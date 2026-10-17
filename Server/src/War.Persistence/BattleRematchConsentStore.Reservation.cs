using MongoDB.Driver;

namespace War.Persistence;

public sealed partial class BattleRematchConsentStore
{
    private static readonly TransactionOptions ReservationTransaction = new(
        readConcern: ReadConcern.Snapshot, writeConcern: WriteConcern.WMajority);

    /// <summary>Atomically consumes mutual consent and reserves exactly its participants once.</summary>
    public async Task<BattleRematchConsentDocument> ReserveAsync(
        BattleRematchReservation request, CancellationToken cancellationToken)
    {
        ValidateTime(request.ApplicationTime);
        request = request with { PlayerOrder = request.PlayerOrder?.ToArray() };
        DateTimeOffset now = DateTimeOffset.FromUnixTimeMilliseconds(request.ApplicationTime.ToUnixTimeMilliseconds());
        BattleResultDocument result = await _results.Get(request.SourceMatchId, cancellationToken)
            ?? throw new InvalidDataException("Rematch reservation requires accepted terminal evidence.");
        if (result.AcceptedUtc > now.UtcDateTime)
        {
            throw new InvalidDataException("Rematch reservation cannot precede terminal acceptance.");
        }
        string[] players = ReadParticipants(result, request.AuthenticatedPlayerId);
        string[] order = request.PlayerOrder?.ToArray() ?? players;
        if (!order.OrderBy(player => player, StringComparer.Ordinal).SequenceEqual(players))
        {
            throw new InvalidDataException("Rematch source order differs from accepted participants.");
        }
        BattlePairDocument pair = CreateReservedPair(request.CompatibilityKey, order, now);
        using IClientSessionHandle session = await _client.StartSessionAsync(cancellationToken: cancellationToken);
        try
        {
            return await session.WithTransactionAsync(async (transaction, token) =>
            {
                BattleRematchConsentDocument current = await _consents.Find(transaction, row => row.Id == result.MatchId)
                    .FirstOrDefaultAsync(token) ?? throw new InvalidDataException("Rematch consent is missing.");
                Validate(current, result, players, now);
                if (current.Status == Allocated)
                {
                    if (current.NextCompatibilityKey != request.CompatibilityKey ||
                        !current.NextPlayers.SequenceEqual(order))
                    {
                        throw new InvalidDataException("Reservation replay changed the server compatibility policy.");
                    }
                    // The pair may already have ended; a retry must never recreate its participants or grants.
                    return current;
                }
                if (current.Status != Ready || now.UtcDateTime >= current.ExpiresUtc)
                {
                    throw new InvalidDataException("Both participants must consent inside the rematch window.");
                }
                await RequireParticipantsAvailableAsync(transaction, players, token);
                return await PublishReservationAsync(transaction, current, pair, token);
            }, ReservationTransaction, cancellationToken);
        }
        catch (MongoWriteException exception) when (exception.WriteError.Category == ServerErrorCategory.DuplicateKey)
        {
            throw new InvalidDataException("Another allocation already reserved a rematch participant.", exception);
        }
    }

    private async Task RequireParticipantsAvailableAsync(
        IClientSessionHandle session, string[] players, CancellationToken cancellationToken)
    {
        IMongoDatabase database = _consents.Database;
        var pairs = database.GetCollection<BattlePairDocument>("battle_pairs");
        var pairFilter = Builders<BattlePairDocument>.Filter.AnyIn(row => row.Players, players);
        if (await pairs.Find(session, pairFilter).AnyAsync(cancellationToken))
        {
            throw new InvalidDataException("A rematch participant already owns another battle pair.");
        }
        var tickets = database.GetCollection<BattleQueueTicketDocument>("battle_queue_tickets");
        var ticketFilter = Builders<BattleQueueTicketDocument>.Filter.In(row => row.PlayerId, players);
        if (await tickets.Find(session, ticketFilter).AnyAsync(cancellationToken))
        {
            throw new InvalidDataException("A rematch participant already owns a matchmaking ticket.");
        }
    }

    private async Task<BattleRematchConsentDocument> PublishReservationAsync(IClientSessionHandle session,
        BattleRematchConsentDocument consent, BattlePairDocument pair, CancellationToken cancellationToken)
    {
        long previousRevision = consent.Revision;
        consent.Status = Allocated;
        consent.NextMatchId = pair.MatchId;
        consent.NextCompatibilityKey = pair.CompatibilityKey;
        consent.NextPlayers = pair.Players.ToArray();
        consent.UpdatedUtc = pair.CreatedUtc;
        consent.Revision = NextRevision(previousRevision);
        ReplaceOneResult replaced = await _consents.ReplaceOneAsync(session,
            row => row.Id == consent.Id && row.Revision == previousRevision,
            consent, cancellationToken: cancellationToken);
        if (replaced.ModifiedCount != 1)
        {
            throw new InvalidDataException("Rematch consent changed before its reservation.");
        }
        await _consents.Database.GetCollection<BattlePairDocument>("battle_pairs")
            .InsertOneAsync(session, pair, cancellationToken: cancellationToken);
        return consent;
    }

    private static BattlePairDocument CreateReservedPair(string compatibilityKey, string[] players, DateTimeOffset now)
    {
        var pair = new BattlePairDocument
        {
            Id = Guid.NewGuid().ToString("N"),
            MatchId = "m" + Guid.NewGuid().ToString("N"),
            CompatibilityKey = compatibilityKey,
            Players = players,
            CreatedUtc = now.UtcDateTime,
        };
        BattleMatchQueueStore.ValidatePairDocument(pair);
        return pair;
    }
}
