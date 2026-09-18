using UnityEngine;

public class ShotTrail : PoolableObject
{
	public TrailRenderer trail;

	public void PlayShot()
	{
		InvokeAfterRealTimeWithoutPause(DestroyPooled, 3f);
	}
}
