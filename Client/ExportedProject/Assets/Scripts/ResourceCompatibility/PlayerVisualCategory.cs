using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public abstract class PlayerVisualCategory : Core_BaseScript
{
	public string HPOCJBBBPOC;

	public string GEJJLILPJEP;

	public string GFEPGEFGEGD;

	[CompilerGenerated]
	private int _003CJFPAJMDNIDA_003Ek__BackingField;

	public int categoryNumber
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public abstract IEnumerable<PlayerVisual> allVisuals { get; }

	public abstract int count { get; }

	public abstract PlayerVisual equippedVisual { get; }

	public abstract PlayerVisual Item { get; }

	public abstract void SetVisualIds();

	public abstract void InitVisuals();

	public abstract IEnumerator PrepareAssets();
}
