namespace War.BattleServer;

/// <summary>Captures arrival and the first tick allowed by the source strict construction deadline.</summary>
internal sealed record MortarConstructionState(ulong EnteredTick, ulong FirstFireEligibleTick);
