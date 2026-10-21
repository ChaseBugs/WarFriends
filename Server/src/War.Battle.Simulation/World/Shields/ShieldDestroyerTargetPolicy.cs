namespace War.BattleServer;

/// <summary>
/// CardShieldDestroyer samples every opposing PlayerPoint, including a point
/// whose shield is already destroyed. The source rounds a float draw to the
/// nearest index; a hit on an already destroyed shield has no new effect.
/// </summary>
internal static class ShieldDestroyerTargetPolicy
{
    internal static int? Select(IReadOnlyList<ShieldMutation> shields,
        int attackerFraction,float randomValue)
    {
        if (shields == null || shields.Count != 8 ||
            attackerFraction is not (1 or 2) ||
            !float.IsFinite(randomValue) || randomValue is <0 or >1 ||
            shields.Select(shield => shield.CoverIndex).Distinct().Count()!=shields.Count ||
            shields.Any(shield => shield.CoverIndex is <0 or >7 ||
                shield.OwnerFraction is not (1 or 2) ||
                !float.IsFinite(shield.Health) || !float.IsFinite(shield.MaxHealth) ||
                shield.Health<0 || shield.MaxHealth<=0 ||
                shield.Health>shield.MaxHealth ||
                shield.Destroyed!=(shield.Health==0)))
            throw new InvalidDataException("Invalid single-shield card authority.");

        var candidates=shields.Where(shield =>
            shield.OwnerFraction!=attackerFraction).ToArray();
        if (candidates.Length==0) return null;
        float drawnIndex=randomValue*(candidates.Length-1);
        int index=(int)Math.Round(drawnIndex,0,MidpointRounding.ToEven);
        return candidates[index].CoverIndex;
    }
}
