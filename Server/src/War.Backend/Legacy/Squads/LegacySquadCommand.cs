namespace War.Backend.Legacy.Squads;

/// <summary>Validated request assertions plus one server-captured application time.</summary>
public sealed record LegacySquadCommand
{
    public required DatabaseAction Action { get; init; }

    public required int NowUnixSeconds { get; init; }

    public string? SquadId { get; init; }

    public string? TargetId { get; init; }

    public string? Message { get; init; }

    public string? Icon { get; init; }

    public bool? IsPublic { get; init; }

    public int? SkillRequirement { get; init; }

    public int? ExpectedOldRank { get; init; }
}
