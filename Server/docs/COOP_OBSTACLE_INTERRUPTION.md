# Obstacle crawl interruption evidence

The recovered `ShootFromCrawl` keeps a playing begin state, restarts playing
fire, or initializes begin at `1 - Clamp01(crawl.normalizedTime)` before its
0.05-second CrossFade and queued fire. Unlike the corner method, an already
completed crawl must clamp to a zero-time preparation rather than produce a
negative begin clock.

`UnityCoopObstacleInterruptionExport` invokes the actual method on an inactive,
manually wired controller for six crawl fractions: zero, one quarter, one
half, three quarters, one and two. It copies a script-free source hierarchy,
attaches the matching source weapon hierarchy, primes crawl at that fraction,
invokes the source notification, then observes thirteen automatic Animation
frames. It does not run normal AI, controller Update, projectile callbacks or
procedural aiming. The command is issued in the Editor observation phase;
these timings are not yet a gameplay-Update-phase contract.

The source plan hash is checked before playback. A reserialized disposable
prefab fails that check and must be restored from the original Client. Final
artifacts use the original prefab hash; earlier converted-prefab trials are
not their provenance.

## Observed transitions

| Prior crawl fraction | Initial begin fraction | First queued-fire observation |
| --- | --- | --- |
| 0 | 1 | 2 |
| 0.25 | 0.75 | 2 |
| 0.5 | 0.5 | 3 |
| 0.75 | 0.25 | 5 |
| 1 | 0 | 7 |
| 2 | 0 | 7 |

The first two cases show that nominal remaining clip duration alone cannot
select the queue tick: the fade still contributes a transition interval.
Do not copy the existing fresh preparation or corner queue formula into this
branch without its own gameplay-phase source validation.

## Unresolved pose mismatch

The compressed source artifact contains 78 observations with 59 transforms.
The independent fresh-prefab audit samples each observation without prior
animation, using the production sampler and original clip identities. Six
frames exceed the existing position or relative-scale tolerances. The same
six cases fail when the separate replay begins from the primed crawl pose.
This excludes primed initialization as the sole cause, but does not identify
the underlying automatic-evaluation versus manual-sampling difference.

The largest position error is 0.00001745138; the largest relative-scale error
is 0.00006473515. Existing limits remain 0.00001 position, 0.000001 quaternion
dot error and 0.00001 relative scale. Neither verification nor implementation
may normalize away the source states or loosen these limits to close this
feature. The host interruption branch remains unsupported.

```powershell
python Server/tools/verify_coop_obstacle_interruption.py
python Server/tools/verify_coop_obstacle_interruption.py --require-parity
```

The first command validates provenance, reversed phases, queue transitions
and the exact known counterexample. It does not certify pose parity. The
second deliberately exits with failure while the mismatch exists and is the
required promotion gate. Both compressed artifacts retain their own digests.

The server currently resets its obstacle crawl clock before creating a new
windup. Implementation must preserve the preceding animation before that
reset and before clearing old round history, then distinguish retained begin,
fire restart, partial crawl reversal and fresh completed crawl. That data
retention and a verified transition sampler remain future implementation;
no gameplay/collision/admission gate is removed by this research checkpoint.

## Time, initialization and source-sampling controls

`UnityCoopObstacleTimeReplayAudit` reuses the independently verified fresh
prefab comparator with four explicitly diagnostic clocks: recorded float time,
recorded normalized time multiplied by clip length, the preceding float and
the succeeding float. All four retain the same six failing observations.
These adjacent-float trials are hypotheses, not proposed production offsets.

`UnityCoopObstacleOnlyProbe` wires only the recovered obstacle method. The
separate clean exporter intentionally preserves the earlier frozen fixture
implementation while excluding its prior idle/corner initialization. The
78-frame automatic control still has the same six failures. Thus the earlier
corner initialization is not sufficient to explain them.

Two additional clean runs terminate at observation one or two. Only at their
final observation does the exporter invoke the actual source Animation.Sample,
then capture the source again and compare the production sampler. There is
no later observation that this diagnostic could contaminate. All twelve
manual source/replay comparisons have zero reported transform error. Enabled
states, source clocks, weights, speed, wraps and bindings remain unchanged
across that call. The six previously failing automatic observations are all
covered by these controls, and their source transforms change under Sample.

This establishes a difference between automatic evaluation and explicit
sampling at the same observable mixer state in this fixture. It does not
identify Unity's internal cause or establish a replacement automatic pose.
Manual source results must not overwrite the original automatic reference.
The original strict promotion gate still fails; host interruption support,
SDK extension and gameplay-phase callback parity remain unfinished.

The obstacle comparator reports maximum per-axis fractional scale error.
The older general full-rig helper instead used vector scale distance divided
by max(1, source scale magnitude); those scale measures are not interchangeable.
The obstacle limit remains unchanged within these experiments. Independently
of that stricter scale diagnostic, the quarter-return observation at tick one
also exceeds the existing absolute position threshold. This research does not
relax either metric to declare the feature implemented.

The compressed controls artifact preserves the four time variants, clean
automatic baseline and both terminal manual experiments. Validate all controls:

```powershell
python Server/tools/verify_coop_obstacle_interruption_controls.py
```

Native runs use the original source prefab hash. For the clean exporter set
`WAR_OBSTACLE_CLEAN_INTERRUPTION_OUTPUT` to an absolute JSON path. Leave
`WAR_OBSTACLE_CLEAN_MANUAL_SAMPLE` unset for the thirteen-frame baseline; set
it to `1` with `WAR_OBSTACLE_CLEAN_MANUAL_FINAL_TICK=1` or `2` for the two
terminal source Sample controls. No normal controller lifecycle or AI executes.

The [observed-pose candidate](COOP_OBSTACLE_POSE_OVERRIDES.md) preserves all
twelve calibration poses on fresh hierarchies using source position/scale
rows. Identical current mixer states can represent different prior histories,
so host state retention and a complete phase catalog remain required. This
is not implemented interruption transport or a passed clip-only parity gate.
