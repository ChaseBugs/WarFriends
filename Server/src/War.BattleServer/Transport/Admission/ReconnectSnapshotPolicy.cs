namespace War.BattleServer;

public readonly record struct ReconnectSnapshotCursor(ulong SnapshotRevision, ulong EventCursor, ulong ServerTick);

public static class ReconnectSnapshotPolicy
{
    public static ReconnectSnapshotCursor Validate(ReconnectSnapshotCursor cursor, ulong retainedRevision, ulong retainedEvent)
    {
        if (cursor.SnapshotRevision == 0 || cursor.EventCursor == 0 || cursor.ServerTick > 10_000_000 ||
            cursor.SnapshotRevision > retainedRevision || cursor.EventCursor > retainedEvent)
            throw new InvalidDataException("Reconnect cursor is outside retained snapshot history.");
        return cursor;
    }
}
