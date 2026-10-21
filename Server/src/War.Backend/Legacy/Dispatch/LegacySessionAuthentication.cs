using War.Persistence;

namespace War.Backend.Legacy.Dispatch;

public sealed class LegacySessionAuthentication : ILegacySessionAuthentication
{
    private readonly LegacyPlayerStore _players;

    public LegacySessionAuthentication(LegacyPlayerStore players)
    {
        _players = players;
    }

    public Task<LegacyPlayerDocument?> AuthenticateAsync(LegacyRequest request, CancellationToken cancellationToken)
    {
        return _players.Authenticate(request.Token, request.PlayerId, cancellationToken);
    }
}
