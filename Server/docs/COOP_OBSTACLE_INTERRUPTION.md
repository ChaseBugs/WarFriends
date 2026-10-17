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
