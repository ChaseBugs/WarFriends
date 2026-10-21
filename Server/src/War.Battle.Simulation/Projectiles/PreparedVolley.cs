namespace War.BattleServer;

// One host-prepared click: damage-bearing flights and presentation-only flights
// are validated and admitted together before the shell or projectile IDs move.
internal sealed record PreparedVolley(IReadOnlyList<PreparedProjectile> Real,
    IReadOnlyList<ShotgunFakePelletFlight> Fake);
