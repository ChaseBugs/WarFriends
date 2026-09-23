using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using MongoDB.Driver;
using War.Persistence;

namespace War.Backend.Legacy;

/// <summary>
/// Server-owned starting state for a new account. Bound from the <c>Legacy:Starter</c>
/// configuration section, on top of catalog-derived defaults (<see cref="FromCatalog"/>).
/// </summary>
/// <remarks>
/// The client's <c>CreateAccount</c> request carries <c>StartingGold</c>/<c>StartingWarbucks</c>
/// taken from a Fuseboxx A/B payload. Those are client-reported values on an account-management
/// action that has no session yet, so they are read for logging only and never assigned. The
/// balances below are the authority.
/// </remarks>
public sealed class LegacyStarterState
{
    /// <summary>
    /// Fallback used only when <see cref="LegacyCatalog"/> has no <c>Google2u.Constants</c> sheet
    /// loaded (no <c>Legacy:ContentPath</c> configured). When the catalog is loaded,
    /// <see cref="FromCatalog"/> overrides these with the verified sheet values:
    /// <c>StartingGold=75</c>, <c>StartingWarbucks=15000</c>, <c>DogTagCap=5</c> — none of these
    /// three fallback numbers is evidenced; they exist only so the boot chain still produces a
    /// playable (if unverified) account with no catalog configured at all.
    /// </summary>
    public long Gold { get; set; } = 500;
    public long WarBucks { get; set; } = 50;
    public long Tickets { get; set; }
    public long Scraps { get; set; }
    public int Level { get; set; } = 1;

    /// <summary>
    /// Total dog-tag regeneration capacity in <b>seconds</b> — <c>DogTagManager.max</c>, which the
    /// client computes as <c>DogTagCap * DogTagRefillTime</c> (a dog-tag <i>count</i> times the
    /// per-tag regen period), not the raw tag count. <see cref="FromCatalog"/> corrects this to the
    /// real product once both constants are loaded; this fallback (10 seconds) is deliberately
    /// tiny and unevidenced, matching the other catalog-free fallbacks' posture of "playable but not
    /// authoritative" rather than guessing a plausible-looking number.
    /// </summary>
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
    /// Applies the verified <c>Google2u.Constants</c> starter values on top of the hardcoded
    /// fallback defaults. Called before configuration binding, so an explicit
    /// <c>Legacy:Starter</c> override still takes precedence over either source.
    /// </summary>
    public static LegacyStarterState FromCatalog(LegacyCatalog catalog)
    {
        var state = new LegacyStarterState();
        if (catalog.Constant("StartingGold") is double gold) state.Gold = (long)gold;
        if (catalog.Constant("StartingWarbucks") is double warBucks) state.WarBucks = (long)warBucks;
        // DogTagManager.max = DogTagCap * DogTagRefillTime (a count times a per-tag period, in
        // seconds) — both constants must be present, or the product is not the client's real cap.
        if (catalog.ConstantInt("DogTagCap") is int dogTagCap && catalog.ConstantInt("DogTagRefillTime") is int dogTagRefillTime)
            state.DogTagMax = dogTagCap * dogTagRefillTime;
        return state;
    }
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

    public static void MapLegacy(this WebApplication app, LegacyPlayerStore store, LegacyBufferProcessor bufferProcessor, LegacyStarterState starter, LegacyCatalog catalog, LegacySquadStore squads)
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
                    return await ChangePlayerName(request, player, store, catalog, ct);

                case DatabaseAction.GetPlayerInfo:
                    return await GetPlayerInfo(request, store, ct);

                case DatabaseAction.RefillDogtags:
                    return await RefillDogtags(player, store, catalog, ct);

                case DatabaseAction.PayOneDogTag:
                    return await PayOneDogTag(player, store, catalog, ct);

                case DatabaseAction.CheckUniqueSquadName:
                    return await CheckUniqueSquadName(request, squads, ct);

                case DatabaseAction.CreateSquad:
                    return await CreateSquad(request, player, store, squads, catalog, ct);

                case DatabaseAction.JoinSquad:
                    return await JoinSquad(request, player, store, squads, ct);

                case DatabaseAction.GetSquadDetails:
                    return await GetSquadDetails(request, squads, ct);

                case DatabaseAction.GetAllSquadMembers:
                    return await GetAllSquadMembers(request, store, squads, ct);

                case DatabaseAction.GetFullSquadInfo:
                    return await GetFullSquadInfo(request, store, squads, ct);

                case DatabaseAction.InvitePlayerToSquad:
                    return await InvitePlayerToSquad(request, player, squads, ct);

                case DatabaseAction.JoinSquadRequest:
                    return await JoinSquadRequest(request, player, squads, ct);

                case DatabaseAction.AcceptSquadJoinRequest:
                    return await AcceptSquadJoinRequest(request, player, store, squads, ct);

                case DatabaseAction.DeclineSquadJoinRequest:
                    return await DeclineSquadJoinRequest(request, player, squads, ct);

                case DatabaseAction.DepositCards:
                    return await DepositCards(request, player, store, ct);

                case DatabaseAction.WithdrawCard:
                    return await WithdrawCard(request, player, store, catalog, ct);

                case DatabaseAction.CraftCard:
                    return await CraftCard(request, player, store, catalog, ct);

                case DatabaseAction.ClaimCraftedCard:
                    return await ClaimCraftedCard(player, store, catalog, ct);

                case DatabaseAction.NotifyPlayerToDeposit:
                    return await NotifyPlayerToDeposit(request, player, store, ct);

                case DatabaseAction.LeaveSquad:
                    return await LeaveSquad(player, store, squads, ct);

                case DatabaseAction.PromotePlayer:
                    return await PromotePlayer(request, player, store, squads, ct);

                case DatabaseAction.DemotePlayer:
                    return await DemotePlayer(request, player, store, squads, ct);

                case DatabaseAction.PromotePlayerToFounder:
                    return await PromotePlayerToFounder(request, player, store, squads, ct);

                case DatabaseAction.KickPlayer:
                    return await KickPlayer(request, player, store, squads, ct);

                case DatabaseAction.UpdateSquad:
                    return await UpdateSquad(request, player, squads, ct);

                case DatabaseAction.UpdateSquadEmblem:
                    return await UpdateSquadEmblem(request, player, squads, ct);

                case DatabaseAction.GetSquads:
                case DatabaseAction.FindSuggestedSquads:
                    return await GetSquads(request, squads, ct);

                case DatabaseAction.GameStartedTutorial:
                    return await GameStartedTutorial(player, store, ct);

                case DatabaseAction.TutorialEnded:
                    return await TutorialEnded(request, player, store, ct);

                case DatabaseAction.UpdateArmyPower:
                    // Action Success only; OnDataLoaded's shared case for this action reads nothing.
                    // Same non-authoritative display-hint semantics as LegacyBufferProcessor's
                    // buffered ArmyPower assertions — never used to compute rewards or matchmaking.
                    await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update.Set(x => x.ArmyPower, request.Int("ArmyPower", player.ArmyPower)), ct);
                    return LegacyResponse.Json(DatabaseResult.Success);

                case DatabaseAction.UpdateRegionPings:
                    // OnUpdateRegionPings() is a literal empty method: no field is ever read. The
                    // client's Regions/Connection payload describes Photon Cloud region latency,
                    // which is meaningless offline; it is intentionally not stored or relayed.
                case DatabaseAction.PhotonIsFull:
                    // OnPhotonIsFull() only logs. There is no Photon Cloud to have reported this.
                    return LegacyResponse.Json(DatabaseResult.Success);

                case DatabaseAction.ChatShownFirstTime:
                    return await SetAnalyticsFlag(player, store, "chatShown", ct);
                case DatabaseAction.CustomizationShown:
                    return await SetAnalyticsFlag(player, store, "customizationShown", ct);
                case DatabaseAction.WarpathShownFirstTime:
                    return await SetAnalyticsFlag(player, store, "warpathShown", ct);
                case DatabaseAction.CardpoolShown:
                    return await SetAnalyticsFlag(player, store, "cardpoolShown", ct);
                case DatabaseAction.CraftingShown:
                    return await SetAnalyticsFlag(player, store, "craftingShown", ct);
                case DatabaseAction.LeagueLeaderboardShown:
                    return await SetAnalyticsFlag(player, store, "leagueLeaderboardsShown", ct);
                case DatabaseAction.ElitesFeatureShown:
                    // ElitesFeatureShownRequest.OnSuccess logs and reads nothing.
                    return await SetAnalyticsFlag(player, store, "elitesShown", ct);

                case DatabaseAction.Test:
                    // OnTest reads mResponse["Test"] as an unguarded top-level index in a log
                    // statement — the value itself is never asserted against, just printed.
                    return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["Test"] = true });

                case DatabaseAction.OnVIPExpired:
                    // OnVipExpired only re-syncs DogTagSeconds/DogTagLastUpdate, and only if both
                    // keys are present (ContainsKey-guarded) — because losing VIP shrinks the
                    // player's dog-tag cap by its VIP bonus. No account here has ever held VIP
                    // (BuyVip needs real receipt verification this server does not implement, per
                    // Server_guide.md §11.6), so there is no bonus capacity to revoke; omitting both
                    // keys is the correct "nothing changed" answer, not a shortcut.
                    return LegacyResponse.Json(DatabaseResult.Success);

                case DatabaseAction.ReportCheater:
                    // OnReportCheater reads mResponse["PlayerID"] (capitalized exactly like this,
                    // not "PlayerId") as an unguarded top-level index in a log statement — it must
                    // always be present. Echoes the client's own asserted ReportedPlayerId; the
                    // report content itself is diagnostic only; not persisted or actioned yet.
                    app.Logger.LogWarning("Legacy cheater report from player {PlayerId} against {ReportedPlayerId} (type {ReportType}).", player.Id, request.Field("ReportedPlayerId"), request.Field("ReportType"));
                    return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["PlayerID"] = request.Field("ReportedPlayerId") });

                case DatabaseAction.SendLog:
                    // OnSendLog reads mResponse["LogId"] as an unguarded top-level index — it must
                    // always be present, or Logs.instance.logsSent never becomes true and the
                    // client keeps retrying. Log content itself is diagnostic only; not persisted.
                    app.Logger.LogInformation("Legacy client log received from player {PlayerId} ({Bytes} bytes).", player.Id, request.Field("Logs")?.Length ?? 0);
                    return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["LogId"] = Guid.NewGuid().ToString("N") });

                case DatabaseAction.SendCrashReport:
                    // OnSendCrashReport reads nothing. No live call site was found for this action
                    // in the active client, but it costs nothing to answer correctly.
                    app.Logger.LogWarning("Legacy crash report received from player {PlayerId}.", player.Id);
                    return LegacyResponse.Json(DatabaseResult.Success);

                case DatabaseAction.ErrorMessage:
                    // BeanstalkServerManager.OnWebRequestError reports its own failed requests here
                    // — logged only, no response case in ServerResponseHandler at all. Notably, the
                    // client's own sender skips this action entirely when mUrlCreator.isLocalhost is
                    // true, so it is unreachable from a client pointed at http://localhost — real for
                    // any other host (LAN IP, domain) ServerEndpoint.BaseUrl is repointed to.
                    app.Logger.LogWarning("Legacy client-reported error from player {PlayerId} on action {DbAction}: {ExceptionMessage}", player.Id, request.Field("DbAction"), request.Field("ExceptionMessage"));
                    return LegacyResponse.Json(DatabaseResult.Success);

                case DatabaseAction.UpdateAnalytics:
                    // The request's PlayerAnalytics field is JsonConvert.SerializeObject(PlayerAnalytics.GetUpdates()),
                    // an unverified delta shape distinct from the full PlayerAnalyticsData blob.
                    // Merging it in without knowing GetUpdates()'s exact contract risks silently
                    // corrupting that blob, so it is logged only, matching the trivial client-side
                    // reader (ElitesFeatureShownRequest.OnSuccess logs and reads nothing).
                    app.Logger.LogInformation("Legacy analytics update received from player {PlayerId}.", player.Id);
                    return LegacyResponse.Json(DatabaseResult.Success);

                case DatabaseAction.SaveFuseConfigs:
                    // The dispatcher's own case is LogResponse(databaseAction) only — no field is
                    // read. fuseData is Fuse-provider configuration, not gameplay state.
                    app.Logger.LogInformation("Legacy Fuse configuration received from player {PlayerId}.", player.Id);
                    return LegacyResponse.Json(DatabaseResult.Success);

                case DatabaseAction.SpecialOfferShowed:
                    // OnSuccess is `Singleton<OfferManager>.instance.ShowedSavedOnServer()`, which
                    // reads nothing from the response — purely a "don't show this offer again"
                    // presentation fact, separable from the offer's actual accept/purchase flow
                    // (GenerateSpecialOffer/AcceptSpecialOffer), which stays refused per §11.6 real
                    // receipt verification. `showedOffers` is logged, not modeled or replayed, since
                    // no implemented action reads it back — matches SendCrashReport's precedent.
                    app.Logger.LogInformation("Legacy special-offer shown list received from player {PlayerId}: {ShowedOffers}", player.Id, request.Field("showedOffers"));
                    return LegacyResponse.Json(DatabaseResult.Success);

                case DatabaseAction.WarArenaShown:
                    // WarArenaShownRequest.OnSuccess reads nothing from the response either — it only
                    // touches the client's own local WarArena state. Logged only, same posture as
                    // SendCrashReport: real War Arena play (EnterArena/TakeArenaLife/…) still needs
                    // Battle Server result trust and stays unimplemented, but acknowledging that an
                    // arena intro screen was shown fabricates nothing.
                    app.Logger.LogInformation("Legacy WarArenaShown received from player {PlayerId} for arena {ArenaId}.", player.Id, request.Field("ArenaId"));
                    return LegacyResponse.Json(DatabaseResult.Success);

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
    /// otherwise <c>2^(RenameCount-1) * Constants.rowIds.SecondRenameGoldCost</c>, where the row
    /// value (verified from the recovered catalog: <c>SecondRenameGoldCost = 25</c>) comes from
    /// <see cref="LegacyCatalog.Constant"/>. If no catalog is loaded, a priced rename is refused
    /// with <see cref="DatabaseResult.ServerMaintenance"/> rather than guessed. The shift is capped
    /// at 30, not the client's 31: at 31 the client's own `int` arithmetic overflows into a
    /// negative price, and reproducing that would let a high rename count buy a name for negative
    /// gold. That is a safety cap on an economy exploit, not new gameplay logic.
    /// </remarks>
    private static async Task<IResult> ChangePlayerName(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacyCatalog catalog, CancellationToken ct)
    {
        string? name = request.Field("Name");
        if (string.IsNullOrWhiteSpace(name) || name.Length > 15 || name.Any(char.IsControl))
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        bool clientRequestedPay = request.Int("PayForRename") == 1;

        int price = 0;
        if (player.RenameCount > 0)
        {
            if (catalog.ConstantInt("SecondRenameGoldCost") is not int cost) return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
            price = (1 << Math.Clamp(player.RenameCount - 1, 0, 30)) * cost;
        }
        if (price > 0 && !clientRequestedPay) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        int newRenameCount = player.RenameCount + 1;
        var update = Builders<LegacyPlayerDocument>.Update.Set(x => x.Name, name).Set(x => x.RenameCount, newRenameCount);
        if (price > 0) update = update.Inc(x => x.Gold, -price);
        // The balance check is folded into the write itself (see LegacyPlayerStore.TryUpdate) so two
        // concurrent renames can't both pass a stale check and jointly overspend.
        if (await store.TryUpdate(player.Id, x => price == 0 || x.Gold >= price, update, ct) == null)
            return LegacyResponse.Failure(DatabaseResult.NotEnoughGoldForChangeName);

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["Name"] = name,
            ["PayForRename"] = price > 0 ? 1 : 0,
            ["RenameCount"] = newRenameCount
        });
    }

    /// <summary>
    /// The server-authoritative mirror of <c>DogTagManager</c>'s own local regeneration formula:
    /// the stored <c>DogTagSeconds</c>/<c>DogTagLastUpdate</c> plus elapsed real time, clamped to
    /// <c>[0, max]</c>. Neither <see cref="RefillDogtags"/> nor <see cref="PayOneDogTag"/> can price
    /// or consume a dog tag correctly without first re-deriving this the same way the client does.
    /// </summary>
    private static int CurrentDogTagSeconds(LegacyPlayerDocument player, int now) =>
        Math.Clamp(player.DogTagSeconds + (now - player.DogTagLastUpdate), 0, player.DogTagMax);

    /// <summary>
    /// Answers <see cref="DatabaseAction.RefillDogtags"/> (70): an instant, gold-priced full
    /// refill. <c>OnRefillDogtags</c> reads <c>mResponse["Gold"]</c> as an unguarded top-level
    /// index, so it is always emitted on success.
    /// </summary>
    /// <remarks>
    /// <para>The request itself carries no price — the client only sends the
    /// <c>DogTagRefillTime</c>/<c>DogTagCap</c> constants it built its own UI from, as an
    /// assertion the server does not need and does not check. The real price is
    /// <c>DogTagManager.dogtagRefillPrice</c>, a hardcoded client formula (not a catalog row):
    /// <c>35 - 2 * currentDogtags</c>, recomputed here from the server's own stored regeneration
    /// state — never trusted from the client.</para>
    /// <para><c>DogtagDialog.RefillButtonClick</c> never lets a genuine client send this request
    /// while already full (it shows a confirmation dialog instead), and there is no dedicated
    /// result code for that case in the recovered enum. Treating it as a no-op success — no charge,
    /// nothing to refill — follows the same reasoning already used for "buy an already-owned
    /// item": inventing a code with no evidenced client handling would be a guess, and charging for
    /// a refill that adds nothing would be worse than refusing it.</para>
    /// </remarks>
    private static async Task<IResult> RefillDogtags(LegacyPlayerDocument player, LegacyPlayerStore store, LegacyCatalog catalog, CancellationToken ct)
    {
        int refillSeconds = catalog.ConstantInt("DogTagRefillTime") ?? player.DogTagMax;
        int now = Now();
        int currentSeconds = CurrentDogTagSeconds(player, now);

        if (refillSeconds > 0 && currentSeconds >= player.DogTagMax)
            return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["Gold"] = player.Gold });

        int currentDogtags = refillSeconds > 0 ? currentSeconds / refillSeconds : 0;
        long price = Math.Max(0, 35 - 2 * currentDogtags);

        int filledSeconds = player.DogTagMax;
        var updated = await store.TryUpdate(player.Id, x => x.Gold >= price, Builders<LegacyPlayerDocument>.Update
            .Set(x => x.DogTagSeconds, filledSeconds)
            .Set(x => x.DogTagLastUpdate, now)
            .Inc(x => x.Gold, -price), ct);
        if (updated == null) return LegacyResponse.Failure(DatabaseResult.NotEnoughGoldForDogtags);

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["Gold"] = updated.Gold });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.PayOneDogTag"/> (129). Despite the name, this is not a
    /// purchase: every call site (<c>GameControllerOnline.PayDogtag</c>/
    /// <c>GameControllerDeathMatch</c>) spends one already-held dog tag as an early-quit penalty —
    /// "pay [with] one dog tag", not "pay [gold] for one dog tag". No price, no gold field read by
    /// <c>OnPayOneDogTag</c>; it unconditionally reads <c>LastUpdate</c>/<c>Seconds</c> as unguarded
    /// top-level indices, so both are always emitted.
    /// </summary>
    private static async Task<IResult> PayOneDogTag(LegacyPlayerDocument player, LegacyPlayerStore store, LegacyCatalog catalog, CancellationToken ct)
    {
        int refillSeconds = catalog.ConstantInt("DogTagRefillTime") ?? player.DogTagMax;
        int now = Now();
        int newSeconds = Math.Max(0, CurrentDogTagSeconds(player, now) - refillSeconds);

        await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update
            .Set(x => x.DogTagSeconds, newSeconds)
            .Set(x => x.DogTagLastUpdate, now), ct);

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["LastUpdate"] = now,
            ["Seconds"] = newSeconds
        });
    }

    /// <summary>
    /// Projects a <see cref="LegacySquadDocument"/> into the shape <c>DatabaseSquad.CreateFromDatabase</c>
    /// reads. Battle-derived fields (<c>Kills</c>/<c>BattlesWon</c>/<c>SquadPoints</c>/Squad Wars
    /// round data, …) are real fields in that reader but have no meaning without Battle Server
    /// result trust — see the remarks on <see cref="LegacySquadStore"/> — so they are emitted as
    /// zero/empty, the correct "never played a squad war" state, not a placeholder for missing work.
    /// </summary>
    private static JsonObject SquadObject(LegacySquadDocument squad) => new()
    {
        ["Id"] = Dynamo.S(squad.Id),
        ["Message"] = Dynamo.S(squad.Message),
        ["IsPublic"] = Dynamo.N(squad.IsPublic ? 1 : 0),
        ["Icon"] = Dynamo.S(squad.Icon),
        ["SkillRequirement"] = Dynamo.N(squad.SkillRequirement),
        ["Size"] = Dynamo.N(squad.Members.Count),
        ["Level"] = Dynamo.N(1),
        ["Skill"] = Dynamo.N(0),
        ["Position"] = Dynamo.N(0),
        ["SquadPoints"] = Dynamo.N(0),
        ["Experience"] = Dynamo.N(0),
        ["LevelExperience"] = Dynamo.N(0),
        ["Kills"] = Dynamo.N(0),
        ["BattlesLost"] = Dynamo.N(0),
        ["BattlesWon"] = Dynamo.N(0),
        ["CardsPlayed"] = Dynamo.N(0),
        ["BestSkill"] = Dynamo.N(0),
        ["UnitsDeployed"] = Dynamo.N(0),
        ["TiersCompleted"] = Dynamo.N(0),
        ["SquadPointsBest"] = Dynamo.N(0),
        ["SquadWarWins"] = Dynamo.N(0),
        ["RoundId"] = Dynamo.S("")
    };

    /// <summary>
    /// Answers <see cref="DatabaseAction.CheckUniqueSquadName"/>. <c>OnCheckUniqueSquadName</c> reads
    /// <c>mResponse["IsUnique"]</c> as an unguarded top-level index, so it is always emitted.
    /// Mongo's own <c>_id</c> uniqueness on <see cref="LegacySquadDocument.Id"/> (the squad's display
    /// name doubles as its id — <c>CreateSquad</c> sends no separate identifier) is exactly the
    /// uniqueness this answers; no separate reservation/lock is needed.
    /// </summary>
    private static async Task<IResult> CheckUniqueSquadName(LegacyRequest request, LegacySquadStore squads, CancellationToken ct)
    {
        string? name = request.Field("SquadId");
        if (string.IsNullOrEmpty(name)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var existing = await squads.ById(name, ct);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["IsUnique"] = existing == null });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.CreateSquad"/>. No case exists for this action in
    /// <c>ServerResponseHandler</c>'s failure-branch switch at all, so — like <c>PromoteUnit</c> — a
    /// bare <c>Result</c> is the entire failure contract; only the success path needs real fields.
    /// </summary>
    /// <remarks>
    /// <para>Price is real, verified, and escalating, not flat: <c>PlayerAnalytics.createSquadWarBucksPrice
    /// = (squadCreationsCount + 1) * Constants.rowIds.WarBucksCreateSquadPrice</c> (verified 50,000
    /// Warbucks) — reproduced exactly via <see cref="LegacyPlayerDocument.SquadCreationsCount"/>,
    /// incremented on every successful creation and echoed back as <c>squadCreationsCnt</c> (an
    /// optional field the client syncs its own local counter from).</para>
    /// <para><c>SquadCreateScreen.CreateButtonClick</c> validates name/message length
    /// (<c>DatabaseSquad.maxSquadName</c>=15/<c>maxSquadMessage</c>=100) and refuses outright if the
    /// player already has a squad — reproduced here as guards, not just UI. The squad is inserted
    /// (with the creator as <c>SquadRank.Leader</c>) <b>before</b> the price is charged, so a
    /// name collision (<c>SquadnameTaken</c>) never needs a refund path.</para>
    /// <para>No verified maximum squad size exists in the recovered catalog (<c>GetSquadRankSize</c>
    /// depends on a sheet not traced), so member-count gating is not enforced anywhere in this
    /// vertical — a real, documented gap, not silently assumed unlimited.</para>
    /// </remarks>
    private static async Task<IResult> CreateSquad(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacySquadStore squads, LegacyCatalog catalog, CancellationToken ct)
    {
        string? name = request.Field("SquadId");
        if (string.IsNullOrEmpty(name) || name.Length > 15) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        string message = request.Field("Message") ?? "";
        if (message.Length > 100) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        bool isPublic = request.Int("IsPublic") != 0;
        string icon = request.Field("Icon") ?? "";
        int skillRequirement = Math.Clamp(request.Int("SkillRequirement"), 0, 5000);

        if (player.SquadId.Length > 0) return LegacyResponse.Failure(DatabaseResult.PlayerAlreadyInSquad);
        if (catalog.ConstantInt("WarBucksCreateSquadPrice") is not int perCreationPrice) return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);

        var squad = new LegacySquadDocument
        {
            Id = name,
            Message = message,
            IsPublic = isPublic,
            Icon = icon,
            SkillRequirement = skillRequirement,
            Members = [new LegacySquadMember { PlayerId = player.Id, Rank = (int)LegacySquadRank.Leader }],
            CreatedUtc = DateTime.UtcNow
        };
        if (!await squads.TryInsert(squad, ct)) return LegacyResponse.Failure(DatabaseResult.SquadnameTaken);

        long price = (player.SquadCreationsCount + 1) * (long)perCreationPrice;
        int newCreationsCount = player.SquadCreationsCount + 1;
        // The balance check is folded into the write itself (see LegacyPlayerStore.TryUpdate) so two
        // concurrent CreateSquad attempts can't both pass a stale check and jointly overspend.
        if (await store.TryUpdate(player.Id, x => x.WarBucks >= price, Builders<LegacyPlayerDocument>.Update
            .Set(x => x.SquadId, name)
            .Set(x => x.SquadRank, (int)LegacySquadRank.Leader)
            .Set(x => x.SquadCreationsCount, newCreationsCount)
            .Inc(x => x.WarBucks, -price), ct) == null)
        {
            // The squad document was already inserted to claim the name atomically; delete it
            // outright on a refused purchase rather than leave an empty, publicly-searchable squad
            // behind (removing just the member would still leave a real, orphaned squad document —
            // caught by GetSquads/FindSuggestedSquads returning it as a real search result).
            await squads.Delete(name, ct);
            return LegacyResponse.Failure(DatabaseResult.NotEnoughWarBucksForCreateSquad);
        }

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["SquadId"] = name,
            ["PlayerRank"] = (int)LegacySquadRank.Leader,
            ["Squad"] = SquadObject(squad),
            ["squadCreationsCnt"] = newCreationsCount
        });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.JoinSquad"/>: a direct join of a public squad, or accepting
    /// an invite to a private one. <c>OnJoinSquad</c> reads <c>SquadId</c>/<c>PlayerRank</c> as
    /// unguarded top-level indices; the optional first-join Gold reward
    /// (<c>GoldRewardFirstTimeSquad</c>, verified 50 Gold) is a real, evidenced <c>Constants</c>
    /// value but is deliberately not implemented this pass — it needs a "claimed once" flag inside
    /// the still-unmodeled <c>PlayerAnalyticsData</c> blob, and granting it without that tracking
    /// would let it be re-claimed on every squad join.
    /// </summary>
    /// <remarks>
    /// The recovered enum has no separate "accept invite" action — <c>JoinSquad</c>'s own optional
    /// <c>MessageId</c> is how a genuine client accepts one, referencing the invite notification
    /// message. Rather than require the message/inbox system the owner's "skip Social" instruction
    /// already covers, a private squad is instead joinable here when the caller is in that squad's
    /// own <see cref="LegacySquadDocument.PendingInvites"/> (populated by
    /// <see cref="InvitePlayerToSquad"/>) — the same real effect without needing a delivered message.
    /// </remarks>
    private static async Task<IResult> JoinSquad(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacySquadStore squads, CancellationToken ct)
    {
        string? squadId = request.Field("NewSquadId");
        if (string.IsNullOrEmpty(squadId)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        if (player.SquadId.Length > 0)
            return LegacyResponse.Failure(player.SquadId == squadId ? DatabaseResult.JoiningSameSquad : DatabaseResult.PlayerAlreadyInSquadCantJoin);

        var squad = await squads.ById(squadId, ct);
        if (squad == null) return LegacyResponse.Failure(DatabaseResult.SquadNoLongerExists);
        if (!squad.IsPublic && !squad.PendingInvites.Contains(player.Id)) return LegacyResponse.Failure(DatabaseResult.SquadIsNotPublic);

        if (!await squads.TryAddMember(squadId, new LegacySquadMember { PlayerId = player.Id, Rank = (int)LegacySquadRank.Member }, ct))
            return LegacyResponse.Failure(DatabaseResult.JoiningSameSquad);
        if (!squad.IsPublic) await squads.Update(squadId, Builders<LegacySquadDocument>.Update.Pull(x => x.PendingInvites, player.Id), ct);

        await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update
            .Set(x => x.SquadId, squadId)
            .Set(x => x.SquadRank, (int)LegacySquadRank.Member), ct);

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["SquadId"] = squadId,
            ["PlayerRank"] = (int)LegacySquadRank.Member
        });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GetSquadDetails"/>. <c>OnGetSquadDetails</c> casts
    /// <c>mResponse["Squad"]</c> directly, an unguarded top-level index, so it is always emitted on
    /// success. No case exists for this action in the failure-branch switch, so a bare <c>Result</c>
    /// covers "no such squad".
    /// </summary>
    private static async Task<IResult> GetSquadDetails(LegacyRequest request, LegacySquadStore squads, CancellationToken ct)
    {
        string? squadId = request.Field("SquadId");
        if (string.IsNullOrEmpty(squadId)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var squad = await squads.ById(squadId, ct);
        if (squad == null) return LegacyResponse.Failure(DatabaseResult.NoSquadFound);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["Squad"] = SquadObject(squad) });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GetAllSquadMembers"/>. <c>OnGetAllSquadMembers</c> casts
    /// <c>mResponse["SquadMembers"]</c> to a <c>JArray</c> unguarded, and reads <c>SquadId</c>
    /// unguarded too. Each member is the same <c>Player</c>-shaped projection as
    /// <see cref="GetPlayerInfo"/>'s <c>PlayerInfo</c>, since both feed the same
    /// <c>DatabasePlayer.CreateFromDatabase</c> reader.
    /// </summary>
    private static async Task<IResult> GetAllSquadMembers(LegacyRequest request, LegacyPlayerStore store, LegacySquadStore squads, CancellationToken ct)
    {
        string? squadId = request.Field("SquadId");
        if (string.IsNullOrEmpty(squadId)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var squad = await squads.ById(squadId, ct);
        if (squad == null) return LegacyResponse.Failure(DatabaseResult.NoSquadFound);

        var members = await store.ByIds(squad.Members.Select(m => m.PlayerId), ct);
        var array = new JsonArray();
        foreach (var member in members) array.Add(PlayerObject(member, includeDeviceToken: false));

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["SquadId"] = squadId,
            ["SquadMembers"] = array
        });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GetFullSquadInfo"/> (151). <c>OnGetFullSquadInfo</c> is
    /// literally <c>OnGetSquadDetails()</c> followed by <c>OnGetAllSquadMembers()</c> against the
    /// *same* response body, so this combines both projections into one answer rather than
    /// reproducing either reader from scratch.
    /// </summary>
    private static async Task<IResult> GetFullSquadInfo(LegacyRequest request, LegacyPlayerStore store, LegacySquadStore squads, CancellationToken ct)
    {
        string? squadId = request.Field("SquadId");
        if (string.IsNullOrEmpty(squadId)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var squad = await squads.ById(squadId, ct);
        if (squad == null) return LegacyResponse.Failure(DatabaseResult.NoSquadFound);

        var members = await store.ByIds(squad.Members.Select(m => m.PlayerId), ct);
        var array = new JsonArray();
        foreach (var member in members) array.Add(PlayerObject(member, includeDeviceToken: false));

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["Squad"] = SquadObject(squad),
            ["SquadId"] = squadId,
            ["SquadMembers"] = array
        });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.InvitePlayerToSquad"/> (59). <c>OnInvitePlayerToSquad</c>
    /// reads nothing at all — it only hides a waiting dialog — so a bare <c>Result</c> is the whole
    /// contract. Any current member may invite (not gated to Leader/Coleader — no evidence either
    /// way was found, and this is the more permissive, less surprising default for a social action).
    /// </summary>
    private static async Task<IResult> InvitePlayerToSquad(LegacyRequest request, LegacyPlayerDocument player, LegacySquadStore squads, CancellationToken ct)
    {
        string? targetId = request.Field("PlayerToInviteId");
        if (string.IsNullOrEmpty(targetId) || targetId == player.Id) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        if (player.SquadId.Length == 0) return LegacyResponse.Failure(DatabaseResult.NotLeaderOfSquad);

        await squads.Update(player.SquadId, Builders<LegacySquadDocument>.Update.AddToSet(x => x.PendingInvites, targetId), ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.JoinSquadRequest"/> (132): asks to join a private squad.
    /// <c>OnJoinSquadRequest</c> reads nothing from the response — it only flips a local UI flag —
    /// so a bare <c>Result</c> is the whole contract. Recorded in
    /// <see cref="LegacySquadDocument.PendingRequests"/> for a Leader/Coleader to later resolve via
    /// <see cref="AcceptSquadJoinRequest"/>/<see cref="DeclineSquadJoinRequest"/>.
    /// </summary>
    private static async Task<IResult> JoinSquadRequest(LegacyRequest request, LegacyPlayerDocument player, LegacySquadStore squads, CancellationToken ct)
    {
        string? squadId = request.Field("SquadId");
        if (string.IsNullOrEmpty(squadId)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        if (player.SquadId.Length > 0) return LegacyResponse.Failure(DatabaseResult.PlayerAlreadyInSquadCantJoin);
        var squad = await squads.ById(squadId, ct);
        if (squad == null) return LegacyResponse.Failure(DatabaseResult.SquadNoLongerExists);

        await squads.Update(squadId, Builders<LegacySquadDocument>.Update.AddToSet(x => x.PendingRequests, player.Id), ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.AcceptSquadJoinRequest"/> (133). <c>joinedPlayer</c> is
    /// <c>ContainsKey</c>-guarded, so it is optional, but is included (the same <c>Player</c>
    /// projection used throughout this vertical) since it costs nothing extra.
    /// </summary>
    private static async Task<IResult> AcceptSquadJoinRequest(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacySquadStore squads, CancellationToken ct)
    {
        string? targetId = request.Field("PlayerToJoin");
        if (string.IsNullOrEmpty(targetId)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var (squad, error) = await RequireSquadLeadership(player, squads, ct);
        if (error != null) return LegacyResponse.Failure(error.Value);
        if (!squad!.PendingRequests.Contains(targetId)) return LegacyResponse.Failure(DatabaseResult.SquadJoinRequestNotExists);

        if (!await squads.TryAddMember(player.SquadId, new LegacySquadMember { PlayerId = targetId, Rank = (int)LegacySquadRank.Member }, ct))
            return LegacyResponse.Failure(DatabaseResult.JoiningSameSquad);
        await squads.Update(player.SquadId, Builders<LegacySquadDocument>.Update.Pull(x => x.PendingRequests, targetId), ct);
        await store.Update(targetId, Builders<LegacyPlayerDocument>.Update
            .Set(x => x.SquadId, player.SquadId)
            .Set(x => x.SquadRank, (int)LegacySquadRank.Member), ct);

        var target = await store.ById(targetId, ct);
        var response = new JsonObject();
        if (target != null) response["joinedPlayer"] = PlayerObject(target, includeDeviceToken: false);
        return LegacyResponse.Json(DatabaseResult.Success, response);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.DeclineSquadJoinRequest"/> (181).
    /// <c>OnDeclineSquadJoinRequest</c> reads only from its own already-sent <c>postData</c> — the
    /// client's local request fields, never the server's response body at all — so the server side
    /// of this contract needs no response fields whatsoever; only the real effect (removing the
    /// pending request) matters.
    /// </summary>
    private static async Task<IResult> DeclineSquadJoinRequest(LegacyRequest request, LegacyPlayerDocument player, LegacySquadStore squads, CancellationToken ct)
    {
        string? targetId = request.Field("Id");
        if (string.IsNullOrEmpty(targetId)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var (squad, error) = await RequireSquadLeadership(player, squads, ct);
        if (error != null) return LegacyResponse.Failure(error.Value);

        await squads.Update(player.SquadId, Builders<LegacySquadDocument>.Update.Pull(x => x.PendingRequests, targetId), ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.DepositCards"/> (174). <c>OnDepositCards</c> only reads a
    /// guarded, unimplemented <c>NextBuddyDeposit</c>, so a bare <c>Result</c> is the whole success
    /// contract. <c>AddedCards</c>/<c>RemovedCards</c> are each a JSON-serialized
    /// <c>Dictionary&lt;string, string&gt;</c> — card id to a *further* JSON-serialized
    /// <c>CardManager.CardData</c> (double-encoded) — reproduced by <see cref="ParseDepositedCardAmounts"/>.
    /// </summary>
    /// <remarks>
    /// The pool is not a separate structure: a squad member's deposited cards live on their own
    /// <see cref="LegacyPlayerDocument.DepositedCards"/>, which is why <c>DatabasePlayer.CreateFromDatabase</c>
    /// parses a <c>DepositedCards</c> map off *each squad member's own player record* — visible to
    /// squadmates through <c>GetAllSquadMembers</c>/<c>GetSquadDetails</c>/<c>GetFullSquadInfo</c>,
    /// all of which already project the full <c>Player</c> shape via <see cref="PlayerObject"/>.
    /// Buddy-card deposits use a distinct wire shape (a numeric <c>"start-end"</c> range key instead
    /// of a card id) and are out of scope — a request naming the literal id <c>"BuddyCard"</c> is
    /// refused rather than silently mishandled.
    /// </remarks>
    private static async Task<IResult> DepositCards(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, CancellationToken ct)
    {
        string? addedJson = request.Field("AddedCards");
        string? removedJson = request.Field("RemovedCards");
        if (addedJson == null || removedJson == null) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        Dictionary<string, int> added, removed;
        try
        {
            added = ParseDepositedCardAmounts(addedJson);
            removed = ParseDepositedCardAmounts(removedJson);
        }
        catch (JsonException)
        {
            return LegacyResponse.Failure(DatabaseResult.JsonFailure);
        }
        if (added.ContainsKey("BuddyCard") || removed.ContainsKey("BuddyCard")) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        var cards = PlayerState.Read<CardManagerData>(player.Serialized.GetValueOrDefault("CardManagerData"));
        var depositedCards = new Dictionary<string, int>(player.DepositedCards);

        foreach (var (cardId, amount) in removed)
        {
            if (amount <= 0) continue;
            if (!depositedCards.TryGetValue(cardId, out int have) || have < amount) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
            depositedCards[cardId] = have - amount;
            if (depositedCards[cardId] <= 0) depositedCards.Remove(cardId);
            if (!cards.CardData.TryGetValue(cardId, out var returned)) cards.CardData[cardId] = returned = new SavedCardData();
            returned.Amount += amount;
        }
        foreach (var (cardId, amount) in added)
        {
            if (amount <= 0) continue;
            if (!cards.CardData.TryGetValue(cardId, out var owned) || owned.Amount < amount) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
            owned.Amount -= amount;
            depositedCards[cardId] = depositedCards.GetValueOrDefault(cardId) + amount;
        }

        await store.SetSerialized(player.Id, "CardManagerData", PlayerState.Write(cards), ct);
        await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update.Set(x => x.DepositedCards, depositedCards), ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Parses <c>CardpoolDialog.GetCardsInJson</c>'s wire shape: a JSON object of card id to a
    /// further JSON-serialized <c>{"amount":N}</c> string (double-encoded, not a bare number).
    /// Malformed individual entries are skipped rather than failing the whole request.
    /// </summary>
    private static Dictionary<string, int> ParseDepositedCardAmounts(string json)
    {
        var result = new Dictionary<string, int>();
        if (JsonNode.Parse(json) is not JsonObject obj) return result;
        foreach (var (cardId, value) in obj)
        {
            if (value?.GetValue<string>() is not string inner) continue;
            if (JsonNode.Parse(inner) is not JsonObject cardData) continue;
            if (cardData["amount"]?.GetValue<int>() is int amount && amount > 0) result[cardId] = amount;
        }
        return result;
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.WithdrawCard"/> (175). <c>OnWithdrawCard</c> reads
    /// <c>mResponse["NextWithdraw"]</c> as an unguarded top-level index, so it is always emitted.
    /// The cooldown is server-owned and real: <c>Google2u.Constants</c>' verified
    /// <c>CardWithdrawTimer</c> (240 seconds) — the client never computes this locally, it only
    /// ever stores whatever the server last told it.
    /// </summary>
    private static async Task<IResult> WithdrawCard(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacyCatalog catalog, CancellationToken ct)
    {
        string? targetId = request.Field("IdOfPlayer");
        string? cardId = request.Field("CardId");
        if (string.IsNullOrEmpty(targetId) || string.IsNullOrEmpty(cardId) || cardId == "BuddyCard") return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        if (player.SquadId.Length == 0) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        if (catalog.ConstantInt("CardWithdrawTimer") is not int cooldownSeconds) return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);

        var callerCards = PlayerState.Read<CardManagerData>(player.Serialized.GetValueOrDefault("CardManagerData"));
        int now = Now();
        if (callerCards.NextWithdraw > now) return LegacyResponse.Failure(DatabaseResult.TooSoonToActivate);

        var target = await store.ById(targetId, ct);
        if (target == null || target.SquadId.Length == 0 || target.SquadId != player.SquadId) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        if (!target.DepositedCards.TryGetValue(cardId, out int available) || available <= 0) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        var targetDeposits = new Dictionary<string, int>(target.DepositedCards);
        targetDeposits[cardId] = available - 1;
        if (targetDeposits[cardId] <= 0) targetDeposits.Remove(cardId);
        await store.Update(targetId, Builders<LegacyPlayerDocument>.Update.Set(x => x.DepositedCards, targetDeposits), ct);

        if (!callerCards.CardData.TryGetValue(cardId, out var slot)) callerCards.CardData[cardId] = slot = new SavedCardData();
        slot.Amount++;
        callerCards.NextWithdraw = now + cooldownSeconds;
        await store.SetSerialized(player.Id, "CardManagerData", PlayerState.Write(callerCards), ct);

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["NextWithdraw"] = callerCards.NextWithdraw });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.CraftCard"/> (176). No dedicated failure-branch case exists
    /// for this action in <c>ServerResponseHandler</c>, so a bare <c>Result</c> covers every
    /// refusal; only success needs a real field. <c>OnCraftCards</c> reads <c>mResponse["End"]</c>
    /// as an unguarded top-level index, so it is always emitted.
    /// </summary>
    /// <remarks>
    /// <c>CardCraftingManager.CraftWarcard</c> only ever offers exactly 3 cards of the *same*
    /// rarity — Bronze crafts into a random Silver (`CardCraftTimeSilver`, verified 30 minutes),
    /// Silver crafts into a random Gold (`CardCraftTimeGold`, verified 60 minutes); Gold has no
    /// higher tier and is never offered (`CardCraftingManager.canAnyWarcardBeCrafted` only checks
    /// Bronze/Silver counts). The constant names refer to the *output* tier, not the input — not a
    /// mismatch to "fix". Consumed cards are verified actually owned before being spent; a second
    /// `CraftCard` while one is already in progress reuses <c>AlreadyUpgrading</c>, the same "one
    /// timed slot" refusal already used for weapon/unit upgrade deliveries.
    /// </remarks>
    private static async Task<IResult> CraftCard(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacyCatalog catalog, CancellationToken ct)
    {
        string? cardsJson = request.Field("Cards");
        if (cardsJson == null) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        List<string>? cardIds;
        try { cardIds = JsonSerializer.Deserialize<List<string>>(cardsJson); }
        catch (JsonException) { return LegacyResponse.Failure(DatabaseResult.JsonFailure); }
        if (cardIds == null || cardIds.Count != 3) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        int? rarity = null;
        foreach (string cardId in cardIds)
        {
            var row = catalog.Row("Google2u.CardDefinitions", "NAME", cardId);
            if (row == null) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
            int cardRarity = LegacyBufferProcessor.RowInt(row, "RARITY");
            if (cardRarity is not (1 or 2)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
            if (rarity == null) rarity = cardRarity;
            else if (rarity != cardRarity) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }

        string craftBlobKey = rarity == 1 ? "CardCraftTimeSilver" : "CardCraftTimeGold";
        if (catalog.ConstantInt(craftBlobKey) is not int minutes) return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);

        var craft = PlayerState.Read<CraftData>(player.Serialized.GetValueOrDefault("CraftData"));
        int now = Now();
        if (craft.Cards.Count > 0 && craft.Start < craft.End) return LegacyResponse.Failure(DatabaseResult.AlreadyUpgrading);

        var cards = PlayerState.Read<CardManagerData>(player.Serialized.GetValueOrDefault("CardManagerData"));
        var consumedCounts = cardIds.GroupBy(id => id).ToDictionary(g => g.Key, g => g.Count());
        foreach (var (cardId, count) in consumedCounts)
        {
            if (!cards.CardData.TryGetValue(cardId, out var owned) || owned.Amount < count) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        foreach (var (cardId, count) in consumedCounts) cards.CardData[cardId].Amount -= count;

        craft.Cards = cardIds;
        craft.Start = now;
        craft.End = now + minutes * 60;

        await store.SetSerialized(player.Id, "CardManagerData", PlayerState.Write(cards), ct);
        await store.SetSerialized(player.Id, "CraftData", PlayerState.Write(craft), ct);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["End"] = craft.End });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.ClaimCraftedCard"/> (177). No dedicated failure-branch case
    /// exists for this action either. <c>OnClaimCraftedCard</c> reads <c>mResponse["CardId"]</c> as
    /// an unguarded top-level index, so it is always emitted on success. The awarded card is
    /// server-generated — a uniform random pick from the output rarity's pool, reusing the exact
    /// same <c>CardPoolsByRarity</c>/<c>PickCard</c> machinery <c>BuyCardPack</c> already verified —
    /// never a client assertion, since the request carries no fields at all to assert one with.
    /// </summary>
    private static async Task<IResult> ClaimCraftedCard(LegacyPlayerDocument player, LegacyPlayerStore store, LegacyCatalog catalog, CancellationToken ct)
    {
        var craft = PlayerState.Read<CraftData>(player.Serialized.GetValueOrDefault("CraftData"));
        if (craft.Cards.Count == 0) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        int now = Now();
        if (craft.End > now) return LegacyResponse.Failure(DatabaseResult.TooSoonToActivate);

        var inputRow = catalog.Row("Google2u.CardDefinitions", "NAME", craft.Cards[0]);
        int inputRarity = inputRow == null ? 1 : LegacyBufferProcessor.RowInt(inputRow, "RARITY");
        int outputRarity = inputRarity == 1 ? 2 : 3;

        var pools = LegacyBufferProcessor.CardPoolsByRarity(catalog);
        if (pools[outputRarity - 1].Count == 0) return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        string awardedCardId = LegacyBufferProcessor.PickCard(pools, outputRarity);

        var cards = PlayerState.Read<CardManagerData>(player.Serialized.GetValueOrDefault("CardManagerData"));
        if (!cards.CardData.TryGetValue(awardedCardId, out var slot)) cards.CardData[awardedCardId] = slot = new SavedCardData();
        slot.Amount++;
        craft.Cards = [];
        craft.Start = 0;
        craft.End = 0;

        await store.SetSerialized(player.Id, "CardManagerData", PlayerState.Write(cards), ct);
        await store.SetSerialized(player.Id, "CraftData", PlayerState.Write(craft), ct);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["CardId"] = awardedCardId });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.NotifyPlayerToDeposit"/> (178) — <c>CardpoolRecord.NotifyClick</c>
    /// nudges a squadmate to deposit into the card pool. <c>ServerResponseHandler</c> shares its
    /// success case with <c>UpdateArmyPower</c>, logging only ("Action Success") and reading nothing
    /// back; a real push notification (Fuse/FCM) is out of scope, same as every other retired
    /// third-party SDK. Only real validation possible: the target must actually be a squadmate of
    /// the caller — never trusted blindly, matching <see cref="WithdrawCard"/>'s same target check.
    /// </summary>
    private static async Task<IResult> NotifyPlayerToDeposit(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, CancellationToken ct)
    {
        string? targetId = request.Field("SquadMemberId");
        if (string.IsNullOrEmpty(targetId) || targetId == player.Id) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        if (player.SquadId.Length == 0) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        var target = await store.ById(targetId, ct);
        if (target == null || target.SquadId != player.SquadId) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.LeaveSquad"/>. The request carries no fields at all.
    /// <c>OnLeaveSquad</c> only optionally reads a card-pool <c>DepositedCards</c> list, which stays
    /// with the player rather than the squad (see <see cref="DepositCards"/>) — nothing here needs
    /// to change it on leaving, matching the client's own guarded, optional read.
    /// Leadership does not transfer if a Leader/Coleader leaves a non-empty squad, and a squad left
    /// with zero members is not actively deleted — no evidenced succession or cleanup rule was
    /// found, and guessing one would be new gameplay logic, not a reproduction. A memberless squad
    /// simply sits unreachable (its name stays taken); nothing else in this vertical lists squads by
    /// membership in a way that requires pruning it.
    /// </summary>
    private static async Task<IResult> LeaveSquad(LegacyPlayerDocument player, LegacyPlayerStore store, LegacySquadStore squads, CancellationToken ct)
    {
        if (player.SquadId.Length == 0) return LegacyResponse.Failure(DatabaseResult.SquadLeaveError);

        await squads.RemoveMember(player.SquadId, player.Id, ct);
        await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update
            .Set(x => x.SquadId, "")
            .Set(x => x.SquadRank, (int)LegacySquadRank.None), ct);

        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>Resolves the caller's own squad and confirms Leader/Coleader authority for rank/settings management actions.</summary>
    private static async Task<(LegacySquadDocument? Squad, DatabaseResult? Error)> RequireSquadLeadership(LegacyPlayerDocument player, LegacySquadStore squads, CancellationToken ct)
    {
        if (player.SquadId.Length == 0 || player.SquadRank < (int)LegacySquadRank.Leader) return (null, DatabaseResult.NotLeaderOfSquad);
        var squad = await squads.ById(player.SquadId, ct);
        return squad == null ? (null, DatabaseResult.SquadNoLongerExists) : (squad, null);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.PromotePlayer"/> (55). No case exists for this action in
    /// the failure-branch switch, so a bare <c>Result</c> covers every refusal. Advances the target
    /// one <c>SquadRank</c> step, clamped at <c>Coleader</c> — the client's own asserted
    /// <c>OldSquadRank</c> is never trusted, matching this file's standing rule for mutations.
    /// Already-maxed is an idempotent success (no evidenced code for "can't promote further").
    /// </summary>
    private static async Task<IResult> PromotePlayer(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacySquadStore squads, CancellationToken ct)
    {
        string? targetId = request.Field("PlayerToPromoteId");
        if (string.IsNullOrEmpty(targetId) || targetId == player.Id) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var (squad, error) = await RequireSquadLeadership(player, squads, ct);
        if (error != null) return LegacyResponse.Failure(error.Value);

        var targetMember = squad!.Members.FirstOrDefault(m => m.PlayerId == targetId);
        if (targetMember == null) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        int newRank = Math.Min(targetMember.Rank + 1, (int)LegacySquadRank.Coleader);
        if (newRank != targetMember.Rank)
        {
            await squads.TrySetMemberRank(player.SquadId, targetId, newRank, ct);
            await store.Update(targetId, Builders<LegacyPlayerDocument>.Update.Set(x => x.SquadRank, newRank), ct);
        }

        var target = await store.ById(targetId, ct);
        var response = new JsonObject();
        if (target != null) response["PromotedPlayer"] = PlayerObject(target, includeDeviceToken: false);
        return LegacyResponse.Json(DatabaseResult.Success, response);
    }

    /// <summary>Answers <see cref="DatabaseAction.DemotePlayer"/> (58). Mirror image of <see cref="PromotePlayer"/>: one step down, clamped at <c>Member</c>.</summary>
    private static async Task<IResult> DemotePlayer(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacySquadStore squads, CancellationToken ct)
    {
        string? targetId = request.Field("PlayerToDemoteId");
        if (string.IsNullOrEmpty(targetId) || targetId == player.Id) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var (squad, error) = await RequireSquadLeadership(player, squads, ct);
        if (error != null) return LegacyResponse.Failure(error.Value);

        var targetMember = squad!.Members.FirstOrDefault(m => m.PlayerId == targetId);
        if (targetMember == null) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        int newRank = Math.Max(targetMember.Rank - 1, (int)LegacySquadRank.Member);
        if (newRank != targetMember.Rank)
        {
            await squads.TrySetMemberRank(player.SquadId, targetId, newRank, ct);
            await store.Update(targetId, Builders<LegacyPlayerDocument>.Update.Set(x => x.SquadRank, newRank), ct);
        }

        var target = await store.ById(targetId, ct);
        var response = new JsonObject();
        if (target != null) response["DemotedPlayer"] = PlayerObject(target, includeDeviceToken: false);
        return LegacyResponse.Json(DatabaseResult.Success, response);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.PromotePlayerToFounder"/> (57): transfers sole leadership.
    /// <c>OnPromotePlayerToFounder</c> unconditionally drops the <b>caller's own</b> local rank to
    /// Veteran, so the server does the same authoritatively, regardless of whether the guarded
    /// <c>PromotedPlayer</c> field is emitted.
    /// </summary>
    private static async Task<IResult> PromotePlayerToFounder(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacySquadStore squads, CancellationToken ct)
    {
        string? targetId = request.Field("PlayerToPromoteId");
        if (string.IsNullOrEmpty(targetId) || targetId == player.Id) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var (squad, error) = await RequireSquadLeadership(player, squads, ct);
        if (error != null) return LegacyResponse.Failure(error.Value);
        if (squad!.Members.All(m => m.PlayerId != targetId)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        await squads.TrySetMemberRank(player.SquadId, targetId, (int)LegacySquadRank.Leader, ct);
        await squads.TrySetMemberRank(player.SquadId, player.Id, (int)LegacySquadRank.Veteran, ct);
        await store.Update(targetId, Builders<LegacyPlayerDocument>.Update.Set(x => x.SquadRank, (int)LegacySquadRank.Leader), ct);
        await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update.Set(x => x.SquadRank, (int)LegacySquadRank.Veteran), ct);

        var target = await store.ById(targetId, ct);
        var response = new JsonObject();
        if (target != null) response["PromotedPlayer"] = PlayerObject(target, includeDeviceToken: false);
        return LegacyResponse.Json(DatabaseResult.Success, response);
    }

    /// <summary>Answers <see cref="DatabaseAction.KickPlayer"/> (172). <c>OnKickPlayer</c> reads a guarded <c>Player</c> field, using only its <c>id</c> (it forces the local <c>squadRank</c> to <c>None</c> itself).</summary>
    private static async Task<IResult> KickPlayer(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, LegacySquadStore squads, CancellationToken ct)
    {
        string? targetId = request.Field("PlayerToKickId");
        if (string.IsNullOrEmpty(targetId) || targetId == player.Id) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        var (squad, error) = await RequireSquadLeadership(player, squads, ct);
        if (error != null) return LegacyResponse.Failure(error.Value);
        if (squad!.Members.All(m => m.PlayerId != targetId)) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        await squads.RemoveMember(player.SquadId, targetId, ct);
        await store.Update(targetId, Builders<LegacyPlayerDocument>.Update
            .Set(x => x.SquadId, "")
            .Set(x => x.SquadRank, (int)LegacySquadRank.None), ct);

        var target = await store.ById(targetId, ct);
        var response = new JsonObject();
        if (target != null) response["Player"] = PlayerObject(target, includeDeviceToken: false);
        return LegacyResponse.Json(DatabaseResult.Success, response);
    }

    /// <summary>Answers <see cref="DatabaseAction.UpdateSquad"/> (131). Note the request's field is <c>RequiredMedals</c>, not <c>SkillRequirement</c> like <c>CreateSquad</c> — not a typo to normalize.</summary>
    private static async Task<IResult> UpdateSquad(LegacyRequest request, LegacyPlayerDocument player, LegacySquadStore squads, CancellationToken ct)
    {
        var (squad, error) = await RequireSquadLeadership(player, squads, ct);
        if (error != null) return LegacyResponse.Failure(error.Value);

        bool isPublic = request.Int("IsPublic") != 0;
        int requiredMedals = Math.Clamp(request.Int("RequiredMedals"), 0, 5000);
        string? message = request.Field("Message");
        if (message is { Length: > 100 }) return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);

        var update = Builders<LegacySquadDocument>.Update.Set(x => x.IsPublic, isPublic).Set(x => x.SkillRequirement, requiredMedals);
        await squads.Update(squad!.Id, message != null ? update.Set(x => x.Message, message) : update, ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>Answers <see cref="DatabaseAction.UpdateSquadEmblem"/> (63). <c>OnUpdateSquadEmblem</c> reads nothing back.</summary>
    private static async Task<IResult> UpdateSquadEmblem(LegacyRequest request, LegacyPlayerDocument player, LegacySquadStore squads, CancellationToken ct)
    {
        var (squad, error) = await RequireSquadLeadership(player, squads, ct);
        if (error != null) return LegacyResponse.Failure(error.Value);
        string icon = request.Field("Icon") ?? "";
        await squads.Update(squad!.Id, Builders<LegacySquadDocument>.Update.Set(x => x.Icon, icon), ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GetSquads"/> (56) and <see cref="DatabaseAction.FindSuggestedSquads"/>
    /// (81) — both share <c>ServerResponseHandler.OnGetSquads</c>, which casts <c>mResponse["Items"]</c>
    /// unguarded. <c>GetSquads</c> filters by the client's <c>SquadNameStart</c> prefix;
    /// <c>FindSuggestedSquads</c> sends a <c>Skill</c> value instead, but no skill-matching formula
    /// was traced from the recovered client, so it degrades to "any public squad" — an honest
    /// simplification, not a fabricated heuristic.
    /// </summary>
    private static async Task<IResult> GetSquads(LegacyRequest request, LegacySquadStore squads, CancellationToken ct)
    {
        string prefix = request.Field("SquadNameStart") ?? "";
        var results = await squads.SearchPublic(prefix, 20, ct);
        var items = new JsonArray();
        foreach (var squad in results) items.Add(SquadObject(squad));
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["Items"] = items });
    }

    /// <summary>Mirrors the client's <c>SquadRank</c> enum exactly, including the <c>-1</c> sentinel.</summary>
    private enum LegacySquadRank
    {
        None = -1,
        Member = 0,
        Veteran = 1,
        Leader = 2,
        Coleader = 3
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
    /// Flips one boolean "shown once" flag inside the <c>PlayerAnalyticsData</c> blob — e.g.
    /// <c>chatShown</c>, <c>customizationShown</c> — for the several trivial actions whose entire
    /// client-side effect is <c>PlayerAnalytics.instance.data.&lt;flag&gt; = true</c> with no
    /// response fields read back.
    /// </summary>
    /// <remarks>
    /// <c>PlayerAnalyticsData</c> has ~30 fields (transactions, pack deadlines, rename/session
    /// counters, …) and is not fully modeled in <c>PlayerState.cs</c>. Patching the raw JSON
    /// instead of round-tripping through a partial C# model is deliberate: a model covering only
    /// these flags would silently drop every other field already stored in the blob on the next
    /// write. Model the type fully before anything needs to read those other fields back.
    /// </remarks>
    private static async Task<IResult> SetAnalyticsFlag(LegacyPlayerDocument player, LegacyPlayerStore store, string flagName, CancellationToken ct)
    {
        var blob = player.Serialized.TryGetValue("PlayerAnalyticsData", out string? existingJson) && JsonNode.Parse(existingJson) is JsonObject existing
            ? existing
            : [];
        blob[flagName] = true;
        await store.SetSerialized(player.Id, "PlayerAnalyticsData", blob.ToJsonString(), ct);
        return LegacyResponse.Json(DatabaseResult.Success);
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GameStartedTutorial"/> (119): issues a server-bound battle
    /// identity. <c>OnTutorialStarted</c> reads <c>mResponse["BattleId"]</c> as a direct index on
    /// the top-level response dictionary — like <see cref="GetPlayerInfo"/>, that throws on a
    /// missing key, so it must always be present here (and, unlike <c>GetPlayerInfo</c>, it is
    /// never legitimately null: the server always has a battle id to hand out).
    /// </summary>
    private static async Task<IResult> GameStartedTutorial(LegacyPlayerDocument player, LegacyPlayerStore store, CancellationToken ct)
    {
        string battleId = Guid.NewGuid().ToString("N");
        await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update.Set(x => x.PendingTutorialBattleId, battleId), ct);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["BattleId"] = battleId });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.TutorialEnded"/> (120). This shares the client's
    /// <c>OnGameEnded</c>/<c>OnClassicGameEnded</c> handler with <c>GameEnded</c> (62), so the
    /// response must avoid the <c>IsWarArena</c>-guarded Arena branch entirely (simply never
    /// emitting that key does this) and satisfy <c>OnClassicGameEnded</c>'s one unguarded read.
    /// </summary>
    /// <remarks>
    /// <para><b>Source-verified trap:</b> <c>int num6 = StringParser.ParseInt(mResponse["LevelExperience"]);</c>
    /// is a direct top-level index with no <c>ContainsKey</c> guard, positioned *before* the method's
    /// <c>TutorialData</c> check. Omitting <c>LevelExperience</c> throws, aborting the method before
    /// <c>PlayerAnalytics.instance.tutorialFinished</c> is ever set — so a response missing this one
    /// field would silently fail to mark the tutorial complete on the client, despite the server
    /// having recorded it. <c>TutorialData</c> here is the top-level response's own key (only its
    /// presence matters), distinct from the nested <c>PlayerData.TutorialData</c> that
    /// <c>LoadPlayerData</c>/<c>PlayerDataObject</c> checks.</para>
    /// <para>The client's <c>Experience</c>/<c>Gold</c>/<c>GoldBoxes</c>/<c>WarBucksBoxes</c>/
    /// <c>ObtainedCards</c>/<c>UsedCards</c>/<c>ArmyPower</c> fields are read for logging only and
    /// never applied — every field <c>OnClassicGameEnded</c> would read a reward from
    /// (<c>GameReward</c>, <c>Level</c>, <c>VipReward1</c>, …) is <c>ContainsKey</c>-guarded and
    /// simply omitted, so tutorial completion currently grants nothing. That is deliberate, not an
    /// oversight: there is no verified reward table for it yet.</para>
    /// <para>Completion is idempotent by <c>BattleId</c>: a first call must match the pending id
    /// issued by <see cref="GameStartedTutorial"/>; once completed, replays (a lost response
    /// retried by the client) succeed again without re-applying anything, since nothing was
    /// applied.</para>
    /// </remarks>
    private static async Task<IResult> TutorialEnded(LegacyRequest request, LegacyPlayerDocument player, LegacyPlayerStore store, CancellationToken ct)
    {
        if (!player.TutorialCompleted)
        {
            string? battleId = request.Field("BattleId");
            if (battleId == null || !string.Equals(battleId, player.PendingTutorialBattleId, StringComparison.Ordinal))
                return LegacyResponse.Failure(DatabaseResult.GameDidntExist);
            await store.Update(player.Id, Builders<LegacyPlayerDocument>.Update
                .Set(x => x.TutorialCompleted, true)
                .Set(x => x.PendingTutorialBattleId, (string?)null), ct);
        }

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["LevelExperience"] = player.LevelExperience,
            ["TutorialData"] = true
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
        // DatabasePlayer.CreateFromDatabase reads a regular deposited card as
        // DepositedCards["M"][cardId]["M"]["Amount"]["N"] — a nested map, not the flat
        // {"amount":N} shape CardManagerData.CardData itself uses elsewhere.
        if (p.DepositedCards.Any(kv => kv.Value > 0))
        {
            var deposited = new JsonObject();
            foreach (var (cardId, amount) in p.DepositedCards)
                if (amount > 0) deposited[cardId] = Dynamo.Map(new JsonObject { ["Amount"] = Dynamo.N(amount) });
            item["DepositedCards"] = Dynamo.Map(deposited);
        }

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
