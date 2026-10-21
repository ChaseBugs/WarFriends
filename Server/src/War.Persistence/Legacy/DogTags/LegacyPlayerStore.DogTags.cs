using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.DogTags;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    private const int MaximumDogTagAttempts = 8;

    /// <summary>Recalculates after definite revision conflicts; never retries an uncertain applied write.</summary>
    public async Task<LegacyDogTagResult?> ApplyDogTagAsync(
        LegacyPlayerDocument authenticated,
        DateTimeOffset applicationTime,
        Func<LegacyPlayerDocument, LegacyDogTagMutation> plan,
        CancellationToken cancellationToken)
    {
        long unixSeconds = applicationTime.ToUnixTimeSeconds();
        if (unixSeconds is < 0 or > int.MaxValue)
        {
            throw new InvalidDataException("Invalid dog-tag application time.");
        }

        int now = (int)unixSeconds;
        DateTime requestTime = applicationTime.UtcDateTime;
        for (int attempt = 0; attempt < MaximumDogTagAttempts; attempt++)
        {
            LegacyPlayerDocument? current = await ById(authenticated.Id, cancellationToken);
            if (current == null || current.SessionHash != authenticated.SessionHash ||
                current.SessionExpiresUtc <= requestTime)
            {
                return null;
            }

            LegacySessionAuthority.ValidateStored(current, requestTime);
            LegacyDogTagAuthority.ValidateStored(current, now);
            LegacyDogTagMutation mutation = plan(current);
            if (mutation.Outcome is LegacyDogTagOutcome.Unchanged or LegacyDogTagOutcome.NotEnoughGold)
            {
                return new LegacyDogTagResult(current, mutation.Outcome);
            }

            ValidateDogTagSuccessor(current, mutation, now);
            var update = Builders<LegacyPlayerDocument>.Update
                .Set(player => player.DogTagSeconds, mutation.Seconds)
                .Set(player => player.DogTagLastUpdate, mutation.LastUpdate)
                .Set(player => player.Gold, mutation.Gold)
                .Inc(player => player.Revision, 1);
            LegacyPlayerDocument? committed = await players.FindOneAndUpdateAsync(
                player => player.Id == current.Id && player.Revision == current.Revision &&
                    player.SessionHash == authenticated.SessionHash,
                update, new FindOneAndUpdateOptions<LegacyPlayerDocument> { ReturnDocument = ReturnDocument.After },
                cancellationToken);
            if (committed != null)
            {
                return new LegacyDogTagResult(committed, mutation.Outcome);
            }
        }

        throw new InvalidDataException("Dog-tag authority changed too often to commit this operation.");
    }

    private static void ValidateDogTagSuccessor(
        LegacyPlayerDocument current, LegacyDogTagMutation mutation, int now)
    {
        if (mutation.Outcome != LegacyDogTagOutcome.Applied || mutation.LastUpdate != now ||
            mutation.Seconds > current.DogTagMax || mutation.Gold < 0 || mutation.Gold > current.Gold)
        {
            throw new InvalidDataException("Invalid dog-tag/wallet successor.");
        }
    }
}
