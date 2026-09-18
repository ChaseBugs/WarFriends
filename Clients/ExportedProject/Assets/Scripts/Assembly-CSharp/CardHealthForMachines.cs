using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class CardHealthForMachines : Card
{
	private const string ingameIcoName = "game-card-ico-supersoldiers";

	private Fractions mFraction;

	private bool mEventLocated;

	private float mRemainingTime;

	private bool mUsed;

	public float multiplierMaxHealth => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.VehicleUpgradeCoef).FLOATVALUE;

	public float timeInSec => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.VehicleUpgradeTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.FormatFloatNumberAsPercent(multiplierMaxHealth), MiscTools.PrintableTimeDescription(timeInSec));

	protected override string mBonusName => MiscTools.FormatFloatNumberAsPlusPercent(multiplierMaxHealth);

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (!mEventLocated)
		{
			mRemainingTime = timeInSec;
			mFraction = fraction;
			mUsed = true;
			AIObject.AfterSpawned += AfterSpawn;
			mEventLocated = true;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(fraction, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < ally.Count; i++)
			{
				if (ally[i].destroyableObject.health > 0f)
				{
					float healAmount = ally[i].destroyableObject.maxHealth * multiplierMaxHealth;
					ally[i].destroyableObject.maxHealth *= multiplierMaxHealth + 1f;
					ally[i].destroyableObject.Heal(healAmount, isNetworkCopy: false);
					ally[i].destroyableObject.Sync();
					AIObject component = ally[i].GetComponent<AIObject>();
					if (component != null)
					{
						component.cardIconIndicator.Show("game-card-ico-supersoldiers", mRemainingTime, timeInSec, animated: true);
					}
					else
					{
						Debug.LogError("no AI object for: " + ally[i].name + " - " + ally[i].GetType().ToString());
					}
				}
			}
		}
		cardManager.CardWasUsed(this, fraction);
	}

	private void AfterSpawn(AIObject obj)
	{
		if (obj.fraction != mFraction)
		{
			return;
		}
		Type[] allMechanicalTypes = GameShootableEntity.GetAllMechanicalTypes();
		for (int i = 0; i < allMechanicalTypes.Length; i++)
		{
			if (obj.GetType() == allMechanicalTypes[i])
			{
				obj.destroyableObj.maxHealth *= multiplierMaxHealth + 1f;
				obj.destroyableObj.Refill();
				obj.cardIconIndicator.Show("game-card-ico-supersoldiers", mRemainingTime, timeInSec, animated: true);
				break;
			}
		}
	}

	public override void DisconnectEvents()
	{
		if (mEventLocated)
		{
			AIObject.AfterSpawned -= AfterSpawn;
			mEventLocated = false;
			List<GameShootableEntity> ally = GameShootableEntity.GetAlly(mFraction, GameShootableEntity.GetAllMechanicalTypes());
			for (int i = 0; i < ally.Count; i++)
			{
				if (ally[i].destroyableObject.health > 0f)
				{
					ally[i].destroyableObject.maxHealth /= multiplierMaxHealth + 1f;
					if (ally[i].destroyableObject.health > ally[i].destroyableObject.maxHealth)
					{
						ally[i].destroyableObject.Heal(ally[i].destroyableObject.maxHealth, isNetworkCopy: false);
					}
					ally[i].destroyableObject.Sync();
				}
			}
		}
		mRemainingTime = 0f;
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
			mUsed = false;
		}
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		foreach (GameShootableEntity botMechanicalUnit in botMechanicalUnits)
		{
			if (botMechanicalUnit.destroyableObject.healthRatio > 0.5f)
			{
				return true;
			}
		}
		return false;
	}
}
