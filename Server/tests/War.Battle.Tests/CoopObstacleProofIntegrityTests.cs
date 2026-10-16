using War.BattleServer;

/// <summary>Requires the paired Unity observation at the actual pose catalog loading boundary.</summary>
internal static class CoopObstacleProofIntegrityTests
{
    private const string BaselineName = "coop-obstacle-volley-unity-reference.json";
    private const string NeutralName = "coop-obstacle-volley-neutral-look-reference.json";
    private const string PreparationName = "coop-gameplay-preparation-post-reference.json";

    internal static void Run(string directory, BattleCombatContent content)
    {
        string temporary = Path.Combine(Path.GetTempPath(), "war-obstacle-proof-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(temporary);
        string baselinePath = Path.Combine(temporary, BaselineName);
        string neutralPath = Path.Combine(temporary, NeutralName);
        string preparationPath = Path.Combine(temporary, PreparationName);
        try
        {
            File.Copy(Path.Combine(directory, BaselineName), baselinePath);
            File.Copy(Path.Combine(directory, NeutralName), neutralPath);
            File.Copy(Path.Combine(directory, PreparationName), preparationPath);
            _ = CoopObstaclePoseCatalog.Load(baselinePath, content.EnemyPoses);
            File.Delete(neutralPath);
            RequireFailure(() => CoopObstaclePoseCatalog.Load(baselinePath, content.EnemyPoses),
                typeof(FileNotFoundException));
            File.Copy(Path.Combine(directory, NeutralName), neutralPath);
            File.AppendAllText(neutralPath, " ");
            RequireFailure(() => CoopObstaclePoseCatalog.Load(baselinePath, content.EnemyPoses),
                typeof(InvalidDataException));
            File.Copy(Path.Combine(directory, NeutralName), neutralPath, true);
            File.Delete(preparationPath);
            RequireFailure(() => CoopObstaclePoseCatalog.Load(baselinePath, content.EnemyPoses),
                typeof(FileNotFoundException));
            File.Copy(Path.Combine(directory, PreparationName), preparationPath);
            File.AppendAllText(preparationPath, " ");
            RequireFailure(() => CoopObstaclePoseCatalog.Load(baselinePath, content.EnemyPoses),
                typeof(InvalidDataException));
        }
        finally
        {
            File.Delete(neutralPath);
            File.Delete(baselinePath);
            File.Delete(preparationPath);
            Directory.Delete(temporary);
        }

        Console.WriteLine("PASS: obstacle catalog rejects missing or changed look and gameplay preparation proofs");
    }

    private static void RequireFailure(Action action, Type expectedException)
    {
        try
        {
            action();
        }
        catch (Exception exception) when (exception.GetType() == expectedException)
        {
            return;
        }

        throw new Exception("The pose catalog accepted incomplete or changed source look evidence.");
    }
}
