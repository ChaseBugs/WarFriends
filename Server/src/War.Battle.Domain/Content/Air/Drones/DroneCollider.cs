using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
namespace War.BattleServer;

public sealed record DroneCollider(int ComponentFileId,int SerializedLayer,bool RootOwned,PlayerHitbox Hitbox);
