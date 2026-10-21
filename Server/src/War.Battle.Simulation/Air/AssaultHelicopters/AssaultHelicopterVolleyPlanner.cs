namespace War.BattleServer;

/// <summary>
/// The recovered AssaultHelicopter.Shoot splits a batch between two guns.
/// This plans the volley; projectile creation and damage remain separate.
/// </summary>
internal static class AssaultHelicopterVolleyPlanner
{
    // Both AutomaticRifle components in the pinned assaultHelicopter.prefab
    // serialize the same 0.26-second cadence.
    internal const float GunCadenceSeconds = .26f;

    internal sealed record Volley(int FirstGunCount, int SecondGunCount,
        float SecondGunDelaySeconds);

    internal static Volley Plan(ArmyVehicleShotStats shot, Func<int, int> chooseIndex)
    {
        if (chooseIndex == null || shot.FireBatchSizeMin < 0 ||
            shot.FireBatchSizeMax < shot.FireBatchSizeMin ||
            shot.FireBatchSizeMax > 64)
            throw new InvalidDataException("Invalid Assault Helicopter volley authority.");

        // Unity's integer Random.Range excludes the upper endpoint.
        int span = shot.FireBatchSizeMax - shot.FireBatchSizeMin;
        int index = span == 0 ? 0 : chooseIndex(span);
        if (index < 0 || (span > 0 && index >= span))
            throw new InvalidDataException("Assault Helicopter batch selection escaped its source range.");

        int batchSize = shot.FireBatchSizeMin + index;
        int firstGunCount = batchSize / 2;
        int secondGunCount = batchSize - firstGunCount;
        // StartShooting invokes the second BatchedWeapon after half its own cadence.
        return new(firstGunCount, secondGunCount, GunCadenceSeconds * .5f);
    }

    internal static IReadOnlyList<bool> SampleRealShots(int count, float probability,
        Func<float> nextRandom)
    {
        if (count < 0 || count > 32 || !float.IsFinite(probability) ||
            probability < 0 || probability > 3 || nextRandom == null)
            throw new InvalidDataException("Invalid Assault Helicopter shot mask authority.");

        var realShots = new bool[count];
        for (int index = 0; index < count; index++)
        {
            float sample = nextRandom();
            if (!float.IsFinite(sample) || sample < 0 || sample > 1)
                throw new InvalidDataException("Invalid Assault Helicopter real-shot sample.");
            realShots[index] = sample < probability;
        }
        return Array.AsReadOnly(realShots);
    }
}
