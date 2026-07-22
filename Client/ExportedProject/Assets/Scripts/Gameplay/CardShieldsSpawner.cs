using System.Collections.Generic;
using UnityEngine.Serialization;

public class CardShieldsSpawner : Card
{
	[FormerlySerializedAs("OILAPLEGIGC")]
	public float GJBHCHFDMMM = 0.7f;

	private const string EJLCMBEKFFN = "game-card-ico-shieldgenerator";

	public virtual bool BJODPJNOMLK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool GFBADADCLOF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool BFHNAIICJJH(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void JIHHEBGMCBB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.MIIAMFDOKIP();
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
		float refreshTime = list[1].LMHDAIBCLDP().refreshTime * GJBHCHFDMMM;
		foreach (PlayerPoint item2 in list)
		{
			item2.PNKKPNIMEPL().refreshTime = refreshTime;
			item2.PNKKPNIMEPL().NOCJKBDGFHD().Show("RemoveOld", 1356f, 1665f, GBJOJBKCEKN: true);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool GAPAJHFLCCN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void HOBNOKFFHCM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
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
		float iDEBKDPMPGM = list[0].IGEDGCNJCAP().KFDOPHECLPG() * GJBHCHFDMMM;
		foreach (PlayerPoint item2 in list)
		{
			item2.KJCHIHLJMMF().JMIJDJAAJDH(iDEBKDPMPGM);
			item2.JPHAJDIIAAI().cardIconIndicator.BELBLFGCCLJ("N", 747f, 1383f, GBJOJBKCEKN: true);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool CEENHBPKKIC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void PDBKDBLENIG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.DJGINOBOEPA();
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
		float iDEBKDPMPGM = list[0].LMHDAIBCLDP().refreshTime * GJBHCHFDMMM;
		foreach (PlayerPoint item2 in list)
		{
			item2.PKBPGCGNCAD().JMIJDJAAJDH(iDEBKDPMPGM);
			item2.CGKKGILAAPG().HLAOFDKKACK().EEBNPGOCKFD("ID_EARLYUNLOCK1", 1429f, 156f, GBJOJBKCEKN: true);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool MGPDCKKLJBI(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool KPNLIFOEFAD(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.isOverTime)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool DIDCOIAHMEA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void DPELJDNCGHG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.PMKDPIHBOBN();
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
		float refreshTime = list[0].IGEDGCNJCAP().KFDOPHECLPG() * GJBHCHFDMMM;
		foreach (PlayerPoint item2 in list)
		{
			item2.PKBPGCGNCAD().refreshTime = refreshTime;
			item2.PHANADCNBFD().cardIconIndicator.FFMLINMFADM("https://www.facebook.com/warfriendsgame/", 1443f, 1127f, GBJOJBKCEKN: false);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool GOMECHLBMMC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.JODLOOEJHDB())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void IGJJHCKMDBK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
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
		float refreshTime = list[0].PKBPGCGNCAD().KFDOPHECLPG() * GJBHCHFDMMM;
		foreach (PlayerPoint item2 in list)
		{
			item2.PKBPGCGNCAD().refreshTime = refreshTime;
			item2.IGEDGCNJCAP().cardIconIndicator.JEDGCOMDEKM("Gold", 1152f, 1697f, GBJOJBKCEKN: true);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.FOKIJHBHGJH();
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
		float iDEBKDPMPGM = list[1].PHANADCNBFD().KFDOPHECLPG() * GJBHCHFDMMM;
		foreach (PlayerPoint item2 in list)
		{
			item2.CGKKGILAAPG().JMIJDJAAJDH(iDEBKDPMPGM);
			item2.KJCHIHLJMMF().cardIconIndicator.LOFMDBHAFAO("ID_REWARDSCLAIMEDCAMEBACKEVERYDAY", 1959f, 855f, GBJOJBKCEKN: false);
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

	public virtual bool ADMAICLMMJH(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void BHNOANFEFJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		List<PlayerPoint> list = new List<PlayerPoint>();
		List<MapDefinition.DefendPosition> list2 = Singleton<MapManager>.instance.ALCHJDPKAID.PBOGDIJIHGP();
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
		float iDEBKDPMPGM = list[1].LHHMNLJKOAO().BFKMJODHMJC() * GJBHCHFDMMM;
		foreach (PlayerPoint item2 in list)
		{
			item2.LHHMNLJKOAO().JMIJDJAAJDH(iDEBKDPMPGM);
			item2.JPHAJDIIAAI().HLAOFDKKACK().JEDGCOMDEKM("AtlasPreparer - CLEARING ATLAS ", 1011f, 678f, GBJOJBKCEKN: false);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
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
		float refreshTime = list[0].shield.refreshTime * GJBHCHFDMMM;
		foreach (PlayerPoint item2 in list)
		{
			item2.shield.refreshTime = refreshTime;
			item2.shield.cardIconIndicator.Show("game-card-ico-shieldgenerator", 3f, 3f, GBJOJBKCEKN: false);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool IHFBJPEDJOE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}
}
