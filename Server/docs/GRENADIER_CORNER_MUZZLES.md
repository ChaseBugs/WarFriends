# Grenadier native corner firing muzzles

The pistol launch now uses observed firing-time transforms instead of the exported resting rig.
The first primary shot also waits 22 ticks after preparation, matching the native callback's
following gameplay poll. Grenade timing is unchanged by this primary-specific correction.

## Native observation

`UnityGrenadierCornerCallbackExport` creates two disposable enemy rigs with the actual PistolEnemy
prefab attached at the recovered right-hand gun snap. It strips unrelated gameplay components and
runs the actual `SoldierAnimationController` and `Core_BaseScript.InvokeAfter` callback in Play Mode.
The probe begins in `pistol_idle`, prepares the appropriate side, waits the source's fixed 0.7
seconds and records five rounds spaced by the source 11-tick pistol cadence. Each round samples
the muzzle before replaying the normal source `ShotFromCover` call.

Unity 2018.3.0f2 observed callback tick 21 and first gameplay-ready tick 22 on both sides.
Round ticks were 22, 33, 44, 55 and 66. The first source-local muzzle positions were:

| Side | X | Y | Z |
| --- | ---: | ---: | ---: |
| Left | -0.2848303 | 0.3322548 | -0.175443023 |
| Right | 0.278049 | 0.3461129 | -0.1436967 |

`content/grenadier-corner-muzzle-unity-reference.json` retains the complete observation, including
callback/round animation states, rotations, Unity version and source/tool digests. Its SHA-256 is
`40c8b684f6685f8b0618998e1bf367f6593a493113ed83b0ffc4c517b917d2b7`.
The observed enemy/pistol/controller files match the active Client byte-for-byte. Probe, exporter,
rig-factory and coroutine digests are also checked by the focused tests.

To reproduce, copy the two Grenadier probe/exporter files into a disposable Client project at
`Assets/UnityGrenadierCornerCallbackProbe.cs` and `Assets/Editor/UnityGrenadierCornerCallbackExport.cs`.
It also needs the existing `UnityCoopObstacleVolleyPoseExport` rig factory. Set
`WAR_GRENADIER_CORNER_CALLBACK_OUTPUT` to an output JSON path and invoke
`UnityGrenadierCornerCallbackExport.Run` through the Unity Editor's `-executeMethod` argument.
Do not use `-quit`: the exporter exits after its bounded Play Mode observation. Archive the output
with UTF-8/LF JSON; runtime digest updates require reviewing the new observation.

## Host binding and verification

`GrenadierCornerMuzzleCatalog` validates the embedded observation digest, clock, both sides and
five-round sequence before publishing private samples. It selects the actual corner side and
round index, then applies the source `PrepareToShoot` facing-away rotation at the soldier's current
position. Unknown rounds and non-exposable corners reject. The old resting-world placement method
was removed to prevent accidental reuse as firing authority; the resting value remains provenance.

The primary scheduler uses the observed 22-tick delay. Its old 21-tick windup advanced immediately
in the preparation update and emitted one tick earlier than the native gameplay poll. A host test
now captures the actual preparation tick and checks the emitted shot against the observed delay.

Release build passes without warnings/errors. Focused verification covers all ten native samples
at their original and rotated/transformed placements, invalid rounds/poses, seven source digests,
primary weapon fields and cosmetic flight. The combat suite passes 26,395 assertions, including
the source-relative first-shot timing, actual launch, immutable airborne damage, death and collision.
The complete default suite was not rerun.

## Limits and next work

The existing Park fixture still collides with terrain: player and shield damage are both zero,
with captured raw launch damage 38.18407. That negative observation is retained explicitly.
It does not verify victim damage, friendly exclusions or overtime damage coefficients. A dedicated
exposed-target fixture was required. The subsequent [damage fixture](GRENADIER_PRIMARY_DAMAGE.md)
now proves shield destruction and normal/overtime/Sickness player health changes through actual
host collisions; explicit in-ray friendly and moving-target proof remains open.

This observes the source animation controller and callback, not a normal complete EnemyController
battle, warm-state reuse, authenticated UDP or Client rendering. It uses the available Unity 2018
observation environment; original Unity 5.2.5f1 and Android equivalence remain unverified. Automatic
Sickness lifecycle and authorized Client card use are separate incomplete work.
