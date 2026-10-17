namespace War.Persistence;

/// <summary>Retains attempt ownership until no signed admission request can reopen it.</summary>
public sealed class BattleQueueAttemptDocument
{
    public string Id { get; set; } = "";
    public string PlayerId { get; set; } = "";
    public string AttemptId { get; set; } = "";
    public string State { get; set; } = "waiting";
    public string MatchId { get; set; } = "";
    public DateTime IssuedUtc { get; set; }
    public DateTime ExpiresUtc { get; set; }
    public DateTime RetainUntilUtc { get; set; }
    public long Revision { get; set; }
}
