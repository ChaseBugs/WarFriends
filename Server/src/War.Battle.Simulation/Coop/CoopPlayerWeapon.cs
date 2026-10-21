using System.Collections.ObjectModel;

namespace War.BattleServer;

public sealed record CoopPlayerWeapon(
    int Slot, int InventoryIndex, int UpgradeIndex, WeaponManifest Weapon);
