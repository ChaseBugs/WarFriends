using System;
using UnityEngine;

public class Background : GuiElementSingle<Background>
{
	public enum Type
	{
		Classic,
		Picture,
		Overlay
	}

	public Camera backgroundCamera;

	public UISprite tiles;

	public UISprite blackOverlay;

	public UISprite circleGlow;

	public UISprite longGlow;

	public float fadeDuration = 0.4f;

	public ParticleSystem particles;

	private Type mPreviousVariant = Type.Picture;

	public float tilesAlpha = 1f;

	public float blackOverlayAlpha = 0.80078125f;

	public float circleGlowAlpha = 0.16015625f;

	public float longGlowAlpha = 0.55078125f;

	public GameObject parallax;

	public UISprite bgSprite;

	public override bool isShowed
	{
		get
		{
			return base.isShowed;
		}
		protected set
		{
			base.isShowed = value;
		}
	}

	public override void InitControls()
	{
		bgSprite.gameObject.SetActive(value: false);
		if (parallax != null)
		{
			parallax.SetActive(value: true);
		}
		backgroundCamera.clearFlags = CameraClearFlags.Depth;
	}

	public override void InitGUIValues()
	{
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		if (parallax != null)
		{
			parallax.SetActive(value: false);
		}
		backgroundCamera.gameObject.SetActive(value: false);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		bgSprite.gameObject.SetActive(value: false);
		if (parallax != null)
		{
			parallax.SetActive(value: true);
		}
		backgroundCamera.gameObject.SetActive(value: true);
	}

	public void ShowVariant(Type newType)
	{
		if (mPreviousVariant != newType)
		{
			if (newType == Type.Classic)
			{
				UITweener uITweener = ShowSprite(tiles, tilesAlpha);
				uITweener.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener.onFinished, (UITweener.OnFinished)delegate
				{
					if (parallax != null)
					{
						parallax.SetActive(value: false);
					}
				});
				particles.gameObject.SetActive(value: true);
				particles.Play();
			}
			else
			{
				HideSprite(tiles);
				if (parallax != null)
				{
					parallax.SetActive(value: true);
				}
				particles.Stop();
				particles.gameObject.SetActive(value: false);
			}
			if (newType == Type.Picture)
			{
				HideSprite(circleGlow);
				HideSprite(longGlow);
				HideSprite(blackOverlay);
			}
			else
			{
				ShowSprite(circleGlow, circleGlowAlpha);
				ShowSprite(longGlow, longGlowAlpha);
				ShowSprite(blackOverlay, blackOverlayAlpha);
			}
		}
		else
		{
			tiles.gameObject.SetActive(newType == Type.Classic);
			blackOverlay.gameObject.SetActive(newType == Type.Overlay);
			circleGlow.gameObject.SetActive(newType != Type.Picture);
			longGlow.gameObject.SetActive(newType != Type.Picture);
			if (parallax != null)
			{
				parallax.SetActive(newType != Type.Classic);
			}
			if (tiles.gameObject.activeSelf)
			{
				TweenAlpha.Begin(tiles.gameObject, 0f, tilesAlpha).onFinished = null;
				tiles.alpha = tilesAlpha;
			}
			if (blackOverlay.gameObject.activeSelf)
			{
				TweenAlpha.Begin(blackOverlay.gameObject, 0f, blackOverlayAlpha).onFinished = null;
				blackOverlay.alpha = blackOverlayAlpha;
			}
			if (circleGlow.gameObject.activeSelf)
			{
				TweenAlpha.Begin(circleGlow.gameObject, 0f, circleGlowAlpha).onFinished = null;
				circleGlow.alpha = circleGlowAlpha;
			}
			if (longGlow.gameObject.activeSelf)
			{
				TweenAlpha.Begin(longGlow.gameObject, 0f, longGlowAlpha).onFinished = null;
				longGlow.alpha = longGlowAlpha;
			}
		}
		mPreviousVariant = newType;
	}

	private UITweener ShowSprite(UISprite sprite, float alpha)
	{
		if (sprite.gameObject.activeSelf)
		{
			sprite.alpha = alpha;
			return TweenAlpha.Begin(sprite.gameObject, 0f, alpha);
		}
		sprite.gameObject.SetActive(value: true);
		sprite.alpha = 0f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(sprite.gameObject, fadeDuration, alpha);
		tweenAlpha.onFinished = null;
		return tweenAlpha;
	}

	private void HideSprite(UISprite sprite)
	{
		if (sprite.gameObject.activeSelf)
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(sprite.gameObject, fadeDuration, 0f);
			tweenAlpha.method = UITweener.Method.Linear;
			tweenAlpha.onFinished = delegate
			{
				sprite.gameObject.SetActive(value: false);
			};
		}
		else
		{
			sprite.alpha = 0f;
		}
	}

	public void DestroyParallax()
	{
		if (parallax != null)
		{
			UnityEngine.Object.Destroy(parallax);
			parallax = null;
		}
	}

	public void LoadParallax()
	{
		if (parallax == null)
		{
			GameObject original = Resources.Load<GameObject>("Parallax/Parallax");
			parallax = UnityEngine.Object.Instantiate(original);
			parallax.transform.parent = Singleton<MainSceneRoot>.instance.transform;
		}
	}
}
