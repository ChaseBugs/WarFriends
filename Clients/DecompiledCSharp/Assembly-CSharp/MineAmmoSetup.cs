using UnityEngine;

public class MineAmmoSetup : RadiusWeaponSetup
{
	public float hurtRadius = 2f;

	public float deadRadius = 1f;

	public Vector3 exposionCoef = new Vector3(1.5f, 3f, 1.5f);

	public float additionalUpForce = 12f;

	public float explodeAfterTime;

	public float explodeDamageAmount = 350f;
}
