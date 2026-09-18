using System.Collections.Generic;
using UnityEngine;

public class CardSabotage : Card
{
	private const string ingameIcoName = "game-card-ico-backstab";

	private PlayerController mPlayer;

	private void KillRandomEnemyMechanical(Fractions fraction)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.GetRandomOpponent(fraction, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(fraction, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 0; i < opponents.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = opponents[i];
			AIObject aIObject = gameShootableEntity2.mainGameEntity as AIObject;
			if (aIObject != null && gameShootableEntity2.isMain)
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 5f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.DamageInfo info = new DestroyableObject.DamageInfo
		{
			damageAmount = gameShootableEntity.destroyableObject.maxHealth,
			force = gameShootableEntity.mTransform.forward,
			isNetwork = false,
			isOneHit = true,
			owner = mPlayer,
			ignoreImmortality = true
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
		if (gameShootableEntity.mainGameEntity != null)
		{
			gameShootableEntity.mainGameEntity.cardIconIndicator.Show("game-card-ico-backstab", show: true);
		}
		gameShootableEntity.destroyableObject.DoDamage(info);
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			mPlayer = PlayerController.GetPlayerOld(fraction);
			KillRandomEnemyMechanical(mPlayer.fraction);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			mPlayer = PlayerController.GetPlayerOld(fraction);
			KillRandomEnemyMechanical(fraction);
		}
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		if (opponentMechanicalUnits.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
