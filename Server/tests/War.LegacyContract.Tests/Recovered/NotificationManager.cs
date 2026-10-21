namespace War.LegacyContract.Tests.Recovered;

internal sealed class NotificationManager
{
    public void UpdateWeaponDelivery() => OracleTrace.Calls.Add("weapon-notification");

    public void UpdateUnitDelivery() => OracleTrace.Calls.Add("unit-notification");
}
