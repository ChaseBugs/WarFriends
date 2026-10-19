using War.BattleServer;

/// <summary>
/// Checks shared ordinary/crew reservations and rollback without creating a combat-ready crew entity.
/// </summary>
internal static class CoopHelicopterDestinationTests
{
    private const float ObstacleFraction = 0.5f;

    internal static void Run(CoopMapEnemyPoints source, CoopEnemyPointMaskCatalog masks, CoopEnemyCombatCatalog combat)
    {
        CoopEnemyPoint point = source.Points.First(row => row.ComponentType == "EnemyPointObstacle");
        CoopMapEnemyPoints map = source with { Points = new[] { point } };
        var state = new CoopEnemyDestinationState(map, masks, combat, () => ObstacleFraction);
        CoopAssignedEnemyDestination? crew = state.TryAssignHelicopterAssaulter(100);
        if (crew?.PointComponentFileId != point.ComponentFileId ||
            crew.Position != CoopEnemyPointSelection.GeneratePosition(point, ObstacleFraction) ||
            state.TryAssignInitial(200, "Assaulter", false, point.TransformPosition) != null)
        {
            throw new Exception("Helicopter crew reservation did not share ordinary soldier occupancy.");
        }
        try
        {
            state.TryAssignHelicopterAssaulter(100);
            throw new Exception("Repeated crew assignment replaced an existing destination.");
        }
        catch (InvalidOperationException)
        {
            if (state.ForEnemy(100) != crew)
            {
                throw new Exception("Rejected crew assignment changed the prior destination.");
            }
        }
        state.Release(100);
        if (state.TryAssignInitial(200, "Assaulter", false, point.TransformPosition) == null ||
            state.TryAssignHelicopterAssaulter(300) != null)
        {
            throw new Exception("Helicopter soldier ignored an ordinary soldier's point reservation.");
        }
        VerifyRollback(map, masks, combat, point);
        Console.WriteLine("PASS: helicopter Assaulter destinations share reservations and roll back failed placement.");
    }

    private static void VerifyRollback(CoopMapEnemyPoints map, CoopEnemyPointMaskCatalog masks,
        CoopEnemyCombatCatalog combat, CoopEnemyPoint point)
    {
        float fraction = float.NaN;
        var state = new CoopEnemyDestinationState(map, masks, combat, () => fraction);
        try
        {
            state.TryAssignHelicopterAssaulter(400);
            throw new Exception("Malformed obstacle placement created a crew destination.");
        }
        catch (ArgumentOutOfRangeException)
        {
            if (state.ForEnemy(400) != null)
            {
                throw new Exception("Failed crew placement published a destination.");
            }
        }
        fraction = ObstacleFraction;
        if (state.TryAssignInitial(500, "Assaulter", false, point.TransformPosition) == null)
        {
            throw new Exception("Failed helicopter crew placement leaked its scene point reservation.");
        }
        state.Release(500);
        if (state.TryAssignHelicopterAssaulter(400) == null)
        {
            throw new Exception("Valid crew retry could not claim a released scene point.");
        }
    }
}
