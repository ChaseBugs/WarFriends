namespace War.Persistence.Legacy.Tutorial;

/// <summary>Closed start/end command; scores, rewards, currency and end reasons supply no authority.</summary>
public sealed class LegacyTutorialOperation
{
    private LegacyTutorialOperation(string? battleId) => BattleId = battleId;

    internal string? BattleId { get; }

    internal bool IsStart => BattleId == null;

    /// <summary>Requests the same active or completed identity, or a new identity for an unstarted account.</summary>
    public static LegacyTutorialOperation Start() => new(null);

    /// <summary>Requires the exact identity supplied by the unchanged Client end builder.</summary>
    public static LegacyTutorialOperation End(string? battleId)
    {
        if (!LegacyTutorialAuthority.IsBattleId(battleId))
        {
            throw new InvalidDataException("Invalid tutorial end identity.");
        }

        return new(battleId);
    }
}
