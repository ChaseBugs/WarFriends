using UnityEngine;

public class NameGuiRecord : PoolableObject
{
	public UILabel categoryName;

	public GameObject salePart;

	private WeaponCategory mCategory;

	public void InitializeName(WeaponCategory category)
	{
		mCategory = category;
		categoryName.text = ((!GameVariables.weaponCategoryIdWeaponScreen.ContainsKey(category)) ? category.ToString().ToUpper() : Localization.Localize(GameVariables.weaponCategoryIdWeaponScreen[category]));
		Sale();
	}

	public void Sale()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(mCategory, OfferBuyType.Both) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(mCategory, OfferBuyType.Both) > 0;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.purchasableInShop && weaponLevelsSetup.weaponCategory == mCategory && weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
			flag4 |= weaponLevelsSetup.weaponCategory == mCategory && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		salePart.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void GUIForReposition(bool show)
	{
		if (show)
		{
			Sale();
		}
		else
		{
			salePart.SetActive(value: false);
		}
	}
}
