using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerWeapon : Core_BaseScript, TimeScaleIgnorable
{
	private sealed class GLKGNDFDJOI : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public PlayerWeapon HNNCIECPFEJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public GLKGNDFDJOI(int HEIHBBOBLGF)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public string LMBBOKMEPGI;

	public string AMDHJAEJJGP;

	public CameraPlayerFollow.ThirdPersoncameraDefinition MHJDIIAIFMJ;

	public float EMBGJHLOFEA;

	[CompilerGenerated]
	private PlayerController _003CLCKADKMAIHC_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CNMFAHAGGHME_003Ek__BackingField;

	public bool GMFMKLNJGLP;

	protected GameObject INDBMFNBCEO;

	private static Dictionary<string, GameObject> EGNCGBFLGOD;

	private Weapon CGEPFKGPOKE;

	private bool BOKLAMIBBKC;

	private PlayerInventory.InventorySlot NBIDNOLAPPG;

	public string HFJKJDPBHDM;

	private WeaponLevelsSetup CMPAJDIMOLN;

	public PlayerController playerController
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public bool isEnabled
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

	public virtual bool isActiveWeapon
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Weapon weapon
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool ignoreTimeScale
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public WeaponLevelsSetup weaponLevelSetup
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public IEnumerator LoadWeapon()
	{
		return null;
	}

	public virtual void DestroyModel()
	{
	}

	public static void ClearModels()
	{
	}

	public virtual void UpdateWeapon()
	{
	}

	public virtual void UpdateInactiveWeapon()
	{
	}

	public virtual void MouseUpAndNoUpdate()
	{
	}

	public virtual void ShootForBot(Vector3 MPHCJEIMBEB)
	{
	}

	protected void ODPLHALBCCH()
	{
	}

	protected void AIJBIDKMODP(Vector3 PBLDMECEKCL)
	{
	}

	protected bool COAJBDDMCPE(Vector3 OIMMJIGPNDK)
	{
		return false;
	}

	public bool IsLoaded()
	{
		return false;
	}
}
