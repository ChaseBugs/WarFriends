using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GroundVehiclePassengerBinding(string Role,int PointComponentFileId,
    int TransformFileId,Vector3 Position,Quaternion Rotation);
