using System.Globalization;
using System.Text.Json.Nodes;
using MongoDB.Driver;
using War.Backend.Legacy;
using War.Persistence;

namespace War.Battle.Tests.Legacy.Squads;

/// <summary>Exercises every squad mutation through the running Backend's actual authenticated form endpoint.</summary>
internal static class LegacySquadHttpTests
{
    internal static async Task RunAsync(string uri, string databaseName, string baseUrl)
    {
        using var fixture = new Fixture(new MongoClient(uri).GetDatabase(databaseName), baseUrl);
        try
        {
            await fixture.SeedAsync();
            await CheckCreationAndRolesAsync(fixture);
            await CheckInvitationsAndRequestsAsync(fixture);
            await CheckCrossSquadMoveAsync(fixture);
            await CheckLeaveAsync(fixture);
            Console.WriteLine($"PASS: {fixture.Checks} squad HTTP contract, rank, admission and retry assertions");
        }
        finally
        {
            await fixture.CleanupAsync();
        }
    }

    private static async Task CheckCreationAndRolesAsync(Fixture fixture)
    {
        JsonObject created = await fixture.CreateAsync();
        fixture.Require(IsSuccess(created) && created["SquadId"]!.GetValue<string>() == fixture.SquadName &&
            created["PlayerRank"]!.GetValue<int>() == 2 && created["Squad"]!["Id"]!["S"]!.GetValue<string>() ==
                fixture.SquadName && created["squadCreationsCnt"]!.GetValue<int>() == 1,
            "CreateSquad must publish all unguarded callback fields.");
        JsonObject joined = await fixture.SendAsync(fixture.Second, DatabaseAction.JoinSquad,
            ("NewSquadId", fixture.SquadName));
        fixture.Require(IsSuccess(joined) && joined["SquadId"]!.GetValue<string>() == fixture.SquadName &&
            joined["PlayerRank"]!.GetValue<int>() == 0, "JoinSquad must publish both mandatory fields.");
        JsonObject veteran = await fixture.PromoteAsync("0");
        fixture.Require(IsSuccess(veteran) && Rank(veteran, "PromotedPlayer") == "1",
            "Member must promote to Veteran.");
        await fixture.SetRankAsync(fixture.Second, 0);
        JsonObject damaged = await fixture.PromoteAsync("0");
        fixture.Require(Code(damaged) == 503,
            "A damaged account/roster rank mirror must fail closed through a Client-readable error.");
        fixture.Require((await fixture.ReadSquadAsync()).Members.Single(member =>
            member.PlayerId == fixture.Second.PlayerId).Rank == 1,
            "A damaged rank mirror must not mutate the roster.");
        await fixture.SetRankAsync(fixture.Second, 1);
        JsonObject repeated = await fixture.PromoteAsync("0");
        fixture.Require(Code(repeated) == 5501, "Repeating an old rank assertion must not promote another step.");
        JsonObject coleader = await fixture.PromoteAsync("1");
        fixture.Require(IsSuccess(coleader) && Rank(coleader, "PromotedPlayer") == "3",
            "Veteran must promote to Coleader without becoming Leader.");
        JsonObject demoted = await fixture.SendAsync(fixture.First, DatabaseAction.DemotePlayer,
            ("PlayerToDemoteId", fixture.Second.PlayerId), ("OldSquadRank", "3"));
        fixture.Require(IsSuccess(demoted) && Rank(demoted, "DemotedPlayer") == "1",
            "Coleader must demote to Veteran without becoming Leader.");
        fixture.Require(IsSuccess(await fixture.PromoteAsync("1")), "Coleader setup failed.");
        JsonObject emblem = await fixture.SendAsync(fixture.Second, DatabaseAction.UpdateSquadEmblem,
            ("Icon", "other"));
        fixture.Require(Code(emblem) == 6301, "A Coleader cannot use its larger wire number to edit the emblem.");
        JsonObject transferred = await fixture.SendAsync(fixture.First, DatabaseAction.PromotePlayerToFounder,
            ("PlayerToPromoteId", fixture.Second.PlayerId));
        fixture.Require(IsSuccess(transferred) && Rank(transferred, "PromotedPlayer") == "2",
            "Leadership transfer must publish the new Leader.");
        JsonObject staleKick = await fixture.SendAsync(fixture.First, DatabaseAction.KickPlayer,
            ("PlayerToKickId", fixture.Second.PlayerId));
        fixture.Require(Code(staleKick) == 5802, "The old Leader cannot kick the new Leader.");
        JsonObject kicked = await fixture.SendAsync(fixture.Second, DatabaseAction.KickPlayer,
            ("PlayerToKickId", fixture.First.PlayerId));
        fixture.Require(IsSuccess(kicked) && Rank(kicked, "Player") == "-1", "Kick must project the cleared target.");
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.Second, DatabaseAction.LeaveSquad)),
            "The last member must be able to delete the squad.");
        fixture.Require(await fixture.SquadCountAsync() == 0, "Last-member leave left an orphaned squad.");
    }

    private static async Task CheckInvitationsAndRequestsAsync(Fixture fixture)
    {
        JsonObject recreated = await fixture.CreateAsync();
        fixture.Require(IsSuccess(recreated) && recreated["squadCreationsCnt"]!.GetValue<int>() == 2,
            "A second creation must use the next server-owned price/count.");
        JsonObject duplicate = await fixture.CreateAsync();
        fixture.Require(Code(duplicate) == 13301, "A repeated create cannot charge an already-member actor.");
        LegacyPlayerDocument creator = await fixture.ReadAsync(fixture.First);
        fixture.Require(creator.WarBucks == 0 && creator.SquadCreationsCount == 2,
            "Creation retries changed the wallet/count beyond the two intended creations.");
        JsonObject settings = await fixture.SendAsync(fixture.First, DatabaseAction.UpdateSquad,
            ("IsPublic", "0"), ("RequiredMedals", "1"), ("Message", "private squad"));
        fixture.Require(IsSuccess(settings), "Leader settings update failed.");
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.First, DatabaseAction.UpdateSquadEmblem,
            ("Icon", "icon2"))), "Leader emblem update failed.");
        JsonObject malformed = await fixture.SendAsync(fixture.First, DatabaseAction.UpdateSquad,
            ("IsPublic", "1"), ("RequiredMedals", "-1"));
        fixture.Require(Code(malformed) == 11301, "Invalid settings must reject rather than clamp into authority.");
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.First, DatabaseAction.InvitePlayerToSquad,
            ("PlayerToInviteId", fixture.Third.PlayerId))), "Private invite failed.");
        JsonObject lowSkill = await fixture.SendAsync(fixture.Third, DatabaseAction.JoinSquad,
            ("NewSquadId", fixture.SquadName));
        fixture.Require(Code(lowSkill) == 3803, "An invitation cannot bypass the squad medals requirement.");
        await fixture.SetSkillAsync(fixture.Third);
        JsonObject accepted = await fixture.SendAsync(fixture.Third, DatabaseAction.JoinSquad,
            ("NewSquadId", fixture.SquadName));
        fixture.Require(IsSuccess(accepted), "A valid invited player must join.");
        LegacySquadDocument squad = await fixture.ReadSquadAsync();
        fixture.Require(!squad.IsPublic && squad.Message == "private squad" && squad.Icon == "icon2" &&
            !squad.PendingInvites.Contains(fixture.Third.PlayerId), "Settings/invitation consumption diverged.");
        await CheckPendingRequestAsync(fixture);
    }

    private static async Task CheckPendingRequestAsync(Fixture fixture)
    {
        await fixture.SetSkillAsync(fixture.Fourth);
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.Fourth, DatabaseAction.JoinSquadRequest,
            ("SquadId", fixture.SquadName))), "A valid private join request failed.");
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.First, DatabaseAction.DeclineSquadJoinRequest,
            ("Id", fixture.Fourth.PlayerId))), "Decline request failed.");
        fixture.Require(!(await fixture.ReadSquadAsync()).PendingRequests.Contains(fixture.Fourth.PlayerId),
            "Decline left a stale pending request.");
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.Fourth, DatabaseAction.JoinSquadRequest,
            ("SquadId", fixture.SquadName))), "A new request after decline failed.");
        JsonObject approved = await fixture.SendAsync(fixture.First, DatabaseAction.AcceptSquadJoinRequest,
            ("SquadId", fixture.SquadName), ("PlayerToJoin", fixture.Fourth.PlayerId));
        fixture.Require(IsSuccess(approved) && Rank(approved, "joinedPlayer") == "0",
            "Approval must publish the admitted Player projection.");
        fixture.Require(!(await fixture.ReadSquadAsync()).PendingRequests.Contains(fixture.Fourth.PlayerId),
            "Approval did not consume its request atomically.");
    }

    private static async Task CheckLeaveAsync(Fixture fixture)
    {
        JsonObject blocked = await fixture.SendAsync(fixture.First, DatabaseAction.LeaveSquad);
        fixture.Require(Code(blocked) == 4601, "A Leader cannot abandon a non-empty squad.");
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.First, DatabaseAction.PromotePlayerToFounder,
            ("PlayerToPromoteId", fixture.Third.PlayerId))), "Final leadership transfer failed.");
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.First, DatabaseAction.LeaveSquad)),
            "The former Leader must leave after transfer.");
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.Third, DatabaseAction.KickPlayer,
            ("PlayerToKickId", fixture.Fourth.PlayerId))), "Final member removal failed.");
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.Third, DatabaseAction.LeaveSquad)),
            "The final Leader could not delete the squad.");
        fixture.Require(await fixture.SquadCountAsync() == 0, "The final leave did not delete its empty squad.");
    }

    private static async Task CheckCrossSquadMoveAsync(Fixture fixture)
    {
        JsonObject secondSquad = await fixture.SendAsync(fixture.Second, DatabaseAction.CreateSquad,
            ("SquadId", fixture.OtherSquadName), ("IsPublic", "1"), ("SkillRequirement", "0"), ("Icon", "icon1"));
        fixture.Require(IsSuccess(secondSquad), "Cross-squad fixture creation failed.");
        JsonObject blockedLeader = await fixture.SendAsync(fixture.Second, DatabaseAction.JoinSquad,
            ("NewSquadId", fixture.SquadName));
        fixture.Require(Code(blockedLeader) == 13201, "A Leader cannot implicitly abandon its squad to join another.");
        JsonObject moved = await fixture.SendAsync(fixture.Third, DatabaseAction.JoinSquad,
            ("NewSquadId", fixture.OtherSquadName));
        fixture.Require(IsSuccess(moved) && moved["SquadId"]!.GetValue<string>() == fixture.OtherSquadName,
            "SquadRecord's direct non-Leader JoinSquad must perform an atomic move.");
        fixture.Require(!(await fixture.ReadSquadAsync()).Members.Any(member =>
            member.PlayerId == fixture.Third.PlayerId),
            "The old roster retained a player after a direct move.");
        JsonObject requested = await fixture.SendAsync(fixture.Third, DatabaseAction.JoinSquadRequest,
            ("SquadId", fixture.SquadName));
        fixture.Require(IsSuccess(requested), "A non-Leader must be able to request another private squad.");
        JsonObject approved = await fixture.SendAsync(fixture.First, DatabaseAction.AcceptSquadJoinRequest,
            ("SquadId", fixture.SquadName), ("PlayerToJoin", fixture.Third.PlayerId));
        fixture.Require(IsSuccess(approved) && Rank(approved, "joinedPlayer") == "0",
            "Approval must move a non-Leader from its previous roster atomically.");
        LegacyPlayerDocument returned = await fixture.ReadAsync(fixture.Third);
        fixture.Require(returned.SquadId == fixture.SquadName, "The approved member pointer did not move back.");
        fixture.Require(IsSuccess(await fixture.SendAsync(fixture.Second, DatabaseAction.LeaveSquad)),
            "The other squad must contain only its Leader after the transfer.");
    }

    private static int Code(JsonObject response) => response["Result"]!.GetValue<int>();

    private static bool IsSuccess(JsonObject response) => Code(response) == (int)DatabaseResult.Success;

    private static string Rank(JsonObject response, string field) =>
        response[field]!["SquadRank"]!["N"]!.GetValue<string>();

    private sealed record Credential(string PlayerId, string Token)
    {
        internal static Credential Create() => new(Guid.NewGuid().ToString("N"), LegacyPlayerStore.NewToken());
    }

    private sealed class Fixture(IMongoDatabase database, string baseUrl) : IDisposable
    {
        private readonly HttpClient _http = new()
        {
            BaseAddress = new Uri(baseUrl),
            Timeout = TimeSpan.FromSeconds(10)
        };
        private readonly CancellationTokenSource _deadline = new(TimeSpan.FromSeconds(120));

        internal Credential First { get; } = Credential.Create();

        internal Credential Second { get; } = Credential.Create();

        internal Credential Third { get; } = Credential.Create();

        internal Credential Fourth { get; } = Credential.Create();

        internal string SquadName { get; } = SquadTestFixture.Name();

        internal string OtherSquadName { get; } = SquadTestFixture.Name();

        internal int Checks { get; private set; }

        internal async Task SeedAsync()
        {
            foreach (Credential credential in Credentials())
            {
                LegacyPlayerDocument player = SquadTestFixture.Player();
                player.Id = credential.PlayerId;
                player.Name = "SquadWire";
                player.CreatedUtc = DateTime.UtcNow;
                player.SessionHash = LegacyPlayerStore.HashToken(credential.Token);
                player.SessionExpiresUtc = DateTime.UtcNow.AddHours(1);
                await database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
                    .InsertOneAsync(player, cancellationToken: _deadline.Token);
            }
        }

        internal async Task<JsonObject> SendAsync(
            Credential actor, DatabaseAction action, params (string Key, string Value)[] fields)
        {
            var form = new Dictionary<string, string>
            {
                ["requestId"] = ((int)action).ToString(CultureInfo.InvariantCulture),
                ["PlayerId"] = actor.PlayerId,
                ["Token"] = actor.Token,
                ["Version"] = "1.4.0",
                ["Os"] = "android"
            };
            foreach ((string key, string value) in fields)
            {
                form.Add(key, value);
            }

            using var content = new FormUrlEncodedContent(form);
            using HttpResponseMessage response = await _http.PostAsync(LegacyEndpoints.ActionPath,
                content, _deadline.Token);
            response.EnsureSuccessStatusCode();
            string body = await response.Content.ReadAsStringAsync(_deadline.Token);
            return JsonNode.Parse(body) as JsonObject ?? throw new InvalidDataException("Invalid squad HTTP response.");
        }

        internal Task<JsonObject> CreateAsync() => SendAsync(First, DatabaseAction.CreateSquad,
            ("SquadId", SquadName), ("IsPublic", "1"), ("SkillRequirement", "0"), ("Icon", "icon1"));

        internal Task<JsonObject> PromoteAsync(string oldRank) => SendAsync(First, DatabaseAction.PromotePlayer,
            ("PlayerToPromoteId", Second.PlayerId), ("OldSquadRank", oldRank));

        internal Task<LegacyPlayerDocument> ReadAsync(Credential actor) =>
            database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
                .Find(row => row.Id == actor.PlayerId).SingleAsync(_deadline.Token);

        internal Task<LegacySquadDocument> ReadSquadAsync() =>
            database.GetCollection<LegacySquadDocument>("legacySquads")
                .Find(row => row.Id == SquadName).SingleAsync(_deadline.Token);

        internal Task<long> SquadCountAsync() => database.GetCollection<LegacySquadDocument>("legacySquads")
            .CountDocumentsAsync(row => row.Id == SquadName, cancellationToken: _deadline.Token);

        internal Task SetSkillAsync(Credential actor) => database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
            .UpdateOneAsync(row => row.Id == actor.PlayerId,
                Builders<LegacyPlayerDocument>.Update.Set(row => row.Skill, 1).Inc(row => row.Revision, 1),
                cancellationToken: _deadline.Token);

        internal Task SetRankAsync(Credential actor, int rank) =>
            database.GetCollection<LegacyPlayerDocument>("legacyPlayers").UpdateOneAsync(
                row => row.Id == actor.PlayerId,
                Builders<LegacyPlayerDocument>.Update.Set(row => row.SquadRank, rank).Inc(row => row.Revision, 1),
                cancellationToken: _deadline.Token);

        internal async Task CleanupAsync()
        {
            string[] identities = Credentials().Select(credential => credential.PlayerId).ToArray();
            await database.GetCollection<LegacyPlayerDocument>("legacyPlayers").DeleteManyAsync(
                Builders<LegacyPlayerDocument>.Filter.In(row => row.Id, identities), CancellationToken.None);
            await database.GetCollection<LegacySquadDocument>("legacySquads").DeleteManyAsync(
                row => row.Id == SquadName || row.Id == OtherSquadName, CancellationToken.None);
        }

        internal void Require(bool condition, string message)
        {
            SquadTestFixture.Require(condition, message);
            Checks++;
        }

        public void Dispose()
        {
            _http.Dispose();
            _deadline.Dispose();
        }

        private Credential[] Credentials() => [First, Second, Third, Fourth];
    }
}
