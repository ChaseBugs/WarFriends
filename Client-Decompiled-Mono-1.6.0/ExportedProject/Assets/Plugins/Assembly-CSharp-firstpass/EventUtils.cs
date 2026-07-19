using System;
using UnityEngine;

public class EventUtils : MonoBehaviour
{
	private static EventUtils instance;

	private event Action delayed;

	private void Update()
	{
		this.delayed.Call();
		this.delayed = null;
	}

	public static void Delay(Action act)
	{
		if (!instance)
		{
			instance = new GameObject("event utils", typeof(EventUtils)).GetComponent<EventUtils>();
			instance.hideFlags = HideFlags.HideAndDontSave;
		}
		instance.delayed += act;
	}
}
