namespace War.BattleServer;

public readonly record struct ReconnectCursor(ulong SnapshotRevision,ulong EventCursor);

public static class ReconnectCursorValidator
{
    public static void Validate(ReconnectCursor cursor,ulong currentSnapshot,ulong oldestEvent)
    {
        if(cursor.SnapshotRevision==0||cursor.SnapshotRevision>currentSnapshot||cursor.EventCursor<oldestEvent)
            throw new InvalidDataException("Reconnect cursor is outside retained authority.");
    }

    public static void Validate(ReconnectCursor cursor, ulong serverTick,
        ulong currentSnapshot, ulong oldestEvent, ulong retainedEvent)
    {
        Validate(cursor, currentSnapshot, oldestEvent);
        ReconnectSnapshotPolicy.Validate(new ReconnectSnapshotCursor(cursor.SnapshotRevision,
            cursor.EventCursor, serverTick), currentSnapshot, retainedEvent);
    }
}
