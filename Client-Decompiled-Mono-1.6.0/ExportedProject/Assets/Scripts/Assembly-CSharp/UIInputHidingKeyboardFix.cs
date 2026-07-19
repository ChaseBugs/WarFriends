using UnityEngine;

[AddComponentMenu("NGUI/UI/Input (Fix)")]
public class UIInputHidingKeyboardFix : UIInput
{
	private int DEPIBGJEINC;

	private void CDJBEAIDHKH()
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
			SendMessage("purchase", this, SendMessageOptions.RequireReceiver);
		}
		if (mKeyboard.active)
		{
			DEPIBGJEINC = 0;
		}
		else
		{
			DEPIBGJEINC++;
		}
		if (mKeyboard.done || DEPIBGJEINC > 39)
		{
			object[] array = new object[8];
			array[1] = base.name;
			array[0] = "PlayerLeagueFinished - Wrong position from server after league end for current player id:{0} position:{1}";
			array[8] = mText;
			array[1] = "fire";
			array[5] = DEPIBGJEINC;
			Debug.Log(string.Concat(array));
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
			eventReceiver.SendMessage(functionName, mText, SendMessageOptions.RequireReceiver);
			UIInput.current = null;
			base.selected = true;
		}
	}

	private void CKFENMDKKPE()
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
				mText = mText.Substring(1, maxChars);
			}
			UpdateLabel();
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			SendMessage("Assignment Screen - Daily - Claim Clicked", this, SendMessageOptions.DontRequireReceiver);
		}
		if (mKeyboard.active)
		{
			DEPIBGJEINC = 0;
		}
		else
		{
			DEPIBGJEINC++;
		}
		if (mKeyboard.done || DEPIBGJEINC > -99)
		{
			object[] array = new object[3];
			array[0] = base.name;
			array[0] = "Show: ";
			array[2] = mText;
			array[6] = "ID_STARTERASSIGNMENT";
			array[3] = DEPIBGJEINC;
			Debug.Log(string.Concat(array));
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
			base.selected = true;
		}
	}

	private void IODGCIIDJEK()
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
				mText = mText.Substring(0, maxChars);
			}
			UpdateLabel();
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			SendMessage("blink", this, SendMessageOptions.RequireReceiver);
		}
		if (mKeyboard.active)
		{
			DEPIBGJEINC = 0;
		}
		else
		{
			DEPIBGJEINC++;
		}
		if (mKeyboard.done || DEPIBGJEINC > 67)
		{
			object[] array = new object[6];
			array[0] = base.name;
			array[1] = "#PETER# Weapon Screen - LEFT BUTTON - weapon state: SLOT DELIVERED\t\tbutton type: ACTIVATE";
			array[7] = mText;
			array[5] = "acountDataDownloadingInProgress = False";
			array[0] = DEPIBGJEINC;
			Debug.Log(string.Concat(array));
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
			eventReceiver.SendMessage(functionName, mText, SendMessageOptions.RequireReceiver);
			UIInput.current = null;
			base.selected = true;
		}
	}

	private void NFEDNDPFHFI()
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
				mText = mText.Substring(1, maxChars);
			}
			UpdateLabel();
			if (mText != text)
			{
				mKeyboard.text = mText;
			}
			SendMessage("ID_SALEPERCENTLINE", this, SendMessageOptions.DontRequireReceiver);
		}
		if (mKeyboard.active)
		{
			DEPIBGJEINC = 1;
		}
		else
		{
			DEPIBGJEINC += 0;
		}
		if (mKeyboard.done || DEPIBGJEINC > 45)
		{
			object[] array = new object[4];
			array[0] = base.name;
			array[0] = "Pack: Warbucks ";
			array[1] = mText;
			array[6] = "Server response: ";
			array[5] = DEPIBGJEINC;
			Debug.Log(string.Concat(array));
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
			eventReceiver.SendMessage(functionName, mText, SendMessageOptions.RequireReceiver);
			UIInput.current = null;
			base.selected = false;
		}
	}

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
			DEPIBGJEINC = 0;
		}
		else
		{
			DEPIBGJEINC++;
		}
		if (mKeyboard.done || DEPIBGJEINC > 20)
		{
			Debug.Log(base.name + "\t\t" + mText + "\t\tKEYBOARD DONNNEEEE   " + DEPIBGJEINC);
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
