using System.Text.Json.Nodes;
using War.Backend.Legacy.Player;
using War.Persistence;

namespace War.Backend.Legacy.Squads;

public sealed class LegacySquadQueryEndpoint
{
    private readonly LegacyPlayerStore _players;
    private readonly LegacySquadStore _squads;

    public LegacySquadQueryEndpoint(LegacyPlayerStore players, LegacySquadStore squads)
    {
        _players = players;
        _squads = squads;
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.CheckUniqueSquadName"/>. <c>OnCheckUniqueSquadName</c> reads
    /// <c>mResponse["IsUnique"]</c> as an unguarded top-level index, so it is always emitted.
    /// Mongo's own <c>_id</c> uniqueness on <see cref="LegacySquadDocument.Id"/> (the squad's display
    /// name doubles as its id — <c>CreateSquad</c> sends no separate identifier) is exactly the
    /// uniqueness this answers; no separate reservation/lock is needed.
    /// </summary>
    public async Task<IResult> CheckUniqueNameAsync(LegacyRequest request, CancellationToken cancellationToken)
    {
        string? name = request.Field("SquadId");
        if (string.IsNullOrEmpty(name))
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        var existing = await _squads.ById(name, cancellationToken);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["IsUnique"] = existing == null });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GetSquadDetails"/>. <c>OnGetSquadDetails</c> casts
    /// <c>mResponse["Squad"]</c> directly, an unguarded top-level index, so it is always emitted on
    /// success. No case exists for this action in the failure-branch switch, so a bare <c>Result</c>
    /// covers "no such squad".
    /// </summary>
    public async Task<IResult> ReadDetailsAsync(LegacyRequest request, CancellationToken cancellationToken)
    {
        string? squadId = request.Field("SquadId");
        if (string.IsNullOrEmpty(squadId))
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        var squad = await _squads.ById(squadId, cancellationToken);
        if (squad == null)
        {
            return LegacyResponse.Failure(DatabaseResult.NoSquadFound);
        }
        return LegacyResponse.Json(DatabaseResult.Success,
            new JsonObject { ["Squad"] = LegacySquadDataProjection.Squad(squad) });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GetAllSquadMembers"/>. <c>OnGetAllSquadMembers</c> casts
    /// <c>mResponse["SquadMembers"]</c> to a <c>JArray</c> unguarded, and reads <c>SquadId</c>
    /// unguarded too. Each member is the same <c>Player</c>-shaped projection as
    /// <see cref="LegacyPlayerQueryEndpoint.ReadAsync"/>'s <c>PlayerInfo</c>, since both feed the same
    /// <c>DatabasePlayer.CreateFromDatabase</c> reader.
    /// </summary>
    public async Task<IResult> ReadMembersAsync(LegacyRequest request, CancellationToken cancellationToken)
    {
        string? squadId = request.Field("SquadId");
        if (string.IsNullOrEmpty(squadId))
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        var squad = await _squads.ById(squadId, cancellationToken);
        if (squad == null)
        {
            return LegacyResponse.Failure(DatabaseResult.NoSquadFound);
        }

        var members = await _players.ByIds(squad.Members.Select(m => m.PlayerId), cancellationToken);
        var array = new JsonArray();
        foreach (var member in members)
        {
            array.Add(LegacyPlayerProjection.Player(member, includeDeviceToken: false));
        }

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["SquadId"] = squadId,
            ["SquadMembers"] = array
        });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GetFullSquadInfo"/> (151). <c>OnGetFullSquadInfo</c> is
    /// literally <c>OnReadDetailsAsync()</c> followed by <c>OnReadMembersAsync()</c> against the
    /// *same* response body, so this combines both projections into one answer rather than
    /// reproducing either reader from scratch.
    /// </summary>
    public async Task<IResult> ReadFullInfoAsync(LegacyRequest request, CancellationToken cancellationToken)
    {
        string? squadId = request.Field("SquadId");
        if (string.IsNullOrEmpty(squadId))
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        var squad = await _squads.ById(squadId, cancellationToken);
        if (squad == null)
        {
            return LegacyResponse.Failure(DatabaseResult.NoSquadFound);
        }

        var members = await _players.ByIds(squad.Members.Select(m => m.PlayerId), cancellationToken);
        var array = new JsonArray();
        foreach (var member in members)
        {
            array.Add(LegacyPlayerProjection.Player(member, includeDeviceToken: false));
        }

        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["Squad"] = LegacySquadDataProjection.Squad(squad),
            ["SquadId"] = squadId,
            ["SquadMembers"] = array
        });
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.GetSquads"/> (56) and <see cref="DatabaseAction.FindSuggestedSquads"/>
    /// (81) — both share <c>ServerResponseHandler.OnGetSquads</c>, which casts <c>mResponse["Items"]</c>
    /// unguarded. <c>GetSquads</c> filters by the client's <c>SquadNameStart</c> prefix;
    /// <c>FindSuggestedSquads</c> sends a <c>Skill</c> value instead, but no skill-matching formula
    /// was traced from the recovered client, so it degrades to "any public squad" — an honest
    /// simplification, not a fabricated heuristic.
    /// </summary>
    public async Task<IResult> SearchAsync(LegacyRequest request, CancellationToken cancellationToken)
    {
        string prefix = request.Field("SquadNameStart") ?? "";
        var results = await _squads.SearchPublic(prefix, 20, cancellationToken);
        var items = new JsonArray();
        foreach (var squad in results)
        {
            items.Add(LegacySquadDataProjection.Squad(squad));
        }
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject { ["Items"] = items });
    }
}
