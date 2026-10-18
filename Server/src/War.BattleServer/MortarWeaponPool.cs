namespace War.BattleServer;

/// <summary>Preserves source allocation order while retaining each weapon through its owner's corpse lifetime.</summary>
internal sealed class MortarWeaponPool
{
    private const int MaximumCapacity = 256;
    private const ulong MaximumTick = 10000000;
    private readonly LinkedList<int> _freeSlots = new();
    private readonly Dictionary<ulong, int> _actorSlots = [];
    private readonly Dictionary<ulong, CorpseReturn> _corpseReturns = [];

    internal int Capacity { get; }

    internal int OccupiedCount => _actorSlots.Count;

    internal int PendingCorpseCount => _corpseReturns.Count;

    internal MortarWeaponPool(int capacity)
    {
        // EnemyBasicInventory's recovered attachment contract carries pool indices in a byte array.
        if (capacity < 1 || capacity > MaximumCapacity)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }
        Capacity = capacity;
        for (int index = 0; index < capacity; index++)
        {
            _freeSlots.AddLast(index);
        }
    }

    internal bool TryAllocateForMaster(ulong actorKey, out int slot)
    {
        return TryAllocate(actorKey, _freeSlots.First, out slot);
    }

    internal bool TryAllocateForPeer(ulong actorKey, out int slot)
    {
        return TryAllocate(actorKey, _freeSlots.Last, out slot);
    }

    private bool TryAllocate(ulong actorKey, LinkedListNode<int>? candidate, out int slot)
    {
        ValidateActorKey(actorKey);
        if (_actorSlots.ContainsKey(actorKey))
        {
            throw new InvalidDataException("A Mortar actor already owns its source weapon slot.");
        }
        if (candidate == null)
        {
            slot = -1;
            return false;
        }
        slot = candidate.Value;
        _freeSlots.Remove(candidate);
        _actorSlots.Add(actorKey, slot);
        return true;
    }

    internal bool Release(ulong actorKey)
    {
        ValidateActorKey(actorKey);
        if (!_actorSlots.Remove(actorKey, out int slot))
        {
            return false;
        }
        if (_corpseReturns.Remove(actorKey, out CorpseReturn? corpse))
        {
            corpse.Clock.ForceReturn();
        }
        // ObjectPool.FreeObject puts the released index at the front even when a peer released it.
        _freeSlots.AddFirst(slot);
        return true;
    }

    internal void BeginCorpseReturn(ulong actorKey, ulong deathTick, float hideDelaySeconds)
    {
        ValidateActorKey(actorKey);
        if (deathTick > MaximumTick || !_actorSlots.ContainsKey(actorKey) || _corpseReturns.ContainsKey(actorKey))
        {
            throw new InvalidDataException("A corpse return requires one current weapon owner and death frame.");
        }
        // OnKilled frees the army count, but this weapon remains owned until DestroyPooled.
        var clock = new MortarCorpseReturnClock(hideDelaySeconds);
        _corpseReturns.Add(actorKey, new CorpseReturn(deathTick, clock));
    }

    internal MortarCorpseReturnClock.Transition AdvanceCorpseReturn(ulong actorKey, ulong tick, float deltaSeconds)
    {
        ValidateActorKey(actorKey);
        if (!float.IsFinite(deltaSeconds) || deltaSeconds < 0f)
        {
            throw new ArgumentOutOfRangeException(nameof(deltaSeconds));
        }
        if (tick > MaximumTick)
        {
            throw new ArgumentOutOfRangeException(nameof(tick));
        }
        if (!_corpseReturns.TryGetValue(actorKey, out CorpseReturn? corpse))
        {
            return MortarCorpseReturnClock.Transition.None;
        }
        if (tick == corpse.DeathTick && corpse.LastAdvanceTick == corpse.DeathTick)
        {
            return MortarCorpseReturnClock.Transition.None;
        }
        if (tick != corpse.LastAdvanceTick + 1)
        {
            throw new InvalidDataException("Advance each retained corpse once per completed simulation frame.");
        }
        MortarCorpseReturnClock.Transition transition = corpse.Clock.Advance(deltaSeconds);
        corpse.LastAdvanceTick = tick;
        if (transition == MortarCorpseReturnClock.Transition.Returned && !Release(actorKey))
        {
            throw new InvalidDataException("A completed corpse return lost its weapon ownership.");
        }
        return transition;
    }

    internal int? SlotFor(ulong actorKey)
    {
        return _actorSlots.TryGetValue(actorKey, out int slot) ? slot : null;
    }

    internal int[] FreeSlots()
    {
        return _freeSlots.ToArray();
    }

    internal void Clear()
    {
        foreach (CorpseReturn corpse in _corpseReturns.Values)
        {
            corpse.Clock.ForceReturn();
        }
        _corpseReturns.Clear();
        _actorSlots.Clear();
        _freeSlots.Clear();
        for (int index = 0; index < Capacity; index++)
        {
            _freeSlots.AddLast(index);
        }
    }

    private static void ValidateActorKey(ulong actorKey)
    {
        if (actorKey == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(actorKey));
        }
    }

    private sealed class CorpseReturn
    {
        internal ulong DeathTick { get; }

        internal ulong LastAdvanceTick { get; set; }

        internal MortarCorpseReturnClock Clock { get; }

        internal CorpseReturn(ulong deathTick, MortarCorpseReturnClock clock)
        {
            DeathTick = deathTick;
            LastAdvanceTick = deathTick;
            Clock = clock;
        }
    }
}
