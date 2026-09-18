using System.Collections.Generic;
using UnityEngine;

public class CardPoisonedArmy : Card
{
	private const float poisonDelay = 0.5f;

	private const float buffTime = 5f;

	private bool mUsed;

	private Fractions mFraction;

	private PlayerController mPlayer;

	private float mRemainingTime;

	private float mFromLastPoison;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mUsed = true;
		mFraction = fraction;
		mPlayer = PlayerController.GetPlayerOld(mFraction);
		mRemainingTime = 5f;
		DoPoisonDamage();
		cardManager.CardWasUsed(this, fraction);
	}

	private void DoPoisonDamage()
	{
		DestroyableObject.DamageInfo info = new DestroyableObject.DamageInfo
		{
			owner = mPlayer,
			type = DestroyableObject.DamageType.Poison
		};
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = item as EnemyController;
				if (enemyController != null && enemyController.isAlive && enemyController.fraction != mFraction && enemyController.canBeFreezed)
				{
					info.damageAmount = enemyController.destroyableObj.maxHealth / 5f * 0.5f * Random.Range(0.5f, 0.75f);
					enemyController.destroyableObject.DoDamage(info);
				}
			}
		}
	}

	public override void DisconnectEvents()
	{
		mUsed = false;
	}

	protected void Update()
	{
		if (!mUsed)
		{
			return;
		}
		if (mRemainingTime > 0f)
		{
			mRemainingTime -= Time.deltaTime;
			mFromLastPoison += Time.deltaTime;
			if (mFromLastPoison > 0.5f)
			{
				DoPoisonDamage();
				mFromLastPoison -= 0.5f;
			}
		}
		else
		{
			mUsed = false;
			mRemainingTime = 0f;
		}
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		if (opponentUnits.Count < 3)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
