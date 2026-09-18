using UnityEngine;

public class AutomaticRifle : Gun
{
	public override float nextShootProgress => Mathf.Clamp01((TimeManager.realTimeWithoutPauses - base.lastShotTime) / (float)cadence);
}
