namespace War.Persistence;

/// <summary>Identifies the durable account revision used to prepare a battle manifest.</summary>
public readonly record struct BattleAccountRevision(string PlayerId, long Revision);
