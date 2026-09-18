using System;
using System.Collections.Generic;
using Google2u;

public class CardAmmoBox : Card
{
	private const string ingameIcoName = "game-card-ico-ammobox";

	public float multiplierBullets => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.FormatFloatNumberAsPercent(multiplierBullets));

	protected override string mBonusName => MiscTools.FormatFloatNumberAsPlusPercent(multiplierBullets);

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(fraction);
		List<PlayerWeapon> usedWeapons = playerOld.weaponInventory.usedWeapons;
		foreach (PlayerWeapon item in usedWeapons)
		{
			int num = (int)Math.Ceiling((float)(int)item.weapon.startingAmmmoCount * multiplierBullets);
			item.weapon.ammoLeft += num;
		}
		cardManager.CardWasUsed(this, fraction);
		playerOld.cardIconIndicator.Show("game-card-ico-ammobox", 3f, 3f, animated: false);
	}
}
