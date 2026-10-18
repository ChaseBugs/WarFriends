using MongoDB.Driver;

namespace War.Persistence;

public sealed partial class BattleMatchQueueStore
{
    private const int MaximumTicketAdmissionAttempts = 16;

    private async Task<(string? TicketId, BattlePairDocument? Pair)> FindUnscopedAdmissionAsync(
        string playerId, string compatibilityKey, DateTimeOffset now, CancellationToken cancellationToken)
    {
        BattlePairDocument? existingPair = await PairFor(playerId, cancellationToken);
        if (existingPair != null)
        {
            return (null, existingPair);
        }
        for (int attempt = 0; attempt < MaximumTicketAdmissionAttempts; attempt++)
        {
            var ticket = new BattleQueueTicketDocument
            {
                Id = Guid.NewGuid().ToString("N"), PlayerId = playerId,
                CompatibilityKey = compatibilityKey, JoinedUtc = now.UtcDateTime,
                ExpiresUtc = now.AddSeconds(QueueTicketLifetimeSeconds).UtcDateTime
            };
            try
            {
                existingPair = await AdmitUnscopedTicketAsync(ticket, cancellationToken);
                return existingPair == null ? (ticket.Id, null) : (null, existingPair);
            }
            catch (MongoWriteException failure) when (failure.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                BattleQueueTicketDocument? prior = await tickets.Find(row => row.PlayerId == playerId)
                    .FirstOrDefaultAsync(cancellationToken);
                if (prior != null)
                {
                    if (await TryReuseUnscopedTicketAsync(prior, ticket, cancellationToken))
                    {
                        return (prior.Id, null);
                    }
                    continue;
                }
                existingPair = await PairFor(playerId, cancellationToken);
                if (existingPair != null)
                {
                    return (null, existingPair);
                }
            }
        }
        throw new InvalidDataException("Matchmaking ticket admission changed repeatedly; retry the request.");
    }

    private async Task<bool> TryReuseUnscopedTicketAsync(BattleQueueTicketDocument prior,
        BattleQueueTicketDocument requested, CancellationToken cancellationToken)
    {
        ValidateTicket(prior);
        if (prior.AttemptId.Length != 0)
        {
            throw new InvalidDataException("An attempt token owns this ticket.");
        }
        if (prior.ExpiresUtc <= requested.JoinedUtc)
        {
            await tickets.DeleteOneAsync(row => row.Id == prior.Id && row.ExpiresUtc == prior.ExpiresUtc,
                cancellationToken);
            return false;
        }
        if (prior.CompatibilityKey != requested.CompatibilityKey)
        {
            throw new InvalidDataException("Player already has a different matchmaking ticket.");
        }
        return true;
    }

    private async Task<BattlePairDocument?> AdmitUnscopedTicketAsync(
        BattleQueueTicketDocument ticket, CancellationToken cancellationToken)
    {
        using IClientSessionHandle session = await client.StartSessionAsync(cancellationToken: cancellationToken);
        return await session.WithTransactionAsync(async (transaction, token) =>
        {
            await BattleAdmissionFence.AcquireAsync(tickets.Database, transaction, [ticket.PlayerId], token);
            BattlePairDocument? pair = await PairFor(transaction, ticket.PlayerId, token);
            if (pair != null)
            {
                return pair;
            }
            await tickets.InsertOneAsync(transaction, ticket, cancellationToken: token);
            return null;
        }, QueueTransaction, cancellationToken);
    }
}
