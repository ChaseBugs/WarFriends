using System.Numerics;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace War.BattleServer;

internal sealed record GrenadePoseFrame(float Seconds,PlayerCollisionModel Collision,RifleMuzzlePose Left,
    IReadOnlyDictionary<string,RifleMuzzlePose> Right);
