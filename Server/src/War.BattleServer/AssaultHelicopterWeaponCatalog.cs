using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// The two AutomaticRifle spawn transforms in the recovered assaultHelicopter prefab.
/// The air inventory is already pinned by the combat package revision.
/// </summary>
internal sealed class AssaultHelicopterWeaponCatalog
{
    private const string PrefabSha256 =
        "3e8745b4b43f7c2e60110f34c9f8c2defc8fa65beb1bc8ac0396ccea17d04fe1";

    private static readonly Vector3[] SourceOffsets =
    [
        new(.3287352f, -.24099445f, .04579982f),
        new(-.31855813f, -.24099472f, .045799464f)
    ];

    private AssaultHelicopterWeaponCatalog() { }

    internal static AssaultHelicopterWeaponCatalog Load(string inventoryPath)
    {
        byte[] bytes = File.ReadAllBytes(inventoryPath);
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) !=
            DroneColliderCatalog.VerifiedInventoryRevision)
            throw new InvalidDataException("Assault Helicopter weapon inventory revision changed.");

        using var document = JsonDocument.Parse(bytes);
        var unit = document.RootElement.GetProperty("units").EnumerateArray()
            .Single(row => row.GetProperty("unitId").GetString() == "ID_UNIT-ASSAULTHELI");
        if (unit.GetProperty("sha256").GetString() != PrefabSha256 ||
            unit.GetProperty("rootTransformFileId").GetInt32() != 425385)
            throw new InvalidDataException("Assault Helicopter weapon prefab identity changed.");

        ValidateGun(unit, 0, 11457662, 11487779, 159786, 419666, 417540);
        ValidateGun(unit, 1, 11490945, 11468464, 172700, 400539, 410883);
        return new AssaultHelicopterWeaponCatalog();
    }

    internal Vector3 Muzzle(int gunIndex, Vector3 rootPosition, Quaternion rootRotation)
    {
        if (gunIndex is < 0 or > 1 || !PlayerHitbox.Finite(rootPosition) ||
            !float.IsFinite(rootRotation.LengthSquared()) ||
            Math.Abs(rootRotation.LengthSquared() - 1f) > .001f)
            throw new InvalidDataException("Invalid Assault Helicopter gun pose.");

        Vector3 muzzle = rootPosition + Vector3.Transform(SourceOffsets[gunIndex], rootRotation);
        if (!PlayerHitbox.Finite(muzzle))
            throw new InvalidDataException("Assault Helicopter muzzle escaped scene bounds.");
        return muzzle;
    }

    private static void ValidateGun(JsonElement unit, int index, int batchId,
        int rifleId, int gameObjectId, int gunTransformId, int muzzleTransformId)
    {
        var components = unit.GetProperty("components").EnumerateArray().ToArray();
        CheckComponent(components, batchId, gameObjectId, "BatchedWeapon");
        CheckComponent(components, rifleId, gameObjectId, "AutomaticRifle");

        var hierarchy = unit.GetProperty("hierarchy").EnumerateArray().ToArray();
        var gun = hierarchy.Single(row =>
            row.GetProperty("transformFileId").GetInt32() == gunTransformId);
        var muzzle = hierarchy.Single(row =>
            row.GetProperty("transformFileId").GetInt32() == muzzleTransformId);
        if (gun.GetProperty("gameObjectFileId").GetInt32() != gameObjectId ||
            gun.GetProperty("parentTransformFileId").GetInt32() != 425385 ||
            muzzle.GetProperty("parentTransformFileId").GetInt32() != gunTransformId ||
            !ReadVector(muzzle.GetProperty("localPosition")).Equals(Vector3.Zero) ||
            Vector3.Distance(ReadVector(gun.GetProperty("localPosition")),
                SourceOffsets[index]) > .000001f)
            throw new InvalidDataException("Assault Helicopter gun hierarchy changed.");
    }

    private static void CheckComponent(JsonElement[] components, int componentId,
        int gameObjectId, string scriptType)
    {
        var component = components.Single(row =>
            row.GetProperty("componentFileId").GetInt32() == componentId);
        if (component.GetProperty("gameObjectFileId").GetInt32() != gameObjectId ||
            component.GetProperty("scriptType").GetString() != scriptType)
            throw new InvalidDataException("Assault Helicopter gun component changed.");
    }

    private static Vector3 ReadVector(JsonElement value)
    {
        if (value.GetArrayLength() != 3)
            throw new InvalidDataException("Invalid Assault Helicopter gun position.");
        var result = new Vector3(value[0].GetSingle(), value[1].GetSingle(),
            value[2].GetSingle());
        if (!PlayerHitbox.Finite(result))
            throw new InvalidDataException("Nonfinite Assault Helicopter gun position.");
        return result;
    }
}
