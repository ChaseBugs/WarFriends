# Gunslinger stand timing

## Source contract

The active 1.4.0 Gunslinger inventory in MainScene uses runtime weapon type Colt (16),
with AssaultRifleEnemy.prefab attached to the recovered soldier rig. The observation verifier
checks that serialized binding and hashes the behavior, EnemyController, animation controller,
coroutine implementation, clips, prefabs and native observation tools.

SoldierAnimationController.ShootStandNew and GetStandPhase0Length select the preparation delay.
Unlike Corner shooting, this path adds no callback padding. InvokeAfter with a zero delay still
resumes in a later coroutine phase. A subsequent gameplay Update can consume that callback.
The source next-attempt interval is 0.18 seconds with a strict greater-than comparison.

The native start clip length is 0.666671753 seconds. Its serialized stop-time field alone does
not describe the runtime AnimationClip.length and must not be used to derive the callback.

## Native evidence

`gunslinger-stand-unity-reference.json` records two controlled update orders around the original
SoldierAnimationController, four preparations per order and 604 animation-phase rows in total.
Both orders produced these 30 Hz observations:

| Attempt | Preparation | Callback | Next gameplay poll |
| --- | ---: | ---: | ---: |
| 1 | 1 | 22 | 23 |
| 2 | 29 | 30 | 31 |
| 3 | 37 | 38 | 39 |
| 4 | 45 | 46 | 47 |

The cold start queues a fire-loop clone. The next preparation replaces that clone with the
ordinary loop, which starts on the next animation update. Later preparations reset the enabled
ordinary loop. GunslingerFiringClock distinguishes those three cases; it does not assume one
warm-start phase for every attempt. Native callback and poll muzzle poses agree with the existing
recovered Colt-phase rifle muzzle catalog within the test tolerance of 0.00001.

## Validation and limits

Run the source-bound verifier and the focused server test after building the test executable:

```powershell
python -B Server/tools/verify_gunslinger_stand_observation.py --check
dotnet run --project Server/tests/War.Battle.Tests -c Release --no-build -- --gunslinger-stand-only
```

The native exporter runs only in a disposable Unity project. Its probe calls the recovered
animation APIs and coroutine implementation, while explicitly orchestrating four successful
attempts. The JSON field `shots` records the next gameplay polls, not real Gun.Shoot calls.
EnemyController, weapon readiness, projectiles, collisions, interrupted/reversed animations and
failed attempts are not executed by that probe. Unity 2018.3.0f2 observation is not a claim of
original Unity 5.2.5f1 parity or normal Client gameplay validation.

The Release build passes with zero warnings and errors. The focused stand group now passes 56 checks (including both native hide transitions),
and normal Gunslinger navigation still passes all 50 checks across five maps. The complete default
suite and Linux runtime were not rerun for this checkpoint.

The clock is now wired into the [automatic normal-unit shooting path](GUNSLINGER_SHOOTING.md).
The native probe remains animation/coroutine evidence only; actual server projectile proof comes
from the separate ordinary-deployment shooting fixture. Point changes, interrupted/failed
preparations and normal Client presentation remain open.
