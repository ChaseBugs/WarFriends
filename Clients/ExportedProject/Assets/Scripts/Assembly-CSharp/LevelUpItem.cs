using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpItem : Core_BaseScript
{
	[Header("Core")]
	public BoxCollider itemCollider;

	public UISprite border;

	public UISprite glow;

	public UILabel bottomLabel;

	public GameObject centerObject;

	public GameObject tutorialHandPosition;

	[Header("-Picture")]
	public GameObject iconParent;

	public GameObject goldRewardPart;

	public UILabel goldReceivedLabel;

	public GameObject warCardsUnlockedPart;

	public GameObject dogTagsRefillPart;

	public GameObject joiningSquadsPart;

	public GameObject creatingSquadsPart;

	public GameObject mapUnlockedPart;

	public UISprite mapSprite;

	public GameObject warpathUnlockedPart;

	public UISprite unitWeaponUnlockedIcon;

	public UISprite unitTypeIcon;

	public GameObject instantBattlePart;

	public GameObject wararenaPart;

	[Header("-Details")]
	public GameObject detailsPart;

	public UISprite detailsBorder;

	public UILabel detailsLabel;

	private float mStepX = 440f;

	private bool mAllowChange;

	private LevelUpUnlock mCurrentUnlock;

	private string mUnlockedItemName;

	private TweenAnimator mAnimator;

	private TweenPosition mPositionTween;

	private TweenAnimator mDetailsAnimator;

	private RadicalRoutine mTextChanger;

	private Vector3 mBorderScaleOriginal = new Vector3(366f, 394f, 1f);

	private Vector3 mBorderScaleSmall = new Vector3(294f, 316f, 1f);

	private Vector3 mBorderScaleBig = new Vector3(517f, 556f, 1f);

	private Vector3 mLabelPosition1 = new Vector3(0f, -181f, -1f);

	private Vector3 mLabelPosition2 = new Vector3(0f, -123f, -1f);

	private Vector3 mLabelPosition3 = new Vector3(0f, -169f, -1f);

	private Vector3 mLabelPosition4 = new Vector3(0f, -167f, -1f);

	private Vector3 mGlowScaleSmall = new Vector3(1f, 1f, 1f);

	private Vector3 mGlowScaleBig = new Vector3(920f, 280f, 1f);

	private Vector3 mGlowScaleOriginal = new Vector3(340f, 400f, 1f);

	private Vector3 mIconScaleSmall = new Vector3(0.001f, 0.001f, 1f);

	private Vector3 mIconScaleBig = new Vector3(1.44f, 1.44f, 1f);

	private Vector3 mIconScaleOriginal = new Vector3(1f, 1f, 1f);

	private Vector3 mDetailsBorderScaleOriginal = new Vector3(366f, 80f, 1f);

	private Vector3 mDetailsBorderScaleSmall = new Vector3(296f, 65f, 1f);

	private Vector3 mDetailsBorderScaleBig = new Vector3(524f, 115f, 1f);

	private Vector3 mDetailsLabelPosition1 = new Vector3(0f, 20f, -1f);

	private Vector3 mDetailsLabelPosition2 = new Vector3(0f, -4f, -1f);

	private Vector3 mBottomLabelPosition1 = new Vector3(0f, -147f, -1f);

	private Vector3 mBottomLabelPosition2 = new Vector3(0f, -167f, -1f);

	private Vector3 mBottomLabelPosition3 = new Vector3(0f, -189f, -1f);

	public LevelUpUnlock currentUnlock => mCurrentUnlock;

	private bool mShowBottomButton
	{
		get
		{
			if (mCurrentUnlock == null)
			{
				return false;
			}
			return mCurrentUnlock.type == LevelUpUnlock.ItemType.UnitUnlock || mCurrentUnlock.type == LevelUpUnlock.ItemType.WeaponUnlock || mCurrentUnlock.type == LevelUpUnlock.ItemType.MapUnlock || mCurrentUnlock.type == LevelUpUnlock.ItemType.JoinSquadUnlock || mCurrentUnlock.type == LevelUpUnlock.ItemType.CreateSquadUnlock || mCurrentUnlock.type == LevelUpUnlock.ItemType.WarCardsUnlock || mCurrentUnlock.type == LevelUpUnlock.ItemType.WarpathUnlock || mCurrentUnlock.type == LevelUpUnlock.ItemType.InstantBattleUnlock || mCurrentUnlock.type == LevelUpUnlock.ItemType.WarArenaUnlock;
		}
	}

	public void InitializeControls()
	{
		mAnimator = base.gameObject.AddComponent<TweenAnimator>();
		mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		AddDialogAnimations();
		TweenAnimator tweenAnimator = mAnimator;
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(OnTweenFinished));
		mDetailsAnimator = detailsPart.AddComponent<TweenAnimator>();
		mDetailsAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		AddDetailsAnimations();
		mCurrentUnlock = LevelUpUnlock.CreateEmpty();
	}

	public void HideScreen()
	{
		StopSwitchText();
	}

	public void DebugRecreateAnimations()
	{
		mAnimator.allTweens.Clear();
		AddDialogAnimations();
		mDetailsAnimator.allTweens.Clear();
		AddDetailsAnimations();
	}

	public void ShowOnPosition(int myIndex, int numberOfItems, LevelUpUnlock unlockedItem, bool animate)
	{
		mAllowChange = false;
		InitializeLook(unlockedItem);
		float num = 1f / (float)GuiElementSingle<LevelUpDialog>.instance.fps * 7f;
		if (mCurrentUnlock.type == LevelUpUnlock.ItemType.None)
		{
			SetItem(setActive: false);
			base.transform.localPosition = base.transform.localPosition.ReplaceX(3.5f * mStepX);
			return;
		}
		float val = (0f - (float)(numberOfItems - 1) * mStepX) / 2f + mStepX * (float)myIndex;
		Vector3 vector = base.transform.localPosition.ReplaceX(val);
		detailsBorder.alpha = ((!animate) ? 0.1f : 0f);
		detailsLabel.alpha = ((!animate) ? 1f : 0f);
		if (animate)
		{
			base.transform.localPosition = vector;
			glow.transform.localScale = mGlowScaleSmall;
			InvokeAfter(PlayAnimations, (float)myIndex * num);
			return;
		}
		SetItem(setActive: true);
		Vector3 fromnPos = vector.ReplaceX(2500f);
		mPositionTween = TweenPosition.Begin(base.gameObject, 0.35f, fromnPos, vector);
		mPositionTween.delay = 0f;
		mPositionTween.onFinished = null;
		InvokeAfter(delegate
		{
			mAllowChange = true;
		}, 0.15f);
	}

	public void SwitchTo(LevelUpUnlock unlock, float delay, int myIndex, int numberOfItems)
	{
		mAllowChange = false;
		if (mCurrentUnlock.type == LevelUpUnlock.ItemType.None)
		{
			InvokeAfter(delegate
			{
				ShowOnPosition(myIndex, numberOfItems, unlock, animate: false);
			}, delay + 0.35f);
			return;
		}
		Vector3 pos = base.transform.localPosition.ReplaceX(-2500f);
		mPositionTween = TweenPosition.Begin(base.gameObject, 0.35f, pos);
		mPositionTween.delay = delay;
		mPositionTween.onFinished = delegate
		{
			ShowOnPosition(myIndex, numberOfItems, unlock, animate: false);
		};
	}

	private void PlayAnimations()
	{
		itemCollider.enabled = false;
		mAnimator.PlayTweens();
	}

	private void AddDialogAnimations()
	{
		float num = 1f / (float)GuiElementSingle<LevelUpDialog>.instance.fps;
		mAnimator.AddTween(1, TweenAnimator.TweenType.Alpha, border.gameObject, num * 16f, 0.7f, 0f, -1, 0f);
		mAnimator.AddTween(2, TweenAnimator.TweenType.Alpha, border.gameObject, num * 6f, 0.1f, 0f, 1);
		mAnimator.AddTween(from: mBorderScaleBig, id: 3, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: border.gameObject, time: num * 5f, to: mBorderScaleSmall, delay: 0f);
		mAnimator.AddTween(4, TweenAnimator.TweenType.Scale, border.gameObject, num * 5f, mBorderScaleOriginal, 0f, 3);
		mAnimator.AddTween(5, TweenAnimator.TweenType.Alpha, bottomLabel.gameObject, num * 2f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(from: mLabelPosition1, id: 6, tweenType: TweenAnimator.TweenType.Position, tweenTarget: bottomLabel.gameObject, time: num * 4f, to: mLabelPosition2, delay: 0f);
		mAnimator.AddTween(7, TweenAnimator.TweenType.Position, bottomLabel.gameObject, num * 8f, mLabelPosition3, 0f, 6);
		mAnimator.AddTween(8, TweenAnimator.TweenType.Position, bottomLabel.gameObject, num * 2f, mLabelPosition4, 0f, 7);
		mAnimator.AddTween(9, TweenAnimator.TweenType.Scale, glow.gameObject, num * 6f, mGlowScaleBig, 0f, 6, mGlowScaleSmall);
		mAnimator.AddTween(10, TweenAnimator.TweenType.Scale, glow.gameObject, num * 7f, mGlowScaleOriginal, 0f, 9);
		mAnimator.AddTween(11, TweenAnimator.TweenType.Scale, iconParent, num * 5f, mIconScaleBig, 0f, 6, mIconScaleSmall);
		mAnimator.AddTween(12, TweenAnimator.TweenType.Scale, iconParent, num * 7f, mIconScaleOriginal, 0f, 11);
	}

	private void AddDetailsAnimations()
	{
		float num = 1f / (float)GuiElementSingle<LevelUpDialog>.instance.fps;
		mDetailsAnimator.AddTween(13, TweenAnimator.TweenType.Alpha, detailsBorder.gameObject, num * 16f, 0.3f, 0f, -1, 0f);
		mDetailsAnimator.AddTween(14, TweenAnimator.TweenType.Alpha, detailsBorder.gameObject, num * 6f, 0.1f, 0f, 13);
		mDetailsAnimator.AddTween(from: mDetailsBorderScaleBig, id: 15, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: detailsBorder.gameObject, time: num * 5f, to: mDetailsBorderScaleSmall, delay: 0f);
		mDetailsAnimator.AddTween(16, TweenAnimator.TweenType.Scale, detailsBorder.gameObject, num * 4f, mDetailsBorderScaleOriginal, 0f, 15);
		mDetailsAnimator.AddTween(17, TweenAnimator.TweenType.Alpha, detailsLabel.gameObject, num * 3f, 1f, 0f, 15, 0f);
		mDetailsAnimator.AddTween(18, TweenAnimator.TweenType.Position, detailsLabel.gameObject, num * 3f, mDetailsLabelPosition2, 0f, 15, mDetailsLabelPosition1);
	}

	private void OnTweenFinished(int tweenId)
	{
		if (tweenId == 5)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.LevelUpUnlockedItem);
		}
		if (tweenId == 8 && mShowBottomButton)
		{
			mDetailsAnimator.PlayTweens();
		}
		if (tweenId == 12)
		{
			itemCollider.enabled = true;
			StartSwitchText();
		}
	}

	public void SetItem(bool setActive)
	{
		border.gameObject.SetActive(setActive);
		glow.gameObject.SetActive(setActive);
		iconParent.SetActive(setActive);
		bottomLabel.gameObject.SetActive(setActive);
		detailsPart.SetActive(setActive && mShowBottomButton);
		if (setActive && mPositionTween != null)
		{
			mPositionTween.enabled = false;
		}
		if (!setActive)
		{
			mAllowChange = false;
		}
	}

	private void InitializeLook(LevelUpUnlock unlock)
	{
		mCurrentUnlock = unlock;
		glow.gameObject.SetActive(value: true);
		if (mCurrentUnlock.type == LevelUpUnlock.ItemType.WeaponUnlock)
		{
			mUnlockedItemName = mCurrentUnlock.weapon.weaponName.ToUpper();
			unitWeaponUnlockedIcon.spriteName = mCurrentUnlock.weapon.playerWeapon.iconName;
			unitWeaponUnlockedIcon.MakePixelPerfect();
			unitWeaponUnlockedIcon.transform.localScale = unitWeaponUnlockedIcon.transform.localScale.MultiplyXY(1.1764706f);
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.UnitUnlock)
		{
			mUnlockedItemName = mCurrentUnlock.unit.unitName.ToUpper();
			unitWeaponUnlockedIcon.spriteName = mCurrentUnlock.unit.upgradeSlots.iconName;
			unitWeaponUnlockedIcon.MakePixelPerfect();
			unitTypeIcon.spriteName = mCurrentUnlock.unit.unitTypeIcon;
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.MapUnlock)
		{
			mUnlockedItemName = mCurrentUnlock.mapEntry.guiName.ToUpper();
			mapSprite.spriteName = mCurrentUnlock.mapEntry.iconName;
			TweenAlpha.Begin(mapUnlockedPart, 0.1f, 1f, 1f);
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.WarpathUnlock)
		{
			mUnlockedItemName = Localization.Localize("ID_WARPATHUNLOCKED");
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.JoinSquadUnlock)
		{
			mUnlockedItemName = Localization.Localize("ID_JOINSQUADUNLOCKED");
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.CreateSquadUnlock)
		{
			mUnlockedItemName = Localization.Localize("ID_CREATESQUADUNLOCKED");
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.WarCardsUnlock)
		{
			mUnlockedItemName = Localization.Localize("ID_WARCARDSUNLOCKED");
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.GoldReceived)
		{
			mUnlockedItemName = Localization.Localize("ID_RECEIVED");
			goldReceivedLabel.text = MiscTools.FormatBigNumber(mCurrentUnlock.goldReward);
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.DogTagRefill)
		{
			mUnlockedItemName = Localization.Localize("ID_REFILLED");
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.InstantBattleUnlock)
		{
			mUnlockedItemName = Localization.Localize("ID_INSTANTBATTLEUNLOCKED");
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.WarArenaUnlock)
		{
			mUnlockedItemName = Localization.Localize("ID_WARARENAUNLOCKED");
		}
		else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.None)
		{
			mUnlockedItemName = string.Empty;
		}
		bottomLabel.text = mUnlockedItemName;
		bottomLabel.color = Color.white;
		MiscTools.SetUILabelRescale(bottomLabel, 27f, 20f, 350);
		goldRewardPart.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.GoldReceived);
		dogTagsRefillPart.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.DogTagRefill);
		unitWeaponUnlockedIcon.gameObject.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.UnitUnlock || mCurrentUnlock.type == LevelUpUnlock.ItemType.WeaponUnlock);
		unitTypeIcon.gameObject.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.UnitUnlock);
		mapUnlockedPart.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.MapUnlock);
		warpathUnlockedPart.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.WarpathUnlock);
		joiningSquadsPart.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.JoinSquadUnlock);
		creatingSquadsPart.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.CreateSquadUnlock);
		warCardsUnlockedPart.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.WarCardsUnlock);
		instantBattlePart.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.InstantBattleUnlock);
		wararenaPart.SetActive(mCurrentUnlock.type == LevelUpUnlock.ItemType.WarArenaUnlock);
		detailsPart.SetActive(mShowBottomButton);
		if (mShowBottomButton)
		{
			string key = "ID_DETAILS";
			if (mCurrentUnlock.type == LevelUpUnlock.ItemType.WarpathUnlock)
			{
				key = "ID_PLAYWARPATH";
			}
			else if (mCurrentUnlock.type == LevelUpUnlock.ItemType.InstantBattleUnlock || mCurrentUnlock.type == LevelUpUnlock.ItemType.WarArenaUnlock)
			{
				key = "ID_SHOWME";
			}
			detailsLabel.text = Localization.Localize(key);
		}
	}

	private IEnumerator SwitchTexts()
	{
		mAllowChange = true;
		while (true)
		{
			if (mAllowChange && mShowBottomButton)
			{
				TweenAlpha.Begin(bottomLabel.gameObject, 0.2f, 0f);
				TweenPosition.Begin(bottomLabel.gameObject, 0.25f, mBottomLabelPosition2, mBottomLabelPosition3);
				yield return new WaitForRealSeconds(0.25f);
				if (bottomLabel.text == mUnlockedItemName)
				{
					bottomLabel.text = Localization.Localize("ID_UNLOCKED");
					bottomLabel.color = Colours.blue.ReplaceA(0f);
				}
				else
				{
					bottomLabel.text = mUnlockedItemName;
					bottomLabel.color = Color.white.ReplaceA(0f);
				}
				bottomLabel.transform.localPosition = mBottomLabelPosition1;
				TweenAlpha.Begin(bottomLabel.gameObject, 0.2f, 1f);
				TweenPosition.Begin(bottomLabel.gameObject, 0.25f, mBottomLabelPosition1, mBottomLabelPosition2);
				yield return new WaitForRealSeconds(0.25f);
			}
			yield return new WaitForRealSeconds(1f);
		}
	}

	private void StartSwitchText()
	{
		if (mTextChanger == null)
		{
			mTextChanger = RadicalRoutine.Create(SwitchTexts());
			StartCoroutine(RadicalRoutine.Run(mTextChanger.enumerator));
		}
	}

	private void StopSwitchText()
	{
		if (mTextChanger != null)
		{
			mTextChanger.Cancel();
			mTextChanger = null;
		}
	}

	public void TutorialHide(float time)
	{
		TweenAlpha.Begin(border.gameObject, time, 0f);
		TweenAlpha.Begin(bottomLabel.gameObject, time, 0f);
		TweenAlpha.Begin(detailsBorder.gameObject, time, 0f);
		TweenAlpha.Begin(detailsLabel.gameObject, time, 0f);
		goldRewardPart.SetActive(value: false);
		dogTagsRefillPart.SetActive(value: false);
		glow.gameObject.SetActive(value: false);
	}
}
