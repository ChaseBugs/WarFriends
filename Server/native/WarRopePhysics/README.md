# Native helicopter rope adapter

`NativeHelicopterRope` calls this shared library through a small C ABI. Construction is
explicit; the battle Worker does not register or load it automatically. The existing
PhysX reference build scripts build both the diagnostic executable and this library.
It implements unit-scale aircraft attachment, generated rope bodies and direct aircraft
Transform inheritance and source extension/insertion. Flight scheduling, collisions, crew, landing, signed
content selection and live Client acceptance remain separate work.

## Ownership and failure

One library runtime owns the CPU SDK and one dispatcher. Each rope owns its own scene,
aircraft, bodies and joints. A mutex serializes registry operations and simulation.
The registry permits 64 simultaneous ropes and 2-128 bodies per rope. These are explicit
adapter capacity limits, not recovered gameplay constants. Unsupported source body or
angular-limit settings are rejected, never substituted. Registry identities increase
without reuse; unknown and previously destroyed identities cannot address another rope.

Managed `SafeHandle` ownership releases joints before actors and scene. Disposal is
idempotent and synchronized with state access. State arrays are copied into immutable
managed records. A native error or invalid snapshot permanently closes that owner's
simulation authority; failed simulation cannot be retried as though it rolled back.
SDK parameter/operation/allocation/internal/abort errors latch the shared runtime into
failure, while cleanup remains permitted. This is fail-closed behavior, not crash recovery.

## C ABI version 4

Lifecycle operations return `0` for success, `1` for invalid input/identity, `2` for capacity,
and `3` for SDK/internal failure. No C++ exception crosses the boundary. Identities use
`uintptr_t`, matching managed `IntPtr` on the supported Windows/Linux x64 builds.

| Export | Contract |
| --- | --- |
| `war_rope_abi_version()` | Returns `4`; managed construction rejects any other version before exchanging buffers. |
| `war_rope_extend(handle, values, length, expectedBodyCount)` | Applies one prepared command against the current count. |
| `war_rope_set_aircraft_transform(handle, values, length)` | Applies exactly seven pose floats without advancing time. |
| `war_rope_create(values, length, bodyCount, outHandle)` | Requires `14 + 7 * bodyCount` floats. |
| `war_rope_step(handle, deltaTime)` | Completes one exact 0.02- or 0.004-second simulation step. |
| `war_rope_snapshot(handle, output, length)` | Requires exactly `13 * bodyCount` output floats. |
| `war_rope_destroy(handle)` | Releases one owned scene and its objects. |

Create input starts with aircraft position XYZ and rotation XYZW, then attachment
creation-time rest XYZW, then connected anchor XYZ. Each following body row has
position XYZ and rotation XYZW. Snapshot body rows contain position XYZ, rotation
XYZW, linear velocity XYZ, and world angular velocity XYZ in radians per second.
The ABI accepts managed-owned buffers of the stated length; it is not an untrusted
network parser. SDK objects, signing secrets and native pointers never cross the wire.

The aircraft setter mirrors `Helicopter.Update`'s direct Transform writes. It carries
the root and terminal rope body in aircraft-local space, leaves generated middle bodies
unparented, and preserves existing velocities. It does not use a kinematic target or
recompute joint rest frames. All resulting child poses validate before the first write.
It assumes the measured original unit-scale hierarchy, not arbitrary caller-owned parenting.
Older ABI libraries must be rebuilt; no compatibility fallback selects different behavior.

Extension input has three floats for the moved first-body position, optionally followed
by seven pose floats for exactly one new body. The managed owner prepares these values
from the current snapshot and original measured spacing using `HelicopterRopeExtension`.
It retains the original root constraint identity while disconnecting/reconnecting actors;
replacing that joint changes solver order and does not match the source. The temporary
kinematic transition resets the old first body's velocities. Inserted bodies use default
Rigidbody linear drag zero, rather than the initial chain's 0.2. New objects and vector
capacity allocate before existing body mutation; SDK failure still closes authority.
The new body remains unparented and the original terminal body retains aircraft inheritance.

## Managed render ordering

`BeginExtension(targetHeight)` arms the source ShowRope gate. Target height must come
from a separately resolved host NavMesh target; this API does not fabricate a ground hit.
`UpdateRenderFrame(deltaTime, aircraft)` validates both inputs before mutation, reads the
current terminal height, applies extension only while that height is strictly above the
target, then changes the aircraft Transform. Reaching the target disables extension
until another explicit BeginExtension call, even if a later aircraft move raises the end.
The checked render counter advances only after that sequence succeeds. `Advance()`
remains a separate physics operation; no render/fixed-step ratio is invented.
The render composition uses the current ABI exports without an additional native operation.

The combined capture drives this specific recovered branch with original ExtendRope
calls and synthetic aircraft poses. It is not a complete Helicopter.Update execution,
waypoint flight, automatic Unity fixed-update schedule, NavMesh query or crew proof.

## Normal and ragdoll timing

The active Client's TimeManager profile starts at 0.02 seconds. Its original
`SetupPhysicsTiming` switches to 0.004 seconds for player ragdoll and restores the
cached default afterward. `SetPhysicsMode` selects either recovered mode without
moving bodies or advancing a clock; subsequent `Advance` calls retain that selection.
The caller must fan out host-owned lifecycle changes to the relevant scenes. Global
match timing, automatic fixed/render scheduling and ragdoll body simulation are not
implemented by this rope adapter.

ABI 4 requires the step delta explicitly and rejects every other float, including
zero, NaN, Infinity and a render interval such as 1/30. It never rounds an unsupported
interval or silently substitutes 20ms. A zero render delta is not a zero physical quantum:
the phase clock may still dispatch previously owed work after a mode change. Older native
libraries must be rebuilt because the step signature changed.

`NominalPhysicsMilliseconds` accumulates the exact nominal 20/4ms quanta only after
successful simulation. This is not wall time or a Unix timestamp, and StepCount must
not be multiplied by one fixed duration after timing transitions. The SDK receives the
original float constants directly, not milliseconds multiplied by a float conversion.

## Fixed/render phase clock

`HelicopterPhysicsFrameClock` retains fractional physical time across render frames.
Its intended owner is the match, not each newly spawned rope. BeginFrame accepts bounded
scaled game time, including zero. TakePhysicsStep dispatches due 20/4ms quanta until it
returns null; only then can rendering complete. Mode changes in the render phase affect
the next frame and do not discard the remainder. A failed world execution must Fault the
clock; consumed SDK work cannot be safely replayed by resetting counters.

Actual automatic Unity traces cover normal/ragdoll switches and a zero-timescale window.
Lowering the quantum during pause causes previously owed work to run on a zero-delta
frame. The clock reproduces that behavior instead of suppressing all paused physics.
Tests dispatch every scheduled quantum into a real native rope and apply render updates
only after physics drains. This does not register the clock in the Worker or prove full
NPC/crew collision behavior. Startup alignment, hitch limits and mode changes originating
inside physical collision callbacks need further integrated acceptance.

## Verification

The deliberate `War.Battle.Tests --native-helicopter-rope-only` mode requires the built
library and its SDK dependencies in the native loader search path. It does not silently
skip when the library is unavailable. It compares identity/yaw motion against the pinned
Unity capture and reports the tilted transient diagnostically. Separate checks exercise
scene independence, retained snapshots, double disposal, access after disposal, capacity
rejection, cleanup/reallocation, malformed input and unknown identities.

Windows validation copies `Server/.local/native-rope-probe/Release/WarRopePhysics.dll`
beside the test executable and adds the SDK's `PhysX_3.4/Bin/vc15win64` and
`PxShared/bin/vc15win64` to `PATH`. Linux validation adds
`Server/.local/native-rope-probe-linux`, `PhysX_3.4/Bin/linux64`, and
`PxShared/bin/linux64` to `LD_LIBRARY_PATH`. These are local validation paths;
deployment packaging and loader policy remain pending.

Run the mode from a normal .NET build on Windows and an actual self-contained Linux
publish. Publishing alone is not Linux execution evidence. The library is not yet bundled
into Worker deployments; missing native packages cannot silently select a different solver.
See [physics evidence](../../docs/HELICOPTER_ROPE_PHYSICS.md) and
[SDK build instructions](../../tools/NativeRopeProbe/README.md).

The managed `NativeHelicopterPhysicsWorld` owns isolated rope scenes and one match
clock. A lease binds a world ID, entity ID and generation. Failed frame execution
faults the whole owner and releases its scenes; it cannot publish partial state or
retry already executed physics. A native derived-transform rejection test exercises
this path after physics and an earlier member's render, then reallocates the entire
64-slot registry before disposing the failed owner. This does not introduce shared
collision solving between ropes or register the adapter in the Worker.
