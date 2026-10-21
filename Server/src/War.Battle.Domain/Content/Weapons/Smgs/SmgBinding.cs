using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record SmgBinding(string SourceId,int InventoryIndex,int AnimationFamily,Vector3 ShotOffset,
    int BurstSize,float SerializedBurstLockSeconds,float FirstShotWaitSeconds,float Speed,float CheckDistance,
    float CriticalMultiplier,bool FriendKill,string MuzzlePath,string BulletRevision);
