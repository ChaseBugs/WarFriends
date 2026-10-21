namespace War.Backend.Hosting.Configuration;

/// <summary>The existing API/auth defaults remain explicit and independent.</summary>
public sealed class BackendRateLimitOptions
{
    private const int DefaultApiPermits = 120;
    private const int DefaultAuthPermits = 10;
    private const int DefaultWindowSeconds = 60;

    private BackendRateLimitOptions(FixedWindowPolicy api, FixedWindowPolicy auth)
    {
        Api = api;
        Auth = auth;
    }

    public FixedWindowPolicy Api { get; }

    public FixedWindowPolicy Auth { get; }

    public static BackendRateLimitOptions FromConfiguration(IConfiguration configuration)
    {
        FixedWindowPolicy api = FixedWindowPolicy.FromConfiguration(configuration, "RateLimiting:Api",
            DefaultApiPermits, DefaultWindowSeconds);
        FixedWindowPolicy auth = FixedWindowPolicy.FromConfiguration(configuration, "RateLimiting:Auth",
            DefaultAuthPermits, DefaultWindowSeconds);
        return new BackendRateLimitOptions(api, auth);
    }
}
