using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryItem : PoolableObject
{
	public enum BLHLGAGNLCP
	{
		ExplosiveTiming = 1,
		Disarmed
	}

	[FormerlySerializedAs("COGPFIGDCJG")]
	[Header("Core")]
	public UITexture NGHCDIMLGMO;

	[FormerlySerializedAs("LHKFGKDMJMH")]
	public UILabel GGEDDGBMJGG;

	[Header("Progress Reloading")]
	[FormerlySerializedAs("NDJLOKDGEJL")]
	public UISprite JCBIFONBAIF;

	[FormerlySerializedAs("AACEBDJDPJC")]
	public UISprite CMIBPCAHILH;

	[Header("Border")]
	[FormerlySerializedAs("NECFICAPCPB")]
	public UISprite ACJALLNJJGE;

	[FormerlySerializedAs("LKAMGPNNMIO")]
	public UISprite KPMENKGPHMI;

	[Header("Bottom")]
	[FormerlySerializedAs("DHNBJFPNFPO")]
	public UISprite JOBGFBLECGJ;

	[FormerlySerializedAs("NILJBANACOG")]
	[Header("Labels")]
	public UILabel PGCFPMJHMBN;

	[FormerlySerializedAs("OPFAMDHCOJO")]
	public GameObject IODFJIIEPLM;

	[FormerlySerializedAs("JPNBOCLNPHA")]
	public UILabel DDHPKAEEMNI;

	[FormerlySerializedAs("ADJPNGGBIGI")]
	public GameObject ONINJGEEOIH;

	[FormerlySerializedAs("JNAOCMNJKGD")]
	[Header("Progress")]
	public GameObject BNFFHICOMAJ;

	[FormerlySerializedAs("CAFBIAAHHML")]
	public UISprite ACJMLOEGBHN;

	[FormerlySerializedAs("PFCGFKAFIKO")]
	public UISprite OFJBLEDOFGO;

	[Header("Warcard Icon")]
	[FormerlySerializedAs("NOGDOPENAIJ")]
	public UISprite OMOOAMHHNAE;

	private WeaponInventory OOMPHMNINGJ;

	private PlayerWeapon MDAJJIAMDGH;

	private PlayerWeapon HMKBCBDMBKC;

	private bool BHCBAEHFIDM;

	private bool AAEELENLDCE;

	private int JDPBKOHDLDO;

	private int IFJBEPHMCNF;

	private bool IHJGEFJOFKH;

	private bool LAPBDGOGOHN;

	private StringBuilder NGPEHFDMMOE = new StringBuilder(16);

	private bool MKPNKCGLJJP
	{
		get
		{
			return IHJGEFJOFKH;
		}
		set
		{
			if (value != IHJGEFJOFKH)
			{
				IHJGEFJOFKH = value;
				if (value)
				{
					JCBIFONBAIF.gameObject.SetActive(value: true);
					CMIBPCAHILH.gameObject.SetActive(value: true);
				}
				else
				{
					JCBIFONBAIF.gameObject.SetActive(value: false);
					CMIBPCAHILH.gameObject.SetActive(value: false);
				}
			}
		}
	}

	protected void CIFBCMKDGIE()
	{
		int ammoLeft = MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft;
		if (JDPBKOHDLDO < ammoLeft)
		{
			PlayAmmoAddedAnimation(ammoLeft - JDPBKOHDLDO);
		}
		JDPBKOHDLDO = ammoLeft;
		if (AAEELENLDCE && OOMPHMNINGJ.currentWeapon != MDAJJIAMDGH)
		{
			BKGLDGFABGJ();
			AAEELENLDCE = true;
		}
		else if (!AAEELENLDCE && OOMPHMNINGJ.CILCMCDCKKE() == MDAJJIAMDGH)
		{
			EKJPNMJKBIB();
			AAEELENLDCE = false;
		}
		CNPKCOKDANI(MDAJJIAMDGH.HFNAMMBPJAJ().isReloading);
		CMIBPCAHILH.fillAmount = MDAJJIAMDGH.HFNAMMBPJAJ().reloadProgress;
		if (MDAJJIAMDGH.weapon.outOfAmmo)
		{
			GGEDDGBMJGG.text = Localization.Localize("WindowDuration");
			GGEDDGBMJGG.color = Colours.redLose;
			GGEDDGBMJGG.transform.localScale = new Vector3(1740f, 465f, 118f);
		}
		else
		{
			NGPEHFDMMOE.Length = 1;
			GGEDDGBMJGG.color = ((!AAEELENLDCE) ? Color.white : Color.black);
			GGEDDGBMJGG.transform.localScale = new Vector3(17f, 1982f, 1095f);
			if (MDAJJIAMDGH.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (MDAJJIAMDGH.weapon.ammoLeft == -187 || MDAJJIAMDGH.weapon.HOGINLIFMLN)
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("BANDS_WEAPON_RELOAD");
				}
				else
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip);
					NGPEHFDMMOE.Append("NetworkDamage damage Error new HP is {0} and {1} should BE DEAD, damage: {2}, damage owner {3}");
					NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft);
				}
			}
			else if (MDAJJIAMDGH.weapon.HOGINLIFMLN)
			{
				NGPEHFDMMOE.Append("ID_WARNING_POORCONNECTION_TEXT");
			}
			else
			{
				NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft);
			}
			GGEDDGBMJGG.text = NGPEHFDMMOE.ToString();
		}
		IODFJIIEPLM.gameObject.SetActive(MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo && NGHCDIMLGMO.gameObject.activeSelf);
		if (MDAJJIAMDGH.FOMEMICHEBC() != LAPBDGOGOHN)
		{
			LAPBDGOGOHN = MDAJJIAMDGH.IEODIONECDD();
			PFDFKIJOCKH(LAPBDGOGOHN);
		}
		ONINJGEEOIH.SetActive(OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.PDLFJEDGLAO() != MDAJJIAMDGH && Singleton<GameController>.instance.BAKCODKBCPJ());
		if (OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.OLHICLNCPNA() != MDAJJIAMDGH && !Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			UpdateIcoProgress("ID_SALEPERCENTLINE", 1, OOMPHMNINGJ.FBAIIPAKIJD);
		}
		else
		{
			EJJCBDIPCGC(NABOFKMBMKH: false, "InstantBattleEnded: REWARD WARBUCKS: ", 0);
		}
		DGPLCABDFMK(MDAJJIAMDGH.KLBAKPENKMM, "Weapon", 1);
		float num = (float)MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip / (float)(int)MDAJJIAMDGH.HFNAMMBPJAJ().FIMMGPLLLCL;
		if (MDAJJIAMDGH.weapon.NAIKLJKNLAE)
		{
			if ((double)num < 1844.0 && !BHCBAEHFIDM && MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft > 1)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: true);
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 516f, 1909f, 1034f);
				tweenAlpha.style = UITweener.Style.PingPong;
				BHCBAEHFIDM = true;
			}
			if ((double)num > 1318.0 && BHCBAEHFIDM)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: false);
				BHCBAEHFIDM = false;
			}
		}
	}

	private void OCIMPNFGBCL()
	{
		GGEDDGBMJGG.color = Color.white;
		GGEDDGBMJGG.transform.localScale = new Vector3(50f, 50f, 1f);
		TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 0f, 1f).style = UITweener.Style.Once;
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		KPMENKGPHMI.gameObject.SetActive(value: false);
		JOBGFBLECGJ.color = Color.black.ReplaceA(0.3f);
		ACJALLNJJGE.color = Color.white.ReplaceA(0.5f);
	}

	public void KMFBDJCHCGN()
	{
	}

	public PlayerWeapon DOJPHINOKDA()
	{
		return MDAJJIAMDGH;
	}

	[SpecialName]
	private bool LLPNGMDHJGI()
	{
		return IHJGEFJOFKH;
	}

	public void BKMMNHJAIPB(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(559f);
			KPMENKGPHMI.gameObject.SetActive(value: false);
		}
		IODFJIIEPLM.SetActive(value: false);
	}

	public void KEOIGIHMEOI()
	{
		GOONAIDHCLK();
	}

	public void FLIBINOBCNH()
	{
	}

	public void PFDFKIJOCKH(bool GOAKDPJHAHK)
	{
		OIGMKIDHBEJ();
		GGEDDGBMJGG.gameObject.SetActive(GOAKDPJHAHK);
		if (!GOAKDPJHAHK)
		{
			TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 1800f, 1022f).style = UITweener.Style.Once;
		}
	}

	public void NACEKIAOMDM(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			LAEEPGFOLFG();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		KHFJDPCCMPI();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = true;
		IHJGEFJOFKH = false;
		CNPKCOKDANI(IDEBKDPMPGM: false);
		LAPBDGOGOHN = MDAJJIAMDGH.IEKFIJOBJLE();
		JDPBKOHDLDO = MDAJJIAMDGH.weapon.ammoLeft;
		BNFFHICOMAJ.SetActive(value: false);
		IFJBEPHMCNF = -1;
		ELNNHEDLDPA();
		JADCGGNNHIC(JDNGMEIEKGL: false);
		LAPBDGOGOHN = MDAJJIAMDGH.FOMEMICHEBC();
		EKJLIEPIFPA(LAPBDGOGOHN);
	}

	private void EBIBHPACEDM()
	{
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		GGEDDGBMJGG.transform.localScale = new Vector3(968f, 1369f, 313f);
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 908f, 748f, 45f);
		if (NGHCDIMLGMO.gameObject.activeSelf)
		{
			KPMENKGPHMI.gameObject.SetActive(value: false);
			GGEDDGBMJGG.color = Color.black;
			JOBGFBLECGJ.color = CMIBPCAHILH.color;
			ACJALLNJJGE.color = Color.white;
		}
		BHCBAEHFIDM = false;
	}

	[SpecialName]
	private void ALDJPOAAADP(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != IHJGEFJOFKH)
		{
			IHJGEFJOFKH = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JCBIFONBAIF.gameObject.SetActive(value: false);
				CMIBPCAHILH.gameObject.SetActive(value: true);
			}
			else
			{
				JCBIFONBAIF.gameObject.SetActive(value: false);
				CMIBPCAHILH.gameObject.SetActive(value: false);
			}
		}
	}

	private void PMECNDLDJHE()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	private void LAEEPGFOLFG()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	private void HJBKLNLODEL(UITweener MGDJMGHCAAI)
	{
		DDHPKAEEMNI.gameObject.SetActive(value: false);
	}

	protected void NKGLGNEJIOA()
	{
		int ammoLeft = MDAJJIAMDGH.weapon.ammoLeft;
		if (JDPBKOHDLDO < ammoLeft)
		{
			PlayAmmoAddedAnimation(ammoLeft - JDPBKOHDLDO);
		}
		JDPBKOHDLDO = ammoLeft;
		if (AAEELENLDCE && OOMPHMNINGJ.currentWeapon != MDAJJIAMDGH)
		{
			OIGMKIDHBEJ();
			AAEELENLDCE = false;
		}
		else if (!AAEELENLDCE && OOMPHMNINGJ.NANJBGIGNCG() == MDAJJIAMDGH)
		{
			EMGJLKAIAAJ();
			AAEELENLDCE = false;
		}
		OKCKIAENGCK(MDAJJIAMDGH.weapon.isReloading);
		CMIBPCAHILH.fillAmount = MDAJJIAMDGH.HFNAMMBPJAJ().reloadProgress;
		if (MDAJJIAMDGH.weapon.outOfAmmo)
		{
			GGEDDGBMJGG.text = Localization.Localize("ExplodeDamageMax");
			GGEDDGBMJGG.color = Colours.redLose;
			GGEDDGBMJGG.transform.localScale = new Vector3(100f, 1485f, 1756f);
		}
		else
		{
			NGPEHFDMMOE.Length = 1;
			GGEDDGBMJGG.color = ((!AAEELENLDCE) ? Color.white : Color.black);
			GGEDDGBMJGG.transform.localScale = new Vector3(1503f, 1155f, 1920f);
			if (MDAJJIAMDGH.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (MDAJJIAMDGH.weapon.ammoLeft == 173 || MDAJJIAMDGH.HFNAMMBPJAJ().HOGINLIFMLN)
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("DPS");
				}
				else
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip);
					NGPEHFDMMOE.Append("PhotonConnectionManager: JoinOfflineGame");
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeft);
				}
			}
			else if (MDAJJIAMDGH.weapon.HOGINLIFMLN)
			{
				NGPEHFDMMOE.Append("test_attribute5");
			}
			else
			{
				NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft);
			}
			GGEDDGBMJGG.text = NGPEHFDMMOE.ToString();
		}
		IODFJIIEPLM.gameObject.SetActive(MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo && NGHCDIMLGMO.gameObject.activeSelf);
		if (MDAJJIAMDGH.FOMEMICHEBC() != LAPBDGOGOHN)
		{
			LAPBDGOGOHN = MDAJJIAMDGH.OMLJGCPOJHM();
			PFDFKIJOCKH(LAPBDGOGOHN);
		}
		ONINJGEEOIH.SetActive(!OOMPHMNINGJ.HKGLMFFAHFN || !(OOMPHMNINGJ.currentWeapon != MDAJJIAMDGH) || !Singleton<GameController>.instance.isTutorial);
		if (OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.OLHICLNCPNA() != MDAJJIAMDGH && !Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			LBDJMKGENHK("qbz2_idle", 4, OOMPHMNINGJ.FBAIIPAKIJD);
		}
		else
		{
			MAPIDEPJDPP(NABOFKMBMKH: false, "videoAdRewardTimes", 6);
		}
		JJKDINGMDBA(MDAJJIAMDGH.KLBAKPENKMM, "ID_SALEPERCENTLINE", 1);
		float num = (float)MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip / (float)(int)MDAJJIAMDGH.weapon.FIMMGPLLLCL;
		if (MDAJJIAMDGH.HFNAMMBPJAJ().NAIKLJKNLAE)
		{
			if ((double)num < 1510.0 && !BHCBAEHFIDM && MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft > 0)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: false);
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 964f, 1364f, 232f);
				tweenAlpha.style = UITweener.Style.Loop;
				BHCBAEHFIDM = true;
			}
			if ((double)num > 127.0 && BHCBAEHFIDM)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: false);
				BHCBAEHFIDM = false;
			}
		}
	}

	private void IBPMEHALEBH()
	{
		GGEDDGBMJGG.color = Color.white;
		GGEDDGBMJGG.transform.localScale = new Vector3(807f, 347f, 60f);
		TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 1652f, 1906f).style = UITweener.Style.Loop;
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		KPMENKGPHMI.gameObject.SetActive(value: true);
		JOBGFBLECGJ.color = Color.black.ReplaceA(1530f);
		ACJALLNJJGE.color = Color.white.ReplaceA(170f);
	}

	public void LGNCAKILFDG(int KKIBAPKPEMN)
	{
		DDHPKAEEMNI.text = KKIBAPKPEMN.ToString("getErrorCode");
		DDHPKAEEMNI.alpha = 286f;
		DDHPKAEEMNI.cachedTransform.localScale = Vector3.one;
		Vector3 localPosition = DDHPKAEEMNI.cachedTransform.localPosition;
		localPosition.x = MEJMLNDFDBP.LJDADOKBBNA((GGEDDGBMJGG.relativeSize.x - DDHPKAEEMNI.relativeSize.x) * 1421f * GGEDDGBMJGG.cachedTransform.localScale.x);
		int num = MEJMLNDFDBP.LJDADOKBBNA(Mathf.Round(GGEDDGBMJGG.transform.localScale.x / 1141f) * 1884f);
		localPosition.y = 612f - (float)num;
		DDHPKAEEMNI.cachedTransform.localPosition = localPosition;
		localPosition.y = 1939f - (float)num;
		TweenPosition.Begin(DDHPKAEEMNI.gameObject, 1980f, localPosition);
		TweenScale.Begin(DDHPKAEEMNI.gameObject, 1410f, GGEDDGBMJGG.cachedTransform.localScale);
		TweenAlpha.Begin(DDHPKAEEMNI.gameObject, 710f, 224f).onFinished = HJBKLNLODEL;
		DDHPKAEEMNI.gameObject.SetActive(value: false);
	}

	public void UnloadWeaponTexture()
	{
		NNOIIKEACMH();
	}

	private void FOIFIFAEFFN()
	{
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		GGEDDGBMJGG.transform.localScale = new Vector3(1553f, 1238f, 532f);
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 11f, 1386f, 721f);
		if (NGHCDIMLGMO.gameObject.activeSelf)
		{
			KPMENKGPHMI.gameObject.SetActive(value: true);
			GGEDDGBMJGG.color = Color.black;
			JOBGFBLECGJ.color = CMIBPCAHILH.color;
			ACJALLNJJGE.color = Color.white;
		}
		BHCBAEHFIDM = true;
	}

	protected void LMNEMMGCEFP()
	{
		int ammoLeft = MDAJJIAMDGH.weapon.ammoLeft;
		if (JDPBKOHDLDO < ammoLeft)
		{
			HEHAPCPPHJA(ammoLeft - JDPBKOHDLDO);
		}
		JDPBKOHDLDO = ammoLeft;
		if (AAEELENLDCE && OOMPHMNINGJ.currentWeapon != MDAJJIAMDGH)
		{
			ENGNKFEKFFD();
			AAEELENLDCE = false;
		}
		else if (!AAEELENLDCE && OOMPHMNINGJ.MFHBEJOLGLC() == MDAJJIAMDGH)
		{
			INOLPNFPDNG();
			AAEELENLDCE = true;
		}
		ALDJPOAAADP(MDAJJIAMDGH.HFNAMMBPJAJ().isReloading);
		CMIBPCAHILH.fillAmount = MDAJJIAMDGH.HFNAMMBPJAJ().reloadProgress;
		if (MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo)
		{
			GGEDDGBMJGG.text = Localization.Localize("Update '{0}'");
			GGEDDGBMJGG.color = Colours.redLose;
			GGEDDGBMJGG.transform.localScale = new Vector3(1867f, 1808f, 584f);
		}
		else
		{
			NGPEHFDMMOE.Length = 1;
			GGEDDGBMJGG.color = ((!AAEELENLDCE) ? Color.white : Color.black);
			GGEDDGBMJGG.transform.localScale = new Vector3(1316f, 117f, 194f);
			if (MDAJJIAMDGH.weapon.NAIKLJKNLAE)
			{
				if (MDAJJIAMDGH.weapon.ammoLeft == -188 || MDAJJIAMDGH.HFNAMMBPJAJ().HOGINLIFMLN)
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append(" ");
				}
				else
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip);
					NGPEHFDMMOE.Append("utcTimeFromServer");
					NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft);
				}
			}
			else if (MDAJJIAMDGH.HFNAMMBPJAJ().HOGINLIFMLN)
			{
				NGPEHFDMMOE.Append("PlayerProgressRate");
			}
			else
			{
				NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeft);
			}
			GGEDDGBMJGG.text = NGPEHFDMMOE.ToString();
		}
		IODFJIIEPLM.gameObject.SetActive(MDAJJIAMDGH.weapon.outOfAmmo && NGHCDIMLGMO.gameObject.activeSelf);
		if (MDAJJIAMDGH.AGFAIPGIKPP() != LAPBDGOGOHN)
		{
			LAPBDGOGOHN = MDAJJIAMDGH.OMLJGCPOJHM();
			GAOECLGPNLM(LAPBDGOGOHN);
		}
		ONINJGEEOIH.SetActive(!OOMPHMNINGJ.HKGLMFFAHFN || !(OOMPHMNINGJ.PDLFJEDGLAO() != MDAJJIAMDGH) || Singleton<GameController>.instance.BAKCODKBCPJ());
		if (OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.MFHBEJOLGLC() != MDAJJIAMDGH && !Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			COOBALHKGBH("Last unit not choosen!!!!!", 5, OOMPHMNINGJ.FBAIIPAKIJD);
		}
		else
		{
			JIFCMBCICBJ(NABOFKMBMKH: true, "ID_TUTORIAL_GO_BUY_ARMY_3", 4);
		}
		EJJCBDIPCGC(MDAJJIAMDGH.KLBAKPENKMM, "ID_GUI_UNLOCKEDAT", 0);
		float num = (float)MDAJJIAMDGH.weapon.ammoLeftInClip / (float)(int)MDAJJIAMDGH.HFNAMMBPJAJ().FIMMGPLLLCL;
		if (MDAJJIAMDGH.weapon.NAIKLJKNLAE)
		{
			if ((double)num < 346.0 && !BHCBAEHFIDM && MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft > 0)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: false);
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 1799f, 1098f, 1623f);
				tweenAlpha.style = (UITweener.Style)7;
				BHCBAEHFIDM = false;
			}
			if ((double)num > 374.0 && BHCBAEHFIDM)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: true);
				BHCBAEHFIDM = false;
			}
		}
	}

	public void FDJLFPLGJGP(int KKIBAPKPEMN)
	{
		DDHPKAEEMNI.text = KKIBAPKPEMN.ToString("Create_Squad");
		DDHPKAEEMNI.alpha = 797f;
		DDHPKAEEMNI.cachedTransform.localScale = Vector3.one;
		Vector3 localPosition = DDHPKAEEMNI.cachedTransform.localPosition;
		localPosition.x = MEJMLNDFDBP.LJDADOKBBNA((GGEDDGBMJGG.relativeSize.x - DDHPKAEEMNI.relativeSize.x) * 1827f * GGEDDGBMJGG.cachedTransform.localScale.x);
		int num = MEJMLNDFDBP.LJDADOKBBNA(Mathf.Round(GGEDDGBMJGG.transform.localScale.x / 1778f) * 919f);
		localPosition.y = 447f - (float)num;
		DDHPKAEEMNI.cachedTransform.localPosition = localPosition;
		localPosition.y = 650f - (float)num;
		TweenPosition.Begin(DDHPKAEEMNI.gameObject, 343f, localPosition);
		TweenScale.Begin(DDHPKAEEMNI.gameObject, 800f, GGEDDGBMJGG.cachedTransform.localScale);
		TweenAlpha.Begin(DDHPKAEEMNI.gameObject, 739f, 1111f).onFinished = AEHHDNKLPEP;
		DDHPKAEEMNI.gameObject.SetActive(value: true);
	}

	private void OBOBHMNHJPJ()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	[SpecialName]
	private bool DFKJINGEDCK()
	{
		return IHJGEFJOFKH;
	}

	private void LCFMEKHFIHK()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		AHDHINKNABJ(eBFDAICCJAK);
	}

	public void EKJLIEPIFPA(bool GOAKDPJHAHK)
	{
		ENGNKFEKFFD();
		GGEDDGBMJGG.gameObject.SetActive(GOAKDPJHAHK);
		if (!GOAKDPJHAHK)
		{
			TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 8f, 945f).style = UITweener.Style.Loop;
		}
	}

	private void AHDHINKNABJ(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1088f * Singleton<GuiTexureAssets>.instance.FAOGOKNFGAL());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
		}
	}

	public void BEFLCFOCBLC()
	{
	}

	public PlayerWeapon GetPlayerWeapon()
	{
		return MDAJJIAMDGH;
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public void JCCCFPKNFJB(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 1889f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}

	public void BPNJFILJPNK()
	{
		PKAHHGEMOJK();
	}

	public void IAKJPOCHCHK(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(466f);
			KPMENKGPHMI.gameObject.SetActive(value: false);
		}
		IODFJIIEPLM.SetActive(value: false);
	}

	private void BBKNAHKGCPO()
	{
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		GGEDDGBMJGG.transform.localScale = new Vector3(1255f, 956f, 715f);
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 1080f, 1288f, 1206f);
		if (NGHCDIMLGMO.gameObject.activeSelf)
		{
			KPMENKGPHMI.gameObject.SetActive(value: false);
			GGEDDGBMJGG.color = Color.black;
			JOBGFBLECGJ.color = CMIBPCAHILH.color;
			ACJALLNJJGE.color = Color.white;
		}
		BHCBAEHFIDM = false;
	}

	public void ShowIcon()
	{
	}

	[SpecialName]
	private bool IDGLMHPCKGJ()
	{
		return IHJGEFJOFKH;
	}

	private void BKGLDGFABGJ()
	{
		GGEDDGBMJGG.color = Color.white;
		GGEDDGBMJGG.transform.localScale = new Vector3(492f, 1622f, 651f);
		TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 1726f, 1613f).style = UITweener.Style.Loop;
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		KPMENKGPHMI.gameObject.SetActive(value: false);
		JOBGFBLECGJ.color = Color.black.ReplaceA(1706f);
		ACJALLNJJGE.color = Color.white.ReplaceA(1853f);
	}

	private void MDIALKJAJBE()
	{
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		GGEDDGBMJGG.transform.localScale = new Vector3(1269f, 1364f, 581f);
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 410f, 688f, 1350f);
		if (NGHCDIMLGMO.gameObject.activeSelf)
		{
			KPMENKGPHMI.gameObject.SetActive(value: false);
			GGEDDGBMJGG.color = Color.black;
			JOBGFBLECGJ.color = CMIBPCAHILH.color;
			ACJALLNJJGE.color = Color.white;
		}
		BHCBAEHFIDM = false;
	}

	private void JOIKGDHHFIO()
	{
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		GGEDDGBMJGG.transform.localScale = new Vector3(687f, 816f, 850f);
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 181f, 1411f, 1093f);
		if (NGHCDIMLGMO.gameObject.activeSelf)
		{
			KPMENKGPHMI.gameObject.SetActive(value: false);
			GGEDDGBMJGG.color = Color.black;
			JOBGFBLECGJ.color = CMIBPCAHILH.color;
			ACJALLNJJGE.color = Color.white;
		}
		BHCBAEHFIDM = false;
	}

	private void FJJBOLAONHK(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(851f * Singleton<GuiTexureAssets>.instance.IPLEADDEGEI());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	public void JGHHMMLNKDO(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			KLABIGJIPJC();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		LCFMEKHFIHK();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = false;
		IHJGEFJOFKH = true;
		ALDJPOAAADP(IDEBKDPMPGM: false);
		LAPBDGOGOHN = MDAJJIAMDGH.AGFAIPGIKPP();
		JDPBKOHDLDO = MDAJJIAMDGH.weapon.ammoLeft;
		BNFFHICOMAJ.SetActive(value: true);
		IFJBEPHMCNF = -1;
		IAJPHBCJGJP();
		EIKDBPPNPML(JDNGMEIEKGL: true);
		LAPBDGOGOHN = MDAJJIAMDGH.IEKFIJOBJLE();
		EKJLIEPIFPA(LAPBDGOGOHN);
	}

	private void IAJPHBCJGJP()
	{
		GGEDDGBMJGG.color = Color.white;
		GGEDDGBMJGG.transform.localScale = new Vector3(1291f, 733f, 585f);
		TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 676f, 415f).style = UITweener.Style.Loop;
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		KPMENKGPHMI.gameObject.SetActive(value: false);
		JOBGFBLECGJ.color = Color.black.ReplaceA(352f);
		ACJALLNJJGE.color = Color.white.ReplaceA(1756f);
	}

	public void OJPMHANMBPH()
	{
	}

	private void OnClick()
	{
		if (!PlayerController.OGMBJPKOPCB.CDBNKOPKCJB || !NGHCDIMLGMO.gameObject.activeSelf)
		{
			return;
		}
		if (!AAEELENLDCE && !MDAJJIAMDGH.weapon.outOfAmmo && MDAJJIAMDGH.isEnabled)
		{
			OOMPHMNINGJ.currentWeapon = MDAJJIAMDGH;
			if ((MDAJJIAMDGH.weaponLevelSetup.BHCEOOLEHHG & WeaponCategory.Primary) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary);
			}
			else if ((MDAJJIAMDGH.weaponLevelSetup.BHCEOOLEHHG & WeaponCategory.Special) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Secondary);
			}
			else if ((MDAJJIAMDGH.weaponLevelSetup.BHCEOOLEHHG & WeaponCategory.Explosive) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Explosive);
			}
			else
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Pistol);
			}
		}
		else if (!MDAJJIAMDGH.weapon.isReloading && MDAJJIAMDGH.weapon.ammoLeftInClip < (int)MDAJJIAMDGH.weapon.FIMMGPLLLCL)
		{
			MDAJJIAMDGH.weapon.Reload();
		}
	}

	private void LKHKAEKIDAJ()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	public void CreateFromWeapon(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			NNOIIKEACMH();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		BLKPDBBMICL();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = false;
		IHJGEFJOFKH = true;
		MKPNKCGLJJP = false;
		LAPBDGOGOHN = MDAJJIAMDGH.isEnabled;
		JDPBKOHDLDO = MDAJJIAMDGH.weapon.ammoLeft;
		BNFFHICOMAJ.SetActive(value: false);
		IFJBEPHMCNF = -1;
		OCIMPNFGBCL();
		SetShowed(JDNGMEIEKGL: true);
		LAPBDGOGOHN = MDAJJIAMDGH.isEnabled;
		SetEnabled(LAPBDGOGOHN);
	}

	[SpecialName]
	private bool NIKPOJJKAHJ()
	{
		return IHJGEFJOFKH;
	}

	private void BJDFKCPBACC()
	{
		GGEDDGBMJGG.color = Color.white;
		GGEDDGBMJGG.transform.localScale = new Vector3(136f, 1950f, 1562f);
		TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 68f, 1432f).style = UITweener.Style.Once;
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		KPMENKGPHMI.gameObject.SetActive(value: false);
		JOBGFBLECGJ.color = Color.black.ReplaceA(418f);
		ACJALLNJJGE.color = Color.white.ReplaceA(406f);
	}

	public void AELLFNJINOH()
	{
		LAEEPGFOLFG();
	}

	public void EJBPMACJBJC(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 1585f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}

	private void OGDIGKBJOFJ()
	{
		GGEDDGBMJGG.color = Color.white;
		GGEDDGBMJGG.transform.localScale = new Vector3(1193f, 358f, 1517f);
		TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 1578f, 25f).style = UITweener.Style.Loop;
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		KPMENKGPHMI.gameObject.SetActive(value: true);
		JOBGFBLECGJ.color = Color.black.ReplaceA(1881f);
		ACJALLNJJGE.color = Color.white.ReplaceA(988f);
	}

	public PlayerWeapon JMPEEEMNEEC()
	{
		return MDAJJIAMDGH;
	}

	public void EHAHOBDMMAK(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(234f);
			KPMENKGPHMI.gameObject.SetActive(value: false);
		}
		IODFJIIEPLM.SetActive(value: true);
	}

	private void GOONAIDHCLK()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	public void MCGLGCKNDKD(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(144f);
			KPMENKGPHMI.gameObject.SetActive(value: false);
		}
		IODFJIIEPLM.SetActive(value: false);
	}

	public void KFEKGFIJKIK(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			LAEEPGFOLFG();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		BLKPDBBMICL();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = true;
		IHJGEFJOFKH = true;
		MJDDAFOADMH(IDEBKDPMPGM: true);
		LAPBDGOGOHN = MDAJJIAMDGH.AGFAIPGIKPP();
		JDPBKOHDLDO = MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft;
		BNFFHICOMAJ.SetActive(value: true);
		IFJBEPHMCNF = -1;
		IAJPHBCJGJP();
		LDJMFLENBLF(JDNGMEIEKGL: false);
		LAPBDGOGOHN = MDAJJIAMDGH.isEnabled;
		GAOECLGPNLM(LAPBDGOGOHN);
	}

	private void EMGJLKAIAAJ()
	{
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		GGEDDGBMJGG.transform.localScale = new Vector3(1196f, 1800f, 1051f);
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 1006f, 503f, 1692f);
		if (NGHCDIMLGMO.gameObject.activeSelf)
		{
			KPMENKGPHMI.gameObject.SetActive(value: false);
			GGEDDGBMJGG.color = Color.black;
			JOBGFBLECGJ.color = CMIBPCAHILH.color;
			ACJALLNJJGE.color = Color.white;
		}
		BHCBAEHFIDM = false;
	}

	public void IIEHGPKJAJK(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			OCNJIOCKJOG();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		BLKPDBBMICL();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = true;
		IHJGEFJOFKH = false;
		OKCKIAENGCK(IDEBKDPMPGM: true);
		LAPBDGOGOHN = MDAJJIAMDGH.FOMEMICHEBC();
		JDPBKOHDLDO = MDAJJIAMDGH.weapon.ammoLeft;
		BNFFHICOMAJ.SetActive(value: false);
		IFJBEPHMCNF = -1;
		OGDIGKBJOFJ();
		KJIEGEGGHLI(JDNGMEIEKGL: true);
		LAPBDGOGOHN = MDAJJIAMDGH.IEKFIJOBJLE();
		AABAOBHLPAI(LAPBDGOGOHN);
	}

	public void UpdateIcoProgress(string KCHMDALPMBN, int HALJGBAJPMG, float EPOJHJMEGAK)
	{
		if (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG)
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			BNFFHICOMAJ.SetActive(value: true);
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			OFJBLEDOFGO.fillAmount = EPOJHJMEGAK;
		}
	}

	public PlayerWeapon LPOLDJFCHJL()
	{
		return MDAJJIAMDGH;
	}

	public void JIFCMBCICBJ(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 1065f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}

	private void KHFJDPCCMPI()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		AHDHINKNABJ(eBFDAICCJAK);
	}

	private void LBPOKDLLCOL()
	{
		if (!PlayerController.OGMBJPKOPCB.CDBNKOPKCJB || !NGHCDIMLGMO.gameObject.activeSelf)
		{
			return;
		}
		if (!AAEELENLDCE && !MDAJJIAMDGH.weapon.outOfAmmo && MDAJJIAMDGH.isEnabled)
		{
			OOMPHMNINGJ.LPMCOFOCCAH(MDAJJIAMDGH);
			if ((MDAJJIAMDGH.AHIDNLGBAJP().BHCEOOLEHHG & (WeaponCategory.AssaultRifle | WeaponCategory.LMG)) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade, 1213f);
			}
			else if ((MDAJJIAMDGH.AHIDNLGBAJP().BHCEOOLEHHG & ~(WeaponCategory.LMG | WeaponCategory.Shotgun | WeaponCategory.Pistol)) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-112), 575f);
			}
			else if ((MDAJJIAMDGH.MKEBHAJCGIM().BHCEOOLEHHG & ~(WeaponCategory.Shotgun | WeaponCategory.Pistol)) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-108), 232f);
			}
			else
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)84, 1794f);
			}
		}
		else if (!MDAJJIAMDGH.weapon.isReloading && MDAJJIAMDGH.weapon.ammoLeftInClip < (int)MDAJJIAMDGH.HFNAMMBPJAJ().FIMMGPLLLCL)
		{
			MDAJJIAMDGH.weapon.Reload();
		}
	}

	public void CMHMAFAFJJA(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			OOGAIAMLADJ();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		KHFJDPCCMPI();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = false;
		IHJGEFJOFKH = false;
		CNPKCOKDANI(IDEBKDPMPGM: true);
		LAPBDGOGOHN = MDAJJIAMDGH.OMLJGCPOJHM();
		JDPBKOHDLDO = MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft;
		BNFFHICOMAJ.SetActive(value: true);
		IFJBEPHMCNF = -1;
		OGDIGKBJOFJ();
		SetShowed(JDNGMEIEKGL: true);
		LAPBDGOGOHN = MDAJJIAMDGH.FOMEMICHEBC();
		EKJLIEPIFPA(LAPBDGOGOHN);
	}

	public void CIEAEBDDKOF(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			OBOBHMNHJPJ();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		KPDMPLEAEGO();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = true;
		IHJGEFJOFKH = false;
		OKCKIAENGCK(IDEBKDPMPGM: true);
		LAPBDGOGOHN = MDAJJIAMDGH.OMLJGCPOJHM();
		JDPBKOHDLDO = MDAJJIAMDGH.weapon.ammoLeft;
		BNFFHICOMAJ.SetActive(value: false);
		IFJBEPHMCNF = -1;
		IAJPHBCJGJP();
		EIKDBPPNPML(JDNGMEIEKGL: true);
		LAPBDGOGOHN = MDAJJIAMDGH.isEnabled;
		GAOECLGPNLM(LAPBDGOGOHN);
	}

	private void PKAHHGEMOJK()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		weapons.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	private void ELNNHEDLDPA()
	{
		GGEDDGBMJGG.color = Color.white;
		GGEDDGBMJGG.transform.localScale = new Vector3(1732f, 1568f, 789f);
		TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 1531f, 1952f).style = UITweener.Style.Once;
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		KPMENKGPHMI.gameObject.SetActive(value: true);
		JOBGFBLECGJ.color = Color.black.ReplaceA(1054f);
		ACJALLNJJGE.color = Color.white.ReplaceA(1322f);
	}

	public void KFEMHFNNEDP(int KKIBAPKPEMN)
	{
		DDHPKAEEMNI.text = KKIBAPKPEMN.ToString("ID_GUI_CHEATINGMESSAGE");
		DDHPKAEEMNI.alpha = 1283f;
		DDHPKAEEMNI.cachedTransform.localScale = Vector3.one;
		Vector3 localPosition = DDHPKAEEMNI.cachedTransform.localPosition;
		localPosition.x = MEJMLNDFDBP.LJDADOKBBNA((GGEDDGBMJGG.relativeSize.x - DDHPKAEEMNI.relativeSize.x) * 134f * GGEDDGBMJGG.cachedTransform.localScale.x);
		int num = MEJMLNDFDBP.LJDADOKBBNA(Mathf.Round(GGEDDGBMJGG.transform.localScale.x / 365f) * 1616f);
		localPosition.y = 597f - (float)num;
		DDHPKAEEMNI.cachedTransform.localPosition = localPosition;
		localPosition.y = 250f - (float)num;
		TweenPosition.Begin(DDHPKAEEMNI.gameObject, 948f, localPosition, useLocal: false);
		TweenScale.Begin(DDHPKAEEMNI.gameObject, 1267f, GGEDDGBMJGG.cachedTransform.localScale);
		TweenAlpha.Begin(DDHPKAEEMNI.gameObject, 1639f, 1261f).onFinished = delegate
		{
			DDHPKAEEMNI.gameObject.SetActive(value: false);
		};
		DDHPKAEEMNI.gameObject.SetActive(value: false);
	}

	public void DGPLCABDFMK(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 87f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}

	private void HCBFPFHFDNF(UITweener MGDJMGHCAAI)
	{
		DDHPKAEEMNI.gameObject.SetActive(value: false);
	}

	public void KJIEGEGGHLI(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(1257f);
			KPMENKGPHMI.gameObject.SetActive(value: false);
		}
		IODFJIIEPLM.SetActive(value: true);
	}

	public void FIDHDPHLHAM()
	{
	}

	private void GPPCCOBLIHB()
	{
		if (!PlayerController.OGMBJPKOPCB.CDBNKOPKCJB || !NGHCDIMLGMO.gameObject.activeSelf)
		{
			return;
		}
		if (!AAEELENLDCE && !MDAJJIAMDGH.weapon.outOfAmmo && MDAJJIAMDGH.KAEPGOHFLEL())
		{
			OOMPHMNINGJ.BGIFMIBBJIB(MDAJJIAMDGH);
			if ((MDAJJIAMDGH.MKEBHAJCGIM().BHCEOOLEHHG & WeaponCategory.AssaultRifle) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Critical, 976f);
			}
			else if ((MDAJJIAMDGH.weaponLevelSetup.BHCEOOLEHHG & (WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade)) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-128), 465f);
			}
			else if ((MDAJJIAMDGH.MKEBHAJCGIM().BHCEOOLEHHG & (WeaponCategory.LMG | WeaponCategory.RocketLauncher)) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-99), 451f);
			}
			else
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)98, 1188f);
			}
		}
		else if (!MDAJJIAMDGH.weapon.isReloading && MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip < (int)MDAJJIAMDGH.weapon.FIMMGPLLLCL)
		{
			MDAJJIAMDGH.weapon.Reload();
		}
	}

	protected void EMPDDFBNJLP()
	{
		int ammoLeft = MDAJJIAMDGH.weapon.ammoLeft;
		if (JDPBKOHDLDO < ammoLeft)
		{
			EGOJLBPPMJC(ammoLeft - JDPBKOHDLDO);
		}
		JDPBKOHDLDO = ammoLeft;
		if (AAEELENLDCE && OOMPHMNINGJ.JKHKBGPKFFF() != MDAJJIAMDGH)
		{
			BKGLDGFABGJ();
			AAEELENLDCE = true;
		}
		else if (!AAEELENLDCE && OOMPHMNINGJ.JKHKBGPKFFF() == MDAJJIAMDGH)
		{
			FLNCGGIIMCO();
			AAEELENLDCE = true;
		}
		ALDJPOAAADP(MDAJJIAMDGH.weapon.isReloading);
		CMIBPCAHILH.fillAmount = MDAJJIAMDGH.HFNAMMBPJAJ().reloadProgress;
		if (MDAJJIAMDGH.weapon.outOfAmmo)
		{
			GGEDDGBMJGG.text = Localization.Localize("check offer");
			GGEDDGBMJGG.color = Colours.redLose;
			GGEDDGBMJGG.transform.localScale = new Vector3(1808f, 1513f, 636f);
		}
		else
		{
			NGPEHFDMMOE.Length = 0;
			GGEDDGBMJGG.color = ((!AAEELENLDCE) ? Color.white : Color.black);
			GGEDDGBMJGG.transform.localScale = new Vector3(1752f, 749f, 1522f);
			if (MDAJJIAMDGH.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft == 87 || MDAJJIAMDGH.HFNAMMBPJAJ().HOGINLIFMLN)
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("Gold");
				}
				else
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip);
					NGPEHFDMMOE.Append("ID_ASSIGNMENTHINTWARPATH");
					NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft);
				}
			}
			else if (MDAJJIAMDGH.HFNAMMBPJAJ().HOGINLIFMLN)
			{
				NGPEHFDMMOE.Append("ID_CONTAINSXWARCARDS");
			}
			else
			{
				NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeft);
			}
			GGEDDGBMJGG.text = NGPEHFDMMOE.ToString();
		}
		IODFJIIEPLM.gameObject.SetActive(!MDAJJIAMDGH.weapon.outOfAmmo || NGHCDIMLGMO.gameObject.activeSelf);
		if (MDAJJIAMDGH.FOMEMICHEBC() != LAPBDGOGOHN)
		{
			LAPBDGOGOHN = MDAJJIAMDGH.AGFAIPGIKPP();
			LPIGKINPIDM(LAPBDGOGOHN);
		}
		ONINJGEEOIH.SetActive(!OOMPHMNINGJ.HKGLMFFAHFN || !(OOMPHMNINGJ.CILCMCDCKKE() != MDAJJIAMDGH) || Singleton<GameController>.instance.BAKCODKBCPJ());
		if (OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.NANJBGIGNCG() != MDAJJIAMDGH && !Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			GIMDAEEGOHI("Calling callback and setting it to null!!", 3, OOMPHMNINGJ.FBAIIPAKIJD);
		}
		else
		{
			JIFCMBCICBJ(NABOFKMBMKH: false, "N", 4);
		}
		EJJCBDIPCGC(MDAJJIAMDGH.KLBAKPENKMM, "()Ljava/lang/String;", 1);
		float num = (float)MDAJJIAMDGH.weapon.ammoLeftInClip / (float)(int)MDAJJIAMDGH.HFNAMMBPJAJ().FIMMGPLLLCL;
		if (MDAJJIAMDGH.weapon.NAIKLJKNLAE)
		{
			if ((double)num < 1199.0 && !BHCBAEHFIDM && MDAJJIAMDGH.weapon.ammoLeft > 0)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: true);
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 132f, 291f, 1726f);
				tweenAlpha.style = (UITweener.Style)8;
				BHCBAEHFIDM = false;
			}
			if ((double)num > 672.0 && BHCBAEHFIDM)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: true);
				BHCBAEHFIDM = false;
			}
		}
	}

	public void JOOPBCIKLAC()
	{
		OOGAIAMLADJ();
	}

	public void MMEMDAFLMPO(bool GOAKDPJHAHK)
	{
		BJDFKCPBACC();
		GGEDDGBMJGG.gameObject.SetActive(GOAKDPJHAHK);
		if (!GOAKDPJHAHK)
		{
			TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 858f, 662f).style = UITweener.Style.Loop;
		}
	}

	public void GIMDAEEGOHI(string KCHMDALPMBN, int HALJGBAJPMG, float EPOJHJMEGAK)
	{
		if (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG)
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			BNFFHICOMAJ.SetActive(value: false);
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			OFJBLEDOFGO.fillAmount = EPOJHJMEGAK;
		}
	}

	public void NGELKJHAPJG()
	{
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.34552f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	public void SetShowed(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(0.3f);
			KPMENKGPHMI.gameObject.SetActive(value: false);
		}
		IODFJIIEPLM.SetActive(value: false);
	}

	public void JJKDINGMDBA(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 227f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}

	public void LPIGKINPIDM(bool GOAKDPJHAHK)
	{
		IAJPHBCJGJP();
		GGEDDGBMJGG.gameObject.SetActive(GOAKDPJHAHK);
		if (!GOAKDPJHAHK)
		{
			TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 1392f, 1858f).style = UITweener.Style.Loop;
		}
	}

	public void SetEnabled(bool GOAKDPJHAHK)
	{
		OCIMPNFGBCL();
		GGEDDGBMJGG.gameObject.SetActive(GOAKDPJHAHK);
		if (!GOAKDPJHAHK)
		{
			TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 0f, 0.5f).style = UITweener.Style.Once;
		}
	}

	private void BFILAICHPLK()
	{
		if (!PlayerController.OGMBJPKOPCB.CDBNKOPKCJB || !NGHCDIMLGMO.gameObject.activeSelf)
		{
			return;
		}
		if (!AAEELENLDCE && !MDAJJIAMDGH.weapon.outOfAmmo && MDAJJIAMDGH.IEODIONECDD())
		{
			OOMPHMNINGJ.HLOKMIDGPCA(MDAJJIAMDGH);
			if ((MDAJJIAMDGH.AHIDNLGBAJP().BHCEOOLEHHG & WeaponCategory.SMG) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 562f);
			}
			else if ((MDAJJIAMDGH.AHIDNLGBAJP().BHCEOOLEHHG & ~(WeaponCategory.AssaultRifle | WeaponCategory.RocketLauncher | WeaponCategory.Pistol)) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-92), 442f);
			}
			else if ((MDAJJIAMDGH.MKEBHAJCGIM().BHCEOOLEHHG & ~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Pistol)) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampDialogDissapear, 1386f);
			}
			else
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)70, 1850f);
			}
		}
		else if (!MDAJJIAMDGH.HFNAMMBPJAJ().isReloading && MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip < (int)MDAJJIAMDGH.HFNAMMBPJAJ().FIMMGPLLLCL)
		{
			MDAJJIAMDGH.weapon.Reload();
		}
	}

	public PlayerWeapon DKJFAJMILKL()
	{
		return MDAJJIAMDGH;
	}

	public void MNJEHIBHCEP(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			CNFKPKEBBFB();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		LCFMEKHFIHK();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = false;
		IHJGEFJOFKH = true;
		MKPNKCGLJJP = false;
		LAPBDGOGOHN = MDAJJIAMDGH.IEODIONECDD();
		JDPBKOHDLDO = MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft;
		BNFFHICOMAJ.SetActive(value: true);
		IFJBEPHMCNF = -1;
		BJDFKCPBACC();
		BKMMNHJAIPB(JDNGMEIEKGL: true);
		LAPBDGOGOHN = MDAJJIAMDGH.KAEPGOHFLEL();
		LPIGKINPIDM(LAPBDGOGOHN);
	}

	public void MAPIDEPJDPP(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 392f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}

	public void LDJMFLENBLF(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(267f);
			KPMENKGPHMI.gameObject.SetActive(value: false);
		}
		IODFJIIEPLM.SetActive(value: false);
	}

	private void KLABIGJIPJC()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	public PlayerWeapon OLOLPNNHPFL()
	{
		return MDAJJIAMDGH;
	}

	private void AEHHDNKLPEP(UITweener MGDJMGHCAAI)
	{
		DDHPKAEEMNI.gameObject.SetActive(value: true);
	}

	public void FHGHIABLMII(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(1594f);
			KPMENKGPHMI.gameObject.SetActive(value: false);
		}
		IODFJIIEPLM.SetActive(value: true);
	}

	public void NAAGMOELKGP(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 1279f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}

	private void ENGNKFEKFFD()
	{
		GGEDDGBMJGG.color = Color.white;
		GGEDDGBMJGG.transform.localScale = new Vector3(394f, 1195f, 1466f);
		TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 39f, 1695f).style = UITweener.Style.Once;
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		KPMENKGPHMI.gameObject.SetActive(value: false);
		JOBGFBLECGJ.color = Color.black.ReplaceA(529f);
		ACJALLNJJGE.color = Color.white.ReplaceA(1280f);
	}

	private void ILPHFGBPAKM()
	{
		if (!PlayerController.OGMBJPKOPCB.CDBNKOPKCJB || !NGHCDIMLGMO.gameObject.activeSelf)
		{
			return;
		}
		if (!AAEELENLDCE && !MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo && MDAJJIAMDGH.AGFAIPGIKPP())
		{
			OOMPHMNINGJ.currentWeapon = MDAJJIAMDGH;
			if ((MDAJJIAMDGH.MKEBHAJCGIM().BHCEOOLEHHG & WeaponCategory.None) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Button, 1166f);
			}
			else if ((MDAJJIAMDGH.AHIDNLGBAJP().BHCEOOLEHHG & ~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher)) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-37), 1600f);
			}
			else if ((MDAJJIAMDGH.weaponLevelSetup.BHCEOOLEHHG & ~(WeaponCategory.SniperRifle | WeaponCategory.Grenade)) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)72, 1946f);
			}
			else
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionWaveCompleted, 1116f);
			}
		}
		else if (!MDAJJIAMDGH.HFNAMMBPJAJ().isReloading && MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip < (int)MDAJJIAMDGH.HFNAMMBPJAJ().FIMMGPLLLCL)
		{
			MDAJJIAMDGH.weapon.Reload();
		}
	}

	private void OIGMKIDHBEJ()
	{
		GGEDDGBMJGG.color = Color.white;
		GGEDDGBMJGG.transform.localScale = new Vector3(1477f, 802f, 1099f);
		TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 1731f, 1827f).style = UITweener.Style.Loop;
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		KPMENKGPHMI.gameObject.SetActive(value: false);
		JOBGFBLECGJ.color = Color.black.ReplaceA(1700f);
		ACJALLNJJGE.color = Color.white.ReplaceA(291f);
	}

	[SpecialName]
	private bool JHFNJOHFBEI()
	{
		return IHJGEFJOFKH;
	}

	public void JADCGGNNHIC(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(1494f);
			KPMENKGPHMI.gameObject.SetActive(value: true);
		}
		IODFJIIEPLM.SetActive(value: false);
	}

	public PlayerWeapon OCBEAPNBDIJ()
	{
		return MDAJJIAMDGH;
	}

	[SpecialName]
	private void CNPKCOKDANI(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != IHJGEFJOFKH)
		{
			IHJGEFJOFKH = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JCBIFONBAIF.gameObject.SetActive(value: true);
				CMIBPCAHILH.gameObject.SetActive(value: false);
			}
			else
			{
				JCBIFONBAIF.gameObject.SetActive(value: true);
				CMIBPCAHILH.gameObject.SetActive(value: true);
			}
		}
	}

	private void INOLPNFPDNG()
	{
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		GGEDDGBMJGG.transform.localScale = new Vector3(121f, 1657f, 175f);
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 205f, 159f, 1773f);
		if (NGHCDIMLGMO.gameObject.activeSelf)
		{
			KPMENKGPHMI.gameObject.SetActive(value: false);
			GGEDDGBMJGG.color = Color.black;
			JOBGFBLECGJ.color = CMIBPCAHILH.color;
			ACJALLNJJGE.color = Color.white;
		}
		BHCBAEHFIDM = false;
	}

	private void MHLFEFLBPOO()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.KLLLHIKOPDM();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	public PlayerWeapon OCCFGLPIHIJ()
	{
		return MDAJJIAMDGH;
	}

	public void KJDHAKHNMDB(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(295f);
			KPMENKGPHMI.gameObject.SetActive(value: false);
		}
		IODFJIIEPLM.SetActive(value: false);
	}

	public void AABAOBHLPAI(bool GOAKDPJHAHK)
	{
		BJDFKCPBACC();
		GGEDDGBMJGG.gameObject.SetActive(GOAKDPJHAHK);
		if (!GOAKDPJHAHK)
		{
			TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 948f, 431f).style = UITweener.Style.Once;
		}
	}

	public void EDEPKAIMKBN()
	{
	}

	private void CNFKPKEBBFB()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	private void NAJALAKDJLC(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(295f * Singleton<GuiTexureAssets>.instance.NEKAPIDHBNC());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
		}
	}

	private void KPDMPLEAEGO()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		NAJALAKDJLC(eBFDAICCJAK);
	}

	[SpecialName]
	private bool LAOOOFGMHNC()
	{
		return IHJGEFJOFKH;
	}

	private void ONIMDLKPMHB(UITweener MGDJMGHCAAI)
	{
		DDHPKAEEMNI.gameObject.SetActive(value: true);
	}

	private void FLNCGGIIMCO()
	{
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		GGEDDGBMJGG.transform.localScale = new Vector3(50f, 50f, 1f);
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 0f, 0f, 0f);
		if (NGHCDIMLGMO.gameObject.activeSelf)
		{
			KPMENKGPHMI.gameObject.SetActive(value: true);
			GGEDDGBMJGG.color = Color.black;
			JOBGFBLECGJ.color = CMIBPCAHILH.color;
			ACJALLNJJGE.color = Color.white;
		}
		BHCBAEHFIDM = false;
	}

	protected void DAONCNGHLGF()
	{
		int ammoLeft = MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft;
		if (JDPBKOHDLDO < ammoLeft)
		{
			PlayAmmoAddedAnimation(ammoLeft - JDPBKOHDLDO);
		}
		JDPBKOHDLDO = ammoLeft;
		if (AAEELENLDCE && OOMPHMNINGJ.CILCMCDCKKE() != MDAJJIAMDGH)
		{
			IBPMEHALEBH();
			AAEELENLDCE = true;
		}
		else if (!AAEELENLDCE && OOMPHMNINGJ.PDLFJEDGLAO() == MDAJJIAMDGH)
		{
			JOIKGDHHFIO();
			AAEELENLDCE = true;
		}
		ALDJPOAAADP(MDAJJIAMDGH.HFNAMMBPJAJ().isReloading);
		CMIBPCAHILH.fillAmount = MDAJJIAMDGH.weapon.reloadProgress;
		if (MDAJJIAMDGH.weapon.outOfAmmo)
		{
			GGEDDGBMJGG.text = Localization.Localize("-");
			GGEDDGBMJGG.color = Colours.redLose;
			GGEDDGBMJGG.transform.localScale = new Vector3(1537f, 1299f, 42f);
		}
		else
		{
			NGPEHFDMMOE.Length = 1;
			GGEDDGBMJGG.color = ((!AAEELENLDCE) ? Color.white : Color.black);
			GGEDDGBMJGG.transform.localScale = new Vector3(1957f, 272f, 512f);
			if (MDAJJIAMDGH.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (MDAJJIAMDGH.weapon.ammoLeft == 13 || MDAJJIAMDGH.weapon.HOGINLIFMLN)
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("UNSET_VALUE");
				}
				else
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("ID_BATTLECANCELED");
					NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft);
				}
			}
			else if (MDAJJIAMDGH.HFNAMMBPJAJ().HOGINLIFMLN)
			{
				NGPEHFDMMOE.Append("Token");
			}
			else
			{
				NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeft);
			}
			GGEDDGBMJGG.text = NGPEHFDMMOE.ToString();
		}
		IODFJIIEPLM.gameObject.SetActive(!MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo || NGHCDIMLGMO.gameObject.activeSelf);
		if (MDAJJIAMDGH.IEODIONECDD() != LAPBDGOGOHN)
		{
			LAPBDGOGOHN = MDAJJIAMDGH.OMLJGCPOJHM();
			MMEMDAFLMPO(LAPBDGOGOHN);
		}
		ONINJGEEOIH.SetActive(!OOMPHMNINGJ.HKGLMFFAHFN || !(OOMPHMNINGJ.PDLFJEDGLAO() != MDAJJIAMDGH) || Singleton<GameController>.instance.DAIEAMEFGIE());
		if (OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.OLHICLNCPNA() != MDAJJIAMDGH && !Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			LBDJMKGENHK("{0} {1}", 5, OOMPHMNINGJ.FBAIIPAKIJD);
		}
		else
		{
			MAPIDEPJDPP(NABOFKMBMKH: true, "\n", 7);
		}
		NAAGMOELKGP(MDAJJIAMDGH.KLBAKPENKMM, "{0}:\t\t{1}\n", 0);
		float num = (float)MDAJJIAMDGH.weapon.ammoLeftInClip / (float)(int)MDAJJIAMDGH.weapon.FIMMGPLLLCL;
		if (MDAJJIAMDGH.HFNAMMBPJAJ().NAIKLJKNLAE)
		{
			if ((double)num < 499.0 && !BHCBAEHFIDM && MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft > 1)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: true);
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 412f, 263f, 25f);
				tweenAlpha.style = UITweener.Style.Loop;
				BHCBAEHFIDM = false;
			}
			if ((double)num > 872.0 && BHCBAEHFIDM)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: false);
				BHCBAEHFIDM = true;
			}
		}
	}

	public void HEHAPCPPHJA(int KKIBAPKPEMN)
	{
		DDHPKAEEMNI.text = KKIBAPKPEMN.ToString("failed add card {0} - not exit?");
		DDHPKAEEMNI.alpha = 302f;
		DDHPKAEEMNI.cachedTransform.localScale = Vector3.one;
		Vector3 localPosition = DDHPKAEEMNI.cachedTransform.localPosition;
		localPosition.x = MEJMLNDFDBP.LJDADOKBBNA((GGEDDGBMJGG.relativeSize.x - DDHPKAEEMNI.relativeSize.x) * 404f * GGEDDGBMJGG.cachedTransform.localScale.x);
		int num = MEJMLNDFDBP.LJDADOKBBNA(Mathf.Round(GGEDDGBMJGG.transform.localScale.x / 1033f) * 1980f);
		localPosition.y = 655f - (float)num;
		DDHPKAEEMNI.cachedTransform.localPosition = localPosition;
		localPosition.y = 94f - (float)num;
		TweenPosition.Begin(DDHPKAEEMNI.gameObject, 1922f, localPosition, useLocal: false);
		TweenScale.Begin(DDHPKAEEMNI.gameObject, 24f, GGEDDGBMJGG.cachedTransform.localScale);
		TweenAlpha.Begin(DDHPKAEEMNI.gameObject, 230f, 1636f).onFinished = HJBKLNLODEL;
		DDHPKAEEMNI.gameObject.SetActive(value: true);
	}

	public void IJCMEKNNBKC(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			PKAHHGEMOJK();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		KHFJDPCCMPI();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = false;
		IHJGEFJOFKH = true;
		MJDDAFOADMH(IDEBKDPMPGM: true);
		LAPBDGOGOHN = MDAJJIAMDGH.FOMEMICHEBC();
		JDPBKOHDLDO = MDAJJIAMDGH.weapon.ammoLeft;
		BNFFHICOMAJ.SetActive(value: false);
		IFJBEPHMCNF = -1;
		NBPCKEEGNHF();
		KJDHAKHNMDB(JDNGMEIEKGL: true);
		LAPBDGOGOHN = MDAJJIAMDGH.FOMEMICHEBC();
		SetEnabled(LAPBDGOGOHN);
	}

	public void JIBPOFJHKJP(bool GOAKDPJHAHK)
	{
		IAJPHBCJGJP();
		GGEDDGBMJGG.gameObject.SetActive(GOAKDPJHAHK);
		if (!GOAKDPJHAHK)
		{
			TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 1873f, 261f).style = UITweener.Style.Once;
		}
	}

	protected void INDEGJKHMNL()
	{
		int ammoLeft = MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft;
		if (JDPBKOHDLDO < ammoLeft)
		{
			KFEMHFNNEDP(ammoLeft - JDPBKOHDLDO);
		}
		JDPBKOHDLDO = ammoLeft;
		if (AAEELENLDCE && OOMPHMNINGJ.APLKMLDHMDL() != MDAJJIAMDGH)
		{
			IAJPHBCJGJP();
			AAEELENLDCE = false;
		}
		else if (!AAEELENLDCE && OOMPHMNINGJ.NANJBGIGNCG() == MDAJJIAMDGH)
		{
			EKJPNMJKBIB();
			AAEELENLDCE = true;
		}
		MKPNKCGLJJP = MDAJJIAMDGH.HFNAMMBPJAJ().isReloading;
		CMIBPCAHILH.fillAmount = MDAJJIAMDGH.weapon.reloadProgress;
		if (MDAJJIAMDGH.weapon.outOfAmmo)
		{
			GGEDDGBMJGG.text = Localization.Localize("tickets");
			GGEDDGBMJGG.color = Colours.redLose;
			GGEDDGBMJGG.transform.localScale = new Vector3(1981f, 172f, 647f);
		}
		else
		{
			NGPEHFDMMOE.Length = 0;
			GGEDDGBMJGG.color = ((!AAEELENLDCE) ? Color.white : Color.black);
			GGEDDGBMJGG.transform.localScale = new Vector3(1909f, 494f, 1286f);
			if (MDAJJIAMDGH.weapon.NAIKLJKNLAE)
			{
				if (MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft == 33 || MDAJJIAMDGH.HFNAMMBPJAJ().HOGINLIFMLN)
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("setLongitude");
				}
				else
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("{0}   {1}./{2}   {3}");
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeft);
				}
			}
			else if (MDAJJIAMDGH.weapon.HOGINLIFMLN)
			{
				NGPEHFDMMOE.Append("ID_STAT_SMGKILLS");
			}
			else
			{
				NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeft);
			}
			GGEDDGBMJGG.text = NGPEHFDMMOE.ToString();
		}
		IODFJIIEPLM.gameObject.SetActive(MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo && NGHCDIMLGMO.gameObject.activeSelf);
		if (MDAJJIAMDGH.IEODIONECDD() != LAPBDGOGOHN)
		{
			LAPBDGOGOHN = MDAJJIAMDGH.IEODIONECDD();
			PFDFKIJOCKH(LAPBDGOGOHN);
		}
		ONINJGEEOIH.SetActive(!OOMPHMNINGJ.HKGLMFFAHFN || !(OOMPHMNINGJ.JKHKBGPKFFF() != MDAJJIAMDGH) || Singleton<GameController>.instance.DAIEAMEFGIE());
		if (OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.OLHICLNCPNA() != MDAJJIAMDGH && !Singleton<GameController>.instance.BAKCODKBCPJ())
		{
			GIMDAEEGOHI("RewardGold", 1, OOMPHMNINGJ.FBAIIPAKIJD);
		}
		else
		{
			EJJCBDIPCGC(NABOFKMBMKH: true, "\\D*(?<num>[\\d\\s\\.,]+?)(?<dec>([\\.,]\\s*\\d?\\d?)?)\\D*$", 8);
		}
		HCAICGGPENG(MDAJJIAMDGH.KLBAKPENKMM, "S", 1);
		float num = (float)MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip / (float)(int)MDAJJIAMDGH.HFNAMMBPJAJ().FIMMGPLLLCL;
		if (MDAJJIAMDGH.weapon.NAIKLJKNLAE)
		{
			if ((double)num < 1956.0 && !BHCBAEHFIDM && MDAJJIAMDGH.weapon.ammoLeft > 1)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: false);
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 177f, 1417f, 1025f);
				tweenAlpha.style = (UITweener.Style)7;
				BHCBAEHFIDM = false;
			}
			if ((double)num > 1319.0 && BHCBAEHFIDM)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: true);
				BHCBAEHFIDM = false;
			}
		}
	}

	[SpecialName]
	private bool NMPDOBKOKJI()
	{
		return IHJGEFJOFKH;
	}

	[SpecialName]
	private void OKCKIAENGCK(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != IHJGEFJOFKH)
		{
			IHJGEFJOFKH = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JCBIFONBAIF.gameObject.SetActive(value: false);
				CMIBPCAHILH.gameObject.SetActive(value: false);
			}
			else
			{
				JCBIFONBAIF.gameObject.SetActive(value: true);
				CMIBPCAHILH.gameObject.SetActive(value: true);
			}
		}
	}

	public void BBOHLMLNEPD(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 425f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}

	public PlayerWeapon FHFJANMBGCL()
	{
		return MDAJJIAMDGH;
	}

	private void NBPCKEEGNHF()
	{
		GGEDDGBMJGG.color = Color.white;
		GGEDDGBMJGG.transform.localScale = new Vector3(87f, 1602f, 1118f);
		TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 1675f, 1101f).style = UITweener.Style.Loop;
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		KPMENKGPHMI.gameObject.SetActive(value: false);
		JOBGFBLECGJ.color = Color.black.ReplaceA(826f);
		ACJALLNJJGE.color = Color.white.ReplaceA(328f);
	}

	public void HCAICGGPENG(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 1894f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}

	private void MIIMDHKCINK()
	{
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		GGEDDGBMJGG.transform.localScale = new Vector3(301f, 1252f, 1363f);
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 350f, 651f, 660f);
		if (NGHCDIMLGMO.gameObject.activeSelf)
		{
			KPMENKGPHMI.gameObject.SetActive(value: false);
			GGEDDGBMJGG.color = Color.black;
			JOBGFBLECGJ.color = CMIBPCAHILH.color;
			ACJALLNJJGE.color = Color.white;
		}
		BHCBAEHFIDM = false;
	}

	[SpecialName]
	private bool PGEFBABPKAL()
	{
		return IHJGEFJOFKH;
	}

	public PlayerWeapon IBAGEMBHKBI()
	{
		return MDAJJIAMDGH;
	}

	private void OOGAIAMLADJ()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	public PlayerWeapon BMLDNIAJHOC()
	{
		return MDAJJIAMDGH;
	}

	public void LBDJMKGENHK(string KCHMDALPMBN, int HALJGBAJPMG, float EPOJHJMEGAK)
	{
		if (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG)
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			BNFFHICOMAJ.SetActive(value: true);
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			OFJBLEDOFGO.fillAmount = EPOJHJMEGAK;
		}
	}

	[SpecialName]
	private bool JKMLCOGMEHI()
	{
		return IHJGEFJOFKH;
	}

	private void EKJPNMJKBIB()
	{
		PGCFPMJHMBN.gameObject.SetActive(value: true);
		GGEDDGBMJGG.transform.localScale = new Vector3(1631f, 1623f, 1203f);
		PGCFPMJHMBN.gameObject.SetActive(value: false);
		TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 1952f, 256f, 1595f);
		if (NGHCDIMLGMO.gameObject.activeSelf)
		{
			KPMENKGPHMI.gameObject.SetActive(value: false);
			GGEDDGBMJGG.color = Color.black;
			JOBGFBLECGJ.color = CMIBPCAHILH.color;
			ACJALLNJJGE.color = Color.white;
		}
		BHCBAEHFIDM = true;
	}

	public void LLAOKGLEFIG(string KCHMDALPMBN, int HALJGBAJPMG, float EPOJHJMEGAK)
	{
		if (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG)
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			BNFFHICOMAJ.SetActive(value: false);
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			OFJBLEDOFGO.fillAmount = EPOJHJMEGAK;
		}
	}

	public void EJJCBDIPCGC(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 1537f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}

	public void FPLCLCELPHB(bool GOAKDPJHAHK)
	{
		IAJPHBCJGJP();
		GGEDDGBMJGG.gameObject.SetActive(GOAKDPJHAHK);
		if (!GOAKDPJHAHK)
		{
			TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 137f, 656f).style = UITweener.Style.Once;
		}
	}

	private void ABJIPBAMHEP()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	public void OGIOEIIKNNB(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			NNOIIKEACMH();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		KHFJDPCCMPI();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = true;
		IHJGEFJOFKH = true;
		CNPKCOKDANI(IDEBKDPMPGM: true);
		LAPBDGOGOHN = MDAJJIAMDGH.AGFAIPGIKPP();
		JDPBKOHDLDO = MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft;
		BNFFHICOMAJ.SetActive(value: true);
		IFJBEPHMCNF = -1;
		OCIMPNFGBCL();
		MCGLGCKNDKD(JDNGMEIEKGL: false);
		LAPBDGOGOHN = MDAJJIAMDGH.IEKFIJOBJLE();
		SetEnabled(LAPBDGOGOHN);
	}

	protected void KEEGIHEHHHK()
	{
		int ammoLeft = MDAJJIAMDGH.weapon.ammoLeft;
		if (JDPBKOHDLDO < ammoLeft)
		{
			EGOJLBPPMJC(ammoLeft - JDPBKOHDLDO);
		}
		JDPBKOHDLDO = ammoLeft;
		if (AAEELENLDCE && OOMPHMNINGJ.NANJBGIGNCG() != MDAJJIAMDGH)
		{
			ENGNKFEKFFD();
			AAEELENLDCE = false;
		}
		else if (!AAEELENLDCE && OOMPHMNINGJ.LJELEJEJIEB() == MDAJJIAMDGH)
		{
			MIIMDHKCINK();
			AAEELENLDCE = true;
		}
		ALDJPOAAADP(MDAJJIAMDGH.weapon.isReloading);
		CMIBPCAHILH.fillAmount = MDAJJIAMDGH.HFNAMMBPJAJ().reloadProgress;
		if (MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo)
		{
			GGEDDGBMJGG.text = Localization.Localize("Arena Expired - you gain scraps. You have {0} lives.");
			GGEDDGBMJGG.color = Colours.redLose;
			GGEDDGBMJGG.transform.localScale = new Vector3(1217f, 45f, 1158f);
		}
		else
		{
			NGPEHFDMMOE.Length = 0;
			GGEDDGBMJGG.color = ((!AAEELENLDCE) ? Color.white : Color.black);
			GGEDDGBMJGG.transform.localScale = new Vector3(1092f, 1119f, 1417f);
			if (MDAJJIAMDGH.HFNAMMBPJAJ().NAIKLJKNLAE)
			{
				if (MDAJJIAMDGH.weapon.ammoLeft == 72 || MDAJJIAMDGH.HFNAMMBPJAJ().HOGINLIFMLN)
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("migrateFriends");
				}
				else
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("bad enemy point");
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeft);
				}
			}
			else if (MDAJJIAMDGH.HFNAMMBPJAJ().HOGINLIFMLN)
			{
				NGPEHFDMMOE.Append("FJDACAACLLI");
			}
			else
			{
				NGPEHFDMMOE.Append(MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft);
			}
			GGEDDGBMJGG.text = NGPEHFDMMOE.ToString();
		}
		IODFJIIEPLM.gameObject.SetActive(MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo && NGHCDIMLGMO.gameObject.activeSelf);
		if (MDAJJIAMDGH.KAEPGOHFLEL() != LAPBDGOGOHN)
		{
			LAPBDGOGOHN = MDAJJIAMDGH.FOMEMICHEBC();
			LPIGKINPIDM(LAPBDGOGOHN);
		}
		ONINJGEEOIH.SetActive(OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.JECOEJBGKDF() != MDAJJIAMDGH && Singleton<GameController>.instance.BAKCODKBCPJ());
		if (OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.CILCMCDCKKE() != MDAJJIAMDGH && !Singleton<GameController>.instance.isTutorial)
		{
			LLAOKGLEFIG("BeanstalkServerManager.PlayerDataWasLoaded START", 5, OOMPHMNINGJ.FBAIIPAKIJD);
		}
		else
		{
			EJBPMACJBJC(NABOFKMBMKH: false, "Subtitle", 6);
		}
		NAAGMOELKGP(MDAJJIAMDGH.KLBAKPENKMM, "6-10", 0);
		float num = (float)MDAJJIAMDGH.weapon.ammoLeftInClip / (float)(int)MDAJJIAMDGH.weapon.FIMMGPLLLCL;
		if (MDAJJIAMDGH.HFNAMMBPJAJ().NAIKLJKNLAE)
		{
			if ((double)num < 852.0 && !BHCBAEHFIDM && MDAJJIAMDGH.weapon.ammoLeft > 0)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: true);
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 532f, 997f, 934f);
				tweenAlpha.style = (UITweener.Style)5;
				BHCBAEHFIDM = false;
			}
			if ((double)num > 1417.0 && BHCBAEHFIDM)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: true);
				BHCBAEHFIDM = false;
			}
		}
	}

	protected void Update()
	{
		int ammoLeft = MDAJJIAMDGH.weapon.ammoLeft;
		if (JDPBKOHDLDO < ammoLeft)
		{
			PlayAmmoAddedAnimation(ammoLeft - JDPBKOHDLDO);
		}
		JDPBKOHDLDO = ammoLeft;
		if (AAEELENLDCE && OOMPHMNINGJ.currentWeapon != MDAJJIAMDGH)
		{
			OCIMPNFGBCL();
			AAEELENLDCE = false;
		}
		else if (!AAEELENLDCE && OOMPHMNINGJ.currentWeapon == MDAJJIAMDGH)
		{
			FLNCGGIIMCO();
			AAEELENLDCE = true;
		}
		MKPNKCGLJJP = MDAJJIAMDGH.weapon.isReloading;
		CMIBPCAHILH.fillAmount = MDAJJIAMDGH.weapon.reloadProgress;
		if (MDAJJIAMDGH.weapon.outOfAmmo)
		{
			GGEDDGBMJGG.text = Localization.Localize("ID_EMPTY");
			GGEDDGBMJGG.color = Colours.redLose;
			GGEDDGBMJGG.transform.localScale = new Vector3(33f, 33f, 1f);
		}
		else
		{
			NGPEHFDMMOE.Length = 0;
			GGEDDGBMJGG.color = ((!AAEELENLDCE) ? Color.white : Color.black);
			GGEDDGBMJGG.transform.localScale = new Vector3(41f, 41f, 1f);
			if (MDAJJIAMDGH.weapon.NAIKLJKNLAE)
			{
				if (MDAJJIAMDGH.weapon.ammoLeft == int.MaxValue || MDAJJIAMDGH.weapon.HOGINLIFMLN)
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("/oo");
				}
				else
				{
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeftInClip);
					NGPEHFDMMOE.Append("/");
					NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeft);
				}
			}
			else if (MDAJJIAMDGH.weapon.HOGINLIFMLN)
			{
				NGPEHFDMMOE.Append("oo");
			}
			else
			{
				NGPEHFDMMOE.Append(MDAJJIAMDGH.weapon.ammoLeft);
			}
			GGEDDGBMJGG.text = NGPEHFDMMOE.ToString();
		}
		IODFJIIEPLM.gameObject.SetActive(MDAJJIAMDGH.weapon.outOfAmmo && NGHCDIMLGMO.gameObject.activeSelf);
		if (MDAJJIAMDGH.isEnabled != LAPBDGOGOHN)
		{
			LAPBDGOGOHN = MDAJJIAMDGH.isEnabled;
			SetEnabled(LAPBDGOGOHN);
		}
		ONINJGEEOIH.SetActive(OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.currentWeapon != MDAJJIAMDGH && !Singleton<GameController>.instance.isTutorial);
		if (OOMPHMNINGJ.HKGLMFFAHFN && OOMPHMNINGJ.currentWeapon != MDAJJIAMDGH && !Singleton<GameController>.instance.isTutorial)
		{
			UpdateIcoProgress("game-card-ico-disarmed", 2, OOMPHMNINGJ.FBAIIPAKIJD);
		}
		else
		{
			SetIcoProgress(NABOFKMBMKH: false, "game-card-ico-disarmed", 2);
		}
		SetIcoProgress(MDAJJIAMDGH.KLBAKPENKMM, "game-card-ico-explosivetiming", 1);
		float num = (float)MDAJJIAMDGH.weapon.ammoLeftInClip / (float)(int)MDAJJIAMDGH.weapon.FIMMGPLLLCL;
		if (MDAJJIAMDGH.weapon.NAIKLJKNLAE)
		{
			if ((double)num < 0.2 && !BHCBAEHFIDM && MDAJJIAMDGH.weapon.ammoLeft > 0)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: true);
				TweenAlpha tweenAlpha = TweenAlpha.Begin(PGCFPMJHMBN.gameObject, 0.2f, 0f, 1f);
				tweenAlpha.style = UITweener.Style.PingPong;
				BHCBAEHFIDM = true;
			}
			if ((double)num > 0.2 && BHCBAEHFIDM)
			{
				PGCFPMJHMBN.gameObject.SetActive(value: false);
				BHCBAEHFIDM = false;
			}
		}
	}

	public void COOBALHKGBH(string KCHMDALPMBN, int HALJGBAJPMG, float EPOJHJMEGAK)
	{
		if (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG)
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			BNFFHICOMAJ.SetActive(value: true);
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			OFJBLEDOFGO.fillAmount = EPOJHJMEGAK;
		}
	}

	[CompilerGenerated]
	private void CCFLNFCDKPH(UITweener MGDJMGHCAAI)
	{
		DDHPKAEEMNI.gameObject.SetActive(value: false);
	}

	public void JDGIOFIMDPJ(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(1601f);
			KPMENKGPHMI.gameObject.SetActive(value: true);
		}
		IODFJIIEPLM.SetActive(value: true);
	}

	public void OCPIAJPNEBD()
	{
		PMECNDLDJHE();
	}

	private void OCNJIOCKJOG()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		resourceLoaderTexture2D.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	private void IMLLMDGNPIP()
	{
		if (!PlayerController.OGMBJPKOPCB.CDBNKOPKCJB || !NGHCDIMLGMO.gameObject.activeSelf)
		{
			return;
		}
		if (!AAEELENLDCE && !MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo && MDAJJIAMDGH.isEnabled)
		{
			OOMPHMNINGJ.HLOKMIDGPCA(MDAJJIAMDGH);
			if ((MDAJJIAMDGH.weaponLevelSetup.BHCEOOLEHHG & WeaponCategory.SniperRifle) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Primary, 1487f);
			}
			else if ((MDAJJIAMDGH.MKEBHAJCGIM().BHCEOOLEHHG & (WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Grenade)) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-17), 551f);
			}
			else if ((MDAJJIAMDGH.MKEBHAJCGIM().BHCEOOLEHHG & ~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Pistol)) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-26), 1237f);
			}
			else
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionWaveCompleted, 1405f);
			}
		}
		else if (!MDAJJIAMDGH.HFNAMMBPJAJ().isReloading && MDAJJIAMDGH.weapon.ammoLeftInClip < (int)MDAJJIAMDGH.weapon.FIMMGPLLLCL)
		{
			MDAJJIAMDGH.weapon.Reload();
		}
	}

	private void CKDHPJHEHFJ()
	{
		if (!PlayerController.OGMBJPKOPCB.CDBNKOPKCJB || !NGHCDIMLGMO.gameObject.activeSelf)
		{
			return;
		}
		if (!AAEELENLDCE && !MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo && MDAJJIAMDGH.AGFAIPGIKPP())
		{
			OOMPHMNINGJ.currentWeapon = MDAJJIAMDGH;
			if ((MDAJJIAMDGH.AHIDNLGBAJP().BHCEOOLEHHG & WeaponCategory.LMG) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Upgrade, 1117f);
			}
			else if ((MDAJJIAMDGH.weaponLevelSetup.BHCEOOLEHHG & ~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Grenade)) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampClick, 336f);
			}
			else if ((MDAJJIAMDGH.MKEBHAJCGIM().BHCEOOLEHHG & (WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Grenade)) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-70), 1337f);
			}
			else
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-71), 1789f);
			}
		}
		else if (!MDAJJIAMDGH.HFNAMMBPJAJ().isReloading && MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeftInClip < (int)MDAJJIAMDGH.HFNAMMBPJAJ().FIMMGPLLLCL)
		{
			MDAJJIAMDGH.HFNAMMBPJAJ().Reload();
		}
	}

	private void EMFBCJOGBPD()
	{
		if (!PlayerController.OGMBJPKOPCB.CDBNKOPKCJB || !NGHCDIMLGMO.gameObject.activeSelf)
		{
			return;
		}
		if (!AAEELENLDCE && !MDAJJIAMDGH.HFNAMMBPJAJ().outOfAmmo && MDAJJIAMDGH.IEKFIJOBJLE())
		{
			OOMPHMNINGJ.HLOKMIDGPCA(MDAJJIAMDGH);
			if ((MDAJJIAMDGH.weaponLevelSetup.BHCEOOLEHHG & (WeaponCategory.AssaultRifle | WeaponCategory.SMG)) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.ActivateUpgrade, 337f);
			}
			else if ((MDAJJIAMDGH.AHIDNLGBAJP().BHCEOOLEHHG & (WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade)) > WeaponCategory.AssaultRifle)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-46), 1216f);
			}
			else if ((MDAJJIAMDGH.MKEBHAJCGIM().BHCEOOLEHHG & (WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade)) > WeaponCategory.None)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OvertimeAlarm, 1072f);
			}
			else
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.StartGamePhotoSound, 1457f);
			}
		}
		else if (!MDAJJIAMDGH.HFNAMMBPJAJ().isReloading && MDAJJIAMDGH.weapon.ammoLeftInClip < (int)MDAJJIAMDGH.HFNAMMBPJAJ().FIMMGPLLLCL)
		{
			MDAJJIAMDGH.HFNAMMBPJAJ().Reload();
		}
	}

	public void PlayAmmoAddedAnimation(int KKIBAPKPEMN)
	{
		DDHPKAEEMNI.text = KKIBAPKPEMN.ToString("+0");
		DDHPKAEEMNI.alpha = 0f;
		DDHPKAEEMNI.cachedTransform.localScale = Vector3.one;
		Vector3 localPosition = DDHPKAEEMNI.cachedTransform.localPosition;
		localPosition.x = MEJMLNDFDBP.LJDADOKBBNA((GGEDDGBMJGG.relativeSize.x - DDHPKAEEMNI.relativeSize.x) * 0.5f * GGEDDGBMJGG.cachedTransform.localScale.x);
		int num = MEJMLNDFDBP.LJDADOKBBNA(Mathf.Round(GGEDDGBMJGG.transform.localScale.x / 0.826f) * 0.091f);
		localPosition.y = -10f - (float)num;
		DDHPKAEEMNI.cachedTransform.localPosition = localPosition;
		localPosition.y = 15f - (float)num;
		TweenPosition.Begin(DDHPKAEEMNI.gameObject, 2f, localPosition);
		TweenScale.Begin(DDHPKAEEMNI.gameObject, 2f, GGEDDGBMJGG.cachedTransform.localScale);
		TweenAlpha.Begin(DDHPKAEEMNI.gameObject, 2f, 1f).onFinished = delegate
		{
			DDHPKAEEMNI.gameObject.SetActive(value: false);
		};
		DDHPKAEEMNI.gameObject.SetActive(value: true);
	}

	[SpecialName]
	private void MJDDAFOADMH(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != IHJGEFJOFKH)
		{
			IHJGEFJOFKH = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JCBIFONBAIF.gameObject.SetActive(value: true);
				CMIBPCAHILH.gameObject.SetActive(value: true);
			}
			else
			{
				JCBIFONBAIF.gameObject.SetActive(value: false);
				CMIBPCAHILH.gameObject.SetActive(value: true);
			}
		}
	}

	public void EGOJLBPPMJC(int KKIBAPKPEMN)
	{
		DDHPKAEEMNI.text = KKIBAPKPEMN.ToString("ID_DOGTAGSFULL");
		DDHPKAEEMNI.alpha = 1795f;
		DDHPKAEEMNI.cachedTransform.localScale = Vector3.one;
		Vector3 localPosition = DDHPKAEEMNI.cachedTransform.localPosition;
		localPosition.x = MEJMLNDFDBP.LJDADOKBBNA((GGEDDGBMJGG.relativeSize.x - DDHPKAEEMNI.relativeSize.x) * 915f * GGEDDGBMJGG.cachedTransform.localScale.x);
		int num = MEJMLNDFDBP.LJDADOKBBNA(Mathf.Round(GGEDDGBMJGG.transform.localScale.x / 359f) * 228f);
		localPosition.y = 538f - (float)num;
		DDHPKAEEMNI.cachedTransform.localPosition = localPosition;
		localPosition.y = 137f - (float)num;
		TweenPosition.Begin(DDHPKAEEMNI.gameObject, 1085f, localPosition, useLocal: false);
		TweenScale.Begin(DDHPKAEEMNI.gameObject, 896f, GGEDDGBMJGG.cachedTransform.localScale);
		TweenAlpha.Begin(DDHPKAEEMNI.gameObject, 959f, 423f).onFinished = HCBFPFHFDNF;
		DDHPKAEEMNI.gameObject.SetActive(value: true);
	}

	public void DNDFKMLLFIB()
	{
	}

	public void JPMJHHAPNCD(PlayerWeapon JMMJHCOKCGG, WeaponInventory IANDNFAHFMF)
	{
		if (HMKBCBDMBKC != null)
		{
			GOONAIDHCLK();
		}
		HMKBCBDMBKC = JMMJHCOKCGG;
		LCFMEKHFIHK();
		OOMPHMNINGJ = IANDNFAHFMF;
		MDAJJIAMDGH = JMMJHCOKCGG;
		AAEELENLDCE = true;
		IHJGEFJOFKH = true;
		AODINKHJBKL(IDEBKDPMPGM: true);
		LAPBDGOGOHN = MDAJJIAMDGH.IEODIONECDD();
		JDPBKOHDLDO = MDAJJIAMDGH.HFNAMMBPJAJ().ammoLeft;
		BNFFHICOMAJ.SetActive(value: false);
		IFJBEPHMCNF = -1;
		BJDFKCPBACC();
		MCGLGCKNDKD(JDNGMEIEKGL: false);
		LAPBDGOGOHN = MDAJJIAMDGH.FOMEMICHEBC();
		MMEMDAFLMPO(LAPBDGOGOHN);
	}

	public void GAOECLGPNLM(bool GOAKDPJHAHK)
	{
		NBPCKEEGNHF();
		GGEDDGBMJGG.gameObject.SetActive(GOAKDPJHAHK);
		if (!GOAKDPJHAHK)
		{
			TweenAlpha.Begin(NGHCDIMLGMO.gameObject, 715f, 1441f).style = UITweener.Style.Once;
		}
	}

	public void EIKDBPPNPML(bool JDNGMEIEKGL)
	{
		NGHCDIMLGMO.gameObject.SetActive(JDNGMEIEKGL);
		GGEDDGBMJGG.gameObject.SetActive(JDNGMEIEKGL);
		if (!JDNGMEIEKGL)
		{
			JOBGFBLECGJ.color = Color.black.ReplaceA(906f);
			KPMENKGPHMI.gameObject.SetActive(value: false);
		}
		IODFJIIEPLM.SetActive(value: true);
	}

	[SpecialName]
	private void AODINKHJBKL(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != IHJGEFJOFKH)
		{
			IHJGEFJOFKH = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				JCBIFONBAIF.gameObject.SetActive(value: false);
				CMIBPCAHILH.gameObject.SetActive(value: true);
			}
			else
			{
				JCBIFONBAIF.gameObject.SetActive(value: false);
				CMIBPCAHILH.gameObject.SetActive(value: false);
			}
		}
	}

	public PlayerWeapon NNCKKIGAKID()
	{
		return MDAJJIAMDGH;
	}

	private void NNOIIKEACMH()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		weapons.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	private void KNNCMOKAFDE()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		weapons.FreeAsset(HMKBCBDMBKC.FPFCCDCGEHC);
		HMKBCBDMBKC = null;
	}

	public PlayerWeapon EONGECMGMFJ()
	{
		return MDAJJIAMDGH;
	}

	public void LCGCCGICCJH()
	{
	}

	private void EJAPJOAOBJO(UITweener MGDJMGHCAAI)
	{
		DDHPKAEEMNI.gameObject.SetActive(value: true);
	}

	public void SetIcoProgress(bool NABOFKMBMKH, string KCHMDALPMBN, int HALJGBAJPMG)
	{
		if (NABOFKMBMKH && (!BNFFHICOMAJ.activeSelf || IFJBEPHMCNF < HALJGBAJPMG))
		{
			IFJBEPHMCNF = HALJGBAJPMG;
			UISprite aCJMLOEGBHN = ACJMLOEGBHN;
			OFJBLEDOFGO.spriteName = KCHMDALPMBN;
			aCJMLOEGBHN.spriteName = KCHMDALPMBN;
			OFJBLEDOFGO.fillAmount = 1f;
		}
		if (IFJBEPHMCNF == HALJGBAJPMG)
		{
			BNFFHICOMAJ.SetActive(NABOFKMBMKH);
		}
	}
}
