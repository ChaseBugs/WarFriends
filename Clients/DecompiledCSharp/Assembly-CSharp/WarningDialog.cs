using System;
using UnityEngine;

public class WarningDialog : GuiElementSingle<WarningDialog>, IGuiDialog
{
	private const string mSendLogsText = "SEND LOGS";

	private const string mWaitingText = "Logs sent to server\nWaiting for response";

	private const string mPatientText = "Still waiting for server\nBe patient :-)";

	[Header("Animation Background")]
	public UISprite glow;

	[Header("Dialog")]
	public UIPanel dialogPanel;

	public UILabel titleLabel;

	public UILabel textLabel;

	public GameObject soldierIcon;

	public GameObject lowPingIcon;

	[Header("-Buttons Part")]
	public GameObject oneButtonPart;

	public UIButton okButton;

	public UILabel okLabel;

	public GameObject twoButtonsPart;

	public UIButton firstButton;

	public UILabel firstLabel;

	public UIButton secondButton;

	public UILabel secondLabel;

	[Header("Debug")]
	public GameObject sendLogsButton;

	public UILabel sendLogsLabel;

	[HideInInspector]
	public Action okClicked;

	[HideInInspector]
	public Action<bool> choiceClicked;

	private bool mHiding;

	private bool mUseDialogBackground;

	private bool mCanSendLogs;

	public string setTitleText
	{
		set
		{
			titleLabel.text = value;
			MiscTools.SetUILabelRescale(titleLabel, 84f, 42f, 1420);
		}
	}

	public string setButtonText
	{
		set
		{
			okLabel.text = value;
			MiscTools.SetUILabelRescale(okLabel, 57f, 25f, 440);
		}
	}

	public static WarningDialog ShowError(string text, string title = "", float delay = 0f, Action onOkClick = null, string buttonTitle = "", bool useDialogBackground = false, bool canPlayerSendLogs = false)
	{
		WarningDialog dialog = GuiElementSingle<WarningDialog>.instance;
		if (delay > 0f)
		{
			Singleton<GuiManager>.instance.InvokeAfter(delegate
			{
				SetUpDialog(text, title, onOkClick, buttonTitle, useDialogBackground, dialog, canPlayerSendLogs);
			}, delay);
		}
		else
		{
			SetUpDialog(text, title, onOkClick, buttonTitle, useDialogBackground, dialog, canPlayerSendLogs);
		}
		return dialog;
	}

	private static void SetUpDialog(string text, string title, Action onOkClick, string buttonTitle, bool useDialogBackground, WarningDialog dialog, bool canPlayerSendLogs)
	{
		dialog.mCanSendLogs = canPlayerSendLogs;
		dialog.setTitleText = ((!string.IsNullOrEmpty(title)) ? title : Localization.Localize("ID_WARNING"));
		dialog.textLabel.text = text;
		dialog.SetButtons(1);
		dialog.setButtonText = ((!string.IsNullOrEmpty(buttonTitle)) ? buttonTitle : Localization.Localize("ID_OK"));
		dialog.okClicked = onOkClick;
		dialog.choiceClicked = null;
		dialog.ChooseIcon();
		dialog.mHiding = false;
		if (!dialog.isShowed)
		{
			dialog.mUseDialogBackground = useDialogBackground;
		}
		Singleton<GuiManager>.instance.ShowDialog(dialog, 0f);
	}

	public static WarningDialog ShowChoice(string title, string text, string firstButtonTitle, string secondButtonTitle, Action<bool> onChoiceClicked)
	{
		WarningDialog warningDialog = GuiElementSingle<WarningDialog>.instance;
		warningDialog.mCanSendLogs = false;
		warningDialog.setTitleText = title;
		warningDialog.textLabel.text = text;
		warningDialog.SetButtons(2);
		warningDialog.firstLabel.text = firstButtonTitle;
		warningDialog.secondLabel.text = secondButtonTitle;
		warningDialog.okClicked = null;
		warningDialog.choiceClicked = onChoiceClicked;
		warningDialog.ChooseIcon();
		if (!warningDialog.isShowed)
		{
			warningDialog.mUseDialogBackground = false;
		}
		Singleton<GuiManager>.instance.ShowDialog(warningDialog, 0f);
		return warningDialog;
	}

	public static WarningDialog ShowBadConnection()
	{
		WarningDialog warningDialog = GuiElementSingle<WarningDialog>.instance;
		warningDialog.mCanSendLogs = false;
		warningDialog.setTitleText = Localization.Localize("ID_WARNING_POORCONNECTION");
		warningDialog.textLabel.text = Localization.Localize("ID_WARNING_POORCONNECTION_TEXT");
		warningDialog.SetButtons(1);
		warningDialog.setButtonText = Localization.Localize("ID_OK");
		warningDialog.okClicked = null;
		warningDialog.choiceClicked = null;
		warningDialog.ChooseIcon(useDefault: false);
		if (!warningDialog.isShowed)
		{
			warningDialog.mUseDialogBackground = false;
		}
		Singleton<GuiManager>.instance.ShowDialog(warningDialog, 0f);
		return warningDialog;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(okButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OkClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(firstButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FirstClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(secondButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(SecondClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(sendLogsButton);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(SendLogsButtonClick));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += delegate(DatabaseAction action)
		{
			if (isShowed)
			{
				if (action == DatabaseAction.SendLog)
				{
					sendLogsLabel.text = Singleton<Logs>.instance.logId;
					MiscTools.SetUILabelRescale(sendLogsLabel, 45f, 30f, 380);
				}
			}
		};
	}

	private void OkClick(GameObject go)
	{
		if (!mHiding && base.isFullyShowed)
		{
			mHiding = true;
			AnimateHideWarningDialog(0.5f);
			if (okClicked != null)
			{
				Action action = okClicked;
				okClicked = null;
				action();
			}
		}
	}

	private void FirstClick(GameObject go)
	{
		if (!mHiding && base.isFullyShowed)
		{
			mHiding = true;
			if (choiceClicked != null)
			{
				choiceClicked(obj: true);
				choiceClicked = null;
			}
			AnimateHideWarningDialog(0.5f);
		}
	}

	private void SecondClick(GameObject go)
	{
		if (!mHiding && base.isFullyShowed)
		{
			mHiding = true;
			if (choiceClicked != null)
			{
				choiceClicked(obj: false);
				choiceClicked = null;
			}
			AnimateHideWarningDialog(0.5f);
		}
	}

	private void SendLogsButtonClick(GameObject go)
	{
		if (sendLogsLabel.text == "Logs sent to server\nWaiting for response" || sendLogsLabel.text == "Still waiting for server\nBe patient :-)")
		{
			sendLogsLabel.text = "Still waiting for server\nBe patient :-)";
		}
		else
		{
			sendLogsLabel.text = "Logs sent to server\nWaiting for response";
			Singleton<Logs>.instance.SendLogs();
		}
		MiscTools.SetUILabelRescale(sendLogsLabel, 45f, 30f, 380);
	}

	public override void InitGUIValues()
	{
		mHiding = false;
		bool flag = GameLoginManager.instance.canSendLogs || mCanSendLogs;
		Debug.LogError("WarningDialog - Can send logs: " + flag);
		sendLogsButton.SetActive(flag);
		if (flag)
		{
			sendLogsLabel.text = "SEND LOGS";
			MiscTools.SetUILabelRescale(sendLogsLabel, 45f, 30f, 380);
		}
	}

	private void SetButtons(int number)
	{
		oneButtonPart.SetActive(number <= 1);
		twoButtonsPart.SetActive(number > 1);
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		AnimateShowWarningDialog(0.7f);
		if (mUseDialogBackground)
		{
			DialogBackground.instance.ShowBackground(0.7f);
		}
	}

	private void ResetTweens()
	{
		UITweener[] componentsInChildren = GetComponentsInChildren<UITweener>();
		foreach (UITweener uITweener in componentsInChildren)
		{
			uITweener.enabled = false;
		}
	}

	private void AnimateShowWarningDialog(float time)
	{
		ResetTweens();
		base.gameObject.SetActive(value: true);
		float dur = time / 15f;
		float zzz = base.transform.localPosition.z;
		TweenAlpha.Begin(dialogPanel.gameObject, time, 0.005f, 1f);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, dur * 6f, new Vector3(0f, -4f * mDistance, zzz), new Vector3(0f, -4f * mDistance, zzz));
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, dur * 5f, new Vector3(0f, mDistance, zzz));
			tweenPosition2.method = UITweener.Method.Linear;
			tweenPosition2.onFinished = delegate
			{
				TweenPosition tweenPosition3 = TweenPosition.Begin(base.gameObject, dur * 4f, new Vector3(0f, 0f, zzz));
				tweenPosition3.method = UITweener.Method.EaseOut;
			};
		};
		TweenAlpha.Begin(base.gameObject, dur, 0.005f, 1f).onFinished = null;
		Vector3 UpScale = new Vector3(3425f, 1356f, 1f);
		Vector3 EndScale = new Vector3(2740f, 1017f, 1f);
		TweenAlpha.Begin(overlayBackground.gameObject, dur * 6f, 0f, 0.84f);
		TweenScale tweenScale = TweenScale.Begin(glow.gameObject, dur * 11f, Vector3.one, Vector3.one);
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(glow.gameObject, dur * 2f, Vector3.one, UpScale);
			tweenScale2.method = UITweener.Method.Linear;
			tweenScale2.onFinished = delegate
			{
				TweenScale tweenScale3 = TweenScale.Begin(glow.gameObject, dur * 2f, EndScale);
				tweenScale3.method = UITweener.Method.EaseOut;
			};
		};
		TweenAlpha.Begin(glow.gameObject, dur * 9f, 0f, 0f).onFinished = delegate
		{
			TweenAlpha.Begin(glow.gameObject, dur * 2f, 1f);
		};
	}

	private void AnimateHideWarningDialog(float time)
	{
		TweenAlpha.Begin(dialogPanel.gameObject, time, 0.005f);
		TweenAlpha.Begin(overlayBackground.gameObject, time, 0f);
		TweenScale.Begin(glow.gameObject, time, Vector3.one).onFinished = null;
		TweenAlpha.Begin(glow.gameObject, time, 0f);
		TweenAlpha.Begin(base.gameObject, time, 0.005f).onFinished = delegate
		{
			HideDialog();
			mHiding = false;
		};
		if (mUseDialogBackground)
		{
			DialogBackground.instance.HideBackground(time);
		}
	}

	private void ChooseIcon(bool useDefault = true)
	{
		soldierIcon.SetActive(useDefault);
		lowPingIcon.SetActive(!useDefault);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		if (oneButtonPart.activeSelf)
		{
			OkClick(okButton.gameObject);
		}
	}
}
