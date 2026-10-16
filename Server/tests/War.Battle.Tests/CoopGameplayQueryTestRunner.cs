using War.BattleServer;

/// <summary>Runs native gameplay-query comparisons without unrelated combat simulations.</summary>
internal static class CoopGameplayQueryTestRunner
{
    internal static void Run()
    {
        DirectoryInfo? directory = new DirectoryInfo(AppContext.BaseDirectory);
        while (directory != null)
        {
            string contentDirectory = Path.Combine(directory.FullName, "content");
            string manifestPath = Path.Combine(contentDirectory, "combat-content-manifest.json");
            if (File.Exists(manifestPath))
            {
                BattleCombatContent content = BattleCombatContent.Load(manifestPath);
                CoopGameplayQueryObservationTests.Run(contentDirectory, content);
                CoopGameplayQueryObservationTests.RunPreparation(contentDirectory, content);
                CoopShotCallbackClockTests.Run(contentDirectory, content);
                return;
            }

            directory = directory.Parent;
        }

        throw new FileNotFoundException("The combat content manifest was not found above the test executable.");
    }
}
