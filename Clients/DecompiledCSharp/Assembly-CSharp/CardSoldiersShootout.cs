using System.Collections.Generic;
using UnityEngine;

public class CardSoldiersShootout : Card
{
	private const string ingameIcoName = "game-card-ico-triggerhappy";

	public float multiplierTimeToNextShoot = 0.75f;

	public float durationInSec = 60f;

	private NetworkObjectPool mPool;

	private Fractions mFraction;

	private bool mEventLocated;

	private float mRemainingTime;

	private bool mUse;

	protected override string mBonusName => MiscTools.FormatFloatNumberAsPlusPercent(1f - multiplierTimeToNextShoot);

	private void ChangeSoldiersShootout(Fractions fraction)
	{
		if (!mEventLocated)
		{
			mRemainingTime = durationInSec;
			mUse = true;
			mFraction = fraction;
			ChangeActiveSoldiersShootout(mFraction);
			AIObject.AfterSpawned += OnAfterSpawned;
			mEventLocated = true;
		}
	}

	private void ChangeActiveSoldiersShootout(Fractions fraction)
	{
		mPool = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.destroyableObject.health != 0f && enemyController.fraction == fraction && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime *= multiplierTimeToNextShoot;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime *= multiplierTimeToNextShoot;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin *= multiplierTimeToNextShoot;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax *= multiplierTimeToNextShoot;
				enemyController.cardIconIndicator.Show("game-card-ico-triggerhappy", mRemainingTime, durationInSec, animated: true);
			}
		}
	}

	private void OnAfterSpawned(AIObject aiObject)
	{
		if (aiObject.fraction == mFraction)
		{
			EnemyController enemyController = aiObject as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime *= multiplierTimeToNextShoot;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime *= multiplierTimeToNextShoot;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin *= multiplierTimeToNextShoot;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax *= multiplierTimeToNextShoot;
				enemyController.cardIconIndicator.Show("game-card-ico-triggerhappy", mRemainingTime, durationInSec, animated: true);
			}
		}
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			ChangeSoldiersShootout(fraction);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			ChangeSoldiersShootout(fraction);
		}
	}

	protected void Update()
	{
		if (!mUse)
		{
			return;
		}
		if (mRemainingTime > 0f)
		{
			mRemainingTime -= Time.deltaTime;
			return;
		}
		mRemainingTime = 0f;
		mUse = false;
		DisconnectEvents();
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.destroyableObject.health != 0f && enemyController.fraction == mFraction && enemyController.canBeFreezed)
			{
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.minShootTime /= multiplierTimeToNextShoot;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.maxShootTime /= multiplierTimeToNextShoot;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMin /= multiplierTimeToNextShoot;
				enemyController.soldierBehaviour.soldierBehaviourDefinititon.walkShotTimeMax /= multiplierTimeToNextShoot;
			}
		}
	}

	public override void DisconnectEvents()
	{
		if (mEventLocated)
		{
			AIObject.AfterSpawned -= OnAfterSpawned;
			mEventLocated = false;
		}
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		if (botUnits.Count < 3)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
