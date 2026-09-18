using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGuiRecord : PoolableObject
{
	[Header("Core")]
	public UISprite background;

	public UISprite weaponSprite;

	public UISprite highlight;

	[Header("-Locked")]
	public GameObject locked;

	public UILabel lockedRank;

	[Header("-Not Bought")]
	public GameObject notBought;

	public UISprite buyGoldIcon;

	public UISprite buyWbIcon;

	[Header("-Icons")]
	public UISprite deliveringIcon;

	public UISprite equipedIcon;

	public UISprite upgradingIcon;

	[Header("-Special")]
	public GameObject specialPart;

	[Header("-Rented")]
	public UILabel rentedLabel;

	[Header("-Sale")]
	public GameObject salePart;

	[Header("-Notification")]
	public GameObject notification;

	private TweenAnimator mAnimator;

	private TweenAnimator mAnimator2;

	private WeaponLevelsSetup.State mState;

	private WeaponLevelsSetup mWeaponSetup;

	public WeaponLevelsSetup weaponSetup => mWeaponSetup;

	public void CheckState()
	{
		if (mState != mWeaponSetup.weaponState)
		{
			mState = mWeaponSetup.weaponState;
			UpdateGraphics();
		}
	}

	public void Init(WeaponLevelsSetup setup)
	{
		mWeaponSetup = setup;
		PlayerWeapon playerWeapon = mWeaponSetup.playerWeapon;
		weaponSprite.spriteName = playerWeapon.iconName;
		weaponSprite.MakePixelPerfect();
		weaponSprite.transform.localScale = weaponSprite.transform.localScale.MultiplyXY(1.1764706f);
		buyWbIcon.gameObject.SetActive(mWeaponSetup.price > 0);
		buyGoldIcon.gameObject.SetActive(mWeaponSetup.priceGold > 0);
		lockedRank.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), mWeaponSetup.unlockLevel.displayNumber);
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
		SetEquiped(isEquiped: false);
		InitGuiValues();
	}

	public void GUIForReposition(bool show)
	{
		if (show)
		{
			notification.SetActive(Singleton<NotificationManager>.instance.NotificationForWeapon(mWeaponSetup));
		}
		else
		{
			notification.SetActive(value: false);
		}
	}

	public void InitGuiValues()
	{
		mState = mWeaponSetup.weaponState;
		UpdateGraphics();
	}

	public void OnClick()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<WeaponScreen>.instance.selectedIcon.SetHighlight(isSelected: false);
		SetHighlight(isSelected: true);
		GuiScreenSingle<WeaponScreen>.instance.selectedIcon = this;
		GuiScreenSingle<WeaponScreen>.instance.Select();
		ShowHideNotification();
	}

	internal void SetEquiped(bool isEquiped)
	{
		background.color = (isEquiped ? Colours.blueEquipped : (mWeaponSetup.purchasableInShop ? Color.white : Color.yellow));
		equipedIcon.alpha = ((!isEquiped) ? 0f : 1f);
	}

	internal void SetHighlight(bool isSelected)
	{
		highlight.gameObject.SetActive(isSelected);
	}

	internal void ShowHideNotification()
	{
		notification.SetActive(Singleton<NotificationManager>.instance.NotificationForWeapon(mWeaponSetup));
	}

	internal void UpdateGraphics()
	{
		WeaponLevelsSetup.State weaponState = mWeaponSetup.weaponState;
		specialPart.SetActive(!mWeaponSetup.purchasableInShop && !mWeaponSetup.bought);
		locked.SetActive(mWeaponSetup.purchasableInShop && weaponState == WeaponLevelsSetup.State.Locked);
		notBought.SetActive(mWeaponSetup.purchasableInShop && weaponState == WeaponLevelsSetup.State.NotBuyed);
		rentedLabel.gameObject.SetActive(mWeaponSetup.tryOutWeapon);
		ShowHideNotification();
		SetSale();
		if (!mWeaponSetup.purchasableInShop && !mWeaponSetup.bought)
		{
			upgradingIcon.alpha = 0f;
			deliveringIcon.alpha = 0f;
			return;
		}
		if (weaponState == WeaponLevelsSetup.State.Delivering)
		{
			mAnimator.PlayTweens();
		}
		else
		{
			mAnimator.FinishTweens();
			mAnimator.ResetTweens();
		}
		upgradingIcon.alpha = ((weaponState != WeaponLevelsSetup.State.Delivering) ? 0f : 1f);
		if (weaponState == WeaponLevelsSetup.State.WeaponDelivering)
		{
			mAnimator2.PlayTweens();
		}
		else
		{
			mAnimator2.FinishTweens();
			mAnimator2.ResetTweens();
		}
		deliveringIcon.alpha = ((weaponState != WeaponLevelsSetup.State.WeaponDelivering) ? 0f : 1f);
	}

	public void SetSale()
	{
		WeaponLevelsSetup.State weaponState = mWeaponSetup.weaponState;
		if ((weaponState == WeaponLevelsSetup.State.NotBuyed || weaponState == WeaponLevelsSetup.State.Locked) && mWeaponSetup.purchasableInShop)
		{
			salePart.SetActive(Singleton<OfferManager>.instance.DiscountedWeapon(mWeaponSetup, OfferBuyType.Buy) > 0);
		}
		else if (weaponState == WeaponLevelsSetup.State.Delivering || weaponState == WeaponLevelsSetup.State.Delivered || weaponState == WeaponLevelsSetup.State.Active)
		{
			salePart.SetActive(mWeaponSetup.canBeUpgraded && Singleton<OfferManager>.instance.DiscountedWeapon(mWeaponSetup, OfferBuyType.Upgrade) > 0);
		}
		else
		{
			salePart.SetActive(value: false);
		}
	}

	private void OnTweenFinished(int tweenID)
	{
		if (tweenID == 3)
		{
			if (mWeaponSetup.weaponState == WeaponLevelsSetup.State.Delivering)
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
			if (mWeaponSetup.weaponState == WeaponLevelsSetup.State.WeaponDelivering)
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
}
