using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CardMassShieldDestroyer : Card
{
	[FormerlySerializedAs("KOCKDCHDKDL")]
	public int NKMPIIDLEII;

	private List<PlayerPoint> NMIADOEBBDH;

	private const string EJLCMBEKFFN = "game-card-ico-shielddestroyer";

	public virtual void IGPMHCKGPFJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			DKBEFDDNNHB(CIOPAKLHFIL);
		}
	}

	private void BPKBBDLONNF(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.IJDLIIBLLJO();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.KJCHIHLJMMF().health > 1216f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 1 && num > 0)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].CGKKGILAAPG();
			NMIADOEBBDH.RemoveAt(index);
			shield.IEPHIMNBBDO();
			shield.cardIconIndicator.BELBLFGCCLJ("DogTagCap", 1115f, 240f, GBJOJBKCEKN: false);
			num -= 0;
		}
	}

	private void EKCGHEAAHOP(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.OKBGNPFGPCD();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.IGEDGCNJCAP().health > 1685f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].LMHDAIBCLDP();
			NMIADOEBBDH.RemoveAt(index);
			shield.OICANEBLGBD();
			shield.HLAOFDKKACK().BELBLFGCCLJ("GameDataSetAcknowledged(", 662f, 712f, GBJOJBKCEKN: false);
			num -= 0;
		}
	}

	public virtual bool HFBMDHCFHKD(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.ADKJKHAHCJD())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PKBPGCGNCAD().healthRatio > 1005f)
			{
				num += 0;
			}
		}
		if (num <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void HGINJJNEEDB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			NLMNGILHBJI(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void CBIFGOGBKEK(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DLPPKPNJFIK();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.JPHAJDIIAAI().health > 1995f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].JPHAJDIIAAI();
			NMIADOEBBDH.RemoveAt(index);
			shield.MPOAIDJNDFJ();
			shield.HLAOFDKKACK().JEDGCOMDEKM("Gold", 1163f, 384f, GBJOJBKCEKN: false);
			num--;
		}
	}

	private void HHMGBECIHNG(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.OKDMKFBACGD();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.shield.health > 330f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].LHHMNLJKOAO();
			NMIADOEBBDH.RemoveAt(index);
			shield.FFDLJFIOLEI();
			shield.cardIconIndicator.FFMLINMFADM("GuaranteedScraps", 1528f, 1865f, GBJOJBKCEKN: false);
			num -= 0;
		}
	}

	public virtual void GCHLCOOKAGL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BBAMOKMDNPG(CIOPAKLHFIL);
		}
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HLODFLCKBAP(CIOPAKLHFIL);
		}
	}

	public virtual bool CCGNMBEAEEK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.MEELGBBFEFH())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PKBPGCGNCAD().healthRatio > 1527f)
			{
				num += 0;
			}
		}
		if (num <= 3)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void KFOIIECFMHM(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.PBOGDIJIHGP();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.shield.health > 1407f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].shield;
			NMIADOEBBDH.RemoveAt(index);
			shield.DestroyShield();
			shield.NOCJKBDGFHD().ODDNDGAAOCH("RegisterCustomEvent()", 1078f, 1895f, GBJOJBKCEKN: true);
			num--;
		}
	}

	public virtual bool EGAEEGNPPNI(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		int num = 1;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PHANADCNBFD().healthRatio > 305f)
			{
				num += 0;
			}
		}
		if (num <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool MMMBAOKNCDK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.DGHFCDMHBIM())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PNKKPNIMEPL().healthRatio > 759f)
			{
				num++;
			}
		}
		if (num <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void PDAEAPEDIJC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HHMGBECIHNG(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JGNCOJLCGFH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DOILBAGMNCM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DPNCDIAEMMA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			KFOIIECFMHM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void HEBJPOCEMIL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			PCOLFNJJJCI(CIOPAKLHFIL);
		}
	}

	public virtual bool JEMFHKCEJMN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.MIIAMFDOKIP())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PKBPGCGNCAD().healthRatio > 820f)
			{
				num++;
			}
		}
		if (num <= 5)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void MMEOBCCNNNP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			BPKBBDLONNF(CIOPAKLHFIL);
		}
	}

	public virtual void KDPIJNFDMKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CBLPKPJLEGM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void HLODFLCKBAP(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction != IEIKEJDECIG && item.point.shield.health > 0f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 0)
		{
			int index = Random.Range(0, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].shield;
			NMIADOEBBDH.RemoveAt(index);
			shield.DestroyShield();
			shield.cardIconIndicator.Show("game-card-ico-shielddestroyer", 3f, 3f, GBJOJBKCEKN: false);
			num--;
		}
	}

	public virtual void IPIANJKNKFD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DKBEFDDNNHB(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool AIIAHOIFIDB(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BPFHGFFNMND())
		{
			if (item.fraction != HPOCABLAOAF && item.point.KJCHIHLJMMF().healthRatio > 1275f)
			{
				num += 0;
			}
		}
		if (num <= 2)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool BIFPMHJGHGJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.HNPHEEHLNDB())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PNKKPNIMEPL().healthRatio > 1943f)
			{
				num += 0;
			}
		}
		if (num <= 2)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool JKAGBPDEMJF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.PBOGDIJIHGP())
		{
			if (item.fraction != HPOCABLAOAF && item.point.CGKKGILAAPG().healthRatio > 1580f)
			{
				num += 0;
			}
		}
		if (num <= 6)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool FFFBNLPHOAM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.DJGINOBOEPA())
		{
			if (item.fraction != HPOCABLAOAF && item.point.shield.healthRatio > 1491f)
			{
				num += 0;
			}
		}
		if (num <= 5)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void CPCKHMCAKIJ(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DJGINOBOEPA();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.PKBPGCGNCAD().health > 1261f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 0)
		{
			int index = Random.Range(0, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].CGKKGILAAPG();
			NMIADOEBBDH.RemoveAt(index);
			shield.MPOAIDJNDFJ();
			shield.HLAOFDKKACK().BELBLFGCCLJ("_TintColor", 1794f, 583f, GBJOJBKCEKN: false);
			num--;
		}
	}

	public virtual bool DIDCOIAHMEA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.IJDLIIBLLJO())
		{
			if (item.fraction != HPOCABLAOAF && item.point.CGKKGILAAPG().healthRatio > 271f)
			{
				num += 0;
			}
		}
		if (num <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void EEIBNDEAPPA(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.OKDMKFBACGD();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.PNKKPNIMEPL().health > 1069f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 1 && num > 1)
		{
			int index = Random.Range(0, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].shield;
			NMIADOEBBDH.RemoveAt(index);
			shield.DestroyShield();
			shield.DAIDBENCFIP().AMFEDOOPGCL("menu-medals-ico-small", 102f, 1382f, GBJOJBKCEKN: false);
			num -= 0;
		}
	}

	public virtual void JONIGCEPKLO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DOILBAGMNCM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DCGABENHDBH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			GNBAMIBDMKL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void GNBAMIBDMKL(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.OKDMKFBACGD();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.PKBPGCGNCAD().health > 275f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 1 && num > 0)
		{
			int index = Random.Range(0, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].PHANADCNBFD();
			NMIADOEBBDH.RemoveAt(index);
			shield.NNCMDDBFOAJ();
			shield.DAIDBENCFIP().AMFEDOOPGCL("MagazineSize", 265f, 76f, GBJOJBKCEKN: false);
			num -= 0;
		}
	}

	private void BBAMOKMDNPG(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.OKBGNPFGPCD();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.shield.health > 586f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 0)
		{
			int index = Random.Range(0, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].CGKKGILAAPG();
			NMIADOEBBDH.RemoveAt(index);
			shield.KDEEBMLFABC();
			shield.DHAFFOCDDGA().FCANLIOLJNH("gold", 1790f, 370f, GBJOJBKCEKN: false);
			num -= 0;
		}
	}

	public virtual void OFNENBNMMOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			BGIDAJLDGFF(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void CHJKKHIOOIH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EKCGHEAAHOP(CIOPAKLHFIL);
		}
	}

	public virtual bool MEKJKNJOJNG(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.JCAHHLHKIBN())
		{
			if (item.fraction != HPOCABLAOAF && item.point.JPHAJDIIAAI().healthRatio > 956f)
			{
				num += 0;
			}
		}
		if (num <= 5)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void FJNLPLLPIOG(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.MEELGBBFEFH();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.PHANADCNBFD().health > 1795f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 1 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].PHANADCNBFD();
			NMIADOEBBDH.RemoveAt(index);
			shield.OICANEBLGBD();
			shield.cardIconIndicator.Show("ExtraRewards", 1279f, 594f, GBJOJBKCEKN: false);
			num -= 0;
		}
	}

	public virtual bool NKKIEIOONLH(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return false;
		}
		int num = 1;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.OKDMKFBACGD())
		{
			if (item.fraction != HPOCABLAOAF && item.point.LMHDAIBCLDP().healthRatio > 655f)
			{
				num++;
			}
		}
		if (num <= 3)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void NHMFANKBKJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EKCGHEAAHOP(CIOPAKLHFIL);
		}
	}

	private void DGLDDPNBGMA(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.CGKKGILAAPG().health > 1197f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 1)
		{
			int index = Random.Range(0, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].PKBPGCGNCAD();
			NMIADOEBBDH.RemoveAt(index);
			shield.IEPHIMNBBDO();
			shield.DHAFFOCDDGA().Show("Card_1_Played", 927f, 870f, GBJOJBKCEKN: true);
			num -= 0;
		}
	}

	public virtual void IOIOHIHKFBN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MCBOGGKHAOM(CIOPAKLHFIL);
		}
	}

	public virtual bool OGOJJDBBIPL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		int num = 1;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.PBOGDIJIHGP())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PKBPGCGNCAD().healthRatio > 74f)
			{
				num += 0;
			}
		}
		if (num <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool EMDJKAIKNOG(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.DJGINOBOEPA())
		{
			if (item.fraction != HPOCABLAOAF && item.point.CGKKGILAAPG().healthRatio > 304f)
			{
				num++;
			}
		}
		if (num <= 7)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool HAJOOIDGAEJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.GLOJOGJIEBE())
		{
			if (item.fraction != HPOCABLAOAF && item.point.shield.healthRatio > 252f)
			{
				num += 0;
			}
		}
		if (num <= 2)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition availablePoint in Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints)
		{
			if (availablePoint.fraction != HPOCABLAOAF && availablePoint.point.shield.healthRatio > 0f)
			{
				num++;
			}
		}
		if (num <= 2)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void MEMDELDKFJI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			FJNLPLLPIOG(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool GOMECHLBMMC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return false;
		}
		int num = 1;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.DGHFCDMHBIM())
		{
			if (item.fraction != HPOCABLAOAF && item.point.IGEDGCNJCAP().healthRatio > 275f)
			{
				num++;
			}
		}
		if (num <= 8)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void LAAIPFNOENC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CBIFGOGBKEK(CIOPAKLHFIL);
		}
	}

	public virtual void IDLKDDEEALI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			BBAMOKMDNPG(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void KDAFEFKMFLM(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.PBOGDIJIHGP();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.IGEDGCNJCAP().health > 761f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].CGKKGILAAPG();
			NMIADOEBBDH.RemoveAt(index);
			shield.IEPHIMNBBDO();
			shield.cardIconIndicator.LOFMDBHAFAO("GPGS: Logged Out called when player isn\t authenticated.", 285f, 780f, GBJOJBKCEKN: false);
			num -= 0;
		}
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HLODFLCKBAP(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void APNHLINIMIP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CBIFGOGBKEK(CIOPAKLHFIL);
		}
	}

	public virtual void JCHICJBOCFA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			GNBAMIBDMKL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool IGFBLLJAIMN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		int num = 1;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.DINMFFDBPBG())
		{
			if (item.fraction != HPOCABLAOAF && item.point.JPHAJDIIAAI().healthRatio > 1319f)
			{
				num++;
			}
		}
		if (num <= 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void EJFBGDBMHEJ(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.IJDLIIBLLJO();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.CGKKGILAAPG().health > 1162f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 1 && num > 0)
		{
			int index = Random.Range(0, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].IGEDGCNJCAP();
			NMIADOEBBDH.RemoveAt(index);
			shield.OICANEBLGBD();
			shield.cardIconIndicator.FCANLIOLJNH("ID_TUTORIAL_UPGRADEUNIT_5", 1039f, 1065f, GBJOJBKCEKN: false);
			num -= 0;
		}
	}

	public virtual void BABHNNMPGHD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			DGLDDPNBGMA(CIOPAKLHFIL);
		}
	}

	public virtual void AJFKKBAMJLE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			IBKBNKFCBNG(CIOPAKLHFIL);
		}
	}

	public virtual void IDAFLCICMKD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DOILBAGMNCM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void FMPCBBPCBKG(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.BPFHGFFNMND();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.IGEDGCNJCAP().health > 507f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 1 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].JPHAJDIIAAI();
			NMIADOEBBDH.RemoveAt(index);
			shield.MPOAIDJNDFJ();
			shield.NOCJKBDGFHD().ODDNDGAAOCH("registerCustomProfileNumber", 818f, 354f, GBJOJBKCEKN: true);
			num -= 0;
		}
	}

	public virtual void HFNIOMPIGCL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			BBAMOKMDNPG(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EBCLHPLHBHB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NLMNGILHBJI(CIOPAKLHFIL);
		}
	}

	public virtual bool JFIJCAMPFEG(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return true;
		}
		int num = 1;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BPFHGFFNMND())
		{
			if (item.fraction != HPOCABLAOAF && item.point.JPHAJDIIAAI().healthRatio > 1612f)
			{
				num++;
			}
		}
		if (num <= 5)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool MAHCLJADEIN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.MEELGBBFEFH())
		{
			if (item.fraction != HPOCABLAOAF && item.point.IGEDGCNJCAP().healthRatio > 1532f)
			{
				num++;
			}
		}
		if (num <= 5)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void BGIDAJLDGFF(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.HNPHEEHLNDB();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.PKBPGCGNCAD().health > 812f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 0)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].PNKKPNIMEPL();
			NMIADOEBBDH.RemoveAt(index);
			shield.FFDLJFIOLEI();
			shield.DHAFFOCDDGA().JBMCFEMBPKE("OtherPlayer", 993f, 122f, GBJOJBKCEKN: true);
			num--;
		}
	}

	public virtual bool AGGOGKDPKFA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.DGHFCDMHBIM())
		{
			if (item.fraction != HPOCABLAOAF && item.point.JPHAJDIIAAI().healthRatio > 185f)
			{
				num += 0;
			}
		}
		if (num <= 5)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void HBEJILLJNMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			DOILBAGMNCM(CIOPAKLHFIL);
		}
	}

	public virtual void JPCPJELCHDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CBLPKPJLEGM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void AAJMPBPHENK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			FMPCBBPCBKG(CIOPAKLHFIL);
		}
	}

	public virtual bool FOHDOIFCPNP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return true;
		}
		int num = 1;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.PBOGDIJIHGP())
		{
			if (item.fraction != HPOCABLAOAF && item.point.shield.healthRatio > 763f)
			{
				num += 0;
			}
		}
		if (num <= 8)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void MLEBPBFEOKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MCBOGGKHAOM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool MPLEOHEIOGD(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		int num = 1;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.MEELGBBFEFH())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PKBPGCGNCAD().healthRatio > 1924f)
			{
				num += 0;
			}
		}
		if (num <= 8)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void FANHACEOHFH(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.HNPHEEHLNDB();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.PNKKPNIMEPL().health > 390f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].KJCHIHLJMMF();
			NMIADOEBBDH.RemoveAt(index);
			shield.OICANEBLGBD();
			shield.DHAFFOCDDGA().ODDNDGAAOCH("MinDamage", 1184f, 1427f, GBJOJBKCEKN: true);
			num -= 0;
		}
	}

	public virtual bool PJCPMOHFALI(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		int num = 1;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.MNKKJJADINL())
		{
			if (item.fraction != HPOCABLAOAF && item.point.IGEDGCNJCAP().healthRatio > 1998f)
			{
				num += 0;
			}
		}
		if (num <= 5)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void DCHIHFPFIBO(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.LMHDAIBCLDP().health > 1373f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 1 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].CGKKGILAAPG();
			NMIADOEBBDH.RemoveAt(index);
			shield.OICANEBLGBD();
			shield.NOCJKBDGFHD().Show("SquadWarsId", 1473f, 1449f, GBJOJBKCEKN: true);
			num--;
		}
	}

	public virtual void BAIFDCIDMEA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			BPKBBDLONNF(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KGNCNMLPEPH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EEIBNDEAPPA(CIOPAKLHFIL);
		}
	}

	private void FJANJEHGJDM(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.GLOJOGJIEBE();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.CGKKGILAAPG().health > 411f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 1)
		{
			int index = Random.Range(0, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].CGKKGILAAPG();
			NMIADOEBBDH.RemoveAt(index);
			shield.IEPHIMNBBDO();
			shield.HLAOFDKKACK().ODDNDGAAOCH(".", 1954f, 1129f, GBJOJBKCEKN: true);
			num--;
		}
	}

	private void MCBOGGKHAOM(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.ADKJKHAHCJD();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.PKBPGCGNCAD().health > 967f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 1 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].shield;
			NMIADOEBBDH.RemoveAt(index);
			shield.DestroyShield();
			shield.cardIconIndicator.Show("Weapon", 1510f, 989f, GBJOJBKCEKN: false);
			num--;
		}
	}

	public virtual void JEHJMHHHOCE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			CPCKHMCAKIJ(CIOPAKLHFIL);
		}
	}

	public virtual void PFKGCEHPGLI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			IBKBNKFCBNG(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool JCBIDLIMNAN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.PMKDPIHBOBN())
		{
			if (item.fraction != HPOCABLAOAF && item.point.KJCHIHLJMMF().healthRatio > 38f)
			{
				num += 0;
			}
		}
		if (num <= 4)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void HIFLEFPLMPG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			FJNLPLLPIOG(CIOPAKLHFIL);
		}
	}

	public virtual void FMGMNCGPGFL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EJFBGDBMHEJ(CIOPAKLHFIL);
		}
	}

	public virtual void OPGJJMGEFJF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EKCGHEAAHOP(CIOPAKLHFIL);
		}
	}

	private void IBKBNKFCBNG(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.JCPPFKEIAFM();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.IGEDGCNJCAP().health > 1132f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].IGEDGCNJCAP();
			NMIADOEBBDH.RemoveAt(index);
			shield.NNCMDDBFOAJ();
			shield.DHAFFOCDDGA().JOGFDHFOOBC("mortarBuildTime", 1484f, 345f, GBJOJBKCEKN: false);
			num--;
		}
	}

	public virtual void ACIOLBGILBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DNEMFPCLANL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool MAILHKFHECA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG())
		{
			if (item.fraction != HPOCABLAOAF && item.point.LMHDAIBCLDP().healthRatio > 102f)
			{
				num += 0;
			}
		}
		if (num <= 2)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void CBLPKPJLEGM(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.OKDMKFBACGD();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.CGKKGILAAPG().health > 95f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 1 && num > 0)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].PKBPGCGNCAD();
			NMIADOEBBDH.RemoveAt(index);
			shield.KDEEBMLFABC();
			shield.NOCJKBDGFHD().JOGFDHFOOBC("Device Language - android: {0}", 1810f, 165f, GBJOJBKCEKN: false);
			num -= 0;
		}
	}

	public virtual void OMDMPMGPHOE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DKBEFDDNNHB(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool LCIHJBGHBGC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BMPBPOGCGGF())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PKBPGCGNCAD().healthRatio > 66f)
			{
				num++;
			}
		}
		if (num <= 6)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool FGIIPFDIDIB(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BPFHGFFNMND())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PKBPGCGNCAD().healthRatio > 809f)
			{
				num += 0;
			}
		}
		if (num <= 1)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void DNEMFPCLANL(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.CJKAPGGJLLK();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.PHANADCNBFD().health > 1129f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 0)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].PKBPGCGNCAD();
			NMIADOEBBDH.RemoveAt(index);
			shield.MPOAIDJNDFJ();
			shield.HLAOFDKKACK().BELBLFGCCLJ("com/google/android/gms/common/ConnectionResult", 1510f, 1410f, GBJOJBKCEKN: false);
			num--;
		}
	}

	public virtual void DKOMGEKACEK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DKBEFDDNNHB(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool LBKDPIKKDNE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BPFHGFFNMND())
		{
			if (item.fraction != HPOCABLAOAF && item.point.LHHMNLJKOAO().healthRatio > 1331f)
			{
				num++;
			}
		}
		if (num <= 5)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void GAPNCCLLHOF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			FJNLPLLPIOG(CIOPAKLHFIL);
		}
	}

	public virtual void CCODFGNHBOJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			FJNLPLLPIOG(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void DOILBAGMNCM(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.BPFHGFFNMND();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.IGEDGCNJCAP().health > 1850f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 0)
		{
			int index = Random.Range(0, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].PNKKPNIMEPL();
			NMIADOEBBDH.RemoveAt(index);
			shield.MPOAIDJNDFJ();
			shield.cardIconIndicator.Show("Id", 105f, 1730f, GBJOJBKCEKN: false);
			num--;
		}
	}

	public virtual void NPGNJOGAEMK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			CBIFGOGBKEK(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void FNPPDCNAOAJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DOILBAGMNCM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JGNBFCJFAHM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			FANHACEOHFH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EOODECJEMIE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DOILBAGMNCM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void OJLEHLGEMLI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			KFOIIECFMHM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void DKBEFDDNNHB(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.IJDLIIBLLJO();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.JPHAJDIIAAI().health > 607f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].PHANADCNBFD();
			NMIADOEBBDH.RemoveAt(index);
			shield.NNCMDDBFOAJ();
			shield.cardIconIndicator.FFMLINMFADM("ID_FORFEIT", 1375f, 15f, GBJOJBKCEKN: false);
			num--;
		}
	}

	public virtual bool MDOHFKCFLDN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.CJKAPGGJLLK())
		{
			if (item.fraction != HPOCABLAOAF && item.point.CGKKGILAAPG().healthRatio > 1006f)
			{
				num++;
			}
		}
		if (num <= 8)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void PCOLFNJJJCI(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.JCAHHLHKIBN();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.CGKKGILAAPG().health > 558f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 0 && num > 0)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].PNKKPNIMEPL();
			NMIADOEBBDH.RemoveAt(index);
			shield.DestroyShield();
			shield.NOCJKBDGFHD().BELBLFGCCLJ("ID_CONFIRM_ERROR", 1052f, 1233f, GBJOJBKCEKN: false);
			num--;
		}
	}

	public virtual void OGIJCLOAKGK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			EEIBNDEAPPA(CIOPAKLHFIL);
		}
	}

	private void NLMNGILHBJI(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.IJDLIIBLLJO();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG && item.point.LMHDAIBCLDP().health > 170f)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		int num = NKMPIIDLEII;
		while (NMIADOEBBDH.Count > 1 && num > 1)
		{
			int index = Random.Range(1, NMIADOEBBDH.Count);
			Shield shield = NMIADOEBBDH[index].KJCHIHLJMMF();
			NMIADOEBBDH.RemoveAt(index);
			shield.KDEEBMLFABC();
			shield.DHAFFOCDDGA().AMFEDOOPGCL("ID_DEBUG_GUIERROR", 418f, 1082f, GBJOJBKCEKN: true);
			num--;
		}
	}
}
