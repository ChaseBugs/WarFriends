using War.Protocol;
using War.Shared;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly GrenadierWeaponState _grenadierWeapons = new();

    private uint InfantryWeaponMask(BattleArmyEntityState entity)
    {
        if ((entity.SourceCardId.Length == 0 && !IsGrenadier(entity)) || entity.SourceCardId == "HEAVYDRONE")
        {
            return 0;
        }

        return _grenadierWeapons.IsSecondary(entity.EntityKey) ?
            InfantryWeaponVisibility.SecondaryMask : InfantryWeaponVisibility.PrimaryMask;
    }

    private void AdvanceGrenadierWeaponReturns()
    {
        _grenadierWeapons.Advance(tick, entityKey =>
            activeArmyEntities.TryGetValue(entityKey, out BattleArmyEntityState? actor) &&
            IsGrenadier(actor));
    }

    private void RemoveGrenadierWeaponVisibility(ulong entityKey)
    {
        _grenadierWeapons.Remove(entityKey);
    }
}
