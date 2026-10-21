using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GrenadeSwipeBinding(float MaxDistance,float MaxDistanceShot,float MaxThrowTime,float MinDistance,
    float MinDistanceShot,float MinThrowTime,float ThrowFactor,float DistanceThreshold,string LeftMuzzlePath,string RightMuzzlePath);
