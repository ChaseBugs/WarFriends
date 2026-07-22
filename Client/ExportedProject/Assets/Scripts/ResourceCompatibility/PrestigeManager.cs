using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine.Scripting;

public class PrestigeManager : DatabaseSerializedObjectGeneric<PrestigeManager.PrestigeData>
{
	[Serializable]
	[Preserve]
	public class PrestigeData
	{
		[JsonProperty]
		public long totalPrestigeExperience;

		[JsonProperty]
		public int prestigeLevel;

		[JsonProperty]
		public long prestigeLevelExp;

		[JsonProperty]
		public long dailyProgress;

		[JsonProperty]
		public bool prestigeShown;
	}

	public class LIJMHGDJLKO
	{
		public int EPNGMAHENPA;

		public PrestigeRow HDMOKLHLDEA;

		public int ANNNFJIEDPD => 0;

		public string EGIAFEHPIGI => null;

		public long NMKFKNKNMNL => 0L;

		public int GKKDPAFMAPM => 0;

		public float ICHHOMPBJOD => 0f;

		public float FENAFEGMGLP => 0f;

		public long AKNDCPJCPNA => 0L;

		public LIJMHGDJLKO(int DBMLGANKIOK)
		{
		}

		public LIJMHGDJLKO()
		{
		}
	}

	private static PrestigeManager DJDBDKFAKHN;

	public List<LIJMHGDJLKO> EAJHKAPGADG;

	[CompilerGenerated]
	private static Action DPALMJDACLN;

	private bool BJKNNDOELMK;

	private Prestige OCBEFIPPECP;

	[CompilerGenerated]
	private int _003CCMMEHHPDHFH_003Ek__BackingField;

	public static PrestigeManager instance => null;

	public bool active => false;

	public bool isInPrestige => false;

	public bool isInPrestigeAndActive => false;

	public int level
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public long dailyLimitProgress
	{
		get
		{
			return 0L;
		}
		set
		{
		}
	}

	public long dailyLimit => 0L;

	public bool isDailyLimitReached => false;

	public bool isLevelUp
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int maxDisplayLevel => 0;

	public bool isMaxLevel => false;

	public Prestige levelsSheet => null;

	public LIJMHGDJLKO currentLevel => null;

	public LIJMHGDJLKO nextLevel => null;

	public LIJMHGDJLKO previousLevel => null;

	public int gainedPrestige
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public static event Action LevelUp
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

	public void Init()
	{
	}

	protected override void Awake()
	{
	}

	private void LLJGFMOCLDG()
	{
	}

	public float GetPlayerHP(int MDKDHDFAFPH)
	{
		return 0f;
	}

	public float GetShieldHP(int MDKDHDFAFPH)
	{
		return 0f;
	}

	public void LoadData(JToken FIMDMKAOBGJ)
	{
	}

	private LIJMHGDJLKO DKEMLPABPPF(int AJMAKPNDFLB)
	{
		return null;
	}

	public float GetProgress()
	{
		return 0f;
	}

	public float GetDailyProgress()
	{
		return 0f;
	}

	public long GetRemainingPXP()
	{
		return 0L;
	}

	public void PrestigeTutorialShown()
	{
	}
}
