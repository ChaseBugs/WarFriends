using System.Text;
using UnityEngine;

public class InventoryItem : PoolableObject
{
	public enum InventoryItemIndicatorPriority
	{
		ExplosiveTiming = 1,
		Disarmed
	}

	[Header("Core")]
	public UISprite icon;

	public UILabel pricelabel;

	[Header("Progress Reloading")]
	public UISprite progressBgSprite;

	public UISprite progressSprite;

	[Header("Border")]
	public UISprite topBracket;

	public UISprite selectedBorder;

	[Header("Bottom")]
	public UISprite bottomBg;

	[Header("Labels")]
	public UILabel reloadingLabel;

	public GameObject outOfAmmo;

	public UILabel ammoAddedLabel;

	public GameObject blockedLabel;

	[Header("Progress")]
	public GameObject icoPrigressObject;

	public UISprite icoProgressBG;

	public UISprite icoProgressFG;

	[Header("Warcard Icon")]
	public UISprite explosivePistolIcon;

	private WeaponInventory mInventory;

	private PlayerWeapon mWeapon;

	private bool mIsLowAmmo;

	private bool mIsSelected;

	private int mLastAmmoLeft;

	private int mLastPriority;

	private bool mIsReloading;

	private bool mIsEnabled;

	private StringBuilder mText = new StringBuilder(16);

	private bool IsReloading
	{
		get
		{
			return mIsReloading;
		}
		set
		{
			if (value != mIsReloading)
			{
				mIsReloading = value;
				if (value)
				{
					progressBgSprite.gameObject.SetActive(value: true);
					progressSprite.gameObject.SetActive(value: true);
				}
				else
				{
					progressBgSprite.gameObject.SetActive(value: false);
					progressSprite.gameObject.SetActive(value: false);
				}
			}
		}
	}

	private void OnClick()
	{
		if (!PlayerController.currentPlayer.updateWeapons || !icon.gameObject.activeSelf)
		{
			return;
		}
		if (!mIsSelected && !mWeapon.weapon.outOfAmmo && mWeapon.isEnabled)
		{
			mInventory.currentWeapon = mWeapon;
			if ((mWeapon.weaponLevelSetup.weaponCategory & WeaponCategory.Primary) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.SwitchWeapon_Primary);
			}
			else if ((mWeapon.weaponLevelSetup.weaponCategory & WeaponCategory.Special) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.SwitchWeapon_Secondary);
			}
			else if ((mWeapon.weaponLevelSetup.weaponCategory & WeaponCategory.Explosive) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.SwitchWeapon_Explosive);
			}
			else
			{
				SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.SwitchWeapon_Pistol);
			}
		}
		else if (!mWeapon.weapon.isReloading && mWeapon.weapon.ammoLeftInClip < (int)mWeapon.weapon.clipSize)
		{
			mWeapon.weapon.Reload();
		}
	}

	public void CreateFromWeapon(PlayerWeapon weapon, WeaponInventory inventory)
	{
		icon.spriteName = weapon.iconName;
		icon.MakePixelPerfect();
		icon.transform.localScale = icon.transform.localScale.MultiplyXY(56f / 85f);
		mInventory = inventory;
		mWeapon = weapon;
		mIsSelected = false;
		mIsReloading = true;
		IsReloading = false;
		mIsEnabled = mWeapon.isEnabled;
		mLastAmmoLeft = mWeapon.weapon.ammoLeft;
		icoPrigressObject.SetActive(value: false);
		mLastPriority = -1;
		UnSelect();
		SetShowed(showed: true);
		mIsEnabled = mWeapon.isEnabled;
		SetEnabled(mIsEnabled);
	}

	public void PlayAmmoAddedAnimation(int addedAmmo)
	{
		ammoAddedLabel.text = addedAmmo.ToString("+0");
		ammoAddedLabel.alpha = 0f;
		ammoAddedLabel.cachedTransform.localScale = Vector3.one;
		Vector3 localPosition = ammoAddedLabel.cachedTransform.localPosition;
		localPosition.x = MiscTools.RoundToInt((pricelabel.relativeSize.x - ammoAddedLabel.relativeSize.x) * 0.5f * pricelabel.cachedTransform.localScale.x);
		int num = MiscTools.RoundToInt(Mathf.Round(pricelabel.transform.localScale.x / 0.826f) * 0.091f);
		localPosition.y = -10f - (float)num;
		ammoAddedLabel.cachedTransform.localPosition = localPosition;
		localPosition.y = 15f - (float)num;
		TweenPosition.Begin(ammoAddedLabel.gameObject, 2f, localPosition);
		TweenScale.Begin(ammoAddedLabel.gameObject, 2f, pricelabel.cachedTransform.localScale);
		TweenAlpha.Begin(ammoAddedLabel.gameObject, 2f, 1f).onFinished = delegate
		{
			ammoAddedLabel.gameObject.SetActive(value: false);
		};
		ammoAddedLabel.gameObject.SetActive(value: true);
	}

	public void ShowIcon()
	{
	}

	protected void Update()
	{
		int ammoLeft = mWeapon.weapon.ammoLeft;
		if (mLastAmmoLeft < ammoLeft)
		{
			PlayAmmoAddedAnimation(ammoLeft - mLastAmmoLeft);
		}
		mLastAmmoLeft = ammoLeft;
		if (mIsSelected && mInventory.currentWeapon != mWeapon)
		{
			UnSelect();
			mIsSelected = false;
		}
		else if (!mIsSelected && mInventory.currentWeapon == mWeapon)
		{
			Select();
			mIsSelected = true;
		}
		IsReloading = mWeapon.weapon.isReloading;
		progressSprite.fillAmount = mWeapon.weapon.reloadProgress;
		if (mWeapon.weapon.outOfAmmo)
		{
			pricelabel.text = Localization.Localize("ID_EMPTY");
			pricelabel.color = Colours.redLose;
			pricelabel.transform.localScale = new Vector3(33f, 33f, 1f);
		}
		else
		{
			mText.Length = 0;
			pricelabel.color = ((!mIsSelected) ? Color.white : Color.black);
			pricelabel.transform.localScale = new Vector3(41f, 41f, 1f);
			if (mWeapon.weapon.reloadableWeapon)
			{
				if (mWeapon.weapon.ammoLeft == int.MaxValue || mWeapon.weapon.infiniteAmmo)
				{
					mText.Append(mWeapon.weapon.ammoLeftInClip);
					mText.Append("/oo");
				}
				else
				{
					mText.Append(mWeapon.weapon.ammoLeftInClip);
					mText.Append("/");
					mText.Append(mWeapon.weapon.ammoLeft);
				}
			}
			else if (mWeapon.weapon.infiniteAmmo)
			{
				mText.Append("oo");
			}
			else
			{
				mText.Append(mWeapon.weapon.ammoLeft);
			}
			pricelabel.text = mText.ToString();
		}
		outOfAmmo.gameObject.SetActive(mWeapon.weapon.outOfAmmo && icon.gameObject.activeSelf);
		if (mWeapon.isEnabled != mIsEnabled)
		{
			mIsEnabled = mWeapon.isEnabled;
			SetEnabled(mIsEnabled);
		}
		blockedLabel.SetActive(mInventory.cannotChange && mInventory.currentWeapon != mWeapon && !Singleton<GameController>.instance.isTutorial);
		if (mInventory.cannotChange && mInventory.currentWeapon != mWeapon && !Singleton<GameController>.instance.isTutorial)
		{
			UpdateIcoProgress("game-card-ico-disarmed", 2, mInventory.canNotChangeFract);
		}
		else
		{
			SetIcoProgress(show: false, "game-card-ico-disarmed", 2);
		}
		SetIcoProgress(mWeapon.haveNextNoReload, "game-card-ico-explosivetiming", 1);
		float num = (float)mWeapon.weapon.ammoLeftInClip / (float)(int)mWeapon.weapon.clipSize;
		if (mWeapon.weapon.reloadableWeapon)
		{
			if ((double)num < 0.2 && !mIsLowAmmo && mWeapon.weapon.ammoLeft > 0)
			{
				reloadingLabel.gameObject.SetActive(value: true);
				TweenAlpha tweenAlpha = TweenAlpha.Begin(reloadingLabel.gameObject, 0.2f, 0f, 1f);
				tweenAlpha.style = UITweener.Style.PingPong;
				mIsLowAmmo = true;
			}
			if ((double)num > 0.2 && mIsLowAmmo)
			{
				reloadingLabel.gameObject.SetActive(value: false);
				mIsLowAmmo = false;
			}
		}
	}

	public void SetIcoProgress(bool show, string spriteName, int priority)
	{
		if (show && (!icoPrigressObject.activeSelf || mLastPriority < priority))
		{
			mLastPriority = priority;
			UISprite uISprite = icoProgressBG;
			icoProgressFG.spriteName = spriteName;
			uISprite.spriteName = spriteName;
			icoProgressFG.fillAmount = 1f;
		}
		if (mLastPriority == priority)
		{
			icoPrigressObject.SetActive(show);
		}
	}

	public void UpdateIcoProgress(string spriteName, int priority, float fract)
	{
		if (!icoPrigressObject.activeSelf || mLastPriority < priority)
		{
			mLastPriority = priority;
			UISprite uISprite = icoProgressBG;
			icoProgressFG.spriteName = spriteName;
			uISprite.spriteName = spriteName;
			icoPrigressObject.SetActive(value: true);
		}
		if (mLastPriority == priority)
		{
			icoProgressFG.fillAmount = fract;
		}
	}

	private void UnSelect()
	{
		pricelabel.color = Color.white;
		pricelabel.transform.localScale = new Vector3(50f, 50f, 1f);
		TweenAlpha.Begin(icon.gameObject, 0f, 1f).style = UITweener.Style.Once;
		reloadingLabel.gameObject.SetActive(value: false);
		selectedBorder.gameObject.SetActive(value: false);
		bottomBg.color = Color.black.ReplaceA(0.3f);
		topBracket.color = Color.white.ReplaceA(0.5f);
	}

	private void Select()
	{
		reloadingLabel.gameObject.SetActive(value: false);
		pricelabel.transform.localScale = new Vector3(50f, 50f, 1f);
		reloadingLabel.gameObject.SetActive(value: true);
		TweenAlpha.Begin(reloadingLabel.gameObject, 0f, 0f, 0f);
		if (icon.gameObject.activeSelf)
		{
			selectedBorder.gameObject.SetActive(value: true);
			pricelabel.color = Color.black;
			bottomBg.color = progressSprite.color;
			topBracket.color = Color.white;
		}
		mIsLowAmmo = false;
	}

	public void SetShowed(bool showed)
	{
		icon.gameObject.SetActive(showed);
		pricelabel.gameObject.SetActive(showed);
		if (!showed)
		{
			bottomBg.color = Color.black.ReplaceA(0.3f);
			selectedBorder.gameObject.SetActive(value: false);
		}
		outOfAmmo.SetActive(value: false);
	}

	public void SetEnabled(bool isEnabled)
	{
		UnSelect();
		pricelabel.gameObject.SetActive(isEnabled);
		if (!isEnabled)
		{
			TweenAlpha.Begin(icon.gameObject, 0f, 0.5f).style = UITweener.Style.Once;
		}
	}

	public PlayerWeapon GetPlayerWeapon()
	{
		return mWeapon;
	}
}
