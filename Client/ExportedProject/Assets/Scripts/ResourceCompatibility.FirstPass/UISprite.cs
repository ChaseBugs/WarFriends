using UnityEngine;

[ExecuteInEditMode]
public class UISprite : UIWidget
{
	public enum Type
	{
		Simple,
		Sliced,
		Tiled,
		Filled,
		SlicedInverted
	}

	public enum FillDirection
	{
		Horizontal,
		Horizontal30,
		Horizontalminus30,
		Vertical,
		Radial90,
		Radial180,
		Radial360,
		HorizontalCutted,
		VerticalCutted,
		Horizontal3030
	}

	[HideInInspector]
	[SerializeField]
	private UIAtlas mAtlas;

	[HideInInspector]
	[SerializeField]
	private string mSpriteName;

	[HideInInspector]
	[SerializeField]
	protected bool mFillCenter;

	[HideInInspector]
	[SerializeField]
	private Type mType;

	[HideInInspector]
	[SerializeField]
	private FillDirection mFillDirection;

	[HideInInspector]
	[SerializeField]
	private float mFillAmount;

	[HideInInspector]
	[SerializeField]
	private float mFillAmountBack;

	[HideInInspector]
	[SerializeField]
	private bool mInvert;

	[HideInInspector]
	[SerializeField]
	private float mTiledScale;

	[HideInInspector]
	[SerializeField]
	private bool mUseInnerUVs;

	[SerializeField]
	public float mFillSlopePixels;

	protected UIAtlas.Sprite mSprite;

	protected Rect mInner;

	protected Rect mInnerUV;

	protected Rect mOuter;

	protected Rect mOuterUV;

	protected Vector3 mScale;

	private bool mSpriteSet;

	public virtual Type type
	{
		get
		{
			return default(Type);
		}
		set
		{
		}
	}

	public UIAtlas atlas
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public string spriteName
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool isValid => false;

	public override Material material => null;

	public Rect innerUV => default(Rect);

	public Rect outerUV => default(Rect);

	public bool fillCenter
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public FillDirection fillDirection
	{
		get
		{
			return default(FillDirection);
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

	public float fillAmountBack
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool invert
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float tileScale
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public bool useInnerUVs
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public override Vector4 relativePadding => default(Vector4);

	public override Vector4 border => default(Vector4);

	public override bool pixelPerfectAfterResize => false;

	public UIAtlas.Sprite GetAtlasSprite()
	{
		return null;
	}

	protected void SetAtlasSprite(UIAtlas.Sprite sp)
	{
	}

	public virtual void UpdateUVs(bool force)
	{
	}

	public override void MakePixelPerfect()
	{
	}

	protected override void OnStart()
	{
	}

	public override void Update()
	{
	}

	public override void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, BetterList<Vector2> uvs2)
	{
	}

	protected void SimpleFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
	}

	protected void SlicedFillInverted(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
	}

	protected void SlicedFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
	}

	protected bool AdjustRadial(Vector2[] xy, Vector2[] uv, float fill, bool invert)
	{
		return false;
	}

	protected void Rotate(Vector2[] v, int offset)
	{
	}

	protected void FilledFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
	}

	protected void TiledFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols)
	{
	}
}
