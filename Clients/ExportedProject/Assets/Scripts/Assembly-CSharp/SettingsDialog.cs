using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class SettingsDialog : GuiElementSingle<SettingsDialog>, IGuiDialog
{
	private const string sendLogsText = "SEND LOGS";

	private const string waitingText = "Logs sent to server\nWaiting for response";

	private const string patientText = "Still waiting for server\nBe patient :-)";

	[Header("Close")]
	public UIButton closeButton;

	[Header("4 Header Buttons")]
	public List<SettingsMainButton> settingsButtons;

	[Header("4 Contents")]
	public List<GameObject> contents;

	public SettingsGeneralContent generalContent;

	public SettingsNotificationContent notificationContent;

	public SettingsUserContent userContent;

	public SettingsGuiContent guiContent;

	[Header("Debug")]
	public SettingsDebugContent debugContent;

	[Header("-Send Logs")]
	public GameObject sendLogsButton;

	public UILabel sendLogsButtonLabel;

	[Header("-Debug Button")]
	public UIButton debugOptionsButton;

	public UISprite debugOptionsSprite;

	private int mSelectedContent;

	private bool mDebugEnabled
	{
		get
		{
			return DebugSettings.debugEnabled;
		}
		set
		{
			DebugSettings.debugEnabled = value;
		}
	}

	public void ShowUser()
	{
		mSelectedContent = 2;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 0f);
		}
	}

	public void ShowGeneral()
	{
		mSelectedContent = 0;
		if (isShowed)
		{
			InitGUIValues();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowDialog(this, 0f);
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
		debugContent.DoBeforeHide();
		generalContent.DoBeforeHide();
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		debugContent.DoBeforeShowUp();
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<SessionManager>.instance.ApplicationResumed += OnApplicationResumed;
		debugContent.InitEvents();
	}

	private void OnApplicationResumed()
	{
		if (base.gameObject.activeSelf)
		{
			InitGUIValues();
		}
	}

	public override void InitControls()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		PlayerAnalytics.instance.AddedOneTimeReward += OnAddedOneTimeReward;
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnClose));
		foreach (SettingsMainButton settingsButton in settingsButtons)
		{
			UIEventListener uIEventListener2 = UIEventListener.Get(settingsButton.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ChangeContentClick));
		}
		generalContent.InitControls();
		notificationContent.InitControls();
		userContent.InitControls();
		guiContent.InitControls();
		UIEventListener uIEventListener3 = UIEventListener.Get(sendLogsButton);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(SendLogsButtonClick));
		UIEventListener uIEventListener4 = UIEventListener.Get(debugOptionsButton.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(DebugOptionClick));
		debugContent.InitControls();
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (isShowed)
		{
			switch (action)
			{
			case DatabaseAction.LoginToCustomAccount:
			case DatabaseAction.AddFacebook:
			case DatabaseAction.ChangePlayerName:
			case DatabaseAction.AddGooglePlay:
			case DatabaseAction.RemoveGooglePlay:
				InitGUIValues();
				break;
			case DatabaseAction.SendLog:
				Debug.Log("Changing send logs text to " + Singleton<Logs>.instance.logId);
				sendLogsButtonLabel.text = Singleton<Logs>.instance.logId;
				MiscTools.SetUILabelRescale(sendLogsButtonLabel, 45f, 30f, 280);
				break;
			case DatabaseAction.RemoveFacebook:
				HideDialog();
				break;
			}
		}
	}

	private void OnAddedOneTimeReward(string rewardId)
	{
		if (isShowed && rewardId == Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotificationAllowReward).DBKEY)
		{
			InitGUIValues();
		}
	}

	private void OnClose(GameObject go)
	{
		if (base.isFullyShowed)
		{
			SoundsManager.Instance.Save();
			HideDialog();
			SettingsManager.instance.OnDialogClose();
		}
	}

	private void ChangeContentClick(GameObject go)
	{
		SettingsMainButton button = go.GetComponent<SettingsMainButton>();
		int num = settingsButtons.FindIndex((SettingsMainButton a) => a == button);
		if (num != mSelectedContent)
		{
			mSelectedContent = num;
			for (int num2 = 0; num2 < settingsButtons.Count; num2++)
			{
				settingsButtons[num2].SetHighlight(num2 == mSelectedContent);
				contents[num2].SetActive(num2 == mSelectedContent);
			}
		}
	}

	private void SendLogsButtonClick(GameObject go)
	{
		if (sendLogsButtonLabel.text == "Logs sent to server\nWaiting for response" || sendLogsButtonLabel.text == "Still waiting for server\nBe patient :-)")
		{
			sendLogsButtonLabel.text = "Still waiting for server\nBe patient :-)";
		}
		else
		{
			sendLogsButtonLabel.text = "Logs sent to server\nWaiting for response";
			Singleton<Logs>.instance.SendLogs();
		}
		MiscTools.SetUILabelRescale(sendLogsButtonLabel, 45f, 30f, 280);
	}

	private void DebugOptionClick(GameObject go)
	{
		mDebugEnabled = !mDebugEnabled;
		ShowDebugOptionsBackground();
	}

	public override void InitGUIValues()
	{
		for (int i = 0; i < settingsButtons.Count; i++)
		{
			settingsButtons[i].SetHighlight(i == mSelectedContent);
			contents[i].SetActive(i == mSelectedContent);
		}
		generalContent.InitGUIValues();
		notificationContent.InitGUIValues();
		userContent.InitGUIValues();
		guiContent.InitGUIValues();
		debugOptionsButton.gameObject.SetActive(DebugSettings.isOurDevice);
		ShowDebugOptionsBackground();
		bool canSendLogs = GameLoginManager.instance.canSendLogs;
		sendLogsButton.SetActive(canSendLogs);
		if (canSendLogs)
		{
			sendLogsButtonLabel.text = "SEND LOGS";
			MiscTools.SetUILabelRescale(sendLogsButtonLabel, 45f, 30f, 280);
		}
		debugContent.InitGUIValues();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		userContent.DoAfterHide();
	}

	private void ShowDebugOptionsBackground()
	{
		debugOptionsSprite.spriteName = ((!mDebugEnabled) ? "menu-button-small-white" : "menu-button-small");
		debugContent.gameObject.SetActive(mDebugEnabled);
		if (mDebugEnabled)
		{
			debugContent.InitGUIValues();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		OnClose(closeButton.gameObject);
	}
}
