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
version 2. It validates and snapshots the source initialization, preserves the attachment's
creation-time rest rotation, advances exactly 0.02 seconds per call, and returns copied
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

The expanded native runner now passes 1,131 checks on Windows and actual Ubuntu WSL:
467 stationary/ownership checks and 664 motion/validation checks. The new guards also
reject NaN positions, zero/non-unit rotations and access after disposal, while retaining
unchanged physics time and snapshots after rejected input. Linux normal/yaw position
differences remain below 0.0000015; its tilted maximum position difference is about
0.3997, with quaternion-component distance 0.5162 and angular-velocity difference 15.9757.
These substantial tilted differences remain an open fidelity issue, not a passing trajectory.
Evidence is `.local/rope-native-motion-windows.log`, `.local/rope-native-motion-linux.log`,
and the zero-warning/error build at `.local/rope-native-motion-dotnet.log`.

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
