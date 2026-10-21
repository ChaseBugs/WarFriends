using System.Text.Json.Nodes;
using War.Backend.Legacy.Time;
using War.Persistence.Legacy.DogTags;
using War.Persistence;

namespace War.Backend.Legacy.DogTags;

/// <summary>Owns direct dog-tag callback shapes, one request clock and immutable source policy.</summary>
public sealed class LegacyDogTagEndpoint
{
    private readonly LegacyPlayerStore _store;
    private readonly LegacyDogTagPolicy? _policy;
    private readonly ILogger<LegacyDogTagEndpoint> _logger;
    private readonly TimeProvider _clock;

    public LegacyDogTagEndpoint(
        LegacyPlayerStore store,
        LegacyDogTagPolicy? policy,
        ILogger<LegacyDogTagEndpoint> logger,
        TimeProvider? clock = null)
    {
        _store = store;
        _policy = policy;
        _logger = logger;
        _clock = clock ?? TimeProvider.System;
    }

    /// <summary>Commits one supported mutation or projects expiry state using one request clock.</summary>
    public async Task<IResult> ExecuteAsync(
        LegacyRequest request, LegacyPlayerDocument authenticated, CancellationToken cancellationToken)
    {
        try
        {
            DateTimeOffset applicationTime = _clock.GetUtcNow();
            int now = LegacyClientTime.Read(applicationTime.ToUnixTimeSeconds());
            if (request.Action == DatabaseAction.OnVIPExpired)
            {
                LegacyDogTagSnapshot snapshot = LegacyDogTagRules.Project(authenticated, now, _policy);
                return LegacyResponse.Json(DatabaseResult.Success, new JsonObject
                {
                    ["DogTagSeconds"] = snapshot.Seconds,
                    ["DogTagLastUpdate"] = snapshot.LastUpdate
                });
            }

            if (_policy == null)
            {
                return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
            }

            Func<LegacyPlayerDocument, LegacyDogTagMutation> plan = request.Action switch
            {
                DatabaseAction.RefillDogtags => current => LegacyDogTagRules.Refill(current, _policy, now),
                DatabaseAction.PayOneDogTag => current => LegacyDogTagRules.Pay(current, _policy, now),
                _ => throw new InvalidDataException("Unsupported dog-tag action.")
            };
            LegacyDogTagResult? result = await _store.ApplyDogTagAsync(
                authenticated, applicationTime, plan, cancellationToken);
            return Project(request.Action, result);
        }
        catch (InvalidDataException exception)
        {
            _logger.LogError(exception, "Refused invalid dog-tag authority.");
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }
    }

    private static IResult Project(DatabaseAction action, LegacyDogTagResult? result)
    {
        if (result == null)
        {
            return LegacyResponse.Failure(DatabaseResult.InvalidToken);
        }

        if (result.Outcome == LegacyDogTagOutcome.NotEnoughGold)
        {
            return LegacyResponse.Failure(DatabaseResult.NotEnoughGoldForDogtags);
        }

        // These fields are unguarded in the recovered success callbacks.
        JsonObject body = action == DatabaseAction.RefillDogtags
            ? new() { ["Gold"] = result.Player.Gold }
            : new() { ["LastUpdate"] = result.Player.DogTagLastUpdate, ["Seconds"] = result.Player.DogTagSeconds };
        return LegacyResponse.Json(DatabaseResult.Success, body);
    }
}
