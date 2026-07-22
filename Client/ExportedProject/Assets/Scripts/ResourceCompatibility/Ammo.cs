using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Ammo : PoolableObject, TimeScaleIgnorable, IBFMOMDLFEP
{
	public enum AKNIJEIOBGH
	{
		EnemyPlayer,
		MechanicalUnits,
		NonmechanicalUnits,
		AirUnits,
		UnitCategory
	}

	public struct AGLOGGKNEOM
	{
		public float PIMDLOBOGIM;

		public AKNIJEIOBGH JFACCKJNHHC;

		public float FPFKEBLJFBD(DestroyableObject IILHBBEDLPP, AIObject NBBEEENLPEA)
		{
			return 0f;
		}
	}

	public enum BICKHONNMCG
	{
		Real,
		Fake,
		Shield
	}

	private static ObjectPool DCJOJFDFABA;

	protected bool CNNIAAFHBFH;

	public float HLGEGMJCDJE;

	public List<AGLOGGKNEOM> PPHBECILHDP;

	public List<AGLOGGKNEOM> PENEGDFPHME;

	public bool HKGICFLDIHH;

	public Weapon AEBEOCBIBFI;

	public BICKHONNMCG JFACCKJNHHC;

	public bool KMKNPEHKLMI;

	[CompilerGenerated]
	private bool _003CDEKBAKPBFEP_003Ek__BackingField;

	public bool ignoreTimeScale
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public static ObjectPool ammoPool
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public HPHFGNJPDKN fraction
	{
		get
		{
			return default(HPHFGNJPDKN);
		}
		set
		{
		}
	}

	public IBFMOMDLFEP owner => null;

	public abstract void Fire(Vector3 EMMCJEEABGA, Vector3 FFJGKOLGFLL);

	public virtual void FireMultipleAmmos(Vector3 EMMCJEEABGA, Vector3 FFJGKOLGFLL, int MJNAKJCPGNC)
	{
	}

	public virtual bool DoDamage(GameObject KIHIFIBOOIM, RaycastHit PONMHLDLONO, Vector3 LNODBAPDOJO, DestroyableObject.GIKHDAPJINF BEHICELPHAK, out DestroyableObject IAKBDFLKBHA)
	{
		IAKBDFLKBHA = null;
		return false;
	}

	public virtual void LoadAmmoSetup(AmmoSetup IDIIEBBLDAM)
	{
	}

	public static BICKHONNMCG GetShotType(GameShootableEntity.ShotTarget LGFMBOJMMMB)
	{
		return default(BICKHONNMCG);
	}

	public float CheckExtraHeadshotDamageTargets(DestroyableObject IILHBBEDLPP)
	{
		return 0f;
	}

	public float CheckExtraDamageTargets(DestroyableObject IILHBBEDLPP)
	{
		return 0f;
	}
}
