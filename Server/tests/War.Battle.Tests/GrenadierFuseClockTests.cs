using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Replays native countdown observations and checks contact-entry semantics in the actual flight.</summary>
internal static class GrenadierFuseClockTests
{
    private const string NativeRevision = "5fc37da2b73482423cb7927be2f9975241347d42945af0bb24a7d8a6ceba7e29";

    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "grenadier-fuse-unity-reference.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == NativeRevision,
            "The executed native contact/countdown evidence changed.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        foreach (JsonElement row in document.RootElement.GetProperty("observations").EnumerateArray())
        {
            checks += CheckNativeCountdown(row);
        }

        checks += CheckFlightContactEntries(ContactScenario.Continuous, 2);
        checks += CheckFlightContactEntries(ContactScenario.NewSurface, 10);
        checks += CheckFlightContactEntries(ContactScenario.Separation, 16);
        foreach (float invalid in new[] { float.NaN, float.PositiveInfinity, -1f, 3.1f })
        {
            try
            {
                _ = new GrenadierFuseClock(invalid);
            }
            catch (InvalidDataException)
            {
                checks++;
                continue;
            }

            throw new InvalidOperationException("A malformed source fuse entered host authority.");
        }

        return checks;
    }

    private static int CheckNativeCountdown(JsonElement row)
    {
        var clock = new GrenadierFuseClock(row.GetProperty("fuseSeconds").GetSingle());
        int[] contacts = row.GetProperty("contacts").EnumerateArray()
            .Select(contact => contact.GetProperty("tick").GetInt32()).ToArray();
        int expiry = row.GetProperty("expiryTick").GetInt32();
        for (int tick = 0; tick <= expiry; tick++)
        {
            if (contacts.Contains(tick))
            {
                clock.ContactEntered();
            }

            Require(clock.AdvanceTick() == (tick == expiry),
                "Host float countdown/reset differs from the executed recovered Update method.");
        }

        return 1;
    }

    private static int CheckFlightContactEntries(ContactScenario scenario, ulong expectedLastContact)
    {
        const ulong maximumTick = 150;
        const ulong sourceThreeSecondOffset = 90;
        var setup = new ArmyCardGrenadierRuntime(3f, 45f, 0f, 0.9f, 1.2f, 1f, 0.4f);
        ulong observedTick = 0;
        var flight = new CardGrenadierFlight(1, 1, setup, Vector3.UnitY, -Vector3.UnitY, 0,
            (_, _, _) =>
            {
                // Controlled collision traces test entry identity/separation, not trajectory or native map geometry.
                if (scenario == ContactScenario.Separation && observedTick is >= 10 and < 16)
                {
                    return null;
                }

                string surface = scenario == ContactScenario.NewSurface && observedTick >= 10 ? "wall" : "floor";
                return new ShotCollision(0, Vector3.Zero, surface, null, 1, Static: true,
                    SurfaceNormal: Vector3.UnitY);
            });
        while (++observedTick <= maximumTick)
        {
            CardGrenadierExplosion? explosion = flight.Advance(observedTick);
            if (explosion == null)
            {
                continue;
            }

            return Require(flight.FirstContactTick == 2 && flight.LastContactTick == expectedLastContact &&
                explosion.Tick == expectedLastContact + sourceThreeSecondOffset,
                "Continuous contact must not reset; separation or a new surface must rearm the source fuse.");
        }

        throw new InvalidOperationException("The controlled contact-entry flight never expired.");
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
    private enum ContactScenario
    {
        Continuous,
        NewSurface,
        Separation
    }

}
