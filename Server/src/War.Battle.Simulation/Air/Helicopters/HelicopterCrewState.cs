namespace War.BattleServer;

internal sealed record HelicopterCrewMemberSnapshot(int Slot,int PointComponentFileId,
    float Health,float Maximum,ulong SpawnTick,ulong DropStartTick)
{
    internal bool IsAttached { get; init; } = true;
}
internal sealed record HelicopterCrewDescentSnapshot(int Slot,ulong StartTick,float Progress,
    bool AnimationComplete);

// Source crew begins attached to the Helicopter. The host actor ledger publishes
// health here; animation progress alone does not establish collisions or landing.
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

    internal void PublishActorHealth(int slot, float health)
    {
        if (slot < 0 || slot >= members.Length || !float.IsFinite(health) ||
            health < 0 || health > members[slot].Health)
        {
            throw new InvalidDataException("Crew health publication must preserve its source slot and decrease only.");
        }

        members[slot] = members[slot] with { Health = health };
    }

    internal void PublishSeatRelease(int slot)
    {
        if (slot < 0 || slot >= members.Length || members[slot].Health <= 0 || !members[slot].IsAttached)
        {
            throw new InvalidDataException("Only a living attached crew member can release its seat.");
        }

        members[slot] = members[slot] with { IsAttached = false };
    }

    internal IReadOnlyList<HelicopterCrewDescentSnapshot> DescentSnapshot(ulong tick)
    {
        var result=new List<HelicopterCrewDescentSnapshot>(members.Length);
        foreach(var member in members)
        {
            if (!member.IsAttached || member.Health <= 0 || member.DropStartTick == 0 || tick < member.DropStartTick)
            {
                continue;
            }
            ulong elapsed=tick-member.DropStartTick;
            // EnemyController.HelicopterUpdate accumulates deltaTime and clamps at one.
            // The host's fixed 30 Hz clock describes animation only, not NavMesh landing.
            float progress = HelicopterDescentProgress.AtFixedTicks(elapsed);
            result.Add(new(member.Slot,member.DropStartTick,progress,progress>=1f));
        }
        return result.AsReadOnly();
    }
    internal void Advance(HelicopterCrewSchedule schedule, ulong tick)
    {
        ArgumentNullException.ThrowIfNull(schedule);
        for (int slot = 0; slot < members.Length; slot++)
        {
            ulong due = schedule.DueTick(slot);
            HelicopterCrewMemberSnapshot member = members[slot];
            if (tick >= due && member.DropStartTick == 0 && member.IsAttached && member.Health > 0)
            {
                members[slot] = member with { DropStartTick = due };
            }
        }
    }
}
