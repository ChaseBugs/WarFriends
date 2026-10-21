using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Recovered CardConstants.BoobyTrapDamage from the pinned 1.4.0 sheet.</summary>
internal sealed class PvpBonusBoobyTrapPolicy
{
    private readonly float maximumHealthFraction;

    private PvpBonusBoobyTrapPolicy(float maximumHealthFraction)
    {
        this.maximumHealthFraction = maximumHealthFraction;
    }

    internal static PvpBonusBoobyTrapPolicy Load(string sourcePath, string expectedSha256)
    {
        byte[] bytes = File.ReadAllBytes(sourcePath);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != expectedSha256)
            throw new InvalidDataException("Booby-trap source sheet differs from the combat release.");

        using var document = JsonDocument.Parse(bytes);
        float? fraction = null;
        int sheetsFound = 0;
        foreach (var sheet in document.RootElement.GetProperty("sheets").EnumerateArray())
        {
            if (sheet.GetProperty("type").GetString() != "Google2u.CardConstants")
                continue;
            sheetsFound++;
            foreach (var row in sheet.GetProperty("rows").EnumerateArray())
            {
                if (row.GetProperty("DBKEY").GetString() != "BoobyTrapDamage")
                    continue;
                if (fraction != null)
                    throw new InvalidDataException("Duplicate booby-trap damage row.");
                fraction = row.GetProperty("FLOATVALUE").GetSingle();
            }
        }
        if (sheetsFound != 1 || fraction != 0.15f)
            throw new InvalidDataException("Recovered booby-trap damage row changed.");
        return new PvpBonusBoobyTrapPolicy(fraction.Value);
    }

    internal float Damage(float playerMaximumHealth)
    {
        if (!float.IsFinite(playerMaximumHealth) || playerMaximumHealth <= 0)
            throw new InvalidDataException("Invalid booby-trap target maximum health.");
        float damage = maximumHealthFraction * playerMaximumHealth;
        if (!float.IsFinite(damage) || damage <= 0 || damage > 100_000_000)
            throw new InvalidDataException("Invalid booby-trap damage.");
        return damage;
    }
}
