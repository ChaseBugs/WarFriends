using System.Security.Cryptography;
using Google.Protobuf;
using War.Backend.Application;
using War.Backend.Hosting.Configuration;
using War.Infrastructure;
using War.Protocol;
using static War.Backend.Application.ApplicationFailureKind;

namespace War.Backend.Features.Network;

/// <summary>Issues only connectivity tickets; this use case never enters a match or grants rewards.</summary>
public sealed class ConnectivityProbeService
{
    private const int SessionIdBytes = sizeof(ulong);
    private readonly BattleTickets _tickets;
    private readonly BackendBattleOptions _deployment;

    public ConnectivityProbeService(BattleTickets tickets, BackendBattleOptions deployment)
    {
        _tickets = tickets;
        _deployment = deployment;
    }

    public ApplicationResult<ConnectionGrant> Issue(PlayerProfile player, ConnectionRequest request)
    {
        if (request.Protocol != "war.v1")
        {
            return ApplicationResult<ConnectionGrant>.Reject(InvalidRequest,
                "protocol_version", "Expected war.v1.");
        }

        ulong sessionId;
        do
        {
            sessionId = BitConverter.ToUInt64(RandomNumberGenerator.GetBytes(SessionIdBytes));
        }
        while (sessionId == 0);

        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        var claims = new TicketClaims
        {
            PlayerId = player.PlayerId,
            ServerId = _deployment.ServerId,
            SessionId = sessionId,
            IssuedUnixSeconds = now,
            ExpiresUnixSeconds = now + BattleTickets.LifetimeSeconds,
            Purpose = "connectivity-probe"
        };
        return ApplicationResult<ConnectionGrant>.Success(new ConnectionGrant
        {
            Host = _deployment.PublicHost,
            Port = (uint)_deployment.Port,
            Ticket = _tickets.Sign(claims),
            SessionKey = ByteString.CopyFrom(_tickets.SessionKey(sessionId)),
            SessionId = sessionId,
            ExpiresUnixSeconds = claims.ExpiresUnixSeconds
        });
    }
}
