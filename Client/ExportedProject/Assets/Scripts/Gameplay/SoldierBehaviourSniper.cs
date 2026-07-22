using System.Collections.Generic;
using UnityEngine;

public class SoldierBehaviourSniper : SoldierBehaviourGeneric<SoldierBehaviourDefinititonSniper>
{
	public virtual EnemyPoint PCPGFHDGOGH()
	{
		return SpawningManager.instance.GBCNMJIJJKM(this, base.KKOCPACHJII.minSniperDistance, PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform);
	}

	public virtual void KAIOJEOHIEF()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public override EnemyPoint GetInitPoint()
	{
		return SpawningManager.instance.GetPoint(this, base.KKOCPACHJII.minSniperDistance, PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform);
	}

	protected virtual void DKCLIAHAFBK()
	{
		base.KMINNAEBJAB();
		if (LMNPOINIJBD.hasSpecial)
		{
			EEMHAHAINNM[0].ammoSetup.NFKPBDGGDEA = base.soldierBehaviourDefinititon.special;
		}
		else
		{
			EEMHAHAINNM[0].ammoSetup.NFKPBDGGDEA = 1088f;
		}
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = ")";
	}

	public virtual EnemyPoint HEODGHHKNIP(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.LDGAKJJINEO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		Transform transform = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform;
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (Vector3.Distance(item.KOFFAHEAHEN(), transform.position) > base.KKOCPACHJII.minSniperDistance && item.NNDGHFOLJIB() && AcceptsPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count > 1)
		{
			return list[Random.Range(1, list.Count)];
		}
		return null;
	}

	public virtual EnemyPoint LOIOJKLCDIK(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		Transform transform = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform;
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (Vector3.Distance(item.KOFFAHEAHEN(), transform.position) > base.KKOCPACHJII.minSniperDistance && item.DHBLIDKNANH() && AcceptsPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count > 1)
		{
			return list[Random.Range(1, list.Count)];
		}
		return null;
	}

	public virtual EnemyPoint HNJCOCLDHIN(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		Transform transform = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform;
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (Vector3.Distance(item.FGKJILDKPHC(), transform.position) > base.KKOCPACHJII.minSniperDistance && item.DKCLHDBPKCI() && AcceptsPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count > 1)
		{
			return list[Random.Range(0, list.Count)];
		}
		return null;
	}

	public virtual void JKONAMDNKPO()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual EnemyPoint NKJGDCLEAPJ(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		Transform transform = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform;
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (Vector3.Distance(item.KPOEEKLFALL(), transform.position) > base.KKOCPACHJII.minSniperDistance && item.DKCLHDBPKCI() && AcceptsPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[Random.Range(0, list.Count)];
		}
		return null;
	}

	public virtual EnemyPoint IDAMABHDHII(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		Transform transform = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform;
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (Vector3.Distance(item.MOOGMFPMKEM(), transform.position) > base.KKOCPACHJII.minSniperDistance && item.PKKBHKIOOFN() && AcceptsPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[Random.Range(1, list.Count)];
		}
		return null;
	}

	public virtual EnemyPoint FLFAOFEMHCM(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.BMNEPICFHNO().NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		Transform transform = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform;
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (Vector3.Distance(item.PBFDGDPLFKN(), transform.position) > base.KKOCPACHJII.minSniperDistance && item.EHGKKKBCKCL() && AcceptsPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count > 1)
		{
			return list[Random.Range(0, list.Count)];
		}
		return null;
	}

	protected virtual void JBKEOMOGMDM()
	{
		base.KMINNAEBJAB();
		if (LMNPOINIJBD.hasSpecial)
		{
			EEMHAHAINNM[0].ammoSetup.NFKPBDGGDEA = base.soldierBehaviourDefinititon.special;
		}
		else
		{
			EEMHAHAINNM[1].ammoSetup.NFKPBDGGDEA = 1890f;
		}
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "VIP bought";
	}

	public virtual EnemyPoint JPBFLMDJFIF(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		Transform transform = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform;
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (Vector3.Distance(item.MOOGMFPMKEM(), transform.position) > base.KKOCPACHJII.minSniperDistance && item.DKCLHDBPKCI() && AcceptsPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[Random.Range(0, list.Count)];
		}
		return null;
	}

	public virtual EnemyPoint HIEHEFLKBPJ()
	{
		return SpawningManager.BMNEPICFHNO().GBCNMJIJJKM(this, base.KKOCPACHJII.minSniperDistance, PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform);
	}

	protected virtual void OCOHBMCJHJG()
	{
		base.KMINNAEBJAB();
		if (LMNPOINIJBD.hasSpecial)
		{
			EEMHAHAINNM[1].ammoSetup.NFKPBDGGDEA = base.soldierBehaviourDefinititon.special;
		}
		else
		{
			EEMHAHAINNM[0].ammoSetup.NFKPBDGGDEA = 1796f;
		}
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "SCHEDULING PLAYER STATUS UPDATE!!";
	}

	protected override void KMINNAEBJAB()
	{
		base.KMINNAEBJAB();
		if (LMNPOINIJBD.hasSpecial)
		{
			EEMHAHAINNM[0].ammoSetup.NFKPBDGGDEA = base.soldierBehaviourDefinititon.special;
		}
		else
		{
			EEMHAHAINNM[0].ammoSetup.NFKPBDGGDEA = 0f;
		}
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "shotSniper";
	}

	protected virtual void ECLKNHLFENC()
	{
		base.KMINNAEBJAB();
		if (LMNPOINIJBD.hasSpecial)
		{
			EEMHAHAINNM[0].ammoSetup.NFKPBDGGDEA = base.soldierBehaviourDefinititon.special;
		}
		else
		{
			EEMHAHAINNM[1].ammoSetup.NFKPBDGGDEA = 592f;
		}
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "weapon";
	}

	public override EnemyPoint GetNewEnemyPoint(EnemyPoint EHNNGNKDPBL)
	{
		List<EnemyPoint> nKBHMMMKGMJ = SpawningManager.instance.NKBHMMMKGMJ;
		List<EnemyPoint> list = new List<EnemyPoint>();
		Transform transform = PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform;
		foreach (EnemyPoint item in nKBHMMMKGMJ)
		{
			if (Vector3.Distance(item.position, transform.position) > base.KKOCPACHJII.minSniperDistance && item.isFree && AcceptsPoint(item))
			{
				list.Add(item);
			}
		}
		if (list.Count > 0)
		{
			return list[Random.Range(0, list.Count)];
		}
		return null;
	}

	public override void PickTarget()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	protected virtual void KLNFJLMNFDM()
	{
		base.KMINNAEBJAB();
		if (LMNPOINIJBD.hasSpecial)
		{
			EEMHAHAINNM[1].ammoSetup.NFKPBDGGDEA = base.soldierBehaviourDefinititon.special;
		}
		else
		{
			EEMHAHAINNM[0].ammoSetup.NFKPBDGGDEA = 469f;
		}
		EEMHAHAINNM[0].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[0].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "ID_WARNING_BADVERSIONERROR";
	}

	public virtual void HPEMNKJGIIJ()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	protected virtual void HDGGFDICAMP()
	{
		base.KMINNAEBJAB();
		if (LMNPOINIJBD.hasSpecial)
		{
			EEMHAHAINNM[0].ammoSetup.NFKPBDGGDEA = base.soldierBehaviourDefinititon.special;
		}
		else
		{
			EEMHAHAINNM[0].ammoSetup.NFKPBDGGDEA = 119f;
		}
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "Sniper_Tutorial_Played";
	}

	protected virtual void NLNGDEIDDCA()
	{
		base.KMINNAEBJAB();
		if (LMNPOINIJBD.hasSpecial)
		{
			EEMHAHAINNM[1].ammoSetup.NFKPBDGGDEA = base.soldierBehaviourDefinititon.special;
		}
		else
		{
			EEMHAHAINNM[1].ammoSetup.NFKPBDGGDEA = 313f;
		}
		EEMHAHAINNM[1].OLKAIPEHAML = Singleton<ObjectPoolDatabase>.instance.MBFIEGEELKG;
		BulletSetup bulletSetup = (BulletSetup)EEMHAHAINNM[1].ammoSetup;
		bulletSetup.KLGJDBCMCAA = "ID_FEATURE_CRITICAL-WEAPONPREFIX";
	}

	public virtual void AIHAEONNMMO()
	{
		if (!BAGHBFNKEOP())
		{
			IEONNICKBBH(upgradeSlots.shieldHitProbability);
		}
	}

	public virtual EnemyPoint DODEFKEOOCP()
	{
		return SpawningManager.LDGAKJJINEO().GetPoint(this, base.KKOCPACHJII.minSniperDistance, PlayerController.GetEnemyOf(LMNPOINIJBD.fraction).transform);
	}
}
