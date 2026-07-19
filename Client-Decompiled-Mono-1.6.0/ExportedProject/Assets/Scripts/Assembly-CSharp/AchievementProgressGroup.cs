using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;

public sealed class AchievementProgressGroup
{
	private AchievementProgressGroupData mData;

	public int id
	{
		get
		{
			return mData.id;
		}
	}

	public Achievement achievement { get; private set; }

	public AchievementProgress[] achievementProgresses { get; private set; }

	public CINKACCJIHG state
	{
		get
		{
			AchievementProgress achievementProgress = currentAchievementProgress;
			if (achievementProgress == null)
			{
				throw new NullReferenceException("currentAchievementProgress");
			}
			return achievementProgress.state;
		}
	}

	public int completedCount
	{
		get
		{
			for (int i = 0; i < achievementProgresses.Length; i++)
			{
				if (!achievementProgresses[i].isCompleted)
				{
					return i;
				}
			}
			return achievementProgresses.Length;
		}
	}

	public int claimedCount
	{
		get
		{
			for (int i = 0; i < achievementProgresses.Length; i++)
			{
				if (!achievementProgresses[i].isClaimed)
				{
					return i;
				}
			}
			return achievementProgresses.Length;
		}
	}

	public AchievementProgress currentAchievementProgress
	{
		get
		{
			if (achievementProgresses == null || achievementProgresses.Length == 0)
			{
				return null;
			}
			AchievementProgress[] array = achievementProgresses;
			foreach (AchievementProgress achievementProgress in array)
			{
				if (!achievementProgress.isClaimed)
				{
					return achievementProgress;
				}
			}
			return achievementProgresses[achievementProgresses.Length - 1];
		}
	}

	public AchievementProgress firstUnclaimedAchievementProgress
	{
		get
		{
			if (achievementProgresses == null || achievementProgresses.Length == 0)
			{
				return null;
			}
			AchievementProgress[] array = achievementProgresses;
			foreach (AchievementProgress achievementProgress in array)
			{
				if (!achievementProgress.isClaimed)
				{
					return achievementProgress;
				}
			}
			return null;
		}
	}

	public AchievementProgress currentAchievementProgressForGUI
	{
		get
		{
			if (achievementProgresses == null || achievementProgresses.Length == 0)
			{
				return null;
			}
			AchievementProgress[] array = achievementProgresses;
			foreach (AchievementProgress achievementProgress in array)
			{
				if (!achievementProgress.isClaimed)
				{
					return achievementProgress;
				}
			}
			return achievementProgresses[achievementProgresses.Length - 1];
		}
	}

	public bool hasMultipleAchievementProgresses
	{
		get
		{
			return achievementProgresses != null && achievementProgresses.Length > 1;
		}
	}

	public int globalTargetValue
	{
		get
		{
			if (achievementProgresses == null)
			{
				return 0;
			}
			return achievementProgresses.Length;
		}
	}

	public int globalCurrentValue
	{
		get
		{
			if (achievementProgresses == null)
			{
				return 0;
			}
			for (int i = 0; i < achievementProgresses.Length; i++)
			{
				AchievementProgress achievementProgress = achievementProgresses[i];
				if (!achievementProgress.isCompleted)
				{
					return i;
				}
			}
			return globalTargetValue;
		}
	}

	public float globalProgress
	{
		get
		{
			int num = globalTargetValue;
			return (num > 0) ? EJLBCNBODJG.CBHCAEBJNOE((float)globalCurrentValue / (float)num) : 1f;
		}
	}

	public bool isCompleted
	{
		get
		{
			return Mathf.Approximately(globalProgress, 1f);
		}
	}

	public bool isClaimed
	{
		get
		{
			return achievementProgresses != null && achievementProgresses.Length != 0 && achievementProgresses[achievementProgresses.Length - 1].isClaimed;
		}
	}

	public int localOffset
	{
		get
		{
			return mData.localOffset;
		}
		private set
		{
			if (value != mData.localOffset)
			{
				mData.localOffset = value;
			}
		}
	}

	public int localTargetValue
	{
		get
		{
			if (achievementProgresses == null || achievementProgresses.Length == 0)
			{
				return 0;
			}
			return achievementProgresses[achievementProgresses.Length - 1].targetValue;
		}
	}

	public int localCurrentValue
	{
		get
		{
			return mData.localCurrentValue;
		}
	}

	public float localProgress
	{
		get
		{
			int num = localTargetValue;
			return (!((float)num <= Mathf.Epsilon)) ? EJLBCNBODJG.CBHCAEBJNOE((float)localCurrentValue / (float)num) : 0f;
		}
	}

	public string GetText(string stringColor)
	{
		string arg = Localization.Localize(currentAchievementProgressForGUI.achievementDefinition.MHEHLJGIEKD);
		string text = currentAchievementProgressForGUI.achievementDefinition.JOJLPMLBOMO;
		int targetValue = currentAchievementProgressForGUI.targetValue;
		string text2 = achievement.IJIFKCPIBFE(targetValue);
		if (targetValue == 1 && achievement.CDONJDOBFCM)
		{
			text += "SING";
		}
		string arg2 = Localization.LocalizeFormat(text, text2);
		return string.Format("{0}{1}[-] {2}", stringColor, arg, arg2);
	}

	public string GetProgressString(int start, int end)
	{
		return achievement.DAHPGICCLID(start, end);
	}

	public float GetProgress()
	{
		return achievement.DDPHGMIKKFP(currentAchievementProgress.progress);
	}

	public float GetProgressForSort()
	{
		return achievement.DDPHGMIKKFP(currentAchievementProgressForGUI.progress);
	}

	public void Init(AchievementProgressGroupData data)
	{
		mData = data;
		Type type = Singleton<AchievementsManager>.instance.achievementTypes[mData.id];
		achievement = ((type != null) ? ((Achievement)Activator.CreateInstance(type)) : new AchievementDummy());
		achievementProgresses = new AchievementProgress[mData.achievementProgressData.Length];
		for (int i = 0; i < mData.achievementProgressData.Length; i++)
		{
			AchievementProgress achievementProgress = new AchievementProgress();
			achievementProgress.Init(i, this, mData.achievementProgressData[i]);
			achievementProgresses[i] = achievementProgress;
		}
		if (achievementProgresses.Length > 1)
		{
			achievementProgresses = achievementProgresses.OrderBy((AchievementProgress x) => x.targetValue).ToArray();
		}
		EnsureLocalOffset();
	}

	public static AchievementProgressGroup[] InitFromData(AchievementProgressGroupData[] data)
	{
		if (data == null)
		{
			return null;
		}
		AchievementProgressGroup[] array = new AchievementProgressGroup[data.Length];
		for (int i = 0; i < data.Length; i++)
		{
			AchievementProgressGroupData data2 = data[i];
			AchievementProgressGroup achievementProgressGroup = new AchievementProgressGroup();
			achievementProgressGroup.Init(data2);
			array[i] = achievementProgressGroup;
		}
		return array;
	}

	public void SetLocalCurrentValue(int value, bool addOffset)
	{
		int num = mData.localCurrentValue;
		int num2 = ((localOffset != int.MinValue) ? localOffset : 0);
		int b = Mathf.Clamp(value + (addOffset ? num2 : 0), 0, localTargetValue);
		mData.localCurrentValue = Mathf.Max(num, b);
		OnLocalCurrentValueChanged(num, mData.localCurrentValue);
	}

	private void EnsureLocalOffset()
	{
		if (localOffset == int.MinValue)
		{
			localOffset = achievement.NGBBMKPCECD();
			Evaluate();
			if (localOffset != 0 && achievement.HGOBPPGCPMI != Achievement.NHMEEMEJLOK.Zero)
			{
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("Id", id);
				dictionary.Add("Offset", localOffset);
				string objData = JsonConvert.SerializeObject(dictionary);
				RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
				requestBuffer.AddRequest(DatabaseAction.ChangeAchievementOffset, objData, 0, 0, string.Empty);
			}
		}
	}

	public void Evaluate()
	{
		if (!isCompleted)
		{
			SetLocalCurrentValue(achievement.GOPJOOHKCNB(), true);
		}
	}

	public void Complete()
	{
		if (!isCompleted)
		{
			SetLocalCurrentValue(localTargetValue, false);
		}
	}

	public void CompleteFirstUnclaimedTier()
	{
		CompleteTier(firstUnclaimedAchievementProgress);
		Singleton<AchievementsManager>.instance.FireEvaluatedAchievements();
	}

	public void CompleteTier(AchievementProgress achievementProgress)
	{
		if (achievementProgress != null && !achievementProgress.isCompleted)
		{
			SetLocalCurrentValue(achievementProgress.targetValue, false);
		}
	}

	public bool CanClaim()
	{
		return CanClaim(firstUnclaimedAchievementProgress);
	}

	private bool CanClaim(AchievementProgress achievementProgress)
	{
		return achievementProgress != null && achievementProgress.isCompleted && !achievementProgress.isClaimed;
	}

	public bool Claim()
	{
		AchievementProgress achievementProgress = firstUnclaimedAchievementProgress;
		if (CanClaim(achievementProgress))
		{
			AchievementsManager.CHIDHGCKCIK achievementDefinition = achievementProgress.achievementDefinition;
			Singleton<Wallet>.instance.IGDGGPOJPHL(Mathf.RoundToInt(achievementDefinition.FKIGMDIHKAA), Mathf.RoundToInt(achievementDefinition.BJFGHKNAIIE), Mathf.RoundToInt(achievementDefinition.KMCEFANOLKM), Mathf.RoundToInt(achievementDefinition.ELCDCFHKGHC));
			achievementProgress.isClaimed = true;
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Id", id);
			dictionary.Add("ProgressId", achievementProgress.id);
			string objData = JsonConvert.SerializeObject(dictionary);
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.ClaimAchievement, objData, 0, 0, string.Empty);
			Singleton<AchievementsManager>.instance.ClaimAchievement();
			Singleton<EventTrackingManager>.instance.ClaimAchievement(achievementProgress);
			return true;
		}
		return false;
	}

	private void OnLocalCurrentValueChanged(int oldValue, int newValue)
	{
		if (achievementProgresses == null)
		{
			return;
		}
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("Id", id);
		dictionary.Add("Progress", newValue);
		string objData = JsonConvert.SerializeObject(dictionary);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.ChangeAchievementProgres, objData, 0, 0, string.Empty);
		AchievementProgress[] array = achievementProgresses;
		foreach (AchievementProgress achievementProgress in array)
		{
			if (achievementProgress.IsCompleted(oldValue) != achievementProgress.IsCompleted(newValue))
			{
				Singleton<EventTrackingManager>.instance.CompleteAchievement(achievementProgress);
			}
			float progress = achievementProgress.GetProgress(oldValue);
			float progress2 = achievementProgress.GetProgress(newValue);
			if (!Mathf.Approximately(progress2, progress))
			{
				HADLIENNCEA.IJAOGNHHEPK(achievementProgress.achievementDefinition, progress2 * 100f);
			}
		}
	}
}
