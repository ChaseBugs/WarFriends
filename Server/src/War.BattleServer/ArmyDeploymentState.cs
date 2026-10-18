namespace War.BattleServer;

/// <summary>Records a realized unit and its deployment scheduling-clock tick.</summary>
public sealed record ArmySpawn(int EntityId,int OptionIndex,string UnitId,int Power,ulong Tick,bool IsAir);

/// <summary>Single-writer, host-owned deployment eligibility and 0.3-second spawn schedule.</summary>
public sealed class ArmyDeploymentState
{
    private const int SpawnIntervalTicks = 9;
    private readonly Dictionary<ulong, ArmyDeploymentWave> _activeWaves = [];
    private readonly Dictionary<int, ArmyDeploymentWave> _entityWaves = [];
    private ulong _nextWaveId;
    private IReadOnlyList<ArmyDeploymentWave> _completedWaves = Array.Empty<ArmyDeploymentWave>();

    private readonly ArmyDeploymentCatalog catalog;
    private readonly HashSet<string> equipped;
    private readonly HashSet<string> newlyAcquired;
    private bool firstHand=true;
    private readonly HashSet<int> offered=[];
    private int[] hand=[];
    private readonly Dictionary<string,int> alive=new(StringComparer.Ordinal);
    private readonly Dictionary<string,int> reserved=new(StringComparer.Ordinal);
    private readonly Queue<(ulong Tick, ArmyDeploymentFamily Family, ArmyDeploymentOption Option, ulong WaveId)>
        pending = [];
    private readonly Dictionary<int,ArmySpawn> entities=[];
    private int nextEntityId;
    private float cooldownMultiplier=1;
    public int Energy { get; private set; }
    /// <summary>Gets the next eligible tick in the pause-excluding cooldown clock.</summary>
    public ulong NextDeployTick { get; private set; }
    public int ActiveCount=>entities.Count;
    public int PendingCount=>pending.Count;
    internal int PendingRouteDemand(string collection)
        =>pending.Count(item=>!item.Family.IsSoldier && item.Family.BehaviorType!="MechBehaviour" &&
            ArmySpawnPointSelector.Collection(item.Family.BehaviorType)==collection);
    internal int PendingRusherDemand
        =>pending.Count(item=>ArmyRusherPointCatalog.IsRusher(item.Family.BehaviorType));
    public IReadOnlyList<int> OfferedOptions=>Array.AsReadOnly(hand);

    /// <summary>The most recently accepted deployment; rejected commands do not replace it.</summary>
    public ArmyDeploymentWave? LastAcceptedWave { get; private set; }

    /// <summary>Deployments whose final source wait completed during the latest advance.</summary>
    public IReadOnlyList<ArmyDeploymentWave> CompletedWaves => _completedWaves;

    /// <summary>Accepted deployments still spawning or waiting after their final unit.</summary>
    public IReadOnlyList<ArmyDeploymentWave> ActiveWaves =>
        Array.AsReadOnly(_activeWaves.Values.OrderBy(wave => wave.Id).ToArray());

    /// <summary>Retains the original deployment identity while its spawned entity remains alive.</summary>
    public ArmyDeploymentWave? WaveOf(int entityId) => _entityWaves.GetValueOrDefault(entityId);

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
        firstHand=false;
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

    /// <summary>Deploys using the existing shared-tick projection for both clock domains.</summary>
    public string TryDeploy(int optionIndex, ulong tick)
    {
        return TryDeploy(optionIndex, tick, tick);
    }

    /// <summary>Checks the pause-excluding cooldown clock while scheduling on the independent real-time clock.</summary>
    internal string TryDeploy(int optionIndex, ulong cooldownTick, ulong spawnTick)
    {
        if (cooldownTick > spawnTick)
        {
            throw new InvalidDataException("Deployment clocks must share an epoch and preserve elapsed-time order.");
        }
        if (!offered.Contains(optionIndex))
        {
            return "army-not-offered";
        }
        ArmyDeploymentFamily family = FindFamily(optionIndex);
        ArmyDeploymentOption option = catalog.Option(optionIndex);
        string? rejection = GetDeploymentRejection(family, option, cooldownTick);
        if (rejection != null)
        {
            return rejection;
        }
        ScheduleWave(family, option, cooldownTick, spawnTick);
        return "army-deploying";
    }

    private string? GetDeploymentRejection(ArmyDeploymentFamily family, ArmyDeploymentOption option, ulong cooldownTick)
    {
        if (!equipped.Contains(family.UnitId))
        {
            return "army-not-equipped";
        }
        if (cooldownTick < NextDeployTick)
        {
            return "army-cooldown";
        }
        if (!HasCapacity(family, option.Count))
        {
            return "army-capacity";
        }
        int pendingPower = checked(pending.Sum(entry => entry.Option.Power / entry.Option.Count));
        if (option.Power > Energy - pendingPower)
        {
            return "army-energy";
        }
        return null;
    }

    private void ScheduleWave(ArmyDeploymentFamily family, ArmyDeploymentOption option,
        ulong cooldownTick, ulong spawnTick)
    {
        ulong cooldown = Ticks((catalog.BaseCooldown + option.Cooldown) * cooldownMultiplier);
        ulong[] due = Enumerable.Range(0, option.Count)
            .Select(index => checked(spawnTick + (ulong)(index * SpawnIntervalTicks))).ToArray();
        ulong nextDeploy = checked(cooldownTick + cooldown);
        int nextReserved = checked(reserved.GetValueOrDefault(family.UnitId) + option.Count);
        ulong waveId = checked(_nextWaveId + 1);
        var wave = new ArmyDeploymentWave(waveId, option.Index, family.UnitId, spawnTick)
        {
            FinishAfterTick = checked(due[^1] + SpawnIntervalTicks),
            IsSoldier = family.IsSoldier
        };
        QueueWave(family, option, wave, due);
        _activeWaves.Add(waveId, wave);
        _nextWaveId = waveId;
        LastAcceptedWave = wave;
        reserved[family.UnitId] = nextReserved;
        NextDeployTick = nextDeploy;
        InvalidateOffers();
    }

    private void QueueWave(ArmyDeploymentFamily family, ArmyDeploymentOption option,
        ArmyDeploymentWave wave, IEnumerable<ulong> due)
    {
        foreach (ulong dueTick in due)
        {
            pending.Enqueue((dueTick, family, option, wave.Id));
        }
        // Source coroutines can overlap after cooldown modifiers; a later wave cannot wait behind future units.
        var ordered = pending.OrderBy(spawn => spawn.Tick).ThenBy(spawn => spawn.WaveId).ToArray();
        pending.Clear();
        foreach (var spawn in ordered)
        {
            pending.Enqueue(spawn);
        }
    }

    /// <summary>Validates due spawns without consuming energy, reservations or entity identities.</summary>
    internal IReadOnlyList<ArmySpawn> PreviewDueSpawns(ulong tick)
    {
        int remainingEnergy = Energy;
        int previewId = nextEntityId;
        var previewReserved = new Dictionary<string, int>(reserved, StringComparer.Ordinal);
        var previewAlive = new Dictionary<string, int>(alive, StringComparer.Ordinal);
        var preview = new List<ArmySpawn>();
        foreach (var scheduled in pending.TakeWhile(entry => entry.Tick <= tick))
        {
            if (scheduled.Option.Count <= 0 || scheduled.Option.Power <= 0 ||
                scheduled.Option.Power % scheduled.Option.Count != 0 ||
                !equipped.Contains(scheduled.Family.UnitId))
            {
                throw new InvalidDataException("Invalid pending army spawn authority.");
            }
            int unitPower = scheduled.Option.Power / scheduled.Option.Count;
            if (unitPower > remainingEnergy)
            {
                throw new InvalidDataException("Reserved army energy was lost.");
            }
            remainingEnergy -= unitPower;
            int count = previewReserved.GetValueOrDefault(scheduled.Family.UnitId);
            if (count <= 0)
            {
                throw new InvalidDataException("Reserved army spawn count was lost.");
            }
            previewReserved[scheduled.Family.UnitId] = count - 1;
            previewAlive[scheduled.Family.UnitId] = checked(previewAlive.GetValueOrDefault(scheduled.Family.UnitId) + 1);
            if (previewId >= CardUnitEntityRegistry.FirstLocalEntityId - 1)
            {
                throw new InvalidDataException("Army entity ID entered the card-unit range.");
            }
            if (entities.ContainsKey(++previewId))
            {
                throw new InvalidDataException("Army entity ID already exists.");
            }
            preview.Add(new ArmySpawn(previewId, scheduled.Option.Index, scheduled.Family.UnitId,
                unitPower, scheduled.Tick, scheduled.Family.IsAir));
        }
        return preview.AsReadOnly();
    }

    /// <summary>Realizes due units and completed waves using deployment scheduling-clock time.</summary>
    public IReadOnlyList<ArmySpawn> Advance(ulong tick)
    {
        // Keep the same authority checks available to shared resource preflight before either player commits.
        _ = PreviewDueSpawns(tick);
        var due = pending.TakeWhile(entry => entry.Tick <= tick).ToArray();
        var spawned=new List<ArmySpawn>();
        foreach(var expected in due)
        {
            var scheduled=pending.Dequeue();
            if(scheduled!=expected)throw new InvalidDataException("Army spawn queue changed during host tick.");
            int unitPower=scheduled.Option.Power/scheduled.Option.Count;
            Energy-=unitPower;
            reserved[scheduled.Family.UnitId]--;
            alive[scheduled.Family.UnitId]=alive.GetValueOrDefault(scheduled.Family.UnitId)+1;
            var entity=new ArmySpawn(++nextEntityId,scheduled.Option.Index,scheduled.Family.UnitId,unitPower,scheduled.Tick,scheduled.Family.IsAir);
            entities.Add(entity.EntityId,entity);spawned.Add(entity);
            _entityWaves.Add(entity.EntityId, _activeWaves[scheduled.WaveId]);
        }
        // SpawningManagerDeathMatch waits once after every unit, including the final unit.
        var completed = _activeWaves.Values.Where(wave => wave.FinishAfterTick < tick)
            .OrderBy(wave => wave.FinishAfterTick).ThenBy(wave => wave.Id).ToArray();
        foreach (ArmyDeploymentWave wave in completed)
        {
            _activeWaves.Remove(wave.Id);
        }
        _completedWaves = Array.AsReadOnly(completed);
        return spawned;
    }

    public ArmySpawn? RemoveEntity(int entityId)
    {
        if(!entities.Remove(entityId,out var entity))return null;
        _entityWaves.Remove(entityId);
        alive[entity.UnitId]--;
        return entity;
    }

    public ArmySpawn? Entity(int entityId)=>entities.GetValueOrDefault(entityId);

    public void CreditKillEnergy(int power)
        =>Energy=PreviewKillEnergy(power);

    // Validate the complete reward arithmetic before a host death removes its
    // entity and reservation. The death path is single-writer.
    internal int PreviewKillEnergy(int power)
    {
        if(power is <1 or >1000)throw new InvalidDataException("Invalid confirmed unit kill power.");
        if(Energy<0)throw new InvalidDataException("Invalid army energy before kill credit.");
        return Math.Min(checked((int)catalog.MaxEnergy*2),checked(Energy+power));
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
