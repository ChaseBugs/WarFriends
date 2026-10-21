namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private bool UsesGrenade(string playerId)
    {
        return grenadeCombat?.IsActive(playerId) == true;
    }

    private void SelectCombatWeapon(Player player, PvpWeaponSlotState weapon)
    {
        string playerId = player.Definition.PlayerId;
        bool isGrenade = grenadeCatalog?.Bindings.Any(binding => binding.SourceId == weapon.Definition.Weapon.SourceId)
            == true;
        if (isGrenade)
        {
            if (grenadeCombat == null)
            {
                throw new InvalidDataException("The selected grenade has no host simulation.");
            }
            grenadeCombat.SelectWeapon(playerId, new GrenadeWeaponSelection(weapon.Definition.Weapon,
                weapon.Definition.WeaponUpgrade, tick, new(player.Position, player.Cover, player.IsMoving)));
            rifleCombat?.SuspendWeapon(playerId);
            return;
        }

        rifleCombat?.SwitchWeapon(playerId, weapon.Definition.Weapon, weapon.Definition.WeaponUpgrade);
        if (grenadeCombat != null)
        {
            grenadeCombat.DeselectWeapon(playerId, tick);
        }
    }
}
