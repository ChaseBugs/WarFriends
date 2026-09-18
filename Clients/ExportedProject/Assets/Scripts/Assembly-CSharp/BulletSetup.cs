using UnityEngine;

public class BulletSetup : AmmoSetup
{
	public float speed = 10f;

	public float checkDistance = 1f;

	public float trailSize = 1.5f;

	public float trailWidth = 0.1f;

	public float trailFakeWidth = 0.04f;

	public float thinTrailSize = 0.2f;

	public float thinTrailWidth = 0.03f;

	public float thinTrailFakeWidth = 0.03f;

	public float fakeSpeedFactor = 1.5f;

	public string fakeShotTexture;

	public string realShotTexture;

	public string shieldShotTexture;

	public float speedMultiplayer = 1f;

	public float poisonTime;

	public float poisonRatio;

	[HideInInspector]
	public bool useThinTrail;

	public float fakeSpeed => speed * fakeSpeedFactor;

	public float bulletSpeed
	{
		get
		{
			return speed * speedMultiplayer;
		}
		set
		{
			speed = value;
		}
	}

	public override void Reset()
	{
		base.Reset();
		speedMultiplayer = 1f;
		useThinTrail = false;
	}

	public float GetTrailSize()
	{
		return (!useThinTrail) ? trailSize : thinTrailSize;
	}

	public float GetTrailWidth()
	{
		return (!useThinTrail) ? trailWidth : thinTrailWidth;
	}

	public float GetTrailFakeWidth()
	{
		return (!useThinTrail) ? trailFakeWidth : thinTrailFakeWidth;
	}
}
