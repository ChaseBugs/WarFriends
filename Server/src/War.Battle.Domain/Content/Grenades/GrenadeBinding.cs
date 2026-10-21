using System.Numerics;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

public sealed record GrenadeBinding(string SourceId,int InventoryIndex,int AnimationFamily,bool Swipe,float FirstShotWaitSeconds,
    Vector3 ShootOffset,string MuzzlePath,float Angle,float ThrowDistance,float FuseSeconds,float BehindShieldRatio,
    Vector3 ExplosionCoefficient,float AdditionalUpForce,RecoveredGrenadeEffect Effect,GrenadeSwipeBinding? SwipeInput,string BulletRevision);
