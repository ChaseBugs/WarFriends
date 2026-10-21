using System.Reflection;
using War.BattleServer;
using War.Protocol;

namespace War.Battle.Tests.Match.Lifecycle;

internal static class PvpConnectionLifecycleTests
{
    private const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
    private static readonly string ManifestHash = new('a', 64);

    internal static int Run()
    {
        CheckAdmissionAndReadyOrder();
        CheckReadOnlyResumeQuery();
        CheckPausePreparationAndCleanupFailure();
        CheckTrafficDoesNotResume();
        CheckIdleAndGraceBoundaries();
        CheckStateOwnership();
        return 6;
    }

    private static PvpConnectionLifecycle Create()
    {
        var weapon = new WeaponManifest("fixture-rifle", 2, 3, 0.1, 0.2);
        var manifest = new MatchManifest("connection-unit", "test-host", "fixture-map", ManifestHash, ManifestHash,
            MatchManifest.PrototypeMode, 10, 600, 10, [new(First, weapon), new(Second, weapon)]);
        return new PvpConnectionLifecycle(MatchManifest.Validate(manifest), ManifestHash);
    }

    private static PvpConnectionLifecycle Admitted()
    {
        PvpConnectionLifecycle lifecycle = Create();
        Require(lifecycle.TryAdmit(First, BattlePhase.Waiting, 0, 0) &&
                lifecycle.TryAdmit(Second, BattlePhase.Waiting, 0, 0), "The connection fixture was not admitted.");
        return lifecycle;
    }

    private static void CheckAdmissionAndReadyOrder()
    {
        PvpConnectionLifecycle lifecycle = Create();
        Require(!lifecycle.TryAdmit("unknown", BattlePhase.Waiting, 0, 0) &&
                !lifecycle.TryAdmit(First, BattlePhase.Countdown, 0, 0) &&
                !lifecycle.TryAdmit(First, BattlePhase.Waiting, 300, 300), "An invalid admission succeeded.");
        Require(!lifecycle.Participant(First).Admitted, "Rejected admission changed participant authority.");
        Require(lifecycle.TryAdmit(First, BattlePhase.Waiting, 299, 299), "The last admission tick was refused.");
        Require(lifecycle.Ready(First, BattlePhase.Running, "wrong", out _) == "wrong-phase" &&
                lifecycle.Ready(First, BattlePhase.Waiting, "wrong", out _) == "manifest-mismatch" &&
                !lifecycle.Participant(First).Ready, "Ready validation changed order or committed a refusal.");
        Require(lifecycle.Ready(First, BattlePhase.Waiting, ManifestHash, out bool start) == "ready" && !start,
            "One participant started the countdown alone.");
        Require(lifecycle.TryAdmit(Second, BattlePhase.Waiting, 299, 299), "The second participant was not admitted.");
        Require(lifecycle.Ready(Second, BattlePhase.Waiting, ManifestHash, out start) == "ready" && start,
            "Both admitted/ready participants failed to open the countdown gate.");
        Require(lifecycle.PresentationReady(First, BattlePhase.Countdown) == "wrong-phase" &&
                !lifecycle.Participant(First).PresentationReady &&
                lifecycle.PresentationReady(First, BattlePhase.Running) == "presentation-ready",
            "Presentation readiness preceded running combat.");
    }

    private static void CheckReadOnlyResumeQuery()
    {
        PvpConnectionLifecycle lifecycle = Admitted();
        Require(lifecycle.CanResume(First, false) && !lifecycle.CanResume(First, true) &&
                !lifecycle.CanResume("unknown", false),
            "Reconnect eligibility changed its identity/terminal boundary.");
        Require(lifecycle.Participant(First).LastSeen == 0 && !lifecycle.HasReconnect,
            "A read-only reconnect query refreshed presence or acquired pause ownership.");
    }

    private static void CheckPausePreparationAndCleanupFailure()
    {
        PvpConnectionLifecycle lifecycle = Admitted();
        lifecycle.ObserveTraffic(First, 299);
        for (uint attempt = 1; attempt <= 3; attempt++)
        {
            PvpReconnectDecision decision = lifecycle.BeginIdlePause(300);
            PvpParticipantConnection disconnected = lifecycle.Participant(Second);
            Require(decision.Disposition == PvpReconnectDisposition.PauseRequired &&
                    decision.DisconnectedPlayerId == Second && disconnected.ReconnectAttempts == attempt &&
                    !disconnected.Reconnecting && disconnected.ReconnectDeadlineHostTick == 0,
                "Pause preparation published its deadline before cleanup completed.");
            // Simulate the engine's deployable cleanup throwing: do not activate the pause.
            // The attempt must still be counted when the caller retries that same idle frame.
        }
        PvpReconnectDecision terminal = lifecycle.BeginIdlePause(300);
        Require(terminal.Disposition == PvpReconnectDisposition.OpponentForfeit && terminal.WinnerPlayerId == First &&
                lifecycle.Participant(Second).ReconnectAttempts == 4 && !lifecycle.HasReconnect,
            "Cleanup failure retries reset attempts or opened a fourth grace window.");
    }

    private static void CheckTrafficDoesNotResume()
    {
        PvpConnectionLifecycle lifecycle = Admitted();
        lifecycle.ObserveTraffic(First, 299);
        PvpReconnectDecision decision = lifecycle.BeginIdlePause(300);
        lifecycle.ActivateReconnect(decision.DisconnectedPlayerId, 300);
        lifecycle.ObserveTraffic(Second, 301);
        PvpParticipantConnection participant = lifecycle.Participant(Second);
        Require(participant.LastSeen == 301 && participant.Reconnecting &&
                participant.ReconnectDeadlineHostTick == 1200, "Traffic silently cleared or extended a grace lease.");
        Require(lifecycle.Resume(Second, false, 350) && participant.LastSeen == 350 && !participant.Reconnecting &&
                participant.ReconnectDeadlineHostTick == 0 && participant.ReconnectAttempts == 1,
            "Resume lost its presence, lease cleanup or lifetime attempt count.");
        Require(!lifecycle.Resume(Second, true, 400) && participant.LastSeen == 350,
            "A terminal reconnect changed presence.");
    }

    private static void CheckIdleAndGraceBoundaries()
    {
        PvpConnectionLifecycle both = Admitted();
        Require(!both.HasIdleParticipant(299) && both.BeginIdlePause(299).Disposition == PvpReconnectDisposition.None,
            "Idle detection fired before its exact boundary.");
        Require(both.BeginIdlePause(300).Disposition == PvpReconnectDisposition.BothDisconnected &&
                both.Participant(First).ReconnectAttempts == 0 && both.Participant(Second).ReconnectAttempts == 0,
            "A simultaneous disconnect assigned one side a grace attempt or winner.");
        PvpConnectionLifecycle single = Admitted();
        single.ObserveTraffic(First, 299);
        single.BeginIdlePause(300);
        single.ActivateReconnect(Second, 300);
        Require(single.CheckGraceExpiry(1199).Disposition == PvpReconnectDisposition.None,
            "A reconnect grace expired early.");
        single.ObserveTraffic(First, 1199);
        Require(single.CheckGraceExpiry(1200).WinnerPlayerId == First, "The inclusive grace deadline was missed.");
        single.ClearReconnects();
        Require(!single.HasReconnect && single.Participant(Second).ReconnectDeadlineHostTick == 0 &&
                single.Participant(Second).ReconnectAttempts == 1, "Terminal cleanup erased history or kept a lease.");
    }

    private static void CheckStateOwnership()
    {
        string[] names = ["Admitted", "Ready", "PresentationReady", "LastSeen", "Reconnecting",
            "ReconnectAttempts", "ReconnectDeadlineHostTick"];
        Type player = typeof(MatchEngine).GetNestedType("Player", BindingFlags.NonPublic)!;
        const BindingFlags Members = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        foreach (string name in names)
        {
            Require(player.GetField(name, Members) == null && player.GetProperty(name, Members)?.SetMethod == null,
                "The engine retained independently writable connection state: " + name);
            Require(typeof(PvpParticipantConnection).GetProperty(name, Members)?.SetMethod?.IsPrivate == true,
                "A connection flag can be assigned outside its owner: " + name);
        }
        Require(typeof(MatchEngine).GetField("_connections", Members)?.IsInitOnly == true,
            "The engine can swap its lifecycle owner after allocation.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
