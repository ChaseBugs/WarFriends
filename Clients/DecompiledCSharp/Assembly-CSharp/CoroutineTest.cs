using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
	public float scale = 1f;

	public float offset;

	public Vector3 dir = Vector3.up;

	private void Start()
	{
	}

	private void LateUpdate()
	{
		base.transform.localScale = Vector3.one * scale;
		base.transform.localPosition += offset * dir;
	}
}
