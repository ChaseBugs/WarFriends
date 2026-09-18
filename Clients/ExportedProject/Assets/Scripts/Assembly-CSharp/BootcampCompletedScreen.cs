using System;
using System.Collections;
using Google2u;
using UnityEngine;

public class BootcampCompletedScreen : GuiElementSingle<BootcampCompletedScreen>, IGuiDialog
{
	[Header("Locked Warcards")]
	public BenefitsPart benefitsPart;

	[Header("Reward Text")]
	public UITable centerTable;

	public UILabel goldRewardForFree;

	public GameObject centerTableLastItem;

	[Header("Bottom Buttons")]
	public UIButton closeButton;

	public UIButton connectWithFBButton;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(connectWithFBButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnConnectClicked));
		UIEventListener uIEventListener2 = UIEventListener.Get(closeButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OnCloseClicked));
		centerTable.onReposition = delegate
		{
			float val = 0f - centerTable.padding.x - (centerTableLastItem.transform.localPosition.x - centerTable.padding.x) / 2f;
			centerTable.transform.localPosition = centerTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void OnCloseClicked(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("312 MENU CONNECT FB", clickedYes: false);
			HideDialog();
			GameLoginManager.instance.ShowGcChangeNameDialog();
			FacebookService.ClearTutorialEvent();
			if (!GuiScreenSingle<MainScreen>.instance.isShowed)
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<MainScreen>.instance);
			}
		}
	}

	private void OnConnectClicked(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		GuiElementSingle<FacebookDialog>.instance.ShowLoginDialog(delegate(bool result)
		{
			if (result)
			{
				Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("312 MENU CONNECT FB", clickedYes: true);
				GameLoginManager.instance.AfterTutorialLoginToFacebook();
				HideDialog();
			}
		});
	}

	public override void InitGUIValues()
	{
		benefitsPart.Initialize();
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLoginReward);
		centerTable.gameObject.SetActive(!flag);
		if (!flag)
		{
			goldRewardForFree.text = string.Format("{0} {1}", (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE, Localization.Localize("ID_GOLDFORFREERIGHTAWAY"));
			centerTable.repositionNow = true;
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		StartCoroutine(WaitForLoadingCompleted());
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		GuiElementSingle<ChatGuiElement>.instance.UpdateButtonLook();
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		OnCloseClicked(closeButton.gameObject);
	}

	private IEnumerator WaitForLoadingCompleted()
	{
		while (GuiElementSingle<LoadingDialog>.instance.isShowed)
		{
			yield return null;
		}
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampCongratulations);
	}
}
