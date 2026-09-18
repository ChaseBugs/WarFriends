using System;
using UnityEngine;

public class Parachute : PoolableObject
{
	public float parachuteDrag = 1f;

	public float speed = 1f;

	public Vector3 flyDirection = Vector3.forward;

	private float hangingTimeOffset;

	public MeshRenderer parashuteRenderer;

	public PhysicsEventsListener physicsEventsListenerWeight;

	public Rigidbody weight;

	public Transform snapTransform;

	private Color mColor;

	private bool mFreezed;

	private PhotonView mPhotonView;

	private readonly PhotonTransform mPhotonTransform = new PhotonTransform();

	private bool mWasCollision;

	public Action Landed;

	protected override void Awake()
	{
		base.Awake();
		mPhotonView = GetComponent<PhotonView>();
		snapTransform = weight.transform;
	}

	public override void SafeStart()
	{
		base.SafeStart();
		PhysicsEventsListener physicsEventsListener = physicsEventsListenerWeight;
		physicsEventsListener.onCollisionEnter = (Action<Collision>)Delegate.Combine(physicsEventsListener.onCollisionEnter, new Action<Collision>(OnCollisionEnter));
		mColor = parashuteRenderer.material.GetColor("_Color");
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		StopAllCoroutines();
		mWasCollision = false;
		Landed = null;
		mColor = Color.white;
		mColor.a = 0f;
		parashuteRenderer.material.SetColor("_Color", mColor);
		parashuteRenderer.material.shader = Shader.Find("Mobile/Diffuse");
		hangingTimeOffset = UnityEngine.Random.value;
		if (mPhotonView.isMine)
		{
			weight.isKinematic = false;
		}
		else
		{
			weight.isKinematic = true;
		}
		mPhotonTransform.Reset();
		mFreezed = false;
	}

	public void Freeze(bool freeze)
	{
		weight.isKinematic = freeze;
		mFreezed = freeze;
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		mColor = Color.white;
		parashuteRenderer.material.SetColor("_Color", mColor);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!mWasCollision)
		{
			mWasCollision = true;
			parashuteRenderer.material.shader = Shader.Find("Legacy Shaders/Transparent/DiffuseNew");
			if (Landed != null)
			{
				Landed();
			}
			DestroyPooled(3f);
			mPhotonView.RPC("LandedNetwork", PhotonTargets.Others);
		}
	}

	[PunRPC]
	private void LandedNetwork()
	{
		if (!mWasCollision)
		{
			mWasCollision = true;
			parashuteRenderer.material.shader = Shader.Find("Legacy Shaders/Transparent/DiffuseNew");
			DestroyPooled(3f);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		base.transform.position = new Vector3(1000f, 1000f, 1000f);
		mPhotonTransform.Reset();
	}

	private void FixedUpdate()
	{
		if (mPhotonView.isMine && !mFreezed)
		{
			if (!mWasCollision)
			{
				float num = (((int)(Time.time * 0.5f + hangingTimeOffset) % 2 != 0) ? (-1f) : 1f);
				Vector3 vector = Vector3.up + 0.3f * num * Vector3.Cross(Vector3.up, flyDirection);
				vector.Normalize();
				float num2 = Vector3.Angle(vector, base.transform.up) / 180f;
				Vector3 vector2 = Vector3.Cross(Vector3.up, vector) * parachuteDrag * num2;
				Vector3 torque = vector2 - weight.angularVelocity;
				weight.AddTorque(torque, ForceMode.VelocityChange);
				weight.AddForce(flyDirection * speed * 0.2f);
			}
			else
			{
				weight.AddForce(flyDirection * speed * 0.05f);
			}
		}
	}

	protected void Update()
	{
		if (mWasCollision)
		{
			mColor.a -= 0.5f * Time.deltaTime;
			parashuteRenderer.material.SetColor("_Color", mColor);
		}
		if (!mPhotonView.isMine)
		{
			mPhotonTransform.Update(snapTransform);
		}
	}

	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		mPhotonTransform.OnPhotonSerializeView(snapTransform, stream, info);
	}
}
