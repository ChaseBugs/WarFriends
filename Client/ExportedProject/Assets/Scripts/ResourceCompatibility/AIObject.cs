using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AIObject : MainGameEntity, PHOFJEDENDJ, IBFMOMDLFEP
{
	[CompilerGenerated]
	private static Action<AIObject, DestroyableObject.LDOKCBNNLCH> FAEEHJNAJML;

	[CompilerGenerated]
	private Action<PHOFJEDENDJ, DestroyableObject.LDOKCBNNLCH> DBNKCOADOGP;

	[CompilerGenerated]
	private Action<AIObject, bool> IMCNGMDPHPJ;

	[CompilerGenerated]
	private static Action<AIObject> BCHPODANBOB;

	public LevelBehaviour FFBFBMDMEGB;

	public LevelBehaviour DJDKOBKAJEO;

	public UpgradeSlots.UnitUpgrades BOCCHNDLCOJ;

	public FEPKHDHDKII MAAKDJCLJJJ;

	public HPHFGNJPDKN GNCHIMKGGNO;

	public bool DONHPIMOLAA;

	protected int HCHOOLHJECI;

	protected bool LDFLMLMGNNB;

	[CompilerGenerated]
	private float _003COBIDLJPMADG_003Ek__BackingField;

	[CompilerGenerated]
	private AIObject _003CBDEBCAKKAFE_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CBBBFBFBFHIB_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CEJLPADGHCEJ_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAFDODMDFEME_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CHPDBIIJOJGG_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CIMFJLJAFMDK_003Ek__BackingField;

	private AimTarget[] ICOMPMNFNNA;

	private bool KNBKGCOMONN;

	protected float OAKDJPLKGNG;

	public float spawnTime
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		protected set
		{
		}
	}

	public AIObject parentVehicle
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public bool spawnedByCard
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public int spawnedCardLevel
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

	public string cardId
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public bool isInvader
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float cardProgress
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public bool hasSpecial => false;

	public override int power
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public override HPHFGNJPDKN fraction
	{
		get
		{
			return default(HPHFGNJPDKN);
		}
		set
		{
		}
	}

	public override IBFMOMDLFEP owner
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public static event Action<AIObject, DestroyableObject.LDOKCBNNLCH> AIObjectKilled
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

	public override event Action<PHOFJEDENDJ, DestroyableObject.LDOKCBNNLCH> Killed
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

	public event Action<AIObject, bool> DisableChanged
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

	public static event Action<AIObject> AfterSpawned
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

	public virtual bool CanProcessing()
	{
		return false;
	}

	protected bool CMKFACFEHIE(Vector3 PNOJBGAFKLA)
	{
		return false;
	}

	public bool CanSeeTarget(Vector3 OIEMNMJADKD, Vector3 PNOJBGAFKLA)
	{
		return false;
	}

	public static bool CanSeeTargetStatic(Vector3 OIEMNMJADKD, Vector3 PNOJBGAFKLA, float BGIOBKDLNLD = 0.25f)
	{
		return false;
	}

	public virtual void Spawn()
	{
	}

	public override void BeforeInstancied()
	{
	}

	public void PickUpgrades()
	{
	}

	protected void EKCCMHHGIEH()
	{
	}

	[PunRPC]
	protected void SyncUpgradesRPC(byte PNAJLHACGEO, UpgradeSlots.UnitUpgrades IDHKHECHPHJ)
	{
	}

	public virtual void StartEnemyBehaviour()
	{
	}

	[PunRPC]
	protected void StartEnemyBehaviourNetwork(byte POBCABNALOM)
	{
	}

	protected virtual void LLGNKOCNOEI()
	{
	}

	public override void DestroyPooled()
	{
	}

	[PunRPC]
	protected void SetPower(byte CBGFMOGENKE)
	{
	}

	protected virtual void MLCLIAOFKNE(DestroyableObject.LDOKCBNNLCH OJLKLBKCMIH)
	{
	}

	public virtual void UpdatePreview(bool GBHIJONPCBM)
	{
	}

	public void SpawnByCard(float IDIFAEGGBFA, string KKAKHIJFNKN)
	{
	}

	public void MarkAsInvader()
	{
	}

	[PunRPC]
	protected void MarkAsInvaderRPC()
	{
	}

	public void SetParentVehicle(AIObject HAIEFHHINMM)
	{
	}

	[PunRPC]
	protected void SetParentVehicleRPC(int GAJDAFILJOO)
	{
	}

	private void EFKEILPPBAH(PHOFJEDENDJ DAMJDEPFOOO, DestroyableObject.LDOKCBNNLCH OJLKLBKCMIH)
	{
	}

	[PunRPC]
	protected void SpawnByCardRPC(float IDIFAEGGBFA, string KKAKHIJFNKN)
	{
	}

	public virtual void UpgradesLoaded()
	{
	}

	protected void HOHHDIEENLH(DestroyableObject IILHBBEDLPP)
	{
	}

	public virtual void ReSync()
	{
	}

	[PunRPC]
	public virtual void ReSyncRPC(byte PNAJLHACGEO, Vector3 OLMCGKKHAPD, Quaternion KMPBJDNAEDB, UpgradeSlots.UnitUpgrades IDHKHECHPHJ, bool KILEBFLGIGN, float IDIFAEGGBFA, string KKAKHIJFNKN)
	{
	}

	[PunRPC]
	public virtual void ReSyncDisabledRPC()
	{
	}

	public virtual void EnableSpawn()
	{
	}

	public virtual void DisableSpawn()
	{
	}

	protected virtual void OPNDMFKAEBL(HPHFGNJPDKN LBHJBBKENEO)
	{
	}

	public virtual void GetAudioSources(List<AudioSource> JLFDMGDOEKP)
	{
	}

	public bool IsPrepared()
	{
		return false;
	}

	public void Prepare(LevelBehaviour DJDKOBKAJEO)
	{
	}

	public virtual Type GetBehaviourType()
	{
		return null;
	}

	protected void MCPEDDLFECA(DestroyableObject.BMOKOKCHMLP AHFBNJHCANA, float GHPPCNBBHDK)
	{
	}

	protected virtual void HBDCJHGHHAL(float GHPPCNBBHDK)
	{
	}

	protected virtual void IOOJIDNOILO()
	{
	}

	public void ImproveWeapons(float DMPKAGHIGIB)
	{
	}

	[PunRPC]
	public void ImproveWeaponsRPC(float OFMBKFALFAM)
	{
	}

	public virtual void BoostDamage(float DMPKAGHIGIB)
	{
	}

	public virtual void ScaleDamage(float DMPKAGHIGIB)
	{
	}

	protected override void Update()
	{
	}
}
