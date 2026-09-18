using Google2u;

public class CardAmmoThief : Card
{
	private const string ingameIcoName = "game-card-ico-emptymag";

	private float mBonusAmmo => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MiscTools.FormatFloatNumberAsPercent(mBonusAmmo));

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
		if (!enemyOf.photonView.isMine)
		{
			return;
		}
		PlayerController playerOld = PlayerController.GetPlayerOld(fraction);
		enemyOf.cardIconIndicator.Show("game-card-ico-emptymag", 3f, 3f, animated: false);
		Weapon weapon = enemyOf.weaponInventory.usedWeapons[1].weapon;
		int num = (int)((float)(int)weapon.startingAmmmoCount * mBonusAmmo);
		int num2 = 0;
		if (weapon.ammoLeft >= num)
		{
			num2 = num;
			weapon.ammoLeft -= num;
		}
		else
		{
			num2 = weapon.ammoLeft;
			weapon.ammoLeft = 0;
			num -= num2;
			if (weapon.ammoLeftInClip >= num)
			{
				num2 += num;
				weapon.ammoLeftInClip -= num;
			}
			else
			{
				num2 += weapon.ammoLeftInClip;
				weapon.ammoLeftInClip = 0;
			}
		}
		if (PhotonNetwork.offlineMode)
		{
			playerOld.AddAmmoRPC(1, num2);
			return;
		}
		playerOld.mPhotonView.RPC("AddAmmoRPC", playerOld.mPhotonView.owner, 1, num2);
	}
}
