using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record ArmyShotgunnerWalkingFire(float WindupSeconds,string Rule,string BehaviorSource,
    string BehaviorSha256,string ControllerSource,string ControllerSha256);
