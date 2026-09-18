using System.Collections;
using UnityEngine;

public class CardHeavyTurret : Card
{
	private bool mIsOpponentCard;

	protected override void Awake()
	{
	}

	public override IEnumerator InitCard(bool isOpponentCard)
	{
		LevelBehaviour behaviour = Singleton<ObjectPoolDatabase>.instance.heavyTurret.preparedBehaviour;
		mIsOpponentCard = isOpponentCard;
		yield return StartCoroutine(behaviour.PrepareVisualsForCardCoroutine(!mIsOpponentCard, mIsOpponentCard));
	}

	public override void ReleaseCard(bool isOpponent)
	{
		base.ReleaseCard(isOpponent);
		LevelBehaviour preparedBehaviour = Singleton<ObjectPoolDatabase>.instance.heavyTurret.preparedBehaviour;
		base.ReleaseCard(isOpponent);
		preparedBehaviour.upgradeSlots.NullCardVisuals(!mIsOpponentCard, mIsOpponentCard);
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(fraction);
		float progress = (float)playerOld.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.heavyTurret.preparedBehaviour, 1, progress, playerOld.fraction, Vector3.zero);
		cardManager.CardWasUsed(this, fraction);
	}
}
