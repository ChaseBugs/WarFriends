using System.Collections.Frozen;
using War.Backend.Legacy.Catalog;
using System.Security.Cryptography;
using War.Backend.Legacy.Buffering;
using System.Text.Json;
using System.Text.Json.Nodes;
using War.Backend.Legacy.Economy;
using War.Persistence;
using War.Persistence.Legacy.Buffers;

namespace War.Backend.Legacy;

/// <summary>One entry of the client's <c>Dictionary&lt;int, Request&gt;</c>.</summary>
/// <param name="Index">The dictionary key, which is the order the client queued the request in.</param>
/// <param name="Action">The <c>Request.action</c> field.</param>
/// <param name="Data">The <c>Request.data</c> field: either a bare string or a JSON document,
/// depending on the action. It is always transported as a JSON string.</param>
public sealed record BufferedRequest(int Index, DatabaseAction Action, string? Data);

/// <summary>A parsed buffer: the client's id for it and its requests in index order.</summary>
public sealed record ParsedBuffer(string BufferId, IReadOnlyList<BufferedRequest> Requests);

/// <summary>
/// Applies buffered requests to a player, at most once each, and builds the results array the
/// client's <c>ProcessBuffer</c> consumes.
/// </summary>
/// <remarks>
/// <para><b>Result encoding.</b> Unlike <c>Player</c>/<c>PlayerData</c>, entries here are plain
/// JSON, not DynamoDB AttributeValues: <c>ProcessBuffer</c> reads them with <c>ParseIntToken</c>,
/// <c>ParseLongToken</c> and the single-argument <c>ParseString</c>. Nested blobs are JSON
/// documents escaped inside a string, because <c>LevelManager.UpdateWeapon</c> casts the token to
/// <c>string</c> before deserializing it.</para>
/// <para>Success fields are action-specific: BuyDecal requires DecalId/ExpiresOn, while delivery
/// countdowns are guarded. Failure branches require the authoritative rollback state their exact
/// Client parser consumes. Both first delivery and replay must honor those contracts.</para>
/// <para><b>Implemented actions are those whose effect is fully determined by the request and the
/// stored player state.</b> The economy actions additionally need the price/reward catalog from the
/// client's Google2u sheets; until that is imported, they return a failure rather than a fabricated
/// success, because a success the server did not actually apply would desynchronise the client's
/// wallet from the authoritative balance.</para>
/// </remarks>
public sealed class LegacyBufferProcessor(LegacyBufferStore buffers, LegacyCatalog catalog, ILogger<LegacyBufferProcessor> logger)
{
    /// <summary>
    /// Actions this server applies. Everything else in the client's 27-action buffered set is
    /// economy or cosmetic-catalog work this pass does not cover yet.
    /// </summary>
    private static readonly FrozenSet<DatabaseAction> Implemented = new[]
    {
        DatabaseAction.WeaponWasShown,
        DatabaseAction.ArmyUnitWasShown,
        DatabaseAction.VisualWasShown,
        DatabaseAction.EquipWeapon,
        DatabaseAction.UpdateEquippedUnits,
        DatabaseAction.BuyWeapon,
        DatabaseAction.BuyUnit,
        DatabaseAction.BuyWeaponUpgrade,
        DatabaseAction.ActivateWeaponUpgrade,
        DatabaseAction.InstantWeaponUpgrade,
        DatabaseAction.BuyUnitUpgrade,
        DatabaseAction.ActivateUnitUpgrade,
        DatabaseAction.InstantUnitUpgrade,
        DatabaseAction.ActivateWeapon,
        DatabaseAction.InstantBuyWeapon,
        DatabaseAction.ActivateUnit,
        DatabaseAction.InstantBuyUnit,
        DatabaseAction.PromoteUnit,
        DatabaseAction.BuyDecal,
        DatabaseAction.EquipDecal,
        DatabaseAction.UpgradeEliteSlot,
        DatabaseAction.ConvertPartsToScraps,
        DatabaseAction.ConvertScrapsToParts,
        DatabaseAction.BuyCardPack,
        DatabaseAction.SaveLastSeenSquadChatTimeStamp
    }.ToFrozenSet();

    /// <summary>Read-only action ownership shared by the planner and contract checks.</summary>
    public static IReadOnlySet<DatabaseAction> SupportedActions => Implemented;

    private readonly LegacyBufferPlanner _planner = new(catalog, Implemented, logger);

    /// <summary>
    /// Applies every request of one buffer in index order and returns the results array.
    /// </summary>
    public async Task<AppliedLegacyBuffer> ApplyAsync(
        LegacyPlayerDocument player, ParsedBuffer buffer, CancellationToken ct)
    {
        if (buffer.Requests.Count > LegacyBufferParser.MaxRequestsPerBuffer ||
            buffer.Requests.Any(request => request.Index < 0) ||
            buffer.Requests.Select(request => request.Index).Distinct().Count() != buffer.Requests.Count)
        {
            throw new InvalidDataException("Invalid buffered request positions.");
        }

        var results = new JsonArray();
        foreach (var request in buffer.Requests)
        {
            LegacyBufferedActionResult applied = await ApplyRequestAsync(player.Id, buffer.BufferId, request, ct);
            player = applied.Player;
            if (applied.ResponseJson == null)
            {
                logger.LogWarning("Rejected unbound or conflicting buffer replay for player {PlayerId}, index {Index}.",
                    player.Id, request.Index);
            }
            results.Add(applied.ResponseJson == null
                ? Result(request.Action, DatabaseResult.ServerRespondedWithError)
                : LegacyBufferedResponse.Project(applied, DateTimeOffset.UtcNow.ToUnixTimeSeconds(), request));
        }

        return new AppliedLegacyBuffer(player, results);
    }

    private Task<LegacyBufferedActionResult> ApplyRequestAsync(
        string playerId, string bufferId, BufferedRequest request, CancellationToken cancellationToken)
    {
        byte[] payload = JsonSerializer.SerializeToUtf8Bytes(new { request.Action, request.Data });
        var identity = new LegacyBufferedAction
        {
            PlayerId = playerId,
            BufferId = bufferId,
            Index = request.Index,
            ActionId = (int)request.Action,
            PayloadDigest = Convert.ToHexStringLower(SHA256.HashData(payload))
        };
        long now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        if (now < 0 || now > int.MaxValue)
        {
            throw new InvalidDataException("Application time exceeds the recovered Client clock.");
        }

        int randomSeed = RandomNumberGenerator.GetInt32(int.MaxValue);
        return buffers.ExecuteAsync(identity, snapshot =>
        {
            // Transaction retries use the same time and rolls; a completed receipt replays exact JSON.
            return _planner.Plan(snapshot, request, now, randomSeed);
        }, cancellationToken);
    }

    internal static int RowInt(LegacyCatalogRow row, string field) => LegacyBufferedCatalogValues.RowInt(row, field);

    internal static List<string>[] CardPoolsByRarity(LegacyCatalog catalog) =>
        Buffering.Cards.LegacyBufferedCardPacks.CardPoolsByRarity(catalog);

    internal static string PickCard(List<string>[] pools, int rarity) => Buffering.Cards.LegacyBufferedCardPacks.PickCard(pools, rarity);

    private static JsonObject Result(DatabaseAction action, DatabaseResult result) => new()
    {
        ["ActionId"] = (int)action, ["Result"] = (int)result
    };
}
