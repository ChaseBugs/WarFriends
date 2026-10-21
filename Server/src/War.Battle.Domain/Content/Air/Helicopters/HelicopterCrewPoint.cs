using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record HelicopterCrewPoint(int Index,int ComponentFileId,int TransformFileId,
    int RopeTransformFileId,Vector3 RestPosition,Quaternion RestRotation,Vector3 RopeRestPosition);
