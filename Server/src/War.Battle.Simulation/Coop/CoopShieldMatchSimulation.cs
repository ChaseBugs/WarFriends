namespace War.BattleServer;

/// <summary>
/// Four same-fraction co-op covers. A host-owned collision resolver may apply
/// damage; player UDP commands cannot reach this simulation.
/// </summary>
internal sealed class CoopShieldMatchSimulation
{
    private sealed record UnitShotReceipt(int CoverIndex, float SourceDamage,
        ulong Tick, ShieldMutation? Result);

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
    private readonly Dictionary<ulong, UnitShotReceipt> unitShotReceipts = [];
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

    internal float HealthRatioAt(int coverIndex)
    {
        Cover? cover = covers.SingleOrDefault(row => row.Index == coverIndex);
        if (cover == null)
            throw new InvalidDataException("Player has no source shield cover.");
        if (cover.Lifecycle.MaxHealth <= 0)
            return 0;
        return Math.Clamp(cover.Lifecycle.Health /
            cover.Lifecycle.MaxHealth, 0f, 1f);
    }

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

    /// <summary>
    /// Shield.DoDamage uses UnitToShieldCoef for a soldier's shot.
    /// Only a future verified host projectile impact may call this path.
    /// </summary>
    internal ShieldMutation? ApplyHostUnitShot(
        ulong projectileId, int coverIndex, float sourceDamage, ulong tick)
    {
        if (projectileId == 0 || !float.IsFinite(sourceDamage) ||
            sourceDamage is < 0 or > 100_000_000)
            throw new InvalidDataException(
                "Co-op unit shield shot has invalid host evidence.");
        if (unitShotReceipts.TryGetValue(projectileId,
                out UnitShotReceipt? previous))
        {
            if (previous.CoverIndex != coverIndex ||
                BitConverter.SingleToInt32Bits(previous.SourceDamage) !=
                    BitConverter.SingleToInt32Bits(sourceDamage) ||
                previous.Tick != tick)
                throw new InvalidDataException(
                    "Co-op unit shield projectile replay conflicts.");
            return previous.Result;
        }
        if (tick != lastTick)
            throw new InvalidDataException(
                "Co-op unit shield impact used a different host tick.");
        Cover? cover = covers.SingleOrDefault(row =>
            row.Index == coverIndex);
        if (cover == null)
            throw new InvalidDataException(
                "Co-op unit shield impact has no source cover.");
        if (unitShotReceipts.Count >= 65_536)
            throw new InvalidOperationException(
                "Co-op unit shield impact receipt capacity is exhausted.");

        float previousHealth = cover.Lifecycle.Health;
        cover.Lifecycle.ApplyUnitShot(sourceDamage, tick);
        ShieldMutation? result = null;
        if (cover.Lifecycle.Health != previousHealth)
        {
            cover.Revision++;
            result = cover.Snapshot();
        }
        unitShotReceipts.Add(projectileId,
            new UnitShotReceipt(coverIndex, sourceDamage, tick, result));
        return result;
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
