using War.Persistence.Legacy.Accounts;

namespace War.Backend.Legacy.Progression;

/// <summary>Compares recovered zero-based rank authority with a catalog's display-level requirement.</summary>
public static class LegacyRankGate
{
    /// <summary>Preserves zero/no-gate rows and unreachable tier sentinels without changing stored rank.</summary>
    public static bool IsUnlocked(int playerRankIndex, int requiredDisplayLevel)
    {
        if (playerRankIndex is < 0 or >= LegacyAccountCreation.RecoveredRankCount || requiredDisplayLevel < 0)
        {
            throw new InvalidDataException("Invalid rank or catalog level gate.");
        }

        // GameLevel.displayNumber is index + 1. Purchase/unlock builders compare index against row - 1;
        // tier promotion compares displayNumber against the raw row. Both describe this same boundary.
        return playerRankIndex + 1 >= requiredDisplayLevel;
    }
}
