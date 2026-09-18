using System;
using UnityEngine;

public class StarterAssignmentRewardDialog : GuiElementSingle<StarterAssignmentRewardDialog>, IGuiDialog
{
	[Header("Bottom")]
	public GameObject okButton;

	[Header("Animation")]
	public CardMenuOwerlay cardsAnimation;

	private Card[] mCards;

	public void ShowDialog(Card[] cards)
	{
		mCards = cards;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(okButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OkClick));
	}

	public override void InitGUIValues()
	{
		cardsAnimation.ResetDraw();
	}

	private void OkClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		cardsAnimation.StartShowAnimation(mCards, 0.2f);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		OkClick(okButton);
	}
}
