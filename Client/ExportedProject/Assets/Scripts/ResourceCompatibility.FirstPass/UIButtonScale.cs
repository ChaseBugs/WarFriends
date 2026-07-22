using UnityEngine;

public class UIButtonScale : MonoBehaviour
{
	public Transform tweenTarget;

	public Vector3 hover;

	public Vector3 pressed;

	private static float duration;

	private Vector3 mScale;

	private bool mInitDone;

	private bool mStarted;

	private bool mHighlighted;

	private bool mIsPressed;

	private bool mSomething;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Init()
	{
	}

	public virtual void OnPress(bool isPressed)
	{
	}

	private void OnPressedFinished(UITweener tween)
	{
	}

	private void OnHover(bool isOver)
	{
	}

	public void PlayFullAnimation()
	{
	}
}
