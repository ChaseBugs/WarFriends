using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EndScreen : GuiScreenSingle<EndScreen>
{
	public enum MPJAFCCIOEO
	{
		Results = 0,
		Assignments = 1,
		Enemy = 2,
		WarCards = 3,
		Ribbons = 4,
		None = 5
	}

	private sealed class EHLEKNMNNLJ : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal EndScreen BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGBGCFGNJLA()
		{
			return PHDOCKCBJOF;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JEGNECDPAFK.NPADJCKMJDJ());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.BHKFICKPPPL((!Singleton<GameController>.instance.isChallenge) ? MPJAFCCIOEO.Results : MPJAFCCIOEO.Results);
				if (!Singleton<GameController>.instance.DAIEAMEFGIE())
				{
					Singleton<ChillingoSdkManager>.instance.activateOffers();
				}
				if (Singleton<GameController>.instance.BGAJLJEJEFG())
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.CCIGMPCGACE(BJGCPDNMHDH.DHNNCMHLOEM.DDAOMANBNAG(), 612f));
				}
				else if (BJGCPDNMHDH.isSinglePlayer)
				{
					BJGCPDNMHDH.KLGINBGMGDB.CHDFMEMNIBI();
				}
				else
				{
					BJGCPDNMHDH.KNOAGNHKDIM.EMPENFMILID();
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JEGNECDPAFK.DEEMMCDGJPF());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.BHKFICKPPPL((!Singleton<GameController>.instance.isChallenge) ? MPJAFCCIOEO.Results : MPJAFCCIOEO.Results);
				if (!Singleton<GameController>.instance.isTutorial)
				{
					Singleton<ChillingoSdkManager>.instance.PFENHNJDBDI();
				}
				if (Singleton<GameController>.instance.isChallenge)
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BAOHFDGALNH(BJGCPDNMHDH.DHNNCMHLOEM.DDAOMANBNAG(), 152f));
				}
				else if (BJGCPDNMHDH.isSinglePlayer)
				{
					BJGCPDNMHDH.KLGINBGMGDB.PIKJANINGML();
				}
				else
				{
					BJGCPDNMHDH.KNOAGNHKDIM.EMPENFMILID();
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void KCHOLCGBMBJ()
		{
			throw new NotSupportedException();
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JEGNECDPAFK.OPJPLCLCGIM());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.BHKFICKPPPL((!Singleton<GameController>.instance.BGAJLJEJEFG()) ? MPJAFCCIOEO.Assignments : MPJAFCCIOEO.Assignments);
				if (!Singleton<GameController>.instance.BAKCODKBCPJ())
				{
					Singleton<ChillingoSdkManager>.instance.MNFALFLFADP();
				}
				if (Singleton<GameController>.instance.BGAJLJEJEFG())
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BAOHFDGALNH(BJGCPDNMHDH.DHNNCMHLOEM.Animator, 1421f));
				}
				else if (BJGCPDNMHDH.isSinglePlayer)
				{
					BJGCPDNMHDH.KLGINBGMGDB.PIKJANINGML();
				}
				else
				{
					BJGCPDNMHDH.KNOAGNHKDIM.OPCIAJBNFIA();
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JEGNECDPAFK.PlayAnimation());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.BHKFICKPPPL(Singleton<GameController>.instance.BGAJLJEJEFG() ? MPJAFCCIOEO.Assignments : MPJAFCCIOEO.Results);
				if (!Singleton<GameController>.instance.BAKCODKBCPJ())
				{
					Singleton<ChillingoSdkManager>.instance.activateOffers();
				}
				if (Singleton<GameController>.instance.BGAJLJEJEFG())
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.BAOHFDGALNH(BJGCPDNMHDH.DHNNCMHLOEM.Animator, 569f));
				}
				else if (BJGCPDNMHDH.isSinglePlayer)
				{
					BJGCPDNMHDH.KLGINBGMGDB.CHDFMEMNIBI();
				}
				else
				{
					BJGCPDNMHDH.KNOAGNHKDIM.CHDFMEMNIBI();
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJKHNOHHDGO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JEGNECDPAFK.PlayAnimation());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.BHKFICKPPPL(Singleton<GameController>.instance.isChallenge ? MPJAFCCIOEO.Assignments : MPJAFCCIOEO.Results);
				if (!Singleton<GameController>.instance.isTutorial)
				{
					Singleton<ChillingoSdkManager>.instance.activateOffers();
				}
				if (Singleton<GameController>.instance.isChallenge)
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HLCDIOAIKJL(BJGCPDNMHDH.DHNNCMHLOEM.Animator, 0.3f));
				}
				else if (BJGCPDNMHDH.isSinglePlayer)
				{
					BJGCPDNMHDH.KLGINBGMGDB.FHBFFOOFGJD();
				}
				else
				{
					BJGCPDNMHDH.KNOAGNHKDIM.FHBFFOOFGJD();
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JEGNECDPAFK.AKOFBFPKAJO());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.BHKFICKPPPL(Singleton<GameController>.instance.BGAJLJEJEFG() ? MPJAFCCIOEO.Assignments : MPJAFCCIOEO.Results);
				if (!Singleton<GameController>.instance.DAIEAMEFGIE())
				{
					Singleton<ChillingoSdkManager>.instance.PFENHNJDBDI();
				}
				if (Singleton<GameController>.instance.isChallenge)
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HBGMDCDPBFM(BJGCPDNMHDH.DHNNCMHLOEM.Animator, 832f));
				}
				else if (BJGCPDNMHDH.isSinglePlayer)
				{
					BJGCPDNMHDH.KLGINBGMGDB.FHBFFOOFGJD();
				}
				else
				{
					BJGCPDNMHDH.KNOAGNHKDIM.CHDFMEMNIBI();
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public EHLEKNMNNLJ()
		{
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.JEGNECDPAFK.DEEMMCDGJPF());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.BHKFICKPPPL(Singleton<GameController>.instance.BGAJLJEJEFG() ? MPJAFCCIOEO.Assignments : MPJAFCCIOEO.Results);
				if (!Singleton<GameController>.instance.BAKCODKBCPJ())
				{
					Singleton<ChillingoSdkManager>.instance.activateOffers();
				}
				if (Singleton<GameController>.instance.BGAJLJEJEFG())
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.HLCDIOAIKJL(BJGCPDNMHDH.DHNNCMHLOEM.DDAOMANBNAG(), 1211f));
				}
				else if (BJGCPDNMHDH.isSinglePlayer)
				{
					BJGCPDNMHDH.KLGINBGMGDB.PIKJANINGML();
				}
				else
				{
					BJGCPDNMHDH.KNOAGNHKDIM.FHBFFOOFGJD();
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class ANOMAEMCAON : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<TweenAnimator> MDKGNNAGBPA;

		internal List<TweenAnimator>.Enumerator KFCAECGLKKO;

		internal TweenAnimator JADPOLBPBNE;

		internal float KALLNCAFIMP;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public ANOMAEMCAON()
		{
		}

		[DebuggerHidden]
		public void Dispose()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public bool MoveNext()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = false;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = MDKGNNAGBPA.GetEnumerator();
				num = 4294967293u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JADPOLBPBNE = KFCAECGLKKO.Current;
						if (JADPOLBPBNE.BEOAHFDJEMD.Count <= 0)
						{
							continue;
						}
						JADPOLBPBNE.PlayTweens();
						if (!(KALLNCAFIMP > 0f))
						{
							continue;
						}
						PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = true;
						goto IL_00e5;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_00e5:
				return true;
			}
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public bool HDGDKCMIOGK()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = MDKGNNAGBPA.GetEnumerator();
				num = 4294967204u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JADPOLBPBNE = KFCAECGLKKO.Current;
						if (JADPOLBPBNE.BEOAHFDJEMD.Count <= 1)
						{
							continue;
						}
						JADPOLBPBNE.OKEBGBENAJF();
						if (!(KALLNCAFIMP > 1603f))
						{
							continue;
						}
						PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						flag = true;
						goto IL_00e5;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00e5:
				return true;
			}
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public bool NJBCJDFKGHO()
		{
			uint num = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			bool flag = true;
			switch (num)
			{
			case 0u:
				KFCAECGLKKO = MDKGNNAGBPA.GetEnumerator();
				num = 118u;
				goto case 1u;
			case 1u:
				try
				{
					switch (num)
					{
					}
					while (KFCAECGLKKO.MoveNext())
					{
						JADPOLBPBNE = KFCAECGLKKO.Current;
						if (JADPOLBPBNE.BEOAHFDJEMD.Count <= 0)
						{
							continue;
						}
						JADPOLBPBNE.HMPMBAGNJOJ();
						if (!(KALLNCAFIMP > 268f))
						{
							continue;
						}
						PHDOCKCBJOF = new WaitForSeconds(KALLNCAFIMP);
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						flag = false;
						goto IL_00e5;
					}
				}
				finally
				{
					if (!flag)
					{
						((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
					}
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_00e5:
				return true;
			}
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				try
				{
					break;
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
			case 0u:
				break;
			}
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}
	}

	[Header("Left Content")]
	public GameObject EBJKNDMODOP;

	public List<EndScreenButton> PJCHHCCCCFB;

	[Header("Center Content")]
	public List<GameObject> BMANEHNHPGC;

	public ResultsContent KNOAGNHKDIM;

	public ResultsCampaignContent KLGINBGMGDB;

	public AssignmentsContent DHNNCMHLOEM;

	public EnemyContent KGGJOOAFDIF;

	public CardsContent HGPGKHLOHEF;

	public RibbonsContent NDJCNHDBJMM;

	[Header("Bottom Content")]
	public ButtonsContent MPLELHEKGHO;

	[Header("Card Animations")]
	public GameObject PLHEDGFGMBM;

	public GainedCardsAnimation JEGNECDPAFK;

	[Header("Debug")]
	public GameObject FFGAOOAICAH;

	public UIButton DIKOLBOGDIC;

	public UIButton LEFEKKMGKGB;

	public readonly float EOPGDDCOKAM = 0.8f;

	private MPJAFCCIOEO FIMOPHPNBNM;

	private List<bool> GDICADMMAKE = new List<bool>();

	private TweenAnimator FNOMCHPCOHB;

	private Vector3 JPDPFJHCKGK = new Vector3(-560f, 0f, 0f);

	private Vector3 NJJDHJJMOMJ = new Vector3(100f, 0f, 0f);

	private Vector3 IKHDPODEHIF = new Vector3(0f, 0f, 0f);

	private float HCOJLJOCALK = 156f;

	private bool IOBOOEKGPIO;

	public List<CCNAEIGGMNK> videoRewardLootbox { get; set; }

	public bool shouldGetLootboxForAd { get; set; }

	public bool isEndScreenLootboxAnimations { get; set; }

	public bool isEnteredBeginnersLeague { get; set; }

	public bool OILKNBFJLHE { private get; set; }

	public bool isSinglePlayer
	{
		get
		{
			return Singleton<GameController>.instance.isTutorial || Singleton<GameController>.instance.isMission;
		}
	}

	public bool canShowLvlUp
	{
		get
		{
			return (isSinglePlayer && KLGINBGMGDB.showLevelUp) || (!isSinglePlayer && KNOAGNHKDIM.showLevelUp);
		}
	}

	public bool buttonsEnabled
	{
		get
		{
			return !canShowLvlUp && !JEGNECDPAFK.gameObject.activeSelf;
		}
	}

	public override bool dialogsEnabled
	{
		get
		{
			return base.dialogsEnabled && !OILKNBFJLHE;
		}
	}

	[SpecialName]
	public void EAGFCKNHAGD(bool IDEBKDPMPGM)
	{
		_003CHGFKHFIPOMC_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void OPAEGKCLGFK(GameObject KHAHPAKDIKE)
	{
		if (!JEGNECDPAFK.gameObject.activeSelf && FIMOPHPNBNM != MPJAFCCIOEO.Results)
		{
			CNOOENELODC(FIMOPHPNBNM);
			BHKFICKPPPL(MPJAFCCIOEO.Assignments);
			DHNNCMHLOEM.UpdateAssignments(true);
			if (!GDICADMMAKE[0])
			{
				StartCoroutine(BAOHFDGALNH(DHNNCMHLOEM.Animator, 822f));
				GDICADMMAKE[0] = false;
			}
		}
	}

	private void HCOPBKPIINA(GameObject KHAHPAKDIKE)
	{
		if (!JEGNECDPAFK.gameObject.activeSelf && FIMOPHPNBNM != MPJAFCCIOEO.Ribbons)
		{
			LJLAMPJIALH(FIMOPHPNBNM);
			BHKFICKPPPL(MPJAFCCIOEO.Ribbons);
			NDJCNHDBJMM.AKFLKJBMBAJ.AlignToPos(true);
			if (!GDICADMMAKE[4])
			{
				StartCoroutine(HLCDIOAIKJL(NDJCNHDBJMM.Animator, 0f));
				GDICADMMAKE[4] = true;
			}
		}
	}

	public void AOOIMBPEKME(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (buttonsEnabled)
		{
			IOBOOEKGPIO = true;
			if (Singleton<GameController>.instance.ALPNOKNLMEG())
			{
				Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.NOPGGANHAFN().name);
			}
			if (Singleton<GameController>.instance.isCoop)
			{
				Singleton<GameController>.instance.Rematch();
			}
		}
	}

	public void TestReplayWithAddingLevel()
	{
		GuiElementSingle<LevelUpDialog>.instance.HideDialog();
		FNOMCHPCOHB.FinishTweens();
		GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		LevelManager.instance.DebugAddLevel();
		InitGUIValues();
		FNOMCHPCOHB.PlayTweens();
	}

	public void KFCGAJAIIEN()
	{
		GuiElementSingle<LevelUpDialog>.instance.HideDialog();
		FNOMCHPCOHB.CJGJOAKNIIL();
		GuiElementSingle<MenuHeader>.instance.JFODBIOHGJP(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		LevelManager.instance.DebugAddLevel();
		InitGUIValues();
		FNOMCHPCOHB.OKEBGBENAJF();
	}

	[SpecialName]
	public bool KIPLFBCJCJM()
	{
		return _003CHGFKHFIPOMC_003Ek__BackingField;
	}

	private void AKBILFPDJDJ(GameObject KHAHPAKDIKE)
	{
		if (!JEGNECDPAFK.gameObject.activeSelf && FIMOPHPNBNM != MPJAFCCIOEO.Assignments)
		{
			LJLAMPJIALH(FIMOPHPNBNM);
			BHKFICKPPPL(MPJAFCCIOEO.Assignments);
			DHNNCMHLOEM.UpdateAssignments();
			if (!GDICADMMAKE[1])
			{
				StartCoroutine(HLCDIOAIKJL(DHNNCMHLOEM.Animator, 0.3f));
				GDICADMMAKE[1] = true;
			}
		}
	}

	public void NextButtonClick(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (!buttonsEnabled)
		{
			return;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
			{
				if (weaponLevelsSetup.FICHPKKDGBK)
				{
					GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(weaponLevelsSetup);
				}
			}
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
			GuiScreenSingle<WeaponScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		}
		else if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.upgradeSlots.isTutorialUnit)
				{
					GuiScreenSingle<ArmyScreen>.instance.SelectUnit(behaviour);
				}
			}
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			GuiScreenSingle<ArmyScreen>.instance.previousScreen = GuiScreenSingle<BattlePreparationScreen>.instance;
		}
		else if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			TutorialManagerStage3.instance.FinishMenuTutorial();
			ObjectPoolDatabase.InstantiatePooledObjects(NPNOIGHIALL.Menu);
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
		}
		else if (TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
		}
		else if (LevelManager.instance.isDailyMissionLocked)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
		}
		else if (DailyMissionsManager.instance.currentMission.isHeroic)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<HeroicScreen>.instance);
			GuiScreenSingle<HeroicScreen>.instance.previousScreen = GuiScreenSingle<DailyMissionScreen>.instance;
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
		}
	}

	public void GEEAHNDDJJC()
	{
		GuiElementSingle<LevelUpDialog>.instance.HideDialog();
		FNOMCHPCOHB.HLKNEKNIENJ();
		GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		InitGUIValues();
		FNOMCHPCOHB.AGFMCNDAEEC();
	}

	public override void OIEPFDKMCNC()
	{
		if (GuiScreenSingle<EndScreen>.instance.NMIKNNCLOHD())
		{
			AEGGGBJBLAF((MPJAFCCIOEO)7);
		}
		else
		{
			HOECAONMABB(MPJAFCCIOEO.Assignments);
		}
	}

	public virtual void LKAAFLJKHKE(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		KNOAGNHKDIM.AnimateShow(DCIKANJJFIJ);
		KLGINBGMGDB.LCOOIAJMOPE(DCIKANJJFIJ);
		DHNNCMHLOEM.DBNECBAHPEN(DCIKANJJFIJ);
		KGGJOOAFDIF.FPAPHEHMEOO(DCIKANJJFIJ);
		HGPGKHLOHEF.AnimateShow(DCIKANJJFIJ);
		NDJCNHDBJMM.FPAPHEHMEOO(DCIKANJJFIJ);
	}

	private void JIEMJFINFPM()
	{
		PJCHHCCCCFB[1].IDKGDFDFECC(true);
		if (PJCHHCCCCFB[0].gameObject.activeSelf)
		{
			PJCHHCCCCFB[0].BBCDHJLBEIJ(false);
		}
		if (PJCHHCCCCFB[8].gameObject.activeSelf)
		{
			PJCHHCCCCFB[6].PKEIIFMJDKO(true);
		}
		if (PJCHHCCCCFB[5].gameObject.activeSelf)
		{
			PJCHHCCCCFB[5].NECPEMBFGHE(false);
		}
		if (PJCHHCCCCFB[8].gameObject.activeSelf)
		{
			PJCHHCCCCFB[1].SetButton(false);
		}
	}

	private void CNOOENELODC(MPJAFCCIOEO GEIDIHFGMDF)
	{
		switch (GEIDIHFGMDF)
		{
		case MPJAFCCIOEO.Results:
			if (NMIKNNCLOHD())
			{
				KLGINBGMGDB.HBGCLNNLELH();
			}
			else
			{
				KNOAGNHKDIM.JEOICJEKMAB();
			}
			break;
		case MPJAFCCIOEO.Assignments:
			DHNNCMHLOEM.CHFHLKLFPIK();
			break;
		case MPJAFCCIOEO.Enemy:
			KGGJOOAFDIF.KCCIMOFPMJL();
			break;
		case MPJAFCCIOEO.WarCards:
			HGPGKHLOHEF.POMCHBHLNIB();
			break;
		case MPJAFCCIOEO.Ribbons:
			NDJCNHDBJMM.BOKMAOJKDCI();
			break;
		}
		AILMGPGJAGE();
		FNOMCHPCOHB.CJGJOAKNIIL();
	}

	public virtual void FKAPFKFFCHG()
	{
		base.DoBeforeShowUp();
		OILKNBFJLHE = true;
		MCADKOEBOHN();
		foreach (EndScreenButton item in PJCHHCCCCFB)
		{
			item.AEPKOJGAKMH();
		}
		GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.AHGPPGFIJLL());
		IOBOOEKGPIO = true;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		DHNNCMHLOEM.DoAfterHide();
		KGGJOOAFDIF.DoAfterHide();
		HGPGKHLOHEF.DoAfterHide();
		NDJCNHDBJMM.DoAfterHide();
		Singleton<ChillingoSdkManager>.instance.deactivateOffers();
		Singleton<Recording>.instance.CancelRecording();
		videoRewardLootbox = null;
		isEnteredBeginnersLeague = false;
	}

	public override void OnBack()
	{
		if (GuiScreenSingle<EndScreen>.instance.isSinglePlayer)
		{
			NextButtonClick(MPJAFCCIOEO.WarCards);
		}
		else
		{
			ContinueButtonClick(MPJAFCCIOEO.WarCards);
		}
	}

	public void KJINDMFGFAI(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (buttonsEnabled)
		{
			if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
			{
				IOBOOEKGPIO = false;
				Singleton<GameController>.instance.HGBNEFDBFDC();
				TutorialManagerPlayWarcards.instance.StartTutorial(false);
			}
			else if (!Singleton<GameController>.instance.FJOGEJNMNHI() || Singleton<DogTagManager>.instance.CanUseDogtags(0))
			{
				IOBOOEKGPIO = true;
				Singleton<GameController>.instance.Rematch();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance, 1554f);
			}
		}
	}

	[SpecialName]
	public List<CCNAEIGGMNK> CBMPMHIJDCD()
	{
		return _003CBBIJNDANGKP_003Ek__BackingField;
	}

	public override void AnimateShow(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		KNOAGNHKDIM.AnimateShow(DCIKANJJFIJ);
		KLGINBGMGDB.AnimateShow(DCIKANJJFIJ);
		DHNNCMHLOEM.AnimateShow(DCIKANJJFIJ);
		KGGJOOAFDIF.AnimateShow(DCIKANJJFIJ);
		HGPGKHLOHEF.AnimateShow(DCIKANJJFIJ);
		NDJCNHDBJMM.AnimateShow(DCIKANJJFIJ);
	}

	private void GECEJPNEDIG(GameObject KHAHPAKDIKE)
	{
		if (!JEGNECDPAFK.gameObject.activeSelf && FIMOPHPNBNM != MPJAFCCIOEO.WarCards)
		{
			LJLAMPJIALH(FIMOPHPNBNM);
			HGPGKHLOHEF.SetCardsAvailable();
			BHKFICKPPPL(MPJAFCCIOEO.WarCards);
			HGPGKHLOHEF.HKJLIGAMNKA.ResetPosition();
			if (!GDICADMMAKE[3])
			{
				StartCoroutine(HLCDIOAIKJL(HGPGKHLOHEF.Animator));
				GDICADMMAKE[3] = true;
			}
		}
	}

	private void EICBIKPNADF(GameObject KHAHPAKDIKE)
	{
		if (!JEGNECDPAFK.gameObject.activeSelf && FIMOPHPNBNM != MPJAFCCIOEO.Assignments)
		{
			CNOOENELODC(FIMOPHPNBNM);
			BHKFICKPPPL(MPJAFCCIOEO.Results);
			DHNNCMHLOEM.UpdateAssignments();
			if (!GDICADMMAKE[1])
			{
				StartCoroutine(HBGMDCDPBFM(DHNNCMHLOEM.DDAOMANBNAG(), 809f));
				GDICADMMAKE[1] = false;
			}
		}
	}

	public virtual void BCACBNHFMDA()
	{
		base.DoBeforeShowUp();
		BLJOAMPFIKL(true);
		MCADKOEBOHN();
		foreach (EndScreenButton item in PJCHHCCCCFB)
		{
			item.IDGEKDELIBL();
		}
		GuiElementSingle<MenuHeader>.instance.JFODBIOHGJP(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		IOBOOEKGPIO = true;
	}

	public void HOECAONMABB(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (buttonsEnabled)
		{
			EventAssignmentManager.CGFOOMLLMFG().CheckToShowDialog();
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
		}
	}

	public void ContinueButtonClick(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (buttonsEnabled)
		{
			EventAssignmentManager.instance.CheckToShowDialog();
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
		}
	}

	[SpecialName]
	public void OOPOJBGKBBD(bool IDEBKDPMPGM)
	{
		_003CHFGAMBFLHKO_003Ek__BackingField = IDEBKDPMPGM;
	}

	public override void InitGUIValues()
	{
		KBLKGMEKGAI();
		videoRewardLootbox = null;
		try
		{
			NDJCNHDBJMM.InitGuiValues();
			HGPGKHLOHEF.PILDGJHBBIJ();
			DHNNCMHLOEM.InitGuiValues();
			if (isSinglePlayer)
			{
				KLGINBGMGDB.InitGuiValues();
			}
			else
			{
				KGGJOOAFDIF.InitGuiValues();
				if (!Singleton<GameController>.instance.isChallenge)
				{
					KNOAGNHKDIM.InitGuiValues();
				}
			}
			JEGNECDPAFK.InitGUIValues();
			MPLELHEKGHO.PILDGJHBBIJ();
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError(string.Format("END SUBSCREEN OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}", base.gameObject.name, ex.Message, ex.StackTrace));
			if (DebugSettings.debugEnabled)
			{
				WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_GUIERROR"), 0f, null, string.Empty, true);
			}
			AnalyticsHelper.LogHandledException(ex);
		}
		BMANEHNHPGC[0].SetActive(false);
		BMANEHNHPGC[1].SetActive(false);
		BMANEHNHPGC[2].SetActive(false);
		BMANEHNHPGC[3].SetActive(false);
		BMANEHNHPGC[4].SetActive(false);
		BMANEHNHPGC[5].SetActive(false);
		MPLELHEKGHO.gameObject.SetActive(false);
		IBFKCMDILHL();
		NHMNCEFNGIB();
		FIMOPHPNBNM = MPJAFCCIOEO.Results;
		KBLHMIHEBDA();
	}

	public override void InitEvents()
	{
		base.InitEvents();
		FNOMCHPCOHB = base.gameObject.AddComponent<TweenAnimator>();
		KNOAGNHKDIM.PJFGCMCKMJF.InitEvents();
	}

	public void AEGGGBJBLAF(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (!buttonsEnabled)
		{
			return;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
			{
				if (weaponLevelsSetup.FICHPKKDGBK)
				{
					GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(weaponLevelsSetup);
				}
			}
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<WeaponScreen>.instance);
			GuiScreenSingle<WeaponScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
		}
		else if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.upgradeSlots.isTutorialUnit)
				{
					GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(behaviour);
				}
			}
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			GuiScreenSingle<ArmyScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<BattlePreparationScreen>.instance);
		}
		else if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			TutorialManagerStage3.instance.FinishMenuTutorial();
			ObjectPoolDatabase.KHLPFECMGCL((NPNOIGHIALL)6);
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<MainScreen>.instance);
		}
		else if (TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
		}
		else if (LevelManager.instance.isDailyMissionLocked)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<MainScreen>.instance);
		}
		else if (DailyMissionsManager.instance.DPLEEBIFDKL().isHeroic)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HeroicScreen>.instance);
			GuiScreenSingle<HeroicScreen>.instance.previousScreen = GuiScreenSingle<DailyMissionScreen>.instance;
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<DailyMissionScreen>.instance);
		}
	}

	public virtual void DBNECBAHPEN(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		KNOAGNHKDIM.CHHDHKCLOBG(DCIKANJJFIJ);
		KLGINBGMGDB.AnimateShow(DCIKANJJFIJ);
		DHNNCMHLOEM.DBNECBAHPEN(DCIKANJJFIJ);
		KGGJOOAFDIF.DFEJBGDJGGK(DCIKANJJFIJ);
		HGPGKHLOHEF.AnimateShow(DCIKANJJFIJ);
		NDJCNHDBJMM.FPAPHEHMEOO(DCIKANJJFIJ);
	}

	private void PIGCCMDBMPJ(int EAINKPNECEC)
	{
		if ((EAINKPNECEC == 35 && !Singleton<GameController>.instance.DAIEAMEFGIE()) || (EAINKPNECEC == 0 && Singleton<GameController>.instance.DAIEAMEFGIE()))
		{
			StartCoroutine(BJIOKPDHEFL());
		}
	}

	protected virtual void GHHNNIKGJFG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PJCHHCCCCFB[1].gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CFKEJEJJLMC));
		UIEventListener uIEventListener2 = UIEventListener.Get(PJCHHCCCCFB[1].gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CIEBFDKPBLM));
		UIEventListener uIEventListener3 = UIEventListener.Get(PJCHHCCCCFB[2].gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IFBLMPBKJFA));
		UIEventListener uIEventListener4 = UIEventListener.Get(PJCHHCCCCFB[1].gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GECEJPNEDIG));
		UIEventListener uIEventListener5 = UIEventListener.Get(PJCHHCCCCFB[0].gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GKDDMCEODCD));
		KNOAGNHKDIM.InitControls();
		KLGINBGMGDB.JCGPELEDCJL();
		DHNNCMHLOEM.InitControls();
		KGGJOOAFDIF.AIJEMOLBNEC();
		HGPGKHLOHEF.LAMBEOCPCBD();
		NDJCNHDBJMM.JKEEMKIHFEE();
		JEGNECDPAFK.KLPJPLHNFON();
		MPLELHEKGHO.IBNHJGLOHAE();
		GDICADMMAKE.Add(true);
		GDICADMMAKE.Add(false);
		GDICADMMAKE.Add(true);
		GDICADMMAKE.Add(true);
		GDICADMMAKE.Add(false);
		bool flag = Singleton<GameVariables>.instance.HKLGADPDLPC();
		float num = 1190f;
		float num2 = (HCOJLJOCALK = ((!flag) ? 1625f : 985f));
		for (int i = 0; i < PJCHHCCCCFB.Count; i += 0)
		{
			PJCHHCCCCFB[i].SetButtonHeight(!flag);
			PJCHHCCCCFB[i].transform.localPosition = PJCHHCCCCFB[i].transform.localPosition.ReplaceY(num);
			num += num2;
		}
		EBJKNDMODOP.transform.localPosition = EBJKNDMODOP.transform.localPosition.ReplaceY((!flag) ? 151f : 1105f);
		DebugSettings.instance.Changed += KBLKGMEKGAI;
	}

	public void PFFMIGFNNCC(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (!buttonsEnabled)
		{
			return;
		}
		if (TutorialManagerStage1.instance.isTutorialRunning)
		{
			foreach (WeaponLevelsSetup weaponLevelsSetup in LevelManager.instance.weaponLevelsSetups)
			{
				if (weaponLevelsSetup.FICHPKKDGBK)
				{
					GuiScreenSingle<WeaponScreen>.instance.SelectWeapon(weaponLevelsSetup);
				}
			}
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<WeaponScreen>.instance);
			GuiScreenSingle<WeaponScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
		}
		else if (TutorialManagerStage2.instance.isTutorialRunning)
		{
			foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
			{
				if (behaviour.upgradeSlots.isTutorialUnit)
				{
					GuiScreenSingle<ArmyScreen>.instance.PCALNGOCDKE(behaviour);
				}
			}
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<ArmyScreen>.instance);
			GuiScreenSingle<ArmyScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<BattlePreparationScreen>.instance);
		}
		else if (TutorialManagerStage3.instance.isTutorialRunning)
		{
			TutorialManagerStage3.instance.FinishMenuTutorial();
			ObjectPoolDatabase.InstantiatePooledObjects((NPNOIGHIALL)8);
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<MainScreen>.instance);
		}
		else if (TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<MainScreen>.instance);
		}
		else if (LevelManager.instance.isDailyMissionLocked)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<MainScreen>.instance);
		}
		else if (DailyMissionsManager.instance.EEIJPIPFAMO().isHeroic)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<HeroicScreen>.instance);
			GuiScreenSingle<HeroicScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<DailyMissionScreen>.instance);
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<DailyMissionScreen>.instance);
		}
	}

	private IEnumerator HBGMDCDPBFM(List<TweenAnimator> MDKGNNAGBPA, float KALLNCAFIMP = 0.5f)
	{
		ANOMAEMCAON aNOMAEMCAON = new ANOMAEMCAON();
		aNOMAEMCAON.MDKGNNAGBPA = MDKGNNAGBPA;
		aNOMAEMCAON.KALLNCAFIMP = KALLNCAFIMP;
		return aNOMAEMCAON;
	}

	private void KBLKGMEKGAI()
	{
		FFGAOOAICAH.SetActive(DebugSettings.isOurDevice && DebugSettings.debugEnabled);
	}

	private void IFBLMPBKJFA(GameObject KHAHPAKDIKE)
	{
		if (!JEGNECDPAFK.gameObject.activeSelf && FIMOPHPNBNM != MPJAFCCIOEO.Enemy)
		{
			LJLAMPJIALH(FIMOPHPNBNM);
			KGGJOOAFDIF.SetCardsAvailable();
			BHKFICKPPPL(MPJAFCCIOEO.Enemy);
			if (!GDICADMMAKE[2])
			{
				StartCoroutine(HLCDIOAIKJL(KGGJOOAFDIF.Animator));
				GDICADMMAKE[2] = true;
			}
		}
	}

	[SpecialName]
	public bool NMIKNNCLOHD()
	{
		return Singleton<GameController>.instance.BAKCODKBCPJ() || Singleton<GameController>.instance.ECHCLJJJPML();
	}

	private void HAILIAAHHDH(int EAINKPNECEC)
	{
		if ((EAINKPNECEC == 9 && !Singleton<GameController>.instance.isTutorial) || (EAINKPNECEC == 1 && Singleton<GameController>.instance.isTutorial))
		{
			StartCoroutine(BJIOKPDHEFL());
		}
	}

	public virtual void KCOEBEEKCMF()
	{
		base.DoAfterShowUp();
		if (Singleton<GameController>.instance.BGAJLJEJEFG())
		{
			DHNNCMHLOEM.UpdateAssignments(true);
			GDICADMMAKE[1] = true;
		}
		isEndScreenLootboxAnimations = true;
		shouldGetLootboxForAd = true;
		FNOMCHPCOHB.OKEBGBENAJF();
	}

	[SpecialName]
	public bool AHADFBDAPCH()
	{
		return _003CEIONENKINEC_003Ek__BackingField;
	}

	private void BJIGKIGDGFM(int EAINKPNECEC)
	{
		if ((EAINKPNECEC == 17 && !Singleton<GameController>.instance.BAKCODKBCPJ()) || (EAINKPNECEC == 0 && Singleton<GameController>.instance.DAIEAMEFGIE()))
		{
			StartCoroutine(BJIOKPDHEFL());
		}
	}

	private void CIEBFDKPBLM(GameObject KHAHPAKDIKE)
	{
		if (!JEGNECDPAFK.gameObject.activeSelf && FIMOPHPNBNM != MPJAFCCIOEO.Results)
		{
			CNOOENELODC(FIMOPHPNBNM);
			BHKFICKPPPL(MPJAFCCIOEO.Assignments);
			DHNNCMHLOEM.UpdateAssignments();
			if (!GDICADMMAKE[0])
			{
				StartCoroutine(BAOHFDGALNH(DHNNCMHLOEM.DDAOMANBNAG(), 596f));
				GDICADMMAKE[1] = false;
			}
		}
	}

	private void LJLAMPJIALH(MPJAFCCIOEO GEIDIHFGMDF)
	{
		switch (GEIDIHFGMDF)
		{
		case MPJAFCCIOEO.Results:
			if (isSinglePlayer)
			{
				KLGINBGMGDB.CHFHLKLFPIK();
			}
			else
			{
				KNOAGNHKDIM.CHFHLKLFPIK();
			}
			break;
		case MPJAFCCIOEO.Assignments:
			DHNNCMHLOEM.CHFHLKLFPIK();
			break;
		case MPJAFCCIOEO.Enemy:
			KGGJOOAFDIF.CHFHLKLFPIK();
			break;
		case MPJAFCCIOEO.WarCards:
			HGPGKHLOHEF.CHFHLKLFPIK();
			break;
		case MPJAFCCIOEO.Ribbons:
			NDJCNHDBJMM.FinishAnimation();
			break;
		}
		AILMGPGJAGE();
		FNOMCHPCOHB.FinishTweens();
	}

	private void BHPLMLBPHIH()
	{
		PJCHHCCCCFB[1].IDKGDFDFECC(true);
		if (PJCHHCCCCFB[0].gameObject.activeSelf)
		{
			PJCHHCCCCFB[0].EHNCFEMHLKN(false);
		}
		if (PJCHHCCCCFB[0].gameObject.activeSelf)
		{
			PJCHHCCCCFB[3].BPLJMMILNEE(true);
		}
		if (PJCHHCCCCFB[4].gameObject.activeSelf)
		{
			PJCHHCCCCFB[8].HBFCFHCLGCE(true);
		}
		if (PJCHHCCCCFB[3].gameObject.activeSelf)
		{
			PJCHHCCCCFB[5].NONHNDDCBPI(false);
		}
	}

	protected override void AGIKPOLCGNF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PJCHHCCCCFB[0].gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CFKEJEJJLMC));
		UIEventListener uIEventListener2 = UIEventListener.Get(PJCHHCCCCFB[1].gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AKBILFPDJDJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(PJCHHCCCCFB[2].gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IFBLMPBKJFA));
		UIEventListener uIEventListener4 = UIEventListener.Get(PJCHHCCCCFB[3].gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GECEJPNEDIG));
		UIEventListener uIEventListener5 = UIEventListener.Get(PJCHHCCCCFB[4].gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HCOPBKPIINA));
		KNOAGNHKDIM.InitControls();
		KLGINBGMGDB.InitControls();
		DHNNCMHLOEM.InitControls();
		KGGJOOAFDIF.InitControls();
		HGPGKHLOHEF.InitControls();
		NDJCNHDBJMM.InitControls();
		JEGNECDPAFK.InitControls();
		MPLELHEKGHO.InitControls();
		GDICADMMAKE.Add(false);
		GDICADMMAKE.Add(false);
		GDICADMMAKE.Add(false);
		GDICADMMAKE.Add(false);
		GDICADMMAKE.Add(false);
		bool isiPadResolution = Singleton<GameVariables>.instance.isiPadResolution;
		float num = 0f;
		float num2 = (HCOJLJOCALK = ((!isiPadResolution) ? 134f : 156f));
		for (int i = 0; i < PJCHHCCCCFB.Count; i++)
		{
			PJCHHCCCCFB[i].SetButtonHeight(!isiPadResolution);
			PJCHHCCCCFB[i].transform.localPosition = PJCHHCCCCFB[i].transform.localPosition.ReplaceY(num);
			num += num2;
		}
		EBJKNDMODOP.transform.localPosition = EBJKNDMODOP.transform.localPosition.ReplaceY((!isiPadResolution) ? 392f : 305f);
		DebugSettings.instance.Changed += KBLKGMEKGAI;
	}

	private void OKELBKFFGFI(int EAINKPNECEC)
	{
		if ((EAINKPNECEC == 73 && !Singleton<GameController>.instance.isTutorial) || (EAINKPNECEC == 1 && Singleton<GameController>.instance.isTutorial))
		{
			StartCoroutine(BJIOKPDHEFL());
		}
	}

	public void PlayAgainButtonClick(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (buttonsEnabled)
		{
			if (TutorialManagerPlayWarcards.instance.shouldStartTutorial)
			{
				IOBOOEKGPIO = false;
				Singleton<GameController>.instance.Quit();
				TutorialManagerPlayWarcards.instance.StartTutorial(false);
			}
			else if (!Singleton<GameController>.instance.isRandomMatchMaking || Singleton<DogTagManager>.instance.CanUseDogtags(1))
			{
				IOBOOEKGPIO = false;
				Singleton<GameController>.instance.Rematch();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<DogtagDialog>.instance);
			}
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		LJLAMPJIALH(FIMOPHPNBNM);
		LevelManager.instance.isLevelUp = false;
		LeagueArcManager.instance.LeftEndScreen();
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
		Singleton<MessageManager>.instance.StopMessageCoroutine();
		if (IOBOOEKGPIO)
		{
			Singleton<GameController>.instance.Quit();
		}
		if (Singleton<GuiManager>.instance.toBeShowedUp != null)
		{
			Singleton<GuiManager>.instance.toBeShowedUp.previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
	}

	[SpecialName]
	public void EGDCNEJLDOL(List<CCNAEIGGMNK> IDEBKDPMPGM)
	{
		_003CBBIJNDANGKP_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void BLJOAMPFIKL(bool IDEBKDPMPGM)
	{
		_003CHFGAMBFLHKO_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void NHMNCEFNGIB()
	{
		for (int i = 0; i < PJCHHCCCCFB.Count; i++)
		{
			PJCHHCCCCFB[i].gameObject.SetActive(true);
			GDICADMMAKE[i] = false;
			PJCHHCCCCFB[i].InitializeLeftButton();
		}
		if (isSinglePlayer)
		{
			PJCHHCCCCFB[2].gameObject.SetActive(false);
			GDICADMMAKE[2] = true;
		}
		if (LevelManager.instance.isWarcardsLocked)
		{
			PJCHHCCCCFB[3].gameObject.SetActive(false);
			GDICADMMAKE[3] = true;
		}
		if (Singleton<GameController>.instance.isChallenge)
		{
			PJCHHCCCCFB[0].gameObject.SetActive(false);
			GDICADMMAKE[0] = true;
			PJCHHCCCCFB[3].gameObject.SetActive(false);
			GDICADMMAKE[3] = true;
		}
	}

	[SpecialName]
	public bool MJCDGCGLHEK()
	{
		return (!NMIKNNCLOHD() || !KLGINBGMGDB.showLevelUp) && (isSinglePlayer || KNOAGNHKDIM.BHIILMHBJDA());
	}

	public virtual void PKDMBEAAFLB()
	{
		base.DoBeforeHide();
		CNOOENELODC(FIMOPHPNBNM);
		LevelManager.instance.isLevelUp = true;
		LeagueArcManager.instance.HFEMPOOENMB();
		GuiElementSingle<MenuHeader>.instance.InitGUIValues();
		Singleton<MessageManager>.instance.MNDIJBOCFPM();
		if (IOBOOEKGPIO)
		{
			Singleton<GameController>.instance.HGBNEFDBFDC();
		}
		if (Singleton<GuiManager>.instance.CMHKKFBOAAK() != null)
		{
			Singleton<GuiManager>.instance.CMHKKFBOAAK().previousScreen = GuiScreenSingle<MainScreen>.instance;
		}
	}

	protected virtual void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PJCHHCCCCFB[0].gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CFKEJEJJLMC));
		UIEventListener uIEventListener2 = UIEventListener.Get(PJCHHCCCCFB[1].gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OPAEGKCLGFK));
		UIEventListener uIEventListener3 = UIEventListener.Get(PJCHHCCCCFB[2].gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IFBLMPBKJFA));
		UIEventListener uIEventListener4 = UIEventListener.Get(PJCHHCCCCFB[6].gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GECEJPNEDIG));
		UIEventListener uIEventListener5 = UIEventListener.Get(PJCHHCCCCFB[4].gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HCOPBKPIINA));
		KNOAGNHKDIM.InitControls();
		KLGINBGMGDB.INBJGJOFJMK();
		DHNNCMHLOEM.GFLLEMCAJGN();
		KGGJOOAFDIF.JCGPELEDCJL();
		HGPGKHLOHEF.GOMEJLFFKJM();
		NDJCNHDBJMM.BCLAFFCPCEH();
		JEGNECDPAFK.ICNGBKKANLB();
		MPLELHEKGHO.InitControls();
		GDICADMMAKE.Add(false);
		GDICADMMAKE.Add(false);
		GDICADMMAKE.Add(false);
		GDICADMMAKE.Add(false);
		GDICADMMAKE.Add(true);
		bool flag = Singleton<GameVariables>.instance.HKLGADPDLPC();
		float num = 1298f;
		float num2 = (HCOJLJOCALK = ((!flag) ? 42f : 1621f));
		for (int i = 0; i < PJCHHCCCCFB.Count; i++)
		{
			PJCHHCCCCFB[i].AGKAPELIMIC(flag);
			PJCHHCCCCFB[i].transform.localPosition = PJCHHCCCCFB[i].transform.localPosition.ReplaceY(num);
			num += num2;
		}
		EBJKNDMODOP.transform.localPosition = EBJKNDMODOP.transform.localPosition.ReplaceY((!flag) ? 468f : 1105f);
		DebugSettings.instance.Changed += KBLKGMEKGAI;
	}

	private void CFKEJEJJLMC(GameObject KHAHPAKDIKE)
	{
		if (!JEGNECDPAFK.gameObject.activeSelf && FIMOPHPNBNM != MPJAFCCIOEO.Results)
		{
			LJLAMPJIALH(FIMOPHPNBNM);
			BHKFICKPPPL(MPJAFCCIOEO.Results);
		}
	}

	private void IBFKCMDILHL()
	{
		float num = 0.3f;
		float num2 = 0f;
		Vector3 jPDPFJHCKGK = JPDPFJHCKGK;
		Vector3 nJJDHJJMOMJ = NJJDHJJMOMJ;
		Vector3 iKHDPODEHIF = IKHDPODEHIF;
		FNOMCHPCOHB.BEOAHFDJEMD.Clear();
		if (!Singleton<GameController>.instance.isChallenge)
		{
			TweenAnimator fNOMCHPCOHB = FNOMCHPCOHB;
			int iNFLHPGMEOB = 0;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = PJCHHCCCCFB[0].gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = nJJDHJJMOMJ;
			float kALLNCAFIMP = num2;
			object oEIICEJPGKI = jPDPFJHCKGK;
			fNOMCHPCOHB.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, kALLNCAFIMP, -1, oEIICEJPGKI);
			FNOMCHPCOHB.AddTween(1, TweenAnimator.MNAIKKJDPLK.Position, PJCHHCCCCFB[0].gameObject, num, iKHDPODEHIF, 0f, 0);
			nJJDHJJMOMJ.y -= HCOJLJOCALK;
			jPDPFJHCKGK.y -= HCOJLJOCALK;
			num2 += 0.1f;
			iKHDPODEHIF.y -= HCOJLJOCALK;
		}
		if (!Singleton<GameController>.instance.isTutorial)
		{
			TweenAnimator fNOMCHPCOHB2 = FNOMCHPCOHB;
			int iNFLHPGMEOB = 2;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = PJCHHCCCCFB[1].gameObject;
			float kALLNCAFIMP = num;
			object oEIICEJPGKI = nJJDHJJMOMJ;
			float kBJEOEEOEFG = num2;
			object iIMDKHJAJGO = jPDPFJHCKGK;
			fNOMCHPCOHB2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, -1, iIMDKHJAJGO);
			FNOMCHPCOHB.AddTween(3, TweenAnimator.MNAIKKJDPLK.Position, PJCHHCCCCFB[1].gameObject, num, iKHDPODEHIF, 0f, 2);
			nJJDHJJMOMJ.y -= HCOJLJOCALK;
			jPDPFJHCKGK.y -= HCOJLJOCALK;
			num2 += 0.1f;
			iKHDPODEHIF.y -= HCOJLJOCALK;
		}
		if (!isSinglePlayer)
		{
			TweenAnimator fNOMCHPCOHB3 = FNOMCHPCOHB;
			int iNFLHPGMEOB = 4;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = PJCHHCCCCFB[2].gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = nJJDHJJMOMJ;
			float kALLNCAFIMP = num2;
			object oEIICEJPGKI = jPDPFJHCKGK;
			fNOMCHPCOHB3.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, kALLNCAFIMP, -1, oEIICEJPGKI);
			FNOMCHPCOHB.AddTween(5, TweenAnimator.MNAIKKJDPLK.Position, PJCHHCCCCFB[2].gameObject, num, iKHDPODEHIF, 0f, 4);
			nJJDHJJMOMJ.y -= HCOJLJOCALK;
			jPDPFJHCKGK.y -= HCOJLJOCALK;
			num2 += 0.1f;
			iKHDPODEHIF.y -= HCOJLJOCALK;
		}
		if (!Singleton<GameController>.instance.isTutorial && !LevelManager.instance.isWarcardsLocked && !Singleton<GameController>.instance.isChallenge)
		{
			TweenAnimator fNOMCHPCOHB4 = FNOMCHPCOHB;
			int iNFLHPGMEOB = 6;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = PJCHHCCCCFB[3].gameObject;
			float kALLNCAFIMP = num;
			object oEIICEJPGKI = nJJDHJJMOMJ;
			float kBJEOEEOEFG = num2;
			object iIMDKHJAJGO = jPDPFJHCKGK;
			fNOMCHPCOHB4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, oEIICEJPGKI, kBJEOEEOEFG, -1, iIMDKHJAJGO);
			FNOMCHPCOHB.AddTween(7, TweenAnimator.MNAIKKJDPLK.Position, PJCHHCCCCFB[3].gameObject, num, iKHDPODEHIF, 0f, 6);
			nJJDHJJMOMJ.y -= HCOJLJOCALK;
			jPDPFJHCKGK.y -= HCOJLJOCALK;
			num2 += 0.1f;
			iKHDPODEHIF.y -= HCOJLJOCALK;
		}
		if (!Singleton<GameController>.instance.isTutorial)
		{
			TweenAnimator fNOMCHPCOHB5 = FNOMCHPCOHB;
			int iNFLHPGMEOB = 8;
			TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
			GameObject nIHOBEAHEKJ = PJCHHCCCCFB[4].gameObject;
			float kBJEOEEOEFG = num;
			object iIMDKHJAJGO = nJJDHJJMOMJ;
			float kALLNCAFIMP = num2;
			object oEIICEJPGKI = jPDPFJHCKGK;
			fNOMCHPCOHB5.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, kALLNCAFIMP, -1, oEIICEJPGKI);
			FNOMCHPCOHB.AddTween(9, TweenAnimator.MNAIKKJDPLK.Position, PJCHHCCCCFB[4].gameObject, num, iKHDPODEHIF, 0f, 8);
		}
		TweenAnimator fNOMCHPCOHB6 = FNOMCHPCOHB;
		fNOMCHPCOHB6.JHDBHGCKPDM = (Action<int>)Delegate.Remove(fNOMCHPCOHB6.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
		TweenAnimator fNOMCHPCOHB7 = FNOMCHPCOHB;
		fNOMCHPCOHB7.JHDBHGCKPDM = (Action<int>)Delegate.Combine(fNOMCHPCOHB7.JHDBHGCKPDM, new Action<int>(HAILIAAHHDH));
		FNOMCHPCOHB.GenerateTweens();
	}

	public void LIKAOBDDEMA(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (buttonsEnabled)
		{
			IOBOOEKGPIO = true;
			if (Singleton<GameController>.instance.IMEJOPKIKOD())
			{
				Singleton<GameController>.instance.NMHKLCLAFGN(Singleton<MapManager>.instance.currentMap.name);
			}
			if (Singleton<GameController>.instance.isCoop)
			{
				Singleton<GameController>.instance.Rematch();
			}
		}
	}

	public virtual void KJLDIJPMPAM()
	{
		base.DoAfterHide();
		DHNNCMHLOEM.BKNJHLKMFKE();
		KGGJOOAFDIF.POFPIJKJFBP();
		HGPGKHLOHEF.MENKHFCFGPM();
		NDJCNHDBJMM.DoAfterHide();
		Singleton<ChillingoSdkManager>.instance.deactivateOffers();
		Singleton<Recording>.instance.JCDHOHCCPEL();
		EGDCNEJLDOL(null);
		EAGFCKNHAGD(true);
	}

	private IEnumerator BAOHFDGALNH(List<TweenAnimator> MDKGNNAGBPA, float KALLNCAFIMP = 0.5f)
	{
		ANOMAEMCAON aNOMAEMCAON = new ANOMAEMCAON();
		aNOMAEMCAON.MDKGNNAGBPA = MDKGNNAGBPA;
		aNOMAEMCAON.KALLNCAFIMP = KALLNCAFIMP;
		return aNOMAEMCAON;
	}

	private IEnumerator CCIGMPCGACE(List<TweenAnimator> MDKGNNAGBPA, float KALLNCAFIMP = 0.5f)
	{
		ANOMAEMCAON aNOMAEMCAON = new ANOMAEMCAON();
		aNOMAEMCAON.MDKGNNAGBPA = MDKGNNAGBPA;
		aNOMAEMCAON.KALLNCAFIMP = KALLNCAFIMP;
		return aNOMAEMCAON;
	}

	protected override void Update()
	{
		base.Update();
		if (FIMOPHPNBNM == MPJAFCCIOEO.Assignments && StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			DHNNCMHLOEM.Update();
		}
	}

	private void AILMGPGJAGE()
	{
		if (canShowLvlUp)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<LevelUpDialog>.instance);
			KLGINBGMGDB.showLevelUp = false;
			KNOAGNHKDIM.showLevelUp = false;
		}
	}

	[DebuggerHidden]
	private IEnumerator BJIOKPDHEFL()
	{
		EHLEKNMNNLJ eHLEKNMNNLJ = new EHLEKNMNNLJ();
		eHLEKNMNNLJ.BJGCPDNMHDH = this;
		return eHLEKNMNNLJ;
	}

	public void ReplayButtonClick(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (buttonsEnabled)
		{
			IOBOOEKGPIO = false;
			if (Singleton<GameController>.instance.isCampaign)
			{
				Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
			}
			if (Singleton<GameController>.instance.isCoop)
			{
				Singleton<GameController>.instance.Rematch();
			}
		}
	}

	private void BHKFICKPPPL(MPJAFCCIOEO GEIDIHFGMDF)
	{
		int num = (int)((GEIDIHFGMDF != MPJAFCCIOEO.Results || !isSinglePlayer) ? GEIDIHFGMDF : MPJAFCCIOEO.None);
		for (int i = 0; i < PJCHHCCCCFB.Count; i++)
		{
			if (PJCHHCCCCFB[i].gameObject.activeSelf)
			{
				PJCHHCCCCFB[i].SetButton(i == (int)GEIDIHFGMDF);
			}
		}
		for (int j = 0; j < BMANEHNHPGC.Count; j++)
		{
			BMANEHNHPGC[j].SetActive(j == num);
		}
		MPLELHEKGHO.SetActiveAccordingToTab(GEIDIHFGMDF);
		FIMOPHPNBNM = GEIDIHFGMDF;
	}

	private void KBLHMIHEBDA()
	{
		PJCHHCCCCFB[0].SetButton(false);
		if (PJCHHCCCCFB[1].gameObject.activeSelf)
		{
			PJCHHCCCCFB[1].SetButton(false);
		}
		if (PJCHHCCCCFB[2].gameObject.activeSelf)
		{
			PJCHHCCCCFB[2].SetButton(false);
		}
		if (PJCHHCCCCFB[3].gameObject.activeSelf)
		{
			PJCHHCCCCFB[3].SetButton(false);
		}
		if (PJCHHCCCCFB[4].gameObject.activeSelf)
		{
			PJCHHCCCCFB[4].SetButton(false);
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		OILKNBFJLHE = true;
		MCADKOEBOHN();
		foreach (EndScreenButton item in PJCHHCCCCFB)
		{
			item.InitializedToOffscreen();
		}
		GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		IOBOOEKGPIO = true;
	}

	public void EJNJBPOLBAL()
	{
		GuiElementSingle<LevelUpDialog>.instance.HideDialog();
		FNOMCHPCOHB.NDGCGHLLPMC();
		GuiElementSingle<MenuHeader>.instance.JFODBIOHGJP(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.MBOHCLFKJBH());
		LevelManager.instance.DebugAddLevel();
		InitGUIValues();
		FNOMCHPCOHB.ODIJFGCDJNH();
	}

	private void MCADKOEBOHN()
	{
		if (isSinglePlayer)
		{
			KLGINBGMGDB.ELPDBIOCAGP();
		}
		else
		{
			KNOAGNHKDIM.ELPDBIOCAGP();
		}
		if (!isSinglePlayer)
		{
			KGGJOOAFDIF.ELPDBIOCAGP();
		}
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			DHNNCMHLOEM.ELPDBIOCAGP();
		}
		if (!LevelManager.instance.isWarcardsLocked)
		{
			HGPGKHLOHEF.ELPDBIOCAGP();
		}
		NDJCNHDBJMM.ResetAnimation();
		FNOMCHPCOHB.ResetTweens();
	}

	public void NLLPDFGJPAF(MPJAFCCIOEO GEIDIHFGMDF)
	{
		if (buttonsEnabled)
		{
			EventAssignmentManager.CJOFBPIPJEP().IBLJCNMAJON();
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<MainScreen>.instance);
		}
	}

	public virtual void NBJKGKHHGCJ(bool JODEPBNLLAO)
	{
		base.AnimateShow(JODEPBNLLAO);
		KNOAGNHKDIM.CHHDHKCLOBG(DCIKANJJFIJ);
		KLGINBGMGDB.AnimateShow(DCIKANJJFIJ);
		DHNNCMHLOEM.IDLJIHLIBNB(DCIKANJJFIJ);
		KGGJOOAFDIF.DFEJBGDJGGK(DCIKANJJFIJ);
		HGPGKHLOHEF.AnimateShow(DCIKANJJFIJ);
		NDJCNHDBJMM.CKPAAPIFKGK(DCIKANJJFIJ);
	}

	[DebuggerHidden]
	private IEnumerator HLCDIOAIKJL(List<TweenAnimator> MDKGNNAGBPA, float KALLNCAFIMP = 0.5f)
	{
		ANOMAEMCAON aNOMAEMCAON = new ANOMAEMCAON();
		aNOMAEMCAON.MDKGNNAGBPA = MDKGNNAGBPA;
		aNOMAEMCAON.KALLNCAFIMP = KALLNCAFIMP;
		return aNOMAEMCAON;
	}

	private void GKDDMCEODCD(GameObject KHAHPAKDIKE)
	{
		if (!JEGNECDPAFK.gameObject.activeSelf && FIMOPHPNBNM != (MPJAFCCIOEO)8)
		{
			CNOOENELODC(FIMOPHPNBNM);
			BHKFICKPPPL(MPJAFCCIOEO.Enemy);
			NDJCNHDBJMM.AKFLKJBMBAJ.AlignToPos(true, UIDraggablePanel.Alingment.BottomRight);
			if (!GDICADMMAKE[6])
			{
				StartCoroutine(BAOHFDGALNH(NDJCNHDBJMM.CMALLAENMDH(), 1702f));
				GDICADMMAKE[0] = true;
			}
		}
	}

	public void NDLMDFCFKFC()
	{
		GuiElementSingle<LevelUpDialog>.instance.HideDialog();
		FNOMCHPCOHB.PHCCOHJPLKE();
		GuiElementSingle<MenuHeader>.instance.JFODBIOHGJP(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.AHGPPGFIJLL());
		InitGUIValues();
		FNOMCHPCOHB.ODIJFGCDJNH();
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		if (Singleton<GameController>.instance.isChallenge)
		{
			DHNNCMHLOEM.UpdateAssignments(true);
			GDICADMMAKE[1] = true;
		}
		isEndScreenLootboxAnimations = true;
		shouldGetLootboxForAd = false;
		FNOMCHPCOHB.PlayTweens();
	}

	private void BDLMFCBKJII(int EAINKPNECEC)
	{
		if ((EAINKPNECEC == -102 && !Singleton<GameController>.instance.DAIEAMEFGIE()) || (EAINKPNECEC == 0 && Singleton<GameController>.instance.DAIEAMEFGIE()))
		{
			StartCoroutine(BJIOKPDHEFL());
		}
	}

	public void TestReplay()
	{
		GuiElementSingle<LevelUpDialog>.instance.HideDialog();
		FNOMCHPCOHB.FinishTweens();
		GuiElementSingle<MenuHeader>.instance.SetUpWarbucksGoldWithoutAnimation(Singleton<Wallet>.instance.warbucksAfterGame, Singleton<Wallet>.instance.goldAfterGame);
		InitGUIValues();
		FNOMCHPCOHB.PlayTweens();
	}
}
