using System;
using UnityEngine;

public class VIPOnlyDialog : GuiElementSingle<VIPOnlyDialog>, IGuiDialog
{
	[Header("Center")]
	public UILabel text;

	public UISprite camoSprite;

	public UISprite powerBandSprite;

	[Header("Bottom")]
	public UIButton buttonCancel;

	public UIButton buttonGet;

	public void ShowDialog(PlayerVisual visual)
	{
		Initialize(visual.name, visual.icon, visual.owner is PlayerVisualCategoryPowerBands);
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonCancel.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(buttonGet.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ButtonGetClick));
	}

	public override void InitGUIValues()
	{
	}

	private void Initialize(string visualName, string spriteName, bool isPowerBand)
	{
		camoSprite.gameObject.SetActive(!isPowerBand);
		powerBandSprite.gameObject.SetActive(isPowerBand);
		if (isPowerBand)
		{
			powerBandSprite.spriteName = spriteName;
			powerBandSprite.MakePixelPerfect();
			powerBandSprite.transform.localScale = powerBandSprite.transform.localScale.MultiplyXY(1.7f);
		}
		else
		{
			camoSprite.spriteName = spriteName;
			camoSprite.MakePixelPerfect();
			camoSprite.transform.localScale = camoSprite.transform.localScale.MultiplyXY(1.7f);
		}
		text.text = Localization.LocalizeFormat("ID_ACCESSORYISACCESSIBLEONLYTOVIP", visualName, Colours.stringWhite);
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void ButtonGetClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(buttonCancel.gameObject);
	}
}
