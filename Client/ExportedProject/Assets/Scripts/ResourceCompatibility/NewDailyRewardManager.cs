using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

public class NewDailyRewardManager : DatabaseSerializedObjectGeneric<NewDailyRewardManager.NewDailyRewardData>
{
	[Serializable]
	[Preserve]
	public class NewDailyRewardData
	{
		public int dayOfCalendar;

		public int lastClaimedTime;

		public List<GameRewardData> currentRewards;
	}

	[CompilerGenerated]
	private Action IFPLKNKIBGL;

	[CompilerGenerated]
	private Action NNMAOABADIC;

	private static NewDailyRewardManager DJDBDKFAKHN;

	private List<GameReward> ACGECGMMEMH;

	public static NewDailyRewardManager instance => null;

	public bool hasData => false;

	public bool isTodayRewardClaimed => false;

	public int indexOfToday => 0;

	public List<GameReward> currentRewards => null;

	public event Action DataChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action RewardClaimed
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void OnDestroy()
	{
	}

	public void UpdateForTransition()
	{
	}

	protected override void InitData()
	{
	}

	public void GetConfirmationToClaimTodaysRewards(Action<bool> EPDCNPDNPIC)
	{
	}

	public void ClaimTodayReward()
	{
	}

	protected override void Awake()
	{
	}

	private void MIHHLNMIBON(DatabaseAction JMAECKMPPBI)
	{
	}
}
