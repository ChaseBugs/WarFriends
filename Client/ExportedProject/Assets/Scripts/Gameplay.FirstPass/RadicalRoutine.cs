using System;
using System.Collections;
using UnityEngine;

public class RadicalRoutine
{
	private bool cancel;

	public IEnumerator enumerator;

	private static RadicalRoutine own = new RadicalRoutine();

	public event Action Cancelled;

	public event Action Finished;

	public void Cancel()
	{
		cancel = true;
	}

	public static IEnumerator Run(IEnumerator extendedCoRoutine)
	{
		return own.Execute(extendedCoRoutine);
	}

	public static RadicalRoutine Create(IEnumerator extendedCoRoutine)
	{
		RadicalRoutine radicalRoutine = new RadicalRoutine();
		radicalRoutine.enumerator = radicalRoutine.Execute(extendedCoRoutine);
		return radicalRoutine;
	}

	private IEnumerator Execute(IEnumerator extendedCoRoutine)
	{
		while (!cancel && extendedCoRoutine != null && extendedCoRoutine.MoveNext())
		{
			object v = extendedCoRoutine.Current;
			if (v is CoroutineReturn cr)
			{
				if (cr.cancel)
				{
					cancel = true;
					break;
				}
				while (!cr.finished)
				{
					if (cr.cancel)
					{
						cancel = true;
						break;
					}
					yield return new WaitForEndOfFrame();
				}
			}
			else
			{
				yield return v;
			}
		}
		if (cancel && this.Cancelled != null)
		{
			this.Cancelled();
		}
		if (this.Finished != null)
		{
			this.Finished();
		}
	}
}
