public class WarArenaRewardWarbucks : WarArenaReward
{
	public override string spriteName => "menu-warbucks";

	public override string text => Localization.Localize("ID_ARENAREWARD_WARBUCKS");

	public override float scaleMultiplier => 0.79f;

	public override int order => 9;
}
