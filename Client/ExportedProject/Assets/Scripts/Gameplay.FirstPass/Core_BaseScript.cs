using System;
using System.Collections;
using UnityEngine;

public class Core_BaseScript : MonoBehaviour
{
	public void InvokeAfter(Action a, float seconds)
	{
		StartCoroutine(WaitAndCall(a, seconds));
	}

	public void InvokeAfterRealTime(Action a, float seconds)
	{
		StartCoroutine(RadicalRoutine.Run(WaitAndCallRealTime(a, seconds)));
	}

	public void InvokeAfterRealTimeWithoutPause(Action a, float seconds)
	{
		StartCoroutine(RadicalRoutine.Run(WaitAndCallRealTimeWithoutPause(a, seconds)));
	}

	public void InvokeAfterFrame(Action a)
	{
		StartCoroutine(WaitAndCallAfterFrame(a));
	}

	public void InvokeAfterXFrames(Action a, int frames)
	{
		StartCoroutine(WaitAndCallAfterXFrames(a, frames));
	}

	private static IEnumerator WaitAndCallAfterFrame(Action a)
	{
		yield return null;
		a();
	}

	private static IEnumerator WaitAndCallAfterXFrames(Action a, int frames)
	{
		for (int i = 0; i < frames; i++)
		{
			yield return null;
		}
		a();
	}

	private static IEnumerator WaitAndCall(Action a, float seconds)
	{
		yield return new WaitForSeconds(seconds);
		a();
	}

	private static IEnumerator WaitAndCallRealTime(Action a, float seconds)
	{
		yield return new WaitForRealSeconds(seconds);
		a();
	}

	private static IEnumerator WaitAndCallRealTimeWithoutPause(Action a, float seconds)
	{
		yield return new WaitForRealSecondsWithoutPause(seconds);
		a();
	}

	protected void SetLayerRecursively(GameObject obj, int newLayer)
	{
		obj.layer = newLayer;
		foreach (Transform item in obj.transform)
		{
			SetLayerRecursively(item.gameObject, newLayer);
		}
	}

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	protected T GetComponentImplementing<T>() where T : class
	{
		Core_BaseScript[] components = GetComponents<Core_BaseScript>();
		Core_BaseScript[] array = components;
		foreach (Core_BaseScript core_BaseScript in array)
		{
			if (core_BaseScript is T)
			{
				return core_BaseScript as T;
			}
		}
		return (T)null;
	}
}
