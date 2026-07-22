using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SquadFindResults : Core_BaseScript
{
	[FormerlySerializedAs("GGNOLNHCGDF")]
	public bool OJENCLCONOF = true;

	[Header("Content List")]
	[FormerlySerializedAs("DGMJJCDJFGC")]
	public SquadRecord DBKNGEJPNJE;

	[FormerlySerializedAs("ICKPAEEPOBH")]
	public UIDraggablePanel NFLPPGKCOBL;

	[FormerlySerializedAs("PIEFNCGMIKF")]
	public UIPanel HHMKGNICFMA;

	[FormerlySerializedAs("OAOEJMFHEPM")]
	public UIPooledGrid OLGLAGDAOJH;

	[Header("-List Header")]
	[FormerlySerializedAs("HKAELKNPPGD")]
	public GameObject NFNLBEGFLHC;

	[FormerlySerializedAs("MADEDKKBOIH")]
	public UISprite GJIGEFJAKNM;

	[FormerlySerializedAs("JFPCBIIGEPG")]
	public UILabel INFKHFJFFHP;

	[FormerlySerializedAs("LANEPLJMMLC")]
	[Header("-Error")]
	public GameObject DEBFEDLKOBF;

	[FormerlySerializedAs("MBEFKNAENOJ")]
	public UISprite HGIGLLMJDOD;

	[FormerlySerializedAs("LAILNMAIHHO")]
	public UILabel IIJCDFHDAGO;

	[Header("-Waiting")]
	[FormerlySerializedAs("MAJHBOPLLPK")]
	public GameObject NCLKMPOBLIG;

	[Header("Empty Suggested Squads")]
	[FormerlySerializedAs("JMEFLKGLNMI")]
	public UIPanel MKOPJAEKFBP;

	[FormerlySerializedAs("HAIFOPDPNJF")]
	public GameObject DGBFJNCGAFG;

	[FormerlySerializedAs("HMJDHCDLHHI")]
	public BoxCollider CLIOPGGILNE;

	[FormerlySerializedAs("AMFIPJEFKMF")]
	public UIPanel LHIEJCMFJEG;

	[FormerlySerializedAs("EMLKGPOEABG")]
	public GameObject JBOHFMAPCJL;

	[FormerlySerializedAs("AIGGCKDHKKK")]
	public UILabel BHKJDMAKFPP;

	private bool IHEPLEBDJCB;

	private ObjectPool IHFILHIAGLG;

	private List<AANECPGDMGM> AHBEHCBJDLK;

	private bool IKLFMFPLLNB;

	public void POFFDPGKKII(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			CDHLMEPGPNJ();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(MKOPJAEKFBP.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 573f) : 1013f, (!IHEPLEBDJCB) ? 624f : 1457f);
			TweenAlpha.Begin(LHIEJCMFJEG.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 769f) : 1411f, (!IHEPLEBDJCB) ? 1873f : 352f);
			TweenAlpha.Begin(NFLPPGKCOBL.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 1214f) : 1530f, (!IHEPLEBDJCB) ? 319f : 14f).onFinished = GCMMAALDNNL;
		}
		else if (!IHEPLEBDJCB)
		{
			LCJOGAPBFCO();
		}
	}

	public void HAFHEMPGDAL()
	{
		OLGLAGDAOJH.MakeEmpty();
	}

	private void BBPKBPKIGHC()
	{
		if (AHBEHCBJDLK == null || AHBEHCBJDLK.Count == 0)
		{
			Debug.Log("ID_RELOG_TO_WRONG_FB_DIALOG_TITLE");
			if (!IKLFMFPLLNB)
			{
				PCDLOKOEHEP(INPPKILPEKI: true);
				return;
			}
			EIFFNIECDNM(Localization.Localize((!OJENCLCONOF) ? "menu-assignments-type-kill" : "TweetAboutWarfriends"), Color.white);
			NKOENOHCDCA();
		}
		else
		{
			OLGLAGDAOJH.init(AHBEHCBJDLK.Count, EFOFAEIFOMP, JJMACIHMCNA, NFLPPGKCOBL);
			EMHLIBNEFCC();
		}
	}

	public void InitGUIValues()
	{
		NODMNGFKBBN();
		if (string.IsNullOrEmpty(GuiScreenSingle<SquadFindScreen>.instance.lastSearch))
		{
			SetSuggested();
		}
	}

	public void IEHJMLIMNEP()
	{
		ANHHPJCDJFH();
		if (string.IsNullOrEmpty(GuiScreenSingle<SquadFindScreen>.instance.lastSearch))
		{
			AGFKFFJIAME();
		}
	}

	public void JCIBDJMFOLI()
	{
		LCIJJEKCLEJ();
		if (string.IsNullOrEmpty(GuiScreenSingle<SquadFindScreen>.instance.lastSearch))
		{
			FHDCLHADPBG();
		}
	}

	public void JDFDJPAAIAA()
	{
		LCIJJEKCLEJ();
		if (string.IsNullOrEmpty(GuiScreenSingle<SquadFindScreen>.instance.OLNLKLDACBJ()))
		{
			AGFKFFJIAME();
		}
	}

	private void BHFIOHINBLD()
	{
		NFLPPGKCOBL.AlignToPos(instant: false, UIDraggablePanel.Alingment.BottomRight, onePanelDisabledAfterAlign: true);
	}

	public void InitControls()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		IHEPLEBDJCB = false;
		AHHBOOKDBDI();
		UIEventListener uIEventListener = UIEventListener.Get(DGBFJNCGAFG);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEMPGCPOEBL));
	}

	private Transform KAHOJNJFCGN(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < AHBEHCBJDLK.Count)
		{
			AANECPGDMGM aANECPGDMGM = AHBEHCBJDLK[DFHAAIFFLOE];
			if (aANECPGDMGM == null)
			{
				return null;
			}
			SquadRecord squadRecord = (SquadRecord)IHFILHIAGLG.OKEAAILFPIG(DBKNGEJPNJE, OLGLAGDAOJH.gameObject, string.Format("menu-close", aANECPGDMGM.MHPNDNJDPGE));
			if (squadRecord != null)
			{
				squadRecord.ONJCKDNHGCM(aANECPGDMGM, OLGLAGDAOJH.cellWidth);
				return squadRecord.transform;
			}
		}
		return null;
	}

	public void BLLNHEAKPAK()
	{
		TweenAlpha component = NFLPPGKCOBL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		base.gameObject.SetActive(value: true);
		HAFHEMPGDAL();
	}

	public void SetSuggested()
	{
		OLGLAGDAOJH.MakeEmpty();
		HEKJIEEOJIJ(string.Empty, Color.white);
		BIMDBBLJGMO(INPPKILPEKI: false);
		IKLFMFPLLNB = false;
		JHNMODKKCKF(Localization.Localize((!OJENCLCONOF) ? "ID_SUGGESTEDLOCALSQUADS" : "ID_SUGGESTEDGLOBALSQUADS"));
		NCLKMPOBLIG.SetActive(value: true);
		CHLDECOKHLC();
		Singleton<BeanstalkServerManager>.instance.DPJMMFDOKEB(OJENCLCONOF);
	}

	private void ADLEHPJGMGG()
	{
		if (AHBEHCBJDLK == null || AHBEHCBJDLK.Count == 0)
		{
			Debug.Log("ID_NA");
			if (!IKLFMFPLLNB)
			{
				PCDLOKOEHEP(INPPKILPEKI: true);
				return;
			}
			AOCMMJKENLC(Localization.Localize((!OJENCLCONOF) ? "newHeroicPoints" : "Wrong_Unit"), Color.white);
			CBOCBIJAFED();
		}
		else
		{
			OLGLAGDAOJH.init(AHBEHCBJDLK.Count, IGCJKPLMMGD, ONODANIENOA, NFLPPGKCOBL);
			NKOENOHCDCA();
		}
	}

	public void DGLFBGIFAND(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			IEHJMLIMNEP();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(MKOPJAEKFBP.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 564f) : 257f, (!IHEPLEBDJCB) ? 1284f : 1359f);
			TweenAlpha.Begin(LHIEJCMFJEG.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 356f) : 280f, (!IHEPLEBDJCB) ? 1747f : 129f);
			TweenAlpha.Begin(NFLPPGKCOBL.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 1914f) : 327f, (!IHEPLEBDJCB) ? 941f : 1565f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			InstantHideTab();
		}
	}

	private void BDFIELAGAHO(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: false);
			NLBAPEADKNJ();
		}
	}

	public void CGPFPNNICIO()
	{
		OLGLAGDAOJH.MakeEmpty();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = NFLPPGKCOBL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DoAfterHide();
	}

	private void ONODANIENOA(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadRecord component = ENCEFOOPBMK.GetComponent<SquadRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	public void JAGJEDFNMOH(string FLNPPIEDBCC)
	{
		OLGLAGDAOJH.MakeEmpty();
		PCDLOKOEHEP(INPPKILPEKI: false);
		IKLFMFPLLNB = true;
		object[] array = new object[8];
		array[1] = Colours.stringBlue;
		array[1] = FLNPPIEDBCC;
		array[8] = Colours.stringWhite;
		CNKEEIEHBHI(Localization.LocalizeFormat("vibrator", array));
		if (FLNPPIEDBCC.Length < 2)
		{
			object[] array2 = new object[6];
			array2[1] = Colours.stringWhite;
			array2[0] = Colours.stringBlue;
			EIFFNIECDNM(Localization.LocalizeFormat("menu-valuepack-buybutton", array2), Colours.red);
		}
		else
		{
			AOCMMJKENLC(string.Empty, Color.white);
		}
		CHLDECOKHLC();
	}

	public void FOGBJIMBEKI()
	{
		OLGLAGDAOJH.MakeEmpty();
	}

	private void CHLDECOKHLC()
	{
		NFLPPGKCOBL.AlignToPos(instant: false);
	}

	private void EMHLIBNEFCC()
	{
		NFLPPGKCOBL.AlignToPos(instant: true);
	}

	private void FFEKGOHHCNM(string MBLNKOCLJND)
	{
		bool active = !string.IsNullOrEmpty(MBLNKOCLJND);
		NFNLBEGFLHC.SetActive(active);
		INFKHFJFFHP.text = MBLNKOCLJND;
	}

	public void FHDCLHADPBG()
	{
		OLGLAGDAOJH.MakeEmpty();
		EIFFNIECDNM(string.Empty, Color.white);
		PCDLOKOEHEP(INPPKILPEKI: true);
		IKLFMFPLLNB = true;
		FFEKGOHHCNM(Localization.Localize((!OJENCLCONOF) ? "ID_MINUTES" : "YourIdentityPoolId"));
		NCLKMPOBLIG.SetActive(value: true);
		CHLDECOKHLC();
		Singleton<BeanstalkServerManager>.instance.DPJMMFDOKEB(OJENCLCONOF);
	}

	private void AHHBOOKDBDI()
	{
		float activeHeight = UIHelper.activeHeight;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = activeWidthSafe - 120f;
		float num2 = activeHeight - GuiScreenSingle<SquadFindScreen>.instance.headerHeight;
		float y = activeHeight / 2f - GuiScreenSingle<SquadFindScreen>.instance.headerHeight - num2 / 2f;
		HHMKGNICFMA.clipRange = HHMKGNICFMA.clipRange.ReplaceYW(y, num2);
		NFLPPGKCOBL.transform.localPosition = Vector3.zero;
		OLGLAGDAOJH.cellWidth = num;
		GJIGEFJAKNM.transform.localScale = GJIGEFJAKNM.transform.localScale.ReplaceX(num);
		HGIGLLMJDOD.transform.localScale = HGIGLLMJDOD.transform.localScale.ReplaceX(num);
		NCLKMPOBLIG.transform.localPosition = NCLKMPOBLIG.transform.localPosition.ReplaceY(GuiScreenSingle<SquadFindScreen>.instance.headerHeight - activeHeight / 2f - 100f);
	}

	public void CECEKJOPPNB()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	private void LJPIAKGCPBE(bool INPPKILPEKI)
	{
		MKOPJAEKFBP.gameObject.SetActive(INPPKILPEKI);
		if (INPPKILPEKI)
		{
			JHNMODKKCKF(string.Empty);
			AOCMMJKENLC(string.Empty, Color.white);
			NCLKMPOBLIG.SetActive(value: false);
		}
	}

	private void IFODCNELCHA()
	{
		NFLPPGKCOBL.AlignToPos(instant: false, UIDraggablePanel.Alingment.BottomRight);
	}

	public void NLBAPEADKNJ()
	{
		OLGLAGDAOJH.MakeEmpty();
	}

	private void LPEEABFLHON(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !JBOHFMAPCJL.activeSelf)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	private void KJLCKNBLKGJ(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !JBOHFMAPCJL.activeSelf)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	public void AGFKFFJIAME()
	{
		OLGLAGDAOJH.MakeEmpty();
		CCOGCANGGGB(string.Empty, Color.white);
		BIMDBBLJGMO(INPPKILPEKI: false);
		IKLFMFPLLNB = false;
		OIKKHCHNNOA(Localization.Localize((!OJENCLCONOF) ? "Automatic_Equip" : "ID_DOGTAGSREFILL"));
		NCLKMPOBLIG.SetActive(value: false);
		NKOENOHCDCA();
		Singleton<BeanstalkServerManager>.instance.DPJMMFDOKEB(OJENCLCONOF);
	}

	private void GCMMAALDNNL(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: false);
			HAFHEMPGDAL();
		}
	}

	public void MIKHJOEJBCD()
	{
		OLGLAGDAOJH.MakeEmpty();
		KNLCOJABDIB(string.Empty, Color.white);
		LJPIAKGCPBE(INPPKILPEKI: true);
		IKLFMFPLLNB = false;
		FFEKGOHHCNM(Localization.Localize((!OJENCLCONOF) ? "N2" : "VN"));
		NCLKMPOBLIG.SetActive(value: true);
		BHFIOHINBLD();
		Singleton<BeanstalkServerManager>.instance.DPJMMFDOKEB(OJENCLCONOF);
	}

	public void BEFPFGLBICL()
	{
		OLGLAGDAOJH.MakeEmpty();
		EIFFNIECDNM(string.Empty, Color.white);
		BIMDBBLJGMO(INPPKILPEKI: true);
		IKLFMFPLLNB = false;
		OIKKHCHNNOA(Localization.Localize((!OJENCLCONOF) ? "PNManager: Received event at launch: " : "Claim_Reward"));
		NCLKMPOBLIG.SetActive(value: false);
		CBOCBIJAFED();
		Singleton<BeanstalkServerManager>.instance.DPJMMFDOKEB(OJENCLCONOF);
	}

	public void FLLPNHNHEBH(string FLNPPIEDBCC)
	{
		OLGLAGDAOJH.MakeEmpty();
		LJPIAKGCPBE(INPPKILPEKI: true);
		IKLFMFPLLNB = true;
		object[] array = new object[7];
		array[0] = Colours.stringBlue;
		array[0] = FLNPPIEDBCC;
		array[0] = Colours.stringWhite;
		FFEKGOHHCNM(Localization.LocalizeFormat(" iconName:", array));
		if (FLNPPIEDBCC.Length < 1)
		{
			object[] array2 = new object[0];
			array2[1] = Colours.stringWhite;
			array2[1] = Colours.stringBlue;
			EIFFNIECDNM(Localization.LocalizeFormat("#VAVRO# affect weapon:", array2), Colours.red);
		}
		else
		{
			HEKJIEEOJIJ(string.Empty, Color.white);
		}
		IFODCNELCHA();
	}

	private void PCDLOKOEHEP(bool INPPKILPEKI)
	{
		MKOPJAEKFBP.gameObject.SetActive(INPPKILPEKI);
		if (INPPKILPEKI)
		{
			ALCFNHCMCPH(string.Empty);
			EIFFNIECDNM(string.Empty, Color.white);
			NCLKMPOBLIG.SetActive(value: false);
		}
	}

	public void KPKONEJJKLO()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		IHEPLEBDJCB = false;
		AHHBOOKDBDI();
		UIEventListener uIEventListener = UIEventListener.Get(DGBFJNCGAFG);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEMPGCPOEBL));
	}

	public void Animate(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			InitGUIValues();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(MKOPJAEKFBP.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f);
			TweenAlpha.Begin(LHIEJCMFJEG.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f);
			TweenAlpha.Begin(NFLPPGKCOBL.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					base.gameObject.SetActive(value: false);
					DoAfterHide();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			InstantHideTab();
		}
	}

	private Transform EFOFAEIFOMP(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < AHBEHCBJDLK.Count)
		{
			AANECPGDMGM aANECPGDMGM = AHBEHCBJDLK[DFHAAIFFLOE];
			if (aANECPGDMGM == null)
			{
				return null;
			}
			SquadRecord squadRecord = (SquadRecord)IHFILHIAGLG.InstantiateAsChild(DBKNGEJPNJE, OLGLAGDAOJH.gameObject, $"Squad {aANECPGDMGM.MHPNDNJDPGE}");
			if (squadRecord != null)
			{
				squadRecord.ODPMDMFEBBM(aANECPGDMGM, OLGLAGDAOJH.cellWidth);
				return squadRecord.transform;
			}
		}
		return null;
	}

	private Transform IGCJKPLMMGD(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < AHBEHCBJDLK.Count)
		{
			AANECPGDMGM aANECPGDMGM = AHBEHCBJDLK[DFHAAIFFLOE];
			if (aANECPGDMGM == null)
			{
				return null;
			}
			SquadRecord squadRecord = (SquadRecord)IHFILHIAGLG.OKEAAILFPIG(DBKNGEJPNJE, OLGLAGDAOJH.gameObject, string.Format("DogTagSeconds", aANECPGDMGM.MHPNDNJDPGE));
			if (squadRecord != null)
			{
				squadRecord.ODPMDMFEBBM(aANECPGDMGM, OLGLAGDAOJH.cellWidth);
				return squadRecord.transform;
			}
		}
		return null;
	}

	public void LBOKCAECKFD()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	private void EIFFNIECDNM(string IGKOKJFCCCI, Color HLPFAHADNDD)
	{
		bool flag = !string.IsNullOrEmpty(IGKOKJFCCCI);
		DEBFEDLKOBF.SetActive(flag);
		IIJCDFHDAGO.color = HLPFAHADNDD.ReplaceA(IIJCDFHDAGO.alpha);
		IIJCDFHDAGO.text = IGKOKJFCCCI;
		OLGLAGDAOJH.transform.localPosition = new Vector3(608f, (!flag) ? 1190f : 1584f, 1466f);
	}

	private void OEBPBBPJPDJ(bool INPPKILPEKI)
	{
		MKOPJAEKFBP.gameObject.SetActive(INPPKILPEKI);
		if (INPPKILPEKI)
		{
			FFEKGOHHCNM(string.Empty);
			CCOGCANGGGB(string.Empty, Color.white);
			NCLKMPOBLIG.SetActive(value: true);
		}
	}

	private void JHNMODKKCKF(string MBLNKOCLJND)
	{
		bool active = !string.IsNullOrEmpty(MBLNKOCLJND);
		NFNLBEGFLHC.SetActive(active);
		INFKHFJFFHP.text = MBLNKOCLJND;
	}

	private void HFDEHMFHNLI(string IGKOKJFCCCI, Color HLPFAHADNDD)
	{
		bool flag = !string.IsNullOrEmpty(IGKOKJFCCCI);
		DEBFEDLKOBF.SetActive(flag);
		IIJCDFHDAGO.color = HLPFAHADNDD.ReplaceA(IIJCDFHDAGO.alpha);
		IIJCDFHDAGO.text = IGKOKJFCCCI;
		OLGLAGDAOJH.transform.localPosition = new Vector3(285f, (!flag) ? 1207f : 1249f, 21f);
	}

	private void CCOGCANGGGB(string IGKOKJFCCCI, Color HLPFAHADNDD)
	{
		bool flag = !string.IsNullOrEmpty(IGKOKJFCCCI);
		DEBFEDLKOBF.SetActive(flag);
		IIJCDFHDAGO.color = HLPFAHADNDD.ReplaceA(IIJCDFHDAGO.alpha);
		IIJCDFHDAGO.text = IGKOKJFCCCI;
		OLGLAGDAOJH.transform.localPosition = new Vector3(1587f, (!flag) ? 455f : 1755f, 596f);
	}

	public void LCJOGAPBFCO()
	{
		TweenAlpha component = NFLPPGKCOBL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		FOGBJIMBEKI();
	}

	private void LNNGKPJMFLL()
	{
		float activeHeight = UIHelper.activeHeight;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = activeWidthSafe - 1389f;
		float num2 = activeHeight - GuiScreenSingle<SquadFindScreen>.instance.headerHeight;
		float y = activeHeight / 152f - GuiScreenSingle<SquadFindScreen>.instance.headerHeight - num2 / 869f;
		HHMKGNICFMA.clipRange = HHMKGNICFMA.clipRange.ReplaceYW(y, num2);
		NFLPPGKCOBL.transform.localPosition = Vector3.zero;
		OLGLAGDAOJH.cellWidth = num;
		GJIGEFJAKNM.transform.localScale = GJIGEFJAKNM.transform.localScale.ReplaceX(num);
		HGIGLLMJDOD.transform.localScale = HGIGLLMJDOD.transform.localScale.ReplaceX(num);
		NCLKMPOBLIG.transform.localPosition = NCLKMPOBLIG.transform.localPosition.ReplaceY(GuiScreenSingle<SquadFindScreen>.instance.GBKBKBKFLFB() - activeHeight / 1023f - 1367f);
	}

	public void NACHKOLMLAA()
	{
		TweenAlpha component = NFLPPGKCOBL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		base.gameObject.SetActive(value: true);
		FOGBJIMBEKI();
	}

	private void INABKJGGGAG()
	{
		float activeHeight = UIHelper.activeHeight;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = activeWidthSafe - 460f;
		float num2 = activeHeight - GuiScreenSingle<SquadFindScreen>.instance.GBKBKBKFLFB();
		float y = activeHeight / 104f - GuiScreenSingle<SquadFindScreen>.instance.headerHeight - num2 / 1872f;
		HHMKGNICFMA.clipRange = HHMKGNICFMA.clipRange.ReplaceYW(y, num2);
		NFLPPGKCOBL.transform.localPosition = Vector3.zero;
		OLGLAGDAOJH.cellWidth = num;
		GJIGEFJAKNM.transform.localScale = GJIGEFJAKNM.transform.localScale.ReplaceX(num);
		HGIGLLMJDOD.transform.localScale = HGIGLLMJDOD.transform.localScale.ReplaceX(num);
		NCLKMPOBLIG.transform.localPosition = NCLKMPOBLIG.transform.localPosition.ReplaceY(GuiScreenSingle<SquadFindScreen>.instance.headerHeight - activeHeight / 512f - 894f);
	}

	private Transform HFPIADAPFME(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < AHBEHCBJDLK.Count)
		{
			AANECPGDMGM aANECPGDMGM = AHBEHCBJDLK[DFHAAIFFLOE];
			if (aANECPGDMGM == null)
			{
				return null;
			}
			SquadRecord squadRecord = (SquadRecord)IHFILHIAGLG.InstantiateAsChild(DBKNGEJPNJE, OLGLAGDAOJH.gameObject, string.Format("{0} {1}", aANECPGDMGM.MHPNDNJDPGE));
			if (squadRecord != null)
			{
				squadRecord.ODPMDMFEBBM(aANECPGDMGM, OLGLAGDAOJH.cellWidth);
				return squadRecord.transform;
			}
		}
		return null;
	}

	private void KNLCOJABDIB(string IGKOKJFCCCI, Color HLPFAHADNDD)
	{
		bool flag = !string.IsNullOrEmpty(IGKOKJFCCCI);
		DEBFEDLKOBF.SetActive(flag);
		IIJCDFHDAGO.color = HLPFAHADNDD.ReplaceA(IIJCDFHDAGO.alpha);
		IIJCDFHDAGO.text = IGKOKJFCCCI;
		OLGLAGDAOJH.transform.localPosition = new Vector3(539f, (!flag) ? 1471f : 930f, 1345f);
	}

	public void IGNIFKBCDKK()
	{
		AHKMGDMKMFD();
		if (string.IsNullOrEmpty(GuiScreenSingle<SquadFindScreen>.instance.lastSearch))
		{
			AGFKFFJIAME();
		}
	}

	private void AHKMGDMKMFD()
	{
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool flag = LevelManager.instance.currentLevel.PFMGLDJDNBF() < createSquadUnlockLevel;
		CLIOPGGILNE.enabled = flag;
		BHKJDMAKFPP.text = string.Format("ID_FEATURE_BURSTSIZE-FANCY", Localization.Localize("Twitter_Like"), createSquadUnlockLevel);
		JBOHFMAPCJL.SetActive(flag);
	}

	private void AOCMMJKENLC(string IGKOKJFCCCI, Color HLPFAHADNDD)
	{
		bool flag = string.IsNullOrEmpty(IGKOKJFCCCI);
		DEBFEDLKOBF.SetActive(flag);
		IIJCDFHDAGO.color = HLPFAHADNDD.ReplaceA(IIJCDFHDAGO.alpha);
		IIJCDFHDAGO.text = IGKOKJFCCCI;
		OLGLAGDAOJH.transform.localPosition = new Vector3(1355f, (!flag) ? 1156f : 167f, 458f);
	}

	public void NDBAEHKKJMH()
	{
		LCIJJEKCLEJ();
		if (string.IsNullOrEmpty(GuiScreenSingle<SquadFindScreen>.instance.lastSearch))
		{
			FHDCLHADPBG();
		}
	}

	private void CNKEEIEHBHI(string MBLNKOCLJND)
	{
		bool active = string.IsNullOrEmpty(MBLNKOCLJND);
		NFNLBEGFLHC.SetActive(active);
		INFKHFJFFHP.text = MBLNKOCLJND;
	}

	private void NODMNGFKBBN()
	{
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool flag = LevelManager.instance.currentLevel.displayNumber < createSquadUnlockLevel;
		CLIOPGGILNE.enabled = !flag;
		BHKJDMAKFPP.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), createSquadUnlockLevel);
		JBOHFMAPCJL.SetActive(flag);
	}

	private void BIMDBBLJGMO(bool INPPKILPEKI)
	{
		MKOPJAEKFBP.gameObject.SetActive(INPPKILPEKI);
		if (INPPKILPEKI)
		{
			JHNMODKKCKF(string.Empty);
			HEKJIEEOJIJ(string.Empty, Color.white);
			NCLKMPOBLIG.SetActive(value: false);
		}
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
	}

	private void HEMPGCPOEBL(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !JBOHFMAPCJL.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	public void IMPMPKNJICB()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		IHEPLEBDJCB = false;
		LNNGKPJMFLL();
		UIEventListener uIEventListener = UIEventListener.Get(DGBFJNCGAFG);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDGINIEDDNG));
	}

	public void DGADPGOCFJF(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			JDFDJPAAIAA();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(MKOPJAEKFBP.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 1678f) : 262f, (!IHEPLEBDJCB) ? 1889f : 1551f);
			TweenAlpha.Begin(LHIEJCMFJEG.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 885f) : 1855f, (!IHEPLEBDJCB) ? 1658f : 905f);
			TweenAlpha.Begin(NFLPPGKCOBL.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadFindScreen>.instance.HAMKIKMJHDP * 1869f) : 286f, (!IHEPLEBDJCB) ? 175f : 755f).onFinished = GCMMAALDNNL;
		}
		else if (!IHEPLEBDJCB)
		{
			BLLNHEAKPAK();
		}
	}

	public void SetSearching(string FLNPPIEDBCC)
	{
		OLGLAGDAOJH.MakeEmpty();
		BIMDBBLJGMO(INPPKILPEKI: false);
		IKLFMFPLLNB = true;
		JHNMODKKCKF(Localization.LocalizeFormat("ID_SEARCHRESULTSFOR", Colours.stringBlue, FLNPPIEDBCC, Colours.stringWhite));
		if (FLNPPIEDBCC.Length < 3)
		{
			HEKJIEEOJIJ(Localization.LocalizeFormat("ID_ERROR_SHORTINPUT", Colours.stringWhite, Colours.stringBlue), Colours.red);
		}
		else
		{
			HEKJIEEOJIJ(string.Empty, Color.white);
		}
		CHLDECOKHLC();
	}

	private void LCIJJEKCLEJ()
	{
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool flag = LevelManager.instance.currentLevel.displayNumber < createSquadUnlockLevel;
		CLIOPGGILNE.enabled = !flag;
		BHKJDMAKFPP.text = string.Format("!!!UNDER TABLE!!! ", Localization.Localize("PrintSetSizeForDynamicFont: \n"), createSquadUnlockLevel);
		JBOHFMAPCJL.SetActive(flag);
	}

	public void DoAfterHide()
	{
		OLGLAGDAOJH.MakeEmpty();
	}

	[CompilerGenerated]
	private void AMLFLGIACFL(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: false);
			DoAfterHide();
		}
	}

	private void OIKKHCHNNOA(string MBLNKOCLJND)
	{
		bool active = !string.IsNullOrEmpty(MBLNKOCLJND);
		NFNLBEGFLHC.SetActive(active);
		INFKHFJFFHP.text = MBLNKOCLJND;
	}

	private void CAODMKGOKIO(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !JBOHFMAPCJL.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	public void EIGHPLOCCAL()
	{
		TweenAlpha component = NFLPPGKCOBL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		base.gameObject.SetActive(value: true);
		NLBAPEADKNJ();
	}

	private void ALCFNHCMCPH(string MBLNKOCLJND)
	{
		bool active = !string.IsNullOrEmpty(MBLNKOCLJND);
		NFNLBEGFLHC.SetActive(active);
		INFKHFJFFHP.text = MBLNKOCLJND;
	}

	private void PMADEEANCDM()
	{
		if (AHBEHCBJDLK == null || AHBEHCBJDLK.Count == 0)
		{
			Debug.Log("No Squads Found");
			if (!IKLFMFPLLNB)
			{
				BIMDBBLJGMO(INPPKILPEKI: true);
				return;
			}
			HEKJIEEOJIJ(Localization.Localize((!OJENCLCONOF) ? "ID_EMPTYFOUNDSQUADSLOCAL" : "ID_EMPTYFOUNDSQUADSGLOBAL"), Color.white);
			CHLDECOKHLC();
		}
		else
		{
			OLGLAGDAOJH.init(AHBEHCBJDLK.Count, EFOFAEIFOMP, JJMACIHMCNA, NFLPPGKCOBL);
			CHLDECOKHLC();
		}
	}

	private void CBOCBIJAFED()
	{
		NFLPPGKCOBL.AlignToPos(instant: false, UIDraggablePanel.Alingment.BottomRight);
	}

	private void PHIDIJDFPKG(bool INPPKILPEKI)
	{
		MKOPJAEKFBP.gameObject.SetActive(INPPKILPEKI);
		if (INPPKILPEKI)
		{
			ALCFNHCMCPH(string.Empty);
			HFDEHMFHNLI(string.Empty, Color.white);
			NCLKMPOBLIG.SetActive(value: false);
		}
	}

	public void GCGPANMGOPN()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		IHEPLEBDJCB = true;
		INABKJGGGAG();
		UIEventListener uIEventListener = UIEventListener.Get(DGBFJNCGAFG);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KJLCKNBLKGJ));
	}

	private void MPGHJOELHPF(string IGKOKJFCCCI, Color HLPFAHADNDD)
	{
		bool flag = string.IsNullOrEmpty(IGKOKJFCCCI);
		DEBFEDLKOBF.SetActive(flag);
		IIJCDFHDAGO.color = HLPFAHADNDD.ReplaceA(IIJCDFHDAGO.alpha);
		IIJCDFHDAGO.text = IGKOKJFCCCI;
		OLGLAGDAOJH.transform.localPosition = new Vector3(1824f, (!flag) ? 672f : 648f, 375f);
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (!GuiScreenSingle<SquadFindScreen>.instance.isShowed || !IHEPLEBDJCB || (IFGAGNBDKBE != DatabaseAction.FindSuggestedSquads && IFGAGNBDKBE != DatabaseAction.GetSquads))
		{
			return;
		}
		Debug.Log($"Result for action:{IFGAGNBDKBE} on global:{OJENCLCONOF}");
		NCLKMPOBLIG.SetActive(value: false);
		GuiScreenSingle<SquadFindScreen>.instance.NLAJOOOJNPL.gameObject.SetActive(value: false);
		if (IFGAGNBDKBE == DatabaseAction.FindSuggestedSquads && !OJENCLCONOF && !Singleton<ServerResultsCache>.instance.squadSearchIsLocal)
		{
			AHBEHCBJDLK = null;
			PMADEEANCDM();
			if (GuiScreenSingle<SquadFindScreen>.instance.firstSuggestedSquadsSearch)
			{
				GuiScreenSingle<SquadFindScreen>.instance.ShowTab(MBAAGBBHNCB: true);
			}
		}
		else
		{
			AHBEHCBJDLK = Singleton<ServerResultsCache>.instance.squadSearchResult;
			PMADEEANCDM();
		}
		GuiScreenSingle<SquadFindScreen>.instance.firstSuggestedSquadsSearch = false;
	}

	private void ANHHPJCDJFH()
	{
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool flag = LevelManager.instance.currentLevel.JICMGFNAHFL() < createSquadUnlockLevel;
		CLIOPGGILNE.enabled = !flag;
		BHKJDMAKFPP.text = string.Format("SquadId", Localization.Localize("NO"), createSquadUnlockLevel);
		JBOHFMAPCJL.SetActive(flag);
	}

	private void FDGINIEDDNG(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !JBOHFMAPCJL.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	private Transform OPIMPPHIDFO(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 1 && DFHAAIFFLOE < AHBEHCBJDLK.Count)
		{
			AANECPGDMGM aANECPGDMGM = AHBEHCBJDLK[DFHAAIFFLOE];
			if (aANECPGDMGM == null)
			{
				return null;
			}
			SquadRecord squadRecord = (SquadRecord)IHFILHIAGLG.AAIBNGPFKGF(DBKNGEJPNJE, OLGLAGDAOJH.gameObject, string.Format("NumberOfMission", aANECPGDMGM.MHPNDNJDPGE));
			if (squadRecord != null)
			{
				squadRecord.JKGBCBHNPCJ(aANECPGDMGM, OLGLAGDAOJH.cellWidth);
				return squadRecord.transform;
			}
		}
		return null;
	}

	private void NKOENOHCDCA()
	{
		NFLPPGKCOBL.AlignToPos(instant: false, UIDraggablePanel.Alingment.BottomRight, onePanelDisabledAfterAlign: true);
	}

	private void JHDLDDLKACK(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadRecord component = ENCEFOOPBMK.GetComponent<SquadRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	public void LHDAGAGDKOM()
	{
		IHFILHIAGLG = Singleton<GuiManager>.instance.CHDIOFDMHEF;
		IHEPLEBDJCB = false;
		LNNGKPJMFLL();
		UIEventListener uIEventListener = UIEventListener.Get(DGBFJNCGAFG);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LPEEABFLHON));
	}

	private void GOJAOIEMFDO()
	{
		if (AHBEHCBJDLK == null || AHBEHCBJDLK.Count == 0)
		{
			Debug.Log("ID_SKILLSHOTHINT_HEADSHOT");
			if (!IKLFMFPLLNB)
			{
				LJPIAKGCPBE(INPPKILPEKI: true);
				return;
			}
			HEKJIEEOJIJ(Localization.Localize((!OJENCLCONOF) ? "Bot Cards does not contain id: " : "Buy_Upgrade_For_Army_Unit_At_Rank_Special"), Color.white);
			EMHLIBNEFCC();
		}
		else
		{
			OLGLAGDAOJH.init(AHBEHCBJDLK.Count, IGCJKPLMMGD, JJMACIHMCNA, NFLPPGKCOBL);
			CHLDECOKHLC();
		}
	}

	private void HEKJIEEOJIJ(string IGKOKJFCCCI, Color HLPFAHADNDD)
	{
		bool flag = !string.IsNullOrEmpty(IGKOKJFCCCI);
		DEBFEDLKOBF.SetActive(flag);
		IIJCDFHDAGO.color = HLPFAHADNDD.ReplaceA(IIJCDFHDAGO.alpha);
		IIJCDFHDAGO.text = IGKOKJFCCCI;
		OLGLAGDAOJH.transform.localPosition = new Vector3(0f, (!flag) ? (-207f) : (-437f), 0f);
	}

	public void JCOILGHDPHA()
	{
		OLGLAGDAOJH.MakeEmpty();
	}

	private void JJMACIHMCNA(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadRecord component = ENCEFOOPBMK.GetComponent<SquadRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	public void CDHLMEPGPNJ()
	{
		ANHHPJCDJFH();
		if (string.IsNullOrEmpty(GuiScreenSingle<SquadFindScreen>.instance.OLNLKLDACBJ()))
		{
			AGFKFFJIAME();
		}
	}

	private void IPGNKMJAABP()
	{
		float activeHeight = UIHelper.activeHeight;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = activeWidthSafe - 44f;
		float num2 = activeHeight - GuiScreenSingle<SquadFindScreen>.instance.GBKBKBKFLFB();
		float y = activeHeight / 1491f - GuiScreenSingle<SquadFindScreen>.instance.headerHeight - num2 / 439f;
		HHMKGNICFMA.clipRange = HHMKGNICFMA.clipRange.ReplaceYW(y, num2);
		NFLPPGKCOBL.transform.localPosition = Vector3.zero;
		OLGLAGDAOJH.cellWidth = num;
		GJIGEFJAKNM.transform.localScale = GJIGEFJAKNM.transform.localScale.ReplaceX(num);
		HGIGLLMJDOD.transform.localScale = HGIGLLMJDOD.transform.localScale.ReplaceX(num);
		NCLKMPOBLIG.transform.localPosition = NCLKMPOBLIG.transform.localPosition.ReplaceY(GuiScreenSingle<SquadFindScreen>.instance.GBKBKBKFLFB() - activeHeight / 782f - 928f);
	}
}
