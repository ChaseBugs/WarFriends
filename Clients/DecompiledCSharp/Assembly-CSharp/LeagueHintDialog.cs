using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class LeagueHintDialog : GuiElementSingle<LeagueHintDialog>, IGuiDialog
{
	[Header("Left Top")]
	public UIButton backButton;

	public UITable leftTable;

	public UILabel firstLineStartLabel;

	public UILabel firstLineEndLabel;

	public UILabel nextLinesLabel;

	[Header("Right Top")]
	public UIButton closeButton;

	[Header("Bottom")]
	public UIGrid bottomGrid;

	public List<LeagueRepresentation> leagueElements;

	private float mMaxHeight;

	private int mDebugI;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(backButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		mMaxHeight = (float)UIRoot.list[0].activeHeight - 510f;
		float num = (UIRoot.list[0].activeWidth - 120f - 1656f) / 5f;
		float num2 = 276f + num;
		bottomGrid.cellWidth = num2;
		bottomGrid.transform.localPosition = bottomGrid.transform.localPosition.ReplaceX(-2.5f * num2);
		bottomGrid.repositionNow = true;
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		if (GameLoginManager.currentPlayer.isInBeginnersLeague)
		{
			firstLineStartLabel.text = Localization.Localize("ID_EARN");
			firstLineEndLabel.text = Localization.Localize("ID_MEDALSANDADVANCETHROUGHROOKIE");
			leftTable.repositionNow = true;
			nextLinesLabel.text = Localization.Localize("ID_TOGETTOTHECOMPETITIVE");
		}
		else
		{
			firstLineStartLabel.text = Localization.Localize("ID_EARNMORE");
			firstLineEndLabel.text = Localization.Localize("ID_MEDALSTOADVANCETOBETTERLEAGUES");
			leftTable.repositionNow = true;
			League leagueTier = GameLoginManager.currentPlayer.leagueTier;
			float num = Singleton<GameVariables>.instance.LeagueGoDownPercent(leagueTier);
			float num2 = Singleton<GameVariables>.instance.LeagueGoUpPercent(leagueTier);
			bool flag = num > 0f;
			bool flag2 = num2 > 0f;
			nextLinesLabel.text = Localization.LocalizeFormat("ID_IFNUMBEROFPLAYERS", (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotEnoughPlayersForPlayerLeague).FLOATVALUE);
			if (flag2)
			{
				UILabel uILabel = nextLinesLabel;
				uILabel.text = uILabel.text + "\n" + Localization.LocalizeFormat("ID_XOFPLAYERSGETSPROMOTED", MiscTools.FormatFloatNumberAsPercent(num2));
			}
			if (flag)
			{
				UILabel uILabel2 = nextLinesLabel;
				uILabel2.text = uILabel2.text + "\n" + Localization.LocalizeFormat("ID_XOFPLAYERSGETSRELEGATED", MiscTools.FormatFloatNumberAsPercent(num));
			}
		}
		int num3 = 1;
		foreach (LeagueRepresentation leagueElement in leagueElements)
		{
			leagueElement.Initialization((League)Mathf.Clamp(num3, 0, 16), mMaxHeight);
			num3 += 3;
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		foreach (LeagueRepresentation leagueElement in leagueElements)
		{
			leagueElement.leagueIcon.mainTexture = null;
		}
	}

	public void TestNextLeague()
	{
		mDebugI++;
		if (mDebugI > 16)
		{
			mDebugI = 0;
		}
		if (leagueElements.Count > 0)
		{
			leagueElements[0].Initialization((League)mDebugI, mMaxHeight);
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton.gameObject);
	}
}
