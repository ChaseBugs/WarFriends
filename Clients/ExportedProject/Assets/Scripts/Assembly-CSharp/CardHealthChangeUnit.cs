using System;
using UnityEngine;

public class CardHealthChangeUnit : Card
{
	public float multiplierMaxHealth = 0.5f;

	public string ingameIconName = "game-card-ico-healingstorm";

	public bool sameFraction;

	public bool showIconOnEnemy;

	private Fractions mFraction;

	private bool mStarted;

	private bool mEventLocated;

	private PlayerController mPlayer;

	private SpawningManagerDeathMatch.ArmyUnitDefinition mUsedDefinition;

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
			Debug.LogError("[CardHealthChangeUnit] - used again after spawning start, but before finish!!!");
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
		if (showIconOnEnemy)
		{
			mPlayer = PlayerController.GetEnemyOf(fraction);
		}
		else
		{
			mPlayer = PlayerController.GetPlayerOld(fraction);
		}
		mPlayer.cardIconIndicator.Show(ingameIconName, show: true);
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
			mPlayer.cardIconIndicator.Show(ingameIconName, show: false);
		}
	}

	private void OnAfterSpawned(AIObject aiObject)
	{
		if (!mStarted || ((aiObject.fraction == mFraction) ^ sameFraction))
		{
			return;
		}
		EnemyController enemyController = aiObject as EnemyController;
		if (enemyController != null)
		{
			if ((double)multiplierMaxHealth > 1.0)
			{
				enemyController.destroyableObject.maxHealth *= multiplierMaxHealth;
				enemyController.destroyableObject.Refill();
			}
			else
			{
				enemyController.destroyableObject.RefillTo(enemyController.destroyableObject.maxHealth * multiplierMaxHealth);
			}
		}
	}

	private void SpawningStarted(Fractions fraction, SpawningManagerDeathMatch.ArmyUnitDefinition def)
	{
		if (!((fraction == mFraction) ^ sameFraction))
		{
			if (mStarted)
			{
				Debug.LogError("[CardHealthChangeUnit] start new spawning before used spawning finish");
			}
			mStarted = true;
			mUsedDefinition = def;
		}
	}

	private void SpawningFinished(Fractions fraction, SpawningManagerDeathMatch.ArmyUnitDefinition def)
	{
		if (!((fraction == mFraction) ^ sameFraction) && mStarted && def == mUsedDefinition && mUsedDefinition != null)
		{
			DisconnectEvents();
		}
	}
}
