using UnityEngine;

[ExecuteInEditMode]
public class UIScrollBar : MonoBehaviour
{
	public enum Direction
	{
		Horizontal,
		Vertical
	}

	public delegate void OnScrollBarChange(UIScrollBar sb);

	public delegate void OnDragFinished();

	[HideInInspector]
	[SerializeField]
	private UISprite mBG;

	[HideInInspector]
	[SerializeField]
	private UISprite mFG;

	[HideInInspector]
	[SerializeField]
	private Direction mDir;

	[HideInInspector]
	[SerializeField]
	private bool mInverted;

	[HideInInspector]
	[SerializeField]
	private float mScroll;

	[HideInInspector]
	[SerializeField]
	private float mSize;

	private Transform mTrans;

	private bool mIsDirty;

	private Camera mCam;

	private Vector2 mScreenPos;

	public OnScrollBarChange onChange;

	public OnDragFinished onDragFinished;

	public Transform cachedTransform => null;

	public Camera cachedCamera => null;

	public UISprite background
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public UISprite foreground
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public Direction direction
	{
		get
		{
			return default(Direction);
		}
		set
		{
		}
	}

	public bool inverted
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public float scrollValue
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float barSize
	{
		get
		{
			return 0f;
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

	private void CenterOnPos(Vector2 localPos)
	{
	}

	private void Reposition(Vector2 screenPos)
	{
	}

	private void OnPressBackground(GameObject go, bool isPressed)
	{
	}

	private void OnDragBackground(GameObject go, Vector2 delta)
	{
	}

	private void OnPressForeground(GameObject go, bool isPressed)
	{
	}

	private void OnDragForeground(GameObject go, Vector2 delta)
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void ForceUpdate()
	{
	}
}
