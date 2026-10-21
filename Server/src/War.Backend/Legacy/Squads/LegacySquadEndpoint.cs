using System.Text.Json.Nodes;
using War.Persistence;
using War.Persistence.Legacy.Squads;

namespace War.Backend.Legacy.Squads;

/// <summary>Publishes squad transitions and projects only fields the recovered callbacks consume.</summary>
public sealed class LegacySquadEndpoint(
    LegacyPlayerStore store,
    LegacySquadPolicy policy,
    LegacySquadProjection projection,
    ILogger<LegacySquadEndpoint> logger)
{
    private readonly LegacySquadRules _rules = new(policy);

    public async Task<IResult> ApplyAsync(
        LegacyRequest request, LegacyPlayerDocument player, CancellationToken cancellationToken)
    {
        LegacySquadCommand command;
        try
        {
            command = LegacySquadParser.Parse(request, checked((int)DateTimeOffset.UtcNow.ToUnixTimeSeconds()));
        }
        catch (InvalidDataException)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }

        var operation = new LegacySquadOperation(player.Id, command.TargetId, command.SquadId);
        LegacySquadResult result;
        try
        {
            result = await store.ApplySquadAsync(operation,
                snapshot => _rules.Calculate(snapshot, command), cancellationToken);
        }
        catch (InvalidDataException exception)
        {
            logger.LogError(exception, "Refused invalid squad authority for actor {ActorId}, action {Action}",
                player.Id, command.Action);
            return LegacyResponse.Failure(DatabaseResult.ServerMaintenance);
        }
        return LegacyResponse.Json((DatabaseResult)result.Result,
            result.Result == (int)DatabaseResult.Success ? Project(command.Action, result) : null);
    }

    private JsonObject Project(DatabaseAction action, LegacySquadResult result)
    {
        if (action == DatabaseAction.CreateSquad)
        {
            return new JsonObject
            {
                ["SquadId"] = result.Actor.SquadId,
                ["PlayerRank"] = result.Actor.SquadRank,
                ["Squad"] = projection.Squad(result.Squad!),
                ["squadCreationsCnt"] = result.Actor.SquadCreationsCount
            };
        }

        if (action == DatabaseAction.JoinSquad)
        {
            return new JsonObject { ["SquadId"] = result.Actor.SquadId, ["PlayerRank"] = result.Actor.SquadRank };
        }

        string? targetField = action switch
        {
            DatabaseAction.AcceptSquadJoinRequest => "joinedPlayer",
            DatabaseAction.PromotePlayer or DatabaseAction.PromotePlayerToFounder => "PromotedPlayer",
            DatabaseAction.DemotePlayer => "DemotedPlayer",
            DatabaseAction.KickPlayer => "Player",
            _ => null
        };
        return targetField == null ? new JsonObject() :
            new JsonObject { [targetField] = projection.Player(result.Target!) };
    }
}
