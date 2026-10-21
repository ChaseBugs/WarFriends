namespace War.Persistence.Battles.Settlement;

/// <summary>Immutable battle-wide replay evidence; Id is the unique match identity.</summary>
public sealed class BattleSettlementReceipt
{
    public string Id { get; set; } = "";
    public string ResultDigest { get; set; } = "";
    public string ManifestHash { get; set; } = "";
    public string PolicyRevision { get; set; } = "";
    public DateTime SettledUtc { get; set; }
    public Dictionary<string, string> Responses { get; set; } = [];
}
