public class CardSlowdown : Card
{
	public float slowMotionTime = 5f;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		if (PhotonNetwork.isMasterClient)
		{
			Singleton<SlowMotionManager>.instance.SlowMotionFor(slowMotionTime);
		}
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		if (base.isOnlineMaster)
		{
			Singleton<SlowMotionManager>.instance.SlowMotionFor(slowMotionTime);
		}
	}
}
