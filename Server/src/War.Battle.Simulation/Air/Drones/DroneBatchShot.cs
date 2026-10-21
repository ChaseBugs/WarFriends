using System.Numerics;
namespace War.BattleServer;

public sealed record DroneBatchShot(Vector3 Target,bool IsFake,int Index,int BatchSize,bool EndsBatch);
