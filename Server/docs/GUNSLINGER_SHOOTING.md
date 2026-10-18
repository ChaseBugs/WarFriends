# Normal Gunslinger shooting

## Implemented host path

Ordinary deployment now walks to the source Gunslinger point, enters its maximum-attempt state,
waits for the strict next tick and prepares a shot automatically. Preparation selects a current
source target, consumes all base batch/real-fake draws, forces one round and starts the positive
0.2-second root turn. The source random cooldown draw still occurs even though completion later
replaces it with Colt cadence. A pending attempt blocks another preparation.

The recovered stand clip determines the first coroutine delay; warm attempts use zero delay.
The callback samples the current selected target and velocity, applies the player/entity speed
multiplier and predicts from the native Colt-phase muzzle. The first gameplay poll after the
callback launches one real or cosmetic ArmyProjectileFlight. Gun.shotOffset is world-up 0.05,
real player speed is half the composed base speed, other real targets use base speed and cosmetic
speed retains the source fake-speed factor independently of the real multiplier.

Real rounds use the existing authoritative flight and collision pipeline for shields, players,
infantry and the already supported dynamic targets. Launch identity, current damage and player
coefficients are frozen per projectile. A shooter death cancels pending attempts and releases
its point/state, while already launched projectiles retain their flight and launch authority.
Three ordinary attempts complete with strict 0.18-second next-preparation deadlines; the
zero-delay callback and next gameplay poll still add their separate frames.

## Shield target correction

GameShootableEntityPlayer.GetShotTargets creates a new Shield ShotTarget referencing the
selected cover's shotPosition. This replaces the serialized player-child target. The internal
target descriptor now retains that cover index so the callback keeps the selected transform
identity even if the player later moves to another cover. Initial raw-child callback sampling
produced a scenery hit with no damage and was rejected during implementation. The corrected
Park fixture applies actual shield damage through the source UnitToShield coefficient.

## Verified boundary

The focused shooting fixture passes 29 checks with actual ordinary deployment and automatic
ticks, not a direct launch helper. It covers the first callback and poll, native muzzle placement/root facing,
real shield damage, moving-player callback velocity with retained Shield identity, cosmetic
no-impact/no-damage behavior, cancellation during windup, airborne
survival after shooter death, and the complete three-attempt allowance. The Sickness fixture
now captures a real ordinary Gunslinger projectile with half damage after the spawn window closes.

```powershell
dotnet run --project Server/tests/War.Battle.Tests -c Release --no-build -- --gunslinger-shooting-only
```

Native stand evidence covers the successful continuous firing sequence in two update orders.
The strict one-second hide transition now uses binary32 source tick time and is checked against
both observed stop transitions (56 stand checks), rather than imposing an unconditional
31-frame delay. The Sickness group passes 164 checks, including actual Gunslinger launch damage
118.245 at tick 324. Assaulter automatic-volley regression passes 110 checks, and normal
Gunslinger navigation passes 50 checks across all five maps. The Release build has zero
warnings/errors. Shared combat regression passes 26,395 assertions. Full default-suite, original
Unity 5.2.5 and Linux runtime validation were not rerun for this checkpoint.

[Exhausted-attempt point changes](GUNSLINGER_POINT_CHANGES.md) now execute automatically and
restart a fresh burst after authored arrival. [Holster state](GUNSLINGER_HOLSTER.md) is now
projected through protobuf and the SDK, while the actual visible weapon attachment remains open.
This is not full Gunslinger completion. Interrupted/failed animation preparations, native blend parity for
all presentation frames, moving player/infantry hit outcomes, Decoy and vehicle-specific live
combat branches, and normal Client presentation need additional proof. A target removed before
callback retains its last host-observed pose/velocity; post-death native ragdoll transform motion
is not modeled or verified. Linux runtime and normal Unity battle-controller integration remain
unverified. Keep these on the [feature checklist](BATTLE_SERVER_FEATURES.md).
