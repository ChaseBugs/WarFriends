using UnityEngine;

[RequireComponent(typeof(TweenPosition))]
public class BulletSlow : BulletBase
{
	private RaycastHit mHitPom = default(RaycastHit);

	private int mColisionCheckCounter;

	private Ray mDirRay;

	private bool mIsRayHitTesting;

	private Vector3 mLastPos;

	protected override void Awake()
	{
		base.Awake();
	}

	public override void Fire(Vector3 from, Vector3 to)
	{
		if (!fast)
		{
			base.Fire(from, to);
			mDirection = to - from;
			mIsRayHitTesting = false;
			Vector3 normalized = (to - from).normalized;
			if (Vector3.Distance(from, to) > 50f)
			{
				to = from + normalized * 50f;
				mDirection = to - from;
			}
			base.mRaycastHit = null;
			Ray ray = new Ray(from + normalized * 0.1f, normalized);
			if (isFake)
			{
				AnimateShot(from, to, checkCollision: false);
			}
			else if (Physics.Raycast(ray, out mHitPom, Vector3.Distance(from, from + normalized * (mDirection.magnitude - 0.2f)), Singleton<TagsAndLayers>.instance.GetBulletMask(weapon.fraction, weapon.ignoreLayersMask)))
			{
				if (TagsAndLayers.IsStatic(mHitPom.transform.gameObject))
				{
					AnimateShot(from, mHitPom.point, checkCollision: false);
					base.mRaycastHit = mHitPom;
				}
				else
				{
					AnimateShot(from, mHitPom.point, checkCollision: true);
				}
			}
			else
			{
				AnimateShot(from, from + mDirection, checkCollision: true);
			}
			return;
		}
		base.Fire(from, to);
		mDirection = to - from;
		Vector3 normalized2 = (to - from).normalized;
		if (Vector3.Distance(from, to) > 50f)
		{
			to = from + normalized2 * 50f;
			mDirection = to - from;
		}
		base.mRaycastHit = null;
		Ray ray2 = new Ray(from + normalized2 * 0.1f, normalized2);
		if (isFake)
		{
			AnimateShot(from, to, checkCollision: false);
			return;
		}
		int layerMask = ((!isStatic) ? ((int)Singleton<TagsAndLayers>.instance.GetBulletMask(weapon.fraction, weapon.ignoreLayersMask)) : ((int)Singleton<TagsAndLayers>.instance.GetBulletMask(weapon.fraction, weapon.ignoreLayersMask) & ~TagsAndLayers.destroyableObjectsMask));
		if (Physics.Raycast(ray2, out var hitInfo, float.PositiveInfinity, layerMask))
		{
			if (TagsAndLayers.IsStatic(hitInfo.transform.gameObject))
			{
				AnimateShot(from, hitInfo.point, checkCollision: false);
				base.mRaycastHit = hitInfo;
				return;
			}
			base.mRaycastHit = hitInfo;
			AnimateShot(from, to, checkCollision: false);
			DestroyableObject component = hitInfo.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				Vector3 vector = PredictPosition(weapon, hitInfo.point, component.velocity);
				AnimateShot(from, vector, checkCollision: false);
				hitInfo.point = vector;
				base.mRaycastHit = hitInfo;
			}
			else
			{
				AnimateShot(from, to, checkCollision: false);
			}
		}
		else
		{
			AnimateShot(from, to + mDirection, checkCollision: false);
		}
	}

	private Vector3 PredictPosition(Weapon weapon, Vector3 position, Vector3 velocity)
	{
		BulletSetup bulletSetup = weapon.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(weapon.spawnPoint.transform.position, position);
			float num2 = num / bulletSetup.bulletSpeed + 0.1f;
			return position + num2 * Time.timeScale * velocity;
		}
		return position;
	}

	protected override void OnTryKill()
	{
		if (!fast)
		{
			if (ignoreTimeScale)
			{
				if (mCheckHit)
				{
					mDirRay = new Ray(mTransform.position, mDirection);
					float num = distanceToCheck * 2f;
					if (num > 0f && Physics.Raycast(mDirRay, out mHitPom, num, Singleton<TagsAndLayers>.instance.GetBulletMask(weapon.fraction, weapon.ignoreLayersMask)))
					{
						base.mRaycastHit = mHitPom;
						mIsRayHitTesting = false;
						float duration = Vector3.Distance(mTransform.position, mHitPom.point) / speed;
						TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, mTransform.position, mHitPom.point, useLocal: false);
						tweenPosition.method = UITweener.Method.Linear;
						tweenPosition.onFinished = delegate
						{
							OnHit();
						};
						tweenPosition.ignoreTimeScale = ignoreTimeScale;
					}
					else
					{
						mIsRayHitTesting = true;
						mColisionCheckCounter = 0;
						float duration2 = Vector3.Magnitude(mDirection.normalized * distanceToCheck * 7f) / speed;
						TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, duration2, mTransform.position, mTransform.position + mDirection.normalized * distanceToCheck * 5f, useLocal: false);
						tweenPosition2.method = UITweener.Method.Linear;
						tweenPosition2.ignoreTimeScale = ignoreTimeScale;
					}
				}
				else
				{
					OnHit();
				}
			}
			else if (mCheckHit)
			{
				if (!CheckHit())
				{
					float duration3 = Vector3.Magnitude(mDirection.normalized * distanceToCheck * 3f) / speed;
					TweenPosition tweenPosition3 = TweenPosition.Begin(base.gameObject, duration3, mTransform.position, mTransform.position + mDirection.normalized * distanceToCheck * 2f, useLocal: false);
					tweenPosition3.method = UITweener.Method.Linear;
					tweenPosition3.onFinished = OnCheckingAnimationFinished;
					tweenPosition3.ignoreTimeScale = ignoreTimeScale;
					mIsRayHitTesting = true;
					mColisionCheckCounter = int.MinValue;
				}
			}
			else
			{
				OnHit();
			}
		}
		else
		{
			OnHit();
		}
	}

	private TweenPosition MoveBullet(Vector3 from, Vector3 to)
	{
		float num = Vector3.Distance(from, to);
		speed = ((!isFake) ? speed : mBulletSetup.fakeSpeed);
		float duration = num / speed;
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, from, to, useLocal: false);
		tweenPosition.ignoreTimeScale = ignoreTimeScale;
		tweenPosition.method = UITweener.Method.Linear;
		return tweenPosition;
	}

	private void CheckFinished()
	{
		mIsRayHitTesting = false;
		int layerMask = (int)Singleton<TagsAndLayers>.instance.GetBulletMask(weapon.fraction, weapon.ignoreLayersMask) & ~TagsAndLayers.destroyableObjectsMask;
		mDirRay = new Ray(mLastPos, mDirection);
		if (Physics.Raycast(mDirRay, out mHitPom, float.PositiveInfinity, layerMask))
		{
			base.mRaycastHit = mHitPom;
			MoveBullet(mTransform.position, mHitPom.point).onFinished = delegate
			{
				OnHit();
			};
		}
		else
		{
			MoveBullet(mTransform.position, mTransform.position + 20f * mDirection).onFinished = delegate
			{
				DestroyPooled();
			};
		}
	}

	protected void Update()
	{
		if (mIsRayHitTesting)
		{
			mColisionCheckCounter++;
			CheckHit();
			if (mColisionCheckCounter > 5)
			{
				CheckFinished();
			}
		}
		mLastPos = mTransform.position;
	}

	private bool CheckHit()
	{
		mDirRay = new Ray(mLastPos, mDirection);
		float magnitude = (mTransform.position - mLastPos).magnitude;
		float maxDistance = magnitude + 2f * Time.deltaTime;
		if (magnitude > 0f && Physics.Raycast(mDirRay, out mHitPom, maxDistance, Singleton<TagsAndLayers>.instance.GetBulletMask(weapon.fraction, weapon.ignoreLayersMask)))
		{
			base.mRaycastHit = mHitPom;
			OnHit();
			mIsRayHitTesting = false;
			return true;
		}
		return false;
	}

	private void OnCheckingAnimationFinished(UITweener tween)
	{
		mIsRayHitTesting = false;
		if (!CheckHit())
		{
			float duration = Vector3.Magnitude(mDirection) / speed;
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, mTransform.position, mTransform.position + mDirection, useLocal: false);
			tweenPosition.ignoreTimeScale = ignoreTimeScale;
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = delegate
			{
				DestroyPooled();
			};
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		mlineTrailRenderer.Reset();
		StopAllCoroutines();
		GetComponent<TweenPosition>().enabled = true;
	}
}
