using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GroundVehicleBodyPart(int PartComponentFileId,int TransformFileId,Vector3 Position,int Layer,float Weight,
    IReadOnlyList<GroundVehicleBodyCollider> Colliders);
