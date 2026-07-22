using System.Collections.Generic;
using UnityEngine;

public class UIButtonColor : MonoBehaviour
{
	public GameObject tweenTarget;

	public List<GameObject> extratweenTargets;

	protected List<Color> mColors;

	public Color hover;

	public Color pressed;

	public float duration;

	protected Color mColor;

	protected bool mStarted;

	protected bool mHighlighted;

	public Color defaultColor
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

	private void Start()
	{
	}

	protected virtual void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void Init()
	{
	}

	public virtual void OnPress(bool isPressed)
	{
	}

	public virtual void OnHover(bool isOver)
	{
	}
}
