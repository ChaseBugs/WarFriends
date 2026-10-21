using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record PistolBinding(string SourceId,int InventoryIndex,int AnimationFamily,Vector3 ShotOffset,float FirstShotWaitSeconds,
    float Speed,float CheckDistance,float CriticalMultiplier,bool FriendKill,string MuzzlePath,string BulletRevision);
