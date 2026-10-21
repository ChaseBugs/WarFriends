using System.Text.Json;
using War.Battle.Tests.Match.Tracing;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Weapons;

internal static class PvpWeaponTraceTests
{
    private const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private const string RequestId = "11111111111111111111111111111111";

    internal static IReadOnlyList<MatchEngineTraceResult> Capture()
    {
        return [FiniteAmmo(), ManualAndInactiveReload(), InfiniteReserve(), PausedReload(),
            AmmoBox(), EmptyMag(), AmmoThief(), FallbackSlot()];
    }

    internal static int Run()
    {
        string path = Path.Combine(BackendStartupPolicyTests.FindServerDirectory(),
            "tests/War.Battle.Tests/Match/Weapons/pvp-weapon-baseline.json");
        MatchEngineTraceResult[] expected =
            JsonSerializer.Deserialize<MatchEngineTraceResult[]>(File.ReadAllText(path))!;
        IReadOnlyList<MatchEngineTraceResult> actual = Capture();
        Require(expected.Length == 8 && actual.Count == expected.Length, "The reviewed weapon traces changed.");
        for (int index = 0; index < expected.Length; index++)
        {
            Require(expected[index] == actual[index], "Weapon trace differs: " + expected[index].Scenario);
        }
        return actual.Count;
    }

    private static MatchEngineTraceResult FiniteAmmo()
    {
        using MatchEngineTrace trace = Started("finite-cadence-auto-reload-and-exhaustion");
        Require(Fire(trace, 2).Code == "shot-accepted" && Fire(trace, 3).Code == "cooldown",
            "The same-tick cadence boundary changed.");
        trace.Advance(63);
        Fire(trace, 4);
        Require(Player(trace).ClipAmmo == 0 && Player(trace).ReloadEndTick == 69,
            "An empty clip did not start its source reload.");
        trace.Advance(68);
        Require(Player(trace).ClipAmmo == 0, "Reload completed before its deadline.");
        trace.Advance(69);
        Require(Player(trace).ClipAmmo == 2 && Player(trace).ReserveAmmo == 1,
            "Reload failed to conserve finite ammo.");
        Fire(trace, 5);
        trace.Advance(72);
        Fire(trace, 6);
        trace.Advance(78);
        Require(Player(trace).ClipAmmo == 1 && Player(trace).ReserveAmmo == 0, "Partial final reload created ammo.");
        Fire(trace, 7);
        trace.Advance(81);
        Require(Fire(trace, 8).Code == "no-ammo" && Player(trace).ReloadEndTick == 0,
            "An exhausted weapon started another reload or fired.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult ManualAndInactiveReload()
    {
        using MatchEngineTrace trace = Started("manual-reload-survives-slot-switch");
        Fire(trace, 2);
        Reload(trace, 3);
        Switch(trace, First, 4, 2);
        Require(Player(trace).ClipAmmo == 4, "Slot switching changed the other weapon's clip.");
        trace.Advance(65);
        Switch(trace, First, 5, 0);
        Require(Player(trace).ClipAmmo == 1 && Player(trace).ReloadEndTick == 66, "Switching reset a pending reload.");
        Switch(trace, First, 6, 2);
        trace.Advance(66);
        Switch(trace, First, 7, 0);
        Require(Player(trace).ClipAmmo == 2 && Player(trace).ReserveAmmo == 2 &&
                Player(trace).ReloadEndTick == 0,
            "The inactive slot did not finish reloading.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult InfiniteReserve()
    {
        using MatchEngineTrace trace = Started("immutable-infinite-reserve-sentinel", new(Reserve: int.MaxValue));
        Fire(trace, 2);
        trace.Advance(63);
        Fire(trace, 3);
        trace.Advance(69);
        Require(Player(trace).ClipAmmo == 2 && Player(trace).ReserveAmmo == int.MaxValue,
            "Reload depleted the recovered Pistol reserve sentinel.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult PausedReload()
    {
        using MatchEngineTrace trace = Started("reconnect-pause-keeps-reload-deadline", new(ReloadSeconds: 30));
        Fire(trace, 2);
        Reload(trace, 3);
        trace.Advance(299);
        trace.Poll(First);
        trace.Advance(300);
        trace.Advance(600);
        Require(trace.Engine.Snapshot().ServerTick == 299 && Player(trace).ReloadEndTick == 960,
            "Paused host time completed or extended the simulation reload.");
        trace.Observe("resume-second", trace.Engine.Resume(Second));
        trace.Poll(First);
        trace.Advance(601);
        Require(trace.Engine.Snapshot().ServerTick == 300 && Player(trace).ClipAmmo == 1,
            "Resume replayed the paused reload backlog.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult AmmoBox()
    {
        using MatchEngineTrace trace = Started("ammo-box-all-slots-and-exact-replay", new(Card: "CardAmmoBox"));
        var command = new MatchCommand { CommandId = 3, UseAmmoBox = new() { RequestId = RequestId } };
        Require(trace.Command(First, command).Code == "ammo-box-applied" && Player(trace).ReserveAmmo == 4,
            "Ammo Box lost its starting-reserve ceiling rule.");
        Switch(trace, First, 4, 2);
        Require(Player(trace).ReserveAmmo == 10, "Ammo Box omitted the inactive slot.");
        trace.Command(First, command);
        Require(Player(trace).ReserveAmmo == 10, "Exact replay granted Ammo Box twice.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult EmptyMag()
    {
        using MatchEngineTrace trace = Started("empty-mag-targets-first-inactive-slot", new(Card: "EMPTYMAG"));
        Switch(trace, Second, 2, 2);
        trace.Command(First, new MatchCommand { CommandId = 3, UseEmptyMag = new() { RequestId = RequestId } });
        Require(Player(trace, 1).ClipAmmo == 4, "Empty Mag selected the currently active slot.");
        Switch(trace, Second, 3, 0);
        Require(Player(trace, 1).ClipAmmo == 0 && Player(trace, 1).ReloadEndTick == 66,
            "Empty Mag lost its clip-setter cancellation and fresh reload.");
        trace.Advance(66);
        Require(Player(trace, 1).ClipAmmo == 2 && Player(trace, 1).ReserveAmmo == 1,
            "Empty Mag's reload did not conserve reserve.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult AmmoThief()
    {
        using MatchEngineTrace trace = Started("ammo-thief-second-slot-conservation", new(Card: "CardAmmoThief"));
        trace.Command(First, new MatchCommand { CommandId = 3, UseAmmoThief = new() { RequestId = RequestId } });
        Switch(trace, First, 4, 2);
        Switch(trace, Second, 2, 2);
        Require(Player(trace).ReserveAmmo == 10 && Player(trace, 1).ReserveAmmo == 6 &&
                Player(trace, 1).ClipAmmo == 4, "Ammo Thief changed slot order or actual transferred ammo.");
        return trace.Finish();
    }

    private static MatchEngineTraceResult FallbackSlot()
    {
        using MatchEngineTrace trace = Started("legacy-single-slot-fallback", options: new(IncludeSlots: false));
        Require(Switch(trace, First, 2, 2).Code == "weapon-slot-unavailable", "The fallback invented a second slot.");
        Fire(trace, 3);
        Reload(trace, 4);
        trace.Advance(66);
        Require(Player(trace).ClipAmmo == 2 && Player(trace).ReserveAmmo == 2, "The fallback lost weapon state.");
        return trace.Finish();
    }

    private sealed record Options(int Reserve = 3, double ReloadSeconds = 0.2,
        string? Card = null, bool IncludeSlots = true);

    private static MatchEngineTrace Started(string scenario, Options? options = null)
    {
        options ??= new Options();
        string? card = options.Card;
        string hash = new('a', 64);
        var weapon = new WeaponManifest("fixture-rifle", 2, options.Reserve, 0.1, options.ReloadSeconds);
        var alternate = new WeaponManifest("fixture-alternate", 4, 8, 0.2, 0.3);
        ParticipantManifest Participant(string id) => new(id, weapon)
        {
            WeaponSlots = options.IncludeSlots ? [new(0, 0, weapon, 0), new(2, 1, alternate, 0)] : null
        };
        var manifest = new MatchManifest("weapon-trace", "test-host", "fixture-map", hash, hash,
            MatchManifest.PrototypeMode, 10, 600, 10, [Participant(First), Participant(Second)]);
        var trace = new MatchEngineTrace(scenario, manifest);
        if (card != null)
        {
            trace.Engine.ConfigureCardSelection([card]);
            trace.Engine.ConfigureCardInventory([(First, card, 1)]);
        }
        trace.AdmitBoth();
        if (card != null)
        {
            var selection = new SelectCardsCommand();
            selection.CardIds.Add(card);
            Require(trace.Command(First, new MatchCommand { CommandId = 1, SelectCards = selection }).Code ==
                    "cards-selected", "Weapon trace could not select its allocated card.");
        }
        trace.Command(First, new MatchCommand { CommandId = card == null ? 1u : 2u,
            Ready = new() { ManifestHash = trace.Engine.ManifestHash } });
        trace.Ready(Second);
        trace.Advance(60);
        return trace;
    }

    private static MatchReply Fire(MatchEngineTrace trace, ulong id)
    {
        return trace.Command(First, new MatchCommand { CommandId = id, Fire = new() { TargetX = 1 } });
    }

    private static MatchReply Reload(MatchEngineTrace trace, ulong id)
    {
        return trace.Command(First, new MatchCommand { CommandId = id, Reload = new() });
    }

    private static MatchReply Switch(MatchEngineTrace trace, string player, ulong id, int slot)
    {
        return trace.Command(player, new MatchCommand { CommandId = id, SwitchWeapon = new() { Slot = slot } });
    }

    private static BattlePlayerState Player(MatchEngineTrace trace, int index = 0)
    {
        return trace.Engine.Snapshot().Players[index];
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
