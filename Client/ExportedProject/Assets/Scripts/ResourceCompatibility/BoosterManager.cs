using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Scripting;

public class BoosterManager : DatabaseSerializedObjectGeneric<BoosterManager.BoosterData>
{
	public enum EBLCALOMCNP
	{
		WeaponPrimary,
		WeaponSpecial,
		WeaponExplosive,
		WeaponPistol,
		UnitDefender,
		UnitShooter,
		UnitRusher,
		UnitExplosive,
		None
	}

	[Preserve]
	public class BoosterData
	{
		public Dictionary<EBLCALOMCNP, Dictionary<string, int>> boosterInventory;

		public string PrintBoosterInventory()
		{
			return null;
		}
	}

	private static BoosterManager DJDBDKFAKHN;

	[CompilerGenerated]
	private Action BDNIMFJDNAB;

	[CompilerGenerated]
	private Action PPGNCGHDPAE;

	public bool HLHKOCOEPIN;

	public bool DPLHNOFKPNA;

	public string GDHEJFDLPEE;

	private BoosterLevels GJEBDKOKEJL;

	public readonly Dictionary<int, Color> FHKNJNJJNJJ;

	public bool IsBoostersUnlocked => false;

	public bool IsAdBoostersUnlocked => false;

	public static BoosterManager instance => null;

	public event Action BoosterInProgress
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action BoosterNotReady
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected override void Awake()
	{
	}

	public void SetBoosterInProgress()
	{
	}

	public void SetBoosterNotReady()
	{
	}

	public int GetBoosterAmount(EBLCALOMCNP ALEJAIIFMJN, int DBMLGANKIOK)
	{
		return 0;
	}

	public int GetTimeAmount(int DBMLGANKIOK)
	{
		return 0;
	}

	public void AddBooster(EBLCALOMCNP JFACCKJNHHC, int DBMLGANKIOK, int CKFPFCJDBJK)
	{
	}

	public void ConsumeBooster(string AOCDKEILCLP, EBLCALOMCNP JFACCKJNHHC, int DBMLGANKIOK, bool DFGALPCAKGA)
	{
	}

	public void ScheduleBoosterNotifications()
	{
	}
}
