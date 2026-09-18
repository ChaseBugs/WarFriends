using UnityEngine;

public class WeaponEquipSlotButton : Core_BaseScript
{
	[Header("Core")]
	public UISprite background;

	public UISprite icon;

	public UILabel label;

	[Header("Notification")]
	public UILabel notificationNumber;

	public GameObject notificationGO;

	[Header("Sale")]
	public GameObject salePart;

	private string mSelectedBackgroundButton = "menu-weapons-tab-active";

	private string mNormalBackgroundButton = "menu-weapons-tab";

	private PlayerInventory.InventorySlot mInventorySlot;

	public WeaponCategory WeaponCategoryOfButton()
	{
		return mInventorySlot.category;
	}

	public void Highlight(int index)
	{
		Highlight(index == mInventorySlot.index);
	}

	public void Highlight(WeaponCategory category)
	{
		Highlight(category == (category & mInventorySlot.category));
	}

	private void Highlight(bool show)
	{
		icon.color = ((!show) ? Color.white : Colours.blue);
		label.color = ((!show) ? Color.white : Colours.blue);
		background.spriteName = ((!show) ? mNormalBackgroundButton : mSelectedBackgroundButton);
	}

	public void Notification()
	{
		int numberOfWeaponCategoryNotifications = Singleton<NotificationManager>.instance.GetNumberOfWeaponCategoryNotifications(mInventorySlot.category);
		notificationGO.SetActive(numberOfWeaponCategoryNotifications > 0);
		notificationNumber.text = numberOfWeaponCategoryNotifications.ToString();
	}

	public void Sale()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedWeaponCategory(mInventorySlot.category, OfferBuyType.Both) > 0;
		bool flag2 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(mInventorySlot.category, OfferBuyType.Both) > 0;
		bool flag3 = false;
		bool flag4 = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			flag3 |= weaponLevelsSetup.weaponCategory == (mInventorySlot.category & weaponLevelsSetup.weaponCategory) && weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
			flag4 |= weaponLevelsSetup.weaponCategory == (mInventorySlot.category & weaponLevelsSetup.weaponCategory) && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		}
		salePart.SetActive((flag && flag3) || (flag2 && flag4));
	}

	public void Initialize(PlayerInventory.InventorySlot inventorySlot, int count)
	{
		mInventorySlot = inventorySlot;
		label.text = mInventorySlot.name;
		Notification();
		Sale();
		icon.spriteName = mInventorySlot.iconName;
		icon.MakePixelPerfect();
		Highlight(show: false);
		float num = UIRoot.list[0].activeWidth / (float)count - 5f;
		MiscTools.SetUILabelRescale(label, 35f, 24f, (int)num - 240);
		background.transform.localScale = background.transform.localScale.ReplaceX(num);
		notificationGO.transform.localPosition = notificationGO.transform.localPosition.ReplaceX(num - 52f);
		salePart.transform.localPosition = salePart.transform.localPosition.ReplaceX(num - 65f);
		BoxCollider component = GetComponent<BoxCollider>();
		if (component != null)
		{
			component.center = component.center.ReplaceX(num / 2f);
			component.size = component.size.ReplaceX(num + 20f);
		}
	}

	private void OnClick()
	{
		GuiScreenSingle<WeaponScreen>.instance.WeaponCategoryButtonClick(mInventorySlot.category);
	}
}
