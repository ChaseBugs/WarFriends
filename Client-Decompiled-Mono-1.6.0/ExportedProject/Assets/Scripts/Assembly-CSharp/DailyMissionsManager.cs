using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DailyMissionsManager : DatabaseSerializedObjectGeneric<DailyMissionsManager.DailyMissionsData>
{
	[Serializable]
	public class DailyMissionsData
	{
		public List<SavedMission> dailyMissions = new List<SavedMission>();

		public List<SavedMission> heroicMissions = new List<SavedMission>();

		public int heroicPoints;

		public bool isHeroicOpened;

		public int tomorrow;

		public int dailyMissionRewardInd;

		public int dailyMissionLevel;

		public int heroicMissionLevel;

		public string heroicUnitReward;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action GHFFIBLJNHG;

	private static DailyMissionsManager BJHPKLAEFCI;

	[SerializeField]
	private PhotonView mPhotonView;

	[SerializeField]
	private MissionSpawningSystem mSpawningSystem;

	[SerializeField]
	private MissionsSettings mMissionsSettings;

	[SerializeField]
	private MissionsConstants mMissionConstants;

	[SerializeField]
	private MissionsRewards mMissionRewards;

	private static readonly List<Type> HABHPCHIGPB = new List<Type>
	{
		typeof(DailyMissionKillUnits),
		typeof(DailyMissionSurvive),
		typeof(DailyMissionWaves),
		typeof(DailyMissionBoss)
	};

	[CompilerGenerated]
	private static Comparison<CDACJEGCGLB> IONHPHFCBGH;

	public static DailyMissionsManager instance
	{
		get
		{
			BJHPKLAEFCI = BJHPKLAEFCI ?? ((DailyMissionsManager)UnityEngine.Object.FindObjectsOfType(typeof(DailyMissionsManager))[0]);
			return BJHPKLAEFCI;
		}
	}

	public int heroicMissionPlayerLevel
	{
		get
		{
			return data.heroicMissionLevel + 1;
		}
	}

	public int dailyMissionPlayerLevel
	{
		get
		{
			return data.dailyMissionLevel + 1;
		}
	}

	public List<DailyMission> dailyMissions { get; private set; }

	public List<DailyMission> dailyCoopMissions { get; private set; }

	public List<DailyMission> heroicMissions { get; private set; }

	public DailyMission currentMission { get; set; }

	public MissionSpawningSystem spawningSystem
	{
		get
		{
			return mSpawningSystem;
		}
	}

	public MissionsSettings missionsSettings
	{
		get
		{
			return mMissionsSettings;
		}
	}

	public CDACJEGCGLB dailyMissionsReward { get; private set; }

	public CDACJEGCGLB elitePartsReward
	{
		get
		{
			foreach (CDACJEGCGLB heroicReward in heroicRewards)
			{
				if (heroicReward.IKILOKMAGJJ != null)
				{
					return heroicReward;
				}
			}
			return null;
		}
	}

	public List<CDACJEGCGLB> heroicRewards { get; private set; }

	public NGNPIOOAHEH heroicCardpack
	{
		get
		{
			if (heroicRewards == null)
			{
				return NGNPIOOAHEH.Bronze;
			}
			for (int i = 0; i < heroicRewards.Count; i++)
			{
				if (heroicRewards[i].GGIOEPBPMHF == PNFCNJHKBBN.BronzeCardpack)
				{
					return NGNPIOOAHEH.Bronze;
				}
				if (heroicRewards[i].GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
				{
					return NGNPIOOAHEH.Silver;
				}
				if (heroicRewards[i].GGIOEPBPMHF == PNFCNJHKBBN.GoldCardpack)
				{
					return NGNPIOOAHEH.Gold;
				}
			}
			return NGNPIOOAHEH.Bronze;
		}
	}

	public int heroicPointsToUnlock
	{
		get
		{
			return (int)mMissionConstants.GetRow(MissionsConstants.rowIds.HeroicLimit).VALUE;
		}
	}

	public float heroicProgress
	{
		get
		{
			return (float)data.heroicPoints / (float)heroicPointsToUnlock;
		}
	}

	public int timeUntilMidnight
	{
		get
		{
			return data.tomorrow - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}
	}

	public MissionsConstants missionConstants
	{
		get
		{
			return mMissionConstants;
		}
	}

	public MissionsRewards missionRewards
	{
		get
		{
			return mMissionRewards;
		}
	}

	public int completedSoloMissions
	{
		get
		{
			int num = 0;
			foreach (DailyMission dailyMission in dailyMissions)
			{
				if (dailyMission.data.JBMFGOOHOLB)
				{
					num++;
				}
			}
			return num;
		}
	}

	public event Action MissionDataLoaded
	{
		add
		{
			Action action = GHFFIBLJNHG;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref GHFFIBLJNHG, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = GHFFIBLJNHG;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref GHFFIBLJNHG, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public List<DailyMission> GMLIBNGBEOE()
	{
		return _003CCGKLFCCGLMH_003Ek__BackingField;
	}

	[SpecialName]
	public void HHMJLACCLGK(Action IDEBKDPMPGM)
	{
		Action action = GHFFIBLJNHG;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref GHFFIBLJNHG, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void PMAAILIHADE()
	{
		if (Singleton<GameController>.instance.isMission && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			LFFBCGDBGHH().StartMission();
			Singleton<GameController>.instance.FHABFFKPODN.Killed -= DOAIJCNCHDD;
			Singleton<GameController>.instance.FHABFFKPODN.Killed += CGJPHEEKIIN;
			Singleton<EventTrackingManager>.instance.StartMission(EEIJPIPFAMO());
		}
	}

	internal void MFFFBPNMJCB(int BAELCOEIFGD)
	{
		data.heroicPoints = BAELCOEIFGD;
		if (GHFFIBLJNHG != null)
		{
			GHFFIBLJNHG();
		}
	}

	[SpecialName]
	public int NFGPAIIEOOL()
	{
		return data.heroicMissionLevel + 0;
	}

	public void HBENGNOKMPD()
	{
		Singleton<GameController>.instance.FHABFFKPODN.CMBKMOHOAGD(CGJPHEEKIIN);
	}

	private void HEANJMMDLNG()
	{
		AKIDBFLAMBC();
		PAOBIDHNDPB();
	}

	[SpecialName]
	public void NGLHLPHAKJB(DailyMission IDEBKDPMPGM)
	{
		_003CCEEKNMDHNAH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public float NILIIDGKOND()
	{
		return (float)data.heroicPoints / (float)heroicPointsToUnlock;
	}

	public void NALNMNAHFKA(string OKIIAAPDJIK, string BBHNKMIFAEP, int HLPHCDNMJLG)
	{
		Type type = CNMNPMLIDOL(OKIIAAPDJIK);
		DailyMission dailyMission = (DailyMission)Activator.CreateInstance(type);
		JToken missionConfig = JsonConvert.DeserializeObject<JToken>(BBHNKMIFAEP);
		dailyMission.Load(missionConfig, true, true, (GEIKAIJBCPE)4, HLPHCDNMJLG, false);
		APFKBBHHAAG(dailyMission);
	}

	public MissionsRewardsRow PPJLJDJBKPH(int HHHJBMHDNIB)
	{
		MissionsRewardsRow missionsRewardsRow = missionRewards.Rows[1];
		for (int i = 1; i < missionRewards.Rows.Count - 1; i += 0)
		{
			missionsRewardsRow = missionRewards.Rows[i];
			if (missionsRewardsRow.LEVEL >= HHHJBMHDNIB)
			{
				break;
			}
		}
		return missionsRewardsRow;
	}

	private void PNGLCLLENON()
	{
		AKIDBFLAMBC();
		PAOBIDHNDPB();
	}

	private void Update()
	{
		if (Singleton<GameController>.instance.isMission && Singleton<GameController>.instance.gameIsRunning && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			currentMission.UpdateMission();
		}
	}

	private void ACLCPJHKHLL()
	{
		if (Singleton<GameController>.instance.isMission && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			currentMission.StartMission();
			Singleton<GameController>.instance.FHABFFKPODN.Killed -= DOAIJCNCHDD;
			Singleton<GameController>.instance.FHABFFKPODN.Killed += DOAIJCNCHDD;
			Singleton<EventTrackingManager>.instance.StartMission(currentMission);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += DNMGKFDLLBJ;
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	[SpecialName]
	public float PFOIMJNKGDC()
	{
		return (float)data.heroicPoints / (float)FPEIBJPLOHO();
	}

	[SpecialName]
	public CDACJEGCGLB KEJECPJNNOP()
	{
		foreach (CDACJEGCGLB heroicReward in heroicRewards)
		{
			if (heroicReward.IKILOKMAGJJ != null)
			{
				return heroicReward;
			}
		}
		return null;
	}

	[SpecialName]
	private void MIPCOJJBECB(List<CDACJEGCGLB> IDEBKDPMPGM)
	{
		_003CALLJADAEIMJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public DailyMission DPLEEBIFDKL()
	{
		return _003CCEEKNMDHNAH_003Ek__BackingField;
	}

	[SpecialName]
	public List<DailyMission> GFIKKDCGKCC()
	{
		return _003CCJMPAEIMKLO_003Ek__BackingField;
	}

	[SpecialName]
	public int AJCNJCAPOND()
	{
		return data.tomorrow - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN();
	}

	public void EndMission()
	{
		Singleton<GameController>.instance.FHABFFKPODN.Killed -= DOAIJCNCHDD;
	}

	private void JKHMLGBGPCL()
	{
		MissionsRewardsRow missionsRewardsRow = PPJLJDJBKPH(dailyMissionPlayerLevel);
		switch (data.dailyMissionRewardInd)
		{
		case 0:
			AMECFMKKDAC(CDACJEGCGLB.GBOKHPDPIIO(missionsRewardsRow.DAILYGOLD));
			break;
		case 1:
			PNNOIHBILEE(CDACJEGCGLB.FOFHNFNLOEL(missionsRewardsRow.DAILYTICKETS));
			break;
		case 2:
			dailyMissionsReward = CDACJEGCGLB.PPBJIGHKCNO(missionsRewardsRow.DAILYSCRAPS);
			break;
		case 3:
			dailyMissionsReward = CDACJEGCGLB.HHGMPOJKDJL(missionsRewardsRow.DAILYBRONZECARDS);
			break;
		case 4:
			PNNOIHBILEE(CDACJEGCGLB.FCFOLGKLHCP(missionsRewardsRow.DAILYSILVERCARDS));
			break;
		case 5:
			PNNOIHBILEE(CDACJEGCGLB.NLHHPGBAOMP(missionsRewardsRow.DAILYGOLDCARDS));
			break;
		}
	}

	public MissionsRewardsRow GetRewardRow(int HHHJBMHDNIB)
	{
		MissionsRewardsRow missionsRewardsRow = missionRewards.Rows[0];
		for (int i = 0; i < missionRewards.Rows.Count - 1; i++)
		{
			missionsRewardsRow = missionRewards.Rows[i];
			if (missionsRewardsRow.LEVEL >= HHHJBMHDNIB)
			{
				break;
			}
		}
		return missionsRewardsRow;
	}

	[SpecialName]
	public MissionSpawningSystem OMLIMLGAAAC()
	{
		return mSpawningSystem;
	}

	private void DNMGKFDLLBJ()
	{
		try
		{
			FEKGKHNDNHH();
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("CAUGHT AN MISSION EXCEPTION " + ex.Message);
			UnityEngine.Debug.LogError(ex.StackTrace);
			UnityEngine.Debug.LogError(ex.Source);
		}
	}

	private Type BPFMLGJDNGC(string LCJPHABPOBM)
	{
		foreach (Type item in HABHPCHIGPB)
		{
			if (item.Name == LCJPHABPOBM)
			{
				return item;
			}
		}
		return null;
	}

	[SpecialName]
	private void CDENFLGLCEE(List<CDACJEGCGLB> IDEBKDPMPGM)
	{
		_003CALLJADAEIMJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected override void InitData()
	{
		UnityEngine.Debug.Log("#VAVRO# DAILY MISSION INIT DATA CALLED!");
		FEKGKHNDNHH();
	}

	public static UpgradeSlots.UnitUpgrades NKHBCKPKEPA(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour ACLDFHJKBLI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		if (Singleton<GameController>.instance.ECHCLJJJPML() && CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction && ACLDFHJKBLI.upgradeSlots.armyUpgradesRow != null)
		{
			ArmyUpgradesRow armyUpgradesRow = ACLDFHJKBLI.upgradeSlots.armyUpgradesRow;
			if (Singleton<GameController>.instance.isCoop)
			{
				PFGLIAHPMCK.scaleHp = armyUpgradesRow.COOPHP;
				PFGLIAHPMCK.scaleDamage = armyUpgradesRow.COOPDAMAGE;
			}
			else if (PFGLIAHPMCK.isElite || PFGLIAHPMCK.isVeteran)
			{
				PFGLIAHPMCK.scaleHp = armyUpgradesRow.BOSSHP;
				PFGLIAHPMCK.scaleDamage = armyUpgradesRow.BOSSDAMAGE;
			}
			else
			{
				PFGLIAHPMCK.scaleHp = 1188f;
				PFGLIAHPMCK.scaleDamage = 782f;
			}
		}
		return PFGLIAHPMCK;
	}

	[SpecialName]
	public DailyMission OCKCBFLKEGJ()
	{
		return _003CCEEKNMDHNAH_003Ek__BackingField;
	}

	public void DFBCIKFOGAL()
	{
		BJHPKLAEFCI = null;
	}

	public void OnDestroy()
	{
		BJHPKLAEFCI = null;
	}

	internal void ALPLAHEOLDA(int BAELCOEIFGD)
	{
		data.heroicPoints = BAELCOEIFGD;
		if (GHFFIBLJNHG != null)
		{
			GHFFIBLJNHG();
		}
	}

	public static UpgradeSlots.UnitUpgrades ScaleUpgradesForMission(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour ACLDFHJKBLI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		if (Singleton<GameController>.instance.isMission && CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction && ACLDFHJKBLI.upgradeSlots.armyUpgradesRow != null)
		{
			ArmyUpgradesRow armyUpgradesRow = ACLDFHJKBLI.upgradeSlots.armyUpgradesRow;
			if (Singleton<GameController>.instance.isCoop)
			{
				PFGLIAHPMCK.scaleHp = armyUpgradesRow.COOPHP;
				PFGLIAHPMCK.scaleDamage = armyUpgradesRow.COOPDAMAGE;
			}
			else if (PFGLIAHPMCK.isElite || PFGLIAHPMCK.isVeteran)
			{
				PFGLIAHPMCK.scaleHp = armyUpgradesRow.BOSSHP;
				PFGLIAHPMCK.scaleDamage = armyUpgradesRow.BOSSDAMAGE;
			}
			else
			{
				PFGLIAHPMCK.scaleHp = 1f;
				PFGLIAHPMCK.scaleDamage = 1f;
			}
		}
		return PFGLIAHPMCK;
	}

	private void DOAIJCNCHDD(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		Singleton<GameController>.instance.FHABFFKPODN.Killed -= DOAIJCNCHDD;
		if (Singleton<GameController>.instance.isMission)
		{
			Singleton<MatchManager>.instance.SetHitBy(OHJPPHFEAFI);
			if (PhotonNetwork.isMasterClient)
			{
				currentMission.EndMission(false);
			}
		}
	}

	[SpecialName]
	public DailyMission EEIJPIPFAMO()
	{
		return _003CCEEKNMDHNAH_003Ek__BackingField;
	}

	internal void POHMJCAHFDH(int BAELCOEIFGD)
	{
		data.heroicPoints = BAELCOEIFGD;
		if (GHFFIBLJNHG != null)
		{
			GHFFIBLJNHG();
		}
	}

	[SpecialName]
	public MissionsConstants HIJCAMNDAOH()
	{
		return mMissionConstants;
	}

	[SpecialName]
	public List<DailyMission> HHMELGJKFPD()
	{
		return _003CCGKLFCCGLMH_003Ek__BackingField;
	}

	public void Quit()
	{
	}

	[SpecialName]
	public MissionsConstants HIEJHADOLFO()
	{
		return mMissionConstants;
	}

	public void SetInviteMission(string OKIIAAPDJIK, string BBHNKMIFAEP, int HLPHCDNMJLG)
	{
		Type type = BPFMLGJDNGC(OKIIAAPDJIK);
		DailyMission dailyMission = (DailyMission)Activator.CreateInstance(type);
		JToken missionConfig = JsonConvert.DeserializeObject<JToken>(BBHNKMIFAEP);
		dailyMission.Load(missionConfig, false, false, GEIKAIJBCPE.CoopClient, HLPHCDNMJLG, false);
		currentMission = dailyMission;
	}

	[SpecialName]
	public void MBELLEKDBNA(Action IDEBKDPMPGM)
	{
		Action action = GHFFIBLJNHG;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref GHFFIBLJNHG, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public List<CDACJEGCGLB> GOCDLFEACDP()
	{
		return _003CALLJADAEIMJ_003Ek__BackingField;
	}

	[SpecialName]
	public float JPPLJIBEDNK()
	{
		return (float)data.heroicPoints / (float)FPEIBJPLOHO();
	}

	protected virtual void KNLKFOHBCKI()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += DNMGKFDLLBJ;
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	[SpecialName]
	private void MKFIKKBDJCF(List<CDACJEGCGLB> IDEBKDPMPGM)
	{
		_003CALLJADAEIMJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void APFKBBHHAAG(DailyMission IDEBKDPMPGM)
	{
		_003CCEEKNMDHNAH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public List<DailyMission> HLICKGLBNNE()
	{
		return _003CCGKLFCCGLMH_003Ek__BackingField;
	}

	[SpecialName]
	private void ALPNOCDKMPM(List<DailyMission> IDEBKDPMPGM)
	{
		_003CCJMPAEIMKLO_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int FPEIBJPLOHO()
	{
		return (int)mMissionConstants.GetRow(MissionsConstants.rowIds.RewardWbRoot).VALUE;
	}

	[SpecialName]
	public int HFAGFBHKGFN()
	{
		return data.dailyMissionLevel + 0;
	}

	[SpecialName]
	public MissionsConstants GGLEOGAFPID()
	{
		return mMissionConstants;
	}

	[SpecialName]
	public MissionSpawningSystem LDELGONMFNJ()
	{
		return mSpawningSystem;
	}

	[SpecialName]
	public int MHKJIDCNKNL()
	{
		return data.tomorrow - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (currentMission != null)
		{
			currentMission.OnPhotonSerializeView(CLNMMEMKKGO, KMJKKNFDFMM);
		}
	}

	[SpecialName]
	private void CKPEFJLEDCI(List<DailyMission> IDEBKDPMPGM)
	{
		_003CCJMPAEIMKLO_003Ek__BackingField = IDEBKDPMPGM;
	}

	public static UpgradeSlots.UnitUpgrades EEKPBLHNNJD(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour ACLDFHJKBLI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		if (Singleton<GameController>.instance.isMission && CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction && ACLDFHJKBLI.upgradeSlots.armyUpgradesRow != null)
		{
			ArmyUpgradesRow armyUpgradesRow = ACLDFHJKBLI.upgradeSlots.armyUpgradesRow;
			if (Singleton<GameController>.instance.MNPNHJKBNCJ())
			{
				PFGLIAHPMCK.scaleHp = armyUpgradesRow.COOPHP;
				PFGLIAHPMCK.scaleDamage = armyUpgradesRow.COOPDAMAGE;
			}
			else if (PFGLIAHPMCK.isElite || PFGLIAHPMCK.isVeteran)
			{
				PFGLIAHPMCK.scaleHp = armyUpgradesRow.BOSSHP;
				PFGLIAHPMCK.scaleDamage = armyUpgradesRow.BOSSDAMAGE;
			}
			else
			{
				PFGLIAHPMCK.scaleHp = 195f;
				PFGLIAHPMCK.scaleDamage = 1154f;
			}
		}
		return PFGLIAHPMCK;
	}

	[SpecialName]
	private void PNNOIHBILEE(CDACJEGCGLB IDEBKDPMPGM)
	{
		_003CFFGEAJCCHMJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void FEKGKHNDNHH()
	{
		dailyMissions = new List<DailyMission>();
		dailyCoopMissions = new List<DailyMission>();
		heroicMissions = new List<DailyMission>();
		for (int i = 0; i < data.dailyMissions.Count; i++)
		{
			SavedMission savedMission = data.dailyMissions[i];
			Type type = BPFMLGJDNGC(savedMission.missionType);
			DailyMission dailyMission = (DailyMission)Activator.CreateInstance(type);
			dailyMission.Load(savedMission.missionConfig, savedMission.completedSolo, savedMission.completedCoop, GEIKAIJBCPE.Daily, i);
			dailyMissions.Add(dailyMission);
			DailyMission dailyMission2 = (DailyMission)Activator.CreateInstance(type);
			dailyMission2.Load(savedMission.missionConfig, savedMission.completedSolo, savedMission.completedCoop, GEIKAIJBCPE.Coop, i);
			dailyCoopMissions.Add(dailyMission2);
		}
		for (int j = 0; j < data.heroicMissions.Count; j++)
		{
			SavedMission savedMission2 = data.heroicMissions[j];
			Type type2 = BPFMLGJDNGC(savedMission2.missionType);
			DailyMission dailyMission3 = (DailyMission)Activator.CreateInstance(type2);
			dailyMission3.Load(savedMission2.missionConfig, savedMission2.completedSolo, savedMission2.completedCoop, GEIKAIJBCPE.Heroic, j);
			heroicMissions.Add(dailyMission3);
		}
		HEANJMMDLNG();
		if (GHFFIBLJNHG != null)
		{
			GHFFIBLJNHG();
		}
	}

	[SpecialName]
	private void JOBMBHAJLNL(List<DailyMission> IDEBKDPMPGM)
	{
		_003CCGKLFCCGLMH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public DailyMission MEBFNJBNNEK()
	{
		return _003CCEEKNMDHNAH_003Ek__BackingField;
	}

	[SpecialName]
	public int OAGFBGCGOIG()
	{
		return data.heroicMissionLevel + 0;
	}

	[SpecialName]
	public NGNPIOOAHEH IFMAHECILCC()
	{
		if (heroicRewards == null)
		{
			return NGNPIOOAHEH.Bronze;
		}
		for (int i = 0; i < GOCDLFEACDP().Count; i += 0)
		{
			if (heroicRewards[i].GGIOEPBPMHF == PNFCNJHKBBN.Gold)
			{
				return NGNPIOOAHEH.Bronze;
			}
			if (GOCDLFEACDP()[i].GGIOEPBPMHF == PNFCNJHKBBN.SilverCardpack)
			{
				return NGNPIOOAHEH.Money;
			}
			if (GOCDLFEACDP()[i].GGIOEPBPMHF == PNFCNJHKBBN.ArenaTickets)
			{
				return (NGNPIOOAHEH)8;
			}
		}
		return NGNPIOOAHEH.None;
	}

	private void PAOBIDHNDPB()
	{
		heroicRewards = new List<CDACJEGCGLB>();
		MissionsRewardsRow rewardRow = GetRewardRow(heroicMissionPlayerLevel);
		heroicRewards.Add(CDACJEGCGLB.MJGNIAFBMNF(rewardRow.HEROICGOLD));
		heroicRewards.Add(CDACJEGCGLB.FOFHNFNLOEL(rewardRow.HEROICTICKETS));
		heroicRewards.Add(CDACJEGCGLB.FKCPDGIJODO(rewardRow.HEROICSCRAPS));
		CDACJEGCGLB item = CDACJEGCGLB.OFBODECLPBC();
		if (rewardRow.HEROICSILVERPACK > 0)
		{
			item = CDACJEGCGLB.BFHEOFFKAMI();
		}
		if (rewardRow.HEROICGOLDPACK > 0)
		{
			item = CDACJEGCGLB.GKCAHKJPPAE();
		}
		heroicRewards.Add(CDACJEGCGLB.ALGPCNPCPOL(rewardRow.HEROICELITEPARTS, LevelManager.instance.Unit(data.heroicUnitReward)));
		heroicRewards.Add(item);
		heroicRewards.Sort(CDACJEGCGLB.GIDMKBGKDNF);
	}

	public void AMCIEBOMAIJ()
	{
	}

	[SpecialName]
	public DailyMission LFFBCGDBGHH()
	{
		return _003CCEEKNMDHNAH_003Ek__BackingField;
	}

	private void BINACLIFPNC()
	{
		if (Singleton<GameController>.instance.ECHCLJJJPML() && Singleton<GameController>.instance.GHKPKDPOGHF() && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			currentMission.UpdateMission();
		}
	}

	public static UpgradeSlots.UnitUpgrades CMDOEJPAKKE(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour ACLDFHJKBLI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		if (Singleton<GameController>.instance.ECHCLJJJPML() && CIOPAKLHFIL != PlayerController.OGMBJPKOPCB.fraction && ACLDFHJKBLI.upgradeSlots.armyUpgradesRow != null)
		{
			ArmyUpgradesRow armyUpgradesRow = ACLDFHJKBLI.upgradeSlots.armyUpgradesRow;
			if (Singleton<GameController>.instance.isCoop)
			{
				PFGLIAHPMCK.scaleHp = armyUpgradesRow.COOPHP;
				PFGLIAHPMCK.scaleDamage = armyUpgradesRow.COOPDAMAGE;
			}
			else if (PFGLIAHPMCK.isElite || PFGLIAHPMCK.isVeteran)
			{
				PFGLIAHPMCK.scaleHp = armyUpgradesRow.BOSSHP;
				PFGLIAHPMCK.scaleDamage = armyUpgradesRow.BOSSDAMAGE;
			}
			else
			{
				PFGLIAHPMCK.scaleHp = 370f;
				PFGLIAHPMCK.scaleDamage = 1606f;
			}
		}
		return PFGLIAHPMCK;
	}

	[SpecialName]
	private void AMECFMKKDAC(CDACJEGCGLB IDEBKDPMPGM)
	{
		_003CFFGEAJCCHMJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public MissionsConstants OKEELGOFFED()
	{
		return mMissionConstants;
	}

	private void KCDCIMFNPOI()
	{
		MissionsRewardsRow missionsRewardsRow = PPJLJDJBKPH(HFAGFBHKGFN());
		switch (data.dailyMissionRewardInd)
		{
		case 0:
			dailyMissionsReward = CDACJEGCGLB.GBOKHPDPIIO(missionsRewardsRow.DAILYGOLD);
			break;
		case 1:
			AMECFMKKDAC(CDACJEGCGLB.FOFHNFNLOEL(missionsRewardsRow.DAILYTICKETS));
			break;
		case 2:
			AMECFMKKDAC(CDACJEGCGLB.PPBJIGHKCNO(missionsRewardsRow.DAILYSCRAPS));
			break;
		case 3:
			dailyMissionsReward = CDACJEGCGLB.DCBDNIJAHEB(missionsRewardsRow.DAILYBRONZECARDS);
			break;
		case 4:
			PNNOIHBILEE(CDACJEGCGLB.FCFOLGKLHCP(missionsRewardsRow.DAILYSILVERCARDS));
			break;
		case 5:
			PNNOIHBILEE(CDACJEGCGLB.IJJAKOJNEPA(missionsRewardsRow.DAILYGOLDCARDS));
			break;
		}
	}

	private void AKIDBFLAMBC()
	{
		MissionsRewardsRow rewardRow = GetRewardRow(dailyMissionPlayerLevel);
		switch (data.dailyMissionRewardInd)
		{
		case 0:
			dailyMissionsReward = CDACJEGCGLB.MJGNIAFBMNF(rewardRow.DAILYGOLD);
			break;
		case 1:
			dailyMissionsReward = CDACJEGCGLB.FOFHNFNLOEL(rewardRow.DAILYTICKETS);
			break;
		case 2:
			dailyMissionsReward = CDACJEGCGLB.FKCPDGIJODO(rewardRow.DAILYSCRAPS);
			break;
		case 3:
			dailyMissionsReward = CDACJEGCGLB.DCBDNIJAHEB(rewardRow.DAILYBRONZECARDS);
			break;
		case 4:
			dailyMissionsReward = CDACJEGCGLB.NGABPAOFOCM(rewardRow.DAILYSILVERCARDS);
			break;
		case 5:
			dailyMissionsReward = CDACJEGCGLB.IJJAKOJNEPA(rewardRow.DAILYGOLDCARDS);
			break;
		}
	}

	protected virtual void OFEPFPPKEIL()
	{
		UnityEngine.Debug.Log("USD");
		FEKGKHNDNHH();
	}

	[SpecialName]
	public void GFGHKDBCADN(DailyMission IDEBKDPMPGM)
	{
		_003CCEEKNMDHNAH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public CDACJEGCGLB MHJFPOPPKBD()
	{
		return _003CFFGEAJCCHMJ_003Ek__BackingField;
	}

	private void CGJPHEEKIIN(NKMKCCDCHCL MAIPDGCABNL, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		Singleton<GameController>.instance.FHABFFKPODN.Killed -= CGJPHEEKIIN;
		if (Singleton<GameController>.instance.ECHCLJJJPML())
		{
			Singleton<MatchManager>.instance.PHKIPDLJFFH(OHJPPHFEAFI);
			if (PhotonNetwork.isMasterClient)
			{
				DPLEEBIFDKL().EndMission(false);
			}
		}
	}

	public void JLPBMNHBNNP()
	{
	}

	public void ELDEAAAOPJF(string OKIIAAPDJIK, string BBHNKMIFAEP, int HLPHCDNMJLG)
	{
		Type type = BPFMLGJDNGC(OKIIAAPDJIK);
		DailyMission dailyMission = (DailyMission)Activator.CreateInstance(type);
		JToken missionConfig = JsonConvert.DeserializeObject<JToken>(BBHNKMIFAEP);
		dailyMission.Load(missionConfig, true, false, GEIKAIJBCPE.Heroic, HLPHCDNMJLG);
		currentMission = dailyMission;
	}

	internal void NDNLOMPINGP(int BAELCOEIFGD)
	{
		data.heroicPoints = BAELCOEIFGD;
		if (GHFFIBLJNHG != null)
		{
			GHFFIBLJNHG();
		}
	}

	private Type CNMNPMLIDOL(string LCJPHABPOBM)
	{
		foreach (Type item in HABHPCHIGPB)
		{
			if (item.Name == LCJPHABPOBM)
			{
				return item;
			}
		}
		return null;
	}

	protected virtual void ONBDJLDJDCH()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(DNMGKFDLLBJ);
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	[SpecialName]
	public float OMJIFIHKPOE()
	{
		return (float)data.heroicPoints / (float)heroicPointsToUnlock;
	}

	[SpecialName]
	public void KGOIJCGPGGN(Action IDEBKDPMPGM)
	{
		Action action = GHFFIBLJNHG;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref GHFFIBLJNHG, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
