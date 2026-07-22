using UnityEngine;

[ExecuteInEditMode]
public class CameraPathOrientationList : CameraPathPointList
{
	public enum Interpolation
	{
		None,
		Linear,
		SmoothStep,
		Hermite,
		Cubic
	}

	public Interpolation interpolation;

	public new CameraPathOrientation Item => null;

	private void OnEnable()
	{
	}

	public override void Init(CameraPath _cameraPath)
	{
	}

	public override void CleanUp()
	{
	}

	public void AddOrientation(CameraPathControlPoint atPoint)
	{
	}

	public CameraPathOrientation AddOrientation(CameraPathControlPoint curvePointA, CameraPathControlPoint curvePointB, float curvePercetage, Quaternion rotation)
	{
		return null;
	}

	public void RemovePoint(CameraPathOrientation orientation)
	{
	}

	public Quaternion GetOrientation(float percentage)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Quaternion);
	}

	private Quaternion LinearInterpolation(float percentage)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Quaternion);
	}

	private Quaternion SmootStepInterpolation(float percentage)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Quaternion);
	}

	private Quaternion CubicInterpolation(float percentage)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Quaternion);
	}

	protected override void RecalculatePoints()
	{
	}
}
