using System;
using System.Collections;
using UnityEngine;

public class Core_BaseScript : MonoBehaviour
{
	public void InvokeAfter(Action a, float seconds)
	{
	}

	public void InvokeAfterRealTime(Action a, float seconds)
	{
	}

	public void InvokeAfterRealTimeWithoutPause(Action a, float seconds)
	{
	}

	public void InvokeAfterFrame(Action a)
	{
	}

	public void InvokeAfterXFrames(Action a, int frames)
	{
	}

	private static IEnumerator WaitAndCallAfterFrame(Action a)
	{
		return null;
	}

	private static IEnumerator WaitAndCallAfterXFrames(Action a, int frames)
	{
		return null;
	}

	private static IEnumerator WaitAndCall(Action a, float seconds)
	{
		return null;
	}

	private static IEnumerator WaitAndCallRealTime(Action a, float seconds)
	{
		return null;
	}

	private static IEnumerator WaitAndCallRealTimeWithoutPause(Action a, float seconds)
	{
		return null;
	}

	protected void SetLayerRecursively(GameObject obj, int newLayer)
	{
	}

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	protected T GetComponentImplementing<T>() where T : class
	{
		return null;
	}
}
