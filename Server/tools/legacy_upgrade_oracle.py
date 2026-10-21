"""Extract the reviewed 1.4.0 upgrade boundaries into the headless Client oracle."""

from pathlib import Path


def upgrade_sources(client: Path) -> dict[str, str]:
    weapon = (client / "WeaponLevelsSetup.cs").read_text(encoding="utf-8-sig")
    unit = (client / "UpgradeSlot.cs").read_text(encoding="utf-8-sig")
    elite = (client / "UpgradeSlotElite.cs").read_text(encoding="utf-8-sig")

    def line(source, prefix):
        matches = [row.strip() for row in source.splitlines() if row.strip().startswith(prefix)]
        if len(matches) != 1:
            raise ValueError(f"Upgrade source predicate is not unique: {prefix}")
        return matches[0]

    def section(source, start, end):
        begin = source.index(start)
        return source[begin:source.index(end, begin)].strip()

    return {
        "Upgrade.WeaponMaximum": line(weapon, "public virtual int maxWeaponLevel =>"),
        "Upgrade.WeaponCanBuy": section(weapon, "\tpublic bool CanUpgrade(UpgradeSlot slot)",
                                         "\n\tpublic int DeliveryTime("),
        "Upgrade.UnitMaximum": section(unit, "\tpublic int maxPower\n", "\n\tpublic int maxIndexInExcel"),
        "Upgrade.UnitTierMaximum": section(unit, "\tpublic virtual int actualMaxLevel\n", "\n\tpublic int maxPower"),
        "Upgrade.UnitIsMax": line(unit, "public virtual bool isMaxUpgraded =>"),
        "Upgrade.NormalId": line(unit, "public virtual int id =>"),
        "Upgrade.EliteId": line(elite, "public override int id =>"),
        "Upgrade.EliteUnlocked": line(elite, "public override bool isUnlocked =>"),
        "Upgrade.EliteIsMax": line(elite, "public override bool isMaxUpgraded =>"),
        "Upgrade.EliteTierMaximum": line(elite, "public override int actualMaxLevel =>"),
    }


def upgrade_oracle(recovered: dict[str, str]) -> str:
    template = """
internal static class RecoveredUpgradeOracle
{
    private sealed class UpgradeSlot { public int boughtIndex; }
    private sealed class Sheet
    {
        internal List<int> RowsGeneric;
        internal bool HasColumn(string name) => true;
        internal object GetValue(int index, string name) => RowsGeneric[index];
    }
    private class WeaponOwner
    {
        internal Sheet uprgradesExcel;
        __WEAPON_MAXIMUM__
        __WEAPON_CAN_BUY__
    }
    private sealed class ArmyRow { internal int STARTINGELITE; }
    private sealed class UnitOwner
    {
        internal int actualTier;
        internal Sheet excel;
        internal ArmyRow armyUpgradesRow;
    }
    private class UnitSlot
    {
        internal UnitOwner owner;
        internal int mMaxPower = -1;
        internal int mActualMaxLevel = -1;
        public virtual int boughtIndex { get; set; }
        public virtual bool isUnlocked => true;
        __NORMAL_ID__
        __UNIT_IS_MAX__
        __UNIT_MAXIMUM__
        __UNIT_TIER_MAXIMUM__
    }
    private sealed class EliteSlot : UnitSlot
    {
        __ELITE_ID__
        __ELITE_UNLOCKED__
        __ELITE_IS_MAX__
        __ELITE_TIER_MAXIMUM__
    }
    internal static bool WeaponCanUpgrade(int rowCount, int index)
    {
        var owner = new WeaponOwner { uprgradesExcel = new Sheet { RowsGeneric = new List<int>(new int[rowCount]) } };
        return owner.CanUpgrade(new UpgradeSlot { boughtIndex = index });
    }
    internal static bool UnitCanUpgrade(int[] tiers, int tier, int index)
    {
        var owner = new UnitOwner { actualTier = tier, excel = new Sheet { RowsGeneric = new List<int>(tiers) } };
        var slot = new UnitSlot { owner = owner, boughtIndex = index };
        return index < slot.actualMaxLevel && !slot.isMaxUpgraded;
    }
    internal static bool EliteCanUpgrade(int[] tiers, int startingElite, int index)
    {
        var owner = new UnitOwner { armyUpgradesRow = new ArmyRow { STARTINGELITE = startingElite },
            excel = new Sheet { RowsGeneric = new List<int>(tiers) } };
        return !new EliteSlot { owner = owner, boughtIndex = index }.isMaxUpgraded;
    }
}
"""
    for placeholder, identity in (
        ("WEAPON_MAXIMUM", "WeaponMaximum"), ("WEAPON_CAN_BUY", "WeaponCanBuy"),
        ("NORMAL_ID", "NormalId"), ("UNIT_IS_MAX", "UnitIsMax"), ("UNIT_MAXIMUM", "UnitMaximum"),
        ("UNIT_TIER_MAXIMUM", "UnitTierMaximum"), ("ELITE_ID", "EliteId"),
        ("ELITE_UNLOCKED", "EliteUnlocked"), ("ELITE_IS_MAX", "EliteIsMax"),
        ("ELITE_TIER_MAXIMUM", "EliteTierMaximum"),
    ):
        template = template.replace(f"__{placeholder}__", recovered[f"Upgrade.{identity}"])
    return template
