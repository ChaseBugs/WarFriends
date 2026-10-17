using MongoDB.Driver;
using War.BattleServer;
using War.Protocol;

namespace War.Persistence;

/// <summary>Persists two-party consent; consent alone never issues a match grant or changes a result.</summary>
public sealed partial class BattleRematchConsentStore
{
    // GameControllerOnline.CheckRematchStates waits thirty seconds for the other participant.
    public const int ConsentDurationSeconds = 30;
    private const int MaximumWriteAttempts = 16;
    private const string Waiting = "waiting";
    private const string Ready = "ready";
    private const string Cancelled = "cancelled";
    private const string Expired = "expired";
    private readonly BattleResultStore _results;
    private readonly IMongoCollection<BattleRematchConsentDocument> _consents;

    /// <summary>Uses one database for accepted result evidence and its separate consent records.</summary>
    public BattleRematchConsentStore(string uri, string databaseName)
    {
        _results = new BattleResultStore(uri, databaseName);
        _consents = new MongoClient(uri).GetDatabase(databaseName)
            .GetCollection<BattleRematchConsentDocument>("battle_rematch_consents");
    }

    /// <summary>Records an authenticated participant's idempotent consent to the same opponent.</summary>
    public async Task<BattleRematchConsentDocument> AcceptAsync(
        string matchId, string authenticatedPlayerId, DateTimeOffset now, CancellationToken cancellationToken)
    {
        return await ChangeAsync(new Change(matchId, authenticatedPlayerId, now, Operation.Accept), cancellationToken)
            ?? throw new InvalidDataException("Consent was not recorded.");
    }

    /// <summary>Withdraws the participant's pending consent without touching the completed result.</summary>
    public async Task<BattleRematchConsentDocument> CancelAsync(
        string matchId, string authenticatedPlayerId, DateTimeOffset now, CancellationToken cancellationToken)
    {
        return await ChangeAsync(new Change(matchId, authenticatedPlayerId, now, Operation.Cancel), cancellationToken)
            ?? throw new InvalidDataException("Cancellation was not recorded.");
    }

    /// <summary>Reads participant consent and persists expiry without adding a vote or starting a window.</summary>
    public Task<BattleRematchConsentDocument?> ReadAsync(
        string matchId, string authenticatedPlayerId, DateTimeOffset now, CancellationToken cancellationToken)
    {
        return ChangeAsync(new Change(matchId, authenticatedPlayerId, now, Operation.Read), cancellationToken);
    }

    private async Task<BattleRematchConsentDocument?> ChangeAsync(
        Change change, CancellationToken cancellationToken)
    {
        ValidateTime(change.Now);
        // BSON dates retain milliseconds; return the same timestamps that a second process reads.
        change = change with { Now = DateTimeOffset.FromUnixTimeMilliseconds(change.Now.ToUnixTimeMilliseconds()) };
        BattleResultDocument result = await _results.Get(change.MatchId, cancellationToken)
            ?? throw new InvalidDataException("Rematch requires an accepted completed result.");
        if (result.AcceptedUtc > change.Now.UtcDateTime)
        {
            throw new InvalidDataException("Rematch cannot precede accepted terminal evidence.");
        }
        string[] players = ReadParticipants(result, change.PlayerId);
        for (int attempt = 0; attempt < MaximumWriteAttempts; attempt++)
        {
            BattleRematchConsentDocument? current = await _consents.Find(row => row.Id == change.MatchId)
                .FirstOrDefaultAsync(cancellationToken);
            if (current == null)
            {
                if (change.Kind == Operation.Read)
                {
                    return null;
                }
                BattleRematchConsentDocument created = Create(change, result, players);
                if (await TryInsertAsync(created, cancellationToken))
                {
                    return created;
                }
                continue;
            }

            Validate(current, result, players, change.Now);
            BattleRematchConsentDocument next = Apply(current, change);
            if (next.Revision == current.Revision)
            {
                return current;
            }
            ReplaceOneResult replaced = await _consents.ReplaceOneAsync(
                row => row.Id == current.Id && row.Revision == current.Revision,
                next, cancellationToken: cancellationToken);
            if (replaced.ModifiedCount == 1)
            {
                return next;
            }
        }
        throw new InvalidDataException("Rematch consent changed repeatedly; retry the request.");
    }

    private async Task<bool> TryInsertAsync(
        BattleRematchConsentDocument created, CancellationToken cancellationToken)
    {
        try
        {
            await _consents.InsertOneAsync(created, cancellationToken: cancellationToken);
            return true;
        }
        catch (MongoWriteException exception) when (exception.WriteError.Category == ServerErrorCategory.DuplicateKey)
        {
            return false;
        }
    }

    private static string[] ReadParticipants(BattleResultDocument result, string playerId)
    {
        MatchSnapshot terminal = TerminalOutbox.ValidatePayload(result.Snapshot, result.MatchId, result.Digest);
        string[] players = terminal.Players.Select(player => player.PlayerId)
            .OrderBy(identity => identity, StringComparer.Ordinal).ToArray();
        if (terminal.Phase != BattlePhase.Ended || players.Length != 2 || players[0] == players[1] ||
            !players.Contains(playerId, StringComparer.Ordinal))
        {
            throw new InvalidDataException("Only the two participants of a completed battle can request rematch.");
        }
        return players;
    }

    private static BattleRematchConsentDocument Create(Change change, BattleResultDocument result, string[] players)
    {
        return new BattleRematchConsentDocument
        {
            Id = result.MatchId,
            ResultDigest = result.Digest,
            Players = players,
            AcceptedPlayers = change.Kind == Operation.Cancel ? [] : [change.PlayerId],
            Status = change.Kind == Operation.Cancel ? Cancelled : Waiting,
            Revision = 1,
            CreatedUtc = change.Now.UtcDateTime,
            UpdatedUtc = change.Now.UtcDateTime,
            ExpiresUtc = change.Now.AddSeconds(ConsentDurationSeconds).UtcDateTime,
        };
    }

    private static BattleRematchConsentDocument Apply(BattleRematchConsentDocument current, Change change)
    {
        if (current.Status is Cancelled or Expired)
        {
            return current;
        }
        string status = change.Now.UtcDateTime >= current.ExpiresUtc ? Expired : current.Status;
        string[] accepted = current.AcceptedPlayers;
        if (status != Expired && change.Kind == Operation.Cancel)
        {
            status = Cancelled;
        }
        else if (status != Expired && change.Kind == Operation.Accept &&
            !accepted.Contains(change.PlayerId, StringComparer.Ordinal))
        {
            accepted = accepted.Append(change.PlayerId).OrderBy(player => player, StringComparer.Ordinal).ToArray();
            status = Ready;
        }
        if (status == current.Status && accepted.Length == current.AcceptedPlayers.Length)
        {
            return current;
        }
        return new BattleRematchConsentDocument
        {
            Id = current.Id, ResultDigest = current.ResultDigest, Players = current.Players,
            AcceptedPlayers = accepted, Status = status, Revision = checked(current.Revision + 1),
            CreatedUtc = current.CreatedUtc, UpdatedUtc = change.Now.UtcDateTime, ExpiresUtc = current.ExpiresUtc,
        };
    }

    private enum Operation
    {
        Read,
        Accept,
        Cancel,
    }

    private sealed record Change(string MatchId, string PlayerId, DateTimeOffset Now, Operation Kind);
}
