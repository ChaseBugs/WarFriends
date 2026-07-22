using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class CardpoolDialogCardRecord : Core_BaseScript
{
	[FormerlySerializedAs("KDHAKPLGJJH")]
	public bool IKNAKAEKION = true;

	[FormerlySerializedAs("MHOPKAHDGMN")]
	[Header("Core")]
	public BoxCollider NJEAMAHEMHP;

	[Header("Empty Part")]
	[FormerlySerializedAs("PLDKMFJPCKC")]
	public GameObject BELLJDAFDNM;

	[FormerlySerializedAs("ONIHPKHLGNH")]
	public UISprite MBMIOELEAND;

	[Header("Card Part")]
	[FormerlySerializedAs("CDOIFEBFAKL")]
	public GameObject CHNGBAGBLBN;

	[FormerlySerializedAs("EFOADHPHCHJ")]
	public UISprite BBJGODFHBCI;

	[FormerlySerializedAs("PKCAOLNKADK")]
	public UISprite DPMLMAOJPNL;

	[FormerlySerializedAs("EKIAGNIBEBA")]
	public UITexture PJEPGKLGMLO;

	[FormerlySerializedAs("MLNHBBALBFO")]
	public UISprite IBKLPHAIOOG;

	[FormerlySerializedAs("AABAFJKNEPF")]
	public UILabel FBLGPCFOFCK;

	[FormerlySerializedAs("PGIOEJDFNKP")]
	public GameObject CDHLCGBCDGH;

	private Card GHINGDGFNJC;

	public bool isAvailable => BELLJDAFDNM.activeSelf || CHNGBAGBLBN.activeSelf;

	public bool isEmpty => BELLJDAFDNM.activeSelf && GHINGDGFNJC == null;

	public Card card
	{
		get
		{
			return GHINGDGFNJC;
		}
		private set
		{
			if (value == null && GHINGDGFNJC != null)
			{
				GHINGDGFNJC.HideInMenu();
			}
			GHINGDGFNJC = value;
			if (GHINGDGFNJC != null)
			{
				GHINGDGFNJC.ShowInMenu();
			}
		}
	}

	public void EEIHBNDDOPH(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		BDEFKKADPMO(DFFBEFJNDLG);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: false);
		AMFHHFGBOHC();
		GHONIOHNELP().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(EDDEMJJMJGA && !IKNAKAEKION);
	}

	public void HPBEEHLILGC()
	{
		card = null;
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(value: true);
		CHNGBAGBLBN.SetActive(value: false);
		BLFJLFODINO();
	}

	public void LMLEPPLELFG(CardRecord PJOFHIKENOI)
	{
		EEIHBNDDOPH(PJOFHIKENOI.card);
		CHNGBAGBLBN.transform.position = PJOFHIKENOI.transform.position;
		CHNGBAGBLBN.transform.localPosition = new Vector3(CHNGBAGBLBN.transform.localPosition.x, CHNGBAGBLBN.transform.localPosition.y, 921f);
		TweenPosition.Begin(CHNGBAGBLBN, 1270f, new Vector3(181f, 823f, 107f)).onFinished = NPEDOPAGPBK;
	}

	public void IMLLMDGNPIP()
	{
		if (IDAFBNLMABN() != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = GHONIOHNELP();
			InitializeEmpty();
			GuiElementSingle<CardpoolDialog>.instance.CKMOMKOLGMI(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)90, 1058f);
		}
	}

	private void DOGAHBIGJPN()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(1696f, 549f, 1749f);
	}

	private void GIOILPFEDMN(UITweener MGDJMGHCAAI)
	{
		BELLJDAFDNM.SetActive(value: false);
		CDHLCGBCDGH.SetActive(!IKNAKAEKION);
	}

	public void MKACIABNBPG()
	{
		if (GHONIOHNELP() != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = GHONIOHNELP();
			PDEAPJCGEBB();
			GuiElementSingle<CardpoolDialog>.instance.GMAIOLNGFOP(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-55), 168f);
		}
	}

	public void BECLEKDBJGE()
	{
		if (GDEDIPNIMPM() != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = IDAFBNLMABN();
			MBDCNCMPNMI();
			GuiElementSingle<CardpoolDialog>.instance.FGJOHIHIAGK(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-72), 1521f);
		}
	}

	protected void OOCJOBIIKAH()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && LIAEHNGMCNC() != null && GDEDIPNIMPM().iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(value: false);
			PJEPGKLGMLO.gameObject.SetActive(value: false);
			PJEPGKLGMLO.mainTexture = NGBHOFNJMOA().iconTexture;
		}
	}

	[SpecialName]
	public bool JNLODOLBBKG()
	{
		return BELLJDAFDNM.activeSelf && GHINGDGFNJC == null;
	}

	public void PBMKJEHBEOD()
	{
		card = null;
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: true);
		INKDKCCEPMA();
	}

	[SpecialName]
	private void BOFKJFFJIKN(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	public void OGNJINPOMPB(CardRecord PJOFHIKENOI)
	{
		MCPAHNNCMIJ(PJOFHIKENOI.card, INPPKILPEKI: false, EDDEMJJMJGA: false);
		CHNGBAGBLBN.transform.position = PJOFHIKENOI.transform.position;
		CHNGBAGBLBN.transform.localPosition = new Vector3(CHNGBAGBLBN.transform.localPosition.x, CHNGBAGBLBN.transform.localPosition.y, 526f);
		TweenPosition.Begin(CHNGBAGBLBN, 593f, new Vector3(360f, 1305f, 741f), useLocal: false).onFinished = NPEDOPAGPBK;
	}

	[SpecialName]
	public Card OEJFLKOKILF()
	{
		return GHINGDGFNJC;
	}

	private void EALGFOKFHNF()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(734f, 96f, 261f);
	}

	[SpecialName]
	public Card GDEDIPNIMPM()
	{
		return GHINGDGFNJC;
	}

	[SpecialName]
	public bool MOPCBBPAJCP()
	{
		return BELLJDAFDNM.activeSelf || CHNGBAGBLBN.activeSelf;
	}

	private void LBIMODMNCOK(UITweener MGDJMGHCAAI)
	{
		BELLJDAFDNM.SetActive(value: false);
		CDHLCGBCDGH.SetActive(IKNAKAEKION);
	}

	public void InitializeCard(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		card = DFFBEFJNDLG;
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: true);
		PLLGPINPCCG();
		card.SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(EDDEMJJMJGA && !IKNAKAEKION);
	}

	private void MEKNOLAFOAJ(UITweener MGDJMGHCAAI)
	{
		BELLJDAFDNM.SetActive(value: false);
		CDHLCGBCDGH.SetActive(!IKNAKAEKION);
	}

	private void LDEBNKHCEFJ(UITweener MGDJMGHCAAI)
	{
		BELLJDAFDNM.SetActive(value: false);
		CDHLCGBCDGH.SetActive(!IKNAKAEKION);
	}

	private void CMGBDIDHCMM(UITweener MGDJMGHCAAI)
	{
		BELLJDAFDNM.SetActive(value: true);
		CDHLCGBCDGH.SetActive(IKNAKAEKION);
	}

	private void CCBPIGCKCMO(UITweener MGDJMGHCAAI)
	{
		BELLJDAFDNM.SetActive(value: false);
		CDHLCGBCDGH.SetActive(IKNAKAEKION);
	}

	private void LGIAFKKGGPO()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(1712f, 255f, 1504f);
	}

	protected void PKPIMPKNFJJ()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && NGBHOFNJMOA() != null && OEJFLKOKILF().iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(value: true);
			PJEPGKLGMLO.gameObject.SetActive(value: false);
			PJEPGKLGMLO.mainTexture = IDAFBNLMABN().iconTexture;
		}
	}

	private void CGMLEODJEKL()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(463f, 983f, 705f);
	}

	[SpecialName]
	public bool BEHKMMFCMNE()
	{
		return BELLJDAFDNM.activeSelf || CHNGBAGBLBN.activeSelf;
	}

	private void ODJCHLKNKOC()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(1330f, 1595f, 1744f);
	}

	[SpecialName]
	public bool KJKHHDDGKIM()
	{
		return BELLJDAFDNM.activeSelf && GHINGDGFNJC == null;
	}

	public void POFHFNIDADF(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		PGNCBPEFKPH(DFFBEFJNDLG);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: false);
		EALGFOKFHNF();
		OEJFLKOKILF().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(EDDEMJJMJGA && IKNAKAEKION);
	}

	public void BFJKHJBIBMC()
	{
		PGNCBPEFKPH(null);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: false);
		EALGFOKFHNF();
	}

	[SpecialName]
	public bool BCELACMHMOI()
	{
		return BELLJDAFDNM.activeSelf && GHINGDGFNJC == null;
	}

	[SpecialName]
	public Card NGBHOFNJMOA()
	{
		return GHINGDGFNJC;
	}

	private void NPEDOPAGPBK(UITweener MGDJMGHCAAI)
	{
		BELLJDAFDNM.SetActive(value: true);
		CDHLCGBCDGH.SetActive(IKNAKAEKION);
	}

	public void DCMNJKEPDJO()
	{
		if (DMEEMLPIHJJ() != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = ABNFGCHOJJH();
			MBDCNCMPNMI();
			GuiElementSingle<CardpoolDialog>.instance.RemoveCard(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardEquiped, 36f);
		}
	}

	[SpecialName]
	public bool OJGEPPOMMEO()
	{
		return !BELLJDAFDNM.activeSelf && CHNGBAGBLBN.activeSelf;
	}

	public void ONIDGNIBFAC(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		JBIDBLAHGDG(DFFBEFJNDLG);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: false);
		CGMLEODJEKL();
		card.SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(!EDDEMJJMJGA || !IKNAKAEKION);
	}

	public void EAAFKLCOAJC(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		GFPAKAMDOGN(DFFBEFJNDLG);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: true);
		EALGFOKFHNF();
		GHONIOHNELP().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(!EDDEMJJMJGA || !IKNAKAEKION);
	}

	protected void HNOBCHFHPNF()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && GHONIOHNELP() != null && IDAFBNLMABN().iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(value: true);
			PJEPGKLGMLO.gameObject.SetActive(value: true);
			PJEPGKLGMLO.mainTexture = NGBHOFNJMOA().iconTexture;
		}
	}

	public void HPKNMDLFJPC()
	{
		ELNBLJGEJIK(null);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: false);
		CGMLEODJEKL();
		MBMIOELEAND.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	public void IDOOOFNNGJC()
	{
		if (card != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = IDAFBNLMABN();
			BNGLEDLBCNC();
			GuiElementSingle<CardpoolDialog>.instance.FGJOHIHIAGK(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-52), 1968f);
		}
	}

	public void NPMPGHIDPCM()
	{
		if (NGBHOFNJMOA() != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = LIAEHNGMCNC();
			NLIOGJLOOJB();
			GuiElementSingle<CardpoolDialog>.instance.FGJOHIHIAGK(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-50), 680f);
		}
	}

	public void NNGCENCIGDE(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		BOFKJFFJIKN(DFFBEFJNDLG);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: false);
		BLFJLFODINO();
		NGBHOFNJMOA().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(EDDEMJJMJGA && IKNAKAEKION);
	}

	[SpecialName]
	public bool MDKJFOCBPOB()
	{
		return BELLJDAFDNM.activeSelf || CHNGBAGBLBN.activeSelf;
	}

	[SpecialName]
	private void DODEKJIIICJ(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	public void PDEAPJCGEBB()
	{
		IMGOFJJBCBH(null);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: true);
		CHNGBAGBLBN.SetActive(value: false);
		BLFJLFODINO();
		MBMIOELEAND.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	public void KPIMHMDOJNA()
	{
		PGNCBPEFKPH(null);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: true);
		PLLGPINPCCG();
	}

	[SpecialName]
	public bool JKHOOOBHGJB()
	{
		return !BELLJDAFDNM.activeSelf || GHINGDGFNJC == null;
	}

	[SpecialName]
	public bool EKHAHPKJACA()
	{
		return BELLJDAFDNM.activeSelf || CHNGBAGBLBN.activeSelf;
	}

	[SpecialName]
	public bool NPOPIGOCGKH()
	{
		return BELLJDAFDNM.activeSelf || CHNGBAGBLBN.activeSelf;
	}

	public void FBKLMPFMIME()
	{
		if (GHONIOHNELP() != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = GDEDIPNIMPM();
			InitializeEmpty();
			GuiElementSingle<CardpoolDialog>.instance.CKMOMKOLGMI(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-78), 984f);
		}
	}

	public void BNGLEDLBCNC()
	{
		JBIDBLAHGDG(null);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: true);
		AMFHHFGBOHC();
		MBMIOELEAND.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	public void HCGHACHNBCE(CardRecord PJOFHIKENOI)
	{
		MCPAHNNCMIJ(PJOFHIKENOI.card);
		CHNGBAGBLBN.transform.position = PJOFHIKENOI.transform.position;
		CHNGBAGBLBN.transform.localPosition = new Vector3(CHNGBAGBLBN.transform.localPosition.x, CHNGBAGBLBN.transform.localPosition.y, 1635f);
		TweenPosition.Begin(CHNGBAGBLBN, 1528f, new Vector3(1697f, 1233f, 876f)).onFinished = NPEDOPAGPBK;
	}

	public void LKCMKLIENJA()
	{
		card = null;
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: true);
		EALGFOKFHNF();
	}

	protected void GIOFPLDAHFN()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && card != null && ABNFGCHOJJH().iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(value: true);
			PJEPGKLGMLO.gameObject.SetActive(value: false);
			PJEPGKLGMLO.mainTexture = DMEEMLPIHJJ().iconTexture;
		}
	}

	public void EAKDDAGHKFK(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		PGNCBPEFKPH(DFFBEFJNDLG);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: true);
		CGMLEODJEKL();
		NGBHOFNJMOA().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(!EDDEMJJMJGA || !IKNAKAEKION);
	}

	public void MBDCNCMPNMI()
	{
		LODIIFJKLMN(null);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(value: true);
		CHNGBAGBLBN.SetActive(value: false);
		JFPJGLBBBKO();
		MBMIOELEAND.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	public void DOFOLHEJGEJ(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		card = DFFBEFJNDLG;
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: true);
		PLLGPINPCCG();
		DMEEMLPIHJJ().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(!EDDEMJJMJGA || IKNAKAEKION);
	}

	[SpecialName]
	public bool ENJEFJKMCPK()
	{
		return !BELLJDAFDNM.activeSelf || GHINGDGFNJC == null;
	}

	private void GDGIEHAMFMN()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(1072f, 1720f, 1215f);
	}

	public void KOMPMAKGABD(CardRecord PJOFHIKENOI)
	{
		POFHFNIDADF(PJOFHIKENOI.card, INPPKILPEKI: true, EDDEMJJMJGA: false);
		CHNGBAGBLBN.transform.position = PJOFHIKENOI.transform.position;
		CHNGBAGBLBN.transform.localPosition = new Vector3(CHNGBAGBLBN.transform.localPosition.x, CHNGBAGBLBN.transform.localPosition.y, 756f);
		TweenPosition.Begin(CHNGBAGBLBN, 138f, new Vector3(1922f, 1467f, 1675f), useLocal: false).onFinished = CMGBDIDHCMM;
	}

	public void FJMLAMGABPE()
	{
		if (GDEDIPNIMPM() != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = ABNFGCHOJJH();
			HPKNMDLFJPC();
			GuiElementSingle<CardpoolDialog>.instance.KEJGLIIOBKD(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LevelUp, 1285f);
		}
	}

	[SpecialName]
	private void LODIIFJKLMN(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	public void FJCAJKHBCFO()
	{
		if (ABNFGCHOJJH() != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = DMEEMLPIHJJ();
			HPKNMDLFJPC();
			GuiElementSingle<CardpoolDialog>.instance.FGJOHIHIAGK(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Fight, 134f);
		}
	}

	[SpecialName]
	public bool JFPMOKLENLO()
	{
		return BELLJDAFDNM.activeSelf || CHNGBAGBLBN.activeSelf;
	}

	[SpecialName]
	private void JBIDBLAHGDG(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	protected void PJLKNBGFHKE()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && ABNFGCHOJJH() != null && IDAFBNLMABN().iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(value: true);
			PJEPGKLGMLO.gameObject.SetActive(value: true);
			PJEPGKLGMLO.mainTexture = OEJFLKOKILF().iconTexture;
		}
	}

	public void CCKJHIPIMDB(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		BDEFKKADPMO(DFFBEFJNDLG);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: true);
		BLFJLFODINO();
		NGBHOFNJMOA().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(EDDEMJJMJGA && !IKNAKAEKION);
	}

	public void MLAENNBDNOJ()
	{
		ELNBLJGEJIK(null);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: true);
		AMFHHFGBOHC();
	}

	public void IMMMBJAFFDD(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		KEJJEBPAPGD(DFFBEFJNDLG);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: true);
		ODJCHLKNKOC();
		GDEDIPNIMPM().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(!EDDEMJJMJGA || !IKNAKAEKION);
	}

	[SpecialName]
	public bool KGOFDKPMCMM()
	{
		return !BELLJDAFDNM.activeSelf || GHINGDGFNJC == null;
	}

	[SpecialName]
	private void BDEFKKADPMO(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	private void INKDKCCEPMA()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(1289f, 418f, 1473f);
	}

	[SpecialName]
	public Card DMEEMLPIHJJ()
	{
		return GHINGDGFNJC;
	}

	public void NMJAANNEMHN()
	{
		BPCLDKOGCEH(null);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: false);
		LGIAFKKGGPO();
		MBMIOELEAND.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	[SpecialName]
	private void EHBDBBPHBHO(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	[SpecialName]
	private void IMGOFJJBCBH(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	public void ENMIPLPDKDA()
	{
		KEJJEBPAPGD(null);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: false);
		GDGIEHAMFMN();
	}

	[CompilerGenerated]
	private void JGDNAPMJGJL(UITweener MGDJMGHCAAI)
	{
		BELLJDAFDNM.SetActive(value: false);
		CDHLCGBCDGH.SetActive(!IKNAKAEKION);
	}

	public void BGIJLDHEJIL(CardRecord PJOFHIKENOI)
	{
		GPGOBGHNOJC(PJOFHIKENOI.card, INPPKILPEKI: true, EDDEMJJMJGA: false);
		CHNGBAGBLBN.transform.position = PJOFHIKENOI.transform.position;
		CHNGBAGBLBN.transform.localPosition = new Vector3(CHNGBAGBLBN.transform.localPosition.x, CHNGBAGBLBN.transform.localPosition.y, 1542f);
		TweenPosition.Begin(CHNGBAGBLBN, 202f, new Vector3(1507f, 1035f, 49f), useLocal: false).onFinished = CMGBDIDHCMM;
	}

	public void INMCDCPHALB(CardRecord PJOFHIKENOI)
	{
		POFHFNIDADF(PJOFHIKENOI.card, INPPKILPEKI: false, EDDEMJJMJGA: false);
		CHNGBAGBLBN.transform.position = PJOFHIKENOI.transform.position;
		CHNGBAGBLBN.transform.localPosition = new Vector3(CHNGBAGBLBN.transform.localPosition.x, CHNGBAGBLBN.transform.localPosition.y, 1229f);
		TweenPosition.Begin(CHNGBAGBLBN, 1144f, new Vector3(1187f, 715f, 914f)).onFinished = NPEDOPAGPBK;
	}

	protected void MGKCNLDGNEM()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && LIAEHNGMCNC() != null && NGBHOFNJMOA().iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(value: false);
			PJEPGKLGMLO.gameObject.SetActive(value: false);
			PJEPGKLGMLO.mainTexture = OEJFLKOKILF().iconTexture;
		}
	}

	private void AMFHHFGBOHC()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(1761f, 699f, 1714f);
	}

	public void GPGOBGHNOJC(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		LODIIFJKLMN(DFFBEFJNDLG);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: false);
		PLLGPINPCCG();
		LIAEHNGMCNC().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(!EDDEMJJMJGA || !IKNAKAEKION);
	}

	[SpecialName]
	public bool PNHLGFMFCLG()
	{
		return BELLJDAFDNM.activeSelf && GHINGDGFNJC == null;
	}

	private void PLLGPINPCCG()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(0f, 0f, -1f);
	}

	public void NLIOGJLOOJB()
	{
		GFPAKAMDOGN(null);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(value: true);
		CHNGBAGBLBN.SetActive(value: false);
		BLFJLFODINO();
		MBMIOELEAND.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	public void ICPBCBBIGHM()
	{
		if (NGBHOFNJMOA() != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = DMEEMLPIHJJ();
			HPKNMDLFJPC();
			GuiElementSingle<CardpoolDialog>.instance.CKMOMKOLGMI(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)82, 1030f);
		}
	}

	protected void FADMNOLLJFG()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && IDAFBNLMABN() != null && GHONIOHNELP().iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(value: false);
			PJEPGKLGMLO.gameObject.SetActive(value: false);
			PJEPGKLGMLO.mainTexture = GDEDIPNIMPM().iconTexture;
		}
	}

	[SpecialName]
	public bool MMJKIEDEIHE()
	{
		return !BELLJDAFDNM.activeSelf && CHNGBAGBLBN.activeSelf;
	}

	public void OnClick()
	{
		if (card != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = card;
			InitializeEmpty();
			GuiElementSingle<CardpoolDialog>.instance.RemoveCard(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardReturn);
		}
	}

	public void GFGIIGADDNB()
	{
		ELNBLJGEJIK(null);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: true);
		AMFHHFGBOHC();
	}

	[SpecialName]
	private void PGNCBPEFKPH(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	public void NCBBOFIEMFO()
	{
		LODIIFJKLMN(null);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(value: true);
		CHNGBAGBLBN.SetActive(value: true);
		ODJCHLKNKOC();
	}

	protected void Update()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(value: false);
			PJEPGKLGMLO.gameObject.SetActive(value: true);
			PJEPGKLGMLO.mainTexture = card.iconTexture;
		}
	}

	private void IJAPCINIONN(UITweener MGDJMGHCAAI)
	{
		BELLJDAFDNM.SetActive(value: true);
		CDHLCGBCDGH.SetActive(IKNAKAEKION);
	}

	public void AAJFIHKHDFL()
	{
		if (ABNFGCHOJJH() != null && !IKNAKAEKION)
		{
			Card cEKHIJECPNP = IDAFBNLMABN();
			BNGLEDLBCNC();
			GuiElementSingle<CardpoolDialog>.instance.KEJGLIIOBKD(cEKHIJECPNP);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-108), 1260f);
		}
	}

	[SpecialName]
	public Card IDAFBNLMABN()
	{
		return GHINGDGFNJC;
	}

	[SpecialName]
	public bool OHOJGBMNBMD()
	{
		return BELLJDAFDNM.activeSelf || CHNGBAGBLBN.activeSelf;
	}

	public void ALMAGFPFCMF()
	{
		ELNBLJGEJIK(null);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: true);
		CHNGBAGBLBN.SetActive(value: false);
		AMFHHFGBOHC();
	}

	public void InitializeEmpty()
	{
		card = null;
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: true);
		CHNGBAGBLBN.SetActive(value: false);
		PLLGPINPCCG();
		MBMIOELEAND.color = ((!IKNAKAEKION) ? Colours.grayBorder : Colours.pink);
	}

	[SpecialName]
	private void GFPAKAMDOGN(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	public void InitializeNoCard()
	{
		card = null;
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: false);
		PLLGPINPCCG();
	}

	[SpecialName]
	public bool CCKOHCNBDIF()
	{
		return BELLJDAFDNM.activeSelf && GHINGDGFNJC == null;
	}

	public void PFOKLOJIBPP()
	{
		card = null;
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: true);
		CHNGBAGBLBN.SetActive(value: false);
		INKDKCCEPMA();
	}

	public void CBBKOFLOFFO()
	{
		BPCLDKOGCEH(null);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: true);
		CHNGBAGBLBN.SetActive(value: false);
		GDGIEHAMFMN();
	}

	public void AnimateCard(CardRecord PJOFHIKENOI)
	{
		InitializeCard(PJOFHIKENOI.card, INPPKILPEKI: true, EDDEMJJMJGA: false);
		CHNGBAGBLBN.transform.position = PJOFHIKENOI.transform.position;
		CHNGBAGBLBN.transform.localPosition = new Vector3(CHNGBAGBLBN.transform.localPosition.x, CHNGBAGBLBN.transform.localPosition.y, -1f);
		TweenPosition.Begin(CHNGBAGBLBN, 0.4f, new Vector3(0f, 0f, -1f)).onFinished = delegate
		{
			BELLJDAFDNM.SetActive(value: false);
			CDHLCGBCDGH.SetActive(!IKNAKAEKION);
		};
	}

	public void GLCCEEMLGKE()
	{
		EHBDBBPHBHO(null);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: true);
		PLLGPINPCCG();
	}

	[SpecialName]
	private void LABMGKFEGCP(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	public void GGHLGOCFLBK(CardRecord PJOFHIKENOI)
	{
		NNGCENCIGDE(PJOFHIKENOI.card, INPPKILPEKI: false, EDDEMJJMJGA: false);
		CHNGBAGBLBN.transform.position = PJOFHIKENOI.transform.position;
		CHNGBAGBLBN.transform.localPosition = new Vector3(CHNGBAGBLBN.transform.localPosition.x, CHNGBAGBLBN.transform.localPosition.y, 1650f);
		TweenPosition.Begin(CHNGBAGBLBN, 1442f, new Vector3(833f, 1945f, 1508f), useLocal: false).onFinished = CCBPIGCKCMO;
	}

	[SpecialName]
	public Card ABNFGCHOJJH()
	{
		return GHINGDGFNJC;
	}

	protected void CFLALBENGJN()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && OEJFLKOKILF() != null && ABNFGCHOJJH().iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(value: false);
			PJEPGKLGMLO.gameObject.SetActive(value: true);
			PJEPGKLGMLO.mainTexture = NGBHOFNJMOA().iconTexture;
		}
	}

	private void BLFJLFODINO()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(1581f, 453f, 1575f);
	}

	[SpecialName]
	public bool DHHGIJJDLPI()
	{
		return !BELLJDAFDNM.activeSelf || GHINGDGFNJC == null;
	}

	[SpecialName]
	public Card LIAEHNGMCNC()
	{
		return GHINGDGFNJC;
	}

	public void PDLLIGDDKFP()
	{
		BPCLDKOGCEH(null);
		NJEAMAHEMHP.enabled = true;
		BELLJDAFDNM.SetActive(value: false);
		CHNGBAGBLBN.SetActive(value: true);
		BLFJLFODINO();
	}

	[SpecialName]
	private void AGDHPCNHFMM(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	[SpecialName]
	private void KEJJEBPAPGD(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	[SpecialName]
	private void BPCLDKOGCEH(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	[SpecialName]
	public Card GHONIOHNELP()
	{
		return GHINGDGFNJC;
	}

	public void KKADNGDACHO(CardRecord PJOFHIKENOI)
	{
		ONIDGNIBFAC(PJOFHIKENOI.card, INPPKILPEKI: true);
		CHNGBAGBLBN.transform.position = PJOFHIKENOI.transform.position;
		CHNGBAGBLBN.transform.localPosition = new Vector3(CHNGBAGBLBN.transform.localPosition.x, CHNGBAGBLBN.transform.localPosition.y, 104f);
		TweenPosition.Begin(CHNGBAGBLBN, 797f, new Vector3(166f, 1131f, 1521f), useLocal: false).onFinished = CCBPIGCKCMO;
	}

	[SpecialName]
	public bool OMNDLICBCLI()
	{
		return BELLJDAFDNM.activeSelf && GHINGDGFNJC == null;
	}

	private void JFPJGLBBBKO()
	{
		TweenPosition component = CHNGBAGBLBN.GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = true;
		}
		CHNGBAGBLBN.transform.localPosition = new Vector3(1498f, 1250f, 434f);
	}

	public void MCPAHNNCMIJ(Card DFFBEFJNDLG, bool INPPKILPEKI = false, bool EDDEMJJMJGA = true)
	{
		DODEKJIIICJ(DFFBEFJNDLG);
		NJEAMAHEMHP.enabled = false;
		BELLJDAFDNM.SetActive(INPPKILPEKI);
		CHNGBAGBLBN.SetActive(value: false);
		BLFJLFODINO();
		DMEEMLPIHJJ().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FBLGPCFOFCK, PJEPGKLGMLO);
		CDHLCGBCDGH.SetActive(EDDEMJJMJGA && !IKNAKAEKION);
	}

	[SpecialName]
	private void ELNBLJGEJIK(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}
}
