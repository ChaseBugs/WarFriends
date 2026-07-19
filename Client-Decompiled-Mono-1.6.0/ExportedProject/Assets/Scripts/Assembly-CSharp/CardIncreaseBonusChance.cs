using System.Collections.Generic;

public class CardIncreaseBonusChance : Card
{
	public KillStreakBonus IDHKGCDOEDA;

	public float AABJNJGPHAE = 0.7f;

	public virtual void EMOLCFONJID(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		int num = 1;
		List<KillStreakBonus> kGHBOHPIHND = Singleton<KillStreakManager>.instance.KGHBOHPIHND;
		num = kGHBOHPIHND.IndexOf(IDHKGCDOEDA);
		Singleton<KillStreakManager>.instance.EnqueueNewBonus(num, CIOPAKLHFIL);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void ABMOHFELOFN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		int num = 0;
		List<KillStreakBonus> kGHBOHPIHND = Singleton<KillStreakManager>.instance.KGHBOHPIHND;
		num = kGHBOHPIHND.IndexOf(IDHKGCDOEDA);
		Singleton<KillStreakManager>.instance.DADFAMBJKGL(num, CIOPAKLHFIL);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		int num = 0;
		List<KillStreakBonus> kGHBOHPIHND = Singleton<KillStreakManager>.instance.KGHBOHPIHND;
		num = kGHBOHPIHND.IndexOf(IDHKGCDOEDA);
		Singleton<KillStreakManager>.instance.EnqueueNewBonus(num, CIOPAKLHFIL);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void HGINJJNEEDB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		int num = 1;
		List<KillStreakBonus> kGHBOHPIHND = Singleton<KillStreakManager>.instance.KGHBOHPIHND;
		num = kGHBOHPIHND.IndexOf(IDHKGCDOEDA);
		Singleton<KillStreakManager>.instance.MEHAJPPPIEK(num, CIOPAKLHFIL);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool GFBADADCLOF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool ACOBGNBBAJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		int num = 0;
		List<KillStreakBonus> kGHBOHPIHND = Singleton<KillStreakManager>.instance.KGHBOHPIHND;
		num = kGHBOHPIHND.IndexOf(IDHKGCDOEDA);
		Singleton<KillStreakManager>.instance.NKBHGLJGNKK(num, CIOPAKLHFIL);
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool NAHJCMJEDBM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool MGPDCKKLJBI(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}
}
