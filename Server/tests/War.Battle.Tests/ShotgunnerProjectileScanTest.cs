using Google.Protobuf;
using War.BattleServer;
using War.Client;
using War.Protocol;

/// <summary>Checks frozen scan replay without comparing unrelated live simulation ticks.</summary>
internal static class ShotgunnerProjectileScanTest
{
    private const string UnitId = "ID_UNIT-SHOTGUNNER";
    private const int PelletCount = 5;

    internal static async Task<bool> VerifyAsync(
        MatchConnection client, MatchSnapshot observed, string ownerId, CancellationToken token)
    {
        MatchProjectileBatch first = await client.FetchProjectilesAsync(token);
        MatchProjectileBatch replay = await ReplayAsync(client, first.ScanId, token);
        Require(first.ToByteArray().SequenceEqual(replay.ToByteArray()),
            "A frozen projectile scan must replay its complete original rows across all pages.");
        BattleProjectileState[] pellets = first.Projectiles.Where(row =>
            row.OwnerPlayerId == ownerId && row.ArmyUnitId == UnitId).ToArray();
        if (first.SnapshotTick == observed.ServerTick && !observed.ProjectilesTruncated)
        {
            Require(pellets.Select(row => row.ProjectileId).SequenceEqual(observed.Projectiles
                .Where(row => row.OwnerPlayerId == ownerId && row.ArmyUnitId == UnitId)
                .Select(row => row.ProjectileId)), "Same-tick snapshots and complete scans must agree on pellet IDs.");
        }

        if (pellets.Length != PelletCount || first.ActiveCount != PelletCount)
        {
            return false;
        }

        Require(pellets.Count(row => row.Kind == "army-bullet") == 1 &&
            pellets.Count(row => row.Kind == "army-fake-bullet") == PelletCount - 1,
            "The complete frozen burst must contain one real and four harmless source pellets.");
        return true;
    }

    private static async Task<MatchProjectileBatch> ReplayAsync(
        MatchConnection client, ulong scanId, CancellationToken token)
    {
        MatchProjectileBatch? result = null;
        ulong cursor = 0;
        while (true)
        {
            MatchProjectileBatch page = await client.PollProjectilesAsync(scanId, cursor, token);
            Require(page.Code == "projectiles", "The bounded frozen scan must remain available during replay.");
            if (result == null)
            {
                result = page.Clone();
                result.Projectiles.Clear();
                result.HasMore = false;
            }

            Require(page.ScanId == scanId && page.SnapshotTick == result.SnapshotTick &&
                page.ActiveCount == result.ActiveCount, "Replay must retain one scan identity and clock.");
            foreach (BattleProjectileState row in page.Projectiles)
            {
                Require(row.ProjectileId > cursor && result.Projectiles.Count < MatchEngine.MaximumProjectiles,
                    "Frozen pages must make bounded ordered progress without duplicate projectiles.");
                result.Projectiles.Add(row.Clone());
                cursor = row.ProjectileId;
            }

            if (!page.HasMore)
            {
                Require(result.Projectiles.Count == result.ActiveCount, "The replay must conserve all scan rows.");
                return result;
            }

            Require(page.Projectiles.Count > 0, "A continuing page must advance its cursor.");
        }
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
