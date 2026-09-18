using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class CardHeadAhead : Card
{
	private const float HeadAddSize = 1.5f;

	private List<float> mOldCriticals = new List<float>();

	private NetworkObjectPool mPool;

	private bool mUsed;

	private bool mUsedLocaly;

	private float mRemainingTime;

	private Fractions mEnemyFraction;

	private PlayerController mPlayer;

	private PlayerController mEnemyPlayer;

	private bool mEventLocated;

	public float criticalChance => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.HeadAheadCritical).FLOATVALUE;

	private float timeInSeconds => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.HeadAheadTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.PrintableTimeDescription(timeInSeconds), MiscTools.FormatFloatNumberAsPercent(criticalChance));

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		if (PhotonNetwork.isMasterClient)
		{
			mRemainingTime = timeInSeconds;
			mUsed = true;
			AddBuff(fraction);
		}
		cardManager.CardWasUsed(this, fraction);
		mUsedLocaly = true;
		mOldCriticals.Clear();
		for (int i = 0; i < mPlayer.weaponInventory.usedWeapons.Count; i++)
		{
			mOldCriticals.Add(mPlayer.weaponInventory.usedWeapons[i].weapon.ammoSetup.criticalProbability);
			mPlayer.weaponInventory.usedWeapons[i].weapon.ammoSetup.criticalProbability = criticalChance;
		}
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			mRemainingTime = timeInSeconds;
			mUsed = true;
			AddBuff(fraction);
		}
	}

	private void OnAfterSpawned(AIObject aiObject)
	{
		if (aiObject.fraction != Fractions.None && aiObject.fraction == mEnemyFraction)
		{
			EnemyController enemyController = aiObject as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1.5f);
			}
		}
	}

	private void AddBuff(Fractions fraction)
	{
		if (!mEventLocated)
		{
			AIObject.AfterSpawned += OnAfterSpawned;
			mEventLocated = true;
		}
		mEnemyPlayer = PlayerController.GetEnemyOf(fraction);
		mEnemyFraction = mEnemyPlayer.fraction;
		mPool = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != Fractions.None && enemyController.fraction == mEnemyFraction && enemyController.canBeFreezed)
			{
				enemyController.UpdateHeadScale(1.5f);
			}
		}
	}

	private void RemoveBuff()
	{
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.fraction != Fractions.None && enemyController.fraction == mEnemyFraction)
			{
				enemyController.UpdateHeadScale(1f);
			}
		}
		DisconnectEvents();
	}

	private void RemoveCriticalBuff()
	{
		if (mUsedLocaly)
		{
			mUsedLocaly = false;
			for (int i = 0; i < mPlayer.weaponInventory.usedWeapons.Count; i++)
			{
				mPlayer.weaponInventory.usedWeapons[i].weapon.ammoSetup.criticalProbability = mOldCriticals[i];
			}
		}
	}

	public override void DisconnectEvents()
	{
		base.DisconnectEvents();
		if (mEventLocated)
		{
			AIObject.AfterSpawned -= OnAfterSpawned;
			mEventLocated = false;
			RemoveCriticalBuff();
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
			RemoveCriticalBuff();
			mUsed = false;
		}
	}
}
