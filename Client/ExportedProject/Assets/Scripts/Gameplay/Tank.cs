using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class Tank : Vehicle<TankBehaviour>
{
	[FormerlySerializedAs("ACLINDOAODK")]
	public float JPNAINOGAMM = 0.8f;

	[FormerlySerializedAs("DKMKKEJPNLA")]
	public float AKICJLHMLJC = 0.7f;

	private DestroyableObjectMultipleParts FFOAABONJNO;

	[FormerlySerializedAs("PIOENLJBDJJ")]
	public EnemyPointVehicle CKPKEGIKOLK;

	[FormerlySerializedAs("DLMHGGKOGGI")]
	public EnemyPointVehicle JHGIAHLDJJL;

	[FormerlySerializedAs("PHJJDNCDHKM")]
	public Animation DKIBCDJGAGA;

	[FormerlySerializedAs("JGNFGLEMBMK")]
	public Animation KNCELNACFPM;

	[FormerlySerializedAs("JKBIDKNJODC")]
	public GameObject KLILEECEACC;

	[FormerlySerializedAs("GEJMJGNNNCE")]
	public GameObject DFNHJNMBPHM;

	private Vector3 KFAIPMHFFKM;

	private Transform NGCDDPCAGJB;

	private int ILEKLILGKAK;

	private int INDBNCLMMNC;

	private Transform IMGHHHHHPKF;

	private bool KPBAJMBFKLF;

	private Rigidbody IKAIICBGIAC;

	private bool NBPAEDNBFGE;

	private Vector3 GLBAGFHENDK;

	private Vector3 EPEDHHEMFEM;

	private Quaternion BLFEDCIGICH;

	private float DHFAONHFMCF;

	[FormerlySerializedAs("CDOFFPIOHDE")]
	public TurretWeaponBasic PJJJKFOANDO;

	[FormerlySerializedAs("EADEPGKMMJP")]
	public TurretWeaponBasic KAEAMDOJMIF;

	[FormerlySerializedAs("JEHNEDHMKHF")]
	public AnimationCurve JIAODCNGHIM;

	private Vector3 GMENJOACKEO;

	[FormerlySerializedAs("DEHKIINLGPK")]
	public float FEBDCHNEHPN = 2f;

	private readonly LHMCMJDDOHI LADBLHGBOKJ = new LHMCMJDDOHI();

	[FormerlySerializedAs("LGMFCIHODNP")]
	public float BCKKOBCJBOP = 0.2f;

	[FormerlySerializedAs("BJECIMNFMBH")]
	public float FOFHGDGGEIG = 1f;

	private WaypointCircuit PCDILCOEIKD;

	private SpawnPointCar FEFGKKDIGCI;

	public override DestroyableObject destroyableObj => FFOAABONJNO;

	public void FCBFEKPJHJL(Vector3 PLEBANKIBPP)
	{
		if (LAADDLGBFIG.isMine)
		{
			if (!IKAIICBGIAC.isKinematic)
			{
				IKAIICBGIAC.AddForce(-PLEBANKIBPP.normalized * 1552f, ForceMode.Force);
				IKAIICBGIAC.angularVelocity = Vector3.zero;
			}
			else
			{
				TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 608f, KLILEECEACC.transform.position + 1848f * Vector3.up - GLBAGFHENDK * 1287f);
				tweenPosition.NumOfRepetitions = 7;
				tweenPosition.style = (UITweener.Style)3;
			}
		}
	}

	private void GHMILLMIKMJ()
	{
		OFDAFFJLHCH(CKPKEGIKOLK, KANKDLBGMLK: false);
	}

	private void JKFLPFCLMIB()
	{
		if (GJKNEGDKDFN && IKAIICBGIAC.velocity.magnitude < FOFHGDGGEIG)
		{
			IKAIICBGIAC.AddForce(-NGCDDPCAGJB.forward.normalized * BCKKOBCJBOP, (ForceMode)7);
		}
		if (!LCDBACDIODH && KPBAJMBFKLF && LAADDLGBFIG.isMine && IMGHHHHHPKF != null && PCDILCOEIKD != null)
		{
			if (NGCDDPCAGJB.position.PlanarDistance(IMGHHHHHPKF.position) < AKICJLHMLJC && INDBNCLMMNC < ILEKLILGKAK - 0)
			{
				INDBNCLMMNC += 0;
				IMGHHHHHPKF = PCDILCOEIKD.KJKEAADMJPJ.DMKDFIJIBEP(INDBNCLMMNC);
			}
			Vector3 vector = (IMGHHHHHPKF.position - base.transform.position).ReplaceY(1571f);
			vector = vector.ClampMagnitude(1630f, 1085f);
			float num = 175f - Vector3.Angle(vector, NGCDDPCAGJB.forward);
			float num2 = Mathf.Pow(num / 1037f, 1368f);
			Vector3 vector2 = vector * JPNAINOGAMM * num2;
			Vector3 force = (vector2 - IKAIICBGIAC.velocity).ReplaceY(1971f);
			IKAIICBGIAC.AddForce(force, ForceMode.VelocityChange);
			if (!NBPAEDNBFGE)
			{
				Vector3 normalized = vector.normalized;
				float f = Vector3.Dot(NGCDDPCAGJB.forward, normalized);
				Vector3 vector3 = Vector3.Cross(NGCDDPCAGJB.forward, normalized) * FEBDCHNEHPN * JIAODCNGHIM.Evaluate(Mathf.Abs(f));
				Vector3 torque = vector3 - IKAIICBGIAC.angularVelocity;
				IKAIICBGIAC.AddTorque(torque, (ForceMode)4);
			}
			if (INDBNCLMMNC == ILEKLILGKAK - 1 && !NBPAEDNBFGE && IMGHHHHHPKF.position.PlanarDistance(base.transform.position) < 1314f)
			{
				NBPAEDNBFGE = true;
				GLBAGFHENDK = base.transform.forward;
				KLILEECEACC.gameObject.SetActive(value: false);
				DFNHJNMBPHM.gameObject.SetActive(value: true);
				KLILEECEACC.transform.position = NGCDDPCAGJB.position;
				KLILEECEACC.transform.rotation = NGCDDPCAGJB.rotation;
				GetComponent<Rigidbody>().isKinematic = false;
				isParked = false;
			}
		}
	}

	public virtual void HBANGBMJNGO(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			KNCELNACFPM.Stop();
			DKIBCDJGAGA.Stop();
			GetComponent<Rigidbody>().isKinematic = false;
		}
		else
		{
			KNCELNACFPM.Play("weapon doesnt have ammo setup");
			DKIBCDJGAGA.Play("{0}:{1}\t\t{2}");
			GetComponent<Rigidbody>().isKinematic = false;
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, JHGIAHLDJJL, DKIPMCCIKMF: true);
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, CKPKEGIKOLK, DKIPMCCIKMF: false);
	}

	private void PDBCMCFGMCJ()
	{
		Weapon.OnShotFired -= MJPMLEBJBMC;
		Weapon.OnShotFired += FPLKBANMKLH;
	}

	public virtual void KFMMFCCJHPI()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.BDDGHLDAOFP().health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-9)).FLOATVALUE;
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.ABFGHBDEBAN = base.currentBeh.BGHFNDONBHC().damageCannon;
		missileSetup.EPDELOGPNAC = base.currentBeh.NCOOFGKGBEK().damageCannon / 175f;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = base.currentBeh.ADJCPDPCEME().shotSpeed * 1644f;
		PJJJKFOANDO.MNGCPAPDCNB = 0;
		PJJJKFOANDO.JMJHGHAHAOH = 0;
		PJJJKFOANDO.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		if (base.hasSpecial)
		{
			PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.tankBehaviourDefinititon.minShootTimeCannon * 747f;
			PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.ADJCPDPCEME().maxShootTimeCannon * 1602f;
		}
		else
		{
			PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.BDDGHLDAOFP().minShootTimeCannon;
			PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.tankBehaviourDefinititon.maxShootTimeCannon;
		}
		PJJJKFOANDO.LLOHEBJBBDH = 1750f;
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.tankBehaviourDefinititon.damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.HDBMBJIGLAN().shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.BDDGHLDAOFP().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.BGHFNDONBHC().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.BGHFNDONBHC().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.NCOOFGKGBEK().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.NCOOFGKGBEK().probabilityOfRealShot;
		JPNAINOGAMM = base.currentBeh.NCOOFGKGBEK().speed;
	}

	protected virtual void LPFGBKIINMP()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			float magnitude = IKAIICBGIAC.velocity.magnitude;
			float speed = magnitude / JPNAINOGAMM;
			DKIBCDJGAGA["Set Delegate"].speed = speed;
			KNCELNACFPM["N"].speed = speed;
			return;
		}
		if (!LAADDLGBFIG.isMine && Singleton<GameController>.instance.GHKPKDPOGHF())
		{
			LADBLHGBOKJ.EMPDDFBNJLP(NGCDDPCAGJB);
		}
		float speed2 = DHFAONHFMCF / JPNAINOGAMM;
		DKIBCDJGAGA["getCustomProfileNumber"].speed = speed2;
		KNCELNACFPM[" NOT OK!\t\t\t\t\t\t"].speed = speed2;
	}

	public virtual void AAGOGKDHNJC()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.BGHFNDONBHC().health;
		FFOAABONJNO.NGNPMPGIAGP();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-83)).FLOATVALUE;
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.ABFGHBDEBAN = base.currentBeh.NCOOFGKGBEK().damageCannon;
		missileSetup.EPDELOGPNAC = base.currentBeh.BDDGHLDAOFP().damageCannon / 1967f;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = base.currentBeh.ADJCPDPCEME().shotSpeed * 112f;
		PJJJKFOANDO.MNGCPAPDCNB = 0;
		PJJJKFOANDO.JMJHGHAHAOH = 0;
		PJJJKFOANDO.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		if (base.hasSpecial)
		{
			PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.HDBMBJIGLAN().minShootTimeCannon * 1097f;
			PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.ADJCPDPCEME().maxShootTimeCannon * 1357f;
		}
		else
		{
			PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.tankBehaviourDefinititon.minShootTimeCannon;
			PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.BDDGHLDAOFP().maxShootTimeCannon;
		}
		PJJJKFOANDO.LLOHEBJBBDH = 60f;
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.BGHFNDONBHC().damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.BDDGHLDAOFP().shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.HDBMBJIGLAN().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.tankBehaviourDefinititon.fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.ADJCPDPCEME().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.BDDGHLDAOFP().maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.NCOOFGKGBEK().probabilityOfRealShot;
		JPNAINOGAMM = base.currentBeh.HDBMBJIGLAN().speed;
	}

	private void OnDisable()
	{
		Weapon.OnShotFired -= PJFDBKCIAOD;
	}

	private void IOFCNLCLNFG()
	{
		if ((bool)IMGHHHHHPKF)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(IMGHHHHHPKF.position, 671f);
		}
	}

	public virtual void HGPOCNMFAGE()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		List<SpawnPointCar> list = new List<SpawnPointCar>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (spawnPointCar.IPJOMHKDPKC() == fraction && spawnPointCar.PODMFKMOJML == null)
			{
				list.Add(spawnPointCar);
			}
		}
		if (list.Count > 0)
		{
			int index = Random.Range(0, list.Count);
			SpawnPointCar spawnPointCar2 = list[index];
			base.transform.position = spawnPointCar2.transform.position;
			base.transform.rotation = Quaternion.LookRotation(spawnPointCar2.MEDNJFIDNIL.KJKEAADMJPJ.BHKEOLDAIEE(0).transform.position - spawnPointCar2.transform.position);
			FEFGKKDIGCI = spawnPointCar2;
			FEFGKKDIGCI.PODMFKMOJML = this;
			OJDNAMCDPGC(spawnPointCar2.MEDNJFIDNIL);
		}
		else
		{
			Debug.LogError("unit");
		}
	}

	private void EMJIBKBJEEO(Vector3 MPHCNMDIPAI)
	{
		Vector3 position = PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		PlayShootFeedBack(MPHCNMDIPAI - position);
		Vector3 vector = PJJJKFOANDO.transform.InverseTransformDirection((MPHCNMDIPAI - position).normalized);
		TweenPosition tweenPosition = TweenPosition.Begin(PJJJKFOANDO.gameObject, 0.25f, GMENJOACKEO, GMENJOACKEO - vector * 0.16f);
		tweenPosition.NumOfRepetitions = 2;
		tweenPosition.style = UITweener.Style.PingPong;
	}

	private void OGCBBLDHJEC(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		EnemyController enemyController = (EnemyController)JAOCCGDPCGH;
		if (enemyController.NLGBGOGCNKP == CKPKEGIKOLK)
		{
			InvokeAfterRealTime(ONJNGGBNBJI, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.BBBLJNFEACC();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.NLGBGOGCNKP == JHGIAHLDJJL)
		{
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.BBBLJNFEACC();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(PODCDFGOHBM, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= JNMHFGANCDE;
	}

	protected virtual void NKGLGNEJIOA()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			float magnitude = IKAIICBGIAC.velocity.magnitude;
			float speed = magnitude / JPNAINOGAMM;
			DKIBCDJGAGA["Tickets"].speed = speed;
			KNCELNACFPM["setDebugMode"].speed = speed;
			return;
		}
		if (!LAADDLGBFIG.isMine && Singleton<GameController>.instance.KKHKIEFMENC())
		{
			LADBLHGBOKJ.BLOBBBLIJPI(NGCDDPCAGJB);
		}
		float speed2 = DHFAONHFMCF / JPNAINOGAMM;
		DKIBCDJGAGA["elite"].speed = speed2;
		KNCELNACFPM["Days_Since_Install"].speed = speed2;
	}

	public void CDKPDNCIINO(WaypointCircuit AGKJOIBEFJJ)
	{
		ILEKLILGKAK = AGKJOIBEFJJ.KJKEAADMJPJ.items.Length;
		INDBNCLMMNC = 1;
		IMGHHHHHPKF = AGKJOIBEFJJ.KJKEAADMJPJ.items[1].transform;
		KPBAJMBFKLF = true;
		PCDILCOEIKD = AGKJOIBEFJJ;
	}

	public void EEHJGPEBDNN(Vector3 PLEBANKIBPP)
	{
		if (LAADDLGBFIG.isMine)
		{
			if (!IKAIICBGIAC.isKinematic)
			{
				IKAIICBGIAC.AddForce(-PLEBANKIBPP.normalized * 1898f, ForceMode.Impulse);
				IKAIICBGIAC.angularVelocity = Vector3.zero;
			}
			else
			{
				TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 77f, KLILEECEACC.transform.position + 1573f * Vector3.up - GLBAGFHENDK * 1112f);
				tweenPosition.NumOfRepetitions = 4;
				tweenPosition.style = UITweener.Style.Loop;
			}
		}
	}

	public virtual void DLIEIJOFNJP()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		List<SpawnPointCar> list = new List<SpawnPointCar>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (spawnPointCar.DJEPLLFFBEC() == fraction && spawnPointCar.PODMFKMOJML == null)
			{
				list.Add(spawnPointCar);
			}
		}
		if (list.Count > 0)
		{
			int index = Random.Range(0, list.Count);
			SpawnPointCar spawnPointCar2 = list[index];
			base.transform.position = spawnPointCar2.transform.position;
			base.transform.rotation = Quaternion.LookRotation(spawnPointCar2.MEDNJFIDNIL.KJKEAADMJPJ.OKGFLCADPHH(1).transform.position - spawnPointCar2.transform.position);
			FEFGKKDIGCI = spawnPointCar2;
			FEFGKKDIGCI.PODMFKMOJML = this;
			SetWayPoint(spawnPointCar2.MEDNJFIDNIL);
		}
		else
		{
			Debug.LogError("hookId");
		}
	}

	protected override void Update()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			float magnitude = IKAIICBGIAC.velocity.magnitude;
			float speed = magnitude / JPNAINOGAMM;
			DKIBCDJGAGA["right"].speed = speed;
			KNCELNACFPM["left"].speed = speed;
			return;
		}
		if (!LAADDLGBFIG.isMine && Singleton<GameController>.instance.gameIsRunning)
		{
			LADBLHGBOKJ.NFGMGBMCNOF(NGCDDPCAGJB);
		}
		float speed2 = DHFAONHFMCF / JPNAINOGAMM;
		DKIBCDJGAGA["right"].speed = speed2;
		KNCELNACFPM["left"].speed = speed2;
	}

	[CompilerGenerated]
	private void CNICAAMNEFG()
	{
		IDAOCGPNDBI(JHGIAHLDJJL, KANKDLBGMLK: false);
	}

	[SpecialName]
	public virtual DestroyableObject AAMCPDKGDCG()
	{
		return FFOAABONJNO;
	}

	public void SetWayPoint(WaypointCircuit AGKJOIBEFJJ)
	{
		ILEKLILGKAK = AGKJOIBEFJJ.KJKEAADMJPJ.items.Length;
		INDBNCLMMNC = 0;
		IMGHHHHHPKF = AGKJOIBEFJJ.KJKEAADMJPJ.items[0].transform;
		KPBAJMBFKLF = true;
		PCDILCOEIKD = AGKJOIBEFJJ;
	}

	private void FOPJJHBIPJL()
	{
		Weapon.OnShotFired -= PJFDBKCIAOD;
		Weapon.OnShotFired += FPLKBANMKLH;
	}

	private void JNMHFGANCDE(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		EnemyController enemyController = (EnemyController)JAOCCGDPCGH;
		if (enemyController.NLGBGOGCNKP == CKPKEGIKOLK)
		{
			InvokeAfterRealTime(DLJNJPFLBLG, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.GGMKKIDFJOH();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.NLGBGOGCNKP == JHGIAHLDJJL)
		{
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.HEOPOOMLPJF();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(HOLPDCNNGCF, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= LLIFPAAPHOC;
	}

	private void IDBDPGJPOIN()
	{
		if (GJKNEGDKDFN && IKAIICBGIAC.velocity.magnitude < FOFHGDGGEIG)
		{
			IKAIICBGIAC.AddForce(-NGCDDPCAGJB.forward.normalized * BCKKOBCJBOP, ForceMode.Acceleration);
		}
		if (!LCDBACDIODH && KPBAJMBFKLF && LAADDLGBFIG.isMine && IMGHHHHHPKF != null && PCDILCOEIKD != null)
		{
			if (NGCDDPCAGJB.position.PlanarDistance(IMGHHHHHPKF.position) < AKICJLHMLJC && INDBNCLMMNC < ILEKLILGKAK - 0)
			{
				INDBNCLMMNC += 0;
				IMGHHHHHPKF = PCDILCOEIKD.KJKEAADMJPJ.BJEAEDLLEME(INDBNCLMMNC);
			}
			Vector3 vector = (IMGHHHHHPKF.position - base.transform.position).ReplaceY(502f);
			vector = vector.ClampMagnitude(1997f, 502f);
			float num = 1690f - Vector3.Angle(vector, NGCDDPCAGJB.forward);
			float num2 = Mathf.Pow(num / 15f, 928f);
			Vector3 vector2 = vector * JPNAINOGAMM * num2;
			Vector3 force = (vector2 - IKAIICBGIAC.velocity).ReplaceY(1529f);
			IKAIICBGIAC.AddForce(force, ForceMode.Force);
			if (!NBPAEDNBFGE)
			{
				Vector3 normalized = vector.normalized;
				float f = Vector3.Dot(NGCDDPCAGJB.forward, normalized);
				Vector3 vector3 = Vector3.Cross(NGCDDPCAGJB.forward, normalized) * FEBDCHNEHPN * JIAODCNGHIM.Evaluate(Mathf.Abs(f));
				Vector3 torque = vector3 - IKAIICBGIAC.angularVelocity;
				IKAIICBGIAC.AddTorque(torque, (ForceMode)4);
			}
			if (INDBNCLMMNC == ILEKLILGKAK - 1 && !NBPAEDNBFGE && IMGHHHHHPKF.position.PlanarDistance(base.transform.position) < 854f)
			{
				NBPAEDNBFGE = false;
				GLBAGFHENDK = base.transform.forward;
				KLILEECEACC.gameObject.SetActive(value: true);
				DFNHJNMBPHM.gameObject.SetActive(value: false);
				KLILEECEACC.transform.position = NGCDDPCAGJB.position;
				KLILEECEACC.transform.rotation = NGCDDPCAGJB.rotation;
				GetComponent<Rigidbody>().isKinematic = true;
				isParked = true;
			}
		}
	}

	private void OFDAFFJLHCH(EnemyPointVehicle PLMMBKGLGAB, bool KANKDLBGMLK)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.BMNEPICFHNO().LMJOPLCEBAA(enemyController, fraction, EEAMBOACAGF: true, PLMMBKGLGAB.FBGFMDOHAEG());
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.Helicopter);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.Killed += JNMHFGANCDE;
			if (PLMMBKGLGAB == CKPKEGIKOLK)
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
				KAEAMDOJMIF.enabled = true;
				KAEAMDOJMIF.HEOPOOMLPJF();
			}
			else
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				PJJJKFOANDO.enabled = true;
				PJJJKFOANDO.HEOPOOMLPJF();
			}
		}
	}

	public void EOFGLKGHHKG(Vector3 PLEBANKIBPP)
	{
		if (LAADDLGBFIG.isMine)
		{
			if (!IKAIICBGIAC.isKinematic)
			{
				IKAIICBGIAC.AddForce(-PLEBANKIBPP.normalized * 373f, ForceMode.Impulse);
				IKAIICBGIAC.angularVelocity = Vector3.zero;
			}
			else
			{
				TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 607f, KLILEECEACC.transform.position + 1652f * Vector3.up - GLBAGFHENDK * 420f, useLocal: false);
				tweenPosition.NumOfRepetitions = 7;
				tweenPosition.style = UITweener.Style.PingPong;
			}
		}
	}

	public override void SafeStart()
	{
		base.SafeStart();
		KLILEECEACC.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
	}

	public virtual void GEINAEKMOOP()
	{
		base.OnInstancied();
		GetComponent<Rigidbody>().isKinematic = LCDBACDIODH;
		KNCELNACFPM.enabled = false;
		DKIBCDJGAGA.enabled = true;
		KNCELNACFPM.Play("Wrong_Category");
		DKIBCDJGAGA.Play("customGeo");
		PJJJKFOANDO.enabled = false;
		KAEAMDOJMIF.IEHMPLOKAHC();
		if (!LCDBACDIODH)
		{
			StopAllCoroutines();
			DFNHJNMBPHM.gameObject.SetActive(value: false);
			NBPAEDNBFGE = true;
			IKAIICBGIAC.velocity = Vector3.zero;
			IKAIICBGIAC.angularVelocity = Vector3.zero;
			IAICPGNGCJI = base.currentBeh.totalPower;
			if (LAADDLGBFIG.isMine)
			{
				IDAOCGPNDBI(CKPKEGIKOLK, KANKDLBGMLK: false);
				KFOJKAMLMED(JHGIAHLDJJL, KANKDLBGMLK: false);
			}
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.BBBLJNFEACC();
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.NIGDCBDKKMJ();
			PJJJKFOANDO.JNFKFJOECJE();
			GetComponent<Rigidbody>().isKinematic = LAADDLGBFIG.isMine;
		}
	}

	private void DLJNJPFLBLG()
	{
		JFADLFOOGBD(CKPKEGIKOLK, KANKDLBGMLK: false);
	}

	protected virtual void OBPDFCOPCMK()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		NGCDDPCAGJB = base.transform;
		GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
		FFOAABONJNO.OnDeath += NKKNGMNDKCH;
		IKAIICBGIAC = GetComponent<Rigidbody>();
		DKIBCDJGAGA["0"].wrapMode = (WrapMode)6;
		KNCELNACFPM["211 LOADING MENU"].wrapMode = (WrapMode)5;
		GMENJOACKEO = PJJJKFOANDO.transform.localPosition;
	}

	private void JFADLFOOGBD(EnemyPointVehicle PLMMBKGLGAB, bool KANKDLBGMLK)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.PHNKKNODIJE(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.instance.JLGCKNOKGBL(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.PFOBADFGAKF());
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Walk);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.Killed += FOPOOGKOHIL;
			if (PLMMBKGLGAB == CKPKEGIKOLK)
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				KAEAMDOJMIF.enabled = true;
				KAEAMDOJMIF.IPKNPABKAJD();
			}
			else
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				PJJJKFOANDO.enabled = true;
				PJJJKFOANDO.BBBLJNFEACC();
			}
		}
	}

	private void IFIEHGDOGON()
	{
		if ((bool)IMGHHHHHPKF)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(IMGHHHHHPKF.position, 1423f);
		}
	}

	public virtual void HNIGDPCNFGH(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			KNCELNACFPM.Stop();
			DKIBCDJGAGA.Stop();
			GetComponent<Rigidbody>().isKinematic = true;
		}
		else
		{
			KNCELNACFPM.Play("N");
			DKIBCDJGAGA.Play("menu-weapons-tab");
			GetComponent<Rigidbody>().isKinematic = true;
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, JHGIAHLDJJL, DKIPMCCIKMF: false);
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, CKPKEGIKOLK, DKIPMCCIKMF: true);
	}

	public virtual void JMCCLLPKFGC()
	{
		OEBPFFBKBBD(CKPKEGIKOLK, CBOLHDHIDIF);
		OEBPFFBKBBD(JHGIAHLDJJL, CBOLHDHIDIF);
		KNCELNACFPM.enabled = false;
		DKIBCDJGAGA.enabled = true;
		KLILEECEACC.gameObject.SetActive(value: true);
		DFNHJNMBPHM.gameObject.SetActive(value: true);
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		base.DestroyPooled();
	}

	private void FPLKBANMKLH(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG == PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG)
		{
			IEEFAMHLJFD(MPHCNMDIPAI);
		}
	}

	private void MIBLGEHLDOP(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			LADBLHGBOKJ.PBBCPPKOGBJ(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			CLNMMEMKKGO.SendNext(IKAIICBGIAC.velocity.magnitude);
		}
		else
		{
			LADBLHGBOKJ.KPPBDNGCALK(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			DHFAONHFMCF = (float)CLNMMEMKKGO.ReceiveNext();
		}
	}

	private void JLMECNBOEEM()
	{
		if ((bool)IMGHHHHHPKF)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(IMGHHHHHPKF.position, 913f);
		}
	}

	private void PODCDFGOHBM()
	{
		KFOJKAMLMED(JHGIAHLDJJL, KANKDLBGMLK: false);
	}

	public virtual void IMHOHLIDMIG()
	{
		OEBPFFBKBBD(CKPKEGIKOLK, CBOLHDHIDIF);
		OEBPFFBKBBD(JHGIAHLDJJL, NMKNGPBAJEG);
		KNCELNACFPM.enabled = false;
		DKIBCDJGAGA.enabled = true;
		KLILEECEACC.gameObject.SetActive(value: false);
		DFNHJNMBPHM.gameObject.SetActive(value: false);
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		base.DestroyPooled();
	}

	private void OnDrawGizmos()
	{
		if ((bool)IMGHHHHHPKF)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(IMGHHHHHPKF.position, 0.3f);
		}
	}

	public virtual void NJJCFALPMFH()
	{
		base.OnInstancied();
		GetComponent<Rigidbody>().isKinematic = LCDBACDIODH;
		KNCELNACFPM.enabled = false;
		DKIBCDJGAGA.enabled = true;
		KNCELNACFPM.Play("throw_grenade_left");
		DKIBCDJGAGA.Play("LootBox_Open");
		PJJJKFOANDO.enabled = false;
		KAEAMDOJMIF.JNFKFJOECJE();
		if (!LCDBACDIODH)
		{
			StopAllCoroutines();
			DFNHJNMBPHM.gameObject.SetActive(value: true);
			NBPAEDNBFGE = false;
			IKAIICBGIAC.velocity = Vector3.zero;
			IKAIICBGIAC.angularVelocity = Vector3.zero;
			IAICPGNGCJI = base.currentBeh.totalPower;
			if (LAADDLGBFIG.isMine)
			{
				EOPABEGJABM(CKPKEGIKOLK, KANKDLBGMLK: true);
				EOPABEGJABM(JHGIAHLDJJL, KANKDLBGMLK: false);
			}
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.MGJIOLLKHDK();
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.HEOPOOMLPJF();
			PJJJKFOANDO.MCEPKEIINAA();
			GetComponent<Rigidbody>().isKinematic = !LAADDLGBFIG.isMine;
		}
	}

	[CompilerGenerated]
	private void MAIJGGHMDOA()
	{
		IDAOCGPNDBI(CKPKEGIKOLK, KANKDLBGMLK: false);
	}

	private void EAOEPEMNBKH()
	{
		Weapon.OnShotFired -= PJFDBKCIAOD;
		Weapon.OnShotFired += KMNDLPMBJNJ;
	}

	private void CIGMMLKAICG()
	{
		Weapon.OnShotFired -= HPMOGAJMLBL;
		Weapon.OnShotFired += DMOBGJCJNDD;
	}

	protected virtual void EFEFOJLPOJM()
	{
		JCKCDCFJAHP();
	}

	public void OJDNAMCDPGC(WaypointCircuit AGKJOIBEFJJ)
	{
		ILEKLILGKAK = AGKJOIBEFJJ.KJKEAADMJPJ.items.Length;
		INDBNCLMMNC = 0;
		IMGHHHHHPKF = AGKJOIBEFJJ.KJKEAADMJPJ.items[0].transform;
		KPBAJMBFKLF = true;
		PCDILCOEIKD = AGKJOIBEFJJ;
	}

	private void OACFIDAFBKJ(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			LADBLHGBOKJ.PBBCPPKOGBJ(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			CLNMMEMKKGO.SendNext(IKAIICBGIAC.velocity.magnitude);
		}
		else
		{
			LADBLHGBOKJ.PMPDLGJBMIE(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			DHFAONHFMCF = (float)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public virtual void NOCIEPKFPNB()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.APFFCILMOII();
	}

	private void BMFKGMADKNI()
	{
		Weapon.OnShotFired -= FPLKBANMKLH;
		Weapon.OnShotFired += FPLKBANMKLH;
	}

	protected virtual void KINHAJCDKGN()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		NGCDDPCAGJB = base.transform;
		GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
		FFOAABONJNO.OnDeath += NHMKPMPCDCL;
		IKAIICBGIAC = GetComponent<Rigidbody>();
		DKIBCDJGAGA["com/google/android/gms/games/stats/PlayerStats"].wrapMode = WrapMode.Once;
		KNCELNACFPM[" ("].wrapMode = WrapMode.ClampForever;
		GMENJOACKEO = PJJJKFOANDO.transform.localPosition;
	}

	private void HEEPGHHLCCI()
	{
		Weapon.OnShotFired -= PJFDBKCIAOD;
	}

	private void FixedUpdate()
	{
		if (GJKNEGDKDFN && IKAIICBGIAC.velocity.magnitude < FOFHGDGGEIG)
		{
			IKAIICBGIAC.AddForce(-NGCDDPCAGJB.forward.normalized * BCKKOBCJBOP, ForceMode.VelocityChange);
		}
		if (!LCDBACDIODH && KPBAJMBFKLF && LAADDLGBFIG.isMine && IMGHHHHHPKF != null && PCDILCOEIKD != null)
		{
			if (NGCDDPCAGJB.position.PlanarDistance(IMGHHHHHPKF.position) < AKICJLHMLJC && INDBNCLMMNC < ILEKLILGKAK - 1)
			{
				INDBNCLMMNC++;
				IMGHHHHHPKF = PCDILCOEIKD.KJKEAADMJPJ[INDBNCLMMNC];
			}
			Vector3 vector = (IMGHHHHHPKF.position - base.transform.position).ReplaceY(0f);
			vector = vector.ClampMagnitude(0.65f, 1f);
			float num = 360f - Vector3.Angle(vector, NGCDDPCAGJB.forward);
			float num2 = Mathf.Pow(num / 360f, 3f);
			Vector3 vector2 = vector * JPNAINOGAMM * num2;
			Vector3 force = (vector2 - IKAIICBGIAC.velocity).ReplaceY(0f);
			IKAIICBGIAC.AddForce(force, ForceMode.VelocityChange);
			if (!NBPAEDNBFGE)
			{
				Vector3 normalized = vector.normalized;
				float f = Vector3.Dot(NGCDDPCAGJB.forward, normalized);
				Vector3 vector3 = Vector3.Cross(NGCDDPCAGJB.forward, normalized) * FEBDCHNEHPN * JIAODCNGHIM.Evaluate(Mathf.Abs(f));
				Vector3 torque = vector3 - IKAIICBGIAC.angularVelocity;
				IKAIICBGIAC.AddTorque(torque, ForceMode.VelocityChange);
			}
			if (INDBNCLMMNC == ILEKLILGKAK - 1 && !NBPAEDNBFGE && IMGHHHHHPKF.position.PlanarDistance(base.transform.position) < 0.1f)
			{
				NBPAEDNBFGE = true;
				GLBAGFHENDK = base.transform.forward;
				KLILEECEACC.gameObject.SetActive(value: true);
				DFNHJNMBPHM.gameObject.SetActive(value: false);
				KLILEECEACC.transform.position = NGCDDPCAGJB.position;
				KLILEECEACC.transform.rotation = NGCDDPCAGJB.rotation;
				GetComponent<Rigidbody>().isKinematic = true;
				isParked = true;
			}
		}
	}

	private void HPMOGAJMLBL(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG == PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG)
		{
			EDOIFNFJAFJ(MPHCNMDIPAI);
		}
	}

	private void LLIFPAAPHOC(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		EnemyController enemyController = (EnemyController)JAOCCGDPCGH;
		if (enemyController.NLGBGOGCNKP == CKPKEGIKOLK)
		{
			InvokeAfterRealTime(AINNLHOAGFM, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.GGMKKIDFJOH();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.NLGBGOGCNKP == JHGIAHLDJJL)
		{
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.HEOPOOMLPJF();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(NFNOAGNIANO, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= LLIFPAAPHOC;
	}

	private void NMKNGPBAJEG(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		EnemyController enemyController = (EnemyController)JAOCCGDPCGH;
		if (enemyController.NLGBGOGCNKP == CKPKEGIKOLK)
		{
			InvokeAfterRealTime(GHMILLMIKMJ, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.GGMKKIDFJOH();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.NLGBGOGCNKP == JHGIAHLDJJL)
		{
			PJJJKFOANDO.enabled = false;
			PJJJKFOANDO.Reset();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(delegate
			{
				IDAOCGPNDBI(JHGIAHLDJJL, KANKDLBGMLK: false);
			}, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= LHLLMDHKCMH;
	}

	private void PJFDBKCIAOD(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG == PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG)
		{
			EMJIBKBJEEO(MPHCNMDIPAI);
		}
	}

	public virtual void ODNJNJFPCCO()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.LDKFDMLPIOC();
	}

	private void BOBKPFNCNDO()
	{
		Weapon.OnShotFired -= KMNDLPMBJNJ;
		Weapon.OnShotFired += MJPMLEBJBMC;
	}

	private void ONJNGGBNBJI()
	{
		JFADLFOOGBD(CKPKEGIKOLK, KANKDLBGMLK: true);
	}

	private void KEBMEMFHLNB()
	{
		Weapon.OnShotFired -= MJPMLEBJBMC;
		Weapon.OnShotFired += PJFDBKCIAOD;
	}

	private void NIFHKLIMNHG()
	{
		if ((bool)IMGHHHHHPKF)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(IMGHHHHHPKF.position, 1165f);
		}
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			KNCELNACFPM.Stop();
			DKIBCDJGAGA.Stop();
			GetComponent<Rigidbody>().isKinematic = false;
		}
		else
		{
			KNCELNACFPM.Play("left");
			DKIBCDJGAGA.Play("right");
			GetComponent<Rigidbody>().isKinematic = true;
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, JHGIAHLDJJL, DKIPMCCIKMF: true);
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, CKPKEGIKOLK, DKIPMCCIKMF: true);
	}

	public void EHHIINCKADE(WaypointCircuit AGKJOIBEFJJ)
	{
		ILEKLILGKAK = AGKJOIBEFJJ.KJKEAADMJPJ.items.Length;
		INDBNCLMMNC = 1;
		IMGHHHHHPKF = AGKJOIBEFJJ.KJKEAADMJPJ.items[1].transform;
		KPBAJMBFKLF = false;
		PCDILCOEIKD = AGKJOIBEFJJ;
	}

	public virtual void FMIHBBGBGLO()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.CNBLDCICPLL();
	}

	public virtual void LHLPDEAMJLC()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.APFFCILMOII();
	}

	private void LLEEBKBBICE()
	{
		if (GJKNEGDKDFN && IKAIICBGIAC.velocity.magnitude < FOFHGDGGEIG)
		{
			IKAIICBGIAC.AddForce(-NGCDDPCAGJB.forward.normalized * BCKKOBCJBOP, ForceMode.VelocityChange);
		}
		if (!LCDBACDIODH && KPBAJMBFKLF && LAADDLGBFIG.isMine && IMGHHHHHPKF != null && PCDILCOEIKD != null)
		{
			if (NGCDDPCAGJB.position.PlanarDistance(IMGHHHHHPKF.position) < AKICJLHMLJC && INDBNCLMMNC < ILEKLILGKAK - 1)
			{
				INDBNCLMMNC++;
				IMGHHHHHPKF = PCDILCOEIKD.KJKEAADMJPJ.ABCJHKMKJME(INDBNCLMMNC);
			}
			Vector3 vector = (IMGHHHHHPKF.position - base.transform.position).ReplaceY(1612f);
			vector = vector.ClampMagnitude(1790f, 1355f);
			float num = 1562f - Vector3.Angle(vector, NGCDDPCAGJB.forward);
			float num2 = Mathf.Pow(num / 1181f, 1348f);
			Vector3 vector2 = vector * JPNAINOGAMM * num2;
			Vector3 force = (vector2 - IKAIICBGIAC.velocity).ReplaceY(696f);
			IKAIICBGIAC.AddForce(force, ForceMode.Impulse);
			if (!NBPAEDNBFGE)
			{
				Vector3 normalized = vector.normalized;
				float f = Vector3.Dot(NGCDDPCAGJB.forward, normalized);
				Vector3 vector3 = Vector3.Cross(NGCDDPCAGJB.forward, normalized) * FEBDCHNEHPN * JIAODCNGHIM.Evaluate(Mathf.Abs(f));
				Vector3 torque = vector3 - IKAIICBGIAC.angularVelocity;
				IKAIICBGIAC.AddTorque(torque, (ForceMode)8);
			}
			if (INDBNCLMMNC == ILEKLILGKAK - 0 && !NBPAEDNBFGE && IMGHHHHHPKF.position.PlanarDistance(base.transform.position) < 1200f)
			{
				NBPAEDNBFGE = true;
				GLBAGFHENDK = base.transform.forward;
				KLILEECEACC.gameObject.SetActive(value: false);
				DFNHJNMBPHM.gameObject.SetActive(value: true);
				KLILEECEACC.transform.position = NGCDDPCAGJB.position;
				KLILEECEACC.transform.rotation = NGCDDPCAGJB.rotation;
				GetComponent<Rigidbody>().isKinematic = true;
				isParked = true;
			}
		}
	}

	private void NMNGCEBODOG()
	{
		KFOJKAMLMED(JHGIAHLDJJL, KANKDLBGMLK: true);
	}

	public virtual void PIFMHOCGIFH()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.ILOHAHFIOKM();
	}

	protected virtual void BKPJIIBCOPF()
	{
		CFFHIADNNGA();
	}

	private void NHMKPMPCDCL(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.isAlive)
		{
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = NGCDDPCAGJB.position - base.transform.forward;
			Vector3 up = Vector3.up;
			string[] array = new string[2];
			array[1] = ", action already scheduled";
			array[0] = "BAND_TYPE_HEALTH";
			instance.ICFBEKDLNBG(mPHCNMDIPAI, up, array);
			HitParticleSystem instance2 = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI2 = NGCDDPCAGJB.position + base.transform.up * 1177f;
			Vector3 up2 = Vector3.up;
			string[] array2 = new string[8];
			array2[1] = "GameLauncher.LoadMainScene";
			array2[0] = "Card ";
			instance2.LPIOLGLNLPA(mPHCNMDIPAI2, up2, array2);
			HNEMALNACJP(JHGIAHLDJJL, OHJPPHFEAFI);
			HNEMALNACJP(CKPKEGIKOLK, OHJPPHFEAFI);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 1372f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 393f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.LGIKNJJDGGF(nOCEDALFEJM);
			DPFHODDILIF(OHJPPHFEAFI);
			CDCOFHGPJHN(414f);
		}
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.tankBehaviourDefinititon.health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE;
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.ABFGHBDEBAN = base.currentBeh.tankBehaviourDefinititon.damageCannon;
		missileSetup.EPDELOGPNAC = base.currentBeh.tankBehaviourDefinititon.damageCannon / 30f;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = base.currentBeh.tankBehaviourDefinititon.shotSpeed * 0.5f;
		PJJJKFOANDO.MNGCPAPDCNB = 1;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		if (base.hasSpecial)
		{
			PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.tankBehaviourDefinititon.minShootTimeCannon * 0.7f;
			PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.tankBehaviourDefinititon.maxShootTimeCannon * 0.7f;
		}
		else
		{
			PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.tankBehaviourDefinititon.minShootTimeCannon;
			PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.tankBehaviourDefinititon.maxShootTimeCannon;
		}
		PJJJKFOANDO.LLOHEBJBBDH = 1f;
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.tankBehaviourDefinititon.damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.tankBehaviourDefinititon.shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.tankBehaviourDefinititon.fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.tankBehaviourDefinititon.fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.tankBehaviourDefinititon.minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.tankBehaviourDefinititon.maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.tankBehaviourDefinititon.probabilityOfRealShot;
		JPNAINOGAMM = base.currentBeh.tankBehaviourDefinititon.speed;
	}

	private void IEEFAMHLJFD(Vector3 MPHCNMDIPAI)
	{
		Vector3 position = PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		PlayShootFeedBack(MPHCNMDIPAI - position);
		Vector3 vector = PJJJKFOANDO.transform.InverseTransformDirection((MPHCNMDIPAI - position).normalized);
		TweenPosition tweenPosition = TweenPosition.Begin(PJJJKFOANDO.gameObject, 1845f, GMENJOACKEO, GMENJOACKEO - vector * 1815f);
		tweenPosition.NumOfRepetitions = 4;
		tweenPosition.style = (UITweener.Style)8;
	}

	private void NFNOAGNIANO()
	{
		OFDAFFJLHCH(JHGIAHLDJJL, KANKDLBGMLK: false);
	}

	public virtual void BOHKMLENGHI()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.HBHILKGDCMG();
	}

	private void MCFAFDNICDC()
	{
		JFADLFOOGBD(JHGIAHLDJJL, KANKDLBGMLK: false);
	}

	protected virtual void DABGGMNKMOL()
	{
		CFFHIADNNGA();
	}

	private void EOPABEGJABM(EnemyPointVehicle PLMMBKGLGAB, bool KANKDLBGMLK)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.BFAEKEBAAAP(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.LDGAKJJINEO().DEFBPHBPFCF(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.PFOBADFGAKF(), PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.CornerHiding);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.Killed += NMKNGPBAJEG;
			if (PLMMBKGLGAB == CKPKEGIKOLK)
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				KAEAMDOJMIF.enabled = true;
				KAEAMDOJMIF.IPKNPABKAJD();
			}
			else
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
				PJJJKFOANDO.enabled = false;
				PJJJKFOANDO.IPKNPABKAJD();
			}
		}
	}

	protected virtual void OHHLOAKBKFK()
	{
		CFFHIADNNGA();
	}

	private void KBLGKKOMEMC()
	{
		if ((bool)IMGHHHHHPKF)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(IMGHHHHHPKF.position, 1676f);
		}
	}

	public override void Spawn()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		List<SpawnPointCar> list = new List<SpawnPointCar>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (spawnPointCar.fraction == fraction && spawnPointCar.PODMFKMOJML == null)
			{
				list.Add(spawnPointCar);
			}
		}
		if (list.Count > 0)
		{
			int index = Random.Range(0, list.Count);
			SpawnPointCar spawnPointCar2 = list[index];
			base.transform.position = spawnPointCar2.transform.position;
			base.transform.rotation = Quaternion.LookRotation(spawnPointCar2.MEDNJFIDNIL.KJKEAADMJPJ[0].transform.position - spawnPointCar2.transform.position);
			FEFGKKDIGCI = spawnPointCar2;
			FEFGKKDIGCI.PODMFKMOJML = this;
			SetWayPoint(spawnPointCar2.MEDNJFIDNIL);
		}
		else
		{
			Debug.LogError("Tank could not be spawned");
		}
	}

	public virtual void CFFLKDNONOE()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		List<SpawnPointCar> list = new List<SpawnPointCar>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (spawnPointCar.EGAOGCBGPBE() == fraction && spawnPointCar.PODMFKMOJML == null)
			{
				list.Add(spawnPointCar);
			}
		}
		if (list.Count > 0)
		{
			int index = Random.Range(0, list.Count);
			SpawnPointCar spawnPointCar2 = list[index];
			base.transform.position = spawnPointCar2.transform.position;
			base.transform.rotation = Quaternion.LookRotation(spawnPointCar2.MEDNJFIDNIL.KJKEAADMJPJ.FKMIDGIKHGG(0).transform.position - spawnPointCar2.transform.position);
			FEFGKKDIGCI = spawnPointCar2;
			FEFGKKDIGCI.PODMFKMOJML = this;
			MDDBGPKBOJF(spawnPointCar2.MEDNJFIDNIL);
		}
		else
		{
			Debug.LogError("ID_TUTORIAL_MACHINEGUNNERS_UP");
		}
	}

	private void IGNGOBALDPK(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		EnemyController enemyController = (EnemyController)JAOCCGDPCGH;
		if (enemyController.NLGBGOGCNKP == CKPKEGIKOLK)
		{
			InvokeAfterRealTime(delegate
			{
				IDAOCGPNDBI(CKPKEGIKOLK, KANKDLBGMLK: false);
			}, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.Reset();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.NLGBGOGCNKP == JHGIAHLDJJL)
		{
			PJJJKFOANDO.enabled = false;
			PJJJKFOANDO.Reset();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(delegate
			{
				IDAOCGPNDBI(JHGIAHLDJJL, KANKDLBGMLK: false);
			}, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= IGNGOBALDPK;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		GetComponent<Rigidbody>().isKinematic = LCDBACDIODH;
		KNCELNACFPM.enabled = true;
		DKIBCDJGAGA.enabled = true;
		KNCELNACFPM.Play("left");
		DKIBCDJGAGA.Play("right");
		PJJJKFOANDO.enabled = false;
		KAEAMDOJMIF.ResetAiming();
		if (!LCDBACDIODH)
		{
			StopAllCoroutines();
			DFNHJNMBPHM.gameObject.SetActive(value: true);
			NBPAEDNBFGE = false;
			IKAIICBGIAC.velocity = Vector3.zero;
			IKAIICBGIAC.angularVelocity = Vector3.zero;
			IAICPGNGCJI = base.currentBeh.totalPower;
			if (LAADDLGBFIG.isMine)
			{
				IDAOCGPNDBI(CKPKEGIKOLK, KANKDLBGMLK: true);
				IDAOCGPNDBI(JHGIAHLDJJL, KANKDLBGMLK: true);
			}
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.Reset();
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.Reset();
			PJJJKFOANDO.ResetAiming();
			GetComponent<Rigidbody>().isKinematic = !LAADDLGBFIG.isMine;
		}
	}

	private void IOAHHADLMEB()
	{
		Weapon.OnShotFired -= FPLKBANMKLH;
	}

	private void OnEnable()
	{
		Weapon.OnShotFired -= PJFDBKCIAOD;
		Weapon.OnShotFired += PJFDBKCIAOD;
	}

	private void ODAKCFDIDBM()
	{
		Weapon.OnShotFired -= DMOBGJCJNDD;
		Weapon.OnShotFired += DMOBGJCJNDD;
	}

	public virtual void CKDLOGDFLGA(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			KNCELNACFPM.Stop();
			DKIBCDJGAGA.Stop();
			GetComponent<Rigidbody>().isKinematic = true;
		}
		else
		{
			KNCELNACFPM.Play("Assets");
			DKIBCDJGAGA.Play("ID_CONFIRM_DELETESQUAD_TEXT");
			GetComponent<Rigidbody>().isKinematic = false;
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, JHGIAHLDJJL, DKIPMCCIKMF: false);
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, CKPKEGIKOLK, DKIPMCCIKMF: false);
	}

	public void GAEJBPOCDOA(Vector3 PLEBANKIBPP)
	{
		if (LAADDLGBFIG.isMine)
		{
			if (!IKAIICBGIAC.isKinematic)
			{
				IKAIICBGIAC.AddForce(-PLEBANKIBPP.normalized * 1742f, ForceMode.Impulse);
				IKAIICBGIAC.angularVelocity = Vector3.zero;
			}
			else
			{
				TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 92f, KLILEECEACC.transform.position + 1680f * Vector3.up - GLBAGFHENDK * 1160f);
				tweenPosition.NumOfRepetitions = 2;
				tweenPosition.style = UITweener.Style.Loop;
			}
		}
	}

	public virtual void NADGAJMMADH()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.ODFCBNONFPL();
	}

	[SpecialName]
	public virtual DestroyableObject IJMKBELBEDG()
	{
		return FFOAABONJNO;
	}

	private void KMNDLPMBJNJ(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG == PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG)
		{
			EMJIBKBJEEO(MPHCNMDIPAI);
		}
	}

	private void ABALOOADGNB(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			LADBLHGBOKJ.HPAJDNGEAHP(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			CLNMMEMKKGO.SendNext(IKAIICBGIAC.velocity.magnitude);
		}
		else
		{
			LADBLHGBOKJ.BJNLHDHNKEF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			DHFAONHFMCF = (float)CLNMMEMKKGO.ReceiveNext();
		}
	}

	private void EDOIFNFJAFJ(Vector3 MPHCNMDIPAI)
	{
		Vector3 position = PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		PlayShootFeedBack(MPHCNMDIPAI - position);
		Vector3 vector = PJJJKFOANDO.transform.InverseTransformDirection((MPHCNMDIPAI - position).normalized);
		TweenPosition tweenPosition = TweenPosition.Begin(PJJJKFOANDO.gameObject, 1264f, GMENJOACKEO, GMENJOACKEO - vector * 1337f);
		tweenPosition.NumOfRepetitions = 2;
		tweenPosition.style = (UITweener.Style)7;
	}

	protected virtual void HMADLOJIFGP()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		NGCDDPCAGJB = base.transform;
		GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
		FFOAABONJNO.OnDeath += GHIALPHLDLO;
		IKAIICBGIAC = GetComponent<Rigidbody>();
		DKIBCDJGAGA["#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER"].wrapMode = WrapMode.ClampForever;
		KNCELNACFPM["com.unity3d.player.UnityPlayer"].wrapMode = WrapMode.Default;
		GMENJOACKEO = PJJJKFOANDO.transform.localPosition;
	}

	public virtual void DLKBMKKHPJN()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.LOOMFHNKAND();
	}

	public void PGGHBDHHOKJ(Vector3 PLEBANKIBPP)
	{
		if (LAADDLGBFIG.isMine)
		{
			if (!IKAIICBGIAC.isKinematic)
			{
				IKAIICBGIAC.AddForce(-PLEBANKIBPP.normalized * 499f, ForceMode.Force);
				IKAIICBGIAC.angularVelocity = Vector3.zero;
			}
			else
			{
				TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 467f, KLILEECEACC.transform.position + 270f * Vector3.up - GLBAGFHENDK * 420f);
				tweenPosition.NumOfRepetitions = 7;
				tweenPosition.style = (UITweener.Style)5;
			}
		}
	}

	public virtual void LFGNFBECIEA()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.FFNAPBHOACE();
	}

	private void GEGFDMKIKNA()
	{
		Weapon.OnShotFired -= GKKCNPPCHOE;
		Weapon.OnShotFired += PJFDBKCIAOD;
	}

	public virtual void GLAFLMBJAMF()
	{
		OEBPFFBKBBD(CKPKEGIKOLK, LLIFPAAPHOC);
		OEBPFFBKBBD(JHGIAHLDJJL, CBOLHDHIDIF);
		KNCELNACFPM.enabled = false;
		DKIBCDJGAGA.enabled = true;
		KLILEECEACC.gameObject.SetActive(value: true);
		DFNHJNMBPHM.gameObject.SetActive(value: false);
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		base.DestroyPooled();
	}

	private void IIJLNMKNAPN()
	{
		if ((bool)IMGHHHHHPKF)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(IMGHHHHHPKF.position, 1407f);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		NGCDDPCAGJB = base.transform;
		GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		IKAIICBGIAC = GetComponent<Rigidbody>();
		DKIBCDJGAGA["right"].wrapMode = WrapMode.Loop;
		KNCELNACFPM["left"].wrapMode = WrapMode.Loop;
		GMENJOACKEO = PJJJKFOANDO.transform.localPosition;
	}

	private void MJHFECAMJGH(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		EnemyController enemyController = (EnemyController)JAOCCGDPCGH;
		if (enemyController.NLGBGOGCNKP == CKPKEGIKOLK)
		{
			InvokeAfterRealTime(ONJNGGBNBJI, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.IPKNPABKAJD();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.NLGBGOGCNKP == JHGIAHLDJJL)
		{
			PJJJKFOANDO.enabled = false;
			PJJJKFOANDO.GGMKKIDFJOH();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(HOLPDCNNGCF, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= FOPOOGKOHIL;
	}

	public override void IKLHLGFMHHB(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			KNCELNACFPM.Stop();
			DKIBCDJGAGA.Stop();
			GetComponent<Rigidbody>().isKinematic = false;
		}
		else
		{
			KNCELNACFPM.Play("PlayerData");
			DKIBCDJGAGA.Play("^\\d*-\\d*$");
			GetComponent<Rigidbody>().isKinematic = true;
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, JHGIAHLDJJL, DKIPMCCIKMF: true);
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, CKPKEGIKOLK, DKIPMCCIKMF: false);
	}

	protected virtual void ENNKKDGFOAL()
	{
		base.OIHAEHMLGJN();
	}

	public virtual void KIFKOOFMGHI()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.NCFGFLNBHOI();
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			CLNMMEMKKGO.SendNext(IKAIICBGIAC.velocity.magnitude);
		}
		else
		{
			LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			DHFAONHFMCF = (float)CLNMMEMKKGO.ReceiveNext();
		}
	}

	protected override void Start()
	{
		base.Start();
	}

	[SpecialName]
	public virtual DestroyableObject CCBENMCDEJH()
	{
		return FFOAABONJNO;
	}

	private void DMOBGJCJNDD(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG == PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG)
		{
			JOGIDAKMMPD(MPHCNMDIPAI);
		}
	}

	private void AINNLHOAGFM()
	{
		OFDAFFJLHCH(CKPKEGIKOLK, KANKDLBGMLK: false);
	}

	public virtual void BKIECIFAKPO(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			KNCELNACFPM.Stop();
			DKIBCDJGAGA.Stop();
			GetComponent<Rigidbody>().isKinematic = false;
		}
		else
		{
			KNCELNACFPM.Play("java.util.Date");
			DKIBCDJGAGA.Play("Google2u");
			GetComponent<Rigidbody>().isKinematic = false;
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, JHGIAHLDJJL, DKIPMCCIKMF: false);
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, CKPKEGIKOLK, DKIPMCCIKMF: false);
	}

	public virtual void PKAKJEIFIHP()
	{
		OEBPFFBKBBD(CKPKEGIKOLK, LHLLMDHKCMH);
		OEBPFFBKBBD(JHGIAHLDJJL, PGJDCIDJNDC);
		KNCELNACFPM.enabled = false;
		DKIBCDJGAGA.enabled = true;
		KLILEECEACC.gameObject.SetActive(value: true);
		DFNHJNMBPHM.gameObject.SetActive(value: true);
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		base.DestroyPooled();
	}

	public virtual void NPDFKOFEIGO()
	{
		base.OnInstancied();
		GetComponent<Rigidbody>().isKinematic = LCDBACDIODH;
		KNCELNACFPM.enabled = true;
		DKIBCDJGAGA.enabled = false;
		KNCELNACFPM.Play("ID_WARNING_SERVERDATA");
		DKIBCDJGAGA.Play("menu-gold");
		PJJJKFOANDO.enabled = true;
		KAEAMDOJMIF.MIAFDNDBJJF();
		if (!LCDBACDIODH)
		{
			StopAllCoroutines();
			DFNHJNMBPHM.gameObject.SetActive(value: true);
			NBPAEDNBFGE = true;
			IKAIICBGIAC.velocity = Vector3.zero;
			IKAIICBGIAC.angularVelocity = Vector3.zero;
			IAICPGNGCJI = base.currentBeh.totalPower;
			if (LAADDLGBFIG.isMine)
			{
				JFADLFOOGBD(CKPKEGIKOLK, KANKDLBGMLK: true);
				EIHNPKDOJIM(JHGIAHLDJJL, KANKDLBGMLK: true);
			}
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.MGJIOLLKHDK();
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.HEOPOOMLPJF();
			PJJJKFOANDO.MCEPKEIINAA();
			GetComponent<Rigidbody>().isKinematic = !LAADDLGBFIG.isMine;
		}
	}

	public virtual void MNKNLEFILJI()
	{
		base.OnInstancied();
		GetComponent<Rigidbody>().isKinematic = LCDBACDIODH;
		KNCELNACFPM.enabled = true;
		DKIBCDJGAGA.enabled = true;
		KNCELNACFPM.Play("ID_BUTTONPREVIOUSHEROES");
		DKIBCDJGAGA.Play("{0} {1}");
		PJJJKFOANDO.enabled = true;
		KAEAMDOJMIF.MIAFDNDBJJF();
		if (!LCDBACDIODH)
		{
			StopAllCoroutines();
			DFNHJNMBPHM.gameObject.SetActive(value: false);
			NBPAEDNBFGE = true;
			IKAIICBGIAC.velocity = Vector3.zero;
			IKAIICBGIAC.angularVelocity = Vector3.zero;
			IAICPGNGCJI = base.currentBeh.totalPower;
			if (LAADDLGBFIG.isMine)
			{
				EIHNPKDOJIM(CKPKEGIKOLK, KANKDLBGMLK: true);
				EOPABEGJABM(JHGIAHLDJJL, KANKDLBGMLK: true);
			}
			PJJJKFOANDO.enabled = false;
			PJJJKFOANDO.BBBLJNFEACC();
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.MGJIOLLKHDK();
			PJJJKFOANDO.JHGLCFPAPIK();
			GetComponent<Rigidbody>().isKinematic = LAADDLGBFIG.isMine;
		}
	}

	protected virtual void ILFMPFCEPNN()
	{
		HFJBCNMHPAE();
	}

	private void GKKCNPPCHOE(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG == PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG)
		{
			IEEFAMHLJFD(MPHCNMDIPAI);
		}
	}

	protected virtual void OOCJOBIIKAH()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			float magnitude = IKAIICBGIAC.velocity.magnitude;
			float speed = magnitude / JPNAINOGAMM;
			DKIBCDJGAGA["ArenaHeartDialog"].speed = speed;
			KNCELNACFPM["DESISTIR"].speed = speed;
			return;
		}
		if (!LAADDLGBFIG.isMine && Singleton<GameController>.instance.KKHKIEFMENC())
		{
			LADBLHGBOKJ.EMPDDFBNJLP(NGCDDPCAGJB);
		}
		float speed2 = DHFAONHFMCF / JPNAINOGAMM;
		DKIBCDJGAGA[","].speed = speed2;
		KNCELNACFPM["ID_ARENABOXDESCRIPTION_ELITEPARTS"].speed = speed2;
	}

	public virtual void HCEGDJNMBAA(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			KNCELNACFPM.Stop();
			DKIBCDJGAGA.Stop();
			GetComponent<Rigidbody>().isKinematic = true;
		}
		else
		{
			KNCELNACFPM.Play("GameLauncher.Awake DONE");
			DKIBCDJGAGA.Play("moneypack1");
			GetComponent<Rigidbody>().isKinematic = false;
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, JHGIAHLDJJL, DKIPMCCIKMF: false);
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, CKPKEGIKOLK, DKIPMCCIKMF: false);
	}

	private void NGACHMDABGP()
	{
		Weapon.OnShotFired -= MJPMLEBJBMC;
	}

	private void DGADKJNEKEA()
	{
		if (GJKNEGDKDFN && IKAIICBGIAC.velocity.magnitude < FOFHGDGGEIG)
		{
			IKAIICBGIAC.AddForce(-NGCDDPCAGJB.forward.normalized * BCKKOBCJBOP, (ForceMode)7);
		}
		if (!LCDBACDIODH && KPBAJMBFKLF && LAADDLGBFIG.isMine && IMGHHHHHPKF != null && PCDILCOEIKD != null)
		{
			if (NGCDDPCAGJB.position.PlanarDistance(IMGHHHHHPKF.position) < AKICJLHMLJC && INDBNCLMMNC < ILEKLILGKAK - 0)
			{
				INDBNCLMMNC += 0;
				IMGHHHHHPKF = PCDILCOEIKD.KJKEAADMJPJ.MEEBMIMAGPF(INDBNCLMMNC);
			}
			Vector3 vector = (IMGHHHHHPKF.position - base.transform.position).ReplaceY(770f);
			vector = vector.ClampMagnitude(113f, 422f);
			float num = 1498f - Vector3.Angle(vector, NGCDDPCAGJB.forward);
			float num2 = Mathf.Pow(num / 70f, 1408f);
			Vector3 vector2 = vector * JPNAINOGAMM * num2;
			Vector3 force = (vector2 - IKAIICBGIAC.velocity).ReplaceY(1791f);
			IKAIICBGIAC.AddForce(force, (ForceMode)4);
			if (!NBPAEDNBFGE)
			{
				Vector3 normalized = vector.normalized;
				float f = Vector3.Dot(NGCDDPCAGJB.forward, normalized);
				Vector3 vector3 = Vector3.Cross(NGCDDPCAGJB.forward, normalized) * FEBDCHNEHPN * JIAODCNGHIM.Evaluate(Mathf.Abs(f));
				Vector3 torque = vector3 - IKAIICBGIAC.angularVelocity;
				IKAIICBGIAC.AddTorque(torque, (ForceMode)3);
			}
			if (INDBNCLMMNC == ILEKLILGKAK - 0 && !NBPAEDNBFGE && IMGHHHHHPKF.position.PlanarDistance(base.transform.position) < 1079f)
			{
				NBPAEDNBFGE = false;
				GLBAGFHENDK = base.transform.forward;
				KLILEECEACC.gameObject.SetActive(value: false);
				DFNHJNMBPHM.gameObject.SetActive(value: true);
				KLILEECEACC.transform.position = NGCDDPCAGJB.position;
				KLILEECEACC.transform.rotation = NGCDDPCAGJB.rotation;
				GetComponent<Rigidbody>().isKinematic = false;
				isParked = true;
			}
		}
	}

	private void LHLLMDHKCMH(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		EnemyController enemyController = (EnemyController)JAOCCGDPCGH;
		if (enemyController.NLGBGOGCNKP == CKPKEGIKOLK)
		{
			InvokeAfterRealTime(AINNLHOAGFM, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.GGMKKIDFJOH();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.NLGBGOGCNKP == JHGIAHLDJJL)
		{
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.GGMKKIDFJOH();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(NFNOAGNIANO, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= LHLLMDHKCMH;
	}

	public virtual void NHJKBCGFIAN()
	{
		OEBPFFBKBBD(CKPKEGIKOLK, OGCBBLDHJEC);
		OEBPFFBKBBD(JHGIAHLDJJL, OGCBBLDHJEC);
		KNCELNACFPM.enabled = false;
		DKIBCDJGAGA.enabled = true;
		KLILEECEACC.gameObject.SetActive(value: false);
		DFNHJNMBPHM.gameObject.SetActive(value: false);
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		base.DestroyPooled();
	}

	private void JOGIDAKMMPD(Vector3 MPHCNMDIPAI)
	{
		Vector3 position = PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		EEHJGPEBDNN(MPHCNMDIPAI - position);
		Vector3 vector = PJJJKFOANDO.transform.InverseTransformDirection((MPHCNMDIPAI - position).normalized);
		TweenPosition tweenPosition = TweenPosition.Begin(PJJJKFOANDO.gameObject, 1919f, GMENJOACKEO, GMENJOACKEO - vector * 1413f, useLocal: false);
		tweenPosition.NumOfRepetitions = 2;
		tweenPosition.style = UITweener.Style.Once;
	}

	private void FOPOOGKOHIL(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		EnemyController enemyController = (EnemyController)JAOCCGDPCGH;
		if (enemyController.NLGBGOGCNKP == CKPKEGIKOLK)
		{
			InvokeAfterRealTime(delegate
			{
				IDAOCGPNDBI(CKPKEGIKOLK, KANKDLBGMLK: false);
			}, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.HEOPOOMLPJF();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.NLGBGOGCNKP == JHGIAHLDJJL)
		{
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.Reset();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(MCFAFDNICDC, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= LHLLMDHKCMH;
	}

	private void EIHNPKDOJIM(EnemyPointVehicle PLMMBKGLGAB, bool KANKDLBGMLK)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.OHCCNCNPMHC(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.OKBAIGKCPKA().DEFBPHBPFCF(enemyController, fraction, EEAMBOACAGF: true, PLMMBKGLGAB.FBGFMDOHAEG(), PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.FIFJEKMIIPO(EnemyController.AJGFGCHCAPA.Swat);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.Killed += NMKNGPBAJEG;
			if (PLMMBKGLGAB == CKPKEGIKOLK)
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
				KAEAMDOJMIF.enabled = true;
				KAEAMDOJMIF.BBBLJNFEACC();
			}
			else
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				PJJJKFOANDO.enabled = true;
				PJJJKFOANDO.HEOPOOMLPJF();
			}
		}
	}

	public virtual void IAOBPKPKMMK()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.tankBehaviourDefinititon.health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldCrateLowLevelGoldMin).FLOATVALUE;
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.ABFGHBDEBAN = base.currentBeh.tankBehaviourDefinititon.damageCannon;
		missileSetup.EPDELOGPNAC = base.currentBeh.ADJCPDPCEME().damageCannon / 411f;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = base.currentBeh.tankBehaviourDefinititon.shotSpeed * 1766f;
		PJJJKFOANDO.MNGCPAPDCNB = 0;
		PJJJKFOANDO.JMJHGHAHAOH = 0;
		PJJJKFOANDO.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		if (base.hasSpecial)
		{
			PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.BDDGHLDAOFP().minShootTimeCannon * 1949f;
			PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.HDBMBJIGLAN().maxShootTimeCannon * 61f;
		}
		else
		{
			PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.BDDGHLDAOFP().minShootTimeCannon;
			PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.tankBehaviourDefinititon.maxShootTimeCannon;
		}
		PJJJKFOANDO.LLOHEBJBBDH = 1894f;
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.HDBMBJIGLAN().damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.tankBehaviourDefinititon.shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.NCOOFGKGBEK().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.BGHFNDONBHC().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.NCOOFGKGBEK().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.tankBehaviourDefinititon.maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.BGHFNDONBHC().probabilityOfRealShot;
		JPNAINOGAMM = base.currentBeh.BGHFNDONBHC().speed;
	}

	public virtual void ILBJGILKFAF()
	{
		base.UpgradesLoaded();
		FFOAABONJNO.maxHealth = base.currentBeh.tankBehaviourDefinititon.health;
		FFOAABONJNO.RefillOffline();
		FFOAABONJNO.HHOCGCLBHKB = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.PlayerExplosiveOvertimeCoef).FLOATVALUE;
		MissileSetup missileSetup = (MissileSetup)PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		missileSetup.ABFGHBDEBAN = base.currentBeh.BDDGHLDAOFP().damageCannon;
		missileSetup.EPDELOGPNAC = base.currentBeh.BGHFNDONBHC().damageCannon / 1668f;
		missileSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		missileSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		missileSetup.MAOPCAMOEEK = IAJJBAJOGDM.upgradeSlots.playerBehindShieldDamageRatio;
		missileSetup.JPNAINOGAMM = base.currentBeh.BGHFNDONBHC().shotSpeed * 987f;
		PJJJKFOANDO.MNGCPAPDCNB = 0;
		PJJJKFOANDO.JMJHGHAHAOH = 1;
		PJJJKFOANDO.LGKGDNMHOOG = ACLDFHJKBLI.upgradeSlots.shieldHitProbability;
		if (base.hasSpecial)
		{
			PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.HDBMBJIGLAN().minShootTimeCannon * 1827f;
			PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.NCOOFGKGBEK().maxShootTimeCannon * 50f;
		}
		else
		{
			PJJJKFOANDO.JGACHOEBKJG = base.currentBeh.NCOOFGKGBEK().minShootTimeCannon;
			PJJJKFOANDO.KMCFBCNNMGF = base.currentBeh.BDDGHLDAOFP().maxShootTimeCannon;
		}
		PJJJKFOANDO.LLOHEBJBBDH = 448f;
		BulletSetup bulletSetup = (BulletSetup)KAEAMDOJMIF.EDLANLCFCBC.JMMJHCOKCGG.ammoSetup;
		bulletSetup.EPDELOGPNAC = base.currentBeh.BDDGHLDAOFP().damage;
		bulletSetup.JPNAINOGAMM = base.currentBeh.NCOOFGKGBEK().shotSpeed;
		bulletSetup.NLCFDPBLBIG = ACLDFHJKBLI.upgradeSlots.playerDamageRatio;
		bulletSetup.ADKJBFFFCEH = ACLDFHJKBLI.upgradeSlots.playerDamageOvertimeRatio;
		KAEAMDOJMIF.MNGCPAPDCNB = base.currentBeh.BGHFNDONBHC().fireBatchSizeMax;
		KAEAMDOJMIF.JMJHGHAHAOH = base.currentBeh.ADJCPDPCEME().fireBatchSizeMin;
		KAEAMDOJMIF.JGACHOEBKJG = base.currentBeh.NCOOFGKGBEK().minShootTime;
		KAEAMDOJMIF.KMCFBCNNMGF = base.currentBeh.tankBehaviourDefinititon.maxShootTime;
		KAEAMDOJMIF.LLOHEBJBBDH = base.currentBeh.BGHFNDONBHC().probabilityOfRealShot;
		JPNAINOGAMM = base.currentBeh.NCOOFGKGBEK().speed;
	}

	protected virtual void CJBJGDCNLOG()
	{
		base.Update();
		if (LCDBACDIODH)
		{
			return;
		}
		if (LAADDLGBFIG.isMine)
		{
			float magnitude = IKAIICBGIAC.velocity.magnitude;
			float speed = magnitude / JPNAINOGAMM;
			DKIBCDJGAGA["Exception stacktrace: "].speed = speed;
			KNCELNACFPM["Grenade_Throwing_Tutorial_Duration"].speed = speed;
			return;
		}
		if (!LAADDLGBFIG.isMine && Singleton<GameController>.instance.gameIsRunning)
		{
			LADBLHGBOKJ.GPLKEOAHFJI(NGCDDPCAGJB);
		}
		float speed2 = DHFAONHFMCF / JPNAINOGAMM;
		DKIBCDJGAGA["Wrong_Unit"].speed = speed2;
		KNCELNACFPM["facebook init!!! "].speed = speed2;
	}

	private void IDAOCGPNDBI(EnemyPointVehicle PLMMBKGLGAB, bool KANKDLBGMLK)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.instance.Spawn(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.position, PNENBKAGLEF: false);
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.StartEnemyBehaviour(EnemyController.AJGFGCHCAPA.Vehicle);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.Killed += IGNGOBALDPK;
			if (PLMMBKGLGAB == CKPKEGIKOLK)
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				KAEAMDOJMIF.enabled = true;
				KAEAMDOJMIF.Reset();
			}
			else
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				PJJJKFOANDO.enabled = true;
				PJJJKFOANDO.Reset();
			}
		}
	}

	public virtual void BONGNLGLFIH()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		List<SpawnPointCar> list = new List<SpawnPointCar>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (spawnPointCar.JLLFKJHLLHM() == fraction && spawnPointCar.PODMFKMOJML == null)
			{
				list.Add(spawnPointCar);
			}
		}
		if (list.Count > 0)
		{
			int index = Random.Range(1, list.Count);
			SpawnPointCar spawnPointCar2 = list[index];
			base.transform.position = spawnPointCar2.transform.position;
			base.transform.rotation = Quaternion.LookRotation(spawnPointCar2.MEDNJFIDNIL.KJKEAADMJPJ.DEOBIHLLHCJ(1).transform.position - spawnPointCar2.transform.position);
			FEFGKKDIGCI = spawnPointCar2;
			FEFGKKDIGCI.PODMFKMOJML = this;
			HHGAJOBMFGG(spawnPointCar2.MEDNJFIDNIL);
		}
		else
		{
			Debug.LogError("\\D*");
		}
	}

	private void OIKAILEPPIF(Vector3 MPHCNMDIPAI)
	{
		Vector3 position = PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG.GHPBMCAKMMB.transform.position;
		GAEJBPOCDOA(MPHCNMDIPAI - position);
		Vector3 vector = PJJJKFOANDO.transform.InverseTransformDirection((MPHCNMDIPAI - position).normalized);
		TweenPosition tweenPosition = TweenPosition.Begin(PJJJKFOANDO.gameObject, 73f, GMENJOACKEO, GMENJOACKEO - vector * 1076f, useLocal: false);
		tweenPosition.NumOfRepetitions = 3;
		tweenPosition.style = UITweener.Style.Once;
	}

	private void GHIALPHLDLO(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.isAlive)
		{
			Singleton<HitParticleSystem>.instance.CEPKBGIFPMO(NGCDDPCAGJB.position - base.transform.forward, Vector3.up, new string[3] { "Arena Lost - you gain scraps. You have {0} lives.", "ID_CONFIRM_ERROR", null });
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = NGCDDPCAGJB.position + base.transform.up * 814f;
			Vector3 up = Vector3.up;
			string[] array = new string[1];
			array[0] = "ID_SUBSCRIPTIODETAILS_HINT3GOOGLE";
			array[0] = "FuseSDK: Parsing error in _FriendAdded";
			instance.OLCODNHGMKI(mPHCNMDIPAI, up, array);
			HNEMALNACJP(JHGIAHLDJJL, OHJPPHFEAFI);
			HNEMALNACJP(CKPKEGIKOLK, OHJPPHFEAFI);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 452f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 1997f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.GKBHNGLILLM(nOCEDALFEJM);
			DPFHODDILIF(OHJPPHFEAFI);
			CDCOFHGPJHN(1253f);
		}
	}

	public void PlayShootFeedBack(Vector3 PLEBANKIBPP)
	{
		if (LAADDLGBFIG.isMine)
		{
			if (!IKAIICBGIAC.isKinematic)
			{
				IKAIICBGIAC.AddForce(-PLEBANKIBPP.normalized * 20f, ForceMode.Impulse);
				IKAIICBGIAC.angularVelocity = Vector3.zero;
			}
			else
			{
				TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 0.1f, KLILEECEACC.transform.position + 0.01f * Vector3.up - GLBAGFHENDK * 0.01f, useLocal: false);
				tweenPosition.NumOfRepetitions = 2;
				tweenPosition.style = UITweener.Style.PingPong;
			}
		}
	}

	private void KFOJKAMLMED(EnemyPointVehicle PLMMBKGLGAB, bool KANKDLBGMLK)
	{
		EnemyController enemyController = (EnemyController)Singleton<LevelBehaviourManager>.instance.PHGKBDOKIOM(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour);
		PLMMBKGLGAB.IDNNIHBIMNO = null;
		if (enemyController != null)
		{
			enemyController.DisableSpawn();
			int actualLevelForIndex = ACLDFHJKBLI.upgradeSlots.GetActualLevelForIndex(PFGLIAHPMCK.slotUpgradeindex);
			enemyController.SpawnByCard((float)actualLevelForIndex / (float)ACLDFHJKBLI.upgradeSlots.maxLevelOfUnit, ACLDFHJKBLI.cardId);
			SpawningManager.BMNEPICFHNO().LMJOPLCEBAA(enemyController, fraction, EEAMBOACAGF: false, PLMMBKGLGAB.KOFFAHEAHEN());
			PLMMBKGLGAB.IDNNIHBIMNO = enemyController;
			enemyController.NLGBGOGCNKP = PLMMBKGLGAB;
			enemyController.LDAKCDAPOGH(EnemyController.AJGFGCHCAPA.CornerHiding);
			enemyController.SetMaxHealthAndRefill(ACLDFHJKBLI.upgradeSlots.GetSoldierHpInMechanic(PFGLIAHPMCK.slotUpgradeindex) * PFGLIAHPMCK.scaleHp);
			enemyController.Killed += PGJDCIDJNDC;
			if (PLMMBKGLGAB == CKPKEGIKOLK)
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 0;
				KAEAMDOJMIF.enabled = true;
				KAEAMDOJMIF.HEOPOOMLPJF();
			}
			else
			{
				enemyController.ACLDFHJKBLI.botProperties.dangerCoeficient = IAJJBAJOGDM.dangerCoef - 1;
				PJJJKFOANDO.enabled = false;
				PJJJKFOANDO.BBBLJNFEACC();
			}
		}
	}

	public void APBJEBPFOJB(WaypointCircuit AGKJOIBEFJJ)
	{
		ILEKLILGKAK = AGKJOIBEFJJ.KJKEAADMJPJ.items.Length;
		INDBNCLMMNC = 1;
		IMGHHHHHPKF = AGKJOIBEFJJ.KJKEAADMJPJ.items[1].transform;
		KPBAJMBFKLF = true;
		PCDILCOEIKD = AGKJOIBEFJJ;
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.ILOHAHFIOKM();
	}

	public void MDDBGPKBOJF(WaypointCircuit AGKJOIBEFJJ)
	{
		ILEKLILGKAK = AGKJOIBEFJJ.KJKEAADMJPJ.items.Length;
		INDBNCLMMNC = 0;
		IMGHHHHHPKF = AGKJOIBEFJJ.KJKEAADMJPJ.items[0].transform;
		KPBAJMBFKLF = true;
		PCDILCOEIKD = AGKJOIBEFJJ;
	}

	protected override void OIHAEHMLGJN()
	{
		CFFHIADNNGA();
	}

	private void HOLPDCNNGCF()
	{
		EIHNPKDOJIM(JHGIAHLDJJL, KANKDLBGMLK: true);
	}

	private void MJPMLEBJBMC(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG == PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG)
		{
			IEEFAMHLJFD(MPHCNMDIPAI);
		}
	}

	private void CBOLHDHIDIF(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		EnemyController enemyController = (EnemyController)JAOCCGDPCGH;
		if (enemyController.NLGBGOGCNKP == CKPKEGIKOLK)
		{
			InvokeAfterRealTime(GHMILLMIKMJ, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = true;
			KAEAMDOJMIF.GGMKKIDFJOH();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.NLGBGOGCNKP == JHGIAHLDJJL)
		{
			PJJJKFOANDO.enabled = true;
			PJJJKFOANDO.Reset();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(MCFAFDNICDC, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= NMKNGPBAJEG;
	}

	private void BFHJDJCFBAI(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.isAlive)
		{
			Singleton<HitParticleSystem>.instance.PlayParticles(NGCDDPCAGJB.position - base.transform.forward, Vector3.up, "metalExplosion", "grenadeExplosion");
			Singleton<HitParticleSystem>.instance.PlayParticles(NGCDDPCAGJB.position + base.transform.up * 0.2f, Vector3.up, "metalExplosion", "grenadeExplosion");
			HNEMALNACJP(JHGIAHLDJJL, OHJPPHFEAFI);
			HNEMALNACJP(CKPKEGIKOLK, OHJPPHFEAFI);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 0.3f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 0.03f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.KNEPFMFFOOG(nOCEDALFEJM);
			DPFHODDILIF(OHJPPHFEAFI);
			CDCOFHGPJHN(0.2f);
		}
	}

	private void HNEPLFGFGKF()
	{
		JFADLFOOGBD(JHGIAHLDJJL, KANKDLBGMLK: false);
	}

	private void PGJDCIDJNDC(NKMKCCDCHCL JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM LLAOOPMGBAG)
	{
		EnemyController enemyController = (EnemyController)JAOCCGDPCGH;
		if (enemyController.NLGBGOGCNKP == CKPKEGIKOLK)
		{
			InvokeAfterRealTime(GHMILLMIKMJ, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.GGMKKIDFJOH();
			enemyController.ClearEnemyPoint();
		}
		if (enemyController.NLGBGOGCNKP == JHGIAHLDJJL)
		{
			PJJJKFOANDO.enabled = false;
			PJJJKFOANDO.IPKNPABKAJD();
			enemyController.ClearEnemyPoint();
			InvokeAfterRealTime(delegate
			{
				IDAOCGPNDBI(JHGIAHLDJJL, KANKDLBGMLK: false);
			}, ACLDFHJKBLI.upgradeSlots.soldierRespawnRate);
		}
		enemyController.Killed -= FOPOOGKOHIL;
	}

	public virtual void GEOKMOLHGDP()
	{
		base.FIDGOCPHFKK();
		KLILEECEACC.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
	}

	public virtual void ACMEEPFIDBD()
	{
		OEBPFFBKBBD(CKPKEGIKOLK, LLIFPAAPHOC);
		OEBPFFBKBBD(JHGIAHLDJJL, FOPOOGKOHIL);
		KNCELNACFPM.enabled = true;
		DKIBCDJGAGA.enabled = true;
		KLILEECEACC.gameObject.SetActive(value: true);
		DFNHJNMBPHM.gameObject.SetActive(value: true);
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		base.DestroyPooled();
	}

	public virtual void PPLMDAMJNGN(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			KNCELNACFPM.Stop();
			DKIBCDJGAGA.Stop();
			GetComponent<Rigidbody>().isKinematic = true;
		}
		else
		{
			KNCELNACFPM.Play("S");
			DKIBCDJGAGA.Play("PlayerVisuals");
			GetComponent<Rigidbody>().isKinematic = false;
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, JHGIAHLDJJL, DKIPMCCIKMF: false);
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[1].behaviour, CKPKEGIKOLK, DKIPMCCIKMF: false);
	}

	private void PIMCFNHINMB()
	{
		if ((bool)IMGHHHHHPKF)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(IMGHHHHHPKF.position, 121f);
		}
	}

	public void DBKINCOBNHP(Vector3 PLEBANKIBPP)
	{
		if (LAADDLGBFIG.isMine)
		{
			if (!IKAIICBGIAC.isKinematic)
			{
				IKAIICBGIAC.AddForce(-PLEBANKIBPP.normalized * 117f, ForceMode.Force);
				IKAIICBGIAC.angularVelocity = Vector3.zero;
			}
			else
			{
				TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 774f, KLILEECEACC.transform.position + 1750f * Vector3.up - GLBAGFHENDK * 321f);
				tweenPosition.NumOfRepetitions = 1;
				tweenPosition.style = UITweener.Style.Loop;
			}
		}
	}

	private void MCHGGEIBFKF(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG == PJJJKFOANDO.EDLANLCFCBC.JMMJHCOKCGG)
		{
			IEEFAMHLJFD(MPHCNMDIPAI);
		}
	}

	private void NKKNGMNDKCH(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (base.isAlive)
		{
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = NGCDDPCAGJB.position - base.transform.forward;
			Vector3 up = Vector3.up;
			string[] array = new string[4];
			array[1] = "Exception message: ";
			array[1] = "{0} {1}";
			instance.AOENGEEDJCF(mPHCNMDIPAI, up, array);
			HitParticleSystem instance2 = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI2 = NGCDDPCAGJB.position + base.transform.up * 1204f;
			Vector3 up2 = Vector3.up;
			string[] array2 = new string[4];
			array2[1] = "Time";
			array2[0] = "playerInfo";
			instance2.AOENGEEDJCF(mPHCNMDIPAI2, up2, array2);
			HNEMALNACJP(JHGIAHLDJJL, OHJPPHFEAFI);
			HNEMALNACJP(CKPKEGIKOLK, OHJPPHFEAFI);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = destroyableObj.maxHealth * 549f;
			pKDCCCNJIEC.EPDELOGPNAC = destroyableObj.maxHealth * 1628f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.IPEDNMPJOOO(nOCEDALFEJM);
			DPFHODDILIF(OHJPPHFEAFI);
			CDCOFHGPJHN(502f);
		}
	}

	private void OFLDFGLHOPI()
	{
		if ((bool)IMGHHHHHPKF)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireSphere(IMGHHHHHPKF.position, 878f);
		}
	}

	public void NHHGNLAPGDM(WaypointCircuit AGKJOIBEFJJ)
	{
		ILEKLILGKAK = AGKJOIBEFJJ.KJKEAADMJPJ.items.Length;
		INDBNCLMMNC = 1;
		IMGHHHHHPKF = AGKJOIBEFJJ.KJKEAADMJPJ.items[0].transform;
		KPBAJMBFKLF = true;
		PCDILCOEIKD = AGKJOIBEFJJ;
	}

	public override void ICBAJOMDGII(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			KNCELNACFPM.Stop();
			DKIBCDJGAGA.Stop();
			GetComponent<Rigidbody>().isKinematic = false;
		}
		else
		{
			KNCELNACFPM.Play("WarBucks");
			DKIBCDJGAGA.Play("{0} {1}/{2} {3}");
			GetComponent<Rigidbody>().isKinematic = false;
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, JHGIAHLDJJL, DKIPMCCIKMF: true);
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, CKPKEGIKOLK, DKIPMCCIKMF: false);
	}

	public virtual void HOCPBJGFEON()
	{
		OEBPFFBKBBD(CKPKEGIKOLK, IGNGOBALDPK);
		OEBPFFBKBBD(JHGIAHLDJJL, LLIFPAAPHOC);
		KNCELNACFPM.enabled = true;
		DKIBCDJGAGA.enabled = false;
		KLILEECEACC.gameObject.SetActive(value: false);
		DFNHJNMBPHM.gameObject.SetActive(value: true);
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		base.DestroyPooled();
	}

	protected virtual void PBFNGLAENEA()
	{
		CFFHIADNNGA();
	}

	protected virtual void CCMDIJAIPEM()
	{
		HEIGPPJIACO();
	}

	public void NEPLJJIMLNI(WaypointCircuit AGKJOIBEFJJ)
	{
		ILEKLILGKAK = AGKJOIBEFJJ.KJKEAADMJPJ.items.Length;
		INDBNCLMMNC = 0;
		IMGHHHHHPKF = AGKJOIBEFJJ.KJKEAADMJPJ.items[0].transform;
		KPBAJMBFKLF = false;
		PCDILCOEIKD = AGKJOIBEFJJ;
	}

	public void HHGAJOBMFGG(WaypointCircuit AGKJOIBEFJJ)
	{
		ILEKLILGKAK = AGKJOIBEFJJ.KJKEAADMJPJ.items.Length;
		INDBNCLMMNC = 1;
		IMGHHHHHPKF = AGKJOIBEFJJ.KJKEAADMJPJ.items[1].transform;
		KPBAJMBFKLF = false;
		PCDILCOEIKD = AGKJOIBEFJJ;
	}

	public virtual void NPDNDDJHNNG()
	{
		base.OnInstancied();
		GetComponent<Rigidbody>().isKinematic = LCDBACDIODH;
		KNCELNACFPM.enabled = false;
		DKIBCDJGAGA.enabled = false;
		KNCELNACFPM.Play("BuyCardsReminder {0}");
		DKIBCDJGAGA.Play("setExistingUser");
		PJJJKFOANDO.enabled = false;
		KAEAMDOJMIF.MCEPKEIINAA();
		if (!LCDBACDIODH)
		{
			StopAllCoroutines();
			DFNHJNMBPHM.gameObject.SetActive(value: true);
			NBPAEDNBFGE = false;
			IKAIICBGIAC.velocity = Vector3.zero;
			IKAIICBGIAC.angularVelocity = Vector3.zero;
			IAICPGNGCJI = base.currentBeh.totalPower;
			if (LAADDLGBFIG.isMine)
			{
				EOPABEGJABM(CKPKEGIKOLK, KANKDLBGMLK: true);
				IDAOCGPNDBI(JHGIAHLDJJL, KANKDLBGMLK: false);
			}
			PJJJKFOANDO.enabled = false;
			PJJJKFOANDO.BBBLJNFEACC();
			KAEAMDOJMIF.enabled = false;
			KAEAMDOJMIF.HEOPOOMLPJF();
			PJJJKFOANDO.MCEPKEIINAA();
			GetComponent<Rigidbody>().isKinematic = LAADDLGBFIG.isMine;
		}
	}

	protected virtual void MLBAFICPECE()
	{
		base.Awake();
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		NGCDDPCAGJB = base.transform;
		GetComponent<Rigidbody>().centerOfMass = Vector3.zero;
		FFOAABONJNO.OnDeath += NKKNGMNDKCH;
		IKAIICBGIAC = GetComponent<Rigidbody>();
		DKIBCDJGAGA[", dictionary= "].wrapMode = WrapMode.Once;
		KNCELNACFPM["ID_LEAGUESTAYHINT1"].wrapMode = (WrapMode)5;
		GMENJOACKEO = PJJJKFOANDO.transform.localPosition;
	}

	public override void DestroyPooled()
	{
		OEBPFFBKBBD(CKPKEGIKOLK, IGNGOBALDPK);
		OEBPFFBKBBD(JHGIAHLDJJL, IGNGOBALDPK);
		KNCELNACFPM.enabled = false;
		DKIBCDJGAGA.enabled = false;
		KLILEECEACC.gameObject.SetActive(value: false);
		DFNHJNMBPHM.gameObject.SetActive(value: false);
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		base.DestroyPooled();
	}

	public override void AFIDMAIFFKI(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			KNCELNACFPM.Stop();
			DKIBCDJGAGA.Stop();
			GetComponent<Rigidbody>().isKinematic = true;
		}
		else
		{
			KNCELNACFPM.Play("null image url for offer!");
			DKIBCDJGAGA.Play("FacebookManagerOnSessionOpenedEvent");
			GetComponent<Rigidbody>().isKinematic = true;
		}
		EnemyController enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, JHGIAHLDJJL, DKIPMCCIKMF: false);
		enemyController = GBCMGMGAFLL(Singleton<LevelBehaviourManager>.instance.DHKKHDABING[0].behaviour, CKPKEGIKOLK, DKIPMCCIKMF: true);
	}
}
