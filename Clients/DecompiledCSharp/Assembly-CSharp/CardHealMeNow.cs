using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class CardHealMeNow : Card
{
	private const string ingameIcoName = "game-card-ico-healingstorm";

	public float minimalBotHealth = 1f;

	public bool instatnt = true;

	private float mRemainingTime;

	private bool mUsed;

	private PlayerController mPlayer;

	private float mAmmoutOfHeal;

	private int mLastUpdate;

	public virtual float amountOfHealMin => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.MedKitCoef).FLOATVALUE;

	public virtual float amountOfHealMax => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.MedKitCoef).FLOATVALUE;

	public virtual float timeInSec => 0f;

	public override string description => (!instatnt) ? Localization.LocalizeFormat(mDescriptionID, MiscTools.FormatFloatNumberAsPercent(amountOfHealMin), MiscTools.FormatFloatNumberAsPercent(amountOfHealMax), MiscTools.PrintableTimeDescription(timeInSec)) : Localization.LocalizeFormat(mDescriptionID, MiscTools.FormatFloatNumberAsPercent(amountOfHealMin));

	protected override string mBonusName => MiscTools.FormatFloatNumberAsPlusPercent(amountOfHealMin);

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		mAmmoutOfHeal = Random.Range(amountOfHealMin, amountOfHealMax);
		if (instatnt)
		{
			mPlayer.destroyableParts.Heal(mPlayer.destroyableParts.maxHealth * mAmmoutOfHeal, isNetworkCopy: false);
			mPlayer.destroyableParts.Sync();
			mPlayer.cardIconIndicator.Show("game-card-ico-healingstorm", 3f, 3f, animated: false);
		}
		else
		{
			mPlayer.cardIconIndicator.Show("game-card-ico-healingstorm", show: true);
			mRemainingTime = timeInSec;
			mUsed = true;
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		if (botHealthRatio >= minimalBotHealth)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}

	protected void Update()
	{
		if (!mUsed || instatnt)
		{
			return;
		}
		if (mRemainingTime > 0f)
		{
			mRemainingTime -= Time.deltaTime;
			mPlayer.cardIconIndicator.UpdateIndicator("game-card-ico-healingstorm", mRemainingTime / timeInSec);
			if (mLastUpdate != (int)Time.time)
			{
				mLastUpdate = (int)Time.time;
				mPlayer.destroyableParts.Heal(mPlayer.destroyableParts.maxHealth * mAmmoutOfHeal / timeInSec, isNetworkCopy: false);
			}
		}
		else
		{
			DisconnectEvents();
		}
	}

	public override void DisconnectEvents()
	{
		base.DisconnectEvents();
		if (mUsed)
		{
			mRemainingTime = 0f;
			mUsed = false;
			mPlayer.cardIconIndicator.Show("game-card-ico-healingstorm", show: false);
		}
	}
}
