using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGrenadeAmmo : GrenadeAmmoContent
{
	public override void ExplodeImplementation(Vector3 position)
	{
		base.ExplodeImplementation(position);
		DoSmoke();
	}

	public override void ExplodeRPCImplementation(Vector3 position)
	{
		base.ExplodeRPCImplementation(position);
		DoSmoke();
	}

	private void DoSmoke()
	{
		Singleton<HitParticleSystem>.instance.PlayParticle(base.transform, Vector3.up, "PoisonGrenade");
		grenade.DestroyPooled(((PoisonGrenadeAmmoSetup)base.mSetup).lastTime);
		if (grenade.photonView.isMine)
		{
			StartCoroutine(CheckForDestroyableObjects());
		}
	}

	private IEnumerator CheckForDestroyableObjects()
	{
		while (true)
		{
			PoisonGrenadeAmmoSetup setup = base.mSetup as PoisonGrenadeAmmoSetup;
			yield return new WaitForSeconds(1f);
			Collider[] overlapingObjects = Physics.OverlapSphere(base.transform.position, setup.radius, TagsAndLayers.destroyableObjectsMask);
			List<DestroyableObject> destroyableObjects = new List<DestroyableObject>();
			Collider[] array = overlapingObjects;
			foreach (Collider overlapingObject in array)
			{
				if (!TagsAndLayers.IsDestroyableObject(overlapingObject.gameObject))
				{
					continue;
				}
				DestroyableObject destroyableObject = overlapingObject.gameObject.GetComponent<DestroyableObject>();
				if (destroyableObject == null)
				{
					continue;
				}
				if (destroyableObject is DestroyableObjectpart)
				{
					DestroyableObjectpart d = destroyableObject as DestroyableObjectpart;
					if (!(d != null) || !(d.ownerDestroyableObject != null) || !destroyableObjects.Contains(d.ownerDestroyableObject))
					{
						destroyableObjects.Add(d.ownerDestroyableObject);
					}
				}
				else
				{
					destroyableObjects.Add(destroyableObject);
				}
			}
			foreach (DestroyableObject destroyableObject2 in destroyableObjects)
			{
				destroyableObject2.Poison(base.mSetup.damageAmount, default(Vector3), base.weapon, base.mOwner, isNetworkCopy: false);
			}
			yield return new WaitForSeconds(Random.Range(0.9f, 1.5f));
		}
	}
}
