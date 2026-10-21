using System.Security.Cryptography;
using System.Numerics;
using System.Text.Json;

namespace War.BattleServer;

public sealed record ArmyDeploymentOption(int Index,int Count,int Power,float Cooldown);
