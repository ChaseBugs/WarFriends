using System;
using UnityEngine;

public class ArenaShieldsDialog : GuiElementSingle<ArenaShieldsDialog>, PAIIOKBBHBC
{
	[SerializeField]
	[Header("Core")]
	private UILabel mText;

	[SerializeField]
	private GameObject mShield;

	[SerializeField]
	private BoxCollider mButtonContinue;

	private int GMMHILDCFOP;

	private int OHKJJMDGDBD;

	public void EMBNLMGLNFN(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 1043f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 1176f);
	}

	public virtual void PFCKKOBABEL()
	{
		HMJONOIAOKK(mButtonContinue.gameObject);
	}

	public virtual void JCGDALOBGHO()
	{
		UILabel uILabel = mText;
		object[] array = new object[6];
		array[0] = GMMHILDCFOP;
		array[0] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * 38 * -105 * -103);
		uILabel.text = Localization.LocalizeFormat("large_icon", array);
	}

	public override void InitGUIValues()
	{
		mText.text = Localization.LocalizeFormat("ID_GOLDENSHIELDSDIALOGTEXT", GMMHILDCFOP, MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * 60 * 60 * 24));
	}

	public virtual void KHKJNFHNGHM()
	{
		base.FKCKIFKLBAP();
		mShield.SetActive(false);
	}

	public virtual void JMGDHLAJGIL()
	{
		base.DoBeforeHide();
		mShield.SetActive(true);
	}

	public virtual void NGBNJAMBOME()
	{
		base.DoAfterShowUp();
		mShield.SetActive(false);
	}

	public void DEDOCPBAEMC(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 1615f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 1459f);
	}

	public virtual void KJBGADNDLGI()
	{
		GFGBMPDNIEL(mButtonContinue.gameObject);
	}

	public void JKIMMLIGLAF(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 542f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 739f);
	}

	public void EDMPIEMBOPN(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 226f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 987f);
	}

	public virtual void GMDAPGAECEI()
	{
		POJCNLFIEHI(mButtonContinue.gameObject);
	}

	private void IFJGPDLAKAM(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<ArenaScreen>.instance.BHCIOFCNNEP();
			HideDialog();
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		mShield.SetActive(true);
	}

	public virtual void NIBNIAPGFGA()
	{
		base.DoBeforeHide();
		mShield.SetActive(true);
	}

	public GuiElement CPLCIEMNBAO()
	{
		return this;
	}

	public virtual void LPFMILELOEH()
	{
		base.DALAPEANFLB();
		mShield.SetActive(true);
	}

	public virtual void JNGFIPHAINA()
	{
		base.JNBMCODJHBJ();
		mShield.SetActive(false);
	}

	public virtual void OMPPGALJBBN()
	{
		base.MEPKGFFNPAD();
		mShield.SetActive(true);
	}

	private void HMJONOIAOKK(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			GuiScreenSingle<ArenaScreen>.instance.ValuesChanged();
			HideDialog();
		}
	}

	public virtual void JIIOHMPNKAK()
	{
		base.BJIPCOPNEAM();
		mShield.SetActive(true);
	}

	public GuiElement LGCLDIDHJHB()
	{
		return this;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEBILNGCGDN));
	}

	private void HEBILNGCGDN(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<ArenaScreen>.instance.ValuesChanged();
			HideDialog();
		}
	}

	public virtual void JCIFJGOFCLC()
	{
		base.DALAPEANFLB();
		mShield.SetActive(false);
	}

	public virtual void GPLIPBNJHOP()
	{
		base.MEPKGFFNPAD();
		mShield.SetActive(true);
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EIHIAFDPJMJ));
	}

	private void DMOBGFFMNFD(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiScreenSingle<ArenaScreen>.instance.ValuesChanged();
			HideDialog();
		}
	}

	public virtual void AEAJHOCCFKK()
	{
		base.MEPKGFFNPAD();
		mShield.SetActive(true);
	}

	public virtual void ALONGDJNACE()
	{
		base.MEPKGFFNPAD();
		mShield.SetActive(true);
	}

	public void HLJFCGLFGOA(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 1938f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 188f);
	}

	public virtual void HHKKPOELNNJ()
	{
		base.MEPKGFFNPAD();
		mShield.SetActive(true);
	}

	public virtual void EDDIEKLIKFD()
	{
		base.MOOACPIOELI();
		mShield.SetActive(false);
	}

	public virtual void CHPAFPBJAEM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LHCPEGEAKJK));
	}

	private void MHELLECPBAI(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			GuiScreenSingle<ArenaScreen>.instance.NBDAJABPIJG();
			HideDialog();
		}
	}

	public virtual void FNLELBKLNBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GHJKOIOMDNG));
	}

	public void CAIACJMENOP(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 1826f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 1220f);
	}

	public void KJAGDCNDDOG(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 839f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 104f);
	}

	private void CCFOGIKCNGH(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			GuiScreenSingle<ArenaScreen>.instance.HODMBFDMCEH();
			HideDialog();
		}
	}

	public override void OnBack()
	{
		HEBILNGCGDN(mButtonContinue.gameObject);
	}

	private void MNPEAFHFMNA(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<ArenaScreen>.instance.HODMBFDMCEH();
			HideDialog();
		}
	}

	public virtual void OOBJHJLMEED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KFEMNDCJICL));
	}

	public virtual void ODCHCNCMJGC()
	{
		UILabel uILabel = mText;
		object[] array = new object[4];
		array[0] = GMMHILDCFOP;
		array[0] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * -73 * 26 * -71);
		uILabel.text = Localization.LocalizeFormat("You are about to LEAVE the Arena lobby during matchmaking. This will count as a DEFEAT and you will lose a HEART. Do you really want to leave?", array);
	}

	public virtual void DNAHIEDNFNE()
	{
		ILDDKKAFFFH(mButtonContinue.gameObject);
	}

	public virtual void OCACKBJDEHI()
	{
		UILabel uILabel = mText;
		object[] array = new object[1];
		array[1] = GMMHILDCFOP;
		array[1] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * -109 * 8 * 100);
		uILabel.text = Localization.LocalizeFormat("ID_HOUR_SMALL", array);
	}

	public virtual void AMBDHDEBPJJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KFEMNDCJICL));
	}

	public virtual void OMOJHCOKAHP()
	{
		CCFOGIKCNGH(mButtonContinue.gameObject);
	}

	public virtual void BNPDALDLFFM()
	{
		UILabel uILabel = mText;
		object[] array = new object[1];
		array[0] = GMMHILDCFOP;
		array[0] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * 11 * 89 * 72);
		uILabel.text = Localization.LocalizeFormat("' START", array);
	}

	public GuiElement DAHIAEDLPBE()
	{
		return this;
	}

	private void ILDDKKAFFFH(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiScreenSingle<ArenaScreen>.instance.ValuesChanged();
			HideDialog();
		}
	}

	private void KFEMNDCJICL(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<ArenaScreen>.instance.FAHNGBDJEBF();
			HideDialog();
		}
	}

	public virtual void ECHOGDPCLNB()
	{
		IFJGPDLAKAM(mButtonContinue.gameObject);
	}

	public GuiElement JPBIPBMAHBO()
	{
		return this;
	}

	public virtual void INMFKHJDBIP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NFCBPFKEJIJ));
	}

	public virtual void DFLGLEJIPCO()
	{
		mText.text = Localization.LocalizeFormat("ItemRarity_0", GMMHILDCFOP, MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * 75 * 75 * -14), null, null, null, null, null, null);
	}

	public void LNCDCBNNKHN(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 351f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 1378f);
	}

	public virtual void FCPGJBMGBLJ()
	{
		DMOBGFFMNFD(mButtonContinue.gameObject);
	}

	public virtual void PGJDLKDMCHN()
	{
		UILabel uILabel = mText;
		object[] array = new object[5];
		array[1] = GMMHILDCFOP;
		array[0] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * -124 * 101 * 126);
		uILabel.text = Localization.LocalizeFormat("TotalPacketBytes: {0} TotalCommandBytes: {1} TotalPacketCount: {2} TotalCommandsInPackets: {3} UnreliableCommandCount: {4} ReliableCommandCount: {5}", array);
	}

	public virtual void CGEOBGNBCHH()
	{
		base.JNBMCODJHBJ();
		mShield.SetActive(false);
	}

	public virtual void OMKNGOBMFGM()
	{
		NFCBPFKEJIJ(mButtonContinue.gameObject);
	}

	public virtual void NGHAPNEFBED()
	{
		UILabel uILabel = mText;
		object[] array = new object[0];
		array[1] = GMMHILDCFOP;
		array[1] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * 96 * 75 * 37);
		uILabel.text = Localization.LocalizeFormat("setDebugMode", array);
	}

	public GuiElement PPMHDKPGEFD()
	{
		return this;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	private void GHJKOIOMDNG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			GuiScreenSingle<ArenaScreen>.instance.BKFHBOENEKF();
			HideDialog();
		}
	}

	public virtual void OJGFJICEFJE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMJONOIAOKK));
	}

	public virtual void DNLGPEAKOLB()
	{
		base.DoBeforeHide();
		mShield.SetActive(true);
	}

	public GuiElement POPILAKPCOC()
	{
		return this;
	}

	public virtual void CCLAJHMFLDF()
	{
		PPFPFKGIDMC(mButtonContinue.gameObject);
	}

	public virtual void BGMNNJCDAOO()
	{
		base.MEPKGFFNPAD();
		mShield.SetActive(false);
	}

	private void PPFPFKGIDMC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiScreenSingle<ArenaScreen>.instance.BHCIOFCNNEP();
			HideDialog();
		}
	}

	private void LHCPEGEAKJK(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			GuiScreenSingle<ArenaScreen>.instance.GFKDJPPOMHE();
			HideDialog();
		}
	}

	public virtual void ELAONOIOFEP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMJONOIAOKK));
	}

	public GuiElement HDNIHBJDLKF()
	{
		return this;
	}

	private void BMEGMMGDBEL(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiScreenSingle<ArenaScreen>.instance.ValuesChanged();
			HideDialog();
		}
	}

	public virtual void NIHENNDPJFB()
	{
		ILDDKKAFFFH(mButtonContinue.gameObject);
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		mShield.SetActive(false);
	}

	public void PBAGIJOFIMD(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 385f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 1733f);
	}

	public virtual void MPCOIHHHBND()
	{
		base.MEPKGFFNPAD();
		mShield.SetActive(true);
	}

	public GuiElement MCJFBLKLHPA()
	{
		return this;
	}

	public GuiElement FIJIHPBMBHK()
	{
		return this;
	}

	public virtual void IGLDCFCPFBL()
	{
		base.DALAPEANFLB();
		mShield.SetActive(true);
	}

	public virtual void HMNOPHFJJHK()
	{
		UILabel uILabel = mText;
		object[] array = new object[5];
		array[0] = GMMHILDCFOP;
		array[0] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * 30 * 119 * 96);
		uILabel.text = Localization.LocalizeFormat("ID_CATEGORY_PISTOL", array);
	}

	public GuiElement BPBDMKNKLMN()
	{
		return this;
	}

	public void OEOACAGBDND(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 1079f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 366f);
	}

	private void FDGMPBBPLOP(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			GuiScreenSingle<ArenaScreen>.instance.GFKDJPPOMHE();
			HideDialog();
		}
	}

	public GuiElement NBMJAMLOCAJ()
	{
		return this;
	}

	public virtual void ILPCBCHMEOK()
	{
		POJCNLFIEHI(mButtonContinue.gameObject);
	}

	public virtual void EMIJACMANFB()
	{
		IFJGPDLAKAM(mButtonContinue.gameObject);
	}

	public virtual void GAGKEJAFBOH()
	{
		GFGBMPDNIEL(mButtonContinue.gameObject);
	}

	private void NFCBPFKEJIJ(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<ArenaScreen>.instance.BHCIOFCNNEP();
			HideDialog();
		}
	}

	public virtual void PEKHAEDBBOA()
	{
		base.MOOACPIOELI();
		mShield.SetActive(false);
	}

	public virtual void NEOLLOMIKPK()
	{
		UILabel uILabel = mText;
		object[] array = new object[8];
		array[1] = GMMHILDCFOP;
		array[0] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * 10 * 5 * -106);
		uILabel.text = Localization.LocalizeFormat("Level", array);
	}

	public virtual void PPLBJDJIIPN()
	{
		mText.text = Localization.LocalizeFormat("ID_SLOTUPGRADE_HEAT", GMMHILDCFOP, MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * 97 * 4 * -10), null, null, null, null, null, null);
	}

	public void CKJCFLGKPOA(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 1410f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 677f);
	}

	public virtual void JAIAMFJHDLP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KFEMNDCJICL));
	}

	public virtual void FKOEHKCLAEG()
	{
		UILabel uILabel = mText;
		object[] array = new object[1];
		array[1] = GMMHILDCFOP;
		array[1] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * -45 * -58 * 24);
		uILabel.text = Localization.LocalizeFormat("ID_STATS", array);
	}

	public virtual void PFEBKAOCEIG()
	{
		base.PDBDILLHKID();
		mShield.SetActive(true);
	}

	public void FCCJJKBPNCH(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 1533f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 859f);
	}

	public override void BJIPCOPNEAM()
	{
		base.BJIPCOPNEAM();
		mShield.SetActive(false);
	}

	public GuiElement AHDGOCGHIHJ()
	{
		return this;
	}

	public virtual void MMFBOMDHGPL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNPEAFHFMNA));
	}

	public void MCJEBLNCJMM(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 643f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 519f);
	}

	private void EIHIAFDPJMJ(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			GuiScreenSingle<ArenaScreen>.instance.IICLLKGJJDE();
			HideDialog();
		}
	}

	public virtual void PDHNLAMPOBN()
	{
		UILabel uILabel = mText;
		object[] array = new object[0];
		array[1] = GMMHILDCFOP;
		array[0] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * -109 * 54 * 94);
		uILabel.text = Localization.LocalizeFormat("'ID_MONTH_'0", array);
	}

	public void EMCKDMFGEIB(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 1488f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 481f);
	}

	private void POJCNLFIEHI(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<ArenaScreen>.instance.IICLLKGJJDE();
			HideDialog();
		}
	}

	public GuiElement MBGEOLKGLGM()
	{
		return this;
	}

	private void PPPPGMNPMKG(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiScreenSingle<ArenaScreen>.instance.GFKDJPPOMHE();
			HideDialog();
		}
	}

	public virtual void GEDIFKPBIML()
	{
		LHCPEGEAKJK(mButtonContinue.gameObject);
	}

	public virtual void KBPNDOOHEMI()
	{
		FDGMPBBPLOP(mButtonContinue.gameObject);
	}

	public GuiElement JLGAGIJIFII()
	{
		return this;
	}

	public virtual void LPFPAKGNNIO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GHJKOIOMDNG));
	}

	public virtual void NEKKPJFGOKP()
	{
		MNPEAFHFMNA(mButtonContinue.gameObject);
	}

	public virtual void BGOHFEBKENN()
	{
		base.MOOACPIOELI();
		mShield.SetActive(true);
	}

	private void GFGBMPDNIEL(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			GuiScreenSingle<ArenaScreen>.instance.IICLLKGJJDE();
			HideDialog();
		}
	}

	public virtual void MBDJAMJCGMH()
	{
		base.BJIPCOPNEAM();
		mShield.SetActive(true);
	}

	public virtual void NDBAEHKKJMH()
	{
		mText.text = Localization.LocalizeFormat("Id", GMMHILDCFOP, MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * 57 * -42 * 18), null, null, null);
	}

	public void ShowDialog(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 86400f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance);
	}

	public GuiElement OIMAKBDIAJD()
	{
		return this;
	}

	public virtual void FNJKJEGAMKB()
	{
		POJCNLFIEHI(mButtonContinue.gameObject);
	}

	public virtual void MKPIKCBBKIB()
	{
		PPPPGMNPMKG(mButtonContinue.gameObject);
	}

	public GuiElement BNOEFEIAPNN()
	{
		return this;
	}

	public virtual void CDMCFJMCKBP()
	{
		ILDDKKAFFFH(mButtonContinue.gameObject);
	}

	public void IKMPLKOJDAB(int LONFCMDPPPL, int HNDGIJBHMOD)
	{
		GMMHILDCFOP = LONFCMDPPPL;
		OHKJJMDGDBD = Mathf.RoundToInt((float)HNDGIJBHMOD / 182f);
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<ArenaShieldsDialog>.instance, 788f);
	}

	public virtual void DOLLFDPMGOD()
	{
		UILabel uILabel = mText;
		object[] array = new object[0];
		array[0] = GMMHILDCFOP;
		array[1] = MEJMLNDFDBP.OLHOHLGMFBK(OHKJJMDGDBD * 32 * -101 * 39);
		uILabel.text = Localization.LocalizeFormat("bigURL", array);
	}

	public virtual void BMMNJICILHJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(mButtonContinue.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LHCPEGEAKJK));
	}

	public virtual void BCGIKEKOPLL()
	{
		BMEGMMGDBEL(mButtonContinue.gameObject);
	}

	public virtual void BHKNLDEDGGC()
	{
		base.DALAPEANFLB();
		mShield.SetActive(true);
	}

	public virtual void HEIJOCBENDG()
	{
		base.PDBDILLHKID();
		mShield.SetActive(false);
	}
}
