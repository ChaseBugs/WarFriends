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
sphere and head sphere centers/rotations relative to the root. Version two also
records actual box size, sphere radius and collider activity. The source head
radius varies slightly during animation, so the blend frame retains measured
dimensions rather than borrowing them from another pose. Both scheduled
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

`CoopObstaclePoseCatalog` now selects diagnostic collider candidates from the
source clip clock plus the measured first blend frame. A complete-crawl start,
stand-up, queued fire, per-round reset and explicitly supplied crawl-return event
reproduce all 82 observed frames. Tests compare 246 colliders after translated
and rotated placement, including centers, orientations, dimensions and activity.
The callback-tick sample uses the previous loop clock because the captured
callback resets time after that frame's transform sample.

`CoopMatchRuntime` now exposes these candidates only after the source stationary
root turn, when the source cooldown guarantees a completed prior crawl. Moving
roots and interrupted crawl remain unavailable. The runtime now emits the
float-timed return event and selects the source crawl clip from that tick.
All Assaulter candidates remain unplaced for collision authority.

Still required: align real gameplay transform-sampling phases;
compare moving roots, turning and repeated-volley posture in
Unity; then prove complete collision and damage routing. Before opening co-op,
include the accepted pose catalog in its authoritative content identity. The
stationary diagnostic reference does not open any of those gates.

## Source float return timer

`CoopObstacleCrawlReturnClock` now isolates the timer semantics in recovered
`SoldierAnimationController.ShootFromCrawl` and `Update`: each round replaces the
single-precision `Time.time + hideAfter` deadline; Update consumes it once only
when scaled time is strictly greater. It accepts explicit scaled float time so
the host cannot silently substitute an integer tick boundary or double sum.
Malformed or backward time and an unrepresentable deadline reject atomically.

The content suite checks exact equality, the next representable float, repeated
round resets, one-shot consumption, and both callback orders when a new round
and expired Update share a frame. Those orders intentionally differ: a shot
before Update postpones return, whereas Update before the shot emits return.
Version three records absolute `Time.time` and the actual private controller
deadline before and after each editor callback. The server timer now matches
both fields exactly across all 82 real Play Mode frames, including both round
resets and the single consumed return event. The observed last deadline is
`1.25333333`; return occurs at `1.25333345` in relative frame 37. The event also
coincides with actual `stand_up_crawl` playback. The initial controller call and
round callbacks occur in the editor callback, after that frame's normal Update;
the comparison replays that recorded ordering explicitly.

## Runtime integration and time origin

Recovered `SoldierAnimationController.cs.meta` specifies execution order `-3`;
`EnemyController.cs.meta` and `SoldierBehaviour.cs.meta` specify `0`. Animation
Update therefore processes return before the enemy's same-frame
`ShootingFromWeapon -> SoldierBehaviour.Shooting -> EnemyController.OnShot`
callback. Preparation calls `ShootFromCrawl(1f)`; each rifle round calls it with
`0.5f`. The runtime now preserves this ordering and these deadlines per enemy.

The self-hosted fixed-step simulation explicitly uses `(float)(tick / 30d)`
seconds from match tick zero. This is reconstruction policy, not recovered
Unity process uptime; it does not force the observed relative frame 37 or a
constant fifteen-tick delay into every volley. Float equality may postpone the
return by one tick. Death, path reset and match cleanup remove the timer state.
New volleys replace it. A shot interrupting an already started return closes
diagnostic pose selection because that blend is not yet reconstructed.

The runtime fixture verifies the first strictly later float time, no early
return, actual crawl-clip selection, repeated-tick stability and retained
unplaced collision status. The 82-frame comparison proves the isolated
controller timer; normal gameplay transform sampling and host/Client clock
synchronization remain separate unverified integration work. Collision
authority stays closed.

## Per-round firing muzzle

The runtime now selects obstacle firing muzzles using the same per-round reset
clock as collider candidates. Previously it sampled only elapsed time since
the initial queue, ignoring later `EnemyController.OnShot` resets. The sample
on a round's own tick still uses the previous reset: `SoldierBehaviour.Shooting`
calls `Shoot` before `controller.OnShot`, and the source transform sample has
already run. Later ticks use that round as the new fire-loop origin.

`CoopObstaclePoseCatalog.FiringMuzzle` reuses the existing recovered rifle muzzle
clip catalog. It exposes only firing frames; preparation, crawl return and
interrupted returns cannot supply a firing origin. The complete 82-frame Unity
reference checks muzzle availability and every available local position within
0.00002 world units, including both resets. The runtime fixture independently
checks each later emitted round's clip seconds against its previous round.
Corner firing retains its separate queue path. These are diagnostic origins;
moving-root parity and complete authoritative collision remain unverified.

The subsequent [native moving-root probe](COOP_OBSTACLE_ROOT_TURNS.md) proves
that navigation can overwrite the completed firing tween. Windups started
during movement therefore retain an explicit uncertain-root marker, including
after movement stops; fixed-root world origins and collider candidates remain
unavailable for that volley. Local firing-clock samples remain diagnostic.
