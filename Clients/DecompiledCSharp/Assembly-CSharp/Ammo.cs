using System;
using UnityEngine;

public abstract class Ammo : PoolableObject, TimeScaleIgnorable, IFraction
{
	public enum ShotType
	{
		Real,
		Fake,
		Shield
	}

	public float ammoDamageAmount = 40f;

	public bool isFake;

	public Weapon weapon;

	public ShotType type;

	private static ObjectPool mAmmoPool;

	public bool isNetworkCopy;

	private bool mIsCritical;

	public bool ignoreTimeScale { get; set; }

	public static ObjectPool ammoPool
	{
		get
		{
			if (mAmmoPool == null)
			{
				mAmmoPool = ObjectPool.GetPool("AmmoPool");
			}
			return mAmmoPool;
		}
		set
		{
			mAmmoPool = value;
		}
	}

	public Fractions fraction
	{
		get
		{
			return weapon.fraction;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public IFraction owner => weapon.owner;

	public abstract void Fire(Vector3 from, Vector3 to);

	public virtual bool DoDamage(GameObject obj, RaycastHit hit, Vector3 force, bool flameDamage, out DestroyableObject damagedObject)
	{
		damagedObject = null;
		if (TagsAndLayers.IsDestroyableObject(obj))
		{
			damagedObject = obj.GetComponent<DestroyableObject>();
			if (damagedObject != null)
			{
				if (damagedObject.fraction == fraction)
				{
					PlayerController playerController = owner as PlayerController;
					if (playerController != null && playerController.friendlyKillOver)
					{
						return false;
					}
				}
				if (flameDamage)
				{
					damagedObject.Burn(ammoDamageAmount, hit.point, force, weapon, owner, isNetworkCopy, mIsCritical);
				}
				else
				{
					damagedObject.Shoot(ammoDamageAmount, hit.point, force, weapon, owner, isNetworkCopy, mIsCritical);
				}
				return true;
			}
		}
		return false;
	}

	public virtual void LoadAmmoSetup(AmmoSetup setup)
	{
		if (UnityEngine.Random.value < (float)setup.criticalProbability)
		{
			mIsCritical = true;
			ammoDamageAmount = (float)setup.damageAmount * (float)setup.criticalAmount;
		}
		else
		{
			mIsCritical = false;
			ammoDamageAmount = setup.damageAmount;
		}
	}

	public static ShotType GetShotType(GameShootableEntity.ShotTarget target)
	{
		if (target.type == GameShootableEntity.ShotTargetType.Shield)
		{
			return ShotType.Shield;
		}
		return ShotType.Real;
	}
}
