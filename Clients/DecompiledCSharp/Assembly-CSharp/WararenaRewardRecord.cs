using System;
using UnityEngine;

public class WararenaRewardRecord : PoolableObject
{
	public enum ClickBehaviour
	{
		OpenDialog,
		ChangeUnit
	}

	[Header("Core")]
	public UISprite icon;

	public UILabel rewardText;

	public UISprite visualIcon;

	public GameObject unitPart;

	public GameObject doubleDropPart;

	public UISprite unitIcon;

	public BoxCollider previewUnit;

	private LevelBehaviour mUnit;

	private ClickBehaviour mClickBehaviour;

	public void Initialize(WarArenaReward reward, ClickBehaviour clickBehaviour)
	{
		WarArenaRewardUnit warArenaRewardUnit = reward as WarArenaRewardUnit;
		WarArenaRewardCrown warArenaRewardCrown = reward as WarArenaRewardCrown;
		bool flag = warArenaRewardUnit != null;
		bool flag2 = warArenaRewardCrown != null;
		rewardText.text = reward.text;
		rewardText.transform.localPosition = rewardText.transform.localPosition.ReplaceY((!flag) ? (-73f) : (-53f));
		icon.gameObject.SetActive(!flag2 && !flag);
		visualIcon.gameObject.SetActive(flag2);
		unitPart.SetActive(flag);
		if (flag2)
		{
			visualIcon.spriteName = warArenaRewardCrown.spriteName;
			visualIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(142f / visualIcon.transform.localScale.x, 126f / visualIcon.transform.localScale.x);
			visualIcon.transform.localScale = visualIcon.transform.localScale.MultiplyXY(multiplier);
		}
		else if (flag)
		{
			mUnit = warArenaRewardUnit.behaviour;
			mClickBehaviour = clickBehaviour;
			doubleDropPart.SetActive(warArenaRewardUnit.doubleDrop);
			unitIcon.spriteName = warArenaRewardUnit.spriteName;
			unitIcon.MakePixelPerfect();
			if (mUnit.isSoldier)
			{
				unitIcon.pivot = UIWidget.Pivot.Bottom;
				unitIcon.transform.localPosition = unitIcon.transform.localPosition.ReplaceY(-65f);
				float multiplier2 = 144f / unitIcon.transform.localScale.y;
				unitIcon.transform.localScale = unitIcon.transform.localScale.MultiplyXY(multiplier2);
			}
			else
			{
				unitIcon.pivot = UIWidget.Pivot.Center;
				unitIcon.transform.localPosition = unitIcon.transform.localPosition.ReplaceY(0f);
				float multiplier3 = Mathf.Min(176f / unitIcon.transform.localScale.x, 144f / unitIcon.transform.localScale.y);
				unitIcon.transform.localScale = unitIcon.transform.localScale.MultiplyXY(multiplier3);
			}
			UIEventListener uIEventListener = UIEventListener.Get(previewUnit.gameObject);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PreviewClick));
			UIEventListener uIEventListener2 = UIEventListener.Get(previewUnit.gameObject);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PreviewClick));
		}
		else
		{
			icon.spriteName = reward.spriteName;
			icon.MakePixelPerfect();
			icon.transform.localScale = icon.transform.localScale.MultiplyXY(reward.scaleMultiplier);
			icon.transform.localRotation = reward.iconRotation;
		}
	}

	private void PreviewClick(GameObject go)
	{
		if (mClickBehaviour == ClickBehaviour.OpenDialog)
		{
			GuiElementSingle<EliteUnitPreviewDialog>.instance.ShowDialog(mUnit);
		}
		else
		{
			GuiElementSingle<ArenaOpenedDialog>.instance.ChangeUnit(mUnit);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(previewUnit.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PreviewClick));
	}
}
