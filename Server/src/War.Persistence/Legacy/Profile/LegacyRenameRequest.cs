namespace War.Persistence.Legacy.Profile;

/// <summary>Exact name and paid-rename consent, with no client price or reward authority.</summary>
public sealed record LegacyRenameRequest(string Name, bool PayForRename)
{
    /// <summary>Revalidates the name at the reusable mutation boundary without normalizing it.</summary>
    public void Validate()
    {
        if (!LegacyProfileValues.IsName(Name))
        {
            throw new InvalidDataException("Invalid legacy rename name.");
        }
    }
}
