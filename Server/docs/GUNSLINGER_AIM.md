# Normal Gunslinger aim and one-shot batch

## Source behavior

SoldierBehaviour.ApplyWeaponsSetup copies the composed definition shotSpeed into BulletSetup.speed.
The ArmyUpgrades BULLETSPEED row and trusted perk shotSpeedCoef therefore own the initial speed.
EffectiveInfantryBulletSpeed reads the already validated runtime table and applies that coefficient
once. A normal Gunslinger receives its own mutable aim state during trusted stat initialization;
authoritative death removes that state. Shared catalog values and sibling actors remain unchanged.

SoldierBehaviour.PickPlayerOpponent predicts a moving player with the current weapon multiplier,
using Gun.ComputeFlyTimeToTarget (distance/speed + 0.1 seconds) plus another 0.1 seconds.
Gunslinger ShootJustStarted later sets speed multiplier to 0.5 for players or 1 for other entities,
reads mShotTarget.transform.position again, and predicts with zero extra time. This is different
from Assaulter's frozen prepared aim, triple entity speed and extra 0.3 seconds at callback.
A later moving-player acquisition retains the multiplier written by the previous callback.

For Shield, GameShootableEntityPlayer.GetShotTargets creates a new ShotTarget whose transform
is the selected cover's shotPosition. The callback therefore retains that captured cover binding,
not the player's serialized Shield child and not a newly selected cover. The target descriptor
now records the captured cover index for callback resolution.

GunslingerWeaponAimState exposes those stages separately. Callback callers must provide the
current raw source transform, current target velocity and current animated muzzle. Selection-time
prediction must never be fed back as the callback's raw transform. Prediction validates all inputs
and the finite result before changing the mutable speed multiplier.

## Base batch before single shot

SoldierBehaviourGunslinger.StartShooting calls the base implementation first and only then sets
mFireBatchSize to one. GunslingerShotBatchPolicy therefore consumes the original exclusive batch
draw, fourteen-round clamp and every original real/fake roll. Only bit zero authorizes the single
resulting round; later real bits cannot turn a fake first round into a real shot.

## Verification and remaining work

The focused tests exercise both prediction stages, a changed target between acquisition and
callback, persistent multipliers, malformed-input rejection, complete base draws and the clamp.
Actual ordinary deployment checks source speed ownership, target capture, independent sibling
state and authoritative death cleanup. The match-owned CaptureGunslingerAim selector records the
actor and acquisition tick and uses the shared native muzzle lookup for moving-player capture.

```powershell
dotnet run --project Server/tests/War.Battle.Tests -c Release --no-build -- --gunslinger-aim-only
```

The focused aim/batch group passes 20 checks. Normal Gunslinger navigation and target selection
pass 50 and 16 checks respectively; the shared Assaulter aim group passes 14. Release build has
zero warnings/errors. Shared combat regression passes 26,395 assertions; the native stand
source-bound verifier remains unchanged. The full default suite and Linux runtime were not rerun.

The numerical aim tests supply current poses directly. The subsequent
[automatic shooting implementation](GUNSLINGER_SHOOTING.md) now executes source preparation,
callback sampling and real/cosmetic projectile flight. [Point changes](GUNSLINGER_POINT_CHANGES.md)
now preserve the weapon state across walking and fresh arrival. [Holster metadata](GUNSLINGER_HOLSTER.md)
is now projected without changing weapon speed/damage. Visible attachment and remaining
presentation/combat proofs are tracked on the feature checklist.
