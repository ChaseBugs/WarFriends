using War.Backend.Legacy.Accounts;
using War.Backend.Legacy.DogTags;
using War.Backend.Legacy.Player;
using War.Backend.Legacy.Preferences;
using War.Backend.Legacy.Profile;
using War.Backend.Legacy.Progression;
using War.Backend.Legacy.Tutorial;
using War.Persistence.Legacy.Profile;
using War.Persistence;
using Action = War.Backend.Legacy.DatabaseAction;
using Entry = War.Backend.Legacy.Dispatch.LegacyActionRegistration;
using Feature = War.Backend.Legacy.Dispatch.LegacyActionFeature;

namespace War.Backend.Legacy.Dispatch.Composition;

internal static class LegacyPlayerActions
{
    public static IReadOnlyList<Entry> Create(IServiceProvider services)
    {
        var registrations = new List<Entry>();
        registrations.AddRange(ReadActions(services));
        registrations.AddRange(ProfileActions(services));
        registrations.AddRange(ProgressionActions(services));
        return registrations;
    }

    private static IReadOnlyList<Entry> ReadActions(IServiceProvider services)
    {
        LegacyPlayerStore players = services.GetRequiredService<LegacyPlayerStore>();
        LegacyDogTagPolicy? policy = LegacyDogTagPolicy.FromCatalog(services.GetRequiredService<LegacyCatalog>(),
            services.GetRequiredService<LegacyStarterPolicy>());
        var data = new LegacyPlayerDataEndpoint(services.GetRequiredService<LegacyBufferProcessor>(),
            (player, now) => LegacyPlayerProjection.PlayerData(player, now, policy),
            services.GetRequiredService<ILogger<LegacyPlayerDataEndpoint>>());
        var query = new LegacyPlayerQueryEndpoint(players);
        return
        [
            Entry.Authenticated(Action.GetPlayerData, Feature.Player,
                data.ReadAsync),
            Entry.Authenticated(Action.GetPlayerInfo, Feature.Player,
                (request, _, token) => query.ReadAsync(request, token)),
            Entry.Authenticated(Action.GetAllMessages, Feature.Player,
                (_, _, _) => Task.FromResult(LegacyInboxEndpoint.Read())),
            Entry.Authenticated(Action.UpdateArmyPower, Feature.Player,
                (request, player, token) => LegacyArmyPowerEndpoint.HandleAsync(request, player, players, token)),
        ];
    }

    private static IReadOnlyList<Entry> ProfileActions(IServiceProvider services)
    {
        LegacyPlayerStore players = services.GetRequiredService<LegacyPlayerStore>();
        LegacyCatalog catalog = services.GetRequiredService<LegacyCatalog>();
        var profile = new LegacyProfileEndpoint(players,
            new LegacyRenamePolicy(catalog.ConstantInt("SecondRenameGoldCost")),
            services.GetRequiredService<ILogger<LegacyProfileEndpoint>>());
        var settings = new LegacySettingsEndpoint(players,
            services.GetRequiredService<ILogger<LegacySettingsEndpoint>>());
        return
        [
            Entry.Authenticated(Action.SetPlayerStatus, Feature.Player,
                profile.ExecuteAsync),
            Entry.Authenticated(Action.UpdateDeviceToken, Feature.Player,
                profile.ExecuteAsync),
            Entry.Authenticated(Action.ChangeLanguage, Feature.Player,
                profile.ExecuteAsync),
            Entry.Authenticated(Action.ChangePlayerCountry, Feature.Player,
                profile.ExecuteAsync),
            Entry.Authenticated(Action.ChangePlayerName, Feature.Player,
                profile.ExecuteAsync),
            Entry.Authenticated(Action.UpdateSettings, Feature.Player,
                settings.UpdateAsync),
        ];
    }

    private static IReadOnlyList<Entry> ProgressionActions(IServiceProvider services)
    {
        LegacyPlayerStore players = services.GetRequiredService<LegacyPlayerStore>();
        LegacyDogTagPolicy? policy = LegacyDogTagPolicy.FromCatalog(services.GetRequiredService<LegacyCatalog>(),
            services.GetRequiredService<LegacyStarterPolicy>());
        var dogTags = new LegacyDogTagEndpoint(players, policy,
            services.GetRequiredService<ILogger<LegacyDogTagEndpoint>>());
        return
        [
            Entry.Authenticated(Action.RefillDogtags, Feature.Economy,
                dogTags.ExecuteAsync),
            Entry.Authenticated(Action.PayOneDogTag, Feature.Economy,
                dogTags.ExecuteAsync),
            Entry.Authenticated(Action.OnVIPExpired, Feature.Economy,
                dogTags.ExecuteAsync),
            Entry.Authenticated(Action.GameStartedTutorial, Feature.Player,
                (request, player, token) => LegacyTutorialEndpoint.ExecuteAsync(request, player, players, token)),
            Entry.Authenticated(Action.TutorialEnded, Feature.Player,
                (request, player, token) => LegacyTutorialEndpoint.ExecuteAsync(request, player, players, token)),
        ];
    }
}
