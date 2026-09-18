using System;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatchGuiCard : Core_BaseScript
{
	[NonSerialized]
	public SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition;

	public UISprite blueOverlay;

	public UISprite border;

	[Header("Main Part")]
	public UILabel count;

	public UISprite fill;

	public UISprite fillReady;

	public UISprite icon;

	public Vector3 initPosition;

	public Vector3 initPositionPP;

	private bool mAnimateHide;

	public bool mCanShowPower = true;

	private bool mClickDisabled;

	protected bool mEnabled = true;

	private bool mHasEnoughPower;

	private DeathMatchUnitsGuiElement mOwner;

	private bool mPlayProgress;

	private float mProgress;

	private UISprite mUnitTypeSprite;

	public DeathMatchGuiCardProgress powerProgress;

	public UISprite progress;

	public UISprite progressBg;

	[Header("Right part")]
	public GameObject rightPart;

	public UILabel rightPartLabel;

	public List<UISprite> rightPartUnitTypeSprites;

	public UISprite selectedOverlay;

	public List<UISprite> unitTypeSprites;

	public bool ShowPower
	{
		get
		{
			return mCanShowPower;
		}
		set
		{
			mCanShowPower = value;
		}
	}

	public bool isSelected { get; private set; }

	public bool hasEnoughPower
	{
		get
		{
			return mHasEnoughPower;
		}
		set
		{
			if (mHasEnoughPower != value)
			{
				mHasEnoughPower = value;
				GetComponent<UIButtonScale>().enabled = mHasEnoughPower;
				SetEnabledAnimated(mHasEnoughPower);
			}
		}
	}

	public void Init(DeathMatchUnitsGuiElement owner)
	{
		mOwner = owner;
		progressBg.alpha = 0f;
		initPosition = base.transform.localPosition;
		initPositionPP = powerProgress.transform.localPosition;
		mEnabled = true;
		mAnimateHide = false;
		blueOverlay.alpha = 0f;
		selectedOverlay.alpha = 0f;
		selectedOverlay.transform.localScale = selectedOverlay.transform.localScale.ReplaceY(250f);
		foreach (UISprite unitTypeSprite in unitTypeSprites)
		{
			unitTypeSprite.gameObject.SetActive(value: false);
		}
		rightPart.gameObject.SetActive(value: false);
		foreach (UISprite rightPartUnitTypeSprite in rightPartUnitTypeSprites)
		{
			rightPartUnitTypeSprite.enabled = false;
		}
		rightPartLabel.enabled = false;
	}

	private void OnClick()
	{
		if (base.enabled && mEnabled && hasEnoughPower && PlayerController.currentPlayer.canSendUnits && !mClickDisabled)
		{
			Debug.Log("generate" + base.name + " " + armyUnitDefinition);
			mOwner.SendUnit(this, armyUnitDefinition, clicked: true);
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.DeplyUnits);
		}
	}

	public void PreShowPowerProgress(SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition)
	{
		powerProgress.Show(armyUnitDefinition);
	}

	public virtual void Show(SpawningManagerDeathMatch.ArmyUnitDefinition armyUnitDefinition, bool instant = false)
	{
		isSelected = false;
		mUnitTypeSprite = null;
		this.armyUnitDefinition = armyUnitDefinition;
		progress.fillAmount = 0f;
		mPlayProgress = false;
		TweenAlpha.Begin(blueOverlay.gameObject, 0f, 0f).style = UITweener.Style.Once;
		if (this.armyUnitDefinition != null)
		{
			count.text = "x" + this.armyUnitDefinition.numberOfEnemies;
			icon.type = UISprite.Type.Filled;
			icon.fillDirection = UISprite.FillDirection.HorizontalCutted;
			icon.spriteName = this.armyUnitDefinition.armyUnit.menuIcon;
			icon.pivot = this.armyUnitDefinition.armyUnit.pivot;
			icon.fillAmount = this.armyUnitDefinition.armyUnit.fillAmount;
			icon.fillAmountBack = this.armyUnitDefinition.armyUnit.fillAmountBack;
			icon.MakePixelPerfect();
			float multiplier = Mathf.Min(1f, this.armyUnitDefinition.armyUnit.height / icon.transform.localScale.y);
			icon.transform.localScale = icon.transform.localScale.MultiplyXY(multiplier);
			icon.transform.localPosition = this.armyUnitDefinition.armyUnit.localPosition;
			icon.enabled = true;
			int unitType = (int)armyUnitDefinition.armyUnit.behaviour.unitType;
			for (int i = 0; i < unitTypeSprites.Count; i++)
			{
				UISprite uISprite = unitTypeSprites[i];
				if (i == unitType)
				{
					mUnitTypeSprite = uISprite;
					uISprite.gameObject.SetActive(value: true);
					mUnitTypeSprite.alpha = 1f;
				}
				else
				{
					uISprite.gameObject.SetActive(value: false);
				}
			}
			rightPart.SetActive(value: false);
			for (int j = 0; j < rightPartUnitTypeSprites.Count; j++)
			{
				UISprite uISprite2 = rightPartUnitTypeSprites[j];
				uISprite2.enabled = j == unitType;
			}
			mEnabled = true;
			hasEnoughPower = (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeft >= armyUnitDefinition.power;
			GetComponent<Collider>().enabled = true;
			SetEnabled(hasEnoughPower);
			TweenAlpha.Begin(count.gameObject, 0.3f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(icon.gameObject, 0.3f, 0f, (!hasEnoughPower) ? 0.6f : 1f);
			TweenAlpha.Begin(progressBg.gameObject, 0.3f, 0f);
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, (!instant) ? 0.3f : 0f, initPosition - new Vector3(0f, 350f, 0f), initPosition);
			tweenPosition.delay = 0f;
			mAnimateHide = false;
			rightPartLabel.enabled = true;
			rightPartLabel.text = armyUnitDefinition.armyUnit.behaviour.unitTypeNameHUD;
		}
		else
		{
			count.text = string.Empty;
			icon.enabled = false;
			TweenAlpha.Begin(icon.gameObject, 0f, 1f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(count.gameObject, 0.3f, 0f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(progressBg.gameObject, 0.3f, 0f);
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, 0.3f, initPosition - new Vector3(0f, 350f, 0f), initPosition);
			tweenPosition2.delay = 0f;
			mAnimateHide = false;
			foreach (UISprite unitTypeSprite in unitTypeSprites)
			{
				unitTypeSprite.gameObject.SetActive(value: false);
			}
			rightPart.SetActive(value: false);
			foreach (UISprite rightPartUnitTypeSprite in rightPartUnitTypeSprites)
			{
				rightPartUnitTypeSprite.enabled = false;
			}
			mEnabled = false;
			hasEnoughPower = false;
			GetComponent<UIButtonScale>().enabled = false;
			GetComponent<Collider>().enabled = false;
			rightPartLabel.enabled = false;
		}
		powerProgress.Show(armyUnitDefinition);
	}

	protected void Update()
	{
		if (mPlayProgress)
		{
			mProgress = Mathf.Lerp(mProgress, Singleton<SpawningManagerDeathMatch>.instance.progress, Time.deltaTime * 5f);
			progress.fillAmount = 1f - Singleton<SpawningManagerDeathMatch>.instance.progress;
			if (Singleton<SpawningManagerDeathMatch>.instance.progress == 0f && !mAnimateHide)
			{
				mAnimateHide = true;
				AnimateSpawn();
			}
		}
		if (mEnabled && armyUnitDefinition != null)
		{
			powerProgress.DoUpdate();
			hasEnoughPower = (int)Singleton<SpawningManagerDeathMatch>.instance.powerLeft >= armyUnitDefinition.power;
		}
	}

	protected virtual void AnimateSpawn()
	{
	}

	protected void HidePowerProgress(bool hide)
	{
		TweenPosition tweenPosition = ((!hide) ? TweenPosition.Begin(powerProgress.gameObject, 0.3f, initPositionPP) : TweenPosition.Begin(powerProgress.gameObject, 0.3f, initPositionPP - new Vector3(0f, 350f, 0f)));
	}

	public void StartProgress()
	{
		isSelected = true;
		mProgress = 0f;
		mPlayProgress = true;
		if (mUnitTypeSprite != null)
		{
			TweenAlpha.Begin(mUnitTypeSprite.gameObject, 0.2f, 0f);
		}
		TweenAlpha.Begin(progressBg.gameObject, 0.3f, 1f);
		TweenAlpha.Begin(icon.gameObject, 0f, 0f, 1f).style = UITweener.Style.Once;
		TweenAlpha.Begin(count.gameObject, 0.3f, 0f, 1f).style = UITweener.Style.Once;
		TweenScale.Begin(blueOverlay.gameObject, 0.3f, new Vector3(197f, 223f, 1f) * 6f, new Vector3(197f, 223f, 1f));
		TweenAlpha.Begin(blueOverlay.gameObject, 0.1f, 1f);
		MoveCard();
		mEnabled = false;
		GetComponent<UIButtonScale>().enabled = false;
	}

	protected virtual void MoveCard()
	{
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 0.3f, mOwner.guiCards[0].initPosition);
		tweenPosition.delay = 0.7f;
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, new UITweener.OnFinished(cardMovedToLeft));
	}

	public virtual void Hide()
	{
		rightPart.gameObject.SetActive(value: true);
		TweenPanelClipping.Begin(rightPart, 0.7f, new Vector4(0f, 0f, 170f, 270f));
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, 1f, base.transform.localPosition - new Vector3(0f, 450f, 0f));
		tweenPosition.delay = 0f;
	}

	private void cardMovedToLeft(UITweener tween)
	{
		if (DebugSettings.instance.data.showHud)
		{
			TweenPanelClipping.Begin(rightPart, 0.7f, new Vector4(0f, 0f, 170f, 270f), new Vector4(0f, 0f, 600f, 270f));
		}
		TweenAlpha.Begin(blueOverlay.gameObject, 0.5f, 0f);
		rightPart.gameObject.SetActive(value: true);
	}

	public virtual void DisableCard()
	{
		mEnabled = false;
		TweenAlpha.Begin(blueOverlay.gameObject, 0.5f, 0f);
		TweenPosition.Begin(base.gameObject, 0.5f, initPosition - Vector3.up * 450f).delay = 0f;
		GetComponent<UIButtonScale>().enabled = false;
	}

	public void StartBlink()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(blueOverlay.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha.delay = 0.15f;
		tweenAlpha = TweenAlpha.Begin(icon.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.PingPong;
		tweenAlpha = TweenAlpha.Begin(count.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public void HideOnGameStarted()
	{
		TweenPosition.Begin(base.gameObject, 0f, initPosition - new Vector3(0f, 450f, 0f));
		TweenAlpha.Begin(selectedOverlay.gameObject, 0f, 0f);
	}

	protected void SetEnabled(bool enabled)
	{
		if (enabled)
		{
			TweenAlpha.Begin(icon.gameObject, 0f, 1f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(fill.gameObject, 0f, 0f, 0f).style = UITweener.Style.Once;
			TweenAlpha.Begin(fillReady.gameObject, 0f, 1f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(border.gameObject, 0f, 1f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(rightPartLabel.gameObject, 0f, 1f, 1f).style = UITweener.Style.Once;
		}
		else
		{
			TweenAlpha.Begin(icon.gameObject, 0f, 0.6f).style = UITweener.Style.Once;
			TweenAlpha.Begin(fill.gameObject, 0f, 0.15f).style = UITweener.Style.Once;
			TweenAlpha.Begin(fillReady.gameObject, 0f, 0f).style = UITweener.Style.Once;
			TweenAlpha.Begin(border.gameObject, 0f, 0.5f).style = UITweener.Style.Once;
			TweenAlpha.Begin(rightPartLabel.gameObject, 0f, 0.5f).style = UITweener.Style.Once;
		}
	}

	private void SetEnabledAnimated(bool enabled)
	{
		if (enabled)
		{
			TweenAlpha.Begin(icon.gameObject, 0.45f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(fill.gameObject, 0.1f, 0f).style = UITweener.Style.Once;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(fillReady.gameObject, 0.15f, 1f);
			tweenAlpha.NumOfRepetitions = 3;
			tweenAlpha.style = UITweener.Style.PingPong;
			TweenAlpha.Begin(border.gameObject, 0.45f, 1f).style = UITweener.Style.Once;
			TweenAlpha.Begin(rightPartLabel.gameObject, 0.45f, 1f).style = UITweener.Style.Once;
		}
		else
		{
			TweenAlpha.Begin(icon.gameObject, 0.3f, 0.6f).style = UITweener.Style.Once;
			TweenAlpha.Begin(fill.gameObject, 0.3f, 0.15f).style = UITweener.Style.Once;
			TweenAlpha.Begin(fillReady.gameObject, 0.3f, 0f).style = UITweener.Style.Once;
			TweenAlpha.Begin(border.gameObject, 0.3f, 0.5f).style = UITweener.Style.Once;
			TweenAlpha.Begin(rightPartLabel.gameObject, 0.3f, 0.5f).style = UITweener.Style.Once;
		}
	}

	public void DisableCardClick()
	{
		mClickDisabled = true;
	}

	public void EnableCardClick()
	{
		mClickDisabled = false;
	}
}
