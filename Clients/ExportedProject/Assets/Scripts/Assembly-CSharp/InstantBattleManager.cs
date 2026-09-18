using System.Collections.Generic;
using UnityEngine;

public class InstantBattleManager : Core_BaseScript
{
	public int mNumberOfBattles;

	public int goldCost;

	public int mXpAmmount;

	public int mWbAmmount;

	public int mGdAmmount;

	public int mExtraWarbucks;

	public List<Card> mWarcards;

	public InstantBattleRewardType mThirdRewardType;

	public bool responseArrive;

	private static InstantBattleManager mInstance;

	public static InstantBattleManager instance
	{
		get
		{
			mInstance = mInstance ?? ((InstantBattleManager)Object.FindObjectsOfType(typeof(InstantBattleManager))[0]);
			return mInstance;
		}
	}

	public void OnDestroy()
	{
		mInstance = null;
	}

	protected override void Start()
	{
		base.Start();
	}

	protected override void Awake()
	{
		base.Awake();
	}
}
