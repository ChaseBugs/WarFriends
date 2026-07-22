using System;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

public class DoubleUpgradesManager : DatabaseSerializedObjectGeneric<DoubleUpgradesManager.DoubleUpgradesData>
{
	[Preserve]
	public class DoubleUpgradesData
	{
		public int end;
	}

	public static DoubleUpgradesManager DJDBDKFAKHN;

	[CompilerGenerated]
	private Action<bool> NDALCLDCOHE;

	private bool PINIDLBHNJF;

	public static DoubleUpgradesManager instance => null;

	public bool isDoubleUpgradesActive => false;

	public bool isDoubleUpgradesOffered => false;

	public int doubleUpgradesEnd => 0;

	public event Action<bool> StatusChanged
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

	protected void Update()
	{
	}
}
