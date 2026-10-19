# Helicopter rope physical connection boundary

The host now prepares the local frames needed to attach the source rope to its aircraft
and connect its generated bodies. This is a constraint-preparation step, not an implemented
rope solver or a completed co-op collision world. Source initialization and extension
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

The connected rest orientation is derived from both initial body rotations so that the
two prepared world frames coincide. This orientation is a reconstructed rest-frame
convention, checked for world coincidence; the capture does not expose internal PhysX
joint-frame rotations. Motion/limit comparisons are still required before treating it
as a verified physical adapter. Non-unit scale is outside this preparation contract.

## Native diagnostic motion

The reference records three initial rope/aircraft poses, nine ConfigurableJoint anchors
and three aircraft FixedJoint attachments. It then calls real `Physics.Simulate` ten
times at 0.02 seconds, recording body positions, rotations, velocities and physical
settings. There are no extension commands, moving aircraft, gameplay updates or map
collisions in this fixture. These 0.2-second motion samples are diagnostic evidence for
the next solver work; host frame tests do **not** compare their trajectories.

Observed settings include gravity `(0, -9.81, 0)`, one solver iteration and one velocity
iteration, automatic transform synchronization, zero body COM, unit inertia tensor,
maximum angular velocity 7 and sleep threshold 0.005. The active Client's exported
DynamicsManager also specifies gravity -9.81 and one solver iteration; TimeManager
specifies the 0.02-second fixed timestep. Unity 2018 observations do not establish
original Unity 5.2 native physics equivalence.

The prefab and QuickRope2 SHA-256 values are recorded in
`recovered-helicopter-rope-physics-unity-reference.json`. Its normalized-LF digest is
`067718b56d79cf8c021f4da1502df1cc78e1656156231c6aa6c627f2419c29bb`.
The final Unity process exits zero with no logged exceptions at
`.local/helicopter-rope-physics-unity-final.log`. The active Client was not modified.

## Verification and remaining work

The focused `--helicopter-rope-initialization-only` runner now passes 625 checks,
including 84 new constraint-frame checks. It compares the twelve active native anchors,
local/world coincidence, body ownership and malformed setup rejection. Position tolerance
is 0.000003 and quaternion tolerance is 0.00001. The solution builds with zero warnings
or errors and protocol tests pass.
The Windows combat-content group exits zero with 27,573 assertions at
`.local/helicopter-rope-frames-host.log`. Existing native physics/navigation
diagnostics retain their documented differences; this is not a normal match proof.
The self-contained executable at `.local/linux-rope-frames` passes the same group
under Ubuntu WSL with 27,573 assertions, exiting zero at
`.local/helicopter-rope-frames-linux.log`. No full Battle executable or Mongo
smoke run is claimed for this geometry-only server change.

Still required: apply bodies and constraints in a physical adapter; match force/damping,
angular limits and iterative solving against native motion; couple aircraft motion and
extension with the physical timestep; bind signed content and current crew poses; then
verify descent, NavMesh landing and live co-op combat through the normal Unity Client.
No Worker registration, live co-op Fire, Mongo settlement or normal match acceptance
is established by these frame tests.
