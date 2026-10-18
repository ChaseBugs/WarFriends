# Grenadier moving-target acquisition

Moving primary acquisition previously called `ArmyWeaponBindingCatalog.RestMuzzleOrigin` with
ID_UNIT-GRENADIER. That eight-family catalog excludes Grenadier, so a legitimate moving-body
choice could throw instead of producing the recovered lead calculation. The branch now samples
the current host base pose and the actual selected pistol spawn binding.

## Source rule and geometry

`SoldierBehaviour.PickPlayerOpponent` halves shield probability while the opponent walks. If a
moving-body target is chosen, it calls `AimingHelper.PredictPosition` with 0.1 extra seconds.
`Gun.ComputeFlyTimeToTarget` uses the current spawn position, selected BulletSetup speed and
another 0.1 seconds. At the supported server time scale of one, the primary prediction is:

`movingPosition + velocity * (distance(currentMuzzle, movingPosition) / 5 + 0.1 + 0.1)`

The acquisition muzzle is not the later prepared/firing muzzle. `CardGrenadierAcquisitionMuzzle`
samples the current clip, clip start and facing from the host's published infantry base pose.
The Grenadier's idle/run clips now use the recovered pistol aliases. The generic stand-fire
name remains rifle_shot_loop, matching the source animation controller's default weapon branch;
actual corner firing continues to use the separate native pistol callback samples.

The existing native rig catalog contains an attached reference rifle. `GrenadierAcquisitionMuzzle`
removes that reference muzzle's source local rotation and applies the pistol/rifle local-position
difference at the shared right-hand snap. The reference rotation was already parsed/validated by
`CoopAssaulterWeaponCatalog`; it is now retained for this conversion. Both weapon bindings and
the native rig samples remain hash-pinned. Invalid sampled positions/rotations reject.

Acquisition occurs before the next player-animation sample. The latched aim therefore retains
the exact muzzle, moving target position, velocity and flight interval consumed at acquisition.
Comparing it with a later animation sample would test a different target position. These are
private host records, not new Client assertions or protocol fields. Subsequent player movement
does not rewrite the selected aim before the source shot callback.

## Verification

`--grenadier-moving-only` passes 25 checks:

- Reference-rifle replacement matches ten actual native pistol callback positions within 0.0001.
- Invalid sampled position/rotation authority rejects.
- In a fixed Aztec fixture, both participants select/ready and the owner activates GREATGRENADIER.
  The opponent sends an ordinary direction-1 MoveCover command just before source preparation.
- The actual host AI acquires a type-16 moving-body target with nonzero host velocity, using the
  current pistol base pose, source speed and both padding intervals. It stays running.
- The scheduled primary shot emits an authoritative pistol projectile and retains the acquired
  target and prediction inputs despite subsequent animation/movement. Acquisition is at tick 325
  and the shot is at tick 347 in this fixture.
- The first real moving-latch projectile is tracked individually until it leaves the active
  snapshot at tick 461. This fixed short cover movement ends before interception: the projectile
  misses, emits no Impact event, leaves opponent health unchanged and releases its launch damage
  authority. The source prediction is not silently redirected or treated as proof of a hit.

Release build passes with zero warnings/errors. Existing damage checks pass all 20 assertions,
callback/weapon checks pass 92, and `--combat-only` passes 26,395 assertions after the pose change.
The moving checks are registered in the default suite; the complete default suite was not rerun.

## Remaining boundary

This proves acquisition, scheduled launch and a real missed-flight cleanup without damage,
not an actual moving-player hit. The sampled
acquisition transform follows the current published base pose; complete warm-state overlays,
secondary-weapon pose transitions and normal Unity EnemyController comparisons remain required.
The independent native rig data was observed with Unity 2018.3.0f2, not the original 5.2.5f1
Android runtime. Authenticated UDP, Client presentation, in-ray friendly exclusions, host-scheduled
cosmetic shots and automatic/authorized Sickness activation remain separate incomplete work.
