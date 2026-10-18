# Normal Assaulter prediction and weapon speed

The recovered source performs two different predictions. They cannot be combined by reading a
fresh target position at the later callback or by always using the initial rifle speed.

## Source rules

- Gun.ComputeFlyTimeToTarget uses distance from the current spawnPoint, divided by
  BulletSetup.bulletSpeed, plus 0.1 seconds. It does not add Gun.Shoot's shotOffset to that muzzle.
- PickPlayerOpponent predicts only a selected Moving player transform at acquisition, passing
  another 0.1 seconds to AimingHelper. Other target types keep their selected transform position.
- SoldierBehaviourAssaulter.ShootJustStarted first calls SetBullletSpeedCoef: one for a player,
  three for another entity. It then predicts from the already prepared targetPosition, using
  the callback's current spawnPoint and target velocity, with another 0.3 seconds.
- BulletSetup.bulletSpeed is speed * speedMultiplayer. The coefficient remains until a later
  callback or reset, so an entity shot can make the next moving-player acquisition use speed 15
  before its own callback changes speed back to 5.
- BulletSetup.fakeSpeed is speed * fakeSpeedFactor. It ignores speedMultiplayer and remains 7.5
  for the pinned rifle even when real bullets use speed 15.

The source time scale is one in these host calculations. The current source binding pins real
speed 5 and fake speed 7.5; no Client packet supplies either value or the mutable coefficient.

## Implementation

AssaulterWeaponAimState owns the per-actor coefficient independently of the immutable rifle
catalog. SelectMovingPlayer captures current speed and selection inputs. StartPlayerShot and
StartEntityShot calculate the separate callback prediction, validating the complete result before
changing speed. Earlier immutable predictions retain their original muzzle, input position,
velocity and speed after later callbacks.

Normal spawn/navigation initializes this weapon state once, including while waiting for a free
point. Point retries do not reset it. Host-confirmed death removes it.

CaptureAssaulterAim now binds moving-player acquisition to the selected current transform,
actual host player motion and current sampled infantry rig muzzle. The immutable prepared record
keeps the raw source transform separate from its predicted TargetPosition and acquisition tick.
Subsequent player movement cannot rewrite that record. Non-Moving targets remain unpredicted at
this first stage, matching the recovered source.

## Verification and remaining boundary

--assaulter-aim-only passes fourteen checks. Calculation tests cover both padding stages, the
persistent 1/3 real-speed state, unaffected fake speed, current callback muzzle/velocity versus
latched aim, prior-capture immutability, actor/source isolation and malformed-callback rollback.

A fixed Park fixture uses ordinary deployment, actual Corner arrival and an ordinary MoveCover
command. It captures a Moving player target with nonzero observed velocity and checks the muzzle
against the pinned rig's current clip, root position, facing and animation clock. It verifies
the source acquisition formula, later-movement immutability and weapon-state cleanup on death.
No projectile, collision or damage callback is injected to stand in for a shot.
Release build has zero warnings/errors. Target-selection checks pass 29, navigation/entry checks
pass 19 and combat regression passes 26,395 assertions after this component's initialization and
cleanup changes. The new tests are registered in the default suite; that complete suite was not rerun.

These aim tests explicitly call CaptureAssaulterAim and the calculation model. The subsequent
[automatic volley integration](ASSAULTER_VOLLEYS.md) now executes the scheduled callback using
the latched position, current target velocity and native queued muzzle. The focused aim tests
alone remain calculation evidence; actual fire has a separate host fixture. Complete native
warm-pose parity, vehicle/air targets and normal Unity presentation remain unverified.
