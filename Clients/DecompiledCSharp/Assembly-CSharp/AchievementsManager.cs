using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class AchievementsManager : Singleton<AchievementsManager>
{
	[Serializable]
	public class AchievementDefinition
	{
		public Achievement achievememt;

		[ClassSelection(typeof(Achievement))]
		public string achievementType;

		public Achievements.rowIds rowId;
	}

	public List<AchievementDefinition> achievements;

	private Achievements mAchievementsXls;

	private readonly List<Type> mAchievementTypes = new List<Type>
	{
		typeof(AchievementFinishBootcamp),
		typeof(AchievementCompleteWarpath),
		typeof(AchievementAchieveRank),
		typeof(AchievementDeployUnits),
		typeof(AchievementWinRankedBattles)
	};

	public bool isEnabled { get; set; }

	private Type GetAchievementType(string type)
	{
		foreach (Type mAchievementType in mAchievementTypes)
		{
			if (mAchievementType.Name == type)
			{
				return mAchievementType;
			}
		}
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		isEnabled = true;
		mAchievementsXls = GetComponent<Achievements>();
		Singleton<BeanstalkServerManager>.instance.PlayerDataLoaded += OnPlayerDataLoaded;
		foreach (AchievementDefinition achievement in achievements)
		{
			AchievementsRow row = mAchievementsXls.GetRow(achievement.rowId);
			Type achievementType = GetAchievementType(achievement.achievementType);
			(achievement.achievememt = (Achievement)Activator.CreateInstance(achievementType)).Init(row, achievement.rowId);
		}
	}

	private void OnPlayerDataLoaded()
	{
		if (GameLoginManager.currentPlayer.isGooglePlayConnected && Singleton<GooglePlayGameService>.instance.isLoggedIn)
		{
			Social.Active.LoadAchievements(AchievementsRecieved);
		}
	}

	private void AchievementsRecieved(IAchievement[] iAchievements)
	{
		Debug.Log("AchievementsRecieved: ");
		foreach (IAchievement achievement in iAchievements)
		{
			foreach (AchievementDefinition achievement2 in achievements)
			{
				if (achievement.id == achievement2.achievememt.androidId)
				{
					achievement2.achievememt.Connect(achievement);
					break;
				}
			}
		}
	}

	public void CompleteAchievements<T>() where T : Achievement
	{
		if (!isEnabled)
		{
			return;
		}
		foreach (AchievementDefinition achievement in achievements)
		{
			if (achievement.achievememt.GetType() == typeof(T))
			{
				achievement.achievememt.CompleteAchievement();
			}
		}
	}

	public void EvaluateAchievements<T>() where T : Achievement
	{
		if (!isEnabled)
		{
			return;
		}
		foreach (AchievementDefinition achievement in achievements)
		{
			if (achievement.achievememt.GetType() == typeof(T) && !achievement.achievememt.completed)
			{
				achievement.achievememt.Evaluate();
			}
		}
	}

	public void EvaluateAchievements(Achievement.Evaluation evaluation)
	{
		if (!isEnabled)
		{
			return;
		}
		foreach (AchievementDefinition achievement in achievements)
		{
			if ((achievement.achievememt.evaluation & evaluation) != Achievement.Evaluation.None && !achievement.achievememt.completed)
			{
				achievement.achievememt.Evaluate();
			}
		}
	}
}
