using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

public sealed class AchievementProgressGroups : DatabaseSerializedObjectGeneric<AchievementProgressGroups.AchievementsData>
{
	public sealed class AchievementsData
	{
		[JsonProperty("data")]
		public AchievementProgressGroupData[] achievementProgressGroupData;
	}

	public AchievementProgressGroup[] achievementProgressGroups { get; set; }

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
					throw new InvalidOperationException(string.Format("Achievements config for the '{0}' group contains less achievement definitions than is currently stored on the server.", Singleton<AchievementsManager>.instance.achievementTypes[value.id]));
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
