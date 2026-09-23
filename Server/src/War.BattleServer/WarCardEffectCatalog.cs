namespace War.BattleServer;

public enum WarCardEffectKind { SpawnUnit, SpawnDeployable, Damage, Heal, Shield, Status, Ammo, Modifier }
public sealed record WarCardEffectDefinition(string CardId,WarCardEffectKind Kind,bool RequiresTarget,bool ConsumesReservation);

/// <summary>Explicit classification of recovered gameplay Card classes. Unlisted cards stay closed.</summary>
public static class WarCardEffectCatalog
{
    private static readonly IReadOnlyDictionary<string,WarCardEffectDefinition> definitions=
        new Dictionary<string,WarCardEffectDefinition>(StringComparer.Ordinal)
        {
            ["CardHeavyTurret"]=new("CardHeavyTurret",WarCardEffectKind.SpawnDeployable,false,true),
            ["CardLandmine"]=new("CardLandmine",WarCardEffectKind.SpawnDeployable,true,true),
            ["CardMineYourStep"]=new("CardMineYourStep",WarCardEffectKind.SpawnDeployable,true,true),
            ["CardSpawnUnit"]=new("CardSpawnUnit",WarCardEffectKind.SpawnUnit,false,true),
            ["CardAirstrike"]=new("CardAirstrike",WarCardEffectKind.Damage,true,true),
            ["CardGrenadesBurst"]=new("CardGrenadesBurst",WarCardEffectKind.Damage,true,true),
            ["CardHealMeNow"]=new("CardHealMeNow",WarCardEffectKind.Heal,false,true),
            ["CardHealingStorm"]=new("CardHealingStorm",WarCardEffectKind.Heal,true,true),
            ["CardShieldGenerator"]=new("CardShieldGenerator",WarCardEffectKind.Shield,false,true),
            ["CardShieldsUp"]=new("CardShieldsUp",WarCardEffectKind.Shield,false,true),
            ["CardBrokenLegs"]=new("CardBrokenLegs",WarCardEffectKind.Status,true,true),
            ["CardSlowdown"]=new("CardSlowdown",WarCardEffectKind.Status,true,true),
            ["CardAmmoBox"]=new("CardAmmoBox",WarCardEffectKind.Ammo,false,true),
            ["CardAmmoThief"]=new("CardAmmoThief",WarCardEffectKind.Ammo,true,true),
            ["CardHealthForSoldiers"]=new("CardHealthForSoldiers",WarCardEffectKind.Modifier,false,true),
            ["CardHealthForMachines"]=new("CardHealthForMachines",WarCardEffectKind.Modifier,false,true)
        };
    public static bool TryGet(string cardId,out WarCardEffectDefinition definition)
        =>definitions.TryGetValue(cardId??"",out definition!);
    public static IReadOnlyCollection<WarCardEffectDefinition> All=>definitions.Values.ToArray();
}
