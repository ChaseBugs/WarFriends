using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

using War.BattleServer;

/// <summary>Checks selected pistol fields, muzzle placement and collision-free cosmetic flight.</summary>
internal static class GrenadierPrimaryWeaponTests
{
    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "recovered-grenadier-primary-weapon.json"));
        GrenadierPrimaryWeapon weapon = GrenadierPrimaryWeapon.Load(bytes);
        int checks = Check(weapon.Speed == 5f && weapon.FakeSpeed == 7.5f && weapon.CollisionDistance == 0.35f,
            "Grenadier selected another prefab component's projectile setup.");
        var expected = new Vector3(0.3178592f, 0.18429394f, 0.051513106f);
        checks += Check(Vector3.Distance(weapon.RestMuzzle, expected) < 0.000001f,
            "The selected pistol spawn/rig chain changed.");
        bytes[0] ^= 1;
        Reject(() => GrenadierPrimaryWeapon.Load(bytes));
        checks++;
        return checks + CheckCosmeticFlight(weapon) + CheckNativeMuzzles(directory);
    }

    private static int CheckNativeMuzzles(string directory)
    {
        using JsonDocument reference = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(directory, "grenadier-corner-muzzle-unity-reference.json")));
        GrenadierCornerMuzzleCatalog catalog = GrenadierCornerMuzzleCatalog.Instance;
        int checks = 0;
        foreach (JsonElement scenario in reference.RootElement.GetProperty("scenarios").EnumerateArray())
        {
            bool isRight = scenario.GetProperty("side").GetString() == "right";
            var corner = new CardUnitInitialPoint(0, 1, "EnemyPointCorner", 1, Vector3.Zero,
                Quaternion.Identity, isRight ? -Vector3.UnitX : Vector3.UnitX, isRight);
            foreach (JsonElement round in scenario.GetProperty("rounds").EnumerateArray())
            {
                int index = (round.GetProperty("tick").GetInt32() - 22) / 11;
                JsonElement point = round.GetProperty("pose").GetProperty("position");
                var expected = new Vector3(point[0].GetSingle(), point[1].GetSingle(), point[2].GetSingle());
                checks += Check(catalog.Place(corner, Vector3.Zero, -Vector3.UnitZ, index) == expected,
                    "A source callback muzzle no longer matches the actual native pistol observation.");
                var rotatedCorner = corner with { CornerDirection = isRight ? -Vector3.UnitZ : Vector3.UnitZ };
                Vector3 placed = catalog.Place(rotatedCorner, Vector3.One, Vector3.One + Vector3.UnitX, index);
                checks += Check(Vector3.Distance(placed, Vector3.One +
                    new Vector3(-expected.Z, expected.Y, expected.X)) < 0.000001f,
                    "Corner muzzle placement lost the source facing-away rotation.");
            }

            Reject(() => catalog.Place(corner, Vector3.Zero, -Vector3.UnitZ, -1));
            Reject(() => catalog.Place(corner, Vector3.Zero, -Vector3.UnitZ, 5));
            Reject(() => catalog.Place(corner, Vector3.Zero, Vector3.Zero, 0));
            Reject(() => catalog.Place(corner, new Vector3(float.NaN), -Vector3.UnitZ, 0));
            checks += 4;
        }

        return checks + CheckNativeProvenance(directory, reference.RootElement);
    }

    private static int CheckNativeProvenance(string directory, JsonElement reference)
    {
        string server = Directory.GetParent(directory)!.FullName;
        string client = Path.Combine(Directory.GetParent(server)!.FullName, "Clients/ExportedProject");
        var paths = new Dictionary<string, string>
        {
            ["probeSha256"] = Path.Combine(server, "tools/UnityGrenadierCornerCallbackProbe.cs"),
            ["exporterSha256"] = Path.Combine(server, "tools/UnityGrenadierCornerCallbackExport.cs"),
            ["rigFactorySha256"] = Path.Combine(server, "tools/UnityCoopObstacleVolleyPoseExport.cs"),
            ["coroutineSha256"] = Path.Combine(client, "Assets/Plugins/Assembly-CSharp-firstpass/Core_BaseScript.cs"),
            ["controllerSha256"] = Path.Combine(client, "Assets/Scripts/Assembly-CSharp/SoldierAnimationController.cs"),
            ["prefabSha256"] = Path.Combine(client, "Assets/GameObject/enemy.prefab"),
            ["weaponSha256"] = Path.Combine(client, "Assets/GameObject/PistolEnemy.prefab")
        };
        int checks = 0;
        foreach (var entry in paths)
        {
            string digest = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(entry.Value)));
            checks += Check(digest == reference.GetProperty(entry.Key).GetString(),
                "Native Grenadier observation source changed: " + entry.Key);
        }

        return checks;
    }

    private static int CheckCosmeticFlight(GrenadierPrimaryWeapon weapon)
    {
        int queries = 0;
        var flight = new ArmyProjectileFlight(1, 2, Vector3.Zero, Vector3.UnitZ * 5,
            weapon.FakeSpeed, 0, (_, _, _) =>
            {
                queries++;
                throw new InvalidOperationException("A fake pistol bullet queried collision authority.");
            }, cosmeticTrail: true);
        bool collided = false;
        for (ulong tick = 1; tick <= 40; tick++)
        {
            collided |= flight.Advance(tick) != null;
        }

        return Check(!collided && queries == 0 && flight.Finished &&
            Vector3.Distance(flight.Position, Vector3.UnitZ * 10) < 0.00001f,
            "Fake pistol flight did not follow the shared doubled-distance cosmetic tween.");
    }

    private static int Check(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Invalid primary-weapon evidence was accepted.");
    }
}
