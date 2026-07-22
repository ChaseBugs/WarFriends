using System;
using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;
using WarFriends.Legacy;

public class StarterAssignmentsManager : DatabaseSerializedObjectGeneric<StarterAssignmentsManager.StarterAssignmentsData>
{
	public class StarterAssignmentsData
	{
		public class StarterAssignmentData
		{
			public bool completed;

			public bool claimed;
		}

		public int deadline;

		public Dictionary<string, StarterAssignmentData> assignments = new Dictionary<string, StarterAssignmentData>();
	}

	private static StarterAssignmentsManager mInstance;

	private StarterAssignments mAssignmentsXls;

	private List<StarterAssignment> mAssignments = new List<StarterAssignment>
	{
		new StarterAssignmentWinPVPBattle(),
		new StarterAssignmentDeployUnit(),
		new StarterAssignmentPlayWarcard(),
		new StarterAssignmentGainWeeklyMedals(),
		new StarterAssignmentReachRankFifth(),
		new StarterAssignmentWinMissionFirst(),
		new StarterAssignmentUpgradeWeapon(),
		new StarterAssignmentCraftCard(),
		new StarterAssignmentReachRankSix(),
		new StarterAssignmentGetSquadPoint()
	};

	public static StarterAssignmentsManager instance
	{
		get
		{
			mInstance = mInstance ?? ((StarterAssignmentsManager)SingletonSupport.FindOrCreate(typeof(StarterAssignmentsManager)));
			return mInstance;
		}
	}

	public List<StarterAssignment> assignments => mAssignments;

	public StarterAssignment currentAssignment
	{
		get
		{
			foreach (StarterAssignment assignment in assignments)
			{
				if (!assignment.claimed)
				{
					return assignment;
				}
			}
			return null;
		}
	}

	public bool isActive => data.deadline > Singleton<BeanstalkServerManager>.instance.currentTimestamp;

	public bool isAllCompleted => assignments.Count != 0 && assignments[assignments.Count - 1].claimed;

	public bool isActiveAndNotCompleted => isActive && !isAllCompleted;

	public bool isWBReward => isActiveAndNotCompleted && currentAssignment.rewardWB > 0;

	public int assignmentsCount => assignments.Count;

	public int remainingTime => Mathf.Max(data.deadline - Singleton<BeanstalkServerManager>.instance.currentTimestamp, 0);

	public event Action AssignmentClaimed;

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OnPlayerDataLoaded;
		mAssignmentsXls = GetComponent<StarterAssignments>();
	}

	private void OnPlayerDataLoaded()
	{
		foreach (StarterAssignment assignment in assignments)
		{
			assignment.Init(mAssignmentsXls.GetRow(assignment.id));
		}
		assignments.Sort((StarterAssignment a, StarterAssignment b) => a.order.CompareTo(b.order));
	}

	public StarterAssignmentsData.StarterAssignmentData GetAssignmentData(string id)
	{
		if (data.assignments.TryGetValue(id, out var value))
		{
			return value;
		}
		value = new StarterAssignmentsData.StarterAssignmentData();
		data.assignments[id] = value;
		return value;
	}

	public void Evaluate()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded || Singleton<BeanstalkServerManager>.instance.currentTimestamp > data.deadline)
		{
			return;
		}
		bool nPJDIMACCIL = false;
		try
		{
			List<string> list = new List<string>();
			foreach (StarterAssignment assignment in assignments)
			{
				bool flag = assignment.Evaluate();
				if (!assignment.completed || !assignment.claimed)
				{
					nPJDIMACCIL = true;
				}
				if (flag)
				{
					list.Add(assignment.id);
					Singleton<EventTrackingManager>.instance.GKDGINEBLFD(assignment, nPJDIMACCIL);
				}
			}
			if (list.Count > 0)
			{
				MEJMLNDFDBP.KLPJPNGMBMI(list, "FinishedAssignments:");
				Singleton<BeanstalkServerManager>.instance.PMOJKOPHHEL(list);
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	internal void LoadData(string assignmentData)
	{
		Debug.Log("Load assignments:\n" + assignmentData);
		SerializedObject = JsonConvert.DeserializeObject<StarterAssignmentsData>(assignmentData);
		OnPlayerDataLoaded();
	}

	public void StarterAssignmentClaimed()
	{
		if (this.AssignmentClaimed != null)
		{
			this.AssignmentClaimed();
		}
	}
}
