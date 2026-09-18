using System.Collections.Generic;
using UnityEngine;

public class FlameAmmo : Ammo
{
	public const int hitsPerShot = 6;

	public const float timeBetweenShots = 0.35f;

	private FlameAmmoSetup mSetup;

	private bool mCheckHit;

	private int mHitCheckCount;

	private float mNextHitCheck;

	public override void Fire(Vector3 from, Vector3 to)
	{
		mCheckHit = true;
		mHitCheckCount = 0;
		mNextHitCheck = TimeManager.realTimeWithoutPauses + 0.35f;
	}

	public override void LoadAmmoSetup(AmmoSetup setup)
	{
		base.LoadAmmoSetup(setup);
		FlameAmmoSetup flameAmmoSetup = setup as FlameAmmoSetup;
		if (flameAmmoSetup != null)
		{
			mSetup = flameAmmoSetup;
		}
		else
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to gun");
		}
	}

	protected void Update()
	{
		if (mCheckHit && TimeManager.realTimeWithoutPauses > mNextHitCheck)
		{
			mNextHitCheck += 0.35f;
			CheckHit();
			mHitCheckCount++;
			if (mHitCheckCount >= 6)
			{
				mCheckHit = false;
				DestroyPooled(0.5f);
			}
		}
	}

	private void CheckHit()
	{
		Vector3 position = weapon.spawnPoint.transform.position;
		Collider[] array = Physics.OverlapSphere(position, mSetup.radius);
		List<DestroyableObject> list = new List<DestroyableObject>(5);
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			Vector3 vector = collider.transform.position;
			BoxCollider boxCollider = collider.GetComponent<Collider>() as BoxCollider;
			if (boxCollider != null)
			{
				vector = collider.transform.TransformPoint(boxCollider.center);
			}
			else
			{
				SphereCollider sphereCollider = collider.GetComponent<Collider>() as SphereCollider;
				if (sphereCollider != null)
				{
					vector = collider.transform.TransformPoint(sphereCollider.center);
				}
			}
			DestroyableObject component = collider.GetComponent<DestroyableObject>();
			if (!(component != null))
			{
				continue;
			}
			IFraction fraction = component.owner;
			if (fraction == null || fraction == weapon.owner || fraction.fraction == weapon.owner.fraction)
			{
				continue;
			}
			float num = Vector3.Distance(position, vector);
			Ray ray = new Ray(position, vector - position);
			RaycastHit hit = default(RaycastHit);
			if (num < 0.3f)
			{
				continue;
			}
			Vector3 forward = (weapon.owner as MonoBehaviour).transform.forward;
			Vector3 vector2 = vector - position;
			if (mSetup.flatY)
			{
				forward.y = 0f;
			}
			float f = Vector3.Angle(forward, vector2);
			float t = Mathf.Pow(num, 0.25f);
			float num2 = Mathf.Lerp(mSetup.shotHalfAngleNear, mSetup.shotHalfAngle, t);
			if (!(Mathf.Abs(f) < num2))
			{
				continue;
			}
			float num3 = 1f - num / mSetup.radius;
			mSetup.hitForce = num3 * mSetup.hitForceMax;
			mSetup.damageAmount = Mathf.Lerp(mSetup.minDamage, mSetup.maxDamage, num3);
			LoadAmmoSetup(mSetup);
			DestroyableObjectpart component2 = collider.gameObject.GetComponent<DestroyableObjectpart>();
			if (component2 != null && component2.ownerDestroyableObject != null)
			{
				if (list.Contains(component2.ownerDestroyableObject))
				{
					continue;
				}
				list.Add(component2.ownerDestroyableObject);
			}
			DoDamage(collider.gameObject, hit, num3 * mSetup.hitForceMax * vector2 / num, flameDamage: true, out var _);
		}
	}
}
