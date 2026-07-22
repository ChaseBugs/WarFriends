using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;

public class CardAmmoBox : Card
{
	private const string EJLCMBEKFFN = "game-card-ico-ammobox";

	public float multiplierBullets => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(multiplierBullets));

	protected override string mBonusName => MEJMLNDFDBP.KEPEILBMDMD(multiplierBullets);

	[SpecialName]
	protected virtual string DFOEFNDMAJP()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(FKFCOHJBFFD());
	}

	[SpecialName]
	public float HNFOFIAFDKM()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE;
	}

	[SpecialName]
	public float DBKIAMJLNDJ()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string DMGHILGBHAB()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(multiplierBullets);
	}

	[SpecialName]
	public float FKFCOHJBFFD()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string KJAOLGNCBBP()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(FMAMECJGDLC());
	}

	[SpecialName]
	public virtual string JPLENCEGLKD()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(HNFOFIAFDKM());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	protected virtual string FBFHPFNAPOE()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(CHGMGOHLJCI());
	}

	public virtual void BHNOANFEFJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		List<PlayerWeapon> lAGONJMBJMM = playerController.JLMDEMFIHCA().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			int num = (int)Math.Ceiling((float)(int)item.HFNAMMBPJAJ().LCKNGBAEFCL * FKFCOHJBFFD());
			item.HFNAMMBPJAJ().ammoLeft += num;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		playerController.cardIconIndicator.FCANLIOLJNH(" on object ", 445f, 1547f, GBJOJBKCEKN: true);
	}

	[SpecialName]
	protected virtual string FBIDDJAGGAC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(FKFCOHJBFFD());
	}

	[SpecialName]
	public virtual string PIOHNCLNAAL()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(HNFOFIAFDKM());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float CHGMGOHLJCI()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE;
	}

	public virtual void ABMOHFELOFN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		List<PlayerWeapon> lAGONJMBJMM = playerController.FMKGGADDHJK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			int num = (int)Math.Ceiling((float)(int)item.weapon.LCKNGBAEFCL * ENNMCKJKLJA());
			item.weapon.ammoLeft += num;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		playerController.cardIconIndicator.ODDNDGAAOCH("(Ljava/lang/String;Ljava/io/FileDescriptor;Ljava/io/PrintWriter;[Ljava/lang/String;)V", 214f, 804f, GBJOJBKCEKN: true);
	}

	public virtual void PDAPJMGBOFF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<PlayerWeapon> lAGONJMBJMM = playerOld.BEIIOAIJMFK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			int num = (int)Math.Ceiling((float)(int)item.HFNAMMBPJAJ().LCKNGBAEFCL * DBKIAMJLNDJ());
			item.weapon.ammoLeft += num;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		playerOld.cardIconIndicator.JBMCFEMBPKE("GameReward", 1100f, 98f, GBJOJBKCEKN: true);
	}

	[SpecialName]
	protected virtual string MIEFNCLBKEG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ENNMCKJKLJA());
	}

	public virtual void JIHHEBGMCBB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<PlayerWeapon> lAGONJMBJMM = playerOld.BEIIOAIJMFK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			int num = (int)Math.Ceiling((float)(int)item.weapon.LCKNGBAEFCL * DBKIAMJLNDJ());
			item.HFNAMMBPJAJ().ammoLeft += num;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		playerOld.cardIconIndicator.AMFEDOOPGCL("Skirmish", 1987f, 1036f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	public float FMAMECJGDLC()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string EENMGDEKBAH()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(ENNMCKJKLJA());
	}

	[SpecialName]
	public float ENNMCKJKLJA()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE;
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<PlayerWeapon> lAGONJMBJMM = playerOld.weaponInventory.LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			int num = (int)Math.Ceiling((float)(int)item.weapon.LCKNGBAEFCL * multiplierBullets);
			item.weapon.ammoLeft += num;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		playerOld.cardIconIndicator.Show("game-card-ico-ammobox", 3f, 3f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	public virtual string PACMLGBHFEF()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(FMAMECJGDLC());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string EPPMHHPHHOB()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(FKFCOHJBFFD()));
	}

	[SpecialName]
	protected virtual string OOMBJFDAEID()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(CHGMGOHLJCI());
	}

	[SpecialName]
	public virtual string GLJFGHEOPJP()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(FKFCOHJBFFD()));
	}

	public virtual void CCODFGNHBOJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<PlayerWeapon> lAGONJMBJMM = playerOld.BEIIOAIJMFK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			int num = (int)Math.Ceiling((float)(int)item.HFNAMMBPJAJ().LCKNGBAEFCL * DBKIAMJLNDJ());
			item.weapon.ammoLeft += num;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		playerOld.cardIconIndicator.BELBLFGCCLJ("ID_GETITCHEAPERNOW", 549f, 88f, GBJOJBKCEKN: false);
	}

	public virtual void ODIBFAFGJBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<PlayerWeapon> lAGONJMBJMM = playerOld.weaponInventory.LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			int num = (int)Math.Ceiling((float)(int)item.HFNAMMBPJAJ().LCKNGBAEFCL * HNFOFIAFDKM());
			item.weapon.ammoLeft += num;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		playerOld.cardIconIndicator.LOFMDBHAFAO("BattleAnalytics", 1773f, 638f, GBJOJBKCEKN: false);
	}

	public virtual void KDPIJNFDMKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<PlayerWeapon> lAGONJMBJMM = playerOld.JLMDEMFIHCA().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			int num = (int)Math.Ceiling((float)(int)item.HFNAMMBPJAJ().LCKNGBAEFCL * FKFCOHJBFFD());
			item.HFNAMMBPJAJ().ammoLeft += num;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		playerOld.cardIconIndicator.JOGFDHFOOBC("US", 879f, 166f, GBJOJBKCEKN: false);
	}

	public virtual void NEPIKOKDBHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<PlayerWeapon> lAGONJMBJMM = playerOld.FMKGGADDHJK().LAGONJMBJMM;
		foreach (PlayerWeapon item in lAGONJMBJMM)
		{
			int num = (int)Math.Ceiling((float)(int)item.weapon.LCKNGBAEFCL * FMAMECJGDLC());
			item.HFNAMMBPJAJ().ammoLeft += num;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		playerOld.cardIconIndicator.AMFEDOOPGCL("T", 472f, 1836f, GBJOJBKCEKN: true);
	}

	[SpecialName]
	public virtual string APAHJBGGPHM()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(FMAMECJGDLC()));
	}
}
