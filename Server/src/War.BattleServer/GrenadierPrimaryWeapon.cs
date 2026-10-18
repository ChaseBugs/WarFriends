using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>Hash-pinned pistol setup and resting rig muzzle for the recovered Grenadier.</summary>
public sealed class GrenadierPrimaryWeapon
{
    private const float ExpectedSpeed = 5f;
    private const float ExpectedFakeSpeed = 7.5f;
    private const float ExpectedCollisionDistance = 0.35f;
    private const float MinimumPlanarDirectionSquared = 1e-10f;
    private const int MinimumArtifactBytes = 100;
    private const int MaximumArtifactBytes = 32768;
    /// <summary>The digest of the complete exported primary-weapon evidence.</summary>
    public const string Revision = "c2d37997ce348808aacc46ec0a484e45ac8ed7ab696abd2c1b4d8fe162c63edf";
    private static readonly Lazy<GrenadierPrimaryWeapon> CachedInstance = new(ReadEmbedded);

    /// <summary>The verified setup shared by matches.</summary>
    public static GrenadierPrimaryWeapon Instance => CachedInstance.Value;

    /// <summary>The weapon's runtime real-bullet speed.</summary>
    public float Speed { get; }

    /// <summary>The weapon's runtime cosmetic-bullet speed.</summary>
    public float FakeSpeed { get; }

    /// <summary>The slow bullet's extra collision-ray distance.</summary>
    public float CollisionDistance { get; }

    /// <summary>The primary muzzle relative to the resting enemy rig.</summary>
    public Vector3 RestMuzzle { get; }

    private GrenadierPrimaryWeapon(JsonElement root)
    {
        Speed = root.GetProperty("runtimeSpeed").GetSingle();
        FakeSpeed = root.GetProperty("fakeSpeed").GetSingle();
        CollisionDistance = root.GetProperty("collisionCheckDistance").GetSingle();
        JsonElement position = root.GetProperty("restMuzzlePosition");
        RestMuzzle = new Vector3(position[0].GetSingle(), position[1].GetSingle(), position[2].GetSingle());
        if (Speed != ExpectedSpeed || FakeSpeed != ExpectedFakeSpeed ||
            CollisionDistance != ExpectedCollisionDistance || !PlayerHitbox.Finite(RestMuzzle))
        {
            throw new InvalidDataException("Grenadier primary setup is outside the recovered contract.");
        }
    }

    /// <summary>Places the resting muzzle using the host's planar soldier facing.</summary>
    public Vector3 PlaceMuzzle(Vector3 position, Vector3 forward)
    {
        if (!PlayerHitbox.Finite(position) || !PlayerHitbox.Finite(forward))
        {
            throw new InvalidDataException("Grenadier muzzle requires finite host pose authority.");
        }

        forward.Y = 0;
        if (forward.LengthSquared() < MinimumPlanarDirectionSquared)
        {
            throw new InvalidDataException("Grenadier muzzle requires a planar facing direction.");
        }

        float yaw = MathF.Atan2(forward.X, forward.Z);
        Vector3 placed = position + Vector3.Transform(RestMuzzle, Quaternion.CreateFromAxisAngle(Vector3.UnitY, yaw));
        if (!PlayerHitbox.Finite(placed))
        {
            throw new InvalidDataException("Grenadier muzzle placement overflowed.");
        }

        return placed;
    }

    internal static GrenadierPrimaryWeapon Load(byte[] bytes)
    {
        if (bytes.Length is < MinimumArtifactBytes or > MaximumArtifactBytes ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) != Revision)
        {
            throw new InvalidDataException("Grenadier primary source revision mismatch.");
        }

        using JsonDocument document = JsonDocument.Parse(bytes);
        return new GrenadierPrimaryWeapon(document.RootElement);
    }

    private static GrenadierPrimaryWeapon ReadEmbedded()
    {
        using Stream source = typeof(GrenadierPrimaryWeapon).Assembly
            .GetManifestResourceStream("War.BattleServer.GrenadierPrimaryWeapon") ??
            throw new InvalidDataException("Grenadier primary source setup is absent.");
        using var buffer = new MemoryStream();
        source.CopyTo(buffer);
        return Load(buffer.ToArray());
    }
}
