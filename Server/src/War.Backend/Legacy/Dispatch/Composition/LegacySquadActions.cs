using War.Backend.Legacy.Player;
using War.Backend.Legacy.Squads;
using War.Persistence;
using Action = War.Backend.Legacy.DatabaseAction;
using Entry = War.Backend.Legacy.Dispatch.LegacyActionRegistration;
using Feature = War.Backend.Legacy.Dispatch.LegacyActionFeature;

namespace War.Backend.Legacy.Dispatch.Composition;

internal static class LegacySquadActions
{
    public static IReadOnlyList<Entry> Create(IServiceProvider services)
    {
        var registrations = new List<Entry>();
        registrations.AddRange(Mutations(services));
        registrations.AddRange(Queries(services));
        return registrations;
    }

    private static IReadOnlyList<Entry> Mutations(IServiceProvider services)
    {
        LegacyPlayerStore players = services.GetRequiredService<LegacyPlayerStore>();
        LegacyCatalog catalog = services.GetRequiredService<LegacyCatalog>();
        var projection = new LegacySquadProjection(player => LegacyPlayerProjection.Player(player, false),
            LegacySquadDataProjection.Squad);
        var squads = new LegacySquadEndpoint(players, LegacySquadPolicy.FromCatalog(catalog), projection,
            services.GetRequiredService<ILogger<LegacySquadEndpoint>>());
        return
        [
            Entry.Authenticated(Action.CreateSquad, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.JoinSquad, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.InvitePlayerToSquad, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.JoinSquadRequest, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.AcceptSquadJoinRequest, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.DeclineSquadJoinRequest, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.LeaveSquad, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.PromotePlayer, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.DemotePlayer, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.PromotePlayerToFounder, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.KickPlayer, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.UpdateSquad, Feature.Squads,
                squads.ApplyAsync),
            Entry.Authenticated(Action.UpdateSquadEmblem, Feature.Squads,
                squads.ApplyAsync),
        ];
    }

    private static IReadOnlyList<Entry> Queries(IServiceProvider services)
    {
        var query = new LegacySquadQueryEndpoint(services.GetRequiredService<LegacyPlayerStore>(),
            services.GetRequiredService<LegacySquadStore>());
        return
        [
            Entry.Authenticated(Action.CheckUniqueSquadName, Feature.Squads,
                (request, _, token) => query.CheckUniqueNameAsync(request, token)),
            Entry.Authenticated(Action.GetSquadDetails, Feature.Squads,
                (request, _, token) => query.ReadDetailsAsync(request, token)),
            Entry.Authenticated(Action.GetAllSquadMembers, Feature.Squads,
                (request, _, token) => query.ReadMembersAsync(request, token)),
            Entry.Authenticated(Action.GetFullSquadInfo, Feature.Squads,
                (request, _, token) => query.ReadFullInfoAsync(request, token)),
            Entry.Authenticated(Action.GetSquads, Feature.Squads,
                (request, _, token) => query.SearchAsync(request, token)),
            Entry.Authenticated(Action.FindSuggestedSquads, Feature.Squads,
                (request, _, token) => query.SearchAsync(request, token)),
        ];
    }
}
