using UnityEngine;

public class LightMachinegun : AutomaticRifle
{
	public float missProbability = 0.2f;

	protected override Ammo Shoot(Vector3 position, bool isNetworkCopy)
	{
		if (Random.value < missProbability && TimeManager.realTimeWithoutPauses - base.lastShotTime < 0.4f)
		{
			position += new Vector3(Random.Range(-1f, 1f) * 0.5f, Random.Range(-1f, 1f) * 0.2f, Random.Range(-1f, 1f) * 0.5f);
		}
		return base.Shoot(position, isNetworkCopy);
	}
}
