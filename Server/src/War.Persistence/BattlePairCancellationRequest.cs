namespace War.Persistence;

/// <summary>Retains cancellation authority on its exact pair after short-lived attempt receipts expire.</summary>
public sealed class BattlePairCancellationRequest
{
    public string PlayerId { get; set; } = "";
    public string AttemptId { get; set; } = "";
    public DateTime RequestedUtc { get; set; }
    public DateTime RetryAfterUtc { get; set; }
}
