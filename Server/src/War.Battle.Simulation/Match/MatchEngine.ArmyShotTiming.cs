namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void ConsumeArmyCooldownDraw(ulong entityKey)
    {
        // GenerateNextShootTime draws even when a family override immediately replaces the deadline.
        ArmyBaseShotStats shot = armyShots[entityKey];
        float seconds = shot.MinShootTime + NextArmyFloat() * (shot.MaxShootTime - shot.MinShootTime);
        if (!float.IsFinite(seconds) || seconds < 0f)
        {
            throw new InvalidDataException("Army source cooldown draw lost its composed bounds.");
        }
    }
}
