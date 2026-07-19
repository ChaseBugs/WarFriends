using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public abstract class EventAssignment
{
	private EventAssignmentConfig mConfig;

	public GameReward reward { get; private set; }

	public int eventPointsReward
	{
		get
		{
			return mConfig.eventPointsReward;
		}
	}

	public int currentValue
	{
		get
		{
			return mData.value;
		}
	}

	public int totalValue
	{
		get
		{
			return mConfig.target;
		}
	}

	public virtual string text
	{
		get
		{
			return string.Empty;
		}
	}

	public virtual string iconName
	{
		get
		{
			return "menu-event-gift";
		}
	}

	public virtual Color assignmentColor
	{
		get
		{
			return Colours.winterEventBlue;
		}
	}

	public virtual string dayBackground
	{
		get
		{
			return "menu-event-day-bg";
		}
	}

	public int remainingTime
	{
		get
		{
			return Singleton<BeanstalkServerManager>.instance.midnight - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}
	}

	public float progress
	{
		get
		{
			return Mathf.Clamp01((float)currentValue / (float)totalValue);
		}
	}

	public string progressString
	{
		get
		{
			return string.Format("{0} {1}/[-] {2}", MEJMLNDFDBP.GMIPFLIEOHD(currentValue), Colours.stringGrayDark, MEJMLNDFDBP.GMIPFLIEOHD(totalValue));
		}
	}

	public bool completed
	{
		get
		{
			return currentValue >= totalValue;
		}
	}

	public bool claimed
	{
		get
		{
			return mData.claimed;
		}
	}

	private EventAssignmentManager.EventAssignmentProgress mData
	{
		get
		{
			int currentDayIndex = EventAssignmentManager.instance.currentDayIndex;
			if (!EventAssignmentManager.instance.data.progress.ContainsKey(currentDayIndex))
			{
				Debug.LogFormat("#VOJTA# Empty event assignment progress for day {0}, index {1}", currentDayIndex + 1, currentDayIndex);
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
			GameRewardPlayerVisual gameRewardPlayerVisual = currentMilestone.Value2 as GameRewardPlayerVisual;
			string value = ((gameRewardPlayerVisual != null) ? gameRewardPlayerVisual.visual.id : string.Empty);
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
