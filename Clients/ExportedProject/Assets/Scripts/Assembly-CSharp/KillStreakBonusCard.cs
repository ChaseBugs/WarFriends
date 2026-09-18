using Google2u;
using UnityEngine;

public class KillStreakBonusCard : KillStreakBonus
{
	public string[] iconNames;

	public string[] bonusNames;

	public override bool ActivateBonus(GameObject killStreakBonusBox, PlayerController player)
	{
		base.ActivateBonus(killStreakBonusBox, player);
		if (player.isCurrentPlayer)
		{
			AddRandomCard();
		}
		return true;
	}

	private void AddRandomCard()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= iconNames.Length)
		{
			num = iconNames.Length - 1;
		}
		iconName = iconNames[num];
		dictionaryTranslationId = bonusNames[num];
		bonusName = Localization.Localize(dictionaryTranslationId);
	}

	public override float GetBonusProbability(PlayerController owner)
	{
		if (Singleton<GameController>.instance.gameType == GameController.GameType.DeathMatch && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 0f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.WarcardsUnlockLevel).FLOATVALUE;
		float result = 0f;
		if ((float)owner.playerProperties.level > fLOATVALUE)
		{
			result = base.GetBonusProbability(owner);
		}
		return result;
	}
}
