using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardBrokenLegs : Card
{
	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private PlayerController MBIAKMPDOPG;

	private const string EJLCMBEKFFN = "game-card-ico-paralyzethese";

	private float JMMPIENOKCH
	{
		get
		{
			return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE;
		}
	}

	public override string description
	{
		get
		{
			return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(JMMPIENOKCH));
		}
	}

	[SpecialName]
	private float CEKOINBPPKO()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE;
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string EMICNMMNBIG()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.AIPKMDCJCOG(JMMPIENOKCH, "bazooka_shot_barrier");
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void BHNOANFEFJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void PEGJJBMLEML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void EKPBOMOMMFB()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 182f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("ETM: Show Rewarded Video", BHABHIDDBLH / JMMPIENOKCH);
				return;
			}
			MBIAKMPDOPG.JFECKJEDJNJ = true;
			BHABHIDDBLH = 1491f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("country-noflag", false);
		}
	}

	[SpecialName]
	private float IOKFJPMMLEG()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE;
	}

	public virtual void OFNENBNMMOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void Update()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 0f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("game-card-ico-paralyzethese", BHABHIDDBLH / JMMPIENOKCH);
				return;
			}
			MBIAKMPDOPG.JFECKJEDJNJ = false;
			BHABHIDDBLH = 0f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-paralyzethese", false);
		}
	}

	public virtual void GJCKHJLEPKG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MBIAKMPDOPG.JFECKJEDJNJ = true;
		BHABHIDDBLH = BBJPHKJJEDB();
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.BIIHCAEKCOD("ID_READYTIME", true, true);
	}

	protected void IDPOHKDKDNL()
	{
		if (NNDMKIACBBM)
		{
			if (BHABHIDDBLH > 615f)
			{
				BHABHIDDBLH -= Time.deltaTime;
				MBIAKMPDOPG.cardIconIndicator.JKGGGKPLAAB("CARD BUDDY - SHOW IN MENU - Player: {0} actual reference count: {1}", BHABHIDDBLH / CEKOINBPPKO());
				return;
			}
			MBIAKMPDOPG.JFECKJEDJNJ = false;
			BHABHIDDBLH = 856f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.JCJFMHGNIOF("PT", false, true);
		}
	}

	[SpecialName]
	private float BBJPHKJJEDB()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE;
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetEnemyOf(CIOPAKLHFIL);
		MBIAKMPDOPG.JFECKJEDJNJ = true;
		BHABHIDDBLH = JMMPIENOKCH;
		NNDMKIACBBM = true;
		MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-paralyzethese", true);
	}

	public virtual void EMOLCFONJID(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}
}
