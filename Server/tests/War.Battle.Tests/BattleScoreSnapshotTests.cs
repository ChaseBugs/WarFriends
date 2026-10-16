using Google.Protobuf;
using War.Client;
using War.Protocol;

// Scores are authoritative snapshots, including frozen mutation replays.
// Validate their domain without imposing a false monotonic-reply requirement.
internal static class BattleScoreSnapshotTests
{
    private const int ExpectedScore = 56;

    internal static int Run()
    {
        var snapshot = new MatchSnapshot();
        snapshot.Players.Add(new BattlePlayerState { Score = ExpectedScore });
        snapshot.Players.Add(new BattlePlayerState { Score = 0 });
        BattleScoreSnapshotPolicy.Validate(snapshot);
        MatchSnapshot decoded = MatchSnapshot.Parser.ParseFrom(snapshot.ToByteArray());
        if (decoded.Players[0].Score != ExpectedScore || decoded.Players[1].Score != 0)
        {
            throw new Exception("Protobuf must retain both participants' authoritative scores.");
        }

        snapshot.Players[1].Score = -1;
        bool isRejected = false;
        try
        {
            BattleScoreSnapshotPolicy.Validate(snapshot);
        }
        catch (InvalidOperationException)
        {
            isRejected = true;
        }

        if (!isRejected)
        {
            throw new Exception("The SDK must reject negative host scores before publication.");
        }

        Console.WriteLine("PASS: 2 battle score snapshot assertions");
        return 2;
    }
}
