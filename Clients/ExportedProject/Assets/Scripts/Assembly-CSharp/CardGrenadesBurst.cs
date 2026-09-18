using System.Collections;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class CardGrenadesBurst : Card
{
	private const int granadeCount = 3;

	private Grenade mGrenade;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(fraction);
		if (playerOld.currentPlayerPoint != null)
		{
			Transform snapTransform = playerOld.currentPlayerPoint.point.shield.hudIndicator.snapTransform;
			StartCoroutine(SpawnGrenades(snapTransform, playerOld));
		}
		cardManager.CardWasUsed(this, fraction);
	}

	private IEnumerator SpawnGrenades(Transform fireFromTransform, PlayerController player)
	{
		if (mGrenade == null)
		{
			mGrenade = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
		}
		mGrenade.spawnPoint = fireFromTransform;
		mGrenade.owner = player;
		List<GameShootableEntity> enemies = GameShootableEntity.GetOpponents(player.fraction);
		int toUse = Mathf.Min(3, enemies.Count);
		List<int> indeces = new List<int>(toUse);
		for (int i = 0; i < toUse; i++)
		{
			indeces.Add(Random.Range(0, enemies.Count - i));
			for (int j = 0; j < i; j++)
			{
				if (indeces[j] == indeces[i])
				{
					indeces[i] = enemies.Count - j - 1;
				}
			}
			yield return new WaitForSeconds(0.2f);
			mGrenade.Fire(enemies[indeces[i]].mTransform.position);
		}
		if (toUse < 3)
		{
			List<MapDefinition.DefendPosition> pointsForPlayer = Singleton<MapManager>.instance.currentMapDef.availablePoints;
			List<PlayerPoint> mPlayerPoints = new List<PlayerPoint>();
			foreach (MapDefinition.DefendPosition pPoint in pointsForPlayer)
			{
				if (pPoint.fraction != player.fraction && pPoint.point.shield.player == null)
				{
					mPlayerPoints.Add(pPoint.point);
				}
			}
			for (int k = toUse; k < 3; k++)
			{
				yield return new WaitForSeconds(0.2f);
				int index = Random.Range(0, mPlayerPoints.Count);
				GrenadeAmmoSetup setup = (GrenadeAmmoSetup)mGrenade.ammoSetup;
				if ((bool)setup)
				{
					float explodeDamage = Mathf.Lerp(t: (float)player.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel, a: Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, b: Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE);
					setup.explodeDamageAmount = explodeDamage;
					setup.damageAmount = explodeDamage * 0.1f;
				}
				mGrenade.Fire(mPlayerPoints[index].shield.transform.position);
				mPlayerPoints[index] = mPlayerPoints[mPlayerPoints.Count - 1];
				mPlayerPoints.RemoveAt(mPlayerPoints.Count - 1);
			}
		}
		yield return new WaitForSeconds(0.2f);
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
