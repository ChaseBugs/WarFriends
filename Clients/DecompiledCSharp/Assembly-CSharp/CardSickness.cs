using System;
using UnityEngine;

public class CardSickness : Card
{
	public string ingameIconName = "game-card-ico-sickness";

	public float multiplierMaxHealth = 0.5f;

	public float multiplierDamage = 0.5f;

	private Fractions mFraction;

	private bool mStarted;

	private bool mEventLocated;

	private SpawningManagerDeathMatch.ArmyUnitDefinition mUsedDefinition;

	protected override string mBonusName => "-" + MiscTools.FormatFloatNumberAsPercent(multiplierMaxHealth);

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			SetCardEffect(fraction);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			SetCardEffect(fraction);
		}
	}

	private void SetCardEffect(Fractions fraction)
	{
		mFraction = fraction;
		mUsedDefinition = null;
		if (mStarted)
		{
			Debug.LogError("[CardSickness] - used again after spawning start, but before finish!!!");
			mStarted = false;
		}
		if (!mEventLocated)
		{
			mEventLocated = true;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.onStartSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance.onStartSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(SpawningStarted));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.onFinishSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Combine(instance2.onFinishSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(SpawningFinished));
			AIObject.AfterSpawned += OnAfterSpawned;
		}
	}

	public override void DisconnectEvents()
	{
		if (mEventLocated)
		{
			AIObject.AfterSpawned -= OnAfterSpawned;
			SpawningManagerDeathMatch instance = Singleton<SpawningManagerDeathMatch>.instance;
			instance.onStartSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance.onStartSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(SpawningStarted));
			SpawningManagerDeathMatch instance2 = Singleton<SpawningManagerDeathMatch>.instance;
			instance2.onFinishSpawning = (Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>)Delegate.Remove(instance2.onFinishSpawning, new Action<Fractions, SpawningManagerDeathMatch.ArmyUnitDefinition>(SpawningFinished));
			mStarted = false;
			mEventLocated = false;
		}
	}

	private void SpawningStarted(Fractions fraction, SpawningManagerDeathMatch.ArmyUnitDefinition def)
	{
		if (fraction != mFraction && def.armyUnit.behaviour is SoldierBehaviour)
		{
			if (mStarted)
			{
				Debug.LogError("[CardSickness] start new spawning before used spawning finish");
			}
			mStarted = true;
			mUsedDefinition = def;
		}
	}

	private void OnAfterSpawned(AIObject aiObject)
	{
		if (mStarted && aiObject.fraction != mFraction)
		{
			EnemyController enemyController = aiObject as EnemyController;
			if (enemyController != null && enemyController.canBeFreezed)
			{
				enemyController.ImproveAllWeapons(multiplierDamage);
				enemyController.destroyableObject.RefillTo(enemyController.destroyableObject.maxHealth * multiplierMaxHealth);
				enemyController.cardIconIndicator.Show(ingameIconName, show: true);
			}
		}
	}

	private void SpawningFinished(Fractions fraction, SpawningManagerDeathMatch.ArmyUnitDefinition def)
	{
		if (fraction != mFraction && mStarted && def == mUsedDefinition && mUsedDefinition != null)
		{
			DisconnectEvents();
		}
	}
}
