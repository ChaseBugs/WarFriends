using War.Backend.Legacy.Battle;
using War.Persistence;
using War.Backend.Features.Battle.Settlement;
using Action = War.Backend.Legacy.DatabaseAction;
using Entry = War.Backend.Legacy.Dispatch.LegacyActionRegistration;
using Feature = War.Backend.Legacy.Dispatch.LegacyActionFeature;

namespace War.Backend.Legacy.Dispatch.Composition;

internal static class LegacyBattleActions
{
    public static IReadOnlyList<Entry> Create(IServiceProvider services)
    {
        LegacyBattleStartService battles = services.GetRequiredService<LegacyBattleStartService>();
        LegacyCatalog catalog = services.GetRequiredService<LegacyCatalog>();
        BattleSettlementService settlement = services.GetRequiredService<BattleSettlementService>();
        return
        [
            Entry.Authenticated(Action.GameEnded, Feature.Battle,
                (request, player, token) => settlement.ExecuteAsync(request, player, token)),
            Entry.Authenticated(Action.GameStartedMaster, Feature.Battle,
                (request, player, token) => battles.AcknowledgeAsync(request, player, catalog, token)),
            Entry.Authenticated(Action.GameStartedClient, Feature.Battle,
                (request, player, token) => battles.AcknowledgeAsync(request, player, catalog, token)),
            Entry.Authenticated(Action.UpdateRegionPings, Feature.Battle,
                (_, _, _) => Task.FromResult(LegacyOfflinePhotonEndpoint.Acknowledge())),
            Entry.Authenticated(Action.PhotonIsFull, Feature.Battle,
                (_, _, _) => Task.FromResult(LegacyOfflinePhotonEndpoint.Acknowledge())),
        ];
    }
}
