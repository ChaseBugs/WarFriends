namespace War.BattleServer;

public static class SnapshotTickPolicy
{
    public static void Validate(ulong previousTick, ulong nextTick, ulong maxGap = 120)
    {
        if (maxGap is < 1 or > 600 || nextTick <= previousTick || nextTick - previousTick > maxGap)
            throw new InvalidDataException("Snapshot tick sequence is invalid.");
    }
}
