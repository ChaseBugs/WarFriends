using System;
using System.Collections.Generic;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class ArmyLeftBuffDialog : Core_BaseScript
{
	[Header("Core")]
	public UIPanel eliteDialogPanel;

	public GameObject elitePart;

	public UILabel eliteTitle;

	public UILabel eliteLevelLabel;

	public ArmyElitePerkHint elitePerkHint;

	public UISprite eliteBorder;

	public UISprite eliteStatisticsBackground;

	public ArmyPowerAnimation armyPowerEliteAnimation;

	[Header("Not implemented")]
	public GameObject notSupported;

	[Header("Implemented")]
	public GameObject supported;

	public UILabel eliteDescription;

	public ArmyUnitStatistics unitEliteStatistic;

	[Header("-Progress Bar")]
	public ArmyLeftBuffProgress progressPart;

	[Header("-Convert to Scraps")]
	public GameObject buffButtonConvertToScrapsPart;

	[Header("-Convert to Parts")]
	public GameObject buffButtonConvertToPartsPart;

	public UILabel buffButtonConvertToPartsHint;

	public UITable buffButtonConvertToPartsTable;

	public UILabel buffButtonConvertToPartsLabel;

	public UISprite[] buffButtonConvertToPartsSprites;

	public UISprite buffButtonConvertToPartsHighlight;

	public TweenAlpha buffButtonConvertToPartsHighlightTween;

	[Header("-Activate")]
	public GameObject buffButtonActivatePart;

	[Header("-Upgrade")]
	public GameObject buffButtonUpgradePart;

	public UITable buffButtonUpgradeTable;

	public UILabel buffButtonUpgradeLabel;

	public GameObject buffButtonUpgradeSalePart;

	public UILabel buffButtonUpgradeSalePercent;

	public WinStreakCounter buffButtonUpgradeSaleTimeCounter;

	[Header("-Max")]
	public GameObject buffButtonMaxPart;

	public UILabel buffButtonMaxLabel;

	private LevelBehaviour mUnit;

	private bool mDialogOpened;

	private float mDur = 0.3f;

	private bool mAnimating;

	private bool mCanBuyParts;

	private bool mButtonClicked;

	private bool mSpecialButtonClicked;

	public void ShowDialog()
	{
		if (mDialogOpened)
		{
			return;
		}
		mDialogOpened = true;
		mButtonClicked = false;
		mSpecialButtonClicked = false;
		elitePart.SetActive(value: true);
		eliteDialogPanel.alpha1 = 0.0005f;
		TweenAlpha.Begin(eliteDialogPanel.gameObject, mDur, 1f);
		TweenPosition.Begin(elitePart, mDur / 2f, new Vector3(-40f, 0f, 0f), new Vector3(40f, 0f, 0f)).onFinished = delegate
		{
			if (mDialogOpened)
			{
				TweenPosition.Begin(elitePart, mDur / 2f, new Vector3(0f, 0f, 0f)).onFinished = null;
			}
		};
		SetEliteIcon();
		ChangeLeftContent();
		ResetDialogueButtons();
		UIPanel[] componentsInChildren = elitePart.GetComponentsInChildren<UIPanel>(includeInactive: false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, mDur, 1f).onFinished = null;
		}
	}

	public void HideDialog()
	{
		if (!mDialogOpened)
		{
			return;
		}
		mDialogOpened = false;
		TweenAlpha.Begin(eliteDialogPanel.gameObject, mDur, 0f);
		TweenPosition.Begin(elitePart, mDur / 2f, new Vector3(40f, 0f, 0f)).onFinished = delegate
		{
			if (!mDialogOpened)
			{
				elitePart.SetActive(value: false);
			}
		};
		UIPanel[] componentsInChildren = elitePart.GetComponentsInChildren<UIPanel>(includeInactive: false);
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, mDur, 0f).onFinished = null;
		}
	}

	public void SelectUnit(LevelBehaviour selectedUnit)
	{
		mUnit = selectedUnit;
		bool isUnlocked = selectedUnit.upgradeSlots.upgradeSlotElite.isUnlocked;
		elitePerkHint.gameObject.SetActive(isUnlocked);
		if (isUnlocked)
		{
			elitePerkHint.Initialize(selectedUnit);
		}
	}

	public void InitControls()
	{
		Singleton<Wallet>.instance.ScrapsChanged += OnScrapsChanged;
		UIEventListener uIEventListener = UIEventListener.Get(buffButtonConvertToScrapsPart);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BuffButtonConvertToScrapsClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(buffButtonConvertToPartsPart);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BuffButtonConvertToPartsClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(buffButtonActivatePart);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BuffButtonActivateClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(buffButtonUpgradePart);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(BuffButtonUpgradeClick));
		buffButtonConvertToPartsTable.onReposition = delegate
		{
			float val = 0f - buffButtonConvertToPartsTable.padding.x - (buffButtonConvertToPartsLabel.transform.parent.transform.localPosition.x - buffButtonConvertToPartsTable.padding.x) / 2f;
			buffButtonConvertToPartsTable.transform.localPosition = buffButtonConvertToPartsTable.transform.localPosition.ReplaceX(val);
		};
		buffButtonUpgradeTable.onReposition = delegate
		{
			float val = 0f - buffButtonUpgradeTable.padding.x - (buffButtonUpgradeLabel.transform.parent.transform.localPosition.x - buffButtonUpgradeTable.padding.x) / 2f;
			buffButtonUpgradeTable.transform.localPosition = buffButtonUpgradeTable.transform.localPosition.ReplaceX(val);
		};
		elitePerkHint.InitControls();
	}

	private void OnScrapsChanged(long newValue, long difference)
	{
		if (!mAnimating)
		{
			ChangeLeftContent();
			ResetDialogueButtons();
		}
	}

	private void BuffButtonConvertToScrapsClick(GameObject go)
	{
		if (progressPart.isAnimatingSpend)
		{
			return;
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiElementSingle<ConvertToScrapsDialog>.instance.ShowDialog(mUnit, delegate(bool dialogResponse)
		{
			if (dialogResponse)
			{
				mAnimating = true;
				int currentParts = mUnit.upgradeSlots.upgradeSlotElite.currentParts;
				ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.PartToScrapsSell).FLOATVALUE;
				int num = (int)((float)currentParts * (float)fLOATVALUE);
				RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
				requestBuffer.AddRequest(DatabaseAction.ConvertPartsToScraps, JsonConvert.SerializeObject(new Dictionary<string, object>
				{
					{
						"LevelName",
						mUnit.upgradeSlots.GetSheetName()
					},
					{ "PartsToConvert", currentParts },
					{ "Scraps", num }
				}), 0, 0, string.Empty);
				Singleton<Wallet>.instance.AddScraps(num);
				mUnit.upgradeSlots.upgradeSlotElite.currentParts = 0;
				mButtonClicked = true;
				UpdateLeftContent();
			}
		});
	}

	private void BuffButtonConvertToPartsClick(GameObject go)
	{
		if (!progressPart.isAnimatingSpend)
		{
			mAnimating = true;
			int missingScraps = mUnit.upgradeSlots.upgradeSlotElite.missingScraps;
			int upgradePriceParts = mUnit.upgradeSlots.upgradeSlotElite.upgradePriceParts;
			int currentParts = mUnit.upgradeSlots.upgradeSlotElite.currentParts;
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.ConvertScrapsToParts, mUnit.upgradeSlots.GetSheetName(), 0, 0, string.Empty);
			Singleton<EventTrackingManager>.instance.RegisterPartsGainedFromScraps(mUnit.upgradeSlots.GetSheetName(), upgradePriceParts - currentParts);
			Singleton<Wallet>.instance.ScrapsSpent(missingScraps);
			mUnit.upgradeSlots.upgradeSlotElite.currentParts = upgradePriceParts;
			SoundsManager.Instance.PlayButtonClickedSound();
			DisableClickOnButton(buffButtonConvertToPartsPart);
			mButtonClicked = true;
			UpdateLeftContent();
		}
	}

	private void BuffButtonActivateClick(GameObject go)
	{
		mAnimating = true;
		int armyPowerX = LevelManager.instance.armyPowerX10;
		GuiScreenSingle<ArmyScreen>.instance.BuyUnitElite(mUnit);
		DisableClickOnButton(buffButtonActivatePart);
		AnimateArmyPowerBuff(armyPowerX);
		AnimateRestOfScreen();
		mSpecialButtonClicked = true;
		progressPart.AnimateSpend(0.6f);
	}

	private void BuffButtonUpgradeClick(GameObject go)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		int num = Singleton<OfferManager>.instance.DiscountedUnit(mUnit, OfferBuyType.Upgrade);
		int num2 = mUnit.upgradeSlots.upgradeSlotElite.upgradePrice * (100 - num) / 100;
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, mUnit.unitName, (!mUnit.isSoldier) ? NotEnoughDialog.Type.UPGRADEELITE : NotEnoughDialog.Type.TRAINELITE);
			return;
		}
		mAnimating = true;
		Singleton<Wallet>.instance.WarBucksSpentFake(num2);
		GuiScreenSingle<ArmyScreen>.instance.UpgradeUnitElite(mUnit, num);
		DisableClickOnButton(buffButtonUpgradePart);
		AnimateArmyPowerBuff(armyPowerX);
		AnimateRestOfScreen();
		mSpecialButtonClicked = true;
		progressPart.AnimateSpend(0.6f);
	}

	public void UpdateLeftContent(bool changedUnit = true)
	{
		if (!mDialogOpened)
		{
			mAnimating = false;
			ChangeLeftContent();
		}
		else if (changedUnit)
		{
			mAnimating = false;
			ChangeLeftContent();
			ResetDialogueButtons();
		}
		else if (mButtonClicked || mSpecialButtonClicked)
		{
			TweenAlpha tweenAlpha = AnimateHideDialogButton();
			if (tweenAlpha == null)
			{
				ChangeLeftContent();
				ResetDialogueButtons();
			}
			else
			{
				mAnimating = true;
				if (mSpecialButtonClicked)
				{
					tweenAlpha.onFinished = delegate
					{
						mAnimating = false;
					};
				}
				else
				{
					tweenAlpha.onFinished = delegate
					{
						ChangeLeftContent();
						ResetDialogueButtons(setAlphaToOne: false);
						TweenAlpha tweenAlpha2 = AnimateShowDialogButton();
						if (tweenAlpha2 != null)
						{
							tweenAlpha2.onFinished = delegate
							{
								mAnimating = false;
							};
						}
						else
						{
							mAnimating = false;
						}
					};
				}
			}
			mButtonClicked = false;
		}
		else
		{
			BuffInfoUpdate();
		}
	}

	public void InitGUIValues()
	{
		elitePerkHint.InitGUIValues();
	}

	private void SetEliteIcon()
	{
		if (elitePart.activeSelf)
		{
			unitEliteStatistic.InitializeEliteIcon(mUnit);
		}
	}

	private void ChangeLeftContent()
	{
		UpgradeSlotElite upgradeSlotElite = mUnit.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		bool flag = isUnlocked && upgradeSlotElite.isMaxUpgraded;
		bool flag2 = isUnlocked && upgradeSlotElite.isBought;
		bool flag3 = isUnlocked && upgradeSlotElite.currentParts >= upgradeSlotElite.upgradePriceParts;
		bool flag4 = isUnlocked && upgradeSlotElite.currentParts > 0;
		GuiScreenSingle<ArmyScreen>.instance.armyLeftContent.UpdateProgresses();
		BuffInfoUpdate();
		buffButtonConvertToScrapsPart.SetActive(flag2 && flag4);
		buffButtonConvertToPartsPart.SetActive(!flag && !flag3);
		buffButtonActivatePart.SetActive(!flag2 && flag3);
		buffButtonUpgradePart.SetActive(flag2 && !flag && flag3);
		buffButtonMaxPart.SetActive(flag2 && flag);
	}

	private void BuffInfoUpdate()
	{
		mCanBuyParts = false;
		UpgradeSlotElite upgradeSlotElite = mUnit.upgradeSlots.upgradeSlotElite;
		bool isUnlocked = upgradeSlotElite.isUnlocked;
		bool flag = isUnlocked && mUnit.upgradeSlots.bought && upgradeSlotElite.isBought;
		notSupported.SetActive(!isUnlocked);
		supported.SetActive(isUnlocked);
		int num = (isUnlocked ? upgradeSlotElite.boughtIndex : 0);
		int num2 = (isUnlocked ? upgradeSlotElite.actualMaxLevel : 0);
		eliteTitle.text = Localization.Localize((!isUnlocked || !flag) ? "ID_BUFF" : "ID_UPGRADE");
		eliteBorder.transform.localScale = eliteBorder.transform.localScale.ReplaceY((!isUnlocked) ? 640f : 823f);
		eliteStatisticsBackground.transform.localScale = eliteStatisticsBackground.transform.localScale.ReplaceY((!isUnlocked) ? 382f : 568f);
		eliteLevelLabel.text = ((!isUnlocked) ? Localization.Localize("ID_NOTAVAILABLEATTHEMOMENT") : $"{mUnit.unitBuffName} {num} {Colours.stringGray}/ {num2}[-]");
		if (isUnlocked)
		{
			Tuple<string, float[]> statistic = upgradeSlotElite.guiStatistics[0];
			int currentParts = upgradeSlotElite.currentParts;
			int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
			long scraps = Singleton<Wallet>.instance.scraps;
			int missingScraps = upgradeSlotElite.missingScraps;
			mCanBuyParts = scraps >= missingScraps;
			eliteDescription.text = mUnit.GetBuffDescriptionWithColours(Colours.stringGrayAbi2);
			SetEliteIcon();
			unitEliteStatistic.InitializeElite(statistic, flag);
			progressPart.Initialize(mUnit);
			SetEliteSaleAndPrize();
			buffButtonConvertToPartsHint.text = ((upgradePriceParts <= currentParts) ? string.Empty : Localization.LocalizeFormat("ID_CONVERTSCRAPSTOELITEPARTS", Colours.stringGreenArena, MiscTools.FormatBigNumber(upgradePriceParts - currentParts)));
			MiscTools.SetUILabelRescale(buffButtonConvertToPartsHint, 25f, 20f, 530);
			buffButtonConvertToPartsLabel.text = $"{scraps} {Colours.stringWhite}/[-] {missingScraps}";
			buffButtonConvertToPartsTable.repositionNow = true;
			buffButtonConvertToPartsSprites[0].color = ((!mCanBuyParts) ? Colours.grayButton : Color.white);
			buffButtonConvertToPartsSprites[1].color = ((!mCanBuyParts) ? Colours.grayButton : Color.white);
			buffButtonConvertToPartsHighlightTween.enabled = mCanBuyParts;
			if (!mCanBuyParts)
			{
				buffButtonConvertToPartsHighlight.alpha = 0f;
			}
			buffButtonMaxLabel.text = Localization.Localize((!mUnit.isSoldier) ? "ID_UNITELITEPERKFULLYUPGRADED" : "ID_UNITELITEPERKFULLYTRAINED");
		}
	}

	public void SetEliteSaleAndPrize()
	{
		if (!(mUnit == null) && mUnit.upgradeSlots.upgradeSlotElite.isBought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedUnit(mUnit, OfferBuyType.Upgrade);
			int num2 = mUnit.upgradeSlots.upgradeSlotElite.upgradePrice;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (100 - num) / 100;
			}
			buffButtonUpgradeLabel.text = MiscTools.FormatBigNumber(num2);
			buffButtonUpgradeTable.repositionNow = true;
			buffButtonUpgradeSalePart.SetActive(flag);
			if (flag)
			{
				buffButtonUpgradeSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
				buffButtonUpgradeSaleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedUnitEndtime(mUnit, OfferBuyType.Upgrade), upperCaseCountdown: true);
				WinStreakCounter winStreakCounter = buffButtonUpgradeSaleTimeCounter;
				winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(SetEliteSaleAndPrize));
				WinStreakCounter winStreakCounter2 = buffButtonUpgradeSaleTimeCounter;
				winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(SetEliteSaleAndPrize));
			}
			else
			{
				buffButtonUpgradeSaleTimeCounter.StopCountingTo();
				WinStreakCounter winStreakCounter3 = buffButtonUpgradeSaleTimeCounter;
				winStreakCounter3.winStreakTimer = (Action)Delegate.Remove(winStreakCounter3.winStreakTimer, new Action(SetEliteSaleAndPrize));
			}
		}
	}

	private void ResetDialogueButtons(bool setAlphaToOne = true)
	{
		if (elitePart.activeSelf)
		{
			ResetButton(buffButtonConvertToPartsPart, setAlphaToOne, mCanBuyParts);
			ResetButton(buffButtonActivatePart, setAlphaToOne);
			ResetButton(buffButtonUpgradePart, setAlphaToOne);
			ResetButton(buffButtonMaxPart, setAlphaToOne);
		}
	}

	private void ResetButton(GameObject button, bool setAlphaToOne = true, bool enableCollider = true)
	{
		if (!button.activeInHierarchy)
		{
			return;
		}
		BoxCollider component = button.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = enableCollider;
		}
		if (setAlphaToOne)
		{
			UIPanel component2 = button.GetComponent<UIPanel>();
			if (component2 != null && GuiScreenSingle<ArmyScreen>.instance.isFullyShowed)
			{
				component2.alpha1 = 1f;
			}
		}
		TweenAlpha component3 = button.GetComponent<TweenAlpha>();
		if (component3 != null)
		{
			component3.enabled = false;
			component3.onFinished = null;
		}
	}

	private void DisableClickOnButton(GameObject button)
	{
		if (button.activeInHierarchy)
		{
			BoxCollider component = button.GetComponent<BoxCollider>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
	}

	private void AnimateArmyPowerBuff(int previousArmyPowerX10)
	{
		if (mUnit.upgradeSlots.equipped)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int changeNumber = armyPowerX - previousArmyPowerX10;
			Debug.LogFormat("Army Power Buff Animation from {0} to {1}", previousArmyPowerX10, armyPowerX);
			armyPowerEliteAnimation.StartAnimation(changeNumber, armyPowerX, 0.05f);
		}
	}

	public void DoAfterHide()
	{
		buffButtonUpgradeSaleTimeCounter.StopCountingTo();
		WinStreakCounter winStreakCounter = buffButtonUpgradeSaleTimeCounter;
		winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(SetEliteSaleAndPrize));
		elitePerkHint.DoAfterHide();
	}

	public void InstantHideUpgrades()
	{
		mDialogOpened = false;
		mAnimating = false;
		elitePart.SetActive(value: false);
	}

	private void AnimateRestOfScreen()
	{
		unitEliteStatistic.AnimateStat();
		GuiScreenSingle<ArmyScreen>.instance.armyRightContent.AnimateUnitPower();
		GuiScreenSingle<ArmyScreen>.instance.AnimateUpgrade();
	}

	private TweenAlpha AnimateHideDialogButton()
	{
		return AnimateDialogButton(0f);
	}

	private TweenAlpha AnimateShowDialogButton()
	{
		return AnimateDialogButton(1f);
	}

	private TweenAlpha AnimateDialogButton(float toAlpha)
	{
		TweenAlpha tweenAlpha = buffButtonConvertToPartsPart.GetComponent<TweenAlpha>();
		bool flag = false;
		if (elitePart.activeSelf && mAnimating)
		{
			if (buffButtonConvertToPartsPart.activeSelf)
			{
				tweenAlpha = AnimateButton(buffButtonConvertToPartsPart, toAlpha);
				flag = true;
			}
			if (buffButtonActivatePart.activeSelf)
			{
				tweenAlpha = AnimateButton(buffButtonActivatePart, toAlpha);
				flag = true;
			}
			if (buffButtonUpgradePart.activeSelf)
			{
				tweenAlpha = AnimateButton(buffButtonUpgradePart, toAlpha);
				flag = true;
			}
			if (buffButtonMaxPart.activeSelf)
			{
				tweenAlpha = AnimateButton(buffButtonMaxPart, toAlpha);
				flag = true;
			}
		}
		return (!flag) ? null : tweenAlpha;
	}

	private TweenAlpha AnimateButton(GameObject button, float toAlpha)
	{
		if (!button.activeInHierarchy)
		{
			return null;
		}
		return TweenAlpha.Begin(button, mDur, toAlpha);
	}
}
