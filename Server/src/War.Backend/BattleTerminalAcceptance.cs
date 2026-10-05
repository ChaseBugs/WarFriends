using War.BattleServer;
using War.Persistence;

namespace War.Backend;

/// <summary>Accepts terminal Worker evidence and releases only its proven durable queue pair.</summary>
public sealed class BattleTerminalAcceptance
{
    private readonly BattleResultStore results;
    private readonly BattleMatchQueueStore queue;
    private readonly BattleManifestSnapshotStore manifests;
    public BattleTerminalAcceptance(BattleResultStore results,BattleMatchQueueStore queue,BattleManifestSnapshotStore manifests)
    {this.results=results;this.queue=queue;this.manifests=manifests;}

    public async Task<string> Accept(string matchId,string digest,byte[] payload,CancellationToken ct)
    {
        var terminal=TerminalOutbox.ValidatePayload(payload,matchId,digest);
        BattlePairingResult? pair=null;
        if(System.Text.RegularExpressions.Regex.IsMatch(matchId,@"\Am[0-9a-f]{32}\z"))
            pair=await queue.ForMatch(matchId,ct);
        if(pair!=null)
        {
            if(!terminal.Players.Select(x=>x.PlayerId).SequenceEqual(pair.Players!,StringComparer.Ordinal))
                throw new InvalidDataException("Terminal player roster differs from durable pair.");
            byte[] frozen=await manifests.Get(matchId,pair.Players!,ct)??
                throw new InvalidDataException("Paired match has no frozen manifest.");
            var manifest=MatchManifest.Parse(frozen);
            if(manifest.MatchId!=matchId || manifest.Digest()!=terminal.ManifestHash ||
               !manifest.Players.Select(x=>x.PlayerId).SequenceEqual(pair.Players!,StringComparer.Ordinal))
                throw new InvalidDataException("Terminal proof differs from frozen match authority.");
        }
        string code=await results.Accept(matchId,digest,payload,ct);
        if(code!="conflict")
        {
            var stored=await results.Get(matchId,ct);
            if(stored==null || stored.Digest!=digest || !stored.Snapshot.AsSpan().SequenceEqual(payload))
                throw new InvalidDataException("Persisted terminal evidence differs from the validated Worker payload.");
            if(pair!=null)_=await queue.Release(matchId,pair.Players!,ct);
        }
        return code;
    }
}
