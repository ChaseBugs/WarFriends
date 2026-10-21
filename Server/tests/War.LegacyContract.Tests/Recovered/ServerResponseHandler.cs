using Newtonsoft.Json.Linq;

namespace War.LegacyContract.Tests.Recovered;

internal static partial class ServerResponseHandler
{
    internal static string Read(JToken response, bool isLast) => ProcessBuffer(response, "", isLast);
}
