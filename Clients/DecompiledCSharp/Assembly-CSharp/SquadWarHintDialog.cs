using System;
using System.Collections.Generic;
using Google2u;
using UnityEngine;

public class SquadWarHintDialog : GuiElementSingle<SquadWarHintDialog>, IGuiDialog
{
	[Header("Left Top")]
	public UIButton backButton;

	public UITable leftTable;

	public UILabel hintText;

	[Header("Right Top")]
	public UIButton closeButton;

	[Header("Bottom")]
	public UIGrid bottomGrid;

	public List<DivisionRepresentation> divisionElements;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(backButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		float num = (UIRoot.list[0].activeWidth - 120f - 1632f) / 7f;
		float num2 = 204f + num;
		bottomGrid.cellWidth = num2;
		bottomGrid.transform.localPosition = new Vector3(-3.5f * num2, bottomGrid.transform.localPosition.y, bottomGrid.transform.localPosition.z);
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
		hintText.text = Localization.LocalizeFormat("ID_IFNUMBEROSQUADSINASQUADWAR", (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SquadWarsLowerSquadLimit).FLOATVALUE);
		leftTable.repositionNow = true;
		for (int i = 0; i < 8; i++)
		{
			divisionElements[i].Initialization(i);
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

	public GuiElement GetGuiElement()
	{
		return this;
	}
}
