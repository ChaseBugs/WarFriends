using UnityEngine.AI;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class CardMineYourStep : Card
{
	private const string ingameIcoName = "game-card-ico-mineyourstep-full";

	private MineAmmo mMineAmmo;

	private Vector3 mMinePosition;

	private PlayerController mPlayer;

	private float mRemainingTime;

	private bool mUsed;

	public float totalTime = 15f;

	public float mineDamagePercentage => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.MineYourStepDamageCoef).FLOATVALUE;

	public override void ReleaseCard(bool isOpponent)
	{
		mUsed = false;
		mMineAmmo = null;
		mRemainingTime = float.MaxValue;
	}

	private Vector3 SelectRandomPosition(Fractions callerFraction)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		PlayerController enemyOf = PlayerController.GetEnemyOf(callerFraction);
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction != callerFraction)
			{
				list.Add(item.point);
			}
		}
		int num = Random.Range(1, 4);
		int index = num - 1;
		return Vector3.Lerp(list[index].transform.position, list[num].transform.position, 0.5f);
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
			float num = mRemainingTime / totalTime;
			if (mMineAmmo != null)
			{
				mMineAmmo.blinkInterval = num * 0.5f + 0.1f;
				mMineAmmo.cardIconIndicator.UpdateIndicator("game-card-ico-mineyourstep-full", num);
			}
		}
		else
		{
			mRemainingTime = 0f;
			mUsed = false;
			if (mMineAmmo != null)
			{
				mMineAmmo.cardIconIndicator.Show("game-card-ico-mineyourstep-full", show: false);
				mMineAmmo.Boom();
			}
		}
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		base.UseCard(cardManager, fraction);
		mPlayer = PlayerController.GetPlayerOld(fraction);
		PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
		Vector3 sourcePosition = SelectRandomPosition(fraction);
		NavMesh.SamplePosition(sourcePosition, out var hit, 10f, 1);
		Mine landMine = mPlayer.weaponInventory.landMine;
		landMine.cadence = -0.1f;
		MineAmmoSetup mineAmmoSetup = landMine.ammoSetup as MineAmmoSetup;
		if ((bool)mineAmmoSetup)
		{
			mineAmmoSetup.damageAmount = 0.1f * mineDamagePercentage * enemyOf.destroyableParts.maxHealth;
			mineAmmoSetup.explodeDamageAmount = mineDamagePercentage * enemyOf.destroyableParts.maxHealth;
		}
		mMinePosition = hit.position;
		mMineAmmo = (MineAmmo)landMine.Fire(mMinePosition);
		if (mMineAmmo != null)
		{
			mMineAmmo.cardIconIndicator.Show("game-card-ico-mineyourstep-full", show: true);
			mMineAmmo.beep = true;
		}
		mRemainingTime = totalTime;
		mUsed = true;
		cardManager.CardWasUsed(this, mPlayer.fraction);
	}
}
