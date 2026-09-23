using System.Text.RegularExpressions;

namespace War.BattleServer;

/// <summary>Admission boundary for allocator-supplied loadouts. Client-provided
/// identity lists are assertions and must be resolved against trusted catalogs.</summary>
public static class BattleLoadoutPolicy
{
    private static readonly Regex IdPattern = new(@"\A[A-Za-z0-9_.-]{1,64}\z", RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public static IReadOnlyList<string> ValidateWeaponIds(IEnumerable<string> ids, IReadOnlySet<string> catalog)
        => Validate(ids, catalog, 1, 8, "weapon");

    public static IReadOnlyList<string> ValidateArmyUnitIds(IEnumerable<string> ids, IReadOnlySet<string> catalog)
        => Validate(ids, catalog, 0, 24, "army unit");

    public static IReadOnlyList<string> ValidateCardIds(IEnumerable<string> ids, IReadOnlySet<string> catalog)
        => Validate(ids, catalog, 0, 32, "card");

    private static IReadOnlyList<string> Validate(IEnumerable<string> ids, IReadOnlySet<string> catalog,
        int minimum, int maximum, string kind)
    {
        if (ids is null || catalog is null) throw new InvalidDataException("Missing loadout catalog.");
        var result = ids.ToArray();
        if (result.Length < minimum || result.Length > maximum || result.Any(x => x is null || !IdPattern.IsMatch(x)) ||
            result.Distinct(StringComparer.Ordinal).Count() != result.Length || result.Any(x => !catalog.Contains(x)))
            throw new InvalidDataException($"Invalid {kind} loadout.");
        return Array.AsReadOnly(result);
    }
}
