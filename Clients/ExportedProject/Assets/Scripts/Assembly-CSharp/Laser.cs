using System;
using UnityEngine;

public class Laser : Ammo
{
	private WSP_LaserBeamWS mLaserBeam;

	private Vector3 mDirection;

	protected override void Awake()
	{
		base.Awake();
		mLaserBeam = GetComponent<WSP_LaserBeamWS>();
	}

	public override void Fire(Vector3 from, Vector3 to)
	{
		mDirection = to - from;
		Vector3 normalized = (to - from).normalized;
		if (Vector3.Distance(from, to) > 50f)
		{
			to = from + normalized * 50f;
			mDirection = to - from;
		}
		Ray ray = new Ray(from + normalized * 0.1f, normalized);
		int layerMask = Singleton<TagsAndLayers>.instance.GetBulletMask(weapon.fraction, weapon.ignoreLayersMask);
		RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, layerMask);
		Array.Sort(array, (RaycastHit a, RaycastHit b) => a.distance.CompareTo(b.distance));
		bool flag = false;
		RaycastHit[] array2 = array;
		for (int num = 0; num < array2.Length; num++)
		{
			RaycastHit raycastHit = array2[num];
			if (TagsAndLayers.IsStatic(raycastHit.transform.gameObject))
			{
				AnimateShot(from, raycastHit.point, isHit: false);
				flag = true;
				break;
			}
			DestroyableObject component = raycastHit.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				component.Shoot(ammoDamageAmount, raycastHit.point, Vector3.zero, weapon, owner, isNetworkCopy, isCritical: false);
				if (component.isMetal)
				{
					AnimateShot(from, raycastHit.point, isHit: false);
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			AnimateShot(from, to, isHit: false);
		}
	}

	private void AnimateShot(Vector3 from, Vector3 to, bool isHit)
	{
		mLaserBeam.LaserFireEmitPointTrans.position = from;
		mLaserBeam.TargetHitTransform.position = to;
		mLaserBeam.CurrentTarget.position = to;
		mLaserBeam.FireLaser();
		DestroyPooled(3f);
	}
}
