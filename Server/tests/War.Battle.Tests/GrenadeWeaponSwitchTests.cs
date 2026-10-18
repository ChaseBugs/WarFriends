using System.Numerics;
using War.BattleServer;
using War.Protocol;

/// <summary>Checks active grenade identity, upgrade, pose and ammunition across real host slot changes.</summary>
internal static class GrenadeWeaponSwitchTests
{
    private const string Frag = "Google2u.Grenade_FRAG";
    private const string Launcher = "Google2u.GrenadeLauncher_M320";
    private const int LauncherSlot = 1;
    private const int LauncherUpgrade = 1;
    private const int CountdownTicks = 60;
    private const int LaunchWaitTicks = 30;

    internal static int Run(string directory)
    {
        BattleCombatContent content = BattleCombatContent.Load(Path.Combine(directory, "combat-content-manifest.json"),
            grenadeManifestPath: Path.Combine(directory, "grenade-content-manifest.json"));
        GrenadeCatalog catalog = content.Grenades!;
        var map = content.Maps.Single(candidate =>
            candidate.Source.Contains("City_Multiplayer", StringComparison.Ordinal));
        CoverNode[] covers = [map.Covers.First(cover => cover.Main && cover.Fraction == 1),
            map.Covers.First(cover => cover.Main && cover.Fraction == 2)];
        string[] playerIds = [new('a', 32), new('b', 32)];
        WeaponSlotManifest[] slots =
        [
            new(0, catalog.Binding(Frag).InventoryIndex, catalog.CreateManifest(Frag, 0), 0),
            new(LauncherSlot, catalog.Binding(Launcher).InventoryIndex,
                catalog.CreateManifest(Launcher, LauncherUpgrade), LauncherUpgrade)
        ];
        var participants = playerIds.Select((playerId, index) => new ParticipantManifest(
            playerId, slots[0].Weapon, index + 1, covers[index].SourceIndex, 1, new(10000), 0)
        {
            WeaponSlots = slots
        }).ToArray();
        var definition = new MatchManifest("grenade-switch", "local-1", Path.GetFileNameWithoutExtension(map.Source),
            map.SourceHash, content.GrenadeRevision!, MatchManifest.GrenadeCombatMode, 10, 60, 120, participants);
        var host = new MatchEngine(definition, map, content);
        foreach (string playerId in playerIds)
        {
            Require(host.Admit(playerId), "Grenade switch fixture admission failed.");
            host.Command(playerId, new MatchCommand
            {
                CommandId = 1, Ready = new ReadyCommand { ManifestHash = host.ManifestHash }
            });
        }
        host.Advance(CountdownTicks);
        CheckHostSwitch(host, catalog, playerIds[0], covers[1].Position);
        CheckInvalidSelection(definition, map, catalog, playerIds[0]);
        return 12;
    }

    private static void CheckHostSwitch(MatchEngine host, GrenadeCatalog catalog, string playerId, Vector3 target)
    {
        Require(host.Command(playerId, new MatchCommand
        {
            CommandId = 2, SwitchWeapon = new SwitchWeaponCommand { Slot = LauncherSlot }
        }).Code == "weapon-selected", "The source launcher slot was not selected.");
        Require(host.Snapshot().Players.Single(player => player.PlayerId == playerId).ClipAmmo ==
            catalog.CreateManifest(Launcher, LauncherUpgrade).ClipSize,
            "Launcher selection used another slot's ammunition.");
        Require(host.Command(playerId, new MatchCommand
        {
            CommandId = 3,
            GrenadeThrow = new GrenadeThrowCommand { TargetX = target.X, TargetY = target.Y, TargetZ = target.Z }
        }).Code == "grenade-throwing", "The selected launcher retained the initial swipe-grenade gesture.");
        Require(host.Command(playerId, new MatchCommand
        {
            CommandId = 4, SwitchWeapon = new SwitchWeaponCommand { Slot = 0 }
        }).Code == "shooting", "A pending grenade windup allowed a weapon change.");
        for (ulong tick = CountdownTicks + 1; tick <= CountdownTicks + LaunchWaitTicks; tick++)
        {
            host.Advance(tick);
        }
        Require(host.Snapshot().Players.Single(player => player.PlayerId == playerId).ClipAmmo ==
            catalog.CreateManifest(Launcher, LauncherUpgrade).ClipSize - 1,
            "The launcher did not consume one active-slot round.");
        Require(host.Command(playerId, new MatchCommand
        {
            CommandId = 5, SwitchWeapon = new SwitchWeaponCommand { Slot = 0 }
        }).Code == "weapon-selected", "The grenade actor could not return to the initial slot after launch.");
        Require(host.Snapshot().Players.Single(player => player.PlayerId == playerId).ClipAmmo ==
            catalog.CreateManifest(Frag, 0).ClipSize, "Launcher use consumed an inactive FRAG round.");
    }

    private static void CheckInvalidSelection(MatchManifest definition, RecoveredBattleMap map,
        GrenadeCatalog catalog, string playerId)
    {
        var simulation = new GrenadeMatchSimulation(definition, map, catalog);
        RiflePoseState before = simulation.Snapshot(playerId, 0);
        WeaponManifest forged = catalog.CreateManifest(Launcher, LauncherUpgrade) with { ClipSize = 999 };
        Reject(() => simulation.SelectWeapon(playerId, forged, LauncherUpgrade, 0));
        Require(simulation.Snapshot(playerId, 0).Equals(before), "A rejected weapon assertion changed grenade pose.");
        Reject(() => simulation.SelectWeapon(playerId, catalog.CreateManifest(Launcher, LauncherUpgrade),
            LauncherUpgrade, 1));
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidOperationException("Invalid grenade selection authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
