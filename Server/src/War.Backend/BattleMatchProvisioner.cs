using System.Text.Json;
using War.Infrastructure;
using War.Persistence;
using War.Protocol;
using War.Shared;

namespace War.Backend;

public sealed class BattleMatchProvisioner
{
    private readonly BattleMatchControlClient control;
    private readonly BattleGrantStore grants;
    private readonly Uri endpoint;
    public BattleMatchProvisioner(BattleMatchControlClient control,BattleGrantStore grants,Uri endpoint)
    {this.control=control;this.grants=grants;this.endpoint=endpoint;}

    public async Task<string> Provision(byte[] canonicalManifest,CancellationToken ct)
    {
        if(canonicalManifest is not {Length:>0 and <=65536})throw new InvalidDataException("Invalid match manifest envelope.");
        string matchId;string[] players;int[] fractions;int[] defendPositions;BattlePlayerPresentation[] presentations;
        try
        {
            using var json=JsonDocument.Parse(canonicalManifest);
            var root=json.RootElement;
            if(root.ValueKind!=JsonValueKind.Object || !root.TryGetProperty("MatchId",out var match) || match.ValueKind!=JsonValueKind.String ||
                !root.TryGetProperty("Players",out var roster) || roster.ValueKind!=JsonValueKind.Array || roster.GetArrayLength()!=2)
                throw new InvalidDataException("Match manifest lacks its roster identity.");
            matchId=match.GetString()!;
            if(!System.Text.RegularExpressions.Regex.IsMatch(matchId,@"\Am[0-9a-f]{32}\z"))
                throw new InvalidDataException("Match manifest identity is not allocator-canonical.");
            players=roster.EnumerateArray().Select(row=>row.ValueKind==JsonValueKind.Object &&
                row.TryGetProperty("PlayerId",out var id) && id.ValueKind==JsonValueKind.String?id.GetString()!:"").ToArray();
            fractions=roster.EnumerateArray().Select(row=>row.GetProperty("Fraction").GetInt32()).ToArray();
            if(fractions.Length!=2 || fractions.Any(x=>x is not (1 or 2)) || fractions[0]==fractions[1])
                throw new InvalidDataException("Match manifest lacks renderable participant placement.");
			// The recovered room property used Random.Range(0,2). Keep that exact domain,
			// but derive it retry-stably from allocator-owned match identity.
			int selector=Convert.ToInt32(matchId.Substring(matchId.Length-2),16);
			defendPositions=new[]{selector&1,(selector>>1)&1};
            if(!root.TryGetProperty("Presentations",out var views) || views.ValueKind!=JsonValueKind.Array)
                throw new InvalidDataException("Match manifest lacks player presentations.");
            presentations=JsonSerializer.Deserialize<BattlePlayerPresentation[]>(views.GetRawText()) ?? [];
            if(presentations.Length!=2 || presentations.Select(x=>x.PlayerId).SequenceEqual(players,StringComparer.Ordinal)==false)
                throw new InvalidDataException("Match presentation order differs from roster.");
            presentations=presentations.Select(BattlePlayerPresentation.Validate).ToArray();
        }
        catch(InvalidDataException){throw;}
        catch(Exception e) when(e is JsonException or KeyNotFoundException or InvalidOperationException or FormatException or ArgumentOutOfRangeException)
        {throw new InvalidDataException("Invalid match manifest JSON.",e);}
        var registration=await control.RegisterAsync(endpoint,canonicalManifest,matchId,players,ct);
        var deliverable=registration.Grants.Select(grant=>
        {
            var copy=grant.Clone();
            copy.PlayerViews.AddRange(presentations.Select((value,index)=>ToWire(value,fractions[index],defendPositions[index])));
            return copy;
        }).ToArray();
        string publication=await grants.Publish(registration.MatchId,registration.ManifestHash,deliverable,ct);
        if(publication=="conflict")throw new InvalidDataException("Conflicting durable grant assignment for match.");
        return registration.Code=="existing-match" || publication=="already-published"?"already-provisioned":"provisioned";
    }

    private static BattlePlayerView ToWire(BattlePlayerPresentation value,int fraction,int defendPosition)
    {
        var result=new BattlePlayerView {PlayerId=value.PlayerId,DisplayName=value.DisplayName,Level=value.Level,
            ArmyPower=value.ArmyPower,Skill=value.Skill,LeagueMedals=value.LeagueMedals,BeginnersLeague=value.BeginnersLeague,
            LeagueId=value.LeagueId,Country=value.Country,IsVip=value.IsVip,Fraction=fraction,DefendPosition=defendPosition};
        result.VisualIds.AddRange(value.VisualIds);
        result.Weapons.AddRange(value.Weapons.Select(x=>new BattleWeaponView{Slot=x.Slot,WeaponIndex=x.WeaponIndex,SourceId=x.SourceId,UpgradeIndex=x.UpgradeIndex}));
        result.Units.AddRange(value.Units.Select(x=>new BattleUnitView{SourceId=x.SourceId,UpgradeIndex=x.UpgradeIndex,SpecialIndex=x.SpecialIndex,EliteIndex=x.EliteIndex,Tier=x.Tier}));
        return result;
    }
}
