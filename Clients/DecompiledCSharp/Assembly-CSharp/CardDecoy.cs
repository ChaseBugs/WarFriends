using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDecoy : Card
{
	public string mineTexturePath;

	public string opponentTexturePath;

	public static Texture2D mRedTexture;

	public static Texture2D mBlueTexture;

	private bool mIsOpponentCard;

	public override IEnumerator InitCard(bool isOpponentCard)
	{
		mIsOpponentCard = isOpponentCard;
		if (mIsOpponentCard && mRedTexture == null)
		{
			mRedTexture = Resources.Load<Texture2D>(opponentTexturePath);
		}
		if (!mIsOpponentCard && mBlueTexture == null)
		{
			mBlueTexture = Resources.Load<Texture2D>(mineTexturePath);
		}
		yield break;
	}

	public override void ReleaseCard(bool isOpponent)
	{
		base.ReleaseCard(isOpponent);
		mRedTexture = null;
		mBlueTexture = null;
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		base.UseCard(cardManager, fraction);
		cardManager.CardWasUsed(this, fraction);
		StartCoroutine(SpawnDecoy(fraction));
	}

	private IEnumerator SpawnDecoy(Fractions fraction)
	{
		List<EnemyPointObstacle> freeObstacles = new List<EnemyPointObstacle>();
		int decoysToSpawn = 3;
		while (true)
		{
			foreach (EnemyPoint enemyPoint in Singleton<MapManager>.instance.currentMapDef.enemyPointsCollection.enemyPoints)
			{
				EnemyPointObstacle enemyPointObstacle = enemyPoint as EnemyPointObstacle;
				if (enemyPointObstacle != null && enemyPointObstacle.isFree && enemyPointObstacle.fraction == fraction)
				{
					freeObstacles.Add(enemyPointObstacle);
				}
			}
			if (freeObstacles.Count > 0)
			{
				decoysToSpawn--;
				SpawnDecoyOnRandomPosition(fraction, freeObstacles);
				if (decoysToSpawn <= 0)
				{
					break;
				}
				freeObstacles.Clear();
			}
			else
			{
				Debug.LogWarning(string.Format("No free position for decoy!", freeObstacles.Count));
				yield return new WaitForRealSeconds(0.2f);
			}
		}
	}

	private void SpawnDecoyOnRandomPosition(Fractions fraction, List<EnemyPointObstacle> freeObstacles)
	{
		EnemyPointObstacle enemyPointObstacle = freeObstacles[Random.Range(0, freeObstacles.Count)];
		NavMesh.SamplePosition(enemyPointObstacle.position, out var hit, 10f, 1);
		Vector3 vector = GetLookTarget(fraction).ReplaceY(hit.position.y);
		Quaternion rotation = Quaternion.LookRotation(vector - hit.position, Vector3.up);
		Decoy decoy = ObjectPoolDatabase.networkPool.InstantiateNetwork(Singleton<ObjectPoolDatabase>.instance.decoy, hit.position, rotation) as Decoy;
		decoy.Setup(enemyPointObstacle);
	}

	private Vector3 GetLookTarget(Fractions fraction)
	{
		int num = 0;
		Vector3 zero = Vector3.zero;
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.currentMapDef.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction != fraction)
			{
				num++;
				zero += item.point.shield.shotPosition.position;
			}
		}
		if (num > 0)
		{
			zero /= (float)num;
		}
		return zero;
	}

	public override void DisconnectEvents()
	{
		base.DisconnectEvents();
		StopAllCoroutines();
		mRedTexture = null;
		mBlueTexture = null;
	}
}
