using UnityEngine;

public class CameraSizeSetter : MonoBehaviour
{
	public Camera cam;

	public UIRoot root;

	public Vector2 sizeScale = Vector2.one;

	public bool onlyBox;

	public BoxCollider boxCollider;

	public UILabel textToScale;

	public CameraPanelAligner.AlignBy AlignBy = CameraPanelAligner.AlignBy.UIroot_Fixed;

	public Vector2 BaseCameraSize = new Vector2(1920f, 1440f);

	public bool scaleX = true;

	public bool scaleY;

	public bool onlyScaleUp;

	private bool started;

	public UIRoot root_saveGet
	{
		get
		{
			if (root == null)
			{
				root = Object.FindObjectOfType(typeof(UIRoot)) as UIRoot;
			}
			if (root == null)
			{
				Debug.LogError("NO any UIRoot - failed " + base.name);
			}
			return root;
		}
	}

	public void Start()
	{
		if (started)
		{
			return;
		}
		started = true;
		float num = 0f;
		float num2 = 0f;
		if (AlignBy == CameraPanelAligner.AlignBy.Camera)
		{
			if (cam == null)
			{
				cam = UICamera.mainCamera;
			}
			num = (float)cam.pixelWidth - BaseCameraSize.x;
			num2 = (float)cam.pixelHeight - BaseCameraSize.y;
		}
		else
		{
			if (root_saveGet == null)
			{
				Debug.LogError("missing UIRoot");
				return;
			}
			num = root.activeWidth - BaseCameraSize.x;
			num2 = (float)root.activeHeight - BaseCameraSize.y;
		}
		Vector3 zero = Vector3.zero;
		if (scaleX)
		{
			zero.x = num * sizeScale.x;
		}
		if (scaleY)
		{
			zero.y = num2 * sizeScale.y;
		}
		if (onlyScaleUp)
		{
			if (zero.x < 0f)
			{
				zero.x = 0f;
			}
			if (zero.y < 0f)
			{
				zero.y = 0f;
			}
		}
		if (!onlyBox)
		{
			base.transform.localScale = base.transform.localScale + zero;
		}
		if (boxCollider != null)
		{
			boxCollider.size += zero;
		}
		if (textToScale != null)
		{
			int lineWidth = textToScale.lineWidth;
			lineWidth += Mathf.FloorToInt(zero.x);
			textToScale.lineWidth = lineWidth;
		}
	}
}
