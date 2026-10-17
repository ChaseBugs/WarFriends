using Google.Protobuf;
using War.BattleServer;
using War.Protocol;

/// <summary>Checks authenticated monotonic presentation state without granting combat authority.</summary>
internal static class PresentationReadinessTests
{
    private const ulong CountdownTicks = 2UL * MatchManifest.TickRate;
    private const int ContentHashLength = 64;

    internal static int Run()
    {
        string first = Guid.NewGuid().ToString("N");
        string second = Guid.NewGuid().ToString("N");
        string revision = new('c', ContentHashLength);
        var weapon = new WeaponManifest("presentation-fixture", 2, 3, 0.1, 0.2);
        var definition = MatchManifest.Validate(new MatchManifest("presentation-ready", "local-1",
            "fixture-map", revision, revision, MatchManifest.PrototypeMode, 10, 90, 30,
            [new ParticipantManifest(first, weapon), new ParticipantManifest(second, weapon)]));
        var match = new MatchEngine(definition);
        Require(match.Command(first, Presentation(1)).Code == "not-admitted",
            "An unadmitted identity must not report presentation.");
        match.Admit(first);
        match.Admit(second);
        Require(match.Command(first, Presentation(1)).Code == "wrong-phase",
            "Presentation cannot replace the source loading barrier.");
        match.Command(first, Ready(2, match.ManifestHash));
        match.Command(second, Ready(1, match.ManifestHash));
        Require(match.Command(second, Presentation(2)).Code == "wrong-phase",
            "The countdown must not accept a camera that runs after Running.");
        match.Advance(CountdownTicks);

        VerifyRunningAndReplay(match, first, second);
        VerifyOpponentReconnect(definition, first, second);
        return 13;
    }

    private static void VerifyOpponentReconnect(MatchManifest definition, string first, string second)
    {
        var match = new MatchEngine(definition);
        match.Admit(first);
        match.Admit(second);
        match.Command(first, Ready(1, match.ManifestHash));
        match.Command(second, Ready(1, match.ManifestHash));
        match.Advance(CountdownTicks);
        match.Advance((ulong)(definition.IdleSeconds - 1) * MatchManifest.TickRate);
        match.Command(first, new MatchCommand { Poll = new PollMatch() });
        match.Advance((ulong)definition.IdleSeconds * MatchManifest.TickRate);
        MatchSnapshot paused = match.Snapshot();
        Require(paused.Players.Single(player => player.PlayerId == second).Reconnecting,
            "The source fixture must pause for only the absent opposing participant.");

        MatchReply accepted = match.Command(first, Presentation(2));
        Require(accepted.Code == "presentation-ready" && accepted.Snapshot.Players.Single(
            player => player.PlayerId == first).PresentationReady,
            "Opponent reconnect must not discard the connected player's completed camera.");
        Require(accepted.Snapshot.ServerTick == paused.ServerTick && accepted.Snapshot.PauseHostTick != 0 &&
            accepted.Snapshot.Players.Single(player => player.PlayerId == second).Reconnecting,
            "Presentation must not resume or advance a paused combat simulation.");
    }

    private static void VerifyRunningAndReplay(MatchEngine match, string first, string second)
    {
        MatchSnapshot before = match.Snapshot();
        MatchCommand completion = Presentation(3);
        MatchReply accepted = match.Command(first, completion);
        Require(accepted.Code == "presentation-ready" &&
            accepted.Snapshot.Players.Single(player => player.PlayerId == first).PresentationReady &&
            !accepted.Snapshot.Players.Single(player => player.PlayerId == second).PresentationReady,
            "Only the authenticated participant may become presentation-ready.");
        Require(accepted.Snapshot.Phase == before.Phase && accepted.Snapshot.ServerTick == before.ServerTick &&
            accepted.Snapshot.Players.All(player => player.ShotsFired == 0),
            "Presentation must not start, advance or fire a battle.");
        Require(match.Command(first, completion).ToByteArray().SequenceEqual(accepted.ToByteArray()),
            "Identical retries must return the original immutable receipt.");
        Require(match.Resume(first) && match.Snapshot().Players.Single(player => player.PlayerId == first)
            .PresentationReady, "Reconnect must retain presentation state.");
        Require(match.Command(first, Presentation(4)).Code == "presentation-ready",
            "Repeated presentation reports must remain monotonic.");
        match.Command(second, new MatchCommand { CommandId = 3, Forfeit = new ForfeitCommand() });
        Require(match.Command(first, Presentation(5)).Code == "match-terminal",
            "Presentation must not mutate a terminal result.");
        Require(match.Snapshot().Players.Single(player => player.PlayerId == first).PresentationReady &&
            !match.Snapshot().Players.Single(player => player.PlayerId == second).PresentationReady,
            "Terminal state must preserve each participant's own completion.");
    }

    private static MatchCommand Ready(ulong commandId, string manifestHash)
    {
        return new MatchCommand { CommandId = commandId, Ready = new ReadyCommand { ManifestHash = manifestHash } };
    }

    private static MatchCommand Presentation(ulong commandId)
    {
        return new MatchCommand { CommandId = commandId, PresentationReady = new PresentationReadyCommand() };
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
