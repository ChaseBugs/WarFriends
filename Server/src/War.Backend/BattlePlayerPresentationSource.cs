using War.Backend.Legacy;
using War.Persistence;
using War.Shared;

namespace War.Backend;

/// <summary>Projects only validated durable account state into transport-neutral battle views.</summary>
public sealed class BattlePlayerPresentationSource
{
    private readonly LegacyPlayerStore players;
    public BattlePlayerPresentationSource(LegacyPlayerStore players) => this.players=players;

    public async Task<IReadOnlyList<BattlePlayerPresentation>> GetMany(IReadOnlyList<string> playerIds,CancellationToken ct)
    {
        if(playerIds is not {Count:>0 and <=64} || playerIds.Distinct(StringComparer.Ordinal).Count()!=playerIds.Count)
            throw new InvalidDataException("Invalid battle presentation roster.");
        var found=await players.ByIds(playerIds,ct);
        if(found.Count!=playerIds.Count)throw new InvalidDataException("Battle presentation account is missing.");
        var byId=found.ToDictionary(x=>x.Id,StringComparer.Ordinal);
        return playerIds.Select(id=>byId.TryGetValue(id,out var player) ? Project(player) :
            throw new InvalidDataException("Battle presentation account is missing.")).ToArray();
    }

    public async Task<BattlePlayerPresentation> Get(string playerId,CancellationToken ct)
    {
        var player=await players.ById(playerId,ct) ?? throw new InvalidDataException("Battle presentation account is missing.");
        return Project(player);
    }

    public static BattlePlayerPresentation Project(LegacyPlayerDocument player)
    {
        if(player==null)throw new InvalidDataException("Battle presentation account is missing.");
        DecalManagerData decals=ReadRequired<DecalManagerData>(player,"DecalManagerData");
        InventoryData inventory=ReadRequired<InventoryData>(player,"InventoryData");
        LevelManagerData levels=ReadRequired<LevelManagerData>(player,"LevelManagerData");
        string[] visuals=Enumerable.Range(0,4).Select(i=>decals.Slots.TryGetValue(i,out var slot) ? slot.EquippedId ?? "" : "").ToArray();
        var weapons=inventory.Slots.OrderBy(x=>x.Key).Select(x=>
        {
            string source=x.Value.Name ?? "";
            if(!levels.SavedWeapons.TryGetValue(source,out var saved) || !(saved.Bought || saved.Borrowed))
                throw new InvalidDataException("Equipped weapon is not owned in durable level state.");
            return new BattleWeaponPresentation(x.Key,x.Value.WeaponIndex,source,saved.BoughtIndex);
        }).ToArray();
        var units=levels.SavedArmies.Where(x=>x.Value.Equipped).OrderBy(x=>x.Key,StringComparer.Ordinal).Select(x=>
        {
            if(!(x.Value.Bought || x.Value.Borrowed))throw new InvalidDataException("Equipped unit is not owned in durable level state.");
            return new BattleUnitPresentation(x.Key,x.Value.BoughtIndex,x.Value.SpecialSlot,x.Value.EliteSlot,x.Value.Tier);
        }).ToArray();
        return BattlePlayerPresentation.Validate(new BattlePlayerPresentation(player.Id,player.Name,player.Level,player.ArmyPower,
            player.Skill,player.MedalsBalance,player.BeginnersLeague,player.LeagueId,player.Country,player.Vip>0,visuals,weapons,units));
    }

    private static T ReadRequired<T>(LegacyPlayerDocument player,string key) where T:new()
    {
        if(!player.Serialized.TryGetValue(key,out string? json) || string.IsNullOrWhiteSpace(json))
            throw new InvalidDataException("Required battle presentation state is missing: "+key+".");
        try{return PlayerState.Read<T>(json);}
        catch(Exception e) when(e is System.Text.Json.JsonException or NotSupportedException)
        {throw new InvalidDataException("Required battle presentation state is malformed: "+key+".",e);}
    }
}
