using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using War.Backend.Hosting;
using War.Backend.Hosting.Configuration;
using War.BattleServer;
using War.Infrastructure;
using War.Persistence;

namespace War.Battle.Tests.Startup;

/// <summary>Checks startup policy before any database connection, collection initialization or listener.</summary>
internal static class BackendStartupPolicyTests
{
    private static readonly string SigningKey = Convert.ToBase64String(Enumerable.Repeat((byte)1, 32).ToArray());
    private static readonly string ControlKey = Convert.ToBase64String(Enumerable.Repeat((byte)2, 32).ToArray());

    internal static int Run()
    {
        CheckDefaultsAndFreeze();
        CheckSharedKeyRules();
        CheckPorts();
        CheckEndpoints();
        CheckRateLimits();
        CheckExplicitCatalogMode();
        CheckConfiguredContentCannotFallBack();
        CheckTemplateAdmission();
        CheckDatabaseErrors();
        CheckDeferredComposition();
        return 10;
    }

    internal static IConfigurationRoot CreateSettings()
    {
        return new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string?>
        {
            ["Battle:SigningKey"] = SigningKey,
            ["Battle:ControlKey"] = ControlKey,
            ["Legacy:AllowCatalogFreeStartup"] = "true"
        }).Build();
    }

    private static void CheckDefaultsAndFreeze()
    {
        IConfigurationRoot settings = CreateSettings();
        BackendDeploymentOptions snapshot = BackendDeploymentOptions.FromConfiguration(settings);
        long gold = snapshot.Legacy.Starter.Gold;
        settings["Battle:Port"] = "40000";
        settings["RateLimiting:Api:PermitLimit"] = "999";
        settings["Legacy:Starter:Gold"] = "7";
        settings["Battle:SigningKey"] = ControlKey;
        byte[] exposed = snapshot.Battle.Keys.ControlKey!;
        exposed[0] = 99;

        Require(snapshot.Battle.Port == 30000 && snapshot.Battle.Keys.SigningKey == SigningKey &&
            snapshot.Battle.Keys.ControlKey![0] == 2,
            "Configuration changes modified captured endpoint/key authority.");
        Require(snapshot.RateLimits.Api.PermitLimit == 120 &&
            snapshot.RateLimits.Auth.PermitLimit == 10 && snapshot.RateLimits.Api.Window.TotalSeconds == 60 &&
            snapshot.Legacy.Starter.Gold == gold, "Startup defaults or policy snapshot changed after capture.");
    }

    private static void CheckSharedKeyRules()
    {
        string?[] invalid = [null, "", "not base64", Convert.ToBase64String(new byte[31]),
            Convert.ToBase64String(new byte[32])];
        foreach (string setting in new[] { "Battle:SigningKey", "Battle:ControlKey" })
        {
            foreach (string? value in invalid)
            {
                IConfigurationRoot settings = CreateSettings();
                settings[setting] = value;
                RequireInvalid(() => BackendBattleOptions.FromConfiguration(settings));
                RequireInvalid(() => BattleKeyConfig.FromConfiguration(settings, requireControlKey: true));
            }
        }
        IConfigurationRoot identical = CreateSettings();
        identical["Battle:ControlKey"] = SigningKey;
        RequireInvalid(() => BackendBattleOptions.FromConfiguration(identical));
        RequireInvalid(() => BattleKeyConfig.FromConfiguration(identical, requireControlKey: true));
        RequireInvalid(() => new BattleTickets(Convert.ToBase64String(new byte[32])));
        RequireInvalid(() => new MatchTokens(Convert.ToBase64String(new byte[32])));
    }

    private static void CheckPorts()
    {
        foreach (string value in new[] { "0", "1023", "65536", "3.5", "NaN", "1e4", "" })
        {
            IConfigurationRoot settings = CreateSettings();
            settings["Battle:Port"] = value;
            RequireInvalid(() => BackendBattleOptions.FromConfiguration(settings));
            RequireInvalid(() => BattleRuntimeConfigValidator.FromConfiguration(settings));
        }
        foreach (string value in new[] { "0", "65536", "30000", "NaN", "" })
        {
            IConfigurationRoot settings = CreateSettings();
            settings["Battle:ControlPort"] = value;
            RequireInvalid(() => BackendBattleOptions.FromConfiguration(settings));
            RequireInvalid(() => BattleEndpointPolicy.ReadControlPort(value, 30000));
        }
        foreach (int port in new[] { 1024, 65535 })
        {
            IConfigurationRoot settings = CreateSettings();
            settings["Battle:Port"] = port.ToString(System.Globalization.CultureInfo.InvariantCulture);
            settings["Battle:ControlPort"] = "30001";
            Require(BackendBattleOptions.FromConfiguration(settings).Port == port &&
                BattleRuntimeConfigValidator.FromConfiguration(settings).Port == port,
                "Backend and Worker disagree on a supported UDP boundary.");
        }
    }

    private static void CheckEndpoints()
    {
        foreach (string value in new[] { "", "file:///tmp/endpoint", "http://user:pass@localhost/internal/matches",
            "http://localhost/internal/matches?x=1", "http://localhost/internal/matches#x",
            " http://localhost/internal/matches", "http://local\nhost/internal/matches", "http://localhost:0/" })
        {
            IConfigurationRoot settings = CreateSettings();
            settings["Battle:ControlEndpoint"] = value;
            settings["Battle:BackendResultEndpoint"] = value;
            RequireInvalid(() => BackendBattleOptions.FromConfiguration(settings));
            RequireInvalid(() => BattleWorkerSettings.FromConfiguration(settings, hasControlKey: true));
        }
        foreach (string value in new[] { "", "http://localhost", "host/path", " localhost", "localhost\n" })
        {
            IConfigurationRoot settings = CreateSettings();
            settings["Battle:PublicHost"] = value;
            RequireInvalid(() => BackendBattleOptions.FromConfiguration(settings));
            RequireInvalid(() => BattleWorkerSettings.FromConfiguration(settings, hasControlKey: true));
        }
    }

    private static void CheckRateLimits()
    {
        foreach (string family in new[] { "Api", "Auth" })
        {
            foreach (string field in new[] { "PermitLimit", "WindowSeconds" })
            {
                foreach (string value in new[] { "0", "-1", "1.5", "NaN", "1e2", "", "2147483648" })
                {
                    IConfigurationRoot settings = CreateSettings();
                    settings[$"RateLimiting:{family}:{field}"] = value;
                    RequireInvalid(() => BackendRateLimitOptions.FromConfiguration(settings));
                }
            }
        }
        IConfigurationRoot oversizedWindow = CreateSettings();
        oversizedWindow["RateLimiting:Api:WindowSeconds"] = "86401";
        RequireInvalid(() => BackendRateLimitOptions.FromConfiguration(oversizedWindow));
    }

    private static void CheckExplicitCatalogMode()
    {
        IConfigurationRoot settings = CreateSettings();
        settings["Legacy:AllowCatalogFreeStartup"] = null;
        RequireInvalid(() => BackendLegacyOptions.FromConfiguration(settings));
        settings["Legacy:AllowCatalogFreeStartup"] = "false";
        RequireInvalid(() => BackendLegacyOptions.FromConfiguration(settings));
        settings["Legacy:AllowCatalogFreeStartup"] = "yes";
        RequireInvalid(() => BackendLegacyOptions.FromConfiguration(settings));

        string server = FindServerDirectory();
        settings["Legacy:AllowCatalogFreeStartup"] = null;
        settings["Legacy:ContentPath"] = Path.Combine(server, "content/recovered-battle-content.json");
        BackendLegacyOptions source = BackendLegacyOptions.FromConfiguration(settings);
        Require(source.Catalog.IsLoaded && source.Starter.Gold == 75,
            "A configured source catalog lost its reviewed starter policy.");
    }

    private static void CheckConfiguredContentCannotFallBack()
    {
        foreach (string value in new[] { "", " ", Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".missing") })
        {
            IConfigurationRoot settings = CreateSettings();
            settings["Legacy:ContentPath"] = value;
            RequireInvalid(() => BackendLegacyOptions.FromConfiguration(settings));
            settings["Battle:MatchManifestTemplatePath"] = value;
            RequireInvalid(() => BackendBattleOptions.FromConfiguration(settings));
        }
        WithMalformedFile(path =>
        {
            IConfigurationRoot settings = CreateSettings();
            settings["Legacy:ContentPath"] = path;
            RequireInvalid(() => BackendLegacyOptions.FromConfiguration(settings));
        });
    }

    private static void CheckTemplateAdmission()
    {
        IConfigurationRoot missing = CreateSettings();
        missing["Battle:MatchmakingCompatibilityKey"] = "reviewed-rifle";
        RequireInvalid(() => BackendBattleOptions.FromConfiguration(missing));
        string content = Path.Combine(FindServerDirectory(), "content");
        IConfigurationRoot settings = CreateSettings();
        settings["Battle:MatchManifestTemplatePath"] = Path.Combine(content, "local-rifle-match-template.json");
        settings["Battle:CombatContentManifestPath"] = Path.Combine(content, "combat-content-manifest.json");
        BackendBattleOptions snapshot = BackendBattleOptions.FromConfiguration(settings);
        byte[] exposed = snapshot.Content.CopyTemplate();
        exposed[0] = 0;
        Require(snapshot.Content.IsConfigured && snapshot.Content.CopyTemplate()[0] != 0,
            "A caller rewrote the frozen template byte snapshot.");
        settings["Battle:ServerId"] = "another-host";
        RequireInvalid(() => BackendBattleOptions.FromConfiguration(settings));
        settings["Battle:ServerId"] = "local-1";
        WithMalformedFile(path =>
        {
            settings["Battle:MatchManifestTemplatePath"] = path;
            RequireInvalid(() => BackendBattleOptions.FromConfiguration(settings));
        });
    }

    private static void CheckDatabaseErrors()
    {
        IConfigurationRoot settings = CreateSettings();
        const string Credential = "startup-test-password";
        settings["Mongo:Uri"] = "invalid://user:" + Credential + "@localhost";
        InvalidDataException error = RequireInvalid(() => BackendDatabaseOptions.FromConfiguration(settings));
        Require(!error.ToString().Contains(Credential, StringComparison.Ordinal),
            "Database configuration failure exposed URI credential bytes.");
        settings["Mongo:Uri"] = "mongodb://127.0.0.1:1";
        foreach (string database in new[] { "bad-name", "", new string('a', 65) })
        {
            settings["Mongo:Database"] = database;
            RequireInvalid(() => BackendDatabaseOptions.FromConfiguration(settings));
        }
    }

    private static void CheckDeferredComposition()
    {
        BackendDeploymentOptions options = BackendDeploymentOptions.FromConfiguration(CreateSettings());
        WebApplicationBuilder builder = WebApplication.CreateBuilder(new WebApplicationOptions
        {
            EnvironmentName = "Development"
        });
        builder.Services.AddBackendServices(options);
        Require(builder.Services.Single(row => row.ServiceType == typeof(AccountStore)).ImplementationInstance == null,
            "Service registration constructed a database client eagerly.");
        using WebApplication app = builder.Build();
        _ = app.Services.GetRequiredService<BattleMatchControlClient>();
        _ = app.Services.GetRequiredService<BattleMatchCancellationClient>();
    }

    private static void WithMalformedFile(Action<string> check)
    {
        string directory = Directory.CreateTempSubdirectory("warfriends-startup-policy-").FullName;
        string path = Path.Combine(directory, "malformed.json");
        try
        {
            File.WriteAllText(path, "{}");
            check(path);
        }
        finally
        {
            File.Delete(path);
            Directory.Delete(directory);
        }
    }

    internal static string FindServerDirectory()
    {
        DirectoryInfo? directory = new(AppContext.BaseDirectory);
        while (directory != null &&
            !File.Exists(Path.Combine(directory.FullName, "content/combat-content-manifest.json")))
        {
            directory = directory.Parent;
        }
        return directory?.FullName ?? throw new InvalidOperationException("Server content directory is missing.");
    }

    private static InvalidDataException RequireInvalid(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException error)
        {
            return error;
        }
        throw new InvalidOperationException("Malformed deployment policy was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
