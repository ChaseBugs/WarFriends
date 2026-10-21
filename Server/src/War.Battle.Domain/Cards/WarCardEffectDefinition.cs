namespace War.BattleServer;

public sealed record WarCardEffectDefinition(
    string CardId, WarCardEffectKind Kind, bool RequiresTarget, bool ConsumesReservation);
