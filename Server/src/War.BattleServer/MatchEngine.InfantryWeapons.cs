using War.Protocol;
using War.Shared;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const ulong GrenadierWeaponReturnTicks = 15;
    private readonly HashSet<ulong> _grenadierSecondaryWeapons = [];
    private readonly List<PendingGrenadierWeaponReturn> _grenadierWeaponReturns = [];

    private uint InfantryWeaponMask(BattleArmyEntityState entity)
    {
        if (entity.SourceCardId.Length == 0 || entity.SourceCardId == "HEAVYDRONE")
        {
            return 0;
        }

        return _grenadierSecondaryWeapons.Contains(entity.EntityKey) ?
            InfantryWeaponVisibility.SecondaryMask : InfantryWeaponVisibility.PrimaryMask;
    }

    private void AdvanceGrenadierWeaponReturns()
    {
        PendingGrenadierWeaponReturn[] due = _grenadierWeaponReturns.Where(callback => callback.DueTick <= tick)
            .OrderBy(callback => callback.DueTick).ThenBy(callback => callback.EntityKey).ToArray();
        foreach (PendingGrenadierWeaponReturn callback in due)
        {
            if (!activeArmyEntities.TryGetValue(callback.EntityKey, out BattleArmyEntityState? actor) ||
                actor.SourceCardId != "GREATGRENADIER")
            {
                throw new InvalidDataException("Grenadier weapon callback lost its live card actor.");
            }

            _grenadierSecondaryWeapons.Remove(callback.EntityKey);
            _grenadierWeaponReturns.Remove(callback);
        }
    }

    private void RemoveGrenadierWeaponVisibility(ulong entityKey)
    {
        _grenadierSecondaryWeapons.Remove(entityKey);
        _grenadierWeaponReturns.RemoveAll(callback => callback.EntityKey == entityKey);
    }

    private sealed record PendingGrenadierWeaponReturn(ulong EntityKey, ulong DueTick);
}
