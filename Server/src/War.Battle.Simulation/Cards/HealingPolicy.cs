namespace War.BattleServer;

public static class HealingPolicy
{
    public static float Apply(float current,float maximum,float amount)
    {
        if(!float.IsFinite(current)||!float.IsFinite(maximum)||!float.IsFinite(amount)||maximum<=0||current<0||current>maximum||amount<=0||amount>maximum)
            throw new InvalidDataException("Invalid healing authority.");
        return MathF.Min(maximum,current+amount);
    }
}
