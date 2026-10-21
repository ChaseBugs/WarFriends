namespace War.BattleServer;

public sealed record ArmyDeploymentUsage(int OptionIndex,string UnitId,int Deployments,
    int PlannedSpawns,int ConfirmedSpawns);
