using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

internal sealed record EnemyPoseClip(string Name,float Length,string Wrap,IReadOnlyList<EnemyPoseFrame> Frames);
