# Co-op obstacle volley pose observation

This is source-bound Unity observation, not a damage-authority implementation.
The co-op Worker registration and unverified collision gates stay closed.

## Why a separate observation exists

`EnemyController.OnShot` calls `SoldierAnimationController.ShootFromCrawl(0.5f,
1f, weaponType)` on every obstacle round. If `rifle_shot_loop` is already playing,
the controller resets its normalized time and plays it again. It also extends
the return-to-crawl deadline. The original queue-only muzzle observation does
not contain these repeated calls or the subsequent return to crawling.

The new host plan is taken from actual isolated runtime round intents: relative
ticks 11 and 22 after preparation, at 30 Hz. It binds the enemy prefab digest,
weapon prefab GUID and source clip names. The capture window ends 60 ticks after
the last round. This is a diagnostic fixture; it is never accepted as a command.

## Observed behavior

`UnityCoopObstacleVolleyPoseExport` retains only the recovered animation
controller on the source enemy/rifle rig. The controller uses normal Play Mode
Update, forced visibility and disabled procedural look. Native NavMeshAgents
are disabled; the root remains stationary. The tool calls the same public
animation method as source OnShot at the recorded host ticks and observes
frames from `EditorApplication.update` without manually sampling each frame.

The 82-frame Unity 2018.3 run records muzzle position and the body box, body
sphere and head sphere centers/rotations relative to the root. Both scheduled
calls reset the fire-loop clock to zero. The next-frame muzzle differs by about
0.049 and 0.042 world units from the prior primed queue-only observation.
A crawl replay is observed from relative tick 37 in this capture. That observed
boundary must not be substituted for a generic server timer without comparing
floating-point time and PlayerLoop phase ordering.

The pinned JSON retains the prefab, controller, clips, exporter and input-plan
digests and sampling phase. The old queue artifacts remain unchanged. New raw
JSON uses explicit CRLF Git rules to preserve its Windows capture bytes; the
exporter's LF rule preserves its recorded source digest across checkouts.

## Reproduce and verify

1. Use a disposable full-asset Unity project; do not upgrade or run this tool in
   the owner's active Client. Copy `Server/tools/UnityCoopObstacleVolleyPoseExport.cs`
   into its `Assets/Editor` folder.
2. Set `WAR_COOP_OBSTACLE_POSE_PLAN` to an absolute output path, then run the
   Battle test executable with `--combat-content-only`. The real runtime fixture
   writes that plan only when this variable is set.
3. Set `WAR_COOP_OBSTACLE_POSE_OUTPUT` to an absolute observation output path.
   Run Unity with `-batchmode -projectPath <copy> -executeMethod
   UnityCoopObstacleVolleyPoseExport.Run -logFile <log>`. Omit `-quit`; the tool
   exits after Play Mode capture. Check both exit code and its export marker.
4. The combat-content suite validates the committed observation's complete
   digest, host-plan digest, recovered rig binding, frame count/time order,
   finite/unit collider data, round resets and observed crawl playback.

The reference is not yet used by `CoopMatchRuntime` for muzzle or hitbox
placement. Still required: align source shot callback/sampling phases; reproduce
per-round resets and crawl return in host pose selection; compare moving roots,
turning and repeated-volley posture in Unity; then prove complete collision and
damage routing. A matching stationary observation alone cannot open those gates.
