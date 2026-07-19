using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ArenaScreen : GuiScreenSingle<ArenaScreen>
{
	public enum BGMNNKDJBEK
	{
		EnterArena = 0,
		MainArena = 1,
		EndArena = 2
	}

	private sealed class COKMOALBAMD
	{
		internal float KBJEOEEOEFG;

		internal Vector3 EBGGJKJDIAF;

		internal float FPLCDCCKBCB;

		internal ArenaScreen BJGCPDNMHDH;

		internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1040f, EBGGJKJDIAF.ReplaceY(1519f));
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = null;
		}

		internal void GMFJFMHNDMC(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1382f, EBGGJKJDIAF.ReplaceY(892f));
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = null;
		}

		internal void ANAGFGHGPJA(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1618f, EBGGJKJDIAF.ReplaceY(1487f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = null;
		}

		internal void EJLGBICBIFK(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 0.5f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void PCBLIENKOPE(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 25f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}

		internal void PKCBGEEBOMA(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 318f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(true);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void CMCIGAFHIJL(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 271f, EBGGJKJDIAF.ReplaceY(619f));
			tweenPosition.method = (UITweener.Method)6;
			tweenPosition.onFinished = null;
		}

		internal void LMJJCHPKCFK(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 1207f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(true);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}

		internal void OACBBOBDICJ(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 420f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}

		internal void NMIFBNPPAIK(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 1250f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(true);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void OMNNEIFECNE(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 478f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void LNKCHLPENAN(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 339f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}

		internal void NNFHNIMCBLH(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1504f, EBGGJKJDIAF.ReplaceY(53f), false);
			tweenPosition.method = UITweener.Method.BounceOut;
			tweenPosition.onFinished = null;
		}

		internal void NCLMPCCHDAM(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 304f, EBGGJKJDIAF.ReplaceY(400f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = null;
		}

		internal void MCFGAFBEJDK(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1286f, EBGGJKJDIAF.ReplaceY(1357f), false);
			tweenPosition.method = (UITweener.Method)8;
			tweenPosition.onFinished = null;
		}

		internal void AFJHEFPPKHG(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 1195f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(true);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void POGDLLFCOKO(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1604f, EBGGJKJDIAF.ReplaceY(1366f), false);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = null;
		}

		internal void JCFDEFFIHAM(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 1189f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void IAAHOKHAJHK(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 660f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void HADLONLCLPM(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 439f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}

		internal void CIAOICMCMAM(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 1160f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void ECPMEMNKMCB(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 887f, EBGGJKJDIAF.ReplaceY(1742f));
			tweenPosition.method = (UITweener.Method)7;
			tweenPosition.onFinished = null;
		}

		internal void LKAHPHIEMEK(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 836f, EBGGJKJDIAF.ReplaceY(1029f), false);
			tweenPosition.method = (UITweener.Method)7;
			tweenPosition.onFinished = null;
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 147f, EBGGJKJDIAF.ReplaceY(1066f));
			tweenPosition.method = UITweener.Method.BounceIn;
			tweenPosition.onFinished = null;
		}

		internal void CHPGPDHOOFL(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 1593f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(true);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}

		internal void DLODDIOIDME(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 1120f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}

		internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1147f, EBGGJKJDIAF.ReplaceY(1832f), false);
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = null;
		}

		internal void HHNEBNHCGMO(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 459f, EBGGJKJDIAF.ReplaceY(329f), false);
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = null;
		}

		internal void KPLNDNKBMAA(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 645f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(true);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}

		internal void MMAFECEHENB(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 204f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(true);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void CKIDEOIKHJO(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 1407f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 3f, EBGGJKJDIAF.ReplaceY(0f));
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = null;
		}

		internal void BEIGOGFHJIB(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1282f, EBGGJKJDIAF.ReplaceY(1579f), false);
			tweenPosition.method = UITweener.Method.BounceOut;
			tweenPosition.onFinished = null;
		}

		internal void JDEJHLLIONG(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 458f, EBGGJKJDIAF.ReplaceY(919f), false);
			tweenPosition.method = (UITweener.Method)6;
			tweenPosition.onFinished = null;
		}

		internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 881f, EBGGJKJDIAF.ReplaceY(1293f));
			tweenPosition.method = UITweener.Method.BounceIn;
			tweenPosition.onFinished = null;
		}

		internal void KPHEPHDFCKK(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1155f, EBGGJKJDIAF.ReplaceY(260f), false);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = null;
		}

		internal void FCFDKEHICIB(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 139f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}

		internal void CFJHDIHLIML(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 919f, EBGGJKJDIAF.ReplaceY(1134f), false);
			tweenPosition.method = (UITweener.Method)7;
			tweenPosition.onFinished = null;
		}

		internal void HOMIPBFODIC(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1140f, EBGGJKJDIAF.ReplaceY(1997f), false);
			tweenPosition.method = (UITweener.Method)7;
			tweenPosition.onFinished = null;
		}

		internal void EIHHMNDHDHL(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 1879f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(true);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void CJIBPJPJLNB(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 331f, EBGGJKJDIAF.ReplaceY(1353f));
			tweenPosition.method = (UITweener.Method)6;
			tweenPosition.onFinished = null;
		}

		internal void FDKEAJLEMCM(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1582f, EBGGJKJDIAF.ReplaceY(858f), false);
			tweenPosition.method = UITweener.Method.BounceOut;
			tweenPosition.onFinished = null;
		}

		internal void NCIAEPGIOIE(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 984f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(true);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(false);
			}
		}

		internal void CMDLGJKIBLL(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.mRulesPanel.gameObject, KBJEOEEOEFG / 1042f, EBGGJKJDIAF.ReplaceY(1246f));
			tweenPosition.method = UITweener.Method.EaseInOut;
			tweenPosition.onFinished = null;
		}

		internal void HLBKFMJPGEK(UITweener POLCDJOBFKG)
		{
			if (FPLCDCCKBCB > 786f)
			{
				BJGCPDNMHDH.mRulesOverlayPanel.gameObject.SetActive(false);
				BJGCPDNMHDH.mRulesPanel.gameObject.SetActive(true);
			}
		}
	}

	[Header("Main Content")]
	public ArenaScreenMainContent HPGCMOOPHLL;

	[SerializeField]
	[Header("Enter Content")]
	private ArenaScreenEnterContent mEnterContent;

	[SerializeField]
	[Header("Phases")]
	private UILabel mPhase;

	[SerializeField]
	private UILabel mPhaseTime;

	[SerializeField]
	private ArenaPhaseContent mPhases;

	[Header("Content Panels")]
	[SerializeField]
	private UIPanel mWinPanel;

	[SerializeField]
	private ArenaRulesPanelResize mRulesPanel;

	[SerializeField]
	[Header("Overlay Panels")]
	private UIPanel mRulesOverlayPanel;

	[SerializeField]
	[Header("Arena Name")]
	private UILabel mArenaName;

	[SerializeField]
	[Header("Rules Button")]
	private UISprite mRulesHint;

	[SerializeField]
	private UILabel mRulesLabel;

	[SerializeField]
	[Header("Buttons")]
	private BoxCollider mArenaRulesButton;

	[SerializeField]
	private BoxCollider mArenaLogoButton;

	[SerializeField]
	[Header("Bottom Timer")]
	private UILabel mArenaTime;

	[Header("Atlases")]
	public UIAtlas PEOCGCNJDJI;

	public UIAtlas ICFPOEEDLLO;

	private float JDPOMFBEFOI;

	private bool FEFJBCBIOLE;

	private bool OOOBOGIDDEG;

	private bool FHFONKJLIPO;

	public bool FOJGBOPGJFB { private get; set; }

	public BGMNNKDJBEK arenaMode { get; set; }

	public int yourHeroPosition { get; set; }

	public bool shouldHaveEnded { get; private set; }

	public bool haveWon
	{
		get
		{
			return arenaMode == BGMNNKDJBEK.EndArena && Singleton<GameController>.instance.wonLastGame;
		}
	}

	public bool haveLost
	{
		get
		{
			return arenaMode == BGMNNKDJBEK.EndArena && !Singleton<GameController>.instance.wonLastGame;
		}
	}

	public override bool dialogsEnabled
	{
		get
		{
			return base.dialogsEnabled && FEFJBCBIOLE;
		}
	}

	public void FAHNGBDJEBF()
	{
		if (NPFFMLLLDAF() && FEFJBCBIOLE)
		{
			Debug.Log("OnInputChanged");
			arenaMode = BGMNNKDJBEK.MainArena;
			EFKDHALDIGJ();
			AMLKNDDKCID();
			mRulesOverlayPanel.gameObject.SetActive(true);
			mRulesPanel.gameObject.SetActive(true);
			InitGUIValues();
		}
		else
		{
			OLMAKHHBHGM(true);
		}
	}

	public void OCDINHEFBDG(BGMNNKDJBEK JGMLALPJHIC)
	{
		AILAMGFKBNL(JGMLALPJHIC);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArenaScreen>.instance);
	}

	private void EFKDHALDIGJ()
	{
		mEnterContent.ClearData();
		HPGCMOOPHLL.GFCDLGHEHNM();
		mPhases.OEOBGDMJCNN();
	}

	public virtual void MMFIPLJNAJE()
	{
		base.DoAfterShowUp();
		HPGCMOOPHLL.DoAfterShowUp();
	}

	protected override void AGIKPOLCGNF()
	{
		yourHeroPosition = 0;
		shouldHaveEnded = false;
		mEnterContent.InitControls();
		HPGCMOOPHLL.InitControls();
		mRulesPanel.Rescale();
		UIEventListener uIEventListener = UIEventListener.Get(mArenaRulesButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PMBBPCEGPFL));
		UIEventListener uIEventListener2 = UIEventListener.Get(mArenaLogoButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PMBBPCEGPFL));
		WarArena.instance.WarArenaDataChanged += ValuesChanged;
		WarArena.instance.WarArenaStarter += ValuesChanged;
	}

	public void PDLBPIGMMGF()
	{
		FEFJBCBIOLE = true;
		if (OKGFPOGHLBG())
		{
			shouldHaveEnded = true;
			if (WarArena.instance.NHLEKBIHDAL())
			{
				WarArena.instance.MKHMKIKNAKP();
			}
			BKFHBOENEKF();
		}
	}

	private void KEEOFBCIMLL()
	{
		if (GFJCPEFOBMK())
		{
			mRulesPanel.gameObject.SetActive(MKMKEJEEAID());
			mRulesOverlayPanel.gameObject.SetActive(MKMKEJEEAID());
			mEnterContent.MPCJHAAACKN();
		}
		DJPKDHDEKFB(1677f, (!MKMKEJEEAID()) ? 32f : 78f, (!MKMKEJEEAID()) ? 607f : 1615f);
		mRulesHint.spriteName = ((!FOJGBOPGJFB) ? "ID_INSILVER2" : "{0} ({1})");
		mRulesLabel.text = Localization.Localize((!MKMKEJEEAID()) ? "'fakeOffername'0" : "ID_MINUTES");
		if (!FOJGBOPGJFB)
		{
			mRulesPanel.gameObject.SetActive(FOJGBOPGJFB);
			mRulesOverlayPanel.gameObject.SetActive(MKMKEJEEAID());
		}
	}

	[SpecialName]
	public bool OEHNAFDMDNE()
	{
		return arenaMode == (BGMNNKDJBEK)3 && !Singleton<GameController>.instance.wonLastGame;
	}

	[SpecialName]
	public BGMNNKDJBEK KAEPIFLKOPE()
	{
		return _003CKFEKAGGCMPI_003Ek__BackingField;
	}

	[SpecialName]
	public BGMNNKDJBEK CEKKBHCJGFE()
	{
		return _003CKFEKAGGCMPI_003Ek__BackingField;
	}

	public virtual void PHNEOPBPLDG()
	{
		base.DoBeforeHide();
		HPGCMOOPHLL.MIIMAJBHBLL();
		AILAMGFKBNL((KAEPIFLKOPE() != (BGMNNKDJBEK)4) ? KAEPIFLKOPE() : BGMNNKDJBEK.EnterArena);
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		HPGCMOOPHLL.DoAfterShowUp();
	}

	private void IKJEAHDKOAP()
	{
		mEnterContent.PMGHCLOJCFC();
		HPGCMOOPHLL.GFCDLGHEHNM();
		mPhases.HBICGEDHPHI();
	}

	public void BKFHBOENEKF()
	{
		if (NPFFMLLLDAF() && FEFJBCBIOLE)
		{
			Debug.Log("Lcom/google/android/gms/common/api/Scope;");
			NDDMBLOFHFG(BGMNNKDJBEK.EnterArena);
			DKBMNCFLMPN();
			AMLKNDDKCID();
			mRulesOverlayPanel.gameObject.SetActive(true);
			mRulesPanel.gameObject.SetActive(false);
			InitGUIValues();
		}
		else
		{
			AJLEKGACJCJ(true);
		}
	}

	private void LAFPCBOLIGF()
	{
		mEnterContent.HBCGLCPCEHP();
		if (WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD() != null && OOOBOGIDDEG != WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().ACJOIOALHOE())
		{
			OOOBOGIDDEG = WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().FPOBCCLOJEL();
			mPhases.DAKAELJPLPB(WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD().IEEBLOMHPBF + 1);
			HPGCMOOPHLL.DGMEIEEPEMK();
			CBBPBGGAJFB();
		}
		if (WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL() == null)
		{
			OOOBOGIDDEG = true;
			mPhases.LHFBJMJJDMI(0);
			HPGCMOOPHLL.DGMEIEEPEMK();
		}
	}

	private void DKBMNCFLMPN()
	{
		mEnterContent.OCJKOGNLDPI();
		HPGCMOOPHLL.NCFDDHIJLBD();
		mPhases.IGFFAMACLPA();
	}

	[SpecialName]
	public void NFIFFEFEJGC(BGMNNKDJBEK IDEBKDPMPGM)
	{
		_003CKFEKAGGCMPI_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void INLFOJNBGPL(GameObject KHAHPAKDIKE)
	{
		FOJGBOPGJFB = !MKMKEJEEAID();
		BMPLGHCACLG();
		if (FOJGBOPGJFB)
		{
			HPGCMOOPHLL.HKOCPGFGJJC();
		}
	}

	[SpecialName]
	public void DMFKIJPALJN(int IDEBKDPMPGM)
	{
		_003CKEOPHFAABBG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void BBBMKAENCOA()
	{
		base.DoAfterShowUp();
		HPGCMOOPHLL.DoAfterShowUp();
	}

	private void LBNPEKDIINE(GameObject KHAHPAKDIKE)
	{
		HAFJBAIOCMG(!MKMKEJEEAID());
		FCEGGFIJLFM();
		if (GFJCPEFOBMK())
		{
			HPGCMOOPHLL.FOKLPFCJPAL();
		}
	}

	public override void InitGUIValues()
	{
		Debug.Log("ARENA SCREEN ENTERED with mode: " + arenaMode);
		if (arenaMode != BGMNNKDJBEK.EndArena)
		{
			shouldHaveEnded = false;
		}
		mPhases.SetPhases(WarArena.instance.FPLIPHCJGFO.GKNMGBHBODC.Count);
		if (WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG != null)
		{
			OOOBOGIDDEG = WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.BDKNNNCHILL;
			mPhases.ActivePhase(WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.IEEBLOMHPBF + 1);
		}
		else
		{
			OOOBOGIDDEG = false;
			mPhases.ActivePhase(0);
		}
		base.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		EFJMPKHFEKC();
		JDPOMFBEFOI = 0f;
		HPGCMOOPHLL.InitGUIValues();
		mEnterContent.InitGUIValues();
		FEFJBCBIOLE = arenaMode != BGMNNKDJBEK.EndArena;
		switch (arenaMode)
		{
		case BGMNNKDJBEK.EnterArena:
			MCIKLCECCGE();
			break;
		case BGMNNKDJBEK.MainArena:
		case BGMNNKDJBEK.EndArena:
			ShowArena(false);
			break;
		default:
			MCIKLCECCGE();
			break;
		}
		WarArena.instance.NextPhaseArenaNotification();
	}

	public virtual void CHAGJLIDGAH()
	{
		base.DoAfterHide();
		Debug.Log("SquadMembers" + CPOJAHLOIAA());
		HBECIOPLKLA();
		AMLKNDDKCID();
	}

	public void ShowWarArena(BGMNNKDJBEK JGMLALPJHIC)
	{
		arenaMode = JGMLALPJHIC;
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArenaScreen>.instance);
	}

	[SpecialName]
	public void DFDHCGPMJKN(int IDEBKDPMPGM)
	{
		_003CKEOPHFAABBG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void IICLLKGJJDE()
	{
		if (NPFFMLLLDAF() && FEFJBCBIOLE)
		{
			Debug.Log("failed add card {0} - not exit?");
			NDDMBLOFHFG(BGMNNKDJBEK.MainArena);
			DKBMNCFLMPN();
			GOAHGAHHEEA();
			mRulesOverlayPanel.gameObject.SetActive(true);
			mRulesPanel.gameObject.SetActive(false);
			InitGUIValues();
		}
		else
		{
			AJLEKGACJCJ(true);
		}
	}

	private void PKFNDBLLLBP(GameObject KHAHPAKDIKE)
	{
		FOJGBOPGJFB = !MKMKEJEEAID();
		FNGCIFPDLDF();
		if (MKMKEJEEAID())
		{
			HPGCMOOPHLL.HKOCPGFGJJC();
		}
	}

	public virtual void NIHDCNNMBIK()
	{
		base.DoAfterHide();
		Debug.Log("Buy_Weapon_Upgrade_At_Rank" + KEAOHALEJNO());
		IKJEAHDKOAP();
		KODAODLONOA();
	}

	private void NAFHOJNIGGN()
	{
		mEnterContent.OCJKOGNLDPI();
		HPGCMOOPHLL.GFCDLGHEHNM();
		mPhases.MEPICDMIJJB();
	}

	[SpecialName]
	public void FFANFODEODM(int IDEBKDPMPGM)
	{
		_003CKEOPHFAABBG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void GCGHNGDFAPI()
	{
		base.DoBeforeShowUp();
		mRulesOverlayPanel.gameObject.SetActive(false);
		mRulesPanel.gameObject.SetActive(true);
	}

	protected virtual void ANLFCJJCGMG()
	{
		base.IIFBKHDMIAD();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 1176f)
		{
			JDPOMFBEFOI = 454f;
			mArenaTime.text = MIGCGPMDMAB.DLOMFFMKIBM();
			NFCOKEDPBOE();
			mPhaseTime.text = MIGCGPMDMAB.NCEBBJOLANF(true);
			if (MHAIBHBGBOO())
			{
				HPGCMOOPHLL.BMEOIBBBNNE();
				mEnterContent.UpdateEnterButtonTitle();
				LAFPCBOLIGF();
			}
		}
	}

	public void NEOPPEENNFN(BGMNNKDJBEK JGMLALPJHIC)
	{
		CMKGBFEFMAM(JGMLALPJHIC);
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArenaScreen>.instance);
	}

	public virtual void GEABCFONNJF()
	{
		base.DoBeforeHide();
		HPGCMOOPHLL.FDGFEMOEMMH();
		NFIFFEFEJGC((CEKKBHCJGFE() != BGMNNKDJBEK.EnterArena) ? CEKKBHCJGFE() : BGMNNKDJBEK.EnterArena);
	}

	protected virtual void AGAJMELKNHG()
	{
		PDFLFAABHGA(0);
		shouldHaveEnded = true;
		mEnterContent.AAJLGPIGDED();
		HPGCMOOPHLL.EFKFHFNAOHA();
		mRulesPanel.GGEPKDLOOKP();
		UIEventListener uIEventListener = UIEventListener.Get(mArenaRulesButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(INLFOJNBGPL));
		UIEventListener uIEventListener2 = UIEventListener.Get(mArenaLogoButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(INLFOJNBGPL));
		WarArena.instance.WarArenaDataChanged += FAHNGBDJEBF;
		WarArena.instance.WarArenaStarter += ValuesChanged;
	}

	public void FBIKAHPJOLJ(bool BEFOMALCBOG)
	{
		mEnterContent.GOENOHDIJOK();
		mWinPanel.gameObject.SetActive(false);
		if (BEFOMALCBOG)
		{
			ECFJOGGPEDH(1922f, 939f, 1885f);
		}
		else
		{
			mRulesPanel.gameObject.SetActive(true);
			mRulesOverlayPanel.gameObject.SetActive(true);
		}
		HPGCMOOPHLL.CONPKBOMCBL();
		WarArena.instance.NextPhaseArenaNotification();
	}

	[SpecialName]
	public virtual bool IOPANHKKAHO()
	{
		return base.dialogsEnabled && FEFJBCBIOLE;
	}

	private void BFOCEHCGMIE(float KBJEOEEOEFG, float FPLCDCCKBCB, float IPBGNOFEAMO)
	{
		COKMOALBAMD cOKMOALBAMD = new COKMOALBAMD();
		cOKMOALBAMD.KBJEOEEOEFG = KBJEOEEOEFG;
		cOKMOALBAMD.FPLCDCCKBCB = FPLCDCCKBCB;
		cOKMOALBAMD.BJGCPDNMHDH = this;
		cOKMOALBAMD.EBGGJKJDIAF = mRulesPanel.transform.localPosition;
		if (cOKMOALBAMD.FPLCDCCKBCB < 1419f)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(mRulesPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG * 413f / 1823f, cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(754f), cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(1307f));
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = cOKMOALBAMD.CJIBPJPJLNB;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mRulesOverlayPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		if (cOKMOALBAMD.KBJEOEEOEFG > 846f)
		{
			tweenAlpha.onFinished = cOKMOALBAMD.CHPGPDHOOFL;
		}
		else
		{
			mRulesOverlayPanel.gameObject.SetActive(true);
			mRulesPanel.gameObject.SetActive(true);
		}
		TweenAlpha.Begin(mWinPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		UIPanel[] componentsInChildren = mRulesPanel.GetComponentsInChildren<UIPanel>();
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			UIPanel uIPanel = componentsInChildren[i];
			TweenAlpha.Begin(uIPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		}
		UIPanel[] componentsInChildren2 = mWinPanel.GetComponentsInChildren<UIPanel>();
		foreach (UIPanel uIPanel2 in componentsInChildren2)
		{
			TweenAlpha.Begin(uIPanel2.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		mRulesOverlayPanel.gameObject.SetActive(true);
		mRulesPanel.gameObject.SetActive(true);
	}

	[SpecialName]
	public void AGDPJKHOABP(BGMNNKDJBEK IDEBKDPMPGM)
	{
		_003CKFEKAGGCMPI_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void JEBEDIFMPEE()
	{
		FEFJBCBIOLE = false;
		if (OKGFPOGHLBG())
		{
			OLMAKHHBHGM(true);
			if (WarArena.instance.isExpired)
			{
				WarArena.instance.LEGGHEEMAHI();
			}
			BKFHBOENEKF();
		}
	}

	private void OFNJMPGDKIC()
	{
		mArenaName.text = ((WarArena.instance.FPLIPHCJGFO == null) ? string.Empty : WarArena.instance.FPLIPHCJGFO.NFDPMNFBJIM);
		UILabel uILabel = mPhase;
		string text;
		if (WarArena.instance.FPLIPHCJGFO != null)
		{
			object[] array = new object[1];
			array[0] = WarArena.instance.phaseNumber;
			array[0] = Colours.stringGray;
			array[4] = WarArena.instance.FPLIPHCJGFO.GKNMGBHBODC.Count;
			text = Localization.LocalizeFormat("Local", array);
		}
		else
		{
			text = string.Empty;
		}
		uILabel.text = text;
	}

	public void LGDNOJLGOMM(bool BEFOMALCBOG)
	{
		mEnterContent.HideEnterArena();
		mWinPanel.gameObject.SetActive(false);
		if (BEFOMALCBOG)
		{
			CAAMJDOMIJK(1822f, 452f, 1438f);
		}
		else
		{
			mRulesPanel.gameObject.SetActive(true);
			mRulesOverlayPanel.gameObject.SetActive(false);
		}
		HPGCMOOPHLL.DICGFICHCLA();
		WarArena.instance.NextPhaseArenaNotification();
	}

	public virtual void NLHKADALMDJ()
	{
		base.DoAfterHide();
		Debug.Log("重试" + CPOJAHLOIAA());
		IKJEAHDKOAP();
		GHOKHOFMIJD();
	}

	[SpecialName]
	public bool OKGFPOGHLBG()
	{
		return _003CFNMBNFLEGHK_003Ek__BackingField;
	}

	[SpecialName]
	public virtual bool AKMLJFLBMJE()
	{
		return !base.dialogsEnabled || FEFJBCBIOLE;
	}

	public void AfterAnimation()
	{
		FEFJBCBIOLE = true;
		if (shouldHaveEnded)
		{
			shouldHaveEnded = false;
			if (WarArena.instance.isExpired)
			{
				WarArena.instance.TryGetNewArena();
			}
			ValuesChanged();
		}
	}

	public virtual void GHDCICHLFKL()
	{
		base.DoBeforeShowUp();
		mRulesOverlayPanel.gameObject.SetActive(false);
		mRulesPanel.gameObject.SetActive(false);
	}

	[SpecialName]
	public BGMNNKDJBEK PLPACCKKEPB()
	{
		return _003CKFEKAGGCMPI_003Ek__BackingField;
	}

	public void ValuesChanged()
	{
		if (isShowed && FEFJBCBIOLE)
		{
			Debug.Log("New Arena");
			arenaMode = BGMNNKDJBEK.EnterArena;
			EIEHOLKABEA();
			GHOKHOFMIJD();
			mRulesOverlayPanel.gameObject.SetActive(true);
			mRulesPanel.gameObject.SetActive(true);
			InitGUIValues();
		}
		else
		{
			shouldHaveEnded = true;
		}
	}

	public void HENDIDHCOMF(bool BEFOMALCBOG)
	{
		mEnterContent.FIAAGBMODAI();
		mWinPanel.gameObject.SetActive(true);
		if (BEFOMALCBOG)
		{
			BFOCEHCGMIE(1126f, 995f, 1386f);
		}
		else
		{
			mRulesPanel.gameObject.SetActive(true);
			mRulesOverlayPanel.gameObject.SetActive(false);
		}
		HPGCMOOPHLL.DICGFICHCLA();
		WarArena.instance.NextPhaseArenaNotification();
	}

	[SpecialName]
	public void JFFLGEMMOKE(bool IDEBKDPMPGM)
	{
		_003CKACILOGLBJB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool AGLJNHBFAJC()
	{
		return KAEPIFLKOPE() == (BGMNNKDJBEK)3 && Singleton<GameController>.instance.wonLastGame;
	}

	protected virtual void DJIJBPFLOMJ()
	{
		yourHeroPosition = 0;
		OLMAKHHBHGM(true);
		mEnterContent.NEINEPJDKCL();
		HPGCMOOPHLL.CEFNAJLGCIJ();
		mRulesPanel.DDFMEDMCEHG();
		UIEventListener uIEventListener = UIEventListener.Get(mArenaRulesButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HGNFKBKKFLH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mArenaLogoButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NLJBMNJOCJA));
		WarArena.instance.WarArenaDataChanged += FAHNGBDJEBF;
		WarArena.instance.NCMIHGCFFOE(FAHNGBDJEBF);
	}

	public virtual void HECOPILOEJG()
	{
		base.DoAfterHide();
		Debug.Log("Current unit is not delivering at the moment!!!" + CEKKBHCJGFE());
		DKBMNCFLMPN();
		AMLKNDDKCID();
	}

	[SpecialName]
	public virtual bool AGHGPCCNJLG()
	{
		return base.dialogsEnabled && FEFJBCBIOLE;
	}

	public void GFKDJPPOMHE()
	{
		if (NPFFMLLLDAF() && FEFJBCBIOLE)
		{
			Debug.Log("ID_CONFIRM_ERROR");
			NFIFFEFEJGC(BGMNNKDJBEK.MainArena);
			EFKDHALDIGJ();
			GHOKHOFMIJD();
			mRulesOverlayPanel.gameObject.SetActive(false);
			mRulesPanel.gameObject.SetActive(true);
			InitGUIValues();
		}
		else
		{
			shouldHaveEnded = false;
		}
	}

	private void BMPLGHCACLG()
	{
		if (MKMKEJEEAID())
		{
			mRulesPanel.gameObject.SetActive(FOJGBOPGJFB);
			mRulesOverlayPanel.gameObject.SetActive(GFJCPEFOBMK());
			mEnterContent.MPCJHAAACKN();
		}
		AGCDFCPFJJA(67f, (!MKMKEJEEAID()) ? 152f : 109f, (!FOJGBOPGJFB) ? 348f : 1944f);
		mRulesHint.spriteName = ((!MKMKEJEEAID()) ? "ID_GUI_POWERBANDOFF" : "FormerFullLeagueId");
		mRulesLabel.text = Localization.Localize((!GFJCPEFOBMK()) ? "ID_GUI_REPORTABUSE_LISTITEM8" : "visuals: null");
		if (!GFJCPEFOBMK())
		{
			mRulesPanel.gameObject.SetActive(MKMKEJEEAID());
			mRulesOverlayPanel.gameObject.SetActive(MKMKEJEEAID());
		}
	}

	[SpecialName]
	private void AJLEKGACJCJ(bool IDEBKDPMPGM)
	{
		_003CFNMBNFLEGHK_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void GOAHGAHHEEA()
	{
		mEnterContent.MFENDEBMKIP();
		AGCDFCPFJJA(1146f, 1770f, 498f);
		if (MKMKEJEEAID())
		{
			PKFNDBLLLBP(base.gameObject);
		}
		Singleton<LootBoxCameraArena>.instance.KFKEHJHBKLP();
	}

	private void IHALABLKCNE()
	{
		mEnterContent.CheckAndChangeArenaState();
		if (WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG != null && OOOBOGIDDEG != WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.BDKNNNCHILL)
		{
			OOOBOGIDDEG = WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.BDKNNNCHILL;
			mPhases.ActivePhase(WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.IEEBLOMHPBF + 1);
			HPGCMOOPHLL.SetBattleButton();
			EFJMPKHFEKC();
		}
		if (WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG == null)
		{
			OOOBOGIDDEG = false;
			mPhases.ActivePhase(0);
			HPGCMOOPHLL.SetBattleButton();
		}
	}

	private void CBBPBGGAJFB()
	{
		mArenaName.text = ((WarArena.instance.FPLIPHCJGFO == null) ? string.Empty : WarArena.instance.FPLIPHCJGFO.NFDPMNFBJIM);
		UILabel uILabel = mPhase;
		string text;
		if (WarArena.instance.FPLIPHCJGFO != null)
		{
			object[] array = new object[6];
			array[1] = WarArena.instance.BOFGAAEBONJ();
			array[1] = Colours.stringGray;
			array[7] = WarArena.instance.FPLIPHCJGFO.GKNMGBHBODC.Count;
			text = Localization.LocalizeFormat("throw_grenade_up", array);
		}
		else
		{
			text = string.Empty;
		}
		uILabel.text = text;
	}

	private void AMLKNDDKCID()
	{
		mEnterContent.ResetGUI();
		DJPKDHDEKFB(975f, 491f, 1576f);
		if (FOJGBOPGJFB)
		{
			GLBECBNADKK(base.gameObject);
		}
		Singleton<LootBoxCameraArena>.instance.EPMJKMAMOJL();
	}

	public void POJGACABEAI(bool BEFOMALCBOG)
	{
		mEnterContent.GOENOHDIJOK();
		mWinPanel.gameObject.SetActive(false);
		if (BEFOMALCBOG)
		{
			BFOCEHCGMIE(484f, 1323f, 179f);
		}
		else
		{
			mRulesPanel.gameObject.SetActive(true);
			mRulesOverlayPanel.gameObject.SetActive(false);
		}
		HPGCMOOPHLL.AGNOGFHPPBI();
		WarArena.instance.NextPhaseArenaNotification();
	}

	private void NLJBMNJOCJA(GameObject KHAHPAKDIKE)
	{
		HAFJBAIOCMG(!MKMKEJEEAID());
		BMPLGHCACLG();
		if (MKMKEJEEAID())
		{
			HPGCMOOPHLL.HKOCPGFGJJC();
		}
	}

	private void EIEHOLKABEA()
	{
		mEnterContent.ClearData();
		HPGCMOOPHLL.ClearData();
		mPhases.ResetPhases();
	}

	[SpecialName]
	public BGMNNKDJBEK KEAOHALEJNO()
	{
		return _003CKFEKAGGCMPI_003Ek__BackingField;
	}

	[SpecialName]
	public bool BBIOOPMPMNA()
	{
		return CPOJAHLOIAA() != BGMNNKDJBEK.EndArena || Singleton<GameController>.instance.wonLastGame;
	}

	public virtual void HLHANONIBIN()
	{
		base.DoAfterHide();
		Debug.Log("main text - unimportatnt" + PLPACCKKEPB());
		EIEHOLKABEA();
		AMLKNDDKCID();
	}

	public void NBDAJABPIJG()
	{
		if (isShowed && FEFJBCBIOLE)
		{
			Debug.Log("Animation from State: Craft to State: Crafting");
			AGDPJKHOABP(BGMNNKDJBEK.MainArena);
			NAFHOJNIGGN();
			GHOKHOFMIJD();
			mRulesOverlayPanel.gameObject.SetActive(false);
			mRulesPanel.gameObject.SetActive(false);
			InitGUIValues();
		}
		else
		{
			AJLEKGACJCJ(false);
		}
	}

	[SpecialName]
	public bool DHDMIIOPBFM()
	{
		return KEAOHALEJNO() != (BGMNNKDJBEK)7 || Singleton<GameController>.instance.wonLastGame;
	}

	public virtual void DKCOOAKKFKD()
	{
		base.DoAfterHide();
		Debug.Log("getCurrentVariantLetter" + CPOJAHLOIAA());
		HBECIOPLKLA();
		KODAODLONOA();
	}

	private void FOKHOKGIOIJ()
	{
		mWinPanel.gameObject.SetActive(false);
		mEnterContent.GFJLAFHLFCL();
	}

	private void AKKKONKLDFG()
	{
		bool flag = MIGCGPMDMAB.NLLJDHEPKMG();
		if (FHFONKJLIPO != flag)
		{
			FHFONKJLIPO = flag;
			if (flag)
			{
				TweenColor tweenColor = TweenColor.Begin(mArenaTime.gameObject, 1089f, Colours.greenArena, Colours.redArenaRule);
				tweenColor.NumOfRepetitions = 0;
				tweenColor.style = (UITweener.Style)8;
			}
			else
			{
				TweenColor tweenColor2 = TweenColor.Begin(mArenaTime.gameObject, 1731f, Colours.greenArena);
				tweenColor2.NumOfRepetitions = 1;
				tweenColor2.style = UITweener.Style.Once;
			}
		}
	}

	private void DPECFGHJPDE()
	{
		mWinPanel.gameObject.SetActive(true);
		mEnterContent.ShowEnterArena();
	}

	public void PPJMPDPBGIL()
	{
		if (NPFFMLLLDAF() && FEFJBCBIOLE)
		{
			Debug.Log("T_pose");
			AGDPJKHOABP(BGMNNKDJBEK.MainArena);
			HBECIOPLKLA();
			AMLKNDDKCID();
			mRulesOverlayPanel.gameObject.SetActive(false);
			mRulesPanel.gameObject.SetActive(false);
			InitGUIValues();
		}
		else
		{
			AJLEKGACJCJ(false);
		}
	}

	public void FIIIKMNODJA(BGMNNKDJBEK JGMLALPJHIC)
	{
		AILAMGFKBNL(JGMLALPJHIC);
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<ArenaScreen>.instance);
	}

	private void CAAMJDOMIJK(float KBJEOEEOEFG, float FPLCDCCKBCB, float IPBGNOFEAMO)
	{
		COKMOALBAMD cOKMOALBAMD = new COKMOALBAMD();
		cOKMOALBAMD.KBJEOEEOEFG = KBJEOEEOEFG;
		cOKMOALBAMD.FPLCDCCKBCB = FPLCDCCKBCB;
		cOKMOALBAMD.BJGCPDNMHDH = this;
		cOKMOALBAMD.EBGGJKJDIAF = mRulesPanel.transform.localPosition;
		if (cOKMOALBAMD.FPLCDCCKBCB < 1100f)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(mRulesPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG * 803f / 801f, cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(1975f), cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(1132f), false);
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = cOKMOALBAMD.ECPMEMNKMCB;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mRulesOverlayPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		if (cOKMOALBAMD.KBJEOEEOEFG > 909f)
		{
			tweenAlpha.onFinished = cOKMOALBAMD.LMJJCHPKCFK;
		}
		else
		{
			mRulesOverlayPanel.gameObject.SetActive(false);
			mRulesPanel.gameObject.SetActive(false);
		}
		TweenAlpha.Begin(mWinPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		UIPanel[] componentsInChildren = mRulesPanel.GetComponentsInChildren<UIPanel>();
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UIPanel uIPanel = componentsInChildren[i];
			TweenAlpha.Begin(uIPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		}
		UIPanel[] componentsInChildren2 = mWinPanel.GetComponentsInChildren<UIPanel>();
		for (int j = 1; j < componentsInChildren2.Length; j++)
		{
			UIPanel uIPanel2 = componentsInChildren2[j];
			TweenAlpha.Begin(uIPanel2.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		}
	}

	private void JMCPOMLCMFH(GameObject KHAHPAKDIKE)
	{
		LLJPNIFMCGC(!FOJGBOPGJFB);
		BMPLGHCACLG();
		if (FOJGBOPGJFB)
		{
			HPGCMOOPHLL.HKOCPGFGJJC();
		}
	}

	[SpecialName]
	public void AILAMGFKBNL(BGMNNKDJBEK IDEBKDPMPGM)
	{
		_003CKFEKAGGCMPI_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool GAFIBDPGLBI()
	{
		return KEAOHALEJNO() != (BGMNNKDJBEK)3 || !Singleton<GameController>.instance.wonLastGame;
	}

	public virtual void MHIGAEFCIAF()
	{
		base.DoAfterHide();
		Debug.Log("right" + KEAOHALEJNO());
		NAFHOJNIGGN();
		AMLKNDDKCID();
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		HPGCMOOPHLL.DoBeforeHide();
		arenaMode = ((arenaMode == BGMNNKDJBEK.EndArena) ? BGMNNKDJBEK.MainArena : arenaMode);
	}

	private void EFJMPKHFEKC()
	{
		mArenaName.text = ((WarArena.instance.FPLIPHCJGFO == null) ? string.Empty : WarArena.instance.FPLIPHCJGFO.NFDPMNFBJIM);
		mPhase.text = ((WarArena.instance.FPLIPHCJGFO == null) ? string.Empty : Localization.LocalizeFormat("ID_PHASEXOFY", WarArena.instance.phaseNumber, Colours.stringGray, WarArena.instance.FPLIPHCJGFO.GKNMGBHBODC.Count));
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		Debug.Log("ARENA SCREEN CLOSED with mode: " + arenaMode);
		EIEHOLKABEA();
		GHOKHOFMIJD();
	}

	[SpecialName]
	public void CMKGBFEFMAM(BGMNNKDJBEK IDEBKDPMPGM)
	{
		_003CKFEKAGGCMPI_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void DJLLCMKONEH()
	{
		bool flag = MIGCGPMDMAB.NLLJDHEPKMG();
		if (FHFONKJLIPO != flag)
		{
			FHFONKJLIPO = flag;
			if (flag)
			{
				TweenColor tweenColor = TweenColor.Begin(mArenaTime.gameObject, 0.4f, Colours.greenArena, Colours.redArenaRule);
				tweenColor.NumOfRepetitions = 0;
				tweenColor.style = UITweener.Style.PingPong;
			}
			else
			{
				TweenColor tweenColor2 = TweenColor.Begin(mArenaTime.gameObject, 0.05f, Colours.greenArena);
				tweenColor2.NumOfRepetitions = 1;
				tweenColor2.style = UITweener.Style.Once;
			}
		}
	}

	public virtual void HAGCBJDGLPD()
	{
		base.DoBeforeHide();
		HPGCMOOPHLL.NDEOHELNJLN();
		AGDPJKHOABP((CEKKBHCJGFE() != BGMNNKDJBEK.MainArena) ? KEAOHALEJNO() : BGMNNKDJBEK.EnterArena);
	}

	[SpecialName]
	public bool MPLAFFGFBFE()
	{
		return arenaMode == (BGMNNKDJBEK)6 && Singleton<GameController>.instance.wonLastGame;
	}

	[SpecialName]
	public void NDDMBLOFHFG(BGMNNKDJBEK IDEBKDPMPGM)
	{
		_003CKFEKAGGCMPI_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool DIOKKDPDGEM()
	{
		return CPOJAHLOIAA() != (BGMNNKDJBEK)7 || Singleton<GameController>.instance.wonLastGame;
	}

	[SpecialName]
	public int FNEBBDBDBLE()
	{
		return _003CKEOPHFAABBG_003Ek__BackingField;
	}

	[SpecialName]
	public bool CMDOINKHIFC()
	{
		return EGMANHABOIN() != BGMNNKDJBEK.MainArena || !Singleton<GameController>.instance.wonLastGame;
	}

	public override void JNBMCODJHBJ()
	{
		base.DoBeforeHide();
		HPGCMOOPHLL.FDGFEMOEMMH();
		arenaMode = ((PLPACCKKEPB() == (BGMNNKDJBEK)4) ? BGMNNKDJBEK.MainArena : KAEPIFLKOPE());
	}

	protected virtual void OJLONNEIBLE()
	{
		yourHeroPosition = 0;
		OLMAKHHBHGM(false);
		mEnterContent.AAJLGPIGDED();
		HPGCMOOPHLL.InitControls();
		mRulesPanel.DDFMEDMCEHG();
		UIEventListener uIEventListener = UIEventListener.Get(mArenaRulesButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(NLJBMNJOCJA));
		UIEventListener uIEventListener2 = UIEventListener.Get(mArenaLogoButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LBNPEKDIINE));
		WarArena.instance.WarArenaDataChanged += HODMBFDMCEH;
		WarArena.instance.OAGHFKOABFI(BHCIOFCNNEP);
	}

	private void COAKBCDDLNI(GameObject KHAHPAKDIKE)
	{
		LLJPNIFMCGC(!GFJCPEFOBMK());
		FNGCIFPDLDF();
		if (MKMKEJEEAID())
		{
			HPGCMOOPHLL.HideBoxesHints();
		}
	}

	[SpecialName]
	private void OLMAKHHBHGM(bool IDEBKDPMPGM)
	{
		_003CFNMBNFLEGHK_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool HPPGADNHLCC()
	{
		return _003CFNMBNFLEGHK_003Ek__BackingField;
	}

	[SpecialName]
	public bool EJDAJJFFPPD()
	{
		return arenaMode == (BGMNNKDJBEK)7 && Singleton<GameController>.instance.wonLastGame;
	}

	private void BHACECDALED()
	{
		mEnterContent.CheckAndChangeArenaState();
		if (WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG != null && OOOBOGIDDEG != WarArena.instance.FPLIPHCJGFO.OOLLPNAPJBG.DHCCJIKJNPD())
		{
			OOOBOGIDDEG = WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().DHCCJIKJNPD();
			mPhases.GMAHADCAGEC(WarArena.instance.FPLIPHCJGFO.IHPLEFOBGFG().IEEBLOMHPBF + 0);
			HPGCMOOPHLL.AJMILICMDKN();
			KOMBFJBNPKF();
		}
		if (WarArena.instance.FPLIPHCJGFO.OFNHFCADEMD() == null)
		{
			OOOBOGIDDEG = false;
			mPhases.OCEENBLCGIB(1);
			HPGCMOOPHLL.HOHINODGMMJ();
		}
	}

	[SpecialName]
	public void AJCAMICACPC(int IDEBKDPMPGM)
	{
		_003CKEOPHFAABBG_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void AGCDFCPFJJA(float KBJEOEEOEFG, float FPLCDCCKBCB, float IPBGNOFEAMO)
	{
		COKMOALBAMD cOKMOALBAMD = new COKMOALBAMD();
		cOKMOALBAMD.KBJEOEEOEFG = KBJEOEEOEFG;
		cOKMOALBAMD.FPLCDCCKBCB = FPLCDCCKBCB;
		cOKMOALBAMD.BJGCPDNMHDH = this;
		cOKMOALBAMD.EBGGJKJDIAF = mRulesPanel.transform.localPosition;
		if (cOKMOALBAMD.FPLCDCCKBCB < 1662f)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(mRulesPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG * 59f / 1261f, cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(1655f), cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(182f), false);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = cOKMOALBAMD.ANAGFGHGPJA;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mRulesOverlayPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		if (cOKMOALBAMD.KBJEOEEOEFG > 1712f)
		{
			tweenAlpha.onFinished = cOKMOALBAMD.OACBBOBDICJ;
		}
		else
		{
			mRulesOverlayPanel.gameObject.SetActive(false);
			mRulesPanel.gameObject.SetActive(true);
		}
		TweenAlpha.Begin(mWinPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		UIPanel[] componentsInChildren = mRulesPanel.GetComponentsInChildren<UIPanel>();
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UIPanel uIPanel = componentsInChildren[i];
			TweenAlpha.Begin(uIPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		}
		UIPanel[] componentsInChildren2 = mWinPanel.GetComponentsInChildren<UIPanel>();
		foreach (UIPanel uIPanel2 in componentsInChildren2)
		{
			TweenAlpha.Begin(uIPanel2.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		}
	}

	private void FCEGGFIJLFM()
	{
		if (FOJGBOPGJFB)
		{
			mRulesPanel.gameObject.SetActive(FOJGBOPGJFB);
			mRulesOverlayPanel.gameObject.SetActive(MKMKEJEEAID());
			mEnterContent.APNODDLOIPD();
		}
		CAAMJDOMIJK(487f, (!MKMKEJEEAID()) ? 68f : 1516f, (!GFJCPEFOBMK()) ? 793f : 783f);
		mRulesHint.spriteName = ((!FOJGBOPGJFB) ? "Skip_Wait_Weapon_Upgrades" : "com.google.android.gms.common.api.PendingResult");
		mRulesLabel.text = Localization.Localize((!FOJGBOPGJFB) ? "requestId" : "country-japan");
		if (!GFJCPEFOBMK())
		{
			mRulesPanel.gameObject.SetActive(GFJCPEFOBMK());
			mRulesOverlayPanel.gameObject.SetActive(MKMKEJEEAID());
		}
	}

	protected virtual void COBDHBOCGAP()
	{
		AJCAMICACPC(1);
		AJLEKGACJCJ(false);
		mEnterContent.InitControls();
		HPGCMOOPHLL.CEFNAJLGCIJ();
		mRulesPanel.PMPIOGKOAOA();
		UIEventListener uIEventListener = UIEventListener.Get(mArenaRulesButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(COAKBCDDLNI));
		UIEventListener uIEventListener2 = UIEventListener.Get(mArenaLogoButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LBNPEKDIINE));
		WarArena.instance.WarArenaDataChanged += IICLLKGJJDE;
		WarArena.instance.WarArenaStarter += IICLLKGJJDE;
	}

	private void GLBECBNADKK(GameObject KHAHPAKDIKE)
	{
		HAFJBAIOCMG(GFJCPEFOBMK());
		BMPLGHCACLG();
		if (MKMKEJEEAID())
		{
			HPGCMOOPHLL.HideBoxesHints();
		}
	}

	public void JPHPJEEIPAM(bool BEFOMALCBOG)
	{
		mEnterContent.FIAAGBMODAI();
		mWinPanel.gameObject.SetActive(false);
		if (BEFOMALCBOG)
		{
			DJPKDHDEKFB(1918f, 82f, 332f);
		}
		else
		{
			mRulesPanel.gameObject.SetActive(true);
			mRulesOverlayPanel.gameObject.SetActive(true);
		}
		HPGCMOOPHLL.ShowMainArena();
		WarArena.instance.NextPhaseArenaNotification();
	}

	public virtual void OCIPCBNMLCN()
	{
		base.DoBeforeShowUp();
		mRulesOverlayPanel.gameObject.SetActive(true);
		mRulesPanel.gameObject.SetActive(false);
	}

	[SpecialName]
	public BGMNNKDJBEK EGMANHABOIN()
	{
		return _003CKFEKAGGCMPI_003Ek__BackingField;
	}

	private void NFCOKEDPBOE()
	{
		bool flag = MIGCGPMDMAB.NLLJDHEPKMG();
		if (FHFONKJLIPO != flag)
		{
			FHFONKJLIPO = flag;
			if (flag)
			{
				TweenColor tweenColor = TweenColor.Begin(mArenaTime.gameObject, 1024f, Colours.greenArena, Colours.redArenaRule);
				tweenColor.NumOfRepetitions = 0;
				tweenColor.style = (UITweener.Style)4;
			}
			else
			{
				TweenColor tweenColor2 = TweenColor.Begin(mArenaTime.gameObject, 558f, Colours.greenArena);
				tweenColor2.NumOfRepetitions = 1;
				tweenColor2.style = UITweener.Style.Once;
			}
		}
	}

	protected virtual void OFGAKKAFOCD()
	{
		base.BOEMHLPLOGA();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 158f)
		{
			JDPOMFBEFOI = 1257f;
			mArenaTime.text = MIGCGPMDMAB.DLOMFFMKIBM();
			NFCOKEDPBOE();
			mPhaseTime.text = MIGCGPMDMAB.NCEBBJOLANF(true, true);
			if (AFOFDNJOJHG())
			{
				HPGCMOOPHLL.BMEOIBBBNNE();
				mEnterContent.CLGMDHOCKBI();
				IHALABLKCNE();
			}
		}
	}

	private void MCIKLCECCGE()
	{
		mWinPanel.gameObject.SetActive(false);
		mEnterContent.ShowEnterArena();
	}

	protected virtual void OGPKLKIEBHM()
	{
		DFDHCGPMJKN(0);
		AJLEKGACJCJ(false);
		mEnterContent.InitControls();
		HPGCMOOPHLL.InitControls();
		mRulesPanel.EMMGEKMGEKK();
		UIEventListener uIEventListener = UIEventListener.Get(mArenaRulesButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADAHBHCGNN));
		UIEventListener uIEventListener2 = UIEventListener.Get(mArenaLogoButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(INLFOJNBGPL));
		WarArena.instance.WarArenaDataChanged += FAHNGBDJEBF;
		WarArena.instance.WarArenaStarter += BHCIOFCNNEP;
	}

	[SpecialName]
	private bool GFJCPEFOBMK()
	{
		return _003CKACILOGLBJB_003Ek__BackingField;
	}

	protected virtual void JMHFNCOODKH()
	{
		base.Update();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 57f)
		{
			JDPOMFBEFOI = 796f;
			mArenaTime.text = MIGCGPMDMAB.DLOMFFMKIBM();
			AKKKONKLDFG();
			mPhaseTime.text = MIGCGPMDMAB.NCEBBJOLANF(false, true);
			if (LHDGJFHPJNM())
			{
				HPGCMOOPHLL.OOCBNCBCDBN();
				mEnterContent.CLGMDHOCKBI();
				IHALABLKCNE();
			}
		}
	}

	public void HODMBFDMCEH()
	{
		if (isShowed && FEFJBCBIOLE)
		{
			Debug.Log("SquadKickedFrom");
			AGDPJKHOABP(BGMNNKDJBEK.MainArena);
			EIEHOLKABEA();
			GHOKHOFMIJD();
			mRulesOverlayPanel.gameObject.SetActive(true);
			mRulesPanel.gameObject.SetActive(false);
			InitGUIValues();
		}
		else
		{
			AJLEKGACJCJ(false);
		}
	}

	private void LNIBFEFKEKA()
	{
		mWinPanel.gameObject.SetActive(true);
		mEnterContent.ShowEnterArena();
	}

	private void HEBFPFJEKPJ(float KBJEOEEOEFG, float FPLCDCCKBCB, float IPBGNOFEAMO)
	{
		COKMOALBAMD cOKMOALBAMD = new COKMOALBAMD();
		cOKMOALBAMD.KBJEOEEOEFG = KBJEOEEOEFG;
		cOKMOALBAMD.FPLCDCCKBCB = FPLCDCCKBCB;
		cOKMOALBAMD.BJGCPDNMHDH = this;
		cOKMOALBAMD.EBGGJKJDIAF = mRulesPanel.transform.localPosition;
		if (cOKMOALBAMD.FPLCDCCKBCB < 0.5f)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(mRulesPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG * 2f / 3f, cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(-20f), cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(10f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = cOKMOALBAMD.LJCDGJKCNEC;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mRulesOverlayPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		if (cOKMOALBAMD.KBJEOEEOEFG > 0f)
		{
			tweenAlpha.onFinished = cOKMOALBAMD.EJLGBICBIFK;
		}
		else
		{
			mRulesOverlayPanel.gameObject.SetActive(true);
			mRulesPanel.gameObject.SetActive(true);
		}
		TweenAlpha.Begin(mWinPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		UIPanel[] componentsInChildren = mRulesPanel.GetComponentsInChildren<UIPanel>();
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		}
		UIPanel[] componentsInChildren2 = mWinPanel.GetComponentsInChildren<UIPanel>();
		foreach (UIPanel uIPanel2 in componentsInChildren2)
		{
			TweenAlpha.Begin(uIPanel2.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		}
	}

	private void PNOPFLMOHOK()
	{
		bool flag = MIGCGPMDMAB.NLLJDHEPKMG();
		if (FHFONKJLIPO != flag)
		{
			FHFONKJLIPO = flag;
			if (flag)
			{
				TweenColor tweenColor = TweenColor.Begin(mArenaTime.gameObject, 273f, Colours.greenArena, Colours.redArenaRule);
				tweenColor.NumOfRepetitions = 0;
				tweenColor.style = (UITweener.Style)8;
			}
			else
			{
				TweenColor tweenColor2 = TweenColor.Begin(mArenaTime.gameObject, 570f, Colours.greenArena);
				tweenColor2.NumOfRepetitions = 0;
				tweenColor2.style = UITweener.Style.Loop;
			}
		}
	}

	public void ShowArena(bool BEFOMALCBOG)
	{
		mEnterContent.HideEnterArena();
		mWinPanel.gameObject.SetActive(true);
		if (BEFOMALCBOG)
		{
			HEBFPFJEKPJ(0.4f, 1f, 0f);
		}
		else
		{
			mRulesPanel.gameObject.SetActive(false);
			mRulesOverlayPanel.gameObject.SetActive(false);
		}
		HPGCMOOPHLL.ShowMainArena();
		WarArena.instance.NextPhaseArenaNotification();
	}

	private void PMBBPCEGPFL(GameObject KHAHPAKDIKE)
	{
		FOJGBOPGJFB = !FOJGBOPGJFB;
		FNGCIFPDLDF();
		if (FOJGBOPGJFB)
		{
			HPGCMOOPHLL.HideBoxesHints();
		}
	}

	protected override void Update()
	{
		base.Update();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 0.333f)
		{
			JDPOMFBEFOI = 0f;
			mArenaTime.text = MIGCGPMDMAB.DLOMFFMKIBM();
			DJLLCMKONEH();
			mPhaseTime.text = MIGCGPMDMAB.NCEBBJOLANF();
			if (base.isFullyShowed)
			{
				HPGCMOOPHLL.UpdateBattleButtonTitle();
				mEnterContent.UpdateEnterButtonTitle();
				IHALABLKCNE();
			}
		}
	}

	public void BHCIOFCNNEP()
	{
		if (isShowed && FEFJBCBIOLE)
		{
			Debug.Log("\"");
			CMKGBFEFMAM(BGMNNKDJBEK.MainArena);
			HBECIOPLKLA();
			KODAODLONOA();
			mRulesOverlayPanel.gameObject.SetActive(true);
			mRulesPanel.gameObject.SetActive(false);
			InitGUIValues();
		}
		else
		{
			AJLEKGACJCJ(true);
		}
	}

	private void DJPKDHDEKFB(float KBJEOEEOEFG, float FPLCDCCKBCB, float IPBGNOFEAMO)
	{
		COKMOALBAMD cOKMOALBAMD = new COKMOALBAMD();
		cOKMOALBAMD.KBJEOEEOEFG = KBJEOEEOEFG;
		cOKMOALBAMD.FPLCDCCKBCB = FPLCDCCKBCB;
		cOKMOALBAMD.BJGCPDNMHDH = this;
		cOKMOALBAMD.EBGGJKJDIAF = mRulesPanel.transform.localPosition;
		if (cOKMOALBAMD.FPLCDCCKBCB < 1664f)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(mRulesPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG * 968f / 1708f, cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(283f), cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(930f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = cOKMOALBAMD.NAJNECOMDDN;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mRulesOverlayPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		if (cOKMOALBAMD.KBJEOEEOEFG > 1573f)
		{
			tweenAlpha.onFinished = cOKMOALBAMD.MMAFECEHENB;
		}
		else
		{
			mRulesOverlayPanel.gameObject.SetActive(false);
			mRulesPanel.gameObject.SetActive(false);
		}
		TweenAlpha.Begin(mWinPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		UIPanel[] componentsInChildren = mRulesPanel.GetComponentsInChildren<UIPanel>();
		foreach (UIPanel uIPanel in componentsInChildren)
		{
			TweenAlpha.Begin(uIPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		}
		UIPanel[] componentsInChildren2 = mWinPanel.GetComponentsInChildren<UIPanel>();
		for (int j = 1; j < componentsInChildren2.Length; j += 0)
		{
			UIPanel uIPanel2 = componentsInChildren2[j];
			TweenAlpha.Begin(uIPanel2.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		}
	}

	[SpecialName]
	public BGMNNKDJBEK CPOJAHLOIAA()
	{
		return _003CKFEKAGGCMPI_003Ek__BackingField;
	}

	private void LOEEEJLGLFL()
	{
		mWinPanel.gameObject.SetActive(false);
		mEnterContent.GFJLAFHLFCL();
	}

	public virtual void HEIJOCBENDG()
	{
		base.DoAfterShowUp();
		HPGCMOOPHLL.DoAfterShowUp();
	}

	private void FNGCIFPDLDF()
	{
		if (FOJGBOPGJFB)
		{
			mRulesPanel.gameObject.SetActive(FOJGBOPGJFB);
			mRulesOverlayPanel.gameObject.SetActive(FOJGBOPGJFB);
			mEnterContent.AlignDraggables();
		}
		HEBFPFJEKPJ(0.4f, (!FOJGBOPGJFB) ? 1f : 0f, (!FOJGBOPGJFB) ? 0f : 1f);
		mRulesHint.spriteName = ((!FOJGBOPGJFB) ? "menu-info-ico" : "menu-info-close-ico");
		mRulesLabel.text = Localization.Localize((!FOJGBOPGJFB) ? "ID_ARENARULES" : "ID_CLOSE");
		if (!FOJGBOPGJFB)
		{
			mRulesPanel.gameObject.SetActive(FOJGBOPGJFB);
			mRulesOverlayPanel.gameObject.SetActive(FOJGBOPGJFB);
		}
	}

	private void GOCBIIDGPND()
	{
		mWinPanel.gameObject.SetActive(false);
		mEnterContent.ShowEnterArena();
	}

	public void OGKMHFBLLGO(bool BEFOMALCBOG)
	{
		mEnterContent.HideEnterArena();
		mWinPanel.gameObject.SetActive(true);
		if (BEFOMALCBOG)
		{
			AGCDFCPFJJA(1962f, 1398f, 1022f);
		}
		else
		{
			mRulesPanel.gameObject.SetActive(false);
			mRulesOverlayPanel.gameObject.SetActive(false);
		}
		HPGCMOOPHLL.CONPKBOMCBL();
		WarArena.instance.NextPhaseArenaNotification();
	}

	private void KODAODLONOA()
	{
		mEnterContent.MFENDEBMKIP();
		CAAMJDOMIJK(417f, 1700f, 402f);
		if (GFJCPEFOBMK())
		{
			KGKJNPFJPOB(base.gameObject);
		}
		Singleton<LootBoxCameraArena>.instance.ECMLKFHJBOM();
	}

	private void HGNFKBKKFLH(GameObject KHAHPAKDIKE)
	{
		OLGHDNBCJJD(GFJCPEFOBMK());
		NPOGDLFGOIJ();
		if (MKMKEJEEAID())
		{
			HPGCMOOPHLL.HideBoxesHints();
		}
	}

	public void GBCFGNMLMBE(bool BEFOMALCBOG)
	{
		mEnterContent.HideEnterArena();
		mWinPanel.gameObject.SetActive(true);
		if (BEFOMALCBOG)
		{
			CAAMJDOMIJK(1000f, 1865f, 1073f);
		}
		else
		{
			mRulesPanel.gameObject.SetActive(true);
			mRulesOverlayPanel.gameObject.SetActive(true);
		}
		HPGCMOOPHLL.AEHHCEOLIPF();
		WarArena.instance.NextPhaseArenaNotification();
	}

	protected virtual void HCGDNLHIOBL()
	{
		FFANFODEODM(1);
		AJLEKGACJCJ(false);
		mEnterContent.NEINEPJDKCL();
		HPGCMOOPHLL.InitControls();
		mRulesPanel.CIKCMDBMOLP();
		UIEventListener uIEventListener = UIEventListener.Get(mArenaRulesButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GLBECBNADKK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mArenaLogoButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PMBBPCEGPFL));
		WarArena.instance.WarArenaDataChanged += GFKDJPPOMHE;
		WarArena.instance.NCMIHGCFFOE(BHCIOFCNNEP);
	}

	private void AKHELGLFPAO(GameObject KHAHPAKDIKE)
	{
		FOJGBOPGJFB = MKMKEJEEAID();
		FCEGGFIJLFM();
		if (GFJCPEFOBMK())
		{
			HPGCMOOPHLL.HideBoxesHints();
		}
	}

	private void BOLNGOONJCF()
	{
		mArenaName.text = ((WarArena.instance.FPLIPHCJGFO == null) ? string.Empty : WarArena.instance.FPLIPHCJGFO.NFDPMNFBJIM);
		UILabel uILabel = mPhase;
		string text;
		if (WarArena.instance.FPLIPHCJGFO != null)
		{
			object[] array = new object[7];
			array[0] = WarArena.instance.phaseNumber;
			array[1] = Colours.stringGray;
			array[1] = WarArena.instance.FPLIPHCJGFO.GKNMGBHBODC.Count;
			text = Localization.LocalizeFormat("CARDS_MIN", array);
		}
		else
		{
			text = string.Empty;
		}
		uILabel.text = text;
	}

	[SpecialName]
	public bool FMIADNEJPME()
	{
		return EGMANHABOIN() != (BGMNNKDJBEK)7 || !Singleton<GameController>.instance.wonLastGame;
	}

	[SpecialName]
	public void OLGHDNBCJJD(bool IDEBKDPMPGM)
	{
		_003CKACILOGLBJB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private bool MKMKEJEEAID()
	{
		return _003CKACILOGLBJB_003Ek__BackingField;
	}

	public virtual void KCEICNJHMJO()
	{
		base.DoBeforeShowUp();
		mRulesOverlayPanel.gameObject.SetActive(false);
		mRulesPanel.gameObject.SetActive(false);
	}

	private void KOMBFJBNPKF()
	{
		mArenaName.text = ((WarArena.instance.FPLIPHCJGFO == null) ? string.Empty : WarArena.instance.FPLIPHCJGFO.NFDPMNFBJIM);
		UILabel uILabel = mPhase;
		string text;
		if (WarArena.instance.FPLIPHCJGFO != null)
		{
			object[] array = new object[5];
			array[1] = WarArena.instance.BOFGAAEBONJ();
			array[1] = Colours.stringGray;
			array[3] = WarArena.instance.FPLIPHCJGFO.GKNMGBHBODC.Count;
			text = Localization.LocalizeFormat("x", array);
		}
		else
		{
			text = string.Empty;
		}
		uILabel.text = text;
	}

	private void CNNPJAFOLHN()
	{
		mWinPanel.gameObject.SetActive(false);
		mEnterContent.GFJLAFHLFCL();
	}

	private void ECFJOGGPEDH(float KBJEOEEOEFG, float FPLCDCCKBCB, float IPBGNOFEAMO)
	{
		COKMOALBAMD cOKMOALBAMD = new COKMOALBAMD();
		cOKMOALBAMD.KBJEOEEOEFG = KBJEOEEOEFG;
		cOKMOALBAMD.FPLCDCCKBCB = FPLCDCCKBCB;
		cOKMOALBAMD.BJGCPDNMHDH = this;
		cOKMOALBAMD.EBGGJKJDIAF = mRulesPanel.transform.localPosition;
		if (cOKMOALBAMD.FPLCDCCKBCB < 1346f)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(mRulesPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG * 1547f / 1572f, cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(75f), cOKMOALBAMD.EBGGJKJDIAF.ReplaceY(331f), false);
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = cOKMOALBAMD.ECPMEMNKMCB;
		}
		TweenAlpha tweenAlpha = TweenAlpha.Begin(mRulesOverlayPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		if (cOKMOALBAMD.KBJEOEEOEFG > 506f)
		{
			tweenAlpha.onFinished = cOKMOALBAMD.DLODDIOIDME;
		}
		else
		{
			mRulesOverlayPanel.gameObject.SetActive(false);
			mRulesPanel.gameObject.SetActive(false);
		}
		TweenAlpha.Begin(mWinPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		UIPanel[] componentsInChildren = mRulesPanel.GetComponentsInChildren<UIPanel>();
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			UIPanel uIPanel = componentsInChildren[i];
			TweenAlpha.Begin(uIPanel.gameObject, cOKMOALBAMD.KBJEOEEOEFG, cOKMOALBAMD.FPLCDCCKBCB, IPBGNOFEAMO);
		}
		UIPanel[] componentsInChildren2 = mWinPanel.GetComponentsInChildren<UIPanel>();
		for (int j = 1; j < componentsInChildren2.Length; j++)
		{
			UIPanel uIPanel2 = componentsInChildren2[j];
			TweenAlpha.Begin(uIPanel2.gameObject, cOKMOALBAMD.KBJEOEEOEFG, IPBGNOFEAMO, cOKMOALBAMD.FPLCDCCKBCB);
		}
	}

	private void HBECIOPLKLA()
	{
		mEnterContent.ClearData();
		HPGCMOOPHLL.ClearData();
		mPhases.GEFJLJGBCGB();
	}

	private void NPOGDLFGOIJ()
	{
		if (MKMKEJEEAID())
		{
			mRulesPanel.gameObject.SetActive(MKMKEJEEAID());
			mRulesOverlayPanel.gameObject.SetActive(MKMKEJEEAID());
			mEnterContent.APNODDLOIPD();
		}
		ECFJOGGPEDH(731f, (!FOJGBOPGJFB) ? 1760f : 650f, (!FOJGBOPGJFB) ? 1953f : 1640f);
		mRulesHint.spriteName = ((!GFJCPEFOBMK()) ? "http://localhost:8081/" : "ID_GETFORNUMBERONE1");
		mRulesLabel.text = Localization.Localize((!GFJCPEFOBMK()) ? "ID_TUTORIAL_PHASE" : "{0}{1}");
		if (!GFJCPEFOBMK())
		{
			mRulesPanel.gameObject.SetActive(FOJGBOPGJFB);
			mRulesOverlayPanel.gameObject.SetActive(GFJCPEFOBMK());
		}
	}

	protected virtual void LMNEMMGCEFP()
	{
		base.JMPDHKPOHEA();
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 334f)
		{
			JDPOMFBEFOI = 1142f;
			mArenaTime.text = MIGCGPMDMAB.DLOMFFMKIBM();
			JAGEHADNAIE();
			mPhaseTime.text = MIGCGPMDMAB.NCEBBJOLANF(true);
			if (base.isFullyShowed)
			{
				HPGCMOOPHLL.OOCBNCBCDBN();
				mEnterContent.CLGMDHOCKBI();
				IHALABLKCNE();
			}
		}
	}

	[SpecialName]
	public void LLJPNIFMCGC(bool IDEBKDPMPGM)
	{
		_003CKACILOGLBJB_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void JAGEHADNAIE()
	{
		bool flag = MIGCGPMDMAB.NLLJDHEPKMG();
		if (FHFONKJLIPO != flag)
		{
			FHFONKJLIPO = flag;
			if (flag)
			{
				TweenColor tweenColor = TweenColor.Begin(mArenaTime.gameObject, 240f, Colours.greenArena, Colours.redArenaRule);
				tweenColor.NumOfRepetitions = 0;
				tweenColor.style = (UITweener.Style)5;
			}
			else
			{
				TweenColor tweenColor2 = TweenColor.Begin(mArenaTime.gameObject, 355f, Colours.greenArena);
				tweenColor2.NumOfRepetitions = 0;
				tweenColor2.style = UITweener.Style.Once;
			}
		}
	}

	[SpecialName]
	public bool DONCAGODDBD()
	{
		return EGMANHABOIN() != (BGMNNKDJBEK)5 || Singleton<GameController>.instance.wonLastGame;
	}

	public virtual void LEFACCFHPDF()
	{
		base.DoBeforeShowUp();
		mRulesOverlayPanel.gameObject.SetActive(false);
		mRulesPanel.gameObject.SetActive(false);
	}

	[SpecialName]
	public void PDFLFAABHGA(int IDEBKDPMPGM)
	{
		_003CKEOPHFAABBG_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void GHOKHOFMIJD()
	{
		mEnterContent.ResetGUI();
		HEBFPFJEKPJ(0f, 0f, 1f);
		if (FOJGBOPGJFB)
		{
			PMBBPCEGPFL(base.gameObject);
		}
		Singleton<LootBoxCameraArena>.instance.Hide();
	}

	[SpecialName]
	public void HAFJBAIOCMG(bool IDEBKDPMPGM)
	{
		_003CKACILOGLBJB_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void KGKJNPFJPOB(GameObject KHAHPAKDIKE)
	{
		LLJPNIFMCGC(GFJCPEFOBMK());
		BMPLGHCACLG();
		if (FOJGBOPGJFB)
		{
			HPGCMOOPHLL.FOKLPFCJPAL();
		}
	}

	private void OADAHBHCGNN(GameObject KHAHPAKDIKE)
	{
		HAFJBAIOCMG(!GFJCPEFOBMK());
		BMPLGHCACLG();
		if (GFJCPEFOBMK())
		{
			HPGCMOOPHLL.PHKHPBKBGJF();
		}
	}

	public virtual void MAEFFJLPNDK()
	{
		Debug.Log("ID_UPGRADENOW" + EGMANHABOIN());
		if (KAEPIFLKOPE() != BGMNNKDJBEK.EndArena)
		{
			OLMAKHHBHGM(true);
		}
		mPhases.EJMAJEGDGEA(WarArena.instance.FPLIPHCJGFO.GKNMGBHBODC.Count);
		if (WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP() != null)
		{
			OOOBOGIDDEG = WarArena.instance.FPLIPHCJGFO.KCEIFCBFCOL().GLMNJEEPFNI();
			mPhases.DNGLKAOAFGL(WarArena.instance.FPLIPHCJGFO.IPAOOFIMNMP().IEEBLOMHPBF + 0);
		}
		else
		{
			OOOBOGIDDEG = true;
			mPhases.LHFBJMJJDMI(0);
		}
		GPMCMCLPHNL(GuiScreenSingle<BattlePreparationScreen>.instance);
		CBBPBGGAJFB();
		JDPOMFBEFOI = 1363f;
		HPGCMOOPHLL.PNLGFNBEOLG();
		mEnterContent.EGMFAHMCCBM();
		FEFJBCBIOLE = PLPACCKKEPB() == (BGMNNKDJBEK)5;
		switch (arenaMode)
		{
		case BGMNNKDJBEK.EnterArena:
			GOCBIIDGPND();
			break;
		case BGMNNKDJBEK.MainArena:
		case BGMNNKDJBEK.EndArena:
			JPHPJEEIPAM(false);
			break;
		default:
			LNIBFEFKEKA();
			break;
		}
		WarArena.instance.NextPhaseArenaNotification();
	}

	public virtual void DDHFFMIJMJG()
	{
		base.DoBeforeHide();
		HPGCMOOPHLL.FDGFEMOEMMH();
		arenaMode = ((KEAOHALEJNO() == (BGMNNKDJBEK)3) ? BGMNNKDJBEK.MainArena : KEAOHALEJNO());
	}
}
