namespace War.BattleServer;

/// <summary>Freezes the source damage and player policy for a launched Rocket Soldier or Mortar missile.</summary>
internal sealed record CardRocketLaunchAuthority(
    string OwnerPlayerId, ArmyCardRocketRuntime Missile, ArmyPlayerDamagePolicy PlayerPolicy)
{
    internal ArmyMortarRuntime? Mortar { get; init; }

    internal string ProjectileKind => Mortar == null ? "card-rocket" : "army-mortar";
}
