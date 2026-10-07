using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// The source Assault Helicopter has one damageable body BoxCollider.
/// Its remaining body and glass colliders are meshes and need separate geometry.
/// </summary>
internal sealed class AssaultHelicopterBoxColliderCatalog
{
    internal const int ColliderFileId = 6566439;
    private const int PartComponentFileId = 11471354;
    private readonly Vector3 center;
    private readonly Vector3 size;
    private readonly Quaternion rotation;

    private AssaultHelicopterBoxColliderCatalog(Vector3 center, Vector3 size,
        Quaternion rotation)
    {
        this.center = center;
        this.size = size;
        this.rotation = rotation;
    }

    internal static AssaultHelicopterBoxColliderCatalog Load(string path)
    {
        byte[] bytes = File.ReadAllBytes(path);
        if (bytes.Length > 500000 ||
            Convert.ToHexStringLower(SHA256.HashData(bytes)) !=
                DroneColliderCatalog.VerifiedInventoryRevision)
            throw new InvalidDataException("Assault Helicopter collision inventory differs from source.");

        using var document = JsonDocument.Parse(bytes);
        var unit = document.RootElement.GetProperty("units").EnumerateArray().Single(row =>
            row.GetProperty("unitId").GetString() == "ID_UNIT-ASSAULTHELI");
        if (unit.GetProperty("source").GetString() !=
                "Assets/GameObject/assaultHelicopter.prefab" ||
            unit.GetProperty("sha256").GetString() !=
                "3e8745b4b43f7c2e60110f34c9f8c2defc8fa65beb1bc8ac0396ccea17d04fe1" ||
            unit.GetProperty("rootTransformFileId").GetInt32() != 425385)
            throw new InvalidDataException("Assault Helicopter prefab identity changed.");

        var collider = unit.GetProperty("colliders").EnumerateArray().Single(row =>
            row.GetProperty("colliderFileId").GetInt32() == ColliderFileId);
        var part = unit.GetProperty("components").EnumerateArray().Single(row =>
            row.GetProperty("componentFileId").GetInt32() == PartComponentFileId);
        var ancestors = collider.GetProperty("ancestorTransformFileIds");
        if (collider.GetProperty("gameObjectFileId").GetInt32() != 169566 ||
            collider.GetProperty("type").GetString() != "Box" ||
            collider.GetProperty("serializedLayer").GetInt32() != 8 ||
            !collider.GetProperty("enabled").GetBoolean() ||
            collider.GetProperty("trigger").GetBoolean() ||
            !collider.GetProperty("activeAncestors").GetBoolean() ||
            ancestors.GetArrayLength() != 3 || ancestors[0].GetInt32() != 432167 ||
            ancestors[1].GetInt32() != 435975 || ancestors[2].GetInt32() != 425385 ||
            part.GetProperty("gameObjectFileId").GetInt32() != 169566 ||
            part.GetProperty("scriptType").GetString() != "DestroyableObjectpart" ||
            part.GetProperty("ownerDestroyableObject").GetInt32() != 0 ||
            part.GetProperty("weight").GetSingle() != 1f)
            throw new InvalidDataException("Assault Helicopter body box lost its damage owner.");

        Vector3 center = Vector(collider.GetProperty("restCenter"));
        Vector3 size = Vector(collider.GetProperty("localSize")) *
            Vector(collider.GetProperty("scale"));
        var sourceRotation = collider.GetProperty("restRotation");
        Quaternion rotation = new(sourceRotation[0].GetSingle(), sourceRotation[1].GetSingle(),
            sourceRotation[2].GetSingle(), sourceRotation[3].GetSingle());
        if (!PlayerHitbox.Finite(center) || !PlayerHitbox.Finite(size) ||
            size.X <= 0 || size.Y <= 0 || size.Z <= 0 || size.Length() > 10 ||
            !float.IsFinite(rotation.LengthSquared()) ||
            Math.Abs(rotation.LengthSquared() - 1) > .001f)
            throw new InvalidDataException("Assault Helicopter body box is malformed.");
        return new(center, size, Quaternion.Normalize(rotation));
    }

    internal PlayerHitbox Place(Vector3 position, Quaternion rootRotation)
    {
        if (!PlayerHitbox.Finite(position) || !float.IsFinite(rootRotation.LengthSquared()) ||
            Math.Abs(rootRotation.LengthSquared() - 1) > .001f)
            throw new InvalidDataException("Invalid Assault Helicopter collision pose.");
        Vector3 placedCenter = position + Vector3.Transform(center, rootRotation);
        Quaternion placedRotation = Quaternion.Normalize(rootRotation * rotation);
        if (!PlayerHitbox.Finite(placedCenter) ||
            !float.IsFinite(placedRotation.LengthSquared()))
            throw new InvalidDataException("Assault Helicopter collision pose overflowed.");
        return new PlayerHitbox("Assets/GameObject/assaultHelicopter.prefab#" + ColliderFileId,
            PlayerHitboxKind.Box, 1, placedCenter, size, placedRotation, 0,
            Vector3.Zero, 0, transformPosition: position);
    }

    private static Vector3 Vector(JsonElement value) =>
        new(value[0].GetSingle(), value[1].GetSingle(), value[2].GetSingle());
}
