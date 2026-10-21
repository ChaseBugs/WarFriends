using System.Text.Json.Nodes;
using War.Persistence;

namespace War.Backend.Legacy.Player;

public sealed class LegacyPlayerQueryEndpoint
{
    private readonly LegacyPlayerStore _players;

    public LegacyPlayerQueryEndpoint(LegacyPlayerStore players)
    {
        _players = players;
    }

/// <summary>
    /// Answers <see cref="DatabaseAction.GetPlayerInfo"/> (170): a public lookup of another
    /// player's <c>Player</c>-shaped data. <c>OnGetPlayerInfo</c> reads <c>mResponse["PlayerInfo"]</c>
    /// as a <b>direct index on the top-level response dictionary</b>, not a <c>ContainsKey</c> or
    /// nested-<c>JToken</c> check — a real .NET dictionary throws on a missing key even when the
    /// caller immediately compares the result to null, so the key must always be present, using an
    /// explicit JSON <c>null</c> when the target player does not exist. <c>SquadWarsId</c> by
    /// contrast is <c>ContainsKey</c>-guarded and is omitted (no Squad War authority here).
    /// </summary>
    public async Task<IResult> ReadAsync(LegacyRequest request, CancellationToken cancellationToken)
    {
        string? targetId = request.Field("PlayerInfoId");
        var target = targetId == null ? null : await _players.ById(targetId, cancellationToken);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["PlayerInfo"] = target == null ? null : LegacyPlayerProjection.Player(target, includeDeviceToken: false)
        });
    }
}
