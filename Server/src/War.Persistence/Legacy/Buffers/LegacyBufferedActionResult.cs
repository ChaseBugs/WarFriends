namespace War.Persistence.Legacy.Buffers;

/// <summary>Returns the committed account and exact response, or an untrusted historical replay.</summary>
public sealed record LegacyBufferedActionResult(
    LegacyPlayerDocument Player,
    string? ResponseJson,
    LegacyBufferedDelivery? Delivery = null);
