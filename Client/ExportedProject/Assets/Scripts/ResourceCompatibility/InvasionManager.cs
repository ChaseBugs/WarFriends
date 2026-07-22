using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

public class InvasionManager : DatabaseSerializedObjectGeneric<InvasionManager.InvasionData>
{
	[Serializable]
	[Preserve]
	public class InvasionData
	{
		[NonSerialized]
		public bool isDataValid;

		[Preserve]
		[JsonProperty]
		private JToken mEarnedRewardData;

		[Preserve]
		[JsonProperty]
		private List<RegularUnit> mSupportUnits;

		private List<GameReward> mEarnedRewards;

		[Preserve]
		[JsonProperty]
		public bool canParticipate { get; private set; }

		[Preserve]
		[JsonProperty]
		public int remainingEnergy { get; private set; }

		[Preserve]
		[JsonProperty]
		public int nextEnergyRefillTime { get; private set; }

		[JsonProperty]
		[Preserve]
		public int reachedRewardTier { get; private set; }

		[Preserve]
		[JsonProperty]
		public bool wasRewardClaimed { get; private set; }

		public ReadOnlyCollection<GameReward> earnedRewards => null;

		public ReadOnlyCollection<RegularUnit> supportUnits => null;

		[OnDeserialized]
		internal void PMLOPOKPHAK(StreamingContext LAHJMOCEDGF)
		{
		}

		public void OCECKNNPJEB()
		{
		}

		public void AHNOEBFFFNK()
		{
		}

		public void PKDFIJMDFIM(int PGAMEMJAJFN)
		{
		}

		public void OKODDEHALEK()
		{
		}
	}

	[Serializable]
	[Preserve]
	public class InvasionSquadData
	{
		public long invaderRemainingHealth;

		public List<EventLogEntry> eventLog;

		public List<DamageLogEntry> topDamagers;

		[Preserve]
		[JsonProperty]
		public string invaderId { get; private set; }

		[Preserve]
		[JsonProperty]
		public int nextMissionStartTime { get; private set; }

		[Preserve]
		[JsonProperty]
		public int currentMissionEndTime { get; private set; }

		[JsonProperty]
		[Preserve]
		public int invaderUnitId { get; private set; }

		[JsonProperty]
		[Preserve]
		public int invaderNamePrefixIndex { get; private set; }

		[JsonProperty]
		[Preserve]
		public int invaderNameSuffixIndex { get; private set; }

		[Preserve]
		[JsonProperty]
		public long invaderTotalHealth { get; private set; }

		public bool isInvaderValid => false;
	}

	[Serializable]
	[Preserve]
	public class RegularUnit
	{
		[JsonProperty]
		[Preserve]
		public int behaviourIndex { get; private set; }

		public RegularUnit()
		{
		}

		public RegularUnit(int MGKLEEPCJEF)
		{
		}
	}

	[Serializable]
	[Preserve]
	public class DamageLogEntry
	{
		[JsonProperty]
		[Preserve]
		public string playerId { get; private set; }

		[JsonProperty]
		[Preserve]
		public long damage { get; private set; }

		public void IJALKPAGKOB(long NNAHFKEMOPK)
		{
		}

		public DamageLogEntry()
		{
		}

		public DamageLogEntry(string ECIJDHLNIJO, long PIMDLOBOGIM)
		{
		}
	}

	[Serializable]
	[Preserve]
	public class EventLogEntry
	{
		[JsonProperty]
		[Preserve]
		public long eventTime { get; private set; }

		[JsonProperty]
		[Preserve]
		public string playerName { get; private set; }

		[JsonProperty]
		[Preserve]
		public long damage { get; private set; }

		public EventLogEntry()
		{
		}

		public EventLogEntry(long MKNKPMKDNGJ, string KBJPGNFNAAA, long PIMDLOBOGIM)
		{
		}
	}

	public static class CHIMMBNDGFK
	{
		private static readonly string[] AEEKLJAOHNP;

		private static readonly string[] PMKKNBFEBEK;

		public static string IOHACNEJNDP(int NDMHNCPOOPO, int HMPDJJLPGIP, int PPCKILKHJJH)
		{
			return null;
		}
	}

	public static InvasionManager NALCBOIBJJF;

	private InvasionConstants NMFBBJJJDDE;

	[CompilerGenerated]
	private InvasionSpawnSettings _003CAPNGKLIMCOM_003Ek__BackingField;

	private bool BNHEODMKBJL;

	private bool NAFMLOPGGLO;

	private bool HNFFBOKJHKD;

	[CompilerGenerated]
	private Action KOFDFFKINCE;

	[CompilerGenerated]
	private Action GIIENOFNEMF;

	[CompilerGenerated]
	private Action JNJGDKEMDBK;

	[CompilerGenerated]
	private Action DDJOCNHFOCM;

	[CompilerGenerated]
	private Action NDAECJMNHDO;

	[CompilerGenerated]
	private Action HPAHINACPGL;

	[CompilerGenerated]
	private Action LCMOCDIILLE;

	[CompilerGenerated]
	private Action LJJNBLPCDMD;

	[CompilerGenerated]
	private Action NGOFOPOAPLH;

	public InvasionSpawnSettings spawnSettings
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public bool isInvasionUnlocked => false;

	public bool isInvasionEnabled => false;

	public int numOfRequiredMembers => 0;

	public int dogtagRefillInMinutes => 0;

	public float invaderSpawnTimeMin => 0f;

	public float invaderSpawnTimeMax => 0f;

	public int invaderShieldDurability => 0;

	public float unitSpawnDelayMin => 0f;

	public float unitSpawnDelayMax => 0f;

	public float difficultyConfig => 0f;

	public float invaderShieldReplenishTime => 0f;

	public float battleDurationMax => 0f;

	public int maxUnitsOnBattleField => 0;

	public bool isMissionActive => false;

	public int missionEndTime => 0;

	public int nextMissionStartTime => 0;

	public int invaderUnitId => 0;

	public ReadOnlyCollection<RegularUnit> supportUnits => null;

	public string invaderTitle => null;

	public string invaderIconName => null;

	public long invaderTotalHealth => 0L;

	public long invaderRemainingHealth => 0L;

	public string invaderId => null;

	public bool isInvaderAlive => false;

	public int remainingEnergy => 0;

	public int maximumTotalEnergy => 0;

	public bool isEnergyRefilling => false;

	public int nextEnergyRefillTime => 0;

	public bool canWeParticipate => false;

	public int maxEventLogs => 0;

	public int maxTopDamagers => 0;

	public ReadOnlyCollection<EventLogEntry> eventLog => null;

	public ReadOnlyCollection<DamageLogEntry> topDamagers => null;

	public int reachedRewardTier => 0;

	public ReadOnlyCollection<GameReward> earnedReward => null;

	public bool hasClaimedReward => false;

	public event Action onLocalEnergySpent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action onLocalEnergyRefilled
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action EventLogUpdated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action TopDamagersUpdated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action InvaderIsDamaged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action InvaderIsDead
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action InvasionEnded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action NextGenerationCountdownEnded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action InvasionDogtagsFull
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected override void Awake()
	{
	}

	public void UpdateEventLog(EventLogEntry MDMNJBBIJPI)
	{
	}

	public void UpdateTopDamagers(DamageLogEntry EJFADKPDGMJ)
	{
	}

	public void UpdateInvaderHealth(int CODMLJOHLMD)
	{
	}

	public void SpendEnergyLocally()
	{
	}

	public void SetRewardsClaimedLocally()
	{
	}

	protected override void LoadEmpty()
	{
	}

	protected override void InitData()
	{
	}

	private void Update()
	{
	}

	public void ScheduleInvasionNotifications()
	{
	}
}
