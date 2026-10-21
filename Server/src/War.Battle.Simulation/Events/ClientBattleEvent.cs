using System.Numerics;

namespace War.BattleServer;

public sealed record ClientBattleEvent(ulong Sequence,string Kind,ulong EntityId,Vector3 Position);
