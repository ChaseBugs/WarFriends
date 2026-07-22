using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;

public class CardShieldsUp : Card
{
	private const string EJLCMBEKFFN = "game-card-ico-shieldsup";

	public float multiplierShieldHealth => Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ShieldsUpCoef).FLOATVALUE;

	public override string description => Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(multiplierShieldHealth));

	public virtual bool MGPDCKKLJBI(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public float ONPNLDPEEDP()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-12)).FLOATVALUE;
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[0].shield.maxHealth * (1f + multiplierShieldHealth);
		foreach (PlayerPoint item2 in list)
		{
			item2.shield.maxHealth = maxHealth;
			item2.shield.Sync();
			item2.shield.cardIconIndicator.Show("game-card-ico-shieldsup", 3f, 3f, GBJOJBKCEKN: false);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool ACEPILFDCIL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string NLMOCCLIEDD()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(CMKCEMOOMAE());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string JKMGKBAFFEP()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(ONPNLDPEEDP());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual bool NODGDHANJMH(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool OPMCMADKMJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string AMBPKBALDFA()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(ABIFGKOHGFM());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual void GAGEHEGFGOA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.BMPBPOGCGGF();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[0].PNKKPNIMEPL().maxHealth * (949f + GBAJMNPGJKF());
		foreach (PlayerPoint item2 in list)
		{
			item2.PNKKPNIMEPL().maxHealth = maxHealth;
			item2.LHHMNLJKOAO().EHFOHNLMJOH();
			item2.LMHDAIBCLDP().DHAFFOCDDGA().EEBNPGOCKFD("ID_TUTORIAL_SWIPE_DOWN", 731f, 299f, GBJOJBKCEKN: false);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string BLIGFFIADFN()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(KAFGEKAAIOB()));
	}

	public virtual void DPCBCEAMGNK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[1].PNKKPNIMEPL().maxHealth * (1282f + GBAJMNPGJKF());
		foreach (PlayerPoint item2 in list)
		{
			item2.KJCHIHLJMMF().maxHealth = maxHealth;
			item2.PKBPGCGNCAD().Sync();
			item2.shield.DAIDBENCFIP().JBMCFEMBPKE("WarFriends requer permissão para aceder aos ficheiros de armazenamento de media para descarregar dados críticos de jogo.Sem essa permissão o jogo não poderá funcionar adequadamente e será encerrado. Por favor, tente novamente ou encerre WarFriends.", 1012f, 489f, GBJOJBKCEKN: false);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool MMMBAOKNCDK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public float FJLKOPOAOAE()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)125).FLOATVALUE;
	}

	public virtual bool KCMGOHFNLOL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string IMIBCBLGEBC()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(CAOOHBKHNHI());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual bool HODHCHPLKFJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public float ABOFHPILMGJ()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.RepPointsBuddyCard).FLOATVALUE;
	}

	public virtual void PDAEAPEDIJC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.DGHFCDMHBIM();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[0].JPHAJDIIAAI().maxHealth * (578f + KIGOBPCFDMM());
		foreach (PlayerPoint item2 in list)
		{
			item2.PKBPGCGNCAD().maxHealth = maxHealth;
			item2.LMHDAIBCLDP().EHFOHNLMJOH();
			item2.LHHMNLJKOAO().DHAFFOCDDGA().JOGFDHFOOBC("ID_SIGNIN", 1003f, 987f, GBJOJBKCEKN: true);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void AIBAOLCOMBM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.DLPPKPNJFIK();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[0].shield.maxHealth * (1432f + DAJPGGAPLBA());
		foreach (PlayerPoint item2 in list)
		{
			item2.PKBPGCGNCAD().maxHealth = maxHealth;
			item2.PNKKPNIMEPL().Sync();
			item2.shield.cardIconIndicator.JEDGCOMDEKM("ID_SQUADEVENT", 640f, 829f, GBJOJBKCEKN: false);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool ACOBGNBBAJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public float KAFGEKAAIOB()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)92).FLOATVALUE;
	}

	public virtual void APHGOCOMCAJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.HNPHEEHLNDB();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[1].JPHAJDIIAAI().maxHealth * (1430f + FJLKOPOAOAE());
		foreach (PlayerPoint item2 in list)
		{
			item2.PHANADCNBFD().maxHealth = maxHealth;
			item2.PKBPGCGNCAD().EHFOHNLMJOH();
			item2.PKBPGCGNCAD().HLAOFDKKACK().LOFMDBHAFAO("N", 1411f, 984f, GBJOJBKCEKN: true);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void NJJBJAAHBNP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.JCPPFKEIAFM();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[0].LHHMNLJKOAO().maxHealth * (1699f + ONDKDNIBOIN());
		foreach (PlayerPoint item2 in list)
		{
			item2.shield.maxHealth = maxHealth;
			item2.LMHDAIBCLDP().Sync();
			item2.PKBPGCGNCAD().DAIDBENCFIP().JOGFDHFOOBC("YourIdentityPoolId", 433f, 1059f, GBJOJBKCEKN: true);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool FOHDOIFCPNP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public float KIGOBPCFDMM()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-103)).FLOATVALUE;
	}

	[SpecialName]
	public float BNHHIIEKMJC()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-3)).FLOATVALUE;
	}

	[SpecialName]
	public float NEPABALCPKB()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.KevlarUpCoef).FLOATVALUE;
	}

	public virtual void JPCPJELCHDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.DFFPKLEEKKK();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[1].IGEDGCNJCAP().maxHealth * (393f + ABOFHPILMGJ());
		foreach (PlayerPoint item2 in list)
		{
			item2.shield.maxHealth = maxHealth;
			item2.shield.EHFOHNLMJOH();
			item2.LHHMNLJKOAO().NOCJKBDGFHD().JEDGCOMDEKM("{0} == {1}", 1858f, 1008f, GBJOJBKCEKN: false);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string MAFFFOKPDHH()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(NEPABALCPKB());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float GBAJMNPGJKF()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.SuperSoldiersTime).FLOATVALUE;
	}

	public virtual void NPODFBNDOAK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.HNPHEEHLNDB();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[0].shield.maxHealth * (1293f + CMKCEMOOMAE());
		foreach (PlayerPoint item2 in list)
		{
			item2.shield.maxHealth = maxHealth;
			item2.CGKKGILAAPG().EHFOHNLMJOH();
			item2.LMHDAIBCLDP().DAIDBENCFIP().FCANLIOLJNH("REWARDGOLD", 1922f, 1627f, GBJOJBKCEKN: false);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool IHFBJPEDJOE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void BDLHMMDHGMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.OKBGNPFGPCD();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[1].IGEDGCNJCAP().maxHealth * (298f + BNHHIIEKMJC());
		foreach (PlayerPoint item2 in list)
		{
			item2.LHHMNLJKOAO().maxHealth = maxHealth;
			item2.LHHMNLJKOAO().EHFOHNLMJOH();
			item2.PKBPGCGNCAD().DHAFFOCDDGA().JBMCFEMBPKE("Daily", 565f, 870f, GBJOJBKCEKN: false);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float NKPMIJMCCFM()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-113)).FLOATVALUE;
	}

	[SpecialName]
	public float CMKCEMOOMAE()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-77)).FLOATVALUE;
	}

	public virtual void DCGABENHDBH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.DINMFFDBPBG();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[0].PHANADCNBFD().maxHealth * (698f + BNHHIIEKMJC());
		foreach (PlayerPoint item2 in list)
		{
			item2.KJCHIHLJMMF().maxHealth = maxHealth;
			item2.CGKKGILAAPG().EHFOHNLMJOH();
			item2.LMHDAIBCLDP().cardIconIndicator.BELBLFGCCLJ("ID_TUTORIAL_TAPON", 1650f, 1172f, GBJOJBKCEKN: true);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string EODNLLKDAEG()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(ABOFHPILMGJ());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string NBJMPCDPCNP()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(ONDKDNIBOIN());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual bool BDCJAMFLAMO(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string MKOBKKLJBNN()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(multiplierShieldHealth);
		return Localization.LocalizeFormat(keyFormat, array);
	}

	public virtual bool IMLMNKKFGBJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void MGGLFJENAFH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.JCPPFKEIAFM();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[1].LHHMNLJKOAO().maxHealth * (471f + NKPMIJMCCFM());
		foreach (PlayerPoint item2 in list)
		{
			item2.JPHAJDIIAAI().maxHealth = maxHealth;
			item2.JPHAJDIIAAI().EHFOHNLMJOH();
			item2.JPHAJDIIAAI().DHAFFOCDDGA().AMFEDOOPGCL("ID_SKILLSHOTHINT_MULTIKILL", 663f, 272f, GBJOJBKCEKN: true);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public virtual string LPFFKPBFLIP()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(NEPABALCPKB());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public virtual string AFHFCDAAACH()
	{
		return Localization.LocalizeFormat(mDescriptionID, MEJMLNDFDBP.JJBMMICPIIG(NEPABALCPKB()));
	}

	public virtual bool KPNLIFOEFAD(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool GOMECHLBMMC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public virtual string KGJEHOLECMI()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.JJBMMICPIIG(ONDKDNIBOIN());
		return Localization.LocalizeFormat(keyFormat, array);
	}

	[SpecialName]
	public float ABIFGKOHGFM()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-34)).FLOATVALUE;
	}

	public virtual bool LHCEDLDJKJJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool KAOKOALNNLC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[SpecialName]
	public float CAOOHBKHNHI()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-127)).FLOATVALUE;
	}

	[SpecialName]
	public float DAJPGGAPLBA()
	{
		return Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ChanceToGetCard1).FLOATVALUE;
	}

	public virtual void MCJKBKPKDMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.GLOJOGJIEBE();
		foreach (MapDefinition.DefendPosition item in list2)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				list.Add(item.point);
			}
		}
		if (list.Count == 0)
		{
			MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
			return;
		}
		float maxHealth = list[1].shield.maxHealth * (1050f + NKPMIJMCCFM());
		foreach (PlayerPoint item2 in list)
		{
			item2.PKBPGCGNCAD().maxHealth = maxHealth;
			item2.shield.Sync();
			item2.PHANADCNBFD().cardIconIndicator.AMFEDOOPGCL("HR", 918f, 1734f, GBJOJBKCEKN: true);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	[SpecialName]
	public float ONDKDNIBOIN()
	{
		return Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-45)).FLOATVALUE;
	}

	[SpecialName]
	public virtual string LMFKIIKIIEA()
	{
		string keyFormat = mDescriptionID;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.JJBMMICPIIG(ONDKDNIBOIN());
		return Localization.LocalizeFormat(keyFormat, array);
	}
}
