using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class Gun : Weapon
{
	[FormerlySerializedAs("BGJNHFLGPGH")]
	public vp_MuzzleFlash FPJEKKMDJCG;

	[FormerlySerializedAs("IDBOLBAACHM")]
	public Vector3 AEKBMHEFNHH = new Vector3(0f, 0.1f, 0f);

	[FormerlySerializedAs("IIGAMCGHCNJ")]
	public ParticleSystem EJIOBBOBGOI;

	[FormerlySerializedAs("ONIEAEDLCEA")]
	public bool KKHFGIBILAI;

	public override bool willShoot => base.willShoot && TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;

	[SpecialName]
	public virtual bool COJNEOHPJGL()
	{
		return base.willShoot && TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	public virtual float AIDLNCJABHB(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.ACEKBNJPDEL() + 1952f;
		}
		return 1964f;
	}

	public void DestroyBullets()
	{
		List<PoolableObject> objectsMadeOfPrefab = Ammo.ammoPool.GetObjectsMadeOfPrefab(OLKAIPEHAML);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.JMMJHCOKCGG == this)
				{
					bulletBase.DestroyPooled();
				}
			}
		}
	}

	protected virtual Ammo KPDBBAHJJOP(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.LHOEKJPHFKB(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: false);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	protected virtual Ammo ECNCECOPEOM(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.DOLLANGOAIM(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: false);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	public void PGCCFBEDHDD()
	{
		List<PoolableObject> list = Ammo.ammoPool.PIBDLHKDHKH(OLKAIPEHAML);
		foreach (PoolableObject item in list)
		{
			if (item.isInstantiated)
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.JMMJHCOKCGG == this)
				{
					bulletBase.DestroyPooled();
				}
			}
		}
	}

	public virtual float CKANDGANPFK(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.IOPKJANAPOM() + 1901f;
		}
		return 1715f;
	}

	public override float ComputeFlyTimeToTarget(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.bulletSpeed + 0.1f;
		}
		return 0.1f;
	}

	[SpecialName]
	public virtual bool LKJIFDMOKEK()
	{
		return !base.willShoot || TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	public void NBFOBLGMBIJ()
	{
		List<PoolableObject> objectsMadeOfPrefab = Ammo.ammoPool.GetObjectsMadeOfPrefab(OLKAIPEHAML);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.JMMJHCOKCGG == this)
				{
					bulletBase.DestroyPooled();
				}
			}
		}
	}

	protected virtual Ammo DBCDDNOILJD(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.JAOIENIGGFG(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: true);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	[SpecialName]
	public virtual bool LCPLFBPNLDI()
	{
		return !base.willShoot || TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	protected virtual Ammo OMODKIFONDM(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.PCMJCBKMAKG(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: false);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	public virtual float IKLFDBKHOHP(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.bulletSpeed + 256f;
		}
		return 1697f;
	}

	public virtual float CHENPBLEMFL(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.LHDHGJNOBEE() + 708f;
		}
		return 1257f;
	}

	protected virtual Ammo HCKJKCMACHC(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.NECMOMGCLGN(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: true);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	private void BGHBDBLMMNE(bool NCMHGPNPEJM)
	{
	}

	private void PNJENENBOID(bool NCMHGPNPEJM)
	{
	}

	[SpecialName]
	public virtual bool OLNMJFALMOG()
	{
		return base.willShoot && TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	public virtual float EEELNODNAFN(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.GKOMEKIGEOB() + 1004f;
		}
		return 704f;
	}

	public virtual float OGILALBFGDL(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.HDEEPEADLHJ() + 767f;
		}
		return 1113f;
	}

	public void HIANGDFGDOK()
	{
		List<PoolableObject> objectsMadeOfPrefab = Ammo.ammoPool.GetObjectsMadeOfPrefab(OLKAIPEHAML);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.JMMJHCOKCGG == this)
				{
					bulletBase.DestroyPooled();
				}
			}
		}
	}

	[SpecialName]
	public virtual bool CMANDMBMCAA()
	{
		return base.willShoot && TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	private void DJODCGEOMBE(bool NCMHGPNPEJM)
	{
	}

	[SpecialName]
	public virtual bool MIGFPIPDAJD()
	{
		return base.willShoot && TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	protected virtual Ammo BGBMAMCIJJN(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.DOLLANGOAIM(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: true);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	private void MCCGLHJGOFL(bool NCMHGPNPEJM)
	{
	}

	public virtual float CACBCCFBKGL(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.IEABIBJJKPC() + 512f;
		}
		return 500f;
	}

	[SpecialName]
	public virtual bool NEMBBPFPLCF()
	{
		return !base.willShoot || TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	protected virtual Ammo KBICFELKOJI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.LHOEKJPHFKB(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: true);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	public virtual float BLKDELBMJAF(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.FNGDNOBPHPH() + 176f;
		}
		return 1253f;
	}

	private void ILNJIMMOIFK(bool NCMHGPNPEJM)
	{
	}

	protected virtual Ammo CDKFFGPGHLD(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.KACHOCKGPLA(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: true);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	public void LGCBNAFPDNF()
	{
		List<PoolableObject> list = Ammo.ammoPool.PIBDLHKDHKH(OLKAIPEHAML);
		foreach (PoolableObject item in list)
		{
			if (item.isInstantiated)
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.JMMJHCOKCGG == this)
				{
					bulletBase.OBCAIFMOPPA();
				}
			}
		}
	}

	protected virtual Ammo APFEPFDKCKK(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.EJIHLMEDEEB(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.NDGLPMLNFHJ(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: false);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	private void AOCLDDCKFHD(bool NCMHGPNPEJM)
	{
	}

	public virtual float HENJAPMLMJL(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.IOPKJANAPOM() + 1935f;
		}
		return 1530f;
	}

	public virtual float DGECDDDBBCI(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.FNGDNOBPHPH() + 1005f;
		}
		return 1485f;
	}

	protected virtual Ammo PHBLPLLDPFN(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.NDGLPMLNFHJ(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: false);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	protected virtual Ammo NFMOAFGAMOD(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.GGAHEKAOAPL(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: false);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	private void MLDBJOBOHIO(bool NCMHGPNPEJM)
	{
	}

	[SpecialName]
	public virtual bool IHIPEPOMLBC()
	{
		return !base.willShoot || TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	private void AOBPPOIKPEL(bool NCMHGPNPEJM)
	{
	}

	public virtual float GIMINGGHEMN(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.IOPKJANAPOM() + 1248f;
		}
		return 1178f;
	}

	private void JEJNBHKMGAL(bool NCMHGPNPEJM)
	{
	}

	public void NLCEEOJPLHL()
	{
		List<PoolableObject> objectsMadeOfPrefab = Ammo.ammoPool.GetObjectsMadeOfPrefab(OLKAIPEHAML);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.JHJJKEBNGEN())
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.JMMJHCOKCGG == this)
				{
					bulletBase.OBCAIFMOPPA();
				}
			}
		}
	}

	protected virtual Ammo DAMHDCFCALK(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.MDKGJBLNBIB(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: false);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	[SpecialName]
	public virtual bool OBBFEELPKLF()
	{
		return base.willShoot && TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	private void GCDICMEBALD(bool NCMHGPNPEJM)
	{
	}

	private void EDOINMEFDLD(bool NCMHGPNPEJM)
	{
	}

	public void JPJOKHOFGII()
	{
		List<PoolableObject> list = Ammo.ammoPool.PIBDLHKDHKH(OLKAIPEHAML);
		foreach (PoolableObject item in list)
		{
			if (item.isInstantiated)
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.JMMJHCOKCGG == this)
				{
					bulletBase.BOHCNEDIJPE();
				}
			}
		}
	}

	protected virtual Ammo JPLPOELJDKL(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.FIDFODMFEBC(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.ODLMMPHOBLF(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: true);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	[SpecialName]
	public virtual bool CBKHAMCAHHB()
	{
		return base.willShoot && TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	[SpecialName]
	public virtual bool CBIMKMOGGMJ()
	{
		return !base.willShoot || TimeManager.realTimeWithoutPauses > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	protected virtual Ammo FDJMAANBKLE(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.POIFPKMLACB(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: false);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	private void DJPAHPNBHLM(bool NCMHGPNPEJM)
	{
	}

	[SpecialName]
	public virtual bool JGKEBEAJGOB()
	{
		return base.willShoot && TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	protected override Ammo MDKABJDCKBI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.Shoot(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: true);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	[SpecialName]
	public virtual bool BMAJKDFFALB()
	{
		return !base.willShoot || TimeManager.CEAFAMFNGCC() > base.lastShotTime + (float)JMDLKIAKOIE;
	}

	private void ANBEBIBDGCE(bool NCMHGPNPEJM)
	{
	}

	public void CAGNOCJHAPB()
	{
		List<PoolableObject> list = Ammo.ammoPool.PIBDLHKDHKH(OLKAIPEHAML);
		foreach (PoolableObject item in list)
		{
			if (item.PLPBGNOCCPI())
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.JMMJHCOKCGG == this)
				{
					bulletBase.DestroyPooled();
				}
			}
		}
	}

	public void AMAEIJCIMNB()
	{
		List<PoolableObject> objectsMadeOfPrefab = Ammo.ammoPool.GetObjectsMadeOfPrefab(OLKAIPEHAML);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.isInstantiated)
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.JMMJHCOKCGG == this)
				{
					bulletBase.BOHCNEDIJPE();
				}
			}
		}
	}

	public void OIMLHKEAIBE()
	{
		List<PoolableObject> objectsMadeOfPrefab = Ammo.ammoPool.GetObjectsMadeOfPrefab(OLKAIPEHAML);
		foreach (PoolableObject item in objectsMadeOfPrefab)
		{
			if (item.PPHLEDLNGIN())
			{
				BulletBase bulletBase = (BulletBase)item;
				if (bulletBase.JMMJHCOKCGG == this)
				{
					bulletBase.BOHCNEDIJPE();
				}
			}
		}
	}

	public virtual float CENBIEBAOEK(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.HJNKOGMFKIB() + 1780f;
		}
		return 1817f;
	}

	protected virtual Ammo JBFMCPNACAA(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		Ammo ammo = (Ammo)Ammo.ammoPool.Instantiate(OLKAIPEHAML, GHPBMCAKMMB.transform.position + AEKBMHEFNHH, Quaternion.identity);
		BulletBase bulletBase = null;
		if (ammo != null)
		{
			ammo.LoadAmmoSetup(base.ammoSetup);
			ammo.ignoreTimeScale = base.ignoreTimeScale;
			ammo.GGJPNLDIGGM = GGJPNLDIGGM;
			ammo.FJLBLLLEELD = EBNMDKAEJAH;
			ammo.JMMJHCOKCGG = this;
			ammo.CAKABHIPCDF = CAKABHIPCDF;
			bulletBase = ammo as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.OLDPEIALACE = KKHFGIBILAI;
			}
			ammo.Fire(GHPBMCAKMMB.transform.position + AEKBMHEFNHH, MPHCNMDIPAI);
		}
		if ((bool)FPJEKKMDJCG)
		{
			FPJEKKMDJCG.Shoot(base.ignoreTimeScale);
		}
		if (EJIOBBOBGOI != null)
		{
			EJIOBBOBGOI.Play(withChildren: false);
		}
		base.MDKABJDCKBI(MPHCNMDIPAI, CAKABHIPCDF);
		return ammo;
	}

	public virtual float AMENPPOBMHC(Vector3 MPHCNMDIPAI)
	{
		BulletSetup bulletSetup = base.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			return num / bulletSetup.GKOMEKIGEOB() + 132f;
		}
		return 1568f;
	}
}
