namespace War.BattleServer;

// MainScene.unity Card MonoBehaviours joined by script GUID to CardDefinitions.Rows.
// All of these rows have rarity 1-3; CardBuddy alone overrides rarity to Buddy.
public static class WarCardSourceIdentityCatalog
{
    private static readonly IReadOnlyDictionary<string,string[]> SourceIds =
        new Dictionary<string,string[]>(StringComparer.Ordinal)
        {
            ["CardAmmoThief"]=["AMMOTHIEF"],
            ["CardShieldGenerator"]=["SHIELDGENERATOR"],
            ["CardHealthForSoldiers"]=["SUPERSOLDIERS"],
            ["CardLandmine"]=["MINE"],
            ["CardBrokenLegs"]=["FREEZE"],
            ["CardHeavyTurret"]=["HEAVYTURRET"],
            ["CardDecoy"]=["DECOY"],
            ["CardSlowdown"]=["SLOWDOWN"],
            ["CardMineYourStep"]=["MINEENEMY"],
            ["CardShieldsUp"]=["SHIELDSHEALTH"],
            ["CardAirstrike"]=["AIRSTRIKE"],
            ["CardHealthForMachines"]=["VEHICLEHEALTH"],
            ["CardHealingStorm"]=["HEALINGSTORM"],
            ["CardHealMeNow"]=["MEDKIT"],
            ["CardGrenadesBurst"]=["CLUSTERGRENADE"],
            ["CardAmmoBox"]=["AMMOBOX"],
            ["CardSpawnUnit"]=["BIGROCKET","ELITEMINIGUN","ELITEPARA","ELITESNIPER",
                "ELITESWAT","GREATGRENADIER","HEAVYDRONE"]
        };

    public static string Resolve(string cardClassId,string? sourceCardId=null)
    {
        if(!SourceIds.TryGetValue(cardClassId??"",out var ids) ||
           (sourceCardId!=null && !ids.Contains(sourceCardId,StringComparer.Ordinal)) ||
           (sourceCardId==null && ids.Length!=1))
            throw new InvalidDataException("Card class/source identity is not pinned by MainScene.");
        return sourceCardId??ids[0];
    }
    public static IReadOnlyList<(string CardClassId,string SourceCardId)> All => SourceIds
        .SelectMany(pair=>pair.Value.Select(id=>(pair.Key,id)))
        .OrderBy(row=>row.Key,StringComparer.Ordinal).ThenBy(row=>row.id,StringComparer.Ordinal)
        .Select(row=>(row.Key,row.id)).ToArray();
}
