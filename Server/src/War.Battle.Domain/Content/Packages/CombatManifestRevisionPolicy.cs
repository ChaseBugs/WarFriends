namespace War.BattleServer;

public static class CombatManifestRevisionPolicy
{
    public static string ResolveMortarPool(int version, string? revision)
    {
        return ResolveRevision(version, revision, MortarWeaponPoolSource.VerifiedRevision);
    }

    public static string ResolveAssaulterWeapon(int version, string? revision)
    {
        return ResolveRevision(version, revision, CoopAssaulterWeaponCatalog.LegacyArtifactRevision);
    }

    private static string ResolveRevision(int version, string? revision, string legacyRevision)
    {
        if (version == 13 && revision is null)
        {
            return legacyRevision;
        }

        if (version == 14 && revision is { Length: 64 } &&
            revision.All(char.IsAsciiHexDigitLower))
        {
            return revision;
        }

        throw new InvalidDataException("Invalid combat manifest version or explicit artifact revision.");
    }
}
