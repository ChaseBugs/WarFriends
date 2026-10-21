using War.Protocol;

namespace War.BattleServer;

/// <summary>
/// Binds private terminal currency quotes to the frozen match allocation.
/// A valid arithmetic result is not enough: the recipient's level must be
/// the one signed for that player before the battle began.
/// </summary>
public static class PvpBonusCurrencyManifestValidator
{
    public static void Validate(MatchSnapshot terminal, MatchManifest frozenManifest)
    {
        ArgumentNullException.ThrowIfNull(terminal);
        ArgumentNullException.ThrowIfNull(frozenManifest);

        var manifest = MatchManifest.Validate(frozenManifest);
        if (terminal.MatchId != manifest.MatchId ||
            terminal.ManifestHash != manifest.Digest() ||
            !terminal.Players.Select(player => player.PlayerId)
                .SequenceEqual(manifest.Players.Select(player => player.PlayerId),
                    StringComparer.Ordinal))
            throw new InvalidDataException("Currency evidence differs from the frozen match.");

        if (terminal.PvpCurrencyQuotes.Count == 0)
            return;
        if (manifest.PvpBonusMode == null || manifest.SceneMasterPlayerId == null)
            throw new InvalidDataException("Currency evidence lacks a signed PvP bonus mode.");

        var levels = manifest.Players.ToDictionary(player => player.PlayerId,
            player => player.PlayerLevel, StringComparer.Ordinal);
        foreach (var quote in terminal.PvpCurrencyQuotes)
        {
            if (!levels.TryGetValue(quote.RecipientPlayerId, out int? level) ||
                level != quote.RecipientLevelIndex)
                throw new InvalidDataException(
                    "Currency quote recipient level differs from the frozen match.");
        }
    }
}
