using UnityEngine;

public class ShotTrailRenderer : Singleton<ShotTrailRenderer>
{
	public ShotTrail trailPrefab;

	public ShotTrail PlayShot(Vector3 from, Vector3 to)
	{
		ObjectPool ammoPool = ObjectPoolDatabase.ammoPool;
		ShotTrail shotTrail = ammoPool.Instantiate(trailPrefab, from, Quaternion.identity) as ShotTrail;
		if (shotTrail != null)
		{
			TweenPosition.Begin(shotTrail.gameObject, 0.3f, from, to, useLocal: false);
			shotTrail.PlayShot();
			return shotTrail;
		}
		return null;
	}

	public ShotTrail PlayShot(Vector3 from, Vector3 to, float time)
	{
		ShotTrail shotTrail = PlayShot(from, to);
		if (shotTrail != null)
		{
			shotTrail.trail.time = time;
		}
		return shotTrail;
	}
}
