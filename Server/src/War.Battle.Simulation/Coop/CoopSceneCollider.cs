using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopSceneCollider(
    int ComponentFileId, string ComponentType, int GameObjectFileId,
    int TransformFileId, string GameObjectName, int Layer,
    bool Active, bool ActiveInHierarchy, bool Enabled, bool Trigger,
    IReadOnlyList<CoopColliderTransform> TransformChain,
    Vector3 WorldPosition, Quaternion WorldRotation, CoopColliderShape Shape);
