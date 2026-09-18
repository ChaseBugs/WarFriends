public class SettingsNotificationButton : Core_BaseScript
{
	public UISprite checkbox;

	public UILabel notificationLabel;

	internal void SetHighlight(bool setHighlight)
	{
		checkbox.gameObject.SetActive(setHighlight);
	}
}
