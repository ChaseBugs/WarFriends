using System;
using UnityEngine;

[Serializable]
public class tk2dSpriteDefinition
{
	public enum ColliderType
	{
		Unset,
		None,
		Box,
		Mesh
	}

	public enum FlipMode
	{
		None,
		Tk2d,
		TPackerCW
	}

	[Serializable]
	public class AttachPoint
	{
		public string name;

		public Vector3 position;

		public float angle;

		public void CopyFrom(AttachPoint src)
		{
		}

		public bool CompareTo(AttachPoint src)
		{
			return false;
		}
	}

	public string name;

	public Vector3[] boundsData;

	public Vector3[] untrimmedBoundsData;

	public Vector2 texelSize;

	public Vector3[] positions;

	public Vector3[] normals;

	public Vector4[] tangents;

	public Vector2[] uvs;

	public int[] indices;

	public Material material;

	[NonSerialized]
	public Material materialInst;

	public int materialId;

	public string sourceTextureGUID;

	public bool extractRegion;

	public int regionX;

	public int regionY;

	public int regionW;

	public int regionH;

	public FlipMode flipped;

	public bool complexGeometry;

	public ColliderType colliderType;

	public Vector3[] colliderVertices;

	public int[] colliderIndicesFwd;

	public int[] colliderIndicesBack;

	public bool colliderConvex;

	public bool colliderSmoothSphereCollisions;

	public AttachPoint[] attachPoints;

	public bool Valid => false;

	public Bounds GetBounds()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Bounds);
	}

	public Bounds GetUntrimmedBounds()
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Bounds);
	}
}
