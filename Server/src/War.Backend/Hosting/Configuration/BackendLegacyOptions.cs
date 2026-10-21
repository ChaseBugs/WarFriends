using War.Backend.Legacy;
using War.Backend.Legacy.Accounts;
using War.Infrastructure;
using War.Backend.Features.Battle.Settlement;

namespace War.Backend.Hosting.Configuration;

/// <summary>Source-backed startup or an explicit catalog-free compatibility choice.</summary>
public sealed class BackendLegacyOptions
{
    private BackendLegacyOptions(LegacyCatalog catalog, LegacyStarterPolicy starter,
        bool allowInsecureHttp, BattleRewardPolicy? rewards)
    {
        Catalog = catalog;
        Starter = starter;
        AllowInsecureHttp = allowInsecureHttp;
        Rewards = rewards;
    }

    public LegacyCatalog Catalog { get; }

    public LegacyStarterPolicy Starter { get; }

    public bool AllowInsecureHttp { get; }
    public BattleRewardPolicy? Rewards { get; }

    public static BackendLegacyOptions FromConfiguration(IConfiguration configuration)
    {
        string? path = BackendConfigurationPaths.ReadOptionalFile(configuration, "Legacy:ContentPath");
        bool allowCatalogFree = DeploymentValueParser.ReadBoolean(configuration["Legacy:AllowCatalogFreeStartup"],
            "Legacy:AllowCatalogFreeStartup", false);
        if (path == null && !allowCatalogFree)
        {
            throw new InvalidDataException(
                "Set Legacy:ContentPath or explicitly enable Legacy:AllowCatalogFreeStartup.");
        }

        LegacyCatalog catalog = LegacyCatalog.LoadConfigured(path);
        LegacyStarterState starterOptions = LegacyStarterState.FromCatalog(catalog);
        configuration.GetSection("Legacy:Starter").Bind(starterOptions);
        LegacyStarterPolicy starter = LegacyStarterPolicy.FromOptions(starterOptions);
        bool allowInsecureHttp = DeploymentValueParser.ReadBoolean(configuration["Legacy:AllowInsecureHttp"],
            "Legacy:AllowInsecureHttp", false);
        BattleRewardPolicy? rewards = catalog.IsLoaded ? BattleRewardPolicy.Create(catalog, configuration) : null;
        return new BackendLegacyOptions(catalog, starter, allowInsecureHttp, rewards);
    }
}
