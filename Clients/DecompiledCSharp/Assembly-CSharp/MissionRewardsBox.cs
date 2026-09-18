using UnityEngine;

public class MissionRewardsBox : Core_BaseScript
{
	[Header("Icons")]
	public UISprite warbucksSprite;

	public UISprite goldSprite;

	public GameObject cardObject;

	public UISprite cardBackgroundSprite;

	public UILabel xpLabel;

	[Header("Text")]
	public UILabel amountLabel;

	[Header("Claimed Part")]
	public UISprite border;

	public UISprite background;

	public UISprite claimedSprite;

	public void InitializeWarbucks(int amount)
	{
		warbucksSprite.gameObject.SetActive(value: true);
		goldSprite.gameObject.SetActive(value: false);
		cardObject.gameObject.SetActive(value: false);
		xpLabel.gameObject.SetActive(value: false);
		amountLabel.text = MiscTools.FormatBigNumber(amount);
		ClaimedPart(claimed: false);
	}

	public void InitializeGold(int amount, bool claimed)
	{
		warbucksSprite.gameObject.SetActive(value: false);
		goldSprite.gameObject.SetActive(value: true);
		cardObject.gameObject.SetActive(value: false);
		xpLabel.gameObject.SetActive(value: false);
		amountLabel.text = MiscTools.FormatBigNumber(amount);
		ClaimedPart(claimed);
	}

	public void InitializeCard(CardManager.CardType type, bool claimed)
	{
		warbucksSprite.gameObject.SetActive(value: false);
		goldSprite.gameObject.SetActive(value: false);
		cardObject.gameObject.SetActive(value: true);
		xpLabel.gameObject.SetActive(value: false);
		cardBackgroundSprite.spriteName = Card.CardBackground(type);
		amountLabel.text = Localization.Localize("ID_WARCARD");
		ClaimedPart(claimed);
	}

	public void InitializeXP(int amount)
	{
		warbucksSprite.gameObject.SetActive(value: false);
		goldSprite.gameObject.SetActive(value: false);
		cardObject.gameObject.SetActive(value: false);
		xpLabel.gameObject.SetActive(value: true);
		amountLabel.text = MiscTools.FormatBigNumber(amount);
		ClaimedPart(claimed: false);
	}

	public void Hide()
	{
		warbucksSprite.gameObject.SetActive(value: false);
		goldSprite.gameObject.SetActive(value: false);
		cardObject.gameObject.SetActive(value: false);
		xpLabel.gameObject.SetActive(value: false);
		amountLabel.text = string.Empty;
		ClaimedPart(claimed: false);
	}

	private void ClaimedPart(bool claimed)
	{
		claimedSprite.gameObject.SetActive(claimed);
		goldSprite.color = ((!claimed) ? Color.white : Colours.gray);
		cardBackgroundSprite.color = ((!claimed) ? Color.white : Colours.gray);
		amountLabel.color = ((!claimed) ? Color.white : Colours.gray);
		background.alpha = ((!claimed) ? 0.0625f : (1f / 32f));
		border.alpha = ((!claimed) ? 0.125f : 0.0625f);
	}
}
