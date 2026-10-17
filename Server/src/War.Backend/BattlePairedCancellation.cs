using War.BattleServer;
using War.Infrastructure;
using War.Persistence;
using War.Protocol;

namespace War.Backend;

/// <summary>Accepts a captured pair's proven prestart cancellation before its allocator release.</summary>
public sealed class BattlePairedCancellation
{
    private readonly BattleManifestSnapshotStore _manifests;
    private readonly BattleTerminalAcceptance _acceptance;
    private readonly BattleMatchCancellationClient _worker;
    private readonly Uri _endpoint;

    /// <summary>Uses the same registration endpoint and frozen authority as match provisioning.</summary>
    public BattlePairedCancellation(
        BattleManifestSnapshotStore manifests,
        BattleTerminalAcceptance acceptance,
        BattleMatchCancellationClient worker,
        Uri endpoint)
    {
        _manifests = manifests;
        _acceptance = acceptance;
        _worker = worker;
        _endpoint = endpoint;
    }

    /// <summary>Never substitutes a later account pairing for the captured cancellation decision.</summary>
    public async Task<string> CancelAsync(BattlePairingResult pair, CancellationToken cancellationToken)
    {
        if (pair.Code != "already-paired" || pair.MatchId == null || pair.Players == null)
        {
            throw new InvalidDataException("Paired cancellation requires a captured allocator decision.");
        }

        byte[] frozen = await _manifests.Get(pair.MatchId, pair.Players, cancellationToken) ??
            throw new InvalidDataException("Paired cancellation has no frozen manifest yet.");
        var manifest = MatchManifest.Parse(frozen);
        var evidence = await _worker.CancelAndReadAsync(
            _endpoint, pair.MatchId, manifest.Digest(), cancellationToken);
        var terminal = TerminalOutbox.ValidatePayload(evidence.Payload, pair.MatchId, evidence.Digest);
        if (terminal.Phase != BattlePhase.Aborted || terminal.TerminalReason != "cancelled-before-start" ||
            terminal.ManifestHash != manifest.Digest() ||
            !terminal.Players.Select(player => player.PlayerId).SequenceEqual(pair.Players, StringComparer.Ordinal))
        {
            throw new InvalidDataException("Worker evidence is not this pair's prestart cancellation.");
        }

        // Acceptance persists and rereads exact terminal bytes before releasing the durable pair.
        string accepted = await _acceptance.Accept(
            pair.MatchId, evidence.Digest, evidence.Payload, cancellationToken);
        if (accepted is not ("accepted" or "already-accepted"))
        {
            throw new InvalidDataException("Cancellation terminal authority conflicts with stored evidence.");
        }

        return "cancelled";
    }
}
