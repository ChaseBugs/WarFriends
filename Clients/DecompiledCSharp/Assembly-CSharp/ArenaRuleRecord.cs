using System;
using UnityEngine;

public class ArenaRuleRecord : PoolableObject
{
	[Header("Core")]
	public GameObject center;

	public BoxCollider ruleCollider;

	public UILabel description;

	public UISprite stateIcon;

	[Header("Resize")]
	public UISprite background;

	public GameObject leftAnchor;

	public GameObject rightAnchor;

	private WarArenaRule.WarArenaRuleGui mRuleData;

	public void Initialize(WarArenaRule.WarArenaRuleGui ruleData, bool showStateIcon = true, int width = 560, int height = 80)
	{
		mRuleData = ruleData;
		bool flag = ruleData.type == WarArenaRule.RuleType.InfoRule || ruleData.type == WarArenaRule.RuleType.InfoText;
		bool flag2 = showStateIcon && !flag;
		description.text = ruleData.text;
		float y = description.relativeSize.y;
		if (y > 1.1f)
		{
			MiscTools.SetUILabelRescale(description, 32f, 32f, 1000);
			int num = height - 32 + Mathf.CeilToInt(32f * y);
			SetSize(width, num);
			center.transform.localPosition = center.transform.localPosition.ReplaceY((float)(-num) / 2f);
		}
		else
		{
			SetSize(width, height);
			center.transform.localPosition = center.transform.localPosition.ReplaceY((float)(-height) / 2f);
			MiscTools.SetUILabelRescale(description, 32f, 20f, width - 40 - (flag2 ? 65 : 0));
		}
		stateIcon.gameObject.SetActive(flag2);
		background.color = Colours.greenArena.ReplaceA((!flag) ? 0.2f : 0.05f);
		ruleCollider.enabled = showStateIcon && ruleData.type == WarArenaRule.RuleType.DoesNotMeet;
		UIEventListener uIEventListener = UIEventListener.Get(ruleCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(RuleClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(ruleCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(RuleClick));
		if (flag2)
		{
			if (ruleData.type == WarArenaRule.RuleType.FulFill)
			{
				stateIcon.spriteName = "menu-dailyreward-check";
				stateIcon.transform.localScale = new Vector3(37f, 29f, 1f);
				stateIcon.color = Colours.greenArena;
			}
			else
			{
				stateIcon.spriteName = "menu-close";
				stateIcon.transform.localScale = new Vector3(28f, 28f, 1f);
				stateIcon.color = Colours.redArenaRule;
			}
		}
	}

	private void SetSize(int width, int height)
	{
		background.transform.localScale = new Vector3(width, height, 1f);
		leftAnchor.transform.localPosition = leftAnchor.transform.localPosition.ReplaceX(-width / 2);
		rightAnchor.transform.localPosition = rightAnchor.transform.localPosition.ReplaceX(width / 2);
		ruleCollider.size = background.transform.localScale;
	}

	private void RuleClick(GameObject go)
	{
		if (mRuleData != null && mRuleData.type == WarArenaRule.RuleType.DoesNotMeet)
		{
			GuiElementSingle<CantEnterArenaDialog>.instance.ShowDialog(mRuleData);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(ruleCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(RuleClick));
	}
}
