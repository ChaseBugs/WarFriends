using System.Numerics;

namespace War.BattleServer;

internal sealed record CardGrenadesBurstPlan(
    string RequestId, string OwnerPlayerId, int OwnerLevel, Vector3 FireOrigin,
    IReadOnlyList<PvpBonusGrenadeLaunch> Launches);

/// <summary>
/// The recovered CardGrenadesBurst coroutine chooses random opponents first.
/// Remaining shots choose distinct, empty enemy shield points. The host gives
/// this planner its live target roster and source-bound shield positions.
/// </summary>
internal sealed class CardGrenadesBurstPolicy(PvpBonusCatalog catalog)
{
    internal CardGrenadesBurstPlan Plan(
        string requestId, string ownerPlayerId, int ownerFraction,
        int ownerLevel, Vector3 fireOrigin,
        IReadOnlyList<PvpBonusGrenadeTarget> shootables,
        IReadOnlyList<Vector3> emptyEnemyShieldPositions,
        Func<int, int> randomIndex)
    {
        ArgumentNullException.ThrowIfNull(shootables);
        ArgumentNullException.ThrowIfNull(emptyEnemyShieldPositions);
        ArgumentNullException.ThrowIfNull(randomIndex);
        if (!Guid.TryParseExact(requestId, "N", out _) ||
            requestId != requestId.ToLowerInvariant() ||
            !Guid.TryParseExact(ownerPlayerId, "N", out _) ||
            ownerPlayerId != ownerPlayerId.ToLowerInvariant() ||
            ownerFraction is not (1 or 2) ||
            ownerLevel < 0 || ownerLevel >= catalog.RankCount ||
            !Finite(fireOrigin) || shootables.Count > 256 ||
            emptyEnemyShieldPositions.Count > 8 ||
            emptyEnemyShieldPositions.Any(position => !Finite(position)))
            throw new InvalidDataException("Invalid source CardGrenadesBurst authority.");

        var targetIds = new HashSet<string>(StringComparer.Ordinal);
        foreach (var target in shootables)
        {
            if (target == null || target.Id is not {Length: >= 1 and <= 64} ||
                target.Id.Any(character => !char.IsAsciiLetterOrDigit(character) &&
                    character is not ('_' or '-' or ':')) ||
                !targetIds.Add(target.Id) || target.Fraction is < 0 or > 2 ||
                !Finite(target.Position))
                throw new InvalidDataException("CardGrenadesBurst has an invalid target roster.");
        }
        var opponents = shootables.Where(target =>
            target.Fraction != ownerFraction &&
            target.HasMainEntityOwner && target.Alive && target.Visible)
            .ToArray();

        var launches = new PvpBonusGrenadeLaunch[3];
        var chosenIndexes = new List<int>(3);
        int targetCount = Math.Min(3, opponents.Length);
        for (int shot = 0; shot < targetCount; shot++)
        {
            int selected = DrawIndex(randomIndex, opponents.Length - shot);
            // Preserve CardGrenadesBurst's duplicate-index repair, including
            // its dependence on the earlier draw order.
            for (int previous = 0; previous < chosenIndexes.Count; previous++)
            {
                if (chosenIndexes[previous] == selected)
                    selected = opponents.Length - previous - 1;
            }
            chosenIndexes.Add(selected);
            var target = opponents[selected];
            launches[shot] = new(shot, (shot + 1) * 0.2f,
                target.Id, target.Position, null);
        }

        var shieldPositions = emptyEnemyShieldPositions.ToList();
        if (shieldPositions.Count < 3 - targetCount)
            throw new InvalidDataException("CardGrenadesBurst lacks empty enemy shields.");
        var fallbackDamage = catalog.GrenadeFallbackDamageForLevel(ownerLevel);
        for (int shot = targetCount; shot < 3; shot++)
        {
            int selected = DrawIndex(randomIndex, shieldPositions.Count);
            Vector3 target = shieldPositions[selected];
            launches[shot] = new(shot, (shot + 1) * 0.2f,
                null, target, fallbackDamage);
            shieldPositions[selected] = shieldPositions[^1];
            shieldPositions.RemoveAt(shieldPositions.Count - 1);
        }

        return new CardGrenadesBurstPlan(requestId, ownerPlayerId, ownerLevel,
            fireOrigin, Array.AsReadOnly(launches));
    }

    private static int DrawIndex(Func<int, int> randomIndex, int exclusiveMaximum)
    {
        int selected = randomIndex(exclusiveMaximum);
        if (selected < 0 || selected >= exclusiveMaximum)
            throw new InvalidDataException("CardGrenadesBurst random draw is invalid.");
        return selected;
    }

    private static bool Finite(Vector3 position) =>
        float.IsFinite(position.X) && float.IsFinite(position.Y) &&
        float.IsFinite(position.Z) &&
        Math.Abs(position.X) <= 10_000f &&
        Math.Abs(position.Y) <= 10_000f &&
        Math.Abs(position.Z) <= 10_000f;
}
