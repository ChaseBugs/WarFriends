using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;
using WarFriends.Legacy;

public class SquadScreen : GuiScreenSingle<SquadScreen>
{
	public enum MPJAFCCIOEO
	{
		Member,
		Cardpool,
		Event,
		Stats,
		Emblem,
		Info
	}

	private sealed class LMLBAEALJOF
	{
		internal SquadButton DGJCAIJPEIM;

		internal bool MMEEJDGGAID(SquadButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool LJCDGJKCNEC(SquadButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool NDJOJHNIBFC(SquadButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool LGJCNCHBFDA(SquadButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}

		internal bool LHPPLGOOLEC(SquadButton HPJFBKEKJHB)
		{
			return HPJFBKEKJHB == DGJCAIJPEIM;
		}
	}

	private sealed class ILKOLBHGAMN
	{
		internal float HECJLCFJMBM;

		internal float KBJLCLKFAEB;

		internal bool JHIALFMFBMJ;

		internal bool JNFEBGFALBI;

		internal SquadScreen BJGCPDNMHDH;

		internal void MMEEJDGGAID(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.BPEAMJBCLHM(HECJLCFJMBM, KBJLCLKFAEB);
			TweenAlpha.Begin(BJGCPDNMHDH.KCBAFHJOJCP.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JHIALFMFBMJ) ? 1069f : 1574f);
			TweenAlpha.Begin(BJGCPDNMHDH.JAHOEJODKOH.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JNFEBGFALBI) ? 1162f : 1679f).onFinished = null;
		}

		internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.BPEAMJBCLHM(HECJLCFJMBM, KBJLCLKFAEB);
			TweenAlpha.Begin(BJGCPDNMHDH.KCBAFHJOJCP.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JHIALFMFBMJ) ? 1448f : 1455f);
			TweenAlpha.Begin(BJGCPDNMHDH.JAHOEJODKOH.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JNFEBGFALBI) ? 840f : 1884f).onFinished = null;
		}

		internal void OKNCFDMEFGJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.BPEAMJBCLHM(HECJLCFJMBM, KBJLCLKFAEB);
			TweenAlpha.Begin(BJGCPDNMHDH.KCBAFHJOJCP.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JHIALFMFBMJ) ? 103f : 656f);
			TweenAlpha.Begin(BJGCPDNMHDH.JAHOEJODKOH.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JNFEBGFALBI) ? 943f : 1229f).onFinished = null;
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.BPEAMJBCLHM(HECJLCFJMBM, KBJLCLKFAEB);
			TweenAlpha.Begin(BJGCPDNMHDH.KCBAFHJOJCP.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JHIALFMFBMJ) ? 0f : 1f);
			TweenAlpha.Begin(BJGCPDNMHDH.JAHOEJODKOH.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JNFEBGFALBI) ? 0f : 1f).onFinished = null;
		}

		internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.BPEAMJBCLHM(HECJLCFJMBM, KBJLCLKFAEB);
			TweenAlpha.Begin(BJGCPDNMHDH.KCBAFHJOJCP.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JHIALFMFBMJ) ? 964f : 344f);
			TweenAlpha.Begin(BJGCPDNMHDH.JAHOEJODKOH.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JNFEBGFALBI) ? 1616f : 134f).onFinished = null;
		}

		internal void ECPMEMNKMCB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.BPEAMJBCLHM(HECJLCFJMBM, KBJLCLKFAEB);
			TweenAlpha.Begin(BJGCPDNMHDH.KCBAFHJOJCP.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JHIALFMFBMJ) ? 347f : 1069f);
			TweenAlpha.Begin(BJGCPDNMHDH.JAHOEJODKOH.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JNFEBGFALBI) ? 1359f : 1011f).onFinished = null;
		}

		internal void KJIFNOJILDB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.BPEAMJBCLHM(HECJLCFJMBM, KBJLCLKFAEB);
			TweenAlpha.Begin(BJGCPDNMHDH.KCBAFHJOJCP.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JHIALFMFBMJ) ? 884f : 1366f);
			TweenAlpha.Begin(BJGCPDNMHDH.JAHOEJODKOH.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JNFEBGFALBI) ? 1805f : 1816f).onFinished = null;
		}

		internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.BPEAMJBCLHM(HECJLCFJMBM, KBJLCLKFAEB);
			TweenAlpha.Begin(BJGCPDNMHDH.KCBAFHJOJCP.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JHIALFMFBMJ) ? 928f : 157f);
			TweenAlpha.Begin(BJGCPDNMHDH.JAHOEJODKOH.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JNFEBGFALBI) ? 645f : 1536f).onFinished = null;
		}

		internal void NDJOJHNIBFC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.BPEAMJBCLHM(HECJLCFJMBM, KBJLCLKFAEB);
			TweenAlpha.Begin(BJGCPDNMHDH.KCBAFHJOJCP.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JHIALFMFBMJ) ? 1820f : 159f);
			TweenAlpha.Begin(BJGCPDNMHDH.JAHOEJODKOH.gameObject, BJGCPDNMHDH.HAMKIKMJHDP, (!JNFEBGFALBI) ? 719f : 1497f).onFinished = null;
		}
	}

	private sealed class NFFDKDNHOAN
	{
		internal DatabasePlayer KHLGDCHJJPB;

		internal void JGEMIBIJMJC(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void NNFHNIMCBLH(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void DGELDDJAEEF(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void JDEJHLLIONG(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void LJCDGJKCNEC(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void ILOFOILFGMA(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void PANKBNOCEAM(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void KNJBDOADLDO(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void LGJCNCHBFDA(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void OKNCFDMEFGJ(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void CIFEDFPPPOK(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void PPKGMGNKNAE(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void EMKPBGFBPFI(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void NAJNECOMDDN(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void AGFEDJAKLAC(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void KJIFNOJILDB(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void ILNPANOCHIH(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void FHDOHCJJEMM(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void OHLGKFGIPCC(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void ANAGFGHGPJA(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void PHGDBIEENCB(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void KPHEPHDFCKK(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void NNIJEDKBPGJ(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void MCFGAFBEJDK(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void PCKMJMGLPDG(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}

		internal void MFCNOIDCJME(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.PGKFHBDOGNA(KHLGDCHJJPB);
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		}
	}

	[Header("Not In Squad")]
	[FormerlySerializedAs("AOFAODJEHOC")]
	public GameObject IHPCMGFJPIC;

	[FormerlySerializedAs("LKMGLJDEBBO")]
	public UIGrid KBLJBDEEHJG;

	[FormerlySerializedAs("JNNONCPDICL")]
	public List<UIButtonSetter> CIPJAIDBPIH;

	[Header("-Join Existing Squad")]
	[FormerlySerializedAs("NBLEKCIMHFI")]
	public GameObject KHFOHBMDEBJ;

	[FormerlySerializedAs("DGPDMBLINGJ")]
	public BoxCollider IOHMEPJDJMH;

	[FormerlySerializedAs("KIAMBDAJHHH")]
	public GameObject MEMKHHLCIDH;

	[FormerlySerializedAs("ACPABKDAAEN")]
	public GameObject PNBKGHMDKBJ;

	[FormerlySerializedAs("GCHIKMOPEHO")]
	public UILabel NPNIDIGGPGI;

	[FormerlySerializedAs("EPFLOKIHNEC")]
	public UILabel CKDIMHJAKNF;

	[FormerlySerializedAs("OGILAFHBOPN")]
	public GameObject CPKIKJFFOBG;

	[FormerlySerializedAs("MMOAFJMBJKP")]
	public UILabel PGKOEEPPFJH;

	[FormerlySerializedAs("HAIFOPDPNJF")]
	[Header("-Create New Squad")]
	public GameObject DGBFJNCGAFG;

	[FormerlySerializedAs("HMJDHCDLHHI")]
	public BoxCollider CLIOPGGILNE;

	[FormerlySerializedAs("EHANPHLIKJE")]
	public UISprite LMFGLDGDNEO;

	[FormerlySerializedAs("EFBNFILLOMP")]
	public GameObject DEBNKFCDENN;

	[FormerlySerializedAs("JJJKKKPKLHA")]
	public UILabel GDDFNCHCFKN;

	[FormerlySerializedAs("LIMDJDKPLAG")]
	public UILabel MAECEAGKNFK;

	[FormerlySerializedAs("EMLKGPOEABG")]
	public GameObject JBOHFMAPCJL;

	[FormerlySerializedAs("AIGGCKDHKKK")]
	public UILabel BHKJDMAKFPP;

	[Header("-Bottom")]
	[FormerlySerializedAs("CLNMOGGCBFJ")]
	public UISprite KLGIDHKOEJP;

	[FormerlySerializedAs("ELCKDFIGOGP")]
	public UILabel JKJOBGEEOOK;

	[FormerlySerializedAs("HNDHKFBDJFJ")]
	public UISprite BPMPGAIDHKM;

	[FormerlySerializedAs("LKALFHLDCKB")]
	public GameObject[] BIAIJJAAMCJ;

	[FormerlySerializedAs("MBBALLMOOKD")]
	public UITable GJNALLCCFBB;

	[FormerlySerializedAs("JNPFDGOMPME")]
	public UILabel[] FLFKPIGBDAO;

	[Header("In Squad")]
	[FormerlySerializedAs("GFHACIGCDBN")]
	public GameObject AEFCKOJAOPK;

	[FormerlySerializedAs("IBNCFLJBFPM")]
	public GameObject FLGDNCDLADK;

	[FormerlySerializedAs("DHLEEIMJPGN")]
	[Header("-Header")]
	public UITable PJBNCLAPNEL;

	[FormerlySerializedAs("HLIHJDECJAO")]
	public UITexture GEAGOKJMJFD;

	[FormerlySerializedAs("OFOMNJAPIBJ")]
	public UILabel CGIFEHPDBAL;

	[FormerlySerializedAs("AEKKMNEKKJC")]
	public BoxCollider CFGGNFGPFNG;

	[FormerlySerializedAs("PJPKLMIFPLL")]
	public UILabel AJLAHIKGBML;

	[FormerlySerializedAs("MNADFHLFJJH")]
	public GameObject EACEICOJEED;

	[FormerlySerializedAs("GOHJCLHKAAL")]
	public GameObject GFAIEMEPGNA;

	[FormerlySerializedAs("DNJAOIBLONG")]
	public GameObject KDOHHIBFBIN;

	[FormerlySerializedAs("LJKEEGAJCKL")]
	public UISprite HFFEDJGKHLJ;

	[Header("-Squad Buttons")]
	[FormerlySerializedAs("EHFHOFOIBNI")]
	public UITable LHKLOFBMPGN;

	[FormerlySerializedAs("AMAKKFNBLIF")]
	public List<SquadButton> EIGENHGGBEB;

	[FormerlySerializedAs("CGCMIHGACLK")]
	public UISprite KCBAFHJOJCP;

	[FormerlySerializedAs("LHDLJBHFHEN")]
	public UISprite JAHOEJODKOH;

	[FormerlySerializedAs("EFLOFHDHKPA")]
	public SquadButtonCardpool LMNDLIKKJHE;

	[Header("Contents")]
	[FormerlySerializedAs("LBLAKCIFILA")]
	public SquadMemberContent BBNLILBDOEC;

	[FormerlySerializedAs("IJNCCKFKCJE")]
	public SquadCardpoolContent FCIOFJOCLPJ;

	public SquadEventContent NILIEMMOFNN;

	[FormerlySerializedAs("JBNFFHEGAJH")]
	public SquadStatsContent PEBBFADKJFC;

	[FormerlySerializedAs("MJMGNMNPJKE")]
	public SquadIconContent BAJAOALGHMK;

	[FormerlySerializedAs("LMFNIBMILHI")]
	public SquadInformationContent GHINFPBNJFC;

	[Header("Debug")]
	[FormerlySerializedAs("DEBIPGKNOMM")]
	public GameObject LALBOLDIPHP;

	[FormerlySerializedAs("MFOENJCNNCE")]
	public GameObject HIOONEIFKMF;

	[FormerlySerializedAs("GFPGAOABMDF")]
	public readonly float HAMKIKMJHDP = 0.2f;

	private MPJAFCCIOEO FIDMHHGBLOE;

	private bool IBCIOGABEEA = true;

	private string LCLNBHPNCIK;

	private List<Vector3> BALKDDLMLBD = new List<Vector3>
	{
		new Vector3(-860f, 0f, 0f),
		new Vector3(40f, 0f, 0f),
		new Vector3(-860f, -68f, 0f),
		new Vector3(40f, -68f, 0f),
		new Vector3(-860f, -136f, 0f),
		new Vector3(40f, -136f, 0f)
	};

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> LGJCBPOPCPA;

	[CompilerGenerated]
	private static Action<DatabasePlayer, bool> CCNLMGEJBIB;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> KBAICANEKOP;

	[CompilerGenerated]
	private static Predicate<DatabasePlayer> AOPBBLDIOCI;

	public UIDraggablePanel selectedDragablePanel
	{
		get
		{
			if (FIDMHHGBLOE == MPJAFCCIOEO.Event)
			{
				return NILIEMMOFNN.NFLPPGKCOBL;
			}
			if (FIDMHHGBLOE == MPJAFCCIOEO.Stats)
			{
				return PEBBFADKJFC.NFLPPGKCOBL;
			}
			if (FIDMHHGBLOE == MPJAFCCIOEO.Emblem)
			{
				return BAJAOALGHMK.NFLPPGKCOBL;
			}
			if (FIDMHHGBLOE == MPJAFCCIOEO.Cardpool)
			{
				return FCIOFJOCLPJ.NFLPPGKCOBL;
			}
			return BBNLILBDOEC.NFLPPGKCOBL;
		}
	}

	private void CBPGFLELNFL(bool PDPDGCNHCFN)
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = EIGENHGGBEB[(int)FIDMHHGBLOE].AOAMKOOINKG();
		float num2 = EIGENHGGBEB[(int)FIDMHHGBLOE].CHPFAOAFCIG();
		float num3 = num - num2 / 373f;
		float num4 = num + num2 / 559f;
		float hECJLCFJMBM = Mathf.Max(1950f, 607f + num3 - 1954f);
		float kBJLCLKFAEB = Mathf.Max(747f, 120f + (activeWidthSafe - num4) - 1794f);
		bool jHIALFMFBMJ = false;
		bool jNFEBGFALBI = activeWidthSafe - num4 - 985f > 706f;
		GOCJIMAFNBK(jHIALFMFBMJ, hECJLCFJMBM, jNFEBGFALBI, kBJLCLKFAEB, PDPDGCNHCFN);
	}

	private void LJMBPOCMBJF(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !CPKIKJFFOBG.activeSelf)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		BBNLILBDOEC.InstantHideTab();
		FCIOFJOCLPJ.InstantHideTab();
		NILIEMMOFNN.InstantHideTab();
		PEBBFADKJFC.InstantHideTab();
		BAJAOALGHMK.InstantHideTab();
		GHINFPBNJFC.InstantHideTab();
		CardManager.instance.ResetSquadCards(GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.messageBuddies);
		GEAGOKJMJFD.mainTexture = null;
		LCLNBHPNCIK = null;
	}

	public virtual void LJEBBJFIHFD()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.DGPKFLNLFDD(OnSquadUpdateReceived);
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BBNKOAKBGGE);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += CEDECAHKEIP;
		GameLoginManager.instance.PlayerJoinedSquad += EAGNKKCFHHK;
		GameLoginManager.instance.PlayerLeftSquad += EFJPKEBNMBG;
		CardManager.instance.WithdrawTimeChanged += CardpoolNotifications;
		Singleton<NotificationManager>.instance.CardpoolNotificationChanged += CardpoolNotifications;
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.MPDPBMIAEMP = (Action)Delegate.Combine(serverResultsCache.MPDPBMIAEMP, new Action(MDIHOPBIFJA));
	}

	private void BHPHFADPDDO(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !CPKIKJFFOBG.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	private void BGBNBLAKICB()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = activeWidthSafe / 2f - 167f;
		foreach (UIButtonSetter item in CIPJAIDBPIH)
		{
			item.SetWidth(num);
		}
		KBLJBDEEHJG.transform.localPosition = KBLJBDEEHJG.transform.localPosition.ReplaceX(0f - (num / 2f + 107f));
		KBLJBDEEHJG.cellWidth = num / 2f + 107f;
		EACEICOJEED.transform.localPosition = EACEICOJEED.transform.localPosition.ReplaceX(activeWidthSafe);
	}

	private void CCKMKDLGOMO(string CGIFEHPDBAL)
	{
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
	}

	private static bool IIBIPICFACJ(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	[CompilerGenerated]
	private void MGEKABOAKGB(UITweener MGDJMGHCAAI)
	{
		EIGENHGGBEB[(int)FIDMHHGBLOE].Animate(PAPEDLBKBGM: true);
	}

	private void BPEAMJBCLHM()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float posX = EIGENHGGBEB[(int)FIDMHHGBLOE].posX;
		float width = EIGENHGGBEB[(int)FIDMHHGBLOE].width;
		float num = posX - width / 2f;
		float num2 = posX + width / 2f;
		float hECJLCFJMBM = Mathf.Max(28f, 28f + num - 60f);
		float kBJLCLKFAEB = Mathf.Max(28f, 28f + (activeWidthSafe - num2) - 60f);
		BPEAMJBCLHM(hECJLCFJMBM, kBJLCLKFAEB);
	}

	private void CEPGKMBDLPP(AANECPGDMGM MIDDFOCJJOP)
	{
		if (MIDDFOCJJOP == null)
		{
			BBFLANGMBJG();
			Debug.LogError("com.google.android.apps.youtube.gaming");
			return;
		}
		HIHOANALHPH();
		MLFJPFBEMIJ(MIDDFOCJJOP.DAANKCOLJGJ);
		CGIFEHPDBAL.text = GameLoginManager.currentPlayer.squadName;
		ONOKPKEOGJO();
		PJBNCLAPNEL.repositionNow = true;
		MDIHOPBIFJA();
		SetMembersButton(MIDDFOCJJOP.FOICGJEPBGL, MIDDFOCJJOP.FOICGJEPBGL + MIDDFOCJJOP.JODOHNCDJNC(), 1);
		GEDJLHKCCCA();
		CardpoolNotifications();
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		LMNDLIKKJHE.DCOBJGDBFAK(isWarcardsLocked);
		if (isWarcardsLocked && FIDMHHGBLOE == MPJAFCCIOEO.Member)
		{
			FIDMHHGBLOE = MPJAFCCIOEO.Member;
		}
		if (IBCIOGABEEA)
		{
			IBCIOGABEEA = true;
			HJKLHKGHCJK(FIDMHHGBLOE);
		}
	}

	private void DMLPBGJGCPH(bool PDPDGCNHCFN)
	{
		if (PDPDGCNHCFN)
		{
			for (int i = 0; i < EIGENHGGBEB.Count; i += 0)
			{
				EIGENHGGBEB[i].FILEBFGKKDA(i == (int)FIDMHHGBLOE);
			}
			return;
		}
		EIGENHGGBEB[1].KIBNCDGOLJD(PAPEDLBKBGM: true);
		EIGENHGGBEB[1].LAHIJFMLODM(PAPEDLBKBGM: true);
		if (EIGENHGGBEB[4].gameObject.activeSelf)
		{
			EIGENHGGBEB[6].CGNAGNAOEJA(PAPEDLBKBGM: false);
		}
		EIGENHGGBEB[0].HEBAICIOOOJ(PAPEDLBKBGM: false);
		EIGENHGGBEB[8].BOFICLOIGDJ(PAPEDLBKBGM: false);
		EIGENHGGBEB[1].IPNKGKNJOLO(PAPEDLBKBGM: true).onFinished = delegate
		{
			EIGENHGGBEB[(int)FIDMHHGBLOE].Animate(PAPEDLBKBGM: true);
		};
	}

	private void IMKKLAKPIIN()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		int cEHFMMJHCKC = (int)activeWidthSafe - 136;
		JKJOBGEEOOK.text = Localization.Localize(" 1\u00a0{0}");
		MEJMLNDFDBP.COCBCFKJOJE(JKJOBGEEOOK, 181f, 1226f, cEHFMMJHCKC);
		float num = JKJOBGEEOOK.relativeSize.x * JKJOBGEEOOK.transform.localScale.x;
		float val = Mathf.Max(1848f, (activeWidthSafe - (num + 101f)) / 1083f);
		float num2 = activeWidthSafe / 555f - 277f;
		KLGIDHKOEJP.transform.localPosition = KLGIDHKOEJP.transform.localPosition.ReplaceX(0f - num2);
		BPMPGAIDHKM.transform.localPosition = BPMPGAIDHKM.transform.localPosition.ReplaceX(num2);
		KLGIDHKOEJP.transform.localScale = KLGIDHKOEJP.transform.localScale.ReplaceX(val);
		BPMPGAIDHKM.transform.localScale = BPMPGAIDHKM.transform.localScale.ReplaceX(val);
		BIAIJJAAMCJ[1].transform.localPosition = BALKDDLMLBD[1];
		BIAIJJAAMCJ[1].transform.localPosition = BALKDDLMLBD[0];
		BIAIJJAAMCJ[0].transform.localPosition = BALKDDLMLBD[1];
		BIAIJJAAMCJ[8].transform.localPosition = BALKDDLMLBD[2];
		BIAIJJAAMCJ[2].transform.localPosition = BALKDDLMLBD[2];
		BIAIJJAAMCJ[7].transform.localPosition = BALKDDLMLBD[0];
		float num3 = activeWidthSafe / 491f - 419f;
		FLFKPIGBDAO[0].text = Localization.Localize("PlacementMatchesRequired");
		float num4 = 911f + FLFKPIGBDAO[1].relativeSize.x * FLFKPIGBDAO[1].transform.localScale.x;
		FLFKPIGBDAO[0].lineWidth = (int)(num3 - num4);
		FLFKPIGBDAO[7].lineWidth = (int)num3;
		FLFKPIGBDAO[5].lineWidth = (int)num3;
		FLFKPIGBDAO[2].lineWidth = (int)num3;
		FLFKPIGBDAO[7].lineWidth = (int)num3;
		FLFKPIGBDAO[4].lineWidth = (int)num3;
	}

	private void BBNKOAKBGGE(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.CreateAccount:
		{
			WaitingDialog.NDJPJBDKANE();
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			if (!string.IsNullOrEmpty(currentPlayer.squadName))
			{
				AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName);
				if (aANECPGDMGM == null)
				{
					aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, NICBOKPIBIA: true);
				}
				if (aANECPGDMGM != null)
				{
					CEPGKMBDLPP(aANECPGDMGM);
				}
				else
				{
					InitGUIValues();
				}
			}
			else
			{
				InitGUIValues();
			}
			break;
		}
		case (DatabaseAction)(-60):
			GEDJLHKCCCA();
			break;
		}
	}

	public void KCDJKHMIALH(int GKBPHAGAKAE, int BHGMAEOMLHG, int CIFCDKNDABO)
	{
		SquadButtonSpecial squadButtonSpecial = EIGENHGGBEB[0] as SquadButtonSpecial;
		if (squadButtonSpecial != null)
		{
			squadButtonSpecial.DAAEFHCDFLD(string.Format(" ", GKBPHAGAKAE, BHGMAEOMLHG), FIDMHHGBLOE == MPJAFCCIOEO.Member, IBCIOGABEEA);
			squadButtonSpecial.NOEKLAKCGBG(CIFCDKNDABO);
			if (CIFCDKNDABO == 0)
			{
				LHKLOFBMPGN.repositionNow = true;
			}
		}
	}

	public void GBEIDJEFEEC(GameObject KHAHPAKDIKE)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, NICBOKPIBIA: true);
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.IGGCEILJEFM(null, Localization.Localize("DogTagCap"), Localization.Localize("Scraps"));
		}
		else if (aANECPGDMGM.FOICGJEPBGL == 1)
		{
			ConfirmDialog.LGANINAGPLB(Localization.Localize("Excel {0} dont have row Tier!!!"), Localization.Localize("ChallengedPlayerId"), HIAFMACHJHB, 283f);
		}
		else if (currentPlayer.squadRank == SquadRank.Veteran)
		{
			SelectSquadLeaderDialog.EHIJFLMHEBJ(EKPFJBJNEOE, GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL);
		}
		else
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize("discount"), Localization.Localize("url "), FKJIIMHEPGL, 1277f);
		}
	}

	public virtual void KOJLOBAIPFP()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.SquadUpdateReceived += OnSquadUpdateReceived;
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(BBNKOAKBGGE);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		GameLoginManager.instance.PlayerJoinedSquad += CCKMKDLGOMO;
		GameLoginManager.instance.PlayerLeftSquad += EFJPKEBNMBG;
		CardManager.instance.WithdrawTimeChanged += CardpoolNotifications;
		Singleton<NotificationManager>.instance.LKBGGDCKLEJ(CardpoolNotifications);
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.MPDPBMIAEMP = (Action)Delegate.Combine(serverResultsCache.MPDPBMIAEMP, new Action(MDIHOPBIFJA));
	}

	public void LCNKLOJCIIO()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Member;
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(this);
		}
	}

	private void JBMHHEJPADG(bool PDPDGCNHCFN)
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float posX = EIGENHGGBEB[(int)FIDMHHGBLOE].posX;
		float width = EIGENHGGBEB[(int)FIDMHHGBLOE].width;
		float num = posX - width / 2f;
		float num2 = posX + width / 2f;
		float hECJLCFJMBM = Mathf.Max(28f, 28f + num - 60f);
		float kBJLCLKFAEB = Mathf.Max(28f, 28f + (activeWidthSafe - num2) - 60f);
		bool jHIALFMFBMJ = true;
		bool jNFEBGFALBI = activeWidthSafe - num2 - 60f > 0f;
		GOCJIMAFNBK(jHIALFMFBMJ, hECJLCFJMBM, jNFEBGFALBI, kBJLCLKFAEB, PDPDGCNHCFN);
	}

	private void FCFEMFFJIBH()
	{
		Vector3 vector = new Vector3(1114f, 1017f, 553f);
		TweenScale tweenScale = TweenScale.Begin(HFFEDJGKHLJ.gameObject, 876f, vector, vector.MultiplyXY(1240f));
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.NumOfRepetitions = 1;
	}

	private void CJIEFKAHCGD(AANECPGDMGM MIDDFOCJJOP)
	{
		if (MIDDFOCJJOP == null)
		{
			BBFLANGMBJG();
			Debug.LogError("Squad was deleted.");
			return;
		}
		HIHOANALHPH();
		SetSquadIcon(MIDDFOCJJOP.DAANKCOLJGJ);
		CGIFEHPDBAL.text = GameLoginManager.currentPlayer.squadName;
		HGOBOKCMFON();
		PJBNCLAPNEL.repositionNow = true;
		MDIHOPBIFJA();
		SetMembersButton(MIDDFOCJJOP.FOICGJEPBGL, MIDDFOCJJOP.FOICGJEPBGL + MIDDFOCJJOP.MGDCJLAENHG(), 0);
		GEDJLHKCCCA();
		CardpoolNotifications();
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		LMNDLIKKJHE.SetLocked(isWarcardsLocked);
		if (isWarcardsLocked && FIDMHHGBLOE == MPJAFCCIOEO.Cardpool)
		{
			FIDMHHGBLOE = MPJAFCCIOEO.Member;
		}
		if (IBCIOGABEEA)
		{
			IBCIOGABEEA = false;
			HJKLHKGHCJK(FIDMHHGBLOE, PDPDGCNHCFN: true);
		}
	}

	private void AGPEPAOGGFC(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !CPKIKJFFOBG.activeSelf)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	private void BBFLANGMBJG()
	{
		HIHOANALHPH();
		CCODCFHJCAM();
	}

	private void DCIDANCBHEH(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<LeaguesScreen>.instance.ShowSquadWars();
	}

	public void ShowSquadInfo()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Info;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	private void JKNABGNKBLE(string CGIFEHPDBAL)
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private static void BBIFKJLKHIP(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
		}
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == DatabaseAction.GetSquadDetails)
		{
			Debug.LogError("Server Error, no squad details");
			InitGUIValues();
		}
	}

	private void ELEOEEAHJPH(bool PDPDGCNHCFN)
	{
		if (PDPDGCNHCFN)
		{
			for (int i = 1; i < EIGENHGGBEB.Count; i++)
			{
				EIGENHGGBEB[i].GEBGEODICAE(i == (int)FIDMHHGBLOE);
			}
			return;
		}
		EIGENHGGBEB[0].HODJNFBKFHC(PAPEDLBKBGM: true);
		EIGENHGGBEB[0].CGNAGNAOEJA(PAPEDLBKBGM: false);
		if (EIGENHGGBEB[1].gameObject.activeSelf)
		{
			EIGENHGGBEB[7].LAHIJFMLODM(PAPEDLBKBGM: true);
		}
		EIGENHGGBEB[6].DANJCHNBGJF(PAPEDLBKBGM: false);
		EIGENHGGBEB[2].IPNKGKNJOLO(PAPEDLBKBGM: true);
		EIGENHGGBEB[2].ANEFFNMMALL(PAPEDLBKBGM: false).onFinished = delegate
		{
			EIGENHGGBEB[(int)FIDMHHGBLOE].Animate(PAPEDLBKBGM: true);
		};
	}

	[CompilerGenerated]
	private static bool DDOCFIEOBHD(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		FCIOFJOCLPJ.NFLPPGKCOBL.onePanelDisabled = false;
		NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = false;
		PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
		IBCIOGABEEA = true;
	}

	public void CHGEFIFKNOB()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Cardpool;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(this);
		}
	}

	private void KNNADMFOKFH(GameObject KHAHPAKDIKE)
	{
		LMLBAEALJOF lMLBAEALJOF = new LMLBAEALJOF();
		lMLBAEALJOF.DGJCAIJPEIM = (SquadButton)SingletonSupport.FirstOrDefault((UnityEngine.Object[])KHAHPAKDIKE.GetComponentsInChildren<SquadButton>(includeInactive: true));
		int num = EIGENHGGBEB.FindIndex(lMLBAEALJOF.LJCDGJKCNEC);
		if (num >= 1 && !EIGENHGGBEB[num].GBGMJPILIJG())
		{
			HJKLHKGHCJK((MPJAFCCIOEO)num, PDPDGCNHCFN: true);
		}
	}

	public void MLFJPFBEMIJ(string PCDMKLAJINM)
	{
		if (LCLNBHPNCIK != PCDMKLAJINM)
		{
			Debug.Log(string.Format("WaitTime", PCDMKLAJINM));
			GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("ID_STATE_DISCONNECTED" + PCDMKLAJINM);
			LCLNBHPNCIK = PCDMKLAJINM;
		}
		else
		{
			Debug.Log(string.Format("Connection", PCDMKLAJINM));
		}
	}

	private void EKOFHHFAPCI(GameObject KHAHPAKDIKE)
	{
		LMLBAEALJOF lMLBAEALJOF = new LMLBAEALJOF();
		lMLBAEALJOF.DGJCAIJPEIM = (SquadButton)SingletonSupport.FirstOrDefault((UnityEngine.Object[])KHAHPAKDIKE.GetComponentsInChildren<SquadButton>(includeInactive: true));
		int num = EIGENHGGBEB.FindIndex(lMLBAEALJOF.LJCDGJKCNEC);
		if (num >= 0 && !EIGENHGGBEB[num].pressed)
		{
			HJKLHKGHCJK((MPJAFCCIOEO)num);
		}
	}

	private void BDIICHCECFP()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void NHELGDJHDHP()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		int cEHFMMJHCKC = (int)activeWidthSafe - 220;
		JKJOBGEEOOK.text = Localization.Localize("ID_JOINORCREATESQUADHINT");
		MEJMLNDFDBP.COCBCFKJOJE(JKJOBGEEOOK, 47f, 20f, cEHFMMJHCKC);
		float num = JKJOBGEEOOK.relativeSize.x * JKJOBGEEOOK.transform.localScale.x;
		float val = Mathf.Max(25f, (activeWidthSafe - (num + 160f)) / 2f);
		float num2 = activeWidthSafe / 2f - 60f;
		KLGIDHKOEJP.transform.localPosition = KLGIDHKOEJP.transform.localPosition.ReplaceX(0f - num2);
		BPMPGAIDHKM.transform.localPosition = BPMPGAIDHKM.transform.localPosition.ReplaceX(num2);
		KLGIDHKOEJP.transform.localScale = KLGIDHKOEJP.transform.localScale.ReplaceX(val);
		BPMPGAIDHKM.transform.localScale = BPMPGAIDHKM.transform.localScale.ReplaceX(val);
		BIAIJJAAMCJ[0].transform.localPosition = BALKDDLMLBD[0];
		BIAIJJAAMCJ[1].transform.localPosition = BALKDDLMLBD[1];
		BIAIJJAAMCJ[2].transform.localPosition = BALKDDLMLBD[2];
		BIAIJJAAMCJ[3].transform.localPosition = BALKDDLMLBD[3];
		BIAIJJAAMCJ[4].transform.localPosition = BALKDDLMLBD[4];
		BIAIJJAAMCJ[5].transform.localPosition = BALKDDLMLBD[5];
		float num3 = activeWidthSafe / 2f - 160f;
		FLFKPIGBDAO[0].text = Localization.Localize("ID_GETSP");
		float num4 = 74f + FLFKPIGBDAO[0].relativeSize.x * FLFKPIGBDAO[0].transform.localScale.x;
		FLFKPIGBDAO[1].lineWidth = (int)(num3 - num4);
		FLFKPIGBDAO[2].lineWidth = (int)num3;
		FLFKPIGBDAO[3].lineWidth = (int)num3;
		FLFKPIGBDAO[4].lineWidth = (int)num3;
		FLFKPIGBDAO[5].lineWidth = (int)num3;
		FLFKPIGBDAO[6].lineWidth = (int)num3;
	}

	private void CEDECAHKEIP(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed && IFGAGNBDKBE == (DatabaseAction)50)
		{
			Debug.LogError("Start");
			InitGUIValues();
		}
	}

	private void BPEAMJBCLHM(float HECJLCFJMBM, float KBJLCLKFAEB)
	{
		KCBAFHJOJCP.transform.localScale = new Vector3(HECJLCFJMBM, KCBAFHJOJCP.transform.localScale.y, 0f);
		JAHOEJODKOH.transform.localScale = new Vector3(KBJLCLKFAEB, JAHOEJODKOH.transform.localScale.y, 0f);
	}

	public void ShowSquadStats()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Stats;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("View_Stats");
	}

	private void CCODCFHJCAM()
	{
		int joinSquadUnlockLevel = LevelManager.instance.joinSquadUnlockLevel;
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool flag = LevelManager.instance.currentLevel.displayNumber < joinSquadUnlockLevel;
		bool flag2 = LevelManager.instance.currentLevel.displayNumber < createSquadUnlockLevel;
		bool flag3 = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.GoldRewardFirstTimeSquad);
		MEMKHHLCIDH.transform.localPosition = MEMKHHLCIDH.transform.localPosition.ReplaceX((!flag3) ? (-100f) : 0f);
		PNBKGHMDKBJ.SetActive(!flag3);
		LMFGLDGDNEO.transform.localPosition = LMFGLDGDNEO.transform.localPosition.ReplaceX((!flag3) ? 50f : 0f);
		DEBNKFCDENN.SetActive(!flag3);
		if (!flag3)
		{
			NPNIDIGGPGI.text = Localization.Localize("ID_SQUADREWARDGET");
			MEJMLNDFDBP.COCBCFKJOJE(NPNIDIGGPGI, 89f, 30f, 280);
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).FLOATVALUE;
			CKDIMHJAKNF.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			GDDFNCHCFKN.text = Localization.Localize("ID_SQUADREWARDGET");
			MEJMLNDFDBP.COCBCFKJOJE(GDDFNCHCFKN, 89f, 30f, 280);
			MAECEAGKNFK.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
		bool flag4 = !flag;
		bool flag5 = !flag2;
		IOHMEPJDJMH.enabled = flag4;
		CLIOPGGILNE.enabled = flag5;
		PGKOEEPPFJH.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), joinSquadUnlockLevel);
		BHKJDMAKFPP.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), createSquadUnlockLevel);
		CPKIKJFFOBG.SetActive(flag);
		JBOHFMAPCJL.SetActive(flag2);
		if (FLFKPIGBDAO[0].transform.localScale.x != FLFKPIGBDAO[1].transform.localScale.x)
		{
			FLFKPIGBDAO[0].transform.localScale = FLFKPIGBDAO[1].transform.localScale;
			GJNALLCCFBB.repositionNow = true;
		}
	}

	private void ONOKPKEOGJO()
	{
		float num = AJLAHIKGBML.relativeSize.x * AJLAHIKGBML.transform.localScale.x;
		CFGGNFGPFNG.size = CFGGNFGPFNG.size.ReplaceX(1811f + num);
		CFGGNFGPFNG.center = CFGGNFGPFNG.center.ReplaceX((1524f + num) / 601f - 1625f);
	}

	private void FMACDIAACGM()
	{
		TweenScale tweenScale = TweenScale.Begin(scale: new Vector3(96f, 96f, 1f), go: HFFEDJGKHLJ.gameObject, duration: 0.2f);
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
	}

	private static void EKPFJBJNEOE(DatabasePlayer KHLGDCHJJPB, bool NILPBCGHEDG)
	{
		NFFDKDNHOAN nFFDKDNHOAN = new NFFDKDNHOAN();
		nFFDKDNHOAN.KHLGDCHJJPB = KHLGDCHJJPB;
		if (NILPBCGHEDG)
		{
			string oKMNFHNBMFA = Localization.Localize(">");
			object[] array = new object[1];
			array[1] = nFFDKDNHOAN.KHLGDCHJJPB.name;
			ConfirmDialog.HMBAPGGLPLC(oKMNFHNBMFA, Localization.LocalizeFormat("LEAVING ARENA BATTLE", array), nFFDKDNHOAN.OKNCFDMEFGJ, 1948f);
		}
	}

	private static void HIAFMACHJHB(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
		}
	}

	private void NPGBCBIFOPD()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = activeWidthSafe / 1714f - 1770f;
		foreach (UIButtonSetter item in CIPJAIDBPIH)
		{
			item.EGNOJHEGNCC(num);
		}
		KBLJBDEEHJG.transform.localPosition = KBLJBDEEHJG.transform.localPosition.ReplaceX(0f - (num / 247f + 690f));
		KBLJBDEEHJG.cellWidth = num / 1340f + 1321f;
		EACEICOJEED.transform.localPosition = EACEICOJEED.transform.localPosition.ReplaceX(activeWidthSafe);
	}

	private void HGOBOKCMFON()
	{
		float num = AJLAHIKGBML.relativeSize.x * AJLAHIKGBML.transform.localScale.x;
		CFGGNFGPFNG.size = CFGGNFGPFNG.size.ReplaceX(100f + num);
		CFGGNFGPFNG.center = CFGGNFGPFNG.center.ReplaceX((100f + num) / 2f - 30f);
	}

	private void DFKMJEJMJFF(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !JBOHFMAPCJL.activeSelf)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	private void ADAOHOIBJBO(bool PDPDGCNHCFN)
	{
		if (PDPDGCNHCFN)
		{
			for (int i = 1; i < EIGENHGGBEB.Count; i++)
			{
				EIGENHGGBEB[i].LNNFGHIHBCF(i == (int)FIDMHHGBLOE);
			}
			return;
		}
		EIGENHGGBEB[1].IIHMBOEGCOH(PAPEDLBKBGM: true);
		EIGENHGGBEB[1].MEMHLENAOMB(PAPEDLBKBGM: false);
		if (EIGENHGGBEB[3].gameObject.activeSelf)
		{
			EIGENHGGBEB[4].ANEFFNMMALL(PAPEDLBKBGM: false);
		}
		EIGENHGGBEB[1].KIBNCDGOLJD(PAPEDLBKBGM: true);
		EIGENHGGBEB[1].ANEFFNMMALL(PAPEDLBKBGM: false);
		EIGENHGGBEB[2].IPNKGKNJOLO(PAPEDLBKBGM: true).onFinished = delegate
		{
			EIGENHGGBEB[(int)FIDMHHGBLOE].Animate(PAPEDLBKBGM: true);
		};
	}

	private void OKKHKLPNHHK(bool PDPDGCNHCFN)
	{
		bool flag = FIDMHHGBLOE == MPJAFCCIOEO.Member;
		bool flag2 = FIDMHHGBLOE == MPJAFCCIOEO.Cardpool;
		bool flag3 = FIDMHHGBLOE == MPJAFCCIOEO.Event;
		bool flag4 = FIDMHHGBLOE == MPJAFCCIOEO.Stats;
		bool flag5 = FIDMHHGBLOE == MPJAFCCIOEO.Emblem;
		bool flag6 = FIDMHHGBLOE == MPJAFCCIOEO.Info;
		if (PDPDGCNHCFN)
		{
			BBNLILBDOEC.Animate(flag, PDPDGCNHCFN: true);
			FCIOFJOCLPJ.Animate(flag2, PDPDGCNHCFN: true);
			NILIEMMOFNN.Animate(flag3, PDPDGCNHCFN: true);
			PEBBFADKJFC.Animate(flag4, PDPDGCNHCFN: true);
			BAJAOALGHMK.Animate(flag5, PDPDGCNHCFN: true);
			GHINFPBNJFC.Animate(flag6, PDPDGCNHCFN: true);
			return;
		}
		if (BBNLILBDOEC.gameObject.activeSelf && !flag)
		{
			BBNLILBDOEC.Animate(flag, PDPDGCNHCFN: false);
		}
		if (FCIOFJOCLPJ.gameObject.activeSelf && !flag2)
		{
			FCIOFJOCLPJ.Animate(flag2, PDPDGCNHCFN: false);
		}
		if (NILIEMMOFNN.gameObject.activeSelf && !flag3)
		{
			NILIEMMOFNN.Animate(flag3, PDPDGCNHCFN: false);
		}
		if (PEBBFADKJFC.gameObject.activeSelf && !flag4)
		{
			PEBBFADKJFC.Animate(flag4, PDPDGCNHCFN: false);
		}
		if (BAJAOALGHMK.gameObject.activeSelf && !flag5)
		{
			BAJAOALGHMK.Animate(flag5, PDPDGCNHCFN: false);
		}
		if (GHINFPBNJFC.gameObject.activeSelf && !flag6)
		{
			GHINFPBNJFC.Animate(flag6, PDPDGCNHCFN: false);
		}
		if (!BBNLILBDOEC.gameObject.activeSelf && flag)
		{
			BBNLILBDOEC.Animate(flag, PDPDGCNHCFN: false);
		}
		if (!FCIOFJOCLPJ.gameObject.activeSelf && flag2)
		{
			FCIOFJOCLPJ.Animate(flag2, PDPDGCNHCFN: false);
		}
		if (!NILIEMMOFNN.gameObject.activeSelf && flag3)
		{
			NILIEMMOFNN.Animate(flag3, PDPDGCNHCFN: false);
		}
		if (!PEBBFADKJFC.gameObject.activeSelf && flag4)
		{
			PEBBFADKJFC.Animate(flag4, PDPDGCNHCFN: false);
		}
		if (!BAJAOALGHMK.gameObject.activeSelf && flag5)
		{
			BAJAOALGHMK.Animate(flag5, PDPDGCNHCFN: false);
		}
		if (!GHINFPBNJFC.gameObject.activeSelf && flag6)
		{
			GHINFPBNJFC.Animate(flag6, PDPDGCNHCFN: false);
		}
		if (BBNLILBDOEC.gameObject.activeSelf && flag)
		{
			BBNLILBDOEC.Animate(flag, PDPDGCNHCFN: false);
		}
		if (FCIOFJOCLPJ.gameObject.activeSelf && flag2)
		{
			FCIOFJOCLPJ.Animate(flag2, PDPDGCNHCFN: false);
		}
		if (NILIEMMOFNN.gameObject.activeSelf && flag3)
		{
			NILIEMMOFNN.Animate(flag3, PDPDGCNHCFN: false);
		}
		if (PEBBFADKJFC.gameObject.activeSelf && flag4)
		{
			PEBBFADKJFC.Animate(flag4, PDPDGCNHCFN: false);
		}
		if (BAJAOALGHMK.gameObject.activeSelf && flag5)
		{
			BAJAOALGHMK.Animate(flag5, PDPDGCNHCFN: false);
		}
		if (GHINFPBNJFC.gameObject.activeSelf && flag6)
		{
			GHINFPBNJFC.Animate(flag6, PDPDGCNHCFN: false);
		}
	}

	private void BBANAHMHFBA()
	{
		Vector3 vector = new Vector3(1759f, 7f, 293f);
		TweenScale tweenScale = TweenScale.Begin(HFFEDJGKHLJ.gameObject, 317f, vector, vector.MultiplyXY(585f));
		tweenScale.style = (UITweener.Style)5;
		tweenScale.NumOfRepetitions = 1;
	}

	public void ShowSquadEvent()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Event;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	private void DPKMAJBGMFA()
	{
		Vector3 vector = new Vector3(96f, 96f, 1f);
		TweenScale tweenScale = TweenScale.Begin(HFFEDJGKHLJ.gameObject, 0.4f, vector, vector.MultiplyXY(1.1f));
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.NumOfRepetitions = 0;
	}

	private void EIELNPKGKIH(bool PDPDGCNHCFN)
	{
		bool flag = FIDMHHGBLOE == MPJAFCCIOEO.Member;
		bool flag2 = FIDMHHGBLOE == MPJAFCCIOEO.Cardpool;
		bool flag3 = FIDMHHGBLOE == MPJAFCCIOEO.Emblem;
		bool flag4 = FIDMHHGBLOE == MPJAFCCIOEO.Info;
		bool flag5 = FIDMHHGBLOE == (MPJAFCCIOEO)6;
		bool flag6 = FIDMHHGBLOE == (MPJAFCCIOEO)6;
		if (PDPDGCNHCFN)
		{
			BBNLILBDOEC.Animate(flag, PDPDGCNHCFN: true);
			FCIOFJOCLPJ.Animate(flag2, PDPDGCNHCFN: false);
			NILIEMMOFNN.HKDCHMLHKEB(flag3, PDPDGCNHCFN: false);
			PEBBFADKJFC.OGHIOCHEGGK(flag4, PDPDGCNHCFN: true);
			BAJAOALGHMK.NNPOEMEJGGP(flag5, PDPDGCNHCFN: true);
			GHINFPBNJFC.EAIHHHMDLBM(flag6, PDPDGCNHCFN: true);
			return;
		}
		if (BBNLILBDOEC.gameObject.activeSelf && !flag)
		{
			BBNLILBDOEC.Animate(flag, PDPDGCNHCFN: true);
		}
		if (FCIOFJOCLPJ.gameObject.activeSelf && !flag2)
		{
			FCIOFJOCLPJ.Animate(flag2, PDPDGCNHCFN: true);
		}
		if (NILIEMMOFNN.gameObject.activeSelf && !flag3)
		{
			NILIEMMOFNN.HKDCHMLHKEB(flag3, PDPDGCNHCFN: true);
		}
		if (PEBBFADKJFC.gameObject.activeSelf && !flag4)
		{
			PEBBFADKJFC.OGHIOCHEGGK(flag4, PDPDGCNHCFN: true);
		}
		if (BAJAOALGHMK.gameObject.activeSelf && !flag5)
		{
			BAJAOALGHMK.PDBGNFKGFJO(flag5, PDPDGCNHCFN: true);
		}
		if (GHINFPBNJFC.gameObject.activeSelf && !flag6)
		{
			GHINFPBNJFC.Animate(flag6, PDPDGCNHCFN: false);
		}
		if (!BBNLILBDOEC.gameObject.activeSelf && flag)
		{
			BBNLILBDOEC.Animate(flag, PDPDGCNHCFN: false);
		}
		if (!FCIOFJOCLPJ.gameObject.activeSelf && flag2)
		{
			FCIOFJOCLPJ.HKDCHMLHKEB(flag2, PDPDGCNHCFN: false);
		}
		if (!NILIEMMOFNN.gameObject.activeSelf && flag3)
		{
			NILIEMMOFNN.Animate(flag3, PDPDGCNHCFN: false);
		}
		if (!PEBBFADKJFC.gameObject.activeSelf && flag4)
		{
			PEBBFADKJFC.CMLKAPGBLGO(flag4, PDPDGCNHCFN: true);
		}
		if (!BAJAOALGHMK.gameObject.activeSelf && flag5)
		{
			BAJAOALGHMK.LFLGJGOKPND(flag5, PDPDGCNHCFN: false);
		}
		if (!GHINFPBNJFC.gameObject.activeSelf && flag6)
		{
			GHINFPBNJFC.EAIHHHMDLBM(flag6, PDPDGCNHCFN: true);
		}
		if (BBNLILBDOEC.gameObject.activeSelf && flag)
		{
			BBNLILBDOEC.Animate(flag, PDPDGCNHCFN: false);
		}
		if (FCIOFJOCLPJ.gameObject.activeSelf && flag2)
		{
			FCIOFJOCLPJ.Animate(flag2, PDPDGCNHCFN: true);
		}
		if (NILIEMMOFNN.gameObject.activeSelf && flag3)
		{
			NILIEMMOFNN.HKDCHMLHKEB(flag3, PDPDGCNHCFN: false);
		}
		if (PEBBFADKJFC.gameObject.activeSelf && flag4)
		{
			PEBBFADKJFC.CMLKAPGBLGO(flag4, PDPDGCNHCFN: false);
		}
		if (BAJAOALGHMK.gameObject.activeSelf && flag5)
		{
			BAJAOALGHMK.LFLGJGOKPND(flag5, PDPDGCNHCFN: false);
		}
		if (GHINFPBNJFC.gameObject.activeSelf && flag6)
		{
			GHINFPBNJFC.DOMDAJKLILC(flag6, PDPDGCNHCFN: true);
		}
	}

	private static bool KAOMOJLKHMI(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	public void HFPBJCFLPJP()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Stats;
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(this);
		}
	}

	[SpecialName]
	public UIDraggablePanel FFCJIOIOPKM()
	{
		if (FIDMHHGBLOE == (MPJAFCCIOEO)8)
		{
			return NILIEMMOFNN.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Info)
		{
			return PEBBFADKJFC.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Cardpool)
		{
			return BAJAOALGHMK.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Member)
		{
			return FCIOFJOCLPJ.NFLPPGKCOBL;
		}
		return BBNLILBDOEC.NFLPPGKCOBL;
	}

	private void GOCJIMAFNBK(bool JHIALFMFBMJ, float HECJLCFJMBM, bool JNFEBGFALBI, float KBJLCLKFAEB, bool PDPDGCNHCFN)
	{
		ILKOLBHGAMN iLKOLBHGAMN = new ILKOLBHGAMN();
		iLKOLBHGAMN.HECJLCFJMBM = HECJLCFJMBM;
		iLKOLBHGAMN.KBJLCLKFAEB = KBJLCLKFAEB;
		iLKOLBHGAMN.JHIALFMFBMJ = JHIALFMFBMJ;
		iLKOLBHGAMN.JNFEBGFALBI = JNFEBGFALBI;
		iLKOLBHGAMN.BJGCPDNMHDH = this;
		if (PDPDGCNHCFN)
		{
			BPEAMJBCLHM(iLKOLBHGAMN.HECJLCFJMBM, iLKOLBHGAMN.KBJLCLKFAEB);
			KCBAFHJOJCP.alpha = ((!iLKOLBHGAMN.JHIALFMFBMJ) ? 0f : 1f);
			JAHOEJODKOH.alpha = ((!iLKOLBHGAMN.JNFEBGFALBI) ? 0f : 1f);
			TweenAlpha component = KCBAFHJOJCP.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			TweenAlpha component2 = JAHOEJODKOH.gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.onFinished = null;
				component2.enabled = false;
			}
		}
		else
		{
			TweenAlpha.Begin(KCBAFHJOJCP.gameObject, HAMKIKMJHDP, 0f);
			TweenAlpha.Begin(JAHOEJODKOH.gameObject, HAMKIKMJHDP, 0f).onFinished = iLKOLBHGAMN.LJCDGJKCNEC;
		}
	}

	public void ShowSquadMembers()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Member;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void JHKOIGMCOBN(GameObject KHAHPAKDIKE)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName);
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize(" {0}\u00a0{1}"), Localization.Localize("Game created on server+"));
		}
		else if (aANECPGDMGM.FOICGJEPBGL == 0)
		{
			ConfirmDialog.HMBAPGGLPLC(Localization.Localize("resizing texture "), Localization.Localize(" BOXES "), HIAFMACHJHB, 1666f);
		}
		else if (currentPlayer.squadRank == (SquadRank)6)
		{
			SelectSquadLeaderDialog.EHIJFLMHEBJ(delegate(DatabasePlayer KHLGDCHJJPB, bool NILPBCGHEDG)
			{
				NFFDKDNHOAN nFFDKDNHOAN = new NFFDKDNHOAN
				{
					KHLGDCHJJPB = KHLGDCHJJPB
				};
				if (NILPBCGHEDG)
				{
					ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LEAVESQUAD"), Localization.LocalizeFormat("ID_CONFIRM_LEAVESQUADLEADER_TEXT", nFFDKDNHOAN.KHLGDCHJJPB.name), nFFDKDNHOAN.LJCDGJKCNEC);
				}
			}, GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL);
		}
		else
		{
			ConfirmDialog.NMLMDFGOHDC(Localization.Localize("defendPosition"), Localization.Localize("TuneListener trackerDidReceiveDeeplink: "), FKJIIMHEPGL, 1354f);
		}
	}

	public void PMHPNLDAJKL(AANECPGDMGM MIDDFOCJJOP)
	{
		if (NPFFMLLLDAF() && MIDDFOCJJOP != null && GameLoginManager.currentPlayer.squadName == MIDDFOCJJOP.MHPNDNJDPGE)
		{
			CEPGKMBDLPP(MIDDFOCJJOP);
		}
	}

	private void CKPJAGNMBEO()
	{
	}

	[CompilerGenerated]
	private static void FKBIEDKABBH(DatabasePlayer KHLGDCHJJPB, bool NILPBCGHEDG)
	{
		NFFDKDNHOAN nFFDKDNHOAN = new NFFDKDNHOAN
		{
			KHLGDCHJJPB = KHLGDCHJJPB
		};
		if (NILPBCGHEDG)
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LEAVESQUAD"), Localization.LocalizeFormat("ID_CONFIRM_LEAVESQUADLEADER_TEXT", nFFDKDNHOAN.KHLGDCHJJPB.name), nFFDKDNHOAN.LJCDGJKCNEC);
		}
	}

	public void CardpoolNotifications()
	{
		LMNDLIKKJHE.SetNotifications(Singleton<NotificationManager>.instance.GetSquadCardpoolNotifications());
	}

	private void CAPJJKMPDCA(bool JHIALFMFBMJ, float HECJLCFJMBM, bool JNFEBGFALBI, float KBJLCLKFAEB, bool PDPDGCNHCFN)
	{
		ILKOLBHGAMN iLKOLBHGAMN = new ILKOLBHGAMN();
		iLKOLBHGAMN.HECJLCFJMBM = HECJLCFJMBM;
		iLKOLBHGAMN.KBJLCLKFAEB = KBJLCLKFAEB;
		iLKOLBHGAMN.JHIALFMFBMJ = JHIALFMFBMJ;
		iLKOLBHGAMN.JNFEBGFALBI = JNFEBGFALBI;
		iLKOLBHGAMN.BJGCPDNMHDH = this;
		if (PDPDGCNHCFN)
		{
			BPEAMJBCLHM(iLKOLBHGAMN.HECJLCFJMBM, iLKOLBHGAMN.KBJLCLKFAEB);
			KCBAFHJOJCP.alpha = ((!iLKOLBHGAMN.JHIALFMFBMJ) ? 797f : 273f);
			JAHOEJODKOH.alpha = ((!iLKOLBHGAMN.JNFEBGFALBI) ? 934f : 1146f);
			TweenAlpha component = KCBAFHJOJCP.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = true;
			}
			TweenAlpha component2 = JAHOEJODKOH.gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.onFinished = null;
				component2.enabled = false;
			}
		}
		else
		{
			TweenAlpha.Begin(KCBAFHJOJCP.gameObject, HAMKIKMJHDP, 450f);
			TweenAlpha.Begin(JAHOEJODKOH.gameObject, HAMKIKMJHDP, 1770f).onFinished = iLKOLBHGAMN.LJCDGJKCNEC;
		}
	}

	[SpecialName]
	public UIDraggablePanel AGEDGMLDGAM()
	{
		if (FIDMHHGBLOE == MPJAFCCIOEO.Emblem)
		{
			return NILIEMMOFNN.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == (MPJAFCCIOEO)8)
		{
			return PEBBFADKJFC.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Emblem)
		{
			return BAJAOALGHMK.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Member)
		{
			return FCIOFJOCLPJ.NFLPPGKCOBL;
		}
		return BBNLILBDOEC.NFLPPGKCOBL;
	}

	private void AOLPGPNBOIB(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !CPKIKJFFOBG.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	private void GCJDFBHEPHN(DatabasePlayer KKHKAJPNDEC, bool NCMHGPNPEJM)
	{
		if (KKHKAJPNDEC == null)
		{
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (KKHKAJPNDEC.squadName == currentPlayer.squadName)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_FRIENDINSQUAD"), Localization.LocalizeFormat("ID_CONFIRM_FRIENDINSQUAD_TEXT", KKHKAJPNDEC.name));
			return;
		}
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM != null)
		{
			bool flag = currentPlayer.squadRank == SquadRank.Member;
			if (!aANECPGDMGM.IOLNJBGOOLJ && flag)
			{
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), Localization.Localize("ID_WARNING_CANTSENDINVITE"), 0f, null, string.Empty);
			}
			else if (aANECPGDMGM.MGDCJLAENHG() <= 0)
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance);
			}
			else
			{
				Singleton<BeanstalkServerManager>.instance.CLGKGOHGLGG(KKHKAJPNDEC);
			}
		}
	}

	private void HEMPGCPOEBL(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !JBOHFMAPCJL.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	public void CAGBHGLFPEB()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Cardpool;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public virtual void OMKGJLKNCJG()
	{
		base.DoBeforeShowUp();
		BBNLILBDOEC.NFLPPGKCOBL.onePanelDisabled = false;
		FCIOFJOCLPJ.NFLPPGKCOBL.onePanelDisabled = true;
		NILIEMMOFNN.NFLPPGKCOBL.onePanelDisabled = true;
		PEBBFADKJFC.NFLPPGKCOBL.onePanelDisabled = false;
		BAJAOALGHMK.NFLPPGKCOBL.onePanelDisabled = false;
		IBCIOGABEEA = false;
	}

	protected virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KHFOHBMDEBJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OEGEELHAJPM));
		UIEventListener uIEventListener2 = UIEventListener.Get(DGBFJNCGAFG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEMPGCPOEBL));
		UIEventListener uIEventListener3 = UIEventListener.Get(CFGGNFGPFNG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JHKOIGMCOBN));
		UIEventListener uIEventListener4 = UIEventListener.Get(KDOHHIBFBIN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LNFFFJEEGPB));
		UIEventListener uIEventListener5 = UIEventListener.Get(GFAIEMEPGNA);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(InviteToSquadClick));
		BGBNBLAKICB();
		JAHOEJODKOH.transform.localPosition = JAHOEJODKOH.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 1855f);
		string text = Localization.Localize("GameLaunch") + "HIDIING" + Localization.Localize("ID_GAMEINVITE");
		text = text + Localization.Localize("VisualTimestamp") + Localization.Localize("' not found!") + Localization.Localize("Confirmed_In_App");
		float x = EIGENHGGBEB[1].KLMFIBIIALC.getSizeForString(text).x;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		int num = 15;
		float num2 = activeWidthSafe - (float)num;
		float num3 = Mathf.Clamp(Mathf.Floor(num2 / x), 1589f, 80f);
		for (int i = 0; i < EIGENHGGBEB.Count; i += 0)
		{
			EIGENHGGBEB[i].KLMFIBIIALC.transform.localScale = new Vector3(num3, num3, 247f);
		}
		EIGENHGGBEB[1].CIPKPHAGJMP(Localization.Localize("NON"), HAMKIKMJHDP);
		EIGENHGGBEB[1].JIMBEDOMAFD(Localization.Localize("ID_REMINDER_UPGRADEAVAILABLE"), HAMKIKMJHDP, PAPEDLBKBGM: true);
		EIGENHGGBEB[6].gameObject.SetActive(value: false);
		EIGENHGGBEB[8].Initialize(Localization.Localize("globalPlayerLeaderboard"), HAMKIKMJHDP, PAPEDLBKBGM: true);
		EIGENHGGBEB[7].Initialize(Localization.Localize("reload_grenadelauncher"), HAMKIKMJHDP);
		EIGENHGGBEB[1].PNCJCHPOMOJ(Localization.Localize("Daily_mission_start_heroic"), HAMKIKMJHDP);
		LHKLOFBMPGN.repositionNow = true;
		LHKLOFBMPGN.onReposition = delegate
		{
			BPEAMJBCLHM();
		};
		foreach (SquadButton item in EIGENHGGBEB)
		{
			UIEventListener uIEventListener6 = UIEventListener.Get(item.gameObject);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(EKOFHHFAPCI));
		}
		BBNLILBDOEC.InitControls();
		FCIOFJOCLPJ.InitControls();
		NILIEMMOFNN.LPFPAKGNNIO();
		PEBBFADKJFC.KNOKOJKOCEB();
		BAJAOALGHMK.PGOMBLHHHKD();
		GHINFPBNJFC.InitControls();
		HIOONEIFKMF.gameObject.SetActive(value: false);
		IMKKLAKPIIN();
		DebugSettings.instance.Changed += PHAHDJNMMGE;
	}

	public void ShowSquadEmblem()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Emblem;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void LeaveSquadClick(GameObject KHAHPAKDIKE)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, NICBOKPIBIA: true);
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE"), Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"));
			return;
		}
		if (aANECPGDMGM.FOICGJEPBGL == 1)
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_DELETESQUAD"), Localization.Localize("ID_CONFIRM_DELETESQUAD_TEXT"), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
			{
				if (FBFJNHLKJEC)
				{
					Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
				}
			});
			return;
		}
		if (currentPlayer.squadRank == SquadRank.Leader)
		{
			SelectSquadLeaderDialog.ShowSelectNewSquadLeader(delegate(DatabasePlayer KHLGDCHJJPB, bool NILPBCGHEDG)
			{
				NFFDKDNHOAN nFFDKDNHOAN = new NFFDKDNHOAN
				{
					KHLGDCHJJPB = KHLGDCHJJPB
				};
				if (NILPBCGHEDG)
				{
					ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LEAVESQUAD"), Localization.LocalizeFormat("ID_CONFIRM_LEAVESQUADLEADER_TEXT", nFFDKDNHOAN.KHLGDCHJJPB.name), nFFDKDNHOAN.LJCDGJKCNEC);
				}
			}, GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL);
			return;
		}
		ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LEAVESQUAD"), Localization.Localize("ID_CONFIRM_LEAVESQUAD_TEXT"), delegate(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
			}
		});
	}

	public void SetSquadIcon(string PCDMKLAJINM)
	{
		if (LCLNBHPNCIK != PCDMKLAJINM)
		{
			Debug.Log($"Setting squad icon: {PCDMKLAJINM}");
			GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("SquadIcons/" + PCDMKLAJINM);
			LCLNBHPNCIK = PCDMKLAJINM;
		}
		else
		{
			Debug.Log($"Squad icon: {PCDMKLAJINM} already displayed");
		}
	}

	private void NAOPHHPFFPG()
	{
		BPEAMJBCLHM();
	}

	private void CNKMNOPMPNJ(bool PDPDGCNHCFN)
	{
		if (PDPDGCNHCFN)
		{
			for (int i = 0; i < EIGENHGGBEB.Count; i++)
			{
				EIGENHGGBEB[i].InstantAnimate(i == (int)FIDMHHGBLOE);
			}
			return;
		}
		EIGENHGGBEB[0].Animate(PAPEDLBKBGM: false);
		EIGENHGGBEB[1].Animate(PAPEDLBKBGM: false);
		if (EIGENHGGBEB[2].gameObject.activeSelf)
		{
			EIGENHGGBEB[2].Animate(PAPEDLBKBGM: false);
		}
		EIGENHGGBEB[3].Animate(PAPEDLBKBGM: false);
		EIGENHGGBEB[4].Animate(PAPEDLBKBGM: false);
		EIGENHGGBEB[5].Animate(PAPEDLBKBGM: false).onFinished = delegate
		{
			EIGENHGGBEB[(int)FIDMHHGBLOE].Animate(PAPEDLBKBGM: true);
		};
	}

	private void OPGJDCAOCKP()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<BeanstalkServerManager>.instance.SquadUpdateReceived += OnSquadUpdateReceived;
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		GameLoginManager.instance.PlayerJoinedSquad += JKNABGNKBLE;
		GameLoginManager.instance.PlayerLeftSquad += BDIICHCECFP;
		CardManager.instance.WithdrawTimeChanged += CardpoolNotifications;
		Singleton<NotificationManager>.instance.CardpoolNotificationChanged += CardpoolNotifications;
		ServerResultsCache serverResultsCache = Singleton<ServerResultsCache>.instance;
		serverResultsCache.MPDPBMIAEMP = (Action)Delegate.Combine(serverResultsCache.MPDPBMIAEMP, new Action(MDIHOPBIFJA));
	}

	private void LNFFFJEEGPB(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<LeaguesScreen>.instance.ShowSquadWars();
	}

	private void GEDJLHKCCCA()
	{
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			return;
		}
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
		bool flag = aANECPGDMGM != null && !aANECPGDMGM.IOLNJBGOOLJ;
		bool flag2 = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
		GFAIEMEPGNA.gameObject.SetActive(!flag || !flag2);
		List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.MHELMEJPGBK(GameLoginManager.currentPlayer.squadName);
		if (list == null)
		{
			return;
		}
		DatabasePlayer generatedCurrentPlayer = GameLoginManager.generatedCurrentPlayer;
		int num = list.FindIndex((DatabasePlayer NGKBOFPJNAG) => NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id);
		if (num < 0)
		{
			list.Add(generatedCurrentPlayer);
		}
		for (int num2 = list.Count - 1; num2 >= 0; num2--)
		{
			if (string.IsNullOrEmpty(list[num2].name))
			{
				list.RemoveAt(num2);
			}
		}
		int num3 = 0;
		foreach (DatabasePlayer item in list)
		{
			if (item.GetRealStatus() != PlayerStatus.Offline)
			{
				num3++;
			}
		}
		SetMembersButton(aANECPGDMGM.FOICGJEPBGL, aANECPGDMGM.FOICGJEPBGL + aANECPGDMGM.MGDCJLAENHG(), num3);
	}

	public void ONDDINOMEAG()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Cardpool;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void NFFEHKBGAGN(int GKBPHAGAKAE, int BHGMAEOMLHG, int CIFCDKNDABO)
	{
		SquadButtonSpecial squadButtonSpecial = EIGENHGGBEB[0] as SquadButtonSpecial;
		if (squadButtonSpecial != null)
		{
			squadButtonSpecial.FJGKCEKGGLB(string.Format("ID_WARARENAUNLOCKED", GKBPHAGAKAE, BHGMAEOMLHG), FIDMHHGBLOE == MPJAFCCIOEO.Cardpool, IBCIOGABEEA);
			squadButtonSpecial.KPCDGDEIDCH(CIFCDKNDABO);
			if (CIFCDKNDABO == 0)
			{
				LHKLOFBMPGN.repositionNow = true;
			}
		}
	}

	public void MLAOENMAIKC(int GKBPHAGAKAE, int BHGMAEOMLHG, int CIFCDKNDABO)
	{
		SquadButtonSpecial squadButtonSpecial = EIGENHGGBEB[0] as SquadButtonSpecial;
		if (squadButtonSpecial != null)
		{
			squadButtonSpecial.IMDLPGAGICF(string.Format("MM/dd/yyyy", GKBPHAGAKAE, BHGMAEOMLHG), FIDMHHGBLOE == MPJAFCCIOEO.Cardpool, IBCIOGABEEA);
			squadButtonSpecial.GDNNNNPLNJF(CIFCDKNDABO);
			if (CIFCDKNDABO == 0)
			{
				LHKLOFBMPGN.repositionNow = true;
			}
		}
	}

	[CompilerGenerated]
	private static void OJDIOKGHLEN(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
		}
	}

	public void OnSquadUpdateReceived(AANECPGDMGM MIDDFOCJJOP)
	{
		if (isShowed && MIDDFOCJJOP != null && GameLoginManager.currentPlayer.squadName == MIDDFOCJJOP.MHPNDNJDPGE)
		{
			CJIEFKAHCGD(MIDDFOCJJOP);
		}
	}

	private void EAGNKKCFHHK(string CGIFEHPDBAL)
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	private void KLBNGJJPNFN(DatabasePlayer KKHKAJPNDEC, bool NCMHGPNPEJM)
	{
		if (KKHKAJPNDEC == null)
		{
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (KKHKAJPNDEC.squadName == currentPlayer.squadName)
		{
			string oKMNFHNBMFA = Localization.Localize("StatisticsData");
			object[] array = new object[0];
			array[1] = KKHKAJPNDEC.name;
			ConfirmDialog.JDEDLDGMHBJ(oKMNFHNBMFA, Localization.LocalizeFormat("Version", array), 1660f);
			return;
		}
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM != null)
		{
			bool flag = currentPlayer.squadRank == SquadRank.Member;
			if (!aANECPGDMGM.IOLNJBGOOLJ && flag)
			{
				WarningDialog.JACKIDKHKAI(Localization.Localize("GooglePlayId"), Localization.Localize("-"), 398f, null, string.Empty);
			}
			else if (aANECPGDMGM.DLDHIJAEFHG() <= 1)
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance, 181f);
			}
			else
			{
				Singleton<BeanstalkServerManager>.instance.KLIPCELANKO(KKHKAJPNDEC);
			}
		}
	}

	[SpecialName]
	public UIDraggablePanel GEEJIANGCJO()
	{
		if (FIDMHHGBLOE == (MPJAFCCIOEO)6)
		{
			return NILIEMMOFNN.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Stats)
		{
			return PEBBFADKJFC.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == (MPJAFCCIOEO)8)
		{
			return BAJAOALGHMK.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Member)
		{
			return FCIOFJOCLPJ.NFLPPGKCOBL;
		}
		return BBNLILBDOEC.NFLPPGKCOBL;
	}

	private void KENIMKGFCJH(DatabaseAction IFGAGNBDKBE)
	{
		if (!NPFFMLLLDAF())
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)83:
		{
			WaitingDialog.PEIFGGPNHMK();
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			if (string.IsNullOrEmpty(currentPlayer.squadName))
			{
				AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName);
				if (aANECPGDMGM == null)
				{
					aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName);
				}
				if (aANECPGDMGM != null)
				{
					CJIEFKAHCGD(aANECPGDMGM);
				}
				else
				{
					InitGUIValues();
				}
			}
			else
			{
				InitGUIValues();
			}
			break;
		}
		case (DatabaseAction)(-102):
			GEDJLHKCCCA();
			break;
		}
	}

	private void MIJMPEHBFMP(bool PDPDGCNHCFN)
	{
		if (PDPDGCNHCFN)
		{
			for (int i = 1; i < EIGENHGGBEB.Count; i += 0)
			{
				EIGENHGGBEB[i].LOJIKJPPBIO(i == (int)FIDMHHGBLOE);
			}
			return;
		}
		EIGENHGGBEB[1].CGNAGNAOEJA(PAPEDLBKBGM: false);
		EIGENHGGBEB[1].IPNKGKNJOLO(PAPEDLBKBGM: true);
		if (EIGENHGGBEB[6].gameObject.activeSelf)
		{
			EIGENHGGBEB[2].LAHIJFMLODM(PAPEDLBKBGM: true);
		}
		EIGENHGGBEB[4].ANEFFNMMALL(PAPEDLBKBGM: true);
		EIGENHGGBEB[8].BOFICLOIGDJ(PAPEDLBKBGM: true);
		EIGENHGGBEB[6].JLBALIEPGGC(PAPEDLBKBGM: true).onFinished = delegate
		{
			EIGENHGGBEB[(int)FIDMHHGBLOE].Animate(PAPEDLBKBGM: true);
		};
	}

	private void IGOAEDMOHJF(bool PDPDGCNHCFN)
	{
		if (PDPDGCNHCFN)
		{
			for (int i = 0; i < EIGENHGGBEB.Count; i++)
			{
				EIGENHGGBEB[i].KECAIJLLCOM(i == (int)FIDMHHGBLOE);
			}
			return;
		}
		EIGENHGGBEB[1].CEACEHMMBEI(PAPEDLBKBGM: true);
		EIGENHGGBEB[0].HODJNFBKFHC(PAPEDLBKBGM: false);
		if (EIGENHGGBEB[6].gameObject.activeSelf)
		{
			EIGENHGGBEB[4].DANJCHNBGJF(PAPEDLBKBGM: true);
		}
		EIGENHGGBEB[5].KIBNCDGOLJD(PAPEDLBKBGM: true);
		EIGENHGGBEB[2].CGNAGNAOEJA(PAPEDLBKBGM: false);
		EIGENHGGBEB[1].HNGLCCDCHGG(PAPEDLBKBGM: false).onFinished = delegate
		{
			EIGENHGGBEB[(int)FIDMHHGBLOE].Animate(PAPEDLBKBGM: true);
		};
	}

	private void KBLKGMEKGAI()
	{
	}

	[CompilerGenerated]
	private static void EKNMKIIFHDJ(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
		}
	}

	private static bool NLCAPLEBFPC(DatabasePlayer NGKBOFPJNAG)
	{
		return NGKBOFPJNAG.id == GameLoginManager.currentPlayer.id;
	}

	public virtual void MJGOCAKKDBK()
	{
		base.DoBeforeHide();
		if (FIDMHHGBLOE == MPJAFCCIOEO.Member)
		{
			BBNLILBDOEC.Animate(PJIEFMBDLBE: false, PDPDGCNHCFN: true);
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Member)
		{
			FCIOFJOCLPJ.Animate(PJIEFMBDLBE: false, PDPDGCNHCFN: true);
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Cardpool)
		{
			NILIEMMOFNN.Animate(PJIEFMBDLBE: true, PDPDGCNHCFN: false);
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Stats)
		{
			PEBBFADKJFC.Animate(PJIEFMBDLBE: true, PDPDGCNHCFN: false);
		}
		if (FIDMHHGBLOE == (MPJAFCCIOEO)8)
		{
			BAJAOALGHMK.HBIKDPNHHEG(PJIEFMBDLBE: true, PDPDGCNHCFN: true);
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Event)
		{
			GHINFPBNJFC.BBAJLLLEAID(PJIEFMBDLBE: false, PDPDGCNHCFN: false);
		}
		Singleton<AwaitingSquadMembersManager>.instance.RemoveErrorPlayers();
	}

	private void MDIHOPBIFJA()
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && AEFCKOJAOPK.activeSelf)
		{
			if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
			{
				FMACDIAACGM();
			}
			else
			{
				DPKMAJBGMFA();
			}
		}
	}

	public virtual void PGBBAHLJMLA()
	{
		base.DoAfterHide();
		BBNLILBDOEC.InstantHideTab();
		FCIOFJOCLPJ.InstantHideTab();
		NILIEMMOFNN.InstantHideTab();
		PEBBFADKJFC.InstantHideTab();
		BAJAOALGHMK.PHFCPLOMFGN();
		GHINFPBNJFC.AFJOOMBDLFJ();
		CardManager.instance.ResetSquadCards(GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.messageBuddies);
		GEAGOKJMJFD.mainTexture = null;
		LCLNBHPNCIK = null;
	}

	private void HIHOANALHPH()
	{
		bool isPlayerDataLoaded = Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded;
		string squadName = GameLoginManager.currentPlayer.squadName;
		bool flag = !string.IsNullOrEmpty(squadName);
		bool flag2 = flag;
		if (flag2)
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName);
			if (aANECPGDMGM == null)
			{
				aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(squadName, NICBOKPIBIA: true);
			}
			flag2 = aANECPGDMGM != null;
		}
		bool flag3 = isPlayerDataLoaded && !flag;
		bool flag4 = isPlayerDataLoaded && flag && flag2;
		bool flag5 = !isPlayerDataLoaded || (flag && !flag2);
		if (flag3 != IHPCMGFJPIC.activeSelf)
		{
			IHPCMGFJPIC.SetActive(flag3);
		}
		if (flag4 != AEFCKOJAOPK.activeSelf)
		{
			AEFCKOJAOPK.SetActive(flag4);
		}
		if (flag5 != FLGDNCDLADK.activeSelf)
		{
			FLGDNCDLADK.SetActive(flag5);
		}
	}

	private void OEGEELHAJPM(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !CPKIKJFFOBG.activeSelf)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadFindScreen>.instance);
		}
	}

	private void EFJPKEBNMBG()
	{
		if (isShowed)
		{
			InitGUIValues();
		}
	}

	protected virtual void KNOKOJKOCEB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KHFOHBMDEBJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LJMBPOCMBJF));
		UIEventListener uIEventListener2 = UIEventListener.Get(DGBFJNCGAFG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FGDFFJMDNHB));
		UIEventListener uIEventListener3 = UIEventListener.Get(CFGGNFGPFNG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JHKOIGMCOBN));
		UIEventListener uIEventListener4 = UIEventListener.Get(KDOHHIBFBIN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DCIDANCBHEH));
		UIEventListener uIEventListener5 = UIEventListener.Get(GFAIEMEPGNA);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(InviteToSquadClick));
		BGBNBLAKICB();
		JAHOEJODKOH.transform.localPosition = JAHOEJODKOH.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 1567f);
		string text = Localization.Localize("[]") + "ID_GPGS_LOGIN_TUTORIAL_TITLE" + Localization.Localize("ДА");
		text = text + Localization.Localize("워프렌즈가 중요한 게임 데이터를 다운로드하려면 미디어 저장 장치에 대한 접근 권한이 필요합니다. 다음에 나오는 권한 설정을 수락해주세요. 이 권한 설정은 다른 목적으로는 사용되지 않습니다.") + Localization.Localize("UnitCategoriesReminder") + Localization.Localize("ID_TOBENUMBERONE1");
		float x = EIGENHGGBEB[1].KLMFIBIIALC.getSizeForString(text).x;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		int num = 59;
		float num2 = activeWidthSafe - (float)num;
		float num3 = Mathf.Clamp(Mathf.Floor(num2 / x), 721f, 647f);
		for (int i = 0; i < EIGENHGGBEB.Count; i++)
		{
			EIGENHGGBEB[i].KLMFIBIIALC.transform.localScale = new Vector3(num3, num3, 570f);
		}
		EIGENHGGBEB[1].CIPKPHAGJMP(Localization.Localize("126 MENU BATTLE SCREEN SHOWN"), HAMKIKMJHDP, PAPEDLBKBGM: true);
		EIGENHGGBEB[1].HHFELCAFANH(Localization.Localize("game-card-ico-shieldgenerator"), HAMKIKMJHDP);
		EIGENHGGBEB[1].gameObject.SetActive(value: false);
		EIGENHGGBEB[5].Initialize(Localization.Localize("Name"), HAMKIKMJHDP, PAPEDLBKBGM: true);
		EIGENHGGBEB[3].MKENDIKJPLJ(Localization.Localize("IDFV"), HAMKIKMJHDP, PAPEDLBKBGM: true);
		EIGENHGGBEB[7].OMCNLOHKCBJ(Localization.Localize("Medals/"), HAMKIKMJHDP, PAPEDLBKBGM: true);
		LHKLOFBMPGN.repositionNow = false;
		LHKLOFBMPGN.onReposition = delegate
		{
			BPEAMJBCLHM();
		};
		foreach (SquadButton item in EIGENHGGBEB)
		{
			UIEventListener uIEventListener6 = UIEventListener.Get(item.gameObject);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(KNNADMFOKFH));
		}
		BBNLILBDOEC.InitControls();
		FCIOFJOCLPJ.InitControls();
		NILIEMMOFNN.LPFPAKGNNIO();
		PEBBFADKJFC.InitControls();
		BAJAOALGHMK.GJGCOEJMHNI();
		GHINFPBNJFC.JCGPELEDCJL();
		HIOONEIFKMF.gameObject.SetActive(value: false);
		IMKKLAKPIIN();
		DebugSettings.instance.Changed += CKPJAGNMBEO;
	}

	private void PHAHDJNMMGE()
	{
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		BPEAMJBCLHM();
	}

	public void SetMembersButton(int GKBPHAGAKAE, int BHGMAEOMLHG, int CIFCDKNDABO)
	{
		SquadButtonSpecial squadButtonSpecial = EIGENHGGBEB[0] as SquadButtonSpecial;
		if (squadButtonSpecial != null)
		{
			squadButtonSpecial.InitializeSpecial($"{GKBPHAGAKAE} / {BHGMAEOMLHG}", FIDMHHGBLOE == MPJAFCCIOEO.Member, IBCIOGABEEA);
			squadButtonSpecial.SetOnline(CIFCDKNDABO);
			if (CIFCDKNDABO == 0)
			{
				LHKLOFBMPGN.repositionNow = true;
			}
		}
	}

	private void IDEBIFIFAOP()
	{
		Vector3 vector = new Vector3(1410f, 727f, 1682f);
		TweenScale tweenScale = TweenScale.Begin(HFFEDJGKHLJ.gameObject, 51f, vector, vector.MultiplyXY(1517f));
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 1;
	}

	private void IMAKOLGEKOH()
	{
		int joinSquadUnlockLevel = LevelManager.instance.joinSquadUnlockLevel;
		int createSquadUnlockLevel = LevelManager.instance.createSquadUnlockLevel;
		bool flag = LevelManager.instance.currentLevel.displayNumber < joinSquadUnlockLevel;
		bool flag2 = LevelManager.instance.currentLevel.PFMGLDJDNBF() < createSquadUnlockLevel;
		bool flag3 = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.RepairShields);
		MEMKHHLCIDH.transform.localPosition = MEMKHHLCIDH.transform.localPosition.ReplaceX((!flag3) ? 1198f : 747f);
		PNBKGHMDKBJ.SetActive(!flag3);
		LMFGLDGDNEO.transform.localPosition = LMFGLDGDNEO.transform.localPosition.ReplaceX((!flag3) ? 1736f : 591f);
		DEBNKFCDENN.SetActive(!flag3);
		if (!flag3)
		{
			NPNIDIGGPGI.text = Localization.Localize("http://");
			MEJMLNDFDBP.COCBCFKJOJE(NPNIDIGGPGI, 679f, 1089f, -96);
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-98)).FLOATVALUE;
			CKDIMHJAKNF.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
			GDDFNCHCFKN.text = Localization.Localize("1");
			MEJMLNDFDBP.COCBCFKJOJE(GDDFNCHCFKN, 690f, 193f, 158);
			MAECEAGKNFK.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
		bool flag4 = !flag;
		bool flag5 = !flag2;
		IOHMEPJDJMH.enabled = flag4;
		CLIOPGGILNE.enabled = flag5;
		PGKOEEPPFJH.text = string.Format("Wrong_Category", Localization.Localize("ID_GUI_CHEATINGMESSAGE"), joinSquadUnlockLevel);
		BHKJDMAKFPP.text = string.Format("Hero {0:D2}", Localization.Localize("ID_CONFIRM_EXITINGMATCH"), createSquadUnlockLevel);
		CPKIKJFFOBG.SetActive(flag);
		JBOHFMAPCJL.SetActive(flag2);
		if (FLFKPIGBDAO[0].transform.localScale.x != FLFKPIGBDAO[1].transform.localScale.x)
		{
			FLFKPIGBDAO[0].transform.localScale = FLFKPIGBDAO[0].transform.localScale;
			GJNALLCCFBB.repositionNow = true;
		}
	}

	protected override void AGIKPOLCGNF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KHFOHBMDEBJ);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BHPHFADPDDO));
		UIEventListener uIEventListener2 = UIEventListener.Get(DGBFJNCGAFG);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HEMPGCPOEBL));
		UIEventListener uIEventListener3 = UIEventListener.Get(CFGGNFGPFNG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LeaveSquadClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(KDOHHIBFBIN);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DCIDANCBHEH));
		UIEventListener uIEventListener5 = UIEventListener.Get(GFAIEMEPGNA);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(InviteToSquadClick));
		BGBNBLAKICB();
		JAHOEJODKOH.transform.localPosition = JAHOEJODKOH.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 48f);
		string text = Localization.Localize("ID_MEMBERS") + "22 / 22" + Localization.Localize("ID_CARDPOOL");
		text = text + Localization.Localize("ID_STATS") + Localization.Localize("ID_EMBLEM") + Localization.Localize("ID_INFO");
		float x = EIGENHGGBEB[0].KLMFIBIIALC.getSizeForString(text).x;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		int num = 840;
		float num2 = activeWidthSafe - (float)num;
		float num3 = Mathf.Clamp(Mathf.Floor(num2 / x), 25f, 47f);
		for (int i = 0; i < EIGENHGGBEB.Count; i++)
		{
			EIGENHGGBEB[i].KLMFIBIIALC.transform.localScale = new Vector3(num3, num3, 1f);
		}
		EIGENHGGBEB[0].Initialize(Localization.Localize("ID_MEMBERS"), HAMKIKMJHDP);
		EIGENHGGBEB[1].Initialize(Localization.Localize("ID_CARDPOOL"), HAMKIKMJHDP);
		EIGENHGGBEB[2].gameObject.SetActive(value: false);
		EIGENHGGBEB[3].Initialize(Localization.Localize("ID_STATS"), HAMKIKMJHDP);
		EIGENHGGBEB[4].Initialize(Localization.Localize("ID_EMBLEM"), HAMKIKMJHDP);
		EIGENHGGBEB[5].Initialize(Localization.Localize("ID_INFO"), HAMKIKMJHDP);
		LHKLOFBMPGN.repositionNow = true;
		LHKLOFBMPGN.onReposition = delegate
		{
			BPEAMJBCLHM();
		};
		foreach (SquadButton item in EIGENHGGBEB)
		{
			UIEventListener uIEventListener6 = UIEventListener.Get(item.gameObject);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(EKOFHHFAPCI));
		}
		BBNLILBDOEC.InitControls();
		FCIOFJOCLPJ.InitControls();
		NILIEMMOFNN.InitControls();
		PEBBFADKJFC.InitControls();
		BAJAOALGHMK.InitControls();
		GHINFPBNJFC.InitControls();
		HIOONEIFKMF.gameObject.SetActive(value: false);
		NHELGDJHDHP();
		DebugSettings.instance.Changed += KBLKGMEKGAI;
	}

	public void DAMNGMBFEOB()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Info;
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(this);
		}
	}

	private void HJKLHKGHCJK(MPJAFCCIOEO GEOBBGJFOHJ, bool PDPDGCNHCFN = false)
	{
		FIDMHHGBLOE = GEOBBGJFOHJ;
		CNKMNOPMPNJ(PDPDGCNHCFN);
		JBMHHEJPADG(PDPDGCNHCFN);
		OKKHKLPNHHK(PDPDGCNHCFN);
	}

	public void BONGNHLNECG()
	{
		FIDMHHGBLOE = (MPJAFCCIOEO)8;
		if (NPFFMLLLDAF())
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(this);
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("SquadEmblem");
	}

	[SpecialName]
	public UIDraggablePanel FMGFDCMDLGB()
	{
		if (FIDMHHGBLOE == (MPJAFCCIOEO)7)
		{
			return NILIEMMOFNN.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == (MPJAFCCIOEO)8)
		{
			return PEBBFADKJFC.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Event)
		{
			return BAJAOALGHMK.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Cardpool)
		{
			return FCIOFJOCLPJ.NFLPPGKCOBL;
		}
		return BBNLILBDOEC.NFLPPGKCOBL;
	}

	public virtual void BBIHNICEDGE()
	{
		base.DoAfterHide();
		BBNLILBDOEC.InstantHideTab();
		FCIOFJOCLPJ.InstantHideTab();
		NILIEMMOFNN.InstantHideTab();
		PEBBFADKJFC.IJPBMJKNPAN();
		BAJAOALGHMK.HONGPOAOIJC();
		GHINFPBNJFC.AFJOOMBDLFJ();
		CardManager.instance.ResetSquadCards(GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.BIMDNMKEFNM());
		GEAGOKJMJFD.mainTexture = null;
		LCLNBHPNCIK = null;
	}

	private static void CBMIOOBHGDP(DatabasePlayer KHLGDCHJJPB, bool NILPBCGHEDG)
	{
		NFFDKDNHOAN nFFDKDNHOAN = new NFFDKDNHOAN();
		nFFDKDNHOAN.KHLGDCHJJPB = KHLGDCHJJPB;
		if (NILPBCGHEDG)
		{
			string oKMNFHNBMFA = Localization.Localize("getSettingsIntent");
			object[] array = new object[1];
			array[1] = nFFDKDNHOAN.KHLGDCHJJPB.name;
			ConfirmDialog.ShowConfirm(oKMNFHNBMFA, Localization.LocalizeFormat("localSquadLeaderboard", array), nFFDKDNHOAN.MFCNOIDCJME, 1778f);
		}
	}

	public void InviteToSquadClick(GameObject KHAHPAKDIKE)
	{
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
		if (!aANECPGDMGM.IOLNJBGOOLJ && flag)
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANTSENDINVITE_TEXT"), Localization.Localize("ID_WARNING_CANTSENDINVITE"), 0f, null, string.Empty);
		}
		else if (aANECPGDMGM != null && aANECPGDMGM.MGDCJLAENHG() <= 0)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance);
		}
		else
		{
			SelectFriendsDialog.ShowSquadInviteDialog(GCJDFBHEPHN, selectedDragablePanel, 0.2f);
		}
	}

	public void DIBLGNDMPKK(GameObject KHAHPAKDIKE)
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, NICBOKPIBIA: true);
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.IGGCEILJEFM(null, Localization.Localize("width"), Localization.Localize("OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}"));
		}
		else if (aANECPGDMGM.FOICGJEPBGL == 1)
		{
			ConfirmDialog.ShowConfirm(Localization.Localize("QUIT"), Localization.Localize("Items"), HIAFMACHJHB, 1908f);
		}
		else if (currentPlayer.squadRank == SquadRank.Member)
		{
			SelectSquadLeaderDialog.ShowSelectNewSquadLeader(delegate(DatabasePlayer KHLGDCHJJPB, bool NILPBCGHEDG)
			{
				NFFDKDNHOAN nFFDKDNHOAN = new NFFDKDNHOAN
				{
					KHLGDCHJJPB = KHLGDCHJJPB
				};
				if (NILPBCGHEDG)
				{
					ConfirmDialog.ShowConfirm(Localization.Localize("ID_CONFIRM_LEAVESQUAD"), Localization.LocalizeFormat("ID_CONFIRM_LEAVESQUADLEADER_TEXT", nFFDKDNHOAN.KHLGDCHJJPB.name), nFFDKDNHOAN.LJCDGJKCNEC);
				}
			}, GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.NFLPPGKCOBL);
		}
		else
		{
			ConfirmDialog.BMBPFNKJHMF(Localization.Localize("warfriends-staging.eu-west-1.elasticbeanstalk.com/"), Localization.Localize("PartsGainedLootbox"), BBIFKJLKHIP, 1758f);
		}
	}

	public void ShowSquadCardpool()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Cardpool;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	[SpecialName]
	public UIDraggablePanel CJNONDADAFN()
	{
		if (FIDMHHGBLOE == MPJAFCCIOEO.Stats)
		{
			return NILIEMMOFNN.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == (MPJAFCCIOEO)7)
		{
			return PEBBFADKJFC.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Member)
		{
			return BAJAOALGHMK.NFLPPGKCOBL;
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Member)
		{
			return FCIOFJOCLPJ.NFLPPGKCOBL;
		}
		return BBNLILBDOEC.NFLPPGKCOBL;
	}

	private static void JAHAHHEEDDC(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
		}
	}

	public void KJAGGNNGLJD()
	{
		FIDMHHGBLOE = MPJAFCCIOEO.Cardpool;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(this);
		}
	}

	public override void InitGUIValues()
	{
		KBLKGMEKGAI();
		HIHOANALHPH();
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return;
		}
		if (string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			BBFLANGMBJG();
			return;
		}
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
		if (aANECPGDMGM == null)
		{
			MDIHOPBIFJA();
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
		}
		else
		{
			CJIEFKAHCGD(aANECPGDMGM);
		}
	}

	private void MGECKFLAOIO(DatabasePlayer KKHKAJPNDEC, bool NCMHGPNPEJM)
	{
		if (KKHKAJPNDEC == null)
		{
			return;
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		if (KKHKAJPNDEC.squadName == currentPlayer.squadName)
		{
			string oKMNFHNBMFA = Localization.Localize("ID_NOTIFICATION_DAILYREWARD_GOLD");
			object[] array = new object[0];
			array[0] = KKHKAJPNDEC.name;
			ConfirmDialog.JDEDLDGMHBJ(oKMNFHNBMFA, Localization.LocalizeFormat("DailyMissionsData", array), 1659f);
			return;
		}
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM != null)
		{
			bool flag = currentPlayer.squadRank == SquadRank.Member;
			if (!aANECPGDMGM.IOLNJBGOOLJ && flag)
			{
				WarningDialog.ShowError(Localization.Localize("NULL WARCARD"), Localization.Localize("Buy_Unit_Upgrade"), 891f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			}
			else if (aANECPGDMGM.GGJGGJOHMFD() <= 0)
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance, 47f);
			}
			else
			{
				Singleton<BeanstalkServerManager>.instance.PANLBEECIAB(KKHKAJPNDEC);
			}
		}
	}

	private static void FKJIIMHEPGL(ConfirmDialog JAGBOPMGIAA, bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			Singleton<BeanstalkServerManager>.instance.MOGOJFFMFED();
		}
	}

	public void BEHNAAICODN()
	{
		FIDMHHGBLOE = (MPJAFCCIOEO)6;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	public void GBDHMHCMBLN()
	{
		FIDMHHGBLOE = (MPJAFCCIOEO)6;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(this);
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (!isShowed)
		{
			return;
		}
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.GetSquadDetails:
		{
			WaitingDialog.Hide();
			DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
			if (!string.IsNullOrEmpty(currentPlayer.squadName))
			{
				AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName);
				if (aANECPGDMGM == null)
				{
					aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(currentPlayer.squadName, NICBOKPIBIA: true);
				}
				if (aANECPGDMGM != null)
				{
					CJIEFKAHCGD(aANECPGDMGM);
				}
				else
				{
					InitGUIValues();
				}
			}
			else
			{
				InitGUIValues();
			}
			break;
		}
		case DatabaseAction.GetAllSquadMembers:
			GEDJLHKCCCA();
			break;
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (FIDMHHGBLOE == MPJAFCCIOEO.Member)
		{
			BBNLILBDOEC.Animate(PJIEFMBDLBE: false, PDPDGCNHCFN: false);
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Cardpool)
		{
			FCIOFJOCLPJ.Animate(PJIEFMBDLBE: false, PDPDGCNHCFN: false);
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Event)
		{
			NILIEMMOFNN.Animate(PJIEFMBDLBE: false, PDPDGCNHCFN: false);
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Stats)
		{
			PEBBFADKJFC.Animate(PJIEFMBDLBE: false, PDPDGCNHCFN: false);
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Emblem)
		{
			BAJAOALGHMK.Animate(PJIEFMBDLBE: false, PDPDGCNHCFN: false);
		}
		if (FIDMHHGBLOE == MPJAFCCIOEO.Info)
		{
			GHINFPBNJFC.Animate(PJIEFMBDLBE: false, PDPDGCNHCFN: false);
		}
		Singleton<AwaitingSquadMembersManager>.instance.RemoveErrorPlayers();
	}

	public void ADGLBKCJGBK(AANECPGDMGM MIDDFOCJJOP)
	{
		if (isShowed && MIDDFOCJJOP != null && GameLoginManager.currentPlayer.squadName == MIDDFOCJJOP.MHPNDNJDPGE)
		{
			CEPGKMBDLPP(MIDDFOCJJOP);
		}
	}

	private void FGDFFJMDNHB(GameObject KHAHPAKDIKE)
	{
		if (DebugSettings.debugEnabled || !JBOHFMAPCJL.activeSelf)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadCreateScreen>.instance);
		}
	}

	private void EHEKIGJKEJL(bool JHIALFMFBMJ, float HECJLCFJMBM, bool JNFEBGFALBI, float KBJLCLKFAEB, bool PDPDGCNHCFN)
	{
		ILKOLBHGAMN iLKOLBHGAMN = new ILKOLBHGAMN();
		iLKOLBHGAMN.HECJLCFJMBM = HECJLCFJMBM;
		iLKOLBHGAMN.KBJLCLKFAEB = KBJLCLKFAEB;
		iLKOLBHGAMN.JHIALFMFBMJ = JHIALFMFBMJ;
		iLKOLBHGAMN.JNFEBGFALBI = JNFEBGFALBI;
		iLKOLBHGAMN.BJGCPDNMHDH = this;
		if (PDPDGCNHCFN)
		{
			BPEAMJBCLHM(iLKOLBHGAMN.HECJLCFJMBM, iLKOLBHGAMN.KBJLCLKFAEB);
			KCBAFHJOJCP.alpha = ((!iLKOLBHGAMN.JHIALFMFBMJ) ? 959f : 1590f);
			JAHOEJODKOH.alpha = ((!iLKOLBHGAMN.JNFEBGFALBI) ? 1700f : 15f);
			TweenAlpha component = KCBAFHJOJCP.gameObject.GetComponent<TweenAlpha>();
			if (component != null)
			{
				component.enabled = false;
			}
			TweenAlpha component2 = JAHOEJODKOH.gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.onFinished = null;
				component2.enabled = true;
			}
		}
		else
		{
			TweenAlpha.Begin(KCBAFHJOJCP.gameObject, HAMKIKMJHDP, 1130f);
			TweenAlpha.Begin(JAHOEJODKOH.gameObject, HAMKIKMJHDP, 1151f).onFinished = iLKOLBHGAMN.OKNCFDMEFGJ;
		}
	}

	public void HIIAIPJNLDG(string PCDMKLAJINM)
	{
		if (LCLNBHPNCIK != PCDMKLAJINM)
		{
			Debug.Log(string.Format("ID_SQUADEVENT", PCDMKLAJINM));
			GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("Hero {0:D2}" + PCDMKLAJINM);
			LCLNBHPNCIK = PCDMKLAJINM;
		}
		else
		{
			Debug.Log(string.Format("ID_TUTORIAL_GRENADERS_DOWN", PCDMKLAJINM));
		}
	}

	public void EIMIICGAJNI(GameObject KHAHPAKDIKE)
	{
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Veteran;
		if (!aANECPGDMGM.IOLNJBGOOLJ && flag)
		{
			WarningDialog.ShowError(Localization.Localize("menu-assignments-type-score"), Localization.Localize("set unit not borrowed"), 1135f, null, string.Empty, JCOGJEEFLBC: true);
		}
		else if (aANECPGDMGM != null && aANECPGDMGM.JPMNFIPABND() <= 1)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<IncreaseSquadRankDialog>.instance, 484f);
		}
		else
		{
			SelectFriendsDialog.ShowSquadInviteDialog(GCJDFBHEPHN, FFCJIOIOPKM(), 894f);
		}
	}
}
