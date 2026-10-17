# Cached RPC lifetime and self-hosted ownership

PhotonCachedRPC originally added itself to the global room-reset registry on
every OnEnable and never removed itself. Re-enabling a pooled object duplicated
the receiver, and destroyed scene objects survived in the registry. The native
baseline reproduces duplicate registration in
`Server/.local/unity-cached-rpc-lifetime-baseline.log`.

## Registry behavior

Registration is now idempotent, and destruction removes the entry. Disabled
caches intentionally remain registered: the recovered new-room reset must clear
their pending requests before a later activation. Removing them in OnDisable
would allow stale requests to survive a room transition.

PhotonConnectionManager invalidates a snapshot of the receiver list, skips
destroyed entries, then performs the existing GameController room notification.
It calls InvalidateForNewRoom directly before retaining the original receiver's
SendMessage. The native check in `Server/.local/unity-cached-rpc-inactive-reset.log`
reproduced SendMessage skipping an inactive receiver and leaving its old queue.
The direct reset works independently of activation; the existing message remains
available to other components on active receiver objects.
The snapshot avoids enumerator invalidation if receiver callbacks destroy scene
objects. It does not reorder the surviving receivers.

## Self-hosted transport boundary

Both SendOfflineRPC overloads now reject retained self-hosted ownership before
touching PhotonView or adding a cache entry. They throw InvalidOperationException;
they do not pretend a map, spawn or other arbitrary RPC was accepted by the
Worker. The active literal callers are the legacy map choice and random unit
offer paths; their supported self-hosted replacements remain typed host state,
not a generic string RPC tunnel.

Update discards an existing legacy queue when a self-hosted owner is present.
The new-room notification normally clears it, but owned isInRoom may become true
before that notification. An old Photon request must not replay during that
interval. The ordinary legacy/solo replay contract is otherwise retained.

## Verification limits

UnityCachedRpcAudit runs in the existing disposable Unity component/UI fixture.
It checks registry uniqueness, disabled retention, destruction cleanup, both
direct-send refusals and a prior queue discarded under an inactive canonical
self-hosted owner. That owner uses controlled SDK grant/snapshot state, not a
live Worker. The old queue is installed through the private recovered cache
method to model pre-admission state without submitting a new owned request.
The final combined component/UI run passes in
`Server/.local/unity-cached-rpc-complete-fixed.log`, including direct new-room
invalidation of the inactive cache. Its runtime error gate reports no unexpected
errors. Static asset validation remains at zero missing scripts/broken references
across 288,165 nonzero references. No SDK binary or serialized asset changed.

This does not implement remaining map/rematch/entity RPCs, migrate solo RPC
execution, remove PhotonView registration, or prove full normal battle bootstrap.
The retained cache is a legacy compatibility component, not the new transport.
