using System;
using UnityEngine;

public class NotEnoughMedalsDialog : GuiElementSingle<NotEnoughMedalsDialog>, IGuiDialog
{
	[Header("Content")]
	public UILabel description;

	public UILabel medalsCountLabel;

	[Header("Bottom")]
	public UIButton buttonGet;

	public void ShowDialog(string squadName, int requiredMedalsCount, int playerMedalsCount, UIDraggablePanel draggablePanel = null)
	{
		description.text = Localization.LocalizeFormat("ID_TOJOINSQUADYOUNEEDTOHAVE", Colours.stringBlue, squadName, Colours.stringWhite, MiscTools.FormatBigNumber(requiredMedalsCount));
		medalsCountLabel.text = $"{MiscTools.FormatBigNumber(playerMedalsCount)} {Colours.stringGrayLight}/ {Colours.stringBlue}{MiscTools.FormatBigNumber(requiredMedalsCount)}";
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonGet.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
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

	public override void OnBack()
	{
		CloseDialog(buttonGet.gameObject);
	}
}
