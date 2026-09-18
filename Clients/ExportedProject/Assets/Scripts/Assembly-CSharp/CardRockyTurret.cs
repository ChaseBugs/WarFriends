using System.Collections;
using UnityEngine;

public class CardRockyTurret : Card
{
	private PlayerController mPlayer;

	private bool mIsOpponentCard;

	public override IEnumerator InitCard(bool isOpponentCard)
	{
		LevelBehaviour behaviour = Singleton<ObjectPoolDatabase>.instance.turretRockets.preparedBehaviour;
		mIsOpponentCard = isOpponentCard;
		yield return StartCoroutine(behaviour.PrepareVisualsForCardCoroutine(!mIsOpponentCard, mIsOpponentCard));
	}

	public override void ReleaseCard(bool isOpponent)
	{
		base.ReleaseCard(isOpponent);
		LevelBehaviour preparedBehaviour = Singleton<ObjectPoolDatabase>.instance.turretRockets.preparedBehaviour;
		base.ReleaseCard(isOpponent);
		preparedBehaviour.upgradeSlots.NullCardVisuals(!mIsOpponentCard, mIsOpponentCard);
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		float progress = (float)mPlayer.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.turretRockets.preparedBehaviour, 1, progress, mPlayer.fraction, Vector3.zero);
		cardManager.CardWasUsed(this, fraction);
	}
}
