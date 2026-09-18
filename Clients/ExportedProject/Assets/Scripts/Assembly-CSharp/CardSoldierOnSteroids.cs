using System;
using Google2u;
using UnityEngine;

public class CardSoldierOnSteroids : Card
{
	private const string ingameIconName = "game-card-ico-meatheads-full";

	private bool mRegisterEvents;

	private Fractions mFraction;

	private bool mStarted;

	private SpawningManagerDeathMatch.ArmyUnitDefinition mUsedDefinition;

	private bool mWasSoilder;

	private float damageMult => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SoldierOnSteroidsCoef).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.FormatFloatNumberAsPercent(damageMult));

	protected override string mBonusName => MiscTools.FormatFloatNumberAsPlusPercent(damageMult);

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			RegisterEvents(fraction);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			RegisterEvents(fraction);
		}
	}

	private void RegisterEvents(Fractions fraction)
	{
		mWasSoilder = false;
		mFraction = fraction;
		mUsedDefinition = null;
		if (mStarted)
		{
			Debug.LogError("[CardSoldierOnSteroids] - used agan after spawning start, but before finish!!!");
			mStarted = false;
		}
		if (!mRegisterEvents)
		{
			mRegisterEvents = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.onStartSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.onStartSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(SpawningStarted));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.onFinishSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.onFinishSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(SpawningFinished));
			AIObject.AfterSpawned += SpawnedArmy;
		}
	}

	private void SpawnedArmy(AIObject aiObject)
	{
		if (mStarted && aiObject.fraction == mFraction)
		{
			EnemyController enemyController = aiObject as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.destroyableObj.maxHealth *= 1f + damageMult;
				enemyController.destroyableObj.Refill();
				enemyController.ImproveAllWeapons(1f + damageMult);
				enemyController.cardIconIndicator.Show("game-card-ico-meatheads-full", show: true);
				mWasSoilder = true;
			}
		}
	}

	private void SpawningStarted(Fractions fraction, SpawningManagerDeathMatch.ArmyUnitDefinition def)
	{
		if (fraction == mFraction)
		{
			mStarted = true;
			mUsedDefinition = def;
		}
	}

	private void SpawningFinished(Fractions fraction, SpawningManagerDeathMatch.ArmyUnitDefinition def)
	{
		if (fraction == mFraction && mStarted && def == mUsedDefinition && mUsedDefinition != null && mWasSoilder)
		{
			DisconnectEvents();
		}
	}

	public override void DisconnectEvents()
	{
		if (mRegisterEvents)
		{
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.onStartSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.onStartSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(SpawningStarted));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.onFinishSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.onFinishSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(SpawningFinished));
			AIObject.AfterSpawned -= SpawnedArmy;
			mRegisterEvents = false;
			mStarted = false;
		}
	}
}
