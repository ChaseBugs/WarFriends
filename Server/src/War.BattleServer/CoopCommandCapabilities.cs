using War.Protocol;

namespace War.BattleServer;

/// <summary>Keeps accepted co-op commands and the restricted target-world assumption in one place.</summary>
internal static class CoopCommandCapabilities
{
    private static readonly IReadOnlyList<MatchCommand.IntentOneofCase> Accepted = Array.AsReadOnly(new[]
    {
        MatchCommand.IntentOneofCase.Ready,
        MatchCommand.IntentOneofCase.PresentationReady,
        MatchCommand.IntentOneofCase.Forfeit,
        MatchCommand.IntentOneofCase.MoveCover,
        MatchCommand.IntentOneofCase.SwitchWeapon,
        MatchCommand.IntentOneofCase.Reload,
    });

    internal static bool Supports(MatchCommand.IntentOneofCase intent)
    {
        return Accepted.Contains(intent);
    }

    internal static bool CanConfirmPlayerOnlyOpposition => IsPlayerOnlyScope(Accepted);

    internal static bool IsPlayerOnlyScope(IReadOnlyList<MatchCommand.IntentOneofCase> accepted)
    {
        ArgumentNullException.ThrowIfNull(accepted);
        // Adding any new command must close the empty-entity-world assumption until its producers are reviewed.
        return accepted.Count > 0 && accepted.All(intent => intent is
            MatchCommand.IntentOneofCase.Ready or MatchCommand.IntentOneofCase.PresentationReady or
            MatchCommand.IntentOneofCase.Forfeit or MatchCommand.IntentOneofCase.MoveCover or
            MatchCommand.IntentOneofCase.SwitchWeapon or MatchCommand.IntentOneofCase.Reload);
    }
}
