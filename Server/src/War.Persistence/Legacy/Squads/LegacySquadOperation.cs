namespace War.Persistence.Legacy.Squads;

/// <summary>Identifies the authenticated actor and the records needed for a squad transition.</summary>
public sealed record LegacySquadOperation(string ActorId, string? TargetId, string? SquadId);
