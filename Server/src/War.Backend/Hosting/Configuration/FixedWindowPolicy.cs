using War.Infrastructure;

namespace War.Backend.Hosting.Configuration;

/// <summary>Positive supported limiter values, frozen before the first partition is created.</summary>
public sealed class FixedWindowPolicy
{
    private const int MaximumWindowSeconds = 86400;

    private FixedWindowPolicy(int permitLimit, int windowSeconds)
    {
        PermitLimit = permitLimit;
        Window = TimeSpan.FromSeconds(windowSeconds);
    }

    public int PermitLimit { get; }

    public TimeSpan Window { get; }

    public static FixedWindowPolicy FromConfiguration(IConfiguration configuration, string prefix,
        int defaultPermits, int defaultWindowSeconds)
    {
        int permits = DeploymentValueParser.ReadInt32(configuration[prefix + ":PermitLimit"],
            prefix + ":PermitLimit", defaultPermits);
        int seconds = DeploymentValueParser.ReadInt32(configuration[prefix + ":WindowSeconds"],
            prefix + ":WindowSeconds", defaultWindowSeconds);
        if (permits <= 0 || seconds is < 1 or > MaximumWindowSeconds)
        {
            throw new InvalidDataException(
                prefix + " needs positive permits and a window from 1 through 86400 seconds.");
        }
        return new FixedWindowPolicy(permits, seconds);
    }
}
