using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using tk2dRuntime;

public abstract class tk2dBaseSprite : MonoBehaviour, ISpriteCollectionForceBuild
{
	public enum Anchor
	{
		LowerLeft,
		LowerCenter,
		LowerRight,
		MiddleLeft,
		MiddleCenter,
		MiddleRight,
		UpperLeft,
		UpperCenter,
		UpperRight
	}

	[SerializeField]
	public tk2dSpriteCollectionData collection;

	protected tk2dSpriteCollectionData collectionInst;

	[SerializeField]
	protected Color _color;

	[SerializeField]
	protected Vector3 _scale;

	[SerializeField]
	protected int _spriteId;

	public BoxCollider boxCollider;

	public MeshCollider meshCollider;

	public Vector3[] meshColliderPositions;

	public Mesh meshColliderMesh;

	[SerializeField]
	protected int renderLayer;

	public tk2dSpriteCollectionData Collection
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Color color
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Color);
		}
		set
		{
		}
	}

	public Vector3 scale
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector3);
		}
		set
		{
		}
	}

	public int SortingOrder
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool FlipX
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool FlipY
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public int spriteId
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public tk2dSpriteDefinition CurrentSprite => null;

	public event Action<tk2dBaseSprite> SpriteChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void InitInstance()
	{
	}

	public void SetSprite(int newSpriteId)
	{
	}

	public bool SetSprite(string spriteName)
	{
		return false;
	}

	public void SetSprite(tk2dSpriteCollectionData newCollection, int newSpriteId)
	{
	}

	public bool SetSprite(tk2dSpriteCollectionData newCollection, string spriteName)
	{
		return false;
	}

	public void MakePixelPerfect()
	{
	}

	protected abstract void UpdateMaterial();

	protected abstract void UpdateColors();

	protected abstract void UpdateVertices();

	protected abstract void UpdateGeometry();

	protected abstract int GetCurrentVertexCount();

	public abstract void Build();

	public int GetSpriteIdByName(string name)
	{
		return 0;
	}

	public static T AddComponent<T>(GameObject go, tk2dSpriteCollectionData spriteCollection, int spriteId) where T : tk2dBaseSprite
	{
		return null;
	}

	public static T AddComponent<T>(GameObject go, tk2dSpriteCollectionData spriteCollection, string spriteName) where T : tk2dBaseSprite
	{
		return null;
	}

	protected int GetNumVertices()
	{
		return 0;
	}

	protected int GetNumIndices()
	{
		return 0;
	}

	protected void SetPositions(Vector3[] positions, Vector3[] normals, Vector4[] tangents)
	{
	}

	protected void SetColors(Color32[] dest)
	{
	}

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

	public static Bounds AdjustedMeshBounds(Bounds bounds, int renderLayer)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Bounds);
	}

	public tk2dSpriteDefinition GetCurrentSpriteDef()
	{
		return null;
	}

	public virtual void ReshapeBounds(Vector3 dMin, Vector3 dMax)
	{
	}

	protected virtual bool NeedBoxCollider()
	{
		return false;
	}

	protected virtual void UpdateCollider()
	{
	}

	protected virtual void CreateCollider()
	{
	}

	protected void Awake()
	{
	}

	public bool UsesSpriteCollection(tk2dSpriteCollectionData spriteCollection)
	{
		return false;
	}

	public virtual void ForceBuild()
	{
	}

	public static GameObject CreateFromTexture<T>(Texture texture, tk2dSpriteCollectionSize size, Rect region, Vector2 anchor) where T : tk2dBaseSprite
	{
		return null;
	}
}
