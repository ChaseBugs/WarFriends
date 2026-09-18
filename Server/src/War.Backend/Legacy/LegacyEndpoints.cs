using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using MongoDB.Driver;
using War.Persistence;

namespace War.Backend.Legacy;

/// <summary>
/// Server-owned starting state for a new account. Bound from the <c>Legacy:Starter</c>
/// configuration section.
/// </summary>
/// <remarks>
/// The client's <c>CreateAccount</c> request carries <c>StartingGold</c>/<c>StartingWarbucks</c>
/// taken from a Fuseboxx A/B payload. Those are client-reported values on an account-management
/// action that has no session yet, so they are read for logging only and never assigned. The
/// balances below are the authority.
/// </remarks>
public sealed class LegacyStarterState
{
    public long Gold { get; set; } = 500;
    public long WarBucks { get; set; } = 50;
    public long Tickets { get; set; }
    public long Scraps { get; set; }
    public int Level { get; set; } = 1;
    public int DogTagMax { get; set; } = 10;
    public int PlacementMatchesRequired { get; set; } = 10;
    public int SessionLifetimeHours { get; set; } = 24;

    /// <summary>
    /// The sheet-configuration version reported to <c>GetConfigurations</c>. Kept at the client's
    /// own initial value so the client keeps using its shipped Google2u sheets; bump it only
    /// alongside real sheet documents in the response.
    /// </summary>
    public string SheetConfiguration { get; set; } = "0";

    /// <summary>
    /// The <c>Constants.rowIds.SecondRenameGoldCost</c> Google2u row value. Unset (null) until
    /// content extraction imports it — see <c>Server_guide.md</c> §5 and
    /// <c>LegacyPlayerDocument.RenameCount</c>. A priced rename is refused, never charged an
    /// invented amount, while this is null.
    /// </summary>
    public int? SecondRenameGoldCost { get; set; }
}

/// <summary>
/// The legacy HTTP channel the recovered 1.4.0 client speaks: a single-URL form POST whose
/// <c>requestId</c> selects the action, plus the sibling <c>check.php</c> reachability probe.
/// </summary>
/// <remarks>
/// <para>The client derives both URLs in <c>BeanstalkUrlCreator</c> and targets the retired
/// <c>warfriends-prod.eu-west-1.elasticbeanstalk.com</c> host. Only the host needs repointing —
/// the paths below match what the client requests.</para>
/// <para>This is the boot chain only: reachability, configurations, account creation, login,
/// player data, and the message list the client fetches straight afterwards. Every other action
/// is answered with an explicit maintenance result and logged, because returning
/// <see cref="DatabaseResult.Success"/> with an empty body would send the client into a handler
/// that indexes response keys that are not there.</para>
/// </remarks>
public static class LegacyEndpoints
{
    /// <summary>The reachability probe path, from <c>BeanstalkUrlCreator</c>.</summary>
    public const string CheckPath = "/check.php";

    /// <summary>
    /// The single action URL, from <c>BeanstalkUrlCreator</c>. The date is part of the shipped
    /// client's baked-in path; it is not a version the server may choose.
    /// </summary>
    public const string ActionPath = "/index_09_25_2015.php";

    /// <summary>True for the two paths the legacy client requests.</summary>
    public static bool IsLegacyPath(PathString path) =>
        path.Equals(CheckPath, StringComparison.OrdinalIgnoreCase) || path.Equals(ActionPath, StringComparison.OrdinalIgnoreCase);

    public static void MapLegacy(this WebApplication app, LegacyPlayerStore store, LegacyBufferProcessor bufferProcessor, LegacyStarterState starter)
    {
        // A reachability probe. It grants no session and awards nothing.
        app.MapMethods(CheckPath, ["GET", "POST"], () => LegacyResponse.Ok()).RequireRateLimiting("api");

        app.MapPost(ActionPath, async (HttpContext ctx) =>
        {
            if (!LegacyRequest.TryParse(ctx.Request, out var request))
                return LegacyResponse.Failure(DatabaseResult.JsonFailure);

            var ct = ctx.RequestAborted;

            // GetConfigurations is answered before any account exists and is not JSON.
            if (request.Action == DatabaseAction.GetConfigurations)
                return LegacyResponse.Configurations(starter.SheetConfiguration);

            if (request.Action == DatabaseAction.CreateAccount)
                return await CreateAccount(request, store, starter, app.Logger, ct);

            if (request.Action == DatabaseAction.LoginToCustomAccount)
                return await Login(request, store, starter, ct);

            // Everything past this point consumes a session.
            var player = await store.Authenticate(request.Token, request.PlayerId, ct);
            if (player == null) return LegacyResponse.Failure(DatabaseResult.InvalidToken);

            switch (request.Action)
            {
                case DatabaseAction.GetPlayerData:
                    return await GetPlayerData(request, player, bufferProcessor, ct);

                case DatabaseAction.SendRequestBuffer:
                    return await SendRequestBuffer(request, player, bufferProcessor, ct);

                case DatabaseAction.GetAllMessages:
                    // The client indexes mResponse["Items"] as a JArray without a presence check,
                    // so an empty inbox is an empty array, never an omitted key.
                    return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["Items"] = new JsonArray() });

                case DatabaseAction.SetPlayerStatus:
                    await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update
                        .Set(x => x.Status, request.Int("PlayerStatus"))
                        .Set(x => x.LastAction, Now()), ct);
                    return LegacyResponse.Json(DatabaseResult.Success);

                case DatabaseAction.UpdateDeviceToken:
                    return await UpdateDeviceToken(request, player, store, ct);

                case DatabaseAction.ChangeLanguage:
                    return await ChangeLanguage(request, player, store, ct);

                case DatabaseAction.ChangePlayerCountry:
                    return await ChangePlayerCountry(request, player, store, ct);

                case DatabaseAction.UpdateSettings:
                    return await UpdateSettings(request, player, store, ct);

                case DatabaseAction.ChangePlayerName:
                    return await ChangePlayerName(request, player, store, starter, ct);

                case DatabaseAction.GetPlayerInfo:
                    return await GetPlayerInfo(request, store, ct);

                default:
                    app.Logger.LogWarning("Legacy action {Action} ({Id}) is not implemented yet.", request.Action, (int)request.Action);
                    return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
            }
        }).RequireRateLimiting("api");
    }

    private static int Now() => (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();

    /// <summary>Unix seconds of the next UTC midnight, which is what <c>ServerTime.midnight</c> tracks.</summary>
    private static int NextMidnight() => (int)new DateTimeOffset(DateTime.UtcNow.Date.AddDays(1), TimeSpan.Zero).ToUnixTimeSeconds();

    private static async Task<IResult> CreateAccount(LegacyRequest request, LegacyPlayerStore store, LegacyStarterState starter, ILogger logger, CancellationToken ct)
    {
        // Read but deliberately unused: these arrive from the client's Fuseboxx payload on an
        // unauthenticated action, so they cannot be allowed to set a balance.
        if (request.Field("StartingGold") != null || request.Field("StartingWarbucks") != null)
            logger.LogInformation("Ignoring client-reported starting currency on CreateAccount; server starter state is authoritative.");

        string id = Guid.NewGuid().ToString("N");
        string password = LegacyPlayerStore.NewPassword();
        var player = new LegacyPlayerDocument
        {
            Id = id,
            // The client shows this until the player renames; it never parses it.
            Name = "Recruit",
            AccountType = (int)LegacyAccountType.Guest,
            Locale = request.Field("Locale") ?? "en",
            Level = starter.Level,
            Gold = starter.Gold,
            WarBucks = starter.WarBucks,
            Tickets = starter.Tickets,
            Scraps = starter.Scraps,
            DogTagMax = starter.DogTagMax,
            DogTagSeconds = 0,
            DogTagLastUpdate = Now(),
            PlacementMatchesRequired = starter.PlacementMatchesRequired,
            BeginnersLeague = 1,
            LastAction = Now(),
            CreatedUtc = DateTime.UtcNow,
            TutorialCompleted = false
        };

        await store.Insert(player, password, ct);
        string token = await store.IssueSession(player, TimeSpan.FromHours(starter.SessionLifetimeHours), ct);

        // OnCreateAccount indexes Player, Token, Password, PlayerData and Time without a presence
        // check; all five are mandatory. AccountType, WarArenaConfig, LeagueEvaluation,
        // MaintenanceMessage and BattleId are all guarded by ContainsKey and are omitted here.
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["Player"] = PlayerObject(player),
            ["AccountType"] = player.AccountType,
            ["Token"] = token,
            ["Password"] = password,
            ["PlayerData"] = PlayerDataObject(player),
            ["Time"] = Now()
        });
    }

    private static async Task<IResult> Login(LegacyRequest request, LegacyPlayerStore store, LegacyStarterState starter, CancellationToken ct)
    {
        string? id = request.Field("Id");
        string? password = request.Field("Password");
        if (id == null || password == null) return LegacyResponse.Failure(DatabaseResult.LoginFailure);

        var player = await store.VerifyPassword(id, password, ct);
        if (player == null) return LegacyResponse.Failure(DatabaseResult.LoginFailure);

        string token = await store.IssueSession(player, TimeSpan.FromHours(starter.SessionLifetimeHours), ct);

        // OnLoginToCustomAccount indexes Player, AccountType, Token and Password without a
        // presence check. It does NOT read PlayerData — the client follows up with GetPlayerData
        // from GameLoginManager.OnDataLoaded once this response lands.
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["Player"] = PlayerObject(player),
            ["AccountType"] = player.AccountType,
            ["Token"] = token,
            ["Password"] = password
        });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GetPlayerData"/>. Its <c>Buffers</c> field carries every
    /// buffer <c>RequestBufferManager</c> could not get an acknowledgement for on a prior run
    /// (<c>GetJsonData</c>) — applying them here, before the response is built, is what lets a
    /// crashed or offline session's purchases and equip changes survive. Unlike
    /// <see cref="DatabaseAction.SendRequestBuffer"/>, <c>OnGetPlayerData</c> reads no
    /// <c>RequestsResults</c>; it only expects the resulting authoritative state.
    /// </summary>
    private static async Task<IResult> GetPlayerData(LegacyRequest request, LegacyPlayerDocument player, LegacyBufferProcessor bufferProcessor, CancellationToken ct)
    {
        foreach (var buffer in LegacyBufferParser.ParseBuffers(request.Field("Buffers")))
            await bufferProcessor.Apply(player, buffer, ct);

        // OnGetPlayerData indexes Time and PlayerData without a presence check. Squad,
        // RemoveRewards, MaintenanceMessage, BeginnersLeague, LeagueId, Skill, MedalsBalance,
        // PlacementMatchesRequired, DeviceToken, LeagueEvaluation, dailyRewardData,
        // WarArenaConfig, Scraps, HeartDialog, ShowArenaDialog and DailyGold are all guarded by
        // ContainsKey. Omitting Squad is what puts the player outside a squad.
        var body = new JsonObject
        {
            ["Time"] = Now(),
            ["PlayerData"] = PlayerDataObject(player),
            ["Skill"] = player.Skill,
            ["MedalsBalance"] = player.MedalsBalance,
            ["PlacementMatchesRequired"] = player.PlacementMatchesRequired
        };
        if (player.LeagueId.Length > 0) body["LeagueId"] = player.LeagueId;
        if (player.BeginnersLeague > 0) body["BeginnersLeague"] = player.BeginnersLeague;
        return LegacyResponse.Json(DatabaseResult.Success, body);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.SendRequestBuffer"/>: applies the buffer's requests in
    /// order and returns their results. <c>OnSendRequestBuffer</c> reads both
    /// <c>RequestsResults</c> and <c>BufferId</c> with the single-argument <c>ParseString</c>
    /// overload (a plain <c>ToString()</c>), so — unlike <c>Player</c>/<c>PlayerData</c> — neither
    /// is a DynamoDB AttributeValue; <c>RequestsResults</c> is a JSON array serialized to a string.
    /// </summary>
    private static async Task<IResult> SendRequestBuffer(LegacyRequest request, LegacyPlayerDocument player, LegacyBufferProcessor bufferProcessor, CancellationToken ct)
    {
        string? bufferId = request.Field("BufferId");
        if (string.IsNullOrEmpty(bufferId)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var requests = LegacyBufferParser.ParseRequests(request.Field("Requests"));
        var results = await bufferProcessor.Apply(player, new ParsedBuffer(bufferId, requests), ct);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["RequestsResults"] = results.ToJsonString(),
            ["BufferId"] = bufferId
        });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.UpdateDeviceToken"/> (13). <c>OnUpdateDeviceToken</c> only
    /// logs, so no response fields are read; validation and persistence are all that matters.
    /// </summary>
    private static async Task<IResult> UpdateDeviceToken(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, CancellationToken ct)
    {
        string? deviceToken = request.Field("DeviceToken");
        string? locale = request.Field("Locale");
        if (deviceToken is { Length: > 4096 } || (locale != null && !AccountStore.ValidLocale(locale)))
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        var update = Builders<LegacyPlayerDocument>.Update.Set(x => x.LastAction, Now());
        if (deviceToken != null) update = update.Set(x => x.DeviceToken, deviceToken);
        if (locale != null) update = update.Set(x => x.Locale, locale);
        await store.Update(player.Id, update, ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.ChangeLanguage"/> (150). <c>OnChangeLanguage</c> reads no
    /// response fields (it only hides a dialog, and quits under a debug build).
    /// </summary>
    private static async Task<IResult> ChangeLanguage(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, CancellationToken ct)
    {
        string? locale = request.Field("Locale");
        if (locale == null || !AccountStore.ValidLocale(locale)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update.Set(x => x.Locale, locale), ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.ChangePlayerCountry"/> (196). This action has no case at
    /// all in the client's response switch, so nothing reads the body; presence of a plain
    /// <c>Result</c> the client treats as success (&lt;= 10) is all that is required.
    /// </summary>
    private static async Task<IResult> ChangePlayerCountry(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, CancellationToken ct)
    {
        string? code = request.Field("NewCountryCode");
        if (code == null || !Regex.IsMatch(code, @"\A[A-Za-z]{2}\z")) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update.Set(x => x.Country, code.ToUpperInvariant()), ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.UpdateSettings"/> (165). <c>OnSendSettings</c> reads no
    /// response fields; the request's <c>Settings</c> field is stored verbatim as the
    /// <c>SettingsManager.Settings</c> blob after validating it actually parses as that shape.
    /// </summary>
    private static async Task<IResult> UpdateSettings(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, CancellationToken ct)
    {
        string? json = request.Field("Settings");
        if (json == null) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        try { PlayerState.Read<Settings>(json); }
        catch (System.Text.Json.JsonException) { return LegacyResponse.Failure(DatabaseResult.JsonFailure); }
        await store.SetSerialized(player.Id, "Settings", json, ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.ChangePlayerName"/> (139). <c>OnChangePlayerName</c> reads
    /// <c>PayForRename</c>, <c>RenameCount</c> and <c>Name</c> — all bare, single-argument
    /// <c>StringParser</c> reads, so none are DynamoDB-wrapped.
    /// </summary>
    /// <remarks>
    /// Price follows <c>PlayerAnalytics.renameGoldPrice</c>: free while <c>RenameCount == 0</c>,
    /// otherwise <c>2^(RenameCount-1) * Constants.rowIds.SecondRenameGoldCost</c>. That row value
    /// is not yet extracted (<see cref="LegacyStarterState.SecondRenameGoldCost"/>), so a priced
    /// rename is refused with <see cref="DatabaseResult.ServerMaintenance"/> rather than guessed.
    /// The shift is capped at 30, not the client's 31: at 31 the client's own `int` arithmetic
    /// overflows into a negative price, and reproducing that would let a high rename count buy a
    /// name for negative gold. That is a safety cap on an economy exploit, not new gameplay logic.
    /// </remarks>
    private static async Task<IResult> ChangePlayerName(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacyStarterState starter, CancellationToken ct)
    {
        string? name = request.Field("Name");
        if (string.IsNullOrWhiteSpace(name) || name.Length > 15 || name.Any(char.IsControl))
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        bool clientRequestedPay = request.Int("PayForRename") == 1;

        int price = 0;
        if (player.RenameCount > 0)
        {
            if (starter.SecondRenameGoldCost is not int cost) return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
            price = (1 << Math.Clamp(player.RenameCount - 1, 0, 30)) * cost;
        }
        if (price > 0 && !clientRequestedPay) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        if (price > 0 && player.Gold < price) return LegacyResponse.Failure(DatabaseResult.NotEnoughGoldForChangeName);

        int newRenameCount = player.RenameCount + 1;
        var update = Builders<LegacyPlayerDocument>.Update.Set(x => x.Name, name).Set(x => x.RenameCount, newRenameCount);
        if (price > 0) update = update.Inc(x => x.Gold, -price);
        await store.Update(player.Id, update, ct);

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["Name"] = name,
            ["PayForRename"] = price > 0 ? 1 : 0,
            ["RenameCount"] = newRenameCount
        });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GetPlayerInfo"/> (170): a public lookup of another
    /// player's <c>Player</c>-shaped data. <c>OnGetPlayerInfo</c> reads <c>mResponse["PlayerInfo"]</c>
    /// as a <b>direct index on the top-level response dictionary</b>, not a <c>ContainsKey</c> or
    /// nested-<c>JToken</c> check — a real .NET dictionary throws on a missing key even when the
    /// caller immediately compares the result to null, so the key must always be present, using an
    /// explicit JSON <c>null</c> when the target player does not exist. <c>SquadWarsId</c> by
    /// contrast is <c>ContainsKey</c>-guarded and is omitted (no squad system yet).
    /// </summary>
    private static async Task<IResult> GetPlayerInfo(LegacyRequest request, LegacyPlayerStore store, CancellationToken ct)
    {
        string? targetId = request.Field("PlayerInfoId");
        var target = targetId == null ? null : await store.ById(targetId, ct);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["PlayerInfo"] = target == null ? null : PlayerObject(target, includeDeviceToken: false)
        });
    }

    /// <summary>
    /// Projects the <c>Player</c> object consumed by <c>DatabasePlayer.CreateFromDatabase</c>.
    /// </summary>
    /// <remarks>
    /// <c>Regions</c> is deliberately never emitted: it deserializes to a
    /// <c>Dictionary&lt;CloudRegionCode, int&gt;</c> of Photon Cloud region pings, and this
    /// deployment runs offline with no Photon. The client's null guard leaves
    /// <c>bestRegions</c> null, which is the correct representation of "no Photon regions".
    /// <paramref name="includeDeviceToken"/> is false for <see cref="GetPlayerInfo"/>: the push
    /// token has no use to a third party, and the client's own reader never requires it.
    /// </remarks>
    private static JsonObject PlayerObject(LegacyPlayerDocument p, bool includeDeviceToken = true)
    {
        var item = new JsonObject
        {
            ["Id"] = Dynamo.S(p.Id),
            ["Name"] = Dynamo.S(p.Name),
            ["Level"] = Dynamo.N(p.Level),
            ["Experience"] = Dynamo.N(p.Experience),
            ["Reputation"] = Dynamo.N(p.Reputation),
            ["Skill"] = Dynamo.N(p.Skill),
            ["Status"] = Dynamo.N(p.Status),
            ["AccountType"] = Dynamo.N(p.AccountType),
            ["ArmyPower"] = Dynamo.N(p.ArmyPower),
            ["BeginnersLeague"] = Dynamo.N(p.BeginnersLeague),
            ["LastAction"] = Dynamo.N(p.LastAction),
            ["MedalsBalance"] = Dynamo.N(p.MedalsBalance),
            ["PlacementMatchesRequired"] = Dynamo.N(p.PlacementMatchesRequired),
            ["SendLogs"] = Dynamo.N(p.SendLogs),
            ["SquadPoints"] = Dynamo.N(p.SquadPoints),
            ["SquadRank"] = Dynamo.N(p.SquadRank),
            ["Vip"] = Dynamo.N(p.Vip),
            ["VisualTimestamp"] = Dynamo.N(p.VisualTimestamp)
        };
        if (p.Country.Length > 0) item["Country"] = Dynamo.S(p.Country);
        if (includeDeviceToken && p.DeviceToken.Length > 0) item["DeviceToken"] = Dynamo.S(p.DeviceToken);
        if (p.LeagueId.Length > 0) item["LeagueId"] = Dynamo.S(p.LeagueId);
        if (p.SquadId.Length > 0) item["SquadId"] = Dynamo.S(p.SquadId);
        if (p.VisualType.Length > 0) item["VisualType"] = Dynamo.S(p.VisualType);

        // InventoryData, LevelManagerData and StatisticsData appear on the Player object as well
        // as inside PlayerData; the client parses them from both. Emit the same stored blob.
        CopyBlob(item, p, "InventoryData");
        CopyBlob(item, p, "LevelManagerData");
        CopyBlob(item, p, "StatisticsData");
        return item;
    }

    /// <summary>
    /// Projects the <c>PlayerData</c> object consumed by <c>ServerResponseHandler.LoadPlayerData</c>
    /// and, through <c>DatabaseSerializedObject.LoadObjects</c>, by every registered subsystem.
    /// </summary>
    private static JsonObject PlayerDataObject(LegacyPlayerDocument p)
    {
        var data = new JsonObject
        {
            ["Gold"] = Dynamo.N(p.Gold),
            ["WarBucks"] = Dynamo.N(p.WarBucks),
            ["Level"] = Dynamo.N(p.Level),
            ["LevelExperience"] = Dynamo.N(p.LevelExperience),
            ["Experience"] = Dynamo.N(p.Experience),
            ["ArmyPower"] = Dynamo.N(p.ArmyPower),
            ["Vip"] = Dynamo.N(p.Vip),
            ["VipStart"] = Dynamo.N(p.VipStart),
            ["Tickets"] = Dynamo.N(p.Tickets),
            ["Scraps"] = Dynamo.N(p.Scraps),
            ["Midnight"] = Dynamo.N(NextMidnight()),
            ["DogTagSeconds"] = Dynamo.N(p.DogTagSeconds),
            ["DogTagLastUpdate"] = Dynamo.N(p.DogTagLastUpdate),
            ["DogTagMax"] = Dynamo.N(p.DogTagMax),
            ["Position"] = Dynamo.N(p.Position),
            ["SendLogs"] = Dynamo.N(p.SendLogs),
            ["battlesLostInRow"] = Dynamo.N(p.BattlesLostInRow)
        };

        // Presence alone marks the tutorial finished; the client never reads the value.
        if (p.TutorialCompleted) data["TutorialData"] = Dynamo.S("1");

        // Each subsystem looks itself up by its own simple type name. A key that is absent takes
        // the client's LoadEmpty() path and yields its default instance, which is exactly what a
        // new account should get — so nothing is synthesised here.
        foreach (var (key, json) in p.Serialized)
            if (LegacyPlayerStore.SerializedKeys.Contains(key))
                data[key] = Dynamo.Json(json);

        return data;
    }

    private static void CopyBlob(JsonObject target, LegacyPlayerDocument p, string key)
    {
        if (p.Serialized.TryGetValue(key, out string? json)) target[key] = Dynamo.Json(json);
    }
}
