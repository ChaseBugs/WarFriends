# Runtime infantry animation sampler

`SelfHostedInfantryAnimationState` describes one reviewed base-layer clip,
confirmed sample time, bounded blend weight and recovered wrap mode. It rejects
nonfinite/negative time, invalid weights/wrap modes and generated queued names.
It is a local Unity presentation model, not a protobuf DTO or combat command.

`SelfHostedInfantryAnimationSampler` caches an explicit set of recovered
infantry clips from the source Animation. It binds only clips whose actual
names match their reviewed identities and verifies that AddClip preserved the
source clip object. The destination owns a disabled built-in Animation with
automatic playback disabled. There is no MonoBehaviour, Update or local clock.
Source aliases must already be initialized by the recovered scene setup.

Sample validates and copies the entire frame before stopping the current
mixer. Missing/duplicate/unknown clips, empty frames and all-zero weights
reject without replacing the previous pose. Accepted frames apply confirmed
time, wrap mode and weight on base layer zero with ordinary Blend mode, then
call Animation.Sample. Script-free visual ownership remains with the actor;
destroying the actor destroys its mixer too.

## Active connection and verified scope

The co-op walking presenter now owns one sampler per cached source actor.
It samples validated host frames and retains the previous confirmed
root placement, source appearance choice, unknown-state hiding, death removal,
reset and direct-close cleanup. Legacy walking remains a compatibility path;
the complete frame also supports the host's fixed-root corner fire and
[source return/idle window](COOP_CORNER_RETURN_FRAMES.md).
A failed sampler construction destroys its incomplete actor.

The native whole-rig exporter now uses this exact runtime class for its
original-name positive control. It checks every transform against real source
preparation, queued fire, per-round reset, return and interruption observations.
The native-queue reference and deliberately wrong queued-alias control remain
independent. Use the existing reference verifier with --require-mixer-parity;
the original tolerance limits are unchanged.

The dedicated Editor audit checks invalid frame/state rejection and preserves
the enabled clip, sample time and every local position/rotation/scale after
rejection. The walking presenter audit checks actual skin creation, pose
change, actor reuse, hiding and lifecycle cleanup. These are isolated Unity
2018.3 observations, not normal two-Client gameplay or shipped Unity 5.2 proof.

The runtime class supports only the reviewed base layer, not procedural aiming,
additive layers or full animation state machines. Complete preparation/interruption
projection, missed-snapshot verification, other families and authoritative
co-op combat remain open. See [confirmed frames](COOP_ANIMATION_FRAMES.md)
for the current wire contract and partial host selection.

Windows verification passes 393 strict source/replay frames through the actual
runtime positive control, 31 rejection/pose-preservation checks and twelve
walking presenter checks. The asset audit resolves 1,052 script targets and
288,080 serialized references with zero missing scripts or broken references;
the same seventeen unmatched NGUI sprite selections remain. The subsequent
confirmed-frame increment updates the SDK and protobuf contract separately.
