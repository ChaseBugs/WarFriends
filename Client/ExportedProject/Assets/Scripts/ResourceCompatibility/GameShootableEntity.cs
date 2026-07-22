using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameShootableEntity : Core_BaseScript, IBFMOMDLFEP
{
	[Flags]
	public enum GGDNGONEKLD
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
	public enum COMKCEJBDDC
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

		public GGDNGONEKLD type;

		public GameShootableEntity shootableEntity => null;
	}

	public static LevelBehaviour.UnitType[] HNJGCJCPODF;

	private static List<GameShootableEntity> IBOPPAHCIKE;

	public static Dictionary<Type, List<GameShootableEntity>> HANNOKDHNPD;

	private static readonly Dictionary<COMKCEJBDDC, Type[]> BLGJJKNJPGG;

	private static readonly Type[] PBEMJGMEHJL;

	private Transform DDOHNDOCKKI;

	private DestroyableObject AIIDCMKBFCB;

	private Vector3 HFHHAEJFPKO;

	private Vector3 HBEDNGALFHD;

	private PhotonView IBBJLFJLAFA;

	public List<Transform> BANHBBGDNCM;

	[SerializeField]
	public List<ShotTarget> targets;

	public bool IBGOAFGHACL;

	private IBFMOMDLFEP KNINIDJLIMA;

	private bool LCEPPEJPBEN;

	[CompilerGenerated]
	private Transform _003CIINKAGCHOHP_003Ek__BackingField;

	private HashSet<Type> JFFJNCBEGDB;

	private static Dictionary<LevelBehaviour.UnitType, HashSet<Type>> GGIDHPEPFLD;

	public Vector3 velocity => default(Vector3);

	public DestroyableObject destroyableObject => null;

	public MainGameEntity mainGameEntity => null;

	public Transform mTransform
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

	public IBFMOMDLFEP owner
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool isMain
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	protected virtual void Update()
	{
	}

	protected override void Awake()
	{
	}

	public static GameShootableEntity PickRandomOponentOf(HPHFGNJPDKN LBHJBBKENEO)
	{
		return null;
	}

	public static GameShootableEntity PickOpponentInView(HPHFGNJPDKN LBHJBBKENEO, Vector3 GPCNPCKHKPD, Vector3 JGGILANFPKK, float MBGNBIMPHHI, float JINBCBCBAJO)
	{
		return null;
	}

	public static List<GameShootableEntity> GetEntities(HPHFGNJPDKN LBHJBBKENEO)
	{
		return null;
	}

	public static List<GameShootableEntity> GetOpponents(HPHFGNJPDKN LBHJBBKENEO)
	{
		return null;
	}

	public static List<GameShootableEntity> GetOpponents<T>(HPHFGNJPDKN LBHJBBKENEO) where T : class
	{
		return null;
	}

	public static Type[] GetAllMechanicalTypes()
	{
		return null;
	}

	public static List<GameShootableEntity> GetOpponents(HPHFGNJPDKN LBHJBBKENEO, Type[] AFMBMLOPJDB)
	{
		return null;
	}

	public static List<GameShootableEntity> GetOpponents(HPHFGNJPDKN LBHJBBKENEO, COMKCEJBDDC AMIGLJGDEJM)
	{
		return null;
	}

	public static List<GameShootableEntity> GetOpponents(HPHFGNJPDKN LBHJBBKENEO, COMKCEJBDDC AMIGLJGDEJM, string BIIBLFMJEMN)
	{
		return null;
	}

	public static List<GameShootableEntity> GetAlly(HPHFGNJPDKN LBHJBBKENEO, Type[] AFMBMLOPJDB)
	{
		return null;
	}

	public static GameShootableEntity GetRandomOpponent(HPHFGNJPDKN LBHJBBKENEO, Type[] AFMBMLOPJDB)
	{
		return null;
	}

	public static List<GameShootableEntity> GetAll<T>() where T : class
	{
		return null;
	}

	public virtual List<ShotTarget> GetShotTargets(GGDNGONEKLD JFACCKJNHHC)
	{
		return null;
	}

	public ShotTarget GetNearestTarget(GGDNGONEKLD JFACCKJNHHC, Vector3 MPHCJEIMBEB)
	{
		return null;
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public static void Init()
	{
	}

	public static List<GameShootableEntity> GetOpponents(HPHFGNJPDKN LBHJBBKENEO, LevelBehaviour.UnitType AHCLLPDBLGB)
	{
		return null;
	}

	public static List<GameShootableEntity> GetOpponents(HPHFGNJPDKN LBHJBBKENEO, LevelBehaviour.UnitType[] MCPCHMIFAON)
	{
		return null;
	}
}
