namespace War.BattleServer;

public static class BattleTerminalPolicy
{
    private static readonly HashSet<string> ScoredReasons = new(StringComparer.Ordinal)
    { "forfeit", "opponent-disconnected", "death", "player-killed" };

    private static readonly HashSet<string> Reasons = new(StringComparer.Ordinal)
    { "forfeit", "opponent-disconnected", "both-disconnected", "prestart-disconnect", "duration-limit", "death", "player-killed", "simultaneous-barrel-death", "host-shutdown", "admission-timeout", "cancelled-before-start", "invalid-army-authority", "invalid-army-flame-authority", "invalid-army-impact-authority", "invalid-army-poison-authority", "invalid-army-projectile-authority", "invalid-barrel-authority", "invalid-buggy-projectile-authority", "invalid-combat-authority", "invalid-drone-projectile-authority", "invalid-drone-route-authority", "invalid-drone-special-authority", "invalid-dynamic-impact-authority", "invalid-heavy-turret-authority", "invalid-helicopter-projectile-authority", "invalid-helicopter-route-authority", "invalid-infantry-animation-authority", "invalid-land-mine-authority", "invalid-projectile-authority", "invalid-repair-drone-authority", "invalid-shield-authority", "invalid-tank-projectile-authority", "invalid-vehicle-impact-authority", "invalid-vehicle-projectile-authority", "invalid-vehicle-route-authority", "army-event-backpressure", "overtime-event-backpressure" };

    public static void Validate(string reason, string winnerPlayerId, bool scored, bool winnerDead)
    {
        bool hasWinner = Guid.TryParseExact(winnerPlayerId ?? "", "N", out _);
        if (!Reasons.Contains(reason) || scored != ScoredReasons.Contains(reason) ||
            scored != hasWinner || (scored && winnerDead) ||
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
