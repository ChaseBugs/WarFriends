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

The authenticated protobuf API exposes `/v1/battle/rematch/read`, `/accept`
and `/cancel`, each with only a canonical `MatchGrantRequest.match_id`.
The authenticated account supplies the player identity; unknown request fields
are rejected. Modern and recovered legacy account tokens use the same battle
authentication boundary. Unavailable, foreign or damaged completed evidence
returns `409 rematch_unavailable` without disclosing the roster.
`MatchRematchConsent` returns match ID, status, accepted player IDs, revision
and the Unix-millisecond deadline. A missing consent reads `not-requested`
with zero revision/deadline; it does not create a window. Reads persist expiry
without adding a vote. `BackendClient` has matching read/accept/cancel methods.

These routes do not issue grants.
`ready` means mutual intent only. The reservation primitive below can consume
it atomically; the production allocator still needs to invoke that primitive,
revalidate current loadouts and mode, and issue fresh Worker capabilities.
No wallet or Dog Tag changes are made by consent. Normal Unity controllers
still need typed consent/status/cancel integration; friend, human co-op
and co-op bot policy must remain distinct. No same-opponent gameplay claim
follows from the persistence test.

Run the isolated replica-set check with
`dotnet Server/tests/War.Battle.Tests/bin/Release/net10.0/War.Battle.Tests.dll --rematch-consent-only <mongo-uri>`.
It checks concurrent first/second consent through independent store instances,
unchanged duplicate deadlines, outsider rejection, cancellation, the exact
expiry boundary, damaged-result binding rejection and terminal-result preservation.
The native `--queue-live <mongo-uri>` suite additionally checks real Backend
protobuf/SDK consent against an accepted Worker result, including unauthenticated,
nonparticipant, malformed-ID and unknown-field rejection. This is not a second
same-opponent allocation or Unity controller proof.

## Atomic reservation foundation

`ReserveAsync` consumes an unexpired `ready` record and inserts one new
`battle_pairs` row in the same snapshot/majority MongoDB transaction. It binds
the accepted result digest and exact participant set, checks existing pairs
and queue tickets, and relies on the allocator's unique participant index to
exclude competing pairs. Queue indexes must be initialized before this call.
The compatibility key is server-owned policy, not an HTTP request field.

The committed consent becomes `allocated` with a distinct `NextMatchId`.
Its reserved compatibility key is retained, so a retry cannot silently change
the server policy associated with that identity.
The allocator can supply the frozen source `PlayerOrder`; the pair and consumed
consent retain that exact order separately from sorted consent membership.
A retry cannot swap the slots. `GetForParticipantsAsync` reads the validated
source snapshot by participant set without replacing its original order.
Concurrent reservation retries return that same identity. A retry after pair
release or consent-window expiry does not recreate a battle. Cancellation
before reservation prevents publication; after reservation, it observes
`allocated` and leaves cancellation of the new pair to the ordinary
Worker-confirmed cancellation path. The API projects `next_match_id` as a
reservation pointer only, never as a connection grant.

`--rematch-reservation-only <mongo-uri>` checks concurrent reservation,
Mongo change-stream transaction identity, cancel/reserve ordering, missing or
single-party consent, outsider rejection, busy/expired requests, exhausted
revision rejection and replay after release. Its source result comes from a
controlled real MatchEngine fixture, not a normal Unity rematch session.

No HTTP allocation route calls this primitive yet. Production orchestration of
current-loadout validation and original map/mode/player-slot preservation,
Worker provisioning, fresh grants, post-reservation recovery and Unity
controller handoff remain open.
No wallet or Dog Tag transition is implemented by this reservation layer.

## Source-bound manifest refresh foundation

`BattleManifestFactory.CreateRematchAsync` parses the frozen source manifest
and requires its canonical digest to match the supplied accepted-result hash.
Its caller must obtain that hash from accepted terminal authority. The method
requires a new match ID, preserves source map/mode, participant order, placement
and scene master, and replaces weapon selections, card allocations and profile
presentations by querying current durable stores. Existing participant rank
fields refresh from those current presentations. The old snapshot is unchanged.

The source must still use the configured host and weapon catalog. A manifest
containing army/perk projections, shield levels or a PvP Gold-bonus admission
counter is rejected until those current projections can be rebuilt; none is
silently copied as current authority. This does not prove every loadout or mode
is supported, and the method is not connected to an HTTP allocation route yet.

`--rematch-manifest-only <mongo-uri>` checks real Mongo-backed equipment/rank
changes between rounds, reversed consent membership versus original slot
order, a second-slot scene master, original snapshot immutability and rejection
of mismatched source hashes, reused match IDs and stale shield authority.
The fixture uses reviewed rifle content and controlled account documents;
it is not Worker registration, full menu or same-opponent Unity gameplay proof.
