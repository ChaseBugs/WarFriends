using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Shield : DestroyableObject
{
	public enum FACGHKKEONL
	{
		None,
		Success,
		Failure
	}

	private readonly Color32 OPCFNNKAFIN;

	public AudioSource GOPCBOLEBIK;

	[CompilerGenerated]
	private Action<Shield> MIADFBDGLKM;

	[SerializeField]
	private Material goldMaterial;

	public HudObjectIndicator JFJLDLNPLGK;

	public FACGHKKEONL KEDAMGFHFBI;

	private bool HCIPLELCJHC;

	private float BADLBNMDKLB;

	private bool JOGOHNCGPLI;

	private Collider OGEPBCKDNMN;

	private float MOABKPDOBAD;

	private bool IPMOADILJDI;

	private int IPAAIIJADFA;

	private int PJOGJAKOACB;

	private List<GrenadeAmmoBase> MCHPIOLCEPN;

	[SerializeField]
	private List<Transform> mStickPositions;

	[SerializeField]
	private int mShieldId;

	[SerializeField]
	private Renderer mSubModel;

	public List<float> BGPPHHOPLDO;

	private PlayerController KIHLHCFNNLI;

	private float DIJKGPPJEEB;

	private float COJGMJIKGJN;

	private float PLGIBMANGKL;

	private float BPIFLOMDPMC;

	[SerializeField]
	private Material normalMaterial;

	public List<GameObject> HMPJBKLKFOK;

	public AudioClip DNPNDBOCINL;

	public Transform GCOPNEPKHMG;

	public bool JOHMIEFDKIH;

	[CompilerGenerated]
	private CardIconIndicator _003CJOFCIFDHGPM_003Ek__BackingField;

	private bool NKAOPKPMCHH;

	private bool IDOMMEEKCFG;

	private const string CBHLHMLHAJB = "game-card-ico-shielddestroyer";

	private const string EHGMDKLHPFI = "game-card-ico-shieldcracker";

	private ShieldCosmeticsManager.ShieldCosmeticModel AJANAABKAEI;

	[CompilerGenerated]
	private HPHFGNJPDKN _003CNKENLKIJHNH_003Ek__BackingField;

	public CardIconIndicator cardIconIndicator
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

	public bool isDestroyed => false;

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

	public override HPHFGNJPDKN fraction
	{
		[CompilerGenerated]
		get
		{
			return default(HPHFGNJPDKN);
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public float refreshTime
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public PlayerController player
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool autoRepair
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool canRegenerate
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public event Action<Shield> Refilled
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

	[PunRPC]
	private void SetCanRegenerateRPC(bool HHDCBKDKICG)
	{
	}

	[PunRPC]
	private void SetAutoRepairRPC(bool HHDCBKDKICG)
	{
	}

	[PunRPC]
	private void SetPlayer(int MIFHPHNIMPF)
	{
	}

	[PunRPC]
	private void SetShieldRefresTimeRPC(float CGIFKNDNDOM)
	{
	}

	protected override void Awake()
	{
	}

	private void DJIKBALBFCM()
	{
	}

	private void LOHMGGPFOLL()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected void Update()
	{
	}

	private void GBMEJHCHECB()
	{
	}

	private void NANJILDFGKA()
	{
	}

	protected override void LateUpdate()
	{
	}

	private void AMKPNGPACLE(int DBEAHAFANGG)
	{
	}

	private void OJNGKGCLLGF()
	{
	}

	public override void Refill()
	{
	}

	[PunRPC]
	protected override void RefillRPC(float MLPOAAMKAFI, float BIMKNONLOJD)
	{
	}

	public override bool DoDamage(LDOKCBNNLCH INADGPICPMO)
	{
		return false;
	}

	public override void Death(DestroyableObject IILHBBEDLPP, LDOKCBNNLCH INADGPICPMO)
	{
	}

	public Transform GetStickPosition()
	{
		return null;
	}

	public float GetHighestStickPosition()
	{
		return 0f;
	}

	public float GetLowestStickPosition()
	{
		return 0f;
	}

	public void GetLock()
	{
	}

	[PunRPC]
	private void GetLockRPC()
	{
	}

	[PunRPC]
	private void GetLockResultRPC(byte HPIKCIDGLJM)
	{
	}

	public void DestroyShield()
	{
	}

	public void DestroyShieldWarcard()
	{
	}

	public void Resync()
	{
	}

	public override void Sync()
	{
	}

	[PunRPC]
	protected void SyncShieldRPC(float MLPOAAMKAFI, float BIMKNONLOJD, bool GFECJHAPOBA)
	{
	}

	public void Init()
	{
	}

	public void MultiplyRepairSpeedForPlayer(float DMPKAGHIGIB)
	{
	}

	[PunRPC]
	private void MultiplyRepairSpeedRPC(float DMPKAGHIGIB)
	{
	}

	public void AddStickyExplosive(GrenadeAmmoBase GLICJMLKIGG)
	{
	}

	public void RemoveStickyExplosive(GrenadeAmmoBase GLICJMLKIGG)
	{
	}
}
