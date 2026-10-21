namespace War.LegacyContract.Tests.Recovered;

internal sealed class ArmyScreen
{
    public void EquippedUnitsUpdate() => OracleTrace.Calls.Add("units-updated");
}
