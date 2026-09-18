using System;
using Beebyte.Obfuscator;
using Google2u;
using GooglePlayGames;
using UnityEngine;
using UnityEngine.SocialPlatforms;

[SkipRename]
public abstract class Achievement
{
	[Flags]
	public enum Evaluation
	{
		None = 0,
		AfterGame = 1,
		AfterGameOnServerResponse = 2,
		AfterUnitUpgrade = 4,
		AfterWeaponUpgrade = 8
	}

	private PlayGamesAchievement mAchievement;

	protected AchievementsRow mAchievementsRow;

	public abstract Evaluation evaluation { get; }

	public Achievements.rowIds id { get; private set; }

	public string androidId => (!BundleVersionBindings.BundleID.Contains("about")) ? mAchievementsRow.ANDROIDIDCHILL : mAchievementsRow.ANDROIDID;

	public int targetValue => mAchievementsRow.VALUE;

	public int currentValue
	{
		get
		{
			if (mAchievement != null)
			{
				return mAchievement.currentSteps;
			}
			return 0;
		}
	}

	private float progress => 1f;

	public bool completed
	{
		get
		{
			if (mAchievement != null)
			{
				return mAchievement.completed;
			}
			return false;
		}
	}

	public void Init(AchievementsRow row, Achievements.rowIds achievementId)
	{
		mAchievementsRow = row;
		id = achievementId;
		PlayGamesPlatform.Instance.AddIdMapping(id.ToString(), androidId);
	}

	public void Connect(IAchievement achievement)
	{
		Debug.Log($"Connect: {achievement} to {id}");
		mAchievement = (PlayGamesAchievement)achievement;
	}

	public abstract bool Evaluate();

	public void CompleteAchievement()
	{
		Singleton<GooglePlayGameService>.instance.ReportAchievement(id.ToString(), 100.0, delegate(bool success)
		{
			Debug.Log(string.Format("Report progress success: {0} for achivement: {1}", success, (mAchievement != null) ? mAchievement.ToString() : "null"));
		});
	}

	public void Report(int value)
	{
		Singleton<GooglePlayGameService>.instance.ReportAchievement(id.ToString(), 100.0 * ((double)value / (double)targetValue), delegate(bool success)
		{
			Debug.Log(string.Format("Report progress success: {0} for achivement: {1}", success, (mAchievement != null) ? mAchievement.ToString() : "null"));
		});
	}
}
