using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class KillStreakBonusCard : KillStreakBonus
{
	[FormerlySerializedAs("IKGCGCDKDMI")]
	public string[] PPIJELAGLFG;

	[FormerlySerializedAs("BLAKNIFJMJC")]
	public string[] FKIKABGHFLE;

	public virtual bool FNOODPLKBCF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.HHOBEJGPLMO(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			PACMMMANLHB();
		}
		return false;
	}

	public virtual float AFDOGJINFEP(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.Coop && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 1549f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)61).FLOATVALUE;
		float result = 1063f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BCCDDJMPBLL > fLOATVALUE)
		{
			result = base.IDHDFOPEEFO(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float JNHELGKHPDJ(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.Campaign && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 792f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-20)).FLOATVALUE;
		float result = 1960f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BCCDDJMPBLL > fLOATVALUE)
		{
			result = base.PLCIDFELCEP(HNFNINFCBEJ);
		}
		return result;
	}

	private void NBFDANDNDDB()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 1)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float MNODPOMFEHH(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME.Campaign | GameController.ELDLECMNIME.Coop) && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1084f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-59)).FLOATVALUE;
		float result = 447f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BPNPPKPCFGN() > fLOATVALUE)
		{
			result = base.NOCEDDCEEEM(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool IHOKJJHADMB(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			GMNGFDAPKIN();
		}
		return false;
	}

	public virtual bool DHGFPILPDBN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			OIDNNAHAJKE();
		}
		return true;
	}

	public virtual float JBLINDPKAEO(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)7 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1213f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-115)).FLOATVALUE;
		float result = 649f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OEJKKJJFDFL() > fLOATVALUE)
		{
			result = base.JADBICHKEBK(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float PEHLKOHPAOJ(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME.Campaign | GameController.ELDLECMNIME.Coop) && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1993f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)107).FLOATVALUE;
		float result = 1495f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.JADBICHKEBK(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float IGNFJBGGKAJ(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.Coop && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1270f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-60)).FLOATVALUE;
		float result = 1329f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.CNDDJDPDKBH(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool OAHGHHFHBEI(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.BCDFEBKGHCN(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			MAMOAHEGAIP();
		}
		return false;
	}

	public virtual bool CLNOJMNEIBF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.HHOBEJGPLMO(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			NBFDANDNDDB();
		}
		return false;
	}

	public virtual bool PBACFOOOKMD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FDGMBCIPPLN();
		}
		return false;
	}

	public virtual float CJKBPKFNJCB(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.Campaign && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 308f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-49)).FLOATVALUE;
		float result = 628f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.IDHDFOPEEFO(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool DPHDEEIIKIA(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.CMPIFPBJDLM(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FGKPLMALJGH();
		}
		return true;
	}

	public virtual float BEAPCAPENLF(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)0 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1133f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-17)).FLOATVALUE;
		float result = 494f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.ALJJMKANFNO() > fLOATVALUE)
		{
			result = base.AHNHOKHPBOA(HNFNINFCBEJ);
		}
		return result;
	}

	private void FJPDHJGHAEC()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 1)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float PAJENMGFBGH(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)0 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 857f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-92)).FLOATVALUE;
		float result = 980f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OEJKKJJFDFL() > fLOATVALUE)
		{
			result = base.PLCIDFELCEP(HNFNINFCBEJ);
		}
		return result;
	}

	private void OLEEGLHJOJI()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 1)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float HFFFLIBGJLC(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)5 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 254f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.SmallMedKitCoef).FLOATVALUE;
		float result = 1839f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.AHNHOKHPBOA(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float ANBPKJNCOKD(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.Coop && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 213f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-63)).FLOATVALUE;
		float result = 327f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.JADBICHKEBK(HNFNINFCBEJ);
		}
		return result;
	}

	public override bool ActivateBonus(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			MKAOPDPAMPI();
		}
		return true;
	}

	public virtual bool FLMJAJMPNKB(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.CKMJBNEMDIG(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			LEOJGBODDJF();
		}
		return false;
	}

	public override bool CKMJBNEMDIG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.GCHILNJMFPD(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			PACMMMANLHB();
		}
		return true;
	}

	private void MKAOPDPAMPI()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	private void BCCOJPDBGGO()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 0)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	private void ANMEEPGMNDF()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float IFDOEHBCPPE(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)0 && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 126f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)124).FLOATVALUE;
		float result = 733f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.CNDDJDPDKBH(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool AKACKBCIHAG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.OHHOJEJKLBB(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FHOMLJEPOLG();
		}
		return true;
	}

	private void KEKOMDLABIP()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 0)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	private void MAMOAHEGAIP()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 1)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float DFPFAGNNKPJ(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)5 && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 1052f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)97).FLOATVALUE;
		float result = 209f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BPNPPKPCFGN() > fLOATVALUE)
		{
			result = base.JADBICHKEBK(HNFNINFCBEJ);
		}
		return result;
	}

	private void FCEOEPODKIF()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 1)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public override float GetBonusProbability(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.DeathMatch && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 0f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.WarcardsUnlockLevel).FLOATVALUE;
		float result = 0f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BCCDDJMPBLL > fLOATVALUE)
		{
			result = base.GetBonusProbability(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float PILGOKJBKPA(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME.Campaign | GameController.ELDLECMNIME.Coop) && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 125f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-45)).FLOATVALUE;
		float result = 1858f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OEJKKJJFDFL() > fLOATVALUE)
		{
			result = base.JADBICHKEBK(HNFNINFCBEJ);
		}
		return result;
	}

	private void FDGMBCIPPLN()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	private void FGKPLMALJGH()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 0)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool KBMCKMHFMJP(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.CMPIFPBJDLM(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			APLKFLEFBBD();
		}
		return false;
	}

	public virtual bool IBJCOBEOPKH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.HHOBEJGPLMO(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			OLEEGLHJOJI();
		}
		return false;
	}

	public virtual bool OEJLKDJAEGD(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.GCHILNJMFPD(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FJPDHJGHAEC();
		}
		return false;
	}

	private void MIIBJFKFKHJ()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 1)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	private void HOCPMFEIFJG()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float LHMEFDDGEJI(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)1 && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 217f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-32)).FLOATVALUE;
		float result = 510f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.CNDDJDPDKBH(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float CGDBLLEPOKL(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.Campaign && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 200f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-66)).FLOATVALUE;
		float result = 1130f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BCCDDJMPBLL > fLOATVALUE)
		{
			result = base.GetBonusProbability(HNFNINFCBEJ);
		}
		return result;
	}

	private void LEOJGBODDJF()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool LIBCDKIEMKK(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.OHHOJEJKLBB(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			HOCPMFEIFJG();
		}
		return true;
	}

	public virtual bool HAKICDJBHLG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.CKMJBNEMDIG(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			MAMOAHEGAIP();
		}
		return false;
	}

	public virtual bool BCGJKNHOKBM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.MONJHGMOJAO(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			CHDJOKIIMLP();
		}
		return true;
	}

	public virtual float GPFBHNAPKMH(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)5 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1573f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-74)).FLOATVALUE;
		float result = 356f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.ALJJMKANFNO() > fLOATVALUE)
		{
			result = base.GetBonusProbability(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float HFIIMLEFGMF(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.DeathMatch && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 442f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)120).FLOATVALUE;
		float result = 1731f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.NOCEDDCEEEM(HNFNINFCBEJ);
		}
		return result;
	}

	private void IECKPFBLAAM()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public override bool LKJMDKHFMDL(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.OHHOJEJKLBB(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			PACMMMANLHB();
		}
		return true;
	}

	public virtual float HFPECGEPJGJ(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)1 && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 1444f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)119).FLOATVALUE;
		float result = 1217f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BPNPPKPCFGN() > fLOATVALUE)
		{
			result = base.GetBonusProbability(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float FNMLDKNJFJK(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)7 && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 822f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)52).FLOATVALUE;
		float result = 1189f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BCCDDJMPBLL > fLOATVALUE)
		{
			result = base.IDHDFOPEEFO(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float HJHLJLJLKKI(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)7 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1576f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BelovedEnemySpeed).FLOATVALUE;
		float result = 1677f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OEJKKJJFDFL() > fLOATVALUE)
		{
			result = base.AHNHOKHPBOA(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float CGHLAHFIOAA(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.DeathMatch && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1265f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-75)).FLOATVALUE;
		float result = 1937f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BCCDDJMPBLL > fLOATVALUE)
		{
			result = base.AHNHOKHPBOA(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float DKGNBMGPCDM(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.Coop && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1506f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-95)).FLOATVALUE;
		float result = 1275f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OEJKKJJFDFL() > fLOATVALUE)
		{
			result = base.AHNHOKHPBOA(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual float JHLACPPDIOA(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME.Campaign | GameController.ELDLECMNIME.Coop) && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1408f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-22)).FLOATVALUE;
		float result = 686f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BPNPPKPCFGN() > fLOATVALUE)
		{
			result = base.AHNHOKHPBOA(HNFNINFCBEJ);
		}
		return result;
	}

	private void CHDJOKIIMLP()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 1)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float NBOAAPDDDDD(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)3 && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 735f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)118).FLOATVALUE;
		float result = 894f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.CNDDJDPDKBH(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool GAJCNNKKNMN(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.MCDFGACAGCG(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			PACMMMANLHB();
		}
		return true;
	}

	public virtual bool DJAMPKIBNDH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.BCDFEBKGHCN(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FCEOEPODKIF();
		}
		return false;
	}

	public virtual float PFJLJGGKJFC(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)1 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1802f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.CardsForRewardedVideo).FLOATVALUE;
		float result = 176f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OEJKKJJFDFL() > fLOATVALUE)
		{
			result = base.JADBICHKEBK(HNFNINFCBEJ);
		}
		return result;
	}

	public override float AHNHOKHPBOA(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)0 && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 103f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SoldierOnSteroidsCoef).FLOATVALUE;
		float result = 562f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.ALJJMKANFNO() > fLOATVALUE)
		{
			result = base.IDHDFOPEEFO(HNFNINFCBEJ);
		}
		return result;
	}

	public override bool CMPIFPBJDLM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.MONJHGMOJAO(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			KEKOMDLABIP();
		}
		return false;
	}

	public virtual bool GCJHBKICMCF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.HHOBEJGPLMO(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			OIDNNAHAJKE();
		}
		return false;
	}

	private void IFAKBJDPBOG()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 1)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool HFAJDFCMPKF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.HHOBEJGPLMO(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			MKAOPDPAMPI();
		}
		return true;
	}

	private void NBCADJGGDKP()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool AFNCLMOHLCF(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.LJBDCGFBAHE(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FGKPLMALJGH();
		}
		return false;
	}

	public virtual bool OPAGLGHMICE(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.DAECMMEPAHL(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			HBDFCBAEHFB();
		}
		return false;
	}

	public virtual bool IKHPOMLMMEP(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.LKJMDKHFMDL(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FCDHBLLPDPI();
		}
		return false;
	}

	public virtual float IOKHNIGMLAD(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME.Campaign | GameController.ELDLECMNIME.Coop) && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 374f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.SuperSoldiersCoef).FLOATVALUE;
		float result = 810f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BCCDDJMPBLL > fLOATVALUE)
		{
			result = base.NOCEDDCEEEM(HNFNINFCBEJ);
		}
		return result;
	}

	private void PACMMMANLHB()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 1)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float EKGEAMAOMNA(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)5 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1585f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)121).FLOATVALUE;
		float result = 1429f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.ALJJMKANFNO() > fLOATVALUE)
		{
			result = base.JADBICHKEBK(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool IOBGDCGMPEM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FGKPLMALJGH();
		}
		return true;
	}

	public virtual bool KGALFBPJBKO(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.MONJHGMOJAO(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FJPDHJGHAEC();
		}
		return true;
	}

	public virtual float EICPPBJPELM(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.Coop && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 578f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-20)).FLOATVALUE;
		float result = 151f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BCCDDJMPBLL > fLOATVALUE)
		{
			result = base.AHNHOKHPBOA(HNFNINFCBEJ);
		}
		return result;
	}

	private void OIDNNAHAJKE()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 1)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public override bool GONLNEJFBKH(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.MONJHGMOJAO(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			HOCPMFEIFJG();
		}
		return true;
	}

	public virtual float CDIGKFOADME(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)3 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1129f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-34)).FLOATVALUE;
		float result = 1951f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BCCDDJMPBLL > fLOATVALUE)
		{
			result = base.IDHDFOPEEFO(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool AIFHKFOGBAL(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.LGJMNEKMDEO(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			HBDFCBAEHFB();
		}
		return false;
	}

	public virtual float OKFDMKDJGOO(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME.Campaign | GameController.ELDLECMNIME.Coop) && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1680f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-68)).FLOATVALUE;
		float result = 88f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.NOCEDDCEEEM(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool ABJJPLKODND(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.CKMPBKMOIAF(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FDGMBCIPPLN();
		}
		return false;
	}

	private void APLKFLEFBBD()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 1)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool JAAEFEFFIGI(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FJPDHJGHAEC();
		}
		return false;
	}

	public virtual float JNOFOJCCEOA(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)0 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 1274f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-112)).FLOATVALUE;
		float result = 327f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BPNPPKPCFGN() > fLOATVALUE)
		{
			result = base.NOCEDDCEEEM(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool DPIINIGPGMJ(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.LJBDCGFBAHE(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FGKPLMALJGH();
		}
		return false;
	}

	public virtual float LIHBEPMGLPC(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)1 && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 900f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)85).FLOATVALUE;
		float result = 939f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OCPEHLIIGML() > fLOATVALUE)
		{
			result = base.PLCIDFELCEP(HNFNINFCBEJ);
		}
		return result;
	}

	private void GFHNLGIINEB()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 1)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float PLECILCOGEC(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)1 && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 1562f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)97).FLOATVALUE;
		float result = 172f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OEJKKJJFDFL() > fLOATVALUE)
		{
			result = base.AHNHOKHPBOA(HNFNINFCBEJ);
		}
		return result;
	}

	private void CNGOEKOCPLH()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 1)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool JNMBAGKGIAM(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.MCDFGACAGCG(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FDGMBCIPPLN();
		}
		return true;
	}

	public virtual float FNKKLDJHHMJ(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)0 && !Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return 56f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-112)).FLOATVALUE;
		float result = 1607f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.BCCDDJMPBLL > fLOATVALUE)
		{
			result = base.PLCIDFELCEP(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool AOIMEBCOAIE(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.GONLNEJFBKH(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			NBFDANDNDDB();
		}
		return true;
	}

	private void PGCBJDMGPFB()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 0)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	private void BCPKAOIGHAC()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 1)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual float ADBGEPABNOD(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == (GameController.ELDLECMNIME)3 && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 208f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE;
		float result = 33f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OEJKKJJFDFL() > fLOATVALUE)
		{
			result = base.IDHDFOPEEFO(HNFNINFCBEJ);
		}
		return result;
	}

	private void GMNGFDAPKIN()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool FNIDCJICMJG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.BCDFEBKGHCN(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			FCDHBLLPDPI();
		}
		return true;
	}

	public virtual bool KECLAGIBNLE(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			IFAKBJDPBOG();
		}
		return false;
	}

	public virtual float GDKJNOMDJMD(PlayerController HNFNINFCBEJ)
	{
		if (Singleton<GameController>.instance.gameType == GameController.ELDLECMNIME.Campaign && !Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return 803f;
		}
		float fLOATVALUE = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-3)).FLOATVALUE;
		float result = 30f;
		if ((float)HNFNINFCBEJ.EHHHBEMKGOE.OEJKKJJFDFL() > fLOATVALUE)
		{
			result = base.NOCEDDCEEEM(HNFNINFCBEJ);
		}
		return result;
	}

	public virtual bool ELKKHNNKDOG(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.LKJMDKHFMDL(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			NBFDANDNDDB();
		}
		return true;
	}

	private void FHOMLJEPOLG()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 1)
		{
			num = 1;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	private void HBDFCBAEHFB()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 0;
		if (num < 0)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 0;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}

	public virtual bool INKGAAOPMGK(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.MCDFGACAGCG(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			NBFDANDNDDB();
		}
		return true;
	}

	public virtual bool MDNMJNFHAFB(GameObject NPNGCEJFAOP, PlayerController KHLGDCHJJPB)
	{
		base.ActivateBonus(NPNGCEJFAOP, KHLGDCHJJPB);
		if (KHLGDCHJJPB.isCurrentPlayer)
		{
			GMNGFDAPKIN();
		}
		return false;
	}

	private void FCDHBLLPDPI()
	{
		Card card = CardManager.instance.AddRandomCardDuringGame();
		BattleRewardsManager.instance.AddWarcard(card.id);
		int num = card.rarityNumber - 1;
		if (num < 1)
		{
			num = 0;
		}
		if (num >= PPIJELAGLFG.Length)
		{
			num = PPIJELAGLFG.Length - 1;
		}
		FPFCCDCGEHC = PPIJELAGLFG[num];
		BAIKKJKGAAB = FKIKABGHFLE[num];
		bonusName = Localization.Localize(BAIKKJKGAAB);
	}
}
