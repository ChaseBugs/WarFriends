using Newtonsoft.Json.Linq;
using War.Backend.Legacy;
using War.Persistence.Legacy.Buffers;

namespace War.LegacyContract.Tests;

/// <summary>Requires an executed real producer outcome for every reviewed literal server disposition.</summary>
internal static class BufferProducerCoverage
{
    private static readonly HashSet<string> Observed = [];
    private static readonly HashSet<string> AuthorityChecked = [];

    internal static void Record(
        BufferedRequest request, LegacyBufferedMutation mutation, bool hasCheckedAuthority = false)
    {
        string identity = request.Action + "/" + (DatabaseResult)mutation.Result;
        Observed.Add(identity);
        if (hasCheckedAuthority)
        {
            AuthorityChecked.Add(identity);
        }
    }

    internal static int RequireComplete(JObject matrix)
    {
        var missing = new List<string>();
        int expected = 0;
        foreach (JProperty action in matrix["serverResults"]!.Children<JProperty>())
        {
            foreach (string? result in action.Value.Values<string>())
            {
                expected++;
                string identity = action.Name + "/" + result;
                if (!Observed.Contains(identity) || !AuthorityChecked.Contains(identity))
                {
                    missing.Add(identity);
                }
            }
        }

        if (missing.Count != 0)
        {
            throw new InvalidOperationException("Producer outcomes not exercised:\n" + string.Join("\n", missing));
        }

        return expected;
    }
}
