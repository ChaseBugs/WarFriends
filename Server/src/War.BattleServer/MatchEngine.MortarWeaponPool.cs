namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const string MortarUnitId = "ID_UNIT-MORTAR";
    private const float MinimumCorpseHideSeconds = 2f;
    private const float CorpseHideRangeSeconds = 1f;
    private MortarWeaponPool? _mortarWeaponPool;

    internal int RetainedMortarWeaponCount => _mortarWeaponPool?.OccupiedCount ?? 0;

    internal int RetainedMortarCorpseCount => _mortarWeaponPool?.PendingCorpseCount ?? 0;

    internal int? RetainedMortarWeaponSlot(ulong actorKey) => _mortarWeaponPool?.SlotFor(actorKey);

    private void PreflightMortarWeaponSlots(IEnumerable<(Player Owner, ArmySpawn Spawn)> candidates)
    {
        var pool = _mortarWeaponPool ?? throw new InvalidDataException("Mortar weapon pool is not bound.");
        int required = 0;
        foreach (var candidate in candidates.Where(candidate => candidate.Spawn.UnitId == MortarUnitId))
        {
            ulong actorKey = ((ulong)candidate.Owner.Definition.Fraction << 32) | (uint)candidate.Spawn.EntityId;
            if (pool.SlotFor(actorKey).HasValue)
            {
                throw new InvalidDataException("A new Mortar already owns a physical weapon slot.");
            }
            required++;
        }
        if (required > pool.Capacity - pool.OccupiedCount)
        {
            // Source attachment dereferences an exhausted pool. Fail before either owner
            // spends energy instead of inventing another slot or a retry coroutine.
            throw new InvalidDataException("Retained Mortar bodies exhausted the source weapon pool.");
        }
    }

    private void AllocateMortarWeapon(Player owner, ArmySpawn spawned, ulong actorKey)
    {
        if (spawned.UnitId != MortarUnitId)
        {
            return;
        }
        var pool = _mortarWeaponPool ?? throw new InvalidDataException("Mortar weapon pool is not bound.");
        int slot;
        bool allocated = owner.Definition.PlayerId == manifest.SceneMasterPlayerId
            ? pool.TryAllocateForMaster(actorKey, out slot)
            : pool.TryAllocateForPeer(actorKey, out slot);
        if (!allocated)
        {
            throw new InvalidDataException("Mortar weapon admission changed after shared preflight.");
        }
        BindMortarIndicatorSlot(slot, actorKey);
    }

    private float? PrepareMortarCorpseDelay(ulong actorKey, string unitId)
    {
        if (unitId != MortarUnitId)
        {
            return null;
        }
        if (_mortarWeaponPool?.SlotFor(actorKey) == null)
        {
            throw new InvalidDataException("Mortar death lost its retained physical weapon.");
        }
        float draw = combatRandom();
        if (!float.IsFinite(draw) || draw is < 0f or > 1f)
        {
            throw new InvalidDataException("Mortar corpse delay requires a bounded host random draw.");
        }
        return MinimumCorpseHideSeconds + draw * CorpseHideRangeSeconds;
    }

    private void AdvanceMortarCorpseReturns()
    {
        if (_mortarWeaponPool == null)
        {
            return;
        }
        const float ScaledFrameSeconds = 1f / MatchManifest.TickRate;
        foreach (ulong actorKey in _mortarWeaponPool.CorpseActors())
        {
            _mortarWeaponPool.AdvanceCorpseReturn(actorKey, tick, ScaledFrameSeconds);
        }
    }
}
