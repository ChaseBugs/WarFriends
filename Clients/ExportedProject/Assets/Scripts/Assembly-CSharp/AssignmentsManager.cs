using System;
using System.Collections.Generic;
using System.Globalization;
using Beebyte.Obfuscator;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

[Skip]
public class AssignmentsManager : DatabaseSerializedObjectGeneric<AssignmentsManager.AssignmentData>
{
	[Skip]
	public class AssignmentData
	{
		public List<DatabaseAssignment> assignments;

		public int tomorrow;

		public int completed;

		public int issued;

		public int rewardCounter;

		public int days;
	}

	[Skip]
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

	private AssignmentDefinitions mDefinitions;

	private TaskDefinitions mTaskDefinitions;

	public List<Assignment> preparedAssignments = new List<Assignment>();

	public static AssignmentsManager instance
	{
		get
		{
			mInstance = mInstance ?? ((AssignmentsManager)UnityEngine.Object.FindObjectsOfType(typeof(AssignmentsManager))[0]);
			return mInstance;
		}
	}

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

	public static string blueProgressBar => "menu-assignments-bar-blue";

	public static string redProgressBar => "menu-assignments-bar-red";

	public static string goldProgressBar => "menu-assignments-bar-gold";

	public static string dayNotCompleted => "menu-7days-assignment";

	public static string dayCompleted => "menu-7days-assignment-completed";

	public bool dailyAssignmentsClaimed
	{
		get
		{
			if (data == null || data.assignments == null || preparedAssignments == null || preparedAssignments.Count == 0)
			{
				return false;
			}
			bool flag = true;
			foreach (Assignment preparedAssignment in preparedAssignments)
			{
				flag &= preparedAssignment.claimed;
			}
			return flag;
		}
	}

	public int completedDaysAssignments
	{
		get
		{
			return (data != null) ? data.rewardCounter : 0;
		}
		set
		{
			data.rewardCounter = value;
		}
	}

	public event Action AssignmentsLoaded;

	public event Action<int> AssignmentClaimed;

	public void OnDestroy()
	{
		mInstance = null;
	}

	public void AssignmentHide()
	{
		string text = "Assignments Manager: *** Saving local assignment (Marking as Done) *************\n";
		foreach (Assignment preparedAssignment in preparedAssignments)
		{
			text += preparedAssignment.Hide();
		}
		Debug.Log(text + "**************************************************");
	}

	private float[] UpdateAssignments()
	{
		float[] array = new float[3];
		if (Singleton<GameController>.instance.isTutorial || StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			return array;
		}
		for (int i = 0; i < preparedAssignments.Count; i++)
		{
			if (preparedAssignments[i].isNewAssignment || preparedAssignments[i].done)
			{
				continue;
			}
			try
			{
				array[i] = preparedAssignments[i].Update();
			}
			catch (Exception ex)
			{
				Debug.LogError($"Assignments Manager: Assignment ID: {preparedAssignments[i].id}\nERROR: {ex.Message}\nSTACKTRACE: {ex.StackTrace}");
				if (DebugSettings.debugEnabled)
				{
					WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_ASSIGNMENTUPDATE"), 0f, null, string.Empty, useDialogBackground: true);
				}
				Crittercism.LogHandledException(ex);
			}
		}
		return array;
	}

	public List<Assignment> GetAssignments(bool update = true)
	{
		if (update)
		{
			UpdateAssignments();
		}
		return preparedAssignments;
	}

	internal float[] GetAssignmentsUpdate()
	{
		float[] array = UpdateAssignments();
		string text = "Assignments Manager: *** Counting new parts of completition of assignments to send to server: ***********\n";
		for (int i = 0; i < 3; i++)
		{
			text += $"Assignment {i + 1}: counted progress part: {array[i]}\n";
		}
		Debug.Log(text + "**************************************************");
		return array;
	}

	protected override void Awake()
	{
		base.Awake();
		if (mInstance == null)
		{
			mInstance = this;
		}
		Singleton<GameController>.instance.GameStarted += OnGameStart;
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += OnPlayerDataLoaded;
	}

	private void OnGameStart()
	{
		foreach (Assignment preparedAssignment in preparedAssignments)
		{
			preparedAssignment.isNewAssignment = false;
		}
	}

	private void OnPlayerDataLoaded()
	{
		InvokeAfterFrame(delegate
		{
			PrepareAssignments();
		});
	}

	private void PrepareAssignments()
	{
		preparedAssignments = new List<Assignment>();
		if (data != null && data.assignments != null && !StarterAssignmentsManager.instance.isActiveAndNotCompleted)
		{
			foreach (DatabaseAssignment assignment in data.assignments)
			{
				preparedAssignments.Add(Assignment.CreateAssignment(assignment, isSquadEvent: false, string.Empty, -1f));
			}
		}
		if (this.AssignmentsLoaded != null)
		{
			this.AssignmentsLoaded();
		}
	}

	internal void LoadData(string assignmentData)
	{
		Debug.Log("Assignments Manager: ASSIGNMENT MESSAGE:\n" + assignmentData);
		SerializedObject = JsonConvert.DeserializeObject<AssignmentData>(assignmentData);
		PrepareAssignments();
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
		foreach (Assignment preparedAssignment in preparedAssignments)
		{
			preparedAssignment.Fake();
		}
	}

	public void SetAllAssignmentsCompletedDebug()
	{
		Debug.Log("Assignments Manager: Debug Setting all assignments to done.");
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

	internal void SendClaimAssignment(DatabaseAssignment databaseAssignment, int addedReward)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.ClaimAssignment, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{ "AssignmentId", databaseAssignment.id },
			{ "Reward", addedReward }
		}), 0, 0, string.Empty);
		for (int i = 0; i < preparedAssignments.Count; i++)
		{
			if (preparedAssignments[i].id == databaseAssignment.id && this.AssignmentClaimed != null)
			{
				this.AssignmentClaimed(i);
			}
		}
	}

	public void GetAssignmentsAfterStarterEnd()
	{
		if (!StarterAssignmentsManager.instance.isActiveAndNotCompleted && preparedAssignments.Count == 0)
		{
			Singleton<BeanstalkServerManager>.instance.GetNewAssignments();
		}
	}
}
