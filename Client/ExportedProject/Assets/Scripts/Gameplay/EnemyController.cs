using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyController : AIObjectG<SoldierBehaviour>, NKMKCCDCHCL, KMNCIJPDFPJ, KMHCMCBGFFC
{
	public enum AJGFGCHCAPA
	{
		Walk,
		Idle,
		ObstacleHiding,
		CornerHiding,
		Rusher,
		Vehicle,
		Parachute,
		Helicopter,
		Swat,
		MachineGunPoint,
		Minigunner,
		EngineerTurret,
		EngineerRepair,
		Fly,
		RusherSpare,
		Gunslinger,
		Mortar,
		Warp
	}

	private enum OLHLGDLDGPP
	{
		Driving,
		Spawning,
		Spawned,
		Falling
	}

	[FormerlySerializedAs("LPAJIFHNLKO")]
	public NavigationAgent HJFHCPBADLD;

	[FormerlySerializedAs("IILHBBEDLPP")]
	public DestroyableObjectMultipleParts OJIHGNJFPFM;

	[FormerlySerializedAs("OFCBADJNJHF")]
	public Kevlar PAOIHIANLOC;

	[FormerlySerializedAs("ENPBILNLGGE")]
	public UnitShield JPBBAIGNBAP;

	[FormerlySerializedAs("AJNMLEGNFMJ")]
	public EnemyPoint NLGBGOGCNKP;

	[FormerlySerializedAs("HDKFBMHJFGP")]
	public bool JCKHCELHDBH;

	[FormerlySerializedAs("IHIBKBDPFKD")]
	public SoldierParts EFFIOHJHFHI;

	[SerializeField]
	private DestroyableObject mShield;

	[SerializeField]
	public SoldierAnimationController mSoldierAnimationController;

	[SerializeField]
	private SoldierMeshChanger mSoldierSoldierMeshChanger;

	[FormerlySerializedAs("APAECJDOAIL")]
	public Transform NGCDDPCAGJB;

	private bool JEPEEJIMFOE = true;

	private bool ILPLGCOCODB;

	private float HJEJNIJPFHF;

	private bool KOKLMCHFKJC = true;

	public AJGFGCHCAPA IPIKDCMLOID;

	[FormerlySerializedAs("APJHOIONFGC")]
	public HeadSizeSetter BOFNGHCJPFM;

	private Material DNBEAILMLLJ;

	private float JPAEIIEPIPC;

	private bool DNIIIIBHIJB;

	[FormerlySerializedAs("JLLGBPOMHLJ")]
	public bool PFKPCFCEDME;

	private bool NJMMMLKFPAB;

	private float EIFMONFPJGA;

	private OLHLGDLDGPP KACEPCMMJHN;

	private bool MFHLBKPFMOK;

	private bool MJFJEKPHKJA;

	private bool FMFKLFMGFAO;

	private float ONHLGNIBFGG;

	private float DNCNFMPNOBA;

	private float FOIFLGLALIN;

	private float NEALNLKFEJB;

	private bool KPOGMFIOGMD;

	private float NOLOFNKPIDB;

	private float EGFFPINOONI = 5f;

	private INJKDMBLOAE EBEPNOMNPPL = new INJKDMBLOAE();

	private float PDDOJAMAOHB;

	private int JGCLNHNMDMH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<EnemyController> AHIJJJBIDPD;

	private bool MLFKPOMJMOP;

	private Parachute GGDGAHPEDCC;

	private float FBIKDDGEENF;

	private bool KAKIEBINCDL;

	private bool JNAJGJFOIJD;

	[FormerlySerializedAs("LELFKPCNEBA")]
	public bool GBBFIPKBJGG = true;

	private EnemyPointHelicopter KMCIJJHJJLG;

	private bool ALBLFGNKNDB;

	[FormerlySerializedAs("ODJLKLFAKGK")]
	public bool KIHGHENBPOP;

	private List<GameObject> BGDGEJDKJOP;

	private float DHMGLBICCGC;

	private float PEPDEICKMON;

	private bool NBMPLHLIHOD;

	private float PICFNOPKGGL;

	private float OEHBBHIICCI;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private SpawnPoint _003CADIEPDJJMPM_003Ek__BackingField;

	private bool LFPCMNHOPOP;

	private Vector3 KKAHNPEGPEJ;

	private int LPPGFDGBLNP;

	private Vector3 NBHJGBNMEND;

	private PlayerPoint MPEENGAHOHJ;

	private double OGKDKBNHHAA = 0.18;

	private LHMCMJDDOHI LADBLHGBOKJ = new LHMCMJDDOHI();

	private bool HNIGGHFHHAH;

	private int IECKPDOFCFC = 4;

	private float KDDEPAFBNLH;

	public bool canBeFreezed => IPIKDCMLOID != AJGFGCHCAPA.Vehicle && IPIKDCMLOID != AJGFGCHCAPA.Helicopter && IPIKDCMLOID != AJGFGCHCAPA.MachineGunPoint;

	private bool NBPAEDNBFGE => IPIKDCMLOID == AJGFGCHCAPA.ObstacleHiding || IPIKDCMLOID == AJGFGCHCAPA.CornerHiding || IPIKDCMLOID == AJGFGCHCAPA.Rusher || IPIKDCMLOID == AJGFGCHCAPA.Swat || IPIKDCMLOID == AJGFGCHCAPA.MachineGunPoint || IPIKDCMLOID == AJGFGCHCAPA.Minigunner || IPIKDCMLOID == AJGFGCHCAPA.EngineerTurret || IPIKDCMLOID == AJGFGCHCAPA.RusherSpare;

	public bool allowShoot
	{
		set
		{
			DNIIIIBHIJB = value;
		}
	}

	public bool isCovered => MFHLBKPFMOK;

	public bool isRunning => FMFKLFMGFAO;

	public override DestroyableObject destroyableObj => OJIHGNJFPFM;

	public int rusherCounts
	{
		get
		{
			int num = 0;
			foreach (MapDefinition.DefendPosition item in Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD)
			{
				if (item.fraction == fraction)
				{
					continue;
				}
				foreach (EnemyPointRusher item2 in item.point.JGAIPICHEDP)
				{
					if (!item2.isFree)
					{
						num++;
					}
				}
			}
			return num;
		}
	}

	public new bool isInField => Singleton<MapManager>.instance.ALCHJDPKAID != null && Singleton<MapManager>.instance.ALCHJDPKAID.CMJBHHBKKAF != null && Singleton<MapManager>.instance.ALCHJDPKAID.CMJBHHBKKAF.bounds.Contains(base.transform.position);

	public SoldierBehaviour soldierBehaviour => (SoldierBehaviour)ACLDFHJKBLI;

	public SpawnPoint spawnPoint
	{
		[CompilerGenerated]
		get
		{
			return _003CADIEPDJJMPM_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CADIEPDJJMPM_003Ek__BackingField = value;
		}
	}

	public SoldierMeshChanger meshChanger => mSoldierSoldierMeshChanger;

	public string[] playerVisuals
	{
		get
		{
			return EBEPNOMNPPL.CMBKCHADJPD;
		}
		set
		{
			EBEPNOMNPPL.CMBKCHADJPD = value;
		}
	}

	public PlayerVisualCategoryCamos.PlayerVisualCamo equippedCamo
	{
		get
		{
			return EBEPNOMNPPL.NHOJPACPJEO;
		}
		set
		{
			EBEPNOMNPPL.NHOJPACPJEO = value;
		}
	}

	public PlayerVisualCategoryHelmets.PlayerVisualHelmet equippedHelmet
	{
		get
		{
			return EBEPNOMNPPL.POHFJHBABAF;
		}
		set
		{
			EBEPNOMNPPL.POHFJHBABAF = value;
		}
	}

	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory equippedHeadAccesory
	{
		get
		{
			return EBEPNOMNPPL.IPJIPGILEHF;
		}
		set
		{
			EBEPNOMNPPL.IPJIPGILEHF = value;
		}
	}

	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand equippedPowerBand
	{
		get
		{
			return EBEPNOMNPPL.EOHJMNFLAIK;
		}
		set
		{
			EBEPNOMNPPL.EOHJMNFLAIK = value;
		}
	}

	public bool canDie
	{
		set
		{
		}
	}

	public event Action<EnemyController> onShoot
	{
		add
		{
			Action<EnemyController> action = AHIJJJBIDPD;
			Action<EnemyController> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref AHIJJJBIDPD, (Action<EnemyController>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<EnemyController> action = AHIJJJBIDPD;
			Action<EnemyController> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref AHIJJJBIDPD, (Action<EnemyController>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void GDIFMGKEPGP()
	{
		if (PDDOJAMAOHB > PEPDEICKMON)
		{
			PEPDEICKMON = float.MaxValue;
			KDDEPAFBNLH = PDDOJAMAOHB;
			HJFHCPBADLD.speed = 0.2f;
			HJFHCPBADLD.SetDestination(ACAEFIMAAMB());
			Walk();
			if (IECKPDOFCFC == 0)
			{
				if (NLGBGOGCNKP != null)
				{
					if (!NLGBGOGCNKP.isActive)
					{
						EnemyPointRusher nLGBGOGCNKP = HOPDNNKAEOK();
						NLGBGOGCNKP.IDNNIHBIMNO = null;
						NLGBGOGCNKP = nLGBGOGCNKP;
					}
					NLGBGOGCNKP.IDNNIHBIMNO = this;
					HJFHCPBADLD.SetDestination(NLGBGOGCNKP.position);
					Walk();
					HJEJNIJPFHF = float.MaxValue;
					HJEJNIJPFHF = PDDOJAMAOHB;
					IECKPDOFCFC = -1;
				}
				ALBLFGNKNDB = true;
			}
			else
			{
				IECKPDOFCFC--;
				ALBLFGNKNDB = false;
			}
		}
		if (PEPDEICKMON == float.MaxValue)
		{
			if (PDDOJAMAOHB < KDDEPAFBNLH + 0.5f)
			{
				HJFHCPBADLD.speed = Mathf.Lerp(0.2f, soldierBehaviour.soldierBehaviourDefinititon.speed, (PDDOJAMAOHB - KDDEPAFBNLH) / 0.5f);
			}
			if (PDDOJAMAOHB > KDDEPAFBNLH + 1.5f && HJFHCPBADLD.speed < 2f)
			{
				HJFHCPBADLD.speed = 20f;
				HJFHCPBADLD.Warp();
				Warp();
			}
		}
		float num = base.transform.position.PlanarDistance(HJFHCPBADLD.destnation);
		if (num < 0.5f && PEPDEICKMON == float.MaxValue && IECKPDOFCFC >= 0)
		{
			PEPDEICKMON = PDDOJAMAOHB + 0.5f;
			WarpIdle();
		}
		if (NLGBGOGCNKP != null && NLGBGOGCNKP.IsEnemyPointReached(NGCDDPCAGJB.position) && IECKPDOFCFC < 0)
		{
			HJFHCPBADLD.speed = soldierBehaviour.soldierBehaviourDefinititon.speed;
			BEBFKOFFACA();
			WarpIdle();
			KBHGKGGCOJE();
		}
	}

	[PunRPC]
	public void ImproveAllWeaponsRPC(float IOOJGHMOODB)
	{
		soldierBehaviour.ImproveAllWeapons(IOOJGHMOODB);
	}

	private void AGKAKBFNKOC()
	{
		NLGBGOGCNKP = soldierBehaviour.GetInitPoint();
		HNIGGHFHHAH = UnityEngine.Random.value > 0.5f;
		IECKPDOFCFC = UnityEngine.Random.Range(1, 3);
		PEPDEICKMON = PDDOJAMAOHB - 1f;
		ALBLFGNKNDB = false;
		KDDEPAFBNLH = float.MaxValue;
		if (NLGBGOGCNKP != null)
		{
			NLGBGOGCNKP.IDNNIHBIMNO = this;
			HJFHCPBADLD.SetDestination(NLGBGOGCNKP.position);
			Walk();
			HJEJNIJPFHF = float.MaxValue;
			HJEJNIJPFHF = PDDOJAMAOHB;
		}
		else
		{
			InvokeAfter(AGKAKBFNKOC, 2f);
		}
	}

	private void ALHNOGPCEAL()
	{
		if (NJMMMLKFPAB && isInField)
		{
			NJMMMLKFPAB = true;
			HJFHCPBADLD.Fly(NLGBGOGCNKP.PFOBADFGAKF(), 1026f);
			HJFHCPBADLD.Disable();
			StartFlying();
			EFFIOHJHFHI.AGJKJMGCCKC(fraction);
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[1];
			array[1] = true;
			lAADDLGBFIG.RPC("setCustomProfileStringValue", PhotonTargets.Others, array);
			GenerateNextShootTime();
		}
		if (Vector3.Distance(NGCDDPCAGJB.position, HJFHCPBADLD.OPFIGHPNDGK) < 1035f)
		{
			if (!ALBLFGNKNDB && HJFHCPBADLD.curentPathIndex > 0)
			{
				Crawl();
				ALBLFGNKNDB = true;
				EFFIOHJHFHI.LessJetPackParticles();
				LAADDLGBFIG.RPC("ID_TWITTER_FOLLOWING_TITLE", PhotonTargets.Others, true);
				EndShooting();
			}
			NOLOFNKPIDB += Time.deltaTime;
			if (NOLOFNKPIDB >= EGFFPINOONI)
			{
				EnemyPoint enemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP) ?? NLGBGOGCNKP;
				if (enemyPoint != null)
				{
					NOLOFNKPIDB = 460f;
					if (enemyPoint == NLGBGOGCNKP)
					{
						HJFHCPBADLD.Fly(enemyPoint.KOFFAHEAHEN(), UnityEngine.Random.Range(848f, 563f), base.transform.rotation);
					}
					else
					{
						HJFHCPBADLD.Fly(enemyPoint.PBFDGDPLFKN(), 861f);
					}
					NLGBGOGCNKP.IDNNIHBIMNO = null;
					NLGBGOGCNKP = enemyPoint;
					NLGBGOGCNKP.IDNNIHBIMNO = this;
					HJFHCPBADLD.enabled = false;
					InvokeAfter(delegate
					{
						HJFHCPBADLD.enabled = true;
					}, 1771f);
					EGFFPINOONI = UnityEngine.Random.Range(5, 4);
					ALBLFGNKNDB = true;
					StartFlying();
					EFFIOHJHFHI.JIFFEODOBBB(fraction);
					PhotonView lAADDLGBFIG2 = LAADDLGBFIG;
					object[] array2 = new object[1];
					array2[1] = true;
					lAADDLGBFIG2.RPC("ID_ZEROSECONDS", PhotonTargets.Others, array2);
					GenerateNextShootTime();
				}
			}
		}
		if (HJFHCPBADLD.curentPathIndex == 0 && !NJMMMLKFPAB)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
			Vector3 forward = enemyOf.transform.position - NGCDDPCAGJB.position;
			forward.y = 1077f;
			HJFHCPBADLD.KAIFFKDJCAG(Quaternion.LookRotation(forward));
			if (PDDOJAMAOHB > HJEJNIJPFHF && (NGCDDPCAGJB.position.PlanarDistance(HJFHCPBADLD.OPFIGHPNDGK) > 421f || HJFHCPBADLD.stayTime < HJFHCPBADLD.NFAGEJPAEDD().KBJEOEEOEFG * 1970f))
			{
				KGDPPCIEJEI(JNPBHFODMKI: true, ILEOEIMBILP: false, 168f);
			}
		}
	}

	public void UpdateHeadScale(float FLPHBJHLHKE)
	{
		LAADDLGBFIG.RPC("UpdateHeadScaleRPC", PhotonTargets.Others, FLPHBJHLHKE);
		UpdateHeadScaleRPC(FLPHBJHLHKE);
	}

	[SpecialName]
	public void OFALNGGHMOF(PlayerVisualCategoryCamos.PlayerVisualCamo IDEBKDPMPGM)
	{
		EBEPNOMNPPL.FEIPMOCLDAP(IDEBKDPMPGM);
	}

	public void INKAJPHFFIJ(float KMMAKDHKIKH, int DFHAAIFFLOE)
	{
		OJIHGNJFPFM.AMEELJHHGKP[DFHAAIFFLOE].CMFNOLDCGCL *= KMMAKDHKIKH;
	}

	private void CLOFKKFKPKB()
	{
		LPPGFDGBLNP = soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax;
		HJFHCPBADLD.Stop();
		HJEJNIJPFHF = PDDOJAMAOHB;
		PEPDEICKMON = PDDOJAMAOHB + UnityEngine.Random.Range(2f, 4f);
		SnapColt(BBAOMJODMDH: false);
	}

	public void SwitchStateToMachineGun()
	{
		EnemyPointTower enemyPointTower = (EnemyPointTower)NLGBGOGCNKP;
		ShadowSetActive(IDEBKDPMPGM: false);
		HJFHCPBADLD.Stop();
		Idle();
		EFFIOHJHFHI.MakeTrigger(IDEBKDPMPGM: true);
		NGCDDPCAGJB.position = enemyPointTower.BFLCHKHICGM.position;
		NGCDDPCAGJB.rotation = enemyPointTower.BFLCHKHICGM.rotation;
		soldierBehaviour.KHKAAGCIJPO.gameObject.SetActive(value: false);
	}

	private void IKNPFCIDDHM()
	{
		KOKLMCHFKJC = false;
		WeaponIgnoreLayer(TagsAndLayers.JNCLCGHJAOO);
		FBIKDDGEENF = 0f;
		EnemyPointRusher enemyPointRusher = (EnemyPointRusher)NLGBGOGCNKP;
		HJFHCPBADLD.Stop();
		Idle();
		Vector3 position = enemyPointRusher.position;
		position.y = NGCDDPCAGJB.position.y;
		TweenPosition.Begin(base.gameObject, 0.5f, position);
		Vector3 forward = enemyPointRusher.playerPoint.transform.position - NGCDDPCAGJB.position;
		forward.y = 0f;
		TweenRotation.Begin(base.gameObject, 0.3f, Quaternion.LookRotation(forward)).ignoreTimeScale = false;
		JNAJGJFOIJD = true;
		HJEJNIJPFHF = PDDOJAMAOHB + 0.5f;
	}

	private void HAJHPLNFEBM()
	{
		if (!NBPAEDNBFGE && NLGBGOGCNKP != null && NLGBGOGCNKP.IsEnemyPointReached(NGCDDPCAGJB.position) && !NBMPLHLIHOD)
		{
			KBHGKGGCOJE();
		}
		if (KOKLMCHFKJC)
		{
			if (!NBPAEDNBFGE && PDDOJAMAOHB > HJEJNIJPFHF && soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunning && isInField && !soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunningDontStop && !NBMPLHLIHOD && NGCDDPCAGJB.position.PlanarDistance(NLGBGOGCNKP.position) > 1f)
			{
				soldierBehaviour.StandShoot();
			}
			if (!NBPAEDNBFGE && PDDOJAMAOHB > HJEJNIJPFHF && isInField && soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunningDontStop && !NBMPLHLIHOD && NLGBGOGCNKP != null && NGCDDPCAGJB.position.PlanarDistance(NLGBGOGCNKP.position) > 1f)
			{
				NIHCAFPBOPJ();
			}
		}
		if (!(NLGBGOGCNKP != null))
		{
			return;
		}
		if (Vector3.Distance(NLGBGOGCNKP.position, HJFHCPBADLD.destnation) > 0.5f && !NBMPLHLIHOD && !HJFHCPBADLD.isStopped)
		{
			FBIKDDGEENF += Time.deltaTime;
			SetFinalTarget(NLGBGOGCNKP);
			FBIKDDGEENF = 0f;
		}
		if (NLGBGOGCNKP is EnemyPointRusher)
		{
			if (!NLGBGOGCNKP.isActive && !NBMPLHLIHOD && !HJFHCPBADLD.isStopped)
			{
				FBIKDDGEENF += Time.deltaTime;
				if (FBIKDDGEENF > 1.5f)
				{
					FBIKDDGEENF = 0f;
					EnemyPointRusher finalTarget = HOPDNNKAEOK();
					SetFinalTarget(finalTarget);
				}
			}
			if (NLGBGOGCNKP.isActive)
			{
				FBIKDDGEENF = 0f;
			}
		}
		if (!NLGBGOGCNKP.gameObject.activeInHierarchy)
		{
			GDLEFNAGBLC();
		}
	}

	private bool GDLEFNAGBLC(EnemyPoint PLMMBKGLGAB = null)
	{
		EnemyPoint initPoint = soldierBehaviour.GetInitPoint();
		if (PLMMBKGLGAB == null)
		{
			if (initPoint != null)
			{
				SetFinalTarget(initPoint);
				SwitchState(AJGFGCHCAPA.Walk);
			}
			else
			{
				InvokeAfter(delegate
				{
					GDLEFNAGBLC();
				}, 5f);
			}
			return false;
		}
		SetFinalTarget(PLMMBKGLGAB);
		return true;
	}

	private void PIKKIHGLNIN()
	{
		LADBLHGBOKJ.NFGMGBMCNOF(NGCDDPCAGJB);
	}

	public void SpawnFromHelicopter()
	{
		if (IPIKDCMLOID == AJGFGCHCAPA.Helicopter)
		{
			KACEPCMMJHN = OLHLGDLDGPP.Spawning;
			RopeSlide();
			Vector3 position = (NLGBGOGCNKP as EnemyPointHelicopter).MOIAAKCCFDI.position;
			NavMesh.SamplePosition(position, out var hit, 10f, 1);
			KMCIJJHJJLG = NLGBGOGCNKP as EnemyPointHelicopter;
			BGDGEJDKJOP = KMCIJJHJJLG.HCCENNJFGMA.NLIGPBPNHHP.Joints;
			FOIFLGLALIN = 0f;
			PICFNOPKGGL = base.transform.position.y;
			OEHBBHIICCI = hit.position.y;
		}
	}

	private bool KGDPPCIEJEI(bool JNPBHFODMKI, bool ILEOEIMBILP, float ADJIAOPMJDK = 0f)
	{
		if (!DNIIIIBHIJB)
		{
			return false;
		}
		soldierBehaviour.PickTarget();
		if (ADJIAOPMJDK > 0f && Vector3.Distance(NGCDDPCAGJB.position, soldierBehaviour.OEDJOFINBMI) > ADJIAOPMJDK)
		{
			NBMPLHLIHOD = false;
			return false;
		}
		if (ILEOEIMBILP)
		{
			Vector3 jGBFNKBFCKM = NGCDDPCAGJB.position + Vector3.up * 0.2f;
			if (soldierBehaviour.KHKAAGCIJPO.GHPBMCAKMMB != null)
			{
				jGBFNKBFCKM.y = soldierBehaviour.KHKAAGCIJPO.GHPBMCAKMMB.position.y;
			}
			if (!CanSeeTarget(jGBFNKBFCKM, soldierBehaviour.OEDJOFINBMI))
			{
				NBMPLHLIHOD = false;
				return false;
			}
		}
		mSoldierAnimationController.ForceInScreen();
		if (!soldierBehaviour.StartShooting())
		{
			GenerateNextShootTime();
			return false;
		}
		if (JNPBHFODMKI)
		{
			Vector3 forward = soldierBehaviour.OEDJOFINBMI - NGCDDPCAGJB.position;
			forward.y = 0f;
			TweenRotation.Begin(base.gameObject, 0.2f, Quaternion.LookRotation(forward)).ignoreTimeScale = false;
		}
		if (IPIKDCMLOID == AJGFGCHCAPA.CornerHiding)
		{
			EnemyPointCorner enemyPointCorner = NLGBGOGCNKP as EnemyPointCorner;
			if (enemyPointCorner != null)
			{
				float num = GeometryTools.AngleSigned(-enemyPointCorner.PLEBANKIBPP, soldierBehaviour.OEDJOFINBMI - NGCDDPCAGJB.position, Vector3.up);
				if ((KAKIEBINCDL = num > 0f) != enemyPointCorner.NHKBMMIHAFH || Mathf.Abs(num) < 10f)
				{
					return false;
				}
				Vector3 vector = soldierBehaviour.OEDJOFINBMI - NGCDDPCAGJB.position;
				Quaternion quaternion = Quaternion.LookRotation(-enemyPointCorner.PLEBANKIBPP);
				float num2 = GeometryTools.AngleSigned(-vector, -enemyPointCorner.PLEBANKIBPP, Vector3.up);
				Quaternion rot = quaternion * Quaternion.AngleAxis(0f - num2, Vector3.up);
				vector.y = 0f;
				TweenRotation.Begin(base.gameObject, 0.3f, rot).ignoreTimeScale = false;
			}
		}
		switch (soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG)
		{
		case Weapon.IGGFMJAKLGO.Riffle:
		case Weapon.IGGFMJAKLGO.Pistol:
		case Weapon.IGGFMJAKLGO.GrenadeLauncher:
		case Weapon.IGGFMJAKLGO.Shotgun:
		case Weapon.IGGFMJAKLGO.QBZ:
		case Weapon.IGGFMJAKLGO.SniperRiffle:
		case Weapon.IGGFMJAKLGO.Flamethrower:
		case Weapon.IGGFMJAKLGO.QBZ2:
		case Weapon.IGGFMJAKLGO.DoubleSMG:
		case Weapon.IGGFMJAKLGO.Machinegun:
		case Weapon.IGGFMJAKLGO.Colt:
			switch (IPIKDCMLOID)
			{
			case AJGFGCHCAPA.Walk:
				ShootStand();
				MDKABJDCKBI(mSoldierAnimationController.StandShootLength(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG) * 0.3f);
				break;
			case AJGFGCHCAPA.ObstacleHiding:
				ShootFromCrawl(1f);
				MDKABJDCKBI(mSoldierAnimationController.GetStandUpFromCrawlLength(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG) + 0.05f);
				break;
			case AJGFGCHCAPA.CornerHiding:
				ShootFromCover(!KAKIEBINCDL, 0.7f);
				MDKABJDCKBI(mSoldierAnimationController.uncoverLength + 0.05f);
				break;
			case AJGFGCHCAPA.Rusher:
			case AJGFGCHCAPA.RusherSpare:
			{
				ShootStand();
				bool flag = soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG == Weapon.IGGFMJAKLGO.Flamethrower;
				MDKABJDCKBI(mSoldierAnimationController.StandShootLength(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG) * ((!flag) ? 0.3f : 0f));
				break;
			}
			case AJGFGCHCAPA.Swat:
				ShootStand();
				MDKABJDCKBI(0.1f);
				break;
			case AJGFGCHCAPA.Helicopter:
				ShootStand();
				MDKABJDCKBI(0.5f);
				break;
			case AJGFGCHCAPA.Parachute:
				ShootStand();
				MDKABJDCKBI(mSoldierAnimationController.StandShootLength(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG) * 0.3f);
				break;
			case AJGFGCHCAPA.Fly:
				MDKABJDCKBI(0.05f);
				break;
			case AJGFGCHCAPA.Gunslinger:
				ShootStandNew(1f);
				MDKABJDCKBI(mSoldierAnimationController.GetStandPhase0Length(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG));
				break;
			}
			break;
		case Weapon.IGGFMJAKLGO.Grenade:
			switch (IPIKDCMLOID)
			{
			case AJGFGCHCAPA.Walk:
				ThrowGrenadeFromCrawl();
				MDKABJDCKBI(0.35f);
				break;
			case AJGFGCHCAPA.ObstacleHiding:
				ThrowGrenadeFromCrawl();
				MDKABJDCKBI(0.35f);
				break;
			case AJGFGCHCAPA.CornerHiding:
				ThrowGrenadeFromCover(!KAKIEBINCDL);
				MDKABJDCKBI(0.6f);
				break;
			case AJGFGCHCAPA.Fly:
				ShootStand();
				MDKABJDCKBI(0.3f);
				break;
			}
			break;
		case Weapon.IGGFMJAKLGO.Bazooka:
			switch (IPIKDCMLOID)
			{
			case AJGFGCHCAPA.ObstacleHiding:
				ShootFromBazookaFromCrawl();
				MDKABJDCKBI(0.87f);
				break;
			case AJGFGCHCAPA.CornerHiding:
				ShootFromBazookaFromCover(KAKIEBINCDL);
				MDKABJDCKBI(0.7f);
				break;
			case AJGFGCHCAPA.Fly:
				ShootStand();
				MDKABJDCKBI(0.3f);
				break;
			}
			break;
		case Weapon.IGGFMJAKLGO.SwatPistol:
		case Weapon.IGGFMJAKLGO.SwatSMG:
			switch (IPIKDCMLOID)
			{
			case AJGFGCHCAPA.Walk:
				ShootFromShield();
				MDKABJDCKBI(mSoldierAnimationController.swatShieldUncoverLength);
				break;
			case AJGFGCHCAPA.Rusher:
			case AJGFGCHCAPA.RusherSpare:
				ShootFromShield();
				MDKABJDCKBI(mSoldierAnimationController.swatShieldUncoverLength);
				break;
			case AJGFGCHCAPA.Swat:
				ShootFromShield();
				MDKABJDCKBI(mSoldierAnimationController.swatShieldUncoverLength);
				break;
			}
			break;
		case Weapon.IGGFMJAKLGO.Minigun:
			switch (IPIKDCMLOID)
			{
			case AJGFGCHCAPA.Walk:
				ShootStand();
				MDKABJDCKBI(0.5f);
				break;
			case AJGFGCHCAPA.Swat:
				ShootStand();
				MDKABJDCKBI(0.1f);
				break;
			case AJGFGCHCAPA.Helicopter:
				ShootStand();
				MDKABJDCKBI(0.5f);
				break;
			case AJGFGCHCAPA.Parachute:
				ShootStand();
				MDKABJDCKBI(0.3f);
				break;
			case AJGFGCHCAPA.Minigunner:
				ShootStand();
				MDKABJDCKBI(0.1f);
				break;
			}
			break;
		case Weapon.IGGFMJAKLGO.Mortar:
		{
			AJGFGCHCAPA iPIKDCMLOID = IPIKDCMLOID;
			if (iPIKDCMLOID == AJGFGCHCAPA.Mortar)
			{
				MDKABJDCKBI(0.3f);
			}
			break;
		}
		}
		NBMPLHLIHOD = true;
		return true;
	}

	public void StartEnemyBehaviour(AJGFGCHCAPA MJGBKHOFNHK)
	{
		KPOGMFIOGMD = false;
		IPIKDCMLOID = MJGBKHOFNHK;
		base.StartEnemyBehaviour();
		if (!KPOGMFIOGMD)
		{
			switch (MJGBKHOFNHK)
			{
			case AJGFGCHCAPA.Helicopter:
				SwitchState(AJGFGCHCAPA.Helicopter);
				ShadowSetActive(IDEBKDPMPGM: false);
				break;
			case AJGFGCHCAPA.Vehicle:
				SwitchState(AJGFGCHCAPA.Vehicle);
				ShadowSetActive(IDEBKDPMPGM: false);
				break;
			case AJGFGCHCAPA.Parachute:
				StopAllCoroutines();
				SwitchState(AJGFGCHCAPA.Parachute);
				ShadowSetActive(IDEBKDPMPGM: false);
				break;
			case AJGFGCHCAPA.Fly:
				StopAllCoroutines();
				SwitchState(AJGFGCHCAPA.Fly);
				ShadowSetActive(IDEBKDPMPGM: false);
				break;
			case AJGFGCHCAPA.Warp:
				StopAllCoroutines();
				SwitchState(AJGFGCHCAPA.Warp);
				break;
			default:
				Walk();
				GDLEFNAGBLC();
				break;
			}
		}
	}

	private void HPBEMKDEJEF()
	{
		GenerateNextShootTime();
		if (LAADDLGBFIG.isMine)
		{
			if (!base.isAlive)
			{
				return;
			}
			switch (IPIKDCMLOID)
			{
			case AJGFGCHCAPA.ObstacleHiding:
				ALBLFGNKNDB = true;
				break;
			case AJGFGCHCAPA.CornerHiding:
				JNAJGJFOIJD = true;
				break;
			case AJGFGCHCAPA.Rusher:
			case AJGFGCHCAPA.RusherSpare:
				HJEJNIJPFHF = PDDOJAMAOHB + UnityEngine.Random.Range(2f, 4f);
				break;
			case AJGFGCHCAPA.Swat:
				HJEJNIJPFHF = PDDOJAMAOHB + UnityEngine.Random.Range(2f, 4f);
				break;
			case AJGFGCHCAPA.Walk:
				InvokeAfter(delegate
				{
					HJFHCPBADLD.Resume();
					Walk();
				}, 0.8f);
				break;
			case AJGFGCHCAPA.Helicopter:
				TweenRotation.Begin(base.gameObject, 0.3f, NLGBGOGCNKP.transform.rotation);
				break;
			case AJGFGCHCAPA.Minigunner:
				HJEJNIJPFHF = PDDOJAMAOHB + 8f;
				break;
			case AJGFGCHCAPA.Parachute:
				break;
			case AJGFGCHCAPA.Fly:
				break;
			case AJGFGCHCAPA.Gunslinger:
				GJOFIBHCKCG();
				break;
			case AJGFGCHCAPA.Mortar:
				LGINGMJENOA();
				break;
			case AJGFGCHCAPA.Idle:
			case AJGFGCHCAPA.Vehicle:
			case AJGFGCHCAPA.MachineGunPoint:
			case AJGFGCHCAPA.EngineerTurret:
			case AJGFGCHCAPA.EngineerRepair:
				break;
			}
		}
		else
		{
			switch (IPIKDCMLOID)
			{
			case AJGFGCHCAPA.Rusher:
			case AJGFGCHCAPA.RusherSpare:
				Idle();
				break;
			case AJGFGCHCAPA.Swat:
				InvokeAfter(Idle, 0.2f);
				break;
			case AJGFGCHCAPA.Walk:
				InvokeAfter(Walk, 0.8f);
				break;
			}
		}
	}

	private void GJOFIBHCKCG()
	{
		HJEJNIJPFHF = PDDOJAMAOHB + (float)soldierBehaviour.KHKAAGCIJPO.JMDLKIAKOIE;
		PEPDEICKMON = PDDOJAMAOHB + 2f;
		if (LPPGFDGBLNP == 0)
		{
			InvokeAfter(delegate
			{
				SnapColt(BBAOMJODMDH: true);
			}, 1f);
		}
	}

	private void KHFCHOPFJBA()
	{
		if (JNAJGJFOIJD && PDDOJAMAOHB > HJEJNIJPFHF)
		{
			if (KGDPPCIEJEI(JNPBHFODMKI: false, ILEOEIMBILP: false))
			{
				JNAJGJFOIJD = false;
			}
			else
			{
				GenerateNextShootTime();
			}
		}
		if (JNAJGJFOIJD && PDDOJAMAOHB > DHMGLBICCGC && !ILPLGCOCODB)
		{
			EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP);
			if (newEnemyPoint != null && newEnemyPoint != NLGBGOGCNKP)
			{
				NLGBGOGCNKP.IDNNIHBIMNO = null;
				SetFinalTarget(newEnemyPoint);
				JNAJGJFOIJD = false;
				SwitchState(AJGFGCHCAPA.Walk);
			}
			else
			{
				DHMGLBICCGC += 10f;
			}
		}
	}

	public override void Spawn()
	{
		base.Spawn();
		if (LAADDLGBFIG.isMine && DIPLDDHLMME)
		{
			try
			{
				spawnPoint = soldierBehaviour.PickSpawnPoint(Singleton<MapManager>.instance.ALCHJDPKAID.DMCDJGLDICM.LIAEIIFPONK);
				NGCDDPCAGJB.position = spawnPoint.transform.position;
				TweenPosition.Begin(base.gameObject, 0f, NGCDDPCAGJB.position);
			}
			catch (Exception exception)
			{
				AnalyticsHelper.LogHandledException(exception);
			}
		}
	}

	public void StartEnemyBehaviour(AJGFGCHCAPA MJGBKHOFNHK, EnemyPoint MKIPAEDAADL)
	{
		base.StartEnemyBehaviour();
		SetStateTo(MJGBKHOFNHK, MKIPAEDAADL);
	}

	private void NKJEECFDGGN(AJGFGCHCAPA IGBEGIBGLKK)
	{
		if (IPIKDCMLOID != IGBEGIBGLKK)
		{
			IPIKDCMLOID = IGBEGIBGLKK;
			if (IGBEGIBGLKK == AJGFGCHCAPA.Vehicle)
			{
				EFFIOHJHFHI.MakeTrigger(IDEBKDPMPGM: true);
				OJIHGNJFPFM.SetText(string.Empty);
			}
		}
	}

	private bool NIHCAFPBOPJ()
	{
		if (!DNIIIIBHIJB)
		{
			return false;
		}
		soldierBehaviour.PickTarget();
		soldierBehaviour.StartShooting();
		Vector3 iFBJNODDLJC = soldierBehaviour.OEDJOFINBMI - NGCDDPCAGJB.position;
		iFBJNODDLJC.y = 0f;
		switch (soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG)
		{
		case Weapon.IGGFMJAKLGO.Riffle:
		case Weapon.IGGFMJAKLGO.Pistol:
		case Weapon.IGGFMJAKLGO.Shotgun:
		case Weapon.IGGFMJAKLGO.QBZ:
		case Weapon.IGGFMJAKLGO.SniperRiffle:
		case Weapon.IGGFMJAKLGO.Flamethrower:
		case Weapon.IGGFMJAKLGO.QBZ2:
		case Weapon.IGGFMJAKLGO.DoubleSMG:
		case Weapon.IGGFMJAKLGO.Machinegun:
		case Weapon.IGGFMJAKLGO.Colt:
			if (IPIKDCMLOID == AJGFGCHCAPA.Walk)
			{
				ShootWalk(iFBJNODDLJC);
				MDKABJDCKBI(0.35f);
			}
			break;
		}
		NBMPLHLIHOD = true;
		return true;
	}

	[PunRPC]
	private void PlayeScifiParticles(bool GKAKLBKHBMP)
	{
		if (GKAKLBKHBMP)
		{
			EFFIOHJHFHI.EnableJetPack(fraction);
		}
		else
		{
			EFFIOHJHFHI.LessJetPackParticles();
		}
	}

	private void OMPNAAMNDNH()
	{
		if (PDDOJAMAOHB > HJEJNIJPFHF && !NBMPLHLIHOD)
		{
			KGDPPCIEJEI(JNPBHFODMKI: true, ILEOEIMBILP: false);
		}
		else if (PDDOJAMAOHB > DHMGLBICCGC && !NBMPLHLIHOD && !ILPLGCOCODB)
		{
			EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP);
			if (newEnemyPoint != null && newEnemyPoint != NLGBGOGCNKP)
			{
				NLGBGOGCNKP.IDNNIHBIMNO = null;
				SetFinalTarget(newEnemyPoint);
				SwitchState(AJGFGCHCAPA.Walk);
			}
			else
			{
				DHMGLBICCGC += 2f;
			}
		}
	}

	[CompilerGenerated]
	private void BFNMEADKJEH()
	{
		GDLEFNAGBLC();
	}

	private void LGINGMJENOA()
	{
		HJEJNIJPFHF = float.MaxValue;
	}

	public override void DisableSpawn()
	{
		base.DisableSpawn();
		spawnPoint = null;
	}

	private void HEHBKBIEFNK()
	{
		HJFHCPBADLD.Stop();
		Idle();
		HJEJNIJPFHF = PDDOJAMAOHB + 0.5f;
	}

	private void EEAIPPGKEDM()
	{
		float num = ((!base.hasSpecial) ? (soldierBehaviour.soldierBehaviourDefinititon.special + 0.2f) : soldierBehaviour.soldierBehaviourDefinititon.special);
		JPAEIIEPIPC = PDDOJAMAOHB + num;
		KJMFJFCDEDH.Show("game-engi-progress-fill", IDEBKDPMPGM: true, HudObjectIndicator.NPPEJJKFCON.EngineerIco, (fraction != PlayerController.OGMBJPKOPCB.fraction) ? Colours.redProgress : Colours.blue);
		LAADDLGBFIG.RPC("ShowEngineerBuildingIndicator", PhotonTargets.Others, true, (byte)fraction);
		EnemyPointEngineerTurret enemyPointEngineerTurret = NLGBGOGCNKP as EnemyPointEngineerTurret;
		Vector3 forward = enemyPointEngineerTurret.turretPosition - NGCDDPCAGJB.position;
		forward.y = 0f;
		TweenRotation.Begin(base.gameObject, 0.3f, Quaternion.LookRotation(forward)).ignoreTimeScale = false;
		Repair();
	}

	[PunRPC]
	private void ShootAdditive()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ShootAdditive", PhotonTargets.Others);
		}
		mSoldierAnimationController.ShootStandAdditive(0.5f);
	}

	[CompilerGenerated]
	private void LAKDCPHEIOA()
	{
		HJFHCPBADLD.Resume();
		Walk();
	}

	[CompilerGenerated]
	private void OLHPHLEMOFB()
	{
		GDLEFNAGBLC();
	}

	public void BNGAJMFGEOG()
	{
		IPIKDCMLOID = (AJGFGCHCAPA)(-6);
		HNIGGHFHHAH = UnityEngine.Random.value > 75f;
		IECKPDOFCFC = UnityEngine.Random.Range(0, 2);
		PEPDEICKMON = 1134f;
		KDDEPAFBNLH = PDDOJAMAOHB - 1130f;
		HJFHCPBADLD.speed = 1106f;
		HJFHCPBADLD.CAGPIECMNFF(ACAEFIMAAMB());
		ALBLFGNKNDB = false;
	}

	[CompilerGenerated]
	private void NJAKNHEMPEC()
	{
		soldierBehaviour.BMNHHCCBAAN.SnapToHand();
	}

	[PunRPC]
	public void FreezeRPC(bool ALLIHOCMHBL)
	{
		Freeze(ALLIHOCMHBL);
	}

	public override void ReSync()
	{
		base.ReSync();
		if (base.isAlive)
		{
			if (mSoldierAnimationController.isIdle)
			{
				Idle();
			}
			if (mSoldierAnimationController.isRunning)
			{
				Walk();
			}
			if (mSoldierAnimationController.isSitting)
			{
				SittingIdle();
			}
			if (!EFFIOHJHFHI.OFBEAKDOCIO.gameObject.activeInHierarchy)
			{
				ShadowSetActive(IDEBKDPMPGM: false);
			}
		}
	}

	public void EndShooting()
	{
		ILPLGCOCODB = false;
		NBMPLHLIHOD = false;
		HPBEMKDEJEF();
	}

	[PunRPC]
	public void SoldierBehaviourSwitchWeapon(bool AFKKHLPPGLN)
	{
		if (soldierBehaviour != null)
		{
			soldierBehaviour.SwitchWeapon(AFKKHLPPGLN);
		}
	}

	public void ClearEnemyPoint()
	{
		if (NLGBGOGCNKP != null)
		{
			NLGBGOGCNKP.IDNNIHBIMNO = null;
			NLGBGOGCNKP = null;
		}
	}

	private PlayerPoint OMJNALBMLJG()
	{
		Vector3 b = NLGBGOGCNKP.PFOBADFGAKF();
		float num = 955f;
		PlayerPoint result = null;
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			if (item.Value.fraction != fraction && item.Value.EMAMENNDFMB() != null)
			{
				float num2 = Vector3.Distance(item.Value.CMNFFACHCEE().point.transform.position, b);
				if (num2 < num)
				{
					num = num2;
					result = item.Value.EMAMENNDFMB().point;
				}
			}
		}
		return result;
	}

	[PunRPC]
	private void SyncWarperRPC(Vector3 MPHCNMDIPAI, Quaternion OOMCGGAFJNH)
	{
		LADBLHGBOKJ.DBEGCIIADGF(PhotonNetwork.time, MPHCNMDIPAI, OOMCGGAFJNH);
	}

	private void MDKABJDCKBI(float NOLELDEJDDC)
	{
		GenerateNextShootTime();
		if (!base.isAlive)
		{
			return;
		}
		InvokeAfter(delegate
		{
			ILPLGCOCODB = true;
			soldierBehaviour.ShootJustStarted();
			if (AHIJJJBIDPD != null)
			{
				AHIJJJBIDPD(this);
			}
		}, NOLELDEJDDC);
	}

	[CompilerGenerated]
	private void ACOGPPFEKBP()
	{
		ILPLGCOCODB = true;
		soldierBehaviour.ShootJustStarted();
		if (AHIJJJBIDPD != null)
		{
			AHIJJJBIDPD(this);
		}
	}

	[PunRPC]
	private void ShootWalk(Vector3 IFBJNODDLJC)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ShootWalk", PhotonTargets.Others, IFBJNODDLJC);
		}
		mSoldierAnimationController.PLCAOODHLCA = false;
		mSoldierAnimationController.lookBack = false;
		mSoldierAnimationController.ShootStandAdditive(0.5f);
		mSoldierAnimationController.LookAtUpperBody(IFBJNODDLJC, 1f);
	}

	[CompilerGenerated]
	private void JNOBELBBDAJ()
	{
		GDLEFNAGBLC();
	}

	private void JPAMIAFBNCM()
	{
		NBHJGBNMEND = base.transform.position;
		HJFHCPBADLD.Disable();
		BuildMortar();
		SoldierBehaviourDefinititonMortar soldierBehaviourDefinititonMortar = soldierBehaviour.soldierBehaviourDefinititon as SoldierBehaviourDefinititonMortar;
		HJEJNIJPFHF = PDDOJAMAOHB + soldierBehaviourDefinititonMortar.mortarBuildTime;
		PEPDEICKMON = float.MaxValue;
		BGKINBJANBF();
	}

	private PlayerPoint FHILAMGAHKK()
	{
		Vector3 position = NLGBGOGCNKP.position;
		float num = float.MaxValue;
		PlayerPoint result = null;
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			if (item.Value.fraction != fraction && item.Value.currentPlayerPoint != null)
			{
				float num2 = Vector3.Distance(item.Value.currentPlayerPoint.point.transform.position, position);
				if (num2 < num)
				{
					num = num2;
					result = item.Value.currentPlayerPoint.point;
				}
			}
		}
		return result;
	}

	[PunRPC]
	private void ThrowGrenadeFromCover(bool DNDCODMGGEE)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ThrowGrenadeFromCover", PhotonTargets.Others, DNDCODMGGEE);
		}
		mSoldierAnimationController.ThrowGrenadeFromCover(DNDCODMGGEE, PAFEIGKCJPJ: false);
	}

	public void KGJNBKNHNDB(DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		EFFIOHJHFHI.MakeTrigger(IDEBKDPMPGM: false);
		mSoldierAnimationController.SampleDead();
		GetComponentInChildren<Animation>().enabled = false;
		EFFIOHJHFHI.EnableRagdol(JCKHCELHDBH);
		EFFIOHJHFHI.CGCKDIBIFFI.GetComponent<Rigidbody>().GetComponent<Rigidbody>().AddForce(OHJPPHFEAFI.LPGMLOCLBGP, ForceMode.Acceleration);
		EFFIOHJHFHI.OKOKOGCBCCF.OJGHLMLKGAN.GetComponent<Rigidbody>().AddForce(Vector3.up * UnityEngine.Random.Range(262f, 182f), ForceMode.Impulse);
		EFFIOHJHFHI.OKOKOGCBCCF.OJGHLMLKGAN.GetComponent<Rigidbody>().AddTorque(UnityEngine.Random.Range(364f, 48f), UnityEngine.Random.Range(1788f, 379f), 704f);
		if (JCKHCELHDBH)
		{
			EFFIOHJHFHI.DGHPFMPMAFC.OJGHLMLKGAN.GetComponent<Rigidbody>().AddForce(Vector3.up * UnityEngine.Random.Range(502f, 544f) + OHJPPHFEAFI.LPGMLOCLBGP * 214f, (ForceMode)6);
		}
	}

	private void FBFNDPFNGOJ()
	{
		HJFHCPBADLD.Stop();
		Idle();
		KACEPCMMJHN = OLHLGDLDGPP.Driving;
		TweenRotation.Begin(base.gameObject, 0.3f, NLGBGOGCNKP.transform.rotation);
	}

	private void DOENMNGLIDL()
	{
		if (NJMMMLKFPAB && isInField)
		{
			NJMMMLKFPAB = true;
			HJFHCPBADLD.Fly(NLGBGOGCNKP.FGKJILDKPHC(), 1871f);
			HJFHCPBADLD.Disable();
			StartFlying();
			EFFIOHJHFHI.AGJKJMGCCKC(fraction);
			PhotonView lAADDLGBFIG = LAADDLGBFIG;
			object[] array = new object[1];
			array[1] = true;
			lAADDLGBFIG.RPC("#AccoutCheck# Account exist check result NOT contain result message", PhotonTargets.Others, array);
			GenerateNextShootTime();
		}
		if (Vector3.Distance(NGCDDPCAGJB.position, HJFHCPBADLD.OPFIGHPNDGK) < 580f)
		{
			if (!ALBLFGNKNDB && HJFHCPBADLD.curentPathIndex > 1)
			{
				Crawl();
				ALBLFGNKNDB = false;
				EFFIOHJHFHI.LessJetPackParticles();
				PhotonView lAADDLGBFIG2 = LAADDLGBFIG;
				object[] array2 = new object[0];
				array2[1] = false;
				lAADDLGBFIG2.RPC("), ", PhotonTargets.All, array2);
				EndShooting();
			}
			NOLOFNKPIDB += Time.deltaTime;
			if (NOLOFNKPIDB >= EGFFPINOONI)
			{
				EnemyPoint enemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP) ?? NLGBGOGCNKP;
				if (enemyPoint != null)
				{
					NOLOFNKPIDB = 222f;
					if (enemyPoint == NLGBGOGCNKP)
					{
						HJFHCPBADLD.Fly(enemyPoint.PBFDGDPLFKN(), UnityEngine.Random.Range(580f, 1433f), base.transform.rotation);
					}
					else
					{
						HJFHCPBADLD.Fly(enemyPoint.MGPNABOBKFP(), 463f);
					}
					NLGBGOGCNKP.IDNNIHBIMNO = null;
					NLGBGOGCNKP = enemyPoint;
					NLGBGOGCNKP.IDNNIHBIMNO = this;
					HJFHCPBADLD.enabled = true;
					InvokeAfter(delegate
					{
						HJFHCPBADLD.enabled = true;
					}, 1722f);
					EGFFPINOONI = UnityEngine.Random.Range(2, 4);
					ALBLFGNKNDB = true;
					StartFlying();
					EFFIOHJHFHI.JIFFEODOBBB(fraction);
					PhotonView lAADDLGBFIG3 = LAADDLGBFIG;
					object[] array3 = new object[0];
					array3[0] = false;
					lAADDLGBFIG3.RPC("On Get Arena Leaderboards: CNT =  ", PhotonTargets.All, array3);
					GenerateNextShootTime();
				}
			}
		}
		if (HJFHCPBADLD.curentPathIndex == 0 && !NJMMMLKFPAB)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
			Vector3 forward = enemyOf.transform.position - NGCDDPCAGJB.position;
			forward.y = 1865f;
			HJFHCPBADLD.KAIFFKDJCAG(Quaternion.LookRotation(forward));
			if (PDDOJAMAOHB > HJEJNIJPFHF && (NGCDDPCAGJB.position.PlanarDistance(HJFHCPBADLD.OPFIGHPNDGK) > 564f || HJFHCPBADLD.stayTime < HJFHCPBADLD.HHMJJEIBCNB().KBJEOEEOEFG * 1221f))
			{
				KGDPPCIEJEI(JNPBHFODMKI: true, ILEOEIMBILP: true, 506f);
			}
		}
	}

	private void FGGDLJOGHIO()
	{
		SwitchState(NLGBGOGCNKP.MJGBKHOFNHK);
	}

	public void ImproveAllWeapons(float NEEBBLOFHEF)
	{
		soldierBehaviour.ImproveAllWeapons(NEEBBLOFHEF);
		LAADDLGBFIG.RPC("ImproveAllWeaponsRPC", PhotonTargets.Others, NEEBBLOFHEF);
	}

	[PunRPC]
	private void BuildMortar()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("BuildMortar", PhotonTargets.Others);
		}
		if (soldierBehaviour.KHKAAGCIJPO != null)
		{
			mSoldierAnimationController.ForceInScreen();
			mSoldierAnimationController.BuildMortar();
		}
	}

	public void SwitchState(AJGFGCHCAPA IGBEGIBGLKK)
	{
		if (base.isAlive)
		{
			IPIKDCMLOID = IGBEGIBGLKK;
			switch (IGBEGIBGLKK)
			{
			case AJGFGCHCAPA.Walk:
				JNBJNGKOJFG();
				break;
			case AJGFGCHCAPA.ObstacleHiding:
				HJFHCPBADLD.Stop();
				Crawl();
				ALBLFGNKNDB = true;
				GenerateNextShootTime();
				DHMGLBICCGC = PDDOJAMAOHB + (float)UnityEngine.Random.Range(10, 20);
				PEPDEICKMON = PDDOJAMAOHB + UnityEngine.Random.Range(2f, 4f);
				break;
			case AJGFGCHCAPA.CornerHiding:
			{
				EnemyPointCorner enemyPointCorner = (EnemyPointCorner)NLGBGOGCNKP;
				HJFHCPBADLD.Stop();
				Idle();
				TweenRotation.Begin(base.gameObject, 0.5f, Quaternion.LookRotation(-enemyPointCorner.PLEBANKIBPP));
				Vector3 position = enemyPointCorner.position;
				position.y = NGCDDPCAGJB.position.y;
				TweenPosition.Begin(base.gameObject, 0.5f, position);
				JNAJGJFOIJD = true;
				GenerateNextShootTime();
				DHMGLBICCGC = PDDOJAMAOHB + (float)UnityEngine.Random.Range(10, 20);
				break;
			}
			case AJGFGCHCAPA.Rusher:
				IKNPFCIDDHM();
				break;
			case AJGFGCHCAPA.RusherSpare:
				NENMFFPDKPM();
				break;
			case AJGFGCHCAPA.Swat:
				HEHBKBIEFNK();
				break;
			case AJGFGCHCAPA.Vehicle:
				PJGLPPCIJFE();
				break;
			case AJGFGCHCAPA.Parachute:
				AJNGGNOFOMK();
				break;
			case AJGFGCHCAPA.Helicopter:
				FBFNDPFNGOJ();
				break;
			case AJGFGCHCAPA.MachineGunPoint:
				SwitchStateToMachineGun();
				break;
			case AJGFGCHCAPA.Minigunner:
				OEGIFDHFMDK();
				break;
			case AJGFGCHCAPA.EngineerTurret:
				EEAIPPGKEDM();
				break;
			case AJGFGCHCAPA.Fly:
				GHLMPMFOLNA();
				break;
			case AJGFGCHCAPA.Gunslinger:
				CLOFKKFKPKB();
				break;
			case AJGFGCHCAPA.Mortar:
				JPAMIAFBNCM();
				break;
			case AJGFGCHCAPA.Warp:
				AGKAKBFNKOC();
				break;
			case AJGFGCHCAPA.Idle:
			case AJGFGCHCAPA.EngineerRepair:
				break;
			}
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		DNIIIIBHIJB = true;
		IAICPGNGCJI = soldierBehaviour.totalPower;
		HJFHCPBADLD.Reset();
		HJFHCPBADLD.Disable();
		EFFIOHJHFHI.SetAllRigidBodiesToKinematic(IDEBKDPMPGM: true);
		PDDOJAMAOHB = Time.time;
		LADBLHGBOKJ.ILOHAHFIOKM();
		StopAllCoroutines();
		SkinnedMeshRenderer componentInChildren = GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null && DNBEAILMLLJ != null)
		{
			componentInChildren.material = DNBEAILMLLJ;
		}
		PAOIHIANLOC.ClearKevlar();
		JPBBAIGNBAP.ClearShield();
	}

	[PunRPC]
	public void ChangeWeightForDestroyablePart(float KMMAKDHKIKH, int DFHAAIFFLOE)
	{
		LAADDLGBFIG.RPC("ChangeWeightForDestroyablePartRPC", PhotonTargets.Others, KMMAKDHKIKH, DFHAAIFFLOE);
		ChangeWeightForDestroyablePartRPC(KMMAKDHKIKH, DFHAAIFFLOE);
	}

	private EnemyPointRusher HOPDNNKAEOK()
	{
		EnemyPointRusher enemyPointRusher = NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = FHILAMGAHKK().JGAIPICHEDP;
			List<EnemyPointRusher> jGAIPICHEDP2 = enemyPointRusher.playerPoint.JGAIPICHEDP;
			int index = 0;
			float num = float.MaxValue;
			foreach (List<int> item in MEJMLNDFDBP.IHCOEBKJKLB)
			{
				foreach (EnemyPointRusher item2 in jGAIPICHEDP2)
				{
					EnemyPointRusher enemyPointRusher2 = jGAIPICHEDP[item[item2.DFHAAIFFLOE]];
					if (!item2.isFree && enemyPointRusher2.isFreeWithNearNeighbour(item2))
					{
						float num2 = Vector3.Distance(item2.position, enemyPointRusher2.position);
						if (enemyPointRusher2.DFHAAIFFLOE < 2)
						{
							num2 -= 1.7f;
						}
						if (num2 < num && jGAIPICHEDP[item[enemyPointRusher.DFHAAIFFLOE]].isFreeWithNearNeighbour(enemyPointRusher))
						{
							index = item[enemyPointRusher.DFHAAIFFLOE];
							num = num2;
						}
					}
				}
			}
			return jGAIPICHEDP[index];
		}
		return null;
	}

	private void JKGMOBMIDLF()
	{
		if (NBMPLHLIHOD)
		{
			return;
		}
		if (LPPGFDGBLNP > 0)
		{
			if (PDDOJAMAOHB > HJEJNIJPFHF)
			{
				LPPGFDGBLNP--;
				KGDPPCIEJEI(JNPBHFODMKI: true, ILEOEIMBILP: false);
			}
		}
		else if (PDDOJAMAOHB > PEPDEICKMON)
		{
			EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP);
			if (newEnemyPoint != null && newEnemyPoint != NLGBGOGCNKP)
			{
				NLGBGOGCNKP.IDNNIHBIMNO = null;
				SetFinalTarget(newEnemyPoint);
				ALBLFGNKNDB = false;
				SwitchState(AJGFGCHCAPA.Walk);
			}
		}
	}

	public void GenerateNextShootTime()
	{
		HJEJNIJPFHF = PDDOJAMAOHB + soldierBehaviour.GetNextShotTime();
	}

	private void AHOKMPLFOCO()
	{
		try
		{
			if (KACEPCMMJHN == OLHLGDLDGPP.Spawning)
			{
				FOIFLGLALIN = Mathf.Clamp01(FOIFLGLALIN + Time.deltaTime);
				if (BGDGEJDKJOP != null && BGDGEJDKJOP.Count == 0)
				{
					PIPCBHNNJHJ(null);
					KACEPCMMJHN = OLHLGDLDGPP.Spawned;
				}
				Vector3 fHMNGFGNFLL = base.transform.position.ReplaceY(Mathf.Lerp(PICFNOPKGGL, OEHBBHIICCI, FOIFLGLALIN));
				NGCDDPCAGJB.position = OLBAJGMGEGM(fHMNGFGNFLL);
				NGCDDPCAGJB.rotation = Quaternion.LookRotation(KMCIJJHJJLG.HCCENNJFGMA.NGCDDPCAGJB.right);
				if (FOIFLGLALIN >= 1f)
				{
					PIPCBHNNJHJ(null);
					KACEPCMMJHN = OLHLGDLDGPP.Spawned;
				}
			}
			if (KACEPCMMJHN == OLHLGDLDGPP.Driving && NLGBGOGCNKP != null)
			{
				NGCDDPCAGJB.position = NLGBGOGCNKP.transform.position;
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	[PunRPC]
	public void ShowEngineerBuildingIndicator(bool NABOFKMBMKH, byte PAOKFBHDCFO)
	{
		KJMFJFCDEDH.Show("game-engi-progress-fill", NABOFKMBMKH, HudObjectIndicator.NPPEJJKFCON.EngineerIco, ((GHPGNELIDBM)PAOKFBHDCFO != PlayerController.OGMBJPKOPCB.fraction) ? Colours.redProgress : Colours.blue);
	}

	[PunRPC]
	public void WeaponIgnoreLayer(int BLALNAALHDM)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("WeaponIgnoreLayer", PhotonTargets.Others, BLALNAALHDM);
		}
		if (soldierBehaviour.KHKAAGCIJPO != null)
		{
			soldierBehaviour.KHKAAGCIJPO.BLOHNLJOPIM = ((BLALNAALHDM >= 0) ? (1 << BLALNAALHDM) : 0);
		}
	}

	private void KDFDOHKHIPJ(UITweener MGDJMGHCAAI)
	{
		if (!base.isAlive)
		{
			return;
		}
		EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP);
		if (newEnemyPoint != null)
		{
			SetFinalTarget(newEnemyPoint);
			ShadowSetActive(IDEBKDPMPGM: true);
			SwitchState(AJGFGCHCAPA.Idle);
			return;
		}
		InvokeAfter(delegate
		{
			GDLEFNAGBLC();
		}, 306f);
		Walk();
		spawnPoint = soldierBehaviour.PickNormalSPawn(Singleton<MapManager>.instance.ALCHJDPKAID.DMCDJGLDICM.LIAEIIFPONK);
		HJFHCPBADLD.CAGPIECMNFF(spawnPoint.transform.position);
		HJFHCPBADLD.HDAGCEFHEBN();
		HJFHCPBADLD.stoppingDistance = 1884f;
	}

	private void BEBFKOFFACA()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("SyncWarperRPC", PhotonTargets.Others, base.transform.position, base.transform.rotation);
		}
	}

	[PunRPC]
	private void ShootFromBazookaFromCover(bool DNDCODMGGEE)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ShootFromBazookaFromCover", PhotonTargets.Others, DNDCODMGGEE);
		}
		mSoldierAnimationController.ShootFromBazoka(DNDCODMGGEE, DLMKHPAJKDJ: false);
	}

	[PunRPC]
	public void SittingIdle()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("SittingIdle", PhotonTargets.Others);
		}
		mSoldierAnimationController.SittingIdle();
	}

	public override void DestroyPooled()
	{
		try
		{
			mSoldierAnimationController.Disable();
			NLGBGOGCNKP = null;
			DIPLDDHLMME = true;
			if (soldierBehaviour != null)
			{
				soldierBehaviour.DestroyBehaviour();
			}
			GGDGAHPEDCC = null;
			BGDGEJDKJOP = null;
			base.DestroyPooled();
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	[PunRPC]
	private void StartFlying()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("StartFlying", PhotonTargets.Others);
		}
		mSoldierAnimationController.StartFlying();
	}

	private void HBFFCJIADLI()
	{
		NGCDDPCAGJB.position = NLGBGOGCNKP.transform.position;
		NGCDDPCAGJB.rotation = NLGBGOGCNKP.transform.rotation;
	}

	private void NFBHNDIMNLD(bool NCMHGPNPEJM)
	{
		KJMFJFCDEDH.Show("game-ico-speed", NCMHGPNPEJM, HudObjectIndicator.NPPEJJKFCON.InfoIco);
	}

	[SpecialName]
	public bool IFCAIEPFEAP()
	{
		return MFHLBKPFMOK;
	}

	private void FHEMDCFGMMF(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (!base.isAlive)
		{
			return;
		}
		if (BOFNGHCJPFM != null)
		{
			BOFNGHCJPFM.scaleF = 1f;
		}
		Freeze(ALLIHOCMHBL: false);
		AnalyticsHelper.LeaveBreadcrumb("OnDeath Freeze enemy");
		try
		{
			KJMFJFCDEDH.RemoveAllIconExceptDeathIco();
			DNCNFMPNOBA = PDDOJAMAOHB + 0.2f;
			soldierBehaviour.OnDeath(OHJPPHFEAFI);
			if (OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Explosion && !PFKPCFCEDME)
			{
				PFKPCFCEDME = true;
				EFFIOHJHFHI.MakeTrigger(IDEBKDPMPGM: false);
				mSoldierAnimationController.SampleDead();
				if (IPIKDCMLOID == AJGFGCHCAPA.ObstacleHiding && ALBLFGNKNDB)
				{
					mSoldierAnimationController.SampleStand();
				}
				else
				{
					mSoldierAnimationController.Stop();
				}
				GetComponentInChildren<Animation>().enabled = false;
				EFFIOHJHFHI.EnableRagdol(FKDENIBEGNE: false);
				Vector3 vector = new Vector3(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f), 0f);
				EFFIOHJHFHI.CGCKDIBIFFI.GetComponent<Rigidbody>().AddForce(OHJPPHFEAFI.LPGMLOCLBGP, ForceMode.VelocityChange);
				EFFIOHJHFHI.CGCKDIBIFFI.GetComponent<Rigidbody>().AddTorque(vector.x, vector.y, vector.z);
				EFFIOHJHFHI.OKOKOGCBCCF.OJGHLMLKGAN.GetComponent<Rigidbody>().AddForce(Vector3.up * UnityEngine.Random.Range(5f, 15f), ForceMode.VelocityChange);
				EFFIOHJHFHI.OKOKOGCBCCF.OJGHLMLKGAN.GetComponent<Rigidbody>().AddTorque(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f), 0f);
			}
			else
			{
				JCKHCELHDBH = OHJPPHFEAFI.MEFOHLAIBFA == 1 && OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Shot;
				PlayShotRagdoll(OHJPPHFEAFI);
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
		AnalyticsHelper.LeaveBreadcrumb("OnDeath On Killed");
		DPFHODDILIF(OHJPPHFEAFI);
		HJFHCPBADLD.Disable();
		mSoldierAnimationController.Stop();
		ILPLGCOCODB = false;
		HJFHCPBADLD.enabled = false;
		InvokeAfter(PPFONPMPOHD, UnityEngine.Random.Range(2f, 3f));
		ClearEnemyPoint();
		if (GGDGAHPEDCC != null)
		{
			GGDGAHPEDCC.HDJLFLAAFHH = null;
			GGDGAHPEDCC = null;
		}
		AnalyticsHelper.LeaveBreadcrumb("OnDeath End");
	}

	private void OEGIFDHFMDK()
	{
		if (ILPLGCOCODB)
		{
			UnityEngine.Debug.LogError("Switching to minigunner when shooting !!!");
			ILPLGCOCODB = false;
			NBMPLHLIHOD = false;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
		HJFHCPBADLD.Stop();
		Vector3 forward = enemyOf.transform.position - NGCDDPCAGJB.position;
		forward.y = 0f;
		TweenRotation.Begin(base.gameObject, 0.5f, Quaternion.LookRotation(forward)).ignoreTimeScale = false;
		Idle();
		DHMGLBICCGC = PDDOJAMAOHB + UnityEngine.Random.Range(6f, 10f);
		HJEJNIJPFHF = PDDOJAMAOHB + UnityEngine.Random.Range(2f, 4.5f);
	}

	public void Wait(float KBJEOEEOEFG)
	{
		if (IPIKDCMLOID == AJGFGCHCAPA.Walk)
		{
			HJFHCPBADLD.Pause();
			Idle();
		}
		if (IPIKDCMLOID == AJGFGCHCAPA.Warp && HJFHCPBADLD.speed < 2f)
		{
			HJFHCPBADLD.Pause();
			Idle();
		}
	}

	[PunRPC]
	private void Walk()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("Walk", PhotonTargets.Others);
		}
		if (soldierBehaviour.KHKAAGCIJPO != null)
		{
			mSoldierAnimationController.Walk(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
		}
	}

	public void SetUpKevlar(float DMKIKOALNHO = 0.2f)
	{
		PAOIHIANLOC.DOPFEMONAFI = DMKIKOALNHO;
		PAOIHIANLOC.SetUpKevlar((!JPBBAIGNBAP.IsActive()) ? 1 : 2);
	}

	[PunRPC]
	private void ShootFromShield()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ShootFromShield", PhotonTargets.Others);
		}
		mSoldierAnimationController.ShootFromSwatShield(5f, 1f);
	}

	public void SetMaxHealthAndRefill(float NKKIGGNCDLL)
	{
		OJIHGNJFPFM.maxHealth = NKKIGGNCDLL;
		OJIHGNJFPFM.Refill();
	}

	[CompilerGenerated]
	private void BBNGEDEPNAE()
	{
		HJFHCPBADLD.enabled = true;
	}

	[PunRPC]
	private void ThrowGrenadeFromCrawl()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ThrowGrenadeFromCrawl", PhotonTargets.Others);
		}
		mSoldierAnimationController.ThrowGrenadeFromCrawl();
	}

	public void FIFJEKMIIPO(AJGFGCHCAPA MJGBKHOFNHK)
	{
		KPOGMFIOGMD = true;
		IPIKDCMLOID = MJGBKHOFNHK;
		base.StartEnemyBehaviour();
		if (!KPOGMFIOGMD)
		{
			switch (MJGBKHOFNHK)
			{
			case AJGFGCHCAPA.Swat:
				SwitchState(AJGFGCHCAPA.CornerHiding);
				ShadowSetActive(IDEBKDPMPGM: false);
				break;
			case AJGFGCHCAPA.Parachute:
				SwitchState(AJGFGCHCAPA.Walk);
				ShadowSetActive(IDEBKDPMPGM: false);
				break;
			case AJGFGCHCAPA.Helicopter:
				StopAllCoroutines();
				SwitchState(AJGFGCHCAPA.Idle);
				ShadowSetActive(IDEBKDPMPGM: true);
				break;
			case (AJGFGCHCAPA)(-99):
				StopAllCoroutines();
				SwitchState((AJGFGCHCAPA)(-67));
				ShadowSetActive(IDEBKDPMPGM: false);
				break;
			case (AJGFGCHCAPA)(-73):
				StopAllCoroutines();
				SwitchState((AJGFGCHCAPA)(-39));
				break;
			default:
				Walk();
				GDLEFNAGBLC();
				break;
			}
		}
	}

	[PunRPC]
	private void ShootStand()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ShootStand", PhotonTargets.Others);
		}
		mSoldierAnimationController.ShootStand(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
	}

	[SpecialName]
	public bool KMPAPJDAPFK()
	{
		return MFHLBKPFMOK;
	}

	[PunRPC]
	private void ShootStandNew(float GINCPOHPFBN)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ShootStandNew", PhotonTargets.Others, GINCPOHPFBN);
		}
		if (soldierBehaviour.KHKAAGCIJPO != null)
		{
			mSoldierAnimationController.ShootStandNew(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG, 1f, GINCPOHPFBN);
		}
	}

	private void NPABPDOFCOM()
	{
		EnemyPoint initPoint = soldierBehaviour.GetInitPoint();
		if (initPoint != null)
		{
			SetFinalTarget(initPoint);
			ShadowSetActive(IDEBKDPMPGM: true);
			SwitchState(AJGFGCHCAPA.Walk);
		}
		else
		{
			InvokeAfter(delegate
			{
				GDLEFNAGBLC();
			}, 5f);
			Walk();
			spawnPoint = soldierBehaviour.PickNormalSPawn(Singleton<MapManager>.instance.ALCHJDPKAID.DMCDJGLDICM.LIAEIIFPONK);
			HJFHCPBADLD.SetDestination(spawnPoint.transform.position);
			HJFHCPBADLD.Resume();
			HJFHCPBADLD.stoppingDistance = 0f;
		}
		MLFKPOMJMOP = true;
		GGDGAHPEDCC.HDJLFLAAFHH = null;
		GGDGAHPEDCC = null;
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		OJIHGNJFPFM.maxHealth = soldierBehaviour.soldierBehaviourDefinititon.health;
		OJIHGNJFPFM.ResetWeights();
		OJIHGNJFPFM.RefillOffline();
		HJFHCPBADLD.speed = soldierBehaviour.soldierBehaviourDefinititon.speed;
		soldierBehaviour.UpdateVisual();
	}

	private void NENMFFPDKPM()
	{
		KOKLMCHFKJC = false;
		WeaponIgnoreLayer(TagsAndLayers.JNCLCGHJAOO);
		FBIKDDGEENF = 0f;
		EnemyPointRusherSpare enemyPointRusherSpare = (EnemyPointRusherSpare)NLGBGOGCNKP;
		HJFHCPBADLD.Stop();
		Idle();
		Vector3 position = enemyPointRusherSpare.position;
		position.y = NGCDDPCAGJB.position.y;
		TweenPosition.Begin(base.gameObject, 0.5f, position);
		Vector3 direction = enemyPointRusherSpare.direction;
		direction.y = 0f;
		TweenRotation.Begin(base.gameObject, 0.3f, Quaternion.LookRotation(direction)).ignoreTimeScale = false;
		JNAJGJFOIJD = true;
		HJEJNIJPFHF = PDDOJAMAOHB + 0.5f;
	}

	public virtual void KEOCEEHJKCG()
	{
		base.UpgradesLoaded();
		OJIHGNJFPFM.maxHealth = soldierBehaviour.soldierBehaviourDefinititon.health;
		OJIHGNJFPFM.MPADEMMDEEA();
		OJIHGNJFPFM.RefillOffline();
		HJFHCPBADLD.speed = soldierBehaviour.soldierBehaviourDefinititon.speed;
		soldierBehaviour.UpdateVisual();
	}

	public void StartStandShoot()
	{
		if (KGDPPCIEJEI(JNPBHFODMKI: true, ILEOEIMBILP: true))
		{
			HJFHCPBADLD.Stop();
		}
		else
		{
			GenerateNextShootTime();
		}
	}

	private void PJGLPPCIJFE()
	{
		ShadowSetActive(IDEBKDPMPGM: false);
		HJFHCPBADLD.Stop();
		Idle();
		OJIHGNJFPFM.SetText(string.Empty);
		EFFIOHJHFHI.MakeTrigger(IDEBKDPMPGM: true);
		NGCDDPCAGJB.position = NLGBGOGCNKP.transform.position;
		if (soldierBehaviour.KHKAAGCIJPO != null)
		{
			soldierBehaviour.KHKAAGCIJPO.gameObject.SetActive(value: false);
		}
		soldierBehaviour.UseTurret(null);
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (!LFPCMNHOPOP)
		{
			if (CLNMMEMKKGO.isWriting)
			{
				CLNMMEMKKGO.Serialize(ref FMFKLFMGFAO);
				CLNMMEMKKGO.Serialize(ref MFHLBKPFMOK);
				CLNMMEMKKGO.SendNext((byte)IPIKDCMLOID);
				LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			}
			else
			{
				CLNMMEMKKGO.Serialize(ref FMFKLFMGFAO);
				CLNMMEMKKGO.Serialize(ref MFHLBKPFMOK);
				NKJEECFDGGN((AJGFGCHCAPA)(byte)CLNMMEMKKGO.ReceiveNext());
				LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			}
		}
	}

	[PunRPC]
	private void Repair()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("Repair", PhotonTargets.Others);
		}
		mSoldierAnimationController.Repair();
	}

	private void BLAOPGHCGCG()
	{
		if (base.transform.position.PlanarDistance(KKAHNPEGPEJ) < 0.1f && FMFKLFMGFAO)
		{
			FMFKLFMGFAO = false;
			mSoldierAnimationController.Idle(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
		}
	}

	[PunRPC]
	private void RopeSlide()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("RopeSlide", PhotonTargets.Others);
		}
		mSoldierAnimationController.RopeSlide();
	}

	private Vector3 ACAEFIMAAMB()
	{
		Bounds bounds = Singleton<MapManager>.instance.ALCHJDPKAID.CMJBHHBKKAF.bounds;
		bounds.size -= new Vector3(4f, 0f, UnityEngine.Random.Range(2f, 3.5f));
		Vector3 zero = Vector3.zero;
		zero.x = UnityEngine.Random.Range(bounds.min.x, bounds.max.x);
		zero.y = bounds.min.y;
		zero.z = ((!HNIGGHFHHAH) ? bounds.max.z : bounds.min.z);
		HNIGGHFHHAH = !HNIGGHFHHAH;
		if (NavMesh.SamplePosition(zero, out var hit, 5f, 1))
		{
			return hit.position;
		}
		return ACAEFIMAAMB();
	}

	public void SetStateTo(AJGFGCHCAPA MJGBKHOFNHK, EnemyPoint MKIPAEDAADL)
	{
		IPIKDCMLOID = MJGBKHOFNHK;
		if (MJGBKHOFNHK == AJGFGCHCAPA.Walk)
		{
			Walk();
			GDLEFNAGBLC(MKIPAEDAADL);
		}
		KPOGMFIOGMD = true;
	}

	public void PlayShotRagdoll(DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		EFFIOHJHFHI.MakeTrigger(IDEBKDPMPGM: false);
		mSoldierAnimationController.SampleDead();
		GetComponentInChildren<Animation>().enabled = false;
		EFFIOHJHFHI.EnableRagdol(JCKHCELHDBH);
		EFFIOHJHFHI.CGCKDIBIFFI.GetComponent<Rigidbody>().GetComponent<Rigidbody>().AddForce(OHJPPHFEAFI.LPGMLOCLBGP, ForceMode.VelocityChange);
		EFFIOHJHFHI.OKOKOGCBCCF.OJGHLMLKGAN.GetComponent<Rigidbody>().AddForce(Vector3.up * UnityEngine.Random.Range(0.5f, 2f), ForceMode.VelocityChange);
		EFFIOHJHFHI.OKOKOGCBCCF.OJGHLMLKGAN.GetComponent<Rigidbody>().AddTorque(UnityEngine.Random.Range(-100f, 100f), UnityEngine.Random.Range(-100f, 100f), 0f);
		if (JCKHCELHDBH)
		{
			EFFIOHJHFHI.DGHPFMPMAFC.OJGHLMLKGAN.GetComponent<Rigidbody>().AddForce(Vector3.up * UnityEngine.Random.Range(1f, 3f) + OHJPPHFEAFI.LPGMLOCLBGP * 1.5f, ForceMode.VelocityChange);
		}
	}

	[PunRPC]
	public void SnapColt(bool BBAOMJODMDH)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("SnapColt", PhotonTargets.Others, BBAOMJODMDH);
		}
		if (soldierBehaviour.KHKAAGCIJPO != null)
		{
			soldierBehaviour.BMNHHCCBAAN.SnapColt(BBAOMJODMDH);
		}
	}

	private Vector3 LOKJIECGOIB()
	{
		Vector3 destnation = HJFHCPBADLD.destnation;
		Bounds bounds = Singleton<MapManager>.instance.ALCHJDPKAID.CMJBHHBKKAF.bounds;
		bool flag = !HNIGGHFHHAH;
		float num = ((!flag) ? bounds.max.z : bounds.min.z);
		float num2 = (flag ? bounds.max.z : bounds.min.z);
		float num3 = ((!(num2 - num > 0f)) ? (-1f) : 1f);
		destnation.z = num + num3 * UnityEngine.Random.Range(1f, 2.7f);
		Plane plane = new Plane(Vector3.forward, new Vector3(0f, 0f, destnation.z));
		for (int i = 0; i < HJFHCPBADLD.corners.Length - 1; i++)
		{
			Vector3 vector = HJFHCPBADLD.corners[i];
			Vector3 vector2 = HJFHCPBADLD.corners[i + 1];
			float magnitude = (vector2 - vector).magnitude;
			Ray ray = new Ray(vector, vector2 - vector);
			if (plane.Raycast(ray, out var enter) && enter <= magnitude)
			{
				return ray.GetPoint(enter);
			}
		}
		UnityEngine.Debug.Log("Warp - can not find random point - returning agent destination");
		NavMeshHit hit;
		return (!NavMesh.SamplePosition(HJFHCPBADLD.destnation, out hit, 5f, 1)) ? HJFHCPBADLD.destnation : hit.position;
	}

	private void KBHGKGGCOJE()
	{
		SwitchState(NLGBGOGCNKP.MJGBKHOFNHK);
	}

	public virtual void IDEKKBMPNKL()
	{
		try
		{
			mSoldierAnimationController.Disable();
			NLGBGOGCNKP = null;
			DIPLDDHLMME = true;
			if (soldierBehaviour != null)
			{
				soldierBehaviour.DestroyBehaviour();
			}
			GGDGAHPEDCC = null;
			BGDGEJDKJOP = null;
			base.DestroyPooled();
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	[PunRPC]
	private void Idle()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("Idle", PhotonTargets.Others);
		}
		mSoldierAnimationController.Idle((soldierBehaviour.KHKAAGCIJPO != null) ? soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG : Weapon.IGGFMJAKLGO.Riffle);
	}

	public virtual void HELILMIAOKD(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		soldierBehaviour.UpdateVisual();
		if (LCDBACDIODH && soldierBehaviour != null)
		{
			mSoldierAnimationController.ForceInScreen();
			float KBJEOEEOEFG = 72f;
			if (!mSoldierAnimationController.IsIdle(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG, out KBJEOEEOEFG))
			{
				mSoldierAnimationController.SampleIdle(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG, 196f);
			}
			else
			{
				mSoldierAnimationController.SampleIdle(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG, KBJEOEEOEFG);
			}
			mSoldierAnimationController.Idle(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
		}
		EFFIOHJHFHI.OFBEAKDOCIO.gameObject.SetActive(value: false);
	}

	public void LDAKCDAPOGH(AJGFGCHCAPA MJGBKHOFNHK)
	{
		KPOGMFIOGMD = true;
		IPIKDCMLOID = MJGBKHOFNHK;
		base.StartEnemyBehaviour();
		if (!KPOGMFIOGMD)
		{
			switch (MJGBKHOFNHK)
			{
			case AJGFGCHCAPA.Helicopter:
				SwitchState(AJGFGCHCAPA.Swat);
				ShadowSetActive(IDEBKDPMPGM: true);
				break;
			case AJGFGCHCAPA.Vehicle:
				SwitchState(AJGFGCHCAPA.Walk);
				ShadowSetActive(IDEBKDPMPGM: false);
				break;
			case AJGFGCHCAPA.Parachute:
				StopAllCoroutines();
				SwitchState(AJGFGCHCAPA.Rusher);
				ShadowSetActive(IDEBKDPMPGM: true);
				break;
			case (AJGFGCHCAPA)110:
				StopAllCoroutines();
				SwitchState((AJGFGCHCAPA)(-116));
				ShadowSetActive(IDEBKDPMPGM: false);
				break;
			case (AJGFGCHCAPA)58:
				StopAllCoroutines();
				SwitchState((AJGFGCHCAPA)(-42));
				break;
			default:
				Walk();
				GDLEFNAGBLC();
				break;
			}
		}
	}

	private void MINIJBGMLJO()
	{
		if (!NBPAEDNBFGE && NLGBGOGCNKP != null && NLGBGOGCNKP.PMIDEPGMDGE(NGCDDPCAGJB.position) && !NBMPLHLIHOD)
		{
			KBHGKGGCOJE();
		}
		if (KOKLMCHFKJC)
		{
			if (!NBPAEDNBFGE && PDDOJAMAOHB > HJEJNIJPFHF && soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunning && isInField && !soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunningDontStop && !NBMPLHLIHOD && NGCDDPCAGJB.position.PlanarDistance(NLGBGOGCNKP.PFOBADFGAKF()) > 1109f)
			{
				soldierBehaviour.StandShoot();
			}
			if (!NBPAEDNBFGE && PDDOJAMAOHB > HJEJNIJPFHF && isInField && soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunningDontStop && !NBMPLHLIHOD && NLGBGOGCNKP != null && NGCDDPCAGJB.position.PlanarDistance(NLGBGOGCNKP.position) > 1010f)
			{
				NIHCAFPBOPJ();
			}
		}
		if (!(NLGBGOGCNKP != null))
		{
			return;
		}
		if (Vector3.Distance(NLGBGOGCNKP.FGKJILDKPHC(), HJFHCPBADLD.destnation) > 1589f && !NBMPLHLIHOD && !HJFHCPBADLD.MDDKNJJBCGI())
		{
			FBIKDDGEENF += Time.deltaTime;
			SetFinalTarget(NLGBGOGCNKP);
			FBIKDDGEENF = 1696f;
		}
		if (NLGBGOGCNKP is EnemyPointRusher)
		{
			if (!NLGBGOGCNKP.ACJOIOALHOE() && !NBMPLHLIHOD && !HJFHCPBADLD.isStopped)
			{
				FBIKDDGEENF += Time.deltaTime;
				if (FBIKDDGEENF > 577f)
				{
					FBIKDDGEENF = 7f;
					EnemyPointRusher mKIPAEDAADL = HOPDNNKAEOK();
					KFCHPKACAAO(mKIPAEDAADL);
				}
			}
			if (NLGBGOGCNKP.LLACCPGCFMI())
			{
				FBIKDDGEENF = 1347f;
			}
		}
		if (!NLGBGOGCNKP.gameObject.activeInHierarchy)
		{
			GDLEFNAGBLC();
		}
	}

	[PunRPC]
	private void Crawl()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("Crawl", PhotonTargets.Others);
		}
		if (soldierBehaviour.KHKAAGCIJPO != null)
		{
			Weapon.IGGFMJAKLGO bEACDIILBEG = soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG;
			if (bEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka)
			{
				mSoldierAnimationController.BazookaCrawl();
			}
			else
			{
				mSoldierAnimationController.Crawl();
			}
		}
	}

	[PunRPC]
	private void Warp()
	{
		SoldierBehaviourWarper soldierBehaviourWarper = soldierBehaviour as SoldierBehaviourWarper;
		soldierBehaviourWarper.ChangeToTransparent();
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("Warp", PhotonTargets.Others);
		}
		mSoldierAnimationController.Warp();
	}

	public void DIENGNHAAOG(AJGFGCHCAPA MJGBKHOFNHK, EnemyPoint MKIPAEDAADL)
	{
		IPIKDCMLOID = MJGBKHOFNHK;
		if (MJGBKHOFNHK == AJGFGCHCAPA.Walk)
		{
			Walk();
			GDLEFNAGBLC(MKIPAEDAADL);
		}
		KPOGMFIOGMD = false;
	}

	public override void StartEnemyBehaviour()
	{
		soldierBehaviour.StartEnemyBehaviour();
	}

	private void EMHCNBFEGLP()
	{
		if (PDDOJAMAOHB > HJEJNIJPFHF)
		{
			soldierBehaviour.PickTarget();
			soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMin = 1;
			soldierBehaviour.soldierBehaviourDefinititon.fireBatchSizeMax = 1;
			soldierBehaviour.soldierBehaviourDefinititon.probabilityOfRealShot = 0.9f;
			soldierBehaviour.StartShooting();
			MDKABJDCKBI(0.5f);
		}
	}

	private void OEEKJHPAMDH()
	{
		if (NJMMMLKFPAB && isInField)
		{
			NJMMMLKFPAB = false;
			HJFHCPBADLD.Fly(NLGBGOGCNKP.position);
			HJFHCPBADLD.Disable();
			StartFlying();
			EFFIOHJHFHI.EnableJetPack(fraction);
			LAADDLGBFIG.RPC("PlayeScifiParticles", PhotonTargets.Others, true);
			GenerateNextShootTime();
		}
		if (Vector3.Distance(NGCDDPCAGJB.position, HJFHCPBADLD.OPFIGHPNDGK) < 0.1f)
		{
			if (!ALBLFGNKNDB && HJFHCPBADLD.curentPathIndex > 1)
			{
				Crawl();
				ALBLFGNKNDB = true;
				EFFIOHJHFHI.LessJetPackParticles();
				LAADDLGBFIG.RPC("PlayeScifiParticles", PhotonTargets.Others, false);
				EndShooting();
			}
			NOLOFNKPIDB += Time.deltaTime;
			if (NOLOFNKPIDB >= EGFFPINOONI)
			{
				EnemyPoint enemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP) ?? NLGBGOGCNKP;
				if (enemyPoint != null)
				{
					NOLOFNKPIDB = 0f;
					if (enemyPoint == NLGBGOGCNKP)
					{
						HJFHCPBADLD.Fly(enemyPoint.position, UnityEngine.Random.Range(2f, 4f), base.transform.rotation);
					}
					else
					{
						HJFHCPBADLD.Fly(enemyPoint.position);
					}
					NLGBGOGCNKP.IDNNIHBIMNO = null;
					NLGBGOGCNKP = enemyPoint;
					NLGBGOGCNKP.IDNNIHBIMNO = this;
					HJFHCPBADLD.enabled = false;
					InvokeAfter(delegate
					{
						HJFHCPBADLD.enabled = true;
					}, 0.46f);
					EGFFPINOONI = UnityEngine.Random.Range(2, 3);
					ALBLFGNKNDB = false;
					StartFlying();
					EFFIOHJHFHI.EnableJetPack(fraction);
					LAADDLGBFIG.RPC("PlayeScifiParticles", PhotonTargets.Others, true);
					GenerateNextShootTime();
				}
			}
		}
		if (HJFHCPBADLD.curentPathIndex == 1 && !NJMMMLKFPAB)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
			Vector3 forward = enemyOf.transform.position - NGCDDPCAGJB.position;
			forward.y = 0f;
			HJFHCPBADLD.flyRot = Quaternion.LookRotation(forward);
			if (PDDOJAMAOHB > HJEJNIJPFHF && (NGCDDPCAGJB.position.PlanarDistance(HJFHCPBADLD.OPFIGHPNDGK) > 1f || HJFHCPBADLD.stayTime < HJFHCPBADLD.current.KBJEOEEOEFG * 0.5f))
			{
				KGDPPCIEJEI(JNPBHFODMKI: false, ILEOEIMBILP: false);
			}
		}
	}

	private void JCGIFLFLIJN()
	{
		if (PDDOJAMAOHB > HJEJNIJPFHF)
		{
			KGDPPCIEJEI(JNPBHFODMKI: true, ILEOEIMBILP: false);
		}
	}

	private void FHNJLIDDPAO()
	{
		float num = ((!base.hasSpecial) ? (soldierBehaviour.soldierBehaviourDefinititon.special + 0.2f) : soldierBehaviour.soldierBehaviourDefinititon.special);
		KJMFJFCDEDH.SetProgress("game-engi-progress-fill", 1f - (JPAEIIEPIPC - PDDOJAMAOHB) / num);
		if ((int)TimeManager.realTimeWithoutPauses != JGCLNHNMDMH)
		{
			LAADDLGBFIG.RPC("UpdateEngineerBuildingIndicator", PhotonTargets.Others, 1f - (JPAEIIEPIPC - PDDOJAMAOHB) / num);
			JGCLNHNMDMH = (int)TimeManager.realTimeWithoutPauses;
		}
		if (PDDOJAMAOHB > JPAEIIEPIPC && JPAEIIEPIPC != 0f)
		{
			JPAEIIEPIPC = 0f;
			KJMFJFCDEDH.Show("game-engi-progress-fill", IDEBKDPMPGM: false, HudObjectIndicator.NPPEJJKFCON.EngineerIco);
			LAADDLGBFIG.RPC("ShowEngineerBuildingIndicator", PhotonTargets.Others, false, (byte)fraction);
			EnemyPointEngineerTurret enemyPointEngineerTurret = NLGBGOGCNKP as EnemyPointEngineerTurret;
			Turret turret = (Turret)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<ObjectPoolDatabase>.instance.KAEAMDOJMIF.IAJJBAJOGDM);
			SpawningManager.instance.Spawn(turret, fraction, EEAMBOACAGF: false, enemyPointEngineerTurret.turretPosition);
			enemyPointEngineerTurret.SetTurret(turret);
			int turretUpgradeLevel = ((SoldierBehaviourDefinititonEngineer)soldierBehaviour.soldierBehaviourDefinititon).turretUpgradeLevel;
			turret.LoadUpgrades(turretUpgradeLevel, PFGLIAHPMCK.scaleDamage, PFGLIAHPMCK.scaleHp);
			EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP);
			if (newEnemyPoint != null && newEnemyPoint != NLGBGOGCNKP)
			{
				NLGBGOGCNKP.IDNNIHBIMNO = null;
				SetFinalTarget(newEnemyPoint);
				SwitchState(AJGFGCHCAPA.Walk);
			}
			else
			{
				Walk();
				HJFHCPBADLD.SetDestination(spawnPoint.transform.position);
				HJFHCPBADLD.Resume();
				HJFHCPBADLD.stoppingDistance = 0f;
				MJFJEKPHKJA = true;
				EIFMONFPJGA = PDDOJAMAOHB;
			}
		}
		if (MJFJEKPHKJA && PDDOJAMAOHB > EIFMONFPJGA + 1f)
		{
			EIFMONFPJGA = PDDOJAMAOHB;
			EnemyPoint enemyPoint = soldierBehaviour.GetNewEnemyPoint(null);
			EnemyPointEngineerTurret enemyPointEngineerTurret2 = (EnemyPointEngineerTurret)NLGBGOGCNKP;
			if (enemyPointEngineerTurret2.turret == null)
			{
				enemyPoint = enemyPointEngineerTurret2;
			}
			if (enemyPoint != null)
			{
				MJFJEKPHKJA = false;
				NLGBGOGCNKP.IDNNIHBIMNO = null;
				SetFinalTarget(enemyPoint);
				SwitchState(AJGFGCHCAPA.Walk);
			}
		}
	}

	[SpecialName]
	public virtual DestroyableObject IOEHFOCEFME()
	{
		return OJIHGNJFPFM;
	}

	private void LGDBMAGMAAN()
	{
		if (ALBLFGNKNDB && PDDOJAMAOHB > HJEJNIJPFHF)
		{
			KGDPPCIEJEI(JNPBHFODMKI: true, ILEOEIMBILP: false);
			ALBLFGNKNDB = false;
			PEPDEICKMON = PDDOJAMAOHB + UnityEngine.Random.Range(2f, 3f);
		}
		else if (PDDOJAMAOHB > PEPDEICKMON && !NBMPLHLIHOD)
		{
			PEPDEICKMON = PDDOJAMAOHB + UnityEngine.Random.Range(2f, 6f);
			SetFinalTarget(NLGBGOGCNKP);
		}
		else if (ALBLFGNKNDB && PDDOJAMAOHB > DHMGLBICCGC && !NBMPLHLIHOD && GBBFIPKBJGG)
		{
			EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP);
			if (newEnemyPoint != null && newEnemyPoint != NLGBGOGCNKP)
			{
				NLGBGOGCNKP.IDNNIHBIMNO = null;
				SetFinalTarget(newEnemyPoint);
				ALBLFGNKNDB = false;
				SwitchState(AJGFGCHCAPA.Walk);
			}
			else
			{
				DHMGLBICCGC += 10f;
			}
		}
	}

	private void PPFONPMPOHD()
	{
		KJMFJFCDEDH.Disable();
		EFFIOHJHFHI.SetAllRigidBodiesToKinematic(IDEBKDPMPGM: true);
		TweenPosition.Begin(base.gameObject, 1f, base.transform.position, base.transform.position - Vector3.up, useLocal: false);
		CDCOFHGPJHN(1f);
	}

	[PunRPC]
	private void FireMortar()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("FireMortar", PhotonTargets.Others);
		}
		if (soldierBehaviour.KHKAAGCIJPO != null)
		{
			mSoldierAnimationController.FiredMortar();
		}
		soldierBehaviour.BMNHHCCBAAN.SnapWeaponToWorld();
		InvokeAfter(delegate
		{
			soldierBehaviour.BMNHHCCBAAN.SnapToHand();
		}, mSoldierAnimationController.mortarShotTime);
		PEPDEICKMON = PDDOJAMAOHB + mSoldierAnimationController.mortarShotTime + mSoldierAnimationController.mortarStandTime;
	}

	[CompilerGenerated]
	private void HPDOKJAILJF()
	{
		SnapColt(BBAOMJODMDH: true);
	}

	[PunRPC]
	public void UpdateEngineerBuildingIndicator(float PAENPHMEMGC)
	{
		KJMFJFCDEDH.SetProgress("game-engi-progress-fill", PAENPHMEMGC);
	}

	[PunRPC]
	private void ShootFromCover(bool DNDCODMGGEE, float GINCPOHPFBN)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ShootFromCover", PhotonTargets.Others, DNDCODMGGEE, GINCPOHPFBN);
		}
		else
		{
			KAKIEBINCDL = !DNDCODMGGEE;
		}
		if (soldierBehaviour.KHKAAGCIJPO != null)
		{
			mSoldierAnimationController.ShotFromCover(DNDCODMGGEE, 1f, GINCPOHPFBN, DLMKHPAJKDJ: false, soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
		}
	}

	public void FreezByCard(bool ALLIHOCMHBL)
	{
		Freeze(ALLIHOCMHBL);
		LAADDLGBFIG.RPC("FreezeRPC", PhotonTargets.Others, ALLIHOCMHBL);
	}

	public void SetFinalTarget(EnemyPoint MKIPAEDAADL)
	{
		if (!(MKIPAEDAADL == null))
		{
			if (NLGBGOGCNKP != null)
			{
				NLGBGOGCNKP.IDNNIHBIMNO = null;
			}
			NLGBGOGCNKP = MKIPAEDAADL;
			if (NLGBGOGCNKP.IDNNIHBIMNO != null && NLGBGOGCNKP.IDNNIHBIMNO != this)
			{
				UnityEngine.Debug.LogError("enemy point is not free");
			}
			NLGBGOGCNKP.IDNNIHBIMNO = this;
			MKIPAEDAADL.GeneratePosition();
			HJFHCPBADLD.SetDestination(NLGBGOGCNKP.position);
			HJFHCPBADLD.Resume();
			HJFHCPBADLD.stoppingDistance = 0f;
		}
	}

	public void WarpAgain()
	{
		IPIKDCMLOID = AJGFGCHCAPA.Warp;
		HNIGGHFHHAH = UnityEngine.Random.value > 0.5f;
		IECKPDOFCFC = UnityEngine.Random.Range(0, 2);
		PEPDEICKMON = float.MaxValue;
		KDDEPAFBNLH = PDDOJAMAOHB - 1.3f;
		HJFHCPBADLD.speed = 0f;
		HJFHCPBADLD.SetDestination(ACAEFIMAAMB());
		ALBLFGNKNDB = true;
	}

	[SpecialName]
	public void MHFBPJKLCLJ(PlayerVisualCategoryCamos.PlayerVisualCamo IDEBKDPMPGM)
	{
		EBEPNOMNPPL.FMAICIOEBPG(IDEBKDPMPGM);
	}

	public void KFCHPKACAAO(EnemyPoint MKIPAEDAADL)
	{
		if (!(MKIPAEDAADL == null))
		{
			if (NLGBGOGCNKP != null)
			{
				NLGBGOGCNKP.IDNNIHBIMNO = null;
			}
			NLGBGOGCNKP = MKIPAEDAADL;
			if (NLGBGOGCNKP.IDNNIHBIMNO != null && NLGBGOGCNKP.IDNNIHBIMNO != this)
			{
				UnityEngine.Debug.LogError("Has Gc Name!");
			}
			NLGBGOGCNKP.IDNNIHBIMNO = this;
			MKIPAEDAADL.LBOKMMJILDB();
			HJFHCPBADLD.SetDestination(NLGBGOGCNKP.KPOEEKLFALL());
			HJFHCPBADLD.Resume();
			HJFHCPBADLD.stoppingDistance = 1336f;
		}
	}

	private void NKOLONGLNFH()
	{
		GDLEFNAGBLC();
	}

	[PunRPC]
	private void ShadowSetActive(bool IDEBKDPMPGM)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ShadowSetActive", PhotonTargets.Others, IDEBKDPMPGM);
		}
		EFFIOHJHFHI.ShadowSetActive(IDEBKDPMPGM);
	}

	public void Resume()
	{
		UnityEngine.Debug.Log("==ENEMY RESUME==");
		if (IPIKDCMLOID == AJGFGCHCAPA.Walk)
		{
			Walk();
			HJFHCPBADLD.Resume();
		}
		if (IPIKDCMLOID == AJGFGCHCAPA.Warp && HJFHCPBADLD.speed < 2f)
		{
			HJFHCPBADLD.Resume();
			Walk();
		}
	}

	private EnemyPointRusher NGBPHNIDHGK()
	{
		EnemyPointRusher enemyPointRusher = NLGBGOGCNKP as EnemyPointRusher;
		if (enemyPointRusher != null)
		{
			List<EnemyPointRusher> jGAIPICHEDP = FHILAMGAHKK().JGAIPICHEDP;
			List<EnemyPointRusher> jGAIPICHEDP2 = enemyPointRusher.DKFHIPIJJJG().JGAIPICHEDP;
			int index = 0;
			float num = 1136f;
			foreach (List<int> item in MEJMLNDFDBP.IHCOEBKJKLB)
			{
				foreach (EnemyPointRusher item2 in jGAIPICHEDP2)
				{
					EnemyPointRusher enemyPointRusher2 = jGAIPICHEDP[item[item2.DFHAAIFFLOE]];
					if (!item2.JCOPEJOIIIH() && enemyPointRusher2.KPEBANNLELH(item2))
					{
						float num2 = Vector3.Distance(item2.MOOGMFPMKEM(), enemyPointRusher2.KPOEEKLFALL());
						if (enemyPointRusher2.DFHAAIFFLOE < 3)
						{
							num2 -= 532f;
						}
						if (num2 < num && jGAIPICHEDP[item[enemyPointRusher.DFHAAIFFLOE]].AGEOILBEFNN(enemyPointRusher))
						{
							index = item[enemyPointRusher.DFHAAIFFLOE];
							num = num2;
						}
					}
				}
			}
			return jGAIPICHEDP[index];
		}
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		OJIHGNJFPFM.OnDeath += FHEMDCFGMMF;
		OJIHGNJFPFM.OnDamage += EKDKBACABCK;
		NGCDDPCAGJB = base.transform;
		fraction = GHPGNELIDBM.None;
		GameShootableEntity component = GetComponent<GameShootableEntity>();
	}

	private void AFCPGEOLGJB()
	{
		soldierBehaviour.BMNHHCCBAAN.IGPBOJGBHCO();
	}

	private void JNBJNGKOJFG()
	{
		Walk();
		WeaponIgnoreLayer(-1);
		GenerateNextShootTime();
	}

	public virtual void NFJDLOHDEHJ()
	{
		base.Spawn();
		if (LAADDLGBFIG.isMine && DIPLDDHLMME)
		{
			try
			{
				spawnPoint = soldierBehaviour.PickSpawnPoint(Singleton<MapManager>.instance.ALCHJDPKAID.DMCDJGLDICM.LIAEIIFPONK);
				NGCDDPCAGJB.position = spawnPoint.transform.position;
				TweenPosition.Begin(base.gameObject, 159f, NGCDDPCAGJB.position);
			}
			catch (Exception exception)
			{
				AnalyticsHelper.LogHandledException(exception);
			}
		}
	}

	[PunRPC]
	private void SoldierBehaviourStartShootingNetwork(Vector3 MPHCNMDIPAI, int OAPOAHJLKIP, bool CAKABHIPCDF, byte EBNMDKAEJAH, byte COAEOPHBCOE)
	{
		if (soldierBehaviour != null)
		{
			soldierBehaviour.StartShootingNetworkRPC(MPHCNMDIPAI, OAPOAHJLKIP, CAKABHIPCDF, EBNMDKAEJAH, COAEOPHBCOE);
		}
	}

	private void IGHMLPJDMBE()
	{
		if (PDDOJAMAOHB > HJEJNIJPFHF && !NBMPLHLIHOD)
		{
			KGDPPCIEJEI(JNPBHFODMKI: true, ILEOEIMBILP: false);
		}
		FBIKDDGEENF += Time.deltaTime;
		if (!(FBIKDDGEENF > 0.5f) || NBMPLHLIHOD)
		{
			return;
		}
		FBIKDDGEENF = 0f;
		if (rusherCounts < 4)
		{
			EnemyPoint initPoint = soldierBehaviour.GetInitPoint();
			if (initPoint is EnemyPointRusher)
			{
				SetFinalTarget(initPoint);
				SwitchState(AJGFGCHCAPA.Walk);
			}
		}
	}

	private void ABBEMMJPAKA(Vector3 MPHCNMDIPAI, int OAPOAHJLKIP, bool CAKABHIPCDF, byte EBNMDKAEJAH, byte COAEOPHBCOE)
	{
		if (soldierBehaviour != null)
		{
			soldierBehaviour.StartShootingNetworkRPC(MPHCNMDIPAI, OAPOAHJLKIP, CAKABHIPCDF, EBNMDKAEJAH, COAEOPHBCOE);
		}
	}

	private void AJNGGNOFOMK()
	{
		MLFKPOMJMOP = false;
		HJFHCPBADLD.Stop();
		SpawnPointParachute spawnPointParachute = spawnPoint as SpawnPointParachute;
		GGDGAHPEDCC = ObjectPoolDatabase.networkPool.InstantiateNetwork(Singleton<ObjectPoolDatabase>.instance.NGABCDPNGBJ, spawnPoint.transform.position, spawnPoint.transform.rotation) as Parachute;
		if (GGDGAHPEDCC != null)
		{
			Parachute gGDGAHPEDCC = GGDGAHPEDCC;
			gGDGAHPEDCC.HDJLFLAAFHH = (Action)Delegate.Combine(gGDGAHPEDCC.HDJLFLAAFHH, new Action(NPABPDOFCOM));
			GGDGAHPEDCC.BONADMIGCOJ = spawnPoint.transform.forward;
		}
		Idle();
	}

	[PunRPC]
	private void ShootFromBazookaFromCrawl()
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ShootFromBazookaFromCrawl", PhotonTargets.Others);
		}
		mSoldierAnimationController.ShootFromBazokaCrawl();
	}

	[PunRPC]
	private void SetCanDie(bool OCJFJNHJKMJ)
	{
		JEPEEJIMFOE = OCJFJNHJKMJ;
	}

	public void PLAMBMCCOOE()
	{
		UnityEngine.Debug.Log("ID_NOTIFICATION_WITHDRAWAVAILABLE");
		if (IPIKDCMLOID == AJGFGCHCAPA.Walk)
		{
			Walk();
			HJFHCPBADLD.HDAGCEFHEBN();
		}
		if (IPIKDCMLOID == (AJGFGCHCAPA)(-6) && HJFHCPBADLD.PAGOOCFANHA() < 203f)
		{
			HJFHCPBADLD.Resume();
			Walk();
		}
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		soldierBehaviour.UpdateVisual();
		if (LCDBACDIODH && soldierBehaviour != null)
		{
			mSoldierAnimationController.ForceInScreen();
			float KBJEOEEOEFG = 0f;
			if (!mSoldierAnimationController.IsIdle(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG, out KBJEOEEOEFG))
			{
				mSoldierAnimationController.SampleIdle(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
			}
			else
			{
				mSoldierAnimationController.SampleIdle(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG, KBJEOEEOEFG);
			}
			mSoldierAnimationController.Idle(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
		}
		EFFIOHJHFHI.OFBEAKDOCIO.gameObject.SetActive(value: false);
	}

	private void NHJLEIIEILJ()
	{
		if (ILPLGCOCODB && base.isAlive)
		{
			soldierBehaviour.Shooting();
		}
	}

	private void EKDKBACABCK(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.gameObject.activeInHierarchy && OHJPPHFEAFI.FJLBLLLEELD == DestroyableObject.MANAGOLPMLH.Poison)
		{
			KJMFJFCDEDH.Show("game-ico-poison", IDEBKDPMPGM: true, HudObjectIndicator.NPPEJJKFCON.InfoIco);
			ONHLGNIBFGG = PDDOJAMAOHB;
		}
	}

	public void OnShot()
	{
		if (soldierBehaviour.KHKAAGCIJPO == null)
		{
			return;
		}
		switch (soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG)
		{
		case Weapon.IGGFMJAKLGO.GrenadeLauncher:
			mSoldierAnimationController.ShotFly();
			break;
		case Weapon.IGGFMJAKLGO.Riffle:
		case Weapon.IGGFMJAKLGO.Pistol:
		case Weapon.IGGFMJAKLGO.Shotgun:
		case Weapon.IGGFMJAKLGO.QBZ:
		case Weapon.IGGFMJAKLGO.SniperRiffle:
		case Weapon.IGGFMJAKLGO.Flamethrower:
		case Weapon.IGGFMJAKLGO.QBZ2:
		case Weapon.IGGFMJAKLGO.DoubleSMG:
		case Weapon.IGGFMJAKLGO.Machinegun:
		case Weapon.IGGFMJAKLGO.Colt:
			if (IPIKDCMLOID == AJGFGCHCAPA.ObstacleHiding)
			{
				mSoldierAnimationController.ShootFromCrawl(0.5f, 1f, soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Rusher || IPIKDCMLOID == AJGFGCHCAPA.RusherSpare)
			{
				mSoldierAnimationController.ShootStand(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Swat)
			{
				mSoldierAnimationController.ShootStand(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.CornerHiding)
			{
				mSoldierAnimationController.ShotFromCover(!KAKIEBINCDL, 1f, 0.5f, DLMKHPAJKDJ: false, soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Walk)
			{
				if (soldierBehaviour.soldierBehaviourDefinititon.canShootWhileRunningDontStop)
				{
					mSoldierAnimationController.ShootStandAdditive(0.4f);
					mSoldierAnimationController.PLCAOODHLCA = false;
					Vector3 pLEBANKIBPP = soldierBehaviour.OEDJOFINBMI - NGCDDPCAGJB.position;
					pLEBANKIBPP.y = 0f;
					mSoldierAnimationController.LookAtUpperBody(pLEBANKIBPP);
				}
				else
				{
					mSoldierAnimationController.ShootStand(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
				}
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Parachute)
			{
				mSoldierAnimationController.ShootStandAdditive(0.25f);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Gunslinger)
			{
				mSoldierAnimationController.ShootStandNew(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG, 1f, 0.5f);
			}
			break;
		case Weapon.IGGFMJAKLGO.SwatPistol:
		case Weapon.IGGFMJAKLGO.SwatSMG:
			if (IPIKDCMLOID == AJGFGCHCAPA.Walk)
			{
				mSoldierAnimationController.ShootFromSwatShield(0.5f, 1f);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Rusher || IPIKDCMLOID == AJGFGCHCAPA.RusherSpare)
			{
				mSoldierAnimationController.ShootFromSwatShield(0.5f, 1f);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Swat)
			{
				mSoldierAnimationController.ShootFromSwatShield(0.5f, 1f);
			}
			break;
		case Weapon.IGGFMJAKLGO.Minigun:
			if (IPIKDCMLOID == AJGFGCHCAPA.ObstacleHiding)
			{
				mSoldierAnimationController.ShootFromCrawl(0.5f, 1f, soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Rusher || IPIKDCMLOID == AJGFGCHCAPA.RusherSpare)
			{
				mSoldierAnimationController.ShootStand(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Swat)
			{
				mSoldierAnimationController.ShootStand(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.CornerHiding)
			{
				mSoldierAnimationController.ShotFromCover(!KAKIEBINCDL, 1f, 0.5f, DLMKHPAJKDJ: false, soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Walk || IPIKDCMLOID == AJGFGCHCAPA.Minigunner)
			{
				mSoldierAnimationController.ShootStand(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
			}
			if (IPIKDCMLOID == AJGFGCHCAPA.Parachute)
			{
				mSoldierAnimationController.ShootStandAdditive(0.25f);
			}
			break;
		case Weapon.IGGFMJAKLGO.Grenade:
		case Weapon.IGGFMJAKLGO.Bazooka:
		case Weapon.IGGFMJAKLGO.Tool:
			break;
		}
	}

	[PunRPC]
	public void ChangeWeightForDestroyablePartRPC(float KMMAKDHKIKH, int DFHAAIFFLOE)
	{
		OJIHGNJFPFM.AMEELJHHGKP[DFHAAIFFLOE].CMFNOLDCGCL *= KMMAKDHKIKH;
	}

	public void StartAnim(Vector3 IIMDKHJAJGO)
	{
		LFPCMNHOPOP = true;
		KKAHNPEGPEJ = IIMDKHJAJGO;
		HJFHCPBADLD.SetDestination(IIMDKHJAJGO);
		mSoldierAnimationController.Walk(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
		FMFKLFMGFAO = true;
	}

	private void GHLMPMFOLNA()
	{
		NLGBGOGCNKP = soldierBehaviour.GetInitPoint();
		if (NLGBGOGCNKP != null)
		{
			NLGBGOGCNKP.IDNNIHBIMNO = this;
			HJFHCPBADLD.SetDestination(NLGBGOGCNKP.position);
			Walk();
			GenerateNextShootTime();
			ALBLFGNKNDB = false;
			NJMMMLKFPAB = true;
		}
		else
		{
			InvokeAfter(GHLMPMFOLNA, 5f);
		}
	}

	[SpecialName]
	public void HKGAHNEPFEL(PlayerVisualCategoryPowerBands.PlayerVisualPowerBand IDEBKDPMPGM)
	{
		EBEPNOMNPPL.EFBOEEADMOL(IDEBKDPMPGM);
	}

	private void JHFAODAOMFK()
	{
		SoldierBehaviourWarper soldierBehaviourWarper = soldierBehaviour as SoldierBehaviourWarper;
		soldierBehaviourWarper.ChangeToNormalMat();
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("Position", PhotonTargets.All, new object[1]);
		}
		mSoldierAnimationController.WarpIdle();
	}

	[SpecialName]
	public void LAMLKAONDCN(PlayerVisualCategoryHelmets.PlayerVisualHelmet IDEBKDPMPGM)
	{
		EBEPNOMNPPL.IONNPKDDMPF(IDEBKDPMPGM);
	}

	public void Freeze(bool ALLIHOCMHBL)
	{
		try
		{
			if (GGDGAHPEDCC != null)
			{
				GGDGAHPEDCC.Freeze(ALLIHOCMHBL);
			}
			if (!base.isInstantiated)
			{
				return;
			}
			base.enabled = !ALLIHOCMHBL;
			HJFHCPBADLD.enabled = !ALLIHOCMHBL;
			if (ALLIHOCMHBL)
			{
				HJFHCPBADLD.Pause();
				mSoldierAnimationController.Pause();
				return;
			}
			if (HJFHCPBADLD.navigationAgent.enabled)
			{
				HJFHCPBADLD.Resume();
			}
			mSoldierAnimationController.Resume();
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	protected override void Update()
	{
		base.Update();
		PDDOJAMAOHB += Time.deltaTime;
		if (LFPCMNHOPOP)
		{
			BLAOPGHCGCG();
		}
		if (LCDBACDIODH || Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			return;
		}
		if (PDDOJAMAOHB > DNCNFMPNOBA && DNCNFMPNOBA != 0f)
		{
			EFFIOHJHFHI.SoldierDeath();
			JPAEIIEPIPC = 0f;
		}
		if (!base.isAlive)
		{
			return;
		}
		if (ONHLGNIBFGG != 0f && PDDOJAMAOHB > ONHLGNIBFGG + 2.5f)
		{
			UnityEngine.Debug.Log("Hide poison");
			KJMFJFCDEDH.Show("game-ico-poison", IDEBKDPMPGM: false, HudObjectIndicator.NPPEJJKFCON.InfoIco);
			ONHLGNIBFGG = 0f;
		}
		if (LAADDLGBFIG.isMine && !KIHGHENBPOP)
		{
			MFHLBKPFMOK = ALBLFGNKNDB || (IPIKDCMLOID == AJGFGCHCAPA.CornerHiding && JNAJGJFOIJD);
			FMFKLFMGFAO = IPIKDCMLOID == AJGFGCHCAPA.Walk && HJFHCPBADLD.velocity.sqrMagnitude > HJFHCPBADLD.speed * HJFHCPBADLD.speed * 0.9f;
			if (base.isAlive)
			{
				IODJECILLKI();
				if (NLGBGOGCNKP != null && NLGBGOGCNKP.IDNNIHBIMNO != this)
				{
					UnityEngine.Debug.LogError("bad enemy point");
				}
				switch (IPIKDCMLOID)
				{
				case AJGFGCHCAPA.Walk:
					HAJHPLNFEBM();
					break;
				case AJGFGCHCAPA.ObstacleHiding:
					LGDBMAGMAAN();
					break;
				case AJGFGCHCAPA.CornerHiding:
					KHFCHOPFJBA();
					break;
				case AJGFGCHCAPA.Rusher:
					PCBOHLJMJOG();
					break;
				case AJGFGCHCAPA.RusherSpare:
					IGHMLPJDMBE();
					break;
				case AJGFGCHCAPA.Swat:
					JCGIFLFLIJN();
					break;
				case AJGFGCHCAPA.Vehicle:
					HBFFCJIADLI();
					break;
				case AJGFGCHCAPA.Parachute:
					PICEPHBPBNC();
					break;
				case AJGFGCHCAPA.Helicopter:
					AHOKMPLFOCO();
					break;
				case AJGFGCHCAPA.MachineGunPoint:
					EMHCNBFEGLP();
					break;
				case AJGFGCHCAPA.Minigunner:
					OMPNAAMNDNH();
					break;
				case AJGFGCHCAPA.EngineerTurret:
					FHNJLIDDPAO();
					break;
				case AJGFGCHCAPA.Fly:
					OEEKJHPAMDH();
					break;
				case AJGFGCHCAPA.Gunslinger:
					JKGMOBMIDLF();
					break;
				case AJGFGCHCAPA.Mortar:
					ELAGAFBEPJI();
					break;
				case AJGFGCHCAPA.Warp:
					GDIFMGKEPGP();
					break;
				case AJGFGCHCAPA.Idle:
				case AJGFGCHCAPA.EngineerRepair:
					break;
				}
			}
		}
		else
		{
			PIKKIHGLNIN();
		}
	}

	[PunRPC]
	private void ShootFromCrawl(float GINCPOHPFBN)
	{
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("ShootFromCrawl", PhotonTargets.Others, GINCPOHPFBN);
		}
		if (soldierBehaviour.KHKAAGCIJPO != null)
		{
			mSoldierAnimationController.ShootFromCrawl(GINCPOHPFBN, 1f, soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
		}
	}

	private void PCBOHLJMJOG()
	{
		EnemyPointRusher enemyPointRusher = NLGBGOGCNKP as EnemyPointRusher;
		if (!(enemyPointRusher != null))
		{
			return;
		}
		if (PDDOJAMAOHB > HJEJNIJPFHF && !NBMPLHLIHOD && enemyPointRusher.playerPoint.shield.player != null)
		{
			KGDPPCIEJEI(JNPBHFODMKI: true, ILEOEIMBILP: false);
		}
		if (!NLGBGOGCNKP.isActive && !NBMPLHLIHOD)
		{
			FBIKDDGEENF += Time.deltaTime;
			if (FBIKDDGEENF > 1.5f)
			{
				EnemyPointRusher finalTarget = HOPDNNKAEOK();
				SetFinalTarget(finalTarget);
				SwitchState(AJGFGCHCAPA.Walk);
				FBIKDDGEENF = 0f;
			}
		}
	}

	[PunRPC]
	private void UpdateHeadScaleRPC(float FLPHBJHLHKE)
	{
		if (BOFNGHCJPFM != null)
		{
			BOFNGHCJPFM.scaleF = FLPHBJHLHKE;
		}
	}

	private void IODJECILLKI()
	{
		if (ILPLGCOCODB && base.isAlive)
		{
			soldierBehaviour.Shooting();
		}
	}

	[PunRPC]
	private void WarpIdle()
	{
		SoldierBehaviourWarper soldierBehaviourWarper = soldierBehaviour as SoldierBehaviourWarper;
		soldierBehaviourWarper.ChangeToNormalMat();
		if (LAADDLGBFIG.isMine)
		{
			LAADDLGBFIG.RPC("WarpIdle", PhotonTargets.Others);
		}
		mSoldierAnimationController.WarpIdle();
	}

	private void PIPCBHNNJHJ(UITweener MGDJMGHCAAI)
	{
		if (!base.isAlive)
		{
			return;
		}
		EnemyPoint newEnemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP);
		if (newEnemyPoint != null)
		{
			SetFinalTarget(newEnemyPoint);
			ShadowSetActive(IDEBKDPMPGM: true);
			SwitchState(AJGFGCHCAPA.Walk);
			return;
		}
		InvokeAfter(delegate
		{
			GDLEFNAGBLC();
		}, 5f);
		Walk();
		spawnPoint = soldierBehaviour.PickNormalSPawn(Singleton<MapManager>.instance.ALCHJDPKAID.DMCDJGLDICM.LIAEIIFPONK);
		HJFHCPBADLD.SetDestination(spawnPoint.transform.position);
		HJFHCPBADLD.Resume();
		HJFHCPBADLD.stoppingDistance = 0f;
	}

	private void PICEPHBPBNC()
	{
		if (!MLFKPOMJMOP)
		{
			NGCDDPCAGJB.position = GGDGAHPEDCC.JHNFPPDCBDK.position;
			NGCDDPCAGJB.rotation = GGDGAHPEDCC.JHNFPPDCBDK.rotation;
			if (PDDOJAMAOHB > HJEJNIJPFHF && !KGDPPCIEJEI(JNPBHFODMKI: false, ILEOEIMBILP: true, 16f))
			{
				GenerateNextShootTime();
			}
		}
	}

	private void BGKINBJANBF()
	{
		PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
		MPEENGAHOHJ = enemyOf.currentPlayerPoint.point;
		Vector3 lhs = MPEENGAHOHJ.shield.CLFKHIIPJAC.position - NGCDDPCAGJB.position;
		lhs = lhs.ReplaceY(0f);
		TweenRotation.Begin(base.gameObject, 0.2f, Quaternion.LookRotation(lhs)).ignoreTimeScale = false;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		if (BOFNGHCJPFM != null)
		{
			BOFNGHCJPFM.scaleF = 1f;
		}
		if (soldierBehaviour != null)
		{
			soldierBehaviour.Restart();
		}
		else
		{
			UnityEngine.Debug.LogError("soldier behaviour is null !!!!");
		}
		mSoldierAnimationController.Reset();
		EFFIOHJHFHI.MakeTrigger(IDEBKDPMPGM: false);
		EFFIOHJHFHI.MakeCollidersBulletVisible();
		EFFIOHJHFHI.DisableJetPackParticles();
		LFPCMNHOPOP = false;
		OJIHGNJFPFM.ResetWeights();
		OJIHGNJFPFM.RefillOffline();
		OJIHGNJFPFM.destroyableByBonusBox = true;
		TweenPosition component = GetComponent<TweenPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
		IPIKDCMLOID = AJGFGCHCAPA.Walk;
		ILPLGCOCODB = false;
		PFKPCFCEDME = false;
		JCKHCELHDBH = false;
		ALBLFGNKNDB = false;
		FBIKDDGEENF = 0f;
		KACEPCMMJHN = OLHLGDLDGPP.Spawning;
		NBMPLHLIHOD = false;
		ONHLGNIBFGG = 0f;
		DNCNFMPNOBA = 0f;
		JEPEEJIMFOE = true;
		GBBFIPKBJGG = true;
		KOKLMCHFKJC = true;
		if (LAADDLGBFIG.isMine)
		{
			KIHGHENBPOP = false;
			HJFHCPBADLD.enabled = true;
		}
		else
		{
			KIHGHENBPOP = true;
			HJFHCPBADLD.enabled = false;
		}
		if (LCDBACDIODH && soldierBehaviour != null)
		{
			mSoldierAnimationController.Idle(soldierBehaviour.KHKAAGCIJPO.BEACDIILBEG);
		}
	}

	public override void EnableSpawn()
	{
		base.EnableSpawn();
	}

	private Vector3 OLBAJGMGEGM(Vector3 FHMNGFGNFLL)
	{
		Vector3 vector = FHMNGFGNFLL + mSoldierAnimationController.MEBEGOBBAIA.position - base.transform.position;
		Vector3 result = FHMNGFGNFLL;
		Vector3 vector2 = base.transform.forward * 0.02f - base.transform.right * 0.04f;
		if (BGDGEJDKJOP != null)
		{
			Vector3 vector3 = BGDGEJDKJOP[0].transform.position;
			if (vector.y >= vector3.y)
			{
				vector3.y = vector.y;
				result = FHMNGFGNFLL + (vector3 - vector) + vector2;
			}
			else
			{
				for (int i = 1; i < BGDGEJDKJOP.Count; i++)
				{
					Vector3 position = BGDGEJDKJOP[i].transform.position;
					if (position.y <= vector.y)
					{
						float t = (position.y - vector.y) / (position.y - vector3.y);
						result = FHMNGFGNFLL + (Vector3.Lerp(position, vector3, t) - vector) + vector2;
						break;
					}
					vector3 = position;
				}
			}
		}
		return result;
	}

	private void ELAGAFBEPJI()
	{
		base.transform.position = NBHJGBNMEND;
		if (PDDOJAMAOHB > HJEJNIJPFHF)
		{
			HJEJNIJPFHF = float.MaxValue;
			FireMortar();
			KGDPPCIEJEI(JNPBHFODMKI: false, ILEOEIMBILP: false);
		}
		else if (HJEJNIJPFHF != float.MaxValue)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(fraction);
			if (MPEENGAHOHJ != enemyOf.currentPlayerPoint.point)
			{
				BGKINBJANBF();
			}
		}
		if (PDDOJAMAOHB > PEPDEICKMON)
		{
			EnemyPoint enemyPoint = NLGBGOGCNKP;
			if (NLGBGOGCNKP.IsEnemyPointReached(NGCDDPCAGJB.position))
			{
				enemyPoint = soldierBehaviour.GetNewEnemyPoint(NLGBGOGCNKP);
			}
			if (enemyPoint != null)
			{
				NLGBGOGCNKP.IDNNIHBIMNO = null;
				SetFinalTarget(enemyPoint);
				ALBLFGNKNDB = false;
				SwitchState(AJGFGCHCAPA.Walk);
			}
		}
	}
}
