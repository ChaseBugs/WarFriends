namespace War.LegacyContract.Tests.Recovered;

internal sealed class Wallet
{
    public void InitGold(long value)
    {
        OracleTrace.Calls.Add("Gold");
        OracleTrace.Gold = value;
    }

    public void InitWarBucks(long value)
    {
        OracleTrace.Calls.Add("WarBucks");
        OracleTrace.WarBucks = value;
    }
    public void Init(long gold, long warbucks)
    {
        InitGold(gold);
        InitWarBucks(warbucks);
    }

    public void AddWarBucksReward(long value) => OracleTrace.Calls.Add("warbucks-reward");
}
