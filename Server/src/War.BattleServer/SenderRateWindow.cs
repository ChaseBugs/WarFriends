namespace War.BattleServer;

public sealed class SenderRateWindow
{
    private readonly int limit;
    private readonly ulong windowTicks;
    private ulong start;
    private int count;
    public SenderRateWindow(int limit=256,ulong windowTicks=30)
    {if(limit<1||limit>100000||windowTicks<1||windowTicks>3600)throw new InvalidDataException("Invalid sender rate window.");this.limit=limit;this.windowTicks=windowTicks;}
    public bool Allow(ulong tick)
    {if(tick<start)throw new InvalidDataException("Sender tick moved backwards.");if(tick-start>=windowTicks){start=tick;count=0;}if(count>=limit)return false;count++;return true;}
}
