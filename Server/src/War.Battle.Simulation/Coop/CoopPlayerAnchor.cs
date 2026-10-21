using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopPlayerAnchor(
    int Index, int ComponentFileId, int GameObjectFileId,
    int TransformFileId, bool Main, Vector3 Position)
{
    public Quaternion? SourceRotation { get; init; }
}
