using System.Text.Json.Nodes;
using System.Text.Json;
using War.Persistence;

namespace War.Backend.Legacy.Buffering;

public sealed class LegacyBufferedEndpoint
{
    private readonly LegacyBufferProcessor _buffers;

    public LegacyBufferedEndpoint(LegacyBufferProcessor buffers)
    {
        _buffers = buffers;
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.SendRequestBuffer"/>: applies the buffer's requests in
    /// order and returns their results. <c>OnSendRequestBuffer</c> reads both
    /// <c>RequestsResults</c> and <c>BufferId</c> with the single-argument <c>ParseString</c>
    /// overload (a plain <c>ToString()</c>), so — unlike <c>Player</c>/<c>PlayerData</c> — neither
    /// is a DynamoDB AttributeValue; <c>RequestsResults</c> is a JSON array serialized to a string.
    /// </summary>
    public async Task<IResult> ApplyAsync(
        LegacyRequest request, LegacyPlayerDocument player, CancellationToken cancellationToken)
    {
        string? bufferId = request.Field("BufferId");
        if (!LegacyBufferParser.IsValidBufferId(bufferId))
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        IReadOnlyList<BufferedRequest> requests;
        try
        {
            requests = LegacyBufferParser.ParseRequests(request.Field("Requests"));
        }
        catch (JsonException)
        {
            return LegacyResponse.Failure(DatabaseResult.JsonFailure);
        }

        string? count = request.Field("Count");
        if (count != null && count != requests.Count.ToString(System.Globalization.CultureInfo.InvariantCulture))
            return LegacyResponse.Failure(DatabaseResult.JsonFailure);
        var buffer = new ParsedBuffer(bufferId, requests);
        AppliedLegacyBuffer applied = await _buffers.ApplyAsync(player, buffer, cancellationToken);
        return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
        {
            ["RequestsResults"] = applied.Results.ToJsonString(),
            ["BufferId"] = bufferId
        });
    }
}
