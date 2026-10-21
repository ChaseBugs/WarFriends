using War.Backend.Legacy.Accounts;
using War.Backend.Legacy.DogTags;
using War.Backend.Legacy.Player;
using War.Persistence;
using Action = War.Backend.Legacy.DatabaseAction;
using Entry = War.Backend.Legacy.Dispatch.LegacyActionRegistration;
using Feature = War.Backend.Legacy.Dispatch.LegacyActionFeature;

namespace War.Backend.Legacy.Dispatch.Composition;

internal static class LegacyAccountActions
{
    public static IReadOnlyList<Entry> Create(IServiceProvider services)
    {
        LegacyPlayerStore players = services.GetRequiredService<LegacyPlayerStore>();
        LegacyStarterPolicy starter = services.GetRequiredService<LegacyStarterPolicy>();
        LegacyCatalog catalog = services.GetRequiredService<LegacyCatalog>();
        LegacyDogTagPolicy? dogTags = LegacyDogTagPolicy.FromCatalog(catalog, starter);
        var projection = new LegacyAccountProjection(player => LegacyPlayerProjection.Player(player),
            player => LegacyPlayerProjection.PlayerData(player, player.LastAction, dogTags));
        var accounts = new LegacyAccountEndpoint(new LegacyAccountService(players, starter), projection,
            services.GetRequiredService<ILogger<LegacyAccountEndpoint>>());
        return
        [
            Entry.Anonymous(Action.GetConfigurations, Feature.Configuration,
                (_, _) => Task.FromResult(LegacyResponse.Configurations(starter.SheetConfiguration))),
            Entry.Anonymous(Action.CreateAccount, Feature.Accounts,
                accounts.CreateAsync),
            Entry.Anonymous(Action.CreateGcAccount, Feature.Accounts,
                accounts.CreateAsync),
            Entry.Anonymous(Action.LoginToCustomAccount, Feature.Accounts,
                accounts.LoginAsync),
        ];
    }
}
