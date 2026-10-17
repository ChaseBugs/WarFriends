# Preserved obstacle preparation origins

A new obstacle volley now captures its previous crawl/round context before
resetting the source hide clock or removing old emitted-round history. The
immutable `CoopObstaclePreparationStart` retains capture tick, previous return
tick, previous confirmed round tick and the nominal prior crawl phase.
It does not retain a mutable prior runtime or an unbounded chain of attempts.

The preparation builder runs before `BeginObstacleVolleyClock`; the new clock
and round reset still occur on the same accepted host tick. Source callback
duration, round cadence, root tween, position draws and economy are unchanged.

## Scope and admission boundaries

A known return supplies phases 0-16 using the reviewed crawl length. Completed
clamp progress maps to phase sixteen while its actual epoch remains retained.
Future activity, a round at/after a supposedly known return, an incompatible
clip phase domain and backwards sampling are rejected. An unknown prior fire
or interrupted/unresolved animation does not become fresh completed crawl.
Initial attempts remain separate and retain the existing source-delay guard.

Projectile receipts can survive point movement after their original windup
is removed. They are launch evidence, not current animation history. Capture
therefore accepts a last round only when its prior windup still exists and the
round belongs to that windup's epoch. An integration failure exposed this
distinction; old projectile evidence is preserved rather than deleted to fit
animation state.

The runtime's internal sample selector maps a known nominal return phase and
preparation observation to the generated catalog ID. It ends at observation
thirteen, the next attempt boundary, navigation conflict, terminal phase or
the first confirmed new round. The catalog captured preparation without new
round notifications, so it must not override the separate confirmed-fire
reset timeline. This is a candidate index, not a published or revision-validated
pose. Gameplay-Update evaluation boundaries, especially immediate return/
notification ordering, still need their own source parity before wire use.

Until pose catalog loading and presentation are connected, partial and unknown
previous attempts stay excluded from fresh-clock muzzle/collider diagnostics
and fresh preparation visuals. This prevents unsupported history from being
misrepresented as completed crawl. Hiding is an interim boundary, not the
requested final implementation; correct visible transition support remains
required. Public co-op admission and authoritative player-hit routes stay closed.

## Verification

All 221 origin/sample identities match the independent generated source
catalog. Boundary tests reject future/contradictory activity, malformed clip
lengths, rewound samples and out-of-window extrapolation.

Three independent runtime fixtures cover prior fire without return, a partial
return and completed return. Trusted test-only timing makes these source
branches observable without exposing a Client timing field. They verify
capture before reset, preserved prior round, immutable replay, conservative
visual/collider boundaries and selection termination after a new real round.
The existing post-reposition volley tests also prove retained launch evidence
is not mistaken for a new point's animation. Focused combat passes 26,368
assertions, and MongoDB/HTTP/protobuf/UDP smoke passes 1,143 protocol checks,
74 live checks and restart recovery. That smoke does not exercise public co-op
admission. No protobuf schema, SDK binary or active Unity asset changes here.

Remaining work is a validated immutable catalog loader, source-bound host/SDK
reference, atomic Unity pose application, retained begin/fire branches,
repeated interruption and normal callback/gameplay verification. Source
research alone does not make those runtime features complete.
