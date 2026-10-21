using System.Text.Json;
using War.BattleServer;

namespace War.Backend.Hosting.Configuration;

/// <summary>Loads source catalogs and validates the selected template before any database initialization.</summary>
public sealed class BattleContentStartupOptions
{
    private const int MaximumTemplateBytes = 65536;
    private readonly byte[]? _template;

    private BattleContentStartupOptions(BattleContentPaths paths, string serverId)
    {
        if (paths.Template == null)
        {
            return;
        }

        byte[] template = ReadTemplate(paths.Template);
        using JsonDocument document = JsonDocument.Parse(template);
        if (!document.RootElement.TryGetProperty("ServerId", out JsonElement owner) ||
            owner.ValueKind != JsonValueKind.String || owner.GetString() != serverId)
        {
            throw new InvalidDataException("Battle template ServerId must match Battle:ServerId.");
        }
        if (!document.RootElement.TryGetProperty("Mode", out JsonElement mode) ||
            mode.ValueKind != JsonValueKind.String)
        {
            throw new InvalidDataException("Battle template needs a supported Mode.");
        }
        Weapons = LoadWeapons(paths, mode.GetString()!);
        _ = BattleManifestTemplate.Parse(template, Weapons);
        _template = template;
    }

    public IBattleWeaponManifestCatalog? Weapons { get; }

    public bool IsConfigured => _template != null;

    public byte[] CopyTemplate()
    {
        return _template?.ToArray() ?? throw new InvalidDataException("Battle provisioning is not configured.");
    }

    public static BattleContentStartupOptions FromPaths(BattleContentPaths paths, string serverId)
    {
        return new BattleContentStartupOptions(paths, serverId);
    }

    private static byte[] ReadTemplate(string path)
    {
        using FileStream stream = File.OpenRead(path);
        if (stream.Length is < 2 or > MaximumTemplateBytes)
        {
            throw new InvalidDataException("Invalid battle manifest template size.");
        }
        byte[] bytes = new byte[(int)stream.Length];
        stream.ReadExactly(bytes);
        return bytes;
    }

    private static IBattleWeaponManifestCatalog LoadWeapons(BattleContentPaths paths, string mode)
    {
        string combat = BackendConfigurationPaths.Require(paths.Combat, "Battle:CombatContentManifestPath");
        BattleRifleManifestCatalog rifles = BattleRifleManifestCatalog.Load(combat);
        return mode switch
        {
            MatchManifest.RifleCombatMode => rifles,
            MatchManifest.ShotgunCombatMode => BattleShotgunManifestCatalog.Load(
                BackendConfigurationPaths.Require(paths.Shotgun, "Battle:ShotgunContentManifestPath"), rifles),
            MatchManifest.MixedCombatMode => new BattleMixedManifestCatalog(BattleCombatContent.Load(combat,
                BackendConfigurationPaths.Require(paths.Shotgun, "Battle:ShotgunContentManifestPath"),
                BackendConfigurationPaths.Require(paths.Smg, "Battle:SmgContentManifestPath"),
                BackendConfigurationPaths.Require(paths.Pistol, "Battle:PistolContentManifestPath"),
                BackendConfigurationPaths.Require(paths.Lmg, "Battle:LmgContentManifestPath"),
                BackendConfigurationPaths.Require(paths.Minigun, "Battle:MinigunContentManifestPath"),
                BackendConfigurationPaths.Require(paths.Sniper, "Battle:SniperContentManifestPath"),
                paths.Bazooka, paths.Grenade)),
            _ => throw new InvalidDataException("Unsupported battle manifest template mode.")
        };
    }
}
