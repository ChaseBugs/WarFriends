using UnityEngine;

public class WarArenaRewardGold : WarArenaReward
{
	public override string spriteName => "menu-gold";

	public override string text => Localization.Localize("ID_ARENAREWARD_GOLD");

	public override Quaternion iconRotation => Quaternion.Euler(0f, 180f, 0f);

	public override float scaleMultiplier => 0.458f;

	public override int order => 8;
}
