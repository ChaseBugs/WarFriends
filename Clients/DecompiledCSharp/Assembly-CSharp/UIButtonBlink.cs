using System;
using UnityEngine;

public class UIButtonBlink : MonoBehaviour
{
	public BlinkingObject BlinkTarget;

	private void OnClick()
	{
		if (BlinkTarget != null)
		{
			BlinkTarget.Blink();
			BlinkingObject blinkTarget = BlinkTarget;
			blinkTarget.BlinkingFinished = (Action<BlinkingObject>)Delegate.Combine(blinkTarget.BlinkingFinished, new Action<BlinkingObject>(BlinkingFinished));
			return;
		}
		BlinkingObjectMultiple component = GetComponent<BlinkingObjectMultiple>();
		if (component != null)
		{
			Debug.Log("blink");
			component.Blink();
		}
	}

	private void BlinkingFinished(BlinkingObject blinkingObject)
	{
	}
}
