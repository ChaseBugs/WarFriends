namespace War.Backend.Features.Battle.Settlement;

/// <summary>Preserves the recovered Client's binary32 multiplication and positive integer truncation.</summary>
internal static class RewardInt32
{
    internal static int Scale(int amount, float multiplier)
    {
        float scaled = amount * multiplier;
        if (amount < 0 || !float.IsFinite(multiplier) || multiplier < 0 || !float.IsFinite(scaled) ||
            scaled < 0 || (double)scaled > int.MaxValue)
        {
            throw new InvalidDataException("Battle reward exceeds the recovered Int32 domain.");
        }
        return (int)scaled;
    }
}
