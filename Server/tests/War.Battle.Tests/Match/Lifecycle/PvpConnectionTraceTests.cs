using System.Text.Json;
using War.Battle.Tests.Startup;
using War.BattleServer;
using War.Protocol;
using Trace = War.Battle.Tests.Match.Tracing.MatchEngineTrace;
using TraceResult = War.Battle.Tests.Match.Tracing.MatchEngineTraceResult;

namespace War.Battle.Tests.Match.Lifecycle;

/// <summary>Freezes complete engine/terminal/reply/event bytes before changing connection ownership.</summary>
internal static class PvpConnectionTraceTests
{
    private const string First = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
    private const string Second = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";

    internal static IReadOnlyList<TraceResult> Capture()
    {
        return [AdmissionTimeout(), ReadyAndStart(), PrestartDisconnect(), PauseAndResume(),
            RepeatedReconnect(), GraceExpiry(true), GraceExpiry(false), PausedCommands(), ShutdownWhilePaused()];
    }

    internal static int Run()
    {
        string path = Path.Combine(BackendStartupPolicyTests.FindServerDirectory(),
            "tests/War.Battle.Tests/Match/Lifecycle/pvp-connection-baseline.json");
        TraceResult[] baseline = JsonSerializer.Deserialize<TraceResult[]>(File.ReadAllText(path))!;
        IReadOnlyList<TraceResult> actual = Capture();
        Require(baseline.Length == 9 && baseline.Length == actual.Count, "The reviewed connection trace set changed.");
        for (int index = 0; index < baseline.Length; index++)
        {
            Require(baseline[index] == actual[index], "Connection trace differs: " + baseline[index].Scenario);
        }
        return actual.Count;
    }

    private static TraceResult AdmissionTimeout()
    {
        using var trace = NewTrace("admission-deadline-and-terminal-freeze");
        trace.Advance(299);
        Require(trace.Engine.Snapshot().Phase == BattlePhase.Waiting, "Admission expired before its deadline.");
        trace.Advance(300);
        Require(trace.Engine.Snapshot().TerminalReason == "admission-timeout", "Admission deadline did not abort.");
        trace.Observe("late-admit", trace.Engine.Admit(First));
        trace.Advance(400);
        Require(trace.Engine.Snapshot().ServerTick == 300, "Terminal simulation time advanced.");
        return trace.Finish();
    }

    private static TraceResult ReadyAndStart()
    {
        using var trace = NewTrace("ready-hash-countdown-and-presentation-order");
        trace.AdmitBoth();
        trace.Command(First, new MatchCommand { CommandId = 1, Ready = new() { ManifestHash = new string('0', 64) } });
        Require(trace.Engine.Snapshot().Phase == BattlePhase.Waiting, "A wrong manifest hash started the countdown.");
        trace.Command(First,
            new MatchCommand { CommandId = 2, Ready = new() { ManifestHash = trace.Engine.ManifestHash } });
        trace.Ready(Second);
        Require(trace.Engine.Snapshot().StartTick == 60, "The recovered two-second start offset changed.");
        trace.Advance(59);
        Require(trace.Engine.Snapshot().Phase == BattlePhase.Countdown, "The match started before its start tick.");
        trace.Advance(60);
        trace.Command(First, new MatchCommand { CommandId = 3, PresentationReady = new() });
        Require(trace.Engine.Snapshot().Phase == BattlePhase.Running &&
            trace.Engine.Snapshot().Players[0].PresentationReady, "Loading/presentation readiness changed order.");
        return trace.Finish();
    }

    private static TraceResult PrestartDisconnect()
    {
        using var trace = NewTrace("countdown-idle-precedes-start");
        trace.AdmitBoth();
        trace.Ready(First);
        trace.Ready(Second);
        trace.Advance(300);
        Require(trace.Engine.Snapshot().TerminalReason == "prestart-disconnect",
            "An idle countdown participant entered running combat.");
        return trace.Finish();
    }

    private static TraceResult PauseAndResume()
    {
        using var trace = Started("idle-pause-host-clock-and-resume");
        PauseSecond(trace, 300);
        Require(trace.Engine.Snapshot().ServerTick == 299 && trace.Engine.Snapshot().PauseHostTick == 300,
            "Idle detection partially advanced the simulation frame.");
        trace.Advance(600);
        trace.Poll(First);
        trace.Observe("resume-second", trace.Engine.Resume(Second));
        trace.Advance(601);
        Require(trace.Engine.Snapshot().ServerTick == 300 && !trace.Engine.Snapshot().Players[1].Reconnecting,
            "Resuming replayed the paused host-time backlog.");
        return trace.Finish();
    }

    private static TraceResult RepeatedReconnect()
    {
        using var trace = Started("three-grace-windows-and-fourth-disconnect");
        uint[] graceSeconds = [30, 20, 10];
        for (int attempt = 0; attempt < graceSeconds.Length; attempt++)
        {
            ulong hostTick = (ulong)(attempt + 1) * 300;
            PauseSecond(trace, hostTick);
            BattlePlayerState player = trace.Engine.Snapshot().Players[1];
            Require(player.ReconnectAttempts == (uint)attempt + 1 &&
                    player.ReconnectDeadlineHostTick == hostTick + graceSeconds[attempt] * MatchManifest.TickRate,
                "The recovered reconnect attempt/grace sequence changed.");
            trace.Observe("resume-second", trace.Engine.Resume(Second));
            trace.Poll(First);
        }
        PauseSecond(trace, 1200);
        Require(trace.Engine.Snapshot().TerminalReason == "opponent-disconnected" &&
                trace.Engine.Snapshot().WinnerPlayerId == First,
            "The fourth disconnection did not preserve the existing forfeit outcome.");
        return trace.Finish();
    }

    private static TraceResult GraceExpiry(bool keepOpponentActive)
    {
        string scenario = keepOpponentActive ? "inclusive-grace-expiry-active-opponent" : "silent-peer-no-winner";
        using var trace = Started(scenario);
        PauseSecond(trace, 300);
        trace.Advance(1199);
        if (keepOpponentActive)
        {
            trace.Poll(First);
        }
        trace.Advance(1200);
        MatchSnapshot snapshot = trace.Engine.Snapshot();
        Require(snapshot.TerminalReason == (keepOpponentActive ? "opponent-disconnected" : "both-disconnected") &&
                snapshot.WinnerPlayerId == (keepOpponentActive ? First : ""),
            "Grace expiry promoted a silent peer or missed its inclusive deadline.");
        return trace.Finish();
    }

    private static TraceResult PausedCommands()
    {
        using var trace = Started("poll-replay-presentation-and-forfeit-during-pause");
        PauseSecond(trace, 300);
        trace.Poll(Second);
        Require(trace.Engine.Snapshot().Players[1].Reconnecting, "Polling cleared pause ownership.");
        trace.Command(Second, new MatchCommand { CommandId = 2, PresentationReady = new() });
        var blocked = new MatchCommand { CommandId = 3, Reload = new() };
        Require(trace.Command(Second, blocked).Code == "reconnecting", "A paused gameplay command executed.");
        trace.Advance(301);
        trace.Command(Second, blocked);
        trace.Command(Second, new MatchCommand { CommandId = 4, Forfeit = new() });
        Require(trace.Engine.Snapshot().WinnerPlayerId == First, "Forfeit stopped working during a reconnect pause.");
        return trace.Finish();
    }

    private static TraceResult ShutdownWhilePaused()
    {
        using var trace = Started("shutdown-clears-pause-and-refuses-resume");
        PauseSecond(trace, 300);
        trace.Observe("shutdown", trace.Engine.AbortForHostShutdown());
        trace.Observe("late-resume", trace.Engine.Resume(Second));
        trace.Observe("late-resume-query", trace.Engine.CanResume(Second));
        Require(trace.Engine.Snapshot().TerminalReason == "host-shutdown" &&
                trace.Engine.Snapshot().Players.All(player => !player.Reconnecting &&
                    player.ReconnectDeadlineHostTick == 0), "Host shutdown left a reconnect pause active.");
        trace.Advance(301);
        return trace.Finish();
    }

    private static Trace Started(string scenario)
    {
        var trace = NewTrace(scenario);
        trace.AdmitBoth();
        trace.Ready(First);
        trace.Ready(Second);
        trace.Advance(60);
        return trace;
    }

    private static void PauseSecond(Trace trace, ulong hostTick)
    {
        trace.Advance(hostTick - 1);
        trace.Poll(First);
        trace.Advance(hostTick);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }

    private static Trace NewTrace(string scenario)
    {
        string hash = new('a', 64);
        var weapon = new WeaponManifest("fixture-rifle", 2, 3, 0.1, 0.2);
        var manifest = new MatchManifest("connection-trace", "test-host", "fixture-map", hash, hash,
            MatchManifest.PrototypeMode, 10, 600, 10, [new(First, weapon), new(Second, weapon)]);
        return new Trace(scenario, manifest);
    }
}
