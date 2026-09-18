public class WarArenaRewardTickets : WarArenaReward
{
	public override string spriteName => "menu-arena-ticket";

	public override string text => Localization.Localize("ID_ARENAREWARD_TICKETS");

	public override int order => 6;
}
