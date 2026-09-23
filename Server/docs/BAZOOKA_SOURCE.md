# Recovered bazooka authority

The recovered 1.4.0 Client contains seven `PlayerHoldWeapon` bazooka families and 412 total upgrade stages:

| Source family | Inventory index | Stages |
|---|---:|---:|
| FGM | 37 | 66 |
| FGM Elite | 57 | 66 |
| HMV | 38 | 46 |
| Hater | 58 | 76 |
| M202 | 42 | 76 |
| Panzerfaust | 41 | 56 |
| RPG-7 | 3 | 26 |

`SelfHostedBazookaExport.Run` reads MainScene and pins each setup, `PlayerHoldWeapon`, `Bazooka`/`BazookaFangs`, primary and secondary muzzles, missile prefab, collision masks, explosion geometry and trajectory inputs. `BazookaCatalog` binds that evidence to every recovered `RELOADTIME`, `AMMO`, `EXPLODEDAMAGE`, and `MINDAMAGE` stage row before admission.

All seven scene controllers use a serialized 0.7-second hold, family-2 animation, a finite non-reloadable ammo pool, speed 4, dead radius 0.8 and hurt radius 1.4. A press captures one aim position and firing occurs only while the touch remains held strictly past the timer. Early release cancels it. The source uses the upgrade `RELOADTIME` as post-shot cadence.

M202 is the exceptional `BazookaFangs` family. It launches the primary missile immediately and schedules three missiles from its secondary muzzle at 0.1-second intervals. The add weapon alternates fake/real/fake; fake missiles retain presentation but `Explosion.MissileExplode` exits before damage. Each real M202 missile receives half the stage explosion damage, so two authoritative explosions conserve the recovered total. Its trajectory is curved and uses the serialized rotation profile. The other six families use a straight RPG Bold missile.

The host now accepts a typed `BazookaHoldCommand`, publishes `bazooka_targeting`, enforces the strict hold on its 30 Hz clock, consumes one finite round, and launches source-bound missiles from the animated primary or secondary muzzle. Straight and curved flight use recovered speed, collision masks, stop time, range, curve, fake/real sequence, and half-damage rules. Real impacts resolve the current animated player hitboxes, inner explosion versus outer shiver falloff, player/overtime coefficients, same-fraction/self rules, and live-shield occlusion. Projectile identities, delayed M202 launches, shot/impact events, capacity accounting, and terminal cleanup stay server-owned.

The normal `SelfHostedDeathMatchBridge` recognizes `PlayerHoldWeapon` before swipe/fire handling, forwards press/repeat/release through the portable SDK, and starts or stops the recovered `HudScreen` targeting animation from authoritative snapshots. The immutable catalog, hold/cancel path, both trajectories, radial damage, M202 real/fake sequence, MatchEngine path, and authenticated Worker transport pass 50 focused assertions with `dotnet run --project Server/tests/War.Battle.Tests -- --bazooka-only`. The solution builds with zero warnings/errors, protocol tests pass 1,025 checks, the complete Battle suite passes 94,012 assertions, and Unity 2018.3 batch compilation exits successfully after installing the refreshed SDK.

Bazooka explosions also mutate source-bound shields with the recovered `ShieldExplosionCoef`, per-weapon shield ratio and friendly-fire coefficient, and mutate barrels with inner/outer damage while preserving explosion/shiver cause through synchronous barrel chains. Focused live `MatchEngine` tests prove both dynamic lifecycles.

Remaining bazooka work is spawned missile/explosion visual presentation in the normal Client, a rendered live Unity UDP audit, and Android/two-device proof.
