using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.State;
using War.Protocol;
using War.Shared;

namespace War.Persistence.Battles.Settlement;

internal static class BattleSettlementValidation
{
    internal static void ValidateRequest(BattleSettlementRequest request)
    {
        if (!Regex.IsMatch(request.MatchId ?? "", "\\Am[0-9a-f]{32}\\z") ||
            !CanonicalGuid.IsCanonical(request.PlayerId) ||
            !Regex.IsMatch(request.SessionHash ?? "", "\\A[A-F0-9]{64}\\z") ||
            request.NowUtc.Kind != DateTimeKind.Utc || request.NowUtc < DateTime.UnixEpoch ||
            request.NowUtc > DateTime.UnixEpoch.AddSeconds(int.MaxValue))
        {
            throw new InvalidDataException("Invalid authenticated battle settlement request.");
        }
    }

    internal static void ValidatePlan(BattleSettlementPlan plan, BattleSettlementContext context)
    {
        if (!IsHash(plan.PolicyRevision) || context.Manifest.SettlementPolicyRevision != plan.PolicyRevision ||
            !context.Terminal.RewardEligible || plan.Players.Count != 2 ||
            !plan.Players.Select(player => player.PlayerId).Order(StringComparer.Ordinal)
                .SequenceEqual(context.Players.Select(player => player.Id).Order(StringComparer.Ordinal)))
        {
            throw new InvalidDataException("Settlement plan has no frozen reward policy or complete participant set.");
        }

        foreach (BattleSettlementPlayerChange next in plan.Players)
        {
            LegacyPlayerDocument current = context.Players.Single(player => player.Id == next.PlayerId);
            ValidateChange(current, next);
        }
    }

    internal static void ValidateReceipt(
        BattleSettlementReceipt receipt, BattleResultDocument result, MatchSnapshot terminal, DateTime nowUtc)
    {
        if (!result.Settled || !result.Scored || receipt.Id != result.MatchId ||
            receipt.ResultDigest != result.Digest || receipt.ManifestHash != terminal.ManifestHash ||
            !IsHash(receipt.PolicyRevision) || !terminal.RewardEligible ||
            receipt.PolicyRevision != terminal.SettlementPolicyRevision || receipt.SettledUtc.Kind != DateTimeKind.Utc ||
            receipt.SettledUtc != result.SettledUtc || receipt.SettledUtc < result.AcceptedUtc ||
            receipt.SettledUtc > nowUtc || receipt.Responses.Count != 2 ||
            !receipt.Responses.Keys.Order(StringComparer.Ordinal)
                .SequenceEqual(terminal.Players.Select(player => player.PlayerId).Order(StringComparer.Ordinal)))
        {
            throw new InvalidDataException("Invalid battle settlement replay receipt.");
        }

        foreach (string response in receipt.Responses.Values)
        {
            ValidateResponse(response);
        }
    }

    private static void ValidateChange(LegacyPlayerDocument current, BattleSettlementPlayerChange next)
    {
        if (next.Gold < current.Gold || next.WarBucks < current.WarBucks || next.Experience < current.Experience ||
            next.Level < current.Level || next.Level >= LegacyAccountCreation.RecoveredRankCount ||
            next.LevelExperience < 0 || next.Skill < 0 || next.MedalsBalance < 0 || next.BattlesLostInRow < 0 ||
            next.PlacementMatchesRequired is < 0 or > LegacyPlayerEconomyAuthority.RecoveredPlacementMatches)
        {
            throw new InvalidDataException("Settlement successor violates economy/progression bounds.");
        }

        LegacyPlayerEconomyAuthority.ValidateArmyPower(next.ArmyPower);
        ValidateResponse(next.ResponseJson);
        using JsonDocument streak = JsonDocument.Parse(next.WinStreakJson);
        JsonElement root = streak.RootElement;
        if (root.ValueKind != JsonValueKind.Object || root.EnumerateObject().Count() != 2 ||
            !root.TryGetProperty("WinCount", out JsonElement count) || !count.TryGetInt32(out int wins) ||
            wins is < 0 or > 9 || !root.TryGetProperty("TimeStamp", out JsonElement time) ||
            !time.TryGetInt32(out int seconds) || seconds < 0 ||
            (wins == 0 && seconds != 0) || (wins > 0 && seconds == 0))
        {
            throw new InvalidDataException("Settlement win-streak successor is invalid.");
        }
    }

    private static void ValidateResponse(string response)
    {
        if (response == null || Encoding.UTF8.GetByteCount(response) > 65_536)
        {
            throw new InvalidDataException("Settlement response exceeds its replay bound.");
        }

        using JsonDocument document = JsonDocument.Parse(response);
        if (document.RootElement.ValueKind != JsonValueKind.Object)
        {
            throw new InvalidDataException("Settlement response must be an object.");
        }
    }

    private static bool IsHash(string? value) => value != null && Regex.IsMatch(value, "\\A[0-9a-f]{64}\\z");
}
