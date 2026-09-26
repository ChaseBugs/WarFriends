namespace War.BattleServer;

internal sealed record ArmyInfantryClips(string Idle,string Walk,string Fire);

/// <summary>Recovered SoldierAnimationController weapon-type clip selection for deployed infantry.</summary>
internal static class ArmyInfantryPosePolicy
{
    private static readonly IReadOnlyDictionary<string,ArmyInfantryClips> Clips=
        new Dictionary<string,ArmyInfantryClips>(StringComparer.Ordinal)
        {
            ["ID_UNIT-ASSAULT"]=new("idle_1","run_0","rifle_shot_loop"),
            ["ID_UNIT-SNIPER"]=new("sniper_idle","sniper_run","rifle_shot_loop"),
            ["ID_UNIT-ROCKETSOLDIER"]=new("bazooka_idle","bazooka_run","bazooka_shot_barrier"),
            ["ID_UNIT-SHOTGUNNER"]=new("shotgunner_idle","shotgunner_run","shotgunner_shot_loop"),
            ["ID_UNIT-GRENADIER"]=new("idle_1","run_0","rifle_shot_loop"),
            ["ID_UNIT-PARATROOPER"]=new("idle_1","run_0","rifle_shot_loop"),
            ["ID_UNIT-SWAT"]=new("shield_idle","shield_run","shield_shot"),
            ["ID_UNIT-MINIGUNNER"]=new("minigun_idle","minigun_run","minigun_shot"),
            ["ID_UNIT-ENGINEER"]=new("engineer_idle","engineer_run","engineer_repair"),
            ["ID_UNIT-MACHINEGUNNER"]=new("idle_1","run_0","rifle_shot_loop"),
            ["ID_UNIT-SCIFI"]=new("grenadelauncher_idle","run_grenadelauncher","rifle_shot_loop"),
            ["ID_UNIT-FLAMETHROWER"]=new("flamethrower_idle","flamethrower_run","flamethrower_shot_loop"),
            ["ID_UNIT-COMMANDO"]=new("SMG_idle","SMG_run","commando_shooting"),
            ["ID_UNIT-GUNSLINGER"]=new("colt_idle01","colt_run","colt_shooting_loop"),
            ["ID_UNIT-MORTAR"]=new("mortar_idle_standing","mortar_run","mortar_hide"),
            ["ID_UNIT-WARPER"]=new("shotgunner_idle","shotgunner_run","shotgunner_shot_loop")
        };

    internal static ArmyInfantryClips For(string unitId)=>Clips.TryGetValue(unitId,out var value)?value:
        throw new InvalidDataException("Unknown deployed infantry animation family.");

    internal static void Validate(ArmyDeploymentCatalog army,EnemyPoseCatalog poses)
    {
        var soldiers=army.Families.Where(x=>x.IsSoldier).Select(x=>x.UnitId).Order(StringComparer.Ordinal).ToArray();
        if(soldiers.Length!=Clips.Count||!soldiers.SequenceEqual(Clips.Keys.Order(StringComparer.Ordinal),StringComparer.Ordinal))
            throw new InvalidDataException("Infantry animation policy does not cover the deployed soldier set.");
        var names=poses.Names.ToHashSet(StringComparer.Ordinal);
        if(Clips.Values.SelectMany(x=>new[]{x.Idle,x.Walk,x.Fire}).Any(x=>!names.Contains(x))||
           !names.Contains("warp_movement")||!names.Contains("warp_idle"))
            throw new InvalidDataException("Infantry animation policy references an unpinned enemy clip.");
    }
}
