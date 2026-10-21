namespace War.Backend.Hosting.Configuration;

/// <summary>Resolve once before creating stores, initializing collections or accepting requests.</summary>
public sealed class BackendDeploymentOptions
{
    private BackendDeploymentOptions(BackendDatabaseOptions database, BackendRateLimitOptions rateLimits,
        BackendBattleOptions battle, BackendLegacyOptions legacy)
    {
        Database = database;
        RateLimits = rateLimits;
        Battle = battle;
        Legacy = legacy;
    }

    public BackendDatabaseOptions Database { get; }

    public BackendRateLimitOptions RateLimits { get; }

    public BackendBattleOptions Battle { get; }

    public BackendLegacyOptions Legacy { get; }

    public static BackendDeploymentOptions FromConfiguration(IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);
        try
        {
            BackendDatabaseOptions database = BackendDatabaseOptions.FromConfiguration(configuration);
            BackendRateLimitOptions rateLimits = BackendRateLimitOptions.FromConfiguration(configuration);
            BackendBattleOptions battle = BackendBattleOptions.FromConfiguration(configuration);
            BackendLegacyOptions legacy = BackendLegacyOptions.FromConfiguration(configuration);
            return new BackendDeploymentOptions(database, rateLimits, battle, legacy);
        }
        catch (Exception error) when (error is not InvalidDataException &&
            error is ArgumentException or FormatException or InvalidOperationException or IOException or
                System.Text.Json.JsonException)
        {
            throw new InvalidDataException("Invalid Backend deployment configuration.");
        }
    }
}
