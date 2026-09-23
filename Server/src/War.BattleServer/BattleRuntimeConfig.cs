namespace War.BattleServer;

public sealed record BattleRuntimeConfig(int Port,int MaxMatches,int TickRate,int MtuBytes);

public static class BattleRuntimeConfigValidator
{
    public static BattleRuntimeConfig ValidateAndFreeze(BattleRuntimeConfig config)
    {
        Validate(config);
        return new BattleRuntimeConfig(config.Port, config.MaxMatches, config.TickRate, config.MtuBytes);
    }

    public static void Validate(BattleRuntimeConfig config)
    {
        if(config==null||config.Port is <1024 or >65535||config.MaxMatches is <1 or >1024||
           config.TickRate != 30||config.MtuBytes is <576 or >1400)
            throw new InvalidDataException("Invalid BattleServer runtime configuration.");
    }
}
