using UnityEngine;

public class WarArenaReward
{
	public virtual int order => 10;

	public virtual string spriteName => string.Empty;

	public virtual string text => string.Empty;

	public virtual bool doubleDrop => false;

	public virtual Quaternion iconRotation => Quaternion.Euler(0f, 0f, 0f);

	public virtual float scaleMultiplier => 1f;
}
