using System.Collections.Generic;
using UnityEngine;

public class CardCantDieJustNow : Card
{
	public float buffTime = 10f;

	private NetworkObjectPool mPool;

	private bool mUsed;

	private float mRemainingTime;

	private Fractions mFraction;

	private bool mEventLocated;

	private List<EnemyController> mSoldiersWithBuff = new List<EnemyController>();

	private void MakeSoldiersImmortal(Fractions fraction)
	{
		MakeActiveSoldiersImmortal(fraction);
		if (!mEventLocated)
		{
			mFraction = fraction;
			AIObject.AfterSpawned += OnAfterSpawned;
			mEventLocated = true;
		}
	}

	private void MakeActiveSoldiersImmortal(Fractions fraction)
	{
		mPool = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction == fraction)
			{
				enemyController.canDie = false;
				mSoldiersWithBuff.Add(enemyController);
			}
		}
	}

	private void OnAfterSpawned(AIObject aiObject)
	{
		if (aiObject.fraction == mFraction)
		{
			EnemyController enemyController = aiObject as EnemyController;
			if (enemyController != null)
			{
				enemyController.canDie = false;
				mSoldiersWithBuff.Add(enemyController);
			}
		}
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MakeSoldiersImmortal(fraction);
			mRemainingTime = buffTime;
			mUsed = true;
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			MakeSoldiersImmortal(fraction);
			mRemainingTime = buffTime;
			mUsed = true;
		}
	}

	protected void Update()
	{
		if (mUsed)
		{
			if (mRemainingTime > 0f)
			{
				mRemainingTime -= Time.deltaTime;
			}
			else
			{
				RemoveBuff();
			}
		}
	}

	private void RemoveBuff()
	{
		DisconnectEvents();
		mRemainingTime = 0f;
		mUsed = false;
	}

	public override void DisconnectEvents()
	{
		if (mEventLocated)
		{
			AIObject.AfterSpawned -= OnAfterSpawned;
			mEventLocated = false;
		}
		foreach (EnemyController item in mSoldiersWithBuff)
		{
			item.canDie = true;
		}
		mSoldiersWithBuff.Clear();
	}
}
