using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

internal sealed record HelicopterBodyCollider(int ColliderFileId,int PartComponentFileId,
    int Layer,PlayerHitbox Hitbox);
