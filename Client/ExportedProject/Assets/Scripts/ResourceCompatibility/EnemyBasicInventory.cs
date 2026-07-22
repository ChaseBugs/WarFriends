using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyBasicInventory : Core_BaseScript
{
	[Serializable]
	public class InventoryWeapon
	{
		public Weapon weapon;

		public Weapon.BAGDEMJGIOF type;

		public bool leftHand;

		public bool backpack;
	}

	private sealed class LNOLCJJDJPG : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public bool KBMNJEGOEIH;

		public EnemyBasicInventory HNNCIECPFEJ;

		public int[] DBMLGANKIOK;

		private List<InventoryWeapon> PPGELLEAICF;

		private int ODNCKNCGALA;

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
		public LNOLCJJDJPG(int HEIHBBOBLGF)
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

	public List<InventoryWeapon> FJJILDEABAH;

	public GameObject ENPBILNLGGE;

	public GameObject HNCKDDDCCOD;

	public GameObject NIMFKIDHJBJ;

	public List<InventoryWeapon> JLBHMECIJAN;

	public GameObject CBBJFEBHBJP;

	public GameObject EMCGKFKAIHA;

	[SerializeField]
	private bool mIsEliteShieldMaterialDifferent;

	[SerializeField]
	private Material mSecondShieldMaterial;

	[SerializeField]
	private Material mSecondShieldMaterialEnemy;

	private bool HCAEPLDBFMP;

	private SoldierParts MGKOIOIAEML;

	private List<Weapon> PKFBKJHCBDC;

	[CompilerGenerated]
	private int _003CKMOJJGKEEAO_003Ek__BackingField;

	private int[] EPJCPGHBODN;

	public Weapon currentWeapon => null;

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

	public List<Weapon> weaponInstancies => null;

	public void AttachShield(SoldierParts IHIBKBDPFKD, SoldierMeshChanger GCHENAODIKB, UpgradeSlots.UnitUpgrades BOCCHNDLCOJ, HPHFGNJPDKN LBHJBBKENEO = HPHFGNJPDKN.None, int BBJPHKDOMPN = -1)
	{
	}

	public Material GetWeaponMaterial()
	{
		return null;
	}

	public void SetWeaponMaterial(SoldierMeshChanger GCHENAODIKB, int DBJLKAGFEAG = -1)
	{
	}

	public void SetWeaponMaterial(Material AGMACLPLFMI)
	{
	}

	public void AttachBackpackTurret(UpgradeSlotsBreach HEBMDHGPGGF, SoldierParts IHIBKBDPFKD, SoldierMeshChanger GCHENAODIKB, EnemyController KHCNFGEADLB, int BBJPHKDOMPN = -1)
	{
	}

	public void AttachRemoteController(SoldierParts IHIBKBDPFKD, SoldierMeshChanger GCHENAODIKB, UpgradeSlots.UnitUpgrades BOCCHNDLCOJ)
	{
	}

	public List<Weapon> AttachAllWeapons(SoldierParts IHIBKBDPFKD, bool KILEBFLGIGN, SoldierMeshChanger GCHENAODIKB, EnemyController KHCNFGEADLB)
	{
		return null;
	}

	public List<Weapon> AttachAllWeapons(SoldierParts IHIBKBDPFKD, byte[] NNNIPBGHKFE, bool KILEBFLGIGN, SoldierMeshChanger GCHENAODIKB, UpgradeSlots.UnitUpgrades BOCCHNDLCOJ)
	{
		return null;
	}

	public void DestroyWeapons()
	{
	}

	public Weapon SwitchWeapon(int DBJLKAGFEAG, bool MOKJAIGOJKP = false)
	{
		return null;
	}

	public Weapon EnableSecondaryWeapon(int DBJLKAGFEAG)
	{
		return null;
	}

	public IEnumerator PrepareWeaponCoroutine(int[] DBMLGANKIOK, bool KBMNJEGOEIH)
	{
		return null;
	}

	public void SetWeaponsUpgrade(int[] EAJHKAPGADG)
	{
	}

	public void SetOwner(IBFMOMDLFEP JFFNCLJBGLM)
	{
	}
}
