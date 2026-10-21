using War.Backend.Legacy.Cards;
using War.Persistence;
using Action = War.Backend.Legacy.DatabaseAction;
using Entry = War.Backend.Legacy.Dispatch.LegacyActionRegistration;
using Feature = War.Backend.Legacy.Dispatch.LegacyActionFeature;

namespace War.Backend.Legacy.Dispatch.Composition;

internal static class LegacyCardActions
{
    public static IReadOnlyList<Entry> Create(IServiceProvider services)
    {
        LegacyPlayerStore players = services.GetRequiredService<LegacyPlayerStore>();
        LegacyCatalog catalog = services.GetRequiredService<LegacyCatalog>();
        var pool = new LegacyCardPoolEndpoint(players, LegacyCardPoolPolicy.FromCatalog(catalog));
        var crafting = new LegacyCraftingEndpoint(players, catalog);
        var notifications = new LegacyCardNotificationEndpoint(players);
        return
        [
            Entry.Authenticated(Action.DepositCards, Feature.Cards,
                pool.ApplyAsync),
            Entry.Authenticated(Action.WithdrawCard, Feature.Cards,
                pool.ApplyAsync),
            Entry.Authenticated(Action.CraftCard, Feature.Cards,
                crafting.CraftAsync),
            Entry.Authenticated(Action.ClaimCraftedCard, Feature.Cards,
                (_, player, token) => crafting.ClaimAsync(player, token)),
            Entry.Authenticated(Action.NotifyPlayerToDeposit, Feature.Cards,
                notifications.NotifyAsync),
        ];
    }
}
