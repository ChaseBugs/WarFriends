using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record HelicopterTurretRestPose(int PointComponentFileId,Vector3 GunnerPosition,
    Quaternion GunnerRotation,Vector3 SightRestPosition,Quaternion SightRestRotation,
    Vector3 MuzzleRestPosition,Quaternion MuzzleRestRotation);
