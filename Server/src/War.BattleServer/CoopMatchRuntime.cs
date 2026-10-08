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

/// <summary>
/// Authenticated co-op mission shell. It owns admission and terminal state but
/// cannot accept combat commands until host AI and player controls are wired.
/// Registration remains closed while this runtime is incomplete.
/// </summary>
internal sealed class CoopMatchRuntime : IMatchRuntime
{
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
        public readonly Dictionary<ulong, (byte[] Payload, MatchReply Reply)> Receipts = [];
    }

    private readonly MatchManifest manifest;
    private readonly MissionCatalog missionCatalog;
    private readonly CoopMissionEngine mission;
    private readonly MissionRule missionRule;
    private readonly Func<string, IReadOnlyList<CoopSpawnPoint>> spawnCandidates;
    private readonly CoopEnemyCombatCatalog combat;
    private readonly CoopEnemyDestinationState? enemyDestinations;
    private readonly CoopNavMeshConnectivity? infantryNavigation;
    private readonly Dictionary<ulong, CoopInfantryPathState> infantryPaths = [];
    private readonly EnemyPoseCatalog? enemyPoses;
    private readonly PlayerPoseCatalog? playerPoses;
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
        CoopNavMeshConnectivity? infantryNavigation = null)
        : this(allocation, catalog, spawnPoints, paths, combat,
            (CoopBossRuntimeSources?)null, chooseBehaviour, choosePoint,
            chooseAttackFraction: null, shieldSources: shieldSources,
            skillShotScores: skillShotScores,
            playerWeaponContent: playerWeaponContent,
            coopAirWaypoints: coopAirWaypoints,
            chooseAirDirection: chooseAirDirection,
            enemyDestinations: enemyDestinations,
            chooseRusherPlayer: chooseRusherPlayer,
            infantryNavigation: infantryNavigation)
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
        CoopNavMeshConnectivity? infantryNavigation = null)
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

        ManifestHash = manifest.Digest();
        missionRule = catalog.Get(missionIndex);
        if (playerWeaponContent != null)
            PlayerWeapons = CoopPlayerWeaponCatalog.Bind(manifest, playerWeaponContent);
        enemyPoses = playerWeaponContent?.EnemyPoses;
        playerPoses = playerWeaponContent?.Poses;
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
                    anchor.Main, anchor.Position)).ToArray();
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
            }
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
        // Assaulter follows EnemyController.SetFinalTarget's ordinary walking
        // branch. Rusher, Warp, Parachute, and specialist state machines need
        // separate source rules before their movement can be simulated.
        if (infantryNavigation == null || enemy.Behaviour != "Assaulter")
            return;

        int missionIndex = manifest.MissionIndex!.Value;
        Vector3? surfaceStart = infantryNavigation.SampleNearest(
            missionCatalog, missionIndex, start, 3f);
        Vector3? surfaceEnd = infantryNavigation.SampleNearest(
            missionCatalog, missionIndex, destination.Position, 3f);
        if (surfaceStart == null || surfaceEnd == null)
            return;

        ArmyNavMeshCorridor? corridor = infantryNavigation.PlanCorridor(
            missionCatalog, missionIndex, surfaceStart.Value,
            surfaceEnd.Value);
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
            if (path.HasArrived(tick))
                arrived.Add(entityId);
        }
        foreach (ulong entityId in arrived)
            infantryPaths.Remove(entityId);
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
                _ => PlaceNewInfantryHitboxes(enemy.EntityId)
                    .Select(hitbox => new DynamicShotTarget(enemy.EntityId,
                        0, 23, hitbox, ArmyInfantry: true))
                    .ToArray()
            };
            targets.AddRange(placed);
            // The attached/descending rope crew are separate live soldiers.
            // Their world hitboxes remain unplaced even when the turret gunner
            // is dead, so the helicopter body alone is never a complete world.
            bool hasUnplacedCrew = enemy.Behaviour == "DeployHeli" &&
                transportHelicopterCrew.TryGetValue(enemy.EntityId,
                    out HelicopterCrewState? crew) &&
                crew.Snapshot().Count > 0;
            if (placed.Count == 0 || hasUnplacedCrew ||
                (enemy.Behaviour == "DeployHeli" && enemy.GunnerHealth > 0))
                unplaced.Add(enemy.EntityId);
        }
        return new CoopEnemyCollisionFrame(targets.ToArray(),
            unplaced.ToArray(), BossUnplaced: boss?.Health > 0);
    }

    /// <summary>
    /// Recovers an untouched ally's idle rifle muzzle from the source rig and
    /// defend-position transform. Moving, firing, or using another weapon
    /// requires a live pose and cannot reuse this starting geometry.
    /// </summary>
    internal RifleMuzzlePose? PlaceIdlePlayerMuzzle(string playerId)
    {
        if (phase != BattlePhase.Running || playerPoses == null ||
            PlayerWeapons == null ||
            !participants.TryGetValue(playerId, out Participant? player) ||
            !player.Admitted || !player.Ready || player.Dead ||
            player.HasMoved || player.Route != null || player.Weapons == null)
            return null;

        CoopPlayerAnchor start = playerStarts[playerId];
        if (start.SourceRotation is not Quaternion rotation)
            return null;
        int slot = player.Weapons.ActiveSlot;
        if (player.Weapons.Readiness(slot).ShotsFired != 0)
            return null;
        CoopPlayerWeapon weapon = PlayerWeapons.ForPlayer(playerId)[slot];
        if (!weapon.Weapon.SourceId.StartsWith(
                "Google2u.AssaultRifle_", StringComparison.Ordinal))
            return null;

        PlayerAimPose idlePose = playerPoses.SampleBlended(
            "idle", 0, true, "idle", 0, true, 0,
            Quaternion.Identity).Place(start.Position, rotation);
        return idlePose.Muzzle(weapon.Weapon.SourceId);
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
    internal bool ConfirmHostPlayerShot(string playerId, int slot, ulong shotTick)
    {
        if (phase != BattlePhase.Running || shotTick != tick ||
            !participants.TryGetValue(playerId, out Participant? player) ||
            !player.Admitted || !player.Ready || player.Dead ||
            player.Weapons == null ||
            !player.Weapons.ConfirmHostShot(slot, shotTick))
            return false;
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
            return StartPlayerMovement(participant, command.MoveCover.Direction);
        if (command.IntentCase == MatchCommand.IntentOneofCase.SwitchWeapon)
        {
            if (phase != BattlePhase.Running || !participant.Ready || participant.Dead)
                return "match-not-running";
            if (participant.Route != null)
                return "moving";
            if (participant.Weapons == null ||
                !participant.Weapons.TrySelectSlot(command.SwitchWeapon.Slot, tick))
                return "weapon-slot-unavailable";
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

    private string StartPlayerMovement(Participant participant, int direction)
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

        CoopDefendRoute route = routeBetween(participant.CoverIndex, target);
        participant.HasMoved = true;
        double length = 0;
        for (int index = 1; index < route.Corners.Count; index++)
            length += Vector3.Distance(route.Corners[index - 1], route.Corners[index]);
        if (!double.IsFinite(length) || length <= 0 || length > 100)
            throw new InvalidDataException("Co-op route has an invalid travel length.");

        participant.Route = route;
        participant.DestinationIndex = target;
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
    // The signed Client cannot report its own health or request this damage.
    internal PlayerDamageResult? ApplyHostPlayerDamage(
        string playerId, ResolvedPlayerDamage hit, float randomRoll)
    {
        if (phase != BattlePhase.Running ||
            !participants.TryGetValue(playerId, out Participant? participant) ||
            !participant.Admitted || participant.Dead)
            return null;

        PlayerDamageResult result = PlayerDamage.Resolve(
            participant.Definition.Combat!, participant.Health, hit,
            sameFraction: false, self: false, randomRoll);
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
            snapshot.Players.Add(new BattlePlayerState
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
            });
        }
        return snapshot;
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
