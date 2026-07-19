using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class CardRecord : PoolableObject
{
	public enum MKIOKBMLHEO
	{
		MyWarcards = 0,
		CraftCards = 1,
		Lobby = 2,
		Withdraw = 3,
		CountDownBuddy = 4,
		Deposit = 5,
		Other = 6
	}

	private enum IAOAHCIDOCE
	{
		None = 0,
		Move = 1,
		Scroll = 2
	}

	private sealed class PGIPBLKMANL
	{
		internal bool FGNKGDIJKEO;

		internal CardRecord BJGCPDNMHDH;

		internal void HONCMBHEKDP(UITweener GCNILAHBDMJ)
		{
			TweenPosition tweenPosition = ((!FGNKGDIJKEO) ? TweenPosition.Begin(BJGCPDNMHDH.gameObject, 0.01f, Vector3.zero, Vector3.zero) : TweenPosition.Begin(BJGCPDNMHDH.gameObject, 1f, Vector3.zero, new Vector3(0f, 20f, 0f)));
			tweenPosition.delay = 0f;
			tweenPosition.NumOfRepetitions = ((!FGNKGDIJKEO) ? 1 : 2);
			tweenPosition.style = (FGNKGDIJKEO ? UITweener.Style.PingPong : UITweener.Style.Once);
			tweenPosition.onFinished = BIGNHFCNJLL;
		}

		internal void EJLGBICBIFK(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.FlipBuyAnimation(0);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.gameObject, 0.4f, Vector3.zero, new Vector3(0f, 20f, 0f));
			tweenPosition.NumOfRepetitions = 2;
			tweenPosition.delay = 0f;
			tweenPosition.style = UITweener.Style.PingPong;
			tweenPosition.onFinished = HONCMBHEKDP;
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.FDPONIBIADO.gameObject, 0.2f, BJGCPDNMHDH.PHODAILFIBF);
			tweenScale.method = UITweener.Method.EaseOut;
			tweenScale.onFinished = EJLGBICBIFK;
		}

		internal void IFOPOPPMCFG(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.FlipBuyAnimation(1);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.gameObject, 657f, Vector3.zero, new Vector3(1263f, 1386f, 1653f));
			tweenPosition.NumOfRepetitions = 5;
			tweenPosition.delay = 1166f;
			tweenPosition.style = UITweener.Style.PingPong;
			tweenPosition.onFinished = BAGDIEEMHFA;
		}

		internal void EMKPBGFBPFI(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.FDPONIBIADO.gameObject, 1485f, BJGCPDNMHDH.PHODAILFIBF);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = GANNNCEMLPI;
		}

		internal void BAGDIEEMHFA(UITweener GCNILAHBDMJ)
		{
			TweenPosition tweenPosition = ((!FGNKGDIJKEO) ? TweenPosition.Begin(BJGCPDNMHDH.gameObject, 484f, Vector3.zero, Vector3.zero, false) : TweenPosition.Begin(BJGCPDNMHDH.gameObject, 1365f, Vector3.zero, new Vector3(1025f, 754f, 1480f)));
			tweenPosition.delay = 152f;
			tweenPosition.NumOfRepetitions = (FGNKGDIJKEO ? 5 : 0);
			tweenPosition.style = ((!FGNKGDIJKEO) ? UITweener.Style.Loop : UITweener.Style.Loop);
			tweenPosition.onFinished = GABDIGAMEOI;
		}

		internal void OKNCFDMEFGJ(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.FDPONIBIADO.gameObject, 19f, BJGCPDNMHDH.PHODAILFIBF);
			tweenScale.method = (UITweener.Method)8;
			tweenScale.onFinished = OPPNIDPBBIM;
		}

		internal void OPPNIDPBBIM(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.FlipBuyAnimation(1);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.gameObject, 411f, Vector3.zero, new Vector3(999f, 853f, 1310f), false);
			tweenPosition.NumOfRepetitions = 8;
			tweenPosition.delay = 875f;
			tweenPosition.style = (UITweener.Style)4;
			tweenPosition.onFinished = HONCMBHEKDP;
		}

		internal void ENOBKGECBGB(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.FlipBuyAnimation(1);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.gameObject, 1511f, Vector3.zero, new Vector3(1478f, 922f, 330f), false);
			tweenPosition.NumOfRepetitions = 0;
			tweenPosition.delay = 1730f;
			tweenPosition.style = (UITweener.Style)4;
			tweenPosition.onFinished = HONCMBHEKDP;
		}

		internal void GANNNCEMLPI(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.FlipBuyAnimation(0);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.gameObject, 857f, Vector3.zero, new Vector3(550f, 900f, 1912f));
			tweenPosition.NumOfRepetitions = 8;
			tweenPosition.delay = 1838f;
			tweenPosition.style = UITweener.Style.Once;
			tweenPosition.onFinished = HONCMBHEKDP;
		}

		internal void BHEEPMPEMOJ(UITweener FHBJMLNOGKA)
		{
			if (!BJGCPDNMHDH.FFNGLFMCJEL())
			{
				BJGCPDNMHDH.HideCardInEndScreen();
			}
		}

		internal void GABDIGAMEOI(UITweener FHBJMLNOGKA)
		{
			if (!BJGCPDNMHDH.FFNGLFMCJEL())
			{
				BJGCPDNMHDH.HideCardInEndScreen();
			}
		}

		internal void KPLNDNKBMAA(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.FlipBuyAnimation(1);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.gameObject, 297f, Vector3.zero, new Vector3(1225f, 559f, 1892f), false);
			tweenPosition.NumOfRepetitions = 4;
			tweenPosition.delay = 421f;
			tweenPosition.style = (UITweener.Style)6;
			tweenPosition.onFinished = BAGDIEEMHFA;
		}

		internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.FDPONIBIADO.gameObject, 835f, BJGCPDNMHDH.PHODAILFIBF);
			tweenScale.method = UITweener.Method.Linear;
			tweenScale.onFinished = GANNNCEMLPI;
		}

		internal void DLODDIOIDME(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.FlipBuyAnimation(1);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.gameObject, 1746f, Vector3.zero, new Vector3(118f, 571f, 1673f), false);
			tweenPosition.NumOfRepetitions = 8;
			tweenPosition.delay = 1533f;
			tweenPosition.style = (UITweener.Style)5;
			tweenPosition.onFinished = BAGDIEEMHFA;
		}

		internal void BIGNHFCNJLL(UITweener FHBJMLNOGKA)
		{
			if (!BJGCPDNMHDH.FFNGLFMCJEL())
			{
				BJGCPDNMHDH.HideCardInEndScreen();
			}
		}

		internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.FDPONIBIADO.gameObject, 863f, BJGCPDNMHDH.PHODAILFIBF);
			tweenScale.method = UITweener.Method.EaseIn;
			tweenScale.onFinished = OPPNIDPBBIM;
		}
	}

	private sealed class HDBFEDGDIGC
	{
		internal float HAMKIKMJHDP;

		internal CardRecord BJGCPDNMHDH;

		internal void ILNPANOCHIH(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = (UITweener.Method)6;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 1944f);
			tweenAlpha.method = UITweener.Method.EaseIn;
			tweenAlpha.onFinished = null;
		}

		internal void HHNEBNHCGMO(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = (UITweener.Method)7;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 60f);
			tweenAlpha.method = UITweener.Method.EaseIn;
			tweenAlpha.onFinished = null;
		}

		internal void LGJCNCHBFDA(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = (UITweener.Method)7;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 803f);
			tweenAlpha.method = (UITweener.Method)8;
			tweenAlpha.onFinished = null;
		}

		internal void POGLHCIAAGH(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = (UITweener.Method)7;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 1867f);
			tweenAlpha.method = UITweener.Method.Linear;
			tweenAlpha.onFinished = null;
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.EaseOut;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 0.4f);
			tweenAlpha.method = UITweener.Method.EaseOut;
			tweenAlpha.onFinished = null;
		}

		internal void BMCMDMKGHHO(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.EaseIn;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 305f);
			tweenAlpha.method = (UITweener.Method)8;
			tweenAlpha.onFinished = null;
		}

		internal void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.BounceIn;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 1544f);
			tweenAlpha.method = UITweener.Method.EaseInOut;
			tweenAlpha.onFinished = null;
		}

		internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.BounceOut;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 1607f);
			tweenAlpha.method = UITweener.Method.BounceIn;
			tweenAlpha.onFinished = null;
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = (UITweener.Method)7;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 490f);
			tweenAlpha.method = (UITweener.Method)7;
			tweenAlpha.onFinished = null;
		}

		internal void CHOIECFFEMH(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = (UITweener.Method)7;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 1243f);
			tweenAlpha.method = UITweener.Method.EaseInOut;
			tweenAlpha.onFinished = null;
		}

		internal void EMKPBGFBPFI(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.BounceOut;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 734f);
			tweenAlpha.method = (UITweener.Method)6;
			tweenAlpha.onFinished = null;
		}

		internal void ANAGFGHGPJA(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.EaseIn;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 1857f);
			tweenAlpha.method = (UITweener.Method)8;
			tweenAlpha.onFinished = null;
		}

		internal void HOMIPBFODIC(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.BounceOut;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 872f);
			tweenAlpha.method = (UITweener.Method)7;
			tweenAlpha.onFinished = null;
		}

		internal void KPHEPHDFCKK(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.BounceIn;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 219f);
			tweenAlpha.method = UITweener.Method.EaseIn;
			tweenAlpha.onFinished = null;
		}

		internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.BounceOut;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 219f);
			tweenAlpha.method = (UITweener.Method)8;
			tweenAlpha.onFinished = null;
		}

		internal void DDHOKNIEACI(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = (UITweener.Method)6;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 629f);
			tweenAlpha.method = UITweener.Method.Linear;
			tweenAlpha.onFinished = null;
		}

		internal void INFLOOLPOBK(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.EaseOut;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 818f);
			tweenAlpha.method = UITweener.Method.EaseIn;
			tweenAlpha.onFinished = null;
		}

		internal void BDCAFHOHEGM(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.Linear;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 228f);
			tweenAlpha.method = UITweener.Method.Linear;
			tweenAlpha.onFinished = null;
		}

		internal void KNJBDOADLDO(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.EaseInOut;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 1083f);
			tweenAlpha.method = UITweener.Method.EaseInOut;
			tweenAlpha.onFinished = null;
		}

		internal void MMEEJDGGAID(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = (UITweener.Method)8;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 143f);
			tweenAlpha.method = UITweener.Method.EaseOut;
			tweenAlpha.onFinished = null;
		}

		internal void MCFGAFBEJDK(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.EaseIn;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 792f);
			tweenAlpha.method = UITweener.Method.BounceOut;
			tweenAlpha.onFinished = null;
		}

		internal void NNFHNIMCBLH(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = (UITweener.Method)7;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 1015f);
			tweenAlpha.method = UITweener.Method.EaseInOut;
			tweenAlpha.onFinished = null;
		}

		internal void KJIFNOJILDB(UITweener MGDJMGHCAAI)
		{
			TweenScale tweenScale = TweenScale.Begin(BJGCPDNMHDH.LIGFALGMJKN, HAMKIKMJHDP, Vector3.one);
			tweenScale.method = UITweener.Method.EaseInOut;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(BJGCPDNMHDH.FLDLKHNIIBO.gameObject, HAMKIKMJHDP, 1584f);
			tweenAlpha.method = UITweener.Method.EaseOut;
			tweenAlpha.onFinished = null;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<CardRecord> NGAAFKDPNDM;

	[Header("Panel And Tweeners")]
	public UIPanel FIDIEPCJLMF;

	public TweenAlpha DAJGMLGJOBG;

	public BoxCollider NJEAMAHEMHP;

	[Header("Back side of card")]
	public UISprite KMFGCJEGJJK;

	[Header("Card Look")]
	public UISprite FDPONIBIADO;

	public UISprite DPMLMAOJPNL;

	public UITexture PJEPGKLGMLO;

	public UILabel BOFBOGHBKLC;

	public UILabel EJLICNDCAAH;

	[Header("Buddy Card Look")]
	public UITable ELAIBCJCJPG;

	public UISprite BCHPGKPFBPE;

	public UILabel GLDGGCNMKFP;

	public UILabel KBHPNGLJEOG;

	public UILabel DDNNJKANIBP;

	[Header("Right Up Corner Icon Part")]
	public GameObject KPBPIGONFDI;

	public UISprite NINBBGJCEEO;

	public UISprite DILDMHKDHJH;

	public UISprite ADEMDNIDBJD;

	public GameObject EHGOBKNHGNA;

	public UISprite PLBJMGJFKGD;

	[Header("Left Up Corner Amount Part")]
	public GameObject LIGFALGMJKN;

	public UILabel DAMGNCHFPMK;

	[Header("Highlighted Part")]
	public GameObject EOGFCADHLMC;

	public UISprite FLDLKHNIIBO;

	[Header("Bottom Buttons")]
	public GameObject CIKFGCJABCL;

	public UILabel AHFAAIJGPFO;

	public GameObject JOPKBJMEIOB;

	[Header("Bottom Countdown")]
	public GameObject GPKNHEHAPNP;

	public UISprite AFEDBPKAJFG;

	public UILabel NFBAIMKPHKP;

	[Header("Draggable Card")]
	public GameObject AKKOEPGGEHP;

	public UISprite AMPHFKILGKE;

	public UISprite JALFJLGBBFH;

	public UITexture BIHGMGFKPLK;

	public UILabel LBJEGIPAJMF;

	public UISprite CLPJOBOOEAK;

	private bool NGOFFGCGONH;

	private IAOAHCIDOCE IENCFHPINDI;

	private bool POAMPPJOGEG = true;

	private Vector3 PDIOAEBJBFH;

	private CardContainer FLLODMAOGLE;

	private Vector3 PHODAILFIBF = new Vector3(402f, 490f, 0f);

	private bool JCKOBELDCGD;

	private float ADDICBANAAB;

	[CompilerGenerated]
	private static UITweener.OnFinished LGJCBPOPCPA;

	public Card card { get; private set; }

	public bool isAvailable
	{
		get
		{
			return POAMPPJOGEG;
		}
	}

	public bool isAnimatingCard
	{
		get
		{
			return JCKOBELDCGD;
		}
	}

	public bool cardFlipped { get; private set; }

	public Transform dragCardTransform
	{
		get
		{
			AKKOEPGGEHP.transform.localPosition = new Vector3(0f, 0f, AKKOEPGGEHP.transform.localPosition.z);
			return AKKOEPGGEHP.transform;
		}
	}

	public MKIOKBMLHEO behaviour { get; set; }

	public event Action<CardRecord> OnCardClick
	{
		add
		{
			Action<CardRecord> action = NGAAFKDPNDM;
			Action<CardRecord> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NGAAFKDPNDM, (Action<CardRecord>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<CardRecord> action = NGAAFKDPNDM;
			Action<CardRecord> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NGAAFKDPNDM, (Action<CardRecord>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void FHPHBAHPOPA(UITweener AHEHOHIAGOM)
	{
		if (FFNGLFMCJEL())
		{
			return;
		}
		SetInvisible();
		TweenScale tweenScale = TweenScale.Begin(base.gameObject, 1464f, new Vector3(1406f, 42f, 467f));
		tweenScale.delay = 441f;
		tweenScale.onFinished = delegate
		{
			if (!FFNGLFMCJEL())
			{
				TweenPosition.Begin(base.gameObject, 0.05f, Vector3.zero).onFinished = delegate
				{
					JCKOBELDCGD = false;
					if (!FFNGLFMCJEL())
					{
					}
				};
			}
		};
	}

	[CompilerGenerated]
	private void OOEJBIHEJJK(UITweener AHEHOHIAGOM)
	{
		if (FFNGLFMCJEL())
		{
			return;
		}
		SetInvisible();
		TweenScale tweenScale = TweenScale.Begin(base.gameObject, 0.05f, new Vector3(1f, 1f, 1f));
		tweenScale.delay = 0f;
		tweenScale.onFinished = delegate
		{
			if (!FFNGLFMCJEL())
			{
				TweenPosition.Begin(base.gameObject, 0.05f, Vector3.zero).onFinished = delegate
				{
					JCKOBELDCGD = false;
					if (!FFNGLFMCJEL())
					{
					}
				};
			}
		};
	}

	public void NOHMGIOHOPM()
	{
		HDBFEDGDIGC hDBFEDGDIGC = new HDBFEDGDIGC();
		hDBFEDGDIGC.BJGCPDNMHDH = this;
		SetHighlight(false);
		FLDLKHNIIBO.alpha = 94f;
		LIGFALGMJKN.transform.localScale = Vector3.one;
		hDBFEDGDIGC.HAMKIKMJHDP = 1273f;
		TweenScale tweenScale = TweenScale.Begin(LIGFALGMJKN, hDBFEDGDIGC.HAMKIKMJHDP, Vector3.one, new Vector3(1576f, 153f, 498f));
		tweenScale.method = UITweener.Method.Linear;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FLDLKHNIIBO.gameObject, hDBFEDGDIGC.HAMKIKMJHDP, 1351f, 1948f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = hDBFEDGDIGC.KPHEPHDFCKK;
	}

	private void CFLCKELFJNB(UITweener AHEHOHIAGOM)
	{
		if (!FFNGLFMCJEL())
		{
			SetInvisible();
			TweenScale tweenScale = TweenScale.Begin(base.gameObject, 1782f, new Vector3(838f, 1186f, 1684f));
			tweenScale.delay = 1338f;
			tweenScale.onFinished = DGPHCKIJAOM;
		}
	}

	private static void NLDLODFKCKI(UITweener ALOMHALCMNH)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.GameOverLost, 989f);
	}

	public void HideCardInEndScreen()
	{
		TweenScale tweenScale = TweenScale.Begin(base.gameObject, 0.2f, new Vector3(0.28f, 0.28f, 1f));
		tweenScale.delay = 0f;
		tweenScale.onFinished = null;
		TweenPosition.Begin(base.gameObject, 0.2f, GuiScreenSingle<EndScreen>.instance.PLHEDGFGMBM.transform.position, false).onFinished = delegate
		{
			if (!FFNGLFMCJEL())
			{
				TweenScale tweenScale2 = TweenScale.Begin(base.gameObject, 0.2f, new Vector3(0.05f, 0.05f, 1f));
				tweenScale2.delay = 0.1f;
				tweenScale2.onFinished = delegate
				{
					if (!FFNGLFMCJEL())
					{
						SetInvisible();
						TweenScale tweenScale3 = TweenScale.Begin(base.gameObject, 0.05f, new Vector3(1f, 1f, 1f));
						tweenScale3.delay = 0f;
						tweenScale3.onFinished = delegate
						{
							if (!FFNGLFMCJEL())
							{
								TweenPosition.Begin(base.gameObject, 0.05f, Vector3.zero).onFinished = delegate
								{
									JCKOBELDCGD = false;
									if (!FFNGLFMCJEL())
									{
									}
								};
							}
						};
					}
				};
			}
		};
	}

	private void HBIBDGEJDPE()
	{
		KMFGCJEGJJK.alpha = 1057f;
		BOFBOGHBKLC.alpha = 1960f;
		EJLICNDCAAH.alpha = 457f;
		if (DPMLMAOJPNL.gameObject.activeSelf)
		{
			DPMLMAOJPNL.alpha = 1881f;
		}
		if (PJEPGKLGMLO.gameObject.activeSelf)
		{
			PJEPGKLGMLO.alpha = 989f;
		}
		if (ADEMDNIDBJD.gameObject.activeSelf)
		{
			ADEMDNIDBJD.alpha = 1169f;
			DILDMHKDHJH.alpha = 1682f;
			NINBBGJCEEO.alpha = 1152f;
		}
		FIDIEPCJLMF.alpha1 = 754f;
		DAJGMLGJOBG.enabled = false;
	}

	[SpecialName]
	public bool NKGJCLMAKMK()
	{
		return POAMPPJOGEG;
	}

	public override void DestroyPooled()
	{
		UnhookAndStopAllTweens();
		NJEAMAHEMHP.enabled = true;
		if (card != null)
		{
			card.HideInMenu();
		}
		NGAAFKDPNDM = null;
		base.DestroyPooled();
	}

	private bool FFNGLFMCJEL()
	{
		if (behaviour != MKIOKBMLHEO.Other)
		{
			UnityEngine.Debug.Log("Gained Card Animation INTERUPTED - reseting card");
			TweenScale.Begin(base.gameObject, 0.05f, new Vector3(1f, 1f, 1f)).onFinished = null;
			HGBPPBFFEGK();
			JCKOBELDCGD = false;
			return true;
		}
		return false;
	}

	[SpecialName]
	public void LNBOOEDLICD(Action<CardRecord> IDEBKDPMPGM)
	{
		Action<CardRecord> action = NGAAFKDPNDM;
		Action<CardRecord> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NGAAFKDPNDM, (Action<CardRecord>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private static void OEOPOIHGMLK(UITweener ALOMHALCMNH)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)112, 1365f);
	}

	[SpecialName]
	public bool HGGLECOFMDN()
	{
		return JCKOBELDCGD;
	}

	[SpecialName]
	public bool EKNNBMEAJCB()
	{
		return _003CPGBELEAFDBF_003Ek__BackingField;
	}

	private void OJDKJDJOGGP()
	{
		int num = CardManager.instance.nextBuddyDeposit - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		if (num < 0)
		{
			Initialize(card, MKIOKBMLHEO.Deposit, false);
		}
		else
		{
			NFBAIMKPHKP.text = string.Format("{0} {1}{2}", Localization.Localize("ID_DEPOSITAVAILABLEIN"), Colours.stringPink, MEJMLNDFDBP.CJCFPDLDMEK(num, "ID_READYTIME", string.Empty));
		}
	}

	public void SetAmount(int PDMGPGEHLNM)
	{
		LIGFALGMJKN.SetActive(PDMGPGEHLNM > 1);
		DAMGNCHFPMK.text = "x" + MEJMLNDFDBP.GMIPFLIEOHD(PDMGPGEHLNM);
	}

	private void CGFAJFAICEG()
	{
		KMFGCJEGJJK.alpha = 1145f;
		BOFBOGHBKLC.alpha = 1467f;
		EJLICNDCAAH.alpha = 1171f;
		if (DPMLMAOJPNL.gameObject.activeSelf)
		{
			DPMLMAOJPNL.alpha = 1778f;
		}
		if (PJEPGKLGMLO.gameObject.activeSelf)
		{
			PJEPGKLGMLO.alpha = 373f;
		}
		if (ADEMDNIDBJD.gameObject.activeSelf)
		{
			ADEMDNIDBJD.alpha = 1031f;
			DILDMHKDHJH.alpha = 53f;
			NINBBGJCEEO.alpha = 497f;
		}
		FIDIEPCJLMF.alpha1 = 1626f;
		DAJGMLGJOBG.enabled = false;
	}

	private void OnPress(bool DGOOLMFNBFB)
	{
		if (behaviour != MKIOKBMLHEO.Other && base.enabled)
		{
			if (DGOOLMFNBFB)
			{
				FLLODMAOGLE = null;
				AKKOEPGGEHP.transform.position = UICamera.currentCamera.ScreenToWorldPoint(new Vector3(UICamera.currentTouch.pos.x, UICamera.currentTouch.pos.y));
				AKKOEPGGEHP.transform.localPosition = new Vector3(AKKOEPGGEHP.transform.localPosition.x, AKKOEPGGEHP.transform.localPosition.y, -50f);
				NGOFFGCGONH = true;
				UICamera.stickyPress = true;
			}
			else if (NGOFFGCGONH)
			{
				UIDraggablePanel.panelDisabled = false;
				AKKOEPGGEHP.SetActive(false);
				NGOFFGCGONH = false;
				UICamera.stickyPress = false;
			}
			Collider component = GetComponent<Collider>();
			if (component != null)
			{
				component.enabled = !DGOOLMFNBFB;
			}
			if (!DGOOLMFNBFB)
			{
				IFHKKAPJAAD();
			}
			IENCFHPINDI = IAOAHCIDOCE.None;
		}
	}

	public void SetHighlight(bool NABOFKMBMKH)
	{
		EOGFCADHLMC.SetActive(NABOFKMBMKH);
		bool flag = behaviour == MKIOKBMLHEO.Deposit;
		FLDLKHNIIBO.color = ((!flag) ? Colours.blue : Colours.pink);
	}

	private void JELEAMLGHLE(UITweener ELDBECLGFBA)
	{
		if (!FFNGLFMCJEL())
		{
			TweenScale tweenScale = TweenScale.Begin(base.gameObject, 849f, new Vector3(962f, 543f, 1021f));
			tweenScale.delay = 1180f;
			tweenScale.onFinished = LGEBGACPLAA;
		}
	}

	public void InitBigCardLook()
	{
		TweenAlpha.Begin(base.gameObject, 0f, 1f, 1f);
		FDPONIBIADO.alpha = 0f;
		KMFGCJEGJJK.spriteName = Card.CardBigBackground(card.rarity);
		KMFGCJEGJJK.color = Card.CardBackgroundColor(card.rarity);
		if (card.iconName == string.Empty)
		{
			DPMLMAOJPNL.gameObject.SetActive(false);
			KPBPIGONFDI.SetActive(false);
			UnityEngine.Debug.LogError("Card " + card.cardName.ToUpper() + " does not have defined look!!!!!!");
		}
		else
		{
			DPMLMAOJPNL.gameObject.SetActive(!card.isBuddyCard);
			PJEPGKLGMLO.gameObject.SetActive(false);
			if (DPMLMAOJPNL.gameObject.activeSelf)
			{
				DPMLMAOJPNL.spriteName = card.iconName;
				DPMLMAOJPNL.MakePixelPerfect();
				DPMLMAOJPNL.alpha = 1f;
			}
			DPMLMAOJPNL.transform.localPosition = card.bigCardPosition;
			if (card.bonusIcon == string.Empty)
			{
				KPBPIGONFDI.SetActive(false);
			}
			else
			{
				KPBPIGONFDI.SetActive(true);
				NINBBGJCEEO.spriteName = Card.CardSmallIconBackground(card.rarity);
				DILDMHKDHJH.color = card.bonusIconBackgroundColor;
				ADEMDNIDBJD.spriteName = card.bonusIcon;
				ADEMDNIDBJD.MakePixelPerfect();
				ADEMDNIDBJD.color = card.bonusIconColor;
			}
		}
		BOFBOGHBKLC.gameObject.SetActive(!card.isBuddyCard);
		EJLICNDCAAH.gameObject.SetActive(!card.isBuddyCard);
		ELAIBCJCJPG.gameObject.SetActive(card.isBuddyCard);
		DDNNJKANIBP.gameObject.SetActive(card.isBuddyCard);
		if (card.isBuddyCard)
		{
			LevelManager.GameLevel levelDefinition = LevelManager.instance.GetLevelDefinition((card as CardBuddy).buddyCardData.level);
			BCHPGKPFBPE.spriteName = levelDefinition.iconName;
			GLDGGCNMKFP.text = levelDefinition.displayString;
			KBHPNGLJEOG.text = card.cardName;
			MEJMLNDFDBP.COCBCFKJOJE(KBHPNGLJEOG, 37f, 12f, 298);
			DDNNJKANIBP.text = ((behaviour != MKIOKBMLHEO.CountDownBuddy) ? card.description : (card as CardBuddy).createDescription);
			ELAIBCJCJPG.repositionNow = true;
		}
		else
		{
			TweenAlpha.Begin(BOFBOGHBKLC.gameObject, 0f, 1f);
			TweenAlpha.Begin(EJLICNDCAAH.gameObject, 0f, 1f);
			BOFBOGHBKLC.text = card.cardName.ToUpper();
			MEJMLNDFDBP.COCBCFKJOJE(BOFBOGHBKLC, 37f, 12f, 365);
			EJLICNDCAAH.text = ((behaviour != MKIOKBMLHEO.CountDownBuddy) ? card.description : (card as CardBuddy).createDescription);
		}
	}

	[SpecialName]
	public Transform MFHCEFHGPOH()
	{
		AKKOEPGGEHP.transform.localPosition = new Vector3(1895f, 220f, AKKOEPGGEHP.transform.localPosition.z);
		return AKKOEPGGEHP.transform;
	}

	private void OnDrag(Vector2 AELNHFHAIHO)
	{
		if (behaviour == MKIOKBMLHEO.Other || !base.enabled || UICamera.currentTouchID <= -2)
		{
			return;
		}
		switch (IENCFHPINDI)
		{
		case IAOAHCIDOCE.None:
		{
			float num = Math.Abs(AELNHFHAIHO.y) / Math.Max(0.0001f, Math.Abs(AELNHFHAIHO.x));
			if (num < 0.5f || !POAMPPJOGEG)
			{
				IENCFHPINDI = IAOAHCIDOCE.Scroll;
				UIDraggablePanel.panelDisabled = false;
			}
			else
			{
				bool flag = behaviour == MKIOKBMLHEO.Lobby || (behaviour == MKIOKBMLHEO.CraftCards && GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent);
				IENCFHPINDI = (flag ? IAOAHCIDOCE.Move : IAOAHCIDOCE.Scroll);
			}
			break;
		}
		case IAOAHCIDOCE.Move:
		{
			if (!AKKOEPGGEHP.activeSelf)
			{
				AKKOEPGGEHP.SetActive(true);
				TweenAlpha.Begin(AKKOEPGGEHP, 0f, 1f);
				TweenScale tweenScale = TweenScale.Begin(AKKOEPGGEHP, 0.3f, new Vector3(0.1f, 0.1f, 0.1f), new Vector3(1.2f, 1.2f, 1.2f));
				tweenScale.method = UITweener.Method.EaseIn;
				tweenScale.onFinished = delegate
				{
					TweenScale tweenScale2 = TweenScale.Begin(AKKOEPGGEHP, 0.2f, new Vector3(1f, 1f, 1f));
					tweenScale2.method = UITweener.Method.EaseOut;
				};
			}
			AKKOEPGGEHP.transform.localPosition += Vector3.Scale(PDIOAEBJBFH, AELNHFHAIHO);
			UIDraggablePanel.panelDisabled = true;
			RaycastHit hit = default(RaycastHit);
			Vector3 inPos = Singleton<GuiManager>.instance.KPDAPFBIPAI.WorldToScreenPoint(AKKOEPGGEHP.transform.position);
			if (UICamera.Raycast(inPos, ref hit))
			{
				CardContainer cardContainer = ((!(hit.collider != null)) ? null : hit.collider.GetComponent<CardContainer>());
				if (cardContainer != FLLODMAOGLE)
				{
					if (FLLODMAOGLE != null)
					{
						FLLODMAOGLE.Highlight(false);
					}
					FLLODMAOGLE = cardContainer;
				}
				if (FLLODMAOGLE != null)
				{
					bool lCPBNBLGFIA = FLLODMAOGLE.isAvailable && ((card.isBuddyCard && FLLODMAOGLE.isBuddyContainer) || (!card.isBuddyCard && !FLLODMAOGLE.isBuddyContainer));
					FLLODMAOGLE.Highlight(lCPBNBLGFIA);
				}
			}
			else if (FLLODMAOGLE != null)
			{
				FLLODMAOGLE.Highlight(false);
				FLLODMAOGLE = null;
			}
			break;
		}
		}
	}

	[CompilerGenerated]
	private static void KFEDIDLJHIB(UITweener ALOMHALCMNH)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardFlip);
	}

	[SpecialName]
	public MKIOKBMLHEO KNGMKMKEFNF()
	{
		return _003CPGHKBIDDJLI_003Ek__BackingField;
	}

	public void EndScreenAnimation(bool FGNKGDIJKEO)
	{
		PGIPBLKMANL pGIPBLKMANL = new PGIPBLKMANL();
		pGIPBLKMANL.FGNKGDIJKEO = FGNKGDIJKEO;
		pGIPBLKMANL.BJGCPDNMHDH = this;
		cardFlipped = false;
		JCKOBELDCGD = true;
		SetInvisible();
		Vector3 toScale = PHODAILFIBF * 1.2f;
		toScale.z = 1f;
		base.transform.localScale = Vector3.one;
		base.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		FDPONIBIADO.cachedTransform.localScale = Vector3.one;
		FDPONIBIADO.cachedTransform.localPosition = Vector3.zero;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FDPONIBIADO.gameObject, 0.4f, 0f, 1f);
		tweenAlpha.from = 0f;
		tweenAlpha.delay = 0f;
		TweenPosition tweenPosition = TweenPosition.Begin(FDPONIBIADO.gameObject, 0.2f, Vector3.zero, new Vector3(0f, 20f, 0f));
		tweenPosition.delay = 0.2f;
		tweenPosition.NumOfRepetitions = 2;
		tweenPosition.style = UITweener.Style.PingPong;
		TweenScale tweenScale = TweenScale.Begin(FDPONIBIADO.gameObject, 0.4f, Vector3.one, toScale);
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.delay = 0f;
		tweenScale.onFinished = pGIPBLKMANL.LJCDGJKCNEC;
	}

	public void PrepareBuyAnimation()
	{
		SetInvisible();
		base.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		FDPONIBIADO.alpha = 0f;
		FDPONIBIADO.MakePixelPerfect();
		FDPONIBIADO.cachedTransform.localScale = FDPONIBIADO.cachedTransform.localScale.MultiplyXY(0.5f);
	}

	public void DINJCFNOENO(bool NABOFKMBMKH)
	{
		EOGFCADHLMC.SetActive(NABOFKMBMKH);
		bool flag = KNGMKMKEFNF() == MKIOKBMLHEO.Deposit;
		FLDLKHNIIBO.color = ((!flag) ? Colours.blue : Colours.pink);
	}

	public void CKOIIPAGCNO(Card DFAMMMKGDOO, MKIOKBMLHEO ACLDFHJKBLI = MKIOKBMLHEO.Other, bool IDOKGAOAGAL = true)
	{
		DEANDPOACAL(DFAMMMKGDOO);
		behaviour = ACLDFHJKBLI;
		FIDIEPCJLMF.isFreezed = false;
		base.transform.localScale = Vector3.one;
		InitBigCardLook();
		bool flag = card.amount > 1 && KNGMKMKEFNF() != (MKIOKBMLHEO)7 && behaviour != MKIOKBMLHEO.MyWarcards && behaviour == MKIOKBMLHEO.MyWarcards;
		LIGFALGMJKN.transform.localScale = Vector3.one;
		LIGFALGMJKN.SetActive(flag);
		if (flag)
		{
			DAMGNCHFPMK.text = "alwaysShittyPerformance" + MEJMLNDFDBP.GMIPFLIEOHD(card.amount);
		}
		bool flag2 = !card.isBuddyCard || behaviour != MKIOKBMLHEO.Deposit;
		EHGOBKNHGNA.SetActive(flag2);
		if (flag2)
		{
			PLBJMGJFKGD.spriteName = card.unitTypeSpriteName;
		}
		JOPKBJMEIOB.SetActive(behaviour == MKIOKBMLHEO.Withdraw);
		CIKFGCJABCL.SetActive(KNGMKMKEFNF() == MKIOKBMLHEO.Withdraw);
		GPKNHEHAPNP.SetActive(KNGMKMKEFNF() == MKIOKBMLHEO.Other);
		DINJCFNOENO(false);
		card.SetUpSmallCard(CLPJOBOOEAK, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		AKKOEPGGEHP.SetActive(false);
		KHGENHNADOK();
		LBHJJJGBADD();
		if (IDOKGAOAGAL)
		{
			NGAAFKDPNDM = null;
		}
		card.ShowInMenu();
	}

	public void SelectForCraftingAnimation()
	{
		HDBFEDGDIGC hDBFEDGDIGC = new HDBFEDGDIGC();
		hDBFEDGDIGC.BJGCPDNMHDH = this;
		SetHighlight(true);
		FLDLKHNIIBO.alpha = 0f;
		LIGFALGMJKN.transform.localScale = Vector3.one;
		hDBFEDGDIGC.HAMKIKMJHDP = 0.15f;
		TweenScale tweenScale = TweenScale.Begin(LIGFALGMJKN, hDBFEDGDIGC.HAMKIKMJHDP, Vector3.one, new Vector3(1.3f, 1.3f, 1f));
		tweenScale.method = UITweener.Method.EaseIn;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FLDLKHNIIBO.gameObject, hDBFEDGDIGC.HAMKIKMJHDP, 0f, 1f);
		tweenAlpha.method = UITweener.Method.EaseIn;
		tweenAlpha.onFinished = hDBFEDGDIGC.LJCDGJKCNEC;
	}

	internal void LBHJJJGBADD()
	{
		UIWidget[] componentsInChildren = GetComponentsInChildren<UIWidget>(true);
		UIWidget[] array = componentsInChildren;
		foreach (UIWidget uIWidget in array)
		{
			float alpha = uIWidget.alpha;
			uIWidget.color = Color.white;
			uIWidget.alpha = alpha;
		}
		KMFGCJEGJJK.color = Card.CardBackgroundColor(card.rarity).ReplaceA(KMFGCJEGJJK.alpha);
		DILDMHKDHJH.color = card.bonusIconBackgroundColor.ReplaceA(DILDMHKDHJH.alpha);
		ADEMDNIDBJD.color = card.bonusIconColor.ReplaceA(ADEMDNIDBJD.alpha);
		CLPJOBOOEAK.color = Card.CardBackgroundColor(card.rarity).ReplaceA(CLPJOBOOEAK.alpha);
		JALFJLGBBFH.color = card.bonusIconSmallCardColor.ReplaceA(JALFJLGBBFH.alpha);
		DAMGNCHFPMK.color = Color.black.ReplaceA(DAMGNCHFPMK.alpha);
		SetHighlight(false);
		if (behaviour == MKIOKBMLHEO.Deposit)
		{
			JOPKBJMEIOB.SetActive(true);
		}
		if (behaviour == MKIOKBMLHEO.CountDownBuddy)
		{
			TweenAlpha component = GPKNHEHAPNP.GetComponent<TweenAlpha>();
			if (component != null)
			{
				if (component.enabled)
				{
					component.to = 1f;
				}
				else
				{
					UIPanel component2 = GPKNHEHAPNP.GetComponent<UIPanel>();
					if (component2 != null)
					{
						component2.alpha1 = 1f;
					}
				}
			}
		}
		AHFAAIJGPFO.color = Color.black.ReplaceA(AHFAAIJGPFO.alpha);
		AFEDBPKAJFG.color = Colours.blackDeposit.ReplaceA(AFEDBPKAJFG.alpha);
		NFBAIMKPHKP.color = Color.white.ReplaceA(NFBAIMKPHKP.alpha);
		POAMPPJOGEG = true;
	}

	private void DGPHCKIJAOM(UITweener GMCNLNOEJPP)
	{
		if (FFNGLFMCJEL())
		{
			return;
		}
		TweenPosition.Begin(base.gameObject, 1408f, Vector3.zero, false).onFinished = delegate
		{
			JCKOBELDCGD = false;
			if (!FFNGLFMCJEL())
			{
			}
		};
	}

	[CompilerGenerated]
	private void NBMOAJBNCNA(UITweener HCEGBOFCJPL)
	{
		JCKOBELDCGD = false;
		if (!FFNGLFMCJEL())
		{
		}
	}

	private void JLEEPHCHIOM(UITweener ELDBECLGFBA)
	{
		if (FFNGLFMCJEL())
		{
			return;
		}
		TweenScale tweenScale = TweenScale.Begin(base.gameObject, 995f, new Vector3(537f, 1168f, 950f));
		tweenScale.delay = 1116f;
		tweenScale.onFinished = delegate
		{
			if (!FFNGLFMCJEL())
			{
				SetInvisible();
				TweenScale tweenScale2 = TweenScale.Begin(base.gameObject, 0.05f, new Vector3(1f, 1f, 1f));
				tweenScale2.delay = 0f;
				tweenScale2.onFinished = delegate
				{
					if (!FFNGLFMCJEL())
					{
						TweenPosition.Begin(base.gameObject, 0.05f, Vector3.zero).onFinished = delegate
						{
							JCKOBELDCGD = false;
							if (!FFNGLFMCJEL())
							{
							}
						};
					}
				};
			}
		};
	}

	[SpecialName]
	public bool PJAGFKFINDB()
	{
		return JCKOBELDCGD;
	}

	private void IFHKKAPJAAD()
	{
		if (behaviour == MKIOKBMLHEO.Lobby || behaviour == MKIOKBMLHEO.CraftCards)
		{
			bool flag = behaviour == MKIOKBMLHEO.CraftCards;
			if (flag && !GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent)
			{
				return;
			}
			if (FLLODMAOGLE != null)
			{
				if (!FLLODMAOGLE.isAvailable || (card.isBuddyCard && !FLLODMAOGLE.isBuddyContainer) || (!card.isBuddyCard && FLLODMAOGLE.isBuddyContainer))
				{
					return;
				}
				if (!FLLODMAOGLE.isEmpty)
				{
					FLLODMAOGLE.RemoveCard();
				}
				if (FLLODMAOGLE.InsertCard(card))
				{
					if (flag)
					{
						SelectForCraftingAnimation();
						GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.UpdateCardRecord(card);
					}
					else
					{
						SetUnAvailable();
					}
				}
			}
			if (IENCFHPINDI != IAOAHCIDOCE.None)
			{
				return;
			}
			if (POAMPPJOGEG)
			{
				if (flag)
				{
					if (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.TryToPutCardIntoEmptyContainer(this))
					{
						SelectForCraftingAnimation();
					}
				}
				else if (GuiScreenSingle<CardSelectionScreen>.instance.TryToPutCardIntoEmptyContainer(this))
				{
					SetUnAvailable();
				}
			}
			else if (flag)
			{
				GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.TryToRemoveCardFromAnyContainer(this);
			}
			else
			{
				GuiScreenSingle<CardSelectionScreen>.instance.TryToRemoveCardFromAnyContainer(this);
			}
		}
		else if (IENCFHPINDI == IAOAHCIDOCE.None && (behaviour == MKIOKBMLHEO.Deposit || behaviour == MKIOKBMLHEO.Withdraw) && NGAAFKDPNDM != null)
		{
			NGAAFKDPNDM(this);
		}
	}

	private void HGFPMEHBLAI(UITweener ALOMHALCMNH)
	{
		KHGENHNADOK();
		FDPONIBIADO.alpha = 1908f;
		TweenAlpha.Begin(FDPONIBIADO.gameObject, 289f, 425f, 393f);
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, 1990f, Quaternion.Euler(1164f, 1962f, 852f), true);
		tweenRotation.delay = 1085f;
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			cardFlipped = true;
		});
	}

	[SpecialName]
	private void ICIHJEKOOJI(bool IDEBKDPMPGM)
	{
		_003CPGBELEAFDBF_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void CPNJHFDPOIM(bool NABOFKMBMKH)
	{
		EOGFCADHLMC.SetActive(NABOFKMBMKH);
		bool flag = behaviour == MKIOKBMLHEO.CraftCards;
		FLDLKHNIIBO.color = ((!flag) ? Colours.blue : Colours.pink);
	}

	private void HGBPPBFFEGK()
	{
		KMFGCJEGJJK.alpha = 1f;
		BOFBOGHBKLC.alpha = 1f;
		EJLICNDCAAH.alpha = 1f;
		if (DPMLMAOJPNL.gameObject.activeSelf)
		{
			DPMLMAOJPNL.alpha = 1f;
		}
		if (PJEPGKLGMLO.gameObject.activeSelf)
		{
			PJEPGKLGMLO.alpha = 1f;
		}
		if (ADEMDNIDBJD.gameObject.activeSelf)
		{
			ADEMDNIDBJD.alpha = 1f;
			DILDMHKDHJH.alpha = 1f;
			NINBBGJCEEO.alpha = 1f;
		}
		FIDIEPCJLMF.alpha1 = 1f;
		DAJGMLGJOBG.enabled = false;
	}

	[CompilerGenerated]
	private void AECLNFAEFLE(UITweener GMCNLNOEJPP)
	{
		if (FFNGLFMCJEL())
		{
			return;
		}
		TweenPosition.Begin(base.gameObject, 0.05f, Vector3.zero).onFinished = delegate
		{
			JCKOBELDCGD = false;
			if (!FFNGLFMCJEL())
			{
			}
		};
	}

	public void SetUnAvailable()
	{
		UIWidget[] componentsInChildren = GetComponentsInChildren<UIWidget>(true);
		UIWidget[] array = componentsInChildren;
		foreach (UIWidget uIWidget in array)
		{
			float alpha = uIWidget.alpha;
			uIWidget.color = Color.grey;
			uIWidget.alpha = alpha;
		}
		KMFGCJEGJJK.color = (Card.CardBackgroundColor(card.rarity) * Color.grey).ReplaceA(KMFGCJEGJJK.alpha);
		DILDMHKDHJH.color = (card.bonusIconBackgroundColor * Color.grey).ReplaceA(DILDMHKDHJH.alpha);
		ADEMDNIDBJD.color = (card.bonusIconColor * Color.grey).ReplaceA(ADEMDNIDBJD.alpha);
		CLPJOBOOEAK.color = (Card.CardBackgroundColor(card.rarity) * Color.grey).ReplaceA(CLPJOBOOEAK.alpha);
		JALFJLGBBFH.color = (card.bonusIconSmallCardColor * Color.grey).ReplaceA(JALFJLGBBFH.alpha);
		DAMGNCHFPMK.color = Color.black.ReplaceA(DAMGNCHFPMK.alpha);
		SetHighlight(true);
		if (behaviour == MKIOKBMLHEO.Deposit)
		{
			JOPKBJMEIOB.SetActive(false);
		}
		if (behaviour == MKIOKBMLHEO.CountDownBuddy)
		{
			TweenAlpha component = GPKNHEHAPNP.GetComponent<TweenAlpha>();
			if (component != null)
			{
				if (component.enabled)
				{
					component.to = 1f;
				}
				else
				{
					UIPanel component2 = GPKNHEHAPNP.GetComponent<UIPanel>();
					if (component2 != null)
					{
						component2.alpha1 = 1f;
					}
				}
			}
		}
		AHFAAIJGPFO.color = Color.black.ReplaceA(AHFAAIJGPFO.alpha);
		AFEDBPKAJFG.color = Colours.blackDeposit.ReplaceA(AFEDBPKAJFG.alpha);
		NFBAIMKPHKP.color = Color.white.ReplaceA(NFBAIMKPHKP.alpha);
		POAMPPJOGEG = false;
	}

	[CompilerGenerated]
	private void LEMHFFPGMLG(UITweener MGDJMGHCAAI)
	{
		cardFlipped = true;
	}

	private void LGEBGACPLAA(UITweener AHEHOHIAGOM)
	{
		if (FFNGLFMCJEL())
		{
			return;
		}
		EHBMNJJAJOA();
		TweenScale tweenScale = TweenScale.Begin(base.gameObject, 1142f, new Vector3(564f, 1932f, 1392f));
		tweenScale.delay = 219f;
		tweenScale.onFinished = delegate
		{
			if (!FFNGLFMCJEL())
			{
				TweenPosition.Begin(base.gameObject, 0.05f, Vector3.zero).onFinished = delegate
				{
					JCKOBELDCGD = false;
					if (!FFNGLFMCJEL())
					{
					}
				};
			}
		};
	}

	private void KHGENHNADOK()
	{
		KMFGCJEGJJK.alpha = 1213f;
		BOFBOGHBKLC.alpha = 177f;
		EJLICNDCAAH.alpha = 1619f;
		if (DPMLMAOJPNL.gameObject.activeSelf)
		{
			DPMLMAOJPNL.alpha = 694f;
		}
		if (PJEPGKLGMLO.gameObject.activeSelf)
		{
			PJEPGKLGMLO.alpha = 1304f;
		}
		if (ADEMDNIDBJD.gameObject.activeSelf)
		{
			ADEMDNIDBJD.alpha = 1830f;
			DILDMHKDHJH.alpha = 1918f;
			NINBBGJCEEO.alpha = 1276f;
		}
		FIDIEPCJLMF.alpha1 = 1388f;
		DAJGMLGJOBG.enabled = false;
	}

	public void KPLPHDFNDNM()
	{
		HDBFEDGDIGC hDBFEDGDIGC = new HDBFEDGDIGC();
		hDBFEDGDIGC.BJGCPDNMHDH = this;
		DINJCFNOENO(false);
		FLDLKHNIIBO.alpha = 727f;
		LIGFALGMJKN.transform.localScale = Vector3.one;
		hDBFEDGDIGC.HAMKIKMJHDP = 40f;
		TweenScale tweenScale = TweenScale.Begin(LIGFALGMJKN, hDBFEDGDIGC.HAMKIKMJHDP, Vector3.one, new Vector3(1847f, 649f, 94f));
		tweenScale.method = UITweener.Method.EaseIn;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(FLDLKHNIIBO.gameObject, hDBFEDGDIGC.HAMKIKMJHDP, 300f, 980f);
		tweenAlpha.method = UITweener.Method.Linear;
		tweenAlpha.onFinished = hDBFEDGDIGC.ILNPANOCHIH;
	}

	public void FlipBuyAnimation(int DFHAAIFFLOE)
	{
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, 0.2f, Quaternion.Euler(0f, 90f, 0f));
		tweenRotation.delay = (float)DFHAAIFFLOE * 0.35f;
		tweenRotation.onBegin = delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardFlip);
		};
		tweenRotation.onFinished = delegate
		{
			HGBPPBFFEGK();
			FDPONIBIADO.alpha = 0f;
			TweenAlpha.Begin(FDPONIBIADO.gameObject, 0.05f, 0f, 0f);
			TweenRotation tweenRotation2 = TweenRotation.Begin(base.gameObject, 0.2f, Quaternion.Euler(0f, 0f, 0f));
			tweenRotation2.delay = 0f;
			tweenRotation2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation2.onFinished, (UITweener.OnFinished)delegate
			{
				cardFlipped = true;
			});
		};
	}

	public void UnhookAndStopAllTweens()
	{
		TweenRotation.Begin(base.gameObject, 0f, Quaternion.identity);
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].onBegin = null;
			componentsInChildren[i].onFinished = null;
			componentsInChildren[i].delay = 0f;
			componentsInChildren[i].duration = 0f;
			componentsInChildren[i].enabled = false;
		}
	}

	protected void Update()
	{
		if (card.iconTexture != null && !PJEPGKLGMLO.gameObject.activeSelf)
		{
			DPMLMAOJPNL.gameObject.SetActive(false);
			PJEPGKLGMLO.gameObject.SetActive(true);
			PJEPGKLGMLO.mainTexture = card.iconTexture;
			AMPHFKILGKE.gameObject.SetActive(false);
			BIHGMGFKPLK.gameObject.SetActive(true);
			BIHGMGFKPLK.mainTexture = card.iconTexture;
		}
		if (behaviour == MKIOKBMLHEO.CountDownBuddy)
		{
			ADDICBANAAB += Time.deltaTime;
			if (ADDICBANAAB >= 0.333f)
			{
				ADDICBANAAB -= 0.333f;
				OJDKJDJOGGP();
			}
		}
	}

	protected override void Start()
	{
		base.Start();
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (uIPanel.root != null)
		{
			vector *= uIPanel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
		}
		PDIOAEBJBFH = new Vector3(vector.x / (float)Screen.width, vector.y / (float)Screen.height, 0f);
	}

	[SpecialName]
	public bool CFDKJODBIFO()
	{
		return _003CPGBELEAFDBF_003Ek__BackingField;
	}

	public virtual void MKNKCKLEHEE()
	{
		base.HPPIBGEJMNL();
		NJEAMAHEMHP.enabled = true;
	}

	public virtual void HFBCEMKNEJM()
	{
		base.OnInstancied();
		NJEAMAHEMHP.enabled = false;
	}

	[SpecialName]
	public void OFOPDHDHNHO(MKIOKBMLHEO IDEBKDPMPGM)
	{
		_003CPGHKBIDDJLI_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HECHKEBLOAN(MKIOKBMLHEO IDEBKDPMPGM)
	{
		_003CPGHKBIDDJLI_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void SetInvisible()
	{
		FDPONIBIADO.transform.localScale = Vector3.one;
		FDPONIBIADO.alpha = 0f;
		KMFGCJEGJJK.alpha = 0f;
		BOFBOGHBKLC.alpha = 0f;
		EJLICNDCAAH.alpha = 0f;
		if (DPMLMAOJPNL.gameObject.activeSelf)
		{
			DPMLMAOJPNL.alpha = 0f;
		}
		if (PJEPGKLGMLO.gameObject.activeSelf)
		{
			PJEPGKLGMLO.alpha = 0f;
		}
		if (ADEMDNIDBJD.gameObject.activeSelf)
		{
			ADEMDNIDBJD.alpha = 0f;
			DILDMHKDHJH.alpha = 0f;
			NINBBGJCEEO.alpha = 0f;
		}
		EHGOBKNHGNA.SetActive(false);
		LIGFALGMJKN.SetActive(false);
		SetHighlight(false);
	}

	[SpecialName]
	public void GGFBIEILPEI(Action<CardRecord> IDEBKDPMPGM)
	{
		Action<CardRecord> action = NGAAFKDPNDM;
		Action<CardRecord> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NGAAFKDPNDM, (Action<CardRecord>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		NJEAMAHEMHP.enabled = true;
	}

	public void OMOFBFEMGPM()
	{
		SetInvisible();
		base.transform.localRotation = Quaternion.Euler(1383f, 1197f, 1817f);
		FDPONIBIADO.alpha = 632f;
		FDPONIBIADO.MakePixelPerfect();
		FDPONIBIADO.cachedTransform.localScale = FDPONIBIADO.cachedTransform.localScale.MultiplyXY(913f);
	}

	public void Initialize(Card DFAMMMKGDOO, MKIOKBMLHEO ACLDFHJKBLI = MKIOKBMLHEO.Other, bool IDOKGAOAGAL = true)
	{
		card = DFAMMMKGDOO;
		behaviour = ACLDFHJKBLI;
		FIDIEPCJLMF.isFreezed = false;
		base.transform.localScale = Vector3.one;
		InitBigCardLook();
		bool flag = card.amount > 1 && (behaviour == MKIOKBMLHEO.Lobby || behaviour == MKIOKBMLHEO.MyWarcards || behaviour == MKIOKBMLHEO.CraftCards);
		LIGFALGMJKN.transform.localScale = Vector3.one;
		LIGFALGMJKN.SetActive(flag);
		if (flag)
		{
			DAMGNCHFPMK.text = "x" + MEJMLNDFDBP.GMIPFLIEOHD(card.amount);
		}
		bool flag2 = card.isBuddyCard && behaviour != MKIOKBMLHEO.CountDownBuddy;
		EHGOBKNHGNA.SetActive(flag2);
		if (flag2)
		{
			PLBJMGJFKGD.spriteName = card.unitTypeSpriteName;
		}
		JOPKBJMEIOB.SetActive(behaviour == MKIOKBMLHEO.Deposit);
		CIKFGCJABCL.SetActive(behaviour == MKIOKBMLHEO.Withdraw);
		GPKNHEHAPNP.SetActive(behaviour == MKIOKBMLHEO.CountDownBuddy);
		SetHighlight(false);
		card.SetUpSmallCard(CLPJOBOOEAK, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		AKKOEPGGEHP.SetActive(false);
		HGBPPBFFEGK();
		LBHJJJGBADD();
		if (IDOKGAOAGAL)
		{
			NGAAFKDPNDM = null;
		}
		card.ShowInMenu();
	}

	[CompilerGenerated]
	private void OLPEDCDOKHJ(UITweener ELDBECLGFBA)
	{
		if (FFNGLFMCJEL())
		{
			return;
		}
		TweenScale tweenScale = TweenScale.Begin(base.gameObject, 0.2f, new Vector3(0.05f, 0.05f, 1f));
		tweenScale.delay = 0.1f;
		tweenScale.onFinished = delegate
		{
			if (!FFNGLFMCJEL())
			{
				SetInvisible();
				TweenScale tweenScale2 = TweenScale.Begin(base.gameObject, 0.05f, new Vector3(1f, 1f, 1f));
				tweenScale2.delay = 0f;
				tweenScale2.onFinished = delegate
				{
					if (!FFNGLFMCJEL())
					{
						TweenPosition.Begin(base.gameObject, 0.05f, Vector3.zero).onFinished = delegate
						{
							JCKOBELDCGD = false;
							if (!FFNGLFMCJEL())
							{
							}
						};
					}
				};
			}
		};
	}

	[CompilerGenerated]
	private void APIHPLOAHGH(UITweener ALOMHALCMNH)
	{
		HGBPPBFFEGK();
		FDPONIBIADO.alpha = 0f;
		TweenAlpha.Begin(FDPONIBIADO.gameObject, 0.05f, 0f, 0f);
		TweenRotation tweenRotation = TweenRotation.Begin(base.gameObject, 0.2f, Quaternion.Euler(0f, 0f, 0f));
		tweenRotation.delay = 0f;
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			cardFlipped = true;
		});
	}

	public void JNBMNELHDEJ(bool NABOFKMBMKH)
	{
		EOGFCADHLMC.SetActive(NABOFKMBMKH);
		bool flag = KNGMKMKEFNF() == (MKIOKBMLHEO)7;
		FLDLKHNIIBO.color = ((!flag) ? Colours.blue : Colours.pink);
	}

	[SpecialName]
	public bool DDCOGGBKGOB()
	{
		return _003CPGBELEAFDBF_003Ek__BackingField;
	}

	public void IGPOLIPPGBP(Card DFAMMMKGDOO, MKIOKBMLHEO ACLDFHJKBLI = MKIOKBMLHEO.Other, bool IDOKGAOAGAL = true)
	{
		DEANDPOACAL(DFAMMMKGDOO);
		OFOPDHDHNHO(ACLDFHJKBLI);
		FIDIEPCJLMF.isFreezed = true;
		base.transform.localScale = Vector3.one;
		InitBigCardLook();
		bool flag = card.amount > 1 && (behaviour == MKIOKBMLHEO.Other || KNGMKMKEFNF() == MKIOKBMLHEO.MyWarcards || KNGMKMKEFNF() == MKIOKBMLHEO.MyWarcards);
		LIGFALGMJKN.transform.localScale = Vector3.one;
		LIGFALGMJKN.SetActive(flag);
		if (flag)
		{
			DAMGNCHFPMK.text = "ID_GUI_PLAYER" + MEJMLNDFDBP.GMIPFLIEOHD(card.amount);
		}
		bool flag2 = card.isBuddyCard && KNGMKMKEFNF() != (MKIOKBMLHEO)8;
		EHGOBKNHGNA.SetActive(flag2);
		if (flag2)
		{
			PLBJMGJFKGD.spriteName = card.unitTypeSpriteName;
		}
		JOPKBJMEIOB.SetActive(KNGMKMKEFNF() == MKIOKBMLHEO.Withdraw);
		CIKFGCJABCL.SetActive(behaviour == MKIOKBMLHEO.Withdraw);
		GPKNHEHAPNP.SetActive(behaviour == MKIOKBMLHEO.Deposit);
		CPNJHFDPOIM(true);
		card.SetUpSmallCard(CLPJOBOOEAK, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		AKKOEPGGEHP.SetActive(true);
		HBIBDGEJDPE();
		LBHJJJGBADD();
		if (IDOKGAOAGAL)
		{
			NGAAFKDPNDM = null;
		}
		card.ShowInMenu();
	}

	[SpecialName]
	public bool OGBEODPLMEH()
	{
		return _003CPGBELEAFDBF_003Ek__BackingField;
	}

	[CompilerGenerated]
	private void LHKENEKBDLG(UITweener MGDJMGHCAAI)
	{
		TweenScale tweenScale = TweenScale.Begin(AKKOEPGGEHP, 0.2f, new Vector3(1f, 1f, 1f));
		tweenScale.method = UITweener.Method.EaseOut;
	}

	[SpecialName]
	public void LFMKFNMAMJI(Action<CardRecord> IDEBKDPMPGM)
	{
		Action<CardRecord> action = NGAAFKDPNDM;
		Action<CardRecord> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref NGAAFKDPNDM, (Action<CardRecord>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void EHBMNJJAJOA()
	{
		FDPONIBIADO.transform.localScale = Vector3.one;
		FDPONIBIADO.alpha = 749f;
		KMFGCJEGJJK.alpha = 968f;
		BOFBOGHBKLC.alpha = 1726f;
		EJLICNDCAAH.alpha = 922f;
		if (DPMLMAOJPNL.gameObject.activeSelf)
		{
			DPMLMAOJPNL.alpha = 1339f;
		}
		if (PJEPGKLGMLO.gameObject.activeSelf)
		{
			PJEPGKLGMLO.alpha = 313f;
		}
		if (ADEMDNIDBJD.gameObject.activeSelf)
		{
			ADEMDNIDBJD.alpha = 1398f;
			DILDMHKDHJH.alpha = 1713f;
			NINBBGJCEEO.alpha = 483f;
		}
		EHGOBKNHGNA.SetActive(false);
		LIGFALGMJKN.SetActive(false);
		JNBMNELHDEJ(false);
	}

	[SpecialName]
	private void DEANDPOACAL(Card IDEBKDPMPGM)
	{
		_003CBPDIAPPIFGP_003Ek__BackingField = IDEBKDPMPGM;
	}
}
