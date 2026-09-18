using Google2u;

public class CardHealMeNowBig : CardHealMeNow
{
	public override float amountOfHealMin => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BigMedKitCoefMin).FLOATVALUE;

	public override float amountOfHealMax => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BigMedKitCoefMax).FLOATVALUE;

	public override float timeInSec => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BigMedKitTime).FLOATVALUE;

	protected override string mBonusName => $"{MiscTools.FormatFloatNumberAsPercentWithoutCharacter(amountOfHealMin)}-{MiscTools.FormatFloatNumberAsPercent(amountOfHealMax)}";
}
