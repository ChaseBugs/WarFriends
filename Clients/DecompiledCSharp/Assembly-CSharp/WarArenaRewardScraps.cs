public class WarArenaRewardScraps : WarArenaReward
{
	public override string spriteName => "menu-arena-scrap-ico";

	public override string text => Localization.Localize("ID_ARENAREWARD_SCRAP");

	public override float scaleMultiplier => 1.139f;

	public override int order => 7;
}
