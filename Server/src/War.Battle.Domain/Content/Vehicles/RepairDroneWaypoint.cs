using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record RepairDroneWaypoint(int ComponentFileId,int TransformFileId,int Index,
    Vector3 Position,float StayTime);
