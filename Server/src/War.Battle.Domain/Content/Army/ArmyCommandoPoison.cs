using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record ArmyCommandoPoison(float DurationSeconds,float PulseIntervalSeconds,int PulseCount,
    string Rule,string ConstantsSheet,int ConstantsRow,string BehaviorSource,string BehaviorSha256,
    string BulletSource,string BulletSha256);
