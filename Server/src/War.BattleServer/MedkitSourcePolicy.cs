namespace War.BattleServer;

/// <summary>Recovered 1.4.0 CardConstants for instant medikits.</summary>
internal static class MedkitSourcePolicy
{
    internal sealed record Definition(string SourceCardId,string CardClassId,
        float MaximumHealthFraction);

    internal static Definition? Resolve(string sourceCardId) => sourceCardId switch
    {
        "" or "MEDKIT" => new("MEDKIT","CardHealMeNow",.2f),
        "SMALLMEDKIT" => new("SMALLMEDKIT","CardHealMeNowSmall",.1f),
        _ => null
    };

    internal static Definition? FromClass(string cardClassId) => cardClassId switch
    {
        "CardHealMeNow" => Resolve("MEDKIT"),
        "CardHealMeNowSmall" => Resolve("SMALLMEDKIT"),
        _ => null
    };
}
