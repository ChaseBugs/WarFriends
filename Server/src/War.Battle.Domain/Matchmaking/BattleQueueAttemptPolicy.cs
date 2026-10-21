namespace War.Battle.Domain.Matchmaking;

/// <summary>Owns the fixed admission window shared by token issuance and durable queue receipts.</summary>
public static class BattleQueueAttemptPolicy
{
    public const int LifetimeSeconds = 300;
}
