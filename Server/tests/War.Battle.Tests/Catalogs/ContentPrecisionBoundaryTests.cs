using System.Security.Cryptography;
using System.Text.Json;
using War.Battle.Tests.Startup;
using War.BattleServer;

namespace War.Battle.Tests.Catalogs;

/// <summary>Exercises real vitality owners at synthetic boundaries affected by reviewed sheet corrections.</summary>
internal static class ContentPrecisionBoundaryTests
{
    private const int ExpectedHealthRows = 28;
    private const int ExpectedDamageRows = 358;

    internal static int Run()
    {
        string server = BackendStartupPolicyTests.FindServerDirectory();
        string path = Path.Combine(server, "docs", "battle-sheet-value-audit.json");
        using JsonDocument audit = JsonDocument.Parse(File.ReadAllBytes(path));
        JsonElement root = audit.RootElement;
        VerifyScene(server, root.GetProperty("sceneSha256").GetString());
        int healthRows = 0;
        int damageRows = 0;
        foreach (JsonElement row in root.GetProperty("differences").EnumerateArray())
        {
            if (row.GetProperty("kind").GetString() != "ObscuredFloat")
            {
                continue;
            }
            float previous = row.GetProperty("exported").GetSingle();
            float corrected = row.GetProperty("source").GetSingle();
            Require(previous > 0f && corrected > 0f && previous != corrected, "Invalid precision fixture.");
            if (row.GetProperty("field").GetString() == "HP")
            {
                VerifyHealthBoundary(previous, corrected);
                healthRows++;
            }
            else
            {
                VerifyDamageBoundary(previous, corrected);
                damageRows++;
            }
        }
        Require(healthRows == ExpectedHealthRows, "Reviewed health correction inventory changed.");
        Require(damageRows == ExpectedDamageRows, "Reviewed damage correction inventory changed.");
        return healthRows + damageRows;
    }

    private static void VerifyScene(string server, string? expected)
    {
        string scene = Path.GetFullPath(Path.Combine(server, "..", "Clients", "ExportedProject",
            "Assets", "Scenes", "MainScene.unity"));
        string actual = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(scene)));
        Require(actual == expected, "Precision fixtures refer to another source scene.");
    }

    private static void VerifyHealthBoundary(float previous, float corrected)
    {
        float damage = MathF.Min(previous, corrected);
        var previousVehicle = new VehicleHealthState(previous);
        var correctedVehicle = new VehicleHealthState(corrected);
        var previousAir = new AirEntityHealthState(previous);
        var correctedAir = new AirEntityHealthState(corrected);

        previousVehicle.ApplyDamage(damage);
        correctedVehicle.ApplyDamage(damage);
        previousAir.ApplyDamage(damage);
        correctedAir.ApplyDamage(damage);

        bool correctedDies = corrected < previous;
        Require(correctedVehicle.Destroyed == correctedDies, "Corrected vehicle health boundary differs.");
        Require(previousVehicle.Destroyed != correctedVehicle.Destroyed, "Vehicle HP correction was hidden.");
        Require(correctedAir.IsDead == correctedDies, "Corrected air health boundary differs.");
        Require(previousAir.IsDead != correctedAir.IsDead, "Air HP correction was hidden.");
        Require(correctedVehicle.Current == correctedAir.Current, "Vitality owners disagree on remaining HP.");
    }

    private static void VerifyDamageBoundary(float previous, float corrected)
    {
        float health = MathF.Max(previous, corrected);
        var previousVehicle = new VehicleHealthState(health);
        var correctedVehicle = new VehicleHealthState(health);
        var previousAir = new AirEntityHealthState(health);
        var correctedAir = new AirEntityHealthState(health);

        previousVehicle.ApplyDamage(previous);
        correctedVehicle.ApplyDamage(corrected);
        previousAir.ApplyDamage(previous);
        correctedAir.ApplyDamage(corrected);

        bool correctedKills = corrected > previous;
        Require(correctedVehicle.Destroyed == correctedKills, "Corrected vehicle damage boundary differs.");
        Require(previousVehicle.Destroyed != correctedVehicle.Destroyed, "Vehicle damage correction was hidden.");
        Require(correctedAir.IsDead == correctedKills, "Corrected air damage boundary differs.");
        Require(previousAir.IsDead != correctedAir.IsDead, "Air damage correction was hidden.");
        Require(correctedVehicle.Current == correctedAir.Current, "Vitality owners disagree on remaining damage.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
