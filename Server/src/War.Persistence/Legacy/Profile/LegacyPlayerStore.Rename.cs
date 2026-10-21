using MongoDB.Driver;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Profile;
using War.Persistence.Legacy.State;

namespace War.Persistence;

public sealed partial class LegacyPlayerStore
{
    /// <summary>Commits name/count/debit together against the authenticated revision and live session.</summary>
    public async Task<LegacyRenameResult> RenamePlayerAsync(
        LegacyPlayerDocument authenticated,
        LegacyRenameRequest request,
        LegacyRenamePolicy policy,
        CancellationToken cancellationToken)
    {
        request.Validate();
        DateTime nowUtc = DateTime.UtcNow;
        LegacyPlayerDocument? current = await ById(authenticated.Id, cancellationToken);
        if (current == null || current.SessionHash != authenticated.SessionHash || current.SessionExpiresUtc <= nowUtc)
        {
            return new(LegacyRenameOutcome.InvalidSession);
        }

        LegacySessionAuthority.ValidateStored(current, nowUtc);
        LegacyProfileValues.ValidateStored(current);
        if (current.Revision != authenticated.Revision)
        {
            return new(LegacyRenameOutcome.StaleRevision, current);
        }

        LegacyRenameResult? refusal = CheckRenamePayment(current, request, policy, out int price);
        if (refusal != null)
        {
            return refusal;
        }

        var update = Builders<LegacyPlayerDocument>.Update.Set(row => row.Name, request.Name)
            .Inc(row => row.RenameCount, 1).Inc(row => row.Gold, -price).Inc(row => row.Revision, 1);
        LegacyPlayerDocument? committed = await players.FindOneAndUpdateAsync(
            row => row.Id == current.Id && row.Revision == current.Revision &&
                row.RenameCount == current.RenameCount && row.SessionHash == authenticated.SessionHash &&
                row.SessionExpiresUtc > nowUtc && row.Gold >= price,
            update, new FindOneAndUpdateOptions<LegacyPlayerDocument> { ReturnDocument = ReturnDocument.After },
            cancellationToken);
        if (committed == null)
        {
            return await ClassifyRenameConflictAsync(authenticated, nowUtc, cancellationToken);
        }

        LegacyPlayerIdentityAuthority.Validate(committed);

        LegacyPlayerEconomyAuthority.Validate(committed);
        LegacyProfileValues.ValidateStored(committed);
        return new(LegacyRenameOutcome.Published, committed, price);
    }

    private async Task<LegacyRenameResult> ClassifyRenameConflictAsync(
        LegacyPlayerDocument authenticated, DateTime nowUtc, CancellationToken cancellationToken)
    {
        LegacyPlayerDocument? current = await ById(authenticated.Id, cancellationToken);
        if (current == null || current.SessionHash != authenticated.SessionHash || current.SessionExpiresUtc <= nowUtc)
        {
            return new(LegacyRenameOutcome.InvalidSession);
        }

        LegacySessionAuthority.ValidateStored(current, nowUtc);
        LegacyProfileValues.ValidateStored(current);
        return new(LegacyRenameOutcome.StaleRevision, current);
    }

    private static LegacyRenameResult? CheckRenamePayment(
        LegacyPlayerDocument current, LegacyRenameRequest request, LegacyRenamePolicy policy, out int price)
    {
        price = 0;
        if (current.RenameCount > 0 && policy.SecondRenameGoldCost == null)
        {
            return new(LegacyRenameOutcome.MissingPrice);
        }

        if (!LegacyRenamePolicy.TryCalculatePrice(current.RenameCount, policy.SecondRenameGoldCost ?? 0, out price))
        {
            return new(LegacyRenameOutcome.InvalidPrice);
        }

        if (price > 0 && !request.PayForRename)
        {
            return new(LegacyRenameOutcome.PaymentRequired);
        }

        return current.Gold < price ? new(LegacyRenameOutcome.NotEnoughGold, current) : null;
    }
}
