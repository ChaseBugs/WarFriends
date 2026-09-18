using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class GrenadeAmmoSetup : GrenadeAmmoBaseSetup
{
	public float hurtRadius = 2f;

	public float deadRadius = 1f;

	public Vector3 exposionCoef = new Vector3(1.5f, 3f, 1.5f);

	public float additionalUpForce = 12f;

	public ObscuredFloat explodeDamageAmount = 350f;

	public override void ScaleDamage(float scale)
	{
		base.ScaleDamage(scale);
		explodeDamageAmount = (float)explodeDamageAmount * scale;
	}
}
