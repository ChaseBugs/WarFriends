using UnityEngine;

[AddComponentMenu("Image Effects/Color Adjustments/ApplyShader")]
[ExecuteInEditMode]
public class ApplyShader : ImageEffectBase
{
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, base.material);
	}
}
