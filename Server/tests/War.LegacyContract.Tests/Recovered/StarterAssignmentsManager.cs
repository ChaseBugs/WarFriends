namespace War.LegacyContract.Tests.Recovered;

internal sealed class StarterAssignmentsManager
{
    public static StarterAssignmentsManager instance { get; } = new();

    public void LoadData(string json) => OracleTrace.Decode(json, "StarterAssignmentsData");
}
