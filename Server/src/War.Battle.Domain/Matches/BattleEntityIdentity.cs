namespace War.BattleServer;

/// <summary>Keeps card-spawned entities outside the ordinary army identity range.</summary>
internal static class BattleEntityIdentity
{
    internal const int FirstCardEntityId = 2_000_000_000;
}
