using System;
using System.Collections.Generic;
using UnityEngine;

public class CardBackstab : Card
{
	public const string ingameIcoName = "game-card-ico-backstab";

	private NetworkObjectPool mPool;

	private PlayerController mPlayer;

	private void KillRandomEnemySoldier(Fractions fraction)
	{
		mPool = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController.fraction != fraction && enemyController.destroyableObject.health > 0f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			return;
		}
		float num = UnityEngine.Random.Range(0f, list.Count - 1);
		int index = (int)Math.Round(num, 0);
		DestroyableObject.DamageInfo info = new DestroyableObject.DamageInfo
		{
			damageAmount = list[index].destroyableObject.maxHealth,
			force = list[index].gameObject.transform.forward,
			isNetwork = false,
			isOneHit = true,
			owner = mPlayer
		};
		if (mPlayer.fraction != fraction)
		{
			foreach (KeyValuePair<int, PlayerController> player in PlayerController.players)
			{
				PlayerController value = player.Value;
				if (value.fraction == fraction)
				{
					info.owner = value;
				}
			}
		}
		info.partIndex = 0;
		info.weapon = null;
		info.type = DestroyableObject.DamageType.Shot;
		list[index].cardIconIndicator.Show("game-card-ico-backstab", show: true);
		list[index].destroyableObject.DoDamage(info);
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			mPlayer = PlayerController.GetPlayerOld(fraction);
			KillRandomEnemySoldier(mPlayer.fraction);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			mPlayer = PlayerController.GetPlayerOld(fraction);
			KillRandomEnemySoldier(fraction);
		}
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		if (opponentUnits.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
