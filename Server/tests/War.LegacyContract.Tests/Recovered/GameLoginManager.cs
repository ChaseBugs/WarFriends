namespace War.LegacyContract.Tests.Recovered;

internal static class GameLoginManager
{
    public static void Relog() => OracleTrace.Calls.Add("relog");
}
