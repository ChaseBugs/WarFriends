using System.Collections;
using UnityEngine;

public class CardSpawnUnit : Card
{
	public LevelBehaviour behaviour;

	public int count = 1;

	public float spawnDelay;

	private bool mIsOpponentCard;

	public override IEnumerator InitCard(bool isOpponentCard)
	{
		mIsOpponentCard = isOpponentCard;
		yield return StartCoroutine(behaviour.PrepareVisualsForCardCoroutine(!mIsOpponentCard, mIsOpponentCard));
	}

	public override void ReleaseCard(bool isOpponent)
	{
		base.ReleaseCard(isOpponent);
		behaviour.upgradeSlots.NullCardVisuals(!mIsOpponentCard, mIsOpponentCard);
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		cardManager.CardWasUsed(this, fraction);
		StartCoroutine(SpawnUnits(fraction));
	}

	private IEnumerator SpawnUnits(Fractions fraction)
	{
		PlayerController player = PlayerController.GetPlayerOld(fraction);
		float progress = (float)player.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel;
		for (int i = 0; i < count; i++)
		{
			SpawningManager.instance.SpawnForCard(behaviour, 1, progress, player.fraction, Vector3.one * 9999f);
			if (spawnDelay > 0f)
			{
				yield return new WaitForSeconds(spawnDelay);
			}
		}
	}

	public override void DisconnectEvents()
	{
		base.DisconnectEvents();
		StopAllCoroutines();
	}
}
