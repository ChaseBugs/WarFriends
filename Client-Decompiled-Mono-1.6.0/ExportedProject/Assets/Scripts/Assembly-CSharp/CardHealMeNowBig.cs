using System.Runtime.CompilerServices;
using Google2u;

public class CardHealMeNowBig : CardHealMeNow
{
	public override float amountOfHealMin
	{
		get
		{
			return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BigMedKitCoefMin).FLOATVALUE;
		}
	}

	public override float amountOfHealMax
	{
		get
		{
			return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BigMedKitCoefMax).FLOATVALUE;
		}
	}

	public override float timeInSec
	{
		get
		{
			return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BigMedKitTime).FLOATVALUE;
		}
	}

	protected override string mBonusName
	{
		get
		{
			return string.Format("{0}-{1}", MEJMLNDFDBP.JJOJLCBJBAJ(amountOfHealMin), MEJMLNDFDBP.JJBMMICPIIG(amountOfHealMax));
		}
	}

	[SpecialName]
	protected virtual string CEOIHKJCCJL()
	{
		return string.Format("App-Version", MEJMLNDFDBP.JJOJLCBJBAJ(GOCCEOEFFAH()), MEJMLNDFDBP.JJBMMICPIIG(LMHAHEOAHLB()));
	}

	[SpecialName]
	protected virtual string FAACBLBMPCM()
	{
		return string.Format("ID_PLAYBATTLETOENTERBRONZELEAGUE", MEJMLNDFDBP.JJOJLCBJBAJ(KHEIPJNFDGE()), MEJMLNDFDBP.JJBMMICPIIG(AJAJEIEOPED()));
	}

	[SpecialName]
	public virtual float EHBEDOAMAGB()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-24)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float KJIABKEKNFO()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-46)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float LFDMJKPLOID()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-81)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float ALKGGDKIAIB()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)56).FLOATVALUE;
	}

	[SpecialName]
	public virtual float PLGNNKADKKN()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ChanceToGetCard1).FLOATVALUE;
	}

	[SpecialName]
	public virtual float OLDOHLHKPBG()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)102).FLOATVALUE;
	}

	[SpecialName]
	public virtual float BBABJFNJBEL()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-87)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float PCCACOILEGN()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)126).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string GCABFJJDENG()
	{
		return string.Format("ManualRegisterForPushNotifications(", MEJMLNDFDBP.JJOJLCBJBAJ(CKPJMLADPML()), MEJMLNDFDBP.JJBMMICPIIG(LMHAHEOAHLB()));
	}

	[SpecialName]
	public virtual float HBDAHPKLHKJ()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-123)).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string LMGALCFDNNC()
	{
		return string.Format("MessageId", MEJMLNDFDBP.JJOJLCBJBAJ(MJMDELJDNFH()), MEJMLNDFDBP.JJBMMICPIIG(HFNCOHEGKEB()));
	}

	[SpecialName]
	public virtual float OFJKLKMCBAB()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-65)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float HPGEOHEDFEM()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-66)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float KNEOOPNGCOL()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-20)).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string BHDMMKJFCMP()
	{
		return string.Format("game-card-ico-triggerhappy", MEJMLNDFDBP.JJOJLCBJBAJ(amountOfHealMin), MEJMLNDFDBP.JJBMMICPIIG(amountOfHealMax));
	}

	[SpecialName]
	public virtual float HMNKJKCMMJG()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-34)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float MGAFEMBNEIK()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)73).FLOATVALUE;
	}

	[SpecialName]
	public virtual float KOPAKKDHNDF()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-107)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float IEHNCIHKIMP()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.CardsForRewardedVideo).FLOATVALUE;
	}

	[SpecialName]
	public virtual float LBOLIBPFPPH()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.RepPointsSilverCard).FLOATVALUE;
	}

	[SpecialName]
	public override float GOCCEOEFFAH()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)120).FLOATVALUE;
	}

	[SpecialName]
	public virtual float KBFHNCEIAHF()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.MedKitCoef).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string CLAPAEAIEKM()
	{
		return string.Format("ID_MINIGUNTUTORIALTEXT", MEJMLNDFDBP.JJOJLCBJBAJ(amountOfHealMin), MEJMLNDFDBP.JJBMMICPIIG(LMHAHEOAHLB()));
	}

	[SpecialName]
	protected virtual string OLLAAADPKDL()
	{
		return string.Format("{0} {1}", MEJMLNDFDBP.JJOJLCBJBAJ(IHJGJHPCFEF()), MEJMLNDFDBP.JJBMMICPIIG(LMHAHEOAHLB()));
	}

	[SpecialName]
	public virtual float LKMADKDNBOH()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-59)).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string NLIPKLIIDND()
	{
		return string.Format("Squad Member record does not have DatabasePlayer", MEJMLNDFDBP.JJOJLCBJBAJ(CKPJMLADPML()), MEJMLNDFDBP.JJBMMICPIIG(HFNCOHEGKEB()));
	}

	[SpecialName]
	public virtual float HMBBAFOLFGE()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)66).FLOATVALUE;
	}

	[SpecialName]
	public override float CPAEFNNJHAH()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)76).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string HKFKFEJCDPE()
	{
		return string.Format("ID_BRONZE", MEJMLNDFDBP.JJOJLCBJBAJ(OPBCLHPPGGL()), MEJMLNDFDBP.JJBMMICPIIG(LMHAHEOAHLB()));
	}

	[SpecialName]
	public virtual float FMJBINBOFMJ()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)67).FLOATVALUE;
	}

	[SpecialName]
	public virtual float DBNPPOINKND()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.BelovedEnemyTime).FLOATVALUE;
	}

	[SpecialName]
	public virtual float KCEBIACPJKB()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)106).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string EMLGGCFKHME()
	{
		return string.Format("game-engi-progress-fill", MEJMLNDFDBP.JJOJLCBJBAJ(amountOfHealMin), MEJMLNDFDBP.JJBMMICPIIG(amountOfHealMax));
	}

	[SpecialName]
	public virtual float KIMJLHALCLJ()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.HeadAheadTime).FLOATVALUE;
	}

	[SpecialName]
	public override float MJMDELJDNFH()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.RepPointsBronzeCard).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string OOMBJFDAEID()
	{
		return string.Format("FuseBox Event DuplicateLootbox for {0}", MEJMLNDFDBP.JJOJLCBJBAJ(amountOfHealMin), MEJMLNDFDBP.JJBMMICPIIG(AJAJEIEOPED()));
	}

	[SpecialName]
	protected virtual string GGFKEBENJIG()
	{
		return string.Format(" 1\u00a0{0}", MEJMLNDFDBP.JJOJLCBJBAJ(MJMDELJDNFH()), MEJMLNDFDBP.JJBMMICPIIG(LMHAHEOAHLB()));
	}

	[SpecialName]
	protected virtual string NFFJILGOKJN()
	{
		return string.Format("Already_Completed", MEJMLNDFDBP.JJOJLCBJBAJ(MJMDELJDNFH()), MEJMLNDFDBP.JJBMMICPIIG(LMHAHEOAHLB()));
	}

	[SpecialName]
	public virtual float LJMNEJDENLC()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-22)).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string JLAHPLHPDDJ()
	{
		return string.Format("BUDDY_CARD_BOT", MEJMLNDFDBP.JJOJLCBJBAJ(IHJGJHPCFEF()), MEJMLNDFDBP.JJBMMICPIIG(AJAJEIEOPED()));
	}

	[SpecialName]
	public virtual float PLGFBDKBHNF()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-74)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float AAOLNAMENGI()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-25)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float KKCOEJDBOPB()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BuddyCardDangerCoef).FLOATVALUE;
	}

	[SpecialName]
	protected virtual string OJOHNDMBCHD()
	{
		return string.Format("ID_KICKPLAYER", MEJMLNDFDBP.JJOJLCBJBAJ(MKALIFKFBDL()), MEJMLNDFDBP.JJBMMICPIIG(amountOfHealMax));
	}

	[SpecialName]
	public override float DFLOEMPMJPJ()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-19)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float CEKACAIHGLE()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)101).FLOATVALUE;
	}

	[SpecialName]
	public virtual float OMHKOLPJJFI()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-36)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float BKPFFAJCIMM()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-95)).FLOATVALUE;
	}
}
