# Helicopter rope physical connection boundary

The host now prepares the local frames needed to attach the source rope to its aircraft
and connect its generated bodies. A managed stationary-aircraft solver prototype now exercises
those constraints; it is not a completed co-op collision world. Source initialization and extension
evidence remains in [HELICOPTER_ROPE_ALIGNMENT.md](HELICOPTER_ROPE_ALIGNMENT.md).

## Active anchors differ from inactive inspection

`UnityHelicopterRopeExtensionExport.RunPhysics` uses the original recovered Helicopter
prefab in a disposable Play Mode project. The companion `UnityHelicopterRopePhysicsCapture`
removes gameplay scripts while the prefab is inactive, makes the aircraft kinematic as
the source does at instantiation, then activates the original QuickRope2 initialization.
It disables subsequent rope updates and automatic simulation. A later frame permits
source-deferred ConfigurableJoint destruction to finish before capture; each chain body
then has exactly one connection, except the terminal body, which has none.

Inactive bodies in the earlier initialization reference exposed zero connected anchors.
Active source bodies instead realize automatic anchors approximately 0.35 units along
the next body's local Z axis. The identity fixture's first chain anchor is
`(0, -2.98023224E-08, 0.350023955)`. The aircraft FixedJoint connected anchor is
`(0.372559547, 0.331, -0.009)`. A solver must not reuse the inactive zeros as effective
physical connection frames: doing so would connect body origins instead of preserving
the initial spacing.
Prepare these frames at constraint creation. Recomputing them from deformed poses
on every physics step would erase the original rest geometry.

## Prepared host frames

`HelicopterRopeConstraintFrames.Create` snapshots and validates all initial body poses,
mass/damping, angular stops, sequential link identities and the measured first distance.
Malformed, cyclic, retargeted or reordered links fail before it returns a constraint plan.
The result owns a read-only link sequence; no native body is modified by preparation.

For the original unit-scale bodies, the source local anchor is zero. The connected
local position is the inverse connected-body rotation applied to the difference between
the two world origins. The aircraft attachment uses the same calculation with a reserved
external aircraft-body index. Returned chain indexes remain bound to their source order.

Chain connected rest orientations derive from the two initial body rotations, aligning
their world frames. The aircraft attachment is different: its FixedJoint exists before
QuickRope2 changes the root rotation. Capture records `attachmentConnectedRestRotation`
at that creation boundary. `Create` requires this quaternion as its third argument.
Deriving it from the post-initialization root silently erases the tilted fixture's initial
angular error. The fixture records the creation-time relative rotation, not internal PhysX
joint-frame fields. Non-unit scale is outside this preparation contract.

## Native diagnostic motion

The reference records three initial rope/aircraft poses, nine ConfigurableJoint anchors
and three aircraft FixedJoint attachments. It then calls real `Physics.Simulate` ten
times at 0.02 seconds, recording body positions, rotations, velocities and physical
settings. There are no extension commands, moving aircraft, gameplay updates or map
collisions in this fixture. These 0.2-second motion samples are diagnostic evidence for
solver work. The managed trajectory tests compare the two non-tilted fixtures fully;
the tilted transient remains diagnostic beyond its first position/velocity/rotation sample.

Observed settings include gravity `(0, -9.81, 0)`, one solver iteration and one velocity
iteration, automatic transform synchronization, zero body COM, unit inertia tensor,
maximum angular velocity 7 and sleep threshold 0.005. The active Client's exported
DynamicsManager also specifies gravity -9.81 and one solver iteration; TimeManager
specifies the 0.02-second fixed timestep. Unity 2018 observations do not establish
original Unity 5.2 native physics equivalence.

The prefab and QuickRope2 SHA-256 values are recorded in
`recovered-helicopter-rope-physics-unity-reference.json`. Its normalized-LF digest is
`e87743347ee3fa3d7cb75ced89ab8e4d756e853b86e9751c77e3ec421ac4fc11`.
The final Unity process exits zero with no logged exceptions at
`.local/helicopter-rope-physics-rest-creation.log`. The active Client was not modified.

## Managed dynamics prototype

`HelicopterRopeSimulation` advances an isolated unit-mass/unit-inertia chain with gravity,
linear/angular damping, locked linear constraints, fixed attachment, and twist/swing stops.
It prepares rows, solves biased position constraints, integrates poses, and solves unbiased
velocity constraints. Equalities use mass-weighted row preprocessing. Each step works on
private body copies and publishes only after all states validate; older snapshots remain unchanged.
The implementation is limited to the recovered circular cone, stationary kinematic aircraft,
and the fixed 0.02-second timestep. It has no map collision or sleeping implementation.

Jacobian and solver research uses the pinned NVIDIA PhysX 3.4 source, particularly
`ExtConstraintHelper.h`, `ExtFixedJointSolverPrep.cpp`, and `DyConstraintSetup.cpp`.
See [the official source](https://github.com/NVIDIAGameWorks/PhysX-3.4) and the distributed
BSD attribution in `THIRD_PARTY_NOTICES/PhysX.txt`. This is not a claim that Unity uses
the same unmodified SDK revision or that the translated solver is equivalent.

Across eighty body-step records in the identity/yaw fixtures, position, velocity,
sign-invariant quaternion-component distance, and angular velocity each differ by less
than 0.00002 from the captured Unity samples. The tilted fixture approaches a 180-degree
attachment correction; small numerical differences amplify. Its maximum managed position
error is about 0.016876, quaternion-component distance 1.385353, and angular-velocity error
41.102715. Finite diagnostic output is not trajectory acceptance. Angular-stop stress
response also remains unverified. No tolerance was widened to declare the tilted case passing.

## Native SDK research

`tools/BuildPhysXReference.ps1` builds pinned revision
`5e42a5f112351a223c19c17bb331e6c55037b8eb` locally and compiles
`tools/NativeRopeProbe.cpp`. The Windows script completed successfully with VS 2022;
its upstream build retains compiler warnings. No native SDK binaries are committed or
loaded by the Worker. `tools/CompareNativeRopeProbe.py` rejects duplicate, missing,
unknown, and non-finite rows before reporting all 120 body-step differences.

The Windows native probe's tilted maximum position error is about 0.000197, velocity
error 0.002409, quaternion-component distance 0.036355, and angular-velocity error
3.444836. This improves the diagnostic but does not prove parity or live integration.
Actual Ubuntu WSL SDK/probe builds and execution also pass. The Linux tilted maxima
are position 0.000664, velocity 0.016601, quaternion-component distance 0.075185, and
angular velocity 3.727501. The different Windows/Linux transients rule out a numerical
parity claim even for this shared SDK. Evidence is `.local/physx-sdk-linux-build-const.log`,
`.local/native-rope-probe-linux-build.log`, and `.local/rope-native-linux-comparison.json`.
Linux compatibility changes correct a const return type and keep compiler warnings;
the probe uses a non-constexpr SDK pi constant to satisfy both compilers. No physics
equations were changed. A deliberate native bridge is now implemented below; no Worker
registration or live gameplay acceptance exists yet.

## Native host adapter

`NativeHelicopterRope` now owns an isolated native scene through `WarRopePhysics` C ABI
version 4. It validates and snapshots the source initialization, preserves the attachment's
creation-time rest rotation, advances one selected 0.02/0.004-second step, and returns copied
body snapshots. A SafeHandle releases joints, actors and scene. Scene operations and disposal
are synchronized; stale native registry identities are never reused. The explicit adapter
limits are 64 simultaneous ropes and 128 bodies per rope. Unsupported source settings and
capacity overflow reject rather than selecting a different solver or truncating a chain.

SDK errors latch runtime failure; a failed managed operation cannot retry unproven native
state as though simulation rolled back. No RPC, HTTP endpoint or battle command exposes
the C ABI buffers. The ordinary Worker does not load or select this adapter yet.
See [the native ownership/ABI contract](../native/WarRopePhysics/README.md).

The separate `--native-helicopter-rope-only` mode exercises the actual .NET/native boundary,
not the CLI probe. Identity/yaw trajectories use the same 0.00002 comparison threshold;
the tilted transient remains diagnostic. It also checks independent scenes, retained
snapshots, repeated disposal, access after disposal, capacity rejection and reallocation,
malformed input, unknown handles, and the ABI version. This mode requires native libraries;
it never silently skips an unavailable adapter. Platform results are recorded after actual
execution, separately from cross-publishing and from normal Unity match acceptance.

The initial stationary Windows and Ubuntu WSL .NET/native checkpoint passed 466 checks each. Adapter maximum
position errors are about 0.00000043 (identity), 0.00000095 (yaw), and 0.000496 (tilted)
on each platform. The adapter starts from host-generated initial poses in one scene per
rope; the CLI probe starts from recorded poses with three ropes sharing a scene. Their
near-singular tilted diagnostics therefore are not interchangeable or parity thresholds.
Logs are `.local/rope-native-adapter-windows.log` and `.local/rope-native-adapter-linux.log`.
The latter executes `.local/linux-native-rope-adapter/War.Battle.Tests` with the real
Linux shared library. Flight/extension, full collision geometry and live combat are unverified.

## Aircraft Transform inheritance

`Helicopter.Update` directly changes position and rotation after its rope-extension branch;
it does not call Rigidbody MovePosition/MoveRotation. QuickRope2 creates intermediate bodies
without a Transform parent in Play Mode. The original root and ropeEnd retain aircraft
ancestry. A new stripped Unity capture confirms `[true, false, false, true]` for all three
fixtures. Each of ten samples writes aircraft translation `(0.04, 0.01, -0.02)` and a
three-degree world yaw, synchronizes transforms, captures before simulation, then simulates
one 0.02-second step and captures after. This synthetic input tests the source setter path;
it is not a normal waypoint-flight acceptance run.

`recovered-helicopter-rope-motion-unity-reference.json` has normalized-LF SHA-256
`83f71afc33e30d9b632578afa2023d65ad93de40393cc9bc1d0f230b0486d376`.
The owned Unity process exits zero at `.local/rope-aircraft-motion-unity.log`, with
`PASS: recovered moving-aircraft rope frames=10`. The active Client was not modified.
Reproduce with `WAR_ROPE_CAPTURE_MOTION=1`, a distinct `WAR_ROPE_PHYSICS_OUTPUT`,
and `UnityHelicopterRopeExtensionExport.RunPhysics` in the disposable project.

`ApplyAircraftTransform`/`war_rope_set_aircraft_transform` applies those parent changes
without advancing physics. It transforms root/end through the old aircraft-local frame
into the new world frame, leaving middle bodies and all existing velocities unchanged.
It uses direct global-pose writes, not a kinematic target that would invent velocity.
Invalid inputs reject before SDK mutation. Flight scheduling must still preserve the
source's render-update/physics-update ordering rather than issuing one extension per fixed step.

Windows moving identity/yaw positions and rotations pass the existing 0.00002 comparison
threshold across before/after captures. Their maximum position differences are about
0.00000045 and 0.00000145. Accumulated yaw-fixture velocity differs by up to 0.00002466,
so later speed comparisons are explicitly diagnostic; initial physical steps still assert
the original threshold. The tilted transient remains substantially different: maximum
position difference about 0.4081, quaternion-component distance 0.5286, velocity 5.9934,
and angular velocity 16.3039. Finite output is not tilted-trajectory acceptance. No live
crew, landing, collision, or Worker integration is established by this new setter.

The aircraft-motion checkpoint passed 1,131 checks on Windows and actual Ubuntu WSL:
467 stationary/ownership checks and 664 motion/validation checks. The new guards also
reject NaN positions, zero/non-unit rotations and access after disposal, while retaining
unchanged physics time and snapshots after rejected input. Linux normal/yaw position
differences remain below 0.0000015; its tilted maximum position difference is about
0.3997, with quaternion-component distance 0.5162 and angular-velocity difference 15.9757.
These substantial tilted differences remain an open fidelity issue, not a passing trajectory.
Evidence is `.local/rope-native-motion-windows.log`, `.local/rope-native-motion-linux.log`,
and the zero-warning/error build at `.local/rope-native-motion-dotnet.log`.

## Physical extension and insertion

The adapter now connects the previously verified `HelicopterRopeExtension` geometry to
real bodies and constraints. `Extend(deltaTime)` is a render-update command; it does not
advance the physical clock. It uses the initialization's measured spacing, moves the
first body, inserts at most one body after the strict 1.5-spacing threshold, and reconnects
the original root constraint. Body count changes publish only after successful native
application; capacity exhaustion and malformed time reject without changing the scene.

The original `QuickRope2.ExtendRope` disconnects `connectedBody`, temporarily makes the
old first body kinematic, moves it, restores dynamic state, and reconnects the same joint.
Destroying/replacing that root joint changed native solver ordering and failed the source
comparison. Retaining its identity and changing actors/local connected frame resolves
that positional difference. The temporary kinematic transition resets both velocities,
even when delta time is zero. A new body receives default Rigidbody drag zero; the source
does not apply the initial chain's 0.2 drag to inserted objects.

The new capture runs eighteen original commands at captured `deltaTime=0.0333333351`,
each followed by a manual 0.02-second physics step. It records before-command,
after-command and after-physics states, plus body mass/drag/gravity/kinematic settings.
All three fixtures insert their first new body on command nine and end with five bodies.
The capture is a controlled source command/physics sequence, not normal waypoint flight.

`recovered-helicopter-rope-extension-physics-unity-reference.json` has normalized-LF digest
`afad253ab565ae80c3add9d230dbe160615bf0f8a46ebc59ef5a61ec7d9eb97a`.
The owned Unity process exits zero at `.local/rope-extension-physics-unity.log`.
Use `WAR_ROPE_CAPTURE_EXTENSION=1` and a distinct `WAR_ROPE_PHYSICS_OUTPUT` with
`UnityHelicopterRopeExtensionExport.RunPhysics` in the disposable project to reproduce.

Command and solved positions in all three Windows cases match within 0.00002, with
maximum solved position differences about 0.0000011. Solved linear velocities in all
three cases and identity/yaw rotations/angular velocities match that threshold too.
The tilted quaternion-component difference reaches 0.16747, so tilted
rotations and angular velocities remain diagnostic. The pre-existing moving-aircraft
tilted discrepancy is not resolved by this stationary-aircraft extension fixture.
Worker activation, complete flight/render/physics scheduling, map collisions, crew
attachment, descent and landing remain required.

The physical-extension checkpoint passed 2,707 checks on both Windows and actual Ubuntu WSL:
468 initial/ownership, 664 aircraft-transform and 1,575 extension/capacity checks.
It verifies source commands and solved positions, one insertion on command nine,
velocity reset, malformed delta rejection, access after disposal, zero-delta behavior,
and rejection at the explicit 128-body cap without consuming a physical step or changing
the retained scene. Capacity is adapter policy, not a recovered maximum rope length.
Windows and Linux maximum solved extension position errors stay below 0.0000011;
Linux tilted rotation difference remains about 0.16747. Logs are
`.local/rope-native-extension-windows.log` and `.local/rope-native-extension-linux.log`.
The Linux run executes the self-contained publish in `.local/linux-native-rope-extension`
with the actual ABI 3 shared library. `.local/rope-native-extension-dotnet.log` records
the full solution build with zero warnings/errors. This is not a normal Client match,
native mobile build, complete collision world or Mongo settlement proof.

## Combined render gate and aircraft movement

`BeginExtension` and `UpdateRenderFrame` now model the recovered render branch together.
The height comparison uses the current ropeEnd before changing the aircraft Transform;
extension runs first. Once the end reaches its target, the extension gate stays disabled
until an explicit source-equivalent ShowRope request arms it again. Malformed delta,
aircraft pose or target height rejects before consuming extension state or either clock.
RenderFrameCount and the existing fixed StepCount stay separate. Access after disposal
rejects for the new methods and gate property too.

The combined fixture drives the source height branch, original QuickRope2.ExtendRope,
synthetic aircraft translation/yaw, and one manual physics step, eighteen times.
It records the initial source states, target heights, and before/render/after samples.
Identity inserts on render frames seven and sixteen; the tilted fixture inserts on nine
and eighteen. The yaw fixture starts with an already-reached height, disables extension
on its first update, and keeps four bodies while its aircraft moves. This differs from
the stationary extension fixture's insertion on command nine and proves that composing
the two operations is not interchangeable with applying aircraft motion first.

`recovered-helicopter-rope-combined-unity-reference.json` has normalized-LF SHA-256
`10917a8c2672f3b238dc31a14167f2519283b8aaea171d0b7b8ee1370534e0ba`.
Its Helicopter.cs hash matches the active recovered Client. The Unity capture exits zero
at `.local/rope-combined-unity.log`. Reproduce using `WAR_ROPE_CAPTURE_COMBINED=1`,
a distinct `WAR_ROPE_PHYSICS_OUTPUT`, and the existing RunPhysics editor entry point.
The stripped fixture drives the recovered branch explicitly; it does not invoke the full
Helicopter.Update/base Update stack, derive waypoint poses, perform NavMesh sampling,
or prove Unity's automatic render/fixed scheduling. The active Client was not changed.

The combined-render checkpoint passed 4,192 checks on Windows and actual Ubuntu WSL: 471 initial/ownership,
664 aircraft motion, 1,575 physical extension and 1,482 combined render-order checks.
Combined source topology, gate state and positions pass on all three fixtures, and
identity/yaw rotations pass, at the existing 0.00002 threshold. Maximum combined position
differences stay below 0.0000018 on both platforms. Velocities remain diagnostic for this
combined fixture; the tilted quaternion-component difference reaches about 0.15236 on
Windows and 0.14930 on Linux. The earlier no-extension tilted-motion discrepancy remains
open. Do not treat these position results as a complete tilted trajectory or landing proof.

Evidence is `.local/rope-native-render-windows.log`, `.local/rope-native-render-linux.log`,
and the zero-warning/error solution build at `.local/rope-native-render-build.log`.
The Linux run executes the self-contained output at `.local/linux-native-rope-render`.
Normal flight scheduling, signed content, map collision, current crew/palm attachment,
descent, landing and live Worker/Client integration remain required.

## Source normal/ragdoll physics mode

Further timing inspection found a real missing mode in the former fixed-20ms adapter.
`PlayerController` calls `TimeManager.SetupPhysicsTiming(true)` when activating ragdoll.
`GameControllerCoop` and TimeManager cleanup restore false. The method selects 0.004
seconds for ragdoll or the default cached in Awake. The active recovered
`ProjectSettings/TimeManager.asset` specifies 0.02 seconds. A scan of the active gameplay
and firstpass sources finds no other fixedDeltaTime assignment outside this method.

`HelicopterPhysicsTiming` now defines those two explicit modes. Selection does not
advance time or change body state. Native `war_rope_step` accepts the exact selected
float quantum; malformed/unsupported values reject before simulation. ABI 4 prevents
loading the old one-argument step signature. The checked nominal-millisecond counter
publishes together with StepCount only after successful simulation, independently of
RenderFrameCount. This adds mode support, not automatic global lifecycle fan-out.

The capture invokes the original TimeManager method on an inactive component, seeding
only the cached default normally assigned by Awake. It avoids Photon/base-manager
startup, then performs twelve native physics calls through normal/ragdoll/normal/ragdoll
transitions totaling 96 nominal milliseconds. No full player-death or ragdoll-body
simulation is implied. `recovered-helicopter-rope-timing-unity-reference.json` has
normalized-LF digest `bbb4eaa63fc13b2a51f4a6d7228805d267f050c9400d2e0b2aba1666fb10d8d7`.
Its TimeManager.cs digest matches the active Client. The owned corrected Unity process
exits zero at `.local/rope-timing-unity.log` with twelve captured timing steps.

The initial disposable project retained a 1/30-second profile from earlier probes.
That unsuitable capture was rejected and kept only under `.local/rope-timing-stale-profile-*`.
For the accepted run, the active TimeManager.asset bytes were copied into the disposable
project before startup, then the disposable's prior bytes were restored after the owned
Editor exited. The active Client was not changed. Timing capture now explicitly rejects
a non-20ms default instead of silently treating the stale profile as source authority.
Reproduction uses `WAR_ROPE_CAPTURE_TIMING=1`, a distinct `WAR_ROPE_PHYSICS_OUTPUT`,
the existing RunPhysics entry point, and an isolated project with the active 20ms profile.

Windows identity/yaw timing poses pass the existing 0.00002 comparison threshold.
Speeds and the tilted transient remain diagnostic: the tilted maximum position error
is about 0.000100, quaternion-component distance 0.15497, and angular-velocity difference
67.01471. Mixed-step support does not resolve the earlier tilted-motion fidelity gap.
Automatic render/fixed scheduling, pause/time-scale handling, global ragdoll-mode fan-out,
crew/landing and normal gameplay acceptance remain pending.

The timing-mode checkpoint passed 4,796 checks on Windows and actual Ubuntu WSL:
472 initial/ownership, 664 aircraft motion, 1,575 extension, 1,482 render-order,
and 603 timing-mode checks. The new checks prove mode persistence, rejection of
unknown modes, restoration to normal timing, unchanged bodies during mode selection,
96 nominal milliseconds across twelve mixed steps, independent render time, and
rejection of unsupported raw ABI intervals. Identity/yaw mixed-step position and
rotation comparisons use the unchanged 0.00002 threshold on both platforms.
Linux tilted diagnostics remain substantial: quaternion-component difference about
0.15497 and angular-velocity difference 67.01344. They are not trajectory acceptance.
Evidence is `.local/rope-native-timing-windows.log`, `.local/rope-native-timing-linux.log`,
and the zero-warning/error solution build at `.local/rope-native-timing-dotnet.log`.
The Linux evidence runs `.local/linux-native-rope-timing/War.Battle.Tests` with the
actual ABI 4 shared library; cross-publishing alone is not the claimed proof.

## Actual automatic fixed/render ordering

`UnityHelicopterClockExport` now captures actual Unity FixedUpdate and Update callbacks
without calling Physics.Simulate. Install the exporter under the disposable project's
Assets/Editor and `UnityHelicopterClockRecorder` outside Editor so it can be attached.
The recorder uses capture rate 30, automatic physics, the active 20ms profile and original
inactive TimeManager mode selection. Thirty render updates switch ragdoll on at six and
eighteen, and restore normal timing at twelve and twenty-four. A second fixture sets
Time.timeScale to zero at update four and restores one at update seven. This directly
tests Unity's scaled-time loop, not the full network FreezeGame callback or TimeTweener.

The normal trace contains 130 fixed callbacks before thirty render callbacks, totaling
1,000 nominal milliseconds. The pause trace has 121 fixed callbacks and thirty render
callbacks, totaling 900 nominal milliseconds. In the paused trace, lowering the step
from 20ms to 4ms leaves enough owed time for three fixed callbacks on the next zero-delta
render frame. Therefore a paused render delta must not discard existing physical debt.
All callbacks in each captured frame precede its render callback; the post-render mode
change affects the following frame's physical work.

Normalized-LF capture identities:

- `recovered-helicopter-clock-unity-reference.json`:
  `3f71e40e662eea6051dd5ebe3f0993df2b673dce415bd99f06b95a5b28fe5c8f`.
- `recovered-helicopter-clock-pause-unity-reference.json`:
  `3c16d9cb90eb2bd67064cc690279b0759a938b7921135812b340fb9f931871d4`.

Both owned Unity runs exit zero at `.local/rope-clock-unity.log` and
`.local/rope-clock-pause-unity.log`. The inactive timing component does not start
Photon/base-manager lifecycle. Active Client files remain unchanged; the disposable
profile is temporarily aligned and restored afterward. The exporter now fails if the
recorder cannot attach and has a bounded completion deadline instead of hanging.
Reproduce with `WAR_ROPE_CLOCK_OUTPUT`, optional `WAR_ROPE_CLOCK_PAUSE=1`, and
`UnityHelicopterClockExport.Run`; use a fresh process and the active TimeManager profile.

The new match-owned `HelicopterPhysicsFrameClock` preserves a double remainder, uses
the source float quanta directly, and performs no epsilon rounding, debt reset or
one-render/one-physical-step substitution. A phase guard requires physics to drain
before rendering and prevents overlapping frames. Its input bound comes from the
active 0.2-second Maximum Allowed Timestep; this is not a hitch-behavior proof. Unknown
modes and malformed frame time reject before state mutation. Fault is terminal so a
failed world cannot replay consumed physical work as if it rolled back.

The native runner also replays both traces into an actual native scene, checking each
quantum's mode, delta, sequence and render boundary against the original callback tape.
It verifies physical/render counters and nominal milliseconds against the SDK adapter.
This is source-backed scheduling plus native execution evidence, not normal Client
gameplay, collision-time mode switching or full match restart/phase-alignment acceptance.
Global Worker fan-out, flight inputs, collision shapes, crew, descent and landing remain
required; the known tilted-physics differences remain open.

The expanded native runner passes 5,891 checks on both Windows and actual Ubuntu WSL,
including 1,095 frame-clock/trace checks. Tests cover both actual callback tapes, native
execution counts, preserved zero-delta debt, invalid input rejection, overlapping frames,
premature rendering and terminal fault behavior. The full solution builds with zero
warnings/errors at `.local/rope-frame-clock-build.log`. Platform evidence is
`.local/rope-frame-clock-windows.log` and `.local/rope-frame-clock-linux.log`; the Linux
run executes the self-contained publish in `.local/linux-rope-frame-clock` with ABI 4.
No source or native body-trajectory differences were hidden or relaxed by these clock checks.

## Verification and remaining work

The focused `--helicopter-rope-initialization-only` runner now passes 1,111 checks:
541 initialization/extension, 85 frame guards, and 485 dynamics checks. Frame tests
compare twelve active anchors, chain world coincidence, creation-time attachment rest
rotation, ownership, and malformed setup rejection. Frame position tolerance is 0.000003
and quaternion tolerance 0.00001. The latest .NET solution build has zero warnings/errors;
protocol tests pass 1,360 checks. The focused evidence is `.local/rope-simulation-focused.log`.
The previous frame-only Windows combat-content group exited zero with 27,573 assertions at
`.local/helicopter-rope-frames-host.log`. Existing native physics/navigation
diagnostics retain their documented differences; this is not a normal match proof.
The self-contained executable at `.local/linux-rope-frames` passes the same group
under Ubuntu WSL with 27,573 assertions, exiting zero at
`.local/helicopter-rope-frames-linux.log`. No full Battle executable or Mongo
smoke run is claimed for this geometry-only server change.

The newer dynamics checkpoint passes the complete combat-content group on both Windows
and actual Ubuntu WSL with 28,059 assertions per run. Logs are
`.local/rope-simulation-host.log` and `.local/rope-simulation-linux.log`; the latter runs
the self-contained executable in `.local/linux-rope-simulation`. Existing navigation
and native-physics diagnostic differences remain visible. These are bounded content/
simulation checks, not full BattleServer, normal Unity match, or Mongo smoke acceptance.

Native probe reproduction commands and prerequisites are documented in
[NativeRopeProbe/README.md](../tools/NativeRopeProbe/README.md).

Still required: select and integrate a validated physical adapter; match force/damping,
angular limits and iterative solving against native motion; couple aircraft motion and
extension with the physical timestep; bind signed content and current crew poses; then
verify descent, NavMesh landing and live co-op combat through the normal Unity Client.
No Worker registration, live co-op Fire, Mongo settlement or normal match acceptance
is established by these frame tests.

## Shared native world failure acceptance — 2026-10-19

`NativeHelicopterPhysicsWorld` owns one clock and generation-bound rope members.
The native-world test advances physics for two ropes, renders the first member,
then submits a bounded aircraft pose whose inherited rope root exceeds the native
coordinate limit. The actual native transform call rejects this derived pose.
The test requires the native failure exception, rather than accepting any rejection
from preflight as evidence of partial-frame cleanup.

After failure, snapshot publication, replaying the frame, adding a member and arming
extension are rejected. A previously returned snapshot remains unchanged. Before
disposing the failed managed owner, a replacement world fills all 64 process-wide
native registry slots; this proves failed-world cleanup released both native scenes.
Disposal of the failed owner remains idempotent. No fake physics callback or
test-only production failure switch is used.

Windows and actual Ubuntu WSL native validation each pass 5,916 checks in
`.local/native-world-failure-windows.log` and `.local/native-world-failure-linux.log`.
This covers a native derived-transform rejection after partial frame execution,
not every SDK failure or operating-system allocation failure. Worker ownership,
shared collision scenes, flight, crew descent and landing remain open.

## Flight and arrival frame composition — 2026-10-20

`HelicopterFlightRopeFrameTests` drives a braking flight near its stop, source
orientation, and the native world for twelve render frames, including three paused
frames. An independent native rope receives explicit fixed steps, render extension,
aircraft pose and then arrival activation in recovered callback order. Every body
snapshot, physics/render count and extension flag must agree after each frame.
The arrival callback fires once. An arrival input arms extension after the current
rope render branch so extension starts on the next frame. Non-finite or out-of-bound
arrival targets reject before any frame mutation.

Zero scaled delta is accepted by orientation and preserves its prior pose before
the bank formula divides by delta. Source interpolation factors are zero and its
invalid bank quaternion has a guard; no paused orientation is inferred from an
infinite bank angle. Full Unity flight/pause capture is still required to establish
rendered fidelity. The composition uses an explicit test landing height, not a
recovered NavMesh sample. Worker registration and real landing remain pending.

## Landing query reconstruction — 2026-10-20

`HelicopterRopeLanding` reconstructs the query position in `ShowRope` from the
trusted pre-flight rope origin and current player's selected point. A downward
ray intersects the horizontal plane only if the player point is below the rope;
otherwise the source origin is retained. The nearest surface query uses radius
ten. Army and co-op catalogs reject all nonzero areas, so their mesh queries
match the source's area mask one without accepting unrelated areas.

Tests use the existing triangle nearest-point implementation on two stacked
surfaces. They check floor selection after projection, the no-forward-intersection
case, absent surfaces, and invalid origins. This is host geometry evidence, not
Unity `NavMesh.SamplePosition` equivalence on baked source maps. The original
method ignores SamplePosition's Boolean result and uses `hit.position`; its
failure output is recorded in the later Unity capture below. The host currently returns
null on no surface, explicitly leaving that compatibility path unresolved.
No Worker landing or crew spawn authority is enabled by this helper.

### Actual Unity landing capture

`UnityHelicopterLandingExport.Run` runs only in a disposable project. It executes
the Plane/Ray/SamplePosition operations from ShowRope in an empty scene, first
without navigation, then with each of the five original co-op navigation assets.
It does not invoke the Photon-coupled ShowRope method itself. The capture at
`content/recovered-helicopter-landing-unity-reference.json` has normalized-LF SHA-256
`221ab86577105cc0c76a8046d688aa73898669ea59b8ae9b1c269dec04b48ff2`.
Unity 2018.3.0f2 exited zero (`.local/rope-landing-unity.log`). This is not original
Unity 5.2.5 fidelity or a rendered game test.

The failed empty-mesh query returns `(Infinity, Infinity, Infinity)`. Source code
then arms ShowRope, but its next render's height comparison is false and disables
extension. The host surface query returns null; the later native-world input below
represents this cancellation at the same callback boundary. Worker wiring remains pending.

All 25 projected surface queries agree with host geometry within 0.002 units.
Of 25 non-projected queries, seven agree and eighteen differ. For example,
NavMesh_7 origin `(-33.600002, 5.6498957, -12.725)` returns Unity's vertically aligned
surface `(-33.600002, -2.3501046, -12.725)`, while Euclidean triangle distance picks
`(-33.600002, -1.1626046, -13.200001)`. This is a surface-selection discrepancy,
not floating-point tolerance noise. The test reports each difference as unresolved
and excludes it from accepted counts. Next work must reproduce source polygon
sampling and compare it against these cases before enabling Worker landing.
The Windows native runner reports 6,016 accepted checks with eighteen diagnostics;
Linux was not rerun for this capture checkpoint.

### Failed landing activation and wider source probes

The native world's `HasFailedLandingSample` input now represents the captured
failed-query branch explicitly. It rejects a simultaneous successful target.
After the current render it arms the source positive-infinite target internally;
the next render clears extension through the ordinary height comparison. The test
starts with an active extension, verifies arrival-frame activation, and verifies
that next-frame bodies remain unchanged while the flag clears. This does not allow
untrusted infinity through pose/target validation.

Set `WAR_ROPE_LANDING_EXTENDED=1` when running the disposable exporter to add
three heights and three horizontal offsets at each sampled vertex. The resulting
`recovered-helicopter-landing-offset-unity-reference.json` has 276 rows and LF digest
`01c66cae6eedc21c3a291e0a2a94c4b4cd783d46affa62adc16472169e45cd5b`.
Unity exited zero (`.local/rope-landing-offset-unity.log`). There are 275 successful
queries and one empty-mesh failure. An exploratory triangle projection comparison
matched only 142 with Euclidean ranking and 200 with horizontal-first ranking;
neither is a validated replacement for Unity polygon/detail-surface queries.
The wider capture is evidence for the pending algorithm, not a passing acceptance
fixture. The original 18 discrepancies remain diagnostics in the native runner.
