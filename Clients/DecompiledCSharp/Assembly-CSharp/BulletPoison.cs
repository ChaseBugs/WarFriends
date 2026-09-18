using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TweenPosition))]
public class BulletPoison : BulletSlow
{
	private DestroyableObject mHitDestroyableObject;

	private float mTime = 5f;

	private float mDamageRatio;

	public override void Fire(Vector3 from, Vector3 to)
	{
		base.Fire(from, to);
		BulletSetup bulletSetup = weapon.ammoSetup as BulletSetup;
		mTime = bulletSetup.poisonTime;
		mDamageRatio = bulletSetup.poisonRatio;
	}

	protected override void OnHit()
	{
		TweenPosition component = GetComponent<TweenPosition>();
		if ((bool)component)
		{
			component.enabled = false;
		}
		if (base.mRaycastHit.HasValue)
		{
			DestroyableObject destroyableObject = null;
			if (!(base.mRaycastHit.Value.collider != null) || !DoDamage(base.mRaycastHit.Value.collider.gameObject, base.mRaycastHit.Value, mDirection.normalized * hitForce, flameDamage: false, out mHitDestroyableObject))
			{
				Singleton<HitParticleSystem>.instance.PlayParticle(base.mRaycastHit.Value.point, base.mRaycastHit.Value.normal, 0);
				DecalSystem.Instance.PlayDecal(base.mRaycastHit.Value.point, base.mRaycastHit.Value.normal, 0);
			}
			if (weapon != null)
			{
				weapon.ReportShotHit(this, base.mRaycastHit.Value.point, isNetworkCopy, destroyableObject);
			}
			else
			{
				Debug.LogError("Bullet with NO weapon");
			}
		}
		if (mHitDestroyableObject != null)
		{
			StartCoroutine(DoPoison());
		}
		else
		{
			DestroyPooled(0.5f);
		}
	}

	private IEnumerator DoPoison()
	{
		float startTime = Time.time;
		while (Time.time < startTime + mTime)
		{
			mHitDestroyableObject.Poison(ammoDamageAmount / mTime * mDamageRatio, Vector3.zero, weapon, owner, isNetworkCopy);
			yield return new WaitForSeconds(1f);
		}
		DestroyPooled();
	}
}
