namespace War.BattleServer;

/// <summary>The Worker and its durable outbox share one terminal-reason contract.</summary>
public static class BattleTerminalPolicy
{
    private static readonly HashSet<string> ScoredReasons = new(StringComparer.Ordinal)
    {
        "forfeit", "opponent-disconnected", "player-killed"
    };

    private static readonly HashSet<string> AbortedReasons = new(StringComparer.Ordinal)
    {
        "admission-timeout", "cancelled-before-start", "prestart-disconnect",
        "both-disconnected", "duration-limit", "simultaneous-barrel-death",
        "host-shutdown", "host-crash",
        "invalid-army-authority", "invalid-army-flame-authority",
        "invalid-army-impact-authority", "invalid-army-poison-authority",
        "invalid-army-projectile-authority", "invalid-barrel-authority",
        "invalid-buggy-projectile-authority", "invalid-combat-authority",
        "invalid-drone-projectile-authority", "invalid-drone-route-authority",
        "invalid-drone-special-authority", "invalid-dynamic-impact-authority",
        "invalid-heavy-turret-authority", "invalid-helicopter-projectile-authority",
        "invalid-helicopter-route-authority", "invalid-infantry-animation-authority",
        "invalid-land-mine-authority", "invalid-projectile-authority",
        "invalid-repair-drone-authority", "invalid-shield-authority",
        "invalid-tank-projectile-authority", "invalid-vehicle-impact-authority",
        "invalid-vehicle-projectile-authority", "invalid-vehicle-route-authority",
        "invalid-assault-helicopter-projectile-authority",
        "invalid-assault-helicopter-route-authority",
        "army-event-backpressure", "source-kill-backpressure",
        "overtime-event-backpressure"
    };

    public static bool IsScoredReason(string reason) => ScoredReasons.Contains(reason);
    public static bool IsAbortedReason(string reason) => AbortedReasons.Contains(reason);

    public static void Validate(string reason, string winnerPlayerId, bool scored, bool winnerDead)
    {
        bool supported = scored ? IsScoredReason(reason) : IsAbortedReason(reason);
        bool hasWinner = Guid.TryParseExact(winnerPlayerId ?? "", "N", out _);
        if (!supported || scored != hasWinner || (scored && winnerDead) ||
            (!scored && !string.IsNullOrEmpty(winnerPlayerId)))
            throw new InvalidDataException("Invalid terminal battle result.");
    }

    public static void ValidateWinner(string reason, string winnerPlayerId, bool scored,
        bool winnerDead, IEnumerable<string> admittedPlayers)
    {
        Validate(reason, winnerPlayerId, scored, winnerDead);
        if (scored && !admittedPlayers.Contains(winnerPlayerId, StringComparer.Ordinal))
            throw new InvalidDataException("Terminal winner is not an admitted player.");
    }
}
