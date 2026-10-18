using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;
using War.Backend.Legacy;

namespace War.Backend;

/// <summary>Evaluates recovered weapon availability without changing durable purchase flags.</summary>
public static class BattleWeaponOwnership
{
    private const int WeaponCount = 66;
    private const int MaximumRankIndex = 42;
    private const string ResourceName = "War.Backend.RecoveredStarterObservation";
    private const string ReviewedSha256 = "7e4d56b6dbbfdc832fe65c1a3320c15d4b9c7b80750d7e6ba36f4d45ccb923c5";
    private static readonly IReadOnlyDictionary<string, Rule> Rules = LoadRules();

    /// <summary>Checks the complete reviewed rule set before serving battle requests.</summary>
    public static void Validate()
    {
        if (Rules.Count != WeaponCount)
        {
            throw new InvalidDataException("The recovered weapon ownership rules are incomplete.");
        }
    }

    /// <summary>Uses authoritative mode, rank and saved flags to reproduce WeaponLevelsSetup.bought.</summary>
    public static bool IsAvailable(string sourceId, SavedWeaponSlots saved, WeaponOwnershipContext context)
    {
        if (saved == null || context == null || context.RankIndex < 0 || context.RankIndex > MaximumRankIndex ||
            string.IsNullOrEmpty(sourceId) || !Rules.TryGetValue(sourceId, out Rule? rule))
        {
            throw new InvalidDataException("Invalid battle weapon ownership input.");
        }

        // Tutorial weapons bypass prices outside tutorial; inside tutorial even borrowing does not bypass bought.
        if (rule.IsTutorialWeapon)
        {
            return !context.IsTutorial || saved.Bought;
        }

        bool hasPurchasedAccess = saved.Bought && context.RankIndex >= rule.MinimumPurchaseRankIndex;
        return rule.HasFreeAccess || hasPurchasedAccess || saved.Borrowed;
    }

    private static IReadOnlyDictionary<string, Rule> LoadRules()
    {
        using Stream input = typeof(BattleWeaponOwnership).Assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidDataException("The reviewed weapon ownership resource is missing.");
        using var buffer = new MemoryStream();
        input.CopyTo(buffer);
        byte[] bytes = buffer.ToArray();
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
        {
            throw new InvalidDataException("The weapon ownership reference differs from the reviewed Client.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement weapons = document.RootElement.GetProperty("weapons");
        if (weapons.GetArrayLength() != WeaponCount)
        {
            throw new InvalidDataException("The weapon ownership reference is incomplete.");
        }

        var rules = new Dictionary<string, Rule>(StringComparer.Ordinal);
        foreach (JsonElement weapon in weapons.EnumerateArray())
        {
            string sourceId = weapon.GetProperty("sourceId").GetString() ?? "";
            bool hasFreeAccess = weapon.GetProperty("isShopWeapon").GetBoolean() &&
                weapon.GetProperty("unlockRankIndex").GetInt32() == 0 &&
                weapon.GetProperty("price").GetInt32() == 0 && weapon.GetProperty("goldPrice").GetInt32() == 0;
            if (!BattleClientWeaponIndices.IsKnownSource(sourceId) || !rules.TryAdd(sourceId, new Rule(
                weapon.GetProperty("isTutorialWeapon").GetBoolean(), hasFreeAccess,
                weapon.GetProperty("minimumPurchaseRankIndex").GetInt32())))
            {
                throw new InvalidDataException("An ownership rule has an unknown or duplicate weapon identity.");
            }
        }

        return new ReadOnlyDictionary<string, Rule>(rules);
    }

    private sealed record Rule(bool IsTutorialWeapon, bool HasFreeAccess, int MinimumPurchaseRankIndex);
}
