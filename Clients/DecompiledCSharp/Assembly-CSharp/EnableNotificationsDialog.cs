using System;
using Google2u;
using UnityEngine;

public class EnableNotificationsDialog : GuiElementSingle<EnableNotificationsDialog>, IGuiDialog
{
	[Header("Table")]
	public UITable notificationsTable;

	[Header("Buttons")]
	public UIButton buttonCancel;

	public UIButton buttonEnable;

	public UILabel enableLabel;

	public UITable goldRewardTable;

	public UILabel goldRewardNumber;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonCancel.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnCancelClicked));
		UIEventListener uIEventListener2 = UIEventListener.Get(buttonEnable.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OnEnableClicked));
		goldRewardTable.onReposition = delegate
		{
			float val = 0f - goldRewardTable.padding.x - (goldRewardNumber.transform.parent.transform.localPosition.x - goldRewardTable.padding.x) / 2f;
			goldRewardTable.transform.localPosition = goldRewardTable.transform.localPosition.ReplaceX(val);
		};
	}

	public override void InitGUIValues()
	{
		notificationsTable.repositionNow = true;
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.NotificationAllowReward);
		int num = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.NotificationAllowReward).FLOATVALUE;
		bool flag2 = !flag && num > 0;
		enableLabel.gameObject.SetActive(!flag2);
		goldRewardTable.gameObject.SetActive(flag2);
		if (flag2)
		{
			goldRewardNumber.text = MiscTools.FormatBigNumber(num);
			goldRewardTable.repositionNow = true;
		}
	}

	private void OnCancelClicked(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("313 MENU ENABLE PUSH", clickedYes: false);
			HideDialog();
		}
	}

	private void OnEnableClicked(GameObject go)
	{
		if (base.isFullyShowed)
		{
			Singleton<EventTrackingManager>.instance.RegisterTutorialDialogEvent("313 MENU ENABLE PUSH", clickedYes: false);
			Debug.Log("Going to enable notifications");
			PushNotificationManager.instance.EnablePushNotifications(string.Empty);
			DialogManager.instance.PushNotificationWasEnabled();
			HideDialog();
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		if (GuiElementSingle<SettingsDialog>.instance.isShowed)
		{
			GuiElementSingle<SettingsDialog>.instance.InitGUIValues();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		OnCancelClicked(buttonCancel.gameObject);
	}
}
