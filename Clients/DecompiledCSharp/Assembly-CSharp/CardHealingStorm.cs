using System.Collections.Generic;

public class CardHealingStorm : Card
{
	private const string ingameIcoName = "game-card-ico-healingstorm";

	public float percentOfHeal = 0.5f;

	private NetworkObjectPool mPool;

	protected override string mBonusName => MiscTools.FormatFloatNumberAsPlusPercent(percentOfHeal);

	private void HealSoldiers(Fractions fraction)
	{
		mPool = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				EnemyController enemyController = (EnemyController)item;
				if (enemyController != null && enemyController.isInstantiated && enemyController.fraction == fraction && enemyController.destroyableObject.health != 0f && enemyController.destroyableObject.health != enemyController.destroyableObject.maxHealth)
				{
					enemyController.destroyableObject.Heal(enemyController.destroyableObject.maxHealth * percentOfHeal, isNetworkCopy: false);
					enemyController.destroyableObject.Sync();
					enemyController.cardIconIndicator.Show("game-card-ico-healingstorm", 3f, 3f, animated: false);
				}
			}
		}
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HealSoldiers(fraction);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			HealSoldiers(fraction);
		}
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		int num = 0;
		foreach (GameShootableEntity botUnit in botUnits)
		{
			if (!(botUnit.GetComponent<PlayerController>() != null) && botUnit.destroyableObject.healthRatio < 1f)
			{
				num++;
			}
		}
		if (num < 2)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
