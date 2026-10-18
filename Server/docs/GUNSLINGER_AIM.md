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

The numerical callback tests supply current poses directly. A scheduled normal Gunslinger
callback, target-pose resampling in that scheduler, root turn, projectile launch, collision,
point change and normal Client presentation are still pending. These helpers and captures are
not proof of automatic firing. See the [feature checklist](BATTLE_SERVER_FEATURES.md),
[target selection](GUNSLINGER_TARGET_SELECTION.md) and [native timing](GUNSLINGER_STAND_TIMING.md).
