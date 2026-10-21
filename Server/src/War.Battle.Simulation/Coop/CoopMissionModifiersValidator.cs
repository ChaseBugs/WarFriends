namespace War.BattleServer;

public static class CoopMissionModifiersValidator
{
    public static CoopMissionModifiers Validate(CoopMissionModifiers modifiers)
    {
        if(modifiers.EnemiesEnraged&&!modifiers.Heroic)
            throw new InvalidDataException("Enemy enraged modifier requires heroic mode.");
        return modifiers;
    }
}
