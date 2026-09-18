using System;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
	public Action<string> OnAnimationEvent;

	public void Event(string param)
	{
		if (OnAnimationEvent != null)
		{
			OnAnimationEvent(param);
		}
	}
}
