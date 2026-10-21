using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopBotRule
{
    public int MissionIndex { get; }
    public string Name { get; }
    public int Difficulty { get; }
    public int Level { get; }
    public float HealthMultiplier { get; }
    public string Camo { get; }
    public string HeadAccessory { get; }
    public string Helmet { get; }
    public string PowerBand { get; }
    public bool UseDefinedCards { get; }
    public IReadOnlyList<string> Cards { get; }

    internal CoopBotRule(int missionIndex, string name, int difficulty, int level,
        float healthMultiplier, string camo, string headAccessory, string helmet,
        string powerBand, bool useDefinedCards, string[] cards)
    {
        MissionIndex = missionIndex;
        Name = name;
        Difficulty = difficulty;
        Level = level;
        HealthMultiplier = healthMultiplier;
        Camo = camo;
        HeadAccessory = headAccessory;
        Helmet = helmet;
        PowerBand = powerBand;
        UseDefinedCards = useDefinedCards;
        Cards = new ReadOnlyCollection<string>(cards);
    }
}
