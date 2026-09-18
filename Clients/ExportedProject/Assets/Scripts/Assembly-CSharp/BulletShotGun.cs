using System;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotGun : BulletBase
{
	public BulletBase bulletPrefab;

	private ShotGunBulletSetup mSetup;

	private Dictionary<DestroyableObject, int> hitCounts = new Dictionary<DestroyableObject, int>();

	protected override void OnTryKill()
	{
		throw new NotImplementedException();
	}

	public override void LoadAmmoSetup(AmmoSetup setup)
	{
		base.LoadAmmoSetup(setup);
		ShotGunBulletSetup shotGunBulletSetup = setup as ShotGunBulletSetup;
		if (shotGunBulletSetup != null)
		{
			mSetup = shotGunBulletSetup;
		}
		else
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to gun");
		}
	}

	private bool ShotRealAtPos(Vector3 from, Vector3 to, Vector3 targetPos)
	{
		Vector3 vector = to - from;
		if (mSetup.flatY)
		{
			vector.y = 0f;
		}
		Vector3 to2 = targetPos - from;
		float f = Vector3.Angle(vector, to2);
		float num = Vector3.Distance(from, targetPos);
		float value = 1f - num / mSetup.radius;
		value = Mathf.Clamp01(value);
		float f2 = Mathf.Clamp01(num / mSetup.radius);
		f2 = Mathf.Sqrt(f2);
		f2 = Mathf.Sqrt(f2);
		float num2 = Mathf.Lerp(mSetup.shotHalfAngleNear, mSetup.shotHalfAngle, f2);
		if (Mathf.Abs(f) < num2)
		{
			mSetup.hitForce = value * mSetup.hitForceMax;
			mSetup.damageAmount = Mathf.Clamp(mSetup.minDamage + (mSetup.maxDamage - mSetup.minDamage) * value, 0f, float.MaxValue);
			BulletSlow bulletSlow = (BulletSlow)Ammo.ammoPool.Instantiate(bulletPrefab, from, Quaternion.identity);
			if (bulletSlow != null)
			{
				bulletSlow.LoadAmmoSetup(mSetup);
				bulletSlow.ignoreTimeScale = ignoreTimeScale;
				bulletSlow.type = type;
				bulletSlow.isFake = false;
				bulletSlow.weapon = weapon;
				bulletSlow.fast = true;
				bulletSlow.Fire(from, targetPos);
				bulletSlow.isNetworkCopy = isNetworkCopy;
			}
			return true;
		}
		return false;
	}

	public override void Fire(Vector3 from, Vector3 to)
	{
		hitCounts.Clear();
		LayerMask bulletMask = Singleton<TagsAndLayers>.instance.GetBulletMask(weapon.fraction, weapon.ignoreLayersMask);
		Collider[] array = Physics.OverlapSphere(from, mSetup.radius, bulletMask);
		int num = 0;
		ShotRealAtPos(from, to, to);
		if (!mSetup.shotOnlyMainBullet)
		{
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
				{
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
					if (component != null)
					{
						IFraction fraction = component.owner;
						if (fraction == null || fraction == weapon.owner || fraction.fraction == weapon.owner.fraction)
						{
							continue;
						}
						if (!hitCounts.TryGetValue(component.mainDestroyableObject, out var value))
						{
							hitCounts[component.mainDestroyableObject] = 0;
							value = 0;
						}
						if (value < 2 && Vector3.Distance(to, vector) > 0.3f && ShotRealAtPos(from, to, vector))
						{
							num++;
							value++;
							hitCounts[component.mainDestroyableObject] = value;
						}
					}
				}
				if (num > 6)
				{
					break;
				}
			}
		}
		int num2 = Mathf.Clamp(4 - num, 0, int.MaxValue);
		for (int j = 0; j < num2; j++)
		{
			BulletBase bulletBase = Ammo.ammoPool.Instantiate(bulletPrefab, from, Quaternion.identity) as BulletBase;
			if (bulletBase != null)
			{
				bulletBase.LoadAmmoSetup(mSetup);
				bulletBase.ignoreTimeScale = ignoreTimeScale;
				bulletBase.isFake = true;
				bulletBase.type = type;
				bulletBase.weapon = weapon;
				bulletBase.isStatic = true;
				bulletBase.fast = true;
				bulletBase.isNetworkCopy = isNetworkCopy;
				float num3 = Vector3.Distance(from, to);
				float num4 = Mathf.Clamp01(num3 / 2f) * 0.25f;
				bulletBase.Fire(from, to + UnityEngine.Random.onUnitSphere * num4);
			}
		}
		DestroyPooled();
	}
}
