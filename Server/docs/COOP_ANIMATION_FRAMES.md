# Confirmed co-op infantry animation frames

Enemy field 32 (`infantry_animation`) carries a sample tick and one or two
base-layer clips. Each clip contains its original source identity, sample
seconds, weight and an explicit Clamp/ClampForever/Loop enum. It carries no
Unity-generated queued names, process-local clip IDs, projectile grant or
damage authority. Existing walking fields 29-31 retain their wire numbers.

## Host selection

The walking selector now projects both its legacy route epoch and a complete
frame with run_0, unit weight and Loop wrapping. The frame's unwrapped time
comes from the same 30 Hz route clock.

The next supported state is the fixed-root corner fire window. The host uses
the existing diagnostic corner-fire geometry guard, chooses the recovered
left/right fire clip and samples from queued-fire start or the latest actual
host round intent. It excludes active paths, navigation rotation conflicts,
unconfirmed root transforms, unsupported phases and current-round reset ticks. The latter
occur between source animation evaluations and are not represented yet.
Preparation remains unrepresented by this selector. The subsequent
[return-frame catalog](COOP_CORNER_RETURN_FRAMES.md) covers source return,
cover-to-idle blending and continued idle in the guarded corner window.

An unrepresented state emits no frame; the Client hides that rig. Raw spawn
history remains unchanged. Terminal evidence rejects any live animation frame,
and ended/dead projection emits none. The moving/diagnostic collision exclusion
remains intact. A visible fire pose is not a proven projectile or hit.

## SDK and Unity boundary

The SDK requires a running, alive Assaulter with a confirmed rotation. The
sample tick equals ServerTick and cannot precede the last root pose tick;
a stationary root can legitimately have an older PoseTick. It accepts only
the reviewed source clips and their source wrap modes, at most two unique
clips, finite nonnegative time, finite unit-interval weights and a total weight
of one within 0.0001. Time is bounded by elapsed match time plus the reviewed
one-second prior idle. Host selectors own transition legality; the SDK does
not infer an AI phase from arbitrary clip combinations.

When legacy walking metadata is present, its clip, route-derived time, tick
and unit weight must agree with the complete frame. Immutable copied views
prevent packet or caller mutation from changing an already published sample.
Absent frames still support the earlier walking-only host contract.

The Unity presenter converts validated wire wraps explicitly and sends the
complete local frame to the runtime sampler. It initializes the recovered
source aliases once during configuration, preserves original clip bindings
and reuses the same source actor for walking and corner fire. Unknown states,
death, reset and close retain the existing cleanup behavior.

## Windows verification and remaining work

The solution builds with no warnings/errors. Protocol tests pass 1,136 checks,
including wire roundtrip, immutable samples, blend weights, duplicate/unknown
clips, invalid clocks/scalars/wraps and inconsistent legacy mirrors. The 26,368
focused combat assertions include host walking/frame agreement, source corner
fire time, death cleanup and the existing unplaced-collision boundary. Terminal
fixtures reject forged animation frames.

The disposable Unity 2018.3 audit passes thirteen checks, including protobuf
encode/decode through the actual adapter, actor reuse and replacement of the
walking pose by a corner fire sample. It invokes Editor lifecycle callbacks
explicitly and does not prove rendered pixels, normal bootstrap or automatic
Play Mode lifecycle. Real MongoDB/HTTP/UDP smoke and restart recovery pass;
those 74 integration checks do not exercise public co-op combat admission.

Preparation/interruption projection, current-round transition frames,
obstacle fire, procedural aiming, other families, missed snapshots and normal
two-Client co-op remain open. Worker co-op admission and validated player-hit
routing remain closed. This checkpoint does not open reward or damage gates,
or establish Linux/Android execution or shipped Unity 5.2 parity.
