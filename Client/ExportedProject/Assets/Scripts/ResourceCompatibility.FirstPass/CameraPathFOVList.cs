using UnityEngine;

[ExecuteInEditMode]
public class CameraPathFOVList : CameraPathPointList
{
	public enum Interpolation
	{
		None,
		Linear,
		SmoothStep
	}

	public Interpolation interpolation;

	private const float DEFAULT_FOV = 60f;

	public bool listEnabled;

	public new CameraPathFOV Item => null;

	private float defaultFOV => 0f;

	private void OnEnable()
	{
	}

	public override void Init(CameraPath _cameraPath)
	{
	}

	public override void CleanUp()
	{
	}

	public void AddFOV(CameraPathControlPoint atPoint)
	{
	}

	public CameraPathFOV AddFOV(CameraPathControlPoint curvePointA, CameraPathControlPoint curvePointB, float curvePercetage, float fov)
	{
		return null;
	}

	public float GetFOV(float percentage)
	{
		return 0f;
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
