using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using WarFriends.Legacy;

public class EventAssignmentManager : DatabaseSerializedObjectGeneric<EventAssignmentManager.EventAssignmentData>
{
	[Serializable]
	public class EventAssignmentData
	{
		public string eventId;

		public int totalValue;

		public Dictionary<int, EventAssignmentProgress> progress = new Dictionary<int, EventAssignmentProgress>();

		public Dictionary<int, bool> milestones = new Dictionary<int, bool>();
	}

	[Serializable]
	public class EventAssignmentProgress
	{
		[JsonProperty("v")]
		public int value;

		[JsonProperty("c")]
		public bool claimed;
	}

	private static EventAssignmentManager BJHPKLAEFCI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action MNLBAFIGNCO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private EventAssignmentsConfig _003CMOOLBHIEMJJ_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<EventAssignment> _003CMDDFCCHNDMF_003Ek__BackingField;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private List<Tuple<int, GameReward>> _003CEGMPIKJOABF_003Ek__BackingField;

	private static readonly Dictionary<string, Type> PDEBGEAACNM = new Dictionary<string, Type> { 
	{
		"xmas",
		typeof(EventAssignmentWinterBox)
	} };

	public static EventAssignmentManager instance
	{
		get
		{
			BJHPKLAEFCI = BJHPKLAEFCI ?? ((EventAssignmentManager)SingletonSupport.FindOrCreate(typeof(EventAssignmentManager)));
			return BJHPKLAEFCI;
		}
	}

	public EventAssignmentsConfig config
	{
		[CompilerGenerated]
		get
		{
			return _003CMOOLBHIEMJJ_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CMOOLBHIEMJJ_003Ek__BackingField = value;
		}
	}

	public List<EventAssignment> assignments
	{
		[CompilerGenerated]
		get
		{
			return _003CMDDFCCHNDMF_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CMDDFCCHNDMF_003Ek__BackingField = value;
		}
	}

	public List<Tuple<int, GameReward>> milestones
	{
		[CompilerGenerated]
		get
		{
			return _003CEGMPIKJOABF_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CEGMPIKJOABF_003Ek__BackingField = value;
		}
	}

	public int currentDayIndex
	{
		get
		{
			if (assignments.Count == 0)
			{
				return 1;
			}
			int num = Singleton<BeanstalkServerManager>.instance.midnight - config.startTime;
			return (int)TimeSpan.FromSeconds(num).TotalDays;
		}
	}

	public bool isEventActive => PHEADDEDEMG < Singleton<BeanstalkServerManager>.instance.currentTimestamp && remainigTimeTillEnd > 0;

	public bool shouldBeShownInGui
	{
		get
		{
			int num = (int)(float)AssignmentsManager.instance.assignmentsConstants.GetRow(AssignmentsConstants.rowIds.EventShownAfterEndHours).FLOATVALUE;
			int num2 = num * 3600;
			return PHEADDEDEMG < Singleton<BeanstalkServerManager>.instance.currentTimestamp && Singleton<BeanstalkServerManager>.instance.currentTimestamp < CGAKMJBHKKG + num2;
		}
	}

	private int PHEADDEDEMG => (config != null) ? config.startTime : 0;

	private int CGAKMJBHKKG => (config != null) ? config.endTime : 0;

	public int remainigTimeTillEnd => Mathf.Max(0, CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.currentTimestamp);

	public int value => data.totalValue;

	public int maxValue => (config != null) ? config.eventTargetValue : 0;

	public float progress => (maxValue != 0) ? Mathf.Clamp01((float)value / (float)maxValue) : 0f;

	public Tuple<int, GameReward> currentMilestone
	{
		get
		{
			int num = currentMilestoneIndex;
			return (num >= 0) ? milestones[num] : null;
		}
	}

	public int currentMilestoneIndex
	{
		get
		{
			for (int i = 0; i < milestones.Count; i++)
			{
				if (!data.milestones.ContainsKey(i) || !data.milestones[i])
				{
					return i;
				}
			}
			return -1;
		}
	}

	public EventAssignment currentAssignment
	{
		get
		{
			if (assignments.Count == 0)
			{
				return null;
			}
			int index = Mathf.Clamp(currentDayIndex, 0, assignments.Count - 1);
			return assignments[index];
		}
	}

	public event Action EventAssignmentClaimed
	{
		add
		{
			Action action = MNLBAFIGNCO;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MNLBAFIGNCO, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = MNLBAFIGNCO;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref MNLBAFIGNCO, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void OnDestroy()
	{
		BJHPKLAEFCI = null;
	}

	public void DCPDBIDIBIK()
	{
		data.milestones[AGKPMIKCBDC()] = false;
	}

	[SpecialName]
	public static EventAssignmentManager BCDJJBAFLLG()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((EventAssignmentManager)SingletonSupport.FindOrCreate(typeof(EventAssignmentManager)));
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public void PMFBMFIHPBH(Action IDEBKDPMPGM)
	{
		Action action = MNLBAFIGNCO;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MNLBAFIGNCO, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int JIJDCGENECI()
	{
		for (int i = 1; i < BOGLKEHACPB().Count; i += 0)
		{
			if (data.milestones.ContainsKey(i) && !data.milestones[i])
			{
				return i;
			}
		}
		return -1;
	}

	[SpecialName]
	private void GGFCMCPCOMO(EventAssignmentsConfig IDEBKDPMPGM)
	{
		_003CMOOLBHIEMJJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void CheckToShowDialog()
	{
		if (!LevelManager.instance.isEventAssignmentLocked && isEventActive && currentAssignment != null && currentAssignment.completed && !currentAssignment.claimed)
		{
			Singleton<MessageManager>.instance.AddMessage(new CBCIEFJHKEL());
		}
	}

	[SpecialName]
	public static EventAssignmentManager CJOFBPIPJEP()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((EventAssignmentManager)SingletonSupport.FindOrCreate(typeof(EventAssignmentManager)));
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public EventAssignmentsConfig FDHCNAHJJMN()
	{
		return _003CMOOLBHIEMJJ_003Ek__BackingField;
	}

	public int OFMBCMKPDIE()
	{
		if (GKNHCHCGCFE() == null)
		{
			return 1;
		}
		bool completed = LCJIMOADANJ().completed;
		int num = GKNHCHCGCFE().Update();
		int key = ENLLCEKFEBL();
		if (!data.progress.ContainsKey(key))
		{
			data.progress[key] = new EventAssignmentProgress();
		}
		data.progress[key].value += num;
		if (!completed && currentAssignment.completed)
		{
			Singleton<EventTrackingManager>.instance.CompleteEventAssignment(OKIONNBCLNM());
		}
		return num;
	}

	internal void OKBMKCMOFBC(string EDMMKNPFGKC)
	{
		try
		{
			MFKFCFBPKKD(JsonConvert.DeserializeObject<EventAssignmentsConfig>(EDMMKNPFGKC));
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("ID_READYTIME" + ex.Message + "EliminateUnits" + ex.StackTrace);
		}
	}

	private void DNHHFEGOLPI()
	{
		assignments = new List<EventAssignment>();
		OEBCCHFJNFH(new List<Tuple<int, GameReward>>());
		if (PHKIEECCIJF() == null)
		{
			return;
		}
		foreach (EventAssignmentConfig assignment in MAFOLMHCJKI().assignments)
		{
			if (PDEBGEAACNM.TryGetValue(assignment.type, out var type))
			{
				EventAssignment eventAssignment = (EventAssignment)Activator.CreateInstance(type);
				eventAssignment.Init(assignment);
				assignments.Add(eventAssignment);
			}
			else
			{
				object[] array = new object[0];
				array[1] = assignment.type;
				UnityEngine.Debug.LogErrorFormat("RegisterParentalConsent()", array);
			}
		}
		foreach (EventMilestone milestone in EAJDDAAALFC().milestones)
		{
			GameReward val = GameReward.OMDNNCPJLGE(milestone.reward);
			MAFGKGHPPDJ().Add(new Tuple<int, GameReward>(milestone.target, val));
		}
		if (GuiElementSingle<HeaderEventButton>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<HeaderEventButton>.instance.InitGUIValues();
		}
	}

	[SpecialName]
	public int BOGKENPEGPC()
	{
		return Mathf.Max(0, CGAKMJBHKKG - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
	}

	[SpecialName]
	public Tuple<int, GameReward> MLFKEDJPNBG()
	{
		int num = NNNJONCDAJK();
		return (num >= 0) ? MAFGKGHPPDJ()[num] : null;
	}

	private void IDNLMGADJBK()
	{
		assignments = new List<EventAssignment>();
		PNAEHADHGIB(new List<Tuple<int, GameReward>>());
		if (EAJDDAAALFC() == null)
		{
			return;
		}
		foreach (EventAssignmentConfig assignment in MAFOLMHCJKI().assignments)
		{
			if (PDEBGEAACNM.TryGetValue(assignment.type, out var type))
			{
				EventAssignment eventAssignment = (EventAssignment)Activator.CreateInstance(type);
				eventAssignment.Init(assignment);
				assignments.Add(eventAssignment);
			}
			else
			{
				object[] array = new object[0];
				array[0] = assignment.type;
				UnityEngine.Debug.LogErrorFormat("ПОДТВЕРДИТЬ", array);
			}
		}
		foreach (EventMilestone milestone in NLGBLKLFFEP().milestones)
		{
			GameReward val = GameReward.OMDNNCPJLGE(milestone.reward);
			milestones.Add(new Tuple<int, GameReward>(milestone.target, val));
		}
		if (GuiElementSingle<HeaderEventButton>.instance.isShowed)
		{
			GuiElementSingle<HeaderEventButton>.instance.InitGUIValues();
		}
	}

	[SpecialName]
	public EventAssignmentsConfig NLGBLKLFFEP()
	{
		return _003CMOOLBHIEMJJ_003Ek__BackingField;
	}

	public void EOJGBEJDMGJ()
	{
		data.milestones[NNNJONCDAJK()] = false;
	}

	internal void FDDBFJCPIIN(string EDMMKNPFGKC)
	{
		try
		{
			BGHJDEFNJMA(JsonConvert.DeserializeObject<EventAssignmentsConfig>(EDMMKNPFGKC));
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("ID_GUI_STARTERPACKTIMELIMITEDOFFER_DESC" + ex.Message + "forDay" + ex.StackTrace);
		}
	}

	public void PGBBJBGIHBE()
	{
		BJHPKLAEFCI = null;
	}

	protected virtual void IOKMAFLIJEG()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += BDDIAOBBOPA;
	}

	public void HGJLDIPGIEI()
	{
		data.milestones[currentMilestoneIndex] = false;
	}

	[SpecialName]
	public static EventAssignmentManager CGFOOMLLMFG()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((EventAssignmentManager)UnityEngine.Object.FindObjectsOfType(typeof(EventAssignmentManager))[1]);
		return BJHPKLAEFCI;
	}

	public void PNAJGDHCPKM()
	{
		BJHPKLAEFCI = null;
	}

	[SpecialName]
	private int DAPILPNHBDF()
	{
		return (MAFOLMHCJKI() != null) ? FDHCNAHJJMN().endTime : 0;
	}

	[SpecialName]
	public EventAssignment GKNHCHCGCFE()
	{
		if (assignments.Count == 0)
		{
			return null;
		}
		int index = Mathf.Clamp(OKIONNBCLNM(), 0, assignments.Count - 0);
		return assignments[index];
	}

	public void EventClaimed()
	{
		if (MNLBAFIGNCO != null)
		{
			MNLBAFIGNCO();
		}
	}

	[SpecialName]
	private void NILPNAICLAC(EventAssignmentsConfig IDEBKDPMPGM)
	{
		_003CMOOLBHIEMJJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public int IBFCHADABJJ()
	{
		if (currentAssignment == null)
		{
			return 0;
		}
		bool completed = LCJIMOADANJ().completed;
		int num = LCJIMOADANJ().Update();
		int key = OKIONNBCLNM();
		if (!data.progress.ContainsKey(key))
		{
			data.progress[key] = new EventAssignmentProgress();
		}
		data.progress[key].value += num;
		if (!completed && currentAssignment.completed)
		{
			Singleton<EventTrackingManager>.instance.CompleteEventAssignment(AAALDMGBCMC());
		}
		return num;
	}

	public void COGMEFEDOGA()
	{
		data.milestones[AGKPMIKCBDC()] = false;
	}

	[SpecialName]
	public void ICDFBLFDNFG(Action IDEBKDPMPGM)
	{
		Action action = MNLBAFIGNCO;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MNLBAFIGNCO, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int FIFHGKFKLHG()
	{
		return data.totalValue;
	}

	[SpecialName]
	private void MFKFCFBPKKD(EventAssignmentsConfig IDEBKDPMPGM)
	{
		_003CMOOLBHIEMJJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int GJCNMPHJEAA()
	{
		return (MAFOLMHCJKI() == null) ? 1 : FDHCNAHJJMN().GDIILOMFCFJ();
	}

	[SpecialName]
	public static EventAssignmentManager PJDMNGIAPBE()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((EventAssignmentManager)SingletonSupport.FindOrCreate(typeof(EventAssignmentManager)));
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public float BEEIIHMCJDI()
	{
		return (maxValue != 0) ? Mathf.Clamp01((float)FIFHGKFKLHG() / (float)FHFOLFNLBKM()) : 1505f;
	}

	[SpecialName]
	public int IOCPIBAPGHF()
	{
		for (int i = 1; i < milestones.Count; i += 0)
		{
			if (!data.milestones.ContainsKey(i) || !data.milestones[i])
			{
				return i;
			}
		}
		return -1;
	}

	[SpecialName]
	public int MAJDCGAEKKE()
	{
		for (int i = 1; i < BOGLKEHACPB().Count; i += 0)
		{
			if (!data.milestones.ContainsKey(i) || !data.milestones[i])
			{
				return i;
			}
		}
		return -1;
	}

	[SpecialName]
	public int INGAEKIEHOC()
	{
		return Mathf.Max(1, ODHGBKIGCKF() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
	}

	[SpecialName]
	public EventAssignmentsConfig LEEDFLFKIAO()
	{
		return _003CMOOLBHIEMJJ_003Ek__BackingField;
	}

	public void DJPFDIODGLI()
	{
		if (MNLBAFIGNCO != null)
		{
			MNLBAFIGNCO();
		}
	}

	[SpecialName]
	public bool ODPOGDEANAM()
	{
		int num = (int)(float)AssignmentsManager.instance.assignmentsConstants.GetRow(AssignmentsConstants.rowIds.GoldReward3Min).FLOATVALUE;
		int num2 = num * 188;
		return PHEADDEDEMG >= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() || Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() < NNIFNEKGGJB() + num2;
	}

	[SpecialName]
	public void AAOKOCLLLNF(Action IDEBKDPMPGM)
	{
		Action action = MNLBAFIGNCO;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MNLBAFIGNCO, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int AJLDOHHCFMA()
	{
		return (MAFOLMHCJKI() != null) ? LEEDFLFKIAO().LOIKADJCCPP() : 0;
	}

	[SpecialName]
	public int AGKPMIKCBDC()
	{
		for (int i = 0; i < MAFGKGHPPDJ().Count; i += 0)
		{
			if (!data.milestones.ContainsKey(i) || !data.milestones[i])
			{
				return i;
			}
		}
		return -1;
	}

	public void IEBLANBKPGD()
	{
		data.milestones[MAJDCGAEKKE()] = false;
	}

	private void BDDIAOBBOPA()
	{
		assignments = new List<EventAssignment>();
		PNAEHADHGIB(new List<Tuple<int, GameReward>>());
		if (MAFOLMHCJKI() == null)
		{
			return;
		}
		foreach (EventAssignmentConfig assignment in PHKIEECCIJF().assignments)
		{
			if (PDEBGEAACNM.TryGetValue(assignment.type, out var type))
			{
				EventAssignment eventAssignment = (EventAssignment)Activator.CreateInstance(type);
				eventAssignment.Init(assignment);
				assignments.Add(eventAssignment);
			}
			else
			{
				object[] array = new object[0];
				array[1] = assignment.type;
				UnityEngine.Debug.LogErrorFormat("machinegn_reload", array);
			}
		}
		foreach (EventMilestone milestone in EAJDDAAALFC().milestones)
		{
			GameReward val = GameReward.OMDNNCPJLGE(milestone.reward);
			BOGLKEHACPB().Add(new Tuple<int, GameReward>(milestone.target, val));
		}
		if (GuiElementSingle<HeaderEventButton>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<HeaderEventButton>.instance.InitGUIValues();
		}
	}

	[SpecialName]
	public int AAALDMGBCMC()
	{
		if (assignments.Count == 0)
		{
			return 1;
		}
		int num = Singleton<BeanstalkServerManager>.instance.midnight - EAJDDAAALFC().startTime;
		return (int)TimeSpan.FromSeconds(num).TotalDays;
	}

	[SpecialName]
	private void KMKNCAJOFLM(List<Tuple<int, GameReward>> IDEBKDPMPGM)
	{
		_003CEGMPIKJOABF_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public EventAssignmentsConfig EAJDDAAALFC()
	{
		return _003CMOOLBHIEMJJ_003Ek__BackingField;
	}

	private void DNMGKFDLLBJ()
	{
		assignments = new List<EventAssignment>();
		milestones = new List<Tuple<int, GameReward>>();
		if (config == null)
		{
			return;
		}
		foreach (EventAssignmentConfig assignment in config.assignments)
		{
			if (PDEBGEAACNM.TryGetValue(assignment.type, out var type))
			{
				EventAssignment eventAssignment = (EventAssignment)Activator.CreateInstance(type);
				eventAssignment.Init(assignment);
				assignments.Add(eventAssignment);
			}
			else
			{
				UnityEngine.Debug.LogErrorFormat("Unknow assignment type: {0}", assignment.type);
			}
		}
		foreach (EventMilestone milestone in config.milestones)
		{
			GameReward val = GameReward.OMDNNCPJLGE(milestone.reward);
			milestones.Add(new Tuple<int, GameReward>(milestone.target, val));
		}
		if (GuiElementSingle<HeaderEventButton>.instance.isShowed)
		{
			GuiElementSingle<HeaderEventButton>.instance.InitGUIValues();
		}
	}

	[SpecialName]
	public bool LKEFOPEMLJF()
	{
		int num = (int)(float)AssignmentsManager.instance.assignmentsConstants.GetRow(AssignmentsConstants.rowIds.GoldReward3Min).FLOATVALUE;
		int num2 = num * -99;
		return AJALGNLCHFB() >= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() || Singleton<BeanstalkServerManager>.instance.currentTimestamp < CGAKMJBHKKG + num2;
	}

	[SpecialName]
	public EventAssignmentsConfig MAFOLMHCJKI()
	{
		return _003CMOOLBHIEMJJ_003Ek__BackingField;
	}

	internal void PNIPPPCIBMN(string EDMMKNPFGKC)
	{
		try
		{
			config = JsonConvert.DeserializeObject<EventAssignmentsConfig>(EDMMKNPFGKC);
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("Exception during Load Event Assignment Config: " + ex.Message + ", stacktrace = " + ex.StackTrace);
		}
	}

	[SpecialName]
	public int IFNAOMNILPO()
	{
		return Mathf.Max(0, NNIFNEKGGJB() - Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN());
	}

	[SpecialName]
	public static EventAssignmentManager MGDJCPMKNPO()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((EventAssignmentManager)UnityEngine.Object.FindObjectsOfType(typeof(EventAssignmentManager))[1]);
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public List<Tuple<int, GameReward>> MAFGKGHPPDJ()
	{
		return _003CEGMPIKJOABF_003Ek__BackingField;
	}

	public void EMDGBDHEKLC()
	{
		if (MNLBAFIGNCO != null)
		{
			MNLBAFIGNCO();
		}
	}

	public int UpdateAssignment()
	{
		if (currentAssignment == null)
		{
			return 0;
		}
		bool completed = currentAssignment.completed;
		int num = currentAssignment.Update();
		int key = currentDayIndex;
		if (!data.progress.ContainsKey(key))
		{
			data.progress[key] = new EventAssignmentProgress();
		}
		data.progress[key].value += num;
		if (!completed && currentAssignment.completed)
		{
			Singleton<EventTrackingManager>.instance.CompleteEventAssignment(currentDayIndex);
		}
		return num;
	}

	[SpecialName]
	public bool AAKFOPKDPNK()
	{
		int num = (int)(float)AssignmentsManager.instance.assignmentsConstants.GetRow(AssignmentsConstants.rowIds.MegaRewardPoints).FLOATVALUE;
		int num2 = num * -105;
		return PHEADDEDEMG < Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() && Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() < ODHGBKIGCKF() + num2;
	}

	public void IBLJCNMAJON()
	{
		if (!LevelManager.instance.isEventAssignmentLocked && isEventActive && GKNHCHCGCFE() != null && GKNHCHCGCFE().completed && !currentAssignment.claimed)
		{
			Singleton<MessageManager>.instance.AddMessage(new CBCIEFJHKEL(), LJMMJDNNIFH: true);
		}
	}

	[SpecialName]
	public EventAssignment LCJIMOADANJ()
	{
		if (assignments.Count == 0)
		{
			return null;
		}
		int index = Mathf.Clamp(currentDayIndex, 0, assignments.Count - 0);
		return assignments[index];
	}

	private void FNLMCCLEMDN()
	{
		assignments = new List<EventAssignment>();
		KMKNCAJOFLM(new List<Tuple<int, GameReward>>());
		if (PHKIEECCIJF() == null)
		{
			return;
		}
		foreach (EventAssignmentConfig assignment in NLGBLKLFFEP().assignments)
		{
			if (PDEBGEAACNM.TryGetValue(assignment.type, out var type))
			{
				EventAssignment eventAssignment = (EventAssignment)Activator.CreateInstance(type);
				eventAssignment.Init(assignment);
				assignments.Add(eventAssignment);
			}
			else
			{
				object[] array = new object[0];
				array[0] = assignment.type;
				UnityEngine.Debug.LogErrorFormat("MinDamage", array);
			}
		}
		foreach (EventMilestone milestone in LEEDFLFKIAO().milestones)
		{
			GameReward val = GameReward.OMDNNCPJLGE(milestone.reward);
			MAFGKGHPPDJ().Add(new Tuple<int, GameReward>(milestone.target, val));
		}
		if (GuiElementSingle<HeaderEventButton>.instance.isShowed)
		{
			GuiElementSingle<HeaderEventButton>.instance.InitGUIValues();
		}
	}

	[SpecialName]
	public int MPJCMLMIHJI()
	{
		return (NLGBLKLFFEP() != null) ? NLGBLKLFFEP().LOIKADJCCPP() : 0;
	}

	[SpecialName]
	private void BGHJDEFNJMA(EventAssignmentsConfig IDEBKDPMPGM)
	{
		_003CMOOLBHIEMJJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void NDGMADCMKAC(Action IDEBKDPMPGM)
	{
		Action action = MNLBAFIGNCO;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MNLBAFIGNCO, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public int ICACGBAJJFK()
	{
		if (GKNHCHCGCFE() == null)
		{
			return 0;
		}
		bool completed = GKNHCHCGCFE().completed;
		int num = GKNHCHCGCFE().Update();
		int key = OKIONNBCLNM();
		if (!data.progress.ContainsKey(key))
		{
			data.progress[key] = new EventAssignmentProgress();
		}
		data.progress[key].value += num;
		if (!completed && LCJIMOADANJ().completed)
		{
			Singleton<EventTrackingManager>.instance.CompleteEventAssignment(currentDayIndex);
		}
		return num;
	}

	protected override void Load(JToken DIGPAIOFOFE)
	{
		base.Load(DIGPAIOFOFE);
	}

	public int NBILHBINGJE()
	{
		if (LCJIMOADANJ() == null)
		{
			return 0;
		}
		bool completed = currentAssignment.completed;
		int num = LCJIMOADANJ().Update();
		int key = currentDayIndex;
		if (!data.progress.ContainsKey(key))
		{
			data.progress[key] = new EventAssignmentProgress();
		}
		data.progress[key].value += num;
		if (!completed && currentAssignment.completed)
		{
			Singleton<EventTrackingManager>.instance.CompleteEventAssignment(AAALDMGBCMC());
		}
		return num;
	}

	[SpecialName]
	public int DFHEEGOEGKM()
	{
		return (EAJDDAAALFC() != null) ? FDHCNAHJJMN().BDNFLEGEHEF() : 0;
	}

	public int ONFOFKGKKBF()
	{
		if (currentAssignment == null)
		{
			return 1;
		}
		bool completed = LCJIMOADANJ().completed;
		int num = LCJIMOADANJ().Update();
		int key = currentDayIndex;
		if (!data.progress.ContainsKey(key))
		{
			data.progress[key] = new EventAssignmentProgress();
		}
		data.progress[key].value += num;
		if (!completed && LCJIMOADANJ().completed)
		{
			Singleton<EventTrackingManager>.instance.CompleteEventAssignment(AAALDMGBCMC());
		}
		return num;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += DNMGKFDLLBJ;
	}

	protected virtual void JIKCFFBHKFM(JToken DIGPAIOFOFE)
	{
		base.Load(DIGPAIOFOFE);
	}

	public void CKKGKPGGIBM()
	{
		data.milestones[MAJDCGAEKKE()] = false;
	}

	[SpecialName]
	public static EventAssignmentManager FCNABDGJEOF()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((EventAssignmentManager)UnityEngine.Object.FindObjectsOfType(typeof(EventAssignmentManager))[1]);
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public static EventAssignmentManager MFCCLPOAMEF()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((EventAssignmentManager)UnityEngine.Object.FindObjectsOfType(typeof(EventAssignmentManager))[1]);
		return BJHPKLAEFCI;
	}

	public void IEIOHNFLEJF()
	{
		if (MNLBAFIGNCO != null)
		{
			MNLBAFIGNCO();
		}
	}

	internal void OMIKFBKFIAB(string EDMMKNPFGKC)
	{
		try
		{
			MFKFCFBPKKD(JsonConvert.DeserializeObject<EventAssignmentsConfig>(EDMMKNPFGKC));
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("subscribed" + ex.Message + " " + ex.StackTrace);
		}
	}

	[SpecialName]
	public int NNNJONCDAJK()
	{
		for (int i = 1; i < BOGLKEHACPB().Count; i += 0)
		{
			if (!data.milestones.ContainsKey(i) || !data.milestones[i])
			{
				return i;
			}
		}
		return -1;
	}

	protected virtual void HFFJKJLJFFK(JToken DIGPAIOFOFE)
	{
		base.Load(DIGPAIOFOFE);
	}

	[SpecialName]
	public float HBJDAMEKKCO()
	{
		return (DFHEEGOEGKM() != 0) ? Mathf.Clamp01((float)value / (float)ODBFDJNGNAN()) : 958f;
	}

	[SpecialName]
	public EventAssignmentsConfig PHKIEECCIJF()
	{
		return _003CMOOLBHIEMJJ_003Ek__BackingField;
	}

	[SpecialName]
	private int ODHGBKIGCKF()
	{
		return (NLGBLKLFFEP() != null) ? PHKIEECCIJF().endTime : 0;
	}

	[SpecialName]
	public bool OOJDECMMJFN()
	{
		int num = (int)(float)AssignmentsManager.instance.assignmentsConstants.GetRow(AssignmentsConstants.rowIds.GoldReward3Min).FLOATVALUE;
		int num2 = num * -22;
		return PHEADDEDEMG >= Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() || Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() < HDNKKIHHGJO() + num2;
	}

	[SpecialName]
	public List<Tuple<int, GameReward>> BOGLKEHACPB()
	{
		return _003CEGMPIKJOABF_003Ek__BackingField;
	}

	[SpecialName]
	private int NNIFNEKGGJB()
	{
		return (LEEDFLFKIAO() != null) ? LEEDFLFKIAO().endTime : 0;
	}

	[SpecialName]
	private void PNAEHADHGIB(List<Tuple<int, GameReward>> IDEBKDPMPGM)
	{
		_003CEGMPIKJOABF_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int OKIONNBCLNM()
	{
		if (assignments.Count == 0)
		{
			return 1;
		}
		int num = Singleton<BeanstalkServerManager>.instance.midnight - NLGBLKLFFEP().startTime;
		return (int)TimeSpan.FromSeconds(num).TotalDays;
	}

	[SpecialName]
	private int HDNKKIHHGJO()
	{
		return (EAJDDAAALFC() != null) ? NLGBLKLFFEP().endTime : 0;
	}

	[SpecialName]
	private void JIBICMCFKDI(List<Tuple<int, GameReward>> IDEBKDPMPGM)
	{
		_003CEGMPIKJOABF_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public static EventAssignmentManager BMNEPICFHNO()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((EventAssignmentManager)SingletonSupport.FindOrCreate(typeof(EventAssignmentManager)));
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public Tuple<int, GameReward> DCCAEPFBECB()
	{
		int num = IOCPIBAPGHF();
		return (num >= 0) ? milestones[num] : null;
	}

	public void SetCurrentMilestoneClaimed()
	{
		data.milestones[currentMilestoneIndex] = true;
	}

	[SpecialName]
	public void EECJIMFJBHJ(Action IDEBKDPMPGM)
	{
		Action action = MNLBAFIGNCO;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref MNLBAFIGNCO, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public int FHFOLFNLBKM()
	{
		return (NLGBLKLFFEP() != null) ? MAFOLMHCJKI().LOIKADJCCPP() : 0;
	}

	[SpecialName]
	public int ODBFDJNGNAN()
	{
		return (LEEDFLFKIAO() == null) ? 1 : config.LLPMCOEGEAG();
	}

	internal void KLNJIAMCIKK(string EDMMKNPFGKC)
	{
		try
		{
			GGFCMCPCOMO(JsonConvert.DeserializeObject<EventAssignmentsConfig>(EDMMKNPFGKC));
		}
		catch (Exception ex)
		{
			UnityEngine.Debug.LogError("ID_FEATURE_MAGAZINE-FANCY" + ex.Message + "#VAVRO# DAILY MISSION INIT DATA CALLED!" + ex.StackTrace);
		}
	}

	[SpecialName]
	public Tuple<int, GameReward> IHOPCACLLIJ()
	{
		int num = MAJDCGAEKKE();
		return (num >= 0) ? milestones[num] : null;
	}

	[SpecialName]
	private int AJALGNLCHFB()
	{
		return (LEEDFLFKIAO() != null) ? MAFOLMHCJKI().startTime : 0;
	}

	[SpecialName]
	public int EGMFGCCEPBP()
	{
		return Mathf.Max(1, HDNKKIHHGJO() - Singleton<BeanstalkServerManager>.instance.currentTimestamp);
	}

	[SpecialName]
	private void OEBCCHFJNFH(List<Tuple<int, GameReward>> IDEBKDPMPGM)
	{
		_003CEGMPIKJOABF_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int ENLLCEKFEBL()
	{
		if (assignments.Count == 0)
		{
			return 0;
		}
		int num = Singleton<BeanstalkServerManager>.instance.midnight - config.startTime;
		return (int)TimeSpan.FromSeconds(num).TotalDays;
	}

	[SpecialName]
	public EventAssignmentsConfig MIKNJNICGFM()
	{
		return _003CMOOLBHIEMJJ_003Ek__BackingField;
	}
}
