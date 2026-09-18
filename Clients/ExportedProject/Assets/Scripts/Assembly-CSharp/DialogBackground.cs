using UnityEngine;

public class DialogBackground : Core_BaseScript
{
	public UIPanel panel;

	private static DialogBackground mInstance;

	private bool mAnimating;

	public static DialogBackground instance
	{
		get
		{
			mInstance = Singleton<GuiManager>.instance.root.GetComponentsInChildren<DialogBackground>(includeInactive: true)[0];
			if (mInstance == null)
			{
				Debug.LogError("DialogBackground is not in scene -> add it.");
			}
			return mInstance;
		}
	}

	public void ShowBackground(float time)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			panel.alpha1 = 0.005f;
			mAnimating = true;
			TweenAlpha.Begin(panel.gameObject, time, 0.005f, 1f).onFinished = delegate
			{
				mAnimating = false;
			};
		}
	}

	public void HideBackground(float time)
	{
		if (base.gameObject.activeSelf && !mAnimating)
		{
			mAnimating = true;
			TweenAlpha.Begin(panel.gameObject, time, 0.005f).onFinished = delegate
			{
				mAnimating = false;
				base.gameObject.SetActive(value: false);
			};
		}
	}
}
