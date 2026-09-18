public class SettingsMainButton : Core_BaseScript
{
	public UISprite highlight;

	public UILabel nameLabel;

	internal void SetHighlight(bool setHighlight)
	{
		highlight.gameObject.SetActive(setHighlight);
		nameLabel.color = ((!setHighlight) ? Colours.grayButton : Colours.blue);
	}
}
