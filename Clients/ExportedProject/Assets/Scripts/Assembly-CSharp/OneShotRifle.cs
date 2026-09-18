using UnityEngine;

public class OneShotRifle : Gun
{
	public override float nextShootProgress => Mathf.Clamp01((TimeManager.realTimeWithoutPauses - base.lastShotTime) / (float)cadence);

	public override float ComputeFlyTimeToTarget(Vector3 position)
	{
		return 0f;
	}
}
