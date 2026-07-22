using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BMBigSlotRecord : Core_BaseScript
{
	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private bool mIsSubscriptionOnly;

	[SerializeField]
	private GameObject mSubscriptionOverlay;

	[SerializeField]
	private GameObject mSubscriptionBanner;

	[SerializeField]
	private BoxCollider mSubscriptionButton;

	[SerializeField]
	private List<GameObject> mSubscriptionParts;

	[SerializeField]
	private List<UITexture> mGlows;

	[SerializeField]
	private UISprite mSlotIcon;

	[SerializeField]
	private UILabel mSlotName;

	[SerializeField]
	private GameObject mSalePart;

	[SerializeField]
	private UILabel mSaleLabel;

	[SerializeField]
	private GameObject mWeaponPart;

	[SerializeField]
	private UITexture mWeaponTexture;

	[SerializeField]
	private UILabel mWeaponName;

	[SerializeField]
	private UISprite mWeaponBuffIcon;

	[SerializeField]
	private UILabel mWeaponBuffName;

	[SerializeField]
	private GameObject mUnitPart;

	[SerializeField]
	private UISprite mUnitIcon;

	[SerializeField]
	private GameObject mEarlyUnlockBanner;

	[SerializeField]
	private GameObject mEliteBanner;

	[SerializeField]
	private UILabel mUnitName;

	[SerializeField]
	private UILabel mTierLabel;

	[SerializeField]
	private List<UISprite> mTierStars;

	[SerializeField]
	private BoxCollider mDetailsCollider;

	[SerializeField]
	private UILabel mUnitLevel;

	[SerializeField]
	private UILabel mUnitPower;

	[SerializeField]
	private UISprite mSpecialIcon;

	[SerializeField]
	private UISprite mEliteIcon;

	[SerializeField]
	private UISprite mEliteBuffIcon;

	[SerializeField]
	private GameObject mRestockWaiting;

	[SerializeField]
	private UIPanel mUnitHintIconPanel;

	[SerializeField]
	private UISprite mUnitHintIcon;

	[SerializeField]
	private UIPanel mUnitHintPanel;

	[SerializeField]
	private GameObject mUnitHintMoving;

	[SerializeField]
	private GameObject mAbilityLockedPart;

	[SerializeField]
	private GameObject mAbilityUnlockedPart;

	[SerializeField]
	private List<UISprite> mHintTierStars;

	[SerializeField]
	private UILabel mAttackValue;

	[SerializeField]
	private UILabel mAttackMaxValue;

	[SerializeField]
	private UILabel mHealthValue;

	[SerializeField]
	private UILabel mHealthMaxValue;

	[SerializeField]
	private UILabel mAbilityTitle;

	[SerializeField]
	private UILabel mAbilityDescription;

	[SerializeField]
	private UISprite mAbilityHintIcon;

	[SerializeField]
	private UILabel mEliteTitle;

	[SerializeField]
	private UILabel mEliteDescription;

	[SerializeField]
	private UISprite mEliteHintIcon;

	[SerializeField]
	private UISprite mEliteBuffHintIcon;

	[SerializeField]
	private GameObject mEliteLockedPart;

	[SerializeField]
	private GameObject mEliteUnlockedPart;

	[SerializeField]
	private UILabel mEliteLockedLabel;

	[SerializeField]
	private UILabel mAbilityLockedLabel;

	[SerializeField]
	private List<UISprite> mAbilityHintLockedTierStars;

	[SerializeField]
	private UIPanel mHintIconPanel;

	[SerializeField]
	private UISprite mHintIcon;

	[SerializeField]
	private UIPanel mHintPanel;

	[SerializeField]
	private GameObject mHintMoving;

	[SerializeField]
	private UILabel mHintWeaponName;

	[SerializeField]
	private UISprite mHintWeaponBuffIcon;

	[SerializeField]
	private UILabel mHintWeaponBuffName;

	[SerializeField]
	private UILabel mHintWeaponBuffDescription;

	[SerializeField]
	private UILabel mHintWeaponStatisticName;

	[SerializeField]
	private UILabel mHintWeaponStatisticIncrease;

	[SerializeField]
	private UILabel mHintWeaponStatisticValue;

	[SerializeField]
	private List<BlackmarketWeaponStatisticGUI> mHintProgressBarsLeft;

	[SerializeField]
	private UISprite mHintBackground;

	[SerializeField]
	private UILabel mHintForDuplicatesLabel;

	[SerializeField]
	private UITable mPowerTable;

	[SerializeField]
	private UILabel mWeaponIncreasePower;

	[SerializeField]
	private UILabel mWeaponCurrentPower;

	[SerializeField]
	private UILabel mWeaponMaxPower;

	[SerializeField]
	private UILabel mWeaponLevel;

	[SerializeField]
	private UILabel mWeaponGrade;

	[SerializeField]
	private BoxCollider mBottomButton;

	[SerializeField]
	private UITable mPriceTable;

	[SerializeField]
	private UISprite mCurrencyIcon;

	[SerializeField]
	private UILabel mPriceLabel;

	[SerializeField]
	private GameObject mBottomButtonAcquired;

	[SerializeField]
	private UIAtlas mMenuMainAtlas;

	[SerializeField]
	private UIAtlas mCommonIconsAtlas;

	[SerializeField]
	private UIAtlas mCommonAtlas;

	private BlackMarketStoreManager.BMSlotData HMHDHCMIGHA;

	private WeaponLevelsSetup CGEPFKGPOKE;

	private LevelBehaviour LFJCEHJFPDD;

	private int NKNKBNJNAHN;

	private bool ILGFMFDPKHC;

	private bool PJODGKEGBPE;

	private float JFANCHGCCFK;

	public void InitControls()
	{
	}

	private void PPIBEFOKDJK(GameObject LJFDGDIAGIN)
	{
	}

	private void JHPOKNEPICN(GameObject LJFDGDIAGIN)
	{
	}

	private void BLKJNAELDBL(GameObject LJFDGDIAGIN)
	{
	}

	private void HMDIMCNCLAD(GameObject LJFDGDIAGIN)
	{
	}

	private bool JNIDNIEMAEM(OPGPFDFGCKE GHNHJOIBEIE, long CKFPFCJDBJK)
	{
		return false;
	}

	public void InitGUIValues(LevelBehaviour NGEDOMFLLKI, BlackMarketStoreManager.BMSlotData FDCOJJJHNME, int PKELBCEPGLI)
	{
	}

	public void InitGUIValues(WeaponLevelsSetup AEBEOCBIBFI, BlackMarketStoreManager.BMSlotData FDCOJJJHNME, int PKELBCEPGLI)
	{
	}

	private void NJOLPPOHOKD()
	{
	}

	private void AKHOOEFDDND()
	{
	}

	private void NILJOKPCPKE(Color PJMFHLBNMEO)
	{
	}

	private void JDFMLBBBHDE(string HEEIBFCEOLC, bool KEFEDLPCFAL)
	{
	}

	private void CAGLKGCEIPP(int LNOKLLPABOP)
	{
	}

	private void HDDJJLBNHJK()
	{
	}

	private void FAANBIEMHBA()
	{
	}

	private void KPAEGLDBLKN(GameObject LJFDGDIAGIN)
	{
	}

	private void GDBNBAJFHAC()
	{
	}

	public void DoAfterHide()
	{
	}

	private void FOIOCLOHMHM()
	{
	}

	private void NNPMMMDLCPF(string HFJKJDPBHDM, string BNMDKCKFNGO, UISprite BHEADGAMNNF, UILabel AIEDFPCAJJB, float GMGBFAPEGDM, bool FDBDNCAGAEL)
	{
	}

	private void JDPHHFNOHGI(WeaponLevelsSetup AEBEOCBIBFI, WeaponLevelsSetup EDPGHCCNCFL, WeaponFeature DEMDAHLOPED)
	{
	}

	private void NGKCKCFILEJ(Texture2D GDFNLIOGOKH)
	{
	}

	private void AHJKJBKENDM()
	{
	}

	private void CKCPJCAFHOI()
	{
	}

	public void InitializeRestockProtection()
	{
	}

	[CompilerGenerated]
	private void PDJPBBCGFIJ()
	{
	}

	[CompilerGenerated]
	private void KGIJEJAFHBL(UITweener APDCEKJJGCO)
	{
	}

	[CompilerGenerated]
	private void BHABNPELBJB(bool NPBNDDENDOD)
	{
	}

	[CompilerGenerated]
	private void MOCDKLPHMGG(bool NPBNDDENDOD)
	{
	}
}
