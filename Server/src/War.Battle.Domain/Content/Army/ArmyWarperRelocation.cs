using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record ArmyWarperRelocation(int InitialWarpCountMin,int InitialWarpCountMaxExclusive,
    int RepeatWarpCountMin,int RepeatWarpCountMaxExclusive,float EdgeInsetX,float EdgeInsetZMin,
    float EdgeInsetZMax,float EdgeShrinkZMin,float EdgeShrinkZMax,float SampleRadius,float StartSpeed,
    float AccelerationSeconds,float WarpAfterSeconds,float WarpSpeed,float ArrivalDistance,
    float ArrivalPauseSeconds,float RepeatAfterShotSeconds,string Rule,string ControllerSource,
    string ControllerSha256,IReadOnlyDictionary<string,ArmyWarperField> Fields);
