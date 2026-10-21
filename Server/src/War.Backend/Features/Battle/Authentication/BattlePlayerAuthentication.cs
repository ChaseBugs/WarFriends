using War.Persistence;
using War.Protocol;

namespace War.Backend.Features.Battle.Authentication;

/// <summary>Preserves modern-session-first authentication and the recovered-session fallback.</summary>
public sealed class BattlePlayerAuthentication
{
    private readonly AccountStore _accounts;
    private readonly LegacyPlayerStore _legacy;

    public BattlePlayerAuthentication(AccountStore accounts, LegacyPlayerStore legacy)
    {
        _accounts = accounts;
        _legacy = legacy;
    }

    public async Task<string?> AuthenticateAsync(string token, CancellationToken cancellationToken)
    {
        PlayerProfile? modern = await _accounts.Authenticate(token, cancellationToken);
        if (modern != null)
        {
            return modern.PlayerId;
        }

        LegacyPlayerDocument? recovered = await _legacy.AuthenticateToken(token, cancellationToken);
        return recovered?.Id;
    }
}
