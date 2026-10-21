namespace War.BattleServer;

/// <summary>Consumes the full base StartShooting batch before the Gunslinger forces one round.</summary>
internal static class GunslingerShotBatchPolicy
{
    internal static CoopInfantryShotBatch Create(ArmyBaseShotStats source, Func<int, int> choose,
        Func<float> realShotRoll)
    {
        CoopInfantryShotBatch original = AssaulterShotBatchPolicy.Create(source, choose, realShotRoll);
        // The override changes mFireBatchSize after the base fills mFakeAndRealShots.
        // Preserve every original draw, but only bit zero can drive the single round.
        return new CoopInfantryShotBatch(1, original.RealShotMask & 1);
    }
}
