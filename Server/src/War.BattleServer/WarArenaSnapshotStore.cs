namespace War.BattleServer;

public sealed class WarArenaSnapshotStore
{
    private WarArenaSnapshot? current;
    public WarArenaSnapshot? Current=>current;
    public bool TryPublish(WarArenaSnapshot snapshot,ulong expectedRevision)
    {
        WarArenaSnapshotValidator.Validate(snapshot);
        ulong actual=current?.Revision??0;
        if(actual!=expectedRevision||current!=null&&snapshot.Revision<=actual)return false;
        current=snapshot;return true;
    }
}
