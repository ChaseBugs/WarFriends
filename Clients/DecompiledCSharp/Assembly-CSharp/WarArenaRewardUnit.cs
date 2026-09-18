public class WarArenaRewardUnit : WarArenaReward
{
	public LevelBehaviour behaviour;

	public int dropAmount;

	public override string spriteName => behaviour.upgradeSlots.iconNameElite;

	public override string text => behaviour.unitElitePartsName;

	public override bool doubleDrop => 50 == dropAmount;

	public override int order => (!doubleDrop) ? 1 : 0;
}
