namespace War.BattleServer;

internal readonly record struct PvpGrenadeStep(PvpGrenadePayload Payload, GrenadeFlightImpact? Impact)
{
    internal bool HasInvalidAuthority { get; init; }
}
