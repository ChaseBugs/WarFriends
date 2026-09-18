using System;
using UnityEngine;

public class JoiningSquadDialog : GuiElementSingle<JoiningSquadDialog>, IGuiDialog
{
	[Header("Top")]
	public UIButton closeButton;

	[Header("Middle")]
	public UILabel squadNameLabel;

	[Header("Bottom")]
	public UIButton sendRequestButton;

	public BoxCollider buttonCollider;

	[Header("-Request send")]
	public GameObject sentHolder;

	public UIButton okButton;

	[Header("-Waiting")]
	public GameObject waiting;

	[HideInInspector]
	public bool requestSend;

	private string mSquadName;

	public void ShowDialog(string squadName)
	{
		Initialize(squadName);
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(okButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CloseDialog));
		UIEventListener uIEventListener2 = UIEventListener.Get(sendRequestButton.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(SendRequestClick));
		UIEventListener uIEventListener3 = UIEventListener.Get(closeButton.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CloseDialog));
	}

	private void SendRequestClick(GameObject go)
	{
		buttonCollider.enabled = false;
		Singleton<BeanstalkServerManager>.instance.JoinSquadRequest(mSquadName);
		TweenAlpha.Begin(sendRequestButton.gameObject, 0.25f, 0f).onFinished = delegate
		{
			sendRequestButton.gameObject.SetActive(value: false);
			buttonCollider.enabled = true;
			waiting.SetActive(value: true);
		};
	}

	private void CloseDialog(GameObject go)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		buttonCollider.enabled = true;
	}

	protected override void Update()
	{
		base.Update();
		if (!sendRequestButton.gameObject.activeSelf && requestSend && !sentHolder.gameObject.activeSelf)
		{
			waiting.SetActive(value: false);
			sentHolder.gameObject.SetActive(value: true);
			TweenAlpha.Begin(sentHolder.gameObject, 0.25f, 1f);
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	private void Initialize(string squadName)
	{
		requestSend = false;
		mSquadName = squadName;
		sendRequestButton.gameObject.SetActive(value: true);
		sentHolder.SetActive(value: false);
		waiting.SetActive(value: false);
		squadNameLabel.text = Localization.LocalizeFormat("ID_TOJOINSQUADYOUMUSTBEACCEPTED", Colours.stringBlue, mSquadName, Colours.stringWhite);
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
