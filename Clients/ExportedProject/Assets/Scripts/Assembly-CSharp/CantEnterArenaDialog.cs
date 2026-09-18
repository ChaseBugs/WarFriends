using System;
using System.Collections.Generic;
using UnityEngine;

public class CantEnterArenaDialog : GuiElementSingle<CantEnterArenaDialog>, IGuiDialog
{
	[Header("Core")]
	public GameObject topOfDialog;

	public GameObject closeButton;

	public UISprite background;

	public CantEnterRuleRecord[] ruleRecords;

	public GameObject bottomPart;

	public GameObject bottomButton;

	private List<WarArenaRule.WarArenaRuleGui> mFailSetupRules;

	public void ShowDialog(List<WarArenaRule.WarArenaRuleGui> failRules)
	{
		mFailSetupRules = failRules;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowDialog(WarArenaRule.WarArenaRuleGui failRule)
	{
		mFailSetupRules = new List<WarArenaRule.WarArenaRuleGui> { failRule };
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(bottomButton);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseClick));
	}

	private void CloseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		int num = ((mFailSetupRules != null) ? mFailSetupRules.Count : 0);
		float num2 = 208f + (float)num * 230f;
		float num3 = num2 + 224f;
		float val = num3 / 2f;
		topOfDialog.transform.localPosition = topOfDialog.transform.localPosition.ReplaceY(val);
		background.transform.localScale = background.transform.localScale.ReplaceY(num3);
		bottomPart.transform.localPosition = bottomPart.transform.localPosition.ReplaceY(0f - num2);
		for (int i = 0; i < ruleRecords.Length; i++)
		{
			bool flag = mFailSetupRules != null && i < mFailSetupRules.Count;
			ruleRecords[i].gameObject.SetActive(flag);
			if (flag)
			{
				ruleRecords[i].Initialize(mFailSetupRules[i]);
			}
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseClick(bottomButton);
	}
}
