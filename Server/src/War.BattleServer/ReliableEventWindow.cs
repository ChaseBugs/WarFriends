namespace War.BattleServer;

public sealed class ReliableEventWindow
{
    private readonly int capacity;
    private ulong next=1, acknowledged;
    public ReliableEventWindow(int capacity=64){if(capacity is <1 or >1024)throw new InvalidDataException("Invalid event window.");this.capacity=capacity;}
    public ulong NextEventId=>next;
    public ulong Acknowledged=>acknowledged;
    public bool CanReplay(ulong eventId)=>eventId>=acknowledged&&eventId<next;
    public IReadOnlyList<ulong> ReplayRange(int maxEvents = 256)
    {
        if (maxEvents is < 1 or > 1024) throw new InvalidDataException("Invalid replay range.");
        ulong first = acknowledged == 0 ? 1 : acknowledged;
        ulong count = next > first ? next - first : 0;
        if (count > (ulong)maxEvents) throw new InvalidOperationException("Replay range exceeds caller bound.");
        var result = new List<ulong>((int)count);
        for (ulong id = first; id < next; id++) result.Add(id);
        return result;
    }
    public (ulong Next,ulong Acknowledged) Snapshot=>(next,acknowledged);
    public void Restore(ulong restoredNext,ulong restoredAcknowledged)
    {
        if(restoredNext<1||restoredAcknowledged>restoredNext||restoredNext-restoredAcknowledged-1>(ulong)capacity)
            throw new InvalidDataException("Invalid reliable event cursor.");
        next=restoredNext;acknowledged=restoredAcknowledged;
        ValidateRetention();
    }
    public ulong Append(){if(next-acknowledged-1>=(ulong)capacity)throw new InvalidOperationException("Event window is full.");var id=next++;ValidateRetention();return id;}
    public void Acknowledge(ulong id)
    {if(id<acknowledged||id>=next)throw new InvalidDataException("Invalid event acknowledgement.");acknowledged=Math.Max(acknowledged,id+1);ValidateRetention();}

    private void ValidateRetention()
    {
        if (next == 1 || acknowledged == next) return;
        ReliableEventRetentionPolicy.Validate(acknowledged == 0 ? 1 : acknowledged, next - 1,
            acknowledged == 0 ? 0 : acknowledged - 1, (ulong)capacity);
    }
}
