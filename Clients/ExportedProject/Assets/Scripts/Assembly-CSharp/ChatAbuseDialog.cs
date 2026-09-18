using System;
using System.Collections.Generic;
using UnityEngine;

public class ChatAbuseDialog : GuiElementSingle<ChatAbuseDialog>, IGuiDialog
{
	public const string POPUP_REALLIFE = "ID_GUI_REPORTABUSE_LISTITEM0";

	public const string POPUP_CHILD = "ID_GUI_REPORTABUSE_LISTITEM1";

	public const string POPUP_SEXUAL = "ID_GUI_REPORTABUSE_LISTITEM2";

	public const string POPUP_HATE = "ID_GUI_REPORTABUSE_LISTITEM3";

	public const string POPUP_HARRASMENT = "ID_GUI_REPORTABUSE_LISTITEM4";

	public const string POPUP_SPAM = "ID_GUI_REPORTABUSE_LISTITEM5";

	public const string POPUP_CHEAT = "ID_GUI_REPORTABUSE_LISTITEM6";

	public const string POPUP_OFFENSIVE = "ID_GUI_REPORTABUSE_LISTITEM7";

	public const string POPUP_SCROLLING = "ID_GUI_REPORTABUSE_LISTITEM8";

	[Header("Core")]
	public ChatAbusePopUpList popUpList;

	[Header("Buttons")]
	public UIButton butonClose;

	public UIButton buttonCancel;

	[Header("-Submit")]
	public UIButton submitButton;

	public BoxCollider submitCollider;

	public UISprite submitBackground;

	private string mPlayerId;

	private string mMessage;

	private ChatReportType mReportType;

	private Dictionary<string, ChatReportType> mReportDictionary;

	public static void ShowAbuseDialog(string playerId, string message)
	{
		ChatAbuseDialog chatAbuseDialog = GuiElementSingle<ChatAbuseDialog>.instance;
		chatAbuseDialog.mPlayerId = playerId;
		chatAbuseDialog.mMessage = message;
		Singleton<GuiManager>.instance.ShowDialog(chatAbuseDialog, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonCancel.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(butonClose.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(submitButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(SubmitButtonClick));
		FillDictionary();
		popUpList.popUpList.SetDefaultValue();
		popUpList.OnSelect += OnSelect;
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void SubmitButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<BeanstalkServerManager>.instance.SendPlayerReport(mPlayerId, mMessage, (int)mReportType);
			HideDialog();
		}
	}

	private void OnSelect(string selection, UILabel label)
	{
		if (base.isFullyShowed)
		{
			SetSubmitButton(enabled: true);
			label.color = Colours.grayDark;
			if (!mReportDictionary.ContainsKey(selection))
			{
				FillDictionary();
			}
			if (mReportDictionary.ContainsKey(selection))
			{
				mReportType = mReportDictionary[selection];
			}
			else
			{
				mReportType = ChatReportType.Advertising;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
		}
	}

	public override void InitGUIValues()
	{
		popUpList.ResetToDefault();
		SetSubmitButton(enabled: false);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiElementSingle<ChatGuiElement>.instance.chatContent.draggablePanel.forceDrag = false;
		GuiElementSingle<ChatGuiElement>.instance.messageContent.draggablePanel.forceDrag = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		GuiElementSingle<ChatGuiElement>.instance.chatContent.draggablePanel.forceDrag = true;
		GuiElementSingle<ChatGuiElement>.instance.messageContent.draggablePanel.forceDrag = true;
	}

	private void SetSubmitButton(bool enabled)
	{
		submitCollider.enabled = enabled;
		submitBackground.color = ((!enabled) ? Color.white.ReplaceA(0.5f) : Color.white);
		submitButton.enabled = enabled;
	}

	private void FillDictionary()
	{
		if (mReportDictionary == null)
		{
			mReportDictionary = new Dictionary<string, ChatReportType>();
		}
		if (mReportDictionary.Count > 0)
		{
			mReportDictionary.Clear();
		}
		mReportDictionary.Add("ID_GUI_REPORTABUSE_LISTITEM6", ChatReportType.CheatInfo);
		mReportDictionary.Add("ID_GUI_REPORTABUSE_LISTITEM1", ChatReportType.ChildSolicitation);
		mReportDictionary.Add("ID_GUI_REPORTABUSE_LISTITEM4", ChatReportType.HarassmentOrStalking);
		mReportDictionary.Add("ID_GUI_REPORTABUSE_LISTITEM3", ChatReportType.HateSpeech);
		mReportDictionary.Add("ID_GUI_REPORTABUSE_LISTITEM7", ChatReportType.OffensiveLanguage);
		mReportDictionary.Add("ID_GUI_REPORTABUSE_LISTITEM0", ChatReportType.RealLifeThreat);
		mReportDictionary.Add("ID_GUI_REPORTABUSE_LISTITEM8", ChatReportType.ExcessiveSpamming);
		mReportDictionary.Add("ID_GUI_REPORTABUSE_LISTITEM2", ChatReportType.SexualOrVulgarContent);
		mReportDictionary.Add("ID_GUI_REPORTABUSE_LISTITEM5", ChatReportType.Advertising);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(buttonCancel.gameObject);
	}
}
