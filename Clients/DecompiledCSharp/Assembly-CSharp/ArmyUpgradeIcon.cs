using System;
using System.Collections.Generic;
using UnityEngine;

public class ArmyUpgradeIcon : PoolableObject
{
	[Header("Core")]
	public UISprite background;

	public UISprite icon;

	public UISprite highlight;

	[Header("-Locked")]
	public GameObject locked;

	public UILabel lockedRank;

	[Header("-Not Bought")]
	public GameObject notBought;

	public UISprite buyGoldIcon;

	public UISprite buyWbIcon;

	[Header("-Promote")]
	public GameObject promotePart;

	public ParticleSystem promoteParticle;

	[Header("-Ability")]
	public UISprite abilityIcon;

	[Header("-Elite")]
	public UISprite eliteIcon;

	public UISprite eliteIconBuff;

	public GameObject buyElitePart;

	public ParticleSystem eliteParticle;

	[Header("-Upgrade")]
	public UISprite deliveringIcon;

	public UISprite upgradingIcon;

	public GameObject tiersProgress;

	public List<UISprite> emptyTiers;

	public UISprite progressBar;

	public List<UISprite> actualTiers;

	[Header("-Rented")]
	public UILabel rentedLabel;

	[Header("-Sale")]
	public GameObject salePart;

	[Header("-Notification")]
	public GameObject notification;

	private TweenAnimator mAnimator;

	private TweenAnimator mAnimator2;

	private LevelBehaviour mUnit;

	private UpgradeSlots.State mUnitState;

	private int mUnitTier;

	private Vector3 mBaseScaleIcon;

	private Vector3 mBigScaleIcon;

	public LevelBehaviour levelBehaviour => mUnit;

	public void Init(LevelBehaviour unit)
	{
		mUnit = unit;
		UpdateName();
		SetIcon(mUnit.upgradeSlots.iconName);
		buyWbIcon.gameObject.SetActive(mUnit.upgradeSlots.price > 0);
		buyGoldIcon.gameObject.SetActive(mUnit.upgradeSlots.priceGold > 0);
		lockedRank.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), mUnit.upgradeSlots.unlockLevel.displayNumber);
		abilityIcon.spriteName = mUnit.abilityIcon;
		abilityIcon.MakePixelPerfect();
		abilityIcon.transform.localScale = abilityIcon.transform.localScale.MultiplyXY(0.75f);
		if (unit.upgradeSlots.upgradeSlotElite.isUnlocked)
		{
			unit.SetUpEliteIcon(eliteIcon, eliteIconBuff);
		}
		if (mAnimator == null)
		{
			mAnimator = base.gameObject.AddComponent<TweenAnimator>();
			mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
			float time = 0.7f;
			mAnimator.AddTween(from: new Vector3(110f, -57f, 0f), id: 1, tweenType: TweenAnimator.TweenType.Position, tweenTarget: upgradingIcon.gameObject, time: time, to: new Vector3(110f, -57f, 0f), delay: 0f);
			mAnimator.AddTween(2, TweenAnimator.TweenType.Position, upgradingIcon.gameObject, time, new Vector3(110f, -40f, 0f), 0f, 1);
			mAnimator.AddTween(3, TweenAnimator.TweenType.Position, upgradingIcon.gameObject, time, new Vector3(110f, -57f, 0f), 0f, 2);
			TweenAnimator tweenAnimator = mAnimator;
			tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(OnTweenFinished));
			mAnimator.GenerateTweens();
		}
		if (mAnimator2 == null)
		{
			mAnimator2 = base.gameObject.AddComponent<TweenAnimator>();
			mAnimator2.allTweens = new List<TweenAnimator.TweenRecord>();
			float time2 = 0.7f;
			mAnimator2.AddTween(from: new Vector3(110f, -57f, 0f), id: 1, tweenType: TweenAnimator.TweenType.Position, tweenTarget: deliveringIcon.gameObject, time: time2, to: new Vector3(110f, -57f, 0f), delay: 0f);
			mAnimator2.AddTween(2, TweenAnimator.TweenType.Position, deliveringIcon.gameObject, time2, new Vector3(110f, -40f, 0f), 0f, 1);
			mAnimator2.AddTween(3, TweenAnimator.TweenType.Position, deliveringIcon.gameObject, time2, new Vector3(110f, -57f, 0f), 0f, 2);
			TweenAnimator tweenAnimator2 = mAnimator2;
			tweenAnimator2.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator2.TweenFinished, new Action<int>(OnTweenFinished2));
			mAnimator2.GenerateTweens();
		}
		SetHighlight(isSelected: false);
		InitGuiValuesGraphics();
	}

	public void InitGuiValuesGraphics()
	{
		mUnitState = mUnit.upgradeSlots.unitState;
		mUnitTier = mUnit.upgradeSlots.actualTier;
		UpdateGraphics();
	}

	public void SetHighlight(bool isSelected)
	{
		highlight.gameObject.SetActive(isSelected);
	}

	internal void ShowHideNotification()
	{
		notification.SetActive(Singleton<NotificationManager>.instance.NotificationForArmyUnit(mUnit));
	}

	public void GUIForReposition(bool show)
	{
		if (!show)
		{
			notification.SetActive(value: false);
			highlight.gameObject.SetActive(value: false);
		}
		else
		{
			ShowHideNotification();
		}
		icon.gameObject.SetActive(show);
	}

	internal void UpdateGraphics()
	{
		if (mUnit.upgradeSlots.borrowed)
		{
			background.color = Colours.blueEquipped;
		}
		else if (mUnit.upgradeSlots.equipped)
		{
			background.color = ((!mUnit.upgradeSlots.upgradeSlotElite.isUnlocked || !mUnit.upgradeSlots.upgradeSlotElite.isBought) ? Colours.blueEquipped : Colours.greenArena);
		}
		else
		{
			background.color = Color.white;
		}
		UpgradeSlots.State unitState = mUnit.upgradeSlots.unitState;
		locked.SetActive(unitState == UpgradeSlots.State.Locked);
		notBought.SetActive(unitState == UpgradeSlots.State.NotBuyed);
		bool flag = mUnit.upgradeSlots.bought && !mUnit.upgradeSlots.borrowed && mUnit.upgradeSlots.upgradeSlotElite.isUnlocked && !mUnit.upgradeSlots.upgradeSlotElite.isBought && mUnit.upgradeSlots.upgradeSlotElite.currentParts >= mUnit.upgradeSlots.upgradeSlotElite.upgradePriceParts;
		buyElitePart.SetActive(flag);
		if (flag)
		{
			eliteParticle.Play();
		}
		bool flag2 = !flag && (unitState == UpgradeSlots.State.Active || !mUnit.upgradeSlots.upgradeSlot.isDelivering) && mUnit.upgradeSlots.upgradeSlot.isTierFullUpgraded && !mUnit.upgradeSlots.isPromoteToNextTierLocked;
		promotePart.SetActive(flag2);
		if (flag2)
		{
			promoteParticle.Play();
		}
		rentedLabel.gameObject.SetActive(mUnit.upgradeSlots.borrowed);
		ShowHideNotification();
		if (unitState == UpgradeSlots.State.Delivering)
		{
			mAnimator.PlayTweens();
		}
		else
		{
			mAnimator.FinishTweens();
			mAnimator.ResetTweens();
		}
		upgradingIcon.alpha = ((unitState != UpgradeSlots.State.Delivering) ? 0f : 1f);
		if (unitState == UpgradeSlots.State.UnitDelivering)
		{
			mAnimator2.PlayTweens();
		}
		else
		{
			mAnimator2.FinishTweens();
			mAnimator2.ResetTweens();
		}
		deliveringIcon.alpha = ((unitState != UpgradeSlots.State.UnitDelivering) ? 0f : 1f);
		abilityIcon.alpha = ((!mUnit.upgradeSlots.upgradeSlotSpecial.isBought) ? 0f : 1f);
		bool flag3 = mUnit.upgradeSlots.upgradeSlotElite.isUnlocked && mUnit.upgradeSlots.upgradeSlotElite.isBought;
		eliteIcon.alpha = ((!flag3) ? 0f : 1f);
		eliteIconBuff.alpha = ((!flag3) ? 0f : 1f);
		tiersProgress.SetActive(unitState == UpgradeSlots.State.Active || unitState == UpgradeSlots.State.Delivering || unitState == UpgradeSlots.State.Delivered);
		if (tiersProgress.activeSelf)
		{
			UpdateProgress(mUnit.upgradeSlots.actualTier, mUnit.upgradeSlots.actualUpgradeProgress);
		}
		SetSale();
	}

	public void SetSale()
	{
		switch (mUnit.upgradeSlots.unitState)
		{
		case UpgradeSlots.State.Locked:
		case UpgradeSlots.State.NotBuyed:
			salePart.SetActive(Singleton<OfferManager>.instance.DiscountedUnit(mUnit, OfferBuyType.Buy) > 0);
			break;
		case UpgradeSlots.State.Active:
		case UpgradeSlots.State.Delivering:
		case UpgradeSlots.State.Delivered:
			salePart.SetActive(mUnit.upgradeSlots.actualUnitLevel < mUnit.upgradeSlots.actualMaxUnitLevel && Singleton<OfferManager>.instance.DiscountedUnit(mUnit, OfferBuyType.Upgrade) > 0);
			break;
		default:
			salePart.SetActive(value: false);
			break;
		}
	}

	private void UpdateProgress(int unitTier, float tierProgress)
	{
		int num = 6 - unitTier;
		for (int i = 0; i < emptyTiers.Count; i++)
		{
			emptyTiers[i].gameObject.SetActive(i < num);
		}
		for (int j = 0; j < actualTiers.Count; j++)
		{
			actualTiers[j].gameObject.SetActive(j < unitTier);
		}
		float num2 = -0.03f + 0.11f * (float)unitTier;
		float num3 = Mathf.Min(1f, 1.04f - 0.11f * (float)num);
		float num4 = num3 - num2;
		progressBar.fillAmount = Mathf.Clamp01(num2 + num4 * tierProgress);
	}

	protected void Update()
	{
		if (mUnitState != mUnit.upgradeSlots.unitState || mUnitTier != mUnit.upgradeSlots.actualTier)
		{
			mUnitState = mUnit.upgradeSlots.unitState;
			mUnitTier = mUnit.upgradeSlots.actualTier;
			UpdateGraphics();
		}
	}

	private void OnClick()
	{
		if (GuiScreenSingle<ArmyScreen>.instance.selectedIcon != null)
		{
			GuiScreenSingle<ArmyScreen>.instance.selectedIcon.SetHighlight(isSelected: false);
		}
		SoundsManager.Instance.PlayButtonClickedSound();
		SetHighlight(isSelected: true);
		GuiScreenSingle<ArmyScreen>.instance.selectedIcon = this;
		GuiScreenSingle<ArmyScreen>.instance.Select();
		ShowHideNotification();
	}

	private void OnTweenFinished(int tweenID)
	{
		if (tweenID == 3)
		{
			if (mUnit.upgradeSlots.unitState == UpgradeSlots.State.Delivering)
			{
				mAnimator.ResetTweens();
				mAnimator.PlayTweens();
			}
			else
			{
				upgradingIcon.alpha = 0f;
			}
		}
	}

	private void OnTweenFinished2(int tweenID)
	{
		if (tweenID == 3)
		{
			if (mUnit.upgradeSlots.unitState == UpgradeSlots.State.UnitDelivering)
			{
				mAnimator2.ResetTweens();
				mAnimator2.PlayTweens();
			}
			else
			{
				deliveringIcon.alpha = 0f;
			}
		}
	}

	public void UpdateName()
	{
		base.name = string.Format("{0} Army Icon LVL{1} ORDER{2}", mUnit.upgradeSlots.actualTier, mUnit.upgradeSlots.unlockLevelIndex.ToString("D2"), mUnit.guiOrder.ToString("D2"));
	}

	private void SetIcon(string spriteName)
	{
		TweenScale component = icon.gameObject.GetComponent<TweenScale>();
		if (component != null)
		{
			component.enabled = false;
		}
		icon.spriteName = spriteName;
		icon.MakePixelPerfect();
		mBaseScaleIcon = icon.transform.localScale;
		mBigScaleIcon = (mBaseScaleIcon * 2f).ReplaceZ(1f);
		Vector3 localPosition = new Vector3(0f, 0f, -1f);
		if (icon.transform.localScale.y > 200f)
		{
			localPosition.y = (icon.transform.localScale.y - 200f) / 2f;
		}
		icon.transform.localPosition = localPosition;
	}

	public void TutorialAnimateIcon()
	{
		TweenScale tweenScale = TweenScale.Begin(icon.gameObject, 0.3f, mBaseScaleIcon, mBigScaleIcon);
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}
}
