using System.Text.Json.Nodes;
using War.Backend.Legacy.Time;
using War.Persistence;
using War.Persistence.Legacy.Profile;

namespace War.Backend.Legacy.Profile;

/// <summary>Owns recovered profile parsing and callbacks; persistence owns atomic publication.</summary>
public sealed class LegacyProfileEndpoint(
    LegacyPlayerStore store,
    LegacyRenamePolicy renamePolicy,
    ILogger<LegacyProfileEndpoint> logger,
    TimeProvider? clock = null)
{
    private readonly TimeProvider _clock = clock ?? TimeProvider.System;

    /// <summary>Executes one supported profile mutation using the canonical recovered request fields.</summary>
    public async Task<IResult> ExecuteAsync(
        LegacyRequest request, LegacyPlayerDocument authenticated, CancellationToken cancellationToken)
    {
        try
        {
            DateTimeOffset time = _clock.GetUtcNow();
            _ = LegacyClientTime.Read(time.ToUnixTimeSeconds());
            if (request.Action == DatabaseAction.SetPlayerStatus)
            {
                return await SetStatusAsync(request, authenticated, time, cancellationToken);
            }

            if (request.Action == DatabaseAction.ChangePlayerName)
            {
                return await RenameAsync(request, authenticated, cancellationToken);
            }

            LegacyProfileChange? change = ParseReplacement(request);
            if (change == null)
            {
                return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
            }

            LegacyPlayerDocument? committed = await store.ApplyProfileAsync(
                authenticated, change, time, cancellationToken);
            return LegacyResponse.Json(committed == null ? DatabaseResult.InvalidToken : DatabaseResult.Success);
        }
        catch (InvalidDataException exception)
        {
            logger.LogError(exception, "Refused invalid legacy profile authority.");
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }
    }

    private async Task<IResult> SetStatusAsync(
        LegacyRequest request,
        LegacyPlayerDocument authenticated,
        DateTimeOffset time,
        CancellationToken cancellationToken)
    {
        int now = LegacyClientTime.Read(time.ToUnixTimeSeconds());
        string? status = request.SingleField("PlayerStatus");
        // Even a malformed heartbeat needs Time for the unchanged OnSetPlayerStatus callback.
        if (status is not ("0" or "1" or "2") || !AliasAgrees(request, "Status", status))
        {
            return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["Time"] = now });
        }

        LegacyPlayerDocument? committed = await store.ApplyProfileAsync(authenticated,
            LegacyProfileChange.ForStatus(status[0] - '0'), time, cancellationToken);
        return LegacyResponse.Json(committed == null ? DatabaseResult.InvalidToken : DatabaseResult.Success,
            new JsonObject { ["Time"] = now });
    }

    private static LegacyProfileChange? ParseReplacement(LegacyRequest request)
    {
        try
        {
            return request.Action switch
            {
                DatabaseAction.UpdateDeviceToken => LegacyProfileChange.ForDeviceRegistration(
                    request.SingleField("DeviceToken"), request.SingleField("Locale")),
                DatabaseAction.ChangeLanguage => LegacyProfileChange.ForLanguage(request.SingleField("Locale")),
                DatabaseAction.ChangePlayerCountry when
                    AliasAgrees(request, "CountryCode", request.SingleField("NewCountryCode")) &&
                    AliasAgrees(request, "Country", request.SingleField("NewCountryCode")) =>
                    LegacyProfileChange.ForCountry(request.SingleField("NewCountryCode")),
                _ => null
            };
        }
        catch (InvalidDataException)
        {
            return null;
        }
    }

    private async Task<IResult> RenameAsync(
        LegacyRequest request, LegacyPlayerDocument authenticated, CancellationToken cancellationToken)
    {
        string? name = request.SingleField("Name");
        string? payment = request.SingleField("PayForRename");
        if (!LegacyProfileValues.IsName(name) || payment is not ("0" or "1") ||
            !AliasAgrees(request, "PlayerName", name))
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }

        LegacyRenameResult result = await store.RenamePlayerAsync(
            authenticated, new LegacyRenameRequest(name!, payment == "1"), renamePolicy, cancellationToken);
        DatabaseResult code = result.Outcome switch
        {
            LegacyRenameOutcome.Published => DatabaseResult.Success,
            LegacyRenameOutcome.InvalidSession => DatabaseResult.InvalidToken,
            LegacyRenameOutcome.MissingPrice => DatabaseResult.ServerMaintenance,
            LegacyRenameOutcome.InvalidPrice or LegacyRenameOutcome.PaymentRequired or
                LegacyRenameOutcome.StaleRevision => DatabaseResult.WrongPlayerData,
            LegacyRenameOutcome.NotEnoughGold => DatabaseResult.NotEnoughGoldForChangeName,
            _ => throw new InvalidDataException("Unsupported rename publication outcome.")
        };
        if (code == DatabaseResult.NotEnoughGoldForChangeName)
        {
            // The recovered error handler indexes both fields before restoring its wallet view.
            LegacyPlayerDocument current = result.Player ??
                throw new InvalidDataException("Missing rename error state.");
            return LegacyResponse.Json(code, new JsonObject
            {
                ["RenameCount"] = current.RenameCount, ["PlayerGold"] = current.Gold
            });
        }

        if (result.Outcome != LegacyRenameOutcome.Published)
        {
            return LegacyResponse.Failure(code);
        }

        // All three keys are indexed without a guard by OnChangePlayerName.
        LegacyPlayerDocument committed = result.Player ?? throw new InvalidDataException("Missing committed rename.");
        return LegacyResponse.Json(code, new JsonObject
        {
            ["Name"] = committed.Name,
            ["RenameCount"] = committed.RenameCount,
            ["PayForRename"] = result.Price > 0 ? 1 : 0
        });
    }

    private static bool AliasAgrees(LegacyRequest request, string alias, string? canonical) =>
        !request.HasField(alias) || canonical != null && request.SingleField(alias) == canonical;
}
