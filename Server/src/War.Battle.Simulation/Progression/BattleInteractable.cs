namespace War.BattleServer;

public sealed record BattleInteractable(int EntityId, BattleObjectiveKind ObjectiveKind, int RequiredAmount);
