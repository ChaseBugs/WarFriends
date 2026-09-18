public class ShotGunBulletSetup : BulletSetup
{
	public float shotHalfAngle = 10f;

	public float radius = 3f;

	public float shotHalfAngleNear = 30f;

	public float maxDamage = 100f;

	public float minDamage = 10f;

	public float hitForceMax = 20f;

	public bool flatY;

	public bool shotOnlyMainBullet;

	public override void ScaleDamage(float scale)
	{
		base.ScaleDamage(scale);
		minDamage *= scale;
		maxDamage *= scale;
	}
}
