using UnityEngine;

[ExecuteInEditMode]
public class CameraPathPoint : MonoBehaviour
{
	public enum PositionModes
	{
		Free,
		FixedToPoint,
		FixedToPercent
	}

	public PositionModes positionModes;

	public string givenName;

	public string customName;

	public string fullName;

	[SerializeField]
	protected float _percent;

	[SerializeField]
	protected float _animationPercentage;

	public CameraPathControlPoint point;

	public int index;

	public CameraPathControlPoint cpointA;

	public CameraPathControlPoint cpointB;

	public float curvePercentage;

	public Vector3 worldPosition;

	public bool lockPoint;

	public float percent
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float rawPercent => 0f;

	public float animationPercentage
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public string displayName => null;

	private void OnEnable()
	{
	}
}
