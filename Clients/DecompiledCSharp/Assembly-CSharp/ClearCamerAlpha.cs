using UnityEngine;

public class ClearCamerAlpha : MonoBehaviour
{
	public Material mat;

	public float alpha = 1f;

	private void OnPostRender()
	{
		GL.PushMatrix();
		GL.LoadOrtho();
		mat.SetFloat("_Alpha", alpha);
		mat.SetPass(0);
		GL.Begin(7);
		GL.Vertex3(0f, 0f, 0.1f);
		GL.Vertex3(1f, 0f, 0.1f);
		GL.Vertex3(1f, 1f, 0.1f);
		GL.Vertex3(0f, 1f, 0.1f);
		GL.End();
		GL.PopMatrix();
	}
}
