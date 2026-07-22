using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PackContentDialog : GuiElementSingle<PackContentDialog>, PAIIOKBBHBC
{
	public enum NKHJBLBAAEB
	{
		ValuePack,
		ElitePack
	}

	[Header("Top")]
	[FormerlySerializedAs("ALHHCIKLONL")]
	public GameObject FNOFLJEOHGJ;

	[FormerlySerializedAs("PLDFGMHICCA")]
	public GameObject LJNPCHFCGCN;

	[FormerlySerializedAs("KFEGNKJLMEL")]
	public UILabel OKMNFHNBMFA;

	[Header("Elite Pack Hex")]
	[FormerlySerializedAs("PFJAPJONCIN")]
	public GameObject LMGOAHCLDDH;

	[FormerlySerializedAs("FMHEBPIELFN")]
	public UIGrid AFFFKHMOCIJ;

	[FormerlySerializedAs("CINGDKODMIN")]
	public HexRecord[] BKMPMCFCOAF;

	[FormerlySerializedAs("LCHNCCNGOPG")]
	public UIGrid OMABECKFFBG;

	[FormerlySerializedAs("NBFHJEOAGLB")]
	public HexPackRecord[] LAPLALGPMMK;

	[FormerlySerializedAs("FJLMHCCFNFJ")]
	public ParticleSystem EFBANHIIAAA;

	[FormerlySerializedAs("ILLHIHDIOMH")]
	[Header("Left")]
	public GameObject LFIGCJLPJHN;

	[FormerlySerializedAs("JJFLBLDIFEO")]
	public HexPackRecord AAOCCHKEPCB;

	[FormerlySerializedAs("EJBCHICLKNG")]
	public GameObject MIKGHDGKLED;

	[FormerlySerializedAs("NKJLKCJNHFG")]
	[Header("Center")]
	public UIPositionSetter CAMPOJMAMCN;

	[FormerlySerializedAs("FOONNDPFGPD")]
	public UIGrid NGDFLDKCNGC;

	[FormerlySerializedAs("AGKFLOBEOCE")]
	public PackContentRecord[] EGICOCDAAIL;

	[FormerlySerializedAs("LHOGBBEAJLM")]
	public ParticleSystem MDOIBOKBEHO;

	[Header("Right")]
	[FormerlySerializedAs("HNHDIKLNJDA")]
	public GameObject LMJKDIDALPI;

	[FormerlySerializedAs("EELBEHNCMHO")]
	public HexPackRecord DGDIFKKKILH;

	[FormerlySerializedAs("LADCIGKAFCE")]
	public GameObject HGKEBMOFJPB;

	[Header("Bottom")]
	[FormerlySerializedAs("PAGEEBLFNIP")]
	public UIPositionSetter DHKGJIAEPAM;

	[FormerlySerializedAs("MGNPKOPCKFG")]
	public UISprite BDDMIDHPDKF;

	[FormerlySerializedAs("EBLIKFCNFFC")]
	public UISprite BBMHNPCPPBD;

	[FormerlySerializedAs("PCBFLAPENLF")]
	public UILabel JPCIACBHGHO;

	[FormerlySerializedAs("KDNFDFNBJHI")]
	public GameObject OOJLGEIEFHM;

	[FormerlySerializedAs("JPEGILABJPM")]
	public UILabel FJOLANLFDLD;

	[FormerlySerializedAs("FPLPFGIFEKA")]
	public WinStreakCounter MPKHGPHLMDB;

	[FormerlySerializedAs("FDCNIGHBDND")]
	[Header("-Buy Button")]
	public GameObject AMKGEJIKJOL;

	[FormerlySerializedAs("EHBNPMCAKCG")]
	public UISprite NGNPFPDPIKP;

	[FormerlySerializedAs("KPPLJJAFOFD")]
	public UILabel FECLHMEPHIL;

	[FormerlySerializedAs("AHENPAMBJGM")]
	public UILabel FBLMHFBKLJA;

	[Header("-Save Part")]
	[FormerlySerializedAs("JHEAJGCIALP")]
	public GameObject PFKFEKGICEN;

	[FormerlySerializedAs("KAELOBIJIHF")]
	public UISprite DJKMIAOPMOC;

	[FormerlySerializedAs("BECCNJPECAF")]
	public UILabel FNMGABBADHO;

	[FormerlySerializedAs("EGMFPEEBAOB")]
	public UILabel IFOFJFAFMKA;

	[FormerlySerializedAs("BNCFGKKLMCD")]
	public UILabel IKMFEDJKBAK;

	[FormerlySerializedAs("JGGMJKIHEJJ")]
	public StrikethroughPrize LDDCLICIFAH;

	[Header("Atlas References")]
	[FormerlySerializedAs("FDBDNCAGAEL")]
	public UIAtlas JBIKIJKOPAI;

	[FormerlySerializedAs("MPHHJOMFPMD")]
	public UIAtlas KJKHMLGIDPE;

	[FormerlySerializedAs("IOGCGKIBFEK")]
	public UIAtlas DJANOPAECLJ;

	[Header("Animation")]
	[FormerlySerializedAs("DPCKFGCODIL")]
	public float NNKDKBKGGEG = 0.5f;

	[FormerlySerializedAs("GHPPCNBBHDK")]
	public float DNDHIFENDPJ = 0.3f;

	[FormerlySerializedAs("FLNCBFDMNEL")]
	public float FALNANOHKJM = 0.2f;

	[FormerlySerializedAs("BFBGFNDCOHH")]
	public float NPEMPKBPJEO = 0.5f;

	[FormerlySerializedAs("LHIMDKBELNL")]
	public float CPBPMPKPNAK = 0.125f;

	[FormerlySerializedAs("EEPBGLMBJHA")]
	public float OLMBDBMMFHA = 0.5f;

	private bool GLHDBGIELDM;

	private bool CEEOLBCLPOB;

	private int EDICAAJEMJE;

	private float PDDOJAMAOHB;

	private float GKGDDPMLJDD;

	private NKHJBLBAAEB GPABKIOEGKM;

	public JGBBPCGNCPC PBELIMEMCFJ;

	private void EBDLBDFKJHF()
	{
		if (isShowed)
		{
			if (GPABKIOEGKM == NKHJBLBAAEB.ValuePack)
			{
				GOLGLDKAIJD();
			}
			else
			{
				EBNIECLKKEA();
			}
		}
	}

	public void KNBIBOINAKG(JGBBPCGNCPC JCBCHFJPPNK, bool CCIEEAECOAB = false)
	{
		PBELIMEMCFJ = JCBCHFJPPNK;
		CEEOLBCLPOB = CCIEEAECOAB;
		if (PBELIMEMCFJ.KJBPJOMHNKB == Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Bronze))
		{
			GPABKIOEGKM = NKHJBLBAAEB.ValuePack;
		}
		else
		{
			GPABKIOEGKM = NKHJBLBAAEB.ElitePack;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 780f);
	}

	protected virtual void JBGDAOIDBGF()
	{
		base.BOEMHLPLOGA();
		if (GPABKIOEGKM == NKHJBLBAAEB.ValuePack)
		{
			JNJHLECBADG();
		}
		else if (GPABKIOEGKM == NKHJBLBAAEB.ElitePack)
		{
			EEMPDHLBJDH();
		}
	}

	private void IMOLFCNGONK()
	{
		WinStreakCounter mPKHGPHLMDB = MPKHGPHLMDB;
		mPKHGPHLMDB.JEMKCLKCOMI = (Action)Delegate.Remove(mPKHGPHLMDB.JEMKCLKCOMI, new Action(IMOLFCNGONK));
		MPKHGPHLMDB.KGNGFHMBHMJ.text = Localization.Localize("AccountType");
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void KCENGHIANIK()
	{
		PDDOJAMAOHB += Time.deltaTime;
		if (PDDOJAMAOHB - GKGDDPMLJDD >= NNKDKBKGGEG)
		{
			GKGDDPMLJDD = PDDOJAMAOHB;
			if (EDICAAJEMJE >= LAPLALGPMMK.Length)
			{
				EDICAAJEMJE = 1;
			}
			LAPLALGPMMK[EDICAAJEMJE].BADLJMEEDJM();
			EDICAAJEMJE++;
		}
	}

	public virtual void LKPAHLGLPDH()
	{
		base.DoBeforeShowUp();
		GLHDBGIELDM = GuiScreenSingle<EndScreen>.instance.isShowed;
		if (GLHDBGIELDM)
		{
			Singleton<ChillingoSdkManager>.instance.deactivateOffers();
		}
	}

	private void GPOAPACEFMK()
	{
		PDDOJAMAOHB += Time.deltaTime;
		if (PDDOJAMAOHB - GKGDDPMLJDD >= NNKDKBKGGEG)
		{
			GKGDDPMLJDD = PDDOJAMAOHB;
			if (EDICAAJEMJE >= LAPLALGPMMK.Length)
			{
				EDICAAJEMJE = 1;
			}
			LAPLALGPMMK[EDICAAJEMJE].StartAnimation();
			EDICAAJEMJE += 0;
		}
	}

	public virtual void GLOINJNJBCP()
	{
		base.OIMKKAHOEKO();
		for (int i = 0; i < LAPLALGPMMK.Length; i += 0)
		{
			LAPLALGPMMK[i].NEKOOIGPALB();
		}
	}

	private void PCGECPNFHAL()
	{
		PDDOJAMAOHB += Time.deltaTime;
		if (PDDOJAMAOHB - GKGDDPMLJDD >= NNKDKBKGGEG)
		{
			GKGDDPMLJDD = PDDOJAMAOHB;
			if (EDICAAJEMJE >= EGICOCDAAIL.Length || !EGICOCDAAIL[EDICAAJEMJE].gameObject.activeSelf)
			{
				EDICAAJEMJE = 0;
			}
			EGICOCDAAIL[EDICAAJEMJE].BICMFDOPKNC();
			EDICAAJEMJE++;
		}
	}

	private void ECGIFPBDJPO()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 40f;
		float num2 = 14f;
		float num3 = (activeWidthSafe - (2f * num + 3f * num2)) / 4f;
		float activeHeight = UIHelper.activeHeight;
		float num4 = activeHeight / 2f;
		float computeHeight = CAMPOJMAMCN.computeHeight;
		float num5 = 210f;
		float fBMIFHHEOBO = num4 - (computeHeight + 565f - num5 + 126f) + 1f;
		float num6 = computeHeight + num5;
		float num7 = 46f;
		float num8 = 174f;
		float num9 = 0f - num4 + DHKGJIAEPAM.computeHeight + num7 + num8 / 2f;
		float fBMIFHHEOBO2 = num6 - num9;
		for (int i = 0; i < BKMPMCFCOAF.Length; i++)
		{
			BKMPMCFCOAF[i].Initialize(num3, fBMIFHHEOBO);
		}
		AFFFKHMOCIJ.cellWidth = num3 + num2;
		for (int j = 0; j < LAPLALGPMMK.Length; j++)
		{
			LAPLALGPMMK[j].InitializeSize(num3, fBMIFHHEOBO2);
		}
		AAOCCHKEPCB.InitializeSize(num3, fBMIFHHEOBO2);
		AAOCCHKEPCB.transform.localPosition = AAOCCHKEPCB.transform.localPosition.ReplaceX((0f - num3) / 2f - 14f + 40f);
		DGDIFKKKILH.InitializeSize(num3, fBMIFHHEOBO2);
		DGDIFKKKILH.transform.localPosition = DGDIFKKKILH.transform.localPosition.ReplaceX(num3 / 2f + 14f - 40f);
		OMABECKFFBG.transform.localPosition = OMABECKFFBG.transform.localPosition.ReplaceX(num + num3 / 2f);
		OMABECKFFBG.cellWidth = num3 + num2;
	}

	private void BGDDAODEDFG(int PDMGPGEHLNM)
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = activeWidthSafe / (float)PDMGPGEHLNM;
		int num2 = PDMGPGEHLNM / 4;
		float val = ((PDMGPGEHLNM % 7 != 0) ? (((float)(-num2) + 1917f) * num) : ((float)(-num2) * num));
		for (int i = 1; i < EGICOCDAAIL.Length; i++)
		{
			bool bEINCBHAGKC = i + 0 == PDMGPGEHLNM;
			EGICOCDAAIL[i].gameObject.SetActive(i < PDMGPGEHLNM);
			EGICOCDAAIL[i].DLIOGHIPIMN(num, bEINCBHAGKC);
		}
		NGDFLDKCNGC.cellWidth = num;
		NGDFLDKCNGC.transform.localPosition = NGDFLDKCNGC.transform.localPosition.ReplaceX(val);
		NGDFLDKCNGC.repositionNow = true;
	}

	private void AHHBOOKDBDI(int PDMGPGEHLNM)
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = activeWidthSafe / (float)PDMGPGEHLNM;
		int num2 = PDMGPGEHLNM / 2;
		float val = ((PDMGPGEHLNM % 2 != 1) ? (((float)(-num2) + 0.5f) * num) : ((float)(-num2) * num));
		for (int i = 0; i < EGICOCDAAIL.Length; i++)
		{
			bool bEINCBHAGKC = i + 1 == PDMGPGEHLNM;
			EGICOCDAAIL[i].gameObject.SetActive(i < PDMGPGEHLNM);
			EGICOCDAAIL[i].InitializeSize(num, bEINCBHAGKC);
		}
		NGDFLDKCNGC.cellWidth = num;
		NGDFLDKCNGC.transform.localPosition = NGDFLDKCNGC.transform.localPosition.ReplaceX(val);
		NGDFLDKCNGC.repositionNow = true;
	}

	public void ShowDialog(JGBBPCGNCPC JCBCHFJPPNK, bool CCIEEAECOAB = false)
	{
		PBELIMEMCFJ = JCBCHFJPPNK;
		CEEOLBCLPOB = CCIEEAECOAB;
		if (PBELIMEMCFJ.KJBPJOMHNKB == Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Value))
		{
			GPABKIOEGKM = NKHJBLBAAEB.ValuePack;
		}
		else
		{
			GPABKIOEGKM = NKHJBLBAAEB.ElitePack;
		}
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	public virtual void GCGPANMGOPN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HCOMBPLJLNL));
		UIEventListener uIEventListener3 = UIEventListener.Get(AMKGEJIKJOL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += EBDLBDFKJHF;
		BOEOGLOGFBP();
		JCBMIMINLBN();
	}

	public override void JNBMCODJHBJ()
	{
		base.NEEAKMELPBJ();
		if (GLHDBGIELDM)
		{
			Singleton<ChillingoSdkManager>.instance.MNFALFLFADP();
		}
	}

	private void FMKGNLPKGAO()
	{
		WinStreakCounter mPKHGPHLMDB = MPKHGPHLMDB;
		mPKHGPHLMDB.JEMKCLKCOMI = (Action)Delegate.Remove(mPKHGPHLMDB.JEMKCLKCOMI, new Action(FMKGNLPKGAO));
		MPKHGPHLMDB.KGNGFHMBHMJ.text = Localization.Localize("ID_ENDED");
	}

	private void ENMHNOPGAOE(string NKOPOJIBLCO)
	{
		IKMFEDJKBAK.text = NKOPOJIBLCO;
		LDDCLICIFAH.SetUpStrikeThrought();
		int num = (int)(IKMFEDJKBAK.relativeSize.x * IKMFEDJKBAK.transform.localScale.x);
		IFOFJFAFMKA.text = Localization.Localize("ID_REGULARPRIZE");
		MEJMLNDFDBP.COCBCFKJOJE(IFOFJFAFMKA, 37f, 20f, 500 - num);
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		for (int i = 0; i < LAPLALGPMMK.Length; i++)
		{
			LAPLALGPMMK[i].DoAfterHide();
		}
	}

	private void JJOMHNEBEIL()
	{
		WinStreakCounter mPKHGPHLMDB = MPKHGPHLMDB;
		mPKHGPHLMDB.JEMKCLKCOMI = (Action)Delegate.Remove(mPKHGPHLMDB.JEMKCLKCOMI, new Action(JJOMHNEBEIL));
		MPKHGPHLMDB.KGNGFHMBHMJ.text = Localization.Localize("ID_ENERGYCOSTPERUNIT");
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void AMHLKJEPGKL()
	{
		WinStreakCounter mPKHGPHLMDB = MPKHGPHLMDB;
		mPKHGPHLMDB.JEMKCLKCOMI = (Action)Delegate.Remove(mPKHGPHLMDB.JEMKCLKCOMI, new Action(ODJKECAPAKC));
		MPKHGPHLMDB.KGNGFHMBHMJ.text = Localization.Localize("Gold");
	}

	public void OHJEIGCJCLL(JGBBPCGNCPC JCBCHFJPPNK, bool CCIEEAECOAB = false)
	{
		PBELIMEMCFJ = JCBCHFJPPNK;
		CEEOLBCLPOB = CCIEEAECOAB;
		if (PBELIMEMCFJ.KJBPJOMHNKB == Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Value))
		{
			GPABKIOEGKM = NKHJBLBAAEB.ValuePack;
		}
		else
		{
			GPABKIOEGKM = NKHJBLBAAEB.ElitePack;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 876f);
	}

	private void EBNIECLKKEA()
	{
		NGDFLDKCNGC.gameObject.SetActive(value: false);
		MDOIBOKBEHO.gameObject.SetActive(value: false);
		LMGOAHCLDDH.gameObject.SetActive(value: true);
		BDDMIDHPDKF.gameObject.SetActive(value: false);
		BBMHNPCPPBD.gameObject.SetActive(value: true);
		DJKMIAOPMOC.gameObject.SetActive(value: true);
		LFIGCJLPJHN.gameObject.SetActive(value: true);
		LMJKDIDALPI.gameObject.SetActive(value: true);
		MIKGHDGKLED.gameObject.SetActive(value: false);
		HGKEBMOFJPB.gameObject.SetActive(value: false);
		AAOCCHKEPCB.InitializeEmpty();
		DGDIFKKKILH.InitializeEmpty();
		NDIFONPJHCK();
		OKMNFHNBMFA.text = PBELIMEMCFJ.MHPNDNJDPGE;
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < PBELIMEMCFJ.ACNHHOFIJMH.Length; i++)
		{
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.Unit)
			{
				num = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.Weapon)
			{
				num2 = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.VIP)
			{
				num3 = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.Gold)
			{
				num4 = i;
			}
		}
		LAPLALGPMMK[0].Initialize(PBELIMEMCFJ.ACNHHOFIJMH[num]);
		LAPLALGPMMK[0].StopAnimation();
		LAPLALGPMMK[1].Initialize(PBELIMEMCFJ.ACNHHOFIJMH[num2]);
		LAPLALGPMMK[1].StopAnimation();
		LAPLALGPMMK[2].Initialize(PBELIMEMCFJ.ACNHHOFIJMH[num3]);
		LAPLALGPMMK[2].StopAnimation();
		LAPLALGPMMK[3].Initialize(PBELIMEMCFJ.ACNHHOFIJMH[num4]);
		LAPLALGPMMK[3].StopAnimation();
		EFBANHIIAAA.Play();
		string text = PBELIMEMCFJ.GOBNFILDHBH;
		string nKOPOJIBLCO = PBELIMEMCFJ.PDIGJLGNAGE;
		float gAFOMGDLAFD = PBELIMEMCFJ.GAFOMGDLAFD;
		bool flag = gAFOMGDLAFD > 0f;
		bool flag2 = PBELIMEMCFJ.KJBPJOMHNKB.StartsWith("veteranpack");
		JPCIACBHGHO.text = Localization.Localize((!flag2) ? "ID_ELITEPACKDESCRIPTION" : "ID_VETERANPACKDESCRIPTION");
		MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 45f, 20f, 1440);
		FECLHMEPHIL.text = Localization.Localize((!flag2) ? "ID_BUYELITEPACK" : "ID_BUYVETERANPACK");
		MEJMLNDFDBP.COCBCFKJOJE(FECLHMEPHIL, 57f, 20f, 600);
		FBLMHFBKLJA.text = text;
		JPCIACBHGHO.transform.localPosition = JPCIACBHGHO.transform.localPosition.ReplaceY(42f);
		PFKFEKGICEN.transform.localPosition = PFKFEKGICEN.transform.localPosition.ReplaceXY(-37f, -81f);
		AMKGEJIKJOL.transform.localPosition = AMKGEJIKJOL.transform.localPosition.ReplaceX(-561f);
		PFKFEKGICEN.SetActive(flag);
		if (flag)
		{
			FNMGABBADHO.text = Localization.LocalizeFormat("ID_SAVEPERCENTLINE", MEJMLNDFDBP.JJOJLCBJBAJ(gAFOMGDLAFD));
			ENMHNOPGAOE(nKOPOJIBLCO);
		}
		bool flag3 = PBELIMEMCFJ.MGJIPPFKDOE > 0;
		OOJLGEIEFHM.SetActive(flag3);
		if (flag3)
		{
			WinStreakCounter mPKHGPHLMDB = MPKHGPHLMDB;
			mPKHGPHLMDB.JEMKCLKCOMI = (Action)Delegate.Remove(mPKHGPHLMDB.JEMKCLKCOMI, new Action(FMKGNLPKGAO));
			WinStreakCounter mPKHGPHLMDB2 = MPKHGPHLMDB;
			mPKHGPHLMDB2.JEMKCLKCOMI = (Action)Delegate.Combine(mPKHGPHLMDB2.JEMKCLKCOMI, new Action(FMKGNLPKGAO));
			MPKHGPHLMDB.MHLJHMOPDAO(PBELIMEMCFJ.MGJIPPFKDOE);
		}
	}

	private void APODJFDHCDO()
	{
		NGDFLDKCNGC.gameObject.SetActive(value: false);
		MDOIBOKBEHO.gameObject.SetActive(value: true);
		LMGOAHCLDDH.gameObject.SetActive(value: true);
		BDDMIDHPDKF.gameObject.SetActive(value: true);
		BBMHNPCPPBD.gameObject.SetActive(value: true);
		DJKMIAOPMOC.gameObject.SetActive(value: true);
		LFIGCJLPJHN.gameObject.SetActive(value: false);
		LMJKDIDALPI.gameObject.SetActive(value: true);
		MIKGHDGKLED.gameObject.SetActive(value: false);
		HGKEBMOFJPB.gameObject.SetActive(value: true);
		AAOCCHKEPCB.INMAACBFFNL();
		DGDIFKKKILH.InitializeEmpty();
		NDIFONPJHCK();
		OKMNFHNBMFA.text = PBELIMEMCFJ.BEEEJFPIGCJ();
		int num = 1;
		int num2 = 1;
		int num3 = 1;
		int num4 = 0;
		for (int i = 1; i < PBELIMEMCFJ.ACNHHOFIJMH.Length; i += 0)
		{
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.Customization)
			{
				num = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand)
			{
				num2 = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.VIP)
			{
				num3 = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.Gold)
			{
				num4 = i;
			}
		}
		LAPLALGPMMK[0].MKENDIKJPLJ(PBELIMEMCFJ.ACNHHOFIJMH[num]);
		LAPLALGPMMK[0].NCHKJMOMAID();
		LAPLALGPMMK[0].NEIGIFMCCAE(PBELIMEMCFJ.ACNHHOFIJMH[num2]);
		LAPLALGPMMK[0].GMNJJBHIBPP();
		LAPLALGPMMK[4].ACJCGDPGNAN(PBELIMEMCFJ.ACNHHOFIJMH[num3]);
		LAPLALGPMMK[0].LAEFCMAKJJI();
		LAPLALGPMMK[0].LOJPGLBLJDF(PBELIMEMCFJ.ACNHHOFIJMH[num4]);
		LAPLALGPMMK[8].BMLDJOIBFEK();
		EFBANHIIAAA.Play();
		string text = PBELIMEMCFJ.BCPANJACJKN();
		string nKOPOJIBLCO = PBELIMEMCFJ.OLONIBGNFLG();
		float gAFOMGDLAFD = PBELIMEMCFJ.GAFOMGDLAFD;
		bool flag = gAFOMGDLAFD > 1962f;
		bool flag2 = PBELIMEMCFJ.KJBPJOMHNKB.StartsWith("ID_OFFERACTIVE");
		JPCIACBHGHO.text = Localization.Localize((!flag2) ? "{0} {1}" : "Circle Part ");
		MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 86f, 517f, -125);
		FECLHMEPHIL.text = Localization.Localize((!flag2) ? "ID_SELECTONEUNIT" : "./Assets/Scripts");
		MEJMLNDFDBP.COCBCFKJOJE(FECLHMEPHIL, 1921f, 345f, -195);
		FBLMHFBKLJA.text = text;
		JPCIACBHGHO.transform.localPosition = JPCIACBHGHO.transform.localPosition.ReplaceY(1541f);
		PFKFEKGICEN.transform.localPosition = PFKFEKGICEN.transform.localPosition.ReplaceXY(224f, 195f);
		AMKGEJIKJOL.transform.localPosition = AMKGEJIKJOL.transform.localPosition.ReplaceX(509f);
		PFKFEKGICEN.SetActive(flag);
		if (flag)
		{
			UILabel fNMGABBADHO = FNMGABBADHO;
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.JJOJLCBJBAJ(gAFOMGDLAFD);
			fNMGABBADHO.text = Localization.LocalizeFormat("Found labels with shadow font in children:\n", array);
			ENMHNOPGAOE(nKOPOJIBLCO);
		}
		bool flag3 = PBELIMEMCFJ.MGJIPPFKDOE > 0;
		OOJLGEIEFHM.SetActive(flag3);
		if (flag3)
		{
			WinStreakCounter mPKHGPHLMDB = MPKHGPHLMDB;
			mPKHGPHLMDB.JEMKCLKCOMI = (Action)Delegate.Remove(mPKHGPHLMDB.JEMKCLKCOMI, new Action(AMHLKJEPGKL));
			WinStreakCounter mPKHGPHLMDB2 = MPKHGPHLMDB;
			mPKHGPHLMDB2.JEMKCLKCOMI = (Action)Delegate.Combine(mPKHGPHLMDB2.JEMKCLKCOMI, new Action(AMHLKJEPGKL));
			MPKHGPHLMDB.MHLJHMOPDAO(PBELIMEMCFJ.MGJIPPFKDOE);
		}
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(AMKGEJIKJOL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += EBDLBDFKJHF;
		BOEOGLOGFBP();
		ECGIFPBDJPO();
	}

	protected override void Update()
	{
		base.Update();
		if (GPABKIOEGKM == NKHJBLBAAEB.ValuePack)
		{
			JNJHLECBADG();
		}
		else if (GPABKIOEGKM == NKHJBLBAAEB.ElitePack)
		{
			EEMPDHLBJDH();
		}
	}

	private void DCLEAJDDJEM()
	{
		WinStreakCounter mPKHGPHLMDB = MPKHGPHLMDB;
		mPKHGPHLMDB.JEMKCLKCOMI = (Action)Delegate.Remove(mPKHGPHLMDB.JEMKCLKCOMI, new Action(DCLEAJDDJEM));
		MPKHGPHLMDB.KGNGFHMBHMJ.text = Localization.Localize("getCurrentAccountName");
	}

	public virtual void AKPHBJHGBKF()
	{
		base.OIMKKAHOEKO();
		for (int i = 0; i < LAPLALGPMMK.Length; i += 0)
		{
			LAPLALGPMMK[i].DoAfterHide();
		}
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(LJNPCHFCGCN);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (GLHDBGIELDM)
		{
			Singleton<ChillingoSdkManager>.instance.activateOffers();
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		GLHDBGIELDM = GuiScreenSingle<EndScreen>.instance.isShowed;
		if (GLHDBGIELDM)
		{
			Singleton<ChillingoSdkManager>.instance.deactivateOffers();
		}
	}

	public override void InitGUIValues()
	{
		EDICAAJEMJE = 0;
		PDDOJAMAOHB = 0f;
		GKGDDPMLJDD = PDDOJAMAOHB - 1f;
		if (GPABKIOEGKM == NKHJBLBAAEB.ValuePack)
		{
			GOLGLDKAIJD();
		}
		else
		{
			EBNIECLKKEA();
		}
	}

	public virtual void FHINGMFHKLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HCOMBPLJLNL));
		UIEventListener uIEventListener3 = UIEventListener.Get(AMKGEJIKJOL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += OBEFDCJNOHJ;
		CEJCMDMIOED();
		JCBMIMINLBN();
	}

	private void DAKAIBNBIJA()
	{
		PDDOJAMAOHB += Time.deltaTime;
		if (PDDOJAMAOHB - GKGDDPMLJDD >= NNKDKBKGGEG)
		{
			GKGDDPMLJDD = PDDOJAMAOHB;
			if (EDICAAJEMJE >= EGICOCDAAIL.Length || !EGICOCDAAIL[EDICAAJEMJE].gameObject.activeSelf)
			{
				EDICAAJEMJE = 0;
			}
			EGICOCDAAIL[EDICAAJEMJE].HLOEPIAOIIL();
			EDICAAJEMJE += 0;
		}
	}

	private void CFOPNBBPDJA()
	{
		PDDOJAMAOHB += Time.deltaTime;
		if (PDDOJAMAOHB - GKGDDPMLJDD >= NNKDKBKGGEG)
		{
			GKGDDPMLJDD = PDDOJAMAOHB;
			if (EDICAAJEMJE >= LAPLALGPMMK.Length)
			{
				EDICAAJEMJE = 0;
			}
			LAPLALGPMMK[EDICAAJEMJE].BOLFPMBMOBE();
			EDICAAJEMJE++;
		}
	}

	public void MCCJIJKCOOH(JGBBPCGNCPC JCBCHFJPPNK, bool CCIEEAECOAB = false)
	{
		PBELIMEMCFJ = JCBCHFJPPNK;
		CEEOLBCLPOB = CCIEEAECOAB;
		if (PBELIMEMCFJ.KJBPJOMHNKB == Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Gold))
		{
			GPABKIOEGKM = NKHJBLBAAEB.ElitePack;
		}
		else
		{
			GPABKIOEGKM = NKHJBLBAAEB.ElitePack;
		}
		Singleton<GuiManager>.instance.ShowDialog(this, 1450f);
	}

	private void GOLGLDKAIJD()
	{
		NGDFLDKCNGC.gameObject.SetActive(value: true);
		MDOIBOKBEHO.gameObject.SetActive(value: true);
		LMGOAHCLDDH.gameObject.SetActive(value: false);
		BDDMIDHPDKF.gameObject.SetActive(value: true);
		BBMHNPCPPBD.gameObject.SetActive(value: false);
		DJKMIAOPMOC.gameObject.SetActive(value: false);
		LFIGCJLPJHN.gameObject.SetActive(value: false);
		LMJKDIDALPI.gameObject.SetActive(value: false);
		MIKGHDGKLED.gameObject.SetActive(value: true);
		HGKEBMOFJPB.gameObject.SetActive(value: true);
		NDIFONPJHCK();
		AHHBOOKDBDI(5);
		OKMNFHNBMFA.text = Localization.Localize("ID_VALUEPACK");
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < PBELIMEMCFJ.ACNHHOFIJMH.Length; i++)
		{
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.Gold)
			{
				num = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.VIP)
			{
				num2 = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.Customization)
			{
				num3 = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand)
			{
				num4 = i;
			}
		}
		EGICOCDAAIL[0].InitializeTexts(Localization.Localize("ID_PERMANENTUNLOCK"), Localization.Localize("ID_EXTRAWARCARDSLOT"));
		EGICOCDAAIL[0].InitializeIcon("menu-packs-cardslot-ico", KJKHMLGIDPE, 300f, -1f);
		EGICOCDAAIL[0].StopAnimation();
		EGICOCDAAIL[0].ShowFree(FNODNFMDBCF: false);
		EGICOCDAAIL[1].InitializeTexts(Localization.Localize("ID_EXCLUSIVECHARACTER"), Localization.Localize("ID_ALIEN"));
		EGICOCDAAIL[1].InitializeIcon("menu-camos-alien", DJANOPAECLJ, 266f, -2f);
		EGICOCDAAIL[1].StopAnimation();
		EGICOCDAAIL[1].ShowFree(PBELIMEMCFJ.ACNHHOFIJMH[num3].isFree);
		EGICOCDAAIL[2].InitializeTexts(Localization.Localize("ID_EXCLUSIVEHELMET"), Localization.Localize("ID_SKULL"));
		EGICOCDAAIL[2].InitializeIcon("menu-helmets-reaper", DJANOPAECLJ, 260f, -2f);
		EGICOCDAAIL[2].StopAnimation();
		EGICOCDAAIL[2].ShowFree(PBELIMEMCFJ.ACNHHOFIJMH[num4].isFree);
		EGICOCDAAIL[3].InitializeTexts(Localization.Localize("ID_INSTANTRICHIES"), Localization.LocalizeFormat("ID_PACKXGOLD", MEJMLNDFDBP.GMIPFLIEOHD(PBELIMEMCFJ.ACNHHOFIJMH[num].amount)));
		EGICOCDAAIL[3].InitializeIcon("menu-gold", JBIKIJKOPAI, 184f, 0f, PLPAOCEGDBP: true);
		EGICOCDAAIL[3].StopAnimation();
		EGICOCDAAIL[3].ShowFree(PBELIMEMCFJ.ACNHHOFIJMH[num].isFree);
		EGICOCDAAIL[4].InitializeTexts(Localization.Localize("ID_VIPBENEFIT"), Localization.LocalizeFormat("ID_TIMEOFVIP", MEJMLNDFDBP.EMICJKACBAH(PBELIMEMCFJ.ACNHHOFIJMH[num2].amount)));
		EGICOCDAAIL[4].InitializeIcon("menu-hub-multiplayer-vipico", JBIKIJKOPAI, 232f, 0f);
		EGICOCDAAIL[4].StopAnimation();
		EGICOCDAAIL[4].ShowFree(PBELIMEMCFJ.ACNHHOFIJMH[num2].isFree);
		MDOIBOKBEHO.Play();
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Value).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(NGNPIOOAHEH.Value).Value2;
		float num5 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Value);
		bool flag = num5 > 0f;
		JPCIACBHGHO.text = Localization.Localize("ID_VALUEPACKDESCRIPTION");
		MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 45f, 20f, 1440);
		FECLHMEPHIL.text = Localization.Localize("ID_BUYVALUEPACK");
		MEJMLNDFDBP.COCBCFKJOJE(FECLHMEPHIL, 57f, 20f, 600);
		FBLMHFBKLJA.text = value;
		JPCIACBHGHO.transform.localPosition = JPCIACBHGHO.transform.localPosition.ReplaceY(4f);
		PFKFEKGICEN.transform.localPosition = PFKFEKGICEN.transform.localPosition.ReplaceXY(-60f, -69f);
		AMKGEJIKJOL.transform.localPosition = AMKGEJIKJOL.transform.localPosition.ReplaceX(-584f);
		PFKFEKGICEN.SetActive(flag);
		if (flag)
		{
			FNMGABBADHO.text = Localization.LocalizeFormat("ID_SAVEPERCENTLINE", MEJMLNDFDBP.JJOJLCBJBAJ(num5));
			ENMHNOPGAOE(value2);
		}
		bool flag2 = PBELIMEMCFJ.MGJIPPFKDOE > 0;
		OOJLGEIEFHM.SetActive(flag2);
		if (flag2)
		{
			WinStreakCounter mPKHGPHLMDB = MPKHGPHLMDB;
			mPKHGPHLMDB.JEMKCLKCOMI = (Action)Delegate.Remove(mPKHGPHLMDB.JEMKCLKCOMI, new Action(FMKGNLPKGAO));
			WinStreakCounter mPKHGPHLMDB2 = MPKHGPHLMDB;
			mPKHGPHLMDB2.JEMKCLKCOMI = (Action)Delegate.Combine(mPKHGPHLMDB2.JEMKCLKCOMI, new Action(FMKGNLPKGAO));
			MPKHGPHLMDB.MHLJHMOPDAO(PBELIMEMCFJ.MGJIPPFKDOE);
		}
	}

	private void EEMPDHLBJDH()
	{
		PDDOJAMAOHB += Time.deltaTime;
		if (PDDOJAMAOHB - GKGDDPMLJDD >= NNKDKBKGGEG)
		{
			GKGDDPMLJDD = PDDOJAMAOHB;
			if (EDICAAJEMJE >= LAPLALGPMMK.Length)
			{
				EDICAAJEMJE = 0;
			}
			LAPLALGPMMK[EDICAAJEMJE].StartAnimation();
			EDICAAJEMJE++;
		}
	}

	public virtual void OCIPCBNMLCN()
	{
		base.DoBeforeShowUp();
		GLHDBGIELDM = GuiScreenSingle<EndScreen>.instance.NPFFMLLLDAF();
		if (GLHDBGIELDM)
		{
			Singleton<ChillingoSdkManager>.instance.DEFKEAEFCKI();
		}
	}

	private void CEJCMDMIOED()
	{
		float num = 1543f;
		float num2 = 1538f;
		float num3 = 1332f;
		float num4 = 1574f;
		float val = num + Singleton<GameVariables>.instance.multiplierYfromRatio * (num2 - num);
		float num5 = num4 + Singleton<GameVariables>.instance.multiplierXfromRatio * (num3 - num4);
		BDDMIDHPDKF.transform.localScale = BDDMIDHPDKF.transform.localScale.ReplaceY(val);
		JPCIACBHGHO.lineWidth = (int)num5;
		FJOLANLFDLD.text = Localization.Localize("GetRewardedInfoForZoneID");
		MPKHGPHLMDB.transform.localPosition = MPKHGPHLMDB.transform.localPosition.ReplaceX(FJOLANLFDLD.relativeSize.x * FJOLANLFDLD.transform.localScale.x + 1281f);
	}

	private void NDIFONPJHCK()
	{
		OKMNFHNBMFA.color = ((GPABKIOEGKM != NKHJBLBAAEB.ElitePack) ? Colours.goldAssignment : Colours.cyanElite);
		NGNPFPDPIKP.spriteName = ((GPABKIOEGKM != NKHJBLBAAEB.ElitePack) ? "menu-valuepack-buybutton" : "menu-elitepack-buybutton");
		IKMFEDJKBAK.color = ((GPABKIOEGKM != NKHJBLBAAEB.ElitePack) ? Colours.goldAssignment : Colours.cyanElite);
		DJKMIAOPMOC.alpha = ((GPABKIOEGKM != NKHJBLBAAEB.ElitePack) ? 1f : 0.375f);
		MPKHGPHLMDB.KGNGFHMBHMJ.color = ((GPABKIOEGKM != NKHJBLBAAEB.ElitePack) ? Colours.goldAssignment : Colours.cyanElite);
	}

	public virtual void LMNNNHJKMFP()
	{
		EDICAAJEMJE = 1;
		PDDOJAMAOHB = 979f;
		GKGDDPMLJDD = PDDOJAMAOHB - 346f;
		if (GPABKIOEGKM == NKHJBLBAAEB.ValuePack)
		{
			GOLGLDKAIJD();
		}
		else
		{
			APODJFDHCDO();
		}
	}

	public virtual void LHDAGAGDKOM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(FNOFLJEOHGJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCOMBPLJLNL));
		UIEventListener uIEventListener2 = UIEventListener.Get(LJNPCHFCGCN);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener3 = UIEventListener.Get(AMKGEJIKJOL);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MGCAMKFBJGN += OBEFDCJNOHJ;
		CEJCMDMIOED();
		JCBMIMINLBN();
	}

	protected virtual void EBGBDDIADEJ()
	{
		base.OGJGIMLMJBF();
		if (GPABKIOEGKM == NKHJBLBAAEB.ValuePack)
		{
			PCGECPNFHAL();
		}
		else if (GPABKIOEGKM == NKHJBLBAAEB.ElitePack)
		{
			KCENGHIANIK();
		}
	}

	private void JNJHLECBADG()
	{
		PDDOJAMAOHB += Time.deltaTime;
		if (PDDOJAMAOHB - GKGDDPMLJDD >= NNKDKBKGGEG)
		{
			GKGDDPMLJDD = PDDOJAMAOHB;
			if (EDICAAJEMJE >= EGICOCDAAIL.Length || !EGICOCDAAIL[EDICAAJEMJE].gameObject.activeSelf)
			{
				EDICAAJEMJE = 0;
			}
			EGICOCDAAIL[EDICAAJEMJE].StartAnimation();
			EDICAAJEMJE++;
		}
	}

	private void ODJKECAPAKC()
	{
		WinStreakCounter mPKHGPHLMDB = MPKHGPHLMDB;
		mPKHGPHLMDB.JEMKCLKCOMI = (Action)Delegate.Remove(mPKHGPHLMDB.JEMKCLKCOMI, new Action(ODJKECAPAKC));
		MPKHGPHLMDB.KGNGFHMBHMJ.text = Localization.Localize("Wrong_Unit");
	}

	private void HCOMBPLJLNL(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	private void KJCADHKJFPH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			string cBMKJAFIBKH = string.Empty;
			if (CEEOLBCLPOB)
			{
				cBMKJAFIBKH = "Battle_End_Dialog";
			}
			else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<MainScreen>.instance)
			{
				cBMKJAFIBKH = "Main_Menu_Offers_Bar";
			}
			else if (Singleton<GuiManager>.instance.AODFEHKBJIN == GuiScreenSingle<CardMenuScreen>.instance)
			{
				cBMKJAFIBKH = "WarCards_Screen";
			}
			string kJBPJOMHNKB = ((PBELIMEMCFJ != null) ? PBELIMEMCFJ.KJBPJOMHNKB : Singleton<GameVariables>.instance.PackId(NGNPIOOAHEH.Value));
			Singleton<BeanstalkServerManager>.instance.BuyPack(kJBPJOMHNKB, cBMKJAFIBKH);
			if (GuiScreenSingle<CardMenuScreen>.instance.isShowed)
			{
				GuiScreenSingle<CardMenuScreen>.instance.DBNFECBDIJK.SetStarterOrValuePack();
			}
			HideDialog();
		}
	}

	private void OBEFDCJNOHJ()
	{
		if (NPFFMLLLDAF())
		{
			if (GPABKIOEGKM == NKHJBLBAAEB.ValuePack)
			{
				LJMAMAGJJHP();
			}
			else
			{
				EBNIECLKKEA();
			}
		}
	}

	private void LJMAMAGJJHP()
	{
		NGDFLDKCNGC.gameObject.SetActive(value: false);
		MDOIBOKBEHO.gameObject.SetActive(value: false);
		LMGOAHCLDDH.gameObject.SetActive(value: true);
		BDDMIDHPDKF.gameObject.SetActive(value: true);
		BBMHNPCPPBD.gameObject.SetActive(value: false);
		DJKMIAOPMOC.gameObject.SetActive(value: false);
		LFIGCJLPJHN.gameObject.SetActive(value: false);
		LMJKDIDALPI.gameObject.SetActive(value: true);
		MIKGHDGKLED.gameObject.SetActive(value: true);
		HGKEBMOFJPB.gameObject.SetActive(value: false);
		NDIFONPJHCK();
		BGDDAODEDFG(3);
		OKMNFHNBMFA.text = Localization.Localize("game-ico-blind");
		int num = 1;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < PBELIMEMCFJ.ACNHHOFIJMH.Length; i += 0)
		{
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.Gold)
			{
				num = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks)
			{
				num2 = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.Unit)
			{
				num3 = i;
			}
			if (PBELIMEMCFJ.ACNHHOFIJMH[i].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand)
			{
				num4 = i;
			}
		}
		EGICOCDAAIL[1].PFOBJLNAHDO(Localization.Localize("subscription"), Localization.Localize("ID_ARENARULES_SLOWERRELOADING"));
		EGICOCDAAIL[1].GHGBNKIMKJB("trial", KJKHMLGIDPE, 539f, 749f, PLPAOCEGDBP: true);
		EGICOCDAAIL[1].IPPOJGPDCOI();
		EGICOCDAAIL[0].EHGMOLJMBPK(FNODNFMDBCF: false);
		EGICOCDAAIL[0].InitializeTexts(Localization.Localize("VipReward1"), Localization.Localize("ID_WAITINGFORFRIENDCARDS"));
		EGICOCDAAIL[0].HDBLKKNNKOO("ShootCopyRPC", DJANOPAECLJ, 658f, 933f, PLPAOCEGDBP: true);
		EGICOCDAAIL[0].BONJBDPAGGP();
		EGICOCDAAIL[0].ShowFree(PBELIMEMCFJ.ACNHHOFIJMH[num3].isFree);
		EGICOCDAAIL[0].HAPNIEIOLDP(Localization.Localize(" is not supported on this platform!"), Localization.Localize("LeagueEvaluation"));
		EGICOCDAAIL[6].HDBLKKNNKOO("ID_YOUROPPONENTHASDENIED", DJANOPAECLJ, 1052f, 843f, PLPAOCEGDBP: true);
		EGICOCDAAIL[1].StopAnimation();
		EGICOCDAAIL[6].PJKLNNPHMFF(PBELIMEMCFJ.ACNHHOFIJMH[num4].isFree);
		EGICOCDAAIL[5].HAPNIEIOLDP(Localization.Localize("$#"), Localization.LocalizeFormat("Translation", MEJMLNDFDBP.GMIPFLIEOHD(PBELIMEMCFJ.ACNHHOFIJMH[num].amount)));
		EGICOCDAAIL[1].InitializeIcon("()F", JBIKIJKOPAI, 1795f, 462f);
		EGICOCDAAIL[1].BONJBDPAGGP();
		EGICOCDAAIL[0].PJKLNNPHMFF(PBELIMEMCFJ.ACNHHOFIJMH[num].isFree);
		PackContentRecord obj = EGICOCDAAIL[0];
		string lGPFGGHLKIA = Localization.Localize("DeliveryTime");
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.EMICJKACBAH(PBELIMEMCFJ.ACNHHOFIJMH[num2].amount);
		obj.PFOBJLNAHDO(lGPFGGHLKIA, Localization.LocalizeFormat("BS: On Get Full Squad Info", array));
		EGICOCDAAIL[5].ABNBAGBPBKA("ID_ARENABOXDESCRIPTION_ELITEPARTS", JBIKIJKOPAI, 614f, 1251f, PLPAOCEGDBP: true);
		EGICOCDAAIL[4].IPPOJGPDCOI();
		EGICOCDAAIL[3].JCBPDCLGAOH(PBELIMEMCFJ.ACNHHOFIJMH[num2].isFree);
		MDOIBOKBEHO.Play();
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Bronze).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK((NGNPIOOAHEH)8).Value2;
		float num5 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.None);
		bool flag = num5 > 1594f;
		JPCIACBHGHO.text = Localization.Localize("NO");
		MEJMLNDFDBP.COCBCFKJOJE(JPCIACBHGHO, 187f, 640f, 149);
		FECLHMEPHIL.text = Localization.Localize("ShowNameRPC");
		MEJMLNDFDBP.COCBCFKJOJE(FECLHMEPHIL, 1934f, 349f, -168);
		FBLMHFBKLJA.text = value;
		JPCIACBHGHO.transform.localPosition = JPCIACBHGHO.transform.localPosition.ReplaceY(915f);
		PFKFEKGICEN.transform.localPosition = PFKFEKGICEN.transform.localPosition.ReplaceXY(1423f, 1747f);
		AMKGEJIKJOL.transform.localPosition = AMKGEJIKJOL.transform.localPosition.ReplaceX(1231f);
		PFKFEKGICEN.SetActive(flag);
		if (flag)
		{
			UILabel fNMGABBADHO = FNMGABBADHO;
			object[] array2 = new object[1];
			array2[1] = MEJMLNDFDBP.JJOJLCBJBAJ(num5);
			fNMGABBADHO.text = Localization.LocalizeFormat(" OK!", array2);
			ENMHNOPGAOE(value2);
		}
		bool flag2 = PBELIMEMCFJ.MGJIPPFKDOE > 1;
		OOJLGEIEFHM.SetActive(flag2);
		if (flag2)
		{
			WinStreakCounter mPKHGPHLMDB = MPKHGPHLMDB;
			mPKHGPHLMDB.JEMKCLKCOMI = (Action)Delegate.Remove(mPKHGPHLMDB.JEMKCLKCOMI, new Action(JJOMHNEBEIL));
			WinStreakCounter mPKHGPHLMDB2 = MPKHGPHLMDB;
			mPKHGPHLMDB2.JEMKCLKCOMI = (Action)Delegate.Combine(mPKHGPHLMDB2.JEMKCLKCOMI, new Action(JJOMHNEBEIL));
			MPKHGPHLMDB.APFDDFPMACA(PBELIMEMCFJ.MGJIPPFKDOE);
		}
	}

	private void BOEOGLOGFBP()
	{
		float num = 274f;
		float num2 = 300f;
		float num3 = 720f;
		float num4 = 850f;
		float val = num + Singleton<GameVariables>.instance.multiplierYfromRatio * (num2 - num);
		float num5 = num4 + Singleton<GameVariables>.instance.multiplierXfromRatio * (num3 - num4);
		BDDMIDHPDKF.transform.localScale = BDDMIDHPDKF.transform.localScale.ReplaceY(val);
		JPCIACBHGHO.lineWidth = (int)num5;
		FJOLANLFDLD.text = Localization.Localize("ID_OFFERENDSIN");
		MPKHGPHLMDB.transform.localPosition = MPKHGPHLMDB.transform.localPosition.ReplaceX(FJOLANLFDLD.relativeSize.x * FJOLANLFDLD.transform.localScale.x + 18f);
	}

	private void JCBMIMINLBN()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = 698f;
		float num2 = 1450f;
		float num3 = (activeWidthSafe - (1182f * num + 1320f * num2)) / 1149f;
		float activeHeight = UIHelper.activeHeight;
		float num4 = activeHeight / 1580f;
		float num5 = CAMPOJMAMCN.NHBHIPOAFMA();
		float num6 = 1348f;
		float fBMIFHHEOBO = num4 - (num5 + 714f - num6 + 283f) + 560f;
		float num7 = num5 + num6;
		float num8 = 640f;
		float num9 = 411f;
		float num10 = 0f - num4 + DHKGJIAEPAM.computeHeight + num8 + num9 / 1334f;
		float fBMIFHHEOBO2 = num7 - num10;
		for (int i = 0; i < BKMPMCFCOAF.Length; i++)
		{
			BKMPMCFCOAF[i].MFMJPBCIHEH(num3, fBMIFHHEOBO);
		}
		AFFFKHMOCIJ.cellWidth = num3 + num2;
		for (int j = 0; j < LAPLALGPMMK.Length; j++)
		{
			LAPLALGPMMK[j].JHOEENOBNEB(num3, fBMIFHHEOBO2);
		}
		AAOCCHKEPCB.KOIPDOOMEMM(num3, fBMIFHHEOBO2);
		AAOCCHKEPCB.transform.localPosition = AAOCCHKEPCB.transform.localPosition.ReplaceX((0f - num3) / 1955f - 412f + 314f);
		DGDIFKKKILH.KOIPDOOMEMM(num3, fBMIFHHEOBO2);
		DGDIFKKKILH.transform.localPosition = DGDIFKKKILH.transform.localPosition.ReplaceX(num3 / 865f + 129f - 800f);
		OMABECKFFBG.transform.localPosition = OMABECKFFBG.transform.localPosition.ReplaceX(num + num3 / 522f);
		OMABECKFFBG.cellWidth = num3 + num2;
	}

	public GuiElement GKHMFKHFKBN()
	{
		return this;
	}
}
