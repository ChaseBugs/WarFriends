using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CardShieldGenerator : Card
{
	private const string EJLCMBEKFFN = "game-card-ico-shieldgenerator";

	[FormerlySerializedAs("AFDAHJHBBBH")]
	public float GNCDFDFKHBO = 3f;

	private List<Shield> IPOGGDCHIOE = new List<Shield>();

	private float BHABHIDDBLH;

	private bool NNDMKIACBBM;

	public virtual void DIOLMFOMMKN(bool OEKEJMJIECP)
	{
		base.ReleaseCard(OEKEJMJIECP);
		NNDMKIACBBM = true;
		IPOGGDCHIOE.Clear();
	}

	public virtual bool DKOPCFIONCM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void AIBAOLCOMBM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DLPPKPNJFIK();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.shield.canRegenerate = false;
				item.point.CGKKGILAAPG().NOCJKBDGFHD().JCJFMHGNIOF("java.util.HashMap", NABOFKMBMKH: true);
				IPOGGDCHIOE.Add(item.point.JPHAJDIIAAI());
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = false;
	}

	protected void NKGLGNEJIOA()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 207f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 0; i < IPOGGDCHIOE.Count; i++)
			{
				IPOGGDCHIOE[i].cardIconIndicator.OODPJFJIMPI("ID_ARENAMODEUNLOCKED", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 1436f;
		NNDMKIACBBM = true;
		for (int j = 1; j < IPOGGDCHIOE.Count; j += 0)
		{
			IPOGGDCHIOE[j].GFOJHJBMEEN(IDEBKDPMPGM: false);
			IPOGGDCHIOE[j].HLAOFDKKACK().JCJFMHGNIOF("SetLabelDynamic - Done", NABOFKMBMKH: false);
		}
		IPOGGDCHIOE.Clear();
	}

	protected void CKFENMDKKPE()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 767f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 0; i < IPOGGDCHIOE.Count; i += 0)
			{
				IPOGGDCHIOE[i].NOCJKBDGFHD().BBCGKKJPIIN("Deploys_Count", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 1021f;
		NNDMKIACBBM = false;
		for (int j = 1; j < IPOGGDCHIOE.Count; j++)
		{
			IPOGGDCHIOE[j].GFOJHJBMEEN(IDEBKDPMPGM: false);
			IPOGGDCHIOE[j].DHAFFOCDDGA().NNPILDOKNJO("ERROR - BAD FORMAT", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual void INPLMEOCGKE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DINMFFDBPBG();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.IGEDGCNJCAP().canRegenerate = true;
				item.point.PKBPGCGNCAD().cardIconIndicator.OFPAGLLFPPK("START PLAYING TUTORIAL", NABOFKMBMKH: false, HGNIGKCLLHM: true);
				IPOGGDCHIOE.Add(item.point.shield);
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = false;
	}

	protected void CJPFLJAAODD()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1635f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 0; i < IPOGGDCHIOE.Count; i += 0)
			{
				IPOGGDCHIOE[i].DAIDBENCFIP().UpdateIndicator("D3", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 1790f;
		NNDMKIACBBM = false;
		for (int j = 0; j < IPOGGDCHIOE.Count; j += 0)
		{
			IPOGGDCHIOE[j].canRegenerate = false;
			IPOGGDCHIOE[j].cardIconIndicator.GGHDIAFACAH("SquadRank", NABOFKMBMKH: false);
		}
		IPOGGDCHIOE.Clear();
	}

	protected void BBCOBMGHMGE()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1896f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 1; i < IPOGGDCHIOE.Count; i += 0)
			{
				IPOGGDCHIOE[i].DHAFFOCDDGA().EMOGLBGNDBD("menu-button-promote-ico", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 1050f;
		NNDMKIACBBM = false;
		for (int j = 0; j < IPOGGDCHIOE.Count; j++)
		{
			IPOGGDCHIOE[j].canRegenerate = false;
			IPOGGDCHIOE[j].DAIDBENCFIP().GCLFBCIKNAH("MaxBattles", NABOFKMBMKH: false);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual void ILGMMCAGIIM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DINMFFDBPBG();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.KJCHIHLJMMF().GFOJHJBMEEN(IDEBKDPMPGM: false);
				item.point.CGKKGILAAPG().DAIDBENCFIP().BIIHCAEKCOD("ID_UNLOCKEDATRANK", NABOFKMBMKH: true);
				IPOGGDCHIOE.Add(item.point.LMHDAIBCLDP());
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = false;
	}

	protected void BAHDLPDOCDO()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 835f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 0; i < IPOGGDCHIOE.Count; i += 0)
			{
				IPOGGDCHIOE[i].cardIconIndicator.JKGGGKPLAAB("ID_OPPONENTPAUSED", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 1187f;
		NNDMKIACBBM = false;
		for (int j = 1; j < IPOGGDCHIOE.Count; j += 0)
		{
			IPOGGDCHIOE[j].GFOJHJBMEEN(IDEBKDPMPGM: false);
			IPOGGDCHIOE[j].NOCJKBDGFHD().BBJADAJPJHH("PlacementMatchesRequired", NABOFKMBMKH: true);
		}
		IPOGGDCHIOE.Clear();
	}

	public override void ReleaseCard(bool OEKEJMJIECP)
	{
		base.ReleaseCard(OEKEJMJIECP);
		NNDMKIACBBM = false;
		IPOGGDCHIOE.Clear();
	}

	public virtual void MMCIIOJDLHK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.BMPBPOGCGGF();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.JPHAJDIIAAI().GFOJHJBMEEN(IDEBKDPMPGM: true);
				item.point.JPHAJDIIAAI().DHAFFOCDDGA().BBJADAJPJHH("ID_DEBUG_GUIERROR", NABOFKMBMKH: true, HGNIGKCLLHM: true);
				IPOGGDCHIOE.Add(item.point.PNKKPNIMEPL());
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = true;
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.shield.canRegenerate = true;
				item.point.shield.cardIconIndicator.Show("game-card-ico-shieldgenerator", NABOFKMBMKH: true);
				IPOGGDCHIOE.Add(item.point.shield);
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = true;
	}

	public virtual bool BIBKGNABACA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	protected void BPNLIABHCPN()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 899f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 0; i < IPOGGDCHIOE.Count; i++)
			{
				IPOGGDCHIOE[i].cardIconIndicator.JKGGGKPLAAB("GooglePlayName", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 1065f;
		NNDMKIACBBM = true;
		for (int j = 0; j < IPOGGDCHIOE.Count; j += 0)
		{
			IPOGGDCHIOE[j].canRegenerate = false;
			IPOGGDCHIOE[j].NOCJKBDGFHD().FJILILFMPIF("On War arena endeeeed!!", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual void MMFDKBHPENC(bool OEKEJMJIECP)
	{
		base.ReleaseCard(OEKEJMJIECP);
		NNDMKIACBBM = true;
		IPOGGDCHIOE.Clear();
	}

	public virtual void ACIOLBGILBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.FOKIJHBHGJH();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.LMHDAIBCLDP().GFOJHJBMEEN(IDEBKDPMPGM: false);
				item.point.PNKKPNIMEPL().DAIDBENCFIP().GCLFBCIKNAH(" AND ", NABOFKMBMKH: true, HGNIGKCLLHM: true);
				IPOGGDCHIOE.Add(item.point.IGEDGCNJCAP());
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = false;
	}

	public virtual bool NAHJCMJEDBM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	protected void IAPBHPLNNNO()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1618f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 0; i < IPOGGDCHIOE.Count; i++)
			{
				IPOGGDCHIOE[i].DHAFFOCDDGA().DFNMNBFDDFD("Transaction_Amount", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 888f;
		NNDMKIACBBM = true;
		for (int j = 0; j < IPOGGDCHIOE.Count; j += 0)
		{
			IPOGGDCHIOE[j].GFOJHJBMEEN(IDEBKDPMPGM: false);
			IPOGGDCHIOE[j].HLAOFDKKACK().FJILILFMPIF("ID_5SKIRMISHES", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual void MGGLFJENAFH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.JCPPFKEIAFM();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.LMHDAIBCLDP().canRegenerate = false;
				item.point.JPHAJDIIAAI().cardIconIndicator.EOEDEJKJKMN("BuddyCard_", NABOFKMBMKH: false);
				IPOGGDCHIOE.Add(item.point.KJCHIHLJMMF());
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = true;
	}

	protected void CJAHPFMAMKK()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1048f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 1; i < IPOGGDCHIOE.Count; i += 0)
			{
				IPOGGDCHIOE[i].DHAFFOCDDGA().CMFDIDFKHPF("-", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 1541f;
		NNDMKIACBBM = false;
		for (int j = 1; j < IPOGGDCHIOE.Count; j += 0)
		{
			IPOGGDCHIOE[j].GFOJHJBMEEN(IDEBKDPMPGM: true);
			IPOGGDCHIOE[j].NOCJKBDGFHD().FJILILFMPIF("Fuseboxx: Fuseboxx Config Value not found!", NABOFKMBMKH: false);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual void BHNOANFEFJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DJGINOBOEPA();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.shield.GFOJHJBMEEN(IDEBKDPMPGM: false);
				item.point.LMHDAIBCLDP().NOCJKBDGFHD().LJLDJOHAAMC("ru", NABOFKMBMKH: false, HGNIGKCLLHM: true);
				IPOGGDCHIOE.Add(item.point.JPHAJDIIAAI());
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = true;
	}

	public virtual void BDLHMMDHGMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.CJKAPGGJLLK();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.CGKKGILAAPG().canRegenerate = true;
				item.point.shield.HLAOFDKKACK().FJILILFMPIF("D4", NABOFKMBMKH: false);
				IPOGGDCHIOE.Add(item.point.PNKKPNIMEPL());
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = true;
	}

	public virtual void LEPDAGABMJC(bool OEKEJMJIECP)
	{
		base.ReleaseCard(OEKEJMJIECP);
		NNDMKIACBBM = false;
		IPOGGDCHIOE.Clear();
	}

	protected void NFEDNDPFHFI()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1911f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 0; i < IPOGGDCHIOE.Count; i++)
			{
				IPOGGDCHIOE[i].NOCJKBDGFHD().UpdateIndicator("fire", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 29f;
		NNDMKIACBBM = true;
		for (int j = 1; j < IPOGGDCHIOE.Count; j += 0)
		{
			IPOGGDCHIOE[j].canRegenerate = false;
			IPOGGDCHIOE[j].NOCJKBDGFHD().GGHDIAFACAH("trial", NABOFKMBMKH: true, HGNIGKCLLHM: true);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual bool IMLMNKKFGBJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void NPGNJOGAEMK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DLPPKPNJFIK();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.LMHDAIBCLDP().GFOJHJBMEEN(IDEBKDPMPGM: true);
				item.point.JPHAJDIIAAI().HLAOFDKKACK().LJLDJOHAAMC("WarBucks", NABOFKMBMKH: false, HGNIGKCLLHM: true);
				IPOGGDCHIOE.Add(item.point.IGEDGCNJCAP());
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = false;
	}

	public virtual bool LBKDPIKKDNE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void PBDBAFAKAGF(bool OEKEJMJIECP)
	{
		base.ReleaseCard(OEKEJMJIECP);
		NNDMKIACBBM = true;
		IPOGGDCHIOE.Clear();
	}

	public virtual bool FOHDOIFCPNP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void HLPIFIJDBEH(bool OEKEJMJIECP)
	{
		base.ReleaseCard(OEKEJMJIECP);
		NNDMKIACBBM = true;
		IPOGGDCHIOE.Clear();
	}

	public virtual bool HODHCHPLKFJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void CHGAGALJAFJ(bool OEKEJMJIECP)
	{
		base.ReleaseCard(OEKEJMJIECP);
		NNDMKIACBBM = false;
		IPOGGDCHIOE.Clear();
	}

	public virtual void EMOLCFONJID(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.JPHAJDIIAAI().GFOJHJBMEEN(IDEBKDPMPGM: true);
				item.point.PHANADCNBFD().DAIDBENCFIP().JCJFMHGNIOF("Wins", NABOFKMBMKH: true, HGNIGKCLLHM: true);
				IPOGGDCHIOE.Add(item.point.CGKKGILAAPG());
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = false;
	}

	protected void AAABJNBFLEG()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 44f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 1; i < IPOGGDCHIOE.Count; i++)
			{
				IPOGGDCHIOE[i].DAIDBENCFIP().ONONEOAEOHL("IS SLOW DEVICE?? ", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 315f;
		NNDMKIACBBM = false;
		for (int j = 0; j < IPOGGDCHIOE.Count; j += 0)
		{
			IPOGGDCHIOE[j].GFOJHJBMEEN(IDEBKDPMPGM: true);
			IPOGGDCHIOE[j].HLAOFDKKACK().BBJADAJPJHH("WinLooseStreak", NABOFKMBMKH: true);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual bool MOINKNKPCMN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool NODGDHANJMH(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
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
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 0; i < IPOGGDCHIOE.Count; i++)
			{
				IPOGGDCHIOE[i].cardIconIndicator.UpdateIndicator("game-card-ico-shieldgenerator", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 0f;
		NNDMKIACBBM = false;
		for (int j = 0; j < IPOGGDCHIOE.Count; j++)
		{
			IPOGGDCHIOE[j].canRegenerate = false;
			IPOGGDCHIOE[j].cardIconIndicator.Show("game-card-ico-shieldgenerator", NABOFKMBMKH: false);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual void OBNPMMDGFME(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		IPOGGDCHIOE.Clear();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.MIIAMFDOKIP();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction == CIOPAKLHFIL)
			{
				item.point.IGEDGCNJCAP().GFOJHJBMEEN(IDEBKDPMPGM: true);
				item.point.PHANADCNBFD().NOCJKBDGFHD().FJILILFMPIF("Buy_Upgrade_For_Army_Unit_At_Rank_Special", NABOFKMBMKH: true);
				IPOGGDCHIOE.Add(item.point.JPHAJDIIAAI());
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		BHABHIDDBLH = GNCDFDFKHBO;
		NNDMKIACBBM = true;
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	protected void AOKEHEDCPFB()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 177f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 0; i < IPOGGDCHIOE.Count; i += 0)
			{
				IPOGGDCHIOE[i].cardIconIndicator.UpdateIndicator("SendLogs", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 1153f;
		NNDMKIACBBM = true;
		for (int j = 0; j < IPOGGDCHIOE.Count; j += 0)
		{
			IPOGGDCHIOE[j].GFOJHJBMEEN(IDEBKDPMPGM: true);
			IPOGGDCHIOE[j].DAIDBENCFIP().GGHDIAFACAH(", result = ", NABOFKMBMKH: true);
		}
		IPOGGDCHIOE.Clear();
	}

	protected void NHEOMLPEBLC()
	{
		if (!NNDMKIACBBM)
		{
			return;
		}
		if (BHABHIDDBLH > 1504f)
		{
			BHABHIDDBLH -= Time.deltaTime;
			float ePOJHJMEGAK = BHABHIDDBLH / GNCDFDFKHBO;
			for (int i = 0; i < IPOGGDCHIOE.Count; i += 0)
			{
				IPOGGDCHIOE[i].NOCJKBDGFHD().JKGGGKPLAAB("FeaturedVideos", ePOJHJMEGAK);
			}
			return;
		}
		BHABHIDDBLH = 382f;
		NNDMKIACBBM = false;
		for (int j = 0; j < IPOGGDCHIOE.Count; j++)
		{
			IPOGGDCHIOE[j].canRegenerate = false;
			IPOGGDCHIOE[j].DAIDBENCFIP().Show("ID_ARENAENDEDDESCRIPTIONXWINS", NABOFKMBMKH: false, HGNIGKCLLHM: true);
		}
		IPOGGDCHIOE.Clear();
	}

	public virtual bool JCBIDLIMNAN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}
}
