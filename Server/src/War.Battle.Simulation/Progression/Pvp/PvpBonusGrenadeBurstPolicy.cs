using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Plans the three targets of a collected grenade box. The caller supplies
/// host-known shootables in their source registry order and the faction of
/// the original local view. Projectile flight and damage remain separate.
/// </summary>
internal sealed class PvpBonusGrenadeBurstPolicy
{
    internal static float FallbackOffsetFromUnitDraw(float unitDraw)
    {
        if (!float.IsFinite(unitDraw) || unitDraw is < 0f or > 1f)
            throw new InvalidDataException("Host grenade random draw is outside [0, 1].");
        // Unity's Random.Range(float, float) may include either endpoint.
        return -1.5f + 3f * unitDraw;
    }

    private readonly int grenadeCount;
    private readonly float targetDistance;
    private readonly PvpBonusCatalog catalog;

    internal PvpBonusGrenadeBurstPolicy(PvpBonusCatalog catalog)
    {
        ArgumentNullException.ThrowIfNull(catalog);
        this.catalog = catalog;
        grenadeCount = catalog.GrenadeCount;
        targetDistance = catalog.GrenadeTargetDistance;
    }

    internal IReadOnlyList<PvpBonusGrenadeLaunch> Plan(int sourceViewFraction,
        int recipientLevelIndex,
        Vector3 boxPosition, IReadOnlyList<PvpBonusGrenadeTarget> shootables,
        Func<float> nextFallbackOffset)
    {
        ArgumentNullException.ThrowIfNull(shootables);
        ArgumentNullException.ThrowIfNull(nextFallbackOffset);
        if (sourceViewFraction is not (1 or 2) ||
            recipientLevelIndex < 0 || recipientLevelIndex >= catalog.RankCount ||
            !Finite(boxPosition) ||
            shootables.Count > 256)
            throw new InvalidDataException("Invalid grenade-box source view.");

        var identities = new HashSet<string>(StringComparer.Ordinal);
        foreach (var target in shootables)
        {
            if (target == null || target.Id is not {Length: >= 1 and <= 64} ||
                target.Id.Any(character => !char.IsAsciiLetterOrDigit(character) &&
                    character is not ('_' or '-' or ':')) ||
                !identities.Add(target.Id) || target.Fraction is < 0 or > 2 ||
                !Finite(target.Position))
                throw new InvalidDataException("Invalid grenade-box shootable.");
        }

        // GetOpponents excludes same-faction, hidden and dead owners. Preserve
        // the supplied source order for equal distances.
        var nearest = shootables
            .Where(target => target.Fraction != sourceViewFraction &&
                target.HasMainEntityOwner &&
                target.Alive && target.Visible)
            .Select((target, order) => new {
                Target = target, Order = order,
                DistanceSquared = Vector3.DistanceSquared(boxPosition, target.Position)
            })
            .OrderBy(entry => entry.DistanceSquared)
            .ThenBy(entry => entry.Order)
            .Take(grenadeCount)
            .ToArray();

        var launches = new PvpBonusGrenadeLaunch[grenadeCount];
        int shot = 0;
        foreach (var candidate in nearest)
        {
            if (Vector3.Distance(boxPosition, candidate.Target.Position) >= targetDistance)
                continue;
            launches[shot] = new PvpBonusGrenadeLaunch(shot,
                1f + shot * 0.2f, candidate.Target.Id, candidate.Target.Position,
                DamageOverride: null);
            shot++;
        }

        // Only the source's fallback loop overrides GrenadeAmmoSetup damage.
        // Targeted grenades do not mutate the shared setup. The projectile
        // reads that setup at explosion, so a later burst can still change it.
        var fallbackDamage = catalog.GrenadeFallbackDamageForLevel(recipientLevelIndex);
        while (shot < grenadeCount)
        {
            float x = nextFallbackOffset();
            float z = nextFallbackOffset();
            if (!float.IsFinite(x) || !float.IsFinite(z) ||
                x is < -1.5f or > 1.5f || z is < -1.5f or > 1.5f)
                throw new InvalidDataException("Invalid host grenade-box fallback draw.");
            Vector3 destination = boxPosition + new Vector3(x, 0f, z);
            if (!Finite(destination))
                throw new InvalidDataException("Grenade-box fallback lies outside host geometry.");
            launches[shot] = new PvpBonusGrenadeLaunch(shot,
                1f + shot * 0.2f, null, destination, fallbackDamage);
            shot++;
        }
        return Array.AsReadOnly(launches);
    }

    private static bool Finite(Vector3 position) =>
        float.IsFinite(position.X) && float.IsFinite(position.Y) &&
        float.IsFinite(position.Z) &&
        MathF.Abs(position.X) <= 10000f && MathF.Abs(position.Y) <= 10000f &&
        MathF.Abs(position.Z) <= 10000f;
}
