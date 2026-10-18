# Normal Assaulter automatic volleys

The ordinary deployed Assaulter now advances from its automatic Corner attempt through callback,
source-cadenced rounds and end-of-volley cooldown without an injected shot command.

## Recovered rules

`EnemyController.PrepareToShoot` prepares the target, batch and side before the root turn and
`SoldierAnimationController.ShotFromCover`. `ShootJustStarted` uses the prepared target position
with the current muzzle and target velocity. Player shots reset real speed to 5; entity shots
use 15. Cosmetic bullets retain speed 7.5 independently. The callback resumes after Update,
so the first gameplay poll is the following host tick. Strict 0.35-second cadence is 11 ticks.

The host samples the pinned native queued muzzle, applies the source Corner root turn and
retains round offsets for later muzzle samples. Fake aim uses the local/master shooting branch's
lateral offset and has no damaging collision. Real rounds capture current weapon damage and
player coefficients at launch. Completion regenerates the source cooldown; hide starts after
the strict half-second boundary. Target root velocity is observed after movement each tick;
removed targets retain their last observation only while an outstanding callback needs it.

Real collision dispatch reuses shared shield, player, unit, vehicle and environment authority.
Airborne shots survive their firing soldier. A dead soldier cannot acquire a new revenge window;
its already launched shot can still damage the player without aborting the match.

## Verified scope

`--assaulter-volley-only` passes 52 checks using normal Park deployment and automatic host ticks.
Each first volley contains two rounds at source cadence. Actual shield damage is 88.79999 from
raw damage 29.6; explicitly armed Sickness produces 44.400024 from raw 14.8. Cosmetic rounds
leave player/shield health unchanged. An actual time-limit transition destroys shields and
enters overtime; two real rounds then remove 29.599976 total player health, matching the source
coefficient within float tolerance. The fixture kills the firing soldier after its last round
to prove projectile lifetime and damage authority survive that cleanup.

Release build passes with zero warnings/errors. Shared combat regression passes 26,395
assertions; focused Grenadier damage, moving acquisition and Sickness checks pass 23, 25 and
116 respectively. The complete default suite and normal Unity runtime were not rerun.

Sickness is explicitly armed through the internal window in this fixture. This does not verify
authorized card use, inventory consumption, protocol activation or normal Client presentation.
The damage fixture does not prove every dynamic unit/vehicle impact branch. Repeated volleys,
warm layered animation parity, point changes, healing, parachutes, vehicle/air targeting and
normal Unity/Android controller integration remain open. Native muzzle evidence comes from the
documented standalone observation, not original Unity 5.2.5f1 gameplay verification.
