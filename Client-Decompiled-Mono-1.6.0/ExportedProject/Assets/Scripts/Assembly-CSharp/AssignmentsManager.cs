using System;
using System.Collections.Generic;
using System.Globalization;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class AssignmentsManager : DatabaseSerializedObjectGeneric<AssignmentsManager.AssignmentData>
{
	public enum ADHPOEFKINO
	{
		Time = 0,
		Assignment = 1
	}

	public class AssignmentData
	{
		public List<DatabaseAssignment> assignments;

		public int tomorrow;

		public int completed;

		public int issued;

		[JsonProperty("megaReward")]
		public int megaRewardPointsProgress;

		public bool skipUsed;
	}

	public class DatabaseAssignment
	{
		public int id;

		public bool done;

		public bool claimed;

		public float completeFract;

		public float lastCompletedFract;

		public int target;

		public int secondTarget;

		public int tutorialId;

		public DatabaseAssignment(int assignmentId, int assignmentTarget)
		{
			id = assignmentId;
			target = assignmentTarget;
		}

		public string GetSecondTargetAsString()
		{
			TaskDefinitionsRow row = instance.taskDefinitions.GetRow("ID_" + id);
			if (string.IsNullOrEmpty(row.SECONDTARGETPARAMETER))
			{
				return null;
			}
			return secondTarget.ToString(CultureInfo.InvariantCulture);
		}
	}

	private static AssignmentsManager mInstance;

	private TaskDefinitions mTaskDefinitions;

	private List<Assignment> mPreparedAssignments = new List<Assignment>();

	public static AssignmentsManager instance
	{
		get
		{
			mInstance = mInstance ?? ((AssignmentsManager)UnityEngine.Object.FindObjectsOfType(typeof(AssignmentsManager))[0]);
			return mInstance;
		}
	}

	public AssignmentsConstants assignmentsConstants { get; private set; }

	public TaskDefinitions taskDefinitions
	{
		get
		{
			if (mTaskDefinitions == null)
			{
				mTaskDefinitions = GetComponent<TaskDefinitions>();
			}
			return mTaskDefinitions;
		}
	}

	public int timeUntilMidnight
	{
		get
		{
			if (data == null)
			{
				return -1;
			}
			return data.tomorrow - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		}
	}

	public static string blueProgressBar
	{
		get
		{
			return "menu-assignments-bar-blue";
		}
	}

	public static string redProgressBar
	{
		get
		{
			return "menu-assignments-bar-red";
		}
	}

	public static string goldProgressBar
	{
		get
		{
			return "menu-assignments-bar-gold";
		}
	}

	public int currentMegaRewardPoints
	{
		get
		{
			return (data != null) ? data.megaRewardPointsProgress : 0;
		}
		set
		{
			data.megaRewardPointsProgress = value;
		}
	}

	public int megaRewarPoints
	{
		get
		{
			return (int)(float)assignmentsConstants.GetRow(AssignmentsConstants.rowIds.MegaRewardPoints).FLOATVALUE;
		}
	}

	public float megaRewardProgress
	{
		get
		{
			return Mathf.Clamp01((float)currentMegaRewardPoints / (float)megaRewarPoints);
		}
	}

	public List<Assignment> currentAssignments
	{
		get
		{
			List<Assignment> list = new List<Assignment>();
			Array values = Enum.GetValues(typeof(Assignment.BIKGCLOFCFG));
			foreach (object item in values)
			{
				Assignment.BIKGCLOFCFG difficulty = (Assignment.BIKGCLOFCFG)item;
				list.Add(GetAssignmentByDifficulty(difficulty));
			}
			return list;
		}
	}

	public event Action AssignmentsLoaded;

	public event Action<int> AssignmentClaimed;

	public event Action<int> AssignmentSkipped;

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Awake()
	{
		base.Awake();
		if (mInstance == null)
		{
			mInstance = this;
		}
		assignmentsConstants = GetComponent<AssignmentsConstants>();
		Singleton<GameController>.instance.GameStarted += OnGameStart;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
	}

	private void OnGameStart()
	{
		foreach (Assignment currentAssignment in currentAssignments)
		{
			if (currentAssignment != null)
			{
				currentAssignment.isNewAssignment = false;
			}
		}
	}

	private void OnPlayerDataLoaded()
	{
		InvokeAfterFrame(delegate
		{
			LoadAssignments();
		});
	}

	public void AssignmentHide()
	{
		foreach (Assignment currentAssignment in currentAssignments)
		{
			if (currentAssignment != null)
			{
				currentAssignment.Hide();
			}
		}
		if (this.AssignmentsLoaded != null)
		{
			this.AssignmentsLoaded();
		}
	}

	public List<Tuple<int, float>> UpdateAssignments()
	{
		List<Tuple<int, float>> list = new List<Tuple<int, float>>();
		foreach (Assignment currentAssignment in currentAssignments)
		{
			float val = 0f;
			if (currentAssignment != null && !currentAssignment.isNewAssignment && !currentAssignment.done)
			{
				try
				{
					val = currentAssignment.Update();
				}
				catch (Exception exception)
				{
					AnalyticsHelper.LogHandledException(exception);
				}
			}
			int val2 = mPreparedAssignments.IndexOf(currentAssignment);
			list.Add(new Tuple<int, float>(val2, val));
		}
		return list;
	}

	public void Skip(Assignment assignment)
	{
		int num = mPreparedAssignments.IndexOf(assignment);
		Singleton<BeanstalkServerManager>.instance.SkipAssignment(num);
		if (this.AssignmentSkipped != null)
		{
			this.AssignmentSkipped(num);
		}
	}

	public Assignment GetAssignmentByDifficulty(Assignment.BIKGCLOFCFG difficulty)
	{
		foreach (Assignment mPreparedAssignment in mPreparedAssignments)
		{
			if (!mPreparedAssignment.claimed && mPreparedAssignment.difficulty == difficulty)
			{
				return mPreparedAssignment;
			}
		}
		return null;
	}

	public List<Tuple<int, float>> GetAssignmentsUpdate()
	{
		return UpdateAssignments();
	}

	public void LoadData(string assignmentData)
	{
		SerializedObject = JsonConvert.DeserializeObject<AssignmentData>(assignmentData);
		LoadAssignments();
	}

	public int GetCompletedAssignments()
	{
		if (data == null)
		{
			return 0;
		}
		return data.completed;
	}

	public void FakeAssignments()
	{
		foreach (Assignment currentAssignment in currentAssignments)
		{
			if (currentAssignment != null)
			{
				currentAssignment.Fake();
			}
		}
	}

	public void SetAllAssignmentsCompletedDebug()
	{
		List<DatabaseAssignment> assignments = instance.data.assignments;
		foreach (DatabaseAssignment item in assignments)
		{
			item.done = true;
			item.completeFract = 1f;
		}
		if (this.AssignmentsLoaded != null)
		{
			this.AssignmentsLoaded();
		}
	}

	public void SendClaimAssignment(DatabaseAssignment databaseAssignment, int addedReward)
	{
		data.completed++;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.ClaimAssignment, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{ "AssignmentId", databaseAssignment.id },
			{ "Reward", addedReward }
		}), 0, 0, string.Empty);
		for (int i = 0; i < mPreparedAssignments.Count; i++)
		{
			if (mPreparedAssignments[i].id == databaseAssignment.id && this.AssignmentClaimed != null)
			{
				this.AssignmentClaimed(i);
			}
		}
	}

	public void GetAssignmentsAfterStarterEnd()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted && mPreparedAssignments.Count == 0)
		{
			Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
		}
	}

	public void ClaimMegaReward()
	{
		Singleton<BeanstalkServerManager>.instance.PFPODIDLBGJ();
		Singleton<EventTrackingManager>.instance.KBJBMDDDDNF();
	}

	private void LoadAssignments()
	{
		mPreparedAssignments = new List<Assignment>();
		if (data != null && data.assignments != null && !StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			foreach (DatabaseAssignment assignment in data.assignments)
			{
				mPreparedAssignments.Add(Assignment.CreateAssignment(assignment, false, string.Empty));
			}
		}
		if (this.AssignmentsLoaded != null)
		{
			this.AssignmentsLoaded();
		}
	}
}
