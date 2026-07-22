using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

public sealed class AchievementProgressGroups : DatabaseSerializedObjectGeneric<AchievementProgressGroups.AchievementsData>
{
	public sealed class AchievementsData
	{
		[JsonProperty("data")]
		public AchievementProgressGroupData[] achievementProgressGroupData;
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private AchievementProgressGroup[] _003CachievementProgressGroups_003Ek__BackingField;

	public AchievementProgressGroup[] achievementProgressGroups
	{
		[CompilerGenerated]
		get
		{
			return _003CachievementProgressGroups_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CachievementProgressGroups_003Ek__BackingField = value;
		}
	}

	protected override void InitData()
	{
		EnsureInitialized();
	}

	public void EnsureInitialized()
	{
		if (achievementProgressGroups != null)
		{
			return;
		}
		Singleton<AchievementsManager>.instance.EnsureInitialized();
		Dictionary<int, AchievementProgressGroupData> dictionary = new Dictionary<int, AchievementProgressGroupData>();
		for (int i = 0; i < Singleton<AchievementsManager>.instance.achievements.Count; i++)
		{
			List<AchievementsManager.CHIDHGCKCIK> list = Singleton<AchievementsManager>.instance.achievements[i];
			for (int j = 0; j < list.Count; j++)
			{
				AchievementsManager.CHIDHGCKCIK cHIDHGCKCIK = list[j];
				if (!dictionary.ContainsKey(cHIDHGCKCIK.KHKKGLMKBLP))
				{
					dictionary.Add(cHIDHGCKCIK.KHKKGLMKBLP, new AchievementProgressGroupData
					{
						id = cHIDHGCKCIK.KHKKGLMKBLP
					});
				}
			}
		}
		AchievementProgressGroupData[] array = data.achievementProgressGroupData ?? new AchievementProgressGroupData[0];
		foreach (AchievementProgressGroupData achievementProgressGroupData in array)
		{
			dictionary[achievementProgressGroupData.id] = achievementProgressGroupData;
		}
		foreach (KeyValuePair<int, AchievementProgressGroupData> item in dictionary)
		{
			AchievementProgressGroupData value = item.Value;
			List<AchievementsManager.CHIDHGCKCIK> list2 = Singleton<AchievementsManager>.instance.achievements[value.id] ?? new List<AchievementsManager.CHIDHGCKCIK>();
			if (value.achievementProgressData == null || value.achievementProgressData.Length == 0)
			{
				value.achievementProgressData = new AchievementProgressData[list2.Count];
			}
			else
			{
				if (value.achievementProgressData.Length > list2.Count)
				{
					throw new InvalidOperationException($"Achievements config for the '{Singleton<AchievementsManager>.instance.achievementTypes[value.id]}' group contains less achievement definitions than is currently stored on the server.");
				}
				AchievementProgressData[] achievementProgressData = value.achievementProgressData;
				value.achievementProgressData = new AchievementProgressData[list2.Count];
				Array.Copy(achievementProgressData, value.achievementProgressData, achievementProgressData.Length);
			}
			for (int l = 0; l < value.achievementProgressData.Length; l++)
			{
				if (value.achievementProgressData[l] == null)
				{
					value.achievementProgressData[l] = new AchievementProgressData
					{
						claimed = false
					};
				}
			}
		}
		achievementProgressGroups = AchievementProgressGroup.InitFromData(dictionary.Values.ToArray());
	}
}
