using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class CardHealthForSoldiers : Card
{
	private const string ingameIcoName = "game-card-ico-supersoldiers";

	private NetworkObjectPool mPool;

	private Fractions mFraction;

	private bool mEventLocated;

	private float mRemainingTime;

	private bool mUsed;

	public float multiplierMaxHealth => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SuperSoldiersCoef).FLOATVALUE;

	public float timeInSec => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SuperSoldiersTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.FormatFloatNumberAsPercent(multiplierMaxHealth), MiscTools.PrintableTimeDescription(timeInSec));

	protected override string mBonusName => MiscTools.FormatFloatNumberAsPlusPercent(multiplierMaxHealth);

	private void ChangeMaxHealth(Fractions fraction)
	{
		if (!mEventLocated)
		{
			mRemainingTime = timeInSec;
			mUsed = true;
			mFraction = fraction;
			ChangeMaxHealthForActiveSoldiers(mFraction);
			AIObject.AfterSpawned += OnAfterSpawned;
			mEventLocated = true;
		}
	}

	private void ChangeMaxHealthForActiveSoldiers(Fractions fraction)
	{
		mPool = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == fraction && enemyController.destroyableObject.health > 0f && enemyController.canBeFreezed)
				{
					float healAmount = enemyController.destroyableObject.maxHealth * multiplierMaxHealth;
					enemyController.destroyableObject.maxHealth *= multiplierMaxHealth + 1f;
					enemyController.destroyableObject.Heal(healAmount, isNetworkCopy: false);
					enemyController.destroyableObject.Sync();
					enemyController.cardIconIndicator.Show("game-card-ico-supersoldiers", mRemainingTime, timeInSec, animated: true);
				}
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
				enemyController.destroyableObject.maxHealth *= multiplierMaxHealth + 1f;
				enemyController.destroyableObject.Refill();
				enemyController.cardIconIndicator.Show("game-card-ico-supersoldiers", mRemainingTime, timeInSec, animated: true);
			}
		}
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			ChangeMaxHealth(fraction);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			ChangeMaxHealth(fraction);
		}
	}

	public override void DisconnectEvents()
	{
		if (!mEventLocated)
		{
			return;
		}
		AIObject.AfterSpawned -= OnAfterSpawned;
		mEventLocated = false;
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (!item.isInstantiated)
			{
				continue;
			}
			EnemyController enemyController = (EnemyController)item;
			if (enemyController.fraction == mFraction && enemyController.destroyableObject.health != 0f)
			{
				enemyController.destroyableObject.maxHealth /= multiplierMaxHealth + 1f;
				if (enemyController.destroyableObject.health > enemyController.destroyableObject.maxHealth)
				{
					enemyController.destroyableObject.Heal(0f, isNetworkCopy: false);
				}
				enemyController.destroyableObject.Sync();
			}
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
			DisconnectEvents();
			mRemainingTime = 0f;
			mUsed = false;
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
