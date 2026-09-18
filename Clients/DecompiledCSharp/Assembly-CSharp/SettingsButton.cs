using UnityEngine;

public class SettingsButton : Core_BaseScript
{
	[Header("Core")]
	public UILabel offLabel;

	public UILabel onLabel;

	public UISprite buttonBackground;

	public Vector3 onOffPosition = new Vector3(106f, 0f, 0f);

	private bool mOn;

	public bool on
	{
		get
		{
			return mOn;
		}
		set
		{
			mOn = value;
		}
	}

	internal void ButtonSetTo(bool onSetting, bool updateOnlyActiveObject = true)
	{
		if (base.gameObject.activeInHierarchy || !updateOnlyActiveObject)
		{
			on = onSetting;
			offLabel.color = ((!onSetting) ? Color.white : Colours.grayDark);
			onLabel.color = ((!onSetting) ? Colours.grayDark : Color.white);
			buttonBackground.transform.localPosition = ((!onSetting) ? (-onOffPosition) : onOffPosition);
			buttonBackground.alpha = ((!onSetting) ? 0.5f : 1f);
			buttonBackground.spriteName = ((!onSetting) ? "menu-army-upgradebar-gray" : "menu-army-upgradebar");
		}
	}
}
