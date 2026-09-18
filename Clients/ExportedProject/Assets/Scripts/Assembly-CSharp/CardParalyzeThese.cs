using System.Collections.Generic;
using UnityEngine;

public class CardParalyzeThese : Card
{
	private const float TimeInSeconds = 10f;

	private const string ingameIcoName = "game-card-ico-paralyzethese";

	private bool mUsed;

	private float mRemainingTime;

	private Fractions mFraction;

	private List<EnemyController> mUseList;

	private bool mEventLocated;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			Paralyze(fraction);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	private void Paralyze(Fractions fraction)
	{
		mFraction = fraction;
		mUsed = true;
		mRemainingTime = 10f;
		List<PoolableObject> objectsMadeOfPrefab = ObjectPoolDatabase.networkPool.GetObjectsMadeOfPrefab(Singleton<ObjectPoolDatabase>.instance.enemy);
		List<EnemyController> list = new List<EnemyController>();
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			EnemyController enemyController = item as EnemyController;
			if (enemyController != null && enemyController.isInstantiated && enemyController.isAlive && enemyController.fraction != Fractions.None && enemyController.fraction != mFraction && enemyController.canBeFreezed)
			{
				list.Add(enemyController);
			}
		}
		if (mUseList == null)
		{
			mUseList = new List<EnemyController>();
		}
		for (int i = 0; i < 3; i++)
		{
			if (list.Count < 1)
			{
				break;
			}
			int index = Random.Range(0, list.Count);
			list[index].FreezByCard(freeze: true);
			mUseList.Add(list[index]);
			list[index].cardIconIndicator.Show("game-card-ico-paralyzethese", show: true);
			list[index] = list[list.Count - 1];
			list.RemoveAt(list.Count - 1);
		}
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			Paralyze(fraction);
		}
	}

	public override void DisconnectEvents()
	{
		if (mUseList == null)
		{
			return;
		}
		for (int i = 0; i < mUseList.Count; i++)
		{
			if (mUseList[i] != null && mUseList[i].isAlive && mUseList[i].fraction != mFraction)
			{
				mUseList[i].FreezByCard(freeze: false);
				mUseList[i].cardIconIndicator.Show("game-card-ico-paralyzethese", show: false);
			}
		}
		mUseList.Clear();
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
			for (int i = 0; i < mUseList.Count; i++)
			{
				if (mUseList[i] != null && mUseList[i].isAlive && mUseList[i].fraction != mFraction)
				{
					mUseList[i].cardIconIndicator.UpdateIndicator("game-card-ico-paralyzethese", mRemainingTime / 10f);
				}
				else
				{
					mUseList[i] = null;
				}
			}
		}
		else
		{
			DisconnectEvents();
			mRemainingTime = 0f;
			mUsed = false;
		}
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
