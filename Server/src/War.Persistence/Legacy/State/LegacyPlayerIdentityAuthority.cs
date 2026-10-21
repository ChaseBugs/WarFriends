namespace War.Persistence.Legacy.State;

/// <summary>Rejects damaged durable player identities before read projection or mutation.</summary>
public static class LegacyPlayerIdentityAuthority
{
    public static void Validate(LegacyPlayerDocument player)
    {
        if (!War.Shared.CanonicalGuid.IsCanonical(player.Id))
        {
            throw new InvalidDataException("Invalid stored legacy player identity.");
        }
    }
}
