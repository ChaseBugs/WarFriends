using UnityEngine;

public class DestroyableObjectpart : DestroyableObject
{
	public DestroyableObjectMultipleParts ownerDestroyableObject;

	public float weight = 1f;

	public byte index;

	private float baseWeight = 1f;

	public override bool destroyableByBonusBox => ownerDestroyableObject.destroyableByBonusBox;

	public override IFraction owner
	{
		get
		{
			return ownerDestroyableObject.owner;
		}
		set
		{
			ownerDestroyableObject.owner = value;
		}
	}

	public override float health
	{
		get
		{
			if (ownerDestroyableObject == null)
			{
				return 0f;
			}
			return ownerDestroyableObject.health;
		}
	}

	public override float healthRatio
	{
		get
		{
			if (ownerDestroyableObject == null)
			{
				return 0f;
			}
			return ownerDestroyableObject.healthRatio;
		}
		set
		{
			if (ownerDestroyableObject != null)
			{
				ownerDestroyableObject.healthRatio = value;
			}
		}
	}

	public override DestroyableObject mainDestroyableObject => ownerDestroyableObject;

	protected override void Awake()
	{
		base.gameObject.layer = TagsAndLayers.destroyableEntitiesLayerNumber;
		mCachedTransform = base.transform;
		baseWeight = weight;
	}

	public void ResetWeight()
	{
		weight = baseWeight;
	}

	public override void PlaySound(Sounds3DEnum sound)
	{
		ownerDestroyableObject.PlaySound(sound);
	}

	public override void Shoot(float damage, Vector3 hitPos, Vector3 force, Weapon source, IFraction objectOwner, bool isNetworkCopy, bool isCritical)
	{
		shotCoeficient = ownerDestroyableObject.shotCoeficient;
		base.Shoot(damage, hitPos, force, source, objectOwner, isNetworkCopy, isCritical);
	}

	public override bool DoDamage(DamageInfo info, DestroyableObject obj)
	{
		info.damageAmount *= weight;
		info.partIndex = index;
		return ownerDestroyableObject.DoDamage(info, obj);
	}
}
