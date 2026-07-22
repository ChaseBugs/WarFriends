using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Ammo : PoolableObject, TimeScaleIgnorable, KMHCMCBGFFC
{
	public enum ILIOELBBLDM
	{
		Real,
		Fake,
		Shield
	}

	[FormerlySerializedAs("HLGEGMJCDJE")]
	public float PMCGFJLLCHJ = 40f;

	[FormerlySerializedAs("HKGICFLDIHH")]
	public bool GGJPNLDIGGM;

	[FormerlySerializedAs("AEBEOCBIBFI")]
	public Weapon JMMJHCOKCGG;

	public ILIOELBBLDM FJLBLLLEELD;

	private static ObjectPool DNJGBBNLOPE;

	[FormerlySerializedAs("KMKNPEHKLMI")]
	public bool CAKABHIPCDF;

	private bool LEPEDIAOGBH;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CEHAGGBILLNL_003Ek__BackingField;

	public bool ignoreTimeScale
	{
		[CompilerGenerated]
		get
		{
			return _003CEHAGGBILLNL_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CEHAGGBILLNL_003Ek__BackingField = value;
		}
	}

	public static ObjectPool ammoPool
	{
		get
		{
			if (DNJGBBNLOPE == null)
			{
				DNJGBBNLOPE = ObjectPool.GetPool("AmmoPool");
			}
			return DNJGBBNLOPE;
		}
		set
		{
			DNJGBBNLOPE = value;
		}
	}

	public GHPGNELIDBM fraction
	{
		get
		{
			return JMMJHCOKCGG.fraction;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public KMHCMCBGFFC owner => JMMJHCOKCGG.owner;

	public abstract void Fire(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO);

	public virtual bool DoDamage(GameObject ENCEFOOPBMK, RaycastHit MGECAKNCNBD, Vector3 LPGMLOCLBGP, bool DLKHGAHBIMB, out DestroyableObject CMNFMDJEOIK)
	{
		CMNFMDJEOIK = null;
		if (TagsAndLayers.IsDestroyableObject(ENCEFOOPBMK))
		{
			CMNFMDJEOIK = ENCEFOOPBMK.GetComponent<DestroyableObject>();
			if (CMNFMDJEOIK != null)
			{
				if (CMNFMDJEOIK.fraction == fraction)
				{
					PlayerController playerController = owner as PlayerController;
					if (playerController != null && playerController.COHFDCGJECK)
					{
						return false;
					}
				}
				if (DLKHGAHBIMB)
				{
					CMNFMDJEOIK.Burn(PMCGFJLLCHJ, MGECAKNCNBD.point, LPGMLOCLBGP, JMMJHCOKCGG, owner, CAKABHIPCDF, LEPEDIAOGBH);
				}
				else
				{
					CMNFMDJEOIK.Shoot(PMCGFJLLCHJ, MGECAKNCNBD.point, LPGMLOCLBGP, JMMJHCOKCGG, owner, CAKABHIPCDF, LEPEDIAOGBH);
				}
				return true;
			}
		}
		return false;
	}

	public virtual void LoadAmmoSetup(AmmoSetup MBNLFKHLDBH)
	{
		if (UnityEngine.Random.value < (float)MBNLFKHLDBH.NFKPBDGGDEA)
		{
			LEPEDIAOGBH = true;
			PMCGFJLLCHJ = (float)MBNLFKHLDBH.EPDELOGPNAC * (float)MBNLFKHLDBH.FACEDCDFHJC;
		}
		else
		{
			LEPEDIAOGBH = false;
			PMCGFJLLCHJ = MBNLFKHLDBH.EPDELOGPNAC;
		}
	}

	public static ILIOELBBLDM GetShotType(GameShootableEntity.ShotTarget MKIPAEDAADL)
	{
		if (MKIPAEDAADL.type == GameShootableEntity.LAAAMBBNIJO.Shield)
		{
			return ILIOELBBLDM.Shield;
		}
		return ILIOELBBLDM.Real;
	}
}
