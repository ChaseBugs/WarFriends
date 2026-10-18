using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Checks host commands for starter rifle/grenade transitions and an in-flight return to rifle.</summary>
internal static class MixedGrenadeHostTests
{
    private const int StartTick = 60;
    private const int GrenadeSlot = 2;
    private const int RifleSlot = 0;
    private const int MaximumFlightTicks = 550;
    private const int ResumedShotWaitTicks = 60;
    private const float SwipeLength = 7;
    private const float HeldSeconds = 0.05f;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleArmyManifestProjectionTests.LoadContent(directory);
        MatchManifest manifest = MixedGrenadeActorTests.CreateStarterManifest(content, directory);
        var map = content.Maps.Single(candidate => candidate.SourceHash == manifest.MapRevision);
        var host = new MatchEngine(manifest, map, content);
        foreach (ParticipantManifest player in manifest.Players)
        {
            host.Admit(player.PlayerId);
            Require(host.Command(player.PlayerId, new MatchCommand
            {
                CommandId = 1, Ready = new ReadyCommand { ManifestHash = host.ManifestHash }
            }).Code == "ready", "The mixed starter host did not accept readiness.");
        }
        host.Advance(StartTick);
        return CheckTransitions(host, content, manifest, map) + manifest.Players.Length;
    }

    private static int CheckTransitions(MatchEngine host, BattleCombatContent content,
        MatchManifest manifest, RecoveredBattleMap map)
    {
        string owner = manifest.Players[0].PlayerId;
        CoverNode cover = map.Covers[manifest.Players[0].StartCover];
        Vector3 target = map.Covers[manifest.Players[1].StartCover].Position;
        int rifleAmmo = host.Snapshot().Players.Single(player => player.PlayerId == owner).ClipAmmo;
        Require(host.Command(owner, new MatchCommand
        {
            CommandId = 2, Fire = new FireCommand { TargetX = target.X, TargetY = target.Y, TargetZ = target.Z }
        }).Code == "shot-scheduled", "The fixture did not schedule the recovered rifle uncover shot.");
        Require(host.Command(owner, new MatchCommand
        {
            CommandId = 3, SwitchWeapon = new SwitchWeaponCommand { Slot = GrenadeSlot }
        }).Code == "weapon-selected", "The real host rejected the starter FRAG slot.");
        var selected = host.Snapshot().Players.Single(player => player.PlayerId == owner);
        Require(selected.ActiveWeaponSlot == GrenadeSlot &&
            selected.RiflePose.Layers[0].Clip == RiflePoseClip.GrenadeIdle,
            "Grenade selection did not publish the active grenade pose.");
        Require(host.Command(owner, new MatchCommand
        {
            CommandId = 4, Fire = new FireCommand { TargetX = target.X, TargetY = target.Y, TargetZ = target.Z }
        }).Code == "wrong-fire-mode", "The grenade slot fired a stale rifle round.");

        GrenadeThrowCommand swipe = CreateSwipe(cover.Position, target);
        var gesture = GrenadeGesturePlanner.Plan(content.Grenades!.Binding("Google2u.Grenade_FRAG"),
            content.Grenades.Poses, cover.Position, cover.Rotation, swipe, StartTick);
        Require(host.Command(owner, new MatchCommand { CommandId = 5, GrenadeThrow = swipe }).Code ==
            "grenade-throwing",
            "The mixed host did not accept the source FRAG gesture.");
        Require(host.Command(owner, new MatchCommand
        {
            CommandId = 6, SwitchWeapon = new SwitchWeaponCommand { Slot = RifleSlot }
        }).Code == "shooting", "The mixed host allowed a switch during grenade windup.");
        for (ulong tick = StartTick + 1; tick <= gesture.LaunchTick; tick++)
        {
            host.Advance(tick);
        }
        var release = host.Snapshot().Players.Single(player => player.PlayerId == owner);
        Require(release.ShotsFired == 1 && release.ClipAmmo == selected.ClipAmmo - 1 &&
            host.PendingProjectileCount == 1,
            "The mixed release did not consume one FRAG round and create one projectile.");
        Require(host.Command(owner, new MatchCommand
        {
            CommandId = 7, SwitchWeapon = new SwitchWeaponCommand { Slot = RifleSlot }
        }).Code == "weapon-selected", "An airborne grenade prevented the source rifle return.");
        Require(host.Snapshot().Players.Single(player => player.PlayerId == owner).ClipAmmo == rifleAmmo,
            "Grenade use changed inactive rifle ammunition.");
        Require(host.Command(owner, new MatchCommand
        {
            CommandId = 8, Fire = new FireCommand { TargetX = target.X, TargetY = target.Y, TargetZ = target.Z }
        }).Code == "shot-scheduled", "The rifle could not resume while a grenade remained airborne.");
        for (ulong tick = gesture.LaunchTick + 1; tick < MaximumFlightTicks &&
            (tick <= gesture.LaunchTick + ResumedShotWaitTicks || host.PendingProjectileCount > 0); tick++)
        {
            host.Advance(tick);
        }
        Require(!host.Terminal && host.PendingProjectileCount == 0 &&
            host.Snapshot().Players.Single(player => player.PlayerId == owner).ShotsFired == 2,
            "The in-flight grenade lost collision/damage authority after returning to rifle.");
        return 11;
    }

    private static GrenadeThrowCommand CreateSwipe(Vector3 start, Vector3 target)
    {
        Vector3 direction = target - start;
        direction.Y = 0;
        Vector3 end = start + Vector3.Normalize(direction) * SwipeLength;
        return new GrenadeThrowCommand
        {
            Swipe = true, SwipeStartX = start.X, SwipeStartY = start.Y, SwipeStartZ = start.Z,
            SwipeEndX = end.X, SwipeEndY = end.Y, SwipeEndZ = end.Z, HeldSeconds = HeldSeconds
        };
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
