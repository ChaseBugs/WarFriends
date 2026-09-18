using System;
using System.Collections.Generic;
using UnityEngine;

public class NewUnitDisplayerItem : PoolableObject
{
	public tk2dSprite bgSpriteBottom;

	public tk2dSprite bgSpriteTop;

	private TweenAnimator mAnimator;

	public Transform move;

	private Vector3 scale;

	public TextMesh textBottom;

	public TextMesh textTop;

	public override void OnInstancied()
	{
		base.OnInstancied();
	}

	protected override void Awake()
	{
		base.Awake();
		mAnimator = base.gameObject.AddComponent<TweenAnimator>();
		mAnimator.allTweens = new List<TweenAnimator.TweenRecord>();
		mAnimator.AddTween(from: new Vector3(-12.8f, 0f, 0f), id: 0, tweenType: TweenAnimator.TweenType.Position, tweenTarget: move.gameObject, time: 0.3f, to: new Vector3(-12.8f, 15f, 0f), delay: 0f, playAfterIdFinished: -1, method: UITweener.Method.EaseIn);
		mAnimator.AddTween(2, TweenAnimator.TweenType.AlphaTk2d, bgSpriteBottom.gameObject, 0.3f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(3, TweenAnimator.TweenType.AlphaTk2d, textBottom.gameObject, 0.3f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(22, TweenAnimator.TweenType.AlphaTk2d, bgSpriteTop.gameObject, 0.3f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(33, TweenAnimator.TweenType.AlphaTk2d, textTop.gameObject, 0.3f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(4, TweenAnimator.TweenType.Position, move.gameObject, 0.1f, new Vector3(-12.8f, 10f, 0f), 0f, 0, null, UITweener.Method.EaseIn);
		float delay = 1.3f;
		int num = 5;
		TweenAnimator tweenAnimator = mAnimator;
		int numOfRepetitions = num;
		tweenAnimator.AddTween(7, TweenAnimator.TweenType.AlphaTk2d, bgSpriteBottom.gameObject, 0.05f, 0f, delay, 4, null, UITweener.Method.EaseInOut, UITweener.Style.PingPong, numOfRepetitions);
		TweenAnimator tweenAnimator2 = mAnimator;
		numOfRepetitions = num;
		tweenAnimator2.AddTween(8, TweenAnimator.TweenType.AlphaTk2d, textBottom.gameObject, 0.05f, 0f, delay, 4, null, UITweener.Method.EaseInOut, UITweener.Style.PingPong, numOfRepetitions);
		TweenAnimator tweenAnimator3 = mAnimator;
		numOfRepetitions = num;
		tweenAnimator3.AddTween(9, TweenAnimator.TweenType.AlphaTk2d, bgSpriteTop.gameObject, 0.05f, 0f, delay, 4, null, UITweener.Method.EaseInOut, UITweener.Style.PingPong, numOfRepetitions);
		TweenAnimator tweenAnimator4 = mAnimator;
		numOfRepetitions = num;
		tweenAnimator4.AddTween(10, TweenAnimator.TweenType.AlphaTk2d, textTop.gameObject, 0.05f, 0f, delay, 4, null, UITweener.Method.EaseInOut, UITweener.Style.PingPong, numOfRepetitions);
		TweenAnimator tweenAnimator5 = mAnimator;
		tweenAnimator5.TweenFinished = (Action<int>)Delegate.Combine(tweenAnimator5.TweenFinished, new Action<int>(TweenFinished));
		mAnimator.GenerateTweens();
	}

	private void TweenFinished(int i)
	{
		if (i == 10)
		{
			DestroyPooled();
		}
	}

	public void Play(string unitName, Vector3 worldPosition)
	{
		textTop.text = Localization.Localize("ID_NEWUNIT");
		textBottom.text = unitName.ToUpper();
		BackgroundResize(textTop, bgSpriteTop);
		BackgroundResize(textBottom, bgSpriteBottom);
		SetPosition(worldPosition);
		mAnimator.PlayTweens();
	}

	private void BackgroundResize(TextMesh frontText, tk2dSprite background)
	{
		float x = frontText.GetComponent<MeshRenderer>().bounds.size.x;
		float x2 = background.GetBounds().size.x;
		background.transform.localScale = background.transform.localScale.ReplaceX((x + 4f) / x2);
	}

	private void SetPosition(Vector3 worldPosition)
	{
		Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint(worldPosition);
		base.transform.position = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point).ReplaceZ(50f);
		float x = bgSpriteBottom.GetBounds().size.x;
		Vector3 worldPosition2 = bgSpriteBottom.transform.position.AddX(x / 2f);
		worldPosition2 = ClampInScreenX(HealthBarManager.instance.guiCamera, worldPosition2, bgSpriteBottom.GetBounds());
		base.transform.position = worldPosition2.AddX((0f - x) / 2f + 0.4f + 12.8f);
	}

	private Vector3 ClampInScreenX(Camera c, Vector3 worldPosition, Bounds objectSize)
	{
		Vector3 result = worldPosition;
		Vector3 vector = c.ViewportToWorldPoint(new Vector2(0f, 0f));
		Vector3 vector2 = c.ViewportToWorldPoint(new Vector2(1f, 0f));
		if (worldPosition.x - objectSize.extents.x < vector.x)
		{
			result.x = vector.x + objectSize.extents.x;
		}
		if (worldPosition.x + objectSize.extents.x > vector2.x)
		{
			result.x = vector2.x - objectSize.extents.x;
		}
		return result;
	}
}
