using System.Text.Json.Nodes;
using War.BattleServer;
using War.Shared;

namespace War.Backend;

/// <summary>Allocates every durable equipped slot from the Worker's pinned mixed-combat package.</summary>
public sealed class BattleMixedManifestCatalog : IBattleWeaponManifestCatalog
{
    private readonly BattleCombatContent content;
    public string PackageRevision => content.MixedRevision!;

    public BattleMixedManifestCatalog(BattleCombatContent content)
    {
        this.content=content??throw new ArgumentNullException(nameof(content));
        if(content.MixedRevision==null)throw new InvalidDataException("Mixed combat content is incomplete.");
    }

    public void ValidateTemplate(JsonObject template)
    {
        if(template["Mode"]?.GetValue<string>()!=MatchManifest.MixedCombatMode ||
           template["CatalogRevision"]?.GetValue<string>()!=PackageRevision)
            throw new InvalidDataException("Battle template does not bind the recovered mixed combat package.");
    }

    public void Bind(JsonObject participant,BattlePlayerPresentation view)
    {
        view=BattlePlayerPresentation.Validate(view);
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
    }
}
