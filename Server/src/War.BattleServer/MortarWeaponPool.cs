namespace War.BattleServer;

/// <summary>Preserves source front/back allocation and front insertion while binding each slot to one live actor.</summary>
internal sealed class MortarWeaponPool
{
    private const int MaximumCapacity = 256;
    private readonly LinkedList<int> _freeSlots = new();
    private readonly Dictionary<ulong, int> _actorSlots = [];

    internal int Capacity { get; }

    internal int ActiveCount => _actorSlots.Count;

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
        // ObjectPool.FreeObject puts the released index at the front even when a peer released it.
        _freeSlots.AddFirst(slot);
        return true;
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
}
