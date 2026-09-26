using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

// Trusted deployment input; never accepted from a game packet. Fixed neighboring
// filenames keep the package portable between Windows and Linux.
public sealed record CombatContentManifest(int Version,string SceneRevision,string StatsRevision,string BindingsRevision,string AllWeaponBindingsRevision,string PosesRevision,string BarrelBindingsRevision,string BarrelOverlapRevision,string ArmyDeploymentRevision,string ArmyWeaponBindingsRevision,string ArmySpawnPointsRevision,string ArmyRusherPointsRevision,string ArmyMinigunnerPointsRevision,string PlayerShotTargetsRevision,string ArmyNavMeshSourcesRevision,string ArmyNavMeshTriangulationRevision,string ArmyNavMeshPathsRevision);

public sealed class BattleCombatContent
{
    public RifleStatCatalog Stats { get; }
    public RifleBindingCatalog Bindings { get; }
    public WeaponBindingGraphCatalog AllWeaponBindings { get; }
    public PlayerPoseCatalog Poses { get; }
    internal ShieldSourceCatalog Shields { get; }
    public string Revision { get; }
    internal ShotgunCatalog? Shotguns { get; }
    internal string? ShotgunRevision { get; }
    public SmgCatalog? Smgs { get; }
    public string? SmgRevision { get; }
    public string? MixedRevision { get; }
    public PistolCatalog? Pistols { get; }
    public string? PistolRevision { get; }
    public LmgCatalog? Lmgs { get; }
    public string? LmgRevision { get; }
    public MinigunCatalog? Minigun { get; }
    public string? MinigunRevision { get; }
    public SniperCatalog? Snipers { get; }
    public string? SniperRevision { get; }
    public BazookaCatalog? Bazookas { get; }
    public string? BazookaRevision { get; }
    public GrenadeCatalog? Grenades { get; }
    public string? GrenadeRevision { get; }
    public IReadOnlyList<RecoveredBattleMap> Maps { get; }
    public BarrelSceneCatalog Barrels { get; }
    public ArmyDeploymentCatalog Army { get; }
    public ArmyWeaponBindingCatalog ArmyWeapons { get; }
    public ArmySpawnPointCatalog ArmySpawnPoints { get; }
    public ArmyRusherPointCatalog ArmyRusherPoints { get; }
    public ArmyMinigunnerPointCatalog ArmyMinigunnerPoints { get; }
    public PlayerShotTargetCatalog PlayerShotTargets { get; }
    public ArmyNavMeshSourceCatalog ArmyNavMeshes { get; }
    public ArmyNavMeshTriangulationCatalog ArmyNavMeshGeometry { get; }
    public ArmyNavMeshPathFixtureCatalog ArmyNavMeshPaths { get; }
    public ArmyNavMeshConnectivity ArmyNavMeshConnectivity { get; }
    internal BarrelSourcePolicy BarrelPolicy { get; }
    internal ExplosionSourceCatalog Explosions { get; }
    internal BarrelOverlapOrderCatalog BarrelOverlap { get; }
    private BattleCombatContent(RifleStatCatalog stats,RifleBindingCatalog bindings,WeaponBindingGraphCatalog allWeaponBindings,PlayerPoseCatalog poses,string revision,
        IReadOnlyList<RecoveredBattleMap> maps,ShotgunCatalog? shotguns,string? shotgunRevision,SmgCatalog? smgs,string? smgRevision,PistolCatalog? pistols,string? pistolRevision,LmgCatalog? lmgs,string? lmgRevision,MinigunCatalog? minigun,string? minigunRevision,SniperCatalog? snipers,string? sniperRevision,BazookaCatalog? bazookas,string? bazookaRevision,GrenadeCatalog? grenades,string? grenadeRevision,string? mixedRevision,ShieldSourceCatalog shields,BarrelSceneCatalog barrels,BarrelSourcePolicy barrelPolicy,ExplosionSourceCatalog explosions,BarrelOverlapOrderCatalog barrelOverlap,ArmyDeploymentCatalog army,ArmyWeaponBindingCatalog armyWeapons,ArmySpawnPointCatalog armySpawnPoints,ArmyRusherPointCatalog armyRusherPoints,ArmyMinigunnerPointCatalog armyMinigunnerPoints,PlayerShotTargetCatalog playerShotTargets,ArmyNavMeshSourceCatalog armyNavMeshes,ArmyNavMeshTriangulationCatalog armyNavMeshGeometry,ArmyNavMeshPathFixtureCatalog armyNavMeshPaths,ArmyNavMeshConnectivity armyNavMeshConnectivity)
    { Stats=stats;Bindings=bindings;AllWeaponBindings=allWeaponBindings;Poses=poses;Revision=revision;Maps=Array.AsReadOnly(maps.ToArray());Shotguns=shotguns;ShotgunRevision=shotgunRevision;Smgs=smgs;SmgRevision=smgRevision;Pistols=pistols;PistolRevision=pistolRevision;Lmgs=lmgs;LmgRevision=lmgRevision;Minigun=minigun;MinigunRevision=minigunRevision;Snipers=snipers;SniperRevision=sniperRevision;Bazookas=bazookas;BazookaRevision=bazookaRevision;Grenades=grenades;GrenadeRevision=grenadeRevision;MixedRevision=mixedRevision;Shields=shields;Barrels=barrels;BarrelPolicy=barrelPolicy;Explosions=explosions;BarrelOverlap=barrelOverlap;Army=army;ArmyWeapons=armyWeapons;ArmySpawnPoints=armySpawnPoints;ArmyRusherPoints=armyRusherPoints;ArmyMinigunnerPoints=armyMinigunnerPoints;PlayerShotTargets=playerShotTargets;ArmyNavMeshes=armyNavMeshes;ArmyNavMeshGeometry=armyNavMeshGeometry;ArmyNavMeshPaths=armyNavMeshPaths;ArmyNavMeshConnectivity=armyNavMeshConnectivity; }
    public static BattleCombatContent Load(string manifestPath,string? shotgunManifestPath=null,string? smgManifestPath=null,string? pistolManifestPath=null,string? lmgManifestPath=null,string? minigunManifestPath=null,string? sniperManifestPath=null,string? bazookaManifestPath=null,string? grenadeManifestPath=null)
    {
        using var stream=File.OpenRead(manifestPath);
        if (stream.Length is < 2 or > 4096) throw new InvalidDataException("Invalid combat content manifest size.");
        var manifest=JsonSerializer.Deserialize<CombatContentManifest>(stream,new JsonSerializerOptions { UnmappedMemberHandling=JsonUnmappedMemberHandling.Disallow })
            ?? throw new InvalidDataException("Missing combat content manifest.");
        var hashes=new[] {manifest.SceneRevision,manifest.StatsRevision,manifest.BindingsRevision,manifest.AllWeaponBindingsRevision,manifest.PosesRevision,manifest.BarrelBindingsRevision,manifest.BarrelOverlapRevision,manifest.ArmyDeploymentRevision,manifest.ArmyWeaponBindingsRevision,manifest.ArmySpawnPointsRevision,manifest.ArmyRusherPointsRevision,manifest.ArmyMinigunnerPointsRevision,manifest.PlayerShotTargetsRevision,manifest.ArmyNavMeshSourcesRevision,manifest.ArmyNavMeshTriangulationRevision,manifest.ArmyNavMeshPathsRevision};
        if (manifest.Version!=2 || hashes.Any(h=>h==null || !Regex.IsMatch(h,@"\A[0-9a-f]{64}\z")))
            throw new InvalidDataException("Invalid combat package revisions.");
        string directory=Path.GetDirectoryName(Path.GetFullPath(manifestPath))!;
        var stats=RifleStatCatalog.Load(Path.Combine(directory,"recovered-battle-content.json"),manifest.StatsRevision,manifest.SceneRevision);
        var shields=ShieldSourceCatalog.Load(Path.Combine(directory,"recovered-battle-content.json"),manifest.StatsRevision);
        var bindings=RifleBindingCatalog.Load(Path.Combine(directory,"recovered-rifle-bindings.json"),manifest.BindingsRevision,stats);
        var allWeaponBindings=WeaponBindingGraphCatalog.Load(Path.Combine(directory,"recovered-all-weapon-bindings.json"),manifest.AllWeaponBindingsRevision,manifest.SceneRevision,Path.Combine(directory,"recovered-battle-content.json"));
        var poses=PlayerPoseCatalog.Load(Path.Combine(directory,"recovered-player-poses.json"),manifest.SceneRevision,bindings);
        if (poses.Revision!=manifest.PosesRevision) throw new InvalidDataException("Combat pose revision mismatch.");
        var maps=RecoveredBattleMap.Load(Path.Combine(directory,"recovered-battle-content.json"));
        var barrels=BarrelSceneCatalog.Load(Path.Combine(directory,"recovered-barrel-scene-bindings.json"),manifest.BarrelBindingsRevision,maps);
        var barrelPolicy=BarrelSourcePolicy.Load(Path.Combine(directory,"recovered-battle-content.json"),manifest.StatsRevision,manifest.SceneRevision);
        var explosions=ExplosionSourceCatalog.Load(Path.Combine(directory,"recovered-battle-content.json"),manifest.StatsRevision,manifest.SceneRevision);
        var barrelOverlap=BarrelOverlapOrderCatalog.Load(Path.Combine(directory,"unity-barrel-overlap-reference.json"),manifest.BarrelOverlapRevision,maps,barrels);
        var army=ArmyDeploymentCatalog.Load(Path.Combine(directory,"recovered-army-deployment.json"),manifest.ArmyDeploymentRevision,manifest.SceneRevision);
        army.ValidateSourceSheet(Path.Combine(directory,"recovered-battle-content.json"));
        var armyWeapons=ArmyWeaponBindingCatalog.Load(Path.Combine(directory,"recovered-rusher-weapon-bindings.json"),manifest.ArmyWeaponBindingsRevision,manifest.SceneRevision);
        if(maps.Any(map=>!armyWeapons.WarperRelocation.Fields.TryGetValue(map.Source,out var field)||
            field.Sha256!=map.SourceHash))
            throw new InvalidDataException("Warper field authority does not bind the complete map package.");
        var armySpawnPoints=ArmySpawnPointCatalog.Load(Path.Combine(directory,"recovered-army-spawn-points.json"),manifest.ArmySpawnPointsRevision,maps);
        var armyRusherPoints=ArmyRusherPointCatalog.Load(Path.Combine(directory,"recovered-army-rusher-points.json"),manifest.ArmyRusherPointsRevision,maps);
        var armyMinigunnerPoints=ArmyMinigunnerPointCatalog.Load(Path.Combine(directory,"recovered-army-minigunner-points.json"),manifest.ArmyMinigunnerPointsRevision,maps);
        var playerShotTargets=PlayerShotTargetCatalog.Load(Path.Combine(directory,"recovered-player-shot-targets.json"),manifest.PlayerShotTargetsRevision,manifest.SceneRevision);
        poses.AttachPlayerShotTargets(playerShotTargets);
        var armyNavMeshes=ArmyNavMeshSourceCatalog.Load(Path.Combine(directory,"recovered-army-navmesh-sources.json"),manifest.ArmyNavMeshSourcesRevision,maps);
        var armyNavMeshGeometry=ArmyNavMeshTriangulationCatalog.Load(Path.Combine(directory,"recovered-navmesh-triangulation.json"),manifest.ArmyNavMeshTriangulationRevision,armyNavMeshes);
        var armyNavMeshPaths=ArmyNavMeshPathFixtureCatalog.Load(Path.Combine(directory,"recovered-navmesh-path-manifest.json"),manifest.ArmyNavMeshPathsRevision,
            maps,armyNavMeshes,armyNavMeshGeometry,armySpawnPoints,armyRusherPoints);
        var armyNavMeshConnectivity=ArmyNavMeshConnectivity.Build(maps,armyNavMeshGeometry,armyNavMeshPaths);
        string revision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes("WarFriends/combat-content/v2\n"+string.Join("\n",hashes))));
        ShotgunCatalog? shotguns=null;string? shotgunRevision=null;
        if(shotgunManifestPath!=null)
        {
            shotguns=ShotgunCatalog.Load(shotgunManifestPath);
            if(shotguns.SceneRevision!=manifest.SceneRevision)
                throw new InvalidDataException("Shotgun package does not bind the live scene.");
            poses.AttachShotgunMuzzles(shotguns);
            shotgunRevision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(
                "WarFriends/shotgun-combat/v1\n"+revision+"\n"+shotguns.PackageRevision)));
        }
        SmgCatalog? smgs=null;string? smgRevision=null;
        if(smgManifestPath!=null)
        {
            smgs=SmgCatalog.Load(smgManifestPath);
            if(smgs.SceneRevision!=manifest.SceneRevision)
                throw new InvalidDataException("SMG package does not bind the live scene.");
            poses.AttachSmgMuzzles(smgs);
            smgRevision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(
                "WarFriends/smg-combat/v1\n"+revision+"\n"+smgs.PackageRevision)));
        }
        PistolCatalog? pistols=null;string? pistolRevision=null;
        if(pistolManifestPath!=null)
        {
            pistols=PistolCatalog.Load(pistolManifestPath);
            if(pistols.SceneRevision!=manifest.SceneRevision)throw new InvalidDataException("Pistol package does not bind the live scene.");
            poses.AttachPistolMuzzles(pistols);
            pistolRevision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(
                "WarFriends/pistol-combat/v1\n"+revision+"\n"+pistols.PackageRevision)));
        }
        LmgCatalog? lmgs=null;string? lmgRevision=null;
        if(lmgManifestPath!=null)
        {
            lmgs=LmgCatalog.Load(lmgManifestPath);if(lmgs.SceneRevision!=manifest.SceneRevision)throw new InvalidDataException("LMG package does not bind the live scene.");
            poses.AttachLmgMuzzles(lmgs);lmgRevision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(
                "WarFriends/lmg-combat/v1\n"+revision+"\n"+lmgs.PackageRevision)));
        }
        MinigunCatalog? minigun=null;string? minigunRevision=null;
        if(minigunManifestPath!=null)
        {
            minigun=MinigunCatalog.Load(minigunManifestPath);if(minigun.SceneRevision!=manifest.SceneRevision)throw new InvalidDataException("Minigun package does not bind the live scene.");
            poses.AttachMinigunMuzzle(minigun);
            minigunRevision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes("WarFriends/minigun-combat/v1\n"+revision+"\n"+minigun.PackageRevision)));
        }
        SniperCatalog? snipers=null;string? sniperRevision=null;
        if(sniperManifestPath!=null)
        {
            snipers=SniperCatalog.Load(sniperManifestPath);if(snipers.SceneRevision!=manifest.SceneRevision)throw new InvalidDataException("Sniper package does not bind the live scene.");
            poses.AttachSniperMuzzles(snipers);sniperRevision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes("WarFriends/sniper-combat/v1\n"+revision+"\n"+snipers.PackageRevision)));
        }
        BazookaCatalog? bazookas=null;string? bazookaRevision=null;
        if(bazookaManifestPath!=null)
        {
            bazookas=BazookaCatalog.Load(bazookaManifestPath);if(bazookas.SceneRevision!=manifest.SceneRevision)throw new InvalidDataException("Bazooka package does not bind the live scene.");
            poses.AttachBazookaMuzzles(bazookas);bazookaRevision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes("WarFriends/bazooka-combat/v1\n"+revision+"\n"+bazookas.PackageRevision)));
        }
        GrenadeCatalog? grenades=null;string? grenadeRevision=null;
        if(grenadeManifestPath!=null)
        {
            grenades=GrenadeCatalog.Load(grenadeManifestPath);if(grenades.SceneRevision!=manifest.SceneRevision)throw new InvalidDataException("Grenade package does not bind the live scene.");
            poses.AttachGrenadeMuzzles(grenades);grenadeRevision=Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes("WarFriends/grenade-combat/v1\n"+revision+"\n"+grenades.PackageRevision)));
        }
        string? mixedRevision=shotguns!=null&&smgs!=null&&pistols!=null&&lmgs!=null&&minigun!=null&&snipers!=null ? Convert.ToHexStringLower(SHA256.HashData(Encoding.UTF8.GetBytes(
            "WarFriends/mixed-combat/v5\n"+revision+"\n"+shotguns.PackageRevision+"\n"+smgs.PackageRevision+"\n"+pistols.PackageRevision+"\n"+lmgs.PackageRevision+"\n"+minigun.PackageRevision+"\n"+snipers.PackageRevision))) : null;
        return new(stats,bindings,allWeaponBindings,poses,revision,maps,shotguns,shotgunRevision,smgs,smgRevision,pistols,pistolRevision,lmgs,lmgRevision,minigun,minigunRevision,snipers,sniperRevision,bazookas,bazookaRevision,grenades,grenadeRevision,mixedRevision,shields,barrels,barrelPolicy,explosions,barrelOverlap,army,armyWeapons,armySpawnPoints,armyRusherPoints,armyMinigunnerPoints,playerShotTargets,armyNavMeshes,armyNavMeshGeometry,armyNavMeshPaths,armyNavMeshConnectivity);
    }
    public void ValidateAllocation(MatchManifest manifest)
    {
        manifest=MatchManifest.Validate(manifest);
        bool shotgun=manifest.Mode==MatchManifest.ShotgunCombatMode;
        bool smg=manifest.Mode==MatchManifest.SmgCombatMode;
        bool mixed=manifest.Mode==MatchManifest.MixedCombatMode;
        bool pistol=manifest.Mode==MatchManifest.PistolCombatMode;
        bool lmg=manifest.Mode==MatchManifest.LmgCombatMode;
        bool minigun=manifest.Mode==MatchManifest.MinigunCombatMode;
        bool sniper=manifest.Mode==MatchManifest.SniperCombatMode;
        bool bazooka=manifest.Mode==MatchManifest.BazookaCombatMode;
        bool grenade=manifest.Mode==MatchManifest.GrenadeCombatMode;
        string? expectedRevision=shotgun?ShotgunRevision:smg?SmgRevision:pistol?PistolRevision:lmg?LmgRevision:minigun?MinigunRevision:sniper?SniperRevision:bazooka?BazookaRevision:grenade?GrenadeRevision:mixed?MixedRevision:Revision;
        if (manifest.CatalogRevision!=expectedRevision ||
            (shotgun && Shotguns==null) || (smg && Smgs==null) || (pistol&&Pistols==null) || (lmg&&Lmgs==null) || (minigun&&Minigun==null) || (sniper&&Snipers==null) || (bazooka&&Bazookas==null) || (grenade&&Grenades==null) ||
            (mixed&&(Shotguns==null||Smgs==null||Pistols==null||Lmgs==null||Minigun==null||Snipers==null)) || manifest.Players.Any(p=>!p.WeaponUpgrade.HasValue))
            throw new InvalidDataException("Match must bind the complete combat package and both upgrade indexes.");
        WeaponManifest Expected(string id,int upgrade)
        {
            if(shotgun)return Shotguns!.CreateManifest(id,upgrade);
            if(smg)return Smgs!.CreateManifest(id,upgrade);
            if(pistol)return Pistols!.CreateManifest(id,upgrade);
            if(lmg)return Lmgs!.CreateManifest(id,upgrade);
            if(minigun)return id==MinigunCatalog.SourceId?Minigun!.CreateManifest(upgrade):throw new InvalidDataException("Minigun match equips another weapon.");
            if(sniper)return Snipers!.CreateManifest(id,upgrade);
            if(bazooka)return Bazookas!.CreateManifest(id,upgrade);
            if(grenade)return Grenades!.CreateManifest(id,upgrade);
            if(!mixed)return Stats.CreateManifest(id,upgrade);
            if(id.StartsWith("Google2u.AssaultRifle_",StringComparison.Ordinal))return Stats.CreateManifest(id,upgrade);
            if(id.StartsWith("Google2u.Shotgun_",StringComparison.Ordinal))return Shotguns!.CreateManifest(id,upgrade);
            if(id.StartsWith("Google2u.SMG_",StringComparison.Ordinal))return Smgs!.CreateManifest(id,upgrade);
            if(id.StartsWith("Google2u.Pistol_",StringComparison.Ordinal))return Pistols!.CreateManifest(id,upgrade);
            if(id==MinigunCatalog.SourceId)return Minigun!.CreateManifest(upgrade);
            if(id.StartsWith("Google2u.SniperRifle_",StringComparison.Ordinal))return Snipers!.CreateManifest(id,upgrade);
            if(id.StartsWith("Google2u.Bazooka_",StringComparison.Ordinal))return Bazookas!.CreateManifest(id,upgrade);
            if(id.StartsWith("Google2u.LMG_",StringComparison.Ordinal))return Lmgs!.CreateManifest(id,upgrade);
            throw new InvalidDataException("Mixed match equips an unsupported weapon class.");
        }
        void Binding(string id)
        {
            if(shotgun||mixed&&id.StartsWith("Google2u.Shotgun_",StringComparison.Ordinal))Shotguns!.Binding(id);
            else if(smg||mixed&&id.StartsWith("Google2u.SMG_",StringComparison.Ordinal))Smgs!.Binding(id);
            else if(pistol||mixed&&id.StartsWith("Google2u.Pistol_",StringComparison.Ordinal))Pistols!.Binding(id);
            else if(minigun||mixed&&id==MinigunCatalog.SourceId)_=Minigun!.Binding;
            else if(sniper||mixed&&id.StartsWith("Google2u.SniperRifle_",StringComparison.Ordinal))Snipers!.Binding(id);
            else if(bazooka||mixed&&id.StartsWith("Google2u.Bazooka_",StringComparison.Ordinal))Bazookas!.Binding(id);
            else if(grenade)Grenades!.Binding(id);
            else if(lmg||mixed&&id.StartsWith("Google2u.LMG_",StringComparison.Ordinal))Lmgs!.Binding(id);
            else Bindings.Get(id);
        }
        foreach (var p in manifest.Players)
        {
            if(p.EquippedArmyUnitIds!=null &&
               p.EquippedArmyUnitIds.Any(id=>!Army.Families.Any(f=>f.UnitId==id)))
                throw new InvalidDataException("Match equips an unknown recovered army family.");
            if(p.ArmyNormalUpgradeIndexes!=null)
                for(int i=0;i<p.ArmyNormalUpgradeIndexes.Length;i++)
                {
                    try
                    {
                        int? special=p.ArmySpecialUpgradeIndexes is { } specials && specials[i]>=0 ? specials[i] : null;
                        int? elite=p.ArmyEliteUpgradeIndexes is { } elites && elites[i]>=0 ? elites[i] : null;
                        _=Army.ComposeStats(p.EquippedArmyUnitIds![i],p.ArmyNormalUpgradeIndexes[i],special,elite);
                        if(p.ArmyHealthFactors is { } factors)
                            _=Army.EffectiveHealth(p.EquippedArmyUnitIds[i],p.ArmyNormalUpgradeIndexes[i],special,elite,factors[i]);
                        if(p.ArmyDamageScales is { } scales)
                            _=Army.EffectiveDamage(p.EquippedArmyUnitIds[i],p.ArmyNormalUpgradeIndexes[i],special,elite,scales[i]);
                        if(p.ArmySpeedCoefficients is { } speedCoefficients)
                            _=Army.EffectiveSpeed(p.EquippedArmyUnitIds[i],speedCoefficients[i],
                                p.ArmyNormalUpgradeIndexes![i],special,elite);
                        var family=Army.Families.Single(f=>f.UnitId==p.EquippedArmyUnitIds[i]);
                        if(family.BaseShot!=null)
                            _=Army.ComposeShot(p.EquippedArmyUnitIds[i],p.ArmyNormalUpgradeIndexes[i],special,elite,
                                p.ArmyAccuracyCoefficients?[i]??1f);
                    }
                    catch(ArgumentOutOfRangeException ex)
                    { throw new InvalidDataException("Allocated army upgrade stage is outside its recovered lane.",ex); }
                }
            if(p.ShieldLevel.HasValue)_=Shields.Health(p.ShieldLevel.Value);
            if(p.PlayerLevel.HasValue)_=BarrelPolicy.MaxHealth(p.PlayerLevel.Value);
            if (p.Weapon!=Expected(p.Weapon.SourceId,p.WeaponUpgrade!.Value))
                throw new InvalidDataException("Allocated weapon assertions differ from recovered source stage.");
            if(p.WeaponSlots is { } weaponSlots)
            {
                if(shotgun && weaponSlots.Length!=1)
                    throw new InvalidDataException("Shotgun multi-slot authority is not implemented.");
                foreach(var slot in weaponSlots)
                {
                    var expected=Expected(slot.Weapon.SourceId,slot.WeaponUpgrade);
                    if(slot.Weapon!=expected)throw new InvalidDataException("Equipped weapon slot differs from recovered source stage.");
                    var graph=AllWeaponBindings.Get(slot.Weapon.SourceId);
                    if(graph.InventoryIndex!=slot.WeaponIndex)
                        throw new InvalidDataException("Equipped weapon slot index differs from recovered binding authority.");
                    Binding(slot.Weapon.SourceId);
                }
            }
            // GameControllerOnline initializes each PlayerController at speed 1.
            // The War Arena rule may change it in another mode, but this unscored
            // rifle encounter has no validated Arena rule/season authority.
            if (manifest.Mode is MatchManifest.RifleCombatMode or MatchManifest.ShotgunCombatMode or MatchManifest.SmgCombatMode or MatchManifest.PistolCombatMode or MatchManifest.LmgCombatMode or MatchManifest.MinigunCombatMode or MatchManifest.SniperCombatMode or MatchManifest.BazookaCombatMode or MatchManifest.GrenadeCombatMode or MatchManifest.MixedCombatMode && p.MovementSpeed!=1f)
                throw new InvalidDataException("Source encounter requires the recovered default player speed.");
            Binding(p.Weapon.SourceId);
        }
    }
}
