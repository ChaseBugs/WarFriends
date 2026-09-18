using UnityEngine;

public class SpritesWorkAround : MonoBehaviour
{
	public MeshRenderer meshRenderer;

	private void Awake()
	{
		meshRenderer.sharedMaterial.shader = Shader.Find("SpritesWorkaround");
	}
}
