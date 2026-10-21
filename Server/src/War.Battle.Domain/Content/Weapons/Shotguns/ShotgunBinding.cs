using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

internal sealed record ShotgunBinding(string SourceId,int InventoryIndex,string MuzzlePath,
    Vector3 ReferenceMuzzlePosition,Vector3 ShotOffset,float Speed,float FakeSpeed,float CheckDistance,float CriticalMultiplier,
    float HitForceMax,bool FriendKill,int AnimationFamily,ShotgunRule Geometry)
{
    internal ShotgunRule Rule(ShotgunStage stage) => Geometry with {MinDamage=stage.MinDamage,MaxDamage=stage.MaxDamage};
}
