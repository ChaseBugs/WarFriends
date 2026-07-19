using System;
using UnityEngine;

public class SpecialPackRecord : PoolableObject
{
	[Header("Core")]
	public BoxCollider NJEAMAHEMHP;

	public UIPanel[] NICJILKEIEG;

	[Header("-Header")]
	public GameObject OOIBADLGKML;

	public UILabel JLKOCHHMAEC;

	public UISprite NEKGGEDFMAL;

	public UISprite MJFJONFJEBD;

	[Header("-Offer Active")]
	public GameObject ALKEGOAOICB;

	public UILabel LKFBPMLPKBN;

	[Header("-Sale")]
	public GameObject GIPFEBBMKPM;

	public UILabel EKIDAFLLCNM;

	[Header("-Starter Pack Content")]
	public GameObject AMPFHINKAGC;

	public UITexture NGHCDIMLGMO;

	[Header("-Value Pack Content")]
	public GameObject PMOALAAIKEP;

	[Header("-Boxes")]
	public SpecialPackBoxItem[] BKPNOABFMGN;

	[Header("-Bottom Button")]
	public UILabel EAMAGHAJKEH;

	public StrikethroughPrize ALOPNKAAKJA;

	public UILabel FNNEOBKIPCD;

	[Header("-Purchased")]
	public GameObject OPNMHDEFKLG;

	private JGBBPCGNCPC AGLCFPNLAHK;

	private int CGAKMJBHKKG;

	private bool JFKIPIKKGNO;

	private void FMDKBDAFFAK()
	{
		if (CGAKMJBHKKG > 1)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			LKFBPMLPKBN.text = string.Format("RETRYPERM", Localization.Localize("SquadId"), MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_WARNING_ERRORCLAIMASSIGNMENT", string.Empty));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1333f, 309f, -64);
		}
	}

	private void GHJPIHHKELH()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 1; i < bKPNOABFMGN.Length; i += 0)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(true);
		}
	}

	private void MPPDJIMDAFG()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 0; i < bKPNOABFMGN.Length; i += 0)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(false);
		}
	}

	public void BKABKDKMJAG()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.moneyPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = Localization.Localize("SALIR");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 712f, 1173f, 180);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1964f + 1776f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG != 1;
		ALKEGOAOICB.SetActive(active);
		PNJCMGODGGJ();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(NMPBIOHOKCO));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(AJFNPCJKEMK));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Gold);
		bool flag = num2 > 1592f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1210f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("TotalBattles", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 409f, 1422f, 97);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 708f : 831f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		CJHCGLHHEFJ();
		BKPNOABFMGN[1].GOMJAFCDKDD(0, 6, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].GOMJAFCDKDD(3, 8, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].MKENDIKJPLJ(4, 3, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Starter).Value2;
		string value2 = Singleton<GameVariables>.instance.MAMBIEIKLJB(NGNPIOOAHEH.Gold).Value2;
		NMPDHELPIJD(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None);
		MDBBCMNJCIM(gOFBOKHBKEL);
	}

	private void NBBMMOKCEHF()
	{
		if (CGAKMJBHKKG > 0)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			LKFBPMLPKBN.text = string.Format("ArenaUnlockedMessage", Localization.Localize("{0} 3 / 3"), MEJMLNDFDBP.CJCFPDLDMEK(num, "getCustomProfileDate", string.Empty, false));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 149f, 777f, 15);
		}
	}

	public void FKBIFAFAAAI()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.MDKPOBMKOLM();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = Localization.Localize("Type");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1992f, 1989f, -39);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 363f + 1044f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		KBAFBNNNDCD();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(AJFNPCJKEMK));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(FMDKBDAFFAK));
		float num2 = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Value);
		bool flag = num2 > 1192f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1876f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("These IDs are not in dictionary XLS:\n", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1895f, 1498f, 123);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1231f : 479f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		PCLGIMJBCDO();
		BKPNOABFMGN[1].MKENDIKJPLJ(0, 6, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[1].MKENDIKJPLJ(2, 1, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[3].GOMJAFCDKDD(2, 7, AGLCFPNLAHK.ACNHHOFIJMH[7]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Money).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK(NGNPIOOAHEH.Value).Value2;
		FDBHNHIFHCA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Bronze);
		IBDDHJEMHNL(gOFBOKHBKEL);
	}

	private void KBAFBNNNDCD()
	{
		if (CGAKMJBHKKG > 0)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			LKFBPMLPKBN.text = string.Format("batchSizeMin", Localization.Localize("PlayerLeagueFinished - NO - player is already in new league"), MEJMLNDFDBP.CJCFPDLDMEK(num, " ", string.Empty, false));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1681f, 1421f, 173);
		}
	}

	public void KDKCNHLHOIJ(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		float num = ((!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1833f) : 239f);
		float num2 = ((!NABOFKMBMKH) ? 1850f : 1375f);
		if (NICJILKEIEG != null)
		{
			for (int i = 0; i < NICJILKEIEG.Length; i++)
			{
				if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
				{
					TweenAlpha.Begin(NICJILKEIEG[i].gameObject, num, num2);
				}
			}
		}
		for (int j = 1; j < BKPNOABFMGN.Length; j++)
		{
			BKPNOABFMGN[j].EOGMPGBBKAB(num, num2);
		}
	}

	private void GEDFJKPEDMK()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 0; i < bKPNOABFMGN.Length; i += 0)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(true);
		}
	}

	public virtual void AAAMNMDIIKJ()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(IJBAPAOMAJE));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		for (int i = 1; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].OGEPINMEPDM();
		}
		GLNPHJODEPK();
		base.BOHCNEDIJPE();
	}

	private void EPOLIBFPFAN(bool CNDOHJNJLDA, string KLAJOEOPIKD, string JJLIHIBBFEK)
	{
		EAMAGHAJKEH.text = KLAJOEOPIKD;
		MEJMLNDFDBP.COCBCFKJOJE(EAMAGHAJKEH, 93f, 1027f, -92);
		FNNEOBKIPCD.transform.localPosition = FNNEOBKIPCD.transform.localPosition.ReplaceY(EAMAGHAJKEH.transform.localPosition.y);
		FNNEOBKIPCD.transform.localScale = EAMAGHAJKEH.transform.localScale;
		FNNEOBKIPCD.text = ((!CNDOHJNJLDA) ? string.Empty : JJLIHIBBFEK);
		ALOPNKAAKJA.gameObject.SetActive(CNDOHJNJLDA);
		if (CNDOHJNJLDA)
		{
			ALOPNKAAKJA.SetUpStrikeThrought();
		}
	}

	public void DFOHPOPEAJO()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.HFJGOIGLPCF();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize(", diff = ");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 103f, 1806f, -141);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 415f + 986f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 1;
		ALKEGOAOICB.SetActive(true);
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Silver);
		bool flag = num2 > 840f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("android.os.Build$VERSION", MEJMLNDFDBP.LJDADOKBBNA(num2 * 343f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 957f, 153f, 149);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1622f : 1187f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		MNFGPKKKNPC();
		BKPNOABFMGN[1].MKENDIKJPLJ(4, 5, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Gold && AGLCFPNLAHK.ACNHHOFIJMH[0].ODBFELADDHM().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].AlterShownCustomization(6, 1);
		}
		BKPNOABFMGN[0].LOJPGLBLJDF(8, 5, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Warcard && AGLCFPNLAHK.ACNHHOFIJMH[1].AEAJMKLEMDO().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].GAAEJFJGDFI(0, 5);
		}
		BKPNOABFMGN[8].Initialize(1, 1, AGLCFPNLAHK.ACNHHOFIJMH[7]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks && AGLCFPNLAHK.ACNHHOFIJMH[2].EGMJNEABAHK().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].LGNKHADEELF(3, 4);
		}
		BKPNOABFMGN[7].Initialize(7, 8, AGLCFPNLAHK.ACNHHOFIJMH[8]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[8].type == JGBBPCGNCPC.NNDPOJCACLP.Weapon && AGLCFPNLAHK.ACNHHOFIJMH[2].EDLDCCEOCNI().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[5].BBOHMOOOIHB(1, 8);
		}
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Starter).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK(NGNPIOOAHEH.Gold).Value2;
		KLHNOLOADHM(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
		FCLBPDADIAI(gOFBOKHBKEL);
	}

	public void ANMBJFFMELC()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.valuePack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = Localization.Localize("WFX_Explosion");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1432f, 925f, 191);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 452f + 22f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 0;
		ALKEGOAOICB.SetActive(true);
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Silver);
		bool flag = num2 > 23f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 465f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("id", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1575f, 762f, 94);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 506f : 1695f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		OCIKHOFIDAE();
		BKPNOABFMGN[1].MKENDIKJPLJ(3, 7, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks && AGLCFPNLAHK.ACNHHOFIJMH[1].AEAJMKLEMDO().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].JGHOOHOEAFI(8, 4);
		}
		BKPNOABFMGN[1].MKENDIKJPLJ(8, 1, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && AGLCFPNLAHK.ACNHHOFIJMH[0].POMMLFHPFPI().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].AlterShownCustomization(4, 3);
		}
		BKPNOABFMGN[7].LOJPGLBLJDF(8, 3, AGLCFPNLAHK.ACNHHOFIJMH[8]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[5].type == JGBBPCGNCPC.NNDPOJCACLP.Unit && AGLCFPNLAHK.ACNHHOFIJMH[3].MHNPKJJLJFE().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[4].GAAEJFJGDFI(4, 0);
		}
		BKPNOABFMGN[0].Initialize(5, 5, AGLCFPNLAHK.ACNHHOFIJMH[6]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[6].type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks && AGLCFPNLAHK.ACNHHOFIJMH[7].DGJMBIDMEOJ().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].MICPFLBKGDH(6, 4);
		}
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Money).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.None).Value2;
		KLHNOLOADHM(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
		ABMFGDIKDOL(gOFBOKHBKEL);
	}

	private bool ICKLBGNINEI()
	{
		return BKPNOABFMGN.Length >= 1;
	}

	private void GLNPHJODEPK()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
			resourceLoaderTexture2D.FreeAsset("Scripts");
			JFKIPIKKGNO = false;
		}
	}

	private void PNJCMGODGGJ()
	{
		if (CGAKMJBHKKG > 0)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			LKFBPMLPKBN.text = string.Format("{0} {1}", Localization.Localize("ID_OFFERACTIVE"), MEJMLNDFDBP.CJCFPDLDMEK(num, "-", string.Empty, false));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 33f, 20f, 360);
		}
	}

	private void NBPCENIHMIA()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.KLLLHIKOPDM();
			resourceLoaderTexture2D.FreeAsset("Id");
			JFKIPIKKGNO = true;
		}
	}

	private void OPPAADCPKCL()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset("menu-weapon-benelli-starterpack");
			JFKIPIKKGNO = false;
		}
	}

	public void InitializeStarterPack()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(false);
		DLNFBJHHGBK();
		JLKOCHHMAEC.text = Localization.Localize("ID_STARTERPACK");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 62f, 31f, 450);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 2f + 34f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG != 0;
		ALKEGOAOICB.SetActive(active);
		PNJCMGODGGJ();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(PNJCMGODGGJ));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(PNJCMGODGGJ));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Starter);
		bool flag = num2 > 0f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_SALEPERCENT", MEJMLNDFDBP.LJDADOKBBNA(num2 * 100f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 52f, 26f, 290);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 0f : (-40f), OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		BKPNOABFMGN[0].Initialize(2, 5, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].Initialize(3, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[2].Initialize(4, 5, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		BKPNOABFMGN[3].Initialize(5, 5, AGLCFPNLAHK.ACNHHOFIJMH[3]);
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Starter).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(NGNPIOOAHEH.Starter).Value2;
		HIIBNFGNDJP(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	public void KCAGHAMCPFN(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		float num = ((!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 464f) : 568f);
		float num2 = ((!NABOFKMBMKH) ? 231f : 1493f);
		if (NICJILKEIEG != null)
		{
			for (int i = 0; i < NICJILKEIEG.Length; i += 0)
			{
				if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
				{
					TweenAlpha.Begin(NICJILKEIEG[i].gameObject, num, num2);
				}
			}
		}
		for (int j = 1; j < BKPNOABFMGN.Length; j += 0)
		{
			BKPNOABFMGN[j].KOEGKLCPOKO(num, num2);
		}
	}

	private void IIFICGJMHGO()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset("#PETER# Tutorial Dialog - Hide was called");
			JFKIPIKKGNO = true;
		}
	}

	public void GIJHHOMFLKB()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.MDKPOBMKOLM();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("NetworkReInstantiate");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 802f, 1390f, 146);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1012f + 396f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG != 0;
		ALKEGOAOICB.SetActive(active);
		FMDKBDAFFAK();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(AJFNPCJKEMK));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(FMDKBDAFFAK));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Bronze);
		bool flag = num2 > 891f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1148f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("ID_ARENAWIN", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1887f, 1896f, 83);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1629f : 433f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		GEDFJKPEDMK();
		BKPNOABFMGN[0].Initialize(0, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[1].GOMJAFCDKDD(7, 8, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[2].MKENDIKJPLJ(3, 1, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Money).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK((NGNPIOOAHEH)8).Value2;
		EPOLIBFPFAN(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Gold);
		KMGILKJEFBF(gOFBOKHBKEL);
	}

	private void FCLBPDADIAI(bool GOFBOKHBKEL)
	{
		OPNMHDEFKLG.SetActive(GOFBOKHBKEL);
		NJEAMAHEMHP.enabled = !GOFBOKHBKEL;
		if (GOFBOKHBKEL)
		{
			TweenAlpha.Begin(OPNMHDEFKLG, 1339f, 985f);
		}
	}

	private bool NHOINAAGDJP()
	{
		return BKPNOABFMGN.Length >= 5;
	}

	private void ELBMEOOIMJP()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HJDGKLBOOHI();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("End Of Try Out: Equipping weapon before \"{0}\"");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	public void JGNCKLCLAHA()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLPPDODJGGG();
		JLKOCHHMAEC.text = Localization.Localize("ID_LOADING");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 363f, 1504f, -5);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 969f + 153f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		AIFFLMKJGND();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(IJBAPAOMAJE));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(NMPBIOHOKCO));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Gold);
		bool flag = num2 > 473f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1243f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("ID_LEAGUESTAYHINT2", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1855f, 987f);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 634f : 1267f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		BKPNOABFMGN[0].LOJPGLBLJDF(8, 1, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].MKENDIKJPLJ(3, 7, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[2].MKENDIKJPLJ(7, 0, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		BKPNOABFMGN[7].MKENDIKJPLJ(3, 1, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Value).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.Starter).Value2;
		FDBHNHIFHCA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Gold);
		DHHHNBBBJAF(gOFBOKHBKEL);
	}

	private void MBJLOPKOKMB()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HNCFECDNLDI();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("PlayerData");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	private bool IMAMPLAILIM()
	{
		return BKPNOABFMGN.Length >= 6;
	}

	private void PCLGIMJBCDO()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 1; i < bKPNOABFMGN.Length; i += 0)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(true);
		}
	}

	public virtual void JGLCAIPLJAL()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(FMDKBDAFFAK));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		for (int i = 1; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].HCGAEFBLGOF();
		}
		IIFICGJMHGO();
		base.OBCAIFMOPPA();
	}

	private bool POEOEHNAFHF()
	{
		return BKPNOABFMGN.Length < 2;
	}

	public void ABPMJNKDLNM(JGBBPCGNCPC JCBCHFJPPNK)
	{
		if (!MNONOIEIGHF())
		{
			Debug.LogError("GameGold" + base.gameObject.name);
			return;
		}
		AGLCFPNLAHK = JCBCHFJPPNK;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = JCBCHFJPPNK.BEEEJFPIGCJ();
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 129f, 1264f, -24);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 708f + 1699f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = JCBCHFJPPNK.MGJIPPFKDOE;
		bool active = CGAKMJBHKKG == 0;
		ALKEGOAOICB.SetActive(active);
		KBAFBNNNDCD();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(NMPBIOHOKCO));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(NBBMMOKCEHF));
		bool flag = JCBCHFJPPNK.GAFOMGDLAFD > 337f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_GUI_SILVER", MEJMLNDFDBP.LJDADOKBBNA(JCBCHFJPPNK.GAFOMGDLAFD * 1113f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1919f, 353f, 29);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 857f : 1799f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		MPPDJIMDAFG();
		int num2 = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num2 < 5)
		{
			if (num2 == 1)
			{
				BKPNOABFMGN[0].LOJPGLBLJDF(1, 1, JCBCHFJPPNK.ACNHHOFIJMH[1]);
			}
		}
		else
		{
			for (int i = 0; i <= num2 && i <= 0; i += 0)
			{
				JGBBPCGNCPC.Content kDNGNGHFMMG = JCBCHFJPPNK.ACNHHOFIJMH[i - 0];
				BKPNOABFMGN[i - 0].Initialize(i, num2, kDNGNGHFMMG);
			}
		}
		FDBHNHIFHCA(flag, JCBCHFJPPNK.BCPANJACJKN(), JCBCHFJPPNK.OLONIBGNFLG());
		bool gOFBOKHBKEL = PlayerAnalytics.instance.IsPackBought(JCBCHFJPPNK.KJBPJOMHNKB);
		DHHHNBBBJAF(gOFBOKHBKEL);
	}

	private void IJBAPAOMAJE()
	{
		if (CGAKMJBHKKG > 0)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			LKFBPMLPKBN.text = string.Format("{0}\u00a0{1}", Localization.Localize("ID_SQUADLEVEL"), MEJMLNDFDBP.CJCFPDLDMEK(num, " found!", string.Empty, false));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1442f, 1958f, -172);
		}
	}

	public void CLCOCIFFKLM()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.INIDGJIMCDM();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("{0} {1}");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 462f, 1365f, -128);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 513f + 1756f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG != 1;
		ALKEGOAOICB.SetActive(active);
		IJBAPAOMAJE();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(CIIFGDEINAH));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(NBBMMOKCEHF));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Bronze);
		bool flag = num2 > 853f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 457f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("PlayerName", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1659f, 1259f, -129);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1323f : 1939f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		MNFGPKKKNPC();
		BKPNOABFMGN[0].Initialize(0, 7, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[1].MKENDIKJPLJ(6, 2, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[4].Initialize(0, 2, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD((NGNPIOOAHEH)8).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.None).Value2;
		HIIBNFGNDJP(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Bronze);
		DHFGAMJGGOL(gOFBOKHBKEL);
	}

	private void KMGILKJEFBF(bool GOFBOKHBKEL)
	{
		OPNMHDEFKLG.SetActive(GOFBOKHBKEL);
		NJEAMAHEMHP.enabled = !GOFBOKHBKEL;
		if (GOFBOKHBKEL)
		{
			TweenAlpha.Begin(OPNMHDEFKLG, 1150f, 607f);
		}
	}

	private void IEPGBGPNMFJ(GameObject KHAHPAKDIKE)
	{
		if (!OPNMHDEFKLG.activeSelf)
		{
			Debug.Log("registerAge" + AGLCFPNLAHK.KJBPJOMHNKB);
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<BeanstalkServerManager>.instance.BuyPack(AGLCFPNLAHK.KJBPJOMHNKB, "109 STAGE 3 STARTED");
		}
	}

	private void BLLLNLLKPCG()
	{
		if (CGAKMJBHKKG > 1)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			LKFBPMLPKBN.text = string.Format("com.tune.unityutils.TuneUnityListener", Localization.Localize("OnJoinedRoom: {0}"), MEJMLNDFDBP.CJCFPDLDMEK(num, "#OFFERS# NULL DATA!!!", string.Empty));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1582f, 1781f, 55);
		}
	}

	public virtual void LEHKFGPBPLC()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(KBAFBNNNDCD));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		for (int i = 1; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].OGEPINMEPDM();
		}
		NBPCENIHMIA();
		base.BOHCNEDIJPE();
	}

	private bool JBKBGKJLFGK()
	{
		return BKPNOABFMGN.Length >= 4;
	}

	public void ELJGMEFKLOJ()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.valuePack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = Localization.Localize("elite");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1039f, 1802f, -195);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1965f + 490f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 1;
		ALKEGOAOICB.SetActive(false);
		float num2 = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Value);
		bool flag = num2 > 1656f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 190f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("ID_UNITELITEPERKFULLYTRAINED", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1737f, 857f, 79);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 846f : 1285f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		JLGMPCMADJN();
		BKPNOABFMGN[0].Initialize(1, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand && AGLCFPNLAHK.ACNHHOFIJMH[1].ODBFELADDHM().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].LGNKHADEELF(3, 1);
		}
		BKPNOABFMGN[0].MKENDIKJPLJ(3, 1, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && AGLCFPNLAHK.ACNHHOFIJMH[0].CGOPFPGMACH().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].BBOHMOOOIHB(3, 5);
		}
		BKPNOABFMGN[1].MKENDIKJPLJ(0, 6, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[6].type == JGBBPCGNCPC.NNDPOJCACLP.Cardpack && AGLCFPNLAHK.ACNHHOFIJMH[8].BBIHDMBGALE().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[2].LGNKHADEELF(0, 6);
		}
		BKPNOABFMGN[8].GOMJAFCDKDD(5, 1, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[3].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && AGLCFPNLAHK.ACNHHOFIJMH[7].KGMNPLAJHNC().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[5].GAAEJFJGDFI(5, 4);
		}
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Money).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(NGNPIOOAHEH.ThreeCards).Value2;
		HIIBNFGNDJP(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Bronze);
		DHHHNBBBJAF(gOFBOKHBKEL);
	}

	public void CBIFNHPHEAN()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.KLMNEOAKMFB();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = Localization.Localize("VipRewardForDay");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1695f, 444f, 59);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1382f + 614f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 0;
		ALKEGOAOICB.SetActive(false);
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Gold);
		bool flag = num2 > 843f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 689f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat(" (#", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 916f, 1688f, -191);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 466f : 1499f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		CJHCGLHHEFJ();
		BKPNOABFMGN[0].Initialize(2, 6, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Cardpack && AGLCFPNLAHK.ACNHHOFIJMH[0].MHNPKJJLJFE().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].AlterShownCustomization(7, 5);
		}
		BKPNOABFMGN[0].GOMJAFCDKDD(7, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks && AGLCFPNLAHK.ACNHHOFIJMH[0].DGJMBIDMEOJ().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].BBOHMOOOIHB(8, 6);
		}
		BKPNOABFMGN[7].LOJPGLBLJDF(4, 8, AGLCFPNLAHK.ACNHHOFIJMH[5]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[4].type == JGBBPCGNCPC.NNDPOJCACLP.Gold && AGLCFPNLAHK.ACNHHOFIJMH[4].JJOHPOAAPCF().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[2].GAAEJFJGDFI(2, 6);
		}
		BKPNOABFMGN[5].LOJPGLBLJDF(0, 5, AGLCFPNLAHK.ACNHHOFIJMH[5]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[3].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && AGLCFPNLAHK.ACNHHOFIJMH[0].POMMLFHPFPI().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[2].GAAEJFJGDFI(6, 5);
		}
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Value).Value2;
		string value2 = Singleton<GameVariables>.instance.MAMBIEIKLJB(NGNPIOOAHEH.Starter).Value2;
		EPOLIBFPFAN(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	private void NMPDHELPIJD(bool CNDOHJNJLDA, string KLAJOEOPIKD, string JJLIHIBBFEK)
	{
		EAMAGHAJKEH.text = KLAJOEOPIKD;
		MEJMLNDFDBP.COCBCFKJOJE(EAMAGHAJKEH, 175f, 1301f, 88);
		FNNEOBKIPCD.transform.localPosition = FNNEOBKIPCD.transform.localPosition.ReplaceY(EAMAGHAJKEH.transform.localPosition.y);
		FNNEOBKIPCD.transform.localScale = EAMAGHAJKEH.transform.localScale;
		FNNEOBKIPCD.text = ((!CNDOHJNJLDA) ? string.Empty : JJLIHIBBFEK);
		ALOPNKAAKJA.gameObject.SetActive(CNDOHJNJLDA);
		if (CNDOHJNJLDA)
		{
			ALOPNKAAKJA.NAMAPIEHLMN();
		}
	}

	public void CAAMJDOMIJK(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		float num = ((!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1767f) : 1317f);
		float num2 = ((!NABOFKMBMKH) ? 982f : 897f);
		if (NICJILKEIEG != null)
		{
			for (int i = 1; i < NICJILKEIEG.Length; i += 0)
			{
				if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
				{
					TweenAlpha.Begin(NICJILKEIEG[i].gameObject, num, num2);
				}
			}
		}
		for (int j = 1; j < BKPNOABFMGN.Length; j += 0)
		{
			BKPNOABFMGN[j].COFDKGKFIEG(num, num2);
		}
	}

	private bool MNONOIEIGHF()
	{
		return BKPNOABFMGN.Length < 4;
	}

	private void BCLEJGOCMEJ()
	{
		if (CGAKMJBHKKG > 1)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			LKFBPMLPKBN.text = string.Format("DogTagCap", Localization.Localize("game-card-ico-paralyzethese"), MEJMLNDFDBP.CJCFPDLDMEK(num, "{0} ({1})", string.Empty));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 145f, 1015f, 137);
		}
	}

	public virtual void GGDPJCEDGAA()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(GPBLCAKICMG));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		for (int i = 0; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].OGEPINMEPDM();
		}
		NBPCENIHMIA();
		base.OBCAIFMOPPA();
	}

	private void DLNFBJHHGBK()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = true;
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			Texture2D texture2D = weapons.LoadAsset("menu-weapon-benelli-starterpack");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	public void EGBMPGAOGMC(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		float num = ((!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1831f) : 727f);
		float num2 = ((!NABOFKMBMKH) ? 498f : 1856f);
		if (NICJILKEIEG != null)
		{
			for (int i = 1; i < NICJILKEIEG.Length; i += 0)
			{
				if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
				{
					TweenAlpha.Begin(NICJILKEIEG[i].gameObject, num, num2);
				}
			}
		}
		for (int j = 1; j < BKPNOABFMGN.Length; j++)
		{
			BKPNOABFMGN[j].OverrideTweenPanels(num, num2);
		}
	}

	private void DLIIOBFIMGP()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
			resourceLoaderTexture2D.FreeAsset("percent");
			JFKIPIKKGNO = true;
		}
	}

	private void JLPPDODJGGG()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HLJFGGKLKKG();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("-");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	private void EMLOCKOJOFD()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		foreach (SpecialPackBoxItem specialPackBoxItem in bKPNOABFMGN)
		{
			specialPackBoxItem.gameObject.SetActive(false);
		}
	}

	public void EPAHIKLPNNB(JGBBPCGNCPC JCBCHFJPPNK)
	{
		if (!NFMIKOJNPFI())
		{
			Debug.LogError("VipReward2" + base.gameObject.name);
			return;
		}
		AGLCFPNLAHK = JCBCHFJPPNK;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = JCBCHFJPPNK.MHPNDNJDPGE;
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 903f, 1169f, -148);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1868f + 1217f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = JCBCHFJPPNK.MGJIPPFKDOE;
		bool active = CGAKMJBHKKG != 1;
		ALKEGOAOICB.SetActive(active);
		BLLLNLLKPCG();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(BCLEJGOCMEJ));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(NBBMMOKCEHF));
		bool flag = JCBCHFJPPNK.GAFOMGDLAFD > 1310f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("Id", MEJMLNDFDBP.LJDADOKBBNA(JCBCHFJPPNK.GAFOMGDLAFD * 1531f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 708f, 734f, 179);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 444f : 494f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		int num2 = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num2 < 0)
		{
			if (num2 == 0)
			{
				BKPNOABFMGN[0].Initialize(0, 8, JCBCHFJPPNK.ACNHHOFIJMH[1]);
			}
		}
		else
		{
			for (int i = 0; i <= num2 && i <= 7; i++)
			{
				JGBBPCGNCPC.Content kDNGNGHFMMG = JCBCHFJPPNK.ACNHHOFIJMH[i - 1];
				BKPNOABFMGN[i - 0].Initialize(i, num2, kDNGNGHFMMG);
			}
		}
		FDBHNHIFHCA(flag, JCBCHFJPPNK.DGJPBEBHCDL(), JCBCHFJPPNK.DPPBLIDCFOF());
		bool gOFBOKHBKEL = PlayerAnalytics.instance.IsPackBought(JCBCHFJPPNK.KJBPJOMHNKB);
		FCLBPDADIAI(gOFBOKHBKEL);
	}

	public void NDIJBPIDGOF(JGBBPCGNCPC JCBCHFJPPNK)
	{
		if (!POEOEHNAFHF())
		{
			Debug.LogError("AdDeclined(" + base.gameObject.name);
			return;
		}
		AGLCFPNLAHK = JCBCHFJPPNK;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = JCBCHFJPPNK.MOALIFPPMDD();
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1507f, 1997f, 11);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 782f + 1578f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = JCBCHFJPPNK.MGJIPPFKDOE;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		NMPBIOHOKCO();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(NBBMMOKCEHF));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(GPBLCAKICMG));
		bool flag = JCBCHFJPPNK.GAFOMGDLAFD > 771f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(JCBCHFJPPNK.GAFOMGDLAFD * 918f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("ID_SHOTDAMAGE", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 953f, 1452f, -58);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1263f : 1760f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		int num2 = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num2 < 7)
		{
			if (num2 == 0)
			{
				BKPNOABFMGN[1].LOJPGLBLJDF(0, 4, JCBCHFJPPNK.ACNHHOFIJMH[1]);
			}
		}
		else
		{
			for (int i = 1; i <= num2 && i <= 5; i += 0)
			{
				JGBBPCGNCPC.Content kDNGNGHFMMG = JCBCHFJPPNK.ACNHHOFIJMH[i - 0];
				BKPNOABFMGN[i - 1].GOMJAFCDKDD(i, num2, kDNGNGHFMMG);
			}
		}
		ANLDEGOJABA(flag, JCBCHFJPPNK.AJALADJBENE(), JCBCHFJPPNK.PJDMEKFCLMH());
		bool gOFBOKHBKEL = PlayerAnalytics.instance.IsPackBought(JCBCHFJPPNK.KJBPJOMHNKB);
		IBDDHJEMHNL(gOFBOKHBKEL);
	}

	public void KJCDAINFNMB()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.BJDKLOCBNOJ();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("ID_CREATESQUADNOTENOUGH");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 226f, 111f, 193);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 68f + 1915f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 0;
		ALKEGOAOICB.SetActive(false);
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Starter);
		bool flag = num2 > 1279f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("reloadTime", MEJMLNDFDBP.LJDADOKBBNA(num2 * 843f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 769f, 122f, 42);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 235f : 188f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		MNFGPKKKNPC();
		BKPNOABFMGN[1].LOJPGLBLJDF(6, 4, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && AGLCFPNLAHK.ACNHHOFIJMH[1].KGMNPLAJHNC().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].JGHOOHOEAFI(8, 3);
		}
		BKPNOABFMGN[0].MKENDIKJPLJ(4, 4, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.Warcard && AGLCFPNLAHK.ACNHHOFIJMH[0].EGMJNEABAHK().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].LGNKHADEELF(8, 3);
		}
		BKPNOABFMGN[4].GOMJAFCDKDD(3, 6, AGLCFPNLAHK.ACNHHOFIJMH[4]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[5].type == JGBBPCGNCPC.NNDPOJCACLP.Weapon && AGLCFPNLAHK.ACNHHOFIJMH[1].MHNPKJJLJFE().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[6].LGNKHADEELF(6, 8);
		}
		BKPNOABFMGN[4].GOMJAFCDKDD(5, 4, AGLCFPNLAHK.ACNHHOFIJMH[6]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.Warcard && AGLCFPNLAHK.ACNHHOFIJMH[0].EGMJNEABAHK().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[8].BBOHMOOOIHB(8, 5);
		}
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD((NGNPIOOAHEH)8).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.None).Value2;
		KLHNOLOADHM(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Silver);
		MDBBCMNJCIM(gOFBOKHBKEL);
	}

	public void EFEFPOIMMPB()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		DLNFBJHHGBK();
		JLKOCHHMAEC.text = Localization.Localize(" from waitlist");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1446f, 5f, 47);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1881f + 450f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG != 0;
		ALKEGOAOICB.SetActive(active);
		FMDKBDAFFAK();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(AJFNPCJKEMK));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(BCLEJGOCMEJ));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.ThreeCards);
		bool flag = num2 > 1335f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("CONFIRM", MEJMLNDFDBP.LJDADOKBBNA(num2 * 1407f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 288f, 1827f, 173);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 866f : 111f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		MNFGPKKKNPC();
		BKPNOABFMGN[0].GOMJAFCDKDD(8, 6, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].Initialize(0, 0, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[4].LOJPGLBLJDF(0, 0, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		BKPNOABFMGN[6].GOMJAFCDKDD(8, 2, AGLCFPNLAHK.ACNHHOFIJMH[6]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Silver).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK(NGNPIOOAHEH.Bronze).Value2;
		EPOLIBFPFAN(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Money);
		DHHHNBBBJAF(gOFBOKHBKEL);
	}

	private void IBDDHJEMHNL(bool GOFBOKHBKEL)
	{
		OPNMHDEFKLG.SetActive(GOFBOKHBKEL);
		NJEAMAHEMHP.enabled = !GOFBOKHBKEL;
		if (GOFBOKHBKEL)
		{
			TweenAlpha.Begin(OPNMHDEFKLG, 1438f, 1812f);
		}
	}

	public void NHKECIMCHGA()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		BMJCGKDGELF();
		JLKOCHHMAEC.text = Localization.Localize("AdminName");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1421f, 398f, 41);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1659f + 1134f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		JHCNFDAHHPB();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(IJBAPAOMAJE));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(BJEHOKOCBJP));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.ThreeCards);
		bool flag = num2 > 1440f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_RANDOMWARCARDS", MEJMLNDFDBP.LJDADOKBBNA(num2 * 973f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 17f, 8f, 182);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 872f : 1869f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		BKPNOABFMGN[0].LOJPGLBLJDF(5, 0, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].GOMJAFCDKDD(4, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[7].LOJPGLBLJDF(5, 2, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		BKPNOABFMGN[1].LOJPGLBLJDF(1, 1, AGLCFPNLAHK.ACNHHOFIJMH[6]);
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.ThreeCards).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(NGNPIOOAHEH.Starter).Value2;
		KLHNOLOADHM(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	public void AnimatePanels(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		float num = ((!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f);
		float num2 = ((!NABOFKMBMKH) ? 0f : 1f);
		if (NICJILKEIEG != null)
		{
			for (int i = 0; i < NICJILKEIEG.Length; i++)
			{
				if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
				{
					TweenAlpha.Begin(NICJILKEIEG[i].gameObject, num, num2);
				}
			}
		}
		for (int j = 0; j < BKPNOABFMGN.Length; j++)
		{
			BKPNOABFMGN[j].OverrideTweenPanels(num, num2);
		}
	}

	public void PGJPFLJLMBP(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		float num = ((!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 907f) : 1002f);
		float num2 = ((!NABOFKMBMKH) ? 1488f : 1253f);
		if (NICJILKEIEG != null)
		{
			for (int i = 0; i < NICJILKEIEG.Length; i++)
			{
				if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
				{
					TweenAlpha.Begin(NICJILKEIEG[i].gameObject, num, num2);
				}
			}
		}
		for (int j = 0; j < BKPNOABFMGN.Length; j++)
		{
			BKPNOABFMGN[j].KOEGKLCPOKO(num, num2);
		}
	}

	public void DHOEKLPIJIA()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.MDKPOBMKOLM();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("YES");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 340f, 761f, 14);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 737f + 948f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG != 1;
		ALKEGOAOICB.SetActive(active);
		BLLLNLLKPCG();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(BLLLNLLKPCG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(BLLLNLLKPCG));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Value);
		bool flag = num2 > 1456f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("withContentId", MEJMLNDFDBP.LJDADOKBBNA(num2 * 796f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1352f, 1571f, 96);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1882f : 244f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		DFGHNPBODPL();
		BKPNOABFMGN[0].Initialize(0, 7, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[1].LOJPGLBLJDF(7, 1, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[4].GOMJAFCDKDD(1, 7, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.None).Value2;
		string value2 = Singleton<GameVariables>.instance.MAMBIEIKLJB(NGNPIOOAHEH.Silver).Value2;
		EPOLIBFPFAN(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Gold);
		MDBBCMNJCIM(gOFBOKHBKEL);
	}

	private void GKPDMFIIPCP()
	{
		if (CGAKMJBHKKG > 0)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			LKFBPMLPKBN.text = string.Format("DailyRewardMonthScreen: init gui vlaues called", Localization.Localize("button"), MEJMLNDFDBP.CJCFPDLDMEK(num, "menu-hub-multiplayer-vipico", string.Empty, false));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1722f, 1136f, -141);
		}
	}

	private void DHFGAMJGGOL(bool GOFBOKHBKEL)
	{
		OPNMHDEFKLG.SetActive(GOFBOKHBKEL);
		NJEAMAHEMHP.enabled = GOFBOKHBKEL;
		if (GOFBOKHBKEL)
		{
			TweenAlpha.Begin(OPNMHDEFKLG, 170f, 1723f);
		}
	}

	private void OCJDPBAFBAL(bool GOFBOKHBKEL)
	{
		OPNMHDEFKLG.SetActive(GOFBOKHBKEL);
		NJEAMAHEMHP.enabled = !GOFBOKHBKEL;
		if (GOFBOKHBKEL)
		{
			TweenAlpha.Begin(OPNMHDEFKLG, 0f, 1f);
		}
	}

	public void IDLEHILGLLK()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(true);
		ELBMEOOIMJP();
		JLKOCHHMAEC.text = Localization.Localize("com/google/android/gms/common/api/Status");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 192f, 1621f, 64);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 385f + 1501f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG != 0;
		ALKEGOAOICB.SetActive(active);
		CIIFGDEINAH();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(BCLEJGOCMEJ));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(CIIFGDEINAH));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Money);
		bool flag = num2 > 1781f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 755f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("{", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 672f, 606f, 134);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1816f : 431f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		GHJPIHHKELH();
		BKPNOABFMGN[0].MKENDIKJPLJ(3, 0, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].Initialize(0, 3, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[8].MKENDIKJPLJ(5, 6, AGLCFPNLAHK.ACNHHOFIJMH[5]);
		BKPNOABFMGN[0].Initialize(6, 2, AGLCFPNLAHK.ACNHHOFIJMH[5]);
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Starter).Value2;
		string value2 = Singleton<GameVariables>.instance.MAMBIEIKLJB(NGNPIOOAHEH.None).Value2;
		FDBHNHIFHCA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Money);
		IBDDHJEMHNL(gOFBOKHBKEL);
	}

	public void PNPCKEOPFCP()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		DLNFBJHHGBK();
		JLKOCHHMAEC.text = Localization.Localize("ID_5SKIRMISHES");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1121f, 494f, -50);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 186f + 1684f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		JHCNFDAHHPB();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(NBBMMOKCEHF));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(PNJCMGODGGJ));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF((NGNPIOOAHEH)8);
		bool flag = num2 > 362f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 269f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("Region", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 379f, 1917f, -67);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 279f : 215f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		BKPNOABFMGN[1].LOJPGLBLJDF(3, 6, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[0].GOMJAFCDKDD(7, 3, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[6].MKENDIKJPLJ(2, 3, AGLCFPNLAHK.ACNHHOFIJMH[8]);
		BKPNOABFMGN[8].Initialize(2, 5, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Value).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK((NGNPIOOAHEH)8).Value2;
		EPOLIBFPFAN(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Silver);
		MDBBCMNJCIM(gOFBOKHBKEL);
	}

	public void IJBFJFOBFFI()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.moneyPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("setPackageName");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 830f, 181f, -21);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1130f + 61f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		AJFNPCJKEMK();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(KBAFBNNNDCD));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(BLLLNLLKPCG));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Money);
		bool flag = num2 > 1665f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("Test Power Hooks", MEJMLNDFDBP.LJDADOKBBNA(num2 * 170f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 906f, 712f, 83);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 172f : 1095f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		MPPDJIMDAFG();
		BKPNOABFMGN[0].LOJPGLBLJDF(1, 2, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].MKENDIKJPLJ(7, 4, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[2].Initialize(0, 1, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.None).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.Bronze).Value2;
		EPOLIBFPFAN(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought((NGNPIOOAHEH)8);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	public void DCDODCDBPMF()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.INIDGJIMCDM();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("N");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 381f, 80f, 162);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1716f + 1227f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG == 0;
		ALKEGOAOICB.SetActive(active);
		GPBLCAKICMG();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(GPBLCAKICMG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(CIIFGDEINAH));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.ThreeCards);
		bool flag = num2 > 633f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 713f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("Show VIP Expired at ", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 734f, 170f, -90);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1128f : 98f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		GEDFJKPEDMK();
		BKPNOABFMGN[0].MKENDIKJPLJ(1, 0, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].MKENDIKJPLJ(7, 4, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[2].Initialize(8, 3, AGLCFPNLAHK.ACNHHOFIJMH[6]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Starter).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.Silver).Value2;
		FDBHNHIFHCA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter);
		ABMFGDIKDOL(gOFBOKHBKEL);
	}

	public void Initialize(JGBBPCGNCPC JCBCHFJPPNK)
	{
		if (!IMAMPLAILIM())
		{
			Debug.LogError("Missing references in Special Pack Record: " + base.gameObject.name);
			return;
		}
		AGLCFPNLAHK = JCBCHFJPPNK;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = JCBCHFJPPNK.MHPNDNJDPGE;
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 62f, 31f, 450);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 2f + 34f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = JCBCHFJPPNK.MGJIPPFKDOE;
		bool active = CGAKMJBHKKG != 0;
		ALKEGOAOICB.SetActive(active);
		PNJCMGODGGJ();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(PNJCMGODGGJ));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(PNJCMGODGGJ));
		bool flag = JCBCHFJPPNK.GAFOMGDLAFD > 0f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_SALEPERCENT", MEJMLNDFDBP.LJDADOKBBNA(JCBCHFJPPNK.GAFOMGDLAFD * 100f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 52f, 26f, 290);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 0f : (-40f), OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		int num2 = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num2 < 2)
		{
			if (num2 == 1)
			{
				BKPNOABFMGN[0].Initialize(1, 2, JCBCHFJPPNK.ACNHHOFIJMH[0]);
			}
		}
		else
		{
			for (int i = 1; i <= num2 && i <= 6; i++)
			{
				JGBBPCGNCPC.Content kDNGNGHFMMG = JCBCHFJPPNK.ACNHHOFIJMH[i - 1];
				BKPNOABFMGN[i - 1].Initialize(i, num2, kDNGNGHFMMG);
			}
		}
		HIIBNFGNDJP(flag, JCBCHFJPPNK.GOBNFILDHBH, JCBCHFJPPNK.PDIGJLGNAGE);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.IsPackBought(JCBCHFJPPNK.KJBPJOMHNKB);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	public void GLNPAKEHCNM()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.MDKPOBMKOLM();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("RecieveOponentScore");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 522f, 259f, 38);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1574f + 1100f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		JHCNFDAHHPB();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(GPBLCAKICMG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(BLLLNLLKPCG));
		float num2 = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.ThreeCards);
		bool flag = num2 > 262f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1607f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("Time", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 167f, 1080f, 44);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 123f : 1496f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		MPPDJIMDAFG();
		BKPNOABFMGN[1].GOMJAFCDKDD(1, 4, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[1].GOMJAFCDKDD(4, 4, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[2].MKENDIKJPLJ(5, 3, AGLCFPNLAHK.ACNHHOFIJMH[8]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Gold).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(NGNPIOOAHEH.ThreeCards).Value2;
		FDBHNHIFHCA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Gold);
		DHHHNBBBJAF(gOFBOKHBKEL);
	}

	private void FDBHNHIFHCA(bool CNDOHJNJLDA, string KLAJOEOPIKD, string JJLIHIBBFEK)
	{
		EAMAGHAJKEH.text = KLAJOEOPIKD;
		MEJMLNDFDBP.COCBCFKJOJE(EAMAGHAJKEH, 1669f, 1175f, -58);
		FNNEOBKIPCD.transform.localPosition = FNNEOBKIPCD.transform.localPosition.ReplaceY(EAMAGHAJKEH.transform.localPosition.y);
		FNNEOBKIPCD.transform.localScale = EAMAGHAJKEH.transform.localScale;
		FNNEOBKIPCD.text = ((!CNDOHJNJLDA) ? string.Empty : JJLIHIBBFEK);
		ALOPNKAAKJA.gameObject.SetActive(CNDOHJNJLDA);
		if (CNDOHJNJLDA)
		{
			ALOPNKAAKJA.SetUpStrikeThrought();
		}
	}

	private bool EGCOLDEDJIC()
	{
		return BKPNOABFMGN.Length >= 1;
	}

	private void JLGMPCMADJN()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 0; i < bKPNOABFMGN.Length; i += 0)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(false);
		}
	}

	private void MNFGPKKKNPC()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 1; i < bKPNOABFMGN.Length; i += 0)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(false);
		}
	}

	public virtual void NBOMCFHBLOF()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(AIFFLMKJGND));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		for (int i = 0; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].HCGAEFBLGOF();
		}
		OPPAADCPKCL();
		base.DestroyPooled();
	}

	public void CHOLKMFKINL(JGBBPCGNCPC JCBCHFJPPNK)
	{
		if (!EGCOLDEDJIC())
		{
			Debug.LogError("SquadIcons/" + base.gameObject.name);
			return;
		}
		AGLCFPNLAHK = JCBCHFJPPNK;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = JCBCHFJPPNK.FKJLIPIHJIG();
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 343f, 821f, 36);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1924f + 471f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = JCBCHFJPPNK.MGJIPPFKDOE;
		bool active = CGAKMJBHKKG == 0;
		ALKEGOAOICB.SetActive(active);
		CIIFGDEINAH();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(BCLEJGOCMEJ));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(AJCNPBHDNFE));
		bool flag = JCBCHFJPPNK.GAFOMGDLAFD > 770f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(JCBCHFJPPNK.GAFOMGDLAFD * 515f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("menu-arena-scrap-ico", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 193f, 1676f, 152);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 238f : 671f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		MPPDJIMDAFG();
		int num2 = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num2 < 5)
		{
			if (num2 == 1)
			{
				BKPNOABFMGN[1].LOJPGLBLJDF(0, 8, JCBCHFJPPNK.ACNHHOFIJMH[0]);
			}
		}
		else
		{
			for (int i = 1; i <= num2 && i <= 7; i += 0)
			{
				JGBBPCGNCPC.Content kDNGNGHFMMG = JCBCHFJPPNK.ACNHHOFIJMH[i - 0];
				BKPNOABFMGN[i - 1].GOMJAFCDKDD(i, num2, kDNGNGHFMMG);
			}
		}
		HIIBNFGNDJP(flag, JCBCHFJPPNK.BCPANJACJKN(), JCBCHFJPPNK.PJDMEKFCLMH());
		bool gOFBOKHBKEL = PlayerAnalytics.instance.IsPackBought(JCBCHFJPPNK.KJBPJOMHNKB);
		FCLBPDADIAI(gOFBOKHBKEL);
	}

	public void NAKAFGAFEPH(JGBBPCGNCPC JCBCHFJPPNK)
	{
		if (!FDNJODOKDCC())
		{
			Debug.LogError("Show reconnect dialog" + base.gameObject.name);
			return;
		}
		AGLCFPNLAHK = JCBCHFJPPNK;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = JCBCHFJPPNK.BEEEJFPIGCJ();
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1732f, 312f, 86);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1605f + 650f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = JCBCHFJPPNK.MGJIPPFKDOE;
		bool active = CGAKMJBHKKG != 1;
		ALKEGOAOICB.SetActive(active);
		AIFFLMKJGND();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(AJFNPCJKEMK));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(BJEHOKOCBJP));
		bool flag = JCBCHFJPPNK.GAFOMGDLAFD > 550f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(JCBCHFJPPNK.GAFOMGDLAFD * 1995f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("menu-squad-10", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 854f, 1213f, -32);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1607f : 1227f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		MPPDJIMDAFG();
		int num2 = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num2 < 6)
		{
			if (num2 == 1)
			{
				BKPNOABFMGN[1].MKENDIKJPLJ(0, 2, JCBCHFJPPNK.ACNHHOFIJMH[1]);
			}
		}
		else
		{
			for (int i = 0; i <= num2 && i <= 0; i++)
			{
				JGBBPCGNCPC.Content kDNGNGHFMMG = JCBCHFJPPNK.ACNHHOFIJMH[i - 1];
				BKPNOABFMGN[i - 0].LOJPGLBLJDF(i, num2, kDNGNGHFMMG);
			}
		}
		NMPDHELPIJD(flag, JCBCHFJPPNK.GOBNFILDHBH, JCBCHFJPPNK.KBODEOLOEOE());
		bool gOFBOKHBKEL = PlayerAnalytics.instance.IsPackBought(JCBCHFJPPNK.KJBPJOMHNKB);
		KMGILKJEFBF(gOFBOKHBKEL);
	}

	public virtual void DCEPKMPCPJN()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(AJFNPCJKEMK));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		for (int i = 0; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].HCGAEFBLGOF();
		}
		ILAJFCMHHGN();
		base.DestroyPooled();
	}

	private void JHCNFDAHHPB()
	{
		if (CGAKMJBHKKG > 1)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			LKFBPMLPKBN.text = string.Format("1", Localization.Localize("menu-event-gift"), MEJMLNDFDBP.CJCFPDLDMEK(num, "Title", string.Empty, false));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 596f, 1910f, -45);
		}
	}

	private void BJEHOKOCBJP()
	{
		if (CGAKMJBHKKG > 1)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			LKFBPMLPKBN.text = string.Format("com/google/android/gms/games/Games", Localization.Localize("Decline Squad Join Request = "), MEJMLNDFDBP.CJCFPDLDMEK(num, "Play_Card_Tutorial", string.Empty, false));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1133f, 691f, 41);
		}
	}

	private bool GDBHOEDFCFD()
	{
		return BKPNOABFMGN.Length >= 3;
	}

	public void IBGLPMHIKEB()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.BJDKLOCBNOJ();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = Localization.Localize("Rank");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 9f, 1417f, -8);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 155f + 185f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 0;
		ALKEGOAOICB.SetActive(true);
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Gold);
		bool flag = num2 > 543f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1776f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("Weapon_Upgrade", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1340f, 480f, -15);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1792f : 844f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		GHJPIHHKELH();
		BKPNOABFMGN[1].MKENDIKJPLJ(4, 3, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Warcard && AGLCFPNLAHK.ACNHHOFIJMH[0].EDLDCCEOCNI().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].AlterShownCustomization(7, 0);
		}
		BKPNOABFMGN[0].GOMJAFCDKDD(0, 1, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.Unit && AGLCFPNLAHK.ACNHHOFIJMH[1].HFIPANJHCGJ().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].GAAEJFJGDFI(6, 1);
		}
		BKPNOABFMGN[7].LOJPGLBLJDF(8, 0, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[4].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && AGLCFPNLAHK.ACNHHOFIJMH[4].EGMJNEABAHK().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[5].MICPFLBKGDH(0, 6);
		}
		BKPNOABFMGN[0].LOJPGLBLJDF(4, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[4].type == JGBBPCGNCPC.NNDPOJCACLP.Cardpack && AGLCFPNLAHK.ACNHHOFIJMH[1].MHNPKJJLJFE().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].JGHOOHOEAFI(4, 5);
		}
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Value).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(NGNPIOOAHEH.ThreeCards).Value2;
		NMPDHELPIJD(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	public void InitializeMoneyPack()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.moneyPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = Localization.Localize("ID_MONEYPACK");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 62f, 31f, 450);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 2f + 34f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG != 0;
		ALKEGOAOICB.SetActive(active);
		PNJCMGODGGJ();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(PNJCMGODGGJ));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(PNJCMGODGGJ));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Money);
		bool flag = num2 > 0f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_SALEPERCENT", MEJMLNDFDBP.LJDADOKBBNA(num2 * 100f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 52f, 26f, 290);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 0f : (-40f), OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		BKPNOABFMGN[0].Initialize(1, 3, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].Initialize(2, 3, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[2].Initialize(3, 3, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Money).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(NGNPIOOAHEH.Money).Value2;
		HIIBNFGNDJP(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Money);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	private bool FDNJODOKDCC()
	{
		return BKPNOABFMGN.Length < 1;
	}

	private void MDBBCMNJCIM(bool GOFBOKHBKEL)
	{
		OPNMHDEFKLG.SetActive(GOFBOKHBKEL);
		NJEAMAHEMHP.enabled = !GOFBOKHBKEL;
		if (GOFBOKHBKEL)
		{
			TweenAlpha.Begin(OPNMHDEFKLG, 706f, 952f);
		}
	}

	public void InitializeValuePack()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.valuePack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("ID_VALUEPACK");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 62f, 31f, 450);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 2f + 34f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 0;
		ALKEGOAOICB.SetActive(false);
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Value);
		bool flag = num2 > 0f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_SALEPERCENT", MEJMLNDFDBP.LJDADOKBBNA(num2 * 100f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 52f, 26f, 290);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 0f : (-40f), OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		BKPNOABFMGN[0].Initialize(2, 5, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && AGLCFPNLAHK.ACNHHOFIJMH[0].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].AlterShownCustomization(2, 5);
		}
		BKPNOABFMGN[1].Initialize(3, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && AGLCFPNLAHK.ACNHHOFIJMH[1].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].AlterShownCustomization(3, 5);
		}
		BKPNOABFMGN[2].Initialize(4, 5, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[2].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && AGLCFPNLAHK.ACNHHOFIJMH[2].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[2].AlterShownCustomization(4, 5);
		}
		BKPNOABFMGN[3].Initialize(5, 5, AGLCFPNLAHK.ACNHHOFIJMH[3]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[3].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && AGLCFPNLAHK.ACNHHOFIJMH[3].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[3].AlterShownCustomization(5, 5);
		}
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Value).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(NGNPIOOAHEH.Value).Value2;
		HIIBNFGNDJP(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	public void HIICPOCFBIK()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(false);
		OKFCMJGKHCF();
		JLKOCHHMAEC.text = Localization.Localize("percent");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1139f, 1983f, 12);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 555f + 384f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG != 0;
		ALKEGOAOICB.SetActive(active);
		KBAFBNNNDCD();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(CIIFGDEINAH));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(NMPBIOHOKCO));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Gold);
		bool flag = num2 > 1126f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1377f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("resizing texture ", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 227f, 468f, 40);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 859f : 163f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		JLGMPCMADJN();
		BKPNOABFMGN[1].MKENDIKJPLJ(5, 7, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].MKENDIKJPLJ(2, 5, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[5].GOMJAFCDKDD(8, 6, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		BKPNOABFMGN[0].Initialize(6, 0, AGLCFPNLAHK.ACNHHOFIJMH[4]);
		string value = Singleton<GameVariables>.instance.PriceOfPack((NGNPIOOAHEH)8).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.Starter).Value2;
		ANLDEGOJABA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
		KMGILKJEFBF(gOFBOKHBKEL);
	}

	private bool NFMIKOJNPFI()
	{
		return BKPNOABFMGN.Length >= 8;
	}

	public void BBOGPHMMJIB()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.INIDGJIMCDM();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = Localization.Localize("Warbucks");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 417f, 902f, 131);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1584f + 1932f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG != 1;
		ALKEGOAOICB.SetActive(active);
		PNJCMGODGGJ();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(NBBMMOKCEHF));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(AJFNPCJKEMK));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Bronze);
		bool flag = num2 > 1545f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1366f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("Unit {0} is not being delivered/upgrade/trained!!!", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1116f, 1882f, -78);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 180f : 395f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		OCIKHOFIDAE();
		BKPNOABFMGN[1].MKENDIKJPLJ(0, 1, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].LOJPGLBLJDF(7, 4, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[4].MKENDIKJPLJ(1, 7, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Gold).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK((NGNPIOOAHEH)8).Value2;
		HIIBNFGNDJP(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Bronze);
		MDBBCMNJCIM(gOFBOKHBKEL);
	}

	public virtual void GKGMBOKJEIP()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(NMPBIOHOKCO));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		for (int i = 0; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].ClearWeaponIcon();
		}
		OPPAADCPKCL();
		base.DestroyPooled();
	}

	public void LEAPPMGMACB()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.moneyPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("ID_CONFIRM_SERVERERROR_TEXT");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1290f, 831f, -10);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1517f + 1115f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		NMPBIOHOKCO();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(IJBAPAOMAJE));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(GKPDMFIIPCP));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Starter);
		bool flag = num2 > 1481f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1626f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("WarsEvaluation", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 121f, 1519f, 158);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1705f : 187f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		GEDFJKPEDMK();
		BKPNOABFMGN[1].LOJPGLBLJDF(1, 8, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].Initialize(1, 8, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].GOMJAFCDKDD(8, 7, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Value).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.Gold).Value2;
		FDBHNHIFHCA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	private void OCIKHOFIDAE()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 1; i < bKPNOABFMGN.Length; i++)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(true);
		}
	}

	public void ELDFGINPJBL()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.KLMNEOAKMFB();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("ID_RENTAL_ASSAULTRIFLE");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 271f, 371f, -38);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1373f + 301f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 1;
		ALKEGOAOICB.SetActive(true);
		float num2 = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.ThreeCards);
		bool flag = num2 > 1191f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 837f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("ID_DAY", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1353f, 900f, 130);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 492f : 1335f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		DFGHNPBODPL();
		BKPNOABFMGN[0].Initialize(7, 0, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Weapon && AGLCFPNLAHK.ACNHHOFIJMH[1].MHNPKJJLJFE().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].AlterShownCustomization(4, 5);
		}
		BKPNOABFMGN[1].MKENDIKJPLJ(4, 2, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Warcard && AGLCFPNLAHK.ACNHHOFIJMH[1].KGMNPLAJHNC().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].AlterShownCustomization(8, 7);
		}
		BKPNOABFMGN[7].LOJPGLBLJDF(0, 0, AGLCFPNLAHK.ACNHHOFIJMH[5]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[5].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && AGLCFPNLAHK.ACNHHOFIJMH[8].POMMLFHPFPI().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[3].BBOHMOOOIHB(5, 3);
		}
		BKPNOABFMGN[7].MKENDIKJPLJ(7, 1, AGLCFPNLAHK.ACNHHOFIJMH[5]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[3].type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks && AGLCFPNLAHK.ACNHHOFIJMH[3].CBOHPLABHNO().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[8].GAAEJFJGDFI(4, 0);
		}
		string value = Singleton<GameVariables>.instance.PriceOfPack((NGNPIOOAHEH)8).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK(NGNPIOOAHEH.Starter).Value2;
		HIIBNFGNDJP(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	public virtual void DMLEIPJPGOD()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(BCLEJGOCMEJ));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		for (int i = 1; i < BKPNOABFMGN.Length; i++)
		{
			BKPNOABFMGN[i].HCGAEFBLGOF();
		}
		IIFICGJMHGO();
		base.DestroyPooled();
	}

	private void IDHHLOMBNJD()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		foreach (SpecialPackBoxItem specialPackBoxItem in bKPNOABFMGN)
		{
			specialPackBoxItem.gameObject.SetActive(false);
		}
	}

	public void EEIPAKOMGKK()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		BMJCGKDGELF();
		JLKOCHHMAEC.text = Localization.Localize("GrenadeMinDamage");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 621f, 514f, -22);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1857f + 1452f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		BLLLNLLKPCG();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(FMDKBDAFFAK));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(NBBMMOKCEHF));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.None);
		bool flag = num2 > 337f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("{0}/{1}/", MEJMLNDFDBP.LJDADOKBBNA(num2 * 1862f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1110f, 57f, 123);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 131f : 507f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		AJCFDHABHBD();
		BKPNOABFMGN[1].MKENDIKJPLJ(8, 5, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[0].Initialize(1, 7, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[2].LOJPGLBLJDF(7, 6, AGLCFPNLAHK.ACNHHOFIJMH[7]);
		BKPNOABFMGN[0].GOMJAFCDKDD(3, 2, AGLCFPNLAHK.ACNHHOFIJMH[4]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.ThreeCards).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.Silver).Value2;
		KLHNOLOADHM(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
		KMGILKJEFBF(gOFBOKHBKEL);
	}

	public void ELFIIKOCADC()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		OKFCMJGKHCF();
		JLKOCHHMAEC.text = Localization.Localize("FuseSDK: Parsing error in _AccountLoginComplete");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1330f, 158f, 32);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 494f + 847f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG != 1;
		ALKEGOAOICB.SetActive(active);
		AJCNPBHDNFE();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(PNJCMGODGGJ));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(AJCNPBHDNFE));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Bronze);
		bool flag = num2 > 868f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 340f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("sniperrifle", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1877f, 232f, -8);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 114f : 1562f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		GHJPIHHKELH();
		BKPNOABFMGN[0].GOMJAFCDKDD(2, 3, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[1].LOJPGLBLJDF(1, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[3].Initialize(0, 2, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		BKPNOABFMGN[2].Initialize(5, 5, AGLCFPNLAHK.ACNHHOFIJMH[7]);
		string value = Singleton<GameVariables>.instance.PriceOfPack((NGNPIOOAHEH)8).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK(NGNPIOOAHEH.Money).Value2;
		EPOLIBFPFAN(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value);
		MDBBCMNJCIM(gOFBOKHBKEL);
	}

	private void CIIFGDEINAH()
	{
		if (CGAKMJBHKKG > 0)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			LKFBPMLPKBN.text = string.Format("fire", Localization.Localize("Battle"), MEJMLNDFDBP.CJCFPDLDMEK(num, "subscribed", string.Empty));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1871f, 1425f, -14);
		}
	}

	private void AJCNPBHDNFE()
	{
		if (CGAKMJBHKKG > 0)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			LKFBPMLPKBN.text = string.Format("IDFV", Localization.Localize("Play_Card_Tutorial"), MEJMLNDFDBP.CJCFPDLDMEK(num, "InstantBattleEnded: REWARD EXPERIENCE: ", string.Empty));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1730f, 1316f, 26);
		}
	}

	private void OKFCMJGKHCF()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HOBDKJCMHNN();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("ID_WARNING_CANTSENDINVITE_TEXT");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	private void KJCADHKJFPH(GameObject KHAHPAKDIKE)
	{
		if (!OPNMHDEFKLG.activeSelf)
		{
			Debug.Log("Clicked buy on " + AGLCFPNLAHK.KJBPJOMHNKB);
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<BeanstalkServerManager>.instance.BuyPack(AGLCFPNLAHK.KJBPJOMHNKB, "WarShop");
		}
	}

	public void ADJDCJBAPNL()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.moneyPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("ID_CONFIRM_LEAVE_SPECTATE_TEXT");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1825f, 1621f, -14);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1843f + 1660f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG != 0;
		ALKEGOAOICB.SetActive(active);
		PNJCMGODGGJ();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(BLLLNLLKPCG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(GKPDMFIIPCP));
		float num2 = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Starter);
		bool flag = num2 > 710f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("GameReward", MEJMLNDFDBP.LJDADOKBBNA(num2 * 1842f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 103f, 1050f, -68);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1759f : 1446f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		GHJPIHHKELH();
		BKPNOABFMGN[1].MKENDIKJPLJ(0, 7, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[1].Initialize(4, 4, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[4].LOJPGLBLJDF(2, 3, AGLCFPNLAHK.ACNHHOFIJMH[4]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.None).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK(NGNPIOOAHEH.ThreeCards).Value2;
		ANLDEGOJABA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.None);
		KMGILKJEFBF(gOFBOKHBKEL);
	}

	private void AIFFLMKJGND()
	{
		if (CGAKMJBHKKG > 1)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			LKFBPMLPKBN.text = string.Format("{0:D2}:{1:D2}", Localization.Localize("ID_INBRONZE2"), MEJMLNDFDBP.CJCFPDLDMEK(num, "102 GAME STARTED", string.Empty, false));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1997f, 1767f, 181);
		}
	}

	public void FBNJOHIEDDF()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.INIDGJIMCDM();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = Localization.Localize("ID_PARSING_CONFIGURATIONS");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1450f, 1069f, -175);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1329f + 965f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.moneyPackDeadline;
		bool active = CGAKMJBHKKG != 1;
		ALKEGOAOICB.SetActive(active);
		PNJCMGODGGJ();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(NBBMMOKCEHF));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(BCLEJGOCMEJ));
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.ThreeCards);
		bool flag = num2 > 1945f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 686f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("shotReal", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 88f, 1262f, 72);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 937f : 1736f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		BKPNOABFMGN[1].Initialize(1, 3, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].Initialize(8, 7, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[0].GOMJAFCDKDD(7, 5, AGLCFPNLAHK.ACNHHOFIJMH[7]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Starter).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK(NGNPIOOAHEH.Silver).Value2;
		HIIBNFGNDJP(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Value);
		KMGILKJEFBF(gOFBOKHBKEL);
	}

	public void OIPDKEDHHKO()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.KLMNEOAKMFB();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("Measure Session clicked");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 97f, 1060f, -48);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 939f + 1802f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 0;
		ALKEGOAOICB.SetActive(true);
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.ThreeCards);
		bool flag = num2 > 770f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("Description!!!!!!! Motherfuckers :-)", MEJMLNDFDBP.LJDADOKBBNA(num2 * 1544f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 725f, 173f, -130);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 733f : 1819f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		AJCFDHABHBD();
		BKPNOABFMGN[1].LOJPGLBLJDF(4, 3, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && AGLCFPNLAHK.ACNHHOFIJMH[1].BBIHDMBGALE().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].GAAEJFJGDFI(4, 1);
		}
		BKPNOABFMGN[1].LOJPGLBLJDF(6, 0, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand && AGLCFPNLAHK.ACNHHOFIJMH[1].NLNDHAMEEPJ().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].JGHOOHOEAFI(5, 5);
		}
		BKPNOABFMGN[1].LOJPGLBLJDF(0, 1, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[5].type == JGBBPCGNCPC.NNDPOJCACLP.Unit && AGLCFPNLAHK.ACNHHOFIJMH[4].AEAJMKLEMDO().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[3].PFMMDAMAOHC(5, 1);
		}
		BKPNOABFMGN[5].LOJPGLBLJDF(1, 2, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[7].type == JGBBPCGNCPC.NNDPOJCACLP.Gold && AGLCFPNLAHK.ACNHHOFIJMH[8].MHNPKJJLJFE().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[3].JGHOOHOEAFI(2, 6);
		}
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Value).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK(NGNPIOOAHEH.ThreeCards).Value2;
		FDBHNHIFHCA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
		MDBBCMNJCIM(gOFBOKHBKEL);
	}

	private void DFGHNPBODPL()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 1; i < bKPNOABFMGN.Length; i += 0)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(true);
		}
	}

	public void IIACKDPMICL()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.HFJGOIGLPCF();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("Game created on server+");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1590f, 1982f, -121);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 18f + 753f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 0;
		ALKEGOAOICB.SetActive(false);
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Value);
		bool flag = num2 > 806f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1126f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("ID_GUI_BEADVISED_CONNECTFB", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1787f, 1640f, 12);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 239f : 1925f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		AJCFDHABHBD();
		BKPNOABFMGN[0].Initialize(1, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && AGLCFPNLAHK.ACNHHOFIJMH[1].MHNPKJJLJFE().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].GAAEJFJGDFI(6, 3);
		}
		BKPNOABFMGN[0].MKENDIKJPLJ(0, 3, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand && AGLCFPNLAHK.ACNHHOFIJMH[1].CBOHPLABHNO().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].AlterShownCustomization(3, 8);
		}
		BKPNOABFMGN[6].LOJPGLBLJDF(0, 3, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[8].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && AGLCFPNLAHK.ACNHHOFIJMH[0].DGJMBIDMEOJ().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[7].MICPFLBKGDH(5, 8);
		}
		BKPNOABFMGN[8].LOJPGLBLJDF(2, 0, AGLCFPNLAHK.ACNHHOFIJMH[6]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.VIP && AGLCFPNLAHK.ACNHHOFIJMH[8].EDLDCCEOCNI().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[8].JGHOOHOEAFI(4, 4);
		}
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Gold).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(NGNPIOOAHEH.Bronze).Value2;
		KLHNOLOADHM(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.ThreeCards);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	public void FINGDHHJOAL(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		float num = ((!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1519f) : 233f);
		float num2 = ((!NABOFKMBMKH) ? 195f : 994f);
		if (NICJILKEIEG != null)
		{
			for (int i = 0; i < NICJILKEIEG.Length; i++)
			{
				if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
				{
					TweenAlpha.Begin(NICJILKEIEG[i].gameObject, num, num2);
				}
			}
		}
		for (int j = 1; j < BKPNOABFMGN.Length; j++)
		{
			BKPNOABFMGN[j].EOGMPGBBKAB(num, num2);
		}
	}

	public void PBPEFJHMJII()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.valuePack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("subscription");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1337f, 143f, 28);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 412f + 1651f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 1;
		ALKEGOAOICB.SetActive(false);
		float num2 = Singleton<GameVariables>.instance.FLFFIJIOMOJ(NGNPIOOAHEH.Money);
		bool flag = num2 > 1793f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 938f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("BattleId", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 971f, 955f, -185);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 836f : 1505f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		JLGMPCMADJN();
		BKPNOABFMGN[1].MKENDIKJPLJ(6, 0, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand && AGLCFPNLAHK.ACNHHOFIJMH[0].COEDNJOOPMP().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].PFMMDAMAOHC(3, 0);
		}
		BKPNOABFMGN[0].GOMJAFCDKDD(8, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand && AGLCFPNLAHK.ACNHHOFIJMH[0].DGJMBIDMEOJ().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].JGHOOHOEAFI(3, 1);
		}
		BKPNOABFMGN[1].Initialize(4, 0, AGLCFPNLAHK.ACNHHOFIJMH[2]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[4].type == JGBBPCGNCPC.NNDPOJCACLP.Weapon && AGLCFPNLAHK.ACNHHOFIJMH[3].DGJMBIDMEOJ().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[3].AlterShownCustomization(5, 7);
		}
		BKPNOABFMGN[0].LOJPGLBLJDF(3, 4, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[3].type == JGBBPCGNCPC.NNDPOJCACLP.Weapon && AGLCFPNLAHK.ACNHHOFIJMH[8].visual.owner.categoryNumber != 0)
		{
			BKPNOABFMGN[7].PFMMDAMAOHC(7, 8);
		}
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Bronze).Value2;
		string value2 = Singleton<GameVariables>.instance.RegularPriceOfPack(NGNPIOOAHEH.Silver).Value2;
		FDBHNHIFHCA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter);
		ABMFGDIKDOL(gOFBOKHBKEL);
	}

	private void NMPBIOHOKCO()
	{
		if (CGAKMJBHKKG > 0)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
			LKFBPMLPKBN.text = string.Format("FuseSDK: Parsing error in _AccountLoginError", Localization.Localize("LandedNetwork"), MEJMLNDFDBP.CJCFPDLDMEK(num, "Joined room", string.Empty));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1915f, 1695f, 73);
		}
	}

	private void FGONLMHHEED()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = false;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("dailyRewardData");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	private void DHHHNBBBJAF(bool GOFBOKHBKEL)
	{
		OPNMHDEFKLG.SetActive(GOFBOKHBKEL);
		NJEAMAHEMHP.enabled = GOFBOKHBKEL;
		if (GOFBOKHBKEL)
		{
			TweenAlpha.Begin(OPNMHDEFKLG, 199f, 1578f);
		}
	}

	private bool LGPBFPHMBMJ()
	{
		return BKPNOABFMGN.Length >= 6;
	}

	public void CMOHGKPENIJ(JGBBPCGNCPC JCBCHFJPPNK)
	{
		if (!POEOEHNAFHF())
		{
			Debug.LogError("30-40" + base.gameObject.name);
			return;
		}
		AGLCFPNLAHK = JCBCHFJPPNK;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		JLKOCHHMAEC.text = JCBCHFJPPNK.MHPNDNJDPGE;
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1454f, 844f, -49);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1866f + 1168f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = JCBCHFJPPNK.MGJIPPFKDOE;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		BJEHOKOCBJP();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(BLLLNLLKPCG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(FMDKBDAFFAK));
		bool flag = JCBCHFJPPNK.GAFOMGDLAFD > 740f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(JCBCHFJPPNK.GAFOMGDLAFD * 720f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("Amount", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 772f, 390f, -3);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 1153f : 1045f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		MNFGPKKKNPC();
		int num2 = JCBCHFJPPNK.ACNHHOFIJMH.Length;
		if (num2 < 8)
		{
			if (num2 == 0)
			{
				BKPNOABFMGN[1].Initialize(1, 7, JCBCHFJPPNK.ACNHHOFIJMH[0]);
			}
		}
		else
		{
			for (int i = 0; i <= num2 && i <= 5; i += 0)
			{
				JGBBPCGNCPC.Content kDNGNGHFMMG = JCBCHFJPPNK.ACNHHOFIJMH[i - 1];
				BKPNOABFMGN[i - 1].Initialize(i, num2, kDNGNGHFMMG);
			}
		}
		HIIBNFGNDJP(flag, JCBCHFJPPNK.AJALADJBENE(), JCBCHFJPPNK.OLONIBGNFLG());
		bool gOFBOKHBKEL = PlayerAnalytics.instance.IsPackBought(JCBCHFJPPNK.KJBPJOMHNKB);
		KMGILKJEFBF(gOFBOKHBKEL);
	}

	private bool MKNJJHEOCOE()
	{
		return BKPNOABFMGN.Length >= 7;
	}

	public void GGIHHCMFAJE()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.BJDKLOCBNOJ();
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(true);
		JLKOCHHMAEC.text = Localization.Localize("Buy_Units");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1126f, 669f, -120);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1483f + 1420f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = 0;
		ALKEGOAOICB.SetActive(false);
		float num2 = Singleton<GameVariables>.instance.SaleOfPack(NGNPIOOAHEH.Money);
		bool flag = num2 > 158f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 573f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("minigun_idle", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1501f, 412f, 112);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 294f : 740f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		BKPNOABFMGN[0].MKENDIKJPLJ(4, 1, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand && AGLCFPNLAHK.ACNHHOFIJMH[1].DGJMBIDMEOJ().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[0].GAAEJFJGDFI(7, 4);
		}
		BKPNOABFMGN[0].Initialize(4, 4, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[1].type == JGBBPCGNCPC.NNDPOJCACLP.Gold && AGLCFPNLAHK.ACNHHOFIJMH[0].NLNDHAMEEPJ().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[1].GAAEJFJGDFI(8, 2);
		}
		BKPNOABFMGN[6].MKENDIKJPLJ(1, 2, AGLCFPNLAHK.ACNHHOFIJMH[6]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[0].type == JGBBPCGNCPC.NNDPOJCACLP.Customization && AGLCFPNLAHK.ACNHHOFIJMH[4].ALMNJOLFIEF().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[7].JGHOOHOEAFI(7, 3);
		}
		BKPNOABFMGN[8].LOJPGLBLJDF(5, 5, AGLCFPNLAHK.ACNHHOFIJMH[6]);
		if (AGLCFPNLAHK.ACNHHOFIJMH[2].type == JGBBPCGNCPC.NNDPOJCACLP.Warcard && AGLCFPNLAHK.ACNHHOFIJMH[5].BBIHDMBGALE().owner.categoryNumber != 0)
		{
			BKPNOABFMGN[7].JGHOOHOEAFI(7, 0);
		}
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Gold).Value2;
		string value2 = Singleton<GameVariables>.instance.MAMBIEIKLJB(NGNPIOOAHEH.Money).Value2;
		ANLDEGOJABA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Silver);
		IBDDHJEMHNL(gOFBOKHBKEL);
	}

	public virtual void LLKBNDHBNAL()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(NMPBIOHOKCO));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		for (int i = 1; i < BKPNOABFMGN.Length; i++)
		{
			BKPNOABFMGN[i].HCGAEFBLGOF();
		}
		ILAJFCMHHGN();
		base.DestroyPooled();
	}

	public virtual void EJDOMPDOCKD()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(CIIFGDEINAH));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		for (int i = 0; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].EIJGHBHKOIP();
		}
		NBPCENIHMIA();
		base.DestroyPooled();
	}

	private void HIIBNFGNDJP(bool CNDOHJNJLDA, string KLAJOEOPIKD, string JJLIHIBBFEK)
	{
		EAMAGHAJKEH.text = KLAJOEOPIKD;
		MEJMLNDFDBP.COCBCFKJOJE(EAMAGHAJKEH, 42f, 22f, 230);
		FNNEOBKIPCD.transform.localPosition = FNNEOBKIPCD.transform.localPosition.ReplaceY(EAMAGHAJKEH.transform.localPosition.y);
		FNNEOBKIPCD.transform.localScale = EAMAGHAJKEH.transform.localScale;
		FNNEOBKIPCD.text = ((!CNDOHJNJLDA) ? string.Empty : JJLIHIBBFEK);
		ALOPNKAAKJA.gameObject.SetActive(CNDOHJNJLDA);
		if (CNDOHJNJLDA)
		{
			ALOPNKAAKJA.SetUpStrikeThrought();
		}
	}

	public override void DestroyPooled()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(PNJCMGODGGJ));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		for (int i = 0; i < BKPNOABFMGN.Length; i++)
		{
			BKPNOABFMGN[i].ClearWeaponIcon();
		}
		OPPAADCPKCL();
		base.DestroyPooled();
	}

	private void AJCFDHABHBD()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 1; i < bKPNOABFMGN.Length; i += 0)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(false);
		}
	}

	public void DFJADILANBF(bool PDPDGCNHCFN, bool NABOFKMBMKH)
	{
		float num = ((!PDPDGCNHCFN) ? (GuiElementSingle<InappScreen>.instance.HAMKIKMJHDP * 1513f) : 1792f);
		float num2 = ((!NABOFKMBMKH) ? 1923f : 1640f);
		if (NICJILKEIEG != null)
		{
			for (int i = 0; i < NICJILKEIEG.Length; i += 0)
			{
				if (!(NICJILKEIEG[i] == null) && NICJILKEIEG[i].gameObject.activeSelf)
				{
					TweenAlpha.Begin(NICJILKEIEG[i].gameObject, num, num2);
				}
			}
		}
		for (int j = 0; j < BKPNOABFMGN.Length; j += 0)
		{
			BKPNOABFMGN[j].OverrideTweenPanels(num, num2);
		}
	}

	private bool LGJMHOFPMDK()
	{
		return BKPNOABFMGN.Length < 8;
	}

	private void PKNOPGHHMMH(GameObject KHAHPAKDIKE)
	{
		if (!OPNMHDEFKLG.activeSelf)
		{
			Debug.Log("Action" + AGLCFPNLAHK.KJBPJOMHNKB);
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<BeanstalkServerManager>.instance.BuyPack(AGLCFPNLAHK.KJBPJOMHNKB, "Sniper");
		}
	}

	private void BJCHGKKLPAL()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFAKINMEEDJ();
			resourceLoaderTexture2D.FreeAsset("0");
			JFKIPIKKGNO = true;
		}
	}

	private void OAKANAOHCJB(GameObject KHAHPAKDIKE)
	{
		if (!OPNMHDEFKLG.activeSelf)
		{
			Debug.Log("{0} {1}" + AGLCFPNLAHK.KJBPJOMHNKB);
			SoundsManager.Instance.PlayButtonClickedSound();
			Singleton<BeanstalkServerManager>.instance.BuyPack(AGLCFPNLAHK.KJBPJOMHNKB, "ID_WARNING_ERRORCLAIMASSIGNMENT");
		}
	}

	private void GPBLCAKICMG()
	{
		if (CGAKMJBHKKG > 0)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			LKFBPMLPKBN.text = string.Format("FuseLogin(", Localization.Localize("menu-warbucks"), MEJMLNDFDBP.CJCFPDLDMEK(num, "shield_shot", string.Empty, false));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 1668f, 1524f, 183);
		}
	}

	private void ABMFGDIKDOL(bool GOFBOKHBKEL)
	{
		OPNMHDEFKLG.SetActive(GOFBOKHBKEL);
		NJEAMAHEMHP.enabled = !GOFBOKHBKEL;
		if (GOFBOKHBKEL)
		{
			TweenAlpha.Begin(OPNMHDEFKLG, 207f, 1170f);
		}
	}

	public virtual void KOMJDNDMJDF()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(GKPDMFIIPCP));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		for (int i = 0; i < BKPNOABFMGN.Length; i += 0)
		{
			BKPNOABFMGN[i].HCGAEFBLGOF();
		}
		NBPCENIHMIA();
		base.BOHCNEDIJPE();
	}

	private void AJFNPCJKEMK()
	{
		if (CGAKMJBHKKG > 0)
		{
			int num = CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF();
			LKFBPMLPKBN.text = string.Format("weapon doesnt have ammo setup", Localization.Localize("Rank_Up"), MEJMLNDFDBP.CJCFPDLDMEK(num, "Beanstalk: Get Friends Info, count = ", string.Empty));
			MEJMLNDFDBP.COCBCFKJOJE(LKFBPMLPKBN, 565f, 1371f, -3);
		}
	}

	public void MJFOJFPIICP()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PKNOPGHHMMH));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		MBJLOPKOKMB();
		JLKOCHHMAEC.text = Localization.Localize("TimeStamp");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1078f, 554f, -24);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1303f + 1156f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG != 0;
		ALKEGOAOICB.SetActive(active);
		CIIFGDEINAH();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(GPBLCAKICMG));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(NMPBIOHOKCO));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF((NGNPIOOAHEH)8);
		bool flag = num2 > 273f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("BatchSizeMax", MEJMLNDFDBP.LJDADOKBBNA(num2 * 1386f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1747f, 1439f, 130);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 865f : 1886f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		IDHHLOMBNJD();
		BKPNOABFMGN[0].LOJPGLBLJDF(0, 5, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].Initialize(7, 8, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[8].Initialize(7, 5, AGLCFPNLAHK.ACNHHOFIJMH[5]);
		BKPNOABFMGN[3].Initialize(2, 8, AGLCFPNLAHK.ACNHHOFIJMH[7]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.ThreeCards).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.ThreeCards).Value2;
		HIIBNFGNDJP(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Money);
		OCJDPBAFBAL(gOFBOKHBKEL);
	}

	private void ANLDEGOJABA(bool CNDOHJNJLDA, string KLAJOEOPIKD, string JJLIHIBBFEK)
	{
		EAMAGHAJKEH.text = KLAJOEOPIKD;
		MEJMLNDFDBP.COCBCFKJOJE(EAMAGHAJKEH, 1859f, 1021f, 100);
		FNNEOBKIPCD.transform.localPosition = FNNEOBKIPCD.transform.localPosition.ReplaceY(EAMAGHAJKEH.transform.localPosition.y);
		FNNEOBKIPCD.transform.localScale = EAMAGHAJKEH.transform.localScale;
		FNNEOBKIPCD.text = ((!CNDOHJNJLDA) ? string.Empty : JJLIHIBBFEK);
		ALOPNKAAKJA.gameObject.SetActive(CNDOHJNJLDA);
		if (CNDOHJNJLDA)
		{
			ALOPNKAAKJA.PGPKFKEIIJN();
		}
	}

	public void BCCLLAPDOHL()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPGBGPNMFJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		AMPFHINKAGC.SetActive(true);
		PMOALAAIKEP.SetActive(false);
		FGONLMHHEED();
		JLKOCHHMAEC.text = Localization.Localize("{0} {1}");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 296f, 1151f, 16);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 169f + 1917f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG != 1;
		ALKEGOAOICB.SetActive(active);
		BCLEJGOCMEJ();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(AJFNPCJKEMK));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(JHCNFDAHHPB));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF((NGNPIOOAHEH)8);
		bool flag = num2 > 666f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			UILabel eKIDAFLLCNM = EKIDAFLLCNM;
			object[] array = new object[1];
			array[1] = MEJMLNDFDBP.LJDADOKBBNA(num2 * 1031f);
			eKIDAFLLCNM.text = Localization.LocalizeFormat("\"NEGINFINITY\"", array);
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 699f, 1229f, -167);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 585f : 983f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		GHJPIHHKELH();
		BKPNOABFMGN[0].LOJPGLBLJDF(6, 7, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[1].LOJPGLBLJDF(5, 7, AGLCFPNLAHK.ACNHHOFIJMH[0]);
		BKPNOABFMGN[1].LOJPGLBLJDF(6, 1, AGLCFPNLAHK.ACNHHOFIJMH[5]);
		BKPNOABFMGN[7].LOJPGLBLJDF(5, 8, AGLCFPNLAHK.ACNHHOFIJMH[3]);
		string value = Singleton<GameVariables>.instance.PriceOfPack(NGNPIOOAHEH.Gold).Value2;
		string value2 = Singleton<GameVariables>.instance.POAMIAMCDPK(NGNPIOOAHEH.Bronze).Value2;
		NMPDHELPIJD(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Gold);
		MDBBCMNJCIM(gOFBOKHBKEL);
	}

	public virtual void GNPBMHCLKLO()
	{
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(CIIFGDEINAH));
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		for (int i = 0; i < BKPNOABFMGN.Length; i++)
		{
			BKPNOABFMGN[i].CNFKPKEBBFB();
		}
		NBPCENIHMIA();
		base.OBCAIFMOPPA();
	}

	private void KLHNOLOADHM(bool CNDOHJNJLDA, string KLAJOEOPIKD, string JJLIHIBBFEK)
	{
		EAMAGHAJKEH.text = KLAJOEOPIKD;
		MEJMLNDFDBP.COCBCFKJOJE(EAMAGHAJKEH, 790f, 357f, -1);
		FNNEOBKIPCD.transform.localPosition = FNNEOBKIPCD.transform.localPosition.ReplaceY(EAMAGHAJKEH.transform.localPosition.y);
		FNNEOBKIPCD.transform.localScale = EAMAGHAJKEH.transform.localScale;
		FNNEOBKIPCD.text = ((!CNDOHJNJLDA) ? string.Empty : JJLIHIBBFEK);
		ALOPNKAAKJA.gameObject.SetActive(CNDOHJNJLDA);
		if (CNDOHJNJLDA)
		{
			ALOPNKAAKJA.NAMAPIEHLMN();
		}
	}

	private void BMJCGKDGELF()
	{
		if (!JFKIPIKKGNO)
		{
			JFKIPIKKGNO = true;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GNNFDHCBNOF();
			Texture2D texture2D = resourceLoaderTexture2D.LoadAsset("ID_READYTIME");
			NGHCDIMLGMO.gameObject.SetActive(texture2D != null);
			if (texture2D != null)
			{
				NGHCDIMLGMO.mainTexture = texture2D;
			}
		}
	}

	public void MCELGEIPKBE()
	{
		AGLCFPNLAHK = Singleton<GameVariables>.instance.starterPack;
		UIEventListener uIEventListener = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OAKANAOHCJB));
		UIEventListener uIEventListener2 = UIEventListener.Get(NJEAMAHEMHP.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KJCADHKJFPH));
		AMPFHINKAGC.SetActive(false);
		PMOALAAIKEP.SetActive(false);
		DLNFBJHHGBK();
		JLKOCHHMAEC.text = Localization.Localize("WarbucksId");
		MEJMLNDFDBP.COCBCFKJOJE(JLKOCHHMAEC, 1125f, 668f, 20);
		float num = JLKOCHHMAEC.relativeSize.x * JLKOCHHMAEC.transform.localScale.x / 1520f + 213f;
		NEKGGEDFMAL.transform.localPosition = NEKGGEDFMAL.transform.localPosition.ReplaceX(0f - num);
		MJFJONFJEBD.transform.localPosition = MJFJONFJEBD.transform.localPosition.ReplaceX(num);
		CGAKMJBHKKG = PlayerAnalytics.instance.data.starterPackDeadline;
		bool active = CGAKMJBHKKG == 1;
		ALKEGOAOICB.SetActive(active);
		NBBMMOKCEHF();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.EGMLDACJFCF = (Action)Delegate.Remove(instance.EGMLDACJFCF, new Action(FMDKBDAFFAK));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.EGMLDACJFCF = (Action)Delegate.Combine(instance2.EGMLDACJFCF, new Action(BLLLNLLKPCG));
		float num2 = Singleton<GameVariables>.instance.HNFMEMHIOEF(NGNPIOOAHEH.Starter);
		bool flag = num2 > 648f;
		GIPFEBBMKPM.SetActive(flag);
		if (flag)
		{
			EKIDAFLLCNM.text = Localization.LocalizeFormat("ID_TUTORIAL_UPGRADEUNIT_8", MEJMLNDFDBP.LJDADOKBBNA(num2 * 779f));
			MEJMLNDFDBP.COCBCFKJOJE(EKIDAFLLCNM, 1256f, 1480f, -91);
		}
		OOIBADLGKML.transform.localPosition = new Vector3((!flag) ? 629f : 586f, OOIBADLGKML.transform.localPosition.y, OOIBADLGKML.transform.localPosition.z);
		JLGMPCMADJN();
		BKPNOABFMGN[1].LOJPGLBLJDF(8, 3, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[0].LOJPGLBLJDF(0, 7, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		BKPNOABFMGN[6].GOMJAFCDKDD(3, 4, AGLCFPNLAHK.ACNHHOFIJMH[6]);
		BKPNOABFMGN[4].LOJPGLBLJDF(0, 5, AGLCFPNLAHK.ACNHHOFIJMH[1]);
		string value = Singleton<GameVariables>.instance.JNNJBGHJBFD(NGNPIOOAHEH.Starter).Value2;
		string value2 = Singleton<GameVariables>.instance.HFBPGHCNAGK(NGNPIOOAHEH.Money).Value2;
		ANLDEGOJABA(flag, value, value2);
		bool gOFBOKHBKEL = PlayerAnalytics.instance.data.IsPackBought(NGNPIOOAHEH.Starter);
		DHHHNBBBJAF(gOFBOKHBKEL);
	}

	private void ILAJFCMHHGN()
	{
		if (JFKIPIKKGNO)
		{
			NGHCDIMLGMO.mainTexture = null;
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HJDGKLBOOHI();
			resourceLoaderTexture2D.FreeAsset("PlayerName");
			JFKIPIKKGNO = false;
		}
	}

	private void CJHCGLHHEFJ()
	{
		SpecialPackBoxItem[] bKPNOABFMGN = BKPNOABFMGN;
		for (int i = 1; i < bKPNOABFMGN.Length; i += 0)
		{
			SpecialPackBoxItem specialPackBoxItem = bKPNOABFMGN[i];
			specialPackBoxItem.gameObject.SetActive(false);
		}
	}
}
