using System;
using UnityEngine;

public class PackDetailsDialog : GuiElementSingle<PackDetailsDialog>, IGuiDialog
{
	[Header("Header")]
	public UIButton close;

	public UILabel header;

	[Header("Left")]
	public UISprite bigCardPack;

	[Header("Right")]
	public UILabel description;

	public UILabel priceLabel;

	public UISprite priceSprite;

	[Header("Sale")]
	public GameObject salePart;

	public UILabel salePercentLabel;

	[Header("Button")]
	public UIButton purchaseButton;

	public UILabel purchaseButtonLabel;

	private CardPackRecord mCardPackRecord;

	private CardPack mCardPack;

	public void ShowDialog(CardPack cardPack, CardPackRecord cardPackRecord)
	{
		if (Initialize(cardPack, cardPackRecord))
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 0f);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(close.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(purchaseButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ButtonPurchaseClick));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void ButtonPurchaseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<CardMenuScreen>.instance.warcardsContent.BuyCardPack(mCardPackRecord);
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		Singleton<OfferManager>.instance.SalesChanged -= SetSaleAndPrize;
		Singleton<OfferManager>.instance.SalesChanged += SetSaleAndPrize;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.warcardsContent.draggablePanel.onePanelDisabled = true;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.warcardsContent.draggablePanel.onePanelDisabled = false;
		Singleton<OfferManager>.instance.SalesChanged -= SetSaleAndPrize;
	}

	private bool Initialize(CardPack cardPack, CardPackRecord cardPackRecord)
	{
		if (cardPack != CardPack.Bronze && cardPack != CardPack.Silver && cardPack != CardPack.Gold)
		{
			Debug.LogError("CardDetails dialog is only for BRONZE, SILVER and GOLD cardpack details.");
			return false;
		}
		mCardPack = cardPack;
		mCardPackRecord = cardPackRecord;
		int num = Singleton<GameVariables>.instance.CardPackWarbucks(cardPack);
		priceSprite.spriteName = ((num <= 0) ? "menu-gold" : "menu-warbucks");
		priceSprite.MakePixelPerfect();
		float multiplier = ((num <= 0) ? 0.3f : 0.53f);
		priceSprite.transform.localScale = priceSprite.transform.localScale.MultiplyXY(multiplier);
		bigCardPack.spriteName = GameVariables.cardpackLook[cardPack].Value2;
		string text = string.Empty;
		int num2 = 0;
		CardManager.CardType key = CardManager.CardType.Bronze;
		CardManager.CardType key2 = CardManager.CardType.Gold;
		if (cardPack == CardPack.Bronze)
		{
			text = Localization.Localize("ID_BRONZE");
			header.text = Localization.Localize("ID_BRONZEPACK");
			num2 = CardManager.instance.bronzePackBronzeCards;
			key = CardManager.instance.bronzePackMin;
			key2 = CardManager.instance.bronzePackMax;
		}
		if (cardPack == CardPack.Silver)
		{
			text = Localization.Localize("ID_SILVER");
			header.text = Localization.Localize("ID_SILVERPACK");
			num2 = CardManager.instance.silverPackSilverCards;
			key = CardManager.instance.silverPackMin;
			key2 = CardManager.instance.silverPackMax;
		}
		if (cardPack == CardPack.Gold)
		{
			text = Localization.Localize("ID_GOLD");
			header.text = Localization.Localize("ID_GOLDPACK");
			num2 = CardManager.instance.goldPackGoldCards;
			key = CardManager.instance.goldPackMin;
			key2 = CardManager.instance.goldPackMax;
		}
		purchaseButtonLabel.text = Localization.LocalizeFormat("ID_PURCHASECARDPACK", text.ToUpper());
		MiscTools.SetUILabelRescale(purchaseButtonLabel, 50f, 20f);
		description.text = Localization.LocalizeFormat("ID_CARDPACKDETAILS_DESCRIPTION", text, CardManager.instance.cardsInPack, num2, text.ToLower(), CardManager.instance.cardsInPack - num2, Colours.stringBlue, Colours.stringWhite, Localization.Localize(GameVariables.warcardName[key]), Localization.Localize(GameVariables.warcardName[key2]));
		SetSaleAndPrize();
		return true;
	}

	private void SetSaleAndPrize()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(mCardPack);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(mCardPack);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(mCardPack);
		int num4 = ((!flag) ? (num2 + num3) : ((num2 + num3) * (100 - num) / 100));
		priceLabel.text = MiscTools.FormatBigNumber(num4);
		salePart.SetActive(flag);
		if (flag)
		{
			salePercentLabel.text = Localization.LocalizeFormat("ID_SALEPERCENT", num);
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(close.gameObject);
	}
}
