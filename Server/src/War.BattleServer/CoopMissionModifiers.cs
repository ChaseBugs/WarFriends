namespace War.BattleServer;

public readonly record struct CoopMissionModifiers(bool Heroic,bool EnemiesEnraged,bool NoRespawn);

public static class CoopMissionModifiersValidator
{
    public static CoopMissionModifiers Validate(CoopMissionModifiers modifiers)
    {
        if(modifiers.EnemiesEnraged&&!modifiers.Heroic)
            throw new InvalidDataException("Enemy enraged modifier requires heroic mode.");
        return modifiers;
    }
}
