using System;
using UnityEngine;

public class JoinOrCreateSquadDialog : GuiElementSingle<JoinOrCreateSquadDialog>, IGuiDialog
{
	[Header("Top")]
	public UIButton closeButton;

	[Header("Middle")]
	public UITable getTable;

	public UILabel getLabel;

	public UILabel hintLabel;

	[Header("Bottom")]
	public UIButton createSquadButton;

	public UIButton joinSquadButton;

	public void ShowDialog()
	{
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(createSquadButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CreateSquadClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(joinSquadButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JoinSquadClick));
		getLabel.text = Localization.Localize("ID_GETSP");
		hintLabel.rescaleWidth = 870 - ((int)(getLabel.relativeSize.x * getLabel.transform.localScale.x) + 88);
		getTable.repositionNow = true;
		getTable.onReposition = delegate
		{
			if (getLabel.transform.localScale.x != hintLabel.transform.localScale.x)
			{
				getLabel.transform.localScale = hintLabel.transform.localScale;
				getTable.repositionNow = true;
			}
		};
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void CreateSquadClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadCreateScreen>.instance);
			HideDialog();
		}
	}

	private void JoinSquadClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadFindScreen>.instance);
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
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
