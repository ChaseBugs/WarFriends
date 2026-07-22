using UnityEngine;
using UnityEngine.Serialization;

public class ShotTrailRenderer : Singleton<ShotTrailRenderer>
{
	[FormerlySerializedAs("BKFCLLJPODL")]
	public ShotTrail CGMMAIBICAK;

	public ShotTrail FFDJIHEEILI(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, float KBJEOEEOEFG)
	{
		ShotTrail shotTrail = PPLOJOENHHG(OEIICEJPGKI, IIMDKHJAJGO);
		if (shotTrail != null)
		{
			shotTrail.OCEFFHCECIL.time = KBJEOEEOEFG;
		}
		return shotTrail;
	}

	public ShotTrail DIKJNMMJMFO(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		ObjectPool objectPool = ObjectPoolDatabase.FLAHKAIJHBP();
		ShotTrail shotTrail = objectPool.Instantiate(CGMMAIBICAK, OEIICEJPGKI, Quaternion.identity) as ShotTrail;
		if (shotTrail != null)
		{
			TweenPosition.Begin(shotTrail.gameObject, 1301f, OEIICEJPGKI, IIMDKHJAJGO, useLocal: false);
			shotTrail.NKCHNDKGBKM();
			return shotTrail;
		}
		return null;
	}

	public ShotTrail PPLOJOENHHG(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		ObjectPool objectPool = ObjectPoolDatabase.MCACDGOEBHE();
		ShotTrail shotTrail = objectPool.EJIHLMEDEEB(CGMMAIBICAK, OEIICEJPGKI, Quaternion.identity) as ShotTrail;
		if (shotTrail != null)
		{
			TweenPosition.Begin(shotTrail.gameObject, 495f, OEIICEJPGKI, IIMDKHJAJGO, useLocal: false);
			shotTrail.LMGELADPEHH();
			return shotTrail;
		}
		return null;
	}

	public ShotTrail CCHECMPOOBA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		ObjectPool objectPool = ObjectPoolDatabase.MCACDGOEBHE();
		ShotTrail shotTrail = objectPool.FIDFODMFEBC(CGMMAIBICAK, OEIICEJPGKI, Quaternion.identity) as ShotTrail;
		if (shotTrail != null)
		{
			TweenPosition.Begin(shotTrail.gameObject, 181f, OEIICEJPGKI, IIMDKHJAJGO, useLocal: false);
			shotTrail.LMGELADPEHH();
			return shotTrail;
		}
		return null;
	}

	public ShotTrail PlayShot(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		ObjectPool ammoPool = ObjectPoolDatabase.ammoPool;
		ShotTrail shotTrail = ammoPool.Instantiate(CGMMAIBICAK, OEIICEJPGKI, Quaternion.identity) as ShotTrail;
		if (shotTrail != null)
		{
			TweenPosition.Begin(shotTrail.gameObject, 0.3f, OEIICEJPGKI, IIMDKHJAJGO, useLocal: false);
			shotTrail.PlayShot();
			return shotTrail;
		}
		return null;
	}

	public ShotTrail EOICPDKHNDN(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, float KBJEOEEOEFG)
	{
		ShotTrail shotTrail = PPLOJOENHHG(OEIICEJPGKI, IIMDKHJAJGO);
		if (shotTrail != null)
		{
			shotTrail.OCEFFHCECIL.time = KBJEOEEOEFG;
		}
		return shotTrail;
	}

	public ShotTrail JHIFLMLEFBK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, float KBJEOEEOEFG)
	{
		ShotTrail shotTrail = CCHECMPOOBA(OEIICEJPGKI, IIMDKHJAJGO);
		if (shotTrail != null)
		{
			shotTrail.OCEFFHCECIL.time = KBJEOEEOEFG;
		}
		return shotTrail;
	}

	public ShotTrail PlayShot(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, float KBJEOEEOEFG)
	{
		ShotTrail shotTrail = PlayShot(OEIICEJPGKI, IIMDKHJAJGO);
		if (shotTrail != null)
		{
			shotTrail.OCEFFHCECIL.time = KBJEOEEOEFG;
		}
		return shotTrail;
	}
}
