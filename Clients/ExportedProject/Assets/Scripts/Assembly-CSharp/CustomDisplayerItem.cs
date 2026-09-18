using System;
using UnityEngine;

public class CustomDisplayerItem : PoolableObject
{
	public tk2dSprite iconSprite;

	public TextMesh text;

	public tk2dSprite bgSprite;

	public TweenAnimator animator;

	private Vector3 scale;

	protected override void Awake()
	{
		base.Awake();
		GenerateTweens();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
	}

	private void GenerateTweens()
	{
		animator.allTweens.Clear();
		animator.AddTween(from: Vector3.zero, id: 0, tweenType: TweenAnimator.TweenType.Scale, tweenTarget: base.gameObject, time: 0.5f, to: new Vector3(1.3f, 1.3f, 1.3f), delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		animator.AddTween(1, TweenAnimator.TweenType.AlphaTk2d, iconSprite.gameObject, 0.5f, 1f, 0f, -1, 0f);
		animator.AddTween(2, TweenAnimator.TweenType.AlphaTk2d, bgSprite.gameObject, 0.5f, 1f, 0f, -1, 0f);
		animator.AddTween(3, TweenAnimator.TweenType.AlphaTk2d, text.gameObject, 0.5f, 1f, 0f, -1, 0f);
		animator.AddTween(4, TweenAnimator.TweenType.Scale, base.gameObject, 0.2f, Vector3.one, 0f, 0, null, UITweener.Method.EaseOut);
		animator.AddTween(6, TweenAnimator.TweenType.AlphaTk2d, iconSprite.gameObject, 0.3f, 0f, 0.1f, 4);
		animator.AddTween(7, TweenAnimator.TweenType.AlphaTk2d, bgSprite.gameObject, 0.3f, 0f, 0.1f, 4);
		animator.AddTween(8, TweenAnimator.TweenType.AlphaTk2d, text.gameObject, 0.3f, 0f, 0.1f, 4);
		TweenAnimator tweenAnimator = animator;
		tweenAnimator.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator.TweenFinished, new Action<int>(TweenFinished));
	}

	private void TweenFinished(int i)
	{
		if (i == 8)
		{
			DestroyPooled();
		}
	}

	public void Play(string iconName, string displayText, Color bgColor, Color textColor)
	{
		iconSprite.SetSprite(iconName);
		text.text = displayText;
		Vector3 size = text.GetComponent<MeshRenderer>().bounds.size;
		Bounds bounds = iconSprite.GetBounds();
		float y = size.y;
		float num = y * bounds.size.x / bounds.size.y;
		float num2 = 0.25f * y;
		Vector3 localScale = bgSprite.transform.localScale;
		localScale.x = (size.x + num + num2 * 2f) / bgSprite.GetBounds().size.x;
		localScale.y = size.y / bgSprite.GetBounds().size.y;
		bgSprite.transform.localScale = localScale;
		bgSprite.transform.localPosition = bgSprite.transform.localPosition.ReplaceX(num + size.x + num2 * 2f);
		bgSprite.color = bgColor;
		iconSprite.transform.localScale = iconSprite.transform.localScale.ReplaceXY(num / bounds.size.x, y / bounds.size.y);
		iconSprite.transform.localPosition = iconSprite.transform.localPosition.ReplaceX(num);
		text.color = textColor;
		text.transform.localPosition = text.transform.localPosition.ReplaceX(num + size.x + num2);
		animator.PlayTweens();
		Debug.LogWarning($"ICON BOUNDS {bounds} SIZE {iconSprite.transform.localScale}");
	}
}
