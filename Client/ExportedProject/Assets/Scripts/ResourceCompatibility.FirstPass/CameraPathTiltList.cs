using UnityEngine;

[ExecuteInEditMode]
public class CameraPathTiltList : CameraPathPointList
{
	public enum Interpolation
	{
		None,
		Linear,
		SmoothStep
	}

	public Interpolation interpolation;

	public bool listEnabled;

	public float autoSensitivity;

	public new CameraPathTilt Item => null;

	private void OnEnable()
	{
	}

	public override void Init(CameraPath _cameraPath)
	{
	}

	public override void CleanUp()
	{
	}

	public void AddTilt(CameraPathControlPoint atPoint)
	{
	}

	public CameraPathTilt AddTilt(CameraPathControlPoint curvePointA, CameraPathControlPoint curvePointB, float curvePercetage, float tilt)
	{
		return null;
	}

	public float GetTilt(float percentage)
	{
		return 0f;
	}

	public void AutoSetTilts()
	{
	}

	public void AutoSetTilt(CameraPathTilt point)
	{
	}

	private float LinearInterpolation(float percentage)
	{
		return 0f;
	}

	private float SmoothStepInterpolation(float percentage)
	{
		return 0f;
	}
}
