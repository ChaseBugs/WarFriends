using UnityEngine;

[AddComponentMenu("NGUI/UI/Input (Chat)")]
public class UIInputChat : UIInput
{
	protected bool mIsSelectedKeyboard;

	protected override void OnSelect(bool isSelected)
	{
		if (mDoInit)
		{
			Init();
		}
		if (!(label != null) || !base.enabled || !NGUITools.GetActive(base.gameObject))
		{
			return;
		}
		mIsSelectedKeyboard = isSelected;
		if (isSelected)
		{
			mText = ((useLabelTextAtStart || !(label.text == mDefaultText)) ? label.text : string.Empty);
			label.color = activeColor;
			if (isPassword)
			{
				label.password = true;
			}
			if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
			{
				if (isPassword)
				{
					mKeyboard = TouchScreenKeyboard.Open(mText, TouchScreenKeyboardType.Default, autocorrection: false, multiline: false, secure: true);
				}
				else
				{
					mKeyboard = TouchScreenKeyboard.Open(mText, (TouchScreenKeyboardType)type, autoCorrect);
				}
			}
			else
			{
				Input.imeCompositionMode = IMECompositionMode.On;
				Transform cachedTransform = label.cachedTransform;
				Vector3 position = label.pivotOffset;
				position.y += label.relativeSize.y;
				position = cachedTransform.TransformPoint(position);
				Input.compositionCursorPos = UICamera.currentCamera.WorldToScreenPoint(position);
			}
			UpdateLabel();
			return;
		}
		if (mKeyboard != null)
		{
			mKeyboard.active = false;
		}
		if (string.IsNullOrEmpty(mText))
		{
			label.text = mDefaultText;
			label.color = mDefaultColor;
			if (isPassword)
			{
				label.password = false;
			}
		}
		else
		{
			label.text = mText;
		}
		label.showLastPasswordChar = false;
		Input.imeCompositionMode = IMECompositionMode.Off;
		RestoreLabel();
		if (onLostFocus != null)
		{
			onLostFocus(mText);
		}
	}

	protected override void UpdateMethod()
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
		if (!mKeyboard.done)
		{
			return;
		}
		bool wasCanceled = mKeyboard.wasCanceled;
		Debug.Log("KEYBOARD DONNNEEEE, was canceled: " + wasCanceled + " is selected: " + mIsSelectedKeyboard);
		mKeyboard = null;
		UIInput.current = this;
		if (mIsSelectedKeyboard && !wasCanceled)
		{
			if (onSubmit != null)
			{
				onSubmit(mText);
			}
			if (eventReceiver == null)
			{
				eventReceiver = base.gameObject;
			}
			eventReceiver.SendMessage(functionName, mText, SendMessageOptions.DontRequireReceiver);
		}
		if (wasCanceled)
		{
			text = string.Empty;
		}
		UIInput.current = null;
		base.selected = false;
	}
}
