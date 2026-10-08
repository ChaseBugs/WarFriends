using Google.Protobuf;
using System.Numerics;
using War.Protocol;
using War.Shared;

namespace War.BattleServer;

internal sealed record CoopBossRuntimeSources(
    CoopBossAnchorCatalog Anchors,
    CoopBossPathCatalog Paths,
    ArmySpawnPointCatalog Spawns,
    RecoveredBattleMap Map,
    CoopBotHealthCatalog Health,
    CoopBossAttackTimingCatalog AttackTimings,
    CoopBossLoadoutCatalog Loadouts,
    BattleCombatContent WeaponContent,
    CoopShieldStateCatalog ShieldStates);

internal sealed record CoopShieldRuntimeSources(
    CoopShieldStateCatalog States, ShieldSourceCatalog Policy);

internal sealed record CoopBossPreferredShotPlan(
    string PlayerId, CoopBossWeaponSlotKind Slot, string WeaponSourceId);

internal sealed record CoopHostEnemyHitCredit(
    string PlayerId, CoopEnemyKillCredit KillCredit);

internal enum CoopInfantryPointState
{
    ObstacleHiding,
    CornerHiding
}

internal sealed record CoopInfantryPointArrival(
    ulong Tick, int PointComponentFileId, CoopInfantryPointState State,
    ulong FirstShootEligibleTick, ulong? FirstRepositionTick)
{
    internal ulong? FirstCornerChangeTick { get; init; }
    internal bool HasUnchangedObstaclePointForFirstShot =>
        State == CoopInfantryPointState.ObstacleHiding &&
        FirstRepositionTick.HasValue &&
        FirstShootEligibleTick <= FirstRepositionTick.Value;
}

internal sealed record CoopInfantryPlayerTargetPlan(
    ulong EnemyEntityId, string PlayerId, int ShotTargetMask, ulong Tick);

internal sealed record CoopCornerShotAttempt(
    ulong Tick, string PlayerId, Vector3 TargetPosition, bool Exposed,
    ulong? NextEligibleTick, CoopInfantryShotBatch Batch);

internal sealed record CoopInfantryShotBatch(
    int Count, int RealShotMask);

internal sealed record CoopInfantryShotWindup(
    ulong EnemyEntityId, string PlayerId, int TargetTransformFileId,
    Vector3 PreparedAimPosition, Quaternion FinalRootRotation,
    string AnimationClip, string QueuedFireClip,
    ulong StartTick, ulong CallbackTick,
    ulong? CallbackStartedTick, CoopInfantryShotBatch Batch,
    string WeaponPrefabGuid, float WeaponCadenceSeconds)
{
    internal ulong? CompletedTick { get; init; }
    internal ulong? NextEligibleTick { get; init; }
}

internal sealed record CoopInfantryRoundIntent(
    ulong EnemyEntityId, int RoundIndex, ulong Tick, bool Real,
    Vector3 AimPosition, CoopQueuedMuzzleSample? ObservedLocalMuzzle,
    Vector3? ObservedWorldLaunchOrigin);

internal sealed record CoopDiagnosticFlightResult(
    ulong ProjectileId, ulong EnemyEntityId, ulong Tick,
    string Outcome, BulletImpact? Impact);

internal sealed record CoopInfantryPlayerShotTarget(
    ulong EnemyEntityId, string PlayerId, int TransformFileId,
    string SourcePath, Vector3 Position, ulong Tick);

/// <summary>
/// Authenticated co-op mission shell. It owns admission and terminal state but
/// cannot accept combat commands until host AI and player controls are wired.
/// Registration remains closed while this runtime is incomplete.
/// </summary>
internal sealed class CoopMatchRuntime : IMatchRuntime
{
    private const float CornerHideAfterSeconds = 0.7f;
    private const float CornerHideAfterRoundSeconds = 0.5f;
    private sealed class Participant(ParticipantManifest definition)
    {
        public ParticipantManifest Definition { get; } = definition;
        public string PlayerId => Definition.PlayerId;
        public bool Admitted;
        public bool Ready;
        public ulong LastCommandId;
        public int CoverIndex;
        public int DestinationIndex = -1;
        public Vector3 Position;
        public CoopDefendRoute? Route;
        public ulong MoveStartTick;
        public ulong MoveEndTick;
        public float Health = definition.Combat!.MaxHealth;
        public bool Dead;
        public bool HasMoved;
        public ulong DamageRevision;
        public CoopPlayerWeaponState? Weapons;
        public RifleCoverTimeline? ShotTimeline;
        public int ShotAnimationFamily = -1;
        public ulong ShotPoseReadyTick;
        public readonly Dictionary<ulong, (byte[] Payload, MatchReply Reply)> Receipts = [];
    }

    private sealed record SettledWeaponPose(PlayerAimPose Pose,
        string WeaponId);

    private readonly MatchManifest manifest;
    private readonly MissionCatalog missionCatalog;
    private readonly CoopMissionEngine mission;
    private readonly MissionRule missionRule;
    private readonly Func<string, IReadOnlyList<CoopSpawnPoint>> spawnCandidates;
    private readonly CoopEnemyCombatCatalog combat;
    private readonly CoopEnemyDestinationState? enemyDestinations;
    private readonly CoopNavMeshConnectivity? infantryNavigation;
    private readonly Dictionary<ulong, CoopInfantryPathState> infantryPaths = [];
    private readonly Dictionary<ulong, CoopInfantryPointArrival> infantryPointArrivals = [];
    private readonly Dictionary<ulong, CoopInfantryPlayerTargetPlan> infantryFirstTargets = [];
    private readonly Dictionary<ulong, CoopCornerShotAttempt>
        cornerFirstShotAttempts = [];
    private readonly Dictionary<ulong, CoopCornerShotAttempt>
        cornerLatestShotAttempts = [];
    private readonly Dictionary<ulong, CoopInfantryShotWindup>
        infantryShotWindups = [];
    private readonly Dictionary<ulong, List<CoopInfantryRoundIntent>>
        infantryRoundIntents = [];
    private readonly Dictionary<ulong, BulletFlight> diagnosticFlights = [];
    private readonly List<CoopDiagnosticFlightResult> diagnosticFlightResults = [];
    private sealed record PlayerDamageReceipt(string PlayerId,
        ResolvedPlayerDamage Hit, float RandomRoll, ulong Tick,
        PlayerDamageResult Result);
    private readonly Dictionary<ulong, PlayerDamageReceipt> playerDamageReceipts = [];
    private const int MaximumPlayerDamageReceipts = 65_536;
    private CoopPlayerShotCollisionWorld? diagnosticWorld;
    private readonly Dictionary<ulong, ulong> nextCornerChangeTicks = [];
    private readonly Dictionary<ulong, ulong> obstacleRepositionStartedTicks = [];
    private readonly Dictionary<ulong, ulong> nextObstacleRepositionTicks = [];
    private readonly HashSet<ulong> movingObstacleRepositions = [];
    private readonly Func<float> chooseInfantryShotFraction;
    private readonly Func<float> chooseInfantryRepositionFraction;
    private readonly Func<int, int> chooseInfantryPlayer;
    private readonly Func<float> chooseInfantryShieldRoll;
    private readonly Func<int, int, int> chooseInfantryBatchSize;
    private readonly Func<float> chooseInfantryRealShotRoll;
    private readonly Func<float> chooseInfantryFakeDistance;
    private readonly Func<float> chooseInfantryFakeSideRoll;
    private readonly Func<int> chooseCornerChangeSeconds;
    private readonly EnemyPoseCatalog? enemyPoses;
    private readonly CoopAssaulterWeaponCatalog? assaulterWeapon;
    private readonly CoopAssaulterQueueCatalog? assaulterQueue;
    private readonly PlayerPoseCatalog? playerPoses;
    private readonly WeaponBindingGraphCatalog? playerWeaponBindings;
    private readonly RifleBindingCatalog? rifleBindings;
    private readonly uint? enemyBulletMask;
    private readonly PlayerShotTargetCatalog? playerShotTargets;
    private readonly AssaultHelicopterBoxColliderCatalog? assaultHelicopterBody;
    private readonly AssaultHelicopterMeshColliderCatalog? assaultHelicopterMeshes;
    private readonly DroneColliderCatalog? droneColliders;
    private readonly GroundVehicleWeaponCatalog? groundVehicleBodies;
    private readonly HelicopterBodyColliderCatalog? transportHelicopterBodies;
    private readonly HelicopterCrewPointCatalog? transportCrewPoints;
    private readonly CoopSkillShotScoreCatalog? skillShotScores;
    private readonly Func<int, int> chooseSpawnPoint;
    private readonly CoopAirPathReservations? airPathReservations;
    private readonly CoopAirWaypointCatalog? coopAirRoutes;
    private readonly CoopMapSpawnPoints? airSpawnMap;
    private readonly Dictionary<ulong, DroneWaypointState> droneFlights = [];
    private readonly Dictionary<ulong, AssaultHelicopterWaypointState> assaultHelicopterFlights = [];
    private readonly Dictionary<ulong, HelicopterWaypointState> transportHelicopterFlights = [];
    private readonly Dictionary<ulong, HelicopterOrientationState> transportHelicopterOrientations = [];
    private readonly Dictionary<ulong, HelicopterCrewState> transportHelicopterCrew = [];
    private readonly Dictionary<ulong, HelicopterCrewSchedule> transportCrewSchedules = [];
    private readonly Dictionary<ulong, HelicopterGunnerState> transportGunners = [];
    private readonly Func<float> chooseAirDirection;
    private readonly Func<int, int> chooseRusherPlayer;
    private readonly List<BattleCoopEnemySpawn> enemySpawns = [];
    private readonly Dictionary<string, Participant> participants;
    private IReadOnlyDictionary<string, BattleAllocationProjection>? battleAllocations;
    private readonly IReadOnlyDictionary<string, CoopPlayerAnchor> playerStarts;
    private readonly IReadOnlyList<CoopPlayerAnchor> playerPositions;
    private readonly Func<int, int, CoopDefendRoute> routeBetween;
    private readonly int alliedFirstCover;
    private readonly int alliedLastCover;
    private readonly CoopBossMapAnchors? bossAnchors;
    private readonly CoopBotHealth? bossHealth;
    private readonly CoopBossAttackTiming? bossAttackTiming;
    private readonly BattleCombatContent? bossWeaponContent;
    private readonly CoopShieldStateCatalog? shieldStates;
    private readonly ShieldSourceCatalog? shieldPolicy;
    private CoopShieldMatchSimulation? alliedShields;
    private CoopShieldMatchSimulation? enemyShields;
    internal CoopBossLoadout? BossLoadout { get; }
    internal CoopPlayerWeaponCatalog? PlayerWeapons { get; }
    private readonly Func<float>? chooseAttackFraction;
    private CoopBossCombatState? boss;
    internal CoopBossAttackCadence? BossAttackCadence { get; private set; }
    internal CoopBossArsenal? BossArsenal { get; private set; }
    private ulong nextEnemyId = 1;
    private BattlePhase phase = BattlePhase.Waiting;
    private ulong tick;
    private ulong stateRevision;
    private string terminalReason = "";

    public string MatchId => manifest.MatchId;
    public string ManifestHash { get; }
    public bool Terminal => phase is BattlePhase.Ended or BattlePhase.Aborted;

    internal CoopMatchRuntime(MatchManifest allocation, MissionCatalog catalog,
        CoopSpawnPointCatalog spawnPoints, CoopNavMeshPathCatalog paths,
        CoopEnemyCombatCatalog combat,
        Func<int, int>? chooseBehaviour = null,
        Func<int, int>? choosePoint = null,
        CoopShieldRuntimeSources? shieldSources = null,
        CoopSkillShotScoreCatalog? skillShotScores = null,
        BattleCombatContent? playerWeaponContent = null,
        CoopAirWaypointCatalog? coopAirWaypoints = null,
        Func<float>? chooseAirDirection = null,
        CoopEnemyDestinationState? enemyDestinations = null,
        Func<int, int>? chooseRusherPlayer = null,
        CoopNavMeshConnectivity? infantryNavigation = null,
        Func<float>? chooseInfantryShotFraction = null,
        Func<float>? chooseInfantryRepositionFraction = null,
        Func<int, int>? chooseInfantryPlayer = null,
        Func<float>? chooseInfantryShieldRoll = null,
        Func<int>? chooseCornerChangeSeconds = null,
        Func<int, int, int>? chooseInfantryBatchSize = null,
        Func<float>? chooseInfantryRealShotRoll = null,
        Func<float>? chooseInfantryFakeDistance = null,
        Func<float>? chooseInfantryFakeSideRoll = null)
        : this(allocation, catalog, spawnPoints, paths, combat,
            (CoopBossRuntimeSources?)null, chooseBehaviour, choosePoint,
            chooseAttackFraction: null, shieldSources: shieldSources,
            skillShotScores: skillShotScores,
            playerWeaponContent: playerWeaponContent,
            coopAirWaypoints: coopAirWaypoints,
            chooseAirDirection: chooseAirDirection,
            enemyDestinations: enemyDestinations,
            chooseRusherPlayer: chooseRusherPlayer,
            infantryNavigation: infantryNavigation,
            chooseInfantryShotFraction: chooseInfantryShotFraction,
            chooseInfantryRepositionFraction: chooseInfantryRepositionFraction,
            chooseInfantryPlayer: chooseInfantryPlayer,
            chooseInfantryShieldRoll: chooseInfantryShieldRoll,
            chooseCornerChangeSeconds: chooseCornerChangeSeconds,
            chooseInfantryBatchSize: chooseInfantryBatchSize,
            chooseInfantryRealShotRoll: chooseInfantryRealShotRoll,
            chooseInfantryFakeDistance: chooseInfantryFakeDistance,
            chooseInfantryFakeSideRoll: chooseInfantryFakeSideRoll)
    {
    }

    internal CoopMatchRuntime(MatchManifest allocation, MissionCatalog catalog,
        CoopSpawnPointCatalog spawnPoints, CoopNavMeshPathCatalog paths,
        CoopEnemyCombatCatalog combat, CoopBossRuntimeSources? bossSources,
        Func<int, int>? chooseBehaviour, Func<int, int>? choosePoint,
        Func<float>? chooseAttackFraction = null,
        CoopShieldRuntimeSources? shieldSources = null,
        CoopSkillShotScoreCatalog? skillShotScores = null,
        BattleCombatContent? playerWeaponContent = null,
        CoopAirWaypointCatalog? coopAirWaypoints = null,
        Func<float>? chooseAirDirection = null,
        CoopEnemyDestinationState? enemyDestinations = null,
        Func<int, int>? chooseRusherPlayer = null,
        CoopNavMeshConnectivity? infantryNavigation = null,
        Func<float>? chooseInfantryShotFraction = null,
        Func<float>? chooseInfantryRepositionFraction = null,
        Func<int, int>? chooseInfantryPlayer = null,
        Func<float>? chooseInfantryShieldRoll = null,
        Func<int>? chooseCornerChangeSeconds = null,
        Func<int, int, int>? chooseInfantryBatchSize = null,
        Func<float>? chooseInfantryRealShotRoll = null,
        Func<float>? chooseInfantryFakeDistance = null,
        Func<float>? chooseInfantryFakeSideRoll = null)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        missionCatalog = catalog;
        manifest = MatchManifest.Validate(allocation);
        MissionMapRule? missionMap = manifest.MissionIndex is int selectedMission
            ? catalog.MapForMission(selectedMission) : null;
        if (manifest.Mode != MatchManifest.CoopMissionMode ||
            manifest.MissionIndex is not int missionIndex ||
            catalog.SourceSha256 != manifest.CatalogRevision ||
            missionMap == null || manifest.MapId != missionMap.Scene ||
            manifest.MapRevision != missionMap.SceneSha256 ||
            manifest.DurationSeconds != catalog.Get(missionIndex).TimeSeconds)
            throw new InvalidDataException("Co-op allocation differs from source mission authority.");
        if (enemyDestinations != null &&
            (catalog.Get(missionIndex).MissionType == "KillOpponent" ||
             enemyDestinations.Scene != missionMap.Scene ||
             enemyDestinations.SceneSha256 != missionMap.SceneSha256 ||
             !enemyDestinations.UsesCombat(combat)))
            throw new InvalidDataException(
                "Co-op enemy destinations differ from the signed mission map.");
        this.enemyDestinations = enemyDestinations;
        if (infantryNavigation != null && enemyDestinations == null)
            throw new InvalidDataException(
                "Co-op infantry navigation needs host-owned enemy destinations.");
        this.infantryNavigation = infantryNavigation;
        this.chooseInfantryShotFraction = chooseInfantryShotFraction ??
            Random.Shared.NextSingle;
        this.chooseInfantryRepositionFraction =
            chooseInfantryRepositionFraction ?? Random.Shared.NextSingle;
        this.chooseInfantryPlayer = chooseInfantryPlayer ?? Random.Shared.Next;
        this.chooseInfantryShieldRoll = chooseInfantryShieldRoll ??
            Random.Shared.NextSingle;
        this.chooseCornerChangeSeconds = chooseCornerChangeSeconds ??
            (() => Random.Shared.Next(10, 20));
        this.chooseInfantryBatchSize = chooseInfantryBatchSize ??
            Random.Shared.Next;
        this.chooseInfantryRealShotRoll = chooseInfantryRealShotRoll ??
            Random.Shared.NextSingle;
        this.chooseInfantryFakeDistance = chooseInfantryFakeDistance ??
            (() => 0.5f + 0.5f * Random.Shared.NextSingle());
        this.chooseInfantryFakeSideRoll = chooseInfantryFakeSideRoll ??
            Random.Shared.NextSingle;

        ManifestHash = manifest.Digest();
        missionRule = catalog.Get(missionIndex);
        if (playerWeaponContent != null)
            PlayerWeapons = CoopPlayerWeaponCatalog.Bind(manifest, playerWeaponContent);
        enemyPoses = playerWeaponContent?.EnemyPoses;
        assaulterWeapon = playerWeaponContent?.CoopAssaulterWeapon;
        assaulterQueue = playerWeaponContent?.CoopAssaulterQueue;
        playerPoses = playerWeaponContent?.Poses;
        playerWeaponBindings = playerWeaponContent?.AllWeaponBindings;
        rifleBindings = playerWeaponContent?.Bindings;
        enemyBulletMask = playerWeaponContent?.Bindings.BulletMask(1);
        playerShotTargets = playerWeaponContent?.PlayerShotTargets;
        assaultHelicopterBody = playerWeaponContent?.AssaultHelicopterBoxCollider;
        assaultHelicopterMeshes = playerWeaponContent?.AssaultHelicopterMeshColliders;
        droneColliders = playerWeaponContent?.DroneColliders;
        groundVehicleBodies = playerWeaponContent?.GroundVehicleWeapons;
        transportHelicopterBodies = playerWeaponContent?.HelicopterBodyColliders;
        transportCrewPoints = playerWeaponContent?.HelicopterCrewPoints;
        if (missionRule.MissionType == "Score" && skillShotScores == null)
            throw new InvalidDataException("Score mission needs recovered skill-shot points.");
        this.skillShotScores = skillShotScores;
        ArgumentNullException.ThrowIfNull(spawnPoints);
        ArgumentNullException.ThrowIfNull(paths);
        if (bossSources != null && shieldSources != null)
            throw new InvalidDataException("Co-op shield sources were supplied twice.");
        if (missionRule.MissionType == "KillOpponent")
        {
            if (bossSources == null)
                throw new InvalidDataException("Boss mission needs geometry, vitality, timing, and weapons.");
            CoopBossMapAnchors map = bossSources.Anchors.MapForMission(catalog, missionIndex);
            CoopBossMapRoutes routes = bossSources.Paths.MapForMission(catalog, missionIndex);
            this.bossAnchors = map;
            this.bossHealth = bossSources.Health.ForMission(missionIndex);
            bossAttackTiming = bossSources.AttackTimings.ForMission(missionIndex);
            BossLoadout = bossSources.Loadouts.ForMission(missionIndex);
            bossWeaponContent = bossSources.WeaponContent;
            shieldStates = bossSources.ShieldStates;
            shieldPolicy = bossSources.WeaponContent.Shields;
            _ = CoopShieldRankResolver.AlliedRank(manifest);
            this.chooseAttackFraction = chooseAttackFraction;
            var selector = new CoopBossAiSpawnSelector(catalog,
                bossSources.Spawns, bossSources.Map, missionIndex);
            playerPositions = map.PlayerPositions.Select(anchor =>
                new CoopPlayerAnchor(anchor.Index, anchor.ComponentFileId,
                    anchor.GameObjectFileId, anchor.TransformFileId,
                    anchor.Main, anchor.Position)
                {
                    SourceRotation = anchor.Rotation
                }).ToArray();
            routeBetween = routes.Between;
            alliedFirstCover = 4;
            alliedLastCover = 7;
            spawnCandidates = behaviour => selector.Candidates(behaviour)
                .Select(point => new CoopSpawnPoint(point.Collection, point.Order,
                    point.ComponentFileId, point.ComponentType, point.Fraction,
                    point.GameObjectFileId, point.TransformFileId, point.Position))
                .ToArray();
        }
        else
        {
            if (bossSources != null)
                throw new InvalidDataException("Non-boss mission received boss sources.");
            if (shieldSources != null)
            {
                shieldStates = shieldSources.States;
                shieldPolicy = shieldSources.Policy;
                _ = CoopShieldRankResolver.AlliedRank(manifest);
            }
            CoopMapSpawnPoints map = spawnPoints.MapForMission(catalog, missionIndex);
            if (coopAirWaypoints != null)
            {
                coopAirRoutes = coopAirWaypoints;
                airSpawnMap = map;
                airPathReservations = new CoopAirPathReservations(coopAirWaypoints, map);
            }
            CoopMapRoutes routes = paths.MapForMission(catalog, missionIndex);
            var selector = new CoopAiSpawnSelector(catalog, spawnPoints, missionIndex);
            playerPositions = map.PlayerPositions;
            routeBetween = routes.Between;
            alliedFirstCover = 0;
            alliedLastCover = 3;
            spawnCandidates = selector.Candidates;
        }
        CoopPlayerAnchor[] mainPositions = playerPositions
            .Where(position => position.Main &&
                position.Index >= alliedFirstCover && position.Index <= alliedLastCover)
            .OrderBy(position => position.Index)
            .ToArray();
        if (mainPositions.Length != manifest.Players.Length)
            throw new InvalidDataException("Co-op scene lacks both allied main positions.");
        // Photon master used mainPositions[0]. In the self-hosted match, the
        // signed roster order replaces that room-owned assignment.
        playerStarts = manifest.Players
            .Select((player, index) => (player.PlayerId, Position: mainPositions[index]))
            .ToDictionary(entry => entry.PlayerId, entry => entry.Position,
                StringComparer.Ordinal);
        this.combat = combat ?? throw new ArgumentNullException(nameof(combat));
        chooseSpawnPoint = choosePoint ?? Random.Shared.Next;
        this.chooseAirDirection = chooseAirDirection ?? Random.Shared.NextSingle;
        this.chooseRusherPlayer = chooseRusherPlayer ?? Random.Shared.Next;
        mission = new CoopMissionEngine(catalog, missionIndex, chooseBehaviour);
        participants = manifest.Players.ToDictionary(player => player.PlayerId,
            player => new Participant(player), StringComparer.Ordinal);
        foreach (Participant participant in participants.Values)
        {
            if (PlayerWeapons != null)
                participant.Weapons = new CoopPlayerWeaponState(
                    PlayerWeapons.ForPlayer(participant.PlayerId), tick);
            CoopPlayerAnchor start = playerStarts[participant.PlayerId];
            participant.CoverIndex = start.Index;
            participant.Position = start.Position;
        }
        enemyDestinations?.BindToMatch();
    }

    public bool HasPlayer(string playerId) => participants.ContainsKey(playerId);

    internal int? ReservedAirPath(ulong entityId) => airPathReservations?.PathFor(entityId);

    internal CoopAssignedEnemyDestination? EnemyDestination(ulong entityId) =>
        enemyDestinations?.ForEnemy(entityId);

    internal Vector3 PlayerAimForward(string playerId)
    {
        RequireAdmitted(playerId);
        Participant player = participants[playerId];
        if (player.Route != null)
            throw new InvalidOperationException(
                "Moving co-op aim needs the shield-lock handoff timing.");
        CoopPlayerAnchor cover = playerPositions[player.CoverIndex];
        if (cover.SourceRotation is not Quaternion rotation)
            throw new InvalidDataException(
                "Co-op player cover lacks its source rotation.");

        // PlayerController.aimForward uses the negative current defend-point
        // forward while the player is stationary behind that cover.
        Vector3 forward = -Vector3.Transform(Vector3.UnitZ, rotation);
        if (!PlayerHitbox.Finite(forward) ||
            MathF.Abs(forward.LengthSquared() - 1f) > 0.001f)
            throw new InvalidDataException(
                "Co-op player cover has an invalid aim direction.");
        return forward;
    }

    internal CoopInfantryPointArrival? InfantryPointArrival(ulong entityId) =>
        infantryPointArrivals.GetValueOrDefault(entityId);

    internal CoopInfantryPlayerTargetPlan? InfantryFirstPlayerTarget(
        ulong entityId) => infantryFirstTargets.GetValueOrDefault(entityId);

    internal CoopCornerShotAttempt? CornerFirstShotAttempt(
        ulong entityId) => cornerFirstShotAttempts.GetValueOrDefault(entityId);

    internal CoopCornerShotAttempt? CornerLatestShotAttempt(
        ulong entityId) => cornerLatestShotAttempts.GetValueOrDefault(entityId);

    internal CoopInfantryShotWindup? InfantryShotWindup(ulong entityId) =>
        infantryShotWindups.GetValueOrDefault(entityId);

    internal IReadOnlyList<CoopInfantryRoundIntent> InfantryRoundIntents(
        ulong entityId) => infantryRoundIntents.TryGetValue(entityId,
            out List<CoopInfantryRoundIntent>? rounds)
            ? rounds.ToArray() : [];

    internal ulong? NextCornerChangeTick(ulong entityId) =>
        nextCornerChangeTicks.TryGetValue(entityId, out ulong next)
            ? next : null;

    internal ulong? ObstacleRepositionStartedTick(ulong entityId) =>
        obstacleRepositionStartedTicks.TryGetValue(entityId, out ulong start)
            ? start : null;

    internal ulong? NextObstacleRepositionTick(ulong entityId) =>
        nextObstacleRepositionTicks.TryGetValue(entityId, out ulong next)
            ? next : null;

    internal CoopInfantryPlayerShotTarget? PlaceFirstAssaulterPlayerTarget(
        ulong entityId)
    {
        return infantryFirstTargets.TryGetValue(entityId,
            out CoopInfantryPlayerTargetPlan? plan)
            ? PlaceAssaulterPlayerTarget(plan) : null;
    }

    private CoopInfantryPlayerShotTarget? PlaceAssaulterPlayerTarget(
        CoopInfantryPlayerTargetPlan plan)
    {
        ulong entityId = plan.EnemyEntityId;
        if (playerShotTargets == null ||
            !participants.TryGetValue(plan.PlayerId, out Participant? player) ||
            PlaceSettledWeaponPose(player) is not SettledWeaponPose settled)
            return null;
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.DeathTick == 0 &&
            spawn.Behaviour == "Assaulter");
        if (enemy == null)
            return null;
        Vector3 enemyPosition = new(enemy.CurrentX, enemy.CurrentY,
            enemy.CurrentZ);
        PlayerShotTarget selected = playerShotTargets.Nearest(
            plan.ShotTargetMask, enemyPosition,
            target => settled.Pose.BodyTarget(target.TransformFileId).Position);
        Vector3 targetPosition = settled.Pose.BodyTarget(
            selected.TransformFileId).Position;
        return new CoopInfantryPlayerShotTarget(entityId, plan.PlayerId,
            selected.TransformFileId, selected.Path, targetPosition,
            plan.Tick);
    }

    private CoopInfantryPlayerTargetPlan? PlanHostAssaulterPlayerTarget(
        ulong entityId, string playerId)
    {
        if (phase != BattlePhase.Running ||
            !infantryPointArrivals.TryGetValue(entityId,
                out CoopInfantryPointArrival? arrival) ||
            tick < arrival.FirstShootEligibleTick ||
            !participants.TryGetValue(playerId, out Participant? player) ||
            !player.Admitted || !player.Ready || player.Dead ||
            PlaceSettledWeaponPose(player) == null)
            return null;
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.DeathTick == 0 &&
            spawn.Behaviour == "Assaulter");
        if (enemy == null)
            return null;

        float shieldProbability = combat.ShieldHitProbability(enemy.Behaviour);
        if (shieldProbability < 0)
            return null; // PickPlayerOpponent returns without a target.
        Vector3 towardEnemy = new(enemy.CurrentX - player.Position.X,
            enemy.CurrentY - player.Position.Y,
            enemy.CurrentZ - player.Position.Z);
        if (towardEnemy.LengthSquared() == 0)
            return null;

        // The same Client rule is used by stationary Heavy Turret targeting:
        // >50 degrees or a successful HITSHIELDPROB roll chooses Shield (2);
        // otherwise the stationary WholeBody targets use mask 9.
        int targetMask = MatchEngine.HeavyTurretStationaryTargetMask(
            PlayerAimForward(playerId), towardEnemy,
            shieldProbability, chooseInfantryShieldRoll);
        return new CoopInfantryPlayerTargetPlan(
            entityId, playerId, targetMask, tick);
    }

    /// <summary>
    /// A future host AI state may request this after reaching or abandoning
    /// its current point. Clients cannot name or reserve an enemy destination.
    /// </summary>
    internal CoopAssignedEnemyDestination? TryHostRetargetEnemy(ulong entityId)
    {
        if (phase != BattlePhase.Running || enemyDestinations == null)
            return null;
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.DeathTick == 0);
        if (enemy == null)
            return null;

        Vector3? sniperOpponent = null;
        if (enemyDestinations.RequiresSniperTarget(enemy.Behaviour))
        {
            Participant sourceHost = participants[manifest.Players[0].PlayerId];
            if (!sourceHost.Admitted || !sourceHost.Ready || sourceHost.Dead)
                return null;
            sniperOpponent = sourceHost.Position;
        }
        var position = new Vector3(enemy.CurrentX, enemy.CurrentY,
            enemy.CurrentZ);
        CoopAssignedEnemyDestination? destination =
            enemyDestinations.TryRetarget(entityId, enemy.Behaviour,
                enemy.CardUnit, position, sniperOpponent);
        if (destination != null)
        {
            PlanInfantryPath(enemy, destination, position);
            stateRevision++;
        }
        return destination;
    }

    internal IReadOnlyList<HelicopterCrewMemberSnapshot> TransportCrewMembers(ulong entityId)
    {
        return transportHelicopterCrew.TryGetValue(entityId, out HelicopterCrewState? crew)
            ? crew.Snapshot() : [];
    }

    internal IReadOnlyList<HelicopterCrewDescentSnapshot> TransportCrewDescents(ulong entityId)
    {
        return transportHelicopterCrew.TryGetValue(entityId, out HelicopterCrewState? crew)
            ? crew.DescentSnapshot(tick) : [];
    }

    internal HelicopterGunnerSnapshot? TransportGunner(ulong entityId)
    {
        return transportGunners.TryGetValue(entityId, out HelicopterGunnerState? gunner)
            ? gunner.Snapshot() : null;
    }

    internal HelicopterTurretRestPose? PlaceTransportGunner(ulong entityId)
    {
        if (phase != BattlePhase.Running || transportCrewPoints == null ||
            TransportGunner(entityId) is not { TurretEnabled: true })
            return null;
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "DeployHeli" &&
            spawn.PoseTick == tick && spawn.Health > 0 &&
            spawn.DeathTick == 0 && spawn.CurrentRotation != null);
        if (enemy == null)
            return null;
        var position = new Vector3(enemy.CurrentX, enemy.CurrentY, enemy.CurrentZ);
        var rotation = new Quaternion(enemy.CurrentRotation.X,
            enemy.CurrentRotation.Y, enemy.CurrentRotation.Z,
            enemy.CurrentRotation.W);
        return transportCrewPoints.PlaceTurret(position, rotation);
    }

    internal IReadOnlyList<HelicopterCrewPose> AttachedTransportCrewPoses(ulong entityId)
    {
        if (phase != BattlePhase.Running || transportCrewPoints == null ||
            !transportHelicopterCrew.TryGetValue(entityId, out HelicopterCrewState? crew))
            return [];
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "DeployHeli" &&
            spawn.PoseTick == tick && spawn.Health > 0 &&
            spawn.DeathTick == 0 && spawn.CurrentRotation != null);
        if (enemy == null)
            return [];

        var position = new Vector3(enemy.CurrentX, enemy.CurrentY, enemy.CurrentZ);
        var rotation = new Quaternion(enemy.CurrentRotation.X,
            enemy.CurrentRotation.Y, enemy.CurrentRotation.Z,
            enemy.CurrentRotation.W);
        IReadOnlyList<HelicopterCrewMemberSnapshot> members = crew.Snapshot();
        IReadOnlyList<HelicopterCrewPose> poses = transportCrewPoints.PlaceAttached(
            position, rotation, members.Count);
        return poses.Where(pose => members[pose.Slot].DropStartTick == 0)
            .ToArray();
    }

    public bool Admit(string playerId)
    {
        if (phase != BattlePhase.Waiting ||
            !participants.TryGetValue(playerId, out Participant? participant) ||
            participant.Admitted || !mission.Admit(playerId))
            return false;
        participant.Admitted = true;
        stateRevision++;
        return true;
    }

    public bool Resume(string playerId)
    {
        return !Terminal && participants.TryGetValue(playerId, out Participant? participant) &&
            participant.Admitted;
    }

    public bool CancelBeforeStart()
    {
        if (phase != BattlePhase.Waiting)
            return false;
        End(BattlePhase.Aborted, "cancelled-before-start");
        return true;
    }

    public bool AbortForHostShutdown()
    {
        if (Terminal)
            return false;
        End(BattlePhase.Aborted, "host-shutdown");
        return true;
    }

    public void Advance(ulong nextTick)
    {
        if (nextTick < tick)
            throw new InvalidOperationException("Co-op match tick moved backwards.");
        if (Terminal)
            return;

        if (phase == BattlePhase.Waiting)
        {
            ulong admissionDeadline =
                (ulong)manifest.AdmissionSeconds * MatchManifest.TickRate;
            tick = Math.Min(nextTick, admissionDeadline);
            if (nextTick >= admissionDeadline)
                End(BattlePhase.Aborted, "admission-timeout");
            return;
        }

        // A Worker normally advances one tick at a time. Replay and catch-up
        // may jump ahead; each omitted fixed step still owns its timed events
        // and WaveManager's automatic spawn opportunity.
        while (tick < nextTick && phase == BattlePhase.Running)
        {
            tick++;
            foreach (Participant participant in participants.Values)
            {
                AdvancePlayerMovement(participant);
                if (participant.Weapons?.Advance(tick) == true)
                    stateRevision++;
                if (participant.ShotTimeline != null)
                {
                    RifleCoverPhase prior = participant.ShotTimeline.Phase;
                    participant.ShotTimeline.Advance(
                        tick / (double)MatchManifest.TickRate);
                    if (prior != RifleCoverPhase.Idle &&
                        participant.ShotTimeline.Phase == RifleCoverPhase.Idle)
                        participant.ShotPoseReadyTick = checked(
                            tick + MatchManifest.TickRate);
                }
            }
            AdvanceDiagnosticFlights();
            if (alliedShields != null && alliedShields.Advance(tick,
                participants.Values
                    .Where(participant => !participant.Dead &&
                        participant.Route == null)
                    .Select(participant => participant.CoverIndex).ToArray()))
                stateRevision++;
            if (enemyShields != null && enemyShields.Advance(tick,
                boss?.DeathTick == null ? [bossAnchors!.BossStart.Index] : []))
                stateRevision++;
            AdvanceDroneFlights();
            AdvanceAssaultHelicopterFlights();
            AdvanceTransportHelicopterFlights();
            AdvanceInfantryPaths();
            SettleCornerInfantryRoots();
            AdvanceObstacleRepositions();
            ChooseFirstInfantryTargets();
            AdvanceCornerShotTurns();
            AdvanceInfantryShotWindups();
            AdvanceInfantryRoundIntents();
            AdvanceCornerRetargets();
            bool missionEnded = boss?.Advance(tick) ?? mission.AdvanceTick(tick);
            if (missionEnded)
            {
                End(BattlePhase.Ended, mission.Outcome == MissionOutcome.Succeeded
                    ? "mission-success" : "mission-failed");
                break;
            }
            BossAttackCadence?.Advance(tick);
            BossArsenal?.Advance(tick);
            SpawnDueEnemies();
        }
    }

    private void SpawnDueEnemies()
    {
        // Mission.UpdateMission creates timed units; WaveManager also tries one
        // automatic creation when its quarter-second cadence has elapsed.
        foreach (int eventIndex in mission.DueTimedEvents(tick))
        {
            MissionTimedEvent timedEvent = missionRule.Events[eventIndex];
            BattleCoopEnemySpawn? enemy = CreateEnemy(
                timedEvent.Behaviour, timedEvent.Level, true,
                timedEvent.IsCardUnit);
            if (enemy == null)
                continue;
            if (!mission.ConfirmTimedEventSpawn(eventIndex, enemy.EntityId, tick))
                throw new InvalidDataException("A due co-op event rejected its host-created enemy.");
            enemySpawns.Add(enemy);
            stateRevision++;
        }

        int? behaviourIndex = mission.SelectAutomaticBehaviour(tick);
        if (behaviourIndex is not int selectedIndex)
            return;
        MissionSpawnBehaviour behaviour = missionRule.Behaviours[selectedIndex];
        BattleCoopEnemySpawn? automaticEnemy = CreateEnemy(
            behaviour.Name, behaviour.Level, false, false);
        if (automaticEnemy == null)
            return;
        if (!mission.ConfirmAutomaticSpawn(selectedIndex, automaticEnemy.EntityId, tick))
            throw new InvalidDataException("A due co-op spawn rejected its host-created enemy.");
        enemySpawns.Add(automaticEnemy);
        stateRevision++;
    }

    private void AdvanceDroneFlights()
    {
        float time = (float)((double)tick / MatchManifest.TickRate);
        foreach ((ulong entityId, DroneWaypointState flight) in droneFlights.OrderBy(pair => pair.Key))
        {
            flight.Advance(time, 1f / MatchManifest.TickRate);
            BattleCoopEnemySpawn enemy = enemySpawns.Single(spawn => spawn.EntityId == entityId);
            enemy.CurrentX = flight.Position.X;
            enemy.CurrentY = flight.Position.Y;
            enemy.CurrentZ = flight.Position.Z;
            enemy.PoseTick = tick;
            Quaternion rotation = flight.Rotation;
            enemy.CurrentRotation = new BattleJointRotation
            {
                X = rotation.X, Y = rotation.Y, Z = rotation.Z, W = rotation.W
            };
            stateRevision++;
        }
    }

    private void AdvanceAssaultHelicopterFlights()
    {
        float time = (float)((double)tick / MatchManifest.TickRate);
        foreach ((ulong entityId, AssaultHelicopterWaypointState flight) in
            assaultHelicopterFlights.OrderBy(pair => pair.Key))
        {
            flight.Advance(time, 1f / MatchManifest.TickRate);
            BattleCoopEnemySpawn enemy = enemySpawns.Single(spawn => spawn.EntityId == entityId);
            enemy.CurrentX = flight.Position.X;
            enemy.CurrentY = flight.Position.Y;
            enemy.CurrentZ = flight.Position.Z;
            enemy.PoseTick = tick;
            Quaternion rotation = flight.Rotation;
            enemy.CurrentRotation = new BattleJointRotation
            {
                X = rotation.X, Y = rotation.Y, Z = rotation.Z, W = rotation.W
            };
            stateRevision++;
        }
    }

    private void AdvanceTransportHelicopterFlights()
    {
        float time = (float)((double)tick / MatchManifest.TickRate);
        foreach ((ulong entityId, HelicopterWaypointState flight) in
            transportHelicopterFlights.OrderBy(pair => pair.Key))
        {
            bool arrived = flight.Advance(time);
            BattleCoopEnemySpawn enemy = enemySpawns.Single(spawn => spawn.EntityId == entityId);
            if (arrived)
            {
                enemy.StopTick = tick;
                if (transportHelicopterCrew.TryGetValue(entityId, out HelicopterCrewState? crew))
                    transportCrewSchedules.Add(entityId,
                        new HelicopterCrewSchedule(tick, crew.Snapshot().Count));
            }
            if (transportCrewSchedules.TryGetValue(entityId,
                    out HelicopterCrewSchedule? schedule))
            {
                HelicopterCrewState crew = transportHelicopterCrew[entityId];
                crew.Advance(schedule, tick);
                enemy.CrewDropMask = schedule.DueMask(tick);
            }
            if (transportGunners.TryGetValue(entityId, out HelicopterGunnerState? gunner))
            {
                gunner.Advance(tick);
                PublishTransportGunner(enemy, gunner.Snapshot());
            }
            HelicopterOrientationState orientation =
                transportHelicopterOrientations[entityId];
            orientation.Advance(flight.Position, flight.Velocity, flight.Steering,
                flight.TargetPosition, flight.Breaking, 1f / MatchManifest.TickRate);
            enemy.CurrentX = flight.Position.X;
            enemy.CurrentY = flight.Position.Y;
            enemy.CurrentZ = flight.Position.Z;
            enemy.PoseTick = tick;
            Quaternion rotation = orientation.Rotation;
            enemy.CurrentRotation = new BattleJointRotation
            {
                X = rotation.X, Y = rotation.Y, Z = rotation.Z, W = rotation.W
            };
            stateRevision++;
        }
    }

    private static void PublishTransportGunner(BattleCoopEnemySpawn enemy,
        HelicopterGunnerSnapshot gunner)
    {
        enemy.GunnerPointComponentFileId = gunner.PointComponentFileId;
        enemy.GunnerMaxHealth = gunner.MaximumHealth;
        enemy.GunnerHealth = gunner.Health;
        enemy.GunnerSpawnTick = gunner.SpawnTick;
        enemy.GunnerRespawnTick = gunner.RespawnTick;
    }

    private BattleCoopEnemySpawn? CreateEnemy(
        string behaviour, int level, bool timedEvent, bool cardUnit)
    {
        IReadOnlyList<CoopSpawnPoint> candidates = spawnCandidates(behaviour);
        CoopSpawnPoint point;
        if (behaviour == "Drone" && airPathReservations != null)
        {
            // Drone.Spawn filters on path.usedByEntity before choosing an anchor.
            // An exhausted path set cannot create a host-owned enemy yet.
            CoopSpawnPoint? freePoint = airPathReservations.ChooseDrone(candidates, chooseSpawnPoint);
            if (freePoint == null)
                return null;
            point = freePoint;
        }
        else if (behaviour == "Helicopter" && airPathReservations != null)
        {
            CoopSpawnPoint? freePoint = airPathReservations.ChooseAssaultHelicopter(
                candidates, chooseSpawnPoint);
            if (freePoint == null)
                return null;
            point = freePoint;
        }
        else if (behaviour == "DeployHeli" && airPathReservations != null)
        {
            CoopSpawnPoint? freePoint = airPathReservations.ChooseTransportHelicopter(
                candidates, chooseSpawnPoint);
            if (freePoint == null)
                return null;
            point = freePoint;
        }
        else
        {
            int selectedIndex = chooseSpawnPoint(candidates.Count);
            if (selectedIndex < 0 || selectedIndex >= candidates.Count)
                throw new InvalidDataException("Co-op spawn choice is outside the source collection.");
            point = candidates[selectedIndex];
        }
        // The Client's co-op controller scales both paths with COOPHP, but
        // card units first interpolate their named card rows (or row zero when
        // that particular sheet has no card labels).
        float cardProgress = cardUnit ? Math.Clamp(level / 25f, 0f, 1f) : 0f;
        float maximumHealth = cardUnit
            ? combat.CardStats(behaviour, cardProgress).Health
            : combat.OrdinaryStats(behaviour, level).Health;
        var enemy = new BattleCoopEnemySpawn
        {
            EntityId = nextEnemyId++,
            Behaviour = behaviour,
            Level = level,
            SpawnComponentFileId = point.ComponentFileId,
            X = point.Position.X,
            Y = point.Position.Y,
            Z = point.Position.Z,
            SpawnTick = tick,
            TimedEvent = timedEvent,
            CardUnit = cardUnit,
            CardProgress = cardProgress,
            MaxHealth = maximumHealth,
            Health = maximumHealth
        };
        enemy.CurrentX = point.Position.X;
        enemy.CurrentY = point.Position.Y;
        enemy.CurrentZ = point.Position.Z;
        enemy.PoseTick = tick;
        int? rusherTarget = null;
        if (enemyDestinations?.RequiresShieldTarget(behaviour, cardUnit) == true)
        {
            Participant[] activeAllies = manifest.Players
                .Select(player => participants[player.PlayerId])
                .Where(player => player.Admitted && player.Ready && !player.Dead)
                .ToArray();
            if (activeAllies.Length > 0)
            {
                int chosenIndex = chooseRusherPlayer(activeAllies.Length);
                if (chosenIndex < 0 || chosenIndex >= activeAllies.Length)
                    throw new InvalidDataException(
                        "Host Rusher target choice is outside the allied roster.");
                rusherTarget = activeAllies[chosenIndex].CoverIndex;
            }
        }
        Vector3? sniperOpponent = null;
        if (enemyDestinations?.RequiresSniperTarget(behaviour) == true)
        {
            // The recovered Photon master uses its local currentPlayer in
            // PlayerController.GetEnemyOf. Signed roster order owns that
            // master role in this self-hosted co-op runtime.
            Participant sourceHost = participants[manifest.Players[0].PlayerId];
            if (sourceHost.Admitted && sourceHost.Ready && !sourceHost.Dead)
                sniperOpponent = sourceHost.Position;
        }
        CoopAssignedEnemyDestination? destination =
            enemyDestinations?.TryAssignInitial(enemy.EntityId, behaviour,
                cardUnit, point.Position, rusherTarget, sniperOpponent);
        if (destination != null)
            PlanInfantryPath(enemy, destination, point.Position);
        if (point.SourceRotation is Quaternion rotation)
        {
            enemy.SourceRotation = new BattleJointRotation
            {
                X = rotation.X,
                Y = rotation.Y,
                Z = rotation.Z,
                W = rotation.W
            };
            enemy.CurrentRotation = enemy.SourceRotation.Clone();
        }
        if (behaviour == "Drone")
        {
            airPathReservations?.Reserve(enemy.EntityId, point);
            if (airPathReservations != null)
            {
                CoopMapSpawnPoints map = airSpawnMap ??
                    throw new InvalidDataException("Co-op Drone map is unavailable.");
                AirWaypointRoute route = coopAirRoutes!.ForSpawn(map, point.ComponentFileId);
                droneFlights.Add(enemy.EntityId, new DroneWaypointState(
                    route.Waypoints, route.JoinIndex, point.Position, route.Radius,
                    combat.MovementSpeed(behaviour), forward: true, loop: true,
                    chooseAirDirection));
            }
        }
        if (behaviour == "Helicopter" && airPathReservations != null)
        {
            airPathReservations.Reserve(enemy.EntityId, point);
            CoopMapSpawnPoints map = airSpawnMap ??
                throw new InvalidDataException("Co-op Assault Helicopter map is unavailable.");
            AirWaypointRoute route = coopAirRoutes!.ForSpawn(map, point.ComponentFileId);
            assaultHelicopterFlights.Add(enemy.EntityId, new AssaultHelicopterWaypointState(
                route, point.Position, combat.MovementSpeed(behaviour), chooseAirDirection));
        }
        if (behaviour == "DeployHeli" && airPathReservations != null)
        {
            airPathReservations.Reserve(enemy.EntityId, point);
            CoopMapSpawnPoints map = airSpawnMap ??
                throw new InvalidDataException("Co-op Transport Helicopter map is unavailable.");
            AirWaypointRoute route = coopAirRoutes!.ForSpawn(map, point.ComponentFileId);
            transportHelicopterFlights.Add(enemy.EntityId,
                new HelicopterWaypointState(route, point.Position,
                    combat.MovementSpeed(behaviour)));
            transportHelicopterOrientations.Add(enemy.EntityId,
                new HelicopterOrientationState());
            if (transportCrewPoints != null)
            {
                ArmyHelicopterCrewStats crew = combat.TransportCrew(level);
                transportHelicopterCrew.Add(enemy.EntityId,
                    new HelicopterCrewState(crew, transportCrewPoints, tick));
                enemy.CrewCount = (uint)crew.Seats;
                var gunner = new HelicopterGunnerState(
                    transportCrewPoints.TurretPointComponentFileId,
                    crew.SoldierHealth, combat.TransportGunnerRespawnTicks(), tick);
                transportGunners.Add(enemy.EntityId, gunner);
                PublishTransportGunner(enemy, gunner.Snapshot());
            }
        }
        return enemy;
    }

    private void PlanInfantryPath(BattleCoopEnemySpawn enemy,
        CoopAssignedEnemyDestination destination, Vector3 start)
    {
        infantryPaths.Remove(enemy.EntityId);
        infantryPointArrivals.Remove(enemy.EntityId);
        infantryFirstTargets.Remove(enemy.EntityId);
        cornerFirstShotAttempts.Remove(enemy.EntityId);
        cornerLatestShotAttempts.Remove(enemy.EntityId);
        infantryShotWindups.Remove(enemy.EntityId);
        infantryRoundIntents.Remove(enemy.EntityId);
        nextCornerChangeTicks.Remove(enemy.EntityId);
        obstacleRepositionStartedTicks.Remove(enemy.EntityId);
        nextObstacleRepositionTicks.Remove(enemy.EntityId);
        movingObstacleRepositions.Remove(enemy.EntityId);
        // Assaulter follows EnemyController.SetFinalTarget's ordinary walking
        // branch. Rusher, Warp, Parachute, and specialist state machines need
        // separate source rules before their movement can be simulated.
        if (infantryNavigation == null || enemy.Behaviour != "Assaulter")
            return;

        int missionIndex = manifest.MissionIndex!.Value;
        ArmyNavMeshCorridor? corridor = infantryNavigation
            .PlanSourceSpawnCorridor(missionCatalog, missionIndex,
                enemy.SpawnComponentFileId,
                destination.PointComponentFileId, start,
                destination.Position);
        if (corridor == null)
        {
            Vector3? surfaceStart = infantryNavigation.SampleNearest(
                missionCatalog, missionIndex, start, 3f);
            Vector3? surfaceEnd = infantryNavigation.SampleNearest(
                missionCatalog, missionIndex, destination.Position, 3f);
            if (surfaceStart == null || surfaceEnd == null)
                return;
            corridor = infantryNavigation.PlanCorridor(missionCatalog,
                missionIndex, surfaceStart.Value, surfaceEnd.Value);
        }
        if (corridor == null || !corridor.PlanarCovered)
            return;

        infantryPaths[enemy.EntityId] = new CoopInfantryPathState(
            corridor, combat.MovementSpeed(enemy.Behaviour), tick);
    }

    private void AdvanceInfantryPaths()
    {
        var arrived = new List<ulong>();
        foreach ((ulong entityId, CoopInfantryPathState path) in infantryPaths)
        {
            BattleCoopEnemySpawn enemy = enemySpawns.Single(spawn =>
                spawn.EntityId == entityId);
            if (enemy.DeathTick != 0)
                continue;

            Vector3 position = path.PositionAt(tick);
            enemy.CurrentX = position.X;
            enemy.CurrentY = position.Y;
            enemy.CurrentZ = position.Z;
            enemy.PoseTick = tick;
            stateRevision++;
            CoopAssignedEnemyDestination? destination =
                enemyDestinations?.ForEnemy(entityId);
            if (movingObstacleRepositions.Contains(entityId))
            {
                bool reachedNewPoint = destination != null &&
                    Vector2.Distance(new Vector2(position.X, position.Z),
                        new Vector2(destination.Position.X,
                            destination.Position.Z)) < 0.04f;
                if (reachedNewPoint || path.HasArrived(tick))
                {
                    movingObstacleRepositions.Remove(entityId);
                    arrived.Add(entityId);
                }
                continue;
            }
            if (destination != null &&
                Vector2.Distance(new Vector2(position.X, position.Z),
                    new Vector2(destination.Position.X,
                        destination.Position.Z)) < 0.04f)
            {
                // EnemyPoint.IsEnemyPointReached is the Client's walking
                // transition. Shooting is still closed in this runtime.
                string? pointType = enemyDestinations!.PointTypeFor(entityId);
                CoopInfantryPointState pointState = pointType switch
                {
                    "EnemyPointObstacle" => CoopInfantryPointState.ObstacleHiding,
                    "EnemyPointCorner" => CoopInfantryPointState.CornerHiding,
                    _ => throw new InvalidDataException(
                        "Assaulter reached an unsupported source point state.")
                };
                ulong firstShootEligibleTick =
                    FirstInfantryShotEligibleTick(enemy, tick);
                ulong? firstRepositionTick = pointState ==
                    CoopInfantryPointState.ObstacleHiding
                    ? FirstInfantryRepositionTick(tick) : null;
                ulong? firstCornerChangeTick = pointState ==
                    CoopInfantryPointState.CornerHiding
                    ? FirstCornerChangeTick(tick) : null;
                infantryPointArrivals[entityId] = new(
                    tick, destination.PointComponentFileId, pointState,
                    firstShootEligibleTick, firstRepositionTick)
                {
                    FirstCornerChangeTick = firstCornerChangeTick
                };
                if (firstCornerChangeTick.HasValue)
                    nextCornerChangeTicks[entityId] =
                        firstCornerChangeTick.Value;
                if (firstRepositionTick.HasValue)
                    nextObstacleRepositionTicks[entityId] =
                        firstRepositionTick.Value;
                arrived.Add(entityId);
            }
            else if (path.HasArrived(tick))
                arrived.Add(entityId);
        }
        foreach (ulong entityId in arrived)
            infantryPaths.Remove(entityId);
    }

    private void SettleCornerInfantryRoots()
    {
        foreach ((ulong entityId, CoopInfantryPointArrival arrival)
            in infantryPointArrivals)
        {
            if (arrival.State != CoopInfantryPointState.CornerHiding ||
                tick != arrival.Tick + 15 ||
                infantryPaths.ContainsKey(entityId))
                continue;
            BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
                spawn.EntityId == entityId && spawn.Health > 0 &&
                spawn.DeathTick == 0);
            if (enemy == null)
                continue;
            CoopEnemyPoint? point = enemyDestinations?.PointFor(entityId);
            if (point == null ||
                point.ComponentFileId != arrival.PointComponentFileId ||
                point.ComponentType != "EnemyPointCorner")
                throw new InvalidDataException(
                    "Co-op corner arrival lost its source point.");

            // EnemyController's 0.5-second TweenPosition changes X/Z to the
            // corner point but deliberately preserves the soldier's Y.
            enemy.CurrentX = point.Position.X;
            enemy.CurrentZ = point.Position.Z;
            Quaternion rotation = CornerFacing(point);
            enemy.CurrentRotation = new BattleJointRotation
            {
                X = rotation.X, Y = rotation.Y,
                Z = rotation.Z, W = rotation.W
            };
            enemy.PoseTick = tick;
            stateRevision++;
        }
    }

    private static Quaternion CornerFacing(CoopEnemyPoint point)
    {
        if (point.CornerDirection is not Vector3 direction ||
            !PlayerHitbox.Finite(direction) ||
            MathF.Abs(direction.Y) > 0.0001f ||
            direction.LengthSquared() < 0.0001f)
            throw new InvalidDataException(
                "Co-op corner has no planar source direction.");
        Vector3 facing = -direction;
        return Quaternion.CreateFromAxisAngle(Vector3.UnitY,
            MathF.Atan2(facing.X, facing.Z));
    }

    private void AdvanceObstacleRepositions()
    {
        if (enemyDestinations == null || infantryNavigation == null)
            return;
        foreach ((ulong entityId, ulong repositionTick)
            in nextObstacleRepositionTicks.ToArray())
        {
            if (tick != repositionTick ||
                !infantryPointArrivals.TryGetValue(entityId,
                    out CoopInfantryPointArrival? arrival))
                continue;
            if (tick >= arrival.FirstShootEligibleTick ||
                infantryFirstTargets.ContainsKey(entityId))
            {
                // ObstacleHidingUpdate checks the shot first. Its later
                // position draws need the firing/animation state machine.
                nextObstacleRepositionTicks.Remove(entityId);
                continue;
            }
            BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
                spawn.EntityId == entityId && spawn.DeathTick == 0);
            if (enemy == null)
                continue;

            obstacleRepositionStartedTicks.TryAdd(entityId, tick);
            CoopAssignedEnemyDestination? destination =
                enemyDestinations.RegenerateObstaclePosition(entityId);
            if (destination == null)
                throw new InvalidDataException(
                    "Co-op obstacle reposition lost its reserved point.");
            nextObstacleRepositionTicks[entityId] =
                NextObstacleRepositionTickAfter(tick);
            Vector3 start = new(enemy.CurrentX, enemy.CurrentY,
                enemy.CurrentZ);
            int missionIndex = manifest.MissionIndex!.Value;
            Vector3? surfaceStart = infantryNavigation.SampleNearest(
                missionCatalog, missionIndex, start, 3f);
            Vector3? surfaceEnd = infantryNavigation.SampleNearest(
                missionCatalog, missionIndex, destination.Position, 3f);
            ArmyNavMeshCorridor? corridor = surfaceStart.HasValue &&
                surfaceEnd.HasValue ? infantryNavigation.PlanCorridor(
                    missionCatalog, missionIndex, surfaceStart.Value,
                    surfaceEnd.Value) : null;
            if (corridor is not { PlanarCovered: true } ||
                corridor.SmoothedLength <= 0)
                continue;
            infantryPaths[entityId] = new CoopInfantryPathState(corridor,
                combat.MovementSpeed(enemy.Behaviour), tick);
            movingObstacleRepositions.Add(entityId);
            stateRevision++;
        }
    }

    private ulong NextObstacleRepositionTickAfter(ulong startTick)
    {
        float fraction = chooseInfantryRepositionFraction();
        if (!float.IsFinite(fraction) || fraction is < 0 or >= 1)
            throw new InvalidDataException(
                "Co-op infantry reposition choice must be in [0, 1).");
        // ObstacleHidingUpdate draws 2–6 seconds after SetFinalTarget.
        return FirstTickAfterDelay(startTick, 2f + 4f * fraction);
    }

    private ulong FirstInfantryShotEligibleTick(
        BattleCoopEnemySpawn enemy, ulong reachedTick)
    {
        ArmyBaseShotStats shot = enemy.CardUnit
            ? combat.CardShot(enemy.Behaviour, enemy.CardProgress)
            : combat.OrdinaryShot(enemy.Behaviour, enemy.Level);
        float fraction = chooseInfantryShotFraction();
        if (!float.IsFinite(fraction) || fraction is < 0 or >= 1)
            throw new InvalidDataException(
                "Co-op infantry shot choice must be in [0, 1).");

        float delaySeconds = shot.MinShootTime +
            (shot.MaxShootTime - shot.MinShootTime) * fraction;
        // EnemyController checks mTime > mNextShootTime. At fixed 30 Hz,
        // eligibility starts on the first tick strictly after the delay.
        return FirstTickAfterDelay(reachedTick, delaySeconds);
    }

    private ulong FirstInfantryRepositionTick(ulong reachedTick)
    {
        float fraction = chooseInfantryRepositionFraction();
        if (!float.IsFinite(fraction) || fraction is < 0 or >= 1)
            throw new InvalidDataException(
                "Co-op infantry reposition choice must be in [0, 1).");
        // EnemyController.SwitchState(ObstacleHiding) schedules its first
        // SetFinalTarget(enemyPoint) after a separate 2–4 second draw.
        return FirstTickAfterDelay(reachedTick, 2f + 2f * fraction);
    }

    private ulong FirstCornerChangeTick(ulong reachedTick)
    {
        int seconds = chooseCornerChangeSeconds();
        if (seconds is < 10 or >= 20)
            throw new InvalidDataException(
                "Co-op corner change draw must be a 10–19 second integer.");
        // UnityEngine.Random.Range(10, 20) uses an exclusive upper bound.
        return FirstTickAfterDelay(reachedTick, seconds);
    }

    private static ulong FirstTickAfterDelay(ulong startTick,
        float delaySeconds)
    {
        ulong delayTicks = (ulong)Math.Floor(
            delaySeconds * MatchManifest.TickRate) + 1;
        return checked(startTick + delayTicks);
    }

    private void ChooseFirstInfantryTargets()
    {
        foreach ((ulong entityId, CoopInfantryPointArrival arrival)
            in infantryPointArrivals)
        {
            bool obstacleShot = arrival.HasUnchangedObstaclePointForFirstShot;
            bool cornerShot = arrival.State ==
                CoopInfantryPointState.CornerHiding &&
                (!cornerLatestShotAttempts.TryGetValue(entityId,
                    out CoopCornerShotAttempt? previousAttempt) ||
                 previousAttempt.NextEligibleTick <= tick);
            if ((!obstacleShot && !cornerShot) ||
                tick < arrival.FirstShootEligibleTick ||
                infantryFirstTargets.ContainsKey(entityId))
                continue;
            Participant[] eligiblePlayers = manifest.Players
                .Select(entry => participants[entry.PlayerId])
                .Where(player => player.Admitted && player.Ready &&
                    !player.Dead && player.Route == null)
                .ToArray();
            if (eligiblePlayers.Length == 0)
                continue;
            int selectedIndex = chooseInfantryPlayer(eligiblePlayers.Length);
            if (selectedIndex < 0 || selectedIndex >= eligiblePlayers.Length)
                throw new InvalidDataException(
                    "Co-op infantry player choice is outside the living roster.");
            CoopInfantryPlayerTargetPlan? plan =
                PlanHostAssaulterPlayerTarget(entityId,
                    eligiblePlayers[selectedIndex].PlayerId);
            if (plan == null)
                continue;
            CoopInfantryPlayerShotTarget? placedTarget =
                PlaceAssaulterPlayerTarget(plan);
            if (placedTarget == null)
                continue;
            CoopInfantryShotBatch batch = CreateInfantryShotBatch(entityId);
            if (cornerShot)
            {
                CoopEnemyPoint? corner = enemyDestinations?.PointFor(entityId);
                if (corner == null)
                    continue;
                BattleCoopEnemySpawn enemy = enemySpawns.Single(spawn =>
                    spawn.EntityId == entityId);
                Vector3 enemyPosition = new(enemy.CurrentX, enemy.CurrentY,
                    enemy.CurrentZ);
                // PrepareToShoot chooses a target before rejecting a corner
                // angle. CornerHidingUpdate then calls GenerateNextShootTime
                // on rejection; the accepted branch awaits shot animation.
                bool exposed = CoopCornerShotPolicy.CanExpose(corner,
                    enemyPosition, placedTarget.Position);
                ulong? retryTick = exposed ? null :
                    FirstInfantryShotEligibleTick(enemy, tick);
                var attempt = new CoopCornerShotAttempt(tick,
                    plan.PlayerId, placedTarget.Position, exposed, retryTick,
                    batch);
                cornerFirstShotAttempts.TryAdd(entityId, attempt);
                cornerLatestShotAttempts[entityId] = attempt;
                stateRevision++;
                if (!exposed)
                    continue;
            }
            infantryFirstTargets.Add(entityId, plan);
            if (enemyPoses != null)
                infantryShotWindups.Add(entityId,
                    CreateInfantryShotWindup(arrival, placedTarget, batch));
            stateRevision++;
        }
    }

    private CoopInfantryShotBatch CreateInfantryShotBatch(ulong entityId)
    {
        BattleCoopEnemySpawn enemy = enemySpawns.Single(spawn =>
            spawn.EntityId == entityId);
        ArmyBaseShotStats shot = enemy.CardUnit
            ? combat.CardShot(enemy.Behaviour, enemy.CardProgress)
            : combat.OrdinaryShot(enemy.Behaviour, enemy.Level);

        // SoldierBehaviour.StartShooting draws an exclusive-upper-bound
        // integer, clamps it to fourteen rounds, then draws one real/fake
        // flag per round. The host owns every draw before any shot callback.
        int chosenCount = chooseInfantryBatchSize(
            shot.FireBatchSizeMin, shot.FireBatchSizeMax);
        bool validDraw = shot.FireBatchSizeMin == shot.FireBatchSizeMax
            ? chosenCount == shot.FireBatchSizeMin
            : chosenCount >= shot.FireBatchSizeMin &&
              chosenCount < shot.FireBatchSizeMax;
        if (!validDraw)
            throw new InvalidDataException(
                "Co-op infantry batch draw is outside its source range.");
        int count = Math.Clamp(chosenCount, 0, 14);
        int realShotMask = 0;
        for (int index = 0; index < count; index++)
        {
            float roll = chooseInfantryRealShotRoll();
            if (!float.IsFinite(roll) || roll is < 0 or >= 1)
                throw new InvalidDataException(
                    "Co-op infantry real-shot draw must be in [0, 1).");
            if (roll < shot.ProbabilityOfRealShot)
                realShotMask |= 1 << index;
        }
        return new CoopInfantryShotBatch(count, realShotMask);
    }

    private CoopInfantryShotWindup CreateInfantryShotWindup(
        CoopInfantryPointArrival arrival,
        CoopInfantryPlayerShotTarget target,
        CoopInfantryShotBatch batch)
    {
        BattleCoopEnemySpawn enemy = enemySpawns.Single(spawn =>
            spawn.EntityId == target.EnemyEntityId && spawn.DeathTick == 0);
        Vector3 enemyPosition = new(enemy.CurrentX, enemy.CurrentY,
            enemy.CurrentZ);
        string clipName;
        string queuedFireClip;
        float callbackClipLength;
        Quaternion finalRootRotation;
        if (arrival.State == CoopInfantryPointState.ObstacleHiding)
        {
            clipName = "stand_up_begin";
            queuedFireClip = "rifle_shot_loop";
            callbackClipLength = enemyPoses!.Clip(clipName).Length;
            finalRootRotation = CoopAssaulterShotRotation.Obstacle(
                enemyPosition, target.Position);
        }
        else
        {
            CoopEnemyPoint corner = enemyDestinations?.PointFor(
                target.EnemyEntityId) ?? throw new InvalidDataException(
                    "Co-op corner shot has no reserved point.");
            bool rightSide = corner.CornerRightSide ??
                throw new InvalidDataException(
                    "Co-op corner shot has no source-facing side.");
            // EnemyController passes !mCoverShotRight to ShotFromCover.
            // SoldierAnimationController maps that argument back to the
            // exposed side, then queues the corresponding fire clip.
            clipName = rightSide ? "player_look_right3" :
                "player_look_left3";
            queuedFireClip = rightSide ? "player_fire_right3" :
                "player_fire_left3";
            // uncoverLength is always sourced from player_look_right3,
            // even for a left-side shot in the recovered Client.
            callbackClipLength = enemyPoses!.Clip(
                "player_look_right3").Length;
            finalRootRotation = CoopAssaulterShotRotation.Corner(
                corner, enemyPosition, target.Position);
        }
        enemyPoses.Clip(queuedFireClip);
        // EnemyController.Shoot invokes its start callback after the source
        // animation length plus 0.05 seconds. The host observes that callback
        // on the first fixed tick at or after the continuous-time deadline.
        ulong delayTicks = (ulong)Math.Ceiling(
            (callbackClipLength + 0.05f) * MatchManifest.TickRate);
        ulong callbackTick = checked(tick + Math.Max(1UL, delayTicks));
        return new CoopInfantryShotWindup(target.EnemyEntityId,
            target.PlayerId, target.TransformFileId, target.Position,
            finalRootRotation, clipName,
            queuedFireClip, tick,
            callbackTick, null, batch,
            assaulterWeapon!.WeaponPrefabGuid,
            assaulterWeapon.CadenceSeconds);
    }

    private void AdvanceCornerShotTurns()
    {
        foreach ((ulong entityId, CoopInfantryShotWindup windup)
            in infantryShotWindups)
        {
            if (windup.AnimationClip is not
                    ("player_look_right3" or "player_look_left3") ||
                tick <= windup.StartTick ||
                tick > windup.StartTick + 9)
                continue;
            BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
                spawn.EntityId == entityId && spawn.Health > 0 &&
                spawn.DeathTick == 0);
            if (enemy == null)
                continue;
            CoopEnemyPoint? point = enemyDestinations?.PointFor(entityId);
            if (point == null || point.ComponentType != "EnemyPointCorner")
                throw new InvalidDataException(
                    "Co-op corner shot lost its source point.");

            // TweenRotation uses NGUI's default EaseInOut factor. Its
            // default animation curve has unit tangents and is linear, so
            // it leaves this factor unchanged before Quaternion.Slerp.
            float progress = (tick - windup.StartTick) / 9f;
            float eased = progress - MathF.Sin(progress * 2f * MathF.PI) /
                (2f * MathF.PI);
            Quaternion rotation = Quaternion.Slerp(CornerFacing(point),
                windup.FinalRootRotation, eased);
            enemy.CurrentRotation = new BattleJointRotation
            {
                X = rotation.X, Y = rotation.Y,
                Z = rotation.Z, W = rotation.W
            };
            enemy.PoseTick = tick;
            stateRevision++;
        }
    }

    private void AdvanceInfantryShotWindups()
    {
        foreach ((ulong entityId, CoopInfantryShotWindup windup)
            in infantryShotWindups.ToArray())
        {
            if (windup.CallbackStartedTick != null ||
                tick < windup.CallbackTick)
                continue;
            // This is the recovered Shoot callback's state boundary.
            // SoldierBehaviour.Shooting, batch events, projectiles, and
            // damage require separate host authority.
            infantryShotWindups[entityId] = windup with
            {
                CallbackStartedTick = tick
            };
            stateRevision++;
        }
    }

    private void AdvanceInfantryRoundIntents()
    {
        if (assaulterWeapon == null)
            return;
        foreach ((ulong entityId, CoopInfantryShotWindup windup)
            in infantryShotWindups)
        {
            if (windup.CallbackStartedTick is not ulong callbackTick ||
                windup.Batch.Count == 0)
                continue;
            if (!infantryRoundIntents.TryGetValue(entityId,
                    out List<CoopInfantryRoundIntent>? rounds))
            {
                rounds = [];
                infantryRoundIntents.Add(entityId, rounds);
            }
            if (rounds.Count >= windup.Batch.Count)
                continue;

            // WaitForSeconds resumes after EnemyController.Update. The next
            // update first polls ShootingFromWeapon; subsequent Gun.willShoot
            // checks require strictly more than the source rifle cadence.
            ulong nextTick = rounds.Count == 0
                ? checked(callbackTick + 1)
                : assaulterWeapon.NextRoundEligibleTick(rounds[^1].Tick);
            if (tick < nextTick)
                continue;
            int index = rounds.Count;
            bool real = (windup.Batch.RealShotMask & (1 << index)) != 0;
            Vector3 aimPosition = real ? windup.PreparedAimPosition :
                FakeInfantryAimPosition(entityId, windup.PreparedAimPosition);
            // This is an isolated Unity 2018 observation at the elapsed
            // host tick, not a live animation state or projectile origin.
            CoopQueuedMuzzleSample? observedMuzzle = assaulterQueue?.Sample(
                windup.AnimationClip, windup.QueuedFireClip,
                tick - windup.StartTick);
            Vector3? observedWorldOrigin = null;
            CoopInfantryPointState pointState =
                infantryPointArrivals[entityId].State;
            if (observedMuzzle != null &&
                CoopAssaulterShotRotation.FinalRotationReached(
                    pointState, tick - windup.StartTick))
            {
                BattleCoopEnemySpawn enemy = enemySpawns.Single(spawn =>
                    spawn.EntityId == entityId && spawn.DeathTick == 0);
                Vector3 rootPosition = new(enemy.CurrentX, enemy.CurrentY,
                    enemy.CurrentZ);
                observedWorldOrigin = rootPosition + Vector3.Transform(
                    observedMuzzle.LocalPosition,
                    windup.FinalRootRotation) + assaulterWeapon.ShotOffset;
                if (!PlayerHitbox.Finite(observedWorldOrigin.Value))
                    throw new InvalidDataException(
                        "Observed co-op launch origin is not finite.");
            }
            rounds.Add(new CoopInfantryRoundIntent(entityId, index,
                tick, real, aimPosition, observedMuzzle,
                observedWorldOrigin));
            if (rounds.Count == windup.Batch.Count)
            {
                // SoldierBehaviour.Shooting calls EndShooting after its
                // final round, in the same update as that round. Its
                // ReturnToPreviousStateFromShot draws a fresh delay.
                BattleCoopEnemySpawn shootingEnemy = enemySpawns.Single(
                    spawn => spawn.EntityId == entityId &&
                        spawn.DeathTick == 0);
                infantryShotWindups[entityId] = windup with
                {
                    CompletedTick = tick,
                    NextEligibleTick = FirstInfantryShotEligibleTick(
                        shootingEnemy, tick)
                };
            }
            if (real && diagnosticWorld != null)
                TrackDiagnosticAssaulterFlight(entityId, index,
                    diagnosticWorld);
            stateRevision++;
        }
    }

    private Vector3 FakeInfantryAimPosition(ulong entityId,
        Vector3 preparedTarget)
    {
        BattleCoopEnemySpawn enemy = enemySpawns.Single(spawn =>
            spawn.EntityId == entityId && spawn.DeathTick == 0);
        Vector3 enemyPosition = new(enemy.CurrentX, enemy.CurrentY,
            enemy.CurrentZ);
        float distance = chooseInfantryFakeDistance();
        float sideRoll = chooseInfantryFakeSideRoll();
        if (!float.IsFinite(distance) || distance is < 0.5f or > 1f ||
            !float.IsFinite(sideRoll) || sideRoll is < 0f or > 1f)
            throw new InvalidDataException(
                "Co-op fake round offset draw is outside the source range.");

        // SoldierBehaviour.Shooting uses the enemy-to-target cross product.
        // A degenerate horizontal direction contributes zero sideways offset.
        Vector3 sideways = Vector3.Cross(
            enemyPosition - preparedTarget, Vector3.UnitY);
        if (sideways.LengthSquared() > 0)
            sideways = Vector3.Normalize(sideways) * distance;
        if (sideRoll < 0.5f)
            sideways = -sideways;
        Vector3 aim = preparedTarget + sideways +
            new Vector3(0, 0.5f, 0);
        if (!PlayerHitbox.Finite(aim))
            throw new InvalidDataException("Co-op fake round aim is not finite.");
        return aim;
    }

    private void AdvanceCornerRetargets()
    {
        foreach ((ulong entityId, ulong changeTick)
            in nextCornerChangeTicks.ToArray())
        {
            if (tick < changeTick ||
                infantryFirstTargets.ContainsKey(entityId))
                continue;
            // CornerHidingUpdate checks its shot first, then its change
            // timer. A successful target exits hiding; a rejected target
            // can still seek another free point on the same tick.
            if (TryHostRetargetEnemy(entityId) != null)
                continue;

            // With no different free point, the Client adds ten seconds to
            // its original threshold instead of drawing a new interval.
            nextCornerChangeTicks[entityId] = checked(changeTick +
                10UL * MatchManifest.TickRate);
        }
    }

    /// <summary>
    /// Places the recovered infantry idle colliders at the exact spawn tick.
    /// A later tick needs host-owned AI movement and animation before these
    /// colliders can be used for a shot; this method therefore refuses it.
    /// Vehicles and air units have separate source collider families.
    /// </summary>
    internal IReadOnlyList<PlayerHitbox> PlaceNewInfantryHitboxes(ulong entityId)
    {
        if (phase != BattlePhase.Running || enemyPoses == null)
            return [];
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.SpawnTick == tick &&
            spawn.Health > 0 && spawn.DeathTick == 0);
        if (enemy?.SourceRotation == null)
            return [];
        string? clip = combat.InfantryIdleClip(enemy.Behaviour);
        if (clip == null)
            return [];
        var rotation = new Quaternion(enemy.SourceRotation.X,
            enemy.SourceRotation.Y, enemy.SourceRotation.Z,
            enemy.SourceRotation.W);
        var position = new Vector3(enemy.X, enemy.Y, enemy.Z);
        return enemyPoses.Place(clip, position, rotation, 0,
            $"coop/{entityId}/");
    }

    /// <summary>
    /// Samples the recovered run animation at the host route clock. This is
    /// diagnostic geometry: Unity NavMeshAgent turning, acceleration, and
    /// avoidance are not yet reproduced, so the shot collision frame does
    /// not admit these moving hitboxes.
    /// </summary>
    internal IReadOnlyList<PlayerHitbox> PlaceWalkingAssaulterHitboxes(
        ulong entityId)
    {
        if (phase != BattlePhase.Running || enemyPoses == null ||
            movingObstacleRepositions.Contains(entityId) ||
            !infantryPaths.TryGetValue(entityId,
                out CoopInfantryPathState? path))
            return [];
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "Assaulter" &&
            spawn.PoseTick == tick && spawn.Health > 0 &&
            spawn.DeathTick == 0);
        if (enemy == null)
            return [];

        Vector3 direction = path.SmoothedPlanarDirectionAt(tick, 0.6f);
        if (direction == Vector3.Zero)
            return [];
        float heading = MathF.Atan2(direction.X, direction.Z);
        Quaternion rotation = Quaternion.CreateFromAxisAngle(
            Vector3.UnitY, heading);
        Vector3 position = new(enemy.CurrentX, enemy.CurrentY,
            enemy.CurrentZ);
        string clip = ArmyInfantryPosePolicy.For(
            combat.UnitIdFor(enemy.Behaviour)).Walk;
        return enemyPoses.Place(clip, position, rotation,
            path.SecondsSinceStart(tick), $"coop/{entityId}/");
    }

    /// <summary>
    /// Samples the source idle rig after EnemyController's corner position
    /// and rotation tween has finished. The sample remains diagnostic until
    /// the Unity corner transition and following shot pose are verified.
    /// </summary>
    internal IReadOnlyList<PlayerHitbox> PlaceSettledCornerAssaulterHitboxes(
        ulong entityId)
    {
        if (phase != BattlePhase.Running || enemyPoses == null ||
            enemyDestinations == null ||
            !infantryPointArrivals.TryGetValue(entityId,
                out CoopInfantryPointArrival? arrival) ||
            arrival.State != CoopInfantryPointState.CornerHiding ||
            tick < arrival.Tick + 15 ||
            tick >= arrival.FirstShootEligibleTick ||
            (arrival.FirstCornerChangeTick.HasValue &&
                tick >= arrival.FirstCornerChangeTick.Value) ||
            infantryPaths.ContainsKey(entityId) ||
            infantryFirstTargets.ContainsKey(entityId) ||
            infantryShotWindups.ContainsKey(entityId))
            return [];

        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "Assaulter" &&
            spawn.Health > 0 && spawn.DeathTick == 0 &&
            spawn.PoseTick == arrival.Tick + 15 &&
            spawn.CurrentRotation != null);
        CoopEnemyPoint? corner = enemyDestinations.PointFor(entityId);
        if (enemy == null || corner == null ||
            corner.ComponentFileId != arrival.PointComponentFileId ||
            corner.ComponentType != "EnemyPointCorner" ||
            Vector2.Distance(new Vector2(enemy.CurrentX, enemy.CurrentZ),
                new Vector2(corner.Position.X, corner.Position.Z)) >= 0.0001f)
            return [];

        Quaternion rotation = CornerFacing(corner);
        Quaternion currentRotation = new(enemy.CurrentRotation.X,
            enemy.CurrentRotation.Y, enemy.CurrentRotation.Z,
            enemy.CurrentRotation.W);
        if (1 - MathF.Abs(Quaternion.Dot(rotation,
                currentRotation)) > 0.00001f)
            return [];
        Vector3 position = new(enemy.CurrentX, enemy.CurrentY,
            enemy.CurrentZ);
        string clip = combat.InfantryIdleClip(enemy.Behaviour)!;
        float seconds = (tick - arrival.Tick) /
            (float)MatchManifest.TickRate;
        return enemyPoses.Place(clip, position, rotation,
            seconds, $"coop/{entityId}/");
    }

    /// <summary>
    /// Samples the corner uncover while the source root turn is in progress.
    /// These colliders are diagnostic until the full shot lifecycle is proven.
    /// </summary>
    internal IReadOnlyList<PlayerHitbox> PlaceCornerUncoverHitboxes(
        ulong entityId)
    {
        if (phase != BattlePhase.Running || enemyPoses == null ||
            !infantryShotWindups.TryGetValue(entityId,
                out CoopInfantryShotWindup? windup) ||
            windup.AnimationClip is not
                ("player_look_right3" or "player_look_left3") ||
            tick <= windup.StartTick)
            return [];
        float seconds = (tick - windup.StartTick) /
            (float)MatchManifest.TickRate;
        if (seconds > enemyPoses.Clip(windup.AnimationClip).Length)
            return [];
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "Assaulter" &&
            spawn.Health > 0 && spawn.DeathTick == 0 &&
            spawn.PoseTick == windup.StartTick +
                Math.Min(tick - windup.StartTick, 9UL) &&
            spawn.CurrentRotation != null);
        if (enemy == null)
            return [];
        BattleJointRotation facing = enemy.CurrentRotation!;
        Quaternion rotation = new(facing.X, facing.Y, facing.Z, facing.W);
        Vector3 position = new(enemy.CurrentX, enemy.CurrentY,
            enemy.CurrentZ);
        return enemyPoses.Place(windup.AnimationClip, position,
            rotation, seconds, $"coop/{entityId}/");
    }

    /// <summary>
    /// Samples the queued corner fire clip after the look clip ends. A
    /// visible fire pose alone does not prove a projectile or damage event.
    /// </summary>
    internal IReadOnlyList<PlayerHitbox> PlaceCornerFireHitboxes(
        ulong entityId)
    {
        if (phase != BattlePhase.Running || enemyPoses == null ||
            !infantryShotWindups.TryGetValue(entityId,
                out CoopInfantryShotWindup? windup) ||
            windup.AnimationClip is not
                ("player_look_right3" or "player_look_left3") ||
            tick <= windup.StartTick ||
            tick >= CornerCoverBackStartTick(entityId, windup))
            return [];
        float lookTicks = enemyPoses.Clip(windup.AnimationClip).Length *
            MatchManifest.TickRate;
        int lookEndTick = (int)MathF.Round(lookTicks);
        if (MathF.Abs(lookTicks - lookEndTick) > 0.0001f)
            throw new InvalidDataException(
                "Co-op corner look clip does not end on a fixed tick.");
        ulong elapsedTicks = tick - windup.StartTick;
        if (elapsedTicks <= (ulong)lookEndTick)
            return [];
        // Both source look clips exceed fifteen ticks by less than a
        // microsecond. The exported rig has one frame per fixed tick.
        ulong fireStartTick = windup.StartTick + (ulong)lookEndTick;
        if (infantryRoundIntents.TryGetValue(entityId,
                out List<CoopInfantryRoundIntent>? rounds) &&
            rounds.Count > 0)
            fireStartTick = rounds[^1].Tick;
        float fireSeconds = (tick - fireStartTick) /
            (float)MatchManifest.TickRate;
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "Assaulter" &&
            spawn.Health > 0 && spawn.DeathTick == 0 &&
            spawn.PoseTick == windup.StartTick + 9 &&
            spawn.CurrentRotation != null);
        if (enemy == null)
            return [];
        BattleJointRotation facing = enemy.CurrentRotation!;
        Quaternion rotation = new(facing.X, facing.Y, facing.Z, facing.W);
        Vector3 position = new(enemy.CurrentX, enemy.CurrentY,
            enemy.CurrentZ);
        return enemyPoses.Place(windup.QueuedFireClip, position,
            rotation, fireSeconds, $"coop/{entityId}/");
    }

    /// <summary>
    /// Samples the Client's cover-back clip after its strict 0.7-second
    /// hide timer. This is visual evidence, not a verified hit target.
    /// </summary>
    internal IReadOnlyList<PlayerHitbox> PlaceCornerCoverBackHitboxes(
        ulong entityId)
    {
        if (phase != BattlePhase.Running || enemyPoses == null ||
            !infantryShotWindups.TryGetValue(entityId,
                out CoopInfantryShotWindup? windup) ||
            windup.AnimationClip is not
                ("player_look_right3" or "player_look_left3"))
            return [];
        ulong coverStartTick = CornerCoverBackStartTick(entityId, windup);
        if (tick < coverStartTick)
            return [];
        string coverClip = windup.AnimationClip == "player_look_right3"
            ? "player_right_coverBack3" : "player_left_coverBack3";
        float seconds = (tick - coverStartTick) /
            (float)MatchManifest.TickRate;
        if (seconds > enemyPoses.Clip(coverClip).Length)
            return [];
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "Assaulter" &&
            spawn.Health > 0 && spawn.DeathTick == 0 &&
            spawn.PoseTick == windup.StartTick + 9 &&
            spawn.CurrentRotation != null);
        if (enemy == null)
            return [];
        BattleJointRotation facing = enemy.CurrentRotation!;
        Quaternion rotation = new(facing.X, facing.Y, facing.Z, facing.W);
        Vector3 position = new(enemy.CurrentX, enemy.CurrentY,
            enemy.CurrentZ);
        return enemyPoses.Place(coverClip, position, rotation,
            seconds, $"coop/{entityId}/");
    }

    private ulong CornerCoverBackStartTick(ulong entityId,
        CoopInfantryShotWindup windup)
    {
        if (infantryRoundIntents.TryGetValue(entityId,
                out List<CoopInfantryRoundIntent>? rounds) &&
            rounds.Count > 0)
        {
            // Each OnShot restarts ShotFromCover and replaces its hide
            // deadline. The latest round owns the live cover return.
            return FirstTickAfterDelay(rounds[^1].Tick,
                CornerHideAfterRoundSeconds);
        }
        return FirstTickAfterDelay(windup.StartTick,
            CornerHideAfterSeconds);
    }

    /// <summary>
    /// Places the recovered Assault Helicopter body and front glass at its
    /// current host pose. The five body meshes, body box, and front glass
    /// retain distinct damage-part identities.
    /// </summary>
    internal IReadOnlyList<DynamicShotTarget> PlaceAssaultHelicopterTargets(
        ulong entityId)
    {
        if (phase != BattlePhase.Running || assaultHelicopterBody == null ||
            assaultHelicopterMeshes == null)
            return [];
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "Helicopter" &&
            spawn.PoseTick == tick && spawn.Health > 0 &&
            spawn.DeathTick == 0 && spawn.CurrentRotation != null);
        if (enemy == null)
            return [];

        var position = new Vector3(enemy.CurrentX, enemy.CurrentY, enemy.CurrentZ);
        var rotation = new Quaternion(enemy.CurrentRotation.X,
            enemy.CurrentRotation.Y, enemy.CurrentRotation.Z,
            enemy.CurrentRotation.W);
        var targets = new List<DynamicShotTarget>
        {
            new(entityId, AssaultHelicopterBoxColliderCatalog.ColliderFileId,
                27, assaultHelicopterBody.Place(position, rotation),
                HelicopterBody: true)
        };
        targets.AddRange(assaultHelicopterMeshes.Place(position, rotation)
            .Select(part => new DynamicShotTarget(entityId,
                part.ColliderFileId, 27, part.Hitbox,
                HelicopterBody: true)));
        AssaultHelicopterGlassMesh glass = assaultHelicopterMeshes
            .PlaceFrontGlass(position, rotation);
        targets.Add(new DynamicShotTarget(entityId, glass.ColliderFileId,
            8, glass.Hitbox, AssaultGlass: true));
        return targets.AsReadOnly();
    }

    /// <summary>
    /// Places the source Drone box and sphere at the latest host-owned pose.
    /// The root is damageable; its child sphere retains the source layer.
    /// </summary>
    internal IReadOnlyList<DynamicShotTarget> PlaceDroneTargets(ulong entityId)
    {
        if (phase != BattlePhase.Running || droneColliders == null)
            return [];
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "Drone" &&
            spawn.PoseTick == tick && spawn.Health > 0 &&
            spawn.DeathTick == 0 && spawn.CurrentRotation != null);
        if (enemy == null)
            return [];

        var position = new Vector3(enemy.CurrentX, enemy.CurrentY, enemy.CurrentZ);
        var rotation = new Quaternion(enemy.CurrentRotation.X,
            enemy.CurrentRotation.Y, enemy.CurrentRotation.Z,
            enemy.CurrentRotation.W);
        return droneColliders.Place(position, rotation)
            .Select(collider => new DynamicShotTarget(entityId,
                collider.ComponentFileId,
                collider.RootOwned ? 27 : collider.SerializedLayer,
                collider.Hitbox, DroneRoot: collider.RootOwned))
            .ToArray();
    }

    /// <summary>
    /// Places source-owned Humvee, Buggy, Tank, or Transporter body parts when
    /// a co-op enemy spawns. The recovered rotation provides initial facing;
    /// later ticks require host vehicle motion before these shapes are valid.
    /// </summary>
    internal IReadOnlyList<DynamicShotTarget> PlaceNewGroundVehicleTargets(
        ulong entityId)
    {
        if (phase != BattlePhase.Running || groundVehicleBodies == null)
            return [];
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId &&
            (spawn.Behaviour is "Humvee" or "Buggy" or "Tank" or
                "Transporter") &&
            spawn.SpawnTick == tick && spawn.Health > 0 &&
            spawn.DeathTick == 0 && spawn.SourceRotation != null);
        if (enemy == null)
            return [];

        var position = new Vector3(enemy.X, enemy.Y, enemy.Z);
        var rotation = new Quaternion(enemy.SourceRotation.X,
            enemy.SourceRotation.Y, enemy.SourceRotation.Z,
            enemy.SourceRotation.W);
        Vector3 forward = Vector3.Transform(Vector3.UnitZ, rotation);
        string unitId = combat.UnitIdFor(enemy.Behaviour);
        // WaveManager assigns Fractions.Enemies (value 1) before pool
        // re-instantiation. TagsAndLayers maps it to enemy body layers 23
        // for Tank and 27 for the other ground vehicles.
        return groundVehicleBodies.PlaceBody(unitId, entityId,
            position, forward, ownerFraction: 1);
    }

    /// <summary>
    /// Places the eleven recovered transport Helicopter body boxes at the
    /// current host pose.
    /// Its source behavior is DeployHeli; the enemy flying layer is 27 after
    /// DestroyableObjectMultipleParts.ChangeLayer.
    /// </summary>
    internal IReadOnlyList<DynamicShotTarget> PlaceTransportHelicopterTargets(
        ulong entityId)
    {
        if (phase != BattlePhase.Running || transportHelicopterBodies == null)
            return [];
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "DeployHeli" &&
            spawn.PoseTick == tick && spawn.Health > 0 &&
            spawn.DeathTick == 0 && spawn.CurrentRotation != null);
        if (enemy == null)
            return [];

        var position = new Vector3(enemy.CurrentX, enemy.CurrentY, enemy.CurrentZ);
        var rotation = new Quaternion(enemy.CurrentRotation.X,
            enemy.CurrentRotation.Y, enemy.CurrentRotation.Z,
            enemy.CurrentRotation.W);
        return transportHelicopterBodies.Place(position, rotation)
            .Select(collider => new DynamicShotTarget(entityId,
                collider.ColliderFileId, 27, collider.Hitbox,
                HelicopterBody: true))
            .ToArray();
    }

    /// <summary>
    /// Collects the enemy colliders valid at this host tick. An enemy without
    /// a complete current pose is reported, not silently omitted from a ray.
    /// The transport gunner and rope crew are separate live targets and are
    /// not placed yet.
    /// </summary>
    internal CoopEnemyCollisionFrame CurrentEnemyCollisionFrame()
    {
        var targets = new List<DynamicShotTarget>();
        var unplaced = new List<ulong>();
        foreach (BattleCoopEnemySpawn enemy in enemySpawns)
        {
            if (enemy.Health <= 0 || enemy.DeathTick != 0)
                continue;

            IReadOnlyList<DynamicShotTarget> placed = enemy.Behaviour switch
            {
                "Drone" => PlaceDroneTargets(enemy.EntityId),
                "Helicopter" => PlaceAssaultHelicopterTargets(enemy.EntityId),
                "DeployHeli" => PlaceTransportHelicopterTargets(enemy.EntityId),
                "Humvee" or "Buggy" or "Tank" or "Transporter" =>
                    PlaceNewGroundVehicleTargets(enemy.EntityId),
                _ => PlaceInfantryDiagnosticTargets(enemy)
            };
            targets.AddRange(placed);
            // The attached/descending rope crew are separate live soldiers.
            // Their world hitboxes remain unplaced even when the turret gunner
            // is dead, so the helicopter body alone is never a complete world.
            bool hasUnplacedCrew = enemy.Behaviour == "DeployHeli" &&
                transportHelicopterCrew.TryGetValue(enemy.EntityId,
                    out HelicopterCrewState? crew) &&
                crew.Snapshot().Count > 0;
            bool unverifiedCorner = enemy.Behaviour == "Assaulter" &&
                enemy.SpawnTick != tick && placed.Count != 0;
            if (placed.Count == 0 || unverifiedCorner || hasUnplacedCrew ||
                (enemy.Behaviour == "DeployHeli" && enemy.GunnerHealth > 0))
                unplaced.Add(enemy.EntityId);
        }
        return new CoopEnemyCollisionFrame(targets.ToArray(),
            unplaced.ToArray(), BossUnplaced: boss?.Health > 0);
    }

    private IReadOnlyList<DynamicShotTarget> PlaceInfantryDiagnosticTargets(
        BattleCoopEnemySpawn enemy)
    {
        IReadOnlyList<PlayerHitbox> parts = PlaceNewInfantryHitboxes(
            enemy.EntityId);
        if (parts.Count == 0)
            parts = PlaceSettledCornerAssaulterHitboxes(enemy.EntityId);
        if (parts.Count == 0)
            parts = PlaceCornerUncoverHitboxes(enemy.EntityId);
        if (parts.Count == 0)
            parts = PlaceCornerFireHitboxes(enemy.EntityId);
        if (parts.Count == 0)
            parts = PlaceCornerCoverBackHitboxes(enemy.EntityId);
        return parts.Select(part => new DynamicShotTarget(enemy.EntityId,
            0, 23, part, ArmyInfantry: true)).ToArray();
    }

    /// <summary>
    /// Recovers a settled ally's source idle pose at its current cover.
    /// PlayerController finishes its position and rotation tweens and calls
    /// SoldierAnimationController.Idle after arriving. The extra 30 ticks
    /// leave those transitions out of this diagnostic collision window.
    /// </summary>
    private SettledWeaponPose? PlaceSettledWeaponPose(Participant player)
    {
        if (phase != BattlePhase.Running || playerPoses == null ||
            PlayerWeapons == null || playerWeaponBindings == null ||
            !player.Admitted || !player.Ready || player.Dead ||
            player.Route != null || player.Weapons == null ||
            !ShotPoseIsSettled(player) ||
            (player.HasMoved &&
                (tick < player.MoveEndTick ||
                 tick - player.MoveEndTick < MatchManifest.TickRate)))
            return null;

        int slot = player.Weapons.ActiveSlot;
        CoopPlayerWeapon weapon = PlayerWeapons.ForPlayer(player.PlayerId)
            .Single(candidate => candidate.Slot == slot);
        string weaponId = weapon.Weapon.SourceId;
        int family = playerWeaponBindings.Get(weaponId).AnimationFamily;
        string? idleClip = SupportedIdleClip(family, weaponId);
        if (idleClip == null)
            return null;

        CoopPlayerAnchor cover = playerPositions[player.CoverIndex];
        if (cover.SourceRotation is not Quaternion rotation)
            return null;
        PlayerAimPose idlePose = playerPoses.SampleBlended(
            idleClip, 0, true, idleClip, 0, true, 0,
            Quaternion.Identity).Place(cover.Position, rotation);
        return new SettledWeaponPose(idlePose, weaponId);
    }

    private static string? SupportedIdleClip(int family, string weaponId)
    {
        return family switch
        {
            0 when weaponId.StartsWith("Google2u.AssaultRifle_",
                StringComparison.Ordinal) => "idle",
            9 when weaponId.StartsWith("Google2u.AssaultRifle_",
                StringComparison.Ordinal) => "qbz_idle",
            13 when weaponId.StartsWith("Google2u.AssaultRifle_",
                StringComparison.Ordinal) => "qbz2_idle",
            2 when weaponId.StartsWith("Google2u.Bazooka_",
                StringComparison.Ordinal) => "bazooka_idle",
            1 when weaponId.StartsWith("Google2u.Grenade_",
                StringComparison.Ordinal) => "grenade_idle",
            6 when weaponId.StartsWith("Google2u.GrenadeLauncher_",
                StringComparison.Ordinal) => "grenadelauncher_idle",
            4 when weaponId == "Google2u.LMG_Minigun" => "minigun_idle",
            5 when weaponId.StartsWith("Google2u.Pistol_",
                StringComparison.Ordinal) => "pistol_idle",
            7 when weaponId.StartsWith("Google2u.Shotgun_",
                StringComparison.Ordinal) => "shotgunner_idle",
            15 when weaponId.StartsWith("Google2u.AssaultRifle_",
                StringComparison.Ordinal) || weaponId.StartsWith(
                    "Google2u.LMG_", StringComparison.Ordinal) =>
                "shotgunner_idle",
            10 when weaponId.StartsWith("Google2u.SniperRifle_",
                StringComparison.Ordinal) => "sniper_idle",
            _ => null
        };
    }

    private bool ShotPoseIsSettled(Participant player)
    {
        if (player.Weapons?.HasFiredAnyShot != true)
            return true;

        // A previously fired ally can re-enter the diagnostic idle collision
        // window only after the source cover-shot animation has finished.
        return (player.ShotTimeline == null ||
                player.ShotTimeline.Phase == RifleCoverPhase.Idle) &&
            tick >= player.ShotPoseReadyTick;
    }

    private static bool UsesCoverShotTimeline(int animationFamily)
    {
        return animationFamily is 0 or 2 or 4 or 5 or 7 or 9 or 10 or
            13 or 15;
    }

    internal RifleMuzzlePose? PlaceIdlePlayerMuzzle(string playerId)
    {
        if (!participants.TryGetValue(playerId, out Participant? player))
            return null;
        SettledWeaponPose? settled = PlaceSettledWeaponPose(player);
        if (settled == null || !settled.WeaponId.StartsWith(
                "Google2u.AssaultRifle_", StringComparison.Ordinal))
            return null;
        return settled.Pose.Muzzle(settled.WeaponId);
    }

    /// <summary>
    /// Places both allies in source-backed idle poses for an isolated ray.
    /// After a cover move, PlayerController finishes a 0.3-second position
    /// tween, a 0.5-second rotation tween, and SoldierAnimationController
    /// crossfades to idle. Wait a full second after the host route ends.
    /// Moving, firing, dead, or unsampled weapon poses remain unavailable.
    /// </summary>
    internal IReadOnlyList<CollisionPlayer>? PlaceIdleAlliedCollisionPoses()
    {
        if (phase != BattlePhase.Running || playerPoses == null ||
            participants.Count != 2)
            return null;

        var poses = new List<CollisionPlayer>(2);
        foreach (Participant player in manifest.Players.Select(
            definition => participants[definition.PlayerId]))
        {
            SettledWeaponPose? settled = PlaceSettledWeaponPose(player);
            if (settled == null)
                return null;
            // TagsAndLayers.GetFractionBulletLayer(Allies, false) is 22.
            poses.Add(new CollisionPlayer(player.PlayerId,
                settled.Pose.Collision, 22, 2));
        }
        return poses;
    }

    internal CoopPlayerShotHit? TraceIdleAlliedEnemyRay(
        CoopPlayerShotCollisionWorld world, Vector3 origin,
        Vector3 direction, float maximumDistance)
    {
        ArgumentNullException.ThrowIfNull(world);
        IReadOnlyList<CollisionPlayer>? poses =
            PlaceIdleAlliedCollisionPoses();
        if (poses == null || enemyBulletMask is not uint mask)
            return null;
        return world.Trace(origin, direction, maximumDistance,
            mask, poses, alliedShields?.Snapshot());
    }

    /// <summary>
    /// Inspect a current rifle ray from the host-placed muzzle against this
    /// mission's scene and enemy poses. This cannot authorize a hit yet:
    /// pooled and moving enemy colliders are still incomplete.
    /// </summary>
    internal CoopShotHit? TraceCurrentRifleEnemyRay(
        string playerId, CoopShotCollisionWorld world,
        Vector3 direction, float maximumDistance)
    {
        ArgumentNullException.ThrowIfNull(world);
        if (world.Scene != manifest.MapId ||
            world.SceneSha256 != manifest.MapRevision)
            throw new InvalidDataException(
                "Co-op rifle ray uses a different signed scene.");
        if (phase != BattlePhase.Running || rifleBindings == null ||
            PlayerWeapons == null ||
            !participants.TryGetValue(playerId, out Participant? player) ||
            !player.Admitted || !player.Ready || player.Dead ||
            player.Weapons == null)
            return null;

        int slot = player.Weapons.ActiveSlot;
        if (player.Weapons.CheckShot(slot, tick) !=
            CoopShotAvailability.Ready)
            return null;
        RifleMuzzlePose? muzzle = PlaceIdlePlayerMuzzle(playerId);
        if (muzzle == null)
            return null;

        CoopPlayerWeapon equipped = PlayerWeapons.ForPlayer(playerId)
            .Single(weapon => weapon.Slot == slot);
        RifleBinding rifle = rifleBindings.Get(equipped.Weapon.SourceId);
        Vector3 origin = muzzle.Position + rifle.ShotOffset;
        return world.Trace(origin, direction, maximumDistance,
            rifleBindings.BulletMask(2), CurrentEnemyCollisionFrame());
    }

    /// <summary>
    /// Builds a real Assaulter's source slow-bullet flight for inspection.
    /// Every collision query rechecks the current allied pose; a later move
    /// invalidates the diagnostic instead of turning a stale pose into a hit.
    /// No impact from this flight is applied to player health.
    /// </summary>
    internal BulletFlight? CreateDiagnosticAssaulterFlight(
        ulong enemyEntityId, int roundIndex,
        CoopPlayerShotCollisionWorld world)
    {
        ArgumentNullException.ThrowIfNull(world);
        if (phase != BattlePhase.Running || assaulterWeapon == null ||
            world.Scene != manifest.MapId ||
            world.SceneSha256 != manifest.MapRevision ||
            (diagnosticWorld != null &&
                !ReferenceEquals(world, diagnosticWorld)) ||
            enemyBulletMask is not uint mask ||
            !infantryRoundIntents.TryGetValue(enemyEntityId,
                out List<CoopInfantryRoundIntent>? rounds) ||
            roundIndex < 0 || roundIndex >= rounds.Count)
            return null;

        CoopInfantryRoundIntent round = rounds[roundIndex];
        if (!round.Real || round.Tick != tick ||
            round.ObservedWorldLaunchOrigin is not Vector3 origin ||
            PlaceIdleAlliedCollisionPoses() == null)
            return null;

        ulong projectileId = checked(enemyEntityId * 16 +
            (ulong)roundIndex + 1);
        return new BulletFlight(projectileId, enemyEntityId,
            assaulterWeapon.RealBulletFlight(), origin,
            round.AimPosition, tick, (from, direction, range) =>
            {
                IReadOnlyList<CollisionPlayer>? currentPoses =
                    PlaceIdleAlliedCollisionPoses();
                if (currentPoses == null)
                    throw new InvalidOperationException(
                        "Co-op bullet lost its current allied poses.");
                return world.Trace(from, direction, range, mask,
                    currentPoses, alliedShields?.Snapshot())
                    ?.ToBulletCollision();
            });
    }

    internal IReadOnlyList<CoopDiagnosticFlightResult>
        DiagnosticFlightResults() => diagnosticFlightResults.ToArray();

    /// <summary>
    /// Inspects a completed diagnostic hit without changing shield health.
    /// Collision coverage must be completed before this can become authority.
    /// </summary>
    internal CoopAssaulterShieldImpactPlan? PlanDiagnosticShieldImpact(
        ulong projectileId)
    {
        if (diagnosticWorld == null || shieldPolicy == null)
            return null;
        CoopDiagnosticFlightResult? result = diagnosticFlightResults
            .SingleOrDefault(row => row.ProjectileId == projectileId);
        if (result == null)
            return null;
        BattleCoopEnemySpawn? enemy = enemySpawns.SingleOrDefault(
            spawn => spawn.EntityId == result.EnemyEntityId);
        if (enemy == null)
            return null;
        return CoopAssaulterShieldImpactPlanner.FromDiagnostic(result,
            enemy, diagnosticWorld, combat, shieldPolicy);
    }

    /// <summary>
    /// Keeps a diagnostic player hit tied to the admitted target. Damage and
    /// no-damage rolls remain closed until collision is fully authoritative.
    /// </summary>
    internal CoopAssaulterPlayerImpactPlan? PlanDiagnosticPlayerImpact(
        ulong projectileId)
    {
        if (diagnosticWorld == null)
            return null;
        CoopDiagnosticFlightResult? result = diagnosticFlightResults
            .SingleOrDefault(row => row.ProjectileId == projectileId);
        if (result == null)
            return null;
        BattleCoopEnemySpawn? enemy = enemySpawns.SingleOrDefault(
            spawn => spawn.EntityId == result.EnemyEntityId);
        if (enemy == null)
            return null;
        CoopAssaulterPlayerImpactPlan? plan =
            CoopAssaulterPlayerImpactPlanner.FromDiagnostic(result,
                enemy, combat);
        if (plan == null ||
            !participants.TryGetValue(plan.PlayerId,
                out Participant? player) ||
            !player.Admitted || !player.Ready || player.Dead)
            return null;
        return plan;
    }

    internal void AttachDiagnosticWorld(CoopPlayerShotCollisionWorld world)
    {
        ArgumentNullException.ThrowIfNull(world);
        if (diagnosticWorld != null || tick != 0 ||
            world.Scene != manifest.MapId ||
            world.SceneSha256 != manifest.MapRevision ||
            infantryRoundIntents.Count != 0)
            throw new InvalidOperationException(
                "Co-op diagnostic world differs from the signed scene or shot state.");
        diagnosticWorld = world;
    }

    internal IReadOnlyList<ulong> ActiveDiagnosticFlightIds() =>
        diagnosticFlights.Keys.Order().ToArray();

    internal Vector3? DiagnosticFlightPosition(ulong projectileId) =>
        diagnosticFlights.TryGetValue(projectileId,
            out BulletFlight? flight) ? flight.Position : null;

    internal bool TrackDiagnosticAssaulterFlight(ulong enemyEntityId,
        int roundIndex, CoopPlayerShotCollisionWorld world)
    {
        BulletFlight? flight = CreateDiagnosticAssaulterFlight(
            enemyEntityId, roundIndex, world);
        if (flight == null)
            return false;
        if (diagnosticFlights.Count >= 64)
            throw new InvalidOperationException(
                "Too many diagnostic co-op bullets are active.");
        return diagnosticFlights.TryAdd(flight.Id, flight);
    }

    private void AdvanceDiagnosticFlights()
    {
        foreach ((ulong id, BulletFlight flight) in diagnosticFlights.ToArray())
        {
            if (PlaceIdleAlliedCollisionPoses() == null)
            {
                FinishDiagnosticFlight(id, flight, "pose-unavailable", null);
                continue;
            }

            BulletImpact? impact = flight.Advance(tick);
            if (impact != null)
                FinishDiagnosticFlight(id, flight, "impact", impact);
            else if (flight.Finished)
                FinishDiagnosticFlight(id, flight, "miss", null);
        }
    }

    private void FinishDiagnosticFlight(ulong id, BulletFlight flight,
        string outcome, BulletImpact? impact)
    {
        diagnosticFlights.Remove(id);
        if (diagnosticFlightResults.Count == 64)
            diagnosticFlightResults.RemoveAt(0);
        diagnosticFlightResults.Add(new CoopDiagnosticFlightResult(id,
            flight.EnemyEntityId!.Value, tick, outcome, impact));
    }

    /// <summary>
    /// Applies damage already established by host hit simulation. No client
    /// packet routes here: player fire, impact, and ownership still need their
    /// co-op validators before this can become live combat authority.
    /// </summary>
    internal bool ApplyHostEnemyDamage(ulong entityId, float damage, ulong impactTick)
    {
        return ApplyHostEnemyDamage(entityId, damage, impactTick, null);
    }

    /// <summary>
    /// A verified host hit can damage the transport turret soldier without
    /// changing the Helicopter's separate body health. No packet routes here.
    /// </summary>
    internal bool ApplyHostTransportGunnerDamage(ulong entityId, float damage,
        ulong impactTick)
    {
        if (phase != BattlePhase.Running || impactTick != tick ||
            impactTick >= mission.DeadlineTick ||
            !transportGunners.TryGetValue(entityId, out HelicopterGunnerState? gunner))
            return false;
        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(spawn =>
            spawn.EntityId == entityId && spawn.Behaviour == "DeployHeli" &&
            spawn.Health > 0 && spawn.DeathTick == 0);
        if (enemy == null || !gunner.Damage(damage, impactTick))
            return false;
        PublishTransportGunner(enemy, gunner.Snapshot());
        stateRevision++;
        return true;
    }

    /// <summary>
    /// This is a host-only seam. A future hit simulator must establish the
    /// player and damage origin; no client command may supply this credit.
    /// </summary>
    internal bool ApplyHostCreditedEnemyDamage(ulong entityId, float damage,
        ulong impactTick, CoopHostEnemyHitCredit credit)
    {
        if (mission.MissionType != "Score" || credit == null ||
            !participants.TryGetValue(credit.PlayerId, out Participant? player) ||
            !player.Admitted || !player.Ready ||
            !Enum.IsDefined(credit.KillCredit))
            return false;
        return ApplyHostEnemyDamage(entityId, damage, impactTick, credit);
    }

    private bool ApplyHostEnemyDamage(ulong entityId, float damage,
        ulong impactTick, CoopHostEnemyHitCredit? credit)
    {
        if (phase != BattlePhase.Running || impactTick != tick ||
            impactTick >= mission.DeadlineTick ||
            !float.IsFinite(damage) || damage <= 0 || damage > 10_000_000)
            return false;

        BattleCoopEnemySpawn? enemy = enemySpawns.FirstOrDefault(
            spawned => spawned.EntityId == entityId);
        if (enemy == null || enemy.SpawnTick > impactTick ||
            enemy.Health <= 0 || enemy.DeathTick != 0)
            return false;

        float remaining = MathF.Max(0, enemy.Health - damage);
        if (remaining == 0)
        {
            bool confirmed = credit == null
                ? mission.ConfirmAiDeath(entityId, impactTick)
                : mission.ConfirmAttributedAiDeath(entityId, credit.PlayerId,
                    credit.KillCredit, skillShotScores!, impactTick);
            if (!confirmed)
                return false;
        }

        enemy.Health = remaining;
        if (remaining == 0)
        {
            enemy.DeathTick = impactTick;
            enemyDestinations?.Release(entityId);
            infantryPaths.Remove(entityId);
            infantryPointArrivals.Remove(entityId);
            infantryFirstTargets.Remove(entityId);
            cornerFirstShotAttempts.Remove(entityId);
            cornerLatestShotAttempts.Remove(entityId);
            infantryShotWindups.Remove(entityId);
            infantryRoundIntents.Remove(entityId);
            nextCornerChangeTicks.Remove(entityId);
            obstacleRepositionStartedTicks.Remove(entityId);
            nextObstacleRepositionTicks.Remove(entityId);
            movingObstacleRepositions.Remove(entityId);
            if (enemy.Behaviour == "Drone")
            {
                airPathReservations?.Release(entityId);
                droneFlights.Remove(entityId);
            }
            if (enemy.Behaviour == "Helicopter")
            {
                airPathReservations?.Release(entityId);
                assaultHelicopterFlights.Remove(entityId);
            }
            if (enemy.Behaviour == "DeployHeli")
            {
                airPathReservations?.Release(entityId);
                transportHelicopterFlights.Remove(entityId);
                transportHelicopterOrientations.Remove(entityId);
                transportHelicopterCrew.Remove(entityId);
                transportCrewSchedules.Remove(entityId);
                transportGunners.Remove(entityId);
                // DestroyPooled also destroys its attached turret soldier.
                enemy.GunnerHealth = 0;
                enemy.GunnerRespawnTick = 0;
            }
            if (mission.Outcome == MissionOutcome.Succeeded)
                End(BattlePhase.Ended, "mission-success");
        }
        stateRevision++;
        return true;
    }

    /// <summary>Only a validated host impact may call this; packets cannot.</summary>
    internal bool ApplyHostBossDamage(float damage, ulong impactTick)
    {
        if (phase != BattlePhase.Running || boss == null ||
            !boss.ApplyHostDamage(damage, impactTick))
            return false;
        stateRevision++;
        if (mission.Outcome == MissionOutcome.Succeeded)
            End(BattlePhase.Ended, "mission-success");
        return true;
    }

    /// <summary>
    /// Commit ammo only after a host projectile exists for this signed slot.
    /// The client Fire command cannot call this method.
    /// </summary>
    internal bool ConfirmHostPlayerShot(string playerId, int slot,
        Vector3 target, ulong shotTick)
    {
        if (phase != BattlePhase.Running || shotTick != tick ||
            !participants.TryGetValue(playerId, out Participant? player) ||
            !player.Admitted || !player.Ready || player.Dead ||
            player.Route != null || player.Weapons == null ||
            player.Weapons.CheckShot(slot, shotTick) !=
                CoopShotAvailability.Ready ||
            !PlayerHitbox.Finite(target) || playerPoses == null ||
            playerWeaponBindings == null || PlayerWeapons == null)
            return false;

        Vector3 direction = target - player.Position;
        direction.Y = 0;
        float distanceSquared = direction.LengthSquared();
        if (!PlayerHitbox.Finite(direction) ||
            !float.IsFinite(distanceSquared) ||
            distanceSquared < 0.0000001f ||
            playerPositions[player.CoverIndex].SourceRotation is not
                Quaternion coverRotation)
            return false;

        CoopPlayerWeapon selected = PlayerWeapons.ForPlayer(playerId)
            .Single(weapon => weapon.Slot == slot);
        int family = playerWeaponBindings.Get(
            selected.Weapon.SourceId).AnimationFamily;
        if (!UsesCoverShotTimeline(family))
            return false;
        RifleCoverTimeline timeline = player.ShotTimeline != null &&
            player.ShotAnimationFamily == family
                ? player.ShotTimeline
                : new RifleCoverTimeline(playerPoses, family);
        if (timeline != player.ShotTimeline)
            timeline.Advance(tick / (double)MatchManifest.TickRate);

        // PlayerClickWeapon compares the defend point's forward direction
        // against the target from the player's current position.
        Vector3 forward = Vector3.Transform(Vector3.UnitZ, coverRotation);
        bool right = Vector3.Dot(Vector3.UnitY,
            Vector3.Cross(forward, direction)) > 0;
        timeline.Shot(right);
        if (!player.Weapons.ConfirmHostShot(slot, shotTick))
            throw new InvalidOperationException(
                "Validated co-op shot could not consume its ammunition.");
        player.ShotTimeline = timeline;
        player.ShotAnimationFamily = family;
        player.ShotPoseReadyTick = ulong.MaxValue;
        stateRevision++;
        return true;
    }

    public void ConfigureBattleAllocations(IEnumerable<BattleAllocationProjection> allocations)
    {
        ArgumentNullException.ThrowIfNull(allocations);
        if (phase != BattlePhase.Waiting || battleAllocations != null ||
            participants.Values.Any(player => player.Admitted))
            throw new InvalidOperationException(
                "Co-op allocations must be bound once before admission.");

        BattleAllocationProjection[] values = allocations
            .Select(BattleAllocationProjection.Validate).ToArray();
        if (values.Length != manifest.Players.Length ||
            values.Select(value => value.PlayerId)
                .Distinct(StringComparer.Ordinal).Count() != values.Length)
            throw new InvalidDataException(
                "Co-op allocation needs one row for each signed ally.");

        foreach (BattleAllocationProjection value in values)
        {
            ParticipantManifest? signedPlayer = manifest.Players.SingleOrDefault(
                player => player.PlayerId == value.PlayerId);
            if (signedPlayer == null)
                throw new InvalidDataException(
                    "Co-op allocation names a player outside the signed roster.");
            bool normalChanged = signedPlayer.ArmyNormalUpgradeIndexes is { } normal &&
                !normal.SequenceEqual(value.NormalUpgradeIndexes);
            bool specialChanged = signedPlayer.ArmySpecialUpgradeIndexes is { } special &&
                !special.SequenceEqual(value.SpecialUpgradeIndexes);
            bool eliteChanged = signedPlayer.ArmyEliteUpgradeIndexes is { } elite &&
                !elite.SequenceEqual(value.EliteUpgradeIndexes);
            if (normalChanged || specialChanged || eliteChanged)
                throw new InvalidDataException(
                    "Co-op allocation differs from the signed ally's upgrade lanes.");
        }

        battleAllocations = values.ToDictionary(value => value.PlayerId,
            StringComparer.Ordinal);
    }

    internal BattleAllocationProjection AllocationFor(string playerId)
    {
        if (battleAllocations == null ||
            !battleAllocations.TryGetValue(playerId, out BattleAllocationProjection? value))
            throw new InvalidOperationException("Co-op allocation is not bound.");
        // The projection has mutable properties; callers receive a fresh copy.
        return BattleAllocationProjection.Validate(value);
    }

    public MatchReply Command(string playerId, MatchCommand command)
    {
        if (!participants.TryGetValue(playerId, out Participant? participant) ||
            !participant.Admitted)
            return Reply(command.CommandId, "not-admitted");
        if (command.CalculateSize() > 256 ||
            command.IntentCase == MatchCommand.IntentOneofCase.None)
            return Reply(command.CommandId, "invalid-command");

        if (command.IntentCase == MatchCommand.IntentOneofCase.Poll)
            return Reply(0, command.CommandId == 0 ? "state" : "invalid-poll-id");
        if (command.CommandId is 0 or > 100000)
            return Reply(command.CommandId, "invalid-command");

        byte[] payload = command.ToByteArray();
        if (participant.Receipts.TryGetValue(command.CommandId, out var receipt))
            return payload.AsSpan().SequenceEqual(receipt.Payload)
                ? receipt.Reply.Clone() : Reply(command.CommandId, "command-conflict");
        if (Terminal)
            return Reply(command.CommandId, "match-terminal");
        if (command.CommandId != participant.LastCommandId + 1)
            return Reply(command.CommandId, "command-order");

        string code = Apply(participant, command);
        participant.LastCommandId = command.CommandId;
        stateRevision++;
        MatchReply reply = Reply(command.CommandId, code);
        participant.Receipts.Add(command.CommandId, (payload, reply.Clone()));
        if (participant.Receipts.Count > 64)
            participant.Receipts.Remove(command.CommandId - 64);
        return reply;
    }

    private string Apply(Participant participant, MatchCommand command)
    {
        if (command.IntentCase == MatchCommand.IntentOneofCase.Ready)
        {
            if (command.Ready.ManifestHash != ManifestHash)
                return "manifest-mismatch";
            if (participant.Ready)
                return "already-ready";
            if (!mission.MarkReady(participant.PlayerId, tick))
                return "ready-unavailable";
            participant.Ready = true;
            if (mission.Started)
            {
                if (bossAnchors != null && bossHealth != null)
                {
                    boss = new CoopBossCombatState(mission, bossHealth,
                        bossAnchors, tick);
                    BossAttackCadence = new CoopBossAttackCadence(
                        bossAttackTiming!, tick, chooseAttackFraction);
                    BossArsenal = new CoopBossArsenal(
                        BossLoadout!, bossWeaponContent!, tick);
                }
                if (shieldStates != null)
                    alliedShields = new CoopShieldMatchSimulation(manifest,
                        shieldStates, shieldPolicy!, alliedFirstCover, tick);
                if (boss != null)
                    enemyShields = new CoopShieldMatchSimulation(1,
                        bossHealth!.Level,
                        shieldStates!.ForMission(mission.MissionIndex).Bot,
                        shieldPolicy!, firstCover: 0, startingTick: tick);
                phase = BattlePhase.Running;
            }
            return "ready";
        }
        if (command.IntentCase == MatchCommand.IntentOneofCase.Forfeit)
        {
            mission.Leave(participant.PlayerId);
            End(BattlePhase.Ended, "forfeit");
            return "forfeit";
        }
        if (command.IntentCase == MatchCommand.IntentOneofCase.MoveCover)
            return StartPlayerMovement(participant,
                command.MoveCover.Direction,
                command.MoveCover.HasTargetCoverIndex
                    ? command.MoveCover.TargetCoverIndex : null);
        if (command.IntentCase == MatchCommand.IntentOneofCase.SwitchWeapon)
        {
            if (phase != BattlePhase.Running || !participant.Ready || participant.Dead)
                return "match-not-running";
            if (participant.Route != null)
                return "moving";
            if (participant.Weapons == null ||
                !participant.Weapons.TrySelectSlot(command.SwitchWeapon.Slot, tick))
                return "weapon-slot-unavailable";
            if (participant.ShotTimeline != null)
            {
                CoopPlayerWeapon selected = PlayerWeapons!.ForPlayer(
                    participant.PlayerId).Single(weapon =>
                    weapon.Slot == command.SwitchWeapon.Slot);
                int family = playerWeaponBindings!.Get(
                    selected.Weapon.SourceId).AnimationFamily;
                // Grenades use their own throw/launcher gestures. Changing
                // away from a rifle ends its cover animation, but its shot
                // still needs the same one-second collision settling gate.
                if (UsesCoverShotTimeline(family))
                {
                    participant.ShotTimeline = new RifleCoverTimeline(
                        playerPoses!, family);
                    participant.ShotTimeline.Advance(
                        tick / (double)MatchManifest.TickRate);
                }
                else
                    participant.ShotTimeline = null;
                participant.ShotAnimationFamily = family;
                participant.ShotPoseReadyTick = checked(
                    tick + MatchManifest.TickRate);
            }
            return "weapon-selected";
        }
        if (command.IntentCase == MatchCommand.IntentOneofCase.Reload)
        {
            if (phase != BattlePhase.Running || !participant.Ready || participant.Dead)
                return "match-not-running";
            CoopPlayerWeaponState? weapons = participant.Weapons;
            if (weapons == null ||
                !weapons.TryStartReload(weapons.ActiveSlot, tick))
                return "reload-unavailable";
            return "reloading";
        }
        return "coop-command-unavailable";
    }

    private string StartPlayerMovement(Participant participant,
        int direction, int? assertedTargetCover)
    {
        if (phase != BattlePhase.Running || !participant.Ready || participant.Dead)
            return "match-not-running";
        if (direction is not (-1 or 1))
            return "invalid-direction";
        if (participant.Route != null)
            return "already-moving";

        // PlayerController.GoLeft/GoRight scans availablePoints in source
        // order, skips the other fraction and shields occupied by a player.
        // The host also reserves an in-flight destination so simultaneous
        // requests cannot both acquire the same shield.
        int target = participant.CoverIndex + direction;
        while (target >= alliedFirstCover && target <= alliedLastCover)
        {
            if (!participants.Values.Any(other => other != participant &&
                    (other.CoverIndex == target || other.DestinationIndex == target)))
                break;
            target += direction;
        }
        if (target < alliedFirstCover || target > alliedLastCover)
            return "cover-unavailable";
        // PlayerController.GoLeft/GoRight asks Shield.GetLock for one named
        // defend point. Never reserve a different cover behind its back.
        if (assertedTargetCover.HasValue &&
            assertedTargetCover.Value != target)
            return "cover-target-mismatch";

        CoopDefendRoute route = routeBetween(participant.CoverIndex, target);
        participant.HasMoved = true;
        double length = 0;
        for (int index = 1; index < route.Corners.Count; index++)
            length += Vector3.Distance(route.Corners[index - 1], route.Corners[index]);
        if (!double.IsFinite(length) || length <= 0 || length > 100)
            throw new InvalidDataException("Co-op route has an invalid travel length.");

        participant.Route = route;
        participant.DestinationIndex = target;
        // Walking replaces the cover-shot clip. The existing post-arrival
        // settling gate will keep collision poses closed during the tween.
        participant.ShotTimeline?.ResetToIdle();
        participant.ShotPoseReadyTick = 0;
        // PlayerController.GoTo defers NavMeshAgent.SetDestination by 0.02s.
        // At 30 Hz this is the next host tick.
        participant.MoveStartTick = tick + 1;
        participant.MoveEndTick = participant.MoveStartTick +
            (ulong)Math.Max(1, Math.Ceiling(length * MatchManifest.TickRate));
        return "moving";
    }

    private void AdvancePlayerMovement(Participant participant)
    {
        CoopDefendRoute? route = participant.Route;
        if (route == null || tick <= participant.MoveStartTick)
            return;
        if (tick >= participant.MoveEndTick)
        {
            participant.CoverIndex = participant.DestinationIndex;
            participant.Position = playerPositions[participant.CoverIndex].Position;
            participant.DestinationIndex = -1;
            participant.Route = null;
            stateRevision++;
            return;
        }

        double remaining = (double)(tick - participant.MoveStartTick) /
            MatchManifest.TickRate; // PlayerPrefab NavMeshAgent speed is 1 unit/s.
        for (int index = 1; index < route.Corners.Count; index++)
        {
            Vector3 start = route.Corners[index - 1];
            Vector3 end = route.Corners[index];
            float segmentLength = Vector3.Distance(start, end);
            if (remaining <= segmentLength)
            {
                participant.Position = Vector3.Lerp(start, end,
                    (float)(remaining / segmentLength));
                stateRevision++;
                return;
            }
            remaining -= segmentLength;
        }
        participant.Position = route.Corners[^1];
        stateRevision++;
    }

    // Only a later host projectile or AI hit resolver may call this method.
    // Its impact must belong to this live mission tick, after both allies
    // have entered the match. The signed Client cannot request this damage.
    internal PlayerDamageResult? ApplyHostPlayerDamage(
        ulong impactId, string playerId, ResolvedPlayerDamage hit,
        float randomRoll, ulong impactTick)
    {
        // A host collision owns one ID. An exact retry returns its original
        // result even if the first hit killed the player or the clock advanced.
        if (impactId == 0 || hit == null)
            return null;
        if (playerDamageReceipts.TryGetValue(impactId,
                out PlayerDamageReceipt? receipt))
        {
            return receipt.PlayerId == playerId && receipt.Hit == hit &&
                receipt.RandomRoll == randomRoll && receipt.Tick == impactTick
                    ? receipt.Result : null;
        }
        if (playerDamageReceipts.Count >= MaximumPlayerDamageReceipts)
            return null;
        if (phase != BattlePhase.Running || impactTick != tick ||
            impactTick >= mission.DeadlineTick ||
            !participants.TryGetValue(playerId, out Participant? participant) ||
            !participant.Admitted || !participant.Ready || participant.Dead ||
            participant.Definition.Combat == null)
            return null;

        PlayerDamageResult result = PlayerDamage.Resolve(
            participant.Definition.Combat!, participant.Health, hit,
            sameFraction: false, self: false, randomRoll);
        playerDamageReceipts.Add(impactId, new PlayerDamageReceipt(playerId,
            hit, randomRoll, impactTick, result));
        if (!result.Applied)
            return result;

        participant.Health = result.Health;
        participant.Dead = result.Dead;
        participant.DamageRevision++;
        stateRevision++;
        if (result.Dead)
        {
            // GameControllerCoop.OnPlayerControllerKilled enters spectator
            // presentation. The surviving ally can still finish the mission.
            participant.Route = null;
            participant.DestinationIndex = -1;
        }
        return result;
    }

    internal ShieldMutation? ApplyHostShieldShot(
        int coverIndex, string weaponId, float damage)
    {
        if (phase != BattlePhase.Running || alliedShields == null)
            return null;
        ShieldMutation? mutation = alliedShields.ApplyHostShot(
            coverIndex, weaponId, damage, tick);
        if (mutation != null)
            stateRevision++;
        return mutation;
    }

    internal ShieldMutation? ApplyHostEnemyShieldShot(
        int coverIndex, string weaponId, float damage)
    {
        if (phase != BattlePhase.Running || enemyShields == null)
            return null;
        ShieldMutation? mutation = enemyShields.ApplyHostShot(
            coverIndex, weaponId, damage, tick);
        if (mutation != null)
            stateRevision++;
        return mutation;
    }

    // This prepares the Client's first player-target preference pass. It does
    // not perform visibility checks, choose a weapon, or authorize a shot.
    // Pressure and random draw must come from the host AI decision loop.
    internal string? ChooseHostBossPlayerPreference(
        float underPressure, float randomValue)
    {
        if (phase != BattlePhase.Running || boss == null ||
            alliedShields == null || bossAttackTiming == null)
            return null;

        CoopBossPlayerCandidate[] candidates = manifest.Players
            .Select(player => participants[player.PlayerId])
            .Where(player => player.Admitted && player.Ready && !player.Dead)
            .Select(player => new CoopBossPlayerCandidate(
                player.PlayerId,
                Math.Clamp(player.Health /
                    player.Definition.Combat!.MaxHealth, 0f, 1f),
                alliedShields.HealthRatioAt(player.CoverIndex),
                Walking: player.Route != null,
                HasCurrentPoint: true))
            .ToArray();
        return candidates.Length == 0 ? null :
            CoopBossPlayerPreference.Choose(bossAttackTiming, candidates,
                underPressure, randomValue);
    }

    // An open shooting window may prepare a target and source weapon. This
    // does not consume ammunition: sight, aim, and host projectile creation
    // must succeed before BossArsenal.ConfirmShot can run.
    internal CoopBossPreferredShotPlan? PlanPreferredBossPlayerShot(
        float underPressure, float targetDraw, bool inDanger,
        float explosiveDraw, float rifleDraw)
    {
        if (BossAttackCadence?.WindowOpen != true ||
            BossArsenal == null || bossAttackTiming == null)
            return null;
        string? targetId = ChooseHostBossPlayerPreference(
            underPressure, targetDraw);
        if (targetId == null)
            return null;

        CoopBossWeaponSlotKind slot =
            CoopBossWeaponChoice.ForOrdinaryPlayerTarget(
                bossAttackTiming, inDanger,
                BossArsenal.Readiness(CoopBossWeaponSlotKind.Primary, tick),
                BossArsenal.Readiness(CoopBossWeaponSlotKind.Secondary, tick),
                BossArsenal.Readiness(CoopBossWeaponSlotKind.Explosive, tick),
                explosiveDraw, rifleDraw);
        return new CoopBossPreferredShotPlan(targetId, slot,
            BossArsenal.Definition(slot).SourceId);
    }

    // Per-player success presentation from frozen host vitality and clock.
    // Backend reward settlement must still verify the terminal evidence.
    internal CoopMissionSuccessScore? HostSuccessScore(string playerId)
    {
        if (!Terminal || mission.Outcome != MissionOutcome.Succeeded ||
            !participants.TryGetValue(playerId, out Participant? player) ||
            !player.Admitted || player.Dead)
            return null;
        float healthRatio = Math.Clamp(player.Health /
            player.Definition.Combat!.MaxHealth, 0f, 1f);
        ulong remainingTicks = mission.DeadlineTick - tick;
        float remainingTimeRatio = (float)remainingTicks /
            (missionRule.TimeSeconds * MatchManifest.TickRate);
        return CoopMissionScorePolicy.Calculate(missionRule,
            healthRatio, remainingTimeRatio);
    }

    public MatchReply Reply(ulong commandId, string code)
    {
        return new MatchReply
        {
            CommandId = commandId,
            Code = code,
            Snapshot = Snapshot()
        };
    }

    public MatchSnapshot Snapshot()
    {
        var snapshot = new MatchSnapshot
        {
            MatchId = MatchId,
            ManifestHash = ManifestHash,
            Phase = phase,
            ServerTick = tick,
            StartTick = mission.StartTick,
            EndTick = Terminal ? tick : 0,
            TerminalReason = terminalReason,
            RewardEligible = false,
            StateRevision = stateRevision,
            Coop = new BattleCoopState
            {
                MissionIndex = mission.MissionIndex,
                MissionType = mission.MissionType,
                ObjectiveTarget = mission.ObjectiveTarget,
                EnemyKills = mission.EnemyKills,
                ObjectiveScore = mission.Score,
                DeadlineTick = mission.DeadlineTick,
                Started = mission.Started,
                Failed = mission.Outcome == MissionOutcome.Failed ||
                    phase == BattlePhase.Aborted || terminalReason == "forfeit",
                Completed = mission.Outcome == MissionOutcome.Succeeded
            }
        };
        snapshot.Coop.ParticipantIds.AddRange(
            mission.Participants.OrderBy(id => id, StringComparer.Ordinal));
        if (mission.MissionType == "Score")
        {
            foreach (ParticipantManifest player in manifest.Players)
            {
                snapshot.Coop.ParticipantScores.Add(new BattleCoopParticipantScore
                {
                    PlayerId = player.PlayerId,
                    Score = mission.ScoreFor(player.PlayerId)
                });
            }
        }
        if (Terminal && mission.Outcome == MissionOutcome.Succeeded)
        {
            foreach (ParticipantManifest rosterPlayer in manifest.Players)
            {
                CoopMissionSuccessScore? score =
                    HostSuccessScore(rosterPlayer.PlayerId);
                if (score == null)
                    continue;
                snapshot.Coop.SuccessScores.Add(new BattleCoopPlayerScore
                {
                    PlayerId = rosterPlayer.PlayerId,
                    Score = score.Score,
                    Stars = score.Stars
                });
            }
        }
        snapshot.Coop.EnemySpawns.AddRange(
            enemySpawns.Select(enemy => enemy.Clone()));
        AddShields(snapshot, alliedShields);
        AddShields(snapshot, enemyShields);
        if (boss != null)
        {
            snapshot.Coop.Boss = new BattleCoopBossState
            {
                EntityId = boss.EntityId,
                DefendComponentFileId = boss.DefendComponentFileId,
                X = boss.Position.X,
                Y = boss.Position.Y,
                Z = boss.Position.Z,
                RotationX = boss.Rotation.X,
                RotationY = boss.Rotation.Y,
                RotationZ = boss.Rotation.Z,
                RotationW = boss.Rotation.W,
                MaxHealth = boss.MaximumHealth,
                Health = boss.Health,
                SpawnTick = boss.SpawnTick,
                DeathTick = boss.DeathTick ?? 0
            };
            for (int slot = 0; slot < BossLoadout!.Slots.Count; slot++)
            {
                CoopBossWeaponSlot weapon = BossLoadout.Slots[slot];
                snapshot.Coop.Boss.Weapons.Add(new BattleCoopBossWeaponSlot
                {
                    Slot = slot,
                    LevelManagerIndex = weapon.LevelManagerIndex,
                    InventoryIndex = weapon.InventoryIndex,
                    SourceId = weapon.SheetName
                });
            }
        }
        foreach (ParticipantManifest rosterPlayer in manifest.Players)
        {
            CoopPlayerAnchor anchor = playerStarts[rosterPlayer.PlayerId];
            snapshot.Coop.ParticipantStarts.Add(new BattleCoopParticipantStart
            {
                PlayerId = rosterPlayer.PlayerId,
                DefendComponentFileId = anchor.ComponentFileId,
                X = anchor.Position.X,
                Y = anchor.Position.Y,
                Z = anchor.Position.Z
            });
        }
        foreach (Participant participant in participants.Values)
        {
            CoopWeaponReadiness? weapon = participant.Weapons?.Readiness(
                participant.Weapons.ActiveSlot);
            var playerState = new BattlePlayerState
            {
                PlayerId = participant.PlayerId,
                Admitted = participant.Admitted,
                Ready = participant.Ready,
                LastCommandId = participant.LastCommandId,
                ActiveWeaponSlot = weapon?.Slot ?? 0,
                ClipAmmo = weapon?.Clip ?? 0,
                ReserveAmmo = weapon?.Reserve ?? 0,
                ReloadEndTick = weapon?.ReloadEndTick ?? 0,
                NextFireTick = weapon?.NextFireTick ?? 0,
                ShotsFired = weapon?.ShotsFired ?? 0,
                CombatEnabled = false,
                Health = participant.Health,
                MaxHealth = participant.Definition.Combat!.MaxHealth,
                Dead = participant.Dead,
                DamageRevision = participant.DamageRevision,
                CoverIndex = participant.CoverIndex,
                Moving = participant.Route != null,
                MoveEndTick = participant.MoveEndTick,
                PositionX = participant.Position.X,
                PositionY = participant.Position.Y,
                PositionZ = participant.Position.Z
            };
            playerState.RiflePose = StationaryPlayerPose(participant);
            snapshot.Players.Add(playerState);
        }
        return snapshot;
    }

    private RiflePoseState? StationaryPlayerPose(Participant player)
    {
        if (!player.Admitted || !player.Ready || player.Dead ||
            player.Route != null || player.Weapons == null ||
            playerPositions[player.CoverIndex].SourceRotation is not
                Quaternion coverRotation)
            return null;

        if (player.ShotTimeline != null)
            return RiflePoseProjection.Create(tick,
                player.ShotTimeline.Layers, coverRotation,
                Quaternion.Identity, null);

        if (PlayerWeapons == null || playerWeaponBindings == null)
            return null;
        CoopPlayerWeapon selected = PlayerWeapons.ForPlayer(player.PlayerId)
            .Single(weapon => weapon.Slot == player.Weapons.ActiveSlot);
        string? idleClip = SupportedIdleClip(
            playerWeaponBindings.Get(selected.Weapon.SourceId).AnimationFamily,
            selected.Weapon.SourceId);
        if (idleClip == null)
            return null;

        return RiflePoseProjection.Create(tick,
            [new RifleClipLayer(new RifleClipSelection(
                idleClip, 0, 1, true), 1)],
            coverRotation, Quaternion.Identity, null);
    }

    private static void AddShields(MatchSnapshot snapshot,
        CoopShieldMatchSimulation? simulation)
    {
        if (simulation == null)
            return;
        snapshot.Shields.AddRange(simulation.Snapshot().Select(shield =>
            new BattleShieldState
            {
                CoverIndex = shield.CoverIndex,
                OwnerFraction = shield.OwnerFraction,
                Health = shield.Health,
                MaxHealth = shield.MaxHealth,
                Destroyed = shield.Destroyed,
                Revision = shield.Revision
            }));
    }

    public MatchSnapshot TerminalEvidenceSnapshot() => Snapshot();

    public MatchEventBatch EventBatch(string playerId, ulong afterEventId)
    {
        RequireAdmitted(playerId);
        return new MatchEventBatch
        {
            MatchId = MatchId,
            ManifestHash = ManifestHash,
            LatestEventId = 0,
            Code = afterEventId == 0 ? "events" : "invalid-cursor"
        };
    }

    public MatchBarrelBatch BarrelBatch(string playerId)
    {
        RequireAdmitted(playerId);
        return new MatchBarrelBatch
        {
            MatchId = MatchId,
            ManifestHash = ManifestHash,
            StateRevision = stateRevision
        };
    }

    public MatchArmyBatch ArmyBatch(string playerId)
    {
        RequireAdmitted(playerId);
        return new MatchArmyBatch
        {
            MatchId = MatchId,
            ManifestHash = ManifestHash,
            StateRevision = stateRevision,
            Code = "army-disabled"
        };
    }

    public MatchArmyEntityBatch ArmyEntityBatch(
        string playerId, ulong afterEntityKey, ulong expectedRevision)
    {
        RequireAdmitted(playerId);
        return new MatchArmyEntityBatch
        {
            MatchId = MatchId,
            ManifestHash = ManifestHash,
            ServerTick = tick,
            Code = afterEntityKey == 0 && expectedRevision == 0
                ? "army-disabled" : "invalid-cursor"
        };
    }

    private void RequireAdmitted(string playerId)
    {
        if (!participants.TryGetValue(playerId, out Participant? participant) ||
            !participant.Admitted)
            throw new InvalidOperationException("Co-op state requires admission.");
    }

    private void End(BattlePhase finalPhase, string reason)
    {
        if (Terminal)
            return;
        enemyDestinations?.ReleaseAll();
        infantryPaths.Clear();
        infantryPointArrivals.Clear();
        infantryFirstTargets.Clear();
        cornerFirstShotAttempts.Clear();
        cornerLatestShotAttempts.Clear();
        infantryShotWindups.Clear();
        infantryRoundIntents.Clear();
        diagnosticFlights.Clear();
        diagnosticFlightResults.Clear();
        nextCornerChangeTicks.Clear();
        obstacleRepositionStartedTicks.Clear();
        nextObstacleRepositionTicks.Clear();
        movingObstacleRepositions.Clear();
        foreach (Participant participant in participants.Values)
        {
            participant.Route = null;
            participant.DestinationIndex = -1;
            participant.MoveEndTick = 0;
        }
        phase = finalPhase;
        terminalReason = reason;
        stateRevision++;
    }
}
