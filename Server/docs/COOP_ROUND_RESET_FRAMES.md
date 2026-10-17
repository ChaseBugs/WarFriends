# Post-notification corner fire frames

The current host round now publishes the fire clip at time zero instead of
omitting that actor's animation frame. Later host ticks continue from the
latest round's epoch. The existing actor remains visible and is reused.

## Two different observation phases

The full-rig volley capture records a pose before its fixture notification.
Gameplay muzzle sampling likewise uses the evaluation preceding a current
round, and excludes that round from its earlier-round reset lookup. That
geometry and launch-origin evidence are unchanged.

The network animation frame now explicitly represents an evaluated visual
state after the confirmed notification. Recovered ShotFromCover replaces the
queued fire state with ordinary fire, or restarts an existing ordinary fire,
with sample time zero. Sampling that state is distinct from claiming that the
previous observation or gameplay muzzle already had the new pose.

`UnityCoopRoundResetAudit` verifies this boundary in isolated Play Mode. It
creates an empty scene, builds script-free hierarchies and manually wires an
inactive source controller. For both corner sides, it seeds queued fire and
ordinary fire, invokes the actual source notification, checks its zero time,
then evaluates the source and production runtime sampler and compares the
whole local hierarchy. The probe does not run normal AI, controller startup,
projectile damage or rendered gameplay.

The source controller must be added in Play Mode: Editor AddComponent invokes
its recovered Reset before private animation wiring, which produces unrelated
null errors. The final audit enters empty-scene Play Mode first and completes
without those errors. Initial failing Editor-mode trials are not verification.

## Windows verification

The final source audit passes 168 reset/state/hierarchy checks. The native
adapter audit passes eighteen checks, including protobuf decoding of a zero-
time fire frame without hiding or recreating the actor. Live runtime tests
verify the exact first-round tick and the subsequent latest-round clock.

The 26,368 combat assertions, existing retained/return source checks and 1,136
protocol checks pass. Native MongoDB/HTTP/UDP smoke passes 74 checks plus
restart recovery; that smoke does not exercise public co-op combat admission.

No wire schema, SDK binary, Client asset or gameplay muzzle clock changes are
needed. Initial preparation's sub-tick blend, obstacle fire, procedural aiming,
normal co-op admission and authoritative player-hit routing remain open. This
does not prove normal source callback scheduling, rendered pixels, shipped
Unity 5.2, Linux execution or Android execution.
