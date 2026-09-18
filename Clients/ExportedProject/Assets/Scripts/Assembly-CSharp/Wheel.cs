using System;
using UnityEngine;

[RequireComponent(typeof(WheelCollider))]
public class Wheel : MonoBehaviour
{
	public Transform wheelModel;

	public float loQualDist = 100f;

	public bool steerable;

	public bool powered;

	[SerializeField]
	private float particleRate = 3f;

	[SerializeField]
	private float slideThreshold = 10f;

	private float spinAngle;

	private float sideSlideFactor;

	private float springCompression;

	private Rigidbody rb;

	private bool leavingSkidTrail;

	private RaycastHit hit;

	private Vector3 relativeVelocity;

	private float sideSlideFactorTarget;

	private float spinoutFactorTarget;

	private float accelAmount;

	private float burnoutFactor;

	private float burnoutGrip;

	private float spinoutGrip;

	private float sideSlideGrip;

	private float minGrip;

	private float springCompressionGripModifier;

	private float burnoutRpm;

	private float skidFactorTarget;

	private Vector3 originalWheelModelPosition;

	public float Rpm { get; private set; }

	public float MaxRpm { get; private set; }

	public float SkidFactor { get; private set; }

	public bool onGround { get; private set; }

	public Transform Hub { get; set; }

	public WheelCollider wheelCollider { get; private set; }

	public CarController car { get; private set; }

	public float suspensionSpringPos { get; private set; }

	private void Awake()
	{
		wheelCollider = GetComponent<Collider>() as WheelCollider;
	}

	private void Start()
	{
		car = base.transform.parent.GetComponent<CarController>();
		if (wheelModel != null)
		{
			originalWheelModelPosition = wheelModel.localPosition;
			base.transform.position = wheelModel.position;
		}
		MaxRpm = car.MaxSpeed / ((float)Math.PI * wheelCollider.radius * 2f) * 60f;
		rb = wheelCollider.attachedRigidbody;
	}

	private void FixedUpdate()
	{
		relativeVelocity = base.transform.InverseTransformDirection(rb.velocity);
		accelAmount = wheelCollider.motorTorque / car.MaxTorque;
		burnoutFactor = 0f;
		if (powered)
		{
			burnoutFactor = (accelAmount - (1f - car.BurnoutTendency)) / (1f - car.BurnoutTendency);
		}
		burnoutRpm = car.MaxSpeed * car.BurnoutTendency / ((float)Math.PI * wheelCollider.radius * 2f) * 60f;
		Rpm = ((!(burnoutRpm > wheelCollider.rpm)) ? wheelCollider.rpm : Mathf.Lerp(wheelCollider.rpm, burnoutRpm, burnoutFactor));
		spinAngle += Rpm * 6f * Time.deltaTime;
		if (wheelCollider.GetGroundHit(out var wheelHit))
		{
			onGround = true;
			suspensionSpringPos = wheelHit.point.y - base.transform.position.y + wheelCollider.radius;
		}
		else
		{
			suspensionSpringPos = 0f - wheelCollider.suspensionDistance;
			onGround = false;
			springCompression = 0f;
			SkidFactor = 0f;
		}
		if (wheelModel != null)
		{
			wheelModel.localPosition = originalWheelModelPosition + Vector3.up * suspensionSpringPos;
			wheelModel.localRotation = Quaternion.AngleAxis(wheelCollider.steerAngle, Vector3.up) * Quaternion.Euler(spinAngle, 0f, 0f);
		}
	}
}
