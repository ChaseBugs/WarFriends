using War.Backend.Legacy.Buffering;
using War.Persistence;
using Action = War.Backend.Legacy.DatabaseAction;
using Entry = War.Backend.Legacy.Dispatch.LegacyActionRegistration;
using Feature = War.Backend.Legacy.Dispatch.LegacyActionFeature;

namespace War.Backend.Legacy.Dispatch.Composition;

internal static class LegacyBufferActions
{
    public static IReadOnlyList<Entry> Create(IServiceProvider services)
    {
        var buffers = new LegacyBufferedEndpoint(services.GetRequiredService<LegacyBufferProcessor>());
        return
        [
            Entry.Authenticated(Action.SendRequestBuffer, Feature.Buffering,
                buffers.ApplyAsync),
        ];
    }
}
