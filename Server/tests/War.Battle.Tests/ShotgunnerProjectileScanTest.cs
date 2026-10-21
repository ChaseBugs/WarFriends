using Google.Protobuf;
using War.BattleServer;
using War.Client;
using War.Protocol;

/// <summary>Checks frozen scan replay without comparing unrelated live simulation ticks.</summary>
internal static class ShotgunnerProjectileScanTest
{
    private const string UnitId = "ID_UNIT-SHOTGUNNER";
    private const int PelletCount = 5;

    internal sealed record ScanResult(bool ReplayedBurst, ulong SnapshotTick, uint ActiveCount, int PelletCount);

    internal static async Task<ScanResult> VerifyAsync(
        MatchConnection client, MatchSnapshot observed, string ownerId, CancellationToken token)
    {
        MatchProjectileBatch first = await client.FetchProjectilesAsync(token);
        // The live simulation must advance while this immutable scan keeps its original rows.
        await Task.Delay(TimeSpan.FromMilliseconds(100), token);
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

        int realCount = pellets.Count(row => row.Kind == "army-bullet");
        int fakeCount = pellets.Count(row => row.Kind == "army-fake-bullet");
        if (fakeCount != PelletCount - 1 || realCount > 1 ||
            pellets.Length != realCount + fakeCount || first.ActiveCount != pellets.Length)
        {
            return new(false, first.SnapshotTick, first.ActiveCount, pellets.Length);
        }

        // The poll and scan are separate reads. The real pellet can hit before scan creation,
        // leaving four longer-lived cosmetic trails. Both peers must still observe all five
        // together in the live snapshots; the scan must replay exactly what it actually captured.
        return new(true, first.SnapshotTick, first.ActiveCount, pellets.Length);
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
