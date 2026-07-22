using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class OneTimeOfferDialog : GuiElementSingle<OneTimeOfferDialog>, PAIIOKBBHBC
{
	private enum LJCNLBMEENL
	{
		Unit,
		Weapon,
		PowerBand,
		Currency
	}

	[Header("Header")]
	public UILabel OKMNFHNBMFA;

	[Header("Content")]
	public CircleProgress FHFIPPFJIAH;

	[Header("-Weapon")]
	public GameObject IPJGCHLDPNN;

	[Header("--Left")]
	public UILabel PPFCOELFDEI;

	public List<ProgressBarRecordRentalDialog> BOIMODJFNLJ;

	[Header("--Middle")]
	public UITexture NGHCDIMLGMO;

	[Header("--Right")]
	public UISprite KELBMDMFKGE;

	public UILabel NKFPAIBKJLN;

	public UITable PLAJLODCALI;

	public UILabel BKFGHNPPHEK;

	public GameObject BFIKGAJAFPD;

	public UILabel MCPCIHEBDDB;

	public UISprite AIFMBPEECBK;

	[Header("-Unit")]
	public GameObject DNCJEBDPBNA;

	[Header("--Left")]
	public UILabel JHONGBLEHLJ;

	public List<ProgressBarArmyRecordRentalDialog> NGMDHEGFIKE;

	public BoxCollider EEJLKNFPGNF;

	public UISprite AFJJKEIDCOO;

	public UIPanel CDJJCFKGGNM;

	public BoxCollider EKBKEMKCBOP;

	public UISprite GODMILJPCKC;

	public UITable JMMCCMGDLHC;

	public UISprite ODINPJHOLKD;

	public UILabel KCBMFPDBHMK;

	public UILabel NFMNIANAMBN;

	public GameObject IMNEFKFMJCL;

	[Header("--Middle")]
	public UISprite NACGOGCPIAH;

	[Header("--Right")]
	public GameObject BNDBPOEDIHJ;

	public UILabel AODBLOCIBAM;

	public UISprite JHNJAPJJKMD;

	public UISprite CJPLJHJPGAN;

	public UILabel ALEFOLOOMIH;

	public UILabel NENIJEEPPBJ;

	[Header("-Power Band")]
	public GameObject DPHDJEAHODH;

	[Header("--Left")]
	public UITable MIIKHEMFJPA;

	public UILabel PIHCIHILDBO;

	public UITable IDHLOENDLBL;

	public UILabel EJILDMGICPA;

	public UISprite HPFACGCBKCK;

	[Header("--Middle")]
	public UISprite JAJCFNOIBPM;

	[Header("--Right")]
	public UITable MKJPHJIIJDD;

	public UISprite NPLIAGMKPPK;

	public UILabel FBIBBNPGOCG;

	public UILabel DCOFECNGCKC;

	[Header("-Currency")]
	public GameObject CBOBGFENGGF;

	public CircleProgress EDOPLKEKEID;

	public UISprite AECNPKHPDDC;

	public UILabel NOMKJMJJPBH;

	public UISprite GBJNANLNLLP;

	public UILabel PDLODPJIAIM;

	[Header("Bottom")]
	public UIButton MPPDEAMFKMO;

	[Header("-Upgrade")]
	public UIButton BFAGMLNLBGA;

	public UITable FBBEFJJCNNA;

	public UILabel PEPCBNMCFOG;

	[Header("-Buy")]
	public UIButton HDDBLHBCFHG;

	public UITable CHCFBDMGNLP;

	public UISprite BGPBNIJPOKM;

	public UISprite CODFFPODNEP;

	public UILabel LMCJKECEHGM;

	[Header("Early Unlock")]
	public GameObject JBFNFECHDCB;

	public UILabel AIELHBIOBJL;

	public UILabel AFJECEJJIJN;

	public UILabel DANIJOPJCKC;

	[Header("On Sale")]
	public GameObject GIPFEBBMKPM;

	public UILabel EKIDAFLLCNM;

	public UITable JPBIHKIOCOI;

	public GameObject CLIMOEHAMBP;

	public GameObject OKOFOHHOGNO;

	public StrikethroughPrize JHHCNMFNDFN;

	public UILabel HLLCKBPCHBL;

	private string DNEBFDALAFH;

	private int OKGNPCBCIDN;

	private bool MKPKIPHBNOL;

	private int KKBPMPEBKIL;

	private int ENEFFHEDLJJ;

	private bool GBKLFKHMFCP;

	private bool NHIMHOLFCGH;

	private LJCNLBMEENL GPABKIOEGKM;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private LevelBehaviour IFFDIHCPKFE;

	private PlayerVisual FGIMNJOOAOB;

	private static Dictionary<LJCNLBMEENL, Vector3> DJCLJHJKJOJ = new Dictionary<LJCNLBMEENL, Vector3>
	{
		{
			LJCNLBMEENL.Unit,
			new Vector3(820f, 200f, -5f)
		},
		{
			LJCNLBMEENL.Weapon,
			new Vector3(440f, 200f, -5f)
		},
		{
			LJCNLBMEENL.PowerBand,
			new Vector3(440f, 200f, -5f)
		},
		{
			LJCNLBMEENL.Currency,
			new Vector3(760f, -75f, -5f)
		}
	};

	private static Dictionary<LJCNLBMEENL, Vector3> HEPEIFIKMGP = new Dictionary<LJCNLBMEENL, Vector3>
	{
		{
			LJCNLBMEENL.Unit,
			new Vector3(820f, -64f, -5f)
		},
		{
			LJCNLBMEENL.Weapon,
			new Vector3(726f, 200f, -5f)
		},
		{
			LJCNLBMEENL.PowerBand,
			new Vector3(726f, 200f, -5f)
		},
		{
			LJCNLBMEENL.Currency,
			new Vector3(820f, -64f, -5f)
		}
	};

	private void JDFHFNGHCLG(PlayerVisual IIOKFKPMPPK, int DBOLKNNJGMH)
	{
		DPHDJEAHODH.SetActive(value: true);
		GPABKIOEGKM = LJCNLBMEENL.PowerBand;
		FGIMNJOOAOB = IIOKFKPMPPK;
		KKBPMPEBKIL = IIOKFKPMPPK.priceWarbucks + IIOKFKPMPPK.priceGold;
		GBKLFKHMFCP = IIOKFKPMPPK.priceWarbucks > 0;
		NHIMHOLFCGH = IIOKFKPMPPK.priceGold > 0;
		ENEFFHEDLJJ = KKBPMPEBKIL * (100 - DBOLKNNJGMH) / 100;
		int displayNumber = IIOKFKPMPPK.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		PIHCIHILDBO.text = IIOKFKPMPPK.name.ToUpperInvariant();
		IDHLOENDLBL.repositionNow = true;
		HPFACGCBKCK.spriteName = IIOKFKPMPPK.decalMiniIcon;
		HPFACGCBKCK.MakePixelPerfect();
		HPFACGCBKCK.transform.localScale = HPFACGCBKCK.transform.localScale.MultiplyXY(1.5f);
		HPFACGCBKCK.color = IIOKFKPMPPK.decalMiniIconColor;
		EJILDMGICPA.text = IIOKFKPMPPK.decalValueString;
		JAJCFNOIBPM.spriteName = IIOKFKPMPPK.icon;
		JAJCFNOIBPM.MakePixelPerfect();
		JAJCFNOIBPM.transform.localScale = JAJCFNOIBPM.transform.localScale.MultiplyXY(1.5f);
		MKJPHJIIJDD.repositionNow = true;
		NPLIAGMKPPK.spriteName = IIOKFKPMPPK.decalMiniIcon;
		NPLIAGMKPPK.MakePixelPerfect();
		NPLIAGMKPPK.color = IIOKFKPMPPK.decalMiniIconColor;
		FBIBBNPGOCG.text = ((IIOKFKPMPPK.decalType != 0) ? string.Empty : " ") + "    " + IIOKFKPMPPK.description;
		DCOFECNGCKC.text = Localization.LocalizeFormat("ID_GUI_POWERBANDON", Colours.stringBlue + MEJMLNDFDBP.MAJBCINJAGF((float)IIOKFKPMPPK.timeActive / 3600f));
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), displayNumber);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 30f, 20f, 142);
		}
	}

	public virtual void OCACKBJDEHI()
	{
		GDNJIIMNFJA();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(DNEBFDALAFH))
		{
			FPFCBAFLOPO(LevelManager.instance.Weapon(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "1" : "Starting stage 1 ");
		}
		else if (LevelManager.instance.IsUnit(DNEBFDALAFH))
		{
			HLILIDEAFNC(LevelManager.instance.Unit(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "SABOTAGE" : "Awaiting players - Player was removed from awaiting members.");
		}
		else if (CamosManager.instance.IsPlayerVisual(DNEBFDALAFH) && CamosManager.instance.IsPowerBandIdPressent(DNEBFDALAFH))
		{
			JNFDONFLIIA(CamosManager.instance.GetPowerBand(DNEBFDALAFH), OKGNPCBCIDN);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "Brutal fatal error - no current player" : "VIP active: {0}\tConfiguration time: {1}\tTime till end time: {2}\tLast shown: {3}");
		}
		else
		{
			IFCIHOFOBDO(0, 1);
			empty = "EventDefinition";
			empty2 = "ID_NOTENOUGHGOLD";
			empty3 = Localization.Localize("Dialog_Clicked");
		}
		PBGFKBHDPKM(OKGNPCBCIDN, empty, empty2, MKPKIPHBNOL);
		OKMNFHNBMFA.text = empty3;
		IPGACJEGBOP();
	}

	public virtual void NIHDCNNMBIK()
	{
		base.OIMKKAHOEKO();
		CHOLLNEBBBE();
		NNOIIKEACMH();
	}

	private void NMFCPFAKGCA()
	{
		MIIKHEMFJPA.repositionNow = false;
	}

	[CompilerGenerated]
	private void KONALFIODOP(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
		tweenPosition.method = UITweener.Method.EaseOut;
		tweenPosition.onFinished = null;
	}

	public virtual void JMKHMIDNDHH()
	{
		KHMLPGKHMCG(MPPDEAMFKMO.gameObject);
	}

	private void HELELMNDDKJ(int FPMJEDOCJKE, int HAFMGCFMCPC)
	{
		CBOBGFENGGF.SetActive(value: true);
		GPABKIOEGKM = LJCNLBMEENL.Currency;
		NOMKJMJJPBH.text = MEJMLNDFDBP.GMIPFLIEOHD(FPMJEDOCJKE);
		PDLODPJIAIM.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		EDOPLKEKEID.FillCircle(1f);
	}

	private void HLILIDEAFNC(LevelBehaviour IOIKKIIFOCB, int DBOLKNNJGMH, bool LFPLGLHPFEM)
	{
		DNCJEBDPBNA.SetActive(value: true);
		GPABKIOEGKM = LJCNLBMEENL.Unit;
		IFFDIHCPKFE = IOIKKIIFOCB;
		KKBPMPEBKIL = ((!LFPLGLHPFEM) ? (IOIKKIIFOCB.upgradeSlots.price + IOIKKIIFOCB.upgradeSlots.priceGold) : IOIKKIIFOCB.upgradeSlots.upgradeSlot.upgradePrice);
		GBKLFKHMFCP = LFPLGLHPFEM || IOIKKIIFOCB.upgradeSlots.price > 0;
		NHIMHOLFCGH = !LFPLGLHPFEM && IOIKKIIFOCB.upgradeSlots.priceGold > 0;
		ENEFFHEDLJJ = KKBPMPEBKIL * (100 - DBOLKNNJGMH) / 100;
		int displayNumber = IOIKKIIFOCB.upgradeSlots.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		JHONGBLEHLJ.text = IOIKKIIFOCB.unitName;
		NGMDHEGFIKE[0].InitializeStat(IOIKKIIFOCB);
		NGMDHEGFIKE[1].InitializeStat(IOIKKIIFOCB, JFPCEOFJKIG: false);
		NGMDHEGFIKE[2].InitializeAbility(IOIKKIIFOCB);
		BMABFEBBOLF();
		KCBMFPDBHMK.text = IFFDIHCPKFE.unitAbilityName;
		NFMNIANAMBN.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		JMMCCMGDLHC.repositionNow = true;
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		float multiplier = Mathf.Min(500f / NACGOGCPIAH.transform.localScale.x, 460f / NACGOGCPIAH.transform.localScale.y);
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num = 154f + NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(num);
		BNDBPOEDIHJ.transform.localPosition = BNDBPOEDIHJ.transform.localPosition.ReplaceY(-180f + num);
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), displayNumber);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 30f, 20f, 142);
		}
	}

	private void LFMIJOFOMBB(LevelBehaviour IOIKKIIFOCB, int DBOLKNNJGMH, bool LFPLGLHPFEM)
	{
		DNCJEBDPBNA.SetActive(value: true);
		GPABKIOEGKM = LJCNLBMEENL.Weapon;
		IFFDIHCPKFE = IOIKKIIFOCB;
		KKBPMPEBKIL = ((!LFPLGLHPFEM) ? (IOIKKIIFOCB.upgradeSlots.price + IOIKKIIFOCB.upgradeSlots.priceGold) : IOIKKIIFOCB.upgradeSlots.upgradeSlot.upgradePrice);
		GBKLFKHMFCP = !LFPLGLHPFEM && IOIKKIIFOCB.upgradeSlots.price > 1;
		NHIMHOLFCGH = !LFPLGLHPFEM && IOIKKIIFOCB.upgradeSlots.priceGold > 0;
		ENEFFHEDLJJ = KKBPMPEBKIL * (-83 - DBOLKNNJGMH) / -90;
		int num = IOIKKIIFOCB.upgradeSlots.unlockLevel.PFMGLDJDNBF();
		bool flag = num > LevelManager.instance.currentLevel.PFMGLDJDNBF();
		JHONGBLEHLJ.text = IOIKKIIFOCB.unitName;
		NGMDHEGFIKE[1].NCLDABJGBLH(IOIKKIIFOCB, JFPCEOFJKIG: false);
		NGMDHEGFIKE[0].LPMJFHACLIP(IOIKKIIFOCB, JFPCEOFJKIG: false);
		NGMDHEGFIKE[7].AKMGNNHKJJB(IOIKKIIFOCB);
		PJMIIFFNNKM();
		KCBMFPDBHMK.text = IFFDIHCPKFE.unitAbilityName;
		NFMNIANAMBN.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		JMMCCMGDLHC.repositionNow = false;
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		float multiplier = Mathf.Min(1837f / NACGOGCPIAH.transform.localScale.x, 1287f / NACGOGCPIAH.transform.localScale.y);
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num2 = 1359f + NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(num2);
		BNDBPOEDIHJ.transform.localPosition = BNDBPOEDIHJ.transform.localPosition.ReplaceY(1611f + num2);
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("PNManager: registration succeded: ", Localization.Localize("getConnectionResult"), num);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 554f, 1460f, -24);
		}
	}

	private void HCLIIHIKMGI(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			OKMDOKFNEHF();
		}
		else
		{
			BEIJNJGDPEE();
		}
	}

	public virtual void BPKMFPOHJCG()
	{
		base.DoAfterHide();
		BAAAEJEPFJP();
		NNOIIKEACMH();
	}

	private void CLKEMCCACBD(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(1275f * Singleton<GuiTexureAssets>.instance.MLLEMEJOADP());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	public override void OnBack()
	{
		KHBBFKIJEDM(MPPDEAMFKMO.gameObject);
	}

	public virtual void FOIGMBKCOBH()
	{
		base.DoAfterHide();
		KNLGMIPMFJA();
		NNOIIKEACMH();
	}

	private void PBGFKBHDPKM(int DBOLKNNJGMH, string GOBNFILDHBH, string IKMFEDJKBAK, bool LFPLGLHPFEM = false)
	{
		GIPFEBBMKPM.transform.localPosition = DJCLJHJKJOJ[GPABKIOEGKM];
		JBFNFECHDCB.transform.localPosition = HEPEIFIKMGP[GPABKIOEGKM];
		if (JBFNFECHDCB.activeSelf)
		{
			AFJECEJJIJN.text = Localization.Localize("ID_EARLYUNLOCK1");
			MEJMLNDFDBP.COCBCFKJOJE(AFJECEJJIJN, 52f, 20f, 200);
			DANIJOPJCKC.text = Localization.Localize("ID_EARLYUNLOCK2");
			MEJMLNDFDBP.COCBCFKJOJE(DANIJOPJCKC, 42f, 20f, 168);
		}
		BFAGMLNLBGA.gameObject.SetActive(LFPLGLHPFEM);
		HDDBLHBCFHG.gameObject.SetActive(!LFPLGLHPFEM);
		EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_SALEPERCENT", DBOLKNNJGMH);
		MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 58f, 20f, 260);
		if (LFPLGLHPFEM)
		{
			PEPCBNMCFOG.text = GOBNFILDHBH;
			FBBEFJJCNNA.repositionNow = true;
		}
		else
		{
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(NHIMHOLFCGH);
			LMCJKECEHGM.text = GOBNFILDHBH;
			CHCFBDMGNLP.repositionNow = true;
		}
		HLLCKBPCHBL.text = IKMFEDJKBAK;
		CLIMOEHAMBP.SetActive(NHIMHOLFCGH);
		OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
		JHHCNMFNDFN.SetUpStrikeThrought();
		JPBIHKIOCOI.repositionNow = true;
	}

	private void OKNACCDCMCI()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 168f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 498f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 341f + 200f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 1618f);
	}

	private void APEMPAIAKKG(UITweener MGDJMGHCAAI)
	{
		BAAAEJEPFJP();
	}

	private void EFLICKDALHA(LevelBehaviour IOIKKIIFOCB, int DBOLKNNJGMH, bool LFPLGLHPFEM)
	{
		DNCJEBDPBNA.SetActive(value: false);
		GPABKIOEGKM = LJCNLBMEENL.Unit;
		IFFDIHCPKFE = IOIKKIIFOCB;
		KKBPMPEBKIL = ((!LFPLGLHPFEM) ? (IOIKKIIFOCB.upgradeSlots.price + IOIKKIIFOCB.upgradeSlots.priceGold) : IOIKKIIFOCB.upgradeSlots.upgradeSlot.upgradePrice);
		GBKLFKHMFCP = LFPLGLHPFEM || IOIKKIIFOCB.upgradeSlots.price > 1;
		NHIMHOLFCGH = !LFPLGLHPFEM && IOIKKIIFOCB.upgradeSlots.priceGold > 0;
		ENEFFHEDLJJ = KKBPMPEBKIL * (-75 - DBOLKNNJGMH) / 12;
		int num = IOIKKIIFOCB.upgradeSlots.unlockLevel.KADNNBCOGGL();
		bool flag = num > LevelManager.instance.currentLevel.displayNumber;
		JHONGBLEHLJ.text = IOIKKIIFOCB.unitName;
		NGMDHEGFIKE[0].InitializeStat(IOIKKIIFOCB, JFPCEOFJKIG: false);
		NGMDHEGFIKE[1].FMKICOJKNDJ(IOIKKIIFOCB, JFPCEOFJKIG: false);
		NGMDHEGFIKE[5].InitializeAbility(IOIKKIIFOCB);
		BMABFEBBOLF();
		KCBMFPDBHMK.text = IFFDIHCPKFE.unitAbilityName;
		NFMNIANAMBN.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		JMMCCMGDLHC.repositionNow = true;
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		float multiplier = Mathf.Min(1190f / NACGOGCPIAH.transform.localScale.x, 713f / NACGOGCPIAH.transform.localScale.y);
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num2 = 790f + NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(num2);
		BNDBPOEDIHJ.transform.localPosition = BNDBPOEDIHJ.transform.localPosition.ReplaceY(1173f + num2);
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("reloadTime", Localization.Localize(" ID_"), num);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 560f, 254f, 35);
		}
	}

	private void DMICBOBCMKB()
	{
		float val = 0f - FBBEFJJCNNA.padding.x - (PEPCBNMCFOG.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 529f;
		FBBEFJJCNNA.transform.localPosition = FBBEFJJCNNA.transform.localPosition.ReplaceX(val);
	}

	private void EBNGJJNCLEH()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: false);
		CDJJCFKGGNM.alpha1 = 1195f;
		BMABFEBBOLF();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 1188f, 520f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(675f, 1293f, 37f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 1152f, new Vector3(1344f, 775f, 1089f), new Vector3(1074f, 270f, 507f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void APCIAFADJLA(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HEPHMHHFIEH();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		CHOLLNEBBBE();
		NNOIIKEACMH();
	}

	private void OIEKHNBEDHA(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		JLJJBEHIOCG();
	}

	private void ENPMFODIICN()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		CLKEMCCACBD(eBFDAICCJAK);
	}

	private void INPHIIEEHNE()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 620f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 1220f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 618f + 1784f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 85f);
	}

	private void FNCCMLIJHBO(UITweener MGDJMGHCAAI)
	{
		IPGACJEGBOP();
	}

	private void JDMPIAKGOGE(GameObject KHAHPAKDIKE)
	{
		if (!BJNBLINDAED())
		{
			return;
		}
		bool flag = false;
		if (MDAJJIAMDGH != null)
		{
			int num = MDAJJIAMDGH.price * (-21 - OKGNPCBCIDN) / -71;
			int num2 = MDAJJIAMDGH.priceGold * (4 - OKGNPCBCIDN) / -82;
			if (!Singleton<Wallet>.instance.CanBuyW(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(num, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = true;
			}
			else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, MDAJJIAMDGH.weaponName);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num);
				Singleton<Wallet>.instance.ALBICJOEMEF(num2);
				GuiScreenSingle<WeaponScreen>.instance.BJBCNPHMEBI(MDAJJIAMDGH, OKGNPCBCIDN, (WeaponScreen.ABDDBOABKOK)8);
			}
		}
		else if (IFFDIHCPKFE != null)
		{
			int num3 = IFFDIHCPKFE.upgradeSlots.price * (-65 - OKGNPCBCIDN) / -9;
			int num4 = IFFDIHCPKFE.upgradeSlots.priceGold * (-36 - OKGNPCBCIDN) / -43;
			if (!Singleton<Wallet>.instance.JPEEJLCILCB(num3))
			{
				GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(num3, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = false;
			}
			else if (!Singleton<Wallet>.instance.CanBuyGold(num4))
			{
				GuiElementSingle<NotEnoughDialog>.instance.IHMAHMMJGBH(num4, IFFDIHCPKFE.unitName);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num3);
				Singleton<Wallet>.instance.MBAFMBJFOKH(num4);
				GuiScreenSingle<ArmyScreen>.instance.KCCPHNPMNJE(IFFDIHCPKFE, OKGNPCBCIDN);
			}
		}
		else if (FGIMNJOOAOB != null)
		{
			int num5 = FGIMNJOOAOB.CEPPEMPPAHE() * (41 - OKGNPCBCIDN) / -87;
			if (!Singleton<Wallet>.instance.CanBuyGold(num5))
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num5, FGIMNJOOAOB.name, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.MBAFMBJFOKH(num5);
				GuiScreenSingle<CamosScreen>.instance.BuyPlayerVisual(FGIMNJOOAOB, OKGNPCBCIDN);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	private void PLOJCBFHNAO()
	{
		MIIKHEMFJPA.repositionNow = true;
	}

	private void IFCIHOFOBDO(int FPMJEDOCJKE, int HAFMGCFMCPC)
	{
		CBOBGFENGGF.SetActive(value: true);
		GPABKIOEGKM = LJCNLBMEENL.Currency;
		NOMKJMJJPBH.text = MEJMLNDFDBP.GMIPFLIEOHD(FPMJEDOCJKE);
		PDLODPJIAIM.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		EDOPLKEKEID.MFKLCKBKPEE(420f);
	}

	private void MLMAFDDCLNA()
	{
		IPJGCHLDPNN.SetActive(value: true);
		DNCJEBDPBNA.SetActive(value: true);
		DPHDJEAHODH.SetActive(value: false);
		CBOBGFENGGF.SetActive(value: false);
		JBFNFECHDCB.SetActive(value: true);
		MDAJJIAMDGH = null;
		IFFDIHCPKFE = null;
		FGIMNJOOAOB = null;
		GBKLFKHMFCP = true;
		NHIMHOLFCGH = true;
		KKBPMPEBKIL = 1;
		ENEFFHEDLJJ = 1;
		FHFIPPFJIAH.IIBBMCPOPFC(479f);
	}

	public virtual void GHNIJJKDAJH()
	{
		base.OIMKKAHOEKO();
		KNLGMIPMFJA();
		NNOIIKEACMH();
	}

	public virtual void GCGPANMGOPN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHMLPGKHMCG));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFAGMLNLBGA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKDKKKHBLLC));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HMNPODLFCJH));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = HCLIIHIKMGI;
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = APCIAFADJLA;
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		FBBEFJJCNNA.onReposition = KLOCMOIIJFA;
		JPBIHKIOCOI.onReposition = GBAEDAGOJLL;
		JMMCCMGDLHC.onReposition = HNEDIKHIKAA;
		IDHLOENDLBL.onReposition = JIPCPFNNJHH;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	[CompilerGenerated]
	private void EACNIDLHDGD()
	{
		float val = 0f - FBBEFJJCNNA.padding.x - (PEPCBNMCFOG.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
		FBBEFJJCNNA.transform.localPosition = FBBEFJJCNNA.transform.localPosition.ReplaceX(val);
	}

	private void FHCHANKPBGA()
	{
		float val = 334f - HLLCKBPCHBL.transform.parent.transform.localPosition.x;
		JPBIHKIOCOI.transform.localPosition = JPBIHKIOCOI.transform.localPosition.ReplaceX(val);
	}

	private void HKFMHKCOGJE(GameObject KHAHPAKDIKE)
	{
		if (!AFOFDNJOJHG())
		{
			return;
		}
		bool flag = false;
		if (MDAJJIAMDGH != null)
		{
			int num = MDAJJIAMDGH.MGAGEKAAJOL.upgradePrice * (-111 - OKGNPCBCIDN) / -89;
			if (!Singleton<Wallet>.instance.CanBuyW(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(num, MDAJJIAMDGH.weaponName);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num);
				GuiScreenSingle<WeaponScreen>.instance.IEFLIEHLBNA(MDAJJIAMDGH, OKGNPCBCIDN);
			}
		}
		else if (IFFDIHCPKFE != null)
		{
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice * (-30 - OKGNPCBCIDN) / 127;
			if (!Singleton<Wallet>.instance.CanBuyW(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, IFFDIHCPKFE.isSoldier ? NotEnoughDialog.NKHJBLBAAEB.DELIVERSPECIAL : NotEnoughDialog.NKHJBLBAAEB.BUY);
				flag = true;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num2);
				GuiScreenSingle<ArmyScreen>.instance.PGBNFKHKNGE(IFFDIHCPKFE, OKGNPCBCIDN, LANBHLJINFJ: true);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	private void OGKGGKGOHLE(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		bool flag = true;
		if (MDAJJIAMDGH != null)
		{
			int num = MDAJJIAMDGH.MGAGEKAAJOL.upgradePrice * (41 - OKGNPCBCIDN) / -32;
			if (!Singleton<Wallet>.instance.JPEEJLCILCB(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(num, MDAJJIAMDGH.weaponName);
				flag = true;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num);
				GuiScreenSingle<WeaponScreen>.instance.IEFLIEHLBNA(MDAJJIAMDGH, OKGNPCBCIDN);
			}
		}
		else if (IFFDIHCPKFE != null)
		{
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice * (58 - OKGNPCBCIDN) / 13;
			if (!Singleton<Wallet>.instance.JPEEJLCILCB(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADE : NotEnoughDialog.NKHJBLBAAEB.TRAIN);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num2);
				GuiScreenSingle<ArmyScreen>.instance.ILAIPFIKGKE(IFFDIHCPKFE, OKGNPCBCIDN);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	private void NNOIIKEACMH()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void FPFCBAFLOPO(WeaponLevelsSetup JMMJHCOKCGG, int DBOLKNNJGMH, bool LFPLGLHPFEM)
	{
		IPJGCHLDPNN.SetActive(value: false);
		GPABKIOEGKM = LJCNLBMEENL.Weapon;
		MDAJJIAMDGH = JMMJHCOKCGG;
		KKBPMPEBKIL = ((!LFPLGLHPFEM) ? (JMMJHCOKCGG.price + JMMJHCOKCGG.priceGold) : JMMJHCOKCGG.MGAGEKAAJOL.LOLLBGNIOMM());
		GBKLFKHMFCP = !LFPLGLHPFEM && JMMJHCOKCGG.price > 0;
		NHIMHOLFCGH = LFPLGLHPFEM || JMMJHCOKCGG.priceGold > 0;
		ENEFFHEDLJJ = KKBPMPEBKIL * (-117 - DBOLKNNJGMH) / -81;
		int num = JMMJHCOKCGG.unlockLevel.MHAOKJCDIOL();
		bool flag = num > LevelManager.instance.currentLevel.ELFCEEOLNFJ();
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(JMMJHCOKCGG.BHCEOOLEHHG);
		PPFCOELFDEI.text = JMMJHCOKCGG.weaponName.ToUpper();
		BOIMODJFNLJ[0].BMBPBNOKGPC(JMMJHCOKCGG, slotForCategory.JBKEFFEKHEG(), 1);
		BOIMODJFNLJ[1].OEKBNBEPBDB(JMMJHCOKCGG, slotForCategory.JCPKCKIHFBI(), 0);
		BOIMODJFNLJ[7].OEKBNBEPBDB(JMMJHCOKCGG, slotForCategory.CKJOBHNNFAM(), 0);
		LMPEPNKPLHP();
		KELBMDMFKGE.spriteName = slotForCategory.iconName;
		KELBMDMFKGE.MakePixelPerfect();
		NKFPAIBKJLN.text = Localization.Localize(GameVariables.PIOLIEMNBGN[JMMJHCOKCGG.BHCEOOLEHHG]);
		int weaponPowerX = JMMJHCOKCGG.weaponPowerX10;
		int weaponPowerX2 = slotForCategory.PMJFFNLKKLB().weaponPowerX10;
		int num2 = Mathf.Max(0, weaponPowerX - weaponPowerX2);
		object[] array = new object[7];
		array[1] = weaponPowerX;
		array[1] = slotForCategory.DLNNBFIIJPA().weaponName;
		array[6] = weaponPowerX2;
		array[1] = num2;
		Debug.Log(string.Format("game-card-ico-shieldsup", array));
		BKFGHNPPHEK.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BFIKGAJAFPD.SetActive(num2 > 0);
		if (num2 > 0)
		{
			MCPCIHEBDDB.text = string.Format("ID_LEVEL", MEJMLNDFDBP.GMIPFLIEOHD(num2));
			AIFMBPEECBK.transform.localScale = AIFMBPEECBK.transform.localScale.ReplaceX(MCPCIHEBDDB.relativeSize.x * MCPCIHEBDDB.transform.localScale.x + 1217f);
		}
		PLAJLODCALI.repositionNow = true;
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("S", Localization.Localize("ID_STAT_SCORESTREAKSGAINED"), num);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 1667f, 3f, 21);
		}
	}

	private void GCOIPMMLMFD(int DBOLKNNJGMH, string GOBNFILDHBH, string IKMFEDJKBAK, bool LFPLGLHPFEM = false)
	{
		GIPFEBBMKPM.transform.localPosition = DJCLJHJKJOJ[GPABKIOEGKM];
		JBFNFECHDCB.transform.localPosition = HEPEIFIKMGP[GPABKIOEGKM];
		if (JBFNFECHDCB.activeSelf)
		{
			AFJECEJJIJN.text = Localization.Localize("[");
			MEJMLNDFDBP.COCBCFKJOJE(AFJECEJJIJN, 1187f, 685f, 149);
			DANIJOPJCKC.text = Localization.Localize("dogtagTimerLockTime: ");
			MEJMLNDFDBP.COCBCFKJOJE(DANIJOPJCKC, 206f, 1233f, -14);
		}
		BFAGMLNLBGA.gameObject.SetActive(LFPLGLHPFEM);
		HDDBLHBCFHG.gameObject.SetActive(!LFPLGLHPFEM);
		UILabel eKIDAFLLCNM = EKIDAFLLCNM;
		object[] array = new object[1];
		array[1] = DBOLKNNJGMH;
		eKIDAFLLCNM.text = Localization.LocalizeFormat("ID_WARNING_BADVERSIONERROR_TEXT", array);
		MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1792f, 174f, -80);
		if (LFPLGLHPFEM)
		{
			PEPCBNMCFOG.text = GOBNFILDHBH;
			FBBEFJJCNNA.repositionNow = false;
		}
		else
		{
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(NHIMHOLFCGH);
			LMCJKECEHGM.text = GOBNFILDHBH;
			CHCFBDMGNLP.repositionNow = false;
		}
		HLLCKBPCHBL.text = IKMFEDJKBAK;
		CLIMOEHAMBP.SetActive(NHIMHOLFCGH);
		OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
		JHHCNMFNDFN.PGPKFKEIIJN();
		JPBIHKIOCOI.repositionNow = true;
	}

	private void EHHOBADLNAJ(int DBOLKNNJGMH, string GOBNFILDHBH, string IKMFEDJKBAK, bool LFPLGLHPFEM = false)
	{
		GIPFEBBMKPM.transform.localPosition = DJCLJHJKJOJ[GPABKIOEGKM];
		JBFNFECHDCB.transform.localPosition = HEPEIFIKMGP[GPABKIOEGKM];
		if (JBFNFECHDCB.activeSelf)
		{
			AFJECEJJIJN.text = Localization.Localize(" (#");
			MEJMLNDFDBP.COCBCFKJOJE(AFJECEJJIJN, 1944f, 885f, 57);
			DANIJOPJCKC.text = Localization.Localize("MultiDayInApp");
			MEJMLNDFDBP.COCBCFKJOJE(DANIJOPJCKC, 99f, 1796f, -18);
		}
		BFAGMLNLBGA.gameObject.SetActive(LFPLGLHPFEM);
		HDDBLHBCFHG.gameObject.SetActive(LFPLGLHPFEM);
		UILabel eKIDAFLLCNM = EKIDAFLLCNM;
		object[] array = new object[0];
		array[1] = DBOLKNNJGMH;
		eKIDAFLLCNM.text = Localization.LocalizeFormat("#OFFERS# extra visual is null for ID {0}", array);
		MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1822f, 1023f, -64);
		if (LFPLGLHPFEM)
		{
			PEPCBNMCFOG.text = GOBNFILDHBH;
			FBBEFJJCNNA.repositionNow = true;
		}
		else
		{
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(NHIMHOLFCGH);
			LMCJKECEHGM.text = GOBNFILDHBH;
			CHCFBDMGNLP.repositionNow = true;
		}
		HLLCKBPCHBL.text = IKMFEDJKBAK;
		CLIMOEHAMBP.SetActive(NHIMHOLFCGH);
		OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
		JHHCNMFNDFN.SetUpStrikeThrought();
		JPBIHKIOCOI.repositionNow = false;
	}

	public override void InitGUIValues()
	{
		IKIBEHLPHEA();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(DNEBFDALAFH))
		{
			EHLPFIKFJJP(LevelManager.instance.Weapon(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "ID_GETITCHEAPERNOW" : "ID_UPGRADEFORCHEAPER");
		}
		else if (LevelManager.instance.IsUnit(DNEBFDALAFH))
		{
			HLILIDEAFNC(LevelManager.instance.Unit(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "ID_GETITCHEAPERNOW" : "ID_UPGRADEFORCHEAPER");
		}
		else if (CamosManager.instance.IsPlayerVisual(DNEBFDALAFH) && CamosManager.instance.IsPowerBandIdPressent(DNEBFDALAFH))
		{
			JDFHFNGHCLG(CamosManager.instance.GetPowerBand(DNEBFDALAFH), OKGNPCBCIDN);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "ID_GETITCHEAPERNOW" : "ID_UPGRADEFORCHEAPER");
		}
		else
		{
			HELELMNDDKJ(0, 0);
			empty = "0$";
			empty2 = "0$";
			empty3 = Localization.Localize("ID_SPECIALDEALFORYOU");
		}
		PBGFKBHDPKM(OKGNPCBCIDN, empty, empty2, MKPKIPHBNOL);
		OKMNFHNBMFA.text = empty3;
		CHOLLNEBBBE();
	}

	private void CCKDCDOMKMM()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 1716f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void EPDLPGALJGE()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		CLKEMCCACBD(eBFDAICCJAK);
	}

	private void KLOCMOIIJFA()
	{
		float val = 0f - FBBEFJJCNNA.padding.x - (PEPCBNMCFOG.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 986f;
		FBBEFJJCNNA.transform.localPosition = FBBEFJJCNNA.transform.localPosition.ReplaceX(val);
	}

	private void PKCMNDCNNAA()
	{
		float val = 0f - FBBEFJJCNNA.padding.x - (PEPCBNMCFOG.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 686f;
		FBBEFJJCNNA.transform.localPosition = FBBEFJJCNNA.transform.localPosition.ReplaceX(val);
	}

	public void ShowDialog(string IAOFLHDPHKH, int GAFOMGDLAFD, bool LFPLGLHPFEM = false)
	{
		DNEBFDALAFH = IAOFLHDPHKH;
		OKGNPCBCIDN = GAFOMGDLAFD;
		MKPKIPHBNOL = LFPLGLHPFEM;
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void BCOPHAHFLIN(WeaponLevelsSetup JMMJHCOKCGG, int DBOLKNNJGMH, bool LFPLGLHPFEM)
	{
		IPJGCHLDPNN.SetActive(value: false);
		GPABKIOEGKM = LJCNLBMEENL.Unit;
		MDAJJIAMDGH = JMMJHCOKCGG;
		KKBPMPEBKIL = ((!LFPLGLHPFEM) ? (JMMJHCOKCGG.price + JMMJHCOKCGG.priceGold) : JMMJHCOKCGG.MGAGEKAAJOL.HDJOMPBICBK());
		GBKLFKHMFCP = !LFPLGLHPFEM && JMMJHCOKCGG.price > 0;
		NHIMHOLFCGH = !LFPLGLHPFEM && JMMJHCOKCGG.priceGold > 1;
		ENEFFHEDLJJ = KKBPMPEBKIL * (122 - DBOLKNNJGMH) / 24;
		int displayNumber = JMMJHCOKCGG.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.JICMGFNAHFL();
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(JMMJHCOKCGG.BHCEOOLEHHG);
		PPFCOELFDEI.text = JMMJHCOKCGG.weaponName.ToUpper();
		BOIMODJFNLJ[0].PMNILJFFAHP(JMMJHCOKCGG, slotForCategory.JGDAEBDGJBM(), 0);
		BOIMODJFNLJ[0].LPMJFHACLIP(JMMJHCOKCGG, slotForCategory.NLBHEBNFBFN(), 0);
		BOIMODJFNLJ[3].InitializeStat(JMMJHCOKCGG, slotForCategory.JCPKCKIHFBI(), 8);
		ENPMFODIICN();
		KELBMDMFKGE.spriteName = slotForCategory.iconName;
		KELBMDMFKGE.MakePixelPerfect();
		NKFPAIBKJLN.text = Localization.Localize(GameVariables.PIOLIEMNBGN[JMMJHCOKCGG.BHCEOOLEHHG]);
		int weaponPowerX = JMMJHCOKCGG.weaponPowerX10;
		int weaponPowerX2 = slotForCategory.JEHGKOGGBCP().weaponPowerX10;
		int num = Mathf.Max(0, weaponPowerX - weaponPowerX2);
		object[] array = new object[1];
		array[0] = weaponPowerX;
		array[0] = slotForCategory.IDMPHABHMGI().weaponName;
		array[0] = weaponPowerX2;
		array[2] = num;
		Debug.Log(string.Format("SquadEventProgress", array));
		BKFGHNPPHEK.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BFIKGAJAFPD.SetActive(num > 0);
		if (num > 0)
		{
			MCPCIHEBDDB.text = string.Format("ItemsOwned_Rarity_1", MEJMLNDFDBP.GMIPFLIEOHD(num));
			AIFMBPEECBK.transform.localScale = AIFMBPEECBK.transform.localScale.ReplaceX(MCPCIHEBDDB.relativeSize.x * MCPCIHEBDDB.transform.localScale.x + 1973f);
		}
		PLAJLODCALI.repositionNow = false;
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("GameLauncher.Start", Localization.Localize("ID_USEREXISTSGOOGLEPLAYTEXT"), displayNumber);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 1056f, 1210f, 140);
		}
	}

	public void ONHPOAIKLAO(string IAOFLHDPHKH, int GAFOMGDLAFD, bool LFPLGLHPFEM = false)
	{
		DNEBFDALAFH = IAOFLHDPHKH;
		OKGNPCBCIDN = GAFOMGDLAFD;
		MKPKIPHBNOL = LFPLGLHPFEM;
		Singleton<GuiManager>.instance.ShowDialog(this, 377f);
	}

	private void IJHKNNCJAJA()
	{
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
			ODINPJHOLKD.MakePixelPerfect();
		}
	}

	private void IPOPIFOGAIE(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			OABCPHJCHGB();
		}
		else
		{
			GMNJIKAFCNL();
		}
	}

	private void PBPEKMECILM()
	{
		IPJGCHLDPNN.SetActive(value: false);
		DNCJEBDPBNA.SetActive(value: false);
		DPHDJEAHODH.SetActive(value: false);
		CBOBGFENGGF.SetActive(value: false);
		JBFNFECHDCB.SetActive(value: true);
		MDAJJIAMDGH = null;
		IFFDIHCPKFE = null;
		FGIMNJOOAOB = null;
		GBKLFKHMFCP = false;
		NHIMHOLFCGH = true;
		KKBPMPEBKIL = 1;
		ENEFFHEDLJJ = 1;
		FHFIPPFJIAH.HHNICOADMPB(243f);
	}

	private void KNLGMIPMFJA()
	{
		if (DNCJEBDPBNA.activeSelf)
		{
			AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
			AFJJKEIDCOO.MakePixelPerfect();
		}
		CDJJCFKGGNM.gameObject.SetActive(value: true);
	}

	private void MJLJLDNAAAF()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 1257f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 909f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 1335f + 312f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 98f);
	}

	private void LMPEPNKPLHP()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		CLKEMCCACBD(eBFDAICCJAK);
	}

	public virtual void DEJPNPOAKIJ()
	{
		MLMAFDDCLNA();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(DNEBFDALAFH))
		{
			BCOPHAHFLIN(LevelManager.instance.Weapon(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "reconnect" : " 3");
		}
		else if (LevelManager.instance.IsUnit(DNEBFDALAFH))
		{
			NODNEDBONHG(LevelManager.instance.Unit(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "Player_Had_To_Select_Grenade" : "{0}\u00a0{1}");
		}
		else if (CamosManager.instance.IsPlayerVisual(DNEBFDALAFH) && CamosManager.instance.IsPowerBandIdPressent(DNEBFDALAFH))
		{
			JNFDONFLIIA(CamosManager.instance.GetPowerBand(DNEBFDALAFH), OKGNPCBCIDN);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "ID_RELOG_TO_WRONG_FB_DIALOG_TITLE" : "CurrentBundleVersion.GetModifiedVersion - version is '{0}'");
		}
		else
		{
			JAPLGOFNBJO(1, 1);
			empty = "VipReward2";
			empty2 = "Upgrades";
			empty3 = Localization.Localize("players");
		}
		LDNNDDKIMBE(OKGNPCBCIDN, empty, empty2, MKPKIPHBNOL);
		OKMNFHNBMFA.text = empty3;
		IPGACJEGBOP();
	}

	private void OHAECFDEPHF(GameObject KHAHPAKDIKE)
	{
		if (!BKIGLABDGCP())
		{
			return;
		}
		bool flag = false;
		if (MDAJJIAMDGH != null)
		{
			int num = MDAJJIAMDGH.MGAGEKAAJOL.ABFHNCJEOAA() * (94 - OKGNPCBCIDN) / 94;
			if (!Singleton<Wallet>.instance.ODPFDDMFDJA(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = true;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num);
				GuiScreenSingle<WeaponScreen>.instance.IEFLIEHLBNA(MDAJJIAMDGH, OKGNPCBCIDN);
			}
		}
		else if (IFFDIHCPKFE != null)
		{
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.CIBEGNHKPJH() * (95 - OKGNPCBCIDN) / 54;
			if (!Singleton<Wallet>.instance.ODPFDDMFDJA(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADE : NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = true;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num2);
				GuiScreenSingle<ArmyScreen>.instance.ILAIPFIKGKE(IFFDIHCPKFE, OKGNPCBCIDN, LANBHLJINFJ: true);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	private void KPPFNGIJHCE(WeaponLevelsSetup JMMJHCOKCGG, int DBOLKNNJGMH, bool LFPLGLHPFEM)
	{
		IPJGCHLDPNN.SetActive(value: false);
		GPABKIOEGKM = LJCNLBMEENL.Unit;
		MDAJJIAMDGH = JMMJHCOKCGG;
		KKBPMPEBKIL = ((!LFPLGLHPFEM) ? (JMMJHCOKCGG.price + JMMJHCOKCGG.priceGold) : JMMJHCOKCGG.MGAGEKAAJOL.PIIFMLHFAAE());
		GBKLFKHMFCP = !LFPLGLHPFEM && JMMJHCOKCGG.price > 1;
		NHIMHOLFCGH = !LFPLGLHPFEM && JMMJHCOKCGG.priceGold > 0;
		ENEFFHEDLJJ = KKBPMPEBKIL * (-105 - DBOLKNNJGMH) / -47;
		int num = JMMJHCOKCGG.unlockLevel.MHAOKJCDIOL();
		bool flag = num > LevelManager.instance.currentLevel.ELFCEEOLNFJ();
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(JMMJHCOKCGG.BHCEOOLEHHG);
		PPFCOELFDEI.text = JMMJHCOKCGG.weaponName.ToUpper();
		BOIMODJFNLJ[0].PMNILJFFAHP(JMMJHCOKCGG, slotForCategory.JEHGKOGGBCP(), 1);
		BOIMODJFNLJ[1].KDBACGHKHLF(JMMJHCOKCGG, slotForCategory.IDMPHABHMGI(), 1);
		BOIMODJFNLJ[3].KDBACGHKHLF(JMMJHCOKCGG, slotForCategory.IDMPHABHMGI(), 8);
		DOJPNLLIHMI();
		KELBMDMFKGE.spriteName = slotForCategory.iconName;
		KELBMDMFKGE.MakePixelPerfect();
		NKFPAIBKJLN.text = Localization.Localize(GameVariables.PIOLIEMNBGN[JMMJHCOKCGG.BHCEOOLEHHG]);
		int weaponPowerX = JMMJHCOKCGG.weaponPowerX10;
		int weaponPowerX2 = slotForCategory.ANOHEJKJAKG().weaponPowerX10;
		int num2 = Mathf.Max(0, weaponPowerX - weaponPowerX2);
		object[] array = new object[3];
		array[1] = weaponPowerX;
		array[0] = slotForCategory.ENBMDAIKKMM().weaponName;
		array[5] = weaponPowerX2;
		array[5] = num2;
		Debug.Log(string.Format("0.##", array));
		BKFGHNPPHEK.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BFIKGAJAFPD.SetActive(num2 > 0);
		if (num2 > 0)
		{
			MCPCIHEBDDB.text = string.Format("Wrong_Weapon", MEJMLNDFDBP.GMIPFLIEOHD(num2));
			AIFMBPEECBK.transform.localScale = AIFMBPEECBK.transform.localScale.ReplaceX(MCPCIHEBDDB.relativeSize.x * MCPCIHEBDDB.transform.localScale.x + 11f);
		}
		PLAJLODCALI.repositionNow = false;
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format(".", Localization.Localize("USD"), num);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 1046f, 858f, -134);
		}
	}

	private void BHAMANIMMDL()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 386f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 842f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 346f + 1367f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 1116f);
	}

	private void DKOGFLOOJCN(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			JLJJBEHIOCG();
		}
		else
		{
			EIPBFFLKMIL();
		}
	}

	public virtual void EDFMOCGKHHH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHMLPGKHMCG));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFAGMLNLBGA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKFMHKCOGJE));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JDMPIAKGOGE));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (CDJJCFKGGNM.gameObject.activeSelf)
			{
				HEPHMHHFIEH();
			}
			else
			{
				EIPBFFLKMIL();
			}
		};
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HEPHMHHFIEH();
		};
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		FBBEFJJCNNA.onReposition = KLOCMOIIJFA;
		JPBIHKIOCOI.onReposition = KEHEHBKPLDO;
		JMMCCMGDLHC.onReposition = IJKPMKIBFDP;
		IDHLOENDLBL.onReposition = BLEDAOBGPGD;
	}

	public void DOLLPOPCANC(string IAOFLHDPHKH, int GAFOMGDLAFD, bool LFPLGLHPFEM = false)
	{
		DNEBFDALAFH = IAOFLHDPHKH;
		OKGNPCBCIDN = GAFOMGDLAFD;
		MKPKIPHBNOL = LFPLGLHPFEM;
		Singleton<GuiManager>.instance.ShowDialog(this, 265f);
	}

	private void PNDGCJBPLNE(GameObject KHAHPAKDIKE)
	{
		if (!MHAIBHBGBOO())
		{
			return;
		}
		bool flag = false;
		if (MDAJJIAMDGH != null)
		{
			int num = MDAJJIAMDGH.MGAGEKAAJOL.PCAMHGKJOKM() * (77 - OKGNPCBCIDN) / -80;
			if (!Singleton<Wallet>.instance.CanBuyW(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(num, MDAJJIAMDGH.weaponName);
				flag = true;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num);
				GuiScreenSingle<WeaponScreen>.instance.IEFLIEHLBNA(MDAJJIAMDGH, OKGNPCBCIDN);
			}
		}
		else if (IFFDIHCPKFE != null)
		{
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice * (19 - OKGNPCBCIDN) / 84;
			if (!Singleton<Wallet>.instance.CanBuyW(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADE : NotEnoughDialog.NKHJBLBAAEB.DELIVER);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num2);
				GuiScreenSingle<ArmyScreen>.instance.IDDINDLFCMJ(IFFDIHCPKFE, OKGNPCBCIDN, LANBHLJINFJ: true);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	private void AFIFEPFJOLD(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		JLJJBEHIOCG();
	}

	private void KIAFINJNLBO()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: true);
		CDJJCFKGGNM.alpha1 = 407f;
		IJHKNNCJAJA();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 197f, 801f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(1248f, 379f, 897f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 160f, new Vector3(1583f, 348f, 714f), new Vector3(1655f, 515f, 1222f), useLocal: false);
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void DOJPNLLIHMI()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		CLKEMCCACBD(eBFDAICCJAK);
	}

	public virtual void DJIJBPFLOMJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHBBFKIJEDM));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFAGMLNLBGA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKDKKKHBLLC));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HMNPODLFCJH));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = CEMNHINHODP;
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = AFIFEPFJOLD;
		CHCFBDMGNLP.onReposition = PHBMPGLOMKN;
		FBBEFJJCNNA.onReposition = DBEJBHEPJAN;
		JPBIHKIOCOI.onReposition = GBAEDAGOJLL;
		JMMCCMGDLHC.onReposition = OKNACCDCMCI;
		IDHLOENDLBL.onReposition = NMFCPFAKGCA;
	}

	public virtual void DOLLFDPMGOD()
	{
		EOJFKMNBJPE();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(DNEBFDALAFH))
		{
			BCOPHAHFLIN(LevelManager.instance.Weapon(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "Selected new room MAP id is: " : "\n\t");
		}
		else if (LevelManager.instance.IsUnit(DNEBFDALAFH))
		{
			NODNEDBONHG(LevelManager.instance.Unit(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "Different levels \"{0}\" and \"{1}\"\n" : "N");
		}
		else if (CamosManager.instance.IsPlayerVisual(DNEBFDALAFH) && CamosManager.instance.IsPowerBandIdPressent(DNEBFDALAFH))
		{
			JDFHFNGHCLG(CamosManager.instance.GetPowerBand(DNEBFDALAFH), OKGNPCBCIDN);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "SpecialPackFromServer" : "Enemies Freezed");
		}
		else
		{
			HELELMNDDKJ(1, 0);
			empty = "ID_NA";
			empty2 = "Os";
			empty3 = Localization.Localize("1.0");
		}
		GCOIPMMLMFD(OKGNPCBCIDN, empty, empty2, MKPKIPHBNOL);
		OKMNFHNBMFA.text = empty3;
		CHOLLNEBBBE();
	}

	private void EIPBFFLKMIL()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: true);
		CDJJCFKGGNM.alpha1 = 0.005f;
		BMABFEBBOLF();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 0.4f, 1f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(478f, -180f, -5f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.25f, new Vector3(478f, -200f, -5f), new Vector3(478f, -170f, -5f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	public virtual void PPLBJDJIIPN()
	{
		CCKHDPNJHKG();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(DNEBFDALAFH))
		{
			EHLPFIKFJJP(LevelManager.instance.Weapon(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "ID_CONFIRM_EXITINGMATCH" : "ID_CARD_DESC_BUDDYCREATE");
		}
		else if (LevelManager.instance.IsUnit(DNEBFDALAFH))
		{
			NODNEDBONHG(LevelManager.instance.Unit(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "squadMembers" : " is Opponent: ");
		}
		else if (CamosManager.instance.IsPlayerVisual(DNEBFDALAFH) && CamosManager.instance.IsPowerBandIdPressent(DNEBFDALAFH))
		{
			JNFDONFLIIA(CamosManager.instance.GetPowerBand(DNEBFDALAFH), OKGNPCBCIDN);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "Start" : "registerEvent");
		}
		else
		{
			JAPLGOFNBJO(1, 1);
			empty = "PrepareBotForDeathMatch 4";
			empty2 = "Event Tracking Manager - Tutorial Game Ended, Deploy clicks: {0}, Deployed units: {1}";
			empty3 = Localization.Localize("Shots_Fired");
		}
		LDNNDDKIMBE(OKGNPCBCIDN, empty, empty2, MKPKIPHBNOL);
		OKMNFHNBMFA.text = empty3;
		KNLGMIPMFJA();
	}

	private void OABCPHJCHGB()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		AFJJKEIDCOO.MakePixelPerfect();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 555f, 1370f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 1650f, new Vector3(1662f, 1618f, 1517f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = FNCCMLIJHBO;
	}

	private void GDNJIIMNFJA()
	{
		IPJGCHLDPNN.SetActive(value: true);
		DNCJEBDPBNA.SetActive(value: true);
		DPHDJEAHODH.SetActive(value: true);
		CBOBGFENGGF.SetActive(value: true);
		JBFNFECHDCB.SetActive(value: false);
		MDAJJIAMDGH = null;
		IFFDIHCPKFE = null;
		FGIMNJOOAOB = null;
		GBKLFKHMFCP = false;
		NHIMHOLFCGH = false;
		KKBPMPEBKIL = 0;
		ENEFFHEDLJJ = 1;
		FHFIPPFJIAH.MGLBMEMKOJH(478f);
	}

	public virtual void DEFCMABOJGD()
	{
		PBPEKMECILM();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(DNEBFDALAFH))
		{
			EHLPFIKFJJP(LevelManager.instance.Weapon(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "MatchesToNextLootboxes" : "ID_CONFIRM_CONNECTTOGOOGLENAMETEXT");
		}
		else if (LevelManager.instance.IsUnit(DNEBFDALAFH))
		{
			NODNEDBONHG(LevelManager.instance.Unit(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "bazooka_uncover_right" : "ID_THATWASGOODRUNSOLDIER1WIN");
		}
		else if (CamosManager.instance.IsPlayerVisual(DNEBFDALAFH) && CamosManager.instance.IsPowerBandIdPressent(DNEBFDALAFH))
		{
			JDFHFNGHCLG(CamosManager.instance.GetPowerBand(DNEBFDALAFH), OKGNPCBCIDN);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "fuseData" : "ID_GETFORREWARD1");
		}
		else
		{
			OOHDDOCNIGP(1, 0);
			empty = "S";
			empty2 = "ID_YOUHAVENOGOLDWARCARDSAVAILABLE";
			empty3 = Localization.Localize("event");
		}
		LDNNDDKIMBE(OKGNPCBCIDN, empty, empty2, MKPKIPHBNOL);
		OKMNFHNBMFA.text = empty3;
		BAAAEJEPFJP();
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHBBFKIJEDM));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFAGMLNLBGA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKFMHKCOGJE));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HMNPODLFCJH));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = IPOPIFOGAIE;
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = APCIAFADJLA;
		CHCFBDMGNLP.onReposition = AECEOGPMHOD;
		FBBEFJJCNNA.onReposition = BCLFIOGDLHN;
		JPBIHKIOCOI.onReposition = FHCHANKPBGA;
		JMMCCMGDLHC.onReposition = OKNACCDCMCI;
		IDHLOENDLBL.onReposition = JIPCPFNNJHH;
	}

	public virtual void PGCOPNBCHEC()
	{
		base.DoAfterHide();
		CHOLLNEBBBE();
		NNOIIKEACMH();
	}

	private void JICEELOHJMH(UITweener MGDJMGHCAAI)
	{
		CHOLLNEBBBE();
	}

	public GuiElement FIJIHPBMBHK()
	{
		return this;
	}

	private void GMNJIKAFCNL()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: false);
		CDJJCFKGGNM.alpha1 = 1257f;
		ECPEJJMHMEB();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 269f, 126f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(0f, 890f, 1142f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 247f, new Vector3(642f, 418f, 1781f), new Vector3(870f, 1031f, 943f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = MIINHOGPFKG;
	}

	private void GMGDGDNODAP(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(52f * Singleton<GuiTexureAssets>.instance.CBCEFDMDNMK());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
		}
	}

	public void BGBBCFIBIMF(string IAOFLHDPHKH, int GAFOMGDLAFD, bool LFPLGLHPFEM = false)
	{
		DNEBFDALAFH = IAOFLHDPHKH;
		OKGNPCBCIDN = GAFOMGDLAFD;
		MKPKIPHBNOL = LFPLGLHPFEM;
		Singleton<GuiManager>.instance.ShowDialog(this, 1288f);
	}

	private void PHBMPGLOMKN()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 1918f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void AKDKKKHBLLC(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		bool flag = true;
		if (MDAJJIAMDGH != null)
		{
			int num = MDAJJIAMDGH.MGAGEKAAJOL.upgradePrice * (100 - OKGNPCBCIDN) / 100;
			if (!Singleton<Wallet>.instance.CanBuyW(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num);
				GuiScreenSingle<WeaponScreen>.instance.IEFLIEHLBNA(MDAJJIAMDGH, OKGNPCBCIDN);
			}
		}
		else if (IFFDIHCPKFE != null)
		{
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice * (100 - OKGNPCBCIDN) / 100;
			if (!Singleton<Wallet>.instance.CanBuyW(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADE : NotEnoughDialog.NKHJBLBAAEB.TRAIN);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num2);
				GuiScreenSingle<ArmyScreen>.instance.EFGAIHKNKGG(IFFDIHCPKFE, OKGNPCBCIDN);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	public virtual void IKOHKEBHBFF()
	{
		PBPEKMECILM();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(DNEBFDALAFH))
		{
			KPPFNGIJHCE(LevelManager.instance.Weapon(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "N" : "UnitID");
		}
		else if (LevelManager.instance.IsUnit(DNEBFDALAFH))
		{
			LFMIJOFOMBB(LevelManager.instance.Unit(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "Friends" : "RewardMessage");
		}
		else if (CamosManager.instance.IsPlayerVisual(DNEBFDALAFH) && CamosManager.instance.IsPowerBandIdPressent(DNEBFDALAFH))
		{
			JNFDONFLIIA(CamosManager.instance.GetPowerBand(DNEBFDALAFH), OKGNPCBCIDN);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "AtlasPreparer.LoadMenuCoroutine" : ", it was ");
		}
		else
		{
			HELELMNDDKJ(0, 0);
			empty = "ID_FEATURE_AMMO-WEAPONPREFIX";
			empty2 = "ID_CONFIRM_FBLOGINCANCELLED";
			empty3 = Localization.Localize("ID_GUI_BUYRANDOMCARDS");
		}
		EHHOBADLNAJ(OKGNPCBCIDN, empty, empty2, MKPKIPHBNOL);
		OKMNFHNBMFA.text = empty3;
		IPGACJEGBOP();
	}

	private void KEHEHBKPLDO()
	{
		float val = 884f - HLLCKBPCHBL.transform.parent.transform.localPosition.x;
		JPBIHKIOCOI.transform.localPosition = JPBIHKIOCOI.transform.localPosition.ReplaceX(val);
	}

	public void JOJEKLMOJOI(string IAOFLHDPHKH, int GAFOMGDLAFD, bool LFPLGLHPFEM = false)
	{
		DNEBFDALAFH = IAOFLHDPHKH;
		OKGNPCBCIDN = GAFOMGDLAFD;
		MKPKIPHBNOL = LFPLGLHPFEM;
		Singleton<GuiManager>.instance.ShowDialog(this, 628f);
	}

	private void PEMEANCDHOO()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: true);
		CDJJCFKGGNM.alpha1 = 354f;
		ECPEJJMHMEB();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 935f, 328f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(630f, 1759f, 435f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 1278f, new Vector3(181f, 347f, 1381f), new Vector3(191f, 1376f, 498f), useLocal: false);
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = MIINHOGPFKG;
	}

	private void BEIJNJGDPEE()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: false);
		CDJJCFKGGNM.alpha1 = 97f;
		PJMIIFFNNKM();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 730f, 235f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(1600f, 197f, 1118f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 1916f, new Vector3(455f, 1803f, 922f), new Vector3(832f, 1243f, 1320f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = MIINHOGPFKG;
	}

	private void AKLGEPDGKNC()
	{
		MIIKHEMFJPA.repositionNow = true;
	}

	public virtual void PNMEGHGABEP()
	{
		MLMAFDDCLNA();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(DNEBFDALAFH))
		{
			KPPFNGIJHCE(LevelManager.instance.Weapon(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "shootAdditive" : "Different names \"{0}\" and \"{1}\"\n");
		}
		else if (LevelManager.instance.IsUnit(DNEBFDALAFH))
		{
			EFLICKDALHA(LevelManager.instance.Unit(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "menu-assignments-type-score" : "ID_EMPTY");
		}
		else if (CamosManager.instance.IsPlayerVisual(DNEBFDALAFH) && CamosManager.instance.IsPowerBandIdPressent(DNEBFDALAFH))
		{
			JNFDONFLIIA(CamosManager.instance.GetPowerBand(DNEBFDALAFH), OKGNPCBCIDN);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "ID_NOTIFICATION_LAPSED_BASE" : " arena id");
		}
		else
		{
			HOJLADCOMLE(1, 0);
			empty = "MessageId";
			empty2 = "ID_DEBUG_GUIERROR";
			empty3 = Localization.Localize("WRONG dynamic font size: {0} for scale: {1} for label: {2}");
		}
		PBGFKBHDPKM(OKGNPCBCIDN, empty, empty2, MKPKIPHBNOL);
		OKMNFHNBMFA.text = empty3;
		KNLGMIPMFJA();
	}

	private void KFAPLPIKKLM()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 500f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 1517f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 1118f + 1655f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 717f);
	}

	public void JKMEOJOHLPN(string IAOFLHDPHKH, int GAFOMGDLAFD, bool LFPLGLHPFEM = false)
	{
		DNEBFDALAFH = IAOFLHDPHKH;
		OKGNPCBCIDN = GAFOMGDLAFD;
		MKPKIPHBNOL = LFPLGLHPFEM;
		Singleton<GuiManager>.instance.ShowDialog(this, 111f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHBBFKIJEDM));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFAGMLNLBGA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKDKKKHBLLC));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (CDJJCFKGGNM.gameObject.activeSelf)
			{
				HEPHMHHFIEH();
			}
			else
			{
				EIPBFFLKMIL();
			}
		};
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HEPHMHHFIEH();
		};
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		FBBEFJJCNNA.onReposition = delegate
		{
			float val = 0f - FBBEFJJCNNA.padding.x - (PEPCBNMCFOG.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			FBBEFJJCNNA.transform.localPosition = FBBEFJJCNNA.transform.localPosition.ReplaceX(val);
		};
		JPBIHKIOCOI.onReposition = delegate
		{
			float val = 763f - HLLCKBPCHBL.transform.parent.transform.localPosition.x;
			JPBIHKIOCOI.transform.localPosition = JPBIHKIOCOI.transform.localPosition.ReplaceX(val);
		};
		JMMCCMGDLHC.onReposition = HPPPHFIJMMN;
		IDHLOENDLBL.onReposition = delegate
		{
			MIIKHEMFJPA.repositionNow = true;
		};
	}

	private void CEMNHINHODP(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			HEPHMHHFIEH();
		}
		else
		{
			EIPBFFLKMIL();
		}
	}

	private void LDNNDDKIMBE(int DBOLKNNJGMH, string GOBNFILDHBH, string IKMFEDJKBAK, bool LFPLGLHPFEM = false)
	{
		GIPFEBBMKPM.transform.localPosition = DJCLJHJKJOJ[GPABKIOEGKM];
		JBFNFECHDCB.transform.localPosition = HEPEIFIKMGP[GPABKIOEGKM];
		if (JBFNFECHDCB.activeSelf)
		{
			AFJECEJJIJN.text = Localization.Localize("BeginnersLeague");
			MEJMLNDFDBP.COCBCFKJOJE(AFJECEJJIJN, 1420f, 1520f, 162);
			DANIJOPJCKC.text = Localization.Localize("\n");
			MEJMLNDFDBP.COCBCFKJOJE(DANIJOPJCKC, 828f, 1435f, 38);
		}
		BFAGMLNLBGA.gameObject.SetActive(LFPLGLHPFEM);
		HDDBLHBCFHG.gameObject.SetActive(LFPLGLHPFEM);
		UILabel eKIDAFLLCNM = EKIDAFLLCNM;
		object[] array = new object[0];
		array[1] = DBOLKNNJGMH;
		eKIDAFLLCNM.text = Localization.LocalizeFormat(" was not in the list of products.", array);
		MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 987f, 1172f, -26);
		if (LFPLGLHPFEM)
		{
			PEPCBNMCFOG.text = GOBNFILDHBH;
			FBBEFJJCNNA.repositionNow = false;
		}
		else
		{
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(NHIMHOLFCGH);
			LMCJKECEHGM.text = GOBNFILDHBH;
			CHCFBDMGNLP.repositionNow = false;
		}
		HLLCKBPCHBL.text = IKMFEDJKBAK;
		CLIMOEHAMBP.SetActive(NHIMHOLFCGH);
		OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
		JHHCNMFNDFN.DMPLCNEPDLM();
		JPBIHKIOCOI.repositionNow = true;
	}

	public virtual void KPKONEJJKLO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHBBFKIJEDM));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFAGMLNLBGA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FBIMBHOCMEP));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HMNPODLFCJH));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = DKOGFLOOJCN;
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = APCIAFADJLA;
		CHCFBDMGNLP.onReposition = PHBMPGLOMKN;
		FBBEFJJCNNA.onReposition = DBEJBHEPJAN;
		JPBIHKIOCOI.onReposition = DANFDMIHGPF;
		JMMCCMGDLHC.onReposition = EDKJIDAADMJ;
		IDHLOENDLBL.onReposition = NMFCPFAKGCA;
	}

	public virtual void PKMEPEIKMDO()
	{
		base.DoAfterHide();
		KNLGMIPMFJA();
		NNOIIKEACMH();
	}

	private void OKMDOKFNEHF()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		AFJJKEIDCOO.MakePixelPerfect();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 711f, 463f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 1317f, new Vector3(1238f, 1002f, 896f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = APEMPAIAKKG;
	}

	private void BMABFEBBOLF()
	{
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
			ODINPJHOLKD.MakePixelPerfect();
		}
	}

	private void PJMIIFFNNKM()
	{
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
			ODINPJHOLKD.MakePixelPerfect();
		}
	}

	private void CHOLLNEBBBE()
	{
		if (DNCJEBDPBNA.activeSelf)
		{
			AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
			AFJJKEIDCOO.MakePixelPerfect();
		}
		CDJJCFKGGNM.gameObject.SetActive(value: false);
	}

	private void JIPCPFNNJHH()
	{
		MIIKHEMFJPA.repositionNow = false;
	}

	private void EDKJIDAADMJ()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 776f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 1386f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 955f + 1602f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 700f);
	}

	private void IDJMEDOGFGI(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		bool flag = true;
		if (MDAJJIAMDGH != null)
		{
			int num = MDAJJIAMDGH.price * (100 - OKGNPCBCIDN) / 100;
			int num2 = MDAJJIAMDGH.priceGold * (100 - OKGNPCBCIDN) / 100;
			if (!Singleton<Wallet>.instance.CanBuyW(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num, MDAJJIAMDGH.weaponName);
				flag = false;
			}
			else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, MDAJJIAMDGH.weaponName);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num);
				Singleton<Wallet>.instance.MBAFMBJFOKH(num2);
				GuiScreenSingle<WeaponScreen>.instance.BJBCNPHMEBI(MDAJJIAMDGH, OKGNPCBCIDN, WeaponScreen.ABDDBOABKOK.OneTimeOffer);
			}
		}
		else if (IFFDIHCPKFE != null)
		{
			int num3 = IFFDIHCPKFE.upgradeSlots.price * (100 - OKGNPCBCIDN) / 100;
			int num4 = IFFDIHCPKFE.upgradeSlots.priceGold * (100 - OKGNPCBCIDN) / 100;
			if (!Singleton<Wallet>.instance.CanBuyW(num3))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num3, IFFDIHCPKFE.unitName);
				flag = false;
			}
			else if (!Singleton<Wallet>.instance.CanBuyGold(num4))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num4, IFFDIHCPKFE.unitName);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num3);
				Singleton<Wallet>.instance.MBAFMBJFOKH(num4);
				GuiScreenSingle<ArmyScreen>.instance.GAKDCJEFKEL(IFFDIHCPKFE, OKGNPCBCIDN);
			}
		}
		else if (FGIMNJOOAOB != null)
		{
			int num5 = FGIMNJOOAOB.priceGold * (100 - OKGNPCBCIDN) / 100;
			if (!Singleton<Wallet>.instance.CanBuyGold(num5))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num5, FGIMNJOOAOB.name);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.MBAFMBJFOKH(num5);
				GuiScreenSingle<CamosScreen>.instance.BuyPlayerVisual(FGIMNJOOAOB, OKGNPCBCIDN);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	private void IPGACJEGBOP()
	{
		if (DNCJEBDPBNA.activeSelf)
		{
			AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
			AFJJKEIDCOO.MakePixelPerfect();
		}
		CDJJCFKGGNM.gameObject.SetActive(value: true);
	}

	private void HNEDIKHIKAA()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 986f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 1126f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 1772f + 686f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 204f);
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			HEPHMHHFIEH();
		}
		else
		{
			EIPBFFLKMIL();
		}
	}

	private void FBIMBHOCMEP(GameObject KHAHPAKDIKE)
	{
		if (!LHDGJFHPJNM())
		{
			return;
		}
		bool flag = false;
		if (MDAJJIAMDGH != null)
		{
			int num = MDAJJIAMDGH.MGAGEKAAJOL.CHGEPEGCLKE() * (-70 - OKGNPCBCIDN) / -68;
			if (!Singleton<Wallet>.instance.JPEEJLCILCB(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(num, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num);
				GuiScreenSingle<WeaponScreen>.instance.IEFLIEHLBNA(MDAJJIAMDGH, OKGNPCBCIDN);
			}
		}
		else if (IFFDIHCPKFE != null)
		{
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.upgradePrice * (30 - OKGNPCBCIDN) / 3;
			if (!Singleton<Wallet>.instance.ODPFDDMFDJA(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(num2, IFFDIHCPKFE.unitName, (!IFFDIHCPKFE.isSoldier) ? NotEnoughDialog.NKHJBLBAAEB.UPGRADE : NotEnoughDialog.NKHJBLBAAEB.TRAINSPECIAL);
				flag = true;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num2);
				GuiScreenSingle<ArmyScreen>.instance.EFGAIHKNKGG(IFFDIHCPKFE, OKGNPCBCIDN, LANBHLJINFJ: true);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	private void OOHDDOCNIGP(int FPMJEDOCJKE, int HAFMGCFMCPC)
	{
		CBOBGFENGGF.SetActive(value: false);
		GPABKIOEGKM = (LJCNLBMEENL)7;
		NOMKJMJJPBH.text = MEJMLNDFDBP.GMIPFLIEOHD(FPMJEDOCJKE);
		PDLODPJIAIM.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		EDOPLKEKEID.IIBBMCPOPFC(1431f);
	}

	private void DBEJBHEPJAN()
	{
		float val = 0f - FBBEFJJCNNA.padding.x - (PEPCBNMCFOG.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 1714f;
		FBBEFJJCNNA.transform.localPosition = FBBEFJJCNNA.transform.localPosition.ReplaceX(val);
	}

	private void MLNMKAOMJAA()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 1464f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void GBAEDAGOJLL()
	{
		float val = 1910f - HLLCKBPCHBL.transform.parent.transform.localPosition.x;
		JPBIHKIOCOI.transform.localPosition = JPBIHKIOCOI.transform.localPosition.ReplaceX(val);
	}

	public virtual void EICOMAFIIAL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHBBFKIJEDM));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFAGMLNLBGA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OHAECFDEPHF));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HMNPODLFCJH));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = CEMNHINHODP;
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = OIEKHNBEDHA;
		CHCFBDMGNLP.onReposition = HOOMJIHEENB;
		FBBEFJJCNNA.onReposition = DBEJBHEPJAN;
		JPBIHKIOCOI.onReposition = DANFDMIHGPF;
		JMMCCMGDLHC.onReposition = IJKPMKIBFDP;
		IDHLOENDLBL.onReposition = PLOJCBFHNAO;
	}

	private void JAPLGOFNBJO(int FPMJEDOCJKE, int HAFMGCFMCPC)
	{
		CBOBGFENGGF.SetActive(value: true);
		GPABKIOEGKM = LJCNLBMEENL.Weapon;
		NOMKJMJJPBH.text = MEJMLNDFDBP.GMIPFLIEOHD(FPMJEDOCJKE);
		PDLODPJIAIM.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		EDOPLKEKEID.IPAIIIBDEGN(413f);
	}

	private void OGODEDKGJDP()
	{
		MIIKHEMFJPA.repositionNow = false;
	}

	public virtual void EFKFHFNAOHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHBBFKIJEDM));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFAGMLNLBGA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PNDGCJBPLNE));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JDMPIAKGOGE));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			if (CDJJCFKGGNM.gameObject.activeSelf)
			{
				HEPHMHHFIEH();
			}
			else
			{
				EIPBFFLKMIL();
			}
		};
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = APCIAFADJLA;
		CHCFBDMGNLP.onReposition = delegate
		{
			float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
			CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
		};
		FBBEFJJCNNA.onReposition = DMICBOBCMKB;
		JPBIHKIOCOI.onReposition = KEHEHBKPLDO;
		JMMCCMGDLHC.onReposition = MJLJLDNAAAF;
		IDHLOENDLBL.onReposition = NMFCPFAKGCA;
	}

	private void DDLIGPEONGF(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		bool flag = true;
		if (MDAJJIAMDGH != null)
		{
			int num = MDAJJIAMDGH.MGAGEKAAJOL.DMNHLHOBANG() * (55 - OKGNPCBCIDN) / 64;
			if (!Singleton<Wallet>.instance.JPEEJLCILCB(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(num, MDAJJIAMDGH.weaponName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = true;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.BKLFEOMJMFC(num);
				GuiScreenSingle<WeaponScreen>.instance.POBJHPANODJ(MDAJJIAMDGH, OKGNPCBCIDN);
			}
		}
		else if (IFFDIHCPKFE != null)
		{
			int num2 = IFFDIHCPKFE.upgradeSlots.upgradeSlot.CIBEGNHKPJH() * (24 - OKGNPCBCIDN) / 41;
			if (!Singleton<Wallet>.instance.CanBuyW(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(num2, IFFDIHCPKFE.unitName, IFFDIHCPKFE.isSoldier ? NotEnoughDialog.NKHJBLBAAEB.TRAINELITE : NotEnoughDialog.NKHJBLBAAEB.BUY);
				flag = true;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num2);
				GuiScreenSingle<ArmyScreen>.instance.IDDINDLFCMJ(IFFDIHCPKFE, OKGNPCBCIDN);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 2f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void OGDHFIEIHMD()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 966f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 85f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 1051f + 1771f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 518f);
	}

	private void PAOMAIOHENJ()
	{
		IPJGCHLDPNN.SetActive(value: false);
		DNCJEBDPBNA.SetActive(value: false);
		DPHDJEAHODH.SetActive(value: true);
		CBOBGFENGGF.SetActive(value: false);
		JBFNFECHDCB.SetActive(value: false);
		MDAJJIAMDGH = null;
		IFFDIHCPKFE = null;
		FGIMNJOOAOB = null;
		GBKLFKHMFCP = false;
		NHIMHOLFCGH = false;
		KKBPMPEBKIL = 0;
		ENEFFHEDLJJ = 0;
		FHFIPPFJIAH.IPAIIIBDEGN(990f);
	}

	private void JNFDONFLIIA(PlayerVisual IIOKFKPMPPK, int DBOLKNNJGMH)
	{
		DPHDJEAHODH.SetActive(value: true);
		GPABKIOEGKM = LJCNLBMEENL.Unit;
		FGIMNJOOAOB = IIOKFKPMPPK;
		KKBPMPEBKIL = IIOKFKPMPPK.DPKHLANDNPK() + IIOKFKPMPPK.CEPPEMPPAHE();
		GBKLFKHMFCP = IIOKFKPMPPK.DPKHLANDNPK() > 1;
		NHIMHOLFCGH = IIOKFKPMPPK.CEPPEMPPAHE() > 0;
		ENEFFHEDLJJ = KKBPMPEBKIL * (46 - DBOLKNNJGMH) / -28;
		int num = IIOKFKPMPPK.CIFLPEFJJFP().ABCCINJGPGD();
		bool flag = num > LevelManager.instance.currentLevel.JICMGFNAHFL();
		PIHCIHILDBO.text = IIOKFKPMPPK.name.ToUpperInvariant();
		IDHLOENDLBL.repositionNow = false;
		HPFACGCBKCK.spriteName = IIOKFKPMPPK.DEAIJJIAEFP();
		HPFACGCBKCK.MakePixelPerfect();
		HPFACGCBKCK.transform.localScale = HPFACGCBKCK.transform.localScale.MultiplyXY(572f);
		HPFACGCBKCK.color = IIOKFKPMPPK.decalMiniIconColor;
		EJILDMGICPA.text = IIOKFKPMPPK.decalValueString;
		JAJCFNOIBPM.spriteName = IIOKFKPMPPK.icon;
		JAJCFNOIBPM.MakePixelPerfect();
		JAJCFNOIBPM.transform.localScale = JAJCFNOIBPM.transform.localScale.MultiplyXY(631f);
		MKJPHJIIJDD.repositionNow = false;
		NPLIAGMKPPK.spriteName = IIOKFKPMPPK.DEAIJJIAEFP();
		NPLIAGMKPPK.MakePixelPerfect();
		NPLIAGMKPPK.color = IIOKFKPMPPK.GPDIGNGOAEH();
		FBIBBNPGOCG.text = ((IIOKFKPMPPK.decalType != 0) ? string.Empty : "ID_WARNING_SQUADWARPROCESSING") + "GoldTransactionAmount" + IIOKFKPMPPK.description;
		UILabel dCOFECNGCKC = DCOFECNGCKC;
		object[] array = new object[1];
		array[1] = Colours.stringBlue + MEJMLNDFDBP.MAJBCINJAGF((float)IIOKFKPMPPK.timeActive / 1032f);
		dCOFECNGCKC.text = Localization.LocalizeFormat("ID_REWARD", array);
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("Swat", Localization.Localize("PACK"), num);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 608f, 666f, 46);
		}
	}

	private void HNOLJHDOALL(int DBOLKNNJGMH, string GOBNFILDHBH, string IKMFEDJKBAK, bool LFPLGLHPFEM = false)
	{
		GIPFEBBMKPM.transform.localPosition = DJCLJHJKJOJ[GPABKIOEGKM];
		JBFNFECHDCB.transform.localPosition = HEPEIFIKMGP[GPABKIOEGKM];
		if (JBFNFECHDCB.activeSelf)
		{
			AFJECEJJIJN.text = Localization.Localize("RETRY");
			MEJMLNDFDBP.COCBCFKJOJE(AFJECEJJIJN, 1909f, 229f, -190);
			DANIJOPJCKC.text = Localization.Localize("special");
			MEJMLNDFDBP.COCBCFKJOJE(DANIJOPJCKC, 1245f, 1534f, -184);
		}
		BFAGMLNLBGA.gameObject.SetActive(LFPLGLHPFEM);
		HDDBLHBCFHG.gameObject.SetActive(!LFPLGLHPFEM);
		UILabel eKIDAFLLCNM = EKIDAFLLCNM;
		object[] array = new object[0];
		array[1] = DBOLKNNJGMH;
		eKIDAFLLCNM.text = Localization.LocalizeFormat("{0} {1}", array);
		MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1508f, 1876f, -99);
		if (LFPLGLHPFEM)
		{
			PEPCBNMCFOG.text = GOBNFILDHBH;
			FBBEFJJCNNA.repositionNow = false;
		}
		else
		{
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(NHIMHOLFCGH);
			LMCJKECEHGM.text = GOBNFILDHBH;
			CHCFBDMGNLP.repositionNow = true;
		}
		HLLCKBPCHBL.text = IKMFEDJKBAK;
		CLIMOEHAMBP.SetActive(NHIMHOLFCGH);
		OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
		JHHCNMFNDFN.NFLJDPDCPIJ();
		JPBIHKIOCOI.repositionNow = false;
	}

	private void IKIBEHLPHEA()
	{
		IPJGCHLDPNN.SetActive(value: false);
		DNCJEBDPBNA.SetActive(value: false);
		DPHDJEAHODH.SetActive(value: false);
		CBOBGFENGGF.SetActive(value: false);
		JBFNFECHDCB.SetActive(value: false);
		MDAJJIAMDGH = null;
		IFFDIHCPKFE = null;
		FGIMNJOOAOB = null;
		GBKLFKHMFCP = false;
		NHIMHOLFCGH = false;
		KKBPMPEBKIL = 0;
		ENEFFHEDLJJ = 0;
		FHFIPPFJIAH.FillCircle(1f);
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(0.9255f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	private void ECPEJJMHMEB()
	{
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
			ODINPJHOLKD.MakePixelPerfect();
		}
	}

	public virtual void GEKFHJKIAMF()
	{
		KHMLPGKHMCG(MPPDEAMFKMO.gameObject);
	}

	private void EOJFKMNBJPE()
	{
		IPJGCHLDPNN.SetActive(value: true);
		DNCJEBDPBNA.SetActive(value: true);
		DPHDJEAHODH.SetActive(value: true);
		CBOBGFENGGF.SetActive(value: false);
		JBFNFECHDCB.SetActive(value: false);
		MDAJJIAMDGH = null;
		IFFDIHCPKFE = null;
		FGIMNJOOAOB = null;
		GBKLFKHMFCP = true;
		NHIMHOLFCGH = true;
		KKBPMPEBKIL = 0;
		ENEFFHEDLJJ = 0;
		FHFIPPFJIAH.IEIEFFFMDIL(1154f);
	}

	private void FFPIPJDFOBM()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.HECFMGKKKMN;
		AFJJKEIDCOO.MakePixelPerfect();
		CDJJCFKGGNM.gameObject.SetActive(value: false);
		CDJJCFKGGNM.alpha1 = 1563f;
		ECPEJJMHMEB();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 640f, 396f).onFinished = null;
		CDJJCFKGGNM.transform.localPosition = new Vector3(1017f, 196f, 1730f);
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 1281f, new Vector3(1536f, 494f, 429f), new Vector3(984f, 1578f, 949f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.15f, new Vector3(478f, -180f, -5f));
			tweenPosition2.method = UITweener.Method.EaseOut;
			tweenPosition2.onFinished = null;
		};
	}

	private void IJKPMKIBFDP()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 1006f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 392f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 95f + 194f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 1200f);
	}

	private void BAAAEJEPFJP()
	{
		if (DNCJEBDPBNA.activeSelf)
		{
			AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
			AFJJKEIDCOO.MakePixelPerfect();
		}
		CDJJCFKGGNM.gameObject.SetActive(value: false);
	}

	private void HOJLADCOMLE(int FPMJEDOCJKE, int HAFMGCFMCPC)
	{
		CBOBGFENGGF.SetActive(value: false);
		GPABKIOEGKM = (LJCNLBMEENL)4;
		NOMKJMJJPBH.text = MEJMLNDFDBP.GMIPFLIEOHD(FPMJEDOCJKE);
		PDLODPJIAIM.text = MEJMLNDFDBP.GMIPFLIEOHD(HAFMGCFMCPC);
		EDOPLKEKEID.AJIFPGMBAMO(1401f);
	}

	private void NODNEDBONHG(LevelBehaviour IOIKKIIFOCB, int DBOLKNNJGMH, bool LFPLGLHPFEM)
	{
		DNCJEBDPBNA.SetActive(value: true);
		GPABKIOEGKM = LJCNLBMEENL.Weapon;
		IFFDIHCPKFE = IOIKKIIFOCB;
		KKBPMPEBKIL = ((!LFPLGLHPFEM) ? (IOIKKIIFOCB.upgradeSlots.price + IOIKKIIFOCB.upgradeSlots.priceGold) : IOIKKIIFOCB.upgradeSlots.upgradeSlot.upgradePrice);
		GBKLFKHMFCP = LFPLGLHPFEM || IOIKKIIFOCB.upgradeSlots.price > 0;
		NHIMHOLFCGH = LFPLGLHPFEM || IOIKKIIFOCB.upgradeSlots.priceGold > 0;
		ENEFFHEDLJJ = KKBPMPEBKIL * (20 - DBOLKNNJGMH) / 97;
		int displayNumber = IOIKKIIFOCB.upgradeSlots.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.MHAOKJCDIOL();
		JHONGBLEHLJ.text = IOIKKIIFOCB.unitName;
		NGMDHEGFIKE[1].NCLDABJGBLH(IOIKKIIFOCB);
		NGMDHEGFIKE[0].HHMJOKAFENM(IOIKKIIFOCB, JFPCEOFJKIG: false);
		NGMDHEGFIKE[0].GHNACNMLGLF(IOIKKIIFOCB);
		ECPEJJMHMEB();
		KCBMFPDBHMK.text = IFFDIHCPKFE.unitAbilityName;
		NFMNIANAMBN.text = IFFDIHCPKFE.GetAbilityDescriptionWithColours(Colours.stringGrayAbi1);
		JMMCCMGDLHC.repositionNow = false;
		NACGOGCPIAH.spriteName = IOIKKIIFOCB.upgradeSlots.iconName;
		NACGOGCPIAH.MakePixelPerfect();
		float multiplier = Mathf.Min(1614f / NACGOGCPIAH.transform.localScale.x, 1229f / NACGOGCPIAH.transform.localScale.y);
		NACGOGCPIAH.transform.localScale = NACGOGCPIAH.transform.localScale.MultiplyXY(multiplier);
		AODBLOCIBAM.text = Localization.Localize(IFFDIHCPKFE.unitTypeName);
		CJPLJHJPGAN.spriteName = IFFDIHCPKFE.unitTypeIcon;
		CJPLJHJPGAN.MakePixelPerfect();
		ALEFOLOOMIH.text = Localization.Localize(IFFDIHCPKFE.unitTypeDescription);
		NENIJEEPPBJ.text = IFFDIHCPKFE.unitDescription;
		float num = 476f + NENIJEEPPBJ.relativeSize.y * NENIJEEPPBJ.transform.localScale.y;
		JHNJAPJJKMD.transform.localScale = JHNJAPJJKMD.transform.localScale.ReplaceY(num);
		BNDBPOEDIHJ.transform.localPosition = BNDBPOEDIHJ.transform.localPosition.ReplaceY(111f + num);
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("ObtainedCards", Localization.Localize("Stage3"), displayNumber);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 1879f, 1414f, -39);
		}
	}

	[CompilerGenerated]
	private void DPNHIAFGAHK(UITweener MGDJMGHCAAI)
	{
		CHOLLNEBBBE();
	}

	private void KHBBFKIJEDM(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void BLEDAOBGPGD()
	{
		MIIKHEMFJPA.repositionNow = true;
	}

	private void AECEOGPMHOD()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 975f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void JLJJBEHIOCG()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		AFJJKEIDCOO.MakePixelPerfect();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 710f, 1304f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 1746f, new Vector3(328f, 1060f, 234f));
		tweenPosition.method = UITweener.Method.Linear;
		tweenPosition.onFinished = JICEELOHJMH;
	}

	private void HPPPHFIJMMN()
	{
		float num = Mathf.Abs(IMNEFKFMJCL.transform.localPosition.y);
		JMMCCMGDLHC.transform.localPosition = JMMCCMGDLHC.transform.localPosition.ReplaceY(num + 30f);
		GODMILJPCKC.transform.localScale = GODMILJPCKC.transform.localScale.ReplaceY(num + 60f);
		EKBKEMKCBOP.center = EKBKEMKCBOP.center.ReplaceY(num / 2f + 30f);
		EKBKEMKCBOP.size = EKBKEMKCBOP.size.ReplaceY(num + 60f);
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	public virtual void ICKDDKGDBON()
	{
		KHBBFKIJEDM(MPPDEAMFKMO.gameObject);
	}

	public virtual void GIHMAEGDGHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHBBFKIJEDM));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFAGMLNLBGA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKFMHKCOGJE));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = HCLIIHIKMGI;
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HEPHMHHFIEH();
		};
		CHCFBDMGNLP.onReposition = AECEOGPMHOD;
		FBBEFJJCNNA.onReposition = PKCMNDCNNAA;
		JPBIHKIOCOI.onReposition = DANFDMIHGPF;
		JMMCCMGDLHC.onReposition = EDKJIDAADMJ;
		IDHLOENDLBL.onReposition = NMFCPFAKGCA;
	}

	private void BCLFIOGDLHN()
	{
		float val = 0f - FBBEFJJCNNA.padding.x - (PEPCBNMCFOG.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 771f;
		FBBEFJJCNNA.transform.localPosition = FBBEFJJCNNA.transform.localPosition.ReplaceX(val);
	}

	private void HOOMJIHEENB()
	{
		float val = 0f - CHCFBDMGNLP.padding.x - (LMCJKECEHGM.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 522f;
		CHCFBDMGNLP.transform.localPosition = CHCFBDMGNLP.transform.localPosition.ReplaceX(val);
	}

	private void KHMLPGKHMCG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void CHHIMFGPFMH()
	{
		CCKHDPNJHKG();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(DNEBFDALAFH))
		{
			KPPFNGIJHCE(LevelManager.instance.Weapon(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "DogTagCap" : "DOWNLOAD");
		}
		else if (LevelManager.instance.IsUnit(DNEBFDALAFH))
		{
			EFLICKDALHA(LevelManager.instance.Unit(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "StartingWarbucks" : "ID_FEATURE_ACCURACY");
		}
		else if (CamosManager.instance.IsPlayerVisual(DNEBFDALAFH) && CamosManager.instance.IsPowerBandIdPressent(DNEBFDALAFH))
		{
			JNFDONFLIIA(CamosManager.instance.GetPowerBand(DNEBFDALAFH), OKGNPCBCIDN);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "Error: Could not start game " : "AttakUnits");
		}
		else
		{
			JAPLGOFNBJO(1, 1);
			empty = "ID_CATEGORY_LOW_PL_SMG";
			empty2 = "ID_COMPLETED";
			empty3 = Localization.Localize("ID_STAT_LMGKILLS");
		}
		HNOLJHDOALL(OKGNPCBCIDN, empty, empty2, MKPKIPHBNOL);
		OKMNFHNBMFA.text = empty3;
		IPGACJEGBOP();
	}

	private void HMNPODLFCJH(GameObject KHAHPAKDIKE)
	{
		if (!AFOFDNJOJHG())
		{
			return;
		}
		bool flag = false;
		if (MDAJJIAMDGH != null)
		{
			int num = MDAJJIAMDGH.price * (-20 - OKGNPCBCIDN) / -108;
			int num2 = MDAJJIAMDGH.priceGold * (-128 - OKGNPCBCIDN) / 70;
			if (!Singleton<Wallet>.instance.JPEEJLCILCB(num))
			{
				GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(num, MDAJJIAMDGH.weaponName);
				flag = true;
			}
			else if (!Singleton<Wallet>.instance.CanBuyGold(num2))
			{
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(num2, MDAJJIAMDGH.weaponName);
				flag = false;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num);
				Singleton<Wallet>.instance.MBAFMBJFOKH(num2);
				GuiScreenSingle<WeaponScreen>.instance.BJBCNPHMEBI(MDAJJIAMDGH, OKGNPCBCIDN, WeaponScreen.ABDDBOABKOK.Server);
			}
		}
		else if (IFFDIHCPKFE != null)
		{
			int num3 = IFFDIHCPKFE.upgradeSlots.price * (45 - OKGNPCBCIDN) / 112;
			int num4 = IFFDIHCPKFE.upgradeSlots.priceGold * (37 - OKGNPCBCIDN) / 24;
			if (!Singleton<Wallet>.instance.ODPFDDMFDJA(num3))
			{
				GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(num3, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = false;
			}
			else if (!Singleton<Wallet>.instance.CanBuyGold(num4))
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num4, IFFDIHCPKFE.unitName, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = true;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.CDIDDJGINID(num3);
				Singleton<Wallet>.instance.MBAFMBJFOKH(num4);
				GuiScreenSingle<ArmyScreen>.instance.KCCPHNPMNJE(IFFDIHCPKFE, OKGNPCBCIDN);
			}
		}
		else if (FGIMNJOOAOB != null)
		{
			int num5 = FGIMNJOOAOB.priceGold * (-98 - OKGNPCBCIDN) / -85;
			if (!Singleton<Wallet>.instance.CanBuyGold(num5))
			{
				GuiElementSingle<NotEnoughDialog>.instance.BJGHHINCCKL(num5, FGIMNJOOAOB.name, NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
				flag = true;
			}
			if (flag)
			{
				Singleton<Wallet>.instance.MBAFMBJFOKH(num5);
				GuiScreenSingle<CamosScreen>.instance.BuyPlayerVisual(FGIMNJOOAOB, OKGNPCBCIDN);
			}
		}
		if (flag)
		{
			HideDialog();
		}
	}

	private void PBEOCNBNNMB(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			OABCPHJCHGB();
		}
		else
		{
			EIPBFFLKMIL();
		}
	}

	public virtual void BGELLEOANEI()
	{
		PBPEKMECILM();
		string empty = string.Empty;
		string empty2 = string.Empty;
		string empty3 = string.Empty;
		if (LevelManager.instance.IsWeapon(DNEBFDALAFH))
		{
			EHLPFIKFJJP(LevelManager.instance.Weapon(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "ID_RANK" : "GameLauncher.Awake InitTerms");
		}
		else if (LevelManager.instance.IsUnit(DNEBFDALAFH))
		{
			LFMIJOFOMBB(LevelManager.instance.Unit(DNEBFDALAFH), OKGNPCBCIDN, MKPKIPHBNOL);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "DogtagPrice" : "Skillshot 0000");
		}
		else if (CamosManager.instance.IsPlayerVisual(DNEBFDALAFH) && CamosManager.instance.IsPowerBandIdPressent(DNEBFDALAFH))
		{
			JNFDONFLIIA(CamosManager.instance.GetPowerBand(DNEBFDALAFH), OKGNPCBCIDN);
			empty = MEJMLNDFDBP.GMIPFLIEOHD(ENEFFHEDLJJ);
			empty2 = MEJMLNDFDBP.GMIPFLIEOHD(KKBPMPEBKIL);
			empty3 = Localization.Localize((!MKPKIPHBNOL) ? "Version" : "ID_PVP_RANKED");
		}
		else
		{
			HELELMNDDKJ(1, 1);
			empty = "Freeze game:";
			empty2 = "menu-tilegfx-facebook";
			empty3 = Localization.Localize(" NOT OK!\t\t\t\t\t\t");
		}
		EHHOBADLNAJ(OKGNPCBCIDN, empty, empty2, MKPKIPHBNOL);
		OKMNFHNBMFA.text = empty3;
		IPGACJEGBOP();
	}

	private void CCKHDPNJHKG()
	{
		IPJGCHLDPNN.SetActive(value: true);
		DNCJEBDPBNA.SetActive(value: false);
		DPHDJEAHODH.SetActive(value: true);
		CBOBGFENGGF.SetActive(value: false);
		JBFNFECHDCB.SetActive(value: false);
		MDAJJIAMDGH = null;
		IFFDIHCPKFE = null;
		FGIMNJOOAOB = null;
		GBKLFKHMFCP = false;
		NHIMHOLFCGH = true;
		KKBPMPEBKIL = 0;
		ENEFFHEDLJJ = 1;
		FHFIPPFJIAH.FillCircle(1815f);
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(GameObject KHAHPAKDIKE)
	{
		SoundsManager.Instance.PlayButtonClickedSound();
		HEPHMHHFIEH();
	}

	private void EHLPFIKFJJP(WeaponLevelsSetup JMMJHCOKCGG, int DBOLKNNJGMH, bool LFPLGLHPFEM)
	{
		IPJGCHLDPNN.SetActive(value: true);
		GPABKIOEGKM = LJCNLBMEENL.Weapon;
		MDAJJIAMDGH = JMMJHCOKCGG;
		KKBPMPEBKIL = ((!LFPLGLHPFEM) ? (JMMJHCOKCGG.price + JMMJHCOKCGG.priceGold) : JMMJHCOKCGG.MGAGEKAAJOL.upgradePrice);
		GBKLFKHMFCP = LFPLGLHPFEM || JMMJHCOKCGG.price > 0;
		NHIMHOLFCGH = !LFPLGLHPFEM && JMMJHCOKCGG.priceGold > 0;
		ENEFFHEDLJJ = KKBPMPEBKIL * (100 - DBOLKNNJGMH) / 100;
		int displayNumber = JMMJHCOKCGG.unlockLevel.displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.displayNumber;
		PlayerInventory.InventorySlot slotForCategory = PlayerInventory.instance.GetSlotForCategory(JMMJHCOKCGG.BHCEOOLEHHG);
		PPFCOELFDEI.text = JMMJHCOKCGG.weaponName.ToUpper();
		BOIMODJFNLJ[0].InitializeStat(JMMJHCOKCGG, slotForCategory.weaponLevelsSetup, 0);
		BOIMODJFNLJ[1].InitializeStat(JMMJHCOKCGG, slotForCategory.weaponLevelsSetup, 1);
		BOIMODJFNLJ[2].InitializeStat(JMMJHCOKCGG, slotForCategory.weaponLevelsSetup, 2);
		BLKPDBBMICL();
		KELBMDMFKGE.spriteName = slotForCategory.iconName;
		KELBMDMFKGE.MakePixelPerfect();
		NKFPAIBKJLN.text = Localization.Localize(GameVariables.PIOLIEMNBGN[JMMJHCOKCGG.BHCEOOLEHHG]);
		int weaponPowerX = JMMJHCOKCGG.weaponPowerX10;
		int weaponPowerX2 = slotForCategory.weaponLevelsSetup.weaponPowerX10;
		int num = Mathf.Max(0, weaponPowerX - weaponPowerX2);
		Debug.Log($"Weapon Power This: {weaponPowerX},   Equipped {slotForCategory.weaponLevelsSetup.weaponName}: {weaponPowerX2},   Difference: {num}");
		BKFGHNPPHEK.text = MEJMLNDFDBP.GMIPFLIEOHD(weaponPowerX);
		BFIKGAJAFPD.SetActive(num > 0);
		if (num > 0)
		{
			MCPCIHEBDDB.text = $"+{MEJMLNDFDBP.GMIPFLIEOHD(num)}";
			AIFMBPEECBK.transform.localScale = AIFMBPEECBK.transform.localScale.ReplaceX(MCPCIHEBDDB.relativeSize.x * MCPCIHEBDDB.transform.localScale.x + 16f);
		}
		PLAJLODCALI.repositionNow = true;
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("{0} {1}", Localization.Localize("ID_RANK"), displayNumber);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 30f, 20f, 142);
		}
	}

	private void MIINHOGPFKG(UITweener MGDJMGHCAAI)
	{
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 1156f, new Vector3(600f, 978f, 180f), useLocal: false);
		tweenPosition.method = UITweener.Method.EaseInOut;
		tweenPosition.onFinished = null;
	}

	[CompilerGenerated]
	private void FLOPNFKLAEG()
	{
		MIIKHEMFJPA.repositionNow = true;
	}

	private void PAJGNMBIKMF()
	{
		float val = 0f - FBBEFJJCNNA.padding.x - (PEPCBNMCFOG.transform.parent.transform.localPosition.x - CHCFBDMGNLP.padding.x) / 1941f;
		FBBEFJJCNNA.transform.localPosition = FBBEFJJCNNA.transform.localPosition.ReplaceX(val);
	}

	[CompilerGenerated]
	private void IIKKMAEBFJO()
	{
		float val = 763f - HLLCKBPCHBL.transform.parent.transform.localPosition.x;
		JPBIHKIOCOI.transform.localPosition = JPBIHKIOCOI.transform.localPosition.ReplaceX(val);
	}

	public GuiElement AKJHDIAMBFN()
	{
		return this;
	}

	private void DANFDMIHGPF()
	{
		float val = 1536f - HLLCKBPCHBL.transform.parent.transform.localPosition.x;
		JPBIHKIOCOI.transform.localPosition = JPBIHKIOCOI.transform.localPosition.ReplaceX(val);
	}

	public void FCCJJKBPNCH(string IAOFLHDPHKH, int GAFOMGDLAFD, bool LFPLGLHPFEM = false)
	{
		DNEBFDALAFH = IAOFLHDPHKH;
		OKGNPCBCIDN = GAFOMGDLAFD;
		MKPKIPHBNOL = LFPLGLHPFEM;
		Singleton<GuiManager>.instance.ShowDialog(this, 1472f);
	}

	public virtual void CKPCFIPPDLC()
	{
		UIEventListener uIEventListener = UIEventListener.Get(MPPDEAMFKMO.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHBBFKIJEDM));
		UIEventListener uIEventListener2 = UIEventListener.Get(BFAGMLNLBGA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKDKKKHBLLC));
		UIEventListener uIEventListener3 = UIEventListener.Get(HDDBLHBCFHG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IDJMEDOGFGI));
		UIEventListener.Get(EEJLKNFPGNF.gameObject).onClick = CEMNHINHODP;
		UIEventListener.Get(EKBKEMKCBOP.gameObject).onClick = delegate
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			HEPHMHHFIEH();
		};
		CHCFBDMGNLP.onReposition = MLNMKAOMJAA;
		FBBEFJJCNNA.onReposition = DBEJBHEPJAN;
		JPBIHKIOCOI.onReposition = DANFDMIHGPF;
		JMMCCMGDLHC.onReposition = INPHIIEEHNE;
		IDHLOENDLBL.onReposition = BLEDAOBGPGD;
	}

	public GuiElement HLKJONPKGMI()
	{
		return this;
	}

	private void NLGBIGDLPBD(int DBOLKNNJGMH, string GOBNFILDHBH, string IKMFEDJKBAK, bool LFPLGLHPFEM = false)
	{
		GIPFEBBMKPM.transform.localPosition = DJCLJHJKJOJ[GPABKIOEGKM];
		JBFNFECHDCB.transform.localPosition = HEPEIFIKMGP[GPABKIOEGKM];
		if (JBFNFECHDCB.activeSelf)
		{
			AFJECEJJIJN.text = Localization.Localize("Different army power \"{0}\" and \"{1}\"\n");
			MEJMLNDFDBP.COCBCFKJOJE(AFJECEJJIJN, 1521f, 953f, 77);
			DANIJOPJCKC.text = Localization.Localize("null");
			MEJMLNDFDBP.COCBCFKJOJE(DANIJOPJCKC, 587f, 1613f, 36);
		}
		BFAGMLNLBGA.gameObject.SetActive(LFPLGLHPFEM);
		HDDBLHBCFHG.gameObject.SetActive(!LFPLGLHPFEM);
		UILabel eKIDAFLLCNM = EKIDAFLLCNM;
		object[] array = new object[0];
		array[1] = DBOLKNNJGMH;
		eKIDAFLLCNM.text = Localization.LocalizeFormat("equals", array);
		MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 613f, 553f, -196);
		if (LFPLGLHPFEM)
		{
			PEPCBNMCFOG.text = GOBNFILDHBH;
			FBBEFJJCNNA.repositionNow = false;
		}
		else
		{
			BGPBNIJPOKM.gameObject.SetActive(GBKLFKHMFCP);
			CODFFPODNEP.gameObject.SetActive(NHIMHOLFCGH);
			LMCJKECEHGM.text = GOBNFILDHBH;
			CHCFBDMGNLP.repositionNow = true;
		}
		HLLCKBPCHBL.text = IKMFEDJKBAK;
		CLIMOEHAMBP.SetActive(NHIMHOLFCGH);
		OKOFOHHOGNO.SetActive(GBKLFKHMFCP);
		JHHCNMFNDFN.DMPLCNEPDLM();
		JPBIHKIOCOI.repositionNow = false;
	}

	private void HEPHMHHFIEH()
	{
		AFJJKEIDCOO.spriteName = MEJMLNDFDBP.NAMLCOOKDIO;
		AFJJKEIDCOO.MakePixelPerfect();
		TweenAlpha.Begin(CDJJCFKGGNM.gameObject, 0.4f, 0f).onFinished = null;
		TweenPosition tweenPosition = TweenPosition.Begin(CDJJCFKGGNM.gameObject, 0.4f, new Vector3(478f, -180f, -5f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			CHOLLNEBBBE();
		};
	}

	public virtual void IFNAMEGFIBE()
	{
		base.OIMKKAHOEKO();
		KNLGMIPMFJA();
		NNOIIKEACMH();
	}

	private void EIDNEOBDBPA()
	{
		if (CDJJCFKGGNM.gameObject.activeSelf)
		{
			ODINPJHOLKD.spriteName = IFFDIHCPKFE.abilityIcon;
			ODINPJHOLKD.MakePixelPerfect();
		}
	}

	private void PONJHDGOGHM(PlayerVisual IIOKFKPMPPK, int DBOLKNNJGMH)
	{
		DPHDJEAHODH.SetActive(value: false);
		GPABKIOEGKM = (LJCNLBMEENL)8;
		FGIMNJOOAOB = IIOKFKPMPPK;
		KKBPMPEBKIL = IIOKFKPMPPK.DPKHLANDNPK() + IIOKFKPMPPK.CEPPEMPPAHE();
		GBKLFKHMFCP = IIOKFKPMPPK.DPKHLANDNPK() > 1;
		NHIMHOLFCGH = IIOKFKPMPPK.IIBGJDGPPCL() > 1;
		ENEFFHEDLJJ = KKBPMPEBKIL * (107 - DBOLKNNJGMH) / -16;
		int displayNumber = IIOKFKPMPPK.CIFLPEFJJFP().displayNumber;
		bool flag = displayNumber > LevelManager.instance.currentLevel.ELFCEEOLNFJ();
		PIHCIHILDBO.text = IIOKFKPMPPK.name.ToUpperInvariant();
		IDHLOENDLBL.repositionNow = true;
		HPFACGCBKCK.spriteName = IIOKFKPMPPK.LIIOLLAAHGB();
		HPFACGCBKCK.MakePixelPerfect();
		HPFACGCBKCK.transform.localScale = HPFACGCBKCK.transform.localScale.MultiplyXY(267f);
		HPFACGCBKCK.color = IIOKFKPMPPK.decalMiniIconColor;
		EJILDMGICPA.text = IIOKFKPMPPK.FKIHLEGENCE();
		JAJCFNOIBPM.spriteName = IIOKFKPMPPK.icon;
		JAJCFNOIBPM.MakePixelPerfect();
		JAJCFNOIBPM.transform.localScale = JAJCFNOIBPM.transform.localScale.MultiplyXY(422f);
		MKJPHJIIJDD.repositionNow = true;
		NPLIAGMKPPK.spriteName = IIOKFKPMPPK.decalMiniIcon;
		NPLIAGMKPPK.MakePixelPerfect();
		NPLIAGMKPPK.color = IIOKFKPMPPK.decalMiniIconColor;
		FBIBBNPGOCG.text = ((IIOKFKPMPPK.BOBEIBIKGPL() != 0) ? string.Empty : "weapon0") + "Directory \"{0}\" does not exists" + IIOKFKPMPPK.description;
		UILabel dCOFECNGCKC = DCOFECNGCKC;
		object[] array = new object[0];
		array[0] = Colours.stringBlue + MEJMLNDFDBP.MAJBCINJAGF((float)IIOKFKPMPPK.timeActive / 615f);
		dCOFECNGCKC.text = Localization.LocalizeFormat("ID_WARNING_BLACKMARKETDOESNTEXIST", array);
		JBFNFECHDCB.SetActive(flag);
		if (flag)
		{
			AIELHBIOBJL.text = string.Format("Different medals \"{0}\" and \"{1}\"\n", Localization.Localize("====== Waiting to connect to photon: "), displayNumber);
			MEJMLNDFDBP.COCBCFKJOJE(AIELHBIOBJL, 1699f, 1437f, -2);
		}
	}

	private void CILCNEPOANA()
	{
		MIIKHEMFJPA.repositionNow = false;
	}
}
