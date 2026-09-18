using System;
using UnityEngine;

public class SystemMaintenanceDialog : GuiElementSingle<SystemMaintenanceDialog>, IGuiDialog
{
	[Header("Animation Background")]
	public UISprite glow;

	[Header("Dialog")]
	public UIPanel dialogPanel;

	public UILabel header;

	public UILabel description;

	public UIButton buttonRoger;

	private bool mHiding;

	public void ShowBannedFromChat(bool permanent, int time = 0)
	{
		header.text = Localization.Localize("ID_BANNEDFROMCHAT");
		MiscTools.SetUILabelRescale(header, 74f, 37f, 1000);
		description.text = Localization.LocalizeFormat("ID_WEHAVERECEIVEDCOMPLAINTSREGARDING", Localization.Localize((!permanent) ? "ID_TEMPORARY" : "ID_PERMANENT"));
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public void ShowSystemMaintenance(string date, string from)
	{
		header.text = Localization.Localize("ID_SYSTEMMAINTENANCE");
		MiscTools.SetUILabelRescale(header, 74f, 37f, 1000);
		description.text = Localization.LocalizeFormat("ID_SCHEDULEDMAINTENANCEOFSERVER", Colours.stringRed, date, Colours.stringWhite, from);
		Singleton<GuiManager>.instance.ShowDialog(this, 0f);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(buttonRoger.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(RogerClick));
	}

	public override void InitGUIValues()
	{
		mHiding = false;
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		AnimateShowMaintenanceDialog(0.7f);
	}

	private void RogerClick(GameObject go)
	{
		if (!mHiding)
		{
			mHiding = true;
			AnimateHideMaintenanceDialog(0.5f);
		}
	}

	private void AnimateShowMaintenanceDialog(float time)
	{
		base.gameObject.SetActive(value: true);
		float dur = time / 15f;
		float zzz = base.transform.localPosition.z;
		TweenAlpha.Begin(dialogPanel.gameObject, time, 0.005f, 1f);
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, dur * 6f, new Vector3(0f, -4f * mDistance, zzz), new Vector3(0f, -4f * mDistance, zzz));
		tweenPosition.onFinished = delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, dur * 5f, new Vector3(0f, mDistance, zzz));
			tweenPosition2.method = UITweener.Method.Linear;
			tweenPosition2.onFinished = delegate
			{
				TweenPosition tweenPosition3 = TweenPosition.Begin(base.gameObject, dur * 4f, new Vector3(0f, 0f, zzz));
				tweenPosition3.method = UITweener.Method.EaseOut;
			};
		};
		TweenAlpha.Begin(base.gameObject, dur, 0.005f, 1f).onFinished = null;
		Vector3 UpScale = new Vector3(3425f, 1356f, 1f);
		Vector3 EndScale = new Vector3(2740f, 1017f, 1f);
		TweenAlpha.Begin(overlayBackground.gameObject, dur * 6f, 0f, 0.84f);
		TweenScale tweenScale = TweenScale.Begin(glow.gameObject, dur * 11f, Vector3.one, Vector3.one);
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(glow.gameObject, dur * 2f, Vector3.one, UpScale);
			tweenScale2.method = UITweener.Method.Linear;
			tweenScale2.onFinished = delegate
			{
				TweenScale tweenScale3 = TweenScale.Begin(glow.gameObject, dur * 2f, EndScale);
				tweenScale3.method = UITweener.Method.EaseOut;
			};
		};
		TweenAlpha.Begin(glow.gameObject, dur * 9f, 0f, 0f).onFinished = delegate
		{
			TweenAlpha.Begin(glow.gameObject, dur * 2f, 1f);
		};
	}

	private void AnimateHideMaintenanceDialog(float time)
	{
		TweenAlpha.Begin(dialogPanel.gameObject, time, 0.005f);
		TweenAlpha.Begin(overlayBackground.gameObject, time, 0f);
		TweenScale.Begin(glow.gameObject, time, Vector3.one).onFinished = null;
		TweenAlpha.Begin(glow.gameObject, time, 0f);
		TweenAlpha.Begin(base.gameObject, time, 0.005f).onFinished = delegate
		{
			HideDialog();
			mHiding = false;
		};
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		RogerClick(buttonRoger.gameObject);
	}
}
