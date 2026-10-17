# Source-method corner return frames

The host now projects corner cover return, the cover-to-idle blend and later
pure idle through the existing protobuf animation frame. It uses the measured
controller path rather than guessing blend weights from clip duration.

## Source and reproduction

`coop-corner-return-animation-reference.json` contains 31 observations per
side, extracted from the source-method whole-rig volley capture. Source return
starts after that fixture's observation 59. Offsets 1-31 therefore correspond
to observations 60-90. The original controller's Update starts cover at time
zero; the host's confirmed post-command offset zero uses that single clip.
Later samples preserve the measured time, wrapping and weights exactly.

The record binds the compressed source capture digest, recovered enemy prefab
digest, controller digest, client 1.4.0, Unity 2018.3 and 30 Hz clock. Check
reproducibility without changing files:

```powershell
python Server/tools/extract_coop_corner_return_animation.py
```

`--write` regenerates the compact record after a reviewed source capture
change. The runtime revision pin must then be reviewed explicitly. The JSON
has an explicit LF Git attribute so its byte digest stays stable on Windows
and Linux. Runtime deployment needs the compact JSON beside the other combat
content; the larger compressed capture is a development verification input.

## Host boundary

The selector retains the existing corner root/phase checks, rejects active
paths and navigation conflicts, and closes when another shot becomes eligible.
The source last-round hide timer owns its start. The diagnostic collision
selector must still recognize the pose window, but its older idle_1 collider
record is not used as the animation record. Actual source-method rendering
uses the controller's idle alias, preserving that clip binding.

The private catalog validates provenance, contiguous coverage, clip identities,
wraps, finite scalars, conserved weights and a terminal pure-looping-idle frame.
Returned protobuf frames are clones. Beyond the recorded offset 31, pure idle
continues from its measured phase, within the existing diagnostic clock bound.
No Actor, damage, projectile, reward or collision authority is created by a
returned animation frame.

## Verified scope

The solution builds without warnings/errors. The combat suite passes 26,368
focused assertions plus 154 source-method return checks, including comparison
with all 62 independent full-rig observations, copied-frame isolation, idle
continuation and rejection of damaged content or mismatched provenance. Live
host fixtures verify cover-start and continued-idle projection while retaining
the unplaced-collision boundary.

The native adapter audit passes fourteen checks, including a protobuf-decoded
two-clip return blend on the reused source actor. Set
`WAR_CORNER_RETURN_ANIMATION_REFERENCE` to the compact JSON's absolute path
before invoking `UnityCoopWalkingVisualAudit.Run` in the disposable project.
This remains Editor component/geometry proof, without rendered-pixel or
normal gameplay claims.

The protocol executable passes 1,136 checks, and native MongoDB/HTTP/UDP smoke
passes 74 checks plus restart recovery. Those integration checks do not open
or verify public co-op combat admission. No SDK binary or Client asset changes
are required for this server/content increment.

The subsequent [round-reset projection](COOP_ROUND_RESET_FRAMES.md) publishes
confirmed fire at time zero on the current round. Obstacle fire, procedural
aiming and normal co-op admission/combat remain open. Existing collider diagnostics are unchanged; their own full source
parity remains a separate requirement. This does not establish shipped Unity
5.2, Linux execution or Android execution.

The subsequent [retained preparation](COOP_CORNER_PREPARATION.md) checkpoint
captures return before another windup replaces it, preserving the reversed
look phase rather than incorrectly projecting a fresh look.
