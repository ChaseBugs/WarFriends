namespace War.Persistence;

/// <summary>Stores consent separately from the immutable completed battle result.</summary>
public sealed class BattleRematchConsentDocument
{
    public string Id { get; set; } = "";

    public string ResultDigest { get; set; } = "";

    public string[] Players { get; set; } = [];

    public string[] AcceptedPlayers { get; set; } = [];

    public string Status { get; set; } = "";

    public string NextMatchId { get; set; } = "";

    public string NextCompatibilityKey { get; set; } = "";

    public string[] NextPlayers { get; set; } = [];

    public long Revision { get; set; }

    public DateTime CreatedUtc { get; set; }

    public DateTime UpdatedUtc { get; set; }

    public DateTime ExpiresUtc { get; set; }
}
