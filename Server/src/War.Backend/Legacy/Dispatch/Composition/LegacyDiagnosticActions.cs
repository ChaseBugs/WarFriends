using War.Backend.Legacy.Analytics;
using War.Backend.Legacy.Diagnostics;
using War.Persistence;
using Action = War.Backend.Legacy.DatabaseAction;
using Entry = War.Backend.Legacy.Dispatch.LegacyActionRegistration;
using Feature = War.Backend.Legacy.Dispatch.LegacyActionFeature;

namespace War.Backend.Legacy.Dispatch.Composition;

internal static class LegacyDiagnosticActions
{
    public static IReadOnlyList<Entry> Create(IServiceProvider services)
    {
        var registrations = new List<Entry>();
        registrations.AddRange(PresentationMarkers(services));
        registrations.AddRange(Diagnostics(services));
        return registrations;
    }

    private static IReadOnlyList<Entry> PresentationMarkers(IServiceProvider services)
    {
        LegacyPlayerStore players = services.GetRequiredService<LegacyPlayerStore>();
        return
        [
            Entry.Authenticated(Action.ChatShownFirstTime, Feature.Player,
                (request, player, token) =>
                    LegacyAnalyticsEndpoint.ExecuteAsync(request.Action, player, players, token)),
            Entry.Authenticated(Action.CustomizationShown, Feature.Player,
                (request, player, token) =>
                    LegacyAnalyticsEndpoint.ExecuteAsync(request.Action, player, players, token)),
            Entry.Authenticated(Action.WarpathShownFirstTime, Feature.Player,
                (request, player, token) =>
                    LegacyAnalyticsEndpoint.ExecuteAsync(request.Action, player, players, token)),
            Entry.Authenticated(Action.CardpoolShown, Feature.Player,
                (request, player, token) =>
                    LegacyAnalyticsEndpoint.ExecuteAsync(request.Action, player, players, token)),
            Entry.Authenticated(Action.CraftingShown, Feature.Player,
                (request, player, token) =>
                    LegacyAnalyticsEndpoint.ExecuteAsync(request.Action, player, players, token)),
            Entry.Authenticated(Action.LeagueLeaderboardShown, Feature.Player,
                (request, player, token) =>
                    LegacyAnalyticsEndpoint.ExecuteAsync(request.Action, player, players, token)),
            Entry.Authenticated(Action.ElitesFeatureShown, Feature.Player,
                (request, player, token) =>
                    LegacyAnalyticsEndpoint.ExecuteAsync(request.Action, player, players, token)),
        ];
    }

    private static IReadOnlyList<Entry> Diagnostics(IServiceProvider services)
    {
        var diagnostics = new LegacyDiagnosticEndpoint(
            services.GetRequiredService<ILogger<LegacyDiagnosticEndpoint>>());
        return
        [
            Entry.Authenticated(Action.ReportCheater, Feature.Diagnostics,
                (request, player, _) => Task.FromResult(diagnostics.ReportCheater(request, player))),
            Entry.Authenticated(Action.SendLog, Feature.Diagnostics,
                (request, player, _) => Task.FromResult(diagnostics.ReceiveLog(request, player))),
            Entry.Authenticated(Action.ErrorMessage, Feature.Diagnostics,
                (request, player, _) => Task.FromResult(diagnostics.ReceiveError(request, player))),
            Entry.Authenticated(Action.SpecialOfferShowed, Feature.Diagnostics,
                (request, player, _) => Task.FromResult(diagnostics.ReceiveOfferShown(request, player))),
            Entry.Authenticated(Action.WarArenaShown, Feature.Diagnostics,
                (request, player, _) => Task.FromResult(diagnostics.ReceiveArenaShown(request, player))),
            Entry.Authenticated(Action.SendCrashReport, Feature.Diagnostics,
                (_, player, _) => Task.FromResult(diagnostics.ReceiveCrashReport(player))),
            Entry.Authenticated(Action.UpdateAnalytics, Feature.Diagnostics,
                (_, player, _) => Task.FromResult(diagnostics.ReceiveAnalytics(player))),
            Entry.Authenticated(Action.SaveFuseConfigs, Feature.Diagnostics,
                (_, player, _) => Task.FromResult(diagnostics.ReceiveFuseConfiguration(player))),
            Entry.Authenticated(Action.Test, Feature.Diagnostics,
                (_, _, _) => Task.FromResult(LegacyDiagnosticEndpoint.Test())),
        ];
    }
}
