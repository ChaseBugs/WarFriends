using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public interface IBurstStage { int BurstSize{get;} float CadenceSeconds{get;} float BurstLockSeconds{get;} }
