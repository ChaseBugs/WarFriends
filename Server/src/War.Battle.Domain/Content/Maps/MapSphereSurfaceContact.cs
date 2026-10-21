using System.Numerics;
namespace War.BattleServer;

internal sealed record MapSphereSurfaceContact(int ColliderIndex,string SourcePath,int Layer,
    Vector3 SurfacePoint,Vector3 Normal,float Separation);
