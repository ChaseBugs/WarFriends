using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("2D Toolkit/Sprite/tk2dClippedSprite")]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class tk2dClippedSprite : tk2dBaseSprite
{
	private Mesh mesh;

	private Vector2[] meshUvs;

	private Vector3[] meshVertices;

	private Color32[] meshColors;

	public Vector2 _clipBottomLeft = new Vector2(0f, 0f);

	public Vector2 _clipTopRight = new Vector2(1f, 1f);

	private Rect _clipRect = new Rect(0f, 0f, 0f, 0f);

	[SerializeField]
	protected bool _createBoxCollider;

	private Vector3 boundsCenter = Vector3.zero;

	private Vector3 boundsExtents = Vector3.zero;

	public Rect ClipRect
	{
		get
		{
			_clipRect.Set(_clipBottomLeft.x, _clipBottomLeft.y, _clipTopRight.x - _clipBottomLeft.x, _clipTopRight.y - _clipBottomLeft.y);
			return _clipRect;
		}
		set
		{
			Vector2 vector = (clipBottomLeft = new Vector2(value.x, value.y));
			vector.x += value.width;
			vector.y += value.height;
			clipTopRight = vector;
		}
	}

	public Vector2 clipBottomLeft
	{
		get
		{
			return _clipBottomLeft;
		}
		set
		{
			if (value != _clipBottomLeft)
			{
				_clipBottomLeft = new Vector2(value.x, value.y);
				Build();
				UpdateCollider();
			}
		}
	}

	public Vector2 clipTopRight
	{
		get
		{
			return _clipTopRight;
		}
		set
		{
			if (value != _clipTopRight)
			{
				_clipTopRight = new Vector2(value.x, value.y);
				Build();
				UpdateCollider();
			}
		}
	}

	public bool CreateBoxCollider
	{
		get
		{
			return _createBoxCollider;
		}
		set
		{
			if (_createBoxCollider != value)
			{
				_createBoxCollider = value;
				UpdateCollider();
			}
		}
	}

	private new void Awake()
	{
		base.Awake();
		mesh = new Mesh();
		mesh.hideFlags = HideFlags.DontSave;
		GetComponent<MeshFilter>().mesh = mesh;
		if ((bool)base.Collection)
		{
			if (_spriteId < 0 || _spriteId >= base.Collection.Count)
			{
				_spriteId = 0;
			}
			Build();
		}
	}

	protected void OnDestroy()
	{
		if ((bool)mesh)
		{
			Object.Destroy(mesh);
		}
	}

	protected new void SetColors(Color32[] dest)
	{
		if (base.CurrentSprite.positions.Length == 4)
		{
			tk2dSpriteGeomGen.SetSpriteColors(dest, 0, 4, _color, collectionInst.premultipliedAlpha);
		}
	}

	protected void SetGeometry(Vector3[] vertices, Vector2[] uvs)
	{
		tk2dSpriteDefinition currentSprite = base.CurrentSprite;
		float colliderOffsetZ = ((!(boxCollider != null)) ? 0f : boxCollider.center.z);
		float colliderExtentZ = ((!(boxCollider != null)) ? 0.5f : (boxCollider.size.z * 0.5f));
		tk2dSpriteGeomGen.SetClippedSpriteGeom(meshVertices, meshUvs, 0, out boundsCenter, out boundsExtents, currentSprite, _scale, _clipBottomLeft, _clipTopRight, colliderOffsetZ, colliderExtentZ);
		if (currentSprite.positions.Length != 4)
		{
			for (int i = 0; i < vertices.Length; i++)
			{
				ref Vector3 reference = ref vertices[i];
				reference = Vector3.zero;
			}
		}
	}

	public override void Build()
	{
		meshUvs = new Vector2[4];
		meshVertices = new Vector3[4];
		meshColors = new Color32[4];
		SetGeometry(meshVertices, meshUvs);
		SetColors(meshColors);
		if (mesh == null)
		{
			mesh = new Mesh();
			mesh.hideFlags = HideFlags.DontSave;
		}
		else
		{
			mesh.Clear();
		}
		mesh.vertices = meshVertices;
		mesh.colors32 = meshColors;
		mesh.uv = meshUvs;
		int[] array = new int[6];
		tk2dSpriteGeomGen.SetClippedSpriteIndices(array, 0, 0, base.CurrentSprite);
		mesh.triangles = array;
		mesh.RecalculateBounds();
		mesh.bounds = tk2dBaseSprite.AdjustedMeshBounds(mesh.bounds, renderLayer);
		GetComponent<MeshFilter>().mesh = mesh;
		UpdateCollider();
		UpdateMaterial();
	}

	protected override void UpdateGeometry()
	{
		UpdateGeometryImpl();
	}

	protected override void UpdateColors()
	{
		UpdateColorsImpl();
	}

	protected override void UpdateVertices()
	{
		UpdateGeometryImpl();
	}

	protected void UpdateColorsImpl()
	{
		if (meshColors == null || meshColors.Length == 0)
		{
			Build();
			return;
		}
		SetColors(meshColors);
		mesh.colors32 = meshColors;
	}

	protected void UpdateGeometryImpl()
	{
		if (meshVertices == null || meshVertices.Length == 0)
		{
			Build();
			return;
		}
		SetGeometry(meshVertices, meshUvs);
		mesh.vertices = meshVertices;
		mesh.uv = meshUvs;
		mesh.RecalculateBounds();
		mesh.bounds = tk2dBaseSprite.AdjustedMeshBounds(mesh.bounds, renderLayer);
	}

	protected override void UpdateCollider()
	{
		if (CreateBoxCollider)
		{
			if (boxCollider == null)
			{
				boxCollider = GetComponent<BoxCollider>();
				if (boxCollider == null)
				{
					boxCollider = base.gameObject.AddComponent<BoxCollider>();
				}
			}
			boxCollider.size = 2f * boundsExtents;
			boxCollider.center = boundsCenter;
		}
		else if (boxCollider != null)
		{
			Object.Destroy(boxCollider);
		}
	}

	protected override void CreateCollider()
	{
		UpdateCollider();
	}

	protected override void UpdateMaterial()
	{
		if (GetComponent<Renderer>().sharedMaterial != collectionInst.spriteDefinitions[base.spriteId].materialInst)
		{
			GetComponent<Renderer>().material = collectionInst.spriteDefinitions[base.spriteId].materialInst;
		}
	}

	protected override int GetCurrentVertexCount()
	{
		return 4;
	}

	public override void ReshapeBounds(Vector3 dMin, Vector3 dMax)
	{
		tk2dSpriteDefinition currentSprite = base.CurrentSprite;
		Vector3 vector = Vector3.Scale(currentSprite.untrimmedBoundsData[0] - 0.5f * currentSprite.untrimmedBoundsData[1], _scale);
		Vector3 vector2 = Vector3.Scale(currentSprite.untrimmedBoundsData[1], _scale);
		Vector3 vector3 = vector2 + dMax - dMin;
		vector3.x /= currentSprite.untrimmedBoundsData[1].x;
		vector3.y /= currentSprite.untrimmedBoundsData[1].y;
		Vector3 vector4 = new Vector3((!Mathf.Approximately(_scale.x, 0f)) ? (vector.x * vector3.x / _scale.x) : 0f, (!Mathf.Approximately(_scale.y, 0f)) ? (vector.y * vector3.y / _scale.y) : 0f);
		Vector3 position = vector + dMin - vector4;
		position.z = 0f;
		base.transform.position = base.transform.TransformPoint(position);
		base.scale = new Vector3(vector3.x, vector3.y, _scale.z);
	}
}
