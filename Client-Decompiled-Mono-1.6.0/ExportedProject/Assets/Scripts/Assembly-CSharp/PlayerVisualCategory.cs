using System.Collections;
using System.Collections.Generic;

public abstract class PlayerVisualCategory : Core_BaseScript
{
	public string DAANKCOLJGJ;

	public string KLMFIBIIALC;

	public string EGKNDPKCHPC;

	public int categoryNumber { get; set; }

	public abstract IEnumerable<PlayerVisual> allVisuals { get; }

	public abstract int count { get; }

	public abstract PlayerVisual equippedVisual { get; }

	public abstract PlayerVisual this[string INFLHPGMEOB] { get; }

	public abstract void SetVisualIds();

	public abstract void InitVisuals();

	public abstract IEnumerator PrepareAssets();
}
