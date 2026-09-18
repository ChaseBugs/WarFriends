using System;
using System.Collections;
using UnityEngine;

public class BattlePreparationWeaponButton : Core_BaseScript
{
	[Header("Core")]
	public GameObject weaponButton;

	public UISprite weaponIcon;

	[Header("-Sale Part")]
	public GameObject weaponSalePart;

	public UILabel weaponSalePercent;

	public UISprite weaponSaleTimeBackground;

	public WinStreakCounter weaponSaleTimeCounter;

	[Header("-New Unlock")]
	public GameObject unlockedWeaponPart;

	public UITable unlockedWeaponTable;

	public UILabel unlockedWeaponNewLabel;

	public UISprite unlockedWeaponNewBackground;

	public UILabel unlockedWeapon;

	[Header("-Delivering Part")]
	public GameObject deliveringWeaponPart;

	public UISprite progressWeapon;

	public UILabel progressWeaponLabel;

	[Header("-Notification")]
	public UILabel notificationWeaponNumber;

	public GameObject notificationWeaponGO;

	private RadicalRoutine mUpdatingWeapon;

	private int mLastRemainingTimeWeapon;

	private WeaponLevelsSetup mWeapon;

	private bool mAssaultsBuyable;

	private bool mAssaultsUpgradeable;

	private bool mSMGsBuyable;

	private bool mSMGsUpgradeable;

	private bool mLMGsBuyable;

	private bool mLMGsUpgradeable;

	private bool mMinigunsUpgradeable;

	private bool mSnipersBuyable;

	private bool mSnipersUpgradeable;

	private bool mShotgunsBuyable;

	private bool mShotgunsUpgradeable;

	private bool mGrenadesBuyable;

	private bool mGrenadesUpgradeable;

	private bool mRocketsBuyable;

	private bool mRocketsUpgradeable;

	private bool mGrenadeLauncherBuyable;

	private bool mGrenadeLauncherUpgradeable;

	private bool mPistolsBuyable;

	private bool mPistolsUpgradeable;

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(weaponButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
		});
		unlockedWeaponTable.onReposition = delegate
		{
			float val = 0f - unlockedWeaponTable.padding.x - (unlockedWeapon.transform.parent.localPosition.x - unlockedWeaponTable.padding.x) / 2f;
			unlockedWeaponTable.transform.localPosition = unlockedWeaponTable.transform.localPosition.ReplaceX(val);
		};
	}

	public void InitGUIValues()
	{
		SetWeaponButton();
		NotificationWeapon(Singleton<NotificationManager>.instance.GetNumberOfWeaponNotifications());
	}

	public void DoAfterHide()
	{
		StopWeaponUpdate();
	}

	public void SaleWeapons()
	{
		int num = Singleton<OfferManager>.instance.DiscountedWeaponOfferBuy();
		int num2 = Singleton<OfferManager>.instance.DiscountedWeaponOfferUpgrade();
		WeaponLevelsSetup weaponLevelsSetup = Singleton<OfferManager>.instance.DiscountedWeaponOffer();
		int num3 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle, OfferBuyType.Buy);
		int num4 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.AssaultRifle, OfferBuyType.Upgrade);
		int num5 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG, OfferBuyType.Buy);
		int num6 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SMG, OfferBuyType.Upgrade);
		int num7 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.LMG, OfferBuyType.Buy);
		int num8 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.LMG, OfferBuyType.Upgrade);
		int num9 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Minigun, OfferBuyType.Upgrade);
		int num10 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SniperRifle, OfferBuyType.Buy);
		int num11 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.SniperRifle, OfferBuyType.Upgrade);
		int num12 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Shotgun, OfferBuyType.Buy);
		int num13 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Shotgun, OfferBuyType.Upgrade);
		int num14 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Grenade, OfferBuyType.Buy);
		int num15 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Grenade, OfferBuyType.Upgrade);
		int num16 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.RocketLauncher, OfferBuyType.Buy);
		int num17 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.RocketLauncher, OfferBuyType.Upgrade);
		int num18 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.GrenadeLauncher, OfferBuyType.Buy);
		int num19 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.GrenadeLauncher, OfferBuyType.Upgrade);
		int num20 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Pistol, OfferBuyType.Buy);
		int num21 = Singleton<OfferManager>.instance.DiscountedWeaponCategory(WeaponCategory.Pistol, OfferBuyType.Upgrade);
		int num22 = Mathf.Min(num3, num5, num7);
		int num23 = Mathf.Min(num4, num6, num8);
		int num24 = Mathf.Min(num10, num12);
		int num25 = Mathf.Min(num9, num11, num13);
		int num26 = Mathf.Min(num14, num16, num18);
		int num27 = Mathf.Min(num15, num17, num19);
		bool flag = num > 0 && weaponLevelsSetup != null && weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
		bool flag2 = num2 > 0 && weaponLevelsSetup != null && weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
		CheckBuyableAndUpgradeable();
		bool flag3 = num3 > 0 && mAssaultsBuyable;
		bool flag4 = num4 > 0 && mAssaultsUpgradeable;
		bool flag5 = num5 > 0 && mSMGsBuyable;
		bool flag6 = num6 > 0 && mSMGsUpgradeable;
		bool flag7 = num7 > 0 && mLMGsBuyable;
		bool flag8 = num8 > 0 && mLMGsUpgradeable;
		bool flag9 = num9 > 0 && mMinigunsUpgradeable;
		bool flag10 = num10 > 0 && mSnipersBuyable;
		bool flag11 = num11 > 0 && mSnipersUpgradeable;
		bool flag12 = num12 > 0 && mShotgunsBuyable;
		bool flag13 = num13 > 0 && mShotgunsUpgradeable;
		bool flag14 = num14 > 0 && mGrenadesBuyable;
		bool flag15 = num15 > 0 && mGrenadesUpgradeable;
		bool flag16 = num16 > 0 && mRocketsBuyable;
		bool flag17 = num17 > 0 && mRocketsUpgradeable;
		bool flag18 = num18 > 0 && mGrenadeLauncherBuyable;
		bool flag19 = num19 > 0 && mGrenadeLauncherUpgradeable;
		bool flag20 = num20 > 0 && mPistolsBuyable;
		bool flag21 = num21 > 0 && mPistolsUpgradeable;
		bool flag22 = num22 > 0 && (mAssaultsBuyable || mSMGsBuyable || mLMGsBuyable);
		bool flag23 = num23 > 0 && (mAssaultsUpgradeable || mSMGsUpgradeable || mLMGsUpgradeable);
		bool flag24 = num24 > 0 && (mSnipersBuyable || mShotgunsBuyable);
		bool flag25 = num25 > 0 && (mMinigunsUpgradeable || mSnipersUpgradeable || mShotgunsUpgradeable);
		bool flag26 = num26 > 0 && (mGrenadesBuyable || mRocketsBuyable || mGrenadeLauncherBuyable);
		bool flag27 = num27 > 0 && (mGrenadesUpgradeable || mRocketsUpgradeable || mGrenadeLauncherUpgradeable);
		bool flag28 = num3 > 0 && num5 > 0 && num7 > 0 && num10 > 0 && num12 > 0 && num14 > 0 && num16 > 0 && num18 > 0 && num20 > 0;
		bool flag29 = num4 > 0 && num6 > 0 && num8 > 0 && num9 > 0 && num11 > 0 && num13 > 0 && num15 > 0 && num17 > 0 && num19 > 0 && num21 > 0;
		bool flag30 = flag28 && (mAssaultsBuyable || mSMGsBuyable || mLMGsBuyable || mSnipersBuyable || mShotgunsBuyable || mGrenadesBuyable || mRocketsBuyable || mGrenadeLauncherBuyable || mPistolsBuyable);
		bool flag31 = flag29 && (mAssaultsUpgradeable || mSMGsUpgradeable || mLMGsUpgradeable || mMinigunsUpgradeable || mSnipersUpgradeable || mShotgunsUpgradeable || mGrenadesUpgradeable || mRocketsUpgradeable || mGrenadeLauncherUpgradeable || mPistolsUpgradeable);
		bool flag32 = !flag30 && (flag3 || flag5 || flag7 || flag10 || flag12 || flag14 || flag16 || flag18 || flag20);
		bool flag33 = !flag31 && (flag4 || flag6 || flag8 || flag9 || flag11 || flag13 || flag15 || flag17 || flag19 || flag21);
		weaponSalePart.SetActive(flag || flag2 || flag30 || flag31 || flag32 || flag33);
		if (flag30 || flag31)
		{
			weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag30) ? num23 : num22);
			weaponSaleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedWeaponFlatEndtime(), upperCaseCountdown: true);
			WinStreakCounter winStreakCounter = weaponSaleTimeCounter;
			winStreakCounter.winStreakTimer = (Action)Delegate.Remove(winStreakCounter.winStreakTimer, new Action(SaleWeapons));
			WinStreakCounter winStreakCounter2 = weaponSaleTimeCounter;
			winStreakCounter2.winStreakTimer = (Action)Delegate.Combine(winStreakCounter2.winStreakTimer, new Action(SaleWeapons));
			weaponSaleTimeBackground.transform.localScale = weaponSaleTimeBackground.transform.localScale.ReplaceX(130f);
		}
		else if (flag32 || flag33)
		{
			weaponSaleTimeCounter.StopCountingTo();
			WinStreakCounter winStreakCounter3 = weaponSaleTimeCounter;
			winStreakCounter3.winStreakTimer = (Action)Delegate.Remove(winStreakCounter3.winStreakTimer, new Action(SaleWeapons));
			if (flag22 || flag23)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag22) ? num23 : num22);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.Primary, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag24 || flag25)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag24) ? num25 : num24);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.Special, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag26 || flag27)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag26) ? num27 : num26);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.Explosive, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag3 || flag4)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag3) ? num4 : num3);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.AssaultRifle, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag5 || flag6)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag5) ? num6 : num5);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.SMG, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag7 || flag8)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag7) ? num8 : num7);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.LMG, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag9)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num9);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.Minigun, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag10 || flag11)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag10) ? num11 : num10);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.SniperRifle, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag12 || flag13)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag12) ? num13 : num12);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.Shotgun, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag14 || flag15)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag14) ? num15 : num14);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.Grenade, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag16 || flag17)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag16) ? num17 : num16);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.RocketLauncher, StringCase.UpperCase, StringCount.Plural));
			}
			else if (flag18 || flag19)
			{
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag18) ? num19 : num18);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.GrenadeLauncher, StringCase.UpperCase, StringCount.Plural));
			}
			else
			{
				if (!flag20 && !flag21)
				{
					weaponSalePercent.text = string.Empty;
					weaponSaleTimeCounter.counterLabel.text = string.Empty;
					weaponSaleTimeBackground.transform.localScale = weaponSaleTimeBackground.transform.localScale.ReplaceX(130f);
					return;
				}
				weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag20) ? num21 : num20);
				weaponSaleTimeCounter.counterLabel.text = Localization.Localize(Singleton<GameVariables>.instance.GetWeaponCategoryId(WeaponCategory.Pistol, StringCase.UpperCase, StringCount.Plural));
			}
			float num28 = weaponSaleTimeCounter.counterLabel.relativeSize.x * weaponSaleTimeCounter.counterLabel.transform.localScale.x;
			weaponSaleTimeBackground.transform.localScale = weaponSaleTimeBackground.transform.localScale.ReplaceX(num28 + 40f);
		}
		else if (flag || flag2)
		{
			weaponSalePercent.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", (!flag) ? num2 : num);
			weaponSaleTimeCounter.StartCountingTo(Singleton<OfferManager>.instance.DiscountedWeaponOfferEndtime(), upperCaseCountdown: true);
			WinStreakCounter winStreakCounter4 = weaponSaleTimeCounter;
			winStreakCounter4.winStreakTimer = (Action)Delegate.Remove(winStreakCounter4.winStreakTimer, new Action(SaleWeapons));
			WinStreakCounter winStreakCounter5 = weaponSaleTimeCounter;
			winStreakCounter5.winStreakTimer = (Action)Delegate.Combine(winStreakCounter5.winStreakTimer, new Action(SaleWeapons));
			weaponSaleTimeBackground.transform.localScale = weaponSaleTimeBackground.transform.localScale.ReplaceX(130f);
		}
		else
		{
			weaponSaleTimeCounter.StopCountingTo();
			WinStreakCounter winStreakCounter6 = weaponSaleTimeCounter;
			winStreakCounter6.winStreakTimer = (Action)Delegate.Remove(winStreakCounter6.winStreakTimer, new Action(SaleWeapons));
			weaponSaleTimeBackground.transform.localScale = weaponSaleTimeBackground.transform.localScale.ReplaceX(130f);
		}
	}

	private void CheckBuyableAndUpgradeable()
	{
		mAssaultsBuyable = false;
		mAssaultsUpgradeable = false;
		mSMGsBuyable = false;
		mSMGsUpgradeable = false;
		mLMGsBuyable = false;
		mLMGsUpgradeable = false;
		mMinigunsUpgradeable = false;
		mSnipersBuyable = false;
		mSnipersUpgradeable = false;
		mShotgunsBuyable = false;
		mShotgunsUpgradeable = false;
		mGrenadesBuyable = false;
		mGrenadesUpgradeable = false;
		mRocketsBuyable = false;
		mRocketsUpgradeable = false;
		mGrenadeLauncherBuyable = false;
		mGrenadeLauncherUpgradeable = false;
		mPistolsBuyable = false;
		mPistolsUpgradeable = false;
		foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
		{
			switch (weaponLevelsSetup.weaponCategory)
			{
			case WeaponCategory.AssaultRifle:
				mAssaultsBuyable |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
				mAssaultsUpgradeable |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SMG:
				mSMGsBuyable |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
				mSMGsUpgradeable |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.LMG:
				mLMGsBuyable |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
				mLMGsUpgradeable |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Minigun:
				mMinigunsUpgradeable |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.SniperRifle:
				mSnipersBuyable |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
				mSnipersUpgradeable |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Shotgun:
				mShotgunsBuyable |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
				mShotgunsUpgradeable |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Grenade:
				mGrenadesBuyable |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
				mGrenadesUpgradeable |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.RocketLauncher:
				mRocketsBuyable |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
				mRocketsUpgradeable |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.GrenadeLauncher:
				mGrenadeLauncherBuyable |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
				mGrenadeLauncherUpgradeable |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			case WeaponCategory.Pistol:
				mPistolsBuyable |= weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.NotBuyed;
				mPistolsUpgradeable |= weaponLevelsSetup.bought && weaponLevelsSetup.canBeUpgraded;
				break;
			}
		}
	}

	public void InitBlank()
	{
		unlockedWeaponPart.SetActive(value: false);
		deliveringWeaponPart.SetActive(value: false);
		NotificationWeapon(0);
	}

	private void StartWeaponUpdate()
	{
		StopWeaponUpdate();
		mUpdatingWeapon = RadicalRoutine.Create(UpdateWeaponRoutine());
		StartCoroutine(RadicalRoutine.Run(mUpdatingWeapon.enumerator));
	}

	private void StopWeaponUpdate()
	{
		if (mUpdatingWeapon != null)
		{
			mUpdatingWeapon.Cancel();
			mUpdatingWeapon = null;
		}
	}

	private IEnumerator UpdateWeaponRoutine()
	{
		while (mWeapon.remainingDeliveringSeconds > 0.0)
		{
			progressWeapon.fillAmount = mWeapon.progressDelivering;
			progressWeapon.color = Colours.cyan;
			SetUpDeliveringWeaponLabel((int)mWeapon.remainingDeliveringSeconds);
			yield return new WaitForRealSeconds(0.333f);
		}
		progressWeapon.fillAmount = 1f;
		progressWeapon.color = Colours.blue;
		progressWeaponLabel.text = Localization.Localize((mWeapon.weaponState != WeaponLevelsSetup.State.WeaponDelivered) ? "ID_UPGRADED" : "ID_PURCHASED");
		progressWeaponLabel.alpha = 1f;
		TweenAlpha.Begin(progressWeaponLabel.gameObject, 0.01f, 1f);
		NotificationWeapon(Singleton<NotificationManager>.instance.GetNumberOfWeaponNotifications());
	}

	private void SetUpDeliveringWeaponLabel(int remainingTime, bool instant = false)
	{
		if (mLastRemainingTimeWeapon > remainingTime)
		{
			mLastRemainingTimeWeapon = remainingTime;
			GuiScreenSingle<BattlePreparationScreen>.instance.SetUpDeliveringLabel(remainingTime, ref progressWeaponLabel, instant);
		}
	}

	private void NotificationWeapon(int number)
	{
		notificationWeaponGO.SetActive(number > 0);
		notificationWeaponNumber.text = MiscTools.FormatBigNumber(number);
	}

	public void SetUpWeaponLook(string weaponSprite)
	{
		weaponIcon.spriteName = weaponSprite;
		weaponIcon.MakePixelPerfect();
		weaponIcon.transform.localScale = weaponIcon.transform.localScale.MultiplyXY(1.4117649f);
	}

	private void SetWeaponButton()
	{
		StopWeaponUpdate();
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			unlockedWeaponPart.SetActive(value: false);
			deliveringWeaponPart.SetActive(value: true);
			SetUpWeaponLook(weaponLevelsSetup.playerWeapon.iconName);
			if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.Delivered || weaponLevelsSetup.weaponState == WeaponLevelsSetup.State.WeaponDelivered)
			{
				mLastRemainingTimeWeapon = 0;
				progressWeapon.fillAmount = 1f;
				progressWeapon.color = Colours.blue;
				progressWeaponLabel.text = Localization.Localize((weaponLevelsSetup.weaponState != WeaponLevelsSetup.State.WeaponDelivered) ? "ID_UPGRADED" : "ID_PURCHASED");
				progressWeaponLabel.alpha = 1f;
				TweenAlpha.Begin(progressWeaponLabel.gameObject, 0.01f, 1f);
			}
			else
			{
				mLastRemainingTimeWeapon = int.MaxValue;
				progressWeapon.fillAmount = weaponLevelsSetup.progressDelivering;
				progressWeapon.color = Colours.cyan;
				SetUpDeliveringWeaponLabel((int)weaponLevelsSetup.remainingDeliveringSeconds, instant: true);
				mWeapon = weaponLevelsSetup;
				StartWeaponUpdate();
			}
		}
		else
		{
			weaponLevelsSetup = Singleton<NotificationManager>.instance.GetUnlockedWeaponWithNotification();
			if (weaponLevelsSetup != null)
			{
				unlockedWeaponPart.SetActive(value: true);
				deliveringWeaponPart.SetActive(value: false);
				SetUpWeaponLook(weaponLevelsSetup.playerWeapon.iconName);
				unlockedWeapon.text = weaponLevelsSetup.weaponName.ToUpperInvariant();
				MiscTools.SetUILabelRescale(unlockedWeapon, 30f, 20f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 88);
				float val = 16f + unlockedWeaponNewLabel.relativeSize.x * unlockedWeaponNewLabel.transform.localScale.x;
				unlockedWeaponNewBackground.transform.localScale = unlockedWeaponNewBackground.transform.localScale.ReplaceX(val);
				unlockedWeaponTable.repositionNow = true;
			}
			else
			{
				weaponLevelsSetup = PlayerInventory.instance.inventorySlots[0].weaponLevelsSetup;
				unlockedWeaponPart.SetActive(value: false);
				deliveringWeaponPart.SetActive(value: false);
				SetUpWeaponLook(weaponLevelsSetup.playerWeapon.iconName);
			}
		}
	}
}
