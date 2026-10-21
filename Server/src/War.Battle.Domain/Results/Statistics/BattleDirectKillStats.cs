namespace War.BattleServer;

/// <summary>Read-only source-shaped candidates from confirmed player-owned army deaths.</summary>
public sealed record BattleDirectKillStats(string PlayerId,int DirectBulletKills,
    int DirectBulletVehiclesDestroyed,int DirectBulletTanksDestroyed,int DirectGrenadeKills,
    int DirectGrenadeVehiclesDestroyed,int DirectGrenadeTanksDestroyed,
    int DirectMineKills,int DirectMineVehiclesDestroyed,int DirectMineTanksDestroyed,
    int DirectBazookaKills,int DirectBazookaVehiclesDestroyed,int DirectBazookaTanksDestroyed);
