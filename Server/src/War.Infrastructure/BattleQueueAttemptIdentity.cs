namespace War.Infrastructure;

/// <summary>Server-authenticated queue ownership; its expiry bounds admission, not receipt retention.</summary>
public readonly record struct BattleQueueAttemptIdentity(
    string PlayerId,
    string AttemptId,
    long IssuedUnixSeconds,
    long ExpiresUnixSeconds);
