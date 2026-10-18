using System.Numerics;

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
        checks += Check(Vector3.Distance(weapon.PlaceMuzzle(Vector3.One, Vector3.UnitZ),
            Vector3.One + expected) < 0.000001f, "Forward muzzle placement lost its source attachment.");
        checks += Check(Vector3.Distance(weapon.PlaceMuzzle(Vector3.Zero, Vector3.UnitX),
            new Vector3(expected.Z, expected.Y, -expected.X)) < 0.000001f,
            "Sideways muzzle placement used the wrong planar rotation.");
        bytes[0] ^= 1;
        Reject(() => GrenadierPrimaryWeapon.Load(bytes));
        Reject(() => weapon.PlaceMuzzle(Vector3.Zero, Vector3.UnitY));
        Reject(() => weapon.PlaceMuzzle(new Vector3(float.NaN), Vector3.UnitZ));
        checks += 3;
        return checks + CheckCosmeticFlight(weapon);
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
