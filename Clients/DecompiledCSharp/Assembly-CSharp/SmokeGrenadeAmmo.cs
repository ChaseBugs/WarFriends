using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeGrenadeAmmo : GrenadeAmmoContent
{
	public override void LoadAmmoSetup(AmmoSetup setup)
	{
		base.LoadAmmoSetup(setup);
	}

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
		ParticleSystem particleSystem = Singleton<HitParticleSystem>.instance.PlayParticle(base.transform, Vector3.up, "SmokeGrenade");
		SmokeGrenadeAmmoSetup smokeGrenadeAmmoSetup = base.mSetup as SmokeGrenadeAmmoSetup;
		if (base.mOwner.fraction == PlayerController.currentPlayer.fraction)
		{
			particleSystem.startColor = smokeGrenadeAmmoSetup.smokeColorFake;
			particleSystem.emissionRate = 1.5f;
			particleSystem.startSize = 3f;
		}
		else
		{
			particleSystem.startColor = smokeGrenadeAmmoSetup.smokeColorFull;
			particleSystem.emissionRate = 3f;
			particleSystem.startSize = 5f;
		}
		grenade.DestroyPooled(((SmokeGrenadeAmmoSetup)base.mSetup).lastTime);
		StartCoroutine(CheckForDestroyableObjects());
	}

	private IEnumerator CheckForDestroyableObjects()
	{
		while (true)
		{
			Collider[] overlapingObjects = Physics.OverlapSphere(base.transform.position, ((SmokeGrenadeAmmoSetup)base.mSetup).radius, TagsAndLayers.destroyableObjectsMask);
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
				GameShootableEntity shoootablEntity = destroyableObject2.GetComponent<GameShootableEntity>();
				if (!(shoootablEntity != null))
				{
				}
			}
			yield return new WaitForSeconds(1f);
		}
	}
}
