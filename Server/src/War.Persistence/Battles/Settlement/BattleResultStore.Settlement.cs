using MongoDB.Driver;
using War.BattleServer;
using War.Persistence.Battles.Settlement;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.State;
using War.Protocol;
using War.Shared;

namespace War.Persistence;

public sealed partial class BattleResultStore
{
    /// <summary>Commits both account successors and exact replay responses with the terminal settlement marker.</summary>
    public async Task<string?> SettleAsync(
        BattleSettlementRequest request,
        Func<BattleSettlementContext, BattleSettlementPlan> calculate,
        CancellationToken cancellationToken)
    {
        BattleSettlementValidation.ValidateRequest(request);
        using var deadline = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        deadline.CancelAfter(TimeSpan.FromSeconds(30));
        using IClientSessionHandle session = await _client.StartSessionAsync(cancellationToken: deadline.Token);
        return await session.WithTransactionAsync(
            (transaction, token) => SettleTransactionAsync(transaction, request, calculate, token),
            new TransactionOptions(ReadConcern.Snapshot, ReadPreference.Primary, WriteConcern.WMajority),
            deadline.Token);
    }

    private async Task<string?> SettleTransactionAsync(
        IClientSessionHandle session, BattleSettlementRequest request,
        Func<BattleSettlementContext, BattleSettlementPlan> calculate, CancellationToken cancellationToken)
    {
        var players = _database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        LegacyPlayerDocument requester = await players.Find(session, row => row.Id == request.PlayerId)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidDataException("Settlement account is missing.");
        ValidateSettlementAccount(requester, request.NowUtc);
        if (requester.SessionHash != request.SessionHash || requester.SessionExpiresUtc <= request.NowUtc)
        {
            throw new InvalidDataException("Settlement session is no longer valid.");
        }

        BattleResultDocument? result = await results.Find(session, row => row.MatchId == request.MatchId)
            .FirstOrDefaultAsync(cancellationToken);
        if (result == null)
        {
            return null;
        }

        Validate(result, request.MatchId, request.NowUtc);
        MatchSnapshot terminal = BattleTerminalEvidenceValidator.ValidatePayload(
            result.Snapshot, result.MatchId, result.Digest);
        if (!terminal.Players.Any(player => player.PlayerId == request.PlayerId) || terminal.Phase != BattlePhase.Ended)
        {
            throw new InvalidDataException("Settlement requires a participant in a completed battle.");
        }

        var receipts = _database.GetCollection<BattleSettlementReceipt>("battle_settlements");
        BattleSettlementReceipt? receipt = await receipts.Find(session, row => row.Id == request.MatchId)
            .FirstOrDefaultAsync(cancellationToken);
        if (receipt != null)
        {
            BattleSettlementValidation.ValidateReceipt(receipt, result, terminal, request.NowUtc);
            return receipt.Responses[request.PlayerId];
        }

        if (result.Settled)
        {
            throw new InvalidDataException("Settled battle is missing its replay receipt.");
        }

        BattleSettlementContext context = await ReadSettlementContextAsync(session, terminal, cancellationToken);
        foreach (LegacyPlayerDocument player in context.Players)
        {
            ValidateSettlementAccount(player, request.NowUtc);
        }

        BattleSettlementPlan plan = calculate(context);
        BattleSettlementValidation.ValidatePlan(plan, context);
        await PublishSettlementAsync(session, new(request, result, context, plan), cancellationToken);
        return plan.Players.Single(player => player.PlayerId == request.PlayerId).ResponseJson;
    }

    private async Task<BattleSettlementContext> ReadSettlementContextAsync(
        IClientSessionHandle session, MatchSnapshot terminal, CancellationToken cancellationToken)
    {
        string[] ids = terminal.Players.Select(player => player.PlayerId).ToArray();
        var snapshots = _database.GetCollection<BattleManifestSnapshotDocument>("battle_manifest_snapshots");
        BattleManifestSnapshotDocument snapshot = await snapshots.Find(session, row => row.Id == terminal.MatchId)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new InvalidDataException("Missing settlement manifest.");
        MatchManifest manifest = MatchManifest.Parse(BattleManifestSnapshotStore.Validate(snapshot, terminal.MatchId, ids));
        if (manifest.Digest() != terminal.ManifestHash)
        {
            throw new InvalidDataException("Settlement manifest differs from accepted terminal evidence.");
        }
        BattleSettlementEligibility.Validate(terminal, manifest);

        var players = _database.GetCollection<LegacyPlayerDocument>("legacyPlayers");
        List<LegacyPlayerDocument> accounts = await players.Find(session,
            Builders<LegacyPlayerDocument>.Filter.In(player => player.Id, ids)).ToListAsync(cancellationToken);
        if (accounts.Count != ids.Length)
        {
            throw new InvalidDataException("Settlement participant account is missing.");
        }

        return new(terminal, manifest, Array.AsReadOnly(ids.Select(id => accounts.Single(row => row.Id == id)).ToArray()));
    }

    private static void ValidateSettlementAccount(LegacyPlayerDocument player, DateTime nowUtc)
    {
        LegacyPlayerIdentityAuthority.Validate(player);
        LegacyPlayerEconomyAuthority.Validate(player);
        LegacySessionAuthority.ValidateStored(player, nowUtc);
    }

    private sealed record SettlementPublication(BattleSettlementRequest Request, BattleResultDocument Result,
        BattleSettlementContext Context, BattleSettlementPlan Plan);
}
