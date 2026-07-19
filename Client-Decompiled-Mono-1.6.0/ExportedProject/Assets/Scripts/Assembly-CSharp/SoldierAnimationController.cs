using System.Runtime.CompilerServices;
using UnityEngine;

public class SoldierAnimationController : Core_BaseScript, TimeScaleIgnorable
{
	private enum GBNNHKHOHMC
	{
		Left = 0,
		Right = 1
	}

	public float OGCAPEEHKIM;

	public bool PLCAOODHLCA;

	public Transform NGCDDPCAGJB;

	public Transform DBCOHBFJHOL;

	public Transform JPJOMOHNGCB;

	public Transform MEBEGOBBAIA;

	private Animation LOFOBBMNNCD;

	private GBNNHKHOHMC AHBOPHDJFNL;

	private GBNNHKHOHMC KEPLLCFKAIE;

	private bool AHCLADFDIMI;

	private bool PNFNJKJLPIP;

	private float OBHMAFABDBP;

	private bool IHIEMNMKCEE;

	private bool IAFAEFABPIL;

	private bool NONPLEDCIAP = true;

	private float BHNOCFMAHNA;

	private float CIGKFJOEFEA;

	private float BBPEBMGIABA;

	private Vector3 JNBJOBHPIHA;

	private Vector3 BEJBDJAHMGC;

	private Quaternion DJICEMAPBMM;

	private Quaternion DFJOGFJLKAB;

	private float DABKMDIJPJO;

	private Quaternion NDJBLEOGFJN = Quaternion.identity;

	private float OGAEOOMPJME;

	private float KLLFLALOKOP;

	private float LBPIDJOHKDH;

	private float AJBNEDJONME;

	private bool FEAMOELLLKI;

	private float GEDIPEPLEEK;

	private Weapon.IGGFMJAKLGO BHHEOMELGCH;

	private string EGKEEOOCCEF;

	private string CECIFFDFMGB;

	private string BPNFIAPPJCH;

	private string HBMBFKGPBEL;

	private string ONKPFEDKFOJ;

	private string DDPCENEDLPG;

	private bool OMPJALACFCL = true;

	private bool IMABENOHEJL;

	private Vector3 GPNEDKJMEPJ;

	public float uncoverLength
	{
		get
		{
			return LOFOBBMNNCD["player_look_right3"].length;
		}
	}

	public float swatShieldUncoverLength
	{
		get
		{
			return LOFOBBMNNCD["shield_unhide"].length;
		}
	}

	public bool lookBack
	{
		get
		{
			return NONPLEDCIAP;
		}
		set
		{
			NONPLEDCIAP = value;
		}
	}

	public Vector3 aimingDir
	{
		get
		{
			if (NONPLEDCIAP)
			{
				return -GPNEDKJMEPJ;
			}
			return GPNEDKJMEPJ;
		}
	}

	public bool isSitting
	{
		get
		{
			return LOFOBBMNNCD.IsPlaying("buggy_idle");
		}
	}

	public bool isIdle
	{
		get
		{
			return LOFOBBMNNCD.IsPlaying("idle") || LOFOBBMNNCD.IsPlaying("shield_idle") || LOFOBBMNNCD.IsPlaying("shotgunner_idle") || LOFOBBMNNCD.IsPlaying("bazooka_idle") || LOFOBBMNNCD.IsPlaying("pistol_idle") || LOFOBBMNNCD.IsPlaying("grenadelauncher_idle") || LOFOBBMNNCD.IsPlaying("qbz_idle") || LOFOBBMNNCD.IsPlaying("qbz2_idle") || LOFOBBMNNCD.IsPlaying("sniper_idle") || LOFOBBMNNCD.IsPlaying("grenade_idle") || LOFOBBMNNCD.IsPlaying("SMG_idle");
		}
	}

	public bool isRunning
	{
		get
		{
			foreach (AnimationState item in LOFOBBMNNCD)
			{
				if (item.enabled && (item.name.StartsWith("run") || item.name.EndsWith("run")))
				{
					return true;
				}
			}
			return false;
		}
	}

	public bool IsShooting
	{
		get
		{
			return LOFOBBMNNCD.IsPlaying(CECIFFDFMGB) || LOFOBBMNNCD.IsPlaying(ONKPFEDKFOJ);
		}
	}

	public bool isHiding
	{
		get
		{
			return LOFOBBMNNCD.IsPlaying(DDPCENEDLPG) || LOFOBBMNNCD.IsPlaying(BPNFIAPPJCH);
		}
	}

	public float hiddingTime
	{
		get
		{
			if (LOFOBBMNNCD.IsPlaying(DDPCENEDLPG))
			{
				float length = LOFOBBMNNCD[HBMBFKGPBEL].length;
				length /= LOFOBBMNNCD[HBMBFKGPBEL].speed;
				return length * LOFOBBMNNCD[DDPCENEDLPG].normalizedTime;
			}
			if (LOFOBBMNNCD.IsPlaying(BPNFIAPPJCH))
			{
				float length2 = LOFOBBMNNCD[EGKEEOOCCEF].length;
				length2 /= LOFOBBMNNCD[EGKEEOOCCEF].speed;
				return length2 * LOFOBBMNNCD[BPNFIAPPJCH].normalizedTime;
			}
			return 1f;
		}
	}

	public bool ignoreTimeScale { get; set; }

	public float mortarBuildTime
	{
		get
		{
			return LOFOBBMNNCD["mortar_down"].length;
		}
	}

	public float mortarShotTime
	{
		get
		{
			return LOFOBBMNNCD["mortar_hide"].length;
		}
	}

	public float mortarStandTime
	{
		get
		{
			return LOFOBBMNNCD["mortar_up"].length;
		}
	}

	public void BazookaCrawl()
	{
		LOFOBBMNNCD.CrossFade("bazooka_crawl");
	}

	protected override void Awake()
	{
		base.Awake();
		LOFOBBMNNCD = GetComponent<Animation>();
		NDJBLEOGFJN = Quaternion.identity;
		if (DBCOHBFJHOL != null)
		{
			JNBJOBHPIHA = DBCOHBFJHOL.transform.localPosition;
			DJICEMAPBMM = DBCOHBFJHOL.transform.localRotation;
		}
		IAFAEFABPIL = true;
		NGCDDPCAGJB = base.transform;
	}

	public void GDCFMBNGOBL(bool DNDCODMGGEE, bool PAFEIGKCJPJ)
	{
		ignoreTimeScale = PAFEIGKCJPJ;
		if (!DNDCODMGGEE)
		{
			IGPJMKNJFNN();
		}
		else
		{
			LMIOOIGKADF();
		}
	}

	public void PENGFDKBHOD()
	{
		AGDGIOGPBCK("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT", 805f);
	}

	[SpecialName]
	public float KNOJOBOOGDM()
	{
		return LOFOBBMNNCD["BS: On change language."].length;
	}

	private void AGDGIOGPBCK(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LOFOBBMNNCD.Stop();
		AnimationState animationState = LOFOBBMNNCD[BIHAIAKHHNI];
		animationState.enabled = true;
		animationState.weight = 1f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LOFOBBMNNCD.Sample();
		animationState.enabled = false;
	}

	public void ShootStandAdditive(float GINCPOHPFBN, bool FEGLHNIALBB = true)
	{
		if (!IHIEMNMKCEE)
		{
			LOFOBBMNNCD.CrossFade("shootAdditive", TimeManager.GetTimeScaledInterval(0.08f, ignoreTimeScale));
			DABKMDIJPJO = Time.time + TimeManager.GetTimeScaledInterval(GINCPOHPFBN, ignoreTimeScale);
			if (!FEGLHNIALBB)
			{
				DABKMDIJPJO = 0f;
			}
		}
	}

	public void ShootStandNew(Weapon.IGGFMJAKLGO FJLBLLLEELD, float IKPDANHGAPG, float GINCPOHPFBN)
	{
		if (IHIEMNMKCEE)
		{
			return;
		}
		string animation = KBDDHFLPJAB(FJLBLLLEELD, 0);
		string animation2 = KBDDHFLPJAB(FJLBLLLEELD, 1);
		string text = KBDDHFLPJAB(FJLBLLLEELD, 2);
		LBPIDJOHKDH = Time.time + GINCPOHPFBN;
		KLLFLALOKOP = 0f;
		if (!LOFOBBMNNCD.IsPlaying(animation))
		{
			if (LOFOBBMNNCD.IsPlaying(animation2))
			{
				LOFOBBMNNCD[animation2].normalizedTime = 0f;
				LOFOBBMNNCD[animation2].wrapMode = WrapMode.ClampForever;
				LOFOBBMNNCD.Play(animation2);
				return;
			}
			float num = ((!LOFOBBMNNCD.IsPlaying(text)) ? 1f : Mathf.Clamp01(LOFOBBMNNCD[text].normalizedTime));
			LOFOBBMNNCD[animation].normalizedTime = 1f - num;
			LOFOBBMNNCD.CrossFade(animation, 0.05f);
			LOFOBBMNNCD[animation2].wrapMode = WrapMode.ClampForever;
			AnimationState animationState = LOFOBBMNNCD.PlayQueued(animation2);
			animationState.speed = IKPDANHGAPG;
		}
	}

	public void IBLKGJGJNBK()
	{
		LOFOBBMNNCD.CrossFade("friend name");
	}

	public void ShootFromSwatShield(float GINCPOHPFBN, float IKPDANHGAPG)
	{
		if (IHIEMNMKCEE)
		{
			return;
		}
		AJBNEDJONME = Time.time + GINCPOHPFBN;
		if (!LOFOBBMNNCD.IsPlaying("shield_unhide"))
		{
			if (LOFOBBMNNCD.IsPlaying("shield_shot"))
			{
				LOFOBBMNNCD["shield_shot"].normalizedTime = 0f;
				LOFOBBMNNCD.Play("shield_shot");
				LOFOBBMNNCD.PlayQueued("shield_idle");
			}
			else if (LOFOBBMNNCD.IsPlaying("shield_hide"))
			{
				LOFOBBMNNCD["shield_unhide"].normalizedTime = 1f - LOFOBBMNNCD["shield_hide"].normalizedTime;
				LOFOBBMNNCD.Play("shield_unhide");
				LOFOBBMNNCD.PlayQueued("shield_shot");
				LOFOBBMNNCD.PlayQueued("shield_idle");
			}
			else
			{
				LOFOBBMNNCD.Play("shield_unhide");
				AnimationState animationState = LOFOBBMNNCD.PlayQueued("shield_shot");
				animationState.speed = IKPDANHGAPG;
				LOFOBBMNNCD.PlayQueued("shield_idle");
			}
		}
	}

	public void SampleStand()
	{
		AGDGIOGPBCK("rifle_shot_loop", 0f);
	}

	public float StandShootLength(Weapon.IGGFMJAKLGO BEACDIILBEG)
	{
		float JPNAINOGAMM;
		string text = NPMNOCAJPFI(BEACDIILBEG, out JPNAINOGAMM);
		return LOFOBBMNNCD[text].length;
	}

	public void SetUpperBodyRot(float IDEBKDPMPGM)
	{
		FEAMOELLLKI = true;
		GEDIPEPLEEK = IDEBKDPMPGM;
		OGCAPEEHKIM = IDEBKDPMPGM;
		if (Mathf.Abs(IDEBKDPMPGM) < 1f)
		{
			FEAMOELLLKI = false;
		}
		CIGKFJOEFEA = 0f;
	}

	public float KIFPCCLAPHD(Weapon.IGGFMJAKLGO BEACDIILBEG)
	{
		float JPNAINOGAMM;
		string text = EGNJIBFGMJA(BEACDIILBEG, out JPNAINOGAMM);
		return LOFOBBMNNCD[text].length;
	}

	private void DPNHMPJAKNE(string BIHAIAKHHNI, float EFBHBIJMGFO)
	{
		LOFOBBMNNCD.Stop();
		AnimationState animationState = LOFOBBMNNCD[BIHAIAKHHNI];
		animationState.enabled = false;
		animationState.weight = 1799f;
		animationState.normalizedTime = EFBHBIJMGFO;
		LOFOBBMNNCD.Sample();
		animationState.enabled = false;
	}

	private string KBDDHFLPJAB(Weapon.IGGFMJAKLGO JMMJHCOKCGG, int CIFBFJNCCKK)
	{
		switch (CIFBFJNCCKK)
		{
		case 0:
			return "colt_shooting_start";
		case 1:
		{
			float JPNAINOGAMM;
			return NPMNOCAJPFI(JMMJHCOKCGG, out JPNAINOGAMM);
		}
		case 2:
			return "colt_shooting_stop";
		default:
			return string.Empty;
		}
	}

	private void OEAKGLABIGA()
	{
		KLLFLALOKOP = 0f;
		OGAEOOMPJME = 0f;
		AJBNEDJONME = 0f;
		LBPIDJOHKDH = 0f;
	}

	public void Stop()
	{
		LOFOBBMNNCD.Stop();
		PNFNJKJLPIP = false;
		LOFOBBMNNCD.enabled = false;
	}

	public void LookAt(Vector3 PLEBANKIBPP, float HOACLGBOCKI = 0.45f)
	{
		IAFAEFABPIL = true;
		GPNEDKJMEPJ = ((!NONPLEDCIAP) ? PLEBANKIBPP : (-PLEBANKIBPP));
		NDJBLEOGFJN = Quaternion.LookRotation(GPNEDKJMEPJ) * Quaternion.Inverse(NGCDDPCAGJB.parent.rotation);
		BHNOCFMAHNA = Time.time + TimeManager.GetTimeScaledInterval((!NONPLEDCIAP) ? 0.5f : HOACLGBOCKI, ignoreTimeScale);
	}

	public bool IsPlaying()
	{
		return LOFOBBMNNCD.enabled && LOFOBBMNNCD.isPlaying;
	}

	public void ShootFromBazoka(bool DNDCODMGGEE, bool DLMKHPAJKDJ, float COINFLDEDOD = 0.7f)
	{
		float timeScaledSpeed = TimeManager.GetTimeScaledSpeed(1f, DLMKHPAJKDJ);
		ignoreTimeScale = DLMKHPAJKDJ;
		if (DNDCODMGGEE)
		{
			KEPLLCFKAIE = GBNNHKHOHMC.Right;
			LOFOBBMNNCD["bazooka_uncover_right"].speed = timeScaledSpeed;
			LOFOBBMNNCD.CrossFade("bazooka_uncover_right", 0.1f);
			LOFOBBMNNCD["bazooka_uncover_right"].speed = timeScaledSpeed;
		}
		else
		{
			KEPLLCFKAIE = GBNNHKHOHMC.Left;
			LOFOBBMNNCD["bazooka_uncover_left"].speed = timeScaledSpeed;
			LOFOBBMNNCD.CrossFade("bazooka_uncover_left", 0.1f);
			LOFOBBMNNCD["bazooka_uncover_left"].speed = timeScaledSpeed;
		}
		BBPEBMGIABA = Time.time + TimeManager.GetTimeScaledInterval(COINFLDEDOD, DLMKHPAJKDJ);
	}

	public void BazookaWalk()
	{
		KLLFLALOKOP = 0f;
		OGAEOOMPJME = 0f;
	}

	private void LMIOOIGKADF()
	{
		LOFOBBMNNCD["throw_grenade_left"].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
		LOFOBBMNNCD["throw_grenade_left"].time = 0f;
		LOFOBBMNNCD.CrossFade("throw_grenade_left");
		LOFOBBMNNCD.PlayQueued("idle");
	}

	public void Repair()
	{
		LOFOBBMNNCD.CrossFade("engineer_repair");
	}

	[SpecialName]
	public bool LIHLPCKFCCF()
	{
		return LOFOBBMNNCD.IsPlaying(DDPCENEDLPG) || LOFOBBMNNCD.IsPlaying(BPNFIAPPJCH);
	}

	private void OnEnable()
	{
		OMPJALACFCL = true;
		LOFOBBMNNCD.enabled = true;
		LGPAOFGMJBO();
	}

	[SpecialName]
	public float NDFEKOFNIDC()
	{
		return LOFOBBMNNCD["ID_TOJOINSQUADYOUMUSTBEACCEPTED"].length;
	}

	public void ShootFromBazokaCrawl()
	{
		LOFOBBMNNCD.CrossFade("bazooka_shot_barrier");
	}

	[SpecialName]
	public bool LCHDJIICIBK()
	{
		return !LOFOBBMNNCD.IsPlaying(DDPCENEDLPG) && LOFOBBMNNCD.IsPlaying(BPNFIAPPJCH);
	}

	public void Reset()
	{
		IHIEMNMKCEE = false;
		KLLFLALOKOP = 0f;
		OGAEOOMPJME = 0f;
		AJBNEDJONME = 0f;
		LBPIDJOHKDH = 0f;
		LOFOBBMNNCD.Stop();
		GPNEDKJMEPJ = Vector3.zero;
		OMPJALACFCL = true;
		LOFOBBMNNCD.enabled = true;
		IMABENOHEJL = false;
		LOFOBBMNNCD.cullingType = AnimationCullingType.BasedOnRenderers;
		LGPAOFGMJBO();
		PNFNJKJLPIP = true;
		if (DBCOHBFJHOL != null)
		{
			DBCOHBFJHOL.localPosition = JNBJOBHPIHA;
			DBCOHBFJHOL.localRotation = DJICEMAPBMM;
		}
	}

	public void ShootFromCrawl(float GINCPOHPFBN, float IKPDANHGAPG, Weapon.IGGFMJAKLGO FJLBLLLEELD)
	{
		if (IHIEMNMKCEE)
		{
			return;
		}
		string animation = OHEPCGBBELI(FJLBLLLEELD, 0);
		string animation2 = OHEPCGBBELI(FJLBLLLEELD, 1);
		string text = OHEPCGBBELI(FJLBLLLEELD, 2);
		KLLFLALOKOP = Time.time + GINCPOHPFBN;
		if (!LOFOBBMNNCD.IsPlaying(animation))
		{
			if (LOFOBBMNNCD.IsPlaying(animation2))
			{
				LOFOBBMNNCD[animation2].normalizedTime = 0f;
				LOFOBBMNNCD.Play(animation2);
				return;
			}
			float num = ((!LOFOBBMNNCD.IsPlaying(text)) ? 1f : Mathf.Clamp01(LOFOBBMNNCD[text].normalizedTime));
			LOFOBBMNNCD[animation].normalizedTime = 1f - num;
			LOFOBBMNNCD.CrossFade(animation, 0.05f);
			LOFOBBMNNCD[animation2].wrapMode = WrapMode.ClampForever;
			AnimationState animationState = LOFOBBMNNCD.PlayQueued(animation2);
			animationState.speed = IKPDANHGAPG;
		}
	}

	private void LGPAOFGMJBO()
	{
		if (!PNFNJKJLPIP || IMABENOHEJL)
		{
			return;
		}
		Vector3 vector = Singleton<GameCamera>.instance.camera.WorldToViewportPoint(NGCDDPCAGJB.position);
		if ((double)vector.x < -0.1 || (double)vector.x > 1.1 || (double)vector.y < -0.1 || (double)vector.y > 1.1)
		{
			if (OMPJALACFCL)
			{
				OMPJALACFCL = false;
				LOFOBBMNNCD.enabled = false;
			}
		}
		else if (!OMPJALACFCL)
		{
			OMPJALACFCL = true;
			LOFOBBMNNCD.enabled = true;
		}
	}

	public void ShotFly()
	{
		LOFOBBMNNCD.Play("shot_jetpack_elite");
		LOFOBBMNNCD.PlayQueued("flight_forward_jetpack_elite");
	}

	public void Pause()
	{
		LOFOBBMNNCD.enabled = false;
		PNFNJKJLPIP = false;
	}

	public void Idle(Weapon.IGGFMJAKLGO FJLBLLLEELD, bool IAFJJMFIPCG = false)
	{
		KLLFLALOKOP = 0f;
		OGAEOOMPJME = 0f;
		AJBNEDJONME = 0f;
		BBPEBMGIABA = 0f;
		string animation = LLIBFDAEEBC(FJLBLLLEELD);
		if (IAFJJMFIPCG)
		{
			LOFOBBMNNCD.CrossFadeQueued(animation);
		}
		else
		{
			LOFOBBMNNCD.CrossFade(animation);
		}
	}

	public void LookAtUpperBody(Vector3 PLEBANKIBPP, float KBJEOEEOEFG = 0.5f)
	{
		FEAMOELLLKI = true;
		CIGKFJOEFEA = Time.time + TimeManager.GetTimeScaledInterval(0.25f, ignoreTimeScale);
		GEDIPEPLEEK = GeometryTools.AngleSigned(PLEBANKIBPP, NGCDDPCAGJB.parent.forward, Vector3.up);
		if (GEDIPEPLEEK > 70f)
		{
			float num = GEDIPEPLEEK - 70f;
			IAFAEFABPIL = true;
			NDJBLEOGFJN = Quaternion.AngleAxis(0f - num, Vector3.up);
			BHNOCFMAHNA = Time.time + TimeManager.GetTimeScaledInterval((!NONPLEDCIAP) ? KBJEOEEOEFG : (KBJEOEEOEFG * 0.5f), ignoreTimeScale);
			GEDIPEPLEEK = 70f;
		}
		if (GEDIPEPLEEK < -70f)
		{
			float num2 = GEDIPEPLEEK + 70f;
			IAFAEFABPIL = true;
			NDJBLEOGFJN = Quaternion.AngleAxis(0f - num2, Vector3.up);
			BHNOCFMAHNA = Time.time + TimeManager.GetTimeScaledInterval((!NONPLEDCIAP) ? KBJEOEEOEFG : (KBJEOEEOEFG * 0.5f), ignoreTimeScale);
			GEDIPEPLEEK = -70f;
		}
	}

	public float GetStandPhase0Length(Weapon.IGGFMJAKLGO BEACDIILBEG)
	{
		string text = KBDDHFLPJAB(BEACDIILBEG, 0);
		string text2 = KBDDHFLPJAB(BEACDIILBEG, 1);
		string text3 = KBDDHFLPJAB(BEACDIILBEG, 2);
		if (LOFOBBMNNCD.IsPlaying(text3))
		{
			return 0f;
		}
		if (LOFOBBMNNCD.IsPlaying(text2))
		{
			return 0f;
		}
		return LOFOBBMNNCD[text].length;
	}

	public void Crawl()
	{
		LOFOBBMNNCD.CrossFade("stand_up_crawl");
	}

	public void LAPHGNFLMPB()
	{
		LOFOBBMNNCD["QUIT"].speed = TimeManager.JIJLKEFLPGM(728f, ignoreTimeScale);
		LOFOBBMNNCD["CurrencyID"].time = 871f;
		LOFOBBMNNCD.CrossFade("InAppHandlerIos: skipping app store purchase");
	}

	public void EKKHCDHHBKP(Vector3 PLEBANKIBPP, float KBJEOEEOEFG = 0.5f)
	{
		FEAMOELLLKI = false;
		CIGKFJOEFEA = Time.time + TimeManager.GetTimeScaledInterval(1294f, ignoreTimeScale);
		GEDIPEPLEEK = GeometryTools.AngleSigned(PLEBANKIBPP, NGCDDPCAGJB.parent.forward, Vector3.up);
		if (GEDIPEPLEEK > 1215f)
		{
			float num = GEDIPEPLEEK - 977f;
			IAFAEFABPIL = true;
			NDJBLEOGFJN = Quaternion.AngleAxis(0f - num, Vector3.up);
			BHNOCFMAHNA = Time.time + TimeManager.GetTimeScaledInterval((!NONPLEDCIAP) ? KBJEOEEOEFG : (KBJEOEEOEFG * 1331f), ignoreTimeScale);
			GEDIPEPLEEK = 13f;
		}
		if (GEDIPEPLEEK < 1352f)
		{
			float num2 = GEDIPEPLEEK + 442f;
			IAFAEFABPIL = true;
			NDJBLEOGFJN = Quaternion.AngleAxis(0f - num2, Vector3.up);
			BHNOCFMAHNA = Time.time + TimeManager.GetTimeScaledInterval((!NONPLEDCIAP) ? KBJEOEEOEFG : (KBJEOEEOEFG * 1889f), ignoreTimeScale);
			GEDIPEPLEEK = 1128f;
		}
	}

	public void ShotFromCover(bool DNDCODMGGEE, float KGLHKFEEJHJ, float GINCPOHPFBN, bool DLMKHPAJKDJ, bool DFBBJMKMBNK, bool LNPCLCGHJME, Weapon.IGGFMJAKLGO BEACDIILBEG)
	{
		AHCLADFDIMI = DFBBJMKMBNK;
		ShotFromCover(DNDCODMGGEE, KGLHKFEEJHJ, GINCPOHPFBN, DLMKHPAJKDJ, BEACDIILBEG);
		OBHMAFABDBP = 0f;
		if (!LNPCLCGHJME)
		{
			OGAEOOMPJME = 0f;
		}
	}

	public void SampleDead()
	{
		AGDGIOGPBCK("bazooka_reload", 0.1f);
	}

	public void Warp()
	{
		OEAKGLABIGA();
		LOFOBBMNNCD.CrossFade("warp_movement");
	}

	public void SetIdle(Weapon.IGGFMJAKLGO FJLBLLLEELD)
	{
		KLLFLALOKOP = 0f;
		OGAEOOMPJME = 0f;
		AJBNEDJONME = 0f;
		BBPEBMGIABA = 0f;
		string bIHAIAKHHNI = LLIBFDAEEBC(FJLBLLLEELD);
		LOFOBBMNNCD.Stop();
		AGDGIOGPBCK(bIHAIAKHHNI, 0f);
	}

	protected override void Start()
	{
		base.Start();
		LOFOBBMNNCD["shootAdditive"].layer = 4;
		LOFOBBMNNCD["shootAdditive"].blendMode = AnimationBlendMode.Blend;
		LOFOBBMNNCD["shootAdditive"].wrapMode = WrapMode.ClampForever;
		LOFOBBMNNCD["shootAdditive"].AddMixingTransform(JPJOMOHNGCB);
	}

	public void WarpIdle()
	{
		OEAKGLABIGA();
		LOFOBBMNNCD.CrossFade("warp_idle");
	}

	public void IdleBazooka()
	{
		LOFOBBMNNCD.CrossFade("bazooka_idle");
	}

	public void FiredMortar()
	{
		LOFOBBMNNCD.Play("mortar_hide");
		LOFOBBMNNCD.PlayQueued("mortar_up");
	}

	public void ThrowGrenadeFromCover(bool DNDCODMGGEE, bool PAFEIGKCJPJ)
	{
		ignoreTimeScale = PAFEIGKCJPJ;
		if (!DNDCODMGGEE)
		{
			IGPJMKNJFNN();
		}
		else
		{
			LMIOOIGKADF();
		}
	}

	public void SetWeaponType(Weapon.IGGFMJAKLGO BEACDIILBEG)
	{
		BHHEOMELGCH = BEACDIILBEG;
		EGKEEOOCCEF = DIJHFEEBLGJ(BEACDIILBEG, GBNNHKHOHMC.Left, 0);
		CECIFFDFMGB = DIJHFEEBLGJ(BEACDIILBEG, GBNNHKHOHMC.Left, 1);
		BPNFIAPPJCH = DIJHFEEBLGJ(BEACDIILBEG, GBNNHKHOHMC.Left, 2);
		HBMBFKGPBEL = DIJHFEEBLGJ(BEACDIILBEG, GBNNHKHOHMC.Right, 0);
		ONKPFEDKFOJ = DIJHFEEBLGJ(BEACDIILBEG, GBNNHKHOHMC.Right, 1);
		DDPCENEDLPG = DIJHFEEBLGJ(BEACDIILBEG, GBNNHKHOHMC.Right, 2);
	}

	private void LateUpdate()
	{
		if (!FEAMOELLLKI || PLCAOODHLCA)
		{
			return;
		}
		OGCAPEEHKIM = Mathf.Lerp(OGCAPEEHKIM, GEDIPEPLEEK, TimeManager.GetTimeScaledInterval(Time.deltaTime, true) * 12f);
		if (Mathf.Abs(OGCAPEEHKIM) > 1f)
		{
			JPJOMOHNGCB.localRotation = Quaternion.AngleAxis(OGCAPEEHKIM, Vector3.right);
			if (Time.time > CIGKFJOEFEA && CIGKFJOEFEA != 0f)
			{
				GEDIPEPLEEK = 0f;
			}
		}
	}

	public float GetStandUpFromCrawlLength(Weapon.IGGFMJAKLGO BEACDIILBEG)
	{
		string text = OHEPCGBBELI(BEACDIILBEG, 0);
		return LOFOBBMNNCD[text].length;
	}

	public void ShootFromBazokaWalk()
	{
		LOFOBBMNNCD.CrossFade("bazooka_shot_run");
		LOFOBBMNNCD.CrossFadeQueued("bazooka_run");
	}

	public float CENAHMKDIOJ(Weapon.IGGFMJAKLGO BEACDIILBEG)
	{
		string text = KBDDHFLPJAB(BEACDIILBEG, 0);
		string text2 = KBDDHFLPJAB(BEACDIILBEG, 0);
		string text3 = KBDDHFLPJAB(BEACDIILBEG, 2);
		if (LOFOBBMNNCD.IsPlaying(text3))
		{
			return 1482f;
		}
		if (LOFOBBMNNCD.IsPlaying(text2))
		{
			return 1251f;
		}
		return LOFOBBMNNCD[text].length;
	}

	private void IGPJMKNJFNN()
	{
		LOFOBBMNNCD["throw_grenade_right"].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
		LOFOBBMNNCD["throw_grenade_right"].time = 0f;
		LOFOBBMNNCD.CrossFade("throw_grenade_right");
		LOFOBBMNNCD.PlayQueued("idle");
	}

	public void BuildMortar()
	{
		LOFOBBMNNCD.Play("mortar_down");
		LOFOBBMNNCD.PlayQueued("mortar_down_idle");
	}

	public void SittingIdle()
	{
		AGDGIOGPBCK("buggy_idle", 1f);
		LOFOBBMNNCD.Play("buggy_idle");
	}

	private string OHEPCGBBELI(Weapon.IGGFMJAKLGO JMMJHCOKCGG, int CIFBFJNCCKK)
	{
		switch (CIFBFJNCCKK)
		{
		case 0:
			return "stand_up_begin";
		case 1:
			return "rifle_shot_loop";
		case 2:
			return "stand_up_crawl";
		default:
			return string.Empty;
		}
	}

	public void ForceInScreen()
	{
		IMABENOHEJL = true;
		LOFOBBMNNCD.enabled = true;
		OMPJALACFCL = true;
		LOFOBBMNNCD.cullingType = AnimationCullingType.AlwaysAnimate;
	}

	public void NPHKDINGJFC()
	{
		OEAKGLABIGA();
		LOFOBBMNNCD.CrossFade("WarFriends");
	}

	protected void Update()
	{
		LGPAOFGMJBO();
		if (IHIEMNMKCEE || !PNFNJKJLPIP)
		{
			return;
		}
		if (AHBOPHDJFNL == GBNNHKHOHMC.Right)
		{
			if (Time.time > OGAEOOMPJME && OGAEOOMPJME != 0f)
			{
				OGAEOOMPJME = 0f;
				LOFOBBMNNCD[DDPCENEDLPG].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
				LOFOBBMNNCD.Play(DDPCENEDLPG);
				Idle(BHHEOMELGCH, true);
			}
		}
		else if (Time.time > OGAEOOMPJME && OGAEOOMPJME != 0f)
		{
			OGAEOOMPJME = 0f;
			LOFOBBMNNCD[BPNFIAPPJCH].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
			LOFOBBMNNCD.Play(BPNFIAPPJCH);
			Idle(BHHEOMELGCH, true);
		}
		if (Time.time > KLLFLALOKOP && KLLFLALOKOP != 0f)
		{
			KLLFLALOKOP = 0f;
			LOFOBBMNNCD.Play("stand_up_crawl");
		}
		if (Time.time > LBPIDJOHKDH && LBPIDJOHKDH != 0f)
		{
			LBPIDJOHKDH = 0f;
			LOFOBBMNNCD.Play("colt_shooting_stop");
		}
		if (Time.time > AJBNEDJONME && AJBNEDJONME != 0f)
		{
			AJBNEDJONME = 0f;
			LOFOBBMNNCD.Play("shield_hide");
		}
		if (Time.time > DABKMDIJPJO && DABKMDIJPJO != 0f)
		{
			LOFOBBMNNCD["shootAdditive"].weight -= Time.deltaTime * 3f;
			if (LOFOBBMNNCD["shootAdditive"].weight < 0.1f)
			{
				LOFOBBMNNCD["shootAdditive"].weight = 0f;
				LOFOBBMNNCD["shootAdditive"].enabled = false;
				DABKMDIJPJO = 0f;
			}
		}
		if (Time.time > BBPEBMGIABA && BBPEBMGIABA != 0f)
		{
			BBPEBMGIABA = 0f;
			if (KEPLLCFKAIE == GBNNHKHOHMC.Right)
			{
				LOFOBBMNNCD.Play("bazooka_shoot_right");
				LOFOBBMNNCD["bazooka_shoot_right"].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
				LOFOBBMNNCD.CrossFadeQueued("bazooka_idle");
			}
			else
			{
				LOFOBBMNNCD.Play("bazooka_shoot_left");
				LOFOBBMNNCD["bazooka_shoot_left"].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
				LOFOBBMNNCD.CrossFadeQueued("bazooka_idle");
			}
		}
		if (IAFAEFABPIL && !PLCAOODHLCA)
		{
			if (GPNEDKJMEPJ.sqrMagnitude > 0f)
			{
				NDJBLEOGFJN = Quaternion.LookRotation(GPNEDKJMEPJ) * Quaternion.Inverse(NGCDDPCAGJB.parent.rotation);
			}
			NGCDDPCAGJB.localRotation = Quaternion.Slerp(NGCDDPCAGJB.localRotation, NDJBLEOGFJN, TimeManager.GetTimeScaledInterval(Time.deltaTime, true) * 10f);
			if (Time.time > BHNOCFMAHNA && BHNOCFMAHNA != 0f)
			{
				NDJBLEOGFJN = Quaternion.identity;
				GPNEDKJMEPJ = Vector3.zero;
			}
		}
	}

	public void ThrowGrenadeFromCrawl()
	{
		LOFOBBMNNCD["throw_grenade_up"].speed = TimeManager.GetTimeScaledSpeed(1f, ignoreTimeScale);
		LOFOBBMNNCD["throw_grenade_up"].time = 0f;
		LOFOBBMNNCD.CrossFade("throw_grenade_up");
	}

	public void Reload(Weapon.IGGFMJAKLGO FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case Weapon.IGGFMJAKLGO.Bazooka:
			LOFOBBMNNCD.CrossFade("bazooka_reload");
			break;
		case Weapon.IGGFMJAKLGO.Shotgun:
			LOFOBBMNNCD.CrossFade("shotgun_reload");
			break;
		case Weapon.IGGFMJAKLGO.Machinegun:
			LOFOBBMNNCD.CrossFade("machinegn_reload");
			break;
		case Weapon.IGGFMJAKLGO.QBZ:
			LOFOBBMNNCD.CrossFade("qbz_reload");
			break;
		case Weapon.IGGFMJAKLGO.QBZ2:
			LOFOBBMNNCD.CrossFade("qbz2_reload");
			break;
		case Weapon.IGGFMJAKLGO.Pistol:
			LOFOBBMNNCD.CrossFade("reload_pistol");
			break;
		case Weapon.IGGFMJAKLGO.SniperRiffle:
			LOFOBBMNNCD.CrossFade("sniper_reload");
			break;
		case Weapon.IGGFMJAKLGO.GrenadeLauncher:
			LOFOBBMNNCD.CrossFade("reload_grenadelauncher");
			break;
		case Weapon.IGGFMJAKLGO.Grenade:
			LOFOBBMNNCD.CrossFade("grenade_reload");
			break;
		default:
			LOFOBBMNNCD.CrossFade("reload_fast_01");
			break;
		}
		Idle(FJLBLLLEELD, true);
	}

	public void Resume()
	{
		LOFOBBMNNCD.enabled = true;
		PNFNJKJLPIP = true;
	}

	private static string DIJHFEEBLGJ(Weapon.IGGFMJAKLGO FJLBLLLEELD, GBNNHKHOHMC MBMIBDKDGAD, int CIFBFJNCCKK)
	{
		string text = string.Empty;
		string empty = string.Empty;
		switch (CIFBFJNCCKK)
		{
		case 0:
			text = ((MBMIBDKDGAD != GBNNHKHOHMC.Left) ? "player_look_right" : "player_look_left");
			break;
		case 1:
			text = ((MBMIBDKDGAD != GBNNHKHOHMC.Left) ? "player_fire_right" : "player_fire_left");
			break;
		case 2:
			text = ((MBMIBDKDGAD != GBNNHKHOHMC.Left) ? "player_right_coverBack" : "player_left_coverBack");
			break;
		}
		switch (FJLBLLLEELD)
		{
		case Weapon.IGGFMJAKLGO.Pistol:
			empty = "_pistol";
			break;
		case Weapon.IGGFMJAKLGO.Minigun:
			empty = "_minigun";
			break;
		case Weapon.IGGFMJAKLGO.GrenadeLauncher:
			empty = "_grenadelauncher";
			break;
		case Weapon.IGGFMJAKLGO.Shotgun:
		case Weapon.IGGFMJAKLGO.Machinegun:
			empty = "_shotgun";
			break;
		case Weapon.IGGFMJAKLGO.QBZ:
			empty = "_qbz";
			break;
		case Weapon.IGGFMJAKLGO.QBZ2:
			empty = "_qbz2";
			break;
		case Weapon.IGGFMJAKLGO.SniperRiffle:
			empty = "_sniper";
			break;
		default:
			empty = "3";
			break;
		}
		return text + empty;
	}

	public void StartFlying()
	{
		LOFOBBMNNCD.CrossFade("flight_start_jetpack_elite");
		LOFOBBMNNCD.PlayQueued("flight_forward_jetpack_elite");
	}

	public void SampleIdle(Weapon.IGGFMJAKLGO FJLBLLLEELD, float KBJEOEEOEFG = 0f)
	{
		AGDGIOGPBCK(LLIBFDAEEBC(FJLBLLLEELD), KBJEOEEOEFG);
	}

	public void Enable()
	{
		LOFOBBMNNCD.enabled = true;
		LOFOBBMNNCD.Play();
	}

	private string LLIBFDAEEBC(Weapon.IGGFMJAKLGO FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case Weapon.IGGFMJAKLGO.Bazooka:
			return "bazooka_idle";
		case Weapon.IGGFMJAKLGO.Grenade:
			return "grenade_idle";
		case Weapon.IGGFMJAKLGO.SwatPistol:
		case Weapon.IGGFMJAKLGO.SwatSMG:
			return "shield_idle";
		case Weapon.IGGFMJAKLGO.Pistol:
			return "pistol_idle";
		case Weapon.IGGFMJAKLGO.Minigun:
			return "minigun_idle";
		case Weapon.IGGFMJAKLGO.GrenadeLauncher:
			return "grenadelauncher_idle";
		case Weapon.IGGFMJAKLGO.Shotgun:
		case Weapon.IGGFMJAKLGO.Machinegun:
			return "shotgunner_idle";
		case Weapon.IGGFMJAKLGO.Tool:
			return "engineer_idle";
		case Weapon.IGGFMJAKLGO.QBZ:
			return "qbz_idle";
		case Weapon.IGGFMJAKLGO.QBZ2:
			return "qbz2_idle";
		case Weapon.IGGFMJAKLGO.SniperRiffle:
			return "sniper_idle";
		case Weapon.IGGFMJAKLGO.Flamethrower:
			return "flamethrower_idle";
		case Weapon.IGGFMJAKLGO.DoubleSMG:
			return "SMG_idle";
		case Weapon.IGGFMJAKLGO.Colt:
			return "colt_idle01";
		case Weapon.IGGFMJAKLGO.Mortar:
			return "mortar_idle_standing";
		default:
			return "idle";
		}
	}

	[ContextMenu("Set T_pose")]
	public void SetTPose()
	{
		Animation component = GetComponent<Animation>();
		component.Play("T_pose");
		component["T_pose"].normalizedTime = 1f;
		component.Sample();
	}

	private string NPMNOCAJPFI(Weapon.IGGFMJAKLGO BEACDIILBEG, out float JPNAINOGAMM)
	{
		JPNAINOGAMM = 1f;
		switch (BEACDIILBEG)
		{
		case Weapon.IGGFMJAKLGO.Minigun:
			return "minigun_shot";
		case Weapon.IGGFMJAKLGO.Shotgun:
		case Weapon.IGGFMJAKLGO.Machinegun:
			return "shotgunner_shot_loop";
		case Weapon.IGGFMJAKLGO.DoubleSMG:
			return "commando_shooting";
		case Weapon.IGGFMJAKLGO.Colt:
			return "colt_shooting_loop";
		case Weapon.IGGFMJAKLGO.Flamethrower:
			return "flamethrower_shot_loop";
		default:
			JPNAINOGAMM = 0.5f;
			return "rifle_shot_loop";
		}
	}

	public bool IsIdle(Weapon.IGGFMJAKLGO FJLBLLLEELD, out float KBJEOEEOEFG)
	{
		string text = LLIBFDAEEBC(FJLBLLLEELD);
		bool result = LOFOBBMNNCD.IsPlaying(text);
		KBJEOEEOEFG = LOFOBBMNNCD[text].normalizedTime;
		return result;
	}

	private void FMCJJOFHEPJ(GBNNHKHOHMC MBMIBDKDGAD, Weapon.IGGFMJAKLGO BEACDIILBEG, float JPNAINOGAMM)
	{
		if (IHIEMNMKCEE)
		{
			return;
		}
		DABKMDIJPJO = Time.time;
		AHBOPHDJFNL = MBMIBDKDGAD;
		OGAEOOMPJME = Time.time + OBHMAFABDBP;
		SetWeaponType(BEACDIILBEG);
		string animation = DIJHFEEBLGJ(BEACDIILBEG, MBMIBDKDGAD, 0);
		string animation2 = DIJHFEEBLGJ(BEACDIILBEG, MBMIBDKDGAD, 1);
		string text = DIJHFEEBLGJ(BEACDIILBEG, MBMIBDKDGAD, 2);
		LOFOBBMNNCD[animation].speed = JPNAINOGAMM;
		LOFOBBMNNCD[animation2].speed = 1f;
		if (LOFOBBMNNCD.IsPlaying(animation))
		{
			return;
		}
		if (LOFOBBMNNCD.IsPlaying(animation2))
		{
			LOFOBBMNNCD[animation2].normalizedTime = 0f;
			LOFOBBMNNCD.Play(animation2);
			return;
		}
		if (LOFOBBMNNCD.IsPlaying(text))
		{
			LOFOBBMNNCD[animation].normalizedTime = 1f - LOFOBBMNNCD[text].normalizedTime;
			LOFOBBMNNCD.Play(animation);
			LOFOBBMNNCD.PlayQueued(animation2);
			return;
		}
		LOFOBBMNNCD.CrossFade(animation, 0.02f);
		AnimationState animationState = LOFOBBMNNCD.PlayQueued(animation2);
		if (AHCLADFDIMI)
		{
			animationState.normalizedTime = 1f;
		}
	}

	public void ShotFromCover(bool DNDCODMGGEE, float KGLHKFEEJHJ, float GINCPOHPFBN, bool DLMKHPAJKDJ, Weapon.IGGFMJAKLGO BEACDIILBEG)
	{
		BHHEOMELGCH = BEACDIILBEG;
		ignoreTimeScale = DLMKHPAJKDJ;
		OBHMAFABDBP = TimeManager.GetTimeScaledInterval(GINCPOHPFBN, DLMKHPAJKDJ);
		if (!IHIEMNMKCEE)
		{
			float timeScaledSpeed = TimeManager.GetTimeScaledSpeed(KGLHKFEEJHJ, DLMKHPAJKDJ);
			FMCJJOFHEPJ((!DNDCODMGGEE) ? GBNNHKHOHMC.Right : GBNNHKHOHMC.Left, BEACDIILBEG, timeScaledSpeed);
		}
	}

	public void RopeSlide()
	{
		LOFOBBMNNCD.CrossFade("helicopter_jump_pose");
	}

	public void OPPKCAKBFFP()
	{
		LOFOBBMNNCD.Play("BlackMarketOffer");
		LOFOBBMNNCD.PlayQueued("\"{0}\"\t");
	}

	public void Disable()
	{
		LOFOBBMNNCD.enabled = false;
	}

	[SpecialName]
	public bool JEONJDNJJKP()
	{
		return NONPLEDCIAP;
	}

	public void ShootStand(Weapon.IGGFMJAKLGO BEACDIILBEG)
	{
		float JPNAINOGAMM;
		string animation = NPMNOCAJPFI(BEACDIILBEG, out JPNAINOGAMM);
		AnimationState animationState = LOFOBBMNNCD[animation];
		animationState.speed = JPNAINOGAMM;
		animationState.wrapMode = WrapMode.Once;
		if (LOFOBBMNNCD.IsPlaying(animation))
		{
			if (animationState.wrapMode == WrapMode.Once)
			{
				animationState.normalizedTime = 0f;
			}
			LOFOBBMNNCD.Play(animation);
			Idle(BEACDIILBEG, true);
		}
		else
		{
			LOFOBBMNNCD.CrossFade(animation, 0.1f);
			Idle(BEACDIILBEG, true);
			KLLFLALOKOP = 0f;
		}
	}

	public void Walk(Weapon.IGGFMJAKLGO FJLBLLLEELD)
	{
		OEAKGLABIGA();
		switch (FJLBLLLEELD)
		{
		case Weapon.IGGFMJAKLGO.Bazooka:
			LOFOBBMNNCD.CrossFade("bazooka_run");
			break;
		case Weapon.IGGFMJAKLGO.SwatPistol:
		case Weapon.IGGFMJAKLGO.SwatSMG:
			LOFOBBMNNCD.CrossFade("shield_run");
			break;
		case Weapon.IGGFMJAKLGO.Minigun:
			LOFOBBMNNCD.CrossFade("minigun_run");
			break;
		case Weapon.IGGFMJAKLGO.Pistol:
			LOFOBBMNNCD.CrossFade("pistol_run");
			break;
		case Weapon.IGGFMJAKLGO.Grenade:
			LOFOBBMNNCD.CrossFade("grenade_run");
			break;
		case Weapon.IGGFMJAKLGO.GrenadeLauncher:
			LOFOBBMNNCD.CrossFade("run_grenadelauncher");
			break;
		case Weapon.IGGFMJAKLGO.Shotgun:
		case Weapon.IGGFMJAKLGO.Machinegun:
			LOFOBBMNNCD.CrossFade("shotgunner_run");
			break;
		case Weapon.IGGFMJAKLGO.QBZ:
			LOFOBBMNNCD.CrossFade("qbz_run");
			break;
		case Weapon.IGGFMJAKLGO.QBZ2:
			LOFOBBMNNCD.CrossFade("qbz2_run");
			break;
		case Weapon.IGGFMJAKLGO.SniperRiffle:
			LOFOBBMNNCD.CrossFade("sniper_run");
			break;
		case Weapon.IGGFMJAKLGO.Tool:
			LOFOBBMNNCD.CrossFade("engineer_run");
			break;
		case Weapon.IGGFMJAKLGO.Flamethrower:
			LOFOBBMNNCD.CrossFade("flamethrower_run");
			break;
		case Weapon.IGGFMJAKLGO.DoubleSMG:
			LOFOBBMNNCD.CrossFade("SMG_run");
			break;
		case Weapon.IGGFMJAKLGO.Colt:
			LOFOBBMNNCD.CrossFade("colt_run", 0.2f);
			break;
		case Weapon.IGGFMJAKLGO.Mortar:
			LOFOBBMNNCD.CrossFade("mortar_run", 0.2f);
			break;
		default:
			LOFOBBMNNCD.CrossFade("run");
			break;
		}
	}

	private string EGNJIBFGMJA(Weapon.IGGFMJAKLGO BEACDIILBEG, out float JPNAINOGAMM)
	{
		JPNAINOGAMM = 1854f;
		switch (BEACDIILBEG)
		{
		case Weapon.IGGFMJAKLGO.Pistol:
			return "onFirstPlaylistDownloaded";
		case Weapon.IGGFMJAKLGO.GrenadeLauncher:
		case Weapon.IGGFMJAKLGO.Shotgun:
			return "ID_INSTANTBATTLEHINT1";
		case (Weapon.IGGFMJAKLGO)57:
			return "DeviceToken";
		case (Weapon.IGGFMJAKLGO)239:
			return "playerId";
		case (Weapon.IGGFMJAKLGO)164:
			return "null customization for: ";
		default:
			JPNAINOGAMM = 811f;
			return "unity";
		}
	}
}
