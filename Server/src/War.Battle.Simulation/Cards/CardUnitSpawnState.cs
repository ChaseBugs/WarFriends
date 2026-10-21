namespace War.BattleServer;

/// <summary>A single source-scheduled unit awaiting its host-owned scene spawn.</summary>
internal sealed record CardUnitSpawnIntent(string RequestId, string OwnerPlayerId,
    string SourceCardId, int UnitIndex, ulong DueTick);

/// <summary>
/// Keeps unit-card calls separate from ordinary army deployments. Cards spend
/// their own inventory reservation; they do not consume army energy, use an
/// offered deployment option, or grant normal deployment power on death.
/// </summary>
internal sealed class CardUnitSpawnState
{
    private readonly int pendingLimit;
    private readonly List<CardUnitSpawnIntent> pending = [];
    private readonly HashSet<string> acceptedRequests = new(StringComparer.Ordinal);
    private readonly HashSet<string> completedRequests = new(StringComparer.Ordinal);

    internal CardUnitSpawnState(int pendingLimit = 128)
    {
        if (pendingLimit is < 1 or > 4096)
            throw new ArgumentOutOfRangeException(nameof(pendingLimit));
        this.pendingLimit = pendingLimit;
    }

    internal int PendingCount => pending.Count;

    internal bool TrySchedule(string requestId, string ownerPlayerId,
        string sourceCardId, ulong activatedTick)
    {
        if (!War.Shared.CanonicalGuid.IsCanonical(requestId) ||
            string.IsNullOrWhiteSpace(ownerPlayerId) || ownerPlayerId.Length > 64 ||
            activatedTick > 10_000_000)
            throw new InvalidDataException("Invalid unit-card activation identity.");

        var schedule = new CardSpawnUnitSchedule(sourceCardId, activatedTick);
        if (acceptedRequests.Contains(requestId)) return false;
        if (acceptedRequests.Count >= 4096 ||
            schedule.Count > pendingLimit - pending.Count) return false;

        var newIntents = new CardUnitSpawnIntent[schedule.Count];
        for (int unitIndex = 0; unitIndex < schedule.Count; unitIndex++)
        {
            ulong dueTick = schedule.DueTick(unitIndex);
            if (dueTick > 10_000_000)
                throw new InvalidDataException("Unit-card spawn exceeds the match clock.");
            newIntents[unitIndex] = new CardUnitSpawnIntent(requestId,
                ownerPlayerId, sourceCardId, unitIndex, dueTick);
        }

        acceptedRequests.Add(requestId);
        pending.AddRange(newIntents);
        return true;
    }

    internal IReadOnlyList<CardUnitSpawnIntent> Due(ulong tick) =>
        pending.Where(intent => intent.DueTick <= tick)
            .OrderBy(intent => intent.DueTick)
            .ThenBy(intent => intent.RequestId, StringComparer.Ordinal)
            .ThenBy(intent => intent.UnitIndex)
            .ToArray();

    internal bool Complete(CardUnitSpawnIntent intent, ulong tick)
    {
        if (intent == null || tick < intent.DueTick) return false;
        if (!pending.Remove(intent)) return false;
        completedRequests.Add(intent.RequestId);
        return true;
    }

    /// <summary>
    /// Undo an activation only before any of its source calls have run. The
    /// caller uses this if the inventory/effect reservation fails afterward.
    /// </summary>
    internal bool CancelBeforeSpawn(string requestId)
    {
        if (!acceptedRequests.Contains(requestId) ||
            completedRequests.Contains(requestId)) return false;

        pending.RemoveAll(intent => intent.RequestId == requestId);
        acceptedRequests.Remove(requestId);
        return true;
    }
}
