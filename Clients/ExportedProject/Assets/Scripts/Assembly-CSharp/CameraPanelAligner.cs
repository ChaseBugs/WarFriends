using UnityEngine;

public class CameraPanelAligner : MonoBehaviour
{
	public enum AlignBy
	{
		Camera,
		UIroot_Fixed
	}

	public enum AnchorType
	{
		topLeft,
		topRight,
		downLeft,
		downRight,
		center,
		left,
		right,
		top,
		down
	}

	public AlignBy alignBy = AlignBy.UIroot_Fixed;

	public Camera cam;

	public UIRoot root;

	public UIPanel panel;

	public Vector2 baseCenter;

	public Vector2 baseSize;

	public Vector3 basePosition;

	public Vector2 baseCameraSize = new Vector2(1280f, 1920f);

	public bool alignY = true;

	public bool alignX;

	public AnchorType centerAlign = AnchorType.top;

	public float moveXMultiplay;

	public float moveYMultiplay;

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
				Debug.LogError("NO any UIroot - failed " + base.name);
			}
			return root;
		}
	}

	private void Awake()
	{
		Align();
	}

	public void Align()
	{
		if (panel == null)
		{
			return;
		}
		if (alignBy == AlignBy.Camera)
		{
			if (cam == null)
			{
				cam = UICamera.mainCamera;
			}
			float num = cam.pixelWidth;
			float num2 = cam.pixelHeight;
			float num3 = num - baseCameraSize.x;
			float num4 = num2 - baseCameraSize.y;
			Vector4 clipRange = panel.clipRange;
			if (alignX)
			{
				clipRange.x = baseCenter.x - num3 / 2f;
				clipRange.z = baseSize.x + num3;
			}
			if (alignY)
			{
				clipRange.y = baseCenter.y - num4 / 2f;
				clipRange.w = baseSize.y + num4;
			}
			Vector3 zero = Vector3.zero;
			zero.x = num3 * moveXMultiplay;
			zero.y = num4 * moveYMultiplay;
			panel.clipRange = clipRange;
			panel.transform.localPosition = basePosition + zero;
			return;
		}
		if (alignBy == AlignBy.UIroot_Fixed)
		{
			if (root_saveGet == null)
			{
				return;
			}
			Vector4 clipRange2 = panel.clipRange;
			Vector2 vector = new Vector2(root.activeWidth, root.activeHeight);
			Vector3 zero2 = Vector3.zero;
			if (alignX)
			{
				float num5 = vector.x - baseCameraSize.x;
				clipRange2.z = baseSize.x + num5;
				if (centerAlign == AnchorType.left || centerAlign == AnchorType.downLeft || centerAlign == AnchorType.topLeft)
				{
					clipRange2.x = baseCenter.x + num5 / 2f;
				}
				else if (centerAlign == AnchorType.right || centerAlign == AnchorType.downRight || centerAlign == AnchorType.topRight)
				{
					clipRange2.x = baseCenter.x - num5 / 2f;
				}
				else
				{
					clipRange2.x = baseCenter.x;
				}
				zero2.x = num5 * moveXMultiplay;
			}
			if (alignY)
			{
				float num6 = vector.y - baseCameraSize.y;
				clipRange2.w = baseSize.y + num6;
				if (centerAlign == AnchorType.top || centerAlign == AnchorType.topLeft || centerAlign == AnchorType.topRight)
				{
					clipRange2.y = baseCenter.y - num6 / 2f;
				}
				else if (centerAlign == AnchorType.down || centerAlign == AnchorType.downLeft || centerAlign == AnchorType.downRight)
				{
					clipRange2.y = baseCenter.y + num6 / 2f;
				}
				else
				{
					clipRange2.y = baseCenter.y;
				}
				zero2.y = num6 * moveYMultiplay;
			}
			panel.clipRange = clipRange2;
			panel.transform.localPosition = basePosition + zero2;
		}
		panel = null;
	}
}
