public class FlameAmmoSetup : AmmoSetup
{
	public float radius = 3f;

	public float shotHalfAngle = 10f;

	public float shotHalfAngleNear = 30f;

	public float minDamage = 10f;

	public float maxDamage = 100f;

	public float hitForceMax = 20f;

	public bool flatY;

	public override void ScaleDamage(float scale)
	{
		minDamage *= scale;
		maxDamage *= scale;
	}
}
