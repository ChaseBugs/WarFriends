using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Scripting;

public class WarArena : DatabaseSerializedObjectGeneric<WarArena.WarArenaData>
{
	[Serializable]
	[Preserve]
	public class WarArenaData
	{
		public ObscuredInt wins;

		public ObscuredInt lives;

		public List<string> opponents;

		public string arenaId;

		public int runs;

		public int paidRuns;

		public string visualType;

		public int visualTimestamp;

		public int flawless;

		public int topRun;

		public int matches;

		public int shields;

		public bool played;

		public bool heartDialogShown;
	}

	private static WarArena DJDBDKFAKHN;

	[CompilerGenerated]
	private Action KBFKCGNGLDP;

	[CompilerGenerated]
	private Action<int> KAHKJMGHBGE;

	[CompilerGenerated]
	private Action JLPLPNPLNFI;

	[CompilerGenerated]
	private Action LDENGLNDBIH;

	public List<WarArenaRule> JDJJCLHIOIK;

	public TextAsset LNBNIBCCEFH;

	public WarArenaConfig EKAOLGFAEOE;

	public WararenaLootboxReward KGENHGJPLKL;

	private WarArenaParameters MCIDDELKMNF;

	private PhotonView IBBJLFJLAFA;

	private List<WarArenaRule> ODAOLHKLOKP;

	private ArenaLootboxes NCPLKLMBAAO;

	private bool KCDCLLELKJK;

	private bool JLOFABNCNED;

	public static WarArena instance => null;

	public WarArenaParameters warArenaParameters => null;

	public ArenaLootboxes arenaLootboxes => null;

	public WarArenaParameters wararenaParameters => null;

	public bool isArenaTicketBought => false;

	public bool isGoodPing => false;

	public bool isOpened => false;

	public bool isExpired => false;

	public bool isReminderTime => false;

	public int remainigTimeTillStart => 0;

	public int remainigTimeTillEnd => 0;

	public bool goldShieldsActive => false;

	public int phaseNumber => 0;

	public int wararenaTicketPrize => 0;

	public int extraLiveCost => 0;

	public List<WarArenaRule> currenArenaRules => null;

	public event Action WarArenaDataChanged
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

	public event Action<int> LivesChanged
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

	public event Action WarArenaExpired
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

	public event Action WarArenaStarter
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

	public void OnDestroy()
	{
	}

	protected override void Awake()
	{
	}

	public void LoadWarArenaConfig(JToken JFNEGCPHIFI)
	{
	}

	protected override void Load(JToken FIMDMKAOBGJ)
	{
	}

	public void TryGetNewArena()
	{
	}

	private void COJCEOJGEOC()
	{
	}

	private void HCOCHDHHLPC(GameController.ALOAMODMHMO DFEHIADKKNO)
	{
	}

	public void FailedDownloadWarArena()
	{
	}

	public void TakePlayerLive()
	{
	}

	public void UpdateLives(int CHIIPOPCPPC)
	{
	}

	private int FHIFKOHIDJH(out bool KPAEJOODACM)
	{
		KPAEJOODACM = default(bool);
		return 0;
	}

	private void IGJFJENMJED()
	{
	}

	public bool SetupRules()
	{
		return false;
	}

	public void ApplyRules()
	{
	}

	public void ReleaseRules()
	{
	}

	public void SyncArenaRule(int MIJANJLODHN, object[] OLEGNKELNEA)
	{
	}

	public T GetRule<T>(out int EPNGMAHENPA) where T : WarArenaRule
	{
		EPNGMAHENPA = default(int);
		return null;
	}

	[PunRPC]
	private void SyncArenaRuleRPC(int MIJANJLODHN, object[] OLEGNKELNEA)
	{
	}

	private WarArenaRule PFDJKALFHMF(string DBIBCFCDHIG)
	{
		return null;
	}

	public bool IsIgnoringMax2UnitsPerCategory()
	{
		return false;
	}

	public List<WarArenaRule> DeserializeRules(string CDEKMDAKMDN)
	{
		return null;
	}
}
