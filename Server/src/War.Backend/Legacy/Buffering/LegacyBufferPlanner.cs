using System.Text.Json;
using System.Text.Json.Nodes;
using War.Persistence;
using War.Persistence.Legacy.Analytics;
using War.Persistence.Legacy.Buffers;
using War.Persistence.Legacy.State;
using War.Persistence.Legacy.Tutorial;
using static War.Backend.Legacy.Buffering.LegacyBufferedResults;

namespace War.Backend.Legacy.Buffering;

/// <summary>Validates and executes one deterministic buffered request without persistence or wire replay.</summary>
public sealed class LegacyBufferPlanner
{
    private readonly LegacyBufferedActionRegistry _actions;
    private readonly ILogger _logger;

    public LegacyBufferPlanner(LegacyCatalog catalog, IReadOnlySet<DatabaseAction> supportedActions, ILogger logger)
    {
        _actions = LegacyBufferedActionRegistry.Create(catalog, supportedActions);
        _logger = logger;
    }

    /// <summary>Uses one captured time and random seed across all transaction attempts.</summary>
    public LegacyBufferedMutation Plan(
        LegacyPlayerDocument player, BufferedRequest request, long now, int randomSeed)
    {
        if (now < 0 || now > int.MaxValue)
        {
            throw new InvalidDataException("Application time exceeds the recovered Client clock.");
        }

        LegacyPlayerIdentityAuthority.Validate(player);
        LegacyPlayerEconomyAuthority.Validate(player);
        LegacyAnalyticsState.ValidateContainer(player.Serialized);
        LegacyTutorialAuthority.ValidateForRead(player);
        var state = new LegacyBufferedState(player, now, new Random(randomSeed));
        var outcome = Execute(request, state);
        return state.BuildMutation(request.Action, outcome.Code, outcome.Node);
    }

    private (DatabaseResult Code, JsonObject Node) Execute(BufferedRequest request, LegacyBufferedState state)
    {
        if (!_actions.TryGet(request.Action, out LegacyBufferedActionRegistration? registration))
        {
            _logger.LogInformation("Buffered action {Action} is closed; returning maintenance.", request.Action);
            return (DatabaseResult.ServerMaintenance, Result(request.Action, DatabaseResult.ServerMaintenance));
        }
        try
        {
            return registration.Handler(request, state);
        }
        catch (JsonException error)
        {
            _logger.LogWarning("Buffered action {Action} carried unparsable data: {Error}",
                request.Action, error.GetType().Name);
            return (DatabaseResult.JsonFailure, Result(request.Action, DatabaseResult.JsonFailure));
        }
    }
}
