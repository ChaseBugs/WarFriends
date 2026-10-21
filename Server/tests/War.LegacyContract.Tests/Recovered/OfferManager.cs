using Newtonsoft.Json.Linq;

namespace War.LegacyContract.Tests.Recovered;

internal sealed class OfferManager
{
    // The actual callee explicitly accepts a missing token and clears its offer collection.
    public void UpdateFromServer(JToken? token) => OracleTrace.Calls.Add("offers");
}
