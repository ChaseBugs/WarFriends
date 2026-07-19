using System.Collections.Generic;
using UnityEngine;

public class CardSabotage : Card
{
	private PlayerController MBIAKMPDOPG;

	private const string EJLCMBEKFFN = "game-card-ico-backstab";

	public virtual void DPNCDIAEMMA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			PPNAPIKGNCD(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void BPDAJHJNCLG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			NCNMCJCGLOG(CIOPAKLHFIL);
		}
	}

	public virtual bool BMJOBHDGMHP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void HFGMKMIAAGB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			BKBMHIBHLHJ(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void BGKICDIFJNP(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.GetRandomOpponent(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.ICHKCAGOFCM(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 1; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.KHAGKKNPFMP() as AIObject;
			if (aIObject != null && gameShootableEntity2.LIJFONOMLCL())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1796f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.NHOFLPJMKBA().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.mTransform.forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.HIICFFBMLNO() != null)
		{
			gameShootableEntity.KHAGKKNPFMP().cardIconIndicator.GCLFBCIKNAH("opponent defense stop shooting", false, true);
		}
		gameShootableEntity.GILBHOPNBPH().DoDamage(kMJKKNFDFMM);
	}

	public virtual void PCLKGDCKEKO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			PPNAPIKGNCD(CIOPAKLHFIL);
		}
	}

	public virtual void DPCBCEAMGNK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			IHPPNEKIGEN(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool IGFBLLJAIMN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool CHMCOFJGNHA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void NLGPBNBAPIN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			DGJNFJGDMCP(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void GIHMPEHBEDP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			PPNAPIKGNCD(CIOPAKLHFIL);
		}
	}

	private void DGJNFJGDMCP(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.BLMPLLOPLMD(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 1; i < opponents.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = opponents[i];
			AIObject aIObject = gameShootableEntity2.HIICFFBMLNO() as AIObject;
			if (aIObject != null && gameShootableEntity2.GFGLFPEFBBO())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1317f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.GILBHOPNBPH().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.CLKCECPBFIJ().forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.KHAGKKNPFMP() != null)
		{
			gameShootableEntity.KHAGKKNPFMP().cardIconIndicator.DLNGGGOEDLL("{0} {1}", true);
		}
		gameShootableEntity.destroyableObject.DoDamage(kMJKKNFDFMM);
	}

	private void EFILJJGPOJM(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.ICHKCAGOFCM(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 0; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.KPLADAFODKB() as AIObject;
			if (aIObject != null && gameShootableEntity2.LIJFONOMLCL())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 962f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.GILBHOPNBPH().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.MEGABPHJFLL().forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.mainGameEntity != null)
		{
			gameShootableEntity.NOGODFOGKCK().cardIconIndicator.EOEDEJKJKMN("Loaded values during loading data from PlayerAnalytics : lastSeenSquadChatTimeStampDB = {0}, squadCreationsCount = {1}, matchesToNextLootboxes = {2}", true, true);
		}
		gameShootableEntity.destroyableObject.DoDamage(kMJKKNFDFMM);
	}

	public virtual void PAEPGMHDMNM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			BGNANEOOKJO(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void JBLFEMNFJNP(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 1; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.KPLADAFODKB() as AIObject;
			if (aIObject != null && gameShootableEntity2.GFGLFPEFBBO())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1424f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.destroyableObject.maxHealth,
			LPGMLOCLBGP = gameShootableEntity.mTransform.forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.KHAGKKNPFMP() != null)
		{
			gameShootableEntity.KHAGKKNPFMP().cardIconIndicator.OFPAGLLFPPK("GameLoginManager: Login successful, getting player data", true, true);
		}
		gameShootableEntity.GILBHOPNBPH().DoDamage(kMJKKNFDFMM);
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			ICLJEOIMHHG(CIOPAKLHFIL);
		}
	}

	public virtual bool CAMHHFDPLOF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void ILNLEEBPHIH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			JBLFEMNFJNP(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void NLNJAKHLOFO(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.GetRandomOpponent(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.ICHKCAGOFCM(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 0; i < list2.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.KHAGKKNPFMP() as AIObject;
			if (aIObject != null && gameShootableEntity2.LIJFONOMLCL())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 483f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.NHOFLPJMKBA().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.AFKOGLEHKIE().forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.KPLADAFODKB() != null)
		{
			gameShootableEntity.mainGameEntity.cardIconIndicator.EOEDEJKJKMN("Client_", false);
		}
		gameShootableEntity.NHOFLPJMKBA().DoDamage(kMJKKNFDFMM);
	}

	public virtual void BPFGINOCHLH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			MLEFGBFHHOI(CIOPAKLHFIL);
		}
	}

	public virtual void LLMMIFJBLBD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			IBHGBKKILME(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void KAMNHAJGEDH(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 0; i < opponents.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = opponents[i];
			AIObject aIObject = gameShootableEntity2.NOGODFOGKCK() as AIObject;
			if (aIObject != null && gameShootableEntity2.isMain)
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1968f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.EIMJEBNPHAM().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.NOEFNPDCDFJ().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.HIICFFBMLNO() != null)
		{
			gameShootableEntity.KPLADAFODKB().cardIconIndicator.PEBHGOMEKME("TotalBattles", false);
		}
		gameShootableEntity.EIMJEBNPHAM().DoDamage(kMJKKNFDFMM);
	}

	public virtual bool GFBADADCLOF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void GHAOLPJPNLD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			HLHCEEJHDGK(CIOPAKLHFIL);
		}
	}

	private void PJHDAIKJPOB(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 0; i < opponents.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = opponents[i];
			AIObject aIObject = gameShootableEntity2.KPLADAFODKB() as AIObject;
			if (aIObject != null && gameShootableEntity2.GFGLFPEFBBO())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1213f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.destroyableObject.maxHealth,
			LPGMLOCLBGP = gameShootableEntity.EGEONNAALPH().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.mainGameEntity != null)
		{
			gameShootableEntity.NOGODFOGKCK().cardIconIndicator.DLNGGGOEDLL("registerCustomEventString", true, true);
		}
		gameShootableEntity.EIMJEBNPHAM().DoDamage(kMJKKNFDFMM);
	}

	public virtual void KGNCNMLPEPH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			PPNAPIKGNCD(CIOPAKLHFIL);
		}
	}

	public virtual void NPNDHFIMPHE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			GMIHEFMIAIB(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool MBILPOJAHDK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void PFOLMAKLAFO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			MLEFGBFHHOI(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void HNFCOJAIMDI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			NCNMCJCGLOG(CIOPAKLHFIL);
		}
	}

	public virtual bool KGBCKNGHEGN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void EPOEMPCNOPB(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 1; i < opponents.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = opponents[i];
			AIObject aIObject = gameShootableEntity2.mainGameEntity as AIObject;
			if (aIObject != null && gameShootableEntity2.isMain)
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 462f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.destroyableObject.maxHealth,
			LPGMLOCLBGP = gameShootableEntity.CLKCECPBFIJ().forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.HIICFFBMLNO() != null)
		{
			gameShootableEntity.NOGODFOGKCK().cardIconIndicator.PEBHGOMEKME("fire", true, true);
		}
		gameShootableEntity.AFEPMIFFLFH().DoDamage(kMJKKNFDFMM);
	}

	private void GMIHEFMIAIB(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 0; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.mainGameEntity as AIObject;
			if (aIObject != null && gameShootableEntity2.GFGLFPEFBBO())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1576f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.GILBHOPNBPH().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.AFKOGLEHKIE().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.HIICFFBMLNO() != null)
		{
			gameShootableEntity.KHAGKKNPFMP().cardIconIndicator.FJILILFMPIF("Card_1_Played", false);
		}
		gameShootableEntity.AFEPMIFFLFH().DoDamage(kMJKKNFDFMM);
	}

	public virtual void EBCLHPLHBHB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			ICLJEOIMHHG(CIOPAKLHFIL);
		}
	}

	public virtual void LGCPPPIGHDE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			BJKLOIJJIEF(CIOPAKLHFIL);
		}
	}

	public virtual void IHPNEPEBKCP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			DGJNFJGDMCP(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void BKBMHIBHLHJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 0; i < opponents.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = opponents[i];
			AIObject aIObject = gameShootableEntity2.mainGameEntity as AIObject;
			if (aIObject != null && gameShootableEntity2.LIJFONOMLCL())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 18f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.destroyableObject.maxHealth,
			LPGMLOCLBGP = gameShootableEntity.mTransform.forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.KHAGKKNPFMP() != null)
		{
			gameShootableEntity.HIICFFBMLNO().cardIconIndicator.OFPAGLLFPPK("SquadRank", true);
		}
		gameShootableEntity.GILBHOPNBPH().DoDamage(kMJKKNFDFMM);
	}

	public virtual void HGINJJNEEDB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			LCMKKIEOJBM(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EDKOODPOJHE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			BGKICDIFJNP(CIOPAKLHFIL);
		}
	}

	public virtual bool HDGAAOAGNFC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void ICLJEOIMHHG(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.GetRandomOpponent(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 0; i < opponents.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = opponents[i];
			AIObject aIObject = gameShootableEntity2.mainGameEntity as AIObject;
			if (aIObject != null && gameShootableEntity2.isMain)
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 5f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.destroyableObject.maxHealth,
			LPGMLOCLBGP = gameShootableEntity.mTransform.forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.mainGameEntity != null)
		{
			gameShootableEntity.mainGameEntity.cardIconIndicator.Show("game-card-ico-backstab", true);
		}
		gameShootableEntity.destroyableObject.DoDamage(kMJKKNFDFMM);
	}

	public virtual void IIGHAAABACM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			BJKLOIJJIEF(CIOPAKLHFIL);
		}
	}

	public virtual void NIODJFGIJNN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			IHPPNEKIGEN(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void AAJMPBPHENK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			KAMNHAJGEDH(CIOPAKLHFIL);
		}
	}

	public virtual void MBMLMJPHOKP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			EEJMEKFNHAA(CIOPAKLHFIL);
		}
	}

	public virtual bool FGIIPFDIDIB(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void BGNANEOOKJO(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.GetRandomOpponent(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 0; i < list2.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.KHAGKKNPFMP() as AIObject;
			if (aIObject != null && gameShootableEntity2.GFGLFPEFBBO())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 347f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.destroyableObject.maxHealth,
			LPGMLOCLBGP = gameShootableEntity.NOEFNPDCDFJ().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.HIICFFBMLNO() != null)
		{
			gameShootableEntity.KPLADAFODKB().cardIconIndicator.DLNGGGOEDLL("run", false, true);
		}
		gameShootableEntity.GILBHOPNBPH().DoDamage(kMJKKNFDFMM);
	}

	public virtual void HIAKKAEOJGO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			MLEFGBFHHOI(CIOPAKLHFIL);
		}
	}

	public virtual void LAOLPNLFPJM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			JBLFEMNFJNP(CIOPAKLHFIL);
		}
	}

	private void BJKLOIJJIEF(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.BLMPLLOPLMD(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 1; i < opponents.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = opponents[i];
			AIObject aIObject = gameShootableEntity2.KPLADAFODKB() as AIObject;
			if (aIObject != null && gameShootableEntity2.isMain)
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 344f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.NHOFLPJMKBA().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.EGEONNAALPH().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.mainGameEntity != null)
		{
			gameShootableEntity.mainGameEntity.cardIconIndicator.LDGKPCDJPLA("Chat: Disconected: ", false);
		}
		gameShootableEntity.EIMJEBNPHAM().DoDamage(kMJKKNFDFMM);
	}

	public virtual bool GEAPEEMABAL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool AIIAHOIFIDB(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool OGOBFGAABIK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool JCBIDLIMNAN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void LMPJIPAFBDE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			PPNAPIKGNCD(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void IALDONBKFNI(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.BLMPLLOPLMD(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.ICHKCAGOFCM(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 1; i < list2.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.HIICFFBMLNO() as AIObject;
			if (aIObject != null && gameShootableEntity2.GFGLFPEFBBO())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1716f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.NHOFLPJMKBA().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.MEGABPHJFLL().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.mainGameEntity != null)
		{
			gameShootableEntity.HIICFFBMLNO().cardIconIndicator.GKAOMCGCDGE("offers", false, true);
		}
		gameShootableEntity.NHOFLPJMKBA().DoDamage(kMJKKNFDFMM);
	}

	public virtual void IGJJHCKMDBK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			JBLFEMNFJNP(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool APFPKGCEPKL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void IEONLEGFKKK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			PPOFKEMMNOC(CIOPAKLHFIL);
		}
	}

	public virtual void GDEHLDBGNHB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			PJHDAIKJPOB(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void KKEPLAFJKOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			BKBMHIBHLHJ(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JPCPJELCHDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			EFILJJGPOJM(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void IHPPNEKIGEN(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.BLMPLLOPLMD(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 1; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.mainGameEntity as AIObject;
			if (aIObject != null && gameShootableEntity2.LIJFONOMLCL())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 175f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.EIMJEBNPHAM().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.MEGABPHJFLL().forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.NOGODFOGKCK() != null)
		{
			gameShootableEntity.KPLADAFODKB().cardIconIndicator.BBJADAJPJHH("ID_WARSHOP_PACKS", false);
		}
		gameShootableEntity.EIMJEBNPHAM().DoDamage(kMJKKNFDFMM);
	}

	public virtual void JCHONMMNBAE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			HLHCEEJHDGK(CIOPAKLHFIL);
		}
	}

	private void IJOPPFEHJFE(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.BLMPLLOPLMD(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.ICHKCAGOFCM(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 1; i < list2.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.KHAGKKNPFMP() as AIObject;
			if (aIObject != null && gameShootableEntity2.GFGLFPEFBBO())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 184f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.GILBHOPNBPH().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.CLCHGECECJC().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.KPLADAFODKB() != null)
		{
			gameShootableEntity.KHAGKKNPFMP().cardIconIndicator.FJILILFMPIF("ID_ARENALOSSREWARD", false, true);
		}
		gameShootableEntity.destroyableObject.DoDamage(kMJKKNFDFMM);
	}

	public virtual bool OPKJFNONDPG(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void PKBCHKOFPMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			EEJMEKFNHAA(CIOPAKLHFIL);
		}
	}

	public virtual bool GAPAJHFLCCN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void HGCCDEBNHED(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			NLNJAKHLOFO(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void GAGEHEGFGOA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			EFILJJGPOJM(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool BIBKGNABACA(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void LCMKKIEOJBM(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.GetRandomOpponent(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.ICHKCAGOFCM(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 1; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.NOGODFOGKCK() as AIObject;
			if (aIObject != null && gameShootableEntity2.LIJFONOMLCL())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 157f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.NHOFLPJMKBA().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.NOEFNPDCDFJ().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.NOGODFOGKCK() != null)
		{
			gameShootableEntity.KPLADAFODKB().cardIconIndicator.EOEDEJKJKMN("Yes_Clicked", false);
		}
		gameShootableEntity.destroyableObject.DoDamage(kMJKKNFDFMM);
	}

	public virtual void DPELJDNCGHG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			BGKICDIFJNP(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void NKCOEPEOFLP(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.BLMPLLOPLMD(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.ICHKCAGOFCM(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 1; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.HIICFFBMLNO() as AIObject;
			if (aIObject != null && gameShootableEntity2.GFGLFPEFBBO())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1035f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.AFEPMIFFLFH().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.CLKCECPBFIJ().forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.HIICFFBMLNO() != null)
		{
			gameShootableEntity.mainGameEntity.cardIconIndicator.LJLDJOHAAMC("grenade_reload", true);
		}
		gameShootableEntity.EIMJEBNPHAM().DoDamage(kMJKKNFDFMM);
	}

	public virtual void ELDBCIALHLG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			PPOFKEMMNOC(CIOPAKLHFIL);
		}
	}

	public virtual void FHJDANNKODE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			LLCHNMNLCFN(CIOPAKLHFIL);
		}
	}

	private void LLCHNMNLCFN(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 1; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.KPLADAFODKB() as AIObject;
			if (aIObject != null && gameShootableEntity2.GFGLFPEFBBO())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 530f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.destroyableObject.maxHealth,
			LPGMLOCLBGP = gameShootableEntity.MEGABPHJFLL().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.KPLADAFODKB() != null)
		{
			gameShootableEntity.KPLADAFODKB().cardIconIndicator.JCJFMHGNIOF("Awaiting players - Player id:\"{0}\" already added to message center", true, true);
		}
		gameShootableEntity.NHOFLPJMKBA().DoDamage(kMJKKNFDFMM);
	}

	public virtual void LOLJCEGGPMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
			IBHGBKKILME(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void HLCFNFCMGFD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			BGKICDIFJNP(CIOPAKLHFIL);
		}
	}

	public virtual bool PJCPMOHFALI(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void NEPIKOKDBHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			LLCHNMNLCFN(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool CGFFJEHJHHL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool MOEJABKCDGK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void MLEFGBFHHOI(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.BLMPLLOPLMD(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 1; i < opponents.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = opponents[i];
			AIObject aIObject = gameShootableEntity2.HIICFFBMLNO() as AIObject;
			if (aIObject != null && gameShootableEntity2.isMain)
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1723f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.EIMJEBNPHAM().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.JCAKAHGKBIJ().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.mainGameEntity != null)
		{
			gameShootableEntity.KPLADAFODKB().cardIconIndicator.GGHDIAFACAH("ID_CONFIRM_STARTUPERROR", true);
		}
		gameShootableEntity.destroyableObject.DoDamage(kMJKKNFDFMM);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			ICLJEOIMHHG(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool MMMBAOKNCDK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void PIPOLNODBOC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
			EEJMEKFNHAA(CIOPAKLHFIL);
		}
	}

	public virtual bool FFFBNLPHOAM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void BHNOANFEFJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			MLEFGBFHHOI(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private void EEJMEKFNHAA(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 1; i < list2.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.HIICFFBMLNO() as AIObject;
			if (aIObject != null && gameShootableEntity2.isMain)
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1972f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.GILBHOPNBPH().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.MEGABPHJFLL().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.HIICFFBMLNO() != null)
		{
			gameShootableEntity.KHAGKKNPFMP().cardIconIndicator.GGHDIAFACAH("\"{0}\"", false);
		}
		gameShootableEntity.AFEPMIFFLFH().DoDamage(kMJKKNFDFMM);
	}

	public virtual void ABMOHFELOFN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (PhotonNetwork.isMasterClient)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			LCMKKIEOJBM(MBIAKMPDOPG.fraction);
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool CINDAOPACGM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool BJODPJNOMLK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void PPNAPIKGNCD(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.BLMPLLOPLMD(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 0; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.mainGameEntity as AIObject;
			if (aIObject != null && gameShootableEntity2.isMain)
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1938f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.AFEPMIFFLFH().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.CLKCECPBFIJ().forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.HIICFFBMLNO() != null)
		{
			gameShootableEntity.NOGODFOGKCK().cardIconIndicator.FJILILFMPIF("game-card-ico-triggerhappy", false, true);
		}
		gameShootableEntity.EIMJEBNPHAM().DoDamage(kMJKKNFDFMM);
	}

	public virtual void EFMMICONABJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.GetPlayerOld(CIOPAKLHFIL);
			EPOEMPCNOPB(CIOPAKLHFIL);
		}
	}

	public virtual bool OFBIPJIEDPP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void HLHCEEJHDGK(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.BLMPLLOPLMD(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 1; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.KHAGKKNPFMP() as AIObject;
			if (aIObject != null && gameShootableEntity2.GFGLFPEFBBO())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 629f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.NHOFLPJMKBA().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.CLKCECPBFIJ().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = true,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.KPLADAFODKB() != null)
		{
			gameShootableEntity.KPLADAFODKB().cardIconIndicator.GKAOMCGCDGE("312 MENU CONNECT FB", false, true);
		}
		gameShootableEntity.destroyableObject.DoDamage(kMJKKNFDFMM);
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private void KPNAKLGKFFL(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.BLMPLLOPLMD(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		for (int i = 1; i < list2.Count; i++)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.mainGameEntity as AIObject;
			if (aIObject != null && gameShootableEntity2.isMain)
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 412f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.AFEPMIFFLFH().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.CLKCECPBFIJ().forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Shot;
		if (gameShootableEntity.KHAGKKNPFMP() != null)
		{
			gameShootableEntity.mainGameEntity.cardIconIndicator.JCJFMHGNIOF("IsMatchMaking", true);
		}
		gameShootableEntity.destroyableObject.DoDamage(kMJKKNFDFMM);
	}

	public virtual void JNMGIFGMBPF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (base.isOnlineMaster)
		{
			MBIAKMPDOPG = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
			LCMKKIEOJBM(CIOPAKLHFIL);
		}
	}

	private void IBHGBKKILME(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 0; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.HIICFFBMLNO() as AIObject;
			if (aIObject != null && gameShootableEntity2.LIJFONOMLCL())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1392f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.destroyableObject.maxHealth,
			LPGMLOCLBGP = gameShootableEntity.JCAKAHGKBIJ().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = true
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 0;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.HIICFFBMLNO() != null)
		{
			gameShootableEntity.KHAGKKNPFMP().cardIconIndicator.DLNGGGOEDLL("FuseRewardedOptionKey_PostRollContinueButtonText", false, true);
		}
		gameShootableEntity.AFEPMIFFLFH().DoDamage(kMJKKNFDFMM);
	}

	private void NCNMCJCGLOG(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.OIFCFJGKNMJ(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 0; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.KHAGKKNPFMP() as AIObject;
			if (aIObject != null && gameShootableEntity2.LIJFONOMLCL())
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 360f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 1)
		{
			gameShootableEntity = list[Random.Range(1, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.destroyableObject.maxHealth,
			LPGMLOCLBGP = gameShootableEntity.JCAKAHGKBIJ().forward,
			KLOJNPBGFIG = true,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.KPLADAFODKB() != null)
		{
			gameShootableEntity.mainGameEntity.cardIconIndicator.NNPILDOKNJO("Sniper_Tutorial_Duration", false);
		}
		gameShootableEntity.AFEPMIFFLFH().DoDamage(kMJKKNFDFMM);
	}

	private void PPOFKEMMNOC(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity gameShootableEntity = GameShootableEntity.NFBPLNIJIIL(CIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		List<GameShootableEntity> list2 = GameShootableEntity.ICHKCAGOFCM(CIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		for (int i = 1; i < list2.Count; i += 0)
		{
			GameShootableEntity gameShootableEntity2 = list2[i];
			AIObject aIObject = gameShootableEntity2.KPLADAFODKB() as AIObject;
			if (aIObject != null && gameShootableEntity2.isMain)
			{
				float num = Time.realtimeSinceStartup - aIObject.spawnTime;
				if (num > 1969f)
				{
					list.Add(gameShootableEntity2);
				}
			}
		}
		if (list.Count > 0)
		{
			gameShootableEntity = list[Random.Range(0, list.Count)];
		}
		if (gameShootableEntity == null)
		{
			return;
		}
		DestroyableObject.CJLNCMMNPBM kMJKKNFDFMM = new DestroyableObject.CJLNCMMNPBM
		{
			EPDELOGPNAC = gameShootableEntity.EIMJEBNPHAM().maxHealth,
			LPGMLOCLBGP = gameShootableEntity.CLKCECPBFIJ().forward,
			KLOJNPBGFIG = false,
			CCFJFAMEODO = false,
			HNFNINFCBEJ = MBIAKMPDOPG,
			DBFIOEAHJFD = false
		};
		if (MBIAKMPDOPG.fraction != CIOPAKLHFIL)
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				PlayerController value = item.Value;
				if (value.fraction == CIOPAKLHFIL)
				{
					kMJKKNFDFMM.HNFNINFCBEJ = value;
				}
			}
		}
		kMJKKNFDFMM.MEFOHLAIBFA = 1;
		kMJKKNFDFMM.JMMJHCOKCGG = null;
		kMJKKNFDFMM.FJLBLLLEELD = DestroyableObject.MANAGOLPMLH.Explosion;
		if (gameShootableEntity.KHAGKKNPFMP() != null)
		{
			gameShootableEntity.KPLADAFODKB().cardIconIndicator.BBJADAJPJHH("ID_ARENAREWARD_WARBUCKS", true, true);
		}
		gameShootableEntity.AFEPMIFFLFH().DoDamage(kMJKKNFDFMM);
	}

	public virtual bool GIDHJJJIFGC(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (PLLLHNDJFLH.Count == 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}
}
