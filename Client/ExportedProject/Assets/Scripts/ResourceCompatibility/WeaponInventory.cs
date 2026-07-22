using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class WeaponInventory : Core_BaseScript
{
	private sealed class KBNMKGOMIEJ : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public WeaponInventory HNNCIECPFEJ;

		private List<PlayerWeapon>.Enumerator CAMJLFPMEAJ;

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
		public KBNMKGOMIEJ(int HEIHBBOBLGF)
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

		private void LOGNGHDBDGO()
		{
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	public List<PlayerWeapon> BJNGDLKPCGO;

	public Mine KIEBFLLGIKA;

	public int AFPKPACMMMN;

	public List<PlayerWeapon> HONKCGJEGGC;

	public List<int> PADGIHFOPMD;

	private PhotonView IBBJLFJLAFA;

	private PlayerController DHMBJIFPHPE;

	[CompilerGenerated]
	private int _003CKMOJJGKEEAO_003Ek__BackingField;

	[CompilerGenerated]
	private Action<PlayerWeapon> NHHJHIMBOBL;

	private bool EGAAEHAMFLD;

	public bool DDDCIDLOLLK;

	public bool AAOOCMEFCOD;

	public float HOBDBJKGODK;

	public int weaponIndex
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public PlayerWeapon pistol => null;

	public PlayerWeapon currentWeapon
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool cannotChange
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public event Action<PlayerWeapon> SelectedWeaponChanged
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

	public void SetCurrentWeapon(PlayerWeapon HHDCBKDKICG)
	{
	}

	protected override void Awake()
	{
	}

	private void CFDFPBPCELA()
	{
	}

	private void CABEHPEGFBI()
	{
	}

	private void OCPKLCBHEEJ(byte[] NNNIPBGHKFE)
	{
	}

	public void SetWeapons(PlayerInventory.EquippedWeapon[] CJGKBEMPDAI)
	{
	}

	public void InitializeWeaponPhotonViews()
	{
	}

	[PunRPC]
	private void ChangeWeapon(byte DBJLKAGFEAG)
	{
	}

	public IEnumerator LoadWeapons()
	{
		return null;
	}

	public void SetUpPlayer(PlayerController EGJCNDAINGF)
	{
	}

	private void JNDLDGEPFAK(Weapon AEBEOCBIBFI, int JMLOFFNFAPJ, bool PDMDEIKLCIH)
	{
	}

	public void CleanupWeapons()
	{
	}

	public void SetupPhotonViews(bool PDMDEIKLCIH)
	{
	}
}
