using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// The source box's root scale and BoxCollider size form a 0.4834973-unit
/// cube. DestroyableObject.Awake changes the prefab's serialized Default
/// layer to the source destroyable-entity layer (8) at runtime.
/// It can be shot while falling or grounded.
/// The source root rotation permutes cube axes, so its world box has the same
/// dimensions as this axis-aligned host collider.
/// </summary>
internal static class PvpBonusShotHitbox
{
    internal const int RuntimeLayer = 8;
    private const float Side = 0.4834973f;
    private const string SourcePath =
        "Assets/GameObject/KillStreakBonusBox.prefab#6584216";

    internal static PlayerHitbox For(PvpBonusBoxSnapshot box)
    {
        ArgumentNullException.ThrowIfNull(box);
        if (box.Phase == PvpBonusBoxPhase.Collected ||
            !PlayerHitbox.Finite(box.Position))
            throw new InvalidDataException("Collected or invalid bonus box is not shootable.");

        return new PlayerHitbox(SourcePath, PlayerHitboxKind.Box, 1f,
            box.Position, new Vector3(Side), Quaternion.Identity, 0f,
            Vector3.Zero, 0f);
    }
}
