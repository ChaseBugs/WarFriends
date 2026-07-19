using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AchievementsManager : Singleton<AchievementsManager>
{
	public sealed class CHIDHGCKCIK
	{
		private Achievements.rowIds FNFMGDOECDA;

		private AchievementsRow OJDHGFADFDF;

		public Achievements.rowIds FJMCPEDNBGG
		{
			get
			{
				return FNFMGDOECDA;
			}
		}

		public string INFLHPGMEOB
		{
			get
			{
				return (!BundleVersionBindings.BundleID.Contains("about")) ? OJDHGFADFDF.ANDROIDIDCHILL : OJDHGFADFDF.ANDROIDID;
			}
		}

		public string CABMKLIDMEH
		{
			get
			{
				return OJDHGFADFDF.CLASS;
			}
		}

		public int JAJGLLMBPNB
		{
			get
			{
				return OJDHGFADFDF.VALUE;
			}
		}

		public int FKIGMDIHKAA
		{
			get
			{
				return OJDHGFADFDF.REWARDGOLD;
			}
		}

		public int BJFGHKNAIIE
		{
			get
			{
				return OJDHGFADFDF.REWARDWB;
			}
		}

		public int KMCEFANOLKM
		{
			get
			{
				return OJDHGFADFDF.REWARDSCRAPS;
			}
		}

		public int ELCDCFHKGHC
		{
			get
			{
				return OJDHGFADFDF.REWARDTICKETS;
			}
		}

		public int KHKKGLMKBLP
		{
			get
			{
				return OJDHGFADFDF.GROUPID;
			}
		}

		public string MHEHLJGIEKD
		{
			get
			{
				return OJDHGFADFDF.GUITITLE;
			}
		}

		public string JOJLPMLBOMO
		{
			get
			{
				return OJDHGFADFDF.GUIDESCRIPTION;
			}
		}

		public int OJHENOBMDDF
		{
			get
			{
				return FKIGMDIHKAA + BJFGHKNAIIE + KMCEFANOLKM + ELCDCFHKGHC;
			}
		}

		[SpecialName]
		public int NLPIEDDJDIH()
		{
			return OJDHGFADFDF.GROUPID;
		}

		[SpecialName]
		public string FLICOCCLMCK()
		{
			return OJDHGFADFDF.GUITITLE;
		}

		[SpecialName]
		public string KLGFCEPCOKE()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		public CHIDHGCKCIK(Achievements.rowIds FJMCPEDNBGG, AchievementsRow KAJEAOMGGBD)
		{
			FNFMGDOECDA = FJMCPEDNBGG;
			OJDHGFADFDF = KAJEAOMGGBD;
		}

		[SpecialName]
		public int DLPPOIBMLNI()
		{
			return CHMDEEBCOJC() + FPPKLECGAGJ() + ACLKCOGMDKE() + DFHFKLPOGDO();
		}

		[SpecialName]
		public int PCBAGOMNAJI()
		{
			return OJDHGFADFDF.GROUPID;
		}

		[SpecialName]
		public int NPGIBLIHBIF()
		{
			return CHMDEEBCOJC() + FPPKLECGAGJ() + ACLKCOGMDKE() + ELCDCFHKGHC;
		}

		[SpecialName]
		public string IIANAFDBPJN()
		{
			return OJDHGFADFDF.CLASS;
		}

		[SpecialName]
		public int GMHDPNPFBFK()
		{
			return KNJCPLJJPGI() + FPGEADHFEFO() + GFBCBAHBDHI() + HCHKDKDBHGN();
		}

		[SpecialName]
		public int LOGOCALPNHD()
		{
			return OJDHGFADFDF.GROUPID;
		}

		[SpecialName]
		public int FGENMPMGIPC()
		{
			return KNJCPLJJPGI() + PCINEOIIKNO() + JHOODHKDBPM() + HCHKDKDBHGN();
		}

		[SpecialName]
		public int HCHKDKDBHGN()
		{
			return OJDHGFADFDF.REWARDTICKETS;
		}

		[SpecialName]
		public string NMNCJBAIEFM()
		{
			return OJDHGFADFDF.CLASS;
		}

		[SpecialName]
		public string CLCICMNKBDF()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		[SpecialName]
		public string PENODACFKHM()
		{
			return OJDHGFADFDF.CLASS;
		}

		[SpecialName]
		public int DFHFKLPOGDO()
		{
			return OJDHGFADFDF.REWARDTICKETS;
		}

		[SpecialName]
		public string GHPBOPKNJOD()
		{
			return OJDHGFADFDF.GUITITLE;
		}

		[SpecialName]
		public int KNJCPLJJPGI()
		{
			return OJDHGFADFDF.REWARDGOLD;
		}

		[SpecialName]
		public int FPGEADHFEFO()
		{
			return OJDHGFADFDF.REWARDWB;
		}

		[SpecialName]
		public string BGLJHLHKGMD()
		{
			return OJDHGFADFDF.CLASS;
		}

		[SpecialName]
		public string JCBKIENBHOC()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		[SpecialName]
		public int KNEBNHMMONO()
		{
			return OJDHGFADFDF.GROUPID;
		}

		[SpecialName]
		public string FOLKGLODNMN()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		[SpecialName]
		public int PCINEOIIKNO()
		{
			return OJDHGFADFDF.REWARDWB;
		}

		[SpecialName]
		public string EHACCIIKEFN()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		[SpecialName]
		public string FKKLLCEJJID()
		{
			return OJDHGFADFDF.CLASS;
		}

		[SpecialName]
		public Achievements.rowIds MBKOGLEFIDJ()
		{
			return FNFMGDOECDA;
		}

		[SpecialName]
		public int OBFEOHFNBHA()
		{
			return OJDHGFADFDF.VALUE;
		}

		[SpecialName]
		public string CBMDPJDBFJG()
		{
			return OJDHGFADFDF.CLASS;
		}

		[SpecialName]
		public int MADMPDNMEFJ()
		{
			return OJDHGFADFDF.REWARDSCRAPS;
		}

		[SpecialName]
		public int MDMMOOJPIPG()
		{
			return OJDHGFADFDF.REWARDWB;
		}

		[SpecialName]
		public string LNILGHDDLDN()
		{
			return OJDHGFADFDF.CLASS;
		}

		[SpecialName]
		public string BGGBEDDLFNO()
		{
			return OJDHGFADFDF.GUITITLE;
		}

		[SpecialName]
		public int FPPKLECGAGJ()
		{
			return OJDHGFADFDF.REWARDWB;
		}

		[SpecialName]
		public string CGGEEIFPBHN()
		{
			return OJDHGFADFDF.GUITITLE;
		}

		[SpecialName]
		public int DIIBGFLGKOK()
		{
			return OJDHGFADFDF.GROUPID;
		}

		[SpecialName]
		public string APAJPPDHDMB()
		{
			return OJDHGFADFDF.GUITITLE;
		}

		[SpecialName]
		public int CLLJLNMHDFG()
		{
			return OJDHGFADFDF.VALUE;
		}

		[SpecialName]
		public int JHJFNGOPKFO()
		{
			return OJDHGFADFDF.GROUPID;
		}

		[SpecialName]
		public int HEBHILNFEBN()
		{
			return CHMDEEBCOJC() + BOFKJPAMHDB() + MADMPDNMEFJ() + ELCDCFHKGHC;
		}

		[SpecialName]
		public string MJKKKOINEFD()
		{
			return (!BundleVersionBindings.BundleID.Contains("ID_RENTAL_MINIGUN")) ? OJDHGFADFDF.ANDROIDIDCHILL : OJDHGFADFDF.ANDROIDID;
		}

		[SpecialName]
		public int AEJDKACMHMK()
		{
			return OJDHGFADFDF.REWARDTICKETS;
		}

		[SpecialName]
		public int CHMDEEBCOJC()
		{
			return OJDHGFADFDF.REWARDGOLD;
		}

		[SpecialName]
		public string IAPFPFBGFNK()
		{
			return OJDHGFADFDF.GUITITLE;
		}

		[SpecialName]
		public string IPAAMEOICMO()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		[SpecialName]
		public string CKOKHAPGELP()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		[SpecialName]
		public string FPGAGEGMNDL()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		[SpecialName]
		public int CDONOPHJFFH()
		{
			return OJDHGFADFDF.VALUE;
		}

		[SpecialName]
		public string BEACPPHMAFK()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		[SpecialName]
		public int NLPNNLOJBLP()
		{
			return OJDHGFADFDF.REWARDWB;
		}

		[SpecialName]
		public int AGCNFMKHEGN()
		{
			return OJDHGFADFDF.GROUPID;
		}

		[SpecialName]
		public string FHINEGCMMFP()
		{
			return OJDHGFADFDF.CLASS;
		}

		[SpecialName]
		public int EKBFHDEHGDK()
		{
			return OJDHGFADFDF.REWARDTICKETS;
		}

		[SpecialName]
		public string PMNHBIJOAPJ()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		[SpecialName]
		public int ODPHJJKGHLM()
		{
			return KNJCPLJJPGI() + MDMMOOJPIPG() + KMCEFANOLKM + DFHFKLPOGDO();
		}

		[SpecialName]
		public int CCFLCLCLBHG()
		{
			return OJDHGFADFDF.VALUE;
		}

		[SpecialName]
		public int KIGMMBNPLGF()
		{
			return OJDHGFADFDF.REWARDWB;
		}

		[SpecialName]
		public int PCNIMOPMPDO()
		{
			return OJDHGFADFDF.VALUE;
		}

		[SpecialName]
		public string HDEJFCFJEBF()
		{
			return OJDHGFADFDF.GUIDESCRIPTION;
		}

		[SpecialName]
		public int GFBCBAHBDHI()
		{
			return OJDHGFADFDF.REWARDSCRAPS;
		}

		[SpecialName]
		public int HOMLFDHHANI()
		{
			return OJDHGFADFDF.REWARDWB;
		}

		[SpecialName]
		public int CJPJPAFDBJF()
		{
			return OJDHGFADFDF.GROUPID;
		}

		[SpecialName]
		public int JHOODHKDBPM()
		{
			return OJDHGFADFDF.REWARDSCRAPS;
		}

		[SpecialName]
		public int BOFKJPAMHDB()
		{
			return OJDHGFADFDF.REWARDWB;
		}

		[SpecialName]
		public int CHDLJAFIEGG()
		{
			return FKIGMDIHKAA + BOFKJPAMHDB() + GFBCBAHBDHI() + EKBFHDEHGDK();
		}

		[SpecialName]
		public int DNFFDIDEBNB()
		{
			return OJDHGFADFDF.VALUE;
		}

		[SpecialName]
		public string JFHKFDLJKPJ()
		{
			return OJDHGFADFDF.GUITITLE;
		}

		[SpecialName]
		public int ACLKCOGMDKE()
		{
			return OJDHGFADFDF.REWARDSCRAPS;
		}
	}

	private readonly Queue<Type> NCIIEJPIJHO = new Queue<Type>(10);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action HBCILIHIHIP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action DJHKIBKOBJE;

	private Achievements NEGKDEDIFLL;

	private Dictionary<int, List<CHIDHGCKCIK>> MFPOLAAKDMH;

	private List<Type> PGMKIEGEKHC;

	public AchievementProgressGroups OOLANIBDBAE;

	public Dictionary<int, List<CHIDHGCKCIK>> achievements
	{
		get
		{
			return MFPOLAAKDMH;
		}
	}

	public ReadOnlyCollection<Type> achievementTypes
	{
		get
		{
			return PGMKIEGEKHC.AsReadOnly();
		}
	}

	public event Action AchievementsEvaluated
	{
		add
		{
			Action action = HBCILIHIHIP;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HBCILIHIHIP, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = HBCILIHIHIP;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HBCILIHIHIP, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action AchievementClaimed
	{
		add
		{
			Action action = DJHKIBKOBJE;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DJHKIBKOBJE, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = DJHKIBKOBJE;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref DJHKIBKOBJE, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	protected virtual void NOGLOKJINKN()
	{
		base.Awake();
		NEGKDEDIFLL = GetComponent<Achievements>();
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(PHGFBJFFFPH);
		BPDIENJJIMH();
	}

	public void KBOGHOGAKJL()
	{
		if (DJHKIBKOBJE != null)
		{
			DJHKIBKOBJE();
		}
	}

	private void DJIOPLGEPKL()
	{
		if (GameLoginManager.currentPlayer.isGooglePlayConnected && Singleton<GooglePlayGameService>.instance.isLoggedIn)
		{
			Social.Active.LoadAchievements(NPMLOLKMCMD);
		}
		BPDIENJJIMH();
		OOLANIBDBAE.EnsureInitialized();
		while (NCIIEJPIJHO.Count > 1)
		{
			EDLMLLNIDBE(NCIIEJPIJHO.Dequeue());
		}
		NDONIJFFNNF();
	}

	private void KPCDGBHCOIK()
	{
		if (GameLoginManager.currentPlayer.isGooglePlayConnected && Singleton<GooglePlayGameService>.instance.JFBEEDPMNBO())
		{
			Social.Active.LoadAchievements(LEOCBGLDJBJ);
		}
		EnsureInitialized();
		OOLANIBDBAE.EnsureInitialized();
		while (NCIIEJPIJHO.Count > 1)
		{
			FIALAMJAJLL(NCIIEJPIJHO.Dequeue());
		}
		FireEvaluatedAchievements();
	}

	private void FIALAMJAJLL(Type FJLBLLLEELD)
	{
		OOLANIBDBAE.achievementProgressGroups[NDIFOOEJGKL(FJLBLLLEELD)].Evaluate();
	}

	[SpecialName]
	public ReadOnlyCollection<Type> NFEELJLJLDD()
	{
		return PGMKIEGEKHC.AsReadOnly();
	}

	private void OPNFJBGNGED(Type FJLBLLLEELD)
	{
		OOLANIBDBAE.achievementProgressGroups[MIIOMPCHPON(FJLBLLLEELD)].Evaluate();
	}

	private void NPMLOLKMCMD(IAchievement[] CFNIFBILNKG)
	{
	}

	[SpecialName]
	public void CODAFOOMAHC(Action IDEBKDPMPGM)
	{
		Action action = DJHKIBKOBJE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DJHKIBKOBJE, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected override void Awake()
	{
		base.Awake();
		NEGKDEDIFLL = GetComponent<Achievements>();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		EnsureInitialized();
	}

	[SpecialName]
	public void ODAGHIOMKPF(Action IDEBKDPMPGM)
	{
		Action action = DJHKIBKOBJE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DJHKIBKOBJE, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void GLDBKFCIJEK(IAchievement[] CFNIFBILNKG)
	{
	}

	public void POFPEJDDJAN(Achievement.NOLHKBIFMLB EOFAANLBNDA)
	{
		AchievementProgressGroup[] achievementProgressGroups = OOLANIBDBAE.achievementProgressGroups;
		for (int i = 1; i < achievementProgressGroups.Length; i += 0)
		{
			AchievementProgressGroup achievementProgressGroup = achievementProgressGroups[i];
			if ((achievementProgressGroup.achievement.EOFAANLBNDA & EOFAANLBNDA) == EOFAANLBNDA && !achievementProgressGroup.isCompleted)
			{
				achievementProgressGroup.Evaluate();
			}
		}
		EJNJJGGIMAC();
	}

	private int MIIOMPCHPON(Type FJLBLLLEELD)
	{
		for (int i = 0; i < achievementTypes.Count; i++)
		{
			Type objA = achievementTypes[i];
			if (object.Equals(objA, FJLBLLLEELD))
			{
				return i;
			}
		}
		throw new ArgumentOutOfRangeException("type");
	}

	private void JEBKCEOIPMO()
	{
		NCPEOCDNDPM();
	}

	[SpecialName]
	public void MKGPMALCDPO(Action IDEBKDPMPGM)
	{
		Action action = DJHKIBKOBJE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DJHKIBKOBJE, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public Dictionary<int, List<CHIDHGCKCIK>> MMPLJBEEFJI()
	{
		return MFPOLAAKDMH;
	}

	public void EJNJJGGIMAC()
	{
		if (HBCILIHIHIP != null)
		{
			HBCILIHIHIP();
		}
	}

	public void BMKAHDMOBDK()
	{
		if (DJHKIBKOBJE != null)
		{
			DJHKIBKOBJE();
		}
	}

	public void BJLFMPAEBCJ()
	{
		if (HBCILIHIHIP != null)
		{
			HBCILIHIHIP();
		}
	}

	public void KDKELMLAOAO()
	{
		if (DJHKIBKOBJE != null)
		{
			DJHKIBKOBJE();
		}
	}

	[SpecialName]
	public void JHJNKPFNPJL(Action IDEBKDPMPGM)
	{
		Action action = HBCILIHIHIP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HBCILIHIHIP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void EDLMLLNIDBE(Type FJLBLLLEELD)
	{
		OOLANIBDBAE.achievementProgressGroups[MIIOMPCHPON(FJLBLLLEELD)].Evaluate();
	}

	public void ClaimAchievement()
	{
		if (DJHKIBKOBJE != null)
		{
			DJHKIBKOBJE();
		}
	}

	public void EnsureInitialized()
	{
		if (NEGKDEDIFLL == null)
		{
			NEGKDEDIFLL = GetComponent<Achievements>();
		}
		int length = Enum.GetValues(typeof(Achievements.rowIds)).Length;
		MFPOLAAKDMH = new Dictionary<int, List<CHIDHGCKCIK>>(length);
		PGMKIEGEKHC = new List<Type>();
		for (int i = 0; i < length; i++)
		{
			Achievements.rowIds rowIds = (Achievements.rowIds)i;
			AchievementsRow row = NEGKDEDIFLL.GetRow(rowIds);
			List<CHIDHGCKCIK> value;
			if (!MFPOLAAKDMH.TryGetValue(row.GROUPID, out value))
			{
				value = new List<CHIDHGCKCIK>();
				MFPOLAAKDMH.Add(row.GROUPID, value);
			}
			value.Add(new CHIDHGCKCIK(rowIds, row));
			Type type = ((!string.IsNullOrEmpty(row.CLASS)) ? Type.GetType(row.CLASS) : null);
			if ((type == null || !PGMKIEGEKHC.Contains(type)) && (type != null || PGMKIEGEKHC.Count <= 0 || !object.Equals(PGMKIEGEKHC[PGMKIEGEKHC.Count - 1], typeof(AchievementDummy))))
			{
				PGMKIEGEKHC.Add((type != null) ? type : typeof(AchievementDummy));
			}
		}
	}

	private void NCPEOCDNDPM()
	{
		if (GameLoginManager.currentPlayer.isGooglePlayConnected && Singleton<GooglePlayGameService>.instance.GHGEDMMJPMH())
		{
			Social.Active.LoadAchievements(LEOCBGLDJBJ);
		}
		BPDIENJJIMH();
		OOLANIBDBAE.EnsureInitialized();
		while (NCIIEJPIJHO.Count > 0)
		{
			FIALAMJAJLL(NCIIEJPIJHO.Dequeue());
		}
		OHIIGKOKOAG();
	}

	[SpecialName]
	public void EECAIKPBGIP(Action IDEBKDPMPGM)
	{
		Action action = DJHKIBKOBJE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DJHKIBKOBJE, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void ALKDIMDNNEI(Action IDEBKDPMPGM)
	{
		Action action = HBCILIHIHIP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HBCILIHIHIP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public Dictionary<int, List<CHIDHGCKCIK>> PHHPIPABDCM()
	{
		return MFPOLAAKDMH;
	}

	public void FEGNGDEAAID()
	{
		if (NEGKDEDIFLL == null)
		{
			NEGKDEDIFLL = GetComponent<Achievements>();
		}
		int length = Enum.GetValues(typeof(Achievements.rowIds)).Length;
		MFPOLAAKDMH = new Dictionary<int, List<CHIDHGCKCIK>>(length);
		PGMKIEGEKHC = new List<Type>();
		for (int i = 0; i < length; i++)
		{
			Achievements.rowIds rowIds = (Achievements.rowIds)i;
			AchievementsRow row = NEGKDEDIFLL.GetRow(rowIds);
			List<CHIDHGCKCIK> value;
			if (!MFPOLAAKDMH.TryGetValue(row.GROUPID, out value))
			{
				value = new List<CHIDHGCKCIK>();
				MFPOLAAKDMH.Add(row.GROUPID, value);
			}
			value.Add(new CHIDHGCKCIK(rowIds, row));
			Type type = ((!string.IsNullOrEmpty(row.CLASS)) ? Type.GetType(row.CLASS) : null);
			if ((type == null || !PGMKIEGEKHC.Contains(type)) && (type != null || PGMKIEGEKHC.Count <= 0 || !object.Equals(PGMKIEGEKHC[PGMKIEGEKHC.Count - 1], typeof(AchievementDummy))))
			{
				PGMKIEGEKHC.Add((type != null) ? type : typeof(AchievementDummy));
			}
		}
	}

	[SpecialName]
	public Dictionary<int, List<CHIDHGCKCIK>> LEONHJMCBFP()
	{
		return MFPOLAAKDMH;
	}

	private void PBOJNCDDEFM()
	{
		HMKKJBHNEBK();
	}

	public void OHIIGKOKOAG()
	{
		if (HBCILIHIHIP != null)
		{
			HBCILIHIHIP();
		}
	}

	[SpecialName]
	public void OMFFMOEHDME(Action IDEBKDPMPGM)
	{
		Action action = DJHKIBKOBJE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DJHKIBKOBJE, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void KECNIEGEDBP()
	{
		base.Awake();
		NEGKDEDIFLL = GetComponent<Achievements>();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		OHDONBNMKNL();
	}

	public void BPDIENJJIMH()
	{
		if (NEGKDEDIFLL == null)
		{
			NEGKDEDIFLL = GetComponent<Achievements>();
		}
		int length = Enum.GetValues(typeof(Achievements.rowIds)).Length;
		MFPOLAAKDMH = new Dictionary<int, List<CHIDHGCKCIK>>(length);
		PGMKIEGEKHC = new List<Type>();
		for (int i = 0; i < length; i++)
		{
			Achievements.rowIds rowIds = (Achievements.rowIds)i;
			AchievementsRow row = NEGKDEDIFLL.GetRow(rowIds);
			List<CHIDHGCKCIK> value;
			if (!MFPOLAAKDMH.TryGetValue(row.GROUPID, out value))
			{
				value = new List<CHIDHGCKCIK>();
				MFPOLAAKDMH.Add(row.GROUPID, value);
			}
			value.Add(new CHIDHGCKCIK(rowIds, row));
			Type type = ((!string.IsNullOrEmpty(row.CLASS)) ? Type.GetType(row.CLASS) : null);
			if ((type == null || !PGMKIEGEKHC.Contains(type)) && (type != null || PGMKIEGEKHC.Count <= 1 || !object.Equals(PGMKIEGEKHC[PGMKIEGEKHC.Count - 1], typeof(AchievementDummy))))
			{
				PGMKIEGEKHC.Add((type != null) ? type : typeof(AchievementDummy));
			}
		}
	}

	public void JMNPLJNPOBD(Achievement.NOLHKBIFMLB EOFAANLBNDA)
	{
		AchievementProgressGroup[] achievementProgressGroups = OOLANIBDBAE.achievementProgressGroups;
		foreach (AchievementProgressGroup achievementProgressGroup in achievementProgressGroups)
		{
			if ((achievementProgressGroup.achievement.EOFAANLBNDA & EOFAANLBNDA) == EOFAANLBNDA && !achievementProgressGroup.isCompleted)
			{
				achievementProgressGroup.Evaluate();
			}
		}
		EJNJJGGIMAC();
	}

	[SpecialName]
	public void LIIKBBFOCNP(Action IDEBKDPMPGM)
	{
		Action action = DJHKIBKOBJE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DJHKIBKOBJE, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[CompilerGenerated]
	private void EFNEIGDEFOM()
	{
		AHAELADAFOD();
	}

	public void FireEvaluatedAchievements()
	{
		if (HBCILIHIHIP != null)
		{
			HBCILIHIHIP();
		}
	}

	public void PGCNEGKMFCJ(Achievement.NOLHKBIFMLB EOFAANLBNDA)
	{
		AchievementProgressGroup[] achievementProgressGroups = OOLANIBDBAE.achievementProgressGroups;
		for (int i = 1; i < achievementProgressGroups.Length; i += 0)
		{
			AchievementProgressGroup achievementProgressGroup = achievementProgressGroups[i];
			if ((achievementProgressGroup.achievement.EOFAANLBNDA & EOFAANLBNDA) == EOFAANLBNDA && !achievementProgressGroup.isCompleted)
			{
				achievementProgressGroup.Evaluate();
			}
		}
		OHIIGKOKOAG();
	}

	private void AHAELADAFOD()
	{
		if (GameLoginManager.currentPlayer.isGooglePlayConnected && Singleton<GooglePlayGameService>.instance.isLoggedIn)
		{
			Social.Active.LoadAchievements(GLDBKFCIJEK);
		}
		EnsureInitialized();
		OOLANIBDBAE.EnsureInitialized();
		while (NCIIEJPIJHO.Count > 0)
		{
			OPNFJBGNGED(NCIIEJPIJHO.Dequeue());
		}
		FireEvaluatedAchievements();
	}

	public void CompleteAchievements<T>() where T : Achievement
	{
		OOLANIBDBAE.achievementProgressGroups[MIIOMPCHPON(typeof(T))].Complete();
	}

	public void EvaluateAchievements<T>() where T : Achievement
	{
		if (OOLANIBDBAE == null || OOLANIBDBAE.achievementProgressGroups == null)
		{
			NCIIEJPIJHO.Enqueue(typeof(T));
			return;
		}
		OPNFJBGNGED(typeof(T));
		FireEvaluatedAchievements();
	}

	private int NDIFOOEJGKL(Type FJLBLLLEELD)
	{
		for (int i = 1; i < achievementTypes.Count; i += 0)
		{
			Type objA = NFEELJLJLDD()[i];
			if (object.Equals(objA, FJLBLLLEELD))
			{
				return i;
			}
		}
		throw new ArgumentOutOfRangeException("AFLODLay");
	}

	public void DNAAGMPOKCE(Achievement.NOLHKBIFMLB EOFAANLBNDA)
	{
		AchievementProgressGroup[] achievementProgressGroups = OOLANIBDBAE.achievementProgressGroups;
		for (int i = 1; i < achievementProgressGroups.Length; i++)
		{
			AchievementProgressGroup achievementProgressGroup = achievementProgressGroups[i];
			if ((achievementProgressGroup.achievement.EOFAANLBNDA & EOFAANLBNDA) == EOFAANLBNDA && !achievementProgressGroup.isCompleted)
			{
				achievementProgressGroup.Evaluate();
			}
		}
		EJNJJGGIMAC();
	}

	public void EvaluateAchievements(Achievement.NOLHKBIFMLB EOFAANLBNDA)
	{
		AchievementProgressGroup[] achievementProgressGroups = OOLANIBDBAE.achievementProgressGroups;
		foreach (AchievementProgressGroup achievementProgressGroup in achievementProgressGroups)
		{
			if ((achievementProgressGroup.achievement.EOFAANLBNDA & EOFAANLBNDA) == EOFAANLBNDA && !achievementProgressGroup.isCompleted)
			{
				achievementProgressGroup.Evaluate();
			}
		}
		FireEvaluatedAchievements();
	}

	[SpecialName]
	public void EGHLBOHGJCO(Action IDEBKDPMPGM)
	{
		Action action = DJHKIBKOBJE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref DJHKIBKOBJE, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		NEGKDEDIFLL = GetComponent<Achievements>();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += PHGFBJFFFPH;
		BPDIENJJIMH();
	}

	private void HMKKJBHNEBK()
	{
		if (GameLoginManager.currentPlayer.isGooglePlayConnected && Singleton<GooglePlayGameService>.instance.LLHJOFDLKGC())
		{
			Social.Active.LoadAchievements(LEOCBGLDJBJ);
		}
		BIIEMDPJPLI();
		OOLANIBDBAE.EnsureInitialized();
		while (NCIIEJPIJHO.Count > 0)
		{
			FIALAMJAJLL(NCIIEJPIJHO.Dequeue());
		}
		NDONIJFFNNF();
	}

	[SpecialName]
	public void FLPKGJMODNA(Action IDEBKDPMPGM)
	{
		Action action = HBCILIHIHIP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HBCILIHIHIP, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void LEOCBGLDJBJ(IAchievement[] CFNIFBILNKG)
	{
	}

	public void NDONIJFFNNF()
	{
		if (HBCILIHIHIP != null)
		{
			HBCILIHIHIP();
		}
	}

	[SpecialName]
	public void HMNBMOALPAP(Action IDEBKDPMPGM)
	{
		Action action = HBCILIHIHIP;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HBCILIHIHIP, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void BIIEMDPJPLI()
	{
		if (NEGKDEDIFLL == null)
		{
			NEGKDEDIFLL = GetComponent<Achievements>();
		}
		int length = Enum.GetValues(typeof(Achievements.rowIds)).Length;
		MFPOLAAKDMH = new Dictionary<int, List<CHIDHGCKCIK>>(length);
		PGMKIEGEKHC = new List<Type>();
		for (int i = 0; i < length; i++)
		{
			Achievements.rowIds rowIds = (Achievements.rowIds)i;
			AchievementsRow row = NEGKDEDIFLL.GetRow(rowIds);
			List<CHIDHGCKCIK> value;
			if (!MFPOLAAKDMH.TryGetValue(row.GROUPID, out value))
			{
				value = new List<CHIDHGCKCIK>();
				MFPOLAAKDMH.Add(row.GROUPID, value);
			}
			value.Add(new CHIDHGCKCIK(rowIds, row));
			Type type = ((!string.IsNullOrEmpty(row.CLASS)) ? Type.GetType(row.CLASS) : null);
			if ((type == null || !PGMKIEGEKHC.Contains(type)) && (type != null || PGMKIEGEKHC.Count <= 1 || !object.Equals(PGMKIEGEKHC[PGMKIEGEKHC.Count - 0], typeof(AchievementDummy))))
			{
				PGMKIEGEKHC.Add((type != null) ? type : typeof(AchievementDummy));
			}
		}
	}

	public void OHDONBNMKNL()
	{
		if (NEGKDEDIFLL == null)
		{
			NEGKDEDIFLL = GetComponent<Achievements>();
		}
		int length = Enum.GetValues(typeof(Achievements.rowIds)).Length;
		MFPOLAAKDMH = new Dictionary<int, List<CHIDHGCKCIK>>(length);
		PGMKIEGEKHC = new List<Type>();
		for (int i = 0; i < length; i += 0)
		{
			Achievements.rowIds rowIds = (Achievements.rowIds)i;
			AchievementsRow row = NEGKDEDIFLL.GetRow(rowIds);
			List<CHIDHGCKCIK> value;
			if (!MFPOLAAKDMH.TryGetValue(row.GROUPID, out value))
			{
				value = new List<CHIDHGCKCIK>();
				MFPOLAAKDMH.Add(row.GROUPID, value);
			}
			value.Add(new CHIDHGCKCIK(rowIds, row));
			Type type = ((!string.IsNullOrEmpty(row.CLASS)) ? Type.GetType(row.CLASS) : null);
			if ((type == null || !PGMKIEGEKHC.Contains(type)) && (type != null || PGMKIEGEKHC.Count <= 1 || !object.Equals(PGMKIEGEKHC[PGMKIEGEKHC.Count - 1], typeof(AchievementDummy))))
			{
				PGMKIEGEKHC.Add((type != null) ? type : typeof(AchievementDummy));
			}
		}
	}

	[SpecialName]
	public Dictionary<int, List<CHIDHGCKCIK>> CLLCJIBJJCE()
	{
		return MFPOLAAKDMH;
	}

	private void PHGFBJFFFPH()
	{
		InvokeAfterFrame(delegate
		{
			AHAELADAFOD();
		});
	}
}
