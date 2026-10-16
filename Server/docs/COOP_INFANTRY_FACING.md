# Infantry presentation facing estimate

Status: bounded presentation estimate, not verified native navigation rotation.
The existing moving-root collision and world-shot gates remain closed.

Previously `AdvanceInfantryPaths` updated positions but left snapshot root
rotations unchanged. `PlaceWalkingAssaulterHitboxes` independently derived an
instantaneous route heading. Consequently the published root and diagnostic
body geometry could face different directions on the same tick.

The runtime now advances a facing estimate when a path actually changes planar
position. It preserves the existing 0.6-unit geometric route lookahead and
bounds each navigation-stage turn using 600 degrees per second at the host's
30 Hz rate. The angular-speed upper bound comes from `m_AngularSpeed: 600` on
NavMeshAgent component `19588432` in the pinned 1.4.0 `enemy.prefab`.
The lookahead and maximum-rate interpolation are explicit presentation policy;
they are not recovered Unity steering internals.

`CoopInfantryFacingEstimate` validates the root and route vector, retains facing
without a planar direction and takes the bounded shortest rotation toward the
route heading without overshoot. No-motion path ticks preserve the root.
The root snapshot and walking collider candidates now use that same estimate.

For a moving shot, the path first updates the estimated navigation root.
`CoopShotRootComposition` then applies the actual source-tested tween stage,
including its final write. Once the tween stops, later path ticks continue to
publish the estimate. The tween can rotate faster than the agent's angular
upper bound: that bound constrains only the navigation estimate, not the
separate recovered animation tween.

## Verification boundary

Focused tests check bounded turns, target convergence, no-direction stability
and invalid-input rejection. A real moving-shot runtime fixture checks that
the reused source tween updates the published root while movement continues.
It simultaneously requires `HasNavigationRotationConflict` and unplaced
collision status; later round origins remain unavailable through the same
existing guard.

The native before/after reference is also compared with this estimate. The
known tween writes match. Afterwards, 53 frames differ, with a maximum angular
error of approximately 84.99 degrees. This is a measured disagreement, not
native rotation parity. The comparison reports error without requiring the
estimate to stay inaccurate; replacing it with a better model must bring its
own positive source evidence and authority review.

Thus these rotations are coherent diagnostic presentation state. They are not
evidence to authorize moving rifle impact, collision, rewards or co-op mode
registration. Full native steering/history, Client synchronization and complete
gameplay authority remain required. No Client script, prefab or setting was
changed by this integration.

```powershell
dotnet run --project Server/tests/War.Battle.Tests -- --coop-gameplay-query-only
dotnet run --project Server/tests/War.Battle.Tests -- --combat-content-only
```

Windows validation: the focused checks and full content executable exit zero,
including 26,368 counted assertions plus observation and estimate fixtures.
The live moving-volley fixture passes with the rotation-conflict guard retained.
Sequential native smoke builds with zero warnings/errors and passes 1,037
protocol checks, 74 live MongoDB/HTTP/protobuf/UDP checks and restart-persistence
proof. These checks do not establish native steering parity or full Unity play.
