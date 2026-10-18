using System.Text.Json;
using System.Text.Json.Nodes;
using War.Persistence;
using War.Shared;

namespace War.Backend;

/// <summary>Fills only allocator-owned identities/projections into an operator-reviewed source-valid manifest template.</summary>
public sealed partial class BattleManifestFactory
{
    private readonly JsonObject template;
    private readonly BattleAllocationStore allocations;
    private readonly BattlePlayerPresentationSource presentations;
    private readonly IBattleWeaponManifestCatalog weapons;
    public BattleManifestFactory(byte[] templateBytes,BattleAllocationStore allocations,BattlePlayerPresentationSource presentations,
        IBattleWeaponManifestCatalog weapons)
    {
        if(templateBytes is not {Length:>1 and <=65536})throw new InvalidDataException("Invalid battle manifest template size.");
        try {template=JsonNode.Parse(templateBytes)?.AsObject()??throw new InvalidDataException("Null battle manifest template.");}
        catch(JsonException e){throw new InvalidDataException("Invalid battle manifest template JSON.",e);}
        if(template["Players"] is not JsonArray {Count:2} || template.ContainsKey("Allocations"))
            throw new InvalidDataException("Battle manifest template must have two players and no embedded allocation authority.");
        weapons.ValidateTemplate(template);
        this.allocations=allocations;
        this.presentations=presentations;
        this.weapons=weapons;
    }
    public async Task<byte[]> Create(string matchId,IReadOnlyList<string> playerIds,CancellationToken ct)
    {
        return (await CreatePreparedAsync(matchId, playerIds, ct)).Manifest;
    }

    /// <summary>Retains source account revisions so reservation can reject a stale prepared loadout.</summary>
    public async Task<PreparedBattleManifest> CreatePreparedAsync(
        string matchId, IReadOnlyList<string> playerIds, CancellationToken ct)
    {
        if(!System.Text.RegularExpressions.Regex.IsMatch(matchId??"",@"\Am[0-9a-f]{32}\z") || playerIds is not {Count:2} ||
            playerIds.Any(x=>!Guid.TryParseExact(x,"N",out _) || x!=x.ToLowerInvariant()) || playerIds.Distinct(StringComparer.Ordinal).Count()!=2)
            throw new InvalidDataException("Invalid paired manifest identity.");
        IReadOnlyList<BattleAllocationAccountSnapshot> authority = await allocations.GetAccountSnapshotsAsync(playerIds, ct);
        foreach (BattleAllocationAccountSnapshot participant in authority)
        {
            BattleAllocationSource.ValidateMatchesAccount(participant.Account, participant.Allocation);
        }
        IReadOnlyList<BattleAllocationProjection> trusted = authority.Select(row => row.Allocation).ToArray();
        IReadOnlyList<BattlePlayerPresentation> views = authority
            .Select(row => BattlePlayerPresentationSource.Project(row.Account)).ToArray();
        var root=(JsonObject)template.DeepClone();
        root["MatchId"]=matchId;
        var players=(JsonArray)root["Players"]!;
        for(int i=0;i<2;i++)
        {
            var participant=players[i]?.AsObject()??throw new InvalidDataException("Battle manifest participant is missing.");
            weapons.Bind(participant,views[i]);
            participant["PlayerId"]=playerIds[i];
        }
        if(root.ContainsKey("SceneMasterPlayerId"))root["SceneMasterPlayerId"]=playerIds[0];
        root["Allocations"]=JsonSerializer.SerializeToNode(trusted);
        root["Presentations"]=JsonSerializer.SerializeToNode(views);
        byte[] bytes=JsonSerializer.SerializeToUtf8Bytes(root);
        if(bytes.Length>65536)throw new InvalidDataException("Generated battle manifest exceeds control capacity.");
        IReadOnlyList<BattleAccountRevision> revisions = Array.AsReadOnly(authority.Select(row =>
            new BattleAccountRevision(row.Account.Id, row.Account.Revision)).ToArray());
        return new PreparedBattleManifest(bytes, revisions);
    }

    // Queue admission must reject unsupported durable loadouts before a pair is
    // committed; otherwise repeated provisioning can never make that pair usable.
    public void ValidatePresentation(BattlePlayerPresentation view)
    {
        var participant=new JsonObject();
        weapons.Bind(participant,view);
    }

}
