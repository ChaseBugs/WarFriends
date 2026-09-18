using System;
using System.Collections.Generic;
using UnityEngine;

public class InappScreen : GuiElementSingle<InappScreen>, IGuiDialog
{
	public enum InAppType
	{
		Gold,
		Warbucks,
		Lootboxes
	}

	[Serializable]
	public class InappDefinition
	{
		public string id;

		public InAppType type;

		public int amount;

		public int sale;

		public float price { get; set; }

		public string formatedPrice { get; set; }

		public override string ToString()
		{
			return string.Format("{1} {0} for {2}", type, amount, formatedPrice);
		}

		public static InappDefinition CreateInappDefinition(string inappName, int amount)
		{
			InappDefinition inappDefinition = new InappDefinition();
			inappDefinition.id = inappName;
			inappDefinition.amount = amount;
			Tuple<float, string> itemPrice = Singleton<BeanstalkServerManager>.instance.inAppHandler.GetItemPrice(inappName);
			inappDefinition.price = itemPrice.Value1;
			inappDefinition.formatedPrice = itemPrice.Value2;
			return inappDefinition;
		}

		public static InappDefinition CreateLootboxDefinition(string lootboxId, int amount, int price)
		{
			InappDefinition inappDefinition = new InappDefinition();
			inappDefinition.id = lootboxId;
			inappDefinition.amount = amount;
			inappDefinition.price = price;
			inappDefinition.type = InAppType.Lootboxes;
			return inappDefinition;
		}
	}

	public enum Tab
	{
		Gold,
		Warbucks,
		Warcardpacks,
		Packs,
		Offers,
		Lootboxes,
		VIP
	}

	[Header("Core")]
	public GameObject closeButton;

	public GameObject backButton;

	public GameObject hiderForVipSale;

	[Header("Header Buttons")]
	public UITable buttonsTable;

	public List<InappButton> tabButtons;

	public InappButtonSpecial warcardsButton;

	public InappButtonSpecial lootboxButton;

	public UISprite leftHighlight;

	public UISprite rightHighlight;

	[Header("Contents")]
	public InappGold goldPart;

	public InappWarbucks warbucksPart;

	public InappCardPacks cardPacksPart;

	public InappPacks packsPart;

	public InappOffers offersPart;

	public InappLootboxes lootboxesPart;

	public InappVIP vipPart;

	[HideInInspector]
	public float dur = 0.2f;

	[HideInInspector]
	public string routeToStore = string.Empty;

	[HideInInspector]
	public bool converted;

	private Tab mActiveTab;

	public void ShowWarshopGold()
	{
		mActiveTab = Tab.Gold;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InappScreen>.instance, 0f);
		}
	}

	public void ShowWarshopWarbucks()
	{
		mActiveTab = Tab.Warbucks;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InappScreen>.instance, 0f);
		}
	}

	public void ShowCardPacks()
	{
		mActiveTab = Tab.Warcardpacks;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InappScreen>.instance, 0f);
		}
	}

	public void ShowPacks()
	{
		mActiveTab = Tab.Packs;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InappScreen>.instance, 0f);
		}
	}

	public void ShowOffers()
	{
		mActiveTab = Tab.Offers;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InappScreen>.instance, 0f);
		}
	}

	public void ShowLootboxes()
	{
		mActiveTab = Tab.Lootboxes;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InappScreen>.instance, 0f);
		}
	}

	public void ShowVIP()
	{
		mActiveTab = Tab.VIP;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<InappScreen>.instance, 0f);
		}
	}

	public override void InitEvents()
	{
		goldPart.gameObject.SetActive(value: false);
		warbucksPart.gameObject.SetActive(value: false);
		cardPacksPart.gameObject.SetActive(value: false);
		packsPart.gameObject.SetActive(value: false);
		offersPart.gameObject.SetActive(value: false);
		lootboxesPart.gameObject.SetActive(value: false);
		vipPart.gameObject.SetActive(value: false);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(backButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseWarshop));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseWarshop));
		rightHighlight.transform.localPosition = new Vector3(UIRoot.list[0].activeWidth - 48f, rightHighlight.transform.localPosition.y, 0f);
		RescaleTopButtonsLabels();
		tabButtons[0].Initialize(Localization.Localize("ID_WARSHOP_GOLD"), dur);
		tabButtons[1].Initialize(Localization.Localize("ID_WARSHOP_WARBUCKS"), dur);
		tabButtons[2].Initialize(Localization.Localize("ID_WARSHOP_CARDPACKS"), dur);
		tabButtons[3].Initialize(Localization.Localize("ID_WARSHOP_PACKS"), dur);
		tabButtons[4].Initialize(Localization.Localize("ID_WARSHOP_OFFERS"), dur);
		tabButtons[5].Initialize(Localization.Localize("ID_WARSHOP_LOOTBOXES"), dur);
		tabButtons[6].Initialize(string.Empty, dur);
		buttonsTable.repositionNow = true;
		buttonsTable.onReposition = delegate
		{
			SetHighlights();
		};
		foreach (InappButton tabButton in tabButtons)
		{
			UIEventListener uIEventListener3 = UIEventListener.Get(tabButton.gameObject);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HeaderButtonClick));
		}
		goldPart.InitControls();
		warbucksPart.InitControls();
		cardPacksPart.InitControls();
		packsPart.InitControls();
		offersPart.InitControls();
		lootboxesPart.InitControls();
		vipPart.InitControls();
	}

	private void CloseWarshop(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void HeaderButtonClick(GameObject go)
	{
		InappButton button = go.GetComponentsInChildren<InappButton>(includeInactive: true)[0];
		int num = tabButtons.FindIndex((InappButton a) => a == button);
		if (!tabButtons[num].pressed)
		{
			if (offersPart.numberOfOffers == 0 && tabButtons[4].gameObject.activeSelf)
			{
				AnimateHideOfferButton();
			}
			SelectTab((Tab)num);
		}
	}

	public override void InitGUIValues()
	{
		hiderForVipSale.SetActive(Singleton<OfferManager>.instance.DiscountedVIP() > 0);
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		warcardsButton.SetLocked(isWarcardsLocked);
		if (isWarcardsLocked && mActiveTab == Tab.Warcardpacks)
		{
			mActiveTab = Tab.Gold;
		}
		bool isLootboxesLocked = LevelManager.instance.isLootboxesLocked;
		lootboxButton.SetLocked(isLootboxesLocked);
		if (isLootboxesLocked && mActiveTab == Tab.Lootboxes)
		{
			mActiveTab = Tab.Gold;
		}
		ShowHideOffersButton();
		SelectTab(mActiveTab, instant: true);
	}

	private void ShowHideOffersButton()
	{
		tabButtons[4].gameObject.SetActive(offersPart.numberOfOffers > 0);
		buttonsTable.repositionNow = true;
	}

	private void AnimateHideOfferButton()
	{
		tabButtons[4].AnimatedHide();
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		GuiElementSingle<ChatGuiElement>.instance.HideRightContent();
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		GuiElementSingle<Background>.instance.parallax.SetActive(value: false);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		GuiScreen currentScreen = Singleton<GuiManager>.instance.currentScreen;
		GuiElementSingle<Background>.instance.ShowVariant(currentScreen.backgroundType);
		if (mActiveTab == Tab.Gold)
		{
			goldPart.Animate(showTab: false, instant: false);
		}
		if (mActiveTab == Tab.Warbucks)
		{
			warbucksPart.Animate(showTab: false, instant: false);
		}
		if (mActiveTab == Tab.Warcardpacks)
		{
			cardPacksPart.Animate(showTab: false, instant: false);
		}
		if (mActiveTab == Tab.Packs)
		{
			packsPart.Animate(showTab: false, instant: false);
		}
		if (mActiveTab == Tab.Offers)
		{
			offersPart.Animate(showTab: false, instant: false);
		}
		if (mActiveTab == Tab.Lootboxes)
		{
			lootboxesPart.Animate(showTab: false, instant: false);
		}
		if (mActiveTab == Tab.VIP)
		{
			vipPart.Animate(showTab: false, instant: false);
		}
		Singleton<EventTrackingManager>.instance.RegisterStoreVisitComplete(routeToStore, converted);
		converted = false;
		routeToStore = string.Empty;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		goldPart.InstantHideTab();
		warbucksPart.InstantHideTab();
		cardPacksPart.InstantHideTab();
		packsPart.InstantHideTab();
		offersPart.InstantHideTab();
		lootboxesPart.InstantHideTab();
		vipPart.InstantHideTab();
	}

	private void SelectTab(Tab selectedTab, bool instant = false)
	{
		mActiveTab = selectedTab;
		SetAndAnimateButtons(instant);
		SetAndAnimateHighlights(instant);
		SetAndAnimateContent(instant);
	}

	private void SetAndAnimateButtons(bool instant)
	{
		if (instant)
		{
			for (int i = 0; i < tabButtons.Count; i++)
			{
				tabButtons[i].InstantAnimate(i == (int)mActiveTab);
			}
			return;
		}
		tabButtons[0].Animate(toHighlight: false);
		tabButtons[1].Animate(toHighlight: false);
		tabButtons[2].Animate(toHighlight: false);
		tabButtons[3].Animate(toHighlight: false);
		tabButtons[4].Animate(toHighlight: false);
		tabButtons[5].Animate(toHighlight: false);
		tabButtons[6].Animate(toHighlight: false).onFinished = delegate
		{
			tabButtons[(int)mActiveTab].Animate(toHighlight: true);
		};
	}

	private void SetHighlights()
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float posX = tabButtons[(int)mActiveTab].posX;
		float width = tabButtons[(int)mActiveTab].width;
		float num = posX - width / 2f;
		float num2 = posX + width / 2f;
		float leftScale = Mathf.Max(28f, 28f + num - 60f);
		float rightScale = Mathf.Max(28f, 28f + (activeWidth - num2) - 60f);
		SetHighlights(leftScale, rightScale);
	}

	private void SetAndAnimateHighlights(bool instant)
	{
		float activeWidth = UIRoot.list[0].activeWidth;
		float posX = tabButtons[(int)mActiveTab].posX;
		float width = tabButtons[(int)mActiveTab].width;
		float num = posX - width / 2f;
		float num2 = posX + width / 2f;
		float leftScale = Mathf.Max(28f, 28f + num - 60f);
		float rightScale = Mathf.Max(28f, 28f + (activeWidth - num2) - 60f);
		bool showLeft = true;
		bool showRight = true;
		AnimateHighlights(showLeft, leftScale, showRight, rightScale, instant);
	}

	private void SetHighlights(float leftScale, float rightScale)
	{
		leftHighlight.transform.localScale = new Vector3(leftScale, leftHighlight.transform.localScale.y, 0f);
		rightHighlight.transform.localScale = new Vector3(rightScale, rightHighlight.transform.localScale.y, 0f);
	}

	private void AnimateHighlights(bool showLeft, float leftScale, bool showRight, float rightScale, bool instant)
	{
		if (instant)
		{
			SetHighlights(leftScale, rightScale);
			leftHighlight.alpha = ((!showLeft) ? 0f : 1f);
			rightHighlight.alpha = ((!showRight) ? 0f : 1f);
			TweenAlpha component = leftHighlight.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			TweenAlpha component2 = rightHighlight.gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.onFinished = null;
				component2.enabled = false;
			}
		}
		else
		{
			TweenAlpha.Begin(leftHighlight.gameObject, dur, 0f);
			TweenAlpha.Begin(rightHighlight.gameObject, dur, 0f).onFinished = delegate
			{
				SetHighlights(leftScale, rightScale);
				TweenAlpha.Begin(leftHighlight.gameObject, dur, (!showLeft) ? 0f : 1f);
				TweenAlpha.Begin(rightHighlight.gameObject, dur, (!showRight) ? 0f : 1f).onFinished = null;
			};
		}
	}

	private void SetAndAnimateContent(bool instant)
	{
		bool flag = mActiveTab == Tab.Gold;
		bool flag2 = mActiveTab == Tab.Warbucks;
		bool flag3 = mActiveTab == Tab.Warcardpacks;
		bool flag4 = mActiveTab == Tab.Packs;
		bool flag5 = mActiveTab == Tab.Offers;
		bool flag6 = mActiveTab == Tab.Lootboxes;
		bool flag7 = mActiveTab == Tab.VIP;
		if (instant)
		{
			goldPart.Animate(flag, instant: true);
			warbucksPart.Animate(flag2, instant: true);
			cardPacksPart.Animate(flag3, instant: true);
			packsPart.Animate(flag4, instant: true);
			offersPart.Animate(flag5, instant: true);
			lootboxesPart.Animate(flag6, instant: true);
			vipPart.Animate(flag7, instant: true);
			return;
		}
		if (goldPart.gameObject.activeSelf || flag)
		{
			goldPart.Animate(flag, instant: false);
		}
		if (warbucksPart.gameObject.activeSelf || flag2)
		{
			warbucksPart.Animate(flag2, instant: false);
		}
		if (cardPacksPart.gameObject.activeSelf || flag3)
		{
			cardPacksPart.Animate(flag3, instant: false);
		}
		if (packsPart.gameObject.activeSelf || flag4)
		{
			packsPart.Animate(flag4, instant: false);
		}
		if (offersPart.gameObject.activeSelf || flag5)
		{
			offersPart.Animate(flag5, instant: false);
		}
		if (lootboxesPart.gameObject.activeSelf || flag6)
		{
			lootboxesPart.Animate(flag6, instant: false);
		}
		if (vipPart.gameObject.activeSelf || flag7)
		{
			vipPart.Animate(flag7, instant: false);
		}
	}

	private void RescaleTopButtonsLabels()
	{
		float y = tabButtons[0].buttonName.transform.localScale.y;
		float num = Mathf.Max(tabButtons[0].iconWidth / y, tabButtons[0].buttonName.getSizeForString(Localization.Localize("ID_WARSHOP_GOLD")).x);
		float num2 = Mathf.Max(tabButtons[1].iconWidth / y, tabButtons[1].buttonName.getSizeForString(Localization.Localize("ID_WARSHOP_WARBUCKS")).x);
		float num3 = Mathf.Max(tabButtons[2].iconWidth / y, tabButtons[2].buttonName.getSizeForString(Localization.Localize("ID_WARSHOP_CARDPACKS")).x);
		float num4 = Mathf.Max(tabButtons[3].iconWidth / y, tabButtons[3].buttonName.getSizeForString(Localization.Localize("ID_WARSHOP_PACKS")).x);
		float num5 = Mathf.Max(tabButtons[4].iconWidth / y, tabButtons[4].buttonName.getSizeForString(Localization.Localize("ID_WARSHOP_OFFERS")).x);
		float num6 = Mathf.Max(tabButtons[5].iconWidth / y, tabButtons[5].buttonName.getSizeForString(Localization.Localize("ID_WARSHOP_LOOTBOXES")).x);
		float num7 = num + num2 + num3 + num4 + num5 + num6;
		float num8 = UIRoot.list[0].activeWidth - 946f;
		float num9 = Mathf.Clamp(Mathf.Floor(num8 / num7), 20f, y);
		for (int i = 0; i < tabButtons.Count; i++)
		{
			tabButtons[i].buttonName.transform.localScale = new Vector3(num9, num9, 1f);
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseWarshop(backButton);
	}
}
