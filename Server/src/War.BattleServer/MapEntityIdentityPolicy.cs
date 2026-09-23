using System.Text.RegularExpressions;

namespace War.BattleServer;

public readonly record struct MapEntityIdentity(string MapId, string MapRevision, int SourceIndex);

public static class MapEntityIdentityPolicy
{
    private static readonly Regex MapPattern = new(@"\A[A-Za-z0-9_-]{1,64}\z", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    private static readonly Regex RevisionPattern = new(@"\A[0-9a-f]{64}\z", RegexOptions.Compiled | RegexOptions.CultureInvariant);
    public static MapEntityIdentity Validate(MapEntityIdentity identity)
    {
        if (!MapPattern.IsMatch(identity.MapId ?? "") ||
            !RevisionPattern.IsMatch(identity.MapRevision ?? "") ||
            identity.SourceIndex <= 0 || identity.SourceIndex > 1_000_000)
            throw new InvalidDataException("Invalid map entity identity.");
        return identity;
    }
}
