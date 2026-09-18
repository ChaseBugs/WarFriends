using System.Collections;
using UnityEngine;

public class UnitIndicator : PoolableObject
{
	public UISprite background;

	public UISprite unitSprite;

	public UISprite arrowBorder;

	private RadicalRoutine mIndicating;

	private bool mUpdateRunning;

	private EnemyController mSoldier;

	private bool mShown;

	private bool mAnimating;

	private float mPositionZ;

	public override void OnInstancied()
	{
		base.OnInstancied();
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
		background.alpha = 0f;
		unitSprite.alpha = 0f;
		arrowBorder.alpha = 0f;
		mShown = false;
		mAnimating = false;
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		Singleton<GameController>.instance.GameEnded -= OnGameEnded;
		mShown = false;
		Destroy();
	}

	public override void DestroyPooled()
	{
		Singleton<GameController>.instance.GameEnded -= OnGameEnded;
		StopUpdator();
		base.DestroyPooled();
	}

	public void InitAndShow(string unitIconName, EnemyController soldier, float posZ)
	{
		unitSprite.spriteName = unitIconName;
		unitSprite.MakePixelPerfect();
		float multiplier = Mathf.Min(98f / unitSprite.transform.localScale.x, 98f / unitSprite.transform.localScale.y);
		unitSprite.transform.localScale = unitSprite.transform.localScale.MultiplyXY(multiplier);
		mPositionZ = posZ;
		mSoldier = soldier;
		mUpdateRunning = false;
		mShown = false;
		mAnimating = false;
		StartUpdator();
		Show();
	}

	private void Destroy()
	{
		StopUpdator();
		if (!mShown)
		{
			DestroyPooled();
			return;
		}
		Hide();
		InvokeAfterRealTime(delegate
		{
			DestroyPooled();
		}, 0.3f);
	}

	private void StartUpdator()
	{
		if (!mUpdateRunning)
		{
			mIndicating = RadicalRoutine.Create(UpdateStatus());
			StartCoroutine(RadicalRoutine.Run(mIndicating.enumerator));
			mUpdateRunning = true;
		}
	}

	private void StopUpdator()
	{
		if (mUpdateRunning)
		{
			mIndicating.Cancel();
			mUpdateRunning = false;
		}
	}

	private IEnumerator UpdateStatus()
	{
		while (true)
		{
			bool shouldBeShown = isOutSideOfScreen(mSoldier.transform.position);
			if (shouldBeShown && !mShown)
			{
				Show();
			}
			if (!shouldBeShown && mShown)
			{
				Hide();
			}
			if (!mSoldier.isAlive || !mSoldier.isInstantiated)
			{
				Destroy();
			}
			yield return null;
		}
	}

	private bool isOutSideOfScreen(Vector3 worldPosition)
	{
		Vector3 point = Camera.main.WorldToNormalizedViewportPoint(worldPosition);
		if (point.x == Mathf.Clamp01(point.x) && point.y == Mathf.Clamp01(point.y))
		{
			return false;
		}
		point.x = Mathf.Clamp(point.x, 0.025f, 0.975f);
		point.y = Mathf.Clamp(point.y, 0.22f, 0.78f);
		point = Singleton<GuiManager>.instance.guiCamera.NormalizedViewportToWorldPoint(point);
		point.z = 0f;
		base.transform.position = point;
		Vector3 localPosition = base.transform.localPosition;
		localPosition.z = mPositionZ;
		base.transform.localPosition = localPosition;
		arrowBorder.transform.localRotation = ((!(point.x < 0.5f)) ? Quaternion.Euler(0f, 180f, 0f) : Quaternion.identity);
		return true;
	}

	private void Show()
	{
		if (!mShown && !mAnimating)
		{
			mAnimating = true;
			TweenAlpha.Begin(unitSprite.gameObject, 0.2f, 0f, 1f);
			TweenColor tweenColor = TweenColor.Begin(background.gameObject, 0.2f, Colours.blueTransparent, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			TweenColor tweenColor2 = TweenColor.Begin(arrowBorder.gameObject, 0.2f, Colours.whiteTransparent, Color.white);
			tweenColor2.NumOfRepetitions = 1;
			tweenColor2.onFinished = delegate
			{
				StartFlashing();
			};
		}
	}

	private void StartFlashing()
	{
		mAnimating = false;
		mShown = true;
	}

	private void Hide()
	{
		if (mShown && !mAnimating)
		{
			mAnimating = true;
			TweenAlpha.Begin(unitSprite.gameObject, 0.2f, 0f);
			TweenColor tweenColor = TweenColor.Begin(background.gameObject, 0.2f, Colours.blueTransparent);
			tweenColor.NumOfRepetitions = 1;
			TweenColor tweenColor2 = TweenColor.Begin(arrowBorder.gameObject, 0.2f, Colours.whiteTransparent);
			tweenColor2.NumOfRepetitions = 1;
			tweenColor2.onFinished = delegate
			{
				mAnimating = false;
				mShown = false;
				Destroy();
			};
		}
	}
}
