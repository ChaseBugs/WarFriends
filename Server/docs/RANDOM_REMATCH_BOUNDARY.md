# Random rematch transport handoff

The recovered GameControllerDeathMatch.Rematch has two distinct branches.
Random matchmaking starts StartRandomMatchMaking again; a friend match calls
the base Rematch negotiation against the same opponent. They are not equivalent
requests and must not be silently routed to the same queue behavior.

## Implemented random-search boundary

The successful matchmaking request clears its controller search-owner fields,
but the SDK intentionally retains its match connection through gameplay and
terminal presentation. Reset therefore does not release that completed owner.
MatchmakeAndConnect correctly rejects an existing connection, so a fresh random
search cannot reuse it.

StartRandomMatchMaking now checks the canonical retained owner before touching
the lobby, player registry, profile or Dog Tag path. If one exists, the SDK's
ReleaseEndedMatchForNewSearch requires that exact active owner and an Ended
snapshot, and applies the existing abort-recovery guard. Waiting, countdown,
running, missing-state and aborted owners cannot be released through this API.

The release uses normal local transport cleanup; it does not send another
forfeit/result, reopen the old match, create a grant or promise Backend admission.
The original random search, recovered local bot policy and Dog Tag call order
continue afterward. A new match still requires the existing authenticated queue
and allocator, including durable pair-release and loadout/presentation validation.

## Evidence and remaining work

The native baseline invokes the actual random controller with a retained running
owner. It incorrectly reaches LoadingDialog/StartMatch and the absent profile
dependency instead of rejecting ownership first:
`Server/.local/unity-random-search-owner-baseline.log`.

The corrected controlled component gate passes in
`Server/.local/unity-random-search-owner-fixed.log`. It requires the exact rejection
before player/lobby mutation, then checks a controlled Ended transport releases
ownership once, emits one MatchClosed notification and preserves its terminal
snapshot bytes. The existing combined component/NGUI regression also passes.

The additional `UnityRandomRematchAudit` now reuses one actual Unity adapter for
two authenticated Backend queue allocations, with a real UDP Worker, SDK peer
and isolated MongoDB replica set. Each round reaches Running, forfeits through
the Worker, and releases the ended transport without changing its snapshot.
The coordinator waits for accepted terminal evidence and both durable player
pair releases before starting the next round. It requires a distinct match,
session, ticket and session key, then verifies the original accepted result
digest remains unchanged. The native run passed in
`Server/.local/queue-live-58cb6518e0614e9aa5e6964b8b94b047/UnityRandomRematch.log`.

This uses the explicit authenticated SDK entry point without menu/profile
stubs. It does not prove Dog Tag settlement, normal lobby-to-second-battle play
or two Unity clients.
End-to-end same-opponent friend/co-op rematch negotiation remains absent. Its required
two-party consent, cancellation/expiry and fresh allocator grants must be built
separately; the old Photon RematchRPC is not an accepted Worker command.

## Same-opponent consent foundation

`BattleRematchConsentStore` records consent separately from terminal results.
It accepts only the two player identities recovered from an accepted Ended
snapshot, binds the record to its result digest, and uses MongoDB's unique
match identity plus revision compare-and-set for concurrent requests.
One participant produces `waiting`; both produce `ready`. Either participant
can cancel before allocation. Cancelled and expired records cannot reopen.
The half-open thirty-second window comes from CheckRematchStates. Duplicate
requests do not extend it: unlike buffered Photon RPC delivery, a retry is not
a new consent. Millisecond timestamps match BSON persistence precision.

This store is not exposed as an HTTP endpoint and does not issue grants.
`ready` means mutual intent only. An allocator must still atomically reserve
the exact original participants, revalidate their current loadouts and mode,
fence cancellation against publication, and issue fresh Worker capabilities.
No wallet or Dog Tag changes are made by consent. Normal controllers and the
SDK still need typed consent/status/cancel integration; friend, human co-op
and co-op bot policy must remain distinct. No same-opponent gameplay claim
follows from the persistence test.

Run the isolated replica-set check with
`dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --rematch-consent-only <mongo-uri>`.
It checks concurrent first/second consent through independent store instances,
unchanged duplicate deadlines, outsider rejection, cancellation, the exact
expiry boundary, damaged-result binding rejection and terminal-result preservation.
