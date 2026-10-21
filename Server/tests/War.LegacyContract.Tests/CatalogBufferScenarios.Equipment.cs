using War.Backend.Legacy;
using static War.LegacyContract.Tests.CatalogBufferRequests;

namespace War.LegacyContract.Tests;

internal static partial class CatalogBufferScenarios
{
    private static IEnumerable<CatalogBufferScenario> Equipment()
    {
        yield return new("Weapon marker", Create(DatabaseAction.WeaponWasShown, CatalogBufferFixture.WeaponName),
            DatabaseResult.Success);
        yield return new("Army marker", Create(DatabaseAction.ArmyUnitWasShown, CatalogBufferFixture.UnitName),
            DatabaseResult.Success);
        yield return new("Visual notification marker", Create(DatabaseAction.VisualWasShown, "fixture-visual-free"),
            DatabaseResult.Success);
        yield return new("Monotonic chat cursor", Create(DatabaseAction.SaveLastSeenSquadChatTimeStamp, ""),
            DatabaseResult.Success);
        yield return new("Equip owned weapon", Create(DatabaseAction.EquipWeapon, CatalogBufferFixture.WeaponName,
            ("SlotIndex", 0), ("Index", 2)), DatabaseResult.Success, fixture => fixture.OwnWeapon());
        yield return new("Equip unowned weapon", Create(DatabaseAction.EquipWeapon, CatalogBufferFixture.WeaponName,
            ("SlotIndex", 0)), DatabaseResult.WeaponNotBought);
        yield return new("Equip malformed slot", Create(DatabaseAction.EquipWeapon, CatalogBufferFixture.WeaponName,
            ("SlotIndex", -1)), DatabaseResult.WrongPlayerData);
        yield return new("Equip owned army", Create(DatabaseAction.UpdateEquippedUnits, CatalogBufferFixture.UnitName),
            DatabaseResult.Success, fixture => fixture.OwnUnit());
        yield return new("Equip unowned army",
            Create(DatabaseAction.UpdateEquippedUnits, CatalogBufferFixture.UnitName),
            DatabaseResult.CantEquipUnit);
        yield return new("Equip missing cosmetic", Create(DatabaseAction.EquipDecal, "fixture-missing"),
            DatabaseResult.DecalCategoryNotFound);
        yield return new("Equip unowned cosmetic", Create(DatabaseAction.EquipDecal, "fixture-visual-wb"),
            DatabaseResult.DecalNotBought);
        yield return new("Equip default cosmetic", Create(DatabaseAction.EquipDecal, "fixture-visual-free"),
            DatabaseResult.Success);
        yield return new("Equip paid cosmetic", Create(DatabaseAction.EquipDecal, "fixture-visual-wb"),
            DatabaseResult.Success, fixture =>
                fixture.Decals.Visuals["fixture-visual-wb"] = new SavedPlayerVisual { Bought = true });
        yield return new("Promote missing unit", Create(DatabaseAction.PromoteUnit, "fixture-unit-missing"),
            DatabaseResult.PriceNotFound);
        yield return new("Promote unowned unit", Create(DatabaseAction.PromoteUnit, CatalogBufferFixture.UnitName),
            DatabaseResult.WrongIndexToActivate);
        yield return new("Promotion locked by rank", Create(DatabaseAction.PromoteUnit, CatalogBufferFixture.UnitName),
            DatabaseResult.NotEnoughLevel, fixture =>
            {
                fixture.OwnUnit();
                fixture.Player.Level = 1;
            });
        yield return new("Promotion maximum sentinel",
            Create(DatabaseAction.PromoteUnit, CatalogBufferFixture.UnitName),
            DatabaseResult.NotEnoughLevel, fixture =>
            {
                fixture.OwnUnit();
                fixture.Levels.SavedArmies[CatalogBufferFixture.UnitName].Tier = 6;
            });
        yield return new("Promotion to next tier", Create(DatabaseAction.PromoteUnit, CatalogBufferFixture.UnitName),
            DatabaseResult.Success, fixture => fixture.OwnUnit());
    }
}
