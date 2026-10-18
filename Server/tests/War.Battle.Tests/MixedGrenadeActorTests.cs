using System.Numerics;
using System.Text.Json;
using System.Text.Json.Nodes;
using War.Backend;
using War.Backend.Legacy;
using War.BattleServer;
using War.Persistence;
using War.Protocol;

/// <summary>Checks dormant grenade actors and active-class collision poses without a placeholder weapon.</summary>
internal static class MixedGrenadeActorTests
{
    private const string Frag = "Google2u.Grenade_FRAG";
    private const string UnownedLauncher = "Google2u.GrenadeLauncher_M320";
    private const float SwipeLength = 7;
    private const float HeldSeconds = 0.2f;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        MatchManifest manifest = CreateStarterManifest(content, directory);
        var map = content.Maps.Single(candidate => candidate.SourceHash == manifest.MapRevision);
        var rifles = new RifleMatchSimulation(manifest, map, content);
        var grenades = new GrenadeMatchSimulation(manifest, map, content.Grenades!);
        grenades.ConfigureShotTargets(content.GrenadeShotTargets!);
        string owner = manifest.Players[0].PlayerId;
        string opponent = manifest.Players[1].PlayerId;
        int checks = Require(!grenades.IsActive(owner) && !grenades.IsActive(opponent) && !grenades.Busy(owner),
            "A rifle participant acquired an implicit grenade actor.");
        checks += Reject(() => grenades.Collision(owner));
        checks += Reject(() => grenades.TraceForArmy(owner, Vector3.Zero, Vector3.UnitX, 1, uint.MaxValue));
        grenades.ConfigureMixedPlayerPoses(playerId => grenades.IsActive(playerId)
            ? grenades.CombatPose(playerId, content.PlayerShotTargets) : rifles.Pose(playerId));
        grenades.Advance(0);
        checks += CheckTrace(grenades, owner,
            new(opponent, rifles.Pose(opponent).Collision, Fraction: manifest.Players[1].Fraction));
        checks += CheckSelection(content, manifest, map, grenades);
        checks += CheckThrowAndDormancy(content, manifest, map, grenades);
        checks += CheckReleaseOrder(content, manifest, map);
        return checks;
    }

    private static int CheckReleaseOrder(BattleCombatContent content, MatchManifest manifest, RecoveredBattleMap map)
    {
        var simulation = new GrenadeMatchSimulation(manifest, map, content.Grenades!);
        var launches = new List<ScheduledGrenadeLaunch>();
        foreach (ParticipantManifest participant in manifest.Players.Reverse())
        {
            CoverNode cover = map.Covers[participant.StartCover];
            WeaponSlotManifest slot = participant.WeaponSlots!.Single(candidate => candidate.Weapon.SourceId == Frag);
            simulation.SelectWeapon(participant.PlayerId, new GrenadeWeaponSelection(slot.Weapon, slot.WeaponUpgrade, 0,
                new(cover.Position, cover.SourceIndex, false)));
            ParticipantManifest opponent = manifest.Players.Single(player => player.PlayerId != participant.PlayerId);
            GrenadeThrowCommand command = CreateSwipe(cover, map.Covers[opponent.StartCover].Position);
            launches.Add(simulation.Begin(participant.PlayerId, command, 0)!);
        }
        int checks = Require(launches[0].LaunchTick == launches[1].LaunchTick,
            "The release-order fixture is not simultaneous.");
        IReadOnlyList<ScheduledGrenadeLaunch> due = [];
        for (ulong tick = 0; tick <= launches[0].LaunchTick; tick++)
        {
            due = simulation.Advance(tick);
        }
        checks += Require(due.Select(launch => launch.Owner)
            .SequenceEqual(manifest.Players.Select(player => player.PlayerId)),
            "Actor creation order changed simultaneous grenade release ordering.");
        return checks;
    }

    private static MatchManifest CreateStarterManifest(BattleCombatContent content, string directory)
    {
        JsonObject root = BattleArmyManifestProjectionTests.CreateTemplate(content, directory);
        var catalog = new BattleMixedManifestCatalog(content);
        foreach (JsonNode? node in root["Players"]!.AsArray())
        {
            JsonObject participant = node!.AsObject();
            var player = new LegacyPlayerDocument
            {
                Id = participant["PlayerId"]!.GetValue<string>(), Name = "MixedActor", Country = "US", Level = 1,
                Serialized = LegacyInitialLoadout.CreateSerializedState()
            };
            catalog.Bind(participant, BattlePlayerPresentationSource.Project(player));
        }
        MatchManifest manifest = MatchManifest.Parse(JsonSerializer.SerializeToUtf8Bytes(root));
        content.ValidateAllocation(manifest);
        return manifest;
    }

    private static int CheckSelection(BattleCombatContent content, MatchManifest manifest,
        RecoveredBattleMap map, GrenadeMatchSimulation grenades)
    {
        ParticipantManifest participant = manifest.Players[0];
        CoverNode cover = map.Covers[participant.StartCover];
        var location = new RifleActorLocation(cover.Position, cover.SourceIndex, false);
        int checks = Reject(() => grenades.SelectWeapon(participant.PlayerId,
            new GrenadeWeaponSelection(content.Grenades!.CreateManifest(UnownedLauncher, 0), 0, 0, location)));
        WeaponSlotManifest slot = participant.WeaponSlots!.Single(candidate => candidate.Weapon.SourceId == Frag);
        CoverNode foreignCover = map.Covers[manifest.Players[1].StartCover];
        checks += Reject(() => grenades.SelectWeapon(participant.PlayerId, new GrenadeWeaponSelection(
            slot.Weapon, slot.WeaponUpgrade, 0, new(foreignCover.Position, foreignCover.SourceIndex, false))));
        checks += Require(!grenades.IsActive(participant.PlayerId), "Rejected selection published a grenade actor.");
        grenades.SelectWeapon(participant.PlayerId,
            new GrenadeWeaponSelection(slot.Weapon, slot.WeaponUpgrade, 0, location));
        checks += Require(grenades.IsActive(participant.PlayerId) &&
            grenades.Collision(participant.PlayerId).RootPosition == cover.Position,
            "An owned grenade did not enter at the authoritative cover.");
        return checks;
    }

    private static int CheckThrowAndDormancy(BattleCombatContent content, MatchManifest manifest,
        RecoveredBattleMap map, GrenadeMatchSimulation grenades)
    {
        ParticipantManifest owner = manifest.Players[0];
        ParticipantManifest opponent = manifest.Players[1];
        CoverNode start = map.Covers[owner.StartCover];
        GrenadeThrowCommand command = CreateSwipe(start, map.Covers[opponent.StartCover].Position);
        ScheduledGrenadeLaunch launch = grenades.Begin(owner.PlayerId, command, 0)!;
        int checks = Require(launch.WeaponSourceId == Frag && grenades.Busy(owner.PlayerId),
            "The mixed actor did not bind its owned FRAG launch.");
        checks += Reject(() => grenades.DeselectWeapon(owner.PlayerId, 0));
        for (ulong tick = 1; tick <= launch.LaunchTick; tick++)
        {
            grenades.Advance(tick);
        }
        checks += Require(PlayerHitbox.Finite(grenades.Muzzle(launch)), "Mixed FRAG release lost its source muzzle.");
        grenades.DeselectWeapon(owner.PlayerId, launch.LaunchTick);
        checks += Require(!grenades.IsActive(owner.PlayerId), "A deselected grenade actor stayed active.");
        checks += Reject(() => grenades.CombatPose(owner.PlayerId, content.PlayerShotTargets));
        checks += Reject(() => grenades.Begin(owner.PlayerId, command, launch.LaunchTick));
        CoverNode arrived = map.Covers.First(cover => cover.Fraction == owner.Fraction &&
            cover.SourceIndex != owner.StartCover);
        ulong nextTick = launch.LaunchTick + 1;
        grenades.Advance(nextTick);
        WeaponSlotManifest slot = owner.WeaponSlots!.Single(candidate => candidate.Weapon.SourceId == Frag);
        grenades.SelectWeapon(owner.PlayerId, new GrenadeWeaponSelection(slot.Weapon, slot.WeaponUpgrade, nextTick,
            new(arrived.Position, arrived.SourceIndex, false)));
        checks += Require(grenades.Collision(owner.PlayerId).RootPosition == arrived.Position,
            "A dormant grenade actor re-entered at its original spawn instead of the current host cover.");
        checks += CheckTrace(grenades, opponent.PlayerId,
            new(owner.PlayerId, grenades.Collision(owner.PlayerId), Fraction: owner.Fraction));
        return checks;
    }

    private static int CheckTrace(GrenadeMatchSimulation grenades, string owner, CollisionPlayer target)
    {
        PlayerHitbox part = target.Pose.Parts.First(candidate => candidate.Active && candidate.Enabled);
        uint layerMask = 1u << (target.Fraction == 1 ? 23 : 22);
        const float RayOffset = 2;
        ShotCollision? hit = grenades.TraceForArmy(owner, part.Center + Vector3.UnitX * RayOffset,
            -Vector3.UnitX, RayOffset * 2, layerMask);
        return Require(hit?.PlayerId == target.PlayerId,
            "The mixed trace omitted a participant's active-class collision pose.");
    }

    private static GrenadeThrowCommand CreateSwipe(CoverNode start, Vector3 target)
    {
        Vector3 direction = target - start.Position;
        direction.Y = 0;
        Vector3 end = start.Position + Vector3.Normalize(direction) * SwipeLength;
        return new GrenadeThrowCommand
        {
            Swipe = true, SwipeStartX = start.Position.X, SwipeStartY = start.Position.Y,
            SwipeStartZ = start.Position.Z, SwipeEndX = end.X, SwipeEndY = end.Y, SwipeEndZ = end.Z,
            HeldSeconds = HeldSeconds
        };
    }

    private static int Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return 1;
        }
        throw new InvalidOperationException("Invalid mixed grenade authority was accepted.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
        return 1;
    }
}
