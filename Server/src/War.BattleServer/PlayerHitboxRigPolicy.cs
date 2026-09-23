namespace War.BattleServer;

public static class PlayerHitboxRigPolicy
{
    public static IReadOnlyList<PlayerHitbox> Validate(IEnumerable<PlayerHitbox> hitboxes)
    {
        if (hitboxes is null) throw new InvalidDataException("Missing player hitbox rig.");
        var result = hitboxes.ToArray();
        if (result.Length is < 1 or > 128 || result.Any(x => x is null) ||
            result.Select(x => x.SourcePath).Distinct(StringComparer.Ordinal).Count() != result.Length ||
            !result.Any(x => x.Enabled && x.Active))
            throw new InvalidDataException("Invalid player hitbox rig.");
        return Array.AsReadOnly(result);
    }
}
