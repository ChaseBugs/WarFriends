using UnityEngine;

public class UIGeometry
{
	public BetterList<Vector3> verts;

	public BetterList<Vector2> uvs;

	public BetterList<Vector2> uvs2;

	public BetterList<Color32> cols;

	private BetterList<Vector3> mRtpVerts;

	private Vector3 mRtpNormal;

	private Vector4 mRtpTan;

	public bool hasVertices => false;

	public bool hasTransformed => false;

	public void Clear()
	{
	}

	public void ApplyOffset(Vector3 pivotOffset)
	{
	}

	public void ApplyTransform(Matrix4x4 widgetToPanel)
	{
	}

	public void WriteToBuffers(BetterList<Vector3> v, BetterList<Vector2> u, BetterList<Color32> c, BetterList<Vector3> n, BetterList<Vector4> t, BetterList<Vector2> u2)
	{
	}
}
