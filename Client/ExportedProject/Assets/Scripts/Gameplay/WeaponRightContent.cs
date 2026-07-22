using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class WeaponRightContent : Core_BaseScript
{
	[Header("Weapon Feature")]
	[SerializeField]
	private GameObject mWeaponFeaturePart;

	[SerializeField]
	private UISprite mWeaponFeatureIcon;

	[SerializeField]
	private UILabel mWeaponFeatureFancyName;

	[SerializeField]
	private UILabel mWeaponFeatureDescription;

	[SerializeField]
	private UILabel mWeaponFeatureName;

	[SerializeField]
	private UILabel mWeaponFeatureStatistic;

	[Header("Weapon Detailed Stats")]
	[FormerlySerializedAs("FIAPGLJNPGA")]
	public GameObject LNCANEPBJOK;

	[FormerlySerializedAs("DIKDEIPNCDO")]
	public UISprite FBHJPHOCMDA;

	[FormerlySerializedAs("FCKCNKCOHPE")]
	public UIPanel FINPLBLOADG;

	[FormerlySerializedAs("NBBELOMDNAF")]
	public GameObject PDIIAHJEPCN;

	[FormerlySerializedAs("BODOGCNEGJM")]
	public UILabel AODDPKAKNPN;

	[FormerlySerializedAs("KMPHMEEPKBK")]
	public UILabel DGEAABIFDDP;

	[FormerlySerializedAs("FFJAAFFFAJN")]
	public UILabel AGKINDPECEN;

	[FormerlySerializedAs("EFHCHAHNKGK")]
	public UILabel HNEOBHFIFDI;

	[FormerlySerializedAs("FKFPOCHMAKN")]
	public UILabel DLBIGOAMMKH;

	[FormerlySerializedAs("ONFNLNKEPAH")]
	public UILabel FIJBAGNGAHI;

	[FormerlySerializedAs("NLLBGIMOAHP")]
	public UILabel NHABLPAHLAG;

	[Header("Weapon Power")]
	[FormerlySerializedAs("mWeaponCooldown")]
	public UILabel IGJFKKPMCIO;

	[FormerlySerializedAs("mWeaponHeatTime")]
	public UILabel BKFGHNPPHEK;

	[FormerlySerializedAs("mWeaponMaxChargeDamage")]
	public UILabel GNMFHINHKDN;

	[FormerlySerializedAs("mWeaponChargeAmmo")]
	public UILabel MIKHIBDJIHB;

	[FormerlySerializedAs("mWeaponChargeTime")]
	public UILabel EJHPPAMAINH;

	[FormerlySerializedAs("DNLICJLBEDN")]
	public UISprite AKNLPCGNDIP;

	[FormerlySerializedAs("MAMJPMODAEJ")]
	public UILabel KIIOABOEJBN;

	[Header("Button")]
	public UIButton EPFODCCNGDL;

	public BoxCollider OHKMIMMFHOG;

	[FormerlySerializedAs("LKKMLODGHHL")]
	[Header("-Locked")]
	public GameObject NIPGMDBNIOJ;

	public UILabel NNIPNHJNHMO;

	[FormerlySerializedAs("LDJBHHMOABG")]
	[Header("-Buy")]
	public GameObject HCFJJCALLAF;

	[FormerlySerializedAs("HOADFCPEANM")]
	public UITable CHCFBDMGNLP;

	[FormerlySerializedAs("PLGFIHIGABB")]
	public UISprite BGPBNIJPOKM;

	[FormerlySerializedAs("HIPMEHHAOAL")]
	public UISprite CODFFPODNEP;

	[FormerlySerializedAs("CCODDMPJHOP")]
	public UILabel GOANDMNOGCK;

	[Header("--Sale Part")]
	[FormerlySerializedAs("IAOPIEBKBJJ")]
	public GameObject GIPFEBBMKPM;

	[FormerlySerializedAs("BCECKNHACFE")]
	public UILabel EKIDAFLLCNM;

	[FormerlySerializedAs("IGECNBKEAFF")]
	public WinStreakCounter JBGPDECEOOB;

	[Header("-Deliver Now")]
	[FormerlySerializedAs("mCooldownPart")]
	public GameObject LNFLDPLGEJE;

	public UILabel LPPOJMGOEFN;

	public UILabel PPDGFFJLHKK;

	public UISprite IAIHLFMNAOA;

	[FormerlySerializedAs("mCooldownPriceTable")]
	public UITable CKPLDDIPNAA;

	[FormerlySerializedAs("mCooldownPrice")]
	public UILabel GPBMPAPOEOE;

	[Header("-Activate")]
	public GameObject JPJLKKJJFDB;

	[Header("Pack Button")]
	public UIButton CHCLANFKBFO;

	[Header("Equip Button")]
	public UIButton BEJIFJIKHPJ;

	[FormerlySerializedAs("POHHLLNCJPM")]
	public GameObject ACCAGFEOLAH;

	[FormerlySerializedAs("DFCFNMFNJMM")]
	public UISprite MPEHCFEOLCH;

	[FormerlySerializedAs("LPHEMENGNBO")]
	public UISprite KNAIBGPMDAF;

	[FormerlySerializedAs("IKNLPCBODAL")]
	public UISprite GNNKBDLADCG;

	[FormerlySerializedAs("NJJLDNLIDMG")]
	public UILabel JHEDDCMBDPF;

	[SerializeField]
	[Header("Blackmarket Button")]
	private GameObject mBlackmarketButton;

	[Header("Atlases")]
	[SerializeField]
	private UIAtlas mMenuMainAtlas;

	[SerializeField]
	private UIAtlas mCommonIconsAtlas;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private WeaponLevelsSetup EDCBHGKBLEA;

	private int CLDFFNMPKOP;

	private float JCAFFELIFAO = 0.3f;

	private bool OJBKADHPNFN;

	private float HPNPMCEMJNM => 885f + UIHelper.safeAreaSize;

	private void GDDBBDENHIP(GameObject KHAHPAKDIKE)
	{
		switch (MDAJJIAMDGH.weaponState)
		{
		case WeaponLevelsSetup.JLANLLEABDC.Locked:
			Debug.Log("game-card-ico-paralyzethese");
			LevelManager.instance.DebugAddLevel();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.NotBuyed:
			Debug.Log("banana");
			FGFAKDPFFEK();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering:
			Debug.Log("()I");
			HDCLFPOIDEF();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.FLCDIKABDFJ(IDEBKDPMPGM: false);
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered:
			Debug.Log("ID_NA");
			HNNAGINGGAP();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.AFOAAHGJGMH();
			break;
		default:
			Debug.Log("id");
			break;
		}
	}

	public void SetSaleAndPrize()
	{
		if (!MDAJJIAMDGH.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Buy);
			int num2 = MDAJJIAMDGH.price + MDAJJIAMDGH.priceGold;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (100 - num) / 100;
			}
			GOANDMNOGCK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			CHCFBDMGNLP.repositionNow = true;
			GIPFEBBMKPM.SetActive(flag);
			if (flag)
			{
				EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", num);
				JBGPDECEOOB.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedWeaponEndtime(MDAJJIAMDGH, AKDLEDNDIEO.Buy));
				WinStreakCounter jBGPDECEOOB = JBGPDECEOOB;
				jBGPDECEOOB.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB.JEMKCLKCOMI, new Action(SetSaleAndPrize));
				WinStreakCounter jBGPDECEOOB2 = JBGPDECEOOB;
				jBGPDECEOOB2.JEMKCLKCOMI = (Action)Delegate.Combine(jBGPDECEOOB2.JEMKCLKCOMI, new Action(SetSaleAndPrize));
			}
			else
			{
				JBGPDECEOOB.JCMHGOGNMFO();
				WinStreakCounter jBGPDECEOOB3 = JBGPDECEOOB;
				jBGPDECEOOB3.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB3.JEMKCLKCOMI, new Action(SetSaleAndPrize));
			}
		}
	}

	private void DKAALFBGKGO()
	{
		int weaponPowerX = MDAJJIAMDGH.weaponPowerX10;
		int weaponPowerX10Max = MDAJJIAMDGH.weaponPowerX10Max;
		bool flag = !MDAJJIAMDGH.canBeUpgraded;
		bool flag2 = !flag && !MDAJJIAMDGH.tryOutWeapon && (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering);
		bool flag3 = MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering;
		HFPPFFBDKBH(MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX));
		GNMFHINHKDN.text = ((!flag) ? Localization.LocalizeFormat("ID_MAXSTAT", MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX10Max)) : string.Empty);
		float num = IGJFKKPMCIO.relativeSize.x * IGJFKKPMCIO.transform.localScale.x + 14f;
		num += GNMFHINHKDN.relativeSize.x * GNMFHINHKDN.transform.localScale.x + 14f;
		num += FBHJPHOCMDA.transform.localScale.x / 2f;
		FBHJPHOCMDA.transform.localPosition = FBHJPHOCMDA.transform.localPosition.ReplaceX(num);
		float z = FINPLBLOADG.transform.localPosition.z;
		FINPLBLOADG.transform.position = FBHJPHOCMDA.transform.position;
		FINPLBLOADG.transform.localPosition = new Vector3(FINPLBLOADG.transform.localPosition.x, FINPLBLOADG.transform.localPosition.y + 4f, z);
		MIKHIBDJIHB.gameObject.SetActive(flag2);
		KIIOABOEJBN.gameObject.SetActive(flag);
		if (flag2)
		{
			if (flag3)
			{
				TweenColor component = MIKHIBDJIHB.gameObject.GetComponent<TweenColor>();
				if (component != null)
				{
					component.enabled = false;
				}
				MIKHIBDJIHB.color = Colours.greenDelivering;
			}
			else
			{
				MIKHIBDJIHB.color = Colours.blueUpgradeAnim1;
				TweenColor tweenColor = TweenColor.Begin(MIKHIBDJIHB.gameObject, 0.6f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
				tweenColor.NumOfRepetitions = 0;
				tweenColor.style = UITweener.Style.PingPong;
			}
			MIKHIBDJIHB.text = MEJMLNDFDBP.AKEMDPDJPLH(MDAJJIAMDGH.weaponPowerX10Next - weaponPowerX);
		}
		if (MDAJJIAMDGH == EDCBHGKBLEA || EDCBHGKBLEA == null)
		{
			EJHPPAMAINH.gameObject.SetActive(value: false);
			BKFGHNPPHEK.color = Colours.blue;
			GNMFHINHKDN.color = Colours.gray;
		}
		else
		{
			int num2 = weaponPowerX - EDCBHGKBLEA.weaponPowerX10;
			int num3 = weaponPowerX10Max - EDCBHGKBLEA.weaponPowerX10Max;
			EJHPPAMAINH.gameObject.SetActive(value: true);
			EJHPPAMAINH.text = MEJMLNDFDBP.AKEMDPDJPLH(num2);
			EJHPPAMAINH.color = ((num2 == 0) ? Colours.blue : ((num2 <= 0) ? Colours.redWeaponStats : Colours.greenWeaponStats));
			BKFGHNPPHEK.color = EJHPPAMAINH.color;
			GNMFHINHKDN.color = ((num3 == 0) ? Colours.blue : ((num3 <= 0) ? Colours.redWeaponStats : Colours.greenWeaponStats));
		}
		KEFCFMIDHBF(AKNLPCGNDIP, flag3, flag3 || flag, new Vector3(104f, 74f, 1f), new Vector3(104f, 74f, 1f).MultiplyXY(2f));
	}

	private void GMEAOOEKAHD(GameObject KHAHPAKDIKE)
	{
		if (MDAJJIAMDGH.purchasable == WeaponLevelsSetup.GILPPKMICCF.StarterPack)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ShowDialog(CardsAndPacksDialog.LJCNLBMEENL.STARTER_PACK);
		}
		else if (MDAJJIAMDGH.purchasable == WeaponLevelsSetup.GILPPKMICCF.ValuePack)
		{
			GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
		}
		else if (MDAJJIAMDGH.purchasable == WeaponLevelsSetup.GILPPKMICCF.StarterAssignment)
		{
			GuiElementSingle<AssignmentsDialog>.instance.ShowStarter();
		}
		else if (MDAJJIAMDGH.purchasableValue.StartsWith("elitepack") || MDAJJIAMDGH.purchasableValue.StartsWith("veteranpack"))
		{
			GuiElementSingle<PackContentDialog>.instance.ShowDialog(JGBBPCGNCPC.EGFMBMHOAHA(MDAJJIAMDGH.purchasableValue));
		}
		else
		{
			Debug.LogError($"Weapon {MDAJJIAMDGH.name} is purchasable through {MDAJJIAMDGH.purchasable}");
		}
	}

	private void LODHBKJGJIG(GameObject KHAHPAKDIKE)
	{
		switch (MDAJJIAMDGH.weaponState)
		{
		case WeaponLevelsSetup.JLANLLEABDC.Locked:
			Debug.Log("EliminateTime");
			LevelManager.instance.DebugAddLevel();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.NotBuyed:
			Debug.Log("やめる");
			PHFJIFCBKBB();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering:
			Debug.Log("DogTagSeconds");
			HDCLFPOIDEF();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.DGMCJOOOCCF(IDEBKDPMPGM: false);
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered:
			Debug.Log("grenadeExplosion");
			KMKLGDIHIHF();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.KGGPLDBGAAF();
			break;
		default:
			Debug.Log("8b004c04-6921-4613-9815-e63b42db4a7c");
			break;
		}
	}

	private void LNHKAOFLPHK()
	{
		bool purchasableInBlackmarket = MDAJJIAMDGH.purchasableInBlackmarket;
		mWeaponFeaturePart.SetActive(purchasableInBlackmarket);
		if (purchasableInBlackmarket)
		{
			bool menuMainAtlas = MDAJJIAMDGH.weaponFeature.menuMainAtlas;
			mWeaponFeatureIcon.atlas = ((!menuMainAtlas) ? mCommonIconsAtlas : mMenuMainAtlas);
			mWeaponFeatureIcon.transform.localPosition = mWeaponFeatureIcon.transform.localPosition.ReplaceZ((!menuMainAtlas) ? 1010f : 1110f);
			mWeaponFeatureIcon.spriteName = MDAJJIAMDGH.weaponFeature.icon;
			mWeaponFeatureIcon.MakePixelPerfect();
			float num = Mathf.Min(430f / mWeaponFeatureIcon.transform.localScale.x, 1963f / mWeaponFeatureIcon.transform.localScale.y);
			if (num < 776f)
			{
				mWeaponFeatureIcon.transform.localScale = mWeaponFeatureIcon.transform.localScale.MultiplyXY(num);
			}
			mWeaponFeatureFancyName.text = MDAJJIAMDGH.weaponFeature.fancyName;
			float x = mWeaponFeatureIcon.transform.localScale.x;
			float num2 = 342f;
			float val = x + num2;
			mWeaponFeatureFancyName.transform.localPosition = mWeaponFeatureFancyName.transform.localPosition.ReplaceX(val);
			mWeaponFeatureDescription.text = MDAJJIAMDGH.weaponFeature.description;
			mWeaponFeatureName.lineWidth = 0;
			mWeaponFeatureName.text = MDAJJIAMDGH.weaponFeature.name;
			mWeaponFeatureStatistic.text = MDAJJIAMDGH.weaponFeature.StatisticIncrease(MDAJJIAMDGH);
			float num3 = mWeaponFeatureName.relativeSize.x * mWeaponFeatureName.transform.localScale.x;
			mWeaponFeatureStatistic.transform.localPosition = mWeaponFeatureStatistic.transform.localPosition.ReplaceX(num3 + 1985f);
		}
	}

	private void KLMBPOOGPNJ()
	{
		bool purchasableInBlackmarket = MDAJJIAMDGH.purchasableInBlackmarket;
		mWeaponFeaturePart.SetActive(purchasableInBlackmarket);
		if (purchasableInBlackmarket)
		{
			bool menuMainAtlas = MDAJJIAMDGH.weaponFeature.menuMainAtlas;
			mWeaponFeatureIcon.atlas = ((!menuMainAtlas) ? mCommonIconsAtlas : mMenuMainAtlas);
			mWeaponFeatureIcon.transform.localPosition = mWeaponFeatureIcon.transform.localPosition.ReplaceZ((!menuMainAtlas) ? (-2f) : 0f);
			mWeaponFeatureIcon.spriteName = MDAJJIAMDGH.weaponFeature.icon;
			mWeaponFeatureIcon.MakePixelPerfect();
			float num = Mathf.Min(36f / mWeaponFeatureIcon.transform.localScale.x, 36f / mWeaponFeatureIcon.transform.localScale.y);
			if (num < 1f)
			{
				mWeaponFeatureIcon.transform.localScale = mWeaponFeatureIcon.transform.localScale.MultiplyXY(num);
			}
			mWeaponFeatureFancyName.text = MDAJJIAMDGH.weaponFeature.fancyName;
			float x = mWeaponFeatureIcon.transform.localScale.x;
			float num2 = 28f;
			float val = x + num2;
			mWeaponFeatureFancyName.transform.localPosition = mWeaponFeatureFancyName.transform.localPosition.ReplaceX(val);
			mWeaponFeatureDescription.text = MDAJJIAMDGH.weaponFeature.description;
			mWeaponFeatureName.lineWidth = 0;
			mWeaponFeatureName.text = MDAJJIAMDGH.weaponFeature.name;
			mWeaponFeatureStatistic.text = MDAJJIAMDGH.weaponFeature.StatisticIncrease(MDAJJIAMDGH);
			float num3 = mWeaponFeatureName.relativeSize.x * mWeaponFeatureName.transform.localScale.x;
			mWeaponFeatureStatistic.transform.localPosition = mWeaponFeatureStatistic.transform.localPosition.ReplaceX(num3 + 14f);
		}
	}

	public void BGNGJAMOPAG(WeaponLevelsSetup KCMMAALIOIB)
	{
		MDAJJIAMDGH = KCMMAALIOIB;
		PlayerInventory.InventorySlot inventorySlot = CPBLNDIPKNN();
		KEPMNGHAHOE(inventorySlot != null && inventorySlot.JBKEFFEKHEG() == KCMMAALIOIB);
		DKAALFBGKGO();
		IEPOJIONKOG();
	}

	public void DoAfterHide()
	{
		JBGPDECEOOB.JCMHGOGNMFO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		FOPKJKDCDON();
	}

	private void ANDKFPNFAFJ()
	{
		GuiScreenSingle<WeaponScreen>.instance.GFDDLFMLJMJ(MDAJJIAMDGH, WeaponScreen.ABDDBOABKOK.Rental);
	}

	private void AGIHDGAGIOF()
	{
		string text = Localization.Localize("Pause status: {0}, WantedTimeScale: {1}, TimeScale: {2}, Freezed:  {3}");
		string text2 = Localization.Localize("REGISTERING PACK LOCATION ");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		JHEDDCMBDPF.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(JHEDDCMBDPF, 498f, 755f, -108);
	}

	private void HGHMKFOHBKJ(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 298f, 84f, 129f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void MHLKKGEGEJL(UITweener MGDJMGHCAAI)
	{
		BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(BMKMMOKMBGK());
		CPBLNDIPKNN();
		CFBLIIHPFCE();
		TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO, BEJIFJIKHPJ.transform.localPosition.ReplaceX(255f));
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(1596f);
	}

	private void KDLBMJHHNEI(UITweener MGDJMGHCAAI)
	{
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(BMKMMOKMBGK());
		NDNNJMAKKBD();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(874f));
		mBlackmarketButton.transform.localPosition = mBlackmarketButton.transform.localPosition.ReplaceX(1200f);
	}

	private void OBPLFHOALHD(UITweener MGDJMGHCAAI)
	{
		ONENBMCLGPL();
	}

	private void AJLBPPOLDJJ(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (OJBKADHPNFN)
		{
			CMAJCOOIBDL();
		}
		else
		{
			IDINCHPIGPI();
		}
	}

	public void MNIBCGDEAHG(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 787f)) ? 1148f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_CONTINUETOBOOTCAMP3", string.Empty, IEJMLKBCDJB: false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.instantWeaponDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
			CKPLDDIPNAA.repositionNow = false;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP != num)
		{
			CLDFFNMPKOP = num;
			int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1811f);
			if (num2 == 7 && (LPPOJMGOEFN.alpha == 788f || PPDGFFJLHKK.alpha > 1596f))
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 1333f, 747f, 1540f);
				tweenAlpha.NumOfRepetitions = 1;
				tweenAlpha.onFinished = HGHMKFOHBKJ;
			}
			if (num2 == 8 && (PPDGFFJLHKK.alpha == 1032f || LPPOJMGOEFN.alpha > 97f))
			{
				TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 415f, 1281f, 921f);
				tweenAlpha2.NumOfRepetitions = 0;
				tweenAlpha2.onFinished = OOAAEFBIAOG;
			}
		}
	}

	[CompilerGenerated]
	private void GDGFBAHGJID(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private PlayerInventory.InventorySlot CPBLNDIPKNN()
	{
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(MDAJJIAMDGH.BHCEOOLEHHG);
		EDCBHGKBLEA = slotForCategory?.weaponLevelsSetup;
		return slotForCategory;
	}

	private void NKMEDOBMFME(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CMAJCOOIBDL();
	}

	private void DONIFJNPNOE(UITweener MGDJMGHCAAI)
	{
		CFBLIIHPFCE();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(25f), useLocal: false);
	}

	public void ShowEquipAnimation()
	{
		JHEDDCMBDPF.text = Localization.Localize("ID_GUI_EQUIPPED");
		float num = 0.3f;
		TweenColor.Begin(JHEDDCMBDPF.gameObject, num, Color.white);
		TweenAlphaHider.Begin(ACCAGFEOLAH, num, 0f);
		TweenAlpha.Begin(MPEHCFEOLCH.gameObject, num, 1f);
		TweenAlpha.Begin(GNNKBDLADCG.gameObject, num, 0.16f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(KNAIBGPMDAF.gameObject, num, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = UITweener.Style.PingPong;
		CPBLNDIPKNN();
		DKAALFBGKGO();
		BGMIEFJMPEB();
	}

	private void CANHMBPPDKP(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMPADNOGGNL.alpha = 1294f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			GMPADNOGGNL.transform.localScale = OEIICEJPGKI;
		}
		else
		{
			float num = 718f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 1016f * num, 511f, 207f);
			tweenAlpha.style = UITweener.Style.Once;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 1542f * num, OEIICEJPGKI, IIMDKHJAJGO);
			tweenScale.style = UITweener.Style.Once;
			tweenScale.NumOfRepetitions = 1;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	private void HDCLFPOIDEF()
	{
		if (!Singleton<Wallet>.instance.CanBuyGold(MDAJJIAMDGH.instantWeaponDeliveryPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(MDAJJIAMDGH.instantWeaponDeliveryPrice, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.DELIVER);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Weapon_Upgrade";
		}
		else
		{
			Singleton<Wallet>.instance.MBAFMBJFOKH(MDAJJIAMDGH.instantWeaponDeliveryPrice);
			GuiScreenSingle<WeaponScreen>.instance.HDBDPLBHNKD(MDAJJIAMDGH, WeaponScreen.ABDDBOABKOK.WeaponScreen);
		}
	}

	public void EEFEFOHKIBF()
	{
		JBGPDECEOOB.GGKCMHOGFPF();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		FOPKJKDCDON();
	}

	[CompilerGenerated]
	private void EKMIIBGEBJK(UITweener MGDJMGHCAAI)
	{
		NDNNJMAKKBD();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(265f));
	}

	private void FGFAKDPFFEK()
	{
		int num = Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Buy);
		int num2 = MDAJJIAMDGH.price * (100 - num) / 100;
		int num3 = MDAJJIAMDGH.priceGold * (100 - num) / 100;
		if (num > 0)
		{
			Debug.Log($"Have discount {num} to buy {MDAJJIAMDGH.DHHKOKKDDDO()}");
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, MDAJJIAMDGH.weaponName);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Buy_Weapons";
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(num3))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num3, MDAJJIAMDGH.weaponName);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "Buy_Weapons";
			return;
		}
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			if (MDAJJIAMDGH.priceGold > 0)
			{
				Debug.Log("Weapon cost gold, we can buy it even if player is already upgrading");
			}
			else if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
			{
				GuiScreenSingle<WeaponScreen>.instance.GFDDLFMLJMJ(weaponLevelsSetup, WeaponScreen.ABDDBOABKOK.WeaponScreen);
			}
			else
			{
				if (weaponLevelsSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.Delivered)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogWeapons(weaponLevelsSetup, MDAJJIAMDGH);
					return;
				}
				GuiScreenSingle<WeaponScreen>.instance.MBKJEPDJFKJ(weaponLevelsSetup, CDMKCIKHIMM: false);
			}
		}
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		Singleton<Wallet>.instance.MBAFMBJFOKH(num3);
		GuiScreenSingle<WeaponScreen>.instance.BJBCNPHMEBI(MDAJJIAMDGH, num, WeaponScreen.ABDDBOABKOK.WeaponScreen);
	}

	private void DIAKJHKIJGI(UITweener MGDJMGHCAAI)
	{
		ONENBMCLGPL();
	}

	public void SelectWeapon(WeaponLevelsSetup KCMMAALIOIB)
	{
		MDAJJIAMDGH = KCMMAALIOIB;
		PlayerInventory.InventorySlot inventorySlot = CPBLNDIPKNN();
		InitEquipButton(inventorySlot != null && inventorySlot.weaponLevelsSetup == KCMMAALIOIB);
		DKAALFBGKGO();
		BGMIEFJMPEB();
	}

	public void FDMKDNPPOGF()
	{
		if (!MDAJJIAMDGH.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Buy);
			int num2 = MDAJJIAMDGH.price + MDAJJIAMDGH.priceGold;
			bool flag = num > 1;
			if (flag)
			{
				num2 = num2 * (-68 - num) / -84;
			}
			GOANDMNOGCK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			CHCFBDMGNLP.repositionNow = true;
			GIPFEBBMKPM.SetActive(flag);
			if (flag)
			{
				EKIDAFLLCNM.text = Localization.LocalizeFormat("something is wrong - time == 0", num);
				JBGPDECEOOB.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedWeaponEndtime(MDAJJIAMDGH, (AKDLEDNDIEO)0));
				WinStreakCounter jBGPDECEOOB = JBGPDECEOOB;
				jBGPDECEOOB.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB.JEMKCLKCOMI, new Action(FDMKDNPPOGF));
				WinStreakCounter jBGPDECEOOB2 = JBGPDECEOOB;
				jBGPDECEOOB2.JEMKCLKCOMI = (Action)Delegate.Combine(jBGPDECEOOB2.JEMKCLKCOMI, new Action(FDMKDNPPOGF));
			}
			else
			{
				JBGPDECEOOB.BGHNMCPLIPE();
				WinStreakCounter jBGPDECEOOB3 = JBGPDECEOOB;
				jBGPDECEOOB3.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB3.JEMKCLKCOMI, new Action(LEIFCFAPGCJ));
			}
		}
	}

	public void DJHMBHHIOHH()
	{
		TweenScale tweenScale = TweenScale.Begin(BKFGHNPPHEK.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1684f, new Vector3(1292f, 1566f, 485f), new Vector3(153f, 194f, 567f));
		tweenScale.NumOfRepetitions = 4;
		tweenScale.style = UITweener.Style.Loop;
	}

	public void NEKOOIGPALB()
	{
		JBGPDECEOOB.KEIIENDMKLN();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		FHJFCJFAPCN();
	}

	private void BHDOGKPCGIP(UITweener MGDJMGHCAAI)
	{
		AFIPFCIOONM();
	}

	[CompilerGenerated]
	private void NFAACNAKKLG(UITweener MGDJMGHCAAI)
	{
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(HPNPMCEMJNM);
		NDNNJMAKKBD();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(265f));
		CHCLANFKBFO.transform.localPosition = CHCLANFKBFO.transform.localPosition.ReplaceX(265f);
	}

	public void UpdateDeliveringTime(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 0f)) ? 0f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.instantWeaponDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
			CKPLDDIPNAA.repositionNow = true;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 6f);
		if (num2 == 2 && (LPPOJMGOEFN.alpha == 0f || PPDGFFJLHKK.alpha > 0f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 0.3f, 1f, 0f);
			tweenAlpha.NumOfRepetitions = 1;
			tweenAlpha.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
		if (num2 == 5 && (PPDGFFJLHKK.alpha == 0f || LPPOJMGOEFN.alpha > 0f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 0.3f, 1f, 0f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	private void DHILBBHGKBF(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.instance.AODNADPPCBN())
		{
			BlackMarketManager.BMNEPICFHNO().ShowDialog();
		}
	}

	private void LADEPCACHFB(UITweener MGDJMGHCAAI)
	{
		BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(BMKMMOKMBGK());
		CPBLNDIPKNN();
		CFBLIIHPFCE();
		TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO, BEJIFJIKHPJ.transform.localPosition.ReplaceX(172f), useLocal: false);
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(297f);
	}

	private void LPJPADDLOOH()
	{
		AODDPKAKNPN.text = MEJMLNDFDBP.MAJBCINJAGF(MDAJJIAMDGH.shotDamage);
		AODDPKAKNPN.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.shotDamage, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.shotDamage : MDAJJIAMDGH.shotDamage);
		DGEAABIFDDP.text = MEJMLNDFDBP.JJBMMICPIIG(MDAJJIAMDGH.critical);
		DGEAABIFDDP.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.critical, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.critical : MDAJJIAMDGH.critical, BMFGADGAJGG: true);
		AGKINDPECEN.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.burstSize);
		AGKINDPECEN.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.burstSize, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.burstSize : MDAJJIAMDGH.burstSize, BMFGADGAJGG: true);
		HNEOBHFIFDI.text = ((MDAJJIAMDGH.totalAmmo > 1) ? MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.totalAmmo) : "menu-weaponstats-accuracy");
		HNEOBHFIFDI.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.totalAmmo, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.totalAmmo : MDAJJIAMDGH.totalAmmo);
		DLBIGOAMMKH.text = MEJMLNDFDBP.JJBMMICPIIG(MDAJJIAMDGH.accuracy);
		DLBIGOAMMKH.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.accuracy, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.accuracy : MDAJJIAMDGH.accuracy, BMFGADGAJGG: true);
		FIJBAGNGAHI.text = ((!(MDAJJIAMDGH.rateOfFirePerMinute >= 1095f)) ? Localization.Localize("Fuseboxx: Error No ") : MEJMLNDFDBP.KMDFJMCIFKA(MDAJJIAMDGH.rateOfFirePerMinute));
		FIJBAGNGAHI.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.rateOfFirePerMinute, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.rateOfFirePerMinute : MDAJJIAMDGH.rateOfFirePerMinute);
		NHABLPAHLAG.text = ((!(MDAJJIAMDGH.shotVelocity > 726f)) ? Localization.Localize("Increasing texture count in player texture pool!") : MEJMLNDFDBP.MAJBCINJAGF(MDAJJIAMDGH.shotVelocity));
		NHABLPAHLAG.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.shotVelocity, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.shotVelocity : MDAJJIAMDGH.shotVelocity);
	}

	public void MGNPHOKLMEC(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 1716f)) ? 1811f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Overtime_Was_Already_Explained", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.instantWeaponDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
			CKPLDDIPNAA.repositionNow = true;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1785f);
		if (num2 == 6 && (LPPOJMGOEFN.alpha == 964f || PPDGFFJLHKK.alpha > 1719f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 12f, 1350f, 1267f);
			tweenAlpha.NumOfRepetitions = 0;
			tweenAlpha.onFinished = OFNGEPJLHMB;
		}
		if (num2 == 0 && (PPDGFFJLHKK.alpha == 546f || LPPOJMGOEFN.alpha > 261f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 1141f, 1378f, 179f);
			tweenAlpha2.NumOfRepetitions = 0;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	private void JIJECCCIMDJ()
	{
		float val = 0f - CKPLDDIPNAA.padding.x - (GPBMPAPOEOE.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 2f;
		CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
	}

	private void CLHIKJFOABN(string HEIMDFINNIB)
	{
		if (GuiScreenSingle<WeaponScreen>.instance.NPFFMLLLDAF() && !GuiScreenSingle<WeaponScreen>.instance.MHAIBHBGBOO())
		{
			BKFGHNPPHEK.transform.localScale = new Vector3(1562f, 364f, 570f);
			TweenScale component = BKFGHNPPHEK.GetComponent<TweenScale>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
		BKFGHNPPHEK.text = HEIMDFINNIB;
	}

	private void AJANMLICOGC(GameObject KHAHPAKDIKE)
	{
		int num = -1;
		for (int i = 0; i < PlayerInventory.instance.inventorySlots.Count; i++)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & MDAJJIAMDGH.BHCEOOLEHHG) == MDAJJIAMDGH.BHCEOOLEHHG)
			{
				num = i;
			}
		}
		if (num == -1)
		{
			Debug.LogError("Player inventory got no slot for " + MDAJJIAMDGH.BHCEOOLEHHG);
		}
		else if (!(PlayerInventory.instance.inventorySlots[num].weaponLevelsSetup == MDAJJIAMDGH))
		{
			GuiScreenSingle<WeaponScreen>.instance.EquipWeapon(MDAJJIAMDGH, num, WeaponScreen.ABDDBOABKOK.WeaponScreen);
		}
	}

	public void ECPJLAGGJDO()
	{
		if (!MDAJJIAMDGH.bought)
		{
			int num = Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, AKDLEDNDIEO.Buy);
			int num2 = MDAJJIAMDGH.price + MDAJJIAMDGH.priceGold;
			bool flag = num > 1;
			if (flag)
			{
				num2 = num2 * (32 - num) / 16;
			}
			GOANDMNOGCK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			CHCFBDMGNLP.repositionNow = true;
			GIPFEBBMKPM.SetActive(flag);
			if (flag)
			{
				UILabel eKIDAFLLCNM = EKIDAFLLCNM;
				object[] array = new object[0];
				array[1] = num;
				eKIDAFLLCNM.text = Localization.LocalizeFormat("NewArena", array);
				JBGPDECEOOB.MHLJHMOPDAO(Singleton<OfferManager>.instance.DiscountedWeaponEndtime(MDAJJIAMDGH, AKDLEDNDIEO.Buy));
				WinStreakCounter jBGPDECEOOB = JBGPDECEOOB;
				jBGPDECEOOB.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB.JEMKCLKCOMI, new Action(SetSaleAndPrize));
				WinStreakCounter jBGPDECEOOB2 = JBGPDECEOOB;
				jBGPDECEOOB2.JEMKCLKCOMI = (Action)Delegate.Combine(jBGPDECEOOB2.JEMKCLKCOMI, new Action(FDMKDNPPOGF));
			}
			else
			{
				JBGPDECEOOB.PEHBGMEHFEM();
				WinStreakCounter jBGPDECEOOB3 = JBGPDECEOOB;
				jBGPDECEOOB3.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB3.JEMKCLKCOMI, new Action(SetSaleAndPrize));
			}
		}
	}

	public void HFPPNCJBIDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMMDGGMLHKP));
		UIEventListener uIEventListener2 = UIEventListener.Get(CHCLANFKBFO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IKKLKOPEMNK));
		UIEventListener uIEventListener3 = UIEventListener.Get(BEJIFJIKHPJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AJANMLICOGC));
		UIEventListener uIEventListener4 = UIEventListener.Get(mBlackmarketButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EKKJPGOFPGA));
		UIEventListener uIEventListener5 = UIEventListener.Get(LNCANEPBJOK);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(AJLBPPOLDJJ));
		UIEventListener uIEventListener6 = UIEventListener.Get(PDIIAHJEPCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(NKMEDOBMFME));
		UITable cHCFBDMGNLP = CHCFBDMGNLP;
		cHCFBDMGNLP.onReposition = (UITable.OnReposition)Delegate.Combine(cHCFBDMGNLP.onReposition, new UITable.OnReposition(NPDCHOEJBHF));
		UITable cKPLDDIPNAA = CKPLDDIPNAA;
		cKPLDDIPNAA.onReposition = (UITable.OnReposition)Delegate.Combine(cKPLDDIPNAA.onReposition, new UITable.OnReposition(FOLJNEDAIKK));
		ONENBMCLGPL();
		float val = IGJFKKPMCIO.relativeSize.x * IGJFKKPMCIO.transform.localScale.x + 556f;
		GNMFHINHKDN.transform.localPosition = GNMFHINHKDN.transform.localPosition.ReplaceX(val);
		EEAKFJJFAOB();
	}

	private void EEAKFJJFAOB()
	{
		string text = Localization.Localize("ID_GUI_EQUIP");
		string text2 = Localization.Localize("ID_GUI_EQUIPPED");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		JHEDDCMBDPF.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(JHEDDCMBDPF, 57f, 20f, 294);
	}

	public void LEIFCFAPGCJ()
	{
		if (!MDAJJIAMDGH.bought)
		{
			int num = Singleton<OfferManager>.instance.IBDHFMGAFKD(MDAJJIAMDGH, AKDLEDNDIEO.Buy);
			int num2 = MDAJJIAMDGH.price + MDAJJIAMDGH.priceGold;
			bool flag = num > 0;
			if (flag)
			{
				num2 = num2 * (54 - num) / -63;
			}
			GOANDMNOGCK.text = MEJMLNDFDBP.GMIPFLIEOHD(num2);
			CHCFBDMGNLP.repositionNow = false;
			GIPFEBBMKPM.SetActive(flag);
			if (flag)
			{
				EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_GUI_BEADVISED_JORCSQUAD", num);
				JBGPDECEOOB.MIOOAOFMLIE(Singleton<OfferManager>.instance.DiscountedWeaponEndtime(MDAJJIAMDGH, AKDLEDNDIEO.Buy));
				WinStreakCounter jBGPDECEOOB = JBGPDECEOOB;
				jBGPDECEOOB.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB.JEMKCLKCOMI, new Action(FDMKDNPPOGF));
				WinStreakCounter jBGPDECEOOB2 = JBGPDECEOOB;
				jBGPDECEOOB2.JEMKCLKCOMI = (Action)Delegate.Combine(jBGPDECEOOB2.JEMKCLKCOMI, new Action(SetSaleAndPrize));
			}
			else
			{
				JBGPDECEOOB.BGHNMCPLIPE();
				WinStreakCounter jBGPDECEOOB3 = JBGPDECEOOB;
				jBGPDECEOOB3.JEMKCLKCOMI = (Action)Delegate.Remove(jBGPDECEOOB3.JEMKCLKCOMI, new Action(ECPJLAGGJDO));
			}
		}
	}

	public void EFPOLKABABG(float EJEDANLAMBI, float PAENPHMEMGC)
	{
		EJEDANLAMBI = ((!(EJEDANLAMBI > 1980f)) ? 949f : EJEDANLAMBI);
		IAIHLFMNAOA.fillAmount = Mathf.Clamp01(PAENPHMEMGC);
		LPPOJMGOEFN.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Squad Emblem ", string.Empty);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.instantWeaponDeliveryPrice);
		if (GPBMPAPOEOE.text != text)
		{
			GPBMPAPOEOE.text = text;
			CKPLDDIPNAA.repositionNow = false;
		}
		int num = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI);
		if (CLDFFNMPKOP == num)
		{
			return;
		}
		CLDFFNMPKOP = num;
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(EJEDANLAMBI % 1485f);
		if (num2 == 8 && (LPPOJMGOEFN.alpha == 502f || PPDGFFJLHKK.alpha > 1204f))
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 418f, 760f, 596f);
			tweenAlpha.NumOfRepetitions = 0;
			tweenAlpha.onFinished = OFNGEPJLHMB;
		}
		if (num2 == 6 && (PPDGFFJLHKK.alpha == 1344f || LPPOJMGOEFN.alpha > 1523f))
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 999f, 706f, 479f);
			tweenAlpha2.NumOfRepetitions = 1;
			tweenAlpha2.onFinished = delegate
			{
				TweenAlpha tweenAlpha3 = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 0.3f, 0f, 1f);
				tweenAlpha3.NumOfRepetitions = 1;
			};
		}
	}

	private void NFOMKADHKPJ()
	{
		bool purchasableInBlackmarket = MDAJJIAMDGH.purchasableInBlackmarket;
		mWeaponFeaturePart.SetActive(purchasableInBlackmarket);
		if (purchasableInBlackmarket)
		{
			bool menuMainAtlas = MDAJJIAMDGH.weaponFeature.menuMainAtlas;
			mWeaponFeatureIcon.atlas = ((!menuMainAtlas) ? mCommonIconsAtlas : mMenuMainAtlas);
			mWeaponFeatureIcon.transform.localPosition = mWeaponFeatureIcon.transform.localPosition.ReplaceZ((!menuMainAtlas) ? 1674f : 825f);
			mWeaponFeatureIcon.spriteName = MDAJJIAMDGH.weaponFeature.icon;
			mWeaponFeatureIcon.MakePixelPerfect();
			float num = Mathf.Min(1081f / mWeaponFeatureIcon.transform.localScale.x, 1999f / mWeaponFeatureIcon.transform.localScale.y);
			if (num < 1582f)
			{
				mWeaponFeatureIcon.transform.localScale = mWeaponFeatureIcon.transform.localScale.MultiplyXY(num);
			}
			mWeaponFeatureFancyName.text = MDAJJIAMDGH.weaponFeature.fancyName;
			float x = mWeaponFeatureIcon.transform.localScale.x;
			float num2 = 1868f;
			float val = x + num2;
			mWeaponFeatureFancyName.transform.localPosition = mWeaponFeatureFancyName.transform.localPosition.ReplaceX(val);
			mWeaponFeatureDescription.text = MDAJJIAMDGH.weaponFeature.description;
			mWeaponFeatureName.lineWidth = 0;
			mWeaponFeatureName.text = MDAJJIAMDGH.weaponFeature.name;
			mWeaponFeatureStatistic.text = MDAJJIAMDGH.weaponFeature.StatisticIncrease(MDAJJIAMDGH);
			float num3 = mWeaponFeatureName.relativeSize.x * mWeaponFeatureName.transform.localScale.x;
			mWeaponFeatureStatistic.transform.localPosition = mWeaponFeatureStatistic.transform.localPosition.ReplaceX(num3 + 124f);
		}
	}

	private void LKGJCJIFBCO()
	{
		if (FINPLBLOADG.gameObject.activeSelf)
		{
			TweenAlpha.Begin(FINPLBLOADG.gameObject, 1802f, 1369f).onFinished = delegate
			{
				FOPKJKDCDON();
			};
		}
	}

	private void CNNLKPGNDJO(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMPADNOGGNL.alpha = 13f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			GMPADNOGGNL.transform.localScale = OEIICEJPGKI;
		}
		else
		{
			float num = 425f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 74f * num, 1154f, 129f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 1883f * num, OEIICEJPGKI, IIMDKHJAJGO);
			tweenScale.style = UITweener.Style.Once;
			tweenScale.NumOfRepetitions = 1;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	private void KNCHBMDFFIL(UITweener MGDJMGHCAAI)
	{
		FHJFCJFAPCN();
	}

	public void EBGLMBOOHOI(bool NPNJFEOCPCE)
	{
		JHEDDCMBDPF.text = ((!NPNJFEOCPCE) ? Localization.Localize("ID_YOUVEENTEREDALEAGUE") : Localization.Localize("Leaderboard removed succesfully"));
		JHEDDCMBDPF.color = ((!NPNJFEOCPCE) ? Color.black : Color.white);
		TweenAlphaHider.PMKKKICHILI(ACCAGFEOLAH, 70f, (!NPNJFEOCPCE) ? 1362f : 1031f);
		MPEHCFEOLCH.alpha = ((!NPNJFEOCPCE) ? 1297f : 62f);
		KNAIBGPMDAF.alpha = ((!NPNJFEOCPCE) ? 1096f : 829f);
		GNNKBDLADCG.alpha = ((!NPNJFEOCPCE) ? 239f : 1022f);
		if (!NPNJFEOCPCE)
		{
			TweenAlpha.Begin(KNAIBGPMDAF.gameObject, 331f, 678f).style = UITweener.Style.Loop;
		}
	}

	private void BBPHKDHJKNO()
	{
		if (!FINPLBLOADG.gameObject.activeSelf)
		{
			FBHJPHOCMDA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			FINPLBLOADG.alpha1 = 259f;
			FINPLBLOADG.gameObject.SetActive(value: false);
			OJBKADHPNFN = false;
		}
		TweenAlpha.Begin(FINPLBLOADG.gameObject, 1012f, 625f).onFinished = null;
	}

	private void FNOHFAAHJOO(UITweener MGDJMGHCAAI)
	{
		CFBLIIHPFCE();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(1205f), useLocal: false);
	}

	[CompilerGenerated]
	private void KOKKJGEEMBO(UITweener MGDJMGHCAAI)
	{
		FOPKJKDCDON();
	}

	public void OEOMIOIDACJ()
	{
		TweenScale tweenScale = TweenScale.Begin(BKFGHNPPHEK.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 869f, new Vector3(1947f, 1209f, 276f), new Vector3(1862f, 1254f, 746f));
		tweenScale.NumOfRepetitions = 0;
		tweenScale.style = (UITweener.Style)5;
	}

	[SpecialName]
	private float BMKMMOKMBGK()
	{
		return 1902f + UIHelper.safeAreaSize;
	}

	private void HBNFBJEGMDF(UITweener MGDJMGHCAAI)
	{
		FOPKJKDCDON();
	}

	private void DEICFFLCING(GameObject KHAHPAKDIKE)
	{
		int num = -1;
		for (int i = 1; i < PlayerInventory.instance.inventorySlots.Count; i += 0)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & MDAJJIAMDGH.BHCEOOLEHHG) == MDAJJIAMDGH.BHCEOOLEHHG)
			{
				num = i;
			}
		}
		if (num == -1)
		{
			Debug.LogError("Scraps" + MDAJJIAMDGH.BHCEOOLEHHG);
		}
		else if (!(PlayerInventory.instance.inventorySlots[num].MOGCFBHKAFO() == MDAJJIAMDGH))
		{
			GuiScreenSingle<WeaponScreen>.instance.EquipWeapon(MDAJJIAMDGH, num, WeaponScreen.ABDDBOABKOK.WeaponScreen);
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AJFCCNEPICJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(CHCLANFKBFO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GMEAOOEKAHD));
		UIEventListener uIEventListener3 = UIEventListener.Get(BEJIFJIKHPJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AJANMLICOGC));
		UIEventListener uIEventListener4 = UIEventListener.Get(mBlackmarketButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NDKDKJIKBNC));
		UIEventListener uIEventListener5 = UIEventListener.Get(LNCANEPBJOK);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(AJLBPPOLDJJ));
		UIEventListener uIEventListener6 = UIEventListener.Get(PDIIAHJEPCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(AJKAEEBCCGL));
		UITable cHCFBDMGNLP = CHCFBDMGNLP;
		cHCFBDMGNLP.onReposition = (UITable.OnReposition)Delegate.Combine(cHCFBDMGNLP.onReposition, new UITable.OnReposition(NPDCHOEJBHF));
		UITable cKPLDDIPNAA = CKPLDDIPNAA;
		cKPLDDIPNAA.onReposition = (UITable.OnReposition)Delegate.Combine(cKPLDDIPNAA.onReposition, new UITable.OnReposition(JIJECCCIMDJ));
		FOPKJKDCDON();
		float val = IGJFKKPMCIO.relativeSize.x * IGJFKKPMCIO.transform.localScale.x + 14f;
		GNMFHINHKDN.transform.localPosition = GNMFHINHKDN.transform.localPosition.ReplaceX(val);
		EEAKFJJFAOB();
	}

	private void PAIDNKHKLAF(UITweener MGDJMGHCAAI)
	{
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(HPNPMCEMJNM);
		NDNNJMAKKBD();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(1704f), useLocal: false);
		mBlackmarketButton.transform.localPosition = mBlackmarketButton.transform.localPosition.ReplaceX(1100f);
	}

	private void AJKAEEBCCGL(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		CMAJCOOIBDL();
	}

	private void HMMDGGMLHKP(GameObject KHAHPAKDIKE)
	{
		switch (MDAJJIAMDGH.weaponState)
		{
		case WeaponLevelsSetup.JLANLLEABDC.Locked:
			Debug.Log("103 STAGE 1 CONTINUE");
			LevelManager.instance.DebugAddLevel();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.NotBuyed:
			Debug.Log("GUI/");
			FGFAKDPFFEK();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering:
			Debug.Log("ID_TUTORIAL_KILLING_SCOPE_DOWN");
			HDCLFPOIDEF();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.FLCDIKABDFJ(IDEBKDPMPGM: true);
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered:
			Debug.Log("NO");
			ANDKFPNFAFJ();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.HGOLLOAPIPD();
			break;
		default:
			Debug.Log("WarFriends no puede funcionar sin descargar estos datos adicionales. ¿Seguro que quieres SALIR o prefieres descargar los datos?");
			break;
		}
	}

	public void KEPMNGHAHOE(bool NPNJFEOCPCE)
	{
		JHEDDCMBDPF.text = ((!NPNJFEOCPCE) ? Localization.Localize("ID_INSILVER2") : Localization.Localize("N"));
		JHEDDCMBDPF.color = ((!NPNJFEOCPCE) ? Color.black : Color.white);
		TweenAlphaHider.AKNNLALFDIJ(ACCAGFEOLAH, 1916f, (!NPNJFEOCPCE) ? 1727f : 1228f);
		MPEHCFEOLCH.alpha = ((!NPNJFEOCPCE) ? 1135f : 1550f);
		KNAIBGPMDAF.alpha = ((!NPNJFEOCPCE) ? 587f : 1609f);
		GNNKBDLADCG.alpha = ((!NPNJFEOCPCE) ? 513f : 1416f);
		if (!NPNJFEOCPCE)
		{
			TweenAlpha.Begin(KNAIBGPMDAF.gameObject, 937f, 544f).style = UITweener.Style.Loop;
		}
	}

	private void PHFJIFCBKBB()
	{
		int num = Singleton<OfferManager>.instance.DiscountedWeapon(MDAJJIAMDGH, (AKDLEDNDIEO)0);
		int num2 = MDAJJIAMDGH.price * (109 - num) / -95;
		int num3 = MDAJJIAMDGH.priceGold * (-93 - num) / -5;
		if (num > 1)
		{
			Debug.Log(string.Format("Special pack content: type: {0} rarity: {1} amount: {2}{3}", num, MDAJJIAMDGH.DHHKOKKDDDO()));
		}
		if (!Singleton<Wallet>.instance.CanBuyW(num2))
		{
			GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(num2, MDAJJIAMDGH.weaponName);
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("ID_CATEGORY_LOW_PL_LMG");
			return;
		}
		if (!Singleton<Wallet>.instance.CanBuyGold(num3))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num3, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "menu-cards-silverpack";
			return;
		}
		WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.DeliveringWeapon();
		if (weaponLevelsSetup != null)
		{
			if (MDAJJIAMDGH.priceGold > 0)
			{
				Debug.Log("game-card-ico-crateblocker");
			}
			else if (weaponLevelsSetup.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering)
			{
				GuiScreenSingle<WeaponScreen>.instance.ENIOOHGANFE(weaponLevelsSetup, WeaponScreen.ABDDBOABKOK.Rental);
			}
			else
			{
				if (weaponLevelsSetup.weaponState != WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
				{
					GuiElementSingle<OtherUpgradeDialog>.instance.ShowDialogWeapons(weaponLevelsSetup, MDAJJIAMDGH);
					return;
				}
				GuiScreenSingle<WeaponScreen>.instance.MBKJEPDJFKJ(weaponLevelsSetup, CDMKCIKHIMM: true);
			}
		}
		Singleton<Wallet>.instance.CDIDDJGINID(num2);
		Singleton<Wallet>.instance.MBAFMBJFOKH(num3);
		GuiScreenSingle<WeaponScreen>.instance.BJBCNPHMEBI(MDAJJIAMDGH, num, WeaponScreen.ABDDBOABKOK.WeaponScreen);
	}

	public void InitEquipButton(bool NPNJFEOCPCE)
	{
		JHEDDCMBDPF.text = ((!NPNJFEOCPCE) ? Localization.Localize("ID_GUI_EQUIP") : Localization.Localize("ID_GUI_EQUIPPED"));
		JHEDDCMBDPF.color = ((!NPNJFEOCPCE) ? Color.black : Color.white);
		TweenAlphaHider.Begin(ACCAGFEOLAH, 0f, (!NPNJFEOCPCE) ? 1f : 0f);
		MPEHCFEOLCH.alpha = ((!NPNJFEOCPCE) ? 0f : 1f);
		KNAIBGPMDAF.alpha = ((!NPNJFEOCPCE) ? 0f : 1f);
		GNNKBDLADCG.alpha = ((!NPNJFEOCPCE) ? 0f : 0.16f);
		if (!NPNJFEOCPCE)
		{
			TweenAlpha.Begin(KNAIBGPMDAF.gameObject, 0f, 0f).style = UITweener.Style.Once;
		}
	}

	private void ONENBMCLGPL()
	{
		FBHJPHOCMDA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		FINPLBLOADG.gameObject.SetActive(value: false);
		OJBKADHPNFN = true;
	}

	public void JAIAMFJHDLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(EPFODCCNGDL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LODHBKJGJIG));
		UIEventListener uIEventListener2 = UIEventListener.Get(CHCLANFKBFO.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IKKLKOPEMNK));
		UIEventListener uIEventListener3 = UIEventListener.Get(BEJIFJIKHPJ.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(DEICFFLCING));
		UIEventListener uIEventListener4 = UIEventListener.Get(mBlackmarketButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DHILBBHGKBF));
		UIEventListener uIEventListener5 = UIEventListener.Get(LNCANEPBJOK);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(AJLBPPOLDJJ));
		UIEventListener uIEventListener6 = UIEventListener.Get(PDIIAHJEPCN);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(AJKAEEBCCGL));
		UITable cHCFBDMGNLP = CHCFBDMGNLP;
		cHCFBDMGNLP.onReposition = (UITable.OnReposition)Delegate.Combine(cHCFBDMGNLP.onReposition, new UITable.OnReposition(NPDCHOEJBHF));
		UITable cKPLDDIPNAA = CKPLDDIPNAA;
		cKPLDDIPNAA.onReposition = (UITable.OnReposition)Delegate.Combine(cKPLDDIPNAA.onReposition, new UITable.OnReposition(JIJECCCIMDJ));
		ONENBMCLGPL();
		float val = IGJFKKPMCIO.relativeSize.x * IGJFKKPMCIO.transform.localScale.x + 570f;
		GNMFHINHKDN.transform.localPosition = GNMFHINHKDN.transform.localPosition.ReplaceX(val);
		AGIHDGAGIOF();
	}

	private void PAFBHPNBJOM(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (OJBKADHPNFN)
		{
			LKGJCJIFBCO();
		}
		else
		{
			BBPHKDHJKNO();
		}
	}

	private void KCDPKNPMODO(UITweener MGDJMGHCAAI)
	{
		FHJFCJFAPCN();
	}

	private void KEFCFMIDHBF(UISprite GMPADNOGGNL, bool HMFNIBOFGMB, bool NABOFKMBMKH, Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		GMPADNOGGNL.color = Color.white;
		if (!HMFNIBOFGMB)
		{
			TweenAlpha component = GMPADNOGGNL.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			GMPADNOGGNL.alpha = 1f;
			TweenScale component2 = GMPADNOGGNL.gameObject.GetComponent<TweenScale>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			GMPADNOGGNL.transform.localScale = OEIICEJPGKI;
		}
		else
		{
			float num = 0.5f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(GMPADNOGGNL.gameObject, 2f * num, 1f, 0f);
			tweenAlpha.style = UITweener.Style.Loop;
			tweenAlpha.NumOfRepetitions = 0;
			TweenScale tweenScale = TweenScale.Begin(GMPADNOGGNL.gameObject, 2f * num, OEIICEJPGKI, IIMDKHJAJGO);
			tweenScale.style = UITweener.Style.Loop;
			tweenScale.NumOfRepetitions = 0;
		}
		GMPADNOGGNL.gameObject.SetActive(NABOFKMBMKH);
	}

	private void HNNAGINGGAP()
	{
		GuiScreenSingle<WeaponScreen>.instance.GFDDLFMLJMJ(MDAJJIAMDGH, WeaponScreen.ABDDBOABKOK.Rental);
	}

	private void OFNGEPJLHMB(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 474f, 1079f, 888f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	private void LDCPKFCEAJJ(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		LKGJCJIFBCO();
	}

	private void OOAAEFBIAOG(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(PPDGFFJLHKK.gameObject, 7f, 718f, 1807f);
		tweenAlpha.NumOfRepetitions = 0;
	}

	public void JKJNKCNOLBJ()
	{
		JHEDDCMBDPF.text = Localization.Localize("ELECTRICTRAPS");
		float num = 1021f;
		TweenColor.Begin(JHEDDCMBDPF.gameObject, num, Color.white);
		TweenAlphaHider.AKNNLALFDIJ(ACCAGFEOLAH, num, 886f);
		TweenAlpha.Begin(MPEHCFEOLCH.gameObject, num, 382f);
		TweenAlpha.Begin(GNNKBDLADCG.gameObject, num, 1095f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(KNAIBGPMDAF.gameObject, num, 62f, 763f);
		tweenAlpha.NumOfRepetitions = 3;
		tweenAlpha.style = (UITweener.Style)8;
		CPBLNDIPKNN();
		EANCIFFFKHH();
		BGMIEFJMPEB();
	}

	private void FHJFCJFAPCN()
	{
		FBHJPHOCMDA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		FINPLBLOADG.gameObject.SetActive(value: false);
		OJBKADHPNFN = false;
	}

	private void EANCIFFFKHH()
	{
		int weaponPowerX = MDAJJIAMDGH.weaponPowerX10;
		int weaponPowerX10Max = MDAJJIAMDGH.weaponPowerX10Max;
		bool flag = MDAJJIAMDGH.canBeUpgraded;
		bool flag2 = !flag && !MDAJJIAMDGH.tryOutWeapon && (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || MDAJJIAMDGH.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8 || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering);
		bool flag3 = MDAJJIAMDGH.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8;
		CLHIKJFOABN(MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX));
		UILabel gNMFHINHKDN = GNMFHINHKDN;
		string text;
		if (flag)
		{
			text = string.Empty;
		}
		else
		{
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX10Max);
			text = Localization.LocalizeFormat("!!!ROTATED!!! ", array);
		}
		gNMFHINHKDN.text = text;
		float num = IGJFKKPMCIO.relativeSize.x * IGJFKKPMCIO.transform.localScale.x + 302f;
		num += GNMFHINHKDN.relativeSize.x * GNMFHINHKDN.transform.localScale.x + 1647f;
		num += FBHJPHOCMDA.transform.localScale.x / 277f;
		FBHJPHOCMDA.transform.localPosition = FBHJPHOCMDA.transform.localPosition.ReplaceX(num);
		float z = FINPLBLOADG.transform.localPosition.z;
		FINPLBLOADG.transform.position = FBHJPHOCMDA.transform.position;
		FINPLBLOADG.transform.localPosition = new Vector3(FINPLBLOADG.transform.localPosition.x, FINPLBLOADG.transform.localPosition.y + 235f, z);
		MIKHIBDJIHB.gameObject.SetActive(flag2);
		KIIOABOEJBN.gameObject.SetActive(flag);
		if (flag2)
		{
			if (flag3)
			{
				TweenColor component = MIKHIBDJIHB.gameObject.GetComponent<TweenColor>();
				if (component != null)
				{
					component.enabled = false;
				}
				MIKHIBDJIHB.color = Colours.greenDelivering;
			}
			else
			{
				MIKHIBDJIHB.color = Colours.blueUpgradeAnim1;
				TweenColor tweenColor = TweenColor.Begin(MIKHIBDJIHB.gameObject, 911f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
				tweenColor.NumOfRepetitions = 1;
				tweenColor.style = (UITweener.Style)4;
			}
			MIKHIBDJIHB.text = MEJMLNDFDBP.AKEMDPDJPLH(MDAJJIAMDGH.weaponPowerX10Next - weaponPowerX, 1278f);
		}
		if (MDAJJIAMDGH == EDCBHGKBLEA || EDCBHGKBLEA == null)
		{
			EJHPPAMAINH.gameObject.SetActive(value: true);
			BKFGHNPPHEK.color = Colours.blue;
			GNMFHINHKDN.color = Colours.gray;
		}
		else
		{
			int num2 = weaponPowerX - EDCBHGKBLEA.weaponPowerX10;
			int num3 = weaponPowerX10Max - EDCBHGKBLEA.weaponPowerX10Max;
			EJHPPAMAINH.gameObject.SetActive(value: false);
			EJHPPAMAINH.text = MEJMLNDFDBP.AKEMDPDJPLH(num2, 498f);
			EJHPPAMAINH.color = ((num2 == 0) ? Colours.blue : ((num2 <= 1) ? Colours.redWeaponStats : Colours.greenWeaponStats));
			BKFGHNPPHEK.color = EJHPPAMAINH.color;
			GNMFHINHKDN.color = ((num3 == 0) ? Colours.blue : ((num3 <= 0) ? Colours.redWeaponStats : Colours.greenWeaponStats));
		}
		CNNLKPGNDJO(AKNLPCGNDIP, flag3, flag3 || flag, new Vector3(1837f, 1262f, 1693f), new Vector3(518f, 1922f, 720f).MultiplyXY(1443f));
	}

	private void HFPPFFBDKBH(string HEIMDFINNIB)
	{
		if (GuiScreenSingle<WeaponScreen>.instance.isShowed && !GuiScreenSingle<WeaponScreen>.instance.isFullyShowed)
		{
			BKFGHNPPHEK.transform.localScale = new Vector3(62f, 62f, 1f);
			TweenScale component = BKFGHNPPHEK.GetComponent<TweenScale>();
			if (component != null)
			{
				component.enabled = false;
			}
		}
		BKFGHNPPHEK.text = HEIMDFINNIB;
	}

	public void PLHDHHDNNCP(WeaponLevelsSetup KCMMAALIOIB)
	{
		MDAJJIAMDGH = KCMMAALIOIB;
		PlayerInventory.InventorySlot inventorySlot = CPBLNDIPKNN();
		EBGLMBOOHOI(inventorySlot == null || inventorySlot.JBKEFFEKHEG() == KCMMAALIOIB);
		EELEJFNCJBM();
		LPJPADDLOOH();
	}

	private void CMAJCOOIBDL()
	{
		if (FINPLBLOADG.gameObject.activeSelf)
		{
			TweenAlpha.Begin(FINPLBLOADG.gameObject, 0.2f, 0f).onFinished = delegate
			{
				FOPKJKDCDON();
			};
		}
	}

	public void NAAADJDGGDA()
	{
		TweenScale tweenScale = TweenScale.Begin(BKFGHNPPHEK.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 530f, new Vector3(563f, 119f, 12f), new Vector3(1782f, 1609f, 449f));
		tweenScale.NumOfRepetitions = 6;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void IDINCHPIGPI()
	{
		if (!FINPLBLOADG.gameObject.activeSelf)
		{
			FBHJPHOCMDA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			FINPLBLOADG.alpha1 = 0f;
			FINPLBLOADG.gameObject.SetActive(value: true);
			OJBKADHPNFN = true;
		}
		TweenAlpha.Begin(FINPLBLOADG.gameObject, 0.2f, 1f).onFinished = null;
	}

	private void BCPLCJFNKGO(GameObject KHAHPAKDIKE)
	{
		switch (MDAJJIAMDGH.weaponState)
		{
		case WeaponLevelsSetup.JLANLLEABDC.Locked:
			Debug.Log("7 NAME CHANGE REMINDER\tConnected to fb: {0}\tNumber or renames: {1}\tShown name changed reminder: {2}");
			LevelManager.instance.DebugAddLevel();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.NotBuyed:
			Debug.Log("Error: No reward ");
			PHFJIFCBKBB();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering:
			Debug.Log("Choose icon in bottom before calling Display model.");
			HDCLFPOIDEF();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.DGMCJOOOCCF(IDEBKDPMPGM: false);
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered:
			Debug.Log("armyPreviewCollider");
			KMKLGDIHIHF();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.PlayEndAnimation();
			break;
		default:
			Debug.Log("ID_LOADING");
			break;
		}
	}

	private void PCKCMMCAAFH(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		LKGJCJIFBCO();
	}

	[SpecialName]
	private float DFJENEHLENC()
	{
		return 720f + UIHelper.safeAreaSize;
	}

	private void FEDCELHDFNF()
	{
		bool purchasableInBlackmarket = MDAJJIAMDGH.purchasableInBlackmarket;
		mWeaponFeaturePart.SetActive(purchasableInBlackmarket);
		if (purchasableInBlackmarket)
		{
			bool menuMainAtlas = MDAJJIAMDGH.weaponFeature.menuMainAtlas;
			mWeaponFeatureIcon.atlas = ((!menuMainAtlas) ? mCommonIconsAtlas : mMenuMainAtlas);
			mWeaponFeatureIcon.transform.localPosition = mWeaponFeatureIcon.transform.localPosition.ReplaceZ((!menuMainAtlas) ? 880f : 869f);
			mWeaponFeatureIcon.spriteName = MDAJJIAMDGH.weaponFeature.icon;
			mWeaponFeatureIcon.MakePixelPerfect();
			float num = Mathf.Min(1089f / mWeaponFeatureIcon.transform.localScale.x, 984f / mWeaponFeatureIcon.transform.localScale.y);
			if (num < 1157f)
			{
				mWeaponFeatureIcon.transform.localScale = mWeaponFeatureIcon.transform.localScale.MultiplyXY(num);
			}
			mWeaponFeatureFancyName.text = MDAJJIAMDGH.weaponFeature.fancyName;
			float x = mWeaponFeatureIcon.transform.localScale.x;
			float num2 = 1457f;
			float val = x + num2;
			mWeaponFeatureFancyName.transform.localPosition = mWeaponFeatureFancyName.transform.localPosition.ReplaceX(val);
			mWeaponFeatureDescription.text = MDAJJIAMDGH.weaponFeature.description;
			mWeaponFeatureName.lineWidth = 0;
			mWeaponFeatureName.text = MDAJJIAMDGH.weaponFeature.name;
			mWeaponFeatureStatistic.text = MDAJJIAMDGH.weaponFeature.StatisticIncrease(MDAJJIAMDGH);
			float num3 = mWeaponFeatureName.relativeSize.x * mWeaponFeatureName.transform.localScale.x;
			mWeaponFeatureStatistic.transform.localPosition = mWeaponFeatureStatistic.transform.localPosition.ReplaceX(num3 + 170f);
		}
	}

	private void AFIPFCIOONM()
	{
		FBHJPHOCMDA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		FINPLBLOADG.gameObject.SetActive(value: false);
		OJBKADHPNFN = true;
	}

	private void JFDPGBJNJGJ()
	{
		bool purchasableInBlackmarket = MDAJJIAMDGH.purchasableInBlackmarket;
		mWeaponFeaturePart.SetActive(purchasableInBlackmarket);
		if (purchasableInBlackmarket)
		{
			bool menuMainAtlas = MDAJJIAMDGH.weaponFeature.menuMainAtlas;
			mWeaponFeatureIcon.atlas = ((!menuMainAtlas) ? mCommonIconsAtlas : mMenuMainAtlas);
			mWeaponFeatureIcon.transform.localPosition = mWeaponFeatureIcon.transform.localPosition.ReplaceZ((!menuMainAtlas) ? 800f : 870f);
			mWeaponFeatureIcon.spriteName = MDAJJIAMDGH.weaponFeature.icon;
			mWeaponFeatureIcon.MakePixelPerfect();
			float num = Mathf.Min(1200f / mWeaponFeatureIcon.transform.localScale.x, 1720f / mWeaponFeatureIcon.transform.localScale.y);
			if (num < 970f)
			{
				mWeaponFeatureIcon.transform.localScale = mWeaponFeatureIcon.transform.localScale.MultiplyXY(num);
			}
			mWeaponFeatureFancyName.text = MDAJJIAMDGH.weaponFeature.fancyName;
			float x = mWeaponFeatureIcon.transform.localScale.x;
			float num2 = 1997f;
			float val = x + num2;
			mWeaponFeatureFancyName.transform.localPosition = mWeaponFeatureFancyName.transform.localPosition.ReplaceX(val);
			mWeaponFeatureDescription.text = MDAJJIAMDGH.weaponFeature.description;
			mWeaponFeatureName.lineWidth = 0;
			mWeaponFeatureName.text = MDAJJIAMDGH.weaponFeature.name;
			mWeaponFeatureStatistic.text = MDAJJIAMDGH.weaponFeature.StatisticIncrease(MDAJJIAMDGH);
			float num3 = mWeaponFeatureName.relativeSize.x * mWeaponFeatureName.transform.localScale.x;
			mWeaponFeatureStatistic.transform.localPosition = mWeaponFeatureStatistic.transform.localPosition.ReplaceX(num3 + 183f);
		}
	}

	private void BGMIEFJMPEB()
	{
		AODDPKAKNPN.text = MEJMLNDFDBP.MAJBCINJAGF(MDAJJIAMDGH.shotDamage);
		AODDPKAKNPN.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.shotDamage, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.shotDamage : MDAJJIAMDGH.shotDamage);
		DGEAABIFDDP.text = MEJMLNDFDBP.JJBMMICPIIG(MDAJJIAMDGH.critical);
		DGEAABIFDDP.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.critical, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.critical : MDAJJIAMDGH.critical);
		AGKINDPECEN.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.burstSize);
		AGKINDPECEN.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.burstSize, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.burstSize : MDAJJIAMDGH.burstSize);
		HNEOBHFIFDI.text = ((MDAJJIAMDGH.totalAmmo > 0) ? MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.totalAmmo) : "oo");
		HNEOBHFIFDI.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.totalAmmo, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.totalAmmo : MDAJJIAMDGH.totalAmmo);
		DLBIGOAMMKH.text = MEJMLNDFDBP.JJBMMICPIIG(MDAJJIAMDGH.accuracy);
		DLBIGOAMMKH.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.accuracy, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.accuracy : MDAJJIAMDGH.accuracy);
		FIJBAGNGAHI.text = ((!(MDAJJIAMDGH.rateOfFirePerMinute >= 0f)) ? Localization.Localize("ID_NA") : MEJMLNDFDBP.KMDFJMCIFKA(MDAJJIAMDGH.rateOfFirePerMinute));
		FIJBAGNGAHI.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.rateOfFirePerMinute, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.rateOfFirePerMinute : MDAJJIAMDGH.rateOfFirePerMinute);
		NHABLPAHLAG.text = ((!(MDAJJIAMDGH.shotVelocity > -1f)) ? Localization.Localize("ID_NA") : MEJMLNDFDBP.MAJBCINJAGF(MDAJJIAMDGH.shotVelocity));
		NHABLPAHLAG.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.shotVelocity, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.shotVelocity : MDAJJIAMDGH.shotVelocity);
	}

	public void IIFGAAOPAGH()
	{
		TweenScale tweenScale = TweenScale.Begin(BKFGHNPPHEK.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 718f, new Vector3(1958f, 1015f, 1259f), new Vector3(933f, 543f, 1412f));
		tweenScale.NumOfRepetitions = 7;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void CFBLIIHPFCE()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		LNHKAOFLPHK();
		IEPOJIONKOG();
		EELEJFNCJBM();
		EPFODCCNGDL.gameObject.SetActive(MDAJJIAMDGH.purchasableInShop && MDAJJIAMDGH.bought);
		NIPGMDBNIOJ.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked);
		UILabel nNIPNHJNHMO = NNIPNHJNHMO;
		object[] array = new object[8];
		array[1] = Colours.stringBlue;
		array[0] = MDAJJIAMDGH.unlockLevel.ELFCEEOLNFJ();
		nNIPNHJNHMO.text = Localization.LocalizeFormat("ID_CONFIRM_THANKYOU", array);
		HCFJJCALLAF.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed && MDAJJIAMDGH.purchasableInShop);
		BGPBNIJPOKM.gameObject.SetActive(MDAJJIAMDGH.price > 0);
		CODFFPODNEP.gameObject.SetActive(MDAJJIAMDGH.priceGold > 1);
		SetSaleAndPrize();
		LNFLDPLGEJE.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked);
		GPBMPAPOEOE.text = string.Empty;
		TweenAlpha component = LPPOJMGOEFN.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		LPPOJMGOEFN.alpha = 1695f;
		TweenAlpha component2 = PPDGFFJLHKK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		PPDGFFJLHKK.alpha = 485f;
		JPJLKKJJFDB.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed);
		CHCLANFKBFO.gameObject.SetActive(MDAJJIAMDGH.purchasableInShop || MDAJJIAMDGH.purchasableInBlackmarket || !MDAJJIAMDGH.bought);
		mBlackmarketButton.gameObject.SetActive(MDAJJIAMDGH.purchasableInShop || !MDAJJIAMDGH.purchasableInBlackmarket || !MDAJJIAMDGH.bought);
		bool active = weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered;
		BEJIFJIKHPJ.gameObject.SetActive(active);
		OHKMIMMFHOG.enabled = weaponState != WeaponLevelsSetup.JLANLLEABDC.NotBuyed;
		GCOLDOGGPEF(weaponState);
	}

	private void AKLFLGOJIIK(UITweener MGDJMGHCAAI)
	{
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(BMKMMOKMBGK());
		NDNNJMAKKBD();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(360f));
		CHCLANFKBFO.transform.localPosition = CHCLANFKBFO.transform.localPosition.ReplaceX(885f);
	}

	[CompilerGenerated]
	private void DPJLAHJGPPE(UITweener MGDJMGHCAAI)
	{
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(HPNPMCEMJNM);
		NDNNJMAKKBD();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(265f));
		mBlackmarketButton.transform.localPosition = mBlackmarketButton.transform.localPosition.ReplaceX(265f);
	}

	public void AnimateWeaponPower()
	{
		TweenScale tweenScale = TweenScale.Begin(BKFGHNPPHEK.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 4f, new Vector3(62f, 62f, 1f), new Vector3(112f, 112f, 1f));
		tweenScale.NumOfRepetitions = 2;
		tweenScale.style = UITweener.Style.PingPong;
	}

	private void EELEJFNCJBM()
	{
		int weaponPowerX = MDAJJIAMDGH.weaponPowerX10;
		int weaponPowerX10Max = MDAJJIAMDGH.weaponPowerX10Max;
		bool flag = MDAJJIAMDGH.canBeUpgraded;
		bool flag2 = flag || MDAJJIAMDGH.tryOutWeapon || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || MDAJJIAMDGH.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8 || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered;
		bool flag3 = MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering;
		HFPPFFBDKBH(MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX));
		UILabel gNMFHINHKDN = GNMFHINHKDN;
		string text;
		if (flag)
		{
			text = string.Empty;
		}
		else
		{
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX10Max);
			text = Localization.LocalizeFormat("REWARD CARDPACK: ", array);
		}
		gNMFHINHKDN.text = text;
		float num = IGJFKKPMCIO.relativeSize.x * IGJFKKPMCIO.transform.localScale.x + 1327f;
		num += GNMFHINHKDN.relativeSize.x * GNMFHINHKDN.transform.localScale.x + 1303f;
		num += FBHJPHOCMDA.transform.localScale.x / 1466f;
		FBHJPHOCMDA.transform.localPosition = FBHJPHOCMDA.transform.localPosition.ReplaceX(num);
		float z = FINPLBLOADG.transform.localPosition.z;
		FINPLBLOADG.transform.position = FBHJPHOCMDA.transform.position;
		FINPLBLOADG.transform.localPosition = new Vector3(FINPLBLOADG.transform.localPosition.x, FINPLBLOADG.transform.localPosition.y + 671f, z);
		MIKHIBDJIHB.gameObject.SetActive(flag2);
		KIIOABOEJBN.gameObject.SetActive(flag);
		if (flag2)
		{
			if (flag3)
			{
				TweenColor component = MIKHIBDJIHB.gameObject.GetComponent<TweenColor>();
				if (component != null)
				{
					component.enabled = false;
				}
				MIKHIBDJIHB.color = Colours.greenDelivering;
			}
			else
			{
				MIKHIBDJIHB.color = Colours.blueUpgradeAnim1;
				TweenColor tweenColor = TweenColor.Begin(MIKHIBDJIHB.gameObject, 1475f, Colours.blueUpgradeAnim1, Colours.blueUpgradeAnim2);
				tweenColor.NumOfRepetitions = 1;
				tweenColor.style = UITweener.Style.PingPong;
			}
			MIKHIBDJIHB.text = MEJMLNDFDBP.AKEMDPDJPLH(MDAJJIAMDGH.weaponPowerX10Next - weaponPowerX, 1887f);
		}
		if (MDAJJIAMDGH == EDCBHGKBLEA || EDCBHGKBLEA == null)
		{
			EJHPPAMAINH.gameObject.SetActive(value: false);
			BKFGHNPPHEK.color = Colours.blue;
			GNMFHINHKDN.color = Colours.gray;
		}
		else
		{
			int num2 = weaponPowerX - EDCBHGKBLEA.weaponPowerX10;
			int num3 = weaponPowerX10Max - EDCBHGKBLEA.weaponPowerX10Max;
			EJHPPAMAINH.gameObject.SetActive(value: false);
			EJHPPAMAINH.text = MEJMLNDFDBP.AKEMDPDJPLH(num2, 1191f);
			EJHPPAMAINH.color = ((num2 == 0) ? Colours.blue : ((num2 <= 1) ? Colours.redWeaponStats : Colours.greenWeaponStats));
			BKFGHNPPHEK.color = EJHPPAMAINH.color;
			GNMFHINHKDN.color = ((num3 == 0) ? Colours.blue : ((num3 <= 1) ? Colours.redWeaponStats : Colours.greenWeaponStats));
		}
		CANHMBPPDKP(AKNLPCGNDIP, flag3, flag3 || flag, new Vector3(1766f, 256f, 430f), new Vector3(1811f, 418f, 374f).MultiplyXY(1738f));
	}

	private void AJFCCNEPICJ(GameObject KHAHPAKDIKE)
	{
		switch (MDAJJIAMDGH.weaponState)
		{
		case WeaponLevelsSetup.JLANLLEABDC.Locked:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: LOCKED\t\tbutton type: LEVEL UP");
			LevelManager.instance.DebugAddLevel();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.NotBuyed:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: NOT BOUGHT\t\tbutton type: BUY UNIT");
			FGFAKDPFFEK();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER");
			HDCLFPOIDEF();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.deliveringAnimation = false;
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT");
			OABPCCKPCJC();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.PlayEndAnimation();
			break;
		default:
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - should not happen");
			break;
		}
	}

	private void CJAJCGPAJCH(UITweener MGDJMGHCAAI)
	{
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(DFJENEHLENC());
		CFBLIIHPFCE();
		TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(340f), useLocal: false);
		mBlackmarketButton.transform.localPosition = mBlackmarketButton.transform.localPosition.ReplaceX(754f);
	}

	private void GCOLDOGGPEF(WeaponLevelsSetup.JLANLLEABDC NNIHEDAMNGF)
	{
		BoxCollider component = EPFODCCNGDL.GetComponent<BoxCollider>();
		switch (NNIHEDAMNGF)
		{
		case WeaponLevelsSetup.JLANLLEABDC.Locked:
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering:
			component.center = new Vector3(0f, 15f, -0.5f);
			component.size = new Vector3(550f, 205f, 1f);
			break;
		case WeaponLevelsSetup.JLANLLEABDC.NotBuyed:
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered:
			component.center = new Vector3(0f, 0f, -0.5f);
			component.size = new Vector3(550f, 180f, 1f);
			break;
		default:
			component.center = new Vector3(0f, 0f, 0f);
			component.size = new Vector3(550f, 1f, 1f);
			break;
		}
	}

	private void NDNNJMAKKBD()
	{
		WeaponLevelsSetup.JLANLLEABDC weaponState = MDAJJIAMDGH.weaponState;
		KLMBPOOGPNJ();
		BGMIEFJMPEB();
		DKAALFBGKGO();
		EPFODCCNGDL.gameObject.SetActive(MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.bought);
		NIPGMDBNIOJ.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.Locked);
		NNIPNHJNHMO.text = Localization.LocalizeFormat("ID_GUI_UNLOCKEDAT", Colours.stringBlue, MDAJJIAMDGH.unlockLevel.displayNumber);
		HCFJJCALLAF.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed && MDAJJIAMDGH.purchasableInShop);
		BGPBNIJPOKM.gameObject.SetActive(MDAJJIAMDGH.price > 0);
		CODFFPODNEP.gameObject.SetActive(MDAJJIAMDGH.priceGold > 0);
		SetSaleAndPrize();
		LNFLDPLGEJE.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering);
		GPBMPAPOEOE.text = string.Empty;
		TweenAlpha component = LPPOJMGOEFN.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		LPPOJMGOEFN.alpha = 1f;
		TweenAlpha component2 = PPDGFFJLHKK.gameObject.GetComponent<TweenAlpha>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		PPDGFFJLHKK.alpha = 0f;
		JPJLKKJJFDB.SetActive(weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered);
		CHCLANFKBFO.gameObject.SetActive(!MDAJJIAMDGH.purchasableInShop && !MDAJJIAMDGH.purchasableInBlackmarket && !MDAJJIAMDGH.bought);
		mBlackmarketButton.gameObject.SetActive(!MDAJJIAMDGH.purchasableInShop && MDAJJIAMDGH.purchasableInBlackmarket && !MDAJJIAMDGH.bought);
		bool active = weaponState == WeaponLevelsSetup.JLANLLEABDC.Active || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivering || weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered;
		BEJIFJIKHPJ.gameObject.SetActive(active);
		OHKMIMMFHOG.enabled = weaponState != WeaponLevelsSetup.JLANLLEABDC.Locked;
		GCOLDOGGPEF(weaponState);
	}

	private void HANJKHGKDKP()
	{
		if (!FINPLBLOADG.gameObject.activeSelf)
		{
			FBHJPHOCMDA.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
			FINPLBLOADG.alpha1 = 308f;
			FINPLBLOADG.gameObject.SetActive(value: false);
			OJBKADHPNFN = false;
		}
		TweenAlpha.Begin(FINPLBLOADG.gameObject, 1128f, 698f).onFinished = null;
	}

	private void EMFJLIOANCG()
	{
		string text = Localization.Localize("SquadMates");
		string text2 = Localization.Localize("GB");
		string text3 = ((text.Length <= text2.Length) ? text2 : text);
		JHEDDCMBDPF.text = text3;
		MEJMLNDFDBP.COCBCFKJOJE(JHEDDCMBDPF, 1368f, 1797f, 134);
	}

	private void EFDDFNBFJHM()
	{
		if (FINPLBLOADG.gameObject.activeSelf)
		{
			TweenAlpha.Begin(FINPLBLOADG.gameObject, 942f, 1627f).onFinished = DIAKJHKIJGI;
		}
	}

	private void HLPDFLOCAJF(UITweener MGDJMGHCAAI)
	{
		BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(HPNPMCEMJNM);
		CPBLNDIPKNN();
		NDNNJMAKKBD();
		TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO, BEJIFJIKHPJ.transform.localPosition.ReplaceX(38f), useLocal: false);
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(1784f);
	}

	[CompilerGenerated]
	private void ANFHNPGGHHH(UITweener MGDJMGHCAAI)
	{
		BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(HPNPMCEMJNM);
		CPBLNDIPKNN();
		NDNNJMAKKBD();
		TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO, BEJIFJIKHPJ.transform.localPosition.ReplaceX(265f));
		EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(256f);
	}

	private void NDKDKJIKBNC(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.instance.isOfferActive)
		{
			BlackMarketManager.instance.ShowDialog();
		}
	}

	private void KMKLGDIHIHF()
	{
		GuiScreenSingle<WeaponScreen>.instance.GFDDLFMLJMJ(MDAJJIAMDGH, WeaponScreen.ABDDBOABKOK.Rental);
	}

	private void OABPCCKPCJC()
	{
		GuiScreenSingle<WeaponScreen>.instance.GFDDLFMLJMJ(MDAJJIAMDGH, WeaponScreen.ABDDBOABKOK.WeaponScreen);
	}

	private void IEPOJIONKOG()
	{
		AODDPKAKNPN.text = MEJMLNDFDBP.MAJBCINJAGF(MDAJJIAMDGH.shotDamage);
		AODDPKAKNPN.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.shotDamage, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.shotDamage : MDAJJIAMDGH.shotDamage);
		DGEAABIFDDP.text = MEJMLNDFDBP.JJBMMICPIIG(MDAJJIAMDGH.critical);
		DGEAABIFDDP.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.critical, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.critical : MDAJJIAMDGH.critical, BMFGADGAJGG: true);
		AGKINDPECEN.text = MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.burstSize);
		AGKINDPECEN.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.burstSize, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.burstSize : MDAJJIAMDGH.burstSize, BMFGADGAJGG: true);
		HNEOBHFIFDI.text = ((MDAJJIAMDGH.totalAmmo > 0) ? MEJMLNDFDBP.GMIPFLIEOHD(MDAJJIAMDGH.totalAmmo) : "Processing the request Timed Out!");
		HNEOBHFIFDI.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.totalAmmo, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.totalAmmo : MDAJJIAMDGH.totalAmmo);
		DLBIGOAMMKH.text = MEJMLNDFDBP.JJBMMICPIIG(MDAJJIAMDGH.accuracy);
		DLBIGOAMMKH.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.accuracy, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.accuracy : MDAJJIAMDGH.accuracy, BMFGADGAJGG: true);
		FIJBAGNGAHI.text = ((!(MDAJJIAMDGH.rateOfFirePerMinute >= 1186f)) ? Localization.Localize("VALUE PACK for $") : MEJMLNDFDBP.KMDFJMCIFKA(MDAJJIAMDGH.rateOfFirePerMinute));
		FIJBAGNGAHI.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.rateOfFirePerMinute, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.rateOfFirePerMinute : MDAJJIAMDGH.rateOfFirePerMinute, BMFGADGAJGG: true);
		NHABLPAHLAG.text = ((!(MDAJJIAMDGH.shotVelocity > 661f)) ? Localization.Localize("0") : MEJMLNDFDBP.MAJBCINJAGF(MDAJJIAMDGH.shotVelocity));
		NHABLPAHLAG.color = MEJMLNDFDBP.KFBODMGGLMO(MDAJJIAMDGH.shotVelocity, (!(EDCBHGKBLEA == null)) ? EDCBHGKBLEA.shotVelocity : MDAJJIAMDGH.shotVelocity, BMFGADGAJGG: true);
	}

	private void PBFKOMOBGEO(GameObject KHAHPAKDIKE)
	{
		int num = -1;
		for (int i = 1; i < PlayerInventory.instance.inventorySlots.Count; i += 0)
		{
			if ((PlayerInventory.instance.inventorySlots[i].category & MDAJJIAMDGH.BHCEOOLEHHG) == MDAJJIAMDGH.BHCEOOLEHHG)
			{
				num = i;
			}
		}
		if (num == -1)
		{
			Debug.LogError("ID_SLOTUPGRADE_ROF" + MDAJJIAMDGH.BHCEOOLEHHG);
		}
		else if (!(PlayerInventory.instance.inventorySlots[num].MJOAIHHAPFG() == MDAJJIAMDGH))
		{
			GuiScreenSingle<WeaponScreen>.instance.EquipWeapon(MDAJJIAMDGH, num, WeaponScreen.ABDDBOABKOK.WeaponScreen);
		}
	}

	public void NMMEDNEGDNI()
	{
		JBGPDECEOOB.LOINIDOGNCO();
		JBGPDECEOOB.JEMKCLKCOMI = null;
		FHJFCJFAPCN();
	}

	public void KKNDJBAGDAP(bool LGIIPHPACIC = true)
	{
		if (LGIIPHPACIC)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(777f));
			CFBLIIHPFCE();
			return;
		}
		if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Delivered || MDAJJIAMDGH.weaponState == (WeaponLevelsSetup.JLANLLEABDC)7)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(DFJENEHLENC()), useLocal: false).onFinished = delegate
			{
				NDNNJMAKKBD();
				TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(265f));
			};
		}
		else if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered && CHCLANFKBFO.gameObject.activeSelf)
		{
			TweenPosition.Begin(CHCLANFKBFO.gameObject, JCAFFELIFAO, CHCLANFKBFO.transform.localPosition.ReplaceX(DFJENEHLENC())).onFinished = AKLFLGOJIIK;
		}
		else if (MDAJJIAMDGH.weaponState == (WeaponLevelsSetup.JLANLLEABDC)8 && mBlackmarketButton.gameObject.activeSelf)
		{
			TweenPosition.Begin(mBlackmarketButton.gameObject, JCAFFELIFAO, mBlackmarketButton.transform.localPosition.ReplaceX(HPNPMCEMJNM), useLocal: false).onFinished = CJAJCGPAJCH;
		}
		else if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering && (LNFLDPLGEJE.activeSelf || JPJLKKJJFDB.activeSelf || HCFJJCALLAF.activeSelf))
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(BMKMMOKMBGK())).onFinished = delegate
			{
				BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(HPNPMCEMJNM);
				CPBLNDIPKNN();
				NDNNJMAKKBD();
				TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO, BEJIFJIKHPJ.transform.localPosition.ReplaceX(265f));
				EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(256f);
			};
		}
		DKAALFBGKGO();
		IEPOJIONKOG();
	}

	[CompilerGenerated]
	private void KGPEAMIDEOA(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(LPPOJMGOEFN.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 1;
	}

	public void PINGMJCBFDH()
	{
		JHEDDCMBDPF.text = Localization.Localize("COPYCAT");
		float num = 1893f;
		TweenColor.Begin(JHEDDCMBDPF.gameObject, num, Color.white);
		TweenAlphaHider.DBPOCEIDEAE(ACCAGFEOLAH, num, 597f);
		TweenAlpha.Begin(MPEHCFEOLCH.gameObject, num, 1796f);
		TweenAlpha.Begin(GNNKBDLADCG.gameObject, num, 609f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(KNAIBGPMDAF.gameObject, num, 1587f, 1916f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = UITweener.Style.Loop;
		CPBLNDIPKNN();
		EANCIFFFKHH();
		BGMIEFJMPEB();
	}

	private void IKKLKOPEMNK(GameObject KHAHPAKDIKE)
	{
		if (MDAJJIAMDGH.purchasable == WeaponLevelsSetup.GILPPKMICCF.ElitePack2)
		{
			GuiElementSingle<CardsAndPacksDialog>.instance.ONHPOAIKLAO(CardsAndPacksDialog.LJCNLBMEENL.VALUE_PACK);
		}
		else if (MDAJJIAMDGH.purchasable == WeaponLevelsSetup.GILPPKMICCF.ValuePack)
		{
			GuiElementSingle<PackContentDialog>.instance.OHJEIGCJCLL(Singleton<GameVariables>.instance.KLMNEOAKMFB());
		}
		else if (MDAJJIAMDGH.purchasable == WeaponLevelsSetup.GILPPKMICCF.StarterAssignment)
		{
			GuiElementSingle<AssignmentsDialog>.instance.BKENOMAGHJK();
		}
		else if (MDAJJIAMDGH.purchasableValue.StartsWith("ActivateBonusResultRPC") || MDAJJIAMDGH.purchasableValue.StartsWith("ID_TIMEOFVIP"))
		{
			GuiElementSingle<PackContentDialog>.instance.KNBIBOINAKG(JGBBPCGNCPC.EGFMBMHOAHA(MDAJJIAMDGH.purchasableValue), CCIEEAECOAB: true);
		}
		else
		{
			Debug.LogError(string.Format("SquadId", MDAJJIAMDGH.name, MDAJJIAMDGH.purchasable));
		}
	}

	private void FOPKJKDCDON()
	{
		FBHJPHOCMDA.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		FINPLBLOADG.gameObject.SetActive(value: false);
		OJBKADHPNFN = false;
	}

	private void NPDCHOEJBHF()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (GOANDMNOGCK.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void EKKJPGOFPGA(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.BMNEPICFHNO().AODNADPPCBN())
		{
			BlackMarketManager.instance.ShowDialog();
		}
	}

	private void AHFNGIEIHJJ(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.instance.DMHPIEHHDMG())
		{
			BlackMarketManager.instance.ShowDialog();
		}
	}

	public void UpdateRightContent(bool LGIIPHPACIC = true)
	{
		if (LGIIPHPACIC)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(265f));
			NDNNJMAKKBD();
			return;
		}
		if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.NotBuyed || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering || MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered)
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(HPNPMCEMJNM)).onFinished = delegate
			{
				NDNNJMAKKBD();
				TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(265f));
			};
		}
		else if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active && CHCLANFKBFO.gameObject.activeSelf)
		{
			TweenPosition.Begin(CHCLANFKBFO.gameObject, JCAFFELIFAO, CHCLANFKBFO.transform.localPosition.ReplaceX(HPNPMCEMJNM)).onFinished = delegate
			{
				EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(HPNPMCEMJNM);
				NDNNJMAKKBD();
				TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(265f));
				CHCLANFKBFO.transform.localPosition = CHCLANFKBFO.transform.localPosition.ReplaceX(265f);
			};
		}
		else if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active && mBlackmarketButton.gameObject.activeSelf)
		{
			TweenPosition.Begin(mBlackmarketButton.gameObject, JCAFFELIFAO, mBlackmarketButton.transform.localPosition.ReplaceX(HPNPMCEMJNM)).onFinished = delegate
			{
				EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(HPNPMCEMJNM);
				NDNNJMAKKBD();
				TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(265f));
				mBlackmarketButton.transform.localPosition = mBlackmarketButton.transform.localPosition.ReplaceX(265f);
			};
		}
		else if (MDAJJIAMDGH.weaponState == WeaponLevelsSetup.JLANLLEABDC.Active && (LNFLDPLGEJE.activeSelf || JPJLKKJJFDB.activeSelf || HCFJJCALLAF.activeSelf))
		{
			TweenPosition.Begin(EPFODCCNGDL.gameObject, JCAFFELIFAO, EPFODCCNGDL.transform.localPosition.ReplaceX(HPNPMCEMJNM)).onFinished = delegate
			{
				BEJIFJIKHPJ.transform.localPosition = BEJIFJIKHPJ.transform.localPosition.ReplaceX(HPNPMCEMJNM);
				CPBLNDIPKNN();
				NDNNJMAKKBD();
				TweenPosition.Begin(BEJIFJIKHPJ.gameObject, JCAFFELIFAO, BEJIFJIKHPJ.transform.localPosition.ReplaceX(265f));
				EPFODCCNGDL.transform.localPosition = EPFODCCNGDL.transform.localPosition.ReplaceX(256f);
			};
		}
		DKAALFBGKGO();
		BGMIEFJMPEB();
	}

	private void LAIBHGOBADE(GameObject KHAHPAKDIKE)
	{
		switch (MDAJJIAMDGH.weaponState)
		{
		case WeaponLevelsSetup.JLANLLEABDC.Locked:
			Debug.Log("ID_NA");
			LevelManager.instance.DebugAddLevel();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.NotBuyed:
			Debug.Log("Name");
			FGFAKDPFFEK();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering:
			Debug.Log("game-engi-progress-fill");
			HDCLFPOIDEF();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.NCDHKBKPPMG(IDEBKDPMPGM: true);
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered:
			Debug.Log("claimRweard");
			KMKLGDIHIHF();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.LACNOADICNK();
			break;
		default:
			Debug.Log("ID_GUI_DELIVERING");
			break;
		}
	}

	private void FNKNBGDDLNH(GameObject KHAHPAKDIKE)
	{
		switch (MDAJJIAMDGH.weaponState)
		{
		case WeaponLevelsSetup.JLANLLEABDC.Locked:
			Debug.Log("Name");
			LevelManager.instance.DebugAddLevel();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.NotBuyed:
			Debug.Log("lootboxesOfferAdd");
			PHFJIFCBKBB();
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivering:
			Debug.Log("Play_Card_Tutorial_Duration");
			HDCLFPOIDEF();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.HJOGMENNJAJ(IDEBKDPMPGM: true);
			break;
		case WeaponLevelsSetup.JLANLLEABDC.WeaponDelivered:
			Debug.Log("getStatusMessage");
			OABPCCKPCJC();
			GuiScreenSingle<WeaponScreen>.instance.FHFIPPFJIAH.PlayEndAnimation();
			break;
		default:
			Debug.Log("RenameCount");
			break;
		}
	}

	public void GJEOCNOGEPD()
	{
		TweenScale tweenScale = TweenScale.Begin(BKFGHNPPHEK.gameObject, GuiScreenSingle<WeaponScreen>.instance.MFAFIELBJGF * 1108f, new Vector3(928f, 650f, 811f), new Vector3(717f, 1775f, 702f));
		tweenScale.NumOfRepetitions = 1;
		tweenScale.style = (UITweener.Style)8;
	}

	private void FOLJNEDAIKK()
	{
		float val = 0f - CKPLDDIPNAA.padding.x - (GPBMPAPOEOE.transform.parent.transform.localPosition.x - CKPLDDIPNAA.padding.x) / 1366f;
		CKPLDDIPNAA.transform.localPosition = CKPLDDIPNAA.transform.localPosition.ReplaceX(val);
	}

	private void POLLEMCFLBD(GameObject KHAHPAKDIKE)
	{
		if (BlackMarketManager.BMNEPICFHNO().DMHPIEHHDMG())
		{
			BlackMarketManager.instance.ShowDialog();
		}
	}

	public void EJOACBBBONC()
	{
		JHEDDCMBDPF.text = Localization.Localize("S");
		float num = 297f;
		TweenColor.Begin(JHEDDCMBDPF.gameObject, num, Color.white);
		TweenAlphaHider.MNBLBMJICDB(ACCAGFEOLAH, num, 292f);
		TweenAlpha.Begin(MPEHCFEOLCH.gameObject, num, 583f);
		TweenAlpha.Begin(GNNKBDLADCG.gameObject, num, 1250f);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(KNAIBGPMDAF.gameObject, num, 953f, 1279f);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = (UITweener.Style)3;
		CPBLNDIPKNN();
		EELEJFNCJBM();
		IEPOJIONKOG();
	}

	private void KPKNPDEDLPO(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (OJBKADHPNFN)
		{
			EFDDFNBFJHM();
		}
		else
		{
			BBPHKDHJKNO();
		}
	}
}
