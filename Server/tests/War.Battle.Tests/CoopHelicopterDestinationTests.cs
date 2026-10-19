using War.BattleServer;

/// <summary>
/// Checks shared ordinary/crew reservations and rollback without creating a combat-ready crew entity.
/// </summary>
internal static class CoopHelicopterDestinationTests
{
    private const float ObstacleFraction = 0.5f;

    internal static void Run(CoopMapEnemyPoints source, CoopEnemyPointMaskCatalog masks,
        CoopEnemyCombatCatalog combat, CoopAiSpawnSelector spawns)
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
        VerifyExitBranches(map, masks, combat, spawns);
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

    private static void VerifyExitBranches(CoopMapEnemyPoints map, CoopEnemyPointMaskCatalog masks,
        CoopEnemyCombatCatalog combat, CoopAiSpawnSelector spawns)
    {
        var state = new CoopEnemyDestinationState(map, masks, combat, () => ObstacleFraction);
        CoopHelicopterExitTarget first = state.ResolveHelicopterAssaulterExit(600, spawns,
            _ => throw new Exception("Available scene point consumed a fallback spawn draw."));
        if (first is not CoopHelicopterEnemyTarget target || state.ForEnemy(600) != target.Destination)
        {
            throw new Exception("Live exit target was not reserved through the shared destination state.");
        }
        CoopHelicopterExitTarget full = state.ResolveHelicopterAssaulterExit(700, spawns, _ => 0);
        if (full is not CoopHelicopterFallbackTarget fallback || fallback.Spawn.Fraction != 1 ||
            fallback.Spawn.ComponentType != "SpawnPoint" || state.ForEnemy(700) != null)
        {
            throw new Exception("Full scene points failed to produce an unreserved enemy Normal fallback.");
        }
        try
        {
            state.ResolveHelicopterAssaulterExit(800, spawns, _ => -1);
            throw new Exception("Exit target accepted a malformed fallback draw.");
        }
        catch (InvalidDataException)
        {
            if (state.ForEnemy(800) != null || state.ForEnemy(600) != target.Destination)
            {
                throw new Exception("Rejected exit fallback changed shared scene reservations.");
            }
        }
        state.Release(600);
        if (state.ResolveHelicopterAssaulterExit(700, spawns, _ => 0) is not CoopHelicopterEnemyTarget)
        {
            throw new Exception("Fallback choice leaked occupancy or prevented later free-point selection.");
        }
    }
}
