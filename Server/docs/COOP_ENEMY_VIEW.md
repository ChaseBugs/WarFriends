# Common co-op enemy view

The isolated source runtime already publishes a complete `enemy_spawns`
history. The Client previously had no dedicated common enemy view event.
Re-enabling the recovered AI components would restart local combat simulation,
so enemy presentation needs a separate read-only path.

## Validated common fields

`CoopEnemyViewProjection.FromSnapshot` first validates the source mission's
roster, role, clock and lifecycle. It then validates the complete enemy set
before returning any views:

- Contiguous host entity IDs, known recovered behaviour names, nonnegative
  source levels and positive spawn component IDs.
- Creation and pose ticks inside the running mission clock, with a death pose
  no later than its confirmed body death.
- Finite spawn/current coordinates and optional normalized source/current
  rotations. Missing rotation does not invent an orientation.
- Finite positive maximum body health, bounded nonnegative current health and
  the current runtime's zero-health/death-tick agreement.
- Source card interpolation `min(1, level / 25)` only on timed card spawns;
  ordinary units retain zero card progress.

The recovered behaviour dictionary resolves names case-insensitively. The
source catalog spells one entry `FlameThrower`, while other source identifiers
use `Flamethrower`; the view resolves both and preserves the original bytes
instead of renaming an asset/gameplay identity.

`CoopEnemyViewState` copies common identity, card lane, body vitality, exact death
tick and current pose. Its getters cannot mutate the source packet, and optional rotation is
returned as a copy. Complete-set validation happens before the adapter assigns
its next state. A malformed later row cannot publish a partially updated roster.

## Adapter boundary

The active adapter exposes `CoopEnemies` and `CoopEnemiesReceived`. The typed
event runs before room lifecycle and generic state/outcome callbacks. Connection
close clears its active view. IDs remain match-scoped; future presenters must
bind the admitted match/manifest and clear their own actors on scene teardown.
The older generic wave prototype has no source mission type and receives no
invented enemy presentation.

This is a common-field data path, not an actor renderer. It does not instantiate
prefabs, enable recovered AI, infer interpolation, resolve source meshes or
animate deaths. It does not expose transport crew, air gunner, vehicle seat or
other specialized extension fields as validated presentation. Those need their
own source-bound views and lifecycle/asset checks. Boss state is separate from
the ordinary enemy ID sequence and is not folded into this list.

## Verification

Protocol tests cover valid creation/death, empty pre-spawn state, input and
consumer isolation, source name spelling, card lanes and malformed identity,
vitality, pose and rotation. Real source runtime role fixtures now project every
roster before host damage and retain the confirmed dead entries afterward.

`UnityCoopEnemyViewAudit.Run` exercises the current portable SDK and the actual
adapter in Mono: published fields, callback order, packet/consumer isolation,
invalid-row rejection before adapter state changes, and close cleanup. It creates
no enemy actors and does not render gameplay. Worker co-op registration,
validated player-hit routing, complete enemy visuals/combat and settlement
remain open. This change opens no economy or combat gate.

Windows validation passes 26,368 focused combat assertions plus the source
roster fixtures, 1,110 protocol checks, seven native Unity Mono checks and the
74-check MongoDB/HTTP/protobuf/UDP smoke with durable restart replay. The final
portable SDK binaries match the native audit and are installed in the active
Client with updated manifest hashes; third-party DLLs and plugin metadata are
unchanged. Static audits retain zero missing scripts/broken references and the
seventeen known unmatched NGUI selections. No enemy actor, rendered gameplay,
new Linux or Android proof is claimed.
