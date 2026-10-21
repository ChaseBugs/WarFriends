namespace War.BattleServer;

internal readonly record struct PvpBazookaStep(PvpBazookaPayload Payload, BazookaMissileImpact? Impact)
{
    internal bool HasInvalidAuthority { get; init; }
}
