using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class SoldierBehaviour : LevelBehaviour
{
	private sealed class AIECPHCOAHH : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public bool OHOPOOEPMNP;

		public SoldierBehaviour HNNCIECPFEJ;

		public UpgradeSlots.UnitUpgrades BOCCHNDLCOJ;

		public bool EGLHKFKNOLI;

		public bool IAKHPLFOJBI;

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
		public AIECPHCOAHH(int HEIHBBOBLGF)
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

	private sealed class MKMMAELEDJC : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int HEIHBBOBLGF;

		private object BDGCJCKMMEF;

		public SoldierBehaviour HNNCIECPFEJ;

		public bool EGLHKFKNOLI;

		public bool MDBHKJFOGLL;

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
		public MKMMAELEDJC(int HEIHBBOBLGF)
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

	public bool MOKJAIGOJKP;

	public List<SoldierMeshChanger.SoldierStyle> HNEJBPPKBGE;

	public List<SoldierMeshChanger.SoldierStyle> NOPIHCOBGEH;

	public List<SoldierMeshChanger.SoldierStyle> JEOEGCBGJDJ;

	public EnemyPoint.JMLFBBNOMMH FIFFNFMADMA;

	public SpawnPoint.MPKDDOPKKHJ GGAAAKAJIED;

	public Material GEKEKMOLNFO;

	public SoldierParts MGKOIOIAEML;

	protected EnemyBasicInventory ILEBDICBFOM;

	private NavigationAgent CFGGOIGLJCO;

	public EnemyController NBBEEENLPEA;

	public Weapon PIFHJDGIBNM;

	protected Ammo.BICKHONNMCG FGKGKPHFHEL;

	protected int MLFCLICJKMG;

	protected int JDGMPEJGHID;

	protected PhotonView IBBJLFJLAFA;

	[CompilerGenerated]
	private SoldierBehaviourDefinititon _003CNFPABLCKAPI_003Ek__BackingField;

	protected BitVector32 DJHJLBFHPDL;

	public Vector3 PNOJBGAFKLA;

	protected bool CFNJOCFGDFL;

	protected bool PJCOHJOOGCN;

	private bool BEKCLPCJHOI;

	protected List<Weapon> JNPIBBDLCNI;

	protected bool NFEKJBOOGPJ;

	protected GameShootableEntity.ShotTarget PANBJBCFEJB;

	protected SoldierMeshChanger KEDJCABNFDJ => null;

	public List<Weapon> allWeapons => null;

	public SoldierBehaviourDefinititon soldierBehaviourDefinititon
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual SoldierBehaviourDefinititon soldierBaseDefinition
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

	protected bool JLHNMIJJOKB => false;

	protected override void Awake()
	{
	}

	public virtual void UpdateVisual()
	{
	}

	public override IEnumerator PrepareVisualsForGameCoroutine(UpgradeSlots.UnitUpgrades BOCCHNDLCOJ, bool OHOPOOEPMNP, bool EGLHKFKNOLI, bool IAKHPLFOJBI = false)
	{
		return null;
	}

	protected virtual int[] PDNMIAHFLLH(UpgradeSlots.UnitUpgrades BOCCHNDLCOJ)
	{
		return null;
	}

	protected virtual int[] GIDJKMLDFMJ()
	{
		return null;
	}

	public override IEnumerator PrepareVisualsForCardCoroutine(bool EGLHKFKNOLI, bool MDBHKJFOGLL)
	{
		return null;
	}

	protected void CCOKKPGHMHN(bool ADJANLFJEAO = false)
	{
	}

	public override void Init(AIObject FKJGHEFHPKE)
	{
	}

	public virtual bool AcceptsPoint(EnemyPoint KFFIDHDOBPA)
	{
		return false;
	}

	public virtual bool AcceptSpawnPoint(SpawnPoint KFFIDHDOBPA)
	{
		return false;
	}

	public SpawnPoint PickNormalSPawn(IEnumerable<SpawnPoint> IFDBPBHMNKD)
	{
		return null;
	}

	public virtual SpawnPoint PickSpawnPoint(IEnumerable<SpawnPoint> IFDBPBHMNKD)
	{
		return null;
	}

	public virtual EnemyPoint GetNewEnemyPoint(EnemyPoint AOMGAIKICNG)
	{
		return null;
	}

	public virtual EnemyPoint GetInitPoint()
	{
		return null;
	}

	public virtual void PickTarget()
	{
	}

	public void SwitchWeapon(bool BNLPFPFIPFE, bool MOKJAIGOJKP = false)
	{
	}

	protected virtual void KLLJKOEGIIG(Vector3 MPHCJEIMBEB, bool HKGICFLDIHH)
	{
	}

	protected virtual void IENKODKHNOG()
	{
	}

	public virtual bool StartShooting()
	{
		return false;
	}

	protected virtual int NGPLCFCCPIC()
	{
		return 0;
	}

	public virtual void ShootJustStarted()
	{
	}

	public void StartShootingNetworkRPC(Vector3 MPHCJEIMBEB, int JJPNIPKHCGJ, bool KMKNPEHKLMI, byte HIMACIIHLDE, byte JPNOFLJNGNF)
	{
	}

	protected override void Update()
	{
	}

	public virtual void Shooting()
	{
	}

	protected virtual void GPONMMAPJDA()
	{
	}

	public virtual void Restart()
	{
	}

	protected void LIBIJPDKGIM()
	{
	}

	protected virtual void DEKOLCBBMAM()
	{
	}

	public override void ReSync()
	{
	}

	[PunRPC]
	protected virtual void AttachWeaponsRPC(byte[] NNNIPBGHKFE)
	{
	}

	public void ImproveAllWeapons(float KGHCOGCIEKJ)
	{
	}

	public override void DestroyBehaviour()
	{
	}

	protected void PNPOCGLJJLG(UnitType AHCLLPDBLGB, GameShootableEntity.GGDNGONEKLD BDHPCNDEBBC = GameShootableEntity.GGDNGONEKLD.AllIn)
	{
	}

	protected void NBBDBOPNHBA(UnitType AHCLLPDBLGB, GameShootableEntity.GGDNGONEKLD BDHPCNDEBBC = GameShootableEntity.GGDNGONEKLD.AllIn)
	{
	}

	protected void PNPOCGLJJLG()
	{
	}

	protected bool CHEOOJGGGFE()
	{
		return false;
	}

	protected Ammo.BICKHONNMCG IGCDHCLKLPD(GameShootableEntity.ShotTarget LGFMBOJMMMB)
	{
		return default(Ammo.BICKHONNMCG);
	}

	protected virtual void MMADMBGHPFI(float EOBDELGAKJF = 0.5f)
	{
	}

	public virtual void StartEnemyBehaviour()
	{
	}

	public virtual void OnDeath(DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	public override void Unload()
	{
	}

	public virtual void StandShoot()
	{
	}

	private List<SoldierMeshChanger.SoldierStyle> CNJKJAHDGLK(UpgradeSlots.UnitUpgrades IDHKHECHPHJ)
	{
		return null;
	}

	public virtual float GetNextShotTime()
	{
		return 0f;
	}

	public virtual void OnDamage(DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
	}

	[CompilerGenerated]
	[DebuggerHidden]
	private IEnumerator GDPLJEIBFPN(UpgradeSlots.UnitUpgrades BOCCHNDLCOJ, bool OHOPOOEPMNP, bool EGLHKFKNOLI, bool IAKHPLFOJBI)
	{
		return null;
	}

	[DebuggerHidden]
	[CompilerGenerated]
	private IEnumerator EEFEMCMBNED(bool EGLHKFKNOLI, bool MDBHKJFOGLL)
	{
		return null;
	}

	[CompilerGenerated]
	private void KIEFMPPPKNH()
	{
	}

	[CompilerGenerated]
	private bool LBPKKOJGDHM(GameShootableEntity CLMNCBPINKO)
	{
		return false;
	}

	[CompilerGenerated]
	private bool GJJDHJFMOCP(GameShootableEntity CLMNCBPINKO)
	{
		return false;
	}

	[CompilerGenerated]
	private bool AHMAEDIDFCH(GameShootableEntity CLMNCBPINKO)
	{
		return false;
	}

	[CompilerGenerated]
	private bool GPHKBFOMEFB(GameShootableEntity CLMNCBPINKO)
	{
		return false;
	}
}
