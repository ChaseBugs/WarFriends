using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

internal sealed record CoopMuzzlePose(Vector3 Position, Quaternion Rotation);
