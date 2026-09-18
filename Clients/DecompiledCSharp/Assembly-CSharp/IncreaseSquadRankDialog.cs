using System;
using UnityEngine;

public class IncreaseSquadRankDialog : GuiElementSingle<IncreaseSquadRankDialog>, IGuiDialog
{
	[Header("Middle")]
	public UILabel currentSquadRank;

	public UILabel squadRankNeeded;

	[Header("Bottom")]
	public UIButton buttonRoger;

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnServerDataLoaded;
		UIEventListener uIEventListener = UIEventListener.Get(buttonRoger.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	private void OnServerDataLoaded(DatabaseAction action)
	{
		if (isShowed)
		{
			if (action == DatabaseAction.GetSquadDetails)
			{
				InitDialog();
			}
		}
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
		Singleton<BeanstalkServerManager>.instance.GetSquadDetails(GameLoginManager.currentPlayer.squadName);
	}

	private void InitDialog()
	{
		string squadName = GameLoginManager.currentPlayer.squadName;
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(squadName);
		if (squad != null)
		{
			currentSquadRank.text = Localization.LocalizeFormat("ID_CURRENTSQUADRANK", squad.rank);
			squadRankNeeded.text = Singleton<GameVariables>.instance.GetNextSquadRankIncreaseSize(squad.rank).ToString();
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.memberContent.draggablePanel.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.eventContent.draggablePanel.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.statsContent.draggablePanel.onePanelDisabled = true;
		GuiScreenSingle<SquadScreen>.instance.emblemContent.draggablePanel.onePanelDisabled = true;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.memberContent.draggablePanel.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.eventContent.draggablePanel.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.statsContent.draggablePanel.onePanelDisabled = false;
		GuiScreenSingle<SquadScreen>.instance.emblemContent.draggablePanel.onePanelDisabled = false;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(buttonRoger.gameObject);
	}
}
