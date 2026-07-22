using UnityEngine;

[ExecuteInEditMode]
public class tk2dSprite : tk2dBaseSprite
{
	private Renderer _renderer;

	private MaterialPropertyBlock m_MaterialPropertyBlock;

	[SerializeField]
	private Texture2D m_MaskTexture;

	[SerializeField]
	private float m_FillAmount;

	[SerializeField]
	private bool m_MaskInvert;

	protected Mesh mesh;

	protected Vector3[] meshVertices;

	protected Vector3[] meshNormals;

	protected Vector4[] meshTangents;

	protected Color32[] meshColors;

	public Texture2D maskTexture
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public float fillAmount
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool maskInvert
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private new void Awake()
	{
	}

	protected void OnDestroy()
	{
	}

	private void EnsureInitialized()
	{
	}

	public override void Build()
	{
	}

	public static tk2dSprite AddComponent(GameObject go, tk2dSpriteCollectionData spriteCollection, int spriteId)
	{
		return null;
	}

	public static tk2dSprite AddComponent(GameObject go, tk2dSpriteCollectionData spriteCollection, string spriteName)
	{
		return null;
	}

	public static GameObject CreateFromTexture(Texture texture, tk2dSpriteCollectionSize size, Rect region, Vector2 anchor)
	{
		return null;
	}

	protected override void UpdateGeometry()
	{
	}

	protected override void UpdateColors()
	{
	}

	protected override void UpdateVertices()
	{
	}

	protected void UpdateColorsImpl()
	{
	}

	protected void UpdateVerticesImpl()
	{
	}

	protected void UpdateGeometryImpl()
	{
	}

	protected override void UpdateMaterial()
	{
	}

	protected override int GetCurrentVertexCount()
	{
		return 0;
	}

	private static Vector2[] GenerateUv2(Vector3[] vertices)
	{
		return null;
	}

	public override void ForceBuild()
	{
	}

	public override void ReshapeBounds(Vector3 dMin, Vector3 dMax)
	{
	}
}
