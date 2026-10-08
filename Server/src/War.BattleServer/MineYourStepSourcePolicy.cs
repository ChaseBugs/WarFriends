using System.Numerics;

namespace War.BattleServer;

public sealed record MineYourStepPlacement(
    Vector3 Position, int FirstEnemyCover, int SecondEnemyCover,
    float OuterDamage, float ExplosionDamage);

/// <summary>
/// Recovered CardMineYourStep placement and damage inputs. The match host chooses
/// the random pair and samples its own navigation mesh; the client supplies neither.
/// </summary>
public static class MineYourStepSourcePolicy
{
    public const float DurationSeconds = 15f;
    public const float DamageFraction = 0.2f;
    public const float OuterDamageFraction = 0.1f;
    public const float NavMeshSampleRadius = 10f;

    public static MineYourStepPlacement? Select(
        RecoveredBattleMap map, int ownerFraction, Func<int, int> choose,
        Func<Vector3, Vector3?> sampleNearest, float opponentMaximumHealth)
    {
        if (map == null || ownerFraction is not (1 or 2) || choose == null ||
            sampleNearest == null || !float.IsFinite(opponentMaximumHealth) ||
            opponentMaximumHealth <= 0 || opponentMaximumHealth > 10_000_000)
            throw new InvalidDataException("Mine Your Step needs valid source and opponent authority.");

        // SelectRandomPosition uses the four opposing PlayerPoints in map order.
        // Unity Random.Range(1, 4) selects one of adjacent pairs 0-1, 1-2, 2-3.
        var enemyCovers = map.Covers.Where(cover => cover.Fraction != ownerFraction).ToArray();
        if (enemyCovers.Length != 4 || enemyCovers.Select(cover => cover.SourceIndex).Distinct().Count() != 4)
            throw new InvalidDataException("Mine Your Step needs four ordered opposing cover points.");
        int pair = choose(3);
        if (pair is < 0 or > 2)
            throw new InvalidDataException("Mine Your Step random pair is outside source bounds.");

        Vector3 midpoint = Vector3.Lerp(enemyCovers[pair].Position, enemyCovers[pair + 1].Position, 0.5f);
        Vector3? sampled = sampleNearest(midpoint);
        if (!sampled.HasValue) return null;
        if (!PlayerHitbox.Finite(sampled.Value) || Vector3.Distance(midpoint, sampled.Value) > NavMeshSampleRadius)
            throw new InvalidDataException("Mine Your Step placement escaped the source NavMesh radius.");

        float explosionDamage = DamageFraction * opponentMaximumHealth;
        float outerDamage = OuterDamageFraction * DamageFraction * opponentMaximumHealth;
        if (!float.IsFinite(explosionDamage) || !float.IsFinite(outerDamage) ||
            explosionDamage <= 0 || outerDamage <= 0 || explosionDamage > 10_000_000)
            throw new InvalidDataException("Mine Your Step damage escaped host bounds.");

        return new MineYourStepPlacement(sampled.Value, enemyCovers[pair].SourceIndex,
            enemyCovers[pair + 1].SourceIndex, outerDamage, explosionDamage);
    }
}
