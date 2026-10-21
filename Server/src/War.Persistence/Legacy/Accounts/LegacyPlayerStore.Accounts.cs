using System.Security.Cryptography;
using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Analytics;
using War.Persistence.Legacy.Tutorial;
using War.Persistence.Legacy.State;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    private const int SessionRotationAttempts = 4;

    /// <summary>Publishes credentials, initial session, metadata and starter state in one document insert.</summary>
    public async Task<LegacyAccountCreated> CreateAccountAsync(
        LegacyAccountCreation creation, CancellationToken cancellationToken)
    {
        DateTime nowUtc = ValidateAccountCreation(creation);
        DateTime expiry = LegacySessionAuthority.Expiry(nowUtc, creation.SessionLifetimeHours);
        cancellationToken.ThrowIfCancellationRequested();
        LegacyPlayerDocument player = creation.Player;
        string password = NewPassword();
        string token = NewToken();
        player.Id = Guid.NewGuid().ToString("N");
        LegacyPlayerIdentityAuthority.Validate(player);
        player.Locale = creation.Registration.Locale;
        player.DeviceToken = creation.Registration.DeviceToken ?? "";
        player.InitialUtcOffsetHours = creation.Registration.UtcOffsetHours;
        player.CreatedUtc = nowUtc;
        player.LastAction = creation.NowUnixSeconds;
        player.DogTagLastUpdate = creation.NowUnixSeconds;
        player.SessionHash = HashToken(token);
        player.SessionExpiresUtc = expiry;
        player.Salt = RandomNumberGenerator.GetBytes(LegacyPasswordAuthority.SaltBytes);
        player.PasswordIterations = LegacyPasswordAuthority.Iterations;
        player.PasswordHash = LegacyPasswordAuthority.Derive(password, player.Salt);
        await players.InsertOneAsync(player, cancellationToken: cancellationToken);
        return new LegacyAccountCreated(player, token, password);
    }

    /// <summary>Rotates only a still-valid verified account and returns its committed revision.</summary>
    public async Task<LegacySessionIssued?> RotateSessionAsync(
        LegacyPlayerDocument verified, int lifetimeHours, CancellationToken cancellationToken)
    {
        DateTime nowUtc = DateTime.UtcNow;
        DateTime expiry = LegacySessionAuthority.Expiry(nowUtc, lifetimeHours);
        string token = NewToken();
        string hash = HashToken(token);
        for (int attempt = 0; attempt < SessionRotationAttempts; attempt++)
        {
            LegacyPlayerDocument? current = await ById(verified.Id, cancellationToken);
            if (current == null || !MatchesVerifiedCredential(current, verified))
            {
                return null;
            }

            LegacySessionAuthority.ValidateStored(current, nowUtc);
            War.Persistence.Legacy.Preferences.LegacySettingsSnapshot.ValidateContainer(current.Serialized);
            var update = Builders<LegacyPlayerDocument>.Update.Set(row => row.SessionHash, hash)
                .Set(row => row.SessionExpiresUtc, expiry).Inc(row => row.Revision, 1);
            LegacyPlayerDocument? committed = await players.FindOneAndUpdateAsync(
                row => row.Id == current.Id && row.Revision == current.Revision, update,
                new FindOneAndUpdateOptions<LegacyPlayerDocument> { ReturnDocument = ReturnDocument.After },
                cancellationToken);
            if (committed != null)
            {
                return new LegacySessionIssued(committed, token);
            }
        }

        return null;
    }

    private static DateTime ValidateAccountCreation(LegacyAccountCreation creation)
    {
        creation.Registration.Validate();
        LegacyPlayerDocument player = creation.Player;
        LegacyPlayerEconomyAuthority.Validate(player);
        LegacyAnalyticsState.ValidateContainer(player.Serialized);
        LegacyTutorialAuthority.ValidateForRead(player);
        if (creation.Registration.GameCenterId != null || creation.NowUnixSeconds < 0 ||
            !string.IsNullOrEmpty(player.Id) || !string.IsNullOrEmpty(player.SessionHash) ||
            player.Gold < 0 || player.WarBucks < 0 || player.Tickets < 0 || player.Scraps < 0 ||
            player.Level is < 0 or >= LegacyAccountCreation.RecoveredRankCount ||
            player.DogTagMax <= 0 || player.DogTagSeconds < 0 ||
            player.DogTagSeconds > player.DogTagMax || player.PlacementMatchesRequired < 0 || player.Revision != 1 ||
            player.Serialized == null || player.AccountType != 0 || player.TutorialCompleted ||
            player.PendingTutorialBattleId != null || player.TutorialState != null)
        {
            throw new InvalidDataException("Invalid legacy guest starter account.");
        }

        return DateTimeOffset.FromUnixTimeSeconds(creation.NowUnixSeconds).UtcDateTime;
    }

    private static bool MatchesVerifiedCredential(LegacyPlayerDocument current, LegacyPlayerDocument verified) =>
        current.PasswordIterations == LegacyPasswordAuthority.Iterations &&
        verified.PasswordIterations == current.PasswordIterations &&
        current.Salt != null && verified.Salt != null &&
        current.PasswordHash != null && verified.PasswordHash != null &&
        current.Salt.Length == LegacyPasswordAuthority.SaltBytes && verified.Salt.Length == current.Salt.Length &&
        current.PasswordHash.Length == LegacyPasswordAuthority.HashBytes &&
        verified.PasswordHash.Length == current.PasswordHash.Length &&
        CryptographicOperations.FixedTimeEquals(current.Salt, verified.Salt) &&
        CryptographicOperations.FixedTimeEquals(current.PasswordHash, verified.PasswordHash);
}
