namespace War.Persistence.Legacy.Tutorial;

/// <summary>Source-compatible outcomes for publication and identity-bound replay.</summary>
public enum LegacyTutorialOutcome
{
    Published,
    Replayed,
    InvalidSession,
    WrongBattle,
    LegacyProofRequired
}
