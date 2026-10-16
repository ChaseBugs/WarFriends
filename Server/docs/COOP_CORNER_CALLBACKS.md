# Corner callback and round muzzle sampling

The recovered `EnemyController` starts corner preparation with
`SoldierAnimationController.ShotFromCover(!mCoverShotRight, 1f, 0.7f, false, Riffle)`.
The animation controller reverses that Boolean into its `CoverSide` selection.
The later shot callback always waits for `uncoverLength + 0.05f`;
`uncoverLength` reads `player_look_right3` even for left-side preparation.
`OnShot` repeats the same side's animation call with a 0.5-second hide delay.

## Native evidence

`UnityCoopCornerCallbackExport.Run` creates two disposable source rigs through
the existing rifle/animation rig factory. It strips online gameplay scripts,
disables native navigation and leaves the real animation controller running.
`UnityCoopCornerCallbackProbe` primes `idle_1` at normalized time 0.5, starts
the actual source preparation in Update, and calls the actual inherited
`Core_BaseScript.InvokeAfter` for the callback.

Both sides resume at relative tick 17 and first poll at tick 18, at 30 Hz and
time scale one. The source delay is 0.5500005 seconds. The callback sees the
queued fire loop at approximately 0.0333333 seconds; the first poll sees
approximately 0.0666667 seconds. The old current-tick editor queue lookup was
one sample later than those actual gameplay transforms.

The probe records the first round at tick 18, applies the actual source
`ShotFromCover` reset, and records the second at tick 29 before resetting again.
This eleven-tick interval comes from the validated host rifle cadence. The
fixture checks that binding with `NextRoundEligibleTick`; it does not execute
the actual Gun or claim native cadence polling proof. At the second round,
the ordinary firing loop is at approximately 0.3333333 seconds. Continuing to
sample elapsed time from the original queued preparation would miss that reset.

The final native process reports `COOP_CORNER_CALLBACK_EXPORT_PASSED sides=2`
without a compiler error or runtime exception. The small raw record is
`content/coop-corner-callback-unity-reference.json`, SHA-256
`f5db29d3cf852d5fde8e53de7d0496f948a7fdb3bd7ba554a03926e9b9374a37`.
It includes hashes of the recovered prefab, rifle, controller, coroutine,
all five animation clips and all three exporting/factory source files.
Those tool-source hashes were checked against the actual workspace files.

## Host integration

`CoopCornerFiringMuzzle` selects the previous sampled frame before the first
round. Once `OnShot` replaces the queued clone, it selects the ordinary fire
clip using that reset's gameplay clock. Current-tick rounds do not change the
pose used to fire them. Subsequent ordinary-loop resets follow the same
source replay rule already observed for obstacle firing. The clock rejects
unknown or crossed side/clip pairs, unordered or future rounds, rounds before
firing preparation, and history beyond the recovered bounded volley capacity.

Both callback aim prediction and emitted corner rounds now use this selector
through `CoopMatchRuntime.CornerMuzzles`. Root placement and existing uncertain
rotation rejection remain in their original runtime paths. This changes local
origin sampling, not combat authority registration or the target selection rule.

`CoopCornerCallbackTests` compares position, rotation and animation time for
each side's real callback, first poll and two round snapshots. It also binds callback timing to
the source right-side uncover length, verifies the host cadence schedule, and
rejects invalid firing clocks. It runs with:

```powershell
dotnet run --project Server/tests/War.Battle.Tests -- --coop-gameplay-query-only
dotnet run --project Server/tests/War.Battle.Tests -- --combat-content-only
```

## Reproduction and remaining scope

Copy `UnityCoopCornerCallbackProbe.cs` into the disposable project's `Assets/`.
Copy `UnityCoopCornerCallbackExport.cs` and the updated
`UnityCoopObstacleVolleyPoseExport.cs` into `Assets/Editor/`. Set
`WAR_COOP_CORNER_CALLBACK_OUTPUT` to a separate absolute JSON path, then launch
Unity 2018.3.0f2 with `-batchmode -nographics -noUpm -projectPath` and
`-executeMethod UnityCoopCornerCallbackExport.Run`. The editor host exits only
after both probes complete; missing callbacks fail after a bounded frame count.

The shared rig creation was extracted without changing the old obstacle Run
setup. Earlier obstacle raw observations retain their historical exporter
source hashes; the new corner record pins the refactored factory hash.
Do not silently regenerate historical raw records with newer tool digests.

This proves local neutral-look, fixed-root geometry at these measured moments.
It does not execute the complete EnemyController, target selection, actual Gun,
network RPCs, root rotation/navigation, native pooled state or Unity 5.2.5.
It does not establish complete corner collider animation or live co-op damage.
The BattleServer feature remains partial until those gameplay paths and normal
Unity/Android integration are implemented and verified.

Windows validation: focused comparisons including native animation time pass.
The full content executable exits zero with 26,368 counted assertions plus
the observation fixtures. Sequential native smoke builds with zero warnings
and errors, passes 1,037 protocol and 74 live MongoDB/HTTP/protobuf/UDP checks,
and verifies evidence persistence across Worker restarts. No new Linux or
normal Unity match execution is claimed by these checks.
