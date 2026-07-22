using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class KillStreakBonusAddCredits : KillStreakBonus
{
	private int HAFMGCFMCPC;

	public override string fullName => "+" + HAFMGCFMCPC;

	[SpecialName]
	public virtual string OOKKCILIIAE()
	{
		return "ID_GUI_SILVER" + HAFMGCFMCPC;
	}

	public override bool GONLNEJFBKH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.FJAJKEBLFOE(NPNGCEJFAOP, KHLGDCHJJPB);
		float num = LevelManager.instance.InterpolateNumbersBasedOnLevel(5, Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GooglePlayLoginReward).FLOATVALUE, 1, Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AddGoldMin).FLOATVALUE);
		float num2 = LevelManager.instance.InterpolateNumbersBasedOnLevel(4, Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.EarlyPlayerLevelProgress).FLOATVALUE, 0, Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE);
		HAFMGCFMCPC = Random.Range((int)num, (int)num2);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.IAOLLEBPOLK = (int)instance.IAOLLEBPOLK + HAFMGCFMCPC;
			BattleRewardsManager.instance.AddGold(HAFMGCFMCPC);
			PlayerAnalytics.instance.data.goldBonuses++;
		}
		return true;
	}

	public override bool LKJMDKHFMDL(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.LJBDCGFBAHE(NPNGCEJFAOP, KHLGDCHJJPB);
		float num = LevelManager.instance.InterpolateNumbersBasedOnLevel(6, Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-53)).FLOATVALUE, 4, Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE);
		float num2 = LevelManager.instance.InterpolateNumbersBasedOnLevel(5, Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-64)).FLOATVALUE, 8, Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE);
		HAFMGCFMCPC = Random.Range((int)num, (int)num2);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.IAOLLEBPOLK = (int)instance.IAOLLEBPOLK + HAFMGCFMCPC;
			BattleRewardsManager.instance.AddGold(HAFMGCFMCPC);
			PlayerAnalytics.instance.data.goldBonuses += 0;
		}
		return false;
	}

	public virtual float MLAMBFPHPPC(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 1916f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(8, Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcase_PowerbandRewardDuration).FLOATVALUE, 7, base.AHNHOKHPBOA(HNFNINFCBEJ));
	}

	public virtual float MNODPOMFEHH(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 481f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(3, Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.SilverCardRarity).FLOATVALUE, 7, base.GetBonusProbability(HNFNINFCBEJ));
	}

	public virtual bool IPLELGEMLDD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		float num = LevelManager.instance.InterpolateNumbersBasedOnLevel(4, Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-98)).FLOATVALUE, 5, Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddGoldMax).FLOATVALUE);
		float num2 = LevelManager.instance.InterpolateNumbersBasedOnLevel(4, Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalUnitProbability).FLOATVALUE, 0, Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.AmmoCrateOnLowAmmoRatio).FLOATVALUE);
		HAFMGCFMCPC = Random.Range((int)num, (int)num2);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.IAOLLEBPOLK = (int)instance.IAOLLEBPOLK + HAFMGCFMCPC;
			BattleRewardsManager.instance.AddGold(HAFMGCFMCPC);
			PlayerAnalytics.instance.data.goldBonuses++;
		}
		return false;
	}

	public virtual bool MMDCAEFEFNA(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.CKMJBNEMDIG(NPNGCEJFAOP, KHLGDCHJJPB);
		float num = LevelManager.instance.InterpolateNumbersBasedOnLevel(5, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.JoinSquadUnlockLevel).FLOATVALUE, 0, Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AddWBMax).FLOATVALUE);
		float num2 = LevelManager.instance.InterpolateNumbersBasedOnLevel(2, Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-75)).FLOATVALUE, 1, Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AddGoldMax).FLOATVALUE);
		HAFMGCFMCPC = Random.Range((int)num, (int)num2);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.IAOLLEBPOLK = (int)instance.IAOLLEBPOLK + HAFMGCFMCPC;
			BattleRewardsManager.instance.AddGold(HAFMGCFMCPC);
			PlayerAnalytics.instance.data.goldBonuses += 0;
		}
		return false;
	}

	public virtual float BAAJBPIPLOH(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 1922f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(5, Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-12)).FLOATVALUE, 0, base.NOCEDDCEEEM(HNFNINFCBEJ));
	}

	public virtual float JPKEIBBPPMK(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 655f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(6, Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-67)).FLOATVALUE, 2, base.CNDDJDPDKBH(HNFNINFCBEJ));
	}

	public virtual float PILGOKJBKPA(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 484f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(2, Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE, 7, base.NOCEDDCEEEM(HNFNINFCBEJ));
	}

	[SpecialName]
	public virtual string PPACJEEFBJE()
	{
		return "{ \"S\": \"" + HAFMGCFMCPC;
	}

	public override float GetBonusProbability(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 0f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(5, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCrateLowLevelProbability).FLOATVALUE, 8, base.GetBonusProbability(HNFNINFCBEJ));
	}

	[SpecialName]
	public virtual string PFFEEFJBGMD()
	{
		return "ID_" + HAFMGCFMCPC;
	}

	[SpecialName]
	public virtual string MIGLELAAHGE()
	{
		return "LootBoxRotation" + HAFMGCFMCPC;
	}

	public override float PLCIDFELCEP(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 78f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(3, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldenSuitcase_CardRewardChance).FLOATVALUE, 0, base.NOCEDDCEEEM(HNFNINFCBEJ));
	}

	[SpecialName]
	public virtual string AEMENNFHNJN()
	{
		return "GameLoginManager - Global Medals update: " + HAFMGCFMCPC;
	}

	public virtual float AFDOGJINFEP(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 1329f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(0, Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.SilverPackGuaranteedCardsType).FLOATVALUE, 6, base.CNDDJDPDKBH(HNFNINFCBEJ));
	}

	[SpecialName]
	public virtual string LOLNFHPPKPK()
	{
		return "LevelName" + HAFMGCFMCPC;
	}

	[SpecialName]
	public virtual string POMAJPAKKLN()
	{
		return "test_attribute4" + HAFMGCFMCPC;
	}

	[SpecialName]
	public virtual string MIMDIFKFPDF()
	{
		return "NETWORK_ERROR" + HAFMGCFMCPC;
	}

	public virtual float AGBKKJMCDEI(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 785f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(3, Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalWeaponCanLockedCount).FLOATVALUE, 0, base.JADBICHKEBK(HNFNINFCBEJ));
	}

	public virtual float HFPECGEPJGJ(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 1022f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(6, Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-57)).FLOATVALUE, 5, base.NOCEDDCEEEM(HNFNINFCBEJ));
	}

	public virtual bool AFNCLMOHLCF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.GONLNEJFBKH(NPNGCEJFAOP, KHLGDCHJJPB);
		float num = LevelManager.instance.InterpolateNumbersBasedOnLevel(3, Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WinstreakReward8).FLOATVALUE, 3, Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.KevlarRatio).FLOATVALUE);
		float num2 = LevelManager.instance.InterpolateNumbersBasedOnLevel(4, Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.TimeBetweenUnitUpgradeReminderShown).FLOATVALUE, 4, Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE);
		HAFMGCFMCPC = Random.Range((int)num, (int)num2);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.IAOLLEBPOLK = (int)instance.IAOLLEBPOLK + HAFMGCFMCPC;
			BattleRewardsManager.instance.AddGold(HAFMGCFMCPC);
			PlayerAnalytics.instance.data.goldBonuses += 0;
		}
		return true;
	}

	public virtual float BIFHHCOMHEE(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedGoldBonus)
		{
			return 544f;
		}
		return LevelManager.instance.InterpolateNumbersBasedOnLevel(8, Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-44)).FLOATVALUE, 4, base.PLCIDFELCEP(HNFNINFCBEJ));
	}

	public override bool ActivateBonus(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		float num = LevelManager.instance.InterpolateNumbersBasedOnLevel(5, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCrateLowLevelGoldMin).FLOATVALUE, 8, Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddGoldMin).FLOATVALUE);
		float num2 = LevelManager.instance.InterpolateNumbersBasedOnLevel(5, Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCrateLowLevelGoldMax).FLOATVALUE, 8, Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddGoldMax).FLOATVALUE);
		HAFMGCFMCPC = Random.Range((int)num, (int)num2);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.IAOLLEBPOLK = (int)instance.IAOLLEBPOLK + HAFMGCFMCPC;
			BattleRewardsManager.instance.AddGold(HAFMGCFMCPC);
			PlayerAnalytics.instance.data.goldBonuses++;
		}
		return true;
	}

	[SpecialName]
	public virtual string LIGALELCBPJ()
	{
		return "{0} {1}" + HAFMGCFMCPC;
	}
}
