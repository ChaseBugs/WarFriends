using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using War.Shared;

namespace War.BattleServer;

public sealed record ArmyHealthFactors(float PerkCoefficient,float UpgradeScale);
