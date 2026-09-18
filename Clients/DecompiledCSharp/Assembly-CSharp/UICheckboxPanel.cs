using System;
using UnityEngine;

public class UICheckboxPanel : MonoBehaviour
{
	private bool _isOn;

	public Action<bool> StateChanged;

	public GameObject ButtonContent;

	public Vector3 ContentMovement;

	private Vector3 mButtonContentStartPos = new Vector3(0f, 0f, 0f);

	public float animTime = 0.3f;

	public Color EnabledColor;

	public Color DisabledColor;

	public GameObject enabledObject;

	public GameObject disabledObject;

	public bool IsOn
	{
		get
		{
			return _isOn;
		}
		set
		{
			if (_isOn != value)
			{
				_isOn = value;
				ButtonContent.transform.localPosition = ((!IsOn) ? mButtonContentStartPos : ContentMovement);
				TweenPosition.Begin(ButtonContent.gameObject, 0f, (!IsOn) ? mButtonContentStartPos : ContentMovement);
				if (enabledObject != null && disabledObject != null)
				{
					TweenColor.Begin(enabledObject, 0f, (!IsOn) ? DisabledColor : EnabledColor);
					TweenColor.Begin(disabledObject, 0f, IsOn ? DisabledColor : EnabledColor);
				}
			}
		}
	}

	private void OnEnable()
	{
		ButtonContent.transform.localPosition = ((!IsOn) ? mButtonContentStartPos : ContentMovement);
		if (enabledObject != null && disabledObject != null)
		{
			TweenColor.Begin(enabledObject, 0f, (!IsOn) ? DisabledColor : EnabledColor);
			TweenColor.Begin(disabledObject, 0f, IsOn ? DisabledColor : EnabledColor);
		}
	}

	private void OnClick()
	{
		_isOn = !_isOn;
		TweenPosition tweenPosition = TweenPosition.Begin(ButtonContent.gameObject, animTime, (!IsOn) ? mButtonContentStartPos : ContentMovement);
		tweenPosition.method = UITweener.Method.EaseInOut;
		if (StateChanged != null)
		{
			StateChanged(IsOn);
		}
		if (enabledObject != null && disabledObject != null)
		{
			TweenColor.Begin(enabledObject, animTime, (!IsOn) ? DisabledColor : EnabledColor);
			TweenColor.Begin(disabledObject, animTime, IsOn ? DisabledColor : EnabledColor);
		}
	}
}
