using UnityEngine;

public class TweenAlphaTk2d : UITweener
{
	public float from;

	public float to;

	private tk2dBaseSprite mWidget;

	private tk2dTextMesh mWidgetText;

	private TextMesh mText;

	private TextMeshWithStroke mTextWithStroke;

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

	private void Awake()
	{
	}

	protected override void OnUpdate(float factor, bool isFinished)
	{
	}

	public static TweenAlphaTk2d Begin(GameObject go, float duration, float alpha)
	{
		return null;
	}

	public static TweenAlphaTk2d Begin(GameObject go, float duration, float fromAlpha, float toAlpha)
	{
		return null;
	}
}
