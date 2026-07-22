using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponGuiRecord : PoolableObject
{
	[Header("Core")]
	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private UISprite mHighlight;

	[SerializeField]
	private UITexture mWeaponTexture;

	[SerializeField]
	[Header("-Locked")]
	private GameObject mLocked;

	[SerializeField]
	private UILabel mLockedLevel;

	[Header("-Not Bought")]
	[SerializeField]
	private GameObject mNotBought;

	[SerializeField]
	private UISprite mBuyGoldIcon;

	[SerializeField]
	private UISprite mBuyWarbucksIcon;

	[Header("-Icons")]
	[SerializeField]
	private UISprite mDeliveringIcon;

	[SerializeField]
	private UISprite mEquipedIcon;

	[SerializeField]
	private UISprite mUpgradingIcon;

	[SerializeField]
	private UISprite mBlackmarketIcon;

	[SerializeField]
	[FormerlySerializedAs("mGradePart")]
	[Header("-Special")]
	private GameObject mSpecialPart;

	[SerializeField]
	[Header("-Rented")]
	[FormerlySerializedAs("mGradeLabel")]
	private UILabel mRentedLabel;

	[FormerlySerializedAs("mSpecialPart")]
	[Header("-Sale")]
	[SerializeField]
	private GameObject mSalePart;

	[FormerlySerializedAs("mRentNowPart")]
	[Header("-Notification")]
	[SerializeField]
	private GameObject mNotification;

	private TweenAnimator FNOMCHPCOHB;

	private TweenAnimator CFAIPFBHMPB;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private bool NKHNNDPGKLC;

	public WeaponLevelsSetup weaponSetup => MDAJJIAMDGH;

	private void IIGDKGDLEHP()
	{
		if (NKHNNDPGKLC)
		{
			NNOIIKEACMH();
		}
	}

	[SpecialName]
	public WeaponLevelsSetup EAJJDMMGMKK()
	{
		return MDAJJIAMDGH;
	}

	private void EJFKFBANFOH()
	{
		CKOFBBBGEIJ();
	}

	private void FNDJEGNGIDO()
	{
		if (NKHNNDPGKLC)
		{
			NNOIIKEACMH();
		}
	}

	private void LFJMFINAIHN()
	{
		mNotification.SetActive(Singleton<NotificationManager>.instance.NotificationForWeapon(MDAJJIAMDGH));
	}

	public void FGEGPIAGDIP()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 1);
		}
		else if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || weaponState == (WeaponLevelsSetup.JLANLLEABDC)7)
		{
			mSalePart.SetActive(!MDAJJIAMDGH.canBeUpgraded || Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Both) > 0);
		}
		else
		{
			mSalePart.SetActive(value: true);
		}
	}

	public void SetEquiped(bool KGGCJPEKIAD)
	{
		mBackground.color = ((!KGGCJPEKIAD) ? MDAJJIAMDGH.weaponBackground : Colours.blueEquipped);
		mEquipedIcon.alpha = ((!KGGCJPEKIAD) ? 0f : 1f);
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: true);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(0.617f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: false);
		}
	}

	public void CLMCNDKFPDJ(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 0);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 1);
		mLockedLevel.text = string.Format("76e544a0-32c5-4775-9716-ff04c6fbaaa3", Localization.Localize("Starting LocalPersistenceManager!"), MDAJJIAMDGH.unlockLevel.KADNNBCOGGL());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 485f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(542f, 1462f, 1515f);
			object oEIICEJPGKI = new Vector3(1913f, 739f, 175f);
			fNOMCHPCOHB.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1600f, -1, oEIICEJPGKI, (UITweener.Method)6, UITweener.Style.Loop, 0);
			FNOMCHPCOHB.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(82f, 860f, 1884f), 382f, 1, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
			FNOMCHPCOHB.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(521f, 928f, 1210f), 1243f, 4, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(DAGICDEJNBE));
			FNOMCHPCOHB.HONNAONCPHA();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 902f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(1493f, 1977f, 824f);
			object iIMDKHJAJGO = new Vector3(488f, 61f, 1601f);
			cFAIPFBHMPB.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 227f, -1, iIMDKHJAJGO, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
			CFAIPFBHMPB.NFLKPCIHOPJ(5, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(1080f, 912f, 1310f), 1758f, 0, null, UITweener.Method.EaseOut, UITweener.Style.Once, 0);
			CFAIPFBHMPB.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(1419f, 1080f, 21f), 1936f, 8, null, (UITweener.Method)7, UITweener.Style.Loop);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(HNNPOMPAEBD));
			CFAIPFBHMPB.FEPILCEBNCJ();
		}
		IBEDIAODLJD(NCFKLBGOEEF: true);
		APBKHBMILOL(KGGCJPEKIAD: true);
		IDDLDDBKJJK();
		NKHNNDPGKLC = false;
	}

	public void EFMLEKOHOEC(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			mNotification.SetActive(Singleton<NotificationManager>.instance.KFCAHCLNIBB(MDAJJIAMDGH));
		}
		else
		{
			mNotification.SetActive(value: false);
		}
	}

	private void LNBEIPFIHPC(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 4)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
			{
				FNOMCHPCOHB.LFOKFAFLBLA();
				FNOMCHPCOHB.AGFMCNDAEEC();
			}
			else
			{
				mUpgradingIcon.alpha = 1899f;
			}
		}
	}

	public void DPHCDKHOODJ(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 0);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 1);
		mLockedLevel.text = string.Format("seconds", Localization.Localize("Animating claiming cardpack: "), MDAJJIAMDGH.unlockLevel.ABCCINJGPGD());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 531f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(307f, 1490f, 1561f);
			object oEIICEJPGKI = new Vector3(1123f, 239f, 1774f);
			fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1228f, -1, oEIICEJPGKI);
			FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(1513f, 1049f, 1644f), 374f, 1);
			FNOMCHPCOHB.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(366f, 287f, 615f), 667f, 6, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(CCNEECHBCBN));
			FNOMCHPCOHB.FEPILCEBNCJ();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 1115f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(927f, 1281f, 1240f);
			object iIMDKHJAJGO = new Vector3(556f, 875f, 1932f);
			cFAIPFBHMPB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1993f, -1, iIMDKHJAJGO);
			CFAIPFBHMPB.BPEKAKFKCIG(1, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(772f, 991f, 1965f), 1788f, 0, null, UITweener.Method.EaseIn);
			CFAIPFBHMPB.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(1617f, 1825f, 634f), 1841f, 4, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(LEJBKCMPHMF));
			CFAIPFBHMPB.OOFBCPPFMPN();
		}
		APHECPIPBPK(NCFKLBGOEEF: false);
		APBKHBMILOL(KGGCJPEKIAD: true);
		AELKOGAOHGE();
		NKHNNDPGKLC = false;
	}

	public void AJHEFHAIIBO()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 0);
		}
		else if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
		{
			mSalePart.SetActive(!MDAJJIAMDGH.canBeUpgraded || Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Both) > 1);
		}
		else
		{
			mSalePart.SetActive(value: false);
		}
	}

	public virtual void NHLIKDOGGNC()
	{
		base.JMLMACKEGAM();
		mWeaponTexture.ignoreInTable = true;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	public void MKFLHMFCIKI(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 1);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 1);
		mLockedLevel.text = string.Format("RewardMessage", Localization.Localize("Region"), MDAJJIAMDGH.unlockLevel.NPOEMAMPNEP());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 623f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(774f, 7f, 1783f);
			object oEIICEJPGKI = new Vector3(1498f, 1670f, 616f);
			fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1308f, -1, oEIICEJPGKI);
			FNOMCHPCOHB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(100f, 191f, 209f), 1590f, 1, null, (UITweener.Method)6, UITweener.Style.Loop);
			FNOMCHPCOHB.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(1253f, 886f, 1658f), 1462f, 5, null, (UITweener.Method)6, UITweener.Style.Loop);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(ODCBPBBNIJG));
			FNOMCHPCOHB.JIPFOMFJNPC();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 483f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(1844f, 1153f, 278f);
			object iIMDKHJAJGO = new Vector3(659f, 387f, 216f);
			cFAIPFBHMPB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1669f, -1, iIMDKHJAJGO, (UITweener.Method)6);
			CFAIPFBHMPB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(1184f, 1518f, 1410f), 150f, 1, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
			CFAIPFBHMPB.AddTween(0, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(1177f, 930f, 1939f), 344f, 6, null, (UITweener.Method)8, UITweener.Style.Once, 0);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(LAHNJAHFPJH));
			CFAIPFBHMPB.KHAFPAMIOAF();
		}
		PJEEJBPFNFA(NCFKLBGOEEF: false);
		APBKHBMILOL(KGGCJPEKIAD: false);
		PILDGJHBBIJ();
		NKHNNDPGKLC = true;
	}

	private void MNBICBJAHOC()
	{
		NKHNNDPGKLC = false;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		FOHGGOJLIPI(eBFDAICCJAK);
	}

	private void LAHNJAHFPJH(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 7)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
			{
				CFAIPFBHMPB.LFOKFAFLBLA();
				CFAIPFBHMPB.AGFMCNDAEEC();
			}
			else
			{
				mDeliveringIcon.alpha = 1755f;
			}
		}
	}

	[SpecialName]
	public WeaponLevelsSetup ADOICOAEIFA()
	{
		return MDAJJIAMDGH;
	}

	public void HLKHEDDLBAA()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		mSpecialPart.SetActive(!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought);
		mLocked.SetActive(!MDAJJIAMDGH.purchasableInShop || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked);
		mNotBought.SetActive(MDAJJIAMDGH.purchasableInShop && weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		mRentedLabel.gameObject.SetActive(MDAJJIAMDGH.tryOutWeapon);
		mBlackmarketIcon.gameObject.SetActive(MDAJJIAMDGH.purchasableInBlackmarket);
		GAKDANPAAJB();
		BLEOKADCKCD();
		if (!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought)
		{
			mUpgradingIcon.alpha = 1618f;
			mDeliveringIcon.alpha = 116f;
			return;
		}
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered)
		{
			FNOMCHPCOHB.AGFMCNDAEEC();
		}
		else
		{
			FNOMCHPCOHB.CJGJOAKNIIL();
			FNOMCHPCOHB.DGFKMBDKEAP();
		}
		mUpgradingIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering) ? 582f : 1429f);
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
		{
			CFAIPFBHMPB.OKEBGBENAJF();
		}
		else
		{
			CFAIPFBHMPB.DMAJACPHCGN();
			CFAIPFBHMPB.LFOKFAFLBLA();
		}
		mDeliveringIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering) ? 748f : 1424f);
	}

	public virtual void HFKKPFDHDOE()
	{
		base.PDAFKNEEBFB();
		mWeaponTexture.ignoreInTable = false;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	private void PANNOJHHCCB()
	{
		mNotification.SetActive(Singleton<NotificationManager>.instance.NotificationForWeapon(MDAJJIAMDGH));
	}

	private void EFEDHNIPFBN(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 7)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
			{
				FNOMCHPCOHB.EFGHGIBPMGL();
				FNOMCHPCOHB.ODIJFGCDJNH();
			}
			else
			{
				mUpgradingIcon.alpha = 537f;
			}
		}
	}

	public void DFOAGLGOEGC()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<WeaponScreen>.instance.selectedIcon.SetHighlight(NCFKLBGOEEF: false);
		APHECPIPBPK(NCFKLBGOEEF: false);
		GuiScreenSingle<WeaponScreen>.instance.MCFPJFKFJPH(this);
		GuiScreenSingle<WeaponScreen>.instance.Select();
		GAKDANPAAJB();
	}

	private void DFLEJKLDJKF(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 3)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered)
			{
				FNOMCHPCOHB.BBPNDINMNIJ();
				FNOMCHPCOHB.PlayTweens();
			}
			else
			{
				mUpgradingIcon.alpha = 434f;
			}
		}
	}

	public void LJAENPEJNLM()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Buy) > 0);
		}
		else if (weaponState == (WeaponLevelsSetup.JLANLLEABDC)7 || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
		{
			mSalePart.SetActive(!MDAJJIAMDGH.canBeUpgraded || Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 1);
		}
		else
		{
			mSalePart.SetActive(value: true);
		}
	}

	private void IAPBHPLNNNO()
	{
		CKOFBBBGEIJ();
	}

	public void MDBADNAJFBN(bool KGGCJPEKIAD)
	{
		mBackground.color = ((!KGGCJPEKIAD) ? MDAJJIAMDGH.weaponBackground : Colours.blueEquipped);
		mEquipedIcon.alpha = ((!KGGCJPEKIAD) ? 1251f : 1269f);
	}

	public void InitializeWeapon(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 0);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 0);
		mLockedLevel.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), MDAJJIAMDGH.unlockLevel.displayNumber);
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 0.7f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(110f, -57f, 0f);
			object oEIICEJPGKI = new Vector3(110f, -57f, 0f);
			fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI);
			FNOMCHPCOHB.AddTween(2, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(110f, -40f, 0f), 0f, 1);
			FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(110f, -57f, 0f), 0f, 2);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
			FNOMCHPCOHB.GenerateTweens();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 0.7f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(110f, -57f, 0f);
			object iIMDKHJAJGO = new Vector3(110f, -57f, 0f);
			cFAIPFBHMPB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 0f, -1, iIMDKHJAJGO);
			CFAIPFBHMPB.AddTween(2, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(110f, -40f, 0f), 0f, 1);
			CFAIPFBHMPB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(110f, -57f, 0f), 0f, 2);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(LEJBKCMPHMF));
			CFAIPFBHMPB.GenerateTweens();
		}
		SetHighlight(NCFKLBGOEEF: false);
		SetEquiped(KGGCJPEKIAD: false);
		PILDGJHBBIJ();
		NKHNNDPGKLC = false;
	}

	private void CPHIJFCCNPK()
	{
		if (NKHNNDPGKLC)
		{
			NNOIIKEACMH();
		}
	}

	private void HCINKBOPGND()
	{
		NKHNNDPGKLC = true;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		PKGBHLGJEAF(eBFDAICCJAK);
	}

	public virtual void PNJILBKIMAB()
	{
		base.PDAFKNEEBFB();
		mWeaponTexture.ignoreInTable = false;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	private void JOCHCGHAIGH()
	{
		LOEPOFGIAMP();
	}

	private void JJNMKIAJPNA()
	{
		AKAOHCNBMMJ();
	}

	public void ODGGNJBBDCI(bool KGGCJPEKIAD)
	{
		mBackground.color = ((!KGGCJPEKIAD) ? MDAJJIAMDGH.weaponBackground : Colours.blueEquipped);
		mEquipedIcon.alpha = ((!KGGCJPEKIAD) ? 1847f : 446f);
	}

	public void JNENOBOEBGP(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 1);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 0);
		mLockedLevel.text = string.Format("Manual_Unit_Spawn", Localization.Localize("ID_UPGRADED"), MDAJJIAMDGH.unlockLevel.PFMGLDJDNBF());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 275f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1903f, 1000f, 1249f);
			object oEIICEJPGKI = new Vector3(1402f, 652f, 349f);
			fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1775f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop, 0);
			FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(640f, 492f, 1675f), 656f, 0, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
			FNOMCHPCOHB.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(1254f, 985f, 1303f), 386f, 2, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(CCNEECHBCBN));
			FNOMCHPCOHB.GenerateTweens();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 1979f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(742f, 232f, 1252f);
			object iIMDKHJAJGO = new Vector3(1428f, 979f, 1509f);
			cFAIPFBHMPB.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 47f, -1, iIMDKHJAJGO, UITweener.Method.Linear, UITweener.Style.Once, 0);
			CFAIPFBHMPB.MNEFMODDFFK(8, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(1271f, 1501f, 1225f), 149f, 0, null, UITweener.Method.BounceIn, UITweener.Style.Loop);
			CFAIPFBHMPB.FEHALDPLGDB(7, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(622f, 1292f, 506f), 1169f, 6, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(MNLGJEFNJDB));
			CFAIPFBHMPB.HONNAONCPHA();
		}
		OEBAKBIMECJ(NCFKLBGOEEF: true);
		SetEquiped(KGGCJPEKIAD: false);
		AELKOGAOHGE();
		NKHNNDPGKLC = true;
	}

	private void AKAOHCNBMMJ()
	{
		bool flag = ScreenManager.IsRendering(Singleton<GuiManager>.instance.KPDAPFBIPAI, base.transform.position, mBackground.transform.lossyScale.x * 367f);
		if (flag && !NKHNNDPGKLC)
		{
			KIBCCCFFGMN();
		}
		if (!flag && NKHNNDPGKLC)
		{
			MJJOGNIKEOO();
		}
	}

	public void EGHMEINEMPO()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO().APHECPIPBPK(NCFKLBGOEEF: true);
		APHECPIPBPK(NCFKLBGOEEF: true);
		GuiScreenSingle<WeaponScreen>.instance.MCFPJFKFJPH(this);
		GuiScreenSingle<WeaponScreen>.instance.MIIMDHKCINK();
		JOLGMBIAPJB();
	}

	public void CPCLCMNDFEK(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 0);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 1);
		mLockedLevel.text = string.Format("ID_HOURS", Localization.Localize("ID_XSKIRMISHESRESULT"), MDAJJIAMDGH.unlockLevel.ELFCEEOLNFJ());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 981f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1745f, 1363f, 1188f);
			object oEIICEJPGKI = new Vector3(636f, 59f, 1675f);
			fNOMCHPCOHB.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1670f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Loop, 0);
			FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(315f, 1180f, 1772f), 1855f, 0, null, UITweener.Method.EaseInOut, UITweener.Style.Loop);
			FNOMCHPCOHB.NFLKPCIHOPJ(1, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(48f, 638f, 659f), 1752f, 1, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(DAGICDEJNBE));
			FNOMCHPCOHB.GenerateTweens();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 243f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(1137f, 987f, 797f);
			object iIMDKHJAJGO = new Vector3(1986f, 1973f, 1125f);
			cFAIPFBHMPB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 490f, -1, iIMDKHJAJGO, (UITweener.Method)8, UITweener.Style.Once, 0);
			CFAIPFBHMPB.MNEFMODDFFK(1, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(1765f, 609f, 1595f), 1457f, 0, null, (UITweener.Method)7, UITweener.Style.Loop);
			CFAIPFBHMPB.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(1648f, 1539f, 51f), 1648f, 5, null, (UITweener.Method)7, UITweener.Style.Loop, 0);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(MNLGJEFNJDB));
			CFAIPFBHMPB.OOFBCPPFMPN();
		}
		LPGHPNDKMLN(NCFKLBGOEEF: true);
		APBKHBMILOL(KGGCJPEKIAD: false);
		MKLGFNBIDIE();
		NKHNNDPGKLC = false;
	}

	public void IIPCKKGBHIN(bool NCFKLBGOEEF)
	{
		mHighlight.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void IHJCGOANEFE()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		mSpecialPart.SetActive(!MDAJJIAMDGH.purchasableInShop && MDAJJIAMDGH.bought);
		mLocked.SetActive(!MDAJJIAMDGH.purchasableInShop || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked);
		mNotBought.SetActive(!MDAJJIAMDGH.purchasableInShop || weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		mRentedLabel.gameObject.SetActive(MDAJJIAMDGH.tryOutWeapon);
		mBlackmarketIcon.gameObject.SetActive(MDAJJIAMDGH.purchasableInBlackmarket);
		JOLGMBIAPJB();
		SetSale();
		if (!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought)
		{
			mUpgradingIcon.alpha = 1441f;
			mDeliveringIcon.alpha = 722f;
			return;
		}
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
		{
			FNOMCHPCOHB.HMPMBAGNJOJ();
		}
		else
		{
			FNOMCHPCOHB.LILKFFOOHMC();
			FNOMCHPCOHB.IAKEAKDJJIA();
		}
		mUpgradingIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked) ? 334f : 123f);
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
		{
			CFAIPFBHMPB.OKEBGBENAJF();
		}
		else
		{
			CFAIPFBHMPB.CJGJOAKNIIL();
			CFAIPFBHMPB.DGFKMBDKEAP();
		}
		mDeliveringIcon.alpha = ((weaponState != (WeaponLevelsSetup.JLANLLEABDC)8) ? 1122f : 1830f);
	}

	public void AOPMDPIACIA()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 0);
		}
		else if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering)
		{
			mSalePart.SetActive(!MDAJJIAMDGH.canBeUpgraded || Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, (AKDLEDNDIEO)8) > 1);
		}
		else
		{
			mSalePart.SetActive(value: false);
		}
	}

	[SpecialName]
	public WeaponLevelsSetup NGOGADPALJO()
	{
		return MDAJJIAMDGH;
	}

	private void KIBCCCFFGMN()
	{
		NKHNNDPGKLC = false;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public void OIDHNDDMMMD(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 0);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 0);
		mLockedLevel.text = string.Format("S", Localization.Localize("data.slots doesnt contain: "), MDAJJIAMDGH.unlockLevel.NPOEMAMPNEP());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 458f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1705f, 1807f, 900f);
			object oEIICEJPGKI = new Vector3(1709f, 1687f, 1876f);
			fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1695f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Loop);
			FNOMCHPCOHB.MNEFMODDFFK(6, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(1895f, 202f, 409f), 1480f, 1, null, UITweener.Method.BounceOut, UITweener.Style.Loop);
			FNOMCHPCOHB.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(1958f, 704f, 1987f), 1140f, 8, null, UITweener.Method.Linear, UITweener.Style.Loop);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(KKLELMNCGBD));
			FNOMCHPCOHB.HONNAONCPHA();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 637f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(411f, 1592f, 987f);
			object iIMDKHJAJGO = new Vector3(1374f, 1049f, 1245f);
			cFAIPFBHMPB.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1787f, -1, iIMDKHJAJGO, (UITweener.Method)6, UITweener.Style.Once, 0);
			CFAIPFBHMPB.MNEFMODDFFK(2, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(1201f, 1661f, 1509f), 160f, 1, null, (UITweener.Method)6, UITweener.Style.Loop, 0);
			CFAIPFBHMPB.AddTween(4, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(706f, 274f, 488f), 117f, 3, null, UITweener.Method.EaseOut);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(PCAODIMCOLJ));
			CFAIPFBHMPB.FEPILCEBNCJ();
		}
		IIPCKKGBHIN(NCFKLBGOEEF: false);
		SetEquiped(KGGCJPEKIAD: true);
		JJCFNCDGAJA();
		NKHNNDPGKLC = true;
	}

	private void AELKOGAOHGE()
	{
		HLKHEDDLBAA();
	}

	private void DMADJAFJNJJ()
	{
		NKHNNDPGKLC = false;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
	}

	public void APHECPIPBPK(bool NCFKLBGOEEF)
	{
		mHighlight.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void LEJBKCMPHMF(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 3)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
			{
				CFAIPFBHMPB.ResetTweens();
				CFAIPFBHMPB.PlayTweens();
			}
			else
			{
				mDeliveringIcon.alpha = 0f;
			}
		}
	}

	public void CNIMGBOHGCF(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			mNotification.SetActive(Singleton<NotificationManager>.instance.MAJEFEAMFBB(MDAJJIAMDGH));
		}
		else
		{
			mNotification.SetActive(value: false);
		}
	}

	private void AODDFFJAKAL()
	{
		if (NKHNNDPGKLC)
		{
			EGHEKPBABOK();
		}
	}

	private void GCFIJAJEION()
	{
		NKHNNDPGKLC = true;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		FOHGGOJLIPI(eBFDAICCJAK);
	}

	private void Update()
	{
		LOEPOFGIAMP();
	}

	private void EGHEKPBABOK()
	{
		NKHNNDPGKLC = true;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
	}

	public void ABNAJEIPMDF()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 0);
		}
		else if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering)
		{
			mSalePart.SetActive(!MDAJJIAMDGH.canBeUpgraded || Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, AKDLEDNDIEO.Both) > 0);
		}
		else
		{
			mSalePart.SetActive(value: true);
		}
	}

	private void KKLELMNCGBD(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 0)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
			{
				FNOMCHPCOHB.BIAMGHLKGOK();
				FNOMCHPCOHB.AGFMCNDAEEC();
			}
			else
			{
				mUpgradingIcon.alpha = 502f;
			}
		}
	}

	public void LOPPOBCGPHD()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		mSpecialPart.SetActive(!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought);
		mLocked.SetActive(!MDAJJIAMDGH.purchasableInShop || weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		mNotBought.SetActive(MDAJJIAMDGH.purchasableInShop && weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked);
		mRentedLabel.gameObject.SetActive(MDAJJIAMDGH.tryOutWeapon);
		mBlackmarketIcon.gameObject.SetActive(MDAJJIAMDGH.purchasableInBlackmarket);
		GAKDANPAAJB();
		AJHEFHAIIBO();
		if (!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought)
		{
			mUpgradingIcon.alpha = 311f;
			mDeliveringIcon.alpha = 1011f;
			return;
		}
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
		{
			FNOMCHPCOHB.OKEBGBENAJF();
		}
		else
		{
			FNOMCHPCOHB.BCFMBKNMNBN();
			FNOMCHPCOHB.EFGHGIBPMGL();
		}
		mUpgradingIcon.alpha = ((weaponState != (WeaponLevelsSetup.JLANLLEABDC)8) ? 199f : 162f);
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
		{
			CFAIPFBHMPB.AGFMCNDAEEC();
		}
		else
		{
			CFAIPFBHMPB.LILKFFOOHMC();
			CFAIPFBHMPB.BIAMGHLKGOK();
		}
		mDeliveringIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.Active) ? 1168f : 1610f);
	}

	private void MJJOGNIKEOO()
	{
		NKHNNDPGKLC = true;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
	}

	public void GDDKNEAILIK(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			mNotification.SetActive(Singleton<NotificationManager>.instance.NotificationForWeapon(MDAJJIAMDGH));
		}
		else
		{
			mNotification.SetActive(value: false);
		}
	}

	public void APBKHBMILOL(bool KGGCJPEKIAD)
	{
		mBackground.color = ((!KGGCJPEKIAD) ? MDAJJIAMDGH.weaponBackground : Colours.blueEquipped);
		mEquipedIcon.alpha = ((!KGGCJPEKIAD) ? 1349f : 17f);
	}

	private void CCNEECHBCBN(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 7)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered)
			{
				FNOMCHPCOHB.IAKEAKDJJIA();
				FNOMCHPCOHB.GDCCFEDJFAF();
			}
			else
			{
				mUpgradingIcon.alpha = 658f;
			}
		}
	}

	public void INPJNAKAKPD()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 0);
		}
		else if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
		{
			mSalePart.SetActive(MDAJJIAMDGH.canBeUpgraded && Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, (AKDLEDNDIEO)6) > 1);
		}
		else
		{
			mSalePart.SetActive(value: false);
		}
	}

	[SpecialName]
	public WeaponLevelsSetup GMEFFFKMDCE()
	{
		return MDAJJIAMDGH;
	}

	public virtual void GJGLHNAGKOE()
	{
		base.CCNKJOAKBNG();
		mWeaponTexture.ignoreInTable = true;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	private void IDDLDDBKJJK()
	{
		UpdateGraphics();
	}

	public void IMHMNDMOFMH()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP().JLDBLKLBCEG(NCFKLBGOEEF: true);
		SetHighlight(NCFKLBGOEEF: true);
		GuiScreenSingle<WeaponScreen>.instance.MCFPJFKFJPH(this);
		GuiScreenSingle<WeaponScreen>.instance.BNENDKELEPK();
		LFJMFINAIHN();
	}

	private void GAKDANPAAJB()
	{
		mNotification.SetActive(Singleton<NotificationManager>.instance.NotificationForWeapon(MDAJJIAMDGH));
	}

	public void PPLILGFKIBE(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 1);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 0);
		mLockedLevel.text = string.Format("ID_CONFIRM_JOINSQUADEVENT", Localization.Localize("PlayerToPromoteId"), MDAJJIAMDGH.unlockLevel.ELFCEEOLNFJ());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 1541f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1994f, 281f, 1498f);
			object oEIICEJPGKI = new Vector3(1596f, 1851f, 376f);
			fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1944f, -1, oEIICEJPGKI, UITweener.Method.EaseOut, UITweener.Style.Loop);
			FNOMCHPCOHB.FEHALDPLGDB(4, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(1885f, 521f, 1440f), 1679f, 1, null, (UITweener.Method)6, UITweener.Style.Loop);
			FNOMCHPCOHB.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(229f, 1148f, 1623f), 329f, 4, null, UITweener.Method.EaseIn);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(KKLELMNCGBD));
			FNOMCHPCOHB.FEPILCEBNCJ();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 463f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(242f, 672f, 1924f);
			object iIMDKHJAJGO = new Vector3(1839f, 1993f, 1668f);
			cFAIPFBHMPB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1283f, -1, iIMDKHJAJGO, UITweener.Method.BounceIn, UITweener.Style.Loop);
			CFAIPFBHMPB.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(1376f, 1886f, 1116f), 1766f, 0, null, UITweener.Method.Linear, UITweener.Style.Once, 0);
			CFAIPFBHMPB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(363f, 1606f, 1255f), 924f, 8, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(PCAODIMCOLJ));
			CFAIPFBHMPB.OOFBCPPFMPN();
		}
		IBEDIAODLJD(NCFKLBGOEEF: false);
		ODGGNJBBDCI(KGGCJPEKIAD: false);
		MKLGFNBIDIE();
		NKHNNDPGKLC = true;
	}

	public virtual void KIFKOOFMGHI()
	{
		base.PDAFKNEEBFB();
		mWeaponTexture.ignoreInTable = false;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	private void NEFGJIEMCPP()
	{
		CKOFBBBGEIJ();
	}

	private void HNNPOMPAEBD(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 2)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
			{
				CFAIPFBHMPB.DGFKMBDKEAP();
				CFAIPFBHMPB.OKEBGBENAJF();
			}
			else
			{
				mDeliveringIcon.alpha = 1454f;
			}
		}
	}

	public void PFKBPMIABKL()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<WeaponScreen>.instance.selectedIcon.IBEDIAODLJD(NCFKLBGOEEF: true);
		JLDBLKLBCEG(NCFKLBGOEEF: false);
		GuiScreenSingle<WeaponScreen>.instance.MCFPJFKFJPH(this);
		GuiScreenSingle<WeaponScreen>.instance.MIIMDHKCINK();
		JHEOELIFKKA();
	}

	public virtual void CHNBJHGMMPO()
	{
		base.CCNKJOAKBNG();
		mWeaponTexture.ignoreInTable = true;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	public void IECDMODJKLD()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 0);
		}
		else if (weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered)
		{
			mSalePart.SetActive(!MDAJJIAMDGH.canBeUpgraded || Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 1);
		}
		else
		{
			mSalePart.SetActive(value: true);
		}
	}

	private void PILDGJHBBIJ()
	{
		UpdateGraphics();
	}

	public virtual void LEMPICGBCFK()
	{
		base.PDAFKNEEBFB();
		mWeaponTexture.ignoreInTable = false;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	public void BCOPHAHFLIN(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 1);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 0);
		mLockedLevel.text = string.Format("ArenaShieldsMessage", Localization.Localize("com/google/android/gms/common/ConnectionResult"), MDAJJIAMDGH.unlockLevel.PFMGLDJDNBF());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 571f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1027f, 1601f, 305f);
			object oEIICEJPGKI = new Vector3(1431f, 1739f, 993f);
			fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1273f, -1, oEIICEJPGKI, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
			FNOMCHPCOHB.BPEKAKFKCIG(4, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(285f, 620f, 164f), 152f, 0, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
			FNOMCHPCOHB.BPEKAKFKCIG(5, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(441f, 1909f, 991f), 1395f, 3, null, (UITweener.Method)7);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(LNBEIPFIHPC));
			FNOMCHPCOHB.JIPFOMFJNPC();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 573f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(1786f, 1043f, 12f);
			object iIMDKHJAJGO = new Vector3(1731f, 318f, 1589f);
			cFAIPFBHMPB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 592f, -1, iIMDKHJAJGO, UITweener.Method.BounceOut, UITweener.Style.Loop);
			CFAIPFBHMPB.NFLKPCIHOPJ(4, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(1999f, 308f, 291f), 878f, 1, null, UITweener.Method.Linear);
			CFAIPFBHMPB.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(73f, 728f, 518f), 388f, 7, null, UITweener.Method.BounceOut, UITweener.Style.Once, 0);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(EKALHLJEFGN));
			CFAIPFBHMPB.IGBJIEBMEBF();
		}
		JLDBLKLBCEG(NCFKLBGOEEF: true);
		MDBADNAJFBN(KGGCJPEKIAD: true);
		CEEKOPLCFPB();
		NKHNNDPGKLC = true;
	}

	private void LOEPOFGIAMP()
	{
		bool flag = ScreenManager.IsRendering(Singleton<GuiManager>.instance.KPDAPFBIPAI, base.transform.position, mBackground.transform.lossyScale.x * 0.5f);
		if (flag && !NKHNNDPGKLC)
		{
			BLKPDBBMICL();
		}
		if (!flag && NKHNNDPGKLC)
		{
			NNOIIKEACMH();
		}
	}

	private void DEBGBGGOCEN()
	{
		DHPEHBBCCDH();
	}

	private void CAGALLLMBKD()
	{
		NKHNNDPGKLC = true;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
	}

	public void BHGFCNNGGDN(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 0);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 0);
		mLockedLevel.text = string.Format("OK", Localization.Localize("ru"), MDAJJIAMDGH.unlockLevel.MHAOKJCDIOL());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 280f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1839f, 1293f, 108f);
			object oEIICEJPGKI = new Vector3(229f, 1197f, 1956f);
			fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1541f, -1, oEIICEJPGKI, UITweener.Method.BounceIn, UITweener.Style.Loop);
			FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(488f, 1194f, 145f), 152f, 1, null, UITweener.Method.BounceIn, UITweener.Style.Once, 0);
			FNOMCHPCOHB.BPEKAKFKCIG(8, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(479f, 1096f, 1423f), 641f, 5, null, (UITweener.Method)8);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(ODCBPBBNIJG));
			FNOMCHPCOHB.PGGAAGLGKAL();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 1443f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(1977f, 1682f, 796f);
			object iIMDKHJAJGO = new Vector3(525f, 1600f, 1678f);
			cFAIPFBHMPB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 1439f, -1, iIMDKHJAJGO, (UITweener.Method)7, UITweener.Style.Once, 0);
			CFAIPFBHMPB.NFLKPCIHOPJ(7, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(712f, 261f, 1199f), 592f, 1, null, UITweener.Method.BounceIn);
			CFAIPFBHMPB.MNEFMODDFFK(6, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(1306f, 1963f, 131f), 547f, 1, null, (UITweener.Method)6, UITweener.Style.Loop);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(EKALHLJEFGN));
			CFAIPFBHMPB.KHAFPAMIOAF();
		}
		JLDBLKLBCEG(NCFKLBGOEEF: true);
		APBKHBMILOL(KGGCJPEKIAD: true);
		HIMEPFCAAEN();
		NKHNNDPGKLC = true;
	}

	private void ABJIPBAMHEP()
	{
		NKHNNDPGKLC = false;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.KLLLHIKOPDM();
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
	}

	private void BLKPDBBMICL()
	{
		NKHNNDPGKLC = true;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	[SpecialName]
	public WeaponLevelsSetup CJAIGEJNDOH()
	{
		return MDAJJIAMDGH;
	}

	private void PCAODIMCOLJ(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 8)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered)
			{
				CFAIPFBHMPB.IAKEAKDJJIA();
				CFAIPFBHMPB.AGFMCNDAEEC();
			}
			else
			{
				mDeliveringIcon.alpha = 953f;
			}
		}
	}

	public void LPGHPNDKMLN(bool NCFKLBGOEEF)
	{
		mHighlight.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void CMHBHOAPJMD()
	{
		bool flag = ScreenManager.IsRendering(Singleton<GuiManager>.instance.KPDAPFBIPAI, base.transform.position, mBackground.transform.lossyScale.x * 893f);
		if (flag && !NKHNNDPGKLC)
		{
			MNBICBJAHOC();
		}
		if (!flag && NKHNNDPGKLC)
		{
			EGHEKPBABOK();
		}
	}

	public virtual void HENDKLKJPDA()
	{
		base.CCNKJOAKBNG();
		mWeaponTexture.ignoreInTable = false;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	private void HIMEPFCAAEN()
	{
		JCCONMEJKCD();
	}

	public void SetHighlight(bool NCFKLBGOEEF)
	{
		mHighlight.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void JOLGMBIAPJB()
	{
		mNotification.SetActive(Singleton<NotificationManager>.instance.NotificationForWeapon(MDAJJIAMDGH));
	}

	public void MKACIABNBPG()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<WeaponScreen>.instance.selectedIcon.PJEEJBPFNFA(NCFKLBGOEEF: false);
		LINPOIDDFGA(NCFKLBGOEEF: true);
		GuiScreenSingle<WeaponScreen>.instance.SetSelectedIcon(this);
		GuiScreenSingle<WeaponScreen>.instance.Select();
		LFJMFINAIHN();
	}

	public void GUIForReposition(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			mNotification.SetActive(Singleton<NotificationManager>.instance.NotificationForWeapon(MDAJJIAMDGH));
		}
		else
		{
			mNotification.SetActive(value: false);
		}
	}

	public void LINPOIDDFGA(bool NCFKLBGOEEF)
	{
		mHighlight.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void MMEBJMHABCC()
	{
		NKHNNDPGKLC = true;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
	}

	public void IBEDIAODLJD(bool NCFKLBGOEEF)
	{
		mHighlight.gameObject.SetActive(NCFKLBGOEEF);
	}

	public void JLDBLKLBCEG(bool NCFKLBGOEEF)
	{
		mHighlight.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void EKALHLJEFGN(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 2)
		{
			if (MDAJJIAMDGH.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8)
			{
				CFAIPFBHMPB.OHKEAEIFMPJ();
				CFAIPFBHMPB.GDCCFEDJFAF();
			}
			else
			{
				mDeliveringIcon.alpha = 1582f;
			}
		}
	}

	private void ODCBPBBNIJG(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 2)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
			{
				FNOMCHPCOHB.ResetTweens();
				FNOMCHPCOHB.PlayTweens();
			}
			else
			{
				mUpgradingIcon.alpha = 1432f;
			}
		}
	}

	private void CKOFBBBGEIJ()
	{
		bool flag = ScreenManager.IsRendering(Singleton<GuiManager>.instance.KPDAPFBIPAI, base.transform.position, mBackground.transform.lossyScale.x * 1620f);
		if (flag && !NKHNNDPGKLC)
		{
			MNBICBJAHOC();
		}
		if (!flag && NKHNNDPGKLC)
		{
			CAGALLLMBKD();
		}
	}

	private void PLHGANKOFDL()
	{
		mNotification.SetActive(Singleton<NotificationManager>.instance.KFCAHCLNIBB(MDAJJIAMDGH));
	}

	public virtual void BPIIBKJDJMA()
	{
		base.PDAFKNEEBFB();
		mWeaponTexture.ignoreInTable = true;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	private void NNOIIKEACMH()
	{
		NKHNNDPGKLC = false;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		weapons.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
	}

	private void JJCFNCDGAJA()
	{
		IHJCGOANEFE();
	}

	public void HPIOEEICEOH(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 1);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 1);
		mLockedLevel.text = string.Format("_Color", Localization.Localize(" mSpriteName:"), MDAJJIAMDGH.unlockLevel.PFMGLDJDNBF());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 1768f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1198f, 446f, 474f);
			object oEIICEJPGKI = new Vector3(866f, 1791f, 963f);
			fNOMCHPCOHB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1696f, -1, oEIICEJPGKI, (UITweener.Method)7, UITweener.Style.Once, 0);
			FNOMCHPCOHB.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(758f, 132f, 1682f), 720f, 0, null, UITweener.Method.Linear);
			FNOMCHPCOHB.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(1148f, 1652f, 692f), 76f, 0, null, (UITweener.Method)7, UITweener.Style.Once, 0);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(DFLEJKLDJKF));
			FNOMCHPCOHB.FEPILCEBNCJ();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 1235f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(101f, 458f, 1634f);
			object iIMDKHJAJGO = new Vector3(625f, 1959f, 1f);
			cFAIPFBHMPB.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 782f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
			CFAIPFBHMPB.AddTween(8, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(740f, 72f, 592f), 855f, 1, null, (UITweener.Method)8);
			CFAIPFBHMPB.FEHALDPLGDB(2, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(1869f, 535f, 373f), 407f, 0, null, UITweener.Method.EaseIn, UITweener.Style.Loop);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(LEJBKCMPHMF));
			CFAIPFBHMPB.HONNAONCPHA();
		}
		APHECPIPBPK(NCFKLBGOEEF: false);
		MDBADNAJFBN(KGGCJPEKIAD: true);
		CEEKOPLCFPB();
		NKHNNDPGKLC = false;
	}

	public void JCCONMEJKCD()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		mSpecialPart.SetActive(MDAJJIAMDGH.purchasableInShop || MDAJJIAMDGH.bought);
		mLocked.SetActive(!MDAJJIAMDGH.purchasableInShop || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked);
		mNotBought.SetActive(!MDAJJIAMDGH.purchasableInShop || weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		mRentedLabel.gameObject.SetActive(MDAJJIAMDGH.tryOutWeapon);
		mBlackmarketIcon.gameObject.SetActive(MDAJJIAMDGH.purchasableInBlackmarket);
		OJBFKBHDOOI();
		IECDMODJKLD();
		if (!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought)
		{
			mUpgradingIcon.alpha = 1368f;
			mDeliveringIcon.alpha = 1233f;
			return;
		}
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
		{
			FNOMCHPCOHB.ODIJFGCDJNH();
		}
		else
		{
			FNOMCHPCOHB.JEEKNFJCAMJ();
			FNOMCHPCOHB.EFGHGIBPMGL();
		}
		mUpgradingIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.Active) ? 811f : 842f);
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked)
		{
			CFAIPFBHMPB.PlayTweens();
		}
		else
		{
			CFAIPFBHMPB.KIOKIAFPHPE();
			CFAIPFBHMPB.ResetTweens();
		}
		mDeliveringIcon.alpha = ((weaponState != (WeaponLevelsSetup.JLANLLEABDC)7) ? 763f : 947f);
	}

	private void FKPBHJGJEKH(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 5)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
			{
				CFAIPFBHMPB.DGFKMBDKEAP();
				CFAIPFBHMPB.HMPMBAGNJOJ();
			}
			else
			{
				mDeliveringIcon.alpha = 1791f;
			}
		}
	}

	private void DAGICDEJNBE(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 6)
		{
			if (MDAJJIAMDGH.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8)
			{
				FNOMCHPCOHB.IAKEAKDJJIA();
				FNOMCHPCOHB.GDCCFEDJFAF();
			}
			else
			{
				mUpgradingIcon.alpha = 523f;
			}
		}
	}

	public void AHPBNNEKNBE()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<WeaponScreen>.instance.FMFHOPFBMOO().IBEDIAODLJD(NCFKLBGOEEF: true);
		LPGHPNDKMLN(NCFKLBGOEEF: true);
		GuiScreenSingle<WeaponScreen>.instance.SetSelectedIcon(this);
		GuiScreenSingle<WeaponScreen>.instance.Select();
		OJBFKBHDOOI();
	}

	private void PKGBHLGJEAF(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: true);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(1323f * Singleton<GuiTexureAssets>.instance.PLNHBCJFCOE());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: false);
		}
	}

	private void JHEOELIFKKA()
	{
		mNotification.SetActive(Singleton<NotificationManager>.instance.NotificationForWeapon(MDAJJIAMDGH));
	}

	public void PBDMBAJNHJO()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 1);
		}
		else if (weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == (WeaponLevelsSetup.JLANLLEABDC)7 || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering)
		{
			mSalePart.SetActive(MDAJJIAMDGH.canBeUpgraded && Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)6) > 1);
		}
		else
		{
			mSalePart.SetActive(value: false);
		}
	}

	public void SetSale()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Buy) > 0);
		}
		else if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || weaponState == WeaponLevelsSetup.JLANLLEABDC.Active)
		{
			mSalePart.SetActive(MDAJJIAMDGH.canBeUpgraded && Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Upgrade) > 0);
		}
		else
		{
			mSalePart.SetActive(value: false);
		}
	}

	private void DHPEHBBCCDH()
	{
		bool flag = ScreenManager.IsRendering(Singleton<GuiManager>.instance.KPDAPFBIPAI, base.transform.position, mBackground.transform.lossyScale.x * 80f);
		if (flag && !NKHNNDPGKLC)
		{
			MNBICBJAHOC();
		}
		if (!flag && NKHNNDPGKLC)
		{
			CAGALLLMBKD();
		}
	}

	private void JCLKNNHFIIE(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: true);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(1659f * Singleton<GuiTexureAssets>.instance.NFJLFPEOFKD());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: false);
		}
	}

	public void OLBFPNOACAD()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 0);
		}
		else if (weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering || weaponState == (WeaponLevelsSetup.JLANLLEABDC)7)
		{
			mSalePart.SetActive(MDAJJIAMDGH.canBeUpgraded && Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, AKDLEDNDIEO.Upgrade) > 0);
		}
		else
		{
			mSalePart.SetActive(value: true);
		}
	}

	private void LAHPOKILGCB()
	{
		if (NKHNNDPGKLC)
		{
			DMADJAFJNJJ();
		}
	}

	private void MKLGFNBIDIE()
	{
		LOPPOBCGPHD();
	}

	public void UpdateGraphics()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		mSpecialPart.SetActive(!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought);
		mLocked.SetActive(MDAJJIAMDGH.purchasableInShop && weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked);
		mNotBought.SetActive(MDAJJIAMDGH.purchasableInShop && weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		mRentedLabel.gameObject.SetActive(MDAJJIAMDGH.tryOutWeapon);
		mBlackmarketIcon.gameObject.SetActive(MDAJJIAMDGH.purchasableInBlackmarket);
		JOLGMBIAPJB();
		SetSale();
		if (!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought)
		{
			mUpgradingIcon.alpha = 0f;
			mDeliveringIcon.alpha = 0f;
			return;
		}
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering)
		{
			FNOMCHPCOHB.PlayTweens();
		}
		else
		{
			FNOMCHPCOHB.FinishTweens();
			FNOMCHPCOHB.ResetTweens();
		}
		mUpgradingIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivering) ? 0f : 1f);
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
		{
			CFAIPFBHMPB.PlayTweens();
		}
		else
		{
			CFAIPFBHMPB.FinishTweens();
			CFAIPFBHMPB.ResetTweens();
		}
		mDeliveringIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering) ? 0f : 1f);
	}

	private void OAIEFLCAPDN()
	{
		if (NKHNNDPGKLC)
		{
			DMADJAFJNJJ();
		}
	}

	public void PJEEJBPFNFA(bool NCFKLBGOEEF)
	{
		mHighlight.gameObject.SetActive(NCFKLBGOEEF);
	}

	private void GKHNCFNKBCA(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: false);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(1319f * Singleton<GuiTexureAssets>.instance.IPLEADDEGEI());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: false);
		}
	}

	public virtual void NPKBLONKNLB()
	{
		base.JMLMACKEGAM();
		mWeaponTexture.ignoreInTable = true;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	private void IAOHGBHKEEC(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 6)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
			{
				CFAIPFBHMPB.EFGHGIBPMGL();
				CFAIPFBHMPB.HMPMBAGNJOJ();
			}
			else
			{
				mDeliveringIcon.alpha = 605f;
			}
		}
	}

	public void OEBAKBIMECJ(bool NCFKLBGOEEF)
	{
		mHighlight.gameObject.SetActive(NCFKLBGOEEF);
	}

	[SpecialName]
	public WeaponLevelsSetup PMIIPNOJFLF()
	{
		return MDAJJIAMDGH;
	}

	public void NOBCMNHEKKM()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		mSpecialPart.SetActive(MDAJJIAMDGH.purchasableInShop || !MDAJJIAMDGH.bought);
		mLocked.SetActive(!MDAJJIAMDGH.purchasableInShop || weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		mNotBought.SetActive(MDAJJIAMDGH.purchasableInShop && weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		mRentedLabel.gameObject.SetActive(MDAJJIAMDGH.tryOutWeapon);
		mBlackmarketIcon.gameObject.SetActive(MDAJJIAMDGH.purchasableInBlackmarket);
		JOLGMBIAPJB();
		AOPMDPIACIA();
		if (!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought)
		{
			mUpgradingIcon.alpha = 1718f;
			mDeliveringIcon.alpha = 1030f;
			return;
		}
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
		{
			FNOMCHPCOHB.GDCCFEDJFAF();
		}
		else
		{
			FNOMCHPCOHB.NDGCGHLLPMC();
			FNOMCHPCOHB.OHKEAEIFMPJ();
		}
		mUpgradingIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivering) ? 1957f : 1397f);
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering)
		{
			CFAIPFBHMPB.PlayTweens();
		}
		else
		{
			CFAIPFBHMPB.CPKDFIKMKLE();
			CFAIPFBHMPB.LFOKFAFLBLA();
		}
		mDeliveringIcon.alpha = ((weaponState != (WeaponLevelsSetup.JLANLLEABDC)8) ? 1143f : 958f);
	}

	private void LNDBGPFDGOE(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: true);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(382f * Singleton<GuiTexureAssets>.instance.MLLEMEJOADP());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: true);
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		mWeaponTexture.ignoreInTable = true;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	public void IGDPCOCIBEL(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			mNotification.SetActive(Singleton<NotificationManager>.instance.NotificationForWeapon(MDAJJIAMDGH));
		}
		else
		{
			mNotification.SetActive(value: true);
		}
	}

	public void EIDJLBFGNDO()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, AKDLEDNDIEO.Buy) > 1);
		}
		else if (weaponState == (WeaponLevelsSetup.JLANLLEABDC)8 || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
		{
			mSalePart.SetActive(MDAJJIAMDGH.canBeUpgraded && Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, AKDLEDNDIEO.Buy) > 0);
		}
		else
		{
			mSalePart.SetActive(value: true);
		}
	}

	private void FOHGGOJLIPI(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			mWeaponTexture.gameObject.SetActive(value: false);
			mWeaponTexture.mainTexture = EBFDAICCJAK;
			mWeaponTexture.MakePixelPerfect();
			mWeaponTexture.transform.localScale = mWeaponTexture.transform.localScale.MultiplyXY(355f * Singleton<GuiTexureAssets>.instance.KHHIIBIMMDH());
		}
		else
		{
			mWeaponTexture.transform.localScale = Vector3.one;
			mWeaponTexture.gameObject.SetActive(value: true);
		}
	}

	private void HKJIMEHHBDA()
	{
		if (NKHNNDPGKLC)
		{
			CAGALLLMBKD();
		}
	}

	private void OnDisable()
	{
		if (NKHNNDPGKLC)
		{
			NNOIIKEACMH();
		}
	}

	public void OnClick()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<WeaponScreen>.instance.selectedIcon.SetHighlight(NCFKLBGOEEF: false);
		SetHighlight(NCFKLBGOEEF: true);
		GuiScreenSingle<WeaponScreen>.instance.SetSelectedIcon(this);
		GuiScreenSingle<WeaponScreen>.instance.Select();
		JOLGMBIAPJB();
	}

	public void PDLMIBCLICE()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		mSpecialPart.SetActive(!MDAJJIAMDGH.purchasableInShop && MDAJJIAMDGH.bought);
		mLocked.SetActive(MDAJJIAMDGH.purchasableInShop && weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked);
		mNotBought.SetActive(!MDAJJIAMDGH.purchasableInShop || weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		mRentedLabel.gameObject.SetActive(MDAJJIAMDGH.tryOutWeapon);
		mBlackmarketIcon.gameObject.SetActive(MDAJJIAMDGH.purchasableInBlackmarket);
		GAKDANPAAJB();
		LHEIJKMHFJM();
		if (!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought)
		{
			mUpgradingIcon.alpha = 1472f;
			mDeliveringIcon.alpha = 229f;
			return;
		}
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
		{
			FNOMCHPCOHB.GDCCFEDJFAF();
		}
		else
		{
			FNOMCHPCOHB.CJGJOAKNIIL();
			FNOMCHPCOHB.EFGHGIBPMGL();
		}
		mUpgradingIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked) ? 97f : 342f);
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering)
		{
			CFAIPFBHMPB.GDCCFEDJFAF();
		}
		else
		{
			CFAIPFBHMPB.PHCCOHJPLKE();
			CFAIPFBHMPB.LFOKFAFLBLA();
		}
		mDeliveringIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered) ? 846f : 831f);
	}

	private void GPABBGFMLMB()
	{
		if (NKHNNDPGKLC)
		{
			ABJIPBAMHEP();
		}
	}

	private void MNLGJEFNJDB(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 4)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
			{
				CFAIPFBHMPB.BIAMGHLKGOK();
				CFAIPFBHMPB.PlayTweens();
			}
			else
			{
				mDeliveringIcon.alpha = 405f;
			}
		}
	}

	private void CEEKOPLCFPB()
	{
		IHJCGOANEFE();
	}

	[SpecialName]
	public WeaponLevelsSetup OFABMGFOFPI()
	{
		return MDAJJIAMDGH;
	}

	private void NAIAHFGDLIJ()
	{
		NKHNNDPGKLC = true;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
		mWeaponTexture.transform.localScale = Vector3.one;
		mWeaponTexture.mainTexture = null;
		resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
	}

	public virtual void JNCPJFJHKML()
	{
		base.BeforeInstancied();
		mWeaponTexture.ignoreInTable = false;
		mWeaponTexture.transform.localScale = Vector3.one;
	}

	public void FINJCOBOAED()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		mSpecialPart.SetActive(MDAJJIAMDGH.purchasableInShop || MDAJJIAMDGH.bought);
		mLocked.SetActive(MDAJJIAMDGH.purchasableInShop && weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		mNotBought.SetActive(!MDAJJIAMDGH.purchasableInShop || weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		mRentedLabel.gameObject.SetActive(MDAJJIAMDGH.tryOutWeapon);
		mBlackmarketIcon.gameObject.SetActive(MDAJJIAMDGH.purchasableInBlackmarket);
		JHEOELIFKKA();
		FGEGPIAGDIP();
		if (!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought)
		{
			mUpgradingIcon.alpha = 984f;
			mDeliveringIcon.alpha = 1455f;
			return;
		}
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed)
		{
			FNOMCHPCOHB.GDCCFEDJFAF();
		}
		else
		{
			FNOMCHPCOHB.CPKDFIKMKLE();
			FNOMCHPCOHB.IAKEAKDJJIA();
		}
		mUpgradingIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivering) ? 1715f : 1970f);
		if (weaponState == WeaponLevelsSetup.JLANLLEABDC.Active)
		{
			CFAIPFBHMPB.AGFMCNDAEEC();
		}
		else
		{
			CFAIPFBHMPB.KIOKIAFPHPE();
			CFAIPFBHMPB.BIAMGHLKGOK();
		}
		mDeliveringIcon.alpha = ((weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered) ? 1591f : 1824f);
	}

	private void FCNONPDKFIC()
	{
		NKHNNDPGKLC = false;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public void NAOMPCKBHNK(bool NABOFKMBMKH)
	{
		if (NABOFKMBMKH)
		{
			mNotification.SetActive(Singleton<NotificationManager>.instance.MAJEFEAMFBB(MDAJJIAMDGH));
		}
		else
		{
			mNotification.SetActive(value: false);
		}
	}

	private void MBLPFLLINCA()
	{
		if (NKHNNDPGKLC)
		{
			EGHEKPBABOK();
		}
	}

	public void EDCAMHELMIP(WeaponLevelsSetup MBNLFKHLDBH)
	{
		MDAJJIAMDGH = MBNLFKHLDBH;
		mBuyWarbucksIcon.gameObject.SetActive(MDAJJIAMDGH.price > 0);
		mBuyGoldIcon.gameObject.SetActive(MDAJJIAMDGH.priceGold > 0);
		mLockedLevel.text = string.Format("Not a player visual.", Localization.Localize("VipStart"), MDAJJIAMDGH.unlockLevel.MHAOKJCDIOL());
		if (FNOMCHPCOHB == null)
		{
			FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
			FNOMCHPCOHB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num = 1272f;
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = mUpgradingIcon.gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = new Vector3(1476f, 652f, 318f);
			object oEIICEJPGKI = new Vector3(1575f, 1414f, 681f);
			fNOMCHPCOHB.MNEFMODDFFK(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 1094f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop);
			FNOMCHPCOHB.FEHALDPLGDB(3, TweenAnimator.MNAIKKJDPLK.Rotation, mUpgradingIcon.gameObject, num, new Vector3(577f, 501f, 340f), 912f, 0);
			FNOMCHPCOHB.MNEFMODDFFK(4, TweenAnimator.MNAIKKJDPLK.Position, mUpgradingIcon.gameObject, num, new Vector3(1762f, 146f, 514f), 1639f, 4, null, (UITweener.Method)8, UITweener.Style.Loop);
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			fNOMCHPCOHB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB2.JHDBHGCKPDM, new Action<int>(ODCBPBBNIJG));
			FNOMCHPCOHB.GenerateTweens();
		}
		if (CFAIPFBHMPB == null)
		{
			CFAIPFBHMPB = base.gameObject.AddComponent<TweenAnimator>();
			CFAIPFBHMPB.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
			float num2 = 1149f;
			TweenAnimator cFAIPFBHMPB = CFAIPFBHMPB;
			int iNFLHPGMEOB = 1;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Rotation;
			GameObject nIHOBEAHEKJ = mDeliveringIcon.gameObject;
			float kBJEOEEOEFG = num2;
			object oEIICEJPGKI = new Vector3(1461f, 866f, 387f);
			object iIMDKHJAJGO = new Vector3(44f, 790f, 165f);
			cFAIPFBHMPB.FEHALDPLGDB(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, 257f, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
			CFAIPFBHMPB.MNEFMODDFFK(7, TweenAnimator.MNAIKKJDPLK.Position, mDeliveringIcon.gameObject, num2, new Vector3(1468f, 1557f, 110f), 135f, 0, null, (UITweener.Method)6, UITweener.Style.Loop);
			CFAIPFBHMPB.NFLKPCIHOPJ(6, TweenAnimator.MNAIKKJDPLK.Rotation, mDeliveringIcon.gameObject, num2, new Vector3(467f, 1297f, 856f), 709f, 4, null, UITweener.Method.EaseOut);
			TweenAnimator cFAIPFBHMPB2 = CFAIPFBHMPB;
			cFAIPFBHMPB2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(cFAIPFBHMPB2.JHDBHGCKPDM, new Action<int>(IAOHGBHKEEC));
			CFAIPFBHMPB.HONNAONCPHA();
		}
		APHECPIPBPK(NCFKLBGOEEF: true);
		ODGGNJBBDCI(KGGCJPEKIAD: true);
		AELKOGAOHGE();
		NKHNNDPGKLC = false;
	}

	public void CFMEACOPEND()
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		GuiScreenSingle<WeaponScreen>.instance.PAAMHOJOFFP().IIPCKKGBHIN(NCFKLBGOEEF: true);
		JLDBLKLBCEG(NCFKLBGOEEF: true);
		GuiScreenSingle<WeaponScreen>.instance.MCFPJFKFJPH(this);
		GuiScreenSingle<WeaponScreen>.instance.MIIMDHKCINK();
		PANNOJHHCCB();
	}

	public void LHEIJKMHFJM()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 0);
		}
		else if (weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered || weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
		{
			mSalePart.SetActive(MDAJJIAMDGH.canBeUpgraded && Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Upgrade) > 1);
		}
		else
		{
			mSalePart.SetActive(value: false);
		}
	}

	public void BLEOKADCKCD()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		if ((weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked) && MDAJJIAMDGH.purchasableInShop)
		{
			mSalePart.SetActive(Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 1);
		}
		else if (weaponState == (WeaponLevelsSetup.JLANLLEABDC)8 || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || weaponState == WeaponLevelsSetup.JLANLLEABDC.Active)
		{
			mSalePart.SetActive(!MDAJJIAMDGH.canBeUpgraded || Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, (AKDLEDNDIEO)0) > 1);
		}
		else
		{
			mSalePart.SetActive(value: true);
		}
	}

	private void OJBFKBHDOOI()
	{
		mNotification.SetActive(Singleton<NotificationManager>.instance.KFCAHCLNIBB(MDAJJIAMDGH));
	}

	private void HAILIAAHHDH(int ABKIPJJCDMF)
	{
		if (ABKIPJJCDMF == 3)
		{
			if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering)
			{
				FNOMCHPCOHB.ResetTweens();
				FNOMCHPCOHB.PlayTweens();
			}
			else
			{
				mUpgradingIcon.alpha = 0f;
			}
		}
	}

	public virtual void ONIMJGIHHIE()
	{
		base.BeforeInstancied();
		mWeaponTexture.ignoreInTable = true;
		mWeaponTexture.transform.localScale = Vector3.one;
	}
}
