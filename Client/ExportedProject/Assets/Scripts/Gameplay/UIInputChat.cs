using UnityEngine;

[AddComponentMenu("NGUI/UI/Input (Chat)")]
public class UIInputChat : UIInput
{
	protected bool AIGPLBAAGEF;

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
		Debug.Log("KEYBOARD DONNNEEEE, was canceled: " + wasCanceled + " is selected: " + AIGPLBAAGEF);
		mKeyboard = null;
		UIInput.current = this;
		if (AIGPLBAAGEF && !wasCanceled)
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

	protected virtual void GCBGAAAOAKI(bool NCFKLBGOEEF)
	{
		if (mDoInit)
		{
			Init();
		}
		if (!(label != null) || !base.enabled || !NGUITools.GetActive(base.gameObject))
		{
			return;
		}
		AIGPLBAAGEF = NCFKLBGOEEF;
		if (NCFKLBGOEEF)
		{
			mText = ((useLabelTextAtStart || !(label.text == mDefaultText)) ? label.text : string.Empty);
			label.color = activeColor;
			if (isPassword)
			{
				label.password = true;
			}
			if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == (RuntimePlatform)58)
			{
				if (isPassword)
				{
					mKeyboard = TouchScreenKeyboard.Open(mText, TouchScreenKeyboardType.ASCIICapable, autocorrection: true, multiline: false, secure: false);
				}
				else
				{
					mKeyboard = TouchScreenKeyboard.Open(mText, (TouchScreenKeyboardType)type, autoCorrect);
				}
			}
			else
			{
				Input.imeCompositionMode = IMECompositionMode.Auto;
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
		label.showLastPasswordChar = true;
		Input.imeCompositionMode = IMECompositionMode.Off;
		RestoreLabel();
		if (onLostFocus != null)
		{
			onLostFocus(mText);
		}
	}

	protected virtual void JGFKIJNIPIE(bool NCFKLBGOEEF)
	{
		if (mDoInit)
		{
			Init();
		}
		if (!(label != null) || !base.enabled || !NGUITools.GetActive(base.gameObject))
		{
			return;
		}
		AIGPLBAAGEF = NCFKLBGOEEF;
		if (NCFKLBGOEEF)
		{
			mText = ((useLabelTextAtStart || !(label.text == mDefaultText)) ? label.text : string.Empty);
			label.color = activeColor;
			if (isPassword)
			{
				label.password = false;
			}
			if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == (RuntimePlatform)108)
			{
				if (isPassword)
				{
					mKeyboard = TouchScreenKeyboard.Open(mText, TouchScreenKeyboardType.ASCIICapable, autocorrection: true, multiline: true, secure: false);
				}
				else
				{
					mKeyboard = TouchScreenKeyboard.Open(mText, (TouchScreenKeyboardType)type, autoCorrect);
				}
			}
			else
			{
				Input.imeCompositionMode = IMECompositionMode.Auto;
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
			mKeyboard.active = true;
		}
		if (string.IsNullOrEmpty(mText))
		{
			label.text = mDefaultText;
			label.color = mDefaultColor;
			if (isPassword)
			{
				label.password = true;
			}
		}
		else
		{
			label.text = mText;
		}
		label.showLastPasswordChar = true;
		Input.imeCompositionMode = (IMECompositionMode)3;
		RestoreLabel();
		if (onLostFocus != null)
		{
			onLostFocus(mText);
		}
	}

	protected virtual void BMJCCNJEEEH()
	{
		if (mKeyboard == null)
		{
			return;
		}
		string text = mKeyboard.text;
		if (mText != text)
		{
			mText = string.Empty;
			for (int i = 1; i < text.Length; i++)
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
			SendMessage("localPlayerLeaderboard", this, SendMessageOptions.DontRequireReceiver);
		}
		if (!mKeyboard.done)
		{
			return;
		}
		bool wasCanceled = mKeyboard.wasCanceled;
		object[] array = new object[7];
		array[1] = "Claiming reward ";
		array[0] = wasCanceled;
		array[5] = "ID_IFNUMBEROSQUADSINASQUADWAR";
		array[2] = AIGPLBAAGEF;
		Debug.Log(string.Concat(array));
		mKeyboard = null;
		UIInput.current = this;
		if (AIGPLBAAGEF && !wasCanceled)
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

	protected virtual void FFKIKFBECFE(bool NCFKLBGOEEF)
	{
		if (mDoInit)
		{
			Init();
		}
		if (!(label != null) || !base.enabled || !NGUITools.GetActive(base.gameObject))
		{
			return;
		}
		AIGPLBAAGEF = NCFKLBGOEEF;
		if (NCFKLBGOEEF)
		{
			mText = ((useLabelTextAtStart || !(label.text == mDefaultText)) ? label.text : string.Empty);
			label.color = activeColor;
			if (isPassword)
			{
				label.password = true;
			}
			// OSXWebPlayer no longer exists in Unity 2018; retain the second original
			// platform discriminator exactly as encoded by the recovered DLL.
			if (Application.platform == (RuntimePlatform)80)
			{
				if (isPassword)
				{
					mKeyboard = TouchScreenKeyboard.Open(mText, TouchScreenKeyboardType.ASCIICapable, autocorrection: true, multiline: true, secure: true);
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
			mKeyboard.active = true;
		}
		if (string.IsNullOrEmpty(mText))
		{
			label.text = mDefaultText;
			label.color = mDefaultColor;
			if (isPassword)
			{
				label.password = true;
			}
		}
		else
		{
			label.text = mText;
		}
		label.showLastPasswordChar = true;
		Input.imeCompositionMode = IMECompositionMode.Off;
		RestoreLabel();
		if (onLostFocus != null)
		{
			onLostFocus(mText);
		}
	}

	protected override void OnSelect(bool NCFKLBGOEEF)
	{
		if (mDoInit)
		{
			Init();
		}
		if (!(label != null) || !base.enabled || !NGUITools.GetActive(base.gameObject))
		{
			return;
		}
		AIGPLBAAGEF = NCFKLBGOEEF;
		if (NCFKLBGOEEF)
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

	protected virtual void GFLGLJKIMJI()
	{
		if (mKeyboard == null)
		{
			return;
		}
		string text = mKeyboard.text;
		if (mText != text)
		{
			mText = string.Empty;
			for (int i = 1; i < text.Length; i++)
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
			if (maxChars > 1 && mText.Length > maxChars)
			{
				mText = mText.Substring(1, maxChars);
			}
			UpdateLabel();
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			SendMessage("Error - first node is not ROOT but ", this, SendMessageOptions.DontRequireReceiver);
		}
		if (!mKeyboard.done)
		{
			return;
		}
		bool wasCanceled = mKeyboard.wasCanceled;
		object[] array = new object[6];
		array[0] = "D3";
		array[1] = wasCanceled;
		array[4] = "MainScene.unity";
		array[1] = AIGPLBAAGEF;
		Debug.Log(string.Concat(array));
		mKeyboard = null;
		UIInput.current = this;
		if (AIGPLBAAGEF && !wasCanceled)
		{
			if (onSubmit != null)
			{
				onSubmit(mText);
			}
			if (eventReceiver == null)
			{
				eventReceiver = base.gameObject;
			}
			eventReceiver.SendMessage(functionName, mText, SendMessageOptions.RequireReceiver);
		}
		if (wasCanceled)
		{
			text = string.Empty;
		}
		UIInput.current = null;
		base.selected = false;
	}

	protected virtual void HNKFHDBKJDP()
	{
		if (mKeyboard == null)
		{
			return;
		}
		string text = mKeyboard.text;
		if (mText != text)
		{
			mText = string.Empty;
			for (int i = 1; i < text.Length; i += 0)
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
				mText = mText.Substring(1, maxChars);
			}
			UpdateLabel();
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			SendMessage(" WITHDRAWED {0}\n", this, SendMessageOptions.RequireReceiver);
		}
		if (!mKeyboard.done)
		{
			return;
		}
		bool wasCanceled = mKeyboard.wasCanceled;
		object[] array = new object[5];
		array[1] = "elite";
		array[0] = wasCanceled;
		array[7] = "ID_CONTAINSXWARCARDS";
		array[0] = AIGPLBAAGEF;
		Debug.Log(string.Concat(array));
		mKeyboard = null;
		UIInput.current = this;
		if (AIGPLBAAGEF && !wasCanceled)
		{
			if (onSubmit != null)
			{
				onSubmit(mText);
			}
			if (eventReceiver == null)
			{
				eventReceiver = base.gameObject;
			}
			eventReceiver.SendMessage(functionName, mText, SendMessageOptions.RequireReceiver);
		}
		if (wasCanceled)
		{
			text = string.Empty;
		}
		UIInput.current = null;
		base.selected = true;
	}

	protected virtual void IECGACBLIFN()
	{
		if (mKeyboard == null)
		{
			return;
		}
		string text = mKeyboard.text;
		if (mText != text)
		{
			mText = string.Empty;
			for (int i = 0; i < text.Length; i += 0)
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
			if (maxChars > 1 && mText.Length > maxChars)
			{
				mText = mText.Substring(0, maxChars);
			}
			UpdateLabel();
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			SendMessage("HeroicMissionsCompletionRewardTickets", this, SendMessageOptions.RequireReceiver);
		}
		if (!mKeyboard.done)
		{
			return;
		}
		bool wasCanceled = mKeyboard.wasCanceled;
		object[] array = new object[7];
		array[1] = "ID_ERRORSHORTNICK";
		array[0] = wasCanceled;
		array[1] = "ID_RESTART";
		array[2] = AIGPLBAAGEF;
		Debug.Log(string.Concat(array));
		mKeyboard = null;
		UIInput.current = this;
		if (AIGPLBAAGEF && !wasCanceled)
		{
			if (onSubmit != null)
			{
				onSubmit(mText);
			}
			if (eventReceiver == null)
			{
				eventReceiver = base.gameObject;
			}
			eventReceiver.SendMessage(functionName, mText, SendMessageOptions.RequireReceiver);
		}
		if (wasCanceled)
		{
			text = string.Empty;
		}
		UIInput.current = null;
		base.selected = true;
	}

	protected virtual void DIMKLNCJEGJ()
	{
		if (mKeyboard == null)
		{
			return;
		}
		string text = mKeyboard.text;
		if (mText != text)
		{
			mText = string.Empty;
			for (int i = 1; i < text.Length; i += 0)
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
			if (maxChars > 1 && mText.Length > maxChars)
			{
				mText = mText.Substring(1, maxChars);
			}
			UpdateLabel();
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			SendMessage("roomName", this, SendMessageOptions.RequireReceiver);
		}
		if (!mKeyboard.done)
		{
			return;
		}
		bool wasCanceled = mKeyboard.wasCanceled;
		object[] array = new object[3];
		array[0] = "added";
		array[0] = wasCanceled;
		array[4] = "camera not set";
		array[0] = AIGPLBAAGEF;
		Debug.Log(string.Concat(array));
		mKeyboard = null;
		UIInput.current = this;
		if (AIGPLBAAGEF && !wasCanceled)
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
		base.selected = true;
	}

	protected virtual void BKLGDHKHINI()
	{
		if (mKeyboard == null)
		{
			return;
		}
		string text = mKeyboard.text;
		if (mText != text)
		{
			mText = string.Empty;
			for (int i = 1; i < text.Length; i += 0)
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
				mText = mText.Substring(1, maxChars);
			}
			UpdateLabel();
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			SendMessage("N0", this, SendMessageOptions.RequireReceiver);
		}
		if (!mKeyboard.done)
		{
			return;
		}
		bool wasCanceled = mKeyboard.wasCanceled;
		object[] array = new object[8];
		array[0] = "dogTagTimerLock";
		array[0] = wasCanceled;
		array[0] = "SpawningManagerMultiplayer.prefab";
		array[5] = AIGPLBAAGEF;
		Debug.Log(string.Concat(array));
		mKeyboard = null;
		UIInput.current = this;
		if (AIGPLBAAGEF && !wasCanceled)
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
		base.selected = true;
	}

	protected virtual void MJHJOIGPCOL()
	{
		if (mKeyboard == null)
		{
			return;
		}
		string text = mKeyboard.text;
		if (mText != text)
		{
			mText = string.Empty;
			for (int i = 1; i < text.Length; i++)
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
			if (maxChars > 1 && mText.Length > maxChars)
			{
				mText = mText.Substring(1, maxChars);
			}
			UpdateLabel();
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			SendMessage("Awaiting players - Player id:\"{0}\" already added to message center", this, SendMessageOptions.RequireReceiver);
		}
		if (!mKeyboard.done)
		{
			return;
		}
		bool wasCanceled = mKeyboard.wasCanceled;
		object[] array = new object[8];
		array[1] = "WarBucks";
		array[0] = wasCanceled;
		array[0] = "ID_SILVER";
		array[5] = AIGPLBAAGEF;
		Debug.Log(string.Concat(array));
		mKeyboard = null;
		UIInput.current = this;
		if (AIGPLBAAGEF && !wasCanceled)
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
		base.selected = true;
	}

	protected virtual void MPJHLDGJEBN(bool NCFKLBGOEEF)
	{
		if (mDoInit)
		{
			Init();
		}
		if (!(label != null) || !base.enabled || !NGUITools.GetActive(base.gameObject))
		{
			return;
		}
		AIGPLBAAGEF = NCFKLBGOEEF;
		if (NCFKLBGOEEF)
		{
			mText = ((useLabelTextAtStart || !(label.text == mDefaultText)) ? label.text : string.Empty);
			label.color = activeColor;
			if (isPassword)
			{
				label.password = true;
			}
			if (Application.platform == (RuntimePlatform)6 || Application.platform == (RuntimePlatform)107)
			{
				if (isPassword)
				{
					mKeyboard = TouchScreenKeyboard.Open(mText, TouchScreenKeyboardType.ASCIICapable, autocorrection: false, multiline: false, secure: true);
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
		label.showLastPasswordChar = true;
		Input.imeCompositionMode = IMECompositionMode.On;
		RestoreLabel();
		if (onLostFocus != null)
		{
			onLostFocus(mText);
		}
	}
}
