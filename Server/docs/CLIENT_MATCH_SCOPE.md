# Unity match snapshot and admission scope

Reusing `SelfHostedBattleClient` for another match exposed two lifecycle errors.
The component retained its previous snapshot, so a new host tick of 20 could be
discarded after the previous match reached tick 120. Separately, a canceled
`Connect` operation unconditionally called `Close` after its await, potentially
closing a replacement connection already installed on that same component.

## Behavior

After validating and constructing a new transport, `BeginSnapshotScope` clears
the previous snapshot/enemy projection and binds the new grant's match ID,
manifest hash and player ID. Ticks/revisions remain ordered within that match;
the same-match stale-response guard is unchanged. This does not clear the last
snapshot on ordinary Close, preserving the previous post-close behavior.

`Apply` rejects callbacks belonging to another bound match or manifest before
examining their tick or publishing a view. SDK transport validation already
checks each connection's grant; this additional boundary prevents an older
async operation from publishing into a replacement component scope.

Admission captures its own `MatchConnection` before awaiting. Both successful
continuation and failure cleanup check ownership: an operation whose connection
has been replaced cannot publish admission state or close the replacement.
Ownership is checked again after `Apply`, since a synchronous snapshot callback
can close the current connection and install another one before Apply returns.

## Verification and remaining work

`UnityMatchScopeAudit` first reproduced the retained-snapshot failure against the
unmodified component. With the fix, it uses the real public Connect method and
pending loopback SDK sockets to start, cancel and immediately replace admission.
Its batch-mode entry point is `UnityMatchScopeAudit.RunAsync` in a disposable
project containing the installed SDK and existing visual audit helpers.
It checks snapshot reset, replacement ownership, acceptance of a lower new-match
tick, foreign match/manifest rejection and same-match stale-response rejection.
It also sends a synthetic MAC-authenticated admission reply through the SDK and
replaces the connection from its snapshot callback. The old admission must finish
canceled without marking the replacement connected. These are controlled
component lifecycle checks, not a registered Worker room, normal battle UI or
gameplay.

The existing native 24-check visual adapter regression and static asset audits
cover the surrounding component behavior. Full two-Unity-client loading,
successful Worker admission, normal scene scheduling and all other async batch
publication paths still require their own end-to-end evidence. B05/B36 remain
partial in the feature checklist.
