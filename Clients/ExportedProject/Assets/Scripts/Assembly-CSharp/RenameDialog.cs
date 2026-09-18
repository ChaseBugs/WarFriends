using System;
using UnityEngine;

public class RenameDialog : GuiElementSingle<RenameDialog>, IGuiDialog
{
	[Header("Core")]
	public UIInput nickInput;

	public UILabel errorLabel;

	public UIButton closeButton;

	[Header("Rename Button")]
	public UIButton renameButton;

	public UILabel renameLabel;

	public GameObject renamePriceBox;

	public UITable renameTable;

	public UILabel renameGoldPrice;

	public override void InitEvents()
	{
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(closeButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(renameButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CreateButtonClick));
		GameLoginManager.instance.DeviceRegistered += InstanceOnDeviceRegistered;
		nickInput.maxChars = DatabasePlayer.maxPlayerName;
		renameTable.onReposition = delegate
		{
			float val = 0f - renameTable.padding.x - (renameGoldPrice.transform.parent.transform.localPosition.x - renameTable.padding.x) / 2f;
			renameTable.transform.localPosition = renameTable.transform.localPosition.ReplaceX(val);
		};
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void CreateButtonClick(GameObject go)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		errorLabel.gameObject.SetActive(value: false);
		if (string.IsNullOrEmpty(nickInput.text))
		{
			errorLabel.gameObject.SetActive(value: true);
			errorLabel.text = Localization.Localize("ID_ERRORNONICK");
			return;
		}
		if (nickInput.text.Length < 4)
		{
			errorLabel.gameObject.SetActive(value: true);
			errorLabel.text = Localization.Localize("ID_ERRORSHORTNICK");
			return;
		}
		if (Singleton<Chat>.instance.ContainsBadWord(nickInput.text))
		{
			errorLabel.gameObject.SetActive(value: true);
			errorLabel.text = Localization.Localize("ID_ERRORPROFANITYNICK");
			return;
		}
		if (GameLoginManager.instance.data.isDeviceRegistered)
		{
			Debug.Log("Rename Cost Gold = " + PlayerAnalytics.instance.renameGoldPrice);
			if (!Singleton<Wallet>.instance.CanBuyGold(PlayerAnalytics.instance.renameGoldPrice))
			{
				HideDialog();
				GuiElementSingle<SettingsDialog>.instance.HideDialog();
				GuiElementSingle<NotEnoughDialog>.instance.ShowGold(PlayerAnalytics.instance.renameGoldPrice, Localization.Localize("ID_CHANGENAMENOTENOUGHT"));
				return;
			}
			Singleton<BeanstalkServerManager>.instance.ChangePlayerName(nickInput.text, payForRename: true);
		}
		HideDialog();
	}

	private void InstanceOnDeviceRegistered()
	{
		HideDialog();
	}

	public override void InitGUIValues()
	{
		errorLabel.gameObject.SetActive(value: false);
		nickInput.text = GameLoginManager.currentPlayer.name;
		int num = PlayerAnalytics.instance.renameGoldPrice;
		renameLabel.transform.localPosition = renameLabel.transform.localPosition.ReplaceX((num <= 0) ? 0f : (-120f));
		renamePriceBox.SetActive(num > 0);
		if (num > 0)
		{
			renameGoldPrice.text = MiscTools.FormatBigNumber(num);
			renameTable.repositionNow = true;
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		string text = nickInput.text;
		nickInput.selected = true;
		nickInput.mKeyboard = TouchScreenKeyboard.Open(nickInput.text, TouchScreenKeyboardType.Default, autocorrection: false, multiline: false, secure: false);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		CloseDialog(closeButton.gameObject);
	}
}
