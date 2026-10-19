using System.Numerics;

using War.BattleServer;

/// <summary>Checks ordinary post-helicopter selection separately from nearest initial placement.</summary>
internal static class CoopExternalPointSelectionTests
{
    private const int ObstacleMask = 2;

    internal static int Run(CoopMapEnemyPoints sourceMap, CoopEnemyPoint sourcePoint)
    {
        CoopEnemyPoint first = sourcePoint with
        {
            Order = 0, ComponentFileId = 1, Position = new Vector3(20, 0, 0),
            TransformPosition = new Vector3(20, 0, 0),
        };
        CoopEnemyPoint last = first with
        {
            Order = 1, ComponentFileId = 2, Position = Vector3.Zero, TransformPosition = Vector3.Zero,
        };
        CoopMapEnemyPoints map = sourceMap with { Points = new[] { first, last } };
        int drawCount = 0;
        CoopEnemyPoint? selected = CoopEnemyPointSelection.SelectFromExternalPoint(map, ObstacleMask,
            new HashSet<int>(), count =>
            {
                drawCount = count;
                return 0;
            });
        Require(selected == first && drawCount == 2,
            "External seat transition selected nearest placement or excluded a prefab-local identity.");
        selected = CoopEnemyPointSelection.SelectFromExternalPoint(map, ObstacleMask,
            new HashSet<int> { first.ComponentFileId }, count => count - 1);
        Require(selected == last, "External seat transition ignored a scene point reservation.");
        selected = CoopEnemyPointSelection.SelectFromExternalPoint(map, ObstacleMask,
            new HashSet<int> { first.ComponentFileId, last.ComponentFileId },
            _ => throw new Exception("Empty point list consumed randomness."));
        Require(selected == null, "Full scene point list fabricated a helicopter crew destination.");
        foreach (int invalid in new[] { -1, 2 })
        {
            try
            {
                CoopEnemyPointSelection.SelectFromExternalPoint(map, ObstacleMask, new HashSet<int>(), _ => invalid);
                throw new Exception("External point selection accepted a draw outside the candidate list.");
            }
            catch (InvalidDataException)
            {
                // An invalid host draw must fail rather than clamp into a valid destination.
            }
        }
        return 5;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new Exception(message);
        }
    }
}
