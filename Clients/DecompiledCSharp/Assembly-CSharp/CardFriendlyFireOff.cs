public class CardFriendlyFireOff : Card
{
	private PlayerController mPlayer;

	private bool mUsed;

	private float mRemainingTime;

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		cardManager.CardWasUsed(this, fraction);
		mPlayer = PlayerController.GetPlayerOld(fraction);
		mUsed = true;
		mPlayer.friendlyKillOver = true;
	}
}
