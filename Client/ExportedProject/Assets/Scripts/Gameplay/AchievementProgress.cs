using UnityEngine;

public sealed class AchievementProgress
{
	private int _id;

	private AchievementProgressGroup mGroup;

	private AchievementsManager.CHIDHGCKCIK mAchievementDefinition;

	private AchievementProgressData mData;

	public int id => _id;

	public AchievementProgressGroup group => mGroup;

	public AchievementsManager.CHIDHGCKCIK achievementDefinition => mAchievementDefinition;

	public int targetValue => mAchievementDefinition.JAJGLLMBPNB;

	public PLGIEHJKMNP achievementRewardType
	{
		get
		{
			if ((float)mAchievementDefinition.FKIGMDIHKAA != 0f)
			{
				return PLGIEHJKMNP.Gold;
			}
			if ((float)mAchievementDefinition.BJFGHKNAIIE != 0f)
			{
				return PLGIEHJKMNP.WarBucks;
			}
			if ((float)mAchievementDefinition.KMCEFANOLKM != 0f)
			{
				return PLGIEHJKMNP.Scraps;
			}
			if ((float)mAchievementDefinition.ELCDCFHKGHC != 0f)
			{
				return PLGIEHJKMNP.Tickets;
			}
			return PLGIEHJKMNP.WarBucks;
		}
	}

	public bool isClaimed
	{
		get
		{
			return mData.claimed;
		}
		set
		{
			mData.claimed = value;
		}
	}

	public float progress => GetProgress(mGroup.localCurrentValue);

	public bool isCompleted => IsCompleted(mGroup.localCurrentValue);

	public CINKACCJIHG state => GetState(mGroup.localCurrentValue);

	public void Init(int id, AchievementProgressGroup group, AchievementProgressData data)
	{
		_id = id;
		mGroup = group;
		mAchievementDefinition = Singleton<AchievementsManager>.instance.achievements[group.id][id];
		mData = data;
	}

	public float GetProgress(int groupLocalCurrentValue)
	{
		return (targetValue != 0) ? EJLBCNBODJG.CBHCAEBJNOE((float)groupLocalCurrentValue / (float)targetValue) : 1f;
	}

	public bool IsCompleted(int groupLocalCurrentValue)
	{
		float num = GetProgress(groupLocalCurrentValue);
		return num >= 1f || Mathf.Approximately(num, 1f);
	}

	public CINKACCJIHG GetState(int groupLocalCurrentValue)
	{
		if (!IsCompleted(groupLocalCurrentValue))
		{
			return CINKACCJIHG.InProgress;
		}
		if (!isClaimed)
		{
			return CINKACCJIHG.Completed;
		}
		return CINKACCJIHG.Claimed;
	}
}
