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

        return checks;
    }
}
