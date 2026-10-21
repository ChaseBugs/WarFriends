namespace War.BattleServer;

/// <summary>Preserves SoldierBehaviour.StartShooting's exclusive batch draw, clamp and per-round real rolls.</summary>
internal static class AssaulterShotBatchPolicy
{
    private const int MaximumUpgradeBatch = 64;
    private const int MaximumVolleyRounds = 14;
    private const float MaximumComposedProbability = 40f;

    internal static CoopInfantryShotBatch Create(ArmyBaseShotStats source, Func<int, int> choose,
        Func<float> realShotRoll)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(choose);
        ArgumentNullException.ThrowIfNull(realShotRoll);
        if (source.FireBatchSizeMin < 1 || source.FireBatchSizeMax < source.FireBatchSizeMin ||
            source.FireBatchSizeMax > MaximumUpgradeBatch || !float.IsFinite(source.ProbabilityOfRealShot) ||
            source.ProbabilityOfRealShot is < 0f or > MaximumComposedProbability)
        {
            throw new InvalidDataException("Assaulter batch lost its composed source shot authority.");
        }

        int width = source.FireBatchSizeMax - source.FireBatchSizeMin;
        int index = width == 0 ? 0 : choose(width);
        if (index < 0 || (width > 0 && index >= width))
        {
            throw new InvalidDataException("Assaulter batch draw left its exclusive source range.");
        }

        int count = Math.Min(source.FireBatchSizeMin + index, MaximumVolleyRounds);
        int realMask = 0;
        for (int round = 0; round < count; round++)
        {
            float roll = realShotRoll();
            if (!float.IsFinite(roll) || roll is < 0f or >= 1f)
            {
                throw new InvalidDataException("Assaulter real-shot roll left its source range.");
            }

            if (roll < source.ProbabilityOfRealShot)
            {
                realMask |= 1 << round;
            }
        }

        return new CoopInfantryShotBatch(count, realMask);
    }
}
