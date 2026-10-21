namespace War.Persistence.Legacy.Tutorial;

/// <summary>Checks versioned tutorial identity and explicit legacy mirrors without inventing terminal proof.</summary>
public static class LegacyTutorialAuthority
{
    /// <summary>Matches the lower-case N-format identity issued by the existing server.</summary>
    public static bool IsBattleId(string? value) => War.Shared.CanonicalGuid.IsCanonical(value);

    /// <summary>Permits read-only unbound legacy completion, but rejects inconsistent or damaged authority.</summary>
    public static void ValidateForRead(LegacyPlayerDocument player)
    {
        if (player.PendingTutorialBattleId != null && !IsBattleId(player.PendingTutorialBattleId) ||
            player.TutorialCompleted && player.PendingTutorialBattleId != null)
        {
            throw new InvalidDataException("Invalid legacy tutorial mirrors.");
        }

        LegacyTutorialState? state = player.TutorialState;
        if (state == null)
        {
            // An old terminal Boolean without its cleared ID remains read-only, never a replay receipt.
            return;
        }

        bool pendingMatches = state.Completed
            ? player.PendingTutorialBattleId == null
            : player.PendingTutorialBattleId == state.BattleId;
        if (state.Version != 1 || !IsBattleId(state.BattleId) ||
            state.Completed != player.TutorialCompleted || !pendingMatches)
        {
            throw new InvalidDataException("Versioned tutorial authority disagrees with its legacy mirrors.");
        }
    }
}
