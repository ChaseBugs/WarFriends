using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

internal sealed record AssaultHelicopterGlassMesh(int ColliderFileId,
    int PartComponentFileId, PlayerHitbox Hitbox);
