namespace War.BattleServer;

public readonly record struct ReconnectRecoveryPlan(
    ReconnectSnapshotCursor Cursor,
    ulong SnapshotRevision,
    ulong ReplayFromEvent,
    bool RequiresFullSnapshot);

/// <summary>Builds a bounded reconnect plan before any snapshot or event data is emitted.</summary>
public static class ReconnectRecoveryCoordinator
{
    public static ReconnectRecoveryPlan Build(
        ReconnectSnapshotCursor cursor,
        ulong currentSnapshotRevision,
        ReliableEventPayloadStore payloadStore,
        ulong serverTick)
    {
        if (payloadStore is null) throw new ArgumentNullException(nameof(payloadStore));
        if (payloadStore.FirstRetainedSequence == 0 || payloadStore.LastRetainedSequence == 0)
            throw new InvalidDataException("No durable event history is available for reconnect.");
        return Build(cursor, currentSnapshotRevision, payloadStore.FirstRetainedSequence,
            payloadStore.LastRetainedSequence, serverTick);
    }

    public static ReconnectRecoveryPlan Build(
        ReconnectSnapshotCursor cursor,
        ulong currentSnapshotRevision,
        ulong oldestRetainedEvent,
        ulong newestRetainedEvent,
        ulong serverTick)
    {
        if (currentSnapshotRevision == 0 || oldestRetainedEvent == 0 ||
            newestRetainedEvent < oldestRetainedEvent || serverTick > 10_000_000)
            throw new InvalidDataException("Invalid reconnect authority window.");
        ReconnectSnapshotPolicy.Validate(cursor, currentSnapshotRevision, newestRetainedEvent);
        bool fullSnapshot = cursor.EventCursor < oldestRetainedEvent;
        ulong replayFrom = fullSnapshot ? newestRetainedEvent + 1 : cursor.EventCursor + 1;
        if (replayFrom < cursor.EventCursor || replayFrom > newestRetainedEvent + 1)
            throw new InvalidDataException("Invalid reconnect replay range.");
        return new ReconnectRecoveryPlan(cursor, currentSnapshotRevision, replayFrom, fullSnapshot);
    }
}
