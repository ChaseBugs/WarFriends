using UnityEngine;

public class UIInput : MonoBehaviour
{
	public delegate char Validator(string currentText, char nextChar);

	public enum KeyboardType
	{
		Default,
		ASCIICapable,
		NumbersAndPunctuation,
		URL,
		NumberPad,
		PhonePad,
		NamePhonePad,
		EmailAddress
	}

	public delegate void OnSubmit(string inputString);

	public delegate void OnLostFocus(string inputString);

	public delegate void InputChanged(string inputString);

	public static UIInput current;

	public UILabel label;

	public int maxChars;

	public string caratChar;

	public Validator validator;

	public KeyboardType type;

	public bool isPassword;

	public bool autoCorrect;

	public bool useLabelTextAtStart;

	public Color activeColor;

	public GameObject selectOnTab;

	public GameObject eventReceiver;

	public string functionName;

	public OnSubmit onSubmit;

	public OnLostFocus onLostFocus;

	public InputChanged onInputChanged;

	protected string mText;

	protected string mDefaultText;

	protected Color mDefaultColor;

	private UIWidget.Pivot mPivot;

	private float mPosition;

	public TouchScreenKeyboard mKeyboard;

	protected bool mDoInit;

	public virtual string text
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public bool selected
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public string defaultText
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	protected void Init()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void OnSelect(bool isSelected)
	{
	}

	private void Update()
	{
	}

	protected virtual void UpdateMethod()
	{
	}

	private void OnInput(string input)
	{
	}

	private void OnInputChanged()
	{
	}

	protected void Append(string input)
	{
	}

	protected void UpdateLabel()
	{
	}

	protected void RestoreLabel()
	{
	}

	private void OnApplicationPause(bool pauseStatus)
	{
	}
}
