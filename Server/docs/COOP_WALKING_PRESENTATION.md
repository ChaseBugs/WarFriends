# First host-clock co-op infantry presentation

## Source rule and supported boundary

`SoldierAnimationController.Walk` selects `run` for the basic rifle branch;
the recovered enemy rig binds that clip as `run_0`. The host already samples
this clip at `CoopInfantryPathState.SecondsSinceStart` in its diagnostic walking
hitbox path. That path explicitly does not authorize moving collision: native
agent turning/avoidance and complete source animation composition are still
unverified.

The snapshot now publishes that same presentation-only clip and route epoch
for an alive Assaulter on a supported active route. It requires the running
phase, available source pose data, current host pose tick/rotation and no
obstacle reposition transition. The diagnostic hitbox sampler and snapshot
projection share this selection. Raw spawn history is unchanged; metadata is
added only to the projected clone.

Three appended protobuf fields carry `infantry_visual_clip`,
`infantry_visual_start_tick` and `infantry_visual_sample_tick`. An empty clip
requires zero clocks. The SDK accepts the current `Assaulter`/`run_0` branch
only while alive/running, binds sample tick to current pose/server tick and
requires a route epoch no earlier than creation. It does not guess an idle,
fire, uncover or death animation. Terminal server evidence rejects live
walking declarations, and terminal projection emits none.

## Client connection

`SelfHostedCoopInfantryPresenter` binds one admitted match/manifest after the
recovered co-op startup. It subscribes to the validated common enemy view and
uses the shared source infantry factory. Ordinary/card appearance selection
remains local, as in `SetSoldierStyle`, and is performed once per cached actor.
This adds no server appearance prerequisite.

For a supported frame, it places the root at the confirmed position/rotation
and samples the source clip at `(sampleTick - startTick) / 30`. It performs no
local-time extrapolation or local AI update. Repeated frames reuse the actor;
an unrepresented state hides its cached rig instead of substituting a default
pose. Death retires the walking rig. Disable/reset unsubscribes and destroys
owned roots; re-enable replays the current view. The adapter's new `MatchClosed`
notification clears roots after connection/view cleanup, including direct close.

The actor contains visual transforms/renderers and a disabled built-in
Animation sampler: no source MonoBehaviours, colliders, rigid bodies or
autonomous animation controller. It cannot produce
projectile damage, kill credit or economy changes.

## Verification and remaining work

Protocol tests cover supported metadata plus unknown/absent clips, invalid
epochs, stale samples, wrong family, death and terminal declarations. The real
runtime fixture verifies route epoch 8, subsequent pose tick, death cleanup and
the existing unplaced-collision guard. Role/terminal fixtures reject forged
live animation in terminal evidence.

`UnityCoopWalkingVisualAudit.Run` checks actual source mesh creation, actor reuse,
position updates, changed source bone pose, unknown-state hiding/resume,
disable/unsubscribe/re-enable replay, body death, another entity and direct
match-close cleanup. Its Editor-mode lifecycle callbacks are invoked explicitly;
it is not automatic Play Mode lifecycle or rendered-pixel proof.

This is the first supported moving body path, not a complete co-op renderer.
Cross-fade/queued blending, idle/cover/fire/death states, continuous interpolation,
full level-dependent weapon/camo appearance, other infantry, air/vehicles/Boss
and normal two-Client gameplay remain open. Host facing is still the previously
documented presentation estimate rather than native NavMesh parity. Worker
co-op admission and validated player-hit routing remain closed, and no reward
gate opens. The full BattleServer objective remains unchanged.

### Windows verification checkpoint

The solution builds without warnings or errors. Verification passed 26,368
focused combat assertions, 1,118 protocol checks, 74 live MongoDB/HTTP/UDP
checks and restart recovery. The native Unity Editor audit passed twelve
source walking mesh checks. Installed Client/Shared SDK hashes match both
the tested build and the disposable Unity audit; audited Client source hashes
also match the active project.

The asset audit resolves 1,052 script targets and 288,080 serialized references
with no missing scripts or broken references. NGUI retains the same seventeen
unmatched sprite selections. These checks do not establish rendered gameplay,
normal co-op admission, Linux execution or Android execution.

The next firing work follows the source-derived
[firing presentation requirements](COOP_FIRING_PRESENTATION_PLAN.md). In
particular, callback muzzle samples are not whole-body visual mixer samples.
