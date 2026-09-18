using System;
using UnityEngine;

[RequireComponent(typeof(TweenPosition))]
public abstract class BulletBase : Ammo
{
	public float speed = 1f;

	public float distanceToCheck = 1.5f;

	protected LineTrailRenderer mlineTrailRenderer;

	protected Vector3 mDirection;

	protected bool mCheckHit;

	public float trailSize = 1f;

	protected BulletSetup mBulletSetup;

	protected float hitForce;

	public bool isStatic;

	protected Transform mTransform;

	public bool fast;

	private RaycastHit? mRaycastHit1;

	protected RaycastHit? mRaycastHit
	{
		get
		{
			return mRaycastHit1;
		}
		set
		{
			mRaycastHit1 = value;
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		isStatic = false;
	}

	protected override void Awake()
	{
		base.Awake();
		mlineTrailRenderer = GetComponent<LineTrailRenderer>();
		mTransform = base.transform;
	}

	public override void Fire(Vector3 from, Vector3 to)
	{
		if (weapon == null)
		{
			throw new NullReferenceException("WEAPON IS NULL");
		}
	}

	public void AnimateShot(Vector3 from, Vector3 to, bool checkCollision)
	{
		mCheckHit = checkCollision;
		mDirection = to - from;
		mTransform.rotation = Quaternion.LookRotation(from - to) * Quaternion.AngleAxis(-90f, Vector3.up);
		float num = Vector3.Distance(from, to);
		float num2 = 1f - Mathf.Clamp01(distanceToCheck / num);
		if (!mCheckHit)
		{
			num2 = 1f;
		}
		Vector3 toPos = from + num2 * mDirection;
		speed = ((!isFake) ? speed : mBulletSetup.fakeSpeed);
		float num3 = num / speed;
		mlineTrailRenderer.Reset();
		if (isFake)
		{
			if (!string.IsNullOrEmpty(mBulletSetup.fakeShotTexture))
			{
				mlineTrailRenderer.SetSprite(mBulletSetup.fakeShotTexture);
			}
			mlineTrailRenderer.SetWidth(mBulletSetup.GetTrailFakeWidth());
			mlineTrailRenderer.trailLength = trailSize;
			mlineTrailRenderer.disapearTime = TimeManager.GetTimeScaledInterval(trailSize / speed, ignoreTimeScale);
		}
		else
		{
			if (type == ShotType.Real && !string.IsNullOrEmpty(mBulletSetup.realShotTexture))
			{
				mlineTrailRenderer.SetSprite(mBulletSetup.realShotTexture);
			}
			if (type == ShotType.Shield && !string.IsNullOrEmpty(mBulletSetup.shieldShotTexture))
			{
				mlineTrailRenderer.SetSprite(mBulletSetup.shieldShotTexture);
			}
			mlineTrailRenderer.SetWidth(mBulletSetup.GetTrailWidth());
			mlineTrailRenderer.trailLength = trailSize * 2f;
			mlineTrailRenderer.disapearTime = TimeManager.GetTimeScaledInterval(trailSize / speed, ignoreTimeScale);
		}
		if (!isFake)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num3, from, toPos, useLocal: false);
			tweenPosition.ignoreTimeScale = ignoreTimeScale;
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = TryKill;
		}
		else
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, num3 * 2f, from, to + mDirection, useLocal: false);
			tweenPosition2.onFinished = delegate
			{
				DestroyPooled();
			};
		}
	}

	private void TryKill(UITweener tween)
	{
		OnTryKill();
	}

	protected abstract void OnTryKill();

	protected virtual void OnHit()
	{
		TweenPosition component = GetComponent<TweenPosition>();
		if ((bool)component)
		{
			component.enabled = false;
		}
		if (mRaycastHit.HasValue)
		{
			DestroyableObject damagedObject = null;
			if (!(mRaycastHit.Value.collider != null) || !DoDamage(mRaycastHit.Value.collider.gameObject, mRaycastHit.Value, mDirection.normalized * hitForce, flameDamage: false, out damagedObject))
			{
				Singleton<HitParticleSystem>.instance.PlayParticle(mRaycastHit.Value.point, mRaycastHit.Value.normal, 0);
				DecalSystem.Instance.PlayDecal(mRaycastHit.Value.point, mRaycastHit.Value.normal, 0);
			}
			if (weapon != null)
			{
				weapon.ReportShotHit(this, mRaycastHit.Value.point, isNetworkCopy, damagedObject);
			}
			else
			{
				Debug.LogError("Bullet with NO weapon");
			}
		}
		DestroyPooled(0.5f);
	}

	public override void LoadAmmoSetup(AmmoSetup setup)
	{
		base.LoadAmmoSetup(setup);
		BulletSetup bulletSetup = setup as BulletSetup;
		if (bulletSetup != null)
		{
			mBulletSetup = bulletSetup;
			speed = bulletSetup.bulletSpeed;
			distanceToCheck = bulletSetup.checkDistance;
			trailSize = bulletSetup.GetTrailSize();
			hitForce = bulletSetup.hitForce;
		}
		else
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to gun");
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
	}
}
