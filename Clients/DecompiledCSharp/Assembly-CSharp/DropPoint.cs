using UnityEngine;

public class DropPoint : MonoBehaviour
{
	public bool startPoint;

	public MagneticObject droppedObject;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(base.transform.position, Vector3.one * 0.1f);
		Gizmos.DrawCube(base.transform.position, Vector3.one * 0.05f);
	}
}
