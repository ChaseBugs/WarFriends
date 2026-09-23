using System.Text.Json;
using System.Text.Json.Nodes;
using War.Persistence;
using War.Shared;

namespace War.Backend;

/// <summary>Fills only allocator-owned identities/projections into an operator-reviewed source-valid manifest template.</summary>
public sealed class BattleManifestFactory
{
    private readonly JsonObject template;
    private readonly BattleAllocationStore allocations;
    private readonly BattlePlayerPresentationSource presentations;
    private readonly BattleRifleManifestCatalog rifles;
    public BattleManifestFactory(byte[] templateBytes,BattleAllocationStore allocations,BattlePlayerPresentationSource presentations,
        BattleRifleManifestCatalog rifles)
    {
        if(templateBytes is not {Length:>1 and <=65536})throw new InvalidDataException("Invalid battle manifest template size.");
        try {template=JsonNode.Parse(templateBytes)?.AsObject()??throw new InvalidDataException("Null battle manifest template.");}
        catch(JsonException e){throw new InvalidDataException("Invalid battle manifest template JSON.",e);}
        if(template["Players"] is not JsonArray {Count:2} || template.ContainsKey("Allocations"))
            throw new InvalidDataException("Battle manifest template must have two players and no embedded allocation authority.");
        rifles.ValidateTemplate(template);
        this.allocations=allocations;
        this.presentations=presentations;
        this.rifles=rifles;
    }
    public async Task<byte[]> Create(string matchId,IReadOnlyList<string> playerIds,CancellationToken ct)
    {
        if(!System.Text.RegularExpressions.Regex.IsMatch(matchId??"",@"\Am[0-9a-f]{32}\z") || playerIds is not {Count:2} ||
            playerIds.Any(x=>!Guid.TryParseExact(x,"N",out _) || x!=x.ToLowerInvariant()) || playerIds.Distinct(StringComparer.Ordinal).Count()!=2)
            throw new InvalidDataException("Invalid paired manifest identity.");
        IReadOnlyList<BattleAllocationProjection> trusted=await allocations.GetMany(playerIds,ct);
        IReadOnlyList<BattlePlayerPresentation> views=await presentations.GetMany(playerIds,ct);
        var root=(JsonObject)template.DeepClone();
        root["MatchId"]=matchId;
        var players=(JsonArray)root["Players"]!;
        for(int i=0;i<2;i++)
        {
            var participant=players[i]?.AsObject()??throw new InvalidDataException("Battle manifest participant is missing.");
            rifles.Bind(participant,views[i]);
            participant["PlayerId"]=playerIds[i];
        }
        if(root.ContainsKey("SceneMasterPlayerId"))root["SceneMasterPlayerId"]=playerIds[0];
        root["Allocations"]=JsonSerializer.SerializeToNode(trusted);
        root["Presentations"]=JsonSerializer.SerializeToNode(views);
        byte[] bytes=JsonSerializer.SerializeToUtf8Bytes(root);
        if(bytes.Length>65536)throw new InvalidDataException("Generated battle manifest exceeds control capacity.");
        return bytes;
    }

}
