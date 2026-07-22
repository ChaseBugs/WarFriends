using System;
using System.Collections;
using System.Runtime.CompilerServices;

public class RadicalRoutine
{
	private bool cancel;

	public IEnumerator enumerator;

	private static RadicalRoutine own;

	public event Action Cancelled
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action Finished
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void Cancel()
	{
	}

	public static IEnumerator Run(IEnumerator extendedCoRoutine)
	{
		return null;
	}

	public static RadicalRoutine Create(IEnumerator extendedCoRoutine)
	{
		return null;
	}

	private IEnumerator Execute(IEnumerator extendedCoRoutine)
	{
		return null;
	}
}
