namespace War.BattleServer;

public static class BattleTerminalPolicy
{
    private static readonly HashSet<string> Reasons = new(StringComparer.Ordinal)
    { "forfeit", "opponent-disconnected", "both-disconnected", "prestart-disconnect", "duration-limit", "death", "player-killed", "simultaneous-barrel-death", "host-shutdown", "admission-timeout", "cancelled-before-start", "invalid-army-authority", "invalid-army-impact-authority", "invalid-army-projectile-authority", "invalid-barrel-authority", "invalid-combat-authority", "invalid-projectile-authority", "invalid-shield-authority", "army-event-backpressure", "overtime-event-backpressure" };

    public static void Validate(string reason, string winnerPlayerId, bool scored, bool winnerDead)
    {
        bool hasWinner = Guid.TryParseExact(winnerPlayerId ?? "", "N", out _);
        if (!Reasons.Contains(reason) || (!hasWinner && scored))
            throw new InvalidDataException("Invalid terminal battle result.");
        if (scored && reason is "both-disconnected" or "prestart-disconnect" or "duration-limit")
            throw new InvalidDataException("Unscored terminal reason cannot be scored.");
        if (reason is "death" or "player-killed" && winnerDead)
            throw new InvalidDataException("Dead player cannot be winner.");
    }

    public static void ValidateWinner(string reason, string winnerPlayerId, bool scored,
        bool winnerDead, IEnumerable<string> admittedPlayers)
    {
        Validate(reason, winnerPlayerId, scored, winnerDead);
        if (scored && !admittedPlayers.Contains(winnerPlayerId, StringComparer.Ordinal))
            throw new InvalidDataException("Terminal winner is not an admitted player.");
    }
}
