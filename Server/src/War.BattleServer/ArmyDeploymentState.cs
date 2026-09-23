namespace War.BattleServer;

public sealed record ArmySpawn(int EntityId,int OptionIndex,string UnitId,int Power,ulong Tick,bool IsAir);

/// <summary>Single-writer, host-owned deployment eligibility and 0.3-second spawn schedule.</summary>
public sealed class ArmyDeploymentState
{
    private readonly ArmyDeploymentCatalog catalog;
    private readonly HashSet<string> equipped;
    private readonly HashSet<string> newlyAcquired;
    private bool firstHand=true;
    private readonly HashSet<int> offered=[];
    private int[] hand=[];
    private readonly Dictionary<string,int> alive=new(StringComparer.Ordinal);
    private readonly Dictionary<string,int> reserved=new(StringComparer.Ordinal);
    private readonly Queue<(ulong Tick,ArmyDeploymentFamily Family,ArmyDeploymentOption Option)> pending=[];
    private readonly Dictionary<int,ArmySpawn> entities=[];
    private int nextEntityId;
    private float cooldownMultiplier=1;
    public int Energy { get; private set; }
    public ulong NextDeployTick { get; private set; }
    public int ActiveCount=>entities.Count;
    public int PendingCount=>pending.Count;
    internal int PendingRouteDemand(string collection)
        =>pending.Count(item=>!item.Family.IsSoldier && item.Family.BehaviorType!="MechBehaviour" &&
            ArmySpawnPointSelector.Collection(item.Family.BehaviorType)==collection);
    internal int PendingRusherDemand
        =>pending.Count(item=>ArmyRusherPointCatalog.IsRusher(item.Family.BehaviorType));
    public IReadOnlyList<int> OfferedOptions=>Array.AsReadOnly(hand);

    public ArmyDeploymentState(ArmyDeploymentCatalog catalog,IEnumerable<string> equippedUnitIds,
        IEnumerable<string>? newUnitIds=null)
    {
        this.catalog=catalog??throw new ArgumentNullException(nameof(catalog));
        equipped=new HashSet<string>(equippedUnitIds??throw new ArgumentNullException(nameof(equippedUnitIds)),StringComparer.Ordinal);
        if(equipped.Count==0 || equipped.Count>catalog.Families.Count ||
           equipped.Any(id=>!catalog.Families.Any(f=>f.UnitId==id)))
            throw new InvalidDataException("Deployment requires a trusted equipped source unit set.");
        newlyAcquired=new HashSet<string>(newUnitIds??[],StringComparer.Ordinal);
        if(newlyAcquired.Any(id=>!equipped.Contains(id)))
            throw new InvalidDataException("New army units must be a trusted equipped subset.");
        Energy=checked((int)catalog.MaxEnergy);
    }

    // The server's offer generator calls this. A packet cannot install or widen offers.
    public IReadOnlyList<int> GenerateOffers(Func<int,int> choose)
        =>GenerateOffers(choose,(_,_)=>true);

    public IReadOnlyList<int> GenerateOffers(Func<int,int> choose,Func<ArmyDeploymentFamily,bool> canPlace)
        =>GenerateOffers(choose,(family,_)=>canPlace(family));

    public IReadOnlyList<int> GenerateOffers(Func<int,int> choose,
        Func<ArmyDeploymentFamily,ArmyDeploymentOption,bool> canPlace)
    {
        ArgumentNullException.ThrowIfNull(choose);
        ArgumentNullException.ThrowIfNull(canPlace);
        var eligible=catalog.Families.Where(f=>equipped.Contains(f.UnitId))
            .SelectMany(f=>f.Options.Where(o=>HasCapacity(f,o.Count) && canPlace(f,o))
                .Select(o=>(Family:f,Option:o))).ToList();
        var candidates=eligible.Select(x=>x.Option.Index).ToList();
        var first=firstHand;
        firstHand=false;
        if(candidates.Count==0)
        {
            offered.Clear();hand=[];
            return [];
        }
        // Classic source path: one randomly chosen option per UnitType, then
        // three distinct type picks when exactly three/four types are present.
        var byType=eligible.GroupBy(x=>x.Family.UnitType).ToArray();
        if(byType.Length is 3 or 4)
        {
            var typeOptions=new List<int>(byType.Length);
            foreach(var group in byType)
            {
                var entries=group.ToArray();
                int index=Choose(choose,entries.Length);
                typeOptions.Add(entries[index].Option.Index);
            }
            if(typeOptions.Count==4)typeOptions.RemoveAt(Choose(choose,4));
            candidates=typeOptions;
        }
        var selected=new List<int>(3);
        while(selected.Count<3 && candidates.Count>0)
        {
            int pick=Choose(choose,candidates.Count);
            selected.Add(candidates[pick]);candidates.RemoveAt(pick);
        }
        while(selected.Count<3)selected.Add(selected[^1]);
        if(first)
        {
            var priority=eligible.LastOrDefault(x=>newlyAcquired.Contains(x.Family.UnitId));
            if(priority.Family!=null)
            {
                int replacement=selected.FindIndex(x=>FindFamily(x).UnitId==priority.Family.UnitId);
                if(replacement<0)replacement=selected.FindIndex(x=>FindFamily(x).UnitType==priority.Family.UnitType);
                if(replacement<0)replacement=0;
                // The source replaces every already-selected option of the same
                // behavior; otherwise it replaces the first matching type/slot.
                if(selected.Any(x=>FindFamily(x).UnitId==priority.Family.UnitId))
                {
                    for(int i=0;i<selected.Count;i++)
                        if(FindFamily(selected[i]).UnitId==priority.Family.UnitId)
                            selected[i]=priority.Option.Index;
                }
                else selected[replacement]=priority.Option.Index;
            }
        }
        SetOffers(selected);
        return selected.AsReadOnly();
    }

    private static int Choose(Func<int,int> choose,int count)
    {
        int value=choose(count);
        if(value<0 || value>=count)throw new InvalidDataException("Invalid host army random choice.");
        return value;
    }

    public void SetOffers(IEnumerable<int> sourceOptionIndexes)
    {
        var indexes=sourceOptionIndexes?.ToArray()??throw new ArgumentNullException(nameof(sourceOptionIndexes));
        if(indexes.Length!=3)
            throw new InvalidDataException("A recovered army hand contains three options.");
        foreach(int index in indexes)
        {
            var family=FindFamily(index);
            if(!equipped.Contains(family.UnitId))throw new InvalidDataException("Army offer is not equipped.");
            var option=catalog.Option(index);
            if(!HasCapacity(family,option.Count))throw new InvalidDataException("Army offer exceeds source capacity.");
        }
        offered.Clear();foreach(int index in indexes)offered.Add(index);
        hand=indexes;
    }

    /// <summary>Discard a hand whose scene route is no longer available.</summary>
    public void InvalidateOffers()
    {
        offered.Clear();
        hand=[];
    }

    public bool CanStillOffer(int optionIndex)
    {
        if(!offered.Contains(optionIndex))return false;
        var family=FindFamily(optionIndex);
        return equipped.Contains(family.UnitId) && HasCapacity(family,catalog.Option(optionIndex).Count);
    }

    public void SetCooldownMultiplier(float value)
    {
        if(!float.IsFinite(value) || value is <=0 or >10)
            throw new InvalidDataException("Invalid host-owned army cooldown modifier.");
        cooldownMultiplier=value;
    }

    public string TryDeploy(int optionIndex,ulong tick)
    {
        if(!offered.Contains(optionIndex))return "army-not-offered";
        var family=FindFamily(optionIndex);
        var option=catalog.Option(optionIndex);
        if(!equipped.Contains(family.UnitId))return "army-not-equipped";
        if(tick<NextDeployTick)return "army-cooldown";
        if(!HasCapacity(family,option.Count))return "army-capacity";
        int pendingPower=pending.Sum(p=>p.Option.Power/p.Option.Count);
        if(option.Power>Energy-pendingPower)return "army-energy";
        ulong cooldown=Ticks((catalog.BaseCooldown+option.Cooldown)*cooldownMultiplier);
        // The first unit is due now; subsequent units follow at 0.3-second intervals.
        for(int i=0;i<option.Count;i++)
            pending.Enqueue((checked(tick+(ulong)(i*9)),family,option));
        reserved[family.UnitId]=reserved.GetValueOrDefault(family.UnitId)+option.Count;
        NextDeployTick=checked(tick+cooldown);
        InvalidateOffers();
        return "army-deploying";
    }

    public IReadOnlyList<ArmySpawn> Advance(ulong tick)
    {
        var spawned=new List<ArmySpawn>();
        while(pending.Count>0 && pending.Peek().Tick<=tick)
        {
            var scheduled=pending.Dequeue();
            int unitPower=scheduled.Option.Power/scheduled.Option.Count;
            if(unitPower>Energy)throw new InvalidDataException("Reserved army energy was lost.");
            Energy-=unitPower;
            reserved[scheduled.Family.UnitId]--;
            alive[scheduled.Family.UnitId]=alive.GetValueOrDefault(scheduled.Family.UnitId)+1;
            if(nextEntityId==int.MaxValue)throw new InvalidDataException("Army entity ID exhausted.");
            var entity=new ArmySpawn(++nextEntityId,scheduled.Option.Index,scheduled.Family.UnitId,unitPower,scheduled.Tick,scheduled.Family.IsAir);
            entities.Add(entity.EntityId,entity);spawned.Add(entity);
        }
        return spawned;
    }

    public ArmySpawn? RemoveEntity(int entityId)
    {
        if(!entities.Remove(entityId,out var entity))return null;
        alive[entity.UnitId]--;
        return entity;
    }

    public ArmySpawn? Entity(int entityId)=>entities.GetValueOrDefault(entityId);

    public void CreditKillEnergy(int power)
    {
        if(power is <1 or >1000)throw new InvalidDataException("Invalid confirmed unit kill power.");
        Energy=Math.Min(checked((int)catalog.MaxEnergy*2),checked(Energy+power));
    }

    private bool HasCapacity(ArmyDeploymentFamily family,int count)
        =>family.MaxGeneratedCount==0 ||
          count+alive.GetValueOrDefault(family.UnitId)+reserved.GetValueOrDefault(family.UnitId)<=family.MaxGeneratedCount;
    private ArmyDeploymentFamily FindFamily(int optionIndex)
        =>catalog.Families.FirstOrDefault(f=>f.Options.Any(o=>o.Index==optionIndex))
           ??throw new ArgumentOutOfRangeException(nameof(optionIndex));
    private static ulong Ticks(float seconds)
        =>checked((ulong)Math.Ceiling(seconds*MatchManifest.TickRate));
}
