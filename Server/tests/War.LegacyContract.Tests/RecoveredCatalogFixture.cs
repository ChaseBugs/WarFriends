using War.Backend.Legacy;

namespace War.LegacyContract.Tests;

internal static class RecoveredCatalogFixture
{
    internal static string SourceJson { get; } = ReadSource();

    internal static LegacyCatalog Catalog { get; } = LegacyCatalog.ParseConfigured(SourceJson);

    private static string ReadSource()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);
        while (directory != null && !File.Exists(Path.Combine(directory.FullName, "todo-list.md")))
        {
            directory = directory.Parent;
        }

        string root = directory?.FullName ?? throw new DirectoryNotFoundException("Repository root is unavailable.");
        return File.ReadAllText(Path.Combine(root, "Server/content/recovered-battle-content.json"));
    }
}
