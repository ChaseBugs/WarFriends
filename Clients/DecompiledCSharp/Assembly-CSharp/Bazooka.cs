using UnityEngine;

public class Bazooka : PhysicalAmmoWeapon
{
	public override float ComputeFlyTimeToTarget(Vector3 position)
	{
		MissileSetup missileSetup = base.ammoSetup as MissileSetup;
		if (missileSetup != null)
		{
			float num = Vector3.Distance(spawnPoint.transform.position, position);
			return num / missileSetup.speed + 0.1f;
		}
		return 0.1f;
	}
}
