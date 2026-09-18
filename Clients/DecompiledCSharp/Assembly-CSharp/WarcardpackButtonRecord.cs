using UnityEngine;

public class WarcardpackButtonRecord : Core_BaseScript
{
	[Header("Core")]
	public UILabel warcardpackTitle;

	public UILabel warcardpackContains;

	public UILabel warcardpackWarcards;

	public UILabel warcardpackRandomWarcards;

	public UILabel warcardpackHint;

	[Header("-Table")]
	public UITable priceTable;

	public UISprite warbucksIcon;

	public UISprite goldIcon;

	public UILabel warcardpackPrice;

	[Header("-Sale")]
	public GameObject warcardpackSalePart;

	public UILabel warcardpackSaleLabel;

	public WinStreakCounter warcardpackSaleTimeCounter;

	private CardPack mWarCardPack = CardPack.Bronze;

	public CardPack warcardPack => mWarCardPack;

	public void InitControls(CardPack pack)
	{
		mWarCardPack = pack;
		InitializeTexts();
		priceTable.onReposition = delegate
		{
			float val = 0f - priceTable.padding.x - (warcardpackPrice.transform.parent.transform.localPosition.x - priceTable.padding.x) / 2f;
			priceTable.transform.localPosition = priceTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void InitializeTexts()
	{
		if (mWarCardPack == CardPack.Bronze)
		{
			warcardpackTitle.text = Localization.Localize("ID_BRONZEPACK");
			warcardpackContains.text = Localization.LocalizeFormat("ID_CONTAINSXWARCARDS", CardManager.instance.cardsInPack);
			warcardpackWarcards.text = string.Format("{0} {1}", CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_BRONZEWARCARDS"));
			warcardpackRandomWarcards.text = string.Format("{0} {1}", CardManager.instance.cardsInPack - CardManager.instance.bronzePackBronzeCards, Localization.Localize("ID_RANDOMWARCARDS"));
			warcardpackHint.text = Localization.LocalizeFormat("ID_WITHACHANCEOFORWARCARDS", Localization.Localize(GameVariables.warcardName[CardManager.instance.bronzePackMin]).ToLower(), Localization.Localize(GameVariables.warcardName[CardManager.instance.bronzePackMax]).ToLower());
		}
		else if (mWarCardPack == CardPack.Silver)
		{
			warcardpackTitle.text = Localization.Localize("ID_SILVERPACK");
			warcardpackContains.text = Localization.LocalizeFormat("ID_CONTAINSXWARCARDS", CardManager.instance.cardsInPack);
			warcardpackWarcards.text = string.Format("{0} {1}", CardManager.instance.silverPackSilverCards, Localization.Localize("ID_SILVERWARCARDS"));
			warcardpackRandomWarcards.text = string.Format("{0} {1}", CardManager.instance.cardsInPack - CardManager.instance.silverPackSilverCards, Localization.Localize("ID_RANDOMWARCARDS"));
			warcardpackHint.text = Localization.LocalizeFormat("ID_WITHACHANCEOFORWARCARDS", Localization.Localize(GameVariables.warcardName[CardManager.instance.silverPackMin]).ToLower(), Localization.Localize(GameVariables.warcardName[CardManager.instance.silverPackMax]).ToLower());
		}
		else if (mWarCardPack == CardPack.Gold)
		{
			warcardpackTitle.text = Localization.Localize("ID_GOLDPACK");
			warcardpackContains.text = Localization.LocalizeFormat("ID_CONTAINSXWARCARDS", CardManager.instance.cardsInPack);
			warcardpackWarcards.text = string.Format("{0} {1}", CardManager.instance.goldPackGoldCards, Localization.Localize("ID_GOLDWARCARDS"));
			warcardpackRandomWarcards.text = string.Format("{0} {1}", CardManager.instance.cardsInPack - CardManager.instance.goldPackGoldCards, Localization.Localize("ID_RANDOMWARCARDS"));
			warcardpackHint.text = Localization.LocalizeFormat("ID_WITHACHANCEOFORWARCARDS", Localization.Localize(GameVariables.warcardName[CardManager.instance.goldPackMin]).ToLower(), Localization.Localize(GameVariables.warcardName[CardManager.instance.goldPackMax]).ToLower());
		}
		MiscTools.SetUILabelRescale(warcardpackTitle, 57f, 28f, 700);
		MiscTools.SetUILabelRescale(warcardpackContains, 40f, 30f, 400);
		MiscTools.SetUILabelRescale(warcardpackWarcards, 40f, 30f, 370);
		MiscTools.SetUILabelRescale(warcardpackRandomWarcards, 38f, 30f, 370);
	}

	public void SetSaleAndPrize()
	{
		int num = Singleton<OfferManager>.instance.DiscountedCardpack(mWarCardPack);
		bool flag = num > 0;
		int num2 = Singleton<GameVariables>.instance.CardPackWarbucks(mWarCardPack);
		int num3 = Singleton<GameVariables>.instance.CardPackGold(mWarCardPack);
		int num4 = ((!flag) ? (num2 + num3) : ((num2 + num3) * (100 - num) / 100));
		warbucksIcon.gameObject.SetActive(num2 > 0);
		goldIcon.gameObject.SetActive(num3 > 0);
		warcardpackPrice.text = MiscTools.FormatBigNumber(num4);
		priceTable.repositionNow = true;
		warcardpackSalePart.SetActive(flag);
		if (flag)
		{
			warcardpackSaleLabel.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
			warcardpackSaleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedCardpackEndtime(mWarCardPack), upperCaseCountdown: true);
			warcardpackSaleTimeCounter.winStreakTimer = delegate
			{
				warcardpackSalePart.SetActive(value: false);
				warcardpackPrice.text = MiscTools.FormatBigNumber(Singleton<GameVariables>.instance.CardPackWarbucks(mWarCardPack) + Singleton<GameVariables>.instance.CardPackGold(mWarCardPack));
				priceTable.repositionNow = true;
			};
		}
		else
		{
			warcardpackSaleTimeCounter.StopCountingTo();
			warcardpackSaleTimeCounter.winStreakTimer = null;
		}
	}

	public void DoAfterHide()
	{
		warcardpackSaleTimeCounter.StopCountingTo();
		warcardpackSaleTimeCounter.winStreakTimer = null;
	}
}
