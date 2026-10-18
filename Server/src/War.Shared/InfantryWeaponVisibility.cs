using War.Protocol;

namespace War.Shared
{

    /// <summary>Validates source inventory visibility without accepting client weapon-switch commands.</summary>
    public static class InfantryWeaponVisibility
    {
        public const uint PrimaryMask = 1;
        public const uint SecondaryMask = 2;

        /// <summary>Checks the current six card-infantry projection; ordinary units and Drone retain zero.</summary>
        public static bool IsValid(BattleArmyEntityState entity)
        {
            if (entity == null)
            {
                return false;
            }

            if (entity.SourceCardId.Length == 0)
            {
                return entity.InfantryWeaponMask == 0;
            }

            if (!CardUnitSourceIdentity.Matches(entity.SourceCardId, entity.UnitId))
            {
                return false;
            }

            if (entity.SourceCardId == "HEAVYDRONE")
            {
                return entity.InfantryWeaponMask == 0;
            }

            if (entity.SourceCardId == "GREATGRENADIER")
            {
                return entity.InfantryWeaponMask == PrimaryMask || entity.InfantryWeaponMask == SecondaryMask;
            }

            return entity.InfantryWeaponMask == PrimaryMask;
        }
    }
}
