namespace War.LegacyContract.Tests.Recovered;

internal sealed class AssignmentsManager
{
    public static AssignmentsManager instance { get; } = new();

    public void LoadData(string json) => OracleTrace.Decode(json, "AssignmentData");
}
