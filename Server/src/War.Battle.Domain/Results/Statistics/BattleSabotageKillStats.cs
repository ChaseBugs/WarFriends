using War.Protocol;

namespace War.BattleServer;

/// <summary>
/// Read-only Client skill-shot candidates from host-confirmed Sabotage deaths.
/// These counts do not grant rewards or replace the full Client statistics.
/// </summary>
public sealed record BattleSabotageKillStats(string PlayerId, int Kills,
    int OneHitKills, int VehiclesDestroyed, int TanksDestroyed);
