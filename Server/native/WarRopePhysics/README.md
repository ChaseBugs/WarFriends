# Native helicopter rope adapter

`NativeHelicopterRope` calls this shared library through a small C ABI. Construction is
explicit; the battle Worker does not register or load it automatically. The existing
PhysX reference build scripts build both the diagnostic executable and this library.
It implements unit-scale aircraft attachment, generated rope bodies and direct aircraft
Transform inheritance. Flight steering integration, extension/insertion, collisions, crew, landing, signed
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

## C ABI version 2

Lifecycle operations return `0` for success, `1` for invalid input/identity, `2` for capacity,
and `3` for SDK/internal failure. No C++ exception crosses the boundary. Identities use
`uintptr_t`, matching managed `IntPtr` on the supported Windows/Linux x64 builds.

| Export | Contract |
| --- | --- |
| `war_rope_abi_version()` | Returns `2`; managed construction rejects any other version before exchanging buffers. |
| `war_rope_set_aircraft_transform(handle, values, length)` | Applies exactly seven pose floats without advancing time. |
| `war_rope_create(values, length, bodyCount, outHandle)` | Requires `14 + 7 * bodyCount` floats. |
| `war_rope_step(handle)` | Completes exactly one 0.02-second simulation step. |
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
ABI 1 libraries must be rebuilt; no compatibility fallback selects different behavior.

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
