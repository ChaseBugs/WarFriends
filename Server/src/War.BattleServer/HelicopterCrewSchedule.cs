namespace War.BattleServer;

// Recovered Helicopter.DeployEnemies: one five-second wait, then one
// two-second wait after each ordered EnemyPointHelicopter slot.
internal sealed class HelicopterCrewSchedule
{
    private readonly ulong stopTick;
    private readonly int seats;
    internal HelicopterCrewSchedule(ulong stopTick,int seats)
    {
        if(stopTick==0||seats is <1 or >6||
           stopTick>ulong.MaxValue-(ulong)(150+60*(seats-1)))
            throw new InvalidDataException("Invalid source Helicopter crew schedule.");
        this.stopTick=stopTick;this.seats=seats;
    }
    internal ulong DueTick(int slot)
    {
        if(slot<0||slot>=seats)throw new ArgumentOutOfRangeException(nameof(slot));
        return stopTick+(ulong)(150+60*slot);
    }
    internal IReadOnlyList<int> DueSlots(ulong tick)
    {
        if(tick<stopTick)return Array.Empty<int>();
        return Enumerable.Range(0,seats).Where(i=>DueTick(i)<=tick).ToArray();
    }
    internal uint DueMask(ulong tick)
    {
        uint mask=0;
        for(int slot=0;slot<seats&&DueTick(slot)<=tick;slot++)mask|=1u<<slot;
        return mask;
    }
}
