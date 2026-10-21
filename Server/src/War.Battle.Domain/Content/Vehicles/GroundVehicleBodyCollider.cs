using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GroundVehicleBodyCollider(int ColliderFileId,PlayerHitboxKind Kind,
    Vector3 Center,Quaternion Rotation,Vector3 Size,float Radius,Vector3 Axis,float HalfSegment,bool Trigger);
