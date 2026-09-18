using System;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxDialog : GuiElementSingle<LootBoxDialog>, IGuiDialog
{
	[Header("Initial Animation")]
	public GameObject startingTitle;

	public UILabel beginTitle;

	public GameObject swipePart;

	public UILabel swipeLabel;

	public UISprite[] swipeArrows;

	[Header("Top Part")]
	public UILabel visualNameLabel;

	public UILabel visualRarityLabel;

	[Header("Top Right Part")]
	public GameObject multipleBoxes;

	public UILabel boxesCountLabel;

	public GameObject openAllBoxesButton;

	[Header("Center Part")]
	public UISprite flash;

	public UISprite flash2;

	[Header("-Parts Part")]
	public GameObject partsObject;

	public UISprite visualIcon;

	public UISprite partsIcon;

	public UILabel visualPartsIncreaseLabel;

	public UILabel visualPartsCountLabel;

	[Header("-Duplicate Part")]
	public GameObject lootDuplicatePart;

	public UILabel duplicateHeaderLabel;

	public UILabel duplicateWarbucksLabel;

	[Header("-Visual Completed Part")]
	public GameObject visualCompletedPart;

	public UILabel visualCompleted;

	public GameObject visualEquipButton;

	public UILabel visualEquipLabel;

	public UISprite visualEquipIcon;

	public UISprite visualEquipBackground;

	public UISprite visualEquippedIconInside;

	public UISprite visualEquippedIconBigger;

	public UISprite visualEquippedBackground;

	[Header("Bottom Left Part")]
	public GameObject equipButton;

	public UILabel equipLabel;

	public UISprite equipIcon;

	public UISprite equipBackground;

	public UISprite equippedIconInside;

	public UISprite equippedIconBigger;

	public UISprite equippedBackground;

	[Header("Bottom Part")]
	public GameObject newLootcrateButton;

	public UILabel videoHintLabel;

	[Header("Bottom Right Part")]
	public GameObject continueButton;

	public UILabel hintNextLootcrateLabel;

	public GameObject nextLootcrateButton;

	[Header("Particles")]
	public ParticleSystem characterUpParticles;

	public ParticleSystem characterDownParticles;

	private float mDur = 0.13f;

	private float mSpeed = 2f;

	private float mBlickSpeed = 0.7f;

	private List<LootboxContent> mLootboxes;

	private int mIndexNumber;

	private bool mIsBought;

	private bool mUnlocked;

	private bool mVideoLoaded;

	private bool mCheckSwipe;

	private bool mSkippable;

	private bool mArmyCameraShown;

	private bool mWeaponCameraShown;

	private bool mShowAdButton = true;

	private static Dictionary<int, Tuple<string, string>> mCategoryPart = new Dictionary<int, Tuple<string, string>>
	{
		{
			0,
			new Tuple<string, string>("ID_VISUALCATEGORYPART0", "ID_VISUALCATEGORYPARTS0")
		},
		{
			1,
			new Tuple<string, string>("ID_VISUALCATEGORYPART1", "ID_VISUALCATEGORYPARTS1")
		},
		{
			2,
			new Tuple<string, string>("ID_VISUALCATEGORYPART2", "ID_VISUALCATEGORYPARTS2")
		}
	};

	private bool mShowContinue => mLootboxes.Count < 2 || mIndexNumber + 1 == mLootboxes.Count;

	public void ShowDialogMoreBoxes(List<LootboxContent> lootboxes, bool showVideoButton = true)
	{
		mLootboxes = lootboxes;
		mIndexNumber = 0;
		mShowAdButton = showVideoButton;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(openAllBoxesButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OpenAllClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(equipButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EquipClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(visualEquipButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EquipCenterClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(newLootcrateButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(WatchVideoClick));
		UIEventListener uIEventListener5 = UIEventListener.Get(continueButton);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(ContinueClick));
		UIEventListener uIEventListener6 = UIEventListener.Get(nextLootcrateButton);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NextLootcrateClick));
		InitializeEquipLabel();
		InitializeCenterEquipLabel();
	}

	private void OpenAllClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		HideDialog();
		if (!(go == openAllBoxesButton))
		{
			return;
		}
		int num = 0;
		string text = "Opening all lootboxes:\n";
		for (int i = mIndexNumber; i < mLootboxes.Count; i++)
		{
			int num2 = GuiScreenSingle<CamosScreen>.instance.AddParts(mLootboxes[i].playerVisual, mLootboxes[i].parts);
			if (num2 > 0)
			{
				text += $"Visual {mLootboxes[i].playerVisual.name}, overcount {num2}, duplicate wb {num2 * mLootboxes[i].playerVisual.duplicateWarbucks}\n";
				num += num2 * mLootboxes[i].playerVisual.duplicateWarbucks;
			}
			else
			{
				text += $"Visual {mLootboxes[i].playerVisual.name}, no overcount";
			}
		}
		Debug.Log(text + "duplicate WB " + num);
		Singleton<Wallet>.instance.AddWarBucksReward(num);
		if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<EndScreen>.instance)
		{
			GuiScreenSingle<EndScreen>.instance.results.AddLootboxReward(num);
		}
		GuiScreenSingle<CamosScreen>.instance.SelectVisual(mLootboxes[mIndexNumber].playerVisual);
		if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<CamosScreen>.instance)
		{
			GuiScreenSingle<CamosScreen>.instance.InitGUIValues();
			return;
		}
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		GuiScreenSingle<CamosScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
	}

	private void EquipClick(GameObject go)
	{
		if (!mLootboxes[mIndexNumber].playerVisual.isEquipped)
		{
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(mLootboxes[mIndexNumber].playerVisual);
			AnimateEquip();
		}
	}

	private void EquipCenterClick(GameObject go)
	{
		if (!mLootboxes[mIndexNumber].playerVisual.isEquipped)
		{
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(mLootboxes[mIndexNumber].playerVisual);
			AnimateCenterEquip();
		}
	}

	private void WatchVideoClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			AddVisualPartsOrWarbucks(mLootboxes[mIndexNumber]);
			if (GuiScreenSingle<EndScreen>.instance.isShowed)
			{
				GuiScreenSingle<EndScreen>.instance.videoRewardLootbox = null;
				GuiScreenSingle<EndScreen>.instance.shouldGetLootboxForAd = true;
			}
			Singleton<EventTrackingManager>.instance.ShowRewardedVideo(RewardType.LootBox);
			HideDialog();
		}
	}

	private void ContinueClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			AddVisualPartsOrWarbucks(mLootboxes[mIndexNumber]);
			if (GuiScreenSingle<CamosScreen>.instance.isShowed)
			{
				GuiScreenSingle<CamosScreen>.instance.InitGUIValues();
			}
			HideDialog();
		}
	}

	private void NextLootcrateClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			AddVisualPartsOrWarbucks(mLootboxes[mIndexNumber]);
			TweenPosition component = nextLootcrateButton.GetComponent<TweenPosition>();
			if (component != null)
			{
				component.enabled = false;
			}
			nextLootcrateButton.transform.localPosition = nextLootcrateButton.transform.localPosition.ReplaceX(270f);
			mIndexNumber++;
			InitGUIValues();
			ShowInitialAnimation();
		}
	}

	private void AddVisualPartsOrWarbucks(LootboxContent loot)
	{
		int num = GuiScreenSingle<CamosScreen>.instance.AddParts(loot.playerVisual, loot.parts);
		if (num > 0)
		{
			int num2 = num * loot.playerVisual.duplicateWarbucks;
			Debug.Log($"Visual {loot.playerVisual.name}, overcount {num}, added warbucks {num2}");
			Singleton<Wallet>.instance.AddWarBucksReward(num2);
			if (Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<EndScreen>.instance)
			{
				GuiScreenSingle<EndScreen>.instance.results.AddLootboxReward(num2);
			}
		}
		else
		{
			Debug.Log($"Visual {loot.playerVisual.name}, no overcount");
		}
		GuiScreenSingle<CamosScreen>.instance.WasShown(loot.playerVisual);
	}

	public override void InitGUIValues()
	{
		int numberOfPartsMax = mLootboxes[mIndexNumber].playerVisual.numberOfPartsMax;
		int num = ((!mLootboxes[mIndexNumber].playerVisual.isBought) ? mLootboxes[mIndexNumber].playerVisual.numberOfParts : numberOfPartsMax);
		int num2 = mLootboxes[mIndexNumber].parts;
		PlayerVisual.Rarity rarity = mLootboxes[mIndexNumber].playerVisual.rarity;
		mIsBought = mLootboxes[mIndexNumber].playerVisual.isBought || num + num2 >= numberOfPartsMax;
		mUnlocked = !mLootboxes[mIndexNumber].playerVisual.isBought && num + num2 >= numberOfPartsMax;
		mVideoLoaded = Singleton<EventTrackingManager>.instance.IsRewardVideoPreloaded(RewardType.LootBox);
		if (mUnlocked)
		{
			num2 = numberOfPartsMax - num;
		}
		HideEverything();
		Singleton<LootBoxCamera>.instance.Hide();
		beginTitle.text = Localization.Localize((!mLootboxes[mIndexNumber].isVip) ? "ID_LOOTBOXREWARDED" : "ID_VIPLOOTBOXREWARDED");
		visualNameLabel.text = mLootboxes[mIndexNumber].playerVisual.name.ToUpper();
		MiscTools.SetUILabelRescale(visualNameLabel, 131f, 60f, 1240);
		visualRarityLabel.color = GameVariables.rarityColours[rarity].ReplaceA(visualRarityLabel.alpha);
		if (num2 > 1)
		{
			visualRarityLabel.text = Localization.LocalizeFormat(mCategoryPart[mLootboxes[mIndexNumber].playerVisual.owner.categoryNumber].Value2, mLootboxes[mIndexNumber].playerVisual.rarityName, Colours.stringWhite);
		}
		else
		{
			visualRarityLabel.text = Localization.LocalizeFormat(mCategoryPart[mLootboxes[mIndexNumber].playerVisual.owner.categoryNumber].Value1, mLootboxes[mIndexNumber].playerVisual.rarityName, Colours.stringWhite);
		}
		boxesCountLabel.text = $"{mIndexNumber + 1} {Colours.stringGrayParts}/{Colours.stringWhite} {mLootboxes.Count}";
		openAllBoxesButton.gameObject.SetActive(mIndexNumber + 1 < mLootboxes.Count);
		visualIcon.spriteName = mLootboxes[mIndexNumber].playerVisual.icon;
		visualIcon.MakePixelPerfect();
		float multiplier = Mathf.Min(136f / visualIcon.transform.localScale.x, 136f / visualIcon.transform.localScale.y);
		visualIcon.transform.localScale = visualIcon.transform.localScale.MultiplyXY(multiplier);
		partsIcon.color = visualRarityLabel.color.ReplaceA(partsIcon.alpha);
		visualPartsIncreaseLabel.color = visualRarityLabel.color.ReplaceA(visualPartsIncreaseLabel.alpha);
		visualPartsIncreaseLabel.text = MiscTools.FormatMedalsDifference(num2);
		visualPartsCountLabel.color = visualRarityLabel.color.ReplaceA(visualPartsCountLabel.alpha);
		visualPartsCountLabel.text = $"{num + num2} {Colours.stringGrayParts}/{Colours.stringWhite} {numberOfPartsMax}";
		duplicateHeaderLabel.text = ((num2 != 1) ? Localization.LocalizeFormat("ID_LOOTDUPLICATE", num2) : Localization.Localize("ID_LOOTDUPLICATEONE"));
		duplicateWarbucksLabel.text = MiscTools.FormatMedalsDifference(Mathf.Max(0, num + num2 - numberOfPartsMax) * mLootboxes[mIndexNumber].playerVisual.duplicateWarbucks);
		visualCompleted.text = Localization.LocalizeFormat("ID_VISUALCOMPLETED", string.Empty);
		InitializeCenterEquipButton(mLootboxes[mIndexNumber].playerVisual.isEquipped);
		Debug.Log(string.Format("Lootbox - visual \"{5}\", parts: {0}/{2}, added +{1}, that means reward {4} (reward for one {3})", num, num2, numberOfPartsMax, mLootboxes[mIndexNumber].playerVisual.duplicateWarbucks, duplicateWarbucksLabel.text, visualNameLabel.text));
		if (rarity == PlayerVisual.Rarity.Common)
		{
			flash.color = Color.white.ReplaceA(flash.alpha);
			flash2.color = Color.white.ReplaceA(0f);
		}
		else
		{
			flash.color = visualRarityLabel.color.ReplaceA(flash.alpha);
			flash2.color = visualRarityLabel.color.ReplaceA(0f);
		}
		InitializeEquipButton(mLootboxes[mIndexNumber].playerVisual.isEquipped);
		hintNextLootcrateLabel.text = Localization.LocalizeFormat("ID_NEXTLOOTBOXINPVPBATTLES", Colours.stringBlue, PlayerAnalytics.instance.remainingMatchesToNextLootbox);
		Singleton<LootBoxCamera>.instance.ShowVisual(mLootboxes[mIndexNumber].playerVisual);
		mSkippable = true;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		mArmyCameraShown = Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<CamosScreen>.instance || Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<ArmyScreen>.instance;
		mWeaponCameraShown = Singleton<GuiManager>.instance.currentScreen == GuiScreenSingle<WeaponScreen>.instance;
		if (mArmyCameraShown)
		{
			Singleton<ArmyPreviewCamera>.instance.Pause();
		}
		if (mWeaponCameraShown)
		{
			Singleton<WeaponPreviewCamera>.instance.Pause();
		}
		Singleton<LootBoxCamera>.instance.dialogCamera.gameObject.SetActive(value: true);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		if (mSkippable)
		{
			ShowInitialAnimation();
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		Singleton<LootBoxCamera>.instance.Hide();
		if (mArmyCameraShown)
		{
			mArmyCameraShown = false;
			Singleton<ArmyPreviewCamera>.instance.Resume();
		}
		if (mWeaponCameraShown)
		{
			mWeaponCameraShown = false;
			Singleton<WeaponPreviewCamera>.instance.Resume();
		}
		Singleton<LootBoxCamera>.instance.dialogCamera.gameObject.SetActive(value: false);
	}

	private void ShowInitialAnimation()
	{
		TweenPosition.Begin(startingTitle, mDur * mSpeed, startingTitle.transform.localPosition.ReplaceX(UIRoot.list[0].activeWidth), startingTitle.transform.localPosition.ReplaceX(0f));
		TweenPosition tweenPosition = TweenPosition.Begin(swipePart, mDur * mSpeed, swipePart.transform.localPosition.ReplaceX(0f - UIRoot.list[0].activeWidth), swipePart.transform.localPosition.ReplaceX(0f));
		tweenPosition.onFinished = delegate
		{
			if (mSkippable)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(swipeLabel.gameObject, mDur * mBlickSpeed, 0f, 0.2f);
				tweenAlpha.NumOfRepetitions = 1;
				tweenAlpha.method = UITweener.Method.EaseIn;
				tweenAlpha.onFinished = delegate
				{
					TweenAlpha tweenAlpha2 = TweenAlpha.Begin(swipeLabel.gameObject, mDur * mBlickSpeed, 0.2f, 0.7f);
					tweenAlpha2.NumOfRepetitions = 5;
					tweenAlpha2.style = UITweener.Style.PingPong;
					tweenAlpha2.method = UITweener.Method.Linear;
					tweenAlpha2.onFinished = delegate
					{
						TweenAlpha tweenAlpha3 = TweenAlpha.Begin(swipeLabel.gameObject, mDur * mBlickSpeed, 1f);
						tweenAlpha3.NumOfRepetitions = 1;
						tweenAlpha3.method = UITweener.Method.EaseOut;
					};
				};
				StartArrowsAnimation();
				mSkippable = false;
				mCheckSwipe = true;
			}
		};
	}

	private void ShowOpenAnimation()
	{
		HideEverything();
		Singleton<LootBoxCamera>.instance.OpenLootBox();
	}

	public void ShowVisualInfo(bool wasSkipped)
	{
		characterUpParticles.Play();
		characterDownParticles.Play();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(flash.gameObject, 0.05f, 0.9f, 0f);
		tweenAlpha.method = UITweener.Method.EaseOut;
		tweenAlpha.onFinished = null;
		if (wasSkipped)
		{
			ShowInstantScreen();
		}
		else
		{
			AnimateScreen();
		}
	}

	public void ShowFlash()
	{
		PlayerVisual.Rarity rarity = mLootboxes[mIndexNumber].playerVisual.rarity;
		if (mUnlocked)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.OpenLootboxCompleted);
		}
		else if (rarity == PlayerVisual.Rarity.Legendary)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.OpenLootboxLegendary);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.LeagueRewardShowed);
		}
		switch (rarity)
		{
		case PlayerVisual.Rarity.Legendary:
			TweenAlpha.Begin(flash2.gameObject, 1.2f, 0.5f, 0f);
			break;
		case PlayerVisual.Rarity.Epic:
			TweenAlpha.Begin(flash2.gameObject, 0.8f, 0.5f, 0f);
			break;
		case PlayerVisual.Rarity.Rare:
			TweenAlpha.Begin(flash2.gameObject, 0.6f, 0.7f, 0f);
			break;
		case PlayerVisual.Rarity.Uncommon:
			TweenAlpha.Begin(flash2.gameObject, 0.4f, 0.5f, 0f);
			break;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(flash.gameObject, 0.05f, 0f, 0.9f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = delegate
		{
			Singleton<LootBoxCamera>.instance.DisplayModel(wasSkipped: false);
		};
	}

	private void HideEverything()
	{
		StopTweens();
		startingTitle.transform.localPosition = startingTitle.transform.localPosition.ReplaceX(UIRoot.list[0].activeWidth);
		swipePart.transform.localPosition = swipePart.transform.localPosition.ReplaceX(0f - UIRoot.list[0].activeWidth);
		swipeLabel.alpha = 0f;
		visualNameLabel.alpha = 0f;
		visualRarityLabel.alpha = 0f;
		multipleBoxes.transform.localPosition = multipleBoxes.transform.localPosition.ReplaceX(150f);
		partsObject.SetActive(value: false);
		visualPartsCountLabel.alpha = 0f;
		lootDuplicatePart.SetActive(value: false);
		visualCompletedPart.SetActive(value: false);
		equipButton.transform.localPosition = equipButton.transform.localPosition.ReplaceX(-300f);
		newLootcrateButton.transform.localPosition = newLootcrateButton.transform.localPosition.ReplaceY(-80f);
		videoHintLabel.transform.localPosition = videoHintLabel.transform.localPosition.ReplaceY(-20f);
		continueButton.transform.localPosition = continueButton.transform.localPosition.ReplaceX(210f);
		hintNextLootcrateLabel.transform.localPosition = hintNextLootcrateLabel.transform.localPosition.ReplaceX(10f);
		nextLootcrateButton.transform.localPosition = nextLootcrateButton.transform.localPosition.ReplaceX(270f);
		flash.alpha = 0f;
		flash2.alpha = 0f;
		mCheckSwipe = false;
		mSkippable = false;
	}

	private void StopTweens()
	{
		UITweener[] componentsInChildren = base.gameObject.GetComponentsInChildren<UITweener>(includeInactive: true);
		foreach (UITweener uITweener in componentsInChildren)
		{
			if (!(uITweener is TweenAlpha))
			{
				uITweener.enabled = false;
				uITweener.onFinished = null;
			}
		}
		TweenAlpha component = swipeLabel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		StopArrowsAnimation();
		component = visualNameLabel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = visualRarityLabel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = visualPartsCountLabel.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = flash.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = flash2.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	private void ShowInstantScreen()
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.LeagueRewardShowed);
		visualNameLabel.transform.localPosition = visualNameLabel.transform.localPosition.ReplaceY(-142f);
		visualNameLabel.alpha = 1f;
		visualRarityLabel.transform.localPosition = visualRarityLabel.transform.localPosition.ReplaceY(-240f);
		visualRarityLabel.alpha = 1f;
		partsObject.SetActive(!mUnlocked && !mIsBought);
		visualPartsCountLabel.alpha = ((mUnlocked || mIsBought) ? 0f : 1f);
		lootDuplicatePart.SetActive(!mUnlocked && mIsBought);
		visualCompletedPart.SetActive(mUnlocked);
		if (mUnlocked)
		{
			visualCompletedPart.transform.localScale = Vector3.one;
		}
		else if (mIsBought)
		{
			lootDuplicatePart.transform.localScale = Vector3.one;
		}
		else
		{
			partsObject.transform.localScale = Vector3.one;
			visualPartsCountLabel.transform.localPosition = visualPartsCountLabel.transform.localPosition.ReplaceY(-13f);
		}
		AnimateShowEquipButton(instant: true);
		AnimateShowWatchVideoButton(instant: true);
		AnimateShowContinueButton(instant: true);
		AnimateShowNextLootcrateButton(instant: true);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(flash.gameObject, 0.05f, 0f, 0.9f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(flash.gameObject, 0.05f, 0f);
			tweenAlpha2.method = UITweener.Method.EaseOut;
			tweenAlpha2.onFinished = null;
		};
	}

	private void AnimateScreen()
	{
		TweenAlpha.Begin(visualNameLabel.gameObject, mDur, 1f);
		visualNameLabel.transform.localPosition = visualNameLabel.transform.localPosition.ReplaceY(-162f);
		TweenPosition tweenPosition = TweenPosition.Begin(visualNameLabel.gameObject, mDur * mSpeed, visualNameLabel.transform.localPosition.ReplaceY(-192f), visualNameLabel.transform.localPosition.ReplaceY(-96f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(visualNameLabel.gameObject, mDur * mSpeed, visualNameLabel.transform.localPosition.ReplaceY(-142f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
			TweenAlpha.Begin(visualRarityLabel.gameObject, mDur, 1f);
			visualRarityLabel.transform.localPosition = visualRarityLabel.transform.localPosition.ReplaceY(-360f);
			TweenPosition.Begin(visualRarityLabel.gameObject, mDur * mSpeed, visualRarityLabel.transform.localPosition.ReplaceY(-360f), visualRarityLabel.transform.localPosition.ReplaceY(-240f));
		};
		GameObject scaleObject = ((!mIsBought) ? partsObject : lootDuplicatePart);
		if (mUnlocked)
		{
			scaleObject = visualCompletedPart;
		}
		scaleObject.SetActive(value: true);
		scaleObject.transform.localScale = new Vector3(0.001f, 0.001f, 1f);
		visualPartsCountLabel.alpha = 0f;
		TweenScale tweenScale = TweenScale.Begin(scaleObject, mDur * mSpeed, new Vector3(0.001f, 0.001f, 1f), new Vector3(1.3f, 1.3f, 1f));
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = delegate
		{
			if (!mUnlocked && !mIsBought)
			{
				TweenAlpha.Begin(visualPartsCountLabel.gameObject, mDur, 1f);
				visualPartsCountLabel.transform.localPosition = visualPartsCountLabel.transform.localPosition.ReplaceY(-47f);
				TweenPosition tweenPosition2 = TweenPosition.Begin(visualPartsCountLabel.gameObject, mDur * mSpeed, visualPartsCountLabel.transform.localPosition.ReplaceY(-47f), visualPartsCountLabel.transform.localPosition.ReplaceY(21f));
				tweenPosition2.method = UITweener.Method.EaseIn;
				tweenPosition2.onFinished = delegate
				{
					TweenPosition tweenPosition3 = TweenPosition.Begin(visualPartsCountLabel.gameObject, mDur * mSpeed, visualPartsCountLabel.transform.localPosition.ReplaceY(-13f));
					tweenPosition3.method = UITweener.Method.EaseOut;
					tweenPosition3.onFinished = null;
				};
			}
			TweenScale tweenScale2 = TweenScale.Begin(scaleObject, mDur * mSpeed, Vector3.one);
			tweenScale2.method = UITweener.Method.EaseOut;
			tweenScale2.onFinished = delegate
			{
				AnimateShowEquipButton(instant: false);
				AnimateShowWatchVideoButton(instant: false);
				AnimateShowContinueButton(instant: false);
				AnimateShowNextLootcrateButton(instant: false);
			};
		};
		TweenAlpha tweenAlpha = TweenAlpha.Begin(flash.gameObject, 0.05f, 0f, 0.9f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(flash.gameObject, 0.05f, 0f);
			tweenAlpha2.method = UITweener.Method.EaseOut;
			tweenAlpha2.onFinished = null;
		};
	}

	private void AnimateShowEquipButton(bool instant)
	{
		if (!mUnlocked && mIsBought && !mLootboxes[mIndexNumber].playerVisual.isEquipped && !GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			if (instant)
			{
				equipButton.transform.localPosition = equipButton.transform.localPosition.ReplaceX(156f);
				return;
			}
			equipButton.transform.localPosition = equipButton.transform.localPosition.ReplaceX(-300f);
			TweenPosition tweenPosition = TweenPosition.Begin(equipButton.gameObject, mDur * mSpeed, equipButton.transform.localPosition.ReplaceX(-300f), equipButton.transform.localPosition.ReplaceX(168f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(equipButton.gameObject, mDur * mSpeed, equipButton.transform.localPosition.ReplaceX(156f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
			};
		}
		else
		{
			equipButton.transform.localPosition = equipButton.transform.localPosition.ReplaceX(-300f);
		}
	}

	private void AnimateShowWatchVideoButton(bool instant)
	{
		if (mVideoLoaded && mShowContinue && mShowAdButton)
		{
			if (instant)
			{
				newLootcrateButton.transform.localPosition = newLootcrateButton.transform.localPosition.ReplaceY(164f);
				videoHintLabel.transform.localPosition = videoHintLabel.transform.localPosition.ReplaceY(51f);
				return;
			}
			newLootcrateButton.transform.localPosition = newLootcrateButton.transform.localPosition.ReplaceY(-80f);
			TweenPosition tweenPosition = TweenPosition.Begin(newLootcrateButton.gameObject, mDur * mSpeed, newLootcrateButton.transform.localPosition.ReplaceY(-80f), newLootcrateButton.transform.localPosition.ReplaceY(176f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(newLootcrateButton.gameObject, mDur * mSpeed, newLootcrateButton.transform.localPosition.ReplaceY(164f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				videoHintLabel.transform.localPosition = videoHintLabel.transform.localPosition.ReplaceY(-20f);
				TweenPosition tweenPosition3 = TweenPosition.Begin(videoHintLabel.gameObject, mDur * mSpeed, videoHintLabel.transform.localPosition.ReplaceY(-20f), videoHintLabel.transform.localPosition.ReplaceY(63f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition4 = TweenPosition.Begin(videoHintLabel.gameObject, mDur * mSpeed, videoHintLabel.transform.localPosition.ReplaceY(51f));
					tweenPosition4.method = UITweener.Method.EaseOut;
					tweenPosition4.onFinished = null;
				};
			};
		}
		else
		{
			newLootcrateButton.transform.localPosition = newLootcrateButton.transform.localPosition.ReplaceY(-80f);
			videoHintLabel.transform.localPosition = videoHintLabel.transform.localPosition.ReplaceY(-20f);
		}
	}

	private void AnimateShowContinueButton(bool instant)
	{
		if (mShowContinue)
		{
			if (instant)
			{
				continueButton.transform.localPosition = continueButton.transform.localPosition.ReplaceX(-161f);
				hintNextLootcrateLabel.transform.localPosition = hintNextLootcrateLabel.transform.localPosition.ReplaceX(-311f);
				return;
			}
			continueButton.transform.localPosition = continueButton.transform.localPosition.ReplaceX(210f);
			TweenPosition tweenPosition = TweenPosition.Begin(continueButton.gameObject, mDur * mSpeed, continueButton.transform.localPosition.ReplaceX(210f), continueButton.transform.localPosition.ReplaceX(-173f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(continueButton.gameObject, mDur * mSpeed, continueButton.transform.localPosition.ReplaceX(-161f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				hintNextLootcrateLabel.transform.localPosition = hintNextLootcrateLabel.transform.localPosition.ReplaceX(10f);
				TweenPosition tweenPosition3 = TweenPosition.Begin(hintNextLootcrateLabel.gameObject, mDur * mSpeed, hintNextLootcrateLabel.transform.localPosition.ReplaceX(10f), hintNextLootcrateLabel.transform.localPosition.ReplaceX(-323f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition5 = TweenPosition.Begin(hintNextLootcrateLabel.gameObject, mDur * mSpeed, hintNextLootcrateLabel.transform.localPosition.ReplaceX(-311f));
					tweenPosition5.method = UITweener.Method.EaseOut;
					tweenPosition5.onFinished = null;
				};
				if (mLootboxes.Count > 1)
				{
					multipleBoxes.transform.localPosition = multipleBoxes.transform.localPosition.ReplaceX(150f);
					TweenPosition tweenPosition4 = TweenPosition.Begin(multipleBoxes.gameObject, mDur * mSpeed, multipleBoxes.transform.localPosition.ReplaceX(150f), multipleBoxes.transform.localPosition.ReplaceX(-212f));
					tweenPosition4.method = UITweener.Method.EaseIn;
					tweenPosition4.onFinished = delegate
					{
						TweenPosition tweenPosition5 = TweenPosition.Begin(multipleBoxes.gameObject, mDur * mSpeed, multipleBoxes.transform.localPosition.ReplaceX(-200f));
						tweenPosition5.method = UITweener.Method.EaseOut;
						tweenPosition5.onFinished = null;
					};
				}
			};
		}
		else
		{
			continueButton.transform.localPosition = continueButton.transform.localPosition.ReplaceX(210f);
			hintNextLootcrateLabel.transform.localPosition = hintNextLootcrateLabel.transform.localPosition.ReplaceX(10f);
		}
	}

	private void AnimateShowNextLootcrateButton(bool instant)
	{
		if (!mShowContinue)
		{
			if (instant)
			{
				nextLootcrateButton.transform.localPosition = nextLootcrateButton.transform.localPosition.ReplaceX(-211f);
				multipleBoxes.transform.localPosition = multipleBoxes.transform.localPosition.ReplaceX(-200f);
				return;
			}
			nextLootcrateButton.transform.localPosition = nextLootcrateButton.transform.localPosition.ReplaceX(270f);
			TweenPosition tweenPosition = TweenPosition.Begin(nextLootcrateButton.gameObject, mDur * mSpeed, nextLootcrateButton.transform.localPosition.ReplaceX(270f), nextLootcrateButton.transform.localPosition.ReplaceX(-223f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				TweenPosition tweenPosition2 = TweenPosition.Begin(nextLootcrateButton.gameObject, mDur * mSpeed, nextLootcrateButton.transform.localPosition.ReplaceX(-211f));
				tweenPosition2.method = UITweener.Method.EaseOut;
				tweenPosition2.onFinished = null;
				multipleBoxes.transform.localPosition = multipleBoxes.transform.localPosition.ReplaceX(150f);
				TweenPosition tweenPosition3 = TweenPosition.Begin(multipleBoxes.gameObject, mDur * mSpeed, multipleBoxes.transform.localPosition.ReplaceX(150f), multipleBoxes.transform.localPosition.ReplaceX(-212f));
				tweenPosition3.method = UITweener.Method.EaseIn;
				tweenPosition3.onFinished = delegate
				{
					TweenPosition tweenPosition4 = TweenPosition.Begin(multipleBoxes.gameObject, mDur * mSpeed, multipleBoxes.transform.localPosition.ReplaceX(-200f));
					tweenPosition4.method = UITweener.Method.EaseOut;
					tweenPosition4.onFinished = null;
				};
			};
		}
		else
		{
			nextLootcrateButton.transform.localPosition = nextLootcrateButton.transform.localPosition.ReplaceX(270f);
			multipleBoxes.transform.localPosition = multipleBoxes.transform.localPosition.ReplaceX(150f);
		}
	}

	private void StartArrowsAnimation()
	{
		ArrowWave(0);
	}

	private void StopArrowsAnimation()
	{
		for (int i = 0; i < swipeArrows.Length; i++)
		{
			TweenAlpha component = swipeArrows[i].gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
				component.onFinished = null;
			}
			swipeArrows[i].alpha = 0.125f;
		}
	}

	private void ArrowWave(int index)
	{
		int num = swipeArrows.Length;
		if (index >= num)
		{
			index = 0;
		}
		int num2 = ((index <= 0) ? (num - 1) : (index - 1));
		int num3 = ((index + 1 < num - 1) ? (index + 1) : 0);
		float alpha = 0.125f;
		float alpha2 = 1f;
		TweenAlpha.Begin(swipeArrows[num2].gameObject, mDur, alpha).onFinished = null;
		TweenAlpha.Begin(swipeArrows[index].gameObject, mDur, alpha2).onFinished = null;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(swipeArrows[num3].gameObject, mDur, alpha2);
		tweenAlpha.onFinished = delegate
		{
			ArrowWave(index + 1);
		};
	}

	private void InitializeEquipLabel()
	{
		string text = Localization.Localize("ID_GUI_EQUIP");
		string text2 = Localization.Localize("ID_GUI_EQUIPPED");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		equipLabel.text = text3;
		MiscTools.SetUILabelRescale(equipLabel, 47f, 20f, 224);
	}

	private void InitializeEquipButton(bool equipped)
	{
		equipLabel.text = Localization.Localize((!equipped) ? "ID_GUI_EQUIP" : "ID_GUI_EQUIPPED");
		equipLabel.color = ((!equipped) ? Color.black : Color.white);
		TweenAlpha.Begin(equipIcon.gameObject, 0f, (!equipped) ? 1f : 0f);
		TweenAlpha.Begin(equipBackground.gameObject, 0f, (!equipped) ? 1f : 0f);
		equippedBackground.alpha = ((!equipped) ? 0f : 1f);
		equippedIconInside.alpha = ((!equipped) ? 0f : 1f);
		equippedIconBigger.alpha = ((!equipped) ? 0f : 0.16f);
		if (!equipped)
		{
			TweenAlpha.Begin(equippedIconInside.gameObject, 0f, 0f).style = UITweener.Style.Once;
		}
	}

	private void AnimateEquip()
	{
		equipLabel.text = Localization.Localize("ID_GUI_EQUIPPED");
		float duration = 0.3f;
		TweenColor.Begin(equipLabel.gameObject, duration, Color.white);
		TweenAlpha.Begin(equipIcon.gameObject, duration, 0f);
		TweenAlpha.Begin(equipBackground.gameObject, duration, 0f);
		TweenAlpha.Begin(equippedBackground.gameObject, duration, 1f);
		TweenAlpha.Begin(equippedIconBigger.gameObject, duration, 0.16f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(equippedIconInside.gameObject, duration, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	private void InitializeCenterEquipLabel()
	{
		string text = Localization.Localize("ID_GUI_EQUIP");
		string text2 = Localization.Localize("ID_GUI_EQUIPPED");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		visualEquipLabel.text = text3;
		MiscTools.SetUILabelRescale(equipLabel, 47f, 20f, 260);
	}

	private void InitializeCenterEquipButton(bool equipped)
	{
		visualEquipLabel.text = Localization.Localize((!equipped) ? "ID_GUI_EQUIP" : "ID_GUI_EQUIPPED");
		visualEquipLabel.color = ((!equipped) ? Color.black : Color.white);
		TweenAlpha.Begin(visualEquipIcon.gameObject, 0f, (!equipped) ? 1f : 0f);
		TweenAlpha.Begin(visualEquipBackground.gameObject, 0f, (!equipped) ? 1f : 0f);
		visualEquippedBackground.alpha = ((!equipped) ? 0f : 1f);
		visualEquippedIconInside.alpha = ((!equipped) ? 0f : 1f);
		visualEquippedIconBigger.alpha = ((!equipped) ? 0f : 0.16f);
		if (!equipped)
		{
			TweenAlpha.Begin(visualEquippedIconInside.gameObject, 0f, 0f).style = UITweener.Style.Once;
		}
	}

	private void AnimateCenterEquip()
	{
		visualEquipLabel.text = Localization.Localize("ID_GUI_EQUIPPED");
		float duration = 0.3f;
		TweenColor.Begin(visualEquipLabel.gameObject, duration, Color.white);
		TweenAlpha.Begin(visualEquipIcon.gameObject, duration, 0f);
		TweenAlpha.Begin(visualEquipBackground.gameObject, duration, 0f);
		TweenAlpha.Begin(visualEquippedBackground.gameObject, duration, 1f);
		TweenAlpha.Begin(visualEquippedIconBigger.gameObject, duration, 0.16f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(visualEquippedIconInside.gameObject, duration, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	protected override void Update()
	{
		base.Update();
		if (mSkippable && Input.GetMouseButtonDown(0))
		{
			SkipAnimations();
		}
		if (mCheckSwipe && Singleton<InputController>.instance.rawSwipeInput.swipeDone && ((Vector3)(Singleton<InputController>.instance.rawSwipeInput.swipeEnd - Singleton<InputController>.instance.rawSwipeInput.swipeStart)).x > UIRoot.list[0].activeWidth * 0.15f)
		{
			ShowOpenAnimation();
		}
	}

	private void SkipAnimations()
	{
		mSkippable = false;
		HideEverything();
		Singleton<LootBoxCamera>.instance.Skip();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		if (mSkippable)
		{
			SkipAnimations();
		}
		else if (mShowContinue)
		{
			ContinueClick(base.gameObject);
		}
		else
		{
			NextLootcrateClick(base.gameObject);
		}
	}
}
