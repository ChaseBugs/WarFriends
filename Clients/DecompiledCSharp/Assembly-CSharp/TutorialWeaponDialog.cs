using System;
using UnityEngine;

public class TutorialWeaponDialog : GuiElementSingle<TutorialWeaponDialog>, IGuiDialog
{
	[Header("Content")]
	public UILabel headerTitle;

	public UISprite weaponIcon;

	public UILabel mainText;

	public UIButton bottomButton;

	private WeaponLevelsSetup mWeapon;

	public void ShowDialog(WeaponLevelsSetup weapon)
	{
		mWeapon = weapon;
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(bottomButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ButtonClick));
	}

	private void ButtonClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		if (!(mWeapon == null))
		{
			headerTitle.text = Localization.Localize((mWeapon.weaponCategory != WeaponCategory.Minigun) ? "ID_ROCKETLAUNCHERHINT" : "ID_MINIGUNHINT");
			weaponIcon.spriteName = mWeapon.playerWeapon.iconName;
			weaponIcon.MakePixelPerfect();
			float multiplier = Mathf.Min(320f / weaponIcon.transform.localScale.x, 240f / weaponIcon.transform.localScale.y);
			weaponIcon.transform.localScale = weaponIcon.transform.localScale.MultiplyXY(multiplier);
			mainText.text = ((mWeapon.weaponCategory != WeaponCategory.Minigun) ? Localization.Localize("ID_ROCKETLAUNCHERTUTORIALTEXT") : Localization.Localize("ID_MINIGUNTUTORIALTEXT"));
		}
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		mWeapon = null;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		ButtonClick(bottomButton.gameObject);
	}
}
