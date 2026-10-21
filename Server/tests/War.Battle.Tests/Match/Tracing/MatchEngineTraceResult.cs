namespace War.Battle.Tests.Match.Tracing;

internal sealed record MatchEngineTraceResult(string Scenario, int Observations, string Sha256,
    string FinalPhase, ulong FinalTick, string TerminalReason);
