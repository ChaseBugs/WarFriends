using UnityEngine;

[AddComponentMenu("NGUI/UI/Input (Fix)")]
public class UIInputHidingKeyboardFix : UIInput
{
	private int numberOfUpdatesWithKeyboardInactive;

	private void Update()
	{
		if (mKeyboard == null)
		{
			return;
		}
		string text = mKeyboard.text;
		if (mText != text)
		{
			mText = string.Empty;
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (validator != null)
				{
					c = validator(mText, c);
				}
				if (c != 0)
				{
					mText += c;
				}
			}
			if (maxChars > 0 && mText.Length > maxChars)
			{
				mText = mText.Substring(0, maxChars);
			}
			UpdateLabel();
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			SendMessage("OnInputChanged", this, SendMessageOptions.DontRequireReceiver);
		}
		if (mKeyboard.active)
		{
			numberOfUpdatesWithKeyboardInactive = 0;
		}
		else
		{
			numberOfUpdatesWithKeyboardInactive++;
		}
		if (mKeyboard.done || numberOfUpdatesWithKeyboardInactive > 20)
		{
			Debug.Log(base.name + "\t\t" + mText + "\t\tKEYBOARD DONNNEEEE   " + numberOfUpdatesWithKeyboardInactive);
			Debug.Log(mKeyboard.wasCanceled);
			mKeyboard = null;
			UIInput.current = this;
			if (onSubmit != null)
			{
				onSubmit(mText);
			}
			if (eventReceiver == null)
			{
				eventReceiver = base.gameObject;
			}
			eventReceiver.SendMessage(functionName, mText, SendMessageOptions.DontRequireReceiver);
			UIInput.current = null;
			base.selected = false;
		}
	}
}
