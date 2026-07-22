using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class UIPanel : MonoBehaviour
{
	public enum DebugInfo
	{
		None,
		Gizmos,
		Geometry
	}

	public delegate void OnChangeDelegate();

	public OnChangeDelegate onChange;

	public bool showInPanelTool;

	public bool generateNormals;

	public bool depthPass;

	public bool widgetsAreStatic;

	public bool cullWhileDragging;

	[HideInInspector]
	public Matrix4x4 worldToLocal;

	[HideInInspector]
	[SerializeField]
	private float mAlpha;

	[HideInInspector]
	[SerializeField]
	private DebugInfo mDebugInfo;

	[HideInInspector]
	[SerializeField]
	private UIDrawCall.Clipping mClipping;

	[HideInInspector]
	[SerializeField]
	private Vector4 mClipRange;

	[HideInInspector]
	[SerializeField]
	private Vector2 mClipSoftness;

	private BetterList<UIWidget> mWidgets;

	private Dictionary<Material, bool> mChanged;

	private BetterList<UIDrawCall> mDrawCalls;

	private BetterList<Vector3> mVerts;

	private BetterList<Vector3> mNorms;

	private BetterList<Vector4> mTans;

	private BetterList<Vector2> mUvs;

	private BetterList<Vector2> mUvs2;

	private BetterList<Color32> mCols;

	private GameObject mGo;

	private Transform mTrans;

	private Camera mCam;

	private int mLayer;

	private bool mDepthChanged;

	private float mCullTime;

	private float mUpdateTime;

	private float mMatrixTime;

	private static float[] mTemp;

	private Vector2 mMin;

	private Vector2 mMax;

	private UIPanel[] mChildPanels;

	private bool mAlphaChanged;

	public bool isFreezed;

	private UIRoot mRoot;

	public bool generateUvs2 { get; set; }

	public GameObject cachedGameObject => null;

	public Transform cachedTransform => null;

	public float alpha => 0f;

	public float alpha1
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public DebugInfo debugInfo
	{
		get
		{
			return default(DebugInfo);
		}
		set
		{
		}
	}

	public UIDrawCall.Clipping clipping
	{
		get
		{
			return default(UIDrawCall.Clipping);
		}
		set
		{
		}
	}

	public Vector4 clipRange
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector4);
		}
		set
		{
		}
	}

	public Vector2 clipSoftness
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			return default(Vector2);
		}
		set
		{
		}
	}

	public BetterList<UIWidget> widgets => null;

	public BetterList<UIDrawCall> drawCalls => null;

	public UIRoot root
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private bool IsVisible(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
	{
		return false;
	}

	public bool IsVisible(Vector3 worldPos)
	{
		return false;
	}

	public bool IsVisible(UIWidget w)
	{
		return false;
	}

	public void MarkMaterialAsChanged(Material mat, bool sort, bool premultiplied)
	{
	}

	public void AddWidget(UIWidget w)
	{
	}

	public void RemoveWidget(UIWidget w)
	{
	}

	private UIDrawCall GetDrawCall(Material mat, bool createIfMissing)
	{
		return null;
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void UpdateTransformMatrix()
	{
	}

	public void UpdateDrawcalls()
	{
	}

	private void Fill(Material mat, bool isPremultiplied)
	{
	}

	private void LateUpdate()
	{
	}

	public void Refresh()
	{
	}

	public Vector3 CalculateConstrainOffset(Vector2 min, Vector2 max)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public Vector3 CalculateConstrainOffsetTopLeft(Vector2 min, Vector2 max)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public bool ConstrainTargetToBounds(Transform target, ref Bounds targetBounds, bool immediate)
	{
		return false;
	}

	public bool ConstrainTargetToBounds(Transform target, bool immediate)
	{
		return false;
	}

	private static void SetChildLayer(Transform t, int layer)
	{
	}

	public static UIPanel Find(Transform trans, bool createIfMissing)
	{
		return null;
	}

	public Vector3 CalculateLeftTopAlignOffset(Vector2 min, Vector2 max)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public Vector3 CalculateBottomRightAlignOffset(Vector2 min, Vector2 max)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return default(Vector3);
	}

	public static UIPanel Find(Transform trans)
	{
		return null;
	}
}
