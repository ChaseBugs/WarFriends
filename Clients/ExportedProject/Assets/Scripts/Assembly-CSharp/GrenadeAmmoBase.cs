using System;
using UnityEngine;

public class GrenadeAmmoBase : PhysicalAmmo
{
	public enum GrenadeAmmoType
	{
		Frag,
		Poison,
		Smoke,
		Flash,
		Molotov
	}

	public FlashGrenadeAmmo flashGrenade;

	public MolotovGrenadeAmmo molotovGrenade;

	public GrenadeAmmoEnemy fragGrenade;

	public GrenadeAmmoContent grenadeContent;

	protected float mDestroyTime = 0.4f;

	protected Vector3 mDirection;

	protected float mExplodeAfter;

	private float mExplodeTime;

	protected float mFireTime;

	protected bool mIsGogingDown;

	public IFraction mOwner;

	private Rigidbody mRigidBody;

	public GrenadeAmmoBaseSetup mSetup;

	private bool mShouldExplode;

	private Vector3 mVelocity;

	private bool mEnabled = true;

	public PoisonGrenadeAmmo posionGrenade;

	public SmokeGrenadeAmmo smokeGrenade;

	private int mStopMovement;

	public MeshRenderer meshRenderer;

	private Vector3 mFrom;

	private Collider mCollider;

	private Mesh mMesh;

	private Material[] mMaterials;

	private DestroyableObject mDestroyableObject;

	private TrailRenderer mTrail;

	public bool exploded { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		mRigidBody = GetComponent<Rigidbody>();
		mCollider = GetComponent<Collider>();
		mMesh = meshRenderer.GetComponent<MeshFilter>().sharedMesh;
		mMaterials = meshRenderer.sharedMaterials;
		mDestroyableObject = GetComponent<DestroyableObject>();
		mTrail = GetComponentInChildren<TrailRenderer>();
	}

	public void ChangeGrenade(GrenadeAmmoType grenadeType, MeshRenderer grenade, Mesh m)
	{
		if (grenade != null && m != null)
		{
			meshRenderer.GetComponent<MeshFilter>().sharedMesh = m;
			meshRenderer.sharedMaterials = grenade.sharedMaterials;
		}
		else
		{
			meshRenderer.GetComponent<MeshFilter>().sharedMesh = mMesh;
			meshRenderer.sharedMaterials = mMaterials;
		}
		fragGrenade.enabled = false;
		flashGrenade.enabled = false;
		smokeGrenade.enabled = false;
		posionGrenade.enabled = false;
		switch (grenadeType)
		{
		case GrenadeAmmoType.Flash:
			grenadeContent = flashGrenade;
			break;
		case GrenadeAmmoType.Molotov:
			grenadeContent = molotovGrenade;
			break;
		case GrenadeAmmoType.Poison:
			grenadeContent = posionGrenade;
			break;
		case GrenadeAmmoType.Frag:
			grenadeContent = fragGrenade;
			break;
		case GrenadeAmmoType.Smoke:
			grenadeContent = smokeGrenade;
			break;
		}
		grenadeContent.enabled = true;
	}

	public override void Fire(Vector3 from, Vector3 to)
	{
		grenadeContent.grenade = this;
		mFireTime = Time.time;
		mDirection = (to - from).normalized;
		mFrom = from;
		if (mSetup.throwDistance > 0f && (from - to).magnitude > mSetup.throwDistance)
		{
			to = from + mDirection * mSetup.throwDistance;
		}
		mOwner = owner;
		exploded = false;
		mIsGogingDown = false;
		mExplodeAfter = mSetup.explodeAfterTime;
		mCollider.enabled = false;
		Rigidbody component = GetComponent<Rigidbody>();
		component.AddTorque(UnityEngine.Random.onUnitSphere * 10f);
		component.velocity = BallisticVel(from, to, mSetup.angle);
		component.isKinematic = false;
		mShouldExplode = false;
		mRigidBody.drag = 0.2f;
		mStopMovement = 0;
		mEnabled = true;
		mDestroyableObject.ChangeLayer((mOwner != null) ? mOwner.fraction : Fractions.None, isFlying: true);
	}

	private void FixedUpdate()
	{
		if (mEnabled && !exploded && (double)mRigidBody.velocity.y < -1E-08 && !mIsGogingDown)
		{
			mCollider.enabled = true;
			mIsGogingDown = true;
		}
	}

	protected void Update()
	{
		if (!mEnabled || !mShouldExplode)
		{
			return;
		}
		mExplodeTime -= Time.deltaTime;
		if (mExplodeTime < 0f)
		{
			mShouldExplode = false;
			mExplodeTime = 0f;
			if (photonView.isMine)
			{
				Explode();
			}
			else
			{
				ExplodeNetwork(base.transform.position);
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (TagsAndLayers.IsStatic(collision.gameObject) || TagsAndLayers.IsDestroyableObject(collision.gameObject))
		{
			if (!exploded)
			{
				mExplodeTime = TimeManager.GetTimeScaledInterval(mExplodeAfter, ignoreTimeScale);
				mShouldExplode = true;
				GroundHitted();
			}
			mRigidBody.drag = 6f;
		}
	}

	protected virtual void GroundHitted()
	{
		grenadeContent.GroundHitted();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		exploded = false;
		StopAllCoroutines();
		grenadeContent.Init();
		mExplodeTime = 0f;
		mEnabled = true;
		if (mTrail != null)
		{
			mTrail.enabled = true;
		}
	}

	public virtual void Explode()
	{
		if (!exploded)
		{
			exploded = true;
			weapon.ReportShotHit(this, base.transform.position, isNetworkCopy, null);
			ExplodeImplementation(base.transform.position);
			photonView.RPC("ExplodeNetwork", PhotonTargets.Others, base.transform.position);
			if (mTrail != null)
			{
				mTrail.enabled = false;
			}
		}
	}

	public void Pause()
	{
		mVelocity = mRigidBody.velocity;
		mRigidBody.isKinematic = true;
		mEnabled = false;
	}

	public void Resume()
	{
		mRigidBody.isKinematic = false;
		mRigidBody.velocity = mVelocity;
		mEnabled = true;
	}

	protected virtual void ExplodeImplementation(Vector3 position)
	{
		grenadeContent.ExplodeImplementation(position);
	}

	protected virtual void ExplodeRPCImplementation(Vector3 position)
	{
		grenadeContent.ExplodeRPCImplementation(position);
	}

	public override void LoadAmmoSetup(AmmoSetup setup)
	{
		base.LoadAmmoSetup(setup);
		mSetup = (GrenadeAmmoBaseSetup)setup;
		grenadeContent.LoadAmmoSetup(setup);
	}

	[PunRPC]
	public void ExplodeNetwork(Vector3 position)
	{
		if (!exploded)
		{
			exploded = true;
			ExplodeRPCImplementation(position);
		}
	}

	private Vector3 BallisticVel(Vector3 from, Vector3 target, float angle)
	{
		target += 0.2f * Vector3.up;
		Vector3 vector = target - from;
		float y = vector.y;
		y = Mathf.Clamp(y, 0f, float.MaxValue);
		vector.y = 0f;
		float magnitude = vector.magnitude;
		float num = angle * ((float)Math.PI / 180f);
		vector.y = magnitude * Mathf.Tan(num);
		magnitude += y / Mathf.Tan(num);
		magnitude = Mathf.Clamp(magnitude, 0f, float.MaxValue);
		float num2 = Mathf.Sqrt(magnitude * Physics.gravity.magnitude / Mathf.Sin(2f * num));
		Vector3 result = num2 * vector.normalized;
		if (float.IsNaN(result.x) || float.IsNaN(result.y) || float.IsNaN(result.z))
		{
			result = default(Vector3);
		}
		return result;
	}
}
