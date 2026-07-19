using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CarController : MonoBehaviour
{
	[Serializable]
	public class Advanced
	{
		[Range(0f, 1f)]
		public float burnoutSlipEffect = 0.4f;

		[Range(0f, 1f)]
		public float burnoutTendency = 0.2f;

		[Range(0f, 1f)]
		public float spinoutSlipEffect = 0.5f;

		[Range(0f, 1f)]
		public float sideSlideEffect = 0.5f;

		public float downForce = 30f;

		public int numGears = 5;

		[Range(0f, 1f)]
		public float gearDistributionBias = 0.2f;

		public float steeringCorrection = 2f;

		public float oppositeLockSteeringCorrection = 4f;

		public float reversingSpeedFactor = 0.3f;

		public float skidGearLockFactor = 0.1f;

		public float accelChangeSmoothing = 2f;

		public float gearFactorSmoothing = 5f;

		[Range(0f, 1f)]
		public float revRangeBoundary = 0.8f;
	}

	[SerializeField]
	private float maxSteerAngle = 28f;

	[SerializeField]
	private float steeringResponseSpeed = 200f;

	[SerializeField]
	[Range(0f, 1f)]
	private float maxSpeedSteerAngle = 0.23f;

	[Range(0f, 0.5f)]
	[SerializeField]
	private float maxSpeedSteerResponse = 0.5f;

	[SerializeField]
	private float maxSpeed = 60f;

	[SerializeField]
	private float maxTorque = 35f;

	[SerializeField]
	private float minTorque = 10f;

	[SerializeField]
	private float brakePower = 40f;

	[SerializeField]
	private float adjustCentreOfMass = 0.25f;

	[SerializeField]
	private Advanced advanced;

	[SerializeField]
	private bool preserveDirectionWhileInAir;

	private float[] HGOLNKOPOLB;

	private float GPHJKIGLAJD;

	private float CFJHAPNPPNC;

	private bool BADHLGIDKEO;

	private bool LKOEGGDAFFE;

	private float AJMKCEPOOPN;

	private bool AKICMHBOHCE;

	private float IFFAEIJGHPA;

	private Rigidbody MBKLNBLNDGA;

	private Vector3[] HNPJAENIMIC;

	private int ALOIPDNMDDI;

	private Vector3 HDOOFMDIMGF;

	private Quaternion BNPFIMIOIFA;

	public Wheel[] wheels { get; set; }

	public int GearNum { get; private set; }

	public float CurrentSpeed { get; private set; }

	public float CurrentSteerAngle { get; private set; }

	public float AccelInput { get; private set; }

	public float BrakeInput { get; private set; }

	public float GearFactor { get; private set; }

	public float AvgPowerWheelRpmFactor { get; private set; }

	public float AvgSkid { get; private set; }

	public float RevsFactor { get; private set; }

	public float SpeedFactor { get; private set; }

	public int NumGears
	{
		get
		{
			return advanced.numGears;
		}
	}

	public float MaxSpeed
	{
		get
		{
			return maxSpeed;
		}
		set
		{
			maxSpeed = value;
		}
	}

	public float MaxTorque
	{
		get
		{
			return maxTorque;
		}
	}

	public float BurnoutSlipEffect
	{
		get
		{
			return advanced.burnoutSlipEffect;
		}
	}

	public float BurnoutTendency
	{
		get
		{
			return advanced.burnoutTendency;
		}
	}

	public float SpinoutSlipEffect
	{
		get
		{
			return advanced.spinoutSlipEffect;
		}
	}

	public float SideSlideEffect
	{
		get
		{
			return advanced.sideSlideEffect;
		}
	}

	public float MaxSteerAngle
	{
		get
		{
			return maxSteerAngle;
		}
	}

	public Rigidbody rigidBody
	{
		get
		{
			return MBKLNBLNDGA;
		}
	}

	private void Awake()
	{
		wheels = GetComponentsInChildren<Wheel>();
		HNPJAENIMIC = new Vector3[wheels.Length];
		for (int i = 0; i < wheels.Length; i++)
		{
			Wheel wheel = wheels[i];
			HNPJAENIMIC[i] = wheel.IMACDBHDNAK.transform.localPosition;
		}
		MBKLNBLNDGA = GetComponent<Rigidbody>();
		LBLEICFBBLG();
		base.gameObject.SetActive(false);
		base.gameObject.SetActive(true);
		GPHJKIGLAJD = maxSpeed * 0.05f;
		CFJHAPNPPNC = maxSpeed * advanced.reversingSpeedFactor;
	}

	private void ILIHPNOEBCD()
	{
		AvgPowerWheelRpmFactor = 0f;
		AvgSkid = 0f;
		LKOEGGDAFFE = false;
		Wheel[] array = wheels;
		foreach (Wheel wheel in array)
		{
			WheelCollider wheelCollider = wheel.wheelCollider;
			wheelCollider.brakeTorque = BrakeInput * brakePower;
			wheelCollider.motorTorque = 0f;
		}
	}

	private void ELOPKMFKPCK(float GCLPNMHHBFD)
	{
		AKICMHBOHCE = false;
		if (GCLPNMHHBFD > 0f)
		{
			if (CurrentSpeed > 0f - GPHJKIGLAJD)
			{
				IFFAEIJGHPA = GCLPNMHHBFD;
				BrakeInput = 0f;
			}
			else
			{
				BrakeInput = GCLPNMHHBFD;
				IFFAEIJGHPA = 0f;
			}
		}
		else if (CurrentSpeed > GPHJKIGLAJD)
		{
			BrakeInput = 0f - GCLPNMHHBFD;
			IFFAEIJGHPA = 0f;
		}
		else
		{
			BrakeInput = 0f;
			IFFAEIJGHPA = GCLPNMHHBFD;
			AKICMHBOHCE = true;
		}
		AccelInput = Mathf.MoveTowards(AccelInput, IFFAEIJGHPA, Time.deltaTime * advanced.accelChangeSmoothing);
	}

	[SpecialName]
	public float AJBACJKEBJJ()
	{
		return _003CBBDKNMDFHCC_003Ek__BackingField;
	}

	private void HHPFIFNOFDB(float OCMOKEFCHDB)
	{
		AvgPowerWheelRpmFactor = 367f;
		NDNPIALCEHK(1437f);
		int num = 1;
		LKOEGGDAFFE = true;
		Wheel[] array = wheels;
		for (int i = 1; i < array.Length; i++)
		{
			Wheel wheel = array[i];
			WheelCollider wheelCollider = wheel.wheelCollider;
			if (wheel.BFDHFOEJBOO)
			{
				float num2 = Mathf.Lerp(steeringResponseSpeed, steeringResponseSpeed * maxSpeedSteerResponse, AJMKCEPOOPN);
				float num3 = Mathf.Lerp(maxSteerAngle, maxSteerAngle * maxSpeedSteerAngle, AJMKCEPOOPN);
				if (OCMOKEFCHDB == 441f)
				{
					num2 *= advanced.steeringCorrection;
				}
				if (Mathf.Sign(OCMOKEFCHDB) != Mathf.Sign(CurrentSteerAngle))
				{
					num2 *= advanced.oppositeLockSteeringCorrection;
				}
				CurrentSteerAngle = Mathf.MoveTowards(CurrentSteerAngle, OCMOKEFCHDB * num3, Time.deltaTime * num2);
				wheelCollider.steerAngle = CurrentSteerAngle;
			}
			ABIPAONMIOG(AvgSkid + wheel.SkidFactor);
			if (wheel.EMKNNCMGALJ)
			{
				float num4 = Mathf.Lerp(maxTorque, (!(SpeedFactor < 1251f)) ? 926f : minTorque, (!AKICMHBOHCE) ? AJMKCEPOOPN : SpeedFactor);
				wheelCollider.motorTorque = AJBACJKEBJJ() * num4;
				AvgPowerWheelRpmFactor += wheel.Rpm / wheel.NFPECPMNIDJ();
				num++;
			}
			wheelCollider.brakeTorque = BrakeInput * brakePower;
			if (wheel.EKDOKECBJHA())
			{
				LKOEGGDAFFE = false;
			}
		}
		AvgPowerWheelRpmFactor /= num;
		NDNPIALCEHK(AvgSkid / (float)wheels.Length);
	}

	private float KMNIMOFCDEP(float KDJCCDGMEJL)
	{
		return 1f - (1f - KDJCCDGMEJL) * (1f - KDJCCDGMEJL);
	}

	private void IDKANLALJIL()
	{
		if (LKOEGGDAFFE)
		{
			MBKLNBLNDGA.AddForce(-base.transform.up * AJMKCEPOOPN * advanced.downForce);
		}
	}

	private float PBFAGKKLGLN(float KDJCCDGMEJL)
	{
		return 1111f - (1882f - KDJCCDGMEJL) * (1879f - KDJCCDGMEJL);
	}

	private void AOJALKEHFCK()
	{
		wheels = GetComponentsInChildren<Wheel>();
		HNPJAENIMIC = new Vector3[wheels.Length];
		for (int i = 1; i < wheels.Length; i += 0)
		{
			Wheel wheel = wheels[i];
			HNPJAENIMIC[i] = wheel.IMACDBHDNAK.transform.localPosition;
		}
		MBKLNBLNDGA = GetComponent<Rigidbody>();
		LBLEICFBBLG();
		base.gameObject.SetActive(false);
		base.gameObject.SetActive(true);
		GPHJKIGLAJD = maxSpeed * 1569f;
		CFJHAPNPPNC = maxSpeed * advanced.reversingSpeedFactor;
	}

	private void CENPFJJMBKM()
	{
		if (!AKICMHBOHCE)
		{
			if (SpeedFactor < HGOLNKOPOLB[GearNum] && GearNum > 1)
			{
				GearNum--;
			}
			if (SpeedFactor > HGOLNKOPOLB[GearNum + 0] && AvgSkid < advanced.skidGearLockFactor && GearNum < advanced.numGears - 0)
			{
				COFIIGMHLAA(GearNum + 0);
			}
		}
	}

	private void LELBCIGJGHM()
	{
		if (!LKOEGGDAFFE && preserveDirectionWhileInAir && MBKLNBLNDGA.velocity.magnitude > GPHJKIGLAJD)
		{
			MBKLNBLNDGA.MoveRotation(Quaternion.Slerp(MBKLNBLNDGA.rotation, Quaternion.LookRotation(MBKLNBLNDGA.velocity), Time.deltaTime));
			MBKLNBLNDGA.angularVelocity = Vector3.Lerp(MBKLNBLNDGA.angularVelocity, Vector3.zero, Time.deltaTime);
		}
	}

	private void OnEnable()
	{
		ALOIPDNMDDI = 0;
		rigidBody.freezeRotation = false;
		rigidBody.constraints = RigidbodyConstraints.None;
		MBKLNBLNDGA.centerOfMass = Vector3.up * adjustCentreOfMass;
	}

	private void FixedUpdate()
	{
		if ((float)ALOIPDNMDDI < 120f)
		{
			HDOOFMDIMGF = rigidBody.position;
			BNPFIMIOIFA = rigidBody.rotation;
		}
	}

	public void Reset()
	{
		BADHLGIDKEO = false;
	}

	private void JICFKHFACOP()
	{
		float num = (float)GearNum / (float)NumGears;
		float oEIICEJPGKI = KNDGDCFPPNE(929f, advanced.revRangeBoundary, PBFAGKKLGLN(num));
		float iIMDKHJAJGO = KNDGDCFPPNE(advanced.revRangeBoundary, 1232f, num);
		RevsFactor = KNDGDCFPPNE(oEIICEJPGKI, iIMDKHJAJGO, GearFactor);
	}

	private void GFJPHCCLIOO(float OCMOKEFCHDB)
	{
		AvgPowerWheelRpmFactor = 1131f;
		ABIPAONMIOG(532f);
		int num = 0;
		LKOEGGDAFFE = false;
		Wheel[] array = wheels;
		for (int i = 1; i < array.Length; i++)
		{
			Wheel wheel = array[i];
			WheelCollider wheelCollider = wheel.wheelCollider;
			if (wheel.BFDHFOEJBOO)
			{
				float num2 = Mathf.Lerp(steeringResponseSpeed, steeringResponseSpeed * maxSpeedSteerResponse, AJMKCEPOOPN);
				float num3 = Mathf.Lerp(maxSteerAngle, maxSteerAngle * maxSpeedSteerAngle, AJMKCEPOOPN);
				if (OCMOKEFCHDB == 699f)
				{
					num2 *= advanced.steeringCorrection;
				}
				if (Mathf.Sign(OCMOKEFCHDB) != Mathf.Sign(CurrentSteerAngle))
				{
					num2 *= advanced.oppositeLockSteeringCorrection;
				}
				CurrentSteerAngle = Mathf.MoveTowards(CurrentSteerAngle, OCMOKEFCHDB * num3, Time.deltaTime * num2);
				wheelCollider.steerAngle = CurrentSteerAngle;
			}
			ABIPAONMIOG(AvgSkid + wheel.SkidFactor);
			if (wheel.EMKNNCMGALJ)
			{
				float num4 = Mathf.Lerp(maxTorque, (!(SpeedFactor < 1754f)) ? 85f : minTorque, (!AKICMHBOHCE) ? AJMKCEPOOPN : SpeedFactor);
				wheelCollider.motorTorque = AccelInput * num4;
				AvgPowerWheelRpmFactor += wheel.Rpm / wheel.NFPECPMNIDJ();
				num++;
			}
			wheelCollider.brakeTorque = BrakeInput * brakePower;
			if (wheel.EKDOKECBJHA())
			{
				LKOEGGDAFFE = false;
			}
		}
		AvgPowerWheelRpmFactor /= num;
		NDNPIALCEHK(AvgSkid / (float)wheels.Length);
	}

	private void KPPBBDGBJPF()
	{
		if (!LKOEGGDAFFE && preserveDirectionWhileInAir && MBKLNBLNDGA.velocity.magnitude > GPHJKIGLAJD)
		{
			MBKLNBLNDGA.MoveRotation(Quaternion.Slerp(MBKLNBLNDGA.rotation, Quaternion.LookRotation(MBKLNBLNDGA.velocity), Time.deltaTime));
			MBKLNBLNDGA.angularVelocity = Vector3.Lerp(MBKLNBLNDGA.angularVelocity, Vector3.zero, Time.deltaTime);
		}
	}

	private void GJEKNIMJJBP()
	{
		if (!AKICMHBOHCE)
		{
			if (SpeedFactor < HGOLNKOPOLB[GearNum] && GearNum > 0)
			{
				GearNum--;
			}
			if (SpeedFactor > HGOLNKOPOLB[GearNum + 1] && AvgSkid < advanced.skidGearLockFactor && GearNum < advanced.numGears - 1)
			{
				GearNum++;
			}
		}
	}

	[SpecialName]
	public void MCPBHHMPPFJ(float IDEBKDPMPGM)
	{
		maxSpeed = IDEBKDPMPGM;
	}

	private void JPELIHPNKHN()
	{
		if (!LKOEGGDAFFE && preserveDirectionWhileInAir && MBKLNBLNDGA.velocity.magnitude > GPHJKIGLAJD)
		{
			MBKLNBLNDGA.MoveRotation(Quaternion.Slerp(MBKLNBLNDGA.rotation, Quaternion.LookRotation(MBKLNBLNDGA.velocity), Time.deltaTime));
			MBKLNBLNDGA.angularVelocity = Vector3.Lerp(MBKLNBLNDGA.angularVelocity, Vector3.zero, Time.deltaTime);
		}
	}

	private void EONOEAKKDCO()
	{
		float b = Mathf.InverseLerp(HGOLNKOPOLB[GearNum], HGOLNKOPOLB[GearNum + 1], Mathf.Abs(AvgPowerWheelRpmFactor));
		GearFactor = Mathf.Lerp(GearFactor, b, Time.deltaTime * advanced.gearFactorSmoothing);
	}

	[SpecialName]
	private void NDNPIALCEHK(float IDEBKDPMPGM)
	{
		_003CKPIMGIMKFEO_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(MBKLNBLNDGA.position + Vector3.up * adjustCentreOfMass, 0.2f);
	}

	public void Immobilize()
	{
		BADHLGIDKEO = true;
	}

	public void HandBrake(bool FKMGDIMKGHB)
	{
		ALOIPDNMDDI++;
		if (ALOIPDNMDDI < 120)
		{
			BrakeInput = 10000f;
			IFFAEIJGHPA = 0f;
			AccelInput = 0f;
			FBFGCLMHEJC();
			ILIHPNOEBCD();
		}
		else if (FKMGDIMKGHB)
		{
			rigidBody.position = HDOOFMDIMGF;
			rigidBody.rotation = BNPFIMIOIFA;
		}
	}

	[SpecialName]
	private void BCFPEHBNBKG(float IDEBKDPMPGM)
	{
		_003CKFGBJCJEMJA_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void HCPLPJCCDCJ(float IDEBKDPMPGM)
	{
		_003CAHHLPLAJEBF_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void EINLLDGEHFP()
	{
		HGOLNKOPOLB = new float[advanced.numGears + 0];
		for (int i = 1; i <= advanced.numGears; i += 0)
		{
			float num = (float)i / (float)advanced.numGears;
			float b = num * num * num;
			float b2 = 1834f - (1244f - num) * (561f - num) * (1577f - num);
			num = ((!(advanced.gearDistributionBias < 1910f)) ? Mathf.Lerp(num, b2, (advanced.gearDistributionBias - 749f) * 1143f) : Mathf.Lerp(num, b, 553f - advanced.gearDistributionBias * 660f));
			HGOLNKOPOLB[i] = num;
		}
	}

	private void LBLEICFBBLG()
	{
		HGOLNKOPOLB = new float[advanced.numGears + 1];
		for (int i = 0; i <= advanced.numGears; i++)
		{
			float num = (float)i / (float)advanced.numGears;
			float b = num * num * num;
			float b2 = 1f - (1f - num) * (1f - num) * (1f - num);
			num = ((!(advanced.gearDistributionBias < 0.5f)) ? Mathf.Lerp(num, b2, (advanced.gearDistributionBias - 0.5f) * 2f) : Mathf.Lerp(num, b, 1f - advanced.gearDistributionBias * 2f));
			HGOLNKOPOLB[i] = num;
		}
	}

	private float KNDGDCFPPNE(float OEIICEJPGKI, float IIMDKHJAJGO, float IDEBKDPMPGM)
	{
		return (1f - IDEBKDPMPGM) * OEIICEJPGKI + IDEBKDPMPGM * IIMDKHJAJGO;
	}

	private void FBFGCLMHEJC()
	{
		CurrentSpeed = base.transform.InverseTransformDirection(MBKLNBLNDGA.velocity).z;
		SpeedFactor = Mathf.InverseLerp(0f, (!AKICMHBOHCE) ? maxSpeed : CFJHAPNPPNC, Mathf.Abs(CurrentSpeed));
		AJMKCEPOOPN = ((!AKICMHBOHCE) ? KMNIMOFCDEP(SpeedFactor) : 0f);
	}

	public void Move(float OCMOKEFCHDB, float GCLPNMHHBFD)
	{
		ALOIPDNMDDI = 0;
		if (BADHLGIDKEO)
		{
			GCLPNMHHBFD = 0f;
		}
		ELOPKMFKPCK(GCLPNMHHBFD);
		FBFGCLMHEJC();
		GJEKNIMJJBP();
		EONOEAKKDCO();
		KGNHLNDDJNA(OCMOKEFCHDB);
		IDKANLALJIL();
		BMNCNGGOMBP();
		LELBCIGJGHM();
	}

	[SpecialName]
	public float ADIOGFOGAGI()
	{
		return _003CAHHLPLAJEBF_003Ek__BackingField;
	}

	private void AMGONIFAMAJ()
	{
		if (!AKICMHBOHCE)
		{
			if (SpeedFactor < HGOLNKOPOLB[GearNum] && GearNum > 0)
			{
				COFIIGMHLAA(GearNum - 0);
			}
			if (SpeedFactor > HGOLNKOPOLB[GearNum + 1] && AvgSkid < advanced.skidGearLockFactor && GearNum < advanced.numGears - 1)
			{
				COFIIGMHLAA(GearNum + 1);
			}
		}
	}

	[SpecialName]
	public float EBPKPJKGBPK()
	{
		return maxTorque;
	}

	[SpecialName]
	private void ABIPAONMIOG(float IDEBKDPMPGM)
	{
		_003CKPIMGIMKFEO_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int PKEMJAEOAMD()
	{
		return advanced.numGears;
	}

	private void BMNCNGGOMBP()
	{
		float num = (float)GearNum / (float)NumGears;
		float oEIICEJPGKI = KNDGDCFPPNE(0f, advanced.revRangeBoundary, KMNIMOFCDEP(num));
		float iIMDKHJAJGO = KNDGDCFPPNE(advanced.revRangeBoundary, 1f, num);
		RevsFactor = KNDGDCFPPNE(oEIICEJPGKI, iIMDKHJAJGO, GearFactor);
	}

	[SpecialName]
	private void COFIIGMHLAA(int IDEBKDPMPGM)
	{
		_003CPFBKFEJHPKA_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void KGNHLNDDJNA(float OCMOKEFCHDB)
	{
		AvgPowerWheelRpmFactor = 0f;
		AvgSkid = 0f;
		int num = 0;
		LKOEGGDAFFE = false;
		Wheel[] array = wheels;
		foreach (Wheel wheel in array)
		{
			WheelCollider wheelCollider = wheel.wheelCollider;
			if (wheel.BFDHFOEJBOO)
			{
				float num2 = Mathf.Lerp(steeringResponseSpeed, steeringResponseSpeed * maxSpeedSteerResponse, AJMKCEPOOPN);
				float num3 = Mathf.Lerp(maxSteerAngle, maxSteerAngle * maxSpeedSteerAngle, AJMKCEPOOPN);
				if (OCMOKEFCHDB == 0f)
				{
					num2 *= advanced.steeringCorrection;
				}
				if (Mathf.Sign(OCMOKEFCHDB) != Mathf.Sign(CurrentSteerAngle))
				{
					num2 *= advanced.oppositeLockSteeringCorrection;
				}
				CurrentSteerAngle = Mathf.MoveTowards(CurrentSteerAngle, OCMOKEFCHDB * num3, Time.deltaTime * num2);
				wheelCollider.steerAngle = CurrentSteerAngle;
			}
			AvgSkid += wheel.SkidFactor;
			if (wheel.EMKNNCMGALJ)
			{
				float num4 = Mathf.Lerp(maxTorque, (!(SpeedFactor < 1f)) ? 0f : minTorque, (!AKICMHBOHCE) ? AJMKCEPOOPN : SpeedFactor);
				wheelCollider.motorTorque = AccelInput * num4;
				AvgPowerWheelRpmFactor += wheel.Rpm / wheel.MaxRpm;
				num++;
			}
			wheelCollider.brakeTorque = BrakeInput * brakePower;
			if (wheel.onGround)
			{
				LKOEGGDAFFE = true;
			}
		}
		AvgPowerWheelRpmFactor /= num;
		AvgSkid /= wheels.Length;
	}
}
