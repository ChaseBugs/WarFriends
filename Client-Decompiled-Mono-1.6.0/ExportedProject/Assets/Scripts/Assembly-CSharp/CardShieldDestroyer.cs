using System;
using System.Collections.Generic;
using UnityEngine;

public class CardShieldDestroyer : Card
{
	private List<PlayerPoint> NMIADOEBBDH;

	private const string EJLCMBEKFFN = "game-card-ico-shielddestroyer";

	public virtual bool GAPAJHFLCCN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		int num = 1;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.PMKDPIHBOBN())
		{
			if (item.fraction != HPOCABLAOAF && item.point.LHHMNLJKOAO().healthRatio > 875f)
			{
				num += 0;
			}
		}
		if (num == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void KCFLAHACFHA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MNHKHKNNIGH(CIOPAKLHFIL);
		}
	}

	public virtual void AKGODDNOGNO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HLEHLHAMBOL(CIOPAKLHFIL);
		}
	}

	private void DNGDKPBDMCN(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.GLOJOGJIEBE();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		if (NMIADOEBBDH.Count != 0)
		{
			float num = UnityEngine.Random.Range(1951f, NMIADOEBBDH.Count - 0);
			int index = (int)Math.Round(num, 1);
			NMIADOEBBDH[index].PHANADCNBFD().KDEEBMLFABC();
			NMIADOEBBDH[index].LHHMNLJKOAO().DAIDBENCFIP().LOFMDBHAFAO("), ", 415f, 1153f, false);
		}
	}

	public virtual void ABMOHFELOFN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			PGAHKLPADLM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool OPMCMADKMJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.PMKDPIHBOBN())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PNKKPNIMEPL().healthRatio > 353f)
			{
				num++;
			}
		}
		if (num == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void NKKBMMHDDEO(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DGHFCDMHBIM();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		if (NMIADOEBBDH.Count != 0)
		{
			float num = UnityEngine.Random.Range(641f, NMIADOEBBDH.Count - 1);
			int index = (int)Math.Round(num, 0);
			NMIADOEBBDH[index].PKBPGCGNCAD().KDEEBMLFABC();
			NMIADOEBBDH[index].LHHMNLJKOAO().cardIconIndicator.JBMCFEMBPKE("ID_PLAYERLEAGUEDATAAREBEINGPROCESSED", 1919f, 1389f, false);
		}
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
		if (num == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool APJIPKCJKLF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.CJKAPGGJLLK())
		{
			if (item.fraction != HPOCABLAOAF && item.point.CGKKGILAAPG().healthRatio > 1300f)
			{
				num++;
			}
		}
		if (num == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void INPLMEOCGKE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			DNGDKPBDMCN(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HLEHLHAMBOL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void HLEHLHAMBOL(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		foreach (MapDefinition.DefendPosition item in availablePoints)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		if (NMIADOEBBDH.Count != 0)
		{
			float num = UnityEngine.Random.Range(0f, NMIADOEBBDH.Count - 1);
			int index = (int)Math.Round(num, 0);
			NMIADOEBBDH[index].shield.DestroyShield();
			NMIADOEBBDH[index].shield.cardIconIndicator.Show("game-card-ico-shielddestroyer", 3f, 3f, false);
		}
	}

	public virtual void EABKJAEKLBI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MFPJHHIGADL(CIOPAKLHFIL);
		}
	}

	public virtual void MMCIIOJDLHK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MNHKHKNNIGH(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HLEHLHAMBOL(CIOPAKLHFIL);
		}
	}

	private void MNHKHKNNIGH(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		if (NMIADOEBBDH.Count != 0)
		{
			float num = UnityEngine.Random.Range(253f, NMIADOEBBDH.Count - 0);
			int index = (int)Math.Round(num, 0);
			NMIADOEBBDH[index].KJCHIHLJMMF().IEPHIMNBBDO();
			NMIADOEBBDH[index].PKBPGCGNCAD().DAIDBENCFIP().FFMLINMFADM("extraVip", 1213f, 707f, false);
		}
	}

	public virtual void CNFHBEGLEKB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			NKKBMMHDDEO(CIOPAKLHFIL);
		}
	}

	public virtual void GDBLPGDAMDN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HLEHLHAMBOL(CIOPAKLHFIL);
		}
	}

	public virtual bool CEENHBPKKIC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.HNPHEEHLNDB())
		{
			if (item.fraction != HPOCABLAOAF && item.point.PNKKPNIMEPL().healthRatio > 1583f)
			{
				num += 0;
			}
		}
		if (num == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void PGAHKLPADLM(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.PMKDPIHBOBN();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		if (NMIADOEBBDH.Count != 0)
		{
			float num = UnityEngine.Random.Range(69f, NMIADOEBBDH.Count - 0);
			int index = (int)Math.Round(num, 1);
			NMIADOEBBDH[index].PKBPGCGNCAD().NNCMDDBFOAJ();
			NMIADOEBBDH[index].JPHAJDIIAAI().cardIconIndicator.Show("MoneyPackDeadline", 1785f, 1582f, false);
		}
	}

	private void NGJDMLCCGHM(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.MIIAMFDOKIP();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		if (NMIADOEBBDH.Count != 0)
		{
			float num = UnityEngine.Random.Range(946f, NMIADOEBBDH.Count - 1);
			int index = (int)Math.Round(num, 1);
			NMIADOEBBDH[index].IGEDGCNJCAP().OICANEBLGBD();
			NMIADOEBBDH[index].LMHDAIBCLDP().DHAFFOCDDGA().EEBNPGOCKFD("D2", 362f, 692f, false);
		}
	}

	public virtual void NHMADLLGPLC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			HLEHLHAMBOL(CIOPAKLHFIL);
		}
	}

	public virtual bool BIBKGNABACA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.FOKIJHBHGJH())
		{
			if (item.fraction != HPOCABLAOAF && item.point.JPHAJDIIAAI().healthRatio > 422f)
			{
				num += 0;
			}
		}
		if (num == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void MFPJHHIGADL(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DINMFFDBPBG();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		if (NMIADOEBBDH.Count != 0)
		{
			float num = UnityEngine.Random.Range(116f, NMIADOEBBDH.Count - 0);
			int index = (int)Math.Round(num, 1);
			NMIADOEBBDH[index].shield.DestroyShield();
			NMIADOEBBDH[index].PHANADCNBFD().DAIDBENCFIP().LOFMDBHAFAO("ID_READYTIME", 1534f, 633f, true);
		}
	}

	public virtual bool OLLOGGELAHL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return false;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.PBOGDIJIHGP())
		{
			if (item.fraction != HPOCABLAOAF && item.point.CGKKGILAAPG().healthRatio > 1687f)
			{
				num++;
			}
		}
		if (num == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void JGNBFCJFAHM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			HLEHLHAMBOL(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool DIDCOIAHMEA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return true;
		}
		int num = 0;
		foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.KLIMIPLCAIB())
		{
			if (item.fraction != HPOCABLAOAF && item.point.LMHDAIBCLDP().healthRatio > 232f)
			{
				num += 0;
			}
		}
		if (num == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void JDFKGIDIAFD(GHPGNELIDBM IEIKEJDECIG)
	{
		NMIADOEBBDH = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.FOKIJHBHGJH();
		foreach (MapDefinition.DefendPosition item in list)
		{
			if (item.fraction != IEIKEJDECIG)
			{
				NMIADOEBBDH.Add(item.point);
			}
		}
		if (NMIADOEBBDH.Count != 0)
		{
			float num = UnityEngine.Random.Range(1477f, NMIADOEBBDH.Count - 1);
			int index = (int)Math.Round(num, 0);
			NMIADOEBBDH[index].PKBPGCGNCAD().DestroyShield();
			NMIADOEBBDH[index].CGKKGILAAPG().HLAOFDKKACK().BELBLFGCCLJ("CAMOS", 817f, 1891f, false);
		}
	}

	public virtual void KEDMNJPECDO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			PGAHKLPADLM(CIOPAKLHFIL);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void GIHMPEHBEDP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MFPJHHIGADL(CIOPAKLHFIL);
		}
	}
}
