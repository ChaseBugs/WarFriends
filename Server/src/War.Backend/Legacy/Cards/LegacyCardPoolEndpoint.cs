using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using War.Persistence;
using War.Persistence.Legacy.Cards;

namespace War.Backend.Legacy.Cards;

/// <summary>Adapts actions 174/175 to validated intents and transactional publication.</summary>
public sealed class LegacyCardPoolEndpoint(LegacyPlayerStore store, LegacyCardPoolPolicy policy)
{
    private readonly LegacyCardPoolRules _rules = new(policy);

    public async Task<IResult> ApplyAsync(
        LegacyRequest request, LegacyPlayerDocument player, CancellationToken cancellationToken)
    {
        if (!policy.IsAvailable)
        {
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }

        string? operationId = request.Field("OperationId");
        if (request.HasField("OperationId") && (operationId == null ||
            !Regex.IsMatch(operationId, "\\A[a-zA-Z0-9_-]{1,64}\\z")))
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }

        LegacyCardPoolIntent intent;
        try
        {
            intent = ParseIntent(request);
        }
        catch (JsonException)
        {
            return LegacyResponse.Failure(DatabaseResult.JsonFailure);
        }

        int now = checked((int)DateTimeOffset.UtcNow.ToUnixTimeSeconds());
        var operation = new LegacyCardPoolOperation
        {
            ActorId = player.Id,
            DonorId = intent.DonorId,
            ActionId = (int)request.Action,
            PayloadDigest = LegacyCardPoolParser.Digest(intent),
            OperationId = operationId,
            NowUnixSeconds = now
        };
        LegacyCardPoolResult result = await store.ApplyCardPoolAsync(operation,
            snapshot => _rules.Calculate(snapshot, intent, now), cancellationToken);
        // OnWithdrawCard indexes this field without a guard on success.
        return LegacyResponse.Json((DatabaseResult)result.Result,
            new JsonObject { ["NextWithdraw"] = _rules.CurrentNextWithdraw(result.Actor) });
    }

    private static LegacyCardPoolIntent ParseIntent(LegacyRequest request)
    {
        if (request.Action == DatabaseAction.DepositCards)
        {
            string added = request.Field("AddedCards") ?? throw new JsonException("Missing AddedCards.");
            string removed = request.Field("RemovedCards") ?? throw new JsonException("Missing RemovedCards.");
            return new LegacyCardPoolIntent(LegacyCardPoolParser.ParseAmounts(added),
                LegacyCardPoolParser.ParseAmounts(removed), null, null);
        }

        string donor = request.Field("IdOfPlayer") ?? throw new JsonException("Missing donor.");
        string card = request.Field("CardId") ?? throw new JsonException("Missing card.");
        if (donor.Length > 128 || card.Length > 64)
        {
            throw new JsonException("Oversized card-pool identity.");
        }

        return new LegacyCardPoolIntent(new Dictionary<string, int>(), new Dictionary<string, int>(), card, donor);
    }
}
