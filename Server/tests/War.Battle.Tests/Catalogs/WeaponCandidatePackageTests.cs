using War.BattleServer;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.Battle.Tests.Catalogs;

public static class WeaponCandidatePackageTests
{
    public static void RunCombat(string directory)
    {
        string root = Path.GetFullPath(directory);
        BattleCombatContent.Load(
            Path.Combine(root, "combat-content-manifest.json"),
            Path.Combine(root, "shotgun-content-manifest.json"),
            Path.Combine(root, "smg-content-manifest.json"),
            Path.Combine(root, "pistol-content-manifest.json"),
            Path.Combine(root, "lmg-content-manifest.json"),
            Path.Combine(root, "minigun-content-manifest.json"),
            Path.Combine(root, "sniper-content-manifest.json"),
            Path.Combine(root, "bazooka-content-manifest.json"),
            Path.Combine(root, "grenade-content-manifest.json"));
    }

    public static void Run(string directory)
    {
        string root = Path.GetFullPath(directory);
        if (!Directory.Exists(root))
        {
            throw new DirectoryNotFoundException(root);
        }

        // Exercise production loaders against candidate bytes, without replacing deployed content.
        ShotgunCatalog.Load(Path.Combine(root, "shotgun-content-manifest.json"));
        SmgCatalog.Load(Path.Combine(root, "smg-content-manifest.json"));
        PistolCatalog.Load(Path.Combine(root, "pistol-content-manifest.json"));
        LmgCatalog.Load(Path.Combine(root, "lmg-content-manifest.json"));
        MinigunCatalog.Load(Path.Combine(root, "minigun-content-manifest.json"));
        SniperCatalog.Load(Path.Combine(root, "sniper-content-manifest.json"));
        BazookaCatalog.Load(Path.Combine(root, "bazooka-content-manifest.json"));
        GrenadeCatalog.Load(Path.Combine(root, "grenade-content-manifest.json"));
        VerifyLandMineSceneBinding(root);
        VerifyHeavyTurretSceneBinding(root);
        VerifyMortarRevisionPolicy();
        VerifyMortarArtifactBinding(root);
        VerifyAssaulterBinding(root);
        AirGeometryInventoryTests.Run(root);
        GrenadeTargetEvidenceTests.Run(root);
        PvpBonusEvidenceTests.Run(root);
        PvpScoreStreakEvidenceTests.Run(root);
        PvpSkillShotEvidenceTests.Run(root);
        CandidateWeaponIndexTests.Run(root);
        War.Backend.BattleRifleManifestCatalog.Load(Path.Combine(root, "combat-content-manifest.json"));
    }

    private static void VerifyAssaulterBinding(string root)
    {
        using var document = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(root, "combat-content-manifest.json")));
        var manifest = document.RootElement;
        string scene = manifest.GetProperty("SceneRevision").GetString()!;
        string? declared = manifest.TryGetProperty("CoopAssaulterWeaponRevision", out var value)
            ? value.GetString() : null;
        string revision = CombatManifestRevisionPolicy.ResolveAssaulterWeapon(
            manifest.GetProperty("Version").GetInt32(), declared);
        string path = Path.Combine(root, "recovered-coop-assaulter-weapon.json");
        CoopAssaulterWeaponCatalog.Load(path, scene, revision);

        (string Scene, string Revision)[] invalid = [(new string('0', 64), revision), (scene, new string('0', 64))];
        foreach (var candidate in invalid)
        {
            try
            {
                CoopAssaulterWeaponCatalog.Load(path, candidate.Scene, candidate.Revision);
            }
            catch (InvalidDataException)
            {
                continue;
            }

            throw new InvalidOperationException("Assaulter accepted mismatched scene/artifact authority.");
        }
    }

    private static void VerifyMortarArtifactBinding(string root)
    {
        using var document = JsonDocument.Parse(File.ReadAllBytes(Path.Combine(root, "combat-content-manifest.json")));
        var manifest = document.RootElement;
        string scene = manifest.GetProperty("SceneRevision").GetString()!;
        string armyRevision = manifest.GetProperty("ArmyDeploymentRevision").GetString()!;
        var army = ArmyDeploymentCatalog.Load(Path.Combine(root, "recovered-army-deployment.json"), armyRevision, scene);

        try
        {
            MortarWeaponPoolSource.Load(Path.Combine(root, "recovered-mortar-weapon-pool.json"),
                army, scene, new string('0', 64));
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Mortar pool accepted a mismatched expected artifact revision.");
    }

    private static void VerifyMortarRevisionPolicy()
    {
        string revision = new string('a', 64);
        if (CombatManifestRevisionPolicy.ResolveMortarPool(13, null) != MortarWeaponPoolSource.VerifiedRevision ||
            CombatManifestRevisionPolicy.ResolveMortarPool(14, revision) != revision)
        {
            throw new InvalidOperationException("Combat manifest revision policy lost a supported version.");
        }

        (int Version, string? Revision)[] invalid = [(13, revision), (14, null), (14, "bad"),
            (14, new string('A', 64)), (15, revision)];
        foreach (var value in invalid)
        {
            try
            {
                CombatManifestRevisionPolicy.ResolveMortarPool(value.Version, value.Revision);
            }
            catch (InvalidDataException)
            {
                continue;
            }

            throw new InvalidOperationException("Combat manifest accepted an invalid version/revision pair.");
        }
    }

    private static void VerifyHeavyTurretSceneBinding(string root)
    {
        string statsPath = Path.Combine(root, "recovered-battle-content.json");
        using var stats = JsonDocument.Parse(File.ReadAllBytes(statsPath));
        string sceneRevision = stats.RootElement.GetProperty("mainSceneSha256").GetString()!;
        string path = Path.Combine(root, "recovered-heavy-turret-source.json");
        string revision = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(path)));
        var maps = RecoveredBattleMap.Load(statsPath);
        HeavyTurretSourceCatalog.Load(path, revision, maps, sceneRevision);

        try
        {
            HeavyTurretSourceCatalog.Load(path, revision, maps, new string('0', 64));
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Heavy Turret accepted a different expected scene revision.");
    }

    private static void VerifyLandMineSceneBinding(string root)
    {
        string statsPath = Path.Combine(root, "recovered-battle-content.json");
        using var stats = JsonDocument.Parse(File.ReadAllBytes(statsPath));
        string sceneRevision = stats.RootElement.GetProperty("mainSceneSha256").GetString()!;
        string path = Path.Combine(root, "recovered-landmine-source.json");
        string revision = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(path)));
        var maps = RecoveredBattleMap.Load(statsPath);
        LandMineSourceCatalog.Load(path, revision, maps, sceneRevision);

        try
        {
            LandMineSourceCatalog.Load(path, revision, maps, new string('0', 64));
        }
        catch (InvalidDataException)
        {
            return;
        }

        throw new InvalidOperationException("Land Mine accepted a different expected scene revision.");
    }
}
