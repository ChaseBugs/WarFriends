using System.Collections;
using UnityEngine;

public class PlayerHealthBarGuiElement : Core_BaseScript
{
	public bool playerHealthBar;

	public UISprite background;

	public UISprite healthChange;

	public UISprite health;

	public UILabel nameLabel;

	public Transform nameLabelHandle;

	[Header("Health Change Animation")]
	public float healthChangeDelay;

	public float healthChangeMainSpeed;

	public float healthChangeSpeed;

	[Header("Healthbar fade")]
	public float healthFadeDelay;

	public float healthFadeTime;

	public float healthFadeAlpha;

	[Header("Show Animation")]
	public float showDelay;

	public float showBackgroundTime;

	public float showHealthBarDelay;

	public float showHealthBarTime;

	public float showNameDelay;

	public float showNameTime;

	public AnimationCurve showNamePositionAnimation;

	[Header("Near Death Animation")]
	public float nearDeathPeriod;

	public AnimationCurve nearDeathAlphaAnimation;

	[Header("Heartbeat")]
	public AudioSource heartbeat;

	private float mHealthWidth;

	private float mBackgroundWidth;

	private PlayerController mPlayer;

	private float mCurrentHealthRatio;

	private bool mAnimatingNearDeath;

	private Coroutine mAnimateHealthChangeCoroutine;

	public void Init()
	{
		float num = 156f;
		float num2 = 16f;
		mHealthWidth = UIRoot.list[0].activeWidth / 2f - num;
		mBackgroundWidth = mHealthWidth + num2;
		background.transform.localScale = background.transform.localScale.ReplaceX(mBackgroundWidth);
		healthChange.transform.localScale = healthChange.transform.localScale.ReplaceX(mHealthWidth);
		health.transform.localScale = health.transform.localScale.ReplaceX(mHealthWidth);
		Singleton<GameController>.instance.GameStarted += OnGameStarted;
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
	}

	private void OnGameStarted()
	{
		if (mPlayer != null)
		{
			mCurrentHealthRatio = mPlayer.destroyableParts.healthRatio;
			health.transform.localScale = health.transform.localScale.ReplaceX(mCurrentHealthRatio * mHealthWidth);
			healthChange.transform.localScale = healthChange.transform.localScale.ReplaceX(mCurrentHealthRatio * mHealthWidth);
			SoundsManager.Instance.onSoundVolumeChange += OnSoundVolumeChange;
			StartCoroutine(PlayerWatcher());
		}
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		if (!(mPlayer != null))
		{
			return;
		}
		StopCoroutine(PlayerWatcher());
		SoundsManager.Instance.onSoundVolumeChange -= OnSoundVolumeChange;
		if (mAnimatingNearDeath)
		{
			if (heartbeat.isPlaying)
			{
				heartbeat.Stop();
			}
			StopCoroutine(AnimateNearDeath());
		}
		mPlayer = null;
		mAnimatingNearDeath = false;
		mAnimateHealthChangeCoroutine = null;
	}

	private IEnumerator PlayerWatcher()
	{
		while (mPlayer != null)
		{
			if (mCurrentHealthRatio != mPlayer.destroyableParts.healthRatio)
			{
				if (mAnimateHealthChangeCoroutine != null)
				{
					StopCoroutine(mAnimateHealthChangeCoroutine);
					mAnimateHealthChangeCoroutine = null;
				}
				if (mPlayer.destroyableParts.healthRatio > mCurrentHealthRatio)
				{
					mCurrentHealthRatio = mPlayer.destroyableParts.healthRatio;
					health.transform.localScale = health.transform.localScale.ReplaceX(mCurrentHealthRatio * mHealthWidth);
					healthChange.gameObject.SetActive(value: false);
				}
				else
				{
					mCurrentHealthRatio = mPlayer.destroyableParts.healthRatio;
					mAnimateHealthChangeCoroutine = StartCoroutine(AnimateHealthChange());
				}
				if (!mAnimatingNearDeath)
				{
					StopCoroutine(AnimateBarFade());
					StartCoroutine(AnimateBarFade());
				}
			}
			if (!mAnimatingNearDeath && mPlayer.IsNearDeath())
			{
				StopCoroutine(AnimateBarFade());
				if (mPlayer.isCurrentPlayer)
				{
					heartbeat.volume = SoundsManager.Instance.soundsVolume;
					heartbeat.Play();
				}
				StartCoroutine(AnimateNearDeath());
			}
			yield return null;
		}
	}

	private IEnumerator AnimateHealthChange()
	{
		healthChange.gameObject.SetActive(value: true);
		float timer = 0f;
		float desiredWidth = mCurrentHealthRatio * mHealthWidth;
		do
		{
			timer += TimeManager.deltaTimeWithoutPauses;
			float healthDelta = mHealthWidth * TimeManager.deltaTimeWithoutPauses / healthChangeMainSpeed;
			float healthChangeDelta = ((!(timer < healthChangeDelay)) ? (mHealthWidth * TimeManager.deltaTimeWithoutPauses / healthChangeSpeed) : 0f);
			health.transform.localScale = health.transform.localScale.ReplaceX(Mathf.Max(desiredWidth, health.transform.localScale.x - healthDelta));
			healthChange.transform.localScale = healthChange.transform.localScale.ReplaceX(Mathf.Max(desiredWidth, healthChange.transform.localScale.x - healthChangeDelta));
			yield return null;
		}
		while (healthChange.transform.localScale.x > desiredWidth || health.transform.localScale.x > desiredWidth);
		healthChange.gameObject.SetActive(value: false);
	}

	private IEnumerator AnimateBarFade()
	{
		health.color = health.color.ReplaceA(1f);
		yield return new WaitForSeconds(healthFadeDelay);
		float phase = 0f;
		while (phase < 1f)
		{
			phase = Mathf.Clamp01(phase + TimeManager.deltaTimeWithoutPauses / healthFadeTime);
			health.color = health.color.ReplaceA(Mathf.Lerp(1f, healthFadeAlpha, phase));
			yield return 0;
		}
	}

	private IEnumerator AnimateNearDeath()
	{
		mAnimatingNearDeath = true;
		while (mPlayer != null && mPlayer.IsNearDeath())
		{
			float phase = TimeManager.realTimeWithoutPauses / nearDeathPeriod;
			float alpha = nearDeathAlphaAnimation.Evaluate(phase);
			health.alpha = alpha;
			yield return null;
		}
		health.alpha = 1f;
		mAnimatingNearDeath = false;
		if (heartbeat.isPlaying)
		{
			heartbeat.Stop();
		}
	}

	private IEnumerator ShowAnimation()
	{
		Coroutine showBackground = StartCoroutine(ShowBarAnimation(background, mBackgroundWidth, showBackgroundTime, 0f + showDelay));
		Coroutine showHealthBar = StartCoroutine(ShowBarAnimation(health, mHealthWidth, showHealthBarTime, showHealthBarDelay + showDelay));
		Coroutine showName = StartCoroutine(ShowName(showNameTime, showNameDelay + showDelay));
		yield return showBackground;
		yield return showHealthBar;
		yield return showName;
	}

	private IEnumerator ShowBarAnimation(UISprite bar, float width, float time, float delay)
	{
		bar.transform.localScale = bar.transform.localScale.ReplaceX(0f);
		yield return new WaitForSeconds(delay);
		float phase = 0f;
		while (phase < 1f)
		{
			phase = Mathf.Clamp01(phase + TimeManager.deltaTimeWithoutPauses / time);
			bar.transform.localScale = bar.transform.localScale.ReplaceX(phase * width);
			yield return null;
		}
	}

	private IEnumerator ShowName(float time, float delay)
	{
		nameLabel.alpha = 0f;
		yield return new WaitForSeconds(delay);
		float phase = 0f;
		while (phase < 1f)
		{
			phase = Mathf.Clamp01(phase + TimeManager.deltaTimeWithoutPauses / time);
			nameLabel.alpha = phase;
			nameLabelHandle.localPosition = nameLabelHandle.transform.localPosition.ReplaceY(showNamePositionAnimation.Evaluate(phase));
			yield return null;
		}
	}

	private void InitPlayer()
	{
		mPlayer = ((!playerHealthBar) ? PlayerController.GetEnemyOf(PlayerController.currentPlayer.fraction) : PlayerController.currentPlayer);
		nameLabel.text = mPlayer.playerProperties.name;
	}

	private void OnSoundVolumeChange()
	{
		heartbeat.volume = SoundsManager.Instance.soundsVolume;
	}

	public void Hide()
	{
		StopAllCoroutines();
		background.gameObject.SetActive(value: false);
		healthChange.gameObject.SetActive(value: false);
		health.gameObject.SetActive(value: false);
		nameLabel.gameObject.SetActive(value: false);
	}

	public void ShowUp()
	{
		InitPlayer();
		StopAllCoroutines();
		background.gameObject.SetActive(value: true);
		health.gameObject.SetActive(value: true);
		nameLabel.gameObject.SetActive(value: true);
		health.color = health.color.ReplaceA(healthFadeAlpha);
		StartCoroutine(ShowAnimation());
	}

	public void FakeGameStartedAndShowUp()
	{
		InitPlayer();
		StopAllCoroutines();
		OnGameStarted();
		background.gameObject.SetActive(value: true);
		health.gameObject.SetActive(value: true);
		nameLabel.gameObject.SetActive(value: true);
		StartCoroutine(ShowAnimation());
	}
}
