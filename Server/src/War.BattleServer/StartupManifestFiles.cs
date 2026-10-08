namespace War.BattleServer;

public static class StartupManifestFiles
{
    public static string[] ReadPaths(string? singlePath, string? directory,
        int maxMatches)
    {
        if (!string.IsNullOrEmpty(singlePath) &&
            !string.IsNullOrEmpty(directory))
            throw new InvalidDataException(
                "Choose a single manifest or a manifest directory.");

        if (!string.IsNullOrEmpty(singlePath))
            return [singlePath];
        if (string.IsNullOrEmpty(directory))
            return [];
        if (maxMatches is < 1 or > 1024)
            throw new InvalidDataException("Invalid match capacity.");

        string[] paths = Directory.EnumerateFiles(directory, "*.json")
            .Take(maxMatches + 1)
            .ToArray();
        if (paths.Length > maxMatches)
            throw new InvalidDataException(
                "Startup manifest directory exceeds configured match capacity.");

        Array.Sort(paths, StringComparer.Ordinal);
        return paths;
    }
}
