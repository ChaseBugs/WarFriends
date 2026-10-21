using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record SniperBinding(string SourceId,int InventoryIndex,int AnimationFamily,Vector3 ShotOffset,float FirstShotWaitSeconds,
    float ScopeShowSeconds,float ZoomThresholdSeconds,float ZoomMovementThreshold,float Fov,int ScopeNumber,float Speed,float CheckDistance,
    float CriticalMultiplier,bool FriendKill,string MuzzlePath,string BulletRevision);
