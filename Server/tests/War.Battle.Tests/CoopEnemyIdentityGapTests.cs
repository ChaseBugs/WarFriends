using War.Client;
using War.Protocol;

/// <summary>Checks ordinary enemy identities after the same allocator creates secondary actors.</summary>
internal static class CoopEnemyIdentityGapTests
{
    internal static void Verify(MatchSnapshot snapshot, string playerId)
    {
        IReadOnlyList<CoopEnemyViewState> views = CoopEnemyViewProjection.FromSnapshot(snapshot, playerId);
        if (!views.Select(view => view.EntityId).SequenceEqual(snapshot.Coop.EnemySpawns.Select(row => row.EntityId)) ||
            !snapshot.Coop.EnemySpawns.Zip(snapshot.Coop.EnemySpawns.Skip(1))
                .Any(pair => pair.Second.EntityId > pair.First.EntityId + 1))
        {
            throw new Exception("Source crew allocation did not preserve a gapped ordinary-enemy roster.");
        }

        MatchSnapshot duplicate = snapshot.Clone();
        duplicate.Coop.EnemySpawns[1].EntityId = duplicate.Coop.EnemySpawns[0].EntityId;
        RequireRejected(duplicate, playerId);
        MatchSnapshot zero = snapshot.Clone();
        zero.Coop.EnemySpawns[0].EntityId = 0;
        RequireRejected(zero, playerId);
        MatchSnapshot exhausted = snapshot.Clone();
        exhausted.Coop.EnemySpawns.Last().EntityId = ulong.MaxValue;
        RequireRejected(exhausted, playerId);
    }

    private static void RequireRejected(MatchSnapshot snapshot, string playerId)
    {
        try
        {
            CoopEnemyViewProjection.FromSnapshot(snapshot, playerId);
        }
        catch (System.IO.InvalidDataException)
        {
            return;
        }

        throw new Exception("Malformed ordinary-enemy identity escaped SDK validation.");
    }
}
