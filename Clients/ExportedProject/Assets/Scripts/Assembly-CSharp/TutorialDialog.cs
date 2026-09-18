using System;
using UnityEngine;

public class TutorialDialog : GuiElementSingle<TutorialDialog>, IGuiDialog
{
	public enum DialogPosition
	{
		TopLeft,
		Top,
		TopRight,
		Left,
		Center,
		Right,
		BottomLeft,
		Bottom,
		BottomRight
	}

	public enum DialogTutorialType
	{
		Game,
		Menu,
		Special,
		Reward
	}

	[Header("Game Tutorial")]
	public GameObject gameTutorial;

	public GameObject gameTutorialCollider;

	public UISprite soldier;

	public GameObject soldierScale;

	public UITable textAndButtonTable;

	public GameObject upTextParentGameObject;

	public UILabel upText;

	public GameObject downTextParentGameObject;

	public UILabel downText;

	public GameObject continueButton;

	public BoxCollider continueButtonCollider;

	public UISprite deployIcon;

	public UIPanel unitTypesPanel;

	public UISprite unitTypeSprite;

	[Header("Menu Tutorial")]
	public GameObject menuTutorial;

	public BoxCollider menuTutorialCollider;

	public UISprite menuSoldier;

	public GameObject menuSoldierScale;

	public UILabel menuUpText;

	public UILabel menuDownText;

	[Header("Special Tutorial")]
	public GameObject specialTutorial;

	public UILabel specialLabel;

	[Header("Reward Tutorial")]
	public GameObject rewardTutorial;

	public UISprite rewardSoldier;

	public GameObject rewardSoldierScale;

	public GameObject waitingOverlay;

	public UITable contentTable;

	public GameObject waitingSprite;

	public UITable rewardTable;

	public UILabel wbReward;

	public UILabel goldReward;

	public UILabel rewardMiddleText;

	public UILabel rewardBottomText;

	private DialogTutorialType mCurrentType;

	private TweenAnimator mShowUpAnimator;

	private TweenAnimator.TweenRecord mShowUpDialog1;

	private TweenAnimator.TweenRecord mShowUpDialog2;

	private float mShownTime;

	private float mLastRealTime;

	private bool mHideDialog;

	private bool mAfterShowUpTweens;

	private bool mDebugStrangeBehaviour;

	public bool continueClicked { get; private set; }

	public bool blinkText { get; set; }

	public float minimalShowTime => 1.5f;

	public bool setDebug
	{
		set
		{
			mDebugStrangeBehaviour = value;
		}
	}

	public void ShowGameTutorialDirectly(string textUp, string textDown, float multiplier, DialogPosition dialogPosition = DialogPosition.Center, bool showContinue = false, bool useCollider = false)
	{
		mCurrentType = DialogTutorialType.Game;
		SetContent();
		continueClicked = false;
		continueButton.SetActive(showContinue);
		gameTutorialCollider.SetActive(useCollider);
		SetDialogPosition(multiplier, dialogPosition);
		upText.text = textUp;
		downText.text = textDown;
		blinkText = true;
		SetTextAndContinueButtonPositions();
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 0f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public void ShowGameTutorial(string textUp, string textDown, float multiplier, DialogPosition dialogPosition = DialogPosition.Center, bool showContinue = false, bool showDeployIcon = false)
	{
		deployIcon.gameObject.SetActive(showDeployIcon);
		upText.lineWidth = ((!showDeployIcon) ? 675 : 470);
		ShowGameTutorialDirectly((!(textUp == string.Empty)) ? Localization.Localize(textUp) : textUp, (!(textDown == string.Empty)) ? Localization.Localize(textDown) : textDown, multiplier, dialogPosition, showContinue);
		soldier.spriteName = "game-tilegfx-tutorial";
		soldier.MakePixelPerfect();
	}

	public void ShowMenuTutorial(string textUp, string textDown, float multiplier, DialogPosition dialogPosition = DialogPosition.Center, bool useCollider = true)
	{
		mCurrentType = DialogTutorialType.Menu;
		SetContent();
		blinkText = true;
		SetDialogPosition(multiplier, dialogPosition);
		menuTutorialCollider.enabled = useCollider;
		menuUpText.text = textUp;
		menuDownText.text = textDown;
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 0f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public void ShowSpecial(string text, float multiplier, DialogPosition dialogPosition = DialogPosition.Center)
	{
		mCurrentType = DialogTutorialType.Special;
		SetContent();
		blinkText = true;
		SetDialogPosition(multiplier, dialogPosition);
		specialLabel.text = ((!(text == string.Empty) && text.StartsWith("ID_")) ? Localization.Localize(text) : text);
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 0f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public void ShowReward(string middleText, string bottomText, int wb, int gold, float multiplier, DialogPosition dialogPosition = DialogPosition.Center)
	{
		mCurrentType = DialogTutorialType.Reward;
		SetContent();
		blinkText = true;
		SetDialogPosition(multiplier, dialogPosition);
		bool flag = wb + gold == 0;
		waitingSprite.gameObject.SetActive(flag);
		waitingOverlay.gameObject.SetActive(flag);
		rewardTable.gameObject.SetActive(!flag);
		if (!flag)
		{
			rewardTable.repositionNow = true;
			GuiElementSingle<MenuHeader>.instance.AnimateToCurrentValues();
		}
		wbReward.text = MiscTools.FormatBigNumber(wb);
		goldReward.text = MiscTools.FormatBigNumber(gold);
		rewardMiddleText.text = middleText;
		rewardBottomText.text = bottomText;
		contentTable.repositionNow = true;
		if (!isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 0f);
		}
		else
		{
			InitGUIValues();
		}
	}

	public void SetSoldierSprite(string gameTutorialSniper, string unitTypeSpriteName)
	{
		soldier.spriteName = gameTutorialSniper;
		soldier.MakePixelPerfect();
		unitTypeSprite.gameObject.SetActive(value: true);
		unitTypeSprite.spriteName = unitTypeSpriteName;
		unitTypeSprite.MakePixelPerfect();
	}

	private void SetContent()
	{
		gameTutorial.SetActive(mCurrentType == DialogTutorialType.Game);
		menuTutorial.SetActive(mCurrentType == DialogTutorialType.Menu);
		specialTutorial.SetActive(mCurrentType == DialogTutorialType.Special);
		rewardTutorial.SetActive(mCurrentType == DialogTutorialType.Reward);
	}

	public override void InitEvents()
	{
		base.InitEvents();
		UIEventListener uIEventListener = UIEventListener.Get(continueButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ContinueClick));
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
		mShownTime = 0f;
		mLastRealTime = Time.realtimeSinceStartup;
		mHideDialog = false;
		if (mDebugStrangeBehaviour)
		{
			Debug.Log("#PETER# Tutorial Dialog - showing and mHideDialog is set to false");
		}
		continueButtonCollider.enabled = mAfterShowUpTweens;
	}

	public void Hide()
	{
		if (mDebugStrangeBehaviour)
		{
			Debug.Log("#PETER# Tutorial Dialog - Hide was called");
		}
		mHideDialog = true;
	}

	protected override void Update()
	{
		base.Update();
		float num = Time.realtimeSinceStartup - mLastRealTime;
		mShownTime += num;
		mLastRealTime = Time.realtimeSinceStartup;
		if (mShownTime > minimalShowTime)
		{
			AfterTweensFinished();
			if (base.isFullyShowed && mHideDialog)
			{
				HideDialog();
			}
		}
	}

	private void ContinueClick(GameObject go)
	{
		if (mAfterShowUpTweens)
		{
			continueClicked = true;
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampClick);
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampDialogDissapear);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampClick);
			SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampDialogDissapear);
		}
	}

	private void ShowUpTweens()
	{
		mAfterShowUpTweens = false;
		if (mCurrentType == DialogTutorialType.Special)
		{
			mAfterShowUpTweens = true;
			return;
		}
		GameObject dialog = menuTutorial;
		GameObject soldierParent = menuSoldierScale;
		UISprite uISprite = menuSoldier;
		if (mCurrentType == DialogTutorialType.Game)
		{
			dialog = gameTutorial;
			soldierParent = soldierScale;
			uISprite = soldier;
		}
		else if (mCurrentType == DialogTutorialType.Reward)
		{
			dialog = rewardTutorial;
			soldierParent = rewardSoldierScale;
			uISprite = rewardSoldier;
		}
		Vector3 position = dialog.transform.localPosition;
		uISprite.alpha = 0f;
		TweenAlpha tweenAlpha = TweenAlpha.Begin(uISprite.gameObject, 0.3f, 0f, 1f);
		tweenAlpha.delay = 0.2f;
		TweenPosition tweenPosition = TweenPosition.Begin(dialog, 0.4f, position + new Vector3(0f, 50f, 0f));
		tweenPosition.method = UITweener.Method.EaseIn;
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition3 = TweenPosition.Begin(dialog, 0.4f, position);
			tweenPosition3.method = UITweener.Method.EaseOut;
			tweenPosition3.onFinished = delegate
			{
				AfterTweensFinished();
			};
		};
		TweenPosition tweenPosition2 = TweenPosition.Begin(soldierParent, 0.4f, new Vector3(-360f, -250f, 0f), new Vector3(-360f, -300f, 0f));
		tweenPosition2.method = UITweener.Method.EaseIn;
		tweenPosition2.onFinished = delegate
		{
			TweenPosition tweenPosition3 = TweenPosition.Begin(soldierParent, 0.4f, new Vector3(-360f, -250f, 0f));
			tweenPosition3.method = UITweener.Method.EaseOut;
		};
		TweenScale tweenScale = TweenScale.Begin(soldierParent, 0.3f, new Vector3(1f, 1f, 1f), new Vector3(1.1f, 1.1f, 1.1f));
		tweenScale.delay = 0.2f;
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(soldierParent, 0.3f, Vector3.one);
			tweenScale2.method = UITweener.Method.EaseOut;
		};
		TweenAlpha.Begin(unitTypesPanel.gameObject, 0.3f, 0f, 1f);
	}

	private void AfterTweensFinished()
	{
		mAfterShowUpTweens = true;
		continueButtonCollider.enabled = true;
	}

	private void SetDialogPosition(float multiplier, DialogPosition dialogPosition)
	{
		float num = 0f;
		if (dialogPosition == DialogPosition.TopLeft || dialogPosition == DialogPosition.Left || dialogPosition == DialogPosition.BottomLeft)
		{
			num = 550f - UIRoot.list[0].activeWidth / 2f - 20f;
		}
		if (dialogPosition == DialogPosition.TopRight || dialogPosition == DialogPosition.Right || dialogPosition == DialogPosition.BottomRight)
		{
			num = UIRoot.list[0].activeWidth / 2f - 550f + 20f;
		}
		if ((dialogPosition == DialogPosition.TopLeft || dialogPosition == DialogPosition.Top || dialogPosition == DialogPosition.TopRight) && multiplier < 0f)
		{
			multiplier *= -1f;
		}
		if ((dialogPosition == DialogPosition.BottomLeft || dialogPosition == DialogPosition.Bottom || dialogPosition == DialogPosition.BottomRight) && multiplier > 0f)
		{
			multiplier *= -1f;
		}
		float y = multiplier * ((float)UIRoot.list[0].activeHeight / 2f);
		switch (mCurrentType)
		{
		case DialogTutorialType.Special:
			specialTutorial.transform.localPosition = new Vector3(num + 90f, y, 0f);
			break;
		case DialogTutorialType.Game:
			gameTutorial.transform.localPosition = new Vector3(num, y, 0f);
			break;
		case DialogTutorialType.Menu:
			menuTutorial.transform.localPosition = new Vector3(num, y, 0f);
			break;
		case DialogTutorialType.Reward:
			rewardTutorial.transform.localPosition = new Vector3(num, y, 0f);
			break;
		}
	}

	private void SetTextAndContinueButtonPositions()
	{
		bool flag = !string.IsNullOrEmpty(downText.text);
		downTextParentGameObject.SetActive(flag);
		if (continueButton.activeSelf)
		{
			textAndButtonTable.enabled = true;
			textAndButtonTable.repositionNow = true;
			float num = upText.relativeSize.y * upText.transform.localScale.y;
			float num2 = ((!flag) ? 0f : (downText.relativeSize.y * downText.transform.localScale.y));
			float num3 = 35f;
			float num4 = 25f;
			float num5 = 500f - (num3 + num4);
			float num6 = 9f + num + num2 + 100f;
			float num7 = ((!flag) ? 2 : 4);
			float num8 = Mathf.Clamp((num5 - num6) / num7, 1f, 500f);
			textAndButtonTable.transform.localPosition = textAndButtonTable.transform.localPosition.ReplaceY(250f + num8 - num3);
			textAndButtonTable.padding = new Vector2(0f, num8);
		}
		else
		{
			textAndButtonTable.transform.localPosition = textAndButtonTable.transform.localPosition.ReplaceY(250f);
			textAndButtonTable.repositionNow = false;
			textAndButtonTable.enabled = false;
			upTextParentGameObject.transform.localPosition = new Vector3(0f, -35f, 0f);
			downTextParentGameObject.transform.localPosition = new Vector3(0f, -465f, 0f);
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampDialog);
		unitTypeSprite.gameObject.SetActive(value: false);
		ShowUpTweens();
		mHideDialog = false;
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		if (mCurrentType != DialogTutorialType.Game && mCurrentType != DialogTutorialType.Menu && mCurrentType == DialogTutorialType.Reward)
		{
			TweenColor tweenColor = TweenColor.Begin(rewardBottomText.gameObject, 0.5f, Colours.blue, Color.white);
			tweenColor.style = (blinkText ? UITweener.Style.PingPong : UITweener.Style.Once);
			if (blinkText)
			{
				tweenColor.NumOfRepetitions = 0;
			}
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		if (mCurrentType == DialogTutorialType.Game)
		{
			TweenPosition.Begin(gameTutorial, 0.5f, gameTutorial.transform.localPosition.AddY(50f));
		}
		else if (mCurrentType == DialogTutorialType.Menu)
		{
			TweenPosition.Begin(menuTutorial, 0.5f, menuTutorial.transform.localPosition.AddY(50f));
		}
		else if (mCurrentType == DialogTutorialType.Reward)
		{
			TweenPosition.Begin(rewardTutorial, 0.5f, rewardTutorial.transform.localPosition.AddY(50f));
			TweenColor tweenColor = TweenColor.Begin(rewardBottomText.gameObject, 0.2f, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mAfterShowUpTweens = false;
		mHideDialog = false;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		if (continueButton.activeSelf)
		{
			ContinueClick(continueButton);
		}
	}
}
