namespace War.BattleServer;

internal sealed record HelicopterCrewMemberSnapshot(int Slot,int PointComponentFileId,
    float Health,float Maximum,ulong SpawnTick,ulong DropStartTick);

// Source crew begins attached to the Helicopter. No collision, death or
// landing authority is inferred before runtime world poses are implemented.
internal sealed class HelicopterCrewState
{
    private readonly HelicopterCrewMemberSnapshot[] members;
    internal HelicopterCrewState(ArmyHelicopterCrewStats stats,HelicopterCrewPointCatalog points,ulong spawnTick)
    {
        ArgumentNullException.ThrowIfNull(stats);
        ArgumentNullException.ThrowIfNull(points);
        if(stats.Seats is <1 or >6||points.Slots.Count!=6||
           !float.IsFinite(stats.SoldierHealth)||stats.SoldierHealth<=0||
           stats.SoldierHealth>10_000_000||spawnTick==0)
            throw new InvalidDataException("Invalid attached Helicopter crew authority.");
        members=Enumerable.Range(0,stats.Seats).Select(slot=>new HelicopterCrewMemberSnapshot(
            slot,points.Slots[slot].ComponentFileId,stats.SoldierHealth,stats.SoldierHealth,
            spawnTick,0)).ToArray();
    }
    internal IReadOnlyList<HelicopterCrewMemberSnapshot> Snapshot()
        =>Array.AsReadOnly(members.ToArray());
    internal void Advance(HelicopterCrewSchedule schedule,ulong tick)
    {
        ArgumentNullException.ThrowIfNull(schedule);
        for(int slot=0;slot<members.Length;slot++)
        {
            ulong due=schedule.DueTick(slot);
            if(tick>=due&&members[slot].DropStartTick==0)
                members[slot]=members[slot] with{DropStartTick=due};
        }
    }
}
