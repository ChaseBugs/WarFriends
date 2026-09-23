namespace War.BattleServer;

public sealed record VehiclePartState(ulong VehicleId, uint VehicleGeneration, string PartId,
    float Health, float MaxHealth, string? PassengerPlayerId)
{
    public VehiclePartState Validate()
    {
        if (VehicleId == 0 || VehicleGeneration == 0 || string.IsNullOrWhiteSpace(PartId) || PartId.Length > 64 ||
            !float.IsFinite(MaxHealth) || MaxHealth <= 0 || MaxHealth > 10_000_000 ||
            !float.IsFinite(Health) || Health < 0 || Health > MaxHealth ||
            (PassengerPlayerId != null && !Guid.TryParseExact(PassengerPlayerId, "N", out _)))
            throw new InvalidDataException("Invalid vehicle part state.");
        return this;
    }
}
