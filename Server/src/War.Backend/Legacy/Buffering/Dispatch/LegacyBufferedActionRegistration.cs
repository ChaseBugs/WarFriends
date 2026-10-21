using System.Text.Json.Nodes;

namespace War.Backend.Legacy.Buffering;

internal sealed record LegacyBufferedActionRegistration(
    DatabaseAction Action,
    LegacyBufferedFeature Feature,
    Func<BufferedRequest, LegacyBufferedState, (DatabaseResult Code, JsonObject Node)> Handler);
