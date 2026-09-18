using System;
using UnityEngine;

public class CustomizationsTutorial : GuiElementSingle<CustomizationsTutorial>, IGuiDialog
{
	[Header("Core")]
	public UILabel textTutorial;

	public GameObject continueButton;

	private bool mContinueClicked;

	private float mTimePassed;

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(continueButton.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ContinueClick));
		switch (Localization.instance.currentLanguage)
		{
		case "fr":
		case "de":
		case "pt":
			textTutorial.transform.localScale = new Vector3(40f, 40f, 1f);
			break;
		}
	}

	private void ContinueClick(GameObject go)
	{
		mContinueClicked = true;
	}

	public override void InitGUIValues()
	{
		mContinueClicked = false;
		mTimePassed = 0f;
		Singleton<BeanstalkServerManager>.instance.CustomizationShown();
	}

	public override void AnimateShow(bool forceFadeIn)
	{
		base.AnimateShow(forceFadeIn);
		StartCoroutine(Singleton<AtlasPreparer>.instance.LoadTutorialCoroutine());
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		Singleton<AtlasPreparer>.instance.UnloadTutorial();
	}

	protected override void Update()
	{
		base.Update();
		mTimePassed += Time.unscaledDeltaTime;
		if (mContinueClicked && mTimePassed > 1.5f)
		{
			mContinueClicked = false;
			mTimePassed = 0f;
			HideDialog();
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void OnBack()
	{
		ContinueClick(continueButton.gameObject);
	}
}
