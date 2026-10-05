# Recovered 1.4.0 PvP hit-credit provenance

This is the B24 rule for `StatsManager.MatchStats.hits`. It is narrower than damage, a projectile impact, or the Worker's `confirmed_enemy_hits`. No Backend reward or statistic should consume the latter as the source hit count.

| Client call path | What reaches `Weapon.ReportShotHit` | `MatchStats.hits` effect |
| --- | --- | --- |
| `BulletBase.OnHit` | Calls `DoDamage(..., out damagedObject)` for the raycast collider, then passes that object to `ReportShotHit` even when damage is not applied. | One hit only if this is the local player's weapon, the shot is not a network copy, and `damagedObject` has a non-None fraction opposing the current player. A valid enemy shield contact can count even without HP loss. |
| `BulletPoison.OnHit` | Writes the target into `mHitDestroyableObject`, but passes a separate local `destroyableObject` initialized to null. | The recovered source does **not** increment this statistic on this path. Preserve this observable behavior until a deliberate Client change is authorized. |
| `GrenadeAmmoBase.Explode` and `MineAmmo` | Call `ReportShotHit` with a null destroyable object. | No `MatchStats.hits` increment from these calls, even if their explosions damage enemies. |

The shared predicate is in `Weapon.ReportShotHit`: `!isNetworkCopy`, `owner == PlayerController.currentPlayer`, PvP mode, and an opposing non-None `DestroyableObject.fraction`. The exact source sites are `Weapon.cs:341`, `BulletBase.cs:129-145`, `BulletPoison.cs:27-39`, `GrenadeAmmoBase.cs:205-213`, `MineAmmo.cs:165,179`, and `StatsManager.cs:1408` under `Clients/ExportedProject/Assets/Scripts/Assembly-CSharp`.

On the Worker, `MatchEngine` dispatches player bullets from `projectiles`, but also dispatches vehicle fire from `vehicleProjectiles`. Both can reach the same `ApplyArmyProjectileImpact`, `ApplyDecoyProjectileImpact`, and `ApplyHeavyTurretProjectileImpact` helpers. `confirmed_enemy_hits` is also incremented by land mines, army fire, turret fire, grenade/bazooka area damage, and direct player impacts. Its caller's player ID is not proof that the original source `Weapon.ReportShotHit` would have run.

Implementation gate: carry immutable projectile origin (`player weapon` versus army/deployable) and recovered ammo behavior through collision resolution; use the exact impacted collider's destroyable/fraction identity, not its parent or only whether health changed; preserve the poison and null-target exclusions; count only one source-equivalent local-owner hit per eligible bullet callback; then persist a separately named per-player terminal counter with conservation and replay validation. Compare each weapon family against a running Unity Client before mapping it to durable `MatchStats.hits`. Until then, existing host hit counters remain combat diagnostics, not economy or achievement authority.
