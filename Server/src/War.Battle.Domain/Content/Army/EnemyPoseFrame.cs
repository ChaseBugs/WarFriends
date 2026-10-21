using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

internal sealed record EnemyPoseFrame(float Seconds,IReadOnlyList<PlayerHitbox> Parts);
