using UnityEngine;

public class BazookaFangs : Bazooka
{
	public Bazooka add;

	public void SetupGun()
	{
		add.owner = owner;
		add.cadence = 0f;
	}

	protected override Ammo Shoot(Vector3 position, bool isNetworkCopy)
	{
		add.isFake = true;
		for (int i = 0; i < 3; i++)
		{
			InvokeAfterRealTime(delegate
			{
				add.Fire(position);
				add.isFake = !add.isFake;
			}, 0.1f * (float)(i + 1));
		}
		return base.Shoot(position, isNetworkCopy);
	}
}
