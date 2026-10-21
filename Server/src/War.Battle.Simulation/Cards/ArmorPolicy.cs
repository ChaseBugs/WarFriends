namespace War.BattleServer;

public static class ArmorPolicy
{
    public static float Mitigate(float damage,float reduction)
    {
        if(!float.IsFinite(damage)||damage<=0||damage>10_000_000||!float.IsFinite(reduction)||reduction<0||reduction>0.95f)
            throw new InvalidDataException("Invalid armor mitigation.");
        return damage*(1f-reduction);
    }
}
