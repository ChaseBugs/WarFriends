using System;
using System.Collections.Generic;
using UnityEngine;

public class ReportUserDialog : GuiElementSingle<ReportUserDialog>, IGuiDialog
{
	public const string POPUP_INSTAKILL = "ID_REPORTUSER_ITEM0";

	public const string POPUP_SUSPICIOUS = "ID_REPORTUSER_ITEM1";

	public const string POPUP_OTHER = "ID_REPORTUSER_ITEM2";

	[Header("Core")]
	public GameObject butonClose;

	public ChatAbusePopUpList popUpList;

	public GameObject buttonCancel;

	[Header("-Submit Button")]
	public GameObject submitButton;

	public BoxCollider submitCollider;

	public UISprite submitBackground;

	private string mPlayerId;

	private UserReportType mReportType;

	private Dictionary<string, UserReportType> mReportDictionary;

	public static void ShowReportDialog(string playerId)
	{
		ReportUserDialog reportUserDialog = GuiElementSingle<ReportUserDialog>.instance;
		reportUserDialog.mPlayerId = playerId;
		Singleton<GuiManager>.instance.ShowDialog(reportUserDialog, 0f);
	}

	public static void ShowBotReportDialog(int botConfigNumber)
	{
		ReportUserDialog reportUserDialog = GuiElementSingle<ReportUserDialog>.instance;
		reportUserDialog.mPlayerId = botConfigNumber.ToString("'bot-'0");
		Singleton<GuiManager>.instance.ShowDialog(reportUserDialog, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonCancel);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(butonClose);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener3 = UIEventListener.Get(submitButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(SubmitClick));
		popUpList.popUpList.SetDefaultValue();
		popUpList.OnSelect += OnSelectPopUp;
		FillDictionary();
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void SubmitClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			int armyPowerX = LevelManager.instance.armyPowerX10;
			int displayNumber = LevelManager.instance.currentLevel.displayNumber;
			int armyPowerX2 = Singleton<GameController>.instance.opponent.playerProperties.armyPowerX10;
			int level = Singleton<GameController>.instance.opponent.playerProperties.level;
			float matchTime = Singleton<MatchManager>.instance.matchTime;
			GuiScreenSingle<EndScreen>.instance.enemy.DisableReportButton();
			Debug.Log($"Submited: \"{mReportType}\" for player: \"{mPlayerId}\" rank:{level} AP:{MiscTools.FormatBigNumber(armyPowerX2)} and my rank:{displayNumber} AP:{MiscTools.FormatBigNumber(armyPowerX)}. Match duration: {MiscTools.PrintableTimeDigits(matchTime)}");
			Singleton<BeanstalkServerManager>.instance.SendCheaterReport(mPlayerId, (int)mReportType, armyPowerX, displayNumber, level, armyPowerX2, matchTime);
			HideDialog();
		}
	}

	private void OnSelectPopUp(string selection, UILabel label)
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
				mReportType = UserReportType.Other;
			}
			SoundsManager.Instance.PlayButtonClickedSound();
		}
	}

	public override void InitGUIValues()
	{
		popUpList.ResetToDefault();
		SetSubmitButton(enabled: false);
	}

	private void SetSubmitButton(bool enabled)
	{
		submitCollider.enabled = enabled;
		submitBackground.color = ((!enabled) ? Color.white.ReplaceA(0.5f) : Color.white);
	}

	private void FillDictionary()
	{
		if (mReportDictionary == null)
		{
			mReportDictionary = new Dictionary<string, UserReportType>();
		}
		if (mReportDictionary.Count > 0)
		{
			mReportDictionary.Clear();
		}
		mReportDictionary.Add("ID_REPORTUSER_ITEM0", UserReportType.InstantKill);
		mReportDictionary.Add("ID_REPORTUSER_ITEM1", UserReportType.SuspiciousBehaviourDuringMatch);
		mReportDictionary.Add("ID_REPORTUSER_ITEM2", UserReportType.Other);
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<EndScreen>.instance.enemy.panelEnemy.onePanelDisabled = true;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<EndScreen>.instance.enemy.panelEnemy.onePanelDisabled = false;
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
