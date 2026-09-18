using System;
using Beebyte.Obfuscator;
using Google2u;
using UnityEngine;

[Skip]
public class Assignment
{
	public enum State
	{
		InProgress,
		Finishing,
		Done,
		Claimed
	}

	public enum AssignmentId
	{
		DestroyCrates,
		DestroyCratesInOneBattle,
		KillEnemyUnits,
		KillEnemyUnitsInOneBattle,
		KillSpecificEnemyUnits,
		ScorePoints,
		ScorePointsInOneBattle,
		WinMultiplayerMatches,
		PlayMultiplayerMatches,
		FinishMission,
		GainSkillshots,
		GainRibbons,
		DeployUnits,
		DeployUnitsFromCategory,
		PlayWarcards,
		PlaySpecificWarcards,
		KillEnemiesUsingSpecificWeapon,
		DestroyEnemyCrates
	}

	private AssignmentsManager.DatabaseAssignment mDatabaseAssignment;

	public object[] data;

	public int reward;

	public bool isNewAssignment;

	public State currentState
	{
		get
		{
			if (claimed)
			{
				return State.Claimed;
			}
			if (done)
			{
				return State.Done;
			}
			return isCompleted ? State.Finishing : State.InProgress;
		}
	}

	public int id => mDatabaseAssignment.id;

	public bool done
	{
		get
		{
			return mDatabaseAssignment.done;
		}
		private set
		{
			mDatabaseAssignment.done = value;
		}
	}

	public bool claimed
	{
		get
		{
			return mDatabaseAssignment.claimed;
		}
		private set
		{
			mDatabaseAssignment.claimed = value;
		}
	}

	protected float completeFract
	{
		get
		{
			return mDatabaseAssignment.completeFract;
		}
		set
		{
			mDatabaseAssignment.completeFract = value;
		}
	}

	protected float lastCompletedFract
	{
		get
		{
			return mDatabaseAssignment.lastCompletedFract;
		}
		set
		{
			mDatabaseAssignment.lastCompletedFract = value;
		}
	}

	public virtual bool isCompleted
	{
		get
		{
			if (data == null || data.Length == 0)
			{
				return false;
			}
			int num = Convert.ToInt32(data[0]);
			int num2 = (int)Mathf.Round((lastCompletedFract + completeFract) * (float)num);
			return num2 >= num;
		}
	}

	public virtual string progressBarSpriteForProgress => AssignmentsManager.blueProgressBar;

	public virtual string assignmentPicture => "menu-assignments-type-crate";

	public virtual string status
	{
		get
		{
			if (data == null)
			{
				return "no data";
			}
			int num = Convert.ToInt32(data[0]);
			int num2 = MiscTools.RoundToInt((float)num * GetEndProgress());
			return $"({MiscTools.FormatAssignmentNumber(num2)}\u00a0/\u00a0{MiscTools.FormatAssignmentNumber(num)})";
		}
	}

	public virtual string redStatus => status;

	protected string translationId => AssignmentsManager.instance.taskDefinitions.GetRow(GetDefinitionId()).DESCRIPTIONSTRING;

	protected virtual string basicDescription => Localization.LocalizeFormat(translationId, data);

	protected string descriptionNoColours
	{
		get
		{
			if (data == null)
			{
				Debug.LogError($"Assignment: Assignment id {id} does not contain any data!!!!");
				return Localization.Localize(translationId);
			}
			try
			{
				return basicDescription;
			}
			catch (Exception)
			{
				Debug.LogError("Assignment: Bad Localization Format for assignment id = " + id);
				return "ERROR - BAD FORMAT";
			}
		}
	}

	public string blueDescription => descriptionNoColours.Replace("<", Colours.stringBlue).Replace(">", Colours.stringWhite);

	public string goldDescription => descriptionNoColours.Replace("<", Colours.stringGoldOld).Replace(">", Colours.stringWhite);

	public string whiteDescription => descriptionNoColours.Replace("<", string.Empty).Replace(">", string.Empty);

	public virtual bool hasHint => false;

	public virtual string hintText => string.Empty;

	public Assignment(AssignmentsManager.DatabaseAssignment dbAssignment, float playerProgress)
	{
		mDatabaseAssignment = dbAssignment;
		Debug.Log($"Assignment: Initializing - id: {id} completion:{completeFract} lastCompleted:{lastCompletedFract} done:{done} claimed:{claimed}");
		isNewAssignment = false;
		claimed = mDatabaseAssignment.claimed;
		if (lastCompletedFract < 0f)
		{
			done = false;
			isNewAssignment = true;
			lastCompletedFract = 0f;
			completeFract = 0f;
		}
		else
		{
			done = isCompleted;
		}
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + dbAssignment.id);
		if (row != null)
		{
			switch (row.DIFFICULTY)
			{
			default:
				reward = InterpolateValue((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TaskReward1Min).FLOATVALUE, (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TaskReward1Max).FLOATVALUE, playerProgress);
				break;
			case 2:
				reward = InterpolateValue((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TaskReward2Min).FLOATVALUE, (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TaskReward2Max).FLOATVALUE, playerProgress);
				break;
			case 3:
				reward = InterpolateValue((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TaskReward3Min).FLOATVALUE, (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TaskReward3Max).FLOATVALUE, playerProgress);
				break;
			}
		}
		else
		{
			Debug.LogError("Assignment: Error when generating reward -> no definition with id " + dbAssignment.id);
		}
	}

	public string GetDefinitionId()
	{
		return "ID_" + id;
	}

	public int GetReward()
	{
		return reward;
	}

	internal string Hide()
	{
		done = isCompleted;
		string empty = string.Empty;
		if (GetRememberProgress())
		{
			empty += $"Assignment: ASSIGNMENT THAT SAVES PROGRESS\t\t{descriptionNoColours} {status}";
			empty += string.Format("(previous saved + new completed = new total saved): {1} + {0} = ", completeFract, lastCompletedFract);
			lastCompletedFract += completeFract;
			completeFract = 0f;
			empty += $"{lastCompletedFract}";
		}
		else
		{
			empty += $"ASSIGNMENT THAT DOESNOT SAVE PROGRESS\t{descriptionNoColours} {status}";
			empty += $"\tcompletition: {completeFract} and previously completed: {lastCompletedFract}";
			if (!done)
			{
				completeFract = 0f;
			}
		}
		return empty + $"\t\tReward: {GetReward()}\n";
	}

	public bool GetRememberProgress()
	{
		return AssignmentsManager.instance.taskDefinitions.GetRow(GetDefinitionId()).REMEMBERCOMPLETION;
	}

	public float GetProgress()
	{
		return (!done && !claimed) ? (completeFract + lastCompletedFract) : 1f;
	}

	public float GetStartProgress()
	{
		return (!done && !claimed) ? Mathf.Clamp01(lastCompletedFract) : 1f;
	}

	public float GetEndProgress()
	{
		return Mathf.Clamp01(GetProgress());
	}

	protected float CompareIntAndInt(int gained, int target)
	{
		if (target == 0)
		{
			return 1f;
		}
		float value = (float)gained / (float)target;
		return Mathf.Clamp01(value);
	}

	public virtual float Update()
	{
		Debug.LogError("Assignment: Empty Update method called!");
		return 0f;
	}

	protected static object[] GetAloneObjectFor(int id, int length, int target)
	{
		object[] array = new object[length];
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + id);
		if (row == null)
		{
			Debug.Log("Assignment: Error, task definition not found for id = " + id);
			return array;
		}
		array[0] = target;
		return array;
	}

	protected static int InterpolateValue(int min, int max, float coef)
	{
		return (int)Math.Round((float)min + (float)(max - min) * coef);
	}

	internal static Assignment CreateAssignment(AssignmentsManager.DatabaseAssignment databaseAssignment, bool isSquadEvent = false, string secondParameter = "", float levelProgress = -1f)
	{
		if (levelProgress < 0f)
		{
			levelProgress = LevelManager.instance.GetPlayerLevelProgress();
		}
		try
		{
			switch ((AssignmentId)databaseAssignment.id)
			{
			case AssignmentId.DestroyCrates:
				return new DestroyCratesAssignment(databaseAssignment, levelProgress);
			case AssignmentId.DestroyCratesInOneBattle:
				return new DestroyCratesInOneBattleAssignment(databaseAssignment, levelProgress);
			case AssignmentId.KillEnemyUnits:
				return new KillEnemyUnitsAssignment(databaseAssignment, levelProgress);
			case AssignmentId.KillEnemyUnitsInOneBattle:
				return new KillEnemyUnitsInOneBattleAssignment(databaseAssignment, levelProgress);
			case AssignmentId.KillSpecificEnemyUnits:
				return new KillSpecificEnemyUnits(databaseAssignment, levelProgress, secondParameter);
			case AssignmentId.ScorePoints:
				return new ScorePointsAssignment(databaseAssignment, levelProgress);
			case AssignmentId.ScorePointsInOneBattle:
				return new ScorePointsInOneBattleAssignment(databaseAssignment, levelProgress);
			case AssignmentId.WinMultiplayerMatches:
				return new WinMultiplayerMatchesAssignment(databaseAssignment, levelProgress);
			case AssignmentId.PlayMultiplayerMatches:
				return new PlayMultiplayerMatchesAssignment(databaseAssignment, levelProgress);
			case AssignmentId.FinishMission:
				return new FinishMissionAssignment(databaseAssignment, levelProgress);
			case AssignmentId.GainSkillshots:
				return new GainSkillshotsAssignment(databaseAssignment, levelProgress, secondParameter);
			case AssignmentId.GainRibbons:
				return new GainRibbonsAssignment(databaseAssignment, levelProgress, secondParameter);
			case AssignmentId.DeployUnits:
				return new DeployUnitsAssignment(databaseAssignment, levelProgress);
			case AssignmentId.DeployUnitsFromCategory:
				return new DeployUnitsFromCategoryAssignment(databaseAssignment, levelProgress, secondParameter);
			case AssignmentId.PlayWarcards:
				return new PlayWarcardsAssignment(databaseAssignment, levelProgress);
			case AssignmentId.PlaySpecificWarcards:
				return new PlaySpecificWarcardsAssignment(databaseAssignment, levelProgress, secondParameter);
			case AssignmentId.KillEnemiesUsingSpecificWeapon:
				return new KillEnemiesUsingSpecificWeaponAssignment(databaseAssignment, levelProgress, secondParameter);
			case AssignmentId.DestroyEnemyCrates:
				return new DestroyEnemyCratesAssignment(databaseAssignment, levelProgress);
			}
		}
		catch (Exception ex)
		{
			string text = string.Format("Assignment: Handled: \nId:{0} isSquadEvent:{1} secondParameter:{2} levelProgress:{3}\n", databaseAssignment.id, isSquadEvent, (secondParameter != null) ? secondParameter : "null", levelProgress);
			Debug.LogError(text + ex);
			Crittercism.LogHandledException(ex);
		}
		Debug.LogError("Assignment: Unknown Id = " + databaseAssignment.id);
		return new Assignment(databaseAssignment, levelProgress);
	}

	public void Claim()
	{
		claimed = true;
		if (AssignmentsManager.instance.dailyAssignmentsClaimed)
		{
			Debug.LogError("Assignment: All assignments CLAIMED");
			AssignmentsManager.instance.completedDaysAssignments++;
			Singleton<EventTrackingManager>.instance.RegisterAssignmentDailyCompletion(AssignmentsManager.instance.completedDaysAssignments, AssignmentsManager.instance.data.days + 1);
		}
		AssignmentsManager.instance.SendClaimAssignment(mDatabaseAssignment, GetReward());
		Singleton<EventTrackingManager>.instance.RegisterAssignmentCompletion(mDatabaseAssignment, AssignmentsManager.instance.data.completed);
		int num = GetReward();
		if (num > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("Assigment", num);
		}
		Singleton<Wallet>.instance.AddGoldReward(num);
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.AssigmentCompleted);
	}

	public void Fake()
	{
		claimed = false;
		done = false;
		completeFract = 1f;
	}
}
