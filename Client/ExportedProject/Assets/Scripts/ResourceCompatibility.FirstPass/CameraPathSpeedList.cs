using UnityEngine;

[ExecuteInEditMode]
public class CameraPathSpeedList : CameraPathPointList
{
	public enum Interpolation
	{
		None,
		Linear,
		SmoothStep
	}

	public Interpolation interpolation;

	[SerializeField]
	private bool _enabled;

	public new CameraPathSpeed Item => null;

	public bool listEnabled
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void OnEnable()
	{
	}

	public override void Init(CameraPath _cameraPath)
	{
	}

	public void AddSpeedPoint(CameraPathControlPoint atPoint)
	{
	}

	public CameraPathSpeed AddSpeedPoint(CameraPathControlPoint curvePointA, CameraPathControlPoint curvePointB, float curvePercetage)
	{
		return null;
	}

	public float GetSpeed(float percentage)
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
