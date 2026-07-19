using System.Runtime.CompilerServices;
using Google2u;

public class CardKevlarUp : Card
{
	public KillStreakBonus EDHHJMOODAE;

	private NetworkObjectPool IHFILHIAGLG;

	public float kevlarStrength
	{
		get
		{
			return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.KevlarUpCoef).FLOATVALUE;
		}
	}

	public override string description
	{
		get
		{
			return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(kevlarStrength));
		}
	}

	public virtual void ILGMMCAGIIM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		string value = Localization.Localize("country-south-africa");
		foreach (KillStreakBonus item in KillStreakBonus.EEPKLMJMJAI)
		{
			if (item.name.Contains(value))
			{
				MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
				return;
			}
		}
		playerController.SetUpKevlar(IPHBLPOOICA());
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void PDAPJMGBOFF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		string value = Localization.Localize("ID_POSITIONXYREWARD");
		foreach (KillStreakBonus item in KillStreakBonus.EEPKLMJMJAI)
		{
			if (item.name.Contains(value))
			{
				MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
				return;
			}
		}
		playerController.SetUpKevlar(GOBJHBNOLMB());
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float LHNOAKEFLMC()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)115).FLOATVALUE;
	}

	[SpecialName]
	public virtual string EFNOCPODOLE()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(PDNFMPDICBK());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float IPHBLPOOICA()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-55)).FLOATVALUE;
	}

	[SpecialName]
	public virtual string JPPOIDBCGEI()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(GOBJHBNOLMB());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string GLJFGHEOPJP()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(GIDPMJCHAGF());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string CGCEEBCGCFH()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(ILFAALEIDNG());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float GIDPMJCHAGF()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.MineYourStepDamageCoef).FLOATVALUE;
	}

	[SpecialName]
	public float AFBPGECDADL()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-29)).FLOATVALUE;
	}

	public virtual void HOBNOKFFHCM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		string value = Localization.Localize("Rewards");
		foreach (KillStreakBonus item in KillStreakBonus.EEPKLMJMJAI)
		{
			if (item.name.Contains(value))
			{
				MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
				return;
			}
		}
		playerOld.SetUpKevlar(LHNOAKEFLMC());
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float LFGHJANKGEL()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-101)).FLOATVALUE;
	}

	public virtual void JGNCOJLCGFH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		string value = Localization.Localize("ID_BEGINNERSLEAGUE1");
		foreach (KillStreakBonus item in KillStreakBonus.EEPKLMJMJAI)
		{
			if (item.name.Contains(value))
			{
				MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
				return;
			}
		}
		playerController.SetUpKevlar(LFGHJANKGEL());
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float PDNFMPDICBK()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-2)).FLOATVALUE;
	}

	[SpecialName]
	public virtual string NMMJABOJHND()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(kevlarStrength);
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void GEKMPGMEAGF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		string value = Localization.Localize("{0} \t\t");
		foreach (KillStreakBonus item in KillStreakBonus.EEPKLMJMJAI)
		{
			if (item.name.Contains(value))
			{
				MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
				return;
			}
		}
		playerOld.SetUpKevlar(GIDPMJCHAGF());
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		string value = Localization.Localize("ID_BONUS-KEVLAR");
		foreach (KillStreakBonus item in KillStreakBonus.EEPKLMJMJAI)
		{
			if (item.name.Contains(value))
			{
				MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
				return;
			}
		}
		playerOld.SetUpKevlar(kevlarStrength);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float GOBJHBNOLMB()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE;
	}

	[SpecialName]
	public float ILFAALEIDNG()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)126).FLOATVALUE;
	}

	public virtual void NLPMJPNEEOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		string value = Localization.Localize("ID_CONFIRM_FRIENDCANCELLED");
		foreach (KillStreakBonus item in KillStreakBonus.EEPKLMJMJAI)
		{
			if (item.name.Contains(value))
			{
				MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
				return;
			}
		}
		playerOld.SetUpKevlar(IPHBLPOOICA());
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float BFBAMIJNILG()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.SwiftImmortalityTime).FLOATVALUE;
	}

	[SpecialName]
	public virtual string EFCOHICFKEO()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(GIDPMJCHAGF()));
	}

	[SpecialName]
	public virtual string AFHFCDAAACH()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(BFBAMIJNILG()));
	}

	public virtual void LOPOCGLOHLH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		string value = Localization.Localize("PRICEGOLD");
		foreach (KillStreakBonus item in KillStreakBonus.EEPKLMJMJAI)
		{
			if (item.name.Contains(value))
			{
				MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
				return;
			}
		}
		playerController.SetUpKevlar(AFBPGECDADL());
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}
}
