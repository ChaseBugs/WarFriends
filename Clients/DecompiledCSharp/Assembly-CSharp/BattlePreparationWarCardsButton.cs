using System;
using System.Collections;
using UnityEngine;

public class BattlePreparationWarCardsButton : Core_BaseScript
{
	[Header("Core")]
	public GameObject cardsButton;

	public BoxCollider cardsCollider;

	[Header("-Sale Part")]
	public GameObject warcardSalePart;

	public UILabel warcardSalePercent;

	public UISprite warcardSaleBottomBackground;

	public UILabel warcardSaleBottom;

	[Header("-Available Now")]
	public GameObject freeWarcardPart;

	public UISprite freeWarcardBackground;

	public UILabel freeWarcardLabel;

	public UILabel freeWarcardBottomLabel;

	[Header("-Crafting Part")]
	public GameObject craftingWarcardPart;

	public UISprite progressWarcard;

	public UILabel progressWarcardLabel;

	[Header("-Notification")]
	public GameObject notificationWarcardGO;

	[Header("-Locked")]
	public UILabel warcardsButtonLabel;

	public UISprite warcardsLockedGlow;

	public UISprite warcardsLockedIcon;

	public UISprite[] warcardsIcons;

	public UILabel warcardsLockedLabel;

	private RadicalRoutine mUpdatingWarcard;

	private int mLastRemainingTimeWarcard;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(cardsButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (notificationWarcardGO.activeSelf)
			{
				GuiScreenSingle<CardMenuScreen>.instance.ShowCraftCards();
			}
			else if (freeWarcardPart.activeSelf)
			{
				GuiScreenSingle<CardMenuScreen>.instance.ShowMyWarcards();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
			}
		});
	}

	public void InitGUIValues()
	{
		SetWarcardButton();
		NotificationWarcard(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	public void DoAfterHide()
	{
		StopWarCardUpdate();
	}

	public void SaleCardPacks()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(CardPack.Gold);
		bool flag3 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(CardPack.Silver);
		bool flag4 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(CardPack.Bronze);
		warcardSalePart.SetActive(flag || flag2 || flag3 || flag4);
		if (flag)
		{
			warcardSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", Singleton<OfferManager>.instance.DiscountedCardpack(CardPack.Gold));
			warcardSaleBottom.text = Localization.Localize("ID_CARDPACKS");
		}
		else if (flag2)
		{
			warcardSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", Singleton<OfferManager>.instance.DiscountedCardpack(CardPack.Gold));
			warcardSaleBottom.text = Localization.Localize("ID_GOLDPACK");
		}
		else if (flag3)
		{
			warcardSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", Singleton<OfferManager>.instance.DiscountedCardpack(CardPack.Silver));
			warcardSaleBottom.text = Localization.Localize("ID_SILVERPACK");
		}
		else if (flag4)
		{
			warcardSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", Singleton<OfferManager>.instance.DiscountedCardpack(CardPack.Bronze));
			warcardSaleBottom.text = Localization.Localize("ID_BRONZEPACK");
		}
		warcardSaleBottomBackground.transform.localScale = new Vector3(warcardSaleBottom.relativeSize.x * warcardSaleBottom.transform.localScale.x + 40f, warcardSaleBottomBackground.transform.localScale.y, 1f);
	}

	public void InitBlank()
	{
		freeWarcardPart.SetActive(value: false);
		craftingWarcardPart.SetActive(value: false);
		NotificationWarcard(show: false);
	}

	private void StartWarCardUpdate()
	{
		StopWarCardUpdate();
		mUpdatingWarcard = RadicalRoutine.Create(UpdateWarCardRoutine());
		StartCoroutine(RadicalRoutine.Run(mUpdatingWarcard.enumerator));
	}

	private void StopWarCardUpdate()
	{
		if (mUpdatingWarcard != null)
		{
			mUpdatingWarcard.Cancel();
			mUpdatingWarcard = null;
		}
	}

	private IEnumerator UpdateWarCardRoutine()
	{
		while (CardCraftingManager.instance.isCardCrafting)
		{
			progressWarcard.fillAmount = CardCraftingManager.instance.craftingProgress;
			progressWarcard.color = Colours.cyan;
			SetUpCraftingWarcardLabel(CardCraftingManager.instance.remainingSeconds);
			yield return new WaitForRealSeconds(0.333f);
		}
		progressWarcard.fillAmount = 1f;
		progressWarcard.color = Colours.blue;
		progressWarcardLabel.text = Localization.Localize("ID_WARCARDREADY");
		progressWarcardLabel.alpha = 1f;
		TweenAlpha.Begin(progressWarcardLabel.gameObject, 0.01f, 1f);
		NotificationWarcard(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	private void SetUpCraftingWarcardLabel(int remainingTime, bool instant = false)
	{
		if (mLastRemainingTimeWarcard > remainingTime)
		{
			mLastRemainingTimeWarcard = remainingTime;
			switch (remainingTime % 6)
			{
			case 5:
				progressWarcardLabel.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
				TweenAlpha.Begin(progressWarcardLabel.gameObject, (!instant) ? 1f : 0.01f, 0f);
				break;
			case 4:
				progressWarcardLabel.text = Localization.Localize("ID_CRAFTING");
				TweenAlpha.Begin(progressWarcardLabel.gameObject, (!instant) ? 1f : 0.01f, 1f);
				break;
			case 3:
				progressWarcardLabel.text = Localization.Localize("ID_CRAFTING");
				break;
			case 2:
				progressWarcardLabel.text = Localization.Localize("ID_CRAFTING");
				TweenAlpha.Begin(progressWarcardLabel.gameObject, (!instant) ? 1f : 0.01f, 0f);
				break;
			case 1:
				progressWarcardLabel.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
				TweenAlpha.Begin(progressWarcardLabel.gameObject, (!instant) ? 1f : 0.01f, 1f);
				break;
			case 0:
				progressWarcardLabel.text = MiscTools.PrintableTime(remainingTime, "ID_READYTIME", string.Empty);
				break;
			}
		}
	}

	private void NotificationWarcard(bool show)
	{
		notificationWarcardGO.SetActive(show);
	}

	public void SetUpFreeWarcard()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = !Singleton<GameController>.instance.isTutorial && !isWarcardsLocked && Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.RandomCard);
		freeWarcardPart.SetActive(flag);
		if (flag)
		{
			freeWarcardBackground.transform.localScale = new Vector3(freeWarcardLabel.relativeSize.x * freeWarcardLabel.transform.localScale.x + 20f, freeWarcardBackground.transform.localScale.y, 1f);
			bool activeSelf = craftingWarcardPart.activeSelf;
			freeWarcardPart.transform.localPosition = new Vector3(0f, (!activeSelf) ? 0f : (-100f), 0f);
			freeWarcardBottomLabel.gameObject.SetActive(!activeSelf);
		}
	}

	private void SetWarcardButton()
	{
		StopWarCardUpdate();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		warcardsButtonLabel.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		warcardsLockedGlow.gameObject.SetActive(isWarcardsLocked);
		warcardsLockedIcon.gameObject.SetActive(isWarcardsLocked);
		warcardsLockedLabel.gameObject.SetActive(isWarcardsLocked);
		cardsCollider.enabled = !isWarcardsLocked;
		for (int i = 0; i < warcardsIcons.Length; i++)
		{
			warcardsIcons[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			warcardsLockedLabel.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), warcardsUnlockLevel);
			MiscTools.SetUILabelRescale(warcardsLockedLabel, 30f, 20f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 18);
			craftingWarcardPart.SetActive(value: false);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			craftingWarcardPart.SetActive(value: true);
			mLastRemainingTimeWarcard = int.MaxValue;
			progressWarcard.fillAmount = CardCraftingManager.instance.craftingProgress;
			progressWarcard.color = Colours.cyan;
			SetUpCraftingWarcardLabel(CardCraftingManager.instance.remainingSeconds);
			StartWarCardUpdate();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			craftingWarcardPart.SetActive(value: true);
			mLastRemainingTimeWarcard = 0;
			progressWarcard.fillAmount = 1f;
			progressWarcard.color = Colours.blue;
			progressWarcardLabel.text = Localization.Localize("ID_WARCARDREADY");
			progressWarcardLabel.alpha = 1f;
			TweenAlpha.Begin(progressWarcardLabel.gameObject, 0.01f, 1f);
		}
		else
		{
			craftingWarcardPart.SetActive(value: false);
		}
		SetUpFreeWarcard();
	}
}
