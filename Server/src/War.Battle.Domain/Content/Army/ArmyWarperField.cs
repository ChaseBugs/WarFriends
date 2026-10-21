using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record ArmyWarperField(string Source,string Sha256,int ColliderFileId,Vector3 Minimum,Vector3 Maximum);
