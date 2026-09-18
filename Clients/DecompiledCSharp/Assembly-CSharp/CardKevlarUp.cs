using Google2u;

public class CardKevlarUp : Card
{
	public KillStreakBonus bonusPrefab;

	private NetworkObjectPool mPool;

	public float kevlarStrength => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.KevlarUpCoef).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.FormatFloatNumberAsPercent(kevlarStrength));

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(fraction);
		string value = Localization.Localize("ID_BONUS-KEVLAR");
		foreach (KillStreakBonus activeBonuss in KillStreakBonus.activeBonusses)
		{
			if (activeBonuss.name.Contains(value))
			{
				cardManager.CardWasUsed(this, playerOld.fraction);
				return;
			}
		}
		playerOld.SetUpKevlar(kevlarStrength);
		cardManager.CardWasUsed(this, fraction);
	}
}
