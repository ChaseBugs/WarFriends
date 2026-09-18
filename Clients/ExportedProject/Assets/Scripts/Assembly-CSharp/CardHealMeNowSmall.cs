using Google2u;

public class CardHealMeNowSmall : CardHealMeNow
{
	public override float amountOfHealMin => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SmallMedKitCoef).FLOATVALUE;

	public override float amountOfHealMax => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SmallMedKitCoef).FLOATVALUE;

	public override float timeInSec => 0f;
}
