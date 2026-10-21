using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record HelicopterCrewPose(int Slot,int PointComponentFileId,Vector3 Position,
    Quaternion Rotation,Vector3 RopePosition);
