using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

/// <summary>
/// A measured Unity 2018 Play Mode frame. Position and rotation are local to
/// the enemy root; this is observation, not an authoritative world shot.
/// </summary>
internal sealed record CoopQueuedMuzzleSample(
    float FireClipSeconds, Vector3 LocalPosition, Quaternion LocalRotation);
