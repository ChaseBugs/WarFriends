using System.Text.RegularExpressions;

namespace War.BattleServer;

public readonly record struct MapEntityIdentity(string MapId, string MapRevision, int SourceIndex);
