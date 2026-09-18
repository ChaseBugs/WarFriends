using UnityEngine;

[RequireComponent(typeof(Camera))]
[AddComponentMenu("AQUAS/AQUAS Camera")]
public class AQUAS_Camera : MonoBehaviour
{
	private void Start()
	{
		Set();
	}

	private void Set()
	{
		if (GetComponent<Camera>().depthTextureMode == DepthTextureMode.None)
		{
			GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
		}
	}
}
