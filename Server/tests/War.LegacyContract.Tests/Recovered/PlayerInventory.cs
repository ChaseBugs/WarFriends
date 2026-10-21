namespace War.LegacyContract.Tests.Recovered;

internal sealed class PlayerInventory
{
    public static PlayerInventory instance { get; } = new();

    public void LoadData(string json) => OracleTrace.Decode(json, "InventoryData");
}
