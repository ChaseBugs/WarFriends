using System.Text.RegularExpressions;

using War.BattleServer;

/// <summary>Requires each explicit engine abort to remain a valid unscored Worker/outbox result.</summary>
internal static class BattleAbortReasonCoverageTests
{
    internal static int Run(string serverDirectory)
    {
        const string Pattern = @"End\(\s*""(?<reason>[a-z-]+)""\s*,\s*""""\s*,\s*false\s*\)";
        string directory = Path.Combine(serverDirectory, "src/War.BattleServer");
        var reasons = new HashSet<string>(StringComparer.Ordinal);
        foreach (string path in Directory.EnumerateFiles(directory, "MatchEngine*.cs"))
        {
            foreach (Match match in Regex.Matches(File.ReadAllText(path), Pattern))
            {
                reasons.Add(match.Groups["reason"].Value);
            }
        }
        if (reasons.Count == 0)
        {
            throw new InvalidOperationException("Engine abort coverage did not inspect any explicit terminal path.");
        }
        int checks = 0;
        foreach (string reason in reasons.Order(StringComparer.Ordinal))
        {
            if (!BattleTerminalPolicy.IsAbortedReason(reason) || BattleTerminalPolicy.IsScoredReason(reason))
            {
                throw new InvalidOperationException("Engine abort is absent from terminal authority: " + reason);
            }
            BattleTerminalPolicy.Validate(reason, "", false, false);
            checks++;
        }
        if (BattleTerminalPolicy.IsAbortedReason("invalid-not-registered"))
        {
            throw new InvalidOperationException("Unknown error prefixes must not bypass the terminal allowlist.");
        }
        return checks + 1;
    }
}
