using System.Collections.Generic;
using Google2u;
using UnityEngine;
using UnityEngine.AI;

public class CardLandmine : Card
{
	private const string EJLCMBEKFFN = "game-card-ico-mineyourstep-full";

	private Vector3 HLFBKIPANFD;

	public virtual void LLFHEHHPMGL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		List<EnemyPoint> list = JOMJFAHJNMP(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1096f, 0);
			Mine cOHKHNALDPH = playerController.BEIIOAIJMFK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1360f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, t)) * 1050f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.IFKEKKPFIEF().GKAOMCGCDGE("ID_MOREINFO", NABOFKMBMKH: true, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("1.0");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> LIBIPKMNIEO(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.BMNEPICFHNO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.NDFKANKCFFO() == EnemyPoint.LJGGJMAFEBN.Corner && item.MMEJGAPHKPJ() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(1, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> LPEKCNPFDML(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.LOIJJLGGNFN() == (EnemyPoint.LJGGJMAFEBN)0 && item.KGMCJIICFKH() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(4, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> HMOKOEJAEBA(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.HECCAFJBKGP() == EnemyPoint.LJGGJMAFEBN.Corner && item.IOPIBCMGGDG() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(5, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> AIAIMABHPMD(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.LDGAKJJINEO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.enemyPointType == EnemyPoint.LJGGJMAFEBN.Hiding && item.HIALJKICLKJ() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(5, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> MHGAKFAFAGH(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.MODBJDDNNFN() == (EnemyPoint.LJGGJMAFEBN)0 && item.MMEJGAPHKPJ() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(2, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void MEMDELDKFJI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		List<EnemyPoint> list = MHGAKFAFAGH(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 145f, 1);
			Mine cOHKHNALDPH = playerController.BEIIOAIJMFK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1558f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, t)) * 1832f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.MMCLHGEGOJO().GKAOMCGCDGE("S", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("ID_LOGOUT");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> FFEMPJOCMHJ(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.LDGAKJJINEO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.GNEHPIPGJCO() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding) && item.MHLKAEOAGAM() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(3, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> EJDHINFCANC(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.BMNEPICFHNO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.NDFKANKCFFO() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner) && item.fraction != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(3, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void HGINJJNEEDB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		List<EnemyPoint> list = CKHMFMBLDIN(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 545f, 0);
			Mine cOHKHNALDPH = playerController.JLMDEMFIHCA().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1210f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, t)) * 1854f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.GDBDMFCEGIB().GCLFBCIKNAH("ID_SALEPERCENTLINE", NABOFKMBMKH: true, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void IDAFLCICMKD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		List<EnemyPoint> list = JOMJFAHJNMP(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1228f, 1);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1952f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, t)) * 178f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.AOANMLBFHJA().BBJADAJPJHH("Player_Avoided_Grenade_On_First_Try", NABOFKMBMKH: false);
			}
			else
			{
				Debug.LogError("isCanceled");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void NIODJFGIJNN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		List<EnemyPoint> list = JIBFPDCEOBM(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1550f, 1);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 105f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, t)) * 55f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.JHEBMKKODAE().JCJFMHGNIOF("#DANIEL# New Assignemnts Claimed Arrived: ", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("Directory \"{0}\" does not exists");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void IDLKDDEEALI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		List<EnemyPoint> list = KNEDPFEJMDK(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 318f, 1);
			Mine cOHKHNALDPH = playerController.BEIIOAIJMFK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1393f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE, t)) * 1651f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.cardIconIndicator.FJILILFMPIF("Assignment: Error, task definition not found for id = ", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("Not connected when rematch");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void FEJKPDNPNOA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<EnemyPoint> list = HJNABCCOBOJ(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1408f, 0);
			Mine cOHKHNALDPH = playerOld.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 334f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerOld.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE, t)) * 195f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.GDBDMFCEGIB().FJILILFMPIF("ID_READYTIME", NABOFKMBMKH: false);
			}
			else
			{
				Debug.LogError("Remove Facebook Data");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
	}

	public virtual void JPCPJELCHDA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = ONMNJCCLOPB(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1126f, 1);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 420f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, t)) * 310f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.AOANMLBFHJA().LJLDJOHAAMC("alwaysShittyPerformance", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("Terms: First init.");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void DCGABENHDBH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		List<EnemyPoint> list = GJOHMMECIGG(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 34f, 0);
			Mine cOHKHNALDPH = playerController.JLMDEMFIHCA().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 763f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE, t)) * 893f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.IFKEKKPFIEF().LDGKPCDJPLA("country-england", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("acceptFriend");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void PDBKDBLENIG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<EnemyPoint> list = NNIHBKFNILP(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1387f, 0);
			Mine cOHKHNALDPH = playerOld.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 232f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerOld.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE, t)) * 411f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.cardIconIndicator.LDGKPCDJPLA("Twitch", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("CURRENT PLAYER - REMOVE CARD FROM DEPOSITED CARDS - card id is null");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
	}

	private List<EnemyPoint> IEGFOMCBKNF(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.CNGHKNPJAPN() == EnemyPoint.LJGGJMAFEBN.Rusher && item.CIOGGAKBBOJ() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(5, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void JIHHEBGMCBB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = IEGFOMCBKNF(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 544f, 0);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1715f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE, t)) * 406f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.IFKEKKPFIEF().NNPILDOKNJO("Gold", NABOFKMBMKH: false);
			}
			else
			{
				Debug.LogError("RewardItem");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> JEIKEHMBMJA(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.BMNEPICFHNO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.HECCAFJBKGP() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner) && item.MHLKAEOAGAM() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(3, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> JOMJFAHJNMP(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.LDGAKJJINEO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.LJPBPIDDMAE() == EnemyPoint.LJGGJMAFEBN.Rusher && item.MHLKAEOAGAM() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(7, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> DLGPPOIAPGL(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.LDGAKJJINEO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.LOIJJLGGNFN() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner) && item.BKIIMANDLPL() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(0, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void JCCNJNMBKBO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		List<EnemyPoint> list = FFEMPJOCMHJ(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1214f, 0);
			Mine cOHKHNALDPH = playerController.BEIIOAIJMFK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 19f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t)) * 1515f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.AIDNEPBELFP().LJLDJOHAAMC("ID_WARNING_SERVERTIMEDOUT", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("#AccoutCheck# Account exist check result NOT contain result message");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> CKHMFMBLDIN(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.NDFKANKCFFO() == (EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner) && item.IOPIBCMGGDG() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(1, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> JIBFPDCEOBM(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.LDGAKJJINEO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.CNGHKNPJAPN() == (EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner) && item.JJDDKGIGJNI() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(4, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void IHPNEPEBKCP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = FPGEAGNDLGC(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 627f, 1);
			Mine cOHKHNALDPH = playerController.FMKGGADDHJK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1052f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, t)) * 1840f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.GDBDMFCEGIB().GKAOMCGCDGE("AccountId", NABOFKMBMKH: false);
			}
			else
			{
				Debug.LogError("ID_WAITINGFOROPPONENTCARDS");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void NPNDHFIMPHE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = IEGFOMCBKNF(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 255f, 0);
			Mine cOHKHNALDPH = playerController.FMKGGADDHJK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 816f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, t)) * 1057f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.AIDNEPBELFP().OFPAGLLFPPK("ID_TIERX", NABOFKMBMKH: false);
			}
			else
			{
				Debug.LogError("-ABILITYMAXDESC");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> NNIHBKFNILP(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.MODBJDDNNFN() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner) && item.CIOGGAKBBOJ() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(8, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void KKEPLAFJKOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = HCINPMKGDLM(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 459f, 1);
			Mine cOHKHNALDPH = playerController.JLMDEMFIHCA().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 956f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t)) * 623f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.GDBDMFCEGIB().GGHDIAFACAH("Skipping instant battle notification", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("ID_COLLECTXELITEPARTSX");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<EnemyPoint> list = HIFIDCHKCHP(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 10f, 1);
			Mine cOHKHNALDPH = playerOld.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = -0.1f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerOld.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE, t)) * 0.1f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.cardIconIndicator.Show("game-card-ico-mineyourstep-full", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("Mine ammo null");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
	}

	private List<EnemyPoint> CBAIJEKKKJG(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.enemyPointType == EnemyPoint.LJGGJMAFEBN.Hiding && item.MMEJGAPHKPJ() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(0, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void EKFKAICCHLI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = HMOKOEJAEBA(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 519f, 1);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1573f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t)) * 170f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.AOANMLBFHJA().PEBHGOMEKME("SERVICE_VERSION_UPDATE_REQUIRED", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("silverwarcard");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void MLOJPAEBLBL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<EnemyPoint> list = HJNABCCOBOJ(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1436f, 0);
			Mine cOHKHNALDPH = playerOld.JLMDEMFIHCA().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1335f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerOld.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE, t)) * 1138f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.IFKEKKPFIEF().Show("Sniper_Tutorial_Played", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("(Landroid/os/Parcel;I)V");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
	}

	private List<EnemyPoint> DIMNNGDFGHC(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.LJPBPIDDMAE() == EnemyPoint.LJGGJMAFEBN.Car && item.IOPIBCMGGDG() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(0, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> PJAPKGKBIIE(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.CNGHKNPJAPN() == (EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner) && item.MMEJGAPHKPJ() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(7, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> AIKPAMLOAPK(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.LDGAKJJINEO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.NDFKANKCFFO() == EnemyPoint.LJGGJMAFEBN.Car && item.IOPIBCMGGDG() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(2, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> KHIFFDKCGDO(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.GNEHPIPGJCO() == (EnemyPoint.LJGGJMAFEBN)0 && item.fraction != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(4, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void LEEFEJHDLGM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = KHIFFDKCGDO(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1247f, 0);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1751f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE, t)) * 242f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.MMCLHGEGOJO().NNPILDOKNJO("ID_CONFIRM_ERROR", NABOFKMBMKH: true, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("ThrowGrenadeFromCrawl");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> NDDJKOCFHEC(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.GNEHPIPGJCO() == EnemyPoint.LJGGJMAFEBN.Corner && item.MHLKAEOAGAM() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(3, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> FPGEAGNDLGC(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.LJPBPIDDMAE() == EnemyPoint.LJGGJMAFEBN.Car && item.BLNNGHLFHPK() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(4, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void IOKJMNMABHC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		List<EnemyPoint> list = BKGGFLGPDJL(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1290f, 0);
			Mine cOHKHNALDPH = playerController.FMKGGADDHJK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1184f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, t)) * 1222f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.AOANMLBFHJA().GGHDIAFACAH("ID_MISSION_UNITS_HUD", NABOFKMBMKH: false);
			}
			else
			{
				Debug.LogError("SetHitByUnit , ");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> BKGGFLGPDJL(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.NDFKANKCFFO() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding | EnemyPoint.LJGGJMAFEBN.Corner) && item.EJDFGMKHGLN() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(8, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void LLMMIFJBLBD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = KHIFFDKCGDO(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1002f, 1);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 117f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t)) * 1016f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.MMCLHGEGOJO().OFPAGLLFPPK("Player_Avoided_Grenade_On_First_Try", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("GameLauncher.Start");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void OFNENBNMMOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<EnemyPoint> list = JEIKEHMBMJA(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1197f, 0);
			Mine cOHKHNALDPH = playerOld.JLMDEMFIHCA().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1171f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerOld.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, t)) * 950f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.cardIconIndicator.JCJFMHGNIOF("ID_UNIT2TRAIN_UNIT1TRAIN", NABOFKMBMKH: true, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("damage");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
	}

	public virtual void EOODECJEMIE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<EnemyPoint> list = MJNAJMFIHCA(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1051f, 1);
			Mine cOHKHNALDPH = playerOld.BEIIOAIJMFK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1685f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerOld.EHHHBEMKGOE.BPNPPKPCFGN() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE, t)) * 419f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.JHEBMKKODAE().EOEDEJKJKMN(" abilityIcon:", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("Getting fraction for {0} with result {1}");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
	}

	public virtual void ACIOLBGILBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		List<EnemyPoint> list = BKGGFLGPDJL(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 879f, 0);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1707f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE, t)) * 1923f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.JHEBMKKODAE().JCJFMHGNIOF("ID_ARENARULES_RANDOMUNITS", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("ID_CONFIRM_NOTENOUGHMEDALSTOJOIN");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void BHBDBJNOCMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		List<EnemyPoint> list = HJNABCCOBOJ(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1696f, 1);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 568f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE, t)) * 1065f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.IFKEKKPFIEF().Show("{0:D2}:{1:D2}", NABOFKMBMKH: false);
			}
			else
			{
				Debug.LogError("CreateGcAccount with ");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> ONMNJCCLOPB(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.GNEHPIPGJCO() == (EnemyPoint.LJGGJMAFEBN.Rusher | EnemyPoint.LJGGJMAFEBN.Hiding) && item.MMEJGAPHKPJ() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(1, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void BEDOCBBEGAK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		List<EnemyPoint> list = CFGBNMJNLIB(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 264f, 0);
			Mine cOHKHNALDPH = playerController.FMKGGADDHJK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 581f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, t)) * 591f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.MMCLHGEGOJO().EOEDEJKJKMN("throw_grenade_left", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("_#");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> MJNAJMFIHCA(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.enemyPointType == EnemyPoint.LJGGJMAFEBN.Rusher && item.BLNNGHLFHPK() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(5, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void LCHBPLMPGJP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		List<EnemyPoint> list = FFEMPJOCMHJ(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1030f, 1);
			Mine cOHKHNALDPH = playerController.FMKGGADDHJK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1289f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, t)) * 1950f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.AIDNEPBELFP().JCJFMHGNIOF("!!!!", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("VisualType");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void BDLHMMDHGMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		List<EnemyPoint> list = FPGEAGNDLGC(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1712f, 0);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1284f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, t)) * 1416f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.IFKEKKPFIEF().Show("Automatic_Equip", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("(Lcom/google/android/gms/common/api/GoogleApiClient$OnConnectionFailedListener;)V");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> HCINPMKGDLM(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.BMNEPICFHNO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.enemyPointType == EnemyPoint.LJGGJMAFEBN.Hiding && item.fraction != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(6, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> HJNABCCOBOJ(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.LDGAKJJINEO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.HECCAFJBKGP() == EnemyPoint.LJGGJMAFEBN.Hiding && item.JJDDKGIGJNI() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(1, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> CFGBNMJNLIB(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.LDGAKJJINEO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.NDFKANKCFFO() == EnemyPoint.LJGGJMAFEBN.Car && item.BLNNGHLFHPK() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(5, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	private List<EnemyPoint> GJOHMMECIGG(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.BMNEPICFHNO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.enemyPointType == EnemyPoint.LJGGJMAFEBN.Rusher && item.fraction != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(7, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void NLPMJPNEEOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<EnemyPoint> list = FFEMPJOCMHJ(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1113f, 1);
			Mine cOHKHNALDPH = playerOld.FMKGGADDHJK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 490f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerOld.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMin).FLOATVALUE, t)) * 729f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.IFKEKKPFIEF().PEBHGOMEKME("ExplodeDamage", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("getNumberOfSessions");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
	}

	private List<EnemyPoint> KNEDPFEJMDK(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.GIEIGPKGGNL() == EnemyPoint.LJGGJMAFEBN.Hiding && item.MMEJGAPHKPJ() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(5, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void BGLMKFDPDNB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = CBAIJEKKKJG(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1669f, 1);
			Mine cOHKHNALDPH = playerController.FMKGGADDHJK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 524f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, t)) * 641f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.AOANMLBFHJA().GGHDIAFACAH("ID_NOTIFICATION_LAPSED_VIP", NABOFKMBMKH: true, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("ID_OFFERACTIVE");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> HIFIDCHKCHP(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.enemyPointType == EnemyPoint.LJGGJMAFEBN.Hiding && item.fraction != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(3, list.Count))
		{
			int num = 0;
			do
			{
				num = Random.Range(0, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void MLEBPBFEOKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = JIBFPDCEOBM(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 645f, 0);
			Mine cOHKHNALDPH = playerController.FMKGGADDHJK().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 765f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.BrokenLegsTime).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE, t)) * 432f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.AIDNEPBELFP().PEBHGOMEKME("ID_EARLYUNLOCK2", NABOFKMBMKH: false);
			}
			else
			{
				Debug.LogError("ShootFromCrawl");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	private List<EnemyPoint> ILJCOPKOIIK(GHPGNELIDBM IEIKEJDECIG)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.OKBAIGKCPKA().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (item.HECCAFJBKGP() == EnemyPoint.LJGGJMAFEBN.Corner && item.JJDDKGIGJNI() != IEIKEJDECIG)
			{
				list.Add(item);
			}
		}
		List<EnemyPoint> list2 = new List<EnemyPoint>();
		while (list2.Count < Mathf.Min(5, list.Count))
		{
			int num = 1;
			do
			{
				num = Random.Range(1, list.Count);
			}
			while (list2.Contains(list[num]));
			list2.Add(list[num]);
		}
		return list2;
	}

	public virtual void AGMKIMGHPAL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		List<EnemyPoint> list = HCINPMKGDLM(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 441f, 1);
			Mine cOHKHNALDPH = playerOld.JLMDEMFIHCA().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1590f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerOld.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoThiefCoef).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, t)) * 1262f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.AOANMLBFHJA().BIIHCAEKCOD("registerBirthday", NABOFKMBMKH: false);
			}
			else
			{
				Debug.LogError("ID_BLACKMARKETLEFTTEXT3");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
	}

	public virtual void FHPAJBONKON(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		List<EnemyPoint> list = ILJCOPKOIIK(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1247f, 1);
			Mine cOHKHNALDPH = playerController.JLMDEMFIHCA().COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1301f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ExplosivePistolDamageMax).FLOATVALUE, t)) * 1308f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.cardIconIndicator.NNPILDOKNJO("DatabaseMessage - No long existing database message came from server!", NABOFKMBMKH: false, HGNIGKCLLHM: true);
			}
			else
			{
				Debug.LogError("0.0.0");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}

	public virtual void PFLGKCELNOM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCard(MNBIOCOAJHK, CIOPAKLHFIL);
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		List<EnemyPoint> list = AIKPAMLOAPK(CIOPAKLHFIL);
		foreach (EnemyPoint item in list)
		{
			NavMesh.SamplePosition(item.transform.position, out var hit, 1269f, 1);
			Mine cOHKHNALDPH = playerController.weaponInventory.COHKHNALDPH;
			cOHKHNALDPH.JMDLKIAKOIE = 1133f;
			HLFBKIPANFD = hit.position;
			MineAmmoSetup mineAmmoSetup = (MineAmmoSetup)cOHKHNALDPH.ammoSetup;
			if ((bool)mineAmmoSetup)
			{
				float t = (float)playerController.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
				mineAmmoSetup.EPDELOGPNAC = (mineAmmoSetup.ABFGHBDEBAN = Mathf.Lerp(Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.LandMineDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, t)) * 744f;
			}
			MineAmmo mineAmmo = cOHKHNALDPH.Fire(HLFBKIPANFD) as MineAmmo;
			if (mineAmmo != null)
			{
				mineAmmo.cardIconIndicator.GGHDIAFACAH("ID_SALEPERCENTLINE", NABOFKMBMKH: true);
			}
			else
			{
				Debug.LogError("{0} {1}");
			}
		}
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
	}
}
