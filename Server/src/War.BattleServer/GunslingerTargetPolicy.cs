namespace War.BattleServer;

/// <summary>Preserves the source Head preference and its pre-fallback random index.</summary>
internal static class GunslingerTargetPolicy
{
    internal static DroneShotTarget? SelectShotTarget(IReadOnlyList<DroneShotTarget> targets,
        Func<int, int> choose)
    {
        DroneShotTarget? head = AssaulterTargetPolicy.SelectShotTarget(targets,
            AssaulterTargetPolicy.HeadMask, choose);
        if (head != null)
        {
            return head;
        }

        // PickRandomOpponent draws the index before replacing an empty Head list.
        // Range(0, 0) yields zero; the fallback retains that index rather than redrawing.
        if (choose(0) != 0)
        {
            throw new InvalidDataException("Gunslinger empty Head draw must retain the source zero index.");
        }

        return AssaulterTargetPolicy.SelectShotTarget(targets, AssaulterTargetPolicy.AllInMask, _ => 0);
    }
}
