using War.Persistence;
using War.Persistence.Legacy.Accounts;

namespace War.Backend.Legacy.Accounts;

/// <summary>Builds server-owned starter state and delegates one-document credential/session publication.</summary>
public sealed class LegacyAccountService
{
    private readonly LegacyPlayerStore _store;
    private readonly LegacyStarterPolicy _policy;

    public LegacyAccountService(LegacyPlayerStore store, LegacyStarterPolicy policy)
    {
        policy.Validate();
        LegacyInitialLoadout.Validate();
        _store = store;
        _policy = policy;
    }

    public Task<LegacyAccountCreated> CreateAsync(
        LegacyAccountRegistration registration, CancellationToken cancellationToken)
    {
        registration.Validate();
        int now = checked((int)DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        var player = new LegacyPlayerDocument
        {
            Name = "Recruit",
            AccountType = (int)LegacyAccountType.Guest,
            Level = _policy.Level,
            Gold = _policy.Gold,
            WarBucks = _policy.WarBucks,
            Tickets = _policy.Tickets,
            Scraps = _policy.Scraps,
            DogTagMax = _policy.DogTagMax,
            PlacementMatchesRequired = _policy.PlacementMatchesRequired,
            BeginnersLeague = 1,
            SquadRank = -1,
            Serialized = LegacyInitialLoadout.CreateSerializedState()
        };
        return _store.CreateAccountAsync(new LegacyAccountCreation
        {
            Player = player,
            Registration = registration,
            NowUnixSeconds = now,
            SessionLifetimeHours = _policy.SessionLifetimeHours
        }, cancellationToken);
    }

    public async Task<LegacySessionIssued?> LoginAsync(
        string id, string password, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument? player = await _store.VerifyPassword(id, password, cancellationToken);
        return player == null ? null : await _store.RotateSessionAsync(player,
            _policy.SessionLifetimeHours, cancellationToken);
    }
}
