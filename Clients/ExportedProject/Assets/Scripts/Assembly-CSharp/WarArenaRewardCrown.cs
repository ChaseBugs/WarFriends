public class WarArenaRewardCrown : WarArenaReward
{
	public PlayerVisual crown;

	public WarArenaConfig.VisualType type;

	public override string spriteName => crown.icon;

	public override string text => crown.name;

	public override int order => (int)(5 - type);
}
