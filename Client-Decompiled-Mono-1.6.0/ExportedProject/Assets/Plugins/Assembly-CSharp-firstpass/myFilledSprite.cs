using UnityEngine;

[AddComponentMenu("2D Toolkit/Sprite/my2dFilledSprite")]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class myFilledSprite : tk2dSprite
{
	public enum Direction
	{
		Vertical = 0,
		Horizontal = 1
	}

	private float actualFract = 0.99999f;

	protected Vector2[] meshUVS;

	[SerializeField]
	private bool mInverse;

	[SerializeField]
	private Direction mDirection;

	public float fillFract
	{
		get
		{
			return actualFract;
		}
		set
		{
			if (value != actualFract)
			{
				actualFract = Mathf.Clamp01(value);
				UpdateVerticesImpl_();
			}
		}
	}

	public bool inverse
	{
		get
		{
			return mInverse;
		}
		set
		{
			mInverse = value;
			UpdateVerticesImpl_();
		}
	}

	public Direction direction
	{
		get
		{
			return mDirection;
		}
		set
		{
			mDirection = value;
			UpdateVerticesImpl_();
		}
	}

	public override void Build()
	{
		tk2dSpriteDefinition tk2dSpriteDefinition2 = collection.spriteDefinitions[base.spriteId];
		meshVertices = new Vector3[tk2dSpriteDefinition2.positions.Length];
		meshColors = new Color32[tk2dSpriteDefinition2.positions.Length];
		meshUVS = new Vector2[tk2dSpriteDefinition2.uvs.Length];
		meshNormals = new Vector3[0];
		meshTangents = new Vector4[0];
		if (tk2dSpriteDefinition2.normals != null && tk2dSpriteDefinition2.normals.Length > 0)
		{
			meshNormals = new Vector3[tk2dSpriteDefinition2.normals.Length];
		}
		if (tk2dSpriteDefinition2.tangents != null && tk2dSpriteDefinition2.tangents.Length > 0)
		{
			meshTangents = new Vector4[tk2dSpriteDefinition2.tangents.Length];
		}
		SetPositions(meshVertices, meshNormals, meshTangents);
		SetColors(meshColors);
		if (mesh == null)
		{
			mesh = new Mesh();
			GetComponent<MeshFilter>().mesh = mesh;
		}
		mesh.Clear();
		mesh.vertices = meshVertices;
		mesh.normals = meshNormals;
		mesh.tangents = meshTangents;
		mesh.colors32 = meshColors;
		mesh.uv = meshUVS;
		mesh.triangles = tk2dSpriteDefinition2.indices;
		UpdateMaterial();
		CreateCollider();
	}

	protected override void UpdateGeometry()
	{
		UpdateGeometryImpl_();
	}

	protected override void UpdateVertices()
	{
		UpdateVerticesImpl_();
	}

	protected void SetPositions()
	{
		tk2dSpriteDefinition tk2dSpriteDefinition2 = collection.spriteDefinitions[base.spriteId];
		bool flag = false;
		flag = collection.spriteDefinitions[base.spriteId].flipped != tk2dSpriteDefinition.FlipMode.None;
		int numVertices = GetNumVertices();
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		if (!flag)
		{
			for (int i = 0; i < numVertices; i++)
			{
				float num3 = tk2dSpriteDefinition2.positions[i].y * _scale.y;
				if (num3 < num)
				{
					num = num3;
					num2 = tk2dSpriteDefinition2.uvs[i].y;
				}
			}
			for (int j = 0; j < numVertices; j++)
			{
				float num4 = ((!mInverse) ? actualFract : (1f - actualFract));
				float num5 = tk2dSpriteDefinition2.positions[j].y * _scale.y - num;
				meshVertices[j].x = tk2dSpriteDefinition2.positions[j].x * _scale.x;
				meshVertices[j].y = num + num5 * num4;
				meshVertices[j].z = tk2dSpriteDefinition2.positions[j].z * _scale.z;
				meshUVS[j].x = tk2dSpriteDefinition2.uvs[j].x;
				num5 = tk2dSpriteDefinition2.uvs[j].y - num2;
				meshUVS[j].y = num2 + num5 * num4;
			}
		}
		else
		{
			for (int k = 0; k < numVertices; k++)
			{
				float num6 = tk2dSpriteDefinition2.positions[k].y * _scale.y;
				if (num6 < num)
				{
					num = num6;
					num2 = tk2dSpriteDefinition2.uvs[k].x;
				}
			}
			for (int l = 0; l < numVertices; l++)
			{
				float num7 = ((!mInverse) ? actualFract : (1f - actualFract));
				float num8 = tk2dSpriteDefinition2.positions[l].y * _scale.y - num;
				meshVertices[l].x = tk2dSpriteDefinition2.positions[l].x * _scale.x;
				meshVertices[l].y = num + num8 * num7;
				meshVertices[l].z = tk2dSpriteDefinition2.positions[l].z * _scale.z;
				meshUVS[l].y = tk2dSpriteDefinition2.uvs[l].y;
				num8 = tk2dSpriteDefinition2.uvs[l].x - num2;
				meshUVS[l].x = num2 + num8 * num7;
			}
		}
		if (meshNormals.Length > 0)
		{
			for (int m = 0; m < numVertices; m++)
			{
				meshNormals[m] = tk2dSpriteDefinition2.normals[m];
			}
		}
		if (meshTangents.Length > 0)
		{
			for (int n = 0; n < numVertices; n++)
			{
				meshTangents[n] = tk2dSpriteDefinition2.tangents[n];
			}
		}
	}

	protected void UpdateVerticesImpl_()
	{
		tk2dSpriteDefinition tk2dSpriteDefinition2 = collection.spriteDefinitions[base.spriteId];
		if (tk2dSpriteDefinition2.normals.Length != meshNormals.Length)
		{
			meshNormals = ((tk2dSpriteDefinition2.normals == null || tk2dSpriteDefinition2.normals.Length <= 0) ? new Vector3[0] : new Vector3[tk2dSpriteDefinition2.normals.Length]);
		}
		if (tk2dSpriteDefinition2.tangents.Length != meshTangents.Length)
		{
			meshTangents = ((tk2dSpriteDefinition2.tangents == null || tk2dSpriteDefinition2.tangents.Length <= 0) ? new Vector4[0] : new Vector4[tk2dSpriteDefinition2.tangents.Length]);
		}
		SetPositions();
		mesh.vertices = meshVertices;
		mesh.normals = meshNormals;
		mesh.tangents = meshTangents;
		mesh.uv = meshUVS;
		mesh.bounds = GetBounds();
	}

	protected void UpdateGeometryImpl_()
	{
		if (mesh == null)
		{
			Build();
		}
		tk2dSpriteDefinition tk2dSpriteDefinition2 = collection.spriteDefinitions[base.spriteId];
		if (meshVertices == null || meshVertices.Length != tk2dSpriteDefinition2.positions.Length)
		{
			meshVertices = new Vector3[tk2dSpriteDefinition2.positions.Length];
			meshNormals = ((tk2dSpriteDefinition2.normals == null || tk2dSpriteDefinition2.normals.Length <= 0) ? new Vector3[0] : new Vector3[tk2dSpriteDefinition2.normals.Length]);
			meshTangents = ((tk2dSpriteDefinition2.tangents == null || tk2dSpriteDefinition2.tangents.Length <= 0) ? new Vector4[0] : new Vector4[tk2dSpriteDefinition2.tangents.Length]);
			meshColors = new Color32[tk2dSpriteDefinition2.positions.Length];
		}
		SetPositions();
		SetColors(meshColors);
		mesh.Clear();
		mesh.vertices = meshVertices;
		mesh.normals = meshNormals;
		mesh.tangents = meshTangents;
		mesh.colors32 = meshColors;
		mesh.uv = meshUVS;
		mesh.bounds = GetBounds();
		mesh.triangles = tk2dSpriteDefinition2.indices;
	}
}
