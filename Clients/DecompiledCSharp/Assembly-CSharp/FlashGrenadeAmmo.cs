using System.Collections.Generic;
using UnityEngine;

public class FlashGrenadeAmmo : GrenadeAmmoContent
{
	public override void LoadAmmoSetup(AmmoSetup setup)
	{
		base.LoadAmmoSetup(setup);
	}

	public override void ExplodeImplementation(Vector3 position)
	{
		base.ExplodeImplementation(position);
		DoFlash();
	}

	public override void ExplodeRPCImplementation(Vector3 position)
	{
		base.ExplodeRPCImplementation(position);
		DoFlash();
	}

	private void DoFlash()
	{
		Singleton<HitParticleSystem>.instance.PlayParticle(base.transform.position, Vector3.up, "FlashGrenade");
		CheckForDestroyableObjects();
		grenade.DestroyPooled();
	}

	private void CheckForDestroyableObjects()
	{
		FlashGrenadeAmmoSetup flashGrenadeAmmoSetup = base.mSetup as FlashGrenadeAmmoSetup;
		Collider[] array = Physics.OverlapSphere(base.transform.position, flashGrenadeAmmoSetup.radius, TagsAndLayers.destroyableObjectsMask);
		List<DestroyableObject> list = new List<DestroyableObject>();
		Collider[] array2 = array;
		foreach (Collider collider in array2)
		{
			if (!TagsAndLayers.IsDestroyableObject(collider.gameObject))
			{
				continue;
			}
			DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
			if (component == null)
			{
				continue;
			}
			if (component is DestroyableObjectpart)
			{
				DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
				if (!(destroyableObjectpart != null) || !(destroyableObjectpart.ownerDestroyableObject != null) || !list.Contains(destroyableObjectpart.ownerDestroyableObject))
				{
					list.Add(destroyableObjectpart.ownerDestroyableObject);
				}
			}
			else
			{
				list.Add(component);
			}
		}
		foreach (DestroyableObject item in list)
		{
			EnemyController enemyController = item.owner as EnemyController;
			if (enemyController != null)
			{
			}
			PlayerController playerController = item.owner as PlayerController;
			if (!(playerController != null))
			{
				continue;
			}
			playerController.MakeBlind(flashGrenadeAmmoSetup.lastTime);
			if (playerController.isCurrentPlayer)
			{
				DestroyableObjectpart destroyableObjectpart2 = playerController.destroyableParts.parts[1];
				Vector3 up = destroyableObjectpart2.transform.up;
				up.y = 0f;
				Vector3 to = base.transform.position - playerController.transform.position;
				to.y = 0f;
				float num = Vector3.Angle(up, to);
				float num2 = 1.1f - num / 180f * 0.5f;
				if (num < 30f)
				{
					num2 = 1f;
				}
				Debug.Log("Angle: " + num + "intensity: " + num2);
				GuiScreenSingle<HudScreen>.instance.PlayFlash(3f, num2);
			}
		}
	}
}
