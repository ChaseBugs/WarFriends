using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MainGameEntity, TimeScaleIgnorable, NKMKCCDCHCL, KMNCIJPDFPJ, KMHCMCBGFFC
{
	public enum KKPHPLOEACG
	{
		HidingBehindShield = 0,
		Walking = 1,
		WalkingToNewlevel = 2
	}

	private sealed class CIPJHJJKJMF
	{
		internal MapDefinition.DefendPosition MPHCNMDIPAI;

		internal PlayerController BJGCPDNMHDH;

		internal void LHPPLGOOLEC()
		{
			BJGCPDNMHDH.ONOLBDPIOND.CAGPIECMNFF(MPHCNMDIPAI.point.transform.position);
		}

		internal void BDCAFHOHEGM()
		{
			BJGCPDNMHDH.ONOLBDPIOND.CAGPIECMNFF(MPHCNMDIPAI.point.transform.position);
		}

		internal void MMEEJDGGAID()
		{
			BJGCPDNMHDH.ONOLBDPIOND.CAGPIECMNFF(MPHCNMDIPAI.point.transform.position);
		}

		internal void OKNCFDMEFGJ()
		{
			BJGCPDNMHDH.ONOLBDPIOND.SetDestination(MPHCNMDIPAI.point.transform.position);
		}

		internal void KNJBDOADLDO()
		{
			BJGCPDNMHDH.ONOLBDPIOND.CAGPIECMNFF(MPHCNMDIPAI.point.transform.position);
		}

		internal void AMIJFGBOCLC()
		{
			BJGCPDNMHDH.ONOLBDPIOND.SetDestination(MPHCNMDIPAI.point.transform.position);
		}

		internal void ECPMEMNKMCB()
		{
			BJGCPDNMHDH.ONOLBDPIOND.SetDestination(MPHCNMDIPAI.point.transform.position);
		}

		internal void CIFEDFPPPOK()
		{
			BJGCPDNMHDH.ONOLBDPIOND.CAGPIECMNFF(MPHCNMDIPAI.point.transform.position);
		}

		internal void NAJNECOMDDN()
		{
			BJGCPDNMHDH.ONOLBDPIOND.CAGPIECMNFF(MPHCNMDIPAI.point.transform.position);
		}

		internal void MCFGAFBEJDK()
		{
			BJGCPDNMHDH.ONOLBDPIOND.CAGPIECMNFF(MPHCNMDIPAI.point.transform.position);
		}

		internal void MPHECHCFCAN()
		{
			BJGCPDNMHDH.ONOLBDPIOND.CAGPIECMNFF(MPHCNMDIPAI.point.transform.position);
		}

		internal void FIBGJHCGHJH()
		{
			BJGCPDNMHDH.ONOLBDPIOND.CAGPIECMNFF(MPHCNMDIPAI.point.transform.position);
		}

		internal void LJCDGJKCNEC()
		{
			BJGCPDNMHDH.ONOLBDPIOND.SetDestination(MPHCNMDIPAI.point.transform.position);
		}

		internal void KJIFNOJILDB()
		{
			BJGCPDNMHDH.ONOLBDPIOND.CAGPIECMNFF(MPHCNMDIPAI.point.transform.position);
		}

		internal void MFCNOIDCJME()
		{
			BJGCPDNMHDH.ONOLBDPIOND.SetDestination(MPHCNMDIPAI.point.transform.position);
		}
	}

	public static PlayerController OGMBJPKOPCB;

	public static Dictionary<int, PlayerController> JFGDAKMCJAM = new Dictionary<int, PlayerController>();

	public CKDIHNEIHKL LMIHBNGHEHM;

	public List<AimTarget> FMLNJGIHJOK;

	public DestroyableObjectPlayer FOCIOKMPCAG;

	public bool KPIGIEPMLLC;

	private Material DNBEAILMLLJ;

	public PhotonView FEHCCGEGPLH;

	private KKPHPLOEACG JDNNOGPNJLO;

	public SoldierParts EFFIOHJHFHI;

	public int NAGAHNHAKBJ;

	public CHEIFOOIMEH EHHHBEMKGOE = new CHEIFOOIMEH();

	public AimTarget JEHDCCKBPPD;

	public KinematicRagdoll KCGNHJOLNKD;

	[SerializeField]
	private SoldierMeshChanger mMeshChanger;

	public PlayerBot JPMHIGNOPBL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<KKPHPLOEACG> KCECODPHBLE;

	public float AGOGEJNFGEL;

	private static readonly List<PlayerController> PCPBIGOAFPL = new List<PlayerController>();

	public bool JODNNABEFDH;

	public bool COHFDCGJECK;

	public bool GIDLKCONHAC;

	private GameObject PAGPNMNPOIA;

	private MapDefinition.DefendPosition CNAOOPEKADN;

	public GHPGNELIDBM ODCLPMADGFC = GHPGNELIDBM.Enemies;

	private bool DHIDLFAHOFJ;

	private bool HHHOOCKBIOL;

	private MapDefinition.DefendPosition LJPNJJFBMCD;

	private float EEJMNMHBFEN;

	private bool KFLMDLBIMHG;

	private float BJAPCEOFJBJ;

	private Vector3 DJODBMGLPDE;

	private int? IJDHJJFOKIO;

	private SkinnedMeshRenderer HFKEGLEPEFD;

	private Vector3 NJKAHEOPIDD;

	private bool DOMGOLBDMBN;

	private Transform NGCDDPCAGJB;

	private Quaternion FBDGMKGIBNO;

	private LHMCMJDDOHI LADBLHGBOKJ = new LHMCMJDDOHI();

	private float ELFBJCLMKDN;

	public bool JFECKJEDJNJ;

	public float EAOOLOIHKPP = 1f;

	public bool KIIHLIPAGIH;

	public bool CDBNKOPKCJB;

	public float OPCGNNFGFOD = 1f;

	public List<Collider> DDGBIBMPEOE;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> FJHBCIAKBPF;

	private bool FMGIFEFLLBH;

	public bool FAOHFEPIFGJ = true;

	private NavigationAgent ONOLBDPIOND;

	private float FHPMANHKAIO;

	public WeaponInventory weaponInventory { get; private set; }

	public SoldierAnimationController soldierAnimator { get; private set; }

	public GameShootableEntity gameShootableEntity { get; private set; }

	public bool clicked { get; private set; }

	public MapDefinition.DefendPosition currentPlayerPoint
	{
		get
		{
			return CNAOOPEKADN;
		}
		set
		{
			if (CNAOOPEKADN != null && CNAOOPEKADN.point.shield != null)
			{
				CNAOOPEKADN.point.shield.player = null;
			}
			CNAOOPEKADN = value;
			if (CNAOOPEKADN != null && CNAOOPEKADN.point.shield != null)
			{
				CNAOOPEKADN.point.shield.player = this;
			}
		}
	}

	public bool isImmortal
	{
		get
		{
			return FOCIOKMPCAG.isImmortal;
		}
		set
		{
			FOCIOKMPCAG.isImmortal = value;
		}
	}

	public float weaponReloadCoef { get; set; }

	public float speed
	{
		get
		{
			return ONOLBDPIOND.speed;
		}
		set
		{
			ONOLBDPIOND.speed = value;
		}
	}

	public KKPHPLOEACG playerState
	{
		get
		{
			return JDNNOGPNJLO;
		}
		private set
		{
			if (JDNNOGPNJLO != value)
			{
				JDNNOGPNJLO = value;
				if (KCECODPHBLE != null)
				{
					KCECODPHBLE(value);
				}
			}
		}
	}

	public Vector3 position
	{
		get
		{
			return NGCDDPCAGJB.position;
		}
	}

	public Vector3 aimForward
	{
		get
		{
			if (currentPlayerPoint == null || currentPlayerPoint.point == null)
			{
				return -NGCDDPCAGJB.forward;
			}
			return -currentPlayerPoint.point.transform.forward;
		}
	}

	public Vector3 aimToMiddleOfMap
	{
		get
		{
			if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG != null)
			{
				Vector3 vector = Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG.position - NGCDDPCAGJB.position;
				float num = GeometryTools.AngleSigned(vector, aimForward, Vector3.up);
				if (num > 15f)
				{
					return Quaternion.AngleAxis(15f, -Vector3.up) * aimForward;
				}
				if (num < -15f)
				{
					return Quaternion.AngleAxis(-15f, -Vector3.up) * aimForward;
				}
				return vector;
			}
			return base.transform.forward;
		}
	}

	public bool isCurrentPlayer
	{
		get
		{
			return OGMBJPKOPCB == this;
		}
	}

	public override GHPGNELIDBM fraction
	{
		get
		{
			return ODCLPMADGFC;
		}
		set
		{
			if (fraction != value)
			{
				ODCLPMADGFC = value;
			}
			ODDDGIALOPM(ODCLPMADGFC);
		}
	}

	public override KMHCMCBGFFC owner
	{
		get
		{
			return this;
		}
		set
		{
		}
	}

	public override int power { get; set; }

	public bool ignoreTimeScale
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public override DestroyableObject destroyableObj
	{
		get
		{
			return FOCIOKMPCAG;
		}
	}

	public SoldierMeshChanger meshChanger
	{
		get
		{
			return mMeshChanger;
		}
	}

	public string[] playerVisuals
	{
		get
		{
			return EHHHBEMKGOE.CBBDICBLHMM;
		}
		set
		{
			EHHHBEMKGOE.CBBDICBLHMM = value;
		}
	}

	public PlayerVisualCategoryCamos.PlayerVisualCamo equippedCamo
	{
		get
		{
			return EHHHBEMKGOE.NHOJPACPJEO;
		}
		set
		{
			EHHHBEMKGOE.NHOJPACPJEO = value;
		}
	}

	public PlayerVisualCategoryHelmets.PlayerVisualHelmet equippedHelmet
	{
		get
		{
			return EHHHBEMKGOE.POHFJHBABAF;
		}
		set
		{
			EHHHBEMKGOE.POHFJHBABAF = value;
		}
	}

	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory equippedHeadAccesory
	{
		get
		{
			return EHHHBEMKGOE.IPJIPGILEHF;
		}
		set
		{
			EHHHBEMKGOE.IPJIPGILEHF = value;
		}
	}

	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand equippedPowerBand
	{
		get
		{
			return EHHHBEMKGOE.EOHJMNFLAIK;
		}
		set
		{
			EHHHBEMKGOE.EOHJMNFLAIK = value;
		}
	}

	public event Action<KKPHPLOEACG> PlayerStateChanged
	{
		add
		{
			Action<KKPHPLOEACG> action = KCECODPHBLE;
			Action<KKPHPLOEACG> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KCECODPHBLE, (Action<KKPHPLOEACG>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<KKPHPLOEACG> action = KCECODPHBLE;
			Action<KKPHPLOEACG> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KCECODPHBLE, (Action<KKPHPLOEACG>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public override event Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> Killed
	{
		add
		{
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
			Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private Vector3 DPKEOKAIDNB(Vector3 MPHCNMDIPAI)
	{
		NavMeshHit hit;
		if (NavMesh.SamplePosition(MPHCNMDIPAI, out hit, 997f, 1))
		{
			return hit.position;
		}
		return MPHCNMDIPAI;
	}

	private void ODDDGIALOPM(GHPGNELIDBM CIOPAKLHFIL)
	{
		int fractionBulletLayer = Singleton<TagsAndLayers>.instance.GetFractionBulletLayer(CIOPAKLHFIL, false);
		SetLayerRecursively(KCGNHJOLNKD.gameObject, fractionBulletLayer);
	}

	public void InitPlayer()
	{
		speed = 1f;
		weaponInventory.HKGLMFFAHFN = false;
		EHHHBEMKGOE.KJOICDPDOPB();
		soldierAnimator.SetTPose();
		foreach (Collider item in DDGBIBMPEOE)
		{
			item.enabled = false;
		}
		DestroyableObjectpart[] aMEELJHHGKP = FOCIOKMPCAG.AMEELJHHGKP;
		foreach (DestroyableObjectpart destroyableObjectpart in aMEELJHHGKP)
		{
			destroyableObjectpart.GetComponent<Collider>().enabled = true;
		}
		EFFIOHJHFHI.OFBEAKDOCIO.gameObject.SetActive(true);
		EFFIOHJHFHI.DGHPFMPMAFC.Swap(false);
		GetComponent<Kevlar>().ClearKevlar();
		weaponInventory.LIEDNEJPLMA = 0;
		DJODBMGLPDE = Vector3.zero;
		if (DNBEAILMLLJ != null)
		{
			HFKEGLEPEFD.material = DNBEAILMLLJ;
		}
		if (FOCIOKMPCAG.GPLNJOPPKIM != null)
		{
			FOCIOKMPCAG.GPLNJOPPKIM.Disable();
		}
		KPIGIEPMLLC = false;
		KIIHLIPAGIH = false;
		weaponReloadCoef = 1f;
		OPCGNNFGFOD = 1f;
		EAOOLOIHKPP = 1f;
		soldierAnimator.Reset();
		weaponInventory.SetWeapons(EHHHBEMKGOE.GGKGGMNIDMI);
		CamosManager.instance.ApplyVisuals(this, EHHHBEMKGOE.CBBDICBLHMM, true);
		FOCIOKMPCAG.maxHealth = Singleton<GameController>.instance.mainController.GetPlayerHP(this) * EAOOLOIHKPP;
		if (isCurrentPlayer || FEHCCGEGPLH.isMine)
		{
			UnityEngine.Debug.Log("SET HP: " + FOCIOKMPCAG.maxHealth + "name: " + EHHHBEMKGOE.MHPNDNJDPGE);
			FOCIOKMPCAG.Refill();
		}
		else
		{
			FOCIOKMPCAG.RefillOffline();
		}
		base.isAlive = true;
		EFFIOHJHFHI.SetAllRigidBodiesToKinematic(true);
		KCGNHJOLNKD.ResetRagdoll();
		soldierAnimator.Enable();
		soldierAnimator.Reset();
		soldierAnimator.Idle(Weapon.IGGFMJAKLGO.Riffle);
		soldierAnimator.lookBack = true;
		CDBNKOPKCJB = true;
		JODNNABEFDH = true;
		FAOHFEPIFGJ = true;
		ONOLBDPIOND.Stop();
		ONOLBDPIOND.Reset();
		playerState = KKPHPLOEACG.HidingBehindShield;
		KFLMDLBIMHG = false;
		BJAPCEOFJBJ = 0f;
		if (currentPlayerPoint != null && currentPlayerPoint.point.shield != null)
		{
			currentPlayerPoint.point.shield.player = this;
		}
		if (isCurrentPlayer)
		{
			UICamera.genericEventHandler = base.gameObject;
		}
		foreach (PlayerWeapon item2 in weaponInventory.KCGKDDDNONB)
		{
			item2.ignoreTimeScale = true;
		}
		foreach (AimTarget item3 in FMLNJGIHJOK)
		{
			item3.gameObject.SetActive(!isCurrentPlayer);
		}
		JEHDCCKBPPD.gameObject.SetActive(isCurrentPlayer);
		FOCIOKMPCAG.healthbarColor = ((OGMBJPKOPCB.fraction == fraction) ? Color.green : Color.red);
		EEJMNMHBFEN = -1f;
		KJMFJFCDEDH.Show(false);
		AGOGEJNFGEL = 0f;
		isImmortal = false;
		base.isAlive = true;
		JPMHIGNOPBL.enabled = false;
		ONOLBDPIOND.Disable();
		KJMFJFCDEDH.Reset();
		JFECKJEDJNJ = false;
		COHFDCGJECK = false;
		LMIHBNGHEHM.EIPHAAGCHCP = true;
		LADBLHGBOKJ.ILOHAHFIOKM();
	}

	public void PBDOMHCOGKM(byte JMMJHCOKCGG, bool DNDCODMGGEE)
	{
		if (BIEONCCPBIL() == KKPHPLOEACG.HidingBehindShield)
		{
			switch (JMMJHCOKCGG)
			{
			case 0:
				soldierAnimator.GDCFMBNGOBL(DNDCODMGGEE, ignoreTimeScale);
				break;
			case 8:
				GFCDMMGDFJK().ShootFromBazoka(DNDCODMGGEE, true, 503f);
				break;
			default:
				GFCDMMGDFJK().ShotFromCover(DNDCODMGGEE, 1748f, 720f, true, (Weapon.IGGFMJAKLGO)JMMJHCOKCGG);
				break;
			}
		}
		if (playerState == KKPHPLOEACG.Walking)
		{
			switch (JMMJHCOKCGG)
			{
			case 1:
				GFCDMMGDFJK().GDCFMBNGOBL(!DNDCODMGGEE, KAGFCHIAKLG());
				break;
			case 8:
				GFCDMMGDFJK().ShootFromBazokaWalk();
				break;
			default:
				GFCDMMGDFJK().ShootStandAdditive(1071f);
				break;
			}
		}
	}

	public MapDefinition.DefendPosition GoLeft()
	{
		if (currentPlayerPoint != null)
		{
			return GoLeft(currentPlayerPoint);
		}
		return null;
	}

	public bool AONLENLHDMD()
	{
		return FOCIOKMPCAG.healthRatio <= 167f;
	}

	[SpecialName]
	public void AJEONFFLKHG(Action<KKPHPLOEACG> IDEBKDPMPGM)
	{
		Action<KKPHPLOEACG> action = KCECODPHBLE;
		Action<KKPHPLOEACG> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KCECODPHBLE, (Action<KKPHPLOEACG>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void EIMEBEABDHF(Weapon.IGGFMJAKLGO JMMJHCOKCGG, bool DNDCODMGGEE, Vector3 PLEBANKIBPP)
	{
		PLEBANKIBPP.y = 1170f;
		if (BIEONCCPBIL() == KKPHPLOEACG.HidingBehindShield)
		{
			switch (JMMJHCOKCGG)
			{
			case Weapon.IGGFMJAKLGO.Riffle:
				soldierAnimator.GDCFMBNGOBL(!DNDCODMGGEE, true);
				GFCDMMGDFJK().LookAt(PLEBANKIBPP, 396f);
				break;
			case Weapon.IGGFMJAKLGO.SwatPistol:
				soldierAnimator.ShootFromBazoka(DNDCODMGGEE, false, 1967f);
				GFCDMMGDFJK().LookAt(PLEBANKIBPP, 1879f);
				break;
			default:
				soldierAnimator.ShotFromCover(DNDCODMGGEE, 1034f, 664f, true, JMMJHCOKCGG);
				soldierAnimator.LookAt(PLEBANKIBPP, 1390f);
				break;
			}
		}
		if (playerState == KKPHPLOEACG.HidingBehindShield)
		{
			switch (JMMJHCOKCGG)
			{
			case Weapon.IGGFMJAKLGO.Riffle:
				soldierAnimator.GDCFMBNGOBL(DNDCODMGGEE, ignoreTimeScale);
				soldierAnimator.LookAtUpperBody(PLEBANKIBPP, 1962f);
				break;
			case Weapon.IGGFMJAKLGO.Tool:
				soldierAnimator.ShootFromBazokaWalk();
				soldierAnimator.LookAt(PLEBANKIBPP, 242f);
				break;
			default:
				soldierAnimator.ShootStandAdditive(1606f, false);
				GFCDMMGDFJK().LookAtUpperBody(PLEBANKIBPP, 569f);
				break;
			}
		}
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[5];
			array[0] = (byte)JMMJHCOKCGG;
			array[0] = DNDCODMGGEE;
			fEHCCGEGPLH.RPC("ID_GUI_LEAGUEBONUS", PhotonTargets.All, array);
		}
	}

	private void CGGEOPENPBH(bool NCMHGPNPEJM)
	{
	}

	public MapDefinition.DefendPosition LMIIKJMGCIA(MapDefinition.DefendPosition PLMMBKGLGAB)
	{
		if (JFECKJEDJNJ || !base.isAlive || !Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			return null;
		}
		HHHOOCKBIOL = true;
		DHIDLFAHOFJ = true;
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.BMPBPOGCGGF();
		int num = 0;
		for (num = 1; num < list.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = list[num];
			if (defendPosition == PLMMBKGLGAB)
			{
				break;
			}
		}
		if (num > 1)
		{
			for (int num2 = num - 0; num2 >= 1; num2 -= 0)
			{
				if (list[num2].fraction == fraction && list[num2].point.IGEDGCNJCAP().FCBGHBODHHP() == null)
				{
					DHIDLFAHOFJ = true;
					LJPNJJFBMCD = list[num2];
					LJPNJJFBMCD.point.IGEDGCNJCAP().PNICBKAKEHO();
					CODLCIPGHMI(LJPNJJFBMCD, 329f);
					return LJPNJJFBMCD;
				}
			}
		}
		HOAGNCIKKDD(-1);
		return null;
	}

	protected virtual void JFDOGLFMHAE()
	{
		base.Awake();
		JEHDCCKBPPD.POJELIKFDPO = true;
		JEHDCCKBPPD.HADEAAMDKAI(KMOLMCEBCAI);
		soldierAnimator = GetComponentInChildren<SoldierAnimationController>();
		ONOLBDPIOND = GetComponent<NavigationAgent>();
		BJGHPPPAJGH(GetComponentInChildren<WeaponInventory>());
		EFFIOHJHFHI = GetComponent<SoldierParts>();
		gameShootableEntity = GetComponent<GameShootableEntity>();
		JLMDEMFIHCA().LBHNGCFACKH(this);
		FOCIOKMPCAG.OnDeath += FHEMDCFGMMF;
		FOCIOKMPCAG.OnDamage += EKDKBACABCK;
		ODDDGIALOPM(ODCLPMADGFC);
		JDNNOGPNJLO = KKPHPLOEACG.HidingBehindShield;
		Singleton<GameController>.instance.GameStarted += MCJHKKOMHAE;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		NGCDDPCAGJB = base.transform;
		FMKGGADDHJK().LGAGDHLMABF(AKJMMIGGKFG);
		PhotonView[] componentsInChildren = GetComponentsInChildren<PhotonView>(false);
		PhotonView[] array = componentsInChildren;
		foreach (PhotonView photonView in array)
		{
			photonView.didAwake = false;
		}
		HFKEGLEPEFD = GetComponentInChildren<SkinnedMeshRenderer>();
		LMIHBNGHEHM = new CKDIHNEIHKL(this);
		JPMHIGNOPBL = GetComponentsInChildren<PlayerBot>()[1];
	}

	[PunRPC]
	public void AddAmmoRPC(int DFHAAIFFLOE, int IEALLELGOBM)
	{
		weaponInventory.LAGONJMBJMM[DFHAAIFFLOE].weapon.ammoLeft += IEALLELGOBM;
	}

	public static PlayerController FindPlayerWithUserId(string BNFJCGPPAII)
	{
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.EHHHBEMKGOE.ALIIBMLMNKA == BNFJCGPPAII)
			{
				return item.Value;
			}
		}
		UnityEngine.Debug.LogError(string.Format("Player with playerId {0} doesnt exists ! ", BNFJCGPPAII));
		return null;
	}

	private void EKDKBACABCK(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		BattleAnalyticsManager.instance.DoPlayerDamage(this, OHJPPHFEAFI);
		if (DebugSettings.debugPlayerDamage)
		{
			FOCIOKMPCAG.GPLNJOPPKIM.SetText(OHJPPHFEAFI.EPDELOGPNAC.ToString());
		}
		else
		{
			FOCIOKMPCAG.GPLNJOPPKIM.SetText(string.Empty);
		}
		if (isCurrentPlayer)
		{
			MainGameEntity mainGameEntity = OHJPPHFEAFI.HNFNINFCBEJ as MainGameEntity;
			if (mainGameEntity != null && mainGameEntity != this)
			{
				mainGameEntity.SetRevenge();
			}
		}
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
		{
			PlayerController playerController = OHJPPHFEAFI.HNFNINFCBEJ as PlayerController;
			if (playerController != null)
			{
				Transform gHPBMCAKMMB = playerController.weaponInventory.currentWeapon.weapon.GHPBMCAKMMB;
				HCIHCKHMEMA(OHJPPHFEAFI, gHPBMCAKMMB.transform.position, 1.2f);
			}
			else
			{
				EnemyController enemyController = OHJPPHFEAFI.HNFNINFCBEJ as EnemyController;
				if (enemyController != null)
				{
					Transform gHPBMCAKMMB2 = enemyController.soldierBehaviour.KHKAAGCIJPO.GHPBMCAKMMB;
					HCIHCKHMEMA(OHJPPHFEAFI, gHPBMCAKMMB2.transform.position, 0.6f);
				}
				else
				{
					Drone drone = OHJPPHFEAFI.HNFNINFCBEJ as Drone;
					if (drone != null)
					{
						Transform gHPBMCAKMMB3 = drone.JMMJHCOKCGG.JMMJHCOKCGG.GHPBMCAKMMB;
						HCIHCKHMEMA(OHJPPHFEAFI, gHPBMCAKMMB3.transform.position, 0.6f);
					}
					else
					{
						Turret turret = OHJPPHFEAFI.HNFNINFCBEJ as Turret;
						if (turret != null)
						{
							HCIHCKHMEMA(OHJPPHFEAFI, turret.KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.GHPBMCAKMMB.transform.position, 0.6f);
						}
					}
				}
			}
		}
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
		{
			KJMFJFCDEDH.Show("game-ico-poison", true, HudObjectIndicator.NPPEJJKFCON.InfoIco);
			FHPMANHKAIO = Time.time;
		}
		if ((UnityEngine.Random.value < AGOGEJNFGEL || OHJPPHFEAFI.HNFNINFCBEJ == this) && !OHJPPHFEAFI.KLOJNPBGFIG && !isImmortal)
		{
			FOCIOKMPCAG.health += OHJPPHFEAFI.EPDELOGPNAC;
			return;
		}
		if (FOCIOKMPCAG.healthRatio < 0.2f && ((isCurrentPlayer && Singleton<GameController>.instance.isTutorial) || KIIHLIPAGIH))
		{
			FOCIOKMPCAG.health += OHJPPHFEAFI.EPDELOGPNAC;
		}
		if (isCurrentPlayer)
		{
			if (OHJPPHFEAFI.EPDELOGPNAC > 0f)
			{
				float nIMFNNMAKPA = float.MaxValue;
				if (OHJPPHFEAFI.FJLBLLLEELD != DestroyableObject.MANAGOLPMLH.Basic && OHJPPHFEAFI.FJLBLLLEELD != DestroyableObject.MANAGOLPMLH.Poison)
				{
					Singleton<GameCamera>.instance.HitShake();
					DestroyableObject.MANAGOLPMLH fJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD;
					if (fJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion || fJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shiver)
					{
						JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateHeavy);
					}
					else
					{
						JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateMedium);
					}
					Component component = OHJPPHFEAFI.HNFNINFCBEJ as Component;
					if (component != null)
					{
						nIMFNNMAKPA = GeometryTools.AngleSigned(component.transform.position - NGCDDPCAGJB.position, Camera.main.transform.forward, Vector3.up);
					}
				}
				GuiScreenSingle<HudScreen>.instance.PlayBloodOverlay(OHJPPHFEAFI.EPDELOGPNAC, nIMFNNMAKPA);
			}
		}
		else
		{
			FOCIOKMPCAG.GPLNJOPPKIM.Enable();
			FOCIOKMPCAG.GPLNJOPPKIM.FadeIn();
		}
		EEJMNMHBFEN = Time.time;
		KJMFJFCDEDH.Show("game-neardeath-indicator", IsNearDeath() && !isCurrentPlayer, HudObjectIndicator.NPPEJJKFCON.InfoIco);
	}

	[SpecialName]
	public WeaponInventory JLMDEMFIHCA()
	{
		return _003CDNCJBNMAECH_003Ek__BackingField;
	}

	public virtual void HLOPIELMHMO()
	{
		base.OnInstancied();
	}

	private void HCIHCKHMEMA(DestroyableObject.CJLNCMMNPBM KMJKKNFDFMM, Vector3 OEIICEJPGKI, float KBJEOEEOEFG)
	{
		if (isCurrentPlayer && !KMJKKNFDFMM.KLOJNPBGFIG)
		{
			if (FEHCCGEGPLH.isMine)
			{
				Singleton<ShotTrailRenderer>.instance.PlayShot(OEIICEJPGKI, KMJKKNFDFMM.OHNCLEOMHCF, KBJEOEEOEFG);
				return;
			}
			FEHCCGEGPLH.RPC("PlayTrailRPC", PhotonTargets.Others, OEIICEJPGKI, KMJKKNFDFMM.OHNCLEOMHCF, KBJEOEEOEFG);
		}
	}

	[PunRPC]
	public void ChangeWeightForDestroyablePartRPC(float KMMAKDHKIKH, int DFHAAIFFLOE)
	{
		FOCIOKMPCAG.AMEELJHHGKP[DFHAAIFFLOE].CMFNOLDCGCL *= KMMAKDHKIKH;
	}

	[SpecialName]
	public void FOCHCKLMPBH(float IDEBKDPMPGM)
	{
		ONOLBDPIOND.speed = IDEBKDPMPGM;
	}

	[SpecialName]
	private void BPCCKDEOFMA(bool IDEBKDPMPGM)
	{
		_003CFLPJGOOPELI_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public KKPHPLOEACG CLFDBFPKCBJ()
	{
		return JDNNOGPNJLO;
	}

	public static PlayerController CCPHMCAIJNA(GHPGNELIDBM ACJIGOBMLNH)
	{
		if (OGMBJPKOPCB.fraction == ACJIGOBMLNH)
		{
			return OGMBJPKOPCB;
		}
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction == ACJIGOBMLNH)
			{
				return item.Value;
			}
		}
		if (OGMBJPKOPCB.fraction != ACJIGOBMLNH)
		{
			UnityEngine.Debug.LogError("306 OVERTIME" + ACJIGOBMLNH);
		}
		return OGMBJPKOPCB;
	}

	public void InitPlayerForCamera()
	{
		if (DNBEAILMLLJ != null)
		{
			HFKEGLEPEFD.material = DNBEAILMLLJ;
		}
		EFFIOHJHFHI.DGHPFMPMAFC.Swap(false);
		soldierAnimator.Reset();
		SelectPrimary();
		CamosManager.instance.ApplyVisuals(this, EHHHBEMKGOE.CBBDICBLHMM, true);
	}

	public static PlayerController HEAGPACBLJA(GHPGNELIDBM ACJIGOBMLNH)
	{
		if (OGMBJPKOPCB.fraction == ACJIGOBMLNH)
		{
			return OGMBJPKOPCB;
		}
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction == ACJIGOBMLNH)
			{
				return item.Value;
			}
		}
		if (OGMBJPKOPCB.fraction != ACJIGOBMLNH)
		{
			UnityEngine.Debug.LogError("#AccoutCheck# OnCheckGpgsInTutorial: " + ACJIGOBMLNH);
		}
		return OGMBJPKOPCB;
	}

	[SpecialName]
	public virtual KMHCMCBGFFC MMCJDKGDCDD()
	{
		return this;
	}

	private void JIHMNGJCADE(MapDefinition.DefendPosition MPHCNMDIPAI, float KALLNCAFIMP = 0.02f)
	{
		CIPJHJJKJMF cIPJHJJKJMF = new CIPJHJJKJMF();
		cIPJHJJKJMF.MPHCNMDIPAI = MPHCNMDIPAI;
		cIPJHJJKJMF.BJGCPDNMHDH = this;
		EAJMOAFGJJM(KKPHPLOEACG.HidingBehindShield);
		if (KALLNCAFIMP > 1421f)
		{
			InvokeAfter(cIPJHJJKJMF.MPHECHCFCAN, KALLNCAFIMP);
		}
		else
		{
			ONOLBDPIOND.SetDestination(cIPJHJJKJMF.MPHCNMDIPAI.point.transform.position);
		}
		soldierAnimator.lookBack = false;
		Walk();
	}

	public static PlayerController MAJOCMGOFII(GHPGNELIDBM ACJIGOBMLNH)
	{
		if (OGMBJPKOPCB.fraction == ACJIGOBMLNH)
		{
			return OGMBJPKOPCB;
		}
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction == ACJIGOBMLNH)
			{
				return item.Value;
			}
		}
		if (OGMBJPKOPCB.fraction != ACJIGOBMLNH)
		{
			UnityEngine.Debug.LogError("AMMOBOX" + ACJIGOBMLNH);
		}
		return OGMBJPKOPCB;
	}

	public void Preview(bool HDBKFKKAJLF)
	{
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenRotation component2 = GetComponent<TweenRotation>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		ONOLBDPIOND.Disable();
		StopAllCoroutines();
		if (DNBEAILMLLJ != null)
		{
			HFKEGLEPEFD.material = DNBEAILMLLJ;
		}
		EFFIOHJHFHI.SetAllRigidBodiesToKinematic(true);
		EFFIOHJHFHI.OFBEAKDOCIO.SetActive(false);
		soldierAnimator.Reset();
		soldierAnimator.SetIdle(HDBKFKKAJLF ? Weapon.IGGFMJAKLGO.Tool : Weapon.IGGFMJAKLGO.Riffle);
		KPIGIEPMLLC = true;
	}

	[SpecialName]
	private void BJGHPPPAJGH(WeaponInventory IDEBKDPMPGM)
	{
		_003CDNCJBNMAECH_003Ek__BackingField = IDEBKDPMPGM;
	}

	public static PlayerController GetRandomEnemy(GHPGNELIDBM ACJIGOBMLNH)
	{
		PCPBIGOAFPL.Clear();
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction != ACJIGOBMLNH && item.Value.LMIHBNGHEHM.EIPHAAGCHCP)
			{
				PCPBIGOAFPL.Add(item.Value);
			}
		}
		if (PCPBIGOAFPL.Count > 0)
		{
			return PCPBIGOAFPL[UnityEngine.Random.Range(0, PCPBIGOAFPL.Count)];
		}
		return OGMBJPKOPCB;
	}

	private void KMOLMCEBCAI()
	{
		DOMGOLBDMBN = true;
		NJKAHEOPIDD = Input.mousePosition;
	}

	[SpecialName]
	public virtual void CMBKMOHOAGD(Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public virtual void JIAICHMGJAI(KMHCMCBGFFC IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public MapDefinition.DefendPosition CMNFFACHCEE()
	{
		return CNAOOPEKADN;
	}

	protected virtual void JBGDAOIDBGF()
	{
		if (KPIGIEPMLLC)
		{
			return;
		}
		base.Update();
		if (JDNNOGPNJLO == KKPHPLOEACG.HidingBehindShield && (NGCDDPCAGJB.position - DJODBMGLPDE).sqrMagnitude > 1473f)
		{
			DJODBMGLPDE = NGCDDPCAGJB.position;
		}
		if (FHPMANHKAIO != 1361f && Time.time > FHPMANHKAIO + 982f)
		{
			UnityEngine.Debug.Log("Game Login Manager: Login to FB");
			KJMFJFCDEDH.Show("NONE WARCARDS TO ADD FROM CARDPOOL", true, HudObjectIndicator.NPPEJJKFCON.CardIco);
			FHPMANHKAIO = 430f;
		}
		if (KFLMDLBIMHG && Time.time > BJAPCEOFJBJ)
		{
			KFLMDLBIMHG = true;
			KJMFJFCDEDH.Show("globalPlayerLeaderboard", true, HudObjectIndicator.NPPEJJKFCON.CardIco);
		}
		bool flag = fraction == OGMBJPKOPCB.fraction;
		if (EEJMNMHBFEN != 654f && Time.time > EEJMNMHBFEN + 72f && !flag && !Singleton<MatchManager>.instance.JODLOOEJHDB() && !Singleton<GameController>.instance.DAIEAMEFGIE())
		{
			EEJMNMHBFEN = 1691f;
			FOCIOKMPCAG.GPLNJOPPKIM.ECENHCAPDLD(1591f);
		}
		if (!FEHCCGEGPLH.isMine && !isCurrentPlayer)
		{
			LADBLHGBOKJ.BOPGJFGMNJM(NGCDDPCAGJB);
			GFCDMMGDFJK().transform.localRotation = Quaternion.Slerp(GFCDMMGDFJK().transform.localRotation, FBDGMKGIBNO, Time.deltaTime * 1733f);
			GFCDMMGDFJK().PLCAOODHLCA = true;
		}
		if (BEIIOAIJMFK().currentWeapon.weapon.isReloading)
		{
			int num = JLMDEMFIHCA().CGGDFMLBBLN();
			int? iJDHJJFOKIO = IJDHJJFOKIO;
			if (num == iJDHJJFOKIO.GetValueOrDefault() && !iJDHJJFOKIO.HasValue && GFCDMMGDFJK().isIdle)
			{
				GFCDMMGDFJK().Reload(FMKGGADDHJK().PDLFJEDGLAO().weapon.BEACDIILBEG);
				IJDHJJFOKIO = FMKGGADDHJK().LDPEDGACDLL();
			}
		}
		else
		{
			IJDHJJFOKIO = null;
		}
		if (Singleton<GameController>.instance.gameIsRunning && FEHCCGEGPLH.isMine && base.isAlive && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			soldierAnimator.PLCAOODHLCA = true;
			if (isCurrentPlayer)
			{
				if (Input.GetMouseButtonDown(0))
				{
					DOMGOLBDMBN = true;
					AimTarget aimTarget = Singleton<AimingHelper>.instance.GNMGAGKMJGP();
					if (aimTarget != null)
					{
						clicked = false;
					}
				}
				if (Singleton<InputController>.instance.swipeEnded && !DOMGOLBDMBN)
				{
					NJKAHEOPIDD = Singleton<InputController>.instance.swipePosition - Singleton<InputController>.instance.pressPosition;
					float num2 = Vector3.Angle(NJKAHEOPIDD, Vector3.up);
					if (NJKAHEOPIDD.magnitude > (float)Screen.width * 882f && num2 > 84f)
					{
						clicked = true;
						if (NJKAHEOPIDD.x > 802f)
						{
							GoRight();
						}
						else
						{
							GoLeft();
						}
					}
				}
				if (Input.GetMouseButtonUp(0) && DOMGOLBDMBN)
				{
					NJKAHEOPIDD = Input.mousePosition - NJKAHEOPIDD;
					float num3 = Vector3.Angle(NJKAHEOPIDD, Vector3.up);
					if (NJKAHEOPIDD.magnitude > (float)Screen.width * 564f && num3 > 703f)
					{
						clicked = true;
						if (NJKAHEOPIDD.x > 395f)
						{
							GoRight();
						}
						else
						{
							GoLeft();
						}
					}
				}
			}
			if (JDNNOGPNJLO == KKPHPLOEACG.Walking && LJPNJJFBMCD != null && NGCDDPCAGJB.position.PlanarDistance(LJPNJJFBMCD.point.transform.position) < 1103f)
			{
				Vector3 toPos = LJPNJJFBMCD.point.transform.position;
				toPos.y = NGCDDPCAGJB.position.y;
				TweenPosition.Begin(base.gameObject, 1893f, NGCDDPCAGJB.position, toPos, false);
				EAJMOAFGJJM(KKPHPLOEACG.HidingBehindShield);
				TweenRotation.Begin(base.gameObject, 1232f, LJPNJJFBMCD.point.transform.rotation, true);
				GFCDMMGDFJK().lookBack = false;
				Idle();
				ONOLBDPIOND.Disable();
			}
		}
		if (Singleton<GameController>.instance.GHKPKDPOGHF() && isCurrentPlayer && BEIIOAIJMFK().OLHICLNCPNA().HFNAMMBPJAJ().outOfAmmo && !clicked && Input.GetMouseButton(0))
		{
			GuiScreenSingle<HudScreen>.instance.CEBDPNMPAFC(BEIIOAIJMFK().JNFHKEJCIIA());
		}
		else if (Singleton<GameController>.instance.KKHKIEFMENC() && isCurrentPlayer && JLMDEMFIHCA().OLHICLNCPNA().weapon.NAIKLJKNLAE && JLMDEMFIHCA().APLKMLDHMDL().HFNAMMBPJAJ().isReloading && !clicked && Input.GetMouseButton(1))
		{
			GuiScreenSingle<HudScreen>.instance.JHLJHAGPFMD(FMKGGADDHJK().PDLFJEDGLAO());
		}
		if (Singleton<GameController>.instance.gameIsRunning && CDBNKOPKCJB && !TimeManager.instance.EEHBPNDBNKC)
		{
			weaponInventory.PDLFJEDGLAO().MJNGGEJFMNF();
		}
		else if ((TimeManager.instance.EEHBPNDBNKC || !CDBNKOPKCJB) && Input.GetMouseButtonUp(1))
		{
			weaponInventory.PDLFJEDGLAO().AKGFAMMBHJD();
		}
		if (FEHCCGEGPLH.isMine)
		{
			HGNLCILPALK();
		}
		if (!FEHCCGEGPLH.isMine)
		{
			GFCDMMGDFJK().OGCAPEEHKIM = Mathf.Lerp(soldierAnimator.OGCAPEEHKIM, ELFBJCLMKDN, Time.deltaTime * 1364f);
			soldierAnimator.SetUpperBodyRot(GFCDMMGDFJK().OGCAPEEHKIM);
		}
	}

	private void PGEONBPBMPL(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, float KBJEOEEOEFG)
	{
		Singleton<ShotTrailRenderer>.instance.FFDJIHEEILI(OEIICEJPGKI, IIMDKHJAJGO, KBJEOEEOEFG);
	}

	public static PlayerController OKCPJKIDGGE(GHPGNELIDBM ACJIGOBMLNH)
	{
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction == ACJIGOBMLNH && !item.Value.isCurrentPlayer)
			{
				return item.Value;
			}
		}
		if (OGMBJPKOPCB.fraction == ACJIGOBMLNH)
		{
			return OGMBJPKOPCB;
		}
		return null;
	}

	[SpecialName]
	public virtual void HHCEBMPOJHB(int IDEBKDPMPGM)
	{
		_003CCDNMFDJOELD_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void HCOKNKCCPEK(MapDefinition.DefendPosition IDEBKDPMPGM)
	{
		if (CNAOOPEKADN != null && CNAOOPEKADN.point.LHHMNLJKOAO() != null)
		{
			CNAOOPEKADN.point.shield.FPINCGGFENG(null);
		}
		CNAOOPEKADN = IDEBKDPMPGM;
		if (CNAOOPEKADN != null && CNAOOPEKADN.point.shield != null)
		{
			CNAOOPEKADN.point.JPHAJDIIAAI().MIEPCKHJAEL(this);
		}
	}

	[SpecialName]
	public Vector3 EJAEPLJMEGN()
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG != null)
		{
			Vector3 vector = Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG.position - NGCDDPCAGJB.position;
			float num = GeometryTools.AngleSigned(vector, aimForward, Vector3.up);
			if (num > 1236f)
			{
				return Quaternion.AngleAxis(1304f, -Vector3.up) * aimForward;
			}
			if (num < 1651f)
			{
				return Quaternion.AngleAxis(31f, -Vector3.up) * aimForward;
			}
			return vector;
		}
		return base.transform.forward;
	}

	[PunRPC]
	private void PlayTrailRPC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, float KBJEOEEOEFG)
	{
		Singleton<ShotTrailRenderer>.instance.PlayShot(OEIICEJPGKI, IIMDKHJAJGO, KBJEOEEOEFG);
	}

	protected override void Start()
	{
		base.Start();
		base.isAlive = true;
	}

	[SpecialName]
	public void PONCLMNBAJM(Action<KKPHPLOEACG> IDEBKDPMPGM)
	{
		Action<KKPHPLOEACG> action = KCECODPHBLE;
		Action<KKPHPLOEACG> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KCECODPHBLE, (Action<KKPHPLOEACG>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void MKDADCKJGJI(float JNHKEAHMAMF)
	{
		AGOGEJNFGEL = JNHKEAHMAMF;
	}

	public void SetNoDamageChance(float JNHKEAHMAMF)
	{
		AGOGEJNFGEL = JNHKEAHMAMF;
		LAADDLGBFIG.RPC("SetNoDamageChanceRPC", PhotonTargets.Others, JNHKEAHMAMF);
	}

	public static PlayerController GetPlayerOld(GHPGNELIDBM ACJIGOBMLNH)
	{
		if (OGMBJPKOPCB.fraction == ACJIGOBMLNH)
		{
			return OGMBJPKOPCB;
		}
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction == ACJIGOBMLNH)
			{
				return item.Value;
			}
		}
		if (OGMBJPKOPCB.fraction != ACJIGOBMLNH)
		{
			UnityEngine.Debug.LogError("Can not find player with fraction " + ACJIGOBMLNH);
		}
		return OGMBJPKOPCB;
	}

	private void AKHFCLCBPAE(DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		Rigidbody component = EFFIOHJHFHI.CGCKDIBIFFI.GetComponent<Rigidbody>();
		DestroyableObjectpart[] aMEELJHHGKP = FOCIOKMPCAG.AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			if (destroyableObjectpart.GetComponent<Rigidbody>() == null)
			{
				destroyableObjectpart.GetComponent<Collider>().enabled = false;
			}
		}
		foreach (Collider item in DDGBIBMPEOE)
		{
			item.enabled = false;
		}
		SetLayerRecursively(KCGNHJOLNKD.gameObject, TagsAndLayers.KFLGCPACECP);
		TimeManager.instance.SetupPhysicsTiming(true);
		GFCDMMGDFJK().Stop();
		KCGNHJOLNKD.DLJMIOADAKM();
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
		{
			Vector3 vector = new Vector3(UnityEngine.Random.Range(325f, 1122f), UnityEngine.Random.Range(1465f, 1207f), 355f);
			component.AddForce(OHJPPHFEAFI.LPGMLOCLBGP * 1445f, ForceMode.Force);
			component.AddTorque(vector.x, vector.y, vector.z, ForceMode.Force);
		}
		else
		{
			Vector3 force = OHJPPHFEAFI.LPGMLOCLBGP * 646f + Vector3.up * OHJPPHFEAFI.LPGMLOCLBGP.magnitude * 214f;
			component.AddForce(force, ForceMode.Force);
		}
	}

	[SpecialName]
	public WeaponInventory FMKGGADDHJK()
	{
		return _003CDNCJBNMAECH_003Ek__BackingField;
	}

	[SpecialName]
	public void CBJFFHJLADH(float IDEBKDPMPGM)
	{
		_003CDADDCEIAJPH_003Ek__BackingField = IDEBKDPMPGM;
	}

	[PunRPC]
	public void SetNoDamageChanceRPC(float JNHKEAHMAMF)
	{
		AGOGEJNFGEL = JNHKEAHMAMF;
	}

	public virtual void GJNGEPHDIDG()
	{
		base.DestroyPooled();
		CMKNJFHHOHA(null);
	}

	[SpecialName]
	public void CNBLHENJNHE(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		EHHHBEMKGOE.IPJIPGILEHF = IDEBKDPMPGM;
	}

	public void ReSync()
	{
		if (isCurrentPlayer)
		{
			FOCIOKMPCAG.Sync();
		}
	}

	[SpecialName]
	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory BFNHCEOLMHF()
	{
		return EHHHBEMKGOE.IPJIPGILEHF;
	}

	private void OnPress(bool HCAJFFJBCOJ)
	{
		if (HCAJFFJBCOJ && Singleton<GameController>.instance.gameIsRunning && UICamera.currentTouch.pressed != base.gameObject)
		{
			PAGPNMNPOIA = UICamera.currentTouch.pressed;
			clicked = true;
			Singleton<InputController>.instance.CancelClick();
		}
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet EJPCHEICGDE()
	{
		return EHHHBEMKGOE.POHFJHBABAF;
	}

	[SpecialName]
	public virtual int AIIFILIMDIJ()
	{
		return _003CCDNMFDJOELD_003Ek__BackingField;
	}

	[PunRPC]
	private void Walk()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Walk", PhotonTargets.Others);
		}
		soldierAnimator.Walk(weaponInventory.currentWeapon.weapon.BEACDIILBEG);
	}

	[SpecialName]
	public virtual void LODLANHFCBO(KMHCMCBGFFC IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public MapDefinition.DefendPosition EMAMENNDFMB()
	{
		return CNAOOPEKADN;
	}

	protected void PJMAHMIIMPF()
	{
		FMGIFEFLLBH = !Input.GetMouseButton(0);
		if (FMGIFEFLLBH)
		{
			BPCCKDEOFMA(true);
		}
	}

	[SpecialName]
	public void MGODCJLIBAE(Action<KKPHPLOEACG> IDEBKDPMPGM)
	{
		Action<KKPHPLOEACG> action = KCECODPHBLE;
		Action<KKPHPLOEACG> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KCECODPHBLE, (Action<KKPHPLOEACG>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void PICKMNBAPHD(float IDEBKDPMPGM)
	{
		_003CDADDCEIAJPH_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void KLFFMPINIPB()
	{
		if (DNBEAILMLLJ != null)
		{
			HFKEGLEPEFD.material = DNBEAILMLLJ;
		}
		EFFIOHJHFHI.DGHPFMPMAFC.MAGLHAOFGHL(false);
		soldierAnimator.Reset();
		SelectPrimary();
		CamosManager.instance.ApplyVisuals(this, EHHHBEMKGOE.CBBDICBLHMM);
	}

	private void CODLCIPGHMI(MapDefinition.DefendPosition MPHCNMDIPAI, float KALLNCAFIMP = 0.02f)
	{
		CIPJHJJKJMF cIPJHJJKJMF = new CIPJHJJKJMF();
		cIPJHJJKJMF.MPHCNMDIPAI = MPHCNMDIPAI;
		cIPJHJJKJMF.BJGCPDNMHDH = this;
		playerState = KKPHPLOEACG.Walking;
		if (KALLNCAFIMP > 0f)
		{
			InvokeAfter(cIPJHJJKJMF.LJCDGJKCNEC, KALLNCAFIMP);
		}
		else
		{
			ONOLBDPIOND.SetDestination(cIPJHJJKJMF.MPHCNMDIPAI.point.transform.position);
		}
		soldierAnimator.lookBack = false;
		Walk();
	}

	private Vector3 CHNFEKECAPB(Vector3 MPHCNMDIPAI)
	{
		NavMeshHit hit;
		if (NavMesh.SamplePosition(MPHCNMDIPAI, out hit, 10f, 1))
		{
			return hit.position;
		}
		return MPHCNMDIPAI;
	}

	[SpecialName]
	public bool KAGFCHIAKLG()
	{
		return true;
	}

	public MapDefinition.DefendPosition GoLeft(MapDefinition.DefendPosition PLMMBKGLGAB)
	{
		if (JFECKJEDJNJ || !base.isAlive || !Singleton<GameController>.instance.gameIsRunning)
		{
			return null;
		}
		HHHOOCKBIOL = false;
		DHIDLFAHOFJ = false;
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		int num = 0;
		for (num = 0; num < availablePoints.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[num];
			if (defendPosition == PLMMBKGLGAB)
			{
				break;
			}
		}
		if (num > 0)
		{
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (availablePoints[num2].fraction == fraction && availablePoints[num2].point.shield.player == null)
				{
					DHIDLFAHOFJ = true;
					LJPNJJFBMCD = availablePoints[num2];
					LJPNJJFBMCD.point.shield.GetLock();
					CODLCIPGHMI(LJPNJJFBMCD);
					return LJPNJJFBMCD;
				}
			}
		}
		HOAGNCIKKDD(-1);
		return null;
	}

	[SpecialName]
	public virtual void FFEDMMENHFA(Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public static PlayerController BGEKNDDACNP(GHPGNELIDBM ACJIGOBMLNH)
	{
		PCPBIGOAFPL.Clear();
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction != ACJIGOBMLNH && item.Value.LMIHBNGHEHM.NOKOMEHKFNO())
			{
				PCPBIGOAFPL.Add(item.Value);
			}
		}
		if (PCPBIGOAFPL.Count > 0)
		{
			return PCPBIGOAFPL[UnityEngine.Random.Range(1, PCPBIGOAFPL.Count)];
		}
		return OGMBJPKOPCB;
	}

	[SpecialName]
	public virtual int KDGDCNKHJGH()
	{
		return _003CCDNMFDJOELD_003Ek__BackingField;
	}

	[SpecialName]
	public SoldierMeshChanger AJAKNDJMMMH()
	{
		return mMeshChanger;
	}

	protected void LateUpdate()
	{
		FMGIFEFLLBH = !Input.GetMouseButton(0);
		if (FMGIFEFLLBH)
		{
			clicked = false;
		}
	}

	public void SetUpKevlar(float INJCLBGJHAF = 0.25f)
	{
		Kevlar component = GetComponent<Kevlar>();
		component.DOPFEMONAFI = INJCLBGJHAF;
		component.SetUpKevlar();
	}

	private void FGNOMDJPILO(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		BattleAnalyticsManager.NPAJKFMCPPC().DoPlayerDamage(this, OHJPPHFEAFI);
		if (DebugSettings.debugPlayerDamage)
		{
			FOCIOKMPCAG.GPLNJOPPKIM.ICMIAECNIHC(OHJPPHFEAFI.EPDELOGPNAC.ToString());
		}
		else
		{
			FOCIOKMPCAG.GPLNJOPPKIM.IIBOJGPPHGE(string.Empty);
		}
		if (isCurrentPlayer)
		{
			MainGameEntity mainGameEntity = OHJPPHFEAFI.HNFNINFCBEJ as MainGameEntity;
			if (mainGameEntity != null && mainGameEntity != this)
			{
				mainGameEntity.SetRevenge();
			}
		}
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
		{
			PlayerController playerController = OHJPPHFEAFI.HNFNINFCBEJ as PlayerController;
			if (playerController != null)
			{
				Transform gHPBMCAKMMB = playerController.BEIIOAIJMFK().NANJBGIGNCG().HFNAMMBPJAJ()
					.GHPBMCAKMMB;
				HCIHCKHMEMA(OHJPPHFEAFI, gHPBMCAKMMB.transform.position, 1624f);
			}
			else
			{
				EnemyController enemyController = OHJPPHFEAFI.HNFNINFCBEJ as EnemyController;
				if (enemyController != null)
				{
					Transform gHPBMCAKMMB2 = enemyController.soldierBehaviour.KHKAAGCIJPO.GHPBMCAKMMB;
					HCIHCKHMEMA(OHJPPHFEAFI, gHPBMCAKMMB2.transform.position, 1512f);
				}
				else
				{
					Drone drone = OHJPPHFEAFI.HNFNINFCBEJ as Drone;
					if (drone != null)
					{
						Transform gHPBMCAKMMB3 = drone.JMMJHCOKCGG.JMMJHCOKCGG.GHPBMCAKMMB;
						HCIHCKHMEMA(OHJPPHFEAFI, gHPBMCAKMMB3.transform.position, 25f);
					}
					else
					{
						Turret turret = OHJPPHFEAFI.HNFNINFCBEJ as Turret;
						if (turret != null)
						{
							HCIHCKHMEMA(OHJPPHFEAFI, turret.KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.GHPBMCAKMMB.transform.position, 1856f);
						}
					}
				}
			}
		}
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
		{
			KJMFJFCDEDH.GGHDIAFACAH("Card ID \"{0}\" is not pressent in card dictionary.", false, HudObjectIndicator.NPPEJJKFCON.InfoIco);
			FHPMANHKAIO = Time.time;
		}
		if ((UnityEngine.Random.value < AGOGEJNFGEL || OHJPPHFEAFI.HNFNINFCBEJ == this) && !OHJPPHFEAFI.KLOJNPBGFIG && !isImmortal)
		{
			DestroyableObjectPlayer fOCIOKMPCAG = FOCIOKMPCAG;
			fOCIOKMPCAG.GMNNGEELOFC(fOCIOKMPCAG.health + OHJPPHFEAFI.EPDELOGPNAC);
			return;
		}
		if (FOCIOKMPCAG.healthRatio < 1487f && ((isCurrentPlayer && Singleton<GameController>.instance.BAKCODKBCPJ()) || KIIHLIPAGIH))
		{
			FOCIOKMPCAG.health += OHJPPHFEAFI.EPDELOGPNAC;
		}
		if (isCurrentPlayer)
		{
			if (OHJPPHFEAFI.EPDELOGPNAC > 1864f)
			{
				float nIMFNNMAKPA = 1748f;
				if (OHJPPHFEAFI.FJLBLLLEELD != DestroyableObject.MANAGOLPMLH.Poison && OHJPPHFEAFI.FJLBLLLEELD != DestroyableObject.MANAGOLPMLH.Basic)
				{
					Singleton<GameCamera>.instance.HitShake();
					DestroyableObject.MANAGOLPMLH fJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD;
					if (fJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion || fJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
					{
						JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareMedium);
					}
					else
					{
						JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateLight);
					}
					Component component = OHJPPHFEAFI.HNFNINFCBEJ as Component;
					if (component != null)
					{
						nIMFNNMAKPA = GeometryTools.AngleSigned(component.transform.position - NGCDDPCAGJB.position, Camera.main.transform.forward, Vector3.up);
					}
				}
				GuiScreenSingle<HudScreen>.instance.IGOEKAFOLLG(OHJPPHFEAFI.EPDELOGPNAC, nIMFNNMAKPA);
			}
		}
		else
		{
			FOCIOKMPCAG.GPLNJOPPKIM.Enable();
			FOCIOKMPCAG.GPLNJOPPKIM.BNPNCDMAIJM(1351f);
		}
		EEJMNMHBFEN = Time.time;
		KJMFJFCDEDH.Show("Days_Since_Install", !OBEIMNKPABG() || !isCurrentPlayer, HudObjectIndicator.NPPEJJKFCON.CardIco);
	}

	public static PlayerController GetMaster()
	{
		if (Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			return OGMBJPKOPCB;
		}
		return GetFriend(OGMBJPKOPCB.fraction);
	}

	public virtual void FADJGCGFKII()
	{
		base.OnInstancied();
	}

	public static PlayerController GetFriend(GHPGNELIDBM ACJIGOBMLNH)
	{
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction == ACJIGOBMLNH && !item.Value.isCurrentPlayer)
			{
				return item.Value;
			}
		}
		if (OGMBJPKOPCB.fraction == ACJIGOBMLNH)
		{
			return OGMBJPKOPCB;
		}
		return null;
	}

	[SpecialName]
	public SoldierAnimationController GFCDMMGDFJK()
	{
		return _003CGOMKGFGHBMP_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerVisualCategoryHelmets.PlayerVisualHelmet GGOOMCMHDCH()
	{
		return EHHHBEMKGOE.ANCFFCIHJFB();
	}

	private void JOGGMAJOHCI(bool NCMHGPNPEJM)
	{
	}

	public void HideWeapon()
	{
		weaponInventory.currentWeapon.gameObject.SetActive(false);
	}

	[SpecialName]
	public GameShootableEntity IJPPJNNDFIB()
	{
		return _003CMANBIJGEGFF_003Ek__BackingField;
	}

	private void MMIDIBABIJN(bool NCMHGPNPEJM)
	{
	}

	public static List<PlayerController> GetEnemiesOf(GHPGNELIDBM ACJIGOBMLNH)
	{
		List<PlayerController> list = new List<PlayerController>();
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction != ACJIGOBMLNH && item.Value.LMIHBNGHEHM.EIPHAAGCHCP)
			{
				list.Add(item.Value);
			}
		}
		return list;
	}

	[SpecialName]
	public virtual KMHCMCBGFFC MJBDBDBJJNE()
	{
		return this;
	}

	public void AJOPAECPDCG()
	{
		if (isCurrentPlayer)
		{
			FOCIOKMPCAG.Sync();
		}
	}

	private void ENNAAIOKMOE()
	{
		if (!HHHOOCKBIOL && !DHIDLFAHOFJ)
		{
			return;
		}
		if (LJPNJJFBMCD.point.LMHDAIBCLDP().CBKJPJGBHPK == Shield.DLGLDOOFAOA.Success)
		{
			CMKNJFHHOHA(LJPNJJFBMCD);
			if (FEHCCGEGPLH.isMine)
			{
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[0];
				array[0] = CNAOOPEKADN.index;
				fEHCCGEGPLH.RPC("OfflineRoom", PhotonTargets.All, array);
			}
			HHHOOCKBIOL = false;
			DHIDLFAHOFJ = false;
		}
		if (LJPNJJFBMCD.point.KJCHIHLJMMF().CBKJPJGBHPK != (Shield.DLGLDOOFAOA)6)
		{
			return;
		}
		if (HHHOOCKBIOL)
		{
			MCIAJMNFIJO(LJPNJJFBMCD);
			if (!HHHOOCKBIOL)
			{
				LJPNJJFBMCD = CMNFFACHCEE();
				JIHMNGJCADE(LJPNJJFBMCD, 105f);
			}
		}
		if (DHIDLFAHOFJ)
		{
			ACODFPFBDLI(LJPNJJFBMCD);
			if (!DHIDLFAHOFJ)
			{
				LJPNJJFBMCD = BBNPGJAALCJ();
				CODLCIPGHMI(LJPNJJFBMCD, 289f);
			}
		}
	}

	public virtual void ECMBCEPKAFO()
	{
		base.BeforeInstancied();
	}

	[PunRPC]
	private void InitBotRPC(byte ACJIGOBMLNH)
	{
		KPIGIEPMLLC = false;
		fraction = (GHPGNELIDBM)ACJIGOBMLNH;
		EHHHBEMKGOE.GGKGGMNIDMI = null;
		InitPlayer();
		NAGAHNHAKBJ = 10;
		JFGDAKMCJAM[10] = this;
		UnityEngine.Debug.Log("Init bot RPC");
	}

	public void ANNFPEBGBAF(float KBJEOEEOEFG)
	{
		object[] array = new object[4];
		array[1] = "SERVICE_MISSING_PERMISSION";
		array[1] = base.name;
		array[2] = "Look vector error! .. phase: {0} target: {1} transform.position: {2} playerPosition: {3} upPosition: {4} cameraLeanPhase: {5} rotatedLookVector: {6}";
		array[6] = Time.time;
		UnityEngine.Debug.Log(string.Concat(array));
		KJMFJFCDEDH.GGHDIAFACAH("ID_CONFIRM_EXITINGCOOP_TEXT", false, HudObjectIndicator.NPPEJJKFCON.CardIco);
		KFLMDLBIMHG = true;
		BJAPCEOFJBJ = Time.time + KBJEOEEOEFG;
	}

	[PunRPC]
	private void SetCurrentPoint(int DFHAAIFFLOE)
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null)
		{
			CNAOOPEKADN = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD[DFHAAIFFLOE];
		}
	}

	public MapDefinition.DefendPosition MCIAJMNFIJO(MapDefinition.DefendPosition PLMMBKGLGAB)
	{
		if (JFECKJEDJNJ || !base.isAlive || !Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			return null;
		}
		HHHOOCKBIOL = true;
		DHIDLFAHOFJ = true;
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.PBOGDIJIHGP();
		int num = 0;
		for (num = 0; num < list.Count; num += 0)
		{
			MapDefinition.DefendPosition defendPosition = list[num];
			if (defendPosition == PLMMBKGLGAB)
			{
				break;
			}
		}
		if (num < list.Count - 0)
		{
			for (int i = num + 1; i < list.Count; i += 0)
			{
				if (list[i].fraction == fraction && list[i].point.LMHDAIBCLDP().NPOMEBDPBGL() == null)
				{
					HHHOOCKBIOL = false;
					LJPNJJFBMCD = list[i];
					LJPNJJFBMCD.point.KJCHIHLJMMF().GetLock();
					CODLCIPGHMI(LJPNJJFBMCD, 779f);
					return LJPNJJFBMCD;
				}
			}
		}
		HOAGNCIKKDD(1);
		return null;
	}

	[PunRPC]
	private void Idle()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Idle", PhotonTargets.Others);
		}
		soldierAnimator.Idle(weaponInventory.currentWeapon.weapon.BEACDIILBEG);
	}

	[PunRPC]
	public void PlayShotAnimationNetwork(byte JMMJHCOKCGG, bool DNDCODMGGEE)
	{
		if (playerState == KKPHPLOEACG.HidingBehindShield)
		{
			switch (JMMJHCOKCGG)
			{
			case 1:
				soldierAnimator.ThrowGrenadeFromCover(!DNDCODMGGEE, ignoreTimeScale);
				break;
			case 2:
				soldierAnimator.ShootFromBazoka(DNDCODMGGEE, true);
				break;
			default:
				soldierAnimator.ShotFromCover(!DNDCODMGGEE, 4f, 0.4f, true, (Weapon.IGGFMJAKLGO)JMMJHCOKCGG);
				break;
			}
		}
		if (playerState == KKPHPLOEACG.Walking)
		{
			switch (JMMJHCOKCGG)
			{
			case 1:
				soldierAnimator.ThrowGrenadeFromCover(!DNDCODMGGEE, ignoreTimeScale);
				break;
			case 2:
				soldierAnimator.ShootFromBazokaWalk();
				break;
			default:
				soldierAnimator.ShootStandAdditive(0.4f);
				break;
			}
		}
	}

	[SpecialName]
	public WeaponInventory BEIIOAIJMFK()
	{
		return _003CDNCJBNMAECH_003Ek__BackingField;
	}

	public MapDefinition.DefendPosition ACODFPFBDLI(MapDefinition.DefendPosition PLMMBKGLGAB)
	{
		if (JFECKJEDJNJ || !base.isAlive || !Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			return null;
		}
		HHHOOCKBIOL = true;
		DHIDLFAHOFJ = true;
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.IJDLIIBLLJO();
		int num = 0;
		for (num = 1; num < list.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = list[num];
			if (defendPosition == PLMMBKGLGAB)
			{
				break;
			}
		}
		if (num > 1)
		{
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (list[num2].fraction == fraction && list[num2].point.PHANADCNBFD().player == null)
				{
					DHIDLFAHOFJ = true;
					LJPNJJFBMCD = list[num2];
					LJPNJJFBMCD.point.PHANADCNBFD().PNICBKAKEHO();
					JIHMNGJCADE(LJPNJJFBMCD, 506f);
					return LJPNJJFBMCD;
				}
			}
		}
		HOAGNCIKKDD(-1);
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		JEHDCCKBPPD.POJELIKFDPO = true;
		JEHDCCKBPPD.Clicked += KMOLMCEBCAI;
		soldierAnimator = GetComponentInChildren<SoldierAnimationController>();
		ONOLBDPIOND = GetComponent<NavigationAgent>();
		weaponInventory = GetComponentInChildren<WeaponInventory>();
		EFFIOHJHFHI = GetComponent<SoldierParts>();
		gameShootableEntity = GetComponent<GameShootableEntity>();
		weaponInventory.SetUpPlayer(this);
		FOCIOKMPCAG.OnDeath += FHEMDCFGMMF;
		FOCIOKMPCAG.OnDamage += EKDKBACABCK;
		ODDDGIALOPM(ODCLPMADGFC);
		JDNNOGPNJLO = KKPHPLOEACG.HidingBehindShield;
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		NGCDDPCAGJB = base.transform;
		weaponInventory.SelectedWeaponChanged += AKJMMIGGKFG;
		PhotonView[] componentsInChildren = GetComponentsInChildren<PhotonView>(true);
		PhotonView[] array = componentsInChildren;
		foreach (PhotonView photonView in array)
		{
			photonView.didAwake = true;
		}
		HFKEGLEPEFD = GetComponentInChildren<SkinnedMeshRenderer>();
		LMIHBNGHEHM = new CKDIHNEIHKL(this);
		JPMHIGNOPBL = GetComponentsInChildren<PlayerBot>()[0];
	}

	[SpecialName]
	public KKPHPLOEACG BIEONCCPBIL()
	{
		return JDNNOGPNJLO;
	}

	public static PlayerController BAEIKGKJOIN(GHPGNELIDBM ACJIGOBMLNH)
	{
		PCPBIGOAFPL.Clear();
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction != ACJIGOBMLNH && item.Value.LMIHBNGHEHM.JGIFJADOLGO())
			{
				PCPBIGOAFPL.Add(item.Value);
			}
		}
		if (PCPBIGOAFPL.Count > 1)
		{
			return PCPBIGOAFPL[UnityEngine.Random.Range(1, PCPBIGOAFPL.Count)];
		}
		return OGMBJPKOPCB;
	}

	public static PlayerController GetPlayer(GHPGNELIDBM ACJIGOBMLNH)
	{
		if (OGMBJPKOPCB.fraction == ACJIGOBMLNH)
		{
			return OGMBJPKOPCB;
		}
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction == ACJIGOBMLNH)
			{
				return item.Value;
			}
		}
		return null;
	}

	[SpecialName]
	public Vector3 NEAOHPOBCAN()
	{
		return NGCDDPCAGJB.position;
	}

	public virtual void AAEFDBDIHIE()
	{
		base.DestroyPooled();
		CMKNJFHHOHA(null);
	}

	public bool OBEIMNKPABG()
	{
		return !(FOCIOKMPCAG.healthRatio <= 1173f);
	}

	public void LAJGOADFPJH()
	{
		if (isCurrentPlayer)
		{
			FOCIOKMPCAG.EHFOHNLMJOH();
		}
	}

	private void NCAKLEOEDBO()
	{
		if (base.gameObject.activeSelf && fraction == OGMBJPKOPCB.fraction && DebugSettings.instance.data.showPlayerHealthBar)
		{
			FOCIOKMPCAG.GPLNJOPPKIM.Enable();
			FOCIOKMPCAG.GPLNJOPPKIM.FadeIn();
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		currentPlayerPoint = null;
	}

	public void ONPGPFNNLKD(int DFHAAIFFLOE, int IEALLELGOBM)
	{
		FMKGGADDHJK().LAGONJMBJMM[DFHAAIFFLOE].HFNAMMBPJAJ().ammoLeft += IEALLELGOBM;
	}

	[PunRPC]
	public void Uncover(bool DNDCODMGGEE, bool LCPAAFNLHOD)
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Uncover", PhotonTargets.Others, DNDCODMGGEE, LCPAAFNLHOD);
		}
		if (playerState == KKPHPLOEACG.HidingBehindShield)
		{
			Weapon.IGGFMJAKLGO bEACDIILBEG = weaponInventory.currentWeapon.weapon.BEACDIILBEG;
			if (bEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka)
			{
				soldierAnimator.Idle(weaponInventory.currentWeapon.weapon.BEACDIILBEG);
				soldierAnimator.LookAt(-base.transform.forward, 0.3f);
			}
			else
			{
				soldierAnimator.ShotFromCover(!DNDCODMGGEE, 4f, 0.25f, true, true, LCPAAFNLHOD, weaponInventory.currentWeapon.weapon.BEACDIILBEG);
			}
		}
		if (playerState == KKPHPLOEACG.Walking)
		{
			soldierAnimator.ShootStandAdditive(0.25f, LCPAAFNLHOD);
		}
	}

	public bool IsNearDeath()
	{
		return FOCIOKMPCAG.healthRatio <= 0.15f;
	}

	public bool IsDeath()
	{
		return FOCIOKMPCAG.health <= 0f;
	}

	public void MakeBlind(float KBJEOEEOEFG)
	{
		UnityEngine.Debug.Log("Stop shooting " + base.name + ", " + Time.time);
		KJMFJFCDEDH.Show("game-ico-blind", true, HudObjectIndicator.NPPEJJKFCON.InfoIco);
		KFLMDLBIMHG = true;
		BJAPCEOFJBJ = Time.time + KBJEOEEOEFG;
	}

	[SpecialName]
	public void OCMDJMNFNKF(MapDefinition.DefendPosition IDEBKDPMPGM)
	{
		if (CNAOOPEKADN != null && CNAOOPEKADN.point.LMHDAIBCLDP() != null)
		{
			CNAOOPEKADN.point.PHANADCNBFD().MIEPCKHJAEL(null);
		}
		CNAOOPEKADN = IDEBKDPMPGM;
		if (CNAOOPEKADN != null && CNAOOPEKADN.point.IGEDGCNJCAP() != null)
		{
			CNAOOPEKADN.point.PNKKPNIMEPL().player = this;
		}
	}

	[SpecialName]
	public virtual void DIOEINBFJBG(Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public static PlayerController FDMHGNEGHDD(GHPGNELIDBM ACJIGOBMLNH)
	{
		PCPBIGOAFPL.Clear();
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction != ACJIGOBMLNH && item.Value.LMIHBNGHEHM.MIPJPMFLBPG())
			{
				PCPBIGOAFPL.Add(item.Value);
			}
		}
		if (PCPBIGOAFPL.Count > 1)
		{
			return PCPBIGOAFPL[UnityEngine.Random.Range(1, PCPBIGOAFPL.Count)];
		}
		return OGMBJPKOPCB;
	}

	[SpecialName]
	public virtual int OOKPIGKFIDM()
	{
		return _003CCDNMFDJOELD_003Ek__BackingField;
	}

	private void MMMNJDOFMCP()
	{
		if (!HHHOOCKBIOL && !DHIDLFAHOFJ)
		{
			return;
		}
		if (LJPNJJFBMCD.point.shield.CBKJPJGBHPK == Shield.DLGLDOOFAOA.Success)
		{
			currentPlayerPoint = LJPNJJFBMCD;
			if (FEHCCGEGPLH.isMine)
			{
				FEHCCGEGPLH.RPC("SetCurrentPoint", PhotonTargets.Others, CNAOOPEKADN.index);
			}
			HHHOOCKBIOL = false;
			DHIDLFAHOFJ = false;
		}
		if (LJPNJJFBMCD.point.shield.CBKJPJGBHPK != Shield.DLGLDOOFAOA.Failure)
		{
			return;
		}
		if (HHHOOCKBIOL)
		{
			GoRight(LJPNJJFBMCD);
			if (!HHHOOCKBIOL)
			{
				LJPNJJFBMCD = currentPlayerPoint;
				CODLCIPGHMI(LJPNJJFBMCD);
			}
		}
		if (DHIDLFAHOFJ)
		{
			GoLeft(LJPNJJFBMCD);
			if (!DHIDLFAHOFJ)
			{
				LJPNJJFBMCD = currentPlayerPoint;
				CODLCIPGHMI(LJPNJJFBMCD);
			}
		}
	}

	[SpecialName]
	public Vector3 OBBPNKCOJNO()
	{
		return NGCDDPCAGJB.position;
	}

	[SpecialName]
	public void BNODNHPIIMG(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		EHHHBEMKGOE.IPJIPGILEHF = IDEBKDPMPGM;
	}

	public static PlayerController FBIOLEEFJMA(int FDGEHEHCGEE)
	{
		PlayerController value;
		JFGDAKMCJAM.TryGetValue(FDGEHEHCGEE, out value);
		if (value == null)
		{
			UnityEngine.Debug.LogError(string.Format(", action = ", FDGEHEHCGEE));
		}
		return value;
	}

	public static PlayerController GetEnemyOf(GHPGNELIDBM ACJIGOBMLNH)
	{
		if (OGMBJPKOPCB.fraction != ACJIGOBMLNH)
		{
			return OGMBJPKOPCB;
		}
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction != ACJIGOBMLNH)
			{
				return item.Value;
			}
		}
		return OGMBJPKOPCB;
	}

	protected override void Update()
	{
		if (KPIGIEPMLLC)
		{
			return;
		}
		base.Update();
		if (JDNNOGPNJLO == KKPHPLOEACG.HidingBehindShield && (NGCDDPCAGJB.position - DJODBMGLPDE).sqrMagnitude > 0.2f)
		{
			DJODBMGLPDE = NGCDDPCAGJB.position;
		}
		if (FHPMANHKAIO != 0f && Time.time > FHPMANHKAIO + 2.5f)
		{
			UnityEngine.Debug.Log("Hide poison");
			KJMFJFCDEDH.Show("game-ico-poison", false, HudObjectIndicator.NPPEJJKFCON.InfoIco);
			FHPMANHKAIO = 0f;
		}
		if (KFLMDLBIMHG && Time.time > BJAPCEOFJBJ)
		{
			KFLMDLBIMHG = false;
			KJMFJFCDEDH.Show("game-ico-blind", false, HudObjectIndicator.NPPEJJKFCON.InfoIco);
		}
		bool flag = fraction == OGMBJPKOPCB.fraction;
		if (EEJMNMHBFEN != 0f && Time.time > EEJMNMHBFEN + 3f && !flag && !Singleton<MatchManager>.instance.isOverTime && !Singleton<GameController>.instance.isTutorial)
		{
			EEJMNMHBFEN = 0f;
			FOCIOKMPCAG.GPLNJOPPKIM.FadeOut();
		}
		if (!FEHCCGEGPLH.isMine && !isCurrentPlayer)
		{
			LADBLHGBOKJ.NFGMGBMCNOF(NGCDDPCAGJB);
			soldierAnimator.transform.localRotation = Quaternion.Slerp(soldierAnimator.transform.localRotation, FBDGMKGIBNO, Time.deltaTime * 12f);
			soldierAnimator.PLCAOODHLCA = true;
		}
		if (weaponInventory.currentWeapon.weapon.isReloading)
		{
			if (weaponInventory.weaponIndex != IJDHJJFOKIO && soldierAnimator.isIdle)
			{
				soldierAnimator.Reload(weaponInventory.currentWeapon.weapon.BEACDIILBEG);
				IJDHJJFOKIO = weaponInventory.weaponIndex;
			}
		}
		else
		{
			IJDHJJFOKIO = null;
		}
		if (Singleton<GameController>.instance.gameIsRunning && FEHCCGEGPLH.isMine && base.isAlive && Singleton<GameController>.instance.gameIsRunning)
		{
			soldierAnimator.PLCAOODHLCA = false;
			if (isCurrentPlayer)
			{
				if (Input.GetMouseButtonDown(0))
				{
					DOMGOLBDMBN = false;
					AimTarget aimTarget = Singleton<AimingHelper>.instance.AimClickableColliders();
					if (aimTarget != null)
					{
						clicked = true;
					}
				}
				if (Singleton<InputController>.instance.swipeEnded && !DOMGOLBDMBN)
				{
					NJKAHEOPIDD = Singleton<InputController>.instance.swipePosition - Singleton<InputController>.instance.pressPosition;
					float num = Vector3.Angle(NJKAHEOPIDD, Vector3.up);
					if (NJKAHEOPIDD.magnitude > (float)Screen.width * 0.05f && num > 70f)
					{
						clicked = true;
						if (NJKAHEOPIDD.x > 0f)
						{
							GoRight();
						}
						else
						{
							GoLeft();
						}
					}
				}
				if (Input.GetMouseButtonUp(0) && DOMGOLBDMBN)
				{
					NJKAHEOPIDD = Input.mousePosition - NJKAHEOPIDD;
					float num2 = Vector3.Angle(NJKAHEOPIDD, Vector3.up);
					if (NJKAHEOPIDD.magnitude > (float)Screen.width * 0.05f && num2 > 60f)
					{
						clicked = true;
						if (NJKAHEOPIDD.x > 0f)
						{
							GoRight();
						}
						else
						{
							GoLeft();
						}
					}
				}
			}
			if (JDNNOGPNJLO == KKPHPLOEACG.Walking && LJPNJJFBMCD != null && NGCDDPCAGJB.position.PlanarDistance(LJPNJJFBMCD.point.transform.position) < 0.05f)
			{
				Vector3 toPos = LJPNJJFBMCD.point.transform.position;
				toPos.y = NGCDDPCAGJB.position.y;
				TweenPosition.Begin(base.gameObject, 0.3f, NGCDDPCAGJB.position, toPos, false);
				playerState = KKPHPLOEACG.HidingBehindShield;
				TweenRotation.Begin(base.gameObject, 0.5f, LJPNJJFBMCD.point.transform.rotation);
				soldierAnimator.lookBack = true;
				Idle();
				ONOLBDPIOND.Disable();
			}
		}
		if (Singleton<GameController>.instance.gameIsRunning && isCurrentPlayer && weaponInventory.currentWeapon.weapon.outOfAmmo && !clicked && Input.GetMouseButton(0))
		{
			GuiScreenSingle<HudScreen>.instance.ShowNoAmmoMagazine(weaponInventory.currentWeapon);
		}
		else if (Singleton<GameController>.instance.gameIsRunning && isCurrentPlayer && weaponInventory.currentWeapon.weapon.NAIKLJKNLAE && weaponInventory.currentWeapon.weapon.isReloading && !clicked && Input.GetMouseButton(0))
		{
			GuiScreenSingle<HudScreen>.instance.ShowReloadingIco(weaponInventory.currentWeapon);
		}
		if (Singleton<GameController>.instance.gameIsRunning && CDBNKOPKCJB && !TimeManager.instance.EEHBPNDBNKC)
		{
			weaponInventory.currentWeapon.UpdateWeapon();
		}
		else if ((TimeManager.instance.EEHBPNDBNKC || !CDBNKOPKCJB) && Input.GetMouseButtonUp(0))
		{
			weaponInventory.currentWeapon.MouseUpAndNoUpdate();
		}
		if (FEHCCGEGPLH.isMine)
		{
			MMMNJDOFMCP();
		}
		if (!FEHCCGEGPLH.isMine)
		{
			soldierAnimator.OGCAPEEHKIM = Mathf.Lerp(soldierAnimator.OGCAPEEHKIM, ELFBJCLMKDN, Time.deltaTime * 12f);
			soldierAnimator.SetUpperBodyRot(soldierAnimator.OGCAPEEHKIM);
		}
	}

	private void AKJMMIGGKFG(PlayerWeapon BJHNACBCNMJ)
	{
		if (playerState == KKPHPLOEACG.HidingBehindShield)
		{
			soldierAnimator.Idle(BJHNACBCNMJ.weapon.BEACDIILBEG);
		}
		else if (BJHNACBCNMJ.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka)
		{
			soldierAnimator.BazookaWalk();
		}
		else
		{
			soldierAnimator.Walk(BJHNACBCNMJ.weapon.BEACDIILBEG);
		}
	}

	public void BBLBLLCMBJG()
	{
		BEIIOAIJMFK().OLHICLNCPNA().gameObject.SetActive(false);
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
	}

	[SpecialName]
	public virtual DestroyableObject NNLPKKGOLMF()
	{
		return FOCIOKMPCAG;
	}

	public void KAHNLANBMKE(float KBJEOEEOEFG)
	{
		object[] array = new object[6];
		array[1] = "NextDailyRewardLocalnotification";
		array[0] = base.name;
		array[6] = "{0}Message-{1}";
		array[2] = Time.time;
		UnityEngine.Debug.Log(string.Concat(array));
		KJMFJFCDEDH.Show("reached max depth!", false, HudObjectIndicator.NPPEJJKFCON.CardIco);
		KFLMDLBIMHG = true;
		BJAPCEOFJBJ = Time.time + KBJEOEEOEFG;
	}

	private void HOAGNCIKKDD(int PLEBANKIBPP)
	{
		if (playerState != KKPHPLOEACG.Walking)
		{
			Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint(base.transform.position);
			Vector3 mPHCNMDIPAI = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			NoMoveIndikator noMoveIndikator = Singleton<ObjectPoolDatabase>.instance.GHGMIFHAOMI.Instantiate(Singleton<ObjectPoolDatabase>.instance.GFJILBKKDFA, mPHCNMDIPAI, Quaternion.identity) as NoMoveIndikator;
			if (noMoveIndikator != null)
			{
				noMoveIndikator.StartAnimation(PLEBANKIBPP);
			}
		}
	}

	public void SelectPrimary()
	{
		PlayerInventory.JIMOKIIJHNA[] array = EHHHBEMKGOE.GGKGGMNIDMI;
		PlayerInventory.JIMOKIIJHNA[] weapons = new PlayerInventory.JIMOKIIJHNA[1] { array[0] };
		weaponInventory.SetWeapons(weapons);
		Singleton<AssetBundleManager>.instance.StartCoroutine(weaponInventory.currentWeapon.LoadWeapon());
	}

	public void ChangeWeightForDestroyablePart(float KMMAKDHKIKH, int DFHAAIFFLOE)
	{
		LAADDLGBFIG.RPC("ChangeWeightForDestroyablePartRPC", PhotonTargets.Others, KMMAKDHKIKH, DFHAAIFFLOE);
		ChangeWeightForDestroyablePartRPC(KMMAKDHKIKH, DFHAAIFFLOE);
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			CLNMMEMKKGO.SendNext(soldierAnimator.NGCDDPCAGJB.localRotation.eulerAngles.y);
			CLNMMEMKKGO.SendNext(soldierAnimator.OGCAPEEHKIM);
			CLNMMEMKKGO.SendNext(playerState);
		}
		else
		{
			LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			float y = (float)CLNMMEMKKGO.ReceiveNext();
			FBDGMKGIBNO = Quaternion.Euler(0f, y, 0f);
			ELFBJCLMKDN = (float)CLNMMEMKKGO.ReceiveNext();
			playerState = (KKPHPLOEACG)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public void DMHKCCPPODF()
	{
		speed = 1713f;
		weaponInventory.HKGLMFFAHFN = true;
		EHHHBEMKGOE.HEPCLFGLCCF();
		soldierAnimator.SetTPose();
		foreach (Collider item in DDGBIBMPEOE)
		{
			item.enabled = false;
		}
		DestroyableObjectpart[] aMEELJHHGKP = FOCIOKMPCAG.AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.GetComponent<Collider>().enabled = true;
		}
		EFFIOHJHFHI.OFBEAKDOCIO.gameObject.SetActive(false);
		EFFIOHJHFHI.DGHPFMPMAFC.MAGLHAOFGHL(false);
		GetComponent<Kevlar>().EAKPIELOAHM();
		weaponInventory.LIEDNEJPLMA = 0;
		DJODBMGLPDE = Vector3.zero;
		if (DNBEAILMLLJ != null)
		{
			HFKEGLEPEFD.material = DNBEAILMLLJ;
		}
		if (FOCIOKMPCAG.GPLNJOPPKIM != null)
		{
			FOCIOKMPCAG.GPLNJOPPKIM.JAJPHIEDLGE();
		}
		KPIGIEPMLLC = false;
		KIIHLIPAGIH = false;
		weaponReloadCoef = 1866f;
		OPCGNNFGFOD = 890f;
		EAOOLOIHKPP = 504f;
		soldierAnimator.Reset();
		JLMDEMFIHCA().PDELKCDEHCC(EHHHBEMKGOE.GGKGGMNIDMI);
		CamosManager.instance.ApplyVisuals(this, EHHHBEMKGOE.CBBDICBLHMM);
		FOCIOKMPCAG.maxHealth = Singleton<GameController>.instance.mainController.GetPlayerHP(this) * EAOOLOIHKPP;
		if (isCurrentPlayer || FEHCCGEGPLH.isMine)
		{
			object[] array = new object[2];
			array[0] = "IDFA";
			array[1] = FOCIOKMPCAG.maxHealth;
			array[0] = "Time_Range_";
			array[2] = EHHHBEMKGOE.MHPNDNJDPGE;
			UnityEngine.Debug.Log(string.Concat(array));
			FOCIOKMPCAG.APJEBOPJPLA();
		}
		else
		{
			FOCIOKMPCAG.RefillOffline();
		}
		base.isAlive = true;
		EFFIOHJHFHI.GDKNBDKAANE(true);
		KCGNHJOLNKD.HCOMKJPBDIO();
		soldierAnimator.Enable();
		soldierAnimator.Reset();
		soldierAnimator.Idle(Weapon.IGGFMJAKLGO.Grenade, true);
		soldierAnimator.lookBack = false;
		CDBNKOPKCJB = false;
		JODNNABEFDH = false;
		FAOHFEPIFGJ = true;
		ONOLBDPIOND.Stop();
		ONOLBDPIOND.Reset();
		playerState = KKPHPLOEACG.Walking;
		KFLMDLBIMHG = true;
		BJAPCEOFJBJ = 1112f;
		if (CMNFFACHCEE() != null && BBNPGJAALCJ().point.PHANADCNBFD() != null)
		{
			BBNPGJAALCJ().point.KJCHIHLJMMF().MIEPCKHJAEL(this);
		}
		if (isCurrentPlayer)
		{
			UICamera.genericEventHandler = base.gameObject;
		}
		foreach (PlayerWeapon item2 in JLMDEMFIHCA().KCGKDDDNONB)
		{
			item2.FMAMBKLFDKH(true);
		}
		foreach (AimTarget item3 in FMLNJGIHJOK)
		{
			item3.gameObject.SetActive(!isCurrentPlayer);
		}
		JEHDCCKBPPD.gameObject.SetActive(isCurrentPlayer);
		FOCIOKMPCAG.healthbarColor = ((OGMBJPKOPCB.fraction == fraction) ? Color.green : Color.red);
		EEJMNMHBFEN = 1998f;
		KJMFJFCDEDH.IJPAEHAGPFK(true);
		AGOGEJNFGEL = 1131f;
		isImmortal = true;
		base.isAlive = false;
		JPMHIGNOPBL.enabled = true;
		ONOLBDPIOND.Disable();
		KJMFJFCDEDH.NGAGGCFIEGJ();
		JFECKJEDJNJ = false;
		COHFDCGJECK = false;
		LMIHBNGHEHM.BJIAOHPEDAP(true);
		LADBLHGBOKJ.MPLPDIGFPBH();
	}

	public void BCOGCFNLPCI(byte JMMJHCOKCGG, bool DNDCODMGGEE)
	{
		if (CLFDBFPKCBJ() == KKPHPLOEACG.HidingBehindShield)
		{
			switch (JMMJHCOKCGG)
			{
			case 0:
				GFCDMMGDFJK().ThrowGrenadeFromCover(DNDCODMGGEE, KAGFCHIAKLG());
				break;
			case 1:
				soldierAnimator.ShootFromBazoka(DNDCODMGGEE, true, 1693f);
				break;
			default:
				GFCDMMGDFJK().ShotFromCover(!DNDCODMGGEE, 1865f, 1900f, true, (Weapon.IGGFMJAKLGO)JMMJHCOKCGG);
				break;
			}
		}
		if (playerState == KKPHPLOEACG.Walking)
		{
			switch (JMMJHCOKCGG)
			{
			case 0:
				soldierAnimator.GDCFMBNGOBL(DNDCODMGGEE, ignoreTimeScale);
				break;
			case 2:
				GFCDMMGDFJK().ShootFromBazokaWalk();
				break;
			default:
				soldierAnimator.ShootStandAdditive(910f);
				break;
			}
		}
	}

	[SpecialName]
	public Vector3 GOEGBNBHGAJ()
	{
		if (Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG != null)
		{
			Vector3 vector = Singleton<MapManager>.instance.ALCHJDPKAID.NOKCDKMHLJG.position - NGCDDPCAGJB.position;
			float num = GeometryTools.AngleSigned(vector, aimForward, Vector3.up);
			if (num > 797f)
			{
				return Quaternion.AngleAxis(905f, -Vector3.up) * aimForward;
			}
			if (num < 384f)
			{
				return Quaternion.AngleAxis(385f, -Vector3.up) * aimForward;
			}
			return vector;
		}
		return base.transform.forward;
	}

	private void FHEMDCFGMMF(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		KJMFJFCDEDH.Hide("game-neardeath-indicator", 0f);
		EFFIOHJHFHI.OFBEAKDOCIO.gameObject.SetActive(false);
		if (base.isAlive)
		{
			PFLKPPMBPKP(OHJPPHFEAFI);
		}
		if (isCurrentPlayer)
		{
			Singleton<GameCamera>.instance.FocusPlayer(this, OHJPPHFEAFI.HNFNINFCBEJ is PlayerController);
		}
		ONOLBDPIOND.Stop();
		DPFHODDILIF(OJIHGNJFPFM, OHJPPHFEAFI);
		Singleton<HitParticleSystem>.instance.HideAllParticles(HitParticles.NNNKFFDDDGP.Blood);
		base.isAlive = false;
	}

	public void KPLKPJJFBOI(float JNHKEAHMAMF)
	{
		AGOGEJNFGEL = JNHKEAHMAMF;
		PhotonView lAADDLGBFIG = LAADDLGBFIG;
		object[] array = new object[1];
		array[1] = JNHKEAHMAMF;
		lAADDLGBFIG.RPC("SquadWarsId", PhotonTargets.All, array);
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
	}

	[SpecialName]
	public bool PBMFJEPBNLE()
	{
		return _003CFLPJGOOPELI_003Ek__BackingField;
	}

	public static List<PlayerController> OCHGFHABDDN(GHPGNELIDBM ACJIGOBMLNH)
	{
		List<PlayerController> list = new List<PlayerController>();
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.fraction != ACJIGOBMLNH && item.Value.LMIHBNGHEHM.LAIPMABCODH())
			{
				list.Add(item.Value);
			}
		}
		return list;
	}

	public void PlayShotAnimation(Weapon.IGGFMJAKLGO JMMJHCOKCGG, bool DNDCODMGGEE, Vector3 PLEBANKIBPP)
	{
		PLEBANKIBPP.y = 0f;
		if (playerState == KKPHPLOEACG.HidingBehindShield)
		{
			switch (JMMJHCOKCGG)
			{
			case Weapon.IGGFMJAKLGO.Grenade:
				soldierAnimator.ThrowGrenadeFromCover(!DNDCODMGGEE, true);
				soldierAnimator.LookAt(PLEBANKIBPP);
				break;
			case Weapon.IGGFMJAKLGO.Bazooka:
				soldierAnimator.ShootFromBazoka(DNDCODMGGEE, true);
				soldierAnimator.LookAt(PLEBANKIBPP, 1.5f);
				break;
			default:
				soldierAnimator.ShotFromCover(!DNDCODMGGEE, 4f, 0.4f, true, JMMJHCOKCGG);
				soldierAnimator.LookAt(PLEBANKIBPP);
				break;
			}
		}
		if (playerState == KKPHPLOEACG.Walking)
		{
			switch (JMMJHCOKCGG)
			{
			case Weapon.IGGFMJAKLGO.Grenade:
				soldierAnimator.ThrowGrenadeFromCover(!DNDCODMGGEE, ignoreTimeScale);
				soldierAnimator.LookAtUpperBody(PLEBANKIBPP);
				break;
			case Weapon.IGGFMJAKLGO.Bazooka:
				soldierAnimator.ShootFromBazokaWalk();
				soldierAnimator.LookAt(PLEBANKIBPP, 0.5f);
				break;
			default:
				soldierAnimator.ShootStandAdditive(0.4f);
				soldierAnimator.LookAtUpperBody(PLEBANKIBPP);
				break;
			}
		}
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("PlayShotAnimationNetwork", PhotonTargets.Others, (byte)JMMJHCOKCGG, DNDCODMGGEE);
		}
	}

	[SpecialName]
	public Vector3 OGNBCFGEEKD()
	{
		return NGCDDPCAGJB.position;
	}

	private void HGNLCILPALK()
	{
		if (!HHHOOCKBIOL && !DHIDLFAHOFJ)
		{
			return;
		}
		if (LJPNJJFBMCD.point.LMHDAIBCLDP().CBKJPJGBHPK == Shield.DLGLDOOFAOA.Success)
		{
			HCOKNKCCPEK(LJPNJJFBMCD);
			if (FEHCCGEGPLH.isMine)
			{
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[0];
				array[1] = CNAOOPEKADN.index;
				fEHCCGEGPLH.RPC("You are about to LEAVE the Arena lobby during matchmaking. This will count as a DEFEAT and you will lose a HEART. Do you really want to leave?", PhotonTargets.All, array);
			}
			HHHOOCKBIOL = false;
			DHIDLFAHOFJ = true;
		}
		if (LJPNJJFBMCD.point.KJCHIHLJMMF().CBKJPJGBHPK != (Shield.DLGLDOOFAOA)6)
		{
			return;
		}
		if (HHHOOCKBIOL)
		{
			GoRight(LJPNJJFBMCD);
			if (!HHHOOCKBIOL)
			{
				LJPNJJFBMCD = EMAMENNDFMB();
				CODLCIPGHMI(LJPNJJFBMCD, 1404f);
			}
		}
		if (DHIDLFAHOFJ)
		{
			ACODFPFBDLI(LJPNJJFBMCD);
			if (!DHIDLFAHOFJ)
			{
				LJPNJJFBMCD = EMAMENNDFMB();
				JIHMNGJCADE(LJPNJJFBMCD, 1198f);
			}
		}
	}

	[SpecialName]
	public void KFFIHKFHACP(PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory IDEBKDPMPGM)
	{
		EHHHBEMKGOE.IPJIPGILEHF = IDEBKDPMPGM;
	}

	public MapDefinition.DefendPosition GoRight()
	{
		if (currentPlayerPoint != null)
		{
			return GoRight(currentPlayerPoint);
		}
		return null;
	}

	[SpecialName]
	public void CMKNJFHHOHA(MapDefinition.DefendPosition IDEBKDPMPGM)
	{
		if (CNAOOPEKADN != null && CNAOOPEKADN.point.shield != null)
		{
			CNAOOPEKADN.point.IGEDGCNJCAP().player = null;
		}
		CNAOOPEKADN = IDEBKDPMPGM;
		if (CNAOOPEKADN != null && CNAOOPEKADN.point.IGEDGCNJCAP() != null)
		{
			CNAOOPEKADN.point.PKBPGCGNCAD().player = this;
		}
	}

	protected virtual void CALILPEEAMB()
	{
		base.Awake();
		JEHDCCKBPPD.POJELIKFDPO = true;
		JEHDCCKBPPD.GHDDFIIJCNN(KMOLMCEBCAI);
		soldierAnimator = GetComponentInChildren<SoldierAnimationController>();
		ONOLBDPIOND = GetComponent<NavigationAgent>();
		weaponInventory = GetComponentInChildren<WeaponInventory>();
		EFFIOHJHFHI = GetComponent<SoldierParts>();
		gameShootableEntity = GetComponent<GameShootableEntity>();
		FMKGGADDHJK().GJLGLEMLNPB(this);
		FOCIOKMPCAG.OnDeath += FHEMDCFGMMF;
		FOCIOKMPCAG.OnDamage += FGNOMDJPILO;
		ODDDGIALOPM(ODCLPMADGFC);
		JDNNOGPNJLO = KKPHPLOEACG.HidingBehindShield;
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		NGCDDPCAGJB = base.transform;
		JLMDEMFIHCA().FABLKHMJKDP(AKJMMIGGKFG);
		PhotonView[] componentsInChildren = GetComponentsInChildren<PhotonView>(true);
		PhotonView[] array = componentsInChildren;
		foreach (PhotonView photonView in array)
		{
			photonView.didAwake = true;
		}
		HFKEGLEPEFD = GetComponentInChildren<SkinnedMeshRenderer>();
		LMIHBNGHEHM = new CKDIHNEIHKL(this);
		JPMHIGNOPBL = GetComponentsInChildren<PlayerBot>()[0];
	}

	public static PlayerController JDFMHAGLBOE(string BNFJCGPPAII)
	{
		foreach (KeyValuePair<int, PlayerController> item in JFGDAKMCJAM)
		{
			if (item.Value.EHHHBEMKGOE.ALIIBMLMNKA == BNFJCGPPAII)
			{
				return item.Value;
			}
		}
		UnityEngine.Debug.LogError(string.Format("Setting squad icon: {0}", BNFJCGPPAII));
		return null;
	}

	[SpecialName]
	private void EAJMOAFGJJM(KKPHPLOEACG IDEBKDPMPGM)
	{
		if (JDNNOGPNJLO != IDEBKDPMPGM)
		{
			JDNNOGPNJLO = IDEBKDPMPGM;
			if (KCECODPHBLE != null)
			{
				KCECODPHBLE(IDEBKDPMPGM);
			}
		}
	}

	public static PlayerController GetPlayer(int FDGEHEHCGEE)
	{
		PlayerController value;
		JFGDAKMCJAM.TryGetValue(FDGEHEHCGEE, out value);
		if (value == null)
		{
			UnityEngine.Debug.LogError(string.Format("Player with id {0} doesnt exists ! ", FDGEHEHCGEE));
		}
		return value;
	}

	[SpecialName]
	public virtual void FDHJCAGOFKN(Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> IDEBKDPMPGM)
	{
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action = FJHBCIAKBPF;
		Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref FJHBCIAKBPF, (Action<NKMKCCDCHCL, DestroyableObject.CJLNCMMNPBM>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void MoveTo(Vector3 MDOPFNNFLFB, Quaternion NICKNMCOFGI)
	{
		NGCDDPCAGJB.position = CHNFEKECAPB(MDOPFNNFLFB);
		NGCDDPCAGJB.rotation = NICKNMCOFGI;
		ONOLBDPIOND.SetDestination(MDOPFNNFLFB);
	}

	[SpecialName]
	public void IJCLEDDBAFB(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		EHHHBEMKGOE.IFEIEMFFMPE(IDEBKDPMPGM);
	}

	public void HDEPEAIJFJK(float JNHKEAHMAMF)
	{
		AGOGEJNFGEL = JNHKEAHMAMF;
	}

	public void DLJFMKKDMNN(int DFHAAIFFLOE, int IEALLELGOBM)
	{
		JLMDEMFIHCA().LAGONJMBJMM[DFHAAIFFLOE].HFNAMMBPJAJ().ammoLeft += IEALLELGOBM;
	}

	protected virtual void DPFHODDILIF(DestroyableObject BDAKFIFCHLB, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		if (FJHBCIAKBPF != null)
		{
			FJHBCIAKBPF(this, LLAOOPMGBAG);
		}
	}

	public MapDefinition.DefendPosition GoRight(MapDefinition.DefendPosition PLMMBKGLGAB)
	{
		if (JFECKJEDJNJ || !base.isAlive || !Singleton<GameController>.instance.gameIsRunning)
		{
			return null;
		}
		HHHOOCKBIOL = false;
		DHIDLFAHOFJ = false;
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		int num = 0;
		for (num = 0; num < availablePoints.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[num];
			if (defendPosition == PLMMBKGLGAB)
			{
				break;
			}
		}
		if (num < availablePoints.Count - 1)
		{
			for (int i = num + 1; i < availablePoints.Count; i++)
			{
				if (availablePoints[i].fraction == fraction && availablePoints[i].point.shield.player == null)
				{
					HHHOOCKBIOL = true;
					LJPNJJFBMCD = availablePoints[i];
					LJPNJJFBMCD.point.shield.GetLock();
					CODLCIPGHMI(LJPNJJFBMCD);
					return LJPNJJFBMCD;
				}
			}
		}
		HOAGNCIKKDD(1);
		return null;
	}

	[SpecialName]
	public MapDefinition.DefendPosition BBNPGJAALCJ()
	{
		return CNAOOPEKADN;
	}

	private void DOGLPIFJNBJ(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		BattleAnalyticsManager.instance.EFDKNNDMONF(this, OHJPPHFEAFI);
		if (DebugSettings.debugPlayerDamage)
		{
			FOCIOKMPCAG.GPLNJOPPKIM.ICMIAECNIHC(OHJPPHFEAFI.EPDELOGPNAC.ToString());
		}
		else
		{
			FOCIOKMPCAG.GPLNJOPPKIM.SetText(string.Empty);
		}
		if (isCurrentPlayer)
		{
			MainGameEntity mainGameEntity = OHJPPHFEAFI.HNFNINFCBEJ as MainGameEntity;
			if (mainGameEntity != null && mainGameEntity != this)
			{
				mainGameEntity.SetRevenge();
			}
		}
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
		{
			PlayerController playerController = OHJPPHFEAFI.HNFNINFCBEJ as PlayerController;
			if (playerController != null)
			{
				Transform gHPBMCAKMMB = playerController.weaponInventory.APLKMLDHMDL().HFNAMMBPJAJ().GHPBMCAKMMB;
				HCIHCKHMEMA(OHJPPHFEAFI, gHPBMCAKMMB.transform.position, 1412f);
			}
			else
			{
				EnemyController enemyController = OHJPPHFEAFI.HNFNINFCBEJ as EnemyController;
				if (enemyController != null)
				{
					Transform gHPBMCAKMMB2 = enemyController.soldierBehaviour.KHKAAGCIJPO.GHPBMCAKMMB;
					HCIHCKHMEMA(OHJPPHFEAFI, gHPBMCAKMMB2.transform.position, 339f);
				}
				else
				{
					Drone drone = OHJPPHFEAFI.HNFNINFCBEJ as Drone;
					if (drone != null)
					{
						Transform gHPBMCAKMMB3 = drone.JMMJHCOKCGG.JMMJHCOKCGG.GHPBMCAKMMB;
						HCIHCKHMEMA(OHJPPHFEAFI, gHPBMCAKMMB3.transform.position, 1019f);
					}
					else
					{
						Turret turret = OHJPPHFEAFI.HNFNINFCBEJ as Turret;
						if (turret != null)
						{
							HCIHCKHMEMA(OHJPPHFEAFI, turret.KAIGJFPMEKL.EDLANLCFCBC.JMMJHCOKCGG.GHPBMCAKMMB.transform.position, 823f);
						}
					}
				}
			}
		}
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
		{
			KJMFJFCDEDH.GGHDIAFACAH("Managers", true, HudObjectIndicator.NPPEJJKFCON.InfoIco);
			FHPMANHKAIO = Time.time;
		}
		if ((UnityEngine.Random.value < AGOGEJNFGEL || OHJPPHFEAFI.HNFNINFCBEJ == this) && !OHJPPHFEAFI.KLOJNPBGFIG && !isImmortal)
		{
			DestroyableObjectPlayer fOCIOKMPCAG = FOCIOKMPCAG;
			fOCIOKMPCAG.GMNNGEELOFC(fOCIOKMPCAG.health + OHJPPHFEAFI.EPDELOGPNAC);
			return;
		}
		if (FOCIOKMPCAG.healthRatio < 863f && ((isCurrentPlayer && Singleton<GameController>.instance.BAKCODKBCPJ()) || KIIHLIPAGIH))
		{
			DestroyableObjectPlayer fOCIOKMPCAG2 = FOCIOKMPCAG;
			fOCIOKMPCAG2.GMNNGEELOFC(fOCIOKMPCAG2.health + OHJPPHFEAFI.EPDELOGPNAC);
		}
		if (isCurrentPlayer)
		{
			if (OHJPPHFEAFI.EPDELOGPNAC > 405f)
			{
				float nIMFNNMAKPA = 1082f;
				if (OHJPPHFEAFI.FJLBLLLEELD != DestroyableObject.MANAGOLPMLH.Basic && OHJPPHFEAFI.FJLBLLLEELD != DestroyableObject.MANAGOLPMLH.Basic)
				{
					Singleton<GameCamera>.instance.HitShake();
					DestroyableObject.MANAGOLPMLH fJLBLLLEELD = OHJPPHFEAFI.FJLBLLLEELD;
					if (fJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot || fJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Suicide)
					{
						JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareMedium);
					}
					else
					{
						JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateLight);
					}
					Component component = OHJPPHFEAFI.HNFNINFCBEJ as Component;
					if (component != null)
					{
						nIMFNNMAKPA = GeometryTools.AngleSigned(component.transform.position - NGCDDPCAGJB.position, Camera.main.transform.forward, Vector3.up);
					}
				}
				GuiScreenSingle<HudScreen>.instance.DNADPJJMBPA(OHJPPHFEAFI.EPDELOGPNAC, nIMFNNMAKPA);
			}
		}
		else
		{
			FOCIOKMPCAG.GPLNJOPPKIM.Enable();
			FOCIOKMPCAG.GPLNJOPPKIM.FFKLDOCLBDA(28f);
		}
		EEJMNMHBFEN = Time.time;
		KJMFJFCDEDH.Show("setGender", AONLENLHDMD() && isCurrentPlayer, HudObjectIndicator.NPPEJJKFCON.CardIco);
	}

	public void MNLDBAHNIJN(float KBJEOEEOEFG)
	{
		object[] array = new object[4];
		array[1] = "Beanstalk Server Manager: Found Player Progress = ";
		array[1] = base.name;
		array[3] = "S";
		array[2] = Time.time;
		UnityEngine.Debug.Log(string.Concat(array));
		KJMFJFCDEDH.GGHDIAFACAH("Reward", true, HudObjectIndicator.NPPEJJKFCON.CardIco);
		KFLMDLBIMHG = true;
		BJAPCEOFJBJ = Time.time + KBJEOEEOEFG;
	}

	[SpecialName]
	public void MKDHCPCIDPN(PlayerVisualCategoryCamos.PlayerVisualCamo IDEBKDPMPGM)
	{
		EHHHBEMKGOE.FPEAGGJIMEC(IDEBKDPMPGM);
	}

	private void PFLKPPMBPKP(DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		Rigidbody component = EFFIOHJHFHI.CGCKDIBIFFI.GetComponent<Rigidbody>();
		DestroyableObjectpart[] aMEELJHHGKP = FOCIOKMPCAG.AMEELJHHGKP;
		foreach (DestroyableObjectpart destroyableObjectpart in aMEELJHHGKP)
		{
			if (destroyableObjectpart.GetComponent<Rigidbody>() == null)
			{
				destroyableObjectpart.GetComponent<Collider>().enabled = false;
			}
		}
		foreach (Collider item in DDGBIBMPEOE)
		{
			item.enabled = true;
		}
		SetLayerRecursively(KCGNHJOLNKD.gameObject, TagsAndLayers.KFLGCPACECP);
		TimeManager.instance.SetupPhysicsTiming(true);
		soldierAnimator.Stop();
		KCGNHJOLNKD.GoRagdoll();
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion)
		{
			Vector3 vector = new Vector3(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f), 0f);
			component.AddForce(OHJPPHFEAFI.LPGMLOCLBGP * 3f, ForceMode.Impulse);
			component.AddTorque(vector.x, vector.y, vector.z, ForceMode.Impulse);
		}
		else
		{
			Vector3 force = OHJPPHFEAFI.LPGMLOCLBGP * 6f + Vector3.up * OHJPPHFEAFI.LPGMLOCLBGP.magnitude * 0.6f;
			component.AddForce(force, ForceMode.Impulse);
		}
	}

	private void MCJHKKOMHAE()
	{
		if (base.gameObject.activeSelf && fraction == OGMBJPKOPCB.fraction && DebugSettings.instance.data.showPlayerHealthBar)
		{
			FOCIOKMPCAG.GPLNJOPPKIM.Enable();
			FOCIOKMPCAG.GPLNJOPPKIM.HOOEPGICNOH(970f);
		}
	}

	private void BJDPHFKKEGI(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, float KBJEOEEOEFG)
	{
		Singleton<ShotTrailRenderer>.instance.EOICPDKHNDN(OEIICEJPGKI, IIMDKHJAJGO, KBJEOEEOEFG);
	}

	[SpecialName]
	public virtual void DGOHHNOLLIJ(KMHCMCBGFFC IDEBKDPMPGM)
	{
	}

	private void MHEIPDIINEH(DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		Rigidbody component = EFFIOHJHFHI.CGCKDIBIFFI.GetComponent<Rigidbody>();
		DestroyableObjectpart[] aMEELJHHGKP = FOCIOKMPCAG.AMEELJHHGKP;
		for (int i = 0; i < aMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			if (destroyableObjectpart.GetComponent<Rigidbody>() == null)
			{
				destroyableObjectpart.GetComponent<Collider>().enabled = true;
			}
		}
		foreach (Collider item in DDGBIBMPEOE)
		{
			item.enabled = true;
		}
		SetLayerRecursively(KCGNHJOLNKD.gameObject, TagsAndLayers.KFLGCPACECP);
		TimeManager.instance.SetupPhysicsTiming(false);
		soldierAnimator.Stop();
		KCGNHJOLNKD.BLGNILNMCGE();
		if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot)
		{
			Vector3 vector = new Vector3(UnityEngine.Random.Range(1202f, 1064f), UnityEngine.Random.Range(1299f, 1907f), 787f);
			component.AddForce(OHJPPHFEAFI.LPGMLOCLBGP * 516f, ForceMode.Impulse);
			component.AddTorque(vector.x, vector.y, vector.z, ForceMode.Impulse);
		}
		else
		{
			Vector3 force = OHJPPHFEAFI.LPGMLOCLBGP * 553f + Vector3.up * OHJPPHFEAFI.LPGMLOCLBGP.magnitude * 52f;
			component.AddForce(force, ForceMode.Force);
		}
	}

	[SpecialName]
	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory CLHGHKLHCBB()
	{
		return EHHHBEMKGOE.CDHEMGFFCCP();
	}
}
