using System.Text.Json.Nodes;
using War.Persistence;
using War.Persistence.Legacy.Tutorial;

namespace War.Backend.Legacy.Tutorial;

/// <summary>Preserves the original tutorial callbacks while ignoring client economy/combat assertions.</summary>
internal static class LegacyTutorialEndpoint
{
    internal static async Task<IResult> ExecuteAsync(
        LegacyRequest request,
        LegacyPlayerDocument authenticated,
        LegacyPlayerStore store,
        CancellationToken cancellationToken)
    {
        if (request.Action is not (DatabaseAction.GameStartedTutorial or DatabaseAction.TutorialEnded))
        {
            throw new InvalidDataException("Unsupported tutorial action.");
        }

        bool isStart = request.Action == DatabaseAction.GameStartedTutorial;
        string? id = request.SingleField("BattleId");
        if (!isStart && !LegacyTutorialAuthority.IsBattleId(id))
        {
            return LegacyResponse.Failure(DatabaseResult.GameDidntExist);
        }

        LegacyTutorialOperation operation = isStart ? LegacyTutorialOperation.Start() : LegacyTutorialOperation.End(id);
        LegacyTutorialResult result = await store.ApplyTutorialAsync(
            authenticated, operation, DateTimeOffset.UtcNow, cancellationToken);
        DatabaseResult code = result.Outcome switch
        {
            LegacyTutorialOutcome.Published or LegacyTutorialOutcome.Replayed => DatabaseResult.Success,
            LegacyTutorialOutcome.InvalidSession => DatabaseResult.InvalidToken,
            LegacyTutorialOutcome.WrongBattle => DatabaseResult.GameDidntExist,
            _ => DatabaseResult.ServerMaintenance
        };
        if (code != DatabaseResult.Success)
        {
            return LegacyResponse.Failure(code);
        }

        // Start indexes BattleId; the common end callback indexes XP before checking TutorialData.
        // XP is the current server view, so a delayed acknowledgement cannot roll back later progress.
        JsonObject body = isStart
            ? new() { ["BattleId"] = result.BattleId }
            : new() { ["LevelExperience"] = result.Player!.LevelExperience, ["TutorialData"] = true };
        return LegacyResponse.Json(code, body);
    }
}
