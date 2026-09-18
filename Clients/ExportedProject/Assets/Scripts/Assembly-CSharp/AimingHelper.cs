using UnityEngine;

public class AimingHelper : Singleton<AimingHelper>
{
	public Vector3 Aim(Weapon currentWeapon)
	{
		Ray ray = Singleton<GameCamera>.instance.camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hitInfo;
		if (currentWeapon.useAiming)
		{
			RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, (int)Singleton<TagsAndLayers>.instance.GetBulletMask(currentWeapon.fraction, currentWeapon.ignoreLayersMask) | (1 << TagsAndLayers.aimingHelpLayerNumber));
			RaycastHit? raycastHit = null;
			RaycastHit? raycastHit2 = null;
			RaycastHit? raycastHit3 = null;
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				RaycastHit value = array2[i];
				if (TagsAndLayers.IsDestroyableObject(value.collider.transform.gameObject) && (!raycastHit.HasValue || raycastHit.Value.distance > value.distance))
				{
					raycastHit = value;
				}
				else if (value.collider.transform.gameObject.layer == TagsAndLayers.aimingHelpLayerNumber)
				{
					if (!raycastHit2.HasValue)
					{
						raycastHit2 = value;
						continue;
					}
					SphereCollider sphereCollider = raycastHit2.Value.collider as SphereCollider;
					SphereCollider sphereCollider2 = value.collider as SphereCollider;
					if (sphereCollider != null && sphereCollider2 != null)
					{
						float num = GeometryTools.DistanceToLine(ray, raycastHit2.Value.collider.transform.TransformPoint(sphereCollider.center));
						float num2 = GeometryTools.DistanceToLine(ray, value.collider.transform.TransformPoint(sphereCollider2.center));
						if (num2 < num || sphereCollider.radius > sphereCollider2.radius)
						{
							raycastHit2 = value;
						}
					}
				}
				else if (!raycastHit3.HasValue || raycastHit3.Value.distance > value.distance)
				{
					raycastHit3 = value;
				}
			}
			if (raycastHit.HasValue && (!raycastHit3.HasValue || raycastHit.Value.distance < raycastHit3.Value.distance))
			{
				DestroyableObject component = raycastHit.Value.collider.transform.GetComponent<DestroyableObject>();
				Vector3 point = raycastHit.Value.point;
				point += ray.direction.normalized * 0.1f;
				if (component != null)
				{
					return PredictPosition(currentWeapon, point, component.velocity, 0f);
				}
				Debug.LogError("Some object has soldier layer, but not DestroyableObject");
				return raycastHit.Value.point;
			}
			if (raycastHit2.HasValue && (!raycastHit3.HasValue || raycastHit2.Value.distance < raycastHit3.Value.distance))
			{
				GameObject gameObject = raycastHit2.Value.collider.transform.gameObject;
				AimTarget component2 = gameObject.GetComponent<AimTarget>();
				if (component2 != null && component2.targetCollider != null)
				{
					return PredictPosition(currentWeapon, component2.targetPosition, component2.velocity, 0f);
				}
			}
			else if (raycastHit3.HasValue)
			{
				return raycastHit3.Value.point;
			}
		}
		else if (Physics.Raycast(ray, out hitInfo, float.PositiveInfinity, Singleton<TagsAndLayers>.instance.GetBulletMask(currentWeapon.fraction, currentWeapon.ignoreLayersMask)))
		{
			return hitInfo.point;
		}
		return ray.GetPoint(100f);
	}

	public AimTarget AimClickableColliders()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, 1 << TagsAndLayers.aimingHelpLayerNumber);
		RaycastHit? raycastHit = null;
		AimTarget aimTarget = null;
		RaycastHit[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			RaycastHit value = array2[i];
			AimTarget component = value.collider.gameObject.GetComponent<AimTarget>();
			if (component != null && component.isClickable && component.isActive)
			{
				if (component.ignoreLayer)
				{
					component.Click();
				}
				if (aimTarget == null)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.clickableLayer > aimTarget.clickableLayer || aimTarget.ignoreLayer)
				{
					aimTarget = component;
					raycastHit = value;
				}
				else if (component.clickableLayer == aimTarget.clickableLayer && raycastHit.Value.distance > value.distance)
				{
					aimTarget = component;
					raycastHit = value;
				}
			}
		}
		if (aimTarget != null)
		{
			if (!aimTarget.ignoreLayer)
			{
				aimTarget.Click();
			}
			return aimTarget;
		}
		return null;
	}

	public Vector3 PredictPosition(Weapon weapon, Vector3 position, Vector3 velocity, float extraTIme = 0f)
	{
		float num = weapon.ComputeFlyTimeToTarget(position) + extraTIme;
		return position + num * Time.timeScale * velocity;
	}
}
