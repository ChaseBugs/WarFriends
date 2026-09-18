using System;
using UnityEngine;

public class CardsAndPacksDialog : GuiElementSingle<CardsAndPacksDialog>, IGuiDialog
{
	public enum DialogType
	{
		STARTER_PACK,
		VALUE_PACK,
		MONEY_PACK
	}

	[Header("General")]
	public UISprite background;

	public UILabel header;

	public UILabel text;

	public UIButton closeButton;

	[Header("Button")]
	public UIButton buttonBuy;

	public UILabel buttonLabel;

	[Header("Price panel no sale")]
	public GameObject noSalePart;

	public UILabel noSaleValueLabel;

	[Header("Price panel sale")]
	public GameObject salePart;

	public UILabel discountLabel;

	public UILabel currentValueLabel;

	public StrikethroughPrize strikeTroughSetter;

	public UISprite regularStrikeThrough;

	public UILabel regularValueLabel;

	[Header("Offer Active")]
	public GameObject offerActive;

	public UILabel offerActiveLabel;

	[Header("-Starter Pack Content")]
	public GameObject starterPackPart;

	[Header("-Value Pack Content")]
	public GameObject valuePackPart;

	[Header("-Boxes")]
	public SpecialPackBoxItem[] boxes;

	private bool mAfterGame;

	private DialogType mDialogType;

	private bool mInitGuiUpdate;

	private SpecialPackContent mPackContent;

	public void ShowDialog(DialogType dialogType, bool afterGame = false)
	{
		mAfterGame = afterGame;
		mDialogType = dialogType;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonBuy.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ButtonBuyClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		Singleton<BeanstalkServerManager>.instance.inAppHandler.ProductsLoaded += OnProductsLoaded;
	}

	private void ButtonBuyClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			BuyPack();
			HideDialog();
		}
	}

	private void BuyPack()
	{
		string location = string.Empty;
		if (mAfterGame)
		{
			location = "Battle_End_Dialog";
		}
		else if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<MainScreen>.instance)
		{
			location = "Main_Menu_Offers_Bar";
		}
		else if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<CardMenuScreen>.instance)
		{
			location = "WarCards_Screen";
		}
		switch (mDialogType)
		{
		case DialogType.STARTER_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(CardPack.Starter), location);
			break;
		case DialogType.VALUE_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(CardPack.Value), location);
			break;
		case DialogType.MONEY_PACK:
			Singleton<BeanstalkServerManager>.instance.BuyPack(Singleton<GameVariables>.instance.PackId(CardPack.Money), location);
			break;
		}
		GuiScreenSingle<CardMenuScreen>.instance.warcardsContent.SetStarterOrValuePack();
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void OnProductsLoaded()
	{
		if (isShowed)
		{
			ShowPrizes();
		}
	}

	public override void InitGUIValues()
	{
		Initialize();
		if (mDialogType == DialogType.MONEY_PACK || mDialogType == DialogType.STARTER_PACK)
		{
			mInitGuiUpdate = true;
			UpdateOncePerSecond();
			mInitGuiUpdate = false;
			CounterManager counterManager = Singleton<CounterManager>.instance;
			counterManager.updateCounterBySecond = (Action)Delegate.Remove(counterManager.updateCounterBySecond, new Action(UpdateOncePerSecond));
			CounterManager counterManager2 = Singleton<CounterManager>.instance;
			counterManager2.updateCounterBySecond = (Action)Delegate.Combine(counterManager2.updateCounterBySecond, new Action(UpdateOncePerSecond));
		}
	}

	private void Initialize()
	{
		HideAllBoxes();
		switch (mDialogType)
		{
		case DialogType.STARTER_PACK:
			header.text = Localization.Localize("ID_STARTERPACKCONTENTS");
			buttonLabel.text = Localization.Localize("ID_BUYSTARTERPACK");
			InitializeStarterPack();
			break;
		case DialogType.VALUE_PACK:
			header.text = Localization.Localize("ID_VALUEPACKCONTENTS");
			text.text = Localization.Localize("ID_VALUEPACKINFORMATIONS");
			buttonLabel.text = Localization.Localize("ID_BUYVALUEPACK");
			InitializeValuePack();
			break;
		case DialogType.MONEY_PACK:
			header.text = Localization.Localize("ID_MONEYPACKCONTENTS");
			buttonLabel.text = Localization.Localize("ID_BUYMONEYPACK");
			InitializeMoneyPack();
			break;
		}
		MiscTools.SetUILabelRescale(buttonLabel, 57f, 20f, 620);
		ShowPrizes();
	}

	private void InitializeStarterPack()
	{
		starterPackPart.SetActive(value: true);
		valuePackPart.SetActive(value: false);
		offerActive.SetActive(value: true);
		mPackContent = Singleton<GameVariables>.instance.starterPack;
		boxes[0].Initialize(2, 5, mPackContent.contentOfPack[0]);
		boxes[0].freeSticker.SetActive(mPackContent.contentOfPack[0].type != SpecialPackContent.ContentType.Customization);
		boxes[0].gameObject.SetActive(value: true);
		boxes[1].Initialize(3, 5, mPackContent.contentOfPack[1]);
		boxes[1].freeSticker.SetActive(mPackContent.contentOfPack[1].type != SpecialPackContent.ContentType.Customization);
		boxes[1].gameObject.SetActive(value: true);
		boxes[2].Initialize(4, 5, mPackContent.contentOfPack[2]);
		boxes[2].freeSticker.SetActive(mPackContent.contentOfPack[2].type != SpecialPackContent.ContentType.Customization);
		boxes[2].gameObject.SetActive(value: true);
		boxes[3].Initialize(5, 5, mPackContent.contentOfPack[3]);
		boxes[3].freeSticker.SetActive(mPackContent.contentOfPack[3].type != SpecialPackContent.ContentType.Customization);
		boxes[3].gameObject.SetActive(value: true);
	}

	private void InitializeValuePack()
	{
		starterPackPart.SetActive(value: false);
		valuePackPart.SetActive(value: true);
		offerActive.SetActive(value: false);
		mPackContent = Singleton<GameVariables>.instance.valuePack;
		boxes[0].Initialize(2, 5, mPackContent.contentOfPack[0]);
		boxes[0].freeSticker.SetActive(mPackContent.contentOfPack[0].type != SpecialPackContent.ContentType.Customization);
		boxes[0].gameObject.SetActive(value: true);
		if (mPackContent.contentOfPack[0].type == SpecialPackContent.ContentType.Customization && mPackContent.contentOfPack[0].visual.owner.categoryNumber != 0)
		{
			boxes[0].AlterShownCustomization(2, 5);
		}
		boxes[1].Initialize(3, 5, mPackContent.contentOfPack[1]);
		boxes[1].freeSticker.SetActive(mPackContent.contentOfPack[1].type != SpecialPackContent.ContentType.Customization);
		boxes[1].gameObject.SetActive(value: true);
		if (mPackContent.contentOfPack[1].type == SpecialPackContent.ContentType.Customization && mPackContent.contentOfPack[1].visual.owner.categoryNumber != 0)
		{
			boxes[1].AlterShownCustomization(3, 5);
		}
		boxes[2].Initialize(4, 5, mPackContent.contentOfPack[2]);
		boxes[2].freeSticker.SetActive(mPackContent.contentOfPack[2].type != SpecialPackContent.ContentType.Customization);
		boxes[2].gameObject.SetActive(value: true);
		if (mPackContent.contentOfPack[2].type == SpecialPackContent.ContentType.Customization && mPackContent.contentOfPack[2].visual.owner.categoryNumber != 0)
		{
			boxes[2].AlterShownCustomization(4, 5);
		}
		boxes[3].Initialize(5, 5, mPackContent.contentOfPack[3]);
		boxes[3].freeSticker.SetActive(mPackContent.contentOfPack[3].type != SpecialPackContent.ContentType.Customization);
		boxes[3].gameObject.SetActive(value: true);
		if (mPackContent.contentOfPack[3].type == SpecialPackContent.ContentType.Customization && mPackContent.contentOfPack[3].visual.owner.categoryNumber != 0)
		{
			boxes[3].AlterShownCustomization(5, 5);
		}
	}

	private void InitializeMoneyPack()
	{
		starterPackPart.SetActive(value: false);
		valuePackPart.SetActive(value: false);
		offerActive.SetActive(value: true);
		mPackContent = Singleton<GameVariables>.instance.moneyPack;
		boxes[0].Initialize(1, 3, mPackContent.contentOfPack[0]);
		boxes[0].freeSticker.SetActive(value: false);
		boxes[0].gameObject.SetActive(value: true);
		boxes[1].Initialize(2, 3, mPackContent.contentOfPack[1]);
		boxes[1].freeSticker.SetActive(value: false);
		boxes[1].gameObject.SetActive(value: true);
		boxes[2].Initialize(3, 3, mPackContent.contentOfPack[2]);
		boxes[2].freeSticker.SetActive(value: false);
		boxes[2].gameObject.SetActive(value: true);
	}

	private void HideAllBoxes()
	{
		SpecialPackBoxItem[] array = boxes;
		foreach (SpecialPackBoxItem specialPackBoxItem in array)
		{
			specialPackBoxItem.gameObject.SetActive(value: false);
		}
	}

	private void ShowPrizes()
	{
		CardPack packName = CardPack.None;
		switch (mDialogType)
		{
		case DialogType.STARTER_PACK:
			packName = CardPack.Starter;
			break;
		case DialogType.VALUE_PACK:
			packName = CardPack.Value;
			break;
		case DialogType.MONEY_PACK:
			packName = CardPack.Money;
			break;
		}
		float num = Singleton<GameVariables>.instance.SaleOfPack(packName);
		bool flag = num > 0.001f;
		noSalePart.SetActive(!flag);
		salePart.SetActive(flag);
		string value = Singleton<GameVariables>.instance.PriceOfPack(packName).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(packName).Value2;
		noSaleValueLabel.text = value;
		currentValueLabel.text = value;
		regularValueLabel.text = value2;
		discountLabel.text = Localization.LocalizeFormat("ID_SALEPERCENT", MiscTools.RoundToInt(num * 100f));
		MiscTools.SetUILabelRescale(discountLabel, 58f, 29f, 300);
		if (flag)
		{
			strikeTroughSetter.SetUpStrikeThrought();
		}
	}

	private void UpdateOncePerSecond()
	{
		if (mDialogType == DialogType.MONEY_PACK)
		{
			int num = PlayerAnalytics.instance.data.moneyPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num < 0)
			{
				text.text = Localization.LocalizeFormat("ID_MONEYPACKINFORMATIONS", Colours.stringBlue, MiscTools.PrintableTime(0f, "-", string.Empty));
				offerActiveLabel.text = string.Format("{0} {1}", Localization.Localize("ID_OFFERACTIVE"), MiscTools.PrintableTime(0f, "-", string.Empty, localizeReadyString: false));
				if (!mInitGuiUpdate && base.isFullyShowed)
				{
					HideDialog();
				}
			}
			else
			{
				text.text = Localization.LocalizeFormat("ID_MONEYPACKINFORMATIONS", Colours.stringBlue, MiscTools.PrintableTime(num, "-", string.Empty));
				offerActiveLabel.text = string.Format("{0} {1}", Localization.Localize("ID_OFFERACTIVE"), MiscTools.PrintableTime(num, "-", string.Empty, localizeReadyString: false));
			}
		}
		else if (mDialogType == DialogType.STARTER_PACK)
		{
			int num2 = PlayerAnalytics.instance.data.starterPackDeadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			if (num2 < 0)
			{
				text.text = Localization.LocalizeFormat("ID_STARTERPACKINFORMATIONS", Colours.stringBlue, MiscTools.PrintableTime(0f, "-", string.Empty));
				offerActiveLabel.text = string.Format("{0} {1}", Localization.Localize("ID_OFFERACTIVE"), MiscTools.PrintableTime(0f, "-", string.Empty, localizeReadyString: false));
				if (!mInitGuiUpdate && base.isFullyShowed)
				{
					HideDialog();
				}
			}
			else
			{
				text.text = Localization.LocalizeFormat("ID_STARTERPACKINFORMATIONS", Colours.stringBlue, MiscTools.PrintableTime(num2, "-", string.Empty));
				offerActiveLabel.text = string.Format("{0} {1}", Localization.Localize("ID_OFFERACTIVE"), MiscTools.PrintableTime(num2, "-", string.Empty, localizeReadyString: false));
			}
		}
		MiscTools.SetUILabelRescale(offerActiveLabel, 33f, 20f, 390);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		GuiScreenSingle<CardMenuScreen>.instance.warcardsContent.draggablePanel.onePanelDisabled = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		CounterManager counterManager = Singleton<CounterManager>.instance;
		counterManager.updateCounterBySecond = (Action)Delegate.Remove(counterManager.updateCounterBySecond, new Action(UpdateOncePerSecond));
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		GuiScreenSingle<CardMenuScreen>.instance.warcardsContent.draggablePanel.onePanelDisabled = false;
	}

	public void DebugContent(SpecialPackContent packToShow)
	{
		HideAllBoxes();
		starterPackPart.SetActive(value: false);
		valuePackPart.SetActive(value: false);
		offerActive.SetActive(value: false);
		int num = packToShow.contentOfPack.Length;
		if (num < 2)
		{
			if (num == 1)
			{
				boxes[0].Initialize(1, 2, packToShow.contentOfPack[0]);
				boxes[0].gameObject.SetActive(value: true);
			}
		}
		else
		{
			for (int i = 1; i <= num && i <= 6; i++)
			{
				boxes[i - 1].Initialize(i, num, packToShow.contentOfPack[i - 1]);
				boxes[i - 1].gameObject.SetActive(value: true);
			}
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton.gameObject);
	}
}
