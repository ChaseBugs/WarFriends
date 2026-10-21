using War.Infrastructure;

namespace War.Backend.Transport.Http;

internal static class BackendHttpPolicy
{
    internal const int MaximumRequestBodyBytes = 65536;
    internal static int MaximumSupportedBodyBytes => TerminalResultEnvelope.MaximumBodyBytes;
}
