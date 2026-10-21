using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyAgentConfig(string PrefabSha256,float Radius,float Acceleration,
    float AngularSpeed,float Height,float StoppingDistance,bool AutoBraking,bool AutoRepath,
    int ObstacleAvoidanceType);
