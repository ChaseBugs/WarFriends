using UnityEngine;

internal class EnablePushNotificationMessage : DatabaseMessage
{
	public EnablePushNotificationMessage()
		: base($"PushNotificationDialog {Singleton<BeanstalkServerManager>.instance.currentTimestamp}", Type.EnablePushNotificationMessage)
	{
		Debug.Log("About to show Enable Push Notification Dialog");
	}

	public override void Show()
	{
		base.Show();
		Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EnableNotificationsDialog>.instance, 0f);
	}
}
