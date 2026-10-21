namespace War.Persistence.Legacy.DogTags;

/// <summary>Validates the reusable durable tuple while permitting source-backed negative penalty debt.</summary>
public static class LegacyDogTagAuthority
{
    /// <summary>Refuses malformed authority without clamping valid negative penalty debt to zero.</summary>
    public static void ValidateStored(LegacyPlayerDocument player, int now)
    {
        if (now < 0 || player.DogTagMax <= 0 || player.DogTagSeconds > player.DogTagMax ||
            player.DogTagLastUpdate < 0 || player.DogTagLastUpdate > now || player.Vip < 0 || player.Gold < 0)
        {
            throw new InvalidDataException("Invalid stored dog-tag/time/wallet authority.");
        }
    }
}
