using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class MissileSetup : ExplosiveSetup
{
	public enum MissileType
	{
		RpgBasic,
		Small,
		Tank,
		RpgBold
	}

	public float speed = 2f;

	public float hurtRadius = 2f;

	public float deadRadius = 1f;

	public Vector3 exposionCoef = new Vector3(1.5f, 3f, 1.5f);

	public float additionalUpForce = 12f;

	public float stopTime;

	public ObscuredFloat explodeDamageAmount = 350f;

	public MissileType missileType;

	public bool curvedTrajectory;

	public Vector2 minMaxRotations = new Vector2(0.8f, 1.6f);

	public AnimationCurve rotationProfile = new AnimationCurve(new Keyframe(0f, 0f, 0f, 1f), new Keyframe(0.5f, 1f), new Keyframe(1f, 0f, -1f, 0f));

	public float baseRotationMagnitude = 0.45f;

	public override void ScaleDamage(float scale)
	{
		base.ScaleDamage(scale);
		explodeDamageAmount = (float)explodeDamageAmount * scale;
	}
}
