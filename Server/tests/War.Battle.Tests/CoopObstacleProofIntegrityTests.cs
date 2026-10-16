using War.BattleServer;

/// <summary>Requires the paired Unity observation at the actual pose catalog loading boundary.</summary>
internal static class CoopObstacleProofIntegrityTests
{
    private const string BaselineName = "coop-obstacle-volley-unity-reference.json";
    private const string NeutralName = "coop-obstacle-volley-neutral-look-reference.json";

    internal static void Run(string directory, BattleCombatContent content)
    {
        string temporary = Path.Combine(Path.GetTempPath(), "war-obstacle-proof-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(temporary);
        string baselinePath = Path.Combine(temporary, BaselineName);
        string neutralPath = Path.Combine(temporary, NeutralName);
        try
        {
            File.Copy(Path.Combine(directory, BaselineName), baselinePath);
            File.Copy(Path.Combine(directory, NeutralName), neutralPath);
            _ = CoopObstaclePoseCatalog.Load(baselinePath, content.EnemyPoses);
            File.Delete(neutralPath);
            RequireFailure(() => CoopObstaclePoseCatalog.Load(baselinePath, content.EnemyPoses),
                typeof(FileNotFoundException));
            File.Copy(Path.Combine(directory, NeutralName), neutralPath);
            File.AppendAllText(neutralPath, " ");
            RequireFailure(() => CoopObstaclePoseCatalog.Load(baselinePath, content.EnemyPoses),
                typeof(InvalidDataException));
        }
        finally
        {
            File.Delete(neutralPath);
            File.Delete(baselinePath);
            Directory.Delete(temporary);
        }

        Console.WriteLine("PASS: obstacle catalog rejects missing or changed neutral-look proof");
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
