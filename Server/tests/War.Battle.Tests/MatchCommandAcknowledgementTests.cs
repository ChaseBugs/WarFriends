using War.Client;
using War.Protocol;

internal static class MatchCommandAcknowledgementTests
{
    internal static int Run()
    {
        const string localId = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
        const string remoteId = "bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb";
        int checks = 0;

        void Check(bool condition, string message)
        {
            if (!condition) throw new Exception(message);
            checks++;
        }
        void Reject(Action action, string message)
        {
            bool rejected = false;
            try { action(); }
            catch (InvalidOperationException) { rejected = true; }
            Check(rejected, message);
        }
        MatchSnapshot Snapshot(ulong localCursor, ulong revision)
        {
            var snapshot = new MatchSnapshot { StateRevision = revision };
            snapshot.Players.Add(new BattlePlayerState
                { PlayerId = localId, LastCommandId = localCursor });
            snapshot.Players.Add(new BattlePlayerState
                { PlayerId = remoteId, LastCommandId = 0 });
            return snapshot;
        }
        MatchReply Reply(ulong replyId, ulong localCursor, ulong revision, string code)
        {
            return new MatchReply
            {
                CommandId = replyId,
                Code = code,
                Snapshot = Snapshot(localCursor, revision)
            };
        }

        Check(MatchCommandAcknowledgement.AdmissionCursor(Snapshot(0, 0), localId) == 0,
            "new match admits a zero command cursor");
        Check(MatchCommandAcknowledgement.AdmissionCursor(Snapshot(5, 7), localId) == 5,
            "reconnect resumes the host-owned command cursor");
        Reject(() => MatchCommandAcknowledgement.AdmissionCursor(Snapshot(6, 5), localId),
            "admission rejects a cursor beyond the state revision");
        Reject(() => MatchCommandAcknowledgement.AdmissionCursor(Snapshot(100001, 100001), localId),
            "admission rejects a cursor beyond the host command limit");

        var missingLocal = Snapshot(0, 0);
        missingLocal.Players[0].PlayerId = new string('c', 32);
        Reject(() => MatchCommandAcknowledgement.AdmissionCursor(missingLocal, localId),
            "admission requires the local player");
        var duplicateLocal = Snapshot(0, 0);
        duplicateLocal.Players[1].PlayerId = localId;
        Reject(() => MatchCommandAcknowledgement.AdmissionCursor(duplicateLocal, localId),
            "admission rejects duplicate local rows");

        MatchCommandAcknowledgement.RequireConsumed(Reply(1, 1, 1, "ready"), localId, 1);
        Check(true, "mutation completes when snapshot acknowledges its command ID");
        MatchCommandAcknowledgement.RequireConsumed(Reply(1, 1, 1, "match-terminal"), localId, 1);
        Check(true, "a terminal code may still represent a consumed command");
        Reject(() => MatchCommandAcknowledgement.RequireConsumed(
                Reply(1, 0, 0, "match-terminal"), localId, 1),
            "pre-command terminal reply does not consume the pending ID");
        Reject(() => MatchCommandAcknowledgement.RequireConsumed(
                Reply(1, 0, 1, "ready"), localId, 1),
            "a success code alone cannot acknowledge an unconsumed command");
        Reject(() => MatchCommandAcknowledgement.RequireConsumed(
                Reply(2, 1, 2, "ready"), localId, 2),
            "an older local command cursor cannot acknowledge the new command");
        Reject(() => MatchCommandAcknowledgement.RequireConsumed(
                Reply(2, 2, 1, "ready"), localId, 2),
            "snapshot revision cannot predate its acknowledged command");
        Reject(() => MatchCommandAcknowledgement.RequireConsumed(
                Reply(3, 2, 2, "ready"), localId, 2),
            "reply and requested command identities must agree");

        var terminal = Reply(2, 1, 2, "match-terminal");
        terminal.Snapshot.Phase = BattlePhase.Aborted;
        terminal.Snapshot.ServerTick = 10;
        terminal.Snapshot.EndTick = 10;
        terminal.Snapshot.TerminalReason = "cancelled-before-start";
        Check(MatchCommandAcknowledgement.TerminalCursor(terminal, localId, 2) == 1,
            "terminal refusal closes pending work without inventing a consumed cursor");
        var consumedTerminal = terminal.Clone();
        consumedTerminal.Snapshot.Players[0].LastCommandId = 2;
        Check(MatchCommandAcknowledgement.TerminalCursor(consumedTerminal, localId, 2) == 2,
            "a consumed terminal response retains the proven cursor");
        var nonterminal = terminal.Clone();
        nonterminal.Snapshot.Phase = BattlePhase.Running;
        Reject(() => MatchCommandAcknowledgement.TerminalCursor(nonterminal, localId, 2),
            "terminal code alone cannot close a running command stream");
        var wrongCursor = terminal.Clone();
        wrongCursor.Snapshot.Players[0].LastCommandId = 0;
        Reject(() => MatchCommandAcknowledgement.TerminalCursor(wrongCursor, localId, 2),
            "terminal refusal cannot skip unresolved earlier commands");
        var wrongTick = terminal.Clone();
        wrongTick.Snapshot.EndTick++;
        Reject(() => MatchCommandAcknowledgement.TerminalCursor(wrongTick, localId, 2),
            "terminal refusal needs a frozen terminal tick");
        var wrongReply = terminal.Clone();
        wrongReply.CommandId++;
        Reject(() => MatchCommandAcknowledgement.TerminalCursor(wrongReply, localId, 2),
            "terminal refusal remains bound to the pending request ID");

        var noRevision = terminal.Clone();
        noRevision.Snapshot.StateRevision = 0;
        Reject(() => MatchCommandAcknowledgement.TerminalCursor(noRevision, localId, 2),
            "terminal refusal must carry a positive terminal revision");
        var noReason = terminal.Clone();
        noReason.Snapshot.TerminalReason = "";
        Reject(() => MatchCommandAcknowledgement.TerminalCursor(noReason, localId, 2),
            "terminal refusal must identify its host-owned end reason");
        var ended = terminal.Clone();
        ended.Snapshot.Phase = BattlePhase.Ended;
        ended.Snapshot.TerminalReason = "forfeit";
        ended.Snapshot.WinnerPlayerId = remoteId;
        Check(MatchCommandAcknowledgement.TerminalCursor(ended, localId, 2) == 1,
            "a completed battle can reject a late pending command without consuming it");

        return checks;
    }
}
