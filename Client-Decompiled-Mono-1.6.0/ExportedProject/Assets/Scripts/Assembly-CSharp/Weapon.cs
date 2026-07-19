using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

public abstract class Weapon : PoolableObject, TimeScaleIgnorable, KMHCMCBGFFC
{
	public enum IGGFMJAKLGO : byte
	{
		Riffle = 0,
		Grenade = 1,
		Bazooka = 2,
		SwatPistol = 3,
		Minigun = 4,
		Pistol = 5,
		GrenadeLauncher = 6,
		Shotgun = 7,
		Tool = 8,
		QBZ = 9,
		SniperRiffle = 10,
		SwatSMG = 11,
		Flamethrower = 12,
		QBZ2 = 13,
		DoubleSMG = 14,
		Machinegun = 15,
		Colt = 16,
		Mortar = 17
	}

	public delegate void JMPCJHIKJEO(Weapon JMMJHCOKCGG, Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool KLOJNPBGFIG, DestroyableObject OJIHGNJFPFM);

	public Ammo OLKAIPEHAML;

	public ObscuredFloat JMDLKIAKOIE = 0.5f;

	public ObscuredInt FIMMGPLLLCL = 20;

	public ObscuredFloat AMGFJFPKOED = 5f;

	public bool MEFJOGAOKDP = true;

	public bool HOGINLIFMLN;

	public bool NAIKLJKNLAE;

	public bool OLLIJPKAIFC;

	public Transform GHPBMCAKMMB;

	public ObscuredInt LCKNGBAEFCL;

	public bool PKBALLDJEOL = true;

	public bool GGJPNLDIGGM;

	public Ammo.ILIOELBBLDM EBNMDKAEJAH;

	public int BLOHNLJOPIM;

	private ObscuredInt IJEOOGJCAMB;

	private ObscuredInt LEFJCBLMKBE;

	private AmmoSetup BDNJEAKNGOM;

	private bool IHJGEFJOFKH;

	protected float NOFDHHLCEGM;

	protected PhotonView FEHCCGEGPLH;

	private float BEMPMAPDIDH;

	public HINJJOAJAOA GNKKBOADAEA = HINJJOAJAOA.RELOAD_ASSAULT;

	public HINJJOAJAOA EGNEIDMAEKA = HINJJOAJAOA.SHOT_ASSAULT_1;

	public float ADMCKBPFNLO = 1f;

	public IGGFMJAKLGO BEACDIILBEG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static JMPCJHIKJEO GMFFIENELHO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Action<Weapon, Vector3> NHLPPKAGIGF;

	public PlayerWeapon playerWeapon { get; set; }

	public virtual int ammoLeft
	{
		get
		{
			return LEFJCBLMKBE;
		}
		set
		{
			LEFJCBLMKBE = value;
		}
	}

	public int ammoLeftInClip
	{
		get
		{
			return IJEOOGJCAMB;
		}
		set
		{
			IJEOOGJCAMB = value;
			IHJGEFJOFKH = false;
		}
	}

	public AmmoSetup ammoSetup
	{
		get
		{
			return BDNJEAKNGOM ?? (BDNJEAKNGOM = GetComponent<AmmoSetup>());
		}
	}

	public bool isReloading
	{
		get
		{
			if (NAIKLJKNLAE)
			{
				return IHJGEFJOFKH;
			}
			return reloadProgress < 1f && !outOfAmmo;
		}
	}

	public virtual bool willShoot
	{
		get
		{
			if (NAIKLJKNLAE)
			{
				return hasAmmoInClip && !IHJGEFJOFKH;
			}
			return hasAmmo || HOGINLIFMLN;
		}
	}

	public virtual bool hasAmmo
	{
		get
		{
			return ammoLeft > 0 || HOGINLIFMLN;
		}
	}

	public bool outOfAmmo
	{
		get
		{
			if (NAIKLJKNLAE)
			{
				bool flag = ammoLeft <= 0 && !HOGINLIFMLN && ammoLeftInClip <= 0;
				if (!flag && !IHJGEFJOFKH && ammoLeftInClip <= 0)
				{
					Reload();
				}
				return flag;
			}
			return ammoLeft <= 0 && !HOGINLIFMLN;
		}
	}

	public virtual bool hasAmmoInClip
	{
		get
		{
			return ammoLeftInClip > 0;
		}
	}

	public virtual bool hasLowAmmo
	{
		get
		{
			return NAIKLJKNLAE && (float)(ammoLeft + ammoLeftInClip) / (float)(int)LCKNGBAEFCL < Singleton<GameVariables>.instance.bonussesDefinitions.GetRow(BonussesDefinitions.rowIds.LowAmmoRatio).FLOATVALUE;
		}
	}

	public virtual float reloadProgress
	{
		get
		{
			if (NAIKLJKNLAE)
			{
				if (BEMPMAPDIDH == 0f)
				{
					return 0f;
				}
				float num = Mathf.Clamp01((TimeManager.realTimeWithoutPauses - BEMPMAPDIDH) / (float)AMGFJFPKOED);
				if (IHJGEFJOFKH && num >= 1f)
				{
					DCDCGLDCOLA();
				}
				return num;
			}
			return nextShootProgress;
		}
	}

	public virtual float reloadingTimeLeft
	{
		get
		{
			if (NAIKLJKNLAE)
			{
				if (!IHJGEFJOFKH)
				{
					return 0f;
				}
				return (1f - reloadProgress) * (float)AMGFJFPKOED;
			}
			return (1f - nextShootProgress) * (float)JMDLKIAKOIE;
		}
	}

	public virtual float nextShootProgress
	{
		get
		{
			return 1f;
		}
	}

	public float lastShotTime
	{
		get
		{
			return NOFDHHLCEGM;
		}
	}

	public GHPGNELIDBM fraction
	{
		get
		{
			if (owner == null)
			{
				return GHPGNELIDBM.None;
			}
			return owner.fraction;
		}
		set
		{
			UnityEngine.Debug.LogError("Should not set fraction to weapon");
		}
	}

	public virtual KMHCMCBGFFC owner { get; set; }

	public bool ignoreTimeScale { get; set; }

	public static event JMPCJHIKJEO OnShotHit
	{
		add
		{
			JMPCJHIKJEO jMPCJHIKJEO = GMFFIENELHO;
			JMPCJHIKJEO jMPCJHIKJEO2;
			do
			{
				jMPCJHIKJEO2 = jMPCJHIKJEO;
				jMPCJHIKJEO = Interlocked.CompareExchange(ref GMFFIENELHO, (JMPCJHIKJEO)Delegate.Combine(jMPCJHIKJEO2, value), jMPCJHIKJEO);
			}
			while ((object)jMPCJHIKJEO != jMPCJHIKJEO2);
		}
		remove
		{
			JMPCJHIKJEO jMPCJHIKJEO = GMFFIENELHO;
			JMPCJHIKJEO jMPCJHIKJEO2;
			do
			{
				jMPCJHIKJEO2 = jMPCJHIKJEO;
				jMPCJHIKJEO = Interlocked.CompareExchange(ref GMFFIENELHO, (JMPCJHIKJEO)Delegate.Remove(jMPCJHIKJEO2, value), jMPCJHIKJEO);
			}
			while ((object)jMPCJHIKJEO != jMPCJHIKJEO2);
		}
	}

	public static event Action<Weapon, Vector3> OnShotFired
	{
		add
		{
			Action<Weapon, Vector3> action = NHLPPKAGIGF;
			Action<Weapon, Vector3> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NHLPPKAGIGF, (Action<Weapon, Vector3>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<Weapon, Vector3> action = NHLPPKAGIGF;
			Action<Weapon, Vector3> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref NHLPPKAGIGF, (Action<Weapon, Vector3>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		BLOHNLJOPIM = 0;
	}

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public virtual Ammo Fire(Vector3 IIMDKHJAJGO)
	{
		if (DebugSettings.stopShooting && owner != PlayerController.OGMBJPKOPCB)
		{
			return null;
		}
		Ammo ammo = null;
		if (willShoot)
		{
			ammo = MDKABJDCKBI(IIMDKHJAJGO, false);
			if (ammo != null)
			{
				PALEIBJMGGA(IIMDKHJAJGO);
			}
			if (NAIKLJKNLAE)
			{
				ammoLeftInClip--;
			}
			else
			{
				ammoLeft--;
			}
		}
		if (!hasAmmoInClip && NAIKLJKNLAE && hasAmmo)
		{
			Reload();
		}
		return ammo;
	}

	protected virtual void PALEIBJMGGA(Vector3 IIMDKHJAJGO)
	{
		if (!OLLIJPKAIFC && FEHCCGEGPLH != null && FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("FireNetworkRPC", PhotonTargets.Others, IIMDKHJAJGO, GGJPNLDIGGM, (byte)EBNMDKAEJAH);
		}
	}

	[PunRPC]
	public virtual void FireNetworkRPC(Vector3 IIMDKHJAJGO, bool HALDMAOGEOE, byte FJLBLLLEELD)
	{
		GGJPNLDIGGM = HALDMAOGEOE;
		EBNMDKAEJAH = (Ammo.ILIOELBBLDM)FJLBLLLEELD;
		MDKABJDCKBI(IIMDKHJAJGO, true);
	}

	protected virtual Ammo MDKABJDCKBI(Vector3 MPHCNMDIPAI, bool CAKABHIPCDF)
	{
		if (NHLPPKAGIGF != null)
		{
			NHLPPKAGIGF(this, MPHCNMDIPAI);
		}
		NOFDHHLCEGM = TimeManager.realTimeWithoutPauses;
		Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, EGNEIDMAEKA, ADMCKBPFNLO);
		return null;
	}

	protected void Update()
	{
		if (IHJGEFJOFKH && reloadProgress >= 1f)
		{
			DCDCGLDCOLA();
		}
	}

	private void DCDCGLDCOLA()
	{
		int num = Math.Min((int)FIMMGPLLLCL - ammoLeftInClip, (!HOGINLIFMLN) ? ammoLeft : ((int)FIMMGPLLLCL));
		ammoLeftInClip += num;
		ammoLeft -= num;
		BEMPMAPDIDH = 0f;
		IHJGEFJOFKH = false;
	}

	public void Reload()
	{
		if ((NAIKLJKNLAE || !IHJGEFJOFKH) && (ammoLeft > 0 || HOGINLIFMLN))
		{
			IHJGEFJOFKH = true;
			BEMPMAPDIDH = TimeManager.realTimeWithoutPauses;
			InvokeAfterRealTime(delegate
			{
				Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, GNKKBOADAEA);
			}, 0.5f);
		}
	}

	public virtual float ComputeFlyTimeToTarget(Vector3 MPHCNMDIPAI)
	{
		return 0f;
	}

	[PunRPC]
	public void SetBullletSpeedCoef(float BIHHPLAFAKG)
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("SetBullletSpeedCoef", PhotonTargets.Others, BIHHPLAFAKG);
		}
		BulletSetup bulletSetup = ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			bulletSetup.MJMACHBNICC = BIHHPLAFAKG;
		}
	}

	public void ReportShotHit(Ammo DBLOCECAGLP, Vector3 MPHCNMDIPAI, bool CAKABHIPCDF, DestroyableObject OJIHGNJFPFM)
	{
		bool flag = OJIHGNJFPFM != null && OJIHGNJFPFM.fraction != GHPGNELIDBM.None && OJIHGNJFPFM.fraction != PlayerController.OGMBJPKOPCB.fraction;
		if (!CAKABHIPCDF && owner == PlayerController.OGMBJPKOPCB && flag && Singleton<GameController>.instance.isPVP)
		{
			StatsManager.instance.matchStats.hits++;
		}
		if (GMFFIENELHO != null)
		{
			GMFFIENELHO(this, DBLOCECAGLP, MPHCNMDIPAI, CAKABHIPCDF, OJIHGNJFPFM);
		}
	}

	[CompilerGenerated]
	private void JIEFOCEGJND()
	{
		Singleton<SoundsManager3D>.instance.PlayOneShot(base.gameObject, GNKKBOADAEA);
	}
}
