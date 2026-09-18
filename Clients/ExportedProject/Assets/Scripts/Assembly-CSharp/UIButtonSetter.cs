using System;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Button Setter")]
public class UIButtonSetter : MonoBehaviour
{
	[Serializable]
	public class ButtonBackgrounds
	{
		public UISprite background;

		public Vector2 addSize = default(Vector2);
	}

	[Serializable]
	public class LabelWidth
	{
		public UILabel label;

		public int addX;
	}

	public Action Rescaled;

	[Header("Object moving (center stays in current localPosition)")]
	public UIAnchor.Side moveInDirection = UIAnchor.Side.Center;

	[Header("Base Size Settings:")]
	public bool keepBaseSpaceAround;

	public Vector2 baseSize;

	public Vector2 minSize;

	public Vector2 maxSize;

	[Header("Backgrounds:")]
	public List<ButtonBackgrounds> backgrounds;

	[Header("Collider:")]
	public bool isClickable = true;

	public BoxCollider boxCollider;

	public Vector2 addColliderSize;

	[Header("Labels Widths:")]
	public List<LabelWidth> labels;

	[Header("Button Anchors (can be combined):")]
	public List<GameObject> leftAnchors;

	public List<GameObject> rightAnchors;

	public List<GameObject> topAnchors;

	public List<GameObject> bottomAnchors;

	[Header("Resize object when awaked/enabled/started")]
	public bool initializationResizeDone;

	private int mWidth = -1;

	public int width => (mWidth < 0) ? ((int)baseSize.x) : mWidth;

	private void Start()
	{
		if (!initializationResizeDone)
		{
			Initialize();
		}
	}

	private void OnEnable()
	{
		if (!initializationResizeDone)
		{
			Initialize();
		}
	}

	private void Awake()
	{
		if (!initializationResizeDone)
		{
			Initialize();
		}
	}

	private void Initialize()
	{
		initializationResizeDone = true;
		float activeWidth = UIRoot.list[0].activeWidth;
		float num = UIRoot.list[0].activeHeight;
		if (maxSize.x == 0f)
		{
			maxSize = new Vector2(activeWidth, maxSize.y);
		}
		if (maxSize.y == 0f)
		{
			maxSize = new Vector2(maxSize.x, num);
		}
		float num2 = ((!keepBaseSpaceAround) ? (activeWidth / 1920f) : ((activeWidth - (1920f - baseSize.x)) / baseSize.x));
		float num3 = ((!keepBaseSpaceAround) ? (num / 1440f) : ((num - (1440f - baseSize.y)) / baseSize.y));
		Vector2 vector = new Vector2(Mathf.Clamp(baseSize.x * num2, minSize.x, maxSize.x), Mathf.Clamp(baseSize.y * num3, minSize.y, maxSize.y));
		mWidth = (int)vector.x;
		foreach (ButtonBackgrounds background in backgrounds)
		{
			background.background.transform.localScale = new Vector3(vector.x + background.addSize.x, vector.y + background.addSize.y, background.background.transform.localScale.z);
		}
		if (isClickable)
		{
			if (boxCollider != null)
			{
				boxCollider.size = new Vector3(vector.x + addColliderSize.x, vector.y + addColliderSize.y, boxCollider.size.z);
			}
			else
			{
				Debug.LogError($"Button \"{base.name}\" has no assigned box collider.");
			}
		}
		foreach (LabelWidth label in labels)
		{
			label.label.lineWidth = Mathf.FloorToInt(vector.x) + label.addX;
		}
		foreach (GameObject leftAnchor in leftAnchors)
		{
			leftAnchor.transform.localPosition = leftAnchor.transform.localPosition.ReplaceX(0f - vector.x / 2f);
		}
		foreach (GameObject rightAnchor in rightAnchors)
		{
			rightAnchor.transform.localPosition = rightAnchor.transform.localPosition.ReplaceX(vector.x / 2f);
		}
		foreach (GameObject topAnchor in topAnchors)
		{
			topAnchor.transform.localPosition = topAnchor.transform.localPosition.ReplaceY(vector.y / 2f);
		}
		foreach (GameObject bottomAnchor in bottomAnchors)
		{
			bottomAnchor.transform.localPosition = bottomAnchor.transform.localPosition.ReplaceY(0f - vector.y / 2f);
		}
		if (moveInDirection != UIAnchor.Side.Center)
		{
			if (moveInDirection == UIAnchor.Side.BottomLeft || moveInDirection == UIAnchor.Side.Left || moveInDirection == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - baseSize.x)) / 2f);
			}
			if (moveInDirection == UIAnchor.Side.BottomRight || moveInDirection == UIAnchor.Side.Right || moveInDirection == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - baseSize.x) / 2f);
			}
			if (moveInDirection == UIAnchor.Side.BottomLeft || moveInDirection == UIAnchor.Side.Bottom || moveInDirection == UIAnchor.Side.BottomRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (baseSize.y - vector.y)) / 2f);
			}
			if (moveInDirection == UIAnchor.Side.TopLeft || moveInDirection == UIAnchor.Side.Top || moveInDirection == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((baseSize.y - vector.y) / 2f);
			}
			if (Rescaled != null)
			{
				Rescaled();
			}
		}
	}

	public void SetWidth(float buttonWidth)
	{
		initializationResizeDone = true;
		if (maxSize.x == 0f)
		{
			maxSize = new Vector2(UIRoot.list[0].activeWidth, maxSize.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(buttonWidth, minSize.x, maxSize.x), baseSize.y);
		mWidth = (int)vector.x;
		foreach (ButtonBackgrounds background in backgrounds)
		{
			background.background.transform.localScale = new Vector3(vector.x + background.addSize.x, vector.y + background.addSize.y, background.background.transform.localScale.z);
		}
		if (isClickable)
		{
			if (boxCollider != null)
			{
				boxCollider.size = new Vector3(vector.x + addColliderSize.x, vector.y + addColliderSize.y, boxCollider.size.z);
			}
			else
			{
				Debug.LogError($"Button \"{base.name}\" has no assigned box collider.");
			}
		}
		foreach (LabelWidth label in labels)
		{
			label.label.lineWidth = Mathf.FloorToInt(vector.x) + label.addX;
		}
		foreach (GameObject leftAnchor in leftAnchors)
		{
			leftAnchor.transform.localPosition = leftAnchor.transform.localPosition.ReplaceX(0f - vector.x / 2f);
		}
		foreach (GameObject rightAnchor in rightAnchors)
		{
			rightAnchor.transform.localPosition = rightAnchor.transform.localPosition.ReplaceX(vector.x / 2f);
		}
		if (moveInDirection != UIAnchor.Side.Center)
		{
			if (moveInDirection == UIAnchor.Side.BottomLeft || moveInDirection == UIAnchor.Side.Left || moveInDirection == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - baseSize.x)) / 2f);
			}
			if (moveInDirection == UIAnchor.Side.BottomRight || moveInDirection == UIAnchor.Side.Right || moveInDirection == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - baseSize.x) / 2f);
			}
			if (Rescaled != null)
			{
				Rescaled();
			}
		}
	}
}
