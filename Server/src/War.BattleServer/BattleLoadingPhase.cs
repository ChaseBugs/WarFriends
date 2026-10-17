namespace War.BattleServer;

/// <summary>Describes readiness before gameplay, including server deadline expiry.</summary>
public enum BattleLoadingPhase
{
    Waiting,
    Started,
    Cancelled,
    TimedOut
}
