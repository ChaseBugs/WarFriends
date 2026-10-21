namespace War.BattleServer;

public sealed record WarArenaSnapshot(string EventId,string PlayerId,int Wins,int Lives,bool Flawless,ulong Revision);
