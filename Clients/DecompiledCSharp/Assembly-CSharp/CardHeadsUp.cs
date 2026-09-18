using System.Collections.Generic;
using UnityEngine;

public class CardHeadsUp : Card
{
	private const float multiplayer = 1.5f;

	private const string ingameIcoName = "game-card-ico-headsup";

	public float buffTime = 15f;

	private NetworkObjectPool mPool;

	private bool mUsed;

	private float mRemainingTime;

	private Fractions mFraction;

	private bool mEventLocated;

	private void GetSoldiersParts(Fractions fraction)
	{
		ChangeHeadWeighForActiveSoldiers(fraction);
		if (!mEventLocated)
		{
			AIObject.AfterSpawned -= OnAfterSpawned;
			AIObject.AfterSpawned += OnAfterSpawned;
			mEventLocated = true;
		}
	}

	private void ChangeHeadWeighForActiveSoldiers(Fractions fraction)
	{
		mFraction = fraction;
		mPool = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != Fractions.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(1.5f, 1);
				enemyController.cardIconIndicator.Show("game-card-ico-headsup", buffTime, buffTime, animated: true);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
		enemyOf.ChangeWeightForDestroyablePart(1.5f, 1);
		enemyOf.cardIconIndicator.Show("game-card-ico-headsup", buffTime, buffTime, animated: true);
		enemyOf = PlayerController.GetPlayerOld(fraction);
		enemyOf.ChangeWeightForDestroyablePart(1.5f, 1);
		enemyOf.cardIconIndicator.Show("game-card-ico-headsup", buffTime, buffTime, animated: true);
	}

	private void OnAfterSpawned(AIObject aiObject)
	{
		if (aiObject.fraction != Fractions.None)
		{
			EnemyController enemyController = aiObject as EnemyController;
			if (enemyController != null)
			{
				enemyController.ChangeWeightForDestroyablePart(1.5f, 1);
				enemyController.cardIconIndicator.Show("game-card-ico-headsup", mRemainingTime, buffTime, animated: true);
			}
		}
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			GetSoldiersParts(fraction);
			mRemainingTime = buffTime;
			mUsed = true;
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			GetSoldiersParts(fraction);
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
				return;
			}
			RemoveBuff();
			mUsed = false;
		}
	}

	private void RemoveBuff()
	{
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.fraction != Fractions.None && enemyController.isInstantiated && enemyController.isAlive)
			{
				enemyController.ChangeWeightForDestroyablePart(2f / 3f, 1);
			}
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(mFraction);
		enemyOf.ChangeWeightForDestroyablePart(2f / 3f, 1);
		enemyOf = PlayerController.GetPlayerOld(mFraction);
		enemyOf.ChangeWeightForDestroyablePart(2f / 3f, 1);
	}

	public override void DisconnectEvents()
	{
		if (mEventLocated)
		{
			AIObject.AfterSpawned -= OnAfterSpawned;
			mEventLocated = false;
		}
	}
}
