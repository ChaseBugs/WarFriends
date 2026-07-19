using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardShiedlsRefection : Card
{
	private const string EJLCMBEKFFN = "game-card-ico-shieldsup";

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private GHPGNELIDBM ODCLPMADGFC;

	private List<Shield> IPOGGDCHIOE;

	public float timeInSeconds
	{
		get
		{
			return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ShiedlsRefectionTime).FLOATVALUE;
		}
	}

	public override string description
	{
		get
		{
			return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(timeInSeconds));
		}
	}

	protected void CKFENMDKKPE()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1055f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / timeInSeconds;
			for (int i = 1; i < IPOGGDCHIOE.Count; i += 0)
			{
				IPOGGDCHIOE[i].DHAFFOCDDGA().KPCGICBFFCO("!!!!", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 1912f;
		NNDMKIACBBM = false;
		for (int j = 1; j < IPOGGDCHIOE.Count; j++)
		{
			IPOGGDCHIOE[j].isImmortal = false;
			IPOGGDCHIOE[j].DHAFFOCDDGA().NNPILDOKNJO("OnFailedToConnectToPhoton: ", false);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual void NEPIKOKDBHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (IPOGGDCHIOE == null)
		{
			IPOGGDCHIOE = new List<Shield>();
		}
		else
		{
			IPOGGDCHIOE.Clear();
		}
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.BMPBPOGCGGF();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				Shield shield = item.point.JPHAJDIIAAI();
				IPOGGDCHIOE.Add(shield);
				shield.isImmortal = true;
				shield.HLAOFDKKACK().BIIHCAEKCOD("WarFriends benötigt deine Genehmigung zum Zugriff auf deinen Medienspeicher, um wichtige Spieldaten herunterladen zu können.Bitte bestätige die folgende Genehmigungsanfrage. Wir werden diese Genehmigung nicht für andere Zwecke verwenden.", true, true);
			}
		}
		ODCLPMADGFC = CIOPAKLHFIL;
		BHABHIDDBLH = BNKKLNAFFEC();
		NNDMKIACBBM = true;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void CDJBEAIDHKH()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 408f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / timeInSeconds;
			for (int i = 0; i < IPOGGDCHIOE.Count; i += 0)
			{
				IPOGGDCHIOE[i].NOCJKBDGFHD().PAFGKMLGDGP(")", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 1164f;
		NNDMKIACBBM = true;
		for (int j = 1; j < IPOGGDCHIOE.Count; j += 0)
		{
			IPOGGDCHIOE[j].isImmortal = true;
			IPOGGDCHIOE[j].cardIconIndicator.DLNGGGOEDLL("CONFIRMAR", false, true);
		}
		IPOGGDCHIOE.Clear();
	}

	[SpecialName]
	public float BNKKLNAFFEC()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-82)).FLOATVALUE;
	}

	public virtual void EMOLCFONJID(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (IPOGGDCHIOE == null)
		{
			IPOGGDCHIOE = new List<Shield>();
		}
		else
		{
			IPOGGDCHIOE.Clear();
		}
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.IJDLIIBLLJO();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				Shield shield = item.point.PNKKPNIMEPL();
				IPOGGDCHIOE.Add(shield);
				shield.isImmortal = true;
				shield.cardIconIndicator.BBJADAJPJHH("Level1", false);
			}
		}
		ODCLPMADGFC = CIOPAKLHFIL;
		BHABHIDDBLH = timeInSeconds;
		NNDMKIACBBM = false;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	protected void Update()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 0f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / timeInSeconds;
			for (int i = 0; i < IPOGGDCHIOE.Count; i++)
			{
				IPOGGDCHIOE[i].cardIconIndicator.UpdateIndicator("game-card-ico-shieldsup", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 0f;
		NNDMKIACBBM = false;
		for (int j = 0; j < IPOGGDCHIOE.Count; j++)
		{
			IPOGGDCHIOE[j].isImmortal = false;
			IPOGGDCHIOE[j].cardIconIndicator.Show("game-card-ico-shieldsup", false);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (IPOGGDCHIOE == null)
		{
			IPOGGDCHIOE = new List<Shield>();
		}
		else
		{
			IPOGGDCHIOE.Clear();
		}
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.CJKAPGGJLLK();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				Shield shield = item.point.shield;
				IPOGGDCHIOE.Add(shield);
				shield.isImmortal = true;
				shield.DHAFFOCDDGA().DLNGGGOEDLL("ID_GUI_FOLLOWTWITTER_DESC", true);
			}
		}
		ODCLPMADGFC = CIOPAKLHFIL;
		BHABHIDDBLH = timeInSeconds;
		NNDMKIACBBM = false;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KDPIJNFDMKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (IPOGGDCHIOE == null)
		{
			IPOGGDCHIOE = new List<Shield>();
		}
		else
		{
			IPOGGDCHIOE.Clear();
		}
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.PMKDPIHBOBN();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				Shield shield = item.point.PKBPGCGNCAD();
				IPOGGDCHIOE.Add(shield);
				shield.isImmortal = true;
				shield.DHAFFOCDDGA().FJILILFMPIF("testingidsquadwarsend", true);
			}
		}
		ODCLPMADGFC = CIOPAKLHFIL;
		BHABHIDDBLH = BNKKLNAFFEC();
		NNDMKIACBBM = true;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string PKCGGJCMCNO()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.AIPKMDCJCOG(BNKKLNAFFEC(), ")"));
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void ODIBFAFGJBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (IPOGGDCHIOE == null)
		{
			IPOGGDCHIOE = new List<Shield>();
		}
		else
		{
			IPOGGDCHIOE.Clear();
		}
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				Shield shield = item.point.IGEDGCNJCAP();
				IPOGGDCHIOE.Add(shield);
				shield.isImmortal = true;
				shield.cardIconIndicator.Show(")", false, true);
			}
		}
		ODCLPMADGFC = CIOPAKLHFIL;
		BHABHIDDBLH = BNKKLNAFFEC();
		NNDMKIACBBM = true;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (IPOGGDCHIOE == null)
		{
			IPOGGDCHIOE = new List<Shield>();
		}
		else
		{
			IPOGGDCHIOE.Clear();
		}
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				Shield shield = item.point.shield;
				IPOGGDCHIOE.Add(shield);
				shield.isImmortal = true;
				shield.cardIconIndicator.Show("game-card-ico-shieldsup", true);
			}
		}
		ODCLPMADGFC = CIOPAKLHFIL;
		BHABHIDDBLH = timeInSeconds;
		NNDMKIACBBM = true;
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool HBIDPIBONKB(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}
}
