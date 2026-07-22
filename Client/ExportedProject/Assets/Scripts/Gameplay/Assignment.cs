using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class Assignment
{
	public enum BFLFNAENJMJ
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

	public enum JLANLLEABDC
	{
		InProgress,
		Finishing,
		Done,
		Claimed
	}

	public enum BIKGCLOFCFG
	{
		Easy,
		Medium,
		Hard
	}

	public enum MHNMOFPPKBN
	{
		Gold,
		Tickets,
		Scraps
	}

	public bool isNewAssignment;

	private readonly AssignmentsManager.DatabaseAssignment mDatabaseAssignment;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private object[] _003CmData_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _003CrewardAmount_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MHNMOFPPKBN _003CrewardType_003Ek__BackingField;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BIKGCLOFCFG _003Cdifficulty_003Ek__BackingField;

	protected object[] mData
	{
		[CompilerGenerated]
		get
		{
			return _003CmData_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CmData_003Ek__BackingField = value;
		}
	}

	public JLANLLEABDC currentState
	{
		get
		{
			if (claimed)
			{
				return JLANLLEABDC.Claimed;
			}
			if (done)
			{
				return JLANLLEABDC.Done;
			}
			return isCompleted ? JLANLLEABDC.Finishing : JLANLLEABDC.InProgress;
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

	protected float mCompleteFract
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

	protected float mLastCompletedFract
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

	public int rewardAmount
	{
		[CompilerGenerated]
		get
		{
			return _003CrewardAmount_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CrewardAmount_003Ek__BackingField = value;
		}
	}

	public MHNMOFPPKBN rewardType
	{
		[CompilerGenerated]
		get
		{
			return _003CrewardType_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CrewardType_003Ek__BackingField = value;
		}
	}

	public BIKGCLOFCFG difficulty
	{
		[CompilerGenerated]
		get
		{
			return _003Cdifficulty_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003Cdifficulty_003Ek__BackingField = value;
		}
	}

	public int rewardPoints => (int)(difficulty + 1);

	public virtual string assignmentPicture => "menu-assignments-type-crate";

	public virtual bool isCompleted
	{
		get
		{
			if (mData == null || mData.Length == 0)
			{
				return false;
			}
			int num = Convert.ToInt32(mData[0]);
			int num2 = (int)Mathf.Round((mLastCompletedFract + mCompleteFract) * (float)num);
			return num2 >= num;
		}
	}

	public virtual string progressBarSpriteForProgress => AssignmentsManager.blueProgressBar;

	public virtual string status
	{
		get
		{
			if (mData == null)
			{
				return "no data";
			}
			int num = Convert.ToInt32(mData[0]);
			int fFHHEHHFOKJ = MEJMLNDFDBP.LJDADOKBBNA((float)num * GetEndProgress());
			return $"({MEJMLNDFDBP.PHCBFODPDOD(fFHHEHHFOKJ)}\u00a0/\u00a0{MEJMLNDFDBP.PHCBFODPDOD(num)})";
		}
	}

	public virtual string redStatus => status;

	protected string translationId => AssignmentsManager.instance.taskDefinitions.GetRow(GetDefinitionId()).DESCRIPTIONSTRING;

	protected virtual string basicDescription => Localization.LocalizeFormat(translationId, mData);

	protected string descriptionNoColours
	{
		get
		{
			if (mData == null)
			{
				return Localization.Localize(translationId);
			}
			try
			{
				return basicDescription;
			}
			catch (Exception)
			{
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
		isNewAssignment = false;
		claimed = mDatabaseAssignment.claimed;
		if (mLastCompletedFract < 0f)
		{
			done = false;
			isNewAssignment = true;
			mLastCompletedFract = 0f;
			mCompleteFract = 0f;
		}
		else
		{
			done = isCompleted;
		}
		AssignmentsConstants assignmentsConstants = AssignmentsManager.instance.assignmentsConstants;
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + dbAssignment.id);
		if (row != null)
		{
			string in_RowString = $"GoldReward{row.DIFFICULTY}Min";
			string in_RowString2 = $"GoldReward{row.DIFFICULTY}Max";
			rewardType = MHNMOFPPKBN.Gold;
			rewardAmount = (int)Math.Round(Mathf.Lerp(assignmentsConstants.GetRow(in_RowString).FLOATVALUE, assignmentsConstants.GetRow(in_RowString2).FLOATVALUE, playerProgress));
			difficulty = (BIKGCLOFCFG)(row.DIFFICULTY - 1);
		}
		else
		{
			UnityEngine.Debug.LogError("Assignment: Error when generating reward -> no definition with id " + dbAssignment.id);
		}
	}

	public string GetDefinitionId()
	{
		return "ID_" + id;
	}

	public void Hide()
	{
		done = isCompleted;
		if (GetRememberProgress())
		{
			mLastCompletedFract += mCompleteFract;
			mCompleteFract = 0f;
		}
		else if (!done)
		{
			mCompleteFract = 0f;
		}
	}

	protected static object[] GetAloneObjectFor(int id, int length, int target)
	{
		object[] array = new object[length];
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + id);
		if (row == null)
		{
			return array;
		}
		array[0] = target;
		return array;
	}

	internal static Assignment CreateAssignment(AssignmentsManager.DatabaseAssignment databaseAssignment, bool isSquadEvent = false, string secondParameter = "", float levelProgress = -1f)
	{
		if (levelProgress < 0f)
		{
			levelProgress = LevelManager.instance.GetPlayerLevelProgress();
		}
		try
		{
			switch ((BFLFNAENJMJ)databaseAssignment.id)
			{
			case BFLFNAENJMJ.DestroyCrates:
				return new DestroyCratesAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.DestroyCratesInOneBattle:
				return new DestroyCratesInOneBattleAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.KillEnemyUnits:
				return new KillEnemyUnitsAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.KillEnemyUnitsInOneBattle:
				return new KillEnemyUnitsInOneBattleAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.KillSpecificEnemyUnits:
				return new KillSpecificEnemyUnits(databaseAssignment, levelProgress, secondParameter);
			case BFLFNAENJMJ.ScorePoints:
				return new ScorePointsAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.ScorePointsInOneBattle:
				return new ScorePointsInOneBattleAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.WinMultiplayerMatches:
				return new WinMultiplayerMatchesAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.PlayMultiplayerMatches:
				return new PlayMultiplayerMatchesAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.FinishMission:
				return new FinishMissionAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.GainSkillshots:
			case BFLFNAENJMJ.GainRibbons:
				return new GainSkillshotsAssignment(databaseAssignment, levelProgress, secondParameter);
			case BFLFNAENJMJ.DeployUnits:
				return new DeployUnitsAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.DeployUnitsFromCategory:
				return new DeployUnitsFromCategoryAssignment(databaseAssignment, levelProgress, secondParameter);
			case BFLFNAENJMJ.PlayWarcards:
				return new PlayWarcardsAssignment(databaseAssignment, levelProgress);
			case BFLFNAENJMJ.PlaySpecificWarcards:
				return new PlaySpecificWarcardsAssignment(databaseAssignment, levelProgress, secondParameter);
			case BFLFNAENJMJ.KillEnemiesUsingSpecificWeapon:
				return new KillEnemiesUsingSpecificWeaponAssignment(databaseAssignment, levelProgress, secondParameter);
			case BFLFNAENJMJ.DestroyEnemyCrates:
				return new DestroyEnemyCratesAssignment(databaseAssignment, levelProgress);
			}
		}
		catch (Exception exception)
		{
			string text = string.Format("Assignment: Handled: \nId:{0} isSquadEvent:{1} secondParameter:{2} levelProgress:{3}\n", databaseAssignment.id, isSquadEvent, (secondParameter != null) ? secondParameter : "null", levelProgress);
			AnalyticsHelper.LogHandledException(exception);
		}
		return new Assignment(databaseAssignment, levelProgress);
	}

	public void Claim()
	{
		claimed = true;
		AssignmentsManager instance = AssignmentsManager.instance;
		instance.currentMegaRewardPoints += rewardPoints;
		instance.SendClaimAssignment(mDatabaseAssignment, rewardAmount);
		Singleton<EventTrackingManager>.instance.ENALKGDOHDD(mDatabaseAssignment, instance.data.completed);
		Assignment assignmentByDifficulty = instance.GetAssignmentByDifficulty(difficulty);
		if (assignmentByDifficulty != null)
		{
			Singleton<EventTrackingManager>.instance.MINMHKPKOMN(assignmentByDifficulty.mDatabaseAssignment, 1, LHKNKPDMNJH: true);
		}
		Singleton<AchievementsManager>.instance.EvaluateAchievements<AchievementCompleteAssignments>();
		Singleton<EventTrackingManager>.instance.RegisterGoldIn("Assigment", rewardAmount);
		Singleton<Wallet>.instance.COLJGNLBEII(rewardAmount);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.AssigmentCompleted);
	}

	public void Skip()
	{
		claimed = true;
		Singleton<EventTrackingManager>.instance.CGAJBFNDLOE(mDatabaseAssignment);
		AssignmentsManager.instance.Skip(this);
	}

	public void Fake()
	{
		claimed = false;
		done = false;
		mCompleteFract = 1f;
	}

	public bool GetRememberProgress()
	{
		return AssignmentsManager.instance.taskDefinitions.GetRow(GetDefinitionId()).REMEMBERCOMPLETION;
	}

	public float GetProgress()
	{
		return (!done && !claimed) ? (mCompleteFract + mLastCompletedFract) : 1f;
	}

	public float GetStartProgress()
	{
		return (!done && !claimed) ? Mathf.Clamp01(mLastCompletedFract) : 1f;
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
		return 0f;
	}
}
