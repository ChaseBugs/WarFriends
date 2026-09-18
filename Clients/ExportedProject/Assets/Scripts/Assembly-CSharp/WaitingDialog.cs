using UnityEngine;

public class WaitingDialog : GuiElementSingle<WaitingDialog>, IGuiDialog
{
	[Header("Content")]
	public UILabel header;

	private bool mShouldHide;

	public static void ShowDialog(string headerTitle = "ID_JOININGSQUAD")
	{
		Debug.Log("Show Waiting Dialog " + headerTitle);
		GuiElementSingle<WaitingDialog>.instance.header.text = Localization.Localize(headerTitle);
		GuiElementSingle<WaitingDialog>.instance.mShouldHide = false;
		if (!GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<WaitingDialog>.instance, 0f);
		}
	}

	public static void Hide()
	{
		if (GuiElementSingle<WaitingDialog>.instance.isShowed)
		{
			if (GuiElementSingle<WaitingDialog>.instance.isFullyShowed)
			{
				GuiElementSingle<WaitingDialog>.instance.HideDialog();
			}
			else
			{
				GuiElementSingle<WaitingDialog>.instance.mShouldHide = true;
			}
			Debug.Log("Hide Waiting Dialog - will hide in a moment: " + GuiElementSingle<WaitingDialog>.instance.mShouldHide);
		}
	}

	public override void InitControls()
	{
	}

	public override void InitGUIValues()
	{
	}

	protected override void Update()
	{
		base.Update();
		if (base.isFullyShowed && mShouldHide)
		{
			HideDialog();
			mShouldHide = false;
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

	public override void OnBack()
	{
	}
}
