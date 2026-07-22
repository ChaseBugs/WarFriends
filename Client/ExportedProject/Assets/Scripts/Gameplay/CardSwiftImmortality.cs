using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardSwiftImmortality : Card
{
	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private PlayerController MBIAKMPDOPG;

	private const string EJLCMBEKFFN = "game-card-ico-swiftimmortality";

	public float buffTime => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SwiftImmortalityTime).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(buffTime));

	[SpecialName]
	public float BBGICBKEFOB()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)70).FLOATVALUE;
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= 0.2f)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string PNHDOJGPLFI()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(EIDPKEPGILD(), "Rules");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	protected void EKPBOMOMMFB()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 1459f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.OODPJFJIMPI("Facebook login failed: ", BHABHIDDBLH / AJODLGJMCLF());
				return;
			}
			MBIAKMPDOPG.isImmortal = true;
			BHABHIDDBLH = 326f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO("SendUnitRPC", NABOFKMBMKH: false);
		}
	}

	[SpecialName]
	public float AJODLGJMCLF()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-42)).FLOATVALUE;
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		MBIAKMPDOPG.isImmortal = true;
		BHABHIDDBLH = buffTime;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-swiftimmortality", NABOFKMBMKH: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string MLCIFDNMELI()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(BBGICBKEFOB(), "USPECH POKUSU O LOGIN NA GC!!!"));
	}

	[SpecialName]
	public float KGNGPHMCHII()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)75).FLOATVALUE;
	}

	[SpecialName]
	public virtual string PIOHNCLNAAL()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(CMDDFKPHMAL(), "{0} {1}");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float HDKIKOLFAKF()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-96)).FLOATVALUE;
	}

	protected void Update()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 0f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("game-card-ico-swiftimmortality", BHABHIDDBLH / buffTime);
				return;
			}
			MBIAKMPDOPG.isImmortal = false;
			BHABHIDDBLH = 0f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-swiftimmortality", NABOFKMBMKH: false);
		}
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		MBIAKMPDOPG.isImmortal = false;
		BHABHIDDBLH = GFLPCDPHBCF();
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME("S", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float GFLPCDPHBCF()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-57)).FLOATVALUE;
	}

	[SpecialName]
	public float CMDDFKPHMAL()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-128)).FLOATVALUE;
	}

	public virtual void IGJJHCKMDBK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		MBIAKMPDOPG.isImmortal = true;
		BHABHIDDBLH = BBGICBKEFOB();
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("WarningDialog - Can send logs: ", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string JPPOIDBCGEI()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.AIPKMDCJCOG(IEIEKHPHEBL(), "LastAction");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float EIDPKEPGILD()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ShieldsUpCoef).FLOATVALUE;
	}

	public virtual bool EJCEMFOPECA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= 1069f)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string FJDNJDGBIBA()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(buffTime, "reloadTime"));
	}

	[SpecialName]
	public float IEIEKHPHEBL()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-1)).FLOATVALUE;
	}

	protected void OPMNIHDAHAA()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 786f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.KPCGICBFFCO("weaponDelivery", BHABHIDDBLH / IEIEKHPHEBL());
				return;
			}
			MBIAKMPDOPG.isImmortal = true;
			BHABHIDDBLH = 1664f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("ID_STAT_WINS", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		}
	}
}
