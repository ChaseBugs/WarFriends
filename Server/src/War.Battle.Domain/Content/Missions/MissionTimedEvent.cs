using System.Collections.ObjectModel;
using System.Text.Json;

namespace War.BattleServer;

public sealed record MissionTimedEvent(
    float TimeSeconds, string Behaviour, int Level, bool IsCardUnit,
    int Count, string Card);
