using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CarController))]
public class AICarBase<T> : Vehicle<T> where T : LevelBehaviour
{
	public enum FFKHOHMOBHH
	{
		TargetDirectionDifference,
		Stop
	}

	[Range(0f, 1f)]
	[SerializeField]
	private float cautiousSpeedFactor = 0.05f;

	[Range(0f, 180f)]
	[SerializeField]
	private float cautiousMaxAngle = 50f;

	[SerializeField]
	private float cautiousMaxDistance = 100f;

	[SerializeField]
	private float cautiousAngularVelocityFactor = 30f;

	[SerializeField]
	private float steerSensitivity = 0.05f;

	[SerializeField]
	private float accelSensitivity = 0.04f;

	[SerializeField]
	private float brakeSensitivity = 1f;

	[SerializeField]
	protected FFKHOHMOBHH brakeCondition;

	[SerializeField]
	protected bool mDriving;

	[SerializeField]
	private Transform target;

	[SerializeField]
	private bool stopWhenTargetReached;

	[SerializeField]
	private float reachTargetThreshold = 2f;

	[FormerlySerializedAs("OGKBFFPFONJ")]
	public PhysicsEventsListener FBDIIPCGGEK;

	[FormerlySerializedAs("CLOLIKMJJKF")]
	public Transform OAEOAMJINDN;

	[FormerlySerializedAs("KLJDLOLEAMP")]
	public SpawnPointVehicle FEFGKKDIGCI;

	[FormerlySerializedAs("NCMLEKFLEJK")]
	public GameObject DOJCHKGNEHI;

	[FormerlySerializedAs("OFAPKIMNHPI")]
	public EnemyPointVehicle GHAGNCHNHEE;

	protected CarController EFPDLLPCGCB;

	private Rigidbody MBKLNBLNDGA;

	private float FNGIDOLHEGC;

	private float NBBMGJAMKPB;

	private float FFGDGCNLBCM;

	private float LKMPDLOJAOO;

	protected DestroyableObjectMultipleParts FFOAABONJNO;

	protected Transform NGCDDPCAGJB;

	protected Quaternion MENBEBHJCJP;

	private readonly LHMCMJDDOHI LADBLHGBOKJ = new LHMCMJDDOHI();

	private bool ABLNDFPPHFK;

	private float BNKPMIBDDFJ;

	public override DestroyableObject destroyableObj => FFOAABONJNO;

	public virtual void LLEOIKMLEPG()
	{
		base.FIDGOCPHFKK();
		DOJCHKGNEHI.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
	}

	protected virtual void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			CLNMMEMKKGO.SendNext(LKMPDLOJAOO);
			CLNMMEMKKGO.SendNext(FFGDGCNLBCM);
			CLNMMEMKKGO.SendNext((byte)fraction);
		}
		else
		{
			LADBLHGBOKJ.PAJFENKBCLF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			FNGIDOLHEGC = (float)CLNMMEMKKGO.ReceiveNext();
			NBBMGJAMKPB = (float)CLNMMEMKKGO.ReceiveNext();
			fraction = (GHPGNELIDBM)(byte)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public override void UpgradesLoaded()
	{
		base.UpgradesLoaded();
		CarController eFPDLLPCGCB = EFPDLLPCGCB;
		T val = base.currentBeh;
		eFPDLLPCGCB.MaxSpeed = val.behaviourDefinition.speed;
	}

	protected override void ODDDGIALOPM(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF: true);
		}
	}

	public virtual void LJDHLEINMLJ()
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
		int index = UnityEngine.Random.Range(1, list.Count);
		FEFGKKDIGCI = list[index];
		NGCDDPCAGJB.position = FEFGKKDIGCI.transform.position;
		MENBEBHJCJP = Quaternion.LookRotation(FEFGKKDIGCI.MEDNJFIDNIL.FMIAAEFAANH()[0].transform.position - FEFGKKDIGCI.transform.position);
		NGCDDPCAGJB.rotation = MENBEBHJCJP;
		FEFGKKDIGCI.PODMFKMOJML = this;
	}

	public virtual void KLIBIPPJOBB()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.ANOPOLIEBMC();
	}

	public virtual void OLKCNPIBHBN(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH, UpgradeSlots.UnitUpgrades KBBDGCLPOCJ, bool LGKBHPBDNFE, float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		base.ReSyncRPC(KFBOCCACLLK, FLJHPFJFJIN, OOMCGGAFJNH, KBBDGCLPOCJ, LGKBHPBDNFE, PAENPHMEMGC, ICDKHLOBKIE);
		LADBLHGBOKJ.NMEGMPHBNDG(PhotonNetwork.time, FLJHPFJFJIN, OOMCGGAFJNH);
	}

	public override void MEMHHNKDHKM(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			EFPDLLPCGCB.rigidBody.freezeRotation = true;
			EFPDLLPCGCB.rigidBody.velocity = Vector3.zero;
			EFPDLLPCGCB.rigidBody.isKinematic = true;
		}
	}

	public virtual void DOKNFFPIGFL(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			EFPDLLPCGCB.rigidBody.freezeRotation = true;
			EFPDLLPCGCB.rigidBody.velocity = Vector3.zero;
			EFPDLLPCGCB.rigidBody.isKinematic = false;
		}
	}

	private void OFMELHNPJDO()
	{
		if (LCDBACDIODH)
		{
			if (Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu)
			{
				EFPDLLPCGCB.Move(792f, 54f);
			}
			else if (GJKNEGDKDFN)
			{
				EFPDLLPCGCB.Move(466f, 512f);
			}
			else
			{
				EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: true);
			}
			return;
		}
		if (LAADDLGBFIG.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			BJKLFIHDKAP();
		}
		if (!LAADDLGBFIG.isMine && Singleton<PhotonConnectionManager>.instance.KKLAPJPNLIJ())
		{
			MBKLNBLNDGA.isKinematic = true;
			if (FNGIDOLHEGC > 696f)
			{
				EFPDLLPCGCB.Move(NBBMGJAMKPB, FNGIDOLHEGC);
			}
			else
			{
				EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: false);
			}
			if (Singleton<GameController>.instance.gameIsRunning)
			{
				LADBLHGBOKJ.JAFBNNAACCL(NGCDDPCAGJB);
			}
		}
	}

	public virtual void OJOKLNFIEIJ()
	{
		base.AFHLEHJNMMC();
		DOJCHKGNEHI.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
	}

	protected virtual void LMNEMMGCEFP()
	{
		base.Update();
	}

	private void CDMFDEGEMPA(Collider LCBINDJDAAN)
	{
		if (TagsAndLayers.IsDestroyableObject(LCBINDJDAAN.gameObject) && brakeCondition == FFKHOHMOBHH.TargetDirectionDifference)
		{
			DestroyableObjectpart component = LCBINDJDAAN.GetComponent<DestroyableObjectpart>();
			if (component != null)
			{
				ABLNDFPPHFK = true;
				BNKPMIBDDFJ = Time.time;
			}
		}
	}

	protected void BJLJIKAGOAD(float EBOLHJNMAIB, float BEHLMHJAICJ)
	{
		Wheel[] wheels = EFPDLLPCGCB.wheels;
		foreach (Wheel wheel in wheels)
		{
			JointSpring suspensionSpring = wheel.wheelCollider.suspensionSpring;
			suspensionSpring.targetPosition = EBOLHJNMAIB;
			suspensionSpring.spring = 151f;
			suspensionSpring.damper = 1412f;
			wheel.ONPNLGLHPMA().suspensionSpring = suspensionSpring;
			wheel.wheelCollider.suspensionDistance = BEHLMHJAICJ;
		}
	}

	public override void OLCGDMKDNDE()
	{
		base.OnInstancied();
		StopAllCoroutines();
		T val = base.currentBeh;
		IAICPGNGCJI = val.totalPower;
		mDriving = true;
		MBKLNBLNDGA.isKinematic = LCDBACDIODH;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		StopAllCoroutines();
		T val = base.currentBeh;
		IAICPGNGCJI = val.totalPower;
		mDriving = false;
		MBKLNBLNDGA.isKinematic = LCDBACDIODH;
	}

	public virtual void DNLMPCLKOBL()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		List<SpawnPointCar> list = new List<SpawnPointCar>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (spawnPointCar.GBMACONCODL() == fraction && spawnPointCar.PODMFKMOJML == null)
			{
				list.Add(spawnPointCar);
			}
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		FEFGKKDIGCI = list[index];
		NGCDDPCAGJB.position = FEFGKKDIGCI.transform.position;
		MENBEBHJCJP = Quaternion.LookRotation(FEFGKKDIGCI.MEDNJFIDNIL.Waypoints[1].transform.position - FEFGKKDIGCI.transform.position);
		NGCDDPCAGJB.rotation = MENBEBHJCJP;
		FEFGKKDIGCI.PODMFKMOJML = this;
	}

	private void CHBGBCPNBJA(Collider LCBINDJDAAN)
	{
		if (TagsAndLayers.IsDestroyableObject(LCBINDJDAAN.gameObject) && brakeCondition == FFKHOHMOBHH.TargetDirectionDifference)
		{
			DestroyableObjectpart component = LCBINDJDAAN.GetComponent<DestroyableObjectpart>();
			if (component != null)
			{
				ABLNDFPPHFK = true;
				BNKPMIBDDFJ = Time.time;
			}
		}
	}

	public virtual void KGKOGHNDMKF(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			EFPDLLPCGCB.rigidBody.freezeRotation = true;
			EFPDLLPCGCB.rigidBody.velocity = Vector3.zero;
			EFPDLLPCGCB.rigidBody.isKinematic = true;
		}
	}

	protected override void Update()
	{
		base.Update();
	}

	private void JHIDPGPHKBL()
	{
		if (LCDBACDIODH)
		{
			if (Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
			{
				EFPDLLPCGCB.Move(1155f, 345f);
			}
			else if (GJKNEGDKDFN)
			{
				EFPDLLPCGCB.Move(1780f, 1771f);
			}
			else
			{
				EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: false);
			}
			return;
		}
		if (LAADDLGBFIG.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			BJKLFIHDKAP();
		}
		if (!LAADDLGBFIG.isMine && Singleton<PhotonConnectionManager>.instance.GHIKMFDGIHB())
		{
			MBKLNBLNDGA.isKinematic = true;
			if (FNGIDOLHEGC > 515f)
			{
				EFPDLLPCGCB.Move(NBBMGJAMKPB, FNGIDOLHEGC);
			}
			else
			{
				EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: false);
			}
			if (Singleton<GameController>.instance.KKHKIEFMENC())
			{
				LADBLHGBOKJ.LIHOPIGNFFM(NGCDDPCAGJB);
			}
		}
	}

	private void GHCDMKGNFHJ(Collider LCBINDJDAAN)
	{
		if (TagsAndLayers.IsDestroyableObject(LCBINDJDAAN.gameObject) && brakeCondition == FFKHOHMOBHH.TargetDirectionDifference)
		{
			DestroyableObjectpart component = LCBINDJDAAN.GetComponent<DestroyableObjectpart>();
			if (component != null)
			{
				ABLNDFPPHFK = false;
				BNKPMIBDDFJ = Time.time;
			}
		}
	}

	public virtual void FCLPNJHMLPP()
	{
		base.AFHLEHJNMMC();
		DOJCHKGNEHI.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
	}

	protected void HJHAMCCJBIC(float EBOLHJNMAIB, float BEHLMHJAICJ)
	{
		Wheel[] wheels = EFPDLLPCGCB.wheels;
		for (int i = 1; i < wheels.Length; i++)
		{
			Wheel wheel = wheels[i];
			JointSpring suspensionSpring = wheel.ONPNLGLHPMA().suspensionSpring;
			suspensionSpring.targetPosition = EBOLHJNMAIB;
			suspensionSpring.spring = 382f;
			suspensionSpring.damper = 32f;
			wheel.ONPNLGLHPMA().suspensionSpring = suspensionSpring;
			wheel.ONPNLGLHPMA().suspensionDistance = BEHLMHJAICJ;
		}
	}

	private void NIJKMBOENCD(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = base.transform.position - base.transform.forward;
			Vector3 up = Vector3.up;
			string[] array = new string[5];
			array[1] = "warArenaCrown";
			array[1] = "TimeStamp";
			instance.MBJJMKPBMAL(mPHCNMDIPAI, up, array);
			HitParticleSystem instance2 = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI2 = base.transform.position + base.transform.up * 1066f;
			Vector3 up2 = Vector3.up;
			string[] array2 = new string[8];
			array2[1] = "ID_ROQUETRANSMISION";
			array2[0] = "ID_TUTORIAL_WELCOME_UP";
			instance2.CEPKBGIFPMO(mPHCNMDIPAI2, up2, array2);
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 872f;
			pKDCCCNJIEC.EPDELOGPNAC = 1665f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.FPLLKOJKLNI(nOCEDALFEJM);
			CDCOFHGPJHN(524f);
		}
	}

	public virtual void HBKICHPKIHA()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		List<SpawnPointCar> list = new List<SpawnPointCar>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (spawnPointCar.OBFMCBNEBHD() == fraction && spawnPointCar.PODMFKMOJML == null)
			{
				list.Add(spawnPointCar);
			}
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		FEFGKKDIGCI = list[index];
		NGCDDPCAGJB.position = FEFGKKDIGCI.transform.position;
		MENBEBHJCJP = Quaternion.LookRotation(FEFGKKDIGCI.MEDNJFIDNIL.Waypoints[1].transform.position - FEFGKKDIGCI.transform.position);
		NGCDDPCAGJB.rotation = MENBEBHJCJP;
		FEFGKKDIGCI.PODMFKMOJML = this;
	}

	protected override void Awake()
	{
		base.Awake();
		EFPDLLPCGCB = GetComponent<CarController>();
		MBKLNBLNDGA = GetComponent<Rigidbody>();
		PhysicsEventsListener fBDIIPCGGEK = FBDIIPCGGEK;
		fBDIIPCGGEK.onTriggerStay = (Action<Collider>)Delegate.Combine(fBDIIPCGGEK.onTriggerStay, new Action<Collider>(MEMEOFDCONI));
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		NGCDDPCAGJB = base.transform;
	}

	public virtual void NJHDCNDFMOK(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH, UpgradeSlots.UnitUpgrades KBBDGCLPOCJ, bool LGKBHPBDNFE, float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		base.ReSyncRPC(KFBOCCACLLK, FLJHPFJFJIN, OOMCGGAFJNH, KBBDGCLPOCJ, LGKBHPBDNFE, PAENPHMEMGC, ICDKHLOBKIE);
		LADBLHGBOKJ.LBKFBEAIAJN(PhotonNetwork.time, FLJHPFJFJIN, OOMCGGAFJNH);
	}

	protected void FAJKAOFMDNF(float EBOLHJNMAIB, float BEHLMHJAICJ)
	{
		Wheel[] wheels = EFPDLLPCGCB.wheels;
		foreach (Wheel wheel in wheels)
		{
			JointSpring suspensionSpring = wheel.wheelCollider.suspensionSpring;
			suspensionSpring.targetPosition = EBOLHJNMAIB;
			suspensionSpring.spring = 400f;
			suspensionSpring.damper = 9f;
			wheel.wheelCollider.suspensionSpring = suspensionSpring;
			wheel.wheelCollider.suspensionDistance = BEHLMHJAICJ;
		}
	}

	protected virtual void HOINLOMCGFD()
	{
		base.Awake();
		EFPDLLPCGCB = GetComponent<CarController>();
		MBKLNBLNDGA = GetComponent<Rigidbody>();
		PhysicsEventsListener fBDIIPCGGEK = FBDIIPCGGEK;
		fBDIIPCGGEK.onTriggerStay = (Action<Collider>)Delegate.Combine(fBDIIPCGGEK.onTriggerStay, new Action<Collider>(MEMEOFDCONI));
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		NGCDDPCAGJB = base.transform;
	}

	private void HOJJGFHEJBG(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			Singleton<HitParticleSystem>.instance.MBJJMKPBMAL(base.transform.position - base.transform.forward, Vector3.up, new string[8] { "\"{0}\"\t", "ID_ARENARULES_EXPLOSIVESPROHIBITED", null, null, null, null, null, null });
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = base.transform.position + base.transform.up * 520f;
			Vector3 up = Vector3.up;
			string[] array = new string[6];
			array[0] = "mortar_hide";
			array[0] = "PlayerName";
			instance.GCCJAMLPCDF(mPHCNMDIPAI, up, array);
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 1762f;
			pKDCCCNJIEC.EPDELOGPNAC = 1876f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.GBOABAFKMID(nOCEDALFEJM);
			CDCOFHGPJHN(552f);
		}
	}

	private void OGDOCNOJKJE(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = base.transform.position - base.transform.forward;
			Vector3 up = Vector3.up;
			string[] array = new string[8];
			array[1] = "FuseRewardedOptionKey_PostRollContinueButtonText";
			array[1] = "Get player data: NOT SENDING PN DEVICE TOKEN";
			instance.PNOBHBKJGBD(mPHCNMDIPAI, up, array);
			HitParticleSystem instance2 = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI2 = base.transform.position + base.transform.up * 967f;
			Vector3 up2 = Vector3.up;
			string[] array2 = new string[7];
			array2[1] = "ERROR WRONG DAILY REWARDS: ";
			array2[1] = "ID_ARENARULES_UNBREAKABLESHIELDS";
			instance2.PlayParticles(mPHCNMDIPAI2, up2, array2);
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 49f;
			pKDCCCNJIEC.EPDELOGPNAC = 643f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.IIDOGCHLCLO(nOCEDALFEJM);
			CDCOFHGPJHN(49f);
		}
	}

	public void SetTarget(WaypointCircuit FKLOKPBMOJJ, Transform KGPEPNNDPPA)
	{
		WaypointProgressTracker component = GetComponent<WaypointProgressTracker>();
		component.Reset();
		component.FKLOKPBMOJJ = FKLOKPBMOJJ;
		OAEOAMJINDN = KGPEPNNDPPA;
		mDriving = true;
		brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
	}

	private void MEMEOFDCONI(Collider LCBINDJDAAN)
	{
		if (TagsAndLayers.IsDestroyableObject(LCBINDJDAAN.gameObject) && brakeCondition == FFKHOHMOBHH.TargetDirectionDifference)
		{
			DestroyableObjectpart component = LCBINDJDAAN.GetComponent<DestroyableObjectpart>();
			if (component != null)
			{
				ABLNDFPPHFK = true;
				BNKPMIBDDFJ = Time.time;
			}
		}
	}

	private void FixedUpdate()
	{
		if (LCDBACDIODH)
		{
			if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
			{
				EFPDLLPCGCB.Move(0f, 0.1f);
			}
			else if (GJKNEGDKDFN)
			{
				EFPDLLPCGCB.Move(0f, -0.6f);
			}
			else
			{
				EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: true);
			}
			return;
		}
		if (LAADDLGBFIG.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			BJKLFIHDKAP();
		}
		if (!LAADDLGBFIG.isMine && Singleton<PhotonConnectionManager>.instance.isClient)
		{
			MBKLNBLNDGA.isKinematic = true;
			if (FNGIDOLHEGC > 0f)
			{
				EFPDLLPCGCB.Move(NBBMGJAMKPB, FNGIDOLHEGC);
			}
			else
			{
				EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: false);
			}
			if (Singleton<GameController>.instance.gameIsRunning)
			{
				LADBLHGBOKJ.NFGMGBMCNOF(NGCDDPCAGJB);
			}
		}
	}

	private void ABKKOCEHNJL(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = base.transform.position - base.transform.forward;
			Vector3 up = Vector3.up;
			string[] array = new string[1];
			array[0] = "Wrong_Category";
			array[0] = "{0} {1}.";
			instance.FGABGAGDHBP(mPHCNMDIPAI, up, array);
			HitParticleSystem instance2 = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI2 = base.transform.position + base.transform.up * 1151f;
			Vector3 up2 = Vector3.up;
			string[] array2 = new string[8];
			array2[0] = "Position";
			array2[0] = "com/google/android/gms/games/Games";
			instance2.PlayParticles(mPHCNMDIPAI2, up2, array2);
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 1753f;
			pKDCCCNJIEC.EPDELOGPNAC = 448f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.BMGBNPHGKGO(nOCEDALFEJM);
			CDCOFHGPJHN(1037f);
		}
	}

	public virtual void KNOLLMKHCNH()
	{
		base.OnInstancied();
		StopAllCoroutines();
		T val = base.currentBeh;
		IAICPGNGCJI = val.totalPower;
		mDriving = true;
		MBKLNBLNDGA.isKinematic = LCDBACDIODH;
	}

	[SpecialName]
	public virtual DestroyableObject AEPACIOHEGP()
	{
		return FFOAABONJNO;
	}

	public virtual void INNJHKEAFDD()
	{
		base.UpgradesLoaded();
		CarController eFPDLLPCGCB = EFPDLLPCGCB;
		T val = base.currentBeh;
		eFPDLLPCGCB.MaxSpeed = val.behaviourDefinition.speed;
	}

	public virtual void LPAEBNHHMDK(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH, UpgradeSlots.UnitUpgrades KBBDGCLPOCJ, bool LGKBHPBDNFE, float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		base.ReSyncRPC(KFBOCCACLLK, FLJHPFJFJIN, OOMCGGAFJNH, KBBDGCLPOCJ, LGKBHPBDNFE, PAENPHMEMGC, ICDKHLOBKIE);
		LADBLHGBOKJ.BLLFBNOJENJ(PhotonNetwork.time, FLJHPFJFJIN, OOMCGGAFJNH);
	}

	public override void FKAJMFAIMEM(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			EFPDLLPCGCB.rigidBody.freezeRotation = true;
			EFPDLLPCGCB.rigidBody.velocity = Vector3.zero;
			EFPDLLPCGCB.rigidBody.isKinematic = false;
		}
	}

	[SpecialName]
	public virtual DestroyableObject JLMNCJCKJDE()
	{
		return FFOAABONJNO;
	}

	private void DEPCKDNCFGF(Collider LCBINDJDAAN)
	{
		if (TagsAndLayers.IsDestroyableObject(LCBINDJDAAN.gameObject) && brakeCondition == FFKHOHMOBHH.TargetDirectionDifference)
		{
			DestroyableObjectpart component = LCBINDJDAAN.GetComponent<DestroyableObjectpart>();
			if (component != null)
			{
				ABLNDFPPHFK = true;
				BNKPMIBDDFJ = Time.time;
			}
		}
	}

	protected virtual void OEIGMJGNPPH(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			LADBLHGBOKJ.PCLNPDEAAJP(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			CLNMMEMKKGO.SendNext(LKMPDLOJAOO);
			CLNMMEMKKGO.SendNext(FFGDGCNLBCM);
			CLNMMEMKKGO.SendNext((byte)fraction);
		}
		else
		{
			LADBLHGBOKJ.JGJPNAGMNIO(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			FNGIDOLHEGC = (float)CLNMMEMKKGO.ReceiveNext();
			NBBMGJAMKPB = (float)CLNMMEMKKGO.ReceiveNext();
			fraction = (GHPGNELIDBM)(byte)CLNMMEMKKGO.ReceiveNext();
		}
	}

	protected void BECMIFCFNBG(float EBOLHJNMAIB, float BEHLMHJAICJ)
	{
		Wheel[] wheels = EFPDLLPCGCB.wheels;
		foreach (Wheel wheel in wheels)
		{
			JointSpring suspensionSpring = wheel.ONPNLGLHPMA().suspensionSpring;
			suspensionSpring.targetPosition = EBOLHJNMAIB;
			suspensionSpring.spring = 1105f;
			suspensionSpring.damper = 1341f;
			wheel.wheelCollider.suspensionSpring = suspensionSpring;
			wheel.wheelCollider.suspensionDistance = BEHLMHJAICJ;
		}
	}

	private void LNPDCGLGKJC(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			Singleton<HitParticleSystem>.instance.OFCPMLEBNHJ(base.transform.position - base.transform.forward, Vector3.up, new string[2] { "ID_VIP_BENEFITS2", "test_searchString" });
			Singleton<HitParticleSystem>.instance.GCCJAMLPCDF(base.transform.position + base.transform.up * 1380f, Vector3.up, new string[8] { "Assignment error: Skillshots not defined", "Create_Squad", null, null, null, null, null, null });
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 303f;
			pKDCCCNJIEC.EPDELOGPNAC = 406f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.LDCNCEMBBLN(nOCEDALFEJM);
			CDCOFHGPJHN(157f);
		}
	}

	public virtual void DDFDPKNEEFO()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.MPLPDIGFPBH();
	}

	public virtual void LFPBAOELIIL(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH, UpgradeSlots.UnitUpgrades KBBDGCLPOCJ, bool LGKBHPBDNFE, float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		base.ReSyncRPC(KFBOCCACLLK, FLJHPFJFJIN, OOMCGGAFJNH, KBBDGCLPOCJ, LGKBHPBDNFE, PAENPHMEMGC, ICDKHLOBKIE);
		LADBLHGBOKJ.JKPBOMKJPBA(PhotonNetwork.time, FLJHPFJFJIN, OOMCGGAFJNH);
	}

	protected void EDNMGCCHCKF(float EBOLHJNMAIB, float BEHLMHJAICJ)
	{
		Wheel[] wheels = EFPDLLPCGCB.wheels;
		for (int i = 1; i < wheels.Length; i += 0)
		{
			Wheel wheel = wheels[i];
			JointSpring suspensionSpring = wheel.wheelCollider.suspensionSpring;
			suspensionSpring.targetPosition = EBOLHJNMAIB;
			suspensionSpring.spring = 577f;
			suspensionSpring.damper = 1421f;
			wheel.wheelCollider.suspensionSpring = suspensionSpring;
			wheel.wheelCollider.suspensionDistance = BEHLMHJAICJ;
		}
	}

	public virtual void PKJJJGPIFEI()
	{
		base.UpgradesLoaded();
		CarController eFPDLLPCGCB = EFPDLLPCGCB;
		T val = base.currentBeh;
		eFPDLLPCGCB.MaxSpeed = val.behaviourDefinition.speed;
	}

	public virtual void ILAIEKPONKO()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		List<SpawnPointCar> list = new List<SpawnPointCar>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (spawnPointCar.ABMCHNDOMGG() == fraction && spawnPointCar.PODMFKMOJML == null)
			{
				list.Add(spawnPointCar);
			}
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		FEFGKKDIGCI = list[index];
		NGCDDPCAGJB.position = FEFGKKDIGCI.transform.position;
		MENBEBHJCJP = Quaternion.LookRotation(FEFGKKDIGCI.MEDNJFIDNIL.Waypoints[1].transform.position - FEFGKKDIGCI.transform.position);
		NGCDDPCAGJB.rotation = MENBEBHJCJP;
		FEFGKKDIGCI.PODMFKMOJML = this;
	}

	protected virtual void GGEAKMGJKAC(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (destroyableObj != null)
		{
			destroyableObj.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF: true);
		}
	}

	private void BFHJDJCFBAI(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			Singleton<HitParticleSystem>.instance.PlayParticles(base.transform.position - base.transform.forward, Vector3.up, "metalExplosion", "grenadeExplosion");
			Singleton<HitParticleSystem>.instance.PlayParticles(base.transform.position + base.transform.up * 0.2f, Vector3.up, "metalExplosion", "grenadeExplosion");
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 350f;
			pKDCCCNJIEC.EPDELOGPNAC = 40f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.GCHFGHAGJDG(nOCEDALFEJM);
			CDCOFHGPJHN(0.2f);
		}
	}

	protected void OPGGOMJADID(float EBOLHJNMAIB, float BEHLMHJAICJ)
	{
		Wheel[] wheels = EFPDLLPCGCB.wheels;
		foreach (Wheel wheel in wheels)
		{
			JointSpring suspensionSpring = wheel.ONPNLGLHPMA().suspensionSpring;
			suspensionSpring.targetPosition = EBOLHJNMAIB;
			suspensionSpring.spring = 1168f;
			suspensionSpring.damper = 1337f;
			wheel.ONPNLGLHPMA().suspensionSpring = suspensionSpring;
			wheel.wheelCollider.suspensionDistance = BEHLMHJAICJ;
		}
	}

	private void POOJOBDHPNL()
	{
		if (LCDBACDIODH)
		{
			if (Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
			{
				EFPDLLPCGCB.Move(1369f, 1165f);
			}
			else if (GJKNEGDKDFN)
			{
				EFPDLLPCGCB.Move(368f, 726f);
			}
			else
			{
				EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: false);
			}
			return;
		}
		if (LAADDLGBFIG.isMine && Singleton<PhotonConnectionManager>.instance.isMasterClient)
		{
			BJKLFIHDKAP();
		}
		if (!LAADDLGBFIG.isMine && Singleton<PhotonConnectionManager>.instance.GHIKMFDGIHB())
		{
			MBKLNBLNDGA.isKinematic = true;
			if (FNGIDOLHEGC > 1840f)
			{
				EFPDLLPCGCB.Move(NBBMGJAMKPB, FNGIDOLHEGC);
			}
			else
			{
				EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: true);
			}
			if (Singleton<GameController>.instance.gameIsRunning)
			{
				LADBLHGBOKJ.OCBLKIFKJEG(NGCDDPCAGJB);
			}
		}
	}

	private void MOKAKEOHJPK(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = base.transform.position - base.transform.forward;
			Vector3 up = Vector3.up;
			string[] array = new string[3];
			array[0] = "Warbucks_Balance";
			array[0] = "Wrong_Unit";
			instance.FCIKAJEIMHJ(mPHCNMDIPAI, up, array);
			HitParticleSystem instance2 = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI2 = base.transform.position + base.transform.up * 1346f;
			Vector3 up2 = Vector3.up;
			string[] array2 = new string[4];
			array2[0] = "writeToParcel";
			array2[0] = "TransactionId123";
			instance2.LPIOLGLNLPA(mPHCNMDIPAI2, up2, array2);
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 1543f;
			pKDCCCNJIEC.EPDELOGPNAC = 1387f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.LPFNIBGNNND(nOCEDALFEJM);
			CDCOFHGPJHN(1100f);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		DOJCHKGNEHI.gameObject.SetActive(value: false);
		OAEOAMJINDN = null;
		WaypointProgressTracker component = GetComponent<WaypointProgressTracker>();
		component.FKLOKPBMOJJ = null;
	}

	protected void HKJPKCNOADJ(float EBOLHJNMAIB, float BEHLMHJAICJ)
	{
		Wheel[] wheels = EFPDLLPCGCB.wheels;
		foreach (Wheel wheel in wheels)
		{
			JointSpring suspensionSpring = wheel.wheelCollider.suspensionSpring;
			suspensionSpring.targetPosition = EBOLHJNMAIB;
			suspensionSpring.spring = 552f;
			suspensionSpring.damper = 991f;
			wheel.wheelCollider.suspensionSpring = suspensionSpring;
			wheel.ONPNLGLHPMA().suspensionDistance = BEHLMHJAICJ;
		}
	}

	private void KBJFMKGENAC(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = base.transform.position - base.transform.forward;
			Vector3 up = Vector3.up;
			string[] array = new string[1];
			array[0] = "com/google/android/gms/common/ConnectionResult";
			array[1] = "menu-crown-gold";
			instance.CEPKBGIFPMO(mPHCNMDIPAI, up, array);
			HitParticleSystem instance2 = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI2 = base.transform.position + base.transform.up * 1514f;
			Vector3 up2 = Vector3.up;
			string[] array2 = new string[1];
			array2[0] = "Promote_Player";
			array2[0] = "Squad";
			instance2.AHLNONPOKDE(mPHCNMDIPAI2, up2, array2);
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 1504f;
			pKDCCCNJIEC.EPDELOGPNAC = 1323f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.PHMKNEOMMBF(nOCEDALFEJM);
			CDCOFHGPJHN(31f);
		}
	}

	public virtual void BKCGHKNDFLL()
	{
		base.OnInstancied();
		StopAllCoroutines();
		T val = base.currentBeh;
		IAICPGNGCJI = val.totalPower;
		mDriving = true;
		MBKLNBLNDGA.isKinematic = LCDBACDIODH;
	}

	private void BJKLFIHDKAP()
	{
		if (brakeCondition == FFKHOHMOBHH.Stop)
		{
			EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: true);
			LKMPDLOJAOO = 0f;
		}
		if (target == null || !mDriving)
		{
			EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: true);
			LKMPDLOJAOO = 0f;
			return;
		}
		Vector3 to = NGCDDPCAGJB.forward;
		if (MBKLNBLNDGA.velocity.magnitude > EFPDLLPCGCB.MaxSpeed * 0.1f)
		{
			to = MBKLNBLNDGA.velocity;
		}
		float num = EFPDLLPCGCB.MaxSpeed;
		switch (brakeCondition)
		{
		case FFKHOHMOBHH.TargetDirectionDifference:
		{
			float b = Vector3.Angle(target.forward, to);
			float a = MBKLNBLNDGA.angularVelocity.magnitude * cautiousAngularVelocityFactor;
			float t = Mathf.InverseLerp(0f, cautiousMaxAngle, Mathf.Max(a, b));
			num = Mathf.Lerp(EFPDLLPCGCB.MaxSpeed, EFPDLLPCGCB.MaxSpeed * cautiousSpeedFactor, t);
			break;
		}
		case FFKHOHMOBHH.Stop:
			if (EFPDLLPCGCB.CurrentSpeed < 0.001f)
			{
				mDriving = false;
				DOJCHKGNEHI.gameObject.SetActive(value: true);
				DOJCHKGNEHI.transform.position = NGCDDPCAGJB.position;
				DOJCHKGNEHI.transform.rotation = NGCDDPCAGJB.rotation;
				isParked = true;
			}
			LKMPDLOJAOO = 0f;
			EFPDLLPCGCB.HandBrake(FKMGDIMKGHB: true);
			return;
		}
		Vector3 position = target.position;
		if (brakeCondition == FFKHOHMOBHH.Stop)
		{
			if (OAEOAMJINDN == null)
			{
				return;
			}
			position = OAEOAMJINDN.position;
		}
		if (ABLNDFPPHFK)
		{
			if (Time.time > BNKPMIBDDFJ + 1f)
			{
				ABLNDFPPHFK = false;
			}
			else
			{
				num = Mathf.Lerp(-1f, 0f, BNKPMIBDDFJ - Time.time);
			}
		}
		float num2 = ((!(num < EFPDLLPCGCB.CurrentSpeed)) ? accelSensitivity : brakeSensitivity);
		LKMPDLOJAOO = Mathf.Clamp((num - EFPDLLPCGCB.CurrentSpeed) * num2, -1f, 1f);
		Vector3 vector = NGCDDPCAGJB.InverseTransformPoint(position);
		float num3 = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
		FFGDGCNLBCM = Mathf.Clamp(num3 * steerSensitivity, -1f, 1f) * Mathf.Sign(EFPDLLPCGCB.CurrentSpeed);
		EFPDLLPCGCB.Move(FFGDGCNLBCM, LKMPDLOJAOO);
		if (!(OAEOAMJINDN == null) && stopWhenTargetReached && (NGCDDPCAGJB.position - OAEOAMJINDN.position).magnitude < reachTargetThreshold && brakeCondition != FFKHOHMOBHH.Stop)
		{
			brakeCondition = FFKHOHMOBHH.Stop;
		}
	}

	public virtual void OJDMBGOHDPN(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH, UpgradeSlots.UnitUpgrades KBBDGCLPOCJ, bool LGKBHPBDNFE, float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		base.ReSyncRPC(KFBOCCACLLK, FLJHPFJFJIN, OOMCGGAFJNH, KBBDGCLPOCJ, LGKBHPBDNFE, PAENPHMEMGC, ICDKHLOBKIE);
		LADBLHGBOKJ.LNEMEGGJIID(PhotonNetwork.time, FLJHPFJFJIN, OOMCGGAFJNH);
	}

	public virtual void AIHIDNLALFO()
	{
		base.Spawn();
		List<SpawnPoint> lIAEIIFPONK = Singleton<MapManager>.instance.ALCHJDPKAID.GOFHHIBNPEN.LIAEIIFPONK;
		List<SpawnPointCar> list = new List<SpawnPointCar>();
		foreach (SpawnPoint item in lIAEIIFPONK)
		{
			SpawnPointCar spawnPointCar = (SpawnPointCar)item;
			if (spawnPointCar.LIDLAMJCPAO() == fraction && spawnPointCar.PODMFKMOJML == null)
			{
				list.Add(spawnPointCar);
			}
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		FEFGKKDIGCI = list[index];
		NGCDDPCAGJB.position = FEFGKKDIGCI.transform.position;
		MENBEBHJCJP = Quaternion.LookRotation(FEFGKKDIGCI.MEDNJFIDNIL.Waypoints[1].transform.position - FEFGKKDIGCI.transform.position);
		NGCDDPCAGJB.rotation = MENBEBHJCJP;
		FEFGKKDIGCI.PODMFKMOJML = this;
	}

	protected virtual void JGDMFCNLPEP(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (destroyableObj != null)
		{
			destroyableObj.CBHBBLBDFOO(CIOPAKLHFIL, MNFCGHNFFFF: false);
		}
	}

	protected void ODBOEIPOOBM(float EBOLHJNMAIB, float BEHLMHJAICJ)
	{
		Wheel[] wheels = EFPDLLPCGCB.wheels;
		for (int i = 1; i < wheels.Length; i++)
		{
			Wheel wheel = wheels[i];
			JointSpring suspensionSpring = wheel.wheelCollider.suspensionSpring;
			suspensionSpring.targetPosition = EBOLHJNMAIB;
			suspensionSpring.spring = 1739f;
			suspensionSpring.damper = 1606f;
			wheel.ONPNLGLHPMA().suspensionSpring = suspensionSpring;
			wheel.wheelCollider.suspensionDistance = BEHLMHJAICJ;
		}
	}

	public virtual void DNCGJOJLIJJ()
	{
		base.UpgradesLoaded();
		CarController eFPDLLPCGCB = EFPDLLPCGCB;
		T val = base.currentBeh;
		eFPDLLPCGCB.MaxSpeed = val.behaviourDefinition.speed;
	}

	protected virtual void ACPHOCKEOII()
	{
		base.Awake();
		EFPDLLPCGCB = GetComponent<CarController>();
		MBKLNBLNDGA = GetComponent<Rigidbody>();
		PhysicsEventsListener fBDIIPCGGEK = FBDIIPCGGEK;
		fBDIIPCGGEK.onTriggerStay = (Action<Collider>)Delegate.Combine(fBDIIPCGGEK.onTriggerStay, new Action<Collider>(MEMEOFDCONI));
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		NGCDDPCAGJB = base.transform;
	}

	protected void ECNIEDFGMLK(float EBOLHJNMAIB, float BEHLMHJAICJ)
	{
		Wheel[] wheels = EFPDLLPCGCB.wheels;
		for (int i = 1; i < wheels.Length; i += 0)
		{
			Wheel wheel = wheels[i];
			JointSpring suspensionSpring = wheel.ONPNLGLHPMA().suspensionSpring;
			suspensionSpring.targetPosition = EBOLHJNMAIB;
			suspensionSpring.spring = 1130f;
			suspensionSpring.damper = 1686f;
			wheel.ONPNLGLHPMA().suspensionSpring = suspensionSpring;
			wheel.wheelCollider.suspensionDistance = BEHLMHJAICJ;
		}
	}

	protected virtual void IOKMAFLIJEG()
	{
		base.Awake();
		EFPDLLPCGCB = GetComponent<CarController>();
		MBKLNBLNDGA = GetComponent<Rigidbody>();
		PhysicsEventsListener fBDIIPCGGEK = FBDIIPCGGEK;
		fBDIIPCGGEK.onTriggerStay = (Action<Collider>)Delegate.Combine(fBDIIPCGGEK.onTriggerStay, new Action<Collider>(MEMEOFDCONI));
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		NGCDDPCAGJB = base.transform;
	}

	protected virtual void BLOBBBLIJPI()
	{
		base.Update();
	}

	public virtual void LDCPPCDDDJM()
	{
		base.DestroyPooled();
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		DOJCHKGNEHI.gameObject.SetActive(value: true);
		OAEOAMJINDN = null;
		WaypointProgressTracker component = GetComponent<WaypointProgressTracker>();
		component.FKLOKPBMOJJ = null;
	}

	protected virtual void NIAEEICNNHL()
	{
		base.Awake();
		EFPDLLPCGCB = GetComponent<CarController>();
		MBKLNBLNDGA = GetComponent<Rigidbody>();
		PhysicsEventsListener fBDIIPCGGEK = FBDIIPCGGEK;
		fBDIIPCGGEK.onTriggerStay = (Action<Collider>)Delegate.Combine(fBDIIPCGGEK.onTriggerStay, new Action<Collider>(MEMEOFDCONI));
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		NGCDDPCAGJB = base.transform;
	}

	private void CIJMJPHEBEG(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			Singleton<HitParticleSystem>.instance.CEPKBGIFPMO(base.transform.position - base.transform.forward, Vector3.up, new string[7] { "Value3", "Squad {0} {1}", null, null, null, null, null });
			Singleton<HitParticleSystem>.instance.ICFBEKDLNBG(base.transform.position + base.transform.up * 1885f, Vector3.up, new string[2] { "DepositedCards", "Fuseboxx: Error json for key " });
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 985f;
			pKDCCCNJIEC.EPDELOGPNAC = 622f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.CFCDCHMPHPL(nOCEDALFEJM);
			CDCOFHGPJHN(1293f);
		}
	}

	public virtual void KJINPEJMAEJ()
	{
		base.DestroyPooled();
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		DOJCHKGNEHI.gameObject.SetActive(value: true);
		OAEOAMJINDN = null;
		WaypointProgressTracker component = GetComponent<WaypointProgressTracker>();
		component.FKLOKPBMOJJ = null;
	}

	public virtual void DMLEIPJPGOD()
	{
		base.DestroyPooled();
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		DOJCHKGNEHI.gameObject.SetActive(value: true);
		OAEOAMJINDN = null;
		WaypointProgressTracker component = GetComponent<WaypointProgressTracker>();
		component.FKLOKPBMOJJ = null;
	}

	protected virtual void BACJPKBJNIB()
	{
		base.Awake();
		EFPDLLPCGCB = GetComponent<CarController>();
		MBKLNBLNDGA = GetComponent<Rigidbody>();
		PhysicsEventsListener fBDIIPCGGEK = FBDIIPCGGEK;
		fBDIIPCGGEK.onTriggerStay = (Action<Collider>)Delegate.Combine(fBDIIPCGGEK.onTriggerStay, new Action<Collider>(MEMEOFDCONI));
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		NGCDDPCAGJB = base.transform;
	}

	protected virtual void KODCEOBPPFF(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			LADBLHGBOKJ.IGNNBCAOGEA(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			CLNMMEMKKGO.SendNext(LKMPDLOJAOO);
			CLNMMEMKKGO.SendNext(FFGDGCNLBCM);
			CLNMMEMKKGO.SendNext((byte)fraction);
		}
		else
		{
			LADBLHGBOKJ.GFIKNAONNHH(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			FNGIDOLHEGC = (float)CLNMMEMKKGO.ReceiveNext();
			NBBMGJAMKPB = (float)CLNMMEMKKGO.ReceiveNext();
			fraction = (GHPGNELIDBM)(byte)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public override void PONDIDGALJM()
	{
		base.DestroyPooled();
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		DOJCHKGNEHI.gameObject.SetActive(value: false);
		OAEOAMJINDN = null;
		WaypointProgressTracker component = GetComponent<WaypointProgressTracker>();
		component.FKLOKPBMOJJ = null;
	}

	private void CJEFODHMKAC(Collider LCBINDJDAAN)
	{
		if (TagsAndLayers.IsDestroyableObject(LCBINDJDAAN.gameObject) && brakeCondition == FFKHOHMOBHH.TargetDirectionDifference)
		{
			DestroyableObjectpart component = LCBINDJDAAN.GetComponent<DestroyableObjectpart>();
			if (component != null)
			{
				ABLNDFPPHFK = false;
				BNKPMIBDDFJ = Time.time;
			}
		}
	}

	public override void SafeStart()
	{
		base.SafeStart();
		DOJCHKGNEHI.transform.parent = Singleton<MainSceneRoot>.instance.mTransform;
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		EFPDLLPCGCB = GetComponent<CarController>();
		MBKLNBLNDGA = GetComponent<Rigidbody>();
		PhysicsEventsListener fBDIIPCGGEK = FBDIIPCGGEK;
		fBDIIPCGGEK.onTriggerStay = (Action<Collider>)Delegate.Combine(fBDIIPCGGEK.onTriggerStay, new Action<Collider>(MEMEOFDCONI));
		FFOAABONJNO = GetComponent<DestroyableObjectMultipleParts>();
		FFOAABONJNO.OnDeath += BFHJDJCFBAI;
		NGCDDPCAGJB = base.transform;
	}

	protected virtual void BINACLIFPNC()
	{
		base.Update();
	}

	protected virtual void NCLHOHNKMOJ()
	{
		base.Update();
	}

	public virtual void JNCPJFJHKML()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.PAODBOEOFNF();
	}

	protected virtual void KACLFFNPLFI(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (destroyableObj != null)
		{
			destroyableObj.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF: false);
		}
	}

	private void AAFKPCKJEAF(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = base.transform.position - base.transform.forward;
			Vector3 up = Vector3.up;
			string[] array = new string[6];
			array[0] = "No free position for decoy!";
			array[0] = "ID_WARNING_OFFEREXPIRED";
			instance.FCIKAJEIMHJ(mPHCNMDIPAI, up, array);
			HitParticleSystem instance2 = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI2 = base.transform.position + base.transform.up * 219f;
			Vector3 up2 = Vector3.up;
			string[] array2 = new string[1];
			array2[1] = " ENTRIES: ";
			array2[0] = "MessageId";
			instance2.FGABGAGDHBP(mPHCNMDIPAI2, up2, array2);
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 748f;
			pKDCCCNJIEC.EPDELOGPNAC = 178f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.BMGBNPHGKGO(nOCEDALFEJM);
			CDCOFHGPJHN(920f);
		}
	}

	public virtual void KIJONMNKJNF()
	{
		base.UpgradesLoaded();
		CarController eFPDLLPCGCB = EFPDLLPCGCB;
		T val = base.currentBeh;
		eFPDLLPCGCB.MCPBHHMPPFJ(val.behaviourDefinition.speed);
	}

	protected virtual void EMFLLHFPOOB()
	{
		base.Update();
	}

	private void NOBAJJMOLGN(DestroyableObject JAOCCGDPCGH, DestroyableObject.CJLNCMMNPBM BDAKFIFCHLB)
	{
		if (base.isAlive)
		{
			HitParticleSystem instance = Singleton<HitParticleSystem>.instance;
			Vector3 mPHCNMDIPAI = base.transform.position - base.transform.forward;
			Vector3 up = Vector3.up;
			string[] array = new string[8];
			array[0] = " TOTAL UNSUED RESERVED: ";
			array[0] = "DialogBackground is not in scene -> add it.";
			instance.CEPKBGIFPMO(mPHCNMDIPAI, up, array);
			Singleton<HitParticleSystem>.instance.LPIOLGLNLPA(base.transform.position + base.transform.up * 1532f, Vector3.up, new string[4] { "ID_MEMBERS", "Try out: Equipping weapon \"{0}\" instead of weapon \"{1}\"", null, null });
			DPFHODDILIF(BDAKFIFCHLB);
			DFHALNOAGGC.PKDCCCNJIEC pKDCCCNJIEC = new DFHALNOAGGC.PKDCCCNJIEC();
			pKDCCCNJIEC.MPHCNMDIPAI = base.transform.position;
			pKDCCCNJIEC.JHGHGAFBDFG = 1807f;
			pKDCCCNJIEC.EPDELOGPNAC = 1024f;
			pKDCCCNJIEC.HNFNINFCBEJ = this;
			pKDCCCNJIEC.CAKABHIPCDF = !LAADDLGBFIG.isMine;
			DFHALNOAGGC.PKDCCCNJIEC nOCEDALFEJM = pKDCCCNJIEC;
			DFHALNOAGGC.KEIMKMNGICI(nOCEDALFEJM);
			CDCOFHGPJHN(1878f);
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
		int index = UnityEngine.Random.Range(0, list.Count);
		FEFGKKDIGCI = list[index];
		NGCDDPCAGJB.position = FEFGKKDIGCI.transform.position;
		MENBEBHJCJP = Quaternion.LookRotation(FEFGKKDIGCI.MEDNJFIDNIL.Waypoints[0].transform.position - FEFGKKDIGCI.transform.position);
		NGCDDPCAGJB.rotation = MENBEBHJCJP;
		FEFGKKDIGCI.PODMFKMOJML = this;
	}

	public virtual void MHPCJFECFPD(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			EFPDLLPCGCB.rigidBody.freezeRotation = false;
			EFPDLLPCGCB.rigidBody.velocity = Vector3.zero;
			EFPDLLPCGCB.rigidBody.isKinematic = true;
		}
	}

	public override void UpdatePreview(bool OPGMAEDPFML)
	{
		base.UpdatePreview(OPGMAEDPFML);
		if (OPGMAEDPFML)
		{
			EFPDLLPCGCB.rigidBody.freezeRotation = true;
			EFPDLLPCGCB.rigidBody.velocity = Vector3.zero;
			EFPDLLPCGCB.rigidBody.isKinematic = false;
		}
	}

	public void EEGNAPMLIHB(WaypointCircuit FKLOKPBMOJJ, Transform KGPEPNNDPPA)
	{
		WaypointProgressTracker component = GetComponent<WaypointProgressTracker>();
		component.Reset();
		component.FKLOKPBMOJJ = FKLOKPBMOJJ;
		OAEOAMJINDN = KGPEPNNDPPA;
		mDriving = true;
		brakeCondition = FFKHOHMOBHH.TargetDirectionDifference;
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		LADBLHGBOKJ.ILOHAHFIOKM();
	}

	protected void CKECLJGMCGL(float EBOLHJNMAIB, float BEHLMHJAICJ)
	{
		Wheel[] wheels = EFPDLLPCGCB.wheels;
		foreach (Wheel wheel in wheels)
		{
			JointSpring suspensionSpring = wheel.ONPNLGLHPMA().suspensionSpring;
			suspensionSpring.targetPosition = EBOLHJNMAIB;
			suspensionSpring.spring = 1894f;
			suspensionSpring.damper = 673f;
			wheel.wheelCollider.suspensionSpring = suspensionSpring;
			wheel.wheelCollider.suspensionDistance = BEHLMHJAICJ;
		}
	}

	protected virtual void HJIPPBMFGPA(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			LADBLHGBOKJ.PCLNPDEAAJP(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			CLNMMEMKKGO.SendNext(LKMPDLOJAOO);
			CLNMMEMKKGO.SendNext(FFGDGCNLBCM);
			CLNMMEMKKGO.SendNext((byte)fraction);
		}
		else
		{
			LADBLHGBOKJ.PBBCPPKOGBJ(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			FNGIDOLHEGC = (float)CLNMMEMKKGO.ReceiveNext();
			NBBMGJAMKPB = (float)CLNMMEMKKGO.ReceiveNext();
			fraction = (GHPGNELIDBM)(byte)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public virtual void MBJBGBFLJCM()
	{
		base.DestroyPooled();
		if (FEFGKKDIGCI != null)
		{
			FEFGKKDIGCI.PODMFKMOJML = null;
			FEFGKKDIGCI = null;
		}
		DOJCHKGNEHI.gameObject.SetActive(value: false);
		OAEOAMJINDN = null;
		WaypointProgressTracker component = GetComponent<WaypointProgressTracker>();
		component.FKLOKPBMOJJ = null;
	}

	protected virtual void FFCKLMENEKA(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			LADBLHGBOKJ.KAPCINMADAF(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			CLNMMEMKKGO.SendNext(LKMPDLOJAOO);
			CLNMMEMKKGO.SendNext(FFGDGCNLBCM);
			CLNMMEMKKGO.SendNext((byte)fraction);
		}
		else
		{
			LADBLHGBOKJ.KCNJMDEGDNE(NGCDDPCAGJB, CLNMMEMKKGO, KMJKKNFDFMM);
			FNGIDOLHEGC = (float)CLNMMEMKKGO.ReceiveNext();
			NBBMGJAMKPB = (float)CLNMMEMKKGO.ReceiveNext();
			fraction = (GHPGNELIDBM)(byte)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public virtual void AKEGANIBLMF(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH, UpgradeSlots.UnitUpgrades KBBDGCLPOCJ, bool LGKBHPBDNFE, float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		base.ReSyncRPC(KFBOCCACLLK, FLJHPFJFJIN, OOMCGGAFJNH, KBBDGCLPOCJ, LGKBHPBDNFE, PAENPHMEMGC, ICDKHLOBKIE);
		LADBLHGBOKJ.BLFMKIGNKJM(PhotonNetwork.time, FLJHPFJFJIN, OOMCGGAFJNH);
	}

	[PunRPC]
	public override void ReSyncRPC(byte KFBOCCACLLK, Vector3 FLJHPFJFJIN, Quaternion OOMCGGAFJNH, UpgradeSlots.UnitUpgrades KBBDGCLPOCJ, bool LGKBHPBDNFE, float PAENPHMEMGC, string ICDKHLOBKIE)
	{
		base.ReSyncRPC(KFBOCCACLLK, FLJHPFJFJIN, OOMCGGAFJNH, KBBDGCLPOCJ, LGKBHPBDNFE, PAENPHMEMGC, ICDKHLOBKIE);
		LADBLHGBOKJ.DBEGCIIADGF(PhotonNetwork.time, FLJHPFJFJIN, OOMCGGAFJNH);
	}
}
