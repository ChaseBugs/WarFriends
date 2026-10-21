namespace War.BattleServer;

public static class ReliableEventRetentionPolicy
{
    public static void Validate(ulong firstRetained, ulong lastPublished, ulong acknowledged, ulong capacity = 4096)
    {
        if (capacity is < 1 or > 65_536 || lastPublished < firstRetained ||
            acknowledged > lastPublished || lastPublished - firstRetained + 1 > capacity)
            throw new InvalidDataException("Invalid reliable-event retention window.");
        if (acknowledged + 1 < firstRetained && acknowledged != 0)
            throw new InvalidDataException("Acknowledgement is outside retained event history.");
    }
}
