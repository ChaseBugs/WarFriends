namespace War.BattleServer;

/// <summary>
/// Four same-fraction co-op covers. A host-owned collision resolver may apply
/// damage; player UDP commands cannot reach this simulation.
/// </summary>
internal sealed class CoopShieldMatchSimulation
{
    private sealed class Cover(int index, int ownerFraction,
        ShieldLifecycle lifecycle)
    {
        internal int Index { get; } = index;
        internal int OwnerFraction { get; } = ownerFraction;
        internal ShieldLifecycle Lifecycle { get; } = lifecycle;
        internal ulong Revision;

        internal ShieldMutation Snapshot() => new(Index, OwnerFraction, Lifecycle.Health,
            Lifecycle.MaxHealth, Lifecycle.Destroyed, Revision);
    }

    private readonly Cover[] covers;
    private ulong lastTick;

    internal CoopShieldMatchSimulation(MatchManifest manifest,
        CoopShieldStateCatalog missions, ShieldSourceCatalog policy,
        int firstCover, ulong startingTick)
        : this(2, CoopShieldRankResolver.AlliedRank(manifest),
            missions.ForMission(manifest.MissionIndex ??
                throw new InvalidDataException("Co-op shield mission is absent.")).Player,
            policy, firstCover, startingTick)
    {
    }

    internal CoopShieldMatchSimulation(int ownerFraction, int provenRank,
        IReadOnlyList<CoopShieldStart> starts, ShieldSourceCatalog policy,
        int firstCover, ulong startingTick)
    {
        bool alliedCovers = ownerFraction == 2 && (firstCover == 0 || firstCover == 4);
        bool bossCovers = ownerFraction == 1 && firstCover == 0;
        if (startingTick > 10_000_000 ||
            (!alliedCovers && !bossCovers) ||
            starts == null || starts.Count > 4)
            throw new InvalidDataException("Invalid co-op shield start.");
        lastTick = startingTick;
        covers = new Cover[4];
        for (int index = 0; index < covers.Length; index++)
        {
            var lifecycle = new ShieldLifecycle(policy, provenRank, startingTick);
            lifecycle.ApplyMissionStart(index < starts.Count ? starts[index] : null);
            covers[index] = new Cover(firstCover + index, ownerFraction, lifecycle);
        }
    }

    internal IReadOnlyList<ShieldMutation> Snapshot() =>
        Array.AsReadOnly(covers.Select(cover => cover.Snapshot()).ToArray());

    internal ShieldMutation? ApplyHostShot(
        int coverIndex, string weaponId, float damage, ulong tick)
    {
        if (tick != lastTick)
            throw new InvalidDataException("Co-op shield impact used a different host tick.");
        Cover? cover = covers.SingleOrDefault(row => row.Index == coverIndex);
        if (cover == null)
            return null;
        float before = cover.Lifecycle.Health;
        cover.Lifecycle.ApplyShot(weaponId, damage, tick);
        if (cover.Lifecycle.Health == before)
            return null;
        cover.Revision++;
        return cover.Snapshot();
    }

    internal bool Advance(ulong tick, IReadOnlyCollection<int> occupiedCovers)
    {
        if (tick != lastTick + 1)
            throw new InvalidDataException("Co-op shields need the next host tick.");
        ArgumentNullException.ThrowIfNull(occupiedCovers);
        bool changed = false;
        foreach (Cover cover in covers)
        {
            cover.Lifecycle.HasPlayer = occupiedCovers.Contains(cover.Index);
            float before = cover.Lifecycle.Health;
            bool wasDestroyed = cover.Lifecycle.Destroyed;
            cover.Lifecycle.Advance(tick);
            if (before != cover.Lifecycle.Health ||
                wasDestroyed != cover.Lifecycle.Destroyed)
            {
                cover.Revision++;
                changed = true;
            }
        }
        lastTick = tick;
        return changed;
    }
}
