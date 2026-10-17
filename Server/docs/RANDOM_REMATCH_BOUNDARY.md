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
Normal Unity friend/co-op rematch remains incomplete. Durable consent and fresh
SDK allocation are implemented below; the old Photon RematchRPC is not an
accepted Worker command or a substitute for the remaining controller handoff.

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

`ready` means mutual intent only. `/v1/battle/rematch/allocate` consumes it
through the source-compatible allocator described below. Connection grants
remain on the existing `/v1/battle/grant` endpoint.
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
nonparticipant, malformed-ID and unknown-field rejection. Those request checks
alone do not prove a second allocation or Unity controller flow; the allocation
gate below covers the supported SDK admission path separately.

## Atomic reservation foundation

`ReserveAsync` consumes an unexpired `ready` record and inserts one new
`battle_pairs` row in the same snapshot/majority MongoDB transaction. When
provided, its prepared manifest is inserted in that same transaction. It binds
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

The HTTP allocator now calls this primitive with a prepared admission payload.
Unity controller handoff and broader loadout/mode support remain open.
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
is supported. The HTTP allocator uses this method before reserving participants.

`--rematch-manifest-only <mongo-uri>` checks real Mongo-backed equipment/rank
changes between rounds, reversed consent membership versus original slot
order, a second-slot scene master, original snapshot immutability and rejection
of mismatched source hashes, reused match IDs and stale shield authority.
The fixture uses reviewed rifle content and controlled account documents;
it is not Worker registration, full menu or same-opponent Unity gameplay proof.

## HTTP allocation and Worker handoff

`BattleRematchAllocator` serves `/v1/battle/rematch/allocate` using only a
canonical source match ID and authenticated account identity. The recovered
and modern account authentication paths are shared with other battle routes.
The configured catalog and compatibility key remain deployment-owned.

Before reservation it reads accepted terminal evidence, validates the original
ordered manifest, and prepares current supported equipment/profile projections.
Consent consumption, participant reservation and the exact prepared manifest
commit together. The allocator then invokes ordinary Worker registration and
active-pair-fenced grant publication. A successful `MatchQueueReply` has code
`paired` and a new match ID; `BackendClient.AllocateRematchAsync` exposes it.
The caller must fetch its own fresh grant before UDP admission.

Provisioning failures return `503 rematch_provision_deferred`; retries use the
same reservation and frozen payload, not a newly queried loadout. Released or
completed reservations return `completed` without registering the Worker again.
Missing or unsupported source authority returns `409 rematch_unavailable`.
Unconfigured allocation policy returns `503 rematch_disabled`.

Unity controller integration, post-reservation cancel UI behavior, admission expiry and all shield/army/bonus
projection paths remain unverified or unfinished. This is not full gameplay
or same-opponent friend/co-op feature completion.

The native `--queue-live <mongo-uri>` gate now plays an unscored rifle source
round and a same-opponent rematch through actual Backend HTTP, Worker UDP,
accepted terminal evidence and Mongo pair release. It requires two consents,
concurrent allocation convergence, distinct match/session/ticket/key identity,
source slot preservation, unchanged grant replay and `completed` replay after
the second terminal result. The original accepted result digest stays unchanged.
The passing native run is
`Server/.local/queue-live-5c8ee474b5404429a4dd557351ea3aba`.
These are two portable .NET SDK peers, not two Unity Clients or normal friend UI.

This gate initially exposed a Windows UDP `ConnectionReset (10054)` after a
peer closed its port. The shared Worker receiver now continues after peer
ConnectionReset/ConnectionRefused feedback without changing battle authority;
other socket failures retain their existing handling. The rerun completes the
second accepted result instead of stopping the entire Worker.

## Deferred registration recovery evidence

The native queue gate now stops its owned Worker after both source participants
consent, before calling rematch allocation. The actual Backend returns
`503 rematch_provision_deferred`; the test requires a retained `allocated`
record, both reserved participants, the frozen manifest, no terminal result and
no retrievable connection grant.

Before restarting the Worker, the gate changes one durable display name and
checks the Mongo update modified exactly one profile. Retry must register the
same reserved match, retain byte-identical admission data and publish a grant
with the original frozen profile and manifest hash. The temporary profile change
is restored afterward. The same SDK peers then complete the rematch and its
accepted result, and replay after completion still returns `completed`.

This passed in
`Server/.local/queue-live-60f04171eed24e48a43e665c9d47d863`, including
`RematchProvisionRecovery.log`. It proves recovery when registration initially
cannot reach the Worker; it does not prove response loss after registration,
Worker replacement during active combat, admission expiry, or Unity UI recovery.

## Lost registration acknowledgement evidence

`RegistrationReplyLossProxy` forwards the real signed control request bytes to
the owned Worker and aborts one downstream response only after observing a
successful `registered` reply. It forwards normal registration, reconnect,
cancellation and cancellation-evidence lookup paths without rewriting bodies.
No fake Worker response or credential is introduced.

The rematch gate requires `503 rematch_provision_deferred`, retained allocated
intent and frozen admission data, and no retrievable grant before recovery.
Retry must send identical frozen bytes and receive `existing-match`. The proxy
compares the entire returned grant-array digest; the SDK separately checks both
players' original session IDs and ticket/key fingerprints against that first
lost response. Capability values are never printed. The recovered round then
completes actual UDP admission, terminal acceptance and pair release, with
stable replay after completion.

This passed through real Backend, Worker and MongoDB in
`Server/.local/queue-live-7c7bf71aac6e4aa084c4ea399c96fa43`. The same native
run also includes the preceding Worker-outage/profile-change gate. This proves
one lost successful registration acknowledgement while the Worker remains
alive; Backend restart during the lost reply, admission expiry and Unity UI
handoff are separate remaining checks.
