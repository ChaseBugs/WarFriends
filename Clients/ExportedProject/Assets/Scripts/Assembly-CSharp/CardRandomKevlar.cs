using System.Collections.Generic;
using UnityEngine;

public class CardRandomKevlar : Card
{
	private NetworkObjectPool mPool;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPool = ObjectPoolDatabase.networkPool;
		List<PoolableObject> objectsMadeOfPrefab = mPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		List<EnemyController> list = new List<EnemyController>();
		for (int i = 0; i < objectsMadeOfPrefab.Count; i++)
		{
			if (objectsMadeOfPrefab[i].isInstantiated)
			{
				EnemyController enemyController = (EnemyController)objectsMadeOfPrefab[i];
				if (enemyController.fraction == fraction && enemyController.destroyableObject.health > 0f && enemyController.canBeFreezed)
				{
					list.Add(enemyController);
				}
			}
		}
		if (list.Count == 0)
		{
			cardManager.CardWasUsed(this, fraction);
			return;
		}
		List<int> list2 = new List<int>();
		while (list2.Count < Mathf.Min(3, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(num));
			list2.Add(num);
			list[num].SetUpKevlar();
		}
		list.Clear();
		cardManager.CardWasUsed(this, fraction);
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		if (botUnits.Count <= 1)
		{
			return false;
		}
		return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
	}
}
