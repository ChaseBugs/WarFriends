using UnityEngine;

public class BoundsDrawer : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
		Bounds bounds = GetComponent<Renderer>().bounds;
		Vector3 vector = bounds.center + bounds.extents;
		Vector3 start = bounds.center + Vector3.Scale(bounds.extents, new Vector3(-1f, 1f, 1f));
		Vector3 vector2 = bounds.center + Vector3.Scale(bounds.extents, new Vector3(1f, 1f, -1f));
		Vector3 vector3 = bounds.center + Vector3.Scale(bounds.extents, new Vector3(-1f, 1f, -1f));
		Vector3 vector4 = bounds.center + Vector3.Scale(bounds.extents, new Vector3(1f, -1f, 1f));
		Vector3 vector5 = bounds.center + Vector3.Scale(bounds.extents, new Vector3(-1f, -1f, 1f));
		Vector3 end = bounds.center + Vector3.Scale(bounds.extents, new Vector3(1f, -1f, -1f));
		Vector3 vector6 = bounds.center + Vector3.Scale(bounds.extents, new Vector3(-1f, -1f, -1f));
		Color green = Color.green;
		CameraLineRenderer.DrawLine(start, vector, green);
		CameraLineRenderer.DrawLine(vector5, vector4, green);
		CameraLineRenderer.DrawLine(vector3, vector2, green);
		CameraLineRenderer.DrawLine(vector6, end, green);
		CameraLineRenderer.DrawLine(start, vector3, green);
		CameraLineRenderer.DrawLine(vector, vector2, green);
		CameraLineRenderer.DrawLine(vector5, vector6, green);
		CameraLineRenderer.DrawLine(vector4, end, green);
		CameraLineRenderer.DrawLine(start, vector5, green);
		CameraLineRenderer.DrawLine(vector, vector4, green);
		CameraLineRenderer.DrawLine(vector3, vector6, green);
		CameraLineRenderer.DrawLine(vector2, end, green);
	}
}
