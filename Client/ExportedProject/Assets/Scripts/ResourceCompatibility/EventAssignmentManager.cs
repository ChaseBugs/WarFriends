using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Scripting;

public class EventAssignmentManager : DatabaseSerializedObjectGeneric<EventAssignmentManager.EventAssignmentData>
{
	[Serializable]
	[Preserve]
	public class EventAssignmentData
	{
		public string eventId;

		public int totalValue;

		public Dictionary<int, EventAssignmentProgress> progress;

		public Dictionary<int, bool> milestones;
	}

	[Serializable]
	[Preserve]
	public class EventAssignmentProgress
	{
		[JsonProperty]
		public int value;

		[JsonProperty]
		public bool claimed;
	}

	private sealed class AJBAGAMIPGG
	{
		public string GNIGACIKDJD;

		internal bool IGIKNBNBJNJ(EventAssignment CLMNCBPINKO)
		{
			return false;
		}

		internal bool IECOCOCJMKB(Tuple<int, GameReward> CLMNCBPINKO)
		{
			return false;
		}
	}

	private static EventAssignmentManager DJDBDKFAKHN;

	[CompilerGenerated]
	private Action<int> ICGMMMNLNCK;

	[CompilerGenerated]
	private Action ANEPPAPCIPP;

	[CompilerGenerated]
	private EventAssignmentsConfig _003CGLFMEBEGLLG_003Ek__BackingField;

	[CompilerGenerated]
	private List<EventAssignment> _003CHFFCNAHBLAD_003Ek__BackingField;

	[CompilerGenerated]
	private List<Tuple<int, GameReward>> _003CIMHMANJFIGA_003Ek__BackingField;

	public APOHBFICGML FADFJLGPHJJ;

	[CompilerGenerated]
	private int _003CJABHOOEHEID_003Ek__BackingField;

	private bool ENJGBPDHAGF;

	[CompilerGenerated]
	private Action<string> HBONHFONMJF;

	private static readonly Dictionary<string, Type> NHOKIDEIAIP;

	public static EventAssignmentManager instance => null;

	public EventAssignmentsConfig config
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

	public List<EventAssignment> assignments
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

	public List<Tuple<int, GameReward>> milestones
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

	public int currentDayIndex => 0;

	public int currentDayNumber => 0;

	public int lastDayNumber
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public bool isLastDay => false;

	private List<EventAssignment> IOKOIOKMMMN => null;

	public bool isEventActive => false;

	private bool LDCKJMPIBFD => false;

	private bool MCJLPNLNHDI => false;

	private bool CKAKJINBANJ => false;

	public bool isEventShowableInGui => false;

	public bool isEventShowableEarly => false;

	private int DPEJFFCCDFO => 0;

	private int JLIEGCKFKGC => 0;

	private int CJNKJEBNJDP => 0;

	private int NKAICIAJFIB => 0;

	public int endEventShowTime => 0;

	public int beforeEventShowTime => 0;

	public int remainigTimeTillEnd => 0;

	public int remainingTimeTillStart => 0;

	public int value => 0;

	public int maxValue => 0;

	public float progress => 0f;

	public Tuple<int, GameReward> currentMilestone => null;

	public int currentMilestoneIndex => 0;

	public ReadOnlyCollection<EventAssignment> currentAssignments => null;

	public bool hasCurrentAssignments => false;

	public int remainingTime => 0;

	public bool currentAssignmentsCompleted => false;

	public bool currentAssignmentsClaimed => false;

	public event Action<int> EventAssignmentClaimed
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

	public event Action UpdateEventLook
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

	public event Action<string> EventSmallTextureReadyToLoad
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

	protected override void Load(JToken FIMDMKAOBGJ)
	{
	}

	public void SetCurrentMilestoneClaimed()
	{
	}

	public void EventClaimed(int FJGJIIPMGAF)
	{
	}

	public bool EventHasShield(string GNIGACIKDJD)
	{
		return false;
	}

	protected override void Awake()
	{
	}

	public void CheckToShowDialog()
	{
	}

	public void UpdateEventData()
	{
	}

	private void KLLMIABAAPC()
	{
	}

	private bool NEKEGFAGGGB()
	{
		return false;
	}

	private bool NIDBDHBBOPE()
	{
		return false;
	}

	private void Update()
	{
	}

	public Dictionary<int, int> EvaluateAssignments()
	{
		return null;
	}

	public void RevertMatch()
	{
	}

	internal void JGHFJDFCNBA(string MCKBBCFJDOC)
	{
	}

	private void NJLHGFAPLHG(string EMMJLKILDLG)
	{
	}

	public void FreeTexture(string EMMJLKILDLG)
	{
	}

	public void RequestTexture(string EBGFJGDDPGC, string EMMJLKILDLG)
	{
	}

	public Texture2D GetTexture(string EMMJLKILDLG)
	{
		return null;
	}
}
