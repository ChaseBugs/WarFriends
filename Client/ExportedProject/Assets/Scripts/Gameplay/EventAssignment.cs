using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

public abstract class EventAssignment
{
	private EventAssignmentConfig mConfig;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private GameReward _003Creward_003Ek__BackingField;

	public GameReward reward
	{
		[CompilerGenerated]
		get
		{
			return _003Creward_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003Creward_003Ek__BackingField = value;
		}
	}

	public int eventPointsReward => mConfig.eventPointsReward;

	public int currentValue => mData.value;

	public int totalValue => mConfig.target;

	public virtual string text => string.Empty;

	public virtual string iconName => "menu-event-gift";

	public virtual Color assignmentColor => Colours.winterEventBlue;

	public virtual string dayBackground => "menu-event-day-bg";

	public int remainingTime => Singleton<BeanstalkServerManager>.instance.midnight - Singleton<BeanstalkServerManager>.instance.currentTimestamp;

	public float progress => Mathf.Clamp01((float)currentValue / (float)totalValue);

	public string progressString => $"{MEJMLNDFDBP.GMIPFLIEOHD(currentValue)} {Colours.stringGrayDark}/[-] {MEJMLNDFDBP.GMIPFLIEOHD(totalValue)}";

	public bool completed => currentValue >= totalValue;

	public bool claimed => mData.claimed;

	private EventAssignmentManager.EventAssignmentProgress mData
	{
		get
		{
			int currentDayIndex = EventAssignmentManager.instance.currentDayIndex;
			if (!EventAssignmentManager.instance.data.progress.ContainsKey(currentDayIndex))
			{
				UnityEngine.Debug.LogFormat("#VOJTA# Empty event assignment progress for day {0}, index {1}", currentDayIndex + 1, currentDayIndex);
				EventAssignmentManager.instance.data.progress[currentDayIndex] = new EventAssignmentManager.EventAssignmentProgress();
			}
			return EventAssignmentManager.instance.data.progress[currentDayIndex];
		}
	}

	public void Init(EventAssignmentConfig config)
	{
		mConfig = config;
		reward = GameReward.OMDNNCPJLGE(mConfig.reward);
	}

	public void Claim()
	{
		mData.claimed = true;
		reward.HIECGLCKNCA();
		EventAssignmentManager.instance.data.totalValue += eventPointsReward;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("RewardType", reward.id);
		dictionary.Add("RewardValue", reward.amount);
		string objData = JsonConvert.SerializeObject(dictionary);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.ClaimEventAssignment, objData, 0, 0, string.Empty);
		Tuple<int, GameReward> currentMilestone = EventAssignmentManager.instance.currentMilestone;
		if (currentMilestone != null && currentMilestone.Value1 <= EventAssignmentManager.instance.value)
		{
			int currentMilestoneIndex = EventAssignmentManager.instance.currentMilestoneIndex;
			string value = ((currentMilestone.Value2 is GameRewardPlayerVisual gameRewardPlayerVisual) ? gameRewardPlayerVisual.visual.id : string.Empty);
			currentMilestone.Value2.HIECGLCKNCA();
			EventAssignmentManager.instance.SetCurrentMilestoneClaimed();
			dictionary = new Dictionary<string, object>();
			dictionary.Add("MilestoneId", currentMilestoneIndex);
			dictionary.Add("RewardValue", value);
			string objData2 = JsonConvert.SerializeObject(dictionary);
			requestBuffer.AddRequest(DatabaseAction.ClaimEventMilestone, objData2, 0, 0, string.Empty);
		}
		Singleton<EventTrackingManager>.instance.ClaimEventAssignment(EventAssignmentManager.instance.currentDayIndex);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.AssigmentCompleted);
		EventAssignmentManager.instance.EventClaimed();
	}

	public abstract int Update();
}
