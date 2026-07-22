using System;
using UnityEngine;

public abstract class UIWidget : MonoBehaviour
{
	public enum Pivot
	{
		TopLeft,
		Top,
		TopRight,
		Left,
		Center,
		Right,
		BottomLeft,
		Bottom,
		BottomRight
	}

	[HideInInspector]
	[SerializeField]
	protected Material mMat;

	[HideInInspector]
	protected Texture mTex;

	[HideInInspector]
	[SerializeField]
	private Color mColor;

	[HideInInspector]
	[SerializeField]
	private Pivot mPivot;

	[HideInInspector]
	[SerializeField]
	private int mDepth;

	protected GameObject mGo;

	protected Transform mTrans;

	protected UIPanel mPanel;

	protected bool mChanged;

	private Matrix4x4 mLocalToPanel;

	private bool mVisibleByPanel;

	private float mLastAlpha;

	private UIGeometry mGeom;

	private bool mForceVisible;

	private Vector3 mOldV0;

	private Vector3 mOldV1;

	public bool ignoreInTable { get; set; }

	public bool isVisible => false;

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

	public float alpha
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float finalAlpha => 0f;

	public Pivot pivot
	{
		get
		{
			return default(Pivot);
		}
		set
		{
		}
	}

	public int depth
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public Vector2 pivotOffset => default(Vector2);

	public GameObject cachedGameObject => null;

	public Transform cachedTransform => null;

	public virtual Material material
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual Texture mainTexture
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public UIPanel panel
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public virtual Vector2 relativeSize => default(Vector2);

	public virtual Vector4 relativePadding => default(Vector4);

	public virtual Vector4 border => default(Vector4);

	public virtual bool keepMaterial => false;

	public virtual bool pixelPerfectAfterResize => false;

	public virtual bool isPremultiplied => false;

	public static BetterList<UIWidget> Raycast(GameObject root, Vector2 mousePos)
	{
		return null;
	}

	public static int CompareFunc(UIWidget left, UIWidget right)
	{
		return 0;
	}

	public void MarkAsChangedLite()
	{
	}

	public virtual void MarkAsChanged()
	{
	}

	public void CreatePanel()
	{
	}

	public void CheckLayer()
	{
	}

	[Obsolete]
	public void CheckParent()
	{
	}

	public void ParentHasChanged()
	{
	}

	protected virtual void Awake()
	{
	}

	protected virtual void OnEnable()
	{
	}

	private void Start()
	{
	}

	public virtual void Update()
	{
	}

	private void OnDisable()
	{
	}

	private void OnDestroy()
	{
	}

	public bool UpdateGeometry(UIPanel p, bool forceVisible)
	{
		return false;
	}

	public void WriteToBuffers(BetterList<Vector3> v, BetterList<Vector2> u, BetterList<Color32> c, BetterList<Vector3> n, BetterList<Vector4> t, BetterList<Vector2> uvs2)
	{
	}

	public virtual void MakePixelPerfect()
	{
	}

	protected virtual void OnStart()
	{
	}

	public virtual void OnFill(BetterList<Vector3> verts, BetterList<Vector2> uvs, BetterList<Color32> cols, BetterList<Vector2> uvs2)
	{
	}
}
