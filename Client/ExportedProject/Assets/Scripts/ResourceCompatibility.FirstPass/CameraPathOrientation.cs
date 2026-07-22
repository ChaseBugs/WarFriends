using UnityEngine;

[ExecuteInEditMode]
public class CameraPathOrientation : CameraPathPoint
{
	public Quaternion rotation;

	public Transform lookAt;

	private void OnEnable()
	{
	}
}
