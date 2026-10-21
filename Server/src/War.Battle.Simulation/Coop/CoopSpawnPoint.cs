using System.Collections.ObjectModel;
using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopSpawnPoint(
    string Collection, int Order, int ComponentFileId, string ComponentType,
    int Fraction, int GameObjectFileId, int TransformFileId, Vector3 Position)
{
    public Quaternion? SourceRotation { get; init; }
}
