using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class CardLandmine : Card
{
	private const string ingameIcoName = "game-card-ico-mineyourstep-full";

	private Vector3 mMinePosition;

	private List<EnemyPoint> SelectRandomPosition(Fractions callerFraction)
	{
		List<EnemyPoint> enemyPoints = SpawningManager.instance.enemyPoints;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in enemyPoints)
		{
			if (item.enemyPointType == EnemyPoint.EnemyPointType.Hiding && item.fraction != callerFraction)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(3, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		base.UseCard(cardManager, fraction);
		PlayerController playerOld = PlayerController.GetPlayerOld(fraction);
		List<EnemyPoint> list = SelectRandomPosition(fraction);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 10f, 1);
			Mine landMine = playerOld.weaponInventory.landMine;
			landMine.cadence = -0.1f;
			mMinePosition = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)landMine.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerOld.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.damageAmount = (mineAmmoSetup.explodeDamageAmount = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE, t)) * 0.1f;
			}
			MineAmmo mineAmmo = landMine.Fire(mMinePosition) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.cardIconIndicator.Show("game-card-ico-mineyourstep-full", show: true);
			}
			else
			{
				Debug.LogError("Mine ammo null");
			}
		}
		cardManager.CardWasUsed(this, playerOld.fraction);
	}
}
