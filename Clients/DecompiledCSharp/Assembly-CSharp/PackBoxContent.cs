using UnityEngine;

public class PackBoxContent : Core_BaseScript
{
	[Header("Basic")]
	public UILabel contentName;

	public GameObject bottomPart;

	[Header("-Gold Cards 1-5")]
	public GameObject fiveRandomGoldCards;

	public UISprite[] cardsBackground;

	[Header("-Visual")]
	public UISprite visualSprite;

	[Header("-Power Band")]
	public UISprite powerBandSprite;

	public UISprite powerBandMiniIcon;

	public UILabel powerBandValue;

	[Header("-VIP")]
	public UISprite vipSprite;

	[Header("-Gold")]
	public UISprite goldIcon;

	public UILabel goldLabel;

	[Header("Common")]
	public GameObject freePart;

	public void InitializeCards(int number, bool silver = false)
	{
		freePart.SetActive(value: true);
		fiveRandomGoldCards.SetActive(value: true);
		contentName.text = ((!silver) ? string.Format("{0} {1}", number, Localization.Localize((number <= 1) ? "ID_GOLDCARD" : "ID_GOLDCARDS")) : string.Format("{0} {1}", number, Localization.Localize((number <= 1) ? "ID_SILVERCARD" : "ID_SILVERCARDS")));
		number = Mathf.Clamp(number, 1, 5);
		for (int i = 0; i < 5; i++)
		{
			cardsBackground[i].gameObject.SetActive(i < number);
			cardsBackground[i].spriteName = ((!silver) ? "game-card-gold" : "game-card-silver");
		}
		visualSprite.gameObject.SetActive(value: false);
		powerBandSprite.gameObject.SetActive(value: false);
		powerBandMiniIcon.gameObject.SetActive(value: false);
		powerBandValue.gameObject.SetActive(value: false);
		vipSprite.gameObject.SetActive(value: false);
		goldIcon.gameObject.SetActive(value: false);
		goldLabel.gameObject.SetActive(value: false);
	}

	public void InitializeVIP(int seconds)
	{
		freePart.SetActive(value: true);
		vipSprite.gameObject.SetActive(value: true);
		string arg = MiscTools.PrintableTimeVipConvert(seconds);
		contentName.text = string.Format("{0} {1}", arg, Localization.Localize("ID_VIPTIME"));
		fiveRandomGoldCards.SetActive(value: false);
		visualSprite.gameObject.SetActive(value: false);
		powerBandSprite.gameObject.SetActive(value: false);
		powerBandMiniIcon.gameObject.SetActive(value: false);
		powerBandValue.gameObject.SetActive(value: false);
		goldIcon.gameObject.SetActive(value: false);
		goldLabel.gameObject.SetActive(value: false);
	}

	public void InitializeVisual(PlayerVisual playerVisual)
	{
		if (playerVisual == null)
		{
			HideAll();
			Debug.LogError("Not a player visual.");
			return;
		}
		visualSprite.gameObject.SetActive(value: true);
		visualSprite.spriteName = playerVisual.icon;
		visualSprite.MakePixelPerfect();
		visualSprite.transform.localPosition = new Vector3(visualSprite.transform.localPosition.x, visualSprite.transform.localPosition.y, 0.5f);
		visualSprite.transform.localScale = new Vector3(0.7f * visualSprite.transform.localScale.x, 0.7f * visualSprite.transform.localScale.y, visualSprite.transform.localScale.z);
		contentName.text = playerVisual.name.ToUpper();
		fiveRandomGoldCards.SetActive(value: false);
		powerBandSprite.gameObject.SetActive(value: false);
		powerBandMiniIcon.gameObject.SetActive(value: false);
		powerBandValue.gameObject.SetActive(value: false);
		vipSprite.gameObject.SetActive(value: false);
		goldIcon.gameObject.SetActive(value: false);
		goldLabel.gameObject.SetActive(value: false);
		freePart.SetActive(value: false);
	}

	public void InitializePowerBand(PlayerVisual playerVisual, int seconds)
	{
		if (playerVisual == null)
		{
			HideAll();
			Debug.LogError("Not a power band.");
			return;
		}
		freePart.SetActive(value: true);
		powerBandSprite.gameObject.SetActive(value: true);
		powerBandSprite.spriteName = playerVisual.icon;
		powerBandSprite.MakePixelPerfect();
		powerBandSprite.transform.localScale = new Vector3(0.5f * powerBandSprite.transform.localScale.x, 0.5f * powerBandSprite.transform.localScale.y, 1f);
		powerBandValue.gameObject.SetActive(value: true);
		powerBandValue.text = playerVisual.decalValueString;
		float x = powerBandValue.transform.localPosition.x + powerBandValue.relativeSize.x * powerBandValue.transform.localScale.x + 8f;
		powerBandMiniIcon.gameObject.SetActive(value: true);
		powerBandMiniIcon.spriteName = playerVisual.decalMiniIcon;
		powerBandMiniIcon.MakePixelPerfect();
		powerBandMiniIcon.color = playerVisual.decalMiniIconColor;
		powerBandMiniIcon.transform.localPosition = new Vector3(x, powerBandValue.transform.localPosition.y, 0.5f);
		contentName.text = Localization.LocalizeFormat("ID_POWERBANDBOX", MiscTools.PrintableTimeVipConvert(seconds));
		fiveRandomGoldCards.SetActive(value: false);
		visualSprite.gameObject.SetActive(value: false);
		vipSprite.gameObject.SetActive(value: false);
		goldIcon.gameObject.SetActive(value: false);
		goldLabel.gameObject.SetActive(value: false);
	}

	public void InitializeGold(int amount)
	{
		if (amount == 0)
		{
			HideAll();
			Debug.LogError("Not a gold reward.");
			return;
		}
		freePart.SetActive(value: true);
		goldIcon.gameObject.SetActive(value: true);
		goldLabel.gameObject.SetActive(value: true);
		string text = MiscTools.FormatBigNumber(amount);
		goldLabel.text = text;
		contentName.text = string.Format("{0} {1}", text, Localization.Localize("ID_GOLD"));
		fiveRandomGoldCards.SetActive(value: false);
		visualSprite.gameObject.SetActive(value: false);
		powerBandSprite.gameObject.SetActive(value: false);
		powerBandMiniIcon.gameObject.SetActive(value: false);
		powerBandValue.gameObject.SetActive(value: false);
		vipSprite.gameObject.SetActive(value: false);
	}

	public void HideAll()
	{
		fiveRandomGoldCards.SetActive(value: false);
		visualSprite.gameObject.SetActive(value: false);
		powerBandSprite.gameObject.SetActive(value: false);
		powerBandMiniIcon.gameObject.SetActive(value: false);
		powerBandValue.gameObject.SetActive(value: false);
		vipSprite.gameObject.SetActive(value: false);
		goldIcon.gameObject.SetActive(value: false);
		goldLabel.gameObject.SetActive(value: false);
		freePart.SetActive(value: false);
		contentName.text = string.Empty;
	}

	public void InstantShowPanels()
	{
		TweenAlpha.Begin(bottomPart, 0.1f, 1f, 1f);
		TweenAlpha.Begin(fiveRandomGoldCards, 0.1f, 1f, 1f);
	}
}
