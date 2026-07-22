using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class KillStreakBonusAddMoney : KillStreakBonus
{
	private int CKGAKEEDCKJ;

	public override string fullName => "+" + CKGAKEEDCKJ;

	public virtual bool FEBBNJNJEAK(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.CKMPBKMOIAF(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow((BonussesDefinitions.rowIds)8).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-72)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.ALJJMKANFNO() - 1) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return true;
	}

	[SpecialName]
	public virtual string KAKCNBPDNMH()
	{
		return "com/google/android/gms/common/ConnectionResult" + CKGAKEEDCKJ;
	}

	public override bool OHHOJEJKLBB(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.LJBDCGFBAHE(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AmmoCrateOnLowAmmoRatio).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AddGoldMin).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-34)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() - 7) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return true;
	}

	public virtual bool GCJHBKICMCF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-25)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.ALJJMKANFNO() - 7) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	public virtual bool IEGHLKIJPDB(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.LowAmmoRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-72)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() - 5) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return true;
	}

	public virtual bool IBJCOBEOPKH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.GONLNEJFBKH(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.KevlarRatio).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.AmmoCrateOnLowAmmoRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-76)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL - 6) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	[SpecialName]
	public virtual string KJEBGNKNNJL()
	{
		return "gold" + CKGAKEEDCKJ;
	}

	public virtual bool KBMCKMHFMJP(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.FJAJKEBLFOE(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.AddWBMax).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-27)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL - 7) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return true;
	}

	public virtual bool MPNMPNMLOBN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.CKMPBKMOIAF(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow((BonussesDefinitions.rowIds)8).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.BronzePackGuaranteedCardsType).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.ALJJMKANFNO() - 0) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	public override bool ActivateBonus(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddWBMax).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.WarbucksScalingBase).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL - 3) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return true;
	}

	public override bool GONLNEJFBKH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.AddGoldMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AddWBMax).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward1).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.ALJJMKANFNO() - 5) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	public virtual float PMLHJFDAFBA(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 332f;
		}
		return base.NOCEDDCEEEM(HNFNINFCBEJ);
	}

	public virtual bool NFCPEKJEDCG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.GCHILNJMFPD(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward5).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() - 4) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return true;
	}

	public virtual bool NFCAGIHGEAF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.CKMJBNEMDIG(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.KevlarRatio).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AddWBMax).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-89)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.ALJJMKANFNO() - 7) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	public virtual float CNLIFNGEAPC(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 911f;
		}
		return base.PLCIDFELCEP(HNFNINFCBEJ);
	}

	public virtual float PJDPEILONLF(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 499f;
		}
		return base.IDHDFOPEEFO(HNFNINFCBEJ);
	}

	public override float GetBonusProbability(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 0f;
		}
		return base.GetBonusProbability(HNFNINFCBEJ);
	}

	public virtual bool DJAMPKIBNDH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.OHHOJEJKLBB(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AddGoldMax).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.VipDogtags).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() - 5) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	[SpecialName]
	public virtual string PFFEEFJBGMD()
	{
		return "ID_BLACKMARKETLEFTTEXT3" + CKGAKEEDCKJ;
	}

	public virtual float PILGOKJBKPA(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 1759f;
		}
		return base.IDHDFOPEEFO(HNFNINFCBEJ);
	}

	public override bool GCHILNJMFPD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.GONLNEJFBKH(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddGoldMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.KevlarRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-18)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() - 0) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	[SpecialName]
	public virtual string OPLADBFNEIL()
	{
		return "menu-crown-silver" + CKGAKEEDCKJ;
	}

	public virtual bool IPLELGEMLDD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.LKJMDKHFMDL(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AmmoCrateOnLowAmmoRatio).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL() - 1) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	public virtual float BAAJBPIPLOH(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 560f;
		}
		return base.AHNHOKHPBOA(HNFNINFCBEJ);
	}

	[SpecialName]
	public virtual string HCOADBAIBNA()
	{
		return "{0}-{1}" + CKGAKEEDCKJ;
	}

	public virtual float PAJENMGFBGH(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 1672f;
		}
		return base.GetBonusProbability(HNFNINFCBEJ);
	}

	public virtual bool JCEGNMEKPOD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.OHHOJEJKLBB(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.AddWBMin).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.KevlarRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxPingToConnectRegion).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() - 2) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return true;
	}

	[SpecialName]
	public override string MLPCGNBFFCO()
	{
		return "Army upgrade for " + CKGAKEEDCKJ;
	}

	public virtual bool OKLMIJPACPI(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.HHOBEJGPLMO(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.LowAmmoRatio).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.AddWBMax).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalMaxWeapons).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() - 3) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return true;
	}

	public virtual bool DFPGPKIIHFA(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.LowAmmoRatio).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ServerRentalUnitProbability).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() - 6) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return true;
	}

	public virtual bool KIHKPDOCHOJ(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.MCDFGACAGCG(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.KevlarRatio).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AddGoldMin).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverCardRarityEarly).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() - 7) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	[SpecialName]
	public override string BBDCKJOIHPM()
	{
		return "#PETER# League Arc - start ignore on " + CKGAKEEDCKJ;
	}

	[SpecialName]
	public virtual string HMPAJEACCJM()
	{
		return "ID_DOUBLEGOLD" + CKGAKEEDCKJ;
	}

	public virtual bool OIAFHJAAABH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.MONJHGMOJAO(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.LowAmmoRatio).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.LowAmmoRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-103)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.ALJJMKANFNO() - 4) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	public virtual float HFPECGEPJGJ(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 1863f;
		}
		return base.CNDDJDPDKBH(HNFNINFCBEJ);
	}

	public virtual float JHLACPPDIOA(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 1413f;
		}
		return base.NOCEDDCEEEM(HNFNINFCBEJ);
	}

	public virtual float CEEAMDCECFK(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 1859f;
		}
		return base.NOCEDDCEEEM(HNFNINFCBEJ);
	}

	[SpecialName]
	public override string MDCIOFEBIPJ()
	{
		return "ID_GUI_CHEATINGMESSAGE" + CKGAKEEDCKJ;
	}

	[SpecialName]
	public override string BEHIACANIGG()
	{
		return "ID_FACEBOOKLOGOUTLEGALTEXT2" + CKGAKEEDCKJ;
	}

	[SpecialName]
	public virtual string PHMIOJKOCFH()
	{
		return "ID_OPPONENTREFUSEDTHEREMATCH" + CKGAKEEDCKJ;
	}

	[SpecialName]
	public virtual string AADBCPOCNOA()
	{
		return "Start TUTORIAL" + CKGAKEEDCKJ;
	}

	public override bool LGJMNEKMDEO(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.CKMPBKMOIAF(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.AmmoCrateOnLowAmmoRatio).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.LowAmmoRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-105)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.BPNPPKPCFGN() - 0) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}

	public virtual float MNODPOMFEHH(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 422f;
		}
		return base.JADBICHKEBK(HNFNINFCBEJ);
	}

	public virtual float EIMAAPPAFED(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 621f;
		}
		return base.NOCEDDCEEEM(HNFNINFCBEJ);
	}

	[SpecialName]
	public virtual string DJMGBOLMMFK()
	{
		return "ShotFrequencyMaxCannon" + CKGAKEEDCKJ;
	}

	[SpecialName]
	public virtual string ONOCCJLPCMO()
	{
		return "Xp" + CKGAKEEDCKJ;
	}

	public override float PLCIDFELCEP(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 1786f;
		}
		return base.JADBICHKEBK(HNFNINFCBEJ);
	}

	public virtual float IGNFJBGGKAJ(PlayerController HNFNINFCBEJ)
	{
		if (!PlayerAnalytics.instance.IsAllowedMoneyBonus)
		{
			return 454f;
		}
		return base.JADBICHKEBK(HNFNINFCBEJ);
	}

	public override bool BCDFEBKGHCN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.OHHOJEJKLBB(NPNGCEJFAOP, KHLGDCHJJPB);
		float fLOATVALUE = Singleton<GameVariables>.instance.DIHCHLDIONJ().GetRow(BonussesDefinitions.rowIds.HealthRefilRatio).FLOATVALUE;
		float fLOATVALUE2 = Singleton<GameVariables>.instance.JKLCJHJCNGO().GetRow(BonussesDefinitions.rowIds.LowAmmoRatio).FLOATVALUE;
		CKGAKEEDCKJ = Random.Range((int)fLOATVALUE, (int)fLOATVALUE2);
		float f = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-95)).FLOATVALUE;
		CKGAKEEDCKJ = (int)(Mathf.Pow(f, KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() - 0) * (float)CKGAKEEDCKJ);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			ScoreManager instance = Singleton<ScoreManager>.instance;
			instance.HOHGDIKCKFM = (int)instance.HOHGDIKCKFM + CKGAKEEDCKJ;
			BattleRewardsManager.instance.AddWB(CKGAKEEDCKJ);
		}
		return false;
	}
}
