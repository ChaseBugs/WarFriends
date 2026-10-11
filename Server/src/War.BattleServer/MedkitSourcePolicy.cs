namespace War.BattleServer;

/// <summary>Recovered 1.4.0 CardConstants for the three player medikits.</summary>
internal static class MedkitSourcePolicy
{
    internal sealed record Definition(string SourceCardId,string CardClassId,
        float MaximumHealthFraction,float MinimumHealthFraction=0,
        int DurationSeconds=0);

    internal static Definition? Resolve(string sourceCardId) => sourceCardId switch
    {
        "" or "MEDKIT" => new("MEDKIT","CardHealMeNow",.2f),
        "SMALLMEDKIT" => new("SMALLMEDKIT","CardHealMeNowSmall",.1f),
        "BIGMEDKIT" => new("BIGMEDKIT","CardHealMeNowBig",.35f,.25f,15),
        _ => null
    };

    internal static Definition? FromClass(string cardClassId) => cardClassId switch
    {
        "CardHealMeNow" => Resolve("MEDKIT"),
        "CardHealMeNowSmall" => Resolve("SMALLMEDKIT"),
        "CardHealMeNowBig" => Resolve("BIGMEDKIT"),
        _ => null
    };
}
