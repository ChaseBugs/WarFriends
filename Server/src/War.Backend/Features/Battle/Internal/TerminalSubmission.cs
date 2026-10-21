namespace War.Backend.Features.Battle.Internal;

internal sealed record TerminalSubmission(string MatchId, string Digest, byte[] Snapshot);
