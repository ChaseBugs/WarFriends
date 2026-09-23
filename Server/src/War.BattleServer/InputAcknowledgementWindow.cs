namespace War.BattleServer;

public sealed class InputAcknowledgementWindow
{
    private ulong last;
    public ulong LastAcknowledged=>last;
    public bool TryAcknowledge(ulong commandId,ulong snapshotRevision)
    {
        if(commandId==0||snapshotRevision==0||commandId<=last)return false;
        last=commandId;return true;
    }
}
