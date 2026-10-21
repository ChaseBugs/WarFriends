using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record RifleBinding(string SourceId, int InventoryIndex, string MuzzlePath,
    Vector3 ReferenceMuzzlePosition, Vector3 ShotOffset, float Speed, float CheckDistance,
    float CriticalMultiplier, bool FriendKill,int AnimationFamily);
