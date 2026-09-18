using UnityEngine;

public class CardTurret : Card
{
	private PlayerController mPlayer;

	protected override void Awake()
	{
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		mPlayer = PlayerController.GetPlayerOld(fraction);
		float progress = (float)mPlayer.playerProperties.level / (float)LevelManager.instance.maxDisplayLevel;
		SpawningManager.instance.SpawnForCard(Singleton<ObjectPoolDatabase>.instance.turret.preparedBehaviour, 1, progress, mPlayer.fraction, Vector3.zero);
		cardManager.CardWasUsed(this, fraction);
	}
}
