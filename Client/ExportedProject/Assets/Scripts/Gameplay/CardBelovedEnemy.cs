using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardBelovedEnemy : Card
{
	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private float CNOIHHLJLJO = 1f;

	private PlayerController MBIAKMPDOPG;

	private const string EJLCMBEKFFN = "game-card-ico-belovedenemy";

	public float buffTime => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BelovedEnemyTime).FLOATVALUE;

	private float DFNMBEDLOCH => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BelovedEnemySpeed).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(DFNMBEDLOCH), MEJMLNDFDBP.AIPKMDCJCOG(buffTime));

	protected void Update()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 0f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("game-card-ico-belovedenemy", BHABHIDDBLH / buffTime);
				return;
			}
			MBIAKMPDOPG.speed = CNOIHHLJLJO;
			BHABHIDDBLH = 0f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-belovedenemy", NABOFKMBMKH: false);
		}
	}

	public virtual void KDPIJNFDMKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string EMICNMMNBIG()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[6];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(DFNMBEDLOCH);
		array[0] = MEJMLNDFDBP.AIPKMDCJCOG(LPPDEKPDION(), "GUI/2Dtoolkit/");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void EMGGMHONMCM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("ID_REMINDER_GETPOWERBANDTOINCREASE", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		CNOIHHLJLJO = MBIAKMPDOPG.speed;
		MBIAKMPDOPG.FOCHCKLMPBH(DFNMBEDLOCH);
		BHABHIDDBLH = BBGICBKEFOB();
		NNDMKIACBBM = true;
	}

	[SpecialName]
	public float BBGICBKEFOB()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)127).FLOATVALUE;
	}

	public virtual void PEGJJBMLEML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string IMIBCBLGEBC()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[7];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(DFNMBEDLOCH);
		array[0] = MEJMLNDFDBP.AIPKMDCJCOG(BBGICBKEFOB(), "============PINGS===========\n");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string FJDNJDGBIBA()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(DFNMBEDLOCH), MEJMLNDFDBP.AIPKMDCJCOG(LPPDEKPDION(), "Yes_Clicked"), null, null, null);
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string EPPMHHPHHOB()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[6];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(DFNMBEDLOCH);
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(LPPDEKPDION(), "Spawned by card:  progress:{0}, obj: {1},uu: {2} ");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float LPPDEKPDION()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-32)).FLOATVALUE;
	}

	public virtual void JIHHEBGMCBB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-belovedenemy", NABOFKMBMKH: true);
		CNOIHHLJLJO = MBIAKMPDOPG.speed;
		MBIAKMPDOPG.speed = DFNMBEDLOCH;
		BHABHIDDBLH = buffTime;
		NNDMKIACBBM = true;
	}
}
