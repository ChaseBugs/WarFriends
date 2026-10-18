using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private void RefillSicknessCardUnit(BattleArmyEntityState entity, SicknessSpawnWindow window,
        SicknessSpawnTarget target)
    {
        BattleArmyEntityState current = cardUnitCombat!.Find(entity.EntityKey) ??
            throw new InvalidDataException("Sickness card unit lost its current vitality authority.");
        if (current.Health != entity.Health || current.MaxHealth != entity.MaxHealth)
        {
            throw new InvalidDataException("Sickness card-unit vitality mirrors disagree.");
        }

        var vitality = new SicknessCombatState(current.MaxHealth, current.Health, Array.Empty<float>());
        SicknessCombatState changedVitality = window.Apply(target, vitality);
        BattleArmyEntityState changed = cardUnitCombat.RefillHealth(entity.EntityKey, changedVitality.Health) ??
            throw new InvalidDataException("Sickness card unit disappeared before its vitality update.");
        entity.Health = changed.Health;
    }
}
