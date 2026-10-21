using Newtonsoft.Json.Linq;

namespace War.LegacyContract.Tests.Recovered;

internal sealed class CardManager
{
    public static CardManager instance { get; } = new();

    public void LoadData(JToken token) => OracleTrace.Decode((string?)token, "CardManagerData");
    public Card GetCardInstance(string name) => new();

    public void AddCard(string name)
    {
    }
}
