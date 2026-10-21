using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record ArmyWeaponWindup(string UnitId,float Seconds,string Rule,string? ClipAsset,
    string? ClipSha256,float? ClipLength);
