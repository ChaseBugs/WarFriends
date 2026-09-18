using System;
using System.Collections.Generic;
using UnityEngine;

public class GameShootableEntity : Core_BaseScript, IFraction
{
	[Flags]
	public enum ShotTargetType
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
	public enum Target
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

		public ShotTargetType type;

		public GameShootableEntity shootableEntity => mShootableEntity;
	}

	public static LevelBehaviour.UnitType[] anyUnit = new LevelBehaviour.UnitType[4]
	{
		LevelBehaviour.UnitType.AttackerExplosive,
		LevelBehaviour.UnitType.AttackerRusher,
		LevelBehaviour.UnitType.AttackerShooter,
		LevelBehaviour.UnitType.Defender
	};

	private static List<GameShootableEntity> mHelpList = new List<GameShootableEntity>();

	public static Dictionary<Type, List<GameShootableEntity>> generatedEntities = new Dictionary<Type, List<GameShootableEntity>>();

	private static readonly Dictionary<Target, Type[]> mTargets = new Dictionary<Target, Type[]>
	{
		{
			Target.Soldier,
			new Type[1] { typeof(EnemyController) }
		},
		{
			Target.Player,
			new Type[1] { typeof(PlayerController) }
		},
		{
			Target.Flying,
			new Type[3]
			{
				typeof(Helicopter),
				typeof(AssaultHelicopter),
				typeof(Drone)
			}
		},
		{
			Target.Vehicles,
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
			Target.Turret,
			new Type[1] { typeof(Turret) }
		}
	};

	private static readonly Type[] mMechanicalTypesArray = new Type[9]
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

	private Transform mCachedTransform;

	private DestroyableObject mDestroyableObject;

	private Vector3 mDiff;

	private Vector3 mLastPosition;

	private PhotonView mPhotonView;

	public List<Transform> shootTargets;

	[SerializeField]
	public List<ShotTarget> targets;

	public bool visible = true;

	private IFraction mOwner;

	private bool mIsMain = true;

	private HashSet<Type> t;

	private static Dictionary<LevelBehaviour.UnitType, HashSet<Type>> behavioursByType = new Dictionary<LevelBehaviour.UnitType, HashSet<Type>>();

	public Vector3 velocity
	{
		get
		{
			if ((double)Time.deltaTime < 0.01)
			{
				return Vector3.zero;
			}
			return mDiff / Time.deltaTime;
		}
	}

	public DestroyableObject destroyableObject
	{
		get
		{
			if (mDestroyableObject == null)
			{
				mDestroyableObject = GetComponent<DestroyableObject>();
			}
			return mDestroyableObject;
		}
	}

	public MainGameEntity mainGameEntity => owner as MainGameEntity;

	public Transform mTransform { get; set; }

	public Fractions fraction
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

	public IFraction owner
	{
		get
		{
			return mOwner;
		}
		set
		{
			OnDisable();
			mOwner = value;
			OnEnable();
		}
	}

	public bool isMain
	{
		get
		{
			return mIsMain;
		}
		set
		{
			mIsMain = value;
		}
	}

	protected virtual void Update()
	{
		mDiff = mCachedTransform.position - mLastPosition;
		mLastPosition = mCachedTransform.position;
	}

	protected override void Awake()
	{
		mCachedTransform = base.transform;
		mPhotonView = GetComponent<PhotonView>();
		if (owner == null)
		{
			Core_BaseScript[] components = GetComponents<Core_BaseScript>();
			Core_BaseScript[] array = components;
			foreach (Core_BaseScript core_BaseScript in array)
			{
				if (core_BaseScript is IGameMainEntity)
				{
					mOwner = core_BaseScript as IGameMainEntity;
				}
			}
		}
		mTransform = base.transform;
		if (targets == null || targets.Count == 0)
		{
			targets = new List<ShotTarget>();
			foreach (Transform shootTarget in shootTargets)
			{
				targets.Add(new ShotTarget
				{
					transform = shootTarget,
					type = ShotTargetType.Body
				});
			}
		}
		foreach (ShotTarget target in targets)
		{
			target.mShootableEntity = this;
		}
	}

	public static GameShootableEntity PickRandomOponentOf(Fractions fraction)
	{
		GameShootableEntity result = null;
		mHelpList.Clear();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> generatedEntity in generatedEntities)
		{
			foreach (GameShootableEntity item in generatedEntity.Value)
			{
				IGameMainEntity gameMainEntity = item.owner as IGameMainEntity;
				if (item.fraction != fraction && gameMainEntity != null && gameMainEntity.isAlive && item.visible)
				{
					mHelpList.Add(item);
				}
			}
		}
		if (mHelpList.Count > 0)
		{
			result = mHelpList[UnityEngine.Random.Range(0, mHelpList.Count)];
		}
		return result;
	}

	public static GameShootableEntity PickOpponentInView(Fractions fraction, Vector3 fromPos, Vector3 forward, float maxAngle, float maxDistance)
	{
		GameShootableEntity result = null;
		mHelpList.Clear();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> generatedEntity in generatedEntities)
		{
			foreach (GameShootableEntity item in generatedEntity.Value)
			{
				IGameMainEntity gameMainEntity = item.owner as IGameMainEntity;
				if (item.fraction != fraction && gameMainEntity != null && gameMainEntity.isAlive && item.visible)
				{
					float num = Vector3.Distance(fromPos, item.transform.position);
					float num2 = Vector3.Angle(forward, item.transform.position - fromPos);
					if (num <= maxDistance && num2 < maxAngle && !(item.owner is PlayerController))
					{
						mHelpList.Add(item);
					}
				}
			}
		}
		if (mHelpList.Count > 0)
		{
			float num3 = float.MaxValue;
			foreach (GameShootableEntity mHelp in mHelpList)
			{
				float num4 = Vector3.Distance(mHelp.mTransform.position, fromPos);
				if (num4 < num3)
				{
					num3 = num4;
				}
				result = mHelp;
			}
		}
		return result;
	}

	public static List<GameShootableEntity> GetEntities(Fractions fraction)
	{
		mHelpList = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> generatedEntity in generatedEntities)
		{
			foreach (GameShootableEntity item in generatedEntity.Value)
			{
				if (item.fraction == fraction)
				{
					mHelpList.Add(item);
				}
			}
		}
		return mHelpList;
	}

	public static List<GameShootableEntity> GetOpponents(Fractions fraction)
	{
		mHelpList = new List<GameShootableEntity>();
		foreach (KeyValuePair<Type, List<GameShootableEntity>> generatedEntity in generatedEntities)
		{
			foreach (GameShootableEntity item in generatedEntity.Value)
			{
				IGameMainEntity gameMainEntity = item.owner as IGameMainEntity;
				if (item.fraction != fraction && gameMainEntity != null && gameMainEntity.isAlive && item.visible)
				{
					mHelpList.Add(item);
				}
			}
		}
		return mHelpList;
	}

	public static List<GameShootableEntity> GetOpponents<T>(Fractions fraction) where T : class
	{
		mHelpList = new List<GameShootableEntity>();
		if (generatedEntities.TryGetValue(typeof(T), out var value))
		{
			foreach (GameShootableEntity item in value)
			{
				IGameMainEntity gameMainEntity = item.owner as IGameMainEntity;
				if (item.fraction != fraction && gameMainEntity != null && gameMainEntity.isAlive && item.visible)
				{
					mHelpList.Add(item);
				}
			}
		}
		return mHelpList;
	}

	public static Type[] GetAllMechanicalTypes()
	{
		return mMechanicalTypesArray;
	}

	public static List<GameShootableEntity> GetOpponents(Fractions fraction, Type[] types)
	{
		mHelpList = new List<GameShootableEntity>();
		foreach (Type key in types)
		{
			if (!generatedEntities.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				IGameMainEntity gameMainEntity = item.owner as IGameMainEntity;
				if (item.fraction != fraction && gameMainEntity != null && gameMainEntity.isAlive && item.visible)
				{
					mHelpList.Add(item);
				}
			}
		}
		return mHelpList;
	}

	public static List<GameShootableEntity> GetOpponents(Fractions fraction, Target targets)
	{
		List<Type> list = new List<Type>();
		foreach (int value in Enum.GetValues(typeof(Target)))
		{
			if (((uint)value & (uint)targets) == (uint)value)
			{
				list.AddRange(mTargets[(Target)value]);
			}
		}
		return GetOpponents(fraction, list.ToArray());
	}

	public static List<GameShootableEntity> GetOpponents(Fractions fraction, Target targets, string behaviourName)
	{
		List<Type> list = new List<Type>();
		foreach (int value in Enum.GetValues(typeof(Target)))
		{
			if (((uint)value & (uint)targets) == (uint)value)
			{
				list.AddRange(mTargets[(Target)value]);
			}
		}
		List<GameShootableEntity> opponents = GetOpponents(fraction, list.ToArray());
		List<GameShootableEntity> list2 = new List<GameShootableEntity>();
		foreach (GameShootableEntity item in opponents)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.preparedBehaviour != null && aIObject.preparedBehaviour.GetType().ToString() == behaviourName)
			{
				list2.Add(item);
			}
		}
		return list2;
	}

	public static List<GameShootableEntity> GetAlly(Fractions fraction, Type[] types)
	{
		mHelpList = new List<GameShootableEntity>();
		foreach (Type key in types)
		{
			if (!generatedEntities.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				IGameMainEntity gameMainEntity = item.owner as IGameMainEntity;
				if (item.fraction == fraction && gameMainEntity != null && gameMainEntity.isAlive && item.visible)
				{
					mHelpList.Add(item);
				}
			}
		}
		return mHelpList;
	}

	public static GameShootableEntity GetRandomOpponent(Fractions fraction, Type[] types)
	{
		mHelpList = new List<GameShootableEntity>();
		foreach (Type key in types)
		{
			if (!generatedEntities.TryGetValue(key, out var value))
			{
				continue;
			}
			foreach (GameShootableEntity item in value)
			{
				IGameMainEntity gameMainEntity = item.owner as IGameMainEntity;
				if (item.fraction != fraction && gameMainEntity != null && gameMainEntity.isAlive && item.visible)
				{
					mHelpList.Add(item);
				}
			}
		}
		if (mHelpList.Count == 0)
		{
			return null;
		}
		return mHelpList[UnityEngine.Random.Range(0, mHelpList.Count)];
	}

	public static List<GameShootableEntity> GetAll<T>() where T : class
	{
		mHelpList = new List<GameShootableEntity>();
		if (generatedEntities.TryGetValue(typeof(T), out var value))
		{
			foreach (GameShootableEntity item in value)
			{
				if (item.owner is IGameMainEntity mainEntity && mainEntity.isAlive)
				{
					mHelpList.Add(item);
				}
			}
		}
		return mHelpList;
	}

	public virtual List<ShotTarget> GetShotTargets(ShotTargetType type)
	{
		if (type == ShotTargetType.All)
		{
			return targets;
		}
		List<ShotTarget> list = new List<ShotTarget>();
		foreach (ShotTarget target in targets)
		{
			if ((target.type & type) == target.type)
			{
				list.Add(target);
			}
		}
		return list;
	}

	public ShotTarget GetNearestTarget(ShotTargetType type, Vector3 position)
	{
		List<ShotTarget> shotTargets = GetShotTargets(type);
		ShotTarget result = null;
		float num = float.MaxValue;
		foreach (ShotTarget item in shotTargets)
		{
			float num2 = Vector3.Distance(position, item.transform.position);
			if (num2 < num)
			{
				result = item;
				num = num2;
			}
		}
		return result;
	}

	private void OnEnable()
	{
		if (owner != null)
		{
			if (generatedEntities.TryGetValue(owner.GetType(), out var value))
			{
				value.Add(this);
				return;
			}
			value = new List<GameShootableEntity>();
			value.Add(this);
			generatedEntities[owner.GetType()] = value;
		}
		else
		{
			Debug.LogError("Game shoootable entitiy without owner");
		}
	}

	private void OnDisable()
	{
		if (owner != null)
		{
			if (generatedEntities.TryGetValue(owner.GetType(), out var value))
			{
				value.Remove(this);
			}
			else
			{
				Debug.LogError("Should not happened");
			}
		}
		else
		{
			Debug.LogError("Game shoootable entitiy without owner");
		}
	}

	public static void Init()
	{
		List<LevelBehaviourManager.BehaviourEntry> levelBehaviours = Singleton<LevelBehaviourManager>.instance.levelBehaviours;
		foreach (LevelBehaviourManager.BehaviourEntry item in levelBehaviours)
		{
			if (behavioursByType.TryGetValue(item.behaviour.unitType, out var value))
			{
				value.Add(item.behaviour.GetType());
				continue;
			}
			value = new HashSet<Type>();
			value.Add(item.behaviour.GetType());
			behavioursByType[item.behaviour.unitType] = value;
		}
	}

	public static List<GameShootableEntity> GetOpponents(Fractions fraction, LevelBehaviour.UnitType unitType)
	{
		HashSet<Type> hashSet = behavioursByType[unitType];
		List<GameShootableEntity> opponents = GetOpponents(fraction);
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		foreach (GameShootableEntity item in opponents)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.preparedBehaviour != null && hashSet.Contains(aIObject.preparedBehaviour.GetType()))
			{
				list.Add(item);
			}
		}
		return list;
	}

	public static List<GameShootableEntity> GetOpponents(Fractions fraction, LevelBehaviour.UnitType[] unitTypes)
	{
		List<GameShootableEntity> list = new List<GameShootableEntity>();
		foreach (LevelBehaviour.UnitType key in unitTypes)
		{
			HashSet<Type> hashSet = behavioursByType[key];
			List<GameShootableEntity> opponents = GetOpponents(fraction);
			foreach (GameShootableEntity item in opponents)
			{
				AIObject aIObject = item.owner as AIObject;
				if (aIObject != null && aIObject.preparedBehaviour != null && hashSet.Contains(aIObject.preparedBehaviour.GetType()))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}
}
