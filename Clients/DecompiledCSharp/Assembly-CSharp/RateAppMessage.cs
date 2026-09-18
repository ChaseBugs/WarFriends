using System;
using UnityEngine;

internal class RateAppMessage : DatabaseMessage
{
	public bool afterUpdate;

	public int currentCount;

	public RateAppMessage(string version, int count, bool updated)
		: base($"RateAppMessage {version} {count}", Type.EnablePushNotificationMessage)
	{
		afterUpdate = updated;
		currentCount = count;
		Debug.Log($"About to show Enable RateApp Dialog for version: {version} shownTime: {count}");
	}

	public override void Show()
	{
		base.Show();
		GuiElementSingle<RateAppDialog>.instance.ShowDialog(afterUpdate, currentCount);
	}

	internal override Action InitMessageCenterRecord(MessageCenterRecord record)
	{
		record.SetAppearance_GenericGetFreeGoldWithSocial(messageType, messageTime, 0);
		return delegate
		{
			GuiElementSingle<RateAppDialog>.instance.ShowDialog(afterUpdate, currentCount);
		};
	}
}
