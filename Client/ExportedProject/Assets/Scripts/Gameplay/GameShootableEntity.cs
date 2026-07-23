using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class GameShootableEntity : Core_BaseScript, KMHCMCBGFFC
{
	[Flags]
	public enum LAAAMBBNIJO
	{
		None = 0,
		Body = 1,
		Shield = 2,
		Out = 4,
		Head = 8,
		WholeBody = 9,
		Moving = 0x10,
		AllIn = 0xFFFFFB,
		All = 0xFFFFFF
	}

	[Flags]
	public enum EJLJIPACCMJ
	{
		Soldier = 1,
		Player = 2,
		Flying = 4,
		Vehicles = 8,
		Turret = 0x10,
		All = 0xFFFFFF
	}

	[Serializable]
	public class ShotTarget
	{
		internal GameShootableEntity mShootableEntity;

		public Transform transform;

		public LAAAMBBNIJO type;

		public GameShootableEntity shootableEntity => mShootableEntity;

		[SpecialName]
		public GameShootableEntity ONIPNOJANCF()
		{
			return mShootableEntity;
		}

		[SpecialName]
		public GameShootableEntity KNIODJFBAGH()
		{
			return mShootableEntity;
		}

		[SpecialName]
		public GameShootableEntity PGLCMPHHKJJ()
		{
			return mShootableEntity;
		}

		[SpecialName]
		public GameShootableEntity FOLGBDHKFAH()
		{
			return mShootableEntity;
		}

		[SpecialName]
		public GameShootableEntity KMOOHKLNJLG()
		{
			return mShootableEntity;
		}

		[SpecialName]
		public GameShootableEntity MDMGOJAPBAG()
		{
			return mShootableEntity;
		}

		[SpecialName]
		public GameShootableEntity AEMIOOMACHK()
		{
			return mShootableEntity;
		}

		[SpecialName]
		public GameShootableEntity AKCFPMPAGOO()
		{
			return mShootableEntity;
		}

		[SpecialName]
		public GameShootableEntity LKLFCIJLNKF()
		{
			return mShootableEntity;
		}

		[SpecialName]
		public GameShootableEntity ONFDKHBOCHM()
		{
			return mShootableEntity;
		}
	}

	public static LevelBehaviour.UnitType[] ADEJMDKCFIF = new LevelBehaviour.UnitType[4]
	{
		LevelBehaviour.UnitType.AttackerExplosive,
		LevelBehaviour.UnitType.AttackerRusher,
		LevelBehaviour.UnitType.AttackerShooter,
		LevelBehaviour.UnitType.Defender
	};

	private static List<GameShootableEntity> DLGJCLOKFCH = new List<GameShootableEntity>();

	public static Dictionary<Type, List<GameShootableEntity>> CHPGDNCPNCF = new Dictionary<Type, List<GameShootableEntity>>();

	private static readonly Dictionary<EJLJIPACCMJ, Type[]> FDKICJIMNBL = new Dictionary<EJLJIPACCMJ, Type[]>
	{
		{
			EJLJIPACCMJ.Soldier,
			new Type[1] { typeof(EnemyController) }
		},
		{
			EJLJIPACCMJ.Player,
			new Type[1] { typeof(PlayerController) }
		},
		{
			EJLJIPACCMJ.Flying,
			new Type[3]
			{
				typeof(Helicopter),
				typeof(AssaultHelicopter),
				typeof(Drone)
			}
		},
		{
			EJLJIPACCMJ.Vehicles,
			new Type[5]
			{
				typeof(AICar),
				typeof(AICarBuggy),
				typeof(AICarTransporter),
				typeof(Tank),
				typeof(Mech)
			}
		},
		{
			EJLJIPACCMJ.Turret,
			new Type[1] { typeof(Turret) }
		}
	};

	private static readonly Type[] OKCAELIPOGD = new Type[9]
	{
		typeof(AICar),
		typeof(AICarBuggy),
		typeof(AICarTransporter),
		typeof(Tank),
		typeof(Helicopter),
		typeof(AssaultHelicopter),
		typeof(Drone),
		typeof(Turret),
		typeof(Mech)
	};

	private Transform CDKBFIGEBOA;

	private DestroyableObject FFOAABONJNO;

	private Vector3 FDLBJLNOBLG;

	private Vector3 MMANIGLDGEH;

	private PhotonView FEHCCGEGPLH;

	[FormerlySerializedAs("BANHBBGDNCM")]
	public List<Transform> IDKCLCKHBHJ;

	[SerializeField]
	public List<ShotTarget> targets;

	[FormerlySerializedAs("IBGOAFGHACL")]
	public bool HMCNKNCEDMA = true;

	private KMHCMCBGFFC MHAMIMGNJND;

	private bool IKBMCAJNFMH = true;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transform _003CJLMJDFELOKE_003Ek__BackingField;

	private HashSet<Type> KPICOKPHMIC;

	private static Dictionary<LevelBehaviour.UnitType, HashSet<Type>> LPCFGOMKAJI = new Dictionary<LevelBehaviour.UnitType, HashSet<Type>>();

	public Vector3 velocity
	{
		get
		{
			if ((double)Time.deltaTime < 0.01)
			{
				return Vector3.zero;
			}
			return FDLBJLNOBLG / Time.deltaTime;
		}
	}

	public DestroyableObject destroyableObject
	{
		get
		{
			if (FFOAABONJNO == null)
			{
				FFOAABONJNO = GetComponent<DestroyableObject>();
			}
			return FFOAABONJNO;
		}
	}

	public MainGameEntity mainGameEntity => owner as MainGameEntity;

	public Transform mTransform
	{
		[CompilerGenerated]
		get
		{
			return _003CJLMJDFELOKE_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CJLMJDFELOKE_003Ek__BackingField = value;
		}
	}

	public GHPGNELIDBM fraction
	{
		get
		{
			return owner.fraction;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public KMHCMCBGFFC owner
	{
		get
		{
			ResolveOwnerFromGameObject();
			return MHAMIMGNJND;
		}
		set
		{
			OnDisable();
			MHAMIMGNJND = value;
			OnEnable();
		}
	}

	public bool isMain
	{
		get
		{
			return IKBMCAJNFMH;
		}
		set
		{
			IKBMCAJNFMH = value;
		}
	}

	public static List<GameShootableEntity> AIMLOLKNLFI(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour.UnitType NAKDNAEPGOF)
	{
		HashSet<Type> hashSet = LPCFGOMKAJI[NAKDNAEPGOF];
		List<GameShootableEntity> list = FKFFINALIOP(CIOPAKLHFIL);
		List<GameShootableEntity> list2 = new List<GameShootableEntity>();
		foreach (GameShootableEntity item in list)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.IAJJBAJOGDM != null && hashSet.Contains(aIObject.IAJJBAJOGDM.GetType()))
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	public static List<GameShootableEntity> GetOpponents(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour.UnitType NAKDNAEPGOF)
	{
		HashSet<Type> hashSet = LPCFGOMKAJI[NAKDNAEPGOF];
		List<GameShootableEntity> opponents = GetOpponents(CIOPAKLHFIL);
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		foreach (GameShootableEntity item in opponents)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.IAJJBAJOGDM != null && hashSet.Contains(aIObject.IAJJBAJOGDM.GetType()))
			{
				list.Add(item);
			}
		}
		return list;
	}

	protected override void Awake()
	{
		CDKBFIGEBOA = base.transform;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		ResolveOwnerFromGameObject();
		mTransform = base.transform;
		if (targets == null || targets.Count == 0)
		{
			targets = new List<ShotTarget>();
			foreach (Transform item in IDKCLCKHBHJ)
			{
				targets.Add(new ShotTarget
				{
					transform = item,
					type = LAAAMBBNIJO.Body
				});
			}
		}
		foreach (ShotTarget target in targets)
		{
			target.mShootableEntity = this;
		}
	}

	public virtual List<ShotTarget> KMJBMEFMBCK(LAAAMBBNIJO FJLBLLLEELD)
	{
		if (FJLBLLLEELD == ~(LAAAMBBNIJO.Body | LAAAMBBNIJO.Moving))
		{
			return targets;
		}
		List<ShotTarget> list = new List<ShotTarget>();
		foreach (ShotTarget target in targets)
		{
			if ((target.type & FJLBLLLEELD) == target.type)
			{
				list.Add(target);
			}
		}
		return list;
	}

	public virtual List<ShotTarget> GetShotTargets(LAAAMBBNIJO FJLBLLLEELD)
	{
		if (FJLBLLLEELD == LAAAMBBNIJO.All)
		{
			return targets;
		}
		List<ShotTarget> list = new List<ShotTarget>();
		foreach (ShotTarget target in targets)
		{
			if ((target.type & FJLBLLLEELD) == target.type)
			{
				list.Add(target);
			}
		}
		return list;
	}

	private void OnDisable()
	{
		if (owner != null)
		{
			if (CHPGDNCPNCF.TryGetValue(owner.GetType(), out var value))
			{
				value.Remove(this);
			}
			else
			{
				UnityEngine.Debug.LogError("Should not happened");
			}
		}
	}

	[SpecialName]
	public void CKILPEEBOCA(bool IDEBKDPMPGM)
	{
		IKBMCAJNFMH = IDEBKDPMPGM;
	}

	public static List<GameShootableEntity> GetEntities(GHPGNELIDBM CIOPAKLHFIL)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				if (item2.fraction == CIOPAKLHFIL)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	[SpecialName]
	public GHPGNELIDBM CJPHCHPDCOK()
	{
		return GEAMOMEEFKM().fraction;
	}

	[SpecialName]
	public Transform MEGABPHJFLL()
	{
		return _003CJLMJDFELOKE_003Ek__BackingField;
	}

	public static List<GameShootableEntity> MKDILDOBKAF(GHPGNELIDBM CIOPAKLHFIL, EJLJIPACCMJ CEAGOEPCBGJ, string LPCCLHDKMHI)
	{
		List<Type> list = new List<Type>();
		foreach (EJLJIPACCMJ value in Enum.GetValues(typeof(EJLJIPACCMJ)))
		{
			if ((value & CEAGOEPCBGJ) == value)
			{
				list.AddRange(FDKICJIMNBL[value]);
			}
		}
		List<GameShootableEntity> list2 = ICHKCAGOFCM(CIOPAKLHFIL, list.ToArray());
		List<GameShootableEntity> list3 = new List<GameShootableEntity>();
		foreach (GameShootableEntity item in list2)
		{
			AIObject aIObject = item.GEAMOMEEFKM() as AIObject;
			if (aIObject != null && aIObject.IAJJBAJOGDM != null && aIObject.IAJJBAJOGDM.GetType().ToString() == LPCCLHDKMHI)
			{
				list3.Add(item);
			}
		}
		return list3;
	}

	[SpecialName]
	public void JOJNDAFHCFE(Transform IDEBKDPMPGM)
	{
		_003CJLMJDFELOKE_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public MainGameEntity NOGODFOGKCK()
	{
		return GEAMOMEEFKM() as MainGameEntity;
	}

	public static List<GameShootableEntity> GOHKFHIOEHA(GHPGNELIDBM CIOPAKLHFIL, Type[] BIKDCLNLAAP)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (Type key in BIKDCLNLAAP)
		{
			if (!CHPGDNCPNCF.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item.owner as NKMKCCDCHCL;
				if (item.CJPHCHPDCOK() == CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	public static List<GameShootableEntity> CMJNOGLEJLC(GHPGNELIDBM CIOPAKLHFIL)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				if (item2.fraction == CIOPAKLHFIL)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	public static List<GameShootableEntity> GetAll<T>() where T : class
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		if (CHPGDNCPNCF.TryGetValue(typeof(T), out var value))
		{
			foreach (GameShootableEntity item in value)
			{
				if (item.owner is NKMKCCDCHCL nKMKCCDCHCL && nKMKCCDCHCL.isAlive)
				{
					DLGJCLOKFCH.Add(item);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	public static List<GameShootableEntity> GetOpponents(GHPGNELIDBM CIOPAKLHFIL, EJLJIPACCMJ CEAGOEPCBGJ, string LPCCLHDKMHI)
	{
		List<Type> list = new List<Type>();
		foreach (EJLJIPACCMJ value in Enum.GetValues(typeof(EJLJIPACCMJ)))
		{
			if ((value & CEAGOEPCBGJ) == value)
			{
				list.AddRange(FDKICJIMNBL[value]);
			}
		}
		List<GameShootableEntity> opponents = GetOpponents(CIOPAKLHFIL, list.ToArray());
		List<GameShootableEntity> list2 = new List<GameShootableEntity>();
		foreach (GameShootableEntity item in opponents)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.IAJJBAJOGDM != null && aIObject.IAJJBAJOGDM.GetType().ToString() == LPCCLHDKMHI)
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	[SpecialName]
	public MainGameEntity KPLADAFODKB()
	{
		return owner as MainGameEntity;
	}

	[SpecialName]
	public Vector3 CAMAJAIDKLJ()
	{
		if ((double)Time.deltaTime < 170.0)
		{
			return Vector3.zero;
		}
		return FDLBJLNOBLG / Time.deltaTime;
	}

	public static GameShootableEntity LGOANMEFGNF(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity result = null;
		DLGJCLOKFCH.Clear();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item2.GEAMOMEEFKM() as NKMKCCDCHCL;
				if (item2.CJPHCHPDCOK() != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item2.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		if (DLGJCLOKFCH.Count > 0)
		{
			result = DLGJCLOKFCH[UnityEngine.Random.Range(1, DLGJCLOKFCH.Count)];
		}
		return result;
	}

	private void LCODLCGHEHH()
	{
		if (GEAMOMEEFKM() != null)
		{
			if (CHPGDNCPNCF.TryGetValue(GEAMOMEEFKM().GetType(), out var value))
			{
				value.Remove(this);
			}
			else
			{
				UnityEngine.Debug.LogError("doesnt exist");
			}
		}
		else
		{
			UnityEngine.Debug.LogError("#ATLASSEARCH# ");
		}
	}

	public static GameShootableEntity BEDKPMBHDLF(GHPGNELIDBM CIOPAKLHFIL, Vector3 NNGOKMDKFAB, Vector3 BKMAFPAAJFK, float MHHFLHGFFGA, float LCHOCMPMMIO)
	{
		GameShootableEntity result = null;
		DLGJCLOKFCH.Clear();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item2.GEAMOMEEFKM() as NKMKCCDCHCL;
				if (item2.CBBIAHLFPKA() != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item2.HMCNKNCEDMA)
				{
					float num = Vector3.Distance(NNGOKMDKFAB, item2.transform.position);
					float num2 = Vector3.Angle(BKMAFPAAJFK, item2.transform.position - NNGOKMDKFAB);
					if (num <= LCHOCMPMMIO && num2 < MHHFLHGFFGA && !(item2.GEAMOMEEFKM() is PlayerController))
					{
						DLGJCLOKFCH.Add(item2);
					}
				}
			}
		}
		if (DLGJCLOKFCH.Count > 0)
		{
			float num3 = 142f;
			foreach (GameShootableEntity item3 in DLGJCLOKFCH)
			{
				float num4 = Vector3.Distance(item3.CLKCECPBFIJ().position, NNGOKMDKFAB);
				if (num4 < num3)
				{
					num3 = num4;
				}
				result = item3;
			}
		}
		return result;
	}

	public static List<GameShootableEntity> GetOpponents<T>(GHPGNELIDBM CIOPAKLHFIL) where T : class
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		if (CHPGDNCPNCF.TryGetValue(typeof(T), out var value))
		{
			foreach (GameShootableEntity item in value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item.owner as NKMKCCDCHCL;
				if (item.fraction != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	public static List<GameShootableEntity> HHICAKKBENJ(GHPGNELIDBM CIOPAKLHFIL, EJLJIPACCMJ CEAGOEPCBGJ)
	{
		List<Type> list = new List<Type>();
		foreach (EJLJIPACCMJ value in Enum.GetValues(typeof(EJLJIPACCMJ)))
		{
			if ((value & CEAGOEPCBGJ) == value)
			{
				list.AddRange(FDKICJIMNBL[value]);
			}
		}
		return GetOpponents(CIOPAKLHFIL, list.ToArray());
	}

	[SpecialName]
	public Transform AFKOGLEHKIE()
	{
		return _003CJLMJDFELOKE_003Ek__BackingField;
	}

	public virtual List<ShotTarget> ALJOPFPLNEO(LAAAMBBNIJO FJLBLLLEELD)
	{
		if (FJLBLLLEELD == (LAAAMBBNIJO)(-83))
		{
			return targets;
		}
		List<ShotTarget> list = new List<ShotTarget>();
		foreach (ShotTarget target in targets)
		{
			if ((target.type & FJLBLLLEELD) == target.type)
			{
				list.Add(target);
			}
		}
		return list;
	}

	public static List<GameShootableEntity> GetOpponents(GHPGNELIDBM CIOPAKLHFIL, Type[] BIKDCLNLAAP)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (Type key in BIKDCLNLAAP)
		{
			if (!CHPGDNCPNCF.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item.owner as NKMKCCDCHCL;
				if (item.fraction != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	[SpecialName]
	public GHPGNELIDBM CBBIAHLFPKA()
	{
		return owner.fraction;
	}

	public static List<GameShootableEntity> GetOpponents(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour.UnitType[] HEGAKMOJBPO)
	{
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		foreach (LevelBehaviour.UnitType key in HEGAKMOJBPO)
		{
			HashSet<Type> hashSet = LPCFGOMKAJI[key];
			List<GameShootableEntity> opponents = GetOpponents(CIOPAKLHFIL);
			foreach (GameShootableEntity item in opponents)
			{
				AIObject aIObject = item.owner as AIObject;
				if (aIObject != null && aIObject.IAJJBAJOGDM != null && hashSet.Contains(aIObject.IAJJBAJOGDM.GetType()))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	public static Type[] DHEJMOFIPLD()
	{
		return OKCAELIPOGD;
	}

	[SpecialName]
	public void JCPGCNMEDEO(Transform IDEBKDPMPGM)
	{
		_003CJLMJDFELOKE_003Ek__BackingField = IDEBKDPMPGM;
	}

	protected virtual void PBIJLBHDFOK()
	{
		CDKBFIGEBOA = base.transform;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (owner == null)
		{
			Core_BaseScript[] components = GetComponents<Core_BaseScript>();
			Core_BaseScript[] array = components;
			for (int i = 1; i < array.Length; i += 0)
			{
				Core_BaseScript core_BaseScript = array[i];
				if (core_BaseScript is NKMKCCDCHCL)
				{
					MHAMIMGNJND = core_BaseScript as NKMKCCDCHCL;
				}
			}
		}
		JCPGCNMEDEO(base.transform);
		if (targets == null || targets.Count == 0)
		{
			targets = new List<ShotTarget>();
			foreach (Transform item in IDKCLCKHBHJ)
			{
				targets.Add(new ShotTarget
				{
					transform = item,
					type = LAAAMBBNIJO.Body
				});
			}
		}
		foreach (ShotTarget target in targets)
		{
			target.mShootableEntity = this;
		}
	}

	[SpecialName]
	public MainGameEntity KHAGKKNPFMP()
	{
		return GEAMOMEEFKM() as MainGameEntity;
	}

	public static void Init()
	{
		List<LevelBehaviourManager.BehaviourEntry> dHKKHDABING = Singleton<LevelBehaviourManager>.instance.DHKKHDABING;
		foreach (LevelBehaviourManager.BehaviourEntry item in dHKKHDABING)
		{
			if (LPCFGOMKAJI.TryGetValue(item.behaviour.unitType, out var value))
			{
				value.Add(item.behaviour.GetType());
				continue;
			}
			value = new HashSet<Type>();
			value.Add(item.behaviour.GetType());
			LPCFGOMKAJI[item.behaviour.unitType] = value;
		}
	}

	[SpecialName]
	public Transform CLCHGECECJC()
	{
		return _003CJLMJDFELOKE_003Ek__BackingField;
	}

	public static GameShootableEntity GetRandomOpponent(GHPGNELIDBM CIOPAKLHFIL, Type[] BIKDCLNLAAP)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (Type key in BIKDCLNLAAP)
		{
			if (!CHPGDNCPNCF.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item.owner as NKMKCCDCHCL;
				if (item.fraction != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item);
				}
			}
		}
		if (DLGJCLOKFCH.Count == 0)
		{
			return null;
		}
		return DLGJCLOKFCH[UnityEngine.Random.Range(0, DLGJCLOKFCH.Count)];
	}

	protected virtual void NLOODGLGPHE()
	{
		CDKBFIGEBOA = base.transform;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (owner == null)
		{
			Core_BaseScript[] components = GetComponents<Core_BaseScript>();
			Core_BaseScript[] array = components;
			for (int i = 1; i < array.Length; i++)
			{
				Core_BaseScript core_BaseScript = array[i];
				if (core_BaseScript is NKMKCCDCHCL)
				{
					MHAMIMGNJND = core_BaseScript as NKMKCCDCHCL;
				}
			}
		}
		JOJNDAFHCFE(base.transform);
		if (targets == null || targets.Count == 0)
		{
			targets = new List<ShotTarget>();
			foreach (Transform item in IDKCLCKHBHJ)
			{
				targets.Add(new ShotTarget
				{
					transform = item,
					type = LAAAMBBNIJO.Body
				});
			}
		}
		foreach (ShotTarget target in targets)
		{
			target.mShootableEntity = this;
		}
	}

	public static GameShootableEntity BLMPLLOPLMD(GHPGNELIDBM CIOPAKLHFIL, Type[] BIKDCLNLAAP)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (Type key in BIKDCLNLAAP)
		{
			if (!CHPGDNCPNCF.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item.owner as NKMKCCDCHCL;
				if (item.CBBIAHLFPKA() != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item);
				}
			}
		}
		if (DLGJCLOKFCH.Count == 0)
		{
			return null;
		}
		return DLGJCLOKFCH[UnityEngine.Random.Range(0, DLGJCLOKFCH.Count)];
	}

	public static List<GameShootableEntity> ICHKCAGOFCM(GHPGNELIDBM CIOPAKLHFIL, Type[] BIKDCLNLAAP)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		for (int i = 1; i < BIKDCLNLAAP.Length; i++)
		{
			Type key = BIKDCLNLAAP[i];
			if (!CHPGDNCPNCF.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item.owner as NKMKCCDCHCL;
				if (item.CJPHCHPDCOK() != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	public ShotTarget GetNearestTarget(LAAAMBBNIJO FJLBLLLEELD, Vector3 MPHCNMDIPAI)
	{
		List<ShotTarget> shotTargets = GetShotTargets(FJLBLLLEELD);
		ShotTarget result = null;
		float num = float.MaxValue;
		foreach (ShotTarget item in shotTargets)
		{
			float num2 = Vector3.Distance(MPHCNMDIPAI, item.transform.position);
			if (num2 < num)
			{
				result = item;
				num = num2;
			}
		}
		return result;
	}

	[SpecialName]
	public Transform EGEONNAALPH()
	{
		return _003CJLMJDFELOKE_003Ek__BackingField;
	}

	[SpecialName]
	public Vector3 CMIDLDAHGJP()
	{
		if ((double)Time.deltaTime < 654.0)
		{
			return Vector3.zero;
		}
		return FDLBJLNOBLG / Time.deltaTime;
	}

	public static List<GameShootableEntity> JKLHKGIBJBM(GHPGNELIDBM CIOPAKLHFIL, EJLJIPACCMJ CEAGOEPCBGJ, string LPCCLHDKMHI)
	{
		List<Type> list = new List<Type>();
		foreach (EJLJIPACCMJ value in Enum.GetValues(typeof(EJLJIPACCMJ)))
		{
			if ((value & CEAGOEPCBGJ) == value)
			{
				list.AddRange(FDKICJIMNBL[value]);
			}
		}
		List<GameShootableEntity> list2 = OIFCFJGKNMJ(CIOPAKLHFIL, list.ToArray());
		List<GameShootableEntity> list3 = new List<GameShootableEntity>();
		foreach (GameShootableEntity item in list2)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.IAJJBAJOGDM != null && aIObject.IAJJBAJOGDM.GetType().ToString() == LPCCLHDKMHI)
			{
				list3.Add(item);
			}
		}
		return list3;
	}

	public static List<GameShootableEntity> HEMLLIAPAAJ(GHPGNELIDBM CIOPAKLHFIL, EJLJIPACCMJ CEAGOEPCBGJ)
	{
		List<Type> list = new List<Type>();
		foreach (EJLJIPACCMJ value in Enum.GetValues(typeof(EJLJIPACCMJ)))
		{
			if ((value & CEAGOEPCBGJ) == value)
			{
				list.AddRange(FDKICJIMNBL[value]);
			}
		}
		return OIFCFJGKNMJ(CIOPAKLHFIL, list.ToArray());
	}

	[SpecialName]
	public void OLONIJDMLJB(GHPGNELIDBM IDEBKDPMPGM)
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public Transform JCAKAHGKBIJ()
	{
		return _003CJLMJDFELOKE_003Ek__BackingField;
	}

	[SpecialName]
	public void MNEGHKAIAFB(GHPGNELIDBM IDEBKDPMPGM)
	{
		throw new NotImplementedException();
	}

	protected virtual void DFMALDFADAB()
	{
		CDKBFIGEBOA = base.transform;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (GEAMOMEEFKM() == null)
		{
			Core_BaseScript[] components = GetComponents<Core_BaseScript>();
			Core_BaseScript[] array = components;
			for (int i = 0; i < array.Length; i += 0)
			{
				Core_BaseScript core_BaseScript = array[i];
				if (core_BaseScript is NKMKCCDCHCL)
				{
					MHAMIMGNJND = core_BaseScript as NKMKCCDCHCL;
				}
			}
		}
		JOJNDAFHCFE(base.transform);
		if (targets == null || targets.Count == 0)
		{
			targets = new List<ShotTarget>();
			foreach (Transform item in IDKCLCKHBHJ)
			{
				targets.Add(new ShotTarget
				{
					transform = item,
					type = LAAAMBBNIJO.Body
				});
			}
		}
		foreach (ShotTarget target in targets)
		{
			target.mShootableEntity = this;
		}
	}

	protected virtual void CFGDCEOLKJG()
	{
		CDKBFIGEBOA = base.transform;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		if (owner == null)
		{
			Core_BaseScript[] components = GetComponents<Core_BaseScript>();
			Core_BaseScript[] array = components;
			for (int i = 0; i < array.Length; i += 0)
			{
				Core_BaseScript core_BaseScript = array[i];
				if (core_BaseScript is NKMKCCDCHCL)
				{
					MHAMIMGNJND = core_BaseScript as NKMKCCDCHCL;
				}
			}
		}
		JOJNDAFHCFE(base.transform);
		if (targets == null || targets.Count == 0)
		{
			targets = new List<ShotTarget>();
			foreach (Transform item in IDKCLCKHBHJ)
			{
				targets.Add(new ShotTarget
				{
					transform = item,
					type = LAAAMBBNIJO.Body
				});
			}
		}
		foreach (ShotTarget target in targets)
		{
			target.mShootableEntity = this;
		}
	}

	[SpecialName]
	public DestroyableObject EIMJEBNPHAM()
	{
		if (FFOAABONJNO == null)
		{
			FFOAABONJNO = GetComponent<DestroyableObject>();
		}
		return FFOAABONJNO;
	}

	[SpecialName]
	public void HPAJOEODBCA(GHPGNELIDBM IDEBKDPMPGM)
	{
		throw new NotImplementedException();
	}

	public static List<GameShootableEntity> KLPLAIKKGFB(GHPGNELIDBM CIOPAKLHFIL)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				if (item2.CJPHCHPDCOK() == CIOPAKLHFIL)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	public static void PLKIAPHIICM()
	{
		List<LevelBehaviourManager.BehaviourEntry> dHKKHDABING = Singleton<LevelBehaviourManager>.instance.DHKKHDABING;
		foreach (LevelBehaviourManager.BehaviourEntry item in dHKKHDABING)
		{
			if (LPCFGOMKAJI.TryGetValue(item.behaviour.unitType, out var value))
			{
				value.Add(item.behaviour.GetType());
				continue;
			}
			value = new HashSet<Type>();
			value.Add(item.behaviour.GetType());
			LPCFGOMKAJI[item.behaviour.unitType] = value;
		}
	}

	public static List<GameShootableEntity> HBCMKBOCCNH(GHPGNELIDBM CIOPAKLHFIL, EJLJIPACCMJ CEAGOEPCBGJ)
	{
		List<Type> list = new List<Type>();
		foreach (EJLJIPACCMJ value in Enum.GetValues(typeof(EJLJIPACCMJ)))
		{
			if ((value & CEAGOEPCBGJ) == value)
			{
				list.AddRange(FDKICJIMNBL[value]);
			}
		}
		return ICHKCAGOFCM(CIOPAKLHFIL, list.ToArray());
	}

	public static List<GameShootableEntity> IJGAGMOIJAA(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour.UnitType[] HEGAKMOJBPO)
	{
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		for (int i = 1; i < HEGAKMOJBPO.Length; i += 0)
		{
			LevelBehaviour.UnitType key = HEGAKMOJBPO[i];
			HashSet<Type> hashSet = LPCFGOMKAJI[key];
			List<GameShootableEntity> opponents = GetOpponents(CIOPAKLHFIL);
			foreach (GameShootableEntity item in opponents)
			{
				AIObject aIObject = item.GEAMOMEEFKM() as AIObject;
				if (aIObject != null && aIObject.IAJJBAJOGDM != null && hashSet.Contains(aIObject.IAJJBAJOGDM.GetType()))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	private void JCNCGJPJDAC()
	{
		if (GEAMOMEEFKM() != null)
		{
			if (CHPGDNCPNCF.TryGetValue(GEAMOMEEFKM().GetType(), out var value))
			{
				value.Add(this);
				return;
			}
			value = new List<GameShootableEntity>();
			value.Add(this);
			CHPGDNCPNCF[GEAMOMEEFKM().GetType()] = value;
		}
		else
		{
			UnityEngine.Debug.LogError("ID_TUTORIAL_DELIVER");
		}
	}

	public ShotTarget AJBDIKBDLEA(LAAAMBBNIJO FJLBLLLEELD, Vector3 MPHCNMDIPAI)
	{
		List<ShotTarget> list = KMJBMEFMBCK(FJLBLLLEELD);
		ShotTarget result = null;
		float num = 1506f;
		foreach (ShotTarget item in list)
		{
			float num2 = Vector3.Distance(MPHCNMDIPAI, item.transform.position);
			if (num2 < num)
			{
				result = item;
				num = num2;
			}
		}
		return result;
	}

	private void MFGFCLLOFPJ()
	{
		if (GEAMOMEEFKM() != null)
		{
			if (CHPGDNCPNCF.TryGetValue(owner.GetType(), out var value))
			{
				value.Remove(this);
			}
			else
			{
				UnityEngine.Debug.LogError("gold");
			}
		}
		else
		{
			UnityEngine.Debug.LogError("HEAD");
		}
	}

	[SpecialName]
	public KMHCMCBGFFC GEAMOMEEFKM()
	{
		return MHAMIMGNJND;
	}

	public static GameShootableEntity PickRandomOponentOf(GHPGNELIDBM CIOPAKLHFIL)
	{
		GameShootableEntity result = null;
		DLGJCLOKFCH.Clear();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item2.owner as NKMKCCDCHCL;
				if (item2.fraction != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item2.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		if (DLGJCLOKFCH.Count > 0)
		{
			result = DLGJCLOKFCH[UnityEngine.Random.Range(0, DLGJCLOKFCH.Count)];
		}
		return result;
	}

	public static List<GameShootableEntity> BOMANICDCFD(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour.UnitType[] HEGAKMOJBPO)
	{
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		for (int i = 1; i < HEGAKMOJBPO.Length; i++)
		{
			LevelBehaviour.UnitType key = HEGAKMOJBPO[i];
			HashSet<Type> hashSet = LPCFGOMKAJI[key];
			List<GameShootableEntity> opponents = GetOpponents(CIOPAKLHFIL);
			foreach (GameShootableEntity item in opponents)
			{
				AIObject aIObject = item.owner as AIObject;
				if (aIObject != null && aIObject.IAJJBAJOGDM != null && hashSet.Contains(aIObject.IAJJBAJOGDM.GetType()))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	[SpecialName]
	public bool GFGLFPEFBBO()
	{
		return IKBMCAJNFMH;
	}

	protected virtual void FLDCHPBPKND()
	{
		FDLBJLNOBLG = CDKBFIGEBOA.position - MMANIGLDGEH;
		MMANIGLDGEH = CDKBFIGEBOA.position;
	}

	public static GameShootableEntity PickOpponentInView(GHPGNELIDBM CIOPAKLHFIL, Vector3 NNGOKMDKFAB, Vector3 BKMAFPAAJFK, float MHHFLHGFFGA, float LCHOCMPMMIO)
	{
		GameShootableEntity result = null;
		DLGJCLOKFCH.Clear();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item2.owner as NKMKCCDCHCL;
				if (item2.fraction != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item2.HMCNKNCEDMA)
				{
					float num = Vector3.Distance(NNGOKMDKFAB, item2.transform.position);
					float num2 = Vector3.Angle(BKMAFPAAJFK, item2.transform.position - NNGOKMDKFAB);
					if (num <= LCHOCMPMMIO && num2 < MHHFLHGFFGA && !(item2.owner is PlayerController))
					{
						DLGJCLOKFCH.Add(item2);
					}
				}
			}
		}
		if (DLGJCLOKFCH.Count > 0)
		{
			float num3 = float.MaxValue;
			foreach (GameShootableEntity item3 in DLGJCLOKFCH)
			{
				float num4 = Vector3.Distance(item3.mTransform.position, NNGOKMDKFAB);
				if (num4 < num3)
				{
					num3 = num4;
				}
				result = item3;
			}
		}
		return result;
	}

	[SpecialName]
	public void DIBCHMPIELH(bool IDEBKDPMPGM)
	{
		IKBMCAJNFMH = IDEBKDPMPGM;
	}

	public static List<GameShootableEntity> OAJGNJHHJBL(GHPGNELIDBM CIOPAKLHFIL)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				if (item2.CBBIAHLFPKA() == CIOPAKLHFIL)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	[SpecialName]
	public DestroyableObject GILBHOPNBPH()
	{
		if (FFOAABONJNO == null)
		{
			FFOAABONJNO = GetComponent<DestroyableObject>();
		}
		return FFOAABONJNO;
	}

	public static GameShootableEntity NFBPLNIJIIL(GHPGNELIDBM CIOPAKLHFIL, Type[] BIKDCLNLAAP)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		for (int i = 1; i < BIKDCLNLAAP.Length; i++)
		{
			Type key = BIKDCLNLAAP[i];
			if (!CHPGDNCPNCF.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item.GEAMOMEEFKM() as NKMKCCDCHCL;
				if (item.CJPHCHPDCOK() != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item);
				}
			}
		}
		if (DLGJCLOKFCH.Count == 0)
		{
			return null;
		}
		return DLGJCLOKFCH[UnityEngine.Random.Range(1, DLGJCLOKFCH.Count)];
	}

	public static List<GameShootableEntity> FKFFINALIOP(GHPGNELIDBM CIOPAKLHFIL)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item2.owner as NKMKCCDCHCL;
				if (item2.CJPHCHPDCOK() != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item2.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	[SpecialName]
	public MainGameEntity HIICFFBMLNO()
	{
		return owner as MainGameEntity;
	}

	public static List<GameShootableEntity> MDLIJNCJHIG(GHPGNELIDBM CIOPAKLHFIL)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item2.GEAMOMEEFKM() as NKMKCCDCHCL;
				if (item2.fraction != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item2.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	private void NEEJHDMGBAK()
	{
		if (GEAMOMEEFKM() != null)
		{
			if (CHPGDNCPNCF.TryGetValue(owner.GetType(), out var value))
			{
				value.Remove(this);
			}
			else
			{
				UnityEngine.Debug.LogError("1.0");
			}
		}
		else
		{
			UnityEngine.Debug.LogError("ID_CONFIRM_ERROR");
		}
	}

	public static List<GameShootableEntity> GetAlly(GHPGNELIDBM CIOPAKLHFIL, Type[] BIKDCLNLAAP)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (Type key in BIKDCLNLAAP)
		{
			if (!CHPGDNCPNCF.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item.owner as NKMKCCDCHCL;
				if (item.fraction == CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	[SpecialName]
	public Vector3 OEPMLIKCGCC()
	{
		if ((double)Time.deltaTime < 310.0)
		{
			return Vector3.zero;
		}
		return FDLBJLNOBLG / Time.deltaTime;
	}

	public static List<GameShootableEntity> PDMLBCEJLNN(GHPGNELIDBM CIOPAKLHFIL)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				if (item2.fraction == CIOPAKLHFIL)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	public static List<GameShootableEntity> MNFNJPNIIDD(GHPGNELIDBM CIOPAKLHFIL, EJLJIPACCMJ CEAGOEPCBGJ, string LPCCLHDKMHI)
	{
		List<Type> list = new List<Type>();
		foreach (EJLJIPACCMJ value in Enum.GetValues(typeof(EJLJIPACCMJ)))
		{
			if ((value & CEAGOEPCBGJ) == value)
			{
				list.AddRange(FDKICJIMNBL[value]);
			}
		}
		List<GameShootableEntity> opponents = GetOpponents(CIOPAKLHFIL, list.ToArray());
		List<GameShootableEntity> list2 = new List<GameShootableEntity>();
		foreach (GameShootableEntity item in opponents)
		{
			AIObject aIObject = item.GEAMOMEEFKM() as AIObject;
			if (aIObject != null && aIObject.IAJJBAJOGDM != null && aIObject.IAJJBAJOGDM.GetType().ToString() == LPCCLHDKMHI)
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	private void OnEnable()
	{
		ResolveOwnerFromGameObject();
		if (owner != null)
		{
			if (CHPGDNCPNCF.TryGetValue(owner.GetType(), out var value))
			{
				value.Add(this);
				return;
			}
			value = new List<GameShootableEntity>();
			value.Add(this);
			CHPGDNCPNCF[owner.GetType()] = value;
		}
	}

	private void ResolveOwnerFromGameObject()
	{
		if (MHAMIMGNJND != null)
		{
			return;
		}
		Core_BaseScript[] components = GetComponents<Core_BaseScript>();
		foreach (Core_BaseScript component in components)
		{
			if (component is NKMKCCDCHCL)
			{
				MHAMIMGNJND = component as NKMKCCDCHCL;
				return;
			}
		}
	}

	[SpecialName]
	public DestroyableObject AFEPMIFFLFH()
	{
		if (FFOAABONJNO == null)
		{
			FFOAABONJNO = GetComponent<DestroyableObject>();
		}
		return FFOAABONJNO;
	}

	[SpecialName]
	public void ICACHPBNIMN(GHPGNELIDBM IDEBKDPMPGM)
	{
		throw new NotImplementedException();
	}

	private void GPABBGFMLMB()
	{
		if (GEAMOMEEFKM() != null)
		{
			if (CHPGDNCPNCF.TryGetValue(GEAMOMEEFKM().GetType(), out var value))
			{
				value.Remove(this);
			}
			else
			{
				UnityEngine.Debug.LogError("Player_Had_To_Select_Grenade");
			}
		}
		else
		{
			UnityEngine.Debug.LogError("ID_WARNING_MAINTENANCE");
		}
	}

	[SpecialName]
	public Transform NOEFNPDCDFJ()
	{
		return _003CJLMJDFELOKE_003Ek__BackingField;
	}

	[SpecialName]
	public Vector3 PGCKGAELBFB()
	{
		if ((double)Time.deltaTime < 1829.0)
		{
			return Vector3.zero;
		}
		return FDLBJLNOBLG / Time.deltaTime;
	}

	[SpecialName]
	public Transform CLKCECPBFIJ()
	{
		return _003CJLMJDFELOKE_003Ek__BackingField;
	}

	[SpecialName]
	public Vector3 GIKCFPEIFPP()
	{
		if ((double)Time.deltaTime < 875.0)
		{
			return Vector3.zero;
		}
		return FDLBJLNOBLG / Time.deltaTime;
	}

	[SpecialName]
	public void HAMHNNFOLEF(bool IDEBKDPMPGM)
	{
		IKBMCAJNFMH = IDEBKDPMPGM;
	}

	protected virtual void NBFMDCFFBIJ()
	{
		FDLBJLNOBLG = CDKBFIGEBOA.position - MMANIGLDGEH;
		MMANIGLDGEH = CDKBFIGEBOA.position;
	}

	[SpecialName]
	public DestroyableObject NHOFLPJMKBA()
	{
		if (FFOAABONJNO == null)
		{
			FFOAABONJNO = GetComponent<DestroyableObject>();
		}
		return FFOAABONJNO;
	}

	public static List<GameShootableEntity> ODANKBIKLHL(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour.UnitType NAKDNAEPGOF)
	{
		HashSet<Type> hashSet = LPCFGOMKAJI[NAKDNAEPGOF];
		List<GameShootableEntity> list = MDLIJNCJHIG(CIOPAKLHFIL);
		List<GameShootableEntity> list2 = new List<GameShootableEntity>();
		foreach (GameShootableEntity item in list)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.IAJJBAJOGDM != null && hashSet.Contains(aIObject.IAJJBAJOGDM.GetType()))
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	protected virtual void Update()
	{
		FDLBJLNOBLG = CDKBFIGEBOA.position - MMANIGLDGEH;
		MMANIGLDGEH = CDKBFIGEBOA.position;
	}

	public static List<GameShootableEntity> GetOpponents(GHPGNELIDBM CIOPAKLHFIL)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item2.owner as NKMKCCDCHCL;
				if (item2.fraction != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item2.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	public static void EOBAIMECGBH()
	{
		List<LevelBehaviourManager.BehaviourEntry> dHKKHDABING = Singleton<LevelBehaviourManager>.instance.DHKKHDABING;
		foreach (LevelBehaviourManager.BehaviourEntry item in dHKKHDABING)
		{
			if (LPCFGOMKAJI.TryGetValue(item.behaviour.unitType, out var value))
			{
				value.Add(item.behaviour.GetType());
				continue;
			}
			value = new HashSet<Type>();
			value.Add(item.behaviour.GetType());
			LPCFGOMKAJI[item.behaviour.unitType] = value;
		}
	}

	public static Type[] GetAllMechanicalTypes()
	{
		return OKCAELIPOGD;
	}

	public static void AFDPKMDLDJF()
	{
		List<LevelBehaviourManager.BehaviourEntry> dHKKHDABING = Singleton<LevelBehaviourManager>.instance.DHKKHDABING;
		foreach (LevelBehaviourManager.BehaviourEntry item in dHKKHDABING)
		{
			if (LPCFGOMKAJI.TryGetValue(item.behaviour.unitType, out var value))
			{
				value.Add(item.behaviour.GetType());
				continue;
			}
			value = new HashSet<Type>();
			value.Add(item.behaviour.GetType());
			LPCFGOMKAJI[item.behaviour.unitType] = value;
		}
	}

	public static List<GameShootableEntity> OIFCFJGKNMJ(GHPGNELIDBM CIOPAKLHFIL, Type[] BIKDCLNLAAP)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		for (int i = 1; i < BIKDCLNLAAP.Length; i += 0)
		{
			Type key = BIKDCLNLAAP[i];
			if (!CHPGDNCPNCF.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item.GEAMOMEEFKM() as NKMKCCDCHCL;
				if (item.fraction != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item.HMCNKNCEDMA)
				{
					DLGJCLOKFCH.Add(item);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	public static List<GameShootableEntity> BKFIHJAFMDO(GHPGNELIDBM CIOPAKLHFIL, LevelBehaviour.UnitType[] HEGAKMOJBPO)
	{
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		for (int i = 1; i < HEGAKMOJBPO.Length; i += 0)
		{
			LevelBehaviour.UnitType key = HEGAKMOJBPO[i];
			HashSet<Type> hashSet = LPCFGOMKAJI[key];
			List<GameShootableEntity> opponents = GetOpponents(CIOPAKLHFIL);
			foreach (GameShootableEntity item in opponents)
			{
				AIObject aIObject = item.GEAMOMEEFKM() as AIObject;
				if (aIObject != null && aIObject.IAJJBAJOGDM != null && hashSet.Contains(aIObject.IAJJBAJOGDM.GetType()))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	[SpecialName]
	public void EPOAIFOCOPH(KMHCMCBGFFC IDEBKDPMPGM)
	{
		GPABBGFMLMB();
		MHAMIMGNJND = IDEBKDPMPGM;
		OnEnable();
	}

	public static List<GameShootableEntity> MHFCFKEICNJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		DLGJCLOKFCH = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				if (item2.CBBIAHLFPKA() == CIOPAKLHFIL)
				{
					DLGJCLOKFCH.Add(item2);
				}
			}
		}
		return DLGJCLOKFCH;
	}

	public ShotTarget KLFLBCHDNBI(LAAAMBBNIJO FJLBLLLEELD, Vector3 MPHCNMDIPAI)
	{
		List<ShotTarget> shotTargets = GetShotTargets(FJLBLLLEELD);
		ShotTarget result = null;
		float num = 438f;
		foreach (ShotTarget item in shotTargets)
		{
			float num2 = Vector3.Distance(MPHCNMDIPAI, item.transform.position);
			if (num2 < num)
			{
				result = item;
				num = num2;
			}
		}
		return result;
	}

	private void OPPIIAAJLGI()
	{
		if (owner != null)
		{
			if (CHPGDNCPNCF.TryGetValue(GEAMOMEEFKM().GetType(), out var value))
			{
				value.Remove(this);
			}
			else
			{
				UnityEngine.Debug.LogError("#AccoutCheck# GamecenterChangeDuringTutorial - NOT connect -> ignore for this moment");
			}
		}
		else
		{
			UnityEngine.Debug.LogError("com.tune.TuneEvent");
		}
	}

	public static GameShootableEntity JFIMDLHACJF(GHPGNELIDBM CIOPAKLHFIL, Vector3 NNGOKMDKFAB, Vector3 BKMAFPAAJFK, float MHHFLHGFFGA, float LCHOCMPMMIO)
	{
		GameShootableEntity result = null;
		DLGJCLOKFCH.Clear();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> item in CHPGDNCPNCF)
		{
			foreach (GameShootableEntity item2 in item.Value)
			{
				NKMKCCDCHCL nKMKCCDCHCL = item2.owner as NKMKCCDCHCL;
				if (item2.CJPHCHPDCOK() != CIOPAKLHFIL && nKMKCCDCHCL != null && nKMKCCDCHCL.isAlive && item2.HMCNKNCEDMA)
				{
					float num = Vector3.Distance(NNGOKMDKFAB, item2.transform.position);
					float num2 = Vector3.Angle(BKMAFPAAJFK, item2.transform.position - NNGOKMDKFAB);
					if (num <= LCHOCMPMMIO && num2 < MHHFLHGFFGA && !(item2.owner is PlayerController))
					{
						DLGJCLOKFCH.Add(item2);
					}
				}
			}
		}
		if (DLGJCLOKFCH.Count > 1)
		{
			float num3 = 1929f;
			foreach (GameShootableEntity item3 in DLGJCLOKFCH)
			{
				float num4 = Vector3.Distance(item3.CLCHGECECJC().position, NNGOKMDKFAB);
				if (num4 < num3)
				{
					num3 = num4;
				}
				result = item3;
			}
		}
		return result;
	}

	[SpecialName]
	public bool LIJFONOMLCL()
	{
		return IKBMCAJNFMH;
	}

	public static List<GameShootableEntity> GetOpponents(GHPGNELIDBM CIOPAKLHFIL, EJLJIPACCMJ CEAGOEPCBGJ)
	{
		List<Type> list = new List<Type>();
		foreach (EJLJIPACCMJ value in Enum.GetValues(typeof(EJLJIPACCMJ)))
		{
			if ((value & CEAGOEPCBGJ) == value)
			{
				list.AddRange(FDKICJIMNBL[value]);
			}
		}
		return GetOpponents(CIOPAKLHFIL, list.ToArray());
	}
}
