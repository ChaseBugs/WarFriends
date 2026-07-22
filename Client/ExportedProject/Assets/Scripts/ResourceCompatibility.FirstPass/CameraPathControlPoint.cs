using UnityEngine;

[ExecuteInEditMode]
public class CameraPathControlPoint : MonoBehaviour
{
	public string givenName;

	public string customName;

	public string fullName;

	[SerializeField]
	private Vector3 _position;

	[SerializeField]
	private bool _splitControlPoints;

	[SerializeField]
	private Vector3 _forwardControlPoint;

	[SerializeField]
	private Vector3 _backwardControlPoint;

	[SerializeField]
	private Vector3 _pathDirection;

	public int index;

	public float percentage;

	public float normalisedPercentage;

	public Vector3 localPosition
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 worldPosition
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 forwardControlPointWorld
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 forwardControlPoint
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 forwardControlPointLocal
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 backwardControlPointWorld
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public Vector3 backwardControlPoint
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public bool splitControlPoints
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public Vector3 trackDirection
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public string displayName => null;

	private void OnEnable()
	{
	}

	public void CopyData(CameraPathControlPoint to)
	{
	}
}
