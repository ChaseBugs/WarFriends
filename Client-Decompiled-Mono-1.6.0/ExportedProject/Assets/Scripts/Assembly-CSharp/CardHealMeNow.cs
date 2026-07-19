using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardHealMeNow : Card
{
	public float AABJNJGPHAE = 1f;

	private const string EJLCMBEKFFN = "game-card-ico-healingstorm";

	public bool ANMEHGAFBEG = true;

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	private PlayerController MBIAKMPDOPG;

	private float FNAPLODKCKC;

	private int FDGLGCIJCBA;

	public virtual float amountOfHealMin
	{
		get
		{
			return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.MedKitCoef).FLOATVALUE;
		}
	}

	public virtual float amountOfHealMax
	{
		get
		{
			return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.MedKitCoef).FLOATVALUE;
		}
	}

	public virtual float timeInSec
	{
		get
		{
			return 0f;
		}
	}

	public override string description
	{
		get
		{
			return (!ANMEHGAFBEG) ? Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(amountOfHealMin), MEJMLNDFDBP.JJBMMICPIIG(amountOfHealMax), MEJMLNDFDBP.AIPKMDCJCOG(timeInSec)) : Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(amountOfHealMin));
		}
	}

	protected override string mBonusName
	{
		get
		{
			return MEJMLNDFDBP.KEPEILBMDMD(amountOfHealMin);
		}
	}

	[SpecialName]
	public virtual float FGHNICOGGKH()
	{
		return 221f;
	}

	public virtual void JIDDCBAEAGC()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1881f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.BBJADAJPJHH("shotgun_reload", true);
		}
	}

	public virtual bool OKCDLFMKJDM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void EKBAEHKJCHL()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1260f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.FJILILFMPIF("ID_CONFIRM_SERVERERROR", false, true);
		}
	}

	[SpecialName]
	public virtual string BEKKKKCKGMA()
	{
		string result;
		if (ANMEHGAFBEG)
		{
			result = Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(KHEIPJNFDGE()));
		}
		else
		{
			string keyFormat = mDescriptionID;
			object[] array = new object[3];
			array[0] = MEJMLNDFDBP.JJBMMICPIIG(MKALIFKFBDL());
			array[0] = MEJMLNDFDBP.JJBMMICPIIG(AJAJEIEOPED());
			array[5] = MEJMLNDFDBP.AIPKMDCJCOG(CPAEFNNJHAH(), "IsPublic");
			result = Localization.LocalizeFormat(keyFormat, array);
		}
		return result;
	}

	[SpecialName]
	public virtual float HFNCOHEGKEB()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-91)).FLOATVALUE;
	}

	[SpecialName]
	public virtual string APAHJBGGPHM()
	{
		string result;
		if (ANMEHGAFBEG)
		{
			string keyFormat = mDescriptionID;
			object[] array = new object[0];
			array[0] = MEJMLNDFDBP.JJBMMICPIIG(CKPJMLADPML());
			result = Localization.LocalizeFormat(keyFormat, array);
		}
		else
		{
			string keyFormat2 = mDescriptionID;
			object[] array2 = new object[2];
			array2[0] = MEJMLNDFDBP.JJBMMICPIIG(MJMDELJDNFH());
			array2[1] = MEJMLNDFDBP.JJBMMICPIIG(LMHAHEOAHLB());
			array2[0] = MEJMLNDFDBP.AIPKMDCJCOG(DDBOGDKNMFC(), "ID_ENDED");
			result = Localization.LocalizeFormat(keyFormat2, array2);
		}
		return result;
	}

	public virtual void HKFPNJECIJN()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1344f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.OFPAGLLFPPK("menu-health-ico", false, true);
		}
	}

	[SpecialName]
	public virtual float HIHOIDNGECC()
	{
		return 1979f;
	}

	public virtual bool CGFFJEHJHHL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual float MKALIFKFBDL()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.SuperSoldiersCoef).FLOATVALUE;
	}

	[SpecialName]
	public virtual float GCEFNKEHKAG()
	{
		return 713f;
	}

	[SpecialName]
	protected virtual string DBGDDBHBFKN()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(amountOfHealMin);
	}

	[SpecialName]
	public virtual float DFLOEMPMJPJ()
	{
		return 130f;
	}

	protected void NBFMDCFFBIJ()
	{
		if (!NNDMKIACBBM || ANMEHGAFBEG)
		{
			return;
		}
		if (BHABHIDDBLH > 793f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("\tNumber of games after fb login: {0}/{1}", BHABHIDDBLH / timeInSec);
			if (FDGLGCIJCBA != (int)Time.time)
			{
				FDGLGCIJCBA = (int)Time.time;
				MBIAKMPDOPG.FOCIOKMPCAG.LNPKAAGJIGO(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC / GNKGAIABFHM(), true);
			}
		}
		else
		{
			DisconnectEvents();
		}
	}

	[SpecialName]
	public virtual float OPBCLHPPGGL()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-52)).FLOATVALUE;
	}

	public virtual void DPELJDNCGHG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		FNAPLODKCKC = Random.Range(KHEIPJNFDGE(), amountOfHealMax);
		if (ANMEHGAFBEG)
		{
			MBIAKMPDOPG.FOCIOKMPCAG.Heal(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC, true);
			MBIAKMPDOPG.FOCIOKMPCAG.EHFOHNLMJOH();
			MBIAKMPDOPG.cardIconIndicator.JEDGCOMDEKM("FOUND", 657f, 1475f, true);
		}
		else
		{
			MBIAKMPDOPG.cardIconIndicator.PEBHGOMEKME("playerVisuals", false);
			BHABHIDDBLH = DFLOEMPMJPJ();
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual float KNIAIAFLKDG()
	{
		return 1545f;
	}

	protected void LIMHNKKJODK()
	{
		if (!NNDMKIACBBM || ANMEHGAFBEG)
		{
			return;
		}
		if (BHABHIDDBLH > 1141f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			MBIAKMPDOPG.cardIconIndicator.CMFDIDFKHPF("SHOWING ADD FOR ZONE All", BHABHIDDBLH / FGHNICOGGKH());
			if (FDGLGCIJCBA != (int)Time.time)
			{
				FDGLGCIJCBA = (int)Time.time;
				MBIAKMPDOPG.FOCIOKMPCAG.Heal(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC / CKHBNPMNBFL(), false);
			}
		}
		else
		{
			DisconnectEvents();
		}
	}

	[SpecialName]
	public virtual float DIDDDHJPHOJ()
	{
		return 1559f;
	}

	[SpecialName]
	public virtual float DGBJPCOGNIA()
	{
		return 1177f;
	}

	public virtual bool KPNLIFOEFAD(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	protected void GPLKEOAHFJI()
	{
		if (!NNDMKIACBBM || ANMEHGAFBEG)
		{
			return;
		}
		if (BHABHIDDBLH > 1299f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			MBIAKMPDOPG.cardIconIndicator.PAFGKMLGDGP("ID_CONNECTTOGOOGLEPLAY", BHABHIDDBLH / timeInSec);
			if (FDGLGCIJCBA != (int)Time.time)
			{
				FDGLGCIJCBA = (int)Time.time;
				MBIAKMPDOPG.FOCIOKMPCAG.LNPKAAGJIGO(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC / HODMEPFPDEO(), false);
			}
		}
		else
		{
			DisconnectEvents();
		}
	}

	protected void CJAHPFMAMKK()
	{
		if (!NNDMKIACBBM || ANMEHGAFBEG)
		{
			return;
		}
		if (BHABHIDDBLH > 676f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			MBIAKMPDOPG.cardIconIndicator.OODPJFJIMPI("[FFFFFF] (", BHABHIDDBLH / KHIDFKLBIOJ());
			if (FDGLGCIJCBA != (int)Time.time)
			{
				FDGLGCIJCBA = (int)Time.time;
				MBIAKMPDOPG.FOCIOKMPCAG.Heal(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC / HODMEPFPDEO(), false);
			}
		}
		else
		{
			DisconnectEvents();
		}
	}

	[SpecialName]
	public virtual float OJABACAOGBJ()
	{
		return 320f;
	}

	[SpecialName]
	public virtual float CKPJMLADPML()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-43)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float AIBACCNFCPJ()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-25)).FLOATVALUE;
	}

	[SpecialName]
	public virtual float AABHJHONHPI()
	{
		return 517f;
	}

	public virtual bool IHFBJPEDJOE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	protected void HNOBCHFHPNF()
	{
		if (!NNDMKIACBBM || ANMEHGAFBEG)
		{
			return;
		}
		if (BHABHIDDBLH > 1954f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			MBIAKMPDOPG.cardIconIndicator.BBCGKKJPIIN("unregisterConnectionCallbacks", BHABHIDDBLH / FGHNICOGGKH());
			if (FDGLGCIJCBA != (int)Time.time)
			{
				FDGLGCIJCBA = (int)Time.time;
				MBIAKMPDOPG.FOCIOKMPCAG.LNPKAAGJIGO(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC / DFLOEMPMJPJ(), false);
			}
		}
		else
		{
			DisconnectEvents();
		}
	}

	public virtual void KDPIJNFDMKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		FNAPLODKCKC = Random.Range(MKALIFKFBDL(), LMHAHEOAHLB());
		if (ANMEHGAFBEG)
		{
			MBIAKMPDOPG.FOCIOKMPCAG.Heal(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC, false);
			MBIAKMPDOPG.FOCIOKMPCAG.Sync();
			MBIAKMPDOPG.cardIconIndicator.JOGFDHFOOBC("Value2", 1860f, 1410f, true);
		}
		else
		{
			MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("clientVersion", false);
			BHABHIDDBLH = GNKGAIABFHM();
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool APFPKGCEPKL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool CPBLPFNJLBK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string KGJIEDNENPD()
	{
		string result;
		if (ANMEHGAFBEG)
		{
			string keyFormat = mDescriptionID;
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.JJBMMICPIIG(KHEIPJNFDGE());
			result = Localization.LocalizeFormat(keyFormat, array);
		}
		else
		{
			string keyFormat2 = mDescriptionID;
			object[] array2 = new object[4];
			array2[1] = MEJMLNDFDBP.JJBMMICPIIG(amountOfHealMin);
			array2[1] = MEJMLNDFDBP.JJBMMICPIIG(AJAJEIEOPED());
			array2[7] = MEJMLNDFDBP.AIPKMDCJCOG(timeInSec, "TÉLÉCHARGER");
			result = Localization.LocalizeFormat(keyFormat2, array2);
		}
		return result;
	}

	[SpecialName]
	public virtual float KHEIPJNFDGE()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)76).FLOATVALUE;
	}

	[SpecialName]
	public virtual float CJHIENIBMJA()
	{
		return 549f;
	}

	[SpecialName]
	public virtual float AJAJEIEOPED()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ShiedlsRefectionTime).FLOATVALUE;
	}

	public virtual bool KHMOGLMEHGK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual float KHIDFKLBIOJ()
	{
		return 1498f;
	}

	public virtual void NPAMMCJAFLL()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 586f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("checking connection", true);
		}
	}

	[SpecialName]
	protected virtual string POAEKGOAIKI()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(KHEIPJNFDGE());
	}

	[SpecialName]
	protected virtual string AACALLNNGLN()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(CKPJMLADPML());
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string LPFFKPBFLIP()
	{
		string result;
		if (ANMEHGAFBEG)
		{
			result = Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(OPBCLHPPGGL()));
		}
		else
		{
			string keyFormat = mDescriptionID;
			object[] array = new object[2];
			array[1] = MEJMLNDFDBP.JJBMMICPIIG(AIBACCNFCPJ());
			array[0] = MEJMLNDFDBP.JJBMMICPIIG(LMHAHEOAHLB());
			array[0] = MEJMLNDFDBP.AIPKMDCJCOG(GCEFNKEHKAG(), "ID_JOINASQUAD");
			result = Localization.LocalizeFormat(keyFormat, array);
		}
		return result;
	}

	public virtual void JBNMBMOJPAK()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 193f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.DLNGGGOEDLL("DogTagLastUpdate", false, true);
		}
	}

	public virtual void EHFIHPJILMG()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1424f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.GCLFBCIKNAH("RemoveRewards", true, true);
		}
	}

	public virtual bool OFBIPJIEDPP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string BMNHMKAMAHP()
	{
		string result;
		if (ANMEHGAFBEG)
		{
			result = Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(IHJGJHPCFEF()));
		}
		else
		{
			string keyFormat = mDescriptionID;
			object[] array = new object[8];
			array[1] = MEJMLNDFDBP.JJBMMICPIIG(MKALIFKFBDL());
			array[1] = MEJMLNDFDBP.JJBMMICPIIG(LMHAHEOAHLB());
			array[8] = MEJMLNDFDBP.AIPKMDCJCOG(HIHOIDNGECC(), "ID_TUTORIAL_NOACCOUNT_{0}_TEXT");
			result = Localization.LocalizeFormat(keyFormat, array);
		}
		return result;
	}

	[SpecialName]
	public virtual float DDBOGDKNMFC()
	{
		return 823f;
	}

	[SpecialName]
	public virtual float IHJGJHPCFEF()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)81).FLOATVALUE;
	}

	[SpecialName]
	public virtual float GOCCEOEFFAH()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-95)).FLOATVALUE;
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		FNAPLODKCKC = Random.Range(amountOfHealMin, amountOfHealMax);
		if (ANMEHGAFBEG)
		{
			MBIAKMPDOPG.FOCIOKMPCAG.Heal(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC, false);
			MBIAKMPDOPG.FOCIOKMPCAG.Sync();
			MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-healingstorm", 3f, 3f, false);
		}
		else
		{
			MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-healingstorm", true);
			BHABHIDDBLH = timeInSec;
			NNDMKIACBBM = true;
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void NMOKBODAKHB()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1203f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("ArenaPrice", false);
		}
	}

	public virtual void CFIKIKCBGKI()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1363f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.LDGKPCDJPLA("ID_BOSS", true, true);
		}
	}

	[SpecialName]
	protected virtual string CKKFCMLLKKG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(AIBACCNFCPJ());
	}

	public virtual void GKDDIKLDCHC()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 604f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.NNPILDOKNJO("S", false);
		}
	}

	public virtual void AJLIIHKDAOD()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 1458f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.GKAOMCGCDGE("Warbucks", false);
		}
	}

	[SpecialName]
	public virtual float HODMEPFPDEO()
	{
		return 911f;
	}

	protected void PHABEKGALCE()
	{
		if (!NNDMKIACBBM || ANMEHGAFBEG)
		{
			return;
		}
		if (BHABHIDDBLH > 87f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("percent", BHABHIDDBLH / DGBJPCOGNIA());
			if (FDGLGCIJCBA != (int)Time.time)
			{
				FDGLGCIJCBA = (int)Time.time;
				MBIAKMPDOPG.FOCIOKMPCAG.Heal(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC / KHIDFKLBIOJ(), false);
			}
		}
		else
		{
			DisconnectEvents();
		}
	}

	protected void OFNEGNKMKKG()
	{
		if (!NNDMKIACBBM || ANMEHGAFBEG)
		{
			return;
		}
		if (BHABHIDDBLH > 869f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			MBIAKMPDOPG.cardIconIndicator.LAJPOLNEDAD("ID_DIVISION", BHABHIDDBLH / FGHNICOGGKH());
			if (FDGLGCIJCBA != (int)Time.time)
			{
				FDGLGCIJCBA = (int)Time.time;
				MBIAKMPDOPG.FOCIOKMPCAG.LNPKAAGJIGO(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC / CJHIENIBMJA(), false);
			}
		}
		else
		{
			DisconnectEvents();
		}
	}

	public virtual void KLEPKFBJIBA()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 815f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.LJLDJOHAAMC("Ground texture: ", true, true);
		}
	}

	public virtual void HHKFLIABFCA()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 70f;
			NNDMKIACBBM = true;
			MBIAKMPDOPG.cardIconIndicator.GGHDIAFACAH("S", false);
		}
	}

	[SpecialName]
	public virtual float CPAEFNNJHAH()
	{
		return 993f;
	}

	[SpecialName]
	public virtual float LMHAHEOAHLB()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)68).FLOATVALUE;
	}

	[SpecialName]
	public virtual string NMMJABOJHND()
	{
		string result;
		if (ANMEHGAFBEG)
		{
			string keyFormat = mDescriptionID;
			object[] array = new object[0];
			array[1] = MEJMLNDFDBP.JJBMMICPIIG(KHEIPJNFDGE());
			result = Localization.LocalizeFormat(keyFormat, array);
		}
		else
		{
			string keyFormat2 = mDescriptionID;
			object[] array2 = new object[2];
			array2[1] = MEJMLNDFDBP.JJBMMICPIIG(OPBCLHPPGGL());
			array2[1] = MEJMLNDFDBP.JJBMMICPIIG(HFNCOHEGKEB());
			array2[7] = MEJMLNDFDBP.AIPKMDCJCOG(DFLOEMPMJPJ(), "Skipping instant battle notification");
			result = Localization.LocalizeFormat(keyFormat2, array2);
		}
		return result;
	}

	public virtual bool KBIBLEMBNEP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string ALBOHHNCNOM()
	{
		return (!ANMEHGAFBEG) ? Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(amountOfHealMin), MEJMLNDFDBP.JJBMMICPIIG(AJAJEIEOPED()), null, MEJMLNDFDBP.AIPKMDCJCOG(DGBJPCOGNIA(), "Days_Since_Install"), null, null, null) : Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(AIBACCNFCPJ()));
	}

	[SpecialName]
	public virtual float GIOAENCNOIJ()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-75)).FLOATVALUE;
	}

	protected void Update()
	{
		if (!NNDMKIACBBM || ANMEHGAFBEG)
		{
			return;
		}
		if (BHABHIDDBLH > 0f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			MBIAKMPDOPG.cardIconIndicator.UpdateIndicator("game-card-ico-healingstorm", BHABHIDDBLH / timeInSec);
			if (FDGLGCIJCBA != (int)Time.time)
			{
				FDGLGCIJCBA = (int)Time.time;
				MBIAKMPDOPG.FOCIOKMPCAG.Heal(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC / timeInSec, false);
			}
		}
		else
		{
			DisconnectEvents();
		}
	}

	[SpecialName]
	protected virtual string OEHGCFPAECJ()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(IHJGJHPCFEF());
	}

	protected void FLDCHPBPKND()
	{
		if (!NNDMKIACBBM || ANMEHGAFBEG)
		{
			return;
		}
		if (BHABHIDDBLH > 841f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			MBIAKMPDOPG.cardIconIndicator.KPCGICBFFCO("heatTime", BHABHIDDBLH / KHIDFKLBIOJ());
			if (FDGLGCIJCBA != (int)Time.time)
			{
				FDGLGCIJCBA = (int)Time.time;
				MBIAKMPDOPG.FOCIOKMPCAG.LNPKAAGJIGO(MBIAKMPDOPG.FOCIOKMPCAG.maxHealth * FNAPLODKCKC / DDBOGDKNMFC(), true);
			}
		}
		else
		{
			DisconnectEvents();
		}
	}

	[SpecialName]
	public virtual float MJMDELJDNFH()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.SwiftImmortalityTime).FLOATVALUE;
	}

	[SpecialName]
	public virtual float GNKGAIABFHM()
	{
		return 589f;
	}

	public override void DisconnectEvents()
	{
		base.DisconnectEvents();
		if (NNDMKIACBBM)
		{
			BHABHIDDBLH = 0f;
			NNDMKIACBBM = false;
			MBIAKMPDOPG.cardIconIndicator.Show("game-card-ico-healingstorm", false);
		}
	}

	[SpecialName]
	public virtual float CKHBNPMNBFL()
	{
		return 519f;
	}

	public virtual bool MBILPOJAHDK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool OGOBFGAABIK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (GPHPFBFLIGD >= AABJNJGPHAE)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}
}
