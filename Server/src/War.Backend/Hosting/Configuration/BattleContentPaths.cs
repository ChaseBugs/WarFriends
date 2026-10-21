namespace War.Backend.Hosting.Configuration;

/// <summary>Captures supplied files once; an empty or missing configured path cannot disable content.</summary>
public sealed class BattleContentPaths
{
    private BattleContentPaths(IConfiguration configuration)
    {
        Template = Read(configuration, "MatchManifestTemplatePath");
        Combat = Read(configuration, "CombatContentManifestPath");
        Shotgun = Read(configuration, "ShotgunContentManifestPath");
        Smg = Read(configuration, "SmgContentManifestPath");
        Pistol = Read(configuration, "PistolContentManifestPath");
        Lmg = Read(configuration, "LmgContentManifestPath");
        Minigun = Read(configuration, "MinigunContentManifestPath");
        Sniper = Read(configuration, "SniperContentManifestPath");
        Bazooka = Read(configuration, "BazookaContentManifestPath");
        Grenade = Read(configuration, "GrenadeContentManifestPath");
        if (Combat == null && new[] { Shotgun, Smg, Pistol, Lmg, Minigun, Sniper, Bazooka, Grenade }
            .Any(path => path != null))
        {
            throw new InvalidDataException("Weapon content requires Battle:CombatContentManifestPath.");
        }
    }

    public string? Template { get; }

    public string? Combat { get; }

    public string? Shotgun { get; }

    public string? Smg { get; }

    public string? Pistol { get; }

    public string? Lmg { get; }

    public string? Minigun { get; }

    public string? Sniper { get; }

    public string? Bazooka { get; }

    public string? Grenade { get; }

    public static BattleContentPaths FromConfiguration(IConfiguration configuration)
    {
        return new BattleContentPaths(configuration);
    }

    private static string? Read(IConfiguration configuration, string name)
    {
        return BackendConfigurationPaths.ReadOptionalFile(configuration, "Battle:" + name);
    }
}
