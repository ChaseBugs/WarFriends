namespace War.BattleServer;

/// <summary>
/// CardMassShieldDestroyer chooses up to three living enemy shields. Unity
/// removes each selected point from its candidate list before the next draw.
/// The draw callback is owned by the match host, never by the card packet.
/// </summary>
internal static class MassShieldDestroyerTargetPolicy
{
    internal const int MaximumTargets = 3;

    internal static IReadOnlyList<int> Select(IReadOnlyList<ShieldMutation> shields,
        int attackerFraction,Func<int,int> draw)
    {
        if (shields == null || draw == null || attackerFraction is not (1 or 2) ||
            shields.Count != 8 ||
            shields.Select(shield => shield.CoverIndex).Distinct().Count()!=shields.Count ||
            shields.Any(shield => shield.CoverIndex is <0 or >7 ||
                shield.OwnerFraction is not (1 or 2) ||
                !float.IsFinite(shield.Health) || !float.IsFinite(shield.MaxHealth) ||
                shield.Health<0 || shield.MaxHealth<=0 ||
                shield.Health>shield.MaxHealth ||
                shield.Destroyed!=(shield.Health==0)))
            throw new InvalidDataException("Invalid shield-destroy card authority.");

        var candidates=shields.Where(shield =>
            shield.OwnerFraction!=attackerFraction && !shield.Destroyed)
            .Select(shield => shield.CoverIndex).ToList();
        var selected=new List<int>();
        while (candidates.Count>0 && selected.Count<MaximumTargets)
        {
            int index=draw(candidates.Count);
            if (index<0 || index>=candidates.Count)
                throw new InvalidDataException("Invalid shield-destroy host draw.");
            selected.Add(candidates[index]);
            candidates.RemoveAt(index);
        }
        return selected.AsReadOnly();
    }
}
