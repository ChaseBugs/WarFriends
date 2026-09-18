using System;
using UnityEngine;

public class ConfirmDialog : GuiElementSingle<ConfirmDialog>, IGuiDialog
{
	[Header("Labels")]
	public UILabel dialogTitle;

	public UILabel dialogText;

	[Header("Buttons")]
	public UIButton okButton;

	public UILabel okLabel;

	public UIButton yesButton;

	public UILabel yesLabel;

	public UIButton cancelButton;

	public UILabel cancelLabel;

	public Action<ConfirmDialog, bool> dialogResult;

	private int mInstances;

	public string setTitle
	{
		set
		{
			dialogTitle.text = value;
			MiscTools.SetUILabelRescale(dialogTitle, 99f, 44f, 1500);
		}
	}

	public string setText
	{
		set
		{
			dialogText.text = value;
		}
	}

	public string yesButtonText
	{
		get
		{
			return yesLabel.text;
		}
		set
		{
			yesLabel.text = value;
		}
	}

	public string cancelButtonText
	{
		get
		{
			return cancelLabel.text;
		}
		set
		{
			cancelLabel.text = value;
		}
	}

	public string okButtonText
	{
		get
		{
			return okLabel.text;
		}
		set
		{
			okLabel.text = value;
		}
	}

	public event Action<ConfirmDialog, bool> dialogShowed;

	protected override void Awake()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(yesButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(TrueClick));
		UIEventListener uIEventListener2 = UIEventListener.Get(cancelButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FalseClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(okButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(TrueClick));
	}

	public override void InitControls()
	{
		Singleton<GameController>.instance.GameEnded += OnGameEnded;
	}

	public override void InitGUIValues()
	{
	}

	private void OnGameEnded(GameController.GameEndReason endReason)
	{
		if (isShowed)
		{
			Hide();
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if (this.dialogShowed != null)
		{
			this.dialogShowed(this, arg2: true);
		}
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		Reset();
		if (this.dialogShowed != null)
		{
			this.dialogShowed(this, arg2: false);
		}
	}

	private void Reset()
	{
		yesButtonText = Localization.Localize("ID_YES");
		cancelButtonText = Localization.Localize("ID_NO");
		dialogText.gameObject.SetActive(value: true);
		yesButton.gameObject.SetActive(value: true);
		cancelButton.gameObject.SetActive(value: true);
		okButton.gameObject.SetActive(value: false);
		fadeInTime = 0.5f;
		fadeOutTime = 0.5f;
		UIEventListener.Get(overlayBackground.gameObject).onClick = null;
	}

	private void TrueClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			mInstances = 0;
			if (dialogResult != null)
			{
				dialogResult(this, arg2: true);
				dialogResult = null;
			}
		}
	}

	private void FalseClick(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			mInstances = 0;
			if (dialogResult != null)
			{
				dialogResult(this, arg2: false);
				dialogResult = null;
			}
		}
	}

	private void BackgroundClose()
	{
		UIEventListener uIEventListener = UIEventListener.Get(overlayBackground.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate(GameObject go)
		{
			if (base.isFullyShowed)
			{
				TrueClick(go);
			}
		});
	}

	public static void Hide()
	{
		Debug.Log("Hiding CONFIRM dialog");
		if (GuiElementSingle<ConfirmDialog>.instance.isShowed)
		{
			GuiElementSingle<ConfirmDialog>.instance.HideDialog();
		}
		GuiElementSingle<ConfirmDialog>.instance.dialogResult = null;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		if (cancelButton.gameObject.activeSelf)
		{
			FalseClick(cancelButton.gameObject);
		}
		else if (okButton.gameObject.activeSelf)
		{
			TrueClick(okButton.gameObject);
		}
		else if (yesButton.gameObject.activeSelf)
		{
			TrueClick(yesButton.gameObject);
		}
	}

	public static void ShowAlert(Action<ConfirmDialog, bool> resultHandler, string title, string text)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.Reset();
		confirmDialog.setTitle = title;
		confirmDialog.setText = text;
		confirmDialog.dialogResult = null;
		confirmDialog.fadeInTime = 0.2f;
		confirmDialog.fadeOutTime = 0.2f;
		confirmDialog.dialogText.gameObject.SetActive(value: true);
		confirmDialog.yesButton.gameObject.SetActive(value: false);
		confirmDialog.cancelButton.gameObject.SetActive(value: false);
		confirmDialog.okButton.gameObject.SetActive(value: true);
		confirmDialog.okButtonText = Localization.Localize("ID_OK");
		confirmDialog.BackgroundClose();
		if (resultHandler != null)
		{
			confirmDialog.dialogResult = resultHandler;
		}
		confirmDialog.mInstances++;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 0f);
	}

	public static ConfirmDialog ShowAlert(string title, string text, float delay = 0f)
	{
		ConfirmDialog dialog = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(delegate
		{
			dialog.Reset();
			dialog.setTitle = title;
			dialog.setText = text;
			dialog.dialogResult = null;
			dialog.fadeInTime = 0.2f;
			dialog.fadeOutTime = 0.2f;
			dialog.dialogText.gameObject.SetActive(value: true);
			dialog.yesButton.gameObject.SetActive(value: false);
			dialog.cancelButton.gameObject.SetActive(value: false);
			dialog.okButton.gameObject.SetActive(value: true);
			dialog.mInstances++;
			dialog.okButtonText = Localization.Localize("ID_OK");
			dialog.BackgroundClose();
			Singleton<GuiManager>.instance.ShowDialog(dialog, 0f);
		}, delay);
		return dialog;
	}

	public static ConfirmDialog ShowConfirm(string title, string text, Action<ConfirmDialog, bool> resultHandler, float delay = 0f)
	{
		ConfirmDialog dialog = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(delegate
		{
			dialog.Reset();
			dialog.setTitle = title;
			dialog.setText = text;
			dialog.fadeInTime = 0.2f;
			dialog.fadeOutTime = 0.2f;
			dialog.dialogText.gameObject.SetActive(value: true);
			dialog.yesButton.gameObject.SetActive(value: true);
			dialog.cancelButton.gameObject.SetActive(value: true);
			dialog.okButton.gameObject.SetActive(value: false);
			dialog.dialogResult = resultHandler;
			dialog.mInstances++;
			Singleton<GuiManager>.instance.ShowDialog(dialog, 0f);
		}, delay);
		return dialog;
	}

	internal static ConfirmDialog ShowChoice(string title, string text, Action<ConfirmDialog, bool> resultHandler, string firstChoiceButton, string secondChoiceButton)
	{
		ConfirmDialog dialog = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(delegate
		{
			dialog.Reset();
			dialog.setTitle = title;
			dialog.setText = text;
			dialog.fadeInTime = 0.2f;
			dialog.fadeOutTime = 0.2f;
			dialog.dialogText.gameObject.SetActive(value: true);
			dialog.yesButton.gameObject.SetActive(value: true);
			dialog.cancelButton.gameObject.SetActive(value: true);
			dialog.okButton.gameObject.SetActive(value: false);
			dialog.dialogResult = resultHandler;
			dialog.yesButtonText = firstChoiceButton;
			dialog.cancelButtonText = secondChoiceButton;
			dialog.mInstances++;
			Singleton<GuiManager>.instance.ShowDialog(dialog, 0f);
		}, 0f);
		return dialog;
	}
}
