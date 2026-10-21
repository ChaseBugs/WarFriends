using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record ArmyWeaponCadence(string UnitId,float Seconds,int StrictTicks,string Rule,
    string Source,string SourceSha256);
