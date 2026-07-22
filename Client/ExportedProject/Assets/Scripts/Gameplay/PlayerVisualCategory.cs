using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Serialization;

public abstract class PlayerVisualCategory : Core_BaseScript
{
	[FormerlySerializedAs("HPOCJBBBPOC")]
	public string DAANKCOLJGJ;

	[FormerlySerializedAs("GEJJLILPJEP")]
	public string KLMFIBIIALC;

	[FormerlySerializedAs("GFEPGEFGEGD")]
	public string EGKNDPKCHPC;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private int _003CAKELJKEEAND_003Ek__BackingField;

	public int categoryNumber
	{
		[CompilerGenerated]
		get
		{
			return _003CAKELJKEEAND_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CAKELJKEEAND_003Ek__BackingField = value;
		}
	}

	public abstract IEnumerable<PlayerVisual> allVisuals { get; }

	public abstract int count { get; }

	public abstract PlayerVisual equippedVisual { get; }

	public abstract PlayerVisual this[string INFLHPGMEOB] { get; }

	public abstract void SetVisualIds();

	public abstract void InitVisuals();

	public abstract IEnumerator PrepareAssets();
}
