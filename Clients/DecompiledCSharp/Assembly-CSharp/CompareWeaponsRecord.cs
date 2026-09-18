using UnityEngine;

public class CompareWeaponsRecord : MonoBehaviour
{
	[Header("Header")]
	public UILabel weaponSlot;

	[Header("Core")]
	public UISprite icon;

	public UISprite background;

	public UILabel power;

	public UILabel level;

	public UISprite bottom;

	public void InitializeSlot(int slotIndex)
	{
		WeaponCategory category = GameVariables.slotCategory[slotIndex];
		string weaponCategoryId = Singleton<GameVariables>.instance.GetWeaponCategoryId(category, StringCase.UpperCase);
		weaponSlot.text = Localization.Localize(weaponCategoryId);
	}

	public void Initialize(WeaponLevelsSetup setup, int weaponBoughtIndex, WeaponLevelsSetup opponentSetup, int opponentBoughtIndex, bool isOpponent, bool isEquipped)
	{
		icon.spriteName = setup.playerWeapon.iconName;
		icon.MakePixelPerfect();
		icon.transform.localScale = icon.transform.localScale.MultiplyXY(56f / 85f);
		background.color = Color.white;
		if (Singleton<GameController>.instance.isWarArena)
		{
			power.text = string.Empty;
			level.text = string.Empty;
			bottom.alpha = 0f;
			background.color = ((!isEquipped) ? Color.white.ReplaceA(0.3f) : Color.white);
			icon.alpha = ((!isEquipped) ? 0f : 1f);
			return;
		}
		background.color = Color.white;
		icon.alpha = 1f;
		int weaponPowerX = setup.GetWeaponPowerX10(weaponBoughtIndex);
		power.text = MiscTools.FormatBigNumber(weaponPowerX);
		level.text = MiscTools.FormatBigNumber(setup.GetLevel(isBought: true, weaponBoughtIndex));
		int weaponPowerX2 = opponentSetup.GetWeaponPowerX10(opponentBoughtIndex);
		level.transform.localPosition = new Vector3((!isOpponent) ? 42f : 155f, -100f, -2f);
		if (weaponPowerX == weaponPowerX2)
		{
			power.color = Color.white;
			bottom.color = Color.white.ReplaceA(0.15f);
		}
		else if (weaponPowerX > weaponPowerX2)
		{
			power.color = Colours.greenWeaponStats;
			bottom.color = Colours.greenWeaponStats.ReplaceA(0.15f);
		}
		else
		{
			power.color = Colours.redWeaponStats;
			bottom.color = Colours.redWeaponStats.ReplaceA(0.1f);
		}
	}
}
