using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpDialog : GuiElementSingle<LevelUpDialog>, IGuiDialog
{
	[Header("Top")]
	public GameObject headerLeft;

	public UITexture rankUpTexture;

	public UILabel rankUpNumber;

	[Header("-Right")]
	public GameObject headerRight;

	public UISprite armyPowerIcon;

	public UILabel armyPowerIncrease;

	public UILabel armyPowerValue;

	[Header("-SubHeader")]
	public LevelUpInfo healthInfo;

	public LevelUpInfo shieldInfo;

	public LevelUpInfo warcardsInfo;

	[Header("Middle")]
	public UISprite[] leftStripes;

	public UILabel rewardLabel;

	public UISprite[] rightStripes;

	[Header("-Unlocked Items")]
	public GameObject itemParent;

	public LevelUpItem[] items;

	[Header("-Start Animation")]
	public UISprite animationGlow;

	public UILabel animationRankUpLeft;

	public UILabel animationRankUpRight;

	[Header("Bottom")]
	public GameObject continueButton;

	[Header("Settings")]
	public int fps = 60;

	[HideInInspector]
	public bool completeAnimation;

	private bool mAnimating;

	private int mShowPart;

	private List<LevelUpUnlock> mUnlocks = new List<LevelUpUnlock>();

	private TweenAnimator mAnimator;

	private int mHeight;

	private RadicalRoutine mItemChanger;

	private LongObject mAnimateToGoldInHeader = new LongObject(0L);

	private Vector3 mRankUpStartAnimationDownPosition;

	private Vector3 mRankUpStartAnimationUpPosition;

	private Vector3 mRankUpStartAnimationMiddlePosition;

	private Vector3 mRankUpStartAnimationScaleDown = new Vector3(264f, 264f, 1f);

	private Vector3 mRankUpStartAnimationScaleUp = new Vector3(360f, 360f, 1f);

	private Vector3 mGlowOriginal = new Vector3(500f, 109f, 1f);

	private Vector3 mGlowBig = new Vector3(3300f, 600f, 1f);

	private Vector3 mGlowWide = new Vector3(2200f, 60f, 1f);

	private Vector3 mGlowWideSmall = new Vector3(400f, 8f, 1f);

	private Vector3 mTextScaleOne = new Vector3(1f, 1f, 1f);

	private Vector3 mTextScaleBig = new Vector3(231f, 231f, 1f);

	private Vector3 mTextScaleMiddle = new Vector3(203f, 203f, 1f);

	private Vector3 mTextScaleEnd = new Vector3(198f, 198f, 1f);

	private Vector3 mRankUpNumberDownPosition = new Vector3(-194f, -25f, -1f);

	private Vector3 mRankUpNumberUpPosition = new Vector3(-194f, 37f, -1f);

	private Vector3 mRankUpNumberMiddlePosition = new Vector3(-194f, -11f, -1f);

	private Vector3 mRankUpNumberLeftPosition = new Vector3(-232f, -11f, -1f);

	private Vector3 mArmyPowerIconDown = new Vector3(82f, -133f, 0f);

	private Vector3 mArmyPowerIconUp = new Vector3(82f, 47f, 0f);

	private Vector3 mArmyPowerIconEnd = new Vector3(82f, 0f, 0f);

	private Vector3 mArmyPowerIconLeft = new Vector3(0f, 0f, 0f);

	private Vector3 mArmyPowerIncreaseLeft = new Vector3(98f, -11f, -1f);

	private Vector3 mArmyPowerIncreaseRight = new Vector3(178f, -11f, -1f);

	private Vector3 mArmyPowerIncreaseEnd = new Vector3(155f, -11f, -1f);

	private Vector3 mArmyPowerIncreaseHide = new Vector3(75f, 24f, -1f);

	private Vector3 mArmyPowerDown = new Vector3(75f, -27f, -1f);

	private Vector3 mArmyPowerEnd = new Vector3(75f, -9f, -1f);

	private Vector3 mContinueButtonDown = new Vector3(0f, -82f, 0f);

	private Vector3 mContinueButtonUp = new Vector3(0f, 140f, 0f);

	private Vector3 mContinueButtonEnd = new Vector3(0f, 106f, 0f);

	private Vector3 mRewarHeader1 = new Vector3(0f, -19f, -1f);

	private Vector3 mRewarHeader2 = new Vector3(0f, 21f, -1f);

	private Vector3 mRewarHeader3 = new Vector3(0f, -9f, -1f);

	private Vector3 mLeftStripeClose1 = new Vector3(-356f, 0f, 0f);

	private Vector3 mLeftStripeClose2 = new Vector3(-290f, 0f, 0f);

	private Vector3 mLeftStripeClose3 = new Vector3(-314f, 0f, 0f);

	private Vector3 mLeftStripeMiddle1 = new Vector3(-461f, 0f, 0f);

	private Vector3 mLeftStripeMiddle2 = new Vector3(-395f, 0f, 0f);

	private Vector3 mLeftStripeMiddle3 = new Vector3(-415f, 0f, 0f);

	private Vector3 mLeftStripeFar1 = new Vector3(-601f, 0f, 0f);

	private Vector3 mLeftStripeFar2 = new Vector3(-533f, 0f, 0f);

	private Vector3 mLeftStripeFar3 = new Vector3(-553f, 0f, 0f);

	private Vector3 mRightStripeClose1 = new Vector3(356f, 0f, 0f);

	private Vector3 mRightStripeClose2 = new Vector3(290f, 0f, 0f);

	private Vector3 mRightStripeClose3 = new Vector3(314f, 0f, 0f);

	private Vector3 mRightStripeMiddle1 = new Vector3(461f, 0f, 0f);

	private Vector3 mRightStripeMiddle2 = new Vector3(395f, 0f, 0f);

	private Vector3 mRightStripeMiddle3 = new Vector3(415f, 0f, 0f);

	private Vector3 mRightStripeFar1 = new Vector3(601f, 0f, 0f);

	private Vector3 mRightStripeFar2 = new Vector3(533f, 0f, 0f);

	private Vector3 mRightStripeFar3 = new Vector3(553f, 0f, 0f);

	public string debugCurrentLevelUnlocks
	{
		get
		{
			GetCurrentLevelUnlocks();
			if (mUnlocks.Count == 0)
			{
				return "count: 0";
			}
			string text = "count: " + mUnlocks.Count + "\t";
			for (int i = 0; i < mUnlocks.Count; i++)
			{
				string text2 = text;
				text = text2 + " " + i + ". " + mUnlocks[i].type;
				if (mUnlocks[i].type == LevelUpUnlock.ItemType.MapUnlock)
				{
					text = text + "-" + mUnlocks[i].mapEntry.guiName;
				}
				if (mUnlocks[i].type == LevelUpUnlock.ItemType.UnitUnlock)
				{
					text = text + "-" + mUnlocks[i].unit.unitName;
				}
				if (mUnlocks[i].type == LevelUpUnlock.ItemType.WeaponUnlock)
				{
					text = text + "-" + mUnlocks[i].weapon.weaponName;
				}
			}
			return text + "\n";
		}
	}

	public override void InitControls()
	{
		mHeight = UIRoot.list[0].activeHeight;
		float y = 0f - rankUpTexture.transform.parent.transform.localPosition.y - (float)mHeight / 2f;
		Vector3 lhs = new Vector3(0f, y, rankUpTexture.transform.localPosition.z);
		mRankUpStartAnimationDownPosition = lhs.AddY(160f);
		mRankUpStartAnimationUpPosition = lhs.AddY(320f);
		mRankUpStartAnimationMiddlePosition = lhs.AddY(300f);
		CreateAnimations();
		healthInfo.InitControls();
		shieldInfo.InitControls();
		warcardsInfo.InitControls();
		for (int i = 0; i < items.Length; i++)
		{
			items[i].InitializeControls();
		}
		UIEventListener uIEventListener = UIEventListener.Get(continueButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		for (int j = 0; j < items.Length; j++)
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(items[j].gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ItemClick));
		}
	}

	private void CreateAnimations()
	{
		mAnimator = base.gameObject.AddComponent<TweenAnimator>();
		mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		AddDialogAnimations();
		TweenAnimator tweenAnimator = mAnimator;
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(OnTweenFinished));
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void ItemClick(GameObject go)
	{
		if (!base.isFullyShowed || mAnimating)
		{
			return;
		}
		LevelUpItem component = go.GetComponent<LevelUpItem>();
		if (component != null && component.currentUnlock != null)
		{
			if (component.currentUnlock.type == LevelUpUnlock.ItemType.WeaponUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(component.currentUnlock.weapon);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
				GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.currentUnlock.type == LevelUpUnlock.ItemType.UnitUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<ArmyScreen>.instance.SelectUnit(component.currentUnlock.unit);
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
				GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.currentUnlock.type == LevelUpUnlock.ItemType.MapUnlock || component.currentUnlock.type == LevelUpUnlock.ItemType.InstantBattleUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<BattlePreparationScreen>.instance);
			}
			else if (component.currentUnlock.type == LevelUpUnlock.ItemType.WarpathUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MissionScreen>.instance);
				GuiScreenSingle<MissionScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else if (component.currentUnlock.type == LevelUpUnlock.ItemType.JoinSquadUnlock || component.currentUnlock.type == LevelUpUnlock.ItemType.CreateSquadUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
				GuiScreenSingle<SquadScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			}
			else if (component.currentUnlock.type == LevelUpUnlock.ItemType.WarCardsUnlock)
			{
				SoundsManager.Instance.PlayButtonClickedSound();
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
				GuiScreenSingle<CardMenuScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
			}
			else
			{
				if (component.currentUnlock.type != LevelUpUnlock.ItemType.WarArenaUnlock)
				{
					return;
				}
				SoundsManager.Instance.PlayButtonClickedSound();
				GuiScreenSingle<BattlePreparationScreen>.instance.OpenScreenWithGameModesOpen();
			}
		}
		HideDialog();
	}

	public override void InitGUIValues()
	{
		mAnimating = true;
		mAnimator.FinishTweens();
		UIEventListener uIEventListener = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		completeAnimation = false;
		InitializeValues();
		GetCurrentLevelUnlocks();
		HideObjects();
		InitializeObjects();
		float fillTo = (float)LevelManager.instance.currentLevel.displayNumber / (float)LevelManager.instance.maxDisplayLevel;
		healthInfo.InitGuiValues(fillTo);
		shieldInfo.InitGuiValues(fillTo);
		warcardsInfo.InitGuiValues(fillTo);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Notification_PlayerLeague", SettingsManager.instance.playerLeague);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Notification_PlayerBattleChallenges", SettingsManager.instance.challenge);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Notification_YourSquadstatus", SettingsManager.instance.squadStatus);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Notification_DailyRewards", SettingsManager.instance.dailyRewardNotification);
		Singleton<EventTrackingManager>.instance.RegisterPlayerLevelUp("Notification_MaintenanceInformation", SettingsManager.instance.maintenance);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if ((bool)mAnimator)
		{
			mAnimator.ResetTweens();
		}
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			Singleton<ChillingoSdkManager>.instance.deactivateOffers();
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		PlayAnimation();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		StopItemChanger();
		for (int i = 0; i < items.Length; i++)
		{
			items[i].HideScreen();
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			foreach (TweenAnimator.TweenRecord allTween in mAnimator.allTweens)
			{
				if (allTween.id == 73)
				{
					allTween.to = mContinueButtonUp;
				}
				if (allTween.id == 74)
				{
					allTween.to = mContinueButtonEnd;
				}
			}
		}
		rankUpTexture.mainTexture = null;
		LevelManager.instance.isLevelUp = false;
		if (GuiScreenSingle<EndScreen>.instance.isShowed)
		{
			Singleton<ChillingoSdkManager>.instance.activateOffers();
		}
	}

	private void PlayAnimation()
	{
		if (Singleton<GameController>.instance.isTutorial)
		{
			foreach (TweenAnimator.TweenRecord allTween in mAnimator.allTweens)
			{
				if (allTween.id == 73 || allTween.id == 74)
				{
					allTween.to = mContinueButtonDown;
				}
			}
		}
		mAnimator.PlayTweens();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.LevelUp);
	}

	public void DebugReplay()
	{
		StopItemChanger();
		for (int i = 0; i < items.Length; i++)
		{
			items[i].HideScreen();
		}
		RecreateAnimations();
		InitGUIValues();
		PlayAnimation();
	}

	private void RecreateAnimations()
	{
		mAnimator.allTweens.Clear();
		AddDialogAnimations();
		healthInfo.DebugRecreateAnimations();
		shieldInfo.DebugRecreateAnimations();
		warcardsInfo.DebugRecreateAnimations();
		for (int i = 0; i < items.Length; i++)
		{
			items[i].DebugRecreateAnimations();
		}
	}

	private void AddDialogAnimations()
	{
		float num = 1f / (float)fps;
		mAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, num * 7f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(from: mRankUpStartAnimationDownPosition, id: 2, tweenType: TweenAnimator.TweenType.Position, tweenTarget: rankUpTexture.gameObject, time: num * 5f, to: mRankUpStartAnimationUpPosition, delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		mAnimator.AddTween(3, TweenAnimator.TweenType.Position, rankUpTexture.gameObject, num * 3f, mRankUpStartAnimationMiddlePosition, 0f, 1, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(from: mRankUpStartAnimationScaleUp, id: 4, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: rankUpTexture.gameObject, time: num * 6f, to: mRankUpStartAnimationScaleDown, delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.Linear);
		mAnimator.AddTween(5, TweenAnimator.TweenType.Scale, rankUpTexture.gameObject, num * 28f, mRankUpStartAnimationScaleUp, 0f, 4, null, UITweener.Method.Linear);
		mAnimator.AddTween(from: Quaternion.Euler(0f, 180f, 0f), id: 6, tweenType: TweenAnimator.TweenType.Rotation, tweenTarget: rankUpTexture.gameObject, time: num * 3f, to: Quaternion.Euler(0f, 90f, 0f), delay: num * 2f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		mAnimator.AddTween(7, TweenAnimator.TweenType.Rotation, rankUpTexture.gameObject, num * 3f, Quaternion.identity, 0f, 6, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(8, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 0f, num * 21f, 7, 1f);
		mAnimator.AddTween(9, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 1f, num * 1f, 8);
		mAnimator.AddTween(10, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 0f, num * 1f, 9);
		mAnimator.AddTween(11, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 1f, num * 1f, 10);
		mAnimator.AddTween(12, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 0f, num * 1f, 11);
		mAnimator.AddTween(13, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, num * 1f, 0f, 0f, 12);
		mAnimator.AddTween(14, TweenAnimator.TweenType.Alpha, animationGlow.gameObject, 0.001f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(15, TweenAnimator.TweenType.Scale, animationGlow.gameObject, num * 3f, mGlowBig, 0f, 14, mGlowOriginal, UITweener.Method.EaseIn);
		mAnimator.AddTween(16, TweenAnimator.TweenType.Scale, animationGlow.gameObject, num * 13f, mGlowWide, 0f, 15, null, UITweener.Method.Linear);
		mAnimator.AddTween(17, TweenAnimator.TweenType.Scale, animationGlow.gameObject, num * 8f, mGlowWideSmall, 0f, 16, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(18, TweenAnimator.TweenType.Alpha, animationGlow.gameObject, 0.001f, 0f, 0f, 17);
		mAnimator.AddTween(19, TweenAnimator.TweenType.Alpha, animationRankUpLeft.gameObject, 0.001f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(from: mTextScaleOne, id: 20, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: animationRankUpLeft.gameObject, time: num * 4f, to: mTextScaleBig, delay: 0f);
		mAnimator.AddTween(21, TweenAnimator.TweenType.Scale, animationRankUpLeft.gameObject, num * 3f, mTextScaleMiddle, 0f, 20);
		mAnimator.AddTween(22, TweenAnimator.TweenType.Scale, animationRankUpLeft.gameObject, num * 4f, mTextScaleEnd, 0f, 21);
		mAnimator.AddTween(23, TweenAnimator.TweenType.Alpha, animationRankUpLeft.gameObject, 0.001f, 0f, num * 11f, 22);
		mAnimator.AddTween(24, TweenAnimator.TweenType.Alpha, animationRankUpLeft.gameObject, 0.001f, 1f, num * 1f, 23);
		mAnimator.AddTween(25, TweenAnimator.TweenType.Alpha, animationRankUpLeft.gameObject, 0.001f, 0f, num * 1f, 24);
		mAnimator.AddTween(26, TweenAnimator.TweenType.Alpha, animationRankUpLeft.gameObject, 0.001f, 1f, num * 1f, 25);
		mAnimator.AddTween(27, TweenAnimator.TweenType.Alpha, animationRankUpLeft.gameObject, 0.001f, 0f, num * 1f, 26);
		mAnimator.AddTween(28, TweenAnimator.TweenType.Alpha, animationRankUpRight.gameObject, 0.001f, 1f, num * 2f, -1, 0f);
		mAnimator.AddTween(from: mTextScaleOne, id: 29, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: animationRankUpRight.gameObject, time: num * 5f, to: mTextScaleBig, delay: num * 3f);
		mAnimator.AddTween(30, TweenAnimator.TweenType.Scale, animationRankUpRight.gameObject, num * 3f, mTextScaleEnd, 0f, 29);
		mAnimator.AddTween(31, TweenAnimator.TweenType.Alpha, animationRankUpRight.gameObject, 0.001f, 0f, num * 15f, 22);
		mAnimator.AddTween(32, TweenAnimator.TweenType.Alpha, animationRankUpRight.gameObject, 0.001f, 1f, num * 1f, 31);
		mAnimator.AddTween(33, TweenAnimator.TweenType.Alpha, animationRankUpRight.gameObject, 0.001f, 0f, num * 1f, 32);
		mAnimator.AddTween(34, TweenAnimator.TweenType.Alpha, animationRankUpRight.gameObject, 0.001f, 1f, num * 1f, 33);
		mAnimator.AddTween(35, TweenAnimator.TweenType.Alpha, animationRankUpRight.gameObject, 0.001f, 0f, num * 1f, 34);
		mAnimator.AddTween(50, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 1f, num * 1f, 13, 0f);
		mAnimator.AddTween(51, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 0f, num * 1f, 50);
		mAnimator.AddTween(52, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 1f, num * 1f, 51);
		mAnimator.AddTween(53, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 0f, num * 1f, 52);
		mAnimator.AddTween(54, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 1f, num * 1f, 53);
		mAnimator.AddTween(55, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, 0.001f, 0f, num * 1f, 54);
		mAnimator.AddTween(56, TweenAnimator.TweenType.Alpha, rankUpTexture.gameObject, num * 2f, 1f, num * 1f, 55);
		mAnimator.AddTween(60, TweenAnimator.TweenType.Alpha, rankUpNumber.gameObject, num * 2f, 1f, num * 2f, 13, 0f);
		mAnimator.AddTween(61, TweenAnimator.TweenType.Position, rankUpNumber.gameObject, num * 4f, mRankUpNumberUpPosition, num * 2f, 13, mRankUpNumberDownPosition);
		mAnimator.AddTween(62, TweenAnimator.TweenType.Position, rankUpNumber.gameObject, num * 6f, mRankUpNumberMiddlePosition, 0f, 61);
		mAnimator.AddTween(620, TweenAnimator.TweenType.Scale, rankUpNumber.gameObject, num * 4f, new Vector3(84f, 84f, 1f), 0f, 64, new Vector3(101f, 101f, 1f));
		mAnimator.AddTween(621, TweenAnimator.TweenType.Position, rankUpNumber.gameObject, num * 4f, mRankUpNumberLeftPosition, 0f, 64);
		mAnimator.AddTween(63, TweenAnimator.TweenType.Position, headerLeft.gameObject, num * 9f, headerLeft.transform.localPosition.ReplaceX(0f), 0f, 62);
		mAnimator.AddTween(64, TweenAnimator.TweenType.Position, headerLeft.gameObject, num * 2f, headerLeft.transform.localPosition.ReplaceX(-230f), 0f, 63);
		mAnimator.AddTween(65, TweenAnimator.TweenType.Scale, headerLeft.gameObject, num * 4f, Vector3.one, 0f, 64, new Vector3(1.3f, 1.3f, 1f));
		mAnimator.AddTween(66, TweenAnimator.TweenType.Alpha, armyPowerIcon.gameObject, num * 2f, 1f, 0f, 63, 0f);
		mAnimator.AddTween(67, TweenAnimator.TweenType.Position, armyPowerIcon.gameObject, num * 5f, mArmyPowerIconUp, 0f, 63, mArmyPowerIconDown, UITweener.Method.EaseIn);
		mAnimator.AddTween(68, TweenAnimator.TweenType.Position, armyPowerIcon.gameObject, num * 4f, mArmyPowerIconEnd, 0f, 67, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(69, TweenAnimator.TweenType.Alpha, armyPowerIncrease.gameObject, num * 2f, 1f, 0f, 63, 0f);
		mAnimator.AddTween(70, TweenAnimator.TweenType.Position, armyPowerIncrease.gameObject, num * 3f, mArmyPowerIncreaseRight, 0f, 69, mArmyPowerIncreaseLeft, UITweener.Method.EaseIn);
		mAnimator.AddTween(71, TweenAnimator.TweenType.Position, armyPowerIncrease.gameObject, num * 4f, mArmyPowerIncreaseEnd, 0f, 70, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(72, TweenAnimator.TweenType.Alpha, armyPowerIncrease.gameObject, num * 17f, 1f, 0f, 71);
		mAnimator.AddTween(73, TweenAnimator.TweenType.Position, continueButton.gameObject, num * 6f, mContinueButtonUp, num * 11f, 71, mContinueButtonDown, UITweener.Method.EaseOut);
		mAnimator.AddTween(74, TweenAnimator.TweenType.Position, continueButton.gameObject, num * 7f, mContinueButtonEnd, 0f, 73, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(75, TweenAnimator.TweenType.Position, armyPowerIncrease.gameObject, num * 4f, mArmyPowerIncreaseHide, 0f, 72);
		mAnimator.AddTween(76, TweenAnimator.TweenType.Alpha, armyPowerIncrease.gameObject, num * 3f, 0f, num * 1f, 72);
		mAnimator.AddTween(77, TweenAnimator.TweenType.Position, armyPowerIcon.gameObject, num * 4f, mArmyPowerIconLeft, 0f, 72);
		mAnimator.AddTween(78, TweenAnimator.TweenType.Alpha, armyPowerValue.gameObject, num * 2f, 1f, num * 2f, 72, 0f);
		mAnimator.AddTween(79, TweenAnimator.TweenType.Position, armyPowerValue.gameObject, num * 2f, mArmyPowerEnd, num * 2f, 72, mArmyPowerDown);
		mAnimator.AddTween(80, TweenAnimator.TweenType.Scale, headerRight, num * 3f, Vector3.one, 0f, 75, new Vector3(1.2f, 1.2f, 1f));
		mAnimator.AddTween(81, TweenAnimator.TweenType.Alpha, rewardLabel.gameObject, num * 6f, 1f, num * 2f, 75, 0f);
		mAnimator.AddTween(82, TweenAnimator.TweenType.Position, rewardLabel.gameObject, num * 3f, mRewarHeader2, num * 2f, 75, mRewarHeader1, UITweener.Method.EaseIn);
		mAnimator.AddTween(83, TweenAnimator.TweenType.Position, rewardLabel.gameObject, num * 3f, mRewarHeader3, 0f, 82, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(84, TweenAnimator.TweenType.Alpha, leftStripes[2].gameObject, num * 8f, 0.3f, num * 4f, 75, 0f);
		mAnimator.AddTween(85, TweenAnimator.TweenType.Position, leftStripes[2].gameObject, num * 2f, mLeftStripeClose2, num * 6f, 75, mLeftStripeClose1, UITweener.Method.EaseIn);
		mAnimator.AddTween(86, TweenAnimator.TweenType.Position, leftStripes[2].gameObject, num * 4f, mLeftStripeClose3, 0f, 85, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(87, TweenAnimator.TweenType.Alpha, leftStripes[1].gameObject, num * 6f, 0.3f, num * 7f, 75, 0f);
		mAnimator.AddTween(88, TweenAnimator.TweenType.Alpha, leftStripes[1].gameObject, num * 1f, 0.2f, 0f, 87);
		mAnimator.AddTween(89, TweenAnimator.TweenType.Position, leftStripes[1].gameObject, num * 2f, mLeftStripeMiddle2, num * 9f, 75, mLeftStripeMiddle1, UITweener.Method.EaseIn);
		mAnimator.AddTween(90, TweenAnimator.TweenType.Position, leftStripes[1].gameObject, num * 4f, mLeftStripeMiddle3, 0f, 89, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(91, TweenAnimator.TweenType.Alpha, leftStripes[0].gameObject, num * 6f, 0.3f, num * 9f, 75, 0f);
		mAnimator.AddTween(92, TweenAnimator.TweenType.Alpha, leftStripes[0].gameObject, num * 4f, 0.1f, 0f, 91);
		mAnimator.AddTween(93, TweenAnimator.TweenType.Position, leftStripes[0].gameObject, num * 2f, mLeftStripeFar2, num * 11f, 75, mLeftStripeFar1, UITweener.Method.EaseIn);
		mAnimator.AddTween(94, TweenAnimator.TweenType.Position, leftStripes[0].gameObject, num * 4f, mLeftStripeFar3, 0f, 93, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(95, TweenAnimator.TweenType.Alpha, rightStripes[2].gameObject, num * 8f, 0.3f, num * 4f, 75, 0f);
		mAnimator.AddTween(96, TweenAnimator.TweenType.Position, rightStripes[2].gameObject, num * 2f, mRightStripeClose2, num * 6f, 75, mRightStripeClose1, UITweener.Method.EaseIn);
		mAnimator.AddTween(97, TweenAnimator.TweenType.Position, rightStripes[2].gameObject, num * 4f, mRightStripeClose3, 0f, 96, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(98, TweenAnimator.TweenType.Alpha, rightStripes[1].gameObject, num * 6f, 0.3f, num * 7f, 75, 0f);
		mAnimator.AddTween(99, TweenAnimator.TweenType.Alpha, rightStripes[1].gameObject, num * 1f, 0.2f, 0f, 98);
		mAnimator.AddTween(100, TweenAnimator.TweenType.Position, rightStripes[1].gameObject, num * 2f, mRightStripeMiddle2, num * 9f, 75, mRightStripeMiddle1, UITweener.Method.EaseIn);
		mAnimator.AddTween(101, TweenAnimator.TweenType.Position, rightStripes[1].gameObject, num * 4f, mRightStripeMiddle3, 0f, 100, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(102, TweenAnimator.TweenType.Alpha, rightStripes[0].gameObject, num * 6f, 0.3f, num * 9f, 75, 0f);
		mAnimator.AddTween(103, TweenAnimator.TweenType.Alpha, rightStripes[0].gameObject, num * 4f, 0.1f, 0f, 102);
		mAnimator.AddTween(104, TweenAnimator.TweenType.Position, rightStripes[0].gameObject, num * 2f, mRightStripeFar2, num * 11f, 75, mRightStripeFar1, UITweener.Method.EaseIn);
		mAnimator.AddTween(105, TweenAnimator.TweenType.Position, rightStripes[0].gameObject, num * 4f, mRightStripeFar3, 0f, 104, null, UITweener.Method.EaseOut);
		mAnimator.GenerateTweens();
	}

	private void OnTweenFinished(int tweenId)
	{
		if (tweenId == 13)
		{
			rankUpTexture.transform.localScale = new Vector3(157f, 157f, 1f);
			rankUpTexture.transform.localPosition = new Vector3(-324f, 0f, rankUpTexture.transform.localPosition.z);
			headerLeft.transform.localScale = new Vector3(1.3f, 1.3f, 1f);
		}
		if (tweenId == 62)
		{
			LevelManager.instance.isLevelUp = false;
			GuiElementSingle<MenuHeader>.instance.UpdateLevel();
			float num = 1f / (float)fps;
			healthInfo.PlayAnimation(num * 1f);
			shieldInfo.PlayAnimation(num * 7f);
			warcardsInfo.PlayAnimation(num * 13f);
		}
		if (tweenId == 73 && !Singleton<GameController>.instance.isTutorial)
		{
			UIEventListener uIEventListener = UIEventListener.Get(overlayBackground.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		}
		if (tweenId == 82)
		{
			ShowFirstItems();
			AnimateGold();
		}
		if (tweenId == 105)
		{
			completeAnimation = true;
		}
	}

	private void ShowFirstItems()
	{
		mShowPart = 0;
		int num = Mathf.Min(mUnlocks.Count, items.Length);
		bool flag = mUnlocks.Count > 4 && (mUnlocks.Count % 4 == 1 || mUnlocks.Count % 4 == 2);
		if (Singleton<GameController>.instance.isTutorial)
		{
			items[0].ShowOnPosition(0, num, mUnlocks[0], animate: true);
			for (int i = 1; i < items.Length; i++)
			{
				items[i].ShowOnPosition(i, num, LevelUpUnlock.CreateEmpty(), animate: true);
			}
		}
		else if (flag)
		{
			int num2 = 3;
			for (int j = 0; j < num2; j++)
			{
				items[j].ShowOnPosition(j, num2, mUnlocks[j], animate: true);
			}
			for (int k = num2; k < items.Length; k++)
			{
				items[k].ShowOnPosition(k, num, LevelUpUnlock.CreateEmpty(), animate: true);
			}
		}
		else
		{
			for (int l = 0; l < num; l++)
			{
				items[l].ShowOnPosition(l, num, mUnlocks[l], animate: true);
			}
			for (int m = num; m < items.Length; m++)
			{
				items[m].ShowOnPosition(m, num, LevelUpUnlock.CreateEmpty(), animate: true);
			}
		}
		mAnimating = false;
		StartItemChanger();
	}

	private IEnumerator SwitchItems()
	{
		yield return new WaitForRealSeconds(5f);
		int max = mUnlocks.Count;
		int numberOfBoxes = ((mUnlocks.Count <= 4 || (mUnlocks.Count % 4 != 1 && mUnlocks.Count % 4 != 2)) ? items.Length : 3);
		while (max > numberOfBoxes)
		{
			mShowPart = (mShowPart + 1) % ((max + numberOfBoxes - 1) / numberOfBoxes);
			int startIndex = mShowPart * numberOfBoxes;
			max = Mathf.Min(max - startIndex, numberOfBoxes);
			for (int i = 0; i < max; i++)
			{
				items[i].SwitchTo(mUnlocks[startIndex + i], (float)i * 0.1f, i, max);
			}
			for (int j = max; j < items.Length; j++)
			{
				items[j].SwitchTo(LevelUpUnlock.CreateEmpty(), (float)j * 0.1f, j, max);
			}
			yield return new WaitForRealSeconds(4f);
			max = mUnlocks.Count;
		}
	}

	private void StartItemChanger()
	{
		if (mItemChanger == null)
		{
			mItemChanger = RadicalRoutine.Create(SwitchItems());
			StartCoroutine(RadicalRoutine.Run(mItemChanger.enumerator));
		}
	}

	private void StopItemChanger()
	{
		if (mItemChanger != null)
		{
			mItemChanger.Cancel();
			mItemChanger = null;
		}
	}

	private void AnimateGold()
	{
		mAnimateToGoldInHeader.val = Singleton<Wallet>.instance.goldAfterGame + LevelManager.instance.previousLevel.golds;
		TweenTextCounterLong.Begin(GuiElementSingle<MenuHeader>.instance.goldLabel.gameObject, 1f, mAnimateToGoldInHeader);
	}

	private void InitializeValues()
	{
		LevelManager.GameLevel currentLevel = LevelManager.instance.currentLevel;
		string text = Localization.Localize("ID_RANKUP");
		int num = text.IndexOf(' ', 1);
		int num2 = LevelManager.instance.GetRankPowerX10(currentLevel.displayNumber) - LevelManager.instance.GetRankPowerX10(currentLevel.displayNumber - 1);
		rankUpTexture.mainTexture = Resources.Load<Texture>("Ranks/" + currentLevel.iconName);
		animationRankUpLeft.transform.localScale = new Vector3(198f, 198f, 1f);
		animationRankUpRight.transform.localScale = new Vector3(198f, 198f, 1f);
		if (num > 0)
		{
			int num3 = text.IndexOf(' ', num + 1);
			while (num3 > 0)
			{
				int num4 = Mathf.Abs(text.Length / 2 - num);
				int num5 = Mathf.Abs(text.Length / 2 - num3);
				if (num5 < num4)
				{
					num = num3;
					num3 = text.IndexOf(' ', num + 1);
					continue;
				}
				break;
			}
			string text2 = text.Substring(0, num);
			string text3 = text.Substring(num + 1);
			animationRankUpLeft.text = text2;
			animationRankUpRight.text = text3;
			float num6 = animationRankUpLeft.relativeSize.x * 198f;
			float num7 = animationRankUpRight.relativeSize.x * 198f;
			float num8 = animationRankUpLeft.getSizeForString(" ").x * 198f;
			float num9 = num6 + num8 + num7;
			animationRankUpLeft.transform.localPosition = animationRankUpLeft.transform.localPosition.ReplaceX(num9 * 0.5f - num8 - num7);
			animationRankUpRight.transform.localPosition = animationRankUpRight.transform.localPosition.ReplaceX(num9 * 0.5f - num7);
		}
		else
		{
			animationRankUpLeft.text = text;
			animationRankUpRight.text = string.Empty;
			float num10 = animationRankUpLeft.relativeSize.x * 198f;
			animationRankUpLeft.cachedTransform.localPosition = animationRankUpLeft.cachedTransform.localPosition.ReplaceX(num10 / 2f);
			animationRankUpRight.cachedTransform.localPosition = animationRankUpLeft.cachedTransform.localPosition.ReplaceX(UIRoot.list[0].activeWidth);
		}
		rankUpNumber.text = Localization.LocalizeFormat("ID_RANKX", currentLevel.displayNumber);
		armyPowerIncrease.text = MiscTools.FormatMedalsDifference(num2);
		armyPowerValue.text = MiscTools.FormatBigNumber(LevelManager.instance.armyPowerX10);
	}

	private void HideObjects()
	{
		animationGlow.alpha = 0f;
		animationRankUpLeft.alpha = 0f;
		animationRankUpRight.alpha = 0f;
		rankUpTexture.alpha = 0f;
		rankUpNumber.alpha = 0f;
		armyPowerIcon.alpha = 0f;
		armyPowerIncrease.alpha = 0f;
		armyPowerValue.alpha = 0f;
		leftStripes[0].alpha = 0f;
		leftStripes[1].alpha = 0f;
		leftStripes[2].alpha = 0f;
		rewardLabel.alpha = 0f;
		rightStripes[0].alpha = 0f;
		rightStripes[1].alpha = 0f;
		rightStripes[2].alpha = 0f;
		for (int i = 0; i < items.Length; i++)
		{
			items[i].SetItem(setActive: false);
		}
	}

	private void InitializeObjects()
	{
		animationGlow.transform.localScale = mGlowOriginal;
		animationRankUpLeft.transform.localScale = mTextScaleOne;
		animationRankUpRight.transform.localScale = mTextScaleOne;
		headerLeft.transform.localScale = new Vector3(1f, 1f, 1f);
		headerLeft.transform.localPosition = headerLeft.transform.localPosition.ReplaceX(0f);
		rankUpTexture.transform.localPosition = mRankUpStartAnimationDownPosition;
		rankUpNumber.transform.localPosition = mRankUpNumberDownPosition;
		rankUpNumber.transform.localScale = new Vector3(101f, 101f, 1f);
		headerRight.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
		armyPowerIcon.transform.localPosition = mArmyPowerIconDown;
		armyPowerIncrease.transform.localPosition = mArmyPowerIncreaseLeft;
		armyPowerValue.transform.localPosition = mArmyPowerDown;
		leftStripes[0].transform.localPosition = mLeftStripeFar1;
		leftStripes[1].transform.localPosition = mLeftStripeMiddle1;
		leftStripes[2].transform.localPosition = mLeftStripeClose1;
		rewardLabel.transform.localPosition = mRewarHeader1;
		rightStripes[0].transform.localPosition = mRightStripeFar1;
		rightStripes[1].transform.localPosition = mRightStripeMiddle1;
		rightStripes[2].transform.localPosition = mRightStripeClose1;
		continueButton.transform.localPosition = mContinueButtonDown;
	}

	private void GetCurrentLevelUnlocks()
	{
		mUnlocks.Clear();
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.warcardsUnlockLevel)
		{
			mUnlocks.Add(LevelUpUnlock.CreateWarCards());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.joinSquadUnlockLevel)
		{
			mUnlocks.Add(LevelUpUnlock.CreateSquadJoin());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.createSquadUnlockLevel)
		{
			mUnlocks.Add(LevelUpUnlock.CreateSquadCreate());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.warpathUnlockLevel)
		{
			mUnlocks.Add(LevelUpUnlock.CreateWarpath());
		}
		if (Singleton<GameVariables>.instance.isInstantBattleEnabled && LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.instantBattleUnlockLevel)
		{
			mUnlocks.Add(LevelUpUnlock.CreateInstantBattle());
			Singleton<MessageManager>.instance.AddMessage(new InstantBattleUnlockedMessage());
		}
		if (LevelManager.instance.currentLevel.displayNumber == LevelManager.instance.warArenaUnlockLevel)
		{
			mUnlocks.Add(LevelUpUnlock.CreateWarArena());
			Singleton<MessageManager>.instance.AddMessage(new ArenaUnlockedMessage());
		}
		List<MapManager.MapEntry> mapUnlocks = Singleton<MapManager>.instance.mapUnlocks;
		foreach (MapManager.MapEntry item in mapUnlocks)
		{
			mUnlocks.Add(LevelUpUnlock.CreateMap(item));
		}
		List<LevelBehaviour> armyUnlocks = LevelManager.instance.armyUnlocks;
		foreach (LevelBehaviour item2 in armyUnlocks)
		{
			mUnlocks.Add(LevelUpUnlock.CreateUnit(item2));
		}
		List<WeaponLevelsSetup> weaponUnlocks = LevelManager.instance.weaponUnlocks;
		foreach (WeaponLevelsSetup item3 in weaponUnlocks)
		{
			mUnlocks.Add(LevelUpUnlock.CreateWeapon(item3));
		}
		if (LevelManager.instance.previousLevel.golds > 0)
		{
			mUnlocks.Add(LevelUpUnlock.CreateGold(LevelManager.instance.previousLevel.golds));
		}
		mUnlocks.Add(LevelUpUnlock.CreateDogTag());
	}

	public void TutorialHideParts()
	{
		float num = 0.3f;
		healthInfo.TutorialHide(num);
		shieldInfo.TutorialHide(num);
		warcardsInfo.TutorialHide(num);
		TweenAlpha.Begin(rankUpTexture.gameObject, num, 0f);
		TweenAlpha.Begin(rankUpNumber.gameObject, num, 0f);
		TweenAlpha.Begin(armyPowerIcon.gameObject, num, 0f);
		TweenAlpha.Begin(armyPowerIncrease.gameObject, num, 0f);
		TweenAlpha.Begin(armyPowerValue.gameObject, num, 0f);
		TweenAlpha.Begin(leftStripes[0].gameObject, num, 0f);
		TweenAlpha.Begin(leftStripes[1].gameObject, num, 0f);
		TweenAlpha.Begin(leftStripes[2].gameObject, num, 0f);
		TweenAlpha.Begin(rewardLabel.gameObject, num, 0f);
		TweenAlpha.Begin(rightStripes[0].gameObject, num, 0f);
		TweenAlpha.Begin(rightStripes[1].gameObject, num, 0f);
		TweenAlpha.Begin(rightStripes[2].gameObject, num, 0f);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		if (UIEventListener.Get(overlayBackground.gameObject).onClick != null)
		{
			CloseDialog(overlayBackground.gameObject);
		}
	}
}
