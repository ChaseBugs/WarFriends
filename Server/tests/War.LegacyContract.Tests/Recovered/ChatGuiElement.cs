namespace War.LegacyContract.Tests.Recovered;

internal sealed class ChatGuiElement
{
    public ActiveUnitsContent activeUnitsContent { get; } = new();

    internal sealed class ActiveUnitsContent
    {
        public void DatabaseResult(bool dbSuccess) => OracleTrace.Calls.Add("units-result");
    }
}
