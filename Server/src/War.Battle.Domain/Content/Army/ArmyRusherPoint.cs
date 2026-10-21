using System.Security.Cryptography;
using System.Text.Json;
using System.Numerics;

namespace War.BattleServer;

/// <summary>Source PlayerPoint.rusherPoints, bound to the five pinned scene digests.</summary>
public sealed record ArmyRusherPoint(int ComponentFileId,int Index,int TransformFileId,Vector3 Position);
