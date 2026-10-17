using System;

/// <summary>Shares one process endpoint override between recovered HTTP actions and the battle SDK.</summary>
public static class SelfHostedBackendEndpoint
{
    /// <summary>Uses the native Backend's local development port.</summary>
    public const string DefaultBackendUrl = "http://127.0.0.1:8080/";

    /// <summary>Overrides recovered HTTP and normal battle-session routing together.</summary>
    public const string EnvironmentVariableName = "WARFRIENDS_BACKEND_URL";
    private const string LegacyActionFile = "index_09_25_2015.php";
    private static readonly string ProcessBackendUrl =
        Environment.GetEnvironmentVariable(EnvironmentVariableName) ?? string.Empty;

    /// <summary>Resolves a Backend directory URL without falling back to any retired service.</summary>
    public static Uri Resolve(string configuredBackendUrl = DefaultBackendUrl)
    {
        string backendUrl = string.IsNullOrEmpty(ProcessBackendUrl) ? configuredBackendUrl : ProcessBackendUrl;
        Uri endpoint;
        if (string.IsNullOrEmpty(backendUrl) || backendUrl != backendUrl.Trim() ||
            !Uri.TryCreate(backendUrl, UriKind.Absolute, out endpoint) ||
            endpoint.UserInfo.Length != 0 || endpoint.Query.Length != 0 || endpoint.Fragment.Length != 0 ||
            !endpoint.AbsolutePath.EndsWith("/", StringComparison.Ordinal))
        {
            throw new ArgumentException("The Backend must be an absolute directory URL without credentials or query.");
        }

        bool isHttps = endpoint.Scheme == Uri.UriSchemeHttps;
        bool isLoopbackHttp = endpoint.Scheme == Uri.UriSchemeHttp && endpoint.IsLoopback;
        if (!isHttps && !isLoopbackHttp)
        {
            throw new ArgumentException("The Backend requires HTTPS or loopback HTTP for local testing.");
        }

        return endpoint;
    }

    /// <summary>Preserves the recovered action filename and sibling check.php location.</summary>
    public static string GetLegacyActionUrl()
    {
        return new Uri(Resolve(), LegacyActionFile).AbsoluteUri;
    }
}
