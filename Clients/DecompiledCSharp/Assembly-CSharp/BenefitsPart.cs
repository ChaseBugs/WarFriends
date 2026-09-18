using Google2u;
using UnityEngine;

public class BenefitsPart : Core_BaseScript
{
	[Header("1 Warcards Slot")]
	public UILabel benefitSlotLabel;

	public UISprite slotLockedBackground;

	public UISprite slotLockedIcon;

	public UILabel slotLockedRankLabel;

	[Header("2 More Lootboxes")]
	public UILabel lootboxBonus;

	[Header("4 More XP")]
	public UILabel moreXp1st;

	public UILabel moreXp2nd;

	[Header("5 Daily Warcards")]
	public UILabel benefitWarcardsLabel;

	public UISprite warcardsLockedBackground;

	public UISprite warcardsLockedIcon;

	public UILabel warcardsLockedRankLabel;

	public void Initialize()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxAfterBattles).FLOATVALUE;
		benefitSlotLabel.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		benefitWarcardsLabel.color = ((!isWarcardsLocked) ? Color.white : Colours.grayHundred);
		slotLockedBackground.gameObject.SetActive(isWarcardsLocked);
		slotLockedIcon.gameObject.SetActive(isWarcardsLocked);
		slotLockedRankLabel.gameObject.SetActive(isWarcardsLocked);
		warcardsLockedBackground.gameObject.SetActive(isWarcardsLocked);
		warcardsLockedIcon.gameObject.SetActive(isWarcardsLocked);
		warcardsLockedRankLabel.gameObject.SetActive(isWarcardsLocked);
		if (isWarcardsLocked)
		{
			slotLockedRankLabel.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), LevelManager.instance.warcardsUnlockLevel);
			warcardsLockedRankLabel.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), LevelManager.instance.warcardsUnlockLevel);
		}
		moreXp1st.text = Localization.Localize("ID_MOREXP");
		moreXp2nd.text = Localization.Localize("ID_XP");
		MiscTools.SetUILabelRescale(moreXp1st, 50f, 15f, 137);
		MiscTools.SetUILabelRescale(moreXp2nd, 84f, 15f, 124);
		lootboxBonus.text = Localization.LocalizeFormat("ID_VIP_BENEFITS2", MiscTools.FormatNumberToOrdinal(num).ToUpper());
	}
}
