using System.Text.RegularExpressions;

namespace War.Infrastructure;

/// <summary>Common endpoint constraints captured by Backend and Worker before opening listeners.</summary>
public static class BattleEndpointPolicy
{
    public const int DefaultUdpPort = 30000;
    private const int MinimumUdpPort = 1024;
    private const int MaximumPort = ushort.MaxValue;

    public static void ValidateUdpPort(int port)
    {
        if (port is < MinimumUdpPort or > MaximumPort)
        {
            throw new InvalidDataException("Battle:Port must be between 1024 and 65535.");
        }
    }

    public static int ReadControlPort(string? value, int udpPort)
    {
        ValidateUdpPort(udpPort);
        int port = DeploymentValueParser.ReadInt32(value, "Battle:ControlPort", udpPort + 1);
        if (port is < 1 or > MaximumPort || port == udpPort)
        {
            throw new InvalidDataException("Battle:ControlPort must be 1-65535 and differ from Battle:Port.");
        }
        return port;
    }

    public static void ValidateServerId(string serverId)
    {
        if (serverId == null || !Regex.IsMatch(serverId, @"\A[a-zA-Z0-9-]{1,64}\z"))
        {
            throw new InvalidDataException("Invalid Battle:ServerId.");
        }
    }

    public static void ValidatePublicHost(string publicHost)
    {
        if (string.IsNullOrWhiteSpace(publicHost) || publicHost != publicHost.Trim() ||
            publicHost.Any(char.IsControl) || Uri.CheckHostName(publicHost) == UriHostNameType.Unknown)
        {
            throw new InvalidDataException("Invalid Battle:PublicHost.");
        }
    }

    public static Uri ReadHttpEndpoint(string value, string setting)
    {
        if (string.IsNullOrWhiteSpace(value) || value != value.Trim() || value.Any(char.IsControl) ||
            !Uri.TryCreate(value, UriKind.Absolute, out Uri? endpoint) ||
            endpoint.Scheme is not ("http" or "https") || endpoint.Port < 1 || endpoint.UserInfo.Length != 0 ||
            endpoint.Query.Length != 0 || endpoint.Fragment.Length != 0)
        {
            throw new InvalidDataException(
                setting + " must be an absolute HTTP(S) endpoint without credentials/query/fragment.");
        }
        return endpoint;
    }
}
