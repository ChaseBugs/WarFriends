using System.Text.Json.Nodes;
using War.BattleServer;
using War.Shared;

namespace War.Backend;

/// <summary>Allocates every durable equipped slot from the Worker's pinned mixed-combat package.</summary>
public sealed class BattleMixedManifestCatalog : IBattleArmyManifestCatalog
{
    private readonly BattleCombatContent content;
    public string PackageRevision => content.MixedRevision!;

    public BattleMixedManifestCatalog(BattleCombatContent content)
    {
        this.content=content??throw new ArgumentNullException(nameof(content));
        if(content.MixedRevision==null)throw new InvalidDataException("Mixed combat content is incomplete.");
        // Validate the embedded source snapshot before accepting matchmaking traffic.
        BattleArmyPerkCatalog.Recovered.ValidateSource(content.Army);
    }

    public void ValidateTemplate(JsonObject template)
    {
        if(template["Mode"]?.GetValue<string>()!=MatchManifest.MixedCombatMode ||
           template["CatalogRevision"]?.GetValue<string>()!=PackageRevision)
            throw new InvalidDataException("Battle template does not bind the recovered mixed combat package.");
    }

    /// <summary>Allows source unit identities and lanes while rejecting unprojected modifiers and new-unit flags.</summary>
    public void RequireRefreshableArmyAuthority(JsonObject participant)
    {
        BattleArmyManifestProjection.RequireRefreshableAuthority(participant);
    }

    public void Bind(JsonObject participant,BattlePlayerPresentation view)
    {
        view=BattlePlayerPresentation.Validate(view);
        BattleArmyManifestProjection.RequireRefreshableAuthority(participant);
        JsonObject armyFields = BattleArmyManifestProjection.Build(content.Army, view.Units);
        var resolved=view.Weapons.Select(equipped =>
        {
            WeaponManifest weapon=content.CreateMixedWeaponManifest(equipped.SourceId,equipped.UpgradeIndex);
            if(content.AllWeaponBindings.Get(equipped.SourceId).InventoryIndex!=equipped.WeaponIndex)
                throw new InvalidDataException("Durable weapon index differs from recovered scene binding.");
            return (equipped,weapon);
        }).ToArray();
        var slots=new JsonArray();
        foreach(var (equipped,weapon) in resolved)
            slots.Add(new JsonObject { ["Slot"]=equipped.Slot,["WeaponIndex"]=equipped.WeaponIndex,
                ["Weapon"]=System.Text.Json.JsonSerializer.SerializeToNode(weapon),
                ["WeaponUpgrade"]=equipped.UpgradeIndex });
        participant["Weapon"]=System.Text.Json.JsonSerializer.SerializeToNode(resolved[0].weapon);
        participant["WeaponUpgrade"]=resolved[0].equipped.UpgradeIndex;
        participant["WeaponSlots"]=slots;
        BattleArmyManifestProjection.Apply(participant, armyFields);
    }

    /// <summary>Binds source-derived PvP combat lanes after both durable player views have been resolved.</summary>
    public void BindArmyCombat(JsonArray participants, IReadOnlyList<BattlePlayerPresentation> views)
    {
        BattleArmyCombatProjection.Bind(content, participants, views);
    }

    /// <summary>Recomputes accepted factors before allowing fresh rematch account state to replace them.</summary>
    public void PrepareArmyCombatRefresh(JsonObject source, MatchManifest previous)
    {
        BattleArmyCombatProjection.PrepareRefresh(content, source, previous);
    }
}
