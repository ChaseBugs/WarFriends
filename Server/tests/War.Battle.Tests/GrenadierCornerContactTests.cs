using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using War.BattleServer;

/// <summary>Replays source floor/wall lifetimes and keeps instantiated collider identities distinct.</summary>
internal static class GrenadierCornerContactTests
{
    private const string NativeRevision = "7e767662d81f5f3a35848abe248c6df4da3ec95bcf7ca5af7ba63644c31506a9";
    private const string Floor = "CornerFloor";
    private const string Wall = "CornerWall";

    internal static int Run(string directory)
    {
        byte[] bytes = File.ReadAllBytes(Path.Combine(directory, "grenadier-corner-contact-unity-reference.json"));
        int checks = Require(Convert.ToHexStringLower(SHA256.HashData(bytes)) == NativeRevision,
            "The executed floor/wall contact evidence changed.");
        using JsonDocument document = JsonDocument.Parse(bytes);
        foreach (JsonElement row in document.RootElement.GetProperty("observations").EnumerateArray())
        {
            checks += ReplayNativeContacts(row);
        }

        checks += CheckAlternatingFlight();
        checks += CheckInstantiatedIdentities();
        return checks;
    }

    private static int ReplayNativeContacts(JsonElement row)
    {
        var clock = new GrenadierFuseClock(row.GetProperty("fuseSeconds").GetSingle());
        var tracker = new GrenadierContactTracker();
        var enteredSources = new HashSet<string>();
        JsonElement[] entries = row.GetProperty("contacts").EnumerateArray().ToArray();
        int expiry = row.GetProperty("expiryTick").GetInt32();
        for (int tick = 0; tick <= expiry; tick++)
        {
            foreach (JsonElement entry in entries.Where(entry => entry.GetProperty("tick").GetInt32() == tick))
            {
                string source = entry.GetProperty("source").GetString() ??
                    throw new InvalidDataException("Native contact source is missing.");
                enteredSources.Add(source);
                ShotCollision contact = Contact(source);
                Vector3 normal = contact.SurfaceNormal ??
                    throw new InvalidOperationException("Missing contact normal.");
                if (tracker.Enter(contact, normal))
                {
                    clock.ContactEntered();
                }
            }

            if (enteredSources.Count == 2)
            {
                ShotCollision selected = Contact(tick % 2 == 0 ? Floor : Wall);
                Vector3 normal = selected.SurfaceNormal ??
                    throw new InvalidOperationException("Missing contact normal.");
                if (tracker.Enter(selected, normal))
                {
                    clock.ContactEntered();
                }

                tracker.ReleaseSeparated(selected, Vector3.Zero, 1f,
                    (_, direction, _) => Contact(direction == Vector3.UnitX ? Wall : Floor));
                Require(tracker.Count == 2, "Alternating primary hits discarded an independently supported surface.");
            }

            Require(clock.AdvanceTick() == (tick == expiry),
                "A supported floor/wall pair spuriously restarted the recovered countdown.");
        }

        return 1;
    }

    private static int CheckAlternatingFlight()
    {
        const ulong lastEntryTick = 11;
        const ulong maximumTick = 150;
        const ulong threeSecondOffset = 90;
        ulong observedTick = 0;
        var setup = new ArmyCardGrenadierRuntime(3f, 45f, 0f, 0.9f, 1.2f, 1f, 0.4f);
        var flight = new CardGrenadierFlight(1, 1, setup, Vector3.UnitY, -Vector3.UnitY, 0,
            (_, direction, _) =>
            {
                // Controlled traces isolate contact retention; they do not assert a native map trajectory.
                if (direction == Vector3.UnitX)
                {
                    return Contact(Wall);
                }

                if (direction == -Vector3.UnitY)
                {
                    return Contact(Floor);
                }

                return Contact(observedTick >= lastEntryTick && observedTick % 2 != 0 ? Wall : Floor);
            });
        while (++observedTick <= maximumTick)
        {
            CardGrenadierExplosion? explosion = flight.Advance(observedTick);
            if (explosion != null)
            {
                return Require(flight.SupportedContactCount == 2 && flight.LastContactTick == lastEntryTick &&
                    explosion.Tick == lastEntryTick + threeSecondOffset,
                    "The actual flight must retain both surfaces and expire despite alternating primary rays.");
            }
        }

        throw new InvalidOperationException("Alternating floor/wall hits prevented the grenade from expiring.");
    }

    private static int CheckInstantiatedIdentities()
    {
        var tracker = new GrenadierContactTracker();
        var source = new ShotCollision(0, Vector3.Zero, "shared-prefab", null, 1, SourceDestroyable: true);
        ShotCollision[] colliders =
        [
            source with { ColliderIndex = 1 }, source with { ColliderIndex = 2 },
            source with { DynamicEntityId = 101 }, source with { DynamicEntityId = 102 },
            source with { PlayerId = new string('a', 32) }, source with { PlayerId = new string('b', 32) },
            source with { DynamicEntityId = 101, DynamicPartId = 1 },
            source with { DynamicEntityId = 101, DynamicPartId = 2 },
            source with { DynamicEntityId = 101, DynamicPassengerRole = "left" },
            source with { DynamicEntityId = 101, DynamicPassengerRole = "right" },
            source with { DynamicEntityId = 101, DynamicRepairDronePathIndex = 0 },
            source with { DynamicEntityId = 101, DynamicRepairDronePathIndex = 1 },
            source with { BonusBoxId = new string('c', 32) }, source with { BonusBoxId = new string('d', 32) }
        ];
        int checks = 0;
        foreach (ShotCollision collider in colliders)
        {
            bool isFirstEntry = tracker.Enter(collider, Vector3.UnitY);
            bool isRepeatedEntry = tracker.Enter(collider, Vector3.UnitY);
            checks += Require(isFirstEntry && !isRepeatedEntry,
                "Distinct instantiated colliders must enter once despite a shared source path.");
        }

        return checks + Require(tracker.Count == colliders.Length,
            "Contact authority collapsed distinct host-owned collider identities.");
    }

    private static ShotCollision Contact(string source)
    {
        return new ShotCollision(0, Vector3.Zero, source, null, 1, Static: true,
            ColliderIndex: source == Wall ? 1 : 2,
            SurfaceNormal: source == Wall ? -Vector3.UnitX : Vector3.UnitY);
    }

    private static int Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }

        return 1;
    }
}
